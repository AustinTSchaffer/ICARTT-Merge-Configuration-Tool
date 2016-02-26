using ICARTT_Merge_Configuration.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ICARTT_Merge_Configuration.ICARTT_File_Library.Variables
{
    class ICARTT_Variable
    {
        /// <summary>
        /// Column number where variable appears in the file. 0 refers to the independent variable. 1 refers to the first dependent variable.
        /// </summary>
        private int ColumnNumber;

        /// <summary>
        /// Short variable name.
        /// </summary>
        private string Name;

        /// <summary>
        /// Units of variable.
        /// </summary>
        private string Units;

        /// <summary>
        /// Third optional field when naming an ICARTT variable
        /// </summary>
        private string Description;


        private static readonly char VARIABLE_FIELD_SEPARATOR = ',';

        private static readonly string
            DEFAULT_NAME = "NONE",
            DEFAULT_UNIT = "NONE",
            DEFAULT_DESC = "";


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fullNameFromFile"></param>
        /// <param name="columnNumber"></param>
        public ICARTT_Variable(string fullNameFromFile, int columnNumber)
        {
            ColumnNumber = columnNumber;

            if (String.IsNullOrWhiteSpace(fullNameFromFile))
            {
                Logger.Log(Logger.MessageCode.Warning, typeof(ICARTT_Variable), MethodBase.GetCurrentMethod(), "Empty variable name. Initializing default.");

                Name        = DEFAULT_NAME;
                Units       = DEFAULT_UNIT;
                Description = DEFAULT_DESC;
            }
            else
            {
                string[] splitName = fullNameFromFile.Split(VARIABLE_FIELD_SEPARATOR);
                Name        = (splitName.Length > 0) ? splitName[0].Trim() : DEFAULT_NAME;
                Units       = (splitName.Length > 1) ? splitName[1].Trim() : DEFAULT_UNIT;
                Description = (splitName.Length > 2) ? splitName[2].Trim() : DEFAULT_DESC;
            }

            

            
        }
    }
}
