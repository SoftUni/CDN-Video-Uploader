namespace CDN_Video_Uploader
{
    partial class FormVideoUploader
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVideoUploader));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelFTP = new System.Windows.Forms.Label();
            this.textBoxFTPPath = new System.Windows.Forms.TextBox();
            this.buttonFTPConnect = new System.Windows.Forms.Button();
            this.buttonFTPUp = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelUploadQueue = new System.Windows.Forms.Label();
            this.panelUploadBox = new System.Windows.Forms.Panel();
            this.pictureBoxUploadImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewFTPFolders = new System.Windows.Forms.DataGridView();
            this.ColumnFolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFolderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFTPFiles = new System.Windows.Forms.DataGridView();
            this.buttonFTPGo = new System.Windows.Forms.Button();
            this.webBrowserLogs = new System.Windows.Forms.WebBrowser();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.panelUploadBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFTPFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFTPFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFTP
            // 
            this.labelFTP.AutoSize = true;
            this.labelFTP.Location = new System.Drawing.Point(4, 8);
            this.labelFTP.Name = "labelFTP";
            this.labelFTP.Size = new System.Drawing.Size(191, 17);
            this.labelFTP.TabIndex = 0;
            this.labelFTP.Text = "Remote FTP folders and files";
            // 
            // textBoxFTPPath
            // 
            this.textBoxFTPPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFTPPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFTPPath.Location = new System.Drawing.Point(6, 32);
            this.textBoxFTPPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFTPPath.Name = "textBoxFTPPath";
            this.textBoxFTPPath.Size = new System.Drawing.Size(634, 24);
            this.textBoxFTPPath.TabIndex = 1;
            // 
            // buttonFTPConnect
            // 
            this.buttonFTPConnect.Location = new System.Drawing.Point(211, 5);
            this.buttonFTPConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFTPConnect.Name = "buttonFTPConnect";
            this.buttonFTPConnect.Size = new System.Drawing.Size(115, 23);
            this.buttonFTPConnect.TabIndex = 3;
            this.buttonFTPConnect.Text = "FTP Connect";
            this.buttonFTPConnect.UseVisualStyleBackColor = true;
            this.buttonFTPConnect.Click += new System.EventHandler(this.buttonFTPConnect_Click);
            // 
            // buttonFTPUp
            // 
            this.buttonFTPUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFTPUp.Location = new System.Drawing.Point(692, 31);
            this.buttonFTPUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFTPUp.Name = "buttonFTPUp";
            this.buttonFTPUp.Size = new System.Drawing.Size(40, 27);
            this.buttonFTPUp.TabIndex = 4;
            this.buttonFTPUp.Text = "Up";
            this.buttonFTPUp.UseVisualStyleBackColor = true;
            this.buttonFTPUp.Click += new System.EventHandler(this.buttonFTPUp_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Modified";
            // 
            // labelUploadQueue
            // 
            this.labelUploadQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUploadQueue.AutoSize = true;
            this.labelUploadQueue.Location = new System.Drawing.Point(735, 8);
            this.labelUploadQueue.Name = "labelUploadQueue";
            this.labelUploadQueue.Size = new System.Drawing.Size(97, 17);
            this.labelUploadQueue.TabIndex = 0;
            this.labelUploadQueue.Text = "Upload queue";
            // 
            // panelUploadBox
            // 
            this.panelUploadBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUploadBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUploadBox.Controls.Add(this.pictureBoxUploadImage);
            this.panelUploadBox.Controls.Add(this.label1);
            this.panelUploadBox.Location = new System.Drawing.Point(738, 32);
            this.panelUploadBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelUploadBox.Name = "panelUploadBox";
            this.panelUploadBox.Size = new System.Drawing.Size(626, 126);
            this.panelUploadBox.TabIndex = 6;
            // 
            // pictureBoxUploadImage
            // 
            this.pictureBoxUploadImage.ErrorImage = null;
            this.pictureBoxUploadImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUploadImage.Image")));
            this.pictureBoxUploadImage.InitialImage = null;
            this.pictureBoxUploadImage.Location = new System.Drawing.Point(286, 7);
            this.pictureBoxUploadImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxUploadImage.Name = "pictureBoxUploadImage";
            this.pictureBoxUploadImage.Size = new System.Drawing.Size(53, 50);
            this.pictureBoxUploadImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxUploadImage.TabIndex = 1;
            this.pictureBoxUploadImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(618, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drag and Drop Video Files Here to Upload";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewFTPFolders
            // 
            this.dataGridViewFTPFolders.AllowUserToDeleteRows = false;
            this.dataGridViewFTPFolders.AllowUserToOrderColumns = true;
            this.dataGridViewFTPFolders.AllowUserToResizeRows = false;
            this.dataGridViewFTPFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFTPFolders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFTPFolders.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFTPFolders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFTPFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFTPFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFolderName,
            this.ColumnFolderDate});
            this.dataGridViewFTPFolders.EnableHeadersVisualStyles = false;
            this.dataGridViewFTPFolders.Location = new System.Drawing.Point(6, 63);
            this.dataGridViewFTPFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewFTPFolders.MultiSelect = false;
            this.dataGridViewFTPFolders.Name = "dataGridViewFTPFolders";
            this.dataGridViewFTPFolders.RowHeadersVisible = false;
            this.dataGridViewFTPFolders.RowHeadersWidth = 51;
            this.dataGridViewFTPFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFTPFolders.Size = new System.Drawing.Size(726, 200);
            this.dataGridViewFTPFolders.TabIndex = 7;
            this.dataGridViewFTPFolders.Text = "dataGridView1";
            this.dataGridViewFTPFolders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFTPFolders_CellClick);
            // 
            // ColumnFolderName
            // 
            this.ColumnFolderName.DataPropertyName = "Name";
            this.ColumnFolderName.HeaderText = "Folder Name";
            this.ColumnFolderName.MinimumWidth = 6;
            this.ColumnFolderName.Name = "ColumnFolderName";
            this.ColumnFolderName.ReadOnly = true;
            this.ColumnFolderName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnFolderDate
            // 
            this.ColumnFolderDate.DataPropertyName = "Date";
            this.ColumnFolderDate.HeaderText = "Last Modified";
            this.ColumnFolderDate.MinimumWidth = 6;
            this.ColumnFolderDate.Name = "ColumnFolderDate";
            this.ColumnFolderDate.ReadOnly = true;
            this.ColumnFolderDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Folder Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn2.HeaderText = "Last Modified";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // ColumnFileName
            // 
            this.ColumnFileName.DataPropertyName = "Name";
            this.ColumnFileName.HeaderText = "File Name";
            this.ColumnFileName.MinimumWidth = 6;
            this.ColumnFileName.Name = "ColumnFileName";
            this.ColumnFileName.ReadOnly = true;
            // 
            // ColumnFileSize
            // 
            this.ColumnFileSize.DataPropertyName = "Size";
            this.ColumnFileSize.HeaderText = "FileSize";
            this.ColumnFileSize.MinimumWidth = 6;
            this.ColumnFileSize.Name = "ColumnFileSize";
            this.ColumnFileSize.ReadOnly = true;
            // 
            // ColumnFileDate
            // 
            this.ColumnFileDate.DataPropertyName = "Date";
            this.ColumnFileDate.HeaderText = "Last Modified";
            this.ColumnFileDate.MinimumWidth = 6;
            this.ColumnFileDate.Name = "ColumnFileDate";
            this.ColumnFileDate.ReadOnly = true;
            // 
            // dataGridViewFTPFiles
            // 
            this.dataGridViewFTPFiles.AllowUserToDeleteRows = false;
            this.dataGridViewFTPFiles.AllowUserToOrderColumns = true;
            this.dataGridViewFTPFiles.AllowUserToResizeRows = false;
            this.dataGridViewFTPFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFTPFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFTPFiles.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFTPFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFTPFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFTPFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFileName,
            this.ColumnFileSize,
            this.ColumnFileDate});
            this.dataGridViewFTPFiles.EnableHeadersVisualStyles = false;
            this.dataGridViewFTPFiles.Location = new System.Drawing.Point(6, 267);
            this.dataGridViewFTPFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewFTPFiles.MultiSelect = false;
            this.dataGridViewFTPFiles.Name = "dataGridViewFTPFiles";
            this.dataGridViewFTPFiles.RowHeadersVisible = false;
            this.dataGridViewFTPFiles.RowHeadersWidth = 51;
            this.dataGridViewFTPFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFTPFiles.Size = new System.Drawing.Size(726, 226);
            this.dataGridViewFTPFiles.TabIndex = 7;
            this.dataGridViewFTPFiles.Text = "dataGridView1";
            // 
            // buttonFTPGo
            // 
            this.buttonFTPGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFTPGo.Location = new System.Drawing.Point(646, 31);
            this.buttonFTPGo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFTPGo.Name = "buttonFTPGo";
            this.buttonFTPGo.Size = new System.Drawing.Size(40, 27);
            this.buttonFTPGo.TabIndex = 4;
            this.buttonFTPGo.Text = "Go";
            this.buttonFTPGo.UseVisualStyleBackColor = true;
            this.buttonFTPGo.Click += new System.EventHandler(this.buttonFTPGo_Click);
            // 
            // webBrowserLogs
            // 
            this.webBrowserLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserLogs.Location = new System.Drawing.Point(6, 498);
            this.webBrowserLogs.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserLogs.Name = "webBrowserLogs";
            this.webBrowserLogs.Size = new System.Drawing.Size(1359, 250);
            this.webBrowserLogs.TabIndex = 10;
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearLog.Location = new System.Drawing.Point(1267, 505);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(72, 28);
            this.buttonClearLog.TabIndex = 11;
            this.buttonClearLog.Text = "Clear log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // FormVideoUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 754);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.webBrowserLogs);
            this.Controls.Add(this.buttonFTPGo);
            this.Controls.Add(this.dataGridViewFTPFiles);
            this.Controls.Add(this.dataGridViewFTPFolders);
            this.Controls.Add(this.panelUploadBox);
            this.Controls.Add(this.labelUploadQueue);
            this.Controls.Add(this.buttonFTPUp);
            this.Controls.Add(this.buttonFTPConnect);
            this.Controls.Add(this.textBoxFTPPath);
            this.Controls.Add(this.labelFTP);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormVideoUploader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDN Video Uploader & Transcoder";
            this.Load += new System.EventHandler(this.FormVideoUploader_Load);
            this.Shown += new System.EventHandler(this.FormVideoUploader_Shown);
            this.panelUploadBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUploadImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFTPFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFTPFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFTP;
        private System.Windows.Forms.TextBox textBoxFTPPath;
        private System.Windows.Forms.Button buttonFTPConnect;
        private System.Windows.Forms.Button buttonFTPUp;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label labelUploadQueue;
        private System.Windows.Forms.Panel panelUploadBox;
        private System.Windows.Forms.PictureBox pictureBoxUploadImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileDate;
        private System.Windows.Forms.DataGridView dataGridViewFTPFiles;
        private System.Windows.Forms.Button buttonFTPGo;
        private System.Windows.Forms.WebBrowser webBrowserLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFolderDate;
        private System.Windows.Forms.DataGridView dataGridViewFTPFolders;
        private System.Windows.Forms.Button buttonClearLog;
    }
}

