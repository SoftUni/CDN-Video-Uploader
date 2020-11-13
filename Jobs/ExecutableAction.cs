namespace CDN_Video_Uploader.Jobs
{
    abstract class ExecutableAction
    {
        public string Description { get; set; }
        public ExecutionState ExecutionState { get; set; } = ExecutionState.NotStarted;
        public float PercentsDone { get; set; }
        public abstract void Start();
        public abstract void Cancel();
        public abstract void UpdateState();

        public bool IsFinished
        {
            get => this.ExecutionState == ExecutionState.CompletedSuccessfully ||
                this.ExecutionState == ExecutionState.Failed ||
                this.ExecutionState == ExecutionState.Canceled;
        }
    }
}
