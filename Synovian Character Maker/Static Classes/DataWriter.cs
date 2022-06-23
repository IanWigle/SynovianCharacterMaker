using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

// Third-Party references.
using Aspose.Zip;

using Synovian_Character_Maker.Static_Classes;
using Synovian_Character_Maker.Forms.CharacterMaker;

using Synovian_Character_Maker.DataClasses.Static;
using Synovian_Character_Maker.DataClasses.Instanced;

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



                //string HP_Rules;
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
        //public static void WriteCharacterToDiskZip(CharacterSheet characterSheet, string url, ZipExportOptions.ZipExportSettings zipExportSettings)
        //{
        //    if (url == "")
        //        url = Globals.CharacterFolder;
        //    else
        //        url = Path.GetDirectoryName(url);
        //
        //    // First save txt
        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true,
        //    };
        //
        //    string jsonString = JsonSerializer.Serialize(characterSheet, options);
        //
        //    if (!Directory.Exists(Globals.TempFolder))
        //        Directory.CreateDirectory(Globals.TempFolder);
        //
        //    System.IO.File.WriteAllText($"{Globals.TempFolder}\\{characterSheet.Name}.txt", jsonString);
        //
        //    if (zipExportSettings.savePicture && characterSheet._image != null)
        //    {
        //        using (var ms = new MemoryStream())
        //        {
        //            characterSheet._image.Save(ms, characterSheet._image.RawFormat);
        //            System.IO.File.WriteAllBytes($"{Globals.TempFolder}\\{characterSheet.Name}.{characterSheet.imageExtension}", ms.ToArray());
        //        }
        //    }
        //    if (zipExportSettings.saveExcel)
        //    {
        //       ExportCharacterSheetExcel(characterSheet, $"{Globals.TempFolder}\\{characterSheet.Name}");
        //
        //    }
        //
        //    // Archive all files
        //    using (FileStream zipFile = File.Open($"{url}\\{characterSheet.Name}.zip", FileMode.Create))
        //    {
        //        string[] filesToZip = Directory.GetFiles(Globals.TempFolder);
        //        List<FileInfo> fileInfos = new List<FileInfo>();
        //
        //        foreach (string file in filesToZip)
        //            fileInfos.Add(new FileInfo(file));
        //
        //        using (Archive archive = new Archive())
        //        {
        //            // Add files to archive
        //            foreach (FileInfo fileInfo in fileInfos)
        //                archive.CreateEntry(fileInfo.Name, fileInfo);
        //            // Create ZIP archive
        //            archive.Save(zipFile, new Aspose.Zip.Saving.ArchiveSaveOptions());
        //        }
        //
        //        try
        //        {
        //            foreach (string file1 in filesToZip)
        //                File.Delete(file1);
        //        }
        //        catch(Exception e) { Helpers.ExceptionHandle(e); }
        //    }
        //}

        //public static void ExportAllCharacterSheets(List<CharacterSheet> characterSheets)
        //{
        //    foreach (CharacterSheet characterSheet in characterSheets)
        //    {
        //        switch (characterSheet.sheetFileType)
        //        {
        //            case CharacterSheet.SheetFileType.Txt:
        //                WriteCharacterToDiskTxt(characterSheet);
        //                break;
        //            case CharacterSheet.SheetFileType.Zip:
        //                WriteCharacterToDiskZip(characterSheet, "", new ZipExportOptions.ZipExportSettings(true, false, false));
        //                break;
        //            case CharacterSheet.SheetFileType.Xls:
        //                ExportCharacterSheetExcel(characterSheet, "", ExcelFormats.XLS);
        //                break;
        //            case CharacterSheet.SheetFileType.XlSx:
        //                ExportCharacterSheetExcel(characterSheet, "", ExcelFormats.XLSX);
        //                break;
        //            case CharacterSheet.SheetFileType.Xlsx_Google:
        //                break;
        //            default:
        //                WriteCharacterToDiskTxt(characterSheet);
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// Exports a sheet to a xls or xlsx sheet
        /// </summary>
        /// <param name="characterSheet">The provided sheet that turns into a excel sheet.</param>
        /// <param name="url">The provided url of where to save to.</param>
        /// <param name="excelFormats">The prefered format to save the excel sheet. Default is the newer XLSX</param>
        /// <returns>Will return a copy of the Workbook structure.</returns>
        //public static void ExportCharacterSheetExcel(CharacterSheet characterSheet, string url, ExcelFormats excelFormats = ExcelFormats.XLSX)
        //{
        //    ExcelManager.ExportSheet(characterSheet, url);
        //}
    }
}
