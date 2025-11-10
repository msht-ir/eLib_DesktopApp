using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmProject : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmProject));
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_Save = new ToolStripMenuItem ();
            Menu_Cancel = new ToolStripMenuItem ();
            txtProjectNote = new TextBox ();
            CheckBoxActive = new CheckBox ();
            txtProjectName = new MaskedTextBox ();
            panel1 = new Panel ();
            lblSave = new Label ();
            lblCancel = new Label ();
            ContextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_Save, Menu_Cancel });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            resources.ApplyResources (ContextMenuStrip1, "ContextMenuStrip1");
            // 
            // Menu_Save
            // 
            Menu_Save.Name = "Menu_Save";
            resources.ApplyResources (Menu_Save, "Menu_Save");
            Menu_Save.Click += Menu_Save_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            resources.ApplyResources (Menu_Cancel, "Menu_Cancel");
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // txtProjectNote
            // 
            txtProjectNote.BackColor = SystemColors.ButtonHighlight;
            txtProjectNote.ContextMenuStrip = ContextMenuStrip1;
            resources.ApplyResources (txtProjectNote, "txtProjectNote");
            txtProjectNote.ForeColor = Color.RoyalBlue;
            txtProjectNote.Name = "txtProjectNote";
            txtProjectNote.KeyDown += txtProjectNote_KeyDown;
            // 
            // CheckBoxActive
            // 
            resources.ApplyResources (CheckBoxActive, "CheckBoxActive");
            CheckBoxActive.Checked = true;
            CheckBoxActive.CheckState = CheckState.Checked;
            CheckBoxActive.ForeColor = Color.IndianRed;
            CheckBoxActive.Name = "CheckBoxActive";
            CheckBoxActive.TabStop = false;
            CheckBoxActive.UseVisualStyleBackColor = true;
            // 
            // txtProjectName
            // 
            txtProjectName.BackColor = SystemColors.ControlLightLight;
            txtProjectName.ContextMenuStrip = ContextMenuStrip1;
            resources.ApplyResources (txtProjectName, "txtProjectName");
            txtProjectName.ForeColor = Color.DarkRed;
            txtProjectName.Name = "txtProjectName";
            txtProjectName.KeyDown += txtProjectName_KeyDown;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblSave);
            panel1.Controls.Add (lblCancel);
            resources.ApplyResources (panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // lblSave
            // 
            lblSave.BackColor = Color.CornflowerBlue;
            resources.ApplyResources (lblSave, "lblSave");
            lblSave.ForeColor = SystemColors.ButtonHighlight;
            lblSave.Name = "lblSave";
            lblSave.Click += lblSave_Click;
            // 
            // lblCancel
            // 
            lblCancel.BackColor = Color.WhiteSmoke;
            resources.ApplyResources (lblCancel, "lblCancel");
            lblCancel.ForeColor = Color.IndianRed;
            lblCancel.Name = "lblCancel";
            lblCancel.Click += lblCancel_Click;
            // 
            // frmProject
            // 
            resources.ApplyResources (this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (txtProjectNote);
            Controls.Add (CheckBoxActive);
            Controls.Add (txtProjectName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProject";
            ShowIcon = false;
            ShowInTaskbar = false;
            TopMost = true;
            Load += frmProject_Load;
            KeyDown += frmProject_KeyDown;
            ContextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal TextBox txtProjectNote;
        internal CheckBox CheckBoxActive;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_Save;
        internal ToolStripMenuItem Menu_Cancel;
        internal MaskedTextBox txtProjectName;
        private Panel panel1;
        private Label lblSave;
        private Label lblCancel;
        }
}