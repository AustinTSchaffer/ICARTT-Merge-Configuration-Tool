using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICARTT_Merge_Configuration.ICARTT_File_Library
{
    /// <summary>
    /// This struct holds header information from an ICARTT file.
    /// </summary>
    class ICARTT_FileProperties
    {
        /// <summary>
        /// Struct constructor.
        /// </summary>
        public ICARTT_FileProperties()
        {
            LinesInHeader = 0;
            FileFormatIndex = 0;
            NumDependentVariables = 0;
            SpecialCommentLines = 0;
            NormalCommentLines = 0;

            DataInterval = 0.0;

            PI = "";
            Organization = "";
            DataSourceDescription = "";
            MissionName = "";
            FileVolumeInformation = "";
            DateInformation = "";

            SpecialComments = new List<string>();
            NormalComments = new List<string>();
        }

        public int
            LinesInHeader,
            FileFormatIndex,
            NumDependentVariables,
            SpecialCommentLines,
            NormalCommentLines;

        public double
            DataInterval;

        public string 
            PI, 
            Organization,
            DataSourceDescription,
            MissionName,
            FileVolumeInformation,
            DateInformation;

        public List<string> SpecialComments, NormalComments;
    }
}
