using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using SpreadsheetLight;

using Synovian_Character_Maker.Data_Classes;

namespace Synovian_Character_Maker.Static_Classes
{
    public class ExcelManager
    {
        public static void ExportSheet(CharacterSheet characterSheet, string url)
        {
            if (url == "") url = $"{Globals.CharacterFolder}\\{characterSheet.Name}.xlsx";

            string filename = url.Split('\\')[url.Split('\\').Length - 1].Split('.')[0];

            SLDocument sLDocument = new SLDocument();
            System.Drawing.Color GREY = System.Drawing.Color.DarkGray;
            System.Drawing.Color BLACK = System.Drawing.Color.Black;
            System.Drawing.Color PURPLE = System.Drawing.Color.DarkViolet;
            System.Drawing.Color RED = System.Drawing.Color.Red;

            sLDocument.RenameWorksheet(SLDocument.DefaultFirstSheetName, characterSheet.Name);

            void MergeCells(string range)
            {
                sLDocument.MergeWorksheetCells(range.Split(':')[0], range.Split(':')[1]);
            }

            void BoldCell(string cell)
            {
                if (cell.Contains(':'))
                {
                    string originCell = cell.Split(':')[0];
                    string endCell = cell.Split(':')[1];

                    string s_originColumn = Regex.Replace(originCell, @"[\d-]", string.Empty);
                    int i_originColumn = char.ToUpper(s_originColumn.ToCharArray()[0]) - 64;
                    int i_originRow = int.Parse(Regex.Replace(originCell, "[^0-9]", ""));

                    string s_endColumn = Regex.Replace(endCell, @"[\d-]", string.Empty);
                    int i_endColumn = char.ToUpper(s_endColumn.ToCharArray()[0]) - 63;
                    int i_endRow = int.Parse(Regex.Replace(originCell, "[^0-9]", ""));

                    int currentRow = i_originRow;
                    do
                    {
                        int currentCol = i_originColumn;
                        do
                        {
                            SLStyle sLStyle = sLDocument.GetCellStyle(currentRow, currentCol);

                            sLStyle.SetFontBold(true);

                            sLDocument.SetCellStyle(currentRow, currentCol, sLStyle);

                            currentCol++;
                        } while (currentCol < i_endColumn);
                        currentRow++;
                    } while (currentRow < i_endRow);
                }
                else
                {
                    SLStyle sLStyle = sLDocument.GetCellStyle(cell);
                    sLStyle.SetFontBold(true);
                    sLDocument.SetCellStyle(cell, sLStyle);
                }
            }

            void WriteCell(string cell, string data)
            {
                sLDocument.SetCellValue(cell, data);
            }

            void SetCellBackgroundColor(string cell, System.Drawing.Color color)
            {
                if (cell.Contains(':'))
                {
                    string originCell = cell.Split(':')[0];
                    string endCell = cell.Split(':')[1];

                    string s_originColumn = Regex.Replace(originCell, @"[\d-]", string.Empty);
                    int i_originColumn = char.ToUpper(s_originColumn.ToCharArray()[0]) - 64;
                    int i_originRow = int.Parse(Regex.Replace(originCell, "[^0-9]", ""));

                    string s_endColumn = Regex.Replace(endCell, @"[\d-]", string.Empty);
                    int i_endColumn = char.ToUpper(s_endColumn.ToCharArray()[0]) - 63;
                    int i_endRow = int.Parse(Regex.Replace(originCell, "[^0-9]", ""));

                    int currentRow = i_originRow;
                    do
                    {
                        int currentCol = i_originColumn;
                        do
                        {
                            SLStyle sLStyle = sLDocument.GetCellStyle(currentRow, currentCol);

                            sLStyle.Fill.SetPatternType(PatternValues.Solid);
                            sLStyle.Fill.SetPatternForegroundColor(color);

                            sLDocument.SetCellStyle(currentRow, currentCol, sLStyle);

                            currentCol++;
                        } while (currentCol < i_endColumn);
                        currentRow++;
                    } while (currentRow < i_endRow);
                }
                else
                {
                    SLStyle sLStyle = sLDocument.GetCellStyle(cell);

                    sLStyle.Fill.SetPatternType(PatternValues.Solid);
                    sLStyle.Fill.SetPatternForegroundColor(color);
                    sLDocument.SetCellStyle(cell, sLStyle);
                }
            }

            void MakeBorder(string cell)
            {
                if (cell.Contains(':'))
                {
                    string originCell = cell.Split(':')[0];
                    string endCell = cell.Split(':')[1];

                    // Remove all numbers
                    string s_originColumn = "";
                    try
                    {
                        s_originColumn = Regex.Replace(originCell, @"[\d-]", "");
                    }
                    catch(Exception e)
                    {
                        s_originColumn = new string(originCell.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
                    }

                    int i_originColumn = char.ToUpper(s_originColumn.ToCharArray()[0]) - 64;
                    int i_originRow = 0;
                    string test1 = Regex.Replace(originCell,"[^0-9]","");
                    i_originRow = int.Parse(test1);

                    string s_endColumn = Regex.Replace(endCell, @"[\d-]", string.Empty);
                    int i_endColumn = char.ToUpper(s_endColumn.ToCharArray()[0]) - 63;
                    int i_endRow = int.Parse(Regex.Replace(originCell, "[^0-9]", ""));

                    int currentRow = i_originRow;
                    do
                    {
                        int currentCol = i_originColumn;
                        do
                        {
                            SLStyle sLStyle = sLDocument.GetCellStyle(currentRow, currentCol);

                            sLStyle.Border.LeftBorder.BorderStyle = BorderStyleValues.Thick;
                            sLStyle.Border.LeftBorder.Color = System.Drawing.Color.Black;

                            sLStyle.Border.BottomBorder.BorderStyle = BorderStyleValues.Thick;
                            sLStyle.Border.BottomBorder.Color = System.Drawing.Color.Black;

                            sLStyle.Border.RightBorder.BorderStyle = BorderStyleValues.Thick;
                            sLStyle.Border.RightBorder.Color = System.Drawing.Color.Black;

                            sLStyle.Border.TopBorder.BorderStyle = BorderStyleValues.Thick;
                            sLStyle.Border.TopBorder.Color = System.Drawing.Color.Black;

                            sLDocument.SetCellStyle(currentRow, currentCol, sLStyle);
                            currentCol++;
                        } while (currentCol < i_endColumn);
                        currentRow++;
                    } while (currentRow < i_endRow);
                }
                else
                {
                    SLStyle sLStyle = sLDocument.GetCellStyle(cell);

                    sLStyle.Border.LeftBorder.BorderStyle = BorderStyleValues.Thick;
                    sLStyle.Border.LeftBorder.Color = System.Drawing.Color.Black;

                    sLStyle.Border.BottomBorder.BorderStyle = BorderStyleValues.Thick;
                    sLStyle.Border.BottomBorder.Color = System.Drawing.Color.Black;

                    sLStyle.Border.RightBorder.BorderStyle = BorderStyleValues.Thick;
                    sLStyle.Border.RightBorder.Color = System.Drawing.Color.Black;

                    sLStyle.Border.TopBorder.BorderStyle = BorderStyleValues.Thick;
                    sLStyle.Border.TopBorder.Color = System.Drawing.Color.Black;
                    sLDocument.SetCellStyle(cell, sLStyle);
                }
            }

            void CenterText(string cell)
            {
                if (cell.Contains(':'))
                {
                    string originCell = cell.Split(':')[0];
                    string endCell = cell.Split(':')[1];

                    string s_originColumn = Regex.Replace(originCell, @"[\d-]", string.Empty);
                    int i_originColumn = char.ToUpper(s_originColumn.ToCharArray()[0]) - 64;
                    int i_originRow = int.Parse(Regex.Replace(originCell, "[^0-9]", ""));

                    string s_endColumn = Regex.Replace(endCell, @"[\d-]", string.Empty);
                    int i_endColumn = char.ToUpper(s_endColumn.ToCharArray()[0]) - 63;
                    int i_endRow = int.Parse(Regex.Replace(originCell, "[^0-9]", ""));

                    int currentRow = i_originRow;
                    do
                    {
                        int currentCol = i_originColumn;
                        do
                        {
                            SLStyle sLStyle = sLDocument.GetCellStyle(currentRow, currentCol);

                            sLStyle.SetVerticalAlignment(VerticalAlignmentValues.Center);
                            sLStyle.SetHorizontalAlignment(HorizontalAlignmentValues.Center);

                            sLDocument.SetCellStyle(currentRow, currentCol, sLStyle);
                            currentCol++;
                        } while (currentCol < i_endColumn);
                        currentRow++;
                    } while (currentRow < i_endRow);
                }
                else
                {
                    SLStyle sLStyle = sLDocument.GetCellStyle(cell);

                    sLStyle.SetVerticalAlignment(VerticalAlignmentValues.Center);
                    sLStyle.SetHorizontalAlignment(HorizontalAlignmentValues.Center);
                    sLDocument.SetCellStyle(cell, sLStyle);
                }
            }

            void WriteComment(string cell,string comment)
            {
                SLComment sLComment = sLDocument.CreateComment();
                sLComment.SetText(comment);
                sLDocument.InsertComment(cell, sLComment);
            }

            void WriteCommentRaw(int row, int col, string comment)
            {
                SLComment sLComment = sLDocument.CreateComment();
                sLComment.SetText(comment);
                sLDocument.InsertComment(row, col, sLComment);
            }

            // Setup Top header of character sheet
            {
                SetCellBackgroundColor("A1", BLACK);
                MergeCells("A1:N1");

                WriteCell("B2", characterSheet.Name);
                BoldCell("B2");
                CenterText("B2");
                MakeBorder("B2:M2");
                SetCellBackgroundColor("B2", GREY);
                MergeCells("B2:M2");

                WriteCell("B3", "Character Information");
                BoldCell("B3");
                CenterText("B3");
                MakeBorder("B3:E3");
                SetCellBackgroundColor("B3", GREY);
                MergeCells("B3:E3");

                WriteCell("F3", "Specialized Trees");
                BoldCell("F3");
                CenterText("F3");
                MakeBorder("F3:I3");
                SetCellBackgroundColor("F3", GREY);
                MergeCells("F3:I3");

                WriteCell("J3", "Saber/Force Forms");
                BoldCell("J3");
                CenterText("J3");
                MakeBorder("J3:M3");
                SetCellBackgroundColor("J3", GREY);
                MergeCells("J3:M3");

                WriteCell("B4", $"Rank: {characterSheet.s_rank}");
                BoldCell("B4");
                CenterText("B4");
                MakeBorder("B4:E4");
                SetCellBackgroundColor("B4", GREY);
                MergeCells("B4:E4");

                WriteCell("B5", $"Alignment: {characterSheet.s_alignment}");
                BoldCell("B5");
                CenterText("B5");
                MakeBorder("B5:E5");
                SetCellBackgroundColor("B5", GREY);
                MergeCells("B5:E5");

                WriteCell("B6", $"Species: {characterSheet.characterSpecies}");
                BoldCell("B6");
                CenterText("B6");
                MakeBorder("B6:E6");
                SetCellBackgroundColor("B6", GREY);
                MergeCells("B6:E6");
            }

            int startingSchoolIndex = 4;
            string[] schools = characterSheet.GetAllSchools();
            foreach(string school in schools)
            {
                if (school == "School Of Forms")
                    continue;

                WriteCell($"F{startingSchoolIndex}", school);
                BoldCell($"F{startingSchoolIndex}");
                CenterText($"F{startingSchoolIndex}");
                MakeBorder($"F{startingSchoolIndex}:I{startingSchoolIndex}");
                SetCellBackgroundColor($"F{startingSchoolIndex}", GREY);
                MergeCells($"F{startingSchoolIndex}:I{startingSchoolIndex}");
                startingSchoolIndex++;
            }

            int startingFormIndex = 4;
            string[] forms = characterSheet.GetAbilitiesOfSchool(Ability_Schools.Ability_Forms);
            string[] validFormNames = { "Niman", "Shii Cho", "Makashi", "Soresu", "Ataru", "Shien/Djem-so", "Juyo",
                                        "Trakata","Saber Staff","Jar'kai","Saber Pike","Force Channel", "Force Affinity", "Force Mastery",
                                        "Force Potency", "Force Mentalism"};
            string[] formLevels = { "Basic", "Intermediate", "Advanced", "Master" };
            List<string> FurthestForms = new List<string>();

            string GetFurthestVersionOfTree(string form)
            {
                string highestLevel = "";

                foreach(string level in formLevels)
                {
                    if (characterSheet.Contains($"{level} {form}"))
                        highestLevel = $"{level} {form}";
                }

                string highestlevelAlt = CheckForMasterVersionOfForm(form);

                highestLevel = (highestlevelAlt == "") ? highestLevel : highestlevelAlt;

                return highestLevel;
            }

            string CheckForMasterVersionOfForm(string form)
            {
                if(form != "Force Mastery")
                {
                    if (characterSheet.Contains($"{form} Mastery"))
                        return $"{form} Mastery";
                }
                else if (form == "Force Mastery")
                {
                    if (characterSheet.Contains("Force Mastery"))
                        return "Force Mastery";
                }

                return "";
            }

            foreach(string form in validFormNames)
            {
                string highestFormName = GetFurthestVersionOfTree(form);
                if (highestFormName == "")
                {
                    highestFormName = CheckForMasterVersionOfForm(form);
                    if (highestFormName == "")
                        continue;
                }
                else FurthestForms.Add(highestFormName);
            }

            foreach(string form in FurthestForms)
            {
                if (form == "School Of Forms") continue;

                WriteCell($"J{startingFormIndex}", form);
                BoldCell($"J{startingFormIndex}");
                CenterText($"J{startingFormIndex}");
                MakeBorder($"J{startingFormIndex}:M{startingFormIndex}");
                SetCellBackgroundColor($"J{startingFormIndex}", PURPLE);
                MergeCells($"J{startingFormIndex}:M{startingFormIndex}");
                startingFormIndex++;
            }

            int currentLowestIndex = (startingSchoolIndex > startingFormIndex) ? startingSchoolIndex : startingFormIndex;
            if (currentLowestIndex <= 6) currentLowestIndex = 7;

            SetCellBackgroundColor($"A{currentLowestIndex}", BLACK);
            MergeCells($"A{currentLowestIndex}:N{currentLowestIndex}");

            int columnIndex = currentLowestIndex - 1;

            SetCellBackgroundColor("A2", BLACK);
            MergeCells($"A2:A{columnIndex}");

            SetCellBackgroundColor("N2", BLACK);
            MergeCells($"N2:N{columnIndex}");

            currentLowestIndex++;

            WriteCell($"B{currentLowestIndex}", "Known Abilities");
            BoldCell($"B{currentLowestIndex}");
            CenterText($"B{currentLowestIndex}");
            SetCellBackgroundColor($"B{currentLowestIndex}", GREY);
            MakeBorder($"B{currentLowestIndex}:M{currentLowestIndex}");
            MergeCells($"B{currentLowestIndex}:M{currentLowestIndex}");

            SetCellBackgroundColor($"A{currentLowestIndex}", BLACK);
            SetCellBackgroundColor($"N{currentLowestIndex}", BLACK);

            currentLowestIndex++;

            const int maxColumns = 3;
            int currentColumn = 0;

            int currentLeftColumnIndex = currentLowestIndex;
            int currentCenterColumnIndex = currentLowestIndex;
            int currentRightColumnIndex = currentLowestIndex;
            int largestColumnIndex = currentLowestIndex;

            System.Drawing.Color DetermineAbilityColor(Ability_Alignment ability_Alignment)
            {
                switch (ability_Alignment)
                {
                    case Ability_Alignment.Ability_Dark:
                        return System.Drawing.Color.IndianRed;
                    case Ability_Alignment.Ability_Light:
                        return System.Drawing.Color.LightSkyBlue;
                    case Ability_Alignment.Ability_Neutral:
                        return System.Drawing.Color.Violet;
                    case Ability_Alignment.Ability_NonForce:
                        return System.Drawing.Color.PaleTurquoise;
                    default:
                        return System.Drawing.Color.White;
                }
            }

            void SetupLeftColumn(Ability_Schools ability_Schools, ref string[] abilities, ref string[] comments)
            {
                WriteCell($"B{currentLeftColumnIndex}", $"{Enum.GetName(typeof(Ability_Schools), ability_Schools).Replace("Ability_", "")} Abilities");
                BoldCell($"B{currentLeftColumnIndex}");
                CenterText($"B{currentLeftColumnIndex}");
                SetCellBackgroundColor($"B{currentLeftColumnIndex}", GREY);
                MakeBorder($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");
                MergeCells($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");

                WriteCell($"E{currentLeftColumnIndex}", "Status");
                BoldCell($"E{currentLeftColumnIndex}");
                CenterText($"E{currentLeftColumnIndex}");
                MakeBorder($"E{currentLeftColumnIndex}");
                SetCellBackgroundColor($"E{currentLeftColumnIndex}", GREY);
                currentLeftColumnIndex++;

                int l = 0;
                foreach(string ability in abilities)
                {
                    if (Program.abilityLibrary.IsASchool(ability))
                    {
                        l++;
                        continue;
                    }
                    WriteCell($"B{currentLeftColumnIndex}", ability);
                    SetCellBackgroundColor($"B{currentLeftColumnIndex}", DetermineAbilityColor(Program.abilityLibrary.GetAbility(ability).alignment));
                    MakeBorder($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");
                    WriteComment($"B{currentLeftColumnIndex}", comments[l]);
                    MergeCells($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");
                    currentLeftColumnIndex++;
                    l++;
                }
                if (largestColumnIndex <= currentLeftColumnIndex) largestColumnIndex = currentLeftColumnIndex;
            }

            void SetupCenterColumn(Ability_Schools ability_Schools, ref string[] abilities, ref string[] comments)
            {
                WriteCell($"F{currentCenterColumnIndex}", $"{Enum.GetName(typeof(Ability_Schools), ability_Schools).Replace("Ability_", "")} Abilities");
                BoldCell($"F{currentCenterColumnIndex}");
                CenterText($"F{currentCenterColumnIndex}");
                SetCellBackgroundColor($"F{currentCenterColumnIndex}", GREY);
                MakeBorder($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");
                MergeCells($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");

                WriteCell($"I{currentCenterColumnIndex}", "Status");
                BoldCell($"I{currentCenterColumnIndex}");
                CenterText($"I{currentCenterColumnIndex}");
                MakeBorder($"I{currentCenterColumnIndex}");
                SetCellBackgroundColor($"I{currentCenterColumnIndex}", GREY);
                currentCenterColumnIndex++;

                int c = 0;
                foreach (string ability in abilities)
                {
                    if (Program.abilityLibrary.IsASchool(ability))
                    {
                        c++;
                        continue;
                    }
                    WriteCell($"F{currentCenterColumnIndex}", ability);
                    SetCellBackgroundColor($"F{currentCenterColumnIndex}", DetermineAbilityColor(Program.abilityLibrary.GetAbility(ability).alignment));
                    MakeBorder($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");
                    WriteComment($"F{currentLeftColumnIndex}",comments[c]);
                    MergeCells($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");
                    currentCenterColumnIndex++;
                    c++; // good pun
                }
                if (largestColumnIndex <= currentCenterColumnIndex) largestColumnIndex = currentCenterColumnIndex;
            }

            void SetupRightColumn(Ability_Schools ability_Schools, ref string[] abilities, ref string[] comments)
            {
                WriteCell($"J{currentRightColumnIndex}", $"{Enum.GetName(typeof(Ability_Schools), ability_Schools).Replace("Ability_", "")} Abilities");
                BoldCell($"J{currentRightColumnIndex}");
                CenterText($"J{currentRightColumnIndex}");
                SetCellBackgroundColor($"J{currentRightColumnIndex}", GREY);
                MakeBorder($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");
                MergeCells($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");

                WriteCell($"M{currentRightColumnIndex}", "Status");
                BoldCell($"M{currentRightColumnIndex}");
                CenterText($"M{currentRightColumnIndex}");
                MakeBorder($"M{currentRightColumnIndex}");
                SetCellBackgroundColor($"M{currentRightColumnIndex}", GREY);
                currentRightColumnIndex++;

                int r = 0;
                foreach (string ability in abilities)
                {
                    if (Program.abilityLibrary.IsASchool(ability))
                    {
                        r++;
                        continue;
                    }
                    WriteCell($"J{currentRightColumnIndex}", ability);
                    SetCellBackgroundColor($"J{currentRightColumnIndex}", DetermineAbilityColor(Program.abilityLibrary.GetAbility(ability).alignment));
                    MakeBorder($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");
                    WriteComment($"J{currentRightColumnIndex}", comments[r]);
                    MergeCells($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");
                    currentRightColumnIndex++;
                    r++;
                }
                if (largestColumnIndex <= currentRightColumnIndex) largestColumnIndex = currentRightColumnIndex;
            }

            foreach(Ability_Schools ability_Schools in (Ability_Schools[])Enum.GetValues(typeof(Ability_Schools)))
            {
                if (ability_Schools == 0 || ability_Schools == Ability_Schools.Ability_Max) continue;
                if (ability_Schools == Ability_Schools.Ability_Forms) continue;
                string[] abilities = characterSheet.GetAbilitiesOfSchool(ability_Schools);
                string[] comments = characterSheet.GetAllDescriptionsBySchool(ability_Schools);
                if (abilities.Count() == 0) continue;

                switch (currentColumn)
                {
                    case 0:
                        SetupLeftColumn(ability_Schools, ref abilities, ref comments);
                        break;
                    case 1:
                        SetupCenterColumn(ability_Schools, ref abilities, ref comments);
                        break;
                    case 2:
                        SetupRightColumn(ability_Schools, ref abilities, ref comments);
                        break;
                }
                currentColumn++;
                if (currentColumn >= maxColumns) currentColumn = 0;
            }

            if(largestColumnIndex != currentLeftColumnIndex)
            {
                for(int l = currentLeftColumnIndex; l < largestColumnIndex; l++)
                {
                    CenterText($"B{l}");
                    SetCellBackgroundColor($"B{l}",BLACK);
                    MergeCells($"B{l}:E{l}");
                }
            }
            if (largestColumnIndex != currentCenterColumnIndex)
            {
                for(int c = currentCenterColumnIndex; c < largestColumnIndex; c++)
                {
                    CenterText($"F{c}");
                    SetCellBackgroundColor($"F{c}", BLACK);
                    MergeCells($"F{c}:I{c}");
                }
            }
            if(largestColumnIndex != currentRightColumnIndex)
            {
                for(int r= currentRightColumnIndex; r < largestColumnIndex; r++)
                {
                    CenterText($"J{r}");
                    SetCellBackgroundColor($"J{r}", BLACK);
                    MergeCells($"J{r}:M{r}");
                }
            }

            SetCellBackgroundColor($"A{largestColumnIndex}", BLACK);
            MergeCells($"A{largestColumnIndex}:N{largestColumnIndex}");

            SetCellBackgroundColor($"A{currentLowestIndex}", BLACK);
            MergeCells($"A{currentLowestIndex}:A{largestColumnIndex - 1}");

            SetCellBackgroundColor($"N{currentLowestIndex}", BLACK);
            MergeCells($"N{currentLowestIndex}:N{largestColumnIndex - 1}");

            // If character has a companion, make a new sheet for it.
            if(characterSheet.companionSheet != null)
            {
                sLDocument.AddWorksheet("Companion");
                if(characterSheet.companionSheet.primaryCompanionType == CompanionSheet.CompanionType.Beast)
                {
                    WriteCell("A1", $"Companion Name : {characterSheet.companionSheet.companionName}");
                    MergeCells("A1:D1");

                    WriteCell("A2", $"Beast Race : {characterSheet.companionSheet.companionSpecies}");
                    MergeCells("A2:D2");

                    WriteCell("A3", $"Companion History : {characterSheet.companionSheet.companionHistory}");

                    SLStyle sLStyle = new SLStyle();
                    sLStyle.SetWrapText(true);
                    sLStyle.SetVerticalAlignment(VerticalAlignmentValues.Top);

                    sLDocument.SetCellStyle("A3", sLStyle);
                    MergeCells("A3:G6");

                    if(characterSheet.companionSheet._image != null)
                    {
                        var ms = new MemoryStream();
                        characterSheet.companionSheet._image.Save(ms, characterSheet.companionSheet._image.RawFormat);
                    
                        SpreadsheetLight.Drawing.SLPicture picture = new SpreadsheetLight.Drawing.SLPicture(ms.ToArray(), DocumentFormat.OpenXml.Packaging.ImagePartType.Jpeg);
                        picture.SetPosition(8, 1);
                        picture.ResizeInPercentage(10, 10);
                    
                        sLDocument.InsertPicture(picture);
                    }
                }
                else if (characterSheet.companionSheet.primaryCompanionType >= CompanionSheet.CompanionType.Research_Droid)
                {
                    WriteCell("A1", $"Compaion Name : {characterSheet.companionSheet.companionName}");
                    MergeCells("A1:D1");

                    WriteCell("A2", $"Droid Type : {characterSheet.companionSheet.primaryCompanionType}");
                    MergeCells("A2:D2");

                    WriteCell("A3", $"Companion History : {characterSheet.companionSheet.companionHistory}");

                    SLStyle sLStyle = new SLStyle();
                    sLStyle.SetWrapText(true);
                    sLStyle.SetVerticalAlignment(VerticalAlignmentValues.Top);

                    sLDocument.SetCellStyle("A3",sLStyle);
                    MergeCells("A3:L6");

                    WriteCell("A8", "Abilities");
                    MergeCells("A8:D8");

                    WriteCell("A9", "Name");
                    MergeCells("A9:D9");

                    WriteCell("E9", "Description");
                    MergeCells("E9:H9");

                    WriteCell("I9","Droid Type");
                    MergeCells("I9:L9");

                    int currentRow = 10;

                    foreach(int ability in characterSheet.companionSheet.abilities)
                    {
                        if(Program.abilityLibrary.TryGetAbility(ability, out Ability ability1))
                        {
                            WriteCell($"A{currentRow}", ability1.Name);
                            MergeCells($"A{currentRow}:D{currentRow}");

                            WriteCell($"E{currentRow}", ability1.description);
                            MergeCells($"E{currentRow}:H{currentRow}");

                            WriteCell($"I{currentRow}", ability1.s_prereqs[0]);
                            MergeCells($"I{currentRow}:L{currentRow}");

                            currentRow++;
                        }
                    }

                    if (characterSheet.companionSheet._image != null)
                    {
                        var ms = new MemoryStream();
                        characterSheet.companionSheet._image.Save(ms, characterSheet.companionSheet._image.RawFormat);

                        SpreadsheetLight.Drawing.SLPicture picture = new SpreadsheetLight.Drawing.SLPicture(ms.ToArray(), DocumentFormat.OpenXml.Packaging.ImagePartType.Jpeg);
                        picture.SetPosition((currentRow + 2), 1);
                        picture.ResizeInPercentage(10, 10);

                        sLDocument.InsertPicture(picture);
                    }
                }
            }

            // Create metadata sheet
            {
                sLDocument.AddWorksheet("CharacterMakerData");
                WriteCell("A1", "This sheet is used for the charactermaker. If you want to load this sheet into the maker, keep this data in this sheet");
                SLStyle newstyle = new SLStyle();
                newstyle.SetVerticalAlignment(VerticalAlignmentValues.Top);
                newstyle.SetWrapText(true);
                sLDocument.SetCellStyle("A1", newstyle);

                MergeCells("A1:I3");

                string prereqFormsString = "";

                string[] allformabilities = characterSheet.GetAbilitiesOfSchool(Ability_Schools.Ability_Forms);
                foreach (string formAbility in allformabilities)
                {
                    if (FurthestForms.Contains(formAbility))
                        continue;
                    else
                    {
                        if (Program.abilityLibrary.TryGetAbility(formAbility, out Ability ability))
                        {
                            prereqFormsString += $"{ability.ID},";
                        }
                    }
                }

                WriteCell("A4", prereqFormsString);
            }            

            sLDocument.SelectWorksheet(characterSheet.Name);
            sLDocument.SaveAs(url);

            try
            {
                if (Directory.Exists(@"C:\Program Files (x86)\Microsoft Office\root\Office16") && File.Exists(@"C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.EXE")
                    && Program.isClosing == false)
                {
                    if (MessageBox.Show("Would you like to Open Excel?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    Process.Start(@url);
                }
            }
            catch (Exception e) { Helpers.ExceptionHandle(e); }          
        }

        public static CharacterSheet ImportSheet(string url)
        {
            if (!File.Exists(url))
                return null;

            SLDocument sl = new SLDocument(url);

            string name = sl.GetCellValueAsString("B2");
            string characterDescription = "";
            string characterSpecies = sl.GetCellValueAsString("B6").Replace("Species: ", "");
            Rank rank = Rank.Invalid;
            Ability_Alignment ability_Alignment = Ability_Alignment.Ability_Invalid;
            List<int> abilities = new List<int>();

            string s_rank = sl.GetCellValueAsString("B4").Replace("Rank: ", "");
            foreach(Rank _rank in Enum.GetValues(typeof(Rank)))
            {
                if(Enum.GetName(typeof(Rank),_rank) == s_rank)
                {
                    rank = _rank;
                    break;
                }
            }

            string s_alignment = sl.GetCellValueAsString("B5").Replace("Alignment: ", "Ability_");
            foreach(Ability_Alignment _alignment in Enum.GetValues(typeof(Ability_Alignment)))
            {
                if(Enum.GetName(typeof(Ability_Alignment),_alignment) == s_alignment)
                {
                    ability_Alignment = _alignment;
                    break;
                }
            }

            //Skip value incase the sheet is missing schools or forms
            int skipVal = 0;

            // Get all schools
            int s_s_i = 4;
            do
            {
                if (sl.GetCellValueAsString($"F{s_s_i}") == "")
                {
                    skipVal++;
                    break;
                }
                else
                {
                    string s_school_name = sl.GetCellValueAsString($"F{s_s_i}");

                    if(Program.abilityLibrary.TryGetAbility(s_school_name,out Ability ability))
                    {
                        abilities.Add(ability.ID);
                        s_s_i++;
                    }
                    else
                    {
                        break;
                    }
                }
            } while (true);

            // Get all forms
            int s_f_i = 4;
            do
            {
                if (sl.GetCellValueAsString($"J{s_f_i}") == "")
                {
                    skipVal++;
                    break;
                }
                else
                {
                    string s_form_name = sl.GetCellValueAsString($"J{s_f_i}");

                    if(Program.abilityLibrary.TryGetAbility(s_form_name, out Ability ability))
                    {
                        abilities.Add(ability.ID);
                        s_f_i++;
                    }
                    else
                    {
                        break;
                    }
                }
            } while (true);

            skipVal = (skipVal == 2) ? skipVal + 1 : skipVal;

            int s_ability_name = (s_s_i > s_f_i) ? s_s_i : s_f_i;
            s_ability_name += skipVal;
            if (sl.GetCellValueAsString($"B{s_ability_name}") == "") s_ability_name += 3;
            int starting_name_value = s_ability_name;


            // Read all abilities
            // Start with left column
            do
            {
                // Ignore abilitiy column headers.
                if (sl.GetCellValueAsString($"B{s_ability_name}").Contains("Abilities"))
                {
                    s_ability_name++;
                    continue;
                }
                else
                {
                    if(Program.abilityLibrary.TryGetAbility(sl.GetCellValueAsString($"B{s_ability_name}"), out Ability ability))
                    {
                        abilities.Add(ability.ID);
                        s_ability_name++;
                    }
                    else
                    {
                        break;
                    }
                }
            } while (true);
            // Do center column
            s_ability_name = starting_name_value;
            do
            {
                if (sl.GetCellValueAsString($"F{s_ability_name}").Contains("Abilities"))
                {
                    s_ability_name++;
                    continue;
                }
                else
                {
                    if (Program.abilityLibrary.TryGetAbility(sl.GetCellValueAsString($"F{s_ability_name}"), out Ability ability))
                    {
                        abilities.Add(ability.ID);
                        s_ability_name++;
                    }
                    else
                    {
                        break;
                    }
                }
            } while (true);
            // Do Rightside column
            s_ability_name = starting_name_value;
            do
            {
                if (sl.GetCellValueAsString($"J{s_ability_name}").Contains("Abilities"))
                {
                    s_ability_name++;
                    continue;
                }
                else
                {
                    if (Program.abilityLibrary.TryGetAbility(sl.GetCellValueAsString($"J{s_ability_name}"), out Ability ability))
                    {
                        abilities.Add(ability.ID);
                        s_ability_name++;
                    }
                    else
                    {
                        break;
                    }
                }
            } while (true);

            if(sl.SelectWorksheet("CharacterMakerData") == true)
            {
                string otherFormIDs = sl.GetCellValueAsString("A4");
                string[] ids = otherFormIDs.Split(',');
                foreach(string id in ids)
                {
                    if (id == "")
                        break;
                    // If the ability library contains the ability id AND the loaded list of abilities does NOT contain the id already
                    if(Program.abilityLibrary.Contains(int.Parse(id)) && !abilities.Contains(int.Parse(id)))
                    {
                        abilities.Add(int.Parse(id));
                    }
                }
            }

            CompanionSheet companionSheet = null;
            if(sl.SelectWorksheet("Companion") == true)
            {
                string compName = sl.GetCellValueAsString("A1");
                if (compName.Contains("Companion Name : ")) compName = compName.Remove(0, 17);

                string compTypeStr = sl.GetCellValueAsString("A2"); 
                string compHistory = "";
                
                Image compImage = null;
                List<int> compAbil = new List<int>();
                List<CompanionSheet.CompanionType> subTypes = new List<CompanionSheet.CompanionType>();
                CompanionSheet.CompanionType compType = CompanionSheet.CompanionType.None;

                if(compTypeStr.Contains("Beast Race : "))
                {
                    compTypeStr = compTypeStr.Split(':')[1].Remove(0, 1);
                    compType = CompanionSheet.CompanionType.Beast;
                }
                else if (compTypeStr.Contains("Droid Type : "))
                {
                    compTypeStr = compTypeStr.Remove(0, 13);
                }
                else
                {
                    MessageBox.Show($"There was a problem reading the companion worksheet for the character {name}. The companion is not loaded", 
                                    "Error!", 
                                    MessageBoxButtons.OK, 
                                    MessageBoxIcon.Error);
                }

                compHistory = sl.GetCellValueAsString("A3").Split(':')[1].Remove(0, 1);

                if (compType != CompanionSheet.CompanionType.Beast)
                {
                    for (int i = 0; i < (int)CompanionSheet.CompanionType.Max; i++)
                    {
                        if (compTypeStr == Enum.GetName(typeof(CompanionSheet.CompanionType), i))
                            compType = (CompanionSheet.CompanionType)i;
                    }
                }

                companionSheet = new CompanionSheet(compName, compType, subTypes, compAbil);
                companionSheet.SetCompanionHistory(compHistory);
                companionSheet.SetCompanionSpecies(compTypeStr);
                companionSheet._image = compImage;
            }

            CharacterSheet characterSheet = new CharacterSheet(name, 
                                                               rank, 
                                                               ability_Alignment, 
                                                               abilities, 
                                                               "", 
                                                               null, 
                                                               characterSpecies, 
                                                               CharacterSheet.SheetFileType.XlSx);
            characterSheet.companionSheet = companionSheet;

            return characterSheet;
        }
    }
}
