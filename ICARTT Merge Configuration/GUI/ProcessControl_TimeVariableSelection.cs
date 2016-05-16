using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICARTT_Merge_Configuration.GUI.ProcessControl_TimeVariableSelectionControls;
using ICARTT_Merge_Configuration.ICARTT_File_Library;
using ICARTT_Merge_Configuration.Utilities;

namespace ICARTT_Merge_Configuration.GUI
{
    public partial class ProcessControl_TimeVariableSelection : ProcessControl
    {

        public ProcessControl_TimeVariableSelection() : base("Time Variables")
        {
            InitializeComponent();
            this.timeVariableSelectionControls 
                = new List<ProcessControl_TimeVariableSelectionControl>();
        }


        public override void Activate()
        {

            // TODO: Table does not autosize when dataIDs are removed.

            this.timeVariableSelectionControls.Clear();
            this.tableLayoutPanel1.Controls.Clear();

            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.Height = 1;
            this.PopulateTVSCs();
            base.Activate();
        }

        public override void Deactivate()
        {
            this.timeVariableSelectionControls.ForEach(tvsc => tvsc.UpdateMemory());
            base.Deactivate();
        }


        private List<ProcessControl_TimeVariableSelectionControl> timeVariableSelectionControls;


        /// <summary>
        /// Populates the list of TimeVariableSelectionControls from the list of loaded ICARTT files.
        /// </summary>
        public void PopulateTVSCs()
        {
            List<ICARTT_File> ictFiles = ICARTT_FileManager.IcarttFilesToMerge;

            while (ictFiles.Count > 0)
            {
                ProcessControl_TimeVariableSelectionControl tvsc = new ProcessControl_TimeVariableSelectionControl();
                tvsc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                tvsc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                tvsc.TabIndex = 1;

                ictFiles = tvsc.Populate(ictFiles);

                this.timeVariableSelectionControls.Add(tvsc);
                this.tableLayoutPanel1.Controls.Add(
                    tvsc,
                    0, // Column Index
                    tableLayoutPanel1.Controls.Count // Row Index
                    );
            }
        }
    }
}
