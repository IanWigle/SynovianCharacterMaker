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

        public enum HCM_Types
        {
            SkillPoint,
            FeatPoint,
            MasteryPoint,
            ExtraDroid,
            Specialization
        }

        public Dictionary<Rank, int> FeatPoints { get; set; }
        public Dictionary<Rank, int> SkillPoints { get; set; }
        public Dictionary<Rank, int> Schools { get; set; }
        public Dictionary<Rank, int> Masteries { get; set; }
        public Dictionary<CompanionSheet.CompanionType, CompanionDroidData> CompanionDroidDataDictionary { get; set; }
        public Dictionary<HCM_Types, int> MaxObtainableHCM { get; set; }
        public List<string> PossibleBeastSpecies { get; set; }
        

        public StatRules()
        {
            //MaxObtainableHCM = new Dictionary<HCM_Types, int>();
            //MaxObtainableHCM.Add(HCM_Types.SkillPoint, 15);
            //MaxObtainableHCM.Add(HCM_Types.FeatPoint, 6);
            //MaxObtainableHCM.Add(HCM_Types.MasteryPoint, 0); // 0 is to be read as infinite
            //MaxObtainableHCM.Add(HCM_Types.ExtraDroid, 1);
            //MaxObtainableHCM.Add(HCM_Types.Specialization, 1);
        }

        ~StatRules()
        {
        }
    }
}