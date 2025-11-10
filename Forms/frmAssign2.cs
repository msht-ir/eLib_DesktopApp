using Microsoft.VisualBasic;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmAssign2 : System.Windows.Forms.Form
        {
        int currentActiveMode = 0;
        public frmAssign2 ()
            {
            InitializeComponent ();
            }
        //form
        private void frmAssign2_Load (object sender, EventArgs e)
            {
            //this form's name is: Assign2
            //UserTypes: Admin | Guest | User
            Width = 1300;
            Height = 677;
            //calender setup
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
            this.StartPosition = FormStartPosition.CenterScreen;
            Assign.DoInitializeTheTables ();
            string Datum = DateTime.Now.ToString ("yyyy - MM - dd  .  HH : mm");
            Text = Report.Caption + "  -  " + User.Name + "  -  " + Datum;
            this.Show ();
            ShowUpcomingNotes (0); //0:just hilight leds, 1:also feed data in grid-b
            if (User.NotesDay0 > 0)
                {
                lblDay0_Click (null, null);
                }
            //My.MyProject.Forms.frmFolderRefs.ShowDialog ();
            ShowProjectsInTreeA (User.Id, 0, ""); //0:active 1:inactive 2:all 3:search
            MenuA_ShowActive.Checked = true;
            MenuA_ShowInactive.Checked = false;
            MenuA_ShowAll.Checked = false;
            SetMode (64);
            if (TreeA.Nodes.Count == 0)
                {
                lblStatusBar.Text = "Right-click on the list at left, then add a project";
                }
            else
                {
                lblStatusBar.Text = "Welcome! F1: projects, F2: search, F3: notes, F5: refs and links, F6: upcoming notes, F7: logout, exit: click right edge";
                }
            lblListA.Text = "Projects";
            lblGridB.Text = "";
            lblDatum.Text = "";
            //ImR
            Assign.GetImportantRefs ("ImR");
            GridC.DataSource = Db.DS.Tables ["tblRefs"];
            SetMode (29);
            txtSearch.Focus ();
            if (GridC.Rows.Count > 0)
                {
                lblStatusBar.Text = "You have set these documents aside for reading...";
                }
            SetMenuTreeA ("Projects");
            }
        private void frmAssign2_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode.ToString ())
                {
                case "F1":
                        {
                        //0:active 1:inactive 2:all 3:search
                        if (MenuA_ShowActive.Checked == true)
                            {
                            ShowProjectsInTreeA (User.Id, 0, ""); //0:active
                            }
                        else if (MenuA_ShowInactive.Checked == true)
                            {
                            ShowProjectsInTreeA (User.Id, 1, ""); //1:inactive
                            }
                        else
                            {
                            ShowProjectsInTreeA (User.Id, 2, ""); //2:all
                            }
                        //locate item 0
                        ExpandFirstProjectInTreeA ();
                        break;
                        }
                case "F2":
                        {
                        if (txtSearch.Focused)
                            {
                            TreeA.Focus ();
                            lblStatusBar.Text = "Projects and SubProjects ...";
                            }
                        else
                            {
                            txtSearch.Focus ();
                            txtSearch.SelectionStart = 0;
                            txtSearch.SelectionLength = txtSearch.TextLength;
                            lblStatusBar.Text = "Enter search keys / -commands ...";
                            }
                        break;
                        }
                case "F3":
                        {
                        GridB.Focus ();
                        break;
                        }
                case "F4":
                        {
                        if (txtNote.Visible == true)
                            {
                            CloseInlineNoteEditor ();
                            GridB.Focus ();
                            }
                        else
                            {
                            txtNote.Text = "";
                            txtNote.Visible = true;
                            }
                        break;
                        }
                case "F5":
                        {
                        GridC.Focus ();
                        break;
                        }
                case "F6":
                        {
                        ShowUpcomingNotes (1);
                        GridB.Focus ();
                        break;
                        }
                case "F7":
                        {
                        lblLogout_Click (null, null);
                        break;
                        }
                case "F10":
                        {
                        Augustusmate ();
                        break;
                        }
                }
            //e.SuppressKeyPress = true;
            }
        private void frmAssign2_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (e.CloseReason == CloseReason.UserClosing)
                {
                //also: UPPER vertical label along RIGHT side of the form
                Client.Interface = 2;
                Assign.SetDefaultUserInterface (2);
                Dispose ();
                My.MyProject.Forms.frmCNN.ShowDialog ();
                //e.Cancel = true;
                }
            }
        //Tree-A
        private void TreeA_AfterSelect (object sender, TreeViewEventArgs e)
            {
            //MessageBox.Show ("index:" + TreeA.SelectedNode.Index.ToString () + "   /level: " + TreeA.SelectedNode.Level.ToString () + "   /text: " + TreeA.SelectedNode.Text + "   /tag: " + TreeA.SelectedNode.Tag);
            lblDatum.Text = "";
            if (TreeA.SelectedNode != null)
                {
                TreeA.SelectedNode.ExpandAll ();
                }
            switch (TreeA.SelectedNode.Level)
                {
                case 0: //A: Project
                        {
                        Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                        Project.Name = TreeA.SelectedNode.Text;
                        GridB.DataSource = null;
                        GridC.DataSource = null;
                        SetMode (64);
                        lblListA.Text = TreeA.SelectedNode.Text;
                        break;
                        }
                case 1: //A: SubProject
                        {
                        CloseInlineNoteEditor ();
                        SubProject.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                        ShowSNotesInGridB_LinksInGridC (SubProject.Id);
                        SetMode (50);
                        lblListA.Text = TreeA.SelectedNode.Text;
                        TreeA.Focus ();
                        break;
                        }
                }
            }
        private void TreeA_DoubleClick (object sender, EventArgs e)
            {
            TreeA_AfterSelect (null, null);
            }
        private void mntCal_DateSelected (object sender, DateRangeEventArgs e)
            {
            string tmpDate = mntCal.SelectionStart.ToString ();
            tmpDate = Strings.Mid (tmpDate, 7, 4) + "-" + Strings.Mid (tmpDate, 4, 2) + "-" + Strings.Left (tmpDate, 2);
            Note.DateTime = tmpDate;
            Note.GetSNotesFromDB ("oneday");
            TreeA.Nodes.Clear ();
            GridC.DataSource = null;
            GridB.DataSource = null;
            GridB.DataSource = Db.DS.Tables ["tblNotesCount"];
            SetMode (4); //A:- B:FNotes
            }
        //Grid-B
        private void GridB_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Left:
                        {
                        e.SuppressKeyPress = true;
                        if (txtNote.Visible == true)
                            {
                            CloseInlineNoteEditor ();
                            }
                        else
                            {
                            CloseInlineNoteEditor ();
                            TreeA.Focus ();
                            switch (Assign.Mode)
                                {
                                case 64: //A: P
                                        {
                                        GridB.DataSource = null;
                                        GridC.DataSource = null;
                                        lblGridB.Text = "";
                                        lblDatum.Text = "";
                                        TreeA.Focus ();
                                        SetMode (64);
                                        break;
                                        }
                                case 32: //A:SP B:- 
                                case 50: //A:SP B:SNotes
                                        {
                                        GridB.DataSource = null;
                                        GridC.DataSource = null;
                                        lblGridB.Text = "";
                                        lblDatum.Text = "";
                                        TreeA.Focus ();
                                        SetMode (32);
                                        break;
                                        }
                                case 16: //A:- B:SNotes ?
                                        {
                                        GridB.DataSource = null;
                                        GridC.DataSource = null;
                                        lblGridB.Text = "";
                                        lblDatum.Text = "";
                                        SetMode (64);
                                        break;
                                        }
                                case 42: //A:SP B:LNotes
                                        {
                                        GridB.DataSource = null;
                                        GridC.DataSource = null;
                                        lblGridB.Text = "";
                                        lblDatum.Text = "";
                                        SetMode (32);
                                        break;
                                        }
                                case 29:  //A:-  B:SLR-Notes
                                        {
                                        GridC.Focus ();
                                        break;
                                        }
                                case 5: //A:- B:RNotes
                                        {
                                        txtSearch.Focus ();
                                        txtSearch.SelectionStart = 0;
                                        txtSearch.SelectionLength = txtSearch.TextLength;
                                        lblGridB.Text = "";
                                        lblDatum.Text = "";
                                        SetMode (0);
                                        break;
                                        }
                                }
                            }
                        break;
                        }
                case Keys.Right:
                        {
                        e.SuppressKeyPress = true;
                        if (GridB.Rows.Count > 0)
                            {
                            GridB_CellClick (null, null);
                            }
                        else
                            {
                            switch (Assign.Mode)
                                {
                                case 50: //B:SNote C:Link
                                case 42: //B:LNote C:Link
                                case 5:  //B:RNote C:Refs
                                        {
                                        GridC.Focus ();
                                        break;
                                        }
                                default:
                                        {
                                        //goto txtSearch
                                        txtSearch.Focus ();
                                        txtSearch.SelectionStart = 0;
                                        txtSearch.SelectionLength = txtSearch.Text.Length;
                                        break;
                                        }
                                }
                            }
                        break;
                        }
                case Keys.Enter:
                        {
                        e.SuppressKeyPress = true;
                        GridB_CellDoubleClick (null, null);
                        break;
                        }
                case Keys.Escape:
                        {
                        CloseInlineNoteEditor ();
                        GridB.DataSource = null;
                        GridC.DataSource = null;
                        TreeA.Focus ();
                        SetMode (64);
                        break;
                        }
                }
            }
        private void GridB_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            try
                {
                if ((GridB.Rows.Count == 0) || (GridB.SelectedRows [0].Index == -1))
                    {
                    lblStatusBar.Text = "Select an item!";
                    return;
                    }
                else
                    {
                    int r = (int) GridB.SelectedRows [0].Index;
                    switch (Assign.Mode)
                        {
                        case 50: //A:SP B:SNotes
                        case 16: //A:-  B:SNotes ?
                        case 42: //A:SP B:LNotes
                        case 29: //A:-  B:SLRNotes
                        case 5:  //A:-  B:RNotes
                                {
                                string tmpDate = GridB [1, GridB.SelectedRows [0].Index].Value.ToString ();
                                mntCal.SetDate (DateTime.Parse (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                                //Edit SLR-Note {0:ID, 1:NoteDatum, 2:Note, 3:Parent_ID, 4:ParentType, 5:Rtl, 6:Done, 7:User_ID, 8:Shared}
                                Note.Id = Convert.ToInt32 (GridB.Rows [r].Cells [0].Value);
                                Note.Done = Convert.ToBoolean (GridB.Rows [r].Cells [6].Value);
                                Note.ParentType = Convert.ToInt32 (GridB.Rows [r].Cells [4].Value);
                                switch (GridB.CurrentCell.ColumnIndex)
                                    {
                                    case 6:
                                            {
                                            if (Note.Done)
                                                {
                                                Note.SetNoteStatusDone (Note.Id, false);
                                                }
                                            else
                                                {
                                                Note.SetNoteStatusDone (Note.Id, true);
                                                }
                                            GridB.Rows [r].Cells [6].Value = Note.Done;
                                            return;
                                            }
                                    default:
                                            {
                                            Note.Index = r;
                                            Note.DateTime = GridB.Rows [r].Cells [1].Value.ToString ();
                                            lblDatum.Text = Note.DateTime;
                                            Note.Rtl = Convert.ToBoolean (GridB.Rows [r].Cells [5].Value);
                                            Note.Done = Convert.ToBoolean (GridB.Rows [r].Cells [6].Value);
                                            string snote = GridB.Rows [r].Cells [2].Value.ToString ();
                                            //lblStatusBar.Text = snote;
                                            ShowTextInInlineEditor (snote, Note.Rtl, Note.Done, false); //false:dont focus on txtNote
                                            break;
                                            }
                                    }
                                break;
                                }
                        case 4:  //A:-  B:F-Notes -abandoned
                                {
                                string tmpDate = GridB [2, GridB.SelectedRows [0].Index].Value.ToString ();
                                mntCal.SetDate (DateTime.Parse (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                                //Edit SNote {0:ProjectName, 1:SubProjectName, 2:NoteDatum, 3:Note, 4:Projects.ID, 5:SubProjects.ID, 6:Notes.ID, 7:Done, 8:Rtl}
                                Note.Id = Convert.ToInt32 (GridB.Rows [r].Cells [6].Value);
                                Note.Done = Convert.ToBoolean (GridB.Rows [r].Cells [7].Value);
                                switch (GridB.CurrentCell.ColumnIndex)
                                    {
                                    case 7:
                                            {
                                            if (Note.Done)
                                                {
                                                Note.SetNoteStatusDone (Note.Id, false);
                                                }
                                            else
                                                {
                                                Note.SetNoteStatusDone (Note.Id, true);
                                                }
                                            GridB.Rows [r].Cells [7].Value = Note.Done;
                                            return;
                                            }
                                    default:
                                            {
                                            Note.Index = r;
                                            Note.DateTime = GridB.Rows [r].Cells [2].Value.ToString ();
                                            lblDatum.Text = Note.DateTime;
                                            Note.Done = Convert.ToBoolean (GridB.Rows [r].Cells [7].Value);
                                            Note.Rtl = Convert.ToBoolean (GridB.Rows [r].Cells [8].Value);
                                            string snote = GridB.Rows [r].Cells [3].Value.ToString ();
                                            //lblStatusBar.Text = snote;
                                            ShowTextInInlineEditor (snote, Note.Rtl, Note.Done, false); //false:dont focus on txtNote
                                            break;
                                            }
                                    }
                                break;
                                }
                        }
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        private void GridB_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if ((GridB.Rows.Count == 0) || (GridB.SelectedRows [0].Index == -1))
                {
                lblStatusBar.Text = "Select an item!";
                return;
                }
            else
                {
                CloseInlineNoteEditor ();
                //-- alternaet code
                //int r = (int) GridB.SelectedRows [0].Index;
                //switch (Assign.Mode)
                //    {
                //    case 50:  //A:SP  B:SNotes
                //    case 16:  //A:-   B:SNotes ?
                //    case 42:  //A:SP  B:LNotes
                //    case 5:   //A:-   B:RNotes
                //    case 29:  //A:-   B:SLRNotes
                //            {
                //            //Edit SNote
                //            Note.Index = r;
                //            Note.Id = Convert.ToInt32 (GridB.Rows [r].Cells [0].Value);
                //            Note.DateTime = GridB.Rows [r].Cells [1].Value.ToString ();
                //            lblDatum.Text = Note.DateTime;
                //            Note.Rtl = Convert.ToBoolean (GridB.Rows [r].Cells [5].Value);
                //            Note.Done = Convert.ToBoolean (GridB.Rows [r].Cells [6].Value);
                //            string snote = GridB.Rows [r].Cells [2].Value.ToString ();
                //            lblStatusBar.Text = snote;
                //            ShowTextInInlineEditor (snote, Note.Rtl, Note.Done, true); //true:focus on txtNote
                //            break;
                //            }
                //    case 4:   //A:-   B:F-Notes ?
                //            {
                //            //Edit FNote {0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done, 8Rtl}
                //            Note.Index = r;
                //            Note.Id = Convert.ToInt32 (GridB.Rows [r].Cells [6].Value);
                //            Note.DateTime = GridB.Rows [r].Cells [2].Value.ToString ();
                //            lblDatum.Text = Note.DateTime;
                //            Note.Done = Convert.ToBoolean (GridB.Rows [r].Cells [7].Value);
                //            Note.Rtl = Convert.ToBoolean (GridB.Rows [r].Cells [8].Value);
                //            string snote = GridB.Rows [r].Cells [3].Value.ToString ();
                //            lblStatusBar.Text = snote;
                //            ShowTextInInlineEditor (snote, Note.Rtl, Note.Done, true); //true:focus on txtNote
                //            break;
                //            }
                //    }
                }
            }
        private void GridB_DragEnter (object sender, DragEventArgs e)
            {
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void GridB_DragDrop (object sender, DragEventArgs e)
            {
            if ((Assign.Mode != 50) && (Assign.Mode != 42))
                {
                return;
                }
            else
                {
                string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
                eLibFile.strFilex = strFiles [0];
                FileInfo MyFile = new FileInfo (strFiles [0]);
                if (MyFile.Extension.ToLower () != ".txt")
                    {
                    return;
                    }
                //create new SLR-Note for current noteParent
                string text = System.IO.File.ReadAllText (eLibFile.strFilex);
                e.Effect = DragDropEffects.None;
                string strDateTime = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
                int r = (int) GridB.SelectedRows [0].Index;
                switch (Assign.Mode)
                    {
                    case 50:// s-note
                            {
                            SubProject.Id = Convert.ToInt32 (GridB.Rows [r].Cells [3].Value);
                            Assign.AddNewNote (strDateTime, Strings.Left (text, 3998), SubProject.Id, 1, User.Id);
                            break;
                            }
                    case 42: //l-note
                            {
                            Link.Id = Convert.ToInt32 (GridB.Rows [r].Cells [3].Value);
                            Assign.AddNewNote (strDateTime, Strings.Left (text, 3998), Link.Id, 2, User.Id);
                            break;
                            }
                    case 5: //r-note
                            {
                            Ref.Id = Convert.ToInt32 (GridB.Rows [r].Cells [3].Value);
                            Assign.AddNewNote (strDateTime, Strings.Left (text, 3998), Ref.Id, 3, User.Id);
                            break;
                            }
                    }
                ShowSNotesInGridB_LinksInGridC (SubProject.Id);
                }
            }
        private void GridB_SelectionChanged (object sender, EventArgs e)
            {
            //txtNote.Text = "";
            txtNote.Enabled = false;
            LED_Save.Visible = false;
            }
        //Grid-C
        private void GridC_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Left:
                        {
                        e.SuppressKeyPress = true;
                        switch (Assign.Mode)
                            {
                            case 50: //B:SNote C:Link
                            case 42: //B:LNote C:Link
                            case 5:  //B:RNote C:Refs
                                    {
                                    GridB.Focus ();
                                    break;
                                    }
                            default:
                                    {
                                    //goto txtSearch
                                    txtSearch.Focus ();
                                    txtSearch.SelectionStart = 0;
                                    txtSearch.SelectionLength = txtSearch.Text.Length;
                                    break;
                                    }
                            }
                        break;
                        }
                case Keys.Right:
                        {
                        e.SuppressKeyPress = true;
                        txtSearch.Focus ();
                        break;
                        }
                case Keys.Enter:
                        {
                        e.SuppressKeyPress = true;
                        GridC_CellDoubleClick (null, null);
                        break;
                        }
                case Keys.Escape:
                        {
                        e.SuppressKeyPress = true;
                        txtSearch.Focus ();
                        break;
                        }
                }
            }
        private void GridC_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            if (GridC.SelectedRows [0].Index != -1)
                {
                if ((GridC.Rows.Count == 0) || (GridC.SelectedRows [0].Index == -1))
                    {
                    lblStatusBar.Text = "Select an item!";
                    return;
                    }
                else
                    {
                    int r = (int) GridC.SelectedRows [0].Index;
                    GridB.DataSource = null;
                    switch (Assign.Mode)
                        {
                        case 50: //C:Link A:SP B:SNotes
                        case 42: //C:Link A:SP B:LNotes
                                {
                                //Show Notes for A Link {Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, SubProject_ID, Links.ID AS LinkID, Imp1, Imp2, Imp3, ImR}
                                Link.Id = Convert.ToInt32 (GridC.Rows [r].Cells [7].Value);
                                Assign.GetNotes (Link.Id, 2); //ParentTypes (get notes): 1:SNotes, 2:LNotes, 3:RNotes
                                GridB.DataSource = Db.DS.Tables ["tblLNotes"];
                                CloseInlineNoteEditor ();
                                SetMode (42);
                                lblGridB.Text = "Link Note";
                                lblStatusBar.Text = "";
                                break;
                                }
                        case 29: //C:Ref A:-  B:SLR-Notes ?
                        case 5:  //C:Ref A:-  B:RNotes
                                {
                                //Show Notes for A Ref {Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture}
                                Ref.Id = Convert.ToInt32 (GridC.Rows [r].Cells [0].Value);
                                Assign.GetNotes (Ref.Id, 3); //ParentTypes (get notes): 1:SNotes, 2:LNotes, 3:RNotes
                                CloseInlineNoteEditor ();
                                GridB.DataSource = Db.DS.Tables ["tblRNotes"];
                                SetMode (5);
                                lblGridB.Text = "Ref Note";
                                lblStatusBar.Text = "";
                                break;
                                }
                        }
                    //GET R-LINKS
                    Ref.Id = Convert.ToInt32 (GridC.SelectedRows [0].Cells [0].Value);
                    Assign.GetRLinks (Ref.Id);
                    int intRowcount = Db.DS.Tables ["tblAssignments"].Rows.Count;
                    if (intRowcount > 0)
                        {
                        string strLinkedSPs = "";
                        for (int i = 0; i < Db.DS.Tables ["tblAssignments"].Rows.Count; i++)
                            {
                            strLinkedSPs += Db.DS.Tables ["tblAssignments"].Rows [i] [3].ToString () + " | ";
                            }
                        lblStatusBar.Text = "Linked to: " + strLinkedSPs;
                        //notice: this string is used in line 1615 to show a messagebox of linked SPs
                        }
                    else
                        {
                        lblStatusBar.Text = "";
                        }
                    }
                }
            }
        private void GridC_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if ((GridC.Rows.Count == 0) || (GridC.SelectedRows [0].Index == -1))
                {
                lblStatusBar.Text = "Select an item!";
                return;
                }
            else
                {
                int r = (int) GridC.SelectedRows [0].Index;
                switch (Assign.Mode)
                    {
                    case 29: //C:Refs    B:xNotes      
                    case 5:  //C:Refs ?  B:RNotes 
                            {
                            lblStatusBar.Text = GridC.Rows [r].Cells [1].Value.ToString ();
                            Ref.Title = Strings.Trim (GridC.Rows [r].Cells [1].Value.ToString ());
                            if (!string.IsNullOrEmpty (Ref.Title))
                                {
                                My.MyProject.Forms.frmReadRef.ShowDialog ();
                                }
                            break;
                            }
                    case 50:  //C:Links B:SNotes
                    case 42:  //C:Links B:LNotes
                            {
                            lblStatusBar.Text = GridC.Rows [r].Cells [1].Value.ToString ();
                            Ref.Title = Strings.Trim (GridC.Rows [r].Cells [1].Value.ToString ());
                            if (!string.IsNullOrEmpty (Ref.Title))
                                {
                                My.MyProject.Forms.frmReadRef.ShowDialog ();
                                }
                            break;
                            }
                    }
                }

            }
        private void GridC_SelectionChanged (object sender, EventArgs e)
            {
            txtNote.Enabled = false;
            }
        //txt-Search
        private void txtSearch_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Enter:
                        {
                        e.SuppressKeyPress = true;
                        if (Strings.Left (txtSearch.Text.Trim (), 1) == "-")
                            {
                            //dont search (when - is entered for cmd)
                            return;
                            }
                        else if (string.IsNullOrEmpty (Strings.Trim (txtSearch.Text)))
                            {
                            txtSearch.Text = "";
                            return;
                            }
                        else
                            {
                            lblStatusBar.Text = "wait...";
                            Db.DS.Tables ["tblRefs"].Clear ();
                            Db.DS.Tables ["tblRNotes"].Clear ();
                            //do the search
                            string strSearchString = Strings.Trim (txtSearch.Text);
                            //1.search refs
                            GridC.DataSource = null;
                            Assign.DoSearchRefs (strSearchString);
                            GridC.DataSource = Db.DS.Tables ["tblRefs"];
                            //2.search notes
                            Assign.DoSearchNotes (strSearchString, 4); //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
                            GridB.DataSource = null;
                            GridB.DataSource = Db.DS.Tables ["tblRNotes"];
                            //setmode
                            CloseInlineNoteEditor ();
                            TreeA.CollapseAll ();
                            txtSearch.Focus ();
                            txtSearch.SelectionStart = 0;
                            txtSearch.SelectionLength = txtSearch.TextLength;
                            SetMode (29);
                            lblStatusBar.Text = "";
                            }
                        break;
                        }
                case Keys.Escape:
                        {
                        e.SuppressKeyPress = true;
                        txtSearch.Text = ""; //force search
                        break;
                        }
                case Keys.Down:
                        {
                        e.SuppressKeyPress = true;
                        if ((Assign.Mode == 29) || (Assign.Mode == 5))
                            {
                            if (GridB.Rows.Count > 0)
                                {
                                GridB.Focus ();
                                }
                            else if (GridC.Rows.Count > 0)
                                {
                                GridC.Focus ();
                                }
                            else
                                {
                                ShowProjectsInTreeA (User.Id, 2, ""); //2:all
                                }
                            }
                        else
                            {
                            TreeA.Focus ();
                            if (TreeA.Nodes.Count > 0)
                                {
                                if (TreeA.SelectedNode.Text != "")
                                    {
                                    //TreeA.SelectedNode = Project.Id;
                                    }
                                else
                                    {
                                    //ExpandFirstProjectInTreeA ();
                                    }
                                }
                            }
                        break;
                        }
                case Keys.Up:
                        {
                        e.SuppressKeyPress = true;
                        GridC.Focus ();
                        break;
                        }
                }
            }
        private void txtSearch_TextChanged (object sender, EventArgs e)
            {
            lblStatusBar.Text = "";
            if (Strings.Left (txtSearch.Text, 1) == "-")
                {
                lblSearch.Text = "cmd >";
                }
            else
                {
                lblSearch.Text = "search >";
                }
            switch (txtSearch.Text.Trim ().ToLower ())
                {
                case "-?":
                        {
                        txtSearch.Text = " -Upcoming, -Focus, -Date, -ImR, -Imp1-3, -Shelf, -Proj, -Fam, -Folder, -Import, -New, -Pass, -Scan";
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.TextLength;
                        break;
                        }
                case "-augustus":
                        {
                        Augustusmate ();
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-date":
                        {
                        MenuB_DateTime_Click (null, null);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-edit":
                        {
                        MenuB_Edit_Click (null, null);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.TextLength;
                        break;
                        }
                case "-exam":
                        {
                        WindowState = FormWindowState.Minimized;
                        System.Windows.Forms.Form frm_CourseExamTest = new frmCourseExamTest ();
                        frm_CourseExamTest.ShowDialog ();
                        WindowState = FormWindowState.Normal;
                        txtSearch.Text = "";
                        //txtSearch.SelectionStart = 0;
                        //txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-quit":
                case "-exit":
                        {
                        Client.Interface = 2;
                        Assign.SetDefaultUserInterface (2);
                        Dispose ();
                        Db.CloseDbAndExitTheApp ();
                        break;
                        }
                case "-face":
                        {
                        Dispose ();
                        System.Windows.Forms.Form Assign1 = new frmAssign ();
                        Assign1.ShowDialog ();
                        break;
                        }
                case "-fam":
                        {
                        ShowFamForSelectedNote ();
                        break;
                        }
                case "-focus":
                        {
                        ShowUpcomingNotes (1); //inclds setmenu
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-folder":
                case "-explore":
                        {
                        My.MyProject.Forms.frmFolderRefs.ShowDialog ();
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-help":
                        {
                        //En
                        Assign.ShowOfflineHelp ("En");
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-import":
                        {
                        Import ();
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-imp1":
                        {
                        Assign.GetImportantRefs ("Imp1");
                        GridC.DataSource = Db.DS.Tables ["tblRefs"];
                        SetMode (29);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-imp2":
                        {
                        Assign.GetImportantRefs ("Imp2");
                        GridC.DataSource = Db.DS.Tables ["tblRefs"];
                        SetMode (29);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-imp3":
                        {
                        Assign.GetImportantRefs ("Imp3");
                        GridC.DataSource = Db.DS.Tables ["tblRefs"];
                        SetMode (29);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-imr":
                        {
                        GridB.DataSource = null;
                        GridC.DataSource = null;
                        Assign.GetImportantRefs ("ImR");
                        GridC.DataSource = Db.DS.Tables ["tblRefs"];
                        SetMode (29);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-tag":
                        {
                        if ((Assign.Mode == 50) || (Assign.Mode == 42))
                            {
                            //50: A:subprojects  B:s-notes  C:links
                            //42: A:subprojects  B:l-notes  C:links
                            MenuC_Attributes_Click (null, null);
                            }
                        else
                            {
                            txtSearch.Text = "no link is selected!"; //"use Tag cmd for links";
                            }
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-logout":
                        {
                        Client.Interface = 2;
                        Assign.SetDefaultUserInterface (2);
                        Dispose ();
                        My.MyProject.Forms.frmCNN.ShowDialog ();
                        break;
                        }
                case "-mindmap":
                        {
                        MenuB_MindMap_Click (null, null);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.TextLength;
                        break;
                        }
                case "-new":
                        {
                        //word powerpoint excel textfile
                        string strcmd1 = "Create New: ";
                        string strcmd2 = " Project . Word . Excel . PowerPoint . Text";
                        txtSearch.Text = strcmd1 + strcmd2;
                        txtSearch.SelectionStart = strcmd1.Length;
                        txtSearch.SelectionLength = strcmd2.Length;
                        break;
                        }
                case "create new: project":
                        {
                        MenuA_AddNew_Click (null, null);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "create new: word":
                        {
                        Db.CreateNewRef (".docx");
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "create new: powerpoint":
                        {
                        Db.CreateNewRef (".pptx");
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "create new: excel":
                        {
                        Db.CreateNewRef (".xlsx");
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "create new: text":
                        {
                        Db.CreateNewRef (".txt");
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-pass":
                        {
                        Db.ChengePassword ();
                        //logout
                        Client.Interface = 2;
                        Assign.SetDefaultUserInterface (2);
                        Dispose ();
                        My.MyProject.Forms.frmCNN.ShowDialog ();
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-proj":
                case "-show":
                        {
                        //act, inact, all
                        string strcmd1 = "Show Projects: ";
                        string strcmd2 = "{ +Active | -Inactive | All }";
                        txtSearch.Text = strcmd1 + strcmd2;
                        txtSearch.SelectionStart = strcmd1.Length;
                        txtSearch.SelectionLength = strcmd2.Length;
                        break;
                        }
                case "show projects: +":
                        {
                        ShowProjectsInTreeA (User.Id, 0, "");
                        txtSearch.Focus ();
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "show projects: -":
                        {
                        ShowProjectsInTreeA (User.Id, 1, "");
                        txtSearch.Focus ();
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "show projects: a":
                        {
                        ShowProjectsInTreeA (User.Id, 2, "");
                        txtSearch.Focus ();
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-report":
                        {
                        string strHeader;
                        strHeader = "Report Selected/All Projects for User: ";
                        Assign.ReportProjects (strHeader);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-scan":
                        {
                        Client.Interface = 2;
                        Assign.SetDefaultUserInterface (2);
                        Dispose ();
                        My.MyProject.Forms.frmScan.ShowDialog ();
                        this.WindowState = FormWindowState.Normal;
                        lblStatusBar.Text = "SCAN finished successfully!";
                        break;
                        }
                case "-oldscan":
                        {
                        User.ValidateFolders ();
                        DialogResult myansw = (DialogResult) MessageBox.Show ("eLib Settings : \r\n" + "- \r\n" + "Papers ->   " + User.FolderPapers + "\r\n" + "Books ->   " + User.FolderBooks + "\r\n Manuals ->   " + User.FolderManuals + "\r\n Lectures ->   " + User.FolderLectures + "\r\n - \r\n \r\n" + "Scan current folders ?", "eLib", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        switch (myansw)
                            {
                            case DialogResult.OK:
                                    {
                                    lblStatusBar.Text = "Step 1/3 : Clear current file Paths . . .";
                                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                        {
                                        CnnSS.Open ();
                                        Db.ClearPapers ("Paths");
                                        CnnSS.Close ();
                                        }
                                    lblStatusBar.Text = "Step 2/3 : Scan eLib Folders . . .";
                                    Db.ScanNames (); // equals eLibTitles in old eLib versions
                                    lblStatusBar.Text = "Step 3/3 : Constructing new file Paths  . . .";
                                    Db.ScanPaths (); // equals eLibPaths in old eLib versions
                                    lblStatusBar.Text = "SCAN finished successfully!";
                                    Db.ReadSettingsAndUsers ();
                                    lblStatusBar.Text = "SCAN finished successfully!";
                                    MessageBox.Show ("SCAN finished successfully!", "eLib", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                    }
                            case DialogResult.Cancel:
                                    {
                                    break;
                                    }
                                // do nothing
                            }
                        break;
                        }
                case "-share":
                        {
                        if ((TreeA.SelectedNode != null) && (TreeA.SelectedNode.Level == 0))
                            {
                            Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            ShareAProject (Project.Id);
                            //refresh
                            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
                            SetMode (64);
                            }
                        else
                            {
                            lblStatusBar.Text = "Select a Project!";
                            txtSearch.SelectionStart = 0;
                            txtSearch.SelectionLength = txtSearch.Text.Length;
                            }
                        break;
                        }
                case "-shelf":
                        {
                        Assign.GetListOfRefs ();
                        GridC.DataSource = Db.DS.Tables ["tblRefs"];
                        //lblListA.Text = "Click: Projects";
                        lblGridC.Text = "Refs from Shelf";
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        TreeA.Nodes.Clear ();
                        SetMode (29);
                        break;
                        }
                case "-timer":
                        {
                        if (timer1.Enabled)
                            {
                            timer1.Enabled = false;
                            string Datum = DateTime.Now.ToString ("yyyy - MM - dd  .  HH : mm");
                            Text = Report.Caption + "  -  " + User.Name + "  -  " + Datum;
                            }
                        else
                            {
                            timer1.Enabled = true;
                            }
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.TextLength;
                        break;
                        }
                case "-up":
                        {
                        ShowUpcomingNotes (1);
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "-xml":
                        {
                        //En, Fa
                        txtSearch.Text = "Save list data as XML: Notes | Links | Refs";
                        txtSearch.SelectionStart = 23;
                        txtSearch.SelectionLength = 20;
                        break;
                        }
                case "save list data as xml: n":
                        {
                        switch (Assign.Mode)
                            {
                            case 50:
                            case 16:
                                    {
                                    //snotes  eLib_Guide.html"
                                    Db.DS.Tables ["tblSNotes"].WriteXml (System.Windows.Forms.Application.StartupPath + @"\notes-s.xml");
                                    break;
                                    }
                            case 42:
                                    {
                                    //lnotes
                                    Db.DS.Tables ["tblLNotes"].WriteXml (System.Windows.Forms.Application.StartupPath + @"\notes-l.xml");
                                    break;
                                    }
                            case 29:
                            case 5:
                                    {
                                    //rnotes
                                    Db.DS.Tables ["tblRNotes"].WriteXml (System.Windows.Forms.Application.StartupPath + @"\notes-r.xml");
                                    break;
                                    }
                            }
                        txtSearch.Text = "notes list saved as xml, ok.";
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "save list data as xml: l":
                        {
                        Db.DS.Tables ["tblLinks"].WriteXml (System.Windows.Forms.Application.StartupPath + @"\links.xml");
                        txtSearch.Text = "refs list saved as xml, ok.";
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        break;
                        }
                case "save list data as xml: r":
                        {
                        Db.DS.Tables ["tblRefs"].WriteXml (System.Windows.Forms.Application.StartupPath + @"\refs.xml");
                        lblStatusBar.Text = "refs list saved as xml, ok.";
                        txtSearch.SelectionStart = 0;
                        txtSearch.SelectionLength = txtSearch.Text.Length;
                        //Db.DS.WriteXml (System.Windows.Forms.Application.StartupPath + @"\tbl_all.xml");
                        break;
                        }
                }
            }
        private void txtSearch_Click (object sender, EventArgs e)
            {
            //txtSearch.SelectionStart = 0;
            //txtSearch.SelectionLength = txtSearch.TextLength;
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
        //txt-Note
        private void txtNote_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Escape:
                        {
                        e.SuppressKeyPress = true;
                        lblStatusBar.Text = "Note not Saved!";
                        CloseInlineNoteEditor ();
                        break;
                        }
                }
            }
        private void txtNote_TextChanged (object sender, EventArgs e)
            {
            if (txtNote.Text == Note.NoteText)
                {
                LED_Save.Visible = false;
                }
            else
                {
                LED_Save.Visible = true;
                }
            if (Strings.Right (txtNote.Text, 2).ToLower () == "-?")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.TextLength - 2);
                string strHelp = "\r\n  -Rtl\r\n  -Ltr\r\n  -Pend\r\n  -Done\r\n  -Date\r\n  -Edit\r\n  -Save ";
                txtNote.Text += strHelp;
                txtNote.SelectionStart = txtNote.Text.Length - Strings.Len (strHelp);
                txtNote.SelectionLength = Strings.Len (strHelp);
                }
            else if (Strings.Right (txtNote.Text, 5).ToLower () == "-save")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.TextLength - 5);
                SaveTheNote ();
                }
            else if (Strings.Right (txtNote.Text, 4).ToLower () == "-rtl")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.TextLength - 4);
                txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                txtNote.Font = new System.Drawing.Font ("Tahoma", 9);
                LED_Save.Visible = true;
                Note.NoteText += "%ObjectCahnged@"; //maked txtNote feel text has changed and doent equal Note.NoteText!
                txtNote.SelectionStart = txtNote.TextLength;
                txtNote.SelectionLength = 0;
                }
            else if (Strings.Right (txtNote.Text, 4).ToLower () == "-ltr")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.TextLength - 4);
                txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
                txtNote.Font = new System.Drawing.Font ("Consolas", 9);
                LED_Save.Visible = true;
                Note.NoteText += "%ObjectCahnged@"; //maked txtNote feel text has changed and doent equal Note.NoteText!
                txtNote.SelectionStart = txtNote.TextLength;
                txtNote.SelectionLength = 0;
                }
            else if (Strings.Right (txtNote.Text, 5).ToLower () == "-pend")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.TextLength - 5);
                LED_Pending.Visible = true;
                Note.NoteText += "%ObjectCahnged@"; //maked txtNote feel text has changed and doent equal Note.NoteText!
                txtNote.SelectionStart = txtNote.TextLength;
                txtNote.SelectionLength = 0;
                }
            else if (Strings.Right (txtNote.Text, 5).ToLower () == "-done")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.TextLength - 5);
                LED_Pending.Visible = false;
                Note.NoteText += "%ObjectCahnged@"; //maked txtNote feel text has changed and doent equal Note.NoteText!
                txtNote.SelectionStart = txtNote.TextLength;
                txtNote.SelectionLength = 0;
                }
            else if (Strings.Right (txtNote.Text, 5).ToLower () == "-date")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.TextLength - 5);
                MenuT_DateTime_Click (null, null);
                txtNote.SelectionStart = txtNote.TextLength;
                txtNote.SelectionLength = 0;
                }
            else if (Strings.Right (txtNote.Text, 5).ToLower () == "-edit")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.TextLength - 5);
                MenuT_Editor_Click (null, null);
                txtNote.SelectionStart = txtNote.TextLength;
                txtNote.SelectionLength = 0;
                }
            }
        //Labels
        private void lblDay0_Click (object sender, EventArgs e)
            {
            //Upcoming Notes
            Note.GetSNotesFromDB ("all");
            ShowFNotesForm ();
            lblListA.Text = "Projects";
            lblDatum.Text = "";
            ShowUpcomingNotes (1);
            BoldDatesOnCalendar ("tblNotesCount");
            }
        private void lblDay1_Click (object sender, EventArgs e)
            {
            //Tommorow (Day+1) Notes
            Note.DateTime = DateTime.Now.AddDays (1).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            ShowFNotesForm ();
            lblDatum.Text = "";
            ShowUpcomingNotes (1);
            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
            }
        private void lblDay2_Click (object sender, EventArgs e)
            {
            //(Today+2) Notes
            Note.DateTime = DateTime.Now.AddDays (2).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            ShowFNotesForm ();
            lblDatum.Text = "";
            ShowUpcomingNotes (1);
            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
            }
        private void lblDay3_Click (object sender, EventArgs e)
            {
            //(Today+3) Notes
            Note.DateTime = DateTime.Now.AddDays (3).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            ShowFNotesForm ();
            lblDatum.Text = "";
            ShowUpcomingNotes (1);
            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
            }
        private void lblDay4_Click (object sender, EventArgs e)
            {
            //(Today+4) Notes
            Note.DateTime = DateTime.Now.AddDays (4).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            ShowFNotesForm ();
            lblDatum.Text = "";
            ShowUpcomingNotes (1);
            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
            }
        private void lblDay5_Click (object sender, EventArgs e)
            {
            //(Today+5) Notes
            Note.DateTime = DateTime.Now.AddDays (5).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            ShowFNotesForm ();
            lblDatum.Text = "";
            ShowUpcomingNotes (1);
            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
            }
        private void lblDay6_Click (object sender, EventArgs e)
            {
            //(Today+6) Notes
            Note.DateTime = DateTime.Now.AddDays (6).ToString ("yyyy-MM-dd");
            Note.GetSNotesFromDB ("oneday");
            ShowFNotesForm ();
            lblDatum.Text = "";
            ShowUpcomingNotes (1);
            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
            }
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
            txtSearch.Focus ();
            txtSearch.SelectionStart = Strings.Len (txtSearch.Text);
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
                    txtSearch.Focus ();
                    }
                catch (Exception ex)
                    {
                    }
                }
            }
        private void lblListA_Click (object sender, EventArgs e)
            {
            currentActiveMode = 0; //0:active, 2:all
            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
            TreeA.CollapseAll (); //TreeA.ExpandAll ();

            //--alternative code:
            //if (MenuA_ShowActive.Checked)
            //    {
            //    currentActiveMode = 2; //0:active, 2:all
            //    ShowProjectsInTreeA (User.Id, currentActiveMode, "");
            //    TreeA.CollapseAll ();
            //    }
            //else
            //    {
            //    currentActiveMode = 0; //0:active, 2:all
            //    ShowProjectsInTreeA (User.Id, currentActiveMode, "");
            //    TreeA.CollapseAll (); //TreeA.ExpandAll ();
            //    //--locate item 0
            //    //--ExpandFirstProjectInTreeA ();
            //    }
            }
        private void lblDatum_Click (object sender, EventArgs e)
            {
            MenuB_DateTime_Click (null, null);
            }
        private void lblGridB_Click (object sender, EventArgs e)
            {
            switch (Assign.Mode)
                {
                case 50:
                        {
                        GridB.DataSource = Db.DS.Tables ["tblLNotes"];
                        SetMode (42);
                        lblDatum.Text = "";
                        break;
                        }
                case 42:
                        {
                        GridB.DataSource = Db.DS.Tables ["tblSNotes"];
                        SetMode (50);
                        lblDatum.Text = "";
                        break;
                        }
                }
            txtSearch.Focus ();
            txtSearch.SelectionStart = 0;
            txtSearch.SelectionLength = txtSearch.TextLength;
            }
        private void lbl_NewNote_Click (object sender, EventArgs e)
            {
            MenuB_Add_Click (null, null);
            }
        private void lblStatusBar_Click (object sender, EventArgs e)
            {
            if (Strings.Left (lblStatusBar.Text, 10) == "Linked to:")
                {
                string strLinkedSPs = "";
                for (int i = 0; i < Db.DS.Tables ["tblAssignments"].Rows.Count; i++)
                    {
                    strLinkedSPs += "\r\n\r\n" + Db.DS.Tables ["tblAssignments"].Rows [i] [3].ToString ();
                    }
                MessageBox.Show (strLinkedSPs, "eLib: Ref is Linked to:", MessageBoxButtons.OK);
                return;
                }
            string guidePage = Strings.Left (lblStatusBar.Text, 2);
            switch (guidePage)
                {
                case "00":
                        {
                        lblStatusBar.Text = "01-  F1: show projects (all)";
                        break;
                        }
                case "01":
                        {
                        lblStatusBar.Text = "02-  DblClick a project: show SubProjects (also: right arrow)";
                        break;
                        }
                case "02":
                        {
                        lblStatusBar.Text = "03-  F2: focus on search box <--> focus on Projects";
                        break;
                        }
                case "03":
                        {
                        lblStatusBar.Text = "04-  F3: focus on notes (upper list)";
                        break;
                        }
                case "04":
                        {
                        lblStatusBar.Text = "05-  F4: show note editor";
                        break;
                        }
                case "05":
                        {
                        lblStatusBar.Text = "06-  F5: focus on lower list (links / refs)";
                        break;
                        }
                case "06":
                        {
                        lblStatusBar.Text = "07-  F6: show upcoming notes";
                        break;
                        }
                case "07":
                        {
                        lblStatusBar.Text = "08-  F7: logout";
                        break;
                        }
                case "08":
                        {
                        lblStatusBar.Text = "09-  in search box type: -?";
                        break;
                        }
                case "09":
                        {
                        lblStatusBar.Text = "10-  drop a file  on subroject list (left list)";
                        break;
                        }
                case "10":
                        {
                        lblStatusBar.Text = "11-  drop a text file on note list (upper list)";
                        break;
                        }
                case "11":
                        {
                        lblStatusBar.Text = "12-  drop a file  on refs list (lower list)";
                        break;
                        }
                case "12":
                        {
                        lblStatusBar.Text = "13-  you can share a project with all its subprojects and notes another user";
                        break;
                        }
                case "13":
                        {
                        lblStatusBar.Text = "14-  you can entrust a project";
                        break;
                        }
                case "14":
                        {
                        lblStatusBar.Text = "15-  to add a note: select a project, select a subproject, then right-click on upper list ";
                        break;
                        }
                case "15":
                        {
                        lblStatusBar.Text = "16-  you can change the time and date of a note (today, tomorrow, next week, any other date...)";
                        break;
                        }
                case "16":
                        {
                        lblStatusBar.Text = "17-  click on ribbon on top edge: edit upcoming notes";
                        break;
                        }
                case "17":
                        {
                        lblStatusBar.Text = "18-  click very lower part of the right edge to exit eLib";
                        break;
                        }
                case "18":
                        {
                        lblStatusBar.Text = "19-  when editing a note, at the end of text type -save";
                        break;
                        }
                case "19":
                        {
                        lblStatusBar.Text = "20-  when editing a note, at the end of text type -rtl | -ltr to chage direction";
                        break;
                        }
                case "20":
                        {
                        lblStatusBar.Text = "21-  when editing a note, at the end of text type -? for help";
                        break;
                        }
                case "21":
                        {
                        lblStatusBar.Text = "22-  at login (first window), double-click a connection and type -newuser | -signup to create a new account";
                        break;
                        }
                case "22":
                        {
                        lblStatusBar.Text = "23-  there are 3 kinds of notes: s-notes, l-notes, r-notes";
                        break;
                        }
                case "23":
                        {
                        lblStatusBar.Text = "24-  s-notes are notes for SubProjects";
                        break;
                        }
                case "24":
                        {
                        lblStatusBar.Text = "25-  l-notes are notes for Links";
                        break;
                        }
                case "25":
                        {
                        lblStatusBar.Text = "26-  r-notes are notes for refs";
                        break;
                        }
                case "26":
                        {
                        lblStatusBar.Text = "27-  use mindmap to interconnect notes";
                        break;
                        }
                case "27":
                        {
                        lblStatusBar.Text = "28-  notes can be linked upstream or downstream of other notes";
                        break;
                        }
                case "28":
                        {
                        lblStatusBar.Text = "29-  use explore to visit files in their folders";
                        break;
                        }
                case "29":
                        {
                        lblStatusBar.Text = "30-  use attributes of a link to set some tags: imp1-3, ImR (ImR: I am reading this!)";
                        break;
                        }
                case "30":
                        {
                        lblStatusBar.Text = "30-  F10: Augustusmate (for drawing gene clusters)";
                        break;
                        }
                default:
                        {
                        lblStatusBar.Text = "00-  Click a point along side the right edge of the window to exit/logout";
                        break;
                        }
                }
            }
        private void lblAssign1Form_Click (object sender, EventArgs e)
            {
            //vertical label along LEFT side of the form
            Dispose ();
            System.Windows.Forms.Form Assign1 = new frmAssign ();
            Assign1.ShowDialog ();
            }
        private void lblLogout_Click (object sender, EventArgs e)
            {
            Client.Interface = 2;
            Assign.SetDefaultUserInterface (2);
            Dispose ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            //everythime lblStatusBar is clicked, if no matching case is found, guide 00 is displaded, and the subsequent clicks let the switch() to show 30 more guides one-by-one. 
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Client.Interface = 2;
            Assign.SetDefaultUserInterface (2);
            Dispose ();
            Db.CloseDbAndExitTheApp ();
            }
        //Menu-A
        private void MenuA_AddNew_Click (object sender, EventArgs e)
            {
            try
                {
                Assign.AddNewProject (User.Id);
                ShowProjectsInTreeA (User.Id, currentActiveMode, ""); //0:active 1:inactive 2:all 3:search
                SetMode (64);
                }
            catch (Exception ex)
                {
                lblStatusBar.Text = "Create new Project failed";
                }
            }
        private void MenuA_AddNewSubProject_Click (object sender, EventArgs e)
            {
            int intPrjIndex = 0;
            try
                {
                if (TreeA.SelectedNode.Level == 0)
                    {
                    Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                    Project.Name = TreeA.SelectedNode.Text;
                    intPrjIndex = TreeA.SelectedNode.Index;
                    SubProject.Name = "_" + Strings.Left (Project.Name, 12) + " sub-" + (TreeA.SelectedNode.Nodes.Count + 1).ToString (); // + "_" + DateTime.Now.ToString ("HH:mm"); //...yyyyMMddHHmm
                    SubProject.Note = "note";
                    }
                else if (TreeA.SelectedNode.Level == 1)
                    {
                    Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Parent.Tag);
                    Project.Name = TreeA.SelectedNode.Parent.Text;
                    intPrjIndex = TreeA.SelectedNode.Parent.Index;
                    SubProject.Name = "_" + Strings.Left (Project.Name, 12) + " sub-" + (TreeA.SelectedNode.Parent.Nodes.Count + 1).ToString (); // + "_" + DateTime.Now.ToString ("HH:mm"); //...yyyyMMddHHmm
                    SubProject.Note = "note";
                    }
                //ADD SUB-PROJECT   0ID, 1SubProjectName, 2Notes, 3Project_ID
                if (Assign.AddNewSubProject (Project.Id, SubProject.Name, SubProject.Note))
                    {
                    //--Edit form
                    Project.Name = SubProject.Name; //notice: we are using the shared dialog form: frmProjects
                    Project.Note = SubProject.Note; //notice: we are using the shared dialog form: frmProjects
                    Assign.EditASubProject (SubProject.Id);
                    ShowProjectsInTreeA (User.Id, currentActiveMode, ""); //0:active 1:inactive 2:all 3:search                    
                    SetMode (64); //?32 ?64 //SetMode (32)
                    TreeA.Nodes [intPrjIndex].ExpandAll ();
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                lblStatusBar.Text = "Create new subProject failed";
                }
            }
        private void MenuA_Edit_Click (object sender, EventArgs e)
            {
            if (TreeA.Nodes.Count == 0)
                {
                return;
                }
            if (TreeA.SelectedNode.Text != null) //if (TreeA.SelectedNode.Index != -1)            
                switch (TreeA.SelectedNode.Level)
                    {
                    case 0:
                            {
                            Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Project.Name = TreeA.SelectedNode.Text;
                            Project.Note = Db.DS.Tables ["tblProject"].Rows [TreeA.SelectedNode.Index] [2].ToString ();
                            Project.IsActive = Convert.ToBoolean (Db.DS.Tables ["tblProject"].Rows [TreeA.SelectedNode.Index] [3]);
                            Assign.EditAProject (Convert.ToInt32 (TreeA.SelectedNode.Tag));
                            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
                            SetMode (64);
                            break;
                            }
                    case 1:
                            {
                            //notice: using 'project' var for all calls to the dialog
                            Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Parent.Tag);
                            Assign.GetSubProjects (Project.Id);
                            Project.Name = TreeA.SelectedNode.Text;
                            //tblSbProject: ID, SubProjectName, Notes, Project_ID
                            Project.Note = Db.DS.Tables ["tblSubProject"].Rows [Convert.ToInt32 (TreeA.SelectedNode.Index)] [2].ToString ();
                            SubProject.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Assign.EditASubProject (SubProject.Id);
                            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
                            SetMode (64); //?32 ?64
                            break;
                            }
                    }
            }
        private void MenuA_Replace_Click (object sender, EventArgs e)
            {
            //TreeA: SP:
            if ((TreeA.SelectedNode.Text != "") && ((Assign.Mode == 32) || (Assign.Mode == 50) || (Assign.Mode == 42)))
                {
                if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                    return;
                Client.DialogRequestParams = 1; //1:get Project 2:get SubProject 3:get Project or SubProject
                My.MyProject.Forms.frmChooseProject.ShowDialog ();
                //replace current SubProjects to selected project
                if (Client.DialogRequestParams == 64) //bit7:2^6:64: a Project is selected from dialog
                    {
                    Assign.ReplaceASubProject (SubProject.Id, Project.Id);
                    }
                ShowProjectsInTreeA (User.Id, currentActiveMode, ""); //2:all
                SetMode (64);
                }
            }
        private void MenuA_Delete_Click (object sender, EventArgs e)
            {
            if (TreeA.Nodes.Count == 0)
                {
                return;
                }
            if (TreeA.SelectedNode.Text != null)
                switch (TreeA.SelectedNode.Level)
                    {
                    case 0: //project
                            {
                            Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            Project.Name = TreeA.SelectedNode.Text;
                            if (Convert.ToInt32 (Db.DS.Tables ["tblProject"].Rows [Convert.ToInt32 (TreeA.SelectedNode.Index)] [4].ToString ()) != User.Id)
                                {
                                MessageBox.Show ("NOTICE: \n\n You are not the Owner of this project!", "eLib", MessageBoxButtons.OK);
                                return;
                                }
                            //check if this project was populated, if yes, dont delete it 
                            if (TreeA.SelectedNode.Nodes.Count > 0)
                                {
                                MessageBox.Show ("This Project is Populated ! \r\n Replace (or Delete) its Subs, then try again", "eLib", MessageBoxButtons.OK);
                                return;
                                }
                            else
                                {
                                //delete
                                DialogResult myansw = (DialogResult) MessageBox.Show ("Delete this Project?", "eLib", MessageBoxButtons.YesNo);
                                if (myansw == DialogResult.Yes)
                                    {
                                    Assign.DeleteAProject (Project.Id);
                                    //refresh
                                    if (MenuA_ShowActive.Checked == true)
                                        {
                                        ShowProjectsInTreeA (User.Id, 0, ""); //0:active
                                        }
                                    else
                                        {
                                        ShowProjectsInTreeA (User.Id, 2, ""); //2:all
                                        }
                                    lblStatusBar.Text = "Deleted";
                                    }
                                lblStatusBar.Text = "Canceled";
                                }
                            SetMode (64);
                            break;
                            }
                    case 1: //subproject
                            {
                            int projectIndex = TreeA.SelectedNode.Parent.Index;
                            SubProject.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            if ((Project.Id > 0) && (Assign.CheckReadOnlyAccess (Project.Id) != 1))
                                {
                                Assign.DeleteASubProject (SubProject.Id);
                                ShowProjectsInTreeA (User.Id, currentActiveMode, ""); //2:all
                                TreeA.Nodes [projectIndex].ExpandAll ();
                                SetMode (32);
                                lblStatusBar.Text = "Deleted";
                                }
                            break;
                            }
                    }
            }
        private void MenuA_Search_Click (object sender, EventArgs e)
            {
            MenuA_Search.SelectionStart = 0;
            MenuA_Search.SelectionLength = MenuA_Search.TextLength;
            MenuA_ShowActive.Checked = false;
            MenuA_ShowInactive.Checked = false;
            MenuA_ShowAll.Checked = true;
            }
        private void MenuA_Search_TextChanged (object sender, EventArgs e)
            {
            if (String.IsNullOrEmpty (MenuA_Search.Text))
                {
                MenuA_Search.Text = "search";
                MenuA_Search.SelectionStart = 0;
                MenuA_Search.SelectionLength = MenuA_Search.TextLength;
                }
            }
        private void MenuA_Search_KeyDown (object sender, KeyEventArgs e)
            {
            if ((e.KeyCode == Keys.Enter) && (!String.IsNullOrEmpty (MenuA_Search.Text)))
                {
                ShowProjectsInTreeA (User.Id, 3, MenuA_Search.Text);
                MenuA.Visible = false;
                }
            }
        private void MenuA_ShowActive_Click (object sender, EventArgs e)
            {
            ShowProjectsInTreeA (User.Id, 0, ""); //0:active 1:inactive 2:all 3:search
            currentActiveMode = 0;
            MenuA_ShowActive.Checked = true;
            MenuA_ShowInactive.Checked = false;
            MenuA_ShowAll.Checked = false;
            }
        private void MenuA_ShowInactive_Click (object sender, EventArgs e)
            {
            ShowProjectsInTreeA (User.Id, 1, ""); //0:active 1:inactive 2:all 3:search
            currentActiveMode = 1;
            MenuA_ShowActive.Checked = false;
            MenuA_ShowInactive.Checked = true;
            MenuA_ShowAll.Checked = false;
            }
        private void MenuA_ShowAll_Click (object sender, EventArgs e)
            {
            ShowProjectsInTreeA (User.Id, 2, ""); //0:active 1:inactive 2:all 3:search
            currentActiveMode = 2;
            TreeA.ExpandAll (); //TreeA.ExpandAll ();
            MenuA_ShowActive.Checked = false;
            MenuA_ShowInactive.Checked = false;
            MenuA_ShowAll.Checked = true;
            }
        private void MenuA_ExpandAll_Click (object sender, EventArgs e)
            {
            TreeA.ExpandAll ();
            }
        private void MenuA_Import_Click (object sender, EventArgs e)
            {
            Import ();
            }
        private void MenuA_Exit_Click (object sender, EventArgs e)
            {
            //also: LOWER vertical label along RIGHT side of the form
            Client.Interface = 2;
            Assign.SetDefaultUserInterface (2);
            Dispose ();
            Db.CloseDbAndExitTheApp ();
            }
        //Menu-B       
        private void MenuB_Add_Click (object sender, EventArgs e)
            {
            //create new SLR-Note for note parent
            string strDateTime1 = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
            string strDateTime2 = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm-ss");
            switch (Assign.Mode)
                {
                case 50://new s-note
                        {
                        SubProject.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                        Assign.AddNewNote (strDateTime1, User.Name + " @ " + strDateTime2 + "  \r\n{\r\n \r\n}", SubProject.Id, 1, User.Id); // notice: \n is Unix, \r is Mac, \r\n is Windows (alt.: use Environment.NewLine)
                        //refresh s-notes (and links) 
                        ShowSNotesInGridB_LinksInGridC (SubProject.Id);
                        break;
                        }
                case 42: //new l-note
                        {
                        //Link: Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, SubProject_ID, Links.ID AS LinkID, Imp1, Imp2, Imp3, ImR
                        int r = (int) GridC.SelectedRows [0].Index;
                        Link.Id = Convert.ToInt32 (GridC.Rows [r].Cells [7].Value); //7:LinkId
                        Assign.AddNewNote (strDateTime1, User.Name + " @ " + strDateTime2 + "  \r\n{\r\n \r\n}", Link.Id, 2, User.Id); //2:l
                        ShowSNotesInGridB_LinksInGridC (SubProject.Id);
                        //refresh l-notes
                        GridC.CurrentCell = GridC.Rows [r].Cells [1];
                        GridC_CellClick (null, null);
                        break;
                        }
                case 5: //new r-note
                        {
                        int r = (int) GridC.SelectedRows [0].Index;
                        Ref.Id = Convert.ToInt32 (GridC.Rows [r].Cells [0].Value); //0:PaperId
                        Assign.AddNewNote (strDateTime1, User.Name + " @ " + strDateTime2 + "  \r\n{\r\n \r\n}", Ref.Id, 3, User.Id);
                        //refresh r-notes
                        GridC.CurrentCell = GridC.Rows [r].Cells [1];
                        GridC_CellClick (null, null);
                        break;
                        }
                }
            //locate new note and edit
            for (int i = 0; i < GridC.Rows.Count; i++)
                {
                if (Convert.ToInt32 (GridB.Rows [i].Cells [0].Value) == Note.Id)
                    {
                    GridB.CurrentCell = GridB.Rows [i].Cells [1];
                    Note.NoteText = GridB.Rows [i].Cells [2].Value.ToString ();
                    lblDatum.Text = strDateTime1;
                    ShowTextInInlineEditor (Note.NoteText, false, false, true);
                    break;
                    }
                }
            }
        private void MenuB_Edit_Click (object sender, EventArgs e)
            {
            //SNote 50,16
            //LNote 42
            //RNote 5
            try
                {
                if ((GridB.Rows.Count > 0) && (GridB.SelectedRows [0].Index >= 0))
                    {
                    switch (Assign.Mode)
                        {
                        case 50: //A:SP  B:SNotes
                        case 16: //A:--  B:SNotes ?searched
                        case 42: //A:SP  B:LNotes
                        case 5:  //A:--  B:RNotes
                                {
                                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                                Project.Name = TreeA.SelectedNode.Parent.Text;
                                Note.ParentID = Convert.ToInt32 (Convert.ToInt32 (GridB.SelectedRows [0].Cells [3].Value));
                                Note.Id = Convert.ToInt32 (GridB.Rows [GridB.SelectedRows [0].Index].Cells [0].Value);
                                if (Note.Id < 1)
                                    return;
                                Note.DateTime = (GridB.Rows [GridB.SelectedRows [0].Index].Cells [1]).ToString ();
                                Note.NoteText = (GridB.Rows [GridB.SelectedRows [0].Index].Cells [2]).ToString ();
                                Note.Rtl = Convert.ToBoolean (GridB.Rows [GridB.SelectedRows [0].Index].Cells [5].Value);
                                Note.Index = GridB.SelectedRows [0].Index;
                                CallNoteEditor (Assign.Mode);
                                break;
                                }
                        default: //?!
                                {
                                //ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl
                                //do nothing!
                                break;
                                }
                        }
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        private void MenuB_DateTime_Click (object sender, EventArgs e)
            {
            if ((GridB.Rows.Count > 0) && (GridB.SelectedRows [0].Index >= 0))
                {
                lblStatusBar.Text = "Date/Time changed from:  " + Note.DateTime + "   to: ";
                if (Assign.Mode == 4)
                    {
                    //f-Notes: 0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done, 8Rtl
                    Note.DateTime = GridB [2, GridB.SelectedRows [0].Index].Value.ToString ();
                    Note.Id = (int) GridB [6, GridB.SelectedRows [0].Index].Value;
                    }
                else
                    {
                    Note.DateTime = GridB [1, GridB.SelectedRows [0].Index].Value.ToString ();
                    Note.Id = (int) GridB [0, GridB.SelectedRows [0].Index].Value;
                    }
                var frmTMDT = new frmTimeAndDate ();
                frmTMDT.ShowDialog ();
                //do update
                if (Client.DialogRequestParams == 16)
                    {
                    Assign.UpdateDateTime (Note.Id, Note.DateTime);
                    //mntCal.SetDate (DateTime.Parse (Strings.Mid (Note.DateTime, 1, 4) + "/" + Strings.Mid (Note.DateTime, 6, 2) + "/" + Strings.Mid (Note.DateTime, 9, 2)));
                    mntCal_DateSelected (null, null);
                    //switch (Assign.Mode)
                    //    {
                    //    case 4:
                    //            {
                    //            GridB.SelectedRows [0].Cells [2].Value = Note.DateTime;
                    //            BoldDatesOnCalendar ("tblNotesCount");
                    //            break;
                    //            }
                    //    case 50:
                    //    case 16:
                    //            {
                    //            GridB.SelectedRows [0].Cells [1].Value = Note.DateTime;
                    //            BoldDatesOnCalendar ("tblSNotes");
                    //            break;
                    //            }
                    //    case 42:
                    //            {
                    //            GridB.SelectedRows [0].Cells [1].Value = Note.DateTime;
                    //            BoldDatesOnCalendar ("tblLNotes");
                    //            break;
                    //            }
                    //    case 29:
                    //    case 5:
                    //            {
                    //            GridB.SelectedRows [0].Cells [1].Value = Note.DateTime;
                    //            BoldDatesOnCalendar ("tblRNotes");
                    //            break;
                    //            }
                    //    }
                    }
                }
            }
        private void MenuB_Replace_Click (object sender, EventArgs e)
            {
            if ((GridB.Rows.Count > 0) && (GridB.SelectedRows [0].Index >= 0) && (Assign.Mode == 50))
                {
                Note.Id = Convert.ToInt32 (GridB.Rows [GridB.SelectedRows [0].Index].Cells [0].Value);
                Assign.ReplaceASubProjectNote (Note.Id);
                TreeA_AfterSelect (null, null);
                }
            }
        private void MenuB_MovetoToday_Click (object sender, EventArgs e)
            {
            if ((GridB.Rows.Count > 0) && (GridB.SelectedRows [0].Index >= 0))
                {
                if ((Assign.Mode == 50) || (Assign.Mode == 16) || (Assign.Mode == 42) || (Assign.Mode == 5))
                    {
                    //SLR-Notes: 0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                    Note.Id = (int) GridB [0, GridB.SelectedRows [0].Index].Value;
                    Note.DateTime = GridB [1, GridB.SelectedRows [0].Index].Value.ToString ();
                    Note.PostpondNote (Note.Id, 0);
                    GridB.SelectedRows [0].Cells [1].Value = Note.DateTime;
                    lblDatum.Text = Note.DateTime;
                    GridB.Focus ();
                    }
                ShowUpcomingNotes (0);
                }
            }
        private void MenuB_MovetoTomorrow_Click (object sender, EventArgs e)
            {
            if ((GridB.Rows.Count > 0) && (GridB.SelectedRows [0].Index >= 0))
                {
                if ((Assign.Mode == 50) || (Assign.Mode == 16) || (Assign.Mode == 42) || (Assign.Mode == 5))
                //SLR-Notes: 0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                    {
                    Note.Id = (int) GridB [0, GridB.SelectedRows [0].Index].Value;
                    Note.DateTime = GridB [1, GridB.SelectedRows [0].Index].Value.ToString ();
                    Note.PostpondNote (Note.Id, 1);
                    GridB.SelectedRows [0].Cells [1].Value = Note.DateTime;
                    lblDatum.Text = Note.DateTime;
                    GridB.Focus ();
                    }
                ShowUpcomingNotes (0);
                }
            }
        private void MenuB_MovetoNextWeek_Click (object sender, EventArgs e)
            {
            if ((GridB.Rows.Count > 0) && (GridB.SelectedRows [0].Index >= 0))
                {
                if ((Assign.Mode == 50) || (Assign.Mode == 16) || (Assign.Mode == 42) || (Assign.Mode == 5))
                    {
                    //SLR-Notes: 0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                    Note.Id = (int) GridB [0, GridB.SelectedRows [0].Index].Value;
                    Note.DateTime = GridB [1, GridB.SelectedRows [0].Index].Value.ToString ();
                    Note.PostpondNote (Note.Id, 7);
                    GridB.SelectedRows [0].Cells [1].Value = Note.DateTime;
                    lblDatum.Text = Note.DateTime;
                    GridB.Focus ();
                    }
                ShowUpcomingNotes (0);
                }
            }
        private void MenuB_MindMap_Click (object sender, EventArgs e)
            {
            if (GridB.Rows.Count == 0)
                {
                return;
                }
            //{SubProjectNote, SubProjectNoteSearch, LinkNote, LinkNoteSearch, RefNote, RefNoteSearch} <- CallNoteEditor()
            //GridB: 0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
            try
                {
                if ((Assign.Mode == 50) && (TreeA.SelectedNode != null))
                    {
                    SubProject.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                    SubProject.Name = TreeA.SelectedNode.Text;
                    Note.Id = Convert.ToInt32 (Db.DS.Tables ["tblSNotes"].Rows [GridB.SelectedRows [0].Index] [0]);
                    Note.DateTime = (Db.DS.Tables ["tblSNotes"].Rows [GridB.SelectedRows [0].Index] [1]).ToString ();
                    Note.NoteText = (Db.DS.Tables ["tblSNotes"].Rows [GridB.SelectedRows [0].Index] [2]).ToString ();
                    Note.Index = (int) GridB.SelectedRows [0].Index;
                    Note.Type = "SubProjectNote"; //FocusNote SubProjectNote SubProjectNoteSearch LinkNote LinkNoteSearch RefNote RefNoteSearch
                    if (Note.Id < 1)
                        return;
                    var frmMindmap = new frmNoteNetEditor ();
                    frmMindmap.ShowDialog ();
                    //refresh
                    CloseInlineNoteEditor ();
                    ShowUpcomingNotes (0);
                    ShowProjectsInTreeA (User.Id, currentActiveMode, "");
                    TreeA.SelectedNode = null; //??
                    ShowSNotesInGridB_LinksInGridC (Note.ParentID);
                    GridB.CurrentCell = GridB.Rows [Note.Index].Cells [1];
                    GridB.Focus ();
                    }
                else
                    {
                    lblStatusBar.Text = "Please select a subproject-Note for MindMap";
                    }
                }
            catch { }
            }
        private void MenuB_Search_Click (object sender, EventArgs e)
            {
            MenuB_Search.SelectionStart = 0;
            MenuB_Search.SelectionLength = MenuB_Search.TextLength;
            }
        private void MenuB_Search_TextChanged (object sender, EventArgs e)
            {
            if (String.IsNullOrEmpty (MenuB_Search.Text))
                {
                MenuB_Search.Text = "search";
                MenuB_Search.SelectionStart = 0;
                MenuB_Search.SelectionLength = MenuB_Search.TextLength;
                }
            }
        private void MenuB_Search_KeyDown (object sender, KeyEventArgs e)
            {
            if ((e.KeyCode == Keys.Enter) && (!String.IsNullOrEmpty (MenuB_Search.Text)))
                {
                e.SuppressKeyPress = true;
                MenuB.Visible = false;
                Db.DS.Tables ["tblRefs"].Clear ();
                Db.DS.Tables ["tblAssignments"].Clear ();
                Db.DS.Tables ["tblSNotes"].Clear ();
                if (string.IsNullOrEmpty (Strings.Trim (MenuB_Search.Text)))
                    {
                    MenuB_Search.Text = "";
                    return;
                    }
                else
                    {
                    //there are some keys to search
                    GridB.DataSource = null;
                    string strSearchString = Strings.Trim (MenuB_Search.Text);
                    Assign.DoSearchNotes (strSearchString, 1); //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
                    GridB.DataSource = Db.DS.Tables ["tblSNotes"];
                    FormatGridB ("SNotes"); //{SubProjects. SNotes, LNotes. RNotes, FNotes}
                    MenuB_Search.Focus ();
                    MenuB_Search.SelectionStart = 0;
                    MenuB_Search.SelectionLength = MenuB_Search.TextLength;
                    GridC.DataSource = null;
                    TreeA.Nodes.Clear ();
                    SetMode (16);
                    }
                }
            }
        private void MenuB_Delete_Click (object sender, EventArgs e)
            {
            if ((GridB.Rows.Count > 0) && (GridB.SelectedRows [0].Index >= 0))
                {
                if (Assign.Mode == 4)
                    {
                    //f-Notes: 0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done, 8Rtl
                    Note.Id = Convert.ToInt32 (GridB [6, GridB.SelectedRows [0].Index].Value);
                    }
                else
                    {
                    //SLR-Notes: 0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                    Note.Id = Convert.ToInt32 (GridB [0, GridB.SelectedRows [0].Index].Value);
                    }
                string result = Assign.DeleteNote (Note.Id, true); //true: get user confirmation
                switch (result)
                    {
                    case "deleted":
                            {
                            lblStatusBar.Text = "Deleted";
                            GridB.Rows.RemoveAt ((int) GridB.SelectedRows [0].Index);
                            GridB.Focus ();
                            CloseInlineNoteEditor ();
                            if (Assign.Mode == 4)
                                {
                                ShowUpcomingNotes (0); //0:just hilight leds, 1:also feed data in grid-b
                                }
                            break;
                            }
                    case "notenet":
                            {
                            MenuB_MindMap_Click (null, null);
                            break;
                            }
                    case "error":
                            {
                            lblStatusBar.Text = "an error occured: not deleted!";
                            CloseInlineNoteEditor ();
                            break;
                            }
                    case "cancelled":
                            {
                            lblStatusBar.Text = "Cancelled";
                            CloseInlineNoteEditor ();
                            break;
                            }
                    }
                }
            }
        private void MenuB_ShowUpcoming_Click (object sender, EventArgs e)
            {
            ShowUpcomingNotes (1);
            SetMode (4); //A:- B:FNotes
            }
        private void MenuB_ShowPending_Click (object sender, EventArgs e)
            {
            Note.GetSNotesFromDB ("upcomingpending"); //all, upcomingpending, postponeded, ndays
            TreeA.Nodes.Clear ();
            GridB.DataSource = Db.DS.Tables ["tblNotesCount"];
            GridC.DataSource = null;
            SetMode (4); //A:- B:FNotes (~SNotes ?)
            }
        private void MenuB_ShowPostponded_Click (object sender, EventArgs e)
            {
            Note.GetSNotesFromDB ("postponeded"); //all, upcomingpending, postponeded, ndays
            TreeA.Nodes.Clear ();
            GridB.DataSource = Db.DS.Tables ["tblNotesCount"];
            GridC.DataSource = null;
            SetMode (4); //A:- B:FNotes
            }
        private void MenuB_ShowNDays_Click (object sender, EventArgs e)
            {
            MenuB_ShowNDays.SelectionStart = 0;
            MenuB_ShowNDays.SelectionLength = MenuB_ShowNDays.Text.Length;
            }
        private void MenuB_ShowNDays_TextChanged (object sender, EventArgs e)
            {
            if (MenuB_ShowNDays.Text.Trim () == "")
                {
                MenuB_ShowNDays.Text = " Show n days ";
                MenuB_ShowNDays.SelectionStart = 0;
                MenuB_ShowNDays.SelectionLength = MenuB_ShowNDays.Text.Length;
                }
            }
        private void MenuB_ShowNDays_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                try
                    {
                    Note.days = 0;
                    Note.days = Convert.ToInt32 (MenuB_ShowNDays.Text);
                    if ((Note.days != 0) && (Note.days < 94) && (Note.days > -94))
                        {
                        Note.GetSNotesFromDB ("ndays");
                        TreeA.Nodes.Clear ();
                        GridB.DataSource = Db.DS.Tables ["tblNotesCount"];
                        GridC.DataSource = null;
                        lblStatusBar.Text = "notes during <" + Note.days.ToString () + "> days";
                        SetMode (4); //A:- B:FNotes
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
                MenuB_ShowNDays.Text = " Show n days ";
                MenuB_ShowNDays.SelectionStart = 0;
                MenuB_ShowNDays.SelectionLength = MenuB_ShowNDays.Text.Length;
                e.SuppressKeyPress = true;
                }
            }
        //Menu-C
        private void MenuC_Read_Click (object sender, EventArgs e)
            {
            GridC_CellDoubleClick (null, null);
            }
        private void MenuC_Linkto_Click (object sender, EventArgs e)
            {
            //link a ref to a subproject
            switch (Assign.Mode)
                {
                case 29: //A:-  B:-        C:refs ?
                case 5:  //A:-  B:r-notes  C:refs ?
                        {
                        Ref.Id = Convert.ToInt32 (GridC.SelectedRows [0].Cells [0].Value);
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
                                GridC_CellClick (null, null);
                                }
                            else
                                {
                                MessageBox.Show ("Error linking the Ref to a SubProject!", "eLib", MessageBoxButtons.OK);
                                }
                            }
                        break;
                        }
                }
            }
        private void MenuC_CopyTitle_Click (object sender, EventArgs e)
            {
            int r = Convert.ToInt32 (GridC.SelectedRows [0].Index);
            if (r >= 0)
                {
                My.MyProject.Computer.Clipboard.SetText (GridC.Rows [r].Cells [1].Value.ToString ());
                lblStatusBar.Text = "copied: " + GridC.Rows [r].Cells [1].Value.ToString ();
                }
            }
        private void MenuC_QRCode_Click (object sender, EventArgs e)
            {
            int r = (int) GridC.SelectedRows [0].Index;
            if (r >= 0)
                {
                Client.GenerateQRCode (GridC.Rows [r].Cells [1].Value.ToString ());
                }
            }
        private void MenuC_Replace_Click (object sender, EventArgs e)
            {
            if ((GridC.SelectedRows [0].Index >= 0) && ((Assign.Mode == 50) || (Assign.Mode == 42)))
                {
                //50,42: C:link
                Link.Id = Convert.ToInt32 (GridC.SelectedRows [0].Cells [7].Value);
                Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
                My.MyProject.Forms.frmChooseProject.ShowDialog ();
                if (Client.DialogRequestParams == 32)
                    {
                    Assign.ReplaceALink (Link.Id, SubProject.Id);
                    TreeA_AfterSelect (null, null); //refresh
                    }
                }
            }
        private void MenuC_Attributes_Click (object sender, EventArgs e)
            {
            try
                {
                Project.Id = (TreeA.SelectedNode.Level == 0) ? Convert.ToInt32 (TreeA.SelectedNode.Tag) : Convert.ToInt32 (TreeA.SelectedNode.Parent.Tag);
                if (((Assign.Mode != 50) || (Assign.Mode != 42)) && (GridC.SelectedRows [0].Index != -1) && (Assign.CheckReadOnlyAccess (Project.Id) != 1))
                    {
                    //50,42: C:link
                    Link.Id = Convert.ToInt32 (GridC.SelectedRows [0].Cells [7].Value);       //7:LinkId
                    Ref.Title = (GridC.SelectedRows [0].Cells [1].Value).ToString ();         //1:paperName(refTitle)
                    Ref.Id = Convert.ToInt32 (GridC.SelectedRows [0].Cells [0].Value);        //0:PapersId(RefId)
                    SubProject.Id = Convert.ToInt32 (GridC.SelectedRows [0].Cells [6].Value); //6:SubProjectId
                    SubProject.Note = (GridC.SelectedRows [0].Cells [2].Value).ToString (); // 2:SubProject.Note
                    }
                Ref.Attributes = 0;
                //1111-1111 {ImR.Imp3.Imp2.Imp1.Lect.Man.Book.Paper}
                if (Convert.ToBoolean (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [2]) == true)
                    Ref.Attributes = Ref.Attributes | 1;
                if (Convert.ToBoolean (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [3]) == true)
                    Ref.Attributes = Ref.Attributes | 2;
                if (Convert.ToBoolean (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [4]) == true)
                    Ref.Attributes = Ref.Attributes | 4;
                if (Convert.ToBoolean (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [5]) == true)
                    Ref.Attributes = Ref.Attributes | 8;
                if (Convert.ToBoolean (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [8]) == true)
                    Ref.Attributes = Ref.Attributes | 16;
                if (Convert.ToBoolean (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [9]) == true)
                    Ref.Attributes = Ref.Attributes | 32;
                if (Convert.ToBoolean (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [10]) == true)
                    Ref.Attributes = Ref.Attributes | 64;
                if (Convert.ToBoolean (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [11]) == true)
                    Ref.Attributes = Ref.Attributes | 128;
                My.MyProject.Forms.frmRefAttributes.ShowDialog ();
                if (Client.DialogRequestParams == 16)
                    {
                    //16: ok! save
                    Assign.SetRefAttributes (Ref.Attributes);
                    //update grid row
                    (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [2]) = ((Ref.Attributes & 1) == 1) ? 1 : 0;
                    (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [3]) = ((Ref.Attributes & 2) == 2) ? 1 : 0;
                    (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [4]) = ((Ref.Attributes & 4) == 4) ? 1 : 0;
                    (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [5]) = ((Ref.Attributes & 8) == 8) ? 1 : 0;
                    (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [8]) = ((Ref.Attributes & 16) == 16) ? 1 : 0;
                    (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [9]) = ((Ref.Attributes & 32) == 32) ? 1 : 0;
                    (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [10]) = ((Ref.Attributes & 64) == 64) ? 1 : 0;
                    (Db.DS.Tables ["tblLinks"].Rows [GridC.SelectedRows [0].Index] [11]) = ((Ref.Attributes & 128) == 128) ? 1 : 0;
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString());
                return;
                }
            }
        private void MenuC_Delete_Click (object sender, EventArgs e)
            {
            if ((GridC.Rows.Count == 0) || (GridC.SelectedRows [0].Index == -1))
                {
                return;
                }
            else
                {
                switch (Assign.Mode)
                    {
                    case 50: //C:Link
                    case 42: //C:Link
                            {
                            if (Assign.CheckReadOnlyAccess (Project.Id) != 1)
                                {
                                Link.Id = Convert.ToInt32 (GridC.SelectedRows [0].Cells [7].Value); //7:LinkId
                                if (Assign.DeleteALink (Link.Id, true))
                                    {
                                    GridC.Rows.RemoveAt (GridC.SelectedRows [0].Index);
                                    }
                                }
                            break;
                            }
                    case 29: //C: Ref
                    case 5:  //C: Ref
                            {
                            Ref.Id = Convert.ToInt32 (GridC.SelectedRows [0].Cells [0].Value); //0:RefId
                            if (Assign.DeleteARef (Ref.Id, true))
                                {
                                GridC.Rows.RemoveAt (GridC.SelectedRows [0].Index);
                                }
                            break;
                            }
                    }
                GridB.DataSource = null;
                lblGridB.Text = "";
                lblDatum.Text = "";
                }
            }
        //Menu-T
        private void MenuT_RTL_Click (object sender, EventArgs e)
            {
            if (txtNote.RightToLeft == System.Windows.Forms.RightToLeft.No)
                {
                txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                txtNote.Font = new System.Drawing.Font ("Tahoma", 9);
                LED_Save.Visible = true;
                Note.NoteText += "%ObjectCahnged@"; //maked txtNote feel text has changed and doent equal Note.NoteText!
                }
            else
                {
                txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
                txtNote.Font = new System.Drawing.Font ("Consolas", 9);
                LED_Save.Visible = true;
                Note.NoteText += "%ObjectCahnged@"; //maked txtNote feel text has changed and doent equal Note.NoteText!
                }
            }
        private void MenuT_DateTime_Click (object sender, EventArgs e)
            {
            lblStatusBar.Text = "Date/Time changed from:  " + Note.DateTime + "   to: ";
            var frmTMDT = new frmTimeAndDate ();
            frmTMDT.ShowDialog ();
            if (Client.DialogRequestParams == 16)
                {
                GridB.Rows [GridB.SelectedRows [0].Index].Cells [1].Value = Note.DateTime;
                lblDatum.Text = Note.DateTime;
                lblStatusBar.Text += Note.DateTime;
                LED_Save.Visible = true;
                Note.NoteText += "%DateCahnged@"; //maked txtNote feel text has changed and doent equal Note.NoteText!
                txtNote.Focus ();
                }
            }
        private void MenuT_PendingDone_Click (object sender, EventArgs e)
            {
            if (LED_Pending.Visible)
                {
                LED_Pending.Visible = false;
                LED_Save.Visible = true;
                Note.NoteText += "%ObjectCahnged@"; //maked txtNote feel text has changed and doent equal Note.NoteText!
                }
            else
                {
                LED_Save.Visible = true;
                Note.NoteText += "%ObjectCahnged@"; //maked txtNote feel text has changed and doent equal Note.NoteText!
                LED_Pending.Visible = true;
                }
            }
        private void MenuT_Save_Click (object sender, EventArgs e)
            {
            SaveTheNote ();
            }
        private void LED_Save_Click (object sender, EventArgs e)
            {
            MenuT_Save_Click (null, null);
            }
        private void MenuT_Cancel_Click (object sender, EventArgs e)
            {
            CloseInlineNoteEditor ();
            lblStatusBar.Text = "Note not Saved!";
            }
        private void MenuT_Editor_Click (object sender, EventArgs e)
            {
            //{SubProjectNote, SubProjectNoteSearch, LinkNote, LinkNoteSearch, RefNote, RefNoteSearch} <- CallNoteEditor()
            try
                {
                switch (Assign.Mode)
                    {
                    case 50: //A:SP B:SNote
                            {
                            SubProject.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                            SubProject.Name = TreeA.SelectedNode.Text;
                            Note.Id = Convert.ToInt32 (Db.DS.Tables ["tblSNotes"].Rows [GridB.SelectedRows [0].Index] [0]);
                            Note.DateTime = (Db.DS.Tables ["tblSNotes"].Rows [GridB.SelectedRows [0].Index] [1]).ToString ();
                            Note.NoteText = (Db.DS.Tables ["tblSNotes"].Rows [GridB.SelectedRows [0].Index] [2]).ToString ();
                            Note.Index = (int) GridB.SelectedRows [0].Index;
                            if (Note.Id < 1)
                                return;
                            CallNoteEditor (50);
                            //refresh
                            CloseInlineNoteEditor ();
                            ShowUpcomingNotes (0);
                            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
                            TreeA.SelectedNode = null; //SubProject.Id; ------------------------------------------
                            ShowSNotesInGridB_LinksInGridC (Note.ParentID);
                            GridB.CurrentCell = GridB.Rows [Note.Index].Cells [1];
                            GridB.Focus ();
                            break;
                            }
                    case 16: //A:-  B:SNote ?
                            {
                            //tblNotesCount: 0:ProjectName, 1:SubProjectName, 2:NoteDatum, 3:Note, 4:Projects.ID, 5:SubProjects.ID, 6:Notes.ID, 7:Done, 8:Rtl
                            Project.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [GridB.SelectedRows [0].Index] [4]);
                            SubProject.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [GridB.SelectedRows [0].Index] [5]);
                            SubProject.Name = (Db.DS.Tables ["tblNotesCount"].Rows [GridB.SelectedRows [0].Index] [1]).ToString ();
                            Note.Index = (int) GridB.SelectedRows [0].Index;
                            Note.Id = (int) (Db.DS.Tables ["tblNotesCount"].Rows [GridB.SelectedRows [0].Index] [6]);
                            Note.DateTime = (Db.DS.Tables ["tblNotesCount"].Rows [GridB.SelectedRows [0].Index] [2]).ToString ();
                            Note.NoteText = (Db.DS.Tables ["tblNotesCount"].Rows [GridB.SelectedRows [0].Index] [3]).ToString ();
                            if (Note.Id < 1)
                                return;
                            CallNoteEditor (16);
                            //refresh
                            CloseInlineNoteEditor ();
                            ShowUpcomingNotes (0);
                            ShowProjectsInTreeA (User.Id, currentActiveMode, "");
                            TreeA.SelectedNode = null; //SubProject.Id; ----------------------------------
                            ShowSNotesInGridB_LinksInGridC (Note.ParentID);
                            GridB.CurrentCell = GridB.Rows [Note.Index].Cells [1];
                            GridB.Focus ();
                            break;
                            }
                    case 42: //A:SP B:LNotes
                            {
                            CallNoteEditor (42);
                            break;
                            }
                    case 5: //A:-  B:RNotes
                            {
                            CallNoteEditor (5);
                            break;
                            }
                    default:
                            {
                            return;
                            }
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                }
            }
        private void MenuT_Find_Click (object sender, EventArgs e)
            {
            MenuT_Find.SelectionStart = 0;
            MenuT_Find.SelectionLength = MenuT_Find.TextLength;
            }
        private void MenuT_Find_TextChanged (object sender, EventArgs e)
            {
            if (String.IsNullOrEmpty (MenuT_Find.Text))
                {
                MenuT_Find.Text = "Find text";
                MenuT_Find.SelectionStart = 0;
                MenuT_Find.SelectionLength = MenuT_Find.TextLength;
                }
            }
        private void MenuT_Find_KeyDown (object sender, KeyEventArgs e)
            {
            if ((e.KeyCode == Keys.Enter) && (!String.IsNullOrEmpty (MenuT_Find.Text)))
                {
                int pos = Strings.InStr ((txtNote.SelectionStart + 1), txtNote.Text.ToLower (), MenuT_Find.Text.ToLower ());
                if (pos > 0)
                    {
                    MenuT.Visible = false;
                    txtNote.SelectionStart = (pos - 1);
                    txtNote.SelectionLength = MenuT_Find.TextLength;
                    txtNote.ScrollToCaret ();
                    e.SuppressKeyPress = true;
                    }
                else
                    {
                    MenuT.Visible = false;
                    lblStatusBar.Text = "not found!";
                    e.SuppressKeyPress = true;
                    }
                }
            }
        //Methods
        private void BoldDatesOnCalendar (string tblType)
            {
            int rx = 0;
            string tmpDate = "";
            mntCal.RemoveAllBoldedDates ();
            mntCal.UpdateBoldedDates ();
            foreach (DataRow r in Db.DS.Tables [tblType].Rows)
                {
                rx++;
                tmpDate = Strings.Left (r ["NoteDatum"].ToString (), 10);
                mntCal.AddBoldedDate (DateTime.Parse (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                }
            mntCal.UpdateBoldedDates ();
            }
        private void timer1_Tick (object sender, EventArgs e)
            {
            this.Text = "mode " + Assign.Mode.ToString ();
            }
        private void ExpandFirstProjectInTreeA ()
            {
            TreeA.Focus ();
            if (TreeA.Nodes.Count > 0)
                {
                TreeA.SelectedNode = TreeA.Nodes [0];
                }
            }
        private void ShowUpcomingNotes (int actiontype)
            {
            //0: just hilight leds, 1:also feed data in grid-b
            //collaps text-editor (if visible)
            CloseInlineNoteEditor ();
            //get data
            Note.GetSNotesFromDB ("all");
            //feed grid-b
            if (actiontype == 1)
                {
                TreeA.Nodes.Clear ();
                GridB.DataSource = Db.DS.Tables ["tblNotesCount"];
                BoldDatesOnCalendar ("tblNotesCount");
                GridC.DataSource = null;
                SetMode (4); //A:- B:FNotes
                }
            //LEDs (in both cases)
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
            //set some leds on
            clrR = 220;
            clrG = 220;
            clrB = 220;
            if (User.NotesDay6 > 0)
                lblDay6.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay5 > 0)
                lblDay5.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay4 > 0)
                lblDay4.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay3 > 0)
                lblDay3.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay2 > 0)
                lblDay2.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay1 > 0)
                lblDay1.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB);
            if (User.NotesDay0 > 0)
                lblDay0.BackColor = System.Drawing.Color.FromArgb (clrR, clrG, clrB); //MistyRose //245, 200, 200
            }
        private void ShowFNotesForm ()
            {
            if (Db.DS.Tables ["tblNotesCount"].Rows.Count != 0)
                {
                var frmUpcomingNT = new frmUpcomingNotes ();
                frmUpcomingNT.ShowDialog ();
                }
            }
        //Mode
        private void SetMode (int modex)
            {
            lblDatum.Text = "";
            CloseInlineNoteEditor ();
            Assign.Mode = modex;
            switch (modex)
                {
                case 4:
                        {
                        //A:-  B:f-notes  C:-
                        FormatGridB ("FNotes");
                        BoldDatesOnCalendar ("tblNotesCount");
                        SetMenuTreeA ("");
                        SetMenuGridB ("");
                        SetMenuGridC ("");
                        txtSearch.Text = "";
                        lblGridB.Text = "";
                        lblGridC.Text = "";
                        lblStatusBar.Text = "";

                        break;
                        }
                case 64:
                        {
                        //A:projects  B:-  C:-
                        SetMenuTreeA ("Projects");
                        SetMenuGridB ("");
                        SetMenuGridC ("");
                        txtSearch.Text = "";
                        lblGridB.Text = "";
                        lblGridC.Text = "";
                        lblStatusBar.Text = "";
                        break;
                        }
                case 32:
                        {
                        //A:subprojects  B:-  C:-
                        SetMenuTreeA ("SubProjects");
                        SetMenuGridB ("");
                        SetMenuGridC ("");
                        lblGridB.Text = "";
                        lblGridC.Text = "";
                        lblStatusBar.Text = "";
                        break;
                        }

                case 50:
                        {
                        //A:subprojects  B:s-notes  C:links
                        FormatGridB ("SNotes");
                        BoldDatesOnCalendar ("tblSNotes");
                        FormatGridC ("Links");
                        SetMenuTreeA ("SubProjects");
                        SetMenuGridB ("SNotes");
                        SetMenuGridC ("Links");
                        lblGridB.Text = "SubProject Notes";
                        lblGridC.Text = "Links";
                        lblStatusBar.Text = "";
                        break;
                        }
                case 16:
                        {
                        //A:-  B:s-notes?  C:-
                        FormatGridB ("SNotes");
                        BoldDatesOnCalendar ("tblSNotes");
                        SetMenuTreeA ("");
                        SetMenuGridB ("SNotes");
                        SetMenuGridC ("");
                        //lblListA.Text = "Click: Projects";
                        lblGridB.Text = "SubProject Notes";
                        lblGridC.Text = "";
                        lblStatusBar.Text = "";
                        break;
                        }
                case 42:
                        {
                        //A:subprojects  B:l-notes  C:links
                        FormatGridB ("LNotes");
                        BoldDatesOnCalendar ("tblLNotes");
                        FormatGridC ("Links");
                        SetMenuTreeA ("SubProjects");
                        SetMenuGridB ("LNotes");
                        SetMenuGridC ("Links");
                        lblGridB.Text = "Link Notes";
                        lblGridC.Text = "Links";
                        lblStatusBar.Text = "";
                        break;
                        }
                case 29:
                        {
                        //A:-  B:slr-notes  C:refs
                        FormatGridB ("RNotes");
                        BoldDatesOnCalendar ("tblRNotes");
                        FormatGridC ("Refs");
                        SetMenuTreeA ("");
                        SetMenuGridB ("");
                        SetMenuGridC ("Refs");
                        lblGridB.Text = "Notes (searched)";
                        lblGridC.Text = "Refs";
                        lblStatusBar.Text = "";
                        break;
                        }
                case 5:
                        {
                        //A:-  B:r-notes  C:refs
                        FormatGridB ("RNotes");
                        BoldDatesOnCalendar ("tblRNotes");
                        FormatGridC ("Refs");
                        SetMenuTreeA ("Projects");
                        SetMenuGridB ("RNotes");
                        SetMenuGridC ("Refs");
                        lblGridB.Text = "Ref Notes";
                        lblGridC.Text = "Refs";
                        lblStatusBar.Text = "";
                        break;
                        }
                }
            }
        private void FormatGridB (string tblx)
            {
            if (GridB.Rows.Count == 0)
                {
                return;
                }
            //Assign.GetNotes (0, 3); //initialize columns of gridB fortblRNotes(type=3)
            try
                {
                for (int i = 0, loopTo = GridB.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                    {
                    GridB.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                }
            catch (Exception ex) { }
            //grid columns total:960px
            switch (tblx)
                {
                case "SNotes":
                case "LNotes":
                case "RNotes":
                        {
                        //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                        GridB.Columns [0].Visible = false;   //ID
                        GridB.Columns [1].Width = 160;       //NoteDatum
                        GridB.Columns [2].Width = 730;       //Note
                        GridB.Columns [3].Visible = false;   //Parent_ID 
                        GridB.Columns [4].Visible = false;   //ParentType
                        GridB.Columns [5].Visible = false;   //Rtl
                        GridB.Columns [6].Width = 40;        //Done
                        GridB.Columns [7].Visible = false;   //User_ID
                        GridB.Columns [8].Visible = false;   //Shared
                        break;
                        }
                case "FNotes":
                        {
                        //0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done, 8Rtl
                        GridB.Columns [0].Width = 180;          //ProjectName
                        GridB.Columns [1].Width = 200;          //SubProjectName
                        GridB.Columns [2].Width = 120;          //NoteDatum
                        GridB.Columns [3].Width = 400;          //Note
                        GridB.Columns [4].Visible = false;      //Projects.ID
                        GridB.Columns [5].Visible = false;      //SubProjects.ID
                        GridB.Columns [6].Visible = false;      //Notes.ID
                        GridB.Columns [7].Width = 30;           //Done
                        GridB.Columns [8].Visible = false;      //Rtl
                        break;
                        }
                }
            }
        private void FormatGridC (String tblx)
            {
            try
                {
                for (int i = 0, loopTo = GridC.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                    {
                    GridC.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                }
            catch (Exception ex) { }
            switch (tblx)
                {
                case "Links":
                        {
                        //Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, SubProject_ID, Links.ID AS LinkID, Imp1, Imp2, Imp3, ImR
                        GridC.Columns [0].Visible = false;      //Papers.ID
                        GridC.Columns [1].Width = 950;          //PaperName
                        GridC.Columns [2].Visible = false;      //IsPaper
                        GridC.Columns [3].Visible = false;      //IsBook
                        GridC.Columns [4].Visible = false;      //IsManual
                        GridC.Columns [5].Visible = false;      //IsLecture
                        GridC.Columns [6].Visible = false;      //SubProject_ID
                        GridC.Columns [7].Visible = false;      //Links.ID AS LinkID
                        GridC.Columns [8].Visible = false;      //Imp1
                        GridC.Columns [9].Visible = false;      //Imp2
                        GridC.Columns [10].Visible = false;     //Imp3
                        GridC.Columns [11].Visible = false;     //ImR
                        break;
                        }
                case "Refs":
                        {
                        //Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture
                        GridC.Columns [0].Visible = false;      //ID
                        GridC.Columns [1].Width = 920;          //PaperName
                        GridC.Columns [2].Visible = false;      //IsPaper
                        GridC.Columns [3].Visible = false;      //IsBook
                        GridC.Columns [4].Visible = false;      //IsManual
                        GridC.Columns [5].Visible = false;      //IsLecture
                        break;
                        }
                }
            }
        private void SetMenuTreeA (string menu)
            {
            switch (menu)
                {
                case "":
                        {
                        TreeA.ContextMenuStrip = null;
                        break;
                        }
                case "Projects":
                        {
                        TreeA.ContextMenuStrip = MenuA;
                        MenuA_AddNew.Visible = true;
                        MenuA_AddNewSubProject.Visible = true;
                        MenuA_Edit.Visible = true;
                        MenuA_Delete.Visible = true;
                        MenuA_Search.Visible = true;
                        MenuA_Div.Visible = true;
                        MenuA_ShowActive.Visible = true;
                        MenuA_ShowInactive.Visible = true;
                        MenuA_ShowAll.Visible = true;
                        MenuA_Replace.Visible = false;
                        MenuA_Import.Visible = true;
                        MenuA_Exit.Visible = true;
                        break;
                        }
                case "SubProjects":
                        {
                        TreeA.ContextMenuStrip = MenuA;
                        MenuA_AddNew.Visible = true;
                        MenuA_AddNewSubProject.Visible = true;
                        MenuA_Edit.Visible = true;
                        MenuA_Delete.Visible = true;
                        MenuA_Search.Visible = false;
                        MenuA_Div.Visible = true;
                        MenuA_ShowActive.Visible = true;
                        MenuA_ShowInactive.Visible = true;
                        MenuA_ShowAll.Visible = true;
                        MenuA_Replace.Visible = true;
                        MenuA_Import.Visible = true;
                        MenuA_Exit.Visible = true;
                        break;
                        }
                }
            }
        private void SetMenuGridB (string menu)
            {
            switch (menu)
                {
                case "":
                        {
                        GridB.ContextMenuStrip = MenuB;
                        MenuB_Add.Visible = false;
                        MenuB_Edit.Visible = false;
                        MenuB_Delete.Visible = true;
                        MenuB_Search.Visible = true;
                        MenuB_DateTime.Visible = true;
                        MenuB_Replace.Visible = false;
                        MenuB_MindMap.Visible = false;
                        MenuB_Moveto.Visible = false;
                        MenuB_Show.Visible = true;
                        lbl_NewNote.Visible = false;
                        break;
                        }
                case "SNotes":
                        {
                        GridB.ContextMenuStrip = MenuB;
                        MenuB_Add.Visible = true;
                        MenuB_Edit.Visible = true;
                        MenuB_Delete.Visible = true;
                        MenuB_Search.Visible = true;
                        MenuB_DateTime.Visible = true;
                        MenuB_Replace.Visible = true;
                        MenuB_MindMap.Visible = true;
                        MenuB_Moveto.Visible = true;
                        MenuB_Show.Visible = true;
                        lbl_NewNote.Visible = true;
                        break;
                        }
                case "FNotes":
                        {
                        GridB.ContextMenuStrip = MenuB;
                        MenuB_Add.Visible = true;
                        MenuB_Edit.Visible = true;
                        MenuB_Delete.Visible = true;
                        MenuB_Search.Visible = true;
                        MenuB_DateTime.Visible = true;
                        MenuB_Replace.Visible = true;
                        MenuB_MindMap.Visible = true;
                        MenuB_Moveto.Visible = true;
                        MenuB_Show.Visible = true;
                        lbl_NewNote.Visible = false;
                        break;
                        }
                case "LNotes":
                        {
                        GridB.ContextMenuStrip = MenuB;
                        MenuB_Add.Visible = true;
                        MenuB_Edit.Visible = true;
                        MenuB_Delete.Visible = true;
                        MenuB_Search.Visible = true;
                        MenuB_DateTime.Visible = true;
                        MenuB_Replace.Visible = true;
                        MenuB_MindMap.Visible = false;
                        MenuB_Moveto.Visible = true;
                        MenuB_Show.Visible = true;
                        lbl_NewNote.Visible = true;
                        break;
                        }
                case "RNotes":
                        {
                        GridB.ContextMenuStrip = MenuB;
                        MenuB_Add.Visible = true;
                        MenuB_Edit.Visible = true;
                        MenuB_Delete.Visible = true;
                        MenuB_Search.Visible = true;
                        MenuB_DateTime.Visible = true;
                        MenuB_Replace.Visible = true;
                        MenuB_MindMap.Visible = false;
                        MenuB_Moveto.Visible = true;
                        MenuB_Show.Visible = true;
                        lbl_NewNote.Visible = true;
                        break;
                        }
                }
            }
        private void SetMenuGridC (string menu)
            {
            switch (menu)
                {
                case "":
                        {
                        GridC.ContextMenuStrip = null;
                        break;
                        }
                case "Links":
                        {
                        GridC.ContextMenuStrip = MenuC;
                        MenuC_Read.Visible = true;
                        MenuC_Linkto.Visible = false;
                        MenuC_Delete.Visible = true;
                        MenuC_CopyTitle.Visible = true;
                        MenuC_QRCode.Visible = true;
                        MenuC_Replace.Visible = true;
                        MenuC_Attributes.Visible = true;
                        break;
                        }
                case "Refs":
                        {
                        GridC.ContextMenuStrip = MenuC;
                        MenuC_Read.Visible = true;
                        MenuC_Linkto.Visible = true;
                        MenuC_Delete.Visible = true;
                        MenuC_CopyTitle.Visible = true;
                        MenuC_QRCode.Visible = true;
                        MenuC_Replace.Visible = false;
                        MenuC_Attributes.Visible = false;
                        break;
                        }
                }
            }
        private void ShowProjectsInTreeA (int intUserId, int intActiveMode, string strSearch)
            {
            try
                {
                //reset
                SubProject.Id = 0;
                SubProject.Name = "";
                TreeA.Nodes.Clear ();
                //Level-1 : projects
                Assign.GetProjects (intUserId, intActiveMode, strSearch); //0:active 1:inactive 2:all 3:search
                for (int i = 0; i < Db.DS.Tables ["tblProject"].Rows.Count; i++)
                    {
                    TreeNode nd1 = new TreeNode { Text = "", Tag = "" };
                    nd1.Text = Db.DS.Tables ["tblProject"].Rows [i] [1].ToString ();
                    nd1.Tag = Db.DS.Tables ["tblProject"].Rows [i] [0].ToString ();
                    TreeA.Nodes.Add (nd1);
                    //Level-2 : subprojects
                    Project.Id = Convert.ToInt32 (Db.DS.Tables ["tblProject"].Rows [i] [0]);
                    Assign.GetSubProjects (Project.Id);
                    for (int j = 0; j < Db.DS.Tables ["tblSubProject"].Rows.Count; j++)
                        {
                        TreeNode nd2 = new TreeNode { Text = "", Tag = "" };
                        nd2.Text = Db.DS.Tables ["tblSubProject"].Rows [j] [1].ToString (); //ID, SubProjectName, Notes, Project_ID
                        nd2.Tag = Db.DS.Tables ["tblSubProject"].Rows [j] [0].ToString ();
                        TreeA.Nodes [i].Nodes.Add (nd2);
                        }
                    }
                lblListA.Text = "Projects";
                //TreeA.ExpandAll ();
                TreeA.CollapseAll ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            GridB.DataSource = null;
            GridC.DataSource = null;
            CloseInlineNoteEditor ();
            SetMode (64); //A:P
            //menuA checks
            switch (intActiveMode)
                {
                case 0:
                        {
                        MenuA_ShowAll.Checked = false;
                        MenuA_ShowActive.Checked = false;
                        MenuA_ShowInactive.Checked = false;
                        MenuA_ShowActive.Checked = true;
                        break;
                        }
                case 1:
                        {
                        MenuA_ShowAll.Checked = false;
                        MenuA_ShowActive.Checked = false;
                        MenuA_ShowInactive.Checked = false;
                        MenuA_ShowInactive.Checked = true;
                        break;
                        }
                case 2:
                        {
                        MenuA_ShowAll.Checked = false;
                        MenuA_ShowActive.Checked = false;
                        MenuA_ShowInactive.Checked = false;
                        MenuA_ShowAll.Checked = true;
                        break;
                        }
                }
            }
        private void ShowSNotesInGridB_LinksInGridC (int intSubProjectId)
            {
            Assign.GetNotes (SubProject.Id, 1); //ParentTypes (get notes): 1:SNotes, 2:LNotes, 3:RNotes
            GridB.DataSource = Db.DS.Tables ["tblSNotes"];
            Assign.GetSLinks (SubProject.Id);
            GridC.DataSource = Db.DS.Tables ["tblLinks"];
            SetMode (50);
            }
        private void ShareAProject (int projectId)
            {
            //check if project is mine or a shared project
            if (Convert.ToInt32 (Db.DS.Tables ["tblProject"].Rows [Convert.ToInt32 (TreeA.SelectedNode.Index)] [4].ToString ()) != User.Id)
                {
                DialogResult i = MessageBox.Show ("Leave Group?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (i == DialogResult.Yes)
                    {
                    DialogResult ii = MessageBox.Show ("Sure?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (ii == DialogResult.No)
                        {
                        return;
                        }
                    else
                        {
                        //remove sharing
                        try
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "DELETE FROM User_Project WHERE (User_Id = " + User.Id.ToString () + " AND Project_Id=" + projectId.ToString () + ")";
                                CnnSS.Open ();
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
                }
            else
                {
                var frmShare = new frmProjectShare ();
                frmShare.ShowDialog ();
                TreeA.Focus ();
                ShowProjectsInTreeA (User.Id, currentActiveMode, "");
                SetMode (64);
                }
            }
        //editor
        private void ShowTextInInlineEditor (string txt, Boolean rtl, Boolean done, Boolean focus)
            {
            txtNote.Visible = true;
            LED_Save.Visible = false;
            Note.NoteText = txt;
            txtNote.Text = txt;
            if (rtl)
                {
                txtNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                txtNote.Font = new System.Drawing.Font ("Tahoma", 9);
                }
            else
                {
                txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No;
                txtNote.Font = new System.Drawing.Font ("Consolas", 9);
                }
            if (done)
                {
                LED_Pending.Visible = false;
                }
            else
                {
                LED_Pending.Visible = true;
                }
            txtNote.Enabled = true;
            txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //focus
            if (focus)
                {
                txtNote.Focus ();
                txtNote.SelectionStart = 0;
                txtNote.SelectionLength = 0;
                }
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
            //Save
            if (Assign.Mode == 4)
                {
                Note.DateTime = GridB.Rows [GridB.SelectedRows [0].Index].Cells [2].Value.ToString (); //focus-notes
                }
            else
                {
                Note.DateTime = GridB.Rows [GridB.SelectedRows [0].Index].Cells [1].Value.ToString ();
                }
            Note.NoteText = txtNote.Text;
            Note.Index = GridB.CurrentRow.Index;
            if (txtNote.RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                {
                Note.Rtl = true;
                }
            else
                {
                Note.Rtl = false;
                }
            if (!LED_Pending.Visible)
                {
                Note.Done = true;
                }
            else
                {
                Note.Done = false;
                }
            Note.SaveNote (Note.Id, Note.NoteText, Note.DateTime, Note.Rtl, Note.Done);
            //refresh grid-b
            //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
            //switch (Note.ParentType)
            //    {
            //    case 1: //s-note
            //            {
            //            GridB.DataSource = Db.DS.Tables ["tblSNotes"];
            //            break;
            //            }
            //    case 2: //l-note
            //            {
            //            GridB.DataSource = Db.DS.Tables ["tblLNotes"];
            //            break;
            //            }
            //    case 3: //r-note
            //            {
            //            GridB.DataSource = Db.DS.Tables ["tblRNotes"];
            //            break;
            //            }
            //    }


            if (Assign.Mode == 4)
                {
                //0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done, 8Rtl
                GridB.Rows [Note.Index].Cells [2].Value = Note.DateTime; //datetime
                GridB.Rows [Note.Index].Cells [3].Value = Note.NoteText; //note
                GridB.Rows [Note.Index].Cells [7].Value = Note.Done; //done
                GridB.Rows [Note.Index].Cells [8].Value = Note.Rtl; //rtl
                }
            else
                {
                GridB.Rows [Note.Index].Cells [1].Value = Note.DateTime; //datetime
                GridB.Rows [Note.Index].Cells [2].Value = Note.NoteText; //note
                GridB.Rows [Note.Index].Cells [6].Value = Note.Done; //done
                GridB.Rows [Note.Index].Cells [5].Value = Note.Rtl; //rtl
                }
            CloseInlineNoteEditor ();
            lblStatusBar.Text = "Note Saved";
            LED_Save.Visible = false;
            }
        private void CloseInlineNoteEditor ()
            {
            try
                {
                txtNote.Enabled = false;
                txtNote.Visible = false;
                LED_Pending.Visible = false;
                GridB.Enabled = true;
                GridC.Enabled = true;
                GridB.Focus ();
                GridB.Rows [Note.Index].Cells [1].Selected = true;
                }
            catch (Exception ex) { }
            }
        private void CallNoteEditor (int modex)
            {
            switch (modex)
                {
                case 50:
                        {
                        Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Parent.Tag);
                        Note.Type = "SubProjectNote";
                        Note.ParentType = 1; //ParentTypes: 1:SubProject 2:Link 3:Ref
                        break;
                        }
                case 16:
                        {
                        Note.Type = "SubProjectNoteSearch";
                        Note.ParentType = 1;
                        break;
                        }
                case 42:
                        {
                        Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Parent.Tag);
                        Note.Type = "LinkNote";
                        Note.ParentType = 2;
                        break;
                        }
                case 5:
                        {
                        Note.Type = "RefNote";
                        Note.ParentType = 3;
                        break;
                        }
                }
            //call editor
            Project.Name = TreeA.SelectedNode.Parent.Text;
            lblDatum.Text = "";
            var frmNote_Editor = new frmNotes ();
            frmNote_Editor.ShowDialog ();
            //My.MyProject.Forms.frmNotes.ShowDialog ();
            //refresh lists
            switch (Note.Type)
                {
                case "SubProjectNote":
                        {
                        break;
                        }
                case "SubProjectNoteSearch":
                        {
                        ShowUpcomingNotes (0);
                        GridB.Focus (); //SelectedValue = Note.Id;
                        break;
                        }
                case "LinkNote":
                case "LinkNoteSearch":
                        {
                        GridB.Focus (); //SelectedValue = Note.Id;
                        break;
                        }
                case "RefNote":
                case "RefNoteSearch":
                        {
                        GridB.Focus (); //SelectedValue = Note.Id;
                        break;
                        }
                }
            }
        //other forms
        private void Augustusmate ()
            {
            if (TreeA.SelectedNode != null)
                {
                Client.DialogRequestParams = 8; //BIT4(=8): 0:new, 1:Edit
                Project.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
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
        private void Import ()
            {
            Ref.ImportStatus = 2; //NewImport from main (w/o link)
            try
                {
                if (SubProject.Id != 0)
                    {
                    SubProject.Id = Convert.ToInt32 (TreeA.SelectedNode.Tag);
                    SubProject.Name = TreeA.SelectedNode.Text;
                    Ref.ImportStatus = 6; //NewImport from main with link
                    }
                else
                    {
                    Ref.ImportStatus = 2; //NewImport from main (w/o link)
                    }
                }
            catch { }
            WindowState = FormWindowState.Minimized;
            My.MyProject.Forms.frmImportRefs.ShowDialog ();
            WindowState = FormWindowState.Normal;
            //--refresh treeA:
            ShowProjectsInTreeA (User.Id, currentActiveMode, ""); //2:all
            }
        private void ShowFamForSelectedNote ()
            {
            if ((GridB.Rows.Count > 0) && (GridB.SelectedRows [0].Index != -1))
                {
                if (Assign.Mode == 4)
                    {
                    //f-Notes: 0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done, 8Rtl
                    Note.Id = Convert.ToInt32 (GridB.SelectedRows [0].Cells [6].Value);
                    Note.ParentID = Convert.ToInt32 (GridB.SelectedRows [0].Cells [5].Value); //Note.ParentID for a SNote equals SubProject.Id
                    Note.ParentType = 1; //(is 1 always?) ParentTypes: 1:SubProject 2:Link 3:Ref                            
                    }
                else
                    {
                    //SLR-Notes : [0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared -> FROM Notes]
                    Note.Id = Convert.ToInt32 (GridB.SelectedRows [0].Cells [0].Value);
                    Note.ParentID = Convert.ToInt32 (GridB.SelectedRows [0].Cells [3].Value); //Note.ParentID for a SNote equals SubProject.Id
                    Note.ParentType = Convert.ToInt32 (GridB.SelectedRows [0].Cells [4].Value); //ParentTypes: 1:SubProject 2:Link 3:Ref                            
                    }
                //MessageBox.Show ("line 1053 : ParentType = " + Note.ParentType.ToString());
                switch (Note.ParentType)
                    {
                    case 1: //-fam for selected SNote
                            {
                            //step1: focus on subproject
                            ShowProjectsInTreeA (User.Id, 2, ""); //0:active 1:inactive 2:all 3:search
                            for (int i = 0; i < TreeA.Nodes.Count; i++)
                                {
                                for (int j = 0; j < TreeA.Nodes [i].Nodes.Count; j++)
                                    {
                                    //lblStatusBar.Text = "count: " + TreeA.Nodes.Count.ToString () + "    i: " + i.ToString () + "    j: " + j.ToString ();
                                    if (Convert.ToInt32 (TreeA.Nodes [i].Nodes [j].Tag) == Note.ParentID)
                                        {
                                        TreeA.SelectedNode = TreeA.Nodes [i].Nodes [j];
                                        lblStatusBar.Text = "found!";
                                        GridB.CurrentCell = GridB.Rows [0].Cells [1];
                                        SetMode (50);
                                        i = TreeA.Nodes.Count + 1; //exit loop
                                        break;
                                        }
                                    }
                                }
                            //step2: show sisters (SNotes of this subproject)
                            ShowSNotesInGridB_LinksInGridC (Note.ParentID); //Note.ParentID for a SNote equals SubProject.Id
                            for (int n = 0; n < GridB.Rows.Count; n++)
                                {
                                if (Convert.ToInt32 (GridB.Rows [n].Cells [0].Value) == Note.Id)
                                    {
                                    GridB.CurrentCell = GridB.Rows [n].Cells [1];
                                    SetMode (50);
                                    n = GridB.Rows.Count + 1; //exit loop
                                    break;
                                    }
                                }
                            TreeA.Focus ();
                            break;
                            }
                    case 2: //-fam for selected LNote
                            {
                            //step1: focus on subproject
                            ShowProjectsInTreeA (User.Id, 2, ""); //0:active 1:inactive 2:all 3:search
                            Link.Id = Note.ParentID;
                            SubProject.Id = Assign.GetSubProjectIdByLinkId (Note.ParentID); //ie Link.Id
                            if (SubProject.Id == 0)
                                {
                                return;
                                }
                            for (int i = 0; i < TreeA.Nodes.Count; i++)
                                {
                                for (int j = 0; j < TreeA.Nodes [i].Nodes.Count; j++)
                                    {
                                    if (Convert.ToInt32 (TreeA.Nodes [i].Nodes [j].Tag) == SubProject.Id)
                                        {
                                        TreeA.SelectedNode = TreeA.Nodes [i].Nodes [j];
                                        lblStatusBar.Text = "found!";
                                        i = TreeA.Nodes.Count + 1; //exit loop
                                        break;
                                        }
                                    }
                                }
                            //step2: show links of this subproject in grid-C
                            Assign.GetSLinks (SubProject.Id);
                            GridC.DataSource = Db.DS.Tables ["tblLinks"];
                            FormatGridC ("Links");
                            SetMenuGridC ("Links");
                            //step3: show sisters (LNotes of this link in grid-B)
                            Assign.GetNotes (Note.ParentID, 2); //ParentTypes (get notes): 1:SNotes, 2:LNotes, 3:RNotes
                            SetMode (42);
                            for (int n = 0; n < GridB.Rows.Count; n++)
                                {
                                if (Convert.ToInt32 (GridB.Rows [n].Cells [0].Value) == Note.Id)
                                    {
                                    GridB.CurrentCell = GridB.Rows [n].Cells [1];
                                    n = GridB.Rows.Count + 1; //exit loop
                                    break;
                                    }
                                }
                            //step4: locate link in grid-c
                            for (int l = 0; l < GridC.Rows.Count; l++)
                                {
                                if (Convert.ToInt32 (GridC.Rows [l].Cells [7].Value) == Note.ParentID) //7:link_id
                                    {
                                    GridC.CurrentCell = GridC.Rows [l].Cells [1];
                                    GridC_CellClick (null, null); //show l-note in grid-b
                                    l = GridC.Rows.Count + 1; //exit loop
                                    break;
                                    }
                                }
                            TreeA.Focus ();
                            break;
                            }
                    case 3: //-fam for selected RNote
                            {
                            //show ref in gridC
                            //show RNotes of this ref in B
                            //step1: get ref by id to show it in C
                            int res = Assign.GetRefByRefId (Note.ParentID);
                            if (res == 0)
                                {
                                return;
                                }
                            GridC.DataSource = Db.DS.Tables ["tblRefs"];
                            FormatGridC ("Refs");
                            SetMenuGridC ("Refs");
                            //step2: show sisters (RNotes of this ref in grid-b)
                            Assign.GetNotes (Note.ParentID, 3); //ParentTypes (get notes): 1:SNotes, 2:LNotes, 3:RNotes
                            for (int n = 0; n < GridB.Rows.Count; n++)
                                {
                                if (Convert.ToInt32 (GridB.Rows [n].Cells [0].Value) == Note.Id)
                                    {
                                    GridB.CurrentCell = GridB.Rows [n].Cells [1];
                                    SetMode (5);
                                    n = GridB.Rows.Count + 1; //exit loop
                                    break;
                                    }
                                }
                            break;
                            }
                    }
                lblStatusBar.Text = "family not found!";
                }
            txtSearch.Text = "";
            }
        private void btn_Explore_Click (object sender, EventArgs e)
            {
            My.MyProject.Forms.frmFolderRefs.ShowDialog ();
            }
        private void btn_Mindmap_Click (object sender, EventArgs e)
            {
            //Note.Type = ? {FocusNote SubProjectNote SubProjectNoteSearch LinkNote LinkNoteSearch RefNote RefNoteSearch}
            try
                {
                if (GridB.SelectedRows [0].Index != -1)
                    {
                    switch (Assign.Mode)
                        {
                        case 50:
                                {
                                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                                Note.Id = (int) GridB [0, GridB.SelectedRows [0].Index].Value;
                                Note.Type = "SubProjectNote";
                                break;
                                }
                        case 16:
                                {
                                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                                Note.Id = (int) GridB [0, GridB.SelectedRows [0].Index].Value;
                                Note.Type = "SubProjectNote";
                                break;
                                }
                        case 42:
                                {
                                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                                Note.Id = (int) GridB [0, GridB.SelectedRows [0].Index].Value;
                                Note.Type = "LinkNote";
                                break;
                                }
                        case 5:
                                {
                                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                                Note.Id = (int) GridB [0, GridB.SelectedRows [0].Index].Value;
                                Note.Type = "RefNote";
                                break;
                                }
                        case 4:
                                {
                                //0ProjectName, 1SubProjectName, 2NoteDatum, 3Note, 4Projects.ID, 5SubProjects.ID, 6Notes.ID, 7Done, 8Rtl
                                SubProject.Id = (int) GridB [5, GridB.SelectedRows [0].Index].Value;
                                Note.Id = (int) GridB [6, GridB.SelectedRows [0].Index].Value;
                                Note.Type = "FocusNote"; //this signal tells NoteNet that must use ["tblNotesCount"]
                                break;
                                }
                        }
                    var frmMindmap = new frmNoteNetEditor ();
                    frmMindmap.ShowDialog ();
                    }
                }
            catch { }
            }

        private void btn_Upcoming_Click (object sender, EventArgs e)
            {
            lblDay0_Click (null, null);
            }
        }
    }
