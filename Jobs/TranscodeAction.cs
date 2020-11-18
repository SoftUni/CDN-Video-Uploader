using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

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

            this.transcodeProcess = new Process
            {
                StartInfo =
                {
                    FileName = cmdExecutable,
                    Arguments = cmdParams,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                }
            };
            this.AppendToLog( 
                cmdExecutable + " " + cmdParams + Environment.NewLine + Environment.NewLine);
            try
            {
                this.transcodeProcess.Start();
                this.ExecutionState = ExecutionState.Running;
            }
            catch (Exception ex)
            {
                this.ExecutionState = ExecutionState.Failed;
                this.OnErrorOccurred(ex);
            }
            this.UpdateLogFromProcessOutput();
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

            this.UpdateLogFromProcessOutput();

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

        public override void Cancel()
        {
            this.ExecutionState = ExecutionState.Canceled;
            try
            {
                this.transcodeProcess.Kill();
            }
            catch (Exception ex)
            {
                OnErrorOccurred(new InvalidOperationException(
                    $"Failed to stop process #{this.transcodeProcess.Id}: {ex}"));
            }
        }

        private void UpdateLogFromProcessOutput()
        {
            this.ExecutionLog +=
                this.transcodeProcess.StandardOutput.ReadToEnd();
            this.ExecutionLog +=
                this.transcodeProcess.StandardError.ReadToEnd();
        }
    }
}
