using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICARTT_Merge_Configuration.ICARTT_File_Library
{
    /// <summary>
    /// This class holds header information for an ICARTT file. This class provides some access control to the information and provides a structured storage location. This class contains all non-variable related information.
    /// </summary>
    class ICARTT_FileProperties
    {
        public ICARTT_FileProperties()
        {
            SpecialComments = new List<string>();
            NormalComments = new List<string>();
        }

        public string 
            FileFormatIndex, 
            PI, 
            Organization,
            DataSourceDescription,
            MissionName;

        /// <summary>
        /// [volume number], [number of volumes]
        /// </summary>
        public string FileVolumeInformation;

        /// <summary>
        /// Data begin date and data revision date formatted like so: yyyy, mm, dd, yyyy, mm, dd
        /// </summary>
        public string DateInformation;

        /// <summary>
        /// Comments related
        /// </summary>
        public List<string> SpecialComments;

        /// <summary>
        /// Comments related to supporting information. Has 18 required "fields".
        /// </summary>
        private List<string> NormalComments;
    }
}
