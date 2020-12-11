using CDN_Video_Uploader.Properties;
using System;
using System.Windows.Forms;
using System.Linq;

namespace CDN_Video_Uploader.Forms
{
    public partial class FormAppSettings : Form
    {
        public FormAppSettings()
        {
            InitializeComponent();
        }

        private void FormAppSettings_Load(object sender, EventArgs e)
        {
            this.checkBoxSaveFTPCredentials.Checked =
                AppSettings.Default.SaveFTPCredentials;
            this.textBoxTranscodingProfiles.Lines =
                AppSettings.Default.TranscodingProfiles.Cast<string>().ToArray();
            this.textBoxVideoUrlPatterns.Lines =
                AppSettings.Default.VideoUrlPatternsAtCDN.Cast<string>().ToArray();
        }
    }
}
