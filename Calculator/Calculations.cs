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

            if (usedSkillPoints > (SkillPointsMax + sheet.additionalSkillPoints))
            {
                log += $"There are {usedSkillPoints - (SkillPointsMax + sheet.additionalSkillPoints)} more skillpoints being used than the character's max of {SkillPointsMax + sheet.additionalSkillPoints}.\n";
                valid = false;
                numErrors++;
            }
            else
            {
                log += $"Used {usedSkillPoints} skill points of the character's {SkillPointsMax + sheet.additionalSkillPoints}.\n";
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

            if (usedFeatPoints > (FeatPointMax + sheet.additionalFeetPoints))
            {
                log += $"There are {usedFeatPoints - (FeatPointMax + sheet.additionalFeetPoints)} more feat points than the character's max of {FeatPointMax + sheet.additionalFeetPoints}.\n";
                valid = false;
                numErrors++;
            }
            else
            {
                log += $"Used {usedFeatPoints} feat points of the character's {FeatPointMax + sheet.additionalFeetPoints}.\n";
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

            if (usedSchools > (SchoolsMax + sheet.additionalSpecialization))
            {
                log += $"There are {usedSchools - (SchoolsMax + sheet.additionalSpecialization)} more than the character's max of {SchoolsMax + sheet.additionalSpecialization} Schools.\n";
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


            if (numMasteries > (MasteriesMax + sheet.additionalMasteryPoints))
            {
                valid = false;
                log += $"You have {numMasteries - (MasteriesMax + sheet.additionalMasteryPoints)} more masteries than what you can currently have. You're max is {(MasteriesMax + sheet.additionalMasteryPoints)}.\n";
                numErrors++;
            }
            else
                log += $"Using {numMasteries} out of {(MasteriesMax + sheet.additionalMasteryPoints)} masteries for rank.";
        }

        void CalculateDroids()
        {
            if (numDroids == 0) return;

            int maxNumDroids = 0;
            maxNumDroids += (sheet.GetAbilitiesWithFilters("Droid", Ability_Schools.Ability_Engineering)).Length;
            // Prior to checking hcm points, a user can only have 3 droids. There are 4 abilities tied to the droid abilities,
            // so -1 to ensure we are not doing a max of 4.
            if (maxNumDroids == 4) maxNumDroids--;

            maxNumDroids += sheet.additionalDroidSlot;

            if (numDroids > maxNumDroids)
            {
                log += $"You have {numDroids - maxNumDroids} more droids than what you can have out on a mission at once. This is not an error or problem, but it means you cannot have all of them out at once.";
            }
        }
    }
}