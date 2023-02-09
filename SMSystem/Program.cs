using SMSystem.Gui;
using System;
using System.Windows.Forms;

namespace SMSystem
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Startup getStarted = new Startup();
            Application.Run(new StartForm());
        }

    }
}
