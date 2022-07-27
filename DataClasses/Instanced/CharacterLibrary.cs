using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Synovian_Character_Maker.DataClasses.Static;

namespace Synovian_Character_Maker.DataClasses.Instanced
{
    public class CharacterLibrary
    {
        public List<CharacterSheet> characterSheets { get => new List<CharacterSheet>(_characterSheets); }
        List<CharacterSheet> _characterSheets;

        ExcelManager _excelManagerRef;

        public CharacterLibrary(ExcelManager excelManagerref)
        {
            _characterSheets = new List<CharacterSheet>();

            _excelManagerRef = excelManagerref;
        }

        public CharacterLibrary(List<CharacterSheet> characters)
        {
            _characterSheets = new List<CharacterSheet>(characters);
        }

        public void ExportSheets()
        {
            foreach (CharacterSheet characterSheet in _characterSheets)
            {
                if (characterSheet.sheetFileType == CharacterSheet.SheetFileType.Xlsx_Google)
                    continue;

                _excelManagerRef.ExportSheet(characterSheet, "", new SheetExportSettings());
            }
        }

        /// <summary>
        /// Try and get a sheet by a string name.
        /// </summary>
        /// <param name="name">String name of the character wanted.</param>
        /// <param name="characterSheet">The output charactersheet if found, may return NULL</param>
        /// <returns>Returns a boolian if successfuly found</returns>
        public bool TryGetCharacter(string name, out CharacterSheet characterSheet)
        {
            foreach (CharacterSheet characterSheet1 in _characterSheets)
            {
                if (characterSheet1.Name == name)
                {
                    characterSheet = characterSheet1;
                    return true;
                }
            }
            characterSheet = null;
            return false;
        }

        /// <summary>
        /// Attempt to add a new character to the library.
        /// </summary>
        /// <param name="characterSheet">The new charactersheet</param>
        /// <param name="automaticallyToFile">Override to auomatically save the character to disk.</param>
        /// <returns>Returns a boolian on whether the sheet successfully was added or not. However if the override is used, the 
        /// bool will return false if the program failed to save to disk.</returns>
        public bool AddCharacter(CharacterSheet characterSheet, bool automaticallyToFile = false)
        {
            foreach (CharacterSheet sheet in _characterSheets)
            {
                if (sheet.Name == characterSheet.Name)
                {
                    MessageBox.Show($"The character {sheet.Name} could not be added as it was already loaded in. Enter the sheets folder and remove the file you don't want.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            _characterSheets.Add(characterSheet);
            return true; //(automaticallyToFile == true) ? DataWriter.WriteCharacterToDiskTxt(characterSheet) : true;
        }

        /// <summary>
        /// Attempt to remove a character from the library, with the override option to remove from disk.
        /// </summary>
        /// <param name="name">The name of the Character</param>
        /// <param name="removeFileFromDisk">The program will attempt to remove the character file from the user's disk. This will only
        /// work if the character file is in the maker's Sheets folder.</param>
        /// <returns>Returns a bool if the sheet was removed from the library. However this bool will always be false if it failed 
        /// to remove the file from disk if the override is overridden.</returns>
        public bool RemoveCharacter(string name, bool removeFileFromDisk = false)
        {
            // Is not override overriden?
            if (!removeFileFromDisk)
            {
                // Go through the library
                foreach (CharacterSheet characterSheet in _characterSheets)
                {
                    // If the sheet has the requested name
                    if (characterSheet.Name == name)
                    {
                        // Remove the sheet
                        _characterSheets.Remove(characterSheet);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                foreach (CharacterSheet characterSheet in _characterSheets)
                {
                    if (characterSheet.Name == name)
                    {
                        _characterSheets.Remove(characterSheet);
                        if (File.Exists($"{Globals.CharacterFolder}\\{name}.txt"))
                        {
                            try
                            {
                                File.Delete($"{Globals.CharacterFolder}\\{name}.txt");
                                return true;
                            }
                            catch (Exception e)
                            {
                                ExceptionHandles.ExceptionHandle(e);
                                return false;
                            }
                        }
                        else if (File.Exists($"{Globals.CharacterFolder}\\{name}.zip"))
                        {
                            try
                            {
                                File.Delete($"{Globals.CharacterFolder}\\{name}.zip");
                                return true;
                            }
                            catch (Exception e)
                            {
                                ExceptionHandles.ExceptionHandle(e);
                                return false;
                            }
                        }
                        else
                            return false;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Search the library for a character by string name.
        /// </summary>
        /// <param name="name">Name of the charactersheet</param>
        /// <returns>Returns a boolian based on whether it finds a sheet or not.</returns>
        public bool HasCharacter(string name)
        {
            foreach (CharacterSheet characterSheet in characterSheets)
                if (characterSheet.Name == name) return true;
            return false;
        }
    }
}