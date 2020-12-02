using System;
using System.ComponentModel.DataAnnotations;

namespace CDN_Video_Uploader.Jobs
{
    abstract class ExecutableAction
    {
        public string Description { get; set; }

        private ExecutionState executionState = ExecutionState.NotStarted;

        public ExecutionState ExecutionState
        {
            get => this.executionState;
            set
            {
                if (value != this.executionState)
                {
                    this.executionState = value;
                    OnExecutionStateChanged();
                }
            } 
        }

        public event EventHandler ExecutionStateChanged;

        protected virtual void OnExecutionStateChanged()
        {
            if (this.ExecutionStateChanged != null)
            {
                ExecutionStateChanged(this, null);
            }
        }

        [Range(0.0, 100.0)]
        public double PercentsDone { get; set; }

        public bool IsFinished
        {
            get => this.ExecutionState == ExecutionState.CompletedSuccessfully ||
                this.ExecutionState == ExecutionState.Failed ||
                this.ExecutionState == ExecutionState.Canceled;
        }

        public string ExecutionLog { get; protected set; } = "";
        protected void AppendToLog(string text)
        {
            if (String.IsNullOrEmpty(text))
                return;
            this.ExecutionLog += Environment.NewLine + text + Environment.NewLine;
        }

        public event UnhandledExceptionEventHandler ErrorOccurred;
        
        protected virtual void OnErrorOccurred(Exception ex)
        {
            this.AppendToLog("Error: " + ex);

            if (this.ErrorOccurred != null)
            {
                ErrorOccurred(this, new UnhandledExceptionEventArgs(ex, false));
            }
        }

        public abstract void Start();
        public abstract void UpdateState();
        public abstract void Cancel();
    }
}
