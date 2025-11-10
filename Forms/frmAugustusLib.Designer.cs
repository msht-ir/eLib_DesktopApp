using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
    {
    partial class frmAugustusLib : Form
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void  Dispose (bool disposing)
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
            lstSpecies = new ListBox ();
            contextMenuSpecies = new ContextMenuStrip (components);
            Menu_SelectProject = new ToolStripMenuItem ();
            toolStripMenuItem3 = new ToolStripSeparator ();
            Menu_AddSpecies = new ToolStripMenuItem ();
            Menu_EditSpecies = new ToolStripMenuItem ();
            Menu_DeleteSpecies = new ToolStripMenuItem ();
            toolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Draw = new ToolStripMenuItem ();
            lstCluster = new ListBox ();
            contextMenu_Cluster = new ContextMenuStrip (components);
            Menu_EditCluster = new ToolStripMenuItem ();
            Menu_DeleteCluster = new ToolStripMenuItem ();
            lstTranscript = new ListBox ();
            contextMenuTranscript = new ContextMenuStrip (components);
            Menu_EditTranscript = new ToolStripMenuItem ();
            toolStripMenuItem2 = new ToolStripSeparator ();
            Menu_DeleteDuplicateTranscripts = new ToolStripMenuItem ();
            txtSequenceData = new TextBox ();
            contextMenuStrip1 = new ContextMenuStrip (components);
            Menu_Project = new ToolStripMenuItem ();
            Menu_Exit = new ToolStripMenuItem ();
            label1 = new Label ();
            lblClusters = new Label ();
            label3 = new Label ();
            label4 = new Label ();
            lblProjectID = new Label ();
            panel1 = new Panel ();
            label2 = new Label ();
            contextMenuSpecies.SuspendLayout ();
            contextMenu_Cluster.SuspendLayout ();
            contextMenuTranscript.SuspendLayout ();
            contextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // lstSpecies
            // 
            lstSpecies.BackColor = Color.FromArgb (  246,   246,   246);
            lstSpecies.BorderStyle = BorderStyle.None;
            lstSpecies.ContextMenuStrip = contextMenuSpecies;
            lstSpecies.Font = new Font ("Segoe UI", 9F);
            lstSpecies.FormattingEnabled = true;
            lstSpecies.ItemHeight = 15;
            lstSpecies.Location = new Point (21, 49);
            lstSpecies.Name = "lstSpecies";
            lstSpecies.Size = new Size (344, 60);
            lstSpecies.TabIndex = 1;
            lstSpecies.Click += lstSpecies_Click;
            lstSpecies.DoubleClick += lstSpecies_DoubleClick;
            lstSpecies.KeyDown += lstSpecies_KeyDown;
            // 
            // contextMenuSpecies
            // 
            contextMenuSpecies.Items.AddRange (new ToolStripItem [] { Menu_SelectProject, toolStripMenuItem3, Menu_AddSpecies, Menu_EditSpecies, Menu_DeleteSpecies, toolStripMenuItem1, Menu_Draw });
            contextMenuSpecies.Name = "contextMenuSpecies";
            contextMenuSpecies.Size = new Size (162, 126);
            // 
            // Menu_SelectProject
            // 
            Menu_SelectProject.Name = "Menu_SelectProject";
            Menu_SelectProject.ShortcutKeys =  Keys.Control | Keys.P;
            Menu_SelectProject.Size = new Size (161, 22);
            Menu_SelectProject.Text = "Project...";
            Menu_SelectProject.Click += Menu_SelectProject_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size (158, 6);
            // 
            // Menu_AddSpecies
            // 
            Menu_AddSpecies.Name = "Menu_AddSpecies";
            Menu_AddSpecies.Size = new Size (161, 22);
            Menu_AddSpecies.Text = "Add Species...";
            Menu_AddSpecies.Click += Menu_AddSpecies_Click;
            // 
            // Menu_EditSpecies
            // 
            Menu_EditSpecies.Name = "Menu_EditSpecies";
            Menu_EditSpecies.Size = new Size (161, 22);
            Menu_EditSpecies.Text = "Rename";
            Menu_EditSpecies.Click += Menu_EditSpecies_Click;
            // 
            // Menu_DeleteSpecies
            // 
            Menu_DeleteSpecies.ForeColor = Color.IndianRed;
            Menu_DeleteSpecies.Name = "Menu_DeleteSpecies";
            Menu_DeleteSpecies.Size = new Size (161, 22);
            Menu_DeleteSpecies.Text = "Delete";
            Menu_DeleteSpecies.Click += Menu_DeleteSpecies_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size (158, 6);
            // 
            // Menu_Draw
            // 
            Menu_Draw.Name = "Menu_Draw";
            Menu_Draw.ShortcutKeys =  Keys.Control | Keys.D;
            Menu_Draw.Size = new Size (161, 22);
            Menu_Draw.Text = "Draw...";
            Menu_Draw.Click += Menu_Draw_Click;
            // 
            // lstCluster
            // 
            lstCluster.AllowDrop = true;
            lstCluster.BackColor = Color.FromArgb (  246,   246,   246);
            lstCluster.BorderStyle = BorderStyle.None;
            lstCluster.ContextMenuStrip = contextMenu_Cluster;
            lstCluster.FormattingEnabled = true;
            lstCluster.ItemHeight = 15;
            lstCluster.Location = new Point (21, 139);
            lstCluster.Name = "lstCluster";
            lstCluster.Size = new Size (344, 240);
            lstCluster.TabIndex = 2;
            lstCluster.Click += lstCluster_Click;
            lstCluster.DragDrop += lstCluster_DragDrop;
            lstCluster.DragEnter += lstCluster_DragEnter;
            lstCluster.DoubleClick += lstCluster_DoubleClick;
            lstCluster.KeyDown += lstCluster_KeyDown;
            // 
            // contextMenu_Cluster
            // 
            contextMenu_Cluster.Items.AddRange (new ToolStripItem [] { Menu_EditCluster, Menu_DeleteCluster });
            contextMenu_Cluster.Name = "contextMenu_Cluster";
            contextMenu_Cluster.Size = new Size (179, 48);
            // 
            // Menu_EditCluster
            // 
            Menu_EditCluster.Name = "Menu_EditCluster";
            Menu_EditCluster.Size = new Size (178, 22);
            Menu_EditCluster.Text = "Edit Cluster Name...";
            Menu_EditCluster.Click += Menu_EditCluster_Click;
            // 
            // Menu_DeleteCluster
            // 
            Menu_DeleteCluster.ForeColor = Color.IndianRed;
            Menu_DeleteCluster.Name = "Menu_DeleteCluster";
            Menu_DeleteCluster.ShortcutKeys = Keys.F9;
            Menu_DeleteCluster.Size = new Size (178, 22);
            Menu_DeleteCluster.Text = "Delete";
            Menu_DeleteCluster.Click += Menu_DeleteCluster_Click;
            // 
            // lstTranscript
            // 
            lstTranscript.AllowDrop = true;
            lstTranscript.BackColor = Color.FromArgb (  246,   246,   246);
            lstTranscript.BorderStyle = BorderStyle.None;
            lstTranscript.ContextMenuStrip = contextMenuTranscript;
            lstTranscript.Font = new Font ("Courier New", 9F);
            lstTranscript.FormattingEnabled = true;
            lstTranscript.ItemHeight = 15;
            lstTranscript.Location = new Point (21, 411);
            lstTranscript.Name = "lstTranscript";
            lstTranscript.Size = new Size (344, 165);
            lstTranscript.TabIndex = 3;
            lstTranscript.Click += lstTranscript_Click;
            lstTranscript.DoubleClick += lstTranscript_DoubleClick;
            lstTranscript.KeyDown += lstTranscript_KeyDown;
            // 
            // contextMenuTranscript
            // 
            contextMenuTranscript.Items.AddRange (new ToolStripItem [] { Menu_EditTranscript, toolStripMenuItem2, Menu_DeleteDuplicateTranscripts });
            contextMenuTranscript.Name = "contextMenuTranscript";
            contextMenuTranscript.Size = new Size (175, 54);
            // 
            // Menu_EditTranscript
            // 
            Menu_EditTranscript.Name = "Menu_EditTranscript";
            Menu_EditTranscript.Size = new Size (174, 22);
            Menu_EditTranscript.Text = "Edit Transcript...";
            Menu_EditTranscript.Click += Menu_EditTranscript_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size (171, 6);
            // 
            // Menu_DeleteDuplicateTranscripts
            // 
            Menu_DeleteDuplicateTranscripts.ForeColor = Color.IndianRed;
            Menu_DeleteDuplicateTranscripts.Name = "Menu_DeleteDuplicateTranscripts";
            Menu_DeleteDuplicateTranscripts.Size = new Size (174, 22);
            Menu_DeleteDuplicateTranscripts.Text = "Remove duplicates";
            Menu_DeleteDuplicateTranscripts.Click += Menu_DeleteDuplicateTranscripts_Click;
            // 
            // txtSequenceData
            // 
            txtSequenceData.AllowDrop = true;
            txtSequenceData.BackColor = Color.FromArgb (  246,   246,   246);
            txtSequenceData.BorderStyle = BorderStyle.None;
            txtSequenceData.ContextMenuStrip = contextMenuStrip1;
            txtSequenceData.Font = new Font ("Courier New", 10F);
            txtSequenceData.Location = new Point (386, 49);
            txtSequenceData.Multiline = true;
            txtSequenceData.Name = "txtSequenceData";
            txtSequenceData.ScrollBars = ScrollBars.Vertical;
            txtSequenceData.Size = new Size (871, 530);
            txtSequenceData.TabIndex = 4;
            txtSequenceData.DragDrop += txtSequenceData_DragDrop;
            txtSequenceData.DragEnter += txtSequenceData_DragEnter;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_Project, Menu_Exit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size (162, 48);
            // 
            // Menu_Project
            // 
            Menu_Project.Name = "Menu_Project";
            Menu_Project.ShortcutKeys =  Keys.Control | Keys.P;
            Menu_Project.Size = new Size (161, 22);
            Menu_Project.Text = "Project...";
            Menu_Project.Click += Menu_Project_Click;
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.ShortcutKeys =  Keys.Control | Keys.Q;
            Menu_Exit.Size = new Size (161, 22);
            Menu_Exit.Text = "Exit";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font ("Courier New", 9F);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point (21, 33);
            label1.Name = "label1";
            label1.Size = new Size (56, 15);
            label1.TabIndex = 103;
            label1.Text = "Species";
            // 
            // lblClusters
            // 
            lblClusters.AutoSize = true;
            lblClusters.Font = new Font ("Courier New", 9F);
            lblClusters.ForeColor = Color.IndianRed;
            lblClusters.Location = new Point (21, 122);
            lblClusters.Name = "lblClusters";
            lblClusters.Size = new Size (63, 15);
            lblClusters.TabIndex = 104;
            lblClusters.Text = "Clusters";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font ("Courier New", 9F);
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point (21, 394);
            label3.Name = "label3";
            label3.Size = new Size (84, 15);
            label3.TabIndex = 106;
            label3.Text = "Transcripts";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font ("Courier New", 9F);
            label4.ForeColor = Color.IndianRed;
            label4.Location = new Point (386, 33);
            label4.Name = "label4";
            label4.Size = new Size (56, 15);
            label4.TabIndex = 107;
            label4.Text = "Details";
            // 
            // lblProjectID
            // 
            lblProjectID.AutoSize = true;
            lblProjectID.Font = new Font ("Courier New", 9F);
            lblProjectID.ForeColor = SystemColors.MenuHighlight;
            lblProjectID.Location = new Point (21, 7);
            lblProjectID.Name = "lblProjectID";
            lblProjectID.Size = new Size (84, 15);
            lblProjectID.TabIndex = 108;
            lblProjectID.Text = "Project id:";
            lblProjectID.Click += lblProjectID_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (label2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 613);
            panel1.Name = "panel1";
            panel1.Size = new Size (1279, 18);
            panel1.TabIndex = 151;
            // 
            // label2
            // 
            label2.BackColor = Color.LightCoral;
            label2.Dock = DockStyle.Bottom;
            label2.Font = new Font ("Consolas", 10F);
            label2.ForeColor = Color.White;
            label2.Location = new Point (0, 0);
            label2.Name = "label2";
            label2.Size = new Size (1279, 18);
            label2.TabIndex = 10;
            label2.Text = "Back";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // frmAugustusLib
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size (1279, 631);
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (lblProjectID);
            Controls.Add (txtSequenceData);
            Controls.Add (lstTranscript);
            Controls.Add (lstCluster);
            Controls.Add (lstSpecies);
            Controls.Add (label3);
            Controls.Add (lblClusters);
            Controls.Add (label1);
            Controls.Add (label4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAugustusLib";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Augustusmate Library";
            Load += frmAugustusLib_Load;
            contextMenuSpecies.ResumeLayout (false);
            contextMenu_Cluster.ResumeLayout (false);
            contextMenuTranscript.ResumeLayout (false);
            contextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private ListBox lstSpecies;
        private ListBox lstCluster;
        private ListBox lstTranscript;
        private TextBox txtSequenceData;
        private ContextMenuStrip contextMenuSpecies;
        private ToolStripMenuItem Menu_AddSpecies;
        private ToolStripMenuItem Menu_Draw;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem Menu_Exit;
        private Label label1;
        private Label lblClusters;
        private Label label3;
        private Label label4;
        private ContextMenuStrip contextMenu_Cluster;
        private ToolStripMenuItem Menu_DeleteCluster;
        private ToolStripMenuItem Menu_EditCluster;
        private ToolStripMenuItem Menu_EditSpecies;
        private ToolStripSeparator toolStripMenuItem1;
        private ContextMenuStrip contextMenuTranscript;
        private ToolStripMenuItem Menu_EditTranscript;
        private ToolStripMenuItem Menu_DeleteSpecies;
        private ToolStripMenuItem Menu_Project;
        private Label lblProjectID;
        private ToolStripMenuItem Menu_SelectProject;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem Menu_DeleteDuplicateTranscripts;
        private ToolStripSeparator toolStripMenuItem3;
        private Panel panel1;
        private Label label2;
        }
    }