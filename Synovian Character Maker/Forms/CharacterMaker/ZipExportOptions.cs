using System;
using System.Windows.Forms;

using Synovian_Character_Maker.DataClasses.Instanced;

namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    public partial class ZipExportOptions : Form
    {
        public enum ExitStatus
        {
            Success,
            Failed
        }

        

        public ExitStatus exitStatus = ExitStatus.Failed;
        public ZipExportSettings exportSettings = new ZipExportSettings(false, false, false);

        public ZipExportOptions() => InitializeComponent();

        private void button1_Click(object sender, EventArgs e)
        {
            exitStatus = ExitStatus.Success;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => exportSettings.savePicture = checkBox1.Checked;

        private void checkBox2_CheckedChanged(object sender, EventArgs e) => exportSettings.saveExcel = checkBox2.Checked;

        private void checkBox3_CheckedChanged(object sender, EventArgs e) => exportSettings.saveCompExcelSeperate = checkBox3.Checked;
    }
}
