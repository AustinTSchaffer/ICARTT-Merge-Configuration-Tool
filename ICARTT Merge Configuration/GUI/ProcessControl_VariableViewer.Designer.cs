namespace ICARTT_Merge_Configuration.GUI
{
    partial class ProcessControl_VariableViewer
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
            this.ListBox_UniqueVariableNames = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_UniqueVariableNames = new System.Windows.Forms.Label();
            this.Label_VariableMetadata = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Size = new System.Drawing.Size(485, 634);
            // 
            // ListBox_UniqueVariableNames
            // 
            this.ListBox_UniqueVariableNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_UniqueVariableNames.FormattingEnabled = true;
            this.ListBox_UniqueVariableNames.IntegralHeight = false;
            this.ListBox_UniqueVariableNames.Location = new System.Drawing.Point(3, 23);
            this.ListBox_UniqueVariableNames.Name = "ListBox_UniqueVariableNames";
            this.ListBox_UniqueVariableNames.Size = new System.Drawing.Size(184, 608);
            this.ListBox_UniqueVariableNames.TabIndex = 0;
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
            this.tableLayoutPanel1.Controls.Add(this.ListBox_UniqueVariableNames, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label_UniqueVariableNames, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_VariableMetadata, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(485, 634);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Label_UniqueVariableNames
            // 
            this.Label_UniqueVariableNames.AutoSize = true;
            this.Label_UniqueVariableNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label_UniqueVariableNames.Location = new System.Drawing.Point(3, 0);
            this.Label_UniqueVariableNames.Name = "Label_UniqueVariableNames";
            this.Label_UniqueVariableNames.Size = new System.Drawing.Size(157, 17);
            this.Label_UniqueVariableNames.TabIndex = 1;
            this.Label_UniqueVariableNames.Text = "Unique Variable Names";
            // 
            // Label_VariableMetadata
            // 
            this.Label_VariableMetadata.AutoSize = true;
            this.Label_VariableMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label_VariableMetadata.Location = new System.Drawing.Point(203, 0);
            this.Label_VariableMetadata.Name = "Label_VariableMetadata";
            this.Label_VariableMetadata.Size = new System.Drawing.Size(123, 17);
            this.Label_VariableMetadata.TabIndex = 2;
            this.Label_VariableMetadata.Text = "Variable Metadata";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(203, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 608);
            this.panel1.TabIndex = 3;
            // 
            // ProcessControl_VariableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProcessControl_VariableViewer";
            this.Size = new System.Drawing.Size(485, 662);
            this.Controls.SetChildIndex(this.processLabel, 0);
            this.Controls.SetChildIndex(this.controlsPanel, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_UniqueVariableNames;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Label_UniqueVariableNames;
        private System.Windows.Forms.Label Label_VariableMetadata;
        private System.Windows.Forms.Panel panel1;
    }
}
