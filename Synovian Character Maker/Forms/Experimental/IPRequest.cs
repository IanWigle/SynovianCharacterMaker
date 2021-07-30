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
    public partial class IPRequest : Form
    {
        public IPRequest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Close();
        }

        public string IP
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Static_Classes.Networking.TCP.GetLocalIPAddress();
        }
    }
}
