using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmSettings : Form
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmSettings));
            GridSettings = new DataGridView ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_ExitSetup = new ToolStripMenuItem ();
            FolderBrowserDialog1 = new FolderBrowserDialog ();
            panel1 = new Panel ();
            lblSaveExit = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridSettings).BeginInit ();
            ContextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridSettings
            // 
            GridSettings.AllowUserToAddRows = false;
            GridSettings.AllowUserToDeleteRows = false;
            GridSettings.AllowUserToOrderColumns = true;
            GridSettings.AllowUserToResizeColumns = false;
            GridSettings.AllowUserToResizeRows = false;
            GridSettings.BackgroundColor = SystemColors.Control;
            GridSettings.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.DimGray;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GridSettings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            GridSettings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            GridSettings.DefaultCellStyle = dataGridViewCellStyle2;
            GridSettings.Dock = DockStyle.Top;
            GridSettings.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridSettings.GridColor = SystemColors.ControlLight;
            GridSettings.Location = new Point (0, 0);
            GridSettings.Name = "GridSettings";
            GridSettings.RowHeadersVisible = false;
            GridSettings.SelectionMode = DataGridViewSelectionMode.CellSelect;
            GridSettings.Size = new Size (616, 277);
            GridSettings.TabIndex = 12;
            GridSettings.TabStop = false;
            GridSettings.CellDoubleClick += GridSettings_CellDoubleClick;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_ExitSetup });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size (144, 26);
            // 
            // Menu_ExitSetup
            // 
            Menu_ExitSetup.ForeColor = Color.IndianRed;
            Menu_ExitSetup.Name = "Menu_ExitSetup";
            Menu_ExitSetup.Size = new Size (143, 22);
            Menu_ExitSetup.Text = "Save and Exit";
            Menu_ExitSetup.Click += Menu_ExitSetup_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblSaveExit);
            panel1.Dock = DockStyle.Bottom;
            panel1.Font = new Font ("Segoe UI", 10F);
            panel1.Location = new Point (0, 308);
            panel1.Name = "panel1";
            panel1.Size = new Size (616, 18);
            panel1.TabIndex = 48;
            // 
            // lblSaveExit
            // 
            lblSaveExit.BackColor = Color.DarkSeaGreen;
            lblSaveExit.Dock = DockStyle.Bottom;
            lblSaveExit.Font = new Font ("Consolas", 10F);
            lblSaveExit.ForeColor = Color.White;
            lblSaveExit.ImeMode = ImeMode.NoControl;
            lblSaveExit.Location = new Point (0, 0);
            lblSaveExit.Name = "lblSaveExit";
            lblSaveExit.Size = new Size (616, 18);
            lblSaveExit.TabIndex = 46;
            lblSaveExit.Text = "Back";
            lblSaveExit.TextAlign = ContentAlignment.MiddleCenter;
            lblSaveExit.Click += lblSaveExit_Click;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb (  252,   252,   252);
            ClientSize = new Size (616, 326);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (GridSettings);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            Name = "frmSettings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            FormClosing += Settings_FormClosing;
            Load += Settings_Load;
            ((System.ComponentModel.ISupportInitialize) GridSettings).EndInit ();
            ContextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal DataGridView GridSettings;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_ExitSetup;
        internal FolderBrowserDialog FolderBrowserDialog1;
        private Panel panel1;
        private Label lblSaveExit;
        }
}