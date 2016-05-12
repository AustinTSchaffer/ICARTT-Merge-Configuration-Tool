using ICARTT_Merge_Configuration.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ICARTT_Merge_Configuration.ICARTT_File_Library
{

    /// <summary>
    /// This class serves as a location to store information related to a single ICARTT file. This class holds all metadata found in the name of the file, the header of the file, and the file system's data regarding the file.
    /// </summary>
    public class ICARTT_File
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
            Volume,
            Comments
        }


        #region Readonly getters


        /// <summary>
        /// Returns a copy of the name and extension of the referenced ICARTT file.
        /// </summary>
        public string FileName { get { return String.Copy(fileNameInformation.FileName); } }


        /// <summary>
        /// Returns a copy of the path to the referenced ICARTT file from the root directory. Does not include the name or extension of the file.
        /// </summary>
        public string FilePath { get { return String.Copy(fileNameInformation.FilePath); } }


        /// <summary>
        /// Returns the size of the referenced ICARTT file (in Bytes). Defaults to -1 if file is not loaded.
        /// </summary>
        public long FileSize { get { return (null == fileInformation) ? -1 : fileInformation.Length; } }


        /// <summary>
        /// Returns the number of lines in the header of the referenced ICARTT file. Defaults to -1 if file is not loaded.
        /// </summary>
        public int LinesInHeader { get { return this.fileProperties.LinesInHeader; } }


        /// <summary>
        /// Returns the file format index of the referenced ICARTT file. Defaults to -1 if file is not loaded.
        /// </summary>
        public int FileFormatIndex { get { return this.fileProperties.FileFormatIndex; } }


        /// <summary>
        /// Returns the number of dependent variables contained in the referenced ICARTT file. Defaults to -1 if file is not loaded.
        /// </summary>
        public int NumDependentVariables { get { return this.fileProperties.NumDependentVariables; } }


        /// <summary>
        /// Returns the data interval of the referenced ICARTT file. Defaults to -1.0 if file is not loaded.
        /// </summary>
        public double DataInterval { get { return this.fileProperties.DataInterval; } }


        /// <summary>
        /// Returns the PI of the referenced ICARTT file. Defaults to "" if file is not loaded.
        /// </summary>
        public string PI { get { return String.Copy(this.fileProperties.PI); } }


        /// <summary>
        /// Returns the organization of the PI of the referenced ICARTT file. Defaults to "" if file is not loaded.
        /// </summary>
        public string Organization { get { return String.Copy(this.fileProperties.Organization); } }


        /// <summary>
        /// Returns the data source description of the referenced ICARTT file. Defaults to "" if file is not loaded.
        /// </summary>
        public string DataSourceDescription { get { return String.Copy(this.fileProperties.DataSourceDescription); } }


        /// <summary>
        /// Returns the name of the mission of the referenced ICARTT file. Defaults to "" if file is not loaded.
        /// </summary>
        public string MissionName { get { return String.Copy(this.fileProperties.MissionName); } }


        /// <summary>
        /// Returns the file volume information of the referenced ICARTT file. Defaults to "" if file is not loaded.
        /// </summary>
        public string FileVolumeInformation { get { return String.Copy(this.fileProperties.FileVolumeInformation); } }


        /// <summary>
        /// Returns the data begin date and the data revision date of the referenced ICARTT file. Defaults to "" if file is not loaded.
        /// </summary>
        public string DateInformation { get { return String.Copy(this.fileProperties.DateInformation); } }


        /// <summary>
        /// Returns the list of special comments of the referenced ICARTT file. Defaults to an empty list of strings if file is not loaded.
        /// </summary>
        public List<string> SpecialComments { get { return new List<string>(this.fileProperties.SpecialComments); } }


        /// <summary>
        /// Returns the list of normal comments of the referenced ICARTT file. Defaults to an empty list of strings if file is not loaded.
        /// </summary>
        public List<string> NormalComments { get { return new List<string>(this.fileProperties.NormalComments); } }


        /// <summary>
        /// Returns a list of the dependent variables found in the referenced ICARTT file. Defaults to an empty list if file is not loaded.
        /// </summary>
        public List<ICARTT_Variable> Variables { get { return new List<ICARTT_Variable>(this.variables); } }


        /// <summary>
        /// Returns the independent variable of the referenced ICARTT file. Defaults to null of file is not loaded.
        /// </summary>
        public ICARTT_Variable IndependentVariable
        {
            get
            {
                foreach (ICARTT_Variable ictVar in this.variables) if (ictVar.columnNumber == 0) return ictVar;

                return null;
            }
        }


        /// <summary>
        /// Returns true if the referenced ICARTT file has been loaded.
        /// </summary>
        public bool Loaded { get { return loaded; } }

        #endregion


        #region Information from file

        /// <summary>
        /// Contains the name and path of the file as well as its component parts.
        /// </summary>
        private ICARTT_FileName fileNameInformation;


        /// <summary>
        /// Contains all information from an ICARTT file header, not including data related to variables in the file.
        /// </summary>
        private ICARTT_FileProperties fileProperties;


        /// <summary>
        /// System.IO object. Used to get metadata such as the size of the file.
        /// </summary>
        private System.IO.FileInfo fileInformation;


        /// <summary>
        /// Dependendent variables of referenced ICARTT file.
        /// </summary>
        private List<ICARTT_Variable> variables;

        #endregion


        #region Timebase Variables

        /// <summary>
        /// Variable that corresponds to the time a measurement began.
        /// </summary>
        public ICARTT_Variable TimeVariable_Start;


        /// <summary>
        /// Variable that corresponds to the midpoint time of a measurement.
        /// </summary>
        public ICARTT_Variable TimeVariable_Midpoint;


        /// <summary>
        /// Variable that corresponds to the time a measurement ended.
        /// </summary>
        public ICARTT_Variable TimeVariable_Stop;

        #endregion


        #region Flags

        /// <summary>
        /// Flag to show if this ICARTT_File will be included in the merge. Default value is 'true'.
        /// </summary>
        public bool IncludeInMerge;

        /// <summary>
        /// Flag to show if this ICARTT_File has been loaded.
        /// </summary>
        private bool loaded;

        #endregion


        /// <summary>
        /// Constructor. Only loads and interprets file name and file path information.
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <param name="inputFilePath"></param>
        public ICARTT_File(string inputFileName, string inputFilePath)
        {
            this.IncludeInMerge = true;
            this.loaded = false;

            fileNameInformation = new ICARTT_FileName(inputFileName, inputFilePath);
            fileProperties = new ICARTT_FileProperties();
            variables = new List<ICARTT_Variable>();
        }


        /// <summary>
        /// Loads header information from ICARTT file. Will not run if file is already loaded.
        /// </summary>
        public void Load()
        {
            if (loaded) return;

            try
            {
                this.fileInformation = new System.IO.FileInfo(FilePath + FileName);
                if (!fileInformation.Exists) throw new System.IO.FileNotFoundException();

                System.IO.StreamReader file = new System.IO.StreamReader(FilePath + FileName);

                string[] linesAndFFI = file.ReadLine().Split(',');
                fileProperties.LinesInHeader = int.Parse(linesAndFFI[0].Trim());
                fileProperties.FileFormatIndex = int.Parse(linesAndFFI[1].Trim());

                fileProperties.PI = file.ReadLine();
                fileProperties.Organization = file.ReadLine();
                fileProperties.DataSourceDescription = file.ReadLine();
                fileProperties.MissionName = file.ReadLine();
                fileProperties.FileVolumeInformation = file.ReadLine();
                fileProperties.DateInformation = file.ReadLine();
                fileProperties.DataInterval = double.Parse(file.ReadLine());

                variables.Add(new ICARTT_Variable(
                        GetProperty(FileNameProperty.DataID),
                        file.ReadLine(), 0));

                fileProperties.NumDependentVariables = int.Parse(file.ReadLine());

                string[] scalingFactors = file.ReadLine().Split(',');
                string[] missingDataIndicators = file.ReadLine().Split(',');

                // Error logging on number of variables and quantity of variable metadata
                if (scalingFactors.Length != missingDataIndicators.Length || scalingFactors.Length != fileProperties.NumDependentVariables) Logger.Log(Logger.MessageCode.Error, typeof(ICARTT_File), MethodBase.GetCurrentMethod(), "ERROR: Mismatch (scaling factors, missing data indicators, dependent variables).", scalingFactors.Length + " scaling factors", missingDataIndicators.Length + " missing data indicators", fileProperties.NumDependentVariables + " dependent variables", "File: " + FilePath + FileName, "Expect an IndexOutOfRangeException");

                // Read in all dependent variables.
                for (int varCol = 1; varCol <= fileProperties.NumDependentVariables; ++varCol)
                {
                    variables.Add(
                        new ICARTT_Variable(
                            GetProperty(FileNameProperty.DataID),
                            file.ReadLine(),
                            varCol,
                            ICARTT_Variable.VariableType.INPUT,
                            double.Parse(scalingFactors[varCol - 1]),
                            double.Parse(missingDataIndicators[varCol - 1])
                            ));
                }

                // Read in special comments
                fileProperties.SpecialCommentLines = int.Parse(file.ReadLine());
                for (int i = 0; i < fileProperties.SpecialCommentLines; ++i) fileProperties.SpecialComments.Add(file.ReadLine());

                // Read in normal comments
                fileProperties.NormalCommentLines = int.Parse(file.ReadLine());
                for (int i = 0; i < fileProperties.NormalCommentLines; ++i) fileProperties.NormalComments.Add(file.ReadLine());

                file.Close();
                loaded = true;
            }
            catch (Exception e)
            {
                Logger.Log(typeof(ICARTT_File), MethodBase.GetCurrentMethod(), e);
                Logger.Log(Logger.MessageCode.Error, typeof(ICARTT_File), MethodBase.GetCurrentMethod(), "LOAD ERROR: " + FilePath + FileName);
                this.IncludeInMerge = false;
            }
        }


        /// <summary>
        /// Returns a copy of the field specified in the parameter. Only includes properties from the name of the file.
        /// </summary>
        /// <param name="field">The field of the property to get.</param>
        /// <returns>String copy of the field data.</returns>
        public string GetProperty(FileNameProperty field)
        {
            if (null == fileNameInformation)
            {
                Exception e = new MemberAccessException();
                Logger.Log(Logger.MessageCode.Error, typeof(ICARTT_File), MethodBase.GetCurrentMethod(), "File '" + FileName + "' not loaded correctly. Throwing exception.");
                Logger.Log(typeof(ICARTT_File), MethodBase.GetCurrentMethod(), e);
                throw e;
            }

            switch (field)
            {
                case FileNameProperty.DataID:
                    return fileNameInformation.DataID;
                case FileNameProperty.LocationID:
                    return fileNameInformation.LocationID;
                case FileNameProperty.Date:
                    return fileNameInformation.Date;
                case FileNameProperty.Revision:
                    return fileNameInformation.Revision;
                case FileNameProperty.Launch:
                    return fileNameInformation.Launch;
                case FileNameProperty.Volume:
                    return fileNameInformation.Volume;
                case FileNameProperty.Comments:
                    return fileNameInformation.Comments;
                default:
                    Exception e = new InvalidOperationException();
                    Logger.Log(typeof(ICARTT_File), MethodBase.GetCurrentMethod(), e);
                    throw e;
            }
        }


        /// <summary>
        /// Returns true if the two ICARTT Files have equivalent variable lists. Will return false based on a mismatch between the name and column number of any two ICARTT variables.
        /// </summary>
        /// <returns></returns>
        public bool VariableListMatch(ICARTT_File ictFile)
        {
            if (null == ictFile) return false;

            if (ictFile.variables.Count != this.variables.Count) return false;

            for (int i = 0; i < this.variables.Count; ++i)
            {
                ICARTT_Variable va = this.variables[i];
                ICARTT_Variable vb = ictFile.variables[i];

                if (!va.Equals(vb)) return false;
            }
            
            return true;
        }


        /// <summary>
        /// Returns true if the FileNameProperty fields of the two objects all have the same value. Fields are not case sensitive.
        /// </summary>
        /// <param name="obj">Other ICARTT_File object</param>
        /// <returns>True if the two ICARTT files are equivalent.</returns>
        public override bool Equals(object obj)
        {
            if (null == obj || GetType() != obj.GetType()) return false;

            ICARTT_File icarttFile = (ICARTT_File)obj;

            foreach (FileNameProperty property in Enum.GetValues(typeof(FileNameProperty))) if (!(this.GetProperty(property).ToUpper()).Equals(icarttFile.GetProperty(property).ToUpper())) return false;

            return true;
        }


        /// <summary>
        /// Returns the hash of the name and path of the file.
        /// </summary>
        /// <returns>Hash of the name and path of the file.</returns>
        public override int GetHashCode() { return (fileNameInformation.FilePath + fileNameInformation.FileName).GetHashCode(); }


        /// <summary>
        /// Returns true if (1) this referenced ICARTT_File file is the same as the specified data file other than the launch and (2) this ICARTT_File's launch flag is a lower number than the specified data file.
        /// </summary>
        /// <returns>Specified file.</returns>
        public bool IsEarlierLaunchThan(ICARTT_File icarttFile)
        {
            if (null == icarttFile) return false;

            // Check all fields other than Launch for equality
            foreach (FileNameProperty fnp in Enum.GetValues(typeof(FileNameProperty)))
            {
                // Launch info same? Cannot be earlier.
                if ((fnp == FileNameProperty.Launch) && this.GetProperty(fnp).ToUpper().Equals(icarttFile.GetProperty(fnp).ToUpper())) return false;

                // Field other than launch mismatch? Different data source.
                if ((fnp != FileNameProperty.Launch) && !(this.GetProperty(fnp).ToUpper()).Equals(icarttFile.GetProperty(fnp).ToUpper())) return false;
            }

            // All others. Cut off first character. Parse the integer. Compare the integers.
            return
                int.Parse(this.GetProperty(FileNameProperty.Launch).Remove(0, 1))
                <
                int.Parse(icarttFile.GetProperty(FileNameProperty.Launch).Remove(0, 1));
        }


        /// <summary>
        /// Returns a copy of the name of the file.
        /// </summary>
        /// <returns>A copy of the name of the file.</returns>
        public override string ToString()
        {
            return FileName;
        }

    }
}
