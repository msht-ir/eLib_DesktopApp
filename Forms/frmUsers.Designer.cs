using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmUsers : Form
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmUsers));
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_AddNewUser = new ToolStripMenuItem ();
            Menu_Tools = new ToolStripMenuItem ();
            MenuTools_Backup2 = new ToolStripMenuItem ();
            MenuTools_Restore = new ToolStripMenuItem ();
            ToolStripMenuItem4 = new ToolStripSeparator ();
            MenuTools_Settings = new ToolStripMenuItem ();
            ToolStripMenuItem5 = new ToolStripSeparator ();
            MenuTools_DeleteUser = new ToolStripMenuItem ();
            MenuTools_Clear = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu_LogOut = new ToolStripMenuItem ();
            GridUsers = new DataGridView ();
            lblInfo = new Label ();
            FolderBrowserDialog1 = new FolderBrowserDialog ();
            panel1 = new Panel ();
            lblNewUser = new Label ();
            lblLogOut = new Label ();
            lblQuit = new Label ();
            txtCmd = new TextBox ();
            lblSearch = new Label ();
            progressBar1 = new ProgressBar ();
            progressBar2 = new ProgressBar ();
            ContextMenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridUsers).BeginInit ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_AddNewUser, Menu_Tools, ToolStripMenuItem2, Menu_LogOut });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size (177, 76);
            // 
            // Menu_AddNewUser
            // 
            Menu_AddNewUser.Name = "Menu_AddNewUser";
            Menu_AddNewUser.ShortcutKeys =  Keys.Control | Keys.N;
            Menu_AddNewUser.Size = new Size (176, 22);
            Menu_AddNewUser.Text = "New User...";
            Menu_AddNewUser.Click += Menu_AddNewUser_Click;
            // 
            // Menu_Tools
            // 
            Menu_Tools.DropDownItems.AddRange (new ToolStripItem [] { MenuTools_Backup2, MenuTools_Restore, ToolStripMenuItem4, MenuTools_Settings, ToolStripMenuItem5, MenuTools_DeleteUser, MenuTools_Clear });
            Menu_Tools.Font = new Font ("Segoe UI", 9F);
            Menu_Tools.Name = "Menu_Tools";
            Menu_Tools.Size = new Size (176, 22);
            Menu_Tools.Text = "Tools";
            // 
            // MenuTools_Backup2
            // 
            MenuTools_Backup2.Name = "MenuTools_Backup2";
            MenuTools_Backup2.Size = new Size (156, 22);
            MenuTools_Backup2.Text = "Backup";
            MenuTools_Backup2.Click += MenuTools_Backup2_Click;
            // 
            // MenuTools_Restore
            // 
            MenuTools_Restore.Name = "MenuTools_Restore";
            MenuTools_Restore.Size = new Size (156, 22);
            MenuTools_Restore.Text = "Restore";
            MenuTools_Restore.Click += MenuTools_Restore_Click;
            // 
            // ToolStripMenuItem4
            // 
            ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            ToolStripMenuItem4.Size = new Size (153, 6);
            // 
            // MenuTools_Settings
            // 
            MenuTools_Settings.Font = new Font ("Segoe UI", 9F);
            MenuTools_Settings.Name = "MenuTools_Settings";
            MenuTools_Settings.ShortcutKeys =  Keys.Control | Keys.T;
            MenuTools_Settings.Size = new Size (156, 22);
            MenuTools_Settings.Text = "Settings";
            MenuTools_Settings.Click += MenuTools_Settings_Click;
            // 
            // ToolStripMenuItem5
            // 
            ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            ToolStripMenuItem5.Size = new Size (153, 6);
            // 
            // MenuTools_DeleteUser
            // 
            MenuTools_DeleteUser.Font = new Font ("Segoe UI", 9F);
            MenuTools_DeleteUser.ForeColor = Color.IndianRed;
            MenuTools_DeleteUser.Name = "MenuTools_DeleteUser";
            MenuTools_DeleteUser.Size = new Size (156, 22);
            MenuTools_DeleteUser.Text = "Delete";
            MenuTools_DeleteUser.Click += MenuTools_DeleteUser_Click;
            // 
            // MenuTools_Clear
            // 
            MenuTools_Clear.Font = new Font ("Segoe UI", 9F);
            MenuTools_Clear.ForeColor = Color.IndianRed;
            MenuTools_Clear.Name = "MenuTools_Clear";
            MenuTools_Clear.Size = new Size (156, 22);
            MenuTools_Clear.Text = "Clear";
            MenuTools_Clear.Click += MenuTools_Clear_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            ToolStripMenuItem2.Size = new Size (173, 6);
            // 
            // Menu_LogOut
            // 
            Menu_LogOut.Font = new Font ("Segoe UI", 9F);
            Menu_LogOut.ForeColor = Color.IndianRed;
            Menu_LogOut.Name = "Menu_LogOut";
            Menu_LogOut.ShortcutKeys =  Keys.Control | Keys.Q;
            Menu_LogOut.Size = new Size (176, 22);
            Menu_LogOut.Text = "Log out";
            Menu_LogOut.Click += Menu_LogOut_Click;
            // 
            // GridUsers
            // 
            GridUsers.AllowUserToAddRows = false;
            GridUsers.AllowUserToDeleteRows = false;
            GridUsers.AllowUserToResizeColumns = false;
            GridUsers.AllowUserToResizeRows = false;
            GridUsers.BackgroundColor = SystemColors.Control;
            GridUsers.BorderStyle = BorderStyle.None;
            GridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridUsers.DefaultCellStyle = dataGridViewCellStyle1;
            GridUsers.Dock = DockStyle.Top;
            GridUsers.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridUsers.GridColor = SystemColors.Control;
            GridUsers.Location = new Point (0, 0);
            GridUsers.Name = "GridUsers";
            GridUsers.RowHeadersVisible = false;
            GridUsers.RowHeadersWidth = 15;
            GridUsers.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GridUsers.Size = new Size (1267, 198);
            GridUsers.TabIndex = 0;
            GridUsers.TabStop = false;
            GridUsers.CellDoubleClick += GridUsers_CellDoubleClick;
            // 
            // lblInfo
            // 
            lblInfo.BackColor = SystemColors.ControlLightLight;
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.Font = new Font ("Segoe UI", 9F);
            lblInfo.ForeColor = Color.IndianRed;
            lblInfo.Location = new Point (189, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size (902, 22);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "-";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblInfo);
            panel1.Controls.Add (lblNewUser);
            panel1.Controls.Add (lblLogOut);
            panel1.Controls.Add (lblQuit);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 263);
            panel1.Name = "panel1";
            panel1.Size = new Size (1267, 22);
            panel1.TabIndex = 28;
            // 
            // lblNewUser
            // 
            lblNewUser.BackColor = Color.CornflowerBlue;
            lblNewUser.Dock = DockStyle.Left;
            lblNewUser.Font = new Font ("Consolas", 10F);
            lblNewUser.ForeColor = Color.White;
            lblNewUser.Location = new Point (0, 0);
            lblNewUser.Name = "lblNewUser";
            lblNewUser.Size = new Size (189, 22);
            lblNewUser.TabIndex = 27;
            lblNewUser.Text = "New User";
            lblNewUser.TextAlign = ContentAlignment.MiddleCenter;
            lblNewUser.Click += lblNewUser_Click;
            // 
            // lblLogOut
            // 
            lblLogOut.BackColor = Color.LightCoral;
            lblLogOut.Dock = DockStyle.Right;
            lblLogOut.Font = new Font ("Consolas", 10F);
            lblLogOut.ForeColor = Color.White;
            lblLogOut.Location = new Point (1091, 0);
            lblLogOut.Name = "lblLogOut";
            lblLogOut.Size = new Size (88, 22);
            lblLogOut.TabIndex = 26;
            lblLogOut.Text = "Logout";
            lblLogOut.TextAlign = ContentAlignment.MiddleCenter;
            lblLogOut.Click += lblLogOut_Click;
            // 
            // lblQuit
            // 
            lblQuit.BackColor = Color.Gray;
            lblQuit.Dock = DockStyle.Right;
            lblQuit.Font = new Font ("Consolas", 10F);
            lblQuit.ForeColor = Color.White;
            lblQuit.Location = new Point (1179, 0);
            lblQuit.Name = "lblQuit";
            lblQuit.Size = new Size (88, 22);
            lblQuit.TabIndex = 28;
            lblQuit.Text = "Quit";
            lblQuit.TextAlign = ContentAlignment.MiddleCenter;
            lblQuit.Click += lblQuit_Click;
            // 
            // txtCmd
            // 
            txtCmd.BackColor = SystemColors.ControlLightLight;
            txtCmd.BorderStyle = BorderStyle.None;
            txtCmd.Font = new Font ("Segoe UI", 10F);
            txtCmd.ForeColor = Color.Teal;
            txtCmd.Location = new Point (60, 204);
            txtCmd.Name = "txtCmd";
            txtCmd.Size = new Size (1183, 18);
            txtCmd.TabIndex = 0;
            txtCmd.TextChanged += txtCmd_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.BackColor = SystemColors.ControlLightLight;
            lblSearch.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.ForeColor = Color.SteelBlue;
            lblSearch.Location = new Point (0, 206);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size (50, 15);
            lblSearch.TabIndex = 148;
            lblSearch.Text = "cmd >";
            lblSearch.TextAlign = ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point (427, 226);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size (409, 10);
            progressBar1.TabIndex = 149;
            progressBar1.Visible = false;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point (427, 242);
            progressBar2.Maximum = 18;
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size (409, 10);
            progressBar2.TabIndex = 150;
            progressBar2.Visible = false;
            // 
            // frmUsers
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size (1267, 285);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (progressBar2);
            Controls.Add (progressBar1);
            Controls.Add (txtCmd);
            Controls.Add (lblSearch);
            Controls.Add (panel1);
            Controls.Add (GridUsers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Users setup";
            Load += frmUsers_Load;
            KeyDown += frmUsers_KeyDown;
            ContextMenuStrip1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridUsers).EndInit ();
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal ContextMenuStrip ContextMenuStrip1;
        internal DataGridView GridUsers;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem Menu_LogOut;
        internal Label lblInfo;
        internal ToolStripMenuItem Menu_Tools;
        internal ToolStripMenuItem MenuTools_DeleteUser;
        internal ToolStripMenuItem MenuTools_Clear;
        internal ToolStripMenuItem MenuTools_Settings;
        internal ToolStripSeparator ToolStripMenuItem4;
        internal ToolStripSeparator ToolStripMenuItem5;
        internal FolderBrowserDialog FolderBrowserDialog1;
        private ToolStripMenuItem Menu_AddNewUser;
        private ToolStripMenuItem MenuTools_Backup2;
        private ToolStripMenuItem MenuTools_Restore;
        private Panel panel1;
        private Label lblNewUser;
        private Label lblLogOut;
        internal TextBox txtCmd;
        internal Label lblSearch;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label lblQuit;
        }
    }