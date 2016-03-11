using System.Collections.Generic;
using System.Linq;

namespace ICARTT_Merge_Configuration.GUI
{
    partial class ICARTT_ConfigurationBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code




        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ICARTT_ConfigurationBuilder));
            this.ConsoleOutTextBox = new System.Windows.Forms.TextBox();
            this.BackAndNextPanel = new System.Windows.Forms.Panel();
            this.NextButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.NavigationListBox = new System.Windows.Forms.ListBox();
            this.NavigationListBoxLabel = new System.Windows.Forms.Label();
            this.CurrentProcessControl = new ICARTT_Merge_Configuration.GUI.ProcessControl();
            this.BackAndNextPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsoleOutTextBox
            // 
            this.ConsoleOutTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleOutTextBox.Location = new System.Drawing.Point(12, 547);
            this.ConsoleOutTextBox.Multiline = true;
            this.ConsoleOutTextBox.Name = "ConsoleOutTextBox";
            this.ConsoleOutTextBox.ReadOnly = true;
            this.ConsoleOutTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConsoleOutTextBox.Size = new System.Drawing.Size(557, 167);
            this.ConsoleOutTextBox.TabIndex = 4;
            this.ConsoleOutTextBox.TabStop = false;
            // 
            // BackAndNextPanel
            // 
            this.BackAndNextPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackAndNextPanel.Controls.Add(this.NextButton);
            this.BackAndNextPanel.Controls.Add(this.BackButton);
            this.BackAndNextPanel.Location = new System.Drawing.Point(183, 512);
            this.BackAndNextPanel.Name = "BackAndNextPanel";
            this.BackAndNextPanel.Size = new System.Drawing.Size(386, 29);
            this.BackAndNextPanel.TabIndex = 2;
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NextButton.Location = new System.Drawing.Point(311, 0);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 29);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BackButton.Location = new System.Drawing.Point(-1, 0);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 29);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NavigationListBox
            // 
            this.NavigationListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NavigationListBox.BackColor = System.Drawing.SystemColors.Control;
            this.NavigationListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NavigationListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.NavigationListBox.FormattingEnabled = true;
            this.NavigationListBox.IntegralHeight = false;
            this.NavigationListBox.ItemHeight = 20;
            this.NavigationListBox.Location = new System.Drawing.Point(12, 37);
            this.NavigationListBox.Name = "NavigationListBox";
            this.NavigationListBox.Size = new System.Drawing.Size(161, 504);
            this.NavigationListBox.TabIndex = 0;
            this.NavigationListBox.SelectedIndexChanged += new System.EventHandler(this.NavigationListBox_SelectedIndexChanged);
            // 
            // NavigationListBoxLabel
            // 
            this.NavigationListBoxLabel.AutoSize = true;
            this.NavigationListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.NavigationListBoxLabel.Location = new System.Drawing.Point(7, 9);
            this.NavigationListBoxLabel.Name = "NavigationListBoxLabel";
            this.NavigationListBoxLabel.Size = new System.Drawing.Size(104, 25);
            this.NavigationListBoxLabel.TabIndex = 5;
            this.NavigationListBoxLabel.Text = "Navigation";
            // 
            // CurrentProcessControl
            // 
            this.CurrentProcessControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentProcessControl.Location = new System.Drawing.Point(182, 9);
            this.CurrentProcessControl.Name = "CurrentProcessControl";
            this.CurrentProcessControl.Size = new System.Drawing.Size(387, 497);
            this.CurrentProcessControl.TabIndex = 3;
            // 
            // ICARTT_ConfigurationBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 726);
            this.Controls.Add(this.NavigationListBoxLabel);
            this.Controls.Add(this.CurrentProcessControl);
            this.Controls.Add(this.BackAndNextPanel);
            this.Controls.Add(this.NavigationListBox);
            this.Controls.Add(this.ConsoleOutTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ICARTT_ConfigurationBuilder";
            this.Text = "ICARTT Merge Configuration Builder";
            this.BackAndNextPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private List<ProcessControl> ProcessControls;
        private System.Windows.Forms.ListBox NavigationListBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Panel BackAndNextPanel;
        private System.Windows.Forms.TextBox ConsoleOutTextBox;
        private ProcessControl CurrentProcessControl;
        private System.Windows.Forms.Label NavigationListBoxLabel;
    }
}