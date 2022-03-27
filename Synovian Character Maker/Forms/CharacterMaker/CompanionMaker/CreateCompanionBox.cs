using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Synovian_Character_Maker.Data_Classes;
using Synovian_Character_Maker.Static_Classes;

namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    public partial class CreateCompanionBox : Form
    {
        private CompanionSheet.CompanionType companionType = CompanionSheet.CompanionType.None;

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

            if(comboBox1.SelectedIndex == 2 && beastName.Text == "" && speciesBox.Text == "")
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

            CompanionSheet companionSheet = new CompanionSheet((companionType == CompanionSheet.CompanionType.Beast) ? beastName.Text : droidName.Text, companionType);
            if (companionType == CompanionSheet.CompanionType.Beast) companionSheet.SetCompanionSpecies(speciesBox.Text);

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

        private void speciesBox_TextChanged(object sender, EventArgs e)
        {
            CanMakeCompanion();
        }
    }
}
