using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICARTT_Merge_Configuration.ICARTT_File_Library;
using System.IO;
using ICARTT_Merge_Configuration.Utilities;
using System.Reflection;

namespace ICARTT_Merge_Configuration.Utilities
{
    static class ICARTT_FileLoader
    {
        public static List<ICARTT_File> icarttFilesToMerge;
        public static List<ICARTT_File> omittedIcarttFiles;

        /// <summary>
        /// Returns a list containing ICARTT_File objects, built from the ICARTT files found in a directory. These ICARTT_File objects will only be initialized will file name and path information. This method will search all subdirectories of the provided root directory. This method will omit duplicate ICARTT files and ICARTT files that have newer data revisions.
        /// </summary>
        /// <param name="dir">Root directory from which to search for ICARTT files.</param>
        /// <returns>Returns a list containing ICARTT_File objects, built from the ICARTT files found in dir.</returns>
        public static List<ICARTT_File> GetICARTTFilesFromDir(string dir)
        {

            icarttFilesToMerge = new List<ICARTT_File>();
            omittedIcarttFiles = new List<ICARTT_File>();

            try
            {
                /*
                * Directory.GetFiles(dir, "*", SearchOption.AllDirectories) returns a string[]
                * This array will hold strings that represent all files nested in all directories
                * under the specified root directory. Each of these strings contains the file name 
                * and path of a distinct file.
                */
                foreach (string fileNameAndPath in Directory.GetFiles(dir, "*", SearchOption.AllDirectories))
                {
                    string fileName = fileNameAndPath.Split(Path.DirectorySeparatorChar).Last();
                    string filePath = fileNameAndPath.Replace(fileName, "");


                    // Do not run the rest of this loop if the file is not an ICARTT file.
                    if (!ICARTT_FileName.ValidateFileName(fileName))
                    {
                        Logger.Log(Logger.MessageCode.Warning, typeof(ICARTT_FileLoader), MethodBase.GetCurrentMethod(), "Non-ICARTT File: " + filePath + fileName);
                        continue;
                    }


                    // Create a new ICARTT file reference object.
                    ICARTT_File icarttFile = new ICARTT_File(fileName, filePath);
                    bool validFileForMergeList = true;


                    // Iterate through all ICARTT files that have already been added to the merge list to search for conflicts.
                    foreach (ICARTT_File previouslyFoundIcarttFile in icarttFilesToMerge)
                    {
                        // No duplicate ICARTT files will be added by default
                        // The one that is found first will be kept. Dev recognizes that this is bad.
                        if (icarttFile.Equals(previouslyFoundIcarttFile))
                        {
                            Logger.Log(Logger.MessageCode.Warning, typeof(ICARTT_FileLoader), MethodBase.GetCurrentMethod(), "Duplicate ICARTT Files Found", icarttFile.FilePath + icarttFile.FileName, previouslyFoundIcarttFile.FilePath + previouslyFoundIcarttFile.FileName);

                            omittedIcarttFiles.Add(icarttFile);
                            validFileForMergeList = false;
                            break;
                        }

                        // Check for a previously found version that is newer
                        else if (previouslyFoundIcarttFile.IsNewerVersionOf(icarttFile))
                        {
                            Logger.Log(Logger.MessageCode.Warning, typeof(ICARTT_FileLoader), MethodBase.GetCurrentMethod(), "Multiple ICARTT File Versions Found", icarttFile.FilePath + icarttFile.FileName, previouslyFoundIcarttFile.FilePath + previouslyFoundIcarttFile.FileName);

                            omittedIcarttFiles.Add(icarttFile);
                            validFileForMergeList = false;
                            break;
                        }

                        // Check to see if a previously found version is older
                        else if (icarttFile.IsNewerVersionOf(previouslyFoundIcarttFile))
                        {
                            Logger.Log(Logger.MessageCode.Warning, typeof(ICARTT_FileLoader), MethodBase.GetCurrentMethod(), "Multiple ICARTT File Versions Found", icarttFile.FilePath + icarttFile.FileName, previouslyFoundIcarttFile.FilePath + previouslyFoundIcarttFile.FileName);

                            omittedIcarttFiles.Add(previouslyFoundIcarttFile);
                            icarttFilesToMerge.Remove(previouslyFoundIcarttFile);
                            validFileForMergeList = true;
                            break;
                        }
                    }

                    // Add the file to the merge list if no conflicts are detected
                    if (validFileForMergeList) icarttFilesToMerge.Add(icarttFile);
                }
            }
            catch (Exception exception)
            {
                Logger.Log(typeof(ICARTT_FileLoader), MethodBase.GetCurrentMethod(), exception);
            }


            // Log results of file system grab.
            Logger.Log(typeof(ICARTT_FileLoader), MethodBase.GetCurrentMethod(),
                "Searched for ICARTT files", "Directory: " + dir, "Number of ICARTT Files Found: " + icarttFilesToMerge.Count, "Number of ICARTT Files Omitted: " + omittedIcarttFiles.Count);

            return icarttFilesToMerge;
        }

        /// <summary>
        /// Returns a list of all the unique location IDs found in the list of ICARTT files to merge.
        /// </summary>
        public static List<string> UniqueLocationIDs()
        {
            List<string> uLIDs = new List<string>();

            foreach (ICARTT_File icarttFile in icarttFilesToMerge) if (!uLIDs.Contains(icarttFile.GetProperty(ICARTT_File.FileNameProperty.LocationID).ToUpper())) uLIDs.Add(icarttFile.GetProperty(ICARTT_File.FileNameProperty.LocationID).ToUpper());

            return uLIDs;
        }

        /// <summary>
        /// Returns a list of all the unique dates found in the list of ICARTT files to merge.
        /// </summary>
        public static List<string> UniqueDates()
        {
            List<string> uDs = new List<string>();

            foreach (ICARTT_File icarttFile in icarttFilesToMerge) if (!uDs.Contains(icarttFile.GetProperty(ICARTT_File.FileNameProperty.Date).ToUpper())) uDs.Add(icarttFile.GetProperty(ICARTT_File.FileNameProperty.Date).ToUpper());

            return uDs;
        }

        /// <summary>
        /// Removes all ICARTT files from the list of ICARTT files to merge based on the specified property. A file will be kept in the list if and only if its specified property can be found in the list of values. Values will not be considered case sensitive.
        /// </summary>
        /// <param name="property">Filtering property</param>
        /// <param name="values">Values to keep in list of ICARTT files to merge</param>
        public static List<ICARTT_File> Filter(ICARTT_File.FileNameProperty property, List<string> values)
        {
            List<ICARTT_File> filteredFiles = new List<ICARTT_File>();

            values = values.ConvertAll(v => v.ToUpper());

            foreach (ICARTT_File ict in icarttFilesToMerge) if (!values.Contains(ict.GetProperty(property).ToUpper())) filteredFiles.Add(ict);

            icarttFilesToMerge.RemoveAll(i => filteredFiles.Contains(i));
            omittedIcarttFiles.AddRange(filteredFiles);

            Logger.Log(typeof(ICARTT_FileLoader), MethodBase.GetCurrentMethod(),
                "Filtered ICARTT Files by " , String.Format("Values: [{0}]", String.Join(", ", values)), "Number of ICARTT Files Filtered: " + filteredFiles.Count, "New Number of ICARTT Files to Merge: " + icarttFilesToMerge.Count, "New number of Omitted ICARTT Files: " + omittedIcarttFiles.Count);

            return icarttFilesToMerge;
        }

        /// <summary>
        /// Removes all ICARTT files from the list of ICARTT files to merge based on the specified property. A file will be kept in the list if and only if its specified property mathces the specified value. Value will not be considered case sensitive.
        /// </summary>
        /// <param name="property">Filtering property</param>
        /// <param name="value">Value to keep in list of ICARTT files to merge</param>
        public static List<ICARTT_File> Filter(ICARTT_File.FileNameProperty property, string value){  return Filter(property, new List<string>() { value }); }
    }
}
