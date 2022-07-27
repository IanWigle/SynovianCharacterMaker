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
        void CalculateUsedSkillPoints()
        {
            foreach (int int_ability in sheet._abilities)
            {
                if (_abilityLibrary.TryGetAbility(int_ability, out Ability ability))
                {

                    if (ability.isFeat)
                        continue;
                    else
                        usedSkillPoints += ability.skillCostOverride;
                }
            }

            if (usedSkillPoints > SkillPointsMax)
            {
                log += $"There are {usedSkillPoints - SkillPointsMax} more skillpoints being used than the character's max of {SkillPointsMax}.\n";
                valid = false;
                numErrors++;
            }
            else
            {
                log += $"Used {usedSkillPoints} skill points of the character's {SkillPointsMax}.\n";
            }
        }

        void CalculateUsedFeatPoints()
        {
            foreach (int int_ability in sheet._abilities)
            {
                if (_abilityLibrary.TryGetAbility(int_ability, out Ability ability))
                {
                    if (ability.Name == "School Of Forms") continue;
                    if (ability.isFeat)
                        usedFeatPoints += ability.skillCostOverride;
                    else
                        continue;
                }
            }

            if (usedFeatPoints > FeatPointMax)
            {
                log += $"There are {usedFeatPoints - FeatPointMax} more feat points than the character's max of {FeatPointMax}.\n";
                valid = false;
                numErrors++;
            }
            else
            {
                log += $"Used {usedFeatPoints} feat points of the character's {FeatPointMax}.\n";
            }
        }

        void CalculateSchools()
        {
            List<Ability> schools = new List<Ability>();

            foreach (Ability_Schools ability_Schools in (Ability_Schools[])Enum.GetValues(typeof(Ability_Schools)))
            {
                Ability abilitySchool = _abilityLibrary.GetSchool(ability_Schools);
                if (abilitySchool != null) schools.Add(abilitySchool);
            }

            foreach (Ability abilitySchool in schools)
            {
                if (abilitySchool.ability_School == Ability_Schools.Ability_Forms) continue;
                if (sheet._abilities.Contains(abilitySchool.ID))
                    usedSchools++;
            }

            if (usedSchools > SchoolsMax)
            {
                log += $"There are {usedSchools - SchoolsMax} more than the character's max of {SchoolsMax} Schools.\n";
                valid = false;
                numErrors++;
            }
        }

        void CalculateMasteries()
        {
            foreach (KeyValuePair<int, Ability_Mastery> pair in sheet.abilityMasteryDictionary)
            {
                if (pair.Value >= Ability_Mastery.Mastery_Master) numMasteries++;
            }


            if (numMasteries > MasteriesMax)
            {
                valid = false;
                log += $"You have {numMasteries - numMasteries} more masteries than what you can currently have. You're max is {MasteriesMax}.\n";
                numErrors++;
            }
            else
                log += $"Using {numMasteries} out of {MasteriesMax} masteries for rank.";
        }
    }
}