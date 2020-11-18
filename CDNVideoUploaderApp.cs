using System;
using System.Windows.Forms;

namespace CDN_Video_Uploader
{
    static class CDNVideoUploaderApp
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormVideoUploader());
        }
    }
}
