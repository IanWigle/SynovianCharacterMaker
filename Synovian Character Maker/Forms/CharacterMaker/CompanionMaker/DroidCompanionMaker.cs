using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    public partial class DroidCompanionMaker : Form
    {
        private Data_Classes.CompanionSheet companionSheet;
        public DroidCompanionMaker()
        {
            InitializeComponent();
            nameBox.Text = Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet.companionName;
            RefreshList();

            companionSheet = Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet;

            if(companionSheet._image != null)
            {
                droidCompanionPicture.Image = companionSheet._image;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void RefreshList()
        {
            if (companionSheet == null)
                return;
            else
            {
                // Ability Library List

                abilityList.Items.Clear();

                foreach (Data_Classes.Ability ability in Program.abilityLibrary.GetAbilities())
                {
                    // If the ability is not a droid one, skip it.
                    if (ability.ability_School != Data_Classes.Ability_Schools.Ability_Droids)
                        continue;

                    if (ability.Name == companionSheet.s_primaryCompanionType || companionSheet.s_additionalCompanionTypes.Contains(ability.Name))
                        continue;

                    // double check if this is a type ability
                    if (ability.prereqs.Count() == 0)
                        continue;

                    if (companionSheet.abilities.Contains(ability.ID))
                        continue;

                    // Check to see if the prereq is a valid ability/type.
                    // All companion prereq abilities have no prereqs, therefore we can just look at the 
                    // name.
                    if (Program.abilityLibrary.TryGetAbility(ability.prereqs[0], out Data_Classes.Ability ability1))
                    {
                        // To now check if the ability is valid to be used by the companion, we now check the prereq ability found
                        // with the companion primary type. We should also check if it is in the additional types as well.
                        if (ability1.Name == companionSheet.s_primaryCompanionType || companionSheet.s_additionalCompanionTypes.Contains(ability1.Name))
                        {
                            string[] subitems = { ability.Name, ability.description };
                            ListViewItem listViewItem = new ListViewItem(subitems);
                            abilityList.Items.Add(listViewItem);
                        }
                    }
                }

                // Companion List
                companionList.Items.Clear();
                foreach(int ability in companionSheet.abilities)
                {
                    if (Program.abilityLibrary.TryGetAbility(ability, out Data_Classes.Ability abilityData))
                    {
                        if (Program.abilityLibrary.TryGetAbility(abilityData.prereqs[0], out Data_Classes.Ability prereqAbility))
                        {
                            if (prereqAbility.Name == companionSheet.s_primaryCompanionType || companionSheet.s_additionalCompanionTypes.Contains(prereqAbility.Name))
                            {
                                string[] subitems = { abilityData.Name, abilityData.description };
                                ListViewItem listViewItem = new ListViewItem(subitems);
                                companionList.Items.Add(listViewItem);
                            }
                        }
                    }
                }
            }
        }

        private void abilityList_Click(object sender, EventArgs e)
        {
            if(Program.abilityLibrary.TryGetAbility(abilityList.FocusedItem.Text, out Data_Classes.Ability ability))
            {
                descriptionBox.Text = ability.description;
            }
        }

        private void abilityList_DoubleClick(object sender, EventArgs e)
        {
            if(Program.abilityLibrary.TryGetAbility(abilityList.FocusedItem.Text, out Data_Classes.Ability ability))
            {
                Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet.abilities.Add(ability.ID);
                RefreshList();
            }
        }

        private void companionList_DoubleClick(object sender, EventArgs e)
        {
            if (Program.abilityLibrary.TryGetAbility(companionList.FocusedItem.Text, out Data_Classes.Ability ability))
            {
                Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet.abilities.Remove(ability.ID);
                RefreshList();
            }
        }

        private void deleteCharButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete your companion?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet = null;
                Close();
            }
            else
                return;
        }

        private void CompanionMaker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void loadpictureButton_Click(object sender, EventArgs e)
        {
            loadPictureDialog.Title = "Open Image";
            loadPictureDialog.DefaultExt = ".jpg";
            loadPictureDialog.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|gif files (*.gif)|*.gif|ico images (*.ico)|*.ico|png images (*.png)|*.png|wdp images (*.wdp)|*.wdp|tiff images (*.tiff)|*.tiff|All files (*.*)|*.*";
            loadPictureDialog.ShowDialog();
        }

        private void loadPictureDialog_FileOk(object sender, CancelEventArgs e)
        {
            droidCompanionPicture.Image = Image.FromFile(loadPictureDialog.FileName);
        }

        private void DroidCompanionMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(droidCompanionPicture.Image != null)
            {
                Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet._image = droidCompanionPicture.Image;
            }
        }
    }
}
