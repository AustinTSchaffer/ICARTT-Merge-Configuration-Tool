using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICARTT_Merge_Configuration.ICARTT_File_Library
{
    /// <summary>
    /// This class holds ICARTT header information that is not directly related to the contained variables.
    /// </summary>
    class ICARTT_FileProperties
    {
        /// <summary>
        /// Initializes all structures with default values to prevent access errors before file is loaded.
        /// </summary>
        public ICARTT_FileProperties()
        {
            LinesInHeader = -1;
            FileFormatIndex = -1;
            NumDependentVariables = -1;
            SpecialCommentLines = -1;
            NormalCommentLines = -1;

            DataInterval = -1.0;

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
