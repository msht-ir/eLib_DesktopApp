using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmReadRef : Form
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
            ListPaths = new ListBox ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_Read = new ToolStripMenuItem ();
            Menu_Edit = new ToolStripMenuItem ();
            Menu_Locate = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_SaveACopy = new ToolStripMenuItem ();
            Menu_OpenSaveFolder = new ToolStripMenuItem ();
            Menu_Email = new ToolStripMenuItem ();
            ToolStripMenuItem3 = new ToolStripSeparator ();
            Menu_Delete = new ToolStripMenuItem ();
            Menu_Cancel = new ToolStripMenuItem ();
            lblExit = new Label ();
            panel1 = new Panel ();
            lblOpenRead = new Label ();
            ContextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ListPaths
            // 
            ListPaths.BackColor = Color.FromArgb (  241,   241,   241);
            ListPaths.BorderStyle = BorderStyle.None;
            ListPaths.ContextMenuStrip = ContextMenuStrip1;
            ListPaths.Dock = DockStyle.Top;
            ListPaths.Font = new Font ("Segoe UI", 11F, FontStyle.Italic);
            ListPaths.ForeColor = Color.IndianRed;
            ListPaths.FormattingEnabled = true;
            ListPaths.Location = new Point (0, 0);
            ListPaths.Name = "ListPaths";
            ListPaths.Size = new Size (1250, 80);
            ListPaths.TabIndex = 0;
            ListPaths.DoubleClick += ListPaths_DoubleClick;
            ListPaths.KeyDown += ListPaths_KeyDown;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_Read, Menu_Edit, Menu_Locate, ToolStripMenuItem1, Menu_SaveACopy, Menu_OpenSaveFolder, Menu_Email, ToolStripMenuItem3, Menu_Delete, Menu_Cancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size (179, 192);
            // 
            // Menu_Read
            // 
            Menu_Read.Font = new Font ("Segoe UI", 9F);
            Menu_Read.ForeColor = SystemColors.HotTrack;
            Menu_Read.Name = "Menu_Read";
            Menu_Read.Size = new Size (178, 22);
            Menu_Read.Text = "Read ...";
            Menu_Read.Click += Menu_Read_Click;
            // 
            // Menu_Edit
            // 
            Menu_Edit.Font = new Font ("Segoe UI", 9F);
            Menu_Edit.ForeColor = Color.DarkGoldenrod;
            Menu_Edit.Name = "Menu_Edit";
            Menu_Edit.ShortcutKeys = Keys.F2;
            Menu_Edit.Size = new Size (178, 22);
            Menu_Edit.Text = "Edit ...";
            Menu_Edit.Click += Menu_Edit_Click;
            // 
            // Menu_Locate
            // 
            Menu_Locate.Name = "Menu_Locate";
            Menu_Locate.Size = new Size (178, 22);
            Menu_Locate.Text = "Locate";
            Menu_Locate.Click += Menu_Locate_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (175, 6);
            // 
            // Menu_SaveACopy
            // 
            Menu_SaveACopy.Name = "Menu_SaveACopy";
            Menu_SaveACopy.ShortcutKeys =  Keys.Control | Keys.S;
            Menu_SaveACopy.Size = new Size (178, 22);
            Menu_SaveACopy.Text = "Save a Copy";
            Menu_SaveACopy.Click += Menu_SaveACopy_Click;
            // 
            // Menu_OpenSaveFolder
            // 
            Menu_OpenSaveFolder.Name = "Menu_OpenSaveFolder";
            Menu_OpenSaveFolder.Size = new Size (178, 22);
            Menu_OpenSaveFolder.Text = "SaveAs Folder";
            Menu_OpenSaveFolder.Click += Menu_OpenSaveFolder_Click;
            // 
            // Menu_Email
            // 
            Menu_Email.Enabled = false;
            Menu_Email.Name = "Menu_Email";
            Menu_Email.Size = new Size (178, 22);
            Menu_Email.Text = "Email";
            Menu_Email.Click += Menu_Email_Click;
            // 
            // ToolStripMenuItem3
            // 
            ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            ToolStripMenuItem3.Size = new Size (175, 6);
            // 
            // Menu_Delete
            // 
            Menu_Delete.Font = new Font ("Segoe UI", 9F);
            Menu_Delete.ForeColor = Color.IndianRed;
            Menu_Delete.Name = "Menu_Delete";
            Menu_Delete.Size = new Size (178, 22);
            Menu_Delete.Text = "Delete";
            Menu_Delete.Click += Menu_Delete_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.ShortcutKeys =  Keys.Control | Keys.Q;
            Menu_Cancel.Size = new Size (178, 22);
            Menu_Cancel.Text = "Exit";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.LightCoral;
            lblExit.Dock = DockStyle.Right;
            lblExit.Font = new Font ("Segoe UI", 10F);
            lblExit.ForeColor = Color.White;
            lblExit.Location = new Point (1175, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (75, 18);
            lblExit.TabIndex = 159;
            lblExit.Text = "Cancel";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblOpenRead);
            panel1.Controls.Add (lblExit);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 99);
            panel1.Name = "panel1";
            panel1.Size = new Size (1250, 18);
            panel1.TabIndex = 160;
            // 
            // lblOpenRead
            // 
            lblOpenRead.BackColor = Color.DarkSeaGreen;
            lblOpenRead.Dock = DockStyle.Left;
            lblOpenRead.Font = new Font ("Segoe UI", 10F);
            lblOpenRead.ForeColor = SystemColors.ButtonHighlight;
            lblOpenRead.ImeMode = ImeMode.NoControl;
            lblOpenRead.Location = new Point (0, 0);
            lblOpenRead.Name = "lblOpenRead";
            lblOpenRead.Size = new Size (1159, 18);
            lblOpenRead.TabIndex = 0;
            lblOpenRead.Text = "Open...";
            lblOpenRead.TextAlign = ContentAlignment.MiddleCenter;
            lblOpenRead.Click += lblOpenRead_Click;
            // 
            // frmReadRef
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb (  251,   251,   251);
            ClientSize = new Size (1250, 117);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (ListPaths);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReadRef";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Instances of the Document:";
            Load += frmReadRef_Load;
            ContextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ListBox ListPaths;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_Read;
        internal ToolStripMenuItem Menu_SaveACopy;
        internal ToolStripMenuItem Menu_OpenSaveFolder;
        internal ToolStripMenuItem Menu_Edit;
        internal ToolStripMenuItem Menu_Delete;
        internal ToolStripMenuItem Menu_Locate;
        internal ToolStripMenuItem Menu_Email;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_Cancel;
        internal ToolStripSeparator ToolStripMenuItem3;
        private Label lblExit;
        private Panel panel1;
        private Label lblOpenRead;
        }
}