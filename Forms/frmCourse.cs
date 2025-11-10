using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmCourse : Form
        {
        public frmCourse ()
            {
            InitializeComponent ();
            }
        private void frmCourse_Load (object sender, EventArgs e)
            {
            //edit course
            Width = 560;
            Height = 410;
            txtCourse.Text = Course.Name;
            txtUnits.Text = Course.Units.ToString ();
            RefreshCourseTopics ();
            if (Course.RTL)
                {
                txtCourse.RightToLeft = RightToLeft.Yes;
                lstTopics.RightToLeft = RightToLeft.Yes;
                chkCourseRTL.Checked = true;
                }
            else
                {
                txtCourse.RightToLeft = RightToLeft.No;
                lstTopics.RightToLeft = RightToLeft.No;
                chkCourseRTL.Checked = false;
                }
            txtCourse.Focus ();
            }
        private void frmCourse_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode.ToString () == "F5")
                {
                e.SuppressKeyPress = true;
                lblSave_Click (null, null);
                }
            else if (e.KeyCode.ToString () == "Escape")
                {
                e.SuppressKeyPress = true;
                lblExit_Click (null, null);
                }
            }
        private void txtCourse_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                e.SuppressKeyPress = true;
                txtUnits.Focus ();
                }
            }
        private void chkCourseRTL_CheckedChanged (object sender, EventArgs e)
            {
            if (chkCourseRTL.Checked)
                {
                Course.RTL = true;
                txtCourse.RightToLeft = RightToLeft.Yes;
                lstTopics.RightToLeft = RightToLeft.Yes;
                }
            else
                {
                Course.RTL = false;
                txtCourse.RightToLeft = RightToLeft.No;
                lstTopics.RightToLeft = RightToLeft.No;
                }
            }
        //Menu1
        private void btnAddTopic_Click (object sender, EventArgs e)
            {
            AddTopic ();
            }
        private void btnEditTopic_Click (object sender, EventArgs e)
            {
            EditTopic ();
            }
        private void lblSave_Click (object sender, EventArgs e)
            {
            DoSave ();
            }
        private void Menu1_Save_Click (object sender, EventArgs e)
            {
            DoSave ();
            }
        //Menu2
        private void Menu2_AddTopic_Click (object sender, EventArgs e)
            {
            AddTopic ();
            }
        private void Menu2_EditTopic_Click (object sender, EventArgs e)
            {
            EditTopic ();
            }
        //methods
        private void AddTopic ()
            {
            string strTopic = Interaction.InputBox ("Topic:", "eLib", "new topic");
            if (!String.IsNullOrEmpty (strTopic)) //save it
                {
                Testbank.AddNewCourseTopic (Course.Id, strTopic);
                RefreshCourseTopics ();
                }
            }
        private void EditTopic ()
            {
            if (lstTopics.SelectedIndex == -1)
                {
                return;
                }
            else
                {
                string strTopic = Interaction.InputBox ("Topic:", "eLib", lstTopics.Text);
                if (!String.IsNullOrEmpty (strTopic)) //save it
                    {
                    try
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            Db.strSQL = "UPDATE CourseTopics SET CourseId = @courseid, Topic = @topic WHERE CourseTopicId = " + lstTopics.SelectedValue.ToString ();
                            CnnSS.Open ();
                            var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                            cmd2.CommandType = CommandType.Text;
                            cmd2.Parameters.AddWithValue ("@courseid", Course.Id);
                            cmd2.Parameters.AddWithValue ("@topic", strTopic);
                            int x2 = (int) cmd2.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ()); // Do Nothing!
                        }
                    RefreshCourseTopics ();
                    }
                }
            }
        private void DoSave ()
            {
            try
                {
                Course.Name = txtCourse.Text.Trim ();
                Course.Units = Convert.ToInt32 (txtUnits.Text);
                Course.RTL = chkCourseRTL.Checked;
                if ((Course.Name == "") || (Course.Units == 0))
                    {
                    return;
                    }
                else
                    {
                    bool result = Testbank.SaveCourse ();
                    if (result)
                        {
                        Testbank.regTestBank |= 0b010000; //16:bit5 on: Saved
                        }
                    else
                        {
                        Testbank.regTestBank |= 0b000000; //bit5 off: NotSaved
                        return;
                        }
                    Dispose ();
                    }
                }
            catch (Exception ex)
                {
                txtUnits.Focus ();
                }
            }
        private void RefreshCourseTopics ()
            {
            Testbank.GetCourseTopics (Course.Id);
            lstTopics.DataSource = Db.DS.Tables["tblCourseTopics"];
            lstTopics.DisplayMember = "Topic";
            lstTopics.ValueMember = "ID";
            }
        //Exit
        private void Menu1_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }

        private void lblComposition_Click (object sender, EventArgs e)
            {
            contextMenuStrip2.Show (Control.MousePosition);
            }

        private void label1_Click (object sender, EventArgs e)
            {
            contextMenuStrip1.Show (Control.MousePosition);
            }
        }
    }
