namespace eLib.Forms
    {
    partial class frmTest
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
            {
            if (disposing && (components != null))
                {
                components.Dispose ();
                }
            base.Dispose (disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
            {
            components = new System.ComponentModel.Container ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle ();
            txtTest = new System.Windows.Forms.TextBox ();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu_Save = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            radio4 = new System.Windows.Forms.RadioButton ();
            radio2 = new System.Windows.Forms.RadioButton ();
            groupBox1 = new System.Windows.Forms.GroupBox ();
            radio3 = new System.Windows.Forms.RadioButton ();
            chkOptionsRTL = new System.Windows.Forms.CheckBox ();
            radio5 = new System.Windows.Forms.RadioButton ();
            radio1 = new System.Windows.Forms.RadioButton ();
            gridOptions = new System.Windows.Forms.DataGridView ();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu2_AddOption = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_EditOption = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_DeleteOption = new System.Windows.Forms.ToolStripMenuItem ();
            label1 = new System.Windows.Forms.Label ();
            label2 = new System.Windows.Forms.Label ();
            lstTopics = new System.Windows.Forms.ListBox ();
            lblExit = new System.Windows.Forms.Label ();
            panel1 = new System.Windows.Forms.Panel ();
            lblSave = new System.Windows.Forms.Label ();
            chkTestRTL = new System.Windows.Forms.CheckBox ();
            chkDblClick2Paste = new System.Windows.Forms.CheckBox ();
            cboTests = new System.Windows.Forms.ComboBox ();
            lbl4 = new System.Windows.Forms.Label ();
            lbl1 = new System.Windows.Forms.Label ();
            lbl2 = new System.Windows.Forms.Label ();
            lbl3 = new System.Windows.Forms.Label ();
            lbl5 = new System.Windows.Forms.Label ();
            lblTo = new System.Windows.Forms.Label ();
            lblFrom = new System.Windows.Forms.Label ();
            lvl2 = new System.Windows.Forms.TrackBar ();
            lvl1 = new System.Windows.Forms.TrackBar ();
            panel2 = new System.Windows.Forms.Panel ();
            btn_Previous = new System.Windows.Forms.Button ();
            btn_Next = new System.Windows.Forms.Button ();
            contextMenuStrip1.SuspendLayout ();
            groupBox1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) gridOptions).BeginInit ();
            contextMenuStrip2.SuspendLayout ();
            panel1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) lvl2).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) lvl1).BeginInit ();
            panel2.SuspendLayout ();
            SuspendLayout ();
            // 
            // txtTest
            // 
            txtTest.BackColor = System.Drawing.SystemColors.InactiveBorder;
            txtTest.ContextMenuStrip = contextMenuStrip1;
            txtTest.Font = new System.Drawing.Font ("Segoe UI", 12F);
            txtTest.Location = new System.Drawing.Point (12, 95);
            txtTest.Multiline = true;
            txtTest.Name = "txtTest";
            txtTest.Size = new System.Drawing.Size (911, 119);
            txtTest.TabIndex = 0;
            txtTest.DoubleClick += txtTest_DoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_Save, Menu_Exit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size (139, 48);
            // 
            // Menu_Save
            // 
            Menu_Save.Name = "Menu_Save";
            Menu_Save.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            Menu_Save.Size = new System.Drawing.Size (138, 22);
            Menu_Save.Text = "Save";
            Menu_Save.Click += Menu_Save_Click;
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
            Menu_Exit.Size = new System.Drawing.Size (138, 22);
            Menu_Exit.Text = "Exit";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // radio4
            // 
            radio4.AutoSize = true;
            radio4.Checked = true;
            radio4.Font = new System.Drawing.Font ("Segoe UI", 9F);
            radio4.Location = new System.Drawing.Point (10, 52);
            radio4.Name = "radio4";
            radio4.Size = new System.Drawing.Size (74, 19);
            radio4.TabIndex = 2;
            radio4.TabStop = true;
            radio4.Text = "4 options";
            radio4.UseVisualStyleBackColor = true;
            radio4.CheckedChanged += radio4_CheckedChanged;
            // 
            // radio2
            // 
            radio2.AutoSize = true;
            radio2.Font = new System.Drawing.Font ("Segoe UI", 9F);
            radio2.Location = new System.Drawing.Point (10, 110);
            radio2.Name = "radio2";
            radio2.Size = new System.Drawing.Size (78, 19);
            radio2.TabIndex = 3;
            radio2.Text = "True/False";
            radio2.UseVisualStyleBackColor = true;
            radio2.CheckedChanged += radio2_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add (radio3);
            groupBox1.Controls.Add (chkOptionsRTL);
            groupBox1.Controls.Add (radio5);
            groupBox1.Controls.Add (radio1);
            groupBox1.Controls.Add (radio4);
            groupBox1.Controls.Add (radio2);
            groupBox1.ForeColor = System.Drawing.Color.DimGray;
            groupBox1.Location = new System.Drawing.Point (933, 267);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size (94, 203);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // radio3
            // 
            radio3.AutoSize = true;
            radio3.Font = new System.Drawing.Font ("Segoe UI", 9F);
            radio3.Location = new System.Drawing.Point (10, 81);
            radio3.Name = "radio3";
            radio3.Size = new System.Drawing.Size (74, 19);
            radio3.TabIndex = 15;
            radio3.Text = "3 options";
            radio3.UseVisualStyleBackColor = true;
            radio3.CheckedChanged += radio3_CheckedChanged;
            // 
            // chkOptionsRTL
            // 
            chkOptionsRTL.AutoSize = true;
            chkOptionsRTL.Font = new System.Drawing.Font ("Segoe UI", 9F);
            chkOptionsRTL.Location = new System.Drawing.Point (10, 164);
            chkOptionsRTL.Name = "chkOptionsRTL";
            chkOptionsRTL.Size = new System.Drawing.Size (44, 19);
            chkOptionsRTL.TabIndex = 13;
            chkOptionsRTL.Text = "RTL";
            chkOptionsRTL.UseVisualStyleBackColor = true;
            chkOptionsRTL.CheckedChanged += chkOptionsRTL_CheckedChanged;
            // 
            // radio5
            // 
            radio5.AutoSize = true;
            radio5.Font = new System.Drawing.Font ("Segoe UI", 9F);
            radio5.Location = new System.Drawing.Point (10, 22);
            radio5.Name = "radio5";
            radio5.Size = new System.Drawing.Size (74, 19);
            radio5.TabIndex = 14;
            radio5.Text = "5 options";
            radio5.UseVisualStyleBackColor = true;
            radio5.CheckedChanged += radio5_CheckedChanged;
            // 
            // radio1
            // 
            radio1.AutoSize = true;
            radio1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            radio1.Location = new System.Drawing.Point (10, 139);
            radio1.Name = "radio1";
            radio1.Size = new System.Drawing.Size (74, 19);
            radio1.TabIndex = 4;
            radio1.Text = "Short ans";
            radio1.UseVisualStyleBackColor = true;
            radio1.CheckedChanged += radio1_CheckedChanged;
            // 
            // gridOptions
            // 
            gridOptions.AllowUserToAddRows = false;
            gridOptions.AllowUserToDeleteRows = false;
            gridOptions.AllowUserToResizeColumns = false;
            gridOptions.AllowUserToResizeRows = false;
            gridOptions.BackgroundColor = System.Drawing.Color.FromArgb (  246,   246,   246);
            gridOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            gridOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridOptions.ContextMenuStrip = contextMenuStrip2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb (  246,   246,   246);
            dataGridViewCellStyle3.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            gridOptions.DefaultCellStyle = dataGridViewCellStyle3;
            gridOptions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            gridOptions.GridColor = System.Drawing.Color.FromArgb (  246,   246,   246);
            gridOptions.Location = new System.Drawing.Point (12, 274);
            gridOptions.Name = "gridOptions";
            gridOptions.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb (  246,   246,   246);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.IndianRed;
            gridOptions.RowsDefaultCellStyle = dataGridViewCellStyle4;
            gridOptions.Size = new System.Drawing.Size (911, 196);
            gridOptions.TabIndex = 6;
            gridOptions.CellDoubleClick += gridOptions_CellDoubleClick;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu2_AddOption, Menu2_EditOption, Menu2_DeleteOption });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size (137, 70);
            // 
            // Menu2_AddOption
            // 
            Menu2_AddOption.Name = "Menu2_AddOption";
            Menu2_AddOption.Size = new System.Drawing.Size (136, 22);
            Menu2_AddOption.Text = "Add Option";
            Menu2_AddOption.Click += Menu2_AddOption_Click;
            // 
            // Menu2_EditOption
            // 
            Menu2_EditOption.Name = "Menu2_EditOption";
            Menu2_EditOption.Size = new System.Drawing.Size (136, 22);
            Menu2_EditOption.Text = "Edit";
            Menu2_EditOption.Click += Menu2_EditOption_Click;
            // 
            // Menu2_DeleteOption
            // 
            Menu2_DeleteOption.Name = "Menu2_DeleteOption";
            Menu2_DeleteOption.Size = new System.Drawing.Size (136, 22);
            Menu2_DeleteOption.Text = "Delete";
            Menu2_DeleteOption.Click += Menu2_DeleteOption_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font ("Segoe UI", 12F);
            label1.ForeColor = System.Drawing.Color.DimGray;
            label1.Location = new System.Drawing.Point (436, 68);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size (73, 21);
            label1.TabIndex = 1;
            label1.Text = "Question";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font ("Segoe UI", 12F);
            label2.ForeColor = System.Drawing.Color.DimGray;
            label2.Location = new System.Drawing.Point (435, 248);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size (65, 21);
            label2.TabIndex = 7;
            label2.Text = "Options";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstTopics
            // 
            lstTopics.BackColor = System.Drawing.Color.FromArgb (  246,   246,   246);
            lstTopics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstTopics.Font = new System.Drawing.Font ("Segoe UI", 10F);
            lstTopics.FormattingEnabled = true;
            lstTopics.ItemHeight = 17;
            lstTopics.Location = new System.Drawing.Point (933, 95);
            lstTopics.Name = "lstTopics";
            lstTopics.Size = new System.Drawing.Size (295, 119);
            lstTopics.TabIndex = 8;
            // 
            // lblExit
            // 
            lblExit.BackColor = System.Drawing.Color.WhiteSmoke;
            lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            lblExit.Font = new System.Drawing.Font ("Segoe UI", 10F);
            lblExit.ForeColor = System.Drawing.Color.IndianRed;
            lblExit.Location = new System.Drawing.Point (1035, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (204, 18);
            lblExit.TabIndex = 9;
            lblExit.Text = "Back";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblSave);
            panel1.Controls.Add (lblExit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 527);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (1239, 18);
            panel1.TabIndex = 11;
            // 
            // lblSave
            // 
            lblSave.BackColor = System.Drawing.Color.CornflowerBlue;
            lblSave.Dock = System.Windows.Forms.DockStyle.Left;
            lblSave.Font = new System.Drawing.Font ("Segoe UI", 10F);
            lblSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lblSave.Location = new System.Drawing.Point (0, 0);
            lblSave.Name = "lblSave";
            lblSave.Size = new System.Drawing.Size (1017, 18);
            lblSave.TabIndex = 12;
            lblSave.Text = "Save";
            lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblSave.Click += lblSave_Click;
            // 
            // chkTestRTL
            // 
            chkTestRTL.AutoSize = true;
            chkTestRTL.Location = new System.Drawing.Point (879, 70);
            chkTestRTL.Name = "chkTestRTL";
            chkTestRTL.Size = new System.Drawing.Size (44, 19);
            chkTestRTL.TabIndex = 12;
            chkTestRTL.Text = "RTL";
            chkTestRTL.UseVisualStyleBackColor = true;
            chkTestRTL.CheckedChanged += chkTestRTL_CheckedChanged;
            // 
            // chkDblClick2Paste
            // 
            chkDblClick2Paste.AutoSize = true;
            chkDblClick2Paste.Location = new System.Drawing.Point (420, 476);
            chkDblClick2Paste.Name = "chkDblClick2Paste";
            chkDblClick2Paste.Size = new System.Drawing.Size (104, 19);
            chkDblClick2Paste.TabIndex = 18;
            chkDblClick2Paste.Text = "DblClick: Paste";
            chkDblClick2Paste.UseVisualStyleBackColor = true;
            chkDblClick2Paste.CheckedChanged += chkDblClick2Paste_CheckedChanged;
            // 
            // cboTests
            // 
            cboTests.BackColor = System.Drawing.Color.WhiteSmoke;
            cboTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTests.Font = new System.Drawing.Font ("Segoe UI", 8F);
            cboTests.ForeColor = System.Drawing.SystemColors.WindowText;
            cboTests.FormattingEnabled = true;
            cboTests.ItemHeight = 13;
            cboTests.Location = new System.Drawing.Point (57, 4);
            cboTests.Name = "cboTests";
            cboTests.Size = new System.Drawing.Size (1125, 21);
            cboTests.TabIndex = 1;
            cboTests.SelectedIndexChanged += cboTests_SelectedIndexChanged;
            // 
            // lbl4
            // 
            lbl4.BackColor = System.Drawing.Color.Transparent;
            lbl4.Font = new System.Drawing.Font ("Segoe UI", 9F);
            lbl4.Location = new System.Drawing.Point (51, 60);
            lbl4.Name = "lbl4";
            lbl4.Size = new System.Drawing.Size (100, 20);
            lbl4.TabIndex = 30;
            lbl4.Text = "upper-Intermed";
            lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl1
            // 
            lbl1.BackColor = System.Drawing.Color.Transparent;
            lbl1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            lbl1.Location = new System.Drawing.Point (51, 162);
            lbl1.Name = "lbl1";
            lbl1.Size = new System.Drawing.Size (100, 20);
            lbl1.TabIndex = 31;
            lbl1.Text = "Elementary";
            lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl2
            // 
            lbl2.BackColor = System.Drawing.Color.Transparent;
            lbl2.Font = new System.Drawing.Font ("Segoe UI", 9F);
            lbl2.Location = new System.Drawing.Point (51, 129);
            lbl2.Name = "lbl2";
            lbl2.Size = new System.Drawing.Size (100, 20);
            lbl2.TabIndex = 32;
            lbl2.Text = "pre-Intermed";
            lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl3
            // 
            lbl3.BackColor = System.Drawing.Color.Transparent;
            lbl3.Font = new System.Drawing.Font ("Segoe UI", 9F);
            lbl3.Location = new System.Drawing.Point (51, 93);
            lbl3.Name = "lbl3";
            lbl3.Size = new System.Drawing.Size (100, 20);
            lbl3.TabIndex = 33;
            lbl3.Text = "Intermediate";
            lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl5
            // 
            lbl5.BackColor = System.Drawing.Color.Transparent;
            lbl5.Font = new System.Drawing.Font ("Segoe UI", 9F);
            lbl5.Location = new System.Drawing.Point (51, 25);
            lbl5.Name = "lbl5";
            lbl5.Size = new System.Drawing.Size (100, 20);
            lbl5.TabIndex = 34;
            lbl5.Text = "Upper level";
            lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new System.Drawing.Point (149, 5);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size (19, 15);
            lblTo.TabIndex = 35;
            lblTo.Text = "To";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new System.Drawing.Point (7, 5);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size (35, 15);
            lblFrom.TabIndex = 36;
            lblFrom.Text = "From";
            // 
            // lvl2
            // 
            lvl2.LargeChange = 1;
            lvl2.Location = new System.Drawing.Point (148, 22);
            lvl2.Maximum = 5;
            lvl2.Minimum = 1;
            lvl2.Name = "lvl2";
            lvl2.Orientation = System.Windows.Forms.Orientation.Vertical;
            lvl2.Size = new System.Drawing.Size (45, 165);
            lvl2.TabIndex = 28;
            lvl2.Value = 1;
            // 
            // lvl1
            // 
            lvl1.LargeChange = 1;
            lvl1.Location = new System.Drawing.Point (9, 22);
            lvl1.Maximum = 5;
            lvl1.Minimum = 1;
            lvl1.Name = "lvl1";
            lvl1.Orientation = System.Windows.Forms.Orientation.Vertical;
            lvl1.Size = new System.Drawing.Size (45, 165);
            lvl1.TabIndex = 29;
            lvl1.Value = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add (lbl4);
            panel2.Controls.Add (lbl1);
            panel2.Controls.Add (lbl2);
            panel2.Controls.Add (lbl3);
            panel2.Controls.Add (lbl5);
            panel2.Controls.Add (lblFrom);
            panel2.Controls.Add (lvl1);
            panel2.Controls.Add (lvl2);
            panel2.Controls.Add (lblTo);
            panel2.Location = new System.Drawing.Point (1031, 275);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size (197, 195);
            panel2.TabIndex = 37;
            // 
            // btn_Previous
            // 
            btn_Previous.Font = new System.Drawing.Font ("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            btn_Previous.ForeColor = System.Drawing.Color.IndianRed;
            btn_Previous.Location = new System.Drawing.Point (12, 4);
            btn_Previous.Name = "btn_Previous";
            btn_Previous.Size = new System.Drawing.Size (39, 23);
            btn_Previous.TabIndex = 38;
            btn_Previous.Text = "<";
            btn_Previous.UseVisualStyleBackColor = true;
            btn_Previous.Click += btn_Previous_Click;
            // 
            // btn_Next
            // 
            btn_Next.Font = new System.Drawing.Font ("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            btn_Next.ForeColor = System.Drawing.Color.IndianRed;
            btn_Next.Location = new System.Drawing.Point (1188, 4);
            btn_Next.Name = "btn_Next";
            btn_Next.Size = new System.Drawing.Size (39, 23);
            btn_Next.TabIndex = 39;
            btn_Next.Text = ">";
            btn_Next.UseVisualStyleBackColor = true;
            btn_Next.Click += btn_Next_Click;
            // 
            // frmTest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ClientSize = new System.Drawing.Size (1239, 545);
            ContextMenuStrip = contextMenuStrip1;
            ControlBox = false;
            Controls.Add (btn_Next);
            Controls.Add (btn_Previous);
            Controls.Add (panel2);
            Controls.Add (cboTests);
            Controls.Add (chkDblClick2Paste);
            Controls.Add (panel1);
            Controls.Add (lstTopics);
            Controls.Add (gridOptions);
            Controls.Add (groupBox1);
            Controls.Add (txtTest);
            Controls.Add (chkTestRTL);
            Controls.Add (label2);
            Controls.Add (label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmTest";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Test";
            Load += frmTest_Load;
            KeyDown += frmTest_KeyDown;
            contextMenuStrip1.ResumeLayout (false);
            groupBox1.ResumeLayout (false);
            groupBox1.PerformLayout ();
            ((System.ComponentModel.ISupportInitialize) gridOptions).EndInit ();
            contextMenuStrip2.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) lvl2).EndInit ();
            ((System.ComponentModel.ISupportInitialize) lvl1).EndInit ();
            panel2.ResumeLayout (false);
            panel2.PerformLayout ();
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.RadioButton radio4;
        private System.Windows.Forms.RadioButton radio2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.ListBox lstTopics;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu_Exit;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Menu2_AddOption;
        private System.Windows.Forms.ToolStripMenuItem Menu2_EditOption;
        private System.Windows.Forms.ToolStripMenuItem Menu2_DeleteOption;
        private System.Windows.Forms.CheckBox chkOptionsRTL;
        private System.Windows.Forms.CheckBox chkTestRTL;
        private System.Windows.Forms.RadioButton radio5;
        private System.Windows.Forms.RadioButton radio3;
        private System.Windows.Forms.CheckBox chkDblClick2Paste;
        private System.Windows.Forms.ComboBox cboTests;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TrackBar lvl2;
        private System.Windows.Forms.TrackBar lvl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Next;
        }
    }