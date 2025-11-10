namespace eLib.Forms
    {
    partial class frmBackup
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode ("Title of Papers");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode ("Title of Books");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode ("Title of Lectures");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode ("Title of Manuals");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode ("Refs", new System.Windows.Forms.TreeNode [] { treeNode1, treeNode2, treeNode3, treeNode4 });
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode ("List of Projects");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode ("List of subProjects");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode ("Projects", new System.Windows.Forms.TreeNode [] { treeNode6, treeNode7 });
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode ("Projects");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode ("subProjects");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode ("Links (assignments)");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode ("Link notes");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode ("Links", new System.Windows.Forms.TreeNode [] { treeNode9, treeNode10, treeNode11, treeNode12 });
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode ("SubProject Notes");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode ("Link Notes");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode ("Ref Notes");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode ("NoteNet (Mindmap)");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode ("Notes", new System.Windows.Forms.TreeNode [] { treeNode14, treeNode15, treeNode16, treeNode17 });
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode ("Courses");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode ("Exams");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode ("Tests");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode ("TestBank", new System.Windows.Forms.TreeNode [] { treeNode19, treeNode20, treeNode21 });
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode ("eLib data", new System.Windows.Forms.TreeNode [] { treeNode5, treeNode8, treeNode13, treeNode18, treeNode22 });
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu_Select = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Cancel = new System.Windows.Forms.ToolStripMenuItem ();
            treeView1 = new System.Windows.Forms.TreeView ();
            panel1 = new System.Windows.Forms.Panel ();
            lblBackup = new System.Windows.Forms.Label ();
            lblCancel = new System.Windows.Forms.Label ();
            contextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_Select, Menu_Cancel });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size (133, 48);
            // 
            // Menu_Select
            // 
            Menu_Select.Name = "Menu_Select";
            Menu_Select.ShortcutKeys = System.Windows.Forms.Keys.F5;
            Menu_Select.Size = new System.Drawing.Size (132, 22);
            Menu_Select.Text = "Backup";
            Menu_Select.Click += Menu_Select_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = System.Drawing.Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.Size = new System.Drawing.Size (132, 22);
            Menu_Cancel.Text = "Cancel";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // treeView1
            // 
            treeView1.BackColor = System.Drawing.Color.WhiteSmoke;
            treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            treeView1.Dock = System.Windows.Forms.DockStyle.Top;
            treeView1.Font = new System.Drawing.Font ("Segoe UI", 12F);
            treeView1.Location = new System.Drawing.Point (0, 0);
            treeView1.Name = "treeView1";
            treeNode1.ForeColor = System.Drawing.Color.Gray;
            treeNode1.Name = "Node7";
            treeNode1.Text = "Title of Papers";
            treeNode2.ForeColor = System.Drawing.Color.Gray;
            treeNode2.Name = "Node8";
            treeNode2.Text = "Title of Books";
            treeNode3.ForeColor = System.Drawing.Color.Gray;
            treeNode3.Name = "Node9";
            treeNode3.Text = "Title of Lectures";
            treeNode4.ForeColor = System.Drawing.Color.Gray;
            treeNode4.Name = "Node10";
            treeNode4.Text = "Title of Manuals";
            treeNode5.ForeColor = System.Drawing.Color.RoyalBlue;
            treeNode5.Name = "NodeFile";
            treeNode5.NodeFont = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            treeNode5.Text = "Refs";
            treeNode6.ForeColor = System.Drawing.Color.Gray;
            treeNode6.Name = "Node5";
            treeNode6.Text = "List of Projects";
            treeNode7.ForeColor = System.Drawing.Color.Gray;
            treeNode7.Name = "Node6";
            treeNode7.Text = "List of subProjects";
            treeNode8.ForeColor = System.Drawing.Color.RoyalBlue;
            treeNode8.Name = "NodeProject";
            treeNode8.NodeFont = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            treeNode8.Text = "Projects";
            treeNode9.ForeColor = System.Drawing.Color.Gray;
            treeNode9.Name = "Node1";
            treeNode9.Text = "Projects";
            treeNode10.ForeColor = System.Drawing.Color.Gray;
            treeNode10.Name = "Node11";
            treeNode10.Text = "subProjects";
            treeNode11.ForeColor = System.Drawing.Color.Gray;
            treeNode11.Name = "Node12";
            treeNode11.Text = "Links (assignments)";
            treeNode12.ForeColor = System.Drawing.Color.Gray;
            treeNode12.Name = "Node13";
            treeNode12.Text = "Link notes";
            treeNode13.ForeColor = System.Drawing.Color.RoyalBlue;
            treeNode13.Name = "Node3";
            treeNode13.NodeFont = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            treeNode13.Text = "Links";
            treeNode14.ForeColor = System.Drawing.Color.Gray;
            treeNode14.Name = "Node2";
            treeNode14.Text = "SubProject Notes";
            treeNode15.ForeColor = System.Drawing.Color.Gray;
            treeNode15.Name = "Node14";
            treeNode15.Text = "Link Notes";
            treeNode16.ForeColor = System.Drawing.Color.Gray;
            treeNode16.Name = "Node15";
            treeNode16.Text = "Ref Notes";
            treeNode17.ForeColor = System.Drawing.Color.Gray;
            treeNode17.Name = "Node16";
            treeNode17.Text = "NoteNet (Mindmap)";
            treeNode18.ForeColor = System.Drawing.Color.RoyalBlue;
            treeNode18.Name = "Node4";
            treeNode18.NodeFont = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            treeNode18.Text = "Notes";
            treeNode19.ForeColor = System.Drawing.Color.Gray;
            treeNode19.Name = "Node18";
            treeNode19.Text = "Courses";
            treeNode20.ForeColor = System.Drawing.Color.Gray;
            treeNode20.Name = "Node19";
            treeNode20.Text = "Exams";
            treeNode21.ForeColor = System.Drawing.Color.Gray;
            treeNode21.Name = "Node20";
            treeNode21.Text = "Tests";
            treeNode22.ForeColor = System.Drawing.Color.RoyalBlue;
            treeNode22.Name = "Node17";
            treeNode22.NodeFont = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            treeNode22.Text = "TestBank";
            treeNode23.ForeColor = System.Drawing.Color.FromArgb (  192,   0,   0);
            treeNode23.Name = "Node0";
            treeNode23.NodeFont = new System.Drawing.Font ("Microsoft Sans Serif", 10F);
            treeNode23.Text = "eLib data";
            treeView1.Nodes.AddRange (new System.Windows.Forms.TreeNode [] { treeNode23 });
            treeView1.ShowLines = false;
            treeView1.Size = new System.Drawing.Size (374, 564);
            treeView1.TabIndex = 1;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Window;
            panel1.Controls.Add (lblBackup);
            panel1.Controls.Add (lblCancel);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 591);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (374, 20);
            panel1.TabIndex = 29;
            // 
            // lblBackup
            // 
            lblBackup.BackColor = System.Drawing.Color.CornflowerBlue;
            lblBackup.Dock = System.Windows.Forms.DockStyle.Left;
            lblBackup.Font = new System.Drawing.Font ("Consolas", 10F);
            lblBackup.ForeColor = System.Drawing.Color.White;
            lblBackup.Location = new System.Drawing.Point (0, 0);
            lblBackup.Name = "lblBackup";
            lblBackup.Size = new System.Drawing.Size (263, 20);
            lblBackup.TabIndex = 27;
            lblBackup.Text = "Backup";
            lblBackup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblBackup.Click += lblBackup_Click;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            lblCancel.Dock = System.Windows.Forms.DockStyle.Right;
            lblCancel.Font = new System.Drawing.Font ("Consolas", 10F);
            lblCancel.ForeColor = System.Drawing.Color.IndianRed;
            lblCancel.Location = new System.Drawing.Point (273, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new System.Drawing.Size (101, 20);
            lblCancel.TabIndex = 26;
            lblCancel.Text = "Cancel";
            lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // frmBackup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size (374, 611);
            ContextMenuStrip = contextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (treeView1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmBackup";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Backup settings";
            TopMost = true;
            Load += frmBackup_Load;
            contextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Select;
        private System.Windows.Forms.ToolStripMenuItem Menu_Cancel;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBackup;
        private System.Windows.Forms.Label lblCancel;
        }
    }