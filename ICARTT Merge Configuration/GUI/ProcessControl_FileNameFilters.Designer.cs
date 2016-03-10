namespace ICARTT_Merge_Configuration.GUI
{
    partial class ProcessControl_FileNameFilters
    {

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (base.components != null))
            {
                base.components.Dispose();
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
            this.ComboBox_LocationIDs = new System.Windows.Forms.ComboBox();
            this.Label_LocationID = new System.Windows.Forms.Label();
            this.Label_DataID = new System.Windows.Forms.Label();
            this.CheckedListBox_DataIDs = new System.Windows.Forms.CheckedListBox();
            this.CheckedListBox_Dates = new System.Windows.Forms.CheckedListBox();
            this.Label_Date = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Button_DataID_CheckAll = new System.Windows.Forms.Button();
            this.Button_DataID_UncheckAll = new System.Windows.Forms.Button();
            this.Button_Date_CheckAll = new System.Windows.Forms.Button();
            this.Button_Date_UncheckAll = new System.Windows.Forms.Button();
            this.controlsPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.AutoScroll = true;
            this.controlsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.controlsPanel.Controls.Add(this.tableLayoutPanel1);
            this.controlsPanel.Size = new System.Drawing.Size(330, 403);
            // 
            // ComboBox_LocationIDs
            // 
            this.ComboBox_LocationIDs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_LocationIDs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBox_LocationIDs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBox_LocationIDs.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.SetColumnSpan(this.ComboBox_LocationIDs, 3);
            this.ComboBox_LocationIDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ComboBox_LocationIDs.FormattingEnabled = true;
            this.ComboBox_LocationIDs.Location = new System.Drawing.Point(3, 23);
            this.ComboBox_LocationIDs.MaxDropDownItems = 15;
            this.ComboBox_LocationIDs.Name = "ComboBox_LocationIDs";
            this.ComboBox_LocationIDs.Size = new System.Drawing.Size(324, 23);
            this.ComboBox_LocationIDs.TabIndex = 0;
            this.ComboBox_LocationIDs.SelectedValueChanged += new System.EventHandler(this.ComboBox_LocationIDs_SelectionChanged);
            // 
            // Label_LocationID
            // 
            this.Label_LocationID.AutoSize = true;
            this.Label_LocationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label_LocationID.Location = new System.Drawing.Point(3, 0);
            this.Label_LocationID.Name = "Label_LocationID";
            this.Label_LocationID.Size = new System.Drawing.Size(79, 17);
            this.Label_LocationID.TabIndex = 1;
            this.Label_LocationID.Text = "Location ID";
            // 
            // Label_DataID
            // 
            this.Label_DataID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_DataID.AutoSize = true;
            this.Label_DataID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label_DataID.Location = new System.Drawing.Point(3, 67);
            this.Label_DataID.Name = "Label_DataID";
            this.Label_DataID.Size = new System.Drawing.Size(55, 17);
            this.Label_DataID.TabIndex = 2;
            this.Label_DataID.Text = "Data ID";
            // 
            // CheckedListBox_DataIDs
            // 
            this.CheckedListBox_DataIDs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckedListBox_DataIDs.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.CheckedListBox_DataIDs, 3);
            this.CheckedListBox_DataIDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.CheckedListBox_DataIDs.FormattingEnabled = true;
            this.CheckedListBox_DataIDs.IntegralHeight = false;
            this.CheckedListBox_DataIDs.Location = new System.Drawing.Point(3, 87);
            this.CheckedListBox_DataIDs.Name = "CheckedListBox_DataIDs";
            this.CheckedListBox_DataIDs.ScrollAlwaysVisible = true;
            this.CheckedListBox_DataIDs.Size = new System.Drawing.Size(324, 136);
            this.CheckedListBox_DataIDs.TabIndex = 3;
            // 
            // CheckedListBox_Dates
            // 
            this.CheckedListBox_Dates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckedListBox_Dates.CheckOnClick = true;
            this.tableLayoutPanel1.SetColumnSpan(this.CheckedListBox_Dates, 3);
            this.CheckedListBox_Dates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.CheckedListBox_Dates.FormattingEnabled = true;
            this.CheckedListBox_Dates.IntegralHeight = false;
            this.CheckedListBox_Dates.Location = new System.Drawing.Point(3, 264);
            this.CheckedListBox_Dates.Name = "CheckedListBox_Dates";
            this.CheckedListBox_Dates.ScrollAlwaysVisible = true;
            this.CheckedListBox_Dates.Size = new System.Drawing.Size(324, 136);
            this.CheckedListBox_Dates.TabIndex = 5;
            // 
            // Label_Date
            // 
            this.Label_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label_Date.AutoSize = true;
            this.Label_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label_Date.Location = new System.Drawing.Point(3, 244);
            this.Label_Date.Name = "Label_Date";
            this.Label_Date.Size = new System.Drawing.Size(38, 17);
            this.Label_Date.TabIndex = 6;
            this.Label_Date.Text = "Date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.CheckedListBox_Dates, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Label_LocationID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ComboBox_LocationIDs, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label_Date, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.CheckedListBox_DataIDs, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Label_DataID, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Button_DataID_CheckAll, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Button_DataID_UncheckAll, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Button_Date_CheckAll, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Button_Date_UncheckAll, 2, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(330, 403);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Button_DataID_CheckAll
            // 
            this.Button_DataID_CheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DataID_CheckAll.Location = new System.Drawing.Point(182, 61);
            this.Button_DataID_CheckAll.Margin = new System.Windows.Forms.Padding(0);
            this.Button_DataID_CheckAll.Name = "Button_DataID_CheckAll";
            this.Button_DataID_CheckAll.Size = new System.Drawing.Size(68, 23);
            this.Button_DataID_CheckAll.TabIndex = 7;
            this.Button_DataID_CheckAll.Text = "Check All";
            this.Button_DataID_CheckAll.UseVisualStyleBackColor = true;
            this.Button_DataID_CheckAll.Click += new System.EventHandler(this.Button_X_CheckAll_Click);
            // 
            // Button_DataID_UncheckAll
            // 
            this.Button_DataID_UncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DataID_UncheckAll.Location = new System.Drawing.Point(253, 61);
            this.Button_DataID_UncheckAll.Margin = new System.Windows.Forms.Padding(0);
            this.Button_DataID_UncheckAll.Name = "Button_DataID_UncheckAll";
            this.Button_DataID_UncheckAll.Size = new System.Drawing.Size(77, 23);
            this.Button_DataID_UncheckAll.TabIndex = 8;
            this.Button_DataID_UncheckAll.Text = "Uncheck All";
            this.Button_DataID_UncheckAll.UseVisualStyleBackColor = true;
            this.Button_DataID_UncheckAll.Click += new System.EventHandler(this.Button_X_CheckAll_Click);
            // 
            // Button_Date_CheckAll
            // 
            this.Button_Date_CheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Date_CheckAll.Location = new System.Drawing.Point(182, 238);
            this.Button_Date_CheckAll.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Date_CheckAll.Name = "Button_Date_CheckAll";
            this.Button_Date_CheckAll.Size = new System.Drawing.Size(68, 23);
            this.Button_Date_CheckAll.TabIndex = 9;
            this.Button_Date_CheckAll.Text = "Check All";
            this.Button_Date_CheckAll.UseVisualStyleBackColor = true;
            this.Button_Date_CheckAll.Click += new System.EventHandler(this.Button_X_CheckAll_Click);
            // 
            // Button_Date_UncheckAll
            // 
            this.Button_Date_UncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Date_UncheckAll.Location = new System.Drawing.Point(253, 238);
            this.Button_Date_UncheckAll.Margin = new System.Windows.Forms.Padding(0);
            this.Button_Date_UncheckAll.Name = "Button_Date_UncheckAll";
            this.Button_Date_UncheckAll.Size = new System.Drawing.Size(77, 23);
            this.Button_Date_UncheckAll.TabIndex = 10;
            this.Button_Date_UncheckAll.Text = "Uncheck All";
            this.Button_Date_UncheckAll.UseVisualStyleBackColor = true;
            this.Button_Date_UncheckAll.Click += new System.EventHandler(this.Button_X_CheckAll_Click);
            // 
            // ProcessControl_FileNameFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProcessControl_FileNameFilters";
            this.Size = new System.Drawing.Size(330, 431);
            this.controlsPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_LocationID;
        private System.Windows.Forms.ComboBox ComboBox_LocationIDs;
        private System.Windows.Forms.CheckedListBox CheckedListBox_Dates;
        private System.Windows.Forms.CheckedListBox CheckedListBox_DataIDs;
        private System.Windows.Forms.Label Label_DataID;
        private System.Windows.Forms.Label Label_Date;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Button_DataID_CheckAll;
        private System.Windows.Forms.Button Button_DataID_UncheckAll;
        private System.Windows.Forms.Button Button_Date_CheckAll;
        private System.Windows.Forms.Button Button_Date_UncheckAll;
    }
}
