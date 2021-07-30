using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synovian_Character_Maker.Forms.Experimental
{
    public partial class SheetSubmission : Form
    {
        public SheetSubmission()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool overrideSubmission
        {
            get
            {
                return checkBox1.Checked;
            }
        }

        public string authorName
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void SheetSubmission_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (authorName == "")
            {
                DialogResult result = MessageBox.Show("You didn't provide a name! Are you sure you want to post anonymous?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);
                e.Cancel = (result == DialogResult.No);                
            }
        }
    }
}
