using ICARTT_Merge_Configuration.ICARTT_File_Library.Variables;
using ICARTT_Merge_Configuration.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;

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


        #region Readonly getters

        public string FileName { get { return String.Copy(FileNameInformation.FileName); } }

        public string FilePath { get { return String.Copy(FileNameInformation.FilePath); } }

        public long FileSize { get { return FileInformation.Length; } }

        public int LinesInHeader { get { return this.FileProperties.LinesInHeader; } }

        public int FileFormatIndex { get { return this.FileProperties.FileFormatIndex; } }

        public int NumDependentVariables { get { return this.FileProperties.NumDependentVariables; } }

        public double DataInterval { get { return this.FileProperties.DataInterval; } }

        public string PI { get { return String.Copy(this.FileProperties.PI); } }

        public string Organization { get { return String.Copy(this.FileProperties.Organization); } }

        public string DataSourceDescription { get { return String.Copy(this.FileProperties.DataSourceDescription); } }

        public string MissionName { get { return String.Copy(this.FileProperties.MissionName); } }

        public string FileVolumeInformation { get { return String.Copy(this.FileProperties.FileVolumeInformation); } }

        public string DateInformation { get { return String.Copy(this.FileProperties.DateInformation); } }

        public List<string> SpecialComments { get { return new List<string>(this.FileProperties.SpecialComments); } }

        public List<string> NormalComments { get { return new List<string>(this.FileProperties.NormalComments); } }

        

        #endregion


        #region Information from file

        /// <summary>
        /// Contains the name and path of the file as well as its component parts.
        /// </summary>
        private ICARTT_FileName FileNameInformation;

        


        /// <summary>
        /// Contains all information from an ICARTT file header, not including data related to variables in the file.
        /// </summary>
        private ICARTT_FileProperties FileProperties;
        private System.IO.FileInfo FileInformation;
        private ICARTT_Variable independentVariable;
        private List<ICARTT_Variable> dependentVariables;


        #endregion


        /// <summary>
        /// Constructor. Only loads and interprets file name and file path information.
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <param name="inputFilePath"></param>
        public ICARTT_File(string inputFileName, string inputFilePath)
        {
            FileNameInformation = new ICARTT_FileName(inputFileName, inputFilePath);
            FileProperties = new ICARTT_FileProperties(GetHashCode());
            dependentVariables = new List<ICARTT_Variable>();
        }


        /// <summary>
        /// Loads header information from ICARTT file.
        /// </summary>
        public void Load()
        {

            try
            {
                this.FileInformation = new System.IO.FileInfo(FilePath + FileName);
                if (!FileInformation.Exists) throw new System.IO.FileNotFoundException();

                System.IO.StreamReader file = new System.IO.StreamReader(FilePath + FileName);

                string[] linesAndFFI                 = file.ReadLine().Split(',');
                FileProperties.LinesInHeader         = int.Parse(linesAndFFI[0].Trim());
                FileProperties.FileFormatIndex       = int.Parse(linesAndFFI[1].Trim());

                FileProperties.PI                    = file.ReadLine();
                FileProperties.Organization          = file.ReadLine();
                FileProperties.DataSourceDescription = file.ReadLine();
                FileProperties.MissionName           = file.ReadLine();
                FileProperties.FileVolumeInformation = file.ReadLine();
                FileProperties.DateInformation       = file.ReadLine();
                FileProperties.DataInterval          = double.Parse(file.ReadLine());
                independentVariable = new ICARTT_Variable(file.ReadLine(), 0, 1, -1);
                FileProperties.NumDependentVariables = int.Parse(file.ReadLine());

                string[] scalingFactors              = file.ReadLine().Split(',');
                string[] missingDataIndicators       = file.ReadLine().Split(',');

                // Error logging on number of variables and quantity of variable metadata
                if (scalingFactors.Length != missingDataIndicators.Length || scalingFactors.Length != FileProperties.NumDependentVariables) Logger.Log(Logger.MessageCode.Error, typeof(ICARTT_File), MethodBase.GetCurrentMethod(), "ERROR: Mismatch (scaling factors, missing data indicators, dependent variables).", scalingFactors.Length + " scaling factors", missingDataIndicators.Length + " missing data indicators", FileProperties.NumDependentVariables + " dependent variables", "File: " + FilePath + FileName, "Expect an IndexOutOfRangeException");

                // Read in all dependent variables.
                for (int varCol = 1; varCol <= FileProperties.NumDependentVariables; ++varCol)
                {
                    dependentVariables.Add(
                        new ICARTT_Variable(
                            file.ReadLine(), 
                            varCol, 
                            double.Parse(scalingFactors[varCol - 1]), 
                            double.Parse(missingDataIndicators[varCol - 1])
                            ));
                }

                // Read in special comments
                FileProperties.SpecialCommentLines = int.Parse(file.ReadLine());
                for (int i = 0; i < FileProperties.SpecialCommentLines; ++i)FileProperties.SpecialComments.Add(file.ReadLine());

                // Read in normal comments
                FileProperties.NormalCommentLines = int.Parse(file.ReadLine());
                for (int i = 0; i < FileProperties.NormalCommentLines; ++i) FileProperties.NormalComments.Add(file.ReadLine());

                file.Close();
            }
            catch (Exception e)
            {
                Logger.Log(typeof(ICARTT_File), MethodBase.GetCurrentMethod(), e);
                Logger.Log(Logger.MessageCode.Error, typeof(ICARTT_File), MethodBase.GetCurrentMethod(), "LOAD ERROR: " + FilePath + FileName);
            }
        }


        /// <summary>
        /// Returns a copy of the field specified in the parameter.
        /// </summary>
        /// <param name="field">The field of the property to get.</param>
        /// <returns>String copy of the field data.</returns>
        public string GetProperty(FileNameProperty field)
        {
            if (null == FileNameInformation)
            {
                Exception e = new MemberAccessException();
                Logger.Log(Logger.MessageCode.Error, typeof(ICARTT_File), MethodBase.GetCurrentMethod(), "File '" + FileName + "' not loaded correctly. Throwing exception.");
                Logger.Log(typeof(ICARTT_File), MethodBase.GetCurrentMethod(), e);
                throw e;
            }

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
                    Exception e = new InvalidOperationException();
                    Logger.Log(typeof(ICARTT_File), MethodBase.GetCurrentMethod(), e);
                    throw e;
            }
        }


        /// <summary>
        /// Returns true if the FileNameProperty fields of the two objects all have the same value. Fields are not case sensitive.
        /// </summary>
        /// <param name="obj">Other ICARTT_File object</param>
        /// <returns>True if the two ICARTT files are equivalent.</returns>
        public override bool Equals(object obj)
        {
            if (null == obj || GetType() != obj.GetType()) return false;

            ICARTT_File icarttFile = (ICARTT_File) obj;

            foreach (FileNameProperty property in Enum.GetValues(typeof(FileNameProperty))) if (!(this.GetProperty(property).ToUpper()).Equals(icarttFile.GetProperty(property).ToUpper())) return false;

            return true;
        }


        /// <summary>
        /// Returns the hash of the name and path of the file.
        /// </summary>
        /// <returns>Hash of the name and path of the file.</returns>
        public override int GetHashCode() { return (FileNameInformation.FilePath + FileNameInformation.FileName).GetHashCode(); }


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


        public override string ToString()
        {
            return String.Format("File Name: {1}{0}File Path: {2}{0}FFI: {3}{0}PI: {4}{0}Organization: {5}{0}Mission: {6}{0}Data Source: {7}{0}Number of Variables: {8}", Environment.NewLine, this.FileName, this.FilePath, this.FileProperties.FileFormatIndex, this.FileProperties.PI, this.FileProperties.Organization, this.FileProperties.MissionName, this.FileProperties.DataSourceDescription, this.FileProperties.NumDependentVariables + 1);
        }

    }
}
