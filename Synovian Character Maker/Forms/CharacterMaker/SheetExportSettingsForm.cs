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

namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    public partial class SheetExportSettingsForm : Form
    {
        

        public SheetExportSettings sheetExportSettings;

        public bool finishedSetup = false;  

        public SheetExportSettingsForm()
        {
            sheetExportSettings = new SheetExportSettings(SheetExportSettings.SortType.None, false, "");

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            finishedSetup = true;
            Close();
        }

        private void SheetExportSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sheetExportSettings.sortType = (SheetExportSettings.SortType)comboBox1.SelectedIndex;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sheetExportSettings.seperateSheetsPerCompanion = checkBox1.Checked;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sheetExportSettings.sheetNameOverride = textBox1.Text;
        }
    }
}
