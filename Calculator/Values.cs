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
        private int FeatPointMax = 0;
        private int SkillPointsMax = 0;
        private int SchoolsMax = 0;
        private int MasteriesMax = 0;

        // Validation check value
        private bool valid = true;

        private int numErrors = 0;

        private int usedSkillPoints = 0;
        private int usedFeatPoints = 0;
        private int usedSchools = 0;

        private int numMasteries = 0;

        CharacterSheet sheet = null;

        StatRules _statRules { get; set; }
        AbilityLibrary _abilityLibrary { get; set; }

        string log = "";
    }
}