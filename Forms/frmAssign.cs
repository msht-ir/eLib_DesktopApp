using eLib.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace eLib
    {
    public partial class frmAssign
        {
        public frmAssign ()
            {
            InitializeComponent ();
            }
        private void frmAssign_Load (object sender, EventArgs e)
            {
            //UserTypes: Admin | Guest | User
            Width = 1310;
            Height = 670;
            this.StartPosition = FormStartPosition.CenterScreen;
            Menu_ChangePassword.Enabled = true;
            lblStatusBar.Text = "";
            txtNote.Text = "";
            try
                {
                Assign.DoInitializeTheTables ();
                Menu1_ImR_Click (sender, e);
                //upcoming notes {JustGet|GetAndShow}
                Menu3_Active_Click (null, null);
                this.Show ();
                GetUpcomingNotes ();
                //ShowNotesForm ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void SetList5Status (string mode)
            {
            //Ref, Link, SubProjectNote, SubProjectNoteSearch, LinkNote, LinkNoteSearch, RefNote, RefNoteSearch
            lblRefs.Visible = false;
            lblLinks.Visible = false;
            lblSubProjectNotes.Visible = false;
            lblRefNotes.Visible = false;
            lblLinkNotes.Visible = false;
            Client.List5Mode = mode;
            switch (mode)
                {
                case "Ref":
                        {
                        List5.ContextMenuStrip = List1MenuStrip;
                        lblList5Status.Text = "Refs";
                        List55.DataSource = null;
                        lblRefs.Visible = true;
                        break;
                        }
                case "Link":
                        {
                        List5.ContextMenuStrip = List5MenuStrip;
                        lblList5Status.Text = "Links";
                        List2.DataSource = null;
                        List15.DataSource = null;
                        lblLinks.Visible = true;
                        break;
                        }
                case "SubProjectNote":
                        {
                        List5.ContextMenuStrip = List5Menu_JustExit;
                        lblList5Status.Text = "SubProject notes";
                        lblSubProjectNotes.Visible = true;
                        break;
                        }
                case "SubProjectNoteSearch":
                        {
                        List5.ContextMenuStrip = List5Menu_JustExit;
                        lblList5Status.Text = "SubProjects notes search";
                        lblSubProjectNotes.Visible = true;
                        break;
                        }
                case "LinkNote":
                        {
                        List5.ContextMenuStrip = List5Menu_JustExit;
                        lblList5Status.Text = "Links notes";
                        lblLinkNotes.Visible = true;
                        break;
                        }
                case "LinkNoteSearch":
                        {
                        List5.ContextMenuStrip = List5Menu_JustExit;
                        lblList5Status.Text = "Links notes search";
                        lblLinkNotes.Visible = true;
                        }
                    break;
                case "RefNote":
                        {
                        List5.ContextMenuStrip = List5Menu_JustExit;
                        lblList5Status.Text = "Ref notes";
                        lblRefNotes.Visible = true;
                        break;
                        }
                case "RefNoteSearch":
                        {
                        List5.ContextMenuStrip = List5Menu_JustExit;
                        lblList5Status.Text = "Ref notes search";
                        lblRefNotes.Visible = true;
                        break;
                        }
                default:
                        {
                        lblList5Status.Text = "-";
                        List5.ContextMenuStrip = List5Menu_JustExit;
                        break;
                        }
                }
            }
        private void frmAssign_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode.ToString ())
                {
                case "F2":
                        {
                        if (txtSearch.Focused != true)
                            {
                            txtSearch.Focus ();
                            if ((txtSearch.Text.Length < 1) | (txtSearch.Text.Trim () == "search"))
                                {
                                txtSearch.Text = "search";
                                txtSearch.SelectionStart = 0;
                                txtSearch.SelectionLength = 6;
                                }
                            else
                                {
                                txtSearch.SelectionStart = 0;
                                txtSearch.SelectionLength = txtSearch.Text.Length;
                                }
                            }
                        else
                            {
                            Menu3_Search.Focus ();
                            if ((Menu3_Search.Text.Length < 1) | (Menu3_Search.Text.Trim () == "command"))
                                {
                                Menu3_Search.Text = "command";
                                Menu3_Search.SelectionStart = 0;
                                Menu3_Search.SelectionLength = 7;
                                }
                            else
                                {
                                Menu3_Search.SelectionStart = 0;
                                Menu3_Search.SelectionLength = Menu3_Search.Text.Length;
                                }
                            }
                        break;
                        }
                case "F3":
                        {
                        List3.Focus ();
                        break;
                        }
                case "F4":
                        {
                        List4.Focus ();
                        break;
                        }
                case "F5":
                        {
                        List5.Focus ();
                        break;
                        }
                case "F6":
                        {
                        List6.Focus ();
                        break;
                        }
                case "F7":
                        {
                        List55.Focus ();
                        break;
                        }
                }
            }
        //Main Menu
        private void Menu_user_Click (object sender, EventArgs e)
            {
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            }
        private void Menu_ChangePassword_Click (object sender, EventArgs e)
            {
            Db.ChengePassword ();
            Menu_user_Click (sender, e);
            }
        private void Menu_About_eLib_Click (object sender, EventArgs e)
            {
            My.MyProject.Forms.frmAbout.ShowDialog ();
            }
        //Tools
        private void Menu_AssignFolder_Click (object sender, EventArgs e)
            {
            My.MyProject.Forms.frmFolderRefs.ShowDialog ();
            }
        private void Menu_Import_Click (object sender, EventArgs e)
            {
            WindowState = FormWindowState.Minimized;
            Ref.ImportStatus = Ref.ImportStatus | 253; //set bit2 = 0 :flag for NewImport (not Edit Ref)
            My.MyProject.Forms.frmImportRefs.ShowDialog ();
            WindowState = FormWindowState.Normal;
            }
        private void Menu_CreateWord_Click (object sender, EventArgs e)
            {
            //Create New Document as Ref
            Db.CreateNewRef (".docx");
            }
        private void Menu_CreatePowepoint_Click (object sender, EventArgs e)
            {
            //Create New Powerpoint as Ref
            Db.CreateNewRef (".pptx");
            }
        private void Menu_CreateTextFile_Click (object sender, EventArgs e)
            {
            //Create New textfile as Ref
            Db.CreateNewRef (".txt");
            }
        private void Menu_CreateExcel_Click (object sender, EventArgs e)
            {
            //Create New Excel spreadsheet as Ref
            Db.CreateNewRef (".xlsx");
            }
        private void Menu_Scan_Click (object sender, EventArgs e)
            {
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            My.MyProject.Forms.frmScan.ShowDialog ();
            this.WindowState = FormWindowState.Normal;
            }
        private void Menu_UpcomingNotes_Click (object sender, EventArgs e)
            {
            //Upcoming Notes
            List6.DataSource = null;
            List5.DataSource = null;
            List4.DataSource = null;
            GetUpcomingNotes ();
            ShowNotesForm ();
            GetUpcomingNotes ();
            }
        private void Menu_MindMapx_Click (object sender, EventArgs e)
            {
            var frmMindmap = new frmNoteNetEditor ();
            frmMindmap.ShowDialog ();
            }
        private void Menu_eLib4Dummies_Click (object sender, EventArgs e)
            {
            ChangeInterface ();
            }
        private void lbl_Interface_Click (object sender, EventArgs e)
            {
            ChangeInterface ();
            }
        private void ShowNotesForm ()
            {
            if (Db.DS.Tables ["tblNotesCount"].Rows.Count != 0)
                {
                var frmUpcomingNT = new frmUpcomingNotes ();
                frmUpcomingNT.ShowDialog ();
                List4_Click (null, null);
                if (Client.DialogRequestParams == 16) //bit5: 00010000: 0:cancel 1:ok
                    {
                    Menu3_All_Click (null, null);
                    List3.SelectedValue = Project.Id;
                    List3_Click (null, null);
                    List4.SelectedValue = SubProject.Id;
                    List4_Click (null, null);
                    List6.SelectedValue = Note.Id;
                    List6_Click (null, null);
                    List5.Focus ();
                    }
                else
                    {
                    //Menu3_Active_Click ();
                    }
                }
            }
        private void Menu_Augustusmate_Click (object sender, EventArgs e)
            {
            Augustusmate ();
            }
        private void Augustusmate ()
            {
            if (List3.SelectedIndex != -1)
                {
                Client.DialogRequestParams = 8; //BIT4(=8): 0:new, 1:Edit
                Project.Id = (int) List3.SelectedValue;
                Form AugustusLib = new frmAugustusLib ();
                AugustusLib.ShowDialog ();
                }
            else
                {
                //no project is selected from list3
                DialogResult myansw = MessageBox.Show ("Data from Excel?", "eLib.Augustusmate:", MessageBoxButtons.YesNoCancel);
                switch (myansw)
                    {
                    case DialogResult.Yes:
                            {
                            //ok, read from Excel
                            Client.DialogRequestParams = 0;
                            Form frmArrow = new Arrows ();
                            frmArrow.ShowDialog ();
                            break;
                            }
                    case DialogResult.No:
                            {
                            //so, a project is needed
                            Client.DialogRequestParams = 1;
                            //bit1:2^0:1:get Project; bit2:2^1:2:get SubProject; bit1,2:1+2:3:get Project or SubProject
                            My.MyProject.Forms.frmChooseProject.ShowDialog ();
                            if (Client.DialogRequestParams == 64) //bit7:2^6:64: a Project is selected from dialog
                                {
                                Client.DialogRequestParams = 8; //BIT4(=8): 0:new, 1:Edit
                                Form AugustusLib = new frmAugustusLib ();
                                AugustusLib.ShowDialog ();
                                }
                            break;
                            }
                    case DialogResult.Cancel: //cancel!
                            {
                            break;
                            }
                    }
                }
            }
        private void GetUpcomingNotes ()
            {
            Note.GetSNotesFromDB ("all");
            //all leds off
            int clrR = 244;
            int clrG = 244;
            int clrB = 244;
            lblDay0.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            lblDay1.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            lblDay2.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            lblDay3.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            lblDay4.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            lblDay5.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            lblDay6.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            //some leds on
            clrR = 220;
            clrG = 220;
            clrB = 220;
            //MessageBox.Show ("Today: " + User.NotesDay0.ToString() + "\n +1: " + User.NotesDay1.ToString () + "\n +2: " + User.NotesDay2.ToString () + "\n +3: " + User.NotesDay3.ToString () + "\n +4: " + User.NotesDay4.ToString () + "\n +5: " + User.NotesDay5.ToString () + "\n +6: " + User.NotesDay6.ToString ());
            if (User.NotesDay0 > 0)
                lblDay0.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay1 > 0)
                lblDay1.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay2 > 0)
                lblDay2.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay3 > 0)
                lblDay3.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay4 > 0)
                lblDay4.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay5 > 0)
                lblDay5.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay6 > 0)
                lblDay6.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            string Datum = DateTime.Now.ToString ("yyyy - MM - dd  .  HH : mm");
            Text = Report.Caption + "  \\  " + User.Name + "  \\  login " + Datum;
            }
        private void lblDay0_Click (object sender, EventArgs e)
            {
            //Upcoming Notes
            GetUpcomingNotes ();
            List6.DataSource = null;
            List5.DataSource = null;
            List4.DataSource = null;
            ShowNotesForm ();
            GetUpcomingNotes ();
            }
        private void lblDay1_Click (object sender, EventArgs e)
            {
            //Tommorow (Day+1) Notes
            Note.DateTime = DateTime.Now.AddDays (1).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            List6.DataSource = null;
            List5.DataSource = null;
            List4.DataSource = null;
            ShowNotesForm ();
            GetUpcomingNotes ();
            }
        private void lblDay2_Click (object sender, EventArgs e)
            {
            //(Today+2) Notes
            Note.DateTime = DateTime.Now.AddDays (2).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            List6.DataSource = null;
            List5.DataSource = null;
            List4.DataSource = null;
            ShowNotesForm ();
            GetUpcomingNotes ();
            }
        private void lblDay3_Click (object sender, EventArgs e)
            {
            //(Today+3) Notes
            Note.DateTime = DateTime.Now.AddDays (3).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            List6.DataSource = null;
            List5.DataSource = null;
            List4.DataSource = null;
            ShowNotesForm ();
            GetUpcomingNotes ();
            }
        private void lblDay4_Click (object sender, EventArgs e)
            {
            //(Today+4) Notes
            Note.DateTime = DateTime.Now.AddDays (4).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            List6.DataSource = null;
            List5.DataSource = null;
            List4.DataSource = null;
            ShowNotesForm ();
            GetUpcomingNotes ();
            }
        private void lblDay5_Click (object sender, EventArgs e)
            {
            //(Today+5) Notes
            Note.DateTime = DateTime.Now.AddDays (5).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            List6.DataSource = null;
            List5.DataSource = null;
            List4.DataSource = null;
            ShowNotesForm ();
            GetUpcomingNotes ();
            }
        private void lblDay6_Click (object sender, EventArgs e)
            {
            //(Today+6) Notes
            Note.DateTime = DateTime.Now.AddDays (6).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            List6.DataSource = null;
            List5.DataSource = null;
            List4.DataSource = null;
            ShowNotesForm ();
            GetUpcomingNotes ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Menu_user_Click (null, null);
            }
        //Theme
        private void Menu_Boarders_Click (object sender, EventArgs e)
            {
            return;
            //Menu item is hdden
            int clrR = 0;
            int clrG = 0;
            int clrB = 0;
            if (Menu_Boarders.Checked == true)
                {
                clrR = 245;
                clrG = 245;
                clrB = 245;
                lblExit.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
                lblList5ShowRefs.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
                //List2.BorderStyle = BorderStyle.None;
                //List3.BorderStyle = BorderStyle.None;
                //List4.BorderStyle = BorderStyle.None;
                //List5.BorderStyle = BorderStyle.None;
                //List6.BorderStyle = BorderStyle.None;
                //List15.BorderStyle = BorderStyle.None;
                //List55.BorderStyle = BorderStyle.None;
                //List35.BorderStyle = BorderStyle.None;
                Menu_Boarders.Checked = false;
                }
            else
                {
                clrR = 230;
                clrG = 230;
                clrB = 230;
                lblExit.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
                lblList5ShowRefs.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
                //List2.BorderStyle = BorderStyle.FixedSingle;
                //List3.BorderStyle = BorderStyle.FixedSingle;
                //List4.BorderStyle = BorderStyle.FixedSingle;
                //List5.BorderStyle = BorderStyle.FixedSingle;
                //List6.BorderStyle = BorderStyle.FixedSingle;
                //List15.BorderStyle = BorderStyle.FixedSingle;
                //List55.BorderStyle = BorderStyle.FixedSingle;
                //List35.BorderStyle = BorderStyle.FixedSingle;
                Menu_Boarders.Checked = true;
                }
            }
        private void ApplyTheme (int r, int g, int b)
            {
            //this method curently is not used
            List5.BackColor = System.Drawing.Color.FromArgb (r, g, b);
            List2.BackColor = System.Drawing.Color.FromArgb (r, g, b);
            List3.BackColor = System.Drawing.Color.FromArgb (r, g, b);
            List4.BackColor = System.Drawing.Color.FromArgb (r, g, b);
            List5.BackColor = System.Drawing.Color.FromArgb (r, g, b);
            List6.BackColor = System.Drawing.Color.FromArgb (r, g, b);
            List15.BackColor = System.Drawing.Color.FromArgb (r, g, b);
            List55.BackColor = System.Drawing.Color.FromArgb (r, g, b);
            }
        //txtSearch
        private void lblSearch_Click (object sender, EventArgs e)
            {
            //CUT-and-PASTE
            string strTempText = "";
            //Step 1
            if (!string.IsNullOrEmpty (Strings.Trim (txtSearch.Text)))
                {
                strTempText = Strings.Trim (txtSearch.Text);
                }
            else
                {
                strTempText = "";
                }
            //Step 2
            try
                {
                if (My.MyProject.Computer.Clipboard.ContainsText ())
                    txtSearch.Text = My.MyProject.Computer.Clipboard.GetText ();
                }
            catch (Exception ex)
                {
                My.MyProject.Computer.Clipboard.SetText ("");
                txtSearch.Text = "";
                }
            //Step 3
            if (!string.IsNullOrEmpty (Strings.Trim (strTempText)))
                {
                My.MyProject.Computer.Clipboard.Clear ();
                My.MyProject.Computer.Clipboard.SetText (strTempText);
                }
            lblSearch.Focus ();
            txtSearch.SelectionStart = Strings.Len (txtSearch.Text);
            //Do the Search:
            if (!string.IsNullOrEmpty (txtSearch.Text))
                txtSearch.Text = txtSearch.Text + " ";
            }
        private void lblSearch_DoubleClick (object sender, EventArgs e)
            {
            if (!string.IsNullOrEmpty (Strings.Trim (txtSearch.Text)))
                {
                try
                    {
                    My.MyProject.Computer.Clipboard.Clear ();
                    My.MyProject.Computer.Clipboard.SetText (Strings.Trim (txtSearch.Text)); // 1 Copy to ClipBoard from textBox
                    txtSearch.Text = "";
                    lblSearch.Focus ();
                    }
                catch (Exception ex)
                    {
                    }
                }
            }
        private void txtSearchP_Click (object sender, EventArgs e)
            {
            if (txtSearchP.Checked == true)
                txtSearchP.Checked = false;
            else
                txtSearchP.Checked = true;
            txtSearch.Focus ();
            }
        private void txtSearchB_Click (object sender, EventArgs e)
            {
            if (txtSearchB.Checked == true)
                txtSearchB.Checked = false;
            else
                txtSearchB.Checked = true;
            txtSearch.Focus ();
            }
        private void txtSearchM_Click (object sender, EventArgs e)
            {
            if (txtSearchM.Checked == true)
                txtSearchM.Checked = false;
            else
                txtSearchM.Checked = true;
            txtSearch.Focus ();
            }
        private void txtSearchL_Click (object sender, EventArgs e)
            {
            if (txtSearchL.Checked == true)
                txtSearchL.Checked = false;
            else
                txtSearchL.Checked = true;
            txtSearch.Focus ();
            }
        private void txtSearchAll_Click (object sender, EventArgs e)
            {
            txtSearchP.Checked = true;
            txtSearchB.Checked = true;
            txtSearchM.Checked = true;
            txtSearchL.Checked = true;
            txtSearch.Focus ();
            }
        private void txtSearchRevrs_Click (object sender, EventArgs e)
            {
            if (txtSearchP.Checked == true)
                txtSearchP.Checked = false;
            else
                txtSearchP.Checked = true;
            if (txtSearchB.Checked == true)
                txtSearchB.Checked = false;
            else
                txtSearchB.Checked = true;
            if (txtSearchM.Checked == true)
                txtSearchM.Checked = false;
            else
                txtSearchM.Checked = true;
            if (txtSearchL.Checked == true)
                txtSearchL.Checked = false;
            else
                txtSearchL.Checked = true;
            txtSearch.Focus ();
            }
        private void txtSearch_DoubleClick (object sender, EventArgs e)
            {
            if (string.IsNullOrEmpty (Strings.Trim (txtSearch.Text)))
                {
                // Paste
                if (My.MyProject.Computer.Clipboard.ContainsText ())
                    txtSearch.Text = My.MyProject.Computer.Clipboard.GetText ();
                }
            else
                {
                // keep empty
                txtSearch.Text = "";
                }
            }
        private void txtSearch_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 38: //up
                case (Keys) 40: //down
                        {
                        List5.Focus ();
                        break;
                        }
                case (Keys) 13: //enter
                        {
                        e.SuppressKeyPress = true;
                        Db.DS.Tables ["tblRefs"].Clear ();
                        Db.DS.Tables ["tblAssignments"].Clear ();
                        if (string.IsNullOrEmpty (Strings.Trim (txtSearch.Text)))
                            {
                            txtSearch.Text = "";
                            }
                        else
                            {
                            //there are some keys to search
                            string searchString = Strings.Trim (txtSearch.Text);
                            FindRefs (searchString);
                            List5.SelectedValue = -1;
                            Db.DS.Tables ["tblAssignments"].Clear ();
                            Db.DS.Tables ["tblRNotes"].Clear ();
                            txtSearch.Focus ();
                            //txtSearch.Text = txtSearch.Text.Trim ();
                            txtSearch.SelectionStart = 0;
                            txtSearch.SelectionLength = txtSearch.TextLength;
                            }

                        break;
                        }
                case (Keys) 27: //escape
                        {
                        txtSearch.Text = "";
                        List5.DataSource = null;
                        List2.DataSource = null;
                        List15.DataSource = null;
                        break;
                        }
                }
            }
        private void txtSearch_TextChanged (object sender, EventArgs e)
            {
            switch (txtSearch.Text.ToLower ())
                {
                case "-":
                        {
                        txtSearch.Text = "-command";
                        txtSearch.SelectionStart = 1;
                        txtSearch.SelectionLength = 7;
                        break;
                        }
                case "-quit":
                case "-exit":
                        {
                        txtSearch.Text = "-exit? yes / no";
                        txtSearch.SelectionStart = 7;
                        txtSearch.SelectionLength = 8;
                        break;
                        }
                case "-exit? y":
                        {
                        Menu_Exit_Click (null, null);
                        txtSearch.Text = "";
                        break;
                        }
                case "-exit? n":
                        {
                        txtSearch.Text = "";
                        break;
                        }
                case "-user":
                case "-log":
                        {
                        Menu_user_Click (null, null);
                        Menu3_Search.Text = "";
                        break;
                        }
                case "-imp":
                        {
                        Menu_Import_Click (null, null);
                        txtSearch.Text = "";
                        break;
                        }
                case "-dir":
                case "-folder":
                        {
                        Menu_AssignFolder_Click (null, null);
                        txtSearch.Text = "";
                        break;
                        }
                case "-scan":
                        {
                        Menu_Scan_Click (null, null);
                        txtSearch.Text = "";
                        break;
                        }
                case "-about":
                case "-info":
                        {
                        Menu_About_eLib_Click (null, null);
                        txtSearch.Text = "";
                        break;
                        }
                case "-create":
                        {
                        txtSearch.Text = "-Create? Word  Excel  PowerPoint  Text";
                        txtSearch.SelectionStart = 9;
                        txtSearch.SelectionLength = 29;
                        break;
                        }
                case "-create? w":
                        {
                        Menu_CreateWord_Click (null, null);
                        txtSearch.Text = "";
                        break;
                        }
                case "-create? e":
                        {
                        Menu_CreateExcel_Click (null, null);
                        txtSearch.Text = "";
                        break;
                        }
                case "-create? p":
                        {
                        Menu_CreatePowepoint_Click (null, null);
                        txtSearch.Text = "";
                        break;
                        }
                case "-create? t":
                        {
                        Menu_CreateTextFile_Click (null, null);
                        txtSearch.Text = "";
                        break;
                        }
                }
            }
        private void FindRefs (string searchString)
            {
            txtSearch.Focus ();
            Ref.TypeCode = 0;
            if (txtSearchP.Checked == true)
                Ref.TypeCode = Ref.TypeCode | 0x1; // 0b0001 for papers
            if (txtSearchB.Checked == true)
                Ref.TypeCode = Ref.TypeCode | 0x2; // 0b0010 for books
            if (txtSearchM.Checked == true)
                Ref.TypeCode = Ref.TypeCode | 0x4; // 0b0100 for manuals
            if (txtSearchL.Checked == true)
                Ref.TypeCode = Ref.TypeCode | 0x8; // 0b1000 for lectures
            if (Ref.TypeCode == 0)
                {
                MessageBox.Show ("Select Ref type(s) for Search", "eLib", MessageBoxButtons.OK);
                return;
                }
            Assign.DoSearchRefs (searchString);
            List5.DataSource = Db.DS.Tables ["tblRefs"];
            List5.DisplayMember = "PaperName";
            List5.ValueMember = "Papers.ID";
            SetList5Status ("Ref");
            //nrows? :if no result => reduce from keys
            if (Db.DS.Tables ["tblRefs"].Rows.Count == 0)
                {
                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
                if (Strings.Right (txtSearch.Text, 1) != " ")
                    txtSearch.Text = txtSearch.Text + " .";
                txtSearch.SelectionStart = Strings.Len (txtSearch.Text);
                }
            Db.DS.Tables ["tblAssignments"].Clear ();
            Db.DS.Tables ["tblRNotes"].Clear ();
            }
        //List1-List5
        private void List5_DragEnter (object sender, DragEventArgs e)
            {
            //if a subProject from List4 is selected 
            //Import and link to the SubProject in List4 
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void List5_DragDrop (object sender, DragEventArgs e)
            {
            if (List4.SelectedIndex == -1)
                {
                return;
                }
            //SubProjectNote, SubProjectNoteSearch, Link, LinkNote, LinkNoteSearch, Ref, RefNote, RefNoteSearch
            switch (Client.List5Mode)
                {
                case "Ref":
                        {
                        Ref.ImportStatus = 2; //flag for NewImport from Main wo link
                        break;
                        }
                case "Link":
                        {
                        Ref.ImportStatus = 6; //flag for NewImport from Main + with link
                        break;
                        }
                default:
                        {
                        return;
                        }
                }
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            eLibFile.strFilex = strFiles [0];
            e.Effect = DragDropEffects.None;
            SubProject.Id = (int) List4.SelectedValue;
            SubProject.Name = List4.Text;
            WindowState = FormWindowState.Minimized;
            My.MyProject.Forms.frmImportRefs.ShowDialog ();
            WindowState = FormWindowState.Normal;
            //refresh list5:
            int inttmplist4value = (int) List4.SelectedValue;
            List3_Click (null, null);
            List4.SelectedValue = inttmplist4value;
            List4_Click (null, null);
            }
        private void List5_KeyDown (object sender, KeyEventArgs e)
            {
            //SubProjectNote, SubProjectNoteSearch, Link, LinkNote, LinkNoteSearch, Ref, RefNote, RefNoteSearch
            switch (Client.List5Mode)
                {
                case ("SubProjectNote"):
                case ("SubProjectNoteSearch"):
                    switch (e.KeyCode)
                        {
                        case (Keys) 13: //enter
                        case (Keys) 39: //right
                                {
                                e.SuppressKeyPress = true;
                                List5_Click (null, null);
                                break;
                                }
                        case (Keys) 27: //excape
                        case (Keys) 37: //left
                                {
                                e.SuppressKeyPress = true;
                                List5.DataSource = null;
                                List6.Focus ();
                                break;
                                }
                        }
                    break;
                case ("Link"):
                        {
                        switch (e.KeyCode)
                            {
                            case (Keys) 39: //right
                                    {
                                    e.SuppressKeyPress = true;
                                    List55.Focus ();
                                    break;
                                    }
                            case (Keys) 37: //left
                                    {
                                    e.SuppressKeyPress = true;
                                    List5.DataSource = null;
                                    List4.Focus ();
                                    break;
                                    }
                            }
                        }
                    break;
                case ("LinkNote"):
                case ("LinkNoteSearch"):
                        {
                        switch (e.KeyCode)
                            {
                            case (Keys) 13: //enter
                            case (Keys) 39: //right
                                    {
                                    e.SuppressKeyPress = true;
                                    List5_Click (null, null);
                                    break;
                                    }
                            case (Keys) 27: //excape
                            case (Keys) 37: //left
                                    {
                                    e.SuppressKeyPress = true;
                                    List5.DataSource = null;
                                    List4.Focus ();
                                    break;
                                    }
                            }
                        break;
                        }
                case "Ref":
                        {
                        switch (e.KeyCode)
                            {
                            case (Keys) 13:
                                    {
                                    Menu1_Read_Click (sender, e);
                                    e.SuppressKeyPress = true;
                                    break;
                                    }
                            case (Keys) 37:
                                    {
                                    txtSearch.Focus ();
                                    txtSearch.SelectionStart = 0;
                                    txtSearch.SelectionLength = txtSearch.TextLength;
                                    e.SuppressKeyPress = true;
                                    break;
                                    }
                            case (Keys) 39:
                                    {
                                    Client.List5Mode = "Ref";
                                    List5_Click (null, null);
                                    List2.Focus ();
                                    e.SuppressKeyPress = true;
                                    break;
                                    }
                            }
                        break;
                        }
                case ("RefNote"):
                case ("RefNoteSearch"):
                        {
                        switch (e.KeyCode)
                            {
                            case (Keys) 13: //enter
                            case (Keys) 39: //right
                                    {
                                    List5_Click (sender, e);
                                    e.SuppressKeyPress = true;
                                    break;
                                    }
                            case (Keys) 37: //left
                                    {
                                    e.SuppressKeyPress = true;
                                    List5.DataSource = null;
                                    List15.Focus ();
                                    break;
                                    }
                            }
                        break;
                        }
                default:
                        {
                        switch (e.KeyCode)
                            {
                            case (Keys) 13:
                                    {
                                    List5_DoubleClick (sender, e);
                                    e.SuppressKeyPress = true;
                                    break;
                                    }
                            case (Keys) 37:
                                    {
                                    List5.DataSource = null;
                                    List6.DataSource = null;
                                    List4.Focus (); // <-
                                    e.SuppressKeyPress = true;
                                    break;
                                    }
                            }
                        break;
                        }
                }
            }
        private void List5_Click (object sender, EventArgs e)
            {
            if ((List5.Items.Count == 0) || (List5.SelectedIndex == -1))
                return;
            switch (Client.List5Mode) //SubProjectNote, SubProjectNoteSearch, Link, LinkNote, LinkNoteSearch, Ref, RefNote, RefNoteSearch
                {
                case "Ref":
                        {
                        Ref.Id = Conversions.ToInteger (List5.SelectedValue);
                        Assign.GetRLinks (Ref.Id);
                        List2.DataSource = Db.DS.Tables ["tblAssignments"];
                        List2.DisplayMember = "SubProjectName";
                        List2.ValueMember = "SubProject_ID";
                        List2.SelectedValue = -1;
                        Assign.GetNotes (Ref.Id, 3);
                        List15.DataSource = Db.DS.Tables ["tblRNotes"];
                        List15.DisplayMember = "NoteDatum";
                        List15.ValueMember = "ID";//Notes.ID
                        List15.SelectedIndex = -1;
                        Client.List15Mode = "RefNote";
                        Note.Type = "RefNote";
                        try
                            {
                            Ref.TypeText = "";
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblRefs"].Rows [List5.SelectedIndex] [2], true, false)))
                                Ref.TypeText = Ref.TypeText + "Paper  ";
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblRefs"].Rows [List5.SelectedIndex] [3], true, false)))
                                Ref.TypeText = Ref.TypeText + "Book  ";
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblRefs"].Rows [List5.SelectedIndex] [4], true, false)))
                                Ref.TypeText = Ref.TypeText + "Manual  ";
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblRefs"].Rows [List5.SelectedIndex] [5], true, false)))
                                Ref.TypeText = Ref.TypeText + "Lecture  "; //lblRefStatus1.Text = Ref.TypeText;
                            }
                        catch (Exception ex)
                            {
                            //MessageBox.Show (ex.ToString ());
                            }
                        List55.DataSource = null;
                        txtNote.Text = "";
                        txtNote.Enabled = false;
                        lblStatusBar.Text = "";
                        break;
                        }
                case "Link":
                        {
                        try
                            {
                            Note.Type = "LinkNote";
                            Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [7]); // 7:Link.ID
                            Assign.GetNotes (Link.Id, 2);
                            List55.DataSource = Db.DS.Tables ["tblLNotes"];
                            List55.DisplayMember = "NoteDatum";
                            List55.ValueMember = "Notes.ID";
                            List55.SelectedIndex = -1;
                            Client.List55Mode = "LinkNote";
                            Ref.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [0]);
                            if (Ref.Id < 1)
                                {
                                lblStatusBar.Text = List5.Text;
                                return;
                                }
                            int Refid = List5.SelectedIndex;
                            Ref.TypeText = "";
                            string lblCaption = "";
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [Refid] [2], true, false)))
                                {
                                lblCaption = lblCaption + "Paper ";
                                Ref.TypeText = Ref.TypeText + "Paper  ";
                                }
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [Refid] [3], true, false)))
                                {
                                lblCaption = lblCaption + "Book ";
                                Ref.TypeText = Ref.TypeText + "Book  ";
                                }
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [Refid] [4], true, false)))
                                {
                                lblCaption = lblCaption + "Manual ";
                                Ref.TypeText = Ref.TypeText + "Manual  ";
                                }
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [Refid] [5], true, false)))
                                {
                                lblCaption = lblCaption + "Lecture ";
                                Ref.TypeText = Ref.TypeText + "Lecture  ";
                                }
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [Refid] [8], true, false)))
                                lblCaption = lblCaption + "Imp1 ";
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [Refid] [9], true, false)))
                                lblCaption = lblCaption + "Imp2 ";
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [Refid] [10], true, false)))
                                lblCaption = lblCaption + "Imp3 ";
                            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [Refid] [11], true, false)))
                                lblCaption = lblCaption + "ImR ";
                            lblStatusBar.Text = lblCaption + " / " + List5.Text;
                            List2.DataSource = null;
                            List15.DataSource = null;
                            txtNote.Text = "";
                            }
                        catch (Exception ex)
                            {
                            //MessageBox.Show (ex.ToString ());
                            }
                        break;
                        }
                //Ref, Link, SubProjectNote, SubProjectNoteSearch, LinkNote, LinkNoteSearch, RefNote, RefNoteSearch
                case "SubProjectNote":
                        {
                        Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblSNotes"].Rows [List5.SelectedIndex] [2]);
                        Note.Rtl = Conversions.ToBoolean (Db.DS.Tables ["tblSNotes"].Rows [List5.SelectedIndex] [5]);
                        ShowNoteInTextBox ();
                        break;
                        }
                case "SubProjectNoteSearch":
                        {
                        Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblNotesCount"].Rows [List5.SelectedIndex] [3]);
                        Note.Rtl = false;
                        ShowNoteInTextBox ();
                        break;
                        }
                case "LinkNote":
                case "LinkNoteSearch":
                        {
                        Note.Type = "LinkNote";
                        Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblLNotes"].Rows [List5.SelectedIndex] [2]);
                        Note.Rtl = Conversions.ToBoolean (Db.DS.Tables ["tblLNotes"].Rows [List5.SelectedIndex] [5]);
                        ShowNoteInTextBox ();
                        break;
                        }
                case "RefNote":
                case "RefNoteSearch":
                        {
                        Note.Type = "LinkNoteSearch";
                        Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblRNotes"].Rows [List5.SelectedIndex] [2]);
                        Note.Rtl = Conversions.ToBoolean (Db.DS.Tables ["tblRNotes"].Rows [List5.SelectedIndex] [5]);
                        ShowNoteInTextBox ();
                        break;
                        }
                }
            }
        private void List5_DoubleClick (object sender, EventArgs e)
            {
            //SubProjectNote, SubProjectNoteSearch, Link, LinkNote, LinkNoteSearch, Ref, RefNote, RefNoteSearch
            switch (Client.List5Mode)
                {
                case "Ref":
                        {
                        if (Menu1_Read.Checked == true)
                            {
                            Menu1_Read_Click (sender, e);
                            return;
                            }
                        if (Menu1_Assign.Checked == true)
                            {
                            Menu1_Assign_Click (sender, e);
                            return;
                            }
                        if (Menu1_AssignTo.Checked == true)
                            {
                            Menu1_AssignTo_Click (sender, e);
                            return;
                            }
                        if (Menu1_QRCode.Checked == true)
                            {
                            Menu1_QRCode_Click (sender, e);
                            return;
                            }
                        if (Menu1_GoogleScholar.Checked == true)
                            {
                            Menu1_GoogleScholar_Click (sender, e);
                            return;
                            }
                        if (Menu1_Delete.Checked == true)
                            {
                            Menu1_Delete_Click (sender, e);
                            return;
                            }
                        break;
                        }
                case "Link":
                        {
                        if (Menu5_Read.Checked == true)
                            {
                            Menu5_Read_Click (sender, e);
                            return;
                            }
                        if (Menu5_Read.Checked == true)
                            {
                            Menu5_Read_Click (sender, e);
                            return;
                            }
                        if (Menu5_Replace.Checked == true)
                            {
                            Menu5_Replace_Click (sender, e);
                            return;
                            }
                        if (Menu5_AddTo.Checked == true)
                            {
                            Menu5_AddTo_Click (sender, e);
                            return;
                            }
                        if (Menu5_Delete.Checked == true)
                            {
                            Menu5_Delete_Click (sender, e);
                            return;
                            }
                        if (Menu5_RefAttributes.Checked == true)
                            {
                            Menu5_RefAttributes_Click (sender, e);
                            return;
                            }
                        if (Menu5_ShowAbove.Checked == true)
                            {
                            Menu5_ShowAbove_Click (sender, e);
                            return;
                            }
                        if (Menu5_GoogleScholar.Checked == true)
                            {
                            Menu5_GoogleScholar_Click (sender, e);
                            return;
                            }
                        if (Menu5_QRCode.Checked == true)
                            {
                            Menu5_QRCode_Click (sender, e);
                            return;
                            }
                        if (Menu5_Collect.Checked == true)
                            {
                            Menu5_Collect_Click (sender, e);
                            return;
                            }
                        break;
                        }
                default:
                        {
                        return;
                        }
                }
            }
        private void lblList5ShowRefs_Click (object sender, EventArgs e)
            {
            try
                {
                List5.DataSource = Db.DS.Tables ["tblRefs"];
                List5.DisplayMember = "PaperName";
                List5.ValueMember = "Papers.ID";
                SetList5Status ("Ref");
                List5_Click (null, null);
                }
            catch
                {
                }
            }
        //Menu1
        private void Menu1_CheckMarkSet (int i)
            {
            Menu1_Read.Checked = false;
            Menu1_Assign.Checked = false;
            Menu1_AssignTo.Checked = false;
            Menu1_QRCode.Checked = false;
            Menu1_GoogleScholar.Checked = false;
            Menu1_Delete.Checked = false;
            switch (i)
                {
                case 1:
                        {
                        Menu1_Read.Checked = true;
                        break;
                        }
                case 2:
                        {
                        Menu1_Assign.Checked = true;
                        break;
                        }
                case 3:
                        {
                        Menu1_AssignTo.Checked = true;
                        break;
                        }
                case 4:
                        {
                        Menu1_QRCode.Checked = true;
                        break;
                        }
                case 5:
                        {
                        Menu1_GoogleScholar.Checked = true;
                        break;
                        }
                case 6:
                        {
                        Menu1_Delete.Checked = true;
                        break;
                        }
                }
            }
        private void Menu1_Read_Click (object sender, EventArgs e)
            {
            Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex >= 0)
                {
                Ref.Title = Strings.Trim (List5.Text);
                if (!string.IsNullOrEmpty (Ref.Title))
                    My.MyProject.Forms.frmReadRef.ShowDialog ();
                }
            }
        private void Menu1_Lock_Click (object sender, EventArgs e)
            {
            if (Menu1_Lock.Checked == true)
                {
                Menu1_Lock.Checked = false;
                Menu1_CheckMarkSet (1);
                }
            else
                {
                Menu1_Lock.Checked = true;
                }
            }
        private void Menu1_Assign_Click (object sender, EventArgs e)
            {
            if (Menu1_Lock.Checked == true)
                Menu1_CheckMarkSet (2);
            else
                Menu1_CheckMarkSet (1);
            Ref.Id = Conversions.ToInteger (List5.SelectedValue);
            SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
            if (Ref.Id < 1 | SubProject.Id < 1)
                return;
            bool i = Assign.DoLinkRef2SubProject (Ref.Id, SubProject.Id);
            if (i == true)
                {
                Client.List5Mode = "Ref";
                List5_Click (null, null); // refresh list2
                List4_Click (null, null); // refresh list5
                }
            else
                {
                MessageBox.Show ("Error Assigning Ref to SubProject!", "eLib", MessageBoxButtons.OK);
                }
            }
        private void Menu1_AssignTo_Click (object sender, EventArgs e)
            {
            if (Menu1_Lock.Checked == true)
                Menu1_CheckMarkSet (3);
            else
                Menu1_CheckMarkSet (1);
            Ref.Id = Conversions.ToInteger (List5.SelectedValue);
            if (Ref.Id < 1)
                return;
            Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            if (Client.DialogRequestParams == 32) //1: A SubProjects is selected from dialog //intProd=id of the selected SubProject
                {
                if (Ref.Id < 1 | SubProject.Id < 1)
                    return;
                bool i = Assign.DoLinkRef2SubProject (Ref.Id, SubProject.Id);
                if (i == true)
                    {
                    Client.List5Mode = "Ref";
                    List5_Click (null, null); // refresh list2
                    List4_Click (null, null); // refresh list5
                    }
                else
                    {
                    MessageBox.Show ("Error Assigning Ref to SubProject!", "eLib", MessageBoxButtons.OK);
                    }
                }
            }
        private void Menu1_GetList_Click (object sender, EventArgs e)
            {
            Assign.GetListOfRefs ();
            List5.DataSource = Db.DS.Tables ["tblRefs"];
            List5.DisplayMember = "Papername";
            List5.ValueMember = "Papers.ID";
            }
        private void Menu1_Copy_Click (object sender, EventArgs e)
            {
            if (List5.SelectedIndex >= 0)
                {
                My.MyProject.Computer.Clipboard.SetText (List5.Text);
                }
            }
        private void Menu1_QRCode_Click (object sender, EventArgs e)
            {
            //check if tbl.Settings allows QRCODEGen ?
            if (Menu1_Lock.Checked == true)
                Menu1_CheckMarkSet (4);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex >= 0)
                Client.GenerateQRCode (List5.Text);
            }
        private void Menu1_GoogleScholar_Click (object sender, EventArgs e)
            {
            if (Menu1_Lock.Checked == true)
                Menu1_CheckMarkSet (5);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex >= 0)
                {
                string strSearchScholar = List5.Text;
                Client.SearchScholar (strSearchScholar);
                }
            }
        private void Menu1_Imp1_Click (object sender, EventArgs e)
            {
            Assign.GetImportantRefs ("Imp1");
            List5.DataSource = Db.DS.Tables ["tblRefs"];
            List5.DisplayMember = "PaperName";
            List5.ValueMember = "Papers.ID";
            txtSearch.Text = "";
            List2.DataSource = null;
            List15.DataSource = null;
            Client.List5Mode = "Ref";
            List5.Focus ();
            }
        private void Menu1_Imp2_Click (object sender, EventArgs e)
            {
            Assign.GetImportantRefs ("Imp2");
            List5.DataSource = Db.DS.Tables ["tblRefs"];
            List5.DisplayMember = "PaperName";
            List5.ValueMember = "Papers.ID";
            txtSearch.Text = "";
            List2.DataSource = null;
            List15.DataSource = null;
            Client.List5Mode = "Ref";
            List5.Focus ();
            }
        private void Menu1_Imp3_Click (object sender, EventArgs e)
            {
            Assign.GetImportantRefs ("Imp3");
            List5.DataSource = Db.DS.Tables ["tblRefs"];
            List5.DisplayMember = "PaperName";
            List5.ValueMember = "Papers.ID";
            txtSearch.Text = "";
            List2.DataSource = null;
            List15.DataSource = null;
            Client.List5Mode = "Ref";
            List5.Focus ();
            }
        private void Menu1_ImpAll_Click (object sender, EventArgs e)
            {
            Assign.GetImportantRefs ("ImpAll");
            List5.DataSource = Db.DS.Tables ["tblRefs"];
            List5.DisplayMember = "PaperName";
            List5.ValueMember = "Papers.ID";
            txtSearch.Text = "";
            List2.DataSource = null;
            List15.DataSource = null;
            Client.List5Mode = "Ref";
            List5.Focus ();
            }
        private void Menu1_ImR_Click (object sender, EventArgs e)
            {
            Assign.GetImportantRefs ("ImR");
            List5.DataSource = Db.DS.Tables ["tblRefs"];
            List5.DisplayMember = "PaperName";
            List5.ValueMember = "Papers.ID";
            txtSearch.Text = "";
            List2.DataSource = null;
            List15.DataSource = null;
            Client.List5Mode = "Ref";
            SetList5Status ("Ref");
            List5.Focus ();
            }
        private void Menu1_ReportList_Click (object sender, EventArgs e)
            {
            //Report the list as HTML
            MessageBox.Show ("under constraction");
            }
        private void Menu1_Delete_Click (object sender, EventArgs e)
            {
            if (Menu1_Lock.Checked == true)
                Menu1_CheckMarkSet (6);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex == -1)
                return;
            Ref.Id = Conversions.ToInteger (List5.SelectedValue);
            if (Ref.Id < 1)
                return;
            Assign.DeleteARef (Ref.Id, true);
            txtSearch_TextChanged (null, null);
            }
        //Menu5
        private void Menu5_CheckMarckSet (int i)
            {
            Menu5_Read.Checked = false;
            Menu5_Replace.Checked = false;
            Menu5_AddTo.Checked = false;
            Menu5_Delete.Checked = false;
            Menu5_RefAttributes.Checked = false;
            Menu5_ShowAbove.Checked = false;
            Menu5_GoogleScholar.Checked = false;
            Menu5_QRCode.Checked = false;
            Menu5_Collect.Checked = false;
            switch (i)
                {
                case 1:
                        {
                        Menu5_Read.Checked = true;
                        break;
                        }
                case 2:
                        {
                        Menu5_Replace.Checked = true;
                        break;
                        }
                case 3:
                        {
                        Menu5_AddTo.Checked = true;
                        break;
                        }
                case 4:
                        {
                        Menu5_Delete.Checked = true;
                        break;
                        }
                case 5:
                        {
                        Menu5_RefAttributes.Checked = true;
                        break;
                        }
                case 6:
                        {
                        Menu5_ShowAbove.Checked = true;
                        break;
                        }
                case 7:
                        {
                        Menu5_GoogleScholar.Checked = true;
                        break;
                        }
                case 8:
                        {
                        Menu5_QRCode.Checked = true;
                        break;
                        }
                case 9:
                        {
                        Menu5_Collect.Checked = true;
                        break;
                        }
                }
            }
        private void Menu5_Lock_Click (object sender, EventArgs e)
            {
            if (Menu5_Lock.Checked == true)
                {
                Menu5_Lock.Checked = false;
                Menu5_CheckMarckSet (1);
                }
            else
                {
                Menu5_Lock.Checked = true;
                }
            }
        private void Menu5_Read_Click (object sender, EventArgs e)
            {
            Menu5_CheckMarckSet (1);
            Ref.Title = List5.Text;
            if (!string.IsNullOrEmpty (Ref.Title))
                My.MyProject.Forms.frmReadRef.ShowDialog ();
            }
        private void Menu5_Replace_Click (object sender, EventArgs e)
            {
            if (Menu5_Lock.Checked == true)
                Menu5_CheckMarckSet (2);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex == -1)
                return;
            if (List6.SelectedIndex >= 0)
                return;
            if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                return;
            Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            if (Client.DialogRequestParams == 32)
                {
                Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [7]);
                Assign.ReplaceALink (Link.Id, SubProject.Id);
                List4_Click (null, null); // refresh List5
                }
            }
        private void Menu5_AddTo_Click (object sender, EventArgs e)
            {
            if (Menu5_Lock.Checked == true)
                Menu5_CheckMarckSet (3);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex == -1)
                return;
            if (List6.SelectedIndex >= 0)
                return;
            Ref.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [0]);
            Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            if (Client.DialogRequestParams == 32) //1: A SubProjects is selected from dialog //intProd=id of the selected SubProject
                {
                if (Ref.Id < 1 | SubProject.Id < 1)
                    return;
                bool i = Assign.DoLinkRef2SubProject (Ref.Id, SubProject.Id);
                if (i == true)
                    {
                    txtSearch.Text = List5.Text + " ";
                    }
                else
                    {
                    MessageBox.Show ("Error Assigning Ref to SubProject!", "eLib", MessageBoxButtons.OK);
                    }
                }
            }
        private void Menu5_Delete_Click (object sender, EventArgs e)
            {
            if (Menu5_Lock.Checked == true)
                Menu5_CheckMarckSet (4);
            else
                Menu1_CheckMarkSet (1);
            if (Link.Id < 1)
                return;
            if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                return;
            Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [7]); // see GetRefs above
            Assign.DeleteALink (Link.Id, true);
            try
                {
                SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
                Assign.GetSLinks (SubProject.Id); // refresh list5
                if (List5.SelectedIndex >= 0)
                    {
                    Ref.Id = Conversions.ToInteger (List5.SelectedValue);
                    Assign.GetRLinks (Ref.Id); // refresh list2
                    }
                }
            catch (Exception ex)
                {
                }
            }
        private void Menu5_RefAttributes_Click (object sender, EventArgs e)
            {
            if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                return;
            if (Menu5_Lock.Checked == true)
                Menu5_CheckMarckSet (5);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex == -1)
                return;
            // If List6.SelectedIndex <> -1 Then Exit Sub
            SubProject.Id = Conversions.ToInteger (Db.DS.Tables ["tblSubProject"].Rows [List4.SelectedIndex] [0]);  // 0:SubProject.Id
            Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [7]);             // 7:Links.ID
            Ref.Title = Conversions.ToString (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [1]);            // 1:PaperName
            SubProject.Note = Conversions.ToString (Db.DS.Tables ["tblSubProject"].Rows [List4.SelectedIndex] [2]); // 2:SubProject.Note
            Ref.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [0]);              // 0:Papers.ID
                                                                                                                    // Retval2: 1111-1111 {ImR.Imp3.Imp2.Imp1.Lect.Man.Book.Paper}
            Ref.Attributes = 0;
            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [2], true, false)))
                Ref.Attributes = Ref.Attributes | 1;
            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [3], true, false)))
                Ref.Attributes = Ref.Attributes | 2;
            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [4], true, false)))
                Ref.Attributes = Ref.Attributes | 4;
            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [5], true, false)))
                Ref.Attributes = Ref.Attributes | 8;
            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [8], true, false)))
                Ref.Attributes = Ref.Attributes | 16;
            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [9], true, false)))
                Ref.Attributes = Ref.Attributes | 32;
            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [10], true, false)))
                Ref.Attributes = Ref.Attributes | 64;
            if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [11], true, false)))
                Ref.Attributes = Ref.Attributes | 128;
            My.MyProject.Forms.frmRefAttributes.ShowDialog ();
            if (Ref.Attributes == 1)
                {
                Assign.SetRefAttributes (Ref.Attributes);
                List4_Click (null, null); // refresh list5
                List5_Click (null, null); // refresh labels
                }
            }
        private void Menu5_Collect_Click (object sender, EventArgs e)
            {
            if (Menu5_Lock.Checked == true)
                Menu5_CheckMarckSet (9);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex == -1)
                return;
            FileSystem.FileOpen (1, Application.StartupPath + "elibCollect", OpenMode.Append);
            FileSystem.PrintLine (1, ". " + List3.Text + " . " + List4.Text + " . " + List6.Text);
            FileSystem.PrintLine (1, "  " + List5.Text);
            FileSystem.PrintLine (1, "");
            FileSystem.FileClose (1);
            }
        private void Menu5_Show_Click (object sender, EventArgs e)
            {
            Assign.ShowCollectedNotes ();
            }
        private void Menu5_ShowAbove_Click (object sender, EventArgs e)
            {
            if (Menu5_Lock.Checked == true)
                Menu5_CheckMarckSet (6);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex == -1)
                return;
            //if (List6.SelectedIndex == -1)
            if (Client.List5Mode == "Link") //check if list 5 is showing a link
                {
                txtSearch.Text = List5.Text + " ";
                //txtSearch.Text = Conversions.ToString (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [1] + " ");
                }
            }
        private void Menu5_Copy_Click (object sender, EventArgs e)
            {
            // Copy to clipboard
            if (List5.SelectedIndex >= 0)
                {
                My.MyProject.Computer.Clipboard.SetText (List5.Text);
                //lblRefStatus2.Text = "'Title' coppied to clipboard";
                }
            }
        private void Menu5_GoogleScholar_Click (object sender, EventArgs e)
            {
            if (Menu5_Lock.Checked == true)
                Menu5_CheckMarckSet (7);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex >= 0)
                {
                string strSearchScholar = List5.Text;
                Client.SearchScholar (strSearchScholar);
                }
            }
        private void Menu5_QRCode_Click (object sender, EventArgs e)
            {
            //check if tbl.Settings allows QRCODEGen ?
            if (Menu5_Lock.Checked == true)
                Menu5_CheckMarckSet (8);
            else
                Menu1_CheckMarkSet (1);
            if (List5.SelectedIndex >= 0)
                Client.GenerateQRCode (List5.Text);
            }
        private void Menu5_Mindmap_Click (object sender, EventArgs e)
            {
            var frmMindmap = new frmNoteNetEditor ();
            frmMindmap.ShowDialog ();
            }
        private void Menu5x_Logout_Click (object sender, EventArgs e)
            {
            Dispose ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            }
        //List 15 (RefNotes)
        private void List15_Click (object sender, EventArgs e)
            {
            if (List15.Items.Count != 0 && List15.SelectedIndex != -1)
                {
                try
                    {
                    List5.DataSource = List15.DataSource;
                    List5.DisplayMember = "Note";
                    List5.ValueMember = "ID";
                    SetList5Status (Note.Type); //ie RefNote or RefNoteSearch
                    List55.DataSource = null;
                    //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                    Note.Id = Convert.ToInt32 (Db.DS.Tables ["tblRNotes"].Rows [List15.SelectedIndex] [0]);
                    Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblRNotes"].Rows [List15.SelectedIndex] [2]);
                    Note.Rtl = Conversions.ToBoolean (Db.DS.Tables ["tblRNotes"].Rows [List15.SelectedIndex] [5]);
                    ShowNoteInTextBox ();
                    }
                catch (Exception ex)
                    {
                    //MessageBox.Show (ex.ToString ());
                    txtNote.Text = "";
                    lblStatusBar.Text = "err";
                    }
                }
            }
        private void List15_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 39: //right
                        {
                        if (List15.SelectedIndex != -1)
                            List15_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case (Keys) 13: //enter
                        {
                        if (List15.SelectedIndex != -1)
                            List15_DoubleClick (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case (Keys) 37: //left
                        {
                        e.SuppressKeyPress = true;
                        List2.Focus ();
                        break;
                        }
                case (Keys) 27: //Escape
                        {
                        e.SuppressKeyPress = true;
                        List2.DataSource = null;
                        List15.DataSource = null;
                        List5.Focus ();
                        break;
                        }
                }
            }
        private void List15_DoubleClick (object sender, EventArgs e)
            {
            if (List15.SelectedIndex == -1)
                return;
            Ref.Id = Conversions.ToInteger (Db.DS.Tables ["tblRNotes"].Rows [List15.SelectedIndex] [3]);
            Ref.Title = List5.Text;
            Note.Id = Conversions.ToInteger (List15.SelectedValue);
            if (Note.Id < 1)
                return;
            Note.DateTime = Conversions.ToString (Db.DS.Tables ["tblRNotes"].Rows [List15.SelectedIndex] [1]);
            Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblRNotes"].Rows [List15.SelectedIndex] [2]);
            Note.Index = List15.SelectedIndex;
            Note.Rtl = Conversions.ToBoolean (Db.DS.Tables ["tblRNotes"].Rows [List15.SelectedIndex] [4]);
            CallNoteEditor (Client.List15Mode);
            //refresh lists
            Client.List5Mode = "Ref";
            }
        private void List15_DragEnter (object sender, DragEventArgs e)
            {
            //if an itemfrom List1 is selected (--and a User is logged in?) 
            //create a new RefNote 
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void List15_DragDrop (object sender, DragEventArgs e)
            {
            if ((List5.SelectedIndex == -1) || (Client.List5Mode != "Ref"))
                {
                return;
                }
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            eLibFile.strFilex = strFiles [0];
            FileInfo MyFile = new FileInfo (strFiles [0]);
            if (MyFile.Extension.ToLower () != ".txt")
                {
                return;
                }
            //create a new RefNote for selected ref in List1
            string text = System.IO.File.ReadAllText (eLibFile.strFilex);
            e.Effect = DragDropEffects.None;
            Ref.Id = Conversions.ToInteger (Db.DS.Tables ["tblRefs"].Rows [List5.SelectedIndex] [0]); //0:Paper.ID
            if (Ref.Id < 1)
                return;
            string strDateTime = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
            Assign.AddNewNote (strDateTime, Strings.Left (text, 3998), Ref.Id, 3, User.Id); //ParentType: 1:SubProject 2:Link 3:Ref
            List5_Click (null, null);
            CallNoteEditor ("RefNote");
            Client.List5Mode = "Ref";

            }
        private void Menu15_Search_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter && Menu15_Search.Text.Trim () != "")
                {
                e.SuppressKeyPress = true;
                SearchRefNotes ();
                }
            }
        private void SearchRefNotes ()
            {
            string KeyxA = "";
            string Keyx1 = "";
            string Keyx2 = "";
            string Keyx3 = "";
            string Keyx4 = "";
            string Fltr = "";
            var spcz = new int [4];
            try
                {
                //locate spaces in the search string
                //save nSPC in scpz(0)
                KeyxA = Menu15_Search.Text.Trim ();
                int k = 0;
                for (int i = 1, loopTo = Strings.Len (KeyxA); i <= loopTo; i++)
                    {
                    if (Strings.Mid (KeyxA, i, 1) == " ")
                        {
                        k = k + 1;
                        if (k == 4)
                            break;
                        spcz [k] = i;
                        }
                    }
                spcz [0] = k; //how many spaces?                    
                switch (spcz [0])
                    {
                    case 0: // no space; one key
                            {
                            Fltr = "(Note Like '%" + KeyxA + "%')";
                            break;
                            }
                    case 1: // 1 space; 2 keys
                            {
                            Keyx1 = Strings.Left (KeyxA, spcz [1] - 1);
                            Keyx2 = Strings.Mid (KeyxA, spcz [1] + 1);
                            Fltr = "(Note Like '%" + Keyx1 + "%') AND ";
                            Fltr = Fltr + "(Note Like '%" + Keyx2 + "%')";
                            break;
                            }
                    case 2: // 2 spaces; 3 keys
                            {
                            Keyx1 = Strings.Left (KeyxA, spcz [1] - 1);
                            Keyx2 = Strings.Mid (KeyxA, spcz [1] + 1, spcz [2] - spcz [1] - 1);
                            Keyx3 = Strings.Mid (KeyxA, spcz [2] + 1);
                            Fltr = "(Note Like '%" + Keyx1 + "%') AND ";
                            Fltr = Fltr + "(Note Like '%" + Keyx2 + "%') AND ";
                            Fltr = Fltr + "(Note Like '%" + Keyx3 + "%')";
                            break;
                            }
                    case 3:
                    case 4:
                            {
                            Keyx1 = Strings.Left (KeyxA, spcz [1] - 1);
                            Keyx2 = Strings.Mid (KeyxA, spcz [1] + 1, spcz [2] - spcz [1] - 1);
                            Keyx3 = Strings.Mid (KeyxA, spcz [2] + 1, spcz [3] - spcz [2] - 1);
                            Keyx4 = Strings.Mid (KeyxA, spcz [3] + 1);
                            Fltr = "(Note Like '%" + Keyx1 + "%') AND ";
                            Fltr = Fltr + "(Note Like '%" + Keyx2 + "%') AND ";
                            Fltr = Fltr + "(Note Like '%" + Keyx3 + "%') AND ";
                            Fltr = Fltr + "(Note Like '%" + Keyx4 + "%')";
                            break;
                            }
                    }
                List2.DataSource = null;
                List5.SelectedIndex = -1;
                Client.List15Mode = "RefNoteSearch";
                Db.DS.Tables ["tblRNotes"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE " + Fltr + " AND ParentType = 3 ORDER BY NoteDatum ASC;", CnnSS);
                    Db.DASS.Fill (Db.DS, "tblRNotes");
                    CnnSS.Close ();
                    //list15
                    List15.DataSource = Db.DS.Tables ["tblRNotes"];
                    List15.DisplayMember = "NoteDatum";
                    List15.ValueMember = "Notes.ID";
                    List15.SelectedIndex = -1;
                    List15.Focus ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void Menu15_Add_Click (object sender, EventArgs e)
            {
            //MessageBox.Show (Client.List5Mode);
            if (Client.List5Mode == "Ref" && List5.SelectedIndex != -1)
                {
                Ref.Id = Conversions.ToInteger (Db.DS.Tables ["tblRefs"].Rows [List5.SelectedIndex] [0]); //0:Paper.ID
                if (Ref.Id < 1)
                    return;
                string text = "new note for:   \n" + List5.Text;
                string strDateTime = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
                Assign.AddNewNote (strDateTime, text, Ref.Id, 3, User.Id); //ParentType: 1:SubProject 2:Link 3:Ref
                List5_Click (null, null);
                CallNoteEditor ("RefNote");
                Client.List5Mode = "Ref";
                }
            }
        private void Menu15_Del_Click (object sender, EventArgs e)
            {
            if (List15.SelectedIndex == -1)
                return;
            Ref.Id = Conversions.ToInteger (Db.DS.Tables ["tblRNotes"].Rows [List15.SelectedIndex] [3]);
            if (Ref.Id < 1)
                return;
            Note.Id = Conversions.ToInteger (List15.SelectedValue);
            if (Note.Id < 1)
                return;
            Assign.DeleteNote (Note.Id, true);
            //refresh list2, 15
            if (Client.List15Mode == "RefNote")
                {
                List5_Click (null, null);
                }
            else if (Client.List15Mode == "RefNoteSearch")
                {
                SearchRefNotes ();
                }
            }
        //List 2 (Assigned)
        private void List2_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 27: //escape
                case (Keys) 37: //left
                        {
                        e.SuppressKeyPress = true;
                        List15.DataSource = null;
                        List2.DataSource = null;
                        if (Client.List5Mode == "RefNote")
                            {
                            List5.DataSource = Db.DS.Tables ["tblRefs"];
                            List5.DisplayMember = "PaperName";
                            List5.ValueMember = "Papers.ID";
                            Client.List5Mode = "Ref";
                            SetList5Status ("Ref");
                            }
                        else if (Client.List5Mode == "RefNoteSearch")
                            {
                            List5.DataSource = null;
                            }
                        List5.Focus ();
                        break;
                        }
                case (Keys) 13: //enter
                case (Keys) 39: //right
                        {
                        e.SuppressKeyPress = true;
                        List15.Focus ();
                        break;
                        }
                }
            }
        private void List2_SelectedIndexChanged (object sender, EventArgs e)
            {
            List2_Click (sender, e);
            }
        private void List2_Click (object sender, EventArgs e)
            {
            if (List2.SelectedIndex == -1)
                return;
            try
                {
                lblStatusBar.Text = ""; //in case no matching user-id was found
                int intKarbar = Conversions.ToInteger (Db.DS.Tables ["tblAssignments"].Rows [List2.SelectedIndex] [8]);
                for (int i = 0, loopTo = Db.DS.Tables ["tblUsrs"].Rows.Count - 1; i <= loopTo; i++)
                    {
                    //MessageBox.Show ("intKarbar: " & intKarbar.ToString & " /  " & i.ToString & ":i  / id: " & DS.Tables("tblUsrs").Rows(i).Item(0) & " / user: " & DS.Tables("tblUsrs").Rows(i).Item(1))
                    if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblUsrs"].Rows [i] [0], intKarbar, false)))
                        {
                        lblStatusBar.Text = Conversions.ToString (Operators.ConcatenateObject ("usr: ", Db.DS.Tables ["tblUsrs"].Rows [i] [1]));
                        break;
                        }
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show ("Error: " + ex.ToString());
                }
            }
        private void List2_DoubleClick (object sender, EventArgs e)
            {
            if ((List2.Items.Count == 0) || (List2.SelectedIndex == -1))
                {
                return;
                }
            else
                {
                Menu2_Filter_Click (null, null);
                }
            }
        private void Menu2_Filter_Click (object sender, EventArgs e)
            {
            if (List2.SelectedIndex >= 0)
                {
                SubProject.Id = Conversions.ToInteger (List2.SelectedValue);
                try
                    {
                    Db.DS.Tables ["tblRefs"].Clear ();
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture From Papers INNER Join (Links INNER Join (Projects INNER Join SubProjects On Projects.ID = SubProjects.Project_ID) ON Links.SubProject_ID = SubProjects.ID) ON Papers.ID = Links.Paper_ID WHERE SubProject_ID = " + SubProject.Id.ToString () + " Order By PaperName DESC;", CnnSS);
                        Db.DASS.Fill (Db.DS, "tblRefs");
                        CnnSS.Close ();
                        }
                    }
                catch (Exception ex)
                    {
                    }
                List5.DataSource = Db.DS.Tables ["tblRefs"];
                List5.DisplayMember = "Papername";
                List5.ValueMember = "Papers.ID";
                List5.SelectedIndex = -1;
                Db.DS.Tables ["tblAssignments"].Clear ();
                }
            }
        private void Menu2_FilterDown_Click (object sender, EventArgs e)
            {
            if (List2.SelectedIndex == -1)
                {
                return;
                }
            else
                {
                Menu3_Search.Text = "Find: " + List2.Text;
                }
            }
        private void Menu2_Remove_Click (object sender, EventArgs e)
            {
            // notice: only user's own assignments are listed in list 2, so user cannot removeother's assignments! this function is safe. 
            try
                {
                Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblAssignments"].Rows [List2.SelectedIndex] [0]); // see GetAssignments1 above
                if (Link.Id < 1)
                    return;
                DialogResult myansw = (DialogResult) MessageBox.Show ("Delete this Link?", "eLib", MessageBoxButtons.YesNo);
                if ((int) myansw == (int) Constants.vbYes)
                    {
                    Assign.DeleteALink (Link.Id, false);
                    Ref.Id = Conversions.ToInteger (List5.SelectedValue);
                    Assign.GetRLinks (Ref.Id); // refresh list2
                    if (List4.SelectedIndex >= 0)
                        {
                        SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
                        Assign.GetSLinks (SubProject.Id); // refresh list5
                        }
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        //List 3 (Projects)
        private void Menu3_Share_Click (object sender, EventArgs e)
            {
            if (List3.SelectedIndex >= 0)
                {
                Project.Id = (int) List3.SelectedValue;
                Project.Name = List3.Text;
                }
            else
                {
                return;
                }
            if (Convert.ToInt32 (Db.DS.Tables ["tblProject"].Rows [(int) List3.SelectedIndex] [4].ToString ()) != User.Id)
                {
                DialogResult i = MessageBox.Show ("Leave Group?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (i == DialogResult.Yes)
                    {
                    DialogResult ii = MessageBox.Show ("Sure?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (ii == DialogResult.No)
                        return;
                    //Remove with SQL
                    try
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            CnnSS.Open ();
                            Db.strSQL = "DELETE FROM User_Project WHERE (User_Id = " + User.Id.ToString () + " AND Project_Id=" + Project.Id + ")";
                            var cmd1 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                            cmd1.CommandType = CommandType.Text;
                            int k = cmd1.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            else
                {
                var frmShare = new frmProjectShare ();
                frmShare.ShowDialog ();
                List3.Focus ();
                }
            Menu3_Active_Click (null, null);
            }
        private void Menu3_Add_Click (object sender, EventArgs e)
            {
            // strProjectName | strProjectNote
            Client.DialogRequestParams = 1; //new project
            Project.IsActive = true; // active
            //get new Proj info
            My.MyProject.Forms.frmProject.ShowDialog ();
            try
                {
                if (Client.DialogRequestParams == 16) //save it
                    {
                    Assign.AddNewProject (User.Id);
                    //Assign.AddNewSubProject (Project.Id, Project.Name, SubProject.Note); // {0: auto add SubProjects for new Project | 1: add extra SubProjects for a already existing project}
                    Menu3_All_Click (null, null);// refresh list3 itself!
                    List3.SelectedValue = Project.Id;
                    List3_Click (null, null);
                    }
                else
                    {
                    //MessageBox.Show ("Canceled", "eLib");
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                }
            }
        private void Menu3_Edit_Click (object sender, EventArgs e)
            {
            if ((List3.Items.Count == 0) || (List3.SelectedIndex == -1) || (Project.Id < 1))
                return;
            if (Convert.ToInt32 (Db.DS.Tables ["tblProject"].Rows [(int) List3.SelectedIndex] [4].ToString ()) != User.Id)
                {
                MessageBox.Show ("Can't EDIT \n \n You are not the Owner of this project!", "eLib", MessageBoxButtons.OK);
                return;
                }
            Client.DialogRequestParams = 9; //edit project
            Project.IsActive = Conversions.ToBoolean (Db.DS.Tables ["tblProject"].Rows [List3.SelectedIndex] [3]); // active/inactive
            Project.Name = Conversions.ToString (Db.DS.Tables ["tblProject"].Rows [List3.SelectedIndex] [1]);
            Project.Note = Conversions.ToString (Db.DS.Tables ["tblProject"].Rows [List3.SelectedIndex] [2]);
            Project.Id = Conversions.ToInteger (List3.SelectedValue); //not used here in this method
            My.MyProject.Forms.frmProject.ShowDialog ();
            try
                {
                if (Client.DialogRequestParams == 16) //save it
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "UPDATE Projects SET ProjectName=@projectname, Notes=@notes, Active=@active WHERE ID=@id";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@projectname", Project.Name);
                        cmdx.Parameters.AddWithValue ("@notes", Project.Note);
                        cmdx.Parameters.AddWithValue ("@active", Project.IsActive.ToString ());
                        cmdx.Parameters.AddWithValue ("@id", Project.Id.ToString ());
                        int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    Menu3_Active_Click (sender, e); // refresh list4
                    }
                else
                    {
                    //MessageBox.Show ("Canceled", "eLib");
                    }
                List3.SelectedValue = Project.Id;
                List3_Click (null, null);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                }
            }
        private void Menu3_Delete_Click (object sender, EventArgs e)
            {
            Project.Id = Conversions.ToInteger (List3.SelectedValue);
            if (Project.Id < 1)
                return;
            if (Convert.ToInt32 (Db.DS.Tables ["tblProject"].Rows [(int) List3.SelectedIndex] [4].ToString ()) != User.Id)
                {
                MessageBox.Show ("NOTICE: \n\n You are not the Owner of this project!", "eLib", MessageBoxButtons.OK);
                return;
                }
            //check if this project was populated, if yes, dont delete it 
            if (Db.DS.Tables ["tblSubProject"].Rows.Count > 0)
                {
                MessageBox.Show ("This Project is Populated ! \r\n Replace (or Delete) its Subs, then try again", "eLib", MessageBoxButtons.OK);
                return;
                }
            DialogResult myansw = (DialogResult) MessageBox.Show ("Delete this Project?", "eLib", MessageBoxButtons.YesNo);
            if ((int) myansw == (int) Constants.vbYes)
                {
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "DELETE FROM Projects WHERE ID=@projectid";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@projectid", Project.Id.ToString ());
                        int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    if (Menu3_Active.Checked == true)
                        {
                        Assign.GetProjects (User.Id, 0, ""); //refresh list3 (active) //0:active 1:inactive 2:all
                        }
                    else
                        {
                        Assign.GetProjects (User.Id, 2, "");//0:active 1:inactive 2:all
                        } // refresh list3 (all)
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            }
        private void Menu3_Active_Click (object sender, EventArgs e)
            {
            Assign.GetProjects (User.Id, 0, ""); //0:active 1:inactive 2:all
            List3.DataSource = Db.DS.Tables ["tblProject"];
            List3.DisplayMember = "ProjectName";
            List3.ValueMember = "ID";
            List3.SelectedIndex = -1;
            Menu3_Active.Checked = true;
            Menu3_InActive.Checked = false;
            Menu3_All.Checked = false;
            List35.DataSource = null;
            List4.DataSource = null;
            List55.DataSource = null;
            List6.DataSource = null;
            }
        private void Menu3_InActive_Click (object sender, EventArgs e)
            {
            Assign.GetProjects (User.Id, 1, ""); //0:active 1:inactive 2:all
            List3.DataSource = Db.DS.Tables ["tblProject"];
            List3.DisplayMember = "ProjectName";
            List3.ValueMember = "ID";
            List3.SelectedIndex = -1;
            List35.DataSource = null;
            Menu3_Active.Checked = false;
            Menu3_InActive.Checked = true;
            Menu3_All.Checked = false;
            }
        private void Menu3_All_Click (object sender, EventArgs e)
            {
            Assign.GetProjects (User.Id, 2, ""); //0:active 1:inactive 2:all
            List3.DataSource = Db.DS.Tables ["tblProject"];
            List3.DisplayMember = "ProjectName";
            List3.ValueMember = "ID";
            List3.SelectedIndex = -1;
            List35.DataSource = null;
            Menu3_Active.Checked = false;
            Menu3_InActive.Checked = false;
            Menu3_All.Checked = true;
            }
        private void Menu3_Search_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 27:
                        {
                        Menu3_Search.Text = "";
                        break;
                        }
                case (Keys) 13:
                        {
                        List3_Click (sender, e);
                        break;
                        }
                case (Keys) 38: //up
                case (Keys) 40: //down
                        {
                        List3.Focus ();
                        break;
                        }
                }
            }
        private void Menu3_Search_TextChanged (object sender, EventArgs e)
            {
            if ((Menu3_Search.Text.Trim ().ToLower () == "act") | (Menu3_Search.Text.Trim ().ToLower () == "+a") | (Menu3_Search.Text.Trim () == ""))
                {
                Menu3_Active_Click (null, null);
                Menu3_Search.Text = " active Projects ";
                Menu3_Search.SelectionStart = 0;
                Menu3_Search.SelectionLength = Menu3_Search.TextLength;
                }
            else if ((Menu3_Search.Text.Trim ().ToLower () == "inact") | (Menu3_Search.Text.Trim ().ToLower () == "-a"))
                {
                Menu3_InActive_Click (null, null);
                Menu3_Search.Text = " inactive Projects ";
                Menu3_Search.SelectionStart = 0;
                Menu3_Search.SelectionLength = Menu3_Search.TextLength;
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "all")
                {
                Menu3_All_Click (null, null);
                Menu3_Search.Text = " all Projects ";
                Menu3_Search.SelectionStart = 0;
                Menu3_Search.SelectionLength = Menu3_Search.TextLength;
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "share")
                {
                Menu3_Share_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if ((Menu3_Search.Text.Trim ().ToLower () == "-user") | (Menu3_Search.Text.Trim ().ToLower () == "log"))
                {
                Menu_user_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if ((Menu3_Search.Text.Trim ().ToLower () == "-quit") | (Menu3_Search.Text.Trim ().ToLower () == "-exit"))
                {
                Menu3_Search.Text = "Exit? yes / no";
                Menu3_Search.SelectionStart = 6;
                Menu3_Search.SelectionLength = 8;
                }
            else if (Menu3_Search.Text.ToLower () == "exit? y")
                {
                Menu_Exit_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if (Menu3_Search.Text.ToLower () == "exit? n")
                {
                Menu3_Search.Text = "";
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "-impo")
                {
                Menu_Import_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "-dir")
                {
                Menu_AssignFolder_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "-h")
                {
                Menu_About_eLib_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "-c")
                {
                Menu3_Search.Text = "Create? Word Exel PwrPnt Text";
                Menu3_Search.SelectionStart = 8;
                Menu3_Search.SelectionLength = 21;
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "create? w")
                {
                Menu_CreateWord_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "create? e")
                {
                Menu_CreateExcel_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "create? p")
                {
                Menu_CreatePowepoint_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "create? t")
                {
                Menu_CreateTextFile_Click (null, null);
                Menu3_Search.Text = "";
                }
            else if (Menu3_Search.Text.Trim ().ToLower () == "-f")
                {
                Menu3_Search.Text = "Find: ";
                Menu3_Search.SelectionStart = 6;
                }
            else if ((Strings.Left (Menu3_Search.Text, 6) == "Find: ") & (Menu3_Search.TextLength >= 8))
                {
                Assign.GetProjects (User.Id, 3, Strings.Trim (Menu3_Search.Text)); //0:active 1:inactive 2:all
                List3.DataSource = Db.DS.Tables ["tblProject"];
                List3.DisplayMember = "ProjectName";
                List3.ValueMember = "ID";
                Menu3_Active.Checked = false;
                Menu3_InActive.Checked = false;
                Menu3_All.Checked = true; // but filter by strSearchProject
                //also search subProjects
                string strSearchPrd = Strings.Trim (Strings.Mid (Menu3_Search.Text, 7));
                if (string.IsNullOrEmpty (strSearchPrd))
                    return;
                SrearchSubProjects (strSearchPrd);
                List4.DataSource = Db.DS.Tables ["tblSubProject"];
                List4.DisplayMember = "SubProjectName";
                List4.ValueMember = "ID";
                List4.SelectedValue = -1;
                Db.DS.Tables ["tblLinks"].Clear ();
                Db.DS.Tables ["tblSNotes"].Clear ();
                lblStatusBar.Text = "";
                }
            }
        private void Menu3_Report_Click (object sender, EventArgs e)
            {
            string strHeader;
            if (Conversions.ToInteger (Menu3_Active.Checked) == -1)
                {
                strHeader = "Report Active Projects for User: ";
                }
            else if (Conversions.ToInteger (Menu3_InActive.Checked) == -1)
                {
                strHeader = "Report Inactive Projects for User: ";
                }
            else
                {
                strHeader = "Report All Projects for User: ";
                }
            //report
            Assign.ReportProjects (strHeader);
            }
        private void SrearchSubProjects (string strSearchKeyword)
            {
            Db.DS.Tables ["tblSubProject"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID, SubProjectName, Notes, Project_ID FROM SubProjects Where SubProjectName LIKE '%" + strSearchKeyword + "%' Order by SubProjectName", CnnSS);
                Db.DASS.Fill (Db.DS, "tblSubProject");
                CnnSS.Close ();
                }
            }
        private void lblStatusBar_Click (object sender, EventArgs e)
            {
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            //if (lblStatusBar.Text.Trim () == "")
            //    {
            //    return;
            //    }
            //if (Note.Rtl == true)
            //    {
            //    MessageBox.Show (lblStatusBar.Text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            //    }
            //else
            //    {
            //    MessageBox.Show (lblStatusBar.Text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            //    }
            }
        private void List3_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 13:
                case (Keys) 39: //-> right
                        {
                        List3_Click (sender, e);
                        if (List4.Items.Count > 0)
                            List4.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case (Keys) 37://<- left
                        {
                        Menu3_Search.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void List3_Click (object sender, EventArgs e)
            {
            if (List3.SelectedIndex == -1)
                return;
            if (Client.List5Mode != "Ref")
                {
                List5.DataSource = null;
                }
            try
                {
                List4.DataSource = null;
                Project.Id = Conversions.ToInteger (List3.SelectedValue);
                Assign.GetSubProjects (Project.Id);
                List35.DataSource = null;
                if (List3.SelectedIndex == -1)
                    {
                    List35.DataSource = null;
                    }
                Assign.GetSharedList (Project.Id);
                List35.DataSource = Db.DS.Tables ["tblUserProject"];
                List35.DisplayMember = "UsrName";
                List35.ValueMember = "User_Id";
                List35.SelectedIndex = -1;
                List4.DataSource = Db.DS.Tables ["tblSubProject"];
                List4.DisplayMember = "SubProjectName";
                List4.ValueMember = "ID";
                List4.SelectedValue = -1;
                Db.DS.Tables ["tblLinks"].Clear ();
                Db.DS.Tables ["tblSNotes"].Clear ();
                SetList5Status ("none"); //Ref, Link, LinkNote, LinkNoteSearch, SubProjectNote, SubProjectNoteSearch, RefNote, RefNoteSearch
                List6.DataSource = null;
                List55.DataSource = null;
                txtNote.Text = "";
                txtNote.Enabled = false;
                lblStatusBar.Text = "";
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        //List 35 (Shared users)
        private void List35_DoubleClick (object sender, EventArgs e)
            {
            Menu3_Share_Click (null, null);
            }
        //List 4 (subProjects)
        private void Menu4_Add_Click (object sender, EventArgs e)
            {
            if ((List3.Items.Count == 0) || (List3.SelectedIndex == -1))
                {
                return;
                }
            else
                {
                Project.Id = (int) List3.SelectedValue;
                Project.Name = List3.Text;
                if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                    {
                    return;
                    }
                SubProject.Name = Strings.Left (Project.Name, 8) + ".sub " + (List4.Items.Count + 1).ToString ().Trim () + "-[" + DateTime.Now.ToString ("HHmm") + "]";//yyyyMMddHHmm
                SubProject.Note = "[Note]";
                Assign.AddNewSubProject (Project.Id, Project.Name, SubProject.Note);
                Assign.GetSubProjects (Project.Id); // refresh list5
                List4.SelectedValue = SubProject.Id;
                }
            }
        private void Menu4_Edit_Click (object sender, EventArgs e)
            {
            Project.Id = Conversions.ToInteger (List3.SelectedValue); //is required for refreshing List4 (see below at end of current sub)
            if (Project.Id < 1)
                return;
            SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
            if (SubProject.Id < 1)
                return;
            Project.Name = Conversions.ToString (Db.DS.Tables ["tblSubProject"].Rows [List4.SelectedIndex] [1]); // using shared variables
            Project.Note = Conversions.ToString (Db.DS.Tables ["tblSubProject"].Rows [List4.SelectedIndex] [2]); // using shared variables
            Assign.EditASubProject (SubProject.Id);
            List4_Click (sender, e);
            }
        private void Menu4_Replace_Click (object sender, EventArgs e)
            {
            if (List4.SelectedIndex == -1)
                return;
            Project.Id = Conversions.ToInteger (List3.SelectedValue);
            if (Project.Id < 1)
                return;
            if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                return;
            Client.DialogRequestParams = 1; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            //replace current SubProjects to selected project
            if (Client.DialogRequestParams == 64) //bit7:2^6:64: a Project is selected from dialog
                {
                Assign.ReplaceASubProject (SubProject.Id, Project.Id);
                }
            List3_Click (sender, e); // to refresh list4
            }
        private void Menu4_Delete_Click (object sender, EventArgs e)
            {
            Project.Id = Conversions.ToInteger (List3.SelectedValue);
            if ((Project.Id < 1) || (Assign.CheckReadOnlyAccess (Project.Id) == 1))
                {
                return;
                }
            SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
            if (SubProject.Id < 1)
                {
                return;
                }
            Assign.DeleteASubProject (SubProject.Id);
            }
        private void Menu4_ReportThis_Click (object sender, EventArgs e)
            {
            if (List3.SelectedIndex == -1)
                return;
            if (List4.SelectedIndex == -1)
                return;
            List5.DataSource = null;
            List6.DataSource = null;
            Assign.ReportThisSubProject (SubProject.Id);
            }
        private void Menu4_ReportAll_Click (object sender, EventArgs e)
            {
            if (List3.SelectedIndex == -1)
                return;
            List5.DataSource = null;
            List6.DataSource = null;
            Assign.ReportAllNotesInASubproject ();
            }
        private void lblProdNote_DoubleClick (object sender, EventArgs e)
            {
            Menu4_Edit_Click (sender, e);
            }
        private void List4_DragEnter (object sender, DragEventArgs e)
            {
            //if an itemfrom List4 is selected 
            //Import and link to the SubProject 
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void List4_DragDrop (object sender, DragEventArgs e)
            {
            if (List4.SelectedIndex == -1)
                {
                return;
                }
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            eLibFile.strFilex = strFiles [0];
            Ref.ImportStatus = 6; //flag for NewImport from Main + a subproject
            e.Effect = DragDropEffects.None;
            SubProject.Id = (int) List4.SelectedValue;
            SubProject.Name = List4.Text;
            WindowState = FormWindowState.Minimized;
            My.MyProject.Forms.frmImportRefs.ShowDialog ();
            WindowState = FormWindowState.Normal;
            }
        private void List4_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 13: //enter
                        {
                        e.SuppressKeyPress = true;
                        List4_Click (null, null);
                        List5.Focus ();
                        List5.SelectedIndex = -1;
                        break;
                        }
                case (Keys) 39: // -> Right
                        {
                        e.SuppressKeyPress = true;
                        List4_Click (null, null);
                        if (List6.Items.Count > 0)
                            {
                            List6.Focus ();
                            List6.SelectedIndex = -1;
                            }
                        else if (List5.Items.Count > 0)
                            {
                            List5.Focus ();
                            List5.SelectedIndex = -1;
                            }
                        break;
                        }
                case (Keys) 37: //left
                        {
                        e.SuppressKeyPress = true;
                        List6.DataSource = null;
                        List4.DataSource = null;
                        List5.DataSource = null;
                        List55.DataSource = null;
                        List3.Focus ();
                        break;
                        }
                }
            }
        private void List4_Click (object sender, EventArgs e)
            {
            if (List4.SelectedIndex == -1)
                return;
            SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
            Note.Type = "";
            Client.List5Mode = "Link";
            Client.List6Mode = "SubProjectNote";
            try
                {
                Assign.GetSLinks (SubProject.Id);
                List5.DataSource = Db.DS.Tables ["tblLinks"];
                List5.DisplayMember = "PaperName";
                List5.ValueMember = "Papers.ID";
                if (Link.Id > 0)
                    {
                    List5.SelectedValue = Link.Id;
                    }
                else
                    {
                    List5.SelectedIndex = -1;
                    }
                Assign.GetNotes (SubProject.Id, 1);
                List6.DataSource = Db.DS.Tables ["tblSNotes"];
                List6.DisplayMember = "NoteDatum";
                List6.ValueMember = "Notes.ID";
                List6.SelectedIndex = -1;
                SetList5Status ("Link");
                lblStatusBar.Text = Conversions.ToString (Db.DS.Tables ["tblSubProject"].Rows [List4.SelectedIndex] [2]);
                List2.DataSource = null;
                List15.DataSource = null;
                List55.DataSource = null;
                txtNote.Text = "";
                txtNote.Enabled = false;
                }
            catch (Exception ex)
                {
                //raises an error when DS.Tables("tblSubProject").Rows(List4.SelectedIndex).Item(2) = NULL!  
                }
            }
        private void List4_DoubleClick (object sender, EventArgs e)
            {
            Menu4_Edit_Click (null, null);
            }
        //List 55 (Link_Notes)
        private void List55_Click (object sender, EventArgs e)
            {
            if (List55.Items.Count != 0 && List55.SelectedIndex != -1)
                {
                try
                    {
                    //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                    Note.Id = Convert.ToInt32 (Db.DS.Tables ["tblLNotes"].Rows [List55.SelectedIndex] [0]);
                    Note.Type = Client.List55Mode;
                    Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblLNotes"].Rows [List55.SelectedIndex] [2]);
                    Note.Rtl = Conversions.ToBoolean (Db.DS.Tables ["tblLNotes"].Rows [List55.SelectedIndex] [5]);
                    ShowNoteInTextBox ();
                    List2.DataSource = null;
                    List15.DataSource = null;
                    List5.DataSource = List55.DataSource;
                    List5.DisplayMember = "Note";
                    List5.ValueMember = "Notes.ID";
                    SetList5Status (Note.Type); //ie LinkNote or LinkNoteSearch
                    }
                catch (Exception ex)
                    {
                    //MessageBox.Show (ex.ToString ());
                    txtNote.Text = "";
                    lblStatusBar.Text = "";
                    }
                }
            }
        private void List55_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 13:
                        {
                        if (List55.SelectedIndex != -1)
                            List55_DoubleClick (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case (Keys) 39: //right
                        {
                        List55_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case (Keys) 37: //left 
                case (Keys) 27: //escape
                        {
                        List5.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void List55_DoubleClick (object sender, EventArgs e)
            {
            if (List55.SelectedIndex == -1)
                return;
            Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLNotes"].Rows [List55.SelectedIndex] [3]);
            Note.Id = Conversions.ToInteger (List55.SelectedValue);
            if (Note.Id < 1)
                return;
            Note.Id = Conversions.ToInteger (List55.SelectedValue);
            Note.DateTime = Conversions.ToString (Db.DS.Tables ["tblLNotes"].Rows [List55.SelectedIndex] [1]);
            Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblLNotes"].Rows [List55.SelectedIndex] [2]);
            Note.Index = List55.SelectedIndex;
            if (Note.Id < 1)
                return;
            Note.Rtl = Conversions.ToBoolean (Db.DS.Tables ["tblLNotes"].Rows [List55.SelectedIndex] [4]);
            CallNoteEditor (Client.List55Mode);
            }
        private void List55_DragEnter (object sender, DragEventArgs e)
            {
            //if an itemfrom List5 is selected 
            //create a new LinkNote 
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void List55_DragDrop (object sender, DragEventArgs e)
            {
            if ((List5.SelectedIndex == -1) || Client.List5Mode != "Link")
                {
                return;
                }
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            eLibFile.strFilex = strFiles [0];
            FileInfo MyFile = new FileInfo (strFiles [0]);
            if (MyFile.Extension.ToLower () != ".txt")
                {
                return;
                }
            //create a new LinkNote for selected Link in List5
            string text = System.IO.File.ReadAllText (eLibFile.strFilex);
            e.Effect = DragDropEffects.None;
            Link.Id = Convert.ToInt32 (List5.SelectedValue);
            Note.DateTime = DateTime.Now.AddDays (2).ToString ("yyyy-MM-dd . HH-mm");
            Assign.AddNewNote (Note.DateTime, Strings.Left (text, 3998), Link.Id, 2, User.Id); //ParentType: 1:SubProject 2:Link 3:Ref
            }
        private void Menu55_Search_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter && Menu55_Search.Text.Trim () != "")
                {
                string KeyxA = "";
                string Keyx1 = "";
                string Keyx2 = "";
                string Keyx3 = "";
                string Keyx4 = "";
                string Fltr = "";
                var spcz = new int [4];
                try
                    {
                    //locate spaces in the search string
                    //save nSPC in scpz(0)
                    KeyxA = Menu55_Search.Text.Trim ();
                    int k = 0;
                    for (int i = 1, loopTo = Strings.Len (KeyxA); i <= loopTo; i++)
                        {
                        if (Strings.Mid (KeyxA, i, 1) == " ")
                            {
                            k = k + 1;
                            if (k == 4)
                                break;
                            spcz [k] = i;
                            }
                        }
                    spcz [0] = k;
                    //how many spaces?
                    switch (spcz [0])
                        {
                        case 0: // no space; one key
                                {
                                Fltr = "(Note Like '%" + KeyxA + "%')";
                                break;
                                }
                        case 1: // 1 space; 2 keys
                                {
                                Keyx1 = Strings.Left (KeyxA, spcz [1] - 1);
                                Keyx2 = Strings.Mid (KeyxA, spcz [1] + 1);
                                Fltr = "(Note Like '%" + Keyx1 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx2 + "%')";
                                break;
                                }
                        case 2: // 2 spaces; 3 keys
                                {
                                Keyx1 = Strings.Left (KeyxA, spcz [1] - 1);
                                Keyx2 = Strings.Mid (KeyxA, spcz [1] + 1, spcz [2] - spcz [1] - 1);
                                Keyx3 = Strings.Mid (KeyxA, spcz [2] + 1);
                                Fltr = "(Note Like '%" + Keyx1 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx2 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx3 + "%')";
                                break;
                                }
                        case 3:
                        case 4:
                                {
                                Keyx1 = Strings.Left (KeyxA, spcz [1] - 1);
                                Keyx2 = Strings.Mid (KeyxA, spcz [1] + 1, spcz [2] - spcz [1] - 1);
                                Keyx3 = Strings.Mid (KeyxA, spcz [2] + 1, spcz [3] - spcz [2] - 1);
                                Keyx4 = Strings.Mid (KeyxA, spcz [3] + 1);
                                Fltr = "(Note Like '%" + Keyx1 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx2 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx3 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx4 + "%')";
                                break;
                                }
                        }
                    Db.DS.Tables ["tblLNotes"].Clear ();
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE " + Fltr + " AND ParentType = 2 ORDER BY NoteDatum ASC;", CnnSS);
                        Db.DASS.Fill (Db.DS, "tblLNotes");
                        CnnSS.Close ();
                        }
                    List55.DataSource = Db.DS.Tables ["tblLNotes"];
                    List55.DisplayMember = "NoteDatum";
                    List55.ValueMember = "Notes.ID";
                    List55.SelectedIndex = -1;
                    Client.List55Mode = "LinkNoteSearch";
                    Note.Type = "LinkNoteSearch";
                    List6.SelectedIndex = -1;
                    e.SuppressKeyPress = true;
                    List55.Focus ();
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            }
        private void Menu55_Add_Click (object sender, EventArgs e)
            {
            if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                return;
            if (Client.List5Mode == "Link" && List5.SelectedIndex != -1)
                {
                try
                    {
                    Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [7]); // 7:Link.ID
                    if (Link.Id < 1)
                        return;
                    Note.DateTime = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
                    Assign.AddNewNote (Note.DateTime, ("New Note for link: \n" + List5.Text), Link.Id, 2, User.Id); //ParentType: 1:SubProject 2:Link 3:Ref
                    List5_Click (null, null);
                    CallNoteEditor ("LinkNote");
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ()); // Do Nothing!
                    }
                }
            }
        private void Menu55_Del_Click (object sender, EventArgs e)
            {
            if (List55.SelectedIndex == -1)
                return;
            Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [List5.SelectedIndex] [7]); // 7:Link.ID
            Note.Id = Conversions.ToInteger (List5.SelectedValue);
            if ((Link.Id < 1) || (Note.Id < 1) || (Assign.CheckReadOnlyAccess (Project.Id) == 1))
                return;
            DialogResult myansw = (DialogResult) MessageBox.Show ("Delete this note?", "eLib", MessageBoxButtons.YesNo);
            if (myansw == DialogResult.Yes)
                {
                Assign.DeleteNote (Note.Id, true);
                int tmpLinkId = Link.Id;
                List4_Click (null, null);
                List5.SelectedValue = tmpLinkId;
                List5_Click (null, null); //refresh list55,6
                }
            }
        //List 6 (subproject_Notes)
        private void List6_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 13:
                        {
                        e.SuppressKeyPress = true;
                        if (List6.SelectedIndex != -1)
                            Menu6_Edit_Click (null, null);
                        break;
                        }
                case (Keys) 37: //left
                        {
                        List6.DataSource = null;
                        List5.DataSource = null;
                        List55.DataSource = null;
                        List4.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case (Keys) 39: //right
                        {
                        List6_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void List6_Click (object sender, EventArgs e)
            {
            if (List6.Items.Count != 0 || List6.SelectedIndex != -1)
                {
                try
                    {
                    Note.Type = Client.List6Mode;
                    if (List6.DataSource == Db.DS.Tables ["tblSNotes"])
                        {
                        Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblSNotes"].Rows [List6.SelectedIndex] [2]);
                        txtNote.Text = Note.NoteText;
                        Note.Id = Convert.ToInt32 (Db.DS.Tables ["tblSNotes"].Rows [List6.SelectedIndex] [0]);
                        Note.Rtl = Conversions.ToBoolean (Db.DS.Tables ["tblSNotes"].Rows [List6.SelectedIndex] [5]);
                        ShowNoteInTextBox ();
                        //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                        Project.Id = Conversions.ToInteger (Db.DS.Tables ["tblSubProject"].Rows [List4.SelectedIndex] [3]);  //3:Project.Id
                        SubProject.Id = (int) (List4.SelectedValue);
                        List5.DataSource = List6.DataSource;
                        List5.DisplayMember = "Note";
                        List5.ValueMember = "ID";
                        SetList5Status (Note.Type); //ie SubProjectNote
                        }
                    else if (List6.DataSource == Db.DS.Tables ["tblNotesCount"])
                        {
                        //tblNotesCount: 0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done, 8Rtl : FROM Notes INNER JOIN ...
                        Project.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [4]);
                        Note.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [6]);
                        Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [3]);
                        Note.Rtl = Convert.ToBoolean (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [8]);
                        ShowNoteInTextBox ();
                        }
                    List2.DataSource = null;
                    List15.DataSource = null;
                    List5.DataSource = List6.DataSource;
                    List5.DisplayMember = "Note";
                    List5.ValueMember = "ID";
                    SetList5Status (Note.Type); //ie SubProjectNoteSearch
                    }
                catch (Exception ex)
                    {
                    //MessageBox.Show ("Error \n\n" + ex.ToString ());
                    txtNote.Text = "";
                    lblStatusBar.Text = "";
                    }
                }
            }
        private void List6_DoubleClick (object sender, EventArgs e)
            {
            if (List6.SelectedIndex == -1)
                List6.SelectedIndex = List5.SelectedIndex;
            Note.Type = "SubProjectNote";
            Menu6_Edit_Click (null, null);
            }
        private void List6_DragEnter (object sender, DragEventArgs e)
            {
            //if an itemfrom List4 is selected
            //create a new SubProjectNote 
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void List6_DragDrop (object sender, DragEventArgs e)
            {
            if (List4.SelectedIndex == -1)
                {
                return;
                }
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            eLibFile.strFilex = strFiles [0];
            FileInfo MyFile = new FileInfo (strFiles [0]);
            if (MyFile.Extension.ToLower () != ".txt")
                {
                return;
                }
            //create a new SubProjectNote for selected SubProject in List4
            string text = System.IO.File.ReadAllText (eLibFile.strFilex);
            e.Effect = DragDropEffects.None;
            Note.DateTime = DateTime.Now.AddDays (2).ToString ("yyyy-MM-dd . HH-mm");
            Assign.AddNewNote (Note.DateTime, Strings.Left (text, 3998), SubProject.Id, 1, User.Id); //ParentType: 1:SubProject 2:Link 3:Ref
            List4_Click (null, null);
            CallNoteEditor ("SubProjectNote");
            }
        private void Menu6_Search_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter && Menu6_Search.Text.Trim () != "")
                {
                string KeyxA = "";
                string Keyx1 = "";
                string Keyx2 = "";
                string Keyx3 = "";
                string Keyx4 = "";
                string Fltr = "";
                var spcz = new int [4];
                try
                    {
                    //locate spaces in the search string
                    //save nSPC in scpz(0)
                    KeyxA = Menu6_Search.Text.Trim ();
                    int k = 0;
                    for (int i = 1, loopTo = Strings.Len (KeyxA); i <= loopTo; i++)
                        {
                        if (Strings.Mid (KeyxA, i, 1) == " ")
                            {
                            k = k + 1;
                            if (k == 4)
                                break;
                            spcz [k] = i;
                            }
                        }
                    spcz [0] = k;
                    //how many spaces?
                    switch (spcz [0])
                        {
                        case 0: // no space; one key
                                {
                                Fltr = "(Note Like '%" + KeyxA + "%')";
                                break;
                                }
                        case 1: // 1 space; 2 keys
                                {
                                // Keyx1 = Mid(KeyxA, 1, spcz(1) - 1)
                                Keyx1 = Strings.Left (KeyxA, spcz [1] - 1);
                                Keyx2 = Strings.Mid (KeyxA, spcz [1] + 1);
                                Fltr = "(Note Like '%" + Keyx1 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx2 + "%')";
                                break;
                                }
                        case 2: // 2 spaces; 3 keys
                                {
                                Keyx1 = Strings.Left (KeyxA, spcz [1] - 1);
                                Keyx2 = Strings.Mid (KeyxA, spcz [1] + 1, spcz [2] - spcz [1] - 1);
                                Keyx3 = Strings.Mid (KeyxA, spcz [2] + 1);
                                Fltr = "(Note Like '%" + Keyx1 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx2 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx3 + "%')";
                                break;
                                }
                        case 3:
                        case 4:
                                {
                                Keyx1 = Strings.Left (KeyxA, spcz [1] - 1);
                                Keyx2 = Strings.Mid (KeyxA, spcz [1] + 1, spcz [2] - spcz [1] - 1);
                                Keyx3 = Strings.Mid (KeyxA, spcz [2] + 1, spcz [3] - spcz [2] - 1);
                                Keyx4 = Strings.Mid (KeyxA, spcz [3] + 1);
                                Fltr = "(Note Like '%" + Keyx1 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx2 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx3 + "%') AND ";
                                Fltr = Fltr + "(Note Like '%" + Keyx4 + "%')";
                                break;
                                }
                        }
                    List4.SelectedIndex = -1;
                    Db.DS.Tables ["tblNotesCount"].Clear ();
                    //strSQL ?
                    Db.strSQL = "SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID";
                    Db.strSQL += " WHERE (Projects.User_ID = " + User.Id.ToString ();
                    Db.strSQL += " AND " + Fltr + ")";
                    Db.strSQL += " UNION SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID INNER JOIN User_Project ON User_Project.Project_Id = Projects.ID";
                    Db.strSQL += " WHERE (User_Project.User_Id = " + User.Id.ToString ();
                    Db.strSQL += " AND " + Fltr + ")";
                    Db.strSQL += " ORDER BY NoteDatum";
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                        Db.DASS.Fill (Db.DS, "tblNotesCount");
                        CnnSS.Close ();
                        }
                    List6.DataSource = Db.DS.Tables ["tblNotesCount"];
                    List6.DisplayMember = "NoteDatum";
                    List6.ValueMember = "SubPojectsNotes.ID";
                    List6.SelectedIndex = -1;
                    Client.List6Mode = "SubProjectNoteSearch";
                    e.SuppressKeyPress = true;
                    List6.Focus ();
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            }
        private void Menu6_Add_Click (object sender, EventArgs e)
            {
            if ((Assign.CheckReadOnlyAccess (Project.Id) == 1) || (List4.Items.Count == 0) || (List4.SelectedIndex == -1))
                return;
            try
                {
                SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
                SubProject.Name = List4.Text;
                if (SubProject.Id < 1)
                    return;
                SubProject.Name = List4.Text;
                }
            catch
                {
                return;
                }
            Note.DateTime = DateTime.Now.AddDays (2).ToString ("yyyy-MM-dd . HH-mm");
            Assign.AddNewNote (Note.DateTime, ("New note for subProject: " + SubProject.Name), SubProject.Id, 1, User.Id); //ParentType: 1:SubProject 2:Link 3:Ref
            List4_Click (null, null);
            CallNoteEditor ("SubProjectNote");
            }
        private void Menu6_Edit_Click (object sender, EventArgs e)
            {
            if (List6.SelectedIndex == -1)
                return;
            if (List4.SelectedIndex == -1 | Client.List5Mode == "SubProjectNoteSearch")
                {
                Note.DateTime = Conversions.ToString (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [2]);
                Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [3]);
                Project.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [4]);
                SubProject.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [5]);
                Note.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [6]);
                Menu3_All_Click (null, null);
                List3.SelectedValue = Project.Id;
                List3_Click (null, null);
                List4.SelectedValue = SubProject.Id;
                List4_Click (null, null);
                List6.SelectedValue = Note.Id;
                List6_Click (null, null);
                List5.DataSource = List6.DataSource;
                }
            SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
            SubProject.Name = List4.Text;
            Project.Name = List3.Text;
            Note.Id = Conversions.ToInteger (List6.SelectedValue);
            Note.DateTime = Conversions.ToString (Db.DS.Tables ["tblSNotes"].Rows [List6.SelectedIndex] [1]);
            Note.NoteText = Conversions.ToString (Db.DS.Tables ["tblSNotes"].Rows [List6.SelectedIndex] [2]);
            Note.Index = List6.SelectedIndex;
            if (Note.Id < 1)
                return;
            CallNoteEditor ("SubProjectNote");
            }
        private void Menu6_Replace_Click (object sender, EventArgs e)
            {
            //Replace a Note
            if (List6.SelectedIndex == -1)
                return;
            Note.Id = Conversions.ToInteger (List6.SelectedValue);
            Assign.ReplaceASubProjectNote (Note.Id);
            List4_Click (sender, e); // to refresh list6
            }
        private void Menu6_Delete_Click (object sender, EventArgs e)
            {
            SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
            Note.Id = Conversions.ToInteger (List6.SelectedValue);
            if ((SubProject.Id > 0) && (Note.Id > 0))
                {
                Assign.DeleteNote (Note.Id, true);
                List4_Click (sender, e); // refresh list5,6
                GetUpcomingNotes ();
                }
            }
        private void Menu6_DeleteAll_Click (object sender, EventArgs e)
            {
            if (List6.Items.Count == 0)
                return;
            SubProject.Id = Conversions.ToInteger (List4.SelectedValue);
            if ((SubProject.Id < 1) || (Assign.CheckReadOnlyAccess (Project.Id) == 1))
                {
                return;
                }
            else
                {
                Assign.DeleteAllSubProjectNotes (SubProject.Id);
                List4_Click (sender, e); // refresh list5,6
                GetUpcomingNotes ();
                }
            }
        private void CallNoteEditor (string strnotetype)
            {
            Note.Type = strnotetype;
            My.MyProject.Forms.frmNotes.ShowDialog ();
            //refresh lists
            switch (Note.Type)
                {
                case "SubProjectNote":
                        {
                        GetUpcomingNotes ();
                        List3.SelectedValue = Project.Id;
                        List3_Click (null, null);
                        List4.SelectedValue = Note.ParentID;
                        List4_Click (null, null);
                        List6.SelectedValue = Note.Id;
                        List6_Click (null, null);
                        break;
                        }
                case "SubProjectNoteSearch":
                        {
                        GetUpcomingNotes ();
                        List6.SelectedValue = Note.Id;
                        List6_Click (null, null);
                        break;
                        }
                case "LinkNote":
                case "LinkNoteSearch":
                        {
                        List55.SelectedValue = Note.Id;
                        List55_Click (null, null);
                        break;
                        }
                case "RefNote":
                case "RefNoteSearch":
                        {
                        List15.SelectedValue = Note.Id;
                        List15_Click (null, null);
                        break;
                        }
                }
            }
        private void lblMindMap_Click (object sender, EventArgs e)
            {
            try
                {
                switch (Note.Type)
                    {
                    case "SubProjectNote":
                            {
                            if (List6.SelectedIndex == -1)
                                {
                                return;
                                }
                            Note.Id = (int) List6.SelectedValue;
                            var frmMindmap = new frmNoteNetEditor ();
                            frmMindmap.ShowDialog ();
                            break;
                            }
                    case "SubProjectNoteSearch":
                            {
                            if (List6.SelectedIndex == -1)
                                {
                                return;
                                }
                            //tblNotesCount: 0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done : FROM Notes INNER JOIN ...
                            Note.Type = "FocusNote";
                            Note.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [6]);
                            SubProject.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [5]);
                            var frmMindmap = new frmNoteNetEditor ();
                            frmMindmap.ShowDialog ();
                            break;
                            }
                    case "LinkNote":
                    case "LinkNoteSearch":
                            {
                            if (List55.SelectedIndex == -1)
                                {
                                return;
                                }
                            Note.Id = (int) List55.SelectedValue;
                            Note.Type = "LinkNote";
                            var frmMindmap = new frmNoteNetEditor ();
                            frmMindmap.ShowDialog ();
                            break;
                            }
                    case "RefNote":
                    case "RefNoteSearch":
                            {
                            if (List15.SelectedIndex == -1)
                                {
                                return;
                                }
                            Note.Id = (int) List15.SelectedValue;
                            Note.Type = "RefNote";
                            var frmMindmap = new frmNoteNetEditor ();
                            frmMindmap.ShowDialog ();
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error:\n" + ex.ToString ());
                }
            }
        //txtNote
        private void frmAssign_DoubleClick (object sender, EventArgs e)
            {
            txtNote.Enabled = true;
            txtNote.ForeColor = System.Drawing.Color.Black;
            lblStatusBar.Text = txtNote.Text.Length.ToString () + " / 4000";
            txtNote.Focus ();
            txtNote.SelectionStart = 0;
            txtNote.SelectionLength = 0;
            }
        private void txtNote_DoubleClick (object sender, EventArgs e)
            {
            txtNote.Enabled = false;
            lblStatusBar.Text = "";
            }
        private void txtNote_TextChanged (object sender, EventArgs e)
            {
            lblStatusBar.Text = txtNote.Text.Length.ToString () + " / 4000";
            if (Strings.Right (txtNote.Text, 4).ToLower () == "save")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.Text.Length - 4);
                SaveTheNote ();
                }
            }
        private void MenuTextNote_Save_Click (object sender, EventArgs e)
            {
            SaveTheNote ();
            }
        //methods
        private void ShowNoteInTextBox ()
            {
            txtNote.Text = Note.NoteText;
            if (Note.Rtl == true)
                {
                txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                txtNote.Font = new System.Drawing.Font ("Tahoma", 9);
                }
            else
                {
                txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
                txtNote.Font = new System.Drawing.Font ("Consolas", 9);
                }
            lblStatusBar.Text = txtNote.Text.Length.ToString () + " / 4000";
            txtNote.Enabled = false;
            }
        private void SaveTheNote ()
            {
            if (txtNote.TextLength > 3999)
                {
                txtNote.ForeColor = System.Drawing.Color.IndianRed;
                lblStatusBar.Text = "Note text lenght is: " + txtNote.Text.Length.ToString () + " / 4000";
                return;
                }
            if (string.IsNullOrEmpty (Strings.Trim (txtNote.Text)))
                {
                txtNote.Focus ();
                return;
                }

            Note.SaveNote (Note.Id, txtNote.Text, Note.DateTime, true, Note.Done);
            switch (Note.Type)
                {
                case "SubProjectNote":
                        {
                        Db.DS.Tables ["tblSNotes"].Rows [List6.SelectedIndex] [2] = txtNote.Text;
                        break;
                        }
                case "SubProjectNoteSearch":
                        {
                        //tblNotesCount: 0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done : FROM Notes INNER JOIN ...
                        Db.DS.Tables ["tblNotesCount"].Rows [List6.SelectedIndex] [3] = txtNote.Text;
                        break;
                        }
                case "LinkNote":
                case "LinkNoteSearch":
                        {
                        Db.DS.Tables ["tblLNotes"].Rows [List55.SelectedIndex] [2] = txtNote.Text;
                        break;
                        }
                case "RefNote":
                case "RefNoteSearch":
                        {
                        Db.DS.Tables ["tblRNotes"].Rows [List15.SelectedIndex] [2] = txtNote.Text;
                        break;
                        }
                }
            txtNote.Enabled = false;
            lblStatusBar.Text = "";
            }
        private void ChangeInterface ()
            {
            Dispose ();
            var frmeLibD = new frmAssign2 ();
            frmeLibD.ShowDialog ();
            }
        //FormCloseBox
        private void frmeLibAssign_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (e.CloseReason == CloseReason.UserClosing)
                {
                e.Cancel = true;
                }
            }
        //LogOut
        private void Menu3_Logout_Click (object sender, EventArgs e)
            {
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            }
        private void Menu5_Exit_Click (object sender, EventArgs e)
            {
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            }
        private void Menu1_Exit_Click (object sender, EventArgs e)
            {
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            }
        //Quit
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            Db.CloseDbAndExitTheApp ();
            }
        private void Menu1_Quit_Click (object sender, EventArgs e)
            {
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            Db.CloseDbAndExitTheApp ();
            }
        private void Menu5_Quit_Click (object sender, EventArgs e)
            {
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            Db.CloseDbAndExitTheApp ();
            }
        private void lblQuit_Click (object sender, EventArgs e)
            {
            //LOWER vertical label along RIGHT side of the form
            Client.Interface = 1;
            Assign.SetDefaultUserInterface (1);
            Dispose ();
            Db.CloseDbAndExitTheApp ();
            }
        }
    }