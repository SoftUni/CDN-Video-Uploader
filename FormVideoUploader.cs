using FluentFTP;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CDN_Video_Uploader
{
    enum MsgType { Info, Error}

    public partial class FormVideoUploader : Form
    {
        public FtpClient FtpClient { get; set; }

        public FormVideoUploader()
        {
            InitializeComponent();
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
                this.FtpClient = new FtpClient(
                    host: ftpConnectForm.Hostname,
                    user: ftpConnectForm.Username,
                    pass: ftpConnectForm.Password
                );
                FtpClient.SocketKeepAlive = true;
                this.FtpClient.Connect();
                this.textBoxFTPPath.Text = "/";
                Log($"Connected to FTP server: <b>{this.FtpClient.Host}</b>");

                LoadFilesAndFoldersFromFTP();
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }

        private void LoadFilesAndFoldersFromFTP()
        {
            if (this.FtpClient == null || (! this.FtpClient.IsConnected))
            {
                LogError("not connected to the FTP server");
                return;
            }

            try
            {
                FtpListItem[] ftpItems = this.FtpClient.GetListing(this.textBoxFTPPath.Text);

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

        private void FormVideoUploader_Load(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void dataGridViewFTPFolders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string folder = 
                    this.dataGridViewFTPFolders.Rows[e.RowIndex].Cells[0].Value.ToString();
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
    }
}
