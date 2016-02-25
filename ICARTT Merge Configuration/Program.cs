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

            if (ICARTT_FileLoader.UniqueLocationIDs().Count > 1)
            {
                Logger.Log(Logger.MessageCode.Warning, typeof(Program), MethodBase.GetCurrentMethod(), "More than one unique locaiton ID", "Location IDs are not case sensitive", String.Format("Unique Location IDs: [{0}]", String.Join(", ", ICARTT_FileLoader.UniqueLocationIDs())));
            }
            

            ICARTT_FileLoader.Filter_LocationID("P3B");
            ICARTT_FileLoader.Filter_Dates(new List<string>() { "20130904", "20130906", "20130911", "20130912", "20130913", "20130914", "20130924", "20130925", "20130926" });


            ICARTT_FileLoader.icarttFilesToMerge.ForEach(i => Logger.Log(typeof(Program), MethodBase.GetCurrentMethod(), String.Format("{0}{1}", i.FilePath, i.FileName)));


            // TODO: DO NOT DELETE. Uncomment once backbone completed.
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ConfigurationBuilderWindow());


            Logger.Log(Logger.MessageCode.Message, typeof(Program), MethodBase.GetCurrentMethod(), "Main thread terminating.");

            Logger.Close();

        }
    }
}
