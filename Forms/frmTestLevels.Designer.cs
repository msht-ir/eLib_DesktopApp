namespace eLib.Forms
    {
    partial class frmTestLevels
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
            lblOK = new System.Windows.Forms.Label ();
            lblExit = new System.Windows.Forms.Label ();
            lvl1 = new System.Windows.Forms.TrackBar ();
            lvl2 = new System.Windows.Forms.TrackBar ();
            lblFrom = new System.Windows.Forms.Label ();
            lblTo = new System.Windows.Forms.Label ();
            lbl5 = new System.Windows.Forms.Label ();
            lbl4 = new System.Windows.Forms.Label ();
            lbl3 = new System.Windows.Forms.Label ();
            lbl2 = new System.Windows.Forms.Label ();
            lbl1 = new System.Windows.Forms.Label ();
            panel1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) lvl1).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) lvl2).BeginInit ();
            SuspendLayout ();
            // 
            // panel1
            // 
            panel1.Controls.Add (lblOK);
            panel1.Controls.Add (lblExit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 326);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (419, 20);
            panel1.TabIndex = 24;
            // 
            // lblOK
            // 
            lblOK.BackColor = System.Drawing.Color.CornflowerBlue;
            lblOK.Dock = System.Windows.Forms.DockStyle.Left;
            lblOK.Font = new System.Drawing.Font ("Consolas", 10F);
            lblOK.ForeColor = System.Drawing.Color.White;
            lblOK.Location = new System.Drawing.Point (0, 0);
            lblOK.Name = "lblOK";
            lblOK.Size = new System.Drawing.Size (274, 20);
            lblOK.TabIndex = 23;
            lblOK.Text = "OK";
            lblOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblOK.Click += lblOK_Click;
            // 
            // lblExit
            // 
            lblExit.BackColor = System.Drawing.Color.WhiteSmoke;
            lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            lblExit.Font = new System.Drawing.Font ("Consolas", 10F);
            lblExit.ForeColor = System.Drawing.Color.IndianRed;
            lblExit.Location = new System.Drawing.Point (283, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (136, 20);
            lblExit.TabIndex = 22;
            lblExit.Text = "Cancel ";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // lvl1
            // 
            lvl1.LargeChange = 1;
            lvl1.Location = new System.Drawing.Point (89, 39);
            lvl1.Maximum = 5;
            lvl1.Minimum = 1;
            lvl1.Name = "lvl1";
            lvl1.Orientation = System.Windows.Forms.Orientation.Vertical;
            lvl1.Size = new System.Drawing.Size (45, 243);
            lvl1.TabIndex = 26;
            lvl1.Value = 1;
            lvl1.Scroll += lvl1_Scroll;
            // 
            // lvl2
            // 
            lvl2.LargeChange = 1;
            lvl2.Location = new System.Drawing.Point (140, 39);
            lvl2.Maximum = 5;
            lvl2.Minimum = 1;
            lvl2.Name = "lvl2";
            lvl2.Orientation = System.Windows.Forms.Orientation.Vertical;
            lvl2.Size = new System.Drawing.Size (45, 243);
            lvl2.TabIndex = 26;
            lvl2.Value = 1;
            lvl2.Scroll += lvl2_Scroll;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new System.Drawing.Point (79, 22);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size (35, 15);
            lblFrom.TabIndex = 27;
            lblFrom.Text = "From";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new System.Drawing.Point (142, 22);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size (19, 15);
            lblTo.TabIndex = 27;
            lblTo.Text = "To";
            // 
            // lbl5
            // 
            lbl5.AutoSize = true;
            lbl5.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lbl5.Location = new System.Drawing.Point (191, 48);
            lbl5.Name = "lbl5";
            lbl5.Size = new System.Drawing.Size (85, 20);
            lbl5.TabIndex = 27;
            lbl5.Text = "Upper level";
            lbl5.Click += lbl5_Click;
            // 
            // lbl4
            // 
            lbl4.AutoSize = true;
            lbl4.BackColor = System.Drawing.Color.White;
            lbl4.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lbl4.Location = new System.Drawing.Point (191, 99);
            lbl4.Name = "lbl4";
            lbl4.Size = new System.Drawing.Size (139, 20);
            lbl4.TabIndex = 27;
            lbl4.Text = "upper-Intermediate";
            lbl4.Click += lbl4_Click;
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lbl3.Location = new System.Drawing.Point (191, 152);
            lbl3.Name = "lbl3";
            lbl3.Size = new System.Drawing.Size (94, 20);
            lbl3.TabIndex = 27;
            lbl3.Text = "Intermediate";
            lbl3.Click += lbl3_Click;
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lbl2.Location = new System.Drawing.Point (191, 206);
            lbl2.Name = "lbl2";
            lbl2.Size = new System.Drawing.Size (122, 20);
            lbl2.TabIndex = 27;
            lbl2.Text = "pre-Intermediate";
            lbl2.Click += lbl2_Click;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lbl1.Location = new System.Drawing.Point (191, 257);
            lbl1.Name = "lbl1";
            lbl1.Size = new System.Drawing.Size (83, 20);
            lbl1.TabIndex = 27;
            lbl1.Text = "Elementary";
            lbl1.Click += lbl1_Click;
            // 
            // frmTestLevels
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size (419, 346);
            ControlBox = false;
            Controls.Add (lbl4);
            Controls.Add (lbl1);
            Controls.Add (lbl2);
            Controls.Add (lbl3);
            Controls.Add (lbl5);
            Controls.Add (lblTo);
            Controls.Add (lblFrom);
            Controls.Add (lvl2);
            Controls.Add (lvl1);
            Controls.Add (panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmTestLevels";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Test Difficulty Level";
            Load += frmTestLevels_Load;
            panel1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) lvl1).EndInit ();
            ((System.ComponentModel.ISupportInitialize) lvl2).EndInit ();
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.TrackBar lvl1;
        private System.Windows.Forms.TrackBar lvl2;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        }
    }