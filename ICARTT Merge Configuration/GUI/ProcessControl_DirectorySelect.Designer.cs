namespace ICARTT_Merge_Configuration.GUI
{
    partial class ProcessControl_DirectorySelect
    {
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.AboutTextBox = new System.Windows.Forms.RichTextBox();
            this.TextField_ExistingMergeConfig = new System.Windows.Forms.TextBox();
            this.CheckBox_ExistingMergeConfig = new System.Windows.Forms.CheckBox();
            this.TextField_RootDirectory = new System.Windows.Forms.TextBox();
            this.BrowseButton_ExistingMergeConfig = new System.Windows.Forms.Button();
            this.BrowseButton_ICARTTDirectory = new System.Windows.Forms.Button();
            this.SelectRootDirectoryLabel = new System.Windows.Forms.Label();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.controlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.controlsPanel.Controls.Add(this.SelectRootDirectoryLabel);
            this.controlsPanel.Controls.Add(this.BrowseButton_ICARTTDirectory);
            this.controlsPanel.Controls.Add(this.BrowseButton_ExistingMergeConfig);
            this.controlsPanel.Controls.Add(this.TextField_RootDirectory);
            this.controlsPanel.Controls.Add(this.CheckBox_ExistingMergeConfig);
            this.controlsPanel.Controls.Add(this.TextField_ExistingMergeConfig);
            this.controlsPanel.Controls.Add(this.AboutTextBox);
            this.controlsPanel.Size = new System.Drawing.Size(417, 490);
            // 
            // AboutTextBox
            // 
            this.AboutTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.AboutTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.AboutTextBox.Location = new System.Drawing.Point(0, 0);
            this.AboutTextBox.Name = "AboutTextBox";
            this.AboutTextBox.ReadOnly = true;
            this.AboutTextBox.Size = new System.Drawing.Size(417, 374);
            this.AboutTextBox.TabIndex = 0;
            this.AboutTextBox.TabStop = false;
            this.AboutTextBox.Text = "ASDF\nasdfasdf\nasdfasdf\nasdfasdfasdf\nasdfasdfasdf\n\nafafafaf.";
            // 
            // TextField_ExistingMergeConfig
            // 
            this.TextField_ExistingMergeConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextField_ExistingMergeConfig.Enabled = false;
            this.TextField_ExistingMergeConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextField_ExistingMergeConfig.Location = new System.Drawing.Point(0, 456);
            this.TextField_ExistingMergeConfig.Name = "TextField_ExistingMergeConfig";
            this.TextField_ExistingMergeConfig.Size = new System.Drawing.Size(336, 21);
            this.TextField_ExistingMergeConfig.TabIndex = 31;
            // 
            // CheckBox_ExistingMergeConfig
            // 
            this.CheckBox_ExistingMergeConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckBox_ExistingMergeConfig.AutoSize = true;
            this.CheckBox_ExistingMergeConfig.Enabled = false;
            this.CheckBox_ExistingMergeConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.CheckBox_ExistingMergeConfig.Location = new System.Drawing.Point(0, 434);
            this.CheckBox_ExistingMergeConfig.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.CheckBox_ExistingMergeConfig.Name = "CheckBox_ExistingMergeConfig";
            this.CheckBox_ExistingMergeConfig.Size = new System.Drawing.Size(226, 19);
            this.CheckBox_ExistingMergeConfig.TabIndex = 30;
            this.CheckBox_ExistingMergeConfig.Text = "Modify Existing Merge Configuration:";
            this.CheckBox_ExistingMergeConfig.UseVisualStyleBackColor = true;
            this.CheckBox_ExistingMergeConfig.CheckedChanged += new System.EventHandler(this.ModifyExistingMergeCheckbox_CheckedChanged);
            // 
            // TextField_RootDirectory
            // 
            this.TextField_RootDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextField_RootDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextField_RootDirectory.Location = new System.Drawing.Point(0, 407);
            this.TextField_RootDirectory.Name = "TextField_RootDirectory";
            this.TextField_RootDirectory.Size = new System.Drawing.Size(336, 21);
            this.TextField_RootDirectory.TabIndex = 21;
            // 
            // BrowseButton_ExistingMergeConfig
            // 
            this.BrowseButton_ExistingMergeConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton_ExistingMergeConfig.Enabled = false;
            this.BrowseButton_ExistingMergeConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BrowseButton_ExistingMergeConfig.Location = new System.Drawing.Point(342, 456);
            this.BrowseButton_ExistingMergeConfig.Name = "BrowseButton_ExistingMergeConfig";
            this.BrowseButton_ExistingMergeConfig.Size = new System.Drawing.Size(75, 21);
            this.BrowseButton_ExistingMergeConfig.TabIndex = 32;
            this.BrowseButton_ExistingMergeConfig.Text = "Browse...";
            this.BrowseButton_ExistingMergeConfig.UseVisualStyleBackColor = true;
            this.BrowseButton_ExistingMergeConfig.Click += new System.EventHandler(this.ExistingMergeBrowseButton_Click);
            // 
            // BrowseButton_ICARTTDirectory
            // 
            this.BrowseButton_ICARTTDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton_ICARTTDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BrowseButton_ICARTTDirectory.Location = new System.Drawing.Point(342, 407);
            this.BrowseButton_ICARTTDirectory.Name = "BrowseButton_ICARTTDirectory";
            this.BrowseButton_ICARTTDirectory.Size = new System.Drawing.Size(75, 21);
            this.BrowseButton_ICARTTDirectory.TabIndex = 22;
            this.BrowseButton_ICARTTDirectory.Text = "Browse...";
            this.BrowseButton_ICARTTDirectory.UseVisualStyleBackColor = true;
            this.BrowseButton_ICARTTDirectory.Click += new System.EventHandler(this.BrowseButton_ICARTTDirectory_Click);
            // 
            // SelectRootDirectoryLabel
            // 
            this.SelectRootDirectoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectRootDirectoryLabel.AutoSize = true;
            this.SelectRootDirectoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.SelectRootDirectoryLabel.Location = new System.Drawing.Point(-3, 389);
            this.SelectRootDirectoryLabel.Name = "SelectRootDirectoryLabel";
            this.SelectRootDirectoryLabel.Size = new System.Drawing.Size(124, 15);
            this.SelectRootDirectoryLabel.TabIndex = 20;
            this.SelectRootDirectoryLabel.Text = "Select Root Directory:";
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.Description = "Select ICARTT Directory";
            this.FolderBrowserDialog.ShowNewFolderButton = false;
            
            // 
            // ProcessControl_DirectorySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProcessControl_DirectorySelect";
            this.Size = new System.Drawing.Size(417, 518);
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox AboutTextBox;
        private System.Windows.Forms.CheckBox CheckBox_ExistingMergeConfig;
        private System.Windows.Forms.TextBox TextField_ExistingMergeConfig;
        private System.Windows.Forms.Button BrowseButton_ExistingMergeConfig;
        private System.Windows.Forms.TextBox TextField_RootDirectory;
        private System.Windows.Forms.Button BrowseButton_ICARTTDirectory;
        private System.Windows.Forms.Label SelectRootDirectoryLabel;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    }
}
