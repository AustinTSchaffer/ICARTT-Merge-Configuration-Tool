namespace ICARTT_Merge_Configuration.GUI
{
    partial class ProcessControl_VariableMapper : ProcessControl
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
            System.Windows.Forms.Label Label_UniqueInputVariables;
            System.Windows.Forms.Label Label_VariableMetadata;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            this.TreeView_UniqueInputVariables = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_Input_VariableMetadata = new System.Windows.Forms.Panel();
            this.TextBox_Input_DataID = new System.Windows.Forms.TextBox();
            this.ComboBox_Input_OutputVariable = new System.Windows.Forms.ComboBox();
            this.TextBox_VariableOtherStuff = new System.Windows.Forms.TextBox();
            this.TextBox_Input_VariableUnits = new System.Windows.Forms.TextBox();
            this.TextBox_Input_VariableName = new System.Windows.Forms.TextBox();
            this.ListBox_OutputVariables = new System.Windows.Forms.ListBox();
            Label_UniqueInputVariables = new System.Windows.Forms.Label();
            Label_VariableMetadata = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.Panel_Input_VariableMetadata.SuspendLayout();
            this.SuspendLayout();
            // 
            // processLabel
            // 
            this.processLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            // 
            // controlsPanel
            // 
            this.controlsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.controlsPanel.Size = new System.Drawing.Size(861, 527);
            // 
            // Label_UniqueInputVariables
            // 
            Label_UniqueInputVariables.AutoSize = true;
            Label_UniqueInputVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            Label_UniqueInputVariables.Location = new System.Drawing.Point(4, 0);
            Label_UniqueInputVariables.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label_UniqueInputVariables.Name = "Label_UniqueInputVariables";
            Label_UniqueInputVariables.Size = new System.Drawing.Size(120, 20);
            Label_UniqueInputVariables.TabIndex = 1;
            Label_UniqueInputVariables.Text = "Input Variables";
            // 
            // Label_VariableMetadata
            // 
            Label_VariableMetadata.AutoSize = true;
            Label_VariableMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            Label_VariableMetadata.Location = new System.Drawing.Point(356, 0);
            Label_VariableMetadata.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            Label_VariableMetadata.Name = "Label_VariableMetadata";
            Label_VariableMetadata.Size = new System.Drawing.Size(185, 20);
            Label_VariableMetadata.TabIndex = 2;
            Label_VariableMetadata.Text = "Input Variable Metadata";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label6.Location = new System.Drawing.Point(0, 172);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(52, 18);
            label6.TabIndex = 10;
            label6.Text = "Output";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label5.Location = new System.Drawing.Point(0, 103);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(83, 18);
            label5.TabIndex = 9;
            label5.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label4.Location = new System.Drawing.Point(0, 70);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(42, 18);
            label4.TabIndex = 7;
            label4.Text = "Units";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label2.Location = new System.Drawing.Point(0, 37);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 18);
            label2.TabIndex = 0;
            label2.Text = "Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label7.Location = new System.Drawing.Point(0, 4);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(57, 18);
            label7.TabIndex = 13;
            label7.Text = "Data ID";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label1.Location = new System.Drawing.Point(4, 263);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(134, 20);
            label1.TabIndex = 4;
            label1.Text = "Output Variables";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label3.Location = new System.Drawing.Point(356, 263);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(199, 20);
            label3.TabIndex = 5;
            label3.Text = "Output Variable Metadata";
            // 
            // TreeView_UniqueInputVariables
            // 
            this.TreeView_UniqueInputVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView_UniqueInputVariables.Location = new System.Drawing.Point(4, 29);
            this.TreeView_UniqueInputVariables.Margin = new System.Windows.Forms.Padding(4);
            this.TreeView_UniqueInputVariables.Name = "TreeView_UniqueInputVariables";
            this.TreeView_UniqueInputVariables.Size = new System.Drawing.Size(331, 230);
            this.TreeView_UniqueInputVariables.TabIndex = 0;
            this.TreeView_UniqueInputVariables.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_UniqueInputVariables_AfterSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.TreeView_UniqueInputVariables, 0, 1);
            this.tableLayoutPanel1.Controls.Add(Label_UniqueInputVariables, 0, 0);
            this.tableLayoutPanel1.Controls.Add(Label_VariableMetadata, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Panel_Input_VariableMetadata, 2, 1);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ListBox_OutputVariables, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(861, 527);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Panel_Input_VariableMetadata
            // 
            this.Panel_Input_VariableMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Input_VariableMetadata.AutoScroll = true;
            this.Panel_Input_VariableMetadata.Controls.Add(label7);
            this.Panel_Input_VariableMetadata.Controls.Add(this.TextBox_Input_DataID);
            this.Panel_Input_VariableMetadata.Controls.Add(this.ComboBox_Input_OutputVariable);
            this.Panel_Input_VariableMetadata.Controls.Add(label6);
            this.Panel_Input_VariableMetadata.Controls.Add(label5);
            this.Panel_Input_VariableMetadata.Controls.Add(this.TextBox_VariableOtherStuff);
            this.Panel_Input_VariableMetadata.Controls.Add(label4);
            this.Panel_Input_VariableMetadata.Controls.Add(this.TextBox_Input_VariableUnits);
            this.Panel_Input_VariableMetadata.Controls.Add(this.TextBox_Input_VariableName);
            this.Panel_Input_VariableMetadata.Controls.Add(label2);
            this.Panel_Input_VariableMetadata.Location = new System.Drawing.Point(356, 29);
            this.Panel_Input_VariableMetadata.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Input_VariableMetadata.Name = "Panel_Input_VariableMetadata";
            this.Panel_Input_VariableMetadata.Size = new System.Drawing.Size(501, 230);
            this.Panel_Input_VariableMetadata.TabIndex = 3;
            // 
            // TextBox_Input_DataID
            // 
            this.TextBox_Input_DataID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Input_DataID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Input_DataID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Input_DataID.Location = new System.Drawing.Point(100, 0);
            this.TextBox_Input_DataID.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_Input_DataID.Name = "TextBox_Input_DataID";
            this.TextBox_Input_DataID.ReadOnly = true;
            this.TextBox_Input_DataID.Size = new System.Drawing.Size(400, 24);
            this.TextBox_Input_DataID.TabIndex = 12;
            // 
            // ComboBox_Input_OutputVariable
            // 
            this.ComboBox_Input_OutputVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Input_OutputVariable.FormattingEnabled = true;
            this.ComboBox_Input_OutputVariable.Location = new System.Drawing.Point(100, 171);
            this.ComboBox_Input_OutputVariable.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBox_Input_OutputVariable.Name = "ComboBox_Input_OutputVariable";
            this.ComboBox_Input_OutputVariable.Size = new System.Drawing.Size(400, 24);
            this.ComboBox_Input_OutputVariable.TabIndex = 11;
            // 
            // TextBox_VariableOtherStuff
            // 
            this.TextBox_VariableOtherStuff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_VariableOtherStuff.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_VariableOtherStuff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_VariableOtherStuff.Location = new System.Drawing.Point(100, 100);
            this.TextBox_VariableOtherStuff.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_VariableOtherStuff.Multiline = true;
            this.TextBox_VariableOtherStuff.Name = "TextBox_VariableOtherStuff";
            this.TextBox_VariableOtherStuff.ReadOnly = true;
            this.TextBox_VariableOtherStuff.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_VariableOtherStuff.Size = new System.Drawing.Size(400, 63);
            this.TextBox_VariableOtherStuff.TabIndex = 8;
            // 
            // TextBox_Input_VariableUnits
            // 
            this.TextBox_Input_VariableUnits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Input_VariableUnits.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Input_VariableUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Input_VariableUnits.Location = new System.Drawing.Point(100, 66);
            this.TextBox_Input_VariableUnits.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_Input_VariableUnits.Name = "TextBox_Input_VariableUnits";
            this.TextBox_Input_VariableUnits.ReadOnly = true;
            this.TextBox_Input_VariableUnits.Size = new System.Drawing.Size(400, 24);
            this.TextBox_Input_VariableUnits.TabIndex = 6;
            // 
            // TextBox_Input_VariableName
            // 
            this.TextBox_Input_VariableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Input_VariableName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Input_VariableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Input_VariableName.Location = new System.Drawing.Point(100, 33);
            this.TextBox_Input_VariableName.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_Input_VariableName.Name = "TextBox_Input_VariableName";
            this.TextBox_Input_VariableName.ReadOnly = true;
            this.TextBox_Input_VariableName.Size = new System.Drawing.Size(400, 24);
            this.TextBox_Input_VariableName.TabIndex = 5;
            // 
            // ListBox_OutputVariables
            // 
            this.ListBox_OutputVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_OutputVariables.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListBox_OutputVariables.FormattingEnabled = true;
            this.ListBox_OutputVariables.ItemHeight = 16;
            this.ListBox_OutputVariables.Location = new System.Drawing.Point(3, 291);
            this.ListBox_OutputVariables.Name = "ListBox_OutputVariables";
            this.ListBox_OutputVariables.Size = new System.Drawing.Size(333, 228);
            this.ListBox_OutputVariables.TabIndex = 6;
            // 
            // ProcessControl_VariableMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ProcessControl_VariableMapper";
            this.Size = new System.Drawing.Size(861, 561);
            this.Controls.SetChildIndex(this.processLabel, 0);
            this.Controls.SetChildIndex(this.controlsPanel, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Panel_Input_VariableMetadata.ResumeLayout(false);
            this.Panel_Input_VariableMetadata.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView_UniqueInputVariables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel Panel_Input_VariableMetadata;
        private System.Windows.Forms.TextBox TextBox_Input_VariableName;
        private System.Windows.Forms.ComboBox ComboBox_Input_OutputVariable;
        private System.Windows.Forms.TextBox TextBox_VariableOtherStuff;
        private System.Windows.Forms.TextBox TextBox_Input_VariableUnits;
        private System.Windows.Forms.TextBox TextBox_Input_DataID;
        private System.Windows.Forms.ListBox ListBox_OutputVariables;
    }
}
