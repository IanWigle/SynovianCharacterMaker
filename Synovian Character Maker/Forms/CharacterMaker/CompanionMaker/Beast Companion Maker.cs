using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    public partial class Beast_Companion_Maker : Form
    {
        private Data_Classes.CompanionSheet companionSheet = null;

        public Beast_Companion_Maker()
        {
            InitializeComponent();

            companionSheet = Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet;

            compNameBox.Text = companionSheet.companionName;
            compSpeciesBox.Text = companionSheet.companionSpecies;
            compHistoryBox.Text = companionSheet.companionHistory;

            if (companionSheet._image != null)
                companionPicture.Image = companionSheet._image;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            loadPicture.Title = "Open Image";
            loadPicture.DefaultExt = ".jpg";
            loadPicture.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|gif files (*.gif)|*.gif|ico images (*.ico)|*.ico|png images (*.png)|*.png|wdp images (*.wdp)|*.wdp|tiff images (*.tiff)|*.tiff|All files (*.*)|*.*";
            loadPicture.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete your companion?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet = null;
                Close();
            }
            else
                return;
        }

        private void loadPicture_FileOk(object sender, CancelEventArgs e)
        {
            companionPicture.Image = Image.FromFile(loadPicture.FileName);
        }

        private void Beast_Companion_Maker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(companionPicture.Image != null)
            {
                Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet._image = companionPicture.Image;
            }
            Static_Classes.Helpers.GetForm<CharacterMaker>().current_characterSheet.companionSheet.SetCompanionHistory(compHistoryBox.Text);
        }
    }
}
