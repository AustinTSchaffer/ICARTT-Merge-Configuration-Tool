using ICARTT_Merge_Configuration.ICARTT_File_Library;
using ICARTT_Merge_Configuration.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI.ICARTT_ConfigurationBuilder());

            Logger.Log(Logger.MessageCode.Message, typeof(Program), MethodBase.GetCurrentMethod(), "Main thread terminating.");

            Logger.Close();
        }
    }
}