using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace eLib.Forms
    {
    public partial class frmNoteNetEditor : Form
        {
        public frmNoteNetEditor ()
            {
            InitializeComponent ();
            }
        private void frmNoteNetEditor_Load (object sender, EventArgs e)
            {
            Width = 1300;
            Height = 690;
            this.Text = "Mindmap";
            btn_Save.Visible = false;
            switch (Note.Type) //FocusNote SubProjectNote SubProjectNoteSearch LinkNote LinkNoteSearch RefNote RefNoteSearch
                {
                case "FocusNote":
                        {
                        txtNote.Text = "";
                        txtDatum.Text = "";
                        Note.Type = "SubProjectNote"; //change type for method to work properly
                        GetNotes (SubProject.Id); //get family of selected note in focus 
                        GridNoteFamily.Focus ();
                        break;
                        }
                case "SubProjectNote":
                        {
                        txtNote.Text = "";
                        txtDatum.Text = "";
                        GridNoteFamily.DataSource = Db.DS.Tables["tblSNotes"];//GetNotes (SubProject.Id);                   
                        ShowFNote (Note.Id);
                        lblDone.Visible = true;
                        FormatGridCols ("gridfamily");
                        GridNoteFamily.Focus ();
                        break;
                        }
                case "SubProjectNoteSearch":
                        {
                        txtNote.Text = "";
                        txtDatum.Text = "";
                        GridNoteFamily.DataSource = Db.DS.Tables["tblSNotes"];//GetNotes (SubProject.Id);                   
                        ShowFNote (Note.Id);
                        lblDone.Visible = true;
                        FormatGridCols ("gridfamily");
                        GridNoteFamily.Focus ();
                        break;
                        }
                case "LinkNote":
                        {
                        txtNote.Text = "";
                        txtDatum.Text = "";
                        GridNoteFamily.DataSource = Db.DS.Tables["tblLNotes"]; //GetNotes (Link.Id);
                        ShowFNote (Note.Id);
                        lblDone.Visible = false;
                        FormatGridCols ("gridfamily");
                        GridNoteFamily.Focus ();
                        break;
                        }
                case "LinkNoteSearch":
                        {
                        txtNote.Text = "";
                        txtDatum.Text = "";
                        GridNoteFamily.DataSource = Db.DS.Tables["tblLNotes"]; //GetNotes (Link.Id);
                        ShowFNote (Note.Id);
                        lblDone.Visible = false;
                        FormatGridCols ("gridfamily");
                        GridNoteFamily.Focus ();
                        break;
                        }
                case "RefNote":
                        {
                        txtNote.Text = "";
                        txtDatum.Text = "";
                        GridNoteFamily.DataSource = Db.DS.Tables["tblRNotes"]; //GetNotes (Ref.Id);
                        ShowFNote (Note.Id);
                        lblDone.Visible = false;
                        FormatGridCols ("gridfamily");
                        GridNoteFamily.Focus ();
                        break;
                        }
                case "RefNoteSearch":
                        {
                        txtNote.Text = "";
                        txtDatum.Text = "";
                        GridNoteFamily.DataSource = Db.DS.Tables["tblRNotes"]; //GetNotes (Ref.Id);
                        ShowFNote (Note.Id);
                        lblDone.Visible = false;
                        FormatGridCols ("gridfamily");
                        GridNoteFamily.Focus ();
                        break;
                        }
                }
            GridNoteFamily_CellClick (null, null);
            }
        //get notes
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
                            Db.DS.Tables["tblSNotes"].Clear ();
                            Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE Parent_ID = " + parentid.ToString () + " AND ParentType = 1 ORDER BY NoteDatum ASC;";
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                                Db.DASS.Fill (Db.DS, "tblSNotes");
                                CnnSS.Close ();
                                }
                            GridNoteFamily.DataSource = Db.DS.Tables["tblSNotes"];
                            break;
                            }
                    case "LinkNote":
                    case "LinkNoteSearch":
                            {
                            Db.DS.Tables["tblLNotes"].Clear ();
                            Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE Parent_ID = " + parentid.ToString () + " AND ParentType = 2 ORDER BY NoteDatum ASC;";
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                                Db.DASS.Fill (Db.DS, "tblLNotes");
                                CnnSS.Close ();
                                }
                            GridNoteFamily.DataSource = Db.DS.Tables["tblLNotes"];
                            lblCaptionNotes.Text = "Link Notes";
                            break;
                            }
                    case "RefNote":
                    case "RefNoteSearch":
                            {
                            Db.DS.Tables["tblRNotes"].Clear ();
                            Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE Parent_ID = " + parentid.ToString () + " AND ParentType = 3 ORDER BY NoteDatum ASC;";
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                                Db.DASS.Fill (Db.DS, "tblRNotes");
                                CnnSS.Close ();
                                }
                            GridNoteFamily.DataSource = Db.DS.Tables["tblRNotes"];
                            lblCaptionNotes.Text = "Ref Notes";
                            break;
                            }
                    }
                FormatGridCols ("gridfamily");
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void GetUpstreamNotes (int noteid)
            {
            Db.DS.Tables["tblUNotes"].Clear ();
            Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE ID IN (SELECT NoteA_ID FROM NoteNet WHERE NoteB_ID = " + noteid.ToString () + ");";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblUNotes");
                CnnSS.Close ();
                }
            GridUpstream.DataSource = Db.DS.Tables["tblUNotes"];
            FormatGridCols ("gridupstream");
            }
        private void GetDownstreamNotes (int noteid)
            {
            Db.DS.Tables["tblDNotes"].Clear ();
            Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE ID IN (SELECT NoteB_ID FROM NoteNet WHERE NoteA_ID = " + noteid.ToString () + ");";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblDNotes");
                CnnSS.Close ();
                }
            GridDownstream.DataSource = Db.DS.Tables["tblDNotes"];
            FormatGridCols ("griddownstream");
            }
        //show notes
        private void ShowFNote (int noteid)
            {
            //Show a note using Information in gridnotefamily
            txtDatum.Enabled = false;
            txtNote.Enabled = false;
            txtNote.ScrollBars = ScrollBars.None;
            try
                {
                //A: LOCATE
                for (int r = 0; r < GridNoteFamily.Rows.Count; r++)
                    {
                    if (Convert.ToInt32 (GridNoteFamily[0, r].Value) == Note.Id)
                        {
                        Note.Index = r;
                        GridNoteFamily.CurrentCell = GridNoteFamily.Rows[Note.Index].Cells[1];
                        break;
                        }
                    }
                //B: GetRowData
                if (GridNoteFamily.Rows.Count == 0)
                    return;
                if (GridNoteFamily.SelectedRows[0].Index == -1)
                    return;
                Note.Id = Convert.ToInt32 (GridNoteFamily[0, GridNoteFamily.SelectedRows[0].Index].Value);
                Note.DateTime = Convert.ToString (GridNoteFamily[1, GridNoteFamily.SelectedRows[0].Index].Value);
                Note.NoteText = Convert.ToString (GridNoteFamily[2, GridNoteFamily.SelectedRows[0].Index].Value);
                Note.Rtl = Convert.ToBoolean (GridNoteFamily[5, GridNoteFamily.SelectedRows[0].Index].Value);
                //show frm lables
                Note.Done = Convert.ToBoolean (GridNoteFamily[6, GridNoteFamily.SelectedRows[0].Index].Value);
                if (Note.Done == true)
                    {
                    lblDone.Text = "";
                    }
                else
                    {
                    lblDone.Text = "Pending !";
                    }
                if ((Note.Type == "RefNote") || (Note.Type == "RefNoteSearch"))
                    {
                    Note.UserID = Convert.ToInt32 (GridNoteFamily[7, GridNoteFamily.SelectedRows[0].Index].Value);
                    }
                else
                    {
                    Note.UserID = User.Id;
                    }
                Note.Index = GridNoteFamily.CurrentRow.Index;
                //C: SHOW
                txtNote.Text = Note.NoteText;
                txtDatum.Text = Note.DateTime;
                btn_Save.Visible = false;
                if (Note.Rtl == true)
                    {
                    txtNote.RightToLeft = RightToLeft.Yes;
                    txtNote.Font = new Font ("Tahoma", 8);
                    Menu_RTL.Checked = true;
                    }
                else
                    {
                    txtNote.RightToLeft = RightToLeft.No;
                    txtNote.Font = new Font ("Consolas", 8);
                    Menu_RTL.Checked = false;
                    }
                txtNote.SelectionStart = 0;
                txtNote.SelectionLength = 0;
                txtDatum.Enabled = false;
                txtNote.Enabled = false;
                txtNote.ScrollBars = ScrollBars.None;
                SetBlueLEDs ("gridF");
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return;
                }
            }
        private void ShowUNote (int noteid)
            {
            //Show a note using Information in gridupstream
            txtDatum.Enabled = false;
            txtNote.Enabled = false;
            txtNote.ScrollBars = ScrollBars.None;
            try
                {
                //A: LOCATE
                for (int r = 0; r < GridUpstream.Rows.Count; r++)
                    {
                    if (Convert.ToInt32 (GridUpstream[0, r].Value) == Note.Id)
                        {
                        Note.Index = r;
                        GridUpstream.CurrentCell = GridUpstream.Rows[Note.Index].Cells[1];
                        break;
                        }
                    }
                //B: GetRowData
                if (GridUpstream.Rows.Count == 0)
                    return;
                if (GridUpstream.SelectedRows[0].Index == -1)
                    return;
                Note.Id = Convert.ToInt32 (GridUpstream[0, GridUpstream.SelectedRows[0].Index].Value);
                Note.DateTime = Convert.ToString (GridUpstream[1, GridUpstream.SelectedRows[0].Index].Value);
                Note.NoteText = Convert.ToString (GridUpstream[2, GridUpstream.SelectedRows[0].Index].Value);
                Note.Rtl = Convert.ToBoolean (GridUpstream[5, GridUpstream.SelectedRows[0].Index].Value);
                //show frm lables
                Note.Done = Convert.ToBoolean (GridUpstream[6, GridUpstream.SelectedRows[0].Index].Value);
                if (Note.Done == true)
                    {
                    lblDone.Text = "";
                    }
                else
                    {
                    lblDone.Text = "Pending !";
                    }
                if ((Note.Type == "RefNote") || (Note.Type == "RefNoteSearch"))
                    {
                    Note.UserID = Convert.ToInt32 (GridUpstream[7, GridUpstream.SelectedRows[0].Index].Value);
                    }
                else
                    {
                    Note.UserID = User.Id;
                    }
                Note.Index = GridUpstream.CurrentRow.Index;
                //C: SHOW
                txtNote.Text = Note.NoteText;
                txtDatum.Text = Note.DateTime;
                btn_Save.Visible = false;
                if (Note.Rtl == true)
                    {
                    txtNote.RightToLeft = RightToLeft.Yes;
                    txtNote.Font = new Font ("Tahoma", 8);
                    Menu_RTL.Checked = true;
                    }
                else
                    {
                    txtNote.RightToLeft = RightToLeft.No;
                    txtNote.Font = new Font ("Consolas", 8);
                    Menu_RTL.Checked = false;
                    }
                txtDatum.Enabled = false;
                txtNote.SelectionStart = 0;
                txtNote.SelectionLength = 0;
                txtNote.Enabled = false;
                txtNote.ScrollBars = ScrollBars.None;
                SetBlueLEDs ("gridU");
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return;
                }
            }
        private void ShowDNote (int noteid)
            {
            //Show a note using Information in griddownstream
            txtDatum.Enabled = false;
            txtNote.Enabled = false;
            txtNote.ScrollBars = ScrollBars.None;
            try
                {
                //A: LOCATE
                for (int r = 0; r < GridDownstream.Rows.Count; r++)
                    {
                    if (Convert.ToInt32 (GridDownstream[0, r].Value) == Note.Id)
                        {
                        Note.Index = r;
                        GridDownstream.CurrentCell = GridDownstream.Rows[Note.Index].Cells[1];
                        break;
                        }
                    }
                //B: GetRowData
                if (GridDownstream.Rows.Count == 0)
                    return;
                if (GridDownstream.SelectedRows[0].Index == -1)
                    return;
                Note.Id = Convert.ToInt32 (GridDownstream[0, GridDownstream.SelectedRows[0].Index].Value);
                Note.DateTime = Convert.ToString (GridDownstream[1, GridDownstream.SelectedRows[0].Index].Value);
                Note.NoteText = Convert.ToString (GridDownstream[2, GridDownstream.SelectedRows[0].Index].Value);
                Note.Rtl = Convert.ToBoolean (GridDownstream[5, GridDownstream.SelectedRows[0].Index].Value);
                //show frm lables
                Note.Done = Convert.ToBoolean (GridDownstream[6, GridDownstream.SelectedRows[0].Index].Value);
                if (Note.Done == true)
                    {
                    lblDone.Text = "";
                    }
                else
                    {
                    lblDone.Text = "Pending !";
                    }
                if ((Note.Type == "RefNote") || (Note.Type == "RefNoteSearch"))
                    {
                    Note.UserID = Convert.ToInt32 (GridDownstream[7, GridDownstream.SelectedRows[0].Index].Value);
                    }
                else
                    {
                    Note.UserID = User.Id;
                    }
                Note.Index = GridDownstream.CurrentRow.Index;
                //C: SHOW
                txtNote.Text = Note.NoteText;
                txtDatum.Text = Note.DateTime;
                btn_Save.Visible = false;
                if (Note.Rtl == true)
                    {
                    txtNote.RightToLeft = RightToLeft.Yes;
                    txtNote.Font = new Font ("Tahoma", 8);
                    Menu_RTL.Checked = true;
                    }
                else
                    {
                    txtNote.RightToLeft = RightToLeft.No;
                    txtNote.Font = new Font ("Consolas", 8);
                    Menu_RTL.Checked = false;
                    }
                txtDatum.Enabled = false;
                txtNote.SelectionStart = 0;
                txtNote.SelectionLength = 0;
                txtNote.Enabled = false;
                txtNote.ScrollBars = ScrollBars.None;
                SetBlueLEDs ("gridD");
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return;
                }
            }
        private void ShowXNote (int noteid)
            {
            //Show a note using Information in ListNotes (search)
            txtDatum.Enabled = false;
            txtNote.Enabled = false;
            txtNote.ScrollBars = ScrollBars.None;
            if (GridNoteSearch.Rows.Count != 0 && GridNoteSearch.SelectedRows[0].Index != -1)
                {
                txtNote.Text = GridNoteSearch[2, GridNoteSearch.SelectedRows[0].Index].Value.ToString ();
                btn_Save.Visible = false;
                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                Note.ParentType = Convert.ToInt32 (GridNoteSearch[4, GridNoteSearch.SelectedRows[0].Index].Value);
                Note.DateTime = Db.DS.Tables["tblXNotes"].Rows[(int) GridNoteSearch.SelectedRows[0].Index][1].ToString ();
                txtDatum.Text = Note.DateTime;
                if (Convert.ToBoolean (Db.DS.Tables["tblXNotes"].Rows[(int) GridNoteSearch.SelectedRows[0].Index][5]) == true)
                    {
                    txtNote.RightToLeft = RightToLeft.Yes;
                    txtNote.Font = new Font ("Tahoma", 8);
                    Menu_RTL.Checked = true;
                    }
                else
                    {
                    txtNote.RightToLeft = RightToLeft.No;
                    txtNote.Font = new Font ("Consolas", 8);
                    Menu_RTL.Checked = false;
                    }
                if (Convert.ToBoolean (Db.DS.Tables["tblXNotes"].Rows[(int) GridNoteSearch.SelectedRows[0].Index][6]) == true)
                    {
                    lblDone.Text = "";
                    }
                else
                    {
                    lblDone.Text = "Pending !";
                    }
                SetBlueLEDs ("listS");
                }
            }
        private void GetParentInfo (string parentype)
            {
            switch (Note.Type)
                {
                case "FocusNote":
                        {
                        this.Text = "Mindmap: SubProj. " + Convert.ToString (Db.DS.Tables["tblNotesCount"].Rows[1][1]);
                        break;
                        }
                case "SubProjectNote":
                        {
                        this.Text = "Mindmap: SubProj. " + SubProject.Name;
                        break;
                        }
                case "SubProjectNoteSearch":
                        {
                        this.Text = "Mindmap: for a subProject search";
                        break;
                        }
                case "LinkNote":
                        {
                        this.Text = "Mindmap: for a Link";
                        break;
                        }
                case "LinkNoteSearch":
                        {
                        this.Text = "Mindmap: for a Link Search";
                        break;
                        }
                case "RefNote":
                        {
                        this.Text = "Mindmap: for a Ref";
                        break;
                        }
                case "RefNoteSearch":
                        {
                        this.Text = "Mindmap: for a Ref Search";
                        break;
                        }
                }
            }
        private void FormatGridCols (string gridname)
            {
            switch (gridname)
                {
                case "gridfamily":
                        {
                        if (GridNoteFamily.Rows.Count == 0)
                            {
                            return;
                            }
                        else
                            {
                            //disable sort for column_haeders
                            for (int i = 0, loopTo = GridNoteFamily.Columns.Count - 1; i <= loopTo; i++)
                                {
                                GridNoteFamily.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                                }
                            GridNoteFamily.Columns[0].Visible = false;
                            GridNoteFamily.Columns[1].Width = 120;
                            GridNoteFamily.Columns[2].Width = 270;
                            for (int i = 3; i <= 8; i++)
                                GridNoteFamily.Columns[i].Visible = false;
                            //locate grid_row
                            for (int r = 0; r < GridNoteFamily.Rows.Count; r++)
                                if ((int) GridNoteFamily[0, r].Value == Note.Id)
                                    GridNoteFamily.CurrentCell = GridNoteFamily.Rows[r].Cells[1];
                            }
                        break;
                        }
                case "gridupstream":
                        {
                        if (GridUpstream.Rows.Count == 0)
                            {
                            return;
                            }
                        else
                            {
                            for (int i = 0, loopTo = GridUpstream.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                                {
                                GridUpstream.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                                }
                            GridUpstream.Columns[0].Visible = false;
                            GridUpstream.Columns[1].Width = 120;
                            GridUpstream.Columns[2].Width = 270;
                            for (int i = 3; i <= 8; i++)
                                GridUpstream.Columns[i].Visible = false;
                            //for (int r = 0; r < GridUpstream.Rows.Count; r++)
                            //    if ((int) GridUpstream [0, r].Value == Note.Id)
                            //        GridUpstream.CurrentCell = GridNoteFamily.Rows [r].Cells [1];
                            }
                        break;
                        }
                case "griddownstream":
                        {
                        if (GridDownstream.Rows.Count == 0)
                            {
                            return;
                            }
                        for (int i = 0, loopTo = GridDownstream.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                            {
                            GridDownstream.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                            }
                        GridDownstream.Columns[0].Visible = false;
                        GridDownstream.Columns[1].Width = 120;
                        GridDownstream.Columns[2].Width = 270;
                        for (int i = 3; i <= 8; i++)
                            GridDownstream.Columns[i].Visible = false;
                        //for (int r = 0; r < GridNoteFamily.Rows.Count; r++)
                        //    if ((int) GridDownstream [0, r].Value == Note.Id)
                        //        GridDownstream.CurrentCell = GridDownstream.Rows [r].Cells [1];
                        break;
                        }
                case "gridsearch":
                        {
                        if (GridNoteSearch.Rows.Count == 0)
                            {
                            return;
                            }
                        for (int i = 0, loopTo = GridNoteSearch.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                            {
                            GridNoteSearch.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                            }
                        GridNoteSearch.Columns[0].Visible = false;
                        GridNoteSearch.Columns[1].Width = 150;
                        GridNoteSearch.Columns[2].Width = 1050;
                        for (int i = 3; i <= 8; i++)
                            GridNoteSearch.Columns[i].Visible = false;
                        //for (int r = 0; r < GridNoteSearch.Rows.Count; r++)
                        //    if ((int) GridNoteSearch [0, r].Value == Note.Id)
                        //        GridNoteSearch.CurrentCell = GridNoteSearch.Rows [r].Cells [1];
                        break;
                        }
                }
            }
        private void SetBlueLEDs (string strListType)
            {
            lblText4F.Visible = false;
            lblText4U.Visible = false;
            lblText4D.Visible = false;
            lblText4S.Visible = false;
            switch (strListType)
                {
                case "gridF":
                        {
                        lblText4F.Visible = true;
                        break;
                        }
                case "gridU":
                        {
                        lblText4U.Visible = true;
                        break;
                        }
                case "gridD":
                        {
                        lblText4D.Visible = true;
                        break;
                        }
                case "listS":
                        {
                        lblText4S.Visible = true;
                        break;
                        }
                }
            }
        //grid family (notes)
        private void MenuF_SelectSubProject_Click (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            if (Client.DialogRequestParams == 32) //2: item is selected from dialog
                {
                txtNote.Text = "";
                txtDatum.Text = "";
                btn_Save.Visible = false;
                Note.Type = "SubProjectNote";
                Text = SubProject.Name;
                GetNotes (SubProject.Id);
                SetBlueLEDs ("");
                GridNoteFamily.Focus ();
                }
            }
        private void Menu_AddNewNote_Click (object sender, EventArgs e)
            {
            Note.DateTime = DateTime.Now.ToString ("yyyy-MM-dd . HH-mm");
            Note.NoteText = "Proj.: " + Project.Name + " \\ Subproj.: " + SubProject.Name + "\r\n-------\r\nNew note [EDIT]";
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    //notice that EexecuteScalar() should be used to retrieve ID of newly added rec
                    Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType) VALUES (@notedatum, @note, @parentid, 1); SELECT CAST(scope_identity() AS int)";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@notedatum", Note.DateTime);
                    cmdx.Parameters.AddWithValue ("@note", Note.NoteText);
                    cmdx.Parameters.AddWithValue ("@parentid", SubProject.Id.ToString ());
                    Note.Id = (int) cmdx.ExecuteScalar ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                }
            GetNotes (SubProject.Id);
            GridNoteFamily.Focus ();
            GridNoteFamily.Rows[0].Cells[1].Selected = true;
            //MessageBox.Show ("new note created");
            }
        private void lblCaptionNotes_Click (object sender, EventArgs e)
            {
            MenuF_SelectSubProject_Click (null, null);
            }
        private void GridNoteFamily_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            try
                {
                if (GridNoteFamily.CurrentRow.Index == -1) //if (Grid6.SelectedRows [0].Index == -1)
                    return;
                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                Note.ParentType = Convert.ToInt32 (GridNoteFamily[4, GridNoteFamily.SelectedRows[0].Index].Value);
                Note.Id = Convert.ToInt32 (GridNoteFamily[0, GridNoteFamily.SelectedRows[0].Index].Value);
                ShowFNote (Note.Id);
                GetUpstreamNotes (Note.Id);
                GetDownstreamNotes (Note.Id);
                }
            catch (Exception ex)
                {
                //MessageBox.Show ("a\n" + ex.ToString ());
                Note.Id = 0;
                }
            }
        private void GridNoteFamily_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Enter:
                        {
                        e.SuppressKeyPress = true;
                        GridNoteFamily_CellClick (null, null);
                        break;
                        }
                case Keys.Right:
                        {
                        e.SuppressKeyPress = true;
                        GridNoteFamily_CellClick (null, null);
                        if (GridDownstream.Rows.Count > 0)
                            {
                            GridDownstream.Focus ();
                            txtNote.Text = "";
                            btn_Save.Visible = false;
                            }
                        break;
                        }
                case Keys.Left:
                        {
                        e.SuppressKeyPress = true;
                        GridNoteFamily_CellClick (null, null);
                        if (GridUpstream.Rows.Count > 0)
                            {
                            GridUpstream.Focus ();
                            txtNote.Text = "";
                            btn_Save.Visible = false;
                            }
                        break;
                        }
                }
            }
        private void MenuF_AddToNewSubProject_Click (object sender, EventArgs e)
            {
            if (GridNoteFamily.SelectedRows[0].Index == -1)
                {
                return;
                }
            else
                {
                Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
                My.MyProject.Forms.frmChooseProject.ShowDialog ();
                if (Client.DialogRequestParams == 32) //2: item is selected from dialog
                    {
                    Note.NoteText = "";
                    Note.Rtl = false;
                    try
                        {
                        int intNoteA = 0;
                        int intNoteB = 0;
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            CnnSS.Open ();
                            //ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared
                            Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared) VALUES (@notedatum, @note, @parentid, 1, @rtl, 0, @userid, 0); SELECT CAST(scope_identity() AS int)";
                            var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                            cmdx.CommandType = CommandType.Text;
                            cmdx.Parameters.AddWithValue ("@notedatum", Convert.ToString (GridNoteFamily[1, GridNoteFamily.SelectedRows[0].Index].Value));
                            cmdx.Parameters.AddWithValue ("@note", "(noted again) \n" + Convert.ToString (GridNoteFamily[2, GridNoteFamily.SelectedRows[0].Index].Value));
                            cmdx.Parameters.AddWithValue ("@parentid", SubProject.Id.ToString ());
                            cmdx.Parameters.AddWithValue ("@rtl", Convert.ToBoolean (GridNoteFamily[5, GridNoteFamily.SelectedRows[0].Index].Value));
                            cmdx.Parameters.AddWithValue ("@userid", User.Id.ToString ());
                            intNoteB = (int) cmdx.ExecuteScalar ();
                            CnnSS.Close ();
                            }
                        intNoteA = Convert.ToInt32 (GridNoteFamily[0, GridNoteFamily.SelectedRows[0].Index].Value);
                        DoLinkNotesA2B (intNoteA, intNoteB);
                        MessageBox.Show ("Note added to SubProject:\n" + SubProject.Name);
                        GridNoteFamily.Focus ();
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                }
            }
        private void MenuF_BackToUpcoming_Click (object sender, EventArgs e)
            {
            Upcoming ();
            }
        private void MenuF_Exit_Click (object sender, EventArgs e)
            {
            this.Dispose ();
            }
        //textbox edit-note 
        private void frmNoteNetEditor_DoubleClick (object sender, EventArgs e)
            {
            EditNote ();
            }
        private void txtNote_DoubleClick (object sender, EventArgs e)
            {
            txtDatum.Enabled = false;
            txtNote.Enabled = false;
            txtNote.ScrollBars = ScrollBars.None;
            }
        private void txtNote_TextChanged (object sender, EventArgs e)
            {
            if (lblCounter.Text == "")
                {
                lblCounter.Visible = false;
                btn_Save.Visible = false;
                }
            else
                {
                btn_Save.Visible = true;
                lblCounter.Text = txtNote.Text.Length.ToString () + " / 4000";
                lblCounter.Visible = true;
                }
            if (Strings.Right (txtNote.Text, 5).ToLower () == "-save")
                {
                txtNote.Text = Strings.Left (txtNote.Text, txtNote.Text.Length - 5);
                Menu_Save_Click (null, null);
                }
            }
        private void EditNote ()
            {
            txtDatum.Enabled = true;
            txtNote.Enabled = true;
            txtNote.ScrollBars = ScrollBars.Vertical;
            }
        private void txtDatum_DoubleClick (object sender, EventArgs e)
            {
            SetDateTime ();
            }
        private void SetDateTime ()
            {
            var frmTMDT = new frmTimeAndDate ();
            frmTMDT.ShowDialog ();
            if (Client.DialogRequestParams == 16)
                {
                Db.strSQL = "UPDATE Notes SET NoteDatum=@datum WHERE ID=@id";
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.Parameters.AddWithValue ("@datum", Note.DateTime);
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
                //Db.DS.Tables ["tblXNotes"].Rows [(int) GridNoteSearch.SelectedRows [0].Index] [1] = Note.DateTime;
                txtDatum.Text = Note.DateTime;
                btn_Save.Visible = true;
                }
            }
        private void btn_Save_Click (object sender, EventArgs e)
            {
            Menu_Save_Click (null, null);
            }
        private void Menu_RTL_Click (object sender, EventArgs e)
            {
            if (txtNote.RightToLeft == RightToLeft.Yes)
                {
                Menu_RTL.Checked = false;
                txtNote.RightToLeft = RightToLeft.No;
                txtNote.Font = new Font ("Consolas", 8);
                }
            else
                {
                Menu_RTL.Checked = true;
                txtNote.RightToLeft = RightToLeft.Yes;
                txtNote.Font = new Font ("Tahoma", 8);
                }
            }
        private void Menu_EditDateTime_Click (object sender, EventArgs e)
            {
            SetDateTime ();
            }
        private void Menu_Save_Click (object sender, EventArgs e)
            {
            if (txtNote.TextLength > 3999)
                {
                txtNote.ForeColor = System.Drawing.Color.IndianRed;
                MessageBox.Show ("Note text lenght is: " + txtNote.Text.Length.ToString () + " / 4000", "eLib");
                return;
                }
            else if (string.IsNullOrEmpty (Strings.Trim (txtNote.Text)))
                {
                txtNote.Focus ();
                return;
                }
            else
                {
                //Save
                Boolean boolRtl;
                if (txtNote.RightToLeft == RightToLeft.Yes)
                    {
                    boolRtl = true;
                    Note.Rtl = true;
                    }
                else
                    {
                    boolRtl = false;
                    Note.Rtl = false;
                    }
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "UPDATE Notes SET Note=@note, RTL=@rtl WHERE ID=@noteid";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@note", txtNote.Text);
                    cmdx.Parameters.AddWithValue ("@rtl", boolRtl.ToString ());
                    cmdx.Parameters.AddWithValue ("@noteid", Note.Id.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                if (lblText4F.Visible == true)
                    {
                    int r = GridNoteFamily.SelectedRows[0].Index;
                    Db.DS.Tables["tblSNotes"].Rows[r][1] = txtDatum.Text;
                    Db.DS.Tables["tblSNotes"].Rows[r][2] = txtNote.Text;
                    Db.DS.Tables["tblSNotes"].Rows[r][5] = Note.Rtl.ToString ();
                    //GridNoteFamily.Rows [r].Cells [1].Value  = txtDatum.Text;
                    //GridNoteFamily.Rows [r].Cells [2].Value = txtNote.Text;
                    //GridNoteFamily.Rows [r].Cells [5].Value = Note.Rtl.ToString ();
                    GridNoteFamily.Focus ();
                    }
                else if (lblText4U.Visible == true)
                    {
                    int r = GridUpstream.SelectedRows[0].Index;
                    Db.DS.Tables["tblUNotes"].Rows[r][1] = txtDatum.Text;
                    Db.DS.Tables["tblUNotes"].Rows[r][2] = txtNote.Text;
                    Db.DS.Tables["tblUNotes"].Rows[r][5] = Note.Rtl.ToString ();
                    //GridUpstream.Rows [r].Cells [1].Value = txtDatum.Text;
                    //GridUpstream.Rows [r].Cells [2].Value = txtNote.Text;
                    //GridUpstream.Rows [r].Cells [5].Value = Note.Rtl.ToString ();
                    GridUpstream.Focus ();
                    }
                else if (lblText4D.Visible == true)
                    {
                    int r = GridDownstream.SelectedRows[0].Index;
                    Db.DS.Tables["tblDNotes"].Rows[r][1] = txtDatum.Text;
                    Db.DS.Tables["tblDNotes"].Rows[r][2] = txtNote.Text;
                    Db.DS.Tables["tblDNotes"].Rows[r][5] = Note.Rtl.ToString ();
                    //GridDownstream.Rows [r].Cells [1].Value = txtDatum.Text;
                    //GridDownstream.Rows [r].Cells [2].Value = txtNote.Text;
                    //GridDownstream.Rows [r].Cells [5].Value = Note.Rtl.ToString ();
                    GridDownstream.Focus ();
                    }
                else if (lblText4S.Visible == true) //lblSearch
                    {
                    int r = GridNoteSearch.SelectedRows[0].Index;
                    Db.DS.Tables["tblXNotes"].Rows[r][1] = txtDatum.Text;
                    Db.DS.Tables["tblXNotes"].Rows[r][2] = txtNote.Text;
                    Db.DS.Tables["tblXNotes"].Rows[r][5] = Note.Rtl.ToString ();
                    //GridNoteSearch.Rows [r].Cells [1].Value = txtDatum.Text;
                    //GridNoteSearch.Rows [r].Cells [2].Value = txtNote.Text;
                    //GridNoteSearch.Rows [r].Cells [5].Value = Note.Rtl.ToString ();
                    GridNoteSearch.Focus ();
                    }
                btn_Save.Visible = false;
                txtDatum.Enabled = false;
                txtNote.Enabled = false;
                txtNote.ScrollBars = ScrollBars.None;
                }
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void Menu_FontSmall_Click (object sender, EventArgs e)
            {
            if (Note.Rtl == true)
                {
                txtNote.RightToLeft = RightToLeft.Yes;
                txtNote.Font = new Font ("Tahoma", 8);
                Menu_RTL.Checked = true;
                }
            else
                {
                txtNote.RightToLeft = RightToLeft.No;
                txtNote.Font = new Font ("Consolas", 8);
                Menu_RTL.Checked = false;
                }
            }
        private void Menu_FontMedium_Click (object sender, EventArgs e)
            {
            if (Note.Rtl == true)
                {
                txtNote.RightToLeft = RightToLeft.Yes;
                txtNote.Font = new Font ("Tahoma", 11);
                Menu_RTL.Checked = true;
                }
            else
                {
                txtNote.RightToLeft = RightToLeft.No;
                txtNote.Font = new Font ("Consolas", 11);
                Menu_RTL.Checked = false;
                }
            }
        private void Menu_FontLarge_Click (object sender, EventArgs e)
            {
            if (Note.Rtl == true)
                {
                txtNote.RightToLeft = RightToLeft.Yes;
                txtNote.Font = new Font ("Tahoma", 12);
                Menu_RTL.Checked = true;
                }
            else
                {
                txtNote.RightToLeft = RightToLeft.No;
                txtNote.Font = new Font ("Consolas", 12);
                Menu_RTL.Checked = false;
                }
            }
        //grid u notes
        private void GridUpstream_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            try
                {
                if (GridUpstream.CurrentRow.Index == -1) //if (Grid6.SelectedRows [0].Index == -1)
                    return;
                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                Note.ParentType = Convert.ToInt32 (GridUpstream[4, GridUpstream.SelectedRows[0].Index].Value);
                Note.Id = Convert.ToInt32 (GridUpstream[0, GridUpstream.SelectedRows[0].Index].Value);
                ShowUNote (Note.Id);
                }
            catch (Exception ex)
                {
                Note.Id = 0;
                MessageBox.Show (ex.ToString ());
                }
            }
        private void GridUpstream_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 13: //enter
                        {
                        e.SuppressKeyPress = true;
                        GridUpstream_CellClick (null, null);
                        break;
                        }

                case (Keys) 39: //right
                        {
                        e.SuppressKeyPress = true;
                        if (GridNoteFamily.Rows.Count > 0)
                            {
                            GridNoteFamily.Focus ();
                            GridUpstream.DataSource = null;
                            txtNote.Text = "";
                            btn_Save.Visible = false;
                            }
                        break;
                        }
                }
            }
        private void lblCaptionUpstream_Click (object sender, EventArgs e)
            {
            if ((GridUpstream.Rows.Count == 0) || (GridUpstream.SelectedRows[0].Index == -1))
                {
                return;
                }
            Note.Id = Convert.ToInt32 (GridUpstream[0, GridUpstream.SelectedRows[0].Index].Value);
            Note.ParentID = Convert.ToInt32 (GridUpstream[3, GridUpstream.SelectedRows[0].Index].Value.ToString ());
            Note.ParentType = Convert.ToInt32 (GridUpstream[4, GridUpstream.SelectedRows[0].Index].Value);
            txtNote.Text = "";
            txtDatum.Text = "";
            btn_Save.Visible = false;
            switch (Note.ParentType)
                {
                case 1:
                        {
                        Note.Type = "SubProjectNote";
                        break;
                        }
                case 2:
                        {
                        Note.Type = "LinkNote";
                        break;
                        }
                case 3:
                        {
                        Note.Type = "RefNote";
                        break;
                        }
                }
            GetNotes (Note.ParentID);
            GridNoteFamily.Focus ();
            GridNoteFamily_CellClick (null, null);
            }
        private void lblCaptionSearch_Click (object sender, EventArgs e)
            {
            if ((GridNoteSearch.Rows.Count == 0) || (GridNoteSearch.SelectedRows[0].Index == -1))
                {
                //contextMenuStripSearch.Show (lblCaptionSearch.Location);
                return;
                }
            Note.Id = Convert.ToInt32 (GridNoteSearch[0, GridNoteSearch.SelectedRows[0].Index].Value);
            Note.ParentID = Convert.ToInt32 (Db.DS.Tables["tblXNotes"].Rows[(int) GridNoteSearch.SelectedRows[0].Index][3]);
            Note.ParentType = Convert.ToInt32 (Db.DS.Tables["tblXNotes"].Rows[(int) GridNoteSearch.SelectedRows[0].Index][4]);
            txtNote.Text = "";
            txtDatum.Text = "";
            btn_Save.Visible = false;
            switch (Note.ParentType)
                {
                case 1:
                        {
                        Note.Type = "SubProjectNote";
                        break;
                        }
                case 2:
                        {
                        Note.Type = "LinkNote";
                        break;
                        }
                case 3:
                        {
                        Note.Type = "RefNote";
                        break;
                        }
                }
            GetNotes (Note.ParentID);
            GridNoteFamily.Focus ();
            GridNoteFamily_CellClick (null, null);
            }
        private void Menu_DeleteUpStraem_Click (object sender, EventArgs e)
            {
            if (GridUpstream.Rows.Count != 0)
                {
                if (MessageBox.Show ("Delete upstream note?", "Confirm;", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                    int intNoteA = Convert.ToInt32 (GridUpstream[0, GridUpstream.SelectedRows[0].Index].Value);
                    int intNoteB = Convert.ToInt32 (GridNoteFamily[0, GridNoteFamily.SelectedRows[0].Index].Value);
                    DeleteLinkA2B (intNoteA, intNoteB);
                    }
                }
            }
        private bool DeleteLinkA2B (int ida, int idb)
            {
            bool DelLink = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "DELETE FROM NoteNet WHERE (NoteA_ID = @noteaid) AND (NoteB_ID = @notebid)";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@noteaid", ida.ToString ());
                    cmdx.Parameters.AddWithValue ("@notebid", idb.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                DelLink = true;
                GridNoteFamily_CellClick (null, null);
                }
            catch (Exception ex)
                {
                DelLink = false;
                }
            return DelLink;
            }
        //grid d notes
        private void GridDownstream_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            try
                {
                if (GridDownstream.CurrentRow.Index == -1) //if (Grid6.SelectedRows [0].Index == -1)
                    return;
                //0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
                Note.ParentType = Convert.ToInt32 (GridDownstream[4, GridDownstream.SelectedRows[0].Index].Value);
                Note.Id = Convert.ToInt32 (GridDownstream[0, GridDownstream.SelectedRows[0].Index].Value);
                ShowDNote (Note.Id);
                }
            catch (Exception ex)
                {
                Note.Id = 0;
                MessageBox.Show (ex.ToString ());
                }
            }
        private void GridDownstream_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 13: //enter
                        {
                        e.SuppressKeyPress = true;
                        GridDownstream_CellClick (null, null);
                        break;
                        }
                case (Keys) 37: //left
                        {
                        e.SuppressKeyPress = true;
                        GridDownstream_CellClick (null, null);
                        if (GridNoteFamily.Rows.Count > 0)
                            {
                            GridNoteFamily.Focus ();
                            GridDownstream.DataSource = null;
                            txtNote.Text = "";
                            btn_Save.Visible = false;
                            }
                        break;
                        }
                }
            }
        private void lblCaptionDownstream_Click (object sender, EventArgs e)
            {
            if (((GridDownstream.Rows.Count == 0) || (GridDownstream.SelectedRows[0].Index == -1)))
                {
                return;
                }
            Note.Id = Convert.ToInt32 (GridDownstream[0, GridDownstream.SelectedRows[0].Index].Value);
            Note.ParentID = Convert.ToInt32 (GridDownstream[3, GridDownstream.SelectedRows[0].Index].Value.ToString ());
            Note.ParentType = Convert.ToInt32 (GridDownstream[4, GridDownstream.SelectedRows[0].Index].Value);
            txtNote.Text = "";
            txtDatum.Text = "";
            btn_Save.Visible = false;
            switch (Note.ParentType)
                {
                case 1:
                        {
                        Note.Type = "SubProjectNote";
                        break;
                        }
                case 2:
                        {
                        Note.Type = "LinkNote";
                        break;
                        }
                case 3:
                        {
                        Note.Type = "RefNote";
                        break;
                        }
                }
            GetNotes (Note.ParentID);
            GridNoteFamily.Focus ();
            GridNoteFamily_CellClick (null, null);
            }
        private void Menu_DeleteDownStraem_Click (object sender, EventArgs e)
            {
            if (GridDownstream.Rows.Count != 0)
                {
                if (MessageBox.Show ("Delete downstream note?", "Confirm;", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                    int intNoteA = Convert.ToInt32 (GridNoteFamily[0, GridNoteFamily.SelectedRows[0].Index].Value);
                    int intNoteB = Convert.ToInt32 (GridDownstream[0, GridDownstream.SelectedRows[0].Index].Value);
                    DeleteLinkA2B (intNoteA, intNoteB);
                    }
                }
            }
        //grid search
        private void GridNoteSearch_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            try
                {
                if (GridNoteSearch.SelectedRows[0].Index == -1)
                    return;
                Note.Id = Convert.ToInt32 (GridNoteSearch[0, GridNoteSearch.SelectedRows[0].Index].Value);
                ShowXNote (Note.Id);
                }
            catch (Exception ex)
                {
                Note.Id = 0;
                MessageBox.Show (ex.ToString ());
                }
            }
        private void GridNoteSearch_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Left:
                        {
                        e.SuppressKeyPress = true;
                        break;
                        }
                case Keys.Right:
                        {
                        e.SuppressKeyPress = true;
                        GridNoteSearch_CellClick (null, null);
                        break;
                        }
                case Keys.Enter:
                        {
                        e.SuppressKeyPress = true;
                        GridNoteSearch_CellClick (null, null);
                        break;
                        }
                case Keys.Escape:
                        {
                        e.SuppressKeyPress = true;
                        if (GridNoteFamily.Rows.Count > 0)
                            {
                            GridNoteFamily.Focus ();
                            txtNote.Text = "";
                            btn_Save.Visible = false;
                            }
                        break;
                        }
                }
            }
        private void Menu_AddUpstream_Click (object sender, EventArgs e)
            {
            if ((GridNoteFamily.SelectedRows[0] == null) || (GridNoteSearch.SelectedRows[0] == null))
                {
                return;
                }
            int intNoteA = Convert.ToInt32 (GridNoteSearch[0, GridNoteSearch.SelectedRows[0].Index].Value);
            int intNoteB = Convert.ToInt32 (GridNoteFamily[0, GridNoteFamily.SelectedRows[0].Index].Value);
            DoLinkNotesA2B (intNoteA, intNoteB);
            }
        private void Menu_AddDownstream_Click (object sender, EventArgs e)
            {
            if ((GridNoteFamily.SelectedRows[0] == null) || (GridNoteSearch.SelectedRows[0] == null))
                {
                return;
                }
            int intNoteA = Convert.ToInt32 (GridNoteFamily[0, GridNoteFamily.SelectedRows[0].Index].Value);
            int intNoteB = Convert.ToInt32 (GridNoteSearch[0, GridNoteSearch.SelectedRows[0].Index].Value);
            DoLinkNotesA2B (intNoteA, intNoteB);
            }
        private bool DoLinkNotesA2B (int ida, int idb)
            {
            bool DoLink = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "INSERT INTO NoteNet (NoteA_ID, NoteB_ID) VALUES (@noteaid, @notebid)";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@noteaid", ida.ToString ());
                    cmdx.Parameters.AddWithValue ("@notebid", idb.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                DoLink = true;
                GridNoteFamily_CellClick (null, null);
                }
            catch (Exception ex)
                {
                DoLink = false;
                }
            return DoLink;
            }
        //textbox search
        private void txt_Search_Click (object sender, EventArgs e)
            {
            txt_Search.SelectionStart = 0;
            txt_Search.SelectionLength = txt_Search.Text.Length;
            }
        private void txt_Search_TextChanged (object sender, EventArgs e)
            {
            if (txt_Search.Text == "")
                {
                txt_Search.Text = "Search";
                txt_Search.SelectionStart = 0;
                txt_Search.SelectionLength = txt_Search.Text.Length;
                }
            }
        private void txt_Search_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 38: //up
                        {
                        GridNoteFamily.Focus ();
                        break;
                        }
                case (Keys) 40: //down
                        {
                        GridNoteSearch.Focus ();
                        break;
                        }
                case (Keys) 13: //enter
                        {
                        e.SuppressKeyPress = true;
                        string searchString = Strings.Trim (txt_Search.Text);
                        FindNotes (searchString);
                        FormatGridCols ("gridsearch");
                        GridNoteSearch.Focus ();
                        txt_Search.SelectionStart = txt_Search.Text.Length;
                        txtNote.Text = "";
                        txtNote.Enabled = false;
                        txtDatum.Enabled = false;
                        break;
                        }
                case (Keys) 27: //escape
                        {
                        txt_Search.Text = "";
                        GridNoteSearch.DataSource = null;
                        break;
                        }
                }
            }
        //
        private void FindNotes (string searchString)
            {
            txt_Search.Focus ();
            string KeyxA = "";
            string Keyx1 = "";
            string Keyx2 = "";
            string Keyx3 = "";
            string Keyx4 = "";
            string Fltrx = ""; //search Notes 
            var spcz = new int[4];
            //locate spaces in the search string : save nSPC in scpz(0)
            KeyxA = searchString;
            int k = 0;
            for (int i = 1, loopTo = Strings.Len (KeyxA); i <= loopTo; i++)
                {
                if (Strings.Mid (KeyxA, i, 1) == " ")
                    {
                    k = k + 1;
                    if (k == 4)
                        break;
                    spcz[k] = i;
                    }
                }
            spcz[0] = k;
            //how many spaces?
            switch (spcz[0])
                {
                case 0: // no space; one key
                        {
                        Fltrx = "(Notes.Note Like '%" + KeyxA + "%')";
                        break;
                        }
                case 1: // 1 space; 2 keys
                        {
                        // Keyx1 = Mid(KeyxA, 1, spcz(1) - 1)
                        Keyx1 = Strings.Left (KeyxA, spcz[1] - 1);
                        Keyx2 = Strings.Mid (KeyxA, spcz[1] + 1);
                        Fltrx = "(Notes.Note Like '%" + Keyx1 + "%') AND ";
                        Fltrx = Fltrx + "(Notes.Note Like '%" + Keyx2 + "%')";
                        break;
                        }
                case 2: // 2 spaces; 3 keys
                        {
                        Keyx1 = Strings.Left (KeyxA, spcz[1] - 1);
                        Keyx2 = Strings.Mid (KeyxA, spcz[1] + 1, spcz[2] - spcz[1] - 1);
                        Keyx3 = Strings.Mid (KeyxA, spcz[2] + 1);
                        Fltrx = "(Notes.Note Like '%" + Keyx1 + "%') AND ";
                        Fltrx = Fltrx + "(Notes.Note Like '%" + Keyx2 + "%') AND ";
                        Fltrx = Fltrx + "(Notes.Note Like '%" + Keyx3 + "%')";
                        break;
                        }
                case 3:
                case 4:
                        {
                        Keyx1 = Strings.Left (KeyxA, spcz[1] - 1);
                        Keyx2 = Strings.Mid (KeyxA, spcz[1] + 1, spcz[2] - spcz[1] - 1);
                        Keyx3 = Strings.Mid (KeyxA, spcz[2] + 1, spcz[3] - spcz[2] - 1);
                        Keyx4 = Strings.Mid (KeyxA, spcz[3] + 1);
                        Fltrx = "(Notes.Note Like '%" + Keyx1 + "%') AND ";
                        Fltrx = Fltrx + "(Notes.Note Like '%" + Keyx2 + "%') AND ";
                        Fltrx = Fltrx + "(Notes.Note Like '%" + Keyx3 + "%') AND ";
                        Fltrx = Fltrx + "(Notes.Note Like '%" + Keyx4 + "%')";
                        break;
                        }
                }
            Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE (" + Fltrx + ")  ORDER BY NoteDatum DESC;";
            //Do Query
            try
                {
                Db.DS.Tables["tblXNotes"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    Db.DASS.Fill (Db.DS, "tblXNotes");
                    CnnSS.Close ();
                    }
                GridNoteSearch.DataSource = Db.DS.Tables["tblXNotes"];
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return;
                }
            //nrows? :if no result => reduce from keys
            if (Db.DS.Tables["tblXNotes"].Rows.Count == 0)
                {
                switch (spcz[0])
                    {
                    case 0:
                            {
                            txt_Search.Text = "";
                            break;
                            }
                    case 1:
                            {
                            txt_Search.Text = Keyx1;
                            break;
                            }
                    case 2:
                            {
                            txt_Search.Text = Keyx1 + " " + Keyx2;
                            break;
                            }
                    case 3:
                    case 4:
                            {
                            txt_Search.Text = Keyx1 + " " + Keyx2 + " " + Keyx3;
                            break;
                            }
                    }
                if (Strings.Right (txt_Search.Text, 1) != " ")
                    txt_Search.Text = txt_Search.Text + " .";
                txt_Search.SelectionStart = Strings.Len (txt_Search.Text);
                }
            }
        //Exit
        private void Upcoming ()
            {
            //Upcoming Notes
            try
                {
                Note.GetSNotesFromDB ("all");
                Dispose (); //close me
                var frmUpcomingNT = new frmUpcomingNotes ();
                frmUpcomingNT.ShowDialog ();
                }
            catch { }
            }
        private void frmNoteNetEditor_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Escape)
                {
                this.Dispose ();
                }
            }
        private void btn_Upcoming_Click (object sender, EventArgs e)
            {
            Upcoming ();
            }
        private void btn_Assign_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        }
    }
