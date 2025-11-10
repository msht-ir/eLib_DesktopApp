using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using Constants = Microsoft.VisualBasic.Constants;

namespace eLib
    {
    public partial class frmUsers
        {
        public frmUsers ()
            {
            InitializeComponent ();
            }
        private void frmUsers_Load (object sender, EventArgs e)
            {
            RefreshGridUsers ();
            }
        private void frmUsers_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode.ToString ())
                {
                case "27":
                        {
                        Logout ();
                        //Menu_LoginAsAdmin_Click (sender, e);  // nothing
                        break;
                        }
                case "F1":
                        {
                        txtCmd.Text = "-?";
                        break;
                        }
                case "F2":
                        {
                        if (GridUsers.Focused)
                            {
                            txtCmd.Focus ();
                            }
                        else if (txtCmd.Focused)
                            {
                            GridUsers.Focus ();
                            }
                        break;
                        }
                default:
                        {
                        break;
                        }
                }
            }
        private void GridUsers_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            int boolON = 1;
            int boolOFF = 0;
            if (GridUsers.RowCount < 1)
                {
                return;
                }
            int r = GridUsers.SelectedCells[0].RowIndex;    // count from 0
            int c = GridUsers.SelectedCells[0].ColumnIndex; // count from 0
            if (r < 0 | c < 0)
                {
                return;
                }
            string valx = Conversions.ToString (Db.DS.Tables["tblUsrs"].Rows[r][c]);
            //MessageBox.Show (r.ToString + " " + c.ToString + " " + valx, "eLib");
            // 0    ID              '1    UserName        '2    UserPass
            // 3    Active          '4    UsrSN           '5    Acc
            // 6    Folder Papers   '7    Folder Books    '8    Folder Manuals
            // 9    Folder Lecture  '10   Folder Temp     '11   Folder SaveAs
            // 12   Folder Note     '13   Interface
            // -----------------------------------------------------------------------------------------------------------------
            switch (c)
                {
                case 1: //user
                        {
                        //get admin ids
                        string strAdminUsername = User.Name;
                        string strAdminPassword = User.Pass;
                        //get user ids
                        User.Name = Db.DS.Tables["tblUsrs"].Rows[r][1].ToString ();
                        User.Pass = Db.DS.Tables["tblUsrs"].Rows[r][2].ToString ();
                        Db.ChengePassword ();
                        Db.DS.Tables["tblUsrs"].Rows[r][1] = User.Name;
                        Db.DS.Tables["tblUsrs"].Rows[r][2] = User.Pass;
                        //restore admin ids
                        User.Name = strAdminUsername;
                        User.Pass = strAdminPassword;
                        break;
                        }
                case 2: //password
                        {
                        //backup admin ids
                        string strAdminUsername = User.Name;
                        string strAdminPassword = User.Pass;
                        //get user ids
                        User.Name = Db.DS.Tables["tblUsrs"].Rows[r][1].ToString ();
                        User.Pass = Db.DS.Tables["tblUsrs"].Rows[r][2].ToString ();
                        Db.ChengePassword ();
                        Db.DS.Tables["tblUsrs"].Rows[r][1] = User.Name;
                        Db.DS.Tables["tblUsrs"].Rows[r][2] = User.Pass;
                        //restore admin ids
                        User.Name = strAdminUsername;
                        User.Pass = strAdminPassword;
                        break;
                        }
                case 3: // Toggle on/off
                        {
                        if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables["tblUsrs"].Rows[r][c], 0, false)))
                            {
                            Db.DS.Tables["tblUsrs"].Rows[r][c] = boolON;
                            }
                        else
                            {
                            Db.DS.Tables["tblUsrs"].Rows[r][c] = boolOFF;
                            }

                        break;
                        }
                case 6:
                case 7:
                case 8:
                case 9:
                case 11: // Use Folder_Dialog
                        {
                        FolderBrowserDialog1.SelectedPath = Application.StartupPath; // Environment.SpecialFolder.Desktop ' "D:\"
                        if (FolderBrowserDialog1.ShowDialog () == DialogResult.OK)
                            {
                            valx = FolderBrowserDialog1.SelectedPath;
                            }
                        else
                            {
                            valx = Interaction.InputBox ("Enter new Value for :", "Settings", valx);
                            }
                        Db.DS.Tables["tblUsrs"].Rows[r][c] = valx; // using INPUTBOX
                        break;
                        }

                default:
                        {
                        valx = Interaction.InputBox ("Enter new Value for   " + valx, "User Settings", valx);
                        Db.DS.Tables["tblUsrs"].Rows[r][c] = valx;
                        break;
                        }
                }
            SaveUserSettings (c, r);
            }
        private void txtCmd_TextChanged (object sender, EventArgs e)
            {
            switch (txtCmd.Text.Trim ().ToLower ())
                {
                case "-?":
                case "-help":
                case "-cmd":
                        {
                        txtCmd.Text = "-New user, -Edit, -Backup, -Restore, -Settings, -Delete, -Clear, -Logout, -exit";
                        txtCmd.SelectionStart = 0;
                        txtCmd.SelectionLength = txtCmd.TextLength;
                        break;
                        }
                case "-new":
                        {
                        string strcmd1 = "Create new user? ";
                        string strcmd2 = "Yes | No";
                        txtCmd.Text = strcmd1 + strcmd2;
                        txtCmd.SelectionStart = strcmd1.Length;
                        txtCmd.SelectionLength = strcmd2.Length;
                        break;
                        }
                case "create new user? y":
                        {
                        NewUser ();
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "create new user? n":
                        {
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-edit":
                        {
                        GridUsers_CellDoubleClick (null, null);
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-backup":
                        {
                        Backup_eLib ();
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-restore":
                        {
                        Restore_eLib ();
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-settings":
                        {
                        My.MyProject.Forms.frmSettings.ShowDialog ();
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-delete":
                        {
                        DeleteUser ();
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        break;
                        }
                case "-clear":
                        {
                        ClearDB ();
                        txtCmd.Focus ();
                        txtCmd.Text = "";
                        //txtCmd.SelectionStart = 0;
                        //txtCmd.SelectionLength = txtCmd.TextLength;
                        break;
                        }
                case "-logout":
                case "-log out":
                        {
                        Logout ();
                        break;
                        }
                case "-exit":
                case "-quit":
                        {
                        Db.CnnSS.Close ();
                        Db.CnnSS.Dispose ();
                        Db.CnnSS = null;
                        Application.Exit ();
                        Environment.Exit (0);
                        break;
                        }
                }
            }
        //labels
        private void lblLogOut_Click (object sender, EventArgs e)
            {
            Logout ();
            }
        private void lblNewUser_Click (object sender, EventArgs e)
            {
            NewUser ();
            }
        //MENU
        private void Menu_AddNewUser_Click (object sender, EventArgs e)
            {
            Db.AddNewUser ();
            RefreshGridUsers ();
            }
        private void MenuTools_DeleteUser_Click (object sender, EventArgs e)
            {
            DeleteUser ();
            }
        private void MenuTools_Backup2_Click (object sender, EventArgs e)
            {
            Backup_eLib ();
            }
        private void MenuTools_Restore_Click (object sender, EventArgs e)
            {
            Restore_eLib ();
            }
        private void MenuTools_Clear_Click (object sender, EventArgs e)
            {
            ClearDB ();
            }
        private void MenuTools_Settings_Click (object sender, EventArgs e)
            {
            My.MyProject.Forms.frmSettings.ShowDialog ();
            }
        private void Menu_LogOut_Click (object sender, EventArgs e)
            {
            Logout ();
            }
        //methods
        private void RefreshGridUsers ()
            {
            Db.ReadSettingsAndUsers ();
            GridUsers.DataSource = Db.DS.Tables["tblUsrs"];
            GridUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GridUsers.Columns[0].Visible = false;                      // ID
            GridUsers.Columns[1].Width = 120;                          // UserName
            GridUsers.Columns[2].Width = 130;                          // UserPass
            GridUsers.Columns[3].Width = 50;                           // Active
            GridUsers.Columns[4].Visible = false;                      // UsrSN
            GridUsers.Columns[5].Visible = false;                      // Acc
            GridUsers.Columns[6].Width = 150;                          // Folder Papers
            GridUsers.Columns[7].Width = 150;                          // Folder Books
            GridUsers.Columns[8].Width = 150;                          // Folder Manuals
            GridUsers.Columns[9].Width = 150;                          // Folder Lecture
            GridUsers.Columns[10].Visible = false;                     // Folder Temp
            GridUsers.Columns[11].Width = 150;                         // Folder SaveAs
            GridUsers.Columns[12].Width = 150;                         // Folder Note
            GridUsers.Columns[13].Visible = false;                     // Interface
            for (int i = 0, loopTo = GridUsers.Columns.Count - 1; i <= loopTo; i++)       // Disable sort for column_haeders
                GridUsers.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            Text = "eLib     |     USR: " + User.Name + "     |     DB: " + Report.Caption + "     |     BE: " + Db.CurrentDbVersion;
            GridUsers.Refresh ();
            if (GridUsers.Rows.Count > 1)
                GridUsers.Rows[0].Cells[1].Selected = true;
            GridUsers.Focus ();
            }
        private void NewUser ()
            {
            Db.AddNewUser ();
            RefreshGridUsers ();
            }
        private void SaveUserSettings (int c, int r)
            {
            switch (c)
                {
                case 1:
                        {
                        Db.strSQL = "UPDATE Usrs SET UsrName = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 2:
                        {
                        Db.strSQL = "UPDATE Usrs SET UsrPass = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 3:
                        {
                        Db.strSQL = "UPDATE Usrs SET UsrActive = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 5:
                        {
                        Db.strSQL = "UPDATE Usrs SET acc = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 6:
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderPapers = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 7:
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderBooks = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 8:
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderManuals = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 9:
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderLectures = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 11:
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderSaveACopy = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 12:
                        {
                        Db.strSQL = "UPDATE Usrs SET UsrNote = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case 13:
                        {
                        Db.strSQL = "UPDATE Usrs SET UsrInterface = @sttvalue WHERE ID = @ID";
                        break;
                        }
                }
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@sttvalue", Db.DS.Tables["tblUsrs"].Rows[r][c]);
                cmd.Parameters.AddWithValue ("@ID", Db.DS.Tables["tblUsrs"].Rows[r][0].ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        private void Backup_eLib ()
            {
            lblInfo.Text = "Backup in progress ... Please wait!";
            My.MyProject.Forms.frmBackup.ShowDialog ();
            if (Db.BackupRegister == 0)
                {
                return;
                }
            else
                {
                //do backup
                /* BackupRegister:
                  bit1:1   0000'0001  Refs
                  bit2:2   0000'0010  Projects and subProjects
                  bit3:4   0000'0100  Links
                  bit4:8   0000'1000  Notes
                  bit5:16  0001'0000  Backup CET (courses-exams-tests)
                  bit6:32  0010'0000  1:all-users (0: one-user)
                  bit7:64  0-00'0000  reserved
                  bit8:128 1000'0000  backup was successful
                 */
                progressBar1.Visible = false;
                progressBar2.Visible = true;
                progressBar2.Maximum = 18;
                //del this line: Db.BackupRegister = Db.BackupRegister | 16; //set bit5 on: backup all-users
                string strFilename = "eLibBackup" + DateTime.Now.ToString ("yyyy.MM.dd - HH.mm.ss");
                Db.CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString);
                //fill Tables
                //1
                progressBar2.Value = 1;
                Db.DS.Tables["tblUsrs"].Clear ();
                Db.strSQL = "Select ID, UsrName, UsrPass, UsrActive, UsrSN, acc, FolderPapers, FolderBooks, FolderManuals, FolderLectures, FolderTemp, FolderSaveACopy, UsrNote, UsrInterface FROM usrs ORDER BY ID;";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblUsrs");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //2
                progressBar2.Value = 2;
                Db.DS.Tables["tblUserProject"].Clear ();
                Db.strSQL = "SELECT User_Id, UsrName, UsrNote, Project_Id, ReadOnly FROM usrs INNER JOIN User_Project ON User_Project.User_Id = usrs.ID;";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblUserProject");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //3
                progressBar2.Value = 3;
                Db.DS.Tables["tblRefs"].Clear ();
                Db.strSQL = "SELECT Distinct ID, PaperName, IsPaper, IsBook, IsManual, IsLecture FROM Papers ORDER BY ID;";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblRefs");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //4
                progressBar2.Value = 4;
                Db.DS.Tables["tblProject"].Clear ();
                Db.strSQL = "Select ID, ProjectName, Notes, Active, User_ID FROM Projects Order By ID";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblProject");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //5
                progressBar2.Value = 5;
                Db.DS.Tables["tblSubProject"].Clear ();
                Db.strSQL = "Select ID, SubProjectName, Notes, Project_ID FROM SubProjects ORDER by ID";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblSubProject");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //6
                progressBar2.Value = 6;
                Db.DS.Tables["tblAssignments4Backup"].Clear ();
                Db.strSQL = "SELECT Links.ID, Paper_ID, SubProject_ID, Imp1, Imp2, Imp3, ImR FROM Links ORDER BY Links.ID;";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblAssignments4Backup");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //7
                progressBar2.Value = 7;
                Db.DS.Tables["tblSNotes"].Clear ();
                Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared, ReadOnly FROM Notes ORDER BY ID;";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblSNotes");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //8
                progressBar2.Value = 8;
                Db.DS.Tables["tblNoteNet"].Clear ();
                Db.strSQL = "SELECT ID, NoteA_ID, NoteB_ID FROM NoteNet";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.CnnSS.Close ();
                Db.DASS.Fill (Db.DS, "tblNoteNet");
                Application.DoEvents ();
                //9 Courses
                progressBar2.Value = 9;
                Db.DS.Tables["tblCourses"].Clear ();
                Db.strSQL = "SELECT ID, CourseName, CourseUnits, User_ID, RTL FROM Courses";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblCourses");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //10
                progressBar2.Value = 10;
                Db.DS.Tables["tblCourseTopics"].Clear ();
                Db.strSQL = "SELECT CourseTopicId, CourseId, Topic FROM CourseTopics";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblCourseTopics");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //11
                progressBar2.Value = 11;
                Db.DS.Tables["tblTests"].Clear ();
                Db.strSQL = "SELECT TEstId, TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel FROM Tests";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblTests");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //12
                progressBar2.Value = 12;
                Db.DS.Tables["tblTestOptions"].Clear ();
                Db.strSQL = "SELECT TestOptionId, TestId, OptionText, TestOptionTags FROM TestOptions";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblTestOptions");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //13
                progressBar2.Value = 13;
                Db.DS.Tables["tblExams"].Clear ();
                Db.strSQL = "SELECT ExamId, CourseId, ExamTitle, ExamDateTime, ExamDuration, ExamNTests, ExamTags FROM Exams";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblExams");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //14
                progressBar2.Value = 14;
                Db.DS.Tables["tblExamComposition"].Clear ();
                Db.strSQL = "Select ExamCompositions.ExamCompositionId, ExamId, TopicId, CourseTopicTitle, TopicNTests, TestsLevel FROM ExamComposition INNER JOIN CourseTopics ON ExamComposition.TopicId = CourseTopics.CourseTopicId";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblExamComposition");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //15
                progressBar2.Value = 15;
                Db.DS.Tables["tblEntries"].Clear ();
                Db.strSQL = "Select ID, EntryName, User_ID FROM Entries";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblEntries");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //16
                progressBar2.Value = 16;
                Db.DS.Tables["tblEntryStudents"].Clear ();
                Db.strSQL = "Select ID, Entry_ID, StudentName, StudentPass FROM Students";
                Db.CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblEntryStudents");
                Db.CnnSS.Close ();
                Application.DoEvents ();
                //close cnn
                Db.CnnSS.Dispose ();
                Application.DoEvents ();
                //17 Clear unnecessary/sensitive datatables (notice: User.AdminPass:Tables[tblSettings]Rows[0][3])
                progressBar2.Value = 17;
                //Db.DS.Tables ["tblSettings"].Clear ();
                //Db.DS.Tables ["tblConnections"].Clear ();            
                Db.DS.Tables["tblSecurityCodes"].Clear ();
                Db.DS.Tables["tblLNotes"].Clear ();
                Db.DS.Tables["tblRNotes"].Clear ();
                Db.DS.Tables["tblUNotes"].Clear ();
                Db.DS.Tables["tblDNotes"].Clear ();
                Db.DS.Tables["tblXNotes"].Clear ();
                Db.DS.Tables["tblNotesCount"].Clear ();
                Db.DS.Tables["tblAssignments"].Clear ();
                Db.DS.Tables["tblProj_tmp"].Clear ();
                Db.DS.Tables["tblProd_tmp"].Clear ();
                Db.DS.Tables["tblProd_tmp2"].Clear ();
                Db.DS.Tables["tblStudentExams"].Clear ();
                Db.DS.Tables["tblExamSheets"].Clear ();
                Db.DS.Tables["tblExamTests"].Clear ();
                Db.DS.Tables["tblArrows"].Clear ();
                Db.DS.Tables["tblPalette"].Clear ();
                Application.DoEvents ();
                //18 XML
                progressBar2.Value = 18;
                Instance.Path = Application.StartupPath + strFilename + ".xml"; //also is used in frmUsers to report via lbl
                Db.DS.WriteXml (Instance.Path, XmlWriteMode.WriteSchema);
                Db.BackupRegister = (Db.BackupRegister | 128);
                Application.DoEvents ();
                lblInfo.Text = "eLib     |     USR: " + User.Name + "     |     DB: " + Report.Caption + "     |     BE: " + Db.CurrentDbVersion;
                progressBar2.Visible = false;
                if ((Db.BackupRegister & 128) == 128)
                    {
                    lblInfo.Text = "Backup finished successfully!   [ " + Instance.Path + " ] Saved.";
                    }
                else
                    {
                    lblInfo.Text = "Backup Error!";
                    }
                progressBar1.Visible = false;
                progressBar2.Visible = false;
                }
            }
        private void Restore_eLib ()
            {
            DialogResult myansw = (DialogResult) MessageBox.Show ("Notice: 'Restore' will ERASE current data in library", "eLib", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if ((int) myansw == (int) Constants.vbCancel)
                return;
            lblInfo.Text = "Restoring ... Please wait!";
            //File Dialog to get address of Restore_Media (Excel File) ------------- A  
            Db.RestoreStatus = 0;
            using (var dialog = new OpenFileDialog () { InitialDirectory = Application.StartupPath, Filter = "eLib Restore Media|*.xml" })
                {
                if (dialog.ShowDialog () == DialogResult.OK)
                    {
                    eLibFile.Filename = dialog.FileName;
                    }
                else
                    {
                    progressBar1.Visible = false;
                    progressBar2.Visible = false;
                    lblInfo.Text = "Restore cancelled!";
                    return;
                    }
                }
            //initialize tbls (ensure tabel columns are constructed) --------------- B
            progressBar1.Visible = true;
            progressBar2.Visible = true;
            progressBar2.Maximum = 16;
            try
                {
                //open a connection for this method
                Db.CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString);
                Db.CnnSS.Open ();
                //0 tblUsrs
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID, UsrName, UsrPass, UsrActive, UsrSN, acc, FolderPapers, FolderBooks, FolderManuals, FolderLectures, FolderTemp, FolderSaveACopy, UsrNote, UsrInterface FROM usrs WHERE ID = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblUsrs");
                //1 tblUser_Project
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT User_Id, UsrName, UsrNote, Project_Id, ReadOnly FROM usrs INNER JOIN User_Project ON usrs.ID = User_Project.User_Id WHERE User_Id = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblUserProject");
                //2 tblRefs        
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture From Papers INNER Join (Links INNER Join (Projects INNER Join SubProjects On Projects.ID = SubProjects.Project_ID) ON Links.SubProject_ID = SubProjects.ID) ON Papers.ID = Links.Paper_ID WHERE Papers.ID = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblRefs");
                //3 tblProject      
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID, ProjectName, Notes, Active, User_ID FROM Projects WHERE ID = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblProject");
                //4 tblSubProjects      
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID, SubProjectName, Notes, Project_ID FROM SubProjects WHERE ID = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblSubProject");
                //5 tblAssignments4Backups (Links)
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Links.ID, Paper_ID, SubProject_ID, Imp1, Imp2, Imp3, ImR FROM Links WHERE Links.ID = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblAssignments4Backup");
                //6 tblNotes 
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared, ReadOnly FROM Notes WHERE ID = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblSNotes");
                //7 tblNoteNet 
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, NoteA_ID, NoteB_ID FROM NoteNet WHERE ID = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblNoteNet");
                //8 tblCourses
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT CourseId, CourseName, CourseUnits, UserId, RTL FROM Courses WHERE CourseId = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblCourses");
                //9 tblCourseTopics
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT CourseTopicId, CourseId, CourseTopicTitle FROM CourseTopics WHERE CourseTopicId = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblCourseTopics");
                //10 tblTests
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TestId, TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel FROM Tests WHERE TestId = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblTests");
                //11 tblTestOptions
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT TestOptionId, TestId, OptionText, TestOptionTags FROM TestOptions WHERE TestOptionId = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblTestOptions");
                //12 tblExams
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ExamId, CourseId, ExamTitle, ExamDateTime, ExamDuration, ExamNTests, ExamTags FROM Exams WHERE ExamId = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblExams");
                //13 tblExamComposition
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ExamCompositions.ExamCompositionId, ExamId, TopicId, TestTopicTitle, TopicNTests, TestsLevel FROM ExamComposition INNER JOIN CourseTopics ON ExamComposition.TopicId = CourseTopics.CourseTopicId WHERE ExamComposition.ExamCompositionId = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblExamComposition");
                //14 tblEntries
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select GroupId, GroupName, UserId FROM Groups WHERE GroupId = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblEntries");
                //15 tblEntryStudents
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT StudentId, GroupId, StudentName, StudentPass FROM Students WHERE StudentId = 0;", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblEntryStudents");
                //------------------------------------------------------------------ C
                //Del Database Tables Rows: WipeOut
                Db.ClearPapers ("Papers");
                Db.ClearPapers ("Paths");
                Db.ClearDatabaseTablesAndReseed ();
                Db.ClearRepositoryOfThisLibrary (0); //0: wo confirm (just type the random number)
                if (((Db.RestoreStatus & 1) == 0) || ((Db.RestoreStatus & 2) == 0))
                    {
                    MessageBox.Show ("elib: There is an Error in line 1203");
                    return;
                    }
                //------------------------------------------------------------------ D
                //Restore back data from xml (strFileName) to DS.tbls (DataTables)
                Db.DS.ReadXml (eLibFile.Filename, XmlReadMode.ReadSchema);
                Db.RestoreStatus = 0;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            //-------------------------------------------------------------------------- Restore -- xml -------- 0 users
            progressBar2.Value = 1;
            lblInfo.Text = "Restore Users";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT usrs ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                string strUserNote = "";
                int boolUserActive = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblUsrs"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblUsrs"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    User.Id = Convert.ToInt32 (Db.DS.Tables["tblUsrs"].Rows[r][0].ToString ());
                    User.Name = Db.DS.Tables["tblUsrs"].Rows[r][1].ToString ();
                    User.Pass = Db.DS.Tables["tblUsrs"].Rows[r][2].ToString ();
                    boolUserActive = (Db.DS.Tables["tblUsrs"].Rows[r][3].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    Client.SavedSN = Db.DS.Tables["tblUsrs"].Rows[r][4].ToString ();
                    User.Accs = Convert.ToInt32 (Db.DS.Tables["tblUsrs"].Rows[r][5].ToString ());
                    User.FolderPapers = Db.DS.Tables["tblUsrs"].Rows[r][6].ToString ();
                    User.FolderBooks = Db.DS.Tables["tblUsrs"].Rows[r][7].ToString ();
                    User.FolderManuals = Db.DS.Tables["tblUsrs"].Rows[r][8].ToString ();
                    User.FolderLectures = Db.DS.Tables["tblUsrs"].Rows[r][9].ToString ();
                    User.FolderTemp = Db.DS.Tables["tblUsrs"].Rows[r][10].ToString ();
                    User.FolderSaveACopy = Db.DS.Tables["tblUsrs"].Rows[r][11].ToString ();
                    strUserNote = Db.DS.Tables["tblUsrs"].Rows[r][12].ToString ();
                    Client.Interface = Convert.ToInt32 (Db.DS.Tables["tblUsrs"].Rows[r][13].ToString ());
                    Db.strSQL = "INSERT INTO usrs (ID, UsrName, UsrPass, UsrActive, UsrSN, acc, FolderPapers, FolderBooks, FolderManuals, FolderLectures, FolderTemp, FolderSaveACopy, usrNote, UsrInterface) VALUES (@id, @usrname, @usrpass, @usractive, @usrsn, 0, @folderpapers, @folderbooks, @foldermanuals, @folderlectures, @foldertemp, @foldersaveacopy, @usrnote, @usrinterface)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", User.Id);
                    cmd.Parameters.AddWithValue ("@usrname", User.Name);
                    cmd.Parameters.AddWithValue ("@usrpass", User.Pass);
                    cmd.Parameters.AddWithValue ("@usractive", boolUserActive.ToString ());
                    cmd.Parameters.AddWithValue ("@usrsn", Client.SavedSN);
                    cmd.Parameters.AddWithValue ("@acc", User.Accs.ToString ());
                    cmd.Parameters.AddWithValue ("@folderpapers", User.FolderPapers);
                    cmd.Parameters.AddWithValue ("@folderbooks", User.FolderBooks);
                    cmd.Parameters.AddWithValue ("@foldermanuals", User.FolderManuals);
                    cmd.Parameters.AddWithValue ("@folderlectures", User.FolderLectures);
                    cmd.Parameters.AddWithValue ("@foldertemp", User.FolderTemp);
                    cmd.Parameters.AddWithValue ("@foldersaveacopy", User.FolderSaveACopy);
                    cmd.Parameters.AddWithValue ("@usrnote", strUserNote);
                    cmd.Parameters.AddWithValue ("@usrinterface", Client.Interface);
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Users \r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT usrs OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 1 User_Project
            progressBar2.Value = 2;
            lblInfo.Text = "Restore User-Projects";
            try
                {
                int intReadOnly = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblUserProject"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblUserProject"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    User.Id = Convert.ToInt32 (Db.DS.Tables["tblUserProject"].Rows[r][0].ToString ());
                    Project.Id = Convert.ToInt32 (Db.DS.Tables["tblUserProject"].Rows[r][3].ToString ());
                    intReadOnly = (Db.DS.Tables["tblUserProject"].Rows[r][4].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    Db.strSQL = "INSERT INTO User_Project (User_Id, Project_Id, ReadOnly) VALUES (@userid, @projectid, @readonly)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@userid", User.Id);
                    cmd.Parameters.AddWithValue ("@projectid", Project.Id);
                    cmd.Parameters.AddWithValue ("@readonly", intReadOnly.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return;
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 2 Papers
            progressBar2.Value = 3;
            lblInfo.Text = "Restore Papers";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Papers ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }

            try
                {
                int intPaperID = 0;
                string strPaperName = "";
                int boolIsPaper = 0;
                int boolIsBook = 0;
                int boolIsManual = 0;
                int boolIsLecture = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblRefs"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblRefs"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    intPaperID = Convert.ToInt32 (Db.DS.Tables["tblRefs"].Rows[r][0].ToString ());
                    strPaperName = Db.DS.Tables["tblRefs"].Rows[r][1].ToString ();
                    boolIsPaper = (Db.DS.Tables["tblRefs"].Rows[r][2].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    boolIsBook = (Db.DS.Tables["tblRefs"].Rows[r][3].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    boolIsManual = (Db.DS.Tables["tblRefs"].Rows[r][4].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    boolIsLecture = (Db.DS.Tables["tblRefs"].Rows[r][5].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    Db.strSQL = "INSERT INTO Papers (ID, PaperName, IsPaper, IsBook, IsManual, IsLecture) VALUES (@id, @papername, @ispaper, @isbook, @ismanual, @islecture)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", intPaperID);
                    cmd.Parameters.AddWithValue ("@papername", strPaperName);
                    cmd.Parameters.AddWithValue ("@ispaper", boolIsPaper.ToString ());
                    cmd.Parameters.AddWithValue ("@isbook", boolIsBook.ToString ());
                    cmd.Parameters.AddWithValue ("@ismanual", boolIsManual.ToString ());
                    cmd.Parameters.AddWithValue ("@islecture", boolIsLecture.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Papers\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Papers OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 3 Projects
            progressBar2.Value = 4;
            lblInfo.Text = "Restore Projects";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Projects ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            int rx = 0;
            try
                {
                int intProjectID = 0;
                string strProjectName = "";
                string strProjectNotes = "";
                int boolProjectActive = 0;
                int intUserID = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblProject"].Rows.Count;
                for (rx = 0; rx < Db.DS.Tables["tblProject"].Rows.Count; rx++)
                    {
                    progressBar1.Value = rx;
                    intProjectID = Convert.ToInt32 (Db.DS.Tables["tblProject"].Rows[rx][0].ToString ());
                    strProjectName = Db.DS.Tables["tblProject"].Rows[rx][1].ToString ();
                    strProjectNotes = Db.DS.Tables["tblProject"].Rows[rx][2].ToString ();
                    boolProjectActive = (Db.DS.Tables["tblProject"].Rows[rx][3].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    intUserID = Convert.ToInt32 (Db.DS.Tables["tblProject"].Rows[rx][4].ToString ());
                    Db.strSQL = "INSERT INTO Projects (ID, ProjectName, Notes, Active, user_ID) VALUES (@id, @projectname, @notes, @active, @userid)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", intProjectID);
                    cmd.Parameters.AddWithValue ("@projectname", strProjectName);
                    cmd.Parameters.AddWithValue ("@notes", strProjectNotes);
                    cmd.Parameters.AddWithValue ("@active", boolProjectActive.ToString ());
                    cmd.Parameters.AddWithValue ("@userid", intUserID.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Projects\r\n rx= " + rx.ToString () + "\n\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Projects OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- excel -------- 4 SubProjects
            progressBar2.Value = 5;
            lblInfo.Text = "Restore SubProjects";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT SubProjects ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int intSubProjectID = 0;
                string strSubProjectName = "";
                string strNotes = "";
                int intProjectID = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblSubProject"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblSubProject"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    intSubProjectID = Convert.ToInt32 (Db.DS.Tables["tblSubProject"].Rows[r][0].ToString ());
                    strSubProjectName = Db.DS.Tables["tblSubProject"].Rows[r][1].ToString ();
                    strNotes = Db.DS.Tables["tblSubProject"].Rows[r][2].ToString ();
                    intProjectID = Convert.ToInt32 (Db.DS.Tables["tblSubProject"].Rows[r][3].ToString ());
                    Db.strSQL = "INSERT INTO SubProjects (ID, SubProjectName, Notes, Project_ID) VALUES (@id, @SubProjectName, @notes, @projectid)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", intSubProjectID);
                    cmd.Parameters.AddWithValue ("@SubProjectName", strSubProjectName);
                    cmd.Parameters.AddWithValue ("@notes", strNotes);
                    cmd.Parameters.AddWithValue ("@projectid", intProjectID.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing SubProjects\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT SubProjects OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 5 Links
            progressBar2.Value = 6;
            lblInfo.Text = "Restore Links";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Links ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int intPaperSubProjects = 0;
                int intPaperID = 0;
                int intSubProjectID = 0;
                int boolImp1 = 0;
                int boolImp2 = 0;
                int boolImp3 = 0;
                int boolImR = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblAssignments4Backup"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblAssignments4Backup"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    intPaperSubProjects = Convert.ToInt32 (Db.DS.Tables["tblAssignments4Backup"].Rows[r][0].ToString ());
                    intPaperID = Convert.ToInt32 (Db.DS.Tables["tblAssignments4Backup"].Rows[r][1].ToString ());
                    intSubProjectID = Convert.ToInt32 (Db.DS.Tables["tblAssignments4Backup"].Rows[r][2].ToString ());
                    boolImp1 = (Db.DS.Tables["tblAssignments4Backup"].Rows[r][3].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    boolImp2 = (Db.DS.Tables["tblAssignments4Backup"].Rows[r][4].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    boolImp3 = (Db.DS.Tables["tblAssignments4Backup"].Rows[r][5].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    boolImR = (Db.DS.Tables["tblAssignments4Backup"].Rows[r][6].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    Db.strSQL = "INSERT INTO Links (ID, Paper_ID, SubProject_ID, Imp1, Imp2, Imp3, ImR) VALUES (@id, @paperid, @SubProjectid, @imp1, @imp2, @imp3, @imr)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", intPaperSubProjects);
                    cmd.Parameters.AddWithValue ("@paperid", intPaperID.ToString ());
                    cmd.Parameters.AddWithValue ("@SubProjectid", intSubProjectID.ToString ());
                    cmd.Parameters.AddWithValue ("@imp1", boolImp1.ToString ());
                    cmd.Parameters.AddWithValue ("@imp2", boolImp2.ToString ());
                    cmd.Parameters.AddWithValue ("@imp3", boolImp3.ToString ());
                    cmd.Parameters.AddWithValue ("@imr", boolImR.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Assignments\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Links OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 6 Notes
            progressBar2.Value = 7;
            lblInfo.Text = "Restore Notes";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Notes ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int intNote = 0;
                string strNoteDatum = "";
                string strNotes = "";
                int intParentID = 0;
                int intParentType = 0; //ParentTypes (get notes): 1:SNotes, 2:LNotes, 3:RNotes
                int boolRtl = 0;
                int boolDone = 0;
                int intUserID = 0;
                int boolShared = 0;
                int boolReadOnly = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblSNotes"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblSNotes"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    intNote = Convert.ToInt32 (Db.DS.Tables["tblSNotes"].Rows[r][0].ToString ());
                    strNoteDatum = Db.DS.Tables["tblSNotes"].Rows[r][1].ToString ();
                    strNotes = Db.DS.Tables["tblSNotes"].Rows[r][2].ToString ();
                    intParentID = Convert.ToInt32 (Db.DS.Tables["tblSNotes"].Rows[r][3].ToString ());
                    intParentType = Convert.ToInt32 (Db.DS.Tables["tblSNotes"].Rows[r][4].ToString ());
                    boolRtl = (Db.DS.Tables["tblSNotes"].Rows[r][5].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    boolDone = (Db.DS.Tables["tblSNotes"].Rows[r][6].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    intUserID = Convert.ToInt32 (Db.DS.Tables["tblSNotes"].Rows[r][7].ToString ());
                    boolShared = (Db.DS.Tables["tblSNotes"].Rows[r][8].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    boolReadOnly = (Db.DS.Tables["tblSNotes"].Rows[r][9].ToString ().ToUpper () == "TRUE") ? 1 : 0;
                    Db.strSQL = "INSERT INTO Notes (ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared, ReadOnly) VALUES (@id, @datum, @note, @parentid, @parenttype, @rtl, @done, @userid, @shared, @readonly)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", intNote);
                    cmd.Parameters.AddWithValue ("@datum", strNoteDatum);
                    cmd.Parameters.AddWithValue ("@note", strNotes);
                    cmd.Parameters.AddWithValue ("@parentid", intParentID.ToString ());
                    cmd.Parameters.AddWithValue ("@parenttype", intParentType.ToString ());
                    cmd.Parameters.AddWithValue ("@rtl", boolRtl.ToString ());
                    cmd.Parameters.AddWithValue ("@done", boolDone.ToString ());
                    cmd.Parameters.AddWithValue ("@userid", intUserID.ToString ());
                    cmd.Parameters.AddWithValue ("@shared", boolShared.ToString ());
                    cmd.Parameters.AddWithValue ("@readonly", boolReadOnly.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing PapersNotes\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Notes OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 7 NoteNet
            progressBar2.Value = 8;
            lblInfo.Text = "Restore MindMap";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT NoteNet ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int intNoteA_ID = 0;
                int intNoteB_ID = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblNoteNet"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblNoteNet"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    intNoteA_ID = Convert.ToInt32 (Db.DS.Tables["tblNoteNet"].Rows[r][1].ToString ());
                    intNoteB_ID = Convert.ToInt32 (Db.DS.Tables["tblNoteNet"].Rows[r][2].ToString ());
                    Db.strSQL = "INSERT INTO NoteNet (ID, NoteA_ID, NoteB_ID) VALUES (@id, @noteaid, @notebid)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", Db.DS.Tables["tblNoteNet"].Rows[r][0].ToString ());
                    cmd.Parameters.AddWithValue ("@noteaid", intNoteA_ID.ToString ());
                    cmd.Parameters.AddWithValue ("@notebid", intNoteB_ID.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Note-Net\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT NoteNet OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 8 Courses
            progressBar2.Value = 9;
            lblInfo.Text = "Restore Courses";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Courses ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int course_ID = 0;
                string courseName = "";
                int courseUnits = 0;
                int userID = 0;
                bool courseRTL = false;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblCourses"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblCourses"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    course_ID = Convert.ToInt32 (Db.DS.Tables["tblCourses"].Rows[r][0].ToString ());
                    courseName = Db.DS.Tables["tblCourses"].Rows[r][1].ToString ();
                    courseUnits = Convert.ToInt32 (Db.DS.Tables["tblCourses"].Rows[r][2].ToString ());
                    userID = Convert.ToInt32 (Db.DS.Tables["tblCourses"].Rows[r][3].ToString ());
                    courseRTL = Convert.ToBoolean (Db.DS.Tables["tblCourses"].Rows[r][4].ToString ());
                    Db.strSQL = "INSERT INTO Courses (ID, CourseName, CourseUnits, User_ID, RTL) VALUES (@id, @coursename, @courseunits, @userid, @rtl)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", course_ID.ToString ());
                    cmd.Parameters.AddWithValue ("@coursename", courseName);
                    cmd.Parameters.AddWithValue ("@courseunits", courseUnits);
                    cmd.Parameters.AddWithValue ("@userid", userID.ToString ());
                    cmd.Parameters.AddWithValue ("@rtl", courseRTL.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Courses\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Courses OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 9 CourseTopics
            progressBar2.Value = 10;
            lblInfo.Text = "Restore Topics";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT CourseTopics ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int topicID = 0;
                int courseID = 0;
                string topicText = "";
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblCourseTopics"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblCourseTopics"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    topicID = Convert.ToInt32 (Db.DS.Tables["tblCourseTopics"].Rows[r][0].ToString ());
                    courseID = Convert.ToInt32 (Db.DS.Tables["tblCourseTopics"].Rows[r][1].ToString ());
                    topicText = Db.DS.Tables["tblCourseTopics"].Rows[r][2].ToString ();
                    Db.strSQL = "INSERT INTO CourseTopics (CourseTopicId, CourseId, CourseTopicTitle) VALUES (@id, @courseid, @topic)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", topicID.ToString ());
                    cmd.Parameters.AddWithValue ("@courseid", courseID.ToString ());
                    cmd.Parameters.AddWithValue ("@topic", topicText);
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Course-Topics\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT CourseTopics OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 10 Tests
            progressBar2.Value = 11;
            lblInfo.Text = "Restore Tests";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Tests ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int testID = 0;
                string TestTitle = "";
                int testType = 0;
                int courseId = 0;
                int topicId = 0;
                bool testRtl = false;
                bool optionsRtl = false;
                int testLevel = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblTests"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblTests"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    testID = Convert.ToInt32 (Db.DS.Tables["tblTests"].Rows[r][0].ToString ());
                    TestTitle = Db.DS.Tables["tblTests"].Rows[r][1].ToString ();
                    testType = Convert.ToInt32 (Db.DS.Tables["tblTests"].Rows[r][2].ToString ());
                    courseId = Convert.ToInt32 (Db.DS.Tables["tblTests"].Rows[r][3].ToString ());
                    topicId = Convert.ToInt32 (Db.DS.Tables["tblTests"].Rows[r][4].ToString ());
                    testRtl = Convert.ToBoolean (Db.DS.Tables["tblTests"].Rows[r][5].ToString ());
                    optionsRtl = Convert.ToBoolean (Db.DS.Tables["tblTests"].Rows[r][6].ToString ());
                    testLevel = Convert.ToInt32 (Db.DS.Tables["tblTests"].Rows[r][7].ToString ());
                    Db.strSQL = "INSERT INTO Tests (TestId, TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel) VALUES (@id, @TestTitle, @testtype, @courseid, @topicid, @testrtl, @optionsrtl, @testlevel)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", testID.ToString ());
                    cmd.Parameters.AddWithValue ("@TestTitle", TestTitle);
                    cmd.Parameters.AddWithValue ("@testtype", testType.ToString ());
                    cmd.Parameters.AddWithValue ("@courseid", courseId.ToString ());
                    cmd.Parameters.AddWithValue ("@topicid", topicId.ToString ());
                    cmd.Parameters.AddWithValue ("@testrtl", testRtl.ToString ());
                    cmd.Parameters.AddWithValue ("@optionsrtl", optionsRtl.ToString ());
                    cmd.Parameters.AddWithValue ("@testlevel", testLevel.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Tests\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Tests OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 11 TestOptions
            progressBar2.Value = 12;
            lblInfo.Text = "Restore Test-Options";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT TestOptions ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int testOptionID = 0;
                int testID = 0;
                string optionText = "";
                bool isAnswer = false;
                bool forceLast = false;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblTestOptions"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblTestOptions"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    testOptionID = Convert.ToInt32 (Db.DS.Tables["tblTestOptions"].Rows[r][0].ToString ());
                    testID = Convert.ToInt32 (Db.DS.Tables["tblTestOptions"].Rows[r][1].ToString ());
                    optionText = Db.DS.Tables["tblTestOptions"].Rows[r][2].ToString ();
                    isAnswer = Convert.ToBoolean (Db.DS.Tables["tblTestOptions"].Rows[r][3].ToString ());
                    forceLast = Convert.ToBoolean (Db.DS.Tables["tblTestOptions"].Rows[r][4].ToString ());
                    Db.strSQL = "INSERT INTO TestOptions (ID, Test_ID, OptionText, IsAnswer, ForceLast) VALUES (@id, @testid, @optiontext, @isanswer, @forcelast)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", testOptionID.ToString ());
                    cmd.Parameters.AddWithValue ("@testid", testID.ToString ());
                    cmd.Parameters.AddWithValue ("@optiontext", optionText);
                    cmd.Parameters.AddWithValue ("@isanswer", isAnswer.ToString ());
                    cmd.Parameters.AddWithValue ("@forcelast", forceLast.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Test_Options\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT TestOptions OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 12 Exams
            progressBar2.Value = 13;
            lblInfo.Text = "Restore Exams";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Exams ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int examID = 0;
                int courseID = 0;
                string examTitle = "";
                string examDateTime = "";
                string examDuration = "";
                int examNTests = 0;
                bool examTags = false;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblExams"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblExams"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    examID = Convert.ToInt32 (Db.DS.Tables["tblExams"].Rows[r][0].ToString ());
                    courseID = Convert.ToInt32 (Db.DS.Tables["tblExams"].Rows[r][1].ToString ());
                    examTitle = Db.DS.Tables["tblExams"].Rows[r][2].ToString ();
                    examDateTime = Db.DS.Tables["tblExams"].Rows[r][3].ToString ();
                    examDuration = Db.DS.Tables["tblExams"].Rows[r][4].ToString ();
                    examNTests = Convert.ToInt32 (Db.DS.Tables["tblExams"].Rows[r][5].ToString ());
                    examTags = Convert.ToBoolean (Db.DS.Tables["tblExams"].Rows[r][6].ToString ());
                    Db.strSQL = "INSERT INTO Exams (ExamId, CourseId, ExamTitle, ExamDateTime, ExamDuration, ExamNTests, ExamTags) VALUES (@id, @courseid, @examtitle, @examdatetime, @examduration, @examntests, @examtags)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@id", examID.ToString ());
                    cmd.Parameters.AddWithValue ("@courseid", courseID.ToString ());
                    cmd.Parameters.AddWithValue ("@examtitle", examTitle);
                    cmd.Parameters.AddWithValue ("@examdatetime", examDateTime);
                    cmd.Parameters.AddWithValue ("@examduration", examDuration.ToString ());
                    cmd.Parameters.AddWithValue ("@examntests", examNTests.ToString ());
                    cmd.Parameters.AddWithValue ("@examtags", examTags.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Exams\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Exams OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 13 ExamComposition
            progressBar2.Value = 14;
            lblInfo.Text = "Exam-Composition";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT ExamComposition ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int examCompID = 0;
                int examID = 0;
                int topicID = 0;
                int topicNTests = 0;
                int testsLevel = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblExamComposition"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblExamComposition"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    examCompID = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[r][0].ToString ());
                    examID = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[r][1].ToString ());
                    topicID = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[r][2].ToString ());
                    topicNTests = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[r][4].ToString ()); //col3: TopicText
                    testsLevel = Convert.ToInt32 (Db.DS.Tables["tblExamComposition"].Rows[r][5].ToString ());
                    Db.strSQL = "INSERT INTO ExamComposition (ID, Exam_ID, TopicId, TopicNTests, TestsLevel) VALUES (@id, @examid, @topicid, @topicntests, @testslevel)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("id", examCompID.ToString ());
                    cmd.Parameters.AddWithValue ("examid", examID.ToString ());
                    cmd.Parameters.AddWithValue ("topicid", topicID.ToString ());
                    cmd.Parameters.AddWithValue ("topicntests", topicNTests.ToString ());
                    cmd.Parameters.AddWithValue ("testslevel", testsLevel.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Exam-Composition\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT ExamComposition OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 14 Entries
            progressBar2.Value = 15;
            lblInfo.Text = "Restore Entries";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Entries ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int entryID = 0;
                string entryName = "";
                int userID = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblEntries"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblEntries"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    entryID = Convert.ToInt32 (Db.DS.Tables["tblEntries"].Rows[r][0].ToString ());
                    entryName = Db.DS.Tables["tblEntries"].Rows[r][1].ToString ();
                    userID = Convert.ToInt32 (Db.DS.Tables["tblEntries"].Rows[r][2].ToString ());
                    Db.strSQL = "INSERT INTO Entries (ID, EntryName, User_ID) VALUES (@id, @entryname, @userid)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("id", entryID.ToString ());
                    cmd.Parameters.AddWithValue ("entryname", entryName);
                    cmd.Parameters.AddWithValue ("userid", userID);
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error:\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Entries OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- 15 EntryStudents
            progressBar2.Value = 16;
            lblInfo.Text = "Restore Entry-Students";
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Students ON";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            try
                {
                int StudentID = 0;
                int entryID = 0;
                string StudentName = "";
                string StudentPass = "";
                progressBar1.Value = 0;
                progressBar1.Maximum = Db.DS.Tables["tblEntryStudents"].Rows.Count;
                for (int r = 0; r < Db.DS.Tables["tblEntryStudents"].Rows.Count; r++)
                    {
                    progressBar1.Value = r;
                    StudentID = Convert.ToInt32 (Db.DS.Tables["tblEntryStudents"].Rows[r][0].ToString ());
                    entryID = Convert.ToInt32 (Db.DS.Tables["tblEntryStudents"].Rows[r][1].ToString ());
                    StudentName = Db.DS.Tables["tblEntryStudents"].Rows[r][2].ToString ();
                    StudentPass = Db.DS.Tables["tblEntryStudents"].Rows[r][3].ToString ();
                    Db.strSQL = "INSERT INTO Students (ID, Entry_ID, StudentName, StudentPass) VALUES (@id, @entryid, @Studentname, @Studentpass)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("id", StudentID.ToString ());
                    cmd.Parameters.AddWithValue ("entryid", entryID.ToString ());
                    cmd.Parameters.AddWithValue ("Studentname", StudentName);
                    cmd.Parameters.AddWithValue ("Studentpass", StudentPass);
                    int i = cmd.ExecuteNonQuery ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error:\r\n" + ex.ToString ());
                return;
                }
            try
                {
                Db.strSQL = "SET IDENTITY_INSERT Students OFF";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Application.DoEvents ();
            //-------------------------------------------------------------------------- Restore -- xml -------- FINISHED
            Client.DialogRequestParams = 128;
            //RESTORE FINISHED SUCCESSFULLY!
            lblInfo.Text = "eLib     |     USR: " + User.Name + "     |     DB: " + Report.Caption + "     |     BE: " + Db.CurrentDbVersion;
            RefreshGridUsers ();
            if (Client.DialogRequestParams == 128)
                {
                lblInfo.Text = "Restore Finished Successfully !";
                //MessageBox.Show ("Restore Finished Successfully !", "eLib");
                Db.ScanResources ();
                }
            else
                {
                lblInfo.Text = "Restore Error!";
                }
            progressBar1.Visible = false;
            progressBar2.Visible = false;
            }
        private void DeleteUser ()
            {
            if (GridUsers.Rows.Count == 0)
                return;
            int iRow = GridUsers.SelectedCells[0].RowIndex;
            if (iRow < 0)
                return;
            int intUser2bDel = (int) Math.Round (Conversion.Val (GridUsers.Rows[iRow].Cells[0].Value));
            if (intUser2bDel < 1)
                return;
            //Does this User have some Projects? If yes, dont delete it!
            try
                {
                Db.DS.Tables["tblProject"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "SELECT * FROM Projects WHERE user_ID=" + intUser2bDel.ToString () + ";";
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    Db.DASS.Fill (Db.DS, "tblProject");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            //Check user's activity (Number of existing projects for this User)
            if (Db.DS.Tables["tblProject"].Rows.Count > 0)
                {
                MessageBox.Show ("Selected User has " + Db.DS.Tables["tblProject"].Rows.Count.ToString () + " Projects. You can not delete this User!", "eLib", MessageBoxButtons.OK);
                }
            //reload users table at buttom of this sub
            else
                {
                DialogResult myansw = (DialogResult) MessageBox.Show ("Delete selected 'USER' ?   Are you Sure ?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if ((int) myansw == (int) Constants.vbNo)
                    return;
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "DELETE FROM usrs WHERE ID=@id";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@id", intUser2bDel.ToString ());
                        int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            //Reload Page
            Db.DS.Tables["tblProject"].Clear ();
            frmUsers_Load (null, null);
            }
        private void ClearDB ()
            {
            //OPEN A CONNECTION for this SUB
            using (Db.CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                Db.CnnSS.Open ();
                Db.ClearRepositoryOfThisLibrary (1); //1: with confirms
                Db.CnnSS.Close ();
                Db.CnnSS.Dispose ();
                }
            RefreshGridUsers ();
            lblInfo.Text = "Database Cleared !";
            }
        private void Logout ()
            {
            Client.DeleteHtmlFiles (); // Remove possible existing Data related to other users (now, and also when logging-in via frmCNN as new user )
            Dispose ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            }

        private void lblQuit_Click (object sender, EventArgs e)
            {
            Db.CnnSS.Close ();
            Db.CnnSS.Dispose ();
            Db.CnnSS = null;
            Application.Exit ();
            Environment.Exit (0);
            }
        }
    }