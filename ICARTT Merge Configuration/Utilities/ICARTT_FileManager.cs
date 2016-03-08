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
    static class ICARTT_FileManager
    {
        /// <summary>
        /// List of ICARTT files that are to be merged.
        /// </summary>
        private static List<ICARTT_File> icarttFilesToMerge;

        /// <summary>
        /// List of all ICARTT files that could be considered for merge.
        /// </summary>
        private static List<ICARTT_File> icarttFilesInScope;

        /// <summary>
        /// Parent directory of all ICARTT files in merge.
        /// </summary>
        private static string directory;


        #region Getters

        /// <summary>
        /// Readonly. Returns parent directory of all icartt files in IcarttFilesInDirec.
        /// </summary>
        public static string Directory { get { return String.Copy(directory); } }

        /// <summary>
        /// Readonly. Returns a copy of the list of all the ICARTT files that can be considered in the scope of this merge.
        /// </summary>
        public static List<ICARTT_File> IcarttFilesInScope { get { return icarttFilesInScope; } }

        /// <summary>
        /// Readonly. Returns a copy of the list of ICARTT files that have been chosen to be merged.
        /// </summary>
        public static List<ICARTT_File> IcarttFilesToMerge { get { return icarttFilesToMerge; } }

        #endregion


        /// <summary>
        /// Invokes the Load() method of all the ICARTT_File objects in the list of ICARTT_Files to merge. This should load all of the ICARTT file header metadata into memory.
        /// </summary>
        public static void LoadAll()
        {
            if (null == icarttFilesToMerge)
            {
                Logger.Log(Logger.MessageCode.Warning, typeof(ICARTT_FileManager), MethodBase.GetCurrentMethod(), "User attempted to load files without first selecting a directory.");
                return;
            }

            foreach (ICARTT_File ictFile in icarttFilesToMerge)
            {
                Logger.Log(Logger.MessageCode.Message, typeof(ICARTT_FileManager), MethodBase.GetCurrentMethod(), "Loading: " + ictFile.FilePath + ictFile.FileName);

                ictFile.Load();
            }
        }


        /// <summary>
        /// Returns a list containing ICARTT_File objects, built from the ICARTT files found in a directory. These ICARTT_File objects will only be initialized will file name and path information. This method will search all subdirectories of the provided root directory. This method will omit duplicate ICARTT files and ICARTT files that have newer data revisions. Method references internal directory string.
        /// </summary>
        /// <returns>Returns a list containing ICARTT_File objects, built from the ICARTT files found in dir.</returns>
        public static List<ICARTT_File> GetICARTTFileFromDir() { return GetICARTTFilesFromDir(directory); }


        /// <summary>
        /// Returns a list containing ICARTT_File objects, built from the ICARTT files found in a directory. These ICARTT_File objects will only be initialized will file name and path information. This method will search all subdirectories of the provided root directory.
        /// </summary>
        /// <param name="dir">Root directory from which to search for ICARTT files.</param>
        /// <returns>Returns a list containing ICARTT_File objects, built from the ICARTT files found in dir.</returns>
        public static List<ICARTT_File> GetICARTTFilesFromDir(string dir)
        {

            if (null == icarttFilesInScope) icarttFilesInScope = new List<ICARTT_File>();
            else icarttFilesInScope.Clear();

            directory = String.Copy(dir);

            try
            {
                /*
                * Directory.GetFiles(dir, "*", SearchOption.AllDirectories) returns a string[]
                * This array will hold strings that represent all files nested in all directories
                * under the specified root directory. Each of these strings contains the file name 
                * and path of a distinct file.
                */
                foreach (string fileNameAndPath in System.IO.Directory.GetFiles(dir, "*", SearchOption.AllDirectories))
                {
                    string fileName = fileNameAndPath.Split(Path.DirectorySeparatorChar).Last();
                    string filePath = fileNameAndPath.Replace(fileName, "");


                    // Do not run the rest of this loop if the file is not an ICARTT file.
                    if (!ICARTT_FileName.ValidateFileName(fileName)) continue;

                    // Create a new ICARTT file reference object.
                    ICARTT_File icarttFile = new ICARTT_File(fileName, filePath);
                    icarttFilesInScope.Add(icarttFile);

                }
            }
            catch (Exception exception)
            {
                Logger.Log(typeof(ICARTT_FileManager), MethodBase.GetCurrentMethod(), exception);
            }

            // Log results of file system grab.
            Logger.Log(typeof(ICARTT_FileManager), MethodBase.GetCurrentMethod(), "Searched for ICARTT files", "Directory: " + dir, "Number of ICARTT Files Found: " + icarttFilesInScope.Count);

            return IcarttFilesInScope;
        }


        /// <summary>
        /// Returns a list of all the unique values of a particular property found in the list of ICARTT files provided.
        /// </summary>
        /// <param name="property">Desired unique property</param>
        /// <param name="files">List of files to search for unique properties.</param>
        public static List<string> GetUnique(ICARTT_File.FileNameProperty property, List<ICARTT_File> files)
        {
            List<string> uniqueStrings = new List<string>();

            foreach (ICARTT_File icarttFile in files) if (!uniqueStrings.Contains(icarttFile.GetProperty(property).ToUpper())) uniqueStrings.Add(icarttFile.GetProperty(property).ToUpper());

            return uniqueStrings;
        }


        /// <summary>
        /// Returns a hashing of the collection of ICARTT files in scope. Can be used to determine if more files were added or removed.
        /// </summary>
        /// <returns>0 if null</returns>
        public static int Hash()
        {
            if (null == icarttFilesInScope || icarttFilesInScope.Count == 0) return 0;

            unchecked
            {
                int hash = 19;

                foreach (ICARTT_File i in icarttFilesInScope) hash = hash * 31 + ((null == i)? 7 : i.GetHashCode());

                return hash;
            }
        } 

        #region Filtering methods and structures


        /// <summary>
        /// Small class used to determine if an ICARTT file contains a previously selected value of a particular property in its file name.
        /// </summary>
        private class FileNameFilter
        {
            private ICARTT_File.FileNameProperty property;
            private List<string> values;

            public FileNameFilter(ICARTT_File.FileNameProperty property, List<string> values)
            {
                this.property = property;
                this.values = (null != values) ? new List<string>(values) : new List<string>();
            }

            /// <summary>
            /// Returns true if the specified file's previously specified property can be found in the list of previously specified values.
            /// </summary>
            /// <param name="icarttFile">ICARTT_File object to check against filter.</param>
            /// <returns></returns>
            public bool Pass(ICARTT_File icarttFile)
            {
                if (null == values || values.Count == 0) return true;
                return values.Contains(icarttFile.GetProperty(property).ToUpper());
            }


            /// <summary>
            /// Two filters are equal if they filter based on the same property.
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                if (null == obj || GetType() != obj.GetType()) return false;
                return ((FileNameFilter)obj).property == this.property;
            }

            public override int GetHashCode() { return values.GetHashCode(); }
        }


        private static List<FileNameFilter> filters;


        /// <summary>
        /// Removes all previously added file name filters.
        /// </summary>
        public static void ClearFilter()
        {
            if (null == filters) filters = new List<FileNameFilter>();

            else filters.Clear();
        }


        /// <summary>
        /// Adds a property to filter internal set of ICARTT files. Method can be called multiple times before the FileNameFilter() method is called. If a property is specified that has already been specified, the previous entry will be overwritten.
        /// </summary>
        /// <param name="property">Filtering property</param>
        /// <param name="values">Desired values</param>
        public static void AddFilter(ICARTT_File.FileNameProperty property, List<string> values)
        {
            if (null == filters) filters = new List<FileNameFilter>();

            FileNameFilter newFilter = new FileNameFilter(property, values);

            filters.RemoveAll(oldFilter => oldFilter.Equals(newFilter));

            filters.Add(newFilter);
        }


        /// <summary>
        /// Filters a list based on previously specifed properties. Files that pass through the filters will also be selected based on their equivalence to other files and .
        /// </summary>
        /// <returns>Reference to list of ICARTT files to include in merge.</returns>
        public static List<ICARTT_File> Filter()
        {
            if (null == icarttFilesToMerge) icarttFilesToMerge = new List<ICARTT_File>();
            else icarttFilesToMerge.Clear();

            foreach (ICARTT_File icarttFile in icarttFilesInScope) if (ICARTT_FileManager.Pass(icarttFile)) AddToMergeList(icarttFile);

            return IcarttFilesToMerge;
        }


        /// <summary>
        /// Adds an ICARTT_File to the list of files to merge if it is not already in the list of files to merge.
        /// </summary>
        /// <param name="icarttFile"></param>
        /// <returns>True if file was added.</returns>
        private static bool AddToMergeList(ICARTT_File icarttFile)
        {
            // Iterate through all ICARTT files that have already been added to the merge list to search for conflicts.
            foreach (ICARTT_File previouslyFoundIcarttFile in icarttFilesToMerge)
            {
                // No duplicate ICARTT files will be added
                if (icarttFile.Equals(previouslyFoundIcarttFile)) return false;
            }

            // Add if all loop conditions are met, or first record.
            icarttFilesToMerge.Add(icarttFile);
            return true;
        }


        /// <summary>
        /// Checks the specified ICARTT_File against all of the specified filters. If no filters have been specified, then the file passes automatically.
        /// </summary>
        /// <param name="icarttFile">Specified file</param>
        /// <returns>True if file passes through all specified filters.</returns>
        private static bool Pass(ICARTT_File icarttFile)
        {
            if (null == filters || filters.Count == 0) return true;

            bool pass = true;
            filters.ForEach(filter => pass &= filter.Pass(icarttFile));
            return pass;
        }

        #endregion
    }
}
