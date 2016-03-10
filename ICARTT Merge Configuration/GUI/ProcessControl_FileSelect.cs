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
using System.Reflection;

namespace ICARTT_Merge_Configuration.GUI
{
    public partial class ProcessControl_FileSelect : ProcessControl
    {
        public ProcessControl_FileSelect() : base("File Select")
        {
            InitializeComponent();
        }


        /// <summary>
        /// Value to determine if the ICARTT_FileManager loaded new files. If the ICARTT_FileManager changes the files in its scope, then the return of ICARTT_FileManager.Hash() should change.
        /// </summary>
        private int previousFileManagerHash = int.MinValue;


        /// <summary>
        /// Flag that will prevent certain actions from firing based on Activate() and Deactivate()
        /// </summary>
        private bool controlActive = false;


        /// <summary>
        /// At this point, the files were either filtered or the filtering step was skipped. All header information will be loaded from file.
        /// </summary>
        public override void Activate()
        {
            if (ICARTT_FileManager.FilterHash() != this.previousFileManagerHash)
            {
                ICARTT_FileManager.Filter();
                ICARTT_FileManager.LoadAll();
                this.previousFileManagerHash = ICARTT_FileManager.FilterHash();
            }
            
            this.CheckedListBox_AllIcarttFiles.Items.Clear();
            ICARTT_FileManager.IcarttFilesInScope.ForEach(i => this.CheckedListBox_AllIcarttFiles.Items.Add(i.FileName, i.IncludeInMerge));

            base.Activate();

            this.controlActive = true;
        }


        /// <summary>
        /// Forces the list of ICARTT files to merge to match the checkedlistbox
        /// </summary>
        public override void Deactivate()
        {
            this.controlActive = false;

            // Toggles the IncludeInMerge flag of every known ICARTT file
            // so that the list of ICARTT files matches the checkedlistbox.
            foreach (ICARTT_File ictFile in ICARTT_FileManager.IcarttFilesInScope)
            {
                ictFile.IncludeInMerge = false;

                foreach (object item in this.CheckedListBox_AllIcarttFiles.CheckedItems)
                {
                    if (item.ToString().Equals(ictFile.FileName))
                    {
                        this.CheckedListBox_AllIcarttFiles.Items.Remove(item);
                        ictFile.IncludeInMerge = true;
                        break;
                    }
                }
            } 

            base.Deactivate();
        }


        /// <summary>
        /// Loads the metadata viewing window with the specified ICARTT file.
        /// </summary>
        /// <param name="ictFile">Specified ICARTT file.</param>
        private void PopulateMetadataScreen(ICARTT_File ictFile)
        {
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


        private void LoadedIcarttFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!controlActive) return;

            ICARTT_File ictFile = ICARTT_FileManager.IcarttFilesInScope.Find(i => i.FileName.Equals(this.CheckedListBox_AllIcarttFiles.SelectedItem.ToString()));
            ictFile.Load();
            this.PopulateMetadataScreen(ictFile);
        }
    }
}