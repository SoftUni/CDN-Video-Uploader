using System;
using System.ComponentModel.DataAnnotations;

namespace CDN_Video_Uploader.Jobs
{
    public abstract class ExecutableAction
    {
        public string Description { get; set; }

        public abstract string ActionType { get; }

        private ExecutionState executionState = ExecutionState.NotStarted;

        public ExecutionState ExecutionState
        {
            get => this.executionState;
            set
            {
                if (value != this.executionState)
                {
                    ExecutionState previousExecutionState = this.executionState;
                    this.executionState = value;
                    this.AppendToLog($"Action state changed: {this.StateAsText}");
                    if (this.IsRunning)
                    {
                        // The execution has just started
                        this.DateTimeStarted = DateTime.Now;
                    }
                    if (this.IsFinished && this.DateTimeFinished == null)
                    {
                        // The execution has just finished (completed / failed / canceled)
                        this.DateTimeFinished = DateTime.Now;
                        this.ExecutionTime = this.DateTimeFinished - this.DateTimeStarted;
                        this.AppendToLog($"Execution time: {this.ExecutionTimeAsText}");
                    }
                    OnExecutionStateChanged(previousExecutionState);
                }
            }
        }

        public event EventHandler ExecutionStateChanged;

        protected virtual void OnExecutionStateChanged(
            ExecutionState previousExecutionState)
        {
            if (this.ExecutionStateChanged != null)
                ExecutionStateChanged(this, null);
        }

        [Range(0.0, 100.0)]
        public double PercentsDone { get; set; }

        public virtual string StateAsText
        {
            get
            {
                if (this.ExecutionState == ExecutionState.NotStarted)
                    return "Waiting to start";
                if (this.ExecutionState == ExecutionState.Running)
                    return "Running";
                if (this.ExecutionState == ExecutionState.CompletedSuccessfully)
                    return "Completed successfully";
                if (this.ExecutionState == ExecutionState.Failed)
                    return "Failed to execute";
                if (this.ExecutionState == ExecutionState.Canceled)
                    return "Canceled by user";
                return "Unknown";
            }
        }

        public string ProgressAsText
        {
            get => "" + Math.Round(this.PercentsDone, 1) + "% done";
        }

        public bool IsRunning
        {
            get => this.ExecutionState == ExecutionState.Running;
        }

        public bool IsFinished
        {
            get => this.ExecutionState == ExecutionState.CompletedSuccessfully ||
                this.ExecutionState == ExecutionState.Failed ||
                this.ExecutionState == ExecutionState.Canceled;
        }

        public DateTime DateTimeCreated { get; private set; } = DateTime.Now;
        public DateTime? DateTimeStarted { get; private set; }
        public DateTime? DateTimeFinished { get; private set; }
        public TimeSpan? ExecutionTime { get; private set; }

        public string ExecutionTimeAsText
        { 
            get
            {
                if (this.ExecutionTime == null)
                    return "-";

                var time = this.ExecutionTime.Value;
                string timeAsText = $"{time:h\\:mm\\:ss}";
                return timeAsText;
            }
        }

        public string ExecutionLog { get; protected set; } = "";

        public string ExecutionLogForDisplay
        {
            get
            {
                if (this.ExecutionLog == "")
                    return "Action not yet started." + Environment.NewLine;
                return this.ExecutionLog;
            }
        }

        protected void AppendToLog(string text)
        {
            if (String.IsNullOrEmpty(text))
                return;
            if (this.ExecutionLog.Length > 0)
                text = Environment.NewLine + text + Environment.NewLine;
            else
                text = text + Environment.NewLine;
            this.ExecutionLog += text;
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

        public abstract bool CanStart();
        public abstract void Start();
        public abstract void UpdateState();
        public abstract void Cancel();
    }
}
