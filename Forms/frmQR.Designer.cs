using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmQR : Form
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
            PictureBox1 = new PictureBox ();
            ContextMenuStrip1 = new ContextMenuStrip (components);
            Menu_Exit = new ToolStripMenuItem ();
            label2 = new Label ();
            lblExit = new Label ();
            ((System.ComponentModel.ISupportInitialize) PictureBox1).BeginInit ();
            ContextMenuStrip1.SuspendLayout ();
            SuspendLayout ();
            // 
            // PictureBox1
            // 
            PictureBox1.Location = new Point (12, 12);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size (200, 200);
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            PictureBox1.DoubleClick += PictureBox1_DoubleClick;
            // 
            // ContextMenuStrip1
            // 
            ContextMenuStrip1.Items.AddRange (new ToolStripItem [] { Menu_Exit });
            ContextMenuStrip1.Name = "ContextMenuStrip1";
            ContextMenuStrip1.Size = new Size (94, 26);
            // 
            // Menu_Exit
            // 
            Menu_Exit.ForeColor = Color.IndianRed;
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new Size (93, 22);
            Menu_Exit.Text = "Exit";
            Menu_Exit.Click += Menu_Exit_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.CornflowerBlue;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font ("Consolas", 10F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point (0, 0);
            label2.Name = "label2";
            label2.Size = new Size (219, 3);
            label2.TabIndex = 48;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblExit
            // 
            lblExit.BackColor = Color.LightCoral;
            lblExit.Dock = DockStyle.Bottom;
            lblExit.Font = new Font ("Consolas", 10F);
            lblExit.ForeColor = Color.White;
            lblExit.ImeMode = ImeMode.NoControl;
            lblExit.Location = new Point (0, 243);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size (219, 15);
            lblExit.TabIndex = 49;
            lblExit.Text = "Back";
            lblExit.TextAlign = ContentAlignment.MiddleCenter;
            lblExit.Click += lblExit_Click;
            // 
            // frmQR
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size (219, 258);
            ContextMenuStrip = ContextMenuStrip1;
            ControlBox = false;
            Controls.Add (lblExit);
            Controls.Add (label2);
            Controls.Add (PictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmQR";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QRCode";
            Load += frmQR_Load;
            KeyDown += frmQR_KeyDown;
            ((System.ComponentModel.ISupportInitialize) PictureBox1).EndInit ();
            ContextMenuStrip1.ResumeLayout (false);
            ResumeLayout (false);
            }

        internal PictureBox PictureBox1;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolStripMenuItem Menu_Exit;
        private Label label2;
        private Label lblExit;
        }
}