using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmImportRefs
        {
        private FileInfo MyFile;
        private string strTitleA;
        private string strTitleB;
        public frmImportRefs ()
            {
            InitializeComponent ();
            }
        //formLOAD
        private void frmImportRefs_Load (object sender, EventArgs e)
            {
            Width = 725;
            Height = 295;
            this.Focus ();
            this.BringToFront ();
            this.Activate ();
            AllowDrop = true;
            Db.ReadSettingsAndUsers ();
            Db.DS.Tables ["tblProd_tmp2"].Clear ();
            ListSubProject.DataSource = Db.DS.Tables ["tblProd_tmp2"];
            ListSubProject.ValueMember = "ProdId";
            ListSubProject.DisplayMember = "ProdName";
            lblDestinationFolder.Text = "-"; //this label will be checked in line 490
            int status = (Ref.ImportStatus & 15); //check bits1-4: 0001111
            /* 
              Ref.ImportStatus
              bit1(1): 0:new,           1:edit
              bit2(2): 0:via frmImport, 1:via frmAssign
              bit3(4): 0:woLink,        1:con Link
              bit4(8): 0:select a Ref,  1:ready to Move
             */
            switch (status)
                {
                case 2: //import is requested via frmaAssign, w/o link
                        {
                        //(no drops!)ShowFileInfo (eLibFile.strFilex);
                        break;
                        }
                case 6: //(2+4) import via frmAssign, con link to a subproject
                        {
                        //add a subproject t list
                        Db.DS.Tables ["tblProd_tmp2"].Rows.Add (SubProject.Id, SubProject.Name);
                        //(no drops!)ShowFileInfo (eLibFile.strFilex);
                        break;
                        }
                case 3: //editRef or newlyCreatedRefDoc   --mode: Disable these: {SelectRef, Paste, AssignList}: just move with new {type/title/note} w/o change in links!
                        {
                        txtTitle.Text = Ref.Title;
                        eLibFile.Filename = Instance.Path;
                        ShowFileInfo (Instance.Path);
                        switch (Strings.Trim (Ref.TypeText))
                            {
                            case "Paper":
                                    {
                                    lblRefType.Text = "<    Paper    >";
                                    break;
                                    }
                            case "Book":
                                    {
                                    lblRefType.Text = "<    Book    >";
                                    break;
                                    }
                            case "Manual":
                                    {
                                    lblRefType.Text = "<    Manual    >";
                                    break;
                                    }
                            case "Lecture":
                                    {
                                    lblRefType.Text = "<    Lecture    >";
                                    break;
                                    }
                            }
                        Menu1_SelectRef.Enabled = false;
                        Menu1_Paste.Enabled = false;
                        Menu2_Add.Enabled = false;
                        Menu2_Remove.Enabled = false;
                        Menu2_Clear.Enabled = false;
                        for (int i = 0, loopTo = Db.DS.Tables ["tblAssignments"].Rows.Count - 1; i <= loopTo; i++)
                            {
                            //tblProd_tmp2 Cols: {ProdId, ProdName}
                            SubProject.Id = Conversions.ToInteger (Db.DS.Tables ["tblAssignments"].Rows [i] [2]);
                            SubProject.Name = Conversions.ToString (Db.DS.Tables ["tblAssignments"].Rows [i] [3]);
                            Db.DS.Tables ["tblProd_tmp2"].Rows.Add (SubProject.Id, SubProject.Name);
                            }
                        Ref.ImportStatus |= 8; //bit4: on (ref is ready2move)
                        break;
                        }
                }
            }
        private void lblAutoMove2_Click (object sender, EventArgs e)
            {
            if (lblAutoMove.BackColor == Color.FromArgb (230, 230, 230))
                {
                lblAutoMove.BackColor = Color.Gold;
                lblImport.Visible = false;
                }
            else
                {
                lblAutoMove.BackColor = Color.FromArgb (230, 230, 230);
                lblImport.Visible = true;
                }
            }
        private void lblAskFolder2_Click (object sender, EventArgs e)
            {
            if (lblAskFolder.BackColor == Color.FromArgb (230, 230, 230))
                {
                lblAskFolder.BackColor = Color.Gold;
                }
            else
                {
                lblAskFolder.BackColor = Color.FromArgb (230, 230, 230);
                }
            }
        private void lblAutoMove_Click (object sender, EventArgs e)
            {
            lblAutoMove2_Click (null, null);
            }
        private void lblAskFolder_Click (object sender, EventArgs e)
            {
            lblAskFolder2_Click (null, null);
            }
        //RefType PBML
        private void lblRefType_Click (object sender, EventArgs e)
            {
            switch (lblRefType.Text)
                {
                case "<    Paper    >":
                        {
                        lblRefType.Text = "<    Book    >";
                        break;
                        }
                case "<    Book    >":
                        {
                        lblRefType.Text = "<    Manual    >";
                        break;
                        }
                case "<    Manual    >":
                        {
                        lblRefType.Text = "<    Lecture    >";
                        break;
                        }
                case "<    Lecture    >":
                        {
                        lblRefType.Text = "<    Paper    >";
                        break;
                        }
                }
            }
        private void lblDestinationFolder_Click (object sender, EventArgs e)
            {
            if (lblDestinationFolder.Text != "-")
                {
                lblAskFolder2_Click (null, null);
                }
            else
                {
                lblAskFolder.BackColor = Color.Gold;
                }
            }
        private void lblImport_Click (object sender, EventArgs e)
            {
            MoveThisRef ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Menu_Exit ();
            }
        //MENU_2 (Links list)
        private void Menu2_Add_Click (object sender, EventArgs e)
            {
            //Add
            Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            if (Client.DialogRequestParams != 32)
                return;
            //tblProd_tmp2 Cols: {ProdId, ProdName}
            Db.DS.Tables ["tblProd_tmp2"].Rows.Add (SubProject.Id, SubProject.Name);
            }
        private void Menu2_Remove_Click (object sender, EventArgs e)
            {
            //Remove
            if (ListSubProject.Items.Count == 0)
                return;
            if (ListSubProject.SelectedItems.Count == 0)
                return; // No cells is selected
            int i = ListSubProject.SelectedIndex;
            Db.DS.Tables ["tblProd_tmp2"].Rows.RemoveAt (i);
            }
        private void ListSubProject_DoubleClick (object sender, EventArgs e)
            {
            Menu2_Remove_Click (sender, e);
            }
        private void Menu2_Clear_Click (object sender, EventArgs e)
            {
            //Clear
            Db.DS.Tables ["tblProd_tmp2"].Clear ();
            }
        //MENU_1 SELECT/Drag-Drop
        private void Menu1_SelectRef_Click (object sender, EventArgs e)
            {
            Ref.ImportStatus = (Ref.ImportStatus & 7); //set bit 4 off: nothing is ready2move into eLibFolders (after processing the Title, will be on)
            txtTitle.Text = "";
            using (var dialog = new OpenFileDialog () { InitialDirectory = User.FolderTemp, Filter = "eLib Refs|*.*" })
                {
                if (dialog.ShowDialog () == DialogResult.OK)
                    {
                    eLibFile.Filename = dialog.FileName;
                    lblPath.Text = eLibFile.Filename;
                    lblPath.Visible = true;
                    ShowFileInfo (eLibFile.Filename);
                    }
                else // Nothing selected via File Dialog
                    {
                    lblPath.Visible = true;
                    lblPath.Text = "Drop a Ref  ^";
                    lblExt.Visible = false;
                    lblSize.Visible = false;
                    lblCreated.Visible = false;
                    lblModified.Visible = false;
                    return;
                    }
                }
            }
        private void txtTitle_DragEnter (object sender, DragEventArgs e)
            {
            /* display behavior of the mouse icon
               Ref.ImportStatus
               bit1(1): 0:new, 1:edit
               bit2(2): 0:via frmImport, 1:via frmAssign
               bit3(4): 0:woLink, 1:conLink
               bit4(8): 0:selectRef, 1:ready2Move
             */
            //if (((Ref.ImportStatus & 8) == 0) && (e.Data.GetDataPresent (DataFormats.FileDrop)))
            e.Effect = DragDropEffects.Copy;
            }
        private void txtTitle_DragDrop (object sender, DragEventArgs e)
            {
            //get one file from dropped item(s)
            //if ((Ref.ImportStatus & 8) == 0)
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            eLibFile.strFilex = strFiles [0];
            ShowFileInfo (eLibFile.strFilex);
            }
        private void ShowFileInfo (string strF)
            {
            MyFile = new FileInfo (strF);
            if (string.IsNullOrWhiteSpace (MyFile.Extension))
                {
                return; //abort if file is not valid
                }
            else
                {
                eLibFile.Filename = MyFile.FullName;
                lblPath.Visible = true;
                lblExt.Visible = true;
                lblSize.Visible = true;
                lblCreated.Visible = true;
                lblModified.Visible = true;
                //
                lblPath.Text = MyFile.FullName;
                lblExt.Text = "Type: " + MyFile.Extension;
                lblSize.Text = "Size: " + Math.Round (MyFile.Length / 1024d) + " KB";
                lblCreated.Text = "Created: " + Conversions.ToString (MyFile.CreationTime);
                lblModified.Text = "Modified: " + Conversions.ToString (MyFile.LastWriteTime);
                UpdateTempFolder ();
                }
            }
        private void UpdateTempFolder ()
            {
            txtTitle.Text = eLibParseRefFileName (eLibFile.Filename);
            txtTitle.SelectionStart = 0;
            txtTitle.SelectionLength = Strings.Len (txtTitle.Text);
            txtTitle.Focus (); //ready for paste
            //update strFolderTemp
            User.FolderTemp = Instance.Path;
            //Update TempFolder in DB
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.strSQL = "UPDATE usrs SET FolderTemp = @foldertemp WHERE ID = @id";
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@foldertemp", Instance.Path);
                cmd.Parameters.AddWithValue ("@ID", User.Id.ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            Ref.ImportStatus = (Ref.ImportStatus | 8); //set bit 4 on: a strFileName (original) is ready2move into eLibFolders (as txtTitle.Text)
            if (lblAutoMove.BackColor == Color.Gold)
                {
                MoveThisRef ();
                }
            }
        private string eLibParseRefFileName (string strTitleA)
            {
            string eLibParseRefFileNameRet = default;
            eLibParseRefFileNameRet = "";
            int j = 0;
            for (int i = 1; i <= 5; i++)
                {
                j = 0;
                j = Strings.InStr (j + 1, strTitleA, ":");
                if (j > 2)
                    {
                    strTitleB = Strings.Left (strTitleA, j - 1) + "-" + Strings.Mid (strTitleA, j + 1);
                    strTitleA = strTitleB;
                    }
                j = 0;
                j = Strings.InStr (j + 1, strTitleA, "?");
                if (j > 0)
                    {
                    strTitleB = Strings.Left (strTitleA, j - 1) + "-" + Strings.Mid (strTitleA, j + 1);
                    strTitleA = strTitleB;
                    }
                }

        lblNextBackslash:
            ;

            int intPosBackslash = 0;
            intPosBackslash = Strings.InStr (1, strTitleA, @"\");
            if (intPosBackslash != 0)
                {
                strTitleA = Strings.Mid (strTitleA, intPosBackslash + 1);
                goto lblNextBackslash;
                }
            eLibFile.Extension = MyFile.Extension;
            Instance.Path = Strings.Left (eLibFile.Filename, Strings.Len (eLibFile.Filename) - Strings.Len (strTitleA));
            strTitleA = Strings.Left (strTitleA, Strings.Len (strTitleA) - Strings.Len (eLibFile.Extension));
            eLibParseRefFileNameRet = strTitleA;
            return eLibParseRefFileNameRet;
            }
        //MENU_1 -PASTE
        public string eLibParseAuthorLine (object strAuthorx)
            {
            string eLibParseAuthorLineRet = default;
            int tmpspace = 0;
            int tmp0 = 0;
            int tmp1 = 0;
            int tmp2 = 0;
            int tmp3 = 0;
            int tmp4 = 0;
            int tmp5 = 0;
            int tmpx1 = 0;
            int tmpx2 = 0;
            eLibParseAuthorLineRet = "";
            strAuthorx = Strings.Trim (Conversions.ToString (strAuthorx));
            for (int j = 1; j <= 5; j++)
                {
                tmpspace = Strings.InStr (1, Conversions.ToString (strAuthorx), " ");
                if (tmpspace > 0)
                    strAuthorx = Strings.Mid (Conversions.ToString (strAuthorx), tmpspace + 1, Strings.Len (strAuthorx) - tmpspace);
                strAuthorx = Strings.Trim (Conversions.ToString (strAuthorx));
                }
            //Remove numbers and signs * '
            for (int i = 1; i <= 10; i++)
                {
                tmp0 = Strings.InStr (1, Conversions.ToString (strAuthorx), "0");
                if (tmp0 > 0)
                    strAuthorx = Strings.Left (Conversions.ToString (strAuthorx), tmp0 - 1) + Strings.Mid (Conversions.ToString (strAuthorx), tmp0 + 1);
                tmp1 = Strings.InStr (1, Conversions.ToString (strAuthorx), "1");
                if (tmp1 > 0)
                    strAuthorx = Strings.Left (Conversions.ToString (strAuthorx), tmp1 - 1) + Strings.Mid (Conversions.ToString (strAuthorx), tmp1 + 1);
                tmp2 = Strings.InStr (1, Conversions.ToString (strAuthorx), "2");
                if (tmp2 > 0)
                    strAuthorx = Strings.Left (Conversions.ToString (strAuthorx), tmp2 - 1) + Strings.Mid (Conversions.ToString (strAuthorx), tmp2 + 1);
                tmp3 = Strings.InStr (1, Conversions.ToString (strAuthorx), "3");
                if (tmp3 > 0)
                    strAuthorx = Strings.Left (Conversions.ToString (strAuthorx), tmp3 - 1) + Strings.Mid (Conversions.ToString (strAuthorx), tmp3 + 1);
                tmp4 = Strings.InStr (1, Conversions.ToString (strAuthorx), "4");
                if (tmp4 > 0)
                    strAuthorx = Strings.Left (Conversions.ToString (strAuthorx), tmp4 - 1) + Strings.Mid (Conversions.ToString (strAuthorx), tmp4 + 1);
                tmp5 = Strings.InStr (1, Conversions.ToString (strAuthorx), "5");
                if (tmp5 > 0)
                    strAuthorx = Strings.Left (Conversions.ToString (strAuthorx), tmp5 - 1) + Strings.Mid (Conversions.ToString (strAuthorx), tmp5 + 1);
                tmpx1 = Strings.InStr (1, Conversions.ToString (strAuthorx), ",");
                if (tmpx1 > 0)
                    strAuthorx = Strings.Left (Conversions.ToString (strAuthorx), tmpx1 - 1) + " " + Strings.Mid (Conversions.ToString (strAuthorx), tmpx1 + 1);
                tmpx2 = Strings.InStr (1, Conversions.ToString (strAuthorx), "*");
                if (tmpx2 > 0)
                    strAuthorx = Strings.Left (Conversions.ToString (strAuthorx), tmpx2 - 1) + " " + Strings.Mid (Conversions.ToString (strAuthorx), tmpx2 + 1);
                }
            eLibParseAuthorLineRet = Strings.Trim (Conversions.ToString (strAuthorx));
            return eLibParseAuthorLineRet;
            }
        public string eLib_BadCharRemover (string strP)
            {
            string eLib_BadCharRemoverRet = default;
            int tmpPos = 0;
            tmpPos = Strings.InStr (1, strP, ":");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "/");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, @"\");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "=");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "*");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "?");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "<");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "<");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "!");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "@");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "#");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "$");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "%");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "^");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "&");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "+");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "=");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "'");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, ";");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            tmpPos = Strings.InStr (1, strP, "’");
            if (tmpPos != 0)
                strP = Strings.Left (strP, tmpPos - 1) + "-" + Strings.Mid (strP, tmpPos + 1);
            eLib_BadCharRemoverRet = strP;
            return eLib_BadCharRemoverRet;
            }
        //MENU_1 -IMPORT(Move)
        private void Menu1_Move_Click (object sender, EventArgs e)
            {
            //Move the Ref (and Links) to eLib
            MoveThisRef ();
            }
        private void MoveThisRef ()
            {
            //in module: public string DestinationFolder = ""
            if ((Ref.ImportStatus == 0) || (Strings.Left (Strings.Trim (txtTitle.Text), 2) == "//"))
                {
                Menu1_SelectRef_Click (null, null);
                return;
                }
            string strTitle = Strings.Trim (txtTitle.Text);
            int intRefType = 0;
            if (lblRefType.Text == "<    Paper    >")
                intRefType = 1;
            if (lblRefType.Text == "<    Book    >")
                intRefType = 2;
            if (lblRefType.Text == "<    Manual    >")
                intRefType = 3;
            if (lblRefType.Text == "<    Lecture    >")
                intRefType = 4;
            switch (intRefType)
                {
                case 1:
                        {
                        if (lblDestinationFolder.Text == "-")
                            eLibFile.DestinationFolder = User.FolderPapers;
                        else
                            eLibFile.DestinationFolder = lblDestinationFolder.Text;
                        break;
                        }
                case 2:
                        {
                        if (lblDestinationFolder.Text == "-")
                            eLibFile.DestinationFolder = User.FolderBooks;
                        else
                            eLibFile.DestinationFolder = lblDestinationFolder.Text;
                        break;
                        }
                case 3:
                        {
                        if (lblDestinationFolder.Text == "-")
                            eLibFile.DestinationFolder = User.FolderManuals;
                        else
                            eLibFile.DestinationFolder = lblDestinationFolder.Text;
                        break;
                        }
                case 4:
                        {
                        if (lblDestinationFolder.Text == "-")
                            eLibFile.DestinationFolder = User.FolderLectures;
                        else
                            eLibFile.DestinationFolder = lblDestinationFolder.Text;
                        break;
                        }
                default:
                        {
                        return;
                        }
                }
            eLibFile.Extension = MyFile.Extension;
            //ask destination folder
            if (lblAskFolder.BackColor == Color.Gold)
                {
                FolderBrowserDialog1.SelectedPath = eLibFile.DestinationFolder + @"\";  //or Environment.SpecialFolder.Desktop
                if (FolderBrowserDialog1.ShowDialog () == DialogResult.OK)
                    {
                    eLibFile.DestinationFolder = FolderBrowserDialog1.SelectedPath;
                    }
                else
                    {
                    return;
                    }
                }
            //Now, MOVE to Destination
            try
                {
                My.MyProject.Computer.FileSystem.MoveFile (eLibFile.Filename, eLibFile.DestinationFolder + @"\" + strTitle + eLibFile.Extension, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                My.MyProject.Computer.Clipboard.SetText (strTitle);
                lblDestinationFolder.Text = eLibFile.DestinationFolder;

                //Add data to elib Tables
                bool boolIsPaper = Conversions.ToBoolean (0);
                bool boolIsBook = Conversions.ToBoolean (0);
                bool boolIsManual = Conversions.ToBoolean (0);
                bool boolIsLecture = Conversions.ToBoolean (0);
                switch (intRefType)
                    {
                    case 1:
                            {
                            boolIsPaper = Conversions.ToBoolean (1);
                            break;
                            }
                    case 2:
                            {
                            boolIsBook = Conversions.ToBoolean (1);
                            break;
                            }
                    case 3:
                            {
                            boolIsManual = Conversions.ToBoolean (1);
                            break;
                            }
                    case 4:
                            {
                            boolIsLecture = Conversions.ToBoolean (1);
                            break;
                            }

                    default:
                            {
                            return;
                            }
                    }
                /* Register: ImportStatus
                 * bit1: 0:new 1:edit
                 * bit2: 0:requested from frmImport 1:requested from frmAssign
                 * bit3: 0:nolink 1:haslink
                 * bit4: 0:select1ref 1:ready2move
                 */
                //check bit1:
                switch (Ref.ImportStatus & 1)
                    {
                    case 0: //importRef newRefDoc  /task: add title to tblPapers
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.strSQL = "INSERT INTO Papers (PaperName, IsPaper, IsBook, IsManual, IsLecture) VALUES (@papername, @ispaper, @isbook, @ismanual, @islecture)";
                                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue ("@papername", strTitle);
                                cmd.Parameters.AddWithValue ("@ispaper", boolIsPaper.ToString ());
                                cmd.Parameters.AddWithValue ("@isbook", boolIsBook.ToString ());
                                cmd.Parameters.AddWithValue ("@ismanual", boolIsManual.ToString ());
                                cmd.Parameters.AddWithValue ("@islecture", boolIsLecture.ToString ());
                                try
                                    {
                                    int i = cmd.ExecuteNonQuery ();
                                    }
                                catch (Exception ex)
                                    {
                                    MessageBox.Show ("Error creating new paper \r\n" + ex.ToString (), "eLib", MessageBoxButtons.OK);
                                    }
                                CnnSS.Close ();
                                }
                            break;
                            }
                    case 1: //Edit Ref Mode: Update Title in tblPapers
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.strSQL = "UPDATE Papers SET PaperName=@papername, IsPaper=@ispaper, IsBook=@isbook, IsManual=@ismanual, IsLecture=@islecture WHERE ID=@id;";
                                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue ("@papername", strTitle);
                                cmd.Parameters.AddWithValue ("@ispaper", boolIsPaper.ToString ());
                                cmd.Parameters.AddWithValue ("@isbook", boolIsBook.ToString ());
                                cmd.Parameters.AddWithValue ("@ismanual", boolIsManual.ToString ());
                                cmd.Parameters.AddWithValue ("@islecture", boolIsLecture.ToString ());
                                cmd.Parameters.AddWithValue ("@id", Ref.Id.ToString ());
                                int i = cmd.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            break;
                            }
                    }
                //Add strPath (of new Ref) into tblPaths
                Instance.Path = eLibFile.DestinationFolder + @"\" + strTitle + eLibFile.Extension;
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "INSERT INTO Paths (FilePath, StorageSN) VALUES (@filepath, @storagesn)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@filepath", Instance.Path);
                    cmd.Parameters.AddWithValue ("@storagesn", Client.DriveSN);
                    try
                        {
                        int i = cmd.ExecuteNonQuery ();
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show ("Error creating new paper's Path \r\n" + ex.ToString (), "eLib", MessageBoxButtons.OK);
                        }
                    CnnSS.Close ();
                    }
                //check bit1:
                switch (Ref.ImportStatus & 1)
                    {
                    case 0: //Import Ref Mode
                            {
                            //Find ID of the new Ref in tblPapers (Import Mode Only)
                            Db.DS.Tables ["tblRefs"].Clear ();
                            string Fltr = "PaperName='" + strTitle + "'";
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture FROM Links RIGHT JOIN Papers ON Links.Paper_ID = Papers.ID  WHERE (" + Fltr + ") ORDER BY Papers.ID DESC;", CnnSS);
                                Db.DASS.Fill (Db.DS, "tblRefs");
                                CnnSS.Close ();
                                }
                            int idx = Conversions.ToInteger (Db.DS.Tables ["tblRefs"].Rows [0] [0]);
                            int idy = 0;

                            for (int k = 0, loopTo = Db.DS.Tables ["tblProd_tmp2"].Rows.Count - 1; k <= loopTo; k++)
                                {
                                idy = Conversions.ToInteger (Db.DS.Tables ["tblProd_tmp2"].Rows [k] [0]);
                                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                    {
                                    CnnSS.Open ();
                                    Db.strSQL = "INSERT INTO Links (Paper_ID, SubProject_ID) VALUES (@paperid, @SubProjectid)";
                                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Parameters.AddWithValue ("@paperid", idx);
                                    cmd.Parameters.AddWithValue ("@SubProjectid", idy);
                                    try
                                        {
                                        int i = cmd.ExecuteNonQuery ();
                                        }
                                    catch (Exception ex)
                                        {
                                        MessageBox.Show ("Error creating new paper's Path \r\n" + ex.ToString (), "eLib", MessageBoxButtons.OK);
                                        }
                                    CnnSS.Close ();
                                    }
                                }

                            break;
                            }
                    case 1: //Edit Ref Mode
                            {
                            //Do nothing, keep existing Assignments if any
                            break;
                            }
                    }
                //Finish Up
                Ref.ImportStatus = (Ref.ImportStatus & 7); //(0000 ???? & 0000 0111): set bit4 off: select another Ref
                /* Register: ImportStatus
                 * bit1: 0:new 1:edit
                 * bit2: 0:requested from frmImport 1:requested from frmAssign
                 * bit3: 0:nolink 1:haslink
                 * bit4: 0:select1ref 1:ready2move
                 */
                switch (Ref.ImportStatus & 1)
                    {
                    case 0: //ImportRefMode
                            {
                            txtTitle.Text = "Imported: " + strTitle + " \r\n //assigned to: " + Db.DS.Tables ["tblProd_tmp2"].Rows.Count.ToString () + " item(s)\r\n --";
                            lblPath.Visible = true;
                            lblPath.Text = "Drop a Ref  ^";
                            lblExt.Visible = false;
                            lblSize.Visible = false;
                            lblCreated.Visible = false;
                            lblModified.Visible = false;
                            break;
                            }
                    case 1: //editRefMode or createNewRefMode
                            {
                            Menu_Exit ();
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void Menu1_Open_Click (object sender, EventArgs e)
            {
            long G = Interaction.Shell ("RUNDLL32.EXE URL.DLL,FileProtocolHandler " + eLibFile.Filename, Constants.vbNormalFocus);
            }
        private void Menu1_Paste_Click (object sender, EventArgs e)
            {
            string strx = "";
            int intCR1 = 0;
            int intCR2 = 0;
            int intCR3 = 0;
            int intCR4 = 0;
            int intCR5 = 0;
            int intSpc1 = 0;
            int intNLn = 0;
            string strAuthor = "";
            string strP = "";
            txtTitle.Text = My.MyProject.Computer.Clipboard.GetText (); // Paste to textbox
            txtTitle.SelectionStart = 0;
            txtTitle.Focus ();
            strx = txtTitle.Text;
            //CR: Cariage Return | NLn: number of lines
            intCR1 = 0;
            intCR2 = 0;
            intCR3 = 0;
            intCR4 = 0;
            intCR5 = 0;
            intNLn = 0;
            intSpc1 = Strings.InStr (1, strx, " ");
            //Count Number of Lines in string_Title
            intCR1 = Strings.InStr (1, strx, Conversions.ToString ('\r'));
            if (intCR1 > 1) // there are 2 lines
                {
                intNLn = 2;
                }
            else
                {
                intNLn = 1;
                goto lblPARSE;
                }
            intCR2 = Strings.InStr (intCR1 + 2, strx, Conversions.ToString ('\r'));
            if (intCR2 > 1) // oh! there are 3 lines
                {
                intNLn = 3;
                }
            else
                {
                goto lblPARSE;
                }
            intCR3 = Strings.InStr (intCR2 + 2, strx, Conversions.ToString ('\r'));
            if (intCR3 > 1) // oh! there are 4 lines
                {
                intNLn = 4;
                }
            else
                {
                goto lblPARSE;
                }
            intCR4 = Strings.InStr (intCR3 + 2, strx, Conversions.ToString ('\r'));
            if (intCR4 > 1) // wow! there are 5 lines
                {
                intNLn = 5;
                }
            else
                {
                goto lblPARSE;
                }
            intCR5 = Strings.InStr (intCR4 + 2, strx, Conversions.ToString ('\r'));
            if (intCR5 > 1) // ok! there are 6 lines
                {
                intNLn = 6;
                }

        lblPARSE:
            //Concatenate separate lines into one line!
            switch (intNLn)
                {
                case 1: // 1 Lines, 0 CRs :Do Nothing
                        {
                        break;
                        }
                case 2: // 2 Lines, 1 CRs
                        {
                        strAuthor = Strings.Mid (strx, intCR1 + 2, Strings.Len (strx) - intCR1);
                        strAuthor = eLibParseAuthorLine (strAuthor);
                        strP = Strings.Left (strx, intCR1 - 1);
                        break;
                        }
                case 3: // 3 Lines, 2 CRs
                        {
                        strAuthor = Strings.Mid (strx, intCR2 + 2, Strings.Len (strx) - intCR2);
                        strAuthor = eLibParseAuthorLine (strAuthor);
                        strP = Strings.Left (strx, intCR1 - 1) + " ";
                        strP = strP + Strings.Mid (strx, intCR1 + 2, intCR2 - intCR1 - 2);
                        break;
                        }
                case 4: // 4 Lines, 3 CRs
                        {
                        strAuthor = Strings.Mid (strx, intCR3 + 2, Strings.Len (strx) - intCR3);
                        strAuthor = eLibParseAuthorLine (strAuthor);
                        strP = Strings.Left (strx, intCR1 - 1) + " ";
                        strP = strP + Strings.Mid (strx, intCR1 + 2, intCR2 - intCR1 - 2) + " ";
                        strP = strP + Strings.Mid (strx, intCR2 + 2, intCR3 - intCR2 - 2);
                        break;
                        }
                case 5: // 5 Lines, 4 CRs
                        {
                        strAuthor = Strings.Mid (strx, intCR4 + 2, Strings.Len (strx) - intCR4);
                        strAuthor = eLibParseAuthorLine (strAuthor);
                        strP = Strings.Left (strx, intCR1 - 1) + " ";
                        strP = strP + Strings.Mid (strx, intCR1 + 2, intCR2 - intCR1 - 2) + " ";
                        strP = strP + Strings.Mid (strx, intCR2 + 2, intCR3 - intCR2 - 2) + " ";
                        strP = strP + Strings.Mid (strx, intCR3 + 2, intCR4 - intCR3 - 2);
                        break;
                        }
                case 6: // 6 Lines, 5 CRs
                        {
                        strAuthor = Strings.Mid (strx, intCR5 + 2, Strings.Len (strx) - intCR5);
                        strAuthor = eLibParseAuthorLine (strAuthor);
                        strP = Strings.Left (strx, intSpc1 - 1) + " ";
                        strP = strP + Strings.Mid (strx, intCR1 + 2, intCR2 - intCR1 - 2) + " ";
                        strP = strP + Strings.Mid (strx, intCR2 + 2, intCR3 - intCR2 - 2) + " ";
                        strP = strP + Strings.Mid (strx, intCR3 + 2, intCR4 - intCR3 - 2) + " ";
                        strP = strP + Strings.Mid (strx, intCR4 + 2, intCR5 - intCR4 - 2);
                        break;
                        }

                default:
                        {
                        return; // do nothing
                        }
                }
            //Remove Bad chars
            strP = eLib_BadCharRemover (strP);
            if (Conversion.Val (strP) < 1000d) // Sin Yr
                {
                strP = "0000 " + strAuthor + "- " + strP;
                }
            else // Con Yr!
                {
                intSpc1 = Strings.InStr (1, strP, " ");
                if (Strings.Len (Strings.Trim (Conversion.Str (Conversion.Val (strP)))) == 4 & (intSpc1 < 1 | intSpc1 > 5)) // Yr is attached to title
                    {
                    strP = Strings.Left (strP, 4) + " " + strAuthor + "- " + Strings.Mid (strP, 5);
                    }
                else // Separate Yr is available
                    {
                    strP = Strings.Left (strP, 5) + strAuthor + "- " + Strings.Mid (strP, 6);
                    }
                }
            txtTitle.Text = strP;
            txtTitle.SelectionStart = 0;
            txtTitle.SelectionLength = 4;
            }
        private void Menu1_SentenceCase_Click (object sender, EventArgs e)
            {
            try
                {
                string strRef = txtTitle.Text;
                if (!String.IsNullOrEmpty (strRef))
                    {
                    int i = strRef.IndexOf ("- ");
                    if (i != -1)
                        {
                        txtTitle.Text = strRef.Substring (0, 5) + strRef.Substring (5, 1).ToUpper () + strRef.Substring (6, i - 4).ToLower () + strRef.Substring (i + 2, 1).ToUpper () + strRef.Substring (i + 3, strRef.Length - i - 3).ToLower ();
                        }
                    else
                        {
                        txtTitle.Text = strRef.Substring (0, 5) + strRef.Substring (5, 1).ToUpper () + strRef.Substring (6, strRef.Length - 6).ToLower ();
                        }
                    }
                //select year
                txtTitle.SelectionStart = 0;
                txtTitle.SelectionLength = 4;
                }
            catch
                {
                //
                }
            }
        //MENU_Exit
        private void Menu_Exit ()
            {
            Dispose ();
            /*switch (Client.Interface)
                {
                case 1:
                        {
                        //old prof interface
                        //---My.MyProject.Forms.frmAssign.ShowDialog ();
                        Form Assign1 = new frmAssign ();
                        Assign1.ShowDialog ();
                        break;
                        }
                case 2:
                        {
                        //new simpler interface
                        Form Assign2 = new frmAssign2 ();
                        Assign2.ShowDialog ();
                        break;
                        }
                }
            */
            }
        private void Menu1_Exit_Click (object sender, EventArgs e)
            {
            Menu_Exit ();
            }
        private void frmImportRefs_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (e.CloseReason == CloseReason.UserClosing)
                {
                e.Cancel = true;
                //MessageBox.Show (To exit, use menu!, "eLib");
                }
            }

        private void lblPath_Click (object sender, EventArgs e)
            {
            ContextMenuStrip1.Show (Control.MousePosition);
            }
        }
    }