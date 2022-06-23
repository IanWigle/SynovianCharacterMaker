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
    public partial class CompanionMenu : Form
    {
        private string selectedCompanion;

        public CompanionMenu()
        {
            InitializeComponent();

            int validAnimAbilities = 0;
            int validDroidAbilities = 0;
            string[] animabilities = new string[] { "Animal Friendship I", "Animal Friendship II", "Animal Friendship III" };
            string[] droidabilities = new string[] { "Class I Droids", "Class II Droids", "Class III Droids", "Class IV Droids" };
            int validAbilities = animabilities.Length + droidabilities.Length;

            CharacterSheet characterSheet = Program.GetOpenedSheet();

            foreach(string ab in animabilities)
            {
                if (characterSheet.Contains(ab))
                    validAbilities++;
            }

            foreach(string droid in droidabilities)
            {
                if(characterSheet.Contains(droid))
                    validDroidAbilities++;
            }

            foreach(CompanionSheet companionSheet in characterSheet.companionSheets)
            {
                if (companionSheet == null)
                {
                    characterSheet.companionSheets.Remove(companionSheet);
                    continue;
                }

                if (companionSheet.primaryCompanionType == CompanionSheet.CompanionType.Beast && validAnimAbilities > 0)
                    goto AddSheetToList;
                else if (companionSheet.primaryCompanionType == CompanionSheet.CompanionType.Beast)
                {
                    DialogResult dialogResult = MessageBox.Show("You have an animal companion but you don't have an animal companion skill. Add one?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    switch(dialogResult)
                    {
                        case DialogResult.Yes:
                            {
                                goto AddSheetToList;
                            }
                        case DialogResult.No:
                            {
                                goto AddSheetToList;
                            }
                        default:
                            {
#if DEBUG
                                throw (new Exception("Reached impossible outcome!"));
#endif
                                continue;
                            }
                    }
                }
                else if (companionSheet.primaryCompanionType >= CompanionSheet.CompanionType.Research_Droid && companionSheet.primaryCompanionType <= CompanionSheet.CompanionType.Assassin_Droid)
                {
                    string neededSkill = "";

                    if (companionSheet.primaryCompanionType <= CompanionSheet.CompanionType.Medical_Droid)
                    {
                        neededSkill = "Class I Droids";
                    }
                    else if (companionSheet.primaryCompanionType <= CompanionSheet.CompanionType.Astromech_Droid && companionSheet.primaryCompanionType >= CompanionSheet.CompanionType.Engineering_Droid)
                    {
                        neededSkill = "Class II Droids";
                    }
                    else if (companionSheet.primaryCompanionType == CompanionSheet.CompanionType.Protocol_Droid)
                    {
                        neededSkill = "Class III Droids";
                    }
                    else if (companionSheet.primaryCompanionType >= CompanionSheet.CompanionType.Battle_Droid)
                    {
                        neededSkill = "Class IV Droids";
                    }

                    if(characterSheet.Contains(neededSkill))
                        goto AddSheetToList;
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show($"Your companion droid {companionSheet.companionName} requires {neededSkill}. Add it to your list?", "Notice!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        switch(dialogResult)
                        { 
                            case DialogResult.Yes:
                                {
                                    characterSheet.AddAbility(Program.abilityLibrary.GetAbility(neededSkill));

                                    goto AddSheetToList;
                                }
                            case DialogResult.No:
                                {
                                    goto AddSheetToList;
                                }
                            default:
                                {
#if DEBUG
                                    throw (new Exception("Reached impossible outcome!"));
#endif
                                    continue;
                                }
                        }
                    }
                }

                AddSheetToList:
                string[] subitems = { companionSheet.companionName, companionSheet.s_primaryCompanionType };
                companionList.Items.Add(new ListViewItem(subitems));
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            CreateCompanionBox createCompanionBox = new CreateCompanionBox();
            createCompanionBox.ShowDialog();


            var comp = Program.GetOpenedSheet().companionSheets.Last();

            companionList.Items.Clear();

            foreach(CompanionSheet companionSheet in Program.GetOpenedSheet().companionSheets)
            {
                companionList.Items.Add(new ListViewItem(new string[] { companionSheet.companionName, companionSheet.s_primaryCompanionType }));
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string name = companionList.SelectedItems[0].Text;
            Program.GetOpenedSheet().RemoveCompanion(name);

            companionList.Items.Clear();

            foreach (CompanionSheet compSheet in Program.GetOpenedSheet().companionSheets)
            {
                companionList.Items.Add(new ListViewItem(new string[] { compSheet.companionName, compSheet.s_primaryCompanionType }));
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string name = companionList.SelectedItems[0].Text;
            CompanionSheet comp = null;

            foreach(CompanionSheet companionSheet in Program.GetOpenedSheet().companionSheets)
            {
                if(name == companionSheet.companionName)
                {
                    comp = companionSheet;
                }
            }
            
            if (comp != null)
            {
                CompanionEditor companionEditor = new CompanionEditor(comp, Helpers.GetAvailableAbilities(comp.primaryCompanionType));
                companionEditor.ShowDialog();
            }
        }

        private void companionList_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = (companionList.FocusedItem != null) ? true : false;
            editButton.Enabled = (companionList.FocusedItem != null) ? true : false;
        }

        private void companionList_DoubleClick(object sender, EventArgs e)
        {
            string name = companionList.SelectedItems[0].Text;
            CompanionSheet comp = null;

            foreach (CompanionSheet companionSheet in Program.GetOpenedSheet().companionSheets)
            {
                if (name == companionSheet.companionName)
                {
                    comp = companionSheet;
                }
            }

            if (comp != null)
            {
                CompanionEditor companionEditor = new CompanionEditor(comp, Helpers.GetAvailableAbilities(comp.primaryCompanionType));
                companionEditor.ShowDialog();
            }
        }
    }
}
