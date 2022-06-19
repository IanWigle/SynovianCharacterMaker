namespace Synovian_Character_Maker.DataClasses.Instanced
{
    public struct ZipExportSettings
    {
        public bool savePicture;
        public bool saveExcel;
        public bool saveCompExcelSeperate;

        public ZipExportSettings(bool option1, bool option2, bool option3)
        {
            savePicture = option1;
            saveExcel = option2;
            saveCompExcelSeperate = option3;
        }
    }
}