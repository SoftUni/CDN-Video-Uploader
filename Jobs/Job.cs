using System;
using System.Collections.Generic;
using System.Linq;

namespace CDN_Video_Uploader.Jobs
{
    public class Job : ExecutableAction
    {
        public override string ActionType => "Job";
        public List<ExecutableAction> Actions { get; set; }

        public override string StateAsText
        {
            get
            {
                if (this.ExecutionState == ExecutionState.Running)
                {
                    ExecutableAction firstRunningAction = 
                        this.Actions.FirstOrDefault(a => a.IsRunning);
                    if (firstRunningAction != null)
                        return firstRunningAction.Description;
                    else
                        return "Running";
                }
                return base.StateAsText;
            }
        }

        private string videoURL;
        public string VideoURL
        {
            get
            {
                if (this.ExecutionState == ExecutionState.CompletedSuccessfully) 
                    return this.videoURL;
                return null;
            }
            set
            {
                this.videoURL = value;
            }
        }

        public override bool CanStart()
        {
            if (this.ExecutionState != ExecutionState.NotStarted)
                return false;
            foreach (ExecutableAction action in this.Actions)
                if (action.CanStart())
                    return true;
            return false;
        }

        public override void Start()
        {
            this.ExecutionState = ExecutionState.Running;
            foreach (ExecutableAction action in this.Actions)
                if (action.CanStart())
                    action.Start();
        }

        public override void UpdateState()
        {
            if (this.ExecutionState != ExecutionState.Running)
                return;

            foreach (ExecutableAction action in this.Actions)
            {
                if (action.ExecutionState == ExecutionState.Running)
                    action.UpdateState();
                if (action.ExecutionState == ExecutionState.NotStarted)
                    if (action.CanStart())
                        Start();
            }

            this.UpdateJobExecutionState();

            this.PercentsDone = this.Actions.Average(a => a.PercentsDone);
        }

        private void UpdateJobExecutionState()
        {
            if (this.Actions.All(a => a.ExecutionState == ExecutionState.NotStarted))
            {
                this.ExecutionState = ExecutionState.NotStarted;
                return;
            }
            if (this.Actions.All(a => a.ExecutionState == ExecutionState.CompletedSuccessfully))
            {
                this.ExecutionState = ExecutionState.CompletedSuccessfully;
                return;
            }
            if (this.Actions.Any(a => a.ExecutionState == ExecutionState.Failed))
            {
                this.ExecutionState = ExecutionState.Failed;
                return;
            }
            if (this.Actions.Any(a => a.ExecutionState == ExecutionState.Canceled))
            {
                this.ExecutionState = ExecutionState.Canceled;
                return;
            }
            if (this.Actions.Any(a => a.ExecutionState == ExecutionState.Running))
            {
                this.ExecutionState = ExecutionState.Running;
                return;
            }
        }

        public override void Cancel()
        {
            foreach (var action in this.Actions)
                if (action.ExecutionState == ExecutionState.Running)
                    action.Cancel();
            if (this.ExecutionState == ExecutionState.NotStarted ||
                this.ExecutionState == ExecutionState.Running)
            {
                this.ExecutionState = ExecutionState.Canceled;
            }
        }
    }
}
