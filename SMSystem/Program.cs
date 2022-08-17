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
            DependencyInjection dependency = new DependencyInjection();
            ConfigDictionary.keyValuePairs.Add("ConString", Properties.Settings.Default.SQLServerConString);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
