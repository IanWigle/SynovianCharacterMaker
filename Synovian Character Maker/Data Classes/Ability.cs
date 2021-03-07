using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [JsonIgnore]
        public string Name { get => _name; }
        string _name = "";

        public Ability_Alignment alignment { get => _alignment; }
        [JsonIgnore]
        public string s_alignment { get => Enum.GetName(typeof(Ability_Alignment), _alignment).Replace("Ability_", ""); }
        Ability_Alignment _alignment = Ability_Alignment.Ability_Invalid;

        public Rank Rank { get => _rank; }
        [JsonIgnore]
        public string s_rank { get => Enum.GetName(typeof(Rank), _rank); }
        Rank _rank = Rank.Invalid;

        public Ability_Schools ability_School { get => _ability_School; }
        [JsonIgnore]
        public string s_ability_School { get => Enum.GetName(typeof(Ability_Schools), _ability_School).Replace("Ability_", "").Replace('_', ' '); }
        Ability_Schools _ability_School = Ability_Schools.Ability_Invalid;

        public int skillCostOverride { get => _skillCostOverride; }
        [JsonIgnore]
        public string s_skillCostOverride { get => _skillCostOverride.ToString(); }
        int _skillCostOverride = 1;

        [JsonIgnore]
        public string description { get => _desc; }
        string _desc = "";
       
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
        public List<int> prereqs { get => _prereqs; }
        List<int> _prereqs = new List<int>();

        public bool isFeat { get => _isFeat; }
        bool _isFeat = false;

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
