using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using Synovian_Character_Maker.Static_Classes;
using Synovian_Character_Maker.DataClasses.Instanced;
using Synovian_Character_Maker.DataClasses.Static;

namespace Synovian_Character_Maker.Static_Classes
{
    static public class Helpers
    {
        /// <summary>
        /// Tries to find a form of the provided name in the running program.
        /// </summary>
        /// <param name="name">The name of the form.</param>
        /// <param name="form">The out result of what was found or not found.</param>
        /// <returns>Returns true if a form of said name was found.</returns>
        public static bool TryGetForm(string name, out Form form)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form _form in fc)
            {
                if (_form.Name == name)
                {
                    form = _form;
                    return true;
                }
            }

            form = null;
            return false;
        }

        public static bool TryGetForm(Type type, out Form form)
        {
            FormCollection fc = Application.OpenForms;

            foreach(Form _form in fc)
            {
                if(_form.GetType() == type)
                {
                    form = _form;
                    return true;
                }
            }

            form = null;
            return false;
        }

        public static T GetForm<T>() where T : Form
        {
            FormCollection fc = Application.OpenForms;

            foreach(Form form in fc)
            {
                T casted_form = form as T;
                if (casted_form != null)
                    return casted_form;
            }
            return null;
        }

        public static void ExceptionHandle(string message)
        {
#if DEBUG
            Debug.Write(message);
            throw new Exception(message);
#else
            MessageBox.Show(message,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
#endif
        }

        public static void ExceptionHandle(Exception e)
        {
#if DEBUG
            Debug.Write(e.Message);
            if (e.InnerException != null) Debug.Write(e.InnerException.Message);
            throw e;
#else
            MessageBox.Show(e.Message,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
#endif
        }

        public static List<Ability> GetAvailableAbilities(CompanionSheet.CompanionType companionType1)
        {
            List<Ability> skillsAvailable = new List<Ability>();

            string[] investigationAbil = new string[] { "Thermal Scanner", "Sound Scanner", "False Energy Device", "Distress Beacon",
                                                        "Motion Detector", "Signal Jammer", "Spy Drones", "Voice Mimic Device"};

            string[] universalArmsAbil = new string[] { "Blaster", "Slug Thrower", "Covering Fire", "Tactical Reload",
                                                        "Rail Shot", "Laze Target", "High Impact Bolt"};

            string[] protectionAbil = new string[] { "Stealth Field Generator", "Personal Shield Generator", "Magnetic Seal Boots", "Sound Dampening Belt",
                                                     "Holographic Distraction", "Hard Light Shield", "Stealth Armor", "Power Armor", "Exosuit"};

            string[] offenseAbil = new string[] { "Mounted Rocket", "Stun Cuffs", "Wrist Populsion Device", "Paralize Dart", "Mounted Flamethrower", "Wire Launcher" };


            switch (companionType1)
            {
                case CompanionSheet.CompanionType.Research_Droid:
                    {
                        foreach (string str in investigationAbil)
                        {
                            if (Program.abilityLibrary.TryGetAbility(str, out Ability ability))
                            {
                                skillsAvailable.Add(ability);
                            }
                        }
                        break;
                    }
                case CompanionSheet.CompanionType.Medical_Droid:
                    {
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesOfSchool(Ability_Schools.Ability_Medical));
                        break;
                    }
                case CompanionSheet.CompanionType.Engineering_Droid:
                    {
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesOfSchool(Ability_Schools.Ability_Explosives));
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingString("Repair"));
                        break;
                    }
                case CompanionSheet.CompanionType.Protocol_Droid:
                    {
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingString("Protocols"));
                        break;
                    }
                case CompanionSheet.CompanionType.Battle_Droid:
                    {
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(new string[] { "Auto", "Mortar", "Concussive", "Heavy" }));
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(new string[] { "Power", "Rapid", "Precision", "Balanced Movement" }));
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(universalArmsAbil));
                        break;
                    }
                case CompanionSheet.CompanionType.Security_Droid:
                    {
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(new string[] { "Charged", "Quick", "Serrated", "Dual Wielding" }));
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(universalArmsAbil));
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(protectionAbil));
                        break;
                    }
                case CompanionSheet.CompanionType.Assassin_Droid:
                    {
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(new string[] { "Aimed", "Swift", "Disabling", "Ranged Precision" }));
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(new string[] { "Critical", "Flurry", "Power Attack", "Bleeding Strike", "Dual Wield", "Teras Kasi", "Broken Gate", "Stava" }));
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(offenseAbil));
                        skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesOfSchool(Ability_Schools.Ability_Mobility));
                        break;
                    }
                default:
                    break;
            }

            if (companionType1 != CompanionSheet.CompanionType.Beast)
            {
                skillsAvailable.AddRange(Program.abilityLibrary.GetAbilitiesContainingStrings(new string[] { "Data Storage", "Visual Recording" }));
            }

            return skillsAvailable;
        }

    }
}
