using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICARTT_Merge_Configuration.ICARTT_File_Library
{                        
    class ICARTT_File
    {

        /// <summary>
        /// The fields that can be found in the file name of an ICARTT file. Comments have not been included, because they are not used in determining uniqueness from one file to the other.
        /// </summary>
        public enum FileNameProperty
        {
            DataID,
            LocationID,
            Date,
            Revision,
            Launch,
            Volume
        }


        #region Information from file

        /// <summary>
        /// Contains the name and path of the file as well as its component parts.
        /// </summary>
        private ICARTT_FileName FileNameInformation;

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string FileName
        {
            get { return FileNameInformation.FileName; }
        }

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string FilePath
        {
            get { return FileNameInformation.FilePath; }
        }


        /// <summary>
        /// Contains all information from an ICARTT file header, not including data related to variables in the file.
        /// </summary>
        private ICARTT_FileProperties FileProperties;

        #endregion


        /// <summary>
        /// Constructor. Only loads and interprets file name and file path information.
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <param name="inputFilePath"></param>
        public ICARTT_File(string inputFileName, string inputFilePath)
        {
            FileNameInformation = new ICARTT_FileName(inputFileName, inputFilePath);
        }


        /// <summary>
        /// Returns a copy of the field specified in the parameter.
        /// </summary>
        /// <param name="field">The field of the property to get.</param>
        /// <returns>String copy of the field data.</returns>
        public string GetProperty(FileNameProperty field)
        {
            if (null == FileNameInformation)
                throw new MemberAccessException();

            switch (field)
            {
                case FileNameProperty.DataID:
                    return FileNameInformation.DataID;
                case FileNameProperty.LocationID:
                    return FileNameInformation.LocationID;
                case FileNameProperty.Date:
                    return FileNameInformation.Date;
                case FileNameProperty.Revision:
                    return FileNameInformation.Revision;
                case FileNameProperty.Launch:
                    return FileNameInformation.Launch;
                case FileNameProperty.Volume:
                    return FileNameInformation.Volume;
                default:
                    return FileNameInformation.FileName;
            }
        }


        /// <summary>
        /// Returns true if the filtering fields of the two objects all have the same value.
        /// </summary>
        /// <param name="obj">Other ICARTT_File object</param>
        /// <returns>True if the two ICARTT files are equivalent.</returns>
        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;

            if (GetType() != obj.GetType())
                return false;

            ICARTT_File icarttFile = (ICARTT_File) obj;

            foreach (FileNameProperty fnp in Enum.GetValues(typeof(FileNameProperty)))
            {
                if (!(this.GetProperty(fnp).ToUpper()).Equals(icarttFile.GetProperty(fnp).ToUpper()))
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Returns the hash of the name of the file.
        /// </summary>
        /// <returns>Hash of the name of the file.</returns>
        public override int GetHashCode()
        {
            return FileNameInformation.FileName.GetHashCode();
        }


        /// <summary>
        /// Returns true if this ICARTT_File file object is a newer version than the specified ICARTT_File object.
        /// </summary>
        /// <returns>Specified file.</returns>
        public bool IsNewerVersionOf(ICARTT_File icarttFile)
        {
            if (null == icarttFile)
                return false;

            // Check all fields other than Revision for equality
            foreach (FileNameProperty fnp in Enum.GetValues(typeof(FileNameProperty)))
                if ((fnp != FileNameProperty.Revision) && !(this.GetProperty(fnp).ToUpper()).Equals(icarttFile.GetProperty(fnp).ToUpper()))
                    return false;
            
            // Archive data? No Yes
            if (!this.GetProperty(FileNameProperty.Revision).Equals("RA") && icarttFile.GetProperty(FileNameProperty.Revision).Equals("RA"))
                return true;
            // Archive data? Yes No
            if (this.GetProperty(FileNameProperty.Revision).Equals("RA") && !icarttFile.GetProperty(FileNameProperty.Revision).Equals("RA"))
                return false;
            // Archive data? Yes Yes
            if (this.GetProperty(FileNameProperty.Revision).Equals("RA") && icarttFile.GetProperty(FileNameProperty.Revision).Equals("RA"))
                return false;

            // All others. Cut off first character. Parse the integer. Compare the integers.
            return int.Parse(this.GetProperty(FileNameProperty.Revision).Remove(0,1)) > int.Parse(icarttFile.GetProperty(FileNameProperty.Revision).Remove(0,1));
        }

    }
}
