using eLib.Forms;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmScan
        {
        public frmScan ()
            {
            InitializeComponent ();
            }
        private void frmScan_Load (object sender, EventArgs e)
            {
            Width = 590;
            Height = 345;
            CheckFolders ();
            RefreshFolderPathLabels ();
            }
        private void frmScan_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode.ToString () == "F5")
                {
                e.SuppressKeyPress = true;
                lblScan_Click (null, null);
                }
            else if (e.KeyCode.ToString () == "Escape")
                {
                e.SuppressKeyPress = true;
                lblExit_Click (null, null);
                }
            }
        private void lblStatus_Click (object sender, EventArgs e)
            {
            CheckFolders ();
            }
        private void CheckFolders ()
            {
            if (User.ValidateFolders () == "valid")
                {
                lblStatus.Text = "Folders are valid.     F5: Scan";
                }
            else
                {
                lblStatus.Text = "Check Folders    (click)";
                }
            }
        private void RefreshFolderPathLabels ()
            {
            lblFolderPapers.Text = User.FolderPapers;
            lblFolderBooks.Text = User.FolderBooks;
            lblFolderManuals.Text = User.FolderManuals;
            lblFolderLectures.Text = User.FolderLectures;
            lblFolderSaveACopy.Text = User.FolderSaveACopy;
            }
        //Clicks
        private void lbl_P_Click (object sender, EventArgs e)
            {
            User.FolderPapers = GeteLibFolderPath (User.FolderPapers);
            SaveFolderAddress2DB ("P", User.FolderPapers);
            RefreshFolderPathLabels ();
            }
        private void lbl_B_Click (object sender, EventArgs e)
            {
            User.FolderBooks = GeteLibFolderPath (User.FolderBooks);
            SaveFolderAddress2DB ("B", User.FolderBooks);
            RefreshFolderPathLabels ();
            }
        private void lbl_M_Click (object sender, EventArgs e)
            {
            User.FolderManuals = GeteLibFolderPath (User.FolderManuals);
            SaveFolderAddress2DB ("M", User.FolderManuals);
            RefreshFolderPathLabels ();
            }
        private void lbl_L_Click (object sender, EventArgs e)
            {
            User.FolderLectures = GeteLibFolderPath (User.FolderLectures);
            SaveFolderAddress2DB ("L", User.FolderLectures);
            RefreshFolderPathLabels ();
            }
        private void lbl_S_Click (object sender, EventArgs e)
            {
            User.FolderSaveACopy = GeteLibFolderPath (User.FolderSaveACopy);
            SaveFolderAddress2DB ("S", User.FolderSaveACopy);
            RefreshFolderPathLabels ();
            }
        public string GeteLibFolderPath (string strFldr)
            {
            string GeteLibFolderPathRet = default;
            FolderBrowserDialog1.SelectedPath = strFldr; // Application.StartupPath 
            if (FolderBrowserDialog1.ShowDialog () == DialogResult.OK)
                {
                GeteLibFolderPathRet = FolderBrowserDialog1.SelectedPath;
                }
            else
                {
                string strNewPath = Interaction.InputBox ("Enter new folder path :", "Settings", strFldr);
                if (Strings.Len (strNewPath) > 2)
                    {
                    GeteLibFolderPathRet = strNewPath;
                    }
                else
                    {
                    GeteLibFolderPathRet = "not available!";
                    }
                }

            return GeteLibFolderPathRet;
            }
        private void lblScan_Click (object sender, EventArgs e)
            {
            Menu_Scan_Click (null, null);
            }
        //Save Folder_address
        private void SaveFolderAddress2DB (string FldrType, string strFldrPath)
            {
            switch (FldrType)
                {
                case "P":
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderPapers = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case "B":
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderBooks = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case "M":
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderManuals = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case "L":
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderLectures = @sttvalue WHERE ID = @ID";
                        break;
                        }
                case "S":
                        {
                        Db.strSQL = "UPDATE Usrs SET FolderSaveACopy = @sttvalue WHERE ID = @ID";
                        break;
                        }
                }
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@sttvalue", strFldrPath);
                cmd.Parameters.AddWithValue ("@ID", User.Id.ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            CheckFolders ();
            }
        //SCAN
        private void Menu_Scan_Click (object sender, EventArgs e)
            {
            //Do Scan
            lblStatus.Text = "Please wait...";
            Application.DoEvents ();
            Db.ScanResources ();
            lblStatus.Text = "SCAN finished successfully!";
            Db.ReadSettingsAndUsers ();
            //Menu_Exit_Click (sender, e);
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            ExitThisForm ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            ExitThisForm ();
            }
        private void ExitThisForm ()
            {
            switch (Client.Interface)
                {
                case 1:
                        {
                        Dispose ();
                        Form Assign1 = new frmAssign ();
                        Assign1.ShowDialog ();
                        break;
                        }
                case 2:
                        {
                        Dispose ();
                        Form Assign2 = new frmAssign2 ();
                        Assign2.ShowDialog ();
                        break;
                        }
                }
            }
        }
    }