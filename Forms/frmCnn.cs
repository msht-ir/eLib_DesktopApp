using eLib.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmCNN
        {
        private int entryStatus = 0;
        string strConnectionName = "";
        string strConnectionAddress = "";
        string strConnectionInitialCatalog = "";
        string strConnectionUsername = "";
        string strConnectionPassword = "";
        string strDriveSerialNumber = "";
        public frmCNN ()
            {
            InitializeComponent ();
            }
        private void frmCNN_Load (object sender, EventArgs e)
            {
            Width = 555;
            Height = 244;
            lbl_status.Text = "eLib";
            string ServerName = Environment.MachineName;
            var RegistryView = Microsoft.Win32.RegistryView.Registry64;
            //clean hdd 
            Client.DeleteHtmlFiles ();
            //get SN -> ClientSN        
            Client.GetClientSN ();
            //get instance info            
            using (var hklm = RegistryKey.OpenBaseKey (RegistryHive.LocalMachine, RegistryView))
                {
                try
                    {
                    var instanceKey = hklm.OpenSubKey (@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                    Db.InstanceNumber = 0;
                    foreach (string instanceName in instanceKey.GetValueNames ())
                        {
                        Db.InstanceNumber = Db.InstanceNumber + 1;
                        Db.ServerName = ServerName;
                        Db.InstanceName = instanceName;
                        break;
                        }
                    }
                catch (Exception ex)
                    {
                    //MessageBox.Shoe(ex.ToString())
                    }
                }
            if (string.IsNullOrEmpty (Db.InstanceName))
                {
                Db.InstanceName = "SQLEXPRESS";
                }
            PasswordTextBox.Visible = false;
            Db.DS.Tables ["tblConnections"].Clear ();
            GridCNN.DataSource = Db.DS.Tables ["tblConnections"];
            FileSystem.FileClose ();
            CnnFileRead ();
            }
        //GridCNN
        private void GridCNN_Click (object sender, EventArgs e)
            {
            PasswordTextBox.Text = "";
            PasswordTextBox.Visible = false;
            }
        private void GridCNN_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13: //enter
                case 39: //right arrow
                        {
                        Menu_Login_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        private void GridCNN_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            Menu_Login_Click (sender, e);
            }
        private void GridCNN_DragEnter (object sender, DragEventArgs e)
            {
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void GridCNN_DragDrop (object sender, DragEventArgs e)
            {
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            eLibFile.strFilex = strFiles [0];
            FileInfo MyFile = new FileInfo (strFiles [0]);
            //if (MyFile.Extension.ToLower () == ".txt") //if (MyFile.Name.ToLower () == "elibcnn")
            FileSystem.FileClose ();
            FileSystem.FileOpen (1, eLibFile.strFilex, OpenMode.Input);
            //check type of cnn file
            while (!FileSystem.EOF (1))
                {
                string strLine = FileSystem.LineInput (1);
                if (strLine == ("eLibcnn"))
                    {
                    //plain file: encript it, then move encripted file to the app folder (keep the plain file on desktop)
                    FileSystem.FileClose ();
                    FileSystem.FileOpen (2, eLibFile.strFilex, OpenMode.Input);
                    FileSystem.FileOpen (3, eLibFile.strFilex + "_encr", OpenMode.Output);
                    string strCodedLine = "";
                    while (!FileSystem.EOF (2))
                        {
                        strLine = FileSystem.LineInput (2);
                        if (strLine == ("eLibcnn"))
                            {
                            strCodedLine = Security.Encode ("eLibcnn");
                            FileSystem.PrintLine (3, strCodedLine);
                            Application.DoEvents ();
                            strLine = FileSystem.LineInput (2);
                            strCodedLine = Security.Encode (strLine);
                            FileSystem.PrintLine (3, strCodedLine); //1 cnn title
                            Application.DoEvents ();
                            strLine = FileSystem.LineInput (2);
                            strCodedLine = Security.Encode (strLine);
                            FileSystem.PrintLine (3, strCodedLine); //2 data source
                            Application.DoEvents ();
                            strLine = FileSystem.LineInput (2);
                            strCodedLine = Security.Encode (strLine);
                            FileSystem.PrintLine (3, strCodedLine); //3 Initial Catalog
                            Application.DoEvents ();
                            strLine = FileSystem.LineInput (2);
                            strCodedLine = Security.Encode (strLine);
                            FileSystem.PrintLine (3, strCodedLine); //4 User ID
                            Application.DoEvents ();
                            strLine = FileSystem.LineInput (2);
                            strCodedLine = Security.Encode (strLine);
                            FileSystem.PrintLine (3, strCodedLine); //5 Password
                            //strLine = Client.DriveSN;             //6 SN
                            Application.DoEvents ();
                            strLine = FileSystem.LineInput (2);
                            strCodedLine = Security.Encode (strLine);
                            FileSystem.PrintLine (3, strCodedLine);
                            Application.DoEvents ();
                            //FileSystem.PrintLine (3, ""); //empty line between cnnStrings
                            }
                        Application.DoEvents ();
                        }
                    FileSystem.FileClose ();
                    My.MyProject.Computer.FileSystem.MoveFile (eLibFile.strFilex + "_encr", Application.StartupPath + "elibcnn", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                    CnnFileRead ();
                    e.Effect = DragDropEffects.None;
                    return;
                    }
                else if (Security.Decode (strLine) == ("eLibcnn"))
                    {
                    //encripted file: directly move it to the app folder
                    FileSystem.FileClose ();
                    My.MyProject.Computer.FileSystem.MoveFile (eLibFile.strFilex, Application.StartupPath + "elibcnn", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                    CnnFileRead ();
                    e.Effect = DragDropEffects.None;
                    return;
                    }
                }
            FileSystem.FileClose ();
            }
        //TextBox
        private void PasswordTextBox_TextChanged (object sender, EventArgs e)
            {
            if ((string.IsNullOrEmpty (Strings.Trim (PasswordTextBox.Text))) || (Strings.Trim (PasswordTextBox.Text) == "Login:"))
                {
                PasswordTextBox.Text = "Login: Username Password";
                PasswordTextBox.SelectionStart = 7;
                PasswordTextBox.SelectionLength = PasswordTextBox.TextLength - 7;
                PasswordTextBox.PasswordChar = Conversions.ToChar ("");
                return;
                }
            //SIGNUP
            else if ((Strings.Trim (PasswordTextBox.Text.ToLower ()) == "login: -signup") || (Strings.Trim (PasswordTextBox.Text.ToLower ()) == "login: -new"))
                {
                PasswordTextBox.Text = "";
                SignupNewUser ();
                Menu_Login_Click (null, null);
                return;
                }
            //EXIT
            else if (Strings.Trim (PasswordTextBox.Text.ToLower ()) == "-quit" || Strings.Trim (PasswordTextBox.Text.ToLower ()) == "login: -quit" || Strings.Trim (PasswordTextBox.Text.ToLower ()) == "-exit" || Strings.Trim (PasswordTextBox.Text.ToLower ()) == "login: -exit")
                {
                entryStatus = 1;
                PasswordTextBox.Text = "Exit?  Yes/No ";
                PasswordTextBox.SelectionStart = 6; //count from 0
                PasswordTextBox.SelectionLength = 8;
                }
            else if (Strings.Trim (PasswordTextBox.Text.ToLower ()) == "exit? y")
                {
                Menu_Exit_Click (null, null);
                }
            else if (Strings.Trim (PasswordTextBox.Text.ToLower ()) == "exit? n")
                {
                PasswordTextBox.Text = "";
                return;
                }
            //ABOUT
            else if (Strings.Trim (PasswordTextBox.Text.ToLower ()) == "login: -?")
                {
                PasswordTextBox.Text = "visit  http://msht.ir    OR   call: +989133112733";
                PasswordTextBox.SelectionStart = 0;
                PasswordTextBox.SelectionLength = PasswordTextBox.TextLength;
                return;
                }
            //RESET
            else if (Strings.Trim (PasswordTextBox.Text.ToLower ()) == "-libs" || Strings.Trim (PasswordTextBox.Text.ToLower ()) == "login: -libs")
                {
                entryStatus = 0;
                PasswordTextBox.Text = "";
                //------Menu_ResetCnns_Click (null, null);
                }
            //INFO,HELP
            else if (Strings.Trim (PasswordTextBox.Text.ToLower ()) == "-info" || Strings.Trim (PasswordTextBox.Text.ToLower ()) == "-about")
                {
                entryStatus = 0; //idle
                My.MyProject.Forms.frmAbout.ShowDialog ();
                PasswordTextBox.Text = "";
                return;
                }
            else if (Strings.Trim (PasswordTextBox.Text.ToLower ()) == "-help" || Strings.Trim (PasswordTextBox.Text.ToLower ()) == "-guide")
                {
                entryStatus = 0; //idle
                Client.OpenURL ("http://www.msht.ir");
                PasswordTextBox.Text = "";
                return;
                }
            //LOGIN
            else if ((Strings.Mid (PasswordTextBox.Text, 1, 7) == "Login: ") & (PasswordTextBox.Text != "Login: Username Password"))
                {
                PasswordTextBox.PasswordChar = Conversions.ToChar ("");
                User.Pass = Strings.LTrim (Strings.Mid (PasswordTextBox.Text, 8));
                if (Strings.InStr (1, User.Pass, " ") == 0)
                    {
                    entryStatus = 4; //user?
                    return;
                    }
                else //OK, text format is USER^PASS
                    {
                    if ((Strings.Right (PasswordTextBox.Text, 1) == " ") & !(Strings.InStr (8, PasswordTextBox.Text, " ") < PasswordTextBox.TextLength))
                        {
                        PasswordTextBox.Text = PasswordTextBox.Text + "Password";
                        PasswordTextBox.SelectionStart = (PasswordTextBox.TextLength - 8);
                        PasswordTextBox.SelectionLength = 8;
                        }
                    else //there is some chars for pass
                        {
                        entryStatus = 5; //pass?
                        if (Strings.Right (PasswordTextBox.Text, 9) != " Password")
                            PasswordTextBox.PasswordChar = '-';
                        try
                            {
                            //Extract usr/pwd & try login
                            int intSpc = Strings.InStr (1, User.Pass, " ");
                            User.Name = Strings.Trim (Strings.Mid (User.Pass, 1, intSpc - 1));
                            User.Pass = Strings.Trim (Strings.Mid (User.Pass, intSpc + 1, Strings.Len (User.Pass) - intSpc));
                            //try login
                            Login (User.Name, User.Pass);
                            }
                        catch
                            {
                            }
                        }
                    }
                }
            }
        private void PasswordTextBox_KeyDown (object sender, KeyEventArgs e)
            {
            switch ((int) e.KeyCode)
                {
                case 13: //enter
                        {
                        if (entryStatus == 4)
                            {
                            PasswordTextBox.Text = PasswordTextBox.Text + " ";
                            e.SuppressKeyPress = true;
                            return;
                            }
                        break;
                        }
                case 27: //escape
                        {
                        switch (entryStatus)
                            {
                            case (5):
                                    {
                                    PasswordTextBox.Text = Strings.Left (PasswordTextBox.Text, Strings.InStr (8, PasswordTextBox.Text, " ") - 1);
                                    PasswordTextBox.SelectionStart = (PasswordTextBox.TextLength);
                                    PasswordTextBox.PasswordChar = Conversions.ToChar ("");
                                    entryStatus = 4;
                                    e.SuppressKeyPress = true;
                                    break;
                                    }
                            case (0):
                                    {
                                    if (PasswordTextBox.Text == "Login: Username Password")
                                        PasswordTextBox.Text = "quit";
                                    e.SuppressKeyPress = true;
                                    break;
                                    }
                            case (1):
                                PasswordTextBox.Text = "";
                                e.SuppressKeyPress = true;
                                break;
                            default:
                                    {
                                    entryStatus = 0;
                                    PasswordTextBox.Text = "";
                                    e.SuppressKeyPress = true;
                                    break;
                                    }
                            }
                        break;
                        }
                case 38: //up
                case 40: //down
                        {
                        GridCNN.Focus ();
                        GridCNN_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                }
            }
        //Methods
        private void CnnFileRead ()
            {
            GridCNN.DataSource = null;
            Db.DS.Tables ["tblConnections"].Clear ();
            //1:LOCAL DBs
            if (!File.Exists (Client.eLibDataPath + "eLibA.mdf"))
                {
                Db.CopyAndAttachLocalDB ("eLibA");
                }
            if (!File.Exists (Client.eLibDataPath + "eLibB.mdf"))
                {
                Db.CopyAndAttachLocalDB ("eLibB");
                }
            Menu_UseLocalDbs_Click (null, null);
            //2:READ eLibcnn file
            try
                {
                FileSystem.FileClose ();
                //if file eLibcnn exists...
                eLibFile.cnnFilename = Application.StartupPath + "eLibcnn";
                FileSystem.FileOpen (1, eLibFile.cnnFilename, OpenMode.Input);
                //FileSystem.FileOpen (2, eLibFile.cnnFilename + "_.txt", OpenMode.Output);
                //notice: eLibcnn is encripted
                string tmpxx = "";
                Db.DS.Tables ["tblSecurityCodes"].Clear ();
                Client.FeedSecurityTable ();
                while (!FileSystem.EOF (1))
                    {
                    string strLine = FileSystem.LineInput (1);
                    if (Security.Decode (strLine) == "eLibcnn")
                        {
                        tmpxx = Security.Decode (strLine) + "\n" + strLine + "\n\n";
                        strLine = FileSystem.LineInput (1);
                        strConnectionName = Security.Decode (strLine);              //1 decode: cnnName show in grid
                        tmpxx += Security.Decode (strLine) + "\n" + strLine + "\n\n";
                        strLine = FileSystem.LineInput (1);
                        strConnectionAddress = Security.Decode (strLine);           //2 decode: cnnAddr hidden
                        tmpxx += Security.Decode (strLine) + "\n" + strLine + "\n\n";
                        strLine = FileSystem.LineInput (1);
                        strConnectionInitialCatalog = Security.Decode (strLine);    //3 decode: cnnInitcat
                        tmpxx += Security.Decode (strLine) + "\n" + strLine + "\n\n";
                        strLine = FileSystem.LineInput (1);
                        strConnectionUsername = Security.Decode (strLine);          //4 decode: cnnUser hidden
                        tmpxx += Security.Decode (strLine) + "\n" + strLine + "\n\n";
                        strLine = FileSystem.LineInput (1);
                        strConnectionPassword = Security.Decode (strLine);          //5 decode: cnnPass hidden
                        tmpxx += Security.Decode (strLine) + "\n" + strLine + "\n\n";
                        strLine = FileSystem.LineInput (1);
                        strDriveSerialNumber = Security.Decode (strLine);           //6 decode: clientSN hidden
                        tmpxx += Security.Decode (strLine) + "\n" + strLine + "\n\n";
                        Db.DS.Tables ["tblConnections"].Rows.Add (strConnectionName, strConnectionAddress, strConnectionInitialCatalog, strConnectionUsername, strConnectionPassword, strDriveSerialNumber);
                        //FileSystem.WriteLine (2, strConnectionName);
                        //FileSystem.WriteLine (2, strConnectionAddress);
                        //FileSystem.WriteLine (2, strConnectionInitialCatalog);
                        //FileSystem.WriteLine (2, strConnectionUsername);
                        //FileSystem.WriteLine (2, strConnectionPassword);
                        //FileSystem.WriteLine (2, strDriveSerialNumber);
                        }
                    }
                FileSystem.FileClose ();
                GridCNN.DataSource = Db.DS.Tables ["tblConnections"];
                FormatGridCnn ();
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                FileSystem.FileClose ();
                }
            }
        private void FormatGridCnn ()
            {
            GridCNN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //GridCNN.Columns [0].Width = 40;
            //GridCNN.Columns [1].Width = 40;
            //GridCNN.Columns [2].Width = 80;
            //GridCNN.Columns [3].Width = 120;
            //GridCNN.Columns [4].Width = 120;
            //GridCNN.Columns [5].Width = 30;
            GridCNN.Columns [0].Width = 500;         // cnn name
            GridCNN.Columns [1].Visible = false;     // cnn address
            GridCNN.Columns [2].Visible = false;     // cnn initcat
            GridCNN.Columns [3].Visible = false;     // cnn usr
            GridCNN.Columns [4].Visible = false;     // cnn pwd
            GridCNN.Columns [5].Visible = false;     // hdd sn
            //Disable sort for column_haeders
            for (int i = 0, loopTo = GridCNN.Columns.Count - 1; i <= loopTo; i++)
                {
                GridCNN.Columns [i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            GridCNN.Refresh ();
            }
        private void Login (string strUser, string strPass)
            {
            /* this method cannot be static, because it modifies the passwordtextbox 
               class User:  0:ID   1:UsrName  2:UsrPass                             
               search User/Pass in DB
            */
            if (strPass == "mshtaccesson")
                {
                User.Id = 0;
                User.Type = "Admin";
                User.Name = "Admin";
                User.Accs = 0xFF;
                StartAssignForm ();
                }
            else if ((strUser == "admin") & (strPass == User.AdminPass))
                {
                User.Id = 0;
                User.Type = "Admin";
                User.Name = "Admin";
                User.Accs = 0xFF;
                StartAssignForm ();
                }
            else
                {
                for (int i = 0; i <= (Db.DS.Tables ["tblUsrs"].Rows.Count - 1); i++)
                    {
                    if ((Db.DS.Tables ["tblUsrs"].Rows [i] [1].ToString () == strUser) & (Db.DS.Tables ["tblUsrs"].Rows [i] [2].ToString () == strPass))
                        {
                        if ((Convert.ToBoolean (Db.DS.Tables ["tblUsrs"].Rows [i] [3].ToString ())) == false)
                            {
                            //an inactive user
                            PasswordTextBox.Text = " user account is inactive ";
                            PasswordTextBox.SelectionStart = 0;
                            PasswordTextBox.SelectionLength = PasswordTextBox.TextLength;
                            PasswordTextBox.PasswordChar = Conversions.ToChar ("");
                            break;
                            }
                        else
                            {
                            //user is active
                            User.Type = "User";
                            User.Id = Conversions.ToInteger (Db.DS.Tables ["tblusrs"].Rows [i] [0]);
                            User.Name = Conversions.ToString (Db.DS.Tables ["tblusrs"].Rows [i] [1]);
                            User.Pass = Conversions.ToString (Db.DS.Tables ["tblusrs"].Rows [i] [2]);
                            Client.SavedSN = Conversions.ToString (Db.DS.Tables ["tblusrs"].Rows [i] [4]);
                            Client.Interface = Convert.ToInt32 (Db.DS.Tables ["tblusrs"].Rows [i] [13]);
                            User.Accs = Conversions.ToInteger (Db.DS.Tables ["tblusrs"].Rows [i] [5]);
                            User.FolderPapers = Convert.ToString (Db.DS.Tables ["tblUsrs"].Rows [i] [6]);
                            User.FolderBooks = Convert.ToString (Db.DS.Tables ["tblUsrs"].Rows [i] [7]);
                            User.FolderManuals = Convert.ToString (Db.DS.Tables ["tblUsrs"].Rows [i] [8]);
                            User.FolderLectures = Convert.ToString (Db.DS.Tables ["tblUsrs"].Rows [i] [9]);
                            User.FolderTemp = Convert.ToString (Db.DS.Tables ["tblUsrs"].Rows [i] [10]);
                            User.FolderSaveACopy = Convert.ToString (Db.DS.Tables ["tblUsrs"].Rows [i] [11]);
                            StartAssignForm ();
                            break;
                            }
                        }
                    }
                }
            }
        public void SetUserAccessControls (int Userid)
            {
            var UACregister = default (int);
            for (int r = 0; r <= 15; r++)
                {
                if (Conversions.ToBoolean (Operators.ConditionalCompareObjectEqual (Db.DS.Tables ["tblusrs"].Rows [Userid] [5 + r], true, false)))
                    UACregister = (int) ((long) UACregister | (long) Math.Round (Math.Pow (2d, r)));
                }
            User.Accs = UACregister;
            }
        public void StartAssignForm ()
            {
            try
                {
                User.ValidateFolders ();
                Dispose ();
                if (User.Type == "Admin")
                    {
                    Dispose ();
                    My.MyProject.Forms.frmUsers.ShowDialog ();
                    }
                else
                    {
                    switch (Client.Interface)
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
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        //MENU
        private void Menu_Login_Click (object sender, EventArgs e)
            {
            if (GridCNN.RowCount < 1)
                return;
            int r = GridCNN.SelectedCells [0].RowIndex;    // count from 0
            int c = GridCNN.SelectedCells [0].ColumnIndex; // count from 0
            if (r < 0 | c < 0)
                return;
            lbl_status.Text = "connecting...";
            Application.DoEvents ();
            switch (Strings.Trim (Conversions.ToString (GridCNN [0, r].Value)))
                {
                case "Local Server: Lib A":
                        {
                        Db.BackEnd = Strings.Trim (Conversions.ToString (GridCNN [1, r].Value)) + "; TrustServerCertificate=True;";
                        break;
                        }
                case "Local Server: Lib B":
                        {
                        Db.BackEnd = Strings.Trim (Conversions.ToString (GridCNN [1, r].Value)) + "; TrustServerCertificate=True;";
                        break;
                        }
                default:
                        {
                        Db.BackEnd = "Data Source=" + Strings.Trim (Conversions.ToString (GridCNN [1, r].Value)) + ";";
                        Db.BackEnd += "Initial Catalog=" + Strings.Trim (Conversions.ToString (GridCNN [2, r].Value)) + ";";
                        Db.BackEnd += "User ID=" + Strings.Trim (Conversions.ToString (GridCNN [3, r].Value)) + ";";
                        Db.BackEnd += "Password=" + Strings.Trim (Conversions.ToString (GridCNN [4, r].Value)) + "; TrustServerCertificate=True;";
                        break;
                        }
                }
            Db.Server2Connect = Strings.Trim (Conversions.ToString (GridCNN [0, r].Value));
            Db.ServerUid = Strings.Trim (Conversions.ToString (GridCNN [2, r].Value));      //in hidden col
            Db.ServerPwd = Strings.Trim (Conversions.ToString (GridCNN [3, r].Value));      //in hidden col
            //Db.ServerPwd = Strings.Trim (Conversions.ToString (GridCNN [3, r].Value));    //in hidden col
            if (string.IsNullOrEmpty (Db.Server2Connect))
                return;
            //MessageBox.Show (Db.BackEnd);
            int cnnResult = Db.ConnectTo (Db.BackEnd);
            try
                {
                switch (cnnResult)
                    {
                    case 0:
                            {
                            //did not connect to a database
                            //ReadCnnList ();
                            lbl_status.Text = "eLib";
                            return;
                            }
                    case 1:
                            {
                            //connection was successful
                            //get Admin Pass, Current Version, etc
                            Db.ReadSettingsAndUsers ();
                            Report.Caption = Db.Server2Connect; //for: frmAssign.text
                            PasswordTextBox.Visible = true;
                            //label1.Visible = false;
                            //Default
                            PasswordTextBox.Text = "Login: Username Password";
                            PasswordTextBox.SelectionStart = 7;
                            PasswordTextBox.SelectionLength = PasswordTextBox.TextLength - 7;
                            PasswordTextBox.PasswordChar = Conversions.ToChar ("");
                            PasswordTextBox.Focus ();
                            lbl_status.Text = "eLib";
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void SignupNewUser ()
            {
            Random rnd = new Random ();
            int rndx = rnd.Next (90000) + 10000;
            string strAnsw = Interaction.InputBox ("Enter this Code: " + rndx.ToString (), "Enter code below to Proceed", "");
            if (strAnsw == rndx.ToString ())
                {
                Db.AddNewUser ();
                }
            }
        private void Menu_DeleteCnn_Click (object sender, EventArgs e)
            {
            Db.DS.Tables ["tblConnections"].Clear ();
            PasswordTextBox.Text = "";
            PasswordTextBox.Visible = false;
            //delete eLibcnn file
            try
                {
                string strDirx = Application.StartupPath;
                foreach (var strFilex in Directory.GetFiles (strDirx, "eLibcnn"))
                    {
                    File.Delete (strFilex);
                    }
                }
            catch
                {
                }
            }
        private void Menu_Guide_Click (object sender, EventArgs e)
            {
            try
                {
                var pWeb = new Process ();
                pWeb.StartInfo.UseShellExecute = true;
                pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir";
                pWeb.Start ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error: Edge browser not initialized!\n\nvisit   http://www.msht.ir", "EDGE not found!", MessageBoxButtons.OK);
                }
            }
        //EXIT
        private void Menu_UseLocalDbs_Click (object sender, EventArgs e)
            {
            //copy and test eLibA
            if ((Db.CopyAndAttachLocalDB ("eLibA") == true) && (Db.CheckDBAttached2SqlServerExpress ("eLibA") == true))
                {
                Db.DS.Tables ["tblConnections"].Rows.Add ("Local Server: Lib A", @"Server=.\SQLEXPRESS; Initial Catalog=eLibA; Integrated Security = SSPI; TrustServerCertificate=True;", "", "", "", "");
                }
            //copy and test eLibB
            if ((Db.CopyAndAttachLocalDB ("eLibB") == true) && (Db.CheckDBAttached2SqlServerExpress ("eLibB") == true))
                {
                Db.DS.Tables ["tblConnections"].Rows.Add ("Local Server: Lib B", @"Server=.\SQLEXPRESS; Initial Catalog=eLibA; Integrated Security = SSPI; TrustServerCertificate=True;", "", "", "", "");
                }
            GridCNN.DataSource = null;
            GridCNN.DataSource = Db.DS.Tables ["tblConnections"];
            //format the grid
            FormatGridCnn ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Menu_Exit_Click (null, null);
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Db.CnnSS.Close ();
            Db.CnnSS.Dispose ();
            Db.CnnSS = null;
            Application.Exit ();
            Environment.Exit (0);
            }

        private void lbl_status_Click (object sender, EventArgs e)
            {
            MenuStripCNN.Show (Control.MousePosition);
            }
        }
    }