using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmChooseProject : Form
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
            ListProj = new ListBox ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu1_OK = new ToolStripMenuItem ();
            Menu1_NewProject = new ToolStripMenuItem ();
            toolStripMenuItem2 = new ToolStripSeparator ();
            Menu1_Active = new ToolStripMenuItem ();
            Menu1_Inactive = new ToolStripMenuItem ();
            Menu1_All = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu1_Cancel = new ToolStripMenuItem ();
            ListProd = new ListBox ();
            ContextMenuStrip2 = new ContextMenuStrip (components);
            Menu2_OK = new ToolStripMenuItem ();
            Menu2_NewSubProject = new ToolStripMenuItem ();
            toolStripMenuItem3 = new ToolStripSeparator ();
            Menu2_Cancel = new ToolStripMenuItem ();
            TextBoxProdNote = new TextBox ();
            txtSearchProj = new TextBox ();
            lblExit = new Label ();
            lblProject = new Label ();
            lblSubProject = new Label ();
            ContextMenuStrip1.SuspendLayout ();
            ContextMenuStrip2.SuspendLayout ();
            SuspendLayout ();
            // 
            // ListProj
            // 
            ListProj.BackColor = Color.FromArgb (  243,   243,   243);
            ListProj.BorderStyle = BorderStyle.None;
            ListProj.ContextMenuStrip = ContextMenuStrip1;
            ListProj.Font = new Font ("Segoe UI", 10F);
            ListProj.FormattingEnabled = true;
            ListProj.ItemHeight = 17;
            ListProj.Location = new Point (12, 39);
            ListProj.Margin = new Padding (4);
            ListProj.Name = "ListProj";
            ListProj.Size = new Size (304, 340);
            ListProj.TabIndex = 0;
            ListProj.Click += ListProj_Click;
            ListProj.DoubleClick += ListProj_DoubleClick;
            ListProj.KeyDown += ListProj_KeyDown;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu1_OK, Menu1_NewProject, toolStripMenuItem2, Menu1_Active, Menu1_Inactive, Menu1_All, ToolStripMenuItem1, Menu1_Cancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size (173, 148);
            // 
            // Menu1_OK
            // 
            Menu1_OK.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            Menu1_OK.ForeColor = SystemColors.HotTrack;
            Menu1_OK.Name = "Menu1_OK";
            Menu1_OK.ShortcutKeys = Keys.F3;
            Menu1_OK.Size = new Size (172, 22);
            Menu1_OK.Text = "Select Project";
            Menu1_OK.Click += Menu1_OK_Click;
            // 
            // Menu1_NewProject
            // 
            Menu1_NewProject.Name = "Menu1_NewProject";
            Menu1_NewProject.Size = new Size (172, 22);
            Menu1_NewProject.Text = "New Project...";
            Menu1_NewProject.Click += Menu1_NewProject_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size (169, 6);
            // 
            // Menu1_Active
            // 
            Menu1_Active.Checked = true;
            Menu1_Active.CheckState = CheckState.Checked;
            Menu1_Active.Name = "Menu1_Active";
            Menu1_Active.Size = new Size (172, 22);
            Menu1_Active.Text = "Active";
            Menu1_Active.Click += Menu1_Active_Click;
            // 
            // Menu1_Inactive
            // 
            Menu1_Inactive.Name = "Menu1_Inactive";
            Menu1_Inactive.Size = new Size (172, 22);
            Menu1_Inactive.Text = "Inactive";
            Menu1_Inactive.Click += Menu1_Inactive_Click;
            // 
            // Menu1_All
            // 
            Menu1_All.Name = "Menu1_All";
            Menu1_All.ShortcutKeys =  Keys.Control | Keys.A;
            Menu1_All.Size = new Size (172, 22);
            Menu1_All.Text = "All";
            Menu1_All.Click += Menu1_All_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (169, 6);
            // 
            // Menu1_Cancel
            // 
            Menu1_Cancel.ForeColor = Color.IndianRed;
            Menu1_Cancel.Name = "Menu1_Cancel";
            Menu1_Cancel.Size = new Size (172, 22);
            Menu1_Cancel.Text = "Cancel";
            Menu1_Cancel.Click += Menu1_Cancel_Click;
            // 
            // ListProd
            // 
            ListProd.BackColor = Color.FromArgb (  243,   243,   243);
            ListProd.BorderStyle = BorderStyle.None;
            ListProd.ContextMenuStrip = ContextMenuStrip2;
            ListProd.Font = new Font ("Segoe UI", 10F);
            ListProd.FormattingEnabled = true;
            ListProd.ItemHeight = 17;
            ListProd.Location = new Point (335, 39);
            ListProd.Margin = new Padding (4);
            ListProd.Name = "ListProd";
            ListProd.Size = new Size (304, 340);
            ListProd.TabIndex = 1;
            ListProd.TabStop = false;
            ListProd.Click += ListProd_Click;
            ListProd.DoubleClick += ListProd_DoubleClick;
            ListProd.KeyDown += ListProd_KeyDown;
            // 
            // ContextMenuStrip2
            // 
            ContextMenuStrip2.Items.AddRange (new ToolStripItem [] { Menu2_OK, Menu2_NewSubProject, toolStripMenuItem3, Menu2_Cancel });
            ContextMenuStrip2.Name = "ContextMenuStrip2";
            ContextMenuStrip2.Size = new Size (184, 76);
            // 
            // Menu2_OK
            // 
            Menu2_OK.Font = new Font ("Segoe UI", 9F);
            Menu2_OK.ForeColor = SystemColors.HotTrack;
            Menu2_OK.Name = "Menu2_OK";
            Menu2_OK.ShortcutKeys = Keys.F4;
            Menu2_OK.Size = new Size (183, 22);
            Menu2_OK.Text = "Select subProject";
            Menu2_OK.Click += Menu2_OK_Click;
            // 
            // Menu2_NewSubProject
            // 
            Menu2_NewSubProject.Name = "Menu2_NewSubProject";
            Menu2_NewSubProject.Size = new Size (183, 22);
            Menu2_NewSubProject.Text = "New SubProject...";
            Menu2_NewSubProject.Click += Menu2_NewSubProject_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size (180, 6);
            // 
            // Menu2_Cancel
            // 
            Menu2_Cancel.ForeColor = Color.IndianRed;
            Menu2_Cancel.Name = "Menu2_Cancel";
            Menu2_Cancel.Size = new Size (183, 22);
            Menu2_Cancel.Text = "Cancel";
            Menu2_Cancel.Click += Menu2_Cancel_Click;
            // 
            // TextBoxProdNote
            // 
            TextBoxProdNote.BackColor = SystemColors.ControlLightLight;
            TextBoxProdNote.BorderStyle = BorderStyle.None;
            TextBoxProdNote.Font = new Font ("Microsoft Sans Serif", 9F);
            TextBoxProdNote.ForeColor = Color.Teal;
            TextBoxProdNote.Location = new Point (12, 397);
            TextBoxProdNote.Margin = new Padding (4);
            TextBoxProdNote.Name = "TextBoxProdNote";
            TextBoxProdNote.Size = new Size (627, 14);
            TextBoxProdNote.TabIndex = 2;
            TextBoxProdNote.TabStop = false;
            TextBoxProdNote.TextAlign = HorizontalAlignment.Right;
            // 
            // txtSearchProj
            // 
            txtSearchProj.BackColor = Color.FromArgb (  246,   246,   246);
            txtSearchProj.BorderStyle = BorderStyle.None;
            txtSearchProj.Font = new Font ("Segoe UI", 10F, FontStyle.Italic);
            txtSearchProj.ForeColor = Color.IndianRed;
            txtSearchProj.Location = new Point (13, 8);
            txtSearchProj.Margin = new Padding (4);
            txtSearchProj.Name = "txtSearchProj";
            txtSearchProj.Size = new Size (626, 18);
            txtSearchProj.TabIndex = 0;
            txtSearchProj.TextAlign = HorizontalAlignment.Center;
            txtSearchProj.KeyDown += txtSearchProj_KeyDown;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.LightCoral;
            lblExit.Dock = DockStyle.Bottom;
            lblExit.Font = new Font ("Consolas", 10F);
            lblExit.ForeColor = Color.White;
            lblExit.Location = new Point (0, 429);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (645, 18);
            lblExit.TabIndex = 115;
            lblExit.Text = "Back";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // lblProject
            // 
            lblProject.BackColor = Color.CornflowerBlue;
            lblProject.Location = new Point (15, 383);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size (300, 3);
            lblProject.TabIndex = 141;
            lblProject.Visible = false;
            // 
            // lblSubProject
            // 
            lblSubProject.BackColor = Color.CornflowerBlue;
            lblSubProject.Location = new Point (337, 383);
            lblSubProject.Name = "lblSubProject";
            lblSubProject.Size = new Size (300, 3);
            lblSubProject.TabIndex = 142;
            lblSubProject.Visible = false;
            // 
            // frmChooseProject
            // 
            AutoScaleDimensions = new SizeF (9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size (645, 447);
            ControlBox = false;
            Controls.Add (lblSubProject);
            Controls.Add (lblProject);
            Controls.Add (lblExit);
            Controls.Add (txtSearchProj);
            Controls.Add (TextBoxProdNote);
            Controls.Add (ListProd);
            Controls.Add (ListProj);
            Font = new Font ("Microsoft Sans Serif", 11.25F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding (4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChooseProject";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Choose a Project / subProject";
            TopMost = true;
            Load += frmChooseProject_Load;
            KeyDown += frmChooseProject_KeyDown;
            ContextMenuStrip1.ResumeLayout (false);
            ContextMenuStrip2.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal ListBox ListProj;
        internal ListBox ListProd;
        internal TextBox TextBoxProdNote;
        internal TextBox txtSearchProj;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu1_Active;
        internal ToolStripMenuItem Menu1_Inactive;
        internal ToolStripMenuItem Menu1_All;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu1_Cancel;
        internal ToolStripMenuItem Menu1_OK;
        internal ContextMenuStrip ContextMenuStrip2;
        internal ToolStripMenuItem Menu2_OK;
        internal ToolStripMenuItem Menu2_Cancel;
        private Label lblExit;
        private ToolStripMenuItem Menu1_NewProject;
        private ToolStripMenuItem Menu2_NewSubProject;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem3;
        private Label lblProject;
        private Label lblSubProject;
        }
    }