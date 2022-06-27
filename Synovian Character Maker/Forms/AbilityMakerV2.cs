using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Synovian_Character_Maker.DataClasses.Instanced;

namespace Synovian_Character_Maker.Forms
{
    public partial class AbilityMakerV2 : Form
    {
        enum ColumnSort
        {
            None,
            Name,
            Rank,
            Alignment,
            School
        }

        ColumnSort lastSort = ColumnSort.None;


        public AbilityMakerV2()
        {
            InitializeComponent();

            foreach(string s_rank in Enum.GetNames(typeof(Rank)))
            {
                if (s_rank == "Invalid" || s_rank == "Max")
                    continue;

                RankBox.Items.Add(s_rank);
            }
            RankBox.SelectedIndex = 0;

            foreach(string s_align in Enum.GetNames(typeof(Ability_Alignment)))
            {
                if(s_align == "Ability_Invalid" || s_align == "Ability_Max")
                    continue;

                AlignBox.Items.Add(s_align);
            }
            AlignBox.SelectedIndex = 0;

            foreach(string s_school in Enum.GetNames(typeof(Ability_Schools)))
            {
                if(s_school == "Ability_Invalid" || s_school == "Ability_Max")
                    continue;

                SchoolBox.Items.Add(s_school);
            }
            SchoolBox.SelectedIndex = 0;

            RefreshList();
        }

        private void validationPrereqButton_Click(object sender, EventArgs e)
        {
            string prereqs_str = prereqBox.Text;
            string[] indivual_ones = prereqs_str.Split(',');

            List<string> unknownAbilities = new List<string>();
            foreach(string ability in indivual_ones)
            {
                if (ability == "")
                    continue;

                if(!Program.abilityLibrary.Contains(ability))
                {
                    unknownAbilities.Add(ability);
                }
            }

            MessageBox.Show($"Found {unknownAbilities.Count} issues","Check complete",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void makeAbilityButton_Click(object sender, EventArgs e)
        {
            string prereqs_str = prereqBox.Text;
            string[] indivual_ones = prereqs_str.Split(',');

            List<int> prereqIDs = new List<int>();
            foreach (string s in indivual_ones)
            {
                if (s == "")
                    continue;

                if (Program.abilityLibrary.Contains(s))
                {
                    prereqIDs.Add(Program.abilityLibrary.GetAbility(s).ID);
                }
            }
            Ability ability = new Ability(nameBox.Text, 
                                          descriptionBox.Text, 
                                          Program.abilityLibrary.newID,
                                          (Ability_Alignment)Enum.Parse(typeof(Ability_Alignment),AlignBox.Text),
                                          (Rank)Enum.Parse(typeof(Rank), RankBox.Text),
                                          (Ability_Schools)Enum.Parse(typeof(Ability_Schools), SchoolBox.Text),
                                          prereqIDs, 
                                          (int)skillCostBox.Value, 
                                          isFeatCheck.Checked);

            Program.abilityLibrary.AddNewAbility(ability);
            RefreshList();
            resetButton_Click(this,new EventArgs());
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            nameBox.Text = "";
            descriptionBox.Text = "";
            RankBox.SelectedIndex = 0;
            AlignBox.SelectedIndex = 0;
            SchoolBox.SelectedIndex = 0;
            prereqBox.Text = "";
            skillCostBox.Value = 1;

            readOnlyAbilName.Text = "";
            readOnlyAbilDescription.Text = "";
            readonlyRank.Text = "";
            readonlyAlignment.Text = "";
            readOnlySchool.Text = "";
            readOnlyPrereqs.Text = "";
            readOnlyIsFeat.Checked = false;
        }

        private void RefreshList(ColumnSort columnSort = ColumnSort.None)
        {
            AbilityList.Items.Clear();            

            switch (columnSort)
            {
                case ColumnSort.None:
                    {
                        foreach (Ability ability in Program.abilityLibrary.GetAbilities())
                        {
                            AbilityList.Items.Add(new ListViewItem(new string[] { ability.Name, ability.s_rank, ability.s_alignment, ability.s_ability_School }));
                        }
                        break;
                    }
                case ColumnSort.Name:
                    {
                        var rawAbilities = Program.abilityLibrary.GetAbilities();
                        List<string> abilityNames = new List<string>();
                        foreach (Ability ability in rawAbilities)
                        {
                            abilityNames.Add(ability.Name);
                        }

                        abilityNames.Sort();

                        foreach (string abilityName in abilityNames)
                        {
                            Ability ability = Program.abilityLibrary.GetAbility(abilityName);

                            AbilityList.Items.Add(new ListViewItem(new string[] { ability.Name, ability.s_rank, ability.s_alignment, ability.s_ability_School }));
                        }
                        break;
                    }
                case ColumnSort.Rank:
                    {
                        foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                        {
                            if (rank == Rank.Invalid || rank >= Rank.Emperor)
                                continue;
                            foreach (Ability ability in Program.abilityLibrary.GetAbilities())
                            {
                                if(ability.Rank == rank)
                                    AbilityList.Items.Add(new ListViewItem(new string[] { ability.Name, ability.s_rank, ability.s_alignment, ability.s_ability_School }));
                            }
                        }
                        break;
                    }
                case ColumnSort.Alignment:
                    {
                        foreach (Ability_Alignment alignment in Enum.GetValues(typeof(Ability_Alignment)))
                        {
                            if (alignment == Ability_Alignment.Ability_Invalid || alignment == Ability_Alignment.Ability_Max)
                                continue;
                            foreach (Ability ability in Program.abilityLibrary.GetAbilities())
                            {
                                if (ability.alignment == alignment)
                                    AbilityList.Items.Add(new ListViewItem(new string[] { ability.Name, ability.s_rank, ability.s_alignment, ability.s_ability_School }));
                            }
                        }
                        break;
                    }
                case ColumnSort.School:
                    {
                        foreach (Ability_Schools school in Enum.GetValues(typeof(Ability_Schools)))
                        {
                            if (school == Ability_Schools.Ability_Invalid || school == Ability_Schools.Ability_Max)
                                continue;
                            foreach (Ability ability in Program.abilityLibrary.GetAbilities())
                            {
                                if (ability.ability_School == school)
                                    AbilityList.Items.Add(new ListViewItem(new string[] { ability.Name, ability.s_rank, ability.s_alignment, ability.s_ability_School }));
                            }
                        }
                        break;
                    }
            }
        }

        private void AbilityList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lastSort = (ColumnSort)e.Column;
            switch (e.Column)
            {
                // Name
                case 0:
                    {
                        
                        RefreshList(ColumnSort.Name);
                        break;
                    }
                // Rank
                case 1:
                    {
                        RefreshList(ColumnSort.Rank);
                        break;
                    }
                // Alignment
                case 2:
                    {
                        RefreshList(ColumnSort.Alignment);
                        break;
                    }
                // School
                case 3:
                    {
                        RefreshList(ColumnSort.School);
                        break;
                    }
            }
                
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (AbilityList.FocusedItem == null) return;
            switch (MessageBox.Show("Are you sure you want to do this? The change can't be reversed.", "Caution!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                case DialogResult.OK:
                {
                    foreach(ListViewItem listViewItem in AbilityList.SelectedItems)
                    Program.abilityLibrary.TryRemoveAbility(listViewItem.Text);
                        AbilityList.FocusedItem = null;
                    break;
                }
                default:
                {
                    break;
                }
            }

            resetButton_Click(this, new EventArgs());
            RefreshList(lastSort);
        }

        private void AbilityList_Click(object sender, EventArgs e)
        {
            if (Program.abilityLibrary.TryGetAbility(AbilityList.FocusedItem.Text, out Ability ability))
            {
                readOnlyAbilName.Text = ability.Name;
                readOnlyAbilDescription.Text = ability.description;
                readonlyRank.Text = ability.s_rank;
                readonlyAlignment.Text = ability.s_alignment;
                readOnlySchool.Text = ability.s_ability_School;
                readOnlyPrereqs.Text = ability.sql_prepres;
                readOnlyIsFeat.Checked = ability.isFeat;
            }
        }
    }
}
