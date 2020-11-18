using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;

namespace CDN_Video_Uploader.Jobs
{
    class UploadAction : ExecutableAction
    {
        public string InputFile { get; set; }
        public string PathAtFTP { get; set; }
        public FtpClient FtpClient { get; set; }
        private FileStream inputFileStream;
        private Task uploadTask;
        private CancellationTokenSource uploadTaskCancelationTokenSource;

        public override void Start()
        {
            if (this.FtpClient == null)
            {
                this.ExecutionState = ExecutionState.Failed;
                this.OnErrorOccurred(new InvalidOperationException(
                    $"not connected to the FTP server"));
                return;
            }

            try
            {
                IProgress<FtpProgress> progressIndicator =
                    new Progress<FtpProgress>(this.UploadProgressChanged);
                this.inputFileStream = new FileStream(this.InputFile, FileMode.Open);
                this.uploadTaskCancelationTokenSource = new CancellationTokenSource();
                this.uploadTask = this.FtpClient.UploadAsync(
                    fileStream: inputFileStream,
                    remotePath: this.PathAtFTP,
                    token: uploadTaskCancelationTokenSource.Token,
                    progress: progressIndicator
                );
                this.ExecutionState = ExecutionState.Running;
            }
            catch (Exception ex)
            {
                this.ExecutionState = ExecutionState.Failed;
                this.OnErrorOccurred(ex);
            }
        }

        private void UploadProgressChanged(FtpProgress ftpProgress)
        {
            this.PercentsDone = ftpProgress.Progress;
        }

        public override void UpdateState()
        {
            if (this.ExecutionState != ExecutionState.Running)
                return;

            if (this.uploadTask.Status == TaskStatus.RanToCompletion)
            {
                this.PercentsDone = 100;
                this.ExecutionState = ExecutionState.CompletedSuccessfully;
            }
            else if (this.uploadTask.Status == TaskStatus.Faulted)
            {
                this.ExecutionState = ExecutionState.Failed;
            }
            else if (this.uploadTask.Status == TaskStatus.Canceled)
            {
                this.ExecutionState = ExecutionState.Canceled;
            }
            else
            {
                // TODO: update the progress (PercentsDone)
                this.PercentsDone += 0.1f;
            }

            if (this.IsFinished)
                this.CloseInputStream();
        }

        public override void Cancel()
        {
            // Ask the FTP file upload component to cancel its work
            this.uploadTaskCancelationTokenSource.Cancel();

            this.CloseInputStream();

            this.ExecutionState = ExecutionState.Canceled;
        }

        /// <summary>
        /// Close (forcefully) the input stream, associated with the FTP file upload
        /// </summary>
        private void CloseInputStream()
        {
            try 
            { 
                // Try to close the file stream
                this.inputFileStream.Close(); 
            } 
            catch 
            {
                // The file is already closed or can't close --> ignore it
            }
        }
    }
}
