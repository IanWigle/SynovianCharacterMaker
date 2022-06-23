using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Synovian_Character_Maker.Static_Classes;
using Synovian_Character_Maker.Data_Classes;

namespace Synovian_Character_Maker.Forms
{
    public partial class MainForm : Form
    {
        Image defaultPreview = null;

        enum TutorialMode
        {
            Creation = 0,
            SaveLoad,
            Calculator,
            Filters,
            CompanionSetup,
            CompanionAbilities,
            MiscMusic,
            Google
        }

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

            if(Program.audioPlayer.IsValid())
            {
                numericVolume.Maximum = 1;
                numericVolume.Value = Program.audioPlayer.volume;
                audioOnLoopCheckBox.Checked = Program.audioPlayer.onLoop;
                keepMenuOpenBox.Checked = Program.programSettings.HideMainMenu;
                zipsOverTxtBox.Checked = Program.programSettings.FocusOnZipsOverTxts;
                songNameLabel.Text = $"Song : {Program.audioPlayer.SongName()}";
            }


            try
            {
                FAQBox.LoadFile($"{Globals.DataFolder}\\FAQ.rtf",RichTextBoxStreamType.RichText);

                defaultPreview = Image.FromFile(Globals.PreviewDefault);
            }
            catch(Exception e)
            {
                Helpers.ExceptionHandle(e);
            }

            ChangeActiveTutorial(TutorialMode.Creation);

            licenseBox.LoadFile($"{Globals.DataFolder}\\LICENSE", RichTextBoxStreamType.PlainText);
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

        private void numericVolume_Click(object sender, EventArgs e) => numericVolume.Value = (numericVolume.Value > (decimal)1.0) ? (decimal)1.0 : numericVolume.Value;

        private void keepMenuOpenBox_CheckedChanged(object sender, EventArgs e) => Program.programSettings.HideMainMenu = keepMenuOpenBox.Checked;

        private void zipsOverTxtBox_CheckedChanged(object sender, EventArgs e) => Program.programSettings.FocusOnZipsOverTxts = zipsOverTxtBox.Checked;

        private void openCharacter_FileOk(object sender, CancelEventArgs e)
        {
            string extension = openCharacter.FileName.Split('.').Last<string>();

            DataReader.DataReadTypes dataReadTypes = DataReader.DataReadTypes.max;

            foreach(DataReader.DataReadTypes dataRead in (DataReader.DataReadTypes[])Enum.GetValues(typeof(DataReader.DataReadTypes)))
            {
                if(Enum.GetName(typeof(DataReader.DataReadTypes),dataRead) == extension)
                {
                    dataReadTypes = dataRead;
                    break;
                }
            }

            CharacterSheet characterSheet = null;

            switch (dataReadTypes)
            {
                case DataReader.DataReadTypes.txt:
                    {
                        characterSheet = DataReader.ReadSheetFromTxtDisk(openCharacter.FileName);
                        break;
                    }
                case DataReader.DataReadTypes.zip:
                    {
                        characterSheet = DataReader.ReadSheetFromZipDisk(openCharacter.FileName);
                        break;
                    }
                case DataReader.DataReadTypes.xls:
                    {
                        characterSheet = ExcelManager.ImportSheet(openCharacter.FileName);
                        break;
                    }
                case DataReader.DataReadTypes.xlsx:
                    {
                        characterSheet = ExcelManager.ImportSheet(openCharacter.FileName);
                        break;
                    }
                default:
                    {
                        Helpers.ExceptionHandle("Was unable to get the get the correct file type of the selected file to load.");
                        return;
                    }
            }

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

        private void characterView_Click(object sender, EventArgs e)
        {
            string charName = characterView.FocusedItem.Text;

            if (Program.characterLibrary.TryGetCharacter(charName, out CharacterSheet characterSheet))
            {
                if (characterSheet._image != null)
                    previewBox.Image = characterSheet._image;
                else
                    previewBox.Image = defaultPreview;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void ChangeActiveTutorial(TutorialMode tutorialMode)
        {
            switch (tutorialMode)
            {
                case TutorialMode.Creation:
                    tutorialTextBox.LoadFile($"{Globals.DataFolder}\\Tutorials\\TutorialBasicCreation.rtf", RichTextBoxStreamType.RichText);
                    break;
                case TutorialMode.SaveLoad:
                    tutorialTextBox.LoadFile($"{Globals.DataFolder}\\Tutorials\\TutorialSaveLoad.rtf", RichTextBoxStreamType.RichText);
                    break;
                case TutorialMode.Calculator:
                    tutorialTextBox.LoadFile($"{Globals.DataFolder}\\Tutorials\\TutorialCalculator.rtf", RichTextBoxStreamType.RichText);
                    break;
                case TutorialMode.Filters:
                    tutorialTextBox.LoadFile($"{Globals.DataFolder}\\Tutorials\\TutorialFilters.rtf", RichTextBoxStreamType.RichText);
                    break;
                case TutorialMode.CompanionSetup:
                    tutorialTextBox.LoadFile($"{Globals.DataFolder}\\Tutorials\\TutorialCompanionSetup.rtf", RichTextBoxStreamType.RichText);
                    break;
                case TutorialMode.CompanionAbilities:
                    tutorialTextBox.LoadFile($"{Globals.DataFolder}\\Tutorials\\TutorialCompaionAbilities.rtf", RichTextBoxStreamType.RichText);
                    break;
                case TutorialMode.MiscMusic:
                    break;
                case TutorialMode.Google:
                    tutorialTextBox.LoadFile($"{Globals.DataFolder}\\Tutorials\\UsingGoogleDrive.rtf", RichTextBoxStreamType.RichText);
                    break;
                default:
                    return;
            }
        }

        private void makingYourCharacterToolStripMenuItem_Click(object sender, EventArgs e) => ChangeActiveTutorial(TutorialMode.Creation);

        private void savingYourCharacterToolStripMenuItem_Click(object sender, EventArgs e) => ChangeActiveTutorial(TutorialMode.SaveLoad);

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e) => ChangeActiveTutorial(TutorialMode.Calculator);

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e) => ChangeActiveTutorial(TutorialMode.Filters);

        private void settingUpToolStripMenuItem_Click(object sender, EventArgs e) => ChangeActiveTutorial(TutorialMode.CompanionSetup);

        private void abilitiesToolStripMenuItem_Click(object sender, EventArgs e) => ChangeActiveTutorial(TutorialMode.CompanionAbilities);

        private void musicToolStripMenuItem_Click(object sender, EventArgs e) => ChangeActiveTutorial(TutorialMode.MiscMusic);

        private void loadSheetFromGoogle_Click(object sender, EventArgs e)
        {
            Google.Google_Sheets google_Sheets = new Google.Google_Sheets();
            google_Sheets.ShowDialog();

            if (google_Sheets.sheet == null) return;

            CharacterSheet characterSheet = google_Sheets.sheet;
            Program.characterLibrary.AddCharacter(characterSheet);
            if (characterSheet != null)
            {
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

        private void googleToolStripMenuItem_Click(object sender, EventArgs e) => ChangeActiveTutorial(TutorialMode.Google);
    }
}
