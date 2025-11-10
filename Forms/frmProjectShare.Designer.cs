namespace eLib.Forms
    {
    partial class frmProjectShare
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
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu_AddToShareList = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Transfer = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Cancel = new System.Windows.Forms.ToolStripMenuItem ();
            GridShare = new System.Windows.Forms.DataGridView ();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu2_ChangeAccess = new System.Windows.Forms.ToolStripMenuItem ();
            Menu2_Cancel = new System.Windows.Forms.ToolStripMenuItem ();
            lstUsr = new System.Windows.Forms.ListBox ();
            lbl1 = new System.Windows.Forms.Label ();
            lblExit = new System.Windows.Forms.Label ();
            label1 = new System.Windows.Forms.Label ();
            contextMenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GridShare).BeginInit ();
            contextMenuStrip2.SuspendLayout ();
            SuspendLayout ();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_AddToShareList, Menu_Transfer, Menu_Cancel });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size (208, 70);
            // 
            // Menu_AddToShareList
            // 
            Menu_AddToShareList.Name = "Menu_AddToShareList";
            Menu_AddToShareList.ShortcutKeys = System.Windows.Forms.Keys.F4;
            Menu_AddToShareList.Size = new System.Drawing.Size (207, 22);
            Menu_AddToShareList.Text = "Add user to Share List";
            Menu_AddToShareList.Click += Menu_AddToShareList_Click;
            // 
            // Menu_Transfer
            // 
            Menu_Transfer.Name = "Menu_Transfer";
            Menu_Transfer.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E;
            Menu_Transfer.Size = new System.Drawing.Size (207, 22);
            Menu_Transfer.Text = "Entrust";
            Menu_Transfer.Click += Menu_Transfer_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = System.Drawing.Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
            Menu_Cancel.Size = new System.Drawing.Size (207, 22);
            Menu_Cancel.Text = "Exit";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // GridShare
            // 
            GridShare.AllowUserToAddRows = false;
            GridShare.AllowUserToDeleteRows = false;
            GridShare.AllowUserToResizeColumns = false;
            GridShare.AllowUserToResizeRows = false;
            GridShare.BackgroundColor = System.Drawing.SystemColors.Control;
            GridShare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            GridShare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridShare.ContextMenuStrip = contextMenuStrip2;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            GridShare.DefaultCellStyle = dataGridViewCellStyle1;
            GridShare.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            GridShare.GridColor = System.Drawing.SystemColors.Control;
            GridShare.Location = new System.Drawing.Point (262, 31);
            GridShare.Name = "GridShare";
            GridShare.RowHeadersVisible = false;
            GridShare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            GridShare.Size = new System.Drawing.Size (540, 256);
            GridShare.TabIndex = 1;
            GridShare.CellDoubleClick += GridShare_CellDoubleClick;
            GridShare.KeyDown += GridShare_KeyDown;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu2_ChangeAccess, Menu2_Cancel });
            contextMenuStrip2.Name = "contextMenuStrip1";
            contextMenuStrip2.Size = new System.Drawing.Size (174, 48);
            // 
            // Menu2_ChangeAccess
            // 
            Menu2_ChangeAccess.Name = "Menu2_ChangeAccess";
            Menu2_ChangeAccess.ShortcutKeys = System.Windows.Forms.Keys.F2;
            Menu2_ChangeAccess.Size = new System.Drawing.Size (173, 22);
            Menu2_ChangeAccess.Text = "Change Access";
            Menu2_ChangeAccess.Click += Menu2_ChangeAccess_Click;
            // 
            // Menu2_Cancel
            // 
            Menu2_Cancel.ForeColor = System.Drawing.Color.IndianRed;
            Menu2_Cancel.Name = "Menu2_Cancel";
            Menu2_Cancel.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
            Menu2_Cancel.Size = new System.Drawing.Size (173, 22);
            Menu2_Cancel.Text = "Exit";
            Menu2_Cancel.Click += Menu2_Cancel_Click;
            // 
            // lstUsr
            // 
            lstUsr.BackColor = System.Drawing.Color.FromArgb (  251,   251,   251);
            lstUsr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lstUsr.ContextMenuStrip = contextMenuStrip1;
            lstUsr.Font = new System.Drawing.Font ("Segoe UI", 10F);
            lstUsr.FormattingEnabled = true;
            lstUsr.ItemHeight = 17;
            lstUsr.Location = new System.Drawing.Point (9, 31);
            lstUsr.Name = "lstUsr";
            lstUsr.Size = new System.Drawing.Size (241, 255);
            lstUsr.TabIndex = 0;
            lstUsr.DoubleClick += lstUsr_DoubleClick;
            lstUsr.KeyDown += lstUsr_KeyDown;
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Font = new System.Drawing.Font ("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            lbl1.ForeColor = System.Drawing.Color.SteelBlue;
            lbl1.Location = new System.Drawing.Point (1, 5);
            lbl1.Name = "lbl1";
            lbl1.Size = new System.Drawing.Size (44, 20);
            lbl1.TabIndex = 7;
            lbl1.Text = "users:";
            // 
            // lblExit
            // 
            lblExit.BackColor = System.Drawing.Color.FromArgb (  248,   248,   248);
            lblExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblExit.Font = new System.Drawing.Font ("Consolas", 10F);
            lblExit.ForeColor = System.Drawing.Color.IndianRed;
            lblExit.Location = new System.Drawing.Point (0, 324);
            lblExit.Name = "lblExit";
            lblExit.Size = new System.Drawing.Size (812, 20);
            lblExit.TabIndex = 114;
            lblExit.Text = "Back";
            lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font ("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            label1.ForeColor = System.Drawing.Color.SteelBlue;
            label1.Location = new System.Drawing.Point (262, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size (69, 20);
            label1.TabIndex = 115;
            label1.Text = "share list:";
            // 
            // frmProjectShare
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb (  254,   254,   254);
            ClientSize = new System.Drawing.Size (812, 344);
            ControlBox = false;
            Controls.Add (label1);
            Controls.Add (lblExit);
            Controls.Add (lbl1);
            Controls.Add (lstUsr);
            Controls.Add (GridShare);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Name = "frmProjectShare";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Share";
            Load += frmProjectShare_Load;
            contextMenuStrip1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GridShare).EndInit ();
            contextMenuStrip2.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Cancel;
        private System.Windows.Forms.ToolStripMenuItem Menu_Transfer;
        private System.Windows.Forms.DataGridView GridShare;
        internal System.Windows.Forms.ListBox lstUsr;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem Menu2_Cancel;
        private System.Windows.Forms.ToolStripMenuItem Menu_AddToShareList;
        private System.Windows.Forms.ToolStripMenuItem Menu2_ChangeAccess;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label label1;
        }
    }