
namespace CDN_Video_Uploader.Forms
{
    partial class FormAppSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxSaveFTPCredentials = new System.Windows.Forms.CheckBox();
            this.groupBoxFTPCredentials = new System.Windows.Forms.GroupBox();
            this.groupBoxTranscodingProfiles = new System.Windows.Forms.GroupBox();
            this.textBoxTranscodingProfiles = new System.Windows.Forms.TextBox();
            this.textBoxVideoUrlPatterns = new System.Windows.Forms.TextBox();
            this.groupBoxVideoUrlPatterns = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxTranscodingActionsSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMaxParalelTranscodings = new System.Windows.Forms.NumericUpDown();
            this.groupBoxFTPCredentials.SuspendLayout();
            this.groupBoxTranscodingProfiles.SuspendLayout();
            this.groupBoxVideoUrlPatterns.SuspendLayout();
            this.groupBoxTranscodingActionsSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxParalelTranscodings)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxSaveFTPCredentials
            // 
            this.checkBoxSaveFTPCredentials.AutoSize = true;
            this.checkBoxSaveFTPCredentials.Location = new System.Drawing.Point(13, 25);
            this.checkBoxSaveFTPCredentials.Name = "checkBoxSaveFTPCredentials";
            this.checkBoxSaveFTPCredentials.Size = new System.Drawing.Size(239, 21);
            this.checkBoxSaveFTPCredentials.TabIndex = 1;
            this.checkBoxSaveFTPCredentials.Text = "Save FTP credentials on connect";
            this.checkBoxSaveFTPCredentials.UseVisualStyleBackColor = true;
            // 
            // groupBoxFTPCredentials
            // 
            this.groupBoxFTPCredentials.Controls.Add(this.checkBoxSaveFTPCredentials);
            this.groupBoxFTPCredentials.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFTPCredentials.Name = "groupBoxFTPCredentials";
            this.groupBoxFTPCredentials.Size = new System.Drawing.Size(669, 59);
            this.groupBoxFTPCredentials.TabIndex = 3;
            this.groupBoxFTPCredentials.TabStop = false;
            this.groupBoxFTPCredentials.Text = "FTP Credentials";
            // 
            // groupBoxTranscodingProfiles
            // 
            this.groupBoxTranscodingProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTranscodingProfiles.Controls.Add(this.textBoxTranscodingProfiles);
            this.groupBoxTranscodingProfiles.Location = new System.Drawing.Point(12, 77);
            this.groupBoxTranscodingProfiles.Name = "groupBoxTranscodingProfiles";
            this.groupBoxTranscodingProfiles.Size = new System.Drawing.Size(1353, 235);
            this.groupBoxTranscodingProfiles.TabIndex = 4;
            this.groupBoxTranscodingProfiles.TabStop = false;
            this.groupBoxTranscodingProfiles.Text = "Video Transcoding Profiles";
            // 
            // textBoxTranscodingProfiles
            // 
            this.textBoxTranscodingProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTranscodingProfiles.Location = new System.Drawing.Point(7, 22);
            this.textBoxTranscodingProfiles.Multiline = true;
            this.textBoxTranscodingProfiles.Name = "textBoxTranscodingProfiles";
            this.textBoxTranscodingProfiles.Size = new System.Drawing.Size(1340, 207);
            this.textBoxTranscodingProfiles.TabIndex = 0;
            // 
            // textBoxVideoUrlPatterns
            // 
            this.textBoxVideoUrlPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVideoUrlPatterns.Location = new System.Drawing.Point(7, 22);
            this.textBoxVideoUrlPatterns.Multiline = true;
            this.textBoxVideoUrlPatterns.Name = "textBoxVideoUrlPatterns";
            this.textBoxVideoUrlPatterns.Size = new System.Drawing.Size(1340, 148);
            this.textBoxVideoUrlPatterns.TabIndex = 0;
            // 
            // groupBoxVideoUrlPatterns
            // 
            this.groupBoxVideoUrlPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxVideoUrlPatterns.Controls.Add(this.textBoxVideoUrlPatterns);
            this.groupBoxVideoUrlPatterns.Location = new System.Drawing.Point(12, 321);
            this.groupBoxVideoUrlPatterns.Name = "groupBoxVideoUrlPatterns";
            this.groupBoxVideoUrlPatterns.Size = new System.Drawing.Size(1353, 176);
            this.groupBoxVideoUrlPatterns.TabIndex = 5;
            this.groupBoxVideoUrlPatterns.TabStop = false;
            this.groupBoxVideoUrlPatterns.Text = "Video URL Patterns at the CDN";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Image = global::CDN_Video_Uploader.Properties.Resources.cancel_button_icon;
            this.buttonCancel.Location = new System.Drawing.Point(1211, 504);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(148, 44);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = " Cancel";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Image = global::CDN_Video_Uploader.Properties.Resources.save_icon;
            this.buttonSave.Location = new System.Drawing.Point(1043, 504);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 44);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = " Save";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxTranscodingActionsSettings
            // 
            this.groupBoxTranscodingActionsSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTranscodingActionsSettings.Controls.Add(this.label1);
            this.groupBoxTranscodingActionsSettings.Controls.Add(this.numericUpDownMaxParalelTranscodings);
            this.groupBoxTranscodingActionsSettings.Location = new System.Drawing.Point(696, 12);
            this.groupBoxTranscodingActionsSettings.Name = "groupBoxTranscodingActionsSettings";
            this.groupBoxTranscodingActionsSettings.Size = new System.Drawing.Size(669, 59);
            this.groupBoxTranscodingActionsSettings.TabIndex = 4;
            this.groupBoxTranscodingActionsSettings.TabStop = false;
            this.groupBoxTranscodingActionsSettings.Text = "Transcoding Actions Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maximum parallel transcoding actions:";
            // 
            // numericUpDownMaxParalelTranscodings
            // 
            this.numericUpDownMaxParalelTranscodings.Location = new System.Drawing.Point(263, 25);
            this.numericUpDownMaxParalelTranscodings.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDownMaxParalelTranscodings.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxParalelTranscodings.Name = "numericUpDownMaxParalelTranscodings";
            this.numericUpDownMaxParalelTranscodings.Size = new System.Drawing.Size(48, 22);
            this.numericUpDownMaxParalelTranscodings.TabIndex = 0;
            this.numericUpDownMaxParalelTranscodings.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1377, 563);
            this.Controls.Add(this.groupBoxTranscodingActionsSettings);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxVideoUrlPatterns);
            this.Controls.Add(this.groupBoxTranscodingProfiles);
            this.Controls.Add(this.groupBoxFTPCredentials);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormAppSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormAppSettings_Load);
            this.SizeChanged += new System.EventHandler(this.FormAppSettings_SizeChanged);
            this.groupBoxFTPCredentials.ResumeLayout(false);
            this.groupBoxFTPCredentials.PerformLayout();
            this.groupBoxTranscodingProfiles.ResumeLayout(false);
            this.groupBoxTranscodingProfiles.PerformLayout();
            this.groupBoxVideoUrlPatterns.ResumeLayout(false);
            this.groupBoxVideoUrlPatterns.PerformLayout();
            this.groupBoxTranscodingActionsSettings.ResumeLayout(false);
            this.groupBoxTranscodingActionsSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxParalelTranscodings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxSaveFTPCredentials;
        private System.Windows.Forms.GroupBox groupBoxFTPCredentials;
        private System.Windows.Forms.GroupBox groupBoxTranscodingProfiles;
        private System.Windows.Forms.TextBox textBoxTranscodingProfiles;
        private System.Windows.Forms.TextBox textBoxVideoUrlPatterns;
        private System.Windows.Forms.GroupBox groupBoxVideoUrlPatterns;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxTranscodingActionsSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxParalelTranscodings;
    }
}