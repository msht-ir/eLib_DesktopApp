using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmImportRefs : Form
        {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode ()]
        protected override void Dispose (bool disposing)
            {
            try
                {
                if (disposing && components is not null)
                    {
                    components.Dispose ();
                    }
                }
            finally
                {
                base.Dispose (disposing);
                }
            }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough ()]
        private void InitializeComponent ()
            {
            components = new System.ComponentModel.Container ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmImportRefs));
            txtTitle = new TextBox ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu1_Move = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu1_SelectRef = new ToolStripMenuItem ();
            Menu1_Open = new ToolStripMenuItem ();
            Menu1_Paste = new ToolStripMenuItem ();
            Menu1_SentenceCase = new ToolStripMenuItem ();
            toolStripMenuItem3 = new ToolStripSeparator ();
            Menu1_Exit = new ToolStripMenuItem ();
            ListSubProject = new ListBox ();
            ContextMenuStrip2 = new ContextMenuStrip (components);
            Menu2_Add = new ToolStripMenuItem ();
            Menu2_Remove = new ToolStripMenuItem ();
            Menu2_Clear = new ToolStripMenuItem ();
            FolderBrowserDialog1 = new FolderBrowserDialog ();
            lblPath = new Label ();
            lblExt = new Label ();
            lblSize = new Label ();
            lblCreated = new Label ();
            lblModified = new Label ();
            lblDestinationFolder = new Label ();
            lblRefType = new Label ();
            lblAutoMove = new Label ();
            lblAskFolder = new Label ();
            lblAutoMove2 = new Label ();
            lblAskFolder2 = new Label ();
            panel1 = new Panel ();
            lblImport = new Label ();
            lblExit = new Label ();
            ContextMenuStrip1.SuspendLayout ();
            ContextMenuStrip2.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // txtTitle
            // 
            txtTitle.AllowDrop = true;
            txtTitle.BackColor = Color.FromArgb (  246,   246,   246);
            txtTitle.BorderStyle = BorderStyle.None;
            txtTitle.ContextMenuStrip = ContextMenuStrip1;
            txtTitle.Dock = DockStyle.Top;
            txtTitle.Font = new Font ("Segoe UI", 11F);
            txtTitle.ForeColor = Color.Black;
            txtTitle.Location = new Point (0, 0);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size (709, 68);
            txtTitle.TabIndex = 0;
            txtTitle.DragDrop += txtTitle_DragDrop;
            txtTitle.DragEnter += txtTitle_DragEnter;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu1_Move, ToolStripMenuItem1, Menu1_SelectRef, Menu1_Open, Menu1_Paste, Menu1_SentenceCase, toolStripMenuItem3, Menu1_Exit });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size (172, 148);
            // 
            // Menu1_Move
            // 
            Menu1_Move.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            Menu1_Move.ForeColor = Color.RoyalBlue;
            Menu1_Move.Name = "Menu1_Move";
            Menu1_Move.ShortcutKeys = Keys.F5;
            Menu1_Move.Size = new Size (171, 22);
            Menu1_Move.Text = "Import / Save";
            Menu1_Move.Click += Menu1_Move_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (168, 6);
            // 
            // Menu1_SelectRef
            // 
            Menu1_SelectRef.Name = "Menu1_SelectRef";
            Menu1_SelectRef.ShortcutKeys = Keys.F2;
            Menu1_SelectRef.Size = new Size (171, 22);
            Menu1_SelectRef.Text = "Select...";
            Menu1_SelectRef.Click += Menu1_SelectRef_Click;
            // 
            // Menu1_Open
            // 
            Menu1_Open.Name = "Menu1_Open";
            Menu1_Open.ShortcutKeys = Keys.F3;
            Menu1_Open.Size = new Size (171, 22);
            Menu1_Open.Text = "Open";
            Menu1_Open.Click += Menu1_Open_Click;
            // 
            // Menu1_Paste
            // 
            Menu1_Paste.Name = "Menu1_Paste";
            Menu1_Paste.Size = new Size (171, 22);
            Menu1_Paste.Text = "Paste";
            Menu1_Paste.Click += Menu1_Paste_Click;
            // 
            // Menu1_SentenceCase
            // 
            Menu1_SentenceCase.Name = "Menu1_SentenceCase";
            Menu1_SentenceCase.ShortcutKeys = Keys.F4;
            Menu1_SentenceCase.Size = new Size (171, 22);
            Menu1_SentenceCase.Text = "Sentence case";
            Menu1_SentenceCase.Click += Menu1_SentenceCase_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size (168, 6);
            // 
            // Menu1_Exit
            // 
            Menu1_Exit.ForeColor = Color.IndianRed;
            Menu1_Exit.Name = "Menu1_Exit";
            Menu1_Exit.ShortcutKeys =  Keys.Control | Keys.Q;
            Menu1_Exit.Size = new Size (171, 22);
            Menu1_Exit.Text = "Exit";
            Menu1_Exit.Click += Menu1_Exit_Click;
            // 
            // ListSubProject
            // 
            ListSubProject.BackColor = Color.FromArgb (  248,   248,   248);
            ListSubProject.BorderStyle = BorderStyle.None;
            ListSubProject.ContextMenuStrip = ContextMenuStrip2;
            ListSubProject.Font = new Font ("Segoe UI", 11F);
            ListSubProject.ForeColor = Color.IndianRed;
            ListSubProject.FormattingEnabled = true;
            ListSubProject.ItemHeight = 20;
            ListSubProject.Location = new Point (174, 138);
            ListSubProject.Name = "ListSubProject";
            ListSubProject.Size = new Size (357, 80);
            ListSubProject.TabIndex = 1;
            ListSubProject.DoubleClick += ListSubProject_DoubleClick;
            // 
            // ContextMenuStrip2
            // 
            ContextMenuStrip2.Items.AddRange (new ToolStripItem [] { Menu2_Add, Menu2_Remove, Menu2_Clear });
            ContextMenuStrip2.Name = "ContextMenuStrip2";
            ContextMenuStrip2.Size = new Size (145, 70);
            // 
            // Menu2_Add
            // 
            Menu2_Add.Name = "Menu2_Add";
            Menu2_Add.ShortcutKeys = Keys.F8;
            Menu2_Add.Size = new Size (144, 22);
            Menu2_Add.Text = "+ Add";
            Menu2_Add.Click += Menu2_Add_Click;
            // 
            // Menu2_Remove
            // 
            Menu2_Remove.Name = "Menu2_Remove";
            Menu2_Remove.ShortcutKeys = Keys.F9;
            Menu2_Remove.Size = new Size (144, 22);
            Menu2_Remove.Text = "- Remove";
            Menu2_Remove.Click += Menu2_Remove_Click;
            // 
            // Menu2_Clear
            // 
            Menu2_Clear.ForeColor = Color.IndianRed;
            Menu2_Clear.Name = "Menu2_Clear";
            Menu2_Clear.ShortcutKeys = Keys.F5;
            Menu2_Clear.Size = new Size (144, 22);
            Menu2_Clear.Text = "Clear";
            Menu2_Clear.Click += Menu2_Clear_Click;
            // 
            // lblPath
            // 
            lblPath.Font = new Font ("Segoe UI", 9F);
            lblPath.ForeColor = Color.IndianRed;
            lblPath.Location = new Point (12, 71);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size (685, 29);
            lblPath.TabIndex = 8;
            lblPath.Text = "drop  a file ^";
            lblPath.TextAlign = ContentAlignment.MiddleLeft;
            lblPath.Click += lblPath_Click;
            // 
            // lblExt
            // 
            lblExt.AutoSize = true;
            lblExt.Font = new Font ("Segoe UI", 8F);
            lblExt.ForeColor = SystemColors.AppWorkspace;
            lblExt.Location = new Point (537, 143);
            lblExt.Name = "lblExt";
            lblExt.Size = new Size (10, 13);
            lblExt.TabIndex = 17;
            lblExt.Text = ".";
            lblExt.Visible = false;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Font = new Font ("Segoe UI", 8F);
            lblSize.ForeColor = SystemColors.AppWorkspace;
            lblSize.Location = new Point (537, 162);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size (10, 13);
            lblSize.TabIndex = 18;
            lblSize.Text = ".";
            lblSize.Visible = false;
            // 
            // lblCreated
            // 
            lblCreated.AutoSize = true;
            lblCreated.Font = new Font ("Segoe UI", 8F);
            lblCreated.ForeColor = SystemColors.AppWorkspace;
            lblCreated.Location = new Point (537, 181);
            lblCreated.Name = "lblCreated";
            lblCreated.Size = new Size (10, 13);
            lblCreated.TabIndex = 19;
            lblCreated.Text = ".";
            lblCreated.Visible = false;
            // 
            // lblModified
            // 
            lblModified.AutoSize = true;
            lblModified.Font = new Font ("Segoe UI", 8F);
            lblModified.ForeColor = SystemColors.AppWorkspace;
            lblModified.Location = new Point (537, 199);
            lblModified.Name = "lblModified";
            lblModified.Size = new Size (10, 13);
            lblModified.TabIndex = 20;
            lblModified.Text = ".";
            lblModified.Visible = false;
            // 
            // lblDestinationFolder
            // 
            lblDestinationFolder.BackColor = SystemColors.ControlLightLight;
            lblDestinationFolder.Dock = DockStyle.Bottom;
            lblDestinationFolder.Font = new Font ("Segoe UI", 11F);
            lblDestinationFolder.ForeColor = Color.DimGray;
            lblDestinationFolder.Location = new Point (130, 0);
            lblDestinationFolder.Name = "lblDestinationFolder";
            lblDestinationFolder.Size = new Size (449, 18);
            lblDestinationFolder.TabIndex = 24;
            lblDestinationFolder.Text = "-";
            lblDestinationFolder.TextAlign = ContentAlignment.MiddleCenter;
            lblDestinationFolder.Click += lblDestinationFolder_Click;
            // 
            // lblRefType
            // 
            lblRefType.BackColor = SystemColors.InactiveBorder;
            lblRefType.Font = new Font ("Consolas", 14F);
            lblRefType.ForeColor = Color.RoyalBlue;
            lblRefType.Location = new Point (174, 104);
            lblRefType.Name = "lblRefType";
            lblRefType.Size = new Size (357, 31);
            lblRefType.TabIndex = 25;
            lblRefType.Text = "<    Paper    >";
            lblRefType.TextAlign = ContentAlignment.MiddleCenter;
            lblRefType.Click += lblRefType_Click;
            // 
            // lblAutoMove
            // 
            lblAutoMove.BackColor = Color.FromArgb (  230,   230,   230);
            lblAutoMove.Font = new Font ("Consolas", 14F);
            lblAutoMove.ForeColor = Color.RoyalBlue;
            lblAutoMove.Location = new Point (10, 207);
            lblAutoMove.Name = "lblAutoMove";
            lblAutoMove.Size = new Size (30, 5);
            lblAutoMove.TabIndex = 26;
            lblAutoMove.TextAlign = ContentAlignment.MiddleCenter;
            lblAutoMove.Click += lblAutoMove_Click;
            // 
            // lblAskFolder
            // 
            lblAskFolder.BackColor = Color.Gold;
            lblAskFolder.Font = new Font ("Consolas", 14F);
            lblAskFolder.ForeColor = Color.RoyalBlue;
            lblAskFolder.Location = new Point (10, 190);
            lblAskFolder.Name = "lblAskFolder";
            lblAskFolder.Size = new Size (30, 5);
            lblAskFolder.TabIndex = 27;
            lblAskFolder.TextAlign = ContentAlignment.MiddleCenter;
            lblAskFolder.Click += lblAskFolder_Click;
            // 
            // lblAutoMove2
            // 
            lblAutoMove2.BackColor = Color.Transparent;
            lblAutoMove2.Font = new Font ("Consolas", 9F);
            lblAutoMove2.ForeColor = Color.RoyalBlue;
            lblAutoMove2.ImageAlign = ContentAlignment.MiddleLeft;
            lblAutoMove2.Location = new Point (43, 202);
            lblAutoMove2.Name = "lblAutoMove2";
            lblAutoMove2.Size = new Size (99, 14);
            lblAutoMove2.TabIndex = 28;
            lblAutoMove2.Text = "auto import";
            lblAutoMove2.TextAlign = ContentAlignment.MiddleLeft;
            lblAutoMove2.Click += lblAutoMove2_Click;
            // 
            // lblAskFolder2
            // 
            lblAskFolder2.BackColor = Color.Transparent;
            lblAskFolder2.Font = new Font ("Consolas", 9F);
            lblAskFolder2.ForeColor = Color.RoyalBlue;
            lblAskFolder2.ImageAlign = ContentAlignment.MiddleLeft;
            lblAskFolder2.Location = new Point (43, 184);
            lblAskFolder2.Name = "lblAskFolder2";
            lblAskFolder2.Size = new Size (99, 14);
            lblAskFolder2.TabIndex = 29;
            lblAskFolder2.Text = "ask folder";
            lblAskFolder2.TextAlign = ContentAlignment.MiddleLeft;
            lblAskFolder2.Click += lblAskFolder2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblDestinationFolder);
            panel1.Controls.Add (lblImport);
            panel1.Controls.Add (lblExit);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 238);
            panel1.Name = "panel1";
            panel1.Size = new Size (709, 18);
            panel1.TabIndex = 31;
            // 
            // lblImport
            // 
            lblImport.BackColor = Color.CornflowerBlue;
            lblImport.Dock = DockStyle.Left;
            lblImport.Font = new Font ("Segoe UI", 9F);
            lblImport.ForeColor = SystemColors.ButtonHighlight;
            lblImport.Location = new Point (0, 0);
            lblImport.Name = "lblImport";
            lblImport.Size = new Size (130, 18);
            lblImport.TabIndex = 23;
            lblImport.Text = "Import";
            lblImport.TextAlign = ContentAlignment.MiddleCenter;
            lblImport.Click += lblImport_Click;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.LightCoral;
            lblExit.Dock = DockStyle.Right;
            lblExit.Font = new Font ("Segoe UI", 9F);
            lblExit.ForeColor = Color.White;
            lblExit.Location = new Point (579, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (130, 18);
            lblExit.TabIndex = 22;
            lblExit.Text = "Back";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // frmImportRefs
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size (709, 256);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (lblAskFolder2);
            Controls.Add (lblAutoMove2);
            Controls.Add (lblAskFolder);
            Controls.Add (lblAutoMove);
            Controls.Add (lblRefType);
            Controls.Add (lblModified);
            Controls.Add (lblCreated);
            Controls.Add (lblSize);
            Controls.Add (lblExt);
            Controls.Add (ListSubProject);
            Controls.Add (txtTitle);
            Controls.Add (lblPath);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmImportRefs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Import";
            TopMost = true;
            FormClosing += frmImportRefs_FormClosing;
            Load += frmImportRefs_Load;
            ContextMenuStrip1.ResumeLayout (false);
            ContextMenuStrip2.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal TextBox txtTitle;
        internal ListBox ListSubProject;
        internal ContextMenuStrip ContextMenuStrip2;
        internal ToolStripMenuItem Menu2_Add;
        internal ToolStripMenuItem Menu2_Remove;
        internal ToolStripMenuItem Menu2_Clear;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu1_Move;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu1_Exit;
        internal FolderBrowserDialog FolderBrowserDialog1;
        internal Label lblPath;
        internal Label lblExt;
        internal Label lblSize;
        internal Label lblCreated;
        internal Label lblModified;
        internal Label lblDestinationFolder;
        private Label lblRefType;
        private ToolStripMenuItem Menu1_SelectRef;
        private ToolStripMenuItem Menu1_Open;
        private ToolStripMenuItem Menu1_Paste;
        private ToolStripMenuItem Menu1_SentenceCase;
        private ToolStripSeparator toolStripMenuItem3;
        private Label lblAutoMove;
        private Label lblAskFolder;
        private Label lblAutoMove2;
        private Label lblAskFolder2;
        private Panel panel1;
        private Label lblImport;
        private Label lblExit;
        }
    }