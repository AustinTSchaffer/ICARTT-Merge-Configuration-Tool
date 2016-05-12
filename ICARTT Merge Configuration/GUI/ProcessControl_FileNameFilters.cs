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
    public partial class ProcessControl_FileNameFilters : ProcessControl
    {

        /// <summary>
        /// Value to determine if the ICARTT_FileManager loaded new files. If the ICARTT_FileManager changes the files in its scope, then the return of ICARTT_FileManager.Hash() should change.
        /// </summary>
        private int previousFileListHash = int.MinValue;


        /// <summary>
        /// Value to determine if the ICARTT_FileManager changed its filters. There is no need to reload the list of files unless the filters have changed.
        /// </summary>
        private int previousFilterHash = int.MinValue;


        public ProcessControl_FileNameFilters() : base("File Name Filters")
        {
            InitializeComponent();
        }


        public override void Activate()
        {
            int hash = ICARTT_FileManager.AllFilesHash();
            if (hash == previousFileListHash) return;
            previousFileListHash = hash;

            List<ICARTT_File> listOfFilesInScope = ICARTT_FileManager.IcarttFilesInScope;

            this.ComboBox_LocationIDs.Items.Clear();
            ICARTT_FileManager.GetUnique(ICARTT_File.FileNameProperty.LocationID, listOfFilesInScope).ForEach(locID => this.ComboBox_LocationIDs.Items.Add(locID));

            if (this.ComboBox_LocationIDs.Items.Count <= 0) this.ComboBox_LocationIDs.Items.Add("");
            this.ComboBox_LocationIDs.SelectedIndex = 0;

            this.CheckedListBox_DataIDs.Items.Clear();
            this.CheckedListBox_DataIDs.Sorted = true;
            ICARTT_FileManager.GetUnique(ICARTT_File.FileNameProperty.DataID, listOfFilesInScope).ForEach(dataID => this.CheckedListBox_DataIDs.Items.Add(dataID, true));

            this.CheckedListBox_Dates.Sorted = true;
            this.CheckedListBox_Dates.Items.Clear();
            ICARTT_FileManager.GetUnique(ICARTT_File.FileNameProperty.Date, listOfFilesInScope).ForEach(date => this.CheckedListBox_Dates.Items.Add(date, true));

            base.Activate();
        }


        public override void Deactivate()
        {
            List<string> selectedLocationID = new List<string>();
            selectedLocationID.Add(this.ComboBox_LocationIDs.SelectedItem.ToString());

            List<string> selectedDataIDs = new List<string>();
            foreach (object dataID in this.CheckedListBox_DataIDs.CheckedItems) selectedDataIDs.Add(dataID.ToString());

            List<string> selectedDates = new List<string>();
            foreach (object date in this.CheckedListBox_Dates.CheckedItems) selectedDates.Add(date.ToString());


            ICARTT_FileManager.ClearFilter();
            ICARTT_FileManager.AddFilter(ICARTT_File.FileNameProperty.LocationID, selectedLocationID);
            ICARTT_FileManager.AddFilter(ICARTT_File.FileNameProperty.DataID, selectedDataIDs);
            ICARTT_FileManager.AddFilter(ICARTT_File.FileNameProperty.Date, selectedDates);


            int hash = ICARTT_FileManager.FilterHash();

            if (hash != this.previousFilterHash)
            {
                ICARTT_FileManager.Filter();
                ICARTT_FileManager.LoadAll();
                this.previousFilterHash = hash;
            }

            base.Deactivate();
        }

        private void ComboBox_LocationIDs_SelectionChanged(object sender, EventArgs e)
        {
            this.CheckedListBox_DataIDs.Enabled = true;
            this.CheckedListBox_Dates.Enabled   = true;


        }

        private void UpdateDataIdChecklist()
        {
            ICARTT_FileManager.Filter();

            //this.CheckedListBox_DataIDs.Items.AddRange();
        }

        private void Button_X_CheckAll_Click(object sender, EventArgs e)
        {
            bool check;
            CheckedListBox clb = null;

            if (sender == this.Button_DataID_CheckAll)
            {
                check = true;
                clb = this.CheckedListBox_DataIDs;
            }
            else if (sender == this.Button_DataID_UncheckAll)
            {
                check = false;
                clb = this.CheckedListBox_DataIDs;
            }
            else if (sender == this.Button_Date_CheckAll)
            {
                check = true;
                clb = this.CheckedListBox_Dates;
            }
            else if (sender == this.Button_Date_UncheckAll)
            {
                check = false;
                clb = this.CheckedListBox_Dates;
            }
            else return;

            // Null catch
            if (null == clb || null == clb.Items) return;

            // Check or Uncheck all.
            for (int i = 0; i < clb.Items.Count; ++i) clb.SetItemChecked(i, check);
        }
    }
}
