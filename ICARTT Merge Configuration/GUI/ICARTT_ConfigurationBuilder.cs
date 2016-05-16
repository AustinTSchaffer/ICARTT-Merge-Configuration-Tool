using ICARTT_Merge_Configuration.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICARTT_Merge_Configuration.GUI
{
    public partial class ICARTT_ConfigurationBuilder : Form
    {
        public ICARTT_ConfigurationBuilder()
        {

            this.ProcessControls = new List<ProcessControl>()
            {
                new ProcessControl_DirectorySelect(),
                new ProcessControl_FileNameFilters(),
                new ProcessControl_FileSelect(),
                new ProcessControl_TimeVariableSelection(),
                new ProcessControl_VariableMapper()
            };

            InitializeComponent();
            PopulateNavigationListBox();
            this.ChangeCurrentProcessControl(ProcessControls.ElementAt(0));
            Logger.SetAuxiliaryDisplay(this.ConsoleOutTextBox);
        }


        private void PopulateNavigationListBox()
        {
            foreach (ProcessControl pc in this.ProcessControls) this.ListBox_Navigation.Items.Add(pc.DisplayName);
            this.ListBox_Navigation.SelectedIndex = 0;
        }


        private void ChangeCurrentProcessControl(ProcessControl pc)
        {
            if (pc == CurrentProcessControl) return;

            Logger.Log(Logger.MessageCode.Debug, typeof(ICARTT_ConfigurationBuilder), MethodBase.GetCurrentMethod(), "Changing Process View", "From: " + CurrentProcessControl.DisplayName, "To:   " + pc.DisplayName);


            this.SuspendLayout();
            CurrentProcessControl.Deactivate();
            this.Controls.Remove(CurrentProcessControl);


            pc.CopyStyles(CurrentProcessControl);
            this.CurrentProcessControl = pc;
            
            this.Controls.Add(CurrentProcessControl);
            this.ResumeLayout(true);

            this.ToggleNextAndBackButtonState();

            this.ListBox_Navigation.SelectedIndex = this.ProcessControls.IndexOf(CurrentProcessControl);

            this.CurrentProcessControl.Activate();
        }


        /// <summary>
        /// Deactivates Next and Back buttons based on the position in the process.
        /// </summary>
        private void ToggleNextAndBackButtonState()
        {
            int pos = this.ProcessControls.IndexOf(CurrentProcessControl);
            this.BackButton.Enabled = (pos > 0);
            this.NextButton.Enabled = (pos + 1 < this.ProcessControls.Count);
        }


        private void NavigationListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ProcessControl pc in ProcessControls)
            {
                if (pc.DisplayName.Equals(this.ListBox_Navigation.SelectedItem))
                {
                    this.ChangeCurrentProcessControl(pc);
                    return;
                }
            }
        }


        private void NextButton_Click(object sender, EventArgs e)
        {
            int pos = this.ProcessControls.IndexOf(CurrentProcessControl);

            if (pos >= 0 && pos + 1 < this.ProcessControls.Count)
            {
                this.ChangeCurrentProcessControl(this.ProcessControls.ElementAt(pos + 1));
            }
            else this.ChangeCurrentProcessControl(ProcessControls.ElementAt(0));
        }


        private void BackButton_Click(object sender, EventArgs e)
        {
            int pos = this.ProcessControls.IndexOf(CurrentProcessControl);

            if (pos == 0) return;
            else if (pos > 0)
            {
                this.ChangeCurrentProcessControl(this.ProcessControls.ElementAt(pos - 1));
            }
            else this.ChangeCurrentProcessControl(ProcessControls.ElementAt(0));
        }

        private void ConsoleOutTextBox_TextChanged(object sender, EventArgs e)
        {
            ConsoleOutTextBox.SelectionStart = ConsoleOutTextBox.TextLength;
            ConsoleOutTextBox.ScrollToCaret();
        }

        private void ICARTT_ConfigurationBuilder_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}