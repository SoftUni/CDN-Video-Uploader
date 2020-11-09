using FluentFTP;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CDN_Video_Uploader
{
    public partial class FormVideoUploader : Form
    {
        public FtpClient FtpClient { get; set; }

        public FormVideoUploader()
        {
            InitializeComponent();
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
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }

            loadFilesAndFoldersFromFTP();
        }

        private void loadFilesAndFoldersFromFTP()
        {
            if (this.FtpClient == null || (! this.FtpClient.IsConnected))
            {
                Log("Error: <b>not connected to the FTP server</b>.");
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
                Log(ex.ToString());
            }
        }

        private void buttonFTPGo_Click(object sender, EventArgs e)
        {
            loadFilesAndFoldersFromFTP();
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
                loadFilesAndFoldersFromFTP();
            }
            else
            {
                Log("Error: <b>no parent folder</b>.");
            }
        }

        private void Log(string msg)
        {
            // Update the UI through the UI thread (thread safe)
            this.webBrowserLogs.Invoke((MethodInvoker)delegate {
                // Append the message to the logs
                this.webBrowserLogs.Document.Write(msg);
                // Append a new line
                this.webBrowserLogs.Document.Write("<br>\n");
                // Scroll to the document end
                this.webBrowserLogs.Document.Body.ScrollTop =
                    this.webBrowserLogs.Document.Body.ScrollRectangle.Height;
            });
        }

        private void FormVideoUploader_Load(object sender, EventArgs e)
        {
            this.clearLog();
        }

        private void dataGridViewFTPFolders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string folder = 
                    this.dataGridViewFTPFolders.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.textBoxFTPPath.Text += folder + "/";
                loadFilesAndFoldersFromFTP();
            }
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            clearLog();
        }

        private void clearLog()
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

        private void FormVideoUploader_Shown(object sender, EventArgs e)
        {
            this.buttonFTPConnect.PerformClick();
        }
    }
}
