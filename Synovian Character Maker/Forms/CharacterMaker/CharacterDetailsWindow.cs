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
    public partial class CharacterDetailsWindow : Form
    {
        private bool loadedNewImage = false;
        
        public CharacterDetailsWindow()
        {
            InitializeComponent();

            bioTextBox.Text = Program.GetOpenedSheet().characterDescription;
            speciesTextBox.Text = Program.GetOpenedSheet().characterSpecies;
            if (Program.GetOpenedSheet()._image != null) characterImage.Image = Program.GetOpenedSheet()._image;
        }

        private void CharacterDetailsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.GetOpenedSheet().characterDescription = bioTextBox.Text;
            Program.GetOpenedSheet().characterSpecies = speciesTextBox.Text;
            Program.GetOpenedSheet()._image = characterImage.Image;
            if(loadedNewImage) Program.GetOpenedSheet().imageExtension = openImageDialog.FileName.Split('.')[1];
        }

        private void loadPictureButton_Click(object sender, EventArgs e)
        {
            openImageDialog.Title = "Open Image";
            openImageDialog.DefaultExt = ".jpg";
            openImageDialog.Filter = "jpg files (*.jpg)|*.jpg|bmp files (*.bmp)|*.bmp|gif files (*.gif)|*.gif|ico images (*.ico)|*.ico|png images (*.png)|*.png|wdp images (*.wdp)|*.wdp|tiff images (*.tiff)|*.tiff|All files (*.*)|*.*";
            openImageDialog.ShowDialog();
        }

        private void openImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            loadedNewImage = true;
            characterImage.Image = Image.FromFile(openImageDialog.FileName);
        }

        private void CharacterDetailsWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
