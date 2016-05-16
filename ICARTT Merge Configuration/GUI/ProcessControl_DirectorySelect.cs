using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICARTT_Merge_Configuration.Utilities;
using System.Reflection;

namespace ICARTT_Merge_Configuration.GUI
{
    public partial class ProcessControl_DirectorySelect : ProcessControl
    {
        private bool existingMerge;
        string lastPulledDirectory = null;

        public ProcessControl_DirectorySelect() : base("Directory Select")
        {
            InitializeComponent();
        }

        public override void Deactivate()
        {
            if (null == lastPulledDirectory || !lastPulledDirectory.Equals(TextField_RootDirectory.Text))
            {
                lastPulledDirectory = String.Copy(TextField_RootDirectory.Text);
                ICARTT_FileManager.GetICARTTFilesFromDir(lastPulledDirectory);
            }
            base.Deactivate();
        }

        private void ModifyExistingMergeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            this.existingMerge = this.CheckBox_ExistingMergeConfig.CheckState == CheckState.Checked;
            this.ExistingMergeControlsEnableState(this.existingMerge);
        }

        /// <summary>
        /// Activates or deacticates the existing merge controls.
        /// </summary>
        private void ExistingMergeControlsEnableState(bool enabled)
        {
            this.TextField_ExistingMergeConfig.Enabled = enabled;
            this.BrowseButton_ExistingMergeConfig.Enabled = enabled;
        }

        private void ExistingMergeBrowseButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement ExistingMergeBrowseButton_Click
            Logger.Log(typeof(ProcessControl_DirectorySelect), MethodBase.GetCurrentMethod(), new NotImplementedException());

            throw new NotImplementedException();
        }

        private void BrowseButton_ICARTTDirectory_Click(object sender, EventArgs e)
        {
            DialogResult result = FolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Logger.Log(Logger.MessageCode.Message, typeof(ProcessControl_DirectorySelect), MethodBase.GetCurrentMethod(), "User selected directory: " + FolderBrowserDialog.SelectedPath);
                
                this.TextField_RootDirectory.Text = FolderBrowserDialog.SelectedPath;
                

            }
        }
    }
}
