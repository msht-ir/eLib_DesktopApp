namespace eLib.Forms
    {
    partial class frmSelectExam
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
            TreeA = new System.Windows.Forms.TreeView ();
            panel1 = new System.Windows.Forms.Panel ();
            lblSelect = new System.Windows.Forms.Label ();
            lblCancel = new System.Windows.Forms.Label ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // TreeA
            // 
            TreeA.BackColor = System.Drawing.Color.WhiteSmoke;
            TreeA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TreeA.Dock = System.Windows.Forms.DockStyle.Top;
            TreeA.Location = new System.Drawing.Point (0, 0);
            TreeA.Name = "TreeA";
            TreeA.Size = new System.Drawing.Size (344, 453);
            TreeA.TabIndex = 2;
            TreeA.DoubleClick += TreeA_DoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblSelect);
            panel1.Controls.Add (lblCancel);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 493);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (344, 18);
            panel1.TabIndex = 28;
            // 
            // lblSelect
            // 
            lblSelect.BackColor = System.Drawing.Color.DarkSeaGreen;
            lblSelect.Dock = System.Windows.Forms.DockStyle.Left;
            lblSelect.Font = new System.Drawing.Font ("Consolas", 10F);
            lblSelect.ForeColor = System.Drawing.Color.White;
            lblSelect.Location = new System.Drawing.Point (0, 0);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new System.Drawing.Size (227, 18);
            lblSelect.TabIndex = 27;
            lblSelect.Text = "Select";
            lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblSelect.Click += lblSelect_Click;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            lblCancel.Dock = System.Windows.Forms.DockStyle.Right;
            lblCancel.Font = new System.Drawing.Font ("Consolas", 10F);
            lblCancel.ForeColor = System.Drawing.Color.IndianRed;
            lblCancel.Location = new System.Drawing.Point (232, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new System.Drawing.Size (112, 18);
            lblCancel.TabIndex = 26;
            lblCancel.Text = "Cancel";
            lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // frmSelectExam
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size (344, 511);
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (TreeA);
            Font = new System.Drawing.Font ("Consolas", 10F, System.Drawing.FontStyle.Bold);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelectExam";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "frmSelectExam";
            Load += frmSelectExam_Load;
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        #endregion

        private System.Windows.Forms.TreeView TreeA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblCancel;
        }
    }