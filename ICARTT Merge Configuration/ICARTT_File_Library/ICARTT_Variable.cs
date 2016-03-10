using ICARTT_Merge_Configuration.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ICARTT_Merge_Configuration.ICARTT_File_Library
{
    class ICARTT_Variable
    {
        /// <summary>
        /// Column number where variable appears in the file. 0 refers to the independent variable. 1 refers to the first dependent variable.
        /// </summary>
        public int columnNumber;

        /// <summary>
        /// Short variable name.
        /// </summary>
        public string name;

        /// <summary>
        /// Units of variable.
        /// </summary>
        public string unit;

        /// <summary>
        /// Third optional field when naming an ICARTT variable
        /// </summary>
        public string desc;

        /// <summary>
        /// Scaling factor of ICARTT variable.
        /// </summary>
        public double scaleFactor;

        /// <summary>
        /// Missing data indicator.
        /// </summary>
        public double missingDataIndicator;


        /// <summary>
        /// Holds all properties that have not already been specified.
        /// </summary>
        public Dictionary<string, string> properties;


        /// <summary>
        /// Character that separates fields in the name of an ICARTT variable.
        /// </summary>
        private const char VARIABLE_FIELD_SEPARATOR = ',';
        
        private const double
            DEFAULT_SF  =       1.0,
            DEFAULT_MDI = -999999.0;

        private const string
            DEFAULT_NAME = "NONE",
            DEFAULT_UNIT = "NONE",
            DEFAULT_DESC = "";


        /// <summary>
        /// Constructor for loading an ICARTT variable to file.
        /// </summary>
        /// <param name="fullNameFromFile">Name of variable from line in file</param>
        /// <param name="cN">Column number</param>
        /// <param name="sF">Scale Factor</param>
        /// <param name="mDI">Missing data indicator.</param>
        public ICARTT_Variable(string fullNameFromFile, int cN, double sF, double mDI)
        {
            columnNumber = cN;
            scaleFactor = sF;
            missingDataIndicator = mDI;

            properties = new Dictionary<string, string>();

            if (String.IsNullOrWhiteSpace(fullNameFromFile))
            {
                Logger.Log(Logger.MessageCode.Warning, typeof(ICARTT_Variable), MethodBase.GetCurrentMethod(), "Empty variable name. Initializing default.");

                name = DEFAULT_NAME;
                unit = DEFAULT_UNIT;
                desc = DEFAULT_DESC;
            }
            else
            {
                string[] splitName = fullNameFromFile.Split(VARIABLE_FIELD_SEPARATOR);
                name = (splitName.Length > 0) ? splitName[0].Trim() : DEFAULT_NAME;
                unit = (splitName.Length > 1) ? splitName[1].Trim() : DEFAULT_UNIT;
                desc = (splitName.Length > 2) ? splitName[2].Trim() : DEFAULT_DESC;
            }

            name = (name.Length < 1) ? DEFAULT_NAME : name;
            unit = (unit.Length < 1) ? DEFAULT_UNIT : unit;
            desc = (desc.Length < 1) ? DEFAULT_DESC : desc;
        }


        /// <summary>
        /// Constructor for creating renamed variable mappings.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="unit"></param>
        /// <param name="desc"></param>
        /// <param name="cN">Column number</param>
        /// <param name="sF">Scale Factor</param>
        /// <param name="mDI">Missing data indicator.</param>
        public ICARTT_Variable(string name, string unit, string desc, int cN, double sF = DEFAULT_SF, double mDI = DEFAULT_MDI) : this(String.Format("{1}{0}{2}{0}{3}", VARIABLE_FIELD_SEPARATOR, name, unit, desc), cN, sF, mDI) { }


        /// <summary>
        /// Returns true if the two objects have the same name, units, and description.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (null == obj || GetType() != obj.GetType()) return false;

            ICARTT_Variable iV = ((ICARTT_Variable)obj);

            return name.Equals(iV.name) && unit.Equals(iV.unit) && desc.Equals(iV.desc) && iV.scaleFactor == scaleFactor && iV.missingDataIndicator == missingDataIndicator;
        }
        

        /// <summary>
        /// Returns the hash of the concatenated name, units, description, scale factor, and MDI.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() { return (name + unit + desc + scaleFactor.ToString() + missingDataIndicator.ToString()).GetHashCode(); }
    }
}
