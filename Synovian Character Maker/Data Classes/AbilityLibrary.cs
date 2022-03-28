using System;
using System.Collections.Generic;
using System.Linq;
using Synovian_Character_Maker.Static_Classes;

namespace Synovian_Character_Maker.Data_Classes
{
    public class AbilityLibrary
    {
        /// <summary>
        /// Checks library if ability exists based on ID.
        /// </summary>
        /// <param name="id">Provided ability ID.</param>
        /// <returns>Returns TRUE if ability is in the library</returns>
        public bool Contains(int id)
        {
            foreach (Ability ability in _abilities)
                if (ability.ID == id) return true;
            return false;
        }

        /// <summary>
        /// Checks library if ability exists based on ability name.
        /// </summary>
        /// <param name="ability">Name of ability.</param>
        /// <returns>Returns TRUE if ability is in the library</returns>
        public bool Contains(string ability)
        {
            foreach (Ability ability1 in _abilities)
                if (ability1.Name == ability) return true;
            return false;
        }

        /// <summary>
        /// Checks if library contains ability based on provided class.
        /// </summary>
        /// <param name="ability">Provided ability class.</param>
        /// <returns>Returns TRUE if ability is in the library</returns>
        public bool Contains(ref Ability ability) => _abilities.Contains(ability);

        /// <summary>
        /// Try and get an ability based on an provided id. Returns true if successful
        /// </summary>
        /// <param name="id">The ID for the requested ability.</param>
        /// <param name="ability">The outcome var if the ability is found.</param>
        /// <returns>Returns boolian based on if the ability was found or not.</returns>
        public bool TryGetAbility(int id, out Ability ability)
        {
            if(Contains(id))
            {
                ability = GetAbility(id);
                return true;
            }
            else
            {
                ability = null;
                return false;
            }
        }

        /// <summary>
        /// Try and get an ability based on an provided name. Returns true if successful
        /// </summary>
        /// <param name="name">The name for the requested ability.</param>
        /// <param name="ability">The outcome var if the ability is found.</param>
        /// <returns>Returns boolian based on if the ability was found or not.</returns>
        public bool TryGetAbility(string name, out Ability ability)
        {
            if(Contains(name))
            {
                ability = GetAbility(name);
                return true;
            }
            else
            {
                ability = null;
                return false;
            }
        }

        /// <summary>
        /// Creates a new id based on an the next number in order.
        /// </summary>
        public int newID
        {
            get
            {
                if (_abilities.Count == 0)
                    return 0;
                else
                    return _abilities.Last().ID + 1;
            }
        }

        /// <summary>
        /// Adds the ability to the library, will return true is successful.
        /// </summary>
        /// <param name="ability">The new ability to be added to the library.</param>
        /// <returns>Will return a boolian based on if successful in adding the new ability.</returns>
        public bool AddNewAbility(Ability ability)
        {
            foreach (Ability ab in _abilities)
                if (ab.ID == ability.ID || ab.Name == ability.Name) return false;
            _abilities.Add(ability);
            return true;
        }

        /// <summary>
        /// Try and remove an ability based on an provided name. Returns true if successful
        /// </summary>
        /// <param name="name">The name of the ability requested to be removed.</param>
        /// <returns>Returns a boolian if the ability was successfully removed.</returns>
        public bool TryRemoveAbility(string name)
        {
            foreach(Ability ability in _abilities)
                if(ability.Name == name)
                {
                    _abilities.Remove(ability);
                    return true;
                }
            return false;
        }

        /// <summary>
        /// Try and remove an ability based on an provided id. Returns true if successful
        /// </summary>
        /// <param name="id">The id of the provided ability to be removed.</param>
        /// <returns>Returns a boolian if the ability was successfully removed.</returns>
        public bool TryRemoveAbility(int id)
        {
            foreach (Ability ability in _abilities)
                if (ability.ID == id)
                {
                    _abilities.Remove(ability);
                    return true;
                }
            return false;
        }

        /// <summary>
        /// Gets ability flagged as a school by provided name.
        /// </summary>
        /// <param name="school">String name of ability.</param>
        /// <returns>Returns ability class of school.</returns>
        public Ability GetSchool(string school) => GetAbility(school);

        /// <summary>
        /// Gets ability flagged as a school by provided enum value.
        /// </summary>
        /// <param name="ability_Schools">Unique enum value.</param>
        /// <returns>Returns ability class of school.</returns>
        public Ability GetSchool(Ability_Schools ability_Schools)
        {
            return GetAbility(Enum.GetName(typeof(Ability_Schools), ability_Schools).Replace("Ability_", "School Of "));
        }

        /// <summary>
        /// Returns a copy of the ability list that can be modified.
        /// </summary>
        /// <returns>List<Ability> of all abilities.</returns>
        public List<Ability> GetAbilities() => new List<Ability>(_abilities);

        /// <summary>
        /// Clears thge library.
        /// </summary>
        public void ClearList() => _abilities.Clear();

        /// <summary>
        /// Get ability with ability ID.
        /// </summary>
        /// <param name="id">Unique ID of desired ability.</param>
        /// <returns>Returns the ability class of ability if found.</returns>
        public Ability GetAbility(int id)
        {
            foreach (Ability ability in _abilities)
                if (ability.ID == id) return ability;
            return null;
        }

        /// <summary>
        /// Get ability with string name of ability.
        /// </summary>
        /// <param name="name">The name of the ability..</param>
        /// <returns>Returns the ability class of ability if found.</returns>
        public Ability GetAbility(string name)
        {
            foreach (Ability ability in _abilities)
                if (ability.Name == name) 
                    return ability;
            return null;
        }

        /// <summary>
        /// Checks if the provided ability class is a school.
        /// </summary>
        /// <param name="ability">The class of the ability.</param>
        /// <returns>Returns true if a school ability.</returns>
        public bool IsASchool(ref Ability ability)
        {
            return IsASchool(ability.Name);
        }

        /// <summary>
        /// Checks if the provided ability name is a school.
        /// </summary>
        /// <param name="ability">String name of the ability.</param>
        /// <returns>Returns true if a school ability.</returns>
        public bool IsASchool(string ability)
        {
            foreach(Ability_Schools ability_Schools in (Ability_Schools[])Enum.GetValues(typeof(Ability_Schools)))
            {
                if (ability_Schools == Ability_Schools.Ability_Invalid || ability_Schools == Ability_Schools.Ability_Max) continue;
                string enumS = Enum.GetName(typeof(Ability_Schools), ability_Schools).Replace("Ability_", "School Of ");
                if (ability == enumS) return true;
            }
            return false;
        }

        /// <summary>
        /// Get a list of all ability classes of a specific ability school.
        /// </summary>
        /// <param name="ability_Schools">Unique enum value of school</param>
        /// <returns>Returns a list of abilities of a List<Ability></returns>
        public List<Ability> GetAbilitiesOfSchool(Ability_Schools ability_Schools)
        {
            List<Ability> abilities = new List<Ability>();

            foreach(Ability ability in _abilities)
            {
                if (ability.ability_School == ability_Schools)
                    abilities.Add(ability);
            }

            return abilities;
        }

        /// <summary>
        /// Searches the library that contains a specific string.
        /// </summary>
        /// <param name="str">String value to be searched.</param>
        /// <returns>Returns a List<Ability> of abilities.</returns>
        public List<Ability> GetAbilitiesContainingString(string str)
        {
            List<Ability> abilities = new List<Ability>();
            foreach(Ability ability in _abilities)
            {
                if (ability.Name.Contains(str))
                    abilities.Add(ability);
            }
            return abilities;
        }

        public List<Ability> GetAbilitiesContainingStrings(string[] strs)
        {
            List<Ability> abilities = new List<Ability> ();
            foreach (string str in strs)
            {
                abilities.AddRange(GetAbilitiesContainingString(str));
            }

            return abilities;
        }

        public List<Ability> GetAbilitiesContainingIDS(int[] ids)
        {
            List<Ability> abilities = new List<Ability>();
            foreach(int id in ids)
            {
                abilities.Add(GetAbility(id));
            }

            return abilities;
        }

        private List<Ability> _abilities = new List<Ability>();
    }
}
