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
                    if (Program.programSettings.HideMainMenu)
                    {
                        Visible = false;
                    }
                }
                else
                {
                    CharacterMaker.CharacterMaker characterMaker = new CharacterMaker.CharacterMaker(characterSheet);
                    characterMaker.Show();
                    if (Program.programSettings.HideMainMenu)
                    {
                        Visible = false;
                    }
                }
            }    
        }

        private void loadCharButton_Click(object sender, EventArgs e)
        {
            
        }

        private void characterView_DoubleClick(object sender, EventArgs e)
        {
            if(Program.characterLibrary.TryGetCharacter(characterView.FocusedItem.Text,out CharacterSheet characterSheet))
            {
                if(Helpers.TryGetForm("CharacterMaker", out Form form))
                {
                    form.Visible = true;
                    (form as CharacterMaker.CharacterMaker).UseDifferentCharacter(characterSheet);
                    goto HandleClosingForm;
                }
                else
                {
                    CharacterMaker.CharacterMaker characterMaker = new CharacterMaker.CharacterMaker(characterSheet);
                    characterMaker.Show();
                    goto HandleClosingForm;
                }
            }
            
            HandleClosingForm:
            {
                if(Program.programSettings.HideMainMenu)
                {
                    Visible = false;
                }
            }
        }

        private void audioOnLoopCheckBox_CheckedChanged(object sender, EventArgs e) => Program.audioPlayer.onLoop = audioOnLoopCheckBox.Checked;

        private void custonSongButton_Click(object sender, EventArgs e)
        {
            openSongFile.Filter = "WAV (*.wav)|*.wav|MP3 (*.mp3)|*.mp3|All Files (*.*)|*.*";
            openSongFile.Title = "Find new song . . .";
            openSongFile.ShowDialog();
        }

        private void openSongFile_FileOk(object sender, CancelEventArgs e)
        {
            Program.audioPlayer.ChangeSong(openSongFile.FileName);
            numericVolume.Value = (decimal)Program.audioPlayer.Volume();
            songNameLabel.Text = $"Song : {Program.audioPlayer.SongName()}";
        }

        private void numericVolume_ValueChanged(object sender, EventArgs e)
        {
            if (!Program.audioPlayer.IsValid()) return;
            Program.audioPlayer.SetVolume(((float)numericVolume.Value > 1) ? 1.0f : (float)numericVolume.Value);
        }

        private void numericVolume_Click(object sender, EventArgs e)
        {
            numericVolume.Value = (numericVolume.Value > (decimal)1.0) ? (decimal)1.0 : numericVolume.Value;
        }
    }
}
