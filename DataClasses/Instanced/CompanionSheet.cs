using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Drawing;

namespace Synovian_Character_Maker.DataClasses.Instanced
{
    public class CompanionSheet
    {
        public string companionName { get; private set; }

        public string companionHistory { get; private set; }

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

        public string beastSpecies { get => _beastSpecies; }
        string _beastSpecies;

        public Image _image = null;

        public AbilityLibrary libraryRef;
        public StatRules statRulesRef;

        [JsonIgnore]
        public string s_primaryCompanionType { get => Enum.GetName(typeof(CompanionType), _primaryCompanionType).Replace("_", " "); }

        public List<int> abilities { get; set; }

        [JsonIgnore]
        public int usedSkillPoints { get => abilities.Count() * 5; }

        public CompanionSheet(string name, string beastSpecies, ref StatRules rules, ref AbilityLibrary abilityLibrary)
        {
            companionName = name;
            _beastSpecies = beastSpecies;

            _primaryCompanionType = CompanionType.Beast;

            abilities = new List<int>();

            statRulesRef = rules;
            libraryRef = abilityLibrary;
        }

        public CompanionSheet(string name, CompanionType primaryType, List<int> abs, ref StatRules rules, ref AbilityLibrary abilityLibrary)
        {
            companionName = name;
            _primaryCompanionType = primaryType;
            abilities = abs;

            statRulesRef = rules;
            libraryRef = abilityLibrary;
        }

        public CompanionSheet(string name, CompanionType primaryType, ref StatRules rules, ref AbilityLibrary abilityLibrary)
        {
            companionName = name;
            _primaryCompanionType = primaryType;
            abilities = new List<int>();
            statRulesRef = rules;
            libraryRef = abilityLibrary;
        }

        public CompanionSheet(string name, string history, CompanionType primaryType, List<int> abs, ref StatRules rules, ref AbilityLibrary abilityLibrary)
        {
            companionName = name;
            SetCompanionHistory(history);
            _primaryCompanionType = primaryType;
            abilities = new List<int>(abs);
            statRulesRef = rules;
            libraryRef = abilityLibrary;
        }

        static public int DetermineSkillPointsByType(CompanionType companionType)
        {
            switch (companionType)
            {
                // Nothing added in ability system for beasts.
                case CompanionType.Beast:
                    return 0;
                case CompanionType.Research_Droid:
                    return 10;
                case CompanionType.Medical_Droid:
                    return 10;
                case CompanionType.Engineering_Droid:
                    return 8;
                case CompanionType.Astromech_Droid:
                    return 8;
                case CompanionType.Protocol_Droid:
                    return 10;
                case CompanionType.Battle_Droid:
                    return 15;
                case CompanionType.Security_Droid:
                    return 10;
                case CompanionType.Assassin_Droid:
                    return 10;
                default:
                    return 0;
            }
        }

        static public CompanionType DetermineEnumTypeByString(string type)
        {
            if (type == "Beast")
                return CompanionType.Beast;
            else if (type == "Research Droid")
                return CompanionType.Research_Droid;
            else if (type == "Medical Droid")
                return CompanionType.Medical_Droid;
            else if (type == "Engineering Droid")
                return CompanionType.Engineering_Droid;
            else if (type == "Astromech Droid")
                return CompanionType.Astromech_Droid;
            else if (type == "Protocol Droid")
                return CompanionType.Protocol_Droid;
            else if (type == "Battle Droid")
                return CompanionType.Battle_Droid;
            else if (type == "Security Droid")
                return CompanionType.Security_Droid;
            else if (type == "Assassin Droid")
                return CompanionType.Assassin_Droid;

            return CompanionType.None;
        }

        public bool ContainsAbility(int ability) => abilities.Contains(ability);

        public bool ContainsAbility(string ability)
        {
            if (libraryRef.TryGetAbility(ability, out Ability ability1))
                return ContainsAbility(ability1.ID);
            return false;
        }

        public void SetCompanionHistory(string history)
        {
            companionHistory = history;
        }

        public void SetBeastSpecies(string species)
        {
            if (statRulesRef.PossibleBeastSpecies.Contains(species))
            {
                _beastSpecies = species;
            }
        }
    }
}
