using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FluentFTP;

namespace CDN_Video_Uploader.Jobs
{
    public class UploadAction : ExecutableAction
    {
        public override string ActionType => "Upload";
        public string InputFile { get; set; }
        public string PathAtFTP { get; set; }
        public FtpClient FtpClient { get; set; }
        public ExecutableAction DependsOnAction { get; set; }

        private FileStream inputFileStream;
        private Task uploadTask;
        private CancellationTokenSource uploadTaskCancelationTokenSource;

        public override bool CanStart()
        {
            bool canStart = this.ExecutionState == ExecutionState.NotStarted;
            if (this.DependsOnAction != null && 
                this.DependsOnAction.ExecutionState != ExecutionState.CompletedSuccessfully)
                canStart = false;
            return canStart;
        }

        public override void Start()
        {
            if (this.FtpClient == null)
            {
                this.ExecutionState = ExecutionState.Failed;
                this.OnErrorOccurred(new InvalidOperationException($"not connected to the FTP server"));
                return;
            }

            try
            {
                this.AppendToLog($"FTP upload started: {this.InputFile} --> ftp://{this.FtpClient.Host}{this.PathAtFTP}");
                this.ExecutionState = ExecutionState.Running;
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
                this.OnErrorOccurred(this.uploadTask.Exception);
                this.ExecutionState = ExecutionState.Failed;
            }
            else if (this.uploadTask.Status == TaskStatus.Canceled)
            {
                this.ExecutionState = ExecutionState.Canceled;
            }
        }

        public override void Cancel()
        {
            // Ask the FTP file upload component to cancel its work
            this.uploadTaskCancelationTokenSource.Cancel();
            this.ExecutionState = ExecutionState.Canceled;
        }

        protected override void OnExecutionStateChanged(ExecutionState previousExecutionState)
        {
            if (previousExecutionState == ExecutionState.Running && this.IsFinished)
            {
                this.CloseInputStream();
                this.DisconnectFromFTP();
            }
            base.OnExecutionStateChanged(previousExecutionState);
        }

        private void DisconnectFromFTP()
        {
            try
            {
                // Try to disconnect from the FTP server and realease the resources used
                this.FtpClient.Dispose();
            }
            catch
            {
                // The FTP is not connected --> ignore this error
            }
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
                // The file is already closed or can't close --> ignore this error
            }
        }
    }
}
