using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Synovian_Character_Maker.Forms;
using Synovian_Character_Maker.Static_Classes;
using Synovian_Character_Maker.DataClasses.Static;
using Synovian_Character_Maker.DataClasses.Instanced;
using Synovian_Character_Maker.CharacterCalculator;

namespace Synovian_Character_Maker
{
    static class Program
    {
        static bool openAbilityMaker = false;
        static bool deleteGoogleFolderOnClose = true;

        enum LoadAbilitiesMethod
        {
            Json,
            SQL
        };

        static LoadAbilitiesMethod loadAbilitiesMethod = LoadAbilitiesMethod.SQL;

        /// <summary>
        /// Main library for all registered abilities.
        /// </summary>
        static public AbilityLibrary abilityLibrary = null;

        /// <summary>
        /// Main library for all registered abilities.
        /// </summary>
        static public CharacterLibrary characterLibrary { get; private set; }

        /// <summary>
        /// Main Value container that determines what each rank equates for values such as skillpoints, 
        /// health, schools, etc.
        /// </summary>
        static public StatRules _statRules = null;

        /// <summary>
        /// Main settings class for the program's settings.
        /// </summary>
        static public ProgramSettings programSettings = null;

        /// <summary>
        /// Main Audio player that runs in the background as program runs.
        /// </summary>
        static public AudioPlayer audioPlayer { get; private set; }
        static private string defaultSong = "AFriendAudio.wav";

        /// <summary>
        /// Main Excel Class responsible for exporting and importing excel character sheets.
        /// </summary>
        static public ExcelManager excelManager { get; private set; }

        /// <summary>
        /// Main Calculator class responsible for calculating character sheets.
        /// </summary>
        static public Calculator calculator { get; private set; }


        static public string[] programArgs
        {
            get => _programArgs;
        }
        static private string[] _programArgs;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

#if DEBUG
            List<string> argList = args.ToList();

            argList.Add("-TCN");

            args = argList.ToArray();
#endif

            try
            {
                programSettings = new ProgramSettings();
                DataReader.ReadSettings(ref programSettings);

                _statRules = new StatRules();
                DataReader.ReadStatRules(ref _statRules);

                abilityLibrary = new AbilityLibrary();

                switch (loadAbilitiesMethod)
                {
                    case LoadAbilitiesMethod.Json:
                        {
                            DataReader.ReadAbilities(ref abilityLibrary);
                            break;
                        }
                    case LoadAbilitiesMethod.SQL:
                        {
                            SQL.ImportLibrary(ref abilityLibrary);
                            break;
                        }
                }
                            
                excelManager = new ExcelManager(ref abilityLibrary, ref _statRules);

                characterLibrary = new CharacterLibrary(excelManager);
                DataReader.ReadAllSheets();

                audioPlayer = new AudioPlayer(defaultSong, ref programSettings);
                DataReader.LoadAudioSettings();

                calculator = new Calculator(ref _statRules, ref abilityLibrary);

                _programArgs = args;

                if(args.Contains("-ability_maker") || openAbilityMaker == true)
                {
                    Application.Run(new AbilityMakerV2());
                    SQL.ExportLibrary(ref abilityLibrary);
                }
                else
                    Application.Run(new MainForm());

                characterLibrary.ExportSheets();
                DataWriter.ExportSettings(ref programSettings);
                //DataWriter.ExportStatRules(_statRules);
                if (deleteGoogleFolderOnClose)
                    Networking.GoogleDriveManager.WipeGoogleFolderOnDisk();
                if (Directory.Exists(Globals.TempFolder))
                    Directory.Delete(Globals.TempFolder);
            }
            catch(Exception e) { Helpers.ExceptionHandle(e); }
        }

        // Grabs the currently opened character sheet from the maker.
        public static CharacterSheet GetOpenedSheet()
        {
            return Static_Classes.Helpers.GetForm<Forms.CharacterMaker.CharacterMaker>().current_characterSheet;
        }
    }
}
