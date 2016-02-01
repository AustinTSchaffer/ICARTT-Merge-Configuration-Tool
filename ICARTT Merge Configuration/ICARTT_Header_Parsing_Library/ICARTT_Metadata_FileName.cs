using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ICARTT_Header_Parsing_Library
{
    /// <summary>
    /// Contains and controlls access to the name and path of an ICARTT file as well as its component parts.
    /// <seealso cref="ICARTT_File"/>
    /// </summary>
    class ICARTT_Metadata_FileName
    {
        /// <summary>
        /// Holds the absolute file path to the ICARTT file from the root directory.
        /// </summary>
        private String filePath;


        #region fileName related members

        /// <summary>
        /// Holds the name of the ICARTT file, including the extension.
        /// </summary>
        private String fileName;

        /// <summary>
        /// Required field in an ICARTT file name.
        /// </summary>
        private String dataID, locationID, date, revision;

        /// <summary>
        /// Optional field in an ICARTT file name. This field can be unreliable, since the flag can be unreliable.
        /// </summary>
        private String launch, volume, comments;

        #endregion


        #region static members

        #region readonly

        /// <summary>
        /// Default member values.
        /// </summary>
        public static readonly String
            DEFAULT_FILE_PATH   = "",
            DEFAULT_DATA_ID     = "NO-DATA-ID",
            DEFAULT_LOCATION_ID = "NO-LOCATION-ID",
            DEFAULT_DATE        = "99991231",
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
        /// Fields in the name of an ICARTT file are separated by an underscore (_)
        /// </summary>
        public static readonly char FILE_NAME_FIELD_SEPARATOR = '_';

        /// <summary>
        /// The maximum length of an ICARTT file name, including the extension, is 127 characters.
        /// </summary>
        public static readonly short FILE_NAME_MAXIMUM_LENGTH = 127;

        /// <summary>
        /// All ICARTT files must have the ".ict" extension.
        /// </summary>
        public static readonly String ICARTT_FILE_EXTENSION = ".ict";

        /// <summary>
        /// The date field in the name of an ICARTT file is YYYYMMDD.
        /// </summary>
        public static readonly short DATE_MINIMUM_LENGTH = 8;

        /// <summary>
        /// The date field in the name of an ICARTT 
        /// </summary>
        public static readonly short DATE_MAXIMUM_LENGTH = 14;

        #endregion

        #region regular expressions

        /// <summary>
        /// Regular expression that matches any characters that are not alphanumeric, not periods, not underscores, and not dashes.
        /// </summary>
        public static readonly String FILE_NAME_INVALID_CHARACTERS_REGEX = "[^a-zA-Z0-9._-]";

        /// <summary>
        /// Static object for checking the inval. char. regex on file names for all instances of this class.
        /// </summary>
        private static Regex invalidFileNameCharactersRegex;

        /// <summary>
        /// Regular expression that matches any characters that are not alphanumeric, not periods, not underscores, and not dashes.
        /// </summary>
        public static readonly String ONLY_NUMBERS_REGEX = "[^0-9]";

        /// <summary>
        /// Static object for checking the inval. char. regex on file names for all instances of this class.
        /// </summary>
        private static Regex allNonDigitsRegex;

        #endregion

        #endregion


        /// <summary>
        /// 2 param constructor. Should be used for loading ICARTT files from the file system. Accepts the name and path of a file.
        /// </summary>
        /// <param name="fileName">The name of the ICARTT file, including the extension.</param>
        /// <param name="filePath">The absolute file path to the ICARTT file from the root directory.</param>
        public ICARTT_Metadata_FileName (String fileName, String filePath)
        {
            // Initialize static Regex objects if not already initialized.
            if (null == invalidFileNameCharactersRegex)
                invalidFileNameCharactersRegex = new Regex(FILE_NAME_INVALID_CHARACTERS_REGEX);
            if (null == allNonDigitsRegex)
                allNonDigitsRegex = new Regex(ONLY_NUMBERS_REGEX);
            

            // Null check before copying file path
            this.filePath = (null == filePath)? DEFAULT_FILE_PATH : String.Copy(filePath);


            this.fileName   = DEFAULT_FILE_NAME;
            dataID          = DEFAULT_DATA_ID;
            locationID      = DEFAULT_LOCATION_ID;
            date            = DEFAULT_DATE;
            revision        = DEFAULT_REVISION;
            launch          = DEFAULT_LAUNCH;
            volume          = DEFAULT_VOLUME;
            comments        = DEFAULT_COMMENTS;

            
            if (!SetFileName(fileName))
            {
                Console.WriteLine("Issue with file: " + filePath + fileName);
            }
        }


        /// <summary>
        /// Sets the name of the file. This class will not be altered unless the string meets ICARTT specifications.
        /// </summary>
        /// <param name="inputFileName">A properly formatted ICARTT file name.</param>
        /// <returns> True if the name parameter is valid. If it is valid, then all of the file name information will be correctly populated. Otherwise, this class will not be altered.</returns>
        private bool SetFileName(String inputFileName)
        {
            if (!ValidateFileName(inputFileName))
            {
                Console.WriteLine("Unable to set file name to " + inputFileName);
                return false;
            }

            fileName = String.Copy(inputFileName);
            UpdateMembersFromFileName();

            return true;
        }

        /// <summary>
        /// Checks a string to see if it can be considered a file name for an ICARTT file.
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <returns>True if the input string meets qualifications set by the ICARTT File Format Standards V1.1.</returns>
        public bool ValidateFileName(String inputFileName)
        {
            // Null checking.
            if (null == inputFileName)
            {
                Console.WriteLine("Null file name");
                return false;
            }

            // File name must be proper length.
            if (inputFileName.Length > FILE_NAME_MAXIMUM_LENGTH)
            {
                Console.WriteLine("File name too long");
                return false;
            }

            // File name must not contain invalid characters.
            if (invalidFileNameCharactersRegex.IsMatch(inputFileName))
            {
                Console.WriteLine("Invalid character in file name. " + invalidFileNameCharactersRegex.Match(inputFileName).ToString());
                return false;
            }

            // File name must contain proper extension.
            if (!inputFileName.ToUpper().Contains(ICARTT_FILE_EXTENSION.ToUpper()))
            {
                Console.WriteLine("No ICARTT Extension");
                return false;
            }


            // Remove the ICARTT file extension and split into components
            String[] unverifiedComponents =
                inputFileName
                .Substring(0, inputFileName.Length - ICARTT_FILE_EXTENSION.Length)
                .Split(FILE_NAME_FIELD_SEPARATOR);


            // A file name has 4 non-optional fields.
            if (unverifiedComponents.Length < 4)
            {
                Console.WriteLine("Not enough fields in name of file.");
                return false;
            }

            // Cannot have a blank data ID
            if (unverifiedComponents[0].Length == 0)
            {
                Console.WriteLine("Blank data ID");
                return false;
            }

            // Cannot have a blank location ID
            if (unverifiedComponents[1].Length == 0)
            {
                Console.WriteLine("Blank location ID");
                return false;
            }

            // Date must be formatted properly and in correct position.
            // This test currently only checks the length and absence of non-digit characters
            if (unverifiedComponents[2].Length < DATE_MINIMUM_LENGTH
                || unverifiedComponents[2].Length > DATE_MAXIMUM_LENGTH
                || allNonDigitsRegex.IsMatch(unverifiedComponents[2]))
            {
                // TODO break out into 3 different conditionals with 3 different error messages.
                Console.WriteLine("Issue with date.");
                return false;
            }

            // Revision must be formatted correctly and in correct position.
            if (unverifiedComponents[3].ToUpper()[0] != 'R')
            {
                Console.WriteLine("No revision number.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Updates dataID, locationID, date, revision, launch, volume, and comments after a successful modification of the file name.
        /// </summary>
        private void UpdateMembersFromFileName()
        {
            String[] fileNameComponents =
                fileName
                .Substring(0, fileName.Length - ICARTT_FILE_EXTENSION.Length)
                .Split(FILE_NAME_FIELD_SEPARATOR);

            dataID      = fileNameComponents[0];
            locationID  = fileNameComponents[1];
            date        = fileNameComponents[2];
            revision    = fileNameComponents[3];

            // TODO: Flags
            // TODO Regular expressions

            // Set optional members, if any.
            if (fileNameComponents.Length > 4)
            {
                throw new NotImplementedException();
                if (fileNameComponents[4].ToUpper()[0] == 'L')
                {

                }

            }
           
        }
        
    }

}
