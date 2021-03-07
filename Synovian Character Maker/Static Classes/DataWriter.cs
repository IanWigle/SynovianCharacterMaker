using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

// Third-Party references.
using Aspose.Zip;
using IronXL;

using Synovian_Character_Maker.Data_Classes;
using Synovian_Character_Maker.Forms.CharacterMaker;

namespace Synovian_Character_Maker.Static_Classes
{
    static public class DataWriter
    {
        public enum ExcelFormats
        {
            XLS,
            XLSX
        }

        public static void ExportSettings(ProgramSettings programSettings)
        {
            if (!Directory.Exists(Globals.DataFolder))
                Directory.CreateDirectory(Globals.DataFolder);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            try
            {
                string jsonString = JsonSerializer.Serialize(programSettings, options);
                File.WriteAllText($"{Globals.DataFolder}\\Settings.txt", jsonString);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ExportStatRules(StatRules statRules)
        {
            if (!Directory.Exists(Globals.DataFolder))
                Directory.CreateDirectory(Globals.DataFolder);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            try
            {
                string jsonString = JsonSerializer.Serialize(statRules, options);
                File.WriteAllText($"{Globals.DataFolder}\\StatRules.txt", jsonString);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Write all abilities in the running program to disk.
        /// </summary>
        public static void WriteAbilitiesToDisk(List<Ability> abilities)
        {
            if (!Directory.Exists(Globals.DataFolder))
                Directory.CreateDirectory(Globals.DataFolder);

            Dictionary<int, string> names = new Dictionary<int, string>();
            Dictionary<int, string> descriptions = new Dictionary<int, string>();

            foreach (Ability ability in abilities)
            {
                names[ability.ID] = ability.Name;
                descriptions[ability.ID] = ability.description;
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            try
            {
                string jsonString = JsonSerializer.Serialize(names, options);
                File.WriteAllText(Globals.StringNameTable, jsonString);

                jsonString = JsonSerializer.Serialize(descriptions, options);
                File.WriteAllText(Globals.StringDescriptionTable, jsonString);

                jsonString = JsonSerializer.Serialize(abilities, options);
                File.WriteAllText(Globals.AbilityTable, jsonString);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Writes a character sheet into json txt to disk.
        /// </summary>
        /// <param name="characterSheet">The sheet to go to disk.</param>
        /// <returns>Will return true if successful, false if failed.</returns>
        public static bool WriteCharacterToDiskTxt(CharacterSheet characterSheet)
        {
            if (!Directory.Exists(Globals.CharacterFolder))
                Directory.CreateDirectory(Globals.CharacterFolder);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            try
            {
                string jsonString = JsonSerializer.Serialize(characterSheet, options);
                File.WriteAllText($"{Globals.CharacterFolder}\\{characterSheet.Name}.txt", jsonString);
                return true;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Writes a character sheet to disk while taking in the parameters to export the character sheet with other documents into one zip file.
        /// </summary>
        /// <param name="characterSheet">The Sheet to be exported.</param>
        /// <param name="url">Target directory to save into.</param>
        /// <param name="zipExportSettings">Additional settings for export.</param>
        public static void WriteCharacterToDiskZip(CharacterSheet characterSheet, string url, ZipExportOptions.ZipExportSettings zipExportSettings)
        {
            if (url == "")
                url = Globals.CharacterFolder;
            else
                url = Path.GetDirectoryName(url);

            // First save txt
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string jsonString = JsonSerializer.Serialize(characterSheet, options);

            if (!Directory.Exists(Globals.TempFolder))
                Directory.CreateDirectory(Globals.TempFolder);

            System.IO.File.WriteAllText($"{Globals.TempFolder}\\{characterSheet.Name}.txt", jsonString);

            if (zipExportSettings.savePicture && characterSheet._image != null)
            {
                characterSheet._image.Save($"{Globals.TempFolder}{characterSheet.Name}.jpg");
            }
            if (zipExportSettings.saveExcel)
            {
                WorkBook mainWorkBook = ExportCharacterSheetExcel(characterSheet, $"{Globals.TempFolder}\\{characterSheet.Name}");

                // Check if we even have a valid companion sheet.
                if (characterSheet.companionSheet != null)
                {
                    if (zipExportSettings.saveCompExcelSeperate)
                    {
                        //WorkBook compWorkBook = ExportCharacterCompanionExcel(characterSheet.companionSheet, ref mainWorkBook);

                        //compWorkBook.SaveAs($"{Globals.TempFolder}\\{characterSheet.companionSheet.companionName}.xlsx");
                    }
                    else
                    {
                        //mainWorkBook = ExportCharacterCompanionExcel(characterSheet.companionSheet, ref mainWorkBook);
                    }
                }

                mainWorkBook.SaveAs($"{Globals.TempFolder}\\{characterSheet.Name}.xlsx");
            }

            // Archive all files
            using (FileStream zipFile = File.Open($"{url}\\{characterSheet.Name}.zip", FileMode.Create))
            {
                string[] filesToZip = Directory.GetFiles(Globals.TempFolder);
                List<FileInfo> fileInfos = new List<FileInfo>();

                foreach (string file in filesToZip)
                    fileInfos.Add(new FileInfo(file));

                using (Archive archive = new Archive())
                {
                    // Add files to archive
                    foreach (FileInfo fileInfo in fileInfos)
                        archive.CreateEntry(fileInfo.Name, fileInfo);
                    // Create ZIP archive
                    archive.Save(zipFile, new Aspose.Zip.Saving.ArchiveSaveOptions());
                }

                foreach (string file1 in filesToZip)
                    File.Delete(file1);
            }
        }

        public static void ExportAllCharacterSheets(List<CharacterSheet> characterSheets)
        {
            foreach (CharacterSheet characterSheet in characterSheets)
            {
                switch (characterSheet.sheetFileType)
                {
                    case CharacterSheet.SheetFileType.Txt:
                        WriteCharacterToDiskTxt(characterSheet);
                        break;
                    case CharacterSheet.SheetFileType.Zip:
                        WriteCharacterToDiskZip(characterSheet, "", new ZipExportOptions.ZipExportSettings(true, false, false));
                        break;
                    case CharacterSheet.SheetFileType.Xls:
                        ExportCharacterSheetExcel(characterSheet, "", ExcelFormats.XLS);
                        break;
                    case CharacterSheet.SheetFileType.XlSx:
                        ExportCharacterSheetExcel(characterSheet, "", ExcelFormats.XLSX);
                        break;
                    default:
                        WriteCharacterToDiskTxt(characterSheet);
                        break;
                }
            }
        }

        /// <summary>
        /// Exports a sheet to a xls or xlsx sheet
        /// </summary>
        /// <param name="characterSheet">The provided sheet that turns into a excel sheet.</param>
        /// <param name="url">The provided url of where to save to.</param>
        /// <param name="excelFormats">The prefered format to save the excel sheet. Default is the newer XLSX</param>
        /// <returns>Will return a copy of the Workbook structure.</returns>
        public static WorkBook ExportCharacterSheetExcel(CharacterSheet characterSheet, string url, ExcelFormats excelFormats = ExcelFormats.XLSX)
        {
            if (url == "")
                url = $"{Globals.CharacterFolder}\\{characterSheet.Name}.{((excelFormats == ExcelFormats.XLS) ? "xls" : "xlsx")}";

            WorkBook workBook = WorkBook.Create(((excelFormats == ExcelFormats.XLSX) ? ExcelFileFormat.XLSX : ExcelFileFormat.XLS));
            workBook.Metadata.Author = "Synovian Empire SCA";

            WorkSheet mainXlSheet = workBook.CreateWorkSheet("Main");

            void MakeThickBorder(string cell)
            {
                if (cell.Contains(":"))
                {
                    foreach(IronXL.Cell cell1 in mainXlSheet.GetRange(cell))
                    {
                        mainXlSheet[cell1.AddressString].Style.BottomBorder.Type = IronXL.Styles.BorderType.Medium;
                        mainXlSheet[cell1.AddressString].Style.BottomBorder.SetColor(System.Drawing.Color.Black);
                        mainXlSheet[cell1.AddressString].Style.TopBorder.Type = IronXL.Styles.BorderType.Medium;
                        mainXlSheet[cell1.AddressString].Style.TopBorder.SetColor(System.Drawing.Color.Black);
                        mainXlSheet[cell1.AddressString].Style.LeftBorder.Type = IronXL.Styles.BorderType.Medium;
                        mainXlSheet[cell1.AddressString].Style.LeftBorder.SetColor(System.Drawing.Color.Black);
                        mainXlSheet[cell1.AddressString].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;
                        mainXlSheet[cell1.AddressString].Style.RightBorder.SetColor(System.Drawing.Color.Black);
                    }
                }

                mainXlSheet[cell].Style.BottomBorder.Type = IronXL.Styles.BorderType.Medium;
                mainXlSheet[cell].Style.BottomBorder.SetColor(System.Drawing.Color.Black);
                mainXlSheet[cell].Style.TopBorder.Type = IronXL.Styles.BorderType.Medium;
                mainXlSheet[cell].Style.TopBorder.SetColor(System.Drawing.Color.Black);
                mainXlSheet[cell].Style.LeftBorder.Type = IronXL.Styles.BorderType.Medium;
                mainXlSheet[cell].Style.LeftBorder.SetColor(System.Drawing.Color.Black);
                mainXlSheet[cell].Style.RightBorder.Type = IronXL.Styles.BorderType.Medium;
                mainXlSheet[cell].Style.RightBorder.SetColor(System.Drawing.Color.Black);
            }
            // Top Header spacer
            mainXlSheet["A1"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet["A1"].Style.SetBackgroundColor(System.Drawing.Color.Black);
            mainXlSheet.Merge("A1:N1");
            // Top Header setup
            mainXlSheet["B2"].StringValue = characterSheet.Name;
            mainXlSheet["B2"].Style.Font.Bold = true;
            mainXlSheet["B2"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
            mainXlSheet["B2"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            mainXlSheet["B2"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
            mainXlSheet["B2"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet["B2"].Style.DiagonalBorder.SetColor(System.Drawing.Color.Black);
            MakeThickBorder("B2:M2");            
            mainXlSheet.Merge("B2:M2");
            mainXlSheet["B3"].StringValue = "Character Information";
            mainXlSheet["B3"].Style.Font.Bold = true;
            mainXlSheet["B3"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
            mainXlSheet["B3"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            mainXlSheet["B3"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
            mainXlSheet["B3"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            MakeThickBorder("B3:E3");
            mainXlSheet.Merge("B3:E3");
            mainXlSheet["F3"].StringValue = "Specialized Trees";
            mainXlSheet["F3"].Style.Font.Bold = true;
            mainXlSheet["F3"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
            mainXlSheet["F3"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            mainXlSheet["F3"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
            mainXlSheet["F3"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            MakeThickBorder("F3:I3");
            mainXlSheet.Merge("F3:I3");
            mainXlSheet["J3"].StringValue = "Saber/Force Forms";
            mainXlSheet["J3"].Style.Font.Bold = true;
            mainXlSheet["J3"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
            mainXlSheet["J3"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            mainXlSheet["J3"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
            mainXlSheet["J3"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            MakeThickBorder("J3:M3");
            mainXlSheet.Merge("J3:M3");
            mainXlSheet.GetColumn(1).Style.ShrinkToFit = true;
            // Top Header info
            // Rank
            mainXlSheet["B4"].StringValue = $"Rank: {characterSheet.s_rank}";
            mainXlSheet["B4"].Style.Font.Bold = true;
            mainXlSheet["B4"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
            mainXlSheet["B4"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            mainXlSheet["B4"].Style.SetBackgroundColor(System.Drawing.Color.LightGray);
            mainXlSheet["B4"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            MakeThickBorder("B4:E4");
            mainXlSheet.Merge("B4:E4");
            // Alignment
            mainXlSheet["B5"].StringValue = $"Alignment: {characterSheet.s_alignment}";
            mainXlSheet["B5"].Style.Font.Bold = true;
            mainXlSheet["B5"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
            mainXlSheet["B5"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            mainXlSheet["B5"].Style.SetBackgroundColor(System.Drawing.Color.LightGray);
            mainXlSheet["B5"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            MakeThickBorder("B5:E5");
            mainXlSheet.Merge("B5:E5");
            // Species
            mainXlSheet["B6"].StringValue = $"Species: {characterSheet.characterSpecies}";
            mainXlSheet["B6"].Style.Font.Bold = true;
            mainXlSheet["B6"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
            mainXlSheet["B6"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            mainXlSheet["B6"].Style.SetBackgroundColor(System.Drawing.Color.LightGray);
            mainXlSheet["B6"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            MakeThickBorder("B6:E6");
            mainXlSheet.Merge("B6:E6");
            // Trees/Schools
            int startingSchoolIndex = 4;
            string[] schools = characterSheet.GetAllSchools();
            foreach (string school in schools)
            {
                mainXlSheet[$"F{startingSchoolIndex}"].StringValue = school;
                mainXlSheet[$"F{startingSchoolIndex}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                mainXlSheet[$"F{startingSchoolIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                mainXlSheet[$"F{startingSchoolIndex}"].Style.SetBackgroundColor(System.Drawing.Color.CadetBlue);
                mainXlSheet[$"F{startingSchoolIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                MakeThickBorder($"F{startingSchoolIndex}:I{startingSchoolIndex}");
                mainXlSheet.Merge($"F{startingSchoolIndex}:I{startingSchoolIndex}");
                startingSchoolIndex++;
            }
            // Forms 
            int startingFormIndex = 4;
            string[] forms = characterSheet.GetAbilitiesOfSchool(Ability_Schools.Ability_Forms);
            foreach (string form in forms)
            {
                mainXlSheet[$"J{startingFormIndex}"].StringValue = form;
                mainXlSheet[$"J{startingFormIndex}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                mainXlSheet[$"J{startingFormIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                mainXlSheet[$"J{startingFormIndex}"].Style.SetBackgroundColor(System.Drawing.Color.MediumPurple);
                mainXlSheet[$"J{startingFormIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                MakeThickBorder($"J{startingFormIndex}:M{startingFormIndex}");
                mainXlSheet.Merge($"J{startingFormIndex}:M{startingFormIndex}");
                startingFormIndex++;
            }
            // Header break
            int currentLowestIndex = (startingSchoolIndex > startingFormIndex) ? startingSchoolIndex : startingFormIndex;
            if (currentLowestIndex <= 6) currentLowestIndex = 7;
            mainXlSheet[$"A{currentLowestIndex}"].Style.SetBackgroundColor(System.Drawing.Color.Black);
            mainXlSheet[$"A{currentLowestIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet.Merge($"A{currentLowestIndex}:N{currentLowestIndex}");
            // Left/Right Header breaks
            // Left
            int columnIndex = currentLowestIndex - 1;
            mainXlSheet[$"A2"].Style.SetBackgroundColor(System.Drawing.Color.Black);
            mainXlSheet[$"A2"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet.Merge($"A2:A{columnIndex}");
            // Right
            mainXlSheet[$"N2"].Style.SetBackgroundColor(System.Drawing.Color.Black);
            mainXlSheet[$"N2"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet.Merge($"N2:N{columnIndex}");
            currentLowestIndex++;
            // Abilities header
            mainXlSheet[$"B{currentLowestIndex}"].StringValue = "Known Abilities";
            mainXlSheet[$"B{currentLowestIndex}"].Style.Font.Bold = true;
            mainXlSheet[$"B{currentLowestIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
            mainXlSheet[$"B{currentLowestIndex}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
            mainXlSheet[$"B{currentLowestIndex}"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
            mainXlSheet[$"B{currentLowestIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            MakeThickBorder($"B{currentLowestIndex}:M{currentLowestIndex}");
            mainXlSheet.Merge($"B{currentLowestIndex}:M{currentLowestIndex}");
            mainXlSheet[$"A{currentLowestIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet[$"A{currentLowestIndex}"].Style.SetBackgroundColor(System.Drawing.Color.Black);
            mainXlSheet[$"N{currentLowestIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet[$"N{currentLowestIndex}"].Style.SetBackgroundColor(System.Drawing.Color.Black);
            currentLowestIndex++;
            // Split each up based on trees
            // These values are not of the rows and columns of excel, rather the rows in neatly sorting abilities
            // based on school.
            const int maxColumns = 3;
            int currentColumn = 0;

            int currentLeftColumnIndex = currentLowestIndex;
            int currentCenterColumnIndex = currentLowestIndex;
            int currentRightColumnIndex = currentLowestIndex;
            int largestColumnIndex = currentLowestIndex;

            System.Drawing.Color DetermineAbilityCellColor(Ability_Alignment ability_Alignment)
            {
                switch (ability_Alignment)
                {
                    case Ability_Alignment.Ability_Dark:
                        {
                            return System.Drawing.Color.IndianRed;
                        }
                    case Ability_Alignment.Ability_Light:
                        {
                            return System.Drawing.Color.LightSkyBlue;
                        }
                    case Ability_Alignment.Ability_Neutral:
                        {
                            return System.Drawing.Color.Violet;
                        }
                    case Ability_Alignment.Ability_NonForce:
                        {
                            return System.Drawing.Color.PaleTurquoise;
                        }
                    default:
                        return System.Drawing.Color.White;
                }
            }

            void SetupLeftColumn(Ability_Schools ability_Schools, ref string[] abilities)
            {
                mainXlSheet[$"B{currentLeftColumnIndex}"].StringValue = $"{Enum.GetName(typeof(Ability_Schools), ability_Schools).Replace("Ability_", "")} Abilities";
                mainXlSheet[$"B{currentLeftColumnIndex}"].Style.Font.Bold = true;
                mainXlSheet[$"B{currentLeftColumnIndex}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                mainXlSheet[$"B{currentLeftColumnIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                mainXlSheet[$"B{currentLeftColumnIndex}"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
                mainXlSheet[$"B{currentLeftColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                MakeThickBorder($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");
                mainXlSheet.Merge($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");
                mainXlSheet[$"E{currentLeftColumnIndex}"].StringValue = "Status";
                mainXlSheet[$"E{currentLeftColumnIndex}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                mainXlSheet[$"E{currentLeftColumnIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                mainXlSheet[$"E{currentLeftColumnIndex}"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
                mainXlSheet[$"E{currentLeftColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                MakeThickBorder($"E{currentLeftColumnIndex}");
                currentLeftColumnIndex++;
                foreach (string ability in abilities)
                {
                    if (Program.abilityLibrary.IsASchool(ability)) continue;
                    mainXlSheet[$"B{currentLeftColumnIndex}"].StringValue = ability;
                    mainXlSheet[$"B{currentLeftColumnIndex}"].Style.SetBackgroundColor(DetermineAbilityCellColor(Program.abilityLibrary.GetAbility(ability).alignment));
                    mainXlSheet[$"B{currentLeftColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                    MakeThickBorder($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");
                    mainXlSheet.Merge($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");
                    currentLeftColumnIndex++;
                }
                if (largestColumnIndex <= currentLeftColumnIndex) largestColumnIndex = currentLeftColumnIndex;
            }

            void SetupCenterColumn(Ability_Schools ability_Schools, ref string[] abilities)
            {
                mainXlSheet[$"F{currentCenterColumnIndex}"].StringValue = $"{Enum.GetName(typeof(Ability_Schools), ability_Schools).Replace("Ability_", "")} Abilities";
                mainXlSheet[$"F{currentCenterColumnIndex}"].Style.Font.Bold = true;
                mainXlSheet[$"F{currentCenterColumnIndex}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                mainXlSheet[$"F{currentCenterColumnIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                mainXlSheet[$"F{currentCenterColumnIndex}"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
                mainXlSheet[$"F{currentCenterColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                MakeThickBorder($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");
                mainXlSheet.Merge($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");
                mainXlSheet[$"I{currentCenterColumnIndex}"].StringValue = "Status";
                mainXlSheet[$"I{currentCenterColumnIndex}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                mainXlSheet[$"I{currentCenterColumnIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                mainXlSheet[$"I{currentCenterColumnIndex}"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
                mainXlSheet[$"I{currentCenterColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                MakeThickBorder($"I{currentCenterColumnIndex}");
                currentCenterColumnIndex++;
                foreach (string ability in abilities)
                {
                    if (Program.abilityLibrary.IsASchool(ability)) continue;
                    mainXlSheet[$"F{currentCenterColumnIndex}"].StringValue = ability;
                    mainXlSheet[$"F{currentCenterColumnIndex}"].Style.SetBackgroundColor(DetermineAbilityCellColor(Program.abilityLibrary.GetAbility(ability).alignment));
                    mainXlSheet[$"F{currentCenterColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                    MakeThickBorder($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");
                    mainXlSheet.Merge($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");
                    currentCenterColumnIndex++;
                }
                if (largestColumnIndex <= currentCenterColumnIndex) largestColumnIndex = currentCenterColumnIndex;
            }

            void SetupRightColumn(Ability_Schools ability_Schools, ref string[] abilities)
            {
                mainXlSheet[$"J{currentRightColumnIndex}"].StringValue = $"{Enum.GetName(typeof(Ability_Schools), ability_Schools).Replace("Ability_", "")} Abilities";
                mainXlSheet[$"J{currentRightColumnIndex}"].Style.Font.Bold = true;
                mainXlSheet[$"J{currentRightColumnIndex}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                mainXlSheet[$"J{currentRightColumnIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                mainXlSheet[$"J{currentRightColumnIndex}"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
                mainXlSheet[$"J{currentRightColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                MakeThickBorder($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");
                mainXlSheet.Merge($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");
                mainXlSheet[$"M{currentRightColumnIndex}"].StringValue = "Status";
                mainXlSheet[$"M{currentRightColumnIndex}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                mainXlSheet[$"M{currentRightColumnIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                mainXlSheet[$"M{currentRightColumnIndex}"].Style.SetBackgroundColor(System.Drawing.Color.DarkGray);
                mainXlSheet[$"M{currentRightColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                MakeThickBorder($"M{currentRightColumnIndex}");
                currentRightColumnIndex++;
                foreach (string ability in abilities)
                {
                    if (Program.abilityLibrary.IsASchool(ability)) continue;
                    mainXlSheet[$"J{currentRightColumnIndex}"].StringValue = ability;
                    mainXlSheet[$"J{currentRightColumnIndex}"].Style.SetBackgroundColor(DetermineAbilityCellColor(Program.abilityLibrary.GetAbility(ability).alignment));
                    mainXlSheet[$"J{currentRightColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                    MakeThickBorder($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");
                    mainXlSheet.Merge($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");
                    currentRightColumnIndex++;
                }
                if (largestColumnIndex <= currentRightColumnIndex) largestColumnIndex = currentRightColumnIndex;
            }

            foreach (Ability_Schools ability_Schools in (Ability_Schools[])Enum.GetValues(typeof(Ability_Schools)))
            {
                if (ability_Schools == 0 || ability_Schools == Ability_Schools.Ability_Max) continue;
                if (ability_Schools == Ability_Schools.Ability_Forms) continue;
                string[] abilities = characterSheet.GetAbilitiesOfSchool(ability_Schools);
                if (abilities.Count() == 0) continue;

                switch (currentColumn)
                {
                    case 0:
                        SetupLeftColumn(ability_Schools, ref abilities);
                        break;
                    case 1:
                        SetupCenterColumn(ability_Schools, ref abilities);
                        break;
                    case 2:
                        SetupRightColumn(ability_Schools, ref abilities);
                        break;
                }

                currentColumn++;
                if (currentColumn >= maxColumns) currentColumn = 0;
            }

            // Fill all empty cells till it fits with border
            if (largestColumnIndex != currentLeftColumnIndex)
            {
                for(int l = currentLeftColumnIndex; l < largestColumnIndex; l++)
                {
                    mainXlSheet[$"B{l}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                    mainXlSheet[$"B{l}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                    mainXlSheet[$"B{l}"].Style.SetBackgroundColor(System.Drawing.Color.Black);
                    mainXlSheet[$"B{l}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                    mainXlSheet.Merge($"B{l}:E{l}");
                }
            }
            if (largestColumnIndex != currentCenterColumnIndex)
            {
                for (int c = currentCenterColumnIndex; c < largestColumnIndex; c++)
                {
                    mainXlSheet[$"F{c}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                    mainXlSheet[$"F{c}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                    mainXlSheet[$"F{c}"].Style.SetBackgroundColor(System.Drawing.Color.Black);
                    mainXlSheet[$"F{c}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                    mainXlSheet.Merge($"F{c}:I{c}");
                }
            }
            if (largestColumnIndex != currentRightColumnIndex)
            {
                for (int r = currentRightColumnIndex; r < largestColumnIndex; r++)
                {
                    mainXlSheet[$"J{r}"].Style.VerticalAlignment = IronXL.Styles.VerticalAlignment.Center;
                    mainXlSheet[$"J{r}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Center;
                    mainXlSheet[$"J{r}"].Style.SetBackgroundColor(System.Drawing.Color.Black);
                    mainXlSheet[$"J{r}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
                    mainXlSheet.Merge($"J{r}:M{r}");
                }
            }

            // Setup border
            mainXlSheet[$"A{largestColumnIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet[$"A{largestColumnIndex}"].Style.SetBackgroundColor(System.Drawing.Color.Black);
            mainXlSheet.Merge($"A{largestColumnIndex}:N{largestColumnIndex}");
            mainXlSheet[$"A{currentLowestIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet[$"A{currentLowestIndex}"].Style.SetBackgroundColor(System.Drawing.Color.Black);
            mainXlSheet.Merge($"A{currentLowestIndex}:A{largestColumnIndex - 1}");
            mainXlSheet[$"N{currentLowestIndex}"].Style.FillPattern = IronXL.Styles.FillPattern.SolidForeground;
            mainXlSheet[$"N{currentLowestIndex}"].Style.SetBackgroundColor(System.Drawing.Color.Black);
            mainXlSheet.Merge($"N{currentLowestIndex}:N{largestColumnIndex - 1}");

            // Setup companion worksheet
            CreateCompanionSheetForExcel(characterSheet.companionSheet, ref workBook);

            // Save the excel file.
            workBook.SaveAs(url);

            try
            {
                if (Directory.Exists(@"C:\Program Files (x86)\Microsoft Office\root\Office16") && File.Exists(@"C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.EXE"))
                {
                    Process.Start(@url);
                }
            }
            catch (Exception e) { }

            return workBook;
        }

        /// <summary>
        /// Exports a character's companion sheet to XLS or XLSX. This function only either adds to an existing book or returns a book to code. DOES NOT SAVE TO DISK
        /// </summary>
        /// <param name="companionSheet">The provided sheet that turns into a excel sheet.</param>
        /// <param name="excelFormats">The prefered format to save the excel sheet. Default is the newer XLSX</param>
        /// <returns></returns>
        public static WorkBook ExportCharacterCompanionExcel(CompanionSheet companionSheet, ExcelFormats excelFormats = ExcelFormats.XLSX)
        {

            WorkBook book = WorkBook.Create((excelFormats == ExcelFormats.XLSX) ? ExcelFileFormat.XLSX : ExcelFileFormat.XLS);
            WorkSheet xlSheet = book.CreateWorkSheet("Companion");

            // Do data export here . . .
            xlSheet["A1"].StringValue = "Name : ";
            xlSheet.Merge("A1:B1");

            xlSheet["C1"].StringValue = companionSheet.companionName;
            xlSheet.Merge("C1:D1");

            xlSheet["A2"].StringValue = "Type : ";
            xlSheet.Merge("A2:B2");

            xlSheet["C2"].StringValue = companionSheet.s_primaryCompanionType;
            xlSheet.Merge("C2:D2");

            xlSheet["A3"].StringValue = "HP : ";
            xlSheet.Merge("A3:B3");

            xlSheet["C3"].StringValue = Program.statRules.CompanionDroidDataDictionary[companionSheet.primaryCompanionType].HP.ToString();
            xlSheet.Merge("C3:D3");

            xlSheet["A4"].StringValue = "AP : ";
            xlSheet.Merge("A4:B4");

            xlSheet["C4"].StringValue = Program.statRules.CompanionDroidDataDictionary[companionSheet.primaryCompanionType].AP.ToString();
            xlSheet.Merge("C4:D4");

            xlSheet["A5"].StringValue = "Dice : ";
            xlSheet.Merge("A5:D5");

            xlSheet["C5"].StringValue = Program.statRules.CompanionDroidDataDictionary[companionSheet.primaryCompanionType].diceRank;
            xlSheet.Merge("C5:D5");

            xlSheet["A6"].StringValue = "Max Skill Points";
            xlSheet.Merge("A6:D6");

            xlSheet["C6"].StringValue = Program.statRules.CompanionDroidDataDictionary[companionSheet.primaryCompanionType].skillPoints.ToString();
            xlSheet.Merge("C6:D6");

            foreach (int i in companionSheet.abilities)
            {
                if (Program.abilityLibrary.TryGetAbility(i, out Ability ability))
                {

                }
            }

            return book;
        }

        public static void CreateCompanionSheetForExcel(CompanionSheet companionSheet, ref WorkBook workBook)
        {
            WorkSheet xlSheet = workBook.CreateWorkSheet("Companion");

            // Do data export here . . .
            xlSheet["A1"].StringValue = "Name : ";
            xlSheet.Merge("A1:B1");

            xlSheet["C1"].StringValue = companionSheet.companionName;
            xlSheet["C1"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
            xlSheet.Merge("C1:D1");

            xlSheet["A2"].StringValue = "Type : ";
            xlSheet.Merge("A2:B2");

            xlSheet["C2"].StringValue = companionSheet.s_primaryCompanionType;
            xlSheet["C2"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
            xlSheet.Merge("C2:D2");

            xlSheet["A3"].StringValue = "HP : ";
            xlSheet.Merge("A3:B3");

            xlSheet["C3"].Int32Value = Program.statRules.CompanionDroidDataDictionary[companionSheet.primaryCompanionType].HP;
            xlSheet.Merge("C3:D3");

            xlSheet["A4"].StringValue = "AP : ";
            xlSheet.Merge("A4:B4");

            xlSheet["C4"].Int32Value = Program.statRules.CompanionDroidDataDictionary[companionSheet.primaryCompanionType].AP;
            xlSheet.Merge("C4:D4");

            xlSheet["A5"].StringValue = "Dice : ";
            xlSheet.Merge("A5:B5");

            xlSheet["C5"].StringValue = Program.statRules.CompanionDroidDataDictionary[companionSheet.primaryCompanionType].diceRank;
            xlSheet["C5"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
            xlSheet.Merge("C5:D5");

            xlSheet["A6"].StringValue = "Max Skill Points";
            xlSheet.Merge("A6:B6");

            xlSheet["C6"].Int32Value = Program.statRules.CompanionDroidDataDictionary[companionSheet.primaryCompanionType].skillPoints;
            xlSheet.Merge("C6:D6");

            xlSheet["A8"].StringValue = "Abilities";
            xlSheet["A9"].StringValue = "Name";
            xlSheet.Merge("A9:C9");

            xlSheet["D9"].StringValue = "Skill Cost";
            xlSheet.Merge("D9:E9");

            int currentIndex = 10;
            foreach (int i in companionSheet.abilities)
            {
                if (Program.abilityLibrary.TryGetAbility(i, out Ability ability))
                {
                    xlSheet[$"A{currentIndex}"].StringValue = ability.Name;
                    xlSheet.Merge($"A{currentIndex}:C{currentIndex}");
                    xlSheet[$"D{currentIndex}"].Int32Value = ability.skillCostOverride;
                    xlSheet[$"D{currentIndex}"].Style.HorizontalAlignment = IronXL.Styles.HorizontalAlignment.Right;
                    xlSheet.Merge($"D{currentIndex}:E{currentIndex}");
                    currentIndex++;
                }
            }
        }
    }
}
