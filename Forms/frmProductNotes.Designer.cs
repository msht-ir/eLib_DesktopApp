using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmNotes : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmNotes));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle ();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle ();
            txtNote = new TextBox ();
            MenuTextNote = new ContextMenuStrip (components);
            Menu4_Save = new ToolStripMenuItem ();
            Menu4_RTL = new ToolStripMenuItem ();
            Menu4_UpdateDateTime = new ToolStripMenuItem ();
            useTemplateToolStripMenuItem = new ToolStripMenuItem ();
            Menu4_Template_LectureNote = new ToolStripMenuItem ();
            Menu4_Template_Instruction = new ToolStripMenuItem ();
            toolStripMenuItem4 = new ToolStripSeparator ();
            Menu4_Template_Primer = new ToolStripMenuItem ();
            Menu4_Template_PCR = new ToolStripMenuItem ();
            Menu4_Template_Gel = new ToolStripMenuItem ();
            toolStripSeparator1 = new ToolStripSeparator ();
            Menu4_Exit = new ToolStripMenuItem ();
            MenuGridNotes = new ContextMenuStrip (components);
            Menu_SelectProject = new ToolStripMenuItem ();
            toolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Add = new ToolStripMenuItem ();
            Menu_Replace = new ToolStripMenuItem ();
            Menu_Del = new ToolStripMenuItem ();
            toolStripSeparator2 = new ToolStripSeparator ();
            Menu_Mindmap = new ToolStripMenuItem ();
            Menu_Cancel = new ToolStripMenuItem ();
            txtDatum = new MaskedTextBox ();
            MC1 = new MonthCalendar ();
            MenuCalendar = new ContextMenuStrip (components);
            Menu_CalendarAddNewNote = new ToolStripMenuItem ();
            lblCounter = new Label ();
            Grid6 = new DataGridView ();
            MenuGridDT = new ContextMenuStrip (components);
            Menu3_Exit = new ToolStripMenuItem ();
            lblSaveMe = new Label ();
            panel1 = new Panel ();
            btnSelectProject = new Button ();
            cboSubproject = new ComboBox ();
            lblDone = new Label ();
            lblMine = new Label ();
            lblMindmap = new Label ();
            panel2 = new Panel ();
            label1 = new Label ();
            MenuTextNote.SuspendLayout ();
            MenuGridNotes.SuspendLayout ();
            MenuCalendar.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) Grid6).BeginInit ();
            MenuGridDT.SuspendLayout ();
            panel1.SuspendLayout ();
            panel2.SuspendLayout ();
            SuspendLayout ();
            // 
            // txtNote
            // 
            txtNote.AllowDrop = true;
            txtNote.BackColor = Color.FromArgb (  243,   243,   243);
            txtNote.BorderStyle = BorderStyle.None;
            txtNote.ContextMenuStrip = MenuTextNote;
            resources.ApplyResources (txtNote, "txtNote");
            txtNote.ForeColor = Color.Black;
            txtNote.Name = "txtNote";
            txtNote.TextChanged += txtNote_TextChanged;
            txtNote.DragDrop += txtNote_DragDrop;
            txtNote.DragEnter += txtNote_DragEnter;
            txtNote.KeyDown += txtNote_KeyDown;
            // 
            // MenuTextNote
            // 
            MenuTextNote.Items.AddRange (new ToolStripItem [] { Menu4_Save, Menu4_RTL, Menu4_UpdateDateTime, useTemplateToolStripMenuItem, toolStripSeparator1, Menu4_Exit });
            MenuTextNote.Name = "contextMenuStrip3";
            resources.ApplyResources (MenuTextNote, "MenuTextNote");
            // 
            // Menu4_Save
            // 
            Menu4_Save.Name = "Menu4_Save";
            resources.ApplyResources (Menu4_Save, "Menu4_Save");
            Menu4_Save.Click += Menu4_Save_Click;
            // 
            // Menu4_RTL
            // 
            Menu4_RTL.Name = "Menu4_RTL";
            resources.ApplyResources (Menu4_RTL, "Menu4_RTL");
            Menu4_RTL.Click += Menu4_RTL_Click;
            // 
            // Menu4_UpdateDateTime
            // 
            Menu4_UpdateDateTime.Name = "Menu4_UpdateDateTime";
            resources.ApplyResources (Menu4_UpdateDateTime, "Menu4_UpdateDateTime");
            Menu4_UpdateDateTime.Click += Menu4_UpdateDateTime_Click;
            // 
            // useTemplateToolStripMenuItem
            // 
            useTemplateToolStripMenuItem.DropDownItems.AddRange (new ToolStripItem [] { Menu4_Template_LectureNote, Menu4_Template_Instruction, toolStripMenuItem4, Menu4_Template_Primer, Menu4_Template_PCR, Menu4_Template_Gel });
            useTemplateToolStripMenuItem.Name = "useTemplateToolStripMenuItem";
            resources.ApplyResources (useTemplateToolStripMenuItem, "useTemplateToolStripMenuItem");
            // 
            // Menu4_Template_LectureNote
            // 
            Menu4_Template_LectureNote.Name = "Menu4_Template_LectureNote";
            resources.ApplyResources (Menu4_Template_LectureNote, "Menu4_Template_LectureNote");
            Menu4_Template_LectureNote.Click += Menu4_Template_LectureNote_Click;
            // 
            // Menu4_Template_Instruction
            // 
            Menu4_Template_Instruction.Name = "Menu4_Template_Instruction";
            resources.ApplyResources (Menu4_Template_Instruction, "Menu4_Template_Instruction");
            Menu4_Template_Instruction.Click += Menu4_Template_Instruction_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources (toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // Menu4_Template_Primer
            // 
            Menu4_Template_Primer.Name = "Menu4_Template_Primer";
            resources.ApplyResources (Menu4_Template_Primer, "Menu4_Template_Primer");
            Menu4_Template_Primer.Click += Menu4_Template_Primer_Click;
            // 
            // Menu4_Template_PCR
            // 
            Menu4_Template_PCR.Name = "Menu4_Template_PCR";
            resources.ApplyResources (Menu4_Template_PCR, "Menu4_Template_PCR");
            Menu4_Template_PCR.Click += Menu4_Template_PCR_Click;
            // 
            // Menu4_Template_Gel
            // 
            Menu4_Template_Gel.Name = "Menu4_Template_Gel";
            resources.ApplyResources (Menu4_Template_Gel, "Menu4_Template_Gel");
            Menu4_Template_Gel.Click += Menu4_Template_Gel_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources (toolStripSeparator1, "toolStripSeparator1");
            // 
            // Menu4_Exit
            // 
            Menu4_Exit.ForeColor = Color.IndianRed;
            Menu4_Exit.Name = "Menu4_Exit";
            resources.ApplyResources (Menu4_Exit, "Menu4_Exit");
            Menu4_Exit.Click += Menu4_Exit_Click;
            // 
            // MenuGridNotes
            // 
            MenuGridNotes.Items.AddRange (new ToolStripItem [] { Menu_SelectProject, toolStripMenuItem1, Menu_Add, Menu_Replace, Menu_Del, toolStripSeparator2, Menu_Mindmap, Menu_Cancel });
            MenuGridNotes.Name = "ContextMenuStrip1";
            resources.ApplyResources (MenuGridNotes, "MenuGridNotes");
            // 
            // Menu_SelectProject
            // 
            Menu_SelectProject.ForeColor = SystemColors.HotTrack;
            Menu_SelectProject.Name = "Menu_SelectProject";
            resources.ApplyResources (Menu_SelectProject, "Menu_SelectProject");
            Menu_SelectProject.Click += Menu_SelectProject_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources (toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // Menu_Add
            // 
            Menu_Add.Name = "Menu_Add";
            resources.ApplyResources (Menu_Add, "Menu_Add");
            Menu_Add.Click += Menu_Add_Click;
            // 
            // Menu_Replace
            // 
            Menu_Replace.Name = "Menu_Replace";
            resources.ApplyResources (Menu_Replace, "Menu_Replace");
            Menu_Replace.Click += Menu_Replace_Click;
            // 
            // Menu_Del
            // 
            Menu_Del.ForeColor = Color.IndianRed;
            Menu_Del.Name = "Menu_Del";
            resources.ApplyResources (Menu_Del, "Menu_Del");
            Menu_Del.Click += Menu_Del_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources (toolStripSeparator2, "toolStripSeparator2");
            // 
            // Menu_Mindmap
            // 
            Menu_Mindmap.Name = "Menu_Mindmap";
            resources.ApplyResources (Menu_Mindmap, "Menu_Mindmap");
            Menu_Mindmap.Click += Menu_Mindmap_Click;
            // 
            // Menu_Cancel
            // 
            Menu_Cancel.ForeColor = Color.IndianRed;
            Menu_Cancel.Name = "Menu_Cancel";
            resources.ApplyResources (Menu_Cancel, "Menu_Cancel");
            Menu_Cancel.Click += Menu_Cancel_Click;
            // 
            // txtDatum
            // 
            txtDatum.BackColor = SystemColors.Window;
            txtDatum.BorderStyle = BorderStyle.None;
            txtDatum.ContextMenuStrip = MenuGridNotes;
            resources.ApplyResources (txtDatum, "txtDatum");
            txtDatum.ForeColor = Color.IndianRed;
            txtDatum.Name = "txtDatum";
            txtDatum.TabStop = false;
            txtDatum.Click += txtDatum_Click;
            txtDatum.TextChanged += txtDatum_TextChanged;
            txtDatum.KeyDown += txtDatum_KeyDown;
            // 
            // MC1
            // 
            MC1.BackColor = SystemColors.ControlLight;
            resources.ApplyResources (MC1, "MC1");
            MC1.ContextMenuStrip = MenuCalendar;
            MC1.Name = "MC1";
            MC1.TabStop = false;
            // 
            // MenuCalendar
            // 
            MenuCalendar.Items.AddRange (new ToolStripItem [] { Menu_CalendarAddNewNote });
            MenuCalendar.Name = "contextMenuStrip2";
            resources.ApplyResources (MenuCalendar, "MenuCalendar");
            // 
            // Menu_CalendarAddNewNote
            // 
            Menu_CalendarAddNewNote.ForeColor = Color.IndianRed;
            Menu_CalendarAddNewNote.Name = "Menu_CalendarAddNewNote";
            resources.ApplyResources (Menu_CalendarAddNewNote, "Menu_CalendarAddNewNote");
            Menu_CalendarAddNewNote.Click += Menu_CalendarAddNewNote_Click;
            // 
            // lblCounter
            // 
            resources.ApplyResources (lblCounter, "lblCounter");
            lblCounter.ForeColor = Color.SteelBlue;
            lblCounter.Name = "lblCounter";
            // 
            // Grid6
            // 
            Grid6.AllowUserToAddRows = false;
            Grid6.AllowUserToDeleteRows = false;
            Grid6.AllowUserToResizeColumns = false;
            Grid6.AllowUserToResizeRows = false;
            Grid6.BackgroundColor = Color.FromArgb (  248,   248,   248);
            Grid6.BorderStyle = BorderStyle.None;
            Grid6.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid6.ColumnHeadersVisible = false;
            Grid6.ContextMenuStrip = MenuGridNotes;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb (  248,   248,   248);
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 8F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb (  244,   244,   244);
            dataGridViewCellStyle1.SelectionForeColor = Color.IndianRed;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            Grid6.DefaultCellStyle = dataGridViewCellStyle1;
            Grid6.EditMode = DataGridViewEditMode.EditProgrammatically;
            Grid6.GridColor = Color.FromArgb (  246,   246,   246);
            resources.ApplyResources (Grid6, "Grid6");
            Grid6.MultiSelect = false;
            Grid6.Name = "Grid6";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Grid6.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            Grid6.RowHeadersVisible = false;
            Grid6.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            Grid6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid6.CellClick += Grid6_CellClick;
            Grid6.CellDoubleClick += Grid6_CellDoubleClick;
            Grid6.KeyDown += Grid6_KeyDown;
            // 
            // MenuGridDT
            // 
            MenuGridDT.Items.AddRange (new ToolStripItem [] { Menu3_Exit });
            MenuGridDT.Name = "contextMenuStrip3";
            resources.ApplyResources (MenuGridDT, "MenuGridDT");
            // 
            // Menu3_Exit
            // 
            Menu3_Exit.ForeColor = Color.IndianRed;
            Menu3_Exit.Name = "Menu3_Exit";
            resources.ApplyResources (Menu3_Exit, "Menu3_Exit");
            Menu3_Exit.Click += Menu3_Exit_Click;
            // 
            // lblSaveMe
            // 
            lblSaveMe.BackColor = Color.LightCoral;
            resources.ApplyResources (lblSaveMe, "lblSaveMe");
            lblSaveMe.ForeColor = SystemColors.ButtonHighlight;
            lblSaveMe.Name = "lblSaveMe";
            lblSaveMe.Click += lblSaveMe_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add (btnSelectProject);
            panel1.Controls.Add (txtDatum);
            panel1.Controls.Add (cboSubproject);
            panel1.Controls.Add (lblDone);
            panel1.Controls.Add (lblSaveMe);
            panel1.Controls.Add (lblMine);
            resources.ApplyResources (panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // btnSelectProject
            // 
            resources.ApplyResources (btnSelectProject, "btnSelectProject");
            btnSelectProject.Name = "btnSelectProject";
            btnSelectProject.UseVisualStyleBackColor = true;
            btnSelectProject.Click += btnSelectProject_Click;
            // 
            // cboSubproject
            // 
            cboSubproject.BackColor = Color.WhiteSmoke;
            cboSubproject.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources (cboSubproject, "cboSubproject");
            cboSubproject.ForeColor = Color.SteelBlue;
            cboSubproject.FormattingEnabled = true;
            cboSubproject.Name = "cboSubproject";
            cboSubproject.SelectedIndexChanged += cboSubproject_SelectedIndexChanged;
            cboSubproject.KeyDown += cboSubproject_KeyDown;
            // 
            // lblDone
            // 
            lblDone.BackColor = Color.DarkSeaGreen;
            resources.ApplyResources (lblDone, "lblDone");
            lblDone.ForeColor = Color.White;
            lblDone.Name = "lblDone";
            lblDone.Click += lblDone_Click;
            // 
            // lblMine
            // 
            lblMine.BackColor = Color.DarkSeaGreen;
            resources.ApplyResources (lblMine, "lblMine");
            lblMine.ForeColor = SystemColors.ButtonHighlight;
            lblMine.Name = "lblMine";
            // 
            // lblMindmap
            // 
            lblMindmap.BackColor = Color.DarkSeaGreen;
            resources.ApplyResources (lblMindmap, "lblMindmap");
            lblMindmap.ForeColor = Color.White;
            lblMindmap.Name = "lblMindmap";
            lblMindmap.Click += lblMindmap_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add (lblCounter);
            panel2.Controls.Add (label1);
            panel2.Controls.Add (lblMindmap);
            resources.ApplyResources (panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // label1
            // 
            label1.BackColor = Color.CornflowerBlue;
            resources.ApplyResources (label1, "label1");
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // frmNotes
            // 
            resources.ApplyResources (this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ContextMenuStrip = MenuGridNotes;
            ControlBox = false;
            Controls.Add (panel2);
            Controls.Add (MC1);
            Controls.Add (panel1);
            Controls.Add (Grid6);
            Controls.Add (txtNote);
            DoubleBuffered = true;
            ForeColor = SystemColors.WindowText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmNotes";
            ShowIcon = false;
            ShowInTaskbar = false;
            Load += frmNotes_Load;
            DoubleClick += frmNotes_DoubleClick;
            MenuTextNote.ResumeLayout (false);
            MenuGridNotes.ResumeLayout (false);
            MenuCalendar.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) Grid6).EndInit ();
            MenuGridDT.ResumeLayout (false);
            panel1.ResumeLayout (false);
            panel1.PerformLayout ();
            panel2.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        internal TextBox txtNote;
        internal ContextMenuStrip MenuGridNotes;
        internal ToolStripMenuItem Menu_Cancel;
        internal MaskedTextBox txtDatum;
        internal MonthCalendar MC1;
        private Label lblCounter;
        private ToolStripMenuItem Menu_Add;
        private ToolStripMenuItem Menu_Del;
        internal DataGridView Grid6;
        private ContextMenuStrip MenuCalendar;
        private ToolStripMenuItem Menu_CalendarAddNewNote;
        private ContextMenuStrip MenuGridDT;
        private ToolStripMenuItem Menu3_Exit;
        private ToolStripMenuItem Menu_Replace;
        private Label lblSaveMe;
        private ContextMenuStrip MenuTextNote;
        private ToolStripMenuItem Menu4_Save;
        private ToolStripMenuItem Menu4_UpdateDateTime;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem Menu4_Exit;
        private ToolStripMenuItem useTemplateToolStripMenuItem;
        private ToolStripMenuItem Menu4_Template_Primer;
        private ToolStripMenuItem Menu4_Template_PCR;
        private ToolStripMenuItem Menu4_Template_Gel;
        private ToolStripMenuItem Menu4_Template_LectureNote;
        private ToolStripMenuItem Menu4_Template_Instruction;
        private ToolStripSeparator toolStripMenuItem4;
        private Panel panel1;
        private ToolStripMenuItem Menu4_RTL;
        private Label lblMine;
        private Label lblDone;
        private ComboBox cboSubproject;
        private ToolStripMenuItem Menu_SelectProject;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem Menu_Mindmap;
        private Label lblMindmap;
        private Panel panel2;
        private Label label1;
        private Button btnSelectProject;
        }
}