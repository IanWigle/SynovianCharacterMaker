using System;
using System.Windows.Forms;
using Synovian_Character_Maker.DataClasses.Instanced;

namespace Synovian_Character_Maker.CharacterCalculator
{
    public partial class Calculator
    {
        void CheckSpecializations()
        {
            foreach (int i in sheet.abilities)
            {
                if (_abilityLibrary.TryGetAbility(i, out Ability ability))
                {
                    if (ability.Rank > Rank.Apprentice)
                    {
                        if (ability.ability_School >= Ability_Schools.Ability_Forms) continue;

                        Ability_Schools schoolEnum = ability.ability_School;
                        Ability ability_School = _abilityLibrary.GetSchool(schoolEnum);
                        if (ability_School == null)
                        {
#if DEBUG
                                throw new Exception($"The ability school {Enum.GetName(typeof(Ability_Schools),ability.ability_School)} does not exist");
#else
                            MessageBox.Show($"The ability school {Enum.GetName(typeof(Ability_Schools), ability.ability_School)} does not exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
#endif
                        }
                        if (!sheet.abilities.Contains(ability_School.ID))
                        {
                            valid = false;
                            log += $"{ability.Name} is a {ability.s_rank} ability, requiring you to specialize in the {ability_School.Name}.\n";
                            numErrors++;
                        }
                    }
                    else
                        continue;
                }
            }
        }
    }
}
