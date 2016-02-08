using ICARTT_Merge_Configuration.Logging;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ICARTT_Merge_Configuration.ICARTT_Header_Parsing_Library
{
    /// <summary>
    /// Contains and controlls access to the name and path of an ICARTT file as well as the name's component parts.
    /// <seealso cref="ICARTT_File"/>
    /// </summary>
    class ICARTT_Metadata_FileName
    {

        #region fileName related members

        /// <summary>
        /// Holds the name of the ICARTT file, including the extension.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Holds the absolute file path to the ICARTT file from the root directory.
        /// </summary>
        private string filePath;

        /// <summary>
        /// Required field in an ICARTT file name.
        /// </summary>
        private string dataID, locationID, date, revision;

        /// <summary>
        /// Optional field in an ICARTT file name. This field can be unreliable, since the flag       can be unreliable.
        /// </summary>
        private string launch, volume, comments;

        #endregion


        #region fileName related getters

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string FileName { get { return string.Copy(fileName); } }

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string FilePath { get { return string.Copy(filePath); } }

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string DataID { get { return string.Copy(dataID); } }

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string LocationID { get { return string.Copy(locationID); } }

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string Date { get { return string.Copy(date); } }

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string Revision { get { return string.Copy(revision); } }

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string Launch { get { return string.Copy(launch); } }

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string Volume { get { return string.Copy(volume); } }

        /// <summary>
        /// Returns a copy of the member. Can not be used for altering class members.
        /// </summary>
        public string Comments { get { return string.Copy(comments); } }

        #endregion


        #region static members

        #region readonly

        /// <summary>
        /// Default member values.
        /// </summary>
        public static readonly string
            DEFAULT_FILE_PATH   = Directory.GetCurrentDirectory(),
            DEFAULT_DATA_ID     = "NO-DATA-ID",
            DEFAULT_LOCATION_ID = "NO-LOCATION-ID",
            DEFAULT_DATE        = "99999999",
            DEFAULT_REVISION    = "R0",
            DEFAULT_LAUNCH      = "L0",
            DEFAULT_VOLUME      = "V0",
            DEFAULT_COMMENTS    = "NO-COMMENTS",
            DEFAULT_FILE_NAME   = 
            (
                DEFAULT_DATA_ID + "_" +
                DEFAULT_LOCATION_ID + "_" +
                DEFAULT_DATE + "_" +
                DEFAULT_REVISION +
                ICARTT_FILE_EXTENSION
            );

        /// <summary>
        /// All ICARTT files must have the ".ict" extension.
        /// </summary>
        public static readonly string ICARTT_FILE_EXTENSION = ".ict";

        /// <summary>
        /// Fields in the name of an ICARTT file are separated by an underscore (_)
        /// </summary>
        public static readonly char FIELD_SEPARATOR = '_';

        /// <summary>
        /// The maximum length of an ICARTT file name, including the extension, is 127 characters.
        /// </summary>
        public static readonly short FILE_NAME_MAXIMUM_LENGTH = 127;

        /// <summary>
        /// ICARTT file names have required fields and extensions, which creates an implied minimum length property. Example: X_X_20160204_R0.ict
        /// </summary>
        public static readonly short FILE_NAME_MINIMUM_LENGTH = 19;

        /// <summary>
        /// The required date information in the name of an ICARTT file is YYYYMMDD.
        /// </summary>
        public static readonly short DATE_MINIMUM_LENGTH = 8;

        /// <summary>
        /// The date field in the name of an ICARTT can contain additional [hh[mm[ss]]]
        /// </summary>
        public static readonly short DATE_MAXIMUM_LENGTH = 14;

        #endregion

        #region regular expressions

        /// <summary>
        /// Regular expression that matches all characters that are not alphanumeric, not periods, not underscores, and not dashes.
        /// </summary>
        public static readonly string FILE_NAME_INVALID_CHARACTERS_REGEX = "[^a-zA-Z0-9._-]";

        /// <summary>
        /// Regular expression that matches all characters that are not digits.
        /// </summary>
        public static readonly string ONLY_NUMBERS_REGEX = "[^0-9]";

        /// <summary>
        /// Regular expression that matches the launch information from the name of an ICARTT file. The launch information starts with an 'L' or an 'l' and is followed by 1 or 2 digits.
        /// </summary>
        public static readonly string LAUNCH_INFORMATION_REGEX = "^[Ll][0-9]{1,2}$";

        /// <summary>
        /// Regular expression that matches the volume information from the name of an ICARTT file. The volume information starts with a 'V' or a 'v' and is followed by 1 or 2 digits.
        /// </summary>
        public static readonly string VOLUME_INFORMATION_REGEX = "^[Vv][0-9]{1,2}$";

        /// <summary>
        /// Static Regex object for checking the inval. char. regex on file names for all instances of this class.
        /// </summary>
        private static Regex invalidFileNameCharactersRegex;

        /// <summary>
        /// Static Regex object for checking for non-digit characters.
        /// </summary>
        private static Regex allNonDigitsRegex;

        /// <summary>
        /// Static Regex object for checking for launch information.
        /// </summary>
        private static Regex launchRegex;

        /// <summary>
        /// Static Regex object for checking for volume information.
        /// </summary>
        private static Regex volumeRegex;

        #endregion

        #endregion


        /// <summary>
        /// 2 param constructor. Should be used for loading ICARTT files from the file system. Accepts the name and path of a file.
        /// </summary>
        /// <param name="inputFileName">The name of the ICARTT file, including the extension.</param>
        /// <param name="inputFilePath">The absolute file path to the ICARTT file from the root directory.</param>
        public ICARTT_Metadata_FileName (string inputFileName, string inputFilePath)
        {
            // Initialize static Regex objects if not already initialized.
            if (null == invalidFileNameCharactersRegex)
                invalidFileNameCharactersRegex = new Regex(FILE_NAME_INVALID_CHARACTERS_REGEX);
            if (null == allNonDigitsRegex)
                allNonDigitsRegex = new Regex(ONLY_NUMBERS_REGEX);
            if (null == launchRegex)
                launchRegex = new Regex(LAUNCH_INFORMATION_REGEX);
            if (null == volumeRegex)
                volumeRegex = new Regex(VOLUME_INFORMATION_REGEX);

            

            // Null check before copying file path
            filePath = (null == inputFilePath)? DEFAULT_FILE_PATH : string.Copy(inputFilePath);

            // Default initialization.
            fileName   = DEFAULT_FILE_NAME;
            dataID     = DEFAULT_DATA_ID;
            locationID = DEFAULT_LOCATION_ID;
            date       = DEFAULT_DATE;
            revision   = DEFAULT_REVISION;
            launch     = DEFAULT_LAUNCH;
            volume     = DEFAULT_VOLUME;
            comments   = DEFAULT_COMMENTS;


            if (!ValidateFileName(inputFileName))
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "Invalid file name", String.Format("File name: {0}", inputFileName), String.Format("File path: {0}", inputFilePath), "Initialized to default");
            }
            else
            {
                fileName = string.Copy(inputFileName);
                UpdateMembersFromFileName();
            }
        }


        /// <summary>
        /// Checks a string to see if it can be considered a file name for an ICARTT file. Method contains a list of conditionals that the file name must pass.
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <returns>True if the input string meets qualifications set by the ICARTT File Format Standards V1.1.</returns>
        public bool ValidateFileName(string inputFileName)
        {
            // Null checking.
            if (null == inputFileName)
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "Input file name was null");
                return false;
            }


            // File name must be proper length.
            if (inputFileName.Length > FILE_NAME_MAXIMUM_LENGTH)
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name is too long", String.Format("File name: {0}", inputFileName), String.Format("Maximum length: {0,3} Actual length: {1,3}", FILE_NAME_MAXIMUM_LENGTH, inputFileName.Length));
                return false;
            }
            if (inputFileName.Length < FILE_NAME_MINIMUM_LENGTH)
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name is too short", String.Format("File name: {0}", inputFileName), String.Format("Minimum length: {0,3} Actual length: {1,3}", FILE_NAME_MINIMUM_LENGTH, inputFileName.Length));
                return false;
            }


            // File name must not contain invalid characters.
            if (invalidFileNameCharactersRegex.IsMatch(inputFileName))
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name contains an invalid character", String.Format("File name: {0}", inputFileName), String.Format("Character found: {0}", invalidFileNameCharactersRegex.Match(inputFileName).ToString()));
                return false;
            }





            // File name must contain proper extension.
            if (!inputFileName.Substring(inputFileName.Length - ICARTT_FILE_EXTENSION.Length).ToUpper().Equals(ICARTT_FILE_EXTENSION.ToUpper()))
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name does not contain an ICARTT extension", String.Format("File name: {0}", inputFileName), String.Format("Expected extension: {0}", ICARTT_FILE_EXTENSION));
                return false;
            }


            // Remove the ICARTT file extension and split into components
            string[] unverifiedComponents =
                inputFileName
                .Substring(0, inputFileName.Length - ICARTT_FILE_EXTENSION.Length)
                .Split(FIELD_SEPARATOR);


            // A file name has 4 non-optional fields.
            if (unverifiedComponents.Length < 4)
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name does not contain all 4 required fields", String.Format("File name: {0}", inputFileName));
                return false;
            }


            // Cannot have a blank data ID
            if (unverifiedComponents[0].Length == 0)
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name contains a blank data ID", String.Format("File name: {0}", inputFileName));
                return false;
            }


            // Cannot have a blank location ID
            if (unverifiedComponents[1].Length == 0)
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name contains a blank location ID", String.Format("File name: {0}", inputFileName));
                return false;
            }


            // Date must be formatted properly and in correct position.
            // These tests check the length and check for non-digit characters
            if (allNonDigitsRegex.IsMatch(unverifiedComponents[2]))
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name date information contains a non-digit character", String.Format("File name: {0}", inputFileName), String.Format("Character found: {0}", allNonDigitsRegex.Match(unverifiedComponents[2]).ToString()));
                return false;
            }
            if (unverifiedComponents[2].Length < DATE_MINIMUM_LENGTH)
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name date information is too short", String.Format("File name: {0}", inputFileName), String.Format("Minimum Length: {0} Actual Length: {1}", DATE_MINIMUM_LENGTH, unverifiedComponents[2].Length));
                return false;
            }
            if (unverifiedComponents[2].Length > DATE_MAXIMUM_LENGTH)
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name date information is too long", String.Format("File name: {0}", inputFileName), String.Format("Maximum Length: {0} Actual Length: {1}", DATE_MINIMUM_LENGTH, unverifiedComponents[2].Length));
                return false;
            }


            // Revision must be formatted correctly and in correct position.
            if (unverifiedComponents[3].ToUpper()[0] != 'R')
            {
                Logger.Log(Logger.MessageCode.Error, GetType(), MethodBase.GetCurrentMethod(), "File name does not contain a recognizable revision number", String.Format("File name: {0}", inputFileName));
                return false;
            }


            Logger.Log(Logger.MessageCode.Message, GetType(), MethodBase.GetCurrentMethod(), String.Format("Successfully validated file name: {0}", inputFileName));
            return true;
        }


        /// <summary>
        /// Updates dataID, locationID, date, revision, launch, volume, and comments after a successful modification of the file name.
        /// </summary>
        private void UpdateMembersFromFileName()
        {
            string[] fileNameComponents =
                FileName
                .Substring(0, FileName.Length - ICARTT_FILE_EXTENSION.Length)
                .Split(FIELD_SEPARATOR);

            dataID      = fileNameComponents[0];
            locationID  = fileNameComponents[1];
            date        = fileNameComponents[2];
            revision    = fileNameComponents[3];



            /*
                   Launch Info? --> |----|
                   Volume Info? --> |----|----|   
                       Comments --> |----_----_----...
            dataID_locID_YYYYMMDD_R0_####_####_####...

            Process:
                   
            i = 4:
                Check first ambiguous position for launch info.
                No launch info? check it for volume info.
                Otherwise, append it to comments.

            i = 5:
                Check second ambiguous position for volume info.
                Otherwise, append it to comments.

            i >= 6:
                Append it to comments
            
            */
            StringBuilder commentsBuilder = new StringBuilder();
            for (int i = 4; i < fileNameComponents.Length; ++i)
            {
                if (i == 4 && launchRegex.IsMatch(fileNameComponents[i]))
                {
                    launch = fileNameComponents[i];
                }
                else if ((i == 4 || i == 5) && volumeRegex.IsMatch(fileNameComponents[i]))
                {
                    volume = fileNameComponents[i];
                }
                else
                {
                    commentsBuilder.Append(fileNameComponents[i]);
                    if (i != fileNameComponents.Length - 1)
                        commentsBuilder.Append(FIELD_SEPARATOR);
                }
                
            }

            string commentsFound = commentsBuilder.ToString();
            comments = (null == commentsFound || commentsFound.Equals(""))? DEFAULT_COMMENTS : commentsFound;
        }


        /// <summary>
        /// Outputs a string representation of this object.
        /// </summary>
        /// <returns>A formatted string representation of this object.</returns>
        public override string ToString()
        {

            StringBuilder outputBuilder = new StringBuilder();

            outputBuilder
                .Append(String.Format("File Name: {0}{1}",     FileName,   Environment.NewLine))
                .Append(String.Format("  File Path:   {0}{1}", FilePath,   Environment.NewLine))
                .Append(String.Format("  Data ID:     {0}{1}", DataID,     Environment.NewLine))
                .Append(String.Format("  Location ID: {0}{1}", LocationID, Environment.NewLine))
                .Append(String.Format("  Date String: {0}{1}", Date,       Environment.NewLine))
                .Append(String.Format("  Revision:    {0}{1}", Revision,   Environment.NewLine))
                .Append(String.Format("  Launch:      {0}{1}", Launch,     Environment.NewLine))
                .Append(String.Format("  Volume:      {0}{1}", Volume,     Environment.NewLine))
                .Append(String.Format("  Comments:    {0}{1}", Comments,   Environment.NewLine));
            
            return outputBuilder.ToString();

        }


        /// <summary>
        /// Checks this file's name metadata against another file's name metadata to check for equality. The two files are equal if 
        /// </summary>
        /// <param name="obj">Object to check equality to.</param>
        /// <returns>True if obj is an ICARTT_Metadata_FileName type with the same file name.</returns>
        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;

            return Equals(obj as ICARTT_Metadata_FileName);
        }


        /// <summary>
        /// Checks this file's name metadata against another file's name metadata to check for equality. The two files are equal if 
        /// </summary>
        /// <param name="other">Other metadata class to check equality to.</param>
        /// <returns>True if other is an ICARTT_Metadata_FileName type with the same file name.</returns>
        public bool Equals(ICARTT_Metadata_FileName other)
        {
            return (null != other) && (other.FileName.ToUpper().Equals(FileName.ToUpper()));
        }


        /// <summary>
        /// Returns a hash code based on the name of the file.
        /// </summary>
        /// <returns>FimeName.GetHashCode()</returns>
        public override int GetHashCode()
        {
            return FileName.GetHashCode();
        }
    }

}
