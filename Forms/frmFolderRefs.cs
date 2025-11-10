using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;
namespace eLib
    {
    public partial class frmFolderRefs
        {
        public frmFolderRefs ()
            {
            InitializeComponent ();
            }
        private void frmFolderRefs_Load (object sender, EventArgs e)
            {
            ListPathx.View = View.List;
            //in module: Public DestinationFolder As String = ""
            eLibFile.DestinationFolder = System.Windows.Forms.Application.StartupPath; // OR: Environment.SpecialFolder.Desktop
            lblPath.Text = "Select folder ...";
            Width = 1310;
            Height = 677;
            Menu2_Lectures_Click (null, null);
            }
        private void treeView1_AfterSelect (object sender, TreeViewEventArgs e)
            {
            try
                {
                //show files in the list
                ListPathx.Items.Clear ();
                string [] Files = Directory.GetFiles (treeView1.SelectedNode.FullPath, "*.*");
                lblPath.Text = treeView1.SelectedNode.FullPath;
                // Loop through them to see files
                foreach (string file in Files)
                    {
                    FileInfo fi = new FileInfo (file);
                    ListViewItem item = new ListViewItem (fi.Name);
                    switch (Strings.Right (fi.Name, 4).ToLower ())
                        {
                        case ".pdf":
                                {
                                item.ForeColor = System.Drawing.Color.Black;
                                break;
                                }
                        case ".doc":
                        case "docx":
                                {
                                item.ForeColor = System.Drawing.Color.DarkBlue;
                                break;
                                }
                        case ".ppt":
                        case "pptx":
                                {
                                item.ForeColor = System.Drawing.Color.DarkRed;
                                break;
                                }
                        case ".xls":
                        case "xlsx":
                                {
                                item.ForeColor = System.Drawing.Color.DarkGreen;
                                break;
                                }
                        case ".jpg":
                        case ".bmp":
                        case ".png":
                                {
                                item.ForeColor = System.Drawing.Color.DarkOrange;
                                break;
                                }
                        default:
                                {
                                item.ForeColor = System.Drawing.Color.DarkGray;
                                break;
                                }
                        }
                    ListPathx.Items.Add (item);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void lblPath_Click (object sender, EventArgs e)
            {
            ContextMenuStrip2.Show (Control.MousePosition);
            }
        private void blLink_Click (object sender, EventArgs e)
            {
            Menu_Assign_Click (null, null);
            }
        //Menu1
        private void Menu_Read_Click (object sender, EventArgs e)
            {
            if (ListPathx.SelectedItems.Count > 0)
                {
                Instance.Path = Strings.Trim (ListPathx.SelectedItems [0].Text);
                //MessageBox.Show (treeView1.SelectedNode.FullPath + @"\" + Instance.Path);
                long G = Interaction.Shell ("RUNDLL32.EXE URL.DLL,FileProtocolHandler " + treeView1.SelectedNode.FullPath + @"\" + Instance.Path, Microsoft.VisualBasic.Constants.vbNormalFocus);
                }
            }
        private void Menu_OpenFolder_Click (object sender, EventArgs e)
            {
            try
                {
                long G = Interaction.Shell ("RUNDLL32.EXE URL.DLL,FileProtocolHandler " + treeView1.SelectedNode.FullPath, Microsoft.VisualBasic.Constants.vbNormalFocus);
                }
            catch (Exception ex)
                {
                }
            }
        private void Menu_Assign_Click (object sender, EventArgs e)
            {
            //Do Link checked items
            // intRef = ListPaths.SelectedValue
            int tmpCNT = ListPathx.CheckedItems.Count;
            if (tmpCNT == 0)
                {
                if (ListPathx.CheckBoxes != true)
                    {
                    MessageBox.Show ("1. RightClick and switch to ListView mode\n\n2. Make sure some items are checked to be Linked", "eLib", MessageBoxButtons.OK);
                    }
                else
                    {
                    MessageBox.Show ("Make sure some items are checked to be Linked", "eLib", MessageBoxButtons.OK);
                    }
                return;
                }
            tmpCNT = 0; // use as a counter
            string strItem = "";
            Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            if (Client.DialogRequestParams == 32) //32: A SubProjects is selected from dialog //intProd=id of the selected SubProject
                {
                if (SubProject.Id < 1)
                    return;
                for (int i = 0, loopTo = ListPathx.Items.Count - 1; i <= loopTo; i++)
                    {
                    if (ListPathx.Items [i].Checked == true)
                        {
                        strItem = ListPathx.Items [i].ToString ();
                        int intRefId = FindRefId (strItem);
                        if (intRefId > 0)
                            {
                            int k;
                            k = DoAssignRefToSubProjects (intRefId, SubProject.Id);
                            if (k == 1)
                                {
                                lblPath.Text = "Assigned:  " + strItem;
                                tmpCNT = tmpCNT + 1;
                                }
                            }
                        }
                    }
                lblPath.Text = "Assigned Refs:  " + tmpCNT.ToString ();
                }
            }
        private void Menu_CopyTitle_Click (object sender, EventArgs e)
            {
            if (ListPathx.SelectedItems.Count > 0)
                {
                string tmpx = ListPathx.Text;
                if (Strings.Mid (tmpx, (tmpx.Length - 3), 1) == ".")
                    {
                    My.MyProject.Computer.Clipboard.SetText (Strings.Left (tmpx, (tmpx.Length - 4)));
                    }
                else if (Strings.Mid (tmpx, (tmpx.Length - 4), 1) == ".")
                    {
                    My.MyProject.Computer.Clipboard.SetText (Strings.Left (tmpx, (tmpx.Length - 5)));
                    }
                else
                    {
                    My.MyProject.Computer.Clipboard.SetText (tmpx);
                    }
                }
            }
        private void Menu_Inverse_Click (object sender, EventArgs e)
            {
            for (int i = 0, loopTo = ListPathx.Items.Count - 1; i <= loopTo; i++)
                {
                if (ListPathx.Items [i].Checked == true)
                    {
                    ListPathx.Items [i].Checked = false;
                    }
                else
                    {
                    ListPathx.Items [i].Checked = true;
                    }
                }
            }
        private void Menu_None_Click (object sender, EventArgs e)
            {
            for (int i = 0, loopTo = ListPathx.Items.Count - 1; i <= loopTo; i++)
                ListPathx.Items [i].Checked = false;
            }
        private void Menu_ViewList_Click (object sender, EventArgs e)
            {
            ToggleView ("viewList");
            }
        private void Menu_ViewTile_Click (object sender, EventArgs e)
            {
            ToggleView ("viewTile");
            }
        //Menu2
        private void Menu2_Papers_Click (object sender, EventArgs e)
            {
            eLibFile.DestinationFolder = User.FolderPapers;
            treeView1.Nodes.Clear ();
            DirectoryInfo di = new DirectoryInfo (eLibFile.DestinationFolder);
            TreeNode tds = treeView1.Nodes.Add (di.FullName);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadSubDirectories (eLibFile.DestinationFolder, tds);
            treeView1.ExpandAll ();
            treeView1.SelectedNode = treeView1.Nodes [0];
            treeView1_AfterSelect (null, null);
            }
        private void Menu2_Books_Click (object sender, EventArgs e)
            {
            eLibFile.DestinationFolder = User.FolderBooks;
            treeView1.Nodes.Clear ();
            DirectoryInfo di = new DirectoryInfo (eLibFile.DestinationFolder);
            TreeNode tds = treeView1.Nodes.Add (di.FullName);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadSubDirectories (eLibFile.DestinationFolder, tds);
            treeView1.ExpandAll ();
            treeView1.SelectedNode = treeView1.Nodes [0];
            treeView1_AfterSelect (null, null);
            }
        private void Menu2_Manuals_Click (object sender, EventArgs e)
            {
            eLibFile.DestinationFolder = User.FolderManuals;
            treeView1.Nodes.Clear ();
            DirectoryInfo di = new DirectoryInfo (eLibFile.DestinationFolder);
            TreeNode tds = treeView1.Nodes.Add (di.FullName);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadSubDirectories (eLibFile.DestinationFolder, tds);
            treeView1.ExpandAll ();
            treeView1.SelectedNode = treeView1.Nodes [0];
            treeView1_AfterSelect (null, null);
            }
        private void Menu2_Lectures_Click (object sender, EventArgs e)
            {
            eLibFile.DestinationFolder = User.FolderLectures;
            treeView1.Nodes.Clear ();
            DirectoryInfo di = new DirectoryInfo (eLibFile.DestinationFolder);
            TreeNode tds = treeView1.Nodes.Add (di.FullName);
            tds.Tag = di.FullName;
            tds.StateImageIndex = 0;
            LoadSubDirectories (eLibFile.DestinationFolder, tds);
            treeView1.ExpandAll ();
            treeView1.SelectedNode = treeView1.Nodes [0];
            treeView1_AfterSelect (null, null);
            }
        private void Menu2_SelectFolderromDialog_Click (object sender, EventArgs e)
            {
            SelectDirectory ();
            }
        //methods
        private void LoadSubDirectories (string dir, TreeNode td)
            {
            //get all subdirectories
            string [] subdirectoryEntries = Directory.GetDirectories (dir);
            foreach (string subdirectory in subdirectoryEntries)
                {
                //loop through them to see if they have any other subdirectories
                DirectoryInfo di = new DirectoryInfo (subdirectory);
                TreeNode tds = td.Nodes.Add (di.Name);
                tds.StateImageIndex = 0;
                tds.Tag = di.FullName;
                LoadSubDirectories (subdirectory, tds);
                }
            }
        private int FindRefId (string strTitle)
            {
            int FindRefIdRet = default;
            //Find ID of a Ref in tblPapers
            Db.DS.Tables ["tblRefs"].Clear ();
            string Fltr = "PaperName='" + strTitle + "'";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture FROM Links RIGHT JOIN Papers ON Links.Paper_ID = Papers.ID  WHERE (" + Fltr + ") ORDER BY Papers.ID DESC;", CnnSS);
                Db.DASS.Fill (Db.DS, "tblRefs");
                CnnSS.Close ();
                }
            FindRefIdRet = Conversions.ToInteger (Db.DS.Tables ["tblRefs"].Rows [0] [0]);
            return FindRefIdRet;
            }
        private int DoAssignRefToSubProjects (int iRef, int iProd)
            {
            int DoAssignRefToSubProjectRet = default;
            Db.strSQL = "INSERT INTO Links (Paper_ID, SubProject_ID) VALUES (@paperid, @SubProjectid)";
            DoAssignRefToSubProjectRet = 1;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmdx.CommandType = CommandType.Text;
                cmdx.Parameters.AddWithValue ("@paperid", iRef.ToString ());
                cmdx.Parameters.AddWithValue ("@SubProjectid", iProd.ToString ());
                try
                    {
                    int ix = cmdx.ExecuteNonQuery ();
                    }
                catch (Exception ex)
                    {
                    DoAssignRefToSubProjectRet = 0;
                    MessageBox.Show (ex.ToString ());
                    }
                CnnSS.Close ();
                }

            return DoAssignRefToSubProjectRet;
            }
        public void SelectDirectory ()
            {
            FolderBrowserDialog1.SelectedPath = eLibFile.DestinationFolder;   // OR Environment.SpecialFolder.Desktop
            if (FolderBrowserDialog1.ShowDialog () == DialogResult.OK)
                {
                eLibFile.DestinationFolder = FolderBrowserDialog1.SelectedPath + @"\";
                //ScanFolder (eLibFile.DestinationFolder);
                treeView1.Nodes.Clear ();
                DirectoryInfo di = new DirectoryInfo (eLibFile.DestinationFolder);
                TreeNode tds = treeView1.Nodes.Add (di.FullName);
                tds.Tag = di.FullName;
                tds.StateImageIndex = 0;
                LoadSubDirectories (eLibFile.DestinationFolder, tds);
                treeView1.ExpandAll ();
                treeView1.SelectedNode = treeView1.Nodes [0];
                treeView1_AfterSelect (null, null);
                }
            else
                {
                return;
                }
            }
        private void ToggleView (string viewMode)
            {
            switch (viewMode)
                {
                case "viewList":
                        {
                        ListPathx.View = View.List;
                        ListPathx.CheckBoxes = true;
                        btnTileList.Text = "Tile";
                        break;
                        }
                case "viewTile":
                        {
                        ListPathx.CheckBoxes = false;
                        ListPathx.View = View.Tile;
                        ListPathx.TileSize = new Size (340, 60);
                        btnTileList.Text = "List";
                        break;
                        }
                case "viewLargeIcon":
                        {
                        ListPathx.View = View.LargeIcon;
                        ListPathx.CheckBoxes = true;
                        ListPathx.TileSize = new Size (340, 120);
                        btnTileList.Text = "List";
                        break;
                        }
                default:
                        {
                        ListPathx.View = View.List;
                        ListPathx.CheckBoxes = true;
                        btnTileList.Text = "List";
                        break;
                        }
                }
            try
                {
                treeView1_AfterSelect (null, null);
                }
            catch (Exception ex)
                {
                }
            }
        //Exit
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void lblRead_Click (object sender, EventArgs e)
            {
            Menu_Read_Click (null, null);
            }
        private void lblBack_Click (object sender, EventArgs e)
            {
            Dispose ();
            }

        private void btnBrowse_Click (object sender, EventArgs e)
            {
            Menu2_SelectFolderromDialog_Click (null, null);
            }
        private void btnTileList_Click (object sender, EventArgs e)
            {
            if (ListPathx.View == View.List)
                {
                ToggleView ("viewTile");
                }
            else
                {
                ToggleView ("viewList");
                }
            }
        }
    }