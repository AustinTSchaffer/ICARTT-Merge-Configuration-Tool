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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Panel panel1;
            this.TreeView_UniqueInputVariables = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_Output_VariableMetadata = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Panel_Input_VariableMetadata = new System.Windows.Forms.Panel();
            this.TextBox_Input_DataID = new System.Windows.Forms.TextBox();
            this.ComboBox_Input_OutputVariable = new System.Windows.Forms.ComboBox();
            this.TextBox_VariableOtherStuff = new System.Windows.Forms.TextBox();
            this.TextBox_Input_VariableUnits = new System.Windows.Forms.TextBox();
            this.TextBox_Input_VariableName = new System.Windows.Forms.TextBox();
            this.DataGridView_OutputVariables = new System.Windows.Forms.DataGridView();
            this.OutVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Label_UniqueInputVariables = new System.Windows.Forms.Label();
            Label_VariableMetadata = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.Panel_Output_VariableMetadata.SuspendLayout();
            this.Panel_Input_VariableMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_OutputVariables)).BeginInit();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Size = new System.Drawing.Size(646, 428);
            // 
            // Label_UniqueInputVariables
            // 
            Label_UniqueInputVariables.AutoSize = true;
            Label_UniqueInputVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            Label_UniqueInputVariables.Location = new System.Drawing.Point(3, 0);
            Label_UniqueInputVariables.Name = "Label_UniqueInputVariables";
            Label_UniqueInputVariables.Size = new System.Drawing.Size(102, 17);
            Label_UniqueInputVariables.TabIndex = 1;
            Label_UniqueInputVariables.Text = "Input Variables";
            // 
            // Label_VariableMetadata
            // 
            Label_VariableMetadata.AutoSize = true;
            Label_VariableMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            Label_VariableMetadata.Location = new System.Drawing.Point(267, 0);
            Label_VariableMetadata.Name = "Label_VariableMetadata";
            Label_VariableMetadata.Size = new System.Drawing.Size(158, 17);
            Label_VariableMetadata.TabIndex = 2;
            Label_VariableMetadata.Text = "Input Variable Metadata";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label1.Location = new System.Drawing.Point(3, 214);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(114, 17);
            label1.TabIndex = 4;
            label1.Text = "Output Variables";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            label3.Location = new System.Drawing.Point(267, 214);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(170, 17);
            label3.TabIndex = 5;
            label3.Text = "Output Variable Metadata";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label6.Location = new System.Drawing.Point(0, 140);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(43, 15);
            label6.TabIndex = 10;
            label6.Text = "Output";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label5.Location = new System.Drawing.Point(0, 84);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(69, 15);
            label5.TabIndex = 9;
            label5.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label4.Location = new System.Drawing.Point(0, 57);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(35, 15);
            label4.TabIndex = 7;
            label4.Text = "Units";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label2.Location = new System.Drawing.Point(0, 30);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 15);
            label2.TabIndex = 0;
            label2.Text = "Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            label7.Location = new System.Drawing.Point(0, 3);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(48, 15);
            label7.TabIndex = 13;
            label7.Text = "Data ID";
            // 
            // panel1
            // 
            panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel1.Location = new System.Drawing.Point(0, 156);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(376, 32);
            panel1.TabIndex = 0;
            // 
            // TreeView_UniqueInputVariables
            // 
            this.TreeView_UniqueInputVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView_UniqueInputVariables.Location = new System.Drawing.Point(3, 23);
            this.TreeView_UniqueInputVariables.Name = "TreeView_UniqueInputVariables";
            this.TreeView_UniqueInputVariables.Size = new System.Drawing.Size(248, 188);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.Panel_Output_VariableMetadata, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.TreeView_UniqueInputVariables, 0, 1);
            this.tableLayoutPanel1.Controls.Add(Label_UniqueInputVariables, 0, 0);
            this.tableLayoutPanel1.Controls.Add(Label_VariableMetadata, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Panel_Input_VariableMetadata, 2, 1);
            this.tableLayoutPanel1.Controls.Add(label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(label3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.DataGridView_OutputVariables, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 428);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Panel_Output_VariableMetadata
            // 
            this.Panel_Output_VariableMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Output_VariableMetadata.AutoScroll = true;
            this.Panel_Output_VariableMetadata.Controls.Add(this.button1);
            this.Panel_Output_VariableMetadata.Controls.Add(panel1);
            this.Panel_Output_VariableMetadata.Location = new System.Drawing.Point(267, 237);
            this.Panel_Output_VariableMetadata.Name = "Panel_Output_VariableMetadata";
            this.Panel_Output_VariableMetadata.Size = new System.Drawing.Size(376, 188);
            this.Panel_Output_VariableMetadata.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
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
            this.Panel_Input_VariableMetadata.Location = new System.Drawing.Point(267, 23);
            this.Panel_Input_VariableMetadata.Name = "Panel_Input_VariableMetadata";
            this.Panel_Input_VariableMetadata.Size = new System.Drawing.Size(376, 188);
            this.Panel_Input_VariableMetadata.TabIndex = 3;
            // 
            // TextBox_Input_DataID
            // 
            this.TextBox_Input_DataID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Input_DataID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Input_DataID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Input_DataID.Location = new System.Drawing.Point(75, 0);
            this.TextBox_Input_DataID.Name = "TextBox_Input_DataID";
            this.TextBox_Input_DataID.ReadOnly = true;
            this.TextBox_Input_DataID.Size = new System.Drawing.Size(301, 21);
            this.TextBox_Input_DataID.TabIndex = 12;
            // 
            // ComboBox_Input_OutputVariable
            // 
            this.ComboBox_Input_OutputVariable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Input_OutputVariable.FormattingEnabled = true;
            this.ComboBox_Input_OutputVariable.Location = new System.Drawing.Point(75, 139);
            this.ComboBox_Input_OutputVariable.Name = "ComboBox_Input_OutputVariable";
            this.ComboBox_Input_OutputVariable.Size = new System.Drawing.Size(301, 21);
            this.ComboBox_Input_OutputVariable.TabIndex = 11;
            // 
            // TextBox_VariableOtherStuff
            // 
            this.TextBox_VariableOtherStuff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_VariableOtherStuff.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_VariableOtherStuff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_VariableOtherStuff.Location = new System.Drawing.Point(75, 81);
            this.TextBox_VariableOtherStuff.Multiline = true;
            this.TextBox_VariableOtherStuff.Name = "TextBox_VariableOtherStuff";
            this.TextBox_VariableOtherStuff.ReadOnly = true;
            this.TextBox_VariableOtherStuff.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_VariableOtherStuff.Size = new System.Drawing.Size(301, 52);
            this.TextBox_VariableOtherStuff.TabIndex = 8;
            // 
            // TextBox_Input_VariableUnits
            // 
            this.TextBox_Input_VariableUnits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Input_VariableUnits.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Input_VariableUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Input_VariableUnits.Location = new System.Drawing.Point(75, 54);
            this.TextBox_Input_VariableUnits.Name = "TextBox_Input_VariableUnits";
            this.TextBox_Input_VariableUnits.ReadOnly = true;
            this.TextBox_Input_VariableUnits.Size = new System.Drawing.Size(301, 21);
            this.TextBox_Input_VariableUnits.TabIndex = 6;
            // 
            // TextBox_Input_VariableName
            // 
            this.TextBox_Input_VariableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Input_VariableName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TextBox_Input_VariableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox_Input_VariableName.Location = new System.Drawing.Point(75, 27);
            this.TextBox_Input_VariableName.Name = "TextBox_Input_VariableName";
            this.TextBox_Input_VariableName.ReadOnly = true;
            this.TextBox_Input_VariableName.Size = new System.Drawing.Size(301, 21);
            this.TextBox_Input_VariableName.TabIndex = 5;
            // 
            // DataGridView_OutputVariables
            // 
            this.DataGridView_OutputVariables.AllowUserToResizeRows = false;
            this.DataGridView_OutputVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_OutputVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_OutputVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OutVarName,
            this.ColumnNumber});
            this.DataGridView_OutputVariables.Location = new System.Drawing.Point(3, 237);
            this.DataGridView_OutputVariables.Name = "DataGridView_OutputVariables";
            this.DataGridView_OutputVariables.Size = new System.Drawing.Size(248, 188);
            this.DataGridView_OutputVariables.TabIndex = 1;
            // 
            // OutVarName
            // 
            this.OutVarName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OutVarName.FillWeight = 500F;
            this.OutVarName.Frozen = true;
            this.OutVarName.HeaderText = "Name";
            this.OutVarName.Name = "OutVarName";
            this.OutVarName.Width = 146;
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNumber.FillWeight = 1F;
            this.ColumnNumber.HeaderText = "Column";
            this.ColumnNumber.Name = "ColumnNumber";
            // 
            // ProcessControl_VariableMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProcessControl_VariableMapper";
            this.Size = new System.Drawing.Size(646, 456);
            this.Controls.SetChildIndex(this.processLabel, 0);
            this.Controls.SetChildIndex(this.controlsPanel, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Panel_Output_VariableMetadata.ResumeLayout(false);
            this.Panel_Input_VariableMetadata.ResumeLayout(false);
            this.Panel_Input_VariableMetadata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_OutputVariables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView_UniqueInputVariables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel Panel_Input_VariableMetadata;
        private System.Windows.Forms.Panel Panel_Output_VariableMetadata;
        private System.Windows.Forms.TextBox TextBox_Input_VariableName;
        private System.Windows.Forms.ComboBox ComboBox_Input_OutputVariable;
        private System.Windows.Forms.TextBox TextBox_VariableOtherStuff;
        private System.Windows.Forms.TextBox TextBox_Input_VariableUnits;
        private System.Windows.Forms.TextBox TextBox_Input_DataID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DataGridView_OutputVariables;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutVarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
    }
}
