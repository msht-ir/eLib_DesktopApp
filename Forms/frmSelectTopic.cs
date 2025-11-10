using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmSelectTopic : Form
        {
        public frmSelectTopic ()
            {
            InitializeComponent ();
            }
        private void frmSelectTopic_Load (object sender, EventArgs e)
            {
            Width = 460;
            Height = 460;
            Testbank.GetCourseTopics (Course.Id);
            lstTopics.DataSource = Db.DS.Tables ["tblCourseTopics"];
            lstTopics.DisplayMember = "Topic";
            lstTopics.ValueMember = "ID";
            lstTopics.SelectedIndex = -1;
            if (Testbank.CourseRTL)
                {
                lstTopics.RightToLeft = RightToLeft.Yes;
                }
            else
                {
                lstTopics.RightToLeft = RightToLeft.No;
                }

            }
        private void lstTopics_DoubleClick (object sender, EventArgs e)
            {
            if (lstTopics.SelectedIndex != -1)
                {
                lblSelect_Click (null, null);
                }
            }
        private void lblSelect_Click (object sender, EventArgs e)
            {
            if (lstTopics.SelectedIndex == -1)
                {
                return;
                }
            else
                {
                Topic.Id = Convert.ToInt32 (lstTopics.SelectedValue);
                Testbank.regTestBank = 0b100000; //bit6 on: item selected-ok
                Dispose ();
                }
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Topic.Id = 0;
            Testbank.regTestBank &= 0b011111; //bit6 off (item not selected)
            Dispose ();
            }
        private void frmSelectTopic_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode.ToString () == "F5")
                {
                e.SuppressKeyPress = true;
                lblSelect_Click (null, null);
                }
            else if (e.KeyCode.ToString () == "Escape")
                {
                e.SuppressKeyPress = true;
                lblExit_Click (null, null);
                }
            }
        }
    }
