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

namespace ICARTT_Merge_Configuration.GUI
{
    public partial class ProcessControl_VariableViewer : ProcessControl
    {
        public ProcessControl_VariableViewer() : base("View Variables")
        {
            InitializeComponent();
        }


        public override void Activate()
        {

            this.ListBox_UniqueVariableNames.Items.Clear();

            List<string> uniqueVariableNames = new List<string>();

            foreach (ICARTT_File i in ICARTT_FileManager.IcarttFilesToMerge)
            {
                foreach (ICARTT_Variable v in i.DependentVariables)
                {
                    if (!uniqueVariableNames.Contains(v.name))
                    {
                        uniqueVariableNames.Add(v.name);
                    }
                }
            }



            uniqueVariableNames.ForEach(vn => this.ListBox_UniqueVariableNames.Items.Add(vn));
            base.Activate();
        }
    }
}
