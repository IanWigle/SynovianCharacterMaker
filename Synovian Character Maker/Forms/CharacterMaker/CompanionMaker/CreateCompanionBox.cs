using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Synovian_Character_Maker.DataClasses;
using Synovian_Character_Maker.DataClasses.Instanced;
using Synovian_Character_Maker.Static_Classes;

namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    public partial class CreateCompanionBox : Form
    {
        private CompanionSheet.CompanionType companionType = CompanionSheet.CompanionType.None;
        string companionBeastSpecies = "";

        public CreateCompanionBox()
        {
            InitializeComponent();

            droidGroup.Enabled = false;

            foreach (Control control in droidGroup.Controls)
            {
                control.Enabled = false;
            }

            beastGroup.Enabled = false;

            foreach (Control control in beastGroup.Controls)
            {
                control.Enabled = false;
            }

            foreach(string species in Program._statRules.PossibleBeastSpecies)
            {
                string correct_spelling = species.Replace("_", " ");
                SpeciesCombo.Items.Add(correct_spelling);
            }
        }

        private void CanMakeCompanion()
        {
            bool valid = true;
            
            if(comboBox1.SelectedIndex < 1)
            {
                valid = false;
                goto EndValidation;
            }

            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                default:
                    {
                        valid = false;
                        goto EndValidation;
                    }
            }

            if (companionType == CompanionSheet.CompanionType.None && comboBox1.SelectedIndex != 2)
            {
                valid = false;
                goto EndValidation;
            }

            if(comboBox1.SelectedIndex == 2 && beastName.Text == "" && SpeciesCombo.Text == "")
            {
                valid = false;
                goto EndValidation;
            }

            EndValidation:
            makeButton.Enabled = valid;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = comboBox1.SelectedIndex;

            switch (choice)
            {
                // Set combo to none
                case 0:
                    {
                        droidGroup.Enabled = false;
                        
                        foreach(Control control in droidGroup.Controls)
                        {
                            control.Enabled = false;
                        }

                        beastGroup.Enabled = false;

                        foreach (Control control in beastGroup.Controls)
                        {
                            control.Enabled = false;
                        }

                        break;
                    }
                // Set combo to droid
                case 1:
                    {
                        droidGroup.Enabled = true;

                        foreach (Control control in droidGroup.Controls)
                        {
                            control.Enabled = true;
                        }

                        beastGroup.Enabled = false;

                        foreach (Control control in beastGroup.Controls)
                        {
                            control.Enabled = false;
                        }

                        companionType = CompanionSheet.CompanionType.None;

                        break;
                    }
                // Set combo to beast
                case 2:
                    {
                        droidGroup.Enabled = false;

                        foreach (Control control in droidGroup.Controls)
                        {
                            control.Enabled = false;
                        }

                        beastGroup.Enabled = true;

                        foreach (Control control in beastGroup.Controls)
                        {
                            control.Enabled = true;
                        }

                        companionType = CompanionSheet.CompanionType.Beast;

                        break;
                    }
            }

            CanMakeCompanion();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            companionType = (CompanionSheet.CompanionType)comboBox2.SelectedIndex;

            CanMakeCompanion();
        }

        

        private void makeButton_Click(object sender, EventArgs e)
        {
            List<Ability> abilities = Helpers.GetAvailableAbilities(companionType);

            if (companionType == CompanionSheet.CompanionType.Beast)
            {
                List<Ability> missingAbilities = new List<Ability>();

                if (!Program.GetOpenedSheet().Contains("Taming I")) missingAbilities.Add(Program.abilityLibrary.GetAbility("Taming I"));
                if (!Program.GetOpenedSheet().Contains("Taming II")) missingAbilities.Add(Program.abilityLibrary.GetAbility("Taming II"));

                switch (Program.GetOpenedSheet().alignment)
                {
                    case Ability_Alignment.Ability_Light:
                        {
                            if (!Program.GetOpenedSheet().Contains("Animal Friendship I")) missingAbilities.Add(Program.abilityLibrary.GetAbility("Animal Friendship I"));
                            break;
                        }
                    case Ability_Alignment.Ability_Dark:
                        {
                            if (!Program.GetOpenedSheet().Contains("Beast Control I")) missingAbilities.Add(Program.abilityLibrary.GetAbility("Beast Control I"));
                            break;
                        }
                    case Ability_Alignment.Ability_NonForce:
                        {
                            break;
                        }
                }

                string message = "For this companion you are missing the following abilities for an animal :\n";
                foreach(Ability ability in missingAbilities)
                {
                    message += ability.Name;
                    message += "\n";
                }
                message += "\nWould you like us to add these abilities onto your sheet?";

                if (missingAbilities.Count > 0)
                {
                    switch(MessageBox.Show(message,"Notice!",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1))
                    {
                        case DialogResult.Yes:
                            {
                                Program.GetOpenedSheet().AddAbilities(missingAbilities);
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                Close();
                                break;
                            }
                    }
                }
            }

            CompanionSheet companionSheet = new CompanionSheet((companionType == CompanionSheet.CompanionType.Beast) ? beastName.Text : droidName.Text, companionBeastSpecies,ref Program._statRules, ref Program.abilityLibrary);
            //if (companionType == CompanionSheet.CompanionType.Beast) companionSheet.SetCompanionSpecies(speciesBox.Text);

            CompanionEditor companionEditor = new CompanionEditor(companionSheet, abilities);

            this.Visible = false;

            companionEditor.ShowDialog();

            Close();
        }

        private void beastName_TextChanged(object sender, EventArgs e)
        {
            CanMakeCompanion();
        }

        private void beastName_Leave(object sender, EventArgs e)
        {
            CanMakeCompanion();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            companionBeastSpecies = SpeciesCombo.Items[SpeciesCombo.SelectedIndex] as string;
        }
    }
}
