using Aspose.Zip;
using Synovian_Character_Maker.DataClasses.Instanced;
using Synovian_Character_Maker.DataClasses.Static;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Synovian_Character_Maker
{
    static public class DataReader
    {
        public enum DataReadTypes
        {
            txt = 0,
            zip,
            xls,
            xlsx,
            max
        }

        //public static StatRules StatRulesRef = null;
        //public static AbilityLibrary abilityLibraryRef = null;

        /// <summary>
        /// Main method of reading abilities from disk.
        /// </summary>
        /// <param name="abilityLibrary">Referance for library.</param>
        public static void ReadAbilities(ref AbilityLibrary abilityLibrary)
        {
            if (!Directory.Exists(Globals.DataFolder))
                Directory.CreateDirectory(Globals.DataFolder);

            if (!File.Exists(Globals.StringNameTable))
            {
                return;
            }
            if (!File.Exists(Globals.StringDescriptionTable))
            {
                return;
            }

            string TablejsonString = File.ReadAllText(Globals.AbilityTable);
            string NameJsonString = File.ReadAllText(Globals.StringNameTable);
            string DescJsonString = File.ReadAllText(Globals.StringDescriptionTable);

            JsonDocument TablejsonDocument = JsonDocument.Parse(TablejsonString);
            JsonDocument NamejsonDocument = JsonDocument.Parse(NameJsonString);
            JsonDocument DescjsonDocument = JsonDocument.Parse(DescJsonString);

            JsonElement tableRoot = TablejsonDocument.RootElement;
            JsonElement nameRoot = NamejsonDocument.RootElement;
            JsonElement descRoot = DescjsonDocument.RootElement;

            foreach (JsonElement abilityElement in tableRoot.EnumerateArray())
            {
                string name = "";
                string desc = "";
                Ability_Alignment ability_Alignment = Ability_Alignment.Ability_Invalid;
                Ability_Schools ability_Schools = Ability_Schools.Ability_Invalid;
                Rank rank = Rank.Invalid;
                int skillCostOverride = 1;
                int id = 0;
                List<int> ids = new List<int>();
                bool isFeat = false;

                if (abilityElement.TryGetProperty("ID", out JsonElement IDelement))
                    id = IDelement.GetInt32();
                if (abilityElement.TryGetProperty("alignment", out JsonElement alignElement))
                    ability_Alignment = (Ability_Alignment)alignElement.GetInt32();
                if (abilityElement.TryGetProperty("Rank", out JsonElement rankElement))
                    rank = (Rank)rankElement.GetInt32();
                if (abilityElement.TryGetProperty("ability_School", out JsonElement schoolElement))
                    ability_Schools = (Ability_Schools)schoolElement.GetInt32();
                if (abilityElement.TryGetProperty("skillCostOverride", out JsonElement skillElement))
                    skillCostOverride = skillElement.GetInt32();
                if (abilityElement.TryGetProperty("prereqs", out JsonElement prereqElement))
                {
                    foreach (JsonElement preElement in prereqElement.EnumerateArray())
                    {
                        ids.Add(preElement.GetInt32());
                    }
                }
                if (abilityElement.TryGetProperty("isFeat", out JsonElement featElement))
                    isFeat = featElement.GetBoolean();
                if (nameRoot.TryGetProperty(id.ToString(), out JsonElement nameElement))
                    name = nameElement.GetString();
                if (descRoot.TryGetProperty(id.ToString(), out JsonElement descElement))
                    desc = descElement.GetString();

                Ability ability = new Ability(name,
                                              desc,
                                              id,
                                              ability_Alignment,
                                              rank,
                                              ability_Schools,
                                              ids,
                                              skillCostOverride,
                                              isFeat);

                abilityLibrary.AddNewAbility(ability);
            }
        }

        /// <summary>
        /// Main method of reading settings from disk.
        /// </summary>
        /// <param name="programSettings">Referance for program settings.</param>
        public static void ReadSettings(ref ProgramSettings programSettings)
        {
            if (!File.Exists($"{Globals.DataFolder}\\Settings.txt"))
            {
                programSettings.FocusOnZipsOverTxts = true;
            }
            else
            {
                string settingsFile = File.ReadAllText($"{Globals.DataFolder}\\Settings.txt");

                JsonDocument jsonDocument = JsonDocument.Parse(settingsFile);

                JsonElement rootElement = jsonDocument.RootElement;

                if (rootElement.TryGetProperty("FocusOnZipsOverTxts", out JsonElement jsonElement))
                {
                    programSettings.FocusOnZipsOverTxts = jsonElement.GetBoolean();
                }
                if (rootElement.TryGetProperty("HideMainMenu", out JsonElement jsonElement1))
                {
                    programSettings.HideMainMenu = jsonElement1.GetBoolean();
                }
                if (rootElement.TryGetProperty("DetectExcelSheets", out JsonElement jsonElement2))
                {
                    programSettings.DetectExcelSheets = jsonElement2.GetBoolean();
                }
            }
        }

        /// <summary>
        /// Read all sheets from the default sheet folder.
        /// </summary>
        /// <param name="characterLibrary">Referance for library.</param>
        public static void ReadAllSheets()
        {
            if (!Directory.Exists(Globals.CharacterFolder))
                Directory.CreateDirectory(Globals.CharacterFolder);

            // First, get all files in the sheets folder
            string[] files = Directory.GetFiles(Globals.CharacterFolder);

            CharacterSheet GetCharacterSheetFromTextJson(string file)
            {
                string fileData = File.ReadAllText(file);

                JsonDocument jsonDocument = JsonDocument.Parse(fileData);
                JsonElement rootElement = jsonDocument.RootElement;

                string name = "";
                string species = "";
                string description = "";
                Rank rank = Rank.Invalid;
                Ability_Alignment ability_Alignment = Ability_Alignment.Ability_Invalid;
                List<int> vs = new List<int>();
                CompanionSheet companionSheet = null;

                if (rootElement.TryGetProperty("Name", out JsonElement jsonElement))
                {
                    name = jsonElement.GetString();
                }
                if (rootElement.TryGetProperty("Rank", out JsonElement jsonElement1))
                {
                    rank = (Rank)jsonElement1.GetInt32();
                }
                if (rootElement.TryGetProperty("alignment", out JsonElement jsonElement2))
                {
                    ability_Alignment = (Ability_Alignment)jsonElement2.GetInt32();
                }
                if (rootElement.TryGetProperty("abilities", out JsonElement jsonElement3))
                {
                    foreach (JsonElement jsonElement4 in jsonElement3.EnumerateArray())
                    {
                        vs.Add(jsonElement4.GetInt32());
                    }
                }
                if (rootElement.TryGetProperty("species", out JsonElement jsonElement5))
                {
                    species = jsonElement5.GetString();
                }
                if (rootElement.TryGetProperty("companionSheet", out JsonElement compElement))
                {
                    if (compElement.GetRawText() != "null")
                    {
                        string compName = "";
                        CompanionSheet.CompanionType primaryType = CompanionSheet.CompanionType.None;
                        List<CompanionSheet.CompanionType> secondaryTypes = new List<CompanionSheet.CompanionType>();
                        List<int> abilities = new List<int>();

                        if (compElement.TryGetProperty("companionName", out JsonElement jsonElement4))
                            compName = jsonElement4.GetString();
                        if (compElement.TryGetProperty("primaryCompanionType", out JsonElement jsonElement6))
                            primaryType = (CompanionSheet.CompanionType)jsonElement6.GetInt32();
                        if (compElement.TryGetProperty("additionalCompanionTypes", out JsonElement jsonElement7))
                        {
                            foreach (JsonElement jsonElement8 in jsonElement7.EnumerateArray())
                            {
                                secondaryTypes.Add((CompanionSheet.CompanionType)jsonElement8.GetInt32());
                            }
                        }
                        if (compElement.TryGetProperty("abilities", out JsonElement jsonElement9))
                        {
                            foreach (JsonElement jsonElement8 in jsonElement9.EnumerateArray())
                            {
                                abilities.Add(jsonElement8.GetInt32());
                            }
                        }

                        if (compName != "" && primaryType != CompanionSheet.CompanionType.None)
                        {
                            companionSheet = new CompanionSheet(compName, primaryType, abilities, ref Program._statRules, ref Program.abilityLibrary);
                        }
                    }
                }
                if (rootElement.TryGetProperty("characterSpecies", out JsonElement jsonElement10))
                {
                    species = jsonElement10.GetString();
                }
                if (rootElement.TryGetProperty("characterDescription", out JsonElement jsonElement11))
                {
                    description = jsonElement11.GetString();
                }

                if (name != "" && rank != Rank.Invalid && ability_Alignment != Ability_Alignment.Ability_Invalid)
                {
                    DateTime dateTime = File.GetLastWriteTime(file);
                    string dateTimeofMod = (dateTime.Day > 9) ? dateTime.Day.ToString() : ("0" + dateTime.Day.ToString());
                    dateTimeofMod += "-" + ((dateTime.Month > 9) ? dateTime.Month.ToString() : ("0" + dateTime.Month.ToString()));
                    dateTimeofMod += "-" + dateTime.Year.ToString();

                    CharacterSheet characterSheet = new CharacterSheet(name,
                                                                       rank,
                                                                       ability_Alignment,
                                                                       vs,
                                                                       dateTimeofMod,
                                                                       null,
                                                                       species,
                                                                       CharacterSheet.SheetFileType.Txt,
                                                                       ref Program.abilityLibrary);
                    characterSheet.characterDescription = description;
                    if (companionSheet != null) characterSheet.companionSheets.Add(companionSheet);
                    return characterSheet;
                }
                else
                    return null;
            }

            try
            {
                foreach (string fullFile in files)
                {
                    string extension = fullFile.Split('.').Last<string>();

                    if (extension == "txt" && Program.programSettings.FocusOnZipsOverTxts && File.Exists(fullFile.Replace(".txt", ".zip")))
                        continue;
                    else if (extension == "txt")
                    {
                        Program.characterLibrary.AddCharacter(GetCharacterSheetFromTextJson(fullFile));
                    }
                    else if (extension == "zip")
                    {
                        // Get the zip archive
                        FileStream fileStream = File.Open(fullFile, FileMode.Open);
                        Archive archive = new Archive(fileStream);

                        if (!Directory.Exists(Globals.TempFolder))
                            Directory.CreateDirectory(Globals.TempFolder);

                        archive.ExtractToDirectory(Globals.TempFolder);

                        string jsonString = "";
                        string imageString = "";
                        string[] acceptedImageFormats = { ".jpg", ".png", ".bmp", ".gif", ".ico", ".wdp", ".tiff" };

                        foreach (var entry in Directory.GetFiles(Globals.TempFolder))
                        {
                            FileInfo fileInfo = new FileInfo(entry);

                            if (fileInfo != null)
                            {
                                if (fileInfo.Extension == ".txt")
                                    jsonString = fileInfo.FullName;
                                else if (acceptedImageFormats.Contains(fileInfo.Extension))
                                    imageString = fileInfo.FullName;
                            }
                        }

                        CharacterSheet characterSheet = GetCharacterSheetFromTextJson(jsonString);
                        characterSheet._image = Image.FromFile(imageString);
                        characterSheet.imageExtension = imageString.Split('\\')[imageString.Split('\\').Count() - 1].Split('.')[1];
                        Program.characterLibrary.AddCharacter(characterSheet);
                    }
                    else if (extension == "xls")
                    {
                        //CharacterSheet characterSheet = LoadExelSheet(fullFile, ExcelFileFormat.XLS);
                        CharacterSheet characterSheet = Program.excelManager.ImportSheet(fullFile);
                        Program.characterLibrary.AddCharacter(characterSheet);
                    }
                    else if (extension == "xlsx")
                    {
                        //CharacterSheet characterSheet = LoadExelSheet(fullFile, ExcelFileFormat.XLSX);
                        CharacterSheet characterSheet = Program.excelManager.ImportSheet(fullFile);
                        Program.characterLibrary.AddCharacter(characterSheet);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandles.ExceptionHandle(e);
            }


        }

        /// <summary>
        /// Checks default folder location if a sheet exists.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsSheetInDefaultDir(string name, DataReadTypes dataReadTypes = DataReadTypes.txt) => File.Exists($"{Globals.CharacterFolder}\\{name}.{((dataReadTypes == DataReadTypes.txt) ? "txt" : "zip")}");

        public static void ReadStatRules(ref StatRules statRules)
        {
            statRules.FeatPoints = new Dictionary<Rank, int>();
            statRules.SkillPoints = new Dictionary<Rank, int>();
            statRules.Schools = new Dictionary<Rank, int>();
            statRules.Masteries = new Dictionary<Rank, int>();
            statRules.CompanionDroidDataDictionary = new Dictionary<CompanionSheet.CompanionType, StatRules.CompanionDroidData>();
            statRules.PossibleBeastSpecies = new List<string>();
            statRules.MaxObtainableHCM = new Dictionary<StatRules.HCM_Types, int>();

            string fileData = File.ReadAllText($"{Globals.DataFolder}\\StatRules.txt");

            JsonDocument jsonDocument = JsonDocument.Parse(fileData);
            JsonElement rootElement = jsonDocument.RootElement;

            if (rootElement.TryGetProperty("FeatPoints", out JsonElement jsonElementFeats))
            {
                foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank)))
                {
                    string enumName = Enum.GetName(typeof(Rank), rank);
                    if (jsonElementFeats.TryGetProperty(enumName, out JsonElement jsonElement))
                        statRules.FeatPoints[rank] = jsonElement.GetInt32();
                }
            }
            if (rootElement.TryGetProperty("SkillPoints", out JsonElement jsonElementSkills))
            {
                foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank)))
                {
                    string enumName = Enum.GetName(typeof(Rank), rank);
                    if (jsonElementSkills.TryGetProperty(enumName, out JsonElement jsonElement))
                        statRules.SkillPoints[rank] = jsonElement.GetInt32();
                }
            }
            if (rootElement.TryGetProperty("Schools", out JsonElement jsonElementSchools))
            {
                foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank)))
                {
                    string enumName = Enum.GetName(typeof(Rank), rank);
                    if (jsonElementSchools.TryGetProperty(enumName, out JsonElement jsonElement))
                        statRules.Schools[rank] = jsonElement.GetInt32();
                }
            }
            if (rootElement.TryGetProperty("Masteries", out JsonElement jsonElementMasteries))
            {
                foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank)))
                {
                    string enumName = Enum.GetName(typeof(Rank), rank);
                    if (jsonElementMasteries.TryGetProperty(enumName, out JsonElement jsonElement))
                        statRules.Masteries[rank] = jsonElement.GetInt32();
                }
            }
            if(rootElement.TryGetProperty("MaxObtainableHCM", out JsonElement jsonHCM))
            {
                foreach(StatRules.HCM_Types type in (StatRules.HCM_Types[])Enum.GetValues(typeof(StatRules.HCM_Types)))
                {
                    string HCM = Enum.GetName(typeof(StatRules.HCM_Types), type);
                    if(jsonHCM.TryGetProperty(HCM,out JsonElement jsonElement))
                        statRules.MaxObtainableHCM[type] = jsonElement.GetInt32();
                }
            }
            if (rootElement.TryGetProperty("CompanionDroidDataDictionary", out JsonElement jsonElementCompData))
            {
                foreach (CompanionSheet.CompanionType companionType in (CompanionSheet.CompanionType[])Enum.GetValues(typeof(CompanionSheet.CompanionType)))
                {
                    StatRules.CompanionDroidData companionDroidData = new StatRules.CompanionDroidData();

                    string name = Enum.GetName(typeof(CompanionSheet.CompanionType), companionType);
                    if (jsonElementCompData.TryGetProperty(name, out JsonElement jsonElement))
                    {
                        if (jsonElement.TryGetProperty("HP", out JsonElement jsonHP))
                            companionDroidData.HP = jsonHP.GetInt32();
                        if (jsonElement.TryGetProperty("AP", out JsonElement jsonAP))
                            companionDroidData.AP = jsonAP.GetInt32();
                        if (jsonElement.TryGetProperty("diceRank", out JsonElement jsondiceRank))
                            companionDroidData.diceRank = jsondiceRank.GetString();
                        if (jsonElement.TryGetProperty("skillPoints", out JsonElement jsonSkill))
                            companionDroidData.skillPoints = jsonSkill.GetInt32();
                    }

                    statRules.CompanionDroidDataDictionary[companionType] = companionDroidData;
                }
            }

            fileData = File.ReadAllText($"{Globals.DataFolder}\\AnimalCompanions.txt");
            jsonDocument = JsonDocument.Parse(fileData);
            rootElement = jsonDocument.RootElement;

            try
            {
                int index = 0;
                do
                {
                    if (rootElement.TryGetProperty(index.ToString(), out JsonElement jsonElement))
                    {
                        statRules.PossibleBeastSpecies.Add(jsonElement.GetString());
                        index++;
                        continue;
                    }
                    else
                        break;
                } while (true);
            }
            catch (Exception ex)
            {
                ExceptionHandles.ExceptionHandle(ex);
            }
        }

        /// <summary>
        /// Loads audio json settings from disk and straight into the audio player.
        /// </summary>
        /// <param name="audioPlayer">The program's static audio player.</param>
        public static void LoadAudioSettings()
        {
            string settingsFile = File.ReadAllText($"{Globals.DataFolder}\\Settings.txt");

            JsonDocument jsonDocument = JsonDocument.Parse(settingsFile);

            JsonElement rootElement = jsonDocument.RootElement;
            if (rootElement.TryGetProperty("LoopSong", out JsonElement jsonElement2))
            {
                Program.programSettings.LoopSong = jsonElement2.GetBoolean();
                Program.audioPlayer.onLoop = jsonElement2.GetBoolean();
            }
            if (rootElement.TryGetProperty("AudioVolume", out JsonElement jsonElement3))
            {
                Program.programSettings.AudioVolume = jsonElement3.GetDecimal();
                Program.audioPlayer.volume = jsonElement3.GetDecimal(); ;
            }
        }
    }
}