using System.Diagnostics;
using System.Threading.Tasks;

namespace CDN_Video_Uploader.Jobs
{
    class TranscodeAction : ExecutableAction
    {
        public string InputFile { get; set; }
        public string TranscodingCommand { get; set; }
        public string OutputFile { get; set; }
        private Process transcodeProcess;

        public override void Start()
        {


            // TODO: temorary for debug only -> wait 3 seconds, then exit
            this.TranscodingCommand = "timeout / t 3";


            this.transcodeProcess = new Process
            {
                StartInfo =
                {
                    FileName = this.TranscodingCommand,
                    Arguments = "",
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                },
                EnableRaisingEvents = true
            };
            this.transcodeProcess.Start();
            this.ExecutionState = ExecutionState.Running;
        }

        public override void Cancel()
        {
            this.ExecutionState = ExecutionState.Canceled;
            this.transcodeProcess.Kill();
        }

        public override void UpdateState()
        {
            if (this.ExecutionState != ExecutionState.Running)
                return;

            if (this.transcodeProcess.HasExited)
            {
                this.PercentsDone = 100;
                if (this.transcodeProcess.ExitCode == 0)
                    this.ExecutionState = ExecutionState.CompletedSuccessfully;
                else
                    this.ExecutionState = ExecutionState.Failed;
            }
            else
            {
                // TODO: update the progress (PercentsDone)
                this.PercentsDone += 0.1f;
            }
        }
    }
}
