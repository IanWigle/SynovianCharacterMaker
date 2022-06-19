using System;
using System.Windows.Forms;
using Synovian_Character_Maker.DataClasses;
using Synovian_Character_Maker.DataClasses.Instanced;

namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    public partial class GeneralInfoWindow : Form
    {
        public Rank rank = Rank.Invalid;
        public Ability_Alignment alignment = Ability_Alignment.Ability_Invalid;
        public string name = "";
        public bool dataIsValid = false;
        public bool saveImmediatly = false;

        public GeneralInfoWindow() => InitializeComponent();

        private void CalculateReadiness()
        {
            int progress = 0;

            if (rank > Rank.Invalid && rank < Rank.Max) progress++;
            if (alignment > Ability_Alignment.Ability_Invalid && alignment < Ability_Alignment.Ability_Max) progress++;
            if (name != "") progress++;

            characterProgress.Value = progress;

            if(progress == 3)
            {
                makeCharButton.Enabled = true;
            }
            else
            {
                makeCharButton.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rank = (Rank)(comboBox1.SelectedIndex + 1);
            CalculateReadiness();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            alignment = (Ability_Alignment)(comboBox2.SelectedIndex + 1);
            CalculateReadiness();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
            CalculateReadiness();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape || e.KeyCode == Keys.Tab)
            {
                name = textBox1.Text;
                CalculateReadiness();
            }
        }

        private void makeCharButton_Click(object sender, EventArgs e)
        {
            dataIsValid = true;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //saveImmediatly = checkBox1.Checked;
        }

        private void GeneralInfoWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
