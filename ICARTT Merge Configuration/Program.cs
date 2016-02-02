using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICARTT_Merge_Configuration.ICARTT_Header_Parsing_Library;
using System.Diagnostics;
using ICARTT_Merge_Configuration.Logging;

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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ConfigurationBuilderWindow());

            Logger.Setup();

            for (int i = 0; i < 100; ++i)
            {
                ICARTT_Metadata_FileName icmdfn = new ICARTT_Metadata_FileName("dataID_locID_00000000_R0_L44_V22.ict", "bin/");
                ICARTT_Metadata_FileName icmdfn2 = new ICARTT_Metadata_FileName("dataID_locID_00000000_R0_L44_V22.it", "bin/");
                ICARTT_Metadata_FileName icmdfn3 = new ICARTT_Metadata_FileName("dataID_locID_00000000_R0_L44_V.ict", "bin/");
                ICARTT_Metadata_FileName icmdfn4 = new ICARTT_Metadata_FileName(null, "bin/");
            }
        }
    }
}
