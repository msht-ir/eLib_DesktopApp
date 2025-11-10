namespace eLib.Forms
    {
    partial class frmCourse
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
            label5 = new System.Windows.Forms.Label ();
            txtUnits = new System.Windows.Forms.TextBox ();
            lblComposition = new System.Windows.Forms.Label ();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu2_AddTopic = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_EditTopic = new System.Windows.Forms.ToolStripMenuItem ();
            label1 = new System.Windows.Forms.Label ();
            txtCourse = new System.Windows.Forms.TextBox ();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu1_Save = new System.Windows.Forms.ToolStripMenuItem ();
            Menu1_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            lblExit = new System.Windows.Forms.Label ();
            panel1 = new System.Windows.Forms.Panel ();
            lblSave = new System.Windows.Forms.Label ();
            lstTopics = new System.Windows.Forms.ListBox ();
            chkCourseRTL = new System.Windows.Forms.CheckBox ();
            btnEditTopic = new System.Windows.Forms.Button ();
            btnAddTopic = new System.Windows.Forms.Button ();
            contextMenuStrip2.SuspendLayout ();
            contextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font ("Segoe UI", 11F);
            label5.Location = new System.Drawing.Point (405, 77);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size (42, 20);
            label5.TabIndex = 25;
            label5.Text = "Units";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnits
            // 
            txtUnits.Font = new System.Drawing.Font ("Segoe UI", 11F);
            txtUnits.Location = new System.Drawing.Point (453, 74);
            txtUnits.Name = "txtUnits";
            txtUnits.Size = new System.Drawing.Size (61, 27);
            txtUnits.TabIndex = 24;
            txtUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblComposition
            // 
            lblComposition.AutoSize = true;
            lblComposition.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lblComposition.Location = new System.Drawing.Point (249, 121);
            lblComposition.Name = "lblComposition";
            lblComposition.Size = new System.Drawing.Size (51, 20);
            lblComposition.TabIndex = 23;
            lblComposition.Text = "Topics";
            lblComposition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblComposition.Click += lblComposition_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu2_AddTopic, Menu2_EditTopic });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size (97, 48);
            // 
            // Menu2_AddTopic
            // 
            Menu2_AddTopic.Name = "Menu2_AddTopic";
            Menu2_AddTopic.Size = new System.Drawing.Size (96, 22);
            Menu2_AddTopic.Text = "Add";
            Menu2_AddTopic.Click += Menu2_AddTopic_Click;
            // 
            // Menu2_EditTopic
            // 
            Menu2_EditTopic.Name = "Menu2_EditTopic";
            Menu2_EditTopic.Size = new System.Drawing.Size (96, 22);
            Menu2_EditTopic.Text = "Edit";
            Menu2_EditTopic.Click += Menu2_EditTopic_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font ("Segoe UI", 11F);
            label1.Location = new System.Drawing.Point (250, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size (54, 20);
            label1.TabIndex = 21;
            label1.Text = "Course";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // txtCourse
            // 
            txtCourse.Font = new System.Drawing.Font ("Segoe UI", 11F);
            txtCourse.Location = new System.Drawing.Point (39, 39);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new System.Drawing.Size (475, 27);
            txtCourse.TabIndex = 20;
            txtCourse.KeyDown += txtCourse_KeyDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu1_Save, Menu1_Exit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size (99, 48);
            // 
            // Menu1_Save
            // 
            Menu1_Save.Name = "Menu1_Save";
            Menu1_Save.Size = new System.Drawing.Size (98, 22);
            Menu1_Save.Text = "Save";
            Menu1_Save.Click += Menu1_Save_Click;
            // 
            // Menu1_Exit
            // 
            Menu1_Exit.ForeColor = System.Drawing.Color.IndianRed;
            Menu1_Exit.Name = "Menu1_Exit";
            Menu1_Exit.Size = new System.Drawing.Size (98, 22);
            Menu1_Exit.Text = "Exit";
            Menu1_Exit.Click += Menu1_Exit_Click;
            // 
            // lblExit
            // 
            lblExit.BackColor = System.Drawing.Color.WhiteSmoke;
            lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            lblExit.Font = new System.Drawing.Font ("Consolas", 10F);
            lblExit.ForeColor = System.Drawing.Color.IndianRed;
            lblExit.Location = new System.Drawing.Point (439, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (105, 18);
            lblExit.TabIndex = 26;
            lblExit.Text = "Back";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblSave);
            panel1.Controls.Add (lblExit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            panel1.Location = new System.Drawing.Point (0, 353);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (544, 18);
            panel1.TabIndex = 27;
            // 
            // lblSave
            // 
            lblSave.BackColor = System.Drawing.Color.CornflowerBlue;
            lblSave.Dock = System.Windows.Forms.DockStyle.Left;
            lblSave.Font = new System.Drawing.Font ("Consolas", 10F);
            lblSave.ForeColor = System.Drawing.Color.White;
            lblSave.Location = new System.Drawing.Point (0, 0);
            lblSave.Name = "lblSave";
            lblSave.Size = new System.Drawing.Size (424, 18);
            lblSave.TabIndex = 27;
            lblSave.Text = "Save";
            lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblSave.Click += lblSave_Click;
            // 
            // lstTopics
            // 
            lstTopics.BackColor = System.Drawing.Color.WhiteSmoke;
            lstTopics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstTopics.ContextMenuStrip = contextMenuStrip2;
            lstTopics.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lstTopics.FormattingEnabled = true;
            lstTopics.ItemHeight = 20;
            lstTopics.Location = new System.Drawing.Point (39, 145);
            lstTopics.Name = "lstTopics";
            lstTopics.Size = new System.Drawing.Size (475, 160);
            lstTopics.TabIndex = 28;
            // 
            // chkCourseRTL
            // 
            chkCourseRTL.AutoSize = true;
            chkCourseRTL.Location = new System.Drawing.Point (470, 17);
            chkCourseRTL.Name = "chkCourseRTL";
            chkCourseRTL.Size = new System.Drawing.Size (47, 19);
            chkCourseRTL.TabIndex = 29;
            chkCourseRTL.Text = "RTL";
            chkCourseRTL.UseVisualStyleBackColor = true;
            chkCourseRTL.CheckedChanged += chkCourseRTL_CheckedChanged;
            // 
            // btnEditTopic
            // 
            btnEditTopic.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnEditTopic.Location = new System.Drawing.Point (286, 311);
            btnEditTopic.Name = "btnEditTopic";
            btnEditTopic.Size = new System.Drawing.Size (26, 25);
            btnEditTopic.TabIndex = 31;
            btnEditTopic.Text = "I";
            btnEditTopic.UseVisualStyleBackColor = true;
            btnEditTopic.Click += btnEditTopic_Click;
            // 
            // btnAddTopic
            // 
            btnAddTopic.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnAddTopic.Location = new System.Drawing.Point (237, 311);
            btnAddTopic.Name = "btnAddTopic";
            btnAddTopic.Size = new System.Drawing.Size (26, 25);
            btnAddTopic.TabIndex = 30;
            btnAddTopic.Text = "+";
            btnAddTopic.UseVisualStyleBackColor = true;
            btnAddTopic.Click += btnAddTopic_Click;
            // 
            // frmCourse
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size (544, 371);
            ContextMenuStrip = contextMenuStrip1;
            ControlBox = false;
            Controls.Add (btnEditTopic);
            Controls.Add (btnAddTopic);
            Controls.Add (chkCourseRTL);
            Controls.Add (lstTopics);
            Controls.Add (panel1);
            Controls.Add (label5);
            Controls.Add (txtUnits);
            Controls.Add (lblComposition);
            Controls.Add (label1);
            Controls.Add (txtCourse);
            Font = new System.Drawing.Font ("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCourse";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Course";
            Load += frmCourse_Load;
            KeyDown += frmCourse_KeyDown;
            contextMenuStrip2.ResumeLayout (false);
            contextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label lblComposition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCourse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Exit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Menu2_AddTopic;
        private System.Windows.Forms.ToolStripMenuItem Menu2_EditTopic;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.ListBox lstTopics;
        private System.Windows.Forms.CheckBox chkCourseRTL;
        private System.Windows.Forms.Button btnEditTopic;
        private System.Windows.Forms.Button btnAddTopic;
        }
    }