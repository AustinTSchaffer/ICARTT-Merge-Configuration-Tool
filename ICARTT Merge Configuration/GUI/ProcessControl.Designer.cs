namespace ICARTT_Merge_Configuration.GUI
{
    partial class ProcessControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.processLabel = new System.Windows.Forms.Label();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // processLabel
            // 
            this.processLabel.AutoSize = true;
            this.processLabel.BackColor = System.Drawing.SystemColors.Control;
            this.processLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.processLabel.Location = new System.Drawing.Point(-5, 0);
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(167, 25);
            this.processLabel.TabIndex = 0;
            this.processLabel.Text = "GENERIC LABEL";
            // 
            // controlsPanel
            // 
            this.controlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlsPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.controlsPanel.Location = new System.Drawing.Point(0, 28);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(319, 357);
            this.controlsPanel.TabIndex = 1;
            // 
            // ProcessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.processLabel);
            this.Name = "ProcessControl";
            this.Size = new System.Drawing.Size(319, 385);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label processLabel;
        protected System.Windows.Forms.Panel controlsPanel;
    }
}
