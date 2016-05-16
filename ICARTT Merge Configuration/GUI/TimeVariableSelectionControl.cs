using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICARTT_Merge_Configuration.ICARTT_File_Library;
using ICARTT_Merge_Configuration.Utilities;
using System.Reflection;

namespace ICARTT_Merge_Configuration.GUI.ProcessControl_TimeVariableSelectionControls
{
    public partial class ProcessControl_TimeVariableSelectionControl : UserControl
    {


        public ProcessControl_TimeVariableSelectionControl()
        {
            this.containedICARTTFiles = new List<ICARTT_File>();
            InitializeComponent();
        }


        private const string DEFAULT_COMBOBOX_VALUE = "None";


        /// <summary>
        /// Features that can be used to determine if a variable is a start, stop, or mid time variable.
        /// </summary>
        private static readonly string[][] TIME_VARIABLE_FEATURES =
        {
            new string[] {"START"},                         // TimeVariableType.Start
            new string[] {"STOP", "END"},                   // TimeVariableType.Stop
            new string[] {"MID"},                           // TimeVariableType.Mid
            new string[] {"TIME", "UTC", "SECS", "SECONDS"} // TimeVariableType.Generic
        };


        /// <summary>
        /// Used to reference rows from TIME_VARIABLE_FEATURES
        /// </summary>
        private enum TimeVariableType
        {
            Any = -1,
            Start = 0,
            Stop = 1,
            Mid = 2,
            Generic = 3,
        }


        /// <summary>
        /// Handles to a homogeneous set of ICARTT files.
        /// </summary>
        private List<ICARTT_File> containedICARTTFiles;


        /// <summary>
        /// Holds the data ID of the contained ICARTT files.
        /// </summary>
        private string containedDataID = "";

        public string NAME_AND_UNITS_SPACER = "    ";


        /// <summary>
        /// Populates this control with a set of ICARTT files that have the same Data ID and variables. Will take a list of ICARTT files and grab only homogeneous entries. The method will return a list containing all rejects.
        /// </summary>
        /// <param name="ictFiles">A list of ICARTT files that has not already been added to a control.</param>
        /// <returns>A list containing the ICARTT Files that were not included in this control.</returns>
        public List<ICARTT_File> Populate(List<ICARTT_File> ictFiles)
        {
            this.containedICARTTFiles.Clear();


            List<ICARTT_File> rejects = new List<ICARTT_File>();
            if (ictFiles.Count <= 0) return rejects;


            ICARTT_File exampleFile = ictFiles[0]; // All kept files must match
            this.containedICARTTFiles.Add(exampleFile);
            this.containedDataID = exampleFile.GetProperty(ICARTT_File.FileNameProperty.DataID);

            // All files from the list will be channeled into either the list of rejects or the list of containedICARTTFiles.
            for (int i = 1; i < ictFiles.Count; ++i)
            {
                bool match =
                    // DataID Match
                    ictFiles[i].GetProperty(ICARTT_File.FileNameProperty.DataID)
                    .ToUpper()
                    .Equals(exampleFile.GetProperty(ICARTT_File.FileNameProperty.DataID)
                    .ToUpper())
                    &&
                    // Ind.Var. Match
                    ictFiles[i].IndependentVariable
                    .Equals(exampleFile.IndependentVariable)
                    &&
                    // Dep.Vars. Match
                    ictFiles[i].VariableListMatch(exampleFile);

                if (match) this.containedICARTTFiles.Add(ictFiles[i]);
                else rejects.Add(ictFiles[i]);
            }

            this.UpdateFields(exampleFile);
            this.PopulateComboboxes(exampleFile);
            this.PreselectComboboxes(exampleFile);
            return rejects;
        }


        /// <summary>
        /// Fills the onscreen controls with the information from the list of contained ICARTT files.
        /// </summary>
        /// <param name="exampleFile">Example file whose variable list matches all of the variable lists of all the other variable lists maintained by this control.</param>
        public void UpdateFields(ICARTT_File exampleFile)
        {
            if (null == this.containedICARTTFiles || this.containedICARTTFiles.Count <= 0) return;
            if (null == exampleFile) return;

            this.TextBox_DataID.Text = exampleFile.GetProperty(ICARTT_File.FileNameProperty.DataID);

            foreach (ICARTT_File ictFile in this.containedICARTTFiles)
            {
                string s = String.Format("{0}   {1}   {2}   {3}",
                    ictFile.GetProperty(ICARTT_File.FileNameProperty.Date),
                    ictFile.GetProperty(ICARTT_File.FileNameProperty.Revision),
                    ictFile.GetProperty(ICARTT_File.FileNameProperty.Launch),
                    ictFile.GetProperty(ICARTT_File.FileNameProperty.Comments));
                this.ListBox_Files.Items.Add(s);
            }

            this.TextBox_DataInterval.Text = exampleFile.DataInterval.ToString();
        }


        /// <summary>
        /// Populates the comboboxes using the list of variables from an example file.
        /// </summary>
        /// <param name="exampleFile">Example file whose variable list matches all of the variable lists of all the other variable lists maintained by this control.</param>
        private void PopulateComboboxes(ICARTT_File exampleFile)
        {
            if (null == this.containedICARTTFiles || this.containedICARTTFiles.Count <= 0) return;
            if (null == exampleFile) return;

            this.ComboBox_StartTime.Items.Add(DEFAULT_COMBOBOX_VALUE);
            exampleFile.Variables.ForEach(v => this.ComboBox_StartTime.Items.Add(VariableStringFormat(v)));

            this.ComboBox_StopTime.Items.Add(DEFAULT_COMBOBOX_VALUE);
            exampleFile.Variables.ForEach(v => this.ComboBox_StopTime.Items.Add(VariableStringFormat(v)));

            this.ComboBox_MidpointTime.Items.Add(DEFAULT_COMBOBOX_VALUE);
            exampleFile.Variables.ForEach(v => this.ComboBox_MidpointTime.Items.Add(VariableStringFormat(v)));
        }


        /// <summary>
        /// Preselects the time variable comboboxes with None, a previously selected entry, or an entry based on the incoming variable names from file.
        /// </summary>
        /// <param name="exampleFile">Example file whose variable list matches all of the variable lists of all the other variable lists maintained by this control.</param>
        private void PreselectComboboxes(ICARTT_File exampleFile)
        {
            if (null == this.containedICARTTFiles || this.containedICARTTFiles.Count <= 0) return;
            if (null == exampleFile) return;

            //
            // Select previous selection
            //

            this.ComboBox_StartTime.SelectedIndex =
                (null == exampleFile.TimeVariable_Start) ? 0 :
                this.ComboBox_StartTime.FindStringExact(VariableStringFormat(exampleFile.TimeVariable_Start));

            this.ComboBox_StopTime.SelectedIndex =
                (null == exampleFile.TimeVariable_Stop) ? 0 :
                this.ComboBox_StopTime.FindStringExact(VariableStringFormat(exampleFile.TimeVariable_Stop));

            this.ComboBox_MidpointTime.SelectedIndex =
                (null == exampleFile.TimeVariable_Midpoint) ? 0 :
                this.ComboBox_MidpointTime.FindStringExact(VariableStringFormat(exampleFile.TimeVariable_Midpoint));

            //
            // Machine Guess
            //

            List<string> potentialTimeVariables = new List<string>();
            for (int i = 1; i <= 3 && i < ComboBox_StartTime.Items.Count; ++i)
                if (StringHasTimeVarFeatures(ComboBox_StartTime.Items[i].ToString()))
                    potentialTimeVariables.Add(ComboBox_StartTime.Items[i].ToString());


            if (potentialTimeVariables.Count <= 0)
            {
                // Warning to show that the user might continue without selecting a time variable.

                Logger.Log(Logger.MessageCode.Warning, typeof(ProcessControl_TimeVariableSelectionControl), MethodBase.GetCurrentMethod(), "No potential time variables were identified.", "Data ID: " + containedDataID, "Number of files: " + this.containedICARTTFiles.Count);
            }
            else
            {
                foreach (string potentialTimeVariable in potentialTimeVariables)
                {
                    string ptv_nameonly = potentialTimeVariable
                        .Split(NAME_AND_UNITS_SPACER.ToCharArray())[0];


                    if (StringHasTimeVarFeatures(ptv_nameonly, TimeVariableType.Start) && 
                        ComboBox_StartTime.SelectedItem.Equals(DEFAULT_COMBOBOX_VALUE) && 
                        !ComboBox_StopTime.SelectedItem.Equals(potentialTimeVariable) && 
                        !ComboBox_MidpointTime.SelectedItem.Equals(potentialTimeVariable))
                    {
                        this.ComboBox_StartTime.SelectedIndex =
                            this.ComboBox_StartTime.FindStringExact(potentialTimeVariable);

                        continue;
                    }

                    if (StringHasTimeVarFeatures(ptv_nameonly, TimeVariableType.Stop) &&
                        ComboBox_StopTime.SelectedItem.Equals(DEFAULT_COMBOBOX_VALUE) &&
                        !ComboBox_StartTime.SelectedItem.Equals(potentialTimeVariable) &&
                        !ComboBox_MidpointTime.SelectedItem.Equals(potentialTimeVariable))
                    {
                        this.ComboBox_StopTime.SelectedIndex =
                            this.ComboBox_StopTime.FindStringExact(potentialTimeVariable);

                        continue;
                    }

                    if ((potentialTimeVariables.Count == 1 || StringHasTimeVarFeatures(ptv_nameonly, TimeVariableType.Mid)) &&
                        ComboBox_MidpointTime.SelectedItem.Equals(DEFAULT_COMBOBOX_VALUE) &&
                        !ComboBox_StartTime.SelectedItem.Equals(potentialTimeVariable) &&
                        !ComboBox_StopTime.SelectedItem.Equals(potentialTimeVariable))
                    {
                        this.ComboBox_MidpointTime.SelectedIndex =
                            this.ComboBox_MidpointTime.FindStringExact(potentialTimeVariable);

                        continue;
                    }
                }
            }
        }


        /// <summary>
        /// Returns true if a string matches any of the TIME_VARIABLE_FEATURES.
        /// </summary>
        /// <param name="s">String to check for features.</param>
        /// <param name="type">Time variable type to check for. Defaults to Any, which will check all possible types.</param>
        /// <returns>True if the string matches any predefined feature.</returns>
        private bool StringHasTimeVarFeatures(string s, TimeVariableType type = TimeVariableType.Any)
        {
            if (type != TimeVariableType.Any)
            {
                foreach (string feature in TIME_VARIABLE_FEATURES[(int)type])
                    if (s.ToUpper().Contains(feature))
                        return true;
            }
            else
            {
                foreach (string[] featureSubset in TIME_VARIABLE_FEATURES)
                    foreach (string feature in featureSubset)
                        if (s.ToUpper().Contains(feature))
                            return true;
            }

            return false;
        }

        /// <summary>
        /// Matches the referenced ICARTT variables so they match the values selected by this control. Called for each control when ProcessControl_TimeVariableSelection is deactivated.
        /// </summary>
        public void UpdateMemory()
        {
            string selectedStart = this.ComboBox_StartTime.SelectedItem.ToString();
            string selectedStop = this.ComboBox_StopTime.SelectedItem.ToString();
            string selectedMid = this.ComboBox_MidpointTime.SelectedItem.ToString();

            bool startIsFilled = false;
            bool stopIsFilled = false;
            bool midIsFilled = false;

            foreach (ICARTT_File ictFile in this.containedICARTTFiles)
            {
                if (null == selectedStart || selectedStart.Equals(DEFAULT_COMBOBOX_VALUE))
                {
                    ictFile.TimeVariable_Start = null;
                    startIsFilled = true;
                }

                if (null == selectedStop || selectedStop.Equals(DEFAULT_COMBOBOX_VALUE))
                {
                    ictFile.TimeVariable_Stop = null;
                    stopIsFilled = true;
                }

                if (null == selectedMid || selectedMid.Equals(DEFAULT_COMBOBOX_VALUE))
                {
                    ictFile.TimeVariable_Midpoint = null;
                    midIsFilled = true;
                }


                foreach (ICARTT_Variable ictVar in ictFile.Variables)
                {
                    if (!startIsFilled && selectedStart.Equals(VariableStringFormat(ictVar)))
                    {
                        ictFile.TimeVariable_Start = ictVar;
                        ictVar.Type = ICARTT_Variable.VariableType.TIME;
                        startIsFilled = true;
                    }

                    if (!stopIsFilled && selectedStop.Equals(VariableStringFormat(ictVar)))
                    {
                        ictFile.TimeVariable_Stop = ictVar;
                        ictVar.Type = ICARTT_Variable.VariableType.TIME;
                        stopIsFilled = true;
                    }

                    if (!midIsFilled && selectedMid.Equals(VariableStringFormat(ictVar)))
                    {
                        ictFile.TimeVariable_Midpoint = ictVar;
                        ictVar.Type = ICARTT_Variable.VariableType.TIME;
                        midIsFilled = true;
                    }
                }
            }
        }


        /// <summary>
        /// Formats an ICARTT variable for display in the comboboxes.
        /// </summary>
        /// <param name="ictVar">Variable to format.</param>
        /// <returns></returns>
        private string VariableStringFormat(ICARTT_Variable ictVar)
        {
            return String.Join(NAME_AND_UNITS_SPACER, ictVar.Name, ictVar.Unit);
        }
    }
}
