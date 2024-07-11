using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Helper
{
    public static class Files
    {
        public static string Save(IFormFile file)
        {
            Stream fileStream = GetFileAsStream("teacher-407012-658fe495e1e6.json");
            string folderId = "1KMcE_s-MAz8fEoqTdm8eBkMxEbft5JQ_";
            string fileUrl = UploadFileToGoogleDrive(file, folderId, fileStream);
            string fileId = ConvertToDirectLink(fileUrl);
            return fileId;
        }

        private static string UploadFileToGoogleDrive(IFormFile file, string folderId, Stream credentialsStream)
        {
            try
            {
                var credential = GoogleCredential.FromStream(credentialsStream)
                    .CreateScoped(new[] { DriveService.ScopeConstants.DriveFile });

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Drive Upload Console App"
                });

                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(file.FileName),
                    Parents = new List<string> { folderId }
                };

                FilesResource.CreateMediaUpload request;

                using (var stream = file.OpenReadStream())
                {
                    request = service.Files.Create(fileMetadata, stream, file.ContentType);
                    request.Fields = "webViewLink"; // Request the webViewLink field
                    request.Upload();
                }

                var uploadedFile = request.ResponseBody;
                return uploadedFile.WebViewLink; // Return the web view link of the uploaded file
            }
            catch (Exception ex)
            {
                // Handle exceptions here or log them for further analysis.
                return $"Error: {ex.Message}";
            }
        }

        public static Stream GetFileAsStream(string fileName)
        {
            try
            {
                // Use the project path to access the file
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                // Read the content of the file and copy it to a MemoryStream
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin); // Reset the stream position to the beginning
                    return memoryStream;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                return null; // Or you can throw an exception here
            }
        }
        public static object DeleteFileByLink(string fileLink)
        {
            try
            {
                var credential = GoogleCredential.FromStream(GetFileAsStream("teacher-407012-658fe495e1e6.json"))
                    .CreateScoped(new[] { DriveService.ScopeConstants.Drive });

                var service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Drive Upload Console App"
                });

                // Search for the file using its web view link
                FilesResource.ListRequest listRequest = service.Files.List();
                listRequest.QuotaUser = fileLink;
                var files = listRequest.Execute().Files;

                if (files != null && files.Any())
                {
                    var fileId = files.First().Id;

                    // Delete the file
                    service.Files.Delete(fileId).Execute();
                    return true; // File was successfully deleted
                }
                else
                {
                    // File not found with the provided link
                    return false;
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        private static string ConvertToDirectLink(string googleDriveLink)
        {
            string fileId = ExtractFileId(googleDriveLink);
            return $"https://drive.google.com/uc?id={fileId}";
        }

        private static string ExtractFileId(string link)
        {
            Regex regex = new Regex(@"/d/([^/]+)/");
            Match match = regex.Match(link);
            return match.Success ? match.Groups[1].Value : "";
        }
    }
}
