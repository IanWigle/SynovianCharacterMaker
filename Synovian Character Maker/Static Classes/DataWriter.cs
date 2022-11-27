using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
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

        public static void ExportSettings(ref ProgramSettings programSettings)
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
    }
}
