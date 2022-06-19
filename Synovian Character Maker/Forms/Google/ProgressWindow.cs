using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synovian_Character_Maker.Forms.Google
{
    public partial class ProgressWindow : Form
    {
        public enum ProgressType
        {
            Download = 0,
            Upload = 1
        }

        public ProgressWindow(ProgressType progressType)
        {
            InitializeComponent();

            switch (progressType)
            {
                case ProgressType.Download:
                    {
                        Text = "Downloading . . .";
                        break;
                    }
                case ProgressType.Upload:
                    {
                        Text = "Uploading . . .";
                        break;
                    }
            }
        }
    }
}
