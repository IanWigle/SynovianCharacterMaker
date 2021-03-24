using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    public partial class CalculatorLog : Form
    {
        public CalculatorLog()
        {
            InitializeComponent();
        }

        public void AddToLog(string message)
        {
            logBox.Text += $"{message}\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CalculatorLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
