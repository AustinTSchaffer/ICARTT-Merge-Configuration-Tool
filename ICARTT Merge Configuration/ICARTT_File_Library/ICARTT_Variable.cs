using ICARTT_Merge_Configuration.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ICARTT_Merge_Configuration.ICARTT_File_Library
{
    public class ICARTT_Variable
    {

        /// <summary>
        /// Column number where variable appears in the file. 0 refers to the independent variable. 1 refers to the first dependent variable.
        /// </summary>
        public int columnNumber;

        /// <summary>
        /// Short variable name.
        /// </summary>
        public string Name;

        /// <summary>
        /// Units of variable.
        /// </summary>
        public string Unit;

        /// <summary>
        /// Third optional field when naming an ICARTT variable
        /// </summary>
        public string Desc;

        /// <summary>
        /// Data ID that contains this variable.
        /// </summary>
        public string DataID;

        /// <summary>
        /// Scaling factor of ICARTT variable.
        /// </summary>
        public double ScaleFactor;

        /// <summary>
        /// Missing data indicator.
        /// </summary>
        public double MissingDataIndicator;


        /// <summary>
        /// Possible variable merge types. Input denotes variables from a file, which are not merged directly.
        /// </summary>
        public enum VariableType
        {
            INPUT,
            TIME,
            SCALAR,
            Vector_Magnitude,
            Vector_Direction
        }

        /// <summary>
        /// Variable's merge type.
        /// </summary>
        public VariableType Type;


        /// <summary>
        /// Holds all properties that have not already been specified. Used for output variables.
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
        /// <param name="dataID">Data ID that contains this ICARTT variable.</param>
        /// <param name="fullNameFromFile">Name of variable from line in file</param>
        /// <param name="cN">Column number</param>
        /// <param name="sF">Scale Factor</param>
        /// <param name="mDI">Missing data indicator.</param>
        public ICARTT_Variable(string dataID, string fullNameFromFile, int cN, VariableType type = VariableType.INPUT, double sF = DEFAULT_SF, double mDI = DEFAULT_MDI)
        {
            this.columnNumber = cN;
            this.ScaleFactor = sF;
            this.MissingDataIndicator = mDI;

            properties = new Dictionary<string, string>();

            if (String.IsNullOrWhiteSpace(fullNameFromFile))
            {
                Logger.Log(Logger.MessageCode.Warning, typeof(ICARTT_Variable), MethodBase.GetCurrentMethod(), "Empty variable name. Initializing default.");

                Name = DEFAULT_NAME;
                Unit = DEFAULT_UNIT;
                Desc = DEFAULT_DESC;
            }
            else
            {
                string[] splitName = fullNameFromFile.Split(VARIABLE_FIELD_SEPARATOR);
                Name = (splitName.Length > 0) ? splitName[0].Trim() : DEFAULT_NAME;
                Unit = (splitName.Length > 1) ? splitName[1].Trim() : DEFAULT_UNIT;
                Desc = (splitName.Length > 2) ? splitName[2].Trim() : DEFAULT_DESC;
            }

            this.Name = (Name.Length < 1) ? DEFAULT_NAME : Name;
            this.Unit = (Unit.Length < 1) ? DEFAULT_UNIT : Unit;
            this.Desc = (Desc.Length < 1) ? DEFAULT_DESC : Desc;

            this.Type = type;
            this.DataID = (null != dataID) ? dataID : "NO DATA ID";
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
        public ICARTT_Variable(string dataID, string name, string unit, string desc, int cN, VariableType type = VariableType.INPUT, double sF = DEFAULT_SF, double mDI = DEFAULT_MDI) : this(dataID, String.Format("{1}{0}{2}{0}{3}", VARIABLE_FIELD_SEPARATOR, name, unit, desc), cN, type, sF, mDI) { }


        /// <summary>
        /// Returns true if the two objects have the same name, units, and description.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (null == obj || GetType() != obj.GetType()) return false;

            ICARTT_Variable iV = ((ICARTT_Variable) obj);

            return DataID.Equals(iV.DataID) && Name.Equals(iV.Name) && Unit.Equals(iV.Unit) && iV.ScaleFactor == ScaleFactor && iV.MissingDataIndicator == MissingDataIndicator;
        }
        

        /// <summary>
        /// Returns the hash of the concatenated name, units, description, scale factor, and MDI.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() { return (Name + Unit + Desc + ScaleFactor.ToString() + MissingDataIndicator.ToString()).GetHashCode(); }
    }
}
