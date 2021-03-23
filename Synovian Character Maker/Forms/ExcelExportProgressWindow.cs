using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synovian_Character_Maker.Forms
{
    public partial class ExcelExportProgressWindow : Form
    {
        bool closingFromCode = false;

        public ExcelExportProgressWindow()
        {
            InitializeComponent();
        }

        public void ProgressTheBar(string message, int incrementAmount = 1)
        {
            if (incrementAmount == 1)
                progressBar1.PerformStep();
            else
                progressBar1.Value += incrementAmount;

            logLabel.Text = message;
        }

        public void CloseForm()
        {
            closingFromCode = true;
            Close();
        }

        private void ExcelExportProgressWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !closingFromCode;
        }
    }
}
