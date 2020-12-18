
namespace CDN_Video_Uploader.Forms
{
    partial class FormViewJob
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox groupBoxJobDetails;
            System.Windows.Forms.Label labelState;
            System.Windows.Forms.Label labelProgress;
            System.Windows.Forms.Label labelJob;
            System.Windows.Forms.GroupBox groupBoxActions;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.GroupBox groupBoxLogs;
            this.buttonCancelJob = new System.Windows.Forms.Button();
            this.textBoxJobState = new System.Windows.Forms.TextBox();
            this.textBoxJobProgress = new System.Windows.Forms.TextBox();
            this.textBoxJobDescription = new System.Windows.Forms.TextBox();
            this.dataGridViewActions = new System.Windows.Forms.DataGridView();
            this.ColumnAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnActionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLogs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.timerRefreshUI = new System.Windows.Forms.Timer(this.components);
            groupBoxJobDetails = new System.Windows.Forms.GroupBox();
            labelState = new System.Windows.Forms.Label();
            labelProgress = new System.Windows.Forms.Label();
            labelJob = new System.Windows.Forms.Label();
            groupBoxActions = new System.Windows.Forms.GroupBox();
            groupBoxLogs = new System.Windows.Forms.GroupBox();
            groupBoxJobDetails.SuspendLayout();
            groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActions)).BeginInit();
            groupBoxLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxJobDetails
            // 
            groupBoxJobDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBoxJobDetails.Controls.Add(this.buttonCancelJob);
            groupBoxJobDetails.Controls.Add(this.textBoxJobState);
            groupBoxJobDetails.Controls.Add(labelState);
            groupBoxJobDetails.Controls.Add(this.textBoxJobProgress);
            groupBoxJobDetails.Controls.Add(labelProgress);
            groupBoxJobDetails.Controls.Add(this.textBoxJobDescription);
            groupBoxJobDetails.Controls.Add(labelJob);
            groupBoxJobDetails.Location = new System.Drawing.Point(12, 12);
            groupBoxJobDetails.Name = "groupBoxJobDetails";
            groupBoxJobDetails.Size = new System.Drawing.Size(1372, 113);
            groupBoxJobDetails.TabIndex = 0;
            groupBoxJobDetails.TabStop = false;
            groupBoxJobDetails.Text = "Job Details";
            // 
            // buttonCancelJob
            // 
            this.buttonCancelJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancelJob.Image = global::CDN_Video_Uploader.Properties.Resources.cancel_button_icon;
            this.buttonCancelJob.Location = new System.Drawing.Point(1193, 63);
            this.buttonCancelJob.Name = "buttonCancelJob";
            this.buttonCancelJob.Size = new System.Drawing.Size(163, 34);
            this.buttonCancelJob.TabIndex = 8;
            this.buttonCancelJob.Text = " Cancel Job";
            this.buttonCancelJob.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancelJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancelJob.UseVisualStyleBackColor = true;
            this.buttonCancelJob.Click += new System.EventHandler(this.buttonCancelJob_Click);
            // 
            // textBoxJobState
            // 
            this.textBoxJobState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxJobState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxJobState.Location = new System.Drawing.Point(54, 67);
            this.textBoxJobState.Name = "textBoxJobState";
            this.textBoxJobState.ReadOnly = true;
            this.textBoxJobState.Size = new System.Drawing.Size(1120, 27);
            this.textBoxJobState.TabIndex = 5;
            // 
            // labelState
            // 
            labelState.AutoSize = true;
            labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelState.Location = new System.Drawing.Point(7, 71);
            labelState.Name = "labelState";
            labelState.Size = new System.Drawing.Size(46, 18);
            labelState.TabIndex = 4;
            labelState.Text = "State:";
            // 
            // textBoxJobProgress
            // 
            this.textBoxJobProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxJobProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxJobProgress.Location = new System.Drawing.Point(1261, 24);
            this.textBoxJobProgress.Name = "textBoxJobProgress";
            this.textBoxJobProgress.ReadOnly = true;
            this.textBoxJobProgress.Size = new System.Drawing.Size(95, 27);
            this.textBoxJobProgress.TabIndex = 3;
            // 
            // labelProgress
            // 
            labelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            labelProgress.AutoSize = true;
            labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelProgress.Location = new System.Drawing.Point(1190, 28);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new System.Drawing.Size(73, 18);
            labelProgress.TabIndex = 2;
            labelProgress.Text = "Progress:";
            // 
            // textBoxJobDescription
            // 
            this.textBoxJobDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxJobDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxJobDescription.Location = new System.Drawing.Point(54, 24);
            this.textBoxJobDescription.Name = "textBoxJobDescription";
            this.textBoxJobDescription.ReadOnly = true;
            this.textBoxJobDescription.Size = new System.Drawing.Size(1120, 27);
            this.textBoxJobDescription.TabIndex = 1;
            // 
            // labelJob
            // 
            labelJob.AutoSize = true;
            labelJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelJob.Location = new System.Drawing.Point(7, 28);
            labelJob.Name = "labelJob";
            labelJob.Size = new System.Drawing.Size(37, 18);
            labelJob.TabIndex = 0;
            labelJob.Text = "Job:";
            // 
            // groupBoxActions
            // 
            groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBoxActions.Controls.Add(this.dataGridViewActions);
            groupBoxActions.Location = new System.Drawing.Point(12, 131);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Size = new System.Drawing.Size(1372, 240);
            groupBoxActions.TabIndex = 1;
            groupBoxActions.TabStop = false;
            groupBoxActions.Text = "Actions";
            // 
            // dataGridViewActions
            // 
            this.dataGridViewActions.AllowUserToAddRows = false;
            this.dataGridViewActions.AllowUserToDeleteRows = false;
            this.dataGridViewActions.AllowUserToOrderColumns = true;
            this.dataGridViewActions.AllowUserToResizeRows = false;
            this.dataGridViewActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewActions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewActions.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewActions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAction,
            this.ColumnActionType,
            this.ColumnState,
            this.ColumnProgress,
            this.ColumnFinished,
            this.ColumnTime,
            this.ColumnLogs});
            this.dataGridViewActions.EnableHeadersVisualStyles = false;
            this.dataGridViewActions.Location = new System.Drawing.Point(16, 26);
            this.dataGridViewActions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewActions.MultiSelect = false;
            this.dataGridViewActions.Name = "dataGridViewActions";
            this.dataGridViewActions.ReadOnly = true;
            this.dataGridViewActions.RowHeadersVisible = false;
            this.dataGridViewActions.RowHeadersWidth = 51;
            this.dataGridViewActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewActions.Size = new System.Drawing.Size(1340, 196);
            this.dataGridViewActions.TabIndex = 13;
            this.dataGridViewActions.Text = "dataGridView1";
            this.dataGridViewActions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewActions_CellClick);
            // 
            // ColumnAction
            // 
            this.ColumnAction.DataPropertyName = "Description";
            this.ColumnAction.FillWeight = 300F;
            this.ColumnAction.HeaderText = "Action";
            this.ColumnAction.MinimumWidth = 6;
            this.ColumnAction.Name = "ColumnAction";
            this.ColumnAction.ReadOnly = true;
            // 
            // ColumnActionType
            // 
            this.ColumnActionType.DataPropertyName = "ActionType";
            this.ColumnActionType.FillWeight = 50F;
            this.ColumnActionType.HeaderText = "Type";
            this.ColumnActionType.MinimumWidth = 6;
            this.ColumnActionType.Name = "ColumnActionType";
            this.ColumnActionType.ReadOnly = true;
            // 
            // ColumnState
            // 
            this.ColumnState.DataPropertyName = "StateAsText";
            this.ColumnState.FillWeight = 80F;
            this.ColumnState.HeaderText = "State";
            this.ColumnState.MinimumWidth = 6;
            this.ColumnState.Name = "ColumnState";
            this.ColumnState.ReadOnly = true;
            // 
            // ColumnProgress
            // 
            this.ColumnProgress.DataPropertyName = "ProgressAsText";
            this.ColumnProgress.FillWeight = 50F;
            this.ColumnProgress.HeaderText = "Progress";
            this.ColumnProgress.MinimumWidth = 6;
            this.ColumnProgress.Name = "ColumnProgress";
            this.ColumnProgress.ReadOnly = true;
            // 
            // ColumnFinished
            // 
            this.ColumnFinished.DataPropertyName = "IsFinished";
            this.ColumnFinished.FillWeight = 40F;
            this.ColumnFinished.HeaderText = "Finished";
            this.ColumnFinished.MinimumWidth = 6;
            this.ColumnFinished.Name = "ColumnFinished";
            this.ColumnFinished.ReadOnly = true;
            this.ColumnFinished.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnFinished.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnTime
            // 
            this.ColumnTime.DataPropertyName = "ExecutionTimeAsText";
            this.ColumnTime.FillWeight = 40F;
            this.ColumnTime.HeaderText = "Time";
            this.ColumnTime.MinimumWidth = 6;
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            // 
            // ColumnLogs
            // 
            this.ColumnLogs.DataPropertyName = "ExecutionLogForDisplay";
            this.ColumnLogs.FillWeight = 163.8594F;
            this.ColumnLogs.HeaderText = "Logs";
            this.ColumnLogs.MinimumWidth = 6;
            this.ColumnLogs.Name = "ColumnLogs";
            this.ColumnLogs.ReadOnly = true;
            // 
            // groupBoxLogs
            // 
            groupBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBoxLogs.Controls.Add(this.textBoxLogs);
            groupBoxLogs.Location = new System.Drawing.Point(12, 377);
            groupBoxLogs.Name = "groupBoxLogs";
            groupBoxLogs.Size = new System.Drawing.Size(1372, 284);
            groupBoxLogs.TabIndex = 2;
            groupBoxLogs.TabStop = false;
            groupBoxLogs.Text = "Logs";
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogs.Location = new System.Drawing.Point(16, 26);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.ReadOnly = true;
            this.textBoxLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogs.Size = new System.Drawing.Size(1340, 241);
            this.textBoxLogs.TabIndex = 0;
            // 
            // timerRefreshUI
            // 
            this.timerRefreshUI.Enabled = true;
            this.timerRefreshUI.Interval = 500;
            this.timerRefreshUI.Tick += new System.EventHandler(this.timerRefreshUI_Tick);
            // 
            // FormViewJob
            // 
            this.ClientSize = new System.Drawing.Size(1396, 673);
            this.Controls.Add(groupBoxLogs);
            this.Controls.Add(groupBoxActions);
            this.Controls.Add(groupBoxJobDetails);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormViewJob";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Job Details";
            this.Load += new System.EventHandler(this.FormViewJob_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormViewJob_KeyDown);
            groupBoxJobDetails.ResumeLayout(false);
            groupBoxJobDetails.PerformLayout();
            groupBoxActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActions)).EndInit();
            groupBoxLogs.ResumeLayout(false);
            groupBoxLogs.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Timer timerRefreshUI;
        private System.Windows.Forms.TextBox textBoxJobProgress;
        private System.Windows.Forms.TextBox textBoxJobDescription;
        private System.Windows.Forms.TextBox textBoxJobState;
        private System.Windows.Forms.Button buttonCancelJob;
        private System.Windows.Forms.DataGridView dataGridViewActions;
        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnActionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnState;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProgress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnFinished;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLogs;
    }
}