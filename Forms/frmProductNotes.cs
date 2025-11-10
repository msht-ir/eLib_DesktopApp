using eLib.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmNotes
        {
        private bool initialLoadingPhase = true;
        public frmNotes ()
            {
            InitializeComponent ();
            }
        private void frmNotes_Load (object sender, EventArgs e)
            {
            this.Width = 1330;
            this.Height = 690;
            //MessageBox.Show (Project.Name);
            int intYear = Convert.ToInt32 (DateTime.Now.ToString ("yyyy").ToString ());
            if (intYear < 1450)
                {
                MC1.RightToLeft = RightToLeft.Yes;
                MC1.RightToLeftLayout = true;
                }
            else
                {
                MC1.RightToLeft = RightToLeft.No;
                MC1.RightToLeftLayout = false;
                }
            this.Text = "Notes";
            //MessageBox.Show ("ProjectID: " + Project.Id.ToString() + "\nNoteType: " + Note.Type+ "\nSpID: " + SubProject.Id.ToString () + "\nNoteID: " + Note.Id.ToString () + "\nParentType: " + Note.ParentType + "\nParentId: " + Note.ParentID.ToString ());
            switch (Note.Type)
                {
                case "SubProjectNote":
                        {
                        this.Text = Project.Name;
                        Assign.GetSubProjects (Project.Id);
                        cboSubproject.DataSource = Db.DS.Tables ["tblSubProject"];
                        cboSubproject.DisplayMember = "SubProjectName";
                        cboSubproject.ValueMember = "ID";
                        cboSubproject.SelectedValue = SubProject.Id;
                        txtNote.Text = "";
                        Grid6.DataSource = Db.DS.Tables ["tblSNotes"];//GetNotes (SubProject.Id);                   
                        ShowCalendar ();
                        ShowNote (Note.Id);
                        lblDone.Visible = true;
                        lblSaveMe.Visible = false;
                        Grid6.Focus ();
                        break;
                        }
                case "SubProjectNoteSearch":
                        {
                        this.Text = Project.Name;
                        cboSubproject.DataSource = null;
                        txtNote.Text = "";
                        Grid6.DataSource = Db.DS.Tables ["tblSNotes"];//GetNotes (SubProject.Id);                   
                        ShowCalendar ();
                        ShowNote (Note.Id);
                        lblDone.Visible = true;
                        lblSaveMe.Visible = false;
                        Grid6.Focus ();
                        break;
                        }
                case "LinkNote":
                        {
                        cboSubproject.DataSource = Db.DS.Tables ["tblLinks"];
                        cboSubproject.DisplayMember = "PaperName";
                        cboSubproject.ValueMember = "LinkID"; //col7  {Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, SubProject_ID, Links.ID AS LinkID, Imp1, Imp2, Imp3, ImR}
                        cboSubproject.SelectedValue = Link.Id;
                        txtNote.Text = "";
                        Grid6.DataSource = Db.DS.Tables ["tblLNotes"]; //GetNotes (Link.Id);
                        ShowCalendar ();
                        ShowNote (Note.Id);
                        lblDone.Visible = false;
                        lblSaveMe.Visible = false;
                        Grid6.Focus ();
                        break;
                        }
                case "LinkNoteSearch":
                        {
                        cboSubproject.DataSource = null;
                        txtNote.Text = "";
                        Grid6.DataSource = Db.DS.Tables ["tblLNotes"]; //GetNotes (Link.Id);
                        ShowCalendar ();
                        ShowNote (Note.Id);
                        lblDone.Visible = false;
                        lblSaveMe.Visible = false;
                        Grid6.Focus ();
                        break;
                        }
                case "RefNote":
                        {
                        cboSubproject.DataSource = Db.DS.Tables ["tblRefs"];
                        cboSubproject.DisplayMember = "PaperName";
                        cboSubproject.ValueMember = "Papers.ID";
                        cboSubproject.SelectedValue = Ref.Id;
                        txtNote.Text = "";
                        Grid6.DataSource = Db.DS.Tables ["tblRNotes"]; //GetNotes (Ref.Id);
                        ShowCalendar ();
                        ShowNote (Note.Id);
                        lblDone.Visible = false;
                        lblSaveMe.Visible = false;
                        Grid6.Focus ();
                        break;
                        }
                case "RefNoteSearch":
                        {
                        cboSubproject.DataSource = null;
                        txtNote.Text = "";
                        Grid6.DataSource = Db.DS.Tables ["tblRNotes"]; //GetNotes (Ref.Id);
                        ShowCalendar ();
                        ShowNote (Note.Id);
                        lblDone.Visible = false;
                        lblSaveMe.Visible = false;
                        Grid6.Focus ();
                        break;
                        }
                }
            FormatGrid6Cols ();
            initialLoadingPhase = false;
            }
        private void FormatGrid6Cols ()
            {
            //grid columns
            Grid6.Columns [0].Visible = false; //ID
            Grid6.Columns [1].Width = 120;     //NoteDatum
            Grid6.Columns [2].Width = 230;     //Note
            Grid6.Columns [3].Visible = false; //parent-id
            Grid6.Columns [4].Visible = false; //parent-type
            Grid6.Columns [5].Visible = false; //Rtl
            Grid6.Columns [6].Visible = false; //Done(Accomplished)
            Grid6.Columns [7].Visible = false; //Note.UserID 
            Grid6.Columns [8].Visible = false; //shared 
            //focus on the selected note (ID = Note.Id)
            for (int r = 0; r < Grid6.Rows.Count; r++)
                {
                if ((int) Grid6 [0, r].Value == Note.Id)
                    {
                    Grid6.CurrentCell = Grid6.Rows [r].Cells [1];
                    }
                }
            }
        private void frmNotes_DoubleClick (object sender, EventArgs e)
            {
            //when txtnote is disbaled: frm-dblclaick is used for enebling the txtnote
            try
                {
                if ((Note.Id != 0) & (txtNote.Enabled == false) & (Grid6.SelectedRows [0].Index >= 0))
                    {
                    txtDatum.Enabled = true;
                    txtNote.Enabled = true;
                    txtNote.Focus ();
                    }
                }
            catch
                {
                }
            }
        //METHODS
        private void GetNotes (int parentid)
            {
            lblDone.Visible = false;
            try
                {
                switch (Note.Type)
                    {
                    case "SubProjectNote":
                    case "SubProjectNoteSearch":
                            {
                            Db.DS.Tables ["tblSNotes"].Clear ();
                            Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE Parent_ID = " + parentid.ToString () + " AND ParentType = 1 ORDER BY NoteDatum ASC;";
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                                Db.DASS.Fill (Db.DS, "tblSNotes");
                                CnnSS.Close ();
                                }
                            Grid6.DataSource = Db.DS.Tables ["tblSNotes"];
                            break;
                            }
                    case "LinkNote":
                    case "LinkNoteSearch":
                            {
                            Db.DS.Tables ["tblLNotes"].Clear ();
                            Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE Parent_ID = " + parentid.ToString () + " AND ParentType = 2 ORDER BY NoteDatum ASC;";
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                                Db.DASS.Fill (Db.DS, "tblLNotes");
                                CnnSS.Close ();
                                }
                            Grid6.DataSource = Db.DS.Tables ["tblLNotes"];
                            break;
                            }
                    case "RefNote":
                    case "RefNoteSearch":
                            {
                            Db.DS.Tables ["tblRNotes"].Clear ();
                            Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE Parent_ID = " + parentid.ToString () + " AND ParentType = 3 ORDER BY NoteDatum ASC;";
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                                Db.DASS.Fill (Db.DS, "tblRNotes");
                                CnnSS.Close ();
                                }
                            Grid6.DataSource = Db.DS.Tables ["tblRNotes"];
                            break;
                            }
                    }
                for (int i = 0, loopTo = Grid6.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                    {
                    Grid6.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                    }
                FormatGrid6Cols ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("line 221:\n" + ex.ToString ());
                }
            }
        private void ShowNote (int noteid)
            {
            txtDatum.Enabled = true; //txtDatum.Enabled = false;
            txtNote.Enabled = true; //txtNote.Enabled = false;
            try
                {
                //A: LOCATE
                for (int r = 0; r < Grid6.Rows.Count; r++)
                    {
                    if (Convert.ToInt32 (Grid6 [0, r].Value) == Note.Id)
                        {
                        Note.Index = r;
                        Grid6.CurrentCell = Grid6.Rows [Note.Index].Cells [1];
                        break;
                        }
                    }
                //B: GetRowData
                if (Grid6.Rows.Count == 0)
                    return;
                if (Grid6.SelectedRows [0].Index == -1)
                    return;
                Note.Id = Convert.ToInt32 (Grid6 [0, Grid6.SelectedRows [0].Index].Value);
                Note.DateTime = Convert.ToString (Grid6 [1, Grid6.SelectedRows [0].Index].Value);
                Note.NoteText = Convert.ToString (Grid6 [2, Grid6.SelectedRows [0].Index].Value);
                Note.Rtl = Convert.ToBoolean (Grid6 [5, Grid6.SelectedRows [0].Index].Value);
                //show frm lables
                if ((Note.Type == "SubProjectNote") || (Note.Type == "SubProjectNoteSearch"))
                    {
                    lblDone.Visible = true;
                    Note.Done = Convert.ToBoolean (Grid6 [6, Grid6.SelectedRows [0].Index].Value);
                    if (Note.Done == true)
                        {
                        lblDone.Text = "Done";
                        lblDone.BackColor = System.Drawing.Color.DarkSeaGreen;
                        }
                    else
                        {
                        lblDone.Text = "Pending";
                        lblDone.BackColor = System.Drawing.Color.Tan;
                        }
                    }
                else
                    {
                    Note.Done = false;
                    }
                if ((Note.Type == "RefNote") || (Note.Type == "RefNoteSearch"))
                    {
                    Note.UserID = Convert.ToInt32 (Grid6 [7, Grid6.SelectedRows [0].Index].Value);
                    if (User.Id == Note.UserID)
                        {
                        lblMine.Visible = true;
                        }
                    else
                        {
                        lblMine.Visible = false;
                        }
                    }
                else
                    {
                    Note.UserID = User.Id;
                    }
                Note.Index = Grid6.CurrentRow.Index;
                //C: SHOW
                txtDatum.Text = Note.DateTime;
                txtNote.Text = Note.NoteText;
                if (Note.Rtl == true)
                    {
                    txtNote.RightToLeft = RightToLeft.Yes;
                    Menu4_RTL.Checked = true;
                    txtNote.Font = new Font ("Tahoma", 12);
                    }
                else
                    {
                    txtNote.RightToLeft = RightToLeft.No;
                    Menu4_RTL.Checked = false;
                    txtNote.Font = new Font ("Consolas", 12);
                    }
                txtNote.SelectionStart = 0;
                txtNote.SelectionLength = 0;
                try
                    {
                    MC1.SetDate (Conversions.ToDate (Strings.Mid (Note.DateTime, 1, 4) + "/" + Strings.Mid (Note.DateTime, 6, 2) + "/" + Strings.Mid (Note.DateTime, 9, 2)));
                    }
                catch (Exception ex)
                    {
                    MC1.SetDate (Conversions.ToDate (Strings.Mid (Note.DateTime, 1, 4) + "/" + Strings.Mid (Note.DateTime, 6, 2) + "/01"));
                    }
                //Note is not changed, SaveMe:OFF
                Note.Saved = true;
                lblSaveMe.Visible = false;
                }
            catch (Exception ex)
                {
                //MessageBox.Show ("line 346: \n"+ ex.ToString ());
                return;
                }
            }
        private void ShowCalendar ()
            {
            //bold dates on calendar
            string tmpDate;
            MC1.RemoveAllBoldedDates ();
            MC1.UpdateBoldedDates ();
            try
                {
                switch (Note.Type)
                    {
                    case "SubProjectNote":
                            {
                            for (int i = 0, loopTo = Db.DS.Tables ["tblSNotes"].Rows.Count - 1; i <= loopTo; i++)
                                {
                                tmpDate = Strings.Mid (Db.DS.Tables ["tblSNotes"].Rows [i] [1].ToString (), 1, 10);
                                if (Conversion.Val (tmpDate) > 0d)
                                    {
                                    MC1.AddBoldedDate (Conversions.ToDate (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                                    }
                                }
                            break;
                            }
                    case "RefNote":
                            {
                            for (int i = 0, loopTo = Db.DS.Tables ["tblRNotes"].Rows.Count - 1; i <= loopTo; i++)
                                {
                                tmpDate = Strings.Mid (Db.DS.Tables ["tblRNotes"].Rows [i] [1].ToString (), 1, 10);
                                if (Conversion.Val (tmpDate) > 0d)
                                    {
                                    MC1.AddBoldedDate (Conversions.ToDate (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                                    }
                                }
                            break;
                            }
                    case "LinkNote":
                            {
                            for (int i = 0, loopTo = Db.DS.Tables ["tblLNotes"].Rows.Count - 1; i <= loopTo; i++)
                                {
                                tmpDate = Strings.Mid (Db.DS.Tables ["tblLNotes"].Rows [i] [1].ToString (), 1, 10);
                                if (Conversion.Val (tmpDate) > 0d)
                                    {
                                    MC1.AddBoldedDate (Conversions.ToDate (Strings.Mid (tmpDate, 1, 4) + "/" + Strings.Mid (tmpDate, 6, 2) + "/" + Strings.Mid (tmpDate, 9, 2)));
                                    }
                                }
                            break;
                            }
                    }
                MC1.UpdateBoldedDates ();
                }
            catch
                {
                //do nothing!
                }
            }
        private void GetSubprojects (int projectid)
            {
            Db.DS.Tables ["tblSubProject"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID, SubProjectName, Notes, Project_ID FROM SubProjects Where Project_ID = " + projectid.ToString () + " Order by SubProjectName", CnnSS);
                Db.DASS.Fill (Db.DS, "tblSubProject");
                CnnSS.Close ();
                }
            }
        private static int CheckReadOnlyAccess ()
            {
            foreach (DataRow R in Db.DS.Tables ["tblUserProject"].Rows)
                {
                if (((int) R [0] == User.Id) && ((int) R [3] == Project.Id) && ((bool) R [4] == true))
                    {
                    MessageBox.Show ("Notice: \n\n\nYou have ReadOnly access to this SubProject!", "eLib", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 1;
                    }
                }
            return 0;
            }
        //Combo-SubProject
        private void cboSubproject_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 39:
                case 13:
                        {
                        cboSubproject_SelectedIndexChanged (null, null);
                        if (Grid6.Rows.Count > 0)
                            Grid6.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 27:
                        {
                        Menu_Cancel_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void cboSubproject_SelectedIndexChanged (object sender, EventArgs e)
            {
            if ((cboSubproject.Items.Count == 0) || initialLoadingPhase == true)
                {
                return;
                }
            txtDatum.Enabled = false;
            txtNote.Enabled = false;
            lblMine.Visible = false;
            if (cboSubproject.SelectedIndex == -1)
                return;
            try
                {
                switch (Note.Type)
                    {
                    case "SubProjectNote":
                        //case "SubProjectNoteSearch":
                            {
                            SubProject.Id = (int) cboSubproject.SelectedValue;
                            GetNotes (SubProject.Id);
                            break;
                            }
                    case "RefNote":
                        //case "RefNoteSearch":
                            {
                            Ref.Id = Conversions.ToInteger (cboSubproject.SelectedValue);
                            GetNotes (Ref.Id);
                            break;
                            }
                    case "LinkNote":
                        //case "LinkNoteSearch":
                            {
                            Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [cboSubproject.SelectedIndex] [7]); //7:Link.ID
                            GetNotes (Link.Id);
                            break;
                            }
                    }
                //ShowNote ();
                ShowCalendar ();
                txtNote.Text = "";
                txtDatum.Text = "";
                Note.Id = 0;
                Note.Saved = true;
                lblSaveMe.Visible = false;
                }
            catch (Exception ex)
                {
                //MessageBox.Show ("line 492:\n" + ex.ToString ());
                }
            }
        private void Menu_SelectProject_Click (object sender, EventArgs e)
            {
            btnSelectProject_Click (null, null);
            }
        private void btnSelectProject_Click (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 1; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            if (Client.DialogRequestParams == 64) //1: A Projects is selected from dialog
                {
                this.Text = Project.Name;
                GetSubprojects (Project.Id);
                cboSubproject.DataSource = Db.DS.Tables ["tblSubProject"];
                cboSubproject.DisplayMember = "SubProjectName";
                cboSubproject.ValueMember = "ID";
                cboSubproject.SelectedValue = SubProject.Id;
                txtNote.Text = "";
                if (cboSubproject.Items.Count > 0)
                    {
                    cboSubproject.SelectedIndex = 0;
                    }
                else
                    {
                    cboSubproject.SelectedIndex = -1;
                    }
                Note.Type = "SubProjectNote";
                GetNotes (SubProject.Id);
                lblDone.Visible = true;
                ShowCalendar ();
                //ShowNote ();
                lblSaveMe.Visible = false;
                Grid6.Focus ();
                }
            }
        //GRID
        private void Grid6_KeyDown (object sender, KeyEventArgs e)
            {
            try
                {
                switch ((int) e.KeyCode)
                    {
                    case 37: //left
                            {
                            cboSubproject.Focus ();
                            Grid6.DataSource = null; //new
                            Note.Id = 0;
                            txtNote.Text = ""; //new
                            txtDatum.Text = ""; //new
                            lblSaveMe.Visible = false; //new
                            break;
                            }
                    case 39: //right
                            {
                            if (Grid6.CurrentRow.Index == -1) //if (Grid6.SelectedRows [0].Index == -1)
                                return;
                            Note.Id = Convert.ToInt32 (Grid6 [0, Grid6.SelectedRows [0].Index].Value);
                            ShowNote (Note.Id);
                            e.SuppressKeyPress = true;
                            break;
                            }
                    case 13:
                            {
                            Grid6_CellDoubleClick (null, null);
                            e.SuppressKeyPress = true;
                            break;
                            }
                    case 27: //escape
                            {
                            Menu_Cancel_Click (null, null);
                            e.SuppressKeyPress = true;
                            break;
                            }
                    }
                }
            catch
                {
                }
            }
        private void Grid6_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            try
                {
                if (Grid6.CurrentRow.Index == -1) //if (Grid6.SelectedRows [0].Index == -1)
                    return;
                Note.Id = Convert.ToInt32 (Grid6 [0, Grid6.SelectedRows [0].Index].Value);
                ShowNote (Note.Id);
                }
            catch
                {
                Note.Id = 0;
                }
            }
        private void Grid6_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if (Grid6.CurrentRow.Index == -1) //if (Grid6.SelectedRows [0].Index == -1)
                return;
            Note.Id = Convert.ToInt32 (Grid6 [0, Grid6.SelectedRows [0].Index].Value);
            ShowNote (Note.Id);
            txtDatum.Enabled = true;
            txtNote.Enabled = true;
            txtNote.Focus ();
            }
        //TXT
        private void txtNote_KeyDown (object sender, KeyEventArgs e)
            {
            if ((int) e.KeyCode == 27)
                {
                if ((lblSaveMe.Visible == true) & (Note.UserID == User.Id))
                    {
                    DialogResult myansw = MessageBox.Show ("Save?", "eLib", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    switch (myansw)
                        {
                        case DialogResult.Yes:
                                {
                                Menu4_Save_Click (null, null);
                                Grid6.Focus ();
                                txtDatum.Enabled = false;
                                txtNote.Enabled = false;
                                ShowNote (Note.Id);
                                e.SuppressKeyPress = true;
                                break;
                                }
                        case DialogResult.No:
                                {
                                Grid6.Focus ();
                                txtDatum.Enabled = false;
                                txtNote.Enabled = false;
                                ShowNote (Note.Id);
                                e.SuppressKeyPress = true;
                                break;
                                }
                        case DialogResult.Cancel:
                                {
                                //do nothing
                                break;
                                }
                        }
                    }
                else
                    {
                    Grid6.Focus ();
                    txtDatum.Enabled = false;
                    txtNote.Enabled = false;
                    ShowNote (Note.Id);
                    e.SuppressKeyPress = true;
                    }
                }
            }
        private void txtNote_TextChanged (object sender, EventArgs e)
            {
            //Note is changed, SaveMe:ON
            if (txtNote.Text != Note.NoteText)
                {
                Note.Saved = false;
                lblSaveMe.Visible = true;
                }
            else
                {
                Note.Saved = true;
                lblSaveMe.Visible = false;
                }
            txtNote.ForeColor = System.Drawing.Color.Black;
            lblCounter.Text = txtNote.TextLength.ToString () + " / 4000";
            if (txtNote.TextLength > 3900)
                {
                lblCounter.ForeColor = System.Drawing.Color.IndianRed;
                }
            else
                {
                lblCounter.ForeColor = System.Drawing.Color.SteelBlue;
                }
            }
        private void txtNote_DragEnter (object sender, DragEventArgs e)
            {
            //display behavior of the mouse icon
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void txtNote_DragDrop (object sender, DragEventArgs e)
            {
            //get a single file path from dropped object
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            string strFilex = strFiles [0];
            var MyFile = new FileInfo (strFilex);
            if (MyFile.Extension == ".txt")
                {
                string Filename = MyFile.FullName;
                string Linex = "";
                string NoteTexts = "";
                try
                    {
                    FileSystem.FileOpen (1, Filename, OpenMode.Input);
                    while (string.IsNullOrEmpty (Strings.Trim (Linex)))
                        {
                        Linex = FileSystem.LineInput (1);
                        }
                    NoteTexts = NoteTexts + Linex + "\r\n";
                    while (!FileSystem.EOF (1))
                        {
                        Linex = FileSystem.LineInput (1);
                        NoteTexts = NoteTexts + Linex + "\r\n";
                        }
                    FileSystem.FileClose (1);
                    txtNote.Text = txtNote.Text + NoteTexts;
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            }
        private void txtDatum_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13:
                case 27:
                        {
                        txtNote.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void txtDatum_Click (object sender, EventArgs e)
            {
            if (Grid6.SelectedRows [0].Index == -1)
                {
                Grid6.Focus ();
                return;
                }
            //Note.DateTime = Grid6 [1, Grid6.SelectedRows [0].Index].Value.ToString ();
            Note.DateTime = txtDatum.Text;
            var frmTMDT = new frmTimeAndDate ();
            frmTMDT.ShowDialog ();
            if (Client.DialogRequestParams == 16)
                {
                txtDatum.Text = Note.DateTime;
                lblSaveMe.Visible = true;
                txtNote.Focus ();
                }
            }
        private void txtDatum_TextChanged (object sender, EventArgs e)
            {
            //Note Date/Time is changed, SaveMe:ON

            if (txtDatum.Text != Note.DateTime)
                {
                Note.Saved = false;
                lblSaveMe.Visible = true;
                }
            else
                {
                Note.Saved = true;
                lblSaveMe.Visible = false;
                }
            }
        private void lblDone_Click (object sender, EventArgs e)
            {
            if (lblDone.BackColor == System.Drawing.Color.DarkSeaGreen)
                {
                Note.Done = false;
                lblDone.Text = "Pending";
                lblDone.BackColor = System.Drawing.Color.Tan;
                }
            else
                {
                Note.Done = true;
                lblDone.Text = "Done";
                lblDone.BackColor = System.Drawing.Color.DarkSeaGreen;
                }
            if (CheckReadOnlyAccess () == 1)
                return;
            try
                {
                int r = Grid6.CurrentRow.Index;
                if (r == -1)
                    {
                    MessageBox.Show (Grid6.CurrentRow.Index.ToString () + "\n\nSelect a note!");
                    return;
                    }
                }
            catch
                {
                return;
                }
            if (Grid6.SelectedRows.Count == 0)
                return;
            if (txtDatum.MaskCompleted == false)
                return;
            if (txtNote.TextLength > 2047)
                {
                txtNote.ForeColor = System.Drawing.Color.IndianRed;
                return;
                }
            Note.NoteText = txtNote.Text;
            if (string.IsNullOrEmpty (Strings.Trim (Note.NoteText)))
                {
                txtNote.Focus ();
                return;
                }
            else
                {
                Note.Id = Convert.ToInt32 (Grid6 [0, Grid6.SelectedRows [0].Index].Value);
                Note.DateTime = Strings.Trim (txtDatum.Text);
                if (Note.Type == "RefNote")
                    {
                    Note.UserID = Convert.ToInt32 (Grid6 [7, Grid6.SelectedRows [0].Index].Value);
                    }
                else
                    {
                    Note.UserID = User.Id;
                    }
                if (Menu4_RTL.Checked == true)
                    Note.Rtl = true;
                else
                    Note.Rtl = false;
                if (string.IsNullOrEmpty (Note.DateTime))
                    Note.DateTime = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "UPDATE Notes SET Done=@done WHERE ID=@noteid";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@done", Note.Done.ToString ());
                    cmdx.Parameters.AddWithValue ("@noteid", Note.Id.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                //sGetNotes (SubProject.Id);
                }
            //ShowNote ();
            //ShowCalendar ();
            }
        //MENU-SubProjects
        private void Menu_Add_Click (object sender, EventArgs e)
            {
            if (CheckReadOnlyAccess () == 1)
                return;
            //SubProjects.ID is known
            //SubProject.Name
            Note.DateTime = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
            try
                {
                string newNote = User.Name + " @ " + DateTime.Now.ToString ("yyyy-MM-dd . HH-mm-ss") + "  \r\n{\r\n \r\n}";
                switch (Note.Type)
                    {
                    case "SubProjectNote":
                            {
                            SubProject.Id = (int) cboSubproject.SelectedValue;
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType) VALUES (@notedatum, @note, @parentid, 1)";
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                                cmdx.Parameters.AddWithValue ("@note", newNote);
                                cmdx.Parameters.AddWithValue ("@parentid", SubProject.Id.ToString ());
                                int ix = cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            GetNotes (SubProject.Id);
                            break;
                            }
                    case "LinkNote":
                            {
                            Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [cboSubproject.SelectedIndex] [7]); // 7:Link.ID
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType) VALUES (@notedatum, @note, @parentid, 2)";
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                                cmdx.Parameters.AddWithValue ("@note", newNote);
                                cmdx.Parameters.AddWithValue ("@parentid", Link.Id.ToString ());
                                int ix = cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            GetNotes (Link.Id);
                            break;
                            }
                    case "RefNote":
                            {
                            Ref.Id = Conversions.ToInteger (cboSubproject.SelectedValue);
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType) VALUES (@notedatum, @note, @parentid, 3)";
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                                cmdx.Parameters.AddWithValue ("@note", newNote);
                                cmdx.Parameters.AddWithValue ("@parentid", Ref.Id.ToString ());
                                int ix = cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            GetNotes (Ref.Id);
                            break;
                            }
                    }
                txtNote.Text = "";
                Grid6.Rows [0].Selected = false;
                ShowCalendar ();
                Grid6.Focus ();
                //
                txtDatum.Text = ""; //prevent saving new text in blank new page of textbox in the selected listbox item?! 
                Note.Saved = true;
                lblSaveMe.Visible = false;
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ()); // Do Nothing!
                }
            }
        private void Menu_Replace_Click (object sender, EventArgs e)
            {
            if (Note.Type != "SubProjectNote")
                return;
            if (CheckReadOnlyAccess () == 1)
                return;
            //Replace a Note
            if (Grid6.SelectedRows [0].Index == -1)
                return;
            Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            //replace current SubProjectNote to the selected SubProject
            if (Client.DialogRequestParams == 32) // 2: A SubProjects is selected from dialog
                {
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
                Note.Id = 0; //because Note is replaced: the Note is not here now. 
                cboSubproject_SelectedIndexChanged (sender, e); // to refresh list6
                }
            }
        private void Menu_Del_Click (object sender, EventArgs e)
            {
            if (CheckReadOnlyAccess () == 1)
                return;
            if (Grid6.SelectedRows [0].Index == -1)
                return;
            DialogResult myansw = MessageBox.Show ("Delete ?", "eLib", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (myansw != DialogResult.OK)
                return;
            try
                {
                Note.Id = Convert.ToInt32 (Grid6 [0, Grid6.SelectedRows [0].Index].Value);
                switch (Note.Type)
                    {
                    case "SubProjectNote":
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.strSQL = "DELETE FROM Notes WHERE ID = @id";
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@id", Note.Id.ToString ());
                                var i = cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                SubProject.Id = (int) cboSubproject.SelectedValue;
                                GetNotes (SubProject.Id);
                                txtNote.Text = "";
                                Grid6.Focus ();
                                }
                            break;
                            }
                    case "RefNote":
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.strSQL = "DELETE FROM Notes WHERE ID = @id";
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@id", Note.Id.ToString ());
                                var i = cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                Ref.Id = Conversions.ToInteger (cboSubproject.SelectedValue);
                                GetNotes (Ref.Id);
                                txtNote.Text = "";
                                Grid6.Focus ();
                                }
                            break;
                            }
                    case "LinkNote":
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.strSQL = "DELETE FROM Notes WHERE ID = @id";
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@id", Note.Id.ToString ());
                                var i = cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                Link.Id = Conversions.ToInteger (Db.DS.Tables ["tblLinks"].Rows [cboSubproject.SelectedIndex] [7]); // 7:Link.ID
                                GetNotes (Link.Id);
                                txtNote.Text = "";
                                Grid6.Focus ();
                                }
                            break;
                            }
                    }
                Note.Saved = true;
                lblSaveMe.Visible = false;
                }
            catch
                {
                }
            }
        private void Menu_Mindmap_Click (object sender, EventArgs e)
            {
            Note.Type = "SubProjectNote";
            if (Grid6.SelectedRows [0].Index != -1)
                {
                Note.ParentID = SubProject.Id = (int) cboSubproject.SelectedValue;
                Note.Id = Convert.ToInt32 (Grid6 [0, Grid6.SelectedRows [0].Index].Value);
                }
            Dispose ();
            var frmMindmap = new frmNoteNetEditor ();
            frmMindmap.ShowDialog ();
            }
        private void lblMindmap_Click (object sender, EventArgs e)
            {
            Menu_Mindmap_Click (null, null);
            }
        //MENU-Calendar
        private void Menu_CalendarAddNewNote_Click (object sender, EventArgs e)
            {
            DateTime dt = MC1.SelectionStart;
            Note.DateTime = dt.ToString ("yyyy-MM-dd . 08-30");
            try
                {
                switch (Note.Type)
                    {
                    case "SubProjectNote":
                            {
                            SubProject.Id = Convert.ToInt32 (cboSubproject.SelectedValue);
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType) VALUES (@notedatum, @note, @parentid, 1)";
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                                cmdx.Parameters.AddWithValue ("@note", "-");
                                cmdx.Parameters.AddWithValue ("@parentid", SubProject.Id.ToString ());
                                int i = (int) cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            GetNotes (SubProject.Id);
                            break;
                            }
                    case "LinkNote":
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType) VALUES (@notedatum, @note, @parentid, 2)";
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                                cmdx.Parameters.AddWithValue ("@note", "-");
                                cmdx.Parameters.AddWithValue ("@parentid", Link.Id.ToString ());
                                int i = (int) cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            GetNotes (Link.Id);
                            break;
                            }
                    case "RefNote":
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType) VALUES (@notedatum, @note, @parentid, 3)";
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                                cmdx.Parameters.AddWithValue ("@note", "-");
                                cmdx.Parameters.AddWithValue ("@paperid", Ref.Id.ToString ());
                                int i = (int) cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            GetNotes (Ref.Id);
                            break;
                            }
                    }
                txtNote.Text = "";
                ShowCalendar ();
                Grid6.Focus ();
                Note.Saved = true;
                lblSaveMe.Visible = false;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                }
            }
        //MENU-TextNote
        private void lblSaveMe_Click (object sender, EventArgs e)
            {
            Menu4_Save_Click (null, null);
            }
        private void Menu4_Save_Click (object sender, EventArgs e)
            {
            if (CheckReadOnlyAccess () == 1)
                return;
            try
                {
                int r = Grid6.CurrentRow.Index;
                if (r == -1)
                    {
                    MessageBox.Show (Grid6.CurrentRow.Index.ToString () + "\n\nSelect a note!");
                    return;
                    }
                }
            catch
                {
                return;
                }
            if (Grid6.SelectedRows.Count == 0)
                return;
            if (txtDatum.MaskCompleted == false)
                return;
            if (txtNote.TextLength > 3999)
                {
                txtNote.ForeColor = System.Drawing.Color.IndianRed;
                return;
                }
            Note.NoteText = txtNote.Text;
            if (string.IsNullOrEmpty (Strings.Trim (Note.NoteText)))
                {
                txtNote.Focus ();
                return;
                }
            else
                {
                Note.Id = Convert.ToInt32 (Grid6 [0, Grid6.SelectedRows [0].Index].Value);
                Note.DateTime = Strings.Trim (txtDatum.Text);
                if (Note.Type == "RefNote")
                    {
                    Note.UserID = Convert.ToInt32 (Grid6 [7, Grid6.SelectedRows [0].Index].Value);
                    }
                else
                    {
                    Note.UserID = User.Id;
                    }
                if (Menu4_RTL.Checked == true)
                    Note.Rtl = true;
                else
                    Note.Rtl = false;
                if (string.IsNullOrEmpty (Note.DateTime))
                    Note.DateTime = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
                switch (Note.Type)
                    {
                    case "SubProjectNote":
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "UPDATE Notes SET NoteDatum=@notedatum, Note=@note, Rtl=@rtl, Done=@done WHERE ID=@noteid";
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                                cmdx.Parameters.AddWithValue ("@note", Note.NoteText);
                                cmdx.Parameters.AddWithValue ("@rtl", Note.Rtl);
                                cmdx.Parameters.AddWithValue ("@done", Note.Done.ToString ());
                                cmdx.Parameters.AddWithValue ("@noteid", Note.Id.ToString ());
                                int ix = cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            GetNotes (SubProject.Id);
                            break;
                            }
                    case "LinkNote":
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "UPDATE Notes SET NoteDatum=@notedatum, Note=@note, Rtl=@rtl WHERE ID=@noteid";
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                                cmdx.Parameters.AddWithValue ("@note", Note.NoteText);
                                cmdx.Parameters.AddWithValue ("@rtl", Note.Rtl);
                                cmdx.Parameters.AddWithValue ("@noteid", Note.Id.ToString ());
                                int ix = cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            GetNotes (Link.Id);
                            break;
                            }
                    case "RefNote":
                            {
                            if (User.Id != Note.UserID)
                                return;
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "UPDATE Notes SET NoteDatum=@notedatum, Note=@note, Rtl=@rtl WHERE ID=@noteid";
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                                cmdx.Parameters.AddWithValue ("@note", Note.NoteText);
                                cmdx.Parameters.AddWithValue ("@rtl", Note.Rtl);
                                cmdx.Parameters.AddWithValue ("@noteid", Note.Id.ToString ());
                                int ix = cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            GetNotes (Ref.Id);
                            break;
                            }
                    }
                ShowNote (Note.Id);
                ShowCalendar ();
                }
            }
        private void Menu4_RTL_Click (object sender, EventArgs e)
            {
            if (Menu4_RTL.Checked == true)
                {
                Note.Rtl = false;
                Menu4_RTL.Checked = false;
                txtNote.RightToLeft = RightToLeft.No;
                txtNote.Font = new Font ("Consolas", 12);
                }
            else
                {
                Note.Rtl = true;
                Menu4_RTL.Checked = true;
                txtNote.RightToLeft = RightToLeft.Yes;
                txtNote.Font = new Font ("Tahoma", 12);
                }
            if (txtNote.Enabled == true)
                {
                txtNote.Focus ();
                }
            }
        private void Menu4_UpdateDateTime_Click (object sender, EventArgs e)
            {
            txtDatum.Text = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
            }
        //TEMPLATES
        private void Menu4_Template_LectureNote_Click (object sender, EventArgs e)
            {
            //Template for LectureNote 
            string gel_template = @"
Class Note /  

This Class
{
 PresenceAbsence: Y/N

 From

 To

 Activity { }

}

--

Remember 4 next week
{ }

";
            txtNote.Text = txtNote.Text + gel_template;
            txtNote.SelectionStart = txtNote.Text.Length;
            }
        private void Menu4_Template_Instruction_Click (object sender, EventArgs e)
            {
            //Template for EmailAddress
            string gel_template = @"
Instruction for: ---
{

(A)

 a1-
 a2-



(B)

 b1-
 b2-



(C)

 c1-
 c2-



(D)

 d1-
 d2-


}

";
            txtNote.Text = txtNote.Text + gel_template;
            txtNote.SelectionStart = txtNote.Text.Length;
            }
        private void Menu4_Template_Primer_Click (object sender, EventArgs e)
            {
            //Primer
            string gel_template = @"
PRIMERs

No   Tm(c)    Ta(c)    F/R    sequence                Primer Name

01   .        .        .      5'-ATCG...
02   .
03   .
04   .
05   .
06   .
07   .
08   .
09   .
10   .
";
            txtNote.Text = txtNote.Text + gel_template;
            txtNote.SelectionStart = txtNote.Text.Length;
            }
        private void Menu4_Template_PCR_Click (object sender, EventArgs e)
            {
            //PCR                      
            string pcr_template = @"
PCR id

rxns: xx  vol : xx uL


item    cons       1 rxn    n rxns
gDNA    20 ngr/uL  .
H2O     -          .
dNTPs   10 mM      .
F       10 uM      .
R       10 uM      .
Buffer  10 x       .
MgCl2   25 mM      .
Taq     5 u/uL     .


[T/sec]+ N{[T/sec]+[(T0-T1)/sec]+[T/sec]}+[T/sec]


     01  02  03  04  05  06  07  08  09  10  11  12
R1   .   .   .   .   .   .   .   .   .   .   .   .
R2   .   .   .   .   .   .   .   .   .   .   .   .
R3   .   .   .   .   .   .   .   .   .   .   .   .
R4   .   .   .   .   .   .   .   .   .   .   .   .
R5   .   .   .   .   .   .   .   .   .   .   .   .
R6   .   .   .   .   .   .   .   .   .   .   .   .
R7   .   .   .   .   .   .   .   .   .   .   .   .
R8   .   .   .   .   .   .   .   .   .   .   .   .

";
            txtNote.Text = txtNote.Text + pcr_template;
            txtNote.SelectionStart = txtNote.Text.Length;
            }
        private void Menu4_Template_Gel_Click (object sender, EventArgs e)
            {
            //Gel
            string gel_template = @"
GEL id

dye : xx uL
load: xx uL/well
ladd: xx bp (xx uL, in well: xx)

-
01:
02:
03:
04:
05:
06:
07:
08:
09:
10:
-
11:
12:
13:
14:
15:
16:
17:
18:
19:
20:
";
            txtNote.Text = txtNote.Text + gel_template;
            txtNote.SelectionStart = txtNote.Text.Length;
            }
        //MENU-Exit
        private void Menu3_Exit_Click (object sender, EventArgs e)
            {
            Exit ();
            }
        private void Menu4_Exit_Click (object sender, EventArgs e)
            {
            Exit ();
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            Exit ();
            }
        private void Exit ()
            {
            try
                {
                if (Note.Type == "SubProjectNote" && cboSubproject.SelectedIndex != -1)
                    {
                    Note.ParentID = (int) cboSubproject.SelectedValue;
                    }
                if (Grid6.CurrentRow.Index != -1)
                    {
                    Note.Id = Convert.ToInt32 (Grid6 [0, Grid6.SelectedRows [0].Index].Value);
                    }
                Dispose ();
                }
            catch
                {
                }
            }

        private void label1_Click (object sender, EventArgs e)
            {
            Exit ();
            }

        }
    }