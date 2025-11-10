using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmChooseProject
        {
        public frmChooseProject ()
            {
            InitializeComponent ();
            }
        private void frmChooseProject_Load (object sender, EventArgs e)
            {
            Width = 665;
            Height = 490;
            if (Client.DialogRequestParams == 1)
                {
                this.Text = "Select: PROJECT";
                ListProd.Enabled = false; //Menu2_OK.Enabled = false;
                lblProject.Visible = true;
                }
            else if (Client.DialogRequestParams == 2)
                {
                this.Text = "Select: SUB-PROJECT";
                Menu1_OK.Enabled = false;
                lblSubProject.Visible = true;
                }
            else if (Client.DialogRequestParams == 3)
                {
                this.Text = "Select: PROJECT  or  SUB-PROJECT";
                lblProject.Visible = true;
                lblSubProject.Visible = true;
                }
            Db.DS.Tables ["tblProj_tmp"].Clear ();
            Db.DS.Tables ["tblProd_tmp"].Clear ();
            GetListProj (User.Id, 0); // activex {0:active 1:inactive 2:all}
            ListProj.DataSource = Db.DS.Tables ["tblProj_tmp"];
            ListProj.DisplayMember = "ProjectName";
            ListProj.ValueMember = "ID";
            Db.DS.Tables ["tblProd_tmp"].Clear ();
            }
        private void frmChooseProject_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Escape)
                {
                Menu1_Cancel_Click (null, null);
                }
            }
        private void RefreshProjextsTable (int usrid, int activex)
            {
            /* var activex :
             * 0:active
             * 1:inactive 
             * 2:all
             */
            Db.DS.Tables ["tblProject"].Clear ();
            switch (activex)
                {
                case 0:
                        {
                        Db.strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Projects WHERE (ID IN (SELECT Project_Id FROM User_Project WHERE User_Id = " + usrid.ToString () + ") OR user_ID = " + usrid.ToString () + ") AND Active= 1 Order By ProjectName";
                        break;
                        }
                case 1:
                        {
                        Db.strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Projects WHERE (ID IN (SELECT Project_Id FROM User_Project WHERE User_Id = " + usrid.ToString () + ") OR user_ID = " + usrid.ToString () + ") AND Active= 0 Order By ProjectName";
                        break;
                        }
                case 2:
                        {
                        Db.strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Projects WHERE (ID IN (SELECT Project_Id FROM User_Project WHERE User_Id = " + usrid.ToString () + ") OR user_ID = " + usrid.ToString () + ") Order By ProjectName";
                        break;
                        }
                }
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblProject");
                CnnSS.Close ();
                }
            }
        //list1 Search Project
        private void txtSearchProj_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                string searchString = Strings.Trim (txtSearchProj.Text);
                try
                    {
                    if (string.IsNullOrEmpty (Strings.Trim (txtSearchProj.Text)))
                        {
                        txtSearchProj.Text = "";
                        Menu1_All_Click (null, null);
                        }
                    else
                        {
                        Db.DS.Tables ["tblProj_tmp"].Clear ();
                        Db.DS.Tables ["tblProd_tmp"].Clear ();
                        // /
                        FindProject (searchString);
                        ListProj.SelectedValue = -1;
                        Menu1_Active.Checked = false;
                        Menu1_Inactive.Checked = false;
                        Menu1_All.Checked = false;
                        // /
                        FindSubProjects (searchString);
                        ListProd.SelectedValue = -1;
                        Menu1_Active.Checked = false;
                        Menu1_Inactive.Checked = false;
                        Menu1_All.Checked = false;
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                e.SuppressKeyPress = true;
                }
            else if (e.KeyCode == Keys.Down)
                {
                ListProj.Focus ();
                e.SuppressKeyPress = true;
                }
            }
        private void FindProject (string searchString)
            {
            searchString = "(ProjectName Like '%" + searchString + "%' OR ProjectName Like '%" + searchString + "%') AND (user_ID = " + User.Id.ToString () + ")";
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, ProjectName FROM Projects  WHERE (" + searchString + ") ORDER BY ProjectName DESC;", CnnSS);
                    Db.DASS.Fill (Db.DS, "tblProj_tmp");
                    CnnSS.Close ();
                    }
                ListProj.DataSource = Db.DS.Tables ["tblProj_tmp"];
                ListProj.DisplayMember = "ProjectName";
                ListProj.ValueMember = "ID";
                }
            catch (Exception ex)
                {
                }
            }
        private void FindSubProjects (string searchString)
            {
            searchString = "(SubProjectName Like '%" + searchString + "%' OR SubProjectName Like '%" + searchString + "%') AND (user_ID = " + User.Id.ToString () + ")";
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT SubProjects.ID, SubProjectName, SubProject.Notes FROM Projects INNER JOIN SubProjects ON Projects.ID = SubProjects.Project_ID WHERE (" + searchString + ") ORDER BY SubProjectName DESC;", CnnSS);
                    Db.DASS.Fill (Db.DS, "tblProd_tmp");
                    CnnSS.Close ();
                    }
                ListProd.DataSource = Db.DS.Tables ["tblProd_tmp"];
                ListProd.DisplayMember = "SubProjectName";
                ListProd.ValueMember = "ID";
                }
            catch (Exception ex)
                {
                }
            }
        //list1 Project
        private void GetListProj (int usrid, int activex)
            {
            // activex {0:active 1:inactive 2:all}
            Db.DS.Tables ["tblProj_tmp"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                switch (activex)
                    {
                    case 0:
                            {
                            Db.strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Projects Where user_ID = " + usrid.ToString () + " AND Active= 1 Order By ProjectName";
                            break;
                            }
                    case 1:
                            {
                            Db.strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Projects Where user_ID = " + usrid.ToString () + " AND Active = 0 Order By ProjectName";
                            break;
                            }
                    case 2:
                            {
                            Db.strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Projects Where user_ID = " + usrid.ToString () + " Order By ProjectName";
                            break;
                            }
                    }
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblProj_tmp");
                CnnSS.Close ();
                }
            }
        private void ListProj_Click (object sender, EventArgs e)
            {
            if (ListProj.SelectedIndex == -1)
                return;
            try
                {
                int projid = Conversions.ToInteger (ListProj.SelectedValue);
                if (projid > 0)
                    GetListProd (projid);
                }
            catch (Exception ex)
                {
                }
            }
        private void ListProj_DoubleClick (object sender, EventArgs e)
            {
            Menu1_OK_Click (sender, e);
            }
        private void Menu1_NewProject_Click (object sender, EventArgs e)
            {
            //strProjectName | strProjectNote
            int tempVariable = Client.DialogRequestParams; //Client.DialogRequestParams is needed for another dialog temporarily!
            Client.DialogRequestParams = 1; //project
            Project.IsActive = true; //active
            //get new Proj info
            My.MyProject.Forms.frmProject.ShowDialog ();
            try
                {
                if (Client.DialogRequestParams == 16) //save it
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "INSERT INTO Projects (ProjectName, Notes, Active, user_ID) VALUES (@projectname, @notes, @active, @userid); SELECT CAST (scope_identity() AS int)";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@projectname", Project.Name);
                        cmdx.Parameters.AddWithValue ("@notes", Project.Note);
                        cmdx.Parameters.AddWithValue ("@active", Project.IsActive.ToString ());
                        cmdx.Parameters.AddWithValue ("@userid", User.Id.ToString ());
                        Project.Id = (int) cmdx.ExecuteScalar ();
                        CnnSS.Close ();
                        }
                    AddNewSubProject (Project.Id, Project.Name); // {0: auto add SubProjects for new Project | 1: add extra SubProjects for a already existing project}
                    RefreshProjextsTable (User.Id, 2); //refresh to all-projects: for frmAssign.List3
                    //restore back Client.DialogRequestParams for frmSelectProject
                    Client.DialogRequestParams = tempVariable;
                    Menu1_All_Click (null, null);// refresh list3 itself!
                    ListProj.SelectedValue = Project.Id;
                    ListProj_Click (null, null);
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
        private void Menu1_Active_Click (object sender, EventArgs e)
            {
            Db.DS.Tables ["tblProj_tmp"].Clear ();
            Db.DS.Tables ["tblProd_tmp"].Clear ();
            GetListProj (User.Id, 0); // activex {0:active 1:inactive 2:all}
            ListProj.DataSource = Db.DS.Tables ["tblProj_tmp"];
            ListProj.DisplayMember = "ProjectName";
            ListProj.ValueMember = "ID";
            Db.DS.Tables ["tblProd_tmp"].Clear ();
            Menu1_Active.Checked = true;
            Menu1_Inactive.Checked = false;
            Menu1_All.Checked = false;
            txtSearchProj.Text = "";
            }
        private void Menu1_Inactive_Click (object sender, EventArgs e)
            {
            Db.DS.Tables ["tblProj_tmp"].Clear ();
            Db.DS.Tables ["tblProd_tmp"].Clear ();
            GetListProj (User.Id, 1); // activex {0:active 1:inactive 2:all}
            ListProj.DataSource = Db.DS.Tables ["tblProj_tmp"];
            ListProj.DisplayMember = "ProjectName";
            ListProj.ValueMember = "ID";
            Db.DS.Tables ["tblProd_tmp"].Clear ();
            Menu1_Active.Checked = false;
            Menu1_Inactive.Checked = true;
            Menu1_All.Checked = false;
            txtSearchProj.Text = "";
            }
        private void Menu1_All_Click (object sender, EventArgs e)
            {
            Db.DS.Tables ["tblProj_tmp"].Clear ();
            Db.DS.Tables ["tblProd_tmp"].Clear ();
            GetListProj (User.Id, 2); // activex {0:active 1:inactive 2:all}
            ListProj.DataSource = Db.DS.Tables ["tblProj_tmp"];
            ListProj.DisplayMember = "ProjectName";
            ListProj.ValueMember = "ID";
            Db.DS.Tables ["tblProd_tmp"].Clear ();
            Menu1_Active.Checked = false;
            Menu1_Inactive.Checked = false;
            Menu1_All.Checked = true;
            txtSearchProj.Text = "";
            }
        private void ListProj_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                e.SuppressKeyPress = true;
                Menu1_OK_Click (null, null);
                }
            }
        private void Menu1_OK_Click (object sender, EventArgs e)
            {
            if ((ListProj.SelectedIndex == -1) || (Client.DialogRequestParams == 2))
                {
                return;
                }
            else
                {
                //RefreshProjextsTable (User.Id, 2); //refresh to all-projects: for frmAssign.List3
                Project.Id = Conversions.ToInteger (ListProj.SelectedValue);
                Project.Name = ListProj.Text; // check if this line of code is interferring, if not, keep it!
                Client.DialogRequestParams = 64; //bit7: 01000000: a project is selected
                Dispose ();
                }
            }
        private void Menu1_Cancel_Click (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 0; // Cancelled
            Dispose ();
            }
        //list2 SubProject
        private void GetListProd (int Projid)
            {
            // activex {0:active 1:inactive 2:all}
            Db.DS.Tables ["tblProd_tmp"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.strSQL = "Select ID, SubProjectName, Notes FROM SubProjects Where Project_ID = " + Projid.ToString () + " Order By SubProjectName";
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblProd_tmp");
                CnnSS.Close ();
                }
            ListProd.DataSource = Db.DS.Tables ["tblProd_tmp"];
            ListProd.DisplayMember = "SubProjectName";
            ListProd.ValueMember = "ID";
            }
        private void ListProd_Click (object sender, EventArgs e)
            {
            if (ListProd.SelectedIndex == -1)
                return;
            TextBoxProdNote.Text = Conversions.ToString (Db.DS.Tables ["tblProd_tmp"].Rows [ListProd.SelectedIndex] [2]);
            }
        private void ListProd_DoubleClick (object sender, EventArgs e)
            {
            Menu2_OK_Click (sender, e);
            }
        private void Menu2_NewSubProject_Click (object sender, EventArgs e)
            {
            if (ListProj.SelectedIndex == -1)
                {
                return;
                }
            else
                {
                Project.Id = (int) ListProj.SelectedValue;
                Project.Name = ListProj.Text;
                AddNewSubProject (Project.Id, Project.Name);
                }
            }
        private void AddNewSubProject (int intProjectId, string strProjectName)
            {
            SubProject.Name = Strings.Left (strProjectName, 8) + ".sub " + (ListProd.Items.Count + 1).ToString ().Trim () + "-[" + DateTime.Now.ToString ("HHmm") + "]";//yyyyMMddHHmm
            SubProject.Note = "[Note]";
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "INSERT INTO SubProjects (SubProjectName, Notes, Project_ID) VALUES (@SubProjectName, @notes, @projectid); SELECT CAST (scope_identity() AS int)";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@SubProjectName", SubProject.Name);
                    cmdx.Parameters.AddWithValue ("@notes", SubProject.Note);
                    cmdx.Parameters.AddWithValue ("@projectid", Project.Id.ToString ());
                    SubProject.Id = (int) cmdx.ExecuteScalar (); //was: int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                ListProj_Click (null, null); // refresh listProj
                ListProd.SelectedValue = SubProject.Id;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                }
            }
        private void ListProd_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
                {
                e.SuppressKeyPress = true;
                Menu1_OK_Click (null, null);
                }
            }
        private void Menu2_OK_Click (object sender, EventArgs e)
            {
            if ((ListProd.SelectedIndex == -1) || (Client.DialogRequestParams == 1)) //if the request was for project not subproject
                {
                return;
                }
            else
                {
                //RefreshProjextsTable (User.Id, 2); //refresh to all-projects: for frmAssign.List3
                SubProject.Id = Conversions.ToInteger (ListProd.SelectedValue);
                SubProject.Note = Strings.Trim (TextBoxProdNote.Text);
                SubProject.Name = ListProd.Text;
                Client.DialogRequestParams = 32; // OK , one SubProjects is Selected
                Dispose ();
                }
            }
        private void Menu2_Cancel_Click (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 0; // Canceled
            Dispose ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 0; // Canceled
            Dispose ();
            }
        }
    }