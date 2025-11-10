using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmReadRef
        {
        public frmReadRef ()
            {
            InitializeComponent ();
            }
        private void frmReadRef_Load (object sender, EventArgs e)
            {
            Width = 1270;
            Height = 160;
            //Menu_Delete.Enabled = (User.Type != "Admin") ? false: true;
            RefreshPathTable ();
            if (ListPaths.Items.Count > 0)
                {
                ListPaths.SelectedIndex = 0;
                }
            }
        private void RefreshPathTable ()
            {
            try
                {
                Db.DS.Tables ["tblRefPaths"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT FilePath, StorageSN FROM Paths WHERE StorageSN = '" + Client.DriveSN + "' AND FilePath Like '%" + Ref.Title + "%' ORDER BY FilePath;", CnnSS);
                    Db.DASS.Fill (Db.DS, "tblRefPaths");
                    CnnSS.Close ();
                    }
                ListPaths.DataSource = Db.DS.Tables ["tblRefPaths"];
                ListPaths.DisplayMember = "FilePath";
                ListPaths.ValueMember = "FilePath";
                ListPaths.SelectedIndex = -1;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void ListPaths_DoubleClick (object sender, EventArgs e)
            {
            Menu_Read_Click (sender, e); //ContextMenuStrip1.Show (Control.MousePosition);
            }
        private void ListPaths_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case (Keys) 13:
                        {
                        Menu_Read_Click (sender, e);
                        break;
                        }
                case (Keys) 27:
                        {
                        Menu_Cancel_Click (sender, e);  // nothing
                        break;
                        }

                default:
                        {
                        break;
                        }
                }
            }
        private void lblOpenRead_Click (object sender, EventArgs e)
            {
            Menu_Read_Click (null, null);
            }
        //MENU
        private void Menu_Read_Click (object sender, EventArgs e)
            {
            if (ListPaths.SelectedIndex == -1)
                {
                ListPaths.Focus ();
                return;
                }
            Instance.Path = ListPaths.Text;
            long G = Interaction.Shell ("RUNDLL32.EXE URL.DLL,FileProtocolHandler " + Instance.Path, Constants.vbNormalFocus);
            Dispose ();
            }
        private void Menu_Edit_Click (object sender, EventArgs e)
            {
            if (ListPaths.SelectedIndex == -1)
                {
                ListPaths.Focus ();
                return;
                }
            Instance.Path = ListPaths.Text;
            Ref.ImportStatus = 3; //1+2 (editRef + requested from outside of frmImport)
            try
                {
                eLibFile.Extension = Strings.Right (Instance.Path, 4);
                if (Strings.Left (eLibFile.Extension, 1) != ".")
                    {
                    eLibFile.Extension = "." + eLibFile.Extension;
                    }
                My.MyProject.Computer.FileSystem.MoveFile (Instance.Path, Strings.Left (Instance.Path, 3) + Ref.Title + eLibFile.Extension, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                try //Delete thisPath from tbl_Paths
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "DELETE FROM Paths WHERE FilePath='" + Instance.Path + "'";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                Instance.Path = Strings.Left (Instance.Path, 3) + Ref.Title + eLibFile.Extension; //Path of the Ref in Root Directory
                Dispose ();
                My.MyProject.Forms.frmAssign.WindowState = FormWindowState.Minimized;
                My.MyProject.Forms.frmImportRefs.Show (); //Dialog ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Selected Ref is NOT Accessible! Close teh Ref and Try Again", "eLib", MessageBoxButtons.OK);
                return;
                }
            }
        private void Menu_Delete_Click (object sender, EventArgs e)
            {
            //Waiting ...
            //if (User.Type != "Admin")
            //    return;
            if (ListPaths.SelectedIndex == -1)
                return;
            DialogResult myansw = (DialogResult) MessageBox.Show ("NOTICE: Delete Ref from Repository ? SURE ?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            switch (myansw)
                {
                case DialogResult.No:
                        {
                        return;
                        }
                case DialogResult.Yes:
                        {
                        VBMath.Randomize ();
                        int strRndNumber = Conversions.ToInteger (Strings.Trim (Conversion.Str ((int) Math.Round (Conversion.Int (10000f * VBMath.Rnd () + 1001f)))));
                        string strAnsw = Interaction.InputBox ("Enter this Code: " + strRndNumber, "Enter Code below to Proceed with Delete", "");
                        if (Conversions.ToDouble (strAnsw) != strRndNumber)
                            {
                            return;
                            }
                        else
                            {
                            try
                                {
                                //delete thisPath from tbl_Paths
                                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                    {
                                    CnnSS.Open ();
                                    Db.strSQL = "DELETE FROM Paths WHERE FilePath='" + Instance.Path + "'";
                                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                    cmdx.CommandType = CommandType.Text;
                                    int ix = cmdx.ExecuteNonQuery ();
                                    CnnSS.Close ();
                                    }
                                //code here... : first make sure there is a recycleFolder inside d:\eLib, then move the file to recycleFolder                            
                                //delete the Ref
                                Instance.Path = ListPaths.Text;
                                My.MyProject.Computer.FileSystem.MoveFile (Instance.Path, "D:/eLib/zz_" + strRndNumber.ToString () + "_del_" + Strings.Right (Instance.Path, 8), Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                                //ALTERNATIVELY: System.IO.File.Delete (Instance.Path);
                                }
                            catch (Exception ex)
                                {
                                //MessageBox.Show (ex.ToString ());
                                }
                            RefreshPathTable ();
                            }
                        break;
                        }
                }
            }
        private void Menu_Locate_Click (object sender, EventArgs e)
            {
            //Locate
            if (ListPaths.SelectedIndex == -1)
                return;
            Instance.Path = ListPaths.Text;
            string strTitle = Instance.Path;
        lblNextBackslash:
            ;

            int intPosBackslash = 0;
            intPosBackslash = Strings.InStr (1, strTitle, @"\");
            if (intPosBackslash != 0)
                {
                strTitle = Strings.Mid (strTitle, intPosBackslash + 1);
                goto lblNextBackslash;
                }
            Instance.Path = Strings.Left (Instance.Path, Strings.Len (Instance.Path) - Strings.Len (strTitle) - 1);
            Interaction.Shell ("explorer " + Instance.Path, AppWinStyle.NormalFocus);
            }
        private void Menu_SaveACopy_Click (object sender, EventArgs e)
            {
            //SaveACopy
            if (ListPaths.SelectedIndex == -1)
                return;
            //strFolderSaveACopy = ?
            Instance.Path = ListPaths.Text;
            //Extract Filename
            string strTitle = Instance.Path;
        lblNextBackslash:
            ;
            int intPosBackslash = 0;
            intPosBackslash = Strings.InStr (1, strTitle, @"\");
            if (intPosBackslash != 0)
                {
                strTitle = Strings.Mid (strTitle, intPosBackslash + 1);
                goto lblNextBackslash;
                }
            My.MyProject.Computer.FileSystem.CopyFile (Instance.Path, User.FolderSaveACopy + @"\" + strTitle, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
            DialogResult myansw = (DialogResult) MessageBox.Show ("A Copy of Ref: \r\n" + strTitle + "\r\n Copied to: \r\n" + User.FolderSaveACopy + "\r\n \r\n Open Folder?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            switch (myansw)
                {
                case DialogResult.Yes:
                        {
                        Menu_OpenSaveFolder_Click (sender, e);
                        break;
                        }
                case DialogResult.No:
                        {
                        break;
                        }
                }
            }
        private void Menu_OpenSaveFolder_Click (object sender, EventArgs e)
            {
            //OpenSaveFolder
            //strFolderSaveACopy = ?
            long G = Interaction.Shell ("RUNDLL32.EXE URL.DLL,FileProtocolHandler " + User.FolderSaveACopy, Constants.vbNormalFocus);
            }
        private void Menu_Email_Click (object sender, EventArgs e)
            {
            //WAINTING ...
            //Email
            // Dim strTo As String = "msht.ir@outlook.com"
            // Dim strSubject As String = "My Subject"
            // Dim strBody As String = "The Body of the message goes here"
            // Dim strMessage As String = "mailto:" & strTo & "?subject=" & strSubject & "&body=" & strBody
            // System.Diagnostics.Process.Start(strMessage)
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        }
    }