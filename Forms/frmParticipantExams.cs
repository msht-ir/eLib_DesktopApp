using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmStudentExams : Form
        {
        public frmStudentExams ()
            {
            InitializeComponent ();
            }
        private void frmStudentExams_Load (object sender, EventArgs e)
            {
            Width = 1150;
            Height = 600;
            RefreshCboEntries ();
            if (Student.Id != 0)
                {
                cboEntries.SelectedValue = Student.EntryId;
                RefreshGridStudents (Student.EntryId);
                GridStudents.CurrentCell = GridStudents.Rows [Student.Index].Cells [2];
                }
            RefreshGridStudentExam (Student.Id);
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
                    RefreshGridStudents (entryId);
                    }
                }
            catch { }
            }
        private void GridStudents_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            int r = (int) GridStudents.CurrentCell.RowIndex;
            if (r >= 0)
                {
                Student.Id = Convert.ToInt32 (GridStudents.Rows [r].Cells [0].Value);
                RefreshGridStudentExam (Student.Id);
                }
            }
        private void GridStudentExams_CellContentDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            btnDeleteExam_Click (null, null);
            }
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
                            RefreshGridStudents (intEntryId);
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
        private void btn_AddNewStudent_Click (object sender, EventArgs e)
            {
            AddNewStudent ();
            GridStudents.Focus ();
            }
        private void btn_EditStudent_Click (object sender, EventArgs e)
            {
            EditStudent ();
            }
        private void btn_DeleteStudent_Click (object sender, EventArgs e)
            {
            int r = GridStudents.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                DialogResult myansw = MessageBox.Show ("Delete Student?\n\nNotice:\nExamSheets of this Student will be deleted too", "eLib.Exams", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.OK)
                    {
                    Student.Id = Convert.ToInt32 (GridStudents.Rows [r].Cells [0].Value);
                    Testbank.DeleteOneStudentFromEntry (Student.Id);
                    RefreshGridStudents (Convert.ToInt32 (cboEntries.SelectedValue));
                    RefreshGridStudentExam (Exam.Id);
                    }
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
                    RefreshGridStudentExam (Exam.Id);
                    }
                }
            }
        private void btnAddExamToStudent_Click (object sender, EventArgs e)
            {
            if (GridStudents.SelectedCells [0].RowIndex >= 0)
                {
                System.Windows.Forms.Form frm_SelectExam = new frmSelectExam ();
                frm_SelectExam.ShowDialog ();
                if (Exam.Id > 0)
                    {
                    Testbank.AddOneStudent2Exam (Student.Id, Exam.Id);
                    RefreshGridStudentExam (Student.Id);
                    }
                }
            else
                {
                MessageBox.Show ("Select a Student from Left Panel", "eLib.Exams");
                }
            }
        private void btnDeleteExam_Click (object sender, EventArgs e)
            {
            //remove from grid2
            //0ID, 1Student_ID, 2Exam_ID, 3StudentName, 4StudentPass, 5Started, 6DateTime, 7Finished
            if (!chkDoubleClickToDelete.Checked)
                {
                return;
                }
            int r = (int) GridStudentExams.SelectedCells [0].RowIndex;
            if (r >= 0)
                {
                //confirm!
                DialogResult myansw = MessageBox.Show ("Are you sure?\nAll ExamSheet for the Student will be deleted!\n\nContinue?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.No)
                    {
                    return;
                    }
                else
                    {
                    Exam.Id = Convert.ToInt32 (GridStudentExams.Rows [r].Cells [1].Value);
                    Testbank.RemoveOneStudentFromExam (Exam.Id, Student.Id);
                    RefreshGridStudentExam (Student.Id);
                    }
                }
            }
        //Menu
        private void Menu1_Passwords_Click (object sender, EventArgs e)
            {
            int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
            Testbank.GetEntryStudents (entryId);
            //0ID, 1Entry_ID, 2StudentName, 3StudentPass
            DialogResult myansw = MessageBox.Show ("Show QR-CODE ?", "eLib.Exams", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (myansw)
                {
                case DialogResult.Yes:
                        {
                        string strUsrPwds = "";
                        for (int i = 0; i < Db.DS.Tables ["tblEntryStudents"].Rows.Count; i++)
                            {
                            strUsrPwds += Db.DS.Tables ["tblEntryStudents"].Rows [i] [2].ToString () + "   /   " + Db.DS.Tables ["tblEntryStudents"].Rows [i] [3].ToString () + "\n\n";
                            }
                        Client.GenerateQRCode (strUsrPwds);
                        Testbank.PrintoutEntryStudentsUserPass (entryId);
                        break;
                        }
                case DialogResult.No:
                        {
                        Testbank.PrintoutEntryStudentsUserPass (entryId);
                        break;
                        }
                case DialogResult.Cancel:
                        {
                        break;
                        }
                }
            }
        private void Menu2_PrintoutExamSheet_Click (object sender, EventArgs e)
            {
            int r1 = (int) GridStudents.SelectedCells [0].RowIndex;
            int r2 = (int) GridStudentExams.SelectedCells [0].RowIndex;
            if ((r1 >= 0) && (r2 >= 0))
                {
                if (!Convert.ToBoolean (GridStudentExams.Rows [r2].Cells [6].Value))
                    {
                    Student.Id = Convert.ToInt32 (GridStudents.Rows [r1].Cells [0].Value);
                    Exam.Id = Convert.ToInt32 (GridStudentExams.Rows [r2].Cells [1].Value);
                    Exam.Title = GridStudentExams.Rows [r2].Cells [2].Value.ToString ();
                    Testbank.PrintoutRawExamSheets (Exam.Id, Student.Id);
                    }
                else
                    {
                    MessageBox.Show (GridStudents.Rows [r1].Cells [2].Value.ToString () + " has written this exam!");
                    }
                }
            }
        private void Menu2_PrintoutExamRecord_Click (object sender, EventArgs e)
            {
            int r1 = (int) GridStudents.SelectedCells [0].RowIndex;
            int r2 = (int) GridStudentExams.SelectedCells [0].RowIndex;
            if ((r1 >= 0) & (r2 >= 0))
                {
                if (Convert.ToBoolean (GridStudentExams.Rows [r2].Cells [8].Value))
                    {
                    Student.Id = Convert.ToInt32 (GridStudents.Rows [r1].Cells [0].Value);
                    Exam.Id = Convert.ToInt32 (GridStudentExams.Rows [r2].Cells [1].Value);
                    Exam.Title = GridStudentExams.Rows [r2].Cells [2].Value.ToString ();
                    Testbank.PrintoutExamRecords (Exam.Id, Student.Id);
                    }
                else
                    {
                    MessageBox.Show ("Student has not finished this Exam!", "eLib");
                    }
                }
            }
        //methods
        private void RefreshCboEntries ()
            {
            try
                {
                cboEntries.DataSource = null;
                Testbank.GetEntries (User.Id);
                cboEntries.DataSource = Db.DS.Tables ["tblEntries"];
                cboEntries.DisplayMember = "EntryName";
                cboEntries.ValueMember = "ID";
                cboEntries.SelectedValue = Student.Id;
                GridStudents.DataSource = null;
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        private void RefreshGridStudents (int entryId)
            {
            GridStudents.DataSource = null;
            Testbank.GetEntryStudents (entryId);
            GridStudents.DataSource = Db.DS.Tables ["tblEntryStudents"];
            for (int i = 0, loopTo = GridStudents.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                GridStudents.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //0ID, 1Entry_ID, 2StudentName, 3StudentPass
            GridStudents.Columns [0].Visible = false;   //ID
            GridStudents.Columns [1].Visible = false;   //Entry_ID
            GridStudents.Columns [2].Width = 180;       //StudentName
            GridStudents.Columns [3].Width = 80;        //StudentPass
            //reset right
            GridStudentExams.DataSource = null;
            }
        private void RefreshGridStudentExam (int StudentId)
            {
            if (StudentId == 0)
                {
                return;
                }
            else
                {
                GridStudentExams.DataSource = null;
                Testbank.GetAllStudentExams (Student.Id);
                GridStudentExams.DataSource = Db.DS.Tables ["tblStudentExams"];
                for (int i = 0, loopTo = GridStudents.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                    {
                    GridStudentExams.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                //0CourseName, 1Exams.ID, 2ExamTitle, 3ExamDuration, 4IsActive, 5Training, 6Started, 7ExamStudents.DateTime, 8Finished
                GridStudentExams.Columns [0].Width = 180;       //CourseName
                GridStudentExams.Columns [1].Visible = false;   //Exams.ID
                GridStudentExams.Columns [2].Width = 210;       //ExamTitle
                GridStudentExams.Columns [3].Width = 60;        //ExamDuration
                GridStudentExams.Columns [4].Width = 40;        //IsActive
                GridStudentExams.Columns [5].Width = 40;        //Training
                GridStudentExams.Columns [6].Width = 40;        //Started
                GridStudentExams.Columns [7].Width = 140;       //ExamStudents.DateTime
                GridStudentExams.Columns [8].Width = 40;        //Finished
                }
            }
        private void AddNewStudent ()
            {
            if ((cboEntries.Items.Count == 0) || (cboEntries.SelectedIndex == -1))
                {
                return;
                }
            else
                {
                int entryId = Convert.ToInt32 (cboEntries.SelectedValue);
                string strStudentName = "STDNT-" + (GridStudents.Rows.Count + 1).ToString ();
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
                        RefreshGridStudents (entryId);
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
            if ((GridStudents.Rows.Count == 0) || (GridStudents.SelectedCells [0].RowIndex == -1))
                {
                return;
                }
            else
                {
                //Grid1-cols: 0ID, 1Entry_ID, 2StudentName, 3StudentPass
                int intStudentId = Convert.ToInt32 (GridStudents.Rows [GridStudents.SelectedCells [0].RowIndex].Cells [0].Value.ToString ());
                string strStudentName = GridStudents.Rows [GridStudents.SelectedCells [0].RowIndex].Cells [2].Value.ToString ();
                string strStudentPass = GridStudents.Rows [GridStudents.SelectedCells [0].RowIndex].Cells [3].Value.ToString ();
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
                            RefreshGridStudents (intEntryId);
                            }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            }
        //exit
        private void Menu2_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu1_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        }
    }
