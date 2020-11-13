using CDN_Video_Uploader.Jobs;
using CDN_Video_Uploader.Properties;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDN_Video_Uploader
{
    enum MsgType { Info, Error }

    public partial class FormVideoUploader : Form
    {
        const string AllowedVideoFilesExtensions = "*.avi;*.mp4;*.mpg;*.mpeg;*.mov;*.mkv;*.webm;*.wmv";

        // Crate a working directory (temp folder) for the transcoded videos
        private readonly string workDir = 
            Path.GetTempPath() + "CDN-Video-Uploader";

        private FtpClient ftpClient;
        private List<Job> activeJobsQueue = new List<Job>();
        private List<Job> completedJobs = new List<Job>();
        private Task activeJobsProcessor;

        public FormVideoUploader()
        {
            InitializeComponent();
            this.dataGridViewActiveJobs.AutoGenerateColumns = false;
            this.dataGridViewCompletedJobs.AutoGenerateColumns = false;
        }

        private void FormVideoUploader_Load(object sender, EventArgs e)
        {
            ClearLog();
            StartJobProcessor();
        }

        private void StartJobProcessor()
        {
            // Create a background task to continously process the active jobs
            this.activeJobsProcessor = new Task(() =>
            {
                // At certain time interval (1 second), check the status of the currrent job.
                // If the job is completed -> move it the to completed jobs queue.
                while (true)
                {
                    Thread.Sleep(1000);
                    ProcessJobsQueue();
                }
            });
            this.activeJobsProcessor.Start();
        }

        private void FormVideoUploader_Shown(object sender, EventArgs e)
        {
            this.buttonFTPConnect.PerformClick();
        }

        private void buttonFTPConnect_Click(object sender, EventArgs e)
        {
            try
            {
                var ftpConnectForm = new FormConnectToFTP();
                if (ftpConnectForm.ShowDialog() != DialogResult.OK)
                    return;
                this.ftpClient = new FtpClient(
                    host: ftpConnectForm.Hostname,
                    user: ftpConnectForm.Username,
                    pass: ftpConnectForm.Password
                );
                ftpClient.SocketKeepAlive = true;
                this.ftpClient.Connect();
                this.textBoxFTPPath.Text = "/";
                Log($"Connected to FTP server: <b>{this.ftpClient.Host}</b>");

                LoadFilesAndFoldersFromFTP();
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
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
                    .Select(item => new { item.Name, item.Size, Date = item.Modified.ToString() })
                    .ToList();
                this.dataGridViewFTPFiles.DataSource = files;

                Log($"FTP navigated to folder: <b>{this.textBoxFTPPath.Text}</b>");
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
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
                this.webBrowserLogs.Document.Write("<p style='font-family:arial;font-size=9pt'>\n");
                this.webBrowserLogs.Navigated -= browserNavigated;
                this.Log("Welcome to the <b>CDN Video Transcoder and Uploader</b> tool.");
            }
        }

        private void LogError(string errMsg)
        {
            Log(errMsg, MsgType.Error);
        }
 
        private void Log(string msg, MsgType msgType = MsgType.Info)
        {
            if (msgType == MsgType.Error)
            {
                msg = $"<span style='color:#922'>Error:<b>{msg}</b></span>";
            }
            // Update the UI through the UI thread (thread safe)
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
                LogError("invalid file: " + fileInfo.Name);
                return;
            }

            string fileSizeAsText = GetFileSizeAsText(fileInfo);

            List<ExecutableAction> actions = CreateActionsForFile(fileInfo);
            var task = new Job()
            {
                Description = fileInfo.Name + " (" + fileSizeAsText + ")",
                PercentsDone = 0,
                SourceFileName = fileName,
                Actions = actions,
                ActiveActionIndex = 0,
            };
            this.activeJobsQueue.Add(task);

            RefreshActiveJobsUI();
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
                actions.Add(transcodeAction);

                string ftpPath = this.textBoxFTPPath.Text;
                UploadAction uploadAction = new UploadAction()
                {
                    Description = $"Uploading {outputFileNameShort} to FTP folder {ftpPath}",
                    InputFile = outputFileNameFull,
                    PathAtFTP = ftpPath,
                };
                actions.Add(uploadAction);
            }

            return actions;
        }

        private string GetFileSizeAsText(FileInfo fileInfo)
        {
            double sizeKB = fileInfo.Length / 1024.0;
            double sizeMB = sizeKB / 1024.0;
            double sizeGB = sizeMB / 1024.0;
            if (sizeGB >= 1)
                return Math.Round(sizeGB, 2) + " GB";
            if (sizeMB >= 1)
                return Math.Round(sizeMB, 2) + " MB";
            return Math.Round(sizeKB, 2) + " KB";
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
            if (this.activeJobsQueue.Count > 0)
            {
                Job activeJob = this.activeJobsQueue[0];
                if (activeJob.ExecutionState == ExecutionState.NotStarted)
                {
                    activeJob.Start();
                    this.Log("Started job: " + activeJob.Description);
                }
                activeJob.UpdateState();
                if (activeJob.IsFinished)
                {
                    // Move the current job to the "completed jobs" list
                    this.activeJobsQueue.RemoveAt(0);
                    
                    this.completedJobs.Add(activeJob);
                    this.RefreshCompletedJobsUI();
                    this.Log("Completed job: " + activeJob.Description);

                    // Start immediately the next job
                    ProcessJobsQueue(); 
                }

                this.RefreshActiveJobsUI();
            }
        }
    }
}
