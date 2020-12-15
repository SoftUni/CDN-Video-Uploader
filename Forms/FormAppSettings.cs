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
            this.numericUpDownMaxParalelTranscodings.Value =
                AppSettings.Default.MaxParallelTranscodings;
            this.textBoxTranscodingProfiles.Lines =
                AppSettings.Default.TranscodingProfiles.Cast<string>().ToArray();
            this.textBoxVideoUrlPatterns.Lines =
                AppSettings.Default.VideoUrlPatternsAtCDN.Cast<string>().ToArray();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            AppSettings.Default.SaveFTPCredentials =
                this.checkBoxSaveFTPCredentials.Checked;
            if (! this.checkBoxSaveFTPCredentials.Checked)
            {
                // Clear saved credentiials
                AppSettings.Default.FtpPassword = "";
            }

            AppSettings.Default.MaxParallelTranscodings =
                (int) this.numericUpDownMaxParalelTranscodings.Value;

            AppSettings.Default.TranscodingProfiles.Clear();
            foreach (string profile in this.textBoxTranscodingProfiles.Lines)
                if (!String.IsNullOrWhiteSpace(profile))
                    AppSettings.Default.TranscodingProfiles.Add(profile.Trim());
            
            AppSettings.Default.VideoUrlPatternsAtCDN.Clear();
            foreach (string pattern in this.textBoxVideoUrlPatterns.Lines)
                if (!String.IsNullOrWhiteSpace(pattern))
                    AppSettings.Default.VideoUrlPatternsAtCDN.Add(pattern.Trim());

            AppSettings.Default.Save();
        }

        private void FormAppSettings_SizeChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                int newWidth = (this.ClientSize.Width - groupBoxFTPCredentials.Left * 2 - 10) / 2;
                this.groupBoxFTPCredentials.Width = newWidth;
                if (this.ClientSize.Width % 2 == 0)
                    newWidth--;
                this.groupBoxTranscodingActionsSettings.Width = newWidth;
                this.groupBoxTranscodingActionsSettings.Left = this.groupBoxFTPCredentials.Right + 10;
            }
        }
    }
}
