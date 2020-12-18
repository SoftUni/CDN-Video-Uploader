using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace CDN_Video_Uploader.Utils
{
    public class BackgroundProcess : Process
    {
        public unsafe bool StartMinimizedNoFocus()
        {
            if (string.IsNullOrEmpty(this.StartInfo.FileName))
                throw new InvalidOperationException("Missing StartInfo.FileName");

            if (!this.StartInfo.UseShellExecute)
                throw new InvalidOperationException(
                    "Cannot start `minimized no focus` process without ShellExecute");

            // Stop the process if it is currently running
            this.Close();

            fixed (char* fileName = this.StartInfo.FileName.Length > 0 ? this.StartInfo.FileName : null)
            fixed (char* verb = this.StartInfo.Verb.Length > 0 ? this.StartInfo.Verb : null)
            fixed (char* args = this.StartInfo.Arguments.Length > 0 ? this.StartInfo.Arguments : null)
            fixed (char* directory = this.StartInfo.WorkingDirectory.Length > 0 ? this.StartInfo.WorkingDirectory : null)
            {
                Shell32.SHELLEXECUTEINFO shellExecuteInfo = new Shell32.SHELLEXECUTEINFO()
                {
                    cbSize = (uint)sizeof(Shell32.SHELLEXECUTEINFO),
                    lpFile = fileName,
                    lpVerb = verb,
                    lpParameters = args,
                    lpDirectory = directory,
                    fMask = Shell32.SEE_MASK_NOCLOSEPROCESS | Shell32.SEE_MASK_FLAG_DDEWAIT
                };

                if (this.StartInfo.ErrorDialog)
                    shellExecuteInfo.hwnd = this.StartInfo.ErrorDialogParentHandle;
                else
                    shellExecuteInfo.fMask |= Shell32.SEE_MASK_FLAG_NO_UI;

                shellExecuteInfo.nShow = Shell32.SW_SHOWMINNOACTIVE;

                ShellExecuteHelper executeHelper = new ShellExecuteHelper(&shellExecuteInfo);
                if (!executeHelper.ShellExecuteOnSTAThread())
                {
                    int error = executeHelper.ErrorCode;
                    if (error == 0)
                        error = (int)(long)error;
                    throw new Win32Exception(error);
                }

                if (shellExecuteInfo.hProcess != IntPtr.Zero)
                {
                    // SetProcessHandle(new SafeProcessHandle(shellExecuteInfo.hProcess));
                    // Invoke the above private emthod through reflection
                    SafeProcessHandle safeHandle =
                        new SafeProcessHandle(shellExecuteInfo.hProcess, true);
                    Type typeProcess = typeof(Process);
                    MethodInfo setProcessHandleMethod = typeProcess.GetMethod("SetProcessHandle",
                        BindingFlags.NonPublic | BindingFlags.Instance);
                    setProcessHandleMethod.Invoke(this, new object[] { safeHandle });

                    return true;
                }
            }

            return false;
        }

        internal unsafe class ShellExecuteHelper
        {
            private Shell32.SHELLEXECUTEINFO* _executeInfo;
            private bool _succeeded;
            private int _errorCode;

            public ShellExecuteHelper(Shell32.SHELLEXECUTEINFO* executeInfo)
            {
                this._executeInfo = executeInfo;
            }

            public void ShellExecuteFunction()
            {
                if (!(this._succeeded = Shell32.ShellExecuteEx(this._executeInfo)))
                {
                    this._errorCode = Marshal.GetLastWin32Error();
                }
            }

            public bool ShellExecuteOnSTAThread()
            {
                if (Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
                {
                    ThreadStart start = new ThreadStart(this.ShellExecuteFunction);
                    Thread thread = new Thread(start);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                }
                else
                {
                    this.ShellExecuteFunction();
                }
                return this._succeeded;
            }

            public int ErrorCode => this._errorCode;
        }

        internal class Shell32
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            internal unsafe struct SHELLEXECUTEINFO
            {
                public uint cbSize;
                public uint fMask;
                public IntPtr hwnd;
                public char* lpVerb;
                public char* lpFile;
                public char* lpParameters;
                public char* lpDirectory;
                public int nShow;
                public IntPtr hInstApp;
                public IntPtr lpIDList;
                public IntPtr lpClass;
                public IntPtr hkeyClass;
                public uint dwHotKey;
                // This is a union of hIcon and hMonitor
                public IntPtr hIconMonitor;
                public IntPtr hProcess;
            }

            internal const int SW_HIDE = 0;
            internal const int SW_SHOWNORMAL = 1;
            internal const int SW_SHOWMINIMIZED = 2;
            internal const int SW_SHOWMAXIMIZED = 3;
            internal const int SW_SHOWNOACTIVATE = 4;
            internal const int SW_SHOWMINNOACTIVE = 7;

            internal const uint SEE_MASK_FLAG_DDEWAIT = 0x00000100;
            internal const uint SEE_MASK_NOCLOSEPROCESS = 0x00000040;
            internal const uint SEE_MASK_FLAG_NO_UI = 0x00000400;

            [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static unsafe extern bool ShellExecuteEx(SHELLEXECUTEINFO* lpExecInfo);
        }
    }
}
