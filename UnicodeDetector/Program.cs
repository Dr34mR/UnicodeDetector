using System;
using System.Windows.Forms;

namespace UnicodeDetector
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var applicationForm = new FrmMain();
            applicationForm.Setup();
            Application.Run(applicationForm);
        }
    }
}
