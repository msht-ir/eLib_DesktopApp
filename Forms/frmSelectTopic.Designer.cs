namespace eLib.Forms
    {
    partial class frmSelectTopic
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
            lstTopics = new System.Windows.Forms.ListBox ();
            lblExit = new System.Windows.Forms.Label ();
            panel1 = new System.Windows.Forms.Panel ();
            lblSelect = new System.Windows.Forms.Label ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // lstTopics
            // 
            lstTopics.BackColor = System.Drawing.Color.WhiteSmoke;
            lstTopics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstTopics.Dock = System.Windows.Forms.DockStyle.Top;
            lstTopics.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lstTopics.FormattingEnabled = true;
            lstTopics.ItemHeight = 20;
            lstTopics.Location = new System.Drawing.Point (0, 0);
            lstTopics.Name = "lstTopics";
            lstTopics.Size = new System.Drawing.Size (444, 360);
            lstTopics.TabIndex = 0;
            lstTopics.DoubleClick += lstTopics_DoubleClick;
            // 
            // lblExit
            // 
            lblExit.BackColor = System.Drawing.Color.WhiteSmoke;
            lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            lblExit.Font = new System.Drawing.Font ("Consolas", 10F);
            lblExit.ForeColor = System.Drawing.Color.IndianRed;
            lblExit.Location = new System.Drawing.Point (334, 0);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (110, 18);
            lblExit.TabIndex = 10;
            lblExit.Text = "Cancel";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblSelect);
            panel1.Controls.Add (lblExit);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Font = new System.Drawing.Font ("Consolas", 10F, System.Drawing.FontStyle.Bold);
            panel1.Location = new System.Drawing.Point (0, 403);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (444, 18);
            panel1.TabIndex = 11;
            // 
            // lblSelect
            // 
            lblSelect.BackColor = System.Drawing.Color.DarkSeaGreen;
            lblSelect.Dock = System.Windows.Forms.DockStyle.Left;
            lblSelect.Font = new System.Drawing.Font ("Consolas", 10F);
            lblSelect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lblSelect.Location = new System.Drawing.Point (0, 0);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new System.Drawing.Size (328, 18);
            lblSelect.TabIndex = 11;
            lblSelect.Text = "Select";
            lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblSelect.Click += lblSelect_Click;
            // 
            // frmSelectTopic
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size (444, 421);
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (lstTopics);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelectTopic";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Select a Topic";
            Load += frmSelectTopic_Load;
            KeyDown += frmSelectTopic_KeyDown;
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        #endregion

        private System.Windows.Forms.ListBox lstTopics;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSelect;
        }
    }