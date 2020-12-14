using CDN_Video_Uploader.Properties;
using System.Windows.Forms;

namespace CDN_Video_Uploader
{
    public partial class FormConnectToFTP : Form
    {
        public FormConnectToFTP()
        {
            InitializeComponent();
        }

        public string Hostname { get => this.textBoxHostname.Text; }
        public string Username { get => this.textBoxUsername.Text; }
        public string Password { get => this.textBoxPassword.Text; }

        private void FormConnectToFTP_Load(object sender, System.EventArgs e)
        {
            this.textBoxHostname.Text = AppSettings.Default.FtpHostname;
            this.textBoxUsername.Text = AppSettings.Default.FtpUsername;
            this.textBoxPassword.Text = AppSettings.Default.FtpPassword;
        }

        private void buttonConnect_Click(object sender, System.EventArgs e)
        {
            AppSettings.Default.FtpHostname = this.textBoxHostname.Text;
            AppSettings.Default.FtpUsername = this.textBoxUsername.Text;
            if (AppSettings.Default.SaveFTPCredentials)
            {
                AppSettings.Default.FtpPassword = this.textBoxPassword.Text;
            }
            AppSettings.Default.Save();
        }
    }
}
