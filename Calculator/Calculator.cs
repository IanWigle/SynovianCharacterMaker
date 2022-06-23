using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Synovian_Character_Maker.DataClasses.Instanced;

namespace Synovian_Character_Maker.CharacterCalculator
{
    public partial class Calculator
    {
        public bool Calculate(ref CharacterSheet characterSheet, ref string outlog, ref int errors)
        {
            Reset();

            sheet = characterSheet;

            FeatPointMax = _statRules.FeatPoints[characterSheet.Rank];
            SkillPointsMax = _statRules.SkillPoints[characterSheet.Rank];
            SchoolsMax = _statRules.Schools[characterSheet.Rank];
            MasteriesMax = _statRules.Masteries[characterSheet.Rank];

            CalculateUsedSkillPoints();
            CalculateUsedFeatPoints();
            CalculateSchools();
            CalculateMasteries();

            CheckSpecializations();

            CheckPrereqs();

            CheckCompanions();

            outlog = log;
            errors = numErrors;

            return valid;
        }

        public void Reset()
        {
            FeatPointMax = 0;
            SkillPointsMax = 0;
            SchoolsMax = 0;
            MasteriesMax = 0;

            valid = true;

            numErrors = 0;

            usedSkillPoints = 0;
            usedFeatPoints = 0;
            usedSchools = 0;

            numMasteries = 0;

            sheet = null;

            log = "";
        }
    }
}