using System.Collections.Generic;

namespace Synovian_Character_Maker.DataClasses.Instanced
{
    public class StatRules
    {
        public struct CompanionDroidData
        {
            public int HP { get; set; }
            public int AP { get; set; }
            public string diceRank { get; set; }
            public int skillPoints { get; set; }

            public CompanionDroidData(int hp, int ap, string dr, int sp)
            {
                HP = hp;
                AP = ap;
                diceRank = dr;
                skillPoints = sp;
            }
        }


        public Dictionary<Rank, int> FeatPoints { get; set; }
        public Dictionary<Rank, int> SkillPoints { get; set; }
        public Dictionary<Rank, int> Schools { get; set; }
        public Dictionary<Rank, int> Masteries { get; set; }
        public Dictionary<DataClasses.Instanced.CompanionSheet.CompanionType, CompanionDroidData> CompanionDroidDataDictionary { get; set; }
        public List<string> PossibleBeastSpecies { get; set; }


        public StatRules()
        {
        }

        ~StatRules()
        {
        }
    }
}