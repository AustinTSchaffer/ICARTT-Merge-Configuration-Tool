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
        /// <param name="parentHash">Hash of the ICARTT_File object that contains this struct</param>
        public ICARTT_FileProperties(int parentHash)
        {
            ParentHash = parentHash;
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
            ParentHash,
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
