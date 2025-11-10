namespace eLib.Forms
    {
    partial class frmCourseExamTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle ();
            contextMenu1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu1_NewCourse = new System.Windows.Forms.ToolStripMenuItem ();
            Menu1_NewExam = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator ();
            Menu1_Edit = new System.Windows.Forms.ToolStripMenuItem ();
            Menu1_Delete = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator ();
            Menu1_MakeExamSheet = new System.Windows.Forms.ToolStripMenuItem ();
            Menu1_Students = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator ();
            Menu1_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            lstTests = new System.Windows.Forms.ListBox ();
            contextMenuTests = new System.Windows.Forms.ContextMenuStrip (components);
            Menu2_AuoSelectTests = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_NewTest = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_EditTest = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator ();
            Menu2_DeleteTest = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_DeleteAllTests = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator ();
            Menu2_ImportTests = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_txtSearch = new System.Windows.Forms.ToolStripTextBox ();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator ();
            Menu2_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            lblExit = new System.Windows.Forms.Label ();
            lblTree = new System.Windows.Forms.Label ();
            lblTopics = new System.Windows.Forms.Label ();
            lblTests = new System.Windows.Forms.Label ();
            panel1 = new System.Windows.Forms.Panel ();
            lblExamSheets = new System.Windows.Forms.Label ();
            TreeA = new System.Windows.Forms.TreeView ();
            GridTopics = new System.Windows.Forms.DataGridView ();
            GridOptions = new System.Windows.Forms.DataGridView ();
            chkTestsRTL = new System.Windows.Forms.CheckBox ();
            lblTrainingExam = new System.Windows.Forms.Label ();
            chkShowOptions = new System.Windows.Forms.CheckBox ();
            btnShowOptions = new System.Windows.Forms.Button ();
            txtCmd = new System.Windows.Forms.TextBox ();
            lblSearch = new System.Windows.Forms.Label ();
            chkShowTests = new System.Windows.Forms.CheckBox ();
            contextMenu1.SuspendLayout ();
            contextMenuTests.SuspendLayout ();
            panel1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridTopics).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) GridOptions).BeginInit ();
            SuspendLayout ();
            // 
            // contextMenu1
            // 
            contextMenu1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu1_NewCourse, Menu1_NewExam, toolStripMenuItem3, Menu1_Edit, Menu1_Delete, toolStripMenuItem1, Menu1_MakeExamSheet, Menu1_Students, toolStripMenuItem5, Menu1_Exit });
            contextMenu1.Name = "contextMenu1";
            contextMenu1.Size = new System.Drawing.Size (169, 176);
            // 
            // Menu1_NewCourse
            // 
            Menu1_NewCourse.Name = "Menu1_NewCourse";
            Menu1_NewCourse.Size = new System.Drawing.Size (168, 22);
            Menu1_NewCourse.Text = "+ New Course";
            Menu1_NewCourse.Click += Menu1_NewCourse_Click;
            // 
            // Menu1_NewExam
            // 
            Menu1_NewExam.Name = "Menu1_NewExam";
            Menu1_NewExam.Size = new System.Drawing.Size (168, 22);
            Menu1_NewExam.Text = "+ New Exam";
            Menu1_NewExam.Click += Menu1_NewExam_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size (165, 6);
            // 
            // Menu1_Edit
            // 
            Menu1_Edit.Font = new System.Drawing.Font ("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            Menu1_Edit.Name = "Menu1_Edit";
            Menu1_Edit.Size = new System.Drawing.Size (168, 22);
            Menu1_Edit.Text = "Edit ...";
            Menu1_Edit.Click += Menu1_Edit_Click;
            // 
            // Menu1_Delete
            // 
            Menu1_Delete.ForeColor = System.Drawing.Color.IndianRed;
            Menu1_Delete.Name = "Menu1_Delete";
            Menu1_Delete.Size = new System.Drawing.Size (168, 22);
            Menu1_Delete.Text = "Delete";
            Menu1_Delete.Click += Menu1_Delete_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size (165, 6);
            // 
            // Menu1_MakeExamSheet
            // 
            Menu1_MakeExamSheet.Font = new System.Drawing.Font ("Segoe UI", 9F);
            Menu1_MakeExamSheet.Name = "Menu1_MakeExamSheet";
            Menu1_MakeExamSheet.Size = new System.Drawing.Size (168, 22);
            Menu1_MakeExamSheet.Text = "Exam Students";
            Menu1_MakeExamSheet.Click += Menu1_MakeExamSheet_Click;
            // 
            // Menu1_Students
            // 
            Menu1_Students.Name = "Menu1_Students";
            Menu1_Students.Size = new System.Drawing.Size (168, 22);
            Menu1_Students.Text = "Student Exams";
            Menu1_Students.Click += Menu1_Students_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new System.Drawing.Size (165, 6);
            // 
            // Menu1_Exit
            // 
            Menu1_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu1_Exit.Name = "Menu1_Exit";
            Menu1_Exit.Size = new System.Drawing.Size (168, 22);
            Menu1_Exit.Text = "Exit";
            Menu1_Exit.Click += Menu1_Exit_Click;
            // 
            // lstTests
            // 
            lstTests.BackColor = System.Drawing.Color.WhiteSmoke;
            lstTests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstTests.ContextMenuStrip = contextMenuTests;
            lstTests.Font = new System.Drawing.Font ("Segoe UI", 10F);
            lstTests.FormattingEnabled = true;
            lstTests.Location = new System.Drawing.Point (274, 137);
            lstTests.Name = "lstTests";
            lstTests.Size = new System.Drawing.Size (936, 255);
            lstTests.TabIndex = 3;
            lstTests.SelectedIndexChanged += lstTests_SelectedIndexChanged;
            lstTests.DragDrop += lstTests_DragDrop;
            lstTests.DragEnter += lstTests_DragEnter;
            lstTests.DoubleClick += lstTests_DoubleClick;
            // 
            // contextMenuTests
            // 
            contextMenuTests.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu2_AuoSelectTests, Menu2_NewTest, Menu2_EditTest, toolStripMenuItem4, Menu2_DeleteTest, Menu2_DeleteAllTests, toolStripMenuItem2, Menu2_ImportTests, Menu2_txtSearch, toolStripMenuItem6, Menu2_Exit });
            contextMenuTests.Name = "contextMenuTests";
            contextMenuTests.Size = new System.Drawing.Size (261, 201);
            // 
            // Menu2_AuoSelectTests
            // 
            Menu2_AuoSelectTests.Name = "Menu2_AuoSelectTests";
            Menu2_AuoSelectTests.Size = new System.Drawing.Size (260, 22);
            Menu2_AuoSelectTests.Text = "Random Draw Tests";
            Menu2_AuoSelectTests.Click += Menu2_AuoSelectTests_Click;
            // 
            // Menu2_NewTest
            // 
            Menu2_NewTest.Name = "Menu2_NewTest";
            Menu2_NewTest.Size = new System.Drawing.Size (260, 22);
            Menu2_NewTest.Text = "Add Tests Manually";
            Menu2_NewTest.Click += Menu2_NewTest_Click;
            // 
            // Menu2_EditTest
            // 
            Menu2_EditTest.Font = new System.Drawing.Font ("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            Menu2_EditTest.Name = "Menu2_EditTest";
            Menu2_EditTest.Size = new System.Drawing.Size (260, 22);
            Menu2_EditTest.Text = "Edit...";
            Menu2_EditTest.Click += Menu2_EditTest_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size (257, 6);
            // 
            // Menu2_DeleteTest
            // 
            Menu2_DeleteTest.Name = "Menu2_DeleteTest";
            Menu2_DeleteTest.Size = new System.Drawing.Size (260, 22);
            Menu2_DeleteTest.Text = "Remove";
            Menu2_DeleteTest.Click += Menu2_DeleteTest_Click;
            // 
            // Menu2_DeleteAllTests
            // 
            Menu2_DeleteAllTests.Name = "Menu2_DeleteAllTests";
            Menu2_DeleteAllTests.Size = new System.Drawing.Size (260, 22);
            Menu2_DeleteAllTests.Text = "Remove all";
            Menu2_DeleteAllTests.Click += Menu2_DeleteAllTests_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size (257, 6);
            // 
            // Menu2_ImportTests
            // 
            Menu2_ImportTests.Name = "Menu2_ImportTests";
            Menu2_ImportTests.Size = new System.Drawing.Size (260, 22);
            Menu2_ImportTests.Text = "Import";
            Menu2_ImportTests.Click += Menu2_ImportTests_Click;
            // 
            // Menu2_txtSearch
            // 
            Menu2_txtSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            Menu2_txtSearch.Name = "Menu2_txtSearch";
            Menu2_txtSearch.Size = new System.Drawing.Size (200, 23);
            Menu2_txtSearch.KeyDown += Menu2_txtSearch_KeyDown;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new System.Drawing.Size (257, 6);
            // 
            // Menu2_Exit
            // 
            Menu2_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu2_Exit.Name = "Menu2_Exit";
            Menu2_Exit.Size = new System.Drawing.Size (260, 22);
            Menu2_Exit.Text = "Exit";
            Menu2_Exit.Click += Menu2_Exit_Click_1;
            // 
            // lblExit
            // 
            lblExit.BackColor = System.Drawing.Color.LightCoral;
            lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            lblExit.Font = new System.Drawing.Font ("Consolas", 10F);
            lblExit.ForeColor = System.Drawing.Color.White;
            lblExit.Location = new System.Drawing.Point (1061, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (158, 18);
            lblExit.TabIndex = 10;
            lblExit.Text = "Exit";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // lblTree
            // 
            lblTree.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblTree.Font = new System.Drawing.Font ("Segoe UI", 10F);
            lblTree.ForeColor = System.Drawing.Color.IndianRed;
            lblTree.Location = new System.Drawing.Point (10, 3);
            lblTree.Name = "lblTree";
            lblTree.Size = new System.Drawing.Size (256, 19);
            lblTree.TabIndex = 147;
            lblTree.Text = "Courses and Exams";
            lblTree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTopics
            // 
            lblTopics.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblTopics.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lblTopics.ForeColor = System.Drawing.SystemColors.HotTrack;
            lblTopics.Location = new System.Drawing.Point (618, 4);
            lblTopics.Name = "lblTopics";
            lblTopics.Size = new System.Drawing.Size (247, 20);
            lblTopics.TabIndex = 148;
            lblTopics.Text = "Topics";
            lblTopics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTopics.Click += lblTopics_Click;
            // 
            // lblTests
            // 
            lblTests.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblTests.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lblTests.ForeColor = System.Drawing.SystemColors.HotTrack;
            lblTests.Location = new System.Drawing.Point (342, 115);
            lblTests.Name = "lblTests";
            lblTests.Size = new System.Drawing.Size (801, 20);
            lblTests.TabIndex = 149;
            lblTests.Text = "Tests";
            lblTests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTests.Click += lblTests_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblExamSheets);
            panel1.Controls.Add (lblExit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 593);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (1219, 18);
            panel1.TabIndex = 150;
            // 
            // lblExamSheets
            // 
            lblExamSheets.BackColor = System.Drawing.Color.CornflowerBlue;
            lblExamSheets.Dock = System.Windows.Forms.DockStyle.Left;
            lblExamSheets.Font = new System.Drawing.Font ("Consolas", 10F);
            lblExamSheets.ForeColor = System.Drawing.Color.White;
            lblExamSheets.Location = new System.Drawing.Point (0, 0);
            lblExamSheets.Name = "lblExamSheets";
            lblExamSheets.Size = new System.Drawing.Size (158, 18);
            lblExamSheets.TabIndex = 11;
            lblExamSheets.Text = "Students";
            lblExamSheets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExamSheets.Visible = false;
            lblExamSheets.Click += lblExamSheets_Click;
            // 
            // TreeA
            // 
            TreeA.BackColor = System.Drawing.SystemColors.ButtonFace;
            TreeA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TreeA.ContextMenuStrip = contextMenu1;
            TreeA.Location = new System.Drawing.Point (8, 27);
            TreeA.Name = "TreeA";
            TreeA.Size = new System.Drawing.Size (258, 533);
            TreeA.TabIndex = 1;
            TreeA.AfterSelect += TreeA_AfterSelect;
            TreeA.DoubleClick += TreeA_DoubleClick;
            // 
            // GridTopics
            // 
            GridTopics.AllowDrop = true;
            GridTopics.AllowUserToAddRows = false;
            GridTopics.AllowUserToDeleteRows = false;
            GridTopics.AllowUserToResizeColumns = false;
            GridTopics.AllowUserToResizeRows = false;
            GridTopics.BackgroundColor = System.Drawing.Color.FromArgb (  242,   242,   242);
            GridTopics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridTopics.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb (  242,   242,   242);
            dataGridViewCellStyle1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb (  242,   242,   242);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridTopics.DefaultCellStyle = dataGridViewCellStyle1;
            GridTopics.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridTopics.GridColor = System.Drawing.Color.FromArgb (  242,   242,   242);
            GridTopics.Location = new System.Drawing.Point (274, 27);
            GridTopics.MultiSelect = false;
            GridTopics.Name = "GridTopics";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            GridTopics.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            GridTopics.RowHeadersVisible = false;
            GridTopics.RowHeadersWidth = 20;
            GridTopics.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridTopics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            GridTopics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            GridTopics.Size = new System.Drawing.Size (936, 82);
            GridTopics.TabIndex = 173;
            GridTopics.CellClick += GridTopics_CellClick;
            // 
            // GridOptions
            // 
            GridOptions.AllowDrop = true;
            GridOptions.AllowUserToAddRows = false;
            GridOptions.AllowUserToDeleteRows = false;
            GridOptions.AllowUserToResizeColumns = false;
            GridOptions.AllowUserToResizeRows = false;
            GridOptions.BackgroundColor = System.Drawing.Color.FromArgb (  242,   242,   242);
            GridOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridOptions.ColumnHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb (  242,   242,   242);
            dataGridViewCellStyle3.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb (  236,   236,   236);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridOptions.DefaultCellStyle = dataGridViewCellStyle3;
            GridOptions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridOptions.GridColor = System.Drawing.Color.FromArgb (  242,   242,   242);
            GridOptions.Location = new System.Drawing.Point (274, 430);
            GridOptions.MultiSelect = false;
            GridOptions.Name = "GridOptions";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            GridOptions.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            GridOptions.RowHeadersVisible = false;
            GridOptions.RowHeadersWidth = 20;
            GridOptions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridOptions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            GridOptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            GridOptions.Size = new System.Drawing.Size (936, 130);
            GridOptions.TabIndex = 174;
            GridOptions.CellDoubleClick += GridOptions_CellDoubleClick;
            // 
            // chkTestsRTL
            // 
            chkTestsRTL.AutoSize = true;
            chkTestsRTL.Location = new System.Drawing.Point (1166, 118);
            chkTestsRTL.Name = "chkTestsRTL";
            chkTestsRTL.Size = new System.Drawing.Size (44, 19);
            chkTestsRTL.TabIndex = 175;
            chkTestsRTL.Text = "RTL";
            chkTestsRTL.UseVisualStyleBackColor = true;
            chkTestsRTL.CheckedChanged += chkTestsRTL_CheckedChanged;
            // 
            // lblTrainingExam
            // 
            lblTrainingExam.BackColor = System.Drawing.Color.LightCoral;
            lblTrainingExam.Font = new System.Drawing.Font ("Segoe UI", 8F);
            lblTrainingExam.ForeColor = System.Drawing.Color.White;
            lblTrainingExam.Location = new System.Drawing.Point (1092, 9);
            lblTrainingExam.Name = "lblTrainingExam";
            lblTrainingExam.Size = new System.Drawing.Size (117, 14);
            lblTrainingExam.TabIndex = 177;
            lblTrainingExam.Text = "Training Exam";
            lblTrainingExam.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lblTrainingExam.Visible = false;
            // 
            // chkShowOptions
            // 
            chkShowOptions.AutoSize = true;
            chkShowOptions.Location = new System.Drawing.Point (680, 407);
            chkShowOptions.Name = "chkShowOptions";
            chkShowOptions.Size = new System.Drawing.Size (15, 14);
            chkShowOptions.TabIndex = 179;
            chkShowOptions.UseVisualStyleBackColor = true;
            chkShowOptions.CheckedChanged += chkShowOptions_CheckedChanged;
            // 
            // btnShowOptions
            // 
            btnShowOptions.ForeColor = System.Drawing.Color.IndianRed;
            btnShowOptions.Location = new System.Drawing.Point (667, 402);
            btnShowOptions.Name = "btnShowOptions";
            btnShowOptions.Size = new System.Drawing.Size (149, 24);
            btnShowOptions.TabIndex = 178;
            btnShowOptions.Text = "Show Options";
            btnShowOptions.UseVisualStyleBackColor = true;
            btnShowOptions.Click += btnShowOptions_Click;
            // 
            // txtCmd
            // 
            txtCmd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            txtCmd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtCmd.Font = new System.Drawing.Font ("Segoe UI", 10F);
            txtCmd.ForeColor = System.Drawing.Color.Teal;
            txtCmd.Location = new System.Drawing.Point (274, 564);
            txtCmd.Name = "txtCmd";
            txtCmd.Size = new System.Drawing.Size (932, 18);
            txtCmd.TabIndex = 0;
            txtCmd.TextChanged += txtCmd_TextChanged;
            txtCmd.KeyDown += txtCmd_KeyDown;
            // 
            // lblSearch
            // 
            lblSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblSearch.Font = new System.Drawing.Font ("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSearch.ForeColor = System.Drawing.Color.SteelBlue;
            lblSearch.Location = new System.Drawing.Point (218, 566);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size (50, 15);
            lblSearch.TabIndex = 181;
            lblSearch.Text = "cmd >";
            lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShowTests
            // 
            chkShowTests.AutoSize = true;
            chkShowTests.Checked = true;
            chkShowTests.CheckState = System.Windows.Forms.CheckState.Checked;
            chkShowTests.Location = new System.Drawing.Point (274, 5);
            chkShowTests.Name = "chkShowTests";
            chkShowTests.Size = new System.Drawing.Size (211, 19);
            chkShowTests.TabIndex = 183;
            chkShowTests.Text = "Auto Show Course-Tests (TestBank)";
            chkShowTests.UseVisualStyleBackColor = true;
            chkShowTests.CheckedChanged += chkShowTests_CheckedChanged;
            // 
            // frmCourseExamTest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size (1219, 611);
            Controls.Add (txtCmd);
            Controls.Add (lblSearch);
            Controls.Add (chkShowOptions);
            Controls.Add (btnShowOptions);
            Controls.Add (lblTrainingExam);
            Controls.Add (GridOptions);
            Controls.Add (GridTopics);
            Controls.Add (TreeA);
            Controls.Add (panel1);
            Controls.Add (lstTests);
            Controls.Add (lblTests);
            Controls.Add (lblTopics);
            Controls.Add (lblTree);
            Controls.Add (chkTestsRTL);
            Controls.Add (chkShowTests);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "frmCourseExamTest";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Course-Exam-Test";
            FormClosing += frmCourseExamTest_FormClosing;
            Load += frmCourseExamTest_Load;
            KeyDown += frmCourseExamTest_KeyDown;
            contextMenu1.ResumeLayout (false);
            contextMenuTests.ResumeLayout (false);
            contextMenuTests.PerformLayout ();
            panel1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridTopics).EndInit ();
            ((System.ComponentModel.ISupportInitialize) GridOptions).EndInit ();
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion
        private System.Windows.Forms.ListBox lstTests;
        private System.Windows.Forms.ContextMenuStrip contextMenu1;
        private System.Windows.Forms.ContextMenuStrip contextMenu2;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Delete;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Edit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Exit;
        private System.Windows.Forms.Label lblExit;
        internal System.Windows.Forms.Label lblTree;
        internal System.Windows.Forms.Label lblTopics;
        internal System.Windows.Forms.Label lblTests;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem Menu2_MakeExamSheet;
        private System.Windows.Forms.TreeView TreeA;
        internal System.Windows.Forms.DataGridView GridTopics;
        internal System.Windows.Forms.DataGridView GridOptions;
        private System.Windows.Forms.ToolStripMenuItem Menu1_MakeExamSheet;
        private System.Windows.Forms.ContextMenuStrip contextMenuTests;
        private System.Windows.Forms.ToolStripMenuItem Menu2_NewTest;
        private System.Windows.Forms.ToolStripMenuItem Menu2_EditTest;
        private System.Windows.Forms.ToolStripMenuItem Menu2_DeleteTest;
        private System.Windows.Forms.ToolStripMenuItem Menu1_NewCourse;
        private System.Windows.Forms.ToolStripMenuItem Menu1_NewExam;
        private System.Windows.Forms.CheckBox chkTestsRTL;
        private System.Windows.Forms.ToolStripMenuItem Menu2_ImportTests;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem Menu2_AuoSelectTests;
        private System.Windows.Forms.Label lblTrainingExam;
        private System.Windows.Forms.Label lblExamSheets;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Students;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem Menu2_DeleteAllTests;
        private System.Windows.Forms.CheckBox chkShowOptions;
        private System.Windows.Forms.Button btnShowOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem Menu2_Exit;
        internal System.Windows.Forms.TextBox txtCmd;
        internal System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.CheckBox chkShowTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox Menu2_txtSearch;
        }
    }