using System;
using System.Collections.Generic;
using System.Linq;

namespace CDN_Video_Uploader.Jobs
{
    class Job : ExecutableAction
    {
        public List<ExecutableAction> Actions { get; set; }
        public int ActiveActionIndex { get; set; }

        public string StateAsText
        {
            get
            {
                if (this.ExecutionState == ExecutionState.NotStarted)
                    return "Waiting to start";
                if (this.ExecutionState == ExecutionState.Running)
                    return this.ActiveAction.Description;
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

        public ExecutableAction ActiveAction
        {
            get
            {
                if (this.Actions.Count == 0)
                    throw new InvalidOperationException("Please first define actions in the job");

                return this.Actions[this.ActiveActionIndex];
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

        public override void Start()
        {
            // Begin from the first action in the actions list
            this.ActiveActionIndex = 0;

            // Start the first action
            this.ActiveAction.Start();
        }

        public override void Cancel()
        {
            foreach (var action in this.Actions)
            {
                if (action.ExecutionState == ExecutionState.Running)
                {
                    action.Cancel();
                }
            }
            this.ExecutionState = ExecutionState.Canceled;
        }

        public override void UpdateState()
        {
            if (this.IsFinished)
                return;

            var currentAction = this.ActiveAction;
            currentAction.UpdateState();
            this.ExecutionState = currentAction.ExecutionState;
            
            if (currentAction.IsFinished)
            {
                // Proceed to the next action (when the current action is successful)
                bool hasNextAction = this.ActiveActionIndex < this.Actions.Count - 1;
                if (hasNextAction && currentAction.ExecutionState == ExecutionState.CompletedSuccessfully)
                {
                    this.ActiveActionIndex++;
                    ActiveAction.Start();
                    this.ExecutionState = ExecutionState.Running;
                }
            }

            this.PercentsDone = this.Actions.Average(a => a.PercentsDone);
        }
    }
}
