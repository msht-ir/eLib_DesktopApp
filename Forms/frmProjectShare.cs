using System;
using System.Data;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmProjectShare : Form
        {
        public frmProjectShare ()
            {
            InitializeComponent ();
            }
        private void frmProjectShare_Load (object sender, EventArgs e)
            {
            Text = "Sharing:  " + Project.Name;
            lstUsr.DataSource = Db.DS.Tables ["tblUsrs"];
            lstUsr.DisplayMember = "UsrName";
            lstUsr.ValueMember = "ID";
            lstUsr.SelectedIndex = -1;
            ShowShareList ();
            }
        private void ShowShareList ()
            {
            //get list of users this project is already shared with them
            GridShare.DataSource = null;
            Db.DS.Tables ["tblUserProject"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT User_Id, UsrName, UsrNote, Project_Id, ReadOnly FROM usrs JOIN User_Project ON usrs.ID = User_Project.User_Id WHERE Project_Id = " + Project.Id.ToString (), CnnSS);
                Db.DASS.Fill (Db.DS.Tables ["tblUserProject"]);
                //MessageBox.Show ("rows count:  " + Db.DS.Tables ["tblUserProject"].Rows.Count.ToString ());
                CnnSS.Close ();
                }
            //Grid
            GridShare.DataSource = Db.DS.Tables ["tblUserProject"];
            GridShare.Columns [0].Visible = false; //userId
            GridShare.Columns [1].Width = 150;     //userName
            GridShare.Columns [2].Width = 280;     //userNote
            GridShare.Columns [3].Visible = false; //projectId
            GridShare.Columns [4].Width = 70;      //readOnly
            for (int k = 0; k <= GridShare.Columns.Count - 1; k++)
                {
                GridShare.Columns [k].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            lstUsr.SelectedIndex = -1;
            }
        private void lstUsr_DoubleClick (object sender, EventArgs e)
            {
            Menu_AddToShareList_Click (null, null);
            }
        private void GridShare_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            try
                {
                int r = (int) GridShare.SelectedCells [0].RowIndex;
                int c = (int) GridShare.SelectedCells [0].ColumnIndex;
                switch (c)
                    {
                    case 1: //userName
                            {
                            RemoveSharing ();
                            break;
                            }
                    case 4: //readOnly
                            {
                            ChangeAccess ();
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            ShowShareList ();
            }
        private void lstUsr_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 27:
                        {
                        Menu_Cancel_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 13:
                        {
                        Menu_AddToShareList_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 39:
                        {
                        GridShare.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void GridShare_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13://Enter
                        {
                        RemoveSharing ();
                        ShowShareList ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 32: //Space
                        {
                        ChangeAccess ();
                        ShowShareList ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case 27: //SCAPE
                        {
                        lstUsr.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void RemoveSharing ()
            {
            //remove an item from the shareGrid
            int r = (int) GridShare.SelectedCells [0].RowIndex;
            int c = (int) GridShare.SelectedCells [0].ColumnIndex;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.strSQL = "DELETE FROM User_Project WHERE (User_Id = " + Convert.ToInt32 (GridShare.Rows [r].Cells [0].Value).ToString () + " AND Project_Id = " + Convert.ToInt32 (GridShare.Rows [r].Cells [3].Value).ToString () + ")";
                var cmd1 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd1.CommandType = CommandType.Text;
                int k = cmd1.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        private void ChangeAccess ()
            {
            int r = (int) GridShare.SelectedCells [0].RowIndex;
            int c = (int) GridShare.SelectedCells [0].ColumnIndex;
            bool boolAccess = true;
            if (Convert.ToBoolean (GridShare.Rows [r].Cells [4].Value) == true)
                boolAccess = false;
            else
                boolAccess = true;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                //Change the user
                Db.strSQL = "Update User_Project Set ReadOnly = @readonly WHERE User_Id = @userid AND Project_Id = @projectid";
                var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue ("@readonly", (bool) boolAccess);
                cmd2.Parameters.AddWithValue ("@userid", Convert.ToInt32 (GridShare.Rows [r].Cells [0].Value).ToString ());
                cmd2.Parameters.AddWithValue ("@projectid", Convert.ToInt32 (GridShare.Rows [r].Cells [3].Value).ToString ());
                int m = cmd2.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        //MENU1
        private void Menu_AddToShareList_Click (object sender, EventArgs e)
            {
            //add
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                if (lstUsr.SelectedIndex == -1)
                    {
                    return;
                    }
                CnnSS.Open ();
                Db.strSQL = "INSERT INTO User_Project (User_Id, Project_Id, ReadOnly) VALUES (@userid, @projectid, @readonly)";
                var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue ("@userid", lstUsr.SelectedValue.ToString ());
                cmd2.Parameters.AddWithValue ("@projectid", Project.Id.ToString ());
                cmd2.Parameters.AddWithValue ("@readonly", false);
                int m = cmd2.ExecuteNonQuery ();
                CnnSS.Close ();
                ShowShareList ();
                }
            }
        private void Menu_Transfer_Click (object sender, EventArgs e)
            {
            //entrust
            try
                {
                // Confirm
                DialogResult i = MessageBox.Show ("Entrust project:  " + Project.Name + "\n\n to user:  " + lstUsr.Text + "?\n\n\nNOTICE: this operation can't be undo", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (i == DialogResult.Yes)
                    {
                    DialogResult ii = MessageBox.Show ("Sure?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (ii == DialogResult.No)
                        return;
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        //Change the user
                        Db.strSQL = "UPDATE Projects SET User_Id = @userid WHERE Projects.ID = @id ";
                        var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.AddWithValue ("@userid", ((int) lstUsr.SelectedValue).ToString ());
                        cmd2.Parameters.AddWithValue ("@id", Project.Id.ToString ());
                        int m = cmd2.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    this.Dispose ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            this.Dispose ();
            }
        //MENU2
        private void Menu2_ChangeAccess_Click (object sender, EventArgs e)
            {
            int r = 0;
            bool boolAccess = true;
            try
                {
                r = (int) GridShare.CurrentRow.Index;
                if (r == -1)
                    return;
                if (Convert.ToBoolean (GridShare.Rows [r].Cells [4].Value) == true)
                    boolAccess = false;
                else
                    boolAccess = true;
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    //Change the user
                    Db.strSQL = "Update User_Project Set ReadOnly = @readonly WHERE User_Id = @userid AND Project_Id = @projectid";
                    var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue ("@readonly", (bool) boolAccess);
                    cmd2.Parameters.AddWithValue ("@userid", Convert.ToInt32 (GridShare.Rows [r].Cells [0].Value).ToString ());
                    cmd2.Parameters.AddWithValue ("@projectid", Convert.ToInt32 (GridShare.Rows [r].Cells [3].Value).ToString ());
                    int m = cmd2.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                return;
                }
            ShowShareList ();
            }
        private void Menu2_Cancel_Click (object sender, EventArgs e)
            {
            this.Dispose ();
            }

        private void lblExit_Click (object sender, EventArgs e)
            {
            this.Dispose ();
            }
        }
    }
