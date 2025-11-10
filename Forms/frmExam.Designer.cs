namespace eLib.Forms
    {
    partial class frmExam
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
            label2 = new System.Windows.Forms.Label ();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu2_AddComposition = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_EditComposition = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_RemoveComposition = new System.Windows.Forms.ToolStripMenuItem ();
            label1 = new System.Windows.Forms.Label ();
            txtExam = new System.Windows.Forms.TextBox ();
            chkShuffle = new System.Windows.Forms.CheckBox ();
            label4 = new System.Windows.Forms.Label ();
            txtDuration = new System.Windows.Forms.TextBox ();
            label5 = new System.Windows.Forms.Label ();
            txtNTests = new System.Windows.Forms.TextBox ();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu1_Save = new System.Windows.Forms.ToolStripMenuItem ();
            Menu1_Exit = new System.Windows.Forms.ToolStripMenuItem ();
            lblExit = new System.Windows.Forms.Label ();
            panel1 = new System.Windows.Forms.Panel ();
            lblSave = new System.Windows.Forms.Label ();
            txtDateTime = new System.Windows.Forms.MaskedTextBox ();
            gridComposition = new System.Windows.Forms.DataGridView ();
            chkActive = new System.Windows.Forms.CheckBox ();
            chkTraining = new System.Windows.Forms.CheckBox ();
            btnEditComposition = new System.Windows.Forms.Button ();
            btnAddComposition = new System.Windows.Forms.Button ();
            btnRemoveComposition = new System.Windows.Forms.Button ();
            panel2 = new System.Windows.Forms.Panel ();
            contextMenuStrip2.SuspendLayout ();
            contextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) gridComposition).BeginInit ();
            panel2.SuspendLayout ();
            SuspendLayout ();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font ("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label2.Location = new System.Drawing.Point (243, 230);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size (104, 18);
            label2.TabIndex = 12;
            label2.Text = "Composition";
            label2.Click += label2_Click;
            label2.DoubleClick += label2_DoubleClick;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu2_AddComposition, Menu2_EditComposition, Menu2_RemoveComposition });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size (118, 70);
            // 
            // Menu2_AddComposition
            // 
            Menu2_AddComposition.Name = "Menu2_AddComposition";
            Menu2_AddComposition.Size = new System.Drawing.Size (117, 22);
            Menu2_AddComposition.Text = "Add";
            Menu2_AddComposition.Click += Menu2_AddComposition_Click;
            // 
            // Menu2_EditComposition
            // 
            Menu2_EditComposition.Name = "Menu2_EditComposition";
            Menu2_EditComposition.Size = new System.Drawing.Size (117, 22);
            Menu2_EditComposition.Text = "Edit";
            Menu2_EditComposition.Click += Menu2_EditComposition_Click;
            // 
            // Menu2_RemoveComposition
            // 
            Menu2_RemoveComposition.Name = "Menu2_RemoveComposition";
            Menu2_RemoveComposition.Size = new System.Drawing.Size (117, 22);
            Menu2_RemoveComposition.Text = "Remove";
            Menu2_RemoveComposition.Click += Menu2_RemoveComposition_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font ("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label1.Location = new System.Drawing.Point (261, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size (50, 18);
            label1.TabIndex = 9;
            label1.Text = "Exam";
            // 
            // txtExam
            // 
            txtExam.Font = new System.Drawing.Font ("Tahoma", 10F);
            txtExam.Location = new System.Drawing.Point (36, 39);
            txtExam.Name = "txtExam";
            txtExam.Size = new System.Drawing.Size (508, 24);
            txtExam.TabIndex = 0;
            // 
            // chkShuffle
            // 
            chkShuffle.AutoSize = true;
            chkShuffle.Font = new System.Drawing.Font ("Segoe UI", 11F);
            chkShuffle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            chkShuffle.Location = new System.Drawing.Point (326, 137);
            chkShuffle.Name = "chkShuffle";
            chkShuffle.Size = new System.Drawing.Size (128, 24);
            chkShuffle.TabIndex = 2;
            chkShuffle.Text = "Shuffle options";
            chkShuffle.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font ("Microsoft Sans Serif", 10F);
            label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label4.Location = new System.Drawing.Point (258, 396);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size (75, 17);
            label4.TabIndex = 17;
            label4.Text = "Time (min)";
            // 
            // txtDuration
            // 
            txtDuration.BackColor = System.Drawing.SystemColors.InactiveBorder;
            txtDuration.Font = new System.Drawing.Font ("Microsoft Sans Serif", 11.25F);
            txtDuration.Location = new System.Drawing.Point (341, 391);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new System.Drawing.Size (97, 24);
            txtDuration.TabIndex = 6;
            txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font ("Microsoft Sans Serif", 10F);
            label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label5.Location = new System.Drawing.Point (106, 396);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size (43, 17);
            label5.TabIndex = 19;
            label5.Text = "Tests";
            // 
            // txtNTests
            // 
            txtNTests.BackColor = System.Drawing.SystemColors.InactiveBorder;
            txtNTests.Font = new System.Drawing.Font ("Microsoft Sans Serif", 11.25F);
            txtNTests.Location = new System.Drawing.Point (155, 391);
            txtNTests.Name = "txtNTests";
            txtNTests.Size = new System.Drawing.Size (97, 24);
            txtNTests.TabIndex = 5;
            txtNTests.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            lblExit.Location = new System.Drawing.Point (182, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (398, 20);
            lblExit.TabIndex = 22;
            lblExit.Text = "Cancel";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblSave);
            panel1.Controls.Add (lblExit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 477);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (580, 20);
            panel1.TabIndex = 23;
            // 
            // lblSave
            // 
            lblSave.BackColor = System.Drawing.Color.CornflowerBlue;
            lblSave.Dock = System.Windows.Forms.DockStyle.Left;
            lblSave.Font = new System.Drawing.Font ("Consolas", 10F);
            lblSave.ForeColor = System.Drawing.Color.White;
            lblSave.Location = new System.Drawing.Point (0, 0);
            lblSave.Name = "lblSave";
            lblSave.Size = new System.Drawing.Size (168, 20);
            lblSave.TabIndex = 23;
            lblSave.Text = "Save";
            lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblSave.Click += lblSave_Click;
            // 
            // txtDateTime
            // 
            txtDateTime.BackColor = System.Drawing.SystemColors.InactiveBorder;
            txtDateTime.Font = new System.Drawing.Font ("Courier New", 11F);
            txtDateTime.Location = new System.Drawing.Point (168, 87);
            txtDateTime.Mask = "0000-00-00 . 00-00";
            txtDateTime.Name = "txtDateTime";
            txtDateTime.Size = new System.Drawing.Size (249, 24);
            txtDateTime.TabIndex = 3;
            txtDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtDateTime.Click += txtDateTime_Click;
            // 
            // gridComposition
            // 
            gridComposition.AllowUserToAddRows = false;
            gridComposition.AllowUserToDeleteRows = false;
            gridComposition.AllowUserToResizeColumns = false;
            gridComposition.AllowUserToResizeRows = false;
            gridComposition.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            gridComposition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            gridComposition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridComposition.ColumnHeadersVisible = false;
            gridComposition.ContextMenuStrip = contextMenuStrip2;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            gridComposition.DefaultCellStyle = dataGridViewCellStyle1;
            gridComposition.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            gridComposition.GridColor = System.Drawing.Color.WhiteSmoke;
            gridComposition.Location = new System.Drawing.Point (37, 251);
            gridComposition.Name = "gridComposition";
            gridComposition.RowHeadersVisible = false;
            gridComposition.Size = new System.Drawing.Size (508, 120);
            gridComposition.TabIndex = 11;
            gridComposition.CellDoubleClick += gridComposition_CellDoubleClick;
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Font = new System.Drawing.Font ("Segoe UI", 11F);
            chkActive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            chkActive.Location = new System.Drawing.Point (129, 137);
            chkActive.Name = "chkActive";
            chkActive.Size = new System.Drawing.Size (69, 24);
            chkActive.TabIndex = 1;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // chkTraining
            // 
            chkTraining.AutoSize = true;
            chkTraining.Font = new System.Drawing.Font ("Segoe UI", 11F);
            chkTraining.ForeColor = System.Drawing.Color.IndianRed;
            chkTraining.Location = new System.Drawing.Point (221, 137);
            chkTraining.Name = "chkTraining";
            chkTraining.Size = new System.Drawing.Size (81, 24);
            chkTraining.TabIndex = 24;
            chkTraining.Text = "Training";
            chkTraining.UseVisualStyleBackColor = true;
            // 
            // btnEditComposition
            // 
            btnEditComposition.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnEditComposition.Location = new System.Drawing.Point (5, 329);
            btnEditComposition.Name = "btnEditComposition";
            btnEditComposition.Size = new System.Drawing.Size (26, 25);
            btnEditComposition.TabIndex = 30;
            btnEditComposition.Text = "I";
            btnEditComposition.UseVisualStyleBackColor = true;
            btnEditComposition.Click += btnEditComposition_Click;
            // 
            // btnAddComposition
            // 
            btnAddComposition.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnAddComposition.Location = new System.Drawing.Point (5, 267);
            btnAddComposition.Name = "btnAddComposition";
            btnAddComposition.Size = new System.Drawing.Size (26, 25);
            btnAddComposition.TabIndex = 29;
            btnAddComposition.Text = "+";
            btnAddComposition.UseVisualStyleBackColor = true;
            btnAddComposition.Click += btnAddComposition_Click;
            // 
            // btnRemoveComposition
            // 
            btnRemoveComposition.Font = new System.Drawing.Font ("Courier New", 9.75F);
            btnRemoveComposition.Location = new System.Drawing.Point (5, 298);
            btnRemoveComposition.Name = "btnRemoveComposition";
            btnRemoveComposition.Size = new System.Drawing.Size (26, 25);
            btnRemoveComposition.TabIndex = 31;
            btnRemoveComposition.Text = "-";
            btnRemoveComposition.UseVisualStyleBackColor = true;
            btnRemoveComposition.Click += btnRemoveComposition_Click;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            panel2.Controls.Add (label1);
            panel2.Controls.Add (chkActive);
            panel2.Controls.Add (txtExam);
            panel2.Controls.Add (chkShuffle);
            panel2.Controls.Add (txtDateTime);
            panel2.Controls.Add (chkTraining);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point (0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size (580, 184);
            panel2.TabIndex = 32;
            // 
            // frmExam
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlLightLight;
            ClientSize = new System.Drawing.Size (580, 497);
            ContextMenuStrip = contextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel2);
            Controls.Add (btnRemoveComposition);
            Controls.Add (btnEditComposition);
            Controls.Add (btnAddComposition);
            Controls.Add (panel1);
            Controls.Add (label5);
            Controls.Add (txtNTests);
            Controls.Add (label4);
            Controls.Add (txtDuration);
            Controls.Add (gridComposition);
            Controls.Add (label2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmExam";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Exam";
            Load += frmExam_Load;
            KeyDown += frmExam_KeyDown;
            contextMenuStrip2.ResumeLayout (false);
            contextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) gridComposition).EndInit ();
            panel2.ResumeLayout (false);
            panel2.PerformLayout ();
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExam;
        private System.Windows.Forms.CheckBox chkShuffle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNTests;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu1_Exit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Menu2_AddComposition;
        private System.Windows.Forms.ToolStripMenuItem Menu2_RemoveComposition;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.MaskedTextBox txtDateTime;
        private System.Windows.Forms.DataGridView gridComposition;
        private System.Windows.Forms.ToolStripMenuItem Menu2_EditComposition;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkTraining;
        private System.Windows.Forms.Button btnEditComposition;
        private System.Windows.Forms.Button btnAddComposition;
        private System.Windows.Forms.Button btnRemoveComposition;
        private System.Windows.Forms.Panel panel2;
        }
    }