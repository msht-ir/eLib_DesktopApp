namespace eLib.Forms
    {
    partial class frmTimeAndDate
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
            MC = new System.Windows.Forms.MonthCalendar ();
            txtDateTime = new System.Windows.Forms.MaskedTextBox ();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            oKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem ();
            panel1 = new System.Windows.Forms.Panel ();
            lblSelect = new System.Windows.Forms.Label ();
            lblCancel = new System.Windows.Forms.Label ();
            contextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // MC
            // 
            MC.CalendarDimensions = new System.Drawing.Size (1, 2);
            MC.Location = new System.Drawing.Point (39, 12);
            MC.MaxDate = new System.DateTime (2171, 7, 6, 0, 0, 0, 0);
            MC.MinDate = new System.DateTime (1971, 3, 21, 0, 0, 0, 0);
            MC.Name = "MC";
            MC.ShowTodayCircle = false;
            MC.TabIndex = 5;
            MC.TrailingForeColor = System.Drawing.Color.IndianRed;
            MC.DateSelected += MC_DateSelected;
            // 
            // txtDateTime
            // 
            txtDateTime.BackColor = System.Drawing.Color.FromArgb (  253,   253,   253);
            txtDateTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtDateTime.Font = new System.Drawing.Font ("Consolas", 18F);
            txtDateTime.ForeColor = System.Drawing.Color.IndianRed;
            txtDateTime.Location = new System.Drawing.Point (81, 333);
            txtDateTime.Mask = "0000-00-00 . 00-00";
            txtDateTime.Name = "txtDateTime";
            txtDateTime.Size = new System.Drawing.Size (275, 29);
            txtDateTime.TabIndex = 0;
            txtDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtDateTime.KeyDown += txtDateTime_KeyDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { oKToolStripMenuItem, cancelToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size (154, 48);
            // 
            // oKToolStripMenuItem
            // 
            oKToolStripMenuItem.Name = "oKToolStripMenuItem";
            oKToolStripMenuItem.Size = new System.Drawing.Size (153, 22);
            oKToolStripMenuItem.Text = "OK";
            oKToolStripMenuItem.Click += Menu_OK;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.ForeColor = System.Drawing.Color.IndianRed;
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
            cancelToolStripMenuItem.Size = new System.Drawing.Size (153, 22);
            cancelToolStripMenuItem.Text = "Cancel";
            cancelToolStripMenuItem.Click += Menu_Cancel;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblSelect);
            panel1.Controls.Add (lblCancel);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 398);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (445, 20);
            panel1.TabIndex = 117;
            // 
            // lblSelect
            // 
            lblSelect.BackColor = System.Drawing.Color.DarkSeaGreen;
            lblSelect.Dock = System.Windows.Forms.DockStyle.Left;
            lblSelect.Font = new System.Drawing.Font ("Consolas", 10F);
            lblSelect.ForeColor = System.Drawing.Color.White;
            lblSelect.Location = new System.Drawing.Point (0, 0);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new System.Drawing.Size (321, 20);
            lblSelect.TabIndex = 23;
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
            lblCancel.Location = new System.Drawing.Point (327, 0);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new System.Drawing.Size (118, 20);
            lblCancel.TabIndex = 22;
            lblCancel.Text = "Cancel";
            lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCancel.Click += lblCancel_Click;
            // 
            // frmTimeAndDate
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb (  253,   253,   253);
            ClientSize = new System.Drawing.Size (445, 418);
            ContextMenuStrip = contextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (txtDateTime);
            Controls.Add (MC);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmTimeAndDate";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "date and time";
            Load += frmTimeAndDate_Load;
            KeyDown += frmTimeAndDate_KeyDown;
            contextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.MonthCalendar MC;
        internal System.Windows.Forms.MaskedTextBox txtDateTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblCancel;
        }
    }