using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICARTT_Merge_Configuration.GUI
{
    public partial class ProcessControl : UserControl
    {

        /// <summary>
        /// Since the Name property of a UserControl gets rewritten everytime something changes using the designer vew, the object class has been given a new Name property.
        /// </summary>
        private string printedName;
        public string DisplayName { get { return String.Copy(printedName); } }


        public ProcessControl() : this("DEFAULT NAME") { }

        /// <summary>
        /// Method to call whenever a ProcessControl is shown to the user. Should load data from program state.
        /// </summary>
        public virtual void Activate()
        {

        }

        /// <summary>
        /// Method to call whenever a ProcessControl is taken from the user. Should store data to program state.
        /// </summary>
        public virtual void Deactivate()
        {

        }


        public ProcessControl(string name)
        {
            this.printedName = String.Copy(name);

            InitializeComponent();
            this.processLabel.Text = DisplayName;
        }

        public ProcessControl CopyStyles(ProcessControl pc)
        {
            this.Anchor = pc.Anchor;
            this.TabIndex = pc.TabIndex;
            this.TabStop = pc.TabStop;
            this.Location = new System.Drawing.Point(pc.Location.X, pc.Location.Y);
            this.Size = new System.Drawing.Size(pc.Size.Width, pc.Size.Height);

            return this;
        }
    }
}
