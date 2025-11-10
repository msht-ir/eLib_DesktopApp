using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmSelectStudents : Form
        {
        public frmSelectStudents ()
            {
            InitializeComponent ();
            }
        private void frmSelectStudents_Load (object sender, EventArgs e)
            {
            this.Width = 960;
            this.Height = 570;
            lblExamName.Text = Exam.Title;
            RefreshCboEntries ();
            RefreshGrid2 (Exam.Id);
            lblTrainingExam.Visible = (Exam.Training) ? true : false;
            }
        private void cboEntries_SelectedIndexChanged (object sender, EventArgs e)
            {
            try
                {
                if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                    {
                    return;
                    }
                else
                    {
                    int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
                    RefreshGrid1 (entryId);
                    }
                }
            catch { }
            }
        private void lblTrainingExam_DoubleClick (object sender, EventArgs e)
            {
            //Convert a training exam to a real exam

            }
        //combo
        private void btnAddNewEntry_Click (object sender, EventArgs e)
            {
            string strEntryName = Interaction.InputBox ("Entry / Class / Group - Name:", "eLib", "new Entry" + (cboEntries.Items.Count + 1).ToString ());
            if (!string.IsNullOrEmpty (strEntryName))
                {
                int newEntryId = Testbank.AddNewEntry (User.Id, strEntryName);
                RefreshCboEntries ();
                cboEntries.Focus ();
                cboEntries.SelectedValue = newEntryId;
                }
            }
        private void btnEditEntry_Click (object sender, EventArgs e)
            {
            try
                {
                if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                    {
                    return;
                    }
                else
                    {
                    int intEntryId = Convert.ToInt32 (cboEntries.SelectedValue);
                    string strEntryName = Interaction.InputBox ("New Name:", "eLib", cboEntries.Text);
                    if (!string.IsNullOrEmpty (strEntryName))
                        {
                        if (Testbank.UpdateEntry (intEntryId, strEntryName))
                            {
                            RefreshCboEntries ();
                            RefreshGrid1 (intEntryId);
                            cboEntries.Focus ();
                            cboEntries.SelectedValue = intEntryId;
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void lblExamName_Click (object sender, EventArgs e)
            {
            RefreshGrid2 (Exam.Id);
            }
        //grids        
        private void btn_AddNewStudent_Click (object sender, EventArgs e)
            {
            AddNewStudent ();
            Grid1.Focus ();
            }
        private void btn_EditStudent_Click (object sender, EventArgs e)
            {
            EditStudent ();
            }
        private void btnAddStudentToExam_Click (object sender, EventArgs e)
            {
            int r = (int) Grid1.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                Student.Id = Convert.ToInt32 (Grid1.Rows [r].Cells [0].Value);
                Testbank.AddOneStudent2Exam (Student.Id, Exam.Id);
                RefreshGrid2 (Exam.Id);
                }
            }
        private void btnDeleteEntry_Click (object sender, EventArgs e)
            {
            if ((cboEntries.Items.Count > 0) && (cboEntries.SelectedIndex >= 0))
                {
                DialogResult myansw = MessageBox.Show ("Delete Entry?\n\nAll Students in this entry and their ExamSheets will be deleted", "eLib.Exams", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.OK)
                    {
                    Student.EntryId = (int) cboEntries.SelectedValue;
                    Testbank.DeleteAnEntry (Student.EntryId);
                    RefreshCboEntries ();
                    RefreshGrid2 (Exam.Id);
                    }
                }
            }
        private void btn_DeleteStudent_Click (object sender, EventArgs e)
            {
            int r = Grid1.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                DialogResult myansw = MessageBox.Show ("Delete Student?\n\nNotice:\nExamSheets of this Student will be deleted too", "eLib.Exams", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.OK)
                    {
                    Student.Id = Convert.ToInt32 (Grid1.Rows [r].Cells [0].Value);
                    Testbank.DeleteOneStudentFromEntry (Student.Id);
                    RefreshGrid1 (Convert.ToInt32 (cboEntries.SelectedValue));
                    RefreshGrid2 (Exam.Id);
                    }
                }
            }
        private void Grid1_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            //add to grid2
            if (chkEnableDoubleClick.Checked)
                {
                btnAddStudentToExam_Click (null, null);
                }
            }
        private void Grid2_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            //remove from grid2
            //0ID, 1Student_ID, 2Exam_ID, 3StudentName, 4StudentPass, 5Started, 6DateTime, 7Finished
            if (!chkDoubleClickToDelete.Checked)
                {
                return;
                }
            int r = (int) Grid2.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                //confirm!
                DialogResult myansw = MessageBox.Show ("Are you sure?\nThe Students and it's ExamSheet will be deleted!\n\nContinue?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.No)
                    {
                    return;
                    }
                else
                    {
                    int examStudentId = Convert.ToInt32 (Grid2.Rows [r].Cells [1].Value);
                    Student.Id = Convert.ToInt32 (Grid2.Rows [r].Cells [1].Value);
                    Testbank.RemoveOneStudentFromExam (Exam.Id, Student.Id);
                    RefreshGrid2 (Exam.Id);
                    }
                }
            }
        //Menu1
        private void Menu1_AddNewStudent_Click (object sender, EventArgs e)
            {
            AddNewStudent ();
            }
        private void Menu1_EditStudent_Click (object sender, EventArgs e)
            {
            EditStudent ();
            Grid1.Focus ();
            }
        private void Menu1_SelectAll_Click (object sender, EventArgs e)
            {
            if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                {
                return;
                }
            else
                {
                int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
                AddAllStudents2Exam (entryId, Exam.Id);
                RefreshGrid2 (Exam.Id);
                }
            }
        private void Menu1_StudentExams_Click (object sender, EventArgs e)
            {
            try
                {
                int r = Grid1.SelectedCells [0].RowIndex;
                if (r >= 0)
                    {
                    Student.Id = Convert.ToInt32 (Grid1.Rows [r].Cells [0].Value.ToString ());
                    Student.Index = Convert.ToInt32 (Grid1.CurrentCell.RowIndex.ToString ());
                    Student.EntryId = (int) cboEntries.SelectedValue;
                    this.Dispose ();
                    var frmParticExams = new frmStudentExams ();
                    frmParticExams.ShowDialog ();
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        //Menu2
        private void Menu2_RemoveAllStudents_Click (object sender, EventArgs e)
            {
            //confirm!
            DialogResult myansw = MessageBox.Show ("Are you sure?\nAll Students and thrir ExamSheets will be deleted!\n\nContinue?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.No)
                {
                return;
                }
            else
                {
                for (int i = 0; i < Grid2.Rows.Count; i++)
                    {
                    Student.Id = Convert.ToInt32 (Grid2.Rows [i].Cells [1].Value);
                    Testbank.RemoveOneStudentFromExam (Exam.Id, Student.Id);
                    }
                RefreshGrid2 (Exam.Id);
                }
            }
        private void Menu2_PrintoutPasswords_Click (object sender, EventArgs e)
            {
            Testbank.GetExamStudents (Exam.Id);
            //0ID, 1Student_ID, 2Exam_ID, 3StudentName, 4StudentPass, 5Started, 6DateTime, 7Finished
            DialogResult myansw = MessageBox.Show ("Show QR-CODE ?", "eLib.Exams", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (myansw)
                {
                case DialogResult.Yes:
                        {
                        string strUsrPwds = "";
                        for (int i = 0; i < Db.DS.Tables ["tblExamStudents"].Rows.Count; i++)
                            {
                            strUsrPwds += Db.DS.Tables ["tblExamStudents"].Rows [i] [3].ToString () + "   /   " + Db.DS.Tables ["tblExamStudents"].Rows [i] [4].ToString () + "\n\n";
                            }
                        Client.GenerateQRCode (strUsrPwds);
                        Testbank.PrintoutExamStudentsUserPass ();
                        break;
                        }
                case DialogResult.No:
                        {
                        Testbank.PrintoutExamStudentsUserPass ();
                        break;
                        }
                case DialogResult.Cancel:
                        {
                        break;
                        }
                }
            }
        private void Menu2_PrintoutExamsheets_Click (object sender, EventArgs e)
            {
            int r = (int) Grid2.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                Student.Id = Convert.ToInt32 (Grid2.Rows [r].Cells [1].Value);
                Testbank.PrintoutRawExamSheets (Exam.Id, Student.Id);
                }
            }
        private void Menu2_PrintoutMarks_Click (object sender, EventArgs e)
            {
            Testbank.PrintoutExamMarks (Exam.Id);
            }
        private void Menu2_PrintoutStudentRecord_Click (object sender, EventArgs e)
            {
            int r = (int) Grid2.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                if (Convert.ToBoolean (Grid2.Rows [r].Cells [7].Value) == true)
                    {
                    Student.Id = Convert.ToInt32 (Grid2.Rows [r].Cells [1].Value);
                    Testbank.PrintoutExamRecords (Exam.Id, Student.Id);
                    }
                else
                    {
                    MessageBox.Show ("Student has not finished the Exam!", "eLib");
                    }
                }
            }
        //Exit
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu1_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu2_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        //methods
        private void AddNewStudent ()
            {
            if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                {
                return;
                }
            else
                {
                int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
                string strStudentName = "STDNT-" + (Grid1.Rows.Count + 1).ToString ();
                string strStudentPass = Strings.Left (strStudentName, 4) + DateTime.Now.ToString ("mmss");
                //dialog
                Project.Name = strStudentName;
                Project.Note = strStudentPass;
                Client.DialogRequestParams = 128; //dialog for: new user pass
                My.MyProject.Forms.frmProject.ShowDialog ();
                if (Client.DialogRequestParams == 16) //bit5(00010000): bit5=0:cancel, bit5=1(value=16):save
                    {
                    Project.Note += "--------";//Ensure pass is at least  8chars
                    strStudentName = Strings.Left (Project.Name, 40);
                    strStudentPass = Strings.Left (Project.Note, 8);
                    //update
                    try
                        {
                        Testbank.AddNewStudent2Entry (entryId, strStudentName, strStudentPass);
                        RefreshGrid1 (entryId);
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            }
        private void EditStudent ()
            {
            if ((Grid1.Rows.Count == 0) || (Grid1.SelectedCells [0].RowIndex == -1))
                {
                return;
                }
            else
                {
                //Grid1-cols: 0ID, 1Entry_ID, 2StudentName, 3StudentPass
                int intStudentId = Convert.ToInt32 (Grid1.Rows [Grid1.SelectedCells [0].RowIndex].Cells [0].Value.ToString ());
                string strStudentName = Grid1.Rows [Grid1.SelectedCells [0].RowIndex].Cells [2].Value.ToString ();
                string strStudentPass = Grid1.Rows [Grid1.SelectedCells [0].RowIndex].Cells [3].Value.ToString ();
                //dialog
                Project.Name = strStudentName;
                Project.Note = strStudentPass;
                Client.DialogRequestParams = 136; //dialog for: edit user pass
                My.MyProject.Forms.frmProject.ShowDialog ();
                if (Client.DialogRequestParams == 16) //bit5(00010000): bit5=0:cancel, bit5=1(value=16):save
                    {
                    Project.Note += "--------";//Ensure pass is at least  8chars
                    strStudentName = Strings.Left (Project.Name, 40);
                    strStudentPass = Strings.Left (Project.Note, 8);
                    //update
                    try
                        {
                        if (Testbank.UpdateStudent (intStudentId, strStudentName, strStudentPass))
                            {
                            int intEntryId = Convert.ToInt32 (cboEntries.SelectedValue);
                            RefreshGrid1 (intEntryId);
                            }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            }
        public void AddAllStudents2Exam (int entryId, int examId)
            {
            progressBar1.Visible = true;
            int rows = Db.DS.Tables ["tblEntryStudents"].Rows.Count;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = rows;
            for (int i = 0; i < Db.DS.Tables ["tblEntryStudents"].Rows.Count; i++)
                {
                progressBar1.Value = i + 1;
                Student.Id = Convert.ToInt32 (Db.DS.Tables ["tblEntryStudents"].Rows [i] [0].ToString ());
                bool boolExist = false;
                for (int j = 0; j < Grid2.RowCount; j++)
                    {
                    if (Convert.ToInt32 (Grid2.Rows [j].Cells [1].Value) == Student.Id)
                        {
                        boolExist = true;
                        break;
                        }
                    }
                if (!boolExist)
                    {
                    Testbank.AddOneStudent2Exam (Student.Id, examId);
                    }
                }
            progressBar1.Visible = false;
            }
        private void RefreshCboEntries ()
            {
            try
                {
                cboEntries.DataSource = null;
                Testbank.GetEntries (User.Id);
                cboEntries.DataSource = Db.DS.Tables ["tblEntries"];
                cboEntries.DisplayMember = "EntryName";
                cboEntries.ValueMember = "ID";
                cboEntries.SelectedIndex = -1;
                Grid1.DataSource = null;
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        private void RefreshGrid1 (int entryId)
            {
            Grid1.DataSource = null;
            Testbank.GetEntryStudents (entryId);
            Grid1.DataSource = Db.DS.Tables ["tblEntryStudents"];
            for (int i = 0, loopTo = Grid1.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                Grid1.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //ID, Entry_ID, StudentName, StudentPass
            Grid1.Columns [0].Visible = false;   //ID
            Grid1.Columns [1].Visible = false;   //Entry_ID
            Grid1.Columns [2].Width = 210;       //StudentName
            Grid1.Columns [3].Width = 110;       //StudentPass
            }
        private void RefreshGrid2 (int examId)
            {
            Grid2.DataSource = null;
            Testbank.GetExamStudents (examId);
            Grid2.DataSource = Db.DS.Tables ["tblExamStudents"];
            for (int i = 0, loopTo = Grid1.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                Grid2.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //0ID, 1Student_ID, 2Exam_ID, 3StudentName, 4StudentPass, 5Started, 6DateTime, 7Finished
            Grid2.Columns [0].Visible = false;   //ID
            Grid2.Columns [1].Visible = false;   //Student_ID
            Grid2.Columns [2].Visible = false;   //Exam_ID
            Grid2.Columns [3].Width = 180;       //StudentName
            Grid2.Columns [4].Width = 90;        //StudentPass
            Grid2.Columns [5].Width = 40;        //Started
            Grid2.Columns [6].Width = 120;       //DateTime
            Grid2.Columns [7].Width = 40;        //Finished
            }
        }
    }
