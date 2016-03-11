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
        /// List of all ICARTT files that could be considered for merge.
        /// </summary>
        private static List<ICARTT_File> allIcarttFiles;

        /// <summary>
        /// Parent directory of all ICARTT files in merge.
        /// </summary>
        private static string directory;


        #region Getters

        /// <summary>
        /// Readonly. Returns parent directory of all icartt files in IcarttFilesInDirec.
        /// </summary>
        public static string Directory
        {
            get
            {
                return String.Copy(directory);
            }
        }

        /// <summary>
        /// Readonly. Returns a copy of the list of all the ICARTT files that can be considered in the scope of this merge.
        /// </summary>
        public static List<ICARTT_File> IcarttFilesInScope
        {
            get
            {
                List<ICARTT_File> filesInScope = new List<ICARTT_File>();
                if (null != allIcarttFiles) filesInScope.AddRange(allIcarttFiles);
                return allIcarttFiles;
            }
        }

        /// <summary>
        /// Readonly. Returns a copy of the list of ICARTT files that have been chosen to be merged.
        /// </summary>
        public static List<ICARTT_File> IcarttFilesToMerge
        {
            get
            {
                List<ICARTT_File> filesToMerge = new List<ICARTT_File>();

                foreach (ICARTT_File ictFile in allIcarttFiles) if (ictFile.IncludeInMerge) filesToMerge.Add(ictFile);

                return filesToMerge;
            }
        }


        /// <summary>
        /// Returns a list containing all of the ICARTT files with the specified property. Can be used to only get files with a particular data ID.
        /// </summary>
        /// <param name="property">Desired property</param>
        /// <param name="value">Desired Value</param>
        /// <param name="inMergeRequired">Set false if user wants all files in directory. Defaults to true, which will make the method only grab files that have been selected for mergins.</param>
        /// <returns></returns>
        public static List<ICARTT_File> IcarttFiles(ICARTT_File.FileNameProperty property, string value, bool inMergeRequired = true)
        {
            List<ICARTT_File> files = new List<ICARTT_File>();
            if (null == allIcarttFiles || allIcarttFiles.Count <= 0) return files;

            foreach (ICARTT_File ictFile in allIcarttFiles)
            {
                if (null == ictFile) continue;

                bool flagMatch = !inMergeRequired || (ictFile.IncludeInMerge && inMergeRequired);

                if (flagMatch && ictFile.GetProperty(property).ToUpper().Equals(value.ToUpper())) files.Add(ictFile);
            }

            return files;
        }

        #endregion


        /// <summary>
        /// Invokes the Load() method of all the ICARTT_File objects in the list of ICARTT_Files to merge. This should load all of the ICARTT file header metadata into memory.
        /// </summary>
        public static void LoadAll()
        {
            foreach (ICARTT_File ictFile in allIcarttFiles)
            {
                if (ictFile.IncludeInMerge)
                {
                    Logger.Log(Logger.MessageCode.Debug, typeof(ICARTT_FileManager), MethodBase.GetCurrentMethod(), "Loading: " + ictFile.FilePath + ictFile.FileName);

                    ictFile.Load();
                }
            }
        }


        /// <summary>
        /// Returns a list containing ICARTT_File objects, built from the ICARTT files found in a directory. These ICARTT_File objects will only be initialized will file name and path information. This method will search all subdirectories of the provided root directory. This method will omit duplicate ICARTT files and ICARTT files that have newer data revisions. Method references internal directory string.
        /// </summary>
        /// <returns>Returns a list containing ICARTT_File objects, built from the ICARTT files found in dir.</returns>
        public static void GetICARTTFileFromDir() { GetICARTTFilesFromDir(directory); }


        /// <summary>
        /// Returns a list containing ICARTT_File objects, built from the ICARTT files found in a directory. These ICARTT_File objects will only be initialized will file name and path information. This method will search all subdirectories of the provided root directory.
        /// </summary>
        /// <param name="dir">Root directory from which to search for ICARTT files.</param>
        /// <returns>Returns a list containing ICARTT_File objects, built from the ICARTT files found in dir.</returns>
        public static void GetICARTTFilesFromDir(string dir)
        {

            if (null == allIcarttFiles) allIcarttFiles = new List<ICARTT_File>();
            else allIcarttFiles.Clear();

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
                    allIcarttFiles.Add(icarttFile);

                }
            }
            catch (Exception exception)
            {
                Logger.Log(typeof(ICARTT_FileManager), MethodBase.GetCurrentMethod(), exception);
            }

            // Log results of file system grab.
            Logger.Log(typeof(ICARTT_FileManager), MethodBase.GetCurrentMethod(), "Searched for ICARTT files", "Directory: " + dir, "Number of ICARTT Files Found: " + allIcarttFiles.Count);
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


        #region Hash functions

        /// <summary>
        /// Returns a hashing of the collection of ICARTT files in scope. Can be used to determine if more files were added or removed.
        /// </summary>
        /// <returns></returns>
        public static int AllFilesHash()
        {
            unchecked
            {
                if (null == allIcarttFiles || allIcarttFiles.Count == 0) return 0;

                int hash = 19;

                foreach (ICARTT_File i in allIcarttFiles)
                {
                    hash = hash * 31 + ((null == i) ? 7 : i.GetHashCode());
                }

                return hash;
            }
        }
        

        /// <summary>
        /// Returns a hashing of the collection of ICARTT files that have been selected to merge. Can be used to determine if more files were checked or unchecked.
        /// </summary>
        /// <returns></returns>
        public static int MergeFilesHash()
        {
            unchecked
            {
                if (null == allIcarttFiles || allIcarttFiles.Count == 0) return 0;

                List<ICARTT_File> mergelist = IcarttFilesToMerge;

                if (null == mergelist || mergelist.Count == 0) return 0;

                int hash = 19;

                foreach (ICARTT_File i in mergelist)
                {
                    hash = hash * 31 + ((null == i) ? 7 : i.GetHashCode());
                }

                return hash;
            }
        }


        /// <summary>
        /// Returns a hashing of the collection of ICARTT file filters that have been selected to narrow the list of ICARTT files to merge. Can be used to determine if any filters were added, removed, or altered.
        /// </summary>
        /// <returns></returns>
        public static int FilterHash()
        {
            unchecked
            {
                if (null == filters || filters.Count == 0) return 0;

                int hash = 19;

                foreach (FileNameFilter f in filters)
                {
                    hash = hash * 31 + ((null == f) ? 7 : f.GetHashCode());
                }

                return hash;
            }
        }

        #endregion


        #region Filtering methods and structures

        /// <summary>
        /// List of filters that every ICARTT file must pass through in order to be included in the merge.
        /// </summary>
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
        public static void Filter()
        {
            foreach (ICARTT_File icarttFile in allIcarttFiles)
            {
                bool pass = true;

                if (null != filters && filters.Count > 0)
                {
                    filters.ForEach(filter => pass &= filter.Pass(icarttFile));
                }

                icarttFile.IncludeInMerge = pass;
            }
        }


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


            /// <summary>
            /// Returns a combined hash of the list of filtering values.
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    if (null == values || values.Count == 0) return 0;

                    int hash = 19;

                    foreach (string value in values)
                    {
                        hash = hash * 31 + ((null == value) ? 7 : value.GetHashCode());
                    }

                    return hash;
                }
            }
        }

        #endregion
    }
}
