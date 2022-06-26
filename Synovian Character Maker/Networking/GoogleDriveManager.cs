using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

// Google API V3
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Download;

using Synovian_Character_Maker.DataClasses.Static;

namespace Synovian_Character_Maker.Networking
{
    static class GoogleDriveManager
    {
        /// <summary>
        /// Data class for file search result.
        /// </summary>
        public struct FileSearch
        {
            public string Name;
            public string Id;

            public FileSearch(string name, string id)
            {
                Name = name;
                Id = id;
            }
        }        

        static private string[] Scopes = { DriveService.Scope.DriveFile };
        static private string ApplicationName = "Synovian Character Maker";

        static DriveService googleDriveService
        {
            get
            {
                if (_googleDriveService == null)
                {
                    _googleDriveService = GetActiveService();
                    return _googleDriveService;
                }
                else
                    return _googleDriveService;
            }
        }
        static DriveService _googleDriveService = null;

        /// <summary>
        /// Attempts to send the character file provided to the user's google drive. Returns a boolian representing the success.
        /// </summary>
        /// <param name="file">The file path of the file sent.</param>
        /// <returns>Returns true if file was successfuly uploaded to google drive.</returns>
        static public bool SubmitSheetToDrive(string file)
        {
            // Get parentID of folder used to export and import. Create the folder if not found.
            string folderID = GetFolderID(true);
            string fileNameWithoutExt = $"{file.Split('\\')[file.Split('\\').Length - 1].Split('.')[0]}";

            // Check if that sheet already exists
            if (IsCharacterInDrive(fileNameWithoutExt))
            {
                // Ask about the existing file. If they say yes, they overrite existing version. If they say no, create a new copy with a number at the end. Cancel stops the process.
                DialogResult result = MessageBox.Show("You already have a sheet for this character in your drive and specific folder. Do you wish to overrite?", 
                                                      "Notice!", 
                                                      MessageBoxButtons.YesNoCancel, 
                                                      MessageBoxIcon.Warning, 
                                                      MessageBoxDefaultButton.Button2);

                switch(result)
                {
                    case DialogResult.Yes:
                        {
                            googleDriveService.Files.Delete(GetFileID(fileNameWithoutExt)).Execute();
                            break;
                        }
                    case DialogResult.No:
                        {
                            fileNameWithoutExt = IncrementName(fileNameWithoutExt);
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            return false;
                        }
                    default:
                        {
                            ExceptionHandles.ExceptionHandle("Reached out of bounds of possible outcomes.");
                            break;
                        }
                }
            }

            // Submit character sheet
            Google.Apis.Drive.v3.Data.File newFile = new Google.Apis.Drive.v3.Data.File();
            newFile.Name = $"{fileNameWithoutExt}.xlsx";
            newFile.Description = $"Character sheet for the character {fileNameWithoutExt}.";
            newFile.MimeType = "application/vnd.google-apps.spreadsheet";
            newFile.Parents = new List<string>();
            newFile.Parents.Add(folderID);

            try
            {
                // Create the file.
                FilesResource.CreateMediaUpload request;

                using (var stream = new System.IO.FileStream(file, FileMode.Open))
                {
                    request = googleDriveService.Files.Create(newFile, stream, "spreadsheet/xlsx");
                    request.Fields = "id";
                    request.Upload();
                }
                Console.WriteLine("Created the text file called TestFile.txt in your google drive");
                MessageBox.Show("Character sheet successfully sent!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }
            catch (Exception e)
            {
                ExceptionHandles.ExceptionHandle(e);
                return false;
            }
        }

        /// <summary>
        /// Attempts to read users drive to confirm is a character sheet of provided name exists.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <returns>Returns true if charactersheet exists.</returns>
        static public bool IsCharacterInDrive(string name)
        {
            string pageToken = "";
            FilesResource.ListRequest listRequest = googleDriveService.Files.List();
            listRequest.Spaces = ("drive");
            listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.PageToken = pageToken;
            listRequest.Q = $"name contains '{name}' and mimeType = 'application/vnd.google-apps.spreadsheet' and '{GetFolderID()}' in parents";
            listRequest.PageSize = 20;
            
            IList<Google.Apis.Drive.v3.Data.File> files = null;
            try
            {
                files = listRequest.Execute().Files;
            }
            catch (Exception e)
            {
                ExceptionHandles.ExceptionHandle(e);
                return false;
            }

            foreach(var file in files)
            {
                // Ignore extension
                if (file.Name.Split('.')[0] == name)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the file id of a specified file.
        /// </summary>
        /// <param name="name">The file asked for.</param>
        /// <returns>Returns a string of the id. Will return "" if no file found.</returns>
        static private string GetFileID(string name)
        {
            string pageToken = "";
            FilesResource.ListRequest listRequest = googleDriveService.Files.List();
            listRequest.Spaces = ("drive");
            listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.PageToken = pageToken;
            listRequest.Q = $"name contains '{name}' and mimeType = 'application/vnd.google-apps.spreadsheet' and '{GetFolderID()}' in parents";
            listRequest.PageSize = 20;

            IList<Google.Apis.Drive.v3.Data.File> files = null;
            try
            {
                files = listRequest.Execute().Files;
            }
            catch (Exception e)
            {
                ExceptionHandles.ExceptionHandle(e);
                return "";
            }

            foreach (var file in files)
            {
                // Ignore extension
                if (file.Name.Split('.')[0] == name)
                {
                    return file.Id;
                }
            }

            return "";
        }

        /// <summary>
        /// Create a local copy of the DriveService that connects to google.
        /// </summary>
        /// <returns></returns>
        static private DriveService GetActiveService()
        {
            UserCredential credential;

            using (var stream =
                new FileStream($"{Globals.DataFolder}\\client_secret.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                // 
                // If the token folder is deleted, the user must authenticate again.
                string credPath = "Data/token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        /// <summary>
        /// Gets the folder of ID of the folder used to store sent character sheets.
        /// </summary>
        /// <param name="makeIfNotFound">Override to make folder if not found</param>
        /// <returns>Returns a string containing id. Will return "" if not found.</returns>
        static private string GetFolderID(bool makeIfNotFound = false)
        {
            string pageToken = "";
            FilesResource.ListRequest listRequest = googleDriveService.Files.List();
            listRequest.Spaces = ("drive");
            listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.PageToken = pageToken;
            listRequest.Q = "mimeType = 'application/vnd.google-apps.folder'";
            listRequest.PageSize = 20;
            IList<Google.Apis.Drive.v3.Data.File> folders = null;
            try
            {
                folders = listRequest.Execute().Files;
            }
            catch (Exception e)
            {
                ExceptionHandles.ExceptionHandle(e);
                return "";
            }
            // Look through the provided list and search for our specific folder.
            // If we found it, grab the id of the folder for future use.
            foreach (var folder in folders)
            {
                if (folder.Name == "Character Maker Sheets")
                {
                    return folder.Id;
                }
            }

            // If we did not find the folder but we are told to make it.
            if (makeIfNotFound)
            {
                Google.Apis.Drive.v3.Data.File folderFileMeta = new Google.Apis.Drive.v3.Data.File();
                folderFileMeta.Name = "Character Maker Sheets";
                folderFileMeta.MimeType = "application/vnd.google-apps.folder";

                Google.Apis.Drive.v3.Data.File createdFolder = null;

                try
                {
                    createdFolder = googleDriveService.Files.Create(folderFileMeta).Execute();

                    return createdFolder.Id;
                }
                catch (Exception e)
                {
                    ExceptionHandles.ExceptionHandle(e);
                }
            }

            return "";
        }

        /// <summary>
        /// Increments a given name for the google drive. Speed in which this finishes is based on how many increments are needed as it will check drive.
        /// </summary>
        /// <param name="name">Provided filename.</param>
        /// <returns>Returns modified filename with increment change.</returns>
        static private string IncrementName(string name)
        {
            string lastIncrementStr = "";
            int digitSize = 0;
            int lastIncrementInt = 0;

            for(int i = 0; i < name.Length;i++)
            {
                if(Char.IsDigit(name[i]))
                {
                    lastIncrementStr += name[i];
                    digitSize++;
                }
            }

            if (lastIncrementStr != "")
            {
                name = name.Remove(name.Length - digitSize, digitSize);
                lastIncrementInt = int.Parse(lastIncrementStr);
            }
            else
                lastIncrementInt = 0;

            lastIncrementInt++;

            name += lastIncrementInt.ToString();

            if (IsCharacterInDrive(name))
                name = IncrementName(name);

            return name;
        }

        /// <summary>
        /// Provides a list of found files within the Character Maker folder on drive.
        /// </summary>
        /// <param name="searchSize">The max size of the file search. Default search size is 10.</param>
        /// <returns>An array of struct FileSearch containing names and ids.</returns>
        static public List<FileSearch> SearchFiles(int searchSize = 10)
        {
            FilesResource.ListRequest listRequest = googleDriveService.Files.List();
            listRequest.PageSize = searchSize;
            listRequest.Fields = "nextPageToken, files(id, name)";
            listRequest.Q = $"'{GetFolderID()}' in parents and trashed = false";
            IList<Google.Apis.Drive.v3.Data.File> files = null;

            try
            {
                files = listRequest.Execute().Files;
            }
            catch(Exception e)
            {
                ExceptionHandles.ExceptionHandle(e);
                return null;
            }

            List<FileSearch> vs = new List<FileSearch>();
            foreach(var file in files)
            {
                vs.Add(new FileSearch(file.Name, file.Id));
            }

            return vs;
        }

        /// <summary>
        /// Downloads a specific charactersheet with a provided id and filename.
        /// </summary>
        /// <param name="id">The ID of the document.</param>
        /// <param name="filename">The filename of the file.</param>
        /// <returns>Returns true if successful.</returns>
        static public bool DownloadSheet(string id, string filename)
        {
            if (!Directory.Exists(Globals.GoogleDownloads))
                Directory.CreateDirectory(Globals.GoogleDownloads);

            if(File.Exists($"{Globals.GoogleDownloads}\\{filename}"))
            {
                DialogResult result = MessageBox.Show("You have already downloaded this character! Download again?", "Notice!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch(result)
                {
                    case DialogResult.Yes:
                    {
                        break;
                    }
                    case DialogResult.No:
                        return false;
                }
            }

            FilesResource.ExportRequest request = new FilesResource.ExportRequest(googleDriveService, id, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            MemoryStream memoryStream = new MemoryStream();
            bool successful = true;
            request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Completed:
                        {
                            using (FileStream filestream = new FileStream($"{Globals.GoogleDownloads}\\{filename}", FileMode.Create, FileAccess.Write))
                            {
                                memoryStream.WriteTo(filestream);
                            }
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            ExceptionHandles.ExceptionHandle("Download failed!");
                            successful = false;
                            break;
                        }
                };
            };

            request.DownloadWithStatus(memoryStream);
            return successful;
        }

        /// <summary>
        /// Deletes a file on a users google drive in the character folder with a provided id.
        /// </summary>
        /// <param name="id">ID of the file.</param>
        /// <returns>Return's true if successful.</returns>
        static public bool DeleteSheet(string id)
        {
            try
            {
                googleDriveService.Files.Delete(id).Execute();
                return true;
            }
            catch(Exception e)
            {
                ExceptionHandles.ExceptionHandle(e);
                return false;
            }
        }

        /// <summary>
        /// Wipes all downloaded files on the disk, then deleting the folder itself.
        /// </summary>
        static public void WipeGoogleFolderOnDisk()
        {
            if (!Directory.Exists(Globals.GoogleDownloads))
                return;

            string[] files = Directory.GetFiles(Globals.GoogleDownloads);

            foreach(string file in files)
            {
                File.Delete(file);
            }

            Directory.Delete(Globals.GoogleDownloads);
        }
    }
}
