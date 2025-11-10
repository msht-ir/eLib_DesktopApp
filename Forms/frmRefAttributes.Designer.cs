using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmRefAttributes : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode ()]
        protected override void Dispose (bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose ();
                }
            }
            finally
            {
                base.Dispose (disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough ()]
        private void InitializeComponent ()
            {
            components = new System.ComponentModel.Container ();
            CheckBoxImp3 = new CheckBox ();
            CheckBoxImp2 = new CheckBox ();
            CheckBoxLecture = new CheckBox ();
            CheckBoxImp1 = new CheckBox ();
            CheckBoxManual = new CheckBox ();
            CheckBoxImR = new CheckBox ();
            CheckBoxBook = new CheckBox ();
            CheckBoxPaper = new CheckBox ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_Save = new ToolStripMenuItem ();
            Menu_Cancel = new ToolStripMenuItem ();
            LabelRefTitle = new Label ();
            lblSave = new Label ();
            panel1 = new Panel ();
            lblBack = new Label ();
            ContextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // CheckBoxImp3
            // 
            CheckBoxImp3.AutoSize = true;
            CheckBoxImp3.Font = new Font ("Segoe UI", 10F);
            CheckBoxImp3.ForeColor = Color.Brown;
            CheckBoxImp3.Location = new Point (407, 152);
            CheckBoxImp3.Name = "CheckBoxImp3";
            CheckBoxImp3.Size = new Size (60, 23);
            CheckBoxImp3.TabIndex = 7;
            CheckBoxImp3.TabStop = false;
            CheckBoxImp3.Text = "Imp3";
            CheckBoxImp3.UseVisualStyleBackColor = true;
            // 
            // CheckBoxImp2
            // 
            CheckBoxImp2.AutoSize = true;
            CheckBoxImp2.Font = new Font ("Segoe UI", 10F);
            CheckBoxImp2.ForeColor = Color.Brown;
            CheckBoxImp2.Location = new Point (293, 152);
            CheckBoxImp2.Name = "CheckBoxImp2";
            CheckBoxImp2.Size = new Size (60, 23);
            CheckBoxImp2.TabIndex = 6;
            CheckBoxImp2.TabStop = false;
            CheckBoxImp2.Text = "Imp2";
            CheckBoxImp2.UseVisualStyleBackColor = true;
            // 
            // CheckBoxLecture
            // 
            CheckBoxLecture.AutoSize = true;
            CheckBoxLecture.Font = new Font ("Segoe UI", 10F);
            CheckBoxLecture.ForeColor = Color.MediumBlue;
            CheckBoxLecture.Location = new Point (532, 96);
            CheckBoxLecture.Name = "CheckBoxLecture";
            CheckBoxLecture.Size = new Size (73, 23);
            CheckBoxLecture.TabIndex = 3;
            CheckBoxLecture.TabStop = false;
            CheckBoxLecture.Text = "Lecture";
            CheckBoxLecture.UseVisualStyleBackColor = true;
            // 
            // CheckBoxImp1
            // 
            CheckBoxImp1.AutoSize = true;
            CheckBoxImp1.Font = new Font ("Segoe UI", 10F);
            CheckBoxImp1.ForeColor = Color.Brown;
            CheckBoxImp1.Location = new Point (165, 152);
            CheckBoxImp1.Name = "CheckBoxImp1";
            CheckBoxImp1.Size = new Size (60, 23);
            CheckBoxImp1.TabIndex = 5;
            CheckBoxImp1.TabStop = false;
            CheckBoxImp1.Text = "Imp1";
            CheckBoxImp1.UseVisualStyleBackColor = true;
            // 
            // CheckBoxManual
            // 
            CheckBoxManual.AutoSize = true;
            CheckBoxManual.Font = new Font ("Segoe UI", 10F);
            CheckBoxManual.ForeColor = Color.MediumBlue;
            CheckBoxManual.Location = new Point (407, 96);
            CheckBoxManual.Name = "CheckBoxManual";
            CheckBoxManual.Size = new Size (74, 23);
            CheckBoxManual.TabIndex = 2;
            CheckBoxManual.TabStop = false;
            CheckBoxManual.Text = "Manual";
            CheckBoxManual.UseVisualStyleBackColor = true;
            // 
            // CheckBoxImR
            // 
            CheckBoxImR.AutoSize = true;
            CheckBoxImR.Font = new Font ("Segoe UI", 10F, FontStyle.Bold);
            CheckBoxImR.ForeColor = Color.OliveDrab;
            CheckBoxImR.Location = new Point (532, 152);
            CheckBoxImR.Name = "CheckBoxImR";
            CheckBoxImR.Size = new Size (54, 23);
            CheckBoxImR.TabIndex = 4;
            CheckBoxImR.TabStop = false;
            CheckBoxImR.Text = "ImR";
            CheckBoxImR.UseVisualStyleBackColor = true;
            // 
            // CheckBoxBook
            // 
            CheckBoxBook.AutoSize = true;
            CheckBoxBook.Font = new Font ("Segoe UI", 10F);
            CheckBoxBook.ForeColor = Color.MediumBlue;
            CheckBoxBook.Location = new Point (293, 96);
            CheckBoxBook.Name = "CheckBoxBook";
            CheckBoxBook.Size = new Size (59, 23);
            CheckBoxBook.TabIndex = 1;
            CheckBoxBook.TabStop = false;
            CheckBoxBook.Text = "Book";
            CheckBoxBook.UseVisualStyleBackColor = true;
            // 
            // CheckBoxPaper
            // 
            CheckBoxPaper.AutoSize = true;
            CheckBoxPaper.Font = new Font ("Segoe UI", 10F);
            CheckBoxPaper.ForeColor = Color.MediumBlue;
            CheckBoxPaper.Location = new Point (165, 96);
            CheckBoxPaper.Name = "CheckBoxPaper";
            CheckBoxPaper.Size = new Size (63, 23);
            CheckBoxPaper.TabIndex = 0;
            CheckBoxPaper.TabStop = false;
            CheckBoxPaper.Text = "Paper";
            CheckBoxPaper.UseVisualStyleBackColor = true;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_Save, Menu_Cancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size (139, 48);
            // 
            // Menu_Save
            // 
            Menu_Save.Name = "Menu_Save";
            Menu_Save.ShortcutKeys =  Keys.Control | Keys.S;
            Menu_Save.Size = new Size (138, 22);
            Menu_Save.Text = "Save";
            Menu_Save.Click += Menu_Save_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            Menu_Cancel.Size = new Size (138, 22);
            Menu_Cancel.Text = "Cancel";
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // LabelRefTitle
            // 
            LabelRefTitle.BackColor = SystemColors.ButtonFace;
            LabelRefTitle.Dock = DockStyle.Top;
            LabelRefTitle.Font = new Font ("Segoe UI", 10F);
            LabelRefTitle.Location = new Point (0, 0);
            LabelRefTitle.Name = "LabelRefTitle";
            LabelRefTitle.Size = new Size (728, 69);
            LabelRefTitle.TabIndex = 8;
            LabelRefTitle.Text = "-";
            LabelRefTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSave
            // 
            lblSave.BackColor = Color.CornflowerBlue;
            lblSave.Dock = DockStyle.Left;
            lblSave.Font = new Font ("Consolas", 10F);
            lblSave.ForeColor = Color.White;
            lblSave.Location = new Point (0, 0);
            lblSave.Name = "lblSave";
            lblSave.Size = new Size (180, 18);
            lblSave.TabIndex = 118;
            lblSave.Text = "Save";
            lblSave.TextAlign = ContentAlignment.MiddleCenter;
            lblSave.Click += lblSave_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblBack);
            panel1.Controls.Add (lblSave);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 203);
            panel1.Name = "panel1";
            panel1.Size = new Size (728, 18);
            panel1.TabIndex = 173;
            // 
            // lblBack
            // 
            lblBack.BackColor = Color.WhiteSmoke;
            lblBack.Dock = DockStyle.Right;
            lblBack.Font = new Font ("Consolas", 10F);
            lblBack.ForeColor = Color.IndianRed;
            lblBack.Location = new Point (548, 0);
            lblBack.Name = "lblBack";
            lblBack.Size = new Size (180, 18);
            lblBack.TabIndex = 119;
            lblBack.Text = "Back";
            lblBack.TextAlign = ContentAlignment.MiddleCenter;
            lblBack.Click += lblBack_Click;
            // 
            // frmRefAttributes
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size (728, 221);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (CheckBoxImp3);
            Controls.Add (CheckBoxImp2);
            Controls.Add (CheckBoxLecture);
            Controls.Add (LabelRefTitle);
            Controls.Add (CheckBoxImp1);
            Controls.Add (CheckBoxManual);
            Controls.Add (CheckBoxImR);
            Controls.Add (CheckBoxPaper);
            Controls.Add (CheckBoxBook);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRefAttributes";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tags";
            Load += frmRefAttributes_Load;
            KeyDown += frmRefAttributes_KeyDown;
            ContextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal CheckBox CheckBoxLecture;
        internal CheckBox CheckBoxManual;
        internal CheckBox CheckBoxBook;
        internal CheckBox CheckBoxPaper;
        internal CheckBox CheckBoxImp3;
        internal CheckBox CheckBoxImp2;
        internal CheckBox CheckBoxImp1;
        internal CheckBox CheckBoxImR;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_Save;
        internal ToolStripMenuItem Menu_Cancel;
        internal Label LabelRefTitle;
        private Label lblSave;
        private Panel panel1;
        private Label lblBack;
        }
}