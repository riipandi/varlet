using System;
using System.Threading;
using System.Windows.Forms;

namespace VarletUi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            using (var mtx = new Mutex(true, "VarletUi", out var instanceCountOne))
            {
                if (instanceCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    _ = new TrayContext();
                    Application.Run(args.Length != 0 ? new FormMain(args[0]) : new FormMain());
                    mtx.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show(Application.ProductName + " already running!", "Warning");
                }
            }
        }
    }
}
