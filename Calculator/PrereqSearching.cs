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
        void CheckPrereqs()
        {
            foreach (int i in sheet.abilities)
            {
                if (_abilityLibrary.TryGetAbility(i, out Ability ability))
                {
                    if (_abilityLibrary.IsASchool(ref ability))
                        continue;
                    if (ability.Name == "Pyrokinesis")
                    {
                        if (_abilityLibrary.Contains("Alter Enviroment III") || _abilityLibrary.Contains("Force Repulse"))
                            continue;
                        else
                        {
                            log += "Pyrokinesis needs either Alter Enviroment III or Force Repulse";
                            valid = false;
                            numErrors++;
                        }
                    }
                    else if (ability.Name == "Shatterpoint")
                    {
                        int numUnderstanding = 0;

                        if (sheet.Contains("Battle Mind"))
                            numUnderstanding++;
                        else
                        {
                            valid = false;
                            log += "Shatterpoint requires Battle Mind";
                            numErrors++;
                        }
                        if (sheet.Contains("Force Sight"))
                            numUnderstanding++;
                        else
                        {
                            valid = false;
                            log += "Shatterpoint requires Force Sight";
                            numErrors++;
                        }

                        foreach (int j in sheet.abilities)
                        {
                            if (_abilityLibrary.TryGetAbility(j, out Ability ability1))
                            {
                                if (ability1.Name == "Battle Mind" || ability1.Name == "Force Sight" || ability1.Name == "Shatterpoint" || ability1.Name == "School Of Understanding")
                                    continue;
                                else if (ability1.ability_School == Ability_Schools.Ability_Understanding)
                                    numUnderstanding++;
                            }
                        }

                        if (numUnderstanding >= 10)
                            continue;
                        else
                        {
                            valid = false;
                            log += $"Shatterpoint requires 10 abilities from the school of understanding. You only have {numUnderstanding}.";
                            numErrors++;
                        }
                    }
                    else if (ability.Name == "Instinctive Astrogation")
                    {
                        int numUnderstanding = 0;

                        foreach (int j in sheet.abilities)
                        {
                            if (_abilityLibrary.TryGetAbility(j, out Ability ability1))
                            {
                                if (ability1.Name == "Instinctive Astrogation" || ability1.Name == "School Of Understanding")
                                    continue;
                                else if (ability1.ability_School == Ability_Schools.Ability_Understanding)
                                    numUnderstanding++;
                            }
                        }

                        if (numUnderstanding >= 5)
                            continue;
                        else
                        {
                            valid = false;
                            log += $"Instinctive Astrogation requires 5 abilities from the school of understanding. You only have {numUnderstanding}.";
                            numErrors++;
                        }
                    }
                    else if (ability.Name == "Force Body")
                    {
                        if (sheet.Contains("Control Pain") || sheet.Contains("Force Rage"))
                            continue;
                        else
                        {
                            valid = false;
                            log += "Force Body requires either Control Pain or Force Rage. You have neither";
                            numErrors++;
                        }
                    }
                    else if (ability.Name == "Flow Walking")
                    {
                        if (sheet.Contains("Psychometry"))
                        {
                            if (sheet.Contains("Farseeing") || sheet.Contains("Darksight"))
                                continue;
                            else
                            {
                                valid = false;
                                log += "Flow Walking requires either Farseeing or Darksight. You don't have either one.";
                                numErrors++;
                            }
                        }
                        else
                        {
                            valid = false;
                            log += "Flow Walking requires Psychometry, plus either Farseeing or Darksight. You are missing Psychometry";
                            numErrors++;
                        }
                    }
                    else if (ability.Name == "Saber Staff" || ability.Name == "Jar'kai" || ability.Name == "Saber Pike")
                    {
                        int validNumCheck = 0;
                        string[] intermeidateAbilities = sheet.GetAbilitiesWithFilters("Advanced");
                        string[] forms = { "Niman", "Shii Cho", "Makashi", "Soresu", "Ataru", "Shien/Djem-so", "Juyo" };
                        foreach (string str in intermeidateAbilities)
                        {
                            if (_abilityLibrary.TryGetAbility(str, out Ability interAbility))
                            {
                                if (interAbility.ability_School == Ability_Schools.Ability_Forms)
                                {
                                    foreach (string form in forms)
                                    {
                                        if (interAbility.Name.Contains(form))
                                            validNumCheck++;
                                        if (validNumCheck > 0)
                                            break;
                                    }
                                }
                            }
                            if (validNumCheck > 0)
                                break;
                        }
                        if (validNumCheck > 0)
                        {
                            continue;
                        }
                        else
                        {
                            log += $"{ability.Name} requires at least 1 Advanced saber form.";
                            numErrors++;
                        }
                    }
                    else if (ability.Name == "Trakata")
                    {
                        int validNumCheck = 0;
                        string[] intermeidateAbilities = sheet.GetAbilitiesWithFilters("Intermediate");
                        string[] forms = { "Niman", "Shii Cho", "Makashi", "Soresu", "Ataru", "Shien/Djem-so", "Juyo" };
                        foreach (string str in intermeidateAbilities)
                        {
                            if (_abilityLibrary.TryGetAbility(str, out Ability interAbility))
                            {
                                if (interAbility.ability_School == Ability_Schools.Ability_Forms)
                                {

                                    foreach (string form in forms)
                                    {
                                        if (interAbility.Name.Contains(form))
                                            validNumCheck++;
                                        if (validNumCheck > 0)
                                            break;
                                    }
                                }
                            }
                            else if (validNumCheck > 0)
                                break;
                        }
                        if (validNumCheck > 0)
                        {
                            continue;
                        }
                        else
                        {
                            log += "Trakata requires at least 1 Intermediate saber form.";
                            numErrors++;
                        }
                    }
                    else if (ability.Name == "Lightning Storm")
                    {
                        int MaxNumLightning = _abilityLibrary.GetAbilitiesContainingString("Lightning").Count;
                        int sheetNumLightning = 0;

                        string[] abList = sheet.GetAbilitiesWithContaingString("Lightning");

                        foreach (string str in abList)
                        {
                            if (str == "Lightning Storm") continue;
                            else
                                sheetNumLightning++;
                        }

                        if (sheetNumLightning >= MaxNumLightning)
                            continue;
                        else
                        {
                            log += $"Lightning Storm requires all of the lightning abilities in the Offense School. So far, you only have {sheetNumLightning} of the {MaxNumLightning} lightning abilities.";
                            numErrors++;
                        }
                    }
                    else if (ability.Name == "Blaster" || ability.Name == "Slug Thrower" || ability.Name.Contains("Anti-Material") || ability.Name.Contains("Anti-Organic") || ability.Name.Contains("Anti-Armor") || ability.Name == "Covering Fire" || ability.Name == "Tactical Reload" || ability.Name == "Rail Shot" || ability.Name == "Laze Target" || ability.Name == "High Impact Bolt")
                    {
                        string[] rangeFeats = { "Blaster Training", "Marksman Training", "Pistol Training", "Heavy Weapons Training" };
                        bool hasFeat = false;

                        foreach (string str in rangeFeats)
                        {
                            if (sheet.Contains(str))
                            {
                                hasFeat = true;
                                break;
                            }
                        }
                        if (!hasFeat)
                        {
                            numErrors++;
                            log += $"{ability.Name} requires one of the four ranged weapon training feats.";
                        }
                    }
                    else if (ability.Name == "Explosive Diffusing I")
                    {
                        string[] explosiveFeats = { "Timed Explosives", "Impact Explosives", "Trap Explosives" };
                        bool hasFeat = false;

                        foreach (string str in explosiveFeats)
                        {
                            if (sheet.Contains(str))
                            {
                                hasFeat = true;
                                break;
                            }
                        }

                        if (!hasFeat)
                        {
                            log += "Explosive Diffusing I requires at least one explosive training.";
                            numErrors++;
                        }
                    }
                    else
                    {
                        foreach (int j in ability.prereqs)
                        {
                            // Skip if the prereq j being compared is the same ability.
                            if (i == j)
                                continue;
                            else
                            {
                                if (sheet.abilities.Contains(j))
                                    continue;
                                else
                                {
                                    log += $"{ability.Name} is missing the prereq {_abilityLibrary.GetAbility(j).Name}";
                                    valid = false;
                                    numErrors++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}