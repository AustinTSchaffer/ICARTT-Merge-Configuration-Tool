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

namespace ICARTT_Merge_Configuration.GUI
{
    public partial class ProcessControl_VariableMapper : ProcessControl
    {
        public ProcessControl_VariableMapper() : base("Map Variables")
        {
            InitializeComponent();
        }


        public override void Activate()
        {
            TextBox_Input_DataID.Text        = "";
            TextBox_Input_VariableName.Text  = "";
            TextBox_Input_VariableUnits.Text = "";
            TextBox_VariableOtherStuff.Text  = "";

            this.PopulateVariableManager_Inputs();
            this.PopulateUniqueInputVariableTree();

            
            base.Activate();
        }


        /// <summary>
        /// Populates the variable manager's unique input variable list with all of 
        /// the variables from all of the ICARTT files in the merge list.
        /// </summary>
        private void PopulateVariableManager_Inputs()
        {
            foreach (ICARTT_File ictFile in ICARTT_FileManager.IcarttFilesToMerge)
                foreach (ICARTT_Variable var in ictFile.Variables)
                    ICARTT_VariableManager.AddInputVariable(var);
        }


        /// <summary>
        /// Populates the unique input variable tree with the variables stored in the variable manager.
        /// All variables are nested under their containing Data ID.
        /// </summary>
        private void PopulateUniqueInputVariableTree()
        {
            this.TreeView_UniqueInputVariables.Nodes.Clear();

            TreeNode mostRecentDataIDNode = null;

            foreach (ICARTT_Variable v in ICARTT_VariableManager.InputVariables)
            {
                if (null == v || v.Type != ICARTT_Variable.VariableType.INPUT) continue;


                if (null == mostRecentDataIDNode || !v.DataID.Equals(mostRecentDataIDNode.Name))
                {
                    TreeNode[] treeNodes_DataID = this.TreeView_UniqueInputVariables.Nodes.Find(v.DataID, false);

                    if (treeNodes_DataID.Length <= 0)
                    {
                        mostRecentDataIDNode = this.TreeView_UniqueInputVariables.Nodes.Add(
                            v.DataID.ToUpper(),     // Key
                            v.DataID.ToUpper()      // Display Text
                            );
                    }
                    else if (treeNodes_DataID.Length >= 1)
                    {
                        if (treeNodes_DataID.Length > 1)
                        {
                            Logger.Log(
                                Logger.MessageCode.Warning,
                            typeof(ProcessControl_VariableMapper),
                            MethodBase.GetCurrentMethod(),
                            "Data ID appears an incorrect number of times in Tree",
                            "Data ID: " + v.DataID,
                            "Expected: " + 1,
                            "Actual: " + treeNodes_DataID.Length
                            );
                        }

                        mostRecentDataIDNode = treeNodes_DataID[0];
                    }
                }

                mostRecentDataIDNode.Nodes.Add(
                        this.FormatVariable(v), // Key
                        v.Name);                // Display Text
            }
        }


        /// <summary>
        /// Used to format the name of a variable to be used as a TreeNode key.
        /// </summary>
        /// <param name="var">Variable to format</param>
        /// <returns>var.Name, var.Unit</returns>
        private string FormatVariable(ICARTT_Variable var)
        {
            return String.Format("{0}, {1}", var.Name, var.Unit);
        }


        private void TreeView_UniqueInputVariables_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = TreeView_UniqueInputVariables.SelectedNode;

            if (selectedNode.Parent == null) return;

            ICARTT_Variable selectedVariable = null;

            foreach (ICARTT_Variable v in ICARTT_VariableManager.InputVariables)
            {
                if (selectedNode.Name.Equals(this.FormatVariable(v)) 
                    && selectedNode.Parent.Name.Equals(v.DataID.ToUpper()))
                {
                    selectedVariable = v;

                    TextBox_Input_DataID.Text = selectedVariable.DataID;
                    TextBox_Input_VariableName.Text = selectedVariable.Name;
                    TextBox_Input_VariableUnits.Text = selectedVariable.Unit;
                    TextBox_VariableOtherStuff.Text = selectedVariable.Desc;
                    return;
                }
            }
        }
    }
}
