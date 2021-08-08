using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Synovian_Character_Maker.Static_Classes.Networking.GoogleDrive;

namespace Synovian_Character_Maker.Forms.Google
{
    public partial class Google_Sheets : Form
    {
        private int startingValue = 10;
        private List<GoogleDriveManager.FileSearch> savedSearches = null;

        public Data_Classes.CharacterSheet sheet = null;

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
                    selectedID = fileSearch.Id;
            }

            try
            {
                GoogleDriveManager.DownloadSheet(selectedID, listView1.FocusedItem.Text);
                sheet = Static_Classes.ExcelManager.ImportSheet($"{Static_Classes.Globals.GoogleDownloads}\\{listView1.FocusedItem.Text}.xlsx");
                sheet.setFileType(Data_Classes.CharacterSheet.SheetFileType.Xlsx_Google);
                System.IO.File.Delete($"{Static_Classes.Globals.GoogleDownloads}\\{listView1.FocusedItem.Text}.xlsx");
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
