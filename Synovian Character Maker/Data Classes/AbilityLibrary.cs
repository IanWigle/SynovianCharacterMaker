using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synovian_Character_Maker.Data_Classes
{
    public class AbilityLibrary
    {
        public bool Contains(int id)
        {
            foreach (Ability ability in _abilities)
                if (ability.ID == id) return true;
            return false;
        }

        public bool Contains(string ability)
        {
            foreach (Ability ability1 in _abilities)
                if (ability1.Name == ability) return true;
            return false;
        }

        public bool Contains(Ability ability) => _abilities.Contains(ability);

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

        public Ability GetSchool(string school) => GetAbility(school);

        public Ability GetSchool(Ability_Schools ability_Schools)
        {
            return GetAbility(Enum.GetName(typeof(Ability_Schools), ability_Schools).Replace("Ability_", "School Of "));
        }

        public List<Ability> GetAbilities() => new List<Ability>(_abilities);

        public void ClearList() => _abilities.Clear();

        public Ability GetAbility(int id)
        {
            foreach (Ability ability in _abilities)
                if (ability.ID == id) return ability;
            return null;
        }

        public Ability GetAbility(string name)
        {
            foreach (Ability ability in _abilities)
                if (ability.Name == name) 
                    return ability;
            return null;
        }

        public bool IsASchool(Ability ability)
        {
            return IsASchool(ability.Name);
        }

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

        private List<Ability> _abilities = new List<Ability>();
    }
}
