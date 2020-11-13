namespace CDN_Video_Uploader.Jobs
{
    /// <summary>
    /// Execution state for Jobs and Actions
    /// </summary>
    enum ExecutionState
    {
        NotStarted,
        Running,
        CompletedSuccessfully,
        Canceled,
        Failed
    }
}

