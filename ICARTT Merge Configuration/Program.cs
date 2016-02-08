using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICARTT_Merge_Configuration.ICARTT_Header_Parsing_Library;
using System.Diagnostics;
using ICARTT_Merge_Configuration.Logging;
using System.Reflection;
using System.Threading;

namespace ICARTT_Merge_Configuration
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Setup();

            List<ICARTT_File> ictFiles = new List<ICARTT_File>();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ConfigurationBuilderWindow());


            for (int i = 0; i < 200; ++i)
            {
                Logger.Log(Logger.MessageCode.Message, typeof(Program), MethodBase.GetCurrentMethod(), "Test message: " + i, "Test indent 1", "Test indent 2");
            }

            Logger.Close();
            

        }
    }
}
