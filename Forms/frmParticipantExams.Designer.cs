namespace eLib.Forms
    {
    partial class frmStudentExams
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
            panel1 = new System.Windows.Forms.Panel ();
            lblExit = new System.Windows.Forms.Label ();
            GridStudents = new System.Windows.Forms.DataGridView ();
            MenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu1_Passwords = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator ();
            Menu1_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            cboEntries = new System.Windows.Forms.ComboBox ();
            GridStudentExams = new System.Windows.Forms.DataGridView ();
            MenuStrip2 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu2_PrintoutExamSheet = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_PrintoutExamRecord = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator ();
            Menu2_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            btnEditEntry = new System.Windows.Forms.Button ();
            btn_EditStudent = new System.Windows.Forms.Button ();
            btn_AddNewStudent = new System.Windows.Forms.Button ();
            btnAddNewEntry = new System.Windows.Forms.Button ();
            btn_DeleteStudent = new System.Windows.Forms.Button ();
            btnDeleteEntry = new System.Windows.Forms.Button ();
            btnAddExamToStudent = new System.Windows.Forms.Button ();
            btnDeleteExam = new System.Windows.Forms.Button ();
            chkDoubleClickToDelete = new System.Windows.Forms.CheckBox ();
            panel1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridStudents).BeginInit ();
            MenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridStudentExams).BeginInit ();
            MenuStrip2.SuspendLayout ();
            SuspendLayout ();
            // 
            // panel1
            // 
            panel1.Controls.Add (lblExit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 517);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (1125, 20);
            panel1.TabIndex = 28;
            // 
            // lblExit
            // 
            lblExit.BackColor = System.Drawing.Color.WhiteSmoke;
            lblExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblExit.Font = new System.Drawing.Font ("Consolas", 10F);
            lblExit.ForeColor = System.Drawing.Color.IndianRed;
            lblExit.Location = new System.Drawing.Point (0, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (1125, 20);
            lblExit.TabIndex = 26;
            lblExit.Text = "Back";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // GridStudents
            // 
            GridStudents.AllowUserToAddRows = false;
            GridStudents.AllowUserToDeleteRows = false;
            GridStudents.AllowUserToOrderColumns = true;
            GridStudents.AllowUserToResizeColumns = false;
            GridStudents.AllowUserToResizeRows = false;
            GridStudents.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            GridStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridStudents.ColumnHeadersVisible = false;
            GridStudents.ContextMenuStrip = MenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridStudents.DefaultCellStyle = dataGridViewCellStyle1;
            GridStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridStudents.GridColor = System.Drawing.Color.WhiteSmoke;
            GridStudents.Location = new System.Drawing.Point (52, 44);
            GridStudents.Name = "GridStudents";
            GridStudents.RowHeadersVisible = false;
            GridStudents.Size = new System.Drawing.Size (283, 451);
            GridStudents.TabIndex = 29;
            GridStudents.CellClick += GridStudents_CellClick;
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu1_Passwords, toolStripMenuItem2, Menu1_Exit });
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new System.Drawing.Size (139, 54);
            // 
            // Menu1_Passwords
            // 
            Menu1_Passwords.Name = "Menu1_Passwords";
            Menu1_Passwords.Size = new System.Drawing.Size (138, 22);
            Menu1_Passwords.Text = "Passwords...";
            Menu1_Passwords.Click += Menu1_Passwords_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size (135, 6);
            // 
            // Menu1_Exit
            // 
            Menu1_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu1_Exit.Name = "Menu1_Exit";
            Menu1_Exit.Size = new System.Drawing.Size (138, 22);
            Menu1_Exit.Text = "Exit";
            Menu1_Exit.Click += Menu1_Exit_Click;
            // 
            // cboEntries
            // 
            cboEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEntries.FormattingEnabled = true;
            cboEntries.Location = new System.Drawing.Point (52, 12);
            cboEntries.Name = "cboEntries";
            cboEntries.Size = new System.Drawing.Size (193, 23);
            cboEntries.TabIndex = 28;
            cboEntries.SelectedIndexChanged += cboEntries_SelectedIndexChanged;
            // 
            // GridStudentExams
            // 
            GridStudentExams.AllowUserToAddRows = false;
            GridStudentExams.AllowUserToDeleteRows = false;
            GridStudentExams.AllowUserToOrderColumns = true;
            GridStudentExams.AllowUserToResizeColumns = false;
            GridStudentExams.AllowUserToResizeRows = false;
            GridStudentExams.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            GridStudentExams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridStudentExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridStudentExams.ContextMenuStrip = MenuStrip2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridStudentExams.DefaultCellStyle = dataGridViewCellStyle2;
            GridStudentExams.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridStudentExams.GridColor = System.Drawing.Color.WhiteSmoke;
            GridStudentExams.Location = new System.Drawing.Point (341, 44);
            GridStudentExams.Name = "GridStudentExams";
            GridStudentExams.RowHeadersVisible = false;
            GridStudentExams.Size = new System.Drawing.Size (780, 451);
            GridStudentExams.TabIndex = 30;
            GridStudentExams.CellContentDoubleClick += GridStudentExams_CellContentDoubleClick;
            // 
            // MenuStrip2
            // 
            MenuStrip2.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu2_PrintoutExamSheet, Menu2_PrintoutExamRecord, toolStripMenuItem1, Menu2_Exit });
            MenuStrip2.Name = "contextMenuStrip1";
            MenuStrip2.Size = new System.Drawing.Size (181, 76);
            // 
            // Menu2_PrintoutExamSheet
            // 
            Menu2_PrintoutExamSheet.Name = "Menu2_PrintoutExamSheet";
            Menu2_PrintoutExamSheet.Size = new System.Drawing.Size (180, 22);
            Menu2_PrintoutExamSheet.Text = "Exam Sheet (empty)";
            Menu2_PrintoutExamSheet.Click += Menu2_PrintoutExamSheet_Click;
            // 
            // Menu2_PrintoutExamRecord
            // 
            Menu2_PrintoutExamRecord.Name = "Menu2_PrintoutExamRecord";
            Menu2_PrintoutExamRecord.Size = new System.Drawing.Size (180, 22);
            Menu2_PrintoutExamRecord.Text = "Exam Records";
            Menu2_PrintoutExamRecord.Click += Menu2_PrintoutExamRecord_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size (177, 6);
            // 
            // Menu2_Exit
            // 
            Menu2_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu2_Exit.Name = "Menu2_Exit";
            Menu2_Exit.Size = new System.Drawing.Size (180, 22);
            Menu2_Exit.Text = "Exit";
            Menu2_Exit.Click += Menu2_Exit_Click;
            // 
            // btnEditEntry
            // 
            btnEditEntry.Font = new System.Drawing.Font ("Courier New", 11F);
            btnEditEntry.Location = new System.Drawing.Point (311, 12);
            btnEditEntry.Name = "btnEditEntry";
            btnEditEntry.Size = new System.Drawing.Size (24, 24);
            btnEditEntry.TabIndex = 35;
            btnEditEntry.Text = "I";
            btnEditEntry.UseVisualStyleBackColor = true;
            btnEditEntry.Click += btnEditEntry_Click;
            // 
            // btn_EditStudent
            // 
            btn_EditStudent.Font = new System.Drawing.Font ("Courier New", 11F);
            btn_EditStudent.Location = new System.Drawing.Point (5, 142);
            btn_EditStudent.Name = "btn_EditStudent";
            btn_EditStudent.Size = new System.Drawing.Size (41, 24);
            btn_EditStudent.TabIndex = 34;
            btn_EditStudent.Text = "I";
            btn_EditStudent.UseVisualStyleBackColor = true;
            btn_EditStudent.Click += btn_EditStudent_Click;
            // 
            // btn_AddNewStudent
            // 
            btn_AddNewStudent.Font = new System.Drawing.Font ("Courier New", 11F);
            btn_AddNewStudent.Location = new System.Drawing.Point (5, 82);
            btn_AddNewStudent.Name = "btn_AddNewStudent";
            btn_AddNewStudent.Size = new System.Drawing.Size (41, 24);
            btn_AddNewStudent.TabIndex = 33;
            btn_AddNewStudent.Text = "+";
            btn_AddNewStudent.UseVisualStyleBackColor = true;
            btn_AddNewStudent.Click += btn_AddNewStudent_Click;
            // 
            // btnAddNewEntry
            // 
            btnAddNewEntry.Font = new System.Drawing.Font ("Courier New", 11F);
            btnAddNewEntry.Location = new System.Drawing.Point (251, 12);
            btnAddNewEntry.Name = "btnAddNewEntry";
            btnAddNewEntry.Size = new System.Drawing.Size (24, 24);
            btnAddNewEntry.TabIndex = 32;
            btnAddNewEntry.Text = "+";
            btnAddNewEntry.UseVisualStyleBackColor = true;
            btnAddNewEntry.Click += btnAddNewEntry_Click;
            // 
            // btn_DeleteStudent
            // 
            btn_DeleteStudent.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btn_DeleteStudent.Location = new System.Drawing.Point (5, 112);
            btn_DeleteStudent.Name = "btn_DeleteStudent";
            btn_DeleteStudent.Size = new System.Drawing.Size (41, 24);
            btn_DeleteStudent.TabIndex = 37;
            btn_DeleteStudent.Text = "-";
            btn_DeleteStudent.UseVisualStyleBackColor = true;
            btn_DeleteStudent.Click += btn_DeleteStudent_Click;
            // 
            // btnDeleteEntry
            // 
            btnDeleteEntry.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnDeleteEntry.Location = new System.Drawing.Point (281, 12);
            btnDeleteEntry.Name = "btnDeleteEntry";
            btnDeleteEntry.Size = new System.Drawing.Size (24, 24);
            btnDeleteEntry.TabIndex = 36;
            btnDeleteEntry.Text = "-";
            btnDeleteEntry.UseVisualStyleBackColor = true;
            btnDeleteEntry.Click += btnDeleteEntry_Click;
            // 
            // btnAddExamToStudent
            // 
            btnAddExamToStudent.Font = new System.Drawing.Font ("Courier New", 11F);
            btnAddExamToStudent.Location = new System.Drawing.Point (976, 12);
            btnAddExamToStudent.Name = "btnAddExamToStudent";
            btnAddExamToStudent.Size = new System.Drawing.Size (108, 24);
            btnAddExamToStudent.TabIndex = 38;
            btnAddExamToStudent.Text = "+ Exam";
            btnAddExamToStudent.UseVisualStyleBackColor = true;
            btnAddExamToStudent.Click += btnAddExamToStudent_Click;
            // 
            // btnDeleteExam
            // 
            btnDeleteExam.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnDeleteExam.Location = new System.Drawing.Point (1090, 12);
            btnDeleteExam.Name = "btnDeleteExam";
            btnDeleteExam.Size = new System.Drawing.Size (28, 24);
            btnDeleteExam.TabIndex = 39;
            btnDeleteExam.Text = "-";
            btnDeleteExam.UseVisualStyleBackColor = true;
            btnDeleteExam.Click += btnDeleteExam_Click;
            // 
            // chkDoubleClickToDelete
            // 
            chkDoubleClickToDelete.AutoSize = true;
            chkDoubleClickToDelete.ForeColor = System.Drawing.Color.RoyalBlue;
            chkDoubleClickToDelete.Location = new System.Drawing.Point (1008, 503);
            chkDoubleClickToDelete.Name = "chkDoubleClickToDelete";
            chkDoubleClickToDelete.Size = new System.Drawing.Size (113, 19);
            chkDoubleClickToDelete.TabIndex = 40;
            chkDoubleClickToDelete.Text = "DoubleClick: Del";
            chkDoubleClickToDelete.UseVisualStyleBackColor = true;
            // 
            // frmStudentExams
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size (1125, 537);
            ControlBox = false;
            Controls.Add (chkDoubleClickToDelete);
            Controls.Add (btnDeleteExam);
            Controls.Add (btnAddExamToStudent);
            Controls.Add (btn_DeleteStudent);
            Controls.Add (btnDeleteEntry);
            Controls.Add (btnEditEntry);
            Controls.Add (btn_EditStudent);
            Controls.Add (btn_AddNewStudent);
            Controls.Add (btnAddNewEntry);
            Controls.Add (GridStudentExams);
            Controls.Add (GridStudents);
            Controls.Add (cboEntries);
            Controls.Add (panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmStudentExams";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Student Exams";
            Load += frmStudentExams_Load;
            panel1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridStudents).EndInit ();
            MenuStrip1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridStudentExams).EndInit ();
            MenuStrip2.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.DataGridView GridStudents;
        private System.Windows.Forms.ComboBox cboEntries;
        private System.Windows.Forms.DataGridView GridStudentExams;
        private System.Windows.Forms.Button btnEditEntry;
        private System.Windows.Forms.Button btn_EditStudent;
        private System.Windows.Forms.Button btn_AddNewStudent;
        private System.Windows.Forms.Button btnAddNewEntry;
        private System.Windows.Forms.ContextMenuStrip MenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Menu2_PrintoutExamSheet;
        private System.Windows.Forms.ToolStripMenuItem Menu2_PrintoutExamRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Menu2_Exit;
        private System.Windows.Forms.Button btn_DeleteStudent;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Button btnAddExamToStudent;
        private System.Windows.Forms.Button btnDeleteExam;
        private System.Windows.Forms.CheckBox chkDoubleClickToDelete;
        private System.Windows.Forms.ContextMenuStrip MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Passwords;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Exit;
        }
    }