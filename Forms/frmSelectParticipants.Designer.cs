namespace eLib.Forms
    {
    partial class frmSelectStudents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle ();
            panel1 = new System.Windows.Forms.Panel ();
            lblCancel = new System.Windows.Forms.Label ();
            cboEntries = new System.Windows.Forms.ComboBox ();
            Grid1 = new System.Windows.Forms.DataGridView ();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu1_AddNewStudent = new System.Windows.Forms.ToolStripMenuItem ();
            Menu1_EditStudent = new System.Windows.Forms.ToolStripMenuItem ();
            Menu1_SelectAll = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator ();
            Menu1_StudentExams = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator ();
            Menu1_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            Grid2 = new System.Windows.Forms.DataGridView ();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu2_RemoveAllStudents = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator ();
            Menu2_PrintoutPasswords = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_PrintoutStudentRecord = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_PrintoutExamsheets = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_PrintoutMarks = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator ();
            Menu2_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            btnAddNewEntry = new System.Windows.Forms.Button ();
            btn_EditStudent = new System.Windows.Forms.Button ();
            btn_AddNewStudent = new System.Windows.Forms.Button ();
            lblExamName = new System.Windows.Forms.Label ();
            btnEditEntry = new System.Windows.Forms.Button ();
            lblTrainingExam = new System.Windows.Forms.Label ();
            chkEnableDoubleClick = new System.Windows.Forms.CheckBox ();
            btnDeleteEntry = new System.Windows.Forms.Button ();
            btn_DeleteStudent = new System.Windows.Forms.Button ();
            btnAddStudentToExam = new System.Windows.Forms.Button ();
            chkDoubleClickToDelete = new System.Windows.Forms.CheckBox ();
            label1 = new System.Windows.Forms.Label ();
            progressBar1 = new System.Windows.Forms.ProgressBar ();
            panel1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) Grid1).BeginInit ();
            contextMenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) Grid2).BeginInit ();
            contextMenuStrip2.SuspendLayout ();
            SuspendLayout ();
            // 
            // panel1
            // 
            panel1.Controls.Add (lblCancel);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 507);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (925, 20);
            panel1.TabIndex = 12;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            lblCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblCancel.Font = new System.Drawing.Font ("Consolas", 10F);
            lblCancel.ForeColor = System.Drawing.Color.IndianRed;
            lblCancel.Location = new System.Drawing.Point (0, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new System.Drawing.Size (925, 20);
            lblCancel.TabIndex = 9;
            lblCancel.Text = "Back";
            lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // cboEntries
            // 
            cboEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEntries.FormattingEnabled = true;
            cboEntries.Location = new System.Drawing.Point (38, 33);
            cboEntries.Name = "cboEntries";
            cboEntries.Size = new System.Drawing.Size (255, 21);
            cboEntries.TabIndex = 13;
            cboEntries.SelectedIndexChanged += cboEntries_SelectedIndexChanged;
            // 
            // Grid1
            // 
            Grid1.AllowUserToAddRows = false;
            Grid1.AllowUserToDeleteRows = false;
            Grid1.AllowUserToOrderColumns = true;
            Grid1.AllowUserToResizeColumns = false;
            Grid1.AllowUserToResizeRows = false;
            Grid1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            Grid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid1.ColumnHeadersVisible = false;
            Grid1.ContextMenuStrip = contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font ("Consolas", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            Grid1.DefaultCellStyle = dataGridViewCellStyle3;
            Grid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            Grid1.GridColor = System.Drawing.Color.WhiteSmoke;
            Grid1.Location = new System.Drawing.Point (38, 58);
            Grid1.Name = "Grid1";
            Grid1.RowHeadersVisible = false;
            Grid1.Size = new System.Drawing.Size (351, 424);
            Grid1.TabIndex = 14;
            Grid1.CellDoubleClick += Grid1_CellDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu1_AddNewStudent, Menu1_EditStudent, Menu1_SelectAll, toolStripMenuItem1, Menu1_StudentExams, toolStripMenuItem5, Menu1_Exit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size (178, 126);
            // 
            // Menu1_AddNewStudent
            // 
            Menu1_AddNewStudent.Name = "Menu1_AddNewStudent";
            Menu1_AddNewStudent.Size = new System.Drawing.Size (177, 22);
            Menu1_AddNewStudent.Text = "New Student...";
            Menu1_AddNewStudent.Click += Menu1_AddNewStudent_Click;
            // 
            // Menu1_EditStudent
            // 
            Menu1_EditStudent.Name = "Menu1_EditStudent";
            Menu1_EditStudent.Size = new System.Drawing.Size (177, 22);
            Menu1_EditStudent.Text = "Edit...";
            Menu1_EditStudent.Click += Menu1_EditStudent_Click;
            // 
            // Menu1_SelectAll
            // 
            Menu1_SelectAll.Name = "Menu1_SelectAll";
            Menu1_SelectAll.Size = new System.Drawing.Size (177, 22);
            Menu1_SelectAll.Text = "Select All";
            Menu1_SelectAll.Click += Menu1_SelectAll_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size (174, 6);
            // 
            // Menu1_StudentExams
            // 
            Menu1_StudentExams.Name = "Menu1_StudentExams";
            Menu1_StudentExams.Size = new System.Drawing.Size (177, 22);
            Menu1_StudentExams.Text = "Student Exams...";
            Menu1_StudentExams.Click += Menu1_StudentExams_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new System.Drawing.Size (174, 6);
            // 
            // Menu1_Exit
            // 
            Menu1_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu1_Exit.Name = "Menu1_Exit";
            Menu1_Exit.Size = new System.Drawing.Size (177, 22);
            Menu1_Exit.Text = "Back / Exit";
            Menu1_Exit.Click += Menu1_Exit_Click;
            // 
            // Grid2
            // 
            Grid2.AllowUserToAddRows = false;
            Grid2.AllowUserToDeleteRows = false;
            Grid2.AllowUserToOrderColumns = true;
            Grid2.AllowUserToResizeColumns = false;
            Grid2.AllowUserToResizeRows = false;
            Grid2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            Grid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid2.ColumnHeadersVisible = false;
            Grid2.ContextMenuStrip = contextMenuStrip2;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font ("Consolas", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            Grid2.DefaultCellStyle = dataGridViewCellStyle1;
            Grid2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            Grid2.GridColor = System.Drawing.Color.WhiteSmoke;
            Grid2.Location = new System.Drawing.Point (427, 58);
            Grid2.Name = "Grid2";
            Grid2.RowHeadersVisible = false;
            Grid2.Size = new System.Drawing.Size (496, 424);
            Grid2.TabIndex = 15;
            Grid2.CellDoubleClick += Grid2_CellDoubleClick;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu2_RemoveAllStudents, toolStripMenuItem2, Menu2_PrintoutPasswords, Menu2_PrintoutStudentRecord, Menu2_PrintoutExamsheets, Menu2_PrintoutMarks, toolStripMenuItem3, Menu2_Exit });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size (161, 148);
            // 
            // Menu2_RemoveAllStudents
            // 
            Menu2_RemoveAllStudents.Name = "Menu2_RemoveAllStudents";
            Menu2_RemoveAllStudents.Size = new System.Drawing.Size (160, 22);
            Menu2_RemoveAllStudents.Text = "Remove All";
            Menu2_RemoveAllStudents.Click += Menu2_RemoveAllStudents_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size (157, 6);
            // 
            // Menu2_PrintoutPasswords
            // 
            Menu2_PrintoutPasswords.Name = "Menu2_PrintoutPasswords";
            Menu2_PrintoutPasswords.Size = new System.Drawing.Size (160, 22);
            Menu2_PrintoutPasswords.Text = "Passwords";
            Menu2_PrintoutPasswords.Click += Menu2_PrintoutPasswords_Click;
            // 
            // Menu2_PrintoutStudentRecord
            // 
            Menu2_PrintoutStudentRecord.Name = "Menu2_PrintoutStudentRecord";
            Menu2_PrintoutStudentRecord.Size = new System.Drawing.Size (160, 22);
            Menu2_PrintoutStudentRecord.Text = "Exam Record";
            Menu2_PrintoutStudentRecord.Click += Menu2_PrintoutStudentRecord_Click;
            // 
            // Menu2_PrintoutExamsheets
            // 
            Menu2_PrintoutExamsheets.Name = "Menu2_PrintoutExamsheets";
            Menu2_PrintoutExamsheets.Size = new System.Drawing.Size (160, 22);
            Menu2_PrintoutExamsheets.Text = "Raw Exam Sheet";
            Menu2_PrintoutExamsheets.Click += Menu2_PrintoutExamsheets_Click;
            // 
            // Menu2_PrintoutMarks
            // 
            Menu2_PrintoutMarks.Name = "Menu2_PrintoutMarks";
            Menu2_PrintoutMarks.Size = new System.Drawing.Size (160, 22);
            Menu2_PrintoutMarks.Text = "Marks";
            Menu2_PrintoutMarks.Click += Menu2_PrintoutMarks_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size (157, 6);
            // 
            // Menu2_Exit
            // 
            Menu2_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu2_Exit.Name = "Menu2_Exit";
            Menu2_Exit.Size = new System.Drawing.Size (160, 22);
            Menu2_Exit.Text = "Cancel / Exit";
            Menu2_Exit.Click += Menu2_Exit_Click;
            // 
            // btnAddNewEntry
            // 
            btnAddNewEntry.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnAddNewEntry.Location = new System.Drawing.Point (298, 31);
            btnAddNewEntry.Name = "btnAddNewEntry";
            btnAddNewEntry.Size = new System.Drawing.Size (26, 22);
            btnAddNewEntry.TabIndex = 25;
            btnAddNewEntry.Text = "+";
            btnAddNewEntry.UseVisualStyleBackColor = true;
            btnAddNewEntry.Click += btnAddNewEntry_Click;
            // 
            // btn_EditStudent
            // 
            btn_EditStudent.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btn_EditStudent.Location = new System.Drawing.Point (6, 159);
            btn_EditStudent.Name = "btn_EditStudent";
            btn_EditStudent.Size = new System.Drawing.Size (26, 32);
            btn_EditStudent.TabIndex = 28;
            btn_EditStudent.Text = "I";
            btn_EditStudent.UseVisualStyleBackColor = true;
            btn_EditStudent.Click += btn_EditStudent_Click;
            // 
            // btn_AddNewStudent
            // 
            btn_AddNewStudent.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btn_AddNewStudent.Location = new System.Drawing.Point (6, 83);
            btn_AddNewStudent.Name = "btn_AddNewStudent";
            btn_AddNewStudent.Size = new System.Drawing.Size (26, 32);
            btn_AddNewStudent.TabIndex = 27;
            btn_AddNewStudent.Text = "+";
            btn_AddNewStudent.UseVisualStyleBackColor = true;
            btn_AddNewStudent.Click += btn_AddNewStudent_Click;
            // 
            // lblExamName
            // 
            lblExamName.BackColor = System.Drawing.SystemColors.Window;
            lblExamName.Font = new System.Drawing.Font ("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblExamName.ForeColor = System.Drawing.Color.IndianRed;
            lblExamName.Location = new System.Drawing.Point (427, 32);
            lblExamName.Name = "lblExamName";
            lblExamName.Size = new System.Drawing.Size (496, 17);
            lblExamName.TabIndex = 13;
            lblExamName.Text = "-";
            lblExamName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExamName.Click += lblExamName_Click;
            // 
            // btnEditEntry
            // 
            btnEditEntry.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnEditEntry.Location = new System.Drawing.Point (362, 31);
            btnEditEntry.Name = "btnEditEntry";
            btnEditEntry.Size = new System.Drawing.Size (26, 22);
            btnEditEntry.TabIndex = 30;
            btnEditEntry.Text = "I";
            btnEditEntry.UseVisualStyleBackColor = true;
            btnEditEntry.Click += btnEditEntry_Click;
            // 
            // lblTrainingExam
            // 
            lblTrainingExam.BackColor = System.Drawing.Color.LightCoral;
            lblTrainingExam.Dock = System.Windows.Forms.DockStyle.Top;
            lblTrainingExam.Font = new System.Drawing.Font ("Segoe UI", 8F);
            lblTrainingExam.ForeColor = System.Drawing.Color.White;
            lblTrainingExam.Location = new System.Drawing.Point (0, 0);
            lblTrainingExam.Name = "lblTrainingExam";
            lblTrainingExam.Size = new System.Drawing.Size (925, 12);
            lblTrainingExam.TabIndex = 31;
            lblTrainingExam.Text = "Training Exam";
            lblTrainingExam.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lblTrainingExam.Visible = false;
            lblTrainingExam.DoubleClick += lblTrainingExam_DoubleClick;
            // 
            // chkEnableDoubleClick
            // 
            chkEnableDoubleClick.AutoSize = true;
            chkEnableDoubleClick.ForeColor = System.Drawing.Color.RoyalBlue;
            chkEnableDoubleClick.Location = new System.Drawing.Point (38, 488);
            chkEnableDoubleClick.Name = "chkEnableDoubleClick";
            chkEnableDoubleClick.Size = new System.Drawing.Size (170, 17);
            chkEnableDoubleClick.TabIndex = 32;
            chkEnableDoubleClick.Text = "DoubleClick: Add to Exam";
            chkEnableDoubleClick.UseVisualStyleBackColor = true;
            // 
            // btnDeleteEntry
            // 
            btnDeleteEntry.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnDeleteEntry.Location = new System.Drawing.Point (330, 31);
            btnDeleteEntry.Name = "btnDeleteEntry";
            btnDeleteEntry.Size = new System.Drawing.Size (26, 22);
            btnDeleteEntry.TabIndex = 33;
            btnDeleteEntry.Text = "-";
            btnDeleteEntry.UseVisualStyleBackColor = true;
            btnDeleteEntry.Click += btnDeleteEntry_Click;
            // 
            // btn_DeleteStudent
            // 
            btn_DeleteStudent.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btn_DeleteStudent.Location = new System.Drawing.Point (6, 121);
            btn_DeleteStudent.Name = "btn_DeleteStudent";
            btn_DeleteStudent.Size = new System.Drawing.Size (26, 32);
            btn_DeleteStudent.TabIndex = 34;
            btn_DeleteStudent.Text = "-";
            btn_DeleteStudent.UseVisualStyleBackColor = true;
            btn_DeleteStudent.Click += btn_DeleteStudent_Click;
            // 
            // btnAddStudentToExam
            // 
            btnAddStudentToExam.Font = new System.Drawing.Font ("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            btnAddStudentToExam.Location = new System.Drawing.Point (395, 193);
            btnAddStudentToExam.Name = "btnAddStudentToExam";
            btnAddStudentToExam.Size = new System.Drawing.Size (26, 72);
            btnAddStudentToExam.TabIndex = 35;
            btnAddStudentToExam.Text = ">";
            btnAddStudentToExam.UseVisualStyleBackColor = true;
            btnAddStudentToExam.Click += btnAddStudentToExam_Click;
            // 
            // chkDoubleClickToDelete
            // 
            chkDoubleClickToDelete.AutoSize = true;
            chkDoubleClickToDelete.ForeColor = System.Drawing.Color.IndianRed;
            chkDoubleClickToDelete.Location = new System.Drawing.Point (801, 488);
            chkDoubleClickToDelete.Name = "chkDoubleClickToDelete";
            chkDoubleClickToDelete.Size = new System.Drawing.Size (122, 17);
            chkDoubleClickToDelete.TabIndex = 36;
            chkDoubleClickToDelete.Text = "DoubleClick: Del";
            chkDoubleClickToDelete.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.Window;
            label1.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point (38, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size (50, 15);
            label1.TabIndex = 37;
            label1.Text = "Group:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point (427, 488);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size (122, 10);
            progressBar1.TabIndex = 38;
            progressBar1.Visible = false;
            // 
            // frmSelectStudents
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size (925, 527);
            ControlBox = false;
            Controls.Add (progressBar1);
            Controls.Add (chkDoubleClickToDelete);
            Controls.Add (btnAddStudentToExam);
            Controls.Add (btn_DeleteStudent);
            Controls.Add (btnDeleteEntry);
            Controls.Add (btnEditEntry);
            Controls.Add (lblExamName);
            Controls.Add (btn_EditStudent);
            Controls.Add (btn_AddNewStudent);
            Controls.Add (btnAddNewEntry);
            Controls.Add (Grid2);
            Controls.Add (Grid1);
            Controls.Add (cboEntries);
            Controls.Add (panel1);
            Controls.Add (lblTrainingExam);
            Controls.Add (chkEnableDoubleClick);
            Controls.Add (label1);
            Font = new System.Drawing.Font ("Consolas", 8.25F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelectStudents";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Select Students";
            Load += frmSelectStudents_Load;
            panel1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) Grid1).EndInit ();
            contextMenuStrip1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) Grid2).EndInit ();
            contextMenuStrip2.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.ComboBox cboEntries;
        private System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.DataGridView Grid2;
        private System.Windows.Forms.Label lblAddEntry;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu1_AddNewStudent;
        private System.Windows.Forms.ToolStripMenuItem Menu1_EditStudent;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Menu1_SelectAll;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Exit;
        private System.Windows.Forms.Button btnAddNewEntry;
        private System.Windows.Forms.Button btn_EditStudent;
        private System.Windows.Forms.Button btn_AddNewStudent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Menu2_RemoveAllStudents;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem Menu2_Exit;
        private System.Windows.Forms.Label lblExamName;
        private System.Windows.Forms.ToolStripMenuItem Menu2_PrintoutPasswords;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Menu2_PrintoutExamsheets;
        private System.Windows.Forms.ToolStripMenuItem Menu2_PrintoutMarks;
        private System.Windows.Forms.Button btnEditEntry;
        private System.Windows.Forms.ToolStripMenuItem Menu2_PrintoutStudentRecord;
        private System.Windows.Forms.Label lblTrainingExam;
        private System.Windows.Forms.ToolStripMenuItem Menu1_StudentExams;
        private System.Windows.Forms.CheckBox chkEnableDoubleClick;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btn_DeleteStudent;
        private System.Windows.Forms.Button btnAddStudentToExam;
        private System.Windows.Forms.CheckBox chkDoubleClickToDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        }
    }