using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Drawing;

namespace Synovian_Character_Maker.Data_Classes
{
    public class CharacterSheet
    {
        public enum SheetFileType
        {
            JustCreated = 0,
            Txt,
            Zip,
            Xls,
            XlSx,
            Xlsx_Google
        }

        public string Name { get => _name; }
        string _name = "";

        public Rank Rank { get => _rank; }
        [JsonIgnore]
        public string s_rank { get => Enum.GetName(typeof(Rank), _rank); }
        Rank _rank = Rank.Invalid;

        [JsonIgnore]
        public string s_alignment { get => Enum.GetName(typeof(Ability_Alignment), _alignment).Replace("Ability_", ""); }
        public Ability_Alignment alignment { get => _alignment; }
        Ability_Alignment _alignment = Ability_Alignment.Ability_Invalid;

        public string characterDescription { get; set; }

        public List<int> abilities { get => new List<int>(_abilities); }
        List<int> _abilities;

        [JsonIgnore]
        public string lastModified { get => _lastMod; }
        string _lastMod = "";

        [JsonIgnore]
        public SheetFileType sheetFileType { get => _sheetFileType; }
        SheetFileType _sheetFileType;
        public void setFileType(SheetFileType fileType) => _sheetFileType = fileType;

        public string characterSpecies { get; set; }

        [JsonIgnore]
        public Image _image { get; set; }
        [JsonIgnore]
        public string imageExtension { get; set; }

        public CompanionSheet companionSheet { get; set; }

        public CharacterSheet() { }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment)
        {
            _name = name;
            _rank = rank;
            _alignment = ability_Alignment;
            _abilities = new List<int>();
            characterSpecies = "Unknown";
            _sheetFileType = SheetFileType.JustCreated;
        }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment, List<int> abilities)
        {
            _name = name;
            _rank = rank;
            _alignment = ability_Alignment;
            _abilities = new List<int>(abilities);
            characterSpecies = "Unknown";
            _sheetFileType = SheetFileType.JustCreated;
        }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment, List<int> abilities, Image image)
        {
            _name = name;
            _rank = rank;
            _alignment = ability_Alignment;
            _abilities = new List<int>(abilities);
            _image = image;
            characterSpecies = "Unknown";
            _sheetFileType = SheetFileType.JustCreated;
        }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment, List<int> abilities, Image image, string species)
        {
            _name = name;
            _rank = rank;
            _alignment = ability_Alignment;
            _abilities = new List<int>(abilities);
            _image = image;
            characterSpecies = species;
            _sheetFileType = SheetFileType.JustCreated;
        }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment, List<int> abilities, string lastMod)
        {
            _name = name;
            _rank = rank;
            _alignment = ability_Alignment;
            _abilities = new List<int>(abilities);
            _lastMod = lastMod;
            characterSpecies = "Unknown";
            _sheetFileType = SheetFileType.JustCreated;
        }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment, List<int> abilities, string lastMod, Image image, string species)
        {
            _name = name;
            _rank = rank;
            _alignment = ability_Alignment;
            _abilities = new List<int>(abilities);
            _lastMod = lastMod;
            _image = image;
            characterSpecies = species;
            _sheetFileType = SheetFileType.JustCreated;
        }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment, List<int> abilities, string lastMod, Image image, string species, SheetFileType sfT)
        {
            _name = name;
            _rank = rank;
            _alignment = ability_Alignment;
            _abilities = new List<int>(abilities);
            _lastMod = lastMod;
            _image = image;
            characterSpecies = species;
            _sheetFileType = sfT;
        }

        public void AddAbility(Ability ability)
        {
            if (Program.abilityLibrary.Contains(ref ability) || !_abilities.Contains(ability.ID))
            {
                _abilities.Add(ability.ID);
            }
        }

        public void AddAbility(string name)
        {
            if(Program.abilityLibrary.TryGetAbility(name, out Ability ability))
            {
                _abilities.Add(ability.ID);
            }
        }

        public void AddAbility(int ID)
        {
            if (Program.abilityLibrary.Contains(ID))
            {
                _abilities.Add(ID);
            } 
        }

        public void AddAbilities(List<int> ids)
        {
            foreach(int id in ids)
            {
                if (Program.abilityLibrary.Contains(id) &&
                    !_abilities.Contains(id))
                {
                    _abilities.Add(id);
                }
            }
        }

        public void RemoveAbility(ref Ability ability)
        {
            if (Program.abilityLibrary.Contains(ref ability) || !_abilities.Contains(ability.ID))
            {
                _abilities.Remove(ability.ID);
            }
        }

        public void RemoveAbility(string name)
        {
            if (Program.abilityLibrary.TryGetAbility(name, out Ability ability))
            {
                _abilities.Remove(ability.ID);
            }
        }

        public void RemoveAbility(int ID)
        {
            if (Program.abilityLibrary.Contains(ID))
            {
                _abilities.Remove(ID);
            }
        }

        public bool Contains(string name)
        {
            if(Program.abilityLibrary.TryGetAbility(name, out Ability ability))
            {
                return _abilities.Contains(ability.ID);
            }
            return false;
        }

        public string[] GetAllSchools()
        {
            List<string> schools = new List<string>();
            Ability_Schools[] ability_Schools = (Ability_Schools[])Enum.GetValues(typeof(Ability_Schools));
            List<Ability> registeredSchools = new List<Ability>();
            List<string> registeredSchoolStrings = new List<string>();
            foreach(Ability_Schools schools1 in ability_Schools)
            {
                Ability ability = Program.abilityLibrary.GetSchool(schools1);
                if (ability != null)
                {
                    registeredSchools.Add(ability);
                    registeredSchoolStrings.Add(ability.Name);
                }
            }
            if (registeredSchools.Count() > 0)
            {
                foreach(int ability in _abilities)
                {
                    if (Program.abilityLibrary.TryGetAbility(ability, out Ability ability1))
                    {
                        if(registeredSchoolStrings.Contains(ability1.Name))
                        {
                            schools.Add(ability1.Name);
                        }
                    }
                }
            }
            return schools.ToArray();
        }

        public string[] GetAbilitiesOfSchool(Ability_Schools schools)
        {
            List<string> vs = new List<string>();
            foreach(int i in _abilities)
            {
                if(Program.abilityLibrary.TryGetAbility(i,out Ability ability))
                {
                    if (ability.ability_School == schools)
                        vs.Add(ability.Name);
                }
            }
            return vs.ToArray();
        }

        public string[] GetAbilitiesWithContaingString(string str)
        {
            List<string> vs = new List<string>();
            List<Ability> existingAbilitiesWithStr = Program.abilityLibrary.GetAbilitiesContainingString(str);

            foreach(Ability ability in existingAbilitiesWithStr)
            {
                if (abilities.Contains(ability.ID))
                    vs.Add(ability.Name);
            }

            return vs.ToArray();
        }

        public string[] GetAbilitiesWithFilters(string str)
        {
            return GetAbilitiesWithContaingString(str);
        }

        public string[] GetAbilitiesWithFilters(string str, Rank rank)
        {
            List<string> vs = new List<string>();
            List<Ability> existingAbilitiesWithStr = Program.abilityLibrary.GetAbilitiesContainingString(str);

            foreach (Ability ability in existingAbilitiesWithStr)
            {
                if (abilities.Contains(ability.ID) && ability.Rank == rank)
                    vs.Add(ability.Name);
            }

            return vs.ToArray();
        }

        public string[] GetAbilitiesWithFilters(string str, Rank rank, Ability_Alignment alignment)
        {
            List<string> vs = new List<string>();
            List<Ability> existingAbilitiesWithStr = Program.abilityLibrary.GetAbilitiesContainingString(str);

            foreach (Ability ability in existingAbilitiesWithStr)
            {
                if (abilities.Contains(ability.ID) && ability.Rank == rank && ability.alignment == alignment)
                    vs.Add(ability.Name);
            }

            return vs.ToArray();
        }

        public string[] GetAbilitiesWithFilters(string str, Rank rank, Ability_Alignment alignment, Ability_Schools schools)
        {
            List<string> vs = new List<string>();
            List<Ability> existingAbilitiesWithStr = Program.abilityLibrary.GetAbilitiesContainingString(str);

            foreach (Ability ability in existingAbilitiesWithStr)
            {
                if (abilities.Contains(ability.ID) && ability.Rank == rank && ability.alignment == alignment && ability.ability_School == schools)
                    vs.Add(ability.Name);
            }

            return vs.ToArray();
        }

        /// <summary>
        /// Empty the character sheets list of abilities.
        /// </summary>
        public void Empty() => _abilities.Clear();

        public string[] GetAllDescriptionsBySchool(Ability_Schools schools)
        {
            List<string> descriptions = new List<string>();
            foreach(int ability in abilities)
            {
                if (Program.abilityLibrary.TryGetAbility(ability, out Ability ability1))
                {
                    if (ability1.ability_School == schools)
                        descriptions.Add(ability1.description);
                }
            }
            return descriptions.ToArray();
        }
    }
}
