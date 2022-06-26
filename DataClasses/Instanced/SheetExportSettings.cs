namespace Synovian_Character_Maker.DataClasses.Instanced
{
    public struct SheetExportSettings
    {
        public enum SortType
        {
            None = 0,
            Alphabetical,
            Rank,
            Alignment
        }

        public SortType sortType { get; set; }
        public bool seperateSheetsPerCompanion { get; set; }
        public string sheetNameOverride { get; set; }

        public SheetExportSettings(SortType sortType, bool seperateSheetsPerCompanion, string sheetNameOverride)
        {
            this.sortType = sortType;
            this.seperateSheetsPerCompanion = seperateSheetsPerCompanion;
            this.sheetNameOverride = sheetNameOverride;
        }
    }
}