using ICARTT_Merge_Configuration.Utilities;

namespace ICARTT_Merge_Configuration.GUI
{
    partial class ProcessControl_FileSelect
    {
        

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
            this.LoadedIcarttFilesLabel = new System.Windows.Forms.Label();
            this.LoadedIcarttFiles = new System.Windows.Forms.CheckedListBox();
            this.MetadataViewerLabel = new System.Windows.Forms.Label();
            this.MetadataViewerPanel = new System.Windows.Forms.Panel();
            this.TextBox_Variables = new System.Windows.Forms.TextBox();
            this.Label_Variables = new System.Windows.Forms.Label();
            this.Label_Mission = new System.Windows.Forms.Label();
            this.TextBox_Mission = new System.Windows.Forms.TextBox();
            this.Label_FileSize = new System.Windows.Forms.Label();
            this.TextBox_FileSize = new System.Windows.Forms.TextBox();
            this.Label_DataSource = new System.Windows.Forms.Label();
            this.TextBox_DataSource = new System.Windows.Forms.TextBox();
            this.Label_Organization = new System.Windows.Forms.Label();
            this.TextBox_Organization = new System.Windows.Forms.TextBox();
            this.TextBox_PI = new System.Windows.Forms.TextBox();
            this.TextBox_Revision = new System.Windows.Forms.TextBox();
            this.TextBox_Date = new System.Windows.Forms.TextBox();
            this.TextBox_LocationID = new System.Windows.Forms.TextBox();
            this.TextBox_DataID = new System.Windows.Forms.TextBox();
            this.Label_PI = new System.Windows.Forms.Label();
            this.Label_Date = new System.Windows.Forms.Label();
            this.Label_DataID = new System.Windows.Forms.Label();
            this.Label_LocationID = new System.Windows.Forms.Label();
            this.Label_Revision = new System.Windows.Forms.Label();
            this.TextBox_FilePath = new System.Windows.Forms.TextBox();
            this.Label_FilePath = new System.Windows.Forms.Label();
            this.Label_FileName = new System.Windows.Forms.Label();
            this.TextBox_FileName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.controlsPanel.SuspendLayout();
            this.MetadataViewerPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.controlsPanel.Controls.Add(this.tableLayoutPanel1);
            this.controlsPanel.Size = new System.Drawing.Size(761, 453);
            // 
            // LoadedIcarttFilesLabel
            // 
            this.LoadedIcarttFilesLabel.AutoSize = true;
            this.LoadedIcarttFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LoadedIcarttFilesLabel.Location = new System.Drawing.Point(3, 0);
            this.LoadedIcarttFilesLabel.Name = "LoadedIcarttFilesLabel";
            this.LoadedIcarttFilesLabel.Size = new System.Drawing.Size(142, 17);
            this.LoadedIcarttFilesLabel.TabIndex = 1;
            this.LoadedIcarttFilesLabel.Text = "Loaded ICARTT Files";
            // 
            // LoadedIcarttFiles
            // 
            this.LoadedIcarttFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadedIcarttFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.LoadedIcarttFiles.FormattingEnabled = true;
            this.LoadedIcarttFiles.IntegralHeight = false;
            this.LoadedIcarttFiles.Location = new System.Drawing.Point(3, 23);
            this.LoadedIcarttFiles.Name = "LoadedIcarttFiles";
            this.LoadedIcarttFiles.Size = new System.Drawing.Size(294, 427);
            this.LoadedIcarttFiles.TabIndex = 2;
            this.LoadedIcarttFiles.SelectedIndexChanged += new System.EventHandler(this.LoadedIcarttFiles_SelectedIndexChanged);
            // 
            // MetadataViewerLabel
            // 
            this.MetadataViewerLabel.AutoSize = true;
            this.MetadataViewerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MetadataViewerLabel.Location = new System.Drawing.Point(313, 0);
            this.MetadataViewerLabel.Name = "MetadataViewerLabel";
            this.MetadataViewerLabel.Size = new System.Drawing.Size(146, 17);
            this.MetadataViewerLabel.TabIndex = 5;
            this.MetadataViewerLabel.Text = "ICARTT File Metadata";
            // 
            // MetadataViewerPanel
            // 
            this.MetadataViewerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetadataViewerPanel.AutoScroll = true;
            this.MetadataViewerPanel.Controls.Add(this.TextBox_Variables);
            this.MetadataViewerPanel.Controls.Add(this.Label_Variables);
            this.MetadataViewerPanel.Controls.Add(this.Label_Mission);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_Mission);
            this.MetadataViewerPanel.Controls.Add(this.Label_FileSize);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_FileSize);
            this.MetadataViewerPanel.Controls.Add(this.Label_DataSource);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_DataSource);
            this.MetadataViewerPanel.Controls.Add(this.Label_Organization);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_Organization);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_PI);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_Revision);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_Date);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_LocationID);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_DataID);
            this.MetadataViewerPanel.Controls.Add(this.Label_PI);
            this.MetadataViewerPanel.Controls.Add(this.Label_Date);
            this.MetadataViewerPanel.Controls.Add(this.Label_DataID);
            this.MetadataViewerPanel.Controls.Add(this.Label_LocationID);
            this.MetadataViewerPanel.Controls.Add(this.Label_Revision);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_FilePath);
            this.MetadataViewerPanel.Controls.Add(this.Label_FilePath);
            this.MetadataViewerPanel.Controls.Add(this.Label_FileName);
            this.MetadataViewerPanel.Controls.Add(this.TextBox_FileName);
            this.MetadataViewerPanel.Location = new System.Drawing.Point(313, 23);
            this.MetadataViewerPanel.Name = "MetadataViewerPanel";
            this.MetadataViewerPanel.Size = new System.Drawing.Size(445, 427);
            this.MetadataViewerPanel.TabIndex = 3;
            // 
            // TextBox_Variables
            // 
            this.TextBox_Variables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Variables.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Variables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Variables.Location = new System.Drawing.Point(80, 317);
            this.TextBox_Variables.Name = "TextBox_Variables";
            this.TextBox_Variables.ReadOnly = true;
            this.TextBox_Variables.Size = new System.Drawing.Size(365, 21);
            this.TextBox_Variables.TabIndex = 28;
            // 
            // Label_Variables
            // 
            this.Label_Variables.AutoSize = true;
            this.Label_Variables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_Variables.Location = new System.Drawing.Point(-3, 320);
            this.Label_Variables.Name = "Label_Variables";
            this.Label_Variables.Size = new System.Drawing.Size(58, 15);
            this.Label_Variables.TabIndex = 27;
            this.Label_Variables.Text = "Variables";
            // 
            // Label_Mission
            // 
            this.Label_Mission.AutoSize = true;
            this.Label_Mission.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_Mission.Location = new System.Drawing.Point(-3, 294);
            this.Label_Mission.Name = "Label_Mission";
            this.Label_Mission.Size = new System.Drawing.Size(50, 15);
            this.Label_Mission.TabIndex = 26;
            this.Label_Mission.Text = "Mission";
            // 
            // TextBox_Mission
            // 
            this.TextBox_Mission.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Mission.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Mission.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Mission.Location = new System.Drawing.Point(80, 291);
            this.TextBox_Mission.Name = "TextBox_Mission";
            this.TextBox_Mission.ReadOnly = true;
            this.TextBox_Mission.Size = new System.Drawing.Size(365, 21);
            this.TextBox_Mission.TabIndex = 25;
            // 
            // Label_FileSize
            // 
            this.Label_FileSize.AutoSize = true;
            this.Label_FileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_FileSize.Location = new System.Drawing.Point(-3, 60);
            this.Label_FileSize.Name = "Label_FileSize";
            this.Label_FileSize.Size = new System.Drawing.Size(54, 15);
            this.Label_FileSize.TabIndex = 24;
            this.Label_FileSize.Text = "File Size";
            // 
            // TextBox_FileSize
            // 
            this.TextBox_FileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_FileSize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_FileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_FileSize.Location = new System.Drawing.Point(67, 57);
            this.TextBox_FileSize.Name = "TextBox_FileSize";
            this.TextBox_FileSize.ReadOnly = true;
            this.TextBox_FileSize.Size = new System.Drawing.Size(378, 21);
            this.TextBox_FileSize.TabIndex = 23;
            // 
            // Label_DataSource
            // 
            this.Label_DataSource.AutoSize = true;
            this.Label_DataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_DataSource.Location = new System.Drawing.Point(-3, 267);
            this.Label_DataSource.Name = "Label_DataSource";
            this.Label_DataSource.Size = new System.Drawing.Size(75, 15);
            this.Label_DataSource.TabIndex = 22;
            this.Label_DataSource.Text = "Data Source";
            // 
            // TextBox_DataSource
            // 
            this.TextBox_DataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_DataSource.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_DataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_DataSource.Location = new System.Drawing.Point(80, 264);
            this.TextBox_DataSource.Name = "TextBox_DataSource";
            this.TextBox_DataSource.ReadOnly = true;
            this.TextBox_DataSource.Size = new System.Drawing.Size(365, 21);
            this.TextBox_DataSource.TabIndex = 21;
            // 
            // Label_Organization
            // 
            this.Label_Organization.AutoSize = true;
            this.Label_Organization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_Organization.Location = new System.Drawing.Point(-3, 240);
            this.Label_Organization.Name = "Label_Organization";
            this.Label_Organization.Size = new System.Drawing.Size(77, 15);
            this.Label_Organization.TabIndex = 20;
            this.Label_Organization.Text = "Organization";
            // 
            // TextBox_Organization
            // 
            this.TextBox_Organization.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Organization.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Organization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Organization.Location = new System.Drawing.Point(80, 237);
            this.TextBox_Organization.Name = "TextBox_Organization";
            this.TextBox_Organization.ReadOnly = true;
            this.TextBox_Organization.Size = new System.Drawing.Size(365, 21);
            this.TextBox_Organization.TabIndex = 19;
            // 
            // TextBox_PI
            // 
            this.TextBox_PI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_PI.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_PI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_PI.Location = new System.Drawing.Point(80, 210);
            this.TextBox_PI.Name = "TextBox_PI";
            this.TextBox_PI.ReadOnly = true;
            this.TextBox_PI.Size = new System.Drawing.Size(365, 21);
            this.TextBox_PI.TabIndex = 18;
            // 
            // TextBox_Revision
            // 
            this.TextBox_Revision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Revision.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Revision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Revision.Location = new System.Drawing.Point(72, 174);
            this.TextBox_Revision.Name = "TextBox_Revision";
            this.TextBox_Revision.ReadOnly = true;
            this.TextBox_Revision.Size = new System.Drawing.Size(373, 21);
            this.TextBox_Revision.TabIndex = 17;
            // 
            // TextBox_Date
            // 
            this.TextBox_Date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Date.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Date.Location = new System.Drawing.Point(72, 147);
            this.TextBox_Date.Name = "TextBox_Date";
            this.TextBox_Date.ReadOnly = true;
            this.TextBox_Date.Size = new System.Drawing.Size(373, 21);
            this.TextBox_Date.TabIndex = 16;
            // 
            // TextBox_LocationID
            // 
            this.TextBox_LocationID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_LocationID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_LocationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_LocationID.Location = new System.Drawing.Point(72, 120);
            this.TextBox_LocationID.Name = "TextBox_LocationID";
            this.TextBox_LocationID.ReadOnly = true;
            this.TextBox_LocationID.Size = new System.Drawing.Size(373, 21);
            this.TextBox_LocationID.TabIndex = 15;
            // 
            // TextBox_DataID
            // 
            this.TextBox_DataID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_DataID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_DataID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_DataID.Location = new System.Drawing.Point(72, 93);
            this.TextBox_DataID.Name = "TextBox_DataID";
            this.TextBox_DataID.ReadOnly = true;
            this.TextBox_DataID.Size = new System.Drawing.Size(373, 21);
            this.TextBox_DataID.TabIndex = 14;
            // 
            // Label_PI
            // 
            this.Label_PI.AutoSize = true;
            this.Label_PI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_PI.Location = new System.Drawing.Point(-3, 213);
            this.Label_PI.Name = "Label_PI";
            this.Label_PI.Size = new System.Drawing.Size(18, 15);
            this.Label_PI.TabIndex = 13;
            this.Label_PI.Text = "PI";
            // 
            // Label_Date
            // 
            this.Label_Date.AutoSize = true;
            this.Label_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_Date.Location = new System.Drawing.Point(-3, 150);
            this.Label_Date.Name = "Label_Date";
            this.Label_Date.Size = new System.Drawing.Size(33, 15);
            this.Label_Date.TabIndex = 12;
            this.Label_Date.Text = "Date";
            // 
            // Label_DataID
            // 
            this.Label_DataID.AutoSize = true;
            this.Label_DataID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_DataID.Location = new System.Drawing.Point(-3, 96);
            this.Label_DataID.Name = "Label_DataID";
            this.Label_DataID.Size = new System.Drawing.Size(48, 15);
            this.Label_DataID.TabIndex = 11;
            this.Label_DataID.Text = "Data ID";
            // 
            // Label_LocationID
            // 
            this.Label_LocationID.AutoSize = true;
            this.Label_LocationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_LocationID.Location = new System.Drawing.Point(-3, 123);
            this.Label_LocationID.Name = "Label_LocationID";
            this.Label_LocationID.Size = new System.Drawing.Size(69, 15);
            this.Label_LocationID.TabIndex = 10;
            this.Label_LocationID.Text = "Location ID";
            // 
            // Label_Revision
            // 
            this.Label_Revision.AutoSize = true;
            this.Label_Revision.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_Revision.Location = new System.Drawing.Point(-3, 177);
            this.Label_Revision.Name = "Label_Revision";
            this.Label_Revision.Size = new System.Drawing.Size(54, 15);
            this.Label_Revision.TabIndex = 9;
            this.Label_Revision.Text = "Revision";
            // 
            // TextBox_FilePath
            // 
            this.TextBox_FilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_FilePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_FilePath.Location = new System.Drawing.Point(67, 30);
            this.TextBox_FilePath.Name = "TextBox_FilePath";
            this.TextBox_FilePath.ReadOnly = true;
            this.TextBox_FilePath.Size = new System.Drawing.Size(378, 21);
            this.TextBox_FilePath.TabIndex = 8;
            // 
            // Label_FilePath
            // 
            this.Label_FilePath.AutoSize = true;
            this.Label_FilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_FilePath.Location = new System.Drawing.Point(-3, 33);
            this.Label_FilePath.Name = "Label_FilePath";
            this.Label_FilePath.Size = new System.Drawing.Size(55, 15);
            this.Label_FilePath.TabIndex = 7;
            this.Label_FilePath.Text = "File Path";
            // 
            // Label_FileName
            // 
            this.Label_FileName.AutoSize = true;
            this.Label_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label_FileName.Location = new System.Drawing.Point(-3, 6);
            this.Label_FileName.Name = "Label_FileName";
            this.Label_FileName.Size = new System.Drawing.Size(64, 15);
            this.Label_FileName.TabIndex = 6;
            this.Label_FileName.Text = "File Name";
            // 
            // TextBox_FileName
            // 
            this.TextBox_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_FileName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_FileName.Location = new System.Drawing.Point(67, 3);
            this.TextBox_FileName.Name = "TextBox_FileName";
            this.TextBox_FileName.ReadOnly = true;
            this.TextBox_FileName.Size = new System.Drawing.Size(378, 21);
            this.TextBox_FileName.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.MetadataViewerLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.MetadataViewerPanel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LoadedIcarttFilesLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LoadedIcarttFiles, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 453);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ProcessControl_FileSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProcessControl_FileSelect";
            this.Size = new System.Drawing.Size(761, 481);
            this.controlsPanel.ResumeLayout(false);
            this.MetadataViewerPanel.ResumeLayout(false);
            this.MetadataViewerPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label LoadedIcarttFilesLabel;
        private System.Windows.Forms.CheckedListBox LoadedIcarttFiles;
        private System.Windows.Forms.Panel MetadataViewerPanel;
        private System.Windows.Forms.TextBox TextBox_FileName;
        private System.Windows.Forms.Label MetadataViewerLabel;
        private System.Windows.Forms.Label Label_FileName;
        private System.Windows.Forms.Label Label_PI;
        private System.Windows.Forms.Label Label_Date;
        private System.Windows.Forms.Label Label_DataID;
        private System.Windows.Forms.Label Label_LocationID;
        private System.Windows.Forms.Label Label_Revision;
        private System.Windows.Forms.TextBox TextBox_FilePath;
        private System.Windows.Forms.Label Label_FilePath;
        private System.Windows.Forms.TextBox TextBox_Revision;
        private System.Windows.Forms.TextBox TextBox_Date;
        private System.Windows.Forms.TextBox TextBox_LocationID;
        private System.Windows.Forms.TextBox TextBox_DataID;
        private System.Windows.Forms.Label Label_Organization;
        private System.Windows.Forms.TextBox TextBox_Organization;
        private System.Windows.Forms.TextBox TextBox_PI;
        private System.Windows.Forms.Label Label_DataSource;
        private System.Windows.Forms.TextBox TextBox_DataSource;
        private System.Windows.Forms.Label Label_FileSize;
        private System.Windows.Forms.TextBox TextBox_FileSize;
        private System.Windows.Forms.Label Label_Mission;
        private System.Windows.Forms.TextBox TextBox_Mission;
        private System.Windows.Forms.TextBox TextBox_Variables;
        private System.Windows.Forms.Label Label_Variables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
