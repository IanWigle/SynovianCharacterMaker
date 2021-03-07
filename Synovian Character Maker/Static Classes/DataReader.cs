using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Synovian_Character_Maker.Data_Classes;

namespace Synovian_Character_Maker.Static_Classes
{
    static public class DataReader
    {
        public enum DataReadTypes
        {
            txt = 0,
            zip,
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
                    programSettings.HideMainMenu = jsonElement.GetBoolean();
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

            try
            {
                foreach (string fullFile in files)
                {
                    string extension = fullFile.Split('.')[1];

                    if (extension == "txt" && Program.programSettings.FocusOnZipsOverTxts && File.Exists(fullFile.Replace(".txt",".zip")))
                        continue;
                    else if (extension == "txt")
                    {
                        string fileData = File.ReadAllText(fullFile);

                        JsonDocument jsonDocument = JsonDocument.Parse(fileData);
                        JsonElement rootElement = jsonDocument.RootElement;

                        string name = "";
                        string species = "";
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
                            if(compElement.GetRawText() != "null")
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

                        if (name != "" && rank != Rank.Invalid && ability_Alignment != Ability_Alignment.Ability_Invalid)
                        {
                            DateTime dateTime = File.GetLastWriteTime(fullFile);
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
                            if (companionSheet != null) characterSheet.companionSheet = companionSheet;
                            characterLibrary.AddCharacter(characterSheet);
                        }
                    }
                    else if (extension == "zip")
                    {

                    }
                    else if (extension == "xls")
                    {

                    }
                    else if (extension == "xlsl")
                    {

                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string fileData = File.ReadAllText($"{Globals.CharacterFolder}\\{name}");

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
    }
}
