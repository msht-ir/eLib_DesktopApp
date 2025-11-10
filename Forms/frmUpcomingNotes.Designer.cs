namespace eLib.Forms
    {
    public partial class frmUpcomingNotes
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
            Grid6 = new System.Windows.Forms.DataGridView ();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu_MoveToToday = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_MoveToTomorrow = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_MoveToNextWeek = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator ();
            Menu_EditNote = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_ExpandNote = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_AddToNewSpubProject = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Delete = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator ();
            Menu_Search = new System.Windows.Forms.ToolStripTextBox ();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator ();
            Menu_Refs = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Mindmap = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator ();
            Menu_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            mntCal = new System.Windows.Forms.MonthCalendar ();
            contextMenuCal = new System.Windows.Forms.ContextMenuStrip (components);
            Menu2_AddANote = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator ();
            Menu_ShowUpcoming = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_ShowPending = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_ShowPostponded = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator ();
            Menu_ShowNDays = new System.Windows.Forms.ToolStripTextBox ();
            Menu_Show2Weeks = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Show3Weeks = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Show1Month = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Show2Months = new System.Windows.Forms.ToolStripMenuItem ();
            txtNote = new System.Windows.Forms.TextBox ();
            contextMenuTextNote = new System.Windows.Forms.ContextMenuStrip (components);
            Menu3_RTL = new System.Windows.Forms.ToolStripMenuItem ();
            Menu3_Save = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator ();
            Menu3_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            btn_Edit = new System.Windows.Forms.Label ();
            panel1 = new System.Windows.Forms.Panel ();
            btn_Assign = new System.Windows.Forms.Label ();
            btn_Mindmap = new System.Windows.Forms.Label ();
            ((System.ComponentModel.ISupportInitialize) Grid6).BeginInit ();
            contextMenuStrip1.SuspendLayout ();
            contextMenuCal.SuspendLayout ();
            contextMenuTextNote.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // Grid6
            // 
            Grid6.AllowUserToAddRows = false;
            Grid6.AllowUserToDeleteRows = false;
            Grid6.AllowUserToResizeColumns = false;
            Grid6.AllowUserToResizeRows = false;
            Grid6.BackgroundColor = System.Drawing.Color.FromArgb (  251,   251,   251);
            Grid6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            Grid6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid6.ColumnHeadersVisible = false;
            Grid6.ContextMenuStrip = contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb (  251,   251,   251);
            dataGridViewCellStyle1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            Grid6.DefaultCellStyle = dataGridViewCellStyle1;
            Grid6.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            Grid6.GridColor = System.Drawing.Color.FromArgb (  250,   251,   251);
            Grid6.Location = new System.Drawing.Point (381, 33);
            Grid6.MultiSelect = false;
            Grid6.Name = "Grid6";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            Grid6.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            Grid6.RowHeadersVisible = false;
            Grid6.RowHeadersWidth = 20;
            Grid6.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            Grid6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            Grid6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            Grid6.Size = new System.Drawing.Size (465, 560);
            Grid6.TabIndex = 2;
            Grid6.CellClick += Grid6_CellClick;
            Grid6.CellDoubleClick += Grid6_CellDoubleClick;
            Grid6.SelectionChanged += Grid6_SelectionChanged;
            Grid6.KeyDown += Grid6_KeyDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_MoveToToday, Menu_MoveToTomorrow, Menu_MoveToNextWeek, toolStripMenuItem3, Menu_EditNote, Menu_ExpandNote, Menu_AddToNewSpubProject, Menu_Delete, toolStripMenuItem6, Menu_Search, toolStripMenuItem1, Menu_Refs, Menu_Mindmap, toolStripMenuItem2, Menu_Exit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size (261, 273);
            // 
            // Menu_MoveToToday
            // 
            Menu_MoveToToday.ForeColor = System.Drawing.SystemColors.HotTrack;
            Menu_MoveToToday.Name = "Menu_MoveToToday";
            Menu_MoveToToday.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0;
            Menu_MoveToToday.Size = new System.Drawing.Size (260, 22);
            Menu_MoveToToday.Text = "Move to today!";
            Menu_MoveToToday.Click += Menu_MoveToToday_Click;
            // 
            // Menu_MoveToTomorrow
            // 
            Menu_MoveToTomorrow.Name = "Menu_MoveToTomorrow";
            Menu_MoveToTomorrow.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1;
            Menu_MoveToTomorrow.Size = new System.Drawing.Size (260, 22);
            Menu_MoveToTomorrow.Text = "Move to tomorrow";
            Menu_MoveToTomorrow.Click += Menu_MoveToTomorrow_Click;
            // 
            // Menu_MoveToNextWeek
            // 
            Menu_MoveToNextWeek.Name = "Menu_MoveToNextWeek";
            Menu_MoveToNextWeek.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D7;
            Menu_MoveToNextWeek.Size = new System.Drawing.Size (260, 22);
            Menu_MoveToNextWeek.Text = "Move to next week";
            Menu_MoveToNextWeek.Click += Menu_MoveToNextWeek_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size (257, 6);
            // 
            // Menu_EditNote
            // 
            Menu_EditNote.Name = "Menu_EditNote";
            Menu_EditNote.ShortcutKeys = System.Windows.Forms.Keys.F2;
            Menu_EditNote.Size = new System.Drawing.Size (260, 22);
            Menu_EditNote.Text = "Edit";
            Menu_EditNote.Click += Menu_EditNote_Click;
            // 
            // Menu_ExpandNote
            // 
            Menu_ExpandNote.Name = "Menu_ExpandNote";
            Menu_ExpandNote.ShortcutKeys = System.Windows.Forms.Keys.F3;
            Menu_ExpandNote.Size = new System.Drawing.Size (260, 22);
            Menu_ExpandNote.Text = "Expand / Collapse";
            Menu_ExpandNote.Click += Menu_ExpandNote_Click;
            // 
            // Menu_AddToNewSpubProject
            // 
            Menu_AddToNewSpubProject.Name = "Menu_AddToNewSpubProject";
            Menu_AddToNewSpubProject.Size = new System.Drawing.Size (260, 22);
            Menu_AddToNewSpubProject.Text = "Linnk to...";
            Menu_AddToNewSpubProject.Click += Menu_AddToNewSpubProject_Click;
            // 
            // Menu_Delete
            // 
            Menu_Delete.ForeColor = System.Drawing.Color.IndianRed;
            Menu_Delete.Name = "Menu_Delete";
            Menu_Delete.Size = new System.Drawing.Size (260, 22);
            Menu_Delete.Text = "Delete";
            Menu_Delete.Click += Menu_Delete_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new System.Drawing.Size (257, 6);
            // 
            // Menu_Search
            // 
            Menu_Search.BackColor = System.Drawing.SystemColors.InactiveBorder;
            Menu_Search.Name = "Menu_Search";
            Menu_Search.Size = new System.Drawing.Size (200, 23);
            Menu_Search.Text = "search...";
            Menu_Search.KeyDown += Menu_Search_KeyDown;
            Menu_Search.Click += Menu_Search_Click;
            Menu_Search.TextChanged += Menu_Search_TextChanged;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size (257, 6);
            // 
            // Menu_Refs
            // 
            Menu_Refs.Name = "Menu_Refs";
            Menu_Refs.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E;
            Menu_Refs.Size = new System.Drawing.Size (260, 22);
            Menu_Refs.Text = "Back to eLib...";
            Menu_Refs.Click += Menu_Refs_Click;
            // 
            // Menu_Mindmap
            // 
            Menu_Mindmap.Name = "Menu_Mindmap";
            Menu_Mindmap.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M;
            Menu_Mindmap.Size = new System.Drawing.Size (260, 22);
            Menu_Mindmap.Text = "MindMap...";
            Menu_Mindmap.Click += Menu_Mindmap_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size (257, 6);
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
            Menu_Exit.Size = new System.Drawing.Size (260, 22);
            Menu_Exit.Text = "Exit";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // mntCal
            // 
            mntCal.CalendarDimensions = new System.Drawing.Size (1, 4);
            mntCal.ContextMenuStrip = contextMenuCal;
            mntCal.Location = new System.Drawing.Point (10, 11);
            mntCal.MaxDate = new System.DateTime (2171, 7, 6, 0, 0, 0, 0);
            mntCal.MinDate = new System.DateTime (1971, 3, 21, 0, 0, 0, 0);
            mntCal.Name = "mntCal";
            mntCal.ShowTodayCircle = false;
            mntCal.TabIndex = 4;
            mntCal.TabStop = false;
            mntCal.TrailingForeColor = System.Drawing.Color.IndianRed;
            mntCal.DateSelected += mntCal_DateSelected;
            // 
            // contextMenuCal
            // 
            contextMenuCal.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu2_AddANote, toolStripMenuItem4, Menu_ShowUpcoming, Menu_ShowPending, Menu_ShowPostponded, toolStripMenuItem7, Menu_ShowNDays, Menu_Show2Weeks, Menu_Show3Weeks, Menu_Show1Month, Menu_Show2Months });
            contextMenuCal.Name = "contextMenuStrip1";
            contextMenuCal.Size = new System.Drawing.Size (261, 217);
            // 
            // Menu2_AddANote
            // 
            Menu2_AddANote.Font = new System.Drawing.Font ("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            Menu2_AddANote.ForeColor = System.Drawing.SystemColors.HotTrack;
            Menu2_AddANote.Name = "Menu2_AddANote";
            Menu2_AddANote.Size = new System.Drawing.Size (260, 22);
            Menu2_AddANote.Text = "Add Note";
            Menu2_AddANote.Click += Menu2_AddANote_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size (257, 6);
            // 
            // Menu_ShowUpcoming
            // 
            Menu_ShowUpcoming.Name = "Menu_ShowUpcoming";
            Menu_ShowUpcoming.Size = new System.Drawing.Size (260, 22);
            Menu_ShowUpcoming.Text = "Upcoming";
            Menu_ShowUpcoming.Click += Menu_ShowUpcoming_Click;
            // 
            // Menu_ShowPending
            // 
            Menu_ShowPending.Name = "Menu_ShowPending";
            Menu_ShowPending.Size = new System.Drawing.Size (260, 22);
            Menu_ShowPending.Text = "Pending";
            Menu_ShowPending.Click += Menu_ShowPending_Click;
            // 
            // Menu_ShowPostponded
            // 
            Menu_ShowPostponded.Name = "Menu_ShowPostponded";
            Menu_ShowPostponded.Size = new System.Drawing.Size (260, 22);
            Menu_ShowPostponded.Text = "Postponded";
            Menu_ShowPostponded.Click += Menu_ShowPostponded_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new System.Drawing.Size (257, 6);
            // 
            // Menu_ShowNDays
            // 
            Menu_ShowNDays.BackColor = System.Drawing.SystemColors.InactiveBorder;
            Menu_ShowNDays.Name = "Menu_ShowNDays";
            Menu_ShowNDays.Size = new System.Drawing.Size (200, 23);
            Menu_ShowNDays.KeyDown += Menu_ShowNDays_KeyDown;
            Menu_ShowNDays.Click += Menu_ShowNDays_Click;
            Menu_ShowNDays.TextChanged += Menu_ShowNDays_TextChanged;
            // 
            // Menu_Show2Weeks
            // 
            Menu_Show2Weeks.Name = "Menu_Show2Weeks";
            Menu_Show2Weeks.Size = new System.Drawing.Size (260, 22);
            Menu_Show2Weeks.Text = "two weeks";
            Menu_Show2Weeks.Click += Menu_Show2Weeks_Click;
            // 
            // Menu_Show3Weeks
            // 
            Menu_Show3Weeks.Name = "Menu_Show3Weeks";
            Menu_Show3Weeks.Size = new System.Drawing.Size (260, 22);
            Menu_Show3Weeks.Text = "three weeks";
            Menu_Show3Weeks.Click += Menu_Show3Weeks_Click;
            // 
            // Menu_Show1Month
            // 
            Menu_Show1Month.Name = "Menu_Show1Month";
            Menu_Show1Month.Size = new System.Drawing.Size (260, 22);
            Menu_Show1Month.Text = "one month";
            Menu_Show1Month.Click += Menu_Show1Month_Click;
            // 
            // Menu_Show2Months
            // 
            Menu_Show2Months.Name = "Menu_Show2Months";
            Menu_Show2Months.Size = new System.Drawing.Size (260, 22);
            Menu_Show2Months.Text = "two months";
            Menu_Show2Months.Click += Menu_Show2Months_Click;
            // 
            // txtNote
            // 
            txtNote.BackColor = System.Drawing.SystemColors.Control;
            txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtNote.ContextMenuStrip = contextMenuTextNote;
            txtNote.Enabled = false;
            txtNote.Font = new System.Drawing.Font ("Segoe UI", 10F);
            txtNote.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            txtNote.Location = new System.Drawing.Point (852, 33);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new System.Drawing.Size (422, 560);
            txtNote.TabIndex = 3;
            txtNote.TextChanged += txtNote_TextChanged;
            txtNote.KeyDown += txtNote_KeyDown;
            // 
            // contextMenuTextNote
            // 
            contextMenuTextNote.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu3_RTL, Menu3_Save, toolStripMenuItem5, Menu3_Exit });
            contextMenuTextNote.Name = "contextMenuTextNote";
            contextMenuTextNote.Size = new System.Drawing.Size (139, 76);
            // 
            // Menu3_RTL
            // 
            Menu3_RTL.Name = "Menu3_RTL";
            Menu3_RTL.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R;
            Menu3_RTL.Size = new System.Drawing.Size (138, 22);
            Menu3_RTL.Text = "RTL";
            Menu3_RTL.Click += Menu3_RTL_Click;
            // 
            // Menu3_Save
            // 
            Menu3_Save.Name = "Menu3_Save";
            Menu3_Save.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            Menu3_Save.Size = new System.Drawing.Size (138, 22);
            Menu3_Save.Text = "Save";
            Menu3_Save.Click += Menu3_Save_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new System.Drawing.Size (135, 6);
            // 
            // Menu3_Exit
            // 
            Menu3_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu3_Exit.Name = "Menu3_Exit";
            Menu3_Exit.Size = new System.Drawing.Size (138, 22);
            Menu3_Exit.Text = "Exit";
            Menu3_Exit.Click += Menu3_Exit_Click;
            // 
            // btn_Edit
            // 
            btn_Edit.BackColor = System.Drawing.Color.WhiteSmoke;
            btn_Edit.Font = new System.Drawing.Font ("Segoe UI", 10F);
            btn_Edit.ForeColor = System.Drawing.Color.IndianRed;
            btn_Edit.Location = new System.Drawing.Point (1136, 8);
            btn_Edit.Name = "btn_Edit";
            btn_Edit.Size = new System.Drawing.Size (137, 18);
            btn_Edit.TabIndex = 171;
            btn_Edit.Text = "Edit";
            btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn_Edit.Click += btn_Edit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (btn_Assign);
            panel1.Controls.Add (btn_Mindmap);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 620);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (1284, 18);
            panel1.TabIndex = 172;
            // 
            // btn_Assign
            // 
            btn_Assign.BackColor = System.Drawing.Color.CornflowerBlue;
            btn_Assign.Dock = System.Windows.Forms.DockStyle.Right;
            btn_Assign.Font = new System.Drawing.Font ("Segoe UI", 10F);
            btn_Assign.ForeColor = System.Drawing.Color.White;
            btn_Assign.Location = new System.Drawing.Point (199, 0);
            btn_Assign.Name = "btn_Assign";
            btn_Assign.Size = new System.Drawing.Size (1085, 18);
            btn_Assign.TabIndex = 176;
            btn_Assign.Text = "Refs";
            btn_Assign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn_Assign.Click += btn_Assign_Click;
            // 
            // btn_Mindmap
            // 
            btn_Mindmap.BackColor = System.Drawing.Color.DarkSeaGreen;
            btn_Mindmap.Dock = System.Windows.Forms.DockStyle.Left;
            btn_Mindmap.Font = new System.Drawing.Font ("Segoe UI", 10F);
            btn_Mindmap.ForeColor = System.Drawing.Color.White;
            btn_Mindmap.Location = new System.Drawing.Point (0, 0);
            btn_Mindmap.Name = "btn_Mindmap";
            btn_Mindmap.Size = new System.Drawing.Size (189, 18);
            btn_Mindmap.TabIndex = 172;
            btn_Mindmap.Text = "Mindmap";
            btn_Mindmap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn_Mindmap.Click += btn_Mindmap_Click;
            // 
            // frmUpcomingNotes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size (1284, 638);
            ContextMenuStrip = contextMenuStrip1;
            ControlBox = false;
            Controls.Add (btn_Edit);
            Controls.Add (panel1);
            Controls.Add (Grid6);
            Controls.Add (txtNote);
            Controls.Add (mntCal);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUpcomingNotes";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Focus";
            Load += frmUpcomingNotes_Load;
            ((System.ComponentModel.ISupportInitialize) Grid6).EndInit ();
            contextMenuStrip1.ResumeLayout (false);
            contextMenuStrip1.PerformLayout ();
            contextMenuCal.ResumeLayout (false);
            contextMenuCal.PerformLayout ();
            contextMenuTextNote.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        internal System.Windows.Forms.DataGridView Grid6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Exit;
        private System.Windows.Forms.MonthCalendar mntCal;
        private System.Windows.Forms.ContextMenuStrip contextMenuCal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Menu2_AddANote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem Menu_Mindmap;
        private System.Windows.Forms.ToolStripMenuItem Menu_Delete;
        private System.Windows.Forms.ToolStripMenuItem Menu_MoveToTomorrow;
        private System.Windows.Forms.ToolStripMenuItem Menu_MoveToNextWeek;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Menu_MoveToToday;
        private System.Windows.Forms.ToolStripMenuItem Menu_AddToNewSpubProject;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.ContextMenuStrip contextMenuTextNote;
        private System.Windows.Forms.ToolStripMenuItem Menu3_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu3_Exit;
        private System.Windows.Forms.ToolStripMenuItem Menu_EditNote;
        private System.Windows.Forms.ToolStripMenuItem Menu_Refs;
        private System.Windows.Forms.ToolStripMenuItem Menu3_RTL;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripTextBox Menu_Search;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem Menu_ExpandNote;
        private System.Windows.Forms.Label btn_Edit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem Menu_ShowUpcoming;
        private System.Windows.Forms.ToolStripMenuItem Menu_ShowPending;
        private System.Windows.Forms.ToolStripMenuItem Menu_ShowPostponded;
        private System.Windows.Forms.ToolStripTextBox Menu_ShowNDays;
        private System.Windows.Forms.ToolStripMenuItem Menu_Show2Weeks;
        private System.Windows.Forms.ToolStripMenuItem Menu_Show3Weeks;
        private System.Windows.Forms.ToolStripMenuItem Menu_Show1Month;
        private System.Windows.Forms.ToolStripMenuItem Menu_Show2Months;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.Label btn_Mindmap;
        private System.Windows.Forms.Label btn_Assign;
        }
    }