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

            ICARTT_Metadata_FileName fileNameTests = new ICARTT_Metadata_FileName("asdf_asdf_10101010_R0.ict","asdf");
            fileNameTests = new ICARTT_Metadata_FileName("asdf_asdf_10101010_R0.it", "asdf");
            fileNameTests = new ICARTT_Metadata_FileName("asdf_asdf_10101010_R0_asdfhooohlkjahsdfjklhasdfkljhasdfklahsdfkljhasdfkljasdfklhasdfkljhasdfjklahsdfkljhasdfkljhasdfkljahsdf.ict", "asdf");
            fileNameTests = new ICARTT_Metadata_FileName("asdf_as$df_10101010_$R0.ict", "asdf");
            fileNameTests = new ICARTT_Metadata_FileName("asdf_as$df_10101010_$R0.ict", "asdf");
            fileNameTests = new ICARTT_Metadata_FileName("asdf_asdf_10101010_0.ict", "asdf");
            fileNameTests = new ICARTT_Metadata_FileName("asdf_as$df_1012221013330_R0.ict", "asdf");

            fileNameTests = new ICARTT_Metadata_FileName("asdf_asdf_10101010_R0.ict", null);
            fileNameTests = new ICARTT_Metadata_FileName(null, null);
            fileNameTests = new ICARTT_Metadata_FileName(null, "asdf");
        }
    }
}
