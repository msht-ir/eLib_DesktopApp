using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmSelectExam : Form
        {
        public frmSelectExam ()
            {
            InitializeComponent ();
            }
        private void frmSelectExam_Load (object sender, EventArgs e)
            {
            Width = 360;
            Height = 550;
            Testbank.GetCourses (User.Id);
            try
                {
                //reset
                SubProject.Id = 0;
                SubProject.Name = "";
                TreeA.Nodes.Clear ();
                //Level1: [tblCourses] {0ID, 1CourseName, 2CourseUnits, 3user_ID, 4RTL}
                Testbank.GetCourses (User.Id);
                for (int i = 0; i < Db.DS.Tables["tblCourses"].Rows.Count; i++)
                    {
                    TreeNode nd1 = new TreeNode { Text = "", Tag = "" };
                    nd1.Text = Db.DS.Tables["tblCourses"].Rows[i][1].ToString ();
                    nd1.Tag = Db.DS.Tables["tblCourses"].Rows[i][0].ToString ();
                    TreeA.Nodes.Add (nd1);
                    //Level2: [tblExams] {0ID, 1CourseId, 2ExamTitle, 3ExamDateTime, 4ExamDuration, 5ExamNTests, 6ShuffleOptions, 7IsActive}
                    Course.Id = Convert.ToInt32 (Db.DS.Tables["tblCourses"].Rows[i][0]);
                    Testbank.GetExams (Course.Id);
                    if (Db.DS.Tables["tblExams"].Rows.Count > 0)
                        {
                        for (int j = 0; j < Db.DS.Tables["tblExams"].Rows.Count; j++)
                            {
                            TreeNode nd2 = new TreeNode { Text = "", Tag = "" };
                            nd2.Text = Db.DS.Tables["tblExams"].Rows[j][2].ToString ();
                            nd2.Tag = Db.DS.Tables["tblExams"].Rows[j][0].ToString ();
                            TreeA.Nodes[i].Nodes.Add (nd2);
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            TreeA.ExpandAll ();
            }
        private void TreeA_DoubleClick (object sender, EventArgs e)
            {
            lblSelect_Click (null, null);
            }
        private void lblSelect_Click (object sender, EventArgs e)
            {
            if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 1))
                {
                Exam.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                Dispose ();
                }
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Exam.Id = 0;
            Dispose ();
            }
        }
    }
