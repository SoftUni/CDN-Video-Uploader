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
        private FtpClient FtpClient { get; set; }
        private FileStream inputFileStream;
        private Task uploadTask;
        private CancellationTokenSource uploadTaskCancelationTokenSource;

        public override void Start()
        {


            // TODO: temorary for debug only -> wait 3 seconds, then exit
            this.uploadTaskCancelationTokenSource = new CancellationTokenSource();
            this.uploadTask = new Task(() => 
            {
                Thread.Sleep(5);
            });



            //this.inputFileStream = new FileStream(this.InputFile, FileMode.Open);
            //this.uploadTaskCancelationTokenSource = new CancellationTokenSource();
            //this.uploadTask = this.FtpClient.UploadAsync(
            //    fileStream: inputFileStream, 
            //    remotePath: this.PathAtFTP,
            //    token: uploadTaskCancelationTokenSource.Token);
            this.ExecutionState = ExecutionState.Running;
        }

        public override void Cancel()
        {
            // Ask the FTP file uploader to cancel its work
            this.uploadTaskCancelationTokenSource.Cancel();
            
            // Forcefully close the input stream
            try { this.inputFileStream.Close(); } catch { }

            this.ExecutionState = ExecutionState.Canceled;
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
        }
    }
}