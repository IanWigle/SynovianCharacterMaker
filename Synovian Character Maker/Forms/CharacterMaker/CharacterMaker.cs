using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Synovian_Character_Maker.Data_Classes;
using Synovian_Character_Maker.Static_Classes;

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
            text += $"{message}\n";
            logTextBox.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            filterTab.ShowDialog();
            FilterLibraryAbilities(filterTab.filters);
            FilterCharacterAbilities(filterTab.filters);
        }

        private void FilterLibraryAbilities(Filters filters)
        {
            libraryView.Items.Clear();

            foreach(Ability ability in Program.abilityLibrary.GetAbilities())
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
        }

        private void FilterCharacterAbilities(Filters filters)
        {
            characterAbilitiesView.Items.Clear();

            foreach(int abilityID in current_characterSheet.abilities)
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
        }

        private void CharacterMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach(Form form in fc)
            {
                if(form.GetType() == typeof(MainForm))
                {
                    form.Focus();
                }
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
                FilterLibraryAbilities(filterTab.filters);
                FilterCharacterAbilities(filterTab.filters);
            }
        }

        private void saveTxtButton_Click(object sender, EventArgs e)
        {
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
        }

        private void loadTxtButton_Click(object sender, EventArgs e)
        {
            openTxt.Title = "Open Txt";
            openTxt.InitialDirectory = Globals.CharacterFolder;
            openTxt.DefaultExt = ".txt";
            openTxt.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openTxt.ShowDialog();
        }

        private void openTxt_FileOk(object sender, CancelEventArgs e)
        {
            if (Program.characterLibrary.TryGetCharacter(openTxt.SafeFileName.Split('.')[0], out CharacterSheet sheet))
            {
                current_characterSheet = sheet;
            }    
            else
            {
                current_characterSheet = DataReader.ReadSheetFromTxtDisk(openTxt.SafeFileName);
            }

            UpdateLabels();
            Filters filters = new Filters(false,
                                          new List<Rank>(),
                                          new List<Ability_Alignment>(),
                                          new List<Ability_Schools>());
            filters.Fill();
            FilterLibraryAbilities(filters);
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
            ZipExportOptions zipExportOptions = new ZipExportOptions();
            zipExportOptions.ShowDialog();
            if (zipExportOptions.exitStatus == ZipExportOptions.ExitStatus.Failed)
                return;

            DataWriter.WriteCharacterToDiskZip(current_characterSheet, saveZip.FileName, zipExportOptions.exportSettings);
        }

        private void companionButton_Click(object sender, EventArgs e)
        {
            if (current_characterSheet.companionSheet == null)
            {
                CompanionMaker.CompanionSetup companionSetup = new CompanionMaker.CompanionSetup();
                companionSetup.ShowDialog();
            }
            else
            {
                CompanionMaker.CompanionMaker companionMaker = new CompanionMaker.CompanionMaker();
                companionMaker.ShowDialog();
            }
        }

        private void characterAbilitiesView_Click(object sender, EventArgs e)
        {
            if (Program.abilityLibrary.TryGetAbility(characterAbilitiesView.FocusedItem.Text, out Ability ability))
            {
                abilityDescriptionBox.Text = ability.description;
            }
        }

        private void characterAbilitiesView_DoubleClick(object sender, EventArgs e)
        {
            if (Program.abilityLibrary.TryGetAbility(characterAbilitiesView.FocusedItem.Text, out Ability ability))
            {
                current_characterSheet.RemoveAbility(ability.ID);
                FilterLibraryAbilities(filterTab.filters);
                FilterCharacterAbilities(filterTab.filters);
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // Get the rules for the specific rank setup for this character.
            int FeatPointMax = Program.statRules.FeatPoints[current_characterSheet.Rank];
            int SkillPointsMax = Program.statRules.SkillPoints[current_characterSheet.Rank];
            int SchoolsMax = Program.statRules.Schools[current_characterSheet.Rank];
            int MasteriesMax = Program.statRules.Masteries[current_characterSheet.Rank];

            CalculatorLog calculatorLog = new CalculatorLog();

            // Validation check value
            bool valid = true;

            int numErrors = 0;

            // Start by calculating all used skill points
            {
                int usedSkillPoints = 0;

                foreach(int int_ability in current_characterSheet.abilities)
                {
                    if (Program.abilityLibrary.TryGetAbility(int_ability, out Ability ability))
                    {
                        if (ability.isFeat)
                            continue;
                        else
                            usedSkillPoints += ability.skillCostOverride;
                    }
                }

                if (usedSkillPoints > SkillPointsMax)
                {
                    calculatorLog.AddToLog($"There are {usedSkillPoints - SkillPointsMax} more than the character's max of {SkillPointsMax}.");
                    valid = false;
                    numErrors++;
                }
            }
            // Calculate all feat points
            {
                int usedFeatPoints = 0;

                foreach(int int_ability in current_characterSheet.abilities)
                {
                    if (Program.abilityLibrary.TryGetAbility(int_ability, out Ability ability))
                    {
                        if (ability.isFeat)
                            usedFeatPoints += ability.skillCostOverride;
                        else
                            continue;
                    }
                }

                if (usedFeatPoints > FeatPointMax)
                {
                    calculatorLog.AddToLog($"There are {usedFeatPoints - FeatPointMax} more than the character's max of {FeatPointMax}.");
                    valid = false;
                    numErrors++;
                }
            }
            // Calculate if the sheet has right number of schools
            {
                int usedSchools = 0;
                List<Ability> schools = new List<Ability>();

                foreach(Ability_Schools ability_Schools in (Ability_Schools[])Enum.GetValues(typeof(Ability_Schools)))
                {
                    Ability abilitySchool = Program.abilityLibrary.GetSchool(ability_Schools);
                    if (abilitySchool != null) schools.Add(abilitySchool);
                }

                foreach(Ability abilitySchool in schools)
                {
                    if (abilitySchool.ability_School == Ability_Schools.Ability_Forms) continue;
                    if (current_characterSheet.abilities.Contains(abilitySchool.ID))
                        usedSchools++;
                }

                if (usedSchools > SchoolsMax)
                {
                    calculatorLog.AddToLog($"There are {usedSchools - SchoolsMax} more than the character's max of {SchoolsMax}.");
                    valid = false;
                    numErrors++;
                }
            }
            // Determine all school specializations
            {
                foreach (int i in current_characterSheet.abilities)
                {
                    if (Program.abilityLibrary.TryGetAbility(i, out Ability ability))
                    {
                        if (ability.Rank > Rank.Apprentice)
                        {
                            Ability_Schools schoolEnum = ability.ability_School;
                            Ability ability_School = Program.abilityLibrary.GetSchool(schoolEnum);
                            if (!current_characterSheet.abilities.Contains(ability_School.ID))
                            {
                                valid = false;
                                calculatorLog.AddToLog($"{ability.Name} is a {ability.s_rank} ability, requiring you to specialize in the {ability_School.Name}.");
                                numErrors++;
                            }
                        }
                        else
                            continue;
                    }
                }
            }
            // Calculate all prereq checks
            {
                foreach(int i in current_characterSheet.abilities)
                {
                    if(Program.abilityLibrary.TryGetAbility(i,out Ability ability))
                    {
                        if (ability.Name == "School Of Defense" || ability.Name == "School Of Offense" || ability.Name == "School Of Mentalism" ||
                            ability.Name == "School Of Understanding" || ability.Name == "School Of Forms")
                            continue;
                        if (ability.Name == "Pyrokinesis")
                        {
                            if (Program.abilityLibrary.Contains("Advanced Alter Enviroment") || Program.abilityLibrary.Contains("Force Repulse"))
                                continue;
                            else
                            {
                                calculatorLog.AddToLog("Pyrokinesis needs either Advanced Alter Enviroment or Force Repulse");
                                valid = false;
                                numErrors++;
                            }
                        }
                        else if (ability.Name == "Shatterpoint")
                        {
                            int numUnderstanding = 0;

                            if (current_characterSheet.Contains("Psychometry"))
                                numUnderstanding++;
                            else
                            {
                                valid = false;
                                calculatorLog.AddToLog("Shatterpoint requires Psychometry");
                                numErrors++;
                            }
                            if (current_characterSheet.Contains("Force Sight"))
                                numUnderstanding++;
                            else
                            {
                                valid = false;
                                calculatorLog.AddToLog("Shatterpoint requires Force Sight");
                                numErrors++;
                            }

                            foreach (int j in current_characterSheet.abilities)
                            {
                                if(Program.abilityLibrary.TryGetAbility(j, out Ability ability1))
                                {
                                    if (ability1.Name == "Psychometry")
                                        continue;
                                    if (ability1.Name == "Force Sight")
                                        continue;
                                    if (ability1.Name == "Shatterpoint")
                                        continue;
                                    if (ability1.Name == "School Of Understanding")
                                        continue;
                                    else if (ability1.ability_School == Ability_Schools.Ability_Understanding)
                                        numUnderstanding++;
                                }
                            }

                            if (numUnderstanding >= 10)
                                continue;
                            else
                            {
                                valid = false;
                                calculatorLog.AddToLog($"Shatterpoint requires 10 abilities from the school of understanding. You only have {numUnderstanding}.");
                                numErrors++;
                            }
                        }
                        else if (ability.Name == "Force Body")
                        {
                            if (current_characterSheet.Contains("Control Pain") || current_characterSheet.Contains("Force Rage"))
                                continue;
                            else
                            {
                                valid = false;
                                calculatorLog.AddToLog("Force Body requires either Control Pain or Force Rage. You have neither");
                                numErrors++;
                            }
                        }
                        else if (ability.Name == "Flow Walking")
                        {
                            if (current_characterSheet.Contains("Psychometry"))
                            {
                                if (current_characterSheet.Contains("Farseeing") || current_characterSheet.Contains("Darksight"))
                                    continue;
                                else
                                {
                                    valid = false;
                                    calculatorLog.AddToLog("Flow Walking requires either Farseeing or Darksight. You don't have either one.");
                                    numErrors++;
                                }
                            }
                            else
                            {
                                valid = false;
                                calculatorLog.AddToLog("Flow Walking requires Psychometry, plus either Farseeing or Darksight. You are missing Psychometry");
                                numErrors++;
                            }
                        }
                        else
                        {
                            foreach(int j in ability.prereqs)
                            {
                                // Skip if the prereq j being compared is the same ability.
                                if (i == j)
                                    continue;
                                else
                                {
                                    if (current_characterSheet.abilities.Contains(j))
                                        continue;
                                    else
                                    {
                                        calculatorLog.AddToLog($"{ability.Name} is missing the prereq {Program.abilityLibrary.GetAbility(j).Name}");
                                        valid = false;
                                        numErrors++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            calculatorLog.AddToLog($"Results are in: your sheet is {((valid == true) ? "valid" : "invalid")}.");
            calculatorLog.AddToLog($"Number of errors: {numErrors}");
            calculatorLog.ShowDialog();
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
            DataWriter.ExportCharacterSheetExcel(current_characterSheet, saveExcel.FileName, (saveExcel.Filter.Split('.')[1] == "xlsx") ? DataWriter.ExcelFormats.XLSX : DataWriter.ExcelFormats.XLS);
        }
    }
}
