using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;

// Google API V3
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Synovian_Character_Maker.Static_Classes.Networking.GoogleDrive
{
    static class GoogleDriveManager
    {
        static string[] Scopes = { DriveService.Scope.DriveFile };
        static string ApplicationName = "Synovian Character Maker";

        /// <summary>
        /// Attempts to send the character file provided to the user's google drive. Returns a boolian representing the success.
        /// </summary>
        /// <param name="file">The file path of the file sent.</param>
        /// <returns>Returns true if file was successfuly uploaded to google drive.</returns>
        static public bool SubmitSheetToDrive(string file)
        {
            UserCredential credential;

            using (var stream = 
                new FileStream($"{Globals.DataFolder}\\client_secret.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
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


            Google.Apis.Drive.v3.Data.File newFile = new Google.Apis.Drive.v3.Data.File();
            newFile.Name = "Doctor Abrhame.xlsx";
            newFile.Description = "A test file";
            newFile.MimeType = "application/vnd.google-apps.spreadsheet";

            try
            {
                FilesResource.CreateMediaUpload request;

                using (var stream = new System.IO.FileStream("Doctor Abrhame.xlsx", FileMode.Open))
                {
                    request = service.Files.Create(newFile, stream, "spreadsheet/xlsx");
                    request.Fields = "id";
                    request.Upload();
                }
                var fileResponse = request.ResponseBody;
                Console.WriteLine("Created the text file called TestFile.txt in your google drive");
                MessageBox.Show("Character sheet successfully sent!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }
            catch (Exception e)
            {
                Helpers.ExceptionHandle(e);
                return false;
            }
        }
    }
}
