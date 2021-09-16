using System.Collections.Generic;

namespace Synovian_Character_Maker.Static_Classes
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


        public Dictionary<Data_Classes.Rank, int> FeatPoints { get; set; }
        public Dictionary<Data_Classes.Rank, int> SkillPoints { get; set; }
        public Dictionary<Data_Classes.Rank, int> Schools { get; set; }
        public Dictionary<Data_Classes.Rank, int> Masteries { get; set; }
        public Dictionary<Data_Classes.CompanionSheet.CompanionType, CompanionDroidData> CompanionDroidDataDictionary {get; set;}

        public StatRules()
        {
        }

        ~StatRules()
        {
            if (DataWriter.ExportRules.EXPORT_STATRULES)
                DataWriter.ExportStatRules(this);
        }
    }
}
