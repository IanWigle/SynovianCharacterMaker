using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;

using SpreadsheetLight;

using Synovian_Character_Maker.DataClasses.Instanced;

namespace Synovian_Character_Maker.DataClasses.Static
{
	public class ExcelManager
	{
		AbilityLibrary AbilityLibraryRef;
		StatRules StatRulesRef;

		public ExcelManager(ref AbilityLibrary libraryRef, ref StatRules rules)
		{
			AbilityLibraryRef = libraryRef;
			StatRulesRef = rules;
		}

		public void ExportSheet(CharacterSheet characterSheet, string url, SheetExportSettings sheetExportSettings)
		{
			// Setup the url to be the name of the character if no url is provided.
			if (url == "") url = $"{Globals.CharacterFolder}\\{characterSheet.Name}.xlsx";

			// Setup filename to be the name from the url without the extension.
			string filename = url.Split('\\')[url.Split('\\').Length - 1].Split('.')[0];

			// Create the document container.
			SLDocument sLDocument = new SLDocument();
			System.Drawing.Color GREY = System.Drawing.Color.DarkGray;
			System.Drawing.Color BLACK = System.Drawing.Color.Black;
			System.Drawing.Color PURPLE = System.Drawing.Color.DarkViolet;
			System.Drawing.Color RED = System.Drawing.Color.Red;

			// Rename the first main sheet to the character's name.
			sLDocument.RenameWorksheet(SLDocument.DefaultFirstSheetName, characterSheet.Name);

			// Nested function to easily merge a selection of cells.
			void MergeCells(string range)
			{
				sLDocument.MergeWorksheetCells(range.Split(':')[0], range.Split(':')[1]);
			}

			// Nested function to bolden cell(s)
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

			// Nested function to write data into a specific cell.
			void WriteCell(string cell, string data)
			{
				sLDocument.SetCellValue(cell, data);
			}

			// Nested function sets the background of cell(s) with a specific color.
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

			// Nested function makes an outer border for cell(s)
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
					catch (Exception e)
					{
						s_originColumn = new string(originCell.Where(c => c != '-' && (c < '0' || c > '9')).ToArray());
					}

					int i_originColumn = char.ToUpper(s_originColumn.ToCharArray()[0]) - 64;
					int i_originRow = 0;
					string test1 = Regex.Replace(originCell, "[^0-9]", "");
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

			// Nested function to center text within cell(s)
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

			// Nested function to write a comment into cell(s)
			void WriteComment(string cell, string comment)
			{
				SLComment sLComment = sLDocument.CreateComment();
				sLComment.AutoSize = true;
				sLComment.SetText(comment);
				sLDocument.InsertComment(cell, sLComment);
			}

			// Setup Top header of character sheet
			{
				SetCellBackgroundColor("A1", BLACK);
				MergeCells("A1:N1");

				// Character Name
				WriteCell("B2", characterSheet.Name);
				BoldCell("B2");
				CenterText("B2");
				MakeBorder("B2:M2");
				SetCellBackgroundColor("B2", GREY);
				MergeCells("B2:M2");

				// Character Info header
				WriteCell("B3", "Character Information");
				BoldCell("B3");
				CenterText("B3");
				MakeBorder("B3:E3");
				SetCellBackgroundColor("B3", GREY);
				MergeCells("B3:E3");

				// Trees header
				WriteCell("F3", "Specialized Trees");
				BoldCell("F3");
				CenterText("F3");
				MakeBorder("F3:I3");
				SetCellBackgroundColor("F3", GREY);
				MergeCells("F3:I3");

				// Form header.
				WriteCell("J3", "Saber/Force Forms");
				BoldCell("J3");
				CenterText("J3");
				MakeBorder("J3:M3");
				SetCellBackgroundColor("J3", GREY);
				MergeCells("J3:M3");

				// Character Rank
				WriteCell("B4", $"Rank: {characterSheet.s_rank}");
				BoldCell("B4");
				CenterText("B4");
				MakeBorder("B4:E4");
				SetCellBackgroundColor("B4", GREY);
				MergeCells("B4:E4");

				// Character Alignment
				WriteCell("B5", $"Alignment: {characterSheet.s_alignment}");
				BoldCell("B5");
				CenterText("B5");
				MakeBorder("B5:E5");
				SetCellBackgroundColor("B5", GREY);
				MergeCells("B5:E5");

				// Character Species
				WriteCell("B6", $"Species: {characterSheet.characterSpecies}");
				BoldCell("B6");
				CenterText("B6");
				MakeBorder("B6:E6");
				SetCellBackgroundColor("B6", GREY);
				MergeCells("B6:E6");
			}

			// Setup offset value for offseting top headers from character info and sheet border.
			int startingSchoolIndex = 4;

			// Get all schools the character is in (specialized schools)
			string[] schools = characterSheet.GetAllSchools();

			// Run through array to add each school to character list.
			foreach (string school in schools)
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

			// Setup offset value for form list to offset top headers from character info and sheet border.
			int startingFormIndex = 4;
			// Get all forms the character has.
			string[] forms = characterSheet.GetAbilitiesOfSchool(Ability_Schools.Ability_Forms);
			string[] validFormNames = { "Niman", "Shii Cho", "Makashi", "Soresu", "Ataru", "Shien/Djem-so", "Juyo",
										"Trakata","Saber Staff","Jar'kai","Saber Pike","Force Channel", "Force Affinity", "Force Mastery",
										"Force Potency", "Force Mentalism"};
			string[] formLevels = { "Basic", "Intermediate", "Advanced", "Expert" };
			List<string> FurthestForms = new List<string>();

			// Nested function for finding the most advance version of a form the user has.
			string GetFurthestVersionOfTree(string form)
			{
				string highestLevel = "";

				foreach (string level in formLevels)
				{
					if (characterSheet.Contains($"{level} {form}"))
						highestLevel = $"{level} {form}";
				}

				string highestlevelAlt = CheckForMasterVersionOfForm(form);

				highestLevel = (highestlevelAlt == "") ? highestLevel : highestlevelAlt;

				return highestLevel;
			}

			// Nested function for seperating the ability Force mastery from masteries.
			string CheckForMasterVersionOfForm(string form)
			{
				if (form != "Force Mastery")
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

			// Add the furthest version of each learned form to an array of furthest forms.
			foreach (string form in validFormNames)
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

			// Print out each of the furthest forms into the Saber/Force Forms table.
			foreach (string form in FurthestForms)
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

			// If the starting index is smaller than the school index, fill in all empty space remaining in the school table with black boxes
			if (startingFormIndex < startingSchoolIndex)
			{
				for (int i = 4; i < startingSchoolIndex; i++)
				{
					if (sLDocument.GetCellValueAsString($"J{i}") == "")
					{
						SetCellBackgroundColor($"J{i}", BLACK);
						MergeCells($"J{i}:M{i}");
					}
				}
			}

			// Grab the lowest value between the school and form indices.
			int currentLowestIndex = (startingSchoolIndex > startingFormIndex) ? startingSchoolIndex : startingFormIndex;

			// If the lowest value is below threshold of 6, override to 7.
			if (currentLowestIndex <= 6) currentLowestIndex = 7;

			// Create new black border.
			SetCellBackgroundColor($"A{currentLowestIndex}", BLACK);
			MergeCells($"A{currentLowestIndex}:N{currentLowestIndex}");

			// Setup new index for ability columns.
			int columnIndex = currentLowestIndex - 1;

			// Create new border on the left side.
			SetCellBackgroundColor("A2", BLACK);
			MergeCells($"A2:A{columnIndex}");

			// Create new border on the right side.
			SetCellBackgroundColor("N2", BLACK);
			MergeCells($"N2:N{columnIndex}");

			// increment our lowest index to take new borders into account.
			currentLowestIndex++;

			// Setup Abilities header.
			WriteCell($"B{currentLowestIndex}", "Known Abilities");
			BoldCell($"B{currentLowestIndex}");
			CenterText($"B{currentLowestIndex}");
			SetCellBackgroundColor($"B{currentLowestIndex}", GREY);
			MakeBorder($"B{currentLowestIndex}:M{currentLowestIndex}");
			MergeCells($"B{currentLowestIndex}:M{currentLowestIndex}");

			// Create more border segments for left and right.
			SetCellBackgroundColor($"A{currentLowestIndex}", BLACK);
			SetCellBackgroundColor($"N{currentLowestIndex}", BLACK);

			// Increment lowest index for new borders and headers.
			currentLowestIndex++;

			// Setup maxinum number of columns the sheet will setup.
			const int maxColumns = 3;
			// Track current column being used. 0 = Left, 1 = Center, 2 = Right.
			int currentColumn = 0;

			// Keep track of all cell indices for each column, and the largest column index.
			int currentLeftColumnIndex = currentLowestIndex;
			int currentCenterColumnIndex = currentLowestIndex;
			int currentRightColumnIndex = currentLowestIndex;
			int largestColumnIndex = currentLowestIndex;

			// Nested function to determine which colour to use based on ability alignment.
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

			// Nested function to shorten the string symbol for the mastery/learned level of an ability.
			string ShortenMasteryEnum(Ability_Mastery _Mastery)
			{
				switch (_Mastery)
				{
					case Ability_Mastery.Mastery_NotLearned:
						return "NL";
					case Ability_Mastery.Mastery_Learned:
						return "L";
					case Ability_Mastery.Mastery_Master:
						return "M";
					case Ability_Mastery.Mastery_HeadMaster:
						return "HM";
					default:
						return "";
				}

			}

			// Nested function to setup all abilities of a school on the left side of the sheet.
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

				switch (sheetExportSettings.sortType)
				{
					case SheetExportSettings.SortType.Alphabetical:
						{
							Array.Sort(abilities, StringComparer.InvariantCulture);
							break;
						}
					case SheetExportSettings.SortType.Rank:
						{
							List<string> sortedAbilities = new List<string>();

							foreach (string rank in Enum.GetNames(typeof(Rank)))
							{
								if (rank == "Invalid" || rank == "Initiate") continue;

								foreach (string ability in abilities)
								{
									if (AbilityLibraryRef.GetAbility(ability).Rank.ToString() == rank)
										sortedAbilities.Add(ability);

								}
							}

							abilities = sortedAbilities.ToArray();

							break;
						}
					case SheetExportSettings.SortType.Alignment:
						{
							List<string> sortedAbilities = new List<string>();

							foreach (string align in Enum.GetNames(typeof(Ability_Alignment)))
							{
								if (align == "Ability_Invalid") continue;

								foreach (string ability in abilities)
								{
									if (AbilityLibraryRef.GetAbility(ability).alignment.ToString() == align)
										sortedAbilities.Add(ability);
								}
							}

							abilities = sortedAbilities.ToArray();

							break;
						}
				}

				int l = 0;
				foreach (string ability in abilities)
				{
					if (AbilityLibraryRef.IsASchool(ability))
					{
						l++;
						continue;
					}
					WriteCell($"B{currentLeftColumnIndex}", ability);
					WriteCell($"E{currentLeftColumnIndex}", ShortenMasteryEnum(characterSheet.abilityMasteryDictionary[AbilityLibraryRef.GetAbility(ability).ID]));
					SetCellBackgroundColor($"E{currentLeftColumnIndex}", DetermineAbilityColor(AbilityLibraryRef.GetAbility(ability).alignment));
					MakeBorder($"E{currentLeftColumnIndex}");
					CenterText($"E{currentLeftColumnIndex}");

					SetCellBackgroundColor($"B{currentLeftColumnIndex}", DetermineAbilityColor(AbilityLibraryRef.GetAbility(ability).alignment));
					MakeBorder($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");
					WriteComment($"B{currentLeftColumnIndex}", comments[l]);
					MergeCells($"B{currentLeftColumnIndex}:D{currentLeftColumnIndex}");
					currentLeftColumnIndex++;
					l++;
				}
				if (largestColumnIndex <= currentLeftColumnIndex) largestColumnIndex = currentLeftColumnIndex;
			}

			// Nested function to setup all abilities of a school on the center side of the sheet.
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

				switch (sheetExportSettings.sortType)
				{
					case SheetExportSettings.SortType.Alphabetical:
						{
							Array.Sort(abilities, StringComparer.InvariantCulture);
							break;
						}
					case SheetExportSettings.SortType.Rank:
						{
							List<string> sortedAbilities = new List<string>();

							foreach (string rank in Enum.GetNames(typeof(Rank)))
							{
								if (rank == "Invalid" || rank == "Initiate") continue;

								foreach (string ability in abilities)
								{
									if (AbilityLibraryRef.GetAbility(ability).Rank.ToString() == rank)
										sortedAbilities.Add(ability);
								}
							}

							abilities = sortedAbilities.ToArray();

							break;
						}
					case SheetExportSettings.SortType.Alignment:
						{
							List<string> sortedAbilities = new List<string>();

							foreach (string align in Enum.GetNames(typeof(Ability_Alignment)))
							{
								if (align == "Ability_Invalid") continue;

								foreach (string ability in abilities)
								{
									if (AbilityLibraryRef.GetAbility(ability).alignment.ToString() == align)
										sortedAbilities.Add(ability);
								}
							}

							abilities = sortedAbilities.ToArray();

							break;
						}
				}

				int c = 0;
				foreach (string ability in abilities)
				{
					if (AbilityLibraryRef.IsASchool(ability))
					{
						c++;
						continue;
					}
					WriteCell($"F{currentCenterColumnIndex}", ability);
					WriteCell($"I{currentCenterColumnIndex}", ShortenMasteryEnum(characterSheet.abilityMasteryDictionary[AbilityLibraryRef.GetAbility(ability).ID]));
					SetCellBackgroundColor($"I{currentCenterColumnIndex}", DetermineAbilityColor(AbilityLibraryRef.GetAbility(ability).alignment));
					MakeBorder($"I{currentCenterColumnIndex}");
					CenterText($"I{currentCenterColumnIndex}");
					SetCellBackgroundColor($"F{currentCenterColumnIndex}", DetermineAbilityColor(AbilityLibraryRef.GetAbility(ability).alignment));
					MakeBorder($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");
					WriteComment($"F{currentCenterColumnIndex}", comments[c]);
					MergeCells($"F{currentCenterColumnIndex}:H{currentCenterColumnIndex}");
					currentCenterColumnIndex++;
					c++; // good pun
				}
				if (largestColumnIndex <= currentCenterColumnIndex) largestColumnIndex = currentCenterColumnIndex;
			}

			// Nested function to setup all abilities of a school on the right side of the sheet.
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

				switch (sheetExportSettings.sortType)
				{
					case SheetExportSettings.SortType.Alphabetical:
						{
							Array.Sort(abilities, StringComparer.InvariantCulture);
							break;
						}
					case SheetExportSettings.SortType.Rank:
						{
							List<string> sortedAbilities = new List<string>();

							foreach (string rank in Enum.GetNames(typeof(Rank)))
							{
								if (rank == "Invalid" || rank == "Initiate") continue;

								foreach (string ability in abilities)
								{
									if (AbilityLibraryRef.GetAbility(ability).Rank.ToString() == rank)
										sortedAbilities.Add(ability);
								}
							}

							abilities = sortedAbilities.ToArray();

							break;
						}
					case SheetExportSettings.SortType.Alignment:
						{
							List<string> sortedAbilities = new List<string>();

							foreach (string align in Enum.GetNames(typeof(Ability_Alignment)))
							{
								if (align == "Ability_Invalid") continue;

								foreach (string ability in abilities)
								{
									if (AbilityLibraryRef.GetAbility(ability).alignment.ToString() == align)
										sortedAbilities.Add(ability);
								}
							}

							abilities = sortedAbilities.ToArray();

							break;
						}
				}

				int r = 0;
				foreach (string ability in abilities)
				{
					if (AbilityLibraryRef.IsASchool(ability))
					{
						r++;
						continue;
					}
					WriteCell($"J{currentRightColumnIndex}", ability);
					WriteCell($"M{currentRightColumnIndex}", ShortenMasteryEnum(characterSheet.abilityMasteryDictionary[AbilityLibraryRef.GetAbility(ability).ID]));
					SetCellBackgroundColor($"M{currentRightColumnIndex}", DetermineAbilityColor(AbilityLibraryRef.GetAbility(ability).alignment));
					MakeBorder($"M{currentRightColumnIndex}");
					CenterText($"M{currentRightColumnIndex}");
					SetCellBackgroundColor($"J{currentRightColumnIndex}", DetermineAbilityColor(AbilityLibraryRef.GetAbility(ability).alignment));
					MakeBorder($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");
					WriteComment($"J{currentRightColumnIndex}", comments[r]);
					MergeCells($"J{currentRightColumnIndex}:L{currentRightColumnIndex}");
					currentRightColumnIndex++;
					r++;
				}
				if (largestColumnIndex <= currentRightColumnIndex) largestColumnIndex = currentRightColumnIndex;
			}

			// Loop through each registered school of abilities.
			foreach (Ability_Schools ability_Schools in (Ability_Schools[])Enum.GetValues(typeof(Ability_Schools)))
			{
				// Skip debug school values.
				if (ability_Schools == 0 || ability_Schools == Ability_Schools.Ability_Max) continue;
				// Skip the forms school.
				if (ability_Schools == Ability_Schools.Ability_Forms) continue;

				// Grab all abilities in the character's sheet that is of the looped school.
				string[] abilities = characterSheet.GetAbilitiesOfSchool(ability_Schools);

				// Skip this school if there are no abilities found.
				if (abilities.Count() == 0) continue;

				// Get all string descriptions of all abilities under the looped school.
				string[] comments = characterSheet.GetAllDescriptionsBySchool(ability_Schools);

				// Based on the integer tracking the current column, use the specific nested function that
				// correlates.
				switch (currentColumn)
				{
					// Left
					case 0:
						SetupLeftColumn(ability_Schools, ref abilities, ref comments);
						break;
					// Center
					case 1:
						SetupCenterColumn(ability_Schools, ref abilities, ref comments);
						break;
					// Right
					case 2:
						SetupRightColumn(ability_Schools, ref abilities, ref comments);
						break;
				}
				// Increment the current column for the next school. If we surpass the max columns, reset to 0.
				currentColumn++;
				if (currentColumn >= maxColumns) currentColumn = 0;
			}

			if (largestColumnIndex != currentLeftColumnIndex)
			{
				for (int l = currentLeftColumnIndex; l < largestColumnIndex; l++)
				{
					CenterText($"B{l}");
					SetCellBackgroundColor($"B{l}", BLACK);
					MergeCells($"B{l}:E{l}");
				}
			}
			if (largestColumnIndex != currentCenterColumnIndex)
			{
				for (int c = currentCenterColumnIndex; c < largestColumnIndex; c++)
				{
					CenterText($"F{c}");
					SetCellBackgroundColor($"F{c}", BLACK);
					MergeCells($"F{c}:I{c}");
				}
			}
			if (largestColumnIndex != currentRightColumnIndex)
			{
				for (int r = currentRightColumnIndex; r < largestColumnIndex; r++)
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
			if (characterSheet.companionSheets != null)
			{
				if(sheetExportSettings.seperateSheetsPerCompanion == true)
                {
					foreach(var sheet in characterSheet.companionSheets)
                    {
						sLDocument.AddWorksheet(sheet.companionName);

						WriteCell("A1", $"Name : {sheet.companionName}");
						MergeCells("A1:I1");

						WriteCell("A2", $"Type : {sheet.s_primaryCompanionType}");
						MergeCells("A2:I2");

						int offset = 3;
						if(sheet.primaryCompanionType == CompanionSheet.CompanionType.Beast)
                        {
							WriteCell("A3", $"Beast Race : {sheet.beastSpecies}");
							MergeCells("A3:I3");
							offset++;
                        }

						WriteCell($"A{offset}", "Companion History : ");
						MergeCells($"A{offset}:I{offset + 3}");

						SLStyle compsLStyle = new SLStyle();
						compsLStyle.SetWrapText(true);
						compsLStyle.SetVerticalAlignment(VerticalAlignmentValues.Top);
						sLDocument.SetCellStyle($"A{offset}", compsLStyle);

						offset += 5;

						WriteCell($"A{offset}", "Abilities");
						MergeCells($"A{offset}:I{offset}");
						offset++;

						WriteCell($"A{offset}", "Name :");
						MergeCells($"A{offset}:D{offset}");

						WriteCell($"A{offset}", "Description :");
						MergeCells($"E{offset}:I{offset}");
						offset++;

						foreach(int id in sheet.abilities)
                        {
							WriteCell($"A{offset}", AbilityLibraryRef.GetAbility(id).Name);
							MergeCells($"A{offset}:D{offset}");

							WriteCell($"E{offset}",AbilityLibraryRef.GetAbility(id).description);
							MergeCells($"E{offset}:I{offset}");
							offset++;
                        }
                    }
                }
				else
                {
					sLDocument.AddWorksheet("Companion");

					int indexOffsetter = 1;
					foreach (CompanionSheet sheet in characterSheet.companionSheets)
					{
						// Setup companion name.
						WriteCell($"A{indexOffsetter}", $"Companion Name : {sheet.companionName}");
						MergeCells($"A{indexOffsetter}:I{indexOffsetter}");

						indexOffsetter++;

						// Setup Companion Type
						WriteCell($"A{indexOffsetter}", $"Companion Type : {sheet.s_primaryCompanionType}");
						MergeCells($"A{indexOffsetter}:I{indexOffsetter}");

						indexOffsetter++;

						// If the companion is a beast, explain the species
						if (sheet.primaryCompanionType == CompanionSheet.CompanionType.Beast)
						{
							WriteCell($"A{indexOffsetter}", $"Companion Species : {sheet.beastSpecies}");
							MergeCells($"A{indexOffsetter}:I{indexOffsetter}");

							indexOffsetter++;
						}

						// Setup Companion History
						WriteCell($"A{indexOffsetter}", $"Companion History : {sheet.companionHistory}");

						SLStyle compsLStyle = new SLStyle();
						compsLStyle.SetWrapText(true);
						compsLStyle.SetVerticalAlignment(VerticalAlignmentValues.Top);
						sLDocument.SetCellStyle($"A{indexOffsetter}", compsLStyle);

						MergeCells($"A{indexOffsetter}:I{(indexOffsetter + 3)}");

						// Space between history OR new companion
						indexOffsetter += 5;

						// If the companion is a droid.
						if (sheet.primaryCompanionType < CompanionSheet.CompanionType.Beast)
						{
							// Setup Abilities title header
							WriteCell($"A{indexOffsetter}", "Abilities");
							MergeCells($"A{indexOffsetter}:I{indexOffsetter}");

							indexOffsetter++;

							// Setup abilities filter headers
							// Name
							WriteCell($"A{indexOffsetter}", "Name");
							MergeCells($"A{indexOffsetter}:D{indexOffsetter}");
							// Description if valid
							WriteCell($"E{indexOffsetter}", "Description");
							MergeCells($"E{indexOffsetter}:H{indexOffsetter}");

							indexOffsetter++;

							foreach (int abilityID in sheet.abilities)
							{
								Ability ability = AbilityLibraryRef.GetAbility(abilityID);
								if (ability == null) continue;

								WriteCell($"A{indexOffsetter}", ability.Name);
								MergeCells($"A{indexOffsetter}:D{indexOffsetter}");

								WriteCell($"E{indexOffsetter}", ability.description);
								MergeCells($"E{indexOffsetter}:I{indexOffsetter}");

								indexOffsetter++;
							}
						}

						indexOffsetter++;
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
				string prereqmasterString = "";

				string[] allformabilities = characterSheet.GetAbilitiesOfSchool(Ability_Schools.Ability_Forms);
				foreach (string formAbility in allformabilities)
				{
					if (FurthestForms.Contains(formAbility))
						continue;
					else
					{
						if (AbilityLibraryRef.TryGetAbility(formAbility, out Ability ability))
						{
							prereqFormsString += $"{ability.ID},";
							prereqmasterString += $"{(int)(characterSheet.abilityMasteryDictionary[ability.ID])},";
						}
					}
				}

				WriteCell("A4", prereqFormsString);
				WriteCell("A5", prereqmasterString);

				// If we created seperate worksheets for multiple companions we need to record the names here so
				// we know that there are companion sheets with these names to read.
				if(sheetExportSettings.seperateSheetsPerCompanion)
                {
					string names = "";
					foreach(CompanionSheet companionSheet in characterSheet.companionSheets)
                    {
						names += $"{companionSheet.companionName},";
                    }
					WriteCell("A6", names);
                }
			}

			sLDocument.SelectWorksheet(characterSheet.Name);
			sLDocument.SaveAs(url);        
		}

		public CharacterSheet ImportSheet(string url)
		{
			if (!File.Exists(url))
				return null;

			SLDocument sl = new SLDocument(url);
			// Excel files save which worksheet was the last viewed. Move to the main worksheet containing the character's main data.
			// If this is not done, read commands may get inacurrate info.
			string mainWorksheet = (url.Split('\\')[url.Split('\\').Length - 1]).Split('.')[0];
			sl.SelectWorksheet(mainWorksheet);

			string name = sl.GetCellValueAsString("B2");
			string characterDescription = "";
			string characterSpecies = sl.GetCellValueAsString("B6").Replace("Species: ", "");
			Rank rank = Rank.Invalid;
			Ability_Alignment ability_Alignment = Ability_Alignment.Ability_Invalid;
			List<int> abilities = new List<int>();
			Dictionary<int, Ability_Mastery> masteries = new Dictionary<int, Ability_Mastery>();

			string s_rank = sl.GetCellValueAsString("B4").Replace("Rank: ", "");
			foreach (Rank _rank in Enum.GetValues(typeof(Rank)))
			{
				if (Enum.GetName(typeof(Rank), _rank) == s_rank)
				{
					rank = _rank;
					break;
				}
			}

			string s_alignment = sl.GetCellValueAsString("B5").Replace("Alignment: ", "Ability_");
			foreach (Ability_Alignment _alignment in Enum.GetValues(typeof(Ability_Alignment)))
			{
				if (Enum.GetName(typeof(Ability_Alignment), _alignment) == s_alignment)
				{
					ability_Alignment = _alignment;
					break;
				}
			}

			//Skip value incase the sheet is missing schools or forms
			int skipVal = 0;

			void ReadMasteryCell(string cell, int id)
			{
				string mastery = sl.GetCellValueAsString(cell);
				if (mastery == "")
				{
					masteries[id] = Ability_Mastery.Mastery_Learned;
				}
				else if (mastery == "NL")
				{
					masteries[id] = Ability_Mastery.Mastery_NotLearned;
				}
				else if (mastery == "L")
				{
					masteries[id] = Ability_Mastery.Mastery_Learned;
				}
				else if (mastery == "M")
				{
					masteries[id] = Ability_Mastery.Mastery_Master;
				}
				else if (mastery == "HM")
				{
					masteries[id] = Ability_Mastery.Mastery_HeadMaster;
				}
				else
					masteries[id] = Ability_Mastery.Mastery_Learned;
			}

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

					if (AbilityLibraryRef.TryGetAbility(s_school_name, out Ability ability))
					{
						abilities.Add(ability.ID);
						ReadMasteryCell($"F{s_s_i}", ability.ID);
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

					if (AbilityLibraryRef.TryGetAbility(s_form_name, out Ability ability))
					{
						abilities.Add(ability.ID);
						ReadMasteryCell($"F{s_f_i}", ability.ID);
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
					if (AbilityLibraryRef.TryGetAbility(sl.GetCellValueAsString($"B{s_ability_name}"), out Ability ability))
					{
						abilities.Add(ability.ID);
						ReadMasteryCell($"E{s_ability_name}", ability.ID);
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
					if (AbilityLibraryRef.TryGetAbility(sl.GetCellValueAsString($"F{s_ability_name}"), out Ability ability))
					{
						abilities.Add(ability.ID);
						ReadMasteryCell($"I{s_ability_name}", ability.ID);
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
					if (AbilityLibraryRef.TryGetAbility(sl.GetCellValueAsString($"J{s_ability_name}"), out Ability ability))
					{
						abilities.Add(ability.ID);
						ReadMasteryCell($"M{s_ability_name}", ability.ID);
						s_ability_name++;
					}
					else
					{
						break;
					}
				}
			} while (true);


			List<string> dataStringForCompNames = new List<string>();
			if (sl.SelectWorksheet("CharacterMakerData") == true)
			{
				string otherFormIDs = sl.GetCellValueAsString("A4");
				string[] ids = otherFormIDs.Split(',');
				string otherMasteryNumbers = sl.GetCellValueAsString("A5");
				string[] masters = otherMasteryNumbers.Split(',');
				int index = 0;
				foreach (string id in ids)
				{
					if (id == "")
						break;
					// If the ability library contains the ability id AND the loaded list of abilities does NOT contain the id already
					if (AbilityLibraryRef.Contains(int.Parse(id)) && !abilities.Contains(int.Parse(id)))
					{
						abilities.Add(int.Parse(id));
						masteries[int.Parse(id)] = (Ability_Mastery)(int.Parse(masters[index]));
					}
				}
				string[] namesForComps = sl.GetCellValueAsString("A6").Split(',');
				foreach (string compName in namesForComps)
                {
					if (name == "")
						break;
					dataStringForCompNames.Add(compName);
                }
			}

			List<CompanionSheet> companionSheets = new List<CompanionSheet>();
			if (sl.SelectWorksheet("Companion") == true)
			{
				int indexoffset = 1;

				// Read entire worksheet until the cells being read are empty.
				do
				{
					string compName = "";
					string compType = "";
					string compHistory = "";
					string compSpecies = "";
					List<int> compAbil = new List<int>();

					// Read through all data of a companion until read cell is empty, move on to the next sheet.
					do
					{
						// Read cell data
						string companionDataString = sl.GetCellValueAsString($"A{indexoffset}");

						// Figuring out what the cell data is.
						if (companionDataString.Contains("Name"))
						{
							compName = companionDataString.Replace("Companion Name : ", "");
						}
						else if (companionDataString.Contains("Type"))
						{
							compType = companionDataString.Replace("Companion Type : ", "");
						}
						else if (companionDataString.Contains("History"))
						{
							compHistory = companionDataString.Replace("Companion History : ", "");
							// We must make a large offset increase as the cell reader from document will not recognize when
							// two row cells are merged. In the exporter we merge 4 rows to make the history box.
							indexoffset += 4;
						}
						else if (companionDataString.Contains("Species"))
						{
							compSpecies = companionDataString.Replace("Companion Species : ", "");
						}
						else if (companionDataString.Contains("Abilities"))
						{
							indexoffset += 2;
							do
							{
								string ability = sl.GetCellValueAsString($"A{indexoffset}");

								if (AbilityLibraryRef.TryGetAbility(ability, out Ability ability1))
								{
									compAbil.Add(ability1.ID);
									indexoffset++;
								}
								else if (ability == "")
								{
									indexoffset -= 1;
									break;
								}
							} while (true);
						}
						else
							break;

						indexoffset++;
					} while (true);

					if (compName != "" && compType != "")
					{
						CompanionSheet sheet = new CompanionSheet(compName, compHistory, CompanionSheet.DetermineEnumTypeByString(compType), compAbil, ref StatRulesRef, ref AbilityLibraryRef);
						if (sheet.primaryCompanionType == CompanionSheet.CompanionType.Beast) sheet.SetBeastSpecies(compSpecies);
						companionSheets.Add(sheet);
						indexoffset++;
					}
					else
						break;
				} while (true);
			}
			else if (dataStringForCompNames.Count != 0)
            {
				foreach(string compName in dataStringForCompNames)
                {
					if (sl.SelectWorksheet(compName))
					{
						string companionName = sl.GetCellValueAsString("A1").Split(':').Last().Remove(0,1);
						string str_companionType = sl.GetCellValueAsString("A2").Split(':').Last().Replace(' ', '_').Remove(0,1);
						string beastRaceType = "";

						int offsetVal = 3;
						if (str_companionType == "Beast")
                        {
							offsetVal++;
							beastRaceType = sl.GetCellValueAsString("A3").Split(':').Last().Remove(0,1);
                        }

						string description = sl.GetCellValueAsString($"A{offsetVal}").Split(':')[1];
						offsetVal += 7;

						List<int> abilities_int = new List<int>();

						do
						{
							string ability_name = sl.GetCellValueAsString($"A{offsetVal}");
							if (AbilityLibraryRef.TryGetAbility(ability_name, out Ability ability))
							{
								abilities_int.Add(ability.ID);
								offsetVal++;
							}
							else
								break;
						} while (true);

						CompanionSheet sheet = new CompanionSheet(compName, description, CompanionSheet.DetermineEnumTypeByString(str_companionType), abilities_int, ref StatRulesRef, ref AbilityLibraryRef);
						if (sheet.primaryCompanionType == CompanionSheet.CompanionType.Beast) sheet.SetBeastSpecies(beastRaceType);
						companionSheets.Add(sheet);
					}
					else
						continue;
                }
            }

			CharacterSheet characterSheet = new CharacterSheet(name,
															   rank,
															   ability_Alignment,
															   abilities,
															   "",
															   null,
															   characterSpecies,
															   CharacterSheet.SheetFileType.XlSx,
															   ref AbilityLibraryRef);

			characterSheet.abilityMasteryDictionary = masteries;

			if (companionSheets.Count > 0)
				characterSheet.companionSheets = new List<CompanionSheet>(companionSheets);


			return characterSheet;
		}
	}
}