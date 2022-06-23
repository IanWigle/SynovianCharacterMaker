using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Synovian_Character_Maker.Networking;
using Synovian_Character_Maker.DataClasses.Instanced;
using Synovian_Character_Maker.DataClasses.Static;

namespace Synovian_Character_Maker.Forms.Google
{
    public partial class Google_Sheets : Form
    {
        private int startingValue = 10;
        private List<GoogleDriveManager.FileSearch> savedSearches = null;

        public CharacterSheet sheet = null;

        public Google_Sheets()
        {
            InitializeComponent();

            numericMaxSearch.Value = startingValue;

            Search();
        }

        void Search()
        {
            savedSearches = 
                GoogleDriveManager.SearchFiles(int.Parse(numericMaxSearch.Value.ToString()));

            listView1.Items.Clear();

            foreach(GoogleDriveManager.FileSearch fileSearch in savedSearches)
            {
                listView1.Items.Add(fileSearch.Name);
            }
        }

        private void numericMaxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void refreshButton_Click(object sender, EventArgs e) => Search();

        private void loadButton_Click(object sender, EventArgs e)
        {
            Download();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Download();
        }

        private void Download()
        {
            string selectedID = "";
            foreach (GoogleDriveManager.FileSearch fileSearch in savedSearches)
            {
                if (listView1.FocusedItem.Text == fileSearch.Name)
                {
                    selectedID = fileSearch.Id;
                    break;
                }
            }

            try
            {
                GoogleDriveManager.DownloadSheet(selectedID, listView1.FocusedItem.Text);
                sheet = Program.excelManager.ImportSheet($"{Globals.GoogleDownloads}\\{listView1.FocusedItem.Text}");

                DialogResult result = MessageBox.Show("Would you like to keep this sheet on disk?", "Download Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                switch(result)
                {
                    case DialogResult.Yes:
                        {
                            sheet.setFileType(CharacterSheet.SheetFileType.XlSx);
                            break;
                        }
                    case DialogResult.No:
                        {
                            sheet.setFileType(CharacterSheet.SheetFileType.Xlsx_Google);
                            System.IO.File.Delete($"{Globals.GoogleDownloads}\\{listView1.FocusedItem.Text}.xlsx");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Static_Classes.Helpers.ExceptionHandle(ex);
            }

            Close();
        }

        private void deleteCharacter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to delete this character from your drive?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            string selectedID = "";
            foreach (GoogleDriveManager.FileSearch fileSearch in savedSearches)
            {
                if (listView1.FocusedItem.Text == fileSearch.Name)
                    selectedID = fileSearch.Id;
            }

            GoogleDriveManager.DeleteSheet(selectedID);
            Search();
        }
    }
}
