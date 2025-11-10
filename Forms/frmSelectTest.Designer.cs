namespace eLib.Forms
    {
    partial class frmSelectTest
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
            panel1 = new System.Windows.Forms.Panel ();
            lblStatus = new System.Windows.Forms.Label ();
            lblSelect = new System.Windows.Forms.Label ();
            lblExit = new System.Windows.Forms.Label ();
            chkTestsRTL = new System.Windows.Forms.CheckBox ();
            lstTests = new System.Windows.Forms.ListBox ();
            chkShowOptions = new System.Windows.Forms.CheckBox ();
            lstExamTests = new System.Windows.Forms.ListBox ();
            lblTopics = new System.Windows.Forms.Label ();
            btnAddToExam = new System.Windows.Forms.Button ();
            lstOptions = new System.Windows.Forms.ListBox ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // panel1
            // 
            panel1.Controls.Add (lblStatus);
            panel1.Controls.Add (lblSelect);
            panel1.Controls.Add (lblExit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 591);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (1219, 20);
            panel1.TabIndex = 12;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = System.Drawing.Color.Transparent;
            lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblStatus.Font = new System.Drawing.Font ("Consolas", 9F);
            lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            lblStatus.Location = new System.Drawing.Point (143, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size (942, 20);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "-";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelect
            // 
            lblSelect.BackColor = System.Drawing.Color.DarkSeaGreen;
            lblSelect.Dock = System.Windows.Forms.DockStyle.Left;
            lblSelect.Font = new System.Drawing.Font ("Consolas", 10F);
            lblSelect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lblSelect.Location = new System.Drawing.Point (0, 0);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new System.Drawing.Size (143, 20);
            lblSelect.TabIndex = 11;
            lblSelect.Text = "Select";
            lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblSelect.Click += lblSelect_Click;
            // 
            // lblExit
            // 
            lblExit.BackColor = System.Drawing.Color.WhiteSmoke;
            lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            lblExit.Font = new System.Drawing.Font ("Consolas", 10F);
            lblExit.ForeColor = System.Drawing.Color.IndianRed;
            lblExit.Location = new System.Drawing.Point (1085, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (134, 20);
            lblExit.TabIndex = 10;
            lblExit.Text = "Back";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // chkTestsRTL
            // 
            chkTestsRTL.AutoSize = true;
            chkTestsRTL.Location = new System.Drawing.Point (1159, 3);
            chkTestsRTL.Name = "chkTestsRTL";
            chkTestsRTL.Size = new System.Drawing.Size (44, 19);
            chkTestsRTL.TabIndex = 14;
            chkTestsRTL.Text = "RTL";
            chkTestsRTL.UseVisualStyleBackColor = true;
            chkTestsRTL.CheckedChanged += chkTestsRTL_CheckedChanged;
            // 
            // lstTests
            // 
            lstTests.BackColor = System.Drawing.Color.WhiteSmoke;
            lstTests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstTests.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lstTests.FormattingEnabled = true;
            lstTests.Location = new System.Drawing.Point (12, 26);
            lstTests.Name = "lstTests";
            lstTests.Size = new System.Drawing.Size (1194, 120);
            lstTests.TabIndex = 13;
            lstTests.Click += lstTests_Click;
            lstTests.DoubleClick += lstTests_DoubleClick;
            // 
            // chkShowOptions
            // 
            chkShowOptions.AutoSize = true;
            chkShowOptions.Location = new System.Drawing.Point (553, 462);
            chkShowOptions.Name = "chkShowOptions";
            chkShowOptions.Size = new System.Drawing.Size (123, 19);
            chkShowOptions.TabIndex = 17;
            chkShowOptions.Text = "Show Options (F4)";
            chkShowOptions.UseVisualStyleBackColor = true;
            chkShowOptions.CheckedChanged += chkShowOptions_CheckedChanged;
            // 
            // lstExamTests
            // 
            lstExamTests.BackColor = System.Drawing.Color.WhiteSmoke;
            lstExamTests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstExamTests.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lstExamTests.FormattingEnabled = true;
            lstExamTests.Location = new System.Drawing.Point (13, 188);
            lstExamTests.Name = "lstExamTests";
            lstExamTests.Size = new System.Drawing.Size (1194, 260);
            lstExamTests.TabIndex = 18;
            lstExamTests.Click += lstExamTests_Click;
            lstExamTests.DoubleClick += lstExamTests_DoubleClick;
            // 
            // lblTopics
            // 
            lblTopics.BackColor = System.Drawing.SystemColors.ControlLightLight;
            lblTopics.Font = new System.Drawing.Font ("Segoe UI", 12F);
            lblTopics.ForeColor = System.Drawing.SystemColors.HotTrack;
            lblTopics.Location = new System.Drawing.Point (486, 2);
            lblTopics.Name = "lblTopics";
            lblTopics.Size = new System.Drawing.Size (247, 20);
            lblTopics.TabIndex = 149;
            lblTopics.Text = "Test Bank";
            lblTopics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddToExam
            // 
            btnAddToExam.Location = new System.Drawing.Point (545, 159);
            btnAddToExam.Name = "btnAddToExam";
            btnAddToExam.Size = new System.Drawing.Size (132, 24);
            btnAddToExam.TabIndex = 151;
            btnAddToExam.Text = "Add to Exam    (F2)";
            btnAddToExam.UseVisualStyleBackColor = true;
            btnAddToExam.Click += btnAddToExam_Click;
            // 
            // lstOptions
            // 
            lstOptions.BackColor = System.Drawing.Color.GhostWhite;
            lstOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstOptions.Font = new System.Drawing.Font ("Segoe UI", 10F);
            lstOptions.ForeColor = System.Drawing.Color.DimGray;
            lstOptions.FormattingEnabled = true;
            lstOptions.Location = new System.Drawing.Point (210, 486);
            lstOptions.Name = "lstOptions";
            lstOptions.Size = new System.Drawing.Size (807, 85);
            lstOptions.TabIndex = 153;
            // 
            // frmSelectTest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size (1219, 611);
            ControlBox = false;
            Controls.Add (lstOptions);
            Controls.Add (btnAddToExam);
            Controls.Add (lblTopics);
            Controls.Add (lstExamTests);
            Controls.Add (chkShowOptions);
            Controls.Add (chkTestsRTL);
            Controls.Add (lstTests);
            Controls.Add (panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelectTest";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Select Test";
            Load += frmSelectTest_Load;
            KeyDown += frmSelectTest_KeyDown;
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.ListBox lstTests;
        private System.Windows.Forms.CheckBox chkTestsRTL;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkShowOptions;
        private System.Windows.Forms.ListBox lstExamTests;
        internal System.Windows.Forms.Label lblTopics;
        private System.Windows.Forms.Button btnAddToExam;
        private System.Windows.Forms.ListBox lstOptions;
        }
    }