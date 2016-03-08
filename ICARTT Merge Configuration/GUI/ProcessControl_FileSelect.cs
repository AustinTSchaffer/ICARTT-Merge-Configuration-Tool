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
using ICARTT_Merge_Configuration.ICARTT_File_Library;

namespace ICARTT_Merge_Configuration.GUI
{
    public partial class ProcessControl_FileSelect : ProcessControl
    {
        public ProcessControl_FileSelect() : base("File Select")
        {
            InitializeComponent();
        }

        /// <summary>
        /// At this point, the files were either filtered or the filtering step was skipped. All header information will be loaded from file.
        /// </summary>
        public override void Activate()
        {
            ICARTT_FileManager.Filter();
            ICARTT_FileManager.LoadAll();
            this.LoadedIcarttFiles.Items.Clear();
            ICARTT_FileManager.IcarttFilesToMerge.ForEach(i => this.LoadedIcarttFiles.Items.Add(i.FileName, true));

            base.Activate();
        }

        private void LoadedIcarttFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PopulateMetadataScreen();
        }


        /// <summary>
        /// Loads the metadata viewing window with the currently selected ICARTT file.
        /// </summary>
        private void PopulateMetadataScreen()
        {
            ICARTT_File ictFile = ICARTT_FileManager.IcarttFilesToMerge.ElementAt(this.LoadedIcarttFiles.SelectedIndex);

            this.TextBox_FileName.Text = ictFile.FileName;
            this.TextBox_FilePath.Text = ictFile.FilePath;
            this.TextBox_FileSize.Text = String.Format("{0:n0} Bytes", ictFile.FileSize);

            this.TextBox_DataID.Text = ictFile.GetProperty(ICARTT_File.FileNameProperty.DataID);
            this.TextBox_LocationID.Text = ictFile.GetProperty(ICARTT_File.FileNameProperty.LocationID);
            this.TextBox_Date.Text = ictFile.GetProperty(ICARTT_File.FileNameProperty.Date);

            string revision = ictFile.GetProperty(ICARTT_File.FileNameProperty.Revision);
            foreach (string comment in ictFile.NormalComments) if (!String.IsNullOrEmpty(comment) && (comment.Length >= revision.Length) && comment.Substring(0, revision.Length).Equals(revision)) this.TextBox_Revision.Text = comment;

            this.TextBox_PI.Text = ictFile.PI;
            this.TextBox_Organization.Text = ictFile.Organization;
            this.TextBox_DataSource.Text = ictFile.DataSourceDescription;
            this.TextBox_Mission.Text = ictFile.MissionName;
            this.TextBox_Variables.Text = (ictFile.NumDependentVariables + 1).ToString();
        }
    }
}
