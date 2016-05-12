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

namespace ICARTT_Merge_Configuration.GUI
{
    public partial class ProcessControl_TimeVariableSelection : ProcessControl
    {
        public ProcessControl_TimeVariableSelection() : base("Time Variables")
        {
            InitializeComponent();
            this.timeVarSelControls = new List<TimeVariableSelectionControl>();
            this.AddTVSC();
            this.AddTVSC();
            this.AddTVSC();
        }


        public override void Activate()
        {
            
            base.Activate();
        }


        private List<TimeVariableSelectionControl> timeVarSelControls;


        public void AddTVSC()
        {
            TimeVariableSelectionControl tvsc = new TimeVariableSelectionControl();
            tvsc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            tvsc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            tvsc.TabIndex = 1;
            tvsc.Dock = DockStyle.Top;
            this.timeVarSelControls.Add(tvsc);
            this.flowLayoutPanel1.Controls.Add(tvsc);
            // TODO: Figure out how to add a list of these controls so that they stretch to fill horizontally and tile vertically.

            // TODO add padding around control
        }
    }
}
