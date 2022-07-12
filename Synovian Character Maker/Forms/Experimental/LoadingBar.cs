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
    public partial class LoadingBar : Form
    {
        public LoadingBar()
        {
            InitializeComponent();
        }

        public void UpdateMaxValue(int max)
        {
            downloadBar.Maximum = max;
        }

        public void AddTickToProgress(int amount = 1)
        {
            downloadBar.Value += amount;
        }
    }
}
