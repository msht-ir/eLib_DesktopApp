namespace eLib.Forms
    {
    partial class frmAugustusTranscriptEdit
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
            txtTranscriptName = new System.Windows.Forms.TextBox ();
            txtGeneSize = new System.Windows.Forms.TextBox ();
            chkSel = new System.Windows.Forms.CheckBox ();
            label1 = new System.Windows.Forms.Label ();
            label2 = new System.Windows.Forms.Label ();
            label3 = new System.Windows.Forms.Label ();
            txtFunction = new System.Windows.Forms.TextBox ();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip (components);
            Menu_Save = new System.Windows.Forms.ToolStripMenuItem ();
            Menu_Cancel = new System.Windows.Forms.ToolStripMenuItem ();
            txtInfo = new System.Windows.Forms.TextBox ();
            label5 = new System.Windows.Forms.Label ();
            lblSave = new System.Windows.Forms.Label ();
            panel1 = new System.Windows.Forms.Panel ();
            label6 = new System.Windows.Forms.Label ();
            contextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // txtTranscriptName
            // 
            txtTranscriptName.BackColor = System.Drawing.Color.FromArgb (  246,   246,   246);
            txtTranscriptName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtTranscriptName.Font = new System.Drawing.Font ("Segoe UI", 10F);
            txtTranscriptName.Location = new System.Drawing.Point (72, 12);
            txtTranscriptName.Name = "txtTranscriptName";
            txtTranscriptName.Size = new System.Drawing.Size (692, 18);
            txtTranscriptName.TabIndex = 0;
            txtTranscriptName.KeyDown += txtTranscriptName_KeyDown;
            // 
            // txtGeneSize
            // 
            txtGeneSize.BackColor = System.Drawing.Color.FromArgb (  246,   246,   246);
            txtGeneSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtGeneSize.Font = new System.Drawing.Font ("Segoe UI", 10F);
            txtGeneSize.Location = new System.Drawing.Point (868, 50);
            txtGeneSize.Name = "txtGeneSize";
            txtGeneSize.Size = new System.Drawing.Size (73, 18);
            txtGeneSize.TabIndex = 2;
            txtGeneSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtGeneSize.KeyDown += txtGeneSize_KeyDown;
            // 
            // chkSel
            // 
            chkSel.AutoSize = true;
            chkSel.Font = new System.Drawing.Font ("Segoe UI", 9F);
            chkSel.ForeColor = System.Drawing.SystemColors.HotTrack;
            chkSel.Location = new System.Drawing.Point (972, 49);
            chkSel.Name = "chkSel";
            chkSel.Size = new System.Drawing.Size (67, 19);
            chkSel.TabIndex = 4;
            chkSel.Text = "Primary";
            chkSel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font ("Segoe UI", 9F);
            label1.ForeColor = System.Drawing.Color.IndianRed;
            label1.Location = new System.Drawing.Point (805, 53);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size (57, 15);
            label1.TabIndex = 5;
            label1.Text = "Gene Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point (12, 14);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size (39, 15);
            label2.TabIndex = 5;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point (12, 53);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size (54, 15);
            label3.TabIndex = 8;
            label3.Text = "Function";
            // 
            // txtFunction
            // 
            txtFunction.BackColor = System.Drawing.Color.FromArgb (  246,   246,   246);
            txtFunction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtFunction.Font = new System.Drawing.Font ("Segoe UI", 10F);
            txtFunction.Location = new System.Drawing.Point (72, 50);
            txtFunction.Name = "txtFunction";
            txtFunction.Size = new System.Drawing.Size (692, 18);
            txtFunction.TabIndex = 1;
            txtFunction.KeyDown += txtFunction_KeyDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new System.Windows.Forms.ToolStripItem [] { Menu_Save, Menu_Cancel });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size (154, 48);
            // 
            // Menu_Save
            // 
            Menu_Save.Name = "Menu_Save";
            Menu_Save.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            Menu_Save.Size = new System.Drawing.Size (153, 22);
            Menu_Save.Text = "Save";
            Menu_Save.Click += Menu_Save_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = System.Drawing.Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.ShortcutKeys =  System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
            Menu_Cancel.Size = new System.Drawing.Size (153, 22);
            Menu_Cancel.Text = "Cancel";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // txtInfo
            // 
            txtInfo.AllowDrop = true;
            txtInfo.BackColor = System.Drawing.Color.FromArgb (  246,   246,   246);
            txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtInfo.ContextMenuStrip = contextMenuStrip1;
            txtInfo.Location = new System.Drawing.Point (72, 91);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtInfo.Size = new System.Drawing.Size (970, 381);
            txtInfo.TabIndex = 3;
            txtInfo.DragDrop += txtInfo_DragDrop;
            txtInfo.DragEnter += txtInfo_DragEnter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point (12, 91);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size (28, 15);
            label5.TabIndex = 11;
            label5.Text = "Info";
            // 
            // lblSave
            // 
            lblSave.BackColor = System.Drawing.Color.LightCoral;
            lblSave.Font = new System.Drawing.Font ("Segoe UI", 11F);
            lblSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lblSave.Location = new System.Drawing.Point (868, 12);
            lblSave.Name = "lblSave";
            lblSave.Size = new System.Drawing.Size (171, 20);
            lblSave.TabIndex = 12;
            lblSave.Text = "Save";
            lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblSave.Click += lblSave_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (label6);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point (0, 505);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size (1067, 18);
            panel1.TabIndex = 152;
            // 
            // label6
            // 
            label6.BackColor = System.Drawing.Color.WhiteSmoke;
            label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            label6.Font = new System.Drawing.Font ("Consolas", 10F);
            label6.ForeColor = System.Drawing.Color.IndianRed;
            label6.Location = new System.Drawing.Point (0, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size (1067, 18);
            label6.TabIndex = 10;
            label6.Text = "Back";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label6.Click += label6_Click;
            // 
            // frmAugustusTranscriptEdit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF (7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ButtonHighlight;
            ClientSize = new System.Drawing.Size (1067, 523);
            ContextMenuStrip = contextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (lblSave);
            Controls.Add (label5);
            Controls.Add (txtInfo);
            Controls.Add (txtFunction);
            Controls.Add (chkSel);
            Controls.Add (txtGeneSize);
            Controls.Add (txtTranscriptName);
            Controls.Add (label3);
            Controls.Add (label2);
            Controls.Add (label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAugustusTranscriptEdit";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Edit Transcript";
            Load += frmAugustusTranscriptEdit_Load;
            KeyDown += frmAugustusTranscriptEdit_KeyDown;
            contextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private System.Windows.Forms.TextBox txtTranscriptName;
        private System.Windows.Forms.TextBox txtGeneSize;
        private System.Windows.Forms.CheckBox chkSel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Save;
        private System.Windows.Forms.ToolStripMenuItem Menu_Cancel;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        }
    }