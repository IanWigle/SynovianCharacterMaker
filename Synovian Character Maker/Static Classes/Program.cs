using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Synovian_Character_Maker.Forms;
using Synovian_Character_Maker.Static_Classes;
using Synovian_Character_Maker.Data_Classes;

namespace Synovian_Character_Maker
{
    static class Program
    {
        static bool openAbilityMaker = false;

        /// <summary>
        /// A flag that signifies whether the program is closing. Returns true if closing.
        /// </summary>
        static public bool isClosing
        {
            get => _isClosing;
        }
        static private bool _isClosing = false;

        /// <summary>
        /// Main library for all registered abilities.
        /// </summary>
        static public AbilityLibrary abilityLibrary { get => _abilityLibrary; }
        static private AbilityLibrary _abilityLibrary = null;

        /// <summary>
        /// Main library for all registered abilities.
        /// </summary>
        static public CharacterLibrary characterLibrary { get => _characterLibrary; }
        static private CharacterLibrary _characterLibrary = null;

        /// <summary>
        /// Main Value container that determines what each rank equates for values such as skillpoints, 
        /// health, schools, etc.
        /// </summary>
        static public StatRules statRules { get => _statRules; }
        static private StatRules _statRules = null;

        /// <summary>
        /// Main settings class for the program's settings.
        /// </summary>
        static public ProgramSettings programSettings { get => _programSettings; }
        static private ProgramSettings _programSettings = null;

        static public AudioPlayer audioPlayer { get => _audioPlayer; }
        static private AudioPlayer _audioPlayer = null;
        static private string defaultSong = "AFriendAudio.wav";

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
            //argList.Add("-Google");

            args = argList.ToArray();
#endif

            try
            {
                _programSettings = new ProgramSettings();
                DataReader.ReadSettings(ref _programSettings);

                _statRules = new StatRules();
                DataReader.ReadStatRules(ref _statRules);

                _abilityLibrary = new AbilityLibrary();
                DataReader.ReadAbilities(ref _abilityLibrary);

                _characterLibrary = new CharacterLibrary();
                DataReader.ReadAllSheets(ref _characterLibrary);

                _audioPlayer = new AudioPlayer(defaultSong);
                DataReader.LoadAudioSettings(ref _audioPlayer);

                _programArgs = args;

                if(args.Contains("-ability_maker") || openAbilityMaker == true)
                    Application.Run(new AbilityMaker());
                else
                    Application.Run(new MainForm());

                _isClosing = true;
                _characterLibrary.ExportSheets();
            }
            catch(Exception e) { Helpers.ExceptionHandle(e); }
        }

        public static CharacterSheet GetOpenedSheet()
        {
            return Static_Classes.Helpers.GetForm<Forms.CharacterMaker.CharacterMaker>().current_characterSheet;
        }
    }
}
