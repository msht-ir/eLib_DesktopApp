using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmCNN : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmCNN));
            GridCNN = new DataGridView ();
            MenuStripCNN = new ContextMenuStrip (components);
            Menu_Login = new ToolStripMenuItem ();
            ToolStripMenuItem2 = new ToolStripSeparator ();
            Menu_UseLocalDbs = new ToolStripMenuItem ();
            Menu_DeleteCnn = new ToolStripMenuItem ();
            Menu_Guide = new ToolStripMenuItem ();
            toolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Exit = new ToolStripMenuItem ();
            PasswordTextBox = new TextBox ();
            lbl_status = new Label ();
            lblExit = new Label ();
            panel1 = new Panel ();
            label2 = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridCNN).BeginInit ();
            MenuStripCNN.SuspendLayout ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridCNN
            // 
            GridCNN.AllowDrop = true;
            GridCNN.AllowUserToAddRows = false;
            GridCNN.AllowUserToDeleteRows = false;
            GridCNN.AllowUserToResizeColumns = false;
            GridCNN.AllowUserToResizeRows = false;
            GridCNN.BackgroundColor = Color.FromArgb (  249,   249,   249);
            GridCNN.BorderStyle = BorderStyle.None;
            GridCNN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridCNN.ColumnHeadersVisible = false;
            GridCNN.ContextMenuStrip = MenuStripCNN;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb (  249,   249,   249);
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb (  249,   249,   249);
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridCNN.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources (GridCNN, "GridCNN");
            GridCNN.EditMode = DataGridViewEditMode.EditProgrammatically;
            GridCNN.GridColor = Color.FromArgb (  249,   249,   249);
            GridCNN.MultiSelect = false;
            GridCNN.Name = "GridCNN";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            GridCNN.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            GridCNN.RowHeadersVisible = false;
            GridCNN.CellDoubleClick += GridCNN_CellDoubleClick;
            GridCNN.Click += GridCNN_Click;
            GridCNN.DragDrop += GridCNN_DragDrop;
            GridCNN.DragEnter += GridCNN_DragEnter;
            GridCNN.KeyDown += GridCNN_KeyDown;
            // 
            // MenuStripCNN
            // 
            MenuStripCNN.Items.AddRange (new ToolStripItem [] { Menu_Login, ToolStripMenuItem2, Menu_UseLocalDbs, Menu_DeleteCnn, Menu_Guide, toolStripMenuItem1, Menu_Exit });
            MenuStripCNN.Name = "MenuStripCNN";
            resources.ApplyResources (MenuStripCNN, "MenuStripCNN");
            // 
            // Menu_Login
            // 
            resources.ApplyResources (Menu_Login, "Menu_Login");
            Menu_Login.ForeColor = Color.RoyalBlue;
            Menu_Login.Name = "Menu_Login";
            Menu_Login.Click += Menu_Login_Click;
            // 
            // ToolStripMenuItem2
            // 
            ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            resources.ApplyResources (ToolStripMenuItem2, "ToolStripMenuItem2");
            // 
            // Menu_UseLocalDbs
            // 
            Menu_UseLocalDbs.Name = "Menu_UseLocalDbs";
            resources.ApplyResources (Menu_UseLocalDbs, "Menu_UseLocalDbs");
            Menu_UseLocalDbs.Click += Menu_UseLocalDbs_Click;
            // 
            // Menu_DeleteCnn
            // 
            Menu_DeleteCnn.Name = "Menu_DeleteCnn";
            resources.ApplyResources (Menu_DeleteCnn, "Menu_DeleteCnn");
            Menu_DeleteCnn.Click += Menu_DeleteCnn_Click;
            // 
            // Menu_Guide
            // 
            Menu_Guide.Name = "Menu_Guide";
            resources.ApplyResources (Menu_Guide, "Menu_Guide");
            Menu_Guide.Click += Menu_Guide_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources (toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            resources.ApplyResources (Menu_Exit, "Menu_Exit");
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.BackColor = SystemColors.ControlLightLight;
            PasswordTextBox.BorderStyle = BorderStyle.None;
            resources.ApplyResources (PasswordTextBox, "PasswordTextBox");
            PasswordTextBox.ForeColor = Color.MediumSlateBlue;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
            PasswordTextBox.KeyDown += PasswordTextBox_KeyDown;
            // 
            // lbl_status
            // 
            resources.ApplyResources (lbl_status, "lbl_status");
            lbl_status.ForeColor = Color.MediumSlateBlue;
            lbl_status.Name = "lbl_status";
            lbl_status.Click += lbl_status_Click;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.LightCoral;
            resources.ApplyResources (lblExit, "lblExit");
            lblExit.ForeColor = Color.White;
            lblExit.Name = "lblExit";
            lblExit.Click += lblExit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add (lblExit);
            resources.ApplyResources (panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // label2
            // 
            label2.BackColor = Color.CornflowerBlue;
            resources.ApplyResources (label2, "label2");
            label2.ForeColor = Color.White;
            label2.Name = "label2";
            // 
            // frmCNN
            // 
            resources.ApplyResources (this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ContextMenuStrip = MenuStripCNN;
            ControlBox = false;
            Controls.Add (lbl_status);
            Controls.Add (panel1);
            Controls.Add (GridCNN);
            Controls.Add (PasswordTextBox);
            Controls.Add (label2);
            ForeColor = Color.DarkSlateGray;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCNN";
            Load += frmCNN_Load;
            ((System.ComponentModel.ISupportInitialize) GridCNN).EndInit ();
            MenuStripCNN.ResumeLayout (false);
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal DataGridView GridCNN;
        internal ContextMenuStrip MenuStripCNN;
        internal ToolStripMenuItem Menu_Login;
        internal ToolStripMenuItem Menu_Exit;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem راهنماToolStripMenuItem;
        internal ToolStripMenuItem Menu_Guide;
        internal TextBox PasswordTextBox;
        internal ToolStripMenuItem Menu_ResetCnns;
        private Label lbl_status;
        private ToolStripMenuItem Menu_DeleteCnn;
        private Label lblExit;
        private Panel panel1;
        private ToolStripMenuItem Menu_UseLocalDbs;
        private ToolStripSeparator toolStripMenuItem1;
        private Label label2;
        }
    }