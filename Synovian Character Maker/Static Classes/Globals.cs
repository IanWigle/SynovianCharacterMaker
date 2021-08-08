using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Synovian_Character_Maker.Static_Classes
{
    static class Globals
    {
        public static string StringNameTable { get => $"{Directory.GetCurrentDirectory()}\\Data\\StringNameTable.txt"; }
        public static string StringDescriptionTable { get => $"{Directory.GetCurrentDirectory()}\\Data\\StringDescriptionTable.txt"; }
        public static string AbilityTable { get => $"{Directory.GetCurrentDirectory()}\\Data\\AbilityTable.txt"; }
        public static string DataFolder { get => $"{Directory.GetCurrentDirectory()}\\Data"; }
        public static string AssetFolder { get => $"{Directory.GetCurrentDirectory()}\\Assets"; }
        public static string CharacterFolder { get => $"{Directory.GetCurrentDirectory()}\\Sheets"; }
        public static string TempFolder { get => $"{Directory.GetCurrentDirectory()}\\Temp"; }
        public static string AudioFolder { get => $"{DataFolder}\\Audio"; }
        public static string PreviewDefault { get => $"{DataFolder}\\Assets\\Preview.bmp"; }
        public static string GoogleDownloads { get => $"{Directory.GetCurrentDirectory()}\\GoogleDownloads"; }
    }
}
