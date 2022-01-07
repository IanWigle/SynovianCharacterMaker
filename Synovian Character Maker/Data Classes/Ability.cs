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

    public enum Ability_Proficency
    {
        Ability_NotLearned,
        Ability_Learned,
        Ability_Mastered,
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
        public int ID { get; private set; }

        /// <summary>
        /// Unique ability name.
        /// </summary>
        [JsonIgnore]
        public string Name { get; private set; }

        /// <summary>
        /// Enum value for an abilities name.
        /// </summary>
        public Ability_Alignment alignment { get; private set; }

        /// <summary>
        /// Returns a string of the enum value name. Removes the "Ability_" prefix.
        /// </summary>
        [JsonIgnore]
        public string s_alignment { get => Enum.GetName(typeof(Ability_Alignment), alignment).Replace("Ability_", ""); }

        /// <summary>
        /// Enum value for ability rank.
        /// </summary>
        public Rank Rank { get; private set; }

        /// <summary>
        /// Returns a string of the enum value name.
        /// </summary>
        [JsonIgnore]
        public string s_rank { get => Enum.GetName(typeof(Rank), Rank); }

        /// <summary>
        /// Enum value for the school category of the ability.
        /// </summary>
        public Ability_Schools ability_School { get; private set; }

        /// <summary>
        /// Returns a string of the enum value name. Removes the "Ability_" prefix and replaces '_' with spaces.
        /// </summary>
        [JsonIgnore]
        public string s_ability_School { get => Enum.GetName(typeof(Ability_Schools), ability_School).Replace("Ability_", "").Replace('_', ' '); }

        /// <summary>
        /// The skill cost of an ability. By default the cost of an ability equals 1.
        /// </summary>
        public int skillCostOverride { get; private set; }

        /// <summary>
        /// Returns the skill cost as a string.
        /// </summary>
        [JsonIgnore]
        public string s_skillCostOverride { get => skillCostOverride.ToString(); }

        /// <summary>
        /// Unique ability description.
        /// </summary>
        [JsonIgnore]
        public string description { get; private set; }

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
        public List<int> prereqs { get; private set; }

        /// <summary>
        /// Boolian flag to determine if the ability is a Feat or not.
        /// </summary>
        public bool isFeat { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ability()
        {
            Name = "";
            description = "";
            ID = 0;
            alignment = Ability_Alignment.Ability_Invalid;
            Rank = Rank.Invalid;
            ability_School = Ability_Schools.Ability_Invalid;
            prereqs = new List<int>();
            isFeat = false;
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
        public Ability(string name, string desc, int id, Ability_Alignment _alignment, Rank _rank, Ability_Schools school, List<int> _prereqs, int skillCost = 1, bool isF = false)
        {
            Name = name;
            description = desc;
            ID = id;
            alignment = _alignment;
            Rank = _rank;
            ability_School = school;
            prereqs = _prereqs;
            isFeat = isF;
            skillCostOverride = skillCost;
        }

        /// <summary>
        /// Compares the prereq list with a provided list of ids.
        /// </summary>
        /// <param name="ids">Dynamic array of int ids of multiple abilities.</param>
        /// <returns>TRUE if all ids in the provided list is in the prereq list.</returns>
        public bool Contains(List<int> ids)
        {
            foreach(int i in ids)
                if (!prereqs.Contains(i))
                    return false;
            return true;
        }
    }
}
