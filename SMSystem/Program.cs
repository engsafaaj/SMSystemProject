using Microsoft.Extensions.DependencyInjection;
using SMSystem.Code;
using SMSystem.Data;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Startup getStarted=new Startup();
            Application.Run(new Main());
        }
       
    }
}
