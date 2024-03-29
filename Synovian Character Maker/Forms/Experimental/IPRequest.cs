﻿using System;
using System.Windows.Forms;

using Synovian_Character_Maker.Networking;

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
            textBox1.Text = TCPManager.GetLocalIPAddress();
        }
    }
}
