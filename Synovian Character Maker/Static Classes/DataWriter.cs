using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

// Third-Party references.
using Aspose.Zip;

using Synovian_Character_Maker.Data_Classes;
using Synovian_Character_Maker.Forms.CharacterMaker;

namespace Synovian_Character_Maker.Static_Classes
{
    static public class DataWriter
    {
        static public class ExportRules
        {
            public const bool EXPORT_STATRULES = false;
            public const bool EXPORT_ABILITYLIBRARY = false;
        }

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
                Helpers.ExceptionHandle(e);
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
                //string jsonString = JsonSerializer.Serialize(statRules, options);
                //File.WriteAllText($"{Globals.DataFolder}\\StatRules.txt", jsonString);

                //List<int> feats = new List<int>();
                //List<int> skills = new List<int>();
                //List<int> schools = new List<int>();
                //List<int> masteries = new List<int>();
                //List<StatRules.CompanionDroidData> droidData = new List<StatRules.CompanionDroidData>();



                string HP_Rules;
            }
            catch (Exception e)
            {
                Helpers.ExceptionHandle(e);
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
                Helpers.ExceptionHandle(e);
            }
        }

        /// <summary>
        /// Writes a character sheet into json txt to disk.
        /// </summary>
        /// <param name="characterSheet">The sheet to go to disk.</param>
        /// <returns>Will return true if successful, false if failed.</returns>
        public static bool WriteCharacterToDiskTxt(CharacterSheet characterSheet, string customDirectory = "")
        {
            if (!Directory.Exists(Globals.CharacterFolder))
                Directory.CreateDirectory(Globals.CharacterFolder);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };


            if (customDirectory == "")
            {
                if (File.Exists($"{Globals.CharacterFolder}\\{characterSheet.Name}.zip") ||
                File.Exists($"{Globals.CharacterFolder}\\{characterSheet.Name}.xls") ||
                File.Exists($"{Globals.CharacterFolder}\\{characterSheet.Name}.xlsx"))
                {
                    return false;
                }
            }
            

            try
            {
                if (customDirectory == "")
                    customDirectory = $"{Globals.CharacterFolder}\\{characterSheet.Name}.txt"; 
                string jsonString = JsonSerializer.Serialize(characterSheet, options);
                File.WriteAllText(customDirectory, jsonString);
                return true;
            }
            catch (Exception e)
            {
                Helpers.ExceptionHandle(e);
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
                using (var ms = new MemoryStream())
                {
                    characterSheet._image.Save(ms, characterSheet._image.RawFormat);
                    System.IO.File.WriteAllBytes($"{Globals.TempFolder}\\{characterSheet.Name}.{characterSheet.imageExtension}", ms.ToArray());
                }
            }
            if (zipExportSettings.saveExcel)
            {
               ExportCharacterSheetExcel(characterSheet, $"{Globals.TempFolder}\\{characterSheet.Name}");

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

                try
                {
                    foreach (string file1 in filesToZip)
                        File.Delete(file1);
                }
                catch(Exception e) { Helpers.ExceptionHandle(e); }
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
        public static void ExportCharacterSheetExcel(CharacterSheet characterSheet, string url, ExcelFormats excelFormats = ExcelFormats.XLSX)
        {
            ExcelManager.ExportSheet(characterSheet, url);
        }

        /*
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

        */
    }
}
