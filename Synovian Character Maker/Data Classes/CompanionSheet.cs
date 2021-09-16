using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Drawing;

namespace Synovian_Character_Maker.Data_Classes
{
    public class CompanionSheet
    {
        public string companionName { get => _companionName; }
        string _companionName;

        public string companionSpecies { get => _companionSpecies; }
        string _companionSpecies;

        public string companionHistory { get => _companionHistory; }
        string _companionHistory;

        public enum CompanionType
        {
            None = 0,
            Research_Droid,
            Medical_Droid,
            Engineering_Droid,
            Astromech_Droid,
            Protocol_Droid,
            Battle_Droid,
            Security_Droid,
            Assassin_Droid,
            Beast,
            Max
        }

        public CompanionType primaryCompanionType { get => _primaryCompanionType; }
        CompanionType _primaryCompanionType;

        public List<CompanionType> additionalCompanionTypes { get => _additionalCompanionTypes; }
        List<CompanionType> _additionalCompanionTypes = new List<CompanionType>();

        public Image _image = null;

        [JsonIgnore]
        public string s_primaryCompanionType { get => Enum.GetName(typeof(CompanionType), _primaryCompanionType).Replace("_", " "); }

        [JsonIgnore]
        public List<string> s_additionalCompanionTypes
        {
            get
            {
                List<string> strings = new List<string>();

                foreach (CompanionType companionType in _additionalCompanionTypes)
                    strings.Add(Enum.GetName(typeof(CompanionType), companionType).Replace("_", " "));

                return strings;
            }
        }

        public List<int> abilities { get; set; }

        [JsonIgnore]
        public int usedSkillPoints { get => abilities.Count() * 5; }

        public CompanionSheet(string name, CompanionType primeType)
        {
            _companionName = name;
            _primaryCompanionType = primeType;
            _additionalCompanionTypes = new List<CompanionType>();
            abilities = new List<int>();

            switch (primaryCompanionType)
            {
                case CompanionType.Research_Droid:
                    _additionalCompanionTypes.Add(CompanionType.Medical_Droid);
                    _additionalCompanionTypes.Add(CompanionType.Engineering_Droid);
                    _additionalCompanionTypes.Add(CompanionType.Astromech_Droid);
                    break;
                case CompanionType.Security_Droid:
                    _additionalCompanionTypes.Add(CompanionType.Battle_Droid);
                    break;
                case CompanionType.Assassin_Droid:
                    _additionalCompanionTypes.Add(CompanionType.Battle_Droid);
                    break;
                default:
                    break;
            }
        }

        public CompanionSheet(string name, CompanionType primeType, List<CompanionType> secondaryTypes)
        {
            _companionName = name;
            _primaryCompanionType = primeType;
            _additionalCompanionTypes = secondaryTypes;
            abilities = new List<int>();
        }

        public CompanionSheet(string name, CompanionType primeType, List<CompanionType> secondaryTypes, List<int> abs)
        {
            _companionName = name;
            _primaryCompanionType = primeType;
            _additionalCompanionTypes = secondaryTypes;
            abilities = abs;
        }

        public CompanionSheet(string name, CompanionType primaryType, List<int> abs)
        {
            _companionName = name;
            _primaryCompanionType = primaryType;
            _additionalCompanionTypes = new List<CompanionType>();
            abilities = abs;

            switch (primaryCompanionType)
            {
                case CompanionType.Research_Droid:
                    _additionalCompanionTypes.Add(CompanionType.Medical_Droid);
                    _additionalCompanionTypes.Add(CompanionType.Engineering_Droid);
                    _additionalCompanionTypes.Add(CompanionType.Astromech_Droid);
                    break;
                case CompanionType.Security_Droid:
                    _additionalCompanionTypes.Add(CompanionType.Battle_Droid);
                    break;
                case CompanionType.Assassin_Droid:
                    _additionalCompanionTypes.Add(CompanionType.Battle_Droid);
                    break;
                default:
                    break;
            }
        }

        // Used for beast companions
        public CompanionSheet(string name, string species)
        {
            _companionName = name;
            _companionSpecies = species;

            _primaryCompanionType = CompanionType.Beast;

            abilities = new List<int>();
        }

        static public int DetermineSkillPointsByType(CompanionType companionType)
        {
            switch(companionType)
            {
                // Nothing added in ability system for beasts.
                case CompanionType.Beast:
                    return 0;
                case CompanionType.Research_Droid:
                    return 50;
                // Since this is a sub type that isn't a choice, there is no points dedicated
                case CompanionType.Medical_Droid:
                    return 0;
                case CompanionType.Engineering_Droid:
                    return 30;
                case CompanionType.Astromech_Droid:
                    return 30;
                case CompanionType.Protocol_Droid:
                    return 20;
                case CompanionType.Battle_Droid:
                    return 40;
                case CompanionType.Security_Droid:
                    return 35;
                case CompanionType.Assassin_Droid:
                    return 35;
                default:
                    return 0;
            }
        }

        public bool ContainsAbility(int ability) => abilities.Contains(ability);

        public bool ContainsAbility(string ability)
        {
            if (Program.abilityLibrary.TryGetAbility(ability, out Ability ability1))
                return ContainsAbility(ability1.ID);
            return false;
        }

        public void SetCompanionHistory(string history)
        {
            _companionHistory = history;
        }

        public void SetCompanionSpecies(string spec)
        {
            _companionSpecies = spec;
        }
    }
}
