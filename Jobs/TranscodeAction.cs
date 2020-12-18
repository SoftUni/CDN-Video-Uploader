using CDN_Video_Uploader.Properties;
using CDN_Video_Uploader.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace CDN_Video_Uploader.Jobs
{
    public class TranscodeAction : ExecutableAction
    {
        public override string ActionType => "Transcode";
        public string InputFile { get; set; }
        public string TranscodingCommand { get; set; }
        public string OutputFile { get; set; }

        private BackgroundProcess transcodeProcess;

        private static object ActiveTranscodingActionsLock = new object();
        public static int ActiveTranscodingActions { get; private set; }

        public override bool CanStart()
        {
            bool canStart =
                this.ExecutionState == ExecutionState.NotStarted &&
                ActiveTranscodingActions < AppSettings.Default.MaxParallelTranscodings;
            return canStart;
        }

        public override void Start()
        {
            try
            {
                if (File.Exists(this.OutputFile))
                    File.Delete(this.OutputFile);
            }
            catch (Exception ex)
            {
                this.ExecutionState = ExecutionState.Failed;
                this.OnErrorOccurred(new InvalidOperationException(
                    $"Output file <code>{this.OutputFile}</code> already exists and cannot be deleted. {ex.Message}"));
                return;
            }

            Match cmdParts = Regex.Match(this.TranscodingCommand, @"(\S+)\s+(.*)");
            if (cmdParts.Groups.Count != 3)
            {
                this.ExecutionState = ExecutionState.Failed;
                this.OnErrorOccurred(new InvalidOperationException(
                    $"Invalid transcoding command: <code>{this.TranscodingCommand}</code>"));
                return;
            }

            string cmd = cmdParts.Groups[1].Value;
            string cmdParams = cmdParts.Groups[2].Value;

            string cmdExecutable = FindExecutableInSystemPath(cmd);
            if (cmdExecutable == null)
            {
                this.ExecutionState = ExecutionState.Failed;
                this.OnErrorOccurred(new InvalidOperationException(
                    $"Cannot find executable <code>{cmd}</code> in the system PATH. Make sure it is properly installed and configured."));
                return;
            }

            this.transcodeProcess = new BackgroundProcess
            {
                StartInfo =
                {
                    FileName = cmdExecutable,
                    Arguments = cmdParams,
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    WindowStyle = ProcessWindowStyle.Minimized
                }
            };
            this.transcodeProcess.OutputDataReceived += TranscodeProcess_OutputDataReceived;
            this.transcodeProcess.ErrorDataReceived += TranscodeProcess_ErrorDataReceived;
            this.AppendToLog($"{this.Description} started. Executing command:");
            this.AppendToLog($"{cmdExecutable} {cmdParams}");
            try
            {
                this.transcodeProcess.StartMinimizedNoFocus();
                this.ExecutionState = ExecutionState.Running;
            }
            catch (Exception ex)
            {
                this.ExecutionState = ExecutionState.Failed;
                this.OnErrorOccurred(ex);
            }
        }

        private void TranscodeProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.AppendToLog(e.Data);
        }

        private void TranscodeProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.AppendToLog(e.Data);
        }

        private static string FindExecutableInSystemPath(string exeFileName)
        {
            if (File.Exists(exeFileName))
                return Path.GetFullPath(exeFileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, exeFileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        public override void UpdateState()
        {
            if (this.ExecutionState != ExecutionState.Running)
                return;

            if (this.transcodeProcess.HasExited)
            {
                this.UpdateLogFromProcessOutput();
                this.PercentsDone = 100;
                if (this.transcodeProcess.ExitCode == 0)
                    this.ExecutionState = ExecutionState.CompletedSuccessfully;
                else
                    this.ExecutionState = ExecutionState.Failed;
            }
            else
            {
                // TODO: update the progress (PercentsDone)
                double step = 0.1 * (100 - this.PercentsDone) / 100;
                this.PercentsDone += step;
            }
        }

        private void UpdateLogFromProcessOutput()
        {
            if (this.transcodeProcess.StartInfo.RedirectStandardOutput)
            {
                string outputData = this.transcodeProcess.StandardOutput.ReadToEnd();
                this.AppendToLog(outputData);
            }
            if (this.transcodeProcess.StartInfo.RedirectStandardError)
            {
                string errorData = this.transcodeProcess.StandardError.ReadToEnd();
                this.AppendToLog(errorData);
            }
        }

        public override void Cancel()
        {
            try
            {
                if (! this.transcodeProcess.HasExited)
                    this.transcodeProcess.Kill();
            }
            catch (Exception ex)
            {
                OnErrorOccurred(new InvalidOperationException(
                    $"Failed to stop process #{this.transcodeProcess.Id}: {ex}"));
            }
            this.ExecutionState = ExecutionState.Canceled;
        }

        protected override void OnExecutionStateChanged(
            ExecutionState previousExecutionState)
        {
            if (this.ExecutionState == ExecutionState.Running)
            {
                // A new transcoding action has just started
                lock (TranscodeAction.ActiveTranscodingActionsLock)
                    ActiveTranscodingActions++;
            }
            if (previousExecutionState == ExecutionState.Running)
            {
                // The current transcoding action has just stopped
                lock (TranscodeAction.ActiveTranscodingActionsLock)
                    ActiveTranscodingActions--;
            }
            base.OnExecutionStateChanged(previousExecutionState);
        }
    }
}
