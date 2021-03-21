using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Synovian_Character_Maker.Static_Classes;
using Synovian_Character_Maker.Data_Classes;

namespace Synovian_Character_Maker.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Setup character list
            foreach(CharacterSheet characterSheet in Program.characterLibrary.characterSheets)
            {
                string[] subitems = { characterSheet.Name, characterSheet.s_alignment, characterSheet.s_rank, characterSheet.lastModified };
                ListViewItem listViewItem = new ListViewItem(subitems);
                characterView.Items.Add(listViewItem);
            }

            numericVolume.Maximum = 1;
            numericVolume.Value = Program.audioPlayer.volume;
            audioOnLoopCheckBox.Checked = Program.audioPlayer.onLoop;
            keepMenuOpenBox.Checked = Program.programSettings.HideMainMenu;
            zipsOverTxtBox.Checked = Program.programSettings.FocusOnZipsOverTxts;
            songNameLabel.Text = $"Song : {Program.audioPlayer.SongName()}";
        }

        private void exitButton_Click(object sender, EventArgs e) => Close();

        private void sheetFolButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Globals.CharacterFolder))
                Directory.CreateDirectory(Globals.CharacterFolder);
            Process.Start("explorer.exe", @Globals.CharacterFolder);
        }

        private void newCharButton_Click(object sender, EventArgs e)
        {
            CharacterMaker.GeneralInfoWindow generalInfoWindow = new CharacterMaker.GeneralInfoWindow();
            generalInfoWindow.ShowDialog();
            if(generalInfoWindow.dataIsValid)
            {
                if (Program.characterLibrary.HasCharacter(generalInfoWindow.name))
                {
                    //MessageBox.Show($"A sheet with the name {generalInfoWindow.name} alreadt exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var result = MessageBox.Show($"A sheet with the name {generalInfoWindow.name} already exists! Make a copy?",
                                                 "Error!",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        if (generalInfoWindow.name.Split('_').Count() > 1)
                        {
                            int newIndex = int.Parse(generalInfoWindow.name.Split('_')[1]);
                            newIndex++;
                            generalInfoWindow.name = $"{generalInfoWindow.name.Split('_')[0]}_{newIndex}";
                        }
                        else
                        {
                            generalInfoWindow.name = $"{generalInfoWindow.name}_1";
                        }
                    }
                    else
                        return;
                }

                CharacterSheet characterSheet = new CharacterSheet(generalInfoWindow.name,
                                                                   generalInfoWindow.rank,
                                                                   generalInfoWindow.alignment);

                Program.characterLibrary.AddCharacter(characterSheet, generalInfoWindow.saveImmediatly);

                if (Helpers.TryGetForm("CharacterMaker", out Form form))
                {
                    form.Visible = true;
                    (form as CharacterMaker.CharacterMaker).UseDifferentCharacter(characterSheet);
                }
                else
                {
                    CharacterMaker.CharacterMaker characterMaker = new CharacterMaker.CharacterMaker(characterSheet);
                    characterMaker.Show();
                }

                Visible = Program.programSettings.HideMainMenu;
            }    
        }

        private void loadCharButton_Click(object sender, EventArgs e)
        {
            openCharacter.InitialDirectory = $"{Globals.CharacterFolder}";
            openCharacter.Title = "Load Character";
            openCharacter.DefaultExt = ".txt";
            openCharacter.Filter = "txt files (*.txt)|*.txt|zip folder (*.zip)|*.zip|ExcelX Sheet (*.xlsx)|*.xlsx|Excel Sheet (*.xls)|*.xls|All files (*.*)|*.*";
            openCharacter.ShowDialog();
        }

        private void characterView_DoubleClick(object sender, EventArgs e)
        {
            if(Program.characterLibrary.TryGetCharacter(characterView.FocusedItem.Text,out CharacterSheet characterSheet))
            {
                if(Helpers.TryGetForm("CharacterMaker", out Form form))
                {
                    form.Visible = true;
                    (form as CharacterMaker.CharacterMaker).UseDifferentCharacter(characterSheet);
                }
                else
                {
                    CharacterMaker.CharacterMaker characterMaker = new CharacterMaker.CharacterMaker(characterSheet);
                    characterMaker.Show();
                }
            }

            Visible = Program.programSettings.HideMainMenu;
        }

        private void audioOnLoopCheckBox_CheckedChanged(object sender, EventArgs e) => Program.audioPlayer.onLoop = audioOnLoopCheckBox.Checked;

        private void custonSongButton_Click(object sender, EventArgs e)
        {
            openSongFile.Filter = "WAV (*.wav)|*.wav|MP3 (*.mp3)|*.mp3|All Files (*.*)|*.*";
            openSongFile.InitialDirectory = $"{Globals.DataFolder}\\Audio";
            openSongFile.Title = "Find new song . . .";
            openSongFile.ShowDialog();
        }

        private void openSongFile_FileOk(object sender, CancelEventArgs e)
        {
            Program.audioPlayer.ChangeSong(openSongFile.FileName);
            numericVolume.Value = (decimal)Program.audioPlayer.volume;
            songNameLabel.Text = $"Song : {Program.audioPlayer.SongName()}";
        }

        private void numericVolume_ValueChanged(object sender, EventArgs e)
        {
            if (!Program.audioPlayer.IsValid()) return;
            //Program.audioPlayer.SetVolume(((float)numericVolume.Value > 1) ? 1.0f : (float)numericVolume.Value);
            Program.audioPlayer.volume = numericVolume.Value;
            Program.programSettings.AudioVolume = numericVolume.Value;
        }

        private void numericVolume_Click(object sender, EventArgs e)
        {
            numericVolume.Value = (numericVolume.Value > (decimal)1.0) ? (decimal)1.0 : numericVolume.Value;
        }

        private void keepMenuOpenBox_CheckedChanged(object sender, EventArgs e) => Program.programSettings.HideMainMenu = keepMenuOpenBox.Checked;

        private void zipsOverTxtBox_CheckedChanged(object sender, EventArgs e) => Program.programSettings.FocusOnZipsOverTxts = zipsOverTxtBox.Checked;

        private void openCharacter_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
