using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICARTT_Header_Parsing_Library;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            ICARTT_Metadata_FileName icmdfn = new ICARTT_Metadata_FileName("dataID_locID_00000000_R0_L444_V22_Not-a-very-good-comment.ict", "bin/");
            ICARTT_Metadata_FileName icmdfn2 = new ICARTT_Metadata_FileName("dataID_locID_00000000_R0_L444_V22_Not-a-very-good-commet.ict", "bin/");
            Console.WriteLine(icmdfn.ToString());
            Console.WriteLine(icmdfn.Equals(icmdfn2));
        }
    }
}
