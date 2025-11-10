using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmFolderRefs : Form
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
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_Read = new ToolStripMenuItem ();
            Menu_OpenFolder = new ToolStripMenuItem ();
            Menu_Assign = new ToolStripMenuItem ();
            Menu_CopyTitle = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu_Inverse = new ToolStripMenuItem ();
            Menu_None = new ToolStripMenuItem ();
            ToolStripMenuItem1 = new ToolStripSeparator ();
            Menu_ViewMode = new ToolStripMenuItem ();
            Menu_ViewList = new ToolStripMenuItem ();
            Menu_ViewTile = new ToolStripMenuItem ();
            Menu_Exit = new ToolStripMenuItem ();
            FolderBrowserDialog1 = new FolderBrowserDialog ();
            lblPath = new Label ();
            ContextMenuStrip2 = new ContextMenuStrip (components);
            Menu2_Papers = new ToolStripMenuItem ();
            Menu2_Books = new ToolStripMenuItem ();
            Menu2_Manuals = new ToolStripMenuItem ();
            Menu2_Lectures = new ToolStripMenuItem ();
            ToolStripMenuItem4 = new ToolStripSeparator ();
            Menu2_SelectFolderromDialog = new ToolStripMenuItem ();
            treeView1 = new TreeView ();
            panel1 = new Panel ();
            lblRead = new Label ();
            lblBack = new Label ();
            blLink = new Label ();
            ListPathx = new ListView ();
            panel2 = new Panel ();
            btnBrowse = new Label ();
            btnTileList = new Label ();
            ContextMenuStrip1.SuspendLayout ();
            ContextMenuStrip2.SuspendLayout ();
            panel1.SuspendLayout ();
            panel2.SuspendLayout ();
            SuspendLayout ();
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_Read, Menu_OpenFolder, Menu_Assign, Menu_CopyTitle, ToolStripMenuItem2, Menu_Inverse, Menu_None, ToolStripMenuItem1, Menu_ViewMode, Menu_Exit });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size (170, 192);
            // 
            // Menu_Read
            // 
            Menu_Read.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            Menu_Read.ForeColor = SystemColors.HotTrack;
            Menu_Read.Name = "Menu_Read";
            Menu_Read.ShortcutKeys = Keys.F2;
            Menu_Read.Size = new Size (169, 22);
            Menu_Read.Text = "Read ...";
            Menu_Read.Click += Menu_Read_Click;
            // 
            // Menu_OpenFolder
            // 
            Menu_OpenFolder.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            Menu_OpenFolder.ForeColor = Color.IndianRed;
            Menu_OpenFolder.Name = "Menu_OpenFolder";
            Menu_OpenFolder.ShortcutKeys =  Keys.Control | Keys.F;
            Menu_OpenFolder.Size = new Size (169, 22);
            Menu_OpenFolder.Text = "Folder ...";
            Menu_OpenFolder.Click += Menu_OpenFolder_Click;
            // 
            // Menu_Assign
            // 
            Menu_Assign.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            Menu_Assign.ForeColor = Color.SeaGreen;
            Menu_Assign.Name = "Menu_Assign";
            Menu_Assign.ShortcutKeys =  Keys.Control | Keys.L;
            Menu_Assign.Size = new Size (169, 22);
            Menu_Assign.Text = "Link ...";
            Menu_Assign.Click += Menu_Assign_Click;
            // 
            // Menu_CopyTitle
            // 
            Menu_CopyTitle.Name = "Menu_CopyTitle";
            Menu_CopyTitle.ShortcutKeys =  Keys.Control | Keys.C;
            Menu_CopyTitle.Size = new Size (169, 22);
            Menu_CopyTitle.Text = "Copy Title";
            Menu_CopyTitle.Click += Menu_CopyTitle_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (166, 6);
            // 
            // Menu_Inverse
            // 
            Menu_Inverse.Name = "Menu_Inverse";
            Menu_Inverse.ShortcutKeys =  Keys.Control | Keys.I;
            Menu_Inverse.Size = new Size (169, 22);
            Menu_Inverse.Text = "Inverse";
            Menu_Inverse.Click += Menu_Inverse_Click;
            // 
            // Menu_None
            // 
            Menu_None.Name = "Menu_None";
            Menu_None.ShortcutKeys =  Keys.Control | Keys.N;
            Menu_None.Size = new Size (169, 22);
            Menu_None.Text = "None";
            Menu_None.Click += Menu_None_Click;
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size (166, 6);
            // 
            // Menu_ViewMode
            // 
            Menu_ViewMode.DropDownItems.AddRange (new ToolStripItem [] { Menu_ViewList, Menu_ViewTile });
            Menu_ViewMode.Name = "Menu_ViewMode";
            Menu_ViewMode.Size = new Size (169, 22);
            Menu_ViewMode.Text = "View";
            // 
            // Menu_ViewList
            // 
            Menu_ViewList.Name = "Menu_ViewList";
            Menu_ViewList.Size = new Size (92, 22);
            Menu_ViewList.Text = "List";
            Menu_ViewList.Click += Menu_ViewList_Click;
            // 
            // Menu_ViewTile
            // 
            Menu_ViewTile.Name = "Menu_ViewTile";
            Menu_ViewTile.Size = new Size (92, 22);
            Menu_ViewTile.Text = "Tile";
            Menu_ViewTile.Click += Menu_ViewTile_Click;
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.ShortcutKeys =  Keys.Control | Keys.Q;
            Menu_Exit.Size = new Size (169, 22);
            Menu_Exit.Text = "Exit";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // lblPath
            // 
            lblPath.ContextMenuStrip = ContextMenuStrip2;
            lblPath.Dock = DockStyle.Fill;
            lblPath.Font = new Font ("Segoe UI", 11F);
            lblPath.ForeColor = Color.RoyalBlue;
            lblPath.Location = new Point (0, 0);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size (1129, 18);
            lblPath.TabIndex = 2;
            lblPath.Text = "Select folder ...";
            lblPath.TextAlign = ContentAlignment.MiddleCenter;
            lblPath.Click += lblPath_Click;
            // 
            // ContextMenuStrip2
            // 
            ContextMenuStrip2.Items.AddRange (new ToolStripItem [] { Menu2_Papers, Menu2_Books, Menu2_Manuals, Menu2_Lectures, ToolStripMenuItem4, Menu2_SelectFolderromDialog });
            ContextMenuStrip2.Name = "ContextMenuStrip2";
            ContextMenuStrip2.Size = new Size (166, 120);
            // 
            // Menu2_Papers
            // 
            Menu2_Papers.Name = "Menu2_Papers";
            Menu2_Papers.Size = new Size (165, 22);
            Menu2_Papers.Text = "Papers";
            Menu2_Papers.Click += Menu2_Papers_Click;
            // 
            // Menu2_Books
            // 
            Menu2_Books.Name = "Menu2_Books";
            Menu2_Books.Size = new Size (165, 22);
            Menu2_Books.Text = "Books";
            Menu2_Books.Click += Menu2_Books_Click;
            // 
            // Menu2_Manuals
            // 
            Menu2_Manuals.Name = "Menu2_Manuals";
            Menu2_Manuals.Size = new Size (165, 22);
            Menu2_Manuals.Text = "Manuals";
            Menu2_Manuals.Click += Menu2_Manuals_Click;
            // 
            // Menu2_Lectures
            // 
            Menu2_Lectures.Name = "Menu2_Lectures";
            Menu2_Lectures.Size = new Size (165, 22);
            Menu2_Lectures.Text = "Lectures";
            Menu2_Lectures.Click += Menu2_Lectures_Click;
            // 
            // ToolStripMenuItem4
            // 
            ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            ToolStripMenuItem4.Size = new Size (162, 6);
            // 
            // Menu2_SelectFolderromDialog
            // 
            Menu2_SelectFolderromDialog.ForeColor = Color.IndianRed;
            Menu2_SelectFolderromDialog.Name = "Menu2_SelectFolderromDialog";
            Menu2_SelectFolderromDialog.ShortcutKeys =  Keys.Control | Keys.B;
            Menu2_SelectFolderromDialog.Size = new Size (165, 22);
            Menu2_SelectFolderromDialog.Text = "Browse ...";
            Menu2_SelectFolderromDialog.Click += Menu2_SelectFolderromDialog_Click;
            // 
            // treeView1
            // 
            treeView1.BackColor = SystemColors.Control;
            treeView1.BorderStyle = BorderStyle.None;
            treeView1.ContextMenuStrip = ContextMenuStrip2;
            treeView1.Dock = DockStyle.Left;
            treeView1.Location = new Point (0, 18);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size (213, 602);
            treeView1.TabIndex = 4;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblRead);
            panel1.Controls.Add (lblBack);
            panel1.Controls.Add (blLink);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 620);
            panel1.Name = "panel1";
            panel1.Size = new Size (1294, 18);
            panel1.TabIndex = 118;
            // 
            // lblRead
            // 
            lblRead.BackColor = Color.CornflowerBlue;
            lblRead.Font = new Font ("Segoe UI", 10F);
            lblRead.ForeColor = Color.White;
            lblRead.Location = new Point (220, 0);
            lblRead.Name = "lblRead";
            lblRead.Size = new Size (903, 18);
            lblRead.TabIndex = 160;
            lblRead.Text = "Open...";
            lblRead.TextAlign = ContentAlignment.MiddleCenter;
            lblRead.Click += lblRead_Click;
            // 
            // lblBack
            // 
            lblBack.BackColor = Color.LightCoral;
            lblBack.Dock = DockStyle.Right;
            lblBack.Font = new Font ("Consolas", 10F);
            lblBack.ForeColor = Color.White;
            lblBack.Location = new Point (1129, 0);
            lblBack.Name = "lblBack";
            lblBack.Size = new Size (165, 18);
            lblBack.TabIndex = 22;
            lblBack.Text = "Back";
            lblBack.TextAlign = ContentAlignment.MiddleCenter;
            lblBack.Click += lblBack_Click;
            // 
            // blLink
            // 
            blLink.BackColor = Color.DarkSeaGreen;
            blLink.Dock = DockStyle.Left;
            blLink.Font = new Font ("Consolas", 10F);
            blLink.ForeColor = Color.White;
            blLink.Location = new Point (0, 0);
            blLink.Name = "blLink";
            blLink.Size = new Size (213, 18);
            blLink.TabIndex = 161;
            blLink.Text = "Link";
            blLink.TextAlign = ContentAlignment.MiddleCenter;
            blLink.Click += blLink_Click;
            // 
            // ListPathx
            // 
            ListPathx.BorderStyle = BorderStyle.None;
            ListPathx.CheckBoxes = true;
            ListPathx.ContextMenuStrip = ContextMenuStrip1;
            ListPathx.Font = new Font ("Segoe UI", 10F);
            ListPathx.Location = new Point (220, 33);
            ListPathx.Name = "ListPathx";
            ListPathx.Size = new Size (1074, 584);
            ListPathx.TabIndex = 119;
            ListPathx.TileSize = new Size (100, 100);
            ListPathx.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            panel2.Controls.Add (lblPath);
            panel2.Controls.Add (btnTileList);
            panel2.Controls.Add (btnBrowse);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point (0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size (1294, 18);
            panel2.TabIndex = 162;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.LightCoral;
            btnBrowse.Dock = DockStyle.Right;
            btnBrowse.Font = new Font ("Consolas", 10F);
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point (1204, 0);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size (90, 18);
            btnBrowse.TabIndex = 22;
            btnBrowse.Text = "Browse...";
            btnBrowse.TextAlign = ContentAlignment.MiddleCenter;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnTileList
            // 
            btnTileList.BackColor = Color.Gray;
            btnTileList.Dock = DockStyle.Right;
            btnTileList.Font = new Font ("Consolas", 10F);
            btnTileList.ForeColor = Color.White;
            btnTileList.Location = new Point (1129, 0);
            btnTileList.Name = "btnTileList";
            btnTileList.Size = new Size (75, 18);
            btnTileList.TabIndex = 161;
            btnTileList.Text = "Tile";
            btnTileList.TextAlign = ContentAlignment.MiddleCenter;
            btnTileList.Click += btnTileList_Click;
            // 
            // frmFolderRefs
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size (1294, 638);
            ControlBox = false;
            Controls.Add (ListPathx);
            Controls.Add (treeView1);
            Controls.Add (panel2);
            Controls.Add (panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFolderRefs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Explore";
            Load += frmFolderRefs_Load;
            ContextMenuStrip1.ResumeLayout (false);
            ContextMenuStrip2.ResumeLayout (false);
            panel1.ResumeLayout (false);
            panel2.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_Assign;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem Menu_Inverse;
        internal ToolStripMenuItem Menu_None;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem Menu_Exit;
        internal FolderBrowserDialog FolderBrowserDialog1;
        internal Label lblPath;
        internal ContextMenuStrip ContextMenuStrip2;
        internal ToolStripMenuItem Menu2_Papers;
        internal ToolStripMenuItem Menu2_Books;
        internal ToolStripMenuItem Menu2_Manuals;
        internal ToolStripMenuItem Menu2_Lectures;
        internal ToolStripSeparator ToolStripMenuItem4;
        internal ToolStripMenuItem Menu_Read;
        internal ToolStripMenuItem Menu_CopyTitle;
        private TreeView treeView1;
        private ToolStripMenuItem Menu2_SelectFolderromDialog;
        private Panel panel1;
        private Label lblBack;
        private Label lblRead;
        private ListView ListPathx;
        private ToolStripMenuItem Menu_OpenFolder;
        private Label blLink;
        private ToolStripMenuItem Menu_ViewMode;
        private ToolStripMenuItem Menu_ViewList;
        private ToolStripMenuItem Menu_ViewTile;
        private Panel panel2;
        private Label btnBrowse;
        private Label btnTileList;
        }
}