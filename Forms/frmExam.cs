using Microsoft.VisualBasic;
using System;

namespace eLib.Forms
    {
    using System.Windows.Forms;
    public partial class frmExam : Form
        {
        public frmExam ()
            {
            InitializeComponent ();
            }
        private void frmExam_Load (object sender, EventArgs e)
            {
            Width = 600;
            Height = 540;
            BringToFront ();
            txtExam.Text = Exam.Title;
            txtNTests.Text = Exam.nTests.ToString ();
            txtDuration.Text = Exam.Duration.ToString ();
            txtDateTime.Text = Exam.DateTime;
            chkShuffle.Checked = Exam.ShuffleOptions;
            RefreshExamComposition (Exam.Id);
            if (Testbank.CourseRTL)
                {
                txtExam.RightToLeft = RightToLeft.Yes;
                gridComposition.RightToLeft = RightToLeft.Yes;

                }
            else
                {
                txtExam.RightToLeft = RightToLeft.No;
                gridComposition.RightToLeft = RightToLeft.No;
                }
            chkActive.Checked = Exam.IsActive;
            chkTraining.Checked = Exam.Training;
            }
        private void frmExam_KeyDown (object sender, KeyEventArgs e)
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
        private void gridComposition_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            EditComposition ();
            }
        private void txtDateTime_Click (object sender, EventArgs e)
            {
            Note.DateTime = txtDateTime.Text; //initialize
            var frmTMDT = new frmTimeAndDate ();
            frmTMDT.ShowDialog ();
            if (Client.DialogRequestParams == 16)
                {
                txtDateTime.Text = Note.DateTime;
                }
            txtExam.Focus ();
            }
        private void label2_DoubleClick (object sender, EventArgs e)
            {
            Menu2_AddComposition_Click (null, null);
            }
        private void btnAddComposition_Click (object sender, EventArgs e)
            {
            AddComposition ();
            }
        private void btnEditComposition_Click (object sender, EventArgs e)
            {
            EditComposition ();
            }
        private void btnRemoveComposition_Click (object sender, EventArgs e)
            {
            RemoveComposition ();
            }
        //Menu1
        private void lblSave_Click (object sender, EventArgs e)
            {
            DoSave ();
            }
        private void Menu1_Save_Click (object sender, EventArgs e)
            {
            DoSave ();
            }
        //Menu2
        private void Menu2_AddComposition_Click (object sender, EventArgs e)
            {
            AddComposition ();
            }
        private void Menu2_EditComposition_Click (object sender, EventArgs e)
            {
            EditComposition ();
            }
        private void Menu2_RemoveComposition_Click (object sender, EventArgs e)
            {
            RemoveComposition ();
            }
        //methods
        private void AddComposition ()
            {
            System.Windows.Forms.Form frm_Topic = new frmSelectTopic ();
            frm_Topic.ShowDialog ();
            if ((Testbank.regTestBank & 0b100000) == 0b100000)
                {
                //bit6:32 (0b100000) is on: item is selected-ok
                string strCompTopicNTests = Interaction.InputBox ("How many tests:", "eLib", "5");
                if (!String.IsNullOrEmpty (strCompTopicNTests)) //save it
                    {
                    Exam.nTests = Convert.ToInt32 (strCompTopicNTests);
                    //Get testsLevel
                    ExamComposition.TestsLevel = 31; //all levels
                    Form frm_TestLevel = new frmTestLevels ();
                    frm_TestLevel.ShowDialog ();
                    if (ExamComposition.TestsLevel > 0)
                        {
                        Testbank.AddExamComposition (Exam.Id, Topic.Id, Exam.nTests, ExamComposition.TestsLevel);
                        RefreshExamComposition (Exam.Id);
                        }
                    }
                }
            }
        private void EditComposition ()
            {
            try
                {
                if (gridComposition.SelectedCells [0].RowIndex >= 0)
                    {
                    //0ID, 1Exam_ID, 2TopicId, 3Topic, 4TopicNTests, 5TestsLevel
                    int r = gridComposition.SelectedCells [0].RowIndex;
                    int compid = Convert.ToInt32 (gridComposition.Rows [r].Cells [0].Value);
                    int topicNtests = Convert.ToInt32 (gridComposition.Rows [r].Cells [4].Value);
                    Test.Level = Convert.ToInt32 (gridComposition.Rows [r].Cells [5].Value);
                    Topic.Id = Convert.ToInt32 (gridComposition.Rows [r].Cells [2].Value);
                    switch (gridComposition.SelectedCells [0].ColumnIndex)
                        {
                        case 3:
                                {
                                //topic
                                System.Windows.Forms.Form frm_Topic = new frmSelectTopic ();
                                frm_Topic.ShowDialog ();
                                if ((Testbank.regTestBank & 0b100000) == 0b100000)
                                    {
                                    Testbank.UpdateExamComposition (compid, Topic.Id, topicNtests, Test.Level);
                                    RefreshExamComposition (Exam.Id);
                                    }
                                break;
                                }
                        case 4:
                                {
                                //nTest
                                string tmpCompTopicNTests = Interaction.InputBox ("How many tests:", "eLib", topicNtests.ToString ());
                                if (!String.IsNullOrEmpty (tmpCompTopicNTests)) //save it
                                    {
                                    topicNtests = Convert.ToInt32 (tmpCompTopicNTests);
                                    Testbank.UpdateExamComposition (compid, Topic.Id, topicNtests, Test.Level);
                                    RefreshExamComposition (Exam.Id);
                                    }
                                break;
                                }
                        case 5:
                                {
                                //testsLevel
                                Form frm_TestLevel = new frmTestLevels ();
                                frm_TestLevel.ShowDialog ();
                                if (Test.Level > 0)
                                    {
                                    Testbank.UpdateExamComposition (compid, Topic.Id, topicNtests, Test.Level);
                                    RefreshExamComposition (Exam.Id);
                                    }
                                break;
                                }
                        }
                    }
                }
            catch
                {
                //do nothing!
                }
            }
        private void RemoveComposition ()
            {
            try
                {
                if (gridComposition.SelectedCells [0].RowIndex >= 0)
                    {
                    //0ID, 1Exam_ID, 2TopicId, 3Topic, 4TopicNTests, 5TestsLevel
                    int r = gridComposition.SelectedCells [0].RowIndex;
                    ExamComposition.Id = Convert.ToInt32 (gridComposition.Rows [r].Cells [0].Value);
                    DialogResult myansw = MessageBox.Show ("Delete Exam-Composition?\n\nClick ( NO ) to EDIT", "eLib.Exams", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    switch (myansw)
                        {
                        case DialogResult.Yes:
                                {
                                //Delete ExamComposition
                                Testbank.DeleteExamComposition (ExamComposition.Id);
                                RefreshExamComposition (Exam.Id);
                                break;
                                }
                        case DialogResult.No:
                                {
                                //Edit ExamComposition
                                EditComposition ();
                                break;
                                }
                        case DialogResult.Cancel:
                                {
                                //do nothing
                                break;
                                }
                        }
                    }
                RefreshExamComposition (Exam.Id);
                }
            catch
                {
                //do nothing!
                }
            }
        private bool checkComposition (int examId)
            {
            if (gridComposition.Rows.Count == 0)
                {
                return false;
                }
            else
                {
                int tmpNTests_grd = 0;
                int tmpNTests_txt = Convert.ToInt32 (txtNTests.Text);
                for (int i = 0; i < gridComposition.Rows.Count; i++)
                    {
                    tmpNTests_grd += Convert.ToInt32 (gridComposition.Rows [i].Cells [4].Value);
                    }
                if (tmpNTests_grd == tmpNTests_txt)
                    {
                    return true;
                    }
                else
                    {
                    return false;
                    }
                }
            }
        private void DoSave ()
            {
            Exam.Title = txtExam.Text;
            Exam.DateTime = txtDateTime.Text;
            try
                {
                Exam.nTests = Convert.ToInt32 (txtNTests.Text);
                }
            catch
                {
                txtNTests.Focus ();
                return;
                }
            try
                {
                Exam.Duration = Convert.ToInt32 (txtDuration.Text);
                }
            catch
                {
                txtDuration.Focus ();
                return;
                }
            if ((Convert.ToSingle (Exam.Duration) > (Exam.nTests * 1.5)) || (Convert.ToSingle (Exam.Duration) < (Exam.nTests * 0.8)))
                {
                DialogResult myansw = MessageBox.Show ("Confirm:\n\n" + Exam.Duration.ToString () + " min  for:  " + Exam.nTests.ToString () + "  Tests.\n\nContinue Saving?", "eLib.Exams", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw != DialogResult.Yes)
                    {
                    txtDuration.Focus ();
                    txtDuration.Text = Exam.Duration.ToString () + " -> " + Convert.ToInt32 (Exam.nTests * 1.1 + Exam.nTests / 10 + 1).ToString ();
                    txtDuration.SelectionStart = 0;
                    txtDuration.SelectionLength = Exam.Duration.ToString ().Length + 4;
                    return;
                    }
                }
            Exam.ShuffleOptions = chkShuffle.Checked;
            Exam.IsActive = chkActive.Checked;
            Exam.Training = chkTraining.Checked;
            //check composition
            if (!checkComposition (Exam.Id))
                {
                DialogResult myansw2 = MessageBox.Show ("Composition inconsistent with number of tests! \n\nSave anyway?", "eLib", MessageBoxButtons.YesNo);
                if (myansw2 == DialogResult.No)
                    {
                    return;
                    }
                }
            bool result = Testbank.UpdateExam (Exam.Id);
            if (result)
                {
                Testbank.regTestBank |= 0b10000;
                Dispose ();
                }
            else
                {
                MessageBox.Show ("Error Saving Exam-Composition");
                }
            }
        private void RefreshExamComposition (int examid)
            {
            Testbank.GetExamComposition (examid);
            gridComposition.DataSource = Db.DS.Tables ["tblExamComposition"];
            for (int i = 0, loopTo = gridComposition.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                gridComposition.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //[ExamComposition]: ID, Exam_ID, TopicId, Topic, TopicNTests, TestsLevel
            gridComposition.Columns [0].Visible = false;   //ID
            gridComposition.Columns [1].Visible = false;   //Exam_ID
            gridComposition.Columns [2].Visible = false;   //TopicId
            //gridComposition.Columns [5].Visible = false;   //TestsLevel
            gridComposition.Columns [3].Width = 360;       //Topic
            gridComposition.Columns [4].Width = 70;        //TopicNTests
            gridComposition.Columns [5].Width = 50;        //TestsLevel
            int tmpNTests_grd = 0;
            int tmpNTests_txt = Convert.ToInt32 (txtNTests.Text);
            for (int i = 0; i < gridComposition.Rows.Count; i++)
                {
                tmpNTests_grd += Convert.ToInt32 (gridComposition.Rows [i].Cells [4].Value);
                }
            txtNTests.Text = tmpNTests_grd.ToString ();
            try
                {
                Exam.nTests = Convert.ToInt32 (txtNTests.Text);
                }
            catch
                {
                txtNTests.Focus ();
                return;
                }
            try
                {
                Exam.Duration = Convert.ToInt32 (txtDuration.Text);
                }
            catch
                {
                txtDuration.Focus ();
                return;
                }

            txtDuration.Text = Convert.ToInt32 (Exam.nTests * 1.1 + Exam.nTests / 10 + 1).ToString ();
            }
        //Exit
        private void lblExit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu1_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }

        private void label2_Click (object sender, EventArgs e)
            {
            contextMenuStrip2.Show (Control.MousePosition);
            }
        }
    }
