using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Synovian_Character_Maker.Static_Classes;
using Synovian_Character_Maker.DataClasses.Static;
using Synovian_Character_Maker.DataClasses.Instanced;
using Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker;

namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    public partial class CharacterMaker : Form
    {
        public CharacterSheet current_characterSheet;
        FilterTab filterTab = new FilterTab();

        public CharacterMaker(CharacterSheet characterSheet)
        {
            InitializeComponent();
            current_characterSheet = characterSheet;
            UpdateLabels();
            Filters filters = new Filters(false,
                                        new List<Rank>(),
                                        new List<Ability_Alignment>(),
                                        new List<Ability_Schools>());
            filters.Fill();
            serverSubmissionButton.Enabled = Program.programArgs.Contains("-TCN");
            FilterLibraryAbilities(filters);
            FilterCharacterAbilities(filters);
        }

        public void UseDifferentCharacter(CharacterSheet characterSheet, bool saveCurrentOne = true)
        {
            if(saveCurrentOne)
            {
                DataWriter.WriteCharacterToDiskTxt(current_characterSheet);
            }

            current_characterSheet = characterSheet;
            WriteLog($"Set {characterSheet.Name} as the character to edit.");
        }

        private void UpdateLabels()
        {
            nameLabel.Text = "Name : "; 
            nameLabel.Text += $"{current_characterSheet.Name}";
            alignmentLabel.Text = "Alignment : ";
            alignmentLabel.Text += $"{current_characterSheet.s_alignment}";
            rankLabel.Text = "Rank : ";
            rankLabel.Text += $"{current_characterSheet.s_rank}";
            WriteLog("Updated all labels");
        }

        public void WriteLog(string message)
        {
            string text = logTextBox.Text;
            text += $"{DateTime.Now.TimeOfDay.Hours}:{DateTime.Now.TimeOfDay.Minutes} : {message}\n";
            logTextBox.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteLog("Updated filters");
            filterTab.ShowDialog();
            FilterLibraryAbilities(filterTab.filters);
            FilterCharacterAbilities(filterTab.filters);
        }

        private void FilterLibraryAbilities(Filters filters, List<Ability> abilities = null)
        {
            libraryView.Items.Clear();

            if (abilities == null) abilities = Program.abilityLibrary.GetAbilities();

            foreach (Ability ability in abilities)
            {
                if(filters.acceptedAlignment.Count > 0)
                    if (!filters.ContainsAlignment(ability.alignment)) continue;
                if (filters.acceptedRanks.Count > 0)
                    if (!filters.ContainsRank(ability.Rank)) continue;
                if (filters.acceptedSchools.Count > 0)
                    if (!filters.ContainsSchool(ability.ability_School)) continue;
                if (current_characterSheet.abilities.Contains(ability.ID)) continue;
                if (ability.ability_School == Ability_Schools.Ability_Droids) continue;

                string[] subitems = { ability.Name, ability.s_rank, ability.s_alignment, ability.s_ability_School };
                libraryView.Items.Add(new ListViewItem(subitems));
            }
            WriteLog("Updated library list.");
        }

        private void FilterCharacterAbilities(Filters filters, List<int> abilities = null)
        {
            characterAbilitiesView.Items.Clear();

            if (abilities == null) abilities = current_characterSheet.abilities;

            foreach (int abilityID in abilities)
            {
                if(Program.abilityLibrary.TryGetAbility(abilityID, out Ability ability))
                {
                    if (filters.acceptedAlignment.Count > 0)
                        if (!filters.ContainsAlignment(ability.alignment)) continue;
                    if (filters.acceptedRanks.Count > 0)
                        if (!filters.ContainsRank(ability.Rank)) continue;
                    if (filters.acceptedSchools.Count > 0)
                        if (!filters.ContainsSchool(ability.ability_School)) continue;

                    string[] subitems = { ability.Name, ability.s_rank, ability.s_alignment, ability.s_ability_School };
                    characterAbilitiesView.Items.Add(new ListViewItem(subitems));
                }
            }
            WriteLog("Updated character list");
        }

        private void CharacterMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Helpers.TryGetForm(typeof(MainForm), out Form form))
            {
                form.Visible = true;
                form.Focus();
            }
        }

        private void libraryView_Click(object sender, EventArgs e)
        {
            if(Program.abilityLibrary.TryGetAbility(libraryView.FocusedItem.Text, out Ability ability))
            {
                abilityDescriptionBox.Text = ability.description;
            }
        }

        private void libraryView_DoubleClick(object sender, EventArgs e)
        {
            if(Program.abilityLibrary.TryGetAbility(libraryView.FocusedItem.Text, out Ability ability))
            {
                current_characterSheet.AddAbility(ability.ID);
                current_characterSheet.abilityMasteryDictionary[ability.ID] = Ability_Mastery.Mastery_Learned;
                FilterLibraryAbilities(filterTab.filters);
                FilterCharacterAbilities(filterTab.filters);
            }
            WriteLog($"Added {ability.Name} to character");
        }

        private void saveTxtButton_Click(object sender, EventArgs e)
        {
            if (current_characterSheet._image != null)
            {
                if (MessageBox.Show("Your character has a image. The image won't be saved into the text file. Are you sure you want to do this?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (DataReader.IsSheetInDefaultDir(current_characterSheet.Name))
            {
                DataWriter.WriteCharacterToDiskTxt(current_characterSheet);
            }
            else
            {
                saveTxt.FileName = current_characterSheet.Name;
                saveTxt.Title = "Save Txt As...";
                saveTxt.DefaultExt = ".txt";
                saveTxt.InitialDirectory = Globals.CharacterFolder;
                saveTxt.ShowDialog();
            }
        }

        private void saveTxt_FileOk(object sender, CancelEventArgs e)
        {
            DataWriter.WriteCharacterToDiskTxt(current_characterSheet);
            WriteLog("Saved Character to disk as txt.");
        }

        private void loadTxtButton_Click(object sender, EventArgs e)
        {
            openCharacterDialog.Title = "Open Txt";
            openCharacterDialog.InitialDirectory = Globals.CharacterFolder;
            openCharacterDialog.DefaultExt = ".txt";
            openCharacterDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openCharacterDialog.ShowDialog();
        }

        private void openTxt_FileOk(object sender, CancelEventArgs e)
        {
            if (Program.characterLibrary.TryGetCharacter(openCharacterDialog.SafeFileName.Split('.')[0], out CharacterSheet sheet))
            {
                current_characterSheet = sheet;
            }    
            else
            {
                string extension = openCharacterDialog.SafeFileName.Split('.')[1];

                if (extension == "txt")
                {
                    current_characterSheet = DataReader.ReadSheetFromTxtDisk(openCharacterDialog.SafeFileName);
                }
                else if (extension == "zip")
                {
                    current_characterSheet = DataReader.ReadSheetFromZipDisk(openCharacterDialog.FileName);
                }
                else if (extension == "xls" || extension == "xlsx")
                {
                    current_characterSheet = Program.excelManager.ImportSheet(openCharacterDialog.FileName);
                }
                else
                {
#if DEBUG
                    throw new Exception($"{extension} is not a valid extension to use");
#else
                    MessageBox.Show($"{extension} is not a valid extension to use", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                }
            }

            UpdateLabels();
            Filters filters = new Filters(false,
                                          new List<Rank>(),
                                          new List<Ability_Alignment>(),
                                          new List<Ability_Schools>());
            filters.Fill();
            FilterLibraryAbilities(filters);
            FilterCharacterAbilities(filters);
            WriteLog("Opened new character");
        }

        private void saveZipButton_Click(object sender, EventArgs e)
        {
            saveZip.Title = "Save Zip As...";
            saveZip.FileName = current_characterSheet.Name;
            saveZip.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            saveZip.InitialDirectory = Globals.CharacterFolder;
            saveZip.ShowDialog();
        }

        private void saveZip_FileOk(object sender, CancelEventArgs e)
        {
            return;
            //ZipExportOptions zipExportOptions = new ZipExportOptions();
            //zipExportOptions.ShowDialog();
            //if (zipExportOptions.exitStatus == ZipExportOptions.ExitStatus.Failed)
            //    return;
            //
            //DataWriter.WriteCharacterToDiskZip(current_characterSheet, saveZip.FileName, zipExportOptions.exportSettings);
            //WriteLog("Saved character as zip to disk.");
        }

        private void companionButton_Click(object sender, EventArgs e)
        {
            CompanionMenu companionMenu = new CompanionMenu();
            companionMenu.ShowDialog();
        }

        private void characterAbilitiesView_Click(object sender, EventArgs e)
        {
            if (Program.abilityLibrary.TryGetAbility(characterAbilitiesView.FocusedItem.Text, out Ability ability))
            {
                abilityDescriptionBox.Text = ability.description;

                masteryComboBox.SelectedIndex = (int)current_characterSheet.abilityMasteryDictionary[ability.ID];
            }
        }

        private void characterAbilitiesView_DoubleClick(object sender, EventArgs e)
        {
            if (Program.abilityLibrary.TryGetAbility(characterAbilitiesView.FocusedItem.Text, out Ability ability))
            {
                current_characterSheet.RemoveAbility(ability.ID);
                current_characterSheet.abilityMasteryDictionary.Remove(ability.ID);
                FilterLibraryAbilities(filterTab.filters);
                FilterCharacterAbilities(filterTab.filters);
            }
            WriteLog($"Removed {ability.Name} from character.");
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            CalculatorLog calculatorLog = new CalculatorLog();
            string log = "";
            int errors = 0;
            bool success = Program.calculator.Calculate(ref current_characterSheet, ref log, ref errors);
            calculatorLog.AddToLog(log);
            calculatorLog.AddToLog($"Results are in: your sheet is {((success == true) ? "valid" : "invalid")}.");
            calculatorLog.AddToLog($"Number of errors: {errors}");
            calculatorLog.ShowDialog();
            WriteLog("Did big brain math.");
        }

        private void saveExcelButton_Click(object sender, EventArgs e)
        {
            saveExcel.FileName = current_characterSheet.Name;
            saveExcel.Title = "Export sheet . . .";
            saveExcel.Filter = "XLSX (*.xlsx)|*.xlsx|XLS (*.xls)|*.xls|All Files (*.*)|*.*";
            saveExcel.InitialDirectory = Globals.CharacterFolder;
            saveExcel.ShowDialog();
        }

        private void saveExcel_FileOk(object sender, CancelEventArgs e)
        {
            //DataWriter.ExportCharacterSheetExcel(current_characterSheet, saveExcel.FileName, (saveExcel.FileName.Split('.')[1] == "xlsx") ? DataWriter.ExcelFormats.XLSX : DataWriter.ExcelFormats.XLS);
            WriteLog("Saved character to disk as excel");
        }

        private void characterDetailsButton_Click(object sender, EventArgs e)
        {
            CharacterDetailsWindow characterDetailsWindow = new CharacterDetailsWindow();
            characterDetailsWindow.ShowDialog();
        }

        private void clearSheetButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to clear your sheet?","Notice!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                current_characterSheet.Empty();
                characterAbilitiesView.Items.Clear();
                FilterLibraryAbilities(filterTab.filters);
                FilterCharacterAbilities(filterTab.filters);
                WriteLog("Emptied character.");
            }
        }

        private void loadZipButton_Click(object sender, EventArgs e)
        {
            openCharacterDialog.Title = "Open Zip";
            openCharacterDialog.InitialDirectory = Globals.CharacterFolder;
            openCharacterDialog.DefaultExt = ".zip";
            openCharacterDialog.Filter = "Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            openCharacterDialog.ShowDialog();
        }

        private void loadExcelButton_Click(object sender, EventArgs e)
        {
            openCharacterDialog.Title = "Open Excel";
            openCharacterDialog.InitialDirectory = Globals.CharacterFolder;
            openCharacterDialog.DefaultExt = ".xlsx";
            openCharacterDialog.Filter = "Xlsx files (*.xslx)|*.xlsx|Xls files (*.xls)|*.xls|All files (*.*)|*.*";
            openCharacterDialog.ShowDialog();
        }

        private void serverSubmissionButton_Click(object sender, EventArgs e)
        {
            if(Program.programArgs.Contains("-TCN"))
            {
                Networking.TCPManager tCP = new Networking.TCPManager(false, true);
                Experimental.SheetSubmission sheetSubmission = new Experimental.SheetSubmission();
                tCP.SendSheet(current_characterSheet);
            }
        }

        private void googleDriveButton_Click(object sender, EventArgs e)
        {
            SheetExportSettingsForm sheetExportSettings = new SheetExportSettingsForm();
            sheetExportSettings.ShowDialog();
            if (!sheetExportSettings.finishedSetup) return;
            SheetExportSettings sheetExport = sheetExportSettings.sheetExportSettings;

            if (!Directory.Exists(Globals.TempFolder)) Directory.CreateDirectory(Globals.TempFolder);


            // Create the file
            //DataWriter.ExportCharacterSheetExcel(current_characterSheet, $"{Globals.TempFolder}\\{current_characterSheet.Name}.xlsx", sheetExport, DataWriter.ExcelFormats.XLSX);
            Program.excelManager.ExportSheet(current_characterSheet, $"{Globals.TempFolder}\\{current_characterSheet.Name}.xlsx", sheetExport);

            // Send file to google drive
            Networking.GoogleDriveManager.SubmitSheetToDrive($"{Globals.TempFolder}\\{current_characterSheet.Name}.xlsx");

            // Delete the file, we don't need it on disk
            File.Delete($"{Globals.TempFolder}\\{current_characterSheet.Name}.xlsx");


            WriteLog("Sent sheet to google drive.");
        }

        private void libraryView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            List<Ability> abilities = new List<Ability>();
            switch (e.Column)
            {
                // Name
                case 0:
                    {
                        var rawAbilities = Program.abilityLibrary.GetAbilities();
                        List<string> abilityNames = new List<string>();

                        foreach(Ability ability in rawAbilities)
                        {
                            abilityNames.Add(ability.Name);
                        }

                        abilityNames.Sort();

                        foreach(string abilityName in abilityNames)
                        {
                            abilities.Add(Program.abilityLibrary.GetAbility(abilityName)); 
                        }

                        break;
                    }
                // Rank
                case 1:
                    {
                        foreach(Rank rank in Enum.GetValues(typeof(Rank)))
                        {
                            if (rank == Rank.Invalid || rank >= Rank.Emperor)
                                continue;
                            foreach(Ability ability in Program.abilityLibrary.GetAbilities())
                            {
                                if (abilities.Contains(ability))
                                    continue;
                                if(ability.Rank == rank)
                                    abilities.Add(ability);
                            }
                        }
                        break;
                    }
                // Alignment
                case 2:
                    {
                        foreach (Ability_Alignment alignment in Enum.GetValues(typeof(Ability_Alignment)))
                        {
                            if (alignment == Ability_Alignment.Ability_Invalid || alignment == Ability_Alignment.Ability_Max)
                                continue;
                            foreach (Ability ability in Program.abilityLibrary.GetAbilities())
                            {
                                if (abilities.Contains(ability) || current_characterSheet.abilities.Contains(ability.ID))
                                    continue;
                                if (ability.alignment == alignment)
                                    abilities.Add(ability);
                            }
                        }
                        break;
                    }
                // School
                case 3:
                    {
                        foreach (Ability_Schools school in Enum.GetValues(typeof(Ability_Schools)))
                        {
                            if (school == Ability_Schools.Ability_Invalid || school == Ability_Schools.Ability_Max)
                                continue;
                            foreach (Ability ability in Program.abilityLibrary.GetAbilities())
                            {
                                if (abilities.Contains(ability) || current_characterSheet.abilities.Contains(ability.ID))
                                    continue;
                                if (ability.ability_School == school)
                                    abilities.Add(ability);
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
            FilterLibraryAbilities(filterTab.filters, abilities);
        }

        private void characterAbilitiesView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            List<Ability> abilities = new List<Ability>();
            var rawAbilitiesIDS = current_characterSheet.abilities;
            var rawAbilities = Program.abilityLibrary.GetAbilitiesContainingIDS(rawAbilitiesIDS.ToArray());
            List<string> abilityNames = new List<string>();
            switch (e.Column)
            {
                // Name
                case 0:
                    {
                        foreach (Ability ability in rawAbilities)
                        {
                            abilityNames.Add(ability.Name);
                        }

                        abilityNames.Sort();

                        foreach (string abilityName in abilityNames)
                        {
                            abilities.Add(Program.abilityLibrary.GetAbility(abilityName));
                        }

                        break;
                    }
                // Rank
                case 1:
                    {
                        foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                        {
                            if (rank == Rank.Invalid || rank >= Rank.Emperor)
                                continue;
                            foreach (Ability ability in rawAbilities)
                            {
                                if (abilities.Contains(ability))
                                    continue;
                                if (ability.Rank == rank)
                                    abilities.Add(ability);
                            }
                        }
                        break;
                    }
                // Alignment
                case 2:
                    {
                        foreach (Ability_Alignment alignment in Enum.GetValues(typeof(Ability_Alignment)))
                        {
                            if (alignment == Ability_Alignment.Ability_Invalid || alignment == Ability_Alignment.Ability_Max)
                                continue;
                            foreach (Ability ability in rawAbilities)
                            {
                                if (abilities.Contains(ability))
                                    continue;
                                if (ability.alignment == alignment)
                                    abilities.Add(ability);
                            }
                        }
                        break;
                    }
                // School
                case 3:
                    {
                        foreach (Ability_Schools school in Enum.GetValues(typeof(Ability_Schools)))
                        {
                            if (school == Ability_Schools.Ability_Invalid || school == Ability_Schools.Ability_Max)
                                continue;
                            foreach (Ability ability in rawAbilities)
                            {
                                if (abilities.Contains(ability))
                                    continue;
                                if (ability.ability_School == school)
                                    abilities.Add(ability);
                            }
                        }
                        break;
                    }
                default:
                    break;
            }

            var abilityIDs = new List<int>();
            foreach(Ability ability in abilities)
            {
                abilityIDs.Add(ability.ID);
            }
            FilterCharacterAbilities(filterTab.filters, abilityIDs);
        }

        private void masteryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.abilityLibrary.TryGetAbility(characterAbilitiesView.FocusedItem.Text, out Ability ability))
            {
                current_characterSheet.abilityMasteryDictionary[ability.ID] = (Ability_Mastery)masteryComboBox.SelectedIndex;
            }
        }
    }
}
