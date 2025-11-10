using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
    {
    partial class Arrows
        {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
            {
            components = new System.ComponentModel.Container ();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (Arrows));
            Grid1 = new DataGridView ();
            contextMenuStrip1 = new ContextMenuStrip (components);
            Menu_ReadExcelData = new ToolStripMenuItem ();
            toolStripMenuItem4 = new ToolStripSeparator ();
            Menu_SelectAll = new ToolStripMenuItem ();
            Menu_InvertSelection = new ToolStripMenuItem ();
            toolStripMenuItem2 = new ToolStripSeparator ();
            Menu_RandomColors = new ToolStripMenuItem ();
            Menu_ColorPalette = new ToolStripMenuItem ();
            Menu_Draw = new ToolStripMenuItem ();
            toolStripMenuItem1 = new ToolStripSeparator ();
            Menu_Exit = new ToolStripMenuItem ();
            panel1 = new Panel ();
            panel3 = new Panel ();
            label9 = new Label ();
            lblGeneMagn = new Label ();
            lblSpacerMagn = new Label ();
            trackBar1 = new TrackBar ();
            label3 = new Label ();
            trackBar2 = new TrackBar ();
            label7 = new Label ();
            panel2 = new Panel ();
            label8 = new Label ();
            label6 = new Label ();
            txtSpacerScalebar = new TextBox ();
            label5 = new Label ();
            txtGeneScalebar = new TextBox ();
            label4 = new Label ();
            txtArrowHeight = new TextBox ();
            label2 = new Label ();
            txtSlideHeight = new TextBox ();
            label1 = new Label ();
            txtSlideWidth = new TextBox ();
            ((System.ComponentModel.ISupportInitialize) Grid1).BeginInit ();
            contextMenuStrip1.SuspendLayout ();
            panel1.SuspendLayout ();
            panel3.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) trackBar1).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) trackBar2).BeginInit ();
            panel2.SuspendLayout ();
            SuspendLayout ();
            // 
            // Grid1
            // 
            Grid1.AllowUserToAddRows = false;
            Grid1.AllowUserToDeleteRows = false;
            Grid1.AllowUserToResizeColumns = false;
            Grid1.AllowUserToResizeRows = false;
            Grid1.BackgroundColor = SystemColors.ButtonHighlight;
            Grid1.BorderStyle = BorderStyle.None;
            Grid1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid1.ContextMenuStrip = contextMenuStrip1;
            Grid1.EditMode = DataGridViewEditMode.EditOnF2;
            Grid1.Location = new Point (186, 4);
            Grid1.Name = "Grid1";
            Grid1.RowHeadersVisible = false;
            Grid1.ScrollBars = ScrollBars.Vertical;
            Grid1.Size = new Size (1034, 398);
            Grid1.TabIndex = 0;
            Grid1.CellDoubleClick += Grid1_CellDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_ReadExcelData, toolStripMenuItem4, Menu_SelectAll, Menu_InvertSelection, toolStripMenuItem2, Menu_RandomColors, Menu_ColorPalette, Menu_Draw, toolStripMenuItem1, Menu_Exit });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size (161, 176);
            // 
            // Menu_ReadExcelData
            // 
            Menu_ReadExcelData.ForeColor = Color.DarkGreen;
            Menu_ReadExcelData.Name = "Menu_ReadExcelData";
            Menu_ReadExcelData.Size = new Size (160, 22);
            Menu_ReadExcelData.Text = "Excel data...";
            Menu_ReadExcelData.Click += Menu_ReadExcelData_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size (157, 6);
            // 
            // Menu_SelectAll
            // 
            Menu_SelectAll.Name = "Menu_SelectAll";
            Menu_SelectAll.Size = new Size (160, 22);
            Menu_SelectAll.Text = "Select All";
            Menu_SelectAll.Click += Menu_SelectAll_Click;
            // 
            // Menu_InvertSelection
            // 
            Menu_InvertSelection.Name = "Menu_InvertSelection";
            Menu_InvertSelection.Size = new Size (160, 22);
            Menu_InvertSelection.Text = "Invert Selection";
            Menu_InvertSelection.Click += Menu_InvertSelection_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size (157, 6);
            // 
            // Menu_RandomColors
            // 
            Menu_RandomColors.Name = "Menu_RandomColors";
            Menu_RandomColors.Size = new Size (160, 22);
            Menu_RandomColors.Text = "Random Colors";
            Menu_RandomColors.Click += Menu_RandomColors_Click;
            // 
            // Menu_ColorPalette
            // 
            Menu_ColorPalette.Font = new Font ("Segoe UI", 9F);
            Menu_ColorPalette.ForeColor = Color.ForestGreen;
            Menu_ColorPalette.Name = "Menu_ColorPalette";
            Menu_ColorPalette.ShortcutKeys =  Keys.Control | Keys.P;
            Menu_ColorPalette.Size = new Size (160, 22);
            Menu_ColorPalette.Text = "Palette...";
            Menu_ColorPalette.Click += Menu_ColorPalette_Click;
            // 
            // Menu_Draw
            // 
            Menu_Draw.Font = new Font ("Segoe UI", 9F);
            Menu_Draw.Name = "Menu_Draw";
            Menu_Draw.ShortcutKeys =  Keys.Control | Keys.D;
            Menu_Draw.Size = new Size (160, 22);
            Menu_Draw.Text = "Draw...";
            Menu_Draw.Click += Menu_Draw_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size (157, 6);
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.ShortcutKeys =  Keys.Control | Keys.Q;
            Menu_Exit.Size = new Size (160, 22);
            Menu_Exit.Text = "Exit";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb (  249,   249,   249);
            panel1.ContextMenuStrip = contextMenuStrip1;
            panel1.Controls.Add (panel3);
            panel1.Controls.Add (lblGeneMagn);
            panel1.Controls.Add (lblSpacerMagn);
            panel1.Controls.Add (trackBar1);
            panel1.Controls.Add (label3);
            panel1.Controls.Add (trackBar2);
            panel1.Controls.Add (label7);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point (0, 408);
            panel1.Name = "panel1";
            panel1.Size = new Size (1229, 127);
            panel1.TabIndex = 2;
            panel1.Click += panel1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add (label9);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point (0, 109);
            panel3.Name = "panel3";
            panel3.Size = new Size (1229, 18);
            panel3.TabIndex = 152;
            // 
            // label9
            // 
            label9.BackColor = Color.LightCoral;
            label9.Dock = DockStyle.Bottom;
            label9.Font = new Font ("Consolas", 10F);
            label9.ForeColor = Color.White;
            label9.Location = new Point (0, 0);
            label9.Name = "label9";
            label9.Size = new Size (1229, 18);
            label9.TabIndex = 10;
            label9.Text = "Back";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            label9.Click += label9_Click;
            // 
            // lblGeneMagn
            // 
            lblGeneMagn.AutoSize = true;
            lblGeneMagn.BackColor = SystemColors.ButtonFace;
            lblGeneMagn.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            lblGeneMagn.ForeColor = Color.SaddleBrown;
            lblGeneMagn.Location = new Point (114, 9);
            lblGeneMagn.Name = "lblGeneMagn";
            lblGeneMagn.Size = new Size (21, 15);
            lblGeneMagn.TabIndex = 20;
            lblGeneMagn.Text = "10";
            lblGeneMagn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSpacerMagn
            // 
            lblSpacerMagn.AutoSize = true;
            lblSpacerMagn.BackColor = SystemColors.ButtonFace;
            lblSpacerMagn.Font = new Font ("Segoe UI", 9F, FontStyle.Bold);
            lblSpacerMagn.ForeColor = Color.SaddleBrown;
            lblSpacerMagn.Location = new Point (782, 9);
            lblSpacerMagn.Name = "lblSpacerMagn";
            lblSpacerMagn.Size = new Size (14, 15);
            lblSpacerMagn.TabIndex = 21;
            lblSpacerMagn.Text = "5";
            lblSpacerMagn.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point (27, 34);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size (509, 45);
            trackBar1.TabIndex = 14;
            trackBar1.TickFrequency = 5;
            trackBar1.Value = 10;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point (27, 9);
            label3.Name = "label3";
            label3.Size = new Size (81, 15);
            label3.TabIndex = 13;
            label3.Text = "Gene magn %";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point (687, 34);
            trackBar2.Maximum = 100;
            trackBar2.Minimum = 1;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size (509, 45);
            trackBar2.TabIndex = 16;
            trackBar2.TickFrequency = 5;
            trackBar2.Value = 5;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point (687, 9);
            label7.Name = "label7";
            label7.Size = new Size (89, 15);
            label7.TabIndex = 15;
            label7.Text = "Spacer magn %";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb (  249,   249,   249);
            panel2.ContextMenuStrip = contextMenuStrip1;
            panel2.Controls.Add (label8);
            panel2.Controls.Add (label6);
            panel2.Controls.Add (txtSpacerScalebar);
            panel2.Controls.Add (label5);
            panel2.Controls.Add (txtGeneScalebar);
            panel2.Controls.Add (label4);
            panel2.Controls.Add (txtArrowHeight);
            panel2.Controls.Add (label2);
            panel2.Controls.Add (txtSlideHeight);
            panel2.Controls.Add (label1);
            panel2.Controls.Add (txtSlideWidth);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point (0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size (179, 408);
            panel2.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point (15, 271);
            label8.Name = "label8";
            label8.Size = new Size (84, 15);
            label8.TabIndex = 12;
            label8.Text = "Scale bars (bp)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point (30, 325);
            label6.Name = "label6";
            label6.Size = new Size (47, 15);
            label6.TabIndex = 11;
            label6.Text = "Spacers";
            // 
            // txtSpacerScalebar
            // 
            txtSpacerScalebar.Location = new Point (101, 322);
            txtSpacerScalebar.Name = "txtSpacerScalebar";
            txtSpacerScalebar.Size = new Size (61, 23);
            txtSpacerScalebar.TabIndex = 10;
            txtSpacerScalebar.Text = "2500";
            txtSpacerScalebar.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point (30, 297);
            label5.Name = "label5";
            label5.Size = new Size (39, 15);
            label5.TabIndex = 9;
            label5.Text = "Genes";
            // 
            // txtGeneScalebar
            // 
            txtGeneScalebar.Location = new Point (101, 294);
            txtGeneScalebar.Name = "txtGeneScalebar";
            txtGeneScalebar.Size = new Size (61, 23);
            txtGeneScalebar.TabIndex = 8;
            txtGeneScalebar.Text = "2500";
            txtGeneScalebar.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point (15, 179);
            label4.Name = "label4";
            label4.Size = new Size (81, 15);
            label4.TabIndex = 7;
            label4.Text = "Arrows height";
            // 
            // txtArrowHeight
            // 
            txtArrowHeight.Location = new Point (101, 176);
            txtArrowHeight.Name = "txtArrowHeight";
            txtArrowHeight.Size = new Size (61, 23);
            txtArrowHeight.TabIndex = 6;
            txtArrowHeight.Text = "70";
            txtArrowHeight.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point (15, 103);
            label2.Name = "label2";
            label2.Size = new Size (72, 15);
            label2.TabIndex = 3;
            label2.Text = "Page Height";
            // 
            // txtSlideHeight
            // 
            txtSlideHeight.Location = new Point (101, 98);
            txtSlideHeight.Name = "txtSlideHeight";
            txtSlideHeight.Size = new Size (61, 23);
            txtSlideHeight.TabIndex = 2;
            txtSlideHeight.Text = "700";
            txtSlideHeight.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point (15, 61);
            label1.Name = "label1";
            label1.Size = new Size (66, 15);
            label1.TabIndex = 1;
            label1.Text = "Page width";
            // 
            // txtSlideWidth
            // 
            txtSlideWidth.Location = new Point (101, 56);
            txtSlideWidth.Name = "txtSlideWidth";
            txtSlideWidth.Size = new Size (61, 23);
            txtSlideWidth.TabIndex = 0;
            txtSlideWidth.Text = "4200";
            txtSlideWidth.TextAlign = HorizontalAlignment.Center;
            // 
            // Arrows
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size (1229, 535);
            ContextMenuStrip = contextMenuStrip1;
            ControlBox = false;
            Controls.Add (panel2);
            Controls.Add (panel1);
            Controls.Add (Grid1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon) resources.GetObject ("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Arrows";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "augustusmate Draw Arrows";
            Load += Arrows_Load;
            ((System.ComponentModel.ISupportInitialize) Grid1).EndInit ();
            contextMenuStrip1.ResumeLayout (false);
            panel1.ResumeLayout (false);
            panel1.PerformLayout ();
            panel3.ResumeLayout (false);
            ((System.ComponentModel.ISupportInitialize) trackBar1).EndInit ();
            ((System.ComponentModel.ISupportInitialize) trackBar2).EndInit ();
            panel2.ResumeLayout (false);
            panel2.PerformLayout ();
            ResumeLayout (false);
            }

        #endregion

        private DataGridView Grid1;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private TextBox txtSlideHeight;
        private Label label1;
        private TextBox txtSlideWidth;
        private Label label4;
        private TextBox txtArrowHeight;
        private Label label3;
        private TrackBar trackBar1;
        private Label lblSpacerMagn;
        private Label lblGeneMagn;
        private TrackBar trackBar2;
        private Label label7;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem Menu_ColorPalette;
        private ToolStripMenuItem Menu_Draw;
        private ToolStripMenuItem Menu_Exit;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem Menu_SelectAll;
        private ToolStripMenuItem Menu_InvertSelection;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem Menu_RandomColors;
        private ToolStripMenuItem Menu_ReadExcelData;
        private ToolStripSeparator toolStripMenuItem4;
        private Label label5;
        private TextBox txtGeneScalebar;
        private Label label8;
        private Label label6;
        private TextBox txtSpacerScalebar;
        private Panel panel3;
        private Label label9;
        }
    }
