using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Synovian_Character_Maker.Data_Classes;

namespace Synovian_Character_Maker.Forms
{
    public partial class AbilityMaker : Form
    {
        Ability_Alignment ability_Alignment = Ability_Alignment.Ability_Invalid;
        Rank rank = Rank.Invalid;
        Ability_Schools ability_School = Ability_Schools.Ability_Invalid;
        List<int> prereqs = new List<int>();

        public AbilityMaker()
        {
            InitializeComponent();
            RefreshList();
        }

        public void RefreshList()
        {
            listView1.Items.Clear();

            foreach(Ability ability in Program.abilityLibrary.GetAbilities())
            {
                string[] subitems = { ability.Name, ability.s_alignment, ability.s_rank, ability.s_ability_School, ability.isFeat.ToString(),ability.ID.ToString() };
                ListViewItem listViewItem = new ListViewItem(subitems);
                listView1.Items.Add(listViewItem);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) => ability_Alignment = (Ability_Alignment)(comboBox1.SelectedIndex + 1);

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) => rank = (Rank)(comboBox2.SelectedIndex + 1);

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) => ability_School = (Ability_Schools)(comboBox3.SelectedIndex + 1);

        private void makeButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Ability Name") return;

            int newId = Program.abilityLibrary.newID;

            prereqs.Clear();

            foreach (string line in prereqBox.Lines)
            {
                if (line.Contains('-'))
                {
                    int startRange = int.Parse(line.Split('-')[0]);
                    int endRange = int.Parse(line.Split('-')[1]);
                    for (int i = startRange; i < endRange + 1; i++)
                    {
                        if(Program.abilityLibrary.Contains(i))
                            prereqs.Add(i);
                        else
                        {
                            MessageBox.Show($"Could not find the prereq {i}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (Regex.IsMatch(line, @"^\d+$"))
                {
                    if (Program.abilityLibrary.TryGetAbility(int.Parse(line), out Ability ability))
                    {
                        prereqs.Add(ability.ID);
                    }
                    else
                    {
                        MessageBox.Show($"Could not find the prereq {line}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (Program.abilityLibrary.TryGetAbility(line, out Ability ability))
                    {
                        prereqs.Add(ability.ID);
                    }
                    else
                    {
                        MessageBox.Show($"Could not find the prereq {line}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            Ability ability1 = new Ability(
                                        textBox1.Text,
                                        richTextBox1.Text,
                                        newId,
                                        ability_Alignment,
                                        rank,
                                        ability_School,
                                        prereqs,
                                        int.Parse(textBox2.Text),
                                        checkBox1.Checked);

            if (Program.abilityLibrary.Contains(textBox1.Text))
            {
                MessageBox.Show($"The ability \"{textBox1.Text}\" already exists!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Program.abilityLibrary.AddNewAbility(ability1))
            {
                RefreshList();
                prereqBox.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listView1.FocusedItem == null)
            {
                MessageBox.Show("Select a ability", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Program.abilityLibrary.TryRemoveAbility(listView1.FocusedItem.Text);

            listView1.Items.Remove(listView1.FocusedItem);
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (!Regex.IsMatch(textBox2.Text, @"^\d+$"))
                    textBox2.Text = "1";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox2.Text, @"^\d+$"))
                textBox2.Text = "1";
            
        }

        private void AbilityMaker_FormClosing(object sender, FormClosingEventArgs e) => Static_Classes.DataWriter.WriteAbilitiesToDisk(Program.abilityLibrary.GetAbilities());

        private void listView1_Click(object sender, EventArgs e)
        {
            if(Program.abilityLibrary.TryGetAbility(listView1.FocusedItem.Text, out Ability ability))
            {
                comboBox1.SelectedIndex = (int)ability.alignment -1 ;

                comboBox2.SelectedIndex = (int)ability.Rank-1;

                comboBox3.SelectedIndex = (int)ability.ability_School-1;

                textBox1.Text = ability.Name;

                richTextBox1.Text = ability.description;

                checkBox1.Checked = ability.isFeat;

                textBox2.Text = ability.s_skillCostOverride;

                prereqBox.Text = "";

                List<string> vs = new List<string>();
                foreach (int i in ability.prereqs)
                    vs.Add(i.ToString());

                prereqBox.Lines = vs.ToArray();                
            }
            else
            {
                prereqBox.Lines = new string[] { };
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            // Note: Regardless of method, this will have the program no longer protected by Visual Studio enviroment.
            Application.Restart();
            //Environment.Exit(1);
            //Application.Exit();
            //System.Diagnostics.Process.Start(Application.ExecutablePath);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            //Program.abilityLibrary.ClearList();

            //static_Classes.DataReader.ReadAbilities(ref Program.abilityLibrary);

            //RefreshList();
        }
    }
}