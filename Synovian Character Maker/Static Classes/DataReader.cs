using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;
using Synovian_Character_Maker.Data_Classes;

using Aspose.Zip;

namespace Synovian_Character_Maker.Static_Classes
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

            foreach(JsonElement abilityElement in tableRoot.EnumerateArray())
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
                    foreach(JsonElement preElement in prereqElement.EnumerateArray())
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

                if(rootElement.TryGetProperty("FocusOnZipsOverTxts", out JsonElement jsonElement))
                {
                    programSettings.FocusOnZipsOverTxts = jsonElement.GetBoolean();
                }
                if(rootElement.TryGetProperty("HideMainMenu", out JsonElement jsonElement1))
                {
                    programSettings.HideMainMenu = jsonElement1.GetBoolean();
                }
                if(rootElement.TryGetProperty("DetectExcelSheets", out JsonElement jsonElement2))
                {
                    programSettings.DetectExcelSheets = jsonElement2.GetBoolean();
                }
            }
        }

        /// <summary>
        /// Read all sheets from the default sheet folder.
        /// </summary>
        /// <param name="characterLibrary">Referance for library.</param>
        public static void ReadAllSheets(ref CharacterLibrary characterLibrary)
        {
            if(!Directory.Exists(Globals.CharacterFolder))
                Directory.CreateDirectory(Globals.CharacterFolder);

            // First, get all files in the sheets folder
            string[] files = Directory.GetFiles(Globals.CharacterFolder);

            CharacterSheet GetCharacterSheet(string file)
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
                        Data_Classes.CompanionSheet.CompanionType primaryType = CompanionSheet.CompanionType.None;
                        List<Data_Classes.CompanionSheet.CompanionType> secondaryTypes = new List<CompanionSheet.CompanionType>();
                        List<int> abilities = new List<int>();

                        if (compElement.TryGetProperty("companionName", out JsonElement jsonElement4))
                            compName = jsonElement4.GetString();
                        if (compElement.TryGetProperty("primaryCompanionType", out JsonElement jsonElement6))
                            primaryType = (Data_Classes.CompanionSheet.CompanionType)jsonElement6.GetInt32();
                        if (compElement.TryGetProperty("additionalCompanionTypes", out JsonElement jsonElement7))
                        {
                            foreach (JsonElement jsonElement8 in jsonElement7.EnumerateArray())
                            {
                                secondaryTypes.Add((Data_Classes.CompanionSheet.CompanionType)jsonElement8.GetInt32());
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
                            companionSheet = new CompanionSheet(compName, primaryType, secondaryTypes, abilities);
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
                                                                       CharacterSheet.SheetFileType.Txt);
                    characterSheet.characterDescription = description;
                    if (companionSheet != null) characterSheet.companionSheet = companionSheet;
                    return characterSheet;
                }
                else
                    return null;
            }

            try
            {
                foreach (string fullFile in files)
                {
                    string extension = fullFile.Split('.')[1];

                    if (extension == "txt" && Program.programSettings.FocusOnZipsOverTxts && File.Exists(fullFile.Replace(".txt", ".zip")))
                        continue;
                    else if (extension == "txt")
                    {
                        characterLibrary.AddCharacter(GetCharacterSheet(fullFile));
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

                        foreach(var entry in Directory.GetFiles(Globals.TempFolder))
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

                        CharacterSheet characterSheet = GetCharacterSheet(jsonString);
                        characterSheet._image = Image.FromFile(imageString);
                        characterSheet.imageExtension = imageString.Split('\\')[imageString.Split('\\').Count() - 1].Split('.')[1];
                        Program.characterLibrary.AddCharacter(characterSheet);
                    }
                    else if (extension == "xls")
                    {
                        //CharacterSheet characterSheet = LoadExelSheet(fullFile, ExcelFileFormat.XLS);
                        CharacterSheet characterSheet = ExcelManager.ImportSheet(fullFile);
                        characterLibrary.AddCharacter(characterSheet);
                    }
                    else if (extension == "xlsx")
                    {
                        //CharacterSheet characterSheet = LoadExelSheet(fullFile, ExcelFileFormat.XLSX);
                        CharacterSheet characterSheet = ExcelManager.ImportSheet(fullFile);
                        characterLibrary.AddCharacter(characterSheet);
                    }
                }
            }
            catch(Exception e)
            {
                Helpers.ExceptionHandle(e);
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

            string fileData = File.ReadAllText($"{Globals.DataFolder}\\StatRules.txt");

            JsonDocument jsonDocument = JsonDocument.Parse(fileData);
            JsonElement rootElement = jsonDocument.RootElement;

            if (rootElement.TryGetProperty("FeatPoints", out JsonElement jsonElementFeats))
            {
                foreach(Rank rank in (Rank[])Enum.GetValues(typeof(Rank)))
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
            if (rootElement.TryGetProperty("CompanionDroidDataDictionary", out JsonElement jsonElementCompData))
            {
                foreach(CompanionSheet.CompanionType companionType in (CompanionSheet.CompanionType[])Enum.GetValues(typeof(CompanionSheet.CompanionType)))
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
        }

        public static CharacterSheet ReadSheetFromTxtDisk(string name)
        {
            string fileData = "";

            if (name.Contains(Globals.CharacterFolder))
            {
                fileData = File.ReadAllText($"{name}");
            }
            else if (!name.Contains("\\"))
                fileData = File.ReadAllText($"{Globals.CharacterFolder}\\{name}");
            else
                fileData = File.ReadAllText(name);

            JsonDocument jsonDocument = JsonDocument.Parse(fileData);
            JsonElement rootElement = jsonDocument.RootElement;

            string charName = (name.Split('.').Count() > 1) ? name.Split('.')[0] : name;
            Rank rank = Rank.Invalid;
            Ability_Alignment ability_Alignment = Ability_Alignment.Ability_Invalid;
            List<int> vs = new List<int>();

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

            if (name != "" && rank != Rank.Invalid && ability_Alignment != Ability_Alignment.Ability_Invalid)
            {
                DateTime dateTime = File.GetLastWriteTime(name);
                string dateTimeofMod = (dateTime.Day > 9) ? dateTime.Day.ToString() : ("0" + dateTime.Day.ToString());
                dateTimeofMod += "-" + ((dateTime.Month > 9) ? dateTime.Month.ToString() : ("0" + dateTime.Month.ToString()));
                dateTimeofMod += "-" + dateTime.Year.ToString();

                return new CharacterSheet(name,
                                          rank,
                                          ability_Alignment,
                                          vs,
                                          dateTimeofMod);
                
            }

            return null;
        }

        public static CharacterSheet ReadSheetFromZipDisk(string url)
        {
            CharacterSheet GetCharacterSheet(string file)
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
                        Data_Classes.CompanionSheet.CompanionType primaryType = CompanionSheet.CompanionType.None;
                        List<Data_Classes.CompanionSheet.CompanionType> secondaryTypes = new List<CompanionSheet.CompanionType>();
                        List<int> abilities = new List<int>();

                        if (compElement.TryGetProperty("companionName", out JsonElement jsonElement4))
                            compName = jsonElement4.GetString();
                        if (compElement.TryGetProperty("primaryCompanionType", out JsonElement jsonElement6))
                            primaryType = (Data_Classes.CompanionSheet.CompanionType)jsonElement6.GetInt32();
                        if (compElement.TryGetProperty("additionalCompanionTypes", out JsonElement jsonElement7))
                        {
                            foreach (JsonElement jsonElement8 in jsonElement7.EnumerateArray())
                            {
                                secondaryTypes.Add((Data_Classes.CompanionSheet.CompanionType)jsonElement8.GetInt32());
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
                            companionSheet = new CompanionSheet(compName, primaryType, secondaryTypes, abilities);
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

                    CharacterSheet new_characterSheet = new CharacterSheet(name,
                                                                       rank,
                                                                       ability_Alignment,
                                                                       vs,
                                                                       dateTimeofMod,
                                                                       null,
                                                                       species,
                                                                       CharacterSheet.SheetFileType.Txt);
                    new_characterSheet.characterDescription = description;
                    if (companionSheet != null) new_characterSheet.companionSheet = companionSheet;
                    return new_characterSheet;
                }
                else
                    return null;
            }

            // Get the zip archive
            FileStream fileStream = File.Open(url, FileMode.Open);
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

            CharacterSheet characterSheet = GetCharacterSheet(jsonString);
            characterSheet._image = Image.FromFile(imageString);
            characterSheet.imageExtension = imageString.Split('\\')[imageString.Split('\\').Count() - 1].Split('.')[1];
            return characterSheet;
        }

        /// <summary>
        /// Loads audio json settings from disk and straight into the audio player.
        /// </summary>
        /// <param name="audioPlayer">The program's static audio player.</param>
        public static void LoadAudioSettings(ref AudioPlayer audioPlayer)
        {
            string settingsFile = File.ReadAllText($"{Globals.DataFolder}\\Settings.txt");

            JsonDocument jsonDocument = JsonDocument.Parse(settingsFile);

            JsonElement rootElement = jsonDocument.RootElement;
            if (rootElement.TryGetProperty("LoopSong", out JsonElement jsonElement2))
            {
                Program.programSettings.LoopSong = jsonElement2.GetBoolean();
                audioPlayer.onLoop = jsonElement2.GetBoolean();
            }
            if (rootElement.TryGetProperty("AudioVolume", out JsonElement jsonElement3))
            {
                Program.programSettings.AudioVolume = jsonElement3.GetDecimal();
                audioPlayer.volume = jsonElement3.GetDecimal(); ;
            }
        }

        /*
        public static CharacterSheet LoadExelSheet(string url, IronXL.ExcelFileFormat excelFileFormat = ExcelFileFormat.XLSX)
        {
            WorkBook workBook = WorkBook.Load(url);
            WorkSheet mainSheet = workBook.WorkSheets.First();

            string charName = "";
            string species = "";
            Ability_Alignment ability_Alignment = Ability_Alignment.Ability_Invalid;
            Rank rank = Rank.Invalid;
            List<int> abilities = new List<int>();

            int currentIndex = 3;

            // Get all basic info
            charName = mainSheet["B2"].StringValue;
            string s_rank = mainSheet["B4"].StringValue.Replace("Rank: ","");
            foreach(Rank _rank in (Rank[])Enum.GetValues(typeof(Rank)))
            {
                if (s_rank == Enum.GetName(typeof(Rank), _rank))
                {
                    rank = _rank;
                    break;
                }
            }
            string s_alignment = mainSheet["B5"].StringValue.Replace("Alignment: ", "");
            foreach(Ability_Alignment _alignment in (Ability_Alignment[])Enum.GetValues(typeof(Ability_Alignment)))
            {
                if (s_alignment == Enum.GetName(typeof(Ability_Alignment), _alignment).Replace("Ability_",""))
                {
                    ability_Alignment = _alignment;
                    break;
                }
            }
            species = mainSheet["B6"].StringValue.Replace("Species: ", "");
            currentIndex++;
            // Dynamically get all specialized schools.
            int schoolIndex = currentIndex;
            do
            {
                // Get cell string
                string schoolName = mainSheet[$"F{schoolIndex}"].StringValue;
                // If the cell did not have a string, leave this loop.
                if (schoolName == "" || schoolName == null) break;
                // Get the school from the ability library.
                Ability ability_school = Program.abilityLibrary.GetSchool(schoolName);
                // If ability is valid, add to abilities list
                if (ability_school != null)
                    abilities.Add(ability_school.ID);
                schoolIndex++;
                // Throw an exception if we somehow surpassed the max number of registered schools.
                if (schoolIndex > (int)Ability_Schools.Ability_Max)
                    throw new Exception("School read has exceeded possible number of schools");
            } while (true);

            // Dynamically get all saber/force forms
            int formIndex = currentIndex;
            do
            {
                // Get form name from cell.
                string formName = mainSheet[$"J{formIndex}"].StringValue;
                if (formName == "" || formName == null) break;
                if (formName.Contains("School Of"))
                {
                    Ability ability = Program.abilityLibrary.GetSchool(formName);
                    if (ability != null)
                    {
                        abilities.Add(ability.ID);
                        formIndex++;
                        continue;
                    }
                }
                else if(Program.abilityLibrary.TryGetAbility(formName, out Ability ability1))
                {
                    abilities.Add(ability1.ID);
                    formIndex++;
                }
                if (Program.abilityLibrary.GetAbilitiesOfSchool(Ability_Schools.Ability_Forms).Count() < formIndex)
                    throw new Exception("Form read has exceeded possible numver of forms");
            } while (true);

            currentIndex = (formIndex > schoolIndex) ? formIndex : schoolIndex;

            // Incremant for page break and for the two headers
            currentIndex += 3;
            if (mainSheet[$"B{currentIndex}"].StringValue == "") currentIndex += 3;

            int leftColumnAbilities = currentIndex;
            int ceneterColumnAbilities = currentIndex;
            int rightColumnAbilities = currentIndex;

            string[] headerNames = { "Offense Abilities", "Survival Abilities", "Understanding Abilities", 
                                     "Mentalism Abilities", "Defense Abilities", "Arms Abilities", 
                                     "Engineering Abilities","Medical Abilities", "Mobility Abilities",
                                     "Technology Abilities", "Close_Quarters Abilities"};
                        
            void HandleColumn(string cellColumn, ref int columnIndex)
            {
                do
                {
                    string name = mainSheet[$"{cellColumn}{columnIndex}"].StringValue;
                    if (name != "")
                    {
                        if (headerNames.Contains(name))
                        {
                            columnIndex++;
                            continue;
                        }
                        if (Program.abilityLibrary.TryGetAbility(name, out Ability ability))
                        {
                            abilities.Add(ability.ID);
                            columnIndex++;
                        }
                        else
                            break;
                    }
                    else
                        break;
                } while (true);
            }

            HandleColumn("B", ref leftColumnAbilities);
            HandleColumn("F", ref ceneterColumnAbilities);
            HandleColumn("J", ref rightColumnAbilities);

            CharacterSheet characterSheet = new CharacterSheet(charName,
                                                               rank,
                                                               ability_Alignment,
                                                               new List<int>(),
                                                               null,
                                                               species);
            characterSheet.AddAbilities(abilities);

            WorkSheet companSheet = workBook.GetWorkSheet("Companion");
            if (companSheet != null)
            {
                string compName = companSheet["C1"].StringValue;
                string companionType = companSheet["C2"].StringValue.Replace(" ", "_");
                List<int> compAbilities = new List<int>();
                CompanionSheet.CompanionType companionType1 = CompanionSheet.CompanionType.None;
                foreach(CompanionSheet.CompanionType companionType2 in (CompanionSheet.CompanionType[])Enum.GetValues(typeof(CompanionSheet.CompanionType)))
                {
                    if (companionType == Enum.GetName(typeof(CompanionSheet.CompanionType), companionType2))
                        companionType1 = companionType2;
                }

                int startingIndex = 10;
                do
                {
                    if (companSheet[$"A{startingIndex}"].StringValue != "")
                    {
                        if (Program.abilityLibrary.TryGetAbility(companSheet[$"A{startingIndex}"].StringValue, out Ability ability))
                        {
                            compAbilities.Add(ability.ID);
                            startingIndex++;
                        }
                    }
                    else
                        break;
                } while (true);

                CompanionSheet companionSheet = new CompanionSheet(compName, companionType1, compAbilities);
                characterSheet.companionSheet = companionSheet;
            }

            return characterSheet;
        }
        */
    }
}
