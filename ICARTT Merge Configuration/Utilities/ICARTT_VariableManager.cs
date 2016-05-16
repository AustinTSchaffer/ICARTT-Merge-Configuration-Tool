using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICARTT_Merge_Configuration.ICARTT_File_Library;

namespace ICARTT_Merge_Configuration.Utilities
{
    /// <summary>
    /// This class serves to handle all mapping of variables.
    /// </summary>
    public static class ICARTT_VariableManager
    {

        /// <summary>
        /// TODO
        /// </summary>
        public static List<ICARTT_Variable> InputVariables
        {
            get
            {
                return (null == inputVariables) ?
                    new List<ICARTT_Variable>() : 
                    new List<ICARTT_Variable>(inputVariables);
            }
        }


        /// <summary>
        /// TODO
        /// </summary>
        public static List<ICARTT_Variable> OutputVariables
        {
            get
            {
                return (null == outputVariables) ?
                    new List<ICARTT_Variable>() :
                    new List<ICARTT_Variable>(outputVariables);
            }
        }


        /// <summary>
        /// Contains the list of all unique variables from the list of files to merge.
        /// </summary>
        private static List<ICARTT_Variable> inputVariables;


        /// <summary>
        /// Contains the list of all variables that will be merged.
        /// </summary>
        private static List<ICARTT_Variable> outputVariables;


        /// <summary>
        /// Contains mappings from input variables to output variables.
        /// </summary>
        private static Dictionary<ICARTT_Variable, ICARTT_Variable> variableMap;


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public static bool AddInputVariable(ICARTT_Variable variable)
        {
            if (null == inputVariables) inputVariables = new List<ICARTT_Variable>();

            if (inputVariables.Contains(variable)) return false;

            inputVariables.Add(variable);
            return true;
        }


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public static bool AddOutputVariable(ICARTT_Variable variable)
        {
            if (null == outputVariables) outputVariables = new List<ICARTT_Variable>();

            if (outputVariables.Contains(variable)) return false;

            outputVariables.Add(variable);
            return true;
        }

    }
}
