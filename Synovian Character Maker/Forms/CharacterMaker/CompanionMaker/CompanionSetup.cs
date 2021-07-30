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

namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    public partial class CompanionSetup : Form
    {
        CompanionSheet.CompanionType companionType = CompanionSheet.CompanionType.None;
        
        private string previewlabelText;
        enum CompanionSelection
        {
            NoChoice,
            Droid,
            Beast
        }

        CompanionSelection companionSelection = CompanionSelection.NoChoice;

        string startingText = "Companion Name . . .";

        public CompanionSetup()
        {
            InitializeComponent();
            makeCompanion.Enabled = false;
            compNameText.Text = startingText;
            previewlabelText = companionPreviewLabel.Text;
            droidComboOptions.Enabled = false;
            beastSpeciesText.Enabled = false;
        }

        private void beastSelect_CheckedChanged(object sender, EventArgs e)
        {
            beastSpeciesText.Enabled = beastSelect.Checked;

            companionSelection = CompanionSelection.Beast;
            companionPreviewLabel.Text = previewlabelText + "Beast";
            validateCheck();
        }

        private void droidSelection_CheckedChanged(object sender, EventArgs e)
        {
            droidComboOptions.Enabled = droidSelection.Checked;

            companionSelection = CompanionSelection.Droid;
            companionPreviewLabel.Text = previewlabelText + 
                ((companionType != CompanionSheet.CompanionType.None) ? "Droid (" + Enum.GetName(typeof(CompanionSheet.CompanionType), companionType) + ")" : "Droid");
            validateCheck();
        }

        private void makeCompanion_Click(object sender, EventArgs e)
        {
            switch (companionSelection)
            {
                case CompanionSelection.Beast:
                    {
                        CompanionSheet companionSheet = new CompanionSheet(compNameText.Text, beastSpeciesText.Text);
                        Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet = companionSheet;
                        Static_Classes.Helpers.GetForm<CharacterMaker>().WriteLog($"Make companion named {companionSheet.companionName}");
                        Beast_Companion_Maker beast_Companion_Maker = new Beast_Companion_Maker();
                        Close();
                        beast_Companion_Maker.ShowDialog();
                        break;
                    }
                case CompanionSelection.Droid:
                    {
                        CompanionSheet.CompanionType primaryCompanionType = companionType;
                        List<CompanionSheet.CompanionType> secondaryCompanionType = new List<CompanionSheet.CompanionType>();
                        switch (primaryCompanionType)
                        {
                            case CompanionSheet.CompanionType.Research_Droid:
                                secondaryCompanionType.Add(CompanionSheet.CompanionType.Medical_Droid);
                                secondaryCompanionType.Add(CompanionSheet.CompanionType.Engineering_Droid);
                                secondaryCompanionType.Add(CompanionSheet.CompanionType.Astromech_Droid);
                                break;
                            case CompanionSheet.CompanionType.Security_Droid:
                                secondaryCompanionType.Add(CompanionSheet.CompanionType.Battle_Droid);
                                break;
                            case CompanionSheet.CompanionType.Assassin_Droid:
                                secondaryCompanionType.Add(CompanionSheet.CompanionType.Battle_Droid);
                                break;
                            default:
                                break;
                        }
                        CompanionSheet companionSheet = new CompanionSheet(compNameText.Text, primaryCompanionType, secondaryCompanionType);

                        if (Static_Classes.Helpers.TryGetForm(typeof(CharacterMaker), out Form form))
                        {
                            (form as CharacterMaker).current_characterSheet.companionSheet = companionSheet;
                            (form as CharacterMaker).WriteLog($"Made the companion {companionSheet.companionName}");
                            DroidCompanionMaker companionMaker = new DroidCompanionMaker();

                            Close();
                            companionMaker.ShowDialog();
                        }
                        break;
                    }
            }
        }

        private void validateCheck()
        {
            bool valid = true;
            if (compNameText.Text == startingText)
                valid = false;
            if (companionSelection == CompanionSelection.NoChoice)
                valid = false;
            else if (companionSelection == CompanionSelection.Droid)
            {
                if (companionType == CompanionSheet.CompanionType.None)
                    valid = false;
            }
            else if (companionSelection == CompanionSelection.Beast)
            {
                if (beastSpeciesText.Text == "")
                    valid = false;
            }
            if (droidSelection.Checked == true && beastSelect.Checked == true)
                valid = false;
            if (valid)
                makeCompanion.Enabled = true;
        }

        private void compNameText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                validateCheck();
        }

        private void CompanionSetup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void droidComboOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            companionType = (CompanionSheet.CompanionType)((droidComboOptions.SelectedIndex >= 2) ? droidComboOptions.SelectedIndex + 1: droidComboOptions.SelectedIndex);

            companionPreviewLabel.Text = previewlabelText +
                ((companionType != CompanionSheet.CompanionType.None) ? "Droid (" + Enum.GetName(typeof(CompanionSheet.CompanionType), companionType).Replace('_',' ') + ")" : "Droid");
        }

        private void beastSpeciesText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                validateCheck();
        }
    }
}
