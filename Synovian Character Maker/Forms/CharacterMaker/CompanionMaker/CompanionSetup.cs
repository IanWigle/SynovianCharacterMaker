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
        }

        private void beastSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (beastSelect.Checked == false)
                return;

            companionSelection = CompanionSelection.Beast;
        }

        private void droidSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (droidSelection.Checked == false)
                return;

            companionSelection = CompanionSelection.Droid;
        }

        private void makeCompanion_Click(object sender, EventArgs e)
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

            if(Static_Classes.Helpers.TryGetForm(typeof(CharacterMaker),out Form form))
            {
                (form as CharacterMaker).current_characterSheet.companionSheet = companionSheet;
                (form as CharacterMaker).WriteLog($"Made the companion {companionSheet.companionName}");
                CompanionMaker companionMaker = new CompanionMaker();

                Close();
                companionMaker.ShowDialog();
            }
        }

        private void validateCheck()
        {
            bool valid = true;
            if (compNameText.Text == startingText)
                valid = false;
            if (companionSelection == CompanionSelection.NoChoice)
                valid = false;
            if (companionType == CompanionSheet.CompanionType.None)
                valid = false;
            if (valid)
                makeCompanion.Enabled = true;
        }

        private void researchChoice_Click(object sender, EventArgs e)
        {
            companionType = CompanionSheet.CompanionType.Research_Droid;
            validateCheck();
        }

        private void astromechChoice_Click(object sender, EventArgs e)
        {
            companionType = CompanionSheet.CompanionType.Astromech_Droid;
            validateCheck();
        }

        private void protocolChoice_Click(object sender, EventArgs e)
        {
            companionType = CompanionSheet.CompanionType.Protocol_Droid;
            validateCheck();
        }

        private void battleChoice_Click(object sender, EventArgs e)
        {
            companionType = CompanionSheet.CompanionType.Battle_Droid;
            validateCheck();
        }

        private void securityChoice_Click(object sender, EventArgs e)
        {
            companionType = CompanionSheet.CompanionType.Security_Droid;
            validateCheck();
        }

        private void assassinChoice_Click(object sender, EventArgs e)
        {
            companionType = CompanionSheet.CompanionType.Assassin_Droid;
            validateCheck();
        }

        private void compNameText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                validateCheck();
        }
    }
}
