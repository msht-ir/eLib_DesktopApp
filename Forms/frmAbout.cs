using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmAbout
        {
        public frmAbout ()
            {
            InitializeComponent ();
            }
        private void frmAbout_Load (object sender, EventArgs e)
            {
            lblBackEnd.Text = "FrontEnd: " + Client.BuildInfo + "  |  BackEnd: " + Db.CurrentDbVersion;
            }
        private void Timer1_Tick (object sender, EventArgs e)
            {
            this.Dispose ();
            }
        private void Label2_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void frmAbout_Click (object sender, EventArgs e)
            {
            this.Dispose ();
            }
        private void linkLabel1_LinkClicked (object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
            {
            try
                {
                var pWeb = new Process ();
                pWeb.StartInfo.UseShellExecute = true;
                pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir";
                pWeb.Start ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Notice: Help opens with Edge browser", "EDGE not found!", MessageBoxButtons.OK); // MsgBox(ex.ToString)
                }
            }

        }
    }