using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Synovian_Character_Maker.Data_Classes;

namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    public struct Filters
    {
        public List<Rank> acceptedRanks { get; set; }
        public List<Ability_Alignment> acceptedAlignment { get; set; }
        public List<Ability_Schools> acceptedSchools { get; set; }
        public bool isFeat { get; set; }
        public Filters(bool _isFeat, List<Rank> _ranks, List<Ability_Alignment> _align, List<Ability_Schools> _schools)
        {
            isFeat = _isFeat;
            acceptedRanks = _ranks;
            acceptedAlignment = _align;
            acceptedSchools = _schools;
        }
        public void Fill()
        {
            for (int i = 1; i < (int)Rank.Max; i++)
            {
                acceptedRanks.Add((Rank)i);
            }
            for (int i = 1; i < (int)Ability_Alignment.Ability_Max;i++)
            {
                acceptedAlignment.Add((Ability_Alignment)i);
            }
            for (int i = 1; i < (int)Ability_Schools.Ability_Max;i++)
            {
                acceptedSchools.Add((Ability_Schools)i);
            }
        }
        public void Clear()
        {
            acceptedRanks.Clear();
            acceptedAlignment.Clear();
            acceptedSchools.Clear();
        }
        public bool ContainsAlignment(Ability_Alignment ability_Alignment)
        {
            foreach(Ability_Alignment ability_Alignment1 in acceptedAlignment)
                if (ability_Alignment1 == ability_Alignment) return true;
            return false;
        }
        public bool ContainsRank(Rank rank)
        {
            foreach (Rank rank1 in acceptedRanks)
                if (rank1 == rank) return true;
            return false;
        }
        public bool ContainsSchool(Ability_Schools ability_Schools)
        {
            foreach (Ability_Schools ability_Schools1 in acceptedSchools)
                if (ability_Schools == ability_Schools1) return true;
            return false;
        }
    };

    public partial class FilterTab : Form
    {
        public Filters filters = new Filters(false, new List<Rank>(), new List<Ability_Alignment>(), new List<Ability_Schools>());

        public FilterTab()
        {
            InitializeComponent();

            List<CheckBox> items = GetAllCheckBoxesRecursively(this);
            filters.Fill();
            foreach(CheckBox checkBox in items)
            {
                checkBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
                checkBox.Checked = true;
            }
        }

        private List<CheckBox> GetAllCheckBoxesRecursively(Control control)
        {
            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (Control item in control.Controls)
            {
                CheckBox check = item as CheckBox;
                if(check != null)
                {
                    checkBoxes.Add(check);
                }
                else
                {
                    checkBoxes.AddRange(GetAllCheckBoxesRecursively(item));
                }
            }

            return checkBoxes; 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as CheckBox).Parent.GetType() == typeof(GroupBox))
            {
                GroupBox groupBox = (sender as CheckBox).Parent as GroupBox;

                if(groupBox.Text == "Rank")
                {
                    foreach(Control control in groupBox.Controls)
                    {
                        if(control.GetType() == typeof(CheckBox))
                        {
                            CheckBox checkBox = control as CheckBox;
                            switch (checkBox.Text)
                            {
                                case "Acolyte":
                                    if (checkBox.Checked)
                                        AddRankFilter(Rank.Acolyte);
                                    else
                                        filters.acceptedRanks.Remove(Rank.Acolyte);
                                    break;
                                case "Apprentice":
                                    if (checkBox.Checked)
                                        AddRankFilter(Rank.Apprentice);
                                    else
                                        filters.acceptedRanks.Remove(Rank.Apprentice);
                                    break;
                                case "Knight":
                                    if (checkBox.Checked)
                                        AddRankFilter(Rank.Knight);
                                    else
                                        filters.acceptedRanks.Remove(Rank.Knight);
                                    break;
                                case "Lord":
                                    if (checkBox.Checked)
                                        AddRankFilter(Rank.Lord);
                                    else
                                        filters.acceptedRanks.Remove(Rank.Lord);
                                    break;
                                case "Archon":
                                    if (checkBox.Checked)
                                        AddRankFilter(Rank.Archon);
                                    else
                                        filters.acceptedRanks.Remove(Rank.Archon);
                                    break;
                                case "Elder":
                                    if (checkBox.Checked)
                                        AddRankFilter(Rank.Elder);
                                    else
                                        filters.acceptedRanks.Remove(Rank.Elder);
                                    break;
                                default:
                                    continue;
                            }
                        }
                    }
                }
                else if (groupBox.Text == "Alignment")
                {
                    foreach(Control control in groupBox.Controls)
                    {
                        CheckBox checkBox = control as CheckBox;

                        switch(checkBox.Text)
                        {
                            case "Neutral":
                                if (checkBox.Checked)
                                    AddAlignmentFilter(Ability_Alignment.Ability_Neutral);
                                else
                                    filters.acceptedAlignment.Remove(Ability_Alignment.Ability_Neutral);
                                break;
                            case "Darkside":
                                if (checkBox.Checked)
                                    AddAlignmentFilter(Ability_Alignment.Ability_Dark);
                                else
                                    filters.acceptedAlignment.Remove(Ability_Alignment.Ability_Dark);
                                break;
                            case "Lightside":
                                if (checkBox.Checked)
                                    AddAlignmentFilter(Ability_Alignment.Ability_Light);
                                else
                                    filters.acceptedAlignment.Remove(Ability_Alignment.Ability_Light);
                                break;
                            case "NonForce":
                                if (checkBox.Checked)
                                    AddAlignmentFilter(Ability_Alignment.Ability_NonForce);
                                else
                                    filters.acceptedAlignment.Remove(Ability_Alignment.Ability_NonForce);
                                break;
                            default:
                                continue;
                        }
                    }
                }
                else if (groupBox.Text == "Schools")
                {
                    foreach(Control control in groupBox.Controls)
                    {
                        CheckBox checkBox = control as CheckBox;

                        switch (checkBox.Text)
                        {
                            case "Defense":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Defense);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Defense);
                                break;
                            case "Offense":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Offense);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Offense);
                                break;
                            case "Survival":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Survival);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Survival);
                                break;
                            case "Engineering":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Engineering);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Engineering);
                                break;
                            case "Mobility":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Mobility);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Mobility);
                                break;
                            case "Medical":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Medical);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Medical);
                                break;
                            case "Mentalism":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Mentalism);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Mentalism);
                                break;
                            case "Understand":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Understanding);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Understanding);
                                break;
                            case "Forms":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Forms);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Forms);
                                break;
                            case "Technology":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Technology);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Technology);
                                break;
                            case "Droids":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Droids);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Droids);
                                break;
                            case "Relics":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Relics);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Relics);
                                break;
                            case "Arms":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Arms);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Arms);
                                break;
                            case "Explosives":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Explosives);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Explosives);
                                break;
                            case "CQC":
                                if (checkBox.Checked)
                                    AddSchoolFilter(Ability_Schools.Ability_Close_Quarters);
                                else
                                    filters.acceptedSchools.Remove(Ability_Schools.Ability_Close_Quarters);
                                break;
                            default:
                                continue;
                        }
                    }
                }
            }
        }

        private void AddSchoolFilter(Ability_Schools ability_Schools)
        {
            if (filters.acceptedSchools.Contains(ability_Schools))
                return;
            else
                filters.acceptedSchools.Add(ability_Schools);
        }

        private void AddRankFilter(Rank rank)
        {
            if (filters.acceptedRanks.Contains(rank))
                return;
            else
                filters.acceptedRanks.Add(rank);
        }

        private void AddAlignmentFilter(Ability_Alignment alignment)
        {
            if (filters.acceptedAlignment.Contains(alignment))
                return;
            else
                filters.acceptedAlignment.Add(alignment);
        }

        private void FilterTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e) => Close();

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (CheckBox checkBox in rankGroup.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = false;
            }
            foreach (CheckBox checkBox1 in alignmentGroup.Controls.OfType<CheckBox>())
            {
                checkBox1.Checked = false;
            }
            foreach (CheckBox checkBox2 in schoolsGroup.Controls.OfType<CheckBox>())
            {
                checkBox2.Checked = false;
            }

            filters.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(CheckBox checkBox in rankGroup.Controls.OfType<CheckBox>())
            {
                checkBox.Checked = true;
            }
            foreach (CheckBox checkBox1 in alignmentGroup.Controls.OfType<CheckBox>())
            {
                checkBox1.Checked = true;
            }
            foreach (CheckBox checkBox2 in schoolsGroup.Controls.OfType<CheckBox>())
            {
                checkBox2.Checked = true;
            }

            filters.Fill();
        }

        private void FilterTab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
