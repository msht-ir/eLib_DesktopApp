using System;
using System.Data;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace eLib.Forms
    {
    public partial class frmSelectTest : Form
        {
        public frmSelectTest ()
            {
            InitializeComponent ();
            }
        private void frmSelectTest_Load (object sender, EventArgs e)
            {
            Width = 1235;
            Height = 650;
            Text = "Exam : " + Exam.Title;
            int initialId = Test.Id;
            Testbank.regTestBank &= 0b011111; //bit6 off (item not selected) --default
            //Load tests of a course and highlight those already selected for an exam
            Testbank.GetTests (Course.Id, "course", 0);
            lstTests.DataSource = Db.DS.Tables["tblTests"];
            lstTests.DisplayMember = "TestTitle";
            lstTests.ValueMember = "ID";
            lstTests.SelectedIndex = -1;
            if (Testbank.CourseRTL)
                {
                chkTestsRTL.Checked = true;
                lstTests.RightToLeft = RightToLeft.Yes;
                lstExamTests.RightToLeft = RightToLeft.Yes;
                }
            else
                {
                chkTestsRTL.Checked = false;
                lstTests.RightToLeft = RightToLeft.No;
                lstExamTests.RightToLeft = RightToLeft.No;
                }
            RefreshlstExamTests ();
            try
                {
                lstExamTests.SelectedValue = initialId;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void frmSelectTest_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode.ToString ())
                {
                case "F5":
                        {
                        e.SuppressKeyPress = true;
                        lblSelect_Click (null, null);
                        break;
                        }
                case "Escape":
                        {
                        e.SuppressKeyPress = true;
                        lblExit_Click (null, null);
                        break;
                        }
                case "F2":
                        {
                        btnAddToExam_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case "F4":
                        {
                        e.SuppressKeyPress = true;
                        if (chkShowOptions.Checked)
                            {
                            chkShowOptions.Checked = false;
                            }
                        else
                            {
                            chkShowOptions.Checked = true;
                            }
                        break;
                        }
                }
            }
        private void chkTestsRTL_CheckedChanged (object sender, EventArgs e)
            {
            if (chkTestsRTL.Checked)
                {
                lstTests.RightToLeft = RightToLeft.Yes;
                }
            else
                {
                lstTests.RightToLeft = RightToLeft.No;
                }
            }
        private void chkShowOptions_CheckedChanged (object sender, EventArgs e)
            {
            if ((chkShowOptions.Checked) && (lstTests.SelectedIndex >= 0))
                {
                int intTestId = (int) lstTests.SelectedValue;
                ShowOptions (intTestId, "course");
                }
            }
        //lists
        private void lstTests_Click (object sender, EventArgs e)
            {
            lstOptions.DataSource = null;
            if (chkShowOptions.Checked)
                {
                int intTestId = (int) lstTests.SelectedValue;
                ShowOptions (intTestId, "course");
                }
            }
        private void lstTests_DoubleClick (object sender, EventArgs e)
            {
            if (lstTests.SelectedIndex != -1)
                {
                btnAddToExam_Click (null, null);
                }
            }
        private void lstExamTests_Click (object sender, EventArgs e)
            {
            lstOptions.DataSource = null;
            if (chkShowOptions.Checked)
                {
                int intTestId = (int) lstExamTests.SelectedValue;
                ShowOptions (intTestId, "exam");
                }
            }
        private void lstExamTests_DoubleClick (object sender, EventArgs e)
            {
            if (lstExamTests.SelectedIndex != -1)
                {
                DialogResult myansw1 = MessageBox.Show ("Remove Test from Exam?", "eLib", MessageBoxButtons.YesNo);
                if (myansw1 == DialogResult.No)
                    {
                    return;
                    }
                Test.Id = Convert.ToInt32 (lstExamTests.SelectedValue);
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        //ExamTest: {0Tests.ID, 1ExamTests.ID, 2TestTitle, 3TestType, 4Course_ID, 5TopicId, 6TestRTL, 7OptionsRTL}
                        int examTestId = Convert.ToInt32 (Db.DS.Tables["tblExamTests"].Rows[Convert.ToInt32 (lstExamTests.SelectedIndex)][1]);
                        Db.strSQL = "DELETE FROM ExamTests WHERE ExamTestId =" + examTestId.ToString ();
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@testid", Test.Id.ToString ());
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    RefreshlstExamTests ();
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            }
        //lbls and btns
        private void btnAddToExam_Click (object sender, EventArgs e)
            {
            if (lstTests.SelectedIndex == -1)
                {
                return;
                }
            else
                {
                Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
                Testbank.AddNewExamTest (Exam.Id, Test.Id);
                Testbank.regTestBank = 0b100000; //bit6 on: item selected-ok
                lblStatus.Text = lstTests.Text + " -- added";
                RefreshlstExamTests ();
                }
            }
        private void ShowOptions (int intTestId, string mode)
            {
            Testbank.GetTestOptions (intTestId);
            //ID, Test_ID, OptionText, IsAnswer, ForceLast
            lstOptions.DataSource = Db.DS.Tables["tblTestOptions"];
            lstOptions.DisplayMember = "OptionText";
            lstOptions.ValueMember = "ID";
            lstOptions.SelectedIndex = -1;
            bool boolRTL = false;
            switch (mode)
                {
                case "course":
                        {
                        //tblTests: 0ID, 1TestTitle, 2TestType, 3Course_ID, 4TopicId, 5TestRTL, 6OptionsRTL, 7ForceLast, 8TestLevel
                        boolRTL = Convert.ToBoolean (Db.DS.Tables["tblTests"].Rows[(int) lstTests.SelectedIndex][6]);
                        break;
                        }
                case "exam":
                        {
                        //tblExamTests: 0Tests.ID, 1ExamTests.ID, 2TestTitle, 3TestType, 4Course_ID, 5TopicId, 6TestRTL, 7OptionsRTL
                        boolRTL = Convert.ToBoolean (Db.DS.Tables["tblExamTests"].Rows[(int) lstExamTests.SelectedIndex][7]);
                        break;
                        }
                }
            lstOptions.RightToLeft = (boolRTL) ? RightToLeft.Yes : RightToLeft.No;
            //select answer
            int cnt = 0;
            foreach (DataRow r in Db.DS.Tables["tblTestOptions"].Rows)
                {
                cnt++;
                if (Convert.ToBoolean (r[3].ToString ()))
                    {
                    //MessageBox.Show ("Answer: " + cnt.ToString ());
                    lstOptions.SelectedIndex = cnt - 1;
                    return;
                    }
                }
            }
        private void RefreshlstExamTests ()
            {
            //get tests
            Testbank.GetTests (Exam.Id, "Exam", 0);
            lstExamTests.DataSource = Db.DS.Tables["tblExamTests"];
            lstExamTests.DisplayMember = "TestTitle";
            lstExamTests.ValueMember = "Tests.ID";
            lstExamTests.SelectedIndex = -1;
            }
        //exit
        private void lblSelect_Click (object sender, EventArgs e)
            {
            if (lstTests.SelectedIndex == -1)
                {
                return;
                }
            else
                {
                Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
                Testbank.regTestBank = 0b100000; //bit6 on: item selected-ok
                Dispose ();
                }
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        }
    }
