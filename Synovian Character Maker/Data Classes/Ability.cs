using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Synovian_Character_Maker.Data_Classes
{
    /// <summary>
    /// The alignment of characters and abilities/feats that can determine or aid in filtering, and unlocking options.
    /// </summary>
    public enum Ability_Alignment
    {
        /// <summary>
        /// Reserved for error checking.
        /// </summary>
        Ability_Invalid,
        Ability_Neutral,
        Ability_Light,
        Ability_Dark,
        Ability_NonForce,
        /// <summary>
        /// Reserved for non learning abilities such as school prereqs.
        /// </summary>
        Ability_Other,
        /// <summary>
        /// Reserved for program calculating.
        /// </summary>
        Ability_Max
    }

    /// <summary>
    /// The rank of characters and abilities/feats that can determine or aid in filtering, and unlocking options.
    /// </summary>
    public enum Rank
    {
        /// <summary>
        /// Reserved for error checking.
        /// </summary>
        Invalid,
        Initiate,
        Acolyte,
        Apprentice,
        Knight,
        Lord,
        Archon,
        Elder,
        Emperor,
        /// <summary>
        /// Reserved for program calculating.
        /// </summary>
        Max
    }

    public enum Ability_Schools
    {
        /// <summary>
        /// Reserved for error checking.
        /// </summary>
        Ability_Invalid,
        Ability_Defense,
        Ability_Offense,
        Ability_Mentalism,
        Ability_Survival,
        Ability_Understanding,
        Ability_Forms,
        Ability_Arms,
        Ability_Explosives,
        Ability_Close_Quarters,
        Ability_Mobility,
        Ability_Medical,
        Ability_Engineering,
        Ability_Technology,
        Ability_Droids,
        Ability_Relics,
        /// <summary>
        /// Reserved for program calculating.
        /// </summary>
        Ability_Max
    }

    public class Ability
    {
        /// <summary>
        /// The unique ID of an ability.
        /// </summary>
        public int ID { get => _id; }
        int _id = 0;

        /// <summary>
        /// Unique ability name.
        /// </summary>
        [JsonIgnore]
        public string Name { get => _name; }
        string _name = "";

        /// <summary>
        /// Enum value for an abilities name.
        /// </summary>
        public Ability_Alignment alignment { get => _alignment; }

        /// <summary>
        /// Returns a string of the enum value name. Removes the "Ability_" prefix.
        /// </summary>
        [JsonIgnore]
        public string s_alignment { get => Enum.GetName(typeof(Ability_Alignment), _alignment).Replace("Ability_", ""); }
        Ability_Alignment _alignment = Ability_Alignment.Ability_Invalid;

        /// <summary>
        /// Enum value for ability rank.
        /// </summary>
        public Rank Rank { get => _rank; }

        /// <summary>
        /// Returns a string of the enum value name.
        /// </summary>
        [JsonIgnore]
        public string s_rank { get => Enum.GetName(typeof(Rank), _rank); }
        Rank _rank = Rank.Invalid;

        /// <summary>
        /// Enum value for the school category of the ability.
        /// </summary>
        public Ability_Schools ability_School { get => _ability_School; }

        /// <summary>
        /// Returns a string of the enum value name. Removes the "Ability_" prefix and replaces '_' with spaces.
        /// </summary>
        [JsonIgnore]
        public string s_ability_School { get => Enum.GetName(typeof(Ability_Schools), _ability_School).Replace("Ability_", "").Replace('_', ' '); }
        Ability_Schools _ability_School = Ability_Schools.Ability_Invalid;

        /// <summary>
        /// The skill cost of an ability. By default the cost of an ability equals 1.
        /// </summary>
        public int skillCostOverride { get => _skillCostOverride; }

        /// <summary>
        /// Returns the skill cost as a string.
        /// </summary>
        [JsonIgnore]
        public string s_skillCostOverride { get => _skillCostOverride.ToString(); }
        int _skillCostOverride = 1;

        /// <summary>
        /// Unique ability description.
        /// </summary>
        [JsonIgnore]
        public string description { get => _desc; }
        string _desc = "";
       
        /// <summary>
        /// Returns a string list of all the prerequisite abilitys for the ability. Returns the names, not IDs.
        /// </summary>
        [JsonIgnore]
        public List<string> s_prereqs
        {
            get
            {
                List<string> list = new List<string>();
                if (Program.abilityLibrary == null)
                    return list;
                else
                {
                    foreach(int i in prereqs)
                    {
                        if (Program.abilityLibrary.TryGetAbility(i, out Ability ability))
                            list.Add(ability.Name);
                    }
                    return list;
                }
            }
        }

        /// <summary>
        /// Integer list of the ability IDs required for this ability.
        /// </summary>
        public List<int> prereqs { get => _prereqs; }
        List<int> _prereqs = new List<int>();

        /// <summary>
        /// Boolian flag to determine if the ability is a Feat or not.
        /// </summary>
        public bool isFeat { get => _isFeat; }
        bool _isFeat = false;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ability()
        {
            _name = "";
            _desc = "";
            _id = 0;
            _alignment = Ability_Alignment.Ability_Invalid;
            _rank = Rank.Invalid;
            _ability_School = Ability_Schools.Ability_Invalid;
            _prereqs = new List<int>();
            _isFeat = false;
        }

        /// <summary>
        /// </summary>
        /// <param name="name">Name of ability.</param>
        /// <param name="desc">Description of ability.</param>
        /// <param name="id">Unique ability ID.</param>
        /// <param name="alignment">Alignment of the ability.</param>
        /// <param name="rank">Rank of the ability.</param>
        /// <param name="school">School Category of the ability.</param>
        /// <param name="prereqs">Prereq list of abilities.</param>
        /// <param name="skillCost">Skill override cost of ability. Default cost is 1.</param>
        /// <param name="isF">Flag is ability is feat. Default is false.</param>
        public Ability(string name, string desc, int id, Ability_Alignment alignment, Rank rank, Ability_Schools school, List<int> prereqs, int skillCost = 1, bool isF = false)
        {
            _name = name;
            _desc = desc;
            _id = id;
            _alignment = alignment;
            _rank = rank;
            _ability_School = school;
            _prereqs = prereqs;
            _isFeat = isF;
            _skillCostOverride = skillCost;
        }

        /// <summary>
        /// Compares the prereq list with a provided list of ids.
        /// </summary>
        /// <param name="ids">Dynamic array of int ids of multiple abilities.</param>
        /// <returns>TRUE if all ids in the provided list is in the prereq list.</returns>
        public bool Contains(List<int> ids)
        {
            foreach(int i in ids)
                if (!_prereqs.Contains(i))
                    return false;
            return true;
        }
    }
}
