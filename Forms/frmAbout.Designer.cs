using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace eLib
    {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated ()]
    public partial class frmAbout : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (frmAbout));
            Label2 = new Label ();
            Timer1 = new Timer (components);
            lblBackEnd = new Label ();
            Label1 = new Label ();
            linkLabel1 = new LinkLabel ();
            SuspendLayout ();
            // 
            // Label2
            // 
            Label2.BackColor = Color.FromArgb (  234,   234,   234);
            Label2.Dock = DockStyle.Top;
            Label2.Font = new Font ("Courier New", 39.75F, FontStyle.Regular, GraphicsUnit.Point,  0);
            Label2.ForeColor = Color.Gray;
            Label2.Location = new Point (0, 0);
            Label2.Name = "Label2";
            Label2.RightToLeft = RightToLeft.No;
            Label2.Size = new Size (772, 131);
            Label2.TabIndex = 1;
            Label2.Text = "eLib";
            Label2.TextAlign = ContentAlignment.MiddleCenter;
            Label2.Click += Label2_Click;
            // 
            // Timer1
            // 
            Timer1.Enabled = true;
            Timer1.Interval = 10000;
            Timer1.Tick += Timer1_Tick;
            // 
            // lblBackEnd
            // 
            lblBackEnd.Font = new Font ("Consolas", 9.75F);
            lblBackEnd.ForeColor = SystemColors.ControlDarkDark;
            lblBackEnd.Location = new Point (12, 139);
            lblBackEnd.Name = "lblBackEnd";
            lblBackEnd.RightToLeft = RightToLeft.No;
            lblBackEnd.Size = new Size (638, 27);
            lblBackEnd.TabIndex = 5;
            lblBackEnd.Text = "BackEnd:";
            lblBackEnd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            Label1.Font = new Font ("Consolas", 9.75F);
            Label1.ForeColor = SystemColors.ControlDarkDark;
            Label1.Location = new Point (48, 184);
            Label1.Name = "Label1";
            Label1.RightToLeft = RightToLeft.No;
            Label1.Size = new Size (583, 158);
            Label1.TabIndex = 6;
            Label1.Text = resources.GetString ("Label1.Text");
            Label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.FromArgb (  234,   234,   234);
            linkLabel1.Location = new Point (329, 104);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size (109, 15);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "http://www.msht.ir";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb (  246,   246,   246);
            ClientSize = new Size (772, 360);
            ControlBox = false;
            Controls.Add (linkLabel1);
            Controls.Add (Label1);
            Controls.Add (Label2);
            Controls.Add (lblBackEnd);
            ForeColor = Color.Navy;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "elib";
            Load += frmAbout_Load;
            Click += frmAbout_Click;
            ResumeLayout (false);
            PerformLayout ();
            }

        internal Timer Timer1;
        private Label Label2;
        internal Label lblBackEnd;
        internal Label Label1;
        private LinkLabel linkLabel1;
        }
    }