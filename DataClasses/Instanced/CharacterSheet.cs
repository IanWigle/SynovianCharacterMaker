﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Drawing;

namespace Synovian_Character_Maker.DataClasses.Instanced
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

        public string Name { get; private set; }
        public Rank Rank { get; private set; }
        public string s_rank { get => Enum.GetName(typeof(Rank), Rank); }
        public string s_alignment { get => Enum.GetName(typeof(Ability_Alignment), alignment).Replace("Ability_", ""); }
        public Ability_Alignment alignment { get; private set; }
        public string characterDescription { get; set; }
        public List<int> _abilities { get; private set; }
        public string lastModified { get; private set; }
        public SheetFileType sheetFileType { get; private set; }
        public void setFileType(SheetFileType fileType) => sheetFileType = fileType;
        public string characterSpecies { get; set; }
        public Image _image { get; set; }
        public string imageExtension { get; set; }

        // Hardcore specific values
        public int additionalSkillPoints { get; private set; }
        public int additionalFeetPoints { get; private set; }
        public int additionalMasteryPoints { get; private set; }
        public int additionalDroidSlot { get; private set; }
        public int additionalSpecialization { get; private set; }
        // End of Hardcore values

        public List<CompanionSheet> companionSheets = new List<CompanionSheet>();

        public Dictionary<int, Ability_Mastery> abilityMasteryDictionary = new Dictionary<int, Ability_Mastery>();

        AbilityLibrary AbilityLibraryRef;

        public List<Ability> GetAbilitiesOfClass
        {
            get
            {
                List<Ability> abilities = new List<Ability>();
                foreach (var ability in _abilities)
                {
                    abilities.Add(AbilityLibraryRef.GetAbility(ability));
                }
                return abilities;
            }
        }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment, ref AbilityLibrary libraryRef)
        {
            Name = name;
            Rank = rank;
            alignment = ability_Alignment;
            _abilities = new List<int>();
            characterSpecies = "Unknown";
            sheetFileType = SheetFileType.JustCreated;

            AbilityLibraryRef = libraryRef;
        }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment, List<int> abilities, string _lastMod, ref AbilityLibrary libraryRef)
        {
            Name = name;
            Rank = rank;
            alignment = ability_Alignment;
            _abilities = new List<int>(abilities);
            lastModified = _lastMod;
            characterSpecies = "Unknown";
            sheetFileType = SheetFileType.JustCreated;

            AbilityLibraryRef = libraryRef;
        }

        public CharacterSheet(string name, Rank rank, Ability_Alignment ability_Alignment, List<int> abilities, string lastMod, Image image, string species, SheetFileType sfT, ref AbilityLibrary libraryRef)
        {
            Name = name;
            Rank = rank;
            alignment = ability_Alignment;
            _abilities = new List<int>(abilities);
            lastModified = lastMod;
            _image = image;
            characterSpecies = species;
            sheetFileType = sfT;

            AbilityLibraryRef = libraryRef;
        }

        public void AddAbility(Ability ability)
        {
            if (AbilityLibraryRef.Contains(ref ability) || !_abilities.Contains(ability.ID))
            {
                _abilities.Add(ability.ID);
            }
        }

        public void AddAbility(string name)
        {
            if (AbilityLibraryRef.TryGetAbility(name, out Ability ability))
            {
                _abilities.Add(ability.ID);
            }
        }

        public void AddAbility(int ID)
        {
            if (AbilityLibraryRef.Contains(ID))
            {
                _abilities.Add(ID);
            }
        }

        public void AddAbilities(List<int> ids)
        {
            foreach (int id in ids)
            {
                if (AbilityLibraryRef.Contains(id) &&
                    !_abilities.Contains(id))
                {
                    _abilities.Add(id);
                }
            }
        }

        public void AddAbilities(List<Ability> abs)
        {
            foreach (Ability ability in abs)
            {
                if (AbilityLibraryRef.Contains(ability.ID) && !_abilities.Contains(ability.ID))
                {
                    _abilities.Add(ability.ID);
                }
            }
        }

        public void RemoveAbility(ref Ability ability)
        {
            if (AbilityLibraryRef.Contains(ref ability) || !_abilities.Contains(ability.ID))
            {
                _abilities.Remove(ability.ID);
            }
        }

        public void RemoveAbility(string name)
        {
            if (AbilityLibraryRef.TryGetAbility(name, out Ability ability))
            {
                _abilities.Remove(ability.ID);
            }
        }

        public void RemoveAbility(int ID)
        {
            if (AbilityLibraryRef.Contains(ID))
            {
                _abilities.Remove(ID);
            }
        }

        public bool Contains(string name)
        {
            if (AbilityLibraryRef.TryGetAbility(name, out Ability ability))
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
            foreach (Ability_Schools schools1 in ability_Schools)
            {
                Ability ability = AbilityLibraryRef.GetSchool(schools1);
                if (ability != null)
                {
                    registeredSchools.Add(ability);
                    registeredSchoolStrings.Add(ability.Name);
                }
            }
            if (registeredSchools.Count() > 0)
            {
                foreach (int ability in _abilities)
                {
                    if (AbilityLibraryRef.TryGetAbility(ability, out Ability ability1))
                    {
                        if (registeredSchoolStrings.Contains(ability1.Name))
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
            foreach (int i in _abilities)
            {
                if (AbilityLibraryRef.TryGetAbility(i, out Ability ability))
                {
                    if (ability.ability_School == schools)
                        vs.Add(ability.Name);
                }
            }
            return vs.ToArray();
        }

        public List<Ability> GetAbilitiesListBySchool(Ability_Schools schools)
        {
            List<Ability> vs = new List<Ability>();

            foreach (int i in _abilities)
            {
                if (AbilityLibraryRef.TryGetAbility(i, out Ability ability))
                    if (ability.ability_School == schools)
                        vs.Add(ability);
            }

            return vs;
        }

        public string[] GetAbilitiesWithContaingString(string str)
        {
            List<string> vs = new List<string>();
            List<Ability> existingAbilitiesWithStr = AbilityLibraryRef.GetAbilitiesContainingString(str);

            foreach (Ability ability in existingAbilitiesWithStr)
            {
                if (_abilities.Contains(ability.ID))
                    vs.Add(ability.Name);
            }

            return vs.ToArray();
        }

        public string[] GetAbilitiesWithFilters(string str)
        {
            return GetAbilitiesWithContaingString(str);
        }

        public string[] GetAbilitiesWithFilters(string str, Ability_Schools school)
        {
            List<string> vs = new List<string>();
            List<Ability> existingAbilitiesWithStr = AbilityLibraryRef.GetAbilitiesContainingString(str);

            foreach(Ability ability in existingAbilitiesWithStr)
            {
                if(_abilities.Contains(ability.ID) && ability.ability_School == school)
                    vs.Add(ability.Name);
            }

            return vs.ToArray();
        }

        public string[] GetAbilitiesWithFilters(string str, Rank rank)
        {
            List<string> vs = new List<string>();
            List<Ability> existingAbilitiesWithStr = AbilityLibraryRef.GetAbilitiesContainingString(str);

            foreach (Ability ability in existingAbilitiesWithStr)
            {
                if (_abilities.Contains(ability.ID) && ability.Rank == rank)
                    vs.Add(ability.Name);
            }

            return vs.ToArray();
        }

        public string[] GetAbilitiesWithFilters(string str, Rank rank, Ability_Alignment alignment)
        {
            List<string> vs = new List<string>();
            List<Ability> existingAbilitiesWithStr = AbilityLibraryRef.GetAbilitiesContainingString(str);

            foreach (Ability ability in existingAbilitiesWithStr)
            {
                if (_abilities.Contains(ability.ID) && ability.Rank == rank && ability.alignment == alignment)
                    vs.Add(ability.Name);
            }

            return vs.ToArray();
        }

        public string[] GetAbilitiesWithFilters(string str, Rank rank, Ability_Alignment alignment, Ability_Schools schools)
        {
            List<string> vs = new List<string>();
            List<Ability> existingAbilitiesWithStr = AbilityLibraryRef.GetAbilitiesContainingString(str);

            foreach (Ability ability in existingAbilitiesWithStr)
            {
                if (_abilities.Contains(ability.ID) && ability.Rank == rank && ability.alignment == alignment && ability.ability_School == schools)
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
            foreach (int ability in _abilities)
            {
                if (AbilityLibraryRef.TryGetAbility(ability, out Ability ability1))
                {
                    if (ability1.ability_School == schools)
                        descriptions.Add(ability1.description);
                }
            }
            return descriptions.ToArray();
        }

        public bool HasCompanion(CompanionSheet companionSheet)
        {
            foreach (CompanionSheet sheet in companionSheets)
            {
                if (sheet == companionSheet)
                    return true;
            }
            return false;
        }

        public bool HasCompanion(string name)
        {
            foreach (CompanionSheet sheet in companionSheets)
            {
                if (sheet.companionName == name)
                    return true;
            }
            return false;
        }

        public void RemoveCompanion(string name)
        {
            foreach (CompanionSheet s in companionSheets)
            {
                if (s.companionName == name)
                {
                    companionSheets.Remove(s);
                    return;
                }
            }
        }

        public void AddHardcoreValues(int skill, int feet, int mastery, int droid, int spec)
        {
            additionalSkillPoints = skill;
            additionalFeetPoints = feet;
            additionalMasteryPoints = mastery;
            additionalDroidSlot = droid;
            additionalSpecialization = spec;
        }
    }
}