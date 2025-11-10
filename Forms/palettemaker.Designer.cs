using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
    {
    partial class palettemaker : Form
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
            {
            components = new System.ComponentModel.Container ();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle ();
            GridPalette = new DataGridView ();
            ID = new DataGridViewTextBoxColumn ();
            Red = new DataGridViewTextBoxColumn ();
            G = new DataGridViewTextBoxColumn ();
            B = new DataGridViewTextBoxColumn ();
            Color = new DataGridViewTextBoxColumn ();
            contextMenuStrip1 = new ContextMenuStrip (components);
            Menu_NewRandomPalette = new ToolStripMenuItem ();
            Menu_Open = new ToolStripMenuItem ();
            Menu_SaveAs = new ToolStripMenuItem ();
            toolStripMenuItem1 = new ToolStripSeparator ();
            Menu_OkUsePalette = new ToolStripMenuItem ();
            GaugeR = new TrackBar ();
            GaugeG = new TrackBar ();
            GaugeB = new TrackBar ();
            panel1 = new Panel ();
            label1 = new Label ();
            label2 = new Label ();
            ((System.ComponentModel.ISupportInitialize) GridPalette).BeginInit ();
            contextMenuStrip1.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) GaugeR).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) GaugeG).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) GaugeB).BeginInit ();
            panel1.SuspendLayout ();
            SuspendLayout ();
            // 
            // GridPalette
            // 
            GridPalette.AllowUserToAddRows = false;
            GridPalette.AllowUserToDeleteRows = false;
            GridPalette.AllowUserToResizeColumns = false;
            GridPalette.AllowUserToResizeRows = false;
            GridPalette.BackgroundColor = SystemColors.ControlLightLight;
            GridPalette.BorderStyle = BorderStyle.None;
            GridPalette.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridPalette.Columns.AddRange (new DataGridViewColumn [] { ID, Red, G, B, Color });
            GridPalette.ContextMenuStrip = contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Font = new Font ("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridPalette.DefaultCellStyle = dataGridViewCellStyle1;
            GridPalette.Dock = DockStyle.Top;
            GridPalette.GridColor = SystemColors.Menu;
            GridPalette.Location = new Point (0, 0);
            GridPalette.Name = "GridPalette";
            GridPalette.RowHeadersVisible = false;
            GridPalette.Size = new Size (464, 425);
            GridPalette.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.Width = 50;
            // 
            // Red
            // 
            Red.HeaderText = "Red";
            Red.Name = "Red";
            // 
            // G
            // 
            G.HeaderText = "Green";
            G.Name = "G";
            // 
            // B
            // 
            B.HeaderText = "Blue";
            B.Name = "B";
            // 
            // Color
            // 
            Color.HeaderText = "Color";
            Color.Name = "Color";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_NewRandomPalette, Menu_Open, Menu_SaveAs, toolStripMenuItem1, Menu_OkUsePalette });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size (124, 98);
            // 
            // Menu_NewRandomPalette
            // 
            Menu_NewRandomPalette.Name = "Menu_NewRandomPalette";
            Menu_NewRandomPalette.Size = new Size (123, 22);
            Menu_NewRandomPalette.Text = "New";
            Menu_NewRandomPalette.Click += Menu_NewRandomPalette_Click;
            // 
            // Menu_Open
            // 
            Menu_Open.Name = "Menu_Open";
            Menu_Open.Size = new Size (123, 22);
            Menu_Open.Text = "Open...";
            Menu_Open.Click += Menu_Open_Click;
            // 
            // Menu_SaveAs
            // 
            Menu_SaveAs.Name = "Menu_SaveAs";
            Menu_SaveAs.Size = new Size (123, 22);
            Menu_SaveAs.Text = "Save As...";
            Menu_SaveAs.Click += Menu_SaveAs_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size (120, 6);
            // 
            // Menu_OkUsePalette
            // 
            Menu_OkUsePalette.Name = "Menu_OkUsePalette";
            Menu_OkUsePalette.Size = new Size (123, 22);
            Menu_OkUsePalette.Text = "OK";
            Menu_OkUsePalette.Click += Menu_OkUsePalette_Click;
            // 
            // GaugeR
            // 
            GaugeR.Location = new Point (12, 435);
            GaugeR.Maximum = 255;
            GaugeR.Name = "GaugeR";
            GaugeR.Size = new Size (440, 45);
            GaugeR.TabIndex = 6;
            GaugeR.Scroll += GaugeR_Scroll;
            GaugeR.KeyDown += GaugeR_KeyDown;
            // 
            // GaugeG
            // 
            GaugeG.Location = new Point (12, 469);
            GaugeG.Maximum = 255;
            GaugeG.Name = "GaugeG";
            GaugeG.Size = new Size (440, 45);
            GaugeG.TabIndex = 7;
            GaugeG.Scroll += GaugeG_Scroll;
            GaugeG.KeyDown += GaugeG_KeyDown;
            // 
            // GaugeB
            // 
            GaugeB.Location = new Point (12, 504);
            GaugeB.Maximum = 255;
            GaugeB.Name = "GaugeB";
            GaugeB.Size = new Size (440, 45);
            GaugeB.TabIndex = 8;
            GaugeB.Scroll += GaugeB_Scroll;
            GaugeB.KeyDown += GaugeB_KeyDown;
            // 
            // panel1
            // 
            panel1.Controls.Add (label1);
            panel1.Controls.Add (label2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 561);
            panel1.Name = "panel1";
            panel1.Size = new Size (464, 20);
            panel1.TabIndex = 152;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.Control;
            label1.Dock = DockStyle.Right;
            label1.Font = new Font ("Consolas", 10F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point (116, 0);
            label1.Name = "label1";
            label1.Size = new Size (348, 20);
            label1.TabIndex = 11;
            label1.Text = "Back";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.Control;
            label2.Dock = DockStyle.Left;
            label2.Font = new Font ("Consolas", 10F);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point (0, 0);
            label2.Name = "label2";
            label2.Size = new Size (110, 20);
            label2.TabIndex = 10;
            label2.Text = "Save";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // palettemaker
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size (464, 581);
            ControlBox = false;
            Controls.Add (panel1);
            Controls.Add (GaugeB);
            Controls.Add (GaugeG);
            Controls.Add (GaugeR);
            Controls.Add (GridPalette);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "palettemaker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Palettes";
            Load += palettemaker_Load;
            ((System.ComponentModel.ISupportInitialize) GridPalette).EndInit ();
            contextMenuStrip1.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) GaugeR).EndInit ();
            ((System.ComponentModel.ISupportInitialize) GaugeG).EndInit ();
            ((System.ComponentModel.ISupportInitialize) GaugeB).EndInit ();
            panel1.ResumeLayout (false);
            ResumeLayout (false);
            PerformLayout ();
            }

        #endregion

        private DataGridView GridPalette;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Red;
        private DataGridViewTextBoxColumn G;
        private DataGridViewTextBoxColumn B;
        private DataGridViewTextBoxColumn Color;
        private TrackBar GaugeR;
        private TrackBar GaugeG;
        private TrackBar GaugeB;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem Menu_NewRandomPalette;
        private ToolStripMenuItem Menu_Open;
        private ToolStripMenuItem Menu_SaveAs;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem Menu_OkUsePalette;
        private Panel panel1;
        private Label label2;
        private Label label1;
        }
    }