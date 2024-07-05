using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Download;
using Google.Apis.Drive.v2.Data;
using System.Net;

namespace DrawingModel
{
    public class GoogleDriveService
    {
        private readonly string[] _scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private DriveService _service;
        private const int KB = 0x400;
        private const int TWO = 2;
        private const int DOWNLOAD_CHUNK_SIZE = 256 * KB;
        private int _timeStamp;
        private string _applicationName;
        private string _clientSecretFileName;
        private UserCredential _credential;

        public GoogleDriveService(string applicationName, string clientSecretFileName)
        {
            _applicationName = applicationName;
            _clientSecretFileName = clientSecretFileName;
            this.CreateNewService(_applicationName, _clientSecretFileName);
        }

        // set credential
        public void SetCredential(string applicationName, string clientSecretFileName)
        {
            const string USER = "user";
            const string CREDENTIAL_FOLDER = ".credential/";
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), clientSecretFileName));
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                string credentialPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credentialPath = Path.Combine(credentialPath, CREDENTIAL_FOLDER + applicationName);
                _credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets, _scopes, USER, CancellationToken.None, new FileDataStore(credentialPath, true)).Result;
            }
        }

        // create a new service
        public void CreateNewService(string applicationName, string clientSecretFileName)
        {
            SetCredential(applicationName, clientSecretFileName);
            DriveService service = new DriveService(new BaseClientService.Initializer()
            { 
                HttpClientInitializer = _credential,
                ApplicationName = applicationName });
            DateTime now = DateTime.Now;
            _timeStamp = UNIXNowTimeStamp;
            _service = service;
        }

        // return time
        public int UNIXNowTimeStamp
        {
            get
            {
                const int UNIX_START_YEAR = 1970;
                DateTime unixStartTime = new DateTime(UNIX_START_YEAR, 1, 1);
                return Convert.ToInt32((DateTime.Now.Subtract(unixStartTime).TotalSeconds));
            }
        }

        // Check and refresh the credential if credential is out-of-date
        public void CheckCredentialTimeStamp()
        {
            const int ONE_HOUR_SECOND = 3600;
            int nowTimeStamp = UNIXNowTimeStamp;

            if ((nowTimeStamp - _timeStamp) > ONE_HOUR_SECOND)
                this.CreateNewService(_applicationName, _clientSecretFileName);
        }

        // get google drive roots file
        public List<Google.Apis.Drive.v2.Data.File> ListRootFileAndFolder()
        {
            List<Google.Apis.Drive.v2.Data.File> returnList = new List<Google.Apis.Drive.v2.Data.File>();
            const string ROOT_QUERY_STRING = "'root' in parents";
            try
            {
                returnList = ListFileAndFolderWithQueryString(ROOT_QUERY_STRING);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return returnList;
        }

        // check file
        public List<Google.Apis.Drive.v2.Data.File> SearchDetail(FilesResource.ListRequest listRequest)
        {
            List<Google.Apis.Drive.v2.Data.File> returnList = new List<Google.Apis.Drive.v2.Data.File>();
            do
            {
                try
                {
                    FileList fileList = listRequest.Execute();
                    returnList.AddRange(fileList.Items);
                    listRequest.PageToken = fileList.NextPageToken;
                }
                catch (Exception exception)
                {
                    listRequest.PageToken = null;
                    throw exception;
                }
            } while (!String.IsNullOrEmpty(listRequest.PageToken));
            return returnList;
        }

        // find file
        private List<Google.Apis.Drive.v2.Data.File> ListFileAndFolderWithQueryString(string queryString)
        {
            this.CheckCredentialTimeStamp();
            FilesResource.ListRequest listRequest = _service.Files.List();
            listRequest.Q = queryString;
            return SearchDetail(listRequest);
        }

        // upload detail
        public Google.Apis.Drive.v2.Data.File UploadDetail(FilesResource.InsertMediaUpload insertRequest, FileStream uploadStream)
        {
            try
            {
                insertRequest.Upload();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                uploadStream.Close();
            }
            return insertRequest.ResponseBody;
        }

        // upload file
        public Google.Apis.Drive.v2.Data.File UploadFile(string uploadFileName, string contentType, Action<IUploadProgress> uploadProgressEventHandler = null, Action<Google.Apis.Drive.v2.Data.File> responseReceivedEventHandler = null)
        {
            FileStream uploadStream = new FileStream(uploadFileName, FileMode.Open, FileAccess.Read);
            const string TITLE = "shapeInformation.txt";
            this.CheckCredentialTimeStamp();
            Google.Apis.Drive.v2.Data.File fileToInsert = new Google.Apis.Drive.v2.Data.File
            { 
                Title = TITLE };
            FilesResource.InsertMediaUpload insertRequest = _service.Files.Insert(fileToInsert, uploadStream, contentType);
            insertRequest.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * TWO;
            if (uploadProgressEventHandler != null)
                insertRequest.ProgressChanged += uploadProgressEventHandler;
            if (responseReceivedEventHandler != null)
                insertRequest.ResponseReceived += responseReceivedEventHandler;
            return UploadDetail(insertRequest, uploadStream);

        }

        // downlad file
        public void DownloadFile(Google.Apis.Drive.v2.Data.File fileToDownload, string downloadPath, Action<IDownloadProgress> downloadProgressChangedEventHandler = null)
        {
            const string SPLASH = @"\";
            CheckCredentialTimeStamp();
            if (!String.IsNullOrEmpty(fileToDownload.DownloadUrl))
            {
                try
                {
                    Task<byte[]> downloadByte = _service.HttpClient.GetByteArrayAsync(fileToDownload.DownloadUrl);
                    byte[] byteArray = downloadByte.Result;
                    string downloadPosition = downloadPath + SPLASH + fileToDownload.Title;
                    System.IO.File.WriteAllBytes(downloadPosition, byteArray);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
    }
}
