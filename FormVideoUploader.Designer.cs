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
            System.Windows.Forms.PictureBox pictureBoxUploadImage;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVideoUploader));
            System.Windows.Forms.Label labelDragAndDropFiles;
            System.Windows.Forms.Label labelOr;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelFTP = new System.Windows.Forms.Label();
            this.textBoxFTPPath = new System.Windows.Forms.TextBox();
            this.buttonFTPConnect = new System.Windows.Forms.Button();
            this.buttonFTPUp = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelQueue = new System.Windows.Forms.Label();
            this.panelUploadBox = new System.Windows.Forms.Panel();
            this.buttonChooseFilesToUpload = new System.Windows.Forms.Button();
            this.dataGridViewFTPFolders = new System.Windows.Forms.DataGridView();
            this.ColumnFolderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFolderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewFTPFiles = new System.Windows.Forms.DataGridView();
            this.buttonFTPGo = new System.Windows.Forms.Button();
            this.webBrowserLogs = new System.Windows.Forms.WebBrowser();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.dataGridViewActiveJobs = new System.Windows.Forms.DataGridView();
            this.dataGridViewCompletedJobs = new System.Windows.Forms.DataGridView();
            this.ColumnCompletedJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVideoURL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ColumnJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pictureBoxUploadImage = new System.Windows.Forms.PictureBox();
            labelDragAndDropFiles = new System.Windows.Forms.Label();
            labelOr = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxUploadImage)).BeginInit();
            this.panelUploadBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFTPFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFTPFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActiveJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompletedJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxUploadImage
            // 
            pictureBoxUploadImage.ErrorImage = null;
            pictureBoxUploadImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUploadImage.Image")));
            pictureBoxUploadImage.InitialImage = null;
            pictureBoxUploadImage.Location = new System.Drawing.Point(12, 12);
            pictureBoxUploadImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pictureBoxUploadImage.Name = "pictureBoxUploadImage";
            pictureBoxUploadImage.Size = new System.Drawing.Size(77, 72);
            pictureBoxUploadImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxUploadImage.TabIndex = 1;
            pictureBoxUploadImage.TabStop = false;
            // 
            // labelDragAndDropFiles
            // 
            labelDragAndDropFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelDragAndDropFiles.Location = new System.Drawing.Point(95, 12);
            labelDragAndDropFiles.Name = "labelDragAndDropFiles";
            labelDragAndDropFiles.Size = new System.Drawing.Size(524, 23);
            labelDragAndDropFiles.TabIndex = 0;
            labelDragAndDropFiles.Text = "Drag and Drop Video Files Here to Transcode and Upload";
            labelDragAndDropFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOr
            // 
            labelOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelOr.Location = new System.Drawing.Point(244, 45);
            labelOr.Name = "labelOr";
            labelOr.Size = new System.Drawing.Size(29, 33);
            labelOr.TabIndex = 3;
            labelOr.Text = "or";
            labelOr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFTP
            // 
            this.labelFTP.AutoSize = true;
            this.labelFTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFTP.Location = new System.Drawing.Point(4, 11);
            this.labelFTP.Name = "labelFTP";
            this.labelFTP.Size = new System.Drawing.Size(200, 18);
            this.labelFTP.TabIndex = 0;
            this.labelFTP.Text = "Remote FTP folders and files";
            // 
            // textBoxFTPPath
            // 
            this.textBoxFTPPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFTPPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFTPPath.Location = new System.Drawing.Point(6, 34);
            this.textBoxFTPPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFTPPath.Name = "textBoxFTPPath";
            this.textBoxFTPPath.Size = new System.Drawing.Size(634, 24);
            this.textBoxFTPPath.TabIndex = 1;
            this.textBoxFTPPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFTPPath_KeyPress);
            // 
            // buttonFTPConnect
            // 
            this.buttonFTPConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFTPConnect.Location = new System.Drawing.Point(210, 4);
            this.buttonFTPConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFTPConnect.Name = "buttonFTPConnect";
            this.buttonFTPConnect.Size = new System.Drawing.Size(115, 26);
            this.buttonFTPConnect.TabIndex = 3;
            this.buttonFTPConnect.Text = "FTP Connect";
            this.buttonFTPConnect.UseVisualStyleBackColor = true;
            this.buttonFTPConnect.Click += new System.EventHandler(this.buttonFTPConnect_Click);
            // 
            // buttonFTPUp
            // 
            this.buttonFTPUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFTPUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFTPUp.Location = new System.Drawing.Point(692, 33);
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
            // labelQueue
            // 
            this.labelQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQueue.AutoSize = true;
            this.labelQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQueue.Location = new System.Drawing.Point(735, 11);
            this.labelQueue.Name = "labelQueue";
            this.labelQueue.Size = new System.Drawing.Size(99, 18);
            this.labelQueue.TabIndex = 0;
            this.labelQueue.Text = "Upload queue";
            // 
            // panelUploadBox
            // 
            this.panelUploadBox.AllowDrop = true;
            this.panelUploadBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUploadBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUploadBox.Controls.Add(labelOr);
            this.panelUploadBox.Controls.Add(this.buttonChooseFilesToUpload);
            this.panelUploadBox.Controls.Add(pictureBoxUploadImage);
            this.panelUploadBox.Controls.Add(labelDragAndDropFiles);
            this.panelUploadBox.Location = new System.Drawing.Point(738, 34);
            this.panelUploadBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelUploadBox.Name = "panelUploadBox";
            this.panelUploadBox.Size = new System.Drawing.Size(626, 98);
            this.panelUploadBox.TabIndex = 6;
            this.panelUploadBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelUploadBox_DragDrop);
            this.panelUploadBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelUploadBox_DragEnter);
            // 
            // buttonChooseFilesToUpload
            // 
            this.buttonChooseFilesToUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChooseFilesToUpload.Location = new System.Drawing.Point(279, 45);
            this.buttonChooseFilesToUpload.Name = "buttonChooseFilesToUpload";
            this.buttonChooseFilesToUpload.Size = new System.Drawing.Size(192, 33);
            this.buttonChooseFilesToUpload.TabIndex = 2;
            this.buttonChooseFilesToUpload.Text = "Choose Files to Upload ...";
            this.buttonChooseFilesToUpload.UseVisualStyleBackColor = true;
            this.buttonChooseFilesToUpload.Click += new System.EventHandler(this.buttonChooseFilesToUpload_Click);
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
            this.dataGridViewFTPFolders.Location = new System.Drawing.Point(6, 64);
            this.dataGridViewFTPFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewFTPFolders.MultiSelect = false;
            this.dataGridViewFTPFolders.Name = "dataGridViewFTPFolders";
            this.dataGridViewFTPFolders.RowHeadersVisible = false;
            this.dataGridViewFTPFolders.RowHeadersWidth = 51;
            this.dataGridViewFTPFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFTPFolders.Size = new System.Drawing.Size(726, 197);
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
            this.dataGridViewFTPFiles.Location = new System.Drawing.Point(6, 265);
            this.dataGridViewFTPFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.buttonFTPGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFTPGo.Location = new System.Drawing.Point(646, 33);
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
            this.webBrowserLogs.Location = new System.Drawing.Point(6, 496);
            this.webBrowserLogs.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserLogs.Name = "webBrowserLogs";
            this.webBrowserLogs.Size = new System.Drawing.Size(1359, 252);
            this.webBrowserLogs.TabIndex = 10;
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClearLog.Location = new System.Drawing.Point(1267, 505);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(72, 28);
            this.buttonClearLog.TabIndex = 11;
            this.buttonClearLog.Text = "Clear log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.buttonClearLog_Click);
            // 
            // dataGridViewActiveJobs
            // 
            this.dataGridViewActiveJobs.AllowUserToDeleteRows = false;
            this.dataGridViewActiveJobs.AllowUserToOrderColumns = true;
            this.dataGridViewActiveJobs.AllowUserToResizeRows = false;
            this.dataGridViewActiveJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewActiveJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewActiveJobs.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewActiveJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewActiveJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActiveJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnJob,
            this.ColumnState,
            this.ColumnProgress});
            this.dataGridViewActiveJobs.EnableHeadersVisualStyles = false;
            this.dataGridViewActiveJobs.Location = new System.Drawing.Point(738, 136);
            this.dataGridViewActiveJobs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewActiveJobs.MultiSelect = false;
            this.dataGridViewActiveJobs.Name = "dataGridViewActiveJobs";
            this.dataGridViewActiveJobs.RowHeadersVisible = false;
            this.dataGridViewActiveJobs.RowHeadersWidth = 51;
            this.dataGridViewActiveJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActiveJobs.Size = new System.Drawing.Size(626, 170);
            this.dataGridViewActiveJobs.TabIndex = 12;
            this.dataGridViewActiveJobs.Text = "dataGridView1";
            // 
            // dataGridViewCompletedJobs
            // 
            this.dataGridViewCompletedJobs.AllowUserToDeleteRows = false;
            this.dataGridViewCompletedJobs.AllowUserToOrderColumns = true;
            this.dataGridViewCompletedJobs.AllowUserToResizeRows = false;
            this.dataGridViewCompletedJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCompletedJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCompletedJobs.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCompletedJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCompletedJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompletedJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCompletedJob,
            this.ColumnResult,
            this.ColumnVideoURL});
            this.dataGridViewCompletedJobs.EnableHeadersVisualStyles = false;
            this.dataGridViewCompletedJobs.Location = new System.Drawing.Point(739, 310);
            this.dataGridViewCompletedJobs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewCompletedJobs.MultiSelect = false;
            this.dataGridViewCompletedJobs.Name = "dataGridViewCompletedJobs";
            this.dataGridViewCompletedJobs.RowHeadersVisible = false;
            this.dataGridViewCompletedJobs.RowHeadersWidth = 51;
            this.dataGridViewCompletedJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCompletedJobs.Size = new System.Drawing.Size(626, 181);
            this.dataGridViewCompletedJobs.TabIndex = 13;
            this.dataGridViewCompletedJobs.Text = "dataGridView1";
            this.dataGridViewCompletedJobs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompletedJobs_CellClick);
            // 
            // ColumnCompletedJob
            // 
            this.ColumnCompletedJob.DataPropertyName = "Description";
            this.ColumnCompletedJob.FillWeight = 191.2675F;
            this.ColumnCompletedJob.HeaderText = "Completed Job";
            this.ColumnCompletedJob.MinimumWidth = 6;
            this.ColumnCompletedJob.Name = "ColumnCompletedJob";
            this.ColumnCompletedJob.ReadOnly = true;
            // 
            // ColumnResult
            // 
            this.ColumnResult.DataPropertyName = "StateAsText";
            this.ColumnResult.HeaderText = "Result";
            this.ColumnResult.MinimumWidth = 6;
            this.ColumnResult.Name = "ColumnResult";
            // 
            // ColumnVideoURL
            // 
            this.ColumnVideoURL.DataPropertyName = "VideoURL";
            this.ColumnVideoURL.FillWeight = 58.81188F;
            this.ColumnVideoURL.HeaderText = "Video URL";
            this.ColumnVideoURL.MinimumWidth = 6;
            this.ColumnVideoURL.Name = "ColumnVideoURL";
            this.ColumnVideoURL.ReadOnly = true;
            this.ColumnVideoURL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnVideoURL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnJob
            // 
            this.ColumnJob.DataPropertyName = "Description";
            this.ColumnJob.FillWeight = 191.2675F;
            this.ColumnJob.HeaderText = "Job";
            this.ColumnJob.MinimumWidth = 6;
            this.ColumnJob.Name = "ColumnJob";
            this.ColumnJob.ReadOnly = true;
            // 
            // ColumnState
            // 
            this.ColumnState.DataPropertyName = "StateAsText";
            this.ColumnState.FillWeight = 191.2675F;
            this.ColumnState.HeaderText = "State";
            this.ColumnState.MinimumWidth = 6;
            this.ColumnState.Name = "ColumnState";
            this.ColumnState.ReadOnly = true;
            // 
            // ColumnProgress
            // 
            this.ColumnProgress.DataPropertyName = "ProgressAsText";
            this.ColumnProgress.FillWeight = 58.81188F;
            this.ColumnProgress.HeaderText = "Progress";
            this.ColumnProgress.MinimumWidth = 6;
            this.ColumnProgress.Name = "ColumnProgress";
            this.ColumnProgress.ReadOnly = true;
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
            this.ColumnFileSize.DataPropertyName = "SizeAsText";
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
            // FormVideoUploader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1370, 754);
            this.Controls.Add(this.dataGridViewCompletedJobs);
            this.Controls.Add(this.dataGridViewActiveJobs);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.webBrowserLogs);
            this.Controls.Add(this.buttonFTPGo);
            this.Controls.Add(this.dataGridViewFTPFiles);
            this.Controls.Add(this.dataGridViewFTPFolders);
            this.Controls.Add(this.panelUploadBox);
            this.Controls.Add(this.labelQueue);
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
            ((System.ComponentModel.ISupportInitialize)(pictureBoxUploadImage)).EndInit();
            this.panelUploadBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFTPFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFTPFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActiveJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompletedJobs)).EndInit();
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
        private System.Windows.Forms.Label labelQueue;
        private System.Windows.Forms.Panel panelUploadBox;
        private System.Windows.Forms.DataGridView dataGridViewFTPFiles;
        private System.Windows.Forms.Button buttonFTPGo;
        private System.Windows.Forms.WebBrowser webBrowserLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFolderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFolderDate;
        private System.Windows.Forms.DataGridView dataGridViewFTPFolders;
        private System.Windows.Forms.Button buttonClearLog;
        private System.Windows.Forms.Button buttonChooseFilesToUpload;
        private System.Windows.Forms.DataGridView dataGridViewActiveJobs;
        private System.Windows.Forms.DataGridView dataGridViewCompletedJobs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCompletedJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResult;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnVideoURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileDate;
    }
}

