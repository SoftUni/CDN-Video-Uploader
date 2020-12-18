using CDN_Video_Uploader.Jobs;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CDN_Video_Uploader.Forms
{
    public partial class FormViewJob : Form
    {
        private Job job;
        private BindingList<ExecutableAction> actionsBindingList;

        public FormViewJob(Job job)
        {
            this.job = job;
            InitializeComponent();
            this.dataGridViewActions.AutoGenerateColumns = false;
        }

        private void FormViewJob_Load(object sender, EventArgs e)
        {
            this.actionsBindingList = new BindingList<ExecutableAction>(job.Actions);
            this.dataGridViewActions.DataSource = this.actionsBindingList;
            this.RefreshFormData();
            if (this.job.Actions.Count > 0)
                RefreshActionLogs(0);
        }

        private void timerRefreshUI_Tick(object sender, EventArgs e)
        {
            this.RefreshFormData();
        }

        private void RefreshFormData()
        {
            this.textBoxJobDescription.Text = job.Description;
            this.textBoxJobProgress.Text = job.ProgressAsText;
            this.textBoxJobState.Text = job.StateAsText;
            
            // Refresh all actions
            for (int index = 0; index < this.actionsBindingList.Count; index++)
                this.actionsBindingList.ResetItem(index);

            // Refresh the log for the selected action
            if (this.dataGridViewActions.CurrentRow != null)
            {
                RefreshActionLogs(this.dataGridViewActions.CurrentRow.Index);
            }
        }

        private void dataGridViewActions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                RefreshActionLogs(e.RowIndex);
        }

        private void RefreshActionLogs(int actionIndex)
        {
            ExecutableAction selectedAction = this.job.Actions[actionIndex];
            if (this.textBoxLogs.Text != selectedAction.ExecutionLogForDisplay)
                this.textBoxLogs.Text = selectedAction.ExecutionLogForDisplay;
        }

        private void FormViewJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void buttonCancelJob_Click(object sender, EventArgs e)
        {
            job.Cancel();
            this.Close();
        }
    }
}
