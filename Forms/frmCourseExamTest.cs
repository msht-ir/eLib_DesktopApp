using ClosedXML.Excel;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmCourseExamTest : Form
        {
        public frmCourseExamTest ()
            {
            InitializeComponent ();
            }
        private void frmCourseExamTest_Load (object sender, EventArgs e)
            {
            Width = 1235;
            Height = 650;
            BringToFront ();
            TopLevel = true;
            Activate (); //ok, this was the solution to bring the form on top and activated!
            Testbank.GetCourses (User.Id);
            if (Db.DS.Tables["tblCourses"].Rows.Count == 0)
                {
                //add first course and exam
                Testbank.regTestBank = 0b10; //2:addNewCourse
                Course.Name = "_new COURSE";
                Course.Units = 2;
                if (Testbank.SaveCourse ()) //also returns: Course.Id
                    {
                    //MessageBox.Show ("create first exam...");
                    Testbank.regTestBank = 0b100; //2:addNewExam
                    Exam.Title = "_new EXAM";
                    bool result = Testbank.AddExam (Course.Id);
                    }
                }
            //Looad lstCourse
            RefreshTreeA ();
            }
        private void frmCourseExamTest_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode.ToString () == "F2")
                {
                e.SuppressKeyPress = true;
                if (txtCmd.Focused)
                    {
                    TreeA.Focus ();
                    }
                else
                    {
                    txtCmd.Focus ();
                    }
                }
            }
        private void txtCmd_TextChanged (object sender, EventArgs e)
            {
            switch (txtCmd.Text.Trim ().ToLower ())
                {
                case "-?":
                case "-help":
                case "-cmd":
                        {
                        txtCmd.Text = "-New, -Edit, -Delete, -Go, -Add, -exit";
                        txtCmd.SelectionStart = 0;
                        txtCmd.SelectionLength = txtCmd.TextLength;
                        break;
                        }
                case "-new":
                        {
                        string strcmd1 = "New ";
                        string strcmd2 = "Course | Exam";
                        txtCmd.Text = strcmd1 + strcmd2;
                        txtCmd.SelectionStart = strcmd1.Length;
                        txtCmd.SelectionLength = strcmd2.Length;
                        break;
                        }
                case "new c":
                        {
                        Menu1_NewCourse_Click (null, null);
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "new e":
                        {
                        Menu1_NewExam_Click (null, null);
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-import":
                        {
                        if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 0))
                            {
                            Menu2_ImportTests_Click (null, null);
                            txtCmd.Focus ();
                            txtCmd.Text = "";
                            }
                        else
                            {
                            txtCmd.Text = "Select a course!";
                            txtCmd.SelectionStart = 0;
                            txtCmd.SelectionLength = txtCmd.TextLength;
                            return;
                            }
                        break;
                        }
                case "-export":
                        {
                        if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 0) && (lstTests.Items.Count > 0))
                            {
                            //export courseTests
                            string strflnm = System.Windows.Forms.Application.StartupPath + @"\Course_Tests.xml";
                            Db.DS.Tables["tblTests"].WriteXml (strflnm);
                            txtCmd.Text = "Course:    " + lblTree.Text + "       / Tests exported to:     " + strflnm;
                            txtCmd.SelectionStart = 0;
                            txtCmd.SelectionLength = txtCmd.TextLength;
                            }
                        else if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 1) && (lstTests.Items.Count > 0))
                            {
                            //export examTests
                            string strflnm = System.Windows.Forms.Application.StartupPath + @"\Exam_Tests.xml";
                            Db.DS.Tables["tblExamTests"].WriteXml (strflnm);
                            txtCmd.Text = "Exam:    " + lblTree.Text + "       / Tests exported to:     " + strflnm;
                            txtCmd.SelectionStart = 0;
                            txtCmd.SelectionLength = txtCmd.TextLength;
                            }
                        else
                            {
                            //nothing to export
                            txtCmd.Text = "List is Empty! Nothing to Export!";
                            txtCmd.SelectionStart = 0;
                            txtCmd.SelectionLength = txtCmd.TextLength;
                            }
                        break;
                        }
                case "-edit":
                        {
                        if ((TreeA.SelectedNode != null) && (Convert.ToInt32 (lstTests.SelectedIndex) >= 0))
                            {
                            //select edit waht?
                            string strcmd1 = "EDIT Selected ";
                            string strcmd2 = "Course | Exam | Test";
                            txtCmd.Text = strcmd1 + strcmd2;
                            txtCmd.SelectionStart = strcmd1.Length;
                            txtCmd.SelectionLength = strcmd2.Length;
                            }
                        else if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 0))
                            {
                            //confirm edit course
                            //string strcmd1 = "EDIT Course ? ";
                            //string strcmd2 = "Yes | No";
                            //txtCmd.Text = strcmd1 + strcmd2;
                            //txtCmd.SelectionStart = strcmd1.Length;
                            //txtCmd.SelectionLength = strcmd2.Length;
                            Menu1_Edit_Click (null, null);
                            txtCmd.Focus ();
                            txtCmd.Text = "";
                            }
                        else if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 1))
                            {
                            //confirm edit exam
                            //string strcmd1 = "EDIT Exam ? ";
                            //string strcmd2 = "Yes | No";
                            //txtCmd.Text = strcmd1 + strcmd2;
                            //txtCmd.SelectionStart = strcmd1.Length;
                            //txtCmd.SelectionLength = strcmd2.Length;
                            Menu1_Edit_Click (null, null);
                            txtCmd.Focus ();
                            txtCmd.Text = "";
                            }
                        else
                            {
                            txtCmd.Text = "Select a Course, Exam or Test (to edit)!";
                            txtCmd.SelectionStart = 0;
                            txtCmd.SelectionLength = txtCmd.TextLength;
                            }
                        break;
                        }
                case "edit selected t":
                        {
                        Menu2_EditTest_Click (null, null);
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "edit selected c":
                case "edit selected e":
                case "edit course ? y":
                case "edit exam ? y":
                        {
                        Menu1_Edit_Click (null, null);
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "edit course ? n":
                case "edit exam ? n":
                        {
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-delete":
                        {
                        if ((TreeA.SelectedNode != null) && (Convert.ToInt32 (lstTests.SelectedIndex) >= 0))
                            {
                            //select edit waht?
                            string strcmd1 = "DELETE Selected ";
                            string strcmd2 = "Course | Exam | Test";
                            txtCmd.Text = strcmd1 + strcmd2;
                            txtCmd.SelectionStart = strcmd1.Length;
                            txtCmd.SelectionLength = strcmd2.Length;
                            }
                        else if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 0))
                            {
                            //confirm edit course
                            string strcmd1 = "DELETE Course ? ";
                            string strcmd2 = "Yes | No";
                            txtCmd.Text = strcmd1 + strcmd2;
                            txtCmd.SelectionStart = strcmd1.Length;
                            txtCmd.SelectionLength = strcmd2.Length;
                            }
                        else if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 1))
                            {
                            //confirm edit exam
                            string strcmd1 = "DELETE Exam ? ";
                            string strcmd2 = "Yes | No";
                            txtCmd.Text = strcmd1 + strcmd2;
                            txtCmd.SelectionStart = strcmd1.Length;
                            txtCmd.SelectionLength = strcmd2.Length;
                            }
                        else
                            {
                            txtCmd.Text = "Select a Course, Exam or Test (to delete)!";
                            txtCmd.SelectionStart = 0;
                            txtCmd.SelectionLength = txtCmd.TextLength;
                            }
                        break;
                        }
                case "delete selected t":
                        {
                        Menu2_DeleteTest_Click (null, null);
                        break;
                        }
                case "delete selected c":
                case "delete selected e":
                case "delete course ? y":
                case "delete exam ? y":
                        {
                        Menu1_Delete_Click (null, null);
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "delete course ? n":
                case "delete exam ? n":
                        {
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-add":
                        {
                        if (TreeA.SelectedNode == null)
                            {
                            txtCmd.Text = "Select a course / exam!";
                            txtCmd.SelectionStart = 0;
                            txtCmd.SelectionLength = txtCmd.TextLength;
                            return;
                            }
                        else
                            {
                            switch (TreeA.SelectedNode.Level)
                                {
                                case 0:
                                        {
                                        //create new test
                                        string strcmd1 = "New Test for the Course-Testbank ? ";
                                        string strcmd2 = "Yes | No";
                                        txtCmd.Text = strcmd1 + strcmd2;
                                        txtCmd.SelectionStart = strcmd1.Length;
                                        txtCmd.SelectionLength = strcmd2.Length;
                                        break;
                                        }
                                case 1:
                                        {
                                        //add test to exam
                                        string strcmd1 = "Add Tests to the Exam ? ";
                                        string strcmd2 = "Yes | No";
                                        txtCmd.Text = strcmd1 + strcmd2;
                                        txtCmd.SelectionStart = strcmd1.Length;
                                        txtCmd.SelectionLength = strcmd2.Length;
                                        break;
                                        }
                                }
                            }
                        break;
                        }
                case "new test for the course-testbank ? y":
                case "add tests to the exam ? y":
                        {
                        Menu2_NewTest_Click (null, null);
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "new test for the course-testbank ? n":
                case "add tests to the exam ? n":
                        {
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-find":
                        {
                        string strcmd1 = "Find: ";
                        string strcmd2 = "<search string>";
                        txtCmd.Text = strcmd1 + strcmd2;
                        txtCmd.SelectionStart = strcmd1.Length;
                        txtCmd.SelectionLength = strcmd2.Length;
                        break;
                        }
                case "-go":
                        {
                        string strcmd1 = "Goto   ";
                        string strcmd2 = "Exam-Sheets   |   Student-Exams";
                        txtCmd.Text = strcmd1 + strcmd2;
                        txtCmd.SelectionStart = strcmd1.Length;
                        txtCmd.SelectionLength = strcmd2.Length;
                        break;
                        }
                case "goto   e":
                        {
                        Menu1_MakeExamSheet_Click (null, null);
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "goto   p":
                        {
                        Menu1_Students_Click (null, null);
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-exit":
                case "-back":
                case "-logout":
                case "-log out":
                        {
                        Menu1_Exit_Click (null, null);
                        break;
                        }
                case "-quit":
                case "exit elib? y":
                        {
                        Db.CnnSS.Close ();
                        Db.CnnSS.Dispose ();
                        Db.CnnSS = null;
                        Application.Exit ();
                        Environment.Exit (0);
                        break;
                        }
                case "exit elib? n":
                        {
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                }
            }
        private void txtCmd_KeyDown (object sender, KeyEventArgs e)
            {
            if ((TreeA.SelectedNode != null) && (e.KeyCode == Keys.Enter) && (txtCmd.Text.ToLower ().StartsWith ("find: ")) && (txtCmd.TextLength > 8))
                {
                e.SuppressKeyPress = true;
                DoSearch (Strings.Mid (txtCmd.Text, 7).ToLower ());
                txtCmd.SelectionStart = 0;
                txtCmd.SelectionLength = txtCmd.TextLength;
                }
            }
        private void TreeA_AfterSelect (object sender, TreeViewEventArgs e)
            {
            lblTree.Text = TreeA.SelectedNode.Text;
            switch (TreeA.SelectedNode.Level)
                {
                case 0:
                        {
                        lstTests.AllowDrop = true;
                        GridTopics.DataSource = null;
                        lstTests.DataSource = null;
                        GridOptions.DataSource = null;
                        Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                        if (chkShowTests.Checked)
                            {
                            ShowCourseTests (Course.Id);
                            }
                        FormatControlsRTL ();
                        //menu
                        Menu1_NewExam.Visible = true;
                        Menu1_MakeExamSheet.Visible = false;
                        lblExamSheets.Visible = false;
                        break;
                        }
                case 1:
                        {
                        FormatControlsRTL ();
                        lstTests.AllowDrop = false;
                        Exam.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                        RefreshTestsList (Exam.Id, "exam", 0);
                        RefreshExamCompositionList (Exam.Id);
                        GridOptions.DataSource = null;
                        lblTopics.Text = "Exam Composition";
                        lblTests.Text = "Exam tests";
                        //menu
                        Menu1_NewExam.Visible = false;
                        Menu1_MakeExamSheet.Visible = true;
                        lblExamSheets.Visible = true;
                        break;
                        }
                }
            }
        private void TreeA_DoubleClick (object sender, EventArgs e)
            {
            if (TreeA.SelectedNode != null)
                {
                Menu1_Edit_Click (null, null);
                }
            }
        private void lblTests_Click (object sender, EventArgs e)
            {
            if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 0))
                {
                lstTests.AllowDrop = true;
                Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                ShowCourseTests (Course.Id);
                FormatControlsRTL ();
                Menu1_NewExam.Visible = true;
                lblExamSheets.Visible = false;
                }
            else
                {
                MessageBox.Show ("Select a Course", "eLib.Exams");
                }
            }
        private void chkShowTests_CheckedChanged (object sender, EventArgs e)
            {
            if (chkShowTests.Checked)
                {
                lblTests_Click (null, null);
                }
            }
        private void lblTopics_Click (object sender, EventArgs e)
            {
            switch ((int) TreeA.SelectedNode.Level)
                {
                case 0:
                        {
                        RefreshTestsList (Convert.ToInt32 (Course.Id), "course", 0);
                        break;
                        }
                case 1:
                        {
                        RefreshTestsList (Convert.ToInt32 (Exam.Id), "Exam", 0);
                        break;
                        }
                }
            }
        private void lstTests_DragEnter (object sender, DragEventArgs e)
            {
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void lstTests_DragDrop (object sender, DragEventArgs e)
            {
            if (TreeA.SelectedNode.Level == 0)
                {
                string[] strFiles = (string[]) e.Data.GetData (DataFormats.FileDrop, false);
                eLib.eLibFile.strFilex = strFiles[0];
                FileInfo MyFile = new FileInfo (strFiles[0]);
                if (MyFile.Extension.ToLower () != ".xlsx")
                    {
                    return;
                    }
                else
                    {
                    lblTests.Text = "Import from:  " + MyFile.FullName + "  ...  Please wait!";
                    DialogResult myansw = MessageBox.Show ("Import Tests from Excel?", "elib", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (myansw == DialogResult.Yes)
                        {
                        ImportExcel (MyFile.FullName);
                        }
                    }
                lblTests.Text = "Test bank";
                }
            }
        private void lstTests_SelectedIndexChanged (object sender, EventArgs e)
            {
            try
                {
                GridOptions.DataSource = null;
                if ((lstTests.Items.Count > 0) && (lstTests.SelectedIndex != -1) && (chkShowOptions.Checked))
                    {
                    Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
                    RefreshTestOptionsGrid (Test.Id);
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        private void lstTests_DoubleClick (object sender, EventArgs e)
            {
            try
                {
                if ((lstTests.Items.Count > 0) && (lstTests.SelectedIndex != -1))
                    {
                    Menu2_EditTest_Click (null, null);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void chkTestsRTL_CheckedChanged (object sender, EventArgs e)
            {
            if (chkTestsRTL.Checked)
                {
                Testbank.CourseRTL = true;
                lstTests.RightToLeft = RightToLeft.Yes;
                }
            else
                {
                Testbank.CourseRTL = false;
                lstTests.RightToLeft = RightToLeft.No;
                }
            }
        private void GridOptions_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if (GridOptions.SelectedCells[0].RowIndex >= 0)
                {
                lstTests_DoubleClick (null, null);
                }
            }
        private void GridTopics_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            //filter: show only test of this topic
            int r = GridTopics.SelectedCells[0].RowIndex;
            switch ((int) TreeA.SelectedNode.Level)
                {
                case 0:
                        {
                        int intTopicId = Convert.ToInt32 (GridTopics.Rows[r].Cells[0].Value); //col0=topicID
                        RefreshTestsList (Convert.ToInt32 (Course.Id), "course", intTopicId);
                        break;
                        }
                case 1:
                        {
                        int intTopicId = Convert.ToInt32 (GridTopics.Rows[r].Cells[2].Value); //col2=topicID
                        RefreshTestsList (Convert.ToInt32 (Exam.Id), "Exam", intTopicId);
                        break;
                        }
                }
            }
        private void btnShowOptions_Click (object sender, EventArgs e)
            {
            Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
            RefreshTestOptionsGrid (Test.Id);
            }
        private void chkShowOptions_CheckedChanged (object sender, EventArgs e)
            {
            if ((chkShowOptions.Checked) && (lstTests.SelectedIndex >= 0))
                {
                try
                    {
                    Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
                    RefreshTestOptionsGrid (Test.Id);
                    }
                catch (Exception ex)
                    {
                    //MessageBox.Show (ex.ToString ());
                    }
                }
            }
        //Menu1 (tree)
        private void Menu1_NewCourse_Click (object sender, EventArgs e)
            {
            //new course
            Testbank.regTestBank = 0b10; //2:addNewCourse
            Course.Name = "_new course";
            Course.Units = 2;
            bool result = Testbank.SaveCourse ();
            //similar to: Menu1_Edit
            Testbank.regTestBank = 0b11; //3:editCourse
            System.Windows.Forms.Form frm_Course = new frmCourse ();
            frm_Course.ShowDialog ();
            RefreshTreeA ();
            if ((Testbank.regTestBank & 0b010000) == 0b010000)
                {
                //bit5:16 (0b010000)
                TreeA.ExpandAll ();
                }
            }
        private void Menu1_NewExam_Click (object sender, EventArgs e)
            {
            //new exam
            try
                {
                if ((TreeA.Nodes.Count > 0) && (TreeA.SelectedNode.Level == 0))
                    {
                    Testbank.regTestBank = 0b100; //4:addNewExam
                    Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                    Exam.Title = "EXAM_" + (TreeA.SelectedNode.Nodes.Count + 1).ToString () + "_for_" + TreeA.SelectedNode.Text;
                    bool result = Testbank.AddExam (Course.Id);
                    //get info about newly added exam
                    Testbank.GetExamById (Exam.Id);
                    Exam.Title = Db.DS.Tables["tblExams"].Rows[0][2].ToString ();
                    Exam.DateTime = Db.DS.Tables["tblExams"].Rows[0][3].ToString ();
                    Exam.Duration = Convert.ToInt32 (Db.DS.Tables["tblExams"].Rows[0][4].ToString ());
                    Exam.nTests = Convert.ToInt32 (Db.DS.Tables["tblExams"].Rows[0][5].ToString ());
                    Exam.ShuffleOptions = Convert.ToBoolean (Db.DS.Tables["tblExams"].Rows[0][6].ToString ());
                    Exam.IsActive = Convert.ToBoolean (Db.DS.Tables["tblExams"].Rows[0][7].ToString ());
                    Exam.Training = Convert.ToBoolean (Db.DS.Tables["tblExams"].Rows[0][8].ToString ());
                    Testbank.regTestBank = 0b101; //5:editExam
                    System.Windows.Forms.Form frm_Exam = new frmExam ();
                    frm_Exam.ShowDialog ();
                    if ((Testbank.regTestBank & 0b010000) == 0b010000)
                        {
                        //bit5:16 (0b010000)
                        RefreshTreeA ();
                        TreeA.ExpandAll ();
                        DialogResult myansw = MessageBox.Show ("Populate the new Exam with random tests (according Exam Composition)?\n\n<NO> : Select Tests Manually.", "eLib.Exams: Please comfirm", MessageBoxButtons.YesNo);
                        if (myansw == DialogResult.Yes)
                            {
                            //populate!
                            AuoSelectTests (Exam.Id);
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        private void Menu1_Edit_Click (object sender, EventArgs e)
            {
            if (TreeA.SelectedNode == null)
                {
                return;
                }
            else
                {
                lblTrainingExam.Visible = false;
                switch (TreeA.SelectedNode.Level)
                    {
                    case 0:
                            {
                            //level0:course
                            Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Course.Name = (string) TreeA.SelectedNode.Text;
                            Course.Units = Convert.ToInt32 (Db.DS.Tables["tblCourses"].Rows[TreeA.SelectedNode.Index][2].ToString ());
                            Course.RTL = Convert.ToBoolean (Db.DS.Tables["tblCourses"].Rows[TreeA.SelectedNode.Index][4].ToString ());
                            Testbank.regTestBank = 0b11; //3:editCourse
                            System.Windows.Forms.Form frm_Course = new frmCourse ();
                            frm_Course.ShowDialog ();
                            if ((Testbank.regTestBank & 0b010000) == 0b010000)
                                {
                                //bit5:16 (0b010000)
                                RefreshTreeA ();
                                TreeA.ExpandAll ();
                                }
                            break;
                            }
                    case 1:
                            {
                            //level1:exam {0ID, 1CourseId, 2ExamTitle, 3ExamDateTime, 4ExamDuration, 5ExamNTests, 6ExamShuffleOptions, 7IsActive}
                            Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Parent.Tag);
                            Exam.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Testbank.GetExamById (Exam.Id);
                            Exam.Title = Db.DS.Tables["tblExams"].Rows[0][2].ToString ();
                            Exam.DateTime = Db.DS.Tables["tblExams"].Rows[0][3].ToString ();
                            Exam.Duration = Convert.ToInt32 (Db.DS.Tables["tblExams"].Rows[0][4].ToString ());
                            Exam.nTests = Convert.ToInt32 (Db.DS.Tables["tblExams"].Rows[0][5].ToString ());
                            Exam.ShuffleOptions = Convert.ToBoolean (Db.DS.Tables["tblExams"].Rows[0][6].ToString ());
                            Exam.IsActive = Convert.ToBoolean (Db.DS.Tables["tblExams"].Rows[0][7].ToString ());
                            Exam.Training = Convert.ToBoolean (Db.DS.Tables["tblExams"].Rows[0][8].ToString ());
                            Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
                            Testbank.regTestBank = 0b101; //5:editExam
                            System.Windows.Forms.Form frm_Exam = new frmExam ();
                            frm_Exam.ShowDialog ();
                            if ((Testbank.regTestBank & 0b010000) == 0b010000)
                                {
                                //bit5:16 (0b010000)
                                RefreshTreeA ();
                                TreeA.ExpandAll ();
                                }
                            break;
                            }
                    }
                }
            }
        private void Menu1_Delete_Click (object sender, EventArgs e)
            {
            if (TreeA.SelectedNode != null)
                {
                switch (TreeA.SelectedNode.Level)
                    {
                    case 0:
                            {
                            Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Testbank.DeleteCourseById (Course.Id);
                            break;
                            }
                    case 1:
                            {
                            Exam.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Testbank.DeleteExamById (Exam.Id);
                            break;
                            }
                    }
                RefreshTreeA ();
                }
            }
        private void Menu1_MakeExamSheet_Click (object sender, EventArgs e)
            {
            if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 1))
                {
                Exam.Title = TreeA.SelectedNode.Text;
                System.Windows.Forms.Form frm_Partics = new frmSelectStudents ();
                frm_Partics.ShowDialog ();
                }
            else
                {
                txtCmd.Text = "Select an Exam!";
                txtCmd.SelectionStart = 0;
                txtCmd.SelectionLength = txtCmd.TextLength;
                }
            }
        private void Menu1_Students_Click (object sender, EventArgs e)
            {
            if (TreeA.Nodes.Count > 0)
                {
                Student.Id = 0;
                var frmParticExams = new frmStudentExams ();
                frmParticExams.ShowDialog ();
                }
            }
        private void lblExamSheets_Click (object sender, EventArgs e)
            {
            Menu1_MakeExamSheet_Click (null, null);
            }
        //Menu2 (tests)
        private void Menu2_NewTest_Click (object sender, EventArgs e)
            {
            if (TreeA.SelectedNode == null)
                {
                return;
                }
            else
                {
                switch (TreeA.SelectedNode.Level)
                    {
                    case 0:
                            {
                            //create new test
                            Testbank.regTestBank = 0b1000; //8:newTest
                            Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Test.Text = "new test [edit]";
                            Test.TestTags = chkTestsRTL.Checked;
                            Testbank.AddNewCourseTest (Course.Id, 2);
                            RefreshTestsList (Course.Id, "course", 0);
                            lstTests.SelectedValue = Test.Id;
                            Menu2_EditTest_Click (null, null);
                            lstTests.Focus ();
                            break;
                            }
                    case 1:
                            {
                            //add test to exam
                            Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Parent.Tag);
                            Exam.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            System.Windows.Forms.Form frm_SelectTest = new frmSelectTest ();
                            frm_SelectTest.ShowDialog ();
                            if ((Testbank.regTestBank & 0b100000) == 0b100000)
                                {
                                //bit5:32 (0b100000)
                                RefreshTestsList (Exam.Id, "exam", 0);
                                lstTests.Focus ();
                                }
                            break;
                            }
                    }
                }
            }
        private void Menu2_EditTest_Click (object sender, EventArgs e)
            {
            if ((TreeA.SelectedNode == null) || !(Convert.ToInt32 (lstTests.SelectedIndex) >= 0))
                {
                return;
                }
            else
                {
                switch (TreeA.SelectedNode.Level)
                    {
                    case 0:
                            {
                            //edit a test
                            Testbank.regTestBank = 0b1001; //9:edit Test
                            Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
                            //open form
                            System.Windows.Forms.Form frm_EditTest = new frmTest ();
                            frm_EditTest.ShowDialog ();
                            RefreshTestsList (Course.Id, "course", 0);
                            lstTests.SelectedValue = Test.Id;
                            GridOptions.DataSource = null; // if ((Testbank.regTestBank & 0b010000) == 0b010000) //bit5:16 (0b010000)
                            break;
                            }
                    case 1:
                            {
                            //edit an exam-test
                            Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Parent.Tag);
                            Exam.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
                            int examTestId = Test.Id;
                            System.Windows.Forms.Form frm_SelectTest = new frmSelectTest ();
                            frm_SelectTest.ShowDialog ();
                            if ((Testbank.regTestBank & 0b100000) == 0b100000)
                                {
                                //Do Update
                                try
                                    {
                                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                        {
                                        //ExamTest: {0Tests.ID, 1ExamTests.ID, 2TestTitle, 3TestType, 4Course_ID, 5TopicId, 6TestRTL, 7OptionsRTL}
                                        Db.strSQL = "UPDATE ExamTests SET TestId = @testid WHERE ExamTestId =" + examTestId.ToString ();
                                        CnnSS.Open ();
                                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Parameters.AddWithValue ("@testid", Test.Id.ToString ());
                                        int i = cmd.ExecuteNonQuery ();
                                        CnnSS.Close ();
                                        }
                                    RefreshTestsList (Exam.Id, "exam", 0);
                                    }
                                catch (Exception ex)
                                    {
                                    MessageBox.Show (ex.ToString ());
                                    }
                                //Testbank.UpdateExamTestId(ExamTest.Id)
                                RefreshTestsList (Exam.Id, "exam", 0);
                                lstTests.SelectedValue = Test.Id;
                                GridOptions.DataSource = null;
                                }
                            break;
                            }
                    }
                }
            }
        private void Menu2_DeleteTest_Click (object sender, EventArgs e)
            {
            if (TreeA.SelectedNode != null && lstTests.SelectedIndex >= 0)
                {
                switch (TreeA.SelectedNode.Level)
                    {
                    case 0:
                            {
                            DialogResult myansw0 = MessageBox.Show ("Delete Test from TestBank?", "eLib", MessageBoxButtons.YesNo);
                            if (myansw0 == DialogResult.No)
                                {
                                return;
                                }
                            Course.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
                            try
                                {
                                int cnt = 0;
                                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                    {
                                    Db.strSQL = "SELECT COUNT (ID) FROM ExamTests WHERE Test_ID =" + Test.Id.ToString ();
                                    CnnSS.Open ();
                                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                    cmd.CommandType = CommandType.Text;
                                    cnt = (int) cmd.ExecuteScalar ();
                                    CnnSS.Close ();
                                    }
                                if (cnt > 0)
                                    {
                                    if (cnt == 1)
                                        {
                                        DialogResult myansw = MessageBox.Show ("This Test is used in an Exam\n\n It will be removed from the exam too.", "eLib", MessageBoxButtons.OKCancel);
                                        if (myansw != DialogResult.OK)
                                            {
                                            return;
                                            }
                                        }
                                    else if (cnt > 1)
                                        {
                                        DialogResult myansw = MessageBox.Show ("This Test is used in " + cnt.ToString () + " Exams\n\n It will be removed from those exams too.", "eLib", MessageBoxButtons.OKCancel);
                                        if (myansw != DialogResult.OK)
                                            {
                                            return;
                                            }
                                        }
                                    }
                                //delete all
                                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                    {
                                    CnnSS.Open ();
                                    //Delete linked ExamTests
                                    Db.strSQL = "DELETE FROM ExamTests WHERE Test_ID =" + Test.Id.ToString ();
                                    var cmd1 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                    cmd1.CommandType = CommandType.Text;
                                    int i1 = cmd1.ExecuteNonQuery ();
                                    //Delete TestOptions
                                    Db.strSQL = "DELETE FROM TestOptions WHERE TestId =" + Test.Id.ToString ();
                                    var cmd3 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                    cmd3.CommandType = CommandType.Text;
                                    int i3 = cmd3.ExecuteNonQuery ();
                                    //Dekele the Test itself
                                    Db.strSQL = "DELETE FROM Tests WHERE TestId =" + Test.Id.ToString ();
                                    var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                    cmd2.CommandType = CommandType.Text;
                                    int i2 = cmd2.ExecuteNonQuery ();
                                    CnnSS.Close ();
                                    }
                                RefreshTestsList (Course.Id, "course", 0);
                                }
                            catch (Exception ex)
                                {
                                MessageBox.Show (ex.ToString ());
                                }
                            break;
                            }
                    case 1:
                            {
                            DialogResult myansw1 = MessageBox.Show ("Remove Test from Exam?", "eLib", MessageBoxButtons.YesNo);
                            if (myansw1 == DialogResult.No)
                                {
                                return;
                                }
                            Exam.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Test.Id = Convert.ToInt32 (lstTests.SelectedValue);
                            try
                                {
                                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                    {
                                    //ExamTest: {0Tests.ID, 1ExamTests.ID, 2TestTitle, 3TestType, 4Course_ID, 5TopicId, 6TestRTL, 7OptionsRTL}
                                    int examTestId = Convert.ToInt32 (Db.DS.Tables["tblExamTests"].Rows[Convert.ToInt32 (lstTests.SelectedIndex)][1]);
                                    Db.strSQL = "DELETE FROM ExamTests WHERE ExamTestId =" + examTestId.ToString ();
                                    CnnSS.Open ();
                                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Parameters.AddWithValue ("@testid", Test.Id.ToString ());
                                    int i = cmd.ExecuteNonQuery ();
                                    CnnSS.Close ();
                                    }
                                RefreshTestsList (Exam.Id, "exam", 0);
                                }
                            catch (Exception ex)
                                {
                                MessageBox.Show (ex.ToString ());
                                }
                            break;
                            }
                    }
                GridOptions.DataSource = null;
                }
            }
        private void Menu2_DeleteAllTests_Click (object sender, EventArgs e)
            {
            if (TreeA.SelectedNode != null && lstTests.Items.Count > 0)
                {
                switch (TreeA.SelectedNode.Level)
                    {
                    case 0:
                            {
                            MessageBox.Show ("Try deleting the Course!", "eLib", MessageBoxButtons.OK);
                            break;
                            }
                    case 1:
                            {
                            DialogResult myansw1 = MessageBox.Show ("Remove All Tests from this Exam?", "eLib", MessageBoxButtons.YesNo);
                            if (myansw1 == DialogResult.No)
                                {
                                return;
                                }
                            try
                                {
                                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                    {
                                    Exam.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                                    Db.strSQL = "DELETE FROM ExamTests WHERE Exam_ID =" + Exam.Id.ToString ();
                                    CnnSS.Open ();
                                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                    cmd.CommandType = CommandType.Text;
                                    int i = cmd.ExecuteNonQuery ();
                                    CnnSS.Close ();
                                    }
                                RefreshTestsList (Exam.Id, "exam", 0);
                                GridOptions.DataSource = null;
                                }
                            catch (Exception ex)
                                {
                                MessageBox.Show (ex.ToString ());
                                }
                            break;
                            }
                    }
                }
            }
        private void Menu2_ImportTests_Click (object sender, EventArgs e)
            {
            if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 0))
                {
                string flnm = "";
                using (var dialog = new OpenFileDialog () { InitialDirectory = System.Windows.Forms.Application.StartupPath, Filter = "Course Exam Tests|*.xlsx" })
                    {
                    if (dialog.ShowDialog () == DialogResult.OK)
                        {
                        flnm = dialog.FileName;
                        ImportExcel (flnm);
                        }
                    else
                        {
                        return;
                        }
                    }
                }
            else
                {
                MessageBox.Show ("Select a Course!", "eLib.Exams");
                }
            }
        private void Menu2_AuoSelectTests_Click (object sender, EventArgs e)
            {
            if ((TreeA.SelectedNode == null) || (TreeA.SelectedNode.Level != 1) || (lstTests.Items.Count > 0))
                {
                MessageBox.Show ("To use this command: \n\n1. Select a Course.\n2. Add a New Exam.\n3. Define Composition based on topics\n4. Make sure Course tests be already related to the topics.\n5. Then, use this command.", "eLib");
                return;
                }
            else
                {
                AuoSelectTests (Exam.Id);
                }
            }
        private void Menu2_txtSearch_KeyDown (object sender, KeyEventArgs e)
            {
            if ((TreeA.SelectedNode != null) && (e.KeyCode == Keys.Enter) && (Menu2_txtSearch.TextLength > 2))
                {
                e.SuppressKeyPress = true;
                DoSearch (Menu2_txtSearch.Text.Trim ().ToLower ());
                Menu2_txtSearch.SelectionStart = 0;
                Menu2_txtSearch.SelectionLength = Menu2_txtSearch.TextLength;

                }
            }
        //methods
        private void ShowCourseTests (int courseid)
            {
            lblTests.Text = "wait ...";
            Application.DoEvents (); //(this is to refresh label.text) and see also BackgroundWorker()
            RefreshCourseTopicsList (Course.Id);
            RefreshTestsList (Convert.ToInt32 (Course.Id), "course", 0);
            GridOptions.DataSource = null;
            lblTopics.Text = "Course topics";
            lblTests.Text = "Test bank";
            }
        private void FormatControlsRTL ()
            {
            switch (TreeA.SelectedNode.Level)
                {
                case 0:
                        {
                        Course.RTL = Convert.ToBoolean (Db.DS.Tables["tblCourses"].Rows[Convert.ToInt32 (TreeA.SelectedNode.Index.ToString ())][4]);
                        break;
                        }
                case 1:
                        {
                        Course.RTL = Convert.ToBoolean (Db.DS.Tables["tblCourses"].Rows[Convert.ToInt32 (TreeA.SelectedNode.Parent.Index.ToString ())][4]);
                        break;
                        }
                }
            Testbank.CourseRTL = Course.RTL;
            if (Course.RTL)
                {
                GridTopics.RightToLeft = RightToLeft.Yes;
                }
            else
                {
                GridTopics.RightToLeft = RightToLeft.No;
                }
            chkTestsRTL.Checked = Course.RTL;
            }
        public void ImportExcel (string Filename)
            {
            try
                {
                using (IXLWorkbook WB = new XLWorkbook (Filename))
                    {
                    var WS0 = WB.Worksheets.ElementAtOrDefault (0);
                    int iRow = 0;
                    string Option1Text = "";
                    string Option2Text = "";
                    string Option3Text = "";
                    string Option4Text = "";
                    string Option5Text = "";
                    string Answer = "";
                    bool AnsOpt1 = false;
                    bool AnsOpt2 = false;
                    bool AnsOpt3 = false;
                    bool AnsOpt4 = false;
                    bool AnsOpt5 = false;
                    string TopicText = "";
                    //Excel columns: {1:Question, 2:qstRTL, 3:optRTL, 4:nOpt, 5-9:opt1-5Texts, 10:Ans, 11:forceLast 12:Level 13:Topic} 
                    foreach (IXLRow Rowx in WS0.Rows ())
                        {
                        iRow = iRow + 1;
                        if (iRow > 1)
                            {
                            //1:Question
                            Test.Text = WS0.Cell (iRow, 1).Value.ToString ();
                            //2:rtl
                            if (WS0.Cell (iRow, 2).Value.ToString ().ToLower () == "y")
                                {
                                Test.TestTags = true;
                                }
                            else
                                {
                                Test.TestTags = false;
                                }
                            //3:rtl
                            if (WS0.Cell (iRow, 3).Value.ToString ().ToLower () == "y")
                                {
                                Test.TestTags = true;
                                }
                            else
                                {
                                Test.TestTags = false;
                                }
                            //4:nOpts
                            Test.Type = Convert.ToInt32 (WS0.Cell (iRow, 4).Value.ToString ());
                            //12:TestLevel
                            Test.Level = Convert.ToInt32 (WS0.Cell (iRow, 12).Value.ToString ());
                            //13:Topic
                            TopicText = Strings.Left (WS0.Cell (iRow, 13).Value.ToString (), 30).Trim ();
                            Test.TopicId = Testbank.GetIdOfThisTopic (Course.Id, TopicText);
                            //do Import
                            //Testbank.ImportTest (Course.Id, Test.Text, Test.Type, Test.TopicId, Test.TestTags, Test.Level);
                            //--- OPTIONS---
                            Option1Text = WS0.Cell (iRow, 5).Value.ToString ();
                            Option2Text = WS0.Cell (iRow, 6).Value.ToString ();
                            Option3Text = WS0.Cell (iRow, 7).Value.ToString ();
                            Option4Text = WS0.Cell (iRow, 8).Value.ToString ();
                            Option5Text = WS0.Cell (iRow, 9).Value.ToString ();
                            //Ans
                            Answer = WS0.Cell (iRow, 10).Value.ToString ().Trim ().ToLower ();
                            //11:ForceLast
                            if (WS0.Cell (iRow, 11).Value.ToString ().ToLower () == "y")
                                {
                                Test.TestTags = true;
                                }
                            else
                                {
                                Test.TestTags = false;
                                }
                            //initialize opts to false
                            AnsOpt1 = false;
                            AnsOpt2 = false;
                            AnsOpt3 = false;
                            AnsOpt4 = false;
                            AnsOpt5 = false;
                            //set correct answer
                            switch (Answer)
                                {
                                case "1":
                                case "a":
                                        {
                                        AnsOpt1 = true;
                                        break;
                                        }
                                case "2":
                                case "b":
                                        {
                                        AnsOpt2 = true;
                                        break;
                                        }
                                case "3":
                                case "c":
                                        {
                                        AnsOpt3 = true;
                                        break;
                                        }
                                case "4":
                                case "d":
                                        {
                                        AnsOpt4 = true;
                                        break;
                                        }
                                case "5":
                                case "e":
                                        {
                                        AnsOpt5 = true;
                                        break;
                                        }
                                default:
                                        {
                                        break;
                                        }
                                }
                            //save opts to db (needs: testid, optionText, IsAns, forceLast)
                            switch (Test.Type)
                                {
                                case 1:
                                        {
                                        Testbank.AddTestOption (Test.Id, Option1Text, AnsOpt1, Test.TestTags);
                                        break;
                                        }
                                case 2:
                                        {
                                        Testbank.AddTestOption (Test.Id, Option1Text, AnsOpt1, false);
                                        Testbank.AddTestOption (Test.Id, Option2Text, AnsOpt2, Test.TestTags);//if col11=y : Force=TRUE
                                        break;
                                        }
                                case 3:
                                        {
                                        Testbank.AddTestOption (Test.Id, Option1Text, AnsOpt1, false);
                                        Testbank.AddTestOption (Test.Id, Option2Text, AnsOpt2, false);
                                        Testbank.AddTestOption (Test.Id, Option3Text, AnsOpt3, Test.TestTags);//if col11=y : Force=TRUE
                                        break;
                                        }
                                case 4:
                                        {
                                        Testbank.AddTestOption (Test.Id, Option1Text, AnsOpt1, false);
                                        Testbank.AddTestOption (Test.Id, Option2Text, AnsOpt2, false);
                                        Testbank.AddTestOption (Test.Id, Option3Text, AnsOpt3, false);
                                        Testbank.AddTestOption (Test.Id, Option4Text, AnsOpt4, Test.TestTags);//if col11=y : Force=TRUE
                                        break;
                                        }
                                case 5:
                                        {
                                        Testbank.AddTestOption (Test.Id, Option1Text, AnsOpt1, false);
                                        Testbank.AddTestOption (Test.Id, Option2Text, AnsOpt2, false);
                                        Testbank.AddTestOption (Test.Id, Option3Text, AnsOpt3, false);
                                        Testbank.AddTestOption (Test.Id, Option4Text, AnsOpt4, false);
                                        Testbank.AddTestOption (Test.Id, Option5Text, AnsOpt5, Test.TestTags); //if col11=y : Force=TRUE
                                        break;
                                        }
                                }
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Tests and Options \r\n" + ex.ToString ());
                }
            //refresh
            RefreshTestsList (Course.Id, "course", 0);
            RefreshCourseTopicsList (Course.Id);
            }
        private void RefreshTreeA ()
            {
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
            GridTopics.DataSource = null;
            lstTests.DataSource = null;
            GridOptions.DataSource = null;
            }
        private void RefreshCourseTopicsList (int courseid)
            {
            Testbank.GetCourseTopics (courseid);
            GridTopics.DataSource = Db.DS.Tables["tblCourseTopics"];
            for (int i = 0, loopTo = GridTopics.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                GridTopics.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //ID, CourseId, Topic
            GridTopics.Columns[0].Visible = false;   //ID
            GridTopics.Columns[1].Visible = false;   //ExamId
            GridTopics.Columns[2].Width = 800;       //Topic
            }
        private void RefreshExamCompositionList (int examid)
            {
            Testbank.GetExamComposition (examid);
            GridTopics.DataSource = Db.DS.Tables["tblExamComposition"];
            for (int i = 0, loopTo = GridTopics.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                GridTopics.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //[ExamComposition]: ExamComposition.ID, Exam_ID, TopicId, Topic, TopicNTests, TestsLevel
            GridTopics.Columns[0].Visible = false;   //ID
            GridTopics.Columns[1].Visible = false;   //Exam_ID
            GridTopics.Columns[2].Visible = false;   //TopicId
            GridTopics.Columns[3].Width = 750;       //Topic
            GridTopics.Columns[4].Width = 80;        //TopicNTests
            GridTopics.Columns[5].Width = 80;        //TestsLevel
            }
        private void RefreshTestsList (int parentid, string mode, int topicId)
            {
            GridOptions.DataSource = null;
            switch (mode.ToLower ())
                {
                case "course":
                        {
                        Testbank.GetTests (parentid, mode, topicId);
                        lstTests.DataSource = Db.DS.Tables["tblTests"];
                        lstTests.DisplayMember = "TestTitle";
                        lstTests.ValueMember = "ID";
                        lstTests.SelectedIndex = -1;
                        lblTrainingExam.Visible = false;
                        break;
                        }
                case "exam":
                        {
                        Testbank.GetExamById (Exam.Id);
                        Exam.Title = Db.DS.Tables["tblExams"].Rows[0][2].ToString ();
                        Exam.DateTime = Db.DS.Tables["tblExams"].Rows[0][3].ToString ();
                        Exam.Duration = Convert.ToInt32 (Db.DS.Tables["tblExams"].Rows[0][4].ToString ());
                        Exam.nTests = Convert.ToInt32 (Db.DS.Tables["tblExams"].Rows[0][5].ToString ());
                        Exam.IsActive = Convert.ToBoolean (Db.DS.Tables["tblExams"].Rows[0][8].ToString ());
                        Exam.Training = Convert.ToBoolean (Db.DS.Tables["tblExams"].Rows[0][8].ToString ());
                        lblTrainingExam.Visible = (Exam.Training) ? true : false;
                        //get tests
                        Testbank.GetTests (parentid, mode, topicId);
                        lstTests.DataSource = Db.DS.Tables["tblExamTests"];
                        lstTests.DisplayMember = "TestTitle";
                        lstTests.ValueMember = "Tests.ID";
                        lstTests.SelectedIndex = -1;
                        break;
                        }
                }
            }
        private void RefreshTestOptionsGrid (int testid)
            {
            Testbank.GetTestOptions (testid);
            GridOptions.DataSource = Db.DS.Tables["tblTestOptions"];
            for (int i = 0, loopTo = GridOptions.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                GridOptions.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //ID, Test_ID, OptionText, IsAnswer, ForceLast
            GridOptions.Columns[0].Visible = false;   //ID
            GridOptions.Columns[1].Visible = false;   //Test_ID
            GridOptions.Columns[2].Width = 830;       //OptionText
            GridOptions.Columns[3].Width = 70;        //IsAnswer
            GridOptions.Columns[4].Visible = false;   //ForceLast
            try
                {
                //RTL/LTR: ["tblTests"]: {0ID, 1TestTitle, 2TestType, 3CourseId, 4TopicId, 5TestRtl, 6OptionsRtl, 7ForceLast, 8TestLevel}            
                Test.TestTags = Convert.ToBoolean (Db.DS.Tables["tblTests"].Rows[lstTests.SelectedIndex][6]);
                if (Test.TestTags)
                    {
                    GridOptions.RightToLeft = RightToLeft.Yes;
                    }
                else
                    {
                    GridOptions.RightToLeft = RightToLeft.No;
                    }
                }
            catch { }
            }
        private void AuoSelectTests (int examid)
            {
            //ExamComposition: 0ID, 1Exam_ID, 2TopicId, 3Topic, 4TopicNTests, 5TestsLevel
            Testbank.GetExamComposition (Exam.Id);
            int cnt = 0;
            //count composition
            for (int i = 0; i < Db.DS.Tables["tblExamComposition"].Rows.Count; i++)
                {
                cnt += Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[i][4]);
                }
            //check composition
            if (cnt < Exam.nTests)
                {
                DialogResult myansw = MessageBox.Show ("Edit/revise Exam Composition", "eLib", MessageBoxButtons.OKCancel);
                if (myansw == DialogResult.OK)
                    {
                    Menu1_Edit_Click (null, null); //Edit Exam
                    }
                else
                    {
                    return;
                    }
                }
            else if (cnt > Exam.nTests)
                {
                DialogResult myansw = MessageBox.Show ("Number of Tetsts should be: " + Exam.nTests.ToString () + "\nComposition will add: " + cnt.ToString () + "\n\nEdit Exam Composition?", "eLib", MessageBoxButtons.YesNoCancel);
                if (myansw == DialogResult.Cancel)
                    {
                    //do nothing
                    return;
                    }
                else if (myansw == DialogResult.Yes)
                    {
                    //edit Exam
                    Menu1_Edit_Click (null, null); //Edit Exam
                    return;
                    }
                else
                    {
                    //its ok to add more tests
                    for (int i = 0; i < Db.DS.Tables["tblExamComposition"].Rows.Count; i++)
                        {
                        ExamComposition.TopicId = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[i][2]);
                        ExamComposition.nTests = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[i][4]);
                        ExamComposition.TestsLevel = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[i][5]);
                        Testbank.AddRandomTestsToExam (Exam.Id, ExamComposition.TopicId, ExamComposition.nTests, ExamComposition.TestsLevel);
                        }
                    RefreshTestsList (Exam.Id, "exam", 0);
                    }
                }
            else
                {
                //add tests
                for (int i = 0; i < Db.DS.Tables["tblExamComposition"].Rows.Count; i++)
                    {
                    ExamComposition.TopicId = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[i][2]);
                    ExamComposition.nTests = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[i][4]);
                    ExamComposition.TestsLevel = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[i][5]);
                    Testbank.AddRandomTestsToExam (Exam.Id, ExamComposition.TopicId, ExamComposition.nTests, ExamComposition.TestsLevel);
                    }
                RefreshTestsList (Exam.Id, "exam", 0);
                }
            }
        private void DoSearch (string strSearchtext)
            {
            //locate
            int tmpStartIndex = Convert.ToInt32 (lstTests.SelectedIndex); //do search from selected-index onwards
            if (tmpStartIndex < 0)
                {
                tmpStartIndex = 1;
                }
            switch (TreeA.SelectedNode.Level)
                {
                case 0:
                        {
                        for (int i = tmpStartIndex + 1; i < Db.DS.Tables["tblTests"].Rows.Count; i++)
                            {
                            if (Strings.InStr (1, Db.DS.Tables["tblTests"].Rows[i][1].ToString ().ToLower (), strSearchtext) > 0)//col1:TestTitle
                                {
                                lstTests.SelectedIndex = i;
                                return;
                                }
                            }
                        MessageBox.Show ("Not found!", "eLib.Courses");
                        break;
                        }
                case 1:
                        {
                        for (int i = tmpStartIndex + 1; i < Db.DS.Tables["tblExamTests"].Rows.Count; i++)
                            {
                            if (Strings.InStr (1, Db.DS.Tables["tblExamTests"].Rows[i][2].ToString (), strSearchtext) > 0) //col2:TestTitle
                                {
                                lstTests.SelectedIndex = i;
                                return;
                                }
                            MessageBox.Show ("Not found!", "eLib.Exams");
                            }
                        break;
                        }
                }
            }
        private void DoExit ()
            {
            Dispose ();
            }
        //Exit
        private void Menu1_Exit_Click (object sender, EventArgs e)
            {
            DoExit ();
            }
        private void Menu2_Exit_Click (object sender, EventArgs e)
            {
            DoExit ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            DoExit ();
            }
        private void Menu2_Exit_Click_1 (object sender, EventArgs e)
            {
            DoExit ();
            }
        private void frmCourseExamTest_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (e.CloseReason == CloseReason.UserClosing)
                {
                e.Cancel = true;
                DoExit ();
                }
            }
        }
    }
