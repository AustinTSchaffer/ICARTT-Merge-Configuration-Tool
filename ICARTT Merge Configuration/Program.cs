using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICARTT_Merge_Configuration.ICARTT_File_Library;
using System.Diagnostics;
using ICARTT_Merge_Configuration.Utilities;
using System.Reflection;
using System.Threading;
using System.Text;

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

            ICARTT_FileLoader.GetICARTTFilesFromDir("C:\\Users\\atschaff\\ICARTT Data\\TEXAS_2013\\P3B_AIRCRAFT");

            // Log a warning if the directory contains more than one unique Location ID
            if (ICARTT_FileLoader.UniqueLocationIDs().Count > 1) Logger.Log(Logger.MessageCode.Warning, typeof(Program), MethodBase.GetCurrentMethod(), "More than one unique locaiton ID", "Location IDs are not case sensitive", String.Format("Unique Location IDs: [{0}]", String.Join(", ", ICARTT_FileLoader.UniqueLocationIDs())));


            List<string> datesToInclude = ICARTT_FileLoader.UniqueDates();
            datesToInclude.Remove("20130929");
            datesToInclude.Remove("20130904");


            ICARTT_FileLoader.Filter(ICARTT_File.FileNameProperty.LocationID, "p3b");
            ICARTT_FileLoader.Filter(ICARTT_File.FileNameProperty.Date, datesToInclude);


            ICARTT_FileLoader.icarttFilesToMerge.ForEach(i => Logger.Log(typeof(Program), MethodBase.GetCurrentMethod(), String.Format("{0}{1}", i.FilePath, i.FileName)));

            Queue<ICARTT_File> loadQueue = new Queue<ICARTT_File>();
            ICARTT_FileLoader.icarttFilesToMerge.ForEach(i => loadQueue.Enqueue(i));

            loadQueue.Dequeue().Load();


            // TODO: DO NOT DELETE. Uncomment once backbone completed.
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ConfigurationBuilderWindow());


            Logger.Log(Logger.MessageCode.Message, typeof(Program), MethodBase.GetCurrentMethod(), "Main thread terminating.");

            Logger.Close();

        }
    }
}
