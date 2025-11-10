using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmUpcomingNotes : Form
        {
        public frmUpcomingNotes ()
            {
            InitializeComponent ();
            }
        int intGridExpandWidth = 893; int intGridShrinkWidth = 465; //txtNote widths
        private void frmUpcomingNotes_Load (object sender, EventArgs e)
            {
            Width = 1300;
            Height = 677;
            Text = Report.Caption + "  -  " + User.Name + "  -  " + DateTime.Now.ToString ("yyyy - MM - dd  .  HH : mm");
            int intYear = Convert.ToInt32 (DateTime.Now.ToString ("yyyy").ToString ());
            if (intYear < 1450)
                {
                mntCal.RightToLeft = RightToLeft.Yes;
                mntCal.RightToLeftLayout = true;
                }
            else
                {
                mntCal.RightToLeft = RightToLeft.No;
                mntCal.RightToLeftLayout = false;
                }
            //
            ResetMenuSearch ();
            Grid6.Width = intGridExpandWidth;
            try
                {
                Grid6.DataSource = Db.DS.Tables ["tblNotesCount"];
                for (int i = 0, loopTo = Grid6.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                    {
                    Grid6.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                //grid columns total:992px
                Grid6.Columns [0].Width = 155;       //Project
                Grid6.Columns [1].Width = 190;       //SubProject
                Grid6.Columns [2].Width = 120;       //Datum
                Grid6.Columns [3].Width = 380;       //Note 
                Grid6.Columns [4].Visible = false;   //Projects.ID
                Grid6.Columns [5].Visible = false;   //SubProjects.ID
                Grid6.Columns [6].Visible = false;   //Notes.ID
                Grid6.Columns [7].Width = 30;        //Done
                Grid6.Columns [8].Visible = false;   //RTL
                //wrap lines (if row-height be adjusted): Grid6.Columns [3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                HighlightGridRows ();
                Grid6.Focus ();
                SetEditNoteMode (0);
                SetFormTitle (Report.Caption + "  -  " + User.Name + "  -  " + DateTime.Now.ToString ("yyyy - MM - dd  .  HH : mm"));
                }
            catch (Exception ex)
                {
                //MessageBox.Show ("Error in Form Load:\n\n" + ex.ToString ());
                }
            }
        private void HighlightGridRows ()
            {
            int rx = 0;
            string tmpDate = "";
            mntCal.RemoveAllBoldedDates ();
            mntCal.UpdateBoldedDates ();
            foreach (DataRow r in Db.DS.Tables ["tblNotesCount"].Rows)
                {
                rx++;
                tmpDate = Strings.Left (r ["NoteDatum"].ToString (), 10);
                mntCal.AddBoldedDate (Conversions.ToDate (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                //Day0 (today)
                if (Strings.Left (r ["NoteDatum"].ToString (), 10) == DateTime.Now.ToString ("yyyy-MM-dd"))
                    Grid6.Rows [rx - 1].DefaultCellStyle.Font = new System.Drawing.Font (Grid6.Font, FontStyle.Bold);
                //Day+1
                if (Strings.Left (r ["NoteDatum"].ToString (), 10) == DateTime.Now.AddDays (+1).ToString ("yyyy-MM-dd"))
                    Grid6.Rows [rx - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.IndianRed;
                //Day+2
                if (Strings.Left (r ["NoteDatum"].ToString (), 10) == DateTime.Now.AddDays (+2).ToString ("yyyy-MM-dd"))
                    Grid6.Rows [rx - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
                //Day+3
                if (Strings.Left (r ["NoteDatum"].ToString (), 10) == DateTime.Now.AddDays (+3).ToString ("yyyy-MM-dd"))
                    Grid6.Rows [rx - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
                //Day+4
                if (Strings.Left (r ["NoteDatum"].ToString (), 10) == DateTime.Now.AddDays (+4).ToString ("yyyy-MM-dd"))
                    Grid6.Rows [rx - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.SteelBlue;
                //Day+5
                if (Strings.Left (r ["NoteDatum"].ToString (), 10) == DateTime.Now.AddDays (+5).ToString ("yyyy-MM-dd"))
                    Grid6.Rows [rx - 1].DefaultCellStyle.ForeColor = System.Drawing.Color.Peru;
                }
            mntCal.UpdateBoldedDates ();
            }
        private void ResetMenuSearch ()
            {
            Menu_ShowNDays.Text = " Show n days ";
            Menu_ShowNDays.SelectionStart = 0;
            Menu_ShowNDays.SelectionLength = Menu_ShowNDays.Text.Length;
            }
        //grid and text
        private void Grid6_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                e.SuppressKeyPress = true;
                SelectTheNoteAndExit ();
                }
            else if ((e.KeyCode == Keys.Right) && (Grid6.SelectedRows [0].Index != -1))
                {
                e.SuppressKeyPress = true;
                if (Grid6.Width == intGridExpandWidth)
                    {
                    SetEditNoteMode (1); //0:ListNotes 1:EditNote 2:JustShowTheNote
                    }
                else if (Grid6.Width == intGridShrinkWidth)
                    {
                    SetEditNoteMode (2);
                    }
                }
            else if ((e.KeyCode == Keys.Left) && (Grid6.SelectedRows [0].Index != -1))
                {
                e.SuppressKeyPress = true;
                SetEditNoteMode (0);
                }
            }
        private void Grid6_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            //0Project  1SubProject  2Datum 3Note  4Projects.ID(hide)  5SubProjects.ID(hide)  6Notes.ID(hide)  7Done
            string tmpDate = Grid6 [2, Grid6.SelectedRows [0].Index].Value.ToString ();
            mntCal.SetDate (Conversions.ToDate (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
            switch (e.ColumnIndex)
                {
                case 0:
                case 1:
                case 7:
                        {
                        SetEditNoteMode (0);
                        break;
                        }
                case 2:
                        {
                        ShowNote ();
                        SetEditNoteMode (1);
                        break;
                        }
                case 3:
                        {
                        ShowNote ();
                        SetEditNoteMode (2);
                        break;
                        }
                default:
                        {
                        ShowNote ();
                        SetEditNoteMode (1);
                        break;
                        }
                }
            }
        private void Grid6_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            //0Project  1SubProject  2Datum 3Note  4Projects.ID(hide)  5SubProjects.ID(hide)  6Notes.ID(hide)  7Done
            switch (e.ColumnIndex)
                {
                case 0: //project
                        {
                        SetEditNoteMode (0);
                        break;
                        }
                case 1: //subproject
                        {
                        if (Grid6.SelectedRows [0].Index == -1)
                            {
                            return;
                            }
                        DialogResult myansw = MessageBox.Show ("Replace this note?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (myansw == DialogResult.No)
                            return;
                        SubProject.Id = (int) Grid6 [5, Grid6.SelectedRows [0].Index].Value;
                        Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
                        My.MyProject.Forms.frmChooseProject.ShowDialog ();
                        //replace current SubProjectNote to selected SubProject
                        if (Client.DialogRequestParams == 32) //2: A SubProjects is selected from dialog
                            {
                            Note.Id = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
                            Db.strSQL = "UPDATE Notes SET Parent_ID=@parentid WHERE ID=@id";
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmd.Parameters.AddWithValue ("@parentid", SubProject.Id.ToString ());
                                cmd.Parameters.AddWithValue ("@id", Note.Id.ToString ());
                                try
                                    {
                                    int i = cmd.ExecuteNonQuery ();
                                    }
                                catch (Exception ex)
                                    {
                                    MessageBox.Show (ex.ToString ());
                                    }
                                CnnSS.Close ();
                                }
                            FocusNotes ();
                            Grid6.Focus ();
                            }
                        break;
                        }
                case 2: //datum
                        {
                        Note.DateTime = Grid6 [2, Grid6.SelectedRows [0].Index].Value.ToString ();
                        var frmTMDT = new frmTimeAndDate ();
                        frmTMDT.ShowDialog ();
                        if (Client.DialogRequestParams == 16)
                            {
                            Note.Id = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
                            //do UPDATE...
                            Assign.UpdateDateTime (Note.Id, Note.DateTime);
                            Note.GetSNotesFromDB ("all");
                            HighlightGridRows ();
                            Grid6.Focus ();
                            mntCal.SetDate (Conversions.ToDate (Strings.Mid (Note.DateTime, 1, 4) + "/" + Strings.Mid (Note.DateTime, 6, 2) + "/" + Strings.Mid (Note.DateTime, 9, 2)));
                            }
                        break;
                        }

                case 3: //Note
                        {
                        SetEditNoteMode (2);
                        break;
                        }
                case 7: //done
                        {
                        if (Grid6.SelectedRows [0].Index == -1)
                            {
                            return;
                            }
                        bool intDone = false;
                        if ((bool) Grid6 [7, Grid6.SelectedRows [0].Index].Value == false)
                            {
                            intDone = true;
                            }
                        else
                            {
                            intDone = false;
                            }
                        Note.Id = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
                        Db.strSQL = "UPDATE Notes SET Done=@done WHERE ID=@id";
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            CnnSS.Open ();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                            cmd.Parameters.AddWithValue ("@done", intDone.ToString ());
                            cmd.Parameters.AddWithValue ("@id", Note.Id.ToString ());
                            try
                                {
                                int i = cmd.ExecuteNonQuery ();
                                Grid6 [7, Grid6.SelectedRows [0].Index].Value = intDone;
                                }
                            catch (Exception ex)
                                {
                                MessageBox.Show (ex.ToString ());
                                }
                            CnnSS.Close ();
                            }
                        Grid6.Focus ();
                        break;
                        }
                }
            }
        private void Grid6_SelectionChanged (object sender, EventArgs e)
            {
            try
                {
                if ((Grid6.Rows.Count > 0) && (Grid6.SelectedRows [0].Index != -1))
                    {
                    string tmpDate = Grid6 [2, Grid6.SelectedRows [0].Index].Value.ToString ();
                    mntCal.SetDate (Conversions.ToDate (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                    int c = Grid6.SelectedColumns [0].Index;
                    if (c != 7)
                        {
                        //col7:Done (if col7 is clicked, keep grid6 expanded so a dblClick on Done checkBox be still possible)
                        ShowNote ();
                        if (Grid6.Width == intGridShrinkWidth)
                            {
                            SetEditNoteMode (1);
                            }
                        else
                            {
                            SetEditNoteMode (0);
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ()); 
                }
            }
        private void txtNote_TextChanged (object sender, EventArgs e)
            {
            if (Strings.Right (txtNote.Text, 5).ToLower () == "-save")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.Text.Length - 4);
                SaveNote ();
                SetEditNoteMode (2);
                }
            else
                {
                SetEditNoteMode (3);
                }
            }
        private void txtNote_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Escape)
                {
                e.SuppressKeyPress = true;
                SetEditNoteMode (0);
                }
            }
        private void mntCal_DateSelected (object sender, DateRangeEventArgs e)
            {
            string tmpDate = Conversions.ToString (mntCal.SelectionStart);
            tmpDate = Strings.Mid (tmpDate, 7) + "-" + Strings.Mid (tmpDate, 4, 2) + "-" + Strings.Left (tmpDate, 2);
            Note.DateTime = tmpDate;
            Note.GetSNotesFromDB ("oneday");
            SetFormTitle ("notes on: " + Note.DateTime);
            SetEditNoteMode (0);
            }
        //methods
        private void ShowNote ()
            {
            try
                {
                int r = Grid6.SelectedRows [0].Index;
                txtNote.Text = Grid6 [3, r].Value.ToString ();
                if (Convert.ToBoolean (Grid6.Rows [r].Cells [8].Value) == true)
                    {
                    //rtl
                    txtNote.RightToLeft = RightToLeft.Yes;
                    txtNote.Font = new Font ("Tahoma", 9);
                    Menu3_RTL.Checked = true;
                    }
                else
                    {
                    //ltr
                    txtNote.RightToLeft = RightToLeft.No;
                    txtNote.Font = new Font ("Consolas", 9);
                    Menu3_RTL.Checked = false;
                    }
                SetFormTitle (Report.Caption + "  -  " + User.Name + "  -  " + DateTime.Now.ToString ("yyyy - MM - dd  .  HH : mm"));
                txtNote.Enabled = false;
                txtNote.ScrollBars = ScrollBars.None;
                }
            catch (Exception ex)
                {
                MessageBox.Show ("SHOW NOTE\n" + ex.ToString ());
                }
            }
        private void SetEditNoteMode (int mode)
            {
            switch (mode)
                {
                case 0:
                        {
                        //ListNotes
                        txtNote.Enabled = false;
                        Grid6.Width = intGridExpandWidth;
                        txtNote.ScrollBars = ScrollBars.None;
                        Grid6.Focus ();
                        btn_Edit.Text = "Edit";
                        btn_Edit.ForeColor = Color.IndianRed;
                        btn_Edit.BackColor = Color.WhiteSmoke;
                        break;
                        }
                case 1:
                        {
                        //ShowNote
                        txtNote.Enabled = false;
                        Grid6.Width = intGridShrinkWidth;
                        txtNote.ScrollBars = ScrollBars.None;
                        Grid6.Focus ();
                        btn_Edit.Text = "Edit";
                        btn_Edit.ForeColor = Color.IndianRed;
                        btn_Edit.BackColor = Color.WhiteSmoke;
                        break;
                        }
                case 2:
                        {
                        //EditNote
                        txtNote.Enabled = true;
                        Grid6.Width = intGridShrinkWidth;
                        txtNote.SelectionStart = 0;
                        txtNote.SelectionLength = 0;
                        txtNote.ScrollBars = ScrollBars.Vertical;
                        txtNote.Focus ();
                        btn_Edit.Text = "List";
                        btn_Edit.ForeColor = Color.White;
                        btn_Edit.BackColor = Color.CornflowerBlue;
                        break;
                        }
                case 3:
                        {
                        //SaveNote
                        txtNote.Enabled = true;
                        Grid6.Width = intGridShrinkWidth;
                        txtNote.ScrollBars = ScrollBars.Vertical;
                        txtNote.Focus ();
                        btn_Edit.Text = "Save";
                        btn_Edit.ForeColor = Color.White;
                        btn_Edit.BackColor = Color.LightCoral;
                        break;
                        }
                }
            }
        private void SetFormTitle (string strTitle)
            {
            Text = strTitle;
            }
        private void SaveNote ()
            {
            //0Project 1SubProject 2Datum 3Note 4Projects.ID 5SubProjects.ID 6Notes.ID 7Done 8RTL
            try
                {
                //format: disable the textbox
                txtNote.Enabled = false;
                txtNote.ScrollBars = ScrollBars.None;
                //vars
                int r = Grid6.SelectedRows [0].Index;
                Note.Id = (int) Grid6 [6, r].Value;
                Note.DateTime = Grid6 [2, r].Value.ToString ();
                Note.NoteText = txtNote.Text;
                Note.Rtl = Convert.ToBoolean (txtNote.RightToLeft);
                //save
                Note.SaveNote (Note.Id, Note.NoteText, Note.DateTime, Note.Rtl, Note.Done);
                //refresh
                Db.DS.Tables ["tblNotesCount"].Rows [r] [3] = txtNote.Text.ToString ();
                Db.DS.Tables ["tblNotesCount"].Rows [r] [8] = Note.Rtl.ToString ();
                Grid6 [3, r].Value = txtNote.Text;
                Grid6 [8, r].Value = Note.Rtl.ToString ();
                SetEditNoteMode (1);
                Grid6.Focus ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("error:\n" + ex.ToString ());
                }
            }
        private void FocusNotes ()
            {
            //show postponeded and upcoming notes
            Note.GetSNotesFromDB ("all");
            HighlightGridRows ();
            SetFormTitle ("All: Postponeded and Upcoming");
            }
        //Menu-Calendar
        private void Menu2_AddANote_Click (object sender, EventArgs e)
            {
            //AddNewNote (string noteDateTime, string strNote, int parentId, int parentType, int userId)
            DateTime dt = mntCal.SelectionStart;
            Note.DateTime = dt.ToString ("yyyy-MM-dd . 08-30");
            Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            //add a note to selected SubProjectNote
            if (Client.DialogRequestParams == 32) //a subProjects is selected from dialog
                {
                Note.NoteText = "Proj.: " + Project.Name + " \\ Subproj.: " + SubProject.Name + "\r\n-------\r\nNew note [EDIT]";
                Assign.AddNewNote (Note.DateTime, Note.NoteText, SubProject.Id, 1, User.Id);
                SetFormTitle ("new note added to: " + Note.DateTime);
                Grid6.Focus ();
                Note.GetThisNote (Note.Id);
                Grid6.Rows [0].Cells [1].Selected = true;
                ShowNote ();
                SetEditNoteMode (2);
                }
            }
        private void Menu_AddToNewSpubProject_Click (object sender, EventArgs e)
            {
            if (Grid6.SelectedRows [0].Index == -1)
                {
                return;
                }
            else
                {
                Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
                My.MyProject.Forms.frmChooseProject.ShowDialog ();
                if (Client.DialogRequestParams == 32) //32: item is selected from dialog
                    {
                    try
                        {
                        int intNoteA = 0;
                        int intNoteB = 0;
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            CnnSS.Open ();
                            //grid6: 0Project 1SubProject 2Datum 3Note 4Projects.ID(hide) 5SubProjects.ID(hide) 6Notes.ID(hide) 7Done
                            Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared) VALUES (@notedatum, @note, @parentid, 1, @rtl, 0, @userid, 0); SELECT CAST(scope_identity() AS int)";
                            var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                            cmdx.CommandType = CommandType.Text;
                            cmdx.Parameters.AddWithValue ("@notedatum", Convert.ToString (Grid6 [2, Grid6.SelectedRows [0].Index].Value));
                            cmdx.Parameters.AddWithValue ("@note", "(noted again) \n" + Convert.ToString (Grid6 [3, Grid6.SelectedRows [0].Index].Value));
                            cmdx.Parameters.AddWithValue ("@parentid", SubProject.Id.ToString ());
                            cmdx.Parameters.AddWithValue ("@rtl", Note.Rtl);
                            cmdx.Parameters.AddWithValue ("@userid", User.Id.ToString ());
                            intNoteB = (int) cmdx.ExecuteScalar ();
                            CnnSS.Close ();
                            }
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            CnnSS.Open ();
                            intNoteA = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
                            Db.strSQL = "INSERT INTO NoteNet (NoteA_ID, NoteB_ID) VALUES (@noteaid, @notebid)";
                            var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                            cmd2.CommandType = CommandType.Text;
                            cmd2.Parameters.AddWithValue ("@noteaid", intNoteA.ToString ());
                            cmd2.Parameters.AddWithValue ("@notebid", intNoteB.ToString ());
                            int ix2 = cmd2.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        MessageBox.Show ("Note added to:\n\n" + SubProject.Name);
                        Grid6.Focus ();
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            }
        private void Menu_Show2Weeks_Click (object sender, EventArgs e)
            {
            try
                {
                Note.days = 0;
                Note.days = 14;
                Note.GetSNotesFromDB ("ndays");
                HighlightGridRows ();
                SetFormTitle ("two weeks");
                }
            catch
                {
                Note.days = 0;
                }
            ResetMenuSearch ();
            }
        private void Menu_Show3Weeks_Click (object sender, EventArgs e)
            {
            try
                {
                Note.days = 0;
                Note.days = 21;
                Note.GetSNotesFromDB ("ndays");
                HighlightGridRows ();
                SetFormTitle ("thtree weeks");
                }
            catch
                {
                Note.days = 0;
                }
            ResetMenuSearch ();
            }
        private void Menu_Show1Month_Click (object sender, EventArgs e)
            {
            try
                {
                Note.days = 0;
                Note.days = 31;
                Note.GetSNotesFromDB ("ndays");
                HighlightGridRows ();
                SetFormTitle ("one month");
                }
            catch
                {
                Note.days = 0;
                }
            ResetMenuSearch ();
            }
        private void Menu_Show2Months_Click (object sender, EventArgs e)
            {
            try
                {
                Note.days = 0;
                Note.days = 62;
                Note.GetSNotesFromDB ("ndays");
                HighlightGridRows ();
                SetFormTitle ("two months");
                }
            catch
                {
                Note.days = 0;
                }
            ResetMenuSearch ();
            }
        private void Menu_ShowUpcoming_Click (object sender, EventArgs e)
            {
            Note.GetSNotesFromDB ("upcoming");
            HighlightGridRows ();
            SetFormTitle ("Upcoming notes");
            }
        private void Menu_ShowPending_Click (object sender, EventArgs e)
            {
            Note.GetSNotesFromDB ("upcomingpending");
            HighlightGridRows ();
            SetFormTitle ("Pending notes");
            }
        private void Menu_ShowPostponded_Click (object sender, EventArgs e)
            {
            Note.GetSNotesFromDB ("postponeded");
            HighlightGridRows ();
            SetFormTitle ("Postponeded from past 10 days");
            }
        private void Menu_ShowNDays_Click (object sender, EventArgs e)
            {
            Menu_ShowNDays.SelectionStart = 0;
            Menu_ShowNDays.SelectionLength = Menu_ShowNDays.Text.Length;
            }
        private void Menu_ShowNDays_TextChanged (object sender, EventArgs e)
            {
            if (Menu_ShowNDays.Text.Trim () == "")
                {
                ResetMenuSearch ();
                }
            }
        private void Menu_ShowNDays_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                try
                    {
                    Note.days = 0;
                    Note.days = Convert.ToInt32 (Menu_ShowNDays.Text);
                    if ((Note.days != 0) && (Note.days < 94) && (Note.days > -94))
                        {
                        Note.GetSNotesFromDB ("ndays");
                        HighlightGridRows ();
                        SetFormTitle ("notes during <" + Note.days.ToString () + "> days");
                        }
                    else
                        {
                        return;
                        }
                    }
                catch
                    {
                    Note.days = 0;
                    }
                ResetMenuSearch ();
                e.SuppressKeyPress = true;
                }
            }
        private void Menu_Refs_Click (object sender, EventArgs e)
            {
            //exit
            SelectTheNoteAndExit ();
            }
        //Menu-Grid
        private void Menu_EditNote_Click (object sender, EventArgs e)
            {
            if ((Grid6.SelectedRows [0].Index != -1) && (txtNote.Enabled == false))
                {
                SetEditNoteMode (2);
                }
            else
                {
                SetEditNoteMode (0);
                }
            }
        private void Menu_ExpandNote_Click (object sender, EventArgs e)
            {
            if (Grid6.Width == intGridExpandWidth)
                {
                Grid6.Width = intGridShrinkWidth;
                }
            else
                {
                Grid6.Width = intGridExpandWidth;
                }
            }
        private void Menu_MoveToToday_Click (object sender, EventArgs e)
            {
            try
                {
                if (Grid6.SelectedRows [0].Index >= 0)
                    {
                    Note.Id = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
                    Note.DateTime = Grid6 [2, Grid6.SelectedRows [0].Index].Value.ToString ();
                    Note.PostpondNote (Note.Id, 0);
                    Note.GetSNotesFromDB ("all");
                    HighlightGridRows ();
                    SetFormTitle ("notes for: today + postponded + pending");
                    Grid6.Focus ();
                    }
                }
            catch { }
            }
        private void Menu_MoveToTomorrow_Click (object sender, EventArgs e)
            {
            try
                {
                if (Grid6.SelectedRows [0].Index >= 0)
                    {
                    Note.Id = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
                    Note.DateTime = Grid6 [2, Grid6.SelectedRows [0].Index].Value.ToString ();
                    Note.PostpondNote (Note.Id, 1);
                    Note.GetSNotesFromDB ("all");
                    HighlightGridRows ();
                    SetFormTitle ("notes for: today + postponded + pending");
                    Grid6.Focus ();
                    }
                }
            catch { }
            }
        private void Menu_MoveToNextWeek_Click (object sender, EventArgs e)
            {
            try
                {
                if (Grid6.SelectedRows [0].Index >= 0)
                    {
                    Note.Id = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
                    Note.DateTime = Grid6 [2, Grid6.SelectedRows [0].Index].Value.ToString ();
                    Note.PostpondNote (Note.Id, 7);
                    Note.GetSNotesFromDB ("all");
                    HighlightGridRows ();
                    SetFormTitle ("notes for: today + postponded + pending");
                    Grid6.Focus ();
                    }
                }
            catch { }
            }
        //search
        private void Menu_Search_Click (object sender, EventArgs e)
            {
            Menu_Search.SelectionStart = 0;
            Menu_Search.SelectionLength = Menu_Search.Text.Length;
            }
        private void Menu_Search_TextChanged (object sender, EventArgs e)
            {
            if (Menu_Search.Text.Trim () == "")
                {
                Menu_Search.Text = "Search...";
                Menu_Search.SelectionStart = 0;
                Menu_Search.SelectionLength = Menu_Search.Text.Length;
                }
            }
        private void Menu_Search_KeyDown (object sender, KeyEventArgs e)
            {
            if ((e.KeyCode == Keys.Enter) && Menu_Search.Text.Trim () != "")
                {
                e.SuppressKeyPress = true;
                Assign.DoSearchNotes (Menu_Search.Text.Trim (), 0); //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
                Grid6.Focus ();
                if (Grid6.Rows.Count > 0)
                    {
                    Grid6.Rows [0].Cells [1].Selected = true;
                    ShowNote ();
                    if (Grid6.Width == intGridShrinkWidth)
                        {
                        SetEditNoteMode (1);
                        }
                    else
                        {
                        SetEditNoteMode (0);
                        }
                    SetFormTitle (Grid6.Rows.Count.ToString () + " notes retrieved");
                    }
                else
                    {
                    SetFormTitle ("nothing found!");
                    }
                }
            }
        //tools
        private void Menu_Delete_Click (object sender, EventArgs e)
            {
            try
                {
                if (Grid6.SelectedRows [0].Index >= 0)
                    {
                    Note.Id = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
                    string result = Assign.DeleteNote (Note.Id, true); //true: get user confirmation
                    switch (result)
                        {
                        case "deleted":
                                {
                                SetFormTitle ("Deleted");
                                FocusNotes ();
                                Grid6.Focus ();
                                break;
                                }
                        case "notenet":
                                {
                                Menu_Mindmap_Click (null, null);
                                break;
                                }
                        case "error":
                                {
                                SetFormTitle ("Error!");
                                break;
                                }
                        case "cancelled":
                                {
                                SetFormTitle ("Cancelled");
                                break;
                                }
                        }
                    FocusNotes ();
                    Grid6.Focus ();
                    }
                }
            catch { }
            }
        private void Menu_Mindmap_Click (object sender, EventArgs e)
            {
            Mindmap ();
            }
        //Menu-TextBox
        private void Menu3_RTL_Click (object sender, EventArgs e)
            {
            //RTL-LTR
            if (txtNote.RightToLeft == RightToLeft.No)
                {
                //rtl
                txtNote.RightToLeft = RightToLeft.Yes;
                txtNote.Font = new Font ("Tahoma", 9);
                Menu3_RTL.Checked = true;
                }
            else
                {
                //ltr
                txtNote.RightToLeft = RightToLeft.No;
                txtNote.Font = new Font ("Consolas", 9);
                Menu3_RTL.Checked = false;
                }
            }
        private void Menu3_Save_Click (object sender, EventArgs e)
            {
            SaveNote ();
            }
        private void Menu3_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        //EXIT
        private void btn_Edit_Click (object sender, EventArgs e)
            {
            switch (btn_Edit.Text)
                {
                case "List":
                        {
                        SetEditNoteMode (0);
                        break;
                        }
                case "Edit":
                        {
                        if (Grid6.SelectedRows [0].Index != -1)
                            {
                            SetEditNoteMode (2);
                            }
                        break;
                        }
                case "Save":
                        {
                        SaveNote ();
                        break;
                        }
                default:
                        {
                        SetEditNoteMode (0);
                        break;
                        }
                }
            }
        private void Mindmap ()
            {
            try
                {
                if (Grid6.SelectedRows [0].Index != -1)
                    {
                    SubProject.Id = (int) Grid6 [5, Grid6.SelectedRows [0].Index].Value;
                    Note.Id = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
                    Note.Type = "FocusNote"; //this signal tells NoteNet that must use ["tblNotesCount"]
                    this.Dispose ();
                    var frmMindmap = new frmNoteNetEditor ();
                    frmMindmap.ShowDialog ();
                    }
                }
            catch { }
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 0; //bit5: 00010000: 0:cancel 1:ok
            Client.List5Mode = "";
            Dispose ();
            }
        private void btn_Mindmap_Click (object sender, EventArgs e)
            {
            Mindmap ();
            }
        private void btn_Assign_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void SelectTheNoteAndExit ()
            {
            //0 Project 1 SubProject 2 Datum 3 Note 4 Projects.ID(hide) 5 SubProjects.ID(hide) 6 Notes.ID(hide) 7 Done
            Project.Name = Grid6 [0, Grid6.SelectedRows [0].Index].Value.ToString ();
            Project.Id = (int) Grid6 [4, Grid6.SelectedRows [0].Index].Value;
            SubProject.Name = Grid6 [1, Grid6.SelectedRows [0].Index].Value.ToString ();
            SubProject.Id = (int) Grid6 [5, Grid6.SelectedRows [0].Index].Value;
            Note.DateTime = Grid6 [2, Grid6.SelectedRows [0].Index].Value.ToString ();
            Note.Id = (int) Grid6 [6, Grid6.SelectedRows [0].Index].Value;
            Client.List5Mode = "SubProjectNote";
            Client.DialogRequestParams = 16; //bit5: 00010000: 0:cancel 1:ok
            Dispose ();
            }
        }
    }
