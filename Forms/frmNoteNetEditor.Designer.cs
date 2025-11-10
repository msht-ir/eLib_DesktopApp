namespace eLib.Forms
    {
    partial class frmNoteNetEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle ();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle ();
            GridNoteFamily = new System.Windows.Forms.DataGridView ();
            contextMenuStripFamily = new System.Windows.Forms.ContextMenuStrip (components);
            MenuF_SelectSubProject = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator ();
            Menu_AddNewNote = new System.Windows.Forms.ToolStripMenuItem ();
            MenuF_AddToNewSubProject = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator ();
            MenuF_BackToUpcoming = new System.Windows.Forms.ToolStripMenuItem ();
            MenuF_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            lblCaptionUpstream = new System.Windows.Forms.Label ();
            lblCaptionDownstream = new System.Windows.Forms.Label ();
            txtNote = new System.Windows.Forms.TextBox ();
            contextMenuStripDatum = new System.Windows.Forms.ContextMenuStrip (components);
            Menu_RTL = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Font = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_FontSmall = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_FontMedium = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_FontLarge = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_EditDateTime = new System.Windows.Forms.ToolStripMenuItem ();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator ();
            Menu_Save = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            GridDownstream = new System.Windows.Forms.DataGridView ();
            contextMenuDownStream = new System.Windows.Forms.ContextMenuStrip (components);
            Menu_DeleteDownStraem = new System.Windows.Forms.ToolStripMenuItem ();
            GridUpstream = new System.Windows.Forms.DataGridView ();
            contextMenuUpStream = new System.Windows.Forms.ContextMenuStrip (components);
            Menu_DeleteUpStraem = new System.Windows.Forms.ToolStripMenuItem ();
            lblCaptionNotes = new System.Windows.Forms.Label ();
            lblDone = new System.Windows.Forms.Label ();
            lblText4D = new System.Windows.Forms.Label ();
            lblText4F = new System.Windows.Forms.Label ();
            lblText4U = new System.Windows.Forms.Label ();
            lblText4S = new System.Windows.Forms.Label ();
            lblCaptionSearch = new System.Windows.Forms.Label ();
            txtDatum = new System.Windows.Forms.MaskedTextBox ();
            GridNoteSearch = new System.Windows.Forms.DataGridView ();
            contextMenuStripSearch = new System.Windows.Forms.ContextMenuStrip (components);
            Menu_AddUpstream = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_AddDownstream = new System.Windows.Forms.ToolStripMenuItem ();
            lblCounter = new System.Windows.Forms.Label ();
            panel1 = new System.Windows.Forms.Panel ();
            btn_Assign = new System.Windows.Forms.Label ();
            btn_Upcoming = new System.Windows.Forms.Label ();
            btn_Save = new System.Windows.Forms.Label ();
            txt_Search = new System.Windows.Forms.TextBox ();
            ((System.ComponentModel.ISupportInitialize) GridNoteFamily).BeginInit ();
            contextMenuStripFamily.SuspendLayout ();
            contextMenuStripDatum.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridDownstream).BeginInit ();
            contextMenuDownStream.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridUpstream).BeginInit ();
            contextMenuUpStream.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridNoteSearch).BeginInit ();
            contextMenuStripSearch.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridNoteFamily
            // 
            GridNoteFamily.AllowUserToAddRows = false;
            GridNoteFamily.AllowUserToDeleteRows = false;
            GridNoteFamily.AllowUserToResizeColumns = false;
            GridNoteFamily.AllowUserToResizeRows = false;
            GridNoteFamily.BackgroundColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            GridNoteFamily.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridNoteFamily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridNoteFamily.ColumnHeadersVisible = false;
            GridNoteFamily.ContextMenuStrip = contextMenuStripFamily;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            dataGridViewCellStyle1.Font = new System.Drawing.Font ("Segoe UI", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb (  243,   243,   243);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridNoteFamily.DefaultCellStyle = dataGridViewCellStyle1;
            GridNoteFamily.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridNoteFamily.GridColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            GridNoteFamily.Location = new System.Drawing.Point (14, 226);
            GridNoteFamily.MultiSelect = false;
            GridNoteFamily.Name = "GridNoteFamily";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            GridNoteFamily.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            GridNoteFamily.RowHeadersVisible = false;
            GridNoteFamily.RowHeadersWidth = 20;
            GridNoteFamily.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridNoteFamily.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            GridNoteFamily.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            GridNoteFamily.Size = new System.Drawing.Size (410, 183);
            GridNoteFamily.TabIndex = 12;
            GridNoteFamily.CellClick += GridNoteFamily_CellClick;
            GridNoteFamily.KeyDown += GridNoteFamily_KeyDown;
            // 
            // contextMenuStripFamily
            // 
            contextMenuStripFamily.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { MenuF_SelectSubProject, toolStripMenuItem3, Menu_AddNewNote, MenuF_AddToNewSubProject, toolStripMenuItem4, MenuF_BackToUpcoming, MenuF_Exit });
            contextMenuStripFamily.Name = "contextMenuStripFamily";
            contextMenuStripFamily.Size = new System.Drawing.Size (172, 126);
            // 
            // MenuF_SelectSubProject
            // 
            MenuF_SelectSubProject.Name = "MenuF_SelectSubProject";
            MenuF_SelectSubProject.ShortcutKeys = System.Windows.Forms.Keys.F4;
            MenuF_SelectSubProject.Size = new System.Drawing.Size (171, 22);
            MenuF_SelectSubProject.Text = "SubProject...";
            MenuF_SelectSubProject.Click += MenuF_SelectSubProject_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size (168, 6);
            // 
            // Menu_AddNewNote
            // 
            Menu_AddNewNote.Name = "Menu_AddNewNote";
            Menu_AddNewNote.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            Menu_AddNewNote.Size = new System.Drawing.Size (171, 22);
            Menu_AddNewNote.Text = "New note";
            Menu_AddNewNote.Click += Menu_AddNewNote_Click;
            // 
            // MenuF_AddToNewSubProject
            // 
            MenuF_AddToNewSubProject.Name = "MenuF_AddToNewSubProject";
            MenuF_AddToNewSubProject.Size = new System.Drawing.Size (171, 22);
            MenuF_AddToNewSubProject.Text = "Add to...";
            MenuF_AddToNewSubProject.Click += MenuF_AddToNewSubProject_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size (168, 6);
            // 
            // MenuF_BackToUpcoming
            // 
            MenuF_BackToUpcoming.Name = "MenuF_BackToUpcoming";
            MenuF_BackToUpcoming.Size = new System.Drawing.Size (171, 22);
            MenuF_BackToUpcoming.Text = "Upcoming notes...";
            MenuF_BackToUpcoming.Click += MenuF_BackToUpcoming_Click;
            // 
            // MenuF_Exit
            // 
            MenuF_Exit.ForeColor = System.Drawing.Color.IndianRed;
            MenuF_Exit.Name = "MenuF_Exit";
            MenuF_Exit.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
            MenuF_Exit.Size = new System.Drawing.Size (171, 22);
            MenuF_Exit.Text = "Exit";
            MenuF_Exit.Click += MenuF_Exit_Click;
            // 
            // lblCaptionUpstream
            // 
            lblCaptionUpstream.AutoSize = true;
            lblCaptionUpstream.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblCaptionUpstream.Font = new System.Drawing.Font ("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblCaptionUpstream.ForeColor = System.Drawing.Color.SteelBlue;
            lblCaptionUpstream.Location = new System.Drawing.Point (14, 23);
            lblCaptionUpstream.Name = "lblCaptionUpstream";
            lblCaptionUpstream.Size = new System.Drawing.Size (56, 17);
            lblCaptionUpstream.TabIndex = 118;
            lblCaptionUpstream.Text = "Parent";
            lblCaptionUpstream.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCaptionUpstream.Click += lblCaptionUpstream_Click;
            // 
            // lblCaptionDownstream
            // 
            lblCaptionDownstream.AutoSize = true;
            lblCaptionDownstream.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblCaptionDownstream.Font = new System.Drawing.Font ("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblCaptionDownstream.ForeColor = System.Drawing.Color.SteelBlue;
            lblCaptionDownstream.Location = new System.Drawing.Point (14, 422);
            lblCaptionDownstream.Name = "lblCaptionDownstream";
            lblCaptionDownstream.Size = new System.Drawing.Size (44, 17);
            lblCaptionDownstream.TabIndex = 120;
            lblCaptionDownstream.Text = "Child";
            lblCaptionDownstream.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCaptionDownstream.Click += lblCaptionDownstream_Click;
            // 
            // txtNote
            // 
            txtNote.AllowDrop = true;
            txtNote.BackColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtNote.ContextMenuStrip = contextMenuStripDatum;
            txtNote.Enabled = false;
            txtNote.Font = new System.Drawing.Font ("Consolas", 6F);
            txtNote.ForeColor = System.Drawing.Color.Black;
            txtNote.Location = new System.Drawing.Point (446, 42);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtNote.Size = new System.Drawing.Size (826, 269);
            txtNote.TabIndex = 121;
            txtNote.Text = "-";
            txtNote.TextChanged += txtNote_TextChanged;
            txtNote.DoubleClick += txtNote_DoubleClick;
            // 
            // contextMenuStripDatum
            // 
            contextMenuStripDatum.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_RTL, Menu_Font, Menu_EditDateTime, toolStripMenuItem2, Menu_Save, Menu_Exit });
            contextMenuStripDatum.Name = "contextMenuStrip1";
            contextMenuStripDatum.Size = new System.Drawing.Size (148, 120);
            // 
            // Menu_RTL
            // 
            Menu_RTL.Name = "Menu_RTL";
            Menu_RTL.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R;
            Menu_RTL.Size = new System.Drawing.Size (147, 22);
            Menu_RTL.Text = "RTL";
            Menu_RTL.Click += Menu_RTL_Click;
            // 
            // Menu_Font
            // 
            Menu_Font.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_FontSmall, Menu_FontMedium, Menu_FontLarge });
            Menu_Font.Name = "Menu_Font";
            Menu_Font.Size = new System.Drawing.Size (147, 22);
            Menu_Font.Text = "Font  >";
            // 
            // Menu_FontSmall
            // 
            Menu_FontSmall.Name = "Menu_FontSmall";
            Menu_FontSmall.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1;
            Menu_FontSmall.Size = new System.Drawing.Size (159, 22);
            Menu_FontSmall.Text = "Small";
            Menu_FontSmall.Click += Menu_FontSmall_Click;
            // 
            // Menu_FontMedium
            // 
            Menu_FontMedium.Name = "Menu_FontMedium";
            Menu_FontMedium.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2;
            Menu_FontMedium.Size = new System.Drawing.Size (159, 22);
            Menu_FontMedium.Text = "Medium";
            Menu_FontMedium.Click += Menu_FontMedium_Click;
            // 
            // Menu_FontLarge
            // 
            Menu_FontLarge.Name = "Menu_FontLarge";
            Menu_FontLarge.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3;
            Menu_FontLarge.Size = new System.Drawing.Size (159, 22);
            Menu_FontLarge.Text = "Large";
            Menu_FontLarge.Click += Menu_FontLarge_Click;
            // 
            // Menu_EditDateTime
            // 
            Menu_EditDateTime.Name = "Menu_EditDateTime";
            Menu_EditDateTime.Size = new System.Drawing.Size (147, 22);
            Menu_EditDateTime.Text = "Date - Time ...";
            Menu_EditDateTime.Click += Menu_EditDateTime_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size (144, 6);
            // 
            // Menu_Save
            // 
            Menu_Save.ForeColor = System.Drawing.SystemColors.HotTrack;
            Menu_Save.Name = "Menu_Save";
            Menu_Save.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            Menu_Save.Size = new System.Drawing.Size (147, 22);
            Menu_Save.Text = "Save";
            Menu_Save.Click += Menu_Save_Click;
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new System.Drawing.Size (147, 22);
            Menu_Exit.Text = "Exit";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // GridDownstream
            // 
            GridDownstream.AllowUserToAddRows = false;
            GridDownstream.AllowUserToDeleteRows = false;
            GridDownstream.AllowUserToResizeColumns = false;
            GridDownstream.AllowUserToResizeRows = false;
            GridDownstream.BackgroundColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            GridDownstream.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridDownstream.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridDownstream.ColumnHeadersVisible = false;
            GridDownstream.ContextMenuStrip = contextMenuDownStream;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            dataGridViewCellStyle3.Font = new System.Drawing.Font ("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb (  243,   243,   243);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridDownstream.DefaultCellStyle = dataGridViewCellStyle3;
            GridDownstream.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridDownstream.GridColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            GridDownstream.Location = new System.Drawing.Point (14, 440);
            GridDownstream.MultiSelect = false;
            GridDownstream.Name = "GridDownstream";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            GridDownstream.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            GridDownstream.RowHeadersVisible = false;
            GridDownstream.RowHeadersWidth = 20;
            GridDownstream.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridDownstream.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            GridDownstream.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            GridDownstream.Size = new System.Drawing.Size (410, 150);
            GridDownstream.TabIndex = 122;
            GridDownstream.CellClick += GridDownstream_CellClick;
            GridDownstream.KeyDown += GridDownstream_KeyDown;
            // 
            // contextMenuDownStream
            // 
            contextMenuDownStream.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_DeleteDownStraem });
            contextMenuDownStream.Name = "contextMenuDownStream";
            contextMenuDownStream.Size = new System.Drawing.Size (108, 26);
            // 
            // Menu_DeleteDownStraem
            // 
            Menu_DeleteDownStraem.ForeColor = System.Drawing.Color.IndianRed;
            Menu_DeleteDownStraem.Name = "Menu_DeleteDownStraem";
            Menu_DeleteDownStraem.Size = new System.Drawing.Size (107, 22);
            Menu_DeleteDownStraem.Text = "Delete";
            Menu_DeleteDownStraem.Click += Menu_DeleteDownStraem_Click;
            // 
            // GridUpstream
            // 
            GridUpstream.AllowUserToAddRows = false;
            GridUpstream.AllowUserToDeleteRows = false;
            GridUpstream.AllowUserToResizeColumns = false;
            GridUpstream.AllowUserToResizeRows = false;
            GridUpstream.BackgroundColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            GridUpstream.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridUpstream.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridUpstream.ColumnHeadersVisible = false;
            GridUpstream.ContextMenuStrip = contextMenuUpStream;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            dataGridViewCellStyle5.Font = new System.Drawing.Font ("Segoe UI", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb (  243,   243,   243);
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridUpstream.DefaultCellStyle = dataGridViewCellStyle5;
            GridUpstream.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridUpstream.GridColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            GridUpstream.Location = new System.Drawing.Point (14, 42);
            GridUpstream.MultiSelect = false;
            GridUpstream.Name = "GridUpstream";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            GridUpstream.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            GridUpstream.RowHeadersVisible = false;
            GridUpstream.RowHeadersWidth = 20;
            GridUpstream.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridUpstream.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            GridUpstream.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            GridUpstream.Size = new System.Drawing.Size (410, 150);
            GridUpstream.TabIndex = 123;
            GridUpstream.CellClick += GridUpstream_CellClick;
            GridUpstream.KeyDown += GridUpstream_KeyDown;
            // 
            // contextMenuUpStream
            // 
            contextMenuUpStream.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_DeleteUpStraem });
            contextMenuUpStream.Name = "contextMenuUpStream";
            contextMenuUpStream.Size = new System.Drawing.Size (108, 26);
            // 
            // Menu_DeleteUpStraem
            // 
            Menu_DeleteUpStraem.ForeColor = System.Drawing.Color.IndianRed;
            Menu_DeleteUpStraem.Name = "Menu_DeleteUpStraem";
            Menu_DeleteUpStraem.Size = new System.Drawing.Size (107, 22);
            Menu_DeleteUpStraem.Text = "Delete";
            Menu_DeleteUpStraem.Click += Menu_DeleteUpStraem_Click;
            // 
            // lblCaptionNotes
            // 
            lblCaptionNotes.AutoSize = true;
            lblCaptionNotes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblCaptionNotes.Font = new System.Drawing.Font ("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblCaptionNotes.ForeColor = System.Drawing.Color.IndianRed;
            lblCaptionNotes.Location = new System.Drawing.Point (14, 206);
            lblCaptionNotes.Name = "lblCaptionNotes";
            lblCaptionNotes.Size = new System.Drawing.Size (50, 17);
            lblCaptionNotes.TabIndex = 124;
            lblCaptionNotes.Text = "Notes";
            lblCaptionNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCaptionNotes.Click += lblCaptionNotes_Click;
            // 
            // lblDone
            // 
            lblDone.AutoSize = true;
            lblDone.BackColor = System.Drawing.Color.CornflowerBlue;
            lblDone.Font = new System.Drawing.Font ("Courier New", 8F);
            lblDone.ForeColor = System.Drawing.Color.White;
            lblDone.Location = new System.Drawing.Point (446, 25);
            lblDone.Name = "lblDone";
            lblDone.Size = new System.Drawing.Size (14, 14);
            lblDone.TabIndex = 129;
            lblDone.Text = "p";
            lblDone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblDone.Visible = false;
            // 
            // lblText4D
            // 
            lblText4D.BackColor = System.Drawing.Color.CornflowerBlue;
            lblText4D.Location = new System.Drawing.Point (384, 434);
            lblText4D.Name = "lblText4D";
            lblText4D.Size = new System.Drawing.Size (40, 3);
            lblText4D.TabIndex = 132;
            lblText4D.Visible = false;
            // 
            // lblText4F
            // 
            lblText4F.BackColor = System.Drawing.Color.CornflowerBlue;
            lblText4F.Location = new System.Drawing.Point (384, 220);
            lblText4F.Name = "lblText4F";
            lblText4F.Size = new System.Drawing.Size (40, 3);
            lblText4F.TabIndex = 133;
            lblText4F.Visible = false;
            // 
            // lblText4U
            // 
            lblText4U.BackColor = System.Drawing.Color.CornflowerBlue;
            lblText4U.Location = new System.Drawing.Point (384, 36);
            lblText4U.Name = "lblText4U";
            lblText4U.Size = new System.Drawing.Size (40, 3);
            lblText4U.TabIndex = 134;
            lblText4U.Visible = false;
            // 
            // lblText4S
            // 
            lblText4S.BackColor = System.Drawing.Color.CornflowerBlue;
            lblText4S.Location = new System.Drawing.Point (1172, 350);
            lblText4S.Name = "lblText4S";
            lblText4S.Size = new System.Drawing.Size (100, 3);
            lblText4S.TabIndex = 135;
            lblText4S.Visible = false;
            // 
            // lblCaptionSearch
            // 
            lblCaptionSearch.AutoSize = true;
            lblCaptionSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblCaptionSearch.Font = new System.Drawing.Font ("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblCaptionSearch.ForeColor = System.Drawing.Color.SteelBlue;
            lblCaptionSearch.Location = new System.Drawing.Point (446, 336);
            lblCaptionSearch.Name = "lblCaptionSearch";
            lblCaptionSearch.Size = new System.Drawing.Size (59, 17);
            lblCaptionSearch.TabIndex = 136;
            lblCaptionSearch.Text = "Search";
            lblCaptionSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblCaptionSearch.Click += lblCaptionSearch_Click;
            // 
            // txtDatum
            // 
            txtDatum.BackColor = System.Drawing.SystemColors.ControlLightLight;
            txtDatum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtDatum.Enabled = false;
            txtDatum.Font = new System.Drawing.Font ("Courier New", 10F);
            txtDatum.ForeColor = System.Drawing.Color.IndianRed;
            txtDatum.Location = new System.Drawing.Point (759, 19);
            txtDatum.Mask = "0000-00-00 . 00-00";
            txtDatum.Name = "txtDatum";
            txtDatum.Size = new System.Drawing.Size (206, 16);
            txtDatum.TabIndex = 137;
            txtDatum.TabStop = false;
            txtDatum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtDatum.DoubleClick += txtDatum_DoubleClick;
            // 
            // GridNoteSearch
            // 
            GridNoteSearch.AllowUserToAddRows = false;
            GridNoteSearch.AllowUserToDeleteRows = false;
            GridNoteSearch.AllowUserToResizeColumns = false;
            GridNoteSearch.AllowUserToResizeRows = false;
            GridNoteSearch.BackgroundColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            GridNoteSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridNoteSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridNoteSearch.ColumnHeadersVisible = false;
            GridNoteSearch.ContextMenuStrip = contextMenuStripSearch;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            dataGridViewCellStyle7.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb (  243,   243,   243);
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridNoteSearch.DefaultCellStyle = dataGridViewCellStyle7;
            GridNoteSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridNoteSearch.GridColor = System.Drawing.Color.FromArgb (  247,   247,   247);
            GridNoteSearch.Location = new System.Drawing.Point (446, 356);
            GridNoteSearch.MultiSelect = false;
            GridNoteSearch.Name = "GridNoteSearch";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            GridNoteSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            GridNoteSearch.RowHeadersVisible = false;
            GridNoteSearch.RowHeadersWidth = 20;
            GridNoteSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            GridNoteSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            GridNoteSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            GridNoteSearch.Size = new System.Drawing.Size (826, 234);
            GridNoteSearch.TabIndex = 138;
            GridNoteSearch.CellClick += GridNoteSearch_CellClick;
            GridNoteSearch.KeyDown += GridNoteSearch_KeyDown;
            // 
            // contextMenuStripSearch
            // 
            contextMenuStripSearch.Font = new System.Drawing.Font ("Segoe UI", 10F);
            contextMenuStripSearch.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_AddUpstream, Menu_AddDownstream });
            contextMenuStripSearch.Name = "contextMenuStripSearch";
            contextMenuStripSearch.Size = new System.Drawing.Size (248, 52);
            // 
            // Menu_AddUpstream
            // 
            Menu_AddUpstream.Name = "Menu_AddUpstream";
            Menu_AddUpstream.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U;
            Menu_AddUpstream.Size = new System.Drawing.Size (247, 24);
            Menu_AddUpstream.Text = "Add as Parent note";
            Menu_AddUpstream.Click += Menu_AddUpstream_Click;
            // 
            // Menu_AddDownstream
            // 
            Menu_AddDownstream.Name = "Menu_AddDownstream";
            Menu_AddDownstream.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D;
            Menu_AddDownstream.Size = new System.Drawing.Size (247, 24);
            Menu_AddDownstream.Text = "Add as Child note";
            Menu_AddDownstream.Click += Menu_AddDownstream_Click;
            // 
            // lblCounter
            // 
            lblCounter.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblCounter.Font = new System.Drawing.Font ("Courier New", 8F);
            lblCounter.ForeColor = System.Drawing.Color.DarkGray;
            lblCounter.Location = new System.Drawing.Point (807, 315);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new System.Drawing.Size (105, 14);
            lblCounter.TabIndex = 139;
            lblCounter.Text = "-";
            lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCounter.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add (btn_Assign);
            panel1.Controls.Add (btn_Upcoming);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 633);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (1284, 18);
            panel1.TabIndex = 140;
            // 
            // btn_Assign
            // 
            btn_Assign.BackColor = System.Drawing.Color.CornflowerBlue;
            btn_Assign.Dock = System.Windows.Forms.DockStyle.Right;
            btn_Assign.Font = new System.Drawing.Font ("Segoe UI", 10F);
            btn_Assign.ForeColor = System.Drawing.Color.White;
            btn_Assign.Location = new System.Drawing.Point (202, 0);
            btn_Assign.Name = "btn_Assign";
            btn_Assign.Size = new System.Drawing.Size (1082, 18);
            btn_Assign.TabIndex = 174;
            btn_Assign.Text = "Refs";
            btn_Assign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn_Assign.Click += btn_Assign_Click;
            // 
            // btn_Upcoming
            // 
            btn_Upcoming.BackColor = System.Drawing.Color.DarkSeaGreen;
            btn_Upcoming.Dock = System.Windows.Forms.DockStyle.Left;
            btn_Upcoming.Font = new System.Drawing.Font ("Segoe UI", 10F);
            btn_Upcoming.ForeColor = System.Drawing.Color.White;
            btn_Upcoming.Location = new System.Drawing.Point (0, 0);
            btn_Upcoming.Name = "btn_Upcoming";
            btn_Upcoming.Size = new System.Drawing.Size (186, 18);
            btn_Upcoming.TabIndex = 173;
            btn_Upcoming.Text = "Upcoming";
            btn_Upcoming.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn_Upcoming.Click += btn_Upcoming_Click;
            // 
            // btn_Save
            // 
            btn_Save.BackColor = System.Drawing.Color.LightCoral;
            btn_Save.Font = new System.Drawing.Font ("Consolas", 10F);
            btn_Save.ForeColor = System.Drawing.Color.White;
            btn_Save.Location = new System.Drawing.Point (1116, 21);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new System.Drawing.Size (156, 18);
            btn_Save.TabIndex = 9;
            btn_Save.Text = "Save";
            btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn_Save.Visible = false;
            btn_Save.Click += btn_Save_Click;
            // 
            // txt_Search
            // 
            txt_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txt_Search.Font = new System.Drawing.Font ("Segoe UI", 10F);
            txt_Search.ForeColor = System.Drawing.Color.RoyalBlue;
            txt_Search.Location = new System.Drawing.Point (551, 596);
            txt_Search.Name = "txt_Search";
            txt_Search.Size = new System.Drawing.Size (617, 18);
            txt_Search.TabIndex = 141;
            txt_Search.Text = "Search";
            txt_Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txt_Search.Click += txt_Search_Click;
            txt_Search.TextChanged += txt_Search_TextChanged;
            txt_Search.KeyDown += txt_Search_KeyDown;
            // 
            // frmNoteNetEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size (1284, 651);
            ControlBox = false;
            Controls.Add (txt_Search);
            Controls.Add (btn_Save);
            Controls.Add (panel1);
            Controls.Add (GridNoteSearch);
            Controls.Add (txtDatum);
            Controls.Add (lblText4S);
            Controls.Add (lblText4U);
            Controls.Add (lblText4F);
            Controls.Add (lblText4D);
            Controls.Add (lblDone);
            Controls.Add (GridUpstream);
            Controls.Add (GridDownstream);
            Controls.Add (txtNote);
            Controls.Add (GridNoteFamily);
            Controls.Add (lblCounter);
            Controls.Add (lblCaptionSearch);
            Controls.Add (lblCaptionDownstream);
            Controls.Add (lblCaptionUpstream);
            Controls.Add (lblCaptionNotes);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNoteNetEditor";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmNoteNetEditor";
            Load += frmNoteNetEditor_Load;
            DoubleClick += frmNoteNetEditor_DoubleClick;
            KeyDown += frmNoteNetEditor_KeyDown;
            ((System.ComponentModel.ISupportInitialize) GridNoteFamily).EndInit ();
            contextMenuStripFamily.ResumeLayout (false);
            contextMenuStripDatum.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridDownstream).EndInit ();
            contextMenuDownStream.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridUpstream).EndInit ();
            contextMenuUpStream.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridNoteSearch).EndInit ();
            contextMenuStripSearch.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        internal System.Windows.Forms.DataGridView GridNoteFamily;
        internal System.Windows.Forms.Label lblCaptionUpstream;
        internal System.Windows.Forms.ListBox List4;
        internal System.Windows.Forms.Label lblCaptionDownstream;
        internal System.Windows.Forms.ListBox listBox1;
        internal System.Windows.Forms.TextBox txtNote;
        internal System.Windows.Forms.DataGridView GridDownstream;
        internal System.Windows.Forms.DataGridView GridUpstream;
        internal System.Windows.Forms.Label lblCaptionNotes;
        private System.Windows.Forms.Label lblDone;
        private System.Windows.Forms.Label lblText4D;
        private System.Windows.Forms.Label lblText4F;
        private System.Windows.Forms.Label lblText4U;
        private System.Windows.Forms.Label lblText4S;
        internal System.Windows.Forms.Label lblCaptionSearch;
        internal System.Windows.Forms.MaskedTextBox txtDatum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDatum;
        private System.Windows.Forms.ToolStripMenuItem Menu_EditDateTime;
        private System.Windows.Forms.ToolStripMenuItem Menu_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu_Exit;
        internal System.Windows.Forms.DataGridView GridNoteSearch;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.ToolStripMenuItem Menu_Font;
        private System.Windows.Forms.ToolStripMenuItem Menu_FontSmall;
        private System.Windows.Forms.ToolStripMenuItem Menu_FontMedium;
        private System.Windows.Forms.ToolStripMenuItem Menu_FontLarge;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFamily;
        private System.Windows.Forms.ToolStripMenuItem MenuF_Exit;
        private System.Windows.Forms.ToolStripMenuItem MenuF_AddToNewSubProject;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSearch;
        private System.Windows.Forms.ToolStripMenuItem Menu_AddDownstream;
        private System.Windows.Forms.ToolStripMenuItem Menu_AddUpstream;
        private System.Windows.Forms.ContextMenuStrip contextMenuUpStream;
        private System.Windows.Forms.ContextMenuStrip contextMenuDownStream;
        private System.Windows.Forms.ToolStripMenuItem Menu_DeleteUpStraem;
        private System.Windows.Forms.ToolStripMenuItem Menu_DeleteDownStraem;
        private System.Windows.Forms.ToolStripMenuItem MenuF_SelectSubProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Menu_RTL;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem Menu_AddNewNote;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btn_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem MenuF_BackToUpcoming;
        private System.Windows.Forms.Label btn_Upcoming;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label btn_Assign;
        }
    }