using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmTestLevels : Form
        {
        public frmTestLevels ()
            {
            InitializeComponent ();
            }
        private void frmTestLevels_Load (object sender, EventArgs e)
            {
            Width = 435;
            Height = 385;
            lvl1.Value = 1;
            lvl2.Value = 5;
            for (int i = 4; i >= 0; i--)
                {
                if (((long) Test.Level & (long) Math.Pow (2, i)) != 0)
                    {
                    lvl1.Value = i + 1;
                    }
                }
            for (int i = 0; i < 5; i++)
                {
                if (((long) Test.Level & (long) Math.Pow (2, i)) != 0)
                    {
                    lvl2.Value = i + 1;
                    }
                }
            }
        //lbls
        private void lbl1_Click (object sender, EventArgs e)
            {
            SetLevelsTo (1);
            }
        private void lbl2_Click (object sender, EventArgs e)
            {
            SetLevelsTo (2);
            }
        private void lbl3_Click (object sender, EventArgs e)
            {
            SetLevelsTo (3);
            }
        private void lbl4_Click (object sender, EventArgs e)
            {
            SetLevelsTo (4);
            }
        private void lbl5_Click (object sender, EventArgs e)
            {
            SetLevelsTo (5);
            }
        //Levels
        private void lvl1_Scroll (object sender, EventArgs e)
            {
            if (lvl1.Value > lvl2.Value)
                {
                lvl2.Value = lvl1.Value;
                }
            }
        private void lvl2_Scroll (object sender, EventArgs e)
            {
            if (lvl2.Value < lvl1.Value)
                {
                lvl1.Value = lvl2.Value;
                }
            }
        //methods
        private void SetLevelsTo (int lvl)
            {
            lvl1.Value = lvl;
            lvl2.Value = lvl;
            }
        //Exit
        private void lblOK_Click (object sender, EventArgs e)
            {
            //check consistecy
            if (lvl1.Value > lvl2.Value)
                {
                lvl2.Value = lvl1.Value;
                }
            //calc
            Test.Level = 0;
            for (int i = lvl1.Value - 1; i < lvl2.Value; i++)
                {
                Test.Level += Convert.ToInt32 ((long) Math.Pow (2, i));
                }
            Dispose ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Test.Level = 0;
            Dispose ();
            }

        }
    }
