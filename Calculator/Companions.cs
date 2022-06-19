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
        void CheckCompanions()
        {
            foreach (CompanionSheet companion in sheet.companionSheets)
            {
                if (companion.primaryCompanionType == CompanionSheet.CompanionType.Beast)
                {
                    if (!sheet.Contains("Taming I"))
                    {
                        log +="You are missing Taming I if you wish to have a animal companion.";
                        numErrors++;
                        valid = false;
                    }
                    if (!sheet.Contains("Taming II"))
                    {
                        log +="You are missing Taming II if you wish to have a animal companion.";
                        numErrors++;
                        valid = false;
                    }

                    switch (sheet.alignment)
                    {
                        case Ability_Alignment.Ability_Dark:
                            {
                                if (!sheet.Contains("Beast Control I"))
                                {
                                    log +="As a darksider you need at mininum Beast Control I if you wish to have a animal companion.";
                                    numErrors++;
                                    valid = false;
                                }
                                break;
                            }
                        case Ability_Alignment.Ability_Light:
                            {
                                if (!sheet.Contains("Animal Friendship I"))
                                {
                                    log +="As a lightsider you need at mininum Animal Friendship I if you wish to have a animal companion.";
                                    numErrors++;
                                    valid = false;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    switch (companion.primaryCompanionType)
                    {
                        case CompanionSheet.CompanionType.Research_Droid:
                            {
                                if (!sheet.Contains("Class I Droids"))
                                {
                                    numErrors++;
                                    valid = false;
                                    log +=$"To use the droid companion {companion.companionName}, you need Class I Droids for missions";
                                }
                                break;
                            }
                        case CompanionSheet.CompanionType.Medical_Droid:
                            {
                                if (!sheet.Contains("Class I Droids"))
                                {
                                    numErrors++;
                                    valid = false;
                                    log +=$"To use the droid companion {companion.companionName}, you need Class I Droids for missions";
                                }
                                break;
                            }
                        case CompanionSheet.CompanionType.Engineering_Droid:
                            {
                                if (!sheet.Contains("Class II Droids"))
                                {
                                    numErrors++;
                                    valid = false;
                                    log +=$"To use the droid companion {companion.companionName}, you need Class II Droids for missions";
                                }
                                break;
                            }
                        case CompanionSheet.CompanionType.Astromech_Droid:
                            {
                                if (!sheet.Contains("Class II Droids"))
                                {
                                    numErrors++;
                                    valid = false;
                                    log +=$"To use the droid companion {companion.companionName}, you need Class II Droids for missions";
                                }
                                break;
                            }
                        case CompanionSheet.CompanionType.Protocol_Droid:
                            {
                                if (!sheet.Contains("Class III Droids"))
                                {
                                    numErrors++;
                                    valid = false;
                                    log +=$"To use the droid companion {companion.companionName}, you need Class III Droids for missions";
                                }
                                break;
                            }
                        case CompanionSheet.CompanionType.Battle_Droid:
                            {
                                if (!sheet.Contains("Class IV Droids"))
                                {
                                    numErrors++;
                                    valid = false;
                                    log +=$"To use the droid companion {companion.companionName}, you need Class IV Droids for missions";
                                }
                                break;
                            }
                        case CompanionSheet.CompanionType.Security_Droid:
                            {
                                if (!sheet.Contains("Class IV Droids"))
                                {
                                    numErrors++;
                                    valid = false;
                                    log +=$"To use the droid companion {companion.companionName}, you need Class IV Droids for missions";
                                }
                                break;
                            }
                        case CompanionSheet.CompanionType.Assassin_Droid:
                            {
                                if (!sheet.Contains("Class IV Droids"))
                                {
                                    numErrors++;
                                    valid = false;
                                    log +=$"To use the droid companion {companion.companionName}, you need Class IV Droids for missions";
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }
}
