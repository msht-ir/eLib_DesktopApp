using System;
using System.Drawing;

namespace eLib
    {
    public partial class frmQR
        {
        public frmQR ()
            {
            InitializeComponent ();
            }
        private void frmQR_Load (object sender, EventArgs e)
            {
            try
                {
                PictureBox1.Image = Image.FromFile (eLibFile.Filename);
                }
            catch (Exception ex)
                {
                }
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            PictureBox1.Image = null;
            Dispose ();
            }
        private void frmQR_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e)
            {
            if (((int) e.KeyCode == 27) | ((int) e.KeyCode == 13))
                {
                Menu_Exit_Click (null, null);
                }
            }
        private void PictureBox1_DoubleClick (object sender, EventArgs e)
            {
            Menu_Exit_Click (sender, e);
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Menu_Exit_Click (sender, e);
            }
        }
    }