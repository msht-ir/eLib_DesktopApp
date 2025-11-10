using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmScan : Form
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
            lbl_P = new Label ();
            lblFolderPapers = new Label ();
            lblFolderBooks = new Label ();
            lbl_B = new Label ();
            lblFolderManuals = new Label ();
            lbl_M = new Label ();
            lblFolderLectures = new Label ();
            lbl_L = new Label ();
            lblFolderSaveACopy = new Label ();
            lbl_S = new Label ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_Scan = new ToolStripMenuItem ();
            Menu_Exit = new ToolStripMenuItem ();
            lblStatus = new Label ();
            FolderBrowserDialog1 = new FolderBrowserDialog ();
            panel1 = new Panel ();
            lblScan = new Label ();
            lblExit = new Label ();
            ContextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // lbl_P
            // 
            lbl_P.AutoSize = true;
            lbl_P.Font = new Font ("Consolas", 11.25F);
            lbl_P.ForeColor = Color.IndianRed;
            lbl_P.Location = new Point (78, 36);
            lbl_P.Name = "lbl_P";
            lbl_P.Size = new Size (56, 18);
            lbl_P.TabIndex = 1;
            lbl_P.Text = "Papers";
            lbl_P.Click += lbl_P_Click;
            // 
            // lblFolderPapers
            // 
            lblFolderPapers.AutoSize = true;
            lblFolderPapers.Font = new Font ("Consolas", 11.25F, FontStyle.Italic);
            lblFolderPapers.ForeColor = SystemColors.ControlDarkDark;
            lblFolderPapers.Location = new Point (175, 36);
            lblFolderPapers.Name = "lblFolderPapers";
            lblFolderPapers.Size = new Size (152, 18);
            lblFolderPapers.TabIndex = 2;
            lblFolderPapers.Text = "eLib Papers Folder";
            // 
            // lblFolderBooks
            // 
            lblFolderBooks.AutoSize = true;
            lblFolderBooks.Font = new Font ("Consolas", 11.25F, FontStyle.Italic);
            lblFolderBooks.ForeColor = SystemColors.ControlDarkDark;
            lblFolderBooks.Location = new Point (175, 75);
            lblFolderBooks.Name = "lblFolderBooks";
            lblFolderBooks.Size = new Size (144, 18);
            lblFolderBooks.TabIndex = 4;
            lblFolderBooks.Text = "eLib Books Folder";
            // 
            // lbl_B
            // 
            lbl_B.AutoSize = true;
            lbl_B.Font = new Font ("Consolas", 11.25F);
            lbl_B.ForeColor = Color.IndianRed;
            lbl_B.Location = new Point (86, 75);
            lbl_B.Name = "lbl_B";
            lbl_B.Size = new Size (48, 18);
            lbl_B.TabIndex = 3;
            lbl_B.Text = "Books";
            lbl_B.Click += lbl_B_Click;
            // 
            // lblFolderManuals
            // 
            lblFolderManuals.AutoSize = true;
            lblFolderManuals.Font = new Font ("Consolas", 11.25F, FontStyle.Italic);
            lblFolderManuals.ForeColor = SystemColors.ControlDarkDark;
            lblFolderManuals.Location = new Point (175, 120);
            lblFolderManuals.Name = "lblFolderManuals";
            lblFolderManuals.Size = new Size (160, 18);
            lblFolderManuals.TabIndex = 6;
            lblFolderManuals.Text = "eLib Manuals Folder";
            // 
            // lbl_M
            // 
            lbl_M.AutoSize = true;
            lbl_M.Font = new Font ("Consolas", 11.25F);
            lbl_M.ForeColor = Color.IndianRed;
            lbl_M.Location = new Point (70, 120);
            lbl_M.Name = "lbl_M";
            lbl_M.Size = new Size (64, 18);
            lbl_M.TabIndex = 5;
            lbl_M.Text = "Manuals";
            lbl_M.Click += lbl_M_Click;
            // 
            // lblFolderLectures
            // 
            lblFolderLectures.AutoSize = true;
            lblFolderLectures.Font = new Font ("Consolas", 11.25F, FontStyle.Italic);
            lblFolderLectures.ForeColor = SystemColors.ControlDarkDark;
            lblFolderLectures.Location = new Point (175, 162);
            lblFolderLectures.Name = "lblFolderLectures";
            lblFolderLectures.Size = new Size (168, 18);
            lblFolderLectures.TabIndex = 8;
            lblFolderLectures.Text = "eLib Lectures Folder";
            // 
            // lbl_L
            // 
            lbl_L.AutoSize = true;
            lbl_L.Font = new Font ("Consolas", 11.25F);
            lbl_L.ForeColor = Color.IndianRed;
            lbl_L.Location = new Point (62, 162);
            lbl_L.Name = "lbl_L";
            lbl_L.Size = new Size (72, 18);
            lbl_L.TabIndex = 7;
            lbl_L.Text = "Lectures";
            lbl_L.Click += lbl_L_Click;
            // 
            // lblFolderSaveACopy
            // 
            lblFolderSaveACopy.AutoSize = true;
            lblFolderSaveACopy.Font = new Font ("Consolas", 11.25F, FontStyle.Italic);
            lblFolderSaveACopy.ForeColor = SystemColors.ControlDarkDark;
            lblFolderSaveACopy.Location = new Point (175, 206);
            lblFolderSaveACopy.Name = "lblFolderSaveACopy";
            lblFolderSaveACopy.Size = new Size (176, 18);
            lblFolderSaveACopy.TabIndex = 10;
            lblFolderSaveACopy.Text = "eLib SaveACopy Folder";
            // 
            // lbl_S
            // 
            lbl_S.AutoSize = true;
            lbl_S.Font = new Font ("Consolas", 11.25F);
            lbl_S.ForeColor = Color.IndianRed;
            lbl_S.Location = new Point (38, 206);
            lbl_S.Name = "lbl_S";
            lbl_S.Size = new Size (96, 18);
            lbl_S.TabIndex = 9;
            lbl_S.Text = "Save a copy";
            lbl_S.Click += lbl_S_Click;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_Scan, Menu_Exit });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size (137, 48);
            // 
            // Menu_Scan
            // 
            Menu_Scan.Name = "Menu_Scan";
            Menu_Scan.ShortcutKeys = Keys.F5;
            Menu_Scan.Size = new Size (136, 22);
            Menu_Scan.Text = "Scan";
            Menu_Scan.Click += Menu_Scan_Click;
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.ShortcutKeys =  Keys.Control | Keys.Q;
            Menu_Exit.Size = new Size (136, 22);
            Menu_Exit.Text = "Exit";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = SystemColors.ControlLightLight;
            lblStatus.Font = new Font ("Segoe UI", 12F);
            lblStatus.ForeColor = Color.IndianRed;
            lblStatus.Location = new Point (0, 243);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size (561, 20);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "-";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Click += lblStatus_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblScan);
            panel1.Controls.Add (lblExit);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 270);
            panel1.Name = "panel1";
            panel1.Size = new Size (571, 18);
            panel1.TabIndex = 151;
            // 
            // lblScan
            // 
            lblScan.BackColor = Color.CornflowerBlue;
            lblScan.Dock = DockStyle.Left;
            lblScan.Font = new Font ("Consolas", 10F);
            lblScan.ForeColor = SystemColors.ControlLightLight;
            lblScan.Location = new Point (0, 0);
            lblScan.Name = "lblScan";
            lblScan.Size = new Size (416, 18);
            lblScan.TabIndex = 11;
            lblScan.Text = "Scan";
            lblScan.TextAlign = ContentAlignment.MiddleCenter;
            lblScan.Click += lblScan_Click;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.WhiteSmoke;
            lblExit.Dock = DockStyle.Right;
            lblExit.Font = new Font ("Consolas", 10F);
            lblExit.ForeColor = Color.IndianRed;
            lblExit.Location = new Point (443, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (128, 18);
            lblExit.TabIndex = 10;
            lblExit.Text = "Back";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // frmScan
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size (571, 288);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (lblStatus);
            Controls.Add (panel1);
            Controls.Add (lblFolderSaveACopy);
            Controls.Add (lbl_S);
            Controls.Add (lblFolderLectures);
            Controls.Add (lbl_L);
            Controls.Add (lblFolderManuals);
            Controls.Add (lbl_M);
            Controls.Add (lblFolderBooks);
            Controls.Add (lbl_B);
            Controls.Add (lblFolderPapers);
            Controls.Add (lbl_P);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmScan";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Scan";
            Load += frmScan_Load;
            KeyDown += frmScan_KeyDown;
            ContextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal Label lbl_P;
        internal Label lblFolderPapers;
        internal Label lblFolderBooks;
        internal Label lbl_B;
        internal Label lblFolderManuals;
        internal Label lbl_M;
        internal Label lblFolderLectures;
        internal Label lbl_L;
        internal Label lblFolderSaveACopy;
        internal Label lbl_S;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_Scan;
        internal ToolStripMenuItem Menu_Exit;
        internal Label lblStatus;
        internal FolderBrowserDialog FolderBrowserDialog1;
        private Panel panel1;
        private Label lblScan;
        private Label lblExit;
        }
}