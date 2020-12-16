using CDN_Video_Uploader.Jobs;
using CDN_Video_Uploader.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FluentFTP;
using System.Diagnostics;
using CDN_Video_Uploader.Forms;

namespace CDN_Video_Uploader
{
    public partial class FormVideoUploader : Form
    {
        const string AllowedVideoFilesExtensions = "*.avi;*.mp4;*.mpg;*.mpeg;*.mov;*.mkv;*.webm;*.wmv";

        // Create a working directory (temp folder) for the transcoded videos
        private readonly string workDir = 
            Path.GetTempPath() + "CDN-Video-Uploader";

        private FtpClient ftpClient;
        private List<Job> activeJobsQueue = new List<Job>();
        private List<Job> completedJobs = new List<Job>();
        private Timer activeJobsProcessor;

        public FormVideoUploader()
        {
            InitializeComponent();
            this.dataGridViewActiveJobs.AutoGenerateColumns = false;
            this.dataGridViewCompletedJobs.AutoGenerateColumns = false;
        }

        private void FormVideoUploader_Load(object sender, EventArgs e)
        {
            this.ClearLog();
            this.webBrowserLogs.ObjectForScripting = this;

            this.CreateWorkingDirectory();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(Application_ProcessExit);

            this.dataGridViewActiveJobs.DataSource = new List<Job>();
            this.dataGridViewCompletedJobs.DataSource = new List<Job>();
            this.dataGridViewFTPFolders.DataSource = new List<FtpListItem>();
            this.dataGridViewFTPFiles.DataSource = new List<FtpListItem>();

            this.ActiveControl = this.dataGridViewFTPFolders;
            
            this.StartJobProcessor();
        }

        private void CreateWorkingDirectory()
        {
            try
            {
                Directory.CreateDirectory(this.workDir);
                string escapedWorkDir = this.workDir.Replace(@"\", @"\\");
                this.Log($"Created temporary working directory for transcoding: <a href='#' onclick='window.external.OpenFolder(\"{escapedWorkDir}\"); return false;' style='cursor:pointer'><code>{this.workDir}</code></a>.");
            }
            catch (Exception ex) 
            {
                this.LogError($"cannot create temporary working directory: <code>{this.workDir}</code>. {ex.Message}");
            }
        }

        public void OpenFolder(string folderName)
        {
            Process.Start(folderName);
        }

        /// <summary>
        /// Creates a background timer to continously process the active jobs ([er 1 second)
        /// </summary>
        private void StartJobProcessor()
        {
            this.activeJobsProcessor = new System.Windows.Forms.Timer();
            this.activeJobsProcessor.Interval = 500;
            this.activeJobsProcessor.Tick += (sender, args) => 
            {
                ProcessJobsQueue();
            };
            this.activeJobsProcessor.Start();
        }

        private void Application_ProcessExit(object sender, EventArgs e)
        {
            // Delete all temp files on app exit
            Directory.Delete(this.workDir, true);
        }

        private void FormVideoUploader_Shown(object sender, EventArgs e)
        {
            this.buttonFTPConnect.PerformClick();
        }

        private async void buttonFTPConnect_Click(object sender, EventArgs e)
        {
            try
            {
                var ftpConnectForm = new FormConnectToFTP();
                if (ftpConnectForm.ShowDialog() != DialogResult.OK)
                    return;
                if (this.ftpClient != null)
                    this.ftpClient.Dispose();
                this.ftpClient = new FtpClient(
                    host: ftpConnectForm.Hostname,
                    user: ftpConnectForm.Username,
                    pass: ftpConnectForm.Password
                );
                ftpClient.SocketKeepAlive = true;
                ftpClient.DataConnectionType = FtpDataConnectionType.PASV;
                Log($"<i>Connecting to FTP server: <b>{this.ftpClient.Host}</b> ...</i>");
                await this.ftpClient.ConnectAsync();
                Log($"Connected to FTP server: <b>{this.ftpClient.Host}</b>.");
                this.textBoxFTPPath.Text = "/";

                LoadFilesAndFoldersFromFTP();
            }
            catch (Exception ex)
            {
                this.LogError(ex.Message);
            }
        }

        private void LoadFilesAndFoldersFromFTP()
        {
            if (this.ftpClient == null || (! this.ftpClient.IsConnected))
            {
                LogError("not connected to the FTP server");
                return;
            }

            try
            {
                FtpListItem[] ftpItems = this.ftpClient.GetListing(this.textBoxFTPPath.Text);

                var folders = ftpItems
                    .Where(item => item.Type == FtpFileSystemObjectType.Directory)
                    .Select(item => new { item.Name, Date = item.Modified.ToString() })
                    .ToList();
                this.dataGridViewFTPFolders.DataSource = folders;

                var files = ftpItems
                    .Where(item => item.Type == FtpFileSystemObjectType.File)
                    .Select(item => new { 
                        item.Name,
                        SizeAsText = $"{this.GetFileSizeAsText(item.Size)} ({item.Size})",
                        Date = item.Modified.ToString() 
                    })
                    .ToList();
                this.dataGridViewFTPFiles.DataSource = files;

                Log($"FTP navigated to folder: <b>{this.textBoxFTPPath.Text}</b>");
            }
            catch (Exception ex)
            {
                this.LogError($"FTP navigation failed. {ex.Message}");
            }
        }

        private void buttonFTPGo_Click(object sender, EventArgs e)
        {
            LoadFilesAndFoldersFromFTP();
        }

        private void buttonFTPUp_Click(object sender, EventArgs e)
        {
            string path = this.textBoxFTPPath.Text;
            if (path.EndsWith("/"))
                path = path.Substring(0, path.Length - 1);
            int lastSlashIndex = path.LastIndexOf('/');
            if (lastSlashIndex >= 0)
            {
                this.textBoxFTPPath.Text = path.Substring(0, lastSlashIndex + 1);
                LoadFilesAndFoldersFromFTP();
            }
            else
            {
                LogError("no parent folder");
            }
        }

        private void dataGridViewFTPFolders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string folder = 
                    this.dataGridViewFTPFolders.Rows[e.RowIndex].Cells[0].Value?.ToString();
                this.textBoxFTPPath.Text += folder + "/";
                LoadFilesAndFoldersFromFTP();
            }
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void ClearLog()
        {
            this.webBrowserLogs.Navigated += browserNavigated;
            this.webBrowserLogs.Navigate("about:blank");

            void browserNavigated(object sender, WebBrowserNavigatedEventArgs e)
            {
                // Initialize the CSS styles for the logger Web browser control
                this.webBrowserLogs.Document.Write(@"
                    <style>
                        body {font-family:arial; font-size:9pt}
                        code {display:inline-block; font-family:consolas; background:#eee; padding:1px 4px; border-radius:4px}
                    </style>                
                ");
                this.webBrowserLogs.Navigated -= browserNavigated;
                this.Log("Welcome to the <b>CDN Video Transcoder and Uploader</b> tool.");
            }
        }

        private void textBoxFTPPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                this.buttonFTPGo.PerformClick();
            }
        }

        private void buttonChooseFilesToUpload_Click(object sender, EventArgs e)
        {
            var selectFileDialog = new OpenFileDialog() {
                Filter = "Video files" + "|" + AllowedVideoFilesExtensions,
                Title = "Select a video file to upload",
                Multiselect = true
            };
            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in selectFileDialog.FileNames)
                {
                    AppendFileForProcessing(fileName);
                }
            }
        }

        private void AppendFileForProcessing(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            var fileExt = fileInfo.Extension.ToLower();
            if (fileExt == "" || AllowedVideoFilesExtensions.IndexOf(fileExt) == -1)
            {
                LogError($"invalid file: <code>{fileInfo.Name}</code>");
                return;
            }

            string ftpPath = this.textBoxFTPPath.Text;
            string hlsVideoURL = GetVideoUrl(ftpPath, fileInfo.Name);
            if (hlsVideoURL == null)
            {
                LogError($"Cannot find video URL pattern at the CDN for the current FTP path <code>{ftpPath}</code>. Choose an FTP folder first.");
                return;
            }

            List<ExecutableAction> actions = CreateActionsForFile(fileInfo);
            string fileSizeAsText = GetFileSizeAsText(fileInfo);
            var job = new Job()
            {
                Description = ftpPath + fileInfo.Name + " (" + fileSizeAsText + ")",
                PercentsDone = 0,
                Actions = actions,
                ActiveActionIndex = 0,
                VideoURL = hlsVideoURL
            };
            job.ExecutionStateChanged += Job_ExecutionStateChanged;
            job.ErrorOccurred += Job_ErrorOccurred;
            this.activeJobsQueue.Add(job);

            RefreshActiveJobsUI();
        }

        private string GetVideoUrl(string ftpPath, string shortFileName)
        {
            if (!ftpPath.EndsWith("/"))
                ftpPath += "/";
            foreach (string pattern in AppSettings.Default.VideoUrlPatternsAtCDN)
            {
                var patternParts = pattern.Split('|');
                string ftpRootFolder = patternParts[0].Trim();
                string videoUrlPattern = patternParts[1].Trim();
                if (ftpPath.StartsWith(ftpRootFolder))
                {
                    string ftpPathWithoutRoot = ftpPath.Remove(0, ftpRootFolder.Length);
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(shortFileName);
                    string profilesList = "," + GetVideoProfileNames().Join(",") + ",";
                    string hlsVideoURL = videoUrlPattern
                        .Replace("{input}", ftpPathWithoutRoot + fileNameWithoutExt)
                        .Replace("{profiles}", profilesList);
                    return hlsVideoURL;
                }
            }
            return null;
        }

        private List<ExecutableAction> CreateActionsForFile(FileInfo fileInfo)
        {
            var actions = new List<ExecutableAction>();
            foreach (string profile in AppSettings.Default.TranscodingProfiles)
            {
                var profileParts = profile.Split('|');
                string profileName = profileParts[0].Trim();
                string profileCommand = profileParts[1].Trim();

                string outputFileNameShort =
                    Path.GetFileNameWithoutExtension(fileInfo.Name) +
                    "-" + profileName + ".mp4";
                string outputFileNameFull = this.workDir + "\\" + outputFileNameShort;

                TranscodeAction transcodeAction = new TranscodeAction()
                {
                    Description = $"Transcoding {fileInfo.Name} to {profileName}",
                    InputFile = fileInfo.FullName,
                    TranscodingCommand = profileCommand
                        .Replace("{input}", '"' + fileInfo.FullName + '"')
                        .Replace("{output}", '"' + outputFileNameFull + '"'),
                    OutputFile = outputFileNameFull
                };
                transcodeAction.ExecutionStateChanged += TranscodeAction_ExecutionStateChanged;
                transcodeAction.ErrorOccurred += TranscodeAction_ErrorOccurred;
                actions.Add(transcodeAction);

                string ftpPath = this.textBoxFTPPath.Text;
                if (!ftpPath.EndsWith("/"))
                    ftpPath = ftpPath + "/";
                UploadAction uploadAction = new UploadAction()
                {
                    Description = $"Uploading {outputFileNameShort} to FTP folder {ftpPath}",
                    InputFile = outputFileNameFull,
                    FtpClient = new FtpClient(
                        this.ftpClient.Host,
                        this.ftpClient.Credentials
                    ),
                    PathAtFTP = ftpPath + outputFileNameShort,
                    DependsOnAction = transcodeAction
                };
                uploadAction.ExecutionStateChanged += UploadAction_ExecutionStateChanged;
                uploadAction.ErrorOccurred += UploadAction_ErrorOccurred;
                actions.Add(uploadAction);
            }

            return actions;
        }

        private void Job_ExecutionStateChanged(object sender, EventArgs e)
        {
            Job job = sender as Job;
            if (job.ExecutionState == ExecutionState.Running)
                this.Log($"Job <b>started</b>: <code>{job.Description}</code>");
            else if (job.ExecutionState == ExecutionState.CompletedSuccessfully)
                this.Log($"Job <b>completed successfully</b>: <code>{job.Description}</code>");
            else if (job.ExecutionState == ExecutionState.Failed)
                this.Log($"Job <b>failed</b>: <code>{job.Description}</code>");
            else if (job.ExecutionState == ExecutionState.Canceled)
                this.Log($"Job <b>canceled</b>: <code>{job.Description}</code>");
        }

        private void Job_ErrorOccurred(object sender, UnhandledExceptionEventArgs e)
        {
            Job job = sender as Job;
            this.LogError($"Job <b>failed</b>: <code>{job.Description}</code>");
            string errorMsg = CollectErrorsFromException(e);
            this.LogError(errTitle: "Job failed", errMsg: errorMsg, indentTabs: 1);
        }

        private void TranscodeAction_ExecutionStateChanged(object sender, EventArgs e)
        {
            TranscodeAction action = sender as TranscodeAction;
            if (action.ExecutionState == ExecutionState.Running)
                this.Log($"Transcoding <b>started</b>: <code>{action.Description}</code>", indentTabs: 1);
            else if (action.ExecutionState == ExecutionState.CompletedSuccessfully)
                this.Log($"Transcoding <b>successful</b>: <code>{action.Description}</code>", indentTabs: 1);
            else if (action.ExecutionState == ExecutionState.Failed)
                this.Log($"Transcoding <b>failed</b>: <code>{action.Description}</code>", indentTabs: 1);
            else if (action.ExecutionState == ExecutionState.Canceled)
                this.Log($"Transcoding <b>canceled</b>: <code>{action.Description}</code>", indentTabs: 1);
        }

        private void TranscodeAction_ErrorOccurred(object sender, UnhandledExceptionEventArgs e)
        {
            string errorMsg = CollectErrorsFromException(e);
            this.LogError(errTitle: "Transcoding error", errMsg: errorMsg, indentTabs: 1);
        }

        private void UploadAction_ExecutionStateChanged(object sender, EventArgs e)
        {
            UploadAction action = sender as UploadAction;
            if (action.ExecutionState == ExecutionState.Running)
                this.Log($"FTP upload <b>started</b>: <code>{action.Description}</code>", indentTabs: 1);
            else if (action.ExecutionState == ExecutionState.CompletedSuccessfully)
                this.Log($"FTP upload <b>successful</b>: <code>{action.Description}</code>", indentTabs: 1);
            else if (action.ExecutionState == ExecutionState.Failed)
                this.Log($"FTP upload <b>failed</b>: <code>{action.Description}</code>", indentTabs: 1);
            else if (action.ExecutionState == ExecutionState.Canceled)
                this.Log($"FTP upload <b>canceled</b>: <code>{action.Description}</code>", indentTabs: 1);
        }

        private void UploadAction_ErrorOccurred(object sender, UnhandledExceptionEventArgs e)
        {
            string errorMsg = CollectErrorsFromException(e);
            this.LogError(errTitle: "FTP upload error", errMsg: errorMsg, indentTabs: 1);
        }

        private List<string> GetVideoProfileNames()
        {
            List<string> profileNames = new List<string>();
            foreach (string profile in AppSettings.Default.TranscodingProfiles)
            {
                var profileParts = profile.Split('|');
                string profileName = profileParts[0].Trim();
                profileNames.Add(profileName);
            }
            return profileNames;
        }

        /// <summary>
        /// Refresh the "active jobs" data grid UI control to display the jobs queue
        /// </summary>
        private void RefreshActiveJobsUI()
        {
            this.dataGridViewActiveJobs.DataSource = null;
            this.dataGridViewActiveJobs.DataSource = this.activeJobsQueue;
        }

        /// <summary>
        /// Refresh the "completed jobs" data grid UI control to display the completed jobs
        /// </summary>
        private void RefreshCompletedJobsUI()
        {
            this.dataGridViewCompletedJobs.DataSource = null;
            this.dataGridViewCompletedJobs.DataSource = this.completedJobs;
        }

        private static string CollectErrorsFromException(UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex == null)
                return "unknown error";
            string errorMsg = ex.Message;
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                errorMsg += " --> " + ex.Message;
            }
            return errorMsg;
        }

        private string GetFileSizeAsText(long fileSize)
        {
            double sizeKB = fileSize / 1024.0;
            double sizeMB = sizeKB / 1024.0;
            double sizeGB = sizeMB / 1024.0;
            if (sizeGB >= 1)
                return Math.Round(sizeGB, 2) + " GB";
            if (sizeMB >= 1)
                return Math.Round(sizeMB, 2) + " MB";
            return Math.Round(sizeKB, 2) + " KB";
        }

        private string GetFileSizeAsText(FileInfo fileInfo)
        {
            string result = GetFileSizeAsText(fileInfo.Length);
            return result;
        }

        private void panelUploadBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void panelUploadBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string fileName in fileNames)
                AppendFileForProcessing(fileName);
        }

        private void ProcessJobsQueue()
        {
            for (int jobIndex = 0; jobIndex < this.activeJobsQueue.Count; jobIndex++)
            {
                Job job = this.activeJobsQueue[jobIndex];

                if (job.CanStart())
                    job.Start();

                if (job.ExecutionState == ExecutionState.Running)
                    job.UpdateState();

                if (job.IsFinished)
                {
                    // Terminate any job actions, which still run on the background
                    job.Cancel();

                    // Move the current job to the "completed jobs" list
                    this.activeJobsQueue.RemoveAt(jobIndex);
                    this.completedJobs.Add(job);
                    this.RefreshCompletedJobsUI();

                    // Continue correctly to the next job (after the current job, which is deleted)
                    jobIndex--;
                }

                this.RefreshActiveJobsUI();
            }
        }

        private void Log(string msg, int indentTabs = 0)
        {
            if (indentTabs > 0) 
                msg = $"<span style='padding-left:{indentTabs * 10}px'>{msg}</span>";

            // Update the UI through the main UI thread (thread safe)
            this.webBrowserLogs.Invoke((MethodInvoker)delegate {
                // Append the dateand time to the logs
                string date = DateTime.Now.ToString("d-MMM-yyyy HH:mm:ss");
                this.webBrowserLogs.Document.Write($"<span style='color:#999'>[{date}]</span> ");
                // Append the message to the logs
                this.webBrowserLogs.Document.Write(msg);
                // Append a new line
                this.webBrowserLogs.Document.Write("<br>\n");
                // Scroll to the document end
                this.webBrowserLogs.Document.Body.ScrollTop =
                    this.webBrowserLogs.Document.Body.ScrollRectangle.Height;
            });
        }

        private void LogError(string errMsg, string errTitle = "Error", int indentTabs = 0)
        {
            string formattedErrMsg = 
                $"<span style='color:#922'>{errTitle}: <b>{errMsg}</b></span>";
            Log(formattedErrMsg, indentTabs);
        }

        private void dataGridViewCompletedJobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < this.completedJobs.Count)
            {
                string hlsVideoURL = this.completedJobs[e.RowIndex].VideoURL;
                if (hlsVideoURL != null)
                {
                    Clipboard.SetText(hlsVideoURL);
                    this.Log($"HLS video URL copied to clipboard: <code>{hlsVideoURL}</code>");
                }
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            FormAppSettings formSettings = new FormAppSettings();
            formSettings.ShowDialog();
        }
    }
}
