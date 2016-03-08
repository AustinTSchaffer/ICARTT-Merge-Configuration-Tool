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

        private static void testMethod()
        {
            ICARTT_FileManager.GetICARTTFilesFromDir("C:\\Users\\atschaff\\ICARTT Data\\TEXAS_2013\\P3B_AIRCRAFT");

            // Log a warning if the directory contains more than one unique Location ID
            if (ICARTT_FileManager.GetUnique(ICARTT_File.FileNameProperty.LocationID, ICARTT_FileManager.IcarttFilesInScope).Count > 1) Logger.Log(Logger.MessageCode.Warning, typeof(Program), MethodBase.GetCurrentMethod(), "More than one unique locaiton ID", "Location IDs are not case sensitive", String.Format("Unique Location IDs: [{0}]", String.Join(", ", ICARTT_FileManager.GetUnique(ICARTT_File.FileNameProperty.LocationID, ICARTT_FileManager.IcarttFilesInScope))));


            List<string> datesToInclude = ICARTT_FileManager.GetUnique(ICARTT_File.FileNameProperty.Date, ICARTT_FileManager.IcarttFilesInScope);
            datesToInclude.Remove("20130929");

            //ICARTT_FileManager.FileNameFilter(ICARTT_File.FileNameProperty.LocationID, "p3b");
            //ICARTT_FileManager.FileNameFilter(ICARTT_File.FileNameProperty.Date, datesToInclude);

            ICARTT_FileManager.LoadAll();
        }


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

// Long Term Notes (Google Doc)
// TODO: Long Term Note 1.
// TODO: Long Term Note 2.
