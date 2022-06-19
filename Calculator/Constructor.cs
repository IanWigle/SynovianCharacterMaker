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
        public Calculator(ref StatRules statRules, ref AbilityLibrary abilityLibrary)
        {
            _statRules = statRules;
            _abilityLibrary = abilityLibrary;
        }
    }
}
