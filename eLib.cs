using ClosedXML.Excel;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Strings = Microsoft.VisualBasic.Strings;

namespace eLib
    {
    static class Module1
        {
        //TABLES
        //public static DataTable tblConnections = new DataTable ();
        //public static DataTable tblSettings = new DataTable ();
        //public static DataTable tblusrs = new DataTable ();
        //public static DataTable tblRefs = new DataTable ();
        //public static DataTable tblLinks = new DataTable ();
        //public static DataTable tblRefPaths = new DataTable ();
        //public static DataTable tblUserProject = new DataTable ();
        //public static DataTable tblProject = new DataTable ();
        //public static DataTable tblProj_tmp = new DataTable ();
        //public static DataTable tblProd_tmp = new DataTable ();
        //public static DataTable tblProd_tmp2 = new DataTable ();
        //public static DataTable tblAssignments = new DataTable ();
        //public static DataTable tblSubProjects = new DataTable ();
        //public static DataTable tblAssign_tmp = new DataTable (); // to Edit a Ref using frmImport 
        [STAThread]
        public static void Main ()
            {
            Application.EnableVisualStyles ();
            Client.CreateTables ();
            My.MyProject.Forms.frmCNN.ShowDialog ();
            }
        }
    static class Client
        {
        public static string Name;
        public static string SerialNumber;
        public static string BuildInfo = "Build 2025May05";
        public static string SavedSN = "";
        public static string DriveSN = "";
        public static string InferredSN = "";
        public static string StoredKey = "";
        public static string ActivationKey = "";
        public static int nRequests = 0;
        public static bool KeyIsValid = false;
        public static int Interface = 1;      //values: {1:frmAssign, 2:frmAssign2}
        public static string List15Mode = ""; //modes:  {RefNote, RefNoteSearch}
        public static string List5Mode = "";  //modes:  {Ref, Link, LinkNote, LinkNoteSearch, SubProjectNote, SubProjectNoteSearch, RefNote, RefNoteSearch}
        public static string List55Mode = ""; //modes:  {LinkNote, LinkNoteSearch}
        public static string List6Mode = "";  //modes:  {SubProjectNote, SubProjectNoteSearch}
        public static string eLibDataPath = Environment.GetFolderPath (Environment.SpecialFolder.CommonDocuments) + @"\";
        public static int DialogRequestParams = 0;
        /* DialogRequestParams:
            bit 1: frmProject dialog is requested for Project
            bit 2: frmProject dialog is requested for SubProject
            bit 3: frmProject dialog is requested for user/pass
            bit 4: frmProject dialog is requested as 0:new, 1:Edit item
            bit 5: frmProject dialog is exited as 0:cancel, 1:ok/save
            bit 6: a subproject is selected from dialog frmSelectProject/Subproject
            bit 7: a project is selected from dialog frmSelectProject/Subproject
            bit 8: frmProject dialog is requested for Student/pass (examSheets)
         */
        public static void CreateTables ()
            {
            Db.DS.Tables.Add ("tblConnections");
            Db.DS.Tables["tblConnections"].Columns.Add ("Library", typeof (string));
            Db.DS.Tables["tblConnections"].Columns.Add ("Address", typeof (string));
            Db.DS.Tables["tblConnections"].Columns.Add ("initcat", typeof (string));
            Db.DS.Tables["tblConnections"].Columns.Add ("uid", typeof (string));
            Db.DS.Tables["tblConnections"].Columns.Add ("pwd", typeof (string));
            Db.DS.Tables["tblConnections"].Columns.Add ("SN", typeof (string));
            Db.DS.Tables.Add ("tblSettings");
            //Settings usrs
            Db.DS.Tables.Add ("tblusrs");
            //eLib
            //Db.DS.Tables.Add ("tblTempIDs");          //different uses.., eg for Ids of notes to be deleted!
            Db.DS.Tables.Add ("tblRefs");
            Db.DS.Tables.Add ("tblUserProject");
            Db.DS.Tables.Add ("tblProject");
            Db.DS.Tables.Add ("tblSubProject");
            Db.DS.Tables.Add ("tblLinks");
            Db.DS.Tables.Add ("tblAssignments");
            Db.DS.Tables.Add ("tblAssignments4Backup"); //wo subproject.name (to match DB - for bulkcopy)
            Db.DS.Tables.Add ("tblNotesCount");         // notes for Focus?
            Db.DS.Tables.Add ("tblSNotes");             // notes for Sbprojects 
            Db.DS.Tables.Add ("tblLNotes");             // notes for Links
            Db.DS.Tables.Add ("tblRNotes");             // notes for Refs
            Db.DS.Tables.Add ("tblUNotes");             // notes for UpstreamNotes
            Db.DS.Tables.Add ("tblDNotes");             // notes for DownstreamNotes
            Db.DS.Tables.Add ("tblXNotes");             // notes from Search (to be linked?)
            Db.DS.Tables.Add ("tblNoteNet");            // notes liked
            Db.DS.Tables.Add ("tblRefPaths");
            Db.DS.Tables.Add ("tblSubProjects");
            Db.DS.Tables.Add ("tblAssign_tmp ");
            Db.DS.Tables.Add ("tblProj_tmp");           // for frm.selectProj/Prod
            Db.DS.Tables.Add ("tblProd_tmp");           // for frm.selectProj/Prod
            Db.DS.Tables.Add ("tblProd_tmp2");          // for frm.ImportRef
            Db.DS.Tables["tblProd_tmp2"].Columns.Add ("ProdId", typeof (int));
            Db.DS.Tables["tblProd_tmp2"].Columns.Add ("ProdName", typeof (string));
            //Augustus
            Db.DS.Tables.Add ("tblSpecies");
            Db.DS.Tables.Add ("tblClusters");
            Db.DS.Tables.Add ("tblTranscripts");
            Db.DS.Tables.Add ("tblPalette");
            Db.DS.Tables.Add ("tblArrows");
            //tblPalette
            Db.DS.Tables["tblPalette"].Columns.Add ("ID", typeof (int));
            Db.DS.Tables["tblPalette"].Columns.Add ("R", typeof (int));
            Db.DS.Tables["tblPalette"].Columns.Add ("G", typeof (int));
            Db.DS.Tables["tblPalette"].Columns.Add ("B", typeof (int));
            Db.DS.Tables["tblPalette"].Clear ();
            for (int i = 0; i < 20; i++)
                {
                Db.DS.Tables["tblPalette"].Rows.Add (i, 0, 0, 0);
                }
            //tblArrows
            Db.DS.Tables["tblArrows"].Columns.Add ("Species", typeof (string));
            Db.DS.Tables["tblArrows"].Columns.Add ("Cluster", typeof (string));
            Db.DS.Tables["tblArrows"].Columns.Add ("Gene", typeof (string));
            Db.DS.Tables["tblArrows"].Columns.Add ("Spacer", typeof (string));
            Db.DS.Tables["tblArrows"].Columns.Add ("Size", typeof (int));
            Db.DS.Tables["tblArrows"].Columns.Add ("Dir", typeof (string));
            Db.DS.Tables["tblArrows"].Columns.Add ("Description", typeof (string));
            Db.DS.Tables["tblArrows"].Columns.Add ("Dye", typeof (string));
            Db.DS.Tables["tblArrows"].Columns.Add ("Sel", typeof (string));
            //tblExams
            Db.DS.Tables.Add ("tblCourses");
            Db.DS.Tables.Add ("tblCourseTopics");
            Db.DS.Tables.Add ("tblTests");
            Db.DS.Tables.Add ("tblTest1");
            Db.DS.Tables.Add ("tblTestOptions");
            Db.DS.Tables.Add ("tblExams");
            Db.DS.Tables.Add ("tblExamComposition");
            Db.DS.Tables.Add ("tblExamTests");
            Db.DS.Tables.Add ("tblEntries");
            Db.DS.Tables.Add ("tblEntryStudents");
            Db.DS.Tables.Add ("tblExamStudents");
            Db.DS.Tables.Add ("tblStudentExams");
            Db.DS.Tables.Add ("tblExamSheets");
            //security
            Db.DS.Tables.Add ("tblSecurityCodes");
            Db.DS.Tables["tblSecurityCodes"].Columns.Add ("Ascii_Code", typeof (int));
            Db.DS.Tables["tblSecurityCodes"].Columns.Add ("Alt1", typeof (int));
            Db.DS.Tables["tblSecurityCodes"].Columns.Add ("Alt2", typeof (int));
            Db.DS.Tables["tblSecurityCodes"].Columns.Add ("Alt3", typeof (int));
            Db.DS.Tables["tblSecurityCodes"].Columns.Add ("Alt4", typeof (int));
            Db.DS.Tables["tblSecurityCodes"].Columns.Add ("Alt5", typeof (int));
            Db.DS.Tables["tblSecurityCodes"].Columns.Add ("Coeff", typeof (int));
            //add rows
            FeedSecurityTable ();
            }
        public static void FeedSecurityTable ()
            {
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (32, 85, 32, 45, 64, 54, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (33, 104, 53, 57, 90, 67, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (34, 93, 89, 84, 91, 86, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (35, 123, 90, 85, 116, 77, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (36, 77, 91, 56, 120, 123, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (37, 59, 116, 77, 70, 42, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (38, 49, 120, 78, 66, 85, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (39, 65, 121, 102, 71, 119, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (40, 66, 54, 103, 110, 104, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (41, 101, 87, 104, 122, 93, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (42, 46, 88, 47, 123, 114, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (43, 110, 67, 93, 86, 65, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (44, 109, 103, 60, 50, 80, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (45, 94, 101, 121, 125, 37, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (46, 62, 46, 65, 96, 52, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (47, 34, 73, 99, 63, 33, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (48, 111, 72, 100, 107, 125, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (49, 79, 63, 61, 88, 38, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (50, 98, 124, 82, 117, 74, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (51, 32, 75, 58, 55, 105, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (52, 45, 37, 83, 93, 97, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (53, 73, 102, 59, 126, 98, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (54, 41, 114, 55, 92, 32, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (55, 53, 50, 113, 56, 45, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (56, 89, 115, 39, 94, 35, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (57, 126, 106, 123, 98, 91, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (58, 61, 122, 42, 32, 116, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (59, 43, 123, 62, 45, 120, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (60, 124, 42, 34, 35, 70, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (61, 96, 39, 111, 57, 50, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (62, 64, 109, 72, 84, 51, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (63, 99, 41, 73, 85, 112, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (64, 90, 64, 74, 119, 57, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (65, 95, 40, 89, 87, 107, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (66, 40, 47, 118, 76, 111, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (67, 55, 45, 107, 111, 109, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (68, 103, 35, 76, 72, 73, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (69, 83, 74, 110, 105, 99, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (70, 56, 105, 101, 97, 90, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (71, 80, 66, 92, 67, 39, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (72, 36, 108, 53, 54, 92, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (73, 76, 81, 125, 82, 48, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (74, 100, 43, 96, 62, 106, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (75, 117, 44, 63, 34, 60, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (76, 35, 51, 40, 108, 36, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (77, 106, 112, 41, 114, 95, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (78, 60, 57, 64, 115, 79, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (79, 47, 62, 90, 36, 61, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (80, 114, 33, 35, 60, 87, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (81, 72, 111, 122, 38, 96, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (82, 81, 110, 46, 41, 64, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (83, 122, 86, 94, 118, 66, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (84, 58, 118, 108, 68, 71, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (85, 97, 68, 114, 69, 110, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (86, 113, 69, 115, 44, 122, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (87, 39, 70, 50, 121, 40, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (88, 68, 71, 51, 65, 101, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (89, 119, 52, 112, 99, 46, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (90, 48, 94, 91, 95, 43, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (91, 51, 77, 116, 79, 82, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (92, 121, 65, 126, 46, 44, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (93, 87, 80, 33, 43, 47, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (94, 91, 60, 105, 77, 118, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (95, 116, 61, 124, 78, 84, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (96, 120, 82, 75, 104, 58, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (97, 70, 83, 37, 58, 78, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (98, 107, 58, 54, 59, 113, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (99, 38, 59, 87, 49, 55, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (100, 74, 49, 88, 113, 59, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (101, 105, 113, 117, 39, 121, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (102, 69, 55, 49, 40, 68, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (103, 44, 56, 119, 101, 69, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (104, 112, 78, 120, 80, 63, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (105, 57, 84, 66, 102, 94, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (106, 92, 48, 68, 75, 72, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (107, 71, 92, 69, 37, 81, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (108, 102, 126, 70, 52, 83, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (109, 115, 125, 71, 53, 56, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (110, 50, 93, 52, 89, 126, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (111, 67, 117, 48, 42, 108, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (112, 33, 85, 109, 51, 102, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (113, 125, 119, 38, 112, 115, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (114, 118, 76, 79, 124, 49, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (115, 88, 97, 80, 47, 103, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (116, 75, 98, 81, 48, 100, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (117, 82, 99, 43, 106, 76, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (118, 54, 79, 106, 61, 124, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (119, 108, 34, 36, 109, 88, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (120, 86, 107, 95, 73, 117, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (121, 37, 36, 97, 81, 41, 4);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (122, 52, 95, 98, 83, 53, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (123, 42, 96, 32, 74, 89, 2);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (124, 63, 100, 44, 33, 75, 3);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (125, 84, 38, 67, 103, 62, 1);
            Db.DS.Tables["tblSecurityCodes"].Rows.Add (126, 78, 104, 86, 100, 34, 2);
            }
        public static void GetClientName ()
            {
            //
            }
        public static void GetClientSN ()
            {
            //using management object and using Win32_LogicalDisk to obtain disk properties
            var oHD = new System.Management.ManagementObject ("Win32_LogicalDisk.DeviceID=\"C:\"");
            oHD.Get (); // Get Info
            DriveSN = Microsoft.VisualBasic.Strings.Trim (oHD["VolumeSerialNumber"].ToString ());
            }
        //QRCODE
        public static void GenerateQRCode (object strText2Code)
            {
            // On Error Resume Next
            try
                {
                string strDir = Application.StartupPath;
                foreach (var strFile in Directory.GetFiles (strDir, "eLibQRCode*.*"))
                    File.Delete (strFile);
                }
            catch (Exception ex)
                {
                //MessageBox.Show ("Error deleting old files ...  " & ex.ToString);
                }
            try
                {
                string strFlnm = "eLibQRCode" + DateTime.Now.ToString ("yyyyMMddHHmmss");
                string strQRCodeTextFilename = Application.StartupPath + strFlnm + ".iQR";
                string strQRCodeImageFileName = Application.StartupPath + strFlnm + ".PNG";
                FileSystem.FileOpen (1, strQRCodeTextFilename, OpenMode.Output);
                FileSystem.PrintLine (1, strText2Code);
                FileSystem.FileClose (1);
                string strQRCodeGenType = "58";
                Process.Start (Application.StartupPath + @"Zint\Zint.exe", "-b " + strQRCodeGenType + " -o " + strQRCodeImageFileName + " -i " + strQRCodeTextFilename).WaitForExit ();
                Application.DoEvents ();
                eLibFile.Filename = strQRCodeImageFileName;
                File.Delete (strQRCodeTextFilename);
                My.MyProject.Forms.frmQR.ShowDialog ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error Creating QRCode!" + ex.ToString ());
                }
            }
        //URLs
        public static void SearchScholar (string strSearchScholar)
            {
            // Search Google Scholar
            strSearchScholar = Strings.Replace (strSearchScholar, " ", "+");
            strSearchScholar = Strings.Replace (strSearchScholar, "-", " ");
            switch (Strings.Right (strSearchScholar, 4))
                {
                case ".doc":
                case ".pdf":
                case ".xls":
                case ".ppt":
                case ".mp4":
                        {
                        strSearchScholar = Strings.Left (strSearchScholar, Strings.Len (strSearchScholar) - 4);
                        break;
                        }
                case "docx":
                case "xlsx":
                case "pptx":
                        {
                        strSearchScholar = Strings.Left (strSearchScholar, Strings.Len (strSearchScholar) - 5);
                        break;
                        }
                }
            string StrURLx = "https://scholar.google.com/scholar?hl=en&as_sdt=0%2C5&q=" + strSearchScholar + "&btnG=";
            OpenURL (StrURLx);
            }
        public static void OpenURL (object StrURL)
            {
            try
                {
                var pWeb = new Process ();
                pWeb.StartInfo.UseShellExecute = true;
                pWeb.StartInfo.FileName = Operators.ConcatenateObject ("microsoft-edge:", StrURL).ToString ();
                pWeb.Start ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Edge Internet browser not found!", "eLib", MessageBoxButtons.OK);
                }
            }
        public static void DeleteHtmlFiles ()
            {
            string strDirx = Application.StartupPath;
            try
                {
                foreach (var strFilex in Directory.GetFiles (strDirx, "*.html"))
                    File.Delete (strFilex);
                }
            //Alternative Code:
            //My.Computer.FileSystem.DeleteFile(Application.StartupPath & "eLibReport.html", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
            //My.Computer.FileSystem.DeleteFile(Application.StartupPath & "eLibCollect.html", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
            catch (Exception ex)
                {
                }
            }
        }
    public class Db
        {
        public static string CurrentDbVersion = "";
        //Cnn
        public static string CnnString = "";
        public static string Server2Connect = "";
        public static Microsoft.Data.SqlClient.SqlConnection CnnSS = new Microsoft.Data.SqlClient.SqlConnection ();
        public static Microsoft.Data.SqlClient.SqlCommand CmdSS = new Microsoft.Data.SqlClient.SqlCommand ();
        public static Microsoft.Data.SqlClient.SqlDataAdapter DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ();
        //Server
        public static string ServerType = "";
        public static string ServerName = "";
        public static string InstanceName = "";
        public static int InstanceNumber = 0;
        //DS
        public static DataSet DS = new DataSet ();
        public static string BackEnd = "";
        public static string ServerUid = "";
        public static string ServerPwd = "";
        public static string strSQL = "";
        public static int BackupRegister = 0;  //int:32bits
        /* BackupRegister:
           bit1:1   0000'0001  Refs
           bit2:2   0000'0010  Projects and subProjects
           bit3:4   0000'0100  Links
           bit4:8   0000'1000  Notes
           bit5:16  0001'0000  Backup CET (courses-exams-tests)
           bit6:32  0010'0000  1:all-users (0: one-user)
           bit7:64  0-00'0000  reserved
           bit8:128 1000'0000  backup was successful
         */
        public static int RestoreStatus = 0;  //int:32 bit
        /* RestoreStatus:
          bit1: operation 1 done
          bit2: operation 2 done
        */
        public static bool CopyAndAttachLocalDB (string strCatalog)
            {
            try
                {
                //copy
                if (!File.Exists (Client.eLibDataPath + strCatalog + ".mdf"))
                    {
                    My.MyProject.Computer.FileSystem.CopyFile (Application.StartupPath + @"DBs\" + strCatalog + ".mdf", Client.eLibDataPath + strCatalog + ".mdf", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                    }
                if (!File.Exists (Client.eLibDataPath + strCatalog + "_log.ldf"))
                    {
                    My.MyProject.Computer.FileSystem.CopyFile (Application.StartupPath + @"DBs\" + strCatalog + "_log.ldf", Client.eLibDataPath + strCatalog + "_log.ldf", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.ThrowException);
                    }
                //attach
                var conn1 = new Microsoft.Data.SqlClient.SqlConnection (@"Data Source=.\" + Db.InstanceName + "; AttachDbFilename=" + Client.eLibDataPath + strCatalog + ".mdf" + "; Database=" + strCatalog + "; Integrated Security=SSPI; TrustServerCertificate=True;");
                if (conn1.State == ConnectionState.Closed)
                    conn1.Open ();
                var cmd1 = new SqlCommand ("SELECT * FROM usrs", conn1);
                var da1 = new SqlDataAdapter ();
                da1.SelectCommand = cmd1;
                cmd1.Dispose ();
                conn1.Close ();
                conn1.Dispose ();
                return true;
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                return false;
                }
            }
        public static bool CheckDBAttached2SqlServerExpress (string strCatalog)
            {
            using (var DBConn = new SqlConnection (@"Server=.\" + Db.InstanceName + "; Initial Catalog=" + strCatalog + "; Integrated Security = SSPI; TrustServerCertificate=True;"))
                {
                try
                    {
                    DBConn.Open ();
                    var DBCmd = new SqlCommand ("Select * From usrs", DBConn);
                    int rows = DBCmd.ExecuteNonQuery ();
                    DBConn.Close ();
                    return true;
                    }
                catch (Exception ex)
                    {
                    DBConn.Close ();
                    MessageBox.Show (ex.ToString ());
                    return false;
                    }
                }
            }

        public static int ConnectTo (string Server2Connect)
            {
            //MessageBox.Show (Server2Connect);
            int Connect2DatabaseRet = default;
            try
                {
                Db.CnnString = Db.BackEnd;
                Db.CnnSS = new SqlConnection (Db.CnnString);
                Db.CnnSS.Open ();
                Connect2DatabaseRet = 1;
                }
            catch (Exception ex)
                {
                DialogResult myansw = (DialogResult) MessageBox.Show ("eLib did not connect to the selected database\r\n \r\n Show details?", "Error connecting to the database", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if ((int) myansw == (int) Constants.vbYes)
                    MessageBox.Show (ex.ToString ());
                Connect2DatabaseRet = 0;
                }
            return Connect2DatabaseRet;
            }
        public static void ReadSettingsAndUsers ()
            {
            Db.DS.Tables["tblUsrs"].Clear ();
            Db.DS.Tables["tblSettings"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                //Users 
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID, UsrName, UsrPass, UsrActive, UsrSN, acc, FolderPapers, FolderBooks, FolderManuals, FolderLectures, FolderTemp, FolderSaveACopy, UsrNote, UsrInterface FROM usrs", CnnSS);
                Db.DASS.Fill (Db.DS, "tblUsrs");
                //Settings result order by sttKey:   0 AdminPass 1 CurrentVersion 2 Interface 3 Owner 4 QRCodeType 5 SearchRefType
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, sttHeader, sttKey, sttValue, sttNote From Settings ORDER BY sttKey", CnnSS);
                Db.DASS.Fill (Db.DS, "tblSettings");
                CnnSS.Close ();
                }
            User.AdminPass = Convert.ToString (Db.DS.Tables["tblSettings"].Rows[0][3]);
            Db.CurrentDbVersion = Convert.ToString (Db.DS.Tables["tblSettings"].Rows[1][3]);
            }
        //SCAN (new codes using class fileinfo, directory)
        public static void ScanResources ()
            {
            //step 1. validate folders
            string resultx = User.ValidateFolders ();
            if (resultx != "valid")
                {
                MessageBox.Show ("eLib folders not valid !", "eLib", MessageBoxButtons.OK);
                return;
                }
            //step 2. prepare tbls Refs, Paths 
            Db.DS.Tables["tblRefs"].Clear ();
            Db.DS.Tables["tblRefPaths"].Clear ();
            using (var CnnSS1 = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                try
                    {
                    CnnSS1.Open ();
                    //initialise tbl Paths
                    Db.strSQL = "SELECT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture FROM Links RIGHT JOIN Papers ON Links.Paper_ID = Papers.ID WHERE Papers.ID = 1;";
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS1);
                    Db.DASS.Fill (Db.DS, "tblRefs");
                    //clear tbl Paths
                    Db.strSQL = "DELETE FROM Paths WHERE StorageSN = '" + Client.DriveSN + "';";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS1);
                    cmdx.CommandType = CommandType.Text;
                    int ix = cmdx.ExecuteNonQuery ();
                    //initialise tbl Paths
                    Db.strSQL = "SELECT FilePath, StorageSN FROM Paths WHERE FilePath ='_1';";
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS1);
                    Db.DASS.Fill (Db.DS, "tblRefPaths");
                    //close connection
                    CnnSS1.Close ();
                    CnnSS1.Dispose ();
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    CnnSS1.Close ();
                    CnnSS1.Dispose ();
                    }
                }
            //step 3. read files
            //NOTICE: we use ref.attributes here to publicly show which mainfolder is being scanned. we need this info in: GetFilenames()  
            Ref.Attributes = 1; //for papers
            GetSubDirs (User.FolderPapers);
            Ref.Attributes = 2; //for books
            GetSubDirs (User.FolderBooks);
            Ref.Attributes = 3; //for manuals
            GetSubDirs (User.FolderManuals);
            Ref.Attributes = 4; //for lectures
            GetSubDirs (User.FolderLectures);
            //step 4. bulkcopy to sqlserver
            using (var CnnSS1 = new SqlConnection (Db.CnnString))
                {
                try
                    {
                    CnnSS1.Open ();
                    //bulkcopy-files
                    var bCopy1 = new SqlBulkCopy (CnnSS1);
                    bCopy1.DestinationTableName = "Papers";
                    bCopy1.BatchSize = Db.DS.Tables["tblRefs"].Rows.Count;
                    bCopy1.WriteToServer (Db.DS.Tables["tblRefs"]);
                    bCopy1.Close ();
                    CnnSS1.Close ();
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    CnnSS1.Close ();
                    }
                }
            using (var CnnSS2 = new SqlConnection (Db.CnnString))
                {
                try
                    {
                    CnnSS2.Open ();
                    //bulkcopy-paths
                    var bCopy2 = new SqlBulkCopy (CnnSS2);
                    bCopy2.DestinationTableName = "Paths";
                    bCopy2.BatchSize = Db.DS.Tables["tblRefPaths"].Rows.Count;
                    bCopy2.WriteToServer (Db.DS.Tables["tblRefPaths"]);
                    bCopy2.Close ();
                    CnnSS2.Close ();
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    CnnSS2.Close ();
                    }
                }
            }
        private static void GetSubDirs (string strDir)
            {
            string[] subdirectoryEntries = Directory.GetDirectories (strDir);
            //loop to find more subdirectories
            foreach (string subdirectory in subdirectoryEntries)
                {
                GetFilenamesAndPaths (subdirectory);
                GetSubDirs (subdirectory); //recursion
                }
            }
        private static void GetFilenamesAndPaths (string strDirPath)
            {
            string[] Files = Directory.GetFiles (strDirPath, "*.*");
            string strFilename = "";
            foreach (string file in Files)
                {
                FileInfo fi = new FileInfo (file);
                Db.DS.Tables["tblRefPaths"].Rows.Add (fi.FullName, Client.DriveSN);
                //
                strFilename = RemoveExtension (fi.Name);
                switch (Ref.Attributes)
                    {
                    case 1: //for papers
                            {
                            Db.DS.Tables["tblRefs"].Rows.Add (1, strFilename, 1, 0, 0, 0); //P
                            break;
                            }
                    case 2: //for books
                        Db.DS.Tables["tblRefs"].Rows.Add (1, strFilename, 0, 1, 0, 0); //B
                            {
                            break;
                            }
                    case 3: //for manuals
                            {
                            Db.DS.Tables["tblRefs"].Rows.Add (1, strFilename, 0, 0, 1, 0); //M
                            break;
                            }
                    case 4: //for lectures
                            {
                            Db.DS.Tables["tblRefs"].Rows.Add (1, strFilename, 0, 0, 0, 1); //L
                            break;
                            }
                    }
                }
            }
        public static string RemoveExtension (string strFlnm)
            {
            string RemoveExtensionRet = "";
            eLibFile.Extension = "";
            eLibFile.Extension = Strings.LCase (Strings.Right (strFlnm, 5));
            if (eLibFile.Extension == ".docx" | eLibFile.Extension == ".xlsx" | eLibFile.Extension == ".pptx")
                {
                strFlnm = Strings.Left (strFlnm, Strings.Len (strFlnm) - 5);
                goto lblReturn;
                }
            eLibFile.Extension = Strings.LCase (Strings.Right (strFlnm, 4));
            if (eLibFile.Extension == ".pdf" | eLibFile.Extension == ".doc" | eLibFile.Extension == ".xls" | eLibFile.Extension == ".ppt" | eLibFile.Extension == ".bmp" | eLibFile.Extension == ".jpg" | eLibFile.Extension == ".png" | eLibFile.Extension == ".txt" | eLibFile.Extension == ".MP4" | eLibFile.Extension == ".MP3")
                {
                strFlnm = Strings.Left (strFlnm, Strings.Len (strFlnm) - 4);
                goto lblReturn;
                }
        lblReturn:
            RemoveExtensionRet = strFlnm;
            return RemoveExtensionRet;
            }
        //SCAN (old codes)
        public static void ScanNames ()
            {
            //1 Validate Folders
            string resultx = User.ValidateFolders ();
            if (resultx != "valid")
                {
                MessageBox.Show ("eLib folders not valid !", "eLib", MessageBoxButtons.OK);
                return;
                }
            //2 EXTRACT FileNames : DIR /s >> text files
            Process.Start ("cmd.exe", "/C Dir " + User.FolderPapers + " /s > " + Application.StartupPath + "eLibP.txt").WaitForExit ();
            Process.Start ("cmd.exe", "/C Dir " + User.FolderBooks + " /s > " + Application.StartupPath + "eLibB.txt").WaitForExit ();
            Process.Start ("cmd.exe", "/C Dir " + User.FolderManuals + " /s > " + Application.StartupPath + "eLibM.txt").WaitForExit ();
            Process.Start ("cmd.exe", "/C Dir " + User.FolderLectures + " /s > " + Application.StartupPath + "eLibL.txt").WaitForExit ();
            //3 Extract lines of interest out of textfiles!
            string strLine = "";
            string strName = "";
            foreach (string flnm in new[] { "eLibP", "eLibB", "eLibM", "eLibL" })
                {
                FileSystem.FileOpen (1, Application.StartupPath + flnm + ".txt", OpenMode.Input);
                FileSystem.FileOpen (2, Application.StartupPath + flnm + "x.txt", OpenMode.Output);
                strLine = FileSystem.LineInput (1);
                strLine = FileSystem.LineInput (1);
                while (!FileSystem.EOF (1))
                    {
                    try
                        {
                        strLine = Strings.Trim (FileSystem.LineInput (1));
                        if (Strings.Len (strLine) < 40)
                            goto Lblx;
                        if (string.IsNullOrEmpty (strLine) | Strings.InStr (1, strLine, "<DIR>") != 0 | Strings.InStr (1, strLine, "Directory Of") != 0 | Strings.InStr (1, strLine, "File(s) ") != 0 | Strings.InStr (1, strLine, "Total Files Listed:") != 0 | Strings.InStr (1, strLine, "Dir(s) ") != 0)
                            goto Lblx;
                        if (Strings.InStr (1, strLine, @"\") != 0)
                            goto Lblx;
                        strName = Strings.Mid (strLine, 40, Strings.Len (strLine) - 39);
                        strName = Convert.ToString (RemoveExtension (strName));
                        if (Strings.Len (strName) > 8)
                            FileSystem.PrintLine (2, strName);
                        }
                    catch (Exception ex)
                        {
                        //MessageBox.Show ("Error:   \r\n" + strName + "\r\n" + ex.ToString ());
                        MessageBox.Show ("Error:   \r\n" + strName + " \r\n" + ex.ToString ());
                        }

                Lblx:
                    ;

                    }
                FileSystem.FileClose (1);
                FileSystem.FileClose (2);
                }
            //4 Prepare Table cols for Import
            try
                {
                Db.DS.Tables["tblRefs"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture FROM Links RIGHT JOIN Papers ON Links.Paper_ID = Papers.ID  WHERE Papers.ID =1;", CnnSS);
                    Db.DASS.Fill (Db.DS, "tblRefs");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Db.DS.Tables["tblRefs"].Clear ();
            //5 IMPORT into tblPapers
            foreach (string flnm in new[] { "P", "B", "M", "L" })
                {
                FileSystem.FileOpen (1, Application.StartupPath + "eLib" + flnm + "x.txt", OpenMode.Input);
                while (!FileSystem.EOF (1))
                    {
                    strLine = FileSystem.LineInput (1);
                    switch (flnm)
                        {
                        case "P":
                                {
                                Db.DS.Tables["tblRefs"].Rows.Add (1, strLine, 1, 0, 0, 0);
                                break;
                                }
                        case "B":
                                {
                                Db.DS.Tables["tblRefs"].Rows.Add (1, strLine, 0, 1, 0, 0);
                                break;
                                }
                        case "M":
                                {
                                Db.DS.Tables["tblRefs"].Rows.Add (1, strLine, 0, 0, 1, 0);
                                break;
                                }
                        case "L":
                                {
                                Db.DS.Tables["tblRefs"].Rows.Add (1, strLine, 0, 0, 0, 1);
                                break;
                                }
                        }
                    }
                FileSystem.FileClose (1);
                Application.DoEvents ();
                }
            //6 Call BULK-COPY
            BulkCopyPaperNames ();
            //7 Delete temporary files
            foreach (string flnm in new[] { "eLibP", "eLibB", "eLibM", "eLibL" })
                {
                if (!string.IsNullOrEmpty (FileSystem.Dir (Application.StartupPath + flnm + ".txt")))
                    File.Delete (Application.StartupPath + flnm + ".txt");
                if (!string.IsNullOrEmpty (FileSystem.Dir (Application.StartupPath + flnm + "x.txt")))
                    File.Delete (Application.StartupPath + flnm + "x.txt");
                }
            }
        public static void ScanPaths ()
            {
            //OPEN A CONNECTION for this SUB
            Db.CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString);
            Db.CnnSS.Open ();
            try //Delete TABLE Paths
                {
                Db.strSQL = "DELETE FROM Paths WHERE StorageSN = '" + Client.DriveSN + "';";
                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                cmdx.CommandType = CommandType.Text;
                int ix = cmdx.ExecuteNonQuery ();
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            Process.Start ("cmd.exe", "/C Dir " + User.FolderPapers + " /s /b > " + Application.StartupPath + "eLibPz.txt").WaitForExit ();
            Process.Start ("cmd.exe", "/C Dir " + User.FolderBooks + " /s /b > " + Application.StartupPath + "eLibBz.txt").WaitForExit ();
            Process.Start ("cmd.exe", "/C Dir " + User.FolderManuals + " /s /b > " + Application.StartupPath + "eLibMz.txt").WaitForExit ();
            Process.Start ("cmd.exe", "/C Dir " + User.FolderLectures + " /s /b > " + Application.StartupPath + "eLibLz.txt").WaitForExit ();
            try
                {
                Db.DS.Tables["tblRefPaths"].Clear ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT FilePath, StorageSN FROM Paths  WHERE FilePath ='_1';", Db.CnnSS);
                Db.DASS.Fill (Db.DS, "tblRefPaths");
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            // Load fromTextFiles into tblTables:
            string A = "";
            foreach (string flnm in new[] { "P", "B", "M", "L" })
                {
                FileSystem.FileOpen (1, Application.StartupPath + "eLib" + flnm + "z.txt", OpenMode.Input);
                while (!FileSystem.EOF (1))
                    {
                    try
                        {
                        A = FileSystem.LineInput (1);
                        Db.DS.Tables["tblRefPaths"].Rows.Add (A, Client.DriveSN);
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show (ex.ToString ());
                        }
                    }
                FileSystem.FileClose (1);
                Application.DoEvents ();
                }
            //SqlServer-BulkCopy
            try
                {
                var bCopy = new SqlBulkCopy (Db.CnnSS);
                bCopy.DestinationTableName = "Paths";
                bCopy.BatchSize = Db.DS.Tables["tblRefPaths"].Rows.Count;
                bCopy.WriteToServer (Db.DS.Tables["tblRefPaths"]);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            //Delete temporary files
            foreach (string flnm in new[] { "eLibP", "eLibB", "eLibM", "eLibL" })
                {
                if (!string.IsNullOrEmpty (FileSystem.Dir (Application.StartupPath + flnm + "z.txt")))
                    File.Delete (Application.StartupPath + flnm + "z.txt");
                }
            //CLOSE ALL Connections
            Db.CnnSS.Close ();
            Db.CnnSS.Dispose ();
            }
        public static void BulkCopyPaperNames ()
            {
            using (var CnnSS = new SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                var bCopy = new SqlBulkCopy (CnnSS);
                bCopy.DestinationTableName = "Papers";
                bCopy.BatchSize = Db.DS.Tables["tblRefs"].Rows.Count;
                bCopy.WriteToServer (Db.DS.Tables["tblRefs"]);
                CnnSS.Close ();
                }
            }
        //end of scan (old codes)
        public static void AddNewUser ()
            {
            Client.DialogRequestParams = 4; //dialog for: user + new
            My.MyProject.Forms.frmProject.ShowDialog ();
            //checks
            if (Strings.Len (Project.Note) > 20)
                {
                Project.Note = Strings.Left (Project.Note, 20);
                }
            string usr = Project.Name.ToLower ().Trim ();
            if ((usr != "signup") && (usr != "newuser") && (Client.DialogRequestParams == 16)) //bit5(00010000): bit5=0:cancel, bit5=1(value=16):save
                {
                User.Name = Project.Name;  //using shared variables
                User.Pass = Project.Note;  //using shared variables
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = @"INSERT INTO usrs (UsrName, UsrPass, UsrActive, UsrSN, acc, FolderPapers, FolderBooks, FolderManuals, FolderLectures, FolderTemp, FolderSaveACopy, UsrNote, UsrInterface) VALUES (@usrname, @usrpass, 1, 'x', 0, 'D:\eLib\Paper', 'D:\eLib\Book', 'D:\eLib\Manual', 'D:\eLib\Lecture', 'D:\eLib', 'D:\eLib', '-', 2)";
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@usrname", User.Name);
                        cmd.Parameters.AddWithValue ("@usrpass", User.Pass);
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    }
                catch (Exception ex)
                    {
                    DialogResult myansw = (DialogResult) MessageBox.Show ("Error creating new user\r\n Show Error Message ?", "eLib", MessageBoxButtons.YesNo);
                    if ((int) myansw == (int) Constants.vbYes)
                        MessageBox.Show (ex.ToString ());
                    }
                }
            }
        public static void ChengePassword ()
            {
            string strOldPass = "";
            string strNewPass = "";
            string strCheckPass = "";
            strOldPass = User.Pass;
            try
                {
                //check current password
                Project.Name = User.Name;
                Project.Note = "Enter Current Password";
                Client.DialogRequestParams = 12; //mode: userpass + edit
                Project.IsActive = true; //Active chechbox in frmProject
                My.MyProject.Forms.frmProject.ShowDialog ();
                strCheckPass = Project.Note;
                if ((strCheckPass ?? "") != (strOldPass ?? ""))
                    {
                    //Try again!
                    MessageBox.Show ("Incorrect Password !    PLEASE TRY AGAIN", "eLib", MessageBoxButtons.OK);
                    Project.Name = User.Name;
                    Project.Note = "Enter Current Password Carefully!";
                    Client.DialogRequestParams = 12;
                    Project.IsActive = true; // Active
                    My.MyProject.Forms.frmProject.ShowDialog ();
                    strCheckPass = Project.Note;
                    if ((strCheckPass ?? "") != (strOldPass ?? ""))
                        {
                        MessageBox.Show ("Incorrect Password !", "eLib", MessageBoxButtons.OK);
                        return;
                        }
                    }
                //Get new password:
                Project.Name = User.Name;
                Project.Note = "Enter New Password";
                Client.DialogRequestParams = 12;
                Project.IsActive = true; // lets be Active
                My.MyProject.Forms.frmProject.ShowDialog ();
                strNewPass = Project.Note;
                if (string.IsNullOrEmpty (strNewPass) || (strNewPass ?? "") == (strOldPass ?? "") || Strings.Len (strNewPass) < 4)
                    {
                    MessageBox.Show ("Password must be ( NEW ) and greater than ( 4 ) characters !", "eLib", MessageBoxButtons.OK);
                    return;
                    }
                else // Re-Enter (confirm) New Password
                    {
                    strOldPass = strNewPass;
                    Project.Name = User.Name;
                    Project.Note = "Confirm New Password";
                    Client.DialogRequestParams = 12;
                    Project.IsActive = true;
                    My.MyProject.Forms.frmProject.ShowDialog ();
                    strNewPass = Project.Note;
                    if ((strNewPass ?? "") != (strOldPass ?? ""))
                        {
                        MessageBox.Show ("Incorrect repeat of the new Password ", "eLib", MessageBoxButtons.OK);
                        return;
                        }
                    }
                // Save new password
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "UPDATE usrs SET UsrPass=@usrpass WHERE ID=@id";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@usrpass", strNewPass);
                    cmd.Parameters.AddWithValue ("@id", User.Id.ToString ());
                    try
                        {
                        int i = cmd.ExecuteNonQuery ();
                        }
                    catch (Exception ex)
                        {
                        MessageBox.Show ("Error updating Password", "eLib", MessageBoxButtons.OKCancel);
                        }
                    CnnSS.Close ();
                    }
                User.Pass = strNewPass;
                MessageBox.Show ("Password Changed !", "eLib", MessageBoxButtons.OK);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void CreateNewRef (string strRefExt)
            {
            DialogResult myansw = (DialogResult) MessageBox.Show ("Open New Ref", "eLib", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if ((int) myansw == (int) Constants.vbCancel)
                return;
            try
                {
                switch (strRefExt)
                    {
                    case ".docx":
                            {
                            Ref.Title = "New Word Document Ref " + DateTime.Now.ToString ("yyyy-MM-dd HH-mm");
                            Instance.Path = Application.StartupPath + Ref.Title + ".docx";
                            FileSystem.FileOpen (1, Instance.Path, OpenMode.Output);
                            FileSystem.FileClose (1);
                            break;
                            }
                    case ".pptx":
                            {
                            Ref.Title = "New Powerpoint Ref " + DateTime.Now.ToString ("yyyy-MM-dd HH-mm");
                            Instance.Path = Application.StartupPath + Ref.Title + ".pptx";
                            FileSystem.FileOpen (1, Instance.Path, OpenMode.Output);
                            FileSystem.FileClose (1);
                            break;
                            }
                    case ".txt":
                            {
                            Ref.Title = "New Text Document Ref " + DateTime.Now.ToString ("yyyy-MM-dd HH-mm");
                            Instance.Path = Application.StartupPath + Ref.Title + ".txt";
                            FileSystem.FileOpen (1, Instance.Path, OpenMode.Output);
                            FileSystem.FileClose (1);
                            break;
                            }
                    case ".xlsx":
                            {
                            using (ClosedXML.Excel.IXLWorkbook WB = new XLWorkbook ())
                                {
                                var WS0 = WB.Worksheets.Add ("eLib_NewExcelRef");
                                WS0.Cell (1, 1).Value = "eLib Col1";
                                WS0.Cell (1, 2).Value = "eLib Col2";
                                WS0.Cell (1, 3).Value = "eLib Col3";
                                //Save Excel
                                Ref.Title = "New Excel Ref " + DateTime.Now.ToString ("yyyy-MM-dd HH-mm");
                                Instance.Path = Application.StartupPath + Ref.Title + ".xlsx";
                                WB.SaveAs (Instance.Path);
                                }

                            break;
                            }
                    }
                Ref.ImportStatus = 3; //set bit1,2 on: New Ref Document
                eLibFile.Extension = strRefExt;
                Ref.TypeText = "Manual";
                My.MyProject.Forms.frmImportRefs.ShowDialog ();
                if ((int) myansw == (int) Constants.vbYes)
                    {
                    Interaction.Shell ("Notepad.exe " + @Instance.Path, AppWinStyle.NormalFocus);
                    //System.Diagnostics.Process.Start (@Instance.Path);
                    //old code from vb --- long G = Interaction.Shell ("RUNDLL32.EXE URL.DLL,FileProtocolHandler " + Instance.Path, Constants.vbNormalFocus);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error Creating New Ref \r\n" + ex.ToString ());
                }
            }
        //Wipe out data
        public static void ClearPapers (string tblName)
            {
            //Assuming an OPEN CNN for this SUB
            Db.RestoreStatus = 0;
            //Clear DataTables 
            Db.DS.Tables["tblUsrs"].Clear ();
            Db.DS.Tables["tblRefs"].Clear ();
            Db.DS.Tables["tblProject"].Clear ();
            Db.DS.Tables["tblSubProject"].Clear ();
            Db.DS.Tables["tblAssignments"].Clear ();
            Db.DS.Tables["tblLinks"].Clear (); // not necessary
            Db.DS.Tables["tblSNotes"].Clear ();
            Db.DS.Tables["tblNoteNet"].Clear ();
            Db.DS.Tables["tblCourses"].Clear ();
            Db.DS.Tables["tblCourseTopics"].Clear ();
            Db.DS.Tables["tblTests"].Clear ();
            Db.DS.Tables["tblTestOptions"].Clear ();
            Db.DS.Tables["tblExams"].Clear ();
            Db.DS.Tables["tblExamComposition"].Clear ();
            Db.DS.Tables["tblExamTests"].Clear ();
            //Del Database Tables Rows 
            try
                {
                foreach (var strTableName in new[] { tblName })
                    {
                    using (var CnnSSx = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSSx.Open ();
                        switch (strTableName)
                            {
                            case "Paths":
                                    {
                                    Db.strSQL = "DELETE FROM " + strTableName + " WHERE StorageSN = '" + Client.DriveSN + "';";
                                    break;
                                    }

                            default:
                                    {
                                    Db.strSQL = "DELETE FROM " + strTableName + ";";
                                    break;
                                    }
                            }
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSSx);
                        cmd.CommandType = CommandType.Text;
                        int i = cmd.ExecuteNonQuery ();
                        CnnSSx.Close ();
                        }
                    }
                Db.RestoreStatus = 1;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return;
                }
            //ReSeed Table IDs to 1
            Db.RestoreStatus = Db.RestoreStatus & 253; //set bit2 off: ------0-
            try
                {
                foreach (var strTableName in new[] { tblName })
                    {
                    Db.strSQL = "DBCC CHECKIDENT (" + strTableName + ", RESEED, 1)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery ();
                    }
                Db.RestoreStatus = Db.RestoreStatus | 2; //set bit2 on: ------1-
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString(), "eLib");
                return;
                }
            }
        public static void ClearDatabaseTablesAndReseed ()
            {
            //Assuming an OPEN CNN for this SUB
            Db.RestoreStatus = Db.RestoreStatus & 254;
            //Clear DataTables 
            Db.DS.Tables["tblUsrs"].Clear ();
            Db.DS.Tables["tblRefs"].Clear ();
            Db.DS.Tables["tblProject"].Clear ();
            Db.DS.Tables["tblSubProject"].Clear ();
            Db.DS.Tables["tblAssignments"].Clear ();
            Db.DS.Tables["tblAssignments4Backup"].Clear ();
            Db.DS.Tables["tblLinks"].Clear ();
            Db.DS.Tables["tblRNotes"].Clear ();
            Db.DS.Tables["tblSNotes"].Clear ();
            Db.DS.Tables["tblLNotes"].Clear ();
            Db.DS.Tables["tblXNotes"].Clear ();
            Db.DS.Tables["tblNoteNet"].Clear ();
            Db.DS.Tables["tblCourses"].Clear ();
            Db.DS.Tables["tblCourseTopics"].Clear ();
            Db.DS.Tables["tblTests"].Clear ();
            Db.DS.Tables["tblTestOptions"].Clear ();
            Db.DS.Tables["tblExams"].Clear ();
            Db.DS.Tables["tblExamComposition"].Clear ();
            Db.DS.Tables["tblEntries"].Clear ();
            Db.DS.Tables["tblEntryStudents"].Clear ();
            Db.DS.Tables["tblExamStudents"].Clear ();
            Db.DS.Tables["tblExamTests"].Clear ();
            //Db.DS.Tables ["tblConnections"].Clear ();    //new 14030720
            //Db.DS.Tables ["tblSecurityCodes"].Clear ();  //new 14030720
            //Del Database Tables Rows 
            try
                {
                foreach (var strTableName in new[] { "usrs", "User_Project", "Projects", "SubProjects", "Links", "Notes", "NoteNet", "Courses", "CourseTopics", "Tests", "TestOptions", "Exams", "ExamComposition", "ExamTests", "Entries", "Students", "ExamStudents", "ExamSheets", "Sequences", "ArrowData", "Clusters", "Species", "Transcripts" })
                    {
                    Db.strSQL = "DELETE FROM " + strTableName + ";";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery ();
                    }
                Db.RestoreStatus = Db.RestoreStatus | 1;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return;
                }
            //ReSeed IDs to 1
            Db.RestoreStatus = Db.RestoreStatus & 253;
            try
                {
                foreach (var strTableName in new[] { "usrs", "Projects", "SubProjects", "Links", "Notes", "NoteNet", "Courses", "CourseTopics", "Tests", "TestOptions", "Exams", "ExamComposition", "ExamTests", "Entries", "Students", "ExamStudents", "Clusters", "Species", "Transcripts" })
                    {
                    Db.strSQL = "DBCC CHECKIDENT (" + strTableName + ", RESEED, 1)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, Db.CnnSS);
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery ();
                    }
                Db.RestoreStatus = Db.RestoreStatus | 2;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return;
                }
            }
        public static void ClearRepositoryOfThisLibrary (int confirm)
            {
            if (confirm == 1)
                {
                DialogResult myansw;
                myansw = MessageBox.Show ("This will 'CLEAR' all Data from Current Library\r\n" + "Continue ?", "eLib", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.Cancel)
                    {
                    return;
                    }
                }
            //Clear!
            VBMath.Randomize ();
            int strRndNumber = Convert.ToInt32 (10000 * VBMath.Rnd () + 1001);
            string strAnsw = Interaction.InputBox ("Enter this Code: " + strRndNumber, "Enter Code below to Proceed", "");
            if (Convert.ToInt32 (strAnsw) != strRndNumber)
                return;
            //WIPE-OUT!
            //CLOSE ALL Connections
            ClearPapers ("Papers");
            ClearPapers ("Paths");
            ClearDatabaseTablesAndReseed ();
            }
        public static void CloseDbAndExitTheApp ()
            {
            Client.DeleteHtmlFiles (); // Remove possible existing Data related to other users (now, and also when logging-in via frmCNN as new user )
            Db.CnnSS.Close ();
            Db.CnnSS.Dispose ();
            Db.CnnSS = null;
            Application.Exit ();
            Environment.Exit (0);
            }
        }
    public static class User
        {
        public static string AdminPass = "mshtaccesson";
        public static int Id = 0;
        public static string Type = "";             // ADMIN | USER 
        public static string Name = "";
        public static string Pass = "";
        public static int Accs = 0;                 // acc1-acc15 (user access controls)
        public static string FolderPapers = "";
        public static string FolderBooks = "";
        public static string FolderManuals = "";
        public static string FolderLectures = "";
        public static string FolderTemp = "";
        public static string FolderSaveACopy = "";
        public static int NotesDay0 = 0;
        public static int NotesDay1 = 0;
        public static int NotesDay2 = 0;
        public static int NotesDay3 = 0;
        public static int NotesDay4 = 0;
        public static int NotesDay5 = 0;
        public static int NotesDay6 = 0;
        public static string ValidateFolders ()
            {
            string ValidateFoldersRet = default;
            ValidateFoldersRet = "notvalid";
            Db.RestoreStatus = 1;    //set initial value > 1
            while (Db.RestoreStatus > 0)
                {
                string Errmsg = "";
                Db.RestoreStatus = 0;
                if (!System.IO.Directory.Exists (User.FolderPapers))
                    {
                    Db.RestoreStatus = Db.RestoreStatus | 1;
                    Errmsg = Errmsg + User.FolderPapers + "\r\n";
                    }
                if (!System.IO.Directory.Exists (User.FolderBooks))
                    {
                    Db.RestoreStatus = Db.RestoreStatus | 2;
                    Errmsg = Errmsg + User.FolderBooks + "\r\n";
                    }
                if (!System.IO.Directory.Exists (User.FolderManuals))
                    {
                    Db.RestoreStatus = Db.RestoreStatus | 4;
                    Errmsg = Errmsg + User.FolderManuals + "\r\n";
                    }
                if (!System.IO.Directory.Exists (User.FolderLectures))
                    {
                    Db.RestoreStatus = Db.RestoreStatus | 8;
                    Errmsg = Errmsg + User.FolderLectures + "\r\n";
                    }
                if (!System.IO.Directory.Exists (User.FolderSaveACopy))
                    {
                    Db.RestoreStatus = Db.RestoreStatus | 16;
                    Errmsg = Errmsg + User.FolderSaveACopy + "\r\n";
                    }
                ValidateFoldersRet = "valid";
                if (Db.RestoreStatus > 0)
                    {
                    //MessageBox.Show ("Invalid eLib folders: \r\n" + Errmsg, "eLib", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ValidateFoldersRet = "notvalid";
                    return ValidateFoldersRet;
                    }
                }
            return ValidateFoldersRet;
            }
        }
    public static class Assign
        {
        public static int Mode = 0; //TreeA, GridB, GridC in Assign2 form: states 
        /* Mode:
            bit7  TreeA Projects
            bit6  TreeA SubProjects
            bit5  GridB SNotes
            bit4  GridB LNotes
            bit3  GridB RNotes
            bit2  GridC Links 
            bit1  GridC Refs 
            ---
            Examples
            bits             val     treeA              gridB/gridC
            -------------------------------------------------------------------------
            -1-  ---  --     64      A: Projects        B: -          C: -        
            --1  ---  --     32      A: SubProjects     B: -          C: -         
            --1  1--  1-     50      A: SubProjects     B: SNotes     C: Links        
            ---  1--  --     16      a: -               B: SNotes ?   C: -         
            --1  -1--  1-    42      A: SubProjects     B: LNotes     C: Links        
            ---  111  -1     29      A: -               B: RNotes     C: Refs ?        
            ---  --1  -1     5       A: -               B: RNotes     C: -     
            -------------------------------------------------------------------------
            */
        public static void DoInitializeTheTables ()
            {
            Db.CnnSS.Close ();
            Db.CnnSS.Dispose ();
            Db.DS.Tables["tblUserProject"].Clear ();
            Db.DS.Tables["tblProject"].Clear ();
            Db.DS.Tables["tblSubProject"].Clear ();
            Db.DS.Tables["tblAssignments"].Clear ();
            Db.DS.Tables["tblSNotes"].Clear ();
            Db.DS.Tables["tblRefs"].Clear ();
            Db.DS.Tables["tblLinks"].Clear ();
            //initialize tables Links, SLRNotes
            Db.DS.Tables["tblSNotes"].Clear ();
            Db.DS.Tables["tblLinks"].Clear ();
            //tblSNote
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE ID =1;", CnnSS);
                Db.DASS.Fill (Db.DS, "tblSNotes");
                Db.DASS.Fill (Db.DS, "tblLNotes");
                Db.DASS.Fill (Db.DS, "tblRNotes");
                CnnSS.Close ();
                }
            }
        public static void ReadAllSharingsTable ()
            {
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                Db.strSQL = "SELECT User_Id, Project_Id, ReadOnly FROM User_Project";
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT User_Id, UsrName, UsrNote, Project_Id, ReadOnly FROM usrs JOIN User_Project ON usrs.ID = User_Project.User_Id WHERE Project_Id = " + Project.Id.ToString (), CnnSS);
                Db.DASS.Fill (Db.DS.Tables["tblUserProject"]);
                CnnSS.Close ();
                }
            }
        public static int CheckReadOnlyAccess (int projectid)
            {
            foreach (DataRow R in Db.DS.Tables["tblUserProject"].Rows)
                {
                if (((int) R[0] == User.Id) && ((int) R[3] == projectid) && ((bool) R[4] == true))
                    {
                    MessageBox.Show ("Notice: \n\n\nYou have ReadOnly access to this Project!", "eLib", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 1;
                    }
                }
            return 0;
            }
        public static bool DoLinkRef2SubProject (int intRefId, int intSubProjectId)
            {
            bool DoLinkRef2SubProjectRetval = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "INSERT INTO Links (Paper_ID, SubProject_ID) VALUES (@paperid, @SubProjectid)";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@paperid", intRefId.ToString ());
                    cmdx.Parameters.AddWithValue ("@SubProjectid", intSubProjectId.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                DoLinkRef2SubProjectRetval = true;
                }
            catch (Exception ex)
                {
                DoLinkRef2SubProjectRetval = false;
                }
            return DoLinkRef2SubProjectRetval;
            }
        public static void GetProjects (int usrid, int activex, string strSearchProj)
            {
            //activex: 0:active 1:inactive  2:all 3:search
            Db.DS.Tables["tblProject"].Clear ();
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
                case 3:
                        {
                        if (string.IsNullOrEmpty (strSearchProj))
                            {
                            Db.strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Projects WHERE (ID IN (SELECT Project_Id FROM User_Project WHERE User_Id = " + usrid.ToString () + ") OR  user_ID = " + usrid.ToString () + ") Order By ProjectName";
                            }
                        else
                            {
                            Db.strSQL = "Select ID, ProjectName, Notes, Active, user_ID FROM Projects WHERE (ID IN (SELECT Project_Id FROM User_Project WHERE User_Id = " + usrid.ToString () + ") OR  user_ID = " + usrid.ToString () + ") AND ProjectName LIKE '%" + strSearchProj + "%' Order By ProjectName";
                            }
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
            Assign.ReadAllSharingsTable ();
            Db.DS.Tables["tblSubProject"].Clear ();
            }
        public static void GetSubProjects (int Projectid)
            {
            Db.DS.Tables["tblSubProject"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select ID, SubProjectName, Notes, Project_ID FROM SubProjects Where Project_ID = " + Projectid.ToString () + " Order by SubProjectName", CnnSS);
                Db.DASS.Fill (Db.DS, "tblSubProject");
                CnnSS.Close ();
                }
            }
        public static int GetSubProjectIdByLinkId (int linkid)
            {
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "SELECT SubProjects.ID FROM SubProjects INNER JOIN Links ON Links.SubProject_ID = SubProjects.ID WHERE Links.ID = " + linkid.ToString (); //+ "; SELECT CAST (scope_identity() AS int)";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    SubProject.Id = (int) cmdx.ExecuteScalar ();
                    CnnSS.Close ();
                    return SubProject.Id;
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                return 0;
                }
            }
        public static int GetRefByRefId (int refid)
            {
            Db.strSQL = "SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture FROM Papers LEFT JOIN Notes ON Notes.Parent_ID = papers.ID WHERE Papers.ID = " + refid.ToString ();
            //Do Query
            try
                {
                Db.DS.Tables["tblRefs"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    Db.DASS.Fill (Db.DS, "tblRefs");
                    CnnSS.Close ();
                    }
                return 1;
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                return 0;
                }
            }
        public static void GetNotes (int parentId, int parentType)
            {
            //tblxNotes: 0ID, 1NoteDatum, 2Note, 3Parent_ID, 4ParentType, 5Rtl, 6Done, 7User_ID, 8Shared
            //ParentTypes (get notes): 1:SNotes, 2:LNotes, 3:RNotes
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "SELECT ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, User_ID, Shared FROM Notes WHERE (Parent_ID = " + parentId.ToString () + " AND ParentType = " + parentType.ToString () + ") ORDER BY NoteDatum ASC;";
                    switch (parentType)
                        {
                        case 1:
                                {
                                Db.DS.Tables["tblSNotes"].Clear ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                                Db.DASS.Fill (Db.DS, "tblSNotes");
                                break;
                                }
                        case 2:
                                {
                                Db.DS.Tables["tblLNotes"].Clear ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                                Db.DASS.Fill (Db.DS, "tblLNotes");
                                break;
                                }
                        case 3:
                                {
                                Db.DS.Tables["tblRNotes"].Clear ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                                Db.DASS.Fill (Db.DS, "tblRNotes");
                                break;
                                }
                        }
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void GetSLinks (object SubProjectid)
            {
            try
                {
                Db.DS.Tables["tblLinks"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, SubProject_ID, Links.ID AS LinkID, Imp1, Imp2, Imp3, ImR FROM Papers INNER JOIN Links ON Papers.ID = Links.Paper_ID WHERE SubProject_ID = " + SubProjectid.ToString () + " ORDER BY Papers.PaperName DESC;", CnnSS);
                    Db.DASS.Fill (Db.DS, "tblLinks");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void GetRLinks (int refid)
            {
            Db.strSQL = "SELECT Links.ID, Paper_ID, SubProject_ID, SubProjectName, Imp1, Imp2, Imp3, ImR, user_ID FROM Projects INNER JOIN (SubProjects INNER JOIN Links ON SubProjects.ID = Links.SubProject_ID) ON Projects.ID = SubProjects.Project_ID WHERE (Paper_ID =" + refid.ToString () + ") AND (user_ID = " + User.Id + ") ORDER BY SubProjectName;";
            Db.DS.Tables["tblAssignments"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblAssignments");
                CnnSS.Close ();
                }
            }
        public static void GetImportantRefs (string Imx)
            {
            string strFilter = "";
            string strBoolTrue = "";
            //Imx: Imp1, Imp2, Imp3, ImR, ImpAll
            switch (Imx)
                {
                case "Imp1":
                        {
                        strFilter = "Imp1 = 1" + strBoolTrue;
                        break;
                        }
                case "Imp2":
                        {
                        strFilter = "Imp2 = 1" + strBoolTrue;
                        break;
                        }
                case "Imp3":
                        {
                        strFilter = "Imp3 = 1" + strBoolTrue;
                        break;
                        }
                case "ImR":
                        {
                        strFilter = "ImR = 1" + strBoolTrue;
                        break;
                        }
                case "ImpAll":
                        {
                        strFilter = "Imp1 = 1 OR Imp2 = 1 OR Imp3 = 1";
                        break;
                        }
                }
            try
                {
                Db.DS.Tables["tblRefs"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture From Papers INNER Join (Links INNER Join (Projects INNER Join SubProjects On Projects.ID = SubProjects.Project_ID) ON Links.SubProject_ID = SubProjects.ID) ON Papers.ID = Links.Paper_ID WHERE (user_ID = " + User.Id.ToString () + ") AND (" + strFilter + ") Order By PaperName DESC;", CnnSS);
                    Db.DASS.Fill (Db.DS, "tblRefs");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void GetListOfRefs ()
            {
            Client.DialogRequestParams = 3; //1:get Project 2:get SubProject 3:get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            switch (Client.DialogRequestParams)
                {
                case 0: //canceled
                        {
                        return;
                        }
                case 64: //bit7: 01000000: a project is selected
                        {
                        try
                            {
                            Db.DS.Tables["tblRefs"].Clear ();
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture From Papers INNER Join (Links INNER Join (Projects INNER Join SubProjects On Projects.ID = SubProjects.Project_ID) ON Links.SubProject_ID = SubProjects.ID) ON Papers.ID = Links.Paper_ID WHERE (Project_ID = " + Project.Id.ToString () + ") Order By PaperName DESC;", CnnSS);
                                Db.DASS.Fill (Db.DS, "tblRefs");
                                CnnSS.Close ();
                                }
                            }
                        catch (Exception ex)
                            {
                            }

                        break;
                        }
                case 32: //bit6: 00100000: a subproject is selected
                        {
                        try
                            {
                            Db.DS.Tables["tblRefs"].Clear ();
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("Select DISTINCT Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture From Papers INNER Join (Links INNER Join (Projects INNER Join SubProjects On Projects.ID = SubProjects.Project_ID) ON Links.SubProject_ID = SubProjects.ID) ON Papers.ID = Links.Paper_ID WHERE (SubProject_ID = " + SubProject.Id.ToString () + ") Order By PaperName DESC;", CnnSS);
                                Db.DASS.Fill (Db.DS, "tblRefs");
                                CnnSS.Close ();
                                }
                            }
                        catch (Exception ex)
                            {
                            }

                        break;
                        }
                }
            Db.DS.Tables["tblAssignments"].Clear ();
            Client.List5Mode = "Ref";
            }
        public static void GetSharedList (int projectid)
            {
            //get list of users that this project is already shared with them
            Db.DS.Tables["tblUserProject"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT User_Id, UsrName, UsrNote, Project_Id, ReadOnly FROM usrs JOIN User_Project ON usrs.ID = User_Project.User_Id WHERE Project_Id = " + Project.Id.ToString (), CnnSS);
                Db.DASS.Fill (Db.DS.Tables["tblUserProject"]);
                CnnSS.Close ();
                }
            }
        public static void AddNewProject (int userId)
            {
            // strProjectName | strProjectNote
            Client.DialogRequestParams = 1; //new project
            Project.IsActive = true; // active
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
                        cmdx.Parameters.AddWithValue ("@userid", userId.ToString ());
                        Project.Id = (int) cmdx.ExecuteScalar (); //was: int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    AddNewSubProject (Project.Id, "_" + Project.Name, "note"); // {0: auto add SubProjects for new Project | 1: add extra SubProjects for a already existing project}
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
        public static bool AddNewSubProject (int projectid, string projectname, string note)
            {
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "INSERT INTO SubProjects (SubProjectName, Notes, Project_ID) VALUES (@SubProjectName, @notes, @projectid); SELECT CAST (scope_identity() AS int)";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@SubProjectName", projectname);
                    cmdx.Parameters.AddWithValue ("@notes", note);
                    cmdx.Parameters.AddWithValue ("@projectid", projectid.ToString ());
                    SubProject.Id = (int) cmdx.ExecuteScalar ();
                    CnnSS.Close ();
                    }
                return true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                return false;
                }
            }
        public static void AddNewNote (string noteDateTime, string strNote, int parentId, int parentType, int userId)
            {
            //ParentType: 1:SubProject 2:Link 3:Ref
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                //notice that EexecuteScalar() should be used to retrieve ID of newly added rec
                CnnSS.Open ();
                Db.strSQL = "INSERT INTO Notes (NoteDatum, Note, Parent_ID, ParentType, User_ID, Shared) VALUES (@notedatum, @note, @parentid, @parenttype, @userid, 0); SELECT CAST(scope_identity() AS int)";
                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmdx.CommandType = CommandType.Text;
                cmdx.Parameters.AddWithValue ("@notedatum", noteDateTime);
                cmdx.Parameters.AddWithValue ("@note", strNote);
                cmdx.Parameters.AddWithValue ("@parentid", parentId.ToString ());
                cmdx.Parameters.AddWithValue ("@parenttype", parentType.ToString ());
                cmdx.Parameters.AddWithValue ("@userid", userId.ToString ());
                Note.Id = (int) cmdx.ExecuteScalar ();
                CnnSS.Close ();
                }
            }
        public static void EditAProject (int projectId)
            {
            if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                return;
            Client.DialogRequestParams = 9; //edit project
            My.MyProject.Forms.frmProject.ShowDialog ();
            try
                {
                if (Client.DialogRequestParams == 16) //save it
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "UPDATE Projects SET ProjectName=@ProjectName, Notes=@notes, Active=@active WHERE ID=@id";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@ProjectName", Project.Name);
                        cmdx.Parameters.AddWithValue ("@notes", Project.Note);
                        cmdx.Parameters.AddWithValue ("@active", Project.IsActive.ToString ());
                        cmdx.Parameters.AddWithValue ("@id", projectId.ToString ());
                        int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    Assign.GetSubProjects (Project.Id); //refresh list5
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void EditASubProject (int subprojectId)
            {
            if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                return;
            Client.DialogRequestParams = 10; //edit subproject
            My.MyProject.Forms.frmProject.ShowDialog ();
            try
                {
                if (Client.DialogRequestParams == 16) //save it
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "UPDATE SubProjects SET SubProjectName=@SubProjectName, Notes=@notes WHERE ID=@id";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@SubProjectName", Project.Name);
                        cmdx.Parameters.AddWithValue ("@notes", Project.Note);
                        cmdx.Parameters.AddWithValue ("@id", subprojectId.ToString ());
                        int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    Assign.GetSubProjects (Project.Id); //refresh list5
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void UpdateDateTime (int noteid, string notedatetime)
            {
            Db.strSQL = "UPDATE Notes SET NoteDatum=@datum WHERE ID=@id";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd.Parameters.AddWithValue ("@datum", notedatetime);
                cmd.Parameters.AddWithValue ("@id", noteid.ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        public static void ReplaceALink (int linkId, int subprojectId)
            {
            if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                return;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                Db.strSQL = "UPDATE Links SET SubProject_ID=@subprojectid WHERE ID=@id";
                CnnSS.Open ();
                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmdx.CommandType = CommandType.Text;
                cmdx.Parameters.AddWithValue ("@subprojectid", subprojectId);
                cmdx.Parameters.AddWithValue ("@id", linkId.ToString ());
                int ix = cmdx.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        public static void SetRefAttributes (int Attr)
            {
            //intAssign - intProd
            string strAttrx = "";
            // RefAttributes: 1111-1111 {ImR.Imp3.Imp2.Imp1.Lect.Man.Book.Paper}
            try
                {
                strAttrx = ((Ref.Attributes & 16) == 16) ? (strAttrx + "Imp1=1, ") : (strAttrx + "Imp1=0, ");
                strAttrx = ((Ref.Attributes & 32) == 32) ? (strAttrx + "Imp2=1, ") : (strAttrx + "Imp2=0, ");
                strAttrx = ((Ref.Attributes & 64) == 64) ? (strAttrx + "Imp3=1, ") : (strAttrx + "Imp3=0, ");
                strAttrx = ((Ref.Attributes & 128) == 128) ? (strAttrx + "ImR=1 ") : (strAttrx + "ImR=0 ");
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "UPDATE Links SET " + strAttrx + " WHERE ID=@id";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@id", Link.Id.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                strAttrx = "";
                if ((Ref.Attributes & 1) == 1)
                    strAttrx = strAttrx + "IsPaper=1, ";
                else
                    strAttrx = strAttrx + "IsPaper=0, ";
                if ((Ref.Attributes & 2) == 2)
                    strAttrx = strAttrx + "IsBook=1, ";
                else
                    strAttrx = strAttrx + "IsBook=0, ";
                if ((Ref.Attributes & 4) == 4)
                    strAttrx = strAttrx + "IsManual=1, ";
                else
                    strAttrx = strAttrx + "IsManual=0, ";
                if ((Ref.Attributes & 8) == 8)
                    strAttrx = strAttrx + "IsLecture=1 ";
                else
                    strAttrx = strAttrx + "IsLecture=0 ";
                Db.strSQL = "UPDATE Papers SET " + strAttrx + " WHERE ID=@id";
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@id", Ref.Id.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                }

            }
        public static void DeleteAProject (int prijectId)
            {
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "DELETE FROM Projects WHERE ID=@projectid";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@projectid", prijectId.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }

            }
        public static void DeleteASubProject (int subprojectId)
            {
            //check if this SubProjects was populated, if yes, dont delete it 
            try
                {
                GetSLinks (subprojectId);   //fills tblLinks for this subProject
                GetNotes (subprojectId, 1); //fills tblSNotes for this subProject
                if (Db.DS.Tables["tblLinks"].Rows.Count > 0 || Db.DS.Tables["tblSNotes"].Rows.Count > 0)
                    {
                    MessageBox.Show ("This SubProjects is not empty \r\n Replace (or Delete), then try again", "eLib", MessageBoxButtons.OK);
                    return;
                    }
                }
            catch (Exception ex)
                {
                // when list 5 is empty - ok nothing to do
                }
            DialogResult myansw = (DialogResult) MessageBox.Show ("Delete this subProject?", "eLib", MessageBoxButtons.YesNo);
            if ((int) myansw == (int) Constants.vbYes)
                {
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "DELETE FROM SubProjects WHERE ID=@SubProjectid";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@SubProjectid", SubProject.Id.ToString ());
                        int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    Assign.GetSubProjects (Project.Id); // refresh list4
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            }
        public static string DeleteNote (int noteId, bool requireConfirm)
            {
            if (Assign.CheckReadOnlyAccess (Project.Id) == 1)
                {
                //cannot delete ReadOnlyAccess
                return "readonly";
                }
            else
                {
                //ok, CheckReadOnlyAccess was 0
                try
                    {
                    //A: check NoteNet table
                    int cnt = 0;
                    int delMode = 0;
                    Db.strSQL = "SELECT COUNT (ID) FROM NoteNet WHERE NoteA_ID =" + noteId.ToString () + " OR NoteB_ID = " + noteId.ToString ();
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cnt = (int) cmd.ExecuteScalar ();
                        CnnSS.Close ();
                        }
                    //B: confirm?
                    if (!requireConfirm && (cnt == 0))
                        {
                        delMode = 1; //delete the note immediately
                        }
                    else if (requireConfirm && (cnt == 0))
                        {
                        delMode = 2; //if confirmed; delete!
                        }
                    else if (cnt > 0)
                        {
                        delMode = 3; //if confirmed, delete the note and its links
                        }
                    switch (delMode)
                        {
                        case 1:
                                {
                                //delete the note immediately
                                break;
                                }
                        case 2:
                                {
                                DialogResult myansw = (DialogResult) MessageBox.Show ("Delete this note?", "eLib", MessageBoxButtons.OKCancel);
                                if (myansw == DialogResult.Cancel)
                                    {
                                    return "cancelled";
                                    }
                                break;
                                }
                        case 3:
                                {
                                if (requireConfirm)
                                    {
                                    //confirm, then delete the note and its links
                                    string msg = (cnt == 1) ? "Notice: This note is linked to one another note (NoteNet).\n\nYes = delete the note and its links\nNo = show MindMap\nCancel = exit" : "Notice: This note is linked to " + cnt.ToString () + " other notes in MindMap\n\nYes = delete this note and all its " + cnt.ToString () + " links\nNo = show MindMap\n\nCancel = exit";
                                    DialogResult myansw = (DialogResult) MessageBox.Show (msg, "eLib", MessageBoxButtons.YesNoCancel);
                                    switch (myansw)
                                        {
                                        case DialogResult.No:
                                                {
                                                return "notenet";
                                                }
                                        case DialogResult.Cancel:
                                                {
                                                return "cancelled";
                                                }
                                        }
                                    }
                                break;
                                }
                        default:
                                {
                                return "error";
                                }
                        }
                    //C: delete the note (and links if any)
                    Db.strSQL = "DELETE FROM NoteNet WHERE (NoteA_Id=@noteid1 OR NoteB_Id=@noteid2); DELETE FROM Notes WHERE ID=@noteid3";
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@noteid1", noteId.ToString ());
                        cmdx.Parameters.AddWithValue ("@noteid2", noteId.ToString ());
                        cmdx.Parameters.AddWithValue ("@noteid3", noteId.ToString ());
                        int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    return "deleted";
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    return "error";
                    }
                }
            }
        public static void DeleteAllSubProjectNotes (int subprojectId)
            {
            DialogResult myansw = (DialogResult) MessageBox.Show ("Delete  'ALL' notes?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if ((int) myansw == (int) Constants.vbYes)
                {
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "DELETE FROM Notes WHERE Parent_ID=@parentid";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@parentid", subprojectId.ToString ());
                        int ix = cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    }
                }
            }
        public static bool DeleteALink (int linkId, bool requireConfirm)
            {
            if (requireConfirm)
                {
                DialogResult myansw = (DialogResult) MessageBox.Show ("Delete this Link?", "eLib", MessageBoxButtons.YesNo);
                if (myansw == DialogResult.No)
                    {
                    return false;
                    }
                }
            if (Db.DS.Tables["tblLNotes"].Rows.Count > 0)
                {
                DialogResult myansw = MessageBox.Show ("Notice: This Link has some Notes !\n\nNotes will be Deleteded", "eLib", MessageBoxButtons.OKCancel);
                if (myansw == DialogResult.Cancel)
                    {
                    return false;
                    }
                }
            //start deleting
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "DELETE FROM Links WHERE ID=@linkid";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@linkid", linkId.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                //delete (one by one) notes of this Link!
                DataTable temp_dt = new DataTable ();
                temp_dt.Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Notes.ID FROM Notes WHERE Parent_ID=" + linkId.ToString () + " AND ParentType=2;", CnnSS);
                    Db.DASS.Fill (temp_dt);
                    CnnSS.Close ();
                    }
                foreach (DataRow r in temp_dt.Rows)
                    {
                    DeleteNote ((Convert.ToInt32 (r[0])), false);
                    }
                return true;
                }
            catch (Exception ex)
                {
                return false;
                }
            }
        public static bool DeleteARef (int refId, bool requireConfirm)
            {
            if (requireConfirm)
                {
                DialogResult myansw = MessageBox.Show ("Delete this Ref?", "eLib", MessageBoxButtons.YesNo);
                if (myansw == DialogResult.No)
                    {
                    return false;
                    }
                }
            string confirmMessage = "";
            if (Db.DS.Tables["tblRNotes"].Rows.Count > 0)
                {
                confirmMessage += "\n\nNotice: This Ref is Linked to some subProjects! (Links will be deleted)";
                }
            if (Db.DS.Tables["tblAssignments"].Rows.Count > 0)
                {
                confirmMessage += "\n\nNotice: This Ref has Notes! (Notes will be deleted)";
                }
            if (confirmMessage != "")
                {
                DialogResult myansw2 = MessageBox.Show (confirmMessage + "\n\nContinue deleting?", "eLib", MessageBoxButtons.OKCancel);
                if (myansw2 == DialogResult.Cancel)
                    {
                    return false;
                    }
                }
            //start deleting
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "DELETE FROM Papers WHERE ID=@refid";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@refid", refId.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                //delete (one by one) notes of this Ref!
                DataTable temp_dt = new DataTable ();
                temp_dt.Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Notes.ID FROM Notes WHERE Parent_ID=" + refId.ToString () + " AND ParentType=3;", CnnSS);
                    Db.DASS.Fill (temp_dt);
                    CnnSS.Close ();
                    }
                foreach (DataRow r in temp_dt.Rows)
                    {
                    DeleteNote ((Convert.ToInt32 (r[0])), false);
                    }
                //delete (one by one) Links of this Ref!
                temp_dt.Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT Links.ID FROM Links WHERE Paper_ID=" + refId.ToString (), CnnSS);
                    Db.DASS.Fill (temp_dt);
                    CnnSS.Close ();
                    }
                foreach (DataRow r in temp_dt.Rows)
                    {
                    DeleteALink ((Convert.ToInt32 (r[0])), false);
                    }
                return true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return false;
                }
            }
        public static void ReplaceASubProject (int subprojectId, int projectId)
            {
            Db.strSQL = "UPDATE SubProjects SET Project_ID=@projectid WHERE ID=@id";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd.Parameters.AddWithValue ("@projectid", projectId.ToString ());
                cmd.Parameters.AddWithValue ("@id", subprojectId.ToString ());
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
            }
        public static void ReplaceASubProjectNote (int noteId)
            {
            if (Assign.CheckReadOnlyAccess (Project.Id) == 0)
                {
                Client.DialogRequestParams = 2; //1:get Project 2:get SubProject 3:get Project or SubProject
                My.MyProject.Forms.frmChooseProject.ShowDialog ();
                //replace current SubProjectNote to selected SubProject
                if (Client.DialogRequestParams == 32) //32: A SubProjects is selected from dialog
                    {
                    Db.strSQL = "UPDATE Notes SET Parent_ID=@parentid WHERE ID=@id";
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmd.Parameters.AddWithValue ("@parentid", SubProject.Id.ToString ());
                        cmd.Parameters.AddWithValue ("@id", noteId.ToString ());
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
                    }
                }
            }
        public static void ReportProjects (string header)
            {
            //Report Projects
            int iProj = default, iProd = default;
            try
                {
                FileSystem.FileOpen (1, Application.StartupPath + "elibReport.html", OpenMode.Output);
                //header
                Assign.AddHeader2Report (header);
                var loopTo = Db.DS.Tables["tblProject"].Rows.Count - 1;
                for (iProj = 0; iProj <= loopTo; iProj++)
                    {
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Blue; font-family:tahoma; font-size:16px'>Project: ", Db.DS.Tables["tblProject"].Rows[iProj][1]), " "));
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<span style='color:Black; font-family:tahoma; font-size:12px'> (", Db.DS.Tables["tblProject"].Rows[iProj][2]), ")</span>"));
                    //Read Data
                    Assign.GetSubProjects (Convert.ToInt32 (Db.DS.Tables["tblProject"].Rows[iProj][0]));
                    var loopTo1 = Db.DS.Tables["tblSubProject"].Rows.Count - 1;
                    for (iProd = 0; iProd <= loopTo1; iProd++)
                        {
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:12px'> - ", Db.DS.Tables["tblSubProject"].Rows[iProd][1]), " "));
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<span style='color:Green; font-family:tahoma; font-size:10px'> ///", Db.DS.Tables["tblSubProject"].Rows[iProd][2]), "</span>"));
                        }
                    FileSystem.PrintLine (1, "<hr>");
                    }
                //footer
                Assign.AddFooter2Report ();
                FileSystem.FileClose (1);
                Interaction.Shell ("explorer.exe " + Application.StartupPath + "elibreport.html");
                }
            catch (Exception ex)
                {
                MessageBox.Show (iProj.ToString () + " / " + iProd.ToString () + " / " + ex.ToString ());
                FileSystem.FileClose (1);
                return;
                }
            }
        public static void ReportThisSubProject (int subprojectId)
            {
            //Report a SubProjects (subProject)
            int iProj = default, iRef, iNote;
            try
                {
                FileSystem.FileOpen (1, Application.StartupPath + "elibReport.html", OpenMode.Output);
                //header
                Assign.AddHeader2Report ("Report subProject: '" + SubProject.Name + "' of Project: '" + Project.Name + "' of User: ");
                //data
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Blue; font-family:tahoma; font-size:16px'>Project: ", Db.DS.Tables["tblSubProject"].Rows[subprojectId][1]), " "));
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<span style='color:Black; font-family:tahoma; font-size:12px'> [ ", Db.DS.Tables["tblSubProject"].Rows[subprojectId][2]), " ]</span>"));
                //Read Data
                Assign.GetNotes (Convert.ToInt32 (Db.DS.Tables["tblSubProject"].Rows[subprojectId][0]), 1);
                Assign.GetSLinks (Db.DS.Tables["tblSubProject"].Rows[subprojectId][0]);
                FileSystem.PrintLine (1, "<p style='color:Blue; font-family:tahoma; font-size:14px'>Refs: </p>");
                try
                    {
                    //A: Report Refs
                    var loopTo = Db.DS.Tables["tblLinks"].Rows.Count - 1;
                    for (iRef = 0; iRef <= loopTo; iRef++)
                        {
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:12px'> - ", Db.DS.Tables["tblLinks"].Rows[iRef][1]), " "));
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<span style='color:DarkCyan; font-family:tahoma; font-size:12px'> ///", Db.DS.Tables["tblLinks"].Rows[iRef][6]), "</span>"));
                        }
                    }
                catch (Exception ex)
                    {
                    }
                //B: Report Notes
                FileSystem.PrintLine (1, "<p style='color:Blue; font-family:tahoma; font-size:12px'>Notes: </p>");
                try
                    {
                    var loopTo1 = Db.DS.Tables["tblSNotes"].Rows.Count - 1;
                    for (iNote = 0; iNote <= loopTo1; iNote++)
                        {
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:SlateGray; font-family:tahoma; font-size:12px'> - ", Db.DS.Tables["tblSNotes"].Rows[iNote][1]), " "));
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<span style='color:DarkCyan; font-family:tahoma; font-size:12px'> ///", Db.DS.Tables["tblSNotes"].Rows[iNote][2]), "</span>"));
                        }
                    FileSystem.PrintLine (1, "<hr>");
                    }
                catch (Exception ex)
                    {
                    }
                //footer
                Assign.AddFooter2Report ();
                FileSystem.FileClose (1);
                Interaction.Shell ("explorer.exe " + Application.StartupPath + "elibreport.html");
                }
            catch (Exception ex)
                {
                MessageBox.Show (iProj.ToString () + " / " + subprojectId.ToString () + " / " + ex.ToString ());
                FileSystem.FileClose (1);
                return;
                }
            }
        public static void ReportAllNotesInASubproject ()
            {
            //Report a SubProjects (subProject)
            int iProj = default, iProd = default, iRef, iNote;
            try
                {
                FileSystem.FileOpen (1, Application.StartupPath + "elibReport.html", OpenMode.Output);
                //header
                Assign.AddHeader2Report ("Report Project: '" + Project.Name + "' of User: ");
                //data
                var loopTo = Db.DS.Tables["tblSubProject"].Rows.Count - 1;
                for (iProd = 0; iProd <= loopTo; iProd++)
                    {
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Blue; font-family:tahoma; font-size:16px'>Project: ", Db.DS.Tables["tblSubProject"].Rows[iProd][1]), " "));
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<span style='color:Black; font-family:tahoma; font-size:12px'> [ ", Db.DS.Tables["tblSubProject"].Rows[iProd][2]), " ]</span>"));
                    //Read Data
                    Assign.GetNotes (Convert.ToInt32 (Db.DS.Tables["tblSubProject"].Rows[iProd][0]), 1);
                    Assign.GetSLinks (Db.DS.Tables["tblSubProject"].Rows[iProd][0]);
                    //A: Report Refs
                    FileSystem.PrintLine (1, "<p style='color:Blue; font-family:tahoma; font-size:14px'>Refs: </p>");
                    try
                        {
                        var loopTo1 = Db.DS.Tables["tblLinks"].Rows.Count - 1;
                        for (iRef = 0; iRef <= loopTo1; iRef++)
                            {
                            FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:12px'> - ", Db.DS.Tables["tblLinks"].Rows[iRef][1]), " "));
                            FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<span style='color:DarkCyan; font-family:tahoma; font-size:12px'> ///", Db.DS.Tables["tblLinks"].Rows[iRef][6]), "</span>"));
                            }
                        }
                    catch (Exception ex)
                        {
                        }
                    //B: Report Notes
                    FileSystem.PrintLine (1, "<p style='color:Blue; font-family:tahoma; font-size:12px'>Notes: </p>");
                    try
                        {
                        var loopTo2 = Db.DS.Tables["tblSNotes"].Rows.Count - 1;
                        for (iNote = 0; iNote <= loopTo2; iNote++)
                            {
                            FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:SlateGray; font-family:tahoma; font-size:12px'> - ", Db.DS.Tables["tblSNotes"].Rows[iNote][1]), " "));
                            FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<span style='color:DarkCyan; font-family:tahoma; font-size:12px'> ///", Db.DS.Tables["tblSNotes"].Rows[iNote][2]), "</span>"));
                            }
                        FileSystem.PrintLine (1, "<hr>");
                        }
                    catch (Exception ex)
                        {
                        }
                    }
                //footer
                Assign.AddFooter2Report ();
                FileSystem.FileClose (1);
                Interaction.Shell ("explorer.exe " + Application.StartupPath + "elibreport.html");
                }
            catch (Exception ex)
                {
                MessageBox.Show (iProj.ToString () + " / " + iProd.ToString () + " / " + ex.ToString ());
                FileSystem.FileClose (1);
                return;
                }
            }
        public static void AddHeader2Report (string strTitle)
            {
            FileSystem.PrintLine (1, "<head><title>eLib Report</title><style>table, th, td {border: 1px solid;}</style></head>");
            FileSystem.PrintLine (1, "<body>");
            FileSystem.PrintLine (1, "<p style='color:Black; font-family:tahoma; font-size:12px; text-align: center'>[" + DateTime.Now.ToString ("yyyy.MM.dd - HH:mm") + "]</p>");
            FileSystem.PrintLine (1, "<p style='color:Black; font-family:tahoma; font-size:12px; text-align: center'>eLib - " + strTitle + " " + User.Name + "</p>");
            FileSystem.PrintLine (1, "<p style='color:Black; font-family:tahoma; font-size:12px; text-align: center'>DB Type: " + Report.Caption + " - BackEnd: " + Db.CurrentDbVersion + "</p><hr>");
            }
        public static void AddFooter2Report ()
            {
            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'></p><br>");
            FileSystem.PrintLine (1, "<style>table, th,td {border: 1px solid;} .button {border: none;color: black;padding: 5px 20px;Text-align: center;Text-decoration: none;display: inline-block;font-family:Tahoma;Font-Size: 12px;margin: 10px 5px;cursor: pointer;}.button1 {background-Color: lightsilver; border-radius: 4px;}.button2 {background-Color: lightgreen; border-radius: 4px;}.button3 {background-Color: salmon; border-radius: 4px;}</style>");
            string Footerx = "<a href=\"http://msht.ir/app_eLib/eLib_00.html\">eLib</a> Desktop App <a href=\"http://msht.ir\">[ www.msht.ir ]</a> , Faculty of Science, <a href=\"https://sku.ac.ir\">SKU</a>. Developer: <a href=\"https://sku.ac.ir/en/DepartmentGroup/ProfessorForm.aspx?ID=143\">Dr. Majid Sharifi-Tehrani</a> (1400-1403 / 2021-2025)";
            string Footer = "<p style='font-family:tahoma; font-size:10px; text-align: center'>" + Footerx + "<hr> <button class=\"button button1\" onclick=\"location.href='http://msht.ir/app_eLib/eLib_00.html';\">eLib guide</button> <button class=\"button button1\" onclick=\"location.href='http://msht.ir';\">website</button> <button class=\"button button1\" onclick=\"location.href='https://sku.ac.ir/en/DepartmentGroup/ProfessorForm.aspx?ID=143';\">about author</button>  <button class=\"button button3\" onclick=\"self.close();\">close</button> <hr></p>";
            FileSystem.PrintLine (1, Footer);
            FileSystem.PrintLine (1, "</body></html>");
            }
        public static void ShowCollectedNotes ()
            {
            //Open Collected data to read
            string strLine = "";
            try
                {
                FileSystem.FileOpen (1, Application.StartupPath + "elibCollect.html", OpenMode.Output);
                FileSystem.FileOpen (2, Application.StartupPath + "elibCollect", OpenMode.Input);
                FileSystem.PrintLine (1, "<head><title>eLib Collect</title><style>table, th, td {border: 1px solid;}</style></head>");
                FileSystem.PrintLine (1, "<body>");
                //header
                AddHeader2Report ("Collected Notes by User: ");
                while (!FileSystem.EOF (2))
                    {
                    strLine = FileSystem.LineInput (2);
                    switch (Strings.Left (strLine, 1))
                        {
                        case ".":
                                {
                                FileSystem.PrintLine (1, "<p style='color:Green; font-family:tahoma; font-size:14px'>" + strLine + "</p>");
                                break;
                                }

                        default:
                                {
                                FileSystem.PrintLine (1, "<p style='color:Black; font-family:tahoma; font-size:14px'>" + strLine + "</p>");
                                break;
                                }
                        }
                    }
                //footer
                AddFooter2Report ();
                FileSystem.FileClose (1);
                FileSystem.FileClose (2);
                Interaction.Shell ("explorer.exe " + Application.StartupPath + "elibCollect.html");
                DialogResult myansw = (DialogResult) MessageBox.Show ("Keep Data ?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if ((int) myansw == (int) Constants.vbNo)
                    {
                    try
                        {
                        System.IO.File.Delete (Application.StartupPath + "elibCollect");
                        System.IO.File.Delete (Application.StartupPath + "elibCollect.html");
                        }
                    catch (Exception ex)
                        {
                        }
                    }
                }
            catch (Exception ex)
                {
                //lblRefStatus2.Text = "Collected Data not Found!";
                return;
                }
            }
        public static void DoSearchRefs (string searchString)
            {
            Ref.TypeCode = 15; //00001111 for lmbp
            string KeyxA = "";
            string Keyx1 = "";
            string Keyx2 = "";
            string Keyx3 = "";
            string Keyx4 = "";
            string Fltr1 = ""; //search PaperName
            string Fltr2 = ""; //filter reftypes 
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
                case 0: //no space; one key
                        {
                        Fltr1 = "(Papers.PaperName Like '%" + KeyxA + "%')";
                        break;
                        }
                case 1: // 1 space; 2 keys
                        {
                        // Keyx1 = Mid(KeyxA, 1, spcz(1) - 1)
                        Keyx1 = Strings.Left (KeyxA, spcz[1] - 1);
                        Keyx2 = Strings.Mid (KeyxA, spcz[1] + 1);
                        Fltr1 = "(Papers.PaperName Like '%" + Keyx1 + "%') AND ";
                        Fltr1 = Fltr1 + "(Papers.PaperName Like '%" + Keyx2 + "%')";
                        break;
                        }
                case 2: // 2 spaces; 3 keys
                        {
                        Keyx1 = Strings.Left (KeyxA, spcz[1] - 1);
                        Keyx2 = Strings.Mid (KeyxA, spcz[1] + 1, spcz[2] - spcz[1] - 1);
                        Keyx3 = Strings.Mid (KeyxA, spcz[2] + 1);
                        Fltr1 = "(Papers.PaperName Like '%" + Keyx1 + "%') AND ";
                        Fltr1 = Fltr1 + "(Papers.PaperName Like '%" + Keyx2 + "%') AND ";
                        Fltr1 = Fltr1 + "(Papers.PaperName Like '%" + Keyx3 + "%')";
                        break;
                        }
                case 3:
                case 4:
                        {
                        Keyx1 = Strings.Left (KeyxA, spcz[1] - 1);
                        Keyx2 = Strings.Mid (KeyxA, spcz[1] + 1, spcz[2] - spcz[1] - 1);
                        Keyx3 = Strings.Mid (KeyxA, spcz[2] + 1, spcz[3] - spcz[2] - 1);
                        Keyx4 = Strings.Mid (KeyxA, spcz[3] + 1);
                        Fltr1 = "(Papers.PaperName Like '%" + Keyx1 + "%') AND ";
                        Fltr1 = Fltr1 + "(Papers.PaperName Like '%" + Keyx2 + "%') AND ";
                        Fltr1 = Fltr1 + "(Papers.PaperName Like '%" + Keyx3 + "%') AND ";
                        Fltr1 = Fltr1 + "(Papers.PaperName Like '%" + Keyx4 + "%')";
                        break;
                        }
                }
            //Search in which Ref types?   [0b 1111 bits:LMBP]
            if (Ref.TypeCode != 15) //15: 0b1111 : All types are selected
                {
                //start filter on intreftype
                Fltr2 = Fltr2 + " AND (";
                switch (Ref.TypeCode)
                    {
                    case 1:  //---P
                            {
                            Fltr2 = Fltr2 + "IsPaper=1";
                            break;
                            }
                    case 2:   //--B-
                            {
                            Fltr2 = Fltr2 + "IsBook=1";
                            break;
                            }
                    case 3:   //--BP
                            {
                            Fltr2 = Fltr2 + "IsPaper=1 OR IsBook=1";
                            break;
                            }
                    case 4:   //-M--
                            {
                            Fltr2 = Fltr2 + "IsManual=1";
                            break;
                            }
                    case 5:   //-M-P
                            {
                            Fltr2 = Fltr2 + "IsPaper=1 OR IsManual=1";
                            break;
                            }
                    case 6:   //-MB-
                            {
                            Fltr2 = Fltr2 + "IsBook=1 OR IsManual=1";
                            break;
                            }
                    case 7:   //-MBP
                            {
                            Fltr2 = Fltr2 + "IsLecture=0";
                            break;
                            }
                    case 8:   //L---
                            {
                            Fltr2 = Fltr2 + "IsLecture=1";
                            break;
                            }
                    case 9:   //L--P
                            {
                            Fltr2 = Fltr2 + "IsLecture=1 OR IsPaper=1";
                            break;
                            }
                    case 10:  //L-B-
                            {
                            Fltr2 = Fltr2 + "IsLecture=1 OR IsBook=1";
                            break;
                            }
                    case 11:  //L-BP
                            {
                            Fltr2 = Fltr2 + "IsManual=0";
                            break;
                            }
                    case 12:  //LM--
                            {
                            Fltr2 = Fltr2 + "IsLecture=1 OR IsManual=1";
                            break;
                            }
                    case 13:  //LM-P
                            {
                            Fltr2 = Fltr2 + "IsBook=0";
                            break;
                            }
                    case 14:  //LMB-
                            {
                            Fltr2 = Fltr2 + "IsPaper=0";
                            break;
                            }
                    }
                Fltr2 = Fltr2 + ")";
                //finish filter on intReftype
                }
            //MessageBox.Show ("SN: " + Client.DriveSN.ToString());
            Db.strSQL = "SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture FROM Papers LEFT JOIN Notes ON Notes.Parent_ID = papers.ID WHERE (" + Fltr1 + Fltr2 + ") ORDER BY Papers.PaperName DESC;";
            //Do Query
            try
                {
                Db.DS.Tables["tblRefs"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    Db.DASS.Fill (Db.DS, "tblRefs");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show (ex.ToString ());
                return;
                }
            }
        public static void DoSearchNotes (string searchString, int parentType)
            {
            //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
            //MessageBox.Show ("eLib.DoSearchNotes: mode= " + Assign.Mode.ToString () + "    Parent Type= " + parentType.ToString());
            string KeyxA = "";
            string Keyx1 = "";
            string Keyx2 = "";
            string Keyx3 = "";
            string Keyx4 = "";
            string Fltr1 = "";
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
                case 0: //no space; one key
                        {
                        Fltr1 = "(Notes.Note Like '%" + KeyxA + "%')";
                        break;
                        }
                case 1: // 1 space; 2 keys
                        {
                        // Keyx1 = Mid(KeyxA, 1, spcz(1) - 1)
                        Keyx1 = Strings.Left (KeyxA, spcz[1] - 1);
                        Keyx2 = Strings.Mid (KeyxA, spcz[1] + 1);
                        Fltr1 = "(Notes.Note Like '%" + Keyx1 + "%') AND ";
                        Fltr1 = Fltr1 + "(Notes.Note Like '%" + Keyx2 + "%')";
                        break;
                        }
                case 2: // 2 spaces; 3 keys
                        {
                        Keyx1 = Strings.Left (KeyxA, spcz[1] - 1);
                        Keyx2 = Strings.Mid (KeyxA, spcz[1] + 1, spcz[2] - spcz[1] - 1);
                        Keyx3 = Strings.Mid (KeyxA, spcz[2] + 1);
                        Fltr1 = "(Notes.Note Like '%" + Keyx1 + "%') AND ";
                        Fltr1 = Fltr1 + "(Notes.Note Like '%" + Keyx2 + "%') AND ";
                        Fltr1 = Fltr1 + "(Notes.Note Like '%" + Keyx3 + "%')";
                        break;
                        }
                case 3:
                case 4:
                        {
                        Keyx1 = Strings.Left (KeyxA, spcz[1] - 1);
                        Keyx2 = Strings.Mid (KeyxA, spcz[1] + 1, spcz[2] - spcz[1] - 1);
                        Keyx3 = Strings.Mid (KeyxA, spcz[2] + 1, spcz[3] - spcz[2] - 1);
                        Keyx4 = Strings.Mid (KeyxA, spcz[3] + 1);
                        Fltr1 = "(Notes.Note Like '%" + Keyx1 + "%') AND ";
                        Fltr1 = Fltr1 + "(Notes.Note Like '%" + Keyx2 + "%') AND ";
                        Fltr1 = Fltr1 + "(Notes.Note Like '%" + Keyx3 + "%') AND ";
                        Fltr1 = Fltr1 + "(Notes.Note Like '%" + Keyx4 + "%')";
                        break;
                        }
                }
            //notes.parentTypes: 1:SubProject 2:Link 3:Ref 4:AllTypes
            Db.DS.Tables["tblNotesCount"].Clear ();
            //0 sqlString for FNotes
            //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
            string sqlFNotes = "SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID";
            sqlFNotes += " WHERE (" + Fltr1 + ") AND (Notes.ParentType = 1)";
            sqlFNotes += " ORDER BY Notes.NoteDatum;";
            //1 sqlString for SNotes
            //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
            string sqlSNotes = "SELECT Notes.ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, Notes.User_ID, Shared FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON SubProjects.Project_ID = Projects.ID";
            sqlSNotes += " WHERE (" + Fltr1 + ") AND (Notes.ParentType = 1) AND (Notes.User_ID = " + User.Id.ToString () + " OR Projects.ID IN (SELECT Project_Id FROM User_Project WHERE User_Project.User_Id = " + User.Id.ToString () + " AND User_Project.Project_Id = Projects.ID))";
            //2 sqlString for LNotes
            //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
            string sqlLNotes = " SELECT Notes.ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, Notes.User_ID, Shared FROM Notes INNER JOIN Links ON Parent_ID = Links.ID INNER JOIN SubProjects ON Links.SubProject_ID = SubProjects.ID INNER JOIN Projects ON SubProjects.Project_ID = Projects.ID";
            sqlLNotes += " WHERE (" + Fltr1 + ") AND (Notes.ParentType = 2) AND (Notes.User_ID = " + User.Id.ToString () + " OR Projects.ID IN (SELECT Project_Id FROM User_Project WHERE User_Project.User_Id = " + User.Id.ToString () + " AND User_Project.Project_Id = Projects.ID))";
            //3 sqlString for RNotes
            //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
            string sqlRNotes = " SELECT Notes.ID, NoteDatum, Note, Parent_ID, ParentType, Rtl, Done, Notes.User_ID, Shared FROM Notes";
            sqlRNotes += " WHERE (" + Fltr1 + ") AND (Notes.ParentType = 3)";
            Db.strSQL = "";
            switch (parentType)
                {
                case 0:  //B: f-notes?
                        {
                        Db.strSQL = sqlFNotes;
                        break;
                        }
                case 1: //B: s-notes
                        {
                        Db.strSQL = sqlSNotes + " ORDER BY Notes.NoteDatum;";
                        break;
                        }
                case 2: //B: l-notes
                        {
                        Db.strSQL = sqlLNotes + " ORDER BY Notes.NoteDatum;";
                        break;
                        }
                case 3: //B: r-notes
                        {
                        Db.strSQL = sqlRNotes + " ORDER BY Notes.NoteDatum;";
                        break;
                        }
                case 4: //B: slr-notes
                        {
                        //ParentType (search): {0:SubProjectForFNotes 1:SubProjectForSNotes 2:LinkForLNotes 3:RefForRNotes 4:AllNoteTypes(SLR)}
                        Db.strSQL = sqlSNotes + " UNION " + sqlLNotes + " UNION " + sqlRNotes + " ORDER BY Notes.NoteDatum;";
                        break;
                        }
                }
            //Do Query
            try
                {
                Db.DS.Tables["tblNotesCount"].Clear ();
                Db.DS.Tables["tblRNotes"].Clear ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    switch (parentType)
                        {
                        case 0:
                                {
                                //f-notes
                                Db.DS.Tables["tblNotesCount"].Clear ();
                                Db.DASS.Fill (Db.DS, "tblNotesCount");
                                break;
                                }
                        case 1:
                                {
                                Db.DS.Tables["tblSNotes"].Clear ();
                                Db.DASS.Fill (Db.DS, "tblSNotes");
                                break;
                                }
                        case 2:
                                {
                                Db.DS.Tables["tblLNotes"].Clear ();
                                Db.DASS.Fill (Db.DS, "tblLNotes");
                                break;
                                }
                        case 3:
                                {
                                Db.DS.Tables["tblRNotes"].Clear ();
                                Db.DASS.Fill (Db.DS, "tblRNotes");
                                break;
                                }
                        case 4:
                                {
                                //all other note types (s,l,r)
                                //notice: we use r-notes for this mode (allTypes)
                                Db.DS.Tables["tblRNotes"].Clear ();
                                Db.DASS.Fill (Db.DS, "tblRNotes");
                                break;
                                }
                        }
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void SetDefaultUserInterface (int intInterface)
            {
            Db.strSQL = "UPDATE Usrs SET UsrInterface=@usrinterface WHERE ID=@id";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd.Parameters.AddWithValue ("@usrinterface", intInterface.ToString ());
                cmd.Parameters.AddWithValue ("@id", User.Id.ToString ());
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
            }
        public static void ShowOfflineHelp (string param)
            {
            //Help
            try
                {
                switch (param)
                    {
                    case "En":
                            {
                            FileSystem.FileOpen (1, Application.StartupPath + @"\eLib_Guide.html", OpenMode.Output);
                            FileSystem.PrintLine (1, "<html dir=\"ltr\">");
                            FileSystem.PrintLine (1, "<head>");
                            FileSystem.PrintLine (1, "<title>Guide</title>");
                            FileSystem.PrintLine (1, "</head>");
                            FileSystem.PrintLine (1, "<body>");
                            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>University of Shahrekord. Faculty of Science, Dr. Majid SharifiTehrani</p>");
                            FileSystem.PrintLine (1, "<hr>");
                            FileSystem.PrintLine (1, "<p style='color:blue;font-family:tahoma; font-size:14px'>eLib Guide<br></p>");
                            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><Quick list</p>");
                            //start
                            FileSystem.PrintLine (1, "<H3>cmds:</H3>");
                            FileSystem.PrintLine (1, "<hr>");
                            FileSystem.PrintLine (1, "<p><b>-? :</b> Shows an inline help inside the Search TextBox</p>");
                            FileSystem.PrintLine (1, "<p><b>-Help: -- Help: En :</b> Shows an offline help in English language</p>");
                            FileSystem.PrintLine (1, "<p><b>-Help: -- Help: Fa :</b> Shows an offline help in Farsi language</p>");
                            FileSystem.PrintLine (1, "<p><b>-Scan :</b> Run San command to re-bulid list of Refs in the eLib Repository. Each user has their own Depository that may overlap with other uses</p>");
                            FileSystem.PrintLine (1, "");
                            FileSystem.PrintLine (1, "<p><b>-Map :</b> Shows the selected note in MindMap. User can link a note to other existing notes of different types</p>");
                            FileSystem.PrintLine (1, "<p><b>-ImR :</b> Show refs that are tagged by the user as ImR (ImR: I am Reading this ref) </p>");
                            FileSystem.PrintLine (1, "<p>-<b>Imp1:</b> Show refs that are tagged by the user as imp1 (imp1: Important ref level 1)</p>");
                            FileSystem.PrintLine (1, "<p><b>-Imp2:</b> Show refs that are tagged by the user as imp2 (imp2: Important ref level 2)</p>");
                            FileSystem.PrintLine (1, "<p><b>-Imp3:</b> Show refs that are tagged by the user as imp3 (imp3: Important ref level 3)</p>");
                            FileSystem.PrintLine (1, "<p><b>-Shelf:</b> Lets selecting a Project or subProject, and shows list of the refs linked to them</p>");
                            FileSystem.PrintLine (1, "<p><b>-Up :</b> Show Upcoming notes. Upcoming notes are all notes of today and the three next days</p>");
                            FileSystem.PrintLine (1, "<p><b>-Focus:</b> Show those notes with 'Pending' status remained from 3 past days, plus all notes of today and the three next days</p>");
                            FileSystem.PrintLine (1, "");
                            FileSystem.PrintLine (1, "<p><b>-Fam:</b> For a selected note, shows its Parent and its sibling notes</p>");
                            FileSystem.PrintLine (1, "<p><b>-Proj --Show Projects: + :</b> Show active projects</p>");
                            FileSystem.PrintLine (1, "<p><b>-Proj --Show Projects: - :</b> Show inactive projects</p>");
                            FileSystem.PrintLine (1, "<p><b>-Proj --Show Projects: a :</b> Show all projects</p>");
                            FileSystem.PrintLine (1, "");
                            FileSystem.PrintLine (1, "<p><b>-Edit:</b> Edit selected note in Note-Editor</p>");
                            FileSystem.PrintLine (1, "<p><b>-Date:</b> Change the time and date of the selected note</p>");
                            FileSystem.PrintLine (1, "");
                            FileSystem.PrintLine (1, "<p><b>-Folder:</b> Lets browse the HDD to explore the documents in different parts of the depository</p>");
                            FileSystem.PrintLine (1, "<p><b>-Import:</b> let a pdf (doc,...) be imported to the eLib</p>");
                            FileSystem.PrintLine (1, "<p></p>");
                            FileSystem.PrintLine (1, "<p><b>-new  -- Create new: P :</b> create a new project</p>");
                            FileSystem.PrintLine (1, "<p><b>-new  -- Create new: W :</b> create a new word document</p>");
                            FileSystem.PrintLine (1, "<p><b>-new  -- Create new: S :</b> create a new slide collection in ppt</p>");
                            FileSystem.PrintLine (1, "<p><b>-new  -- Create new: E :</b> create a new excel workbook</p>");
                            FileSystem.PrintLine (1, "<p><b>-new  -- Create new: T :</b> create a new textfile</p>");
                            FileSystem.PrintLine (1, "");
                            FileSystem.PrintLine (1, "<p><b>-xml  --save list data as xml: n :</b> Notes</p>");
                            FileSystem.PrintLine (1, "<p><b>-xml  --save list data as xml: l :</b> Links</p>");
                            FileSystem.PrintLine (1, "<p><b>-xml  --save list data as xml: r :</b> Refs</p>");
                            FileSystem.PrintLine (1, "<p></p>");
                            FileSystem.PrintLine (1, "<p><b>-face :</b> goto another face of the program</p>");
                            FileSystem.PrintLine (1, "<p><b>-elib :</b> goto another face of the program</p>");
                            FileSystem.PrintLine (1, "<p></p>");
                            FileSystem.PrintLine (1, "<p><b>-pass :</b> change password</p>");
                            FileSystem.PrintLine (1, "<p><b>-log  :</b> logout </p>");
                            FileSystem.PrintLine (1, "<p><b>-exit :</b> exit the program</p>");
                            FileSystem.PrintLine (1, "<p><b>-quit :</b> exit the program</p>");
                            FileSystem.PrintLine (1, "<hr");
                            FileSystem.PrintLine (1, "<p>There are 3 Lists on the window. List-A is along left side of the window. List-B and List-C are at left. List-B is upper and List-C is lower.</p>");
                            FileSystem.PrintLine (1, "<p>List A shows your Projects and if you click on an item, its subs (subprojects) will be shown.</p>");
                            FileSystem.PrintLine (1, "<p>To force list-A to show projects, press F1, or click on the title above List-A</p>");
                            FileSystem.PrintLine (1, "<p>If List-A is showing subprojects and list-A has the focus, press left arrow</p>");
                            FileSystem.PrintLine (1, "<p>To force focus be on List-A, Press F2. (F2 changes focuse between List-A and the search-box under List-C)</p>");
                            FileSystem.PrintLine (1, "<p>Click on a subproject in List-A to get its notes (SNote) in List-B. List-B can show Date-Time and a line of the note in columns.</p>");
                            FileSystem.PrintLine (1, "<p>List-B also can show whether the note is marked as Done or Pending</p>");
                            FileSystem.PrintLine (1, "<p>There three types of notes: SNotes, LNotes and RNotes.</p>");
                            FileSystem.PrintLine (1, "<p>SNotes are connected to subprojects. LNotes are connected to Links and RNores are connected to Refs</p>");
                            FileSystem.PrintLine (1, "<p>Links are connections between Refs and subprojects. A link may have some notes (LNotes are your notes about links)</p>");
                            FileSystem.PrintLine (1, "<p>Refs are pointing to actual files and documents on your HDD.</p>");
                            FileSystem.PrintLine (1, "<p>Files are saved in eLib repos. Each user registered on a library selects four folders on the HDD as thier dep parts.</p>");
                            FileSystem.PrintLine (1, "<hr>");
                            FileSystem.PrintLine (1, "<p>There are four parts: Papers, Books, Lectures and Manuals</p>");
                            FileSystem.PrintLine (1, "<p>A user may point to a folder as Books, which is already pointed by another user. Therefore, repo parts may be shared between some or all users.</p>");
                            FileSystem.PrintLine (1, "<p>If there is same filename in different folders, users can see the instances and choose between then to open and read, etc...</p>");
                            FileSystem.PrintLine (1, "<p>Users can make notes about refs (RNotes). RNotes are not personal. You can search in eLib and see RNotes made by all users.</p>");
                            FileSystem.PrintLine (1, "<p>SNotes and LNotes are private. You can not see notes of these kinds made by other users.</p>");
                            FileSystem.PrintLine (1, "<p>Notes can be connected to each other. A Note can be the 'family' of another note. That is, they are both connected to the same subproject</p>");
                            FileSystem.PrintLine (1, "<p>You can ask eLib to show you all members of a family. Select a searched note and ask for its family members list (will be shown in List-B)</p>");
                            FileSystem.PrintLine (1, "<p>as you have noticed the List-B can show notes of different types.</p>");
                            FileSystem.PrintLine (1, "<p>When you click on a subProject, list-B shows SNotes, and List-C shows Links. Links are connections between Subprojects and Refs.</p>");
                            FileSystem.PrintLine (1, "<p>A Ref can be connected to many subprojects. When you select a subproject, all the links to this subproject are listed in List-C.</p>");
                            FileSystem.PrintLine (1, "<p>Click on a Link in List-C and List-B will show you notes (LNotes) made by you about that link.</p>");
                            FileSystem.PrintLine (1, "<p>List-C can also show list of Refs based on your search in the search-box beneath the List-C.</p>");
                            FileSystem.PrintLine (1, "<p>You can separate up to 4 keywords in search-box, and then press Enter.</p>");
                            FileSystem.PrintLine (1, "<p>when you search, keywords are used for searching Refs (results shown in List-C), and notes (results shown in List-B)</p>");
                            FileSystem.PrintLine (1, "<p>For SNotes in list-B, youe can ask its family be shown in list-B</p>");
                            FileSystem.PrintLine (1, "<hr>");
                            FileSystem.PrintLine (1, "<p>There is a variant od SNotes known as FNotes. These notes are listed based on date and time.</p>");
                            FileSystem.PrintLine (1, "<p>Notes from three past days and today and 3 next days are listed as a focus-list (FNotes)</p>");
                            FileSystem.PrintLine (1, "<p>Only pending notes from 3 past days are shown. but you can requect for all notes from n-days in past. Use manu on List-B for choices.</p>");
                            FileSystem.PrintLine (1, "<p>When a note in List-B is selected, press Enter to call the Note-Editor</p>");
                            FileSystem.PrintLine (1, "<p>You can edit your note and save it. On the last line of the note in editor, type: (-?) to see a list of inline commands.</p>");
                            FileSystem.PrintLine (1, "<p>You can change the direction of the note (ltr - rtl), save, change date, mark as done or pendenig, etc.</p>");
                            FileSystem.PrintLine (1, "<p>Notes can be interconnectd by MindMap command in the menu on List-B</p>");
                            FileSystem.PrintLine (1, "<p>SNotes are used by the user to remember pst events and progress about projects and subprojects. SNotes are also important for the user to remember tasks and events of coming days and weeks.</p>");
                            FileSystem.PrintLine (1, "<p>SNotes are connected to subprojects.</p>");
                            FileSystem.PrintLine (1, "<p>LNotes are notes on Links. Why did I linke a Ref to a subproject? Why this ref is required for this subproject? What part of the ref is more important and how?</p>");
                            FileSystem.PrintLine (1, "<p>Did I read the ref? These info deserve one or some notes.</p>");
                            FileSystem.PrintLine (1, "<p>These notes are kept connected to the linked-ref but dont accompany the file when copied elsewhere</p>");
                            FileSystem.PrintLine (1, "<p>RNotes are notes about the Refs. Every user can read RNotes left by other users.</p>");
                            FileSystem.PrintLine (1, "<p>When you list a family of notes (SNotes connected to same subproject), sometimes you want read certain notes from another family of notes that may be helpful also for current subproject</p>");
                            FileSystem.PrintLine (1, "<p>You can search all notes and connect then to a specific note. Ususlly you connect searched notes downstream the current note.</p>");
                            FileSystem.PrintLine (1, "<p>You can also connect a searched note upstream the current note. This means that the current note will be seen when upstream note is read in its own family.</p>");
                            FileSystem.PrintLine (1, "<hr>");
                            FileSystem.PrintLine (1, "<p>This help is to be completed. You can try to see updates in later versions, of on eLib webpage at www.msht.ir</p>");
                            FileSystem.PrintLine (1, "<p></p>");
                            FileSystem.PrintLine (1, "<p></p>");
                            //footer
                            Assign.AddFooter2Report ();

                            FileSystem.PrintLine (1, "</body>");
                            FileSystem.PrintLine (1, "</html>");
                            FileSystem.FileClose (1);
                            Interaction.Shell ("explorer.exe " + Application.StartupPath + "eLib_Guide.html");
                            break;
                            }
                    case "Fa":
                            {
                            FileSystem.FileOpen (1, Application.StartupPath + @"\eLib_Guide.html", OpenMode.Output);
                            FileSystem.PrintLine (1, "<html dir=\"rtl\">");
                            FileSystem.PrintLine (1, "<head>");
                            FileSystem.PrintLine (1, "<title>راهنما</title>");
                            //FileSystem.PrintLine (1, Report.Style); // strReportsStyle is defined in Module1
                            FileSystem.PrintLine (1, "</head>");
                            FileSystem.PrintLine (1, "<body>");
                            FileSystem.PrintLine (1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>دانشکده علوم پايه، دانشکاه شهرکرد</p>");
                            FileSystem.PrintLine (1, "<hr>");
                            FileSystem.PrintLine (1, "<p style='color:blue;font-family:tahoma; font-size:14px'>راهنماي نرم افزار کتابخانه الکترونيک<br></p>");
                            FileSystem.PrintLine (1, "<p style='font-family:tahoma; font-size:12px'><Quick list</p>");
                            FileSystem.PrintLine (1, "<table style='font-family:tahoma; font-size:14px; border-collapse:collapse'>");
                            // Header
                            FileSystem.PrintLine (1, Report.Footer); //strReportsFooter is defined in Module1
                            FileSystem.PrintLine (1, "</body>");
                            FileSystem.PrintLine (1, "</html>");
                            FileSystem.FileClose (1);
                            Interaction.Shell ("explorer.exe " + Application.StartupPath + "eLib_Guide.html");
                            break;
                            }
                    }
                }
            catch (Exception ex)
                {
                FileSystem.FileClose (1);
                return;
                }
            }
        }
    public static class Course
        {
        public static int Id;
        public static int Index;
        public static string Name;
        public static int Units;
        public static bool RTL;
        }
    public static class Topic
        {
        public static int Id;
        public static int Index;
        public static string Text;
        }
    public static class Exam
        {
        public static int Id;
        public static int Index;
        public static string Title;
        public static string DateTime;
        public static int Duration;
        public static int nTests;
        public static bool ShuffleOptions;
        public static bool IsActive;
        public static bool Training;
        }
    public static class ExamComposition
        {
        public static int Id;
        public static int ExamId;
        public static int TopicId;
        public static int nTests;
        public static int TestsLevel;
        }
    public static class Test
        {
        public static int Id;
        public static int Index;
        public static int TopicId;
        public static string Text;
        public static int Type;
        public static int Level;
        public static bool TestTags;
        }
    public static class Student
        {
        public static int Id;
        public static int Index;
        public static string Name;
        public static int Pass;
        public static bool Started;
        public static string DateTime;
        public static bool Finished;
        public static int EntryId;
        }
    public static class Testbank
        {
        /*TestBank register:
          bit1 0:AddNew,   1:Edit      bit2 1:Course                  bit3 1:Exam      bit4 1:Test
          bit5 0:Canceled, 1:Saved     bit6 0:Canceled, 1:Selected    bit7 reserved    bit8 reserved
        */
        public static int regTestBank;
        public static bool PasteOnDblClick = false;
        public static bool CourseRTL = false; //is used in frmCET
        public static int EntryId;
        //COURSES and TOPICS
        public static void GetCourses (int userid)
            {
            Db.DS.Tables["tblCourses"].Clear ();
            Db.strSQL = "Select CourseID, CourseName, CourseUnits, CourseRtl FROM Courses WHERE userId = " + userid.ToString () + " Order By CourseName";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblCourses");
                CnnSS.Close ();
                }
            }
        public static void GetCourseTopics (int crsid)
            {
            Db.DS.Tables["tblCourseTopics"].Clear ();
            Db.strSQL = "Select CourseTopicId, CourseId, CourseTopicTitle FROM CourseTopics WHERE CourseId = " + crsid.ToString () + " Order By CourseTopicId";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblCourseTopics");
                CnnSS.Close ();
                }
            }
        public static int GetIdOfThisTopic (int courseId, string topicText)
            {
            //query to get id of existing topic in this course
            Test.TopicId = 0;
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                try
                    {
                    Db.strSQL = "SELECT CourseTopicId FROM CourseTopics WHERE CourseId = " + courseId.ToString () + " AND Topic = N'" + topicText + "'";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    Test.TopicId = (int) cmdx.ExecuteScalar ();
                    //MessageBox.Show ("Test.TopicId : " + Test.TopicId.ToString ());
                    CnnSS.Close ();
                    return Test.TopicId;
                    }
                catch (Exception ex)
                    {
                    //MessageBox.Show (ex.ToString ());
                    //not found? ok, add the topic under this course
                    AddNewCourseTopic (courseId, topicText);
                    return Test.TopicId;
                    }
                }
            }
        public static bool SaveCourse ()
            {
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    switch ((regTestBank & 0b11))
                        {
                        case 0b10: //2:new
                                {
                                Db.strSQL = "INSERT INTO Courses (CourseName, CourseUnits, user_ID, RTL) VALUES (@coursename, @courseunits, @userid, @rtl); SELECT CAST (scope_identity() AS int)";
                                CnnSS.Open ();
                                var cmd1 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmd1.CommandType = CommandType.Text;
                                cmd1.Parameters.AddWithValue ("@coursename", Course.Name);
                                cmd1.Parameters.AddWithValue ("@courseunits", Course.Units.ToString ());
                                cmd1.Parameters.AddWithValue ("@userid", User.Id.ToString ());
                                cmd1.Parameters.AddWithValue ("@rtl", Course.RTL.ToString ());
                                Course.Id = (int) cmd1.ExecuteScalar ();
                                //add default Topic
                                Db.strSQL = "INSERT INTO CourseTopics (CourseId, Topic) VALUES (@courseid, @topic)";
                                var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmd2.CommandType = CommandType.Text;
                                cmd2.Parameters.AddWithValue ("@courseid", Course.Id);
                                cmd2.Parameters.AddWithValue ("@topic", "_ Favorite Topic");
                                int i = (int) cmd2.ExecuteNonQuery ();
                                CnnSS.Close ();
                                break;
                                }
                        case 0b11: //3:edit
                                {
                                Db.strSQL = "UPDATE Courses SET CourseName=@coursename, CourseUnits=@courseunits, CourseRTL=@rtl WHERE CourseId = " + Course.Id.ToString ();
                                CnnSS.Open ();
                                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmdx.CommandType = CommandType.Text;
                                cmdx.Parameters.AddWithValue ("@coursename", Course.Name);
                                cmdx.Parameters.AddWithValue ("@courseunits", Course.Units.ToString ());
                                cmdx.Parameters.AddWithValue ("@userid", User.Id.ToString ());
                                cmdx.Parameters.AddWithValue ("@rtl", Course.RTL.ToString ());
                                Course.Id = (int) cmdx.ExecuteNonQuery ();
                                CnnSS.Close ();
                                break;
                                }
                        }
                    }
                return true;
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Save Error -- Course.Name: " + Course.Name + "\n\n" + ex.ToString ());
                return false;
                }
            }
        public static int AddNewCourseTopic (int courseId, string topicText)
            {
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                try
                    {
                    Db.strSQL = "INSERT INTO CourseTopics (CourseId, Topic) VALUES (@courseid, @topic); SELECT CAST (scope_identity() AS int)";
                    CnnSS.Open ();
                    var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.AddWithValue ("@courseid", courseId.ToString ());
                    cmd2.Parameters.AddWithValue ("@topic", topicText);
                    Test.TopicId = (int) cmd2.ExecuteScalar ();
                    CnnSS.Close ();
                    return Test.TopicId;
                    }
                catch (Exception ex)
                    {
                    CnnSS.Close ();
                    MessageBox.Show (ex.ToString ()); // Do Nothing!
                    return 0;
                    }
                }
            }
        public static bool DeleteCourseById (int courseid)
            {
            bool success = default;
            DialogResult myansw1 = MessageBox.Show ("Delete a Course\n\n- and it's Tests\n- and it's Exams ?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myansw1 == DialogResult.No)
                {
                return false;
                }
            DialogResult myansw2 = MessageBox.Show ("Sure ?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myansw2 == DialogResult.No)
                {
                return false;
                }
            /*
              1: delete exam-tests
              2: delete test-options
              3: delete tests
              4: delete exam-composition
              5: delete exams
              6: delete topics
              7: course the itself
            */
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    //1: delete exam-tests
                    Db.strSQL = "DELETE FROM ExamTests WHERE ExamId IN (SELECT ExamId FROM Exams WHERE CourseId =" + courseid.ToString () + ")";
                    CnnSS.Open ();
                    var cmd1 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd1.CommandType = CommandType.Text;
                    int i1 = cmd1.ExecuteNonQuery ();
                    CnnSS.Close ();
                    //2: delete test-options
                    Db.strSQL = "DELETE FROM TestOptions WHERE TestId IN (SELECT TestId FROM Tests WHERE CourseId =" + courseid.ToString () + ")";
                    CnnSS.Open ();
                    var cmd2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd2.CommandType = CommandType.Text;
                    int i2 = cmd2.ExecuteNonQuery ();
                    CnnSS.Close ();
                    //3: delete tests
                    Db.strSQL = "DELETE FROM Tests WHERE CourseId =" + courseid.ToString ();
                    CnnSS.Open ();
                    var cmd3 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd3.CommandType = CommandType.Text;
                    int i3 = cmd3.ExecuteNonQuery ();
                    CnnSS.Close ();
                    //4: delete exam-composition
                    Db.strSQL = "DELETE FROM ExamComposition WHERE ExamId IN (SELECT ExamId FROM Exams WHERE CourseId =" + courseid.ToString () + ")";
                    CnnSS.Open ();
                    var cmd4 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd4.CommandType = CommandType.Text;
                    int i4 = cmd4.ExecuteNonQuery ();
                    CnnSS.Close ();
                    //5: delete exams
                    Db.strSQL = "DELETE FROM Exams WHERE CourseId =" + courseid.ToString ();
                    CnnSS.Open ();
                    var cmd5 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd5.CommandType = CommandType.Text;
                    int i5 = cmd5.ExecuteNonQuery ();
                    CnnSS.Close ();
                    //6: delete topics
                    Db.strSQL = "DELETE FROM CourseTopics WHERE CourseId =" + courseid.ToString ();
                    CnnSS.Open ();
                    var cmd6 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd6.CommandType = CommandType.Text;
                    int i6 = cmd6.ExecuteNonQuery ();
                    CnnSS.Close ();
                    //7: course the itself
                    Db.strSQL = "DELETE FROM Courses WHERE CourseId = @id";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@id", courseid.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                success = false;
                }
            //finished:
            return success;
            }
        //EXAMS
        public static void GetExams (int crsid)
            {
            Db.DS.Tables["tblExams"].Clear ();
            Db.strSQL = "Select ExamId, CourseId, ExamTitle, ExamDateTime, ExamDuration, ExamNTests, ExamTags FROM Exams WHERE CourseId = " + crsid.ToString () + " Order By ExamTitle";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblExams");
                CnnSS.Close ();
                }
            }
        public static void GetExamById (int examid)
            {
            Db.DS.Tables["tblExams"].Clear ();
            Db.strSQL = "Select ExamId, CourseId, ExamTitle, ExamDateTime, ExamDuration, ExamNTests, ExamTags FROM Exams WHERE ExamId = " + examid.ToString ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblExams");
                CnnSS.Close ();
                }
            }
        public static void GetExamComposition (int examid)
            {
            Db.DS.Tables["tblExamComposition"].Clear ();
            Db.strSQL = "Select ExamComposition.ID, Exam_ID, TopicId, Topic, TopicNTests, TestsLevel FROM ExamComposition INNER JOIN CourseTopics ON ExamComposition.TopicId = CourseTopics.ID WHERE Exam_ID = " + examid.ToString () + " Order By Topic";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblExamComposition");
                CnnSS.Close ();
                }
            }
        public static bool AddExam (int intcourseid)
            {
            bool success = default;
            if ((regTestBank & 0b111) == 0b100)
                {
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        Db.strSQL = "INSERT INTO Exams (CourseId, ExamTitle) VALUES (@courseid, @examtitle); SELECT CAST (scope_identity() AS int)";
                        CnnSS.Open ();
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@courseid", Course.Id);
                        cmdx.Parameters.AddWithValue ("@examtitle", Exam.Title);
                        Exam.Id = (int) cmdx.ExecuteScalar ();
                        CnnSS.Close ();
                        }
                    success = true;
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    success = false;
                    }
                }
            return success;
            }
        public static bool AddExamComposition (int examid, int topicid, int ntests, int testsLevel)
            {
            bool success = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "INSERT INTO ExamComposition (Exam_ID, TopicId, TopicNTests, TestsLevel) VALUES (@examid, @topicid, @topicntests, @testslevel)";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@examid", examid.ToString ());
                    cmdx.Parameters.AddWithValue ("@topicid", topicid.ToString ());
                    cmdx.Parameters.AddWithValue ("@topicntests", ntests.ToString ());
                    cmdx.Parameters.AddWithValue ("@testslevel", testsLevel.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                success = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                success = false;
                }
            return success;
            }
        public static bool UpdateExam (int examid)
            {
            bool success = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "UPDATE Exams SET ExamTitle=@examtitle, ExamDateTime=@examdatetime, ExamDuration=@examduration, ExamNTests=@examntests, ExamShuffleOptions=@examshuffleoptions, IsActive=@isactive, Training=@training WHERE ID = " + Exam.Id.ToString ();
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@examtitle", Exam.Title);
                    cmdx.Parameters.AddWithValue ("@examdatetime", Exam.DateTime);
                    cmdx.Parameters.AddWithValue ("@examduration", Exam.Duration.ToString ());
                    cmdx.Parameters.AddWithValue ("@examntests", Exam.nTests.ToString ());
                    cmdx.Parameters.AddWithValue ("@examshuffleoptions", Exam.ShuffleOptions.ToString ());
                    cmdx.Parameters.AddWithValue ("@isactive", Exam.IsActive.ToString ());
                    cmdx.Parameters.AddWithValue ("@training", Exam.Training.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                success = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                success = false;
                }
            return success;
            }
        public static bool UpdateExamComposition (int compId, int topicId, int nTests, int testsLevel)
            {
            bool success = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "UPDATE ExamComposition SET TopicId=@topicid, TopicNTests=@topicntests, TestsLevel=@testslevel WHERE ExamCompositionId = @id";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@topicid", topicId.ToString ());
                    cmdx.Parameters.AddWithValue ("@topicntests", nTests.ToString ());
                    cmdx.Parameters.AddWithValue ("@testslevel", testsLevel.ToString ());
                    cmdx.Parameters.AddWithValue ("@id", compId.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                success = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                success = false;
                }
            return success;
            }
        public static bool DeleteExamById (int examid)
            {
            bool success = default;
            DialogResult myansw = MessageBox.Show ("Delete an Exam\n\n- and it's Tests?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.No)
                {
                return false;
                }
            /*
              1: delete exam-tests
              4: delete exam-composition
              5: delete exam itself
            */
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    //1: delete exam-tests
                    Db.strSQL = "DELETE FROM ExamTests WHERE ExamId =" + examid.ToString ();
                    CnnSS.Open ();
                    var cmd1 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd1.CommandType = CommandType.Text;
                    int i1 = cmd1.ExecuteNonQuery ();
                    CnnSS.Close ();
                    //4: delete exam-composition
                    Db.strSQL = "DELETE FROM ExamComposition WHERE ExamId=" + examid.ToString ();
                    CnnSS.Open ();
                    var cmd4 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd4.CommandType = CommandType.Text;
                    int i4 = cmd4.ExecuteNonQuery ();
                    CnnSS.Close ();
                    //5: delete exams
                    Db.strSQL = "DELETE FROM Exams WHERE ExamId =" + examid.ToString ();
                    CnnSS.Open ();
                    var cmd5 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd5.CommandType = CommandType.Text;
                    int i5 = cmd5.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                success = false;
                }
            //finished:
            return success;
            }
        public static bool DeleteExamComposition (int compId)
            {
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "DELETE FROM ExamCompositions WHERE ExamCompositionId=@id";
                    CnnSS.Open ();
                    var cmd = new SqlCommand (Db.strSQL, CnnSS);
                    cmd.Parameters.AddWithValue ("@id", compId.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                return true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return false;
                }
            }
        public static void AddRandomTestsToExam (int examId, int topicId, int nTests, int testlevel)
            {
            //MessageBox.Show ("ExamId: " + examId.ToString() + "\nTopicId: " + topicId.ToString () + "\nnTests: " + nTests.ToString () + "\nTestsLevel: " + testlevel.ToString (), "eLib: line 5568", MessageBoxButtons.OKCancel);
            //SELECT TOP n Col FROM Table ORDER BY NEWID()
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                string strSQL = "";
                CnnSS.Open ();
                for (int i = 0; i < nTests; i++)
                    {
                    strSQL = "INSERT INTO ExamTests (ExamId, TestId) SELECT TOP 1 '" + examId.ToString () + "', TestId FROM Tests WHERE TopicId = " + topicId.ToString () + " AND (TestLevel & " + testlevel.ToString () + ") > 0 ORDER BY NEWID ()";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    int x = cmd.ExecuteNonQuery ();
                    }
                CnnSS.Close ();
                }
            }
        //TESTS and OPTIONS        
        public static void GetTests (int parentId, string parent, int topicId)
            {
            switch (parent.ToLower ())
                {
                case "course":
                        {
                        Db.DS.Tables["tblTests"].Clear ();
                        string strSQL1 = "Select TestId, TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel FROM Tests WHERE CourseId = " + parentId.ToString () + " Order By TestId";
                        string strSQL2 = "Select TestId, TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel FROM Tests WHERE CourseId = " + parentId.ToString () + " AND TopicId = " + topicId.ToString () + " Order By TestId";
                        Db.strSQL = (topicId == 0) ? strSQL1 : strSQL2;
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            CnnSS.Open ();
                            Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                            Db.DASS.Fill (Db.DS, "tblTests");
                            CnnSS.Close ();
                            }
                        break;
                        }
                case "exam":
                        {
                        Db.DS.Tables["tblExamTests"].Clear ();
                        string strSQL1 = "Select Tests.TestId, ExamTests.ExamTestId, TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel FROM ExamTests INNER JOIN Tests ON ExamTests.TestId = Tests.TestId WHERE ExamId = " + parentId.ToString () + " Order By ExamTests.ExamTestId";
                        string strSQL2 = "Select Tests.TestId, ExamTests.ExamTestId, TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel FROM ExamTests INNER JOIN Tests ON ExamTests.TestId = Tests.TestId WHERE ExamId = " + parentId.ToString () + " AND TopicId = " + topicId.ToString () + " Order By ExamTests.ExamTestId";
                        Db.strSQL = (topicId == 0) ? strSQL1 : strSQL2;
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            CnnSS.Open ();
                            Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                            Db.DASS.Fill (Db.DS, "tblExamTests");
                            CnnSS.Close ();
                            }
                        break;
                        }
                }
            }
        public static void GetTestById (int testid)
            {
            //[tblTest1]: 0ID, 1TestTitle, 2TestType, 3CourseId, 4TopicID, 5TestRTL, 6OptionsRTL, 7ForceLast, 8TestLevel
            Db.DS.Tables["tblTest1"].Clear ();
            Db.strSQL = "Select TestId, TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel FROM Tests WHERE TestId = " + testid.ToString ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblTest1");
                CnnSS.Close ();
                }
            }
        public static void GetTestOptions (int testid)
            {
            Db.DS.Tables["tblTestOptions"].Clear ();
            Db.strSQL = "Select ID, Test_ID, OptionText, ISAnswer, ForceLast FROM TestOptions WHERE Test_ID = " + testid.ToString () + " Order By ID";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblTestOptions");
                CnnSS.Close ();
                }
            }
        public static void GetTestOptionById (int optionid)
            {
            Db.DS.Tables["tblTestOptions"].Clear ();
            Db.strSQL = "Select TestOptionId, TestId, TestOptionTitle, TestOptionTags FROM TestOptions WHERE TestOptionId = " + optionid.ToString ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblTestOptions");
                CnnSS.Close ();
                }
            }
        public static void AddNewCourseTest (int courseId, int testType)
            {
            Test.TopicId = 0;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "INSERT INTO Tests (TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel) VALUES  (@TestTitle, @testtype, @courseid, @topicid, @testtags, 4); SELECT CAST (scope_identity() AS int)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@TestTitle", Test.Text);
                    cmd.Parameters.AddWithValue ("@testtype", Test.Type.ToString ());
                    cmd.Parameters.AddWithValue ("@courseid", courseId.ToString ());
                    cmd.Parameters.AddWithValue ("@topicid", Test.TopicId.ToString ());
                    cmd.Parameters.AddWithValue ("@testtags", Test.TestTags.ToString ());
                    Test.Id = (int) cmd.ExecuteScalar ();
                    CnnSS.Close ();
                    }
                for (int i = 0; i < testType; i++)
                    {
                    AddTestOption (Test.Id, "_Test option [edit]", false, false);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void AddNewExamTest (int examId, int testId)
            {
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "INSERT INTO ExamTests (Exam_ID, Test_ID) VALUES (@examid, @testid)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@examid", examId.ToString ());
                    cmd.Parameters.AddWithValue ("@testid", testId.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static bool AddTestOption (int testid, string optionText, bool IsAns, bool forceLast)
            {
            bool success = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "INSERT INTO TestOptions (Test_ID, OptionText, IsAnswer, ForceLast) VALUES (@testid, @optiontext, @isanswer, @forcelast)";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@testid", testid.ToString ());
                    cmdx.Parameters.AddWithValue ("@optiontext", optionText);
                    cmdx.Parameters.AddWithValue ("@isanswer", IsAns.ToString ());
                    cmdx.Parameters.AddWithValue ("@forcelast", forceLast.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                success = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                success = false;
                }
            return success;
            }
        public static void ImportTest (int courseId, string TestTitle, int testType, int topicId, bool testRTL, bool optionsRTL, int testLevel)
            {
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "INSERT INTO Tests (TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel) VALUES  (@TestTitle, @testtype, @courseid, @topicid, @testrtl, @optionsrtl, @testlevel); SELECT CAST (scope_identity() AS int)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@TestTitle", TestTitle);
                    cmd.Parameters.AddWithValue ("@testtype", testType.ToString ());
                    cmd.Parameters.AddWithValue ("@courseid", courseId.ToString ());
                    cmd.Parameters.AddWithValue ("@topicid", topicId.ToString ());
                    cmd.Parameters.AddWithValue ("@testtags", testRTL.ToString ());
                    cmd.Parameters.AddWithValue ("@testlevel", testLevel.ToString ());
                    Test.Id = (int) cmd.ExecuteScalar ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void UpdateTest (int id, string mode)
            {
            switch (mode.ToLower ())
                {
                case "course":
                        {
                        try
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "UPDATE Tests SET TestTitle=@TestTitle, TestType=@testtype, TopicId=@topicid, TestTags=@testtags TestLevel=@testlevel WHERE TestId = " + id.ToString ();
                                CnnSS.Open ();
                                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue ("@TestTitle", Test.Text);
                                cmd.Parameters.AddWithValue ("@testtype", Test.Type.ToString ());
                                cmd.Parameters.AddWithValue ("@topicid", Test.TopicId.ToString ());
                                cmd.Parameters.AddWithValue ("@testtags", Test.TestTags.ToString ());
                                cmd.Parameters.AddWithValue ("@testlevel", Test.Level.ToString ());
                                int i = cmd.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            }
                        catch (Exception ex)
                            {
                            MessageBox.Show (ex.ToString ());
                            }
                        break;
                        }
                case "exam":
                        {
                        try
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                Db.strSQL = "INSERT INTO ExamTests (Test_ID = @testid)";
                                CnnSS.Open ();
                                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue ("@testid", Test.Id.ToString ());
                                int i = cmd.ExecuteNonQuery ();
                                CnnSS.Close ();
                                }
                            }
                        catch (Exception ex)
                            {
                            MessageBox.Show (ex.ToString ());
                            }
                        break;
                        }
                }
            }
        public static bool UpdateTestOption (int optId, string optText, bool optIsAns, bool optForce)
            {
            bool success = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "UPDATE TestOptions SET OptionText=@optiontext, TestOptionTags=@tags WHERE TestOptionId=@id";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@optiontext", optText);
                    cmdx.Parameters.AddWithValue ("@tags", optIsAns.ToString ());
                    cmdx.Parameters.AddWithValue ("@id", optId.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                regTestBank &= 0b10000;
                success = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                success = false;
                }
            return success;
            }
        public static bool DeleteTestOptionById (int testOptionId)
            {
            bool success = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "DELETE FROM TestOptions WHERE TestOptionId = @id";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@id", testOptionId.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                success = true;
                }
            catch (Exception ex)
                {
                success = false;
                }
            return success;
            }
        //ENTRIES
        public static void GetEntries (int userId)
            {
            try
                {
                Db.DS.Tables["tblEntries"].Clear ();
                Db.strSQL = "SELECT ID, EntryName, User_ID FROM Entries WHERE User_ID=" + userId.ToString ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    Db.DASS.Fill (Db.DS, "tblEntries");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static int AddNewEntry (int userId, string entryName)
            {
            try
                {
                int i = 0;
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "INSERT INTO Entries (EntryName, User_ID) VALUES (@entryname, @userid); SELECT CAST (scope_identity() AS int)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@entryname", entryName);
                    cmd.Parameters.AddWithValue ("@userid", userId.ToString ());
                    i = (int) cmd.ExecuteScalar ();
                    CnnSS.Close ();
                    }
                regTestBank = 0b10000; //saved
                return i;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                regTestBank = 0b00000; //bit4 off: not saved
                return 0;
                }
            }
        public static bool UpdateEntry (int entryId, string entryName)
            {
            bool success = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "UPDATE Entries SET EntryName = @entryname WHERE ID = @id";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@entryname", entryName);
                    cmdx.Parameters.AddWithValue ("@id", entryId.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                regTestBank &= 0b10000;
                success = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                success = false;
                }
            return success;
            }
        //StudentS and EXAMSHEETS
        public static void GetEntryStudents (int entryId)
            {
            try
                {
                Db.DS.Tables["tblEntryStudents"].Clear ();
                Db.strSQL = "SELECT ID, Entry_ID, StudentName, StudentPass FROM Students WHERE Entry_ID=" + entryId.ToString () + " ORDER BY StudentName";
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    Db.DASS.Fill (Db.DS, "tblEntryStudents");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void GetStudentById (int StudentId)
            {
            try
                {
                Db.DS.Tables["tblEntryStudents"].Clear ();
                Db.strSQL = "SELECT StudentId, GroupId, StudentName, StudentPass FROM Students WHERE StudentId=" + StudentId.ToString ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    Db.DASS.Fill (Db.DS, "tblEntryStudents");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void GetExamStudents (int examId)
            {
            try
                {
                Db.DS.Tables["tblExamStudents"].Clear ();
                Db.strSQL = "SELECT ExamStudents.ID, Student_ID, Exam_ID, StudentName, StudentPass, Started, DateTime, Finished FROM ExamStudents INNER JOIN Students ON ExamStudents. Student_ID = Students.ID WHERE Exam_ID =" + examId.ToString () + " ORDER BY StudentName";
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    Db.DASS.Fill (Db.DS, "tblExamStudents");
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static int GetAllStudentExams (int StudentId)
            {
            Db.DS.Tables["tblStudentExams"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter ("SELECT CourseName, Exams.ExamId, ExamTitle, ExamDuration, ExamTags, Started, ExamStudents.DateTime, Finished FROM Exams INNER JOIN ExamStudents ON Exams.ExamId = ExamStudents.ExamId INNER JOIN Courses ON Exams.CourseId = Courses.CourseId WHERE StudentId =" + StudentId.ToString (), CnnSS);
                Db.DASS.Fill (Db.DS, "tblStudentExams");
                CnnSS.Close ();
                }
            return Db.DS.Tables["tblStudentExams"].Rows.Count;
            }
        public static bool GetStudentExamSheet (int examId, int StudentId)
            {
            try
                {
                Db.DS.Tables["tblExamSheets"].Clear ();
                Db.strSQL = "SELECT ExamId, StudentId, TestId, Opt1Id, Opt2Id, Opt3Id, Opt4Id, Opt5Id, ExamSheetTestKey, ExamSheetTestAns, ExamSheetTestTags FROM ExamSheets WHERE Exam_ID = " + examId.ToString () + " AND Student_ID = " + StudentId.ToString ();
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                    Db.DASS.Fill (Db.DS, "tblExamSheets");
                    CnnSS.Close ();
                    }
                return true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return false;
                }
            }
        public static void GetTestOptionsText (int examTestId)
            {
            Db.DS.Tables["tblTestOptions"].Clear ();
            Db.strSQL = "SELECT TestOptionsId, TestId, OptionText, TestOptionsTags FROM TestOptions WHERE TestId = " + examTestId.ToString () + " Order By TestOptionsId";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblTestOptions");
                CnnSS.Close ();
                }
            }
        public static void GetExamTestById (int examtestId)
            {
            Db.DS.Tables["tblTests"].Clear ();
            Db.strSQL = "SELECT TestId, TestTitle, TestType, CourseId, TopicId, TestTags, TestLevel FROM Tests WHERE TestId = " + examtestId.ToString ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblTests");
                CnnSS.Close ();
                }
            }
        public static void AddNewStudent2Entry (int entryId, string StudentName, string StudentPass)
            {
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                Db.strSQL = "INSERT INTO Students (GroupId, StudentName, StudentPass) VALUES (@groupid, @Studentname, @Studentpass)";
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue ("@groupid", entryId.ToString ());
                cmd.Parameters.AddWithValue ("@Studentname", StudentName);
                cmd.Parameters.AddWithValue ("@Studentpass", StudentPass);
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        public static void AddOneStudent2Exam (int StudentId, int examId)
            {
            try
                {
                //STEP1: add the Student to exam
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "INSERT INTO ExamStudents (StudentId, ExamId) VALUES (@Studentid, @examid)";
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@Studentid", StudentId.ToString ());
                    cmd.Parameters.AddWithValue ("@examid", examId.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                //STEP2: add n tests to examsheets
                GetTests (examId, "exam", 0); //refill DS.[tblExamTests]: 0Tests.ID, 1ExamTests.ID, 2TestTitle, 3TestType, 4Course_ID, 5TopicId, 6TestRTL, 7OptionsRTL
                Exam.nTests = Db.DS.Tables["tblExamTests"].Rows.Count;
                //2_a: shuffle rows of [tblExamTests]
                Random rnd = new Random ();
                int r = 0;
                int tmpVar = 0;
                for (int z = 0; z < (Exam.nTests - 1); z++)
                    {
                    r = rnd.Next (z + 1, Exam.nTests - 1);
                    tmpVar = Convert.ToInt32 (Db.DS.Tables["tblExamTests"].Rows[r][0]);
                    Db.DS.Tables["tblExamTests"].Rows[r][0] = Convert.ToInt32 (Db.DS.Tables["tblExamTests"].Rows[z][0]);
                    Db.DS.Tables["tblExamTests"].Rows[z][0] = tmpVar;
                    }
                //2_b: for each test in shuffled list in [tblExamTests]: 0Tests.ID, 1ExamTests.ID, 2TestTitle, 3TestType, 4Course_ID, 5TopicId, 6TestRTL, 7OptionsRTL
                for (int i = 0; i < Exam.nTests; i++)
                    {
                    Test.Id = Convert.ToInt32 (Db.DS.Tables["tblExamTests"].Rows[i][0]);
                    GetTestOptions (Test.Id);
                    //[tblTestOptions]: 0ID, 1Test_ID, 2OptionText, 3ISAnswer, 4ForceLast
                    int[] intOpts = new int[5] { 0, 0, 0, 0, 0 };
                    int intAnswr = 0;
                    int intForce = 0;
                    int intNOpts = Db.DS.Tables["tblTestOptions"].Rows.Count;
                    for (int p = 0; p < intNOpts; p++)
                        {
                        //Option-IDs
                        intOpts[p] = Convert.ToInt32 (Db.DS.Tables["tblTestOptions"].Rows[p][0]);
                        //find answer
                        if (Convert.ToBoolean (Db.DS.Tables["tblTestOptions"].Rows[p][3]))
                            {
                            intAnswr = Convert.ToInt32 (Db.DS.Tables["tblTestOptions"].Rows[p][0]);
                            }
                        //find forceLast
                        if (Convert.ToBoolean (Db.DS.Tables["tblTestOptions"].Rows[p][4]))
                            {
                            intForce = Convert.ToInt32 (Db.DS.Tables["tblTestOptions"].Rows[p][0]);
                            }
                        }
                    int intNshuffle = 0;
                    if (intForce == 0)
                        {
                        //0=false: no forceLast found
                        intNshuffle = intNOpts; //shuffle all options
                        }
                    else if (intForce > 0)
                        {
                        //1=true: there is forceLast
                        intOpts[intNOpts - 1] = intForce; //Option-ID of the forceLast 
                        intNshuffle = (intNOpts - 1); //shuffle options (1 to nOpts)
                        }
                    //do shuffle cols
                    for (int s = 0; s < intNshuffle; s++)
                        {
                        r = rnd.Next (0, (intNshuffle - 1));
                        //swap!
                        tmpVar = intOpts[r];
                        intOpts[r] = intOpts[s];
                        intOpts[s] = tmpVar;
                        }
                    //insert into table ExamSheets
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        Db.strSQL = "INSERT INTO ExamSheets (ExamId, StudentId, TestId, Opt1Id, Opt2Id, Opt3Id, Opt4Id, Opt5Id, ExamSheetTestKey, ExamSheetTestAns, ExamSheetTestTags) VALUES (@examid, @Studentid, @testid, @opt1id, @opt2id, @opt3id, @opt4id, @opt5id, @key, 0, 0)";
                        CnnSS.Open ();
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue ("@examid", examId.ToString ());
                        cmd.Parameters.AddWithValue ("@Studentid", StudentId.ToString ());
                        cmd.Parameters.AddWithValue ("@testid", Test.Id.ToString ());
                        cmd.Parameters.AddWithValue ("@opt1id", intOpts[0].ToString ());
                        cmd.Parameters.AddWithValue ("@opt2id", intOpts[1].ToString ());
                        cmd.Parameters.AddWithValue ("@opt3id", intOpts[2].ToString ());
                        cmd.Parameters.AddWithValue ("@opt4id", intOpts[3].ToString ());
                        cmd.Parameters.AddWithValue ("@opt5id", intOpts[4].ToString ());
                        cmd.Parameters.AddWithValue ("@key", intAnswr.ToString ());
                        int x = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static bool UpdateStudent (int StudentId, string StudentName, string StudentPass)
            {
            bool success = default;
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    Db.strSQL = "UPDATE Students SET StudentName=@Studentname, StudentPass=@Studentpass WHERE StudentId = @id";
                    CnnSS.Open ();
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@Studentname", StudentName);
                    cmdx.Parameters.AddWithValue ("@Studentpass", StudentPass);
                    cmdx.Parameters.AddWithValue ("@id", StudentId.ToString ());
                    int ix = cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                regTestBank &= 0b10000;
                success = true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                success = false;
                }
            return success;
            }
        public static bool RemoveAllStudentsFromExam (int examId)
            {
            //confirm!
            DialogResult myansw = MessageBox.Show ("Are you sure?\nAll Students and their sheets will be deleted!\n\nContinue?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.No)
                {
                return false;
                }
            else
                {
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        Db.strSQL = "DELETE FROM ExamStudents WHERE ExamId=@examid; DELETE FROM ExamSheets WHERE ExamId=@examid";
                        CnnSS.Open ();
                        var cmd = new SqlCommand (Db.strSQL, CnnSS);
                        cmd.Parameters.AddWithValue ("@examid", examId.ToString ());
                        int i = cmd.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    return true;
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ());
                    return false;
                    }
                }
            }
        public static bool RemoveOneStudentFromExam (int examId, int StudentId)
            {
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    //delete from 2 tables
                    Db.strSQL = "DELETE FROM ExamStudents WHERE ExamId=@examid AND StudentId=@Studentid; DELETE FROM ExamSheets WHERE ExamId=@examid AND StudentId=@Studentid";
                    CnnSS.Open ();
                    var cmd = new SqlCommand (Db.strSQL, CnnSS);
                    cmd.Parameters.AddWithValue ("@examid", examId.ToString ());
                    cmd.Parameters.AddWithValue ("@Studentid", StudentId.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                return true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return false;
                }
            }
        public static bool DeleteOneStudentFromEntry (int StudentId)
            {
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    //delete from 3 tables
                    Db.strSQL = "DELETE FROM Students WHERE StudentId=@Studentid; DELETE FROM ExamStudents WHERE StudentId=@Studentid; DELETE FROM ExamSheets WHERE StudentId=@Studentid";
                    CnnSS.Open ();
                    var cmd = new SqlCommand (Db.strSQL, CnnSS);
                    cmd.Parameters.AddWithValue ("@Studentid", StudentId.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                return true;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                return false;
                }
            }
        public static void DeleteAnEntry (int entryId)
            {
            GetEntryStudents (entryId); //[tblEntryStudents]
            int StudentId = 0;
            for (int r = 0; r < Db.DS.Tables["tblEntryStudents"].Rows.Count; r++)
                {
                StudentId = Convert.ToInt32 (Db.DS.Tables["tblEntryStudents"].Rows[r][0].ToString ());
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    //delete from 3 tables
                    Db.strSQL = "DELETE FROM Students WHERE StudentId=@Studentid; DELETE FROM ExamStudents WHERE StudentId=@Studentid; DELETE FROM ExamSheets WHERE StudentId=@Studentid";
                    CnnSS.Open ();
                    var cmd = new SqlCommand (Db.strSQL, CnnSS);
                    cmd.Parameters.AddWithValue ("@Studentid", StudentId.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            //delete from Entry
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                Db.strSQL = "DELETE FROM Groups WHERE GroupId=@groupid;";
                CnnSS.Open ();
                var cmd = new SqlCommand (Db.strSQL, CnnSS);
                cmd.Parameters.AddWithValue ("@groupid", entryId.ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        //Printout-HTML
        public static void PrintoutExamStudentsUserPass ()
            {
            //Report User-Pass
            string strHeader = "Exam Students UserName - Password.  CBT administrator: ";
            try
                {
                FileSystem.FileOpen (1, Application.StartupPath + "elibExam_Students.html", OpenMode.Output);
                //header
                Assign.AddHeader2Report (strHeader);
                var cnt = Db.DS.Tables["tblExamStudents"].Rows.Count;
                //0ID, 1Student_ID, 2Exam_ID, 3StudentName, 4StudentPass, 5Started, 6DateTime, 7Finished
                for (int i = 0; i < cnt; i++)
                    {
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:18px'>", "Exam : " + Exam.Title), " "));
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Blue; font-family:tahoma; font-size:16px'>Username: ", Db.DS.Tables["tblExamStudents"].Rows[i][3]), " "));
                    //FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<span style='color:Black; font-family:tahoma; font-size:16px'> --- Password: ", Db.DS.Tables ["tblExamStudents"].Rows [i] [4]), "</span>"), "<br>");
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:16px'>Password: ", Db.DS.Tables["tblExamStudents"].Rows[i][4]), " "));
                    FileSystem.PrintLine (1, "<hr>");
                    }
                //footer
                Assign.AddFooter2Report ();
                FileSystem.FileClose (1);
                Interaction.Shell ("explorer.exe " + Application.StartupPath + "elibExam_Students.html");
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                FileSystem.FileClose (1);
                return;
                }
            }
        public static void PrintoutEntryStudentsUserPass (int entryid)
            {
            //Report User-Pass
            string strHeader = "Entry Students UserName - Password.  CBT administrator: ";
            try
                {
                FileSystem.FileOpen (1, Application.StartupPath + "elibEntry_Students.html", OpenMode.Output);
                //header
                Assign.AddHeader2Report (strHeader);
                var cnt = Db.DS.Tables["tblEntryStudents"].Rows.Count;
                //0ID, 1Entry_ID, 2StudentName, 3StudentPass
                for (int i = 0; i < cnt; i++)
                    {
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Blue; font-family:tahoma; font-size:16px'>Username: ", Db.DS.Tables["tblEntryStudents"].Rows[i][2]), " "));
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:16px'>Password: ", Db.DS.Tables["tblEntryStudents"].Rows[i][3]), " "));
                    FileSystem.PrintLine (1, "<hr>");
                    }
                //footer
                Assign.AddFooter2Report ();
                FileSystem.FileClose (1);
                Interaction.Shell ("explorer.exe " + Application.StartupPath + "elibEntry_Students.html");
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                FileSystem.FileClose (1);
                return;
                }
            }
        public static void PrintoutRawExamSheets (int examId, int StudentId)
            {
            //Report RawExamSheet
            string strHeader = "Exam Sheet- ";
            try
                {
                string rawSheetName = "elibExamSheet_" + examId.ToString ().Trim () + "_" + StudentId.ToString ().Trim () + ".html";
                FileSystem.FileOpen (1, Application.StartupPath + rawSheetName, OpenMode.Output);
                //header
                Assign.AddHeader2Report (strHeader); //adds userName to string
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:18px'>", "Exam name: " + Exam.Title), " "));
                GetStudentById (StudentId);
                //[tblEntryStudents]: 0ID, 1Entry_ID, 2StudentName, 3StudentPass
                Student.Name = Db.DS.Tables["tblEntryStudents"].Rows[0][2].ToString ();
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:18px'>", "Student name: " + Student.Name), " "));
                FileSystem.PrintLine (1, "<hr>");
                GetStudentExamSheet (examId, Student.Id);
                int cntTest = 0;
                cntTest = Db.DS.Tables["tblExamSheets"].Rows.Count;
                //0Exam_ID, 1Student_ID, 2Test_ID, 3Opt1_ID, 4Opt2_ID, 5Opt3_ID, 6Opt4_ID, 7Opt5_ID, 8Keyx, 9Ans, 10Tags
                for (int j = 0; j < cntTest; j++)
                    {
                    Test.Id = Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[j][2]);
                    GetExamTestById (Test.Id);
                    //[tblTests]: 0ID, 1TestTitle, 2TestType, 3Course_ID, 4TopicID, 5TestRTL, 6OptionsRTL
                    GetTestOptionsText (Test.Id);
                    //[tblTestOptions]: 0ID, 1Test_ID, 2OptionText, 3ISAnswer, 4ForceLast
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:16px'>", (j + 1).ToString () + "- " + Db.DS.Tables["tblTests"].Rows[0][1]), " "));
                    for (int opt = 0; opt < Db.DS.Tables["tblTestOptions"].Rows.Count; opt++)
                        {
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:16px'>", " -- ( " + (opt + 1).ToString () + " ) " + Db.DS.Tables["tblTestOptions"].Rows[opt][2]), " "));
                        }
                    FileSystem.PrintLine (1, "<hr>");
                    }
                FileSystem.PrintLine (1, "<p>FINISHED</p>");
                //footer
                Assign.AddFooter2Report ();
                FileSystem.FileClose (1);
                Interaction.Shell ("explorer.exe " + Application.StartupPath + rawSheetName);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                FileSystem.FileClose (1);
                return;
                }
            }
        public static void PrintoutExamMarks (int examId)
            {
            //Report User-Pass
            //GetExamById (examId); //tblExams: 0ID, 1CourseId, 2ExamTitle, 3ExamDateTime, 4ExamDuration, 5ExamNTests, 6ExamShuffleOptions, 7IsActive, 8Training
            string strHeader = "Exam Marks.  CBT administrator: ";
            try
                {
                FileSystem.FileOpen (1, Application.StartupPath + "elibExam_Marks.html", OpenMode.Output);
                //header
                Assign.AddHeader2Report (strHeader); //adds userName to string
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:18px'>", "Exam name: " + Exam.Title), " "));
                FileSystem.PrintLine (1, "<hr>");
                int cntTest = 0;
                int cntAns = 0;
                double mark = 0.0;
                double mean = 0.0;
                int nStudents = 0;
                Testbank.GetExamStudents (examId);
                //0ExamStudents.ID, 1Student_ID, 2Exam_ID, 3StudentName, 4StudentPass, 5Started, 6DateTime, 7Finished
                for (int i = 0; i < Db.DS.Tables["tblExamStudents"].Rows.Count; i++)
                    {
                    Student.Id = Convert.ToInt32 (Db.DS.Tables["tblExamStudents"].Rows[i][1]);
                    Student.Name = Db.DS.Tables["tblExamStudents"].Rows[i][3].ToString ();
                    Student.DateTime = Db.DS.Tables["tblExamStudents"].Rows[i][6].ToString ();
                    Testbank.GetStudentExamSheet (examId, Student.Id);
                    //[tblExamSheets]: 0:Exam_ID, 1:Student_ID, 2:Test_ID, 3-7:Optx_ID, 8:Keyx, 9:Ans, 10:Tags
                    cntTest = Db.DS.Tables["tblExamSheets"].Rows.Count;
                    cntAns = 0;
                    for (int j = 0; j < cntTest; j++)
                        {
                        if (Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[j][8]) == Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[j][9]))
                            {
                            cntAns++;
                            }
                        }
                    mark = Convert.ToDouble (Convert.ToDouble (cntAns) * 20.0 / Convert.ToDouble (cntTest));
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:16px'>", "Student# " + Student.Id.ToString ("00000") + " -- Name: " + Student.Name), " "));
                    if (Convert.ToBoolean (Db.DS.Tables["tblExamStudents"].Rows[i][5]))
                        {
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:16px'>", "Starts exam at: " + Student.DateTime), " "));
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Blue; font-family:tahoma; font-size:16px'>", "Answers: " + cntAns.ToString ("000")) + " / ", cntTest.ToString ("000")), " ");
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Blue; font-family:tahoma; font-size:16px'>", "Mark: " + mark.ToString ("00.000")), " "));
                        mean += mark;
                        nStudents++;
                        }
                    else
                        {
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:16px'>", "has not taken the exam"), " "));
                        }
                    FileSystem.PrintLine (1, "<hr>");
                    }
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:20px'>", "Mean: " + Convert.ToDouble (mean / Convert.ToDouble (nStudents)).ToString ("00.000") + " (for " + nStudents.ToString () + " marks)"), " "));
                FileSystem.PrintLine (1, "<hr>");
                //footer
                Assign.AddFooter2Report ();
                FileSystem.FileClose (1);
                Interaction.Shell ("explorer.exe " + Application.StartupPath + "elibExam_Marks.html");
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                FileSystem.FileClose (1);
                return;
                }
            }
        public static void PrintoutExamRecords (int examId, int StudentId)
            {
            //Report RawExamSheet
            string strHeader = "Exam Sheet- ";
            int cntTest = 0;
            int cntAns = 0;
            double mark = 0.0;
            try
                {
                string filledSheetName = "elibExamSheet_" + examId.ToString ().Trim () + "_" + StudentId.ToString ().Trim () + ".html";
                //[tblEntryStudents]: 0ID, 1Entry_ID, 2StudentName, 3StudentPass
                GetStudentById (StudentId);
                FileSystem.FileOpen (1, Application.StartupPath + filledSheetName, OpenMode.Output);
                //header
                Assign.AddHeader2Report (strHeader); //adds userName to string
                Student.Name = Db.DS.Tables["tblEntryStudents"].Rows[0][2].ToString ();
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:18px'>", "Exam name: " + Exam.Title), " "));
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:18px'>", "Student name: " + Student.Name), " "));
                FileSystem.PrintLine (1, "<hr>");
                GetStudentExamSheet (examId, StudentId);
                //[tblExamSheets]: 0:Exam_ID, 1:Student_ID, 2:Test_ID, 3-7:Optx_ID, 8:Keyx, 9:Ans, 10:Tags
                cntTest = Db.DS.Tables["tblExamSheets"].Rows.Count;
                //Calculate Test Mark
                cntAns = 0;
                for (int j = 0; j < cntTest; j++)
                    {
                    if (Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[j][8]) == Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[j][9]))
                        {
                        cntAns++;
                        }
                    }
                mark = Convert.ToDouble (Convert.ToDouble (cntAns) * 20.0 / Convert.ToDouble (cntTest));
                //Color options
                string printColor = "";
                for (int i = 0; i < cntTest; i++)
                    {
                    Test.Id = Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[i][2]);
                    GetExamTestById (Test.Id);
                    //[tblTests]: 0ID, 1TestTitle, 2TestType, 3Course_ID, 4TopicId, 5TestRTL, 6OptionsRTL, 7TestLevel
                    FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Black; font-family:tahoma; font-size:16px'>", (i + 1).ToString () + "- " + Db.DS.Tables["tblTests"].Rows[0][1] + " (level:" + Db.DS.Tables["tblTests"].Rows[0][7] + ")"), " "));
                    Test.Type = Convert.ToInt32 (Db.DS.Tables["tblTests"].Rows[0][2]);
                    for (int p = 0; p < Test.Type; p++)
                        {
                        //MessageBox.Show ("Test " + (i + 1).ToString () + "  -Get Option: " + (p + 1).ToString ());
                        GetTestOptionById (Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[i][p + 3].ToString ()));
                        //[tblTestOptions]: 0ID, 1Test_ID, 2OptionText, 3ISAnswer, 4ForceLast
                        printColor = "Black"; //default
                        if (Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[i][9]) == Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[i][p + 3])) //[p+3]-> Optx_ID
                            {
                            printColor = "Red";
                            }
                        if (Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[i][8]) == Convert.ToInt32 (Db.DS.Tables["tblExamSheets"].Rows[i][p + 3])) //[p+3]-> Optx_ID
                            {
                            printColor = "Blue";
                            }
                        FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:" + printColor + "; font-family:tahoma; font-size:16px'>", " -- ( " + (p + 1).ToString () + " ) " + Db.DS.Tables["tblTestOptions"].Rows[0][2]), " "));
                        }
                    FileSystem.PrintLine (1, "<hr>");
                    }
                FileSystem.PrintLine (1, "<p>FINISHED</p>");
                //results
                FileSystem.PrintLine (1, "<hr>");
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Blue; font-family:tahoma; font-size:16px'>", "Answers: " + cntAns.ToString ("000")) + " / ", cntTest.ToString ("000")), " ");
                FileSystem.PrintLine (1, Operators.ConcatenateObject (Operators.ConcatenateObject ("<p style='color:Blue; font-family:tahoma; font-size:16px'>", "Mark: " + mark.ToString ("00.000")), " "));
                FileSystem.PrintLine (1, "<hr>");
                //footer
                Assign.AddFooter2Report ();
                FileSystem.FileClose (1);
                Interaction.Shell ("explorer.exe " + Application.StartupPath + filledSheetName);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                FileSystem.FileClose (1);
                return;
                }
            }
        }
    public static class Project
        {
        public static int Id = 0;
        public static string Name = "";
        public static string Note = "";
        public static Boolean IsActive = false;
        }
    public static class SubProject
        {
        public static int Id = 0;
        public static string Name = "";
        public static string Note = "";
        }
    public static class Note
        {
        public static string Type = ""; //{RefNote, LinkNote, SubProjectNote}
        public static int Index = 0;
        public static bool Saved = false;
        public static int Id = 0;
        public static string NoteText = "";
        public static string DateTime = "";
        public static bool Rtl = false;
        public static bool Done = false;
        public static int UserID = 0;
        public static int ParentID = 0;
        public static int ParentType = 0; //1:SubProject(SNotes), 2:Link(LNotes), 3:Ref(RNotes)
        public static int days = 0;
        public static void GetSNotesFromDB (string period)
            {
            switch (period)
                {
                case "all":
                        {
                        //all today + postponded + pending                        
                        Db.strSQL = "SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID";
                        Db.strSQL += " WHERE (Projects.User_ID = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (";
                        Db.strSQL += " LEFT (NoteDatum, 10) = '" + System.DateTime.Now.ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (1).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (2).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (3).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (4).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (5).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (6).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (7).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (8).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (9).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (10).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-1).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-2).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-3).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-4).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-5).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += ")";
                        Db.strSQL += " UNION SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID INNER JOIN User_Project ON User_Project.Project_Id = Projects.ID";
                        Db.strSQL += " WHERE (User_Project.User_Id = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (";
                        Db.strSQL += " LEFT (NoteDatum, 10) = '" + System.DateTime.Now.ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (1).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (2).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (3).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (4).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (5).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (6).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (7).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (8).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (9).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (10).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-1).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-2).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-3).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-4).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-5).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += ")";
                        Db.strSQL += " ORDER BY NoteDatum";
                        break;
                        }
                case "upcoming":
                        {
                        //today + 10
                        Db.strSQL = "SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID";
                        Db.strSQL += " WHERE (Projects.User_ID = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (";
                        Db.strSQL += " LEFT (NoteDatum, 10) = '" + System.DateTime.Now.ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (1).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (2).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (3).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (4).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (5).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (6).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (7).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (8).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (9).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (10).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += ")";
                        Db.strSQL += " UNION SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID INNER JOIN User_Project ON User_Project.Project_Id = Projects.ID";
                        Db.strSQL += " WHERE (User_Project.User_Id = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (";
                        Db.strSQL += " LEFT (NoteDatum, 10) = '" + System.DateTime.Now.ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (1).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (2).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (3).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (4).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (5).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (6).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (7).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (8).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (9).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += " OR LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (10).ToString ("yyyy-MM-dd") + "'";
                        Db.strSQL += ")";
                        Db.strSQL += " ORDER BY NoteDatum";
                        break;
                        }
                case "upcomingpending":
                        {
                        //today + (10 pending) 
                        Db.strSQL = "SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID";
                        Db.strSQL += " WHERE (Projects.User_ID = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (";
                        Db.strSQL += " (LEFT (NoteDatum, 10) = '" + System.DateTime.Now.ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (1).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (2).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (3).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (4).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (5).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (6).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (7).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (8).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (9).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (10).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += ")";
                        Db.strSQL += " UNION SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID INNER JOIN User_Project ON User_Project.Project_Id = Projects.ID";
                        Db.strSQL += " WHERE (User_Project.User_Id = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (";
                        Db.strSQL += " (LEFT (NoteDatum, 10) = '" + System.DateTime.Now.ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (1).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (2).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (3).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (4).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (5).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (6).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (7).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (8).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (9).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (10).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += ")";
                        Db.strSQL += " ORDER BY NoteDatum";
                        break;
                        }
                case "postponeded":
                        {
                        //today + (-10)
                        Db.strSQL = "SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID";
                        Db.strSQL += " WHERE (Projects.User_ID = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (";
                        Db.strSQL += " (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-1).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-2).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-3).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-4).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-5).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-6).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-7).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-8).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-9).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-10).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += ")";
                        Db.strSQL += " UNION SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID INNER JOIN User_Project ON User_Project.Project_Id = Projects.ID";
                        Db.strSQL += " WHERE (User_Project.User_Id = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (";
                        Db.strSQL += " (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-1).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-2).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-3).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-4).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-5).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-6).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-7).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-8).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-9).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-10).ToString ("yyyy-MM-dd") + "' AND Done = 0)";
                        Db.strSQL += ")";
                        Db.strSQL += " ORDER BY NoteDatum";
                        break;
                        }
                case "ndays":
                        {
                        Db.strSQL = "SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID";
                        Db.strSQL += " WHERE (Projects.User_ID = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (LEFT (NoteDatum, 10) = '" + System.DateTime.Now.ToString ("yyyy-MM-dd") + "'";
                        int duration = System.Math.Abs (Note.days);
                        for (int d = 1; d <= duration; d++)
                            {
                            if (Note.days > 0)
                                {
                                Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (d).ToString ("yyyy-MM-dd") + "')";
                                }
                            else
                                {
                                Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (-1 * d).ToString ("yyyy-MM-dd") + "')";
                                }
                            }
                        Db.strSQL += ")";
                        Db.strSQL += " UNION SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID INNER JOIN User_Project ON User_Project.Project_Id = Projects.ID";
                        Db.strSQL += " WHERE (User_Project.User_Id = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (LEFT (NoteDatum, 10) = '" + System.DateTime.Now.ToString ("yyyy-MM-dd") + "'";
                        for (int d = 1; d <= Note.days; d++)
                            {
                            Db.strSQL += " OR (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (d).ToString ("yyyy-MM-dd") + "')";
                            }
                        Db.strSQL += ") ORDER BY NoteDatum";
                        break;
                        }
                case "oneday":
                        {
                        Db.strSQL = "SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID";
                        Db.strSQL += " WHERE (Projects.User_ID = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (LEFT (NoteDatum, 10) = '" + Note.DateTime + "')";
                        Db.strSQL += " ";
                        Db.strSQL += " UNION SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID INNER JOIN User_Project ON User_Project.Project_Id = Projects.ID";
                        Db.strSQL += " WHERE (User_Project.User_Id = " + User.Id.ToString () + " AND ParentType = 1)";
                        Db.strSQL += " AND (LEFT (NoteDatum, 10) = '" + System.DateTime.Today.AddDays (Note.days).ToString ("yyyy-MM-dd") + "')";
                        Db.strSQL += " ORDER BY NoteDatum";
                        break;
                        }
                }
            Db.DS.Tables["tblNotesCount"].Clear ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS.Tables["tblNotesCount"]);
                CnnSS.Close ();
                //MessageBox.Show ("Rows: " + Db.DS.Tables ["tblNotesCount"].Rows.Count.ToString ());
                }
            //count
            User.NotesDay0 = 0;
            User.NotesDay1 = 0;
            User.NotesDay2 = 0;
            User.NotesDay3 = 0;
            User.NotesDay4 = 0;
            User.NotesDay5 = 0;
            User.NotesDay6 = 0;
            foreach (DataRow r in Db.DS.Tables["tblNotesCount"].Rows)
                {
                if (Strings.Left (r["NoteDatum"].ToString (), 10) == System.DateTime.Now.ToString ("yyyy-MM-dd"))
                    User.NotesDay0++;
                if (Strings.Left (r["NoteDatum"].ToString (), 10) == System.DateTime.Today.AddDays (+1).ToString ("yyyy-MM-dd"))
                    User.NotesDay1++;
                if (Strings.Left (r["NoteDatum"].ToString (), 10) == System.DateTime.Today.AddDays (+2).ToString ("yyyy-MM-dd"))
                    User.NotesDay2++;
                if (Strings.Left (r["NoteDatum"].ToString (), 10) == System.DateTime.Today.AddDays (+3).ToString ("yyyy-MM-dd"))
                    User.NotesDay3++;
                if (Strings.Left (r["NoteDatum"].ToString (), 10) == System.DateTime.Today.AddDays (+4).ToString ("yyyy-MM-dd"))
                    User.NotesDay4++;
                if (Strings.Left (r["NoteDatum"].ToString (), 10) == System.DateTime.Today.AddDays (+5).ToString ("yyyy-MM-dd"))
                    User.NotesDay5++;
                if (Strings.Left (r["NoteDatum"].ToString (), 10) == System.DateTime.Today.AddDays (+6).ToString ("yyyy-MM-dd"))
                    User.NotesDay6++;
                }
            }
        public static void GetThisNote (int id)
            {
            Db.DS.Tables["tblNotesCount"].Clear ();
            Db.strSQL = "SELECT ProjectName, SubProjectName, NoteDatum, Note, Projects.ID, SubProjects.ID, Notes.ID, Done, Rtl FROM Notes INNER JOIN SubProjects ON Parent_ID = SubProjects.ID INNER JOIN Projects ON Project_ID = Projects.ID";
            Db.strSQL += " WHERE Notes.ID = " + id.ToString ();
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS.Tables["tblNotesCount"]);
                CnnSS.Close ();
                }
            }
        public static void PostpondNote (int noteid, int intdays)
            {
            //do UPDATE...
            try
                {
                Db.strSQL = "UPDATE Notes SET NoteDatum=@datum WHERE ID=@id";
                Note.DateTime = System.DateTime.Today.AddDays (intdays).ToString ("yyyy-MM-dd") + Strings.Mid (Note.DateTime, 11); //("yyyy-MM-dd . HH-mm");
                using (var CnnSS = new SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.Parameters.AddWithValue ("@datum", Note.DateTime);//("yyyy-MM-dd . HH-mm");
                    cmd.Parameters.AddWithValue ("@id", noteid.ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        public static void SaveNote (int noteid, string notetext, string dateTime, Boolean rtl, Boolean done)
            {
            Db.strSQL = "UPDATE Notes SET NoteDatum=@notedatum, Note=@note, RTL=@rtl, Done=@done WHERE ID=@id";
            using (var CnnSS = new SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd.Parameters.AddWithValue ("@notedatum", dateTime);
                cmd.Parameters.AddWithValue ("@note", notetext);
                cmd.Parameters.AddWithValue ("@rtl", rtl.ToString ());
                cmd.Parameters.AddWithValue ("@done", done.ToString ());
                cmd.Parameters.AddWithValue ("@id", noteid.ToString ());
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
            }
        public static void SetNoteStatusDone (int noteId, Boolean done)
            {
            Note.Done = done;
            Db.strSQL = "UPDATE Notes SET Done=@done WHERE ID=@id";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                cmd.Parameters.AddWithValue ("@done", done.ToString ());
                cmd.Parameters.AddWithValue ("@id", noteId.ToString ());
                int i = cmd.ExecuteNonQuery ();
                CnnSS.Close ();
                }
            }
        }
    public static class Link
        {
        public static int Id = 0;
        }
    public static class Ref
        {
        public static int Id = 0;
        public static int TypeCode = 0;
        public static string TypeText = "";
        public static string Title = "";
        public static int Attributes = 0;
        public static int ImportStatus = 0;
        /* ImportStatus:
        bit 1: 0:NewFileMode, 1:EditMode
        bit 2: 0:file is selected via frmImport, 1:file is selected via frmAssign
        bit 3: 0:no link, 1:has link
        bit 4: 0:notReady2move/selectAnotherFile, 1:Ready2move
            */
        }
    public static class Instance
        {
        public static string Path = "";
        public static string ClientSN = "";
        }
    public static class eLibFile
        {
        public static string cnnFilename = Application.StartupPath + "eLibcnn";
        public static string Filename = "";
        public static string Extension = "";
        public static string DestinationFolder = "";
        public static string strFilex; //for import a ref
        }
    static class Security
        {
        private static Random Rndx = new Random ();
        public static string Encode (string strString)
            {
            string returnCode = "";
            int tableId = 0;
            int Addn = 0;
            int Coeff = 0;
            try
                {
                //1: add prefix (t s nnn)
                tableId = Rndx.Next (1, 10); //results[1-9]
                returnCode = tableId.ToString ().Trim (); //save tableId before reducing 5 from it
                if (tableId > 5)
                    {
                    tableId -= 5;
                    }
                //Addn: Number of Null chars n:[1-4]
                Addn = Rndx.Next (32, 127); //results[32-126] //Addn = Rndx.Next (60, 123); //results[60-122]
                for (int x = 32; x < 127; x++)
                    {
                    if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][tableId]) == Addn)
                        {
                        Coeff = Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][6]); //[tblSecurityCodes]: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                        returnCode += Strings.Chr (Addn).ToString (); //.Trim()
                        break;
                        }
                    }
                for (int i = 0; i < Coeff; i++)
                    {
                    returnCode += Strings.Chr (Rndx.Next (32, 127)); //results[32-126]  //returnCode += Strings.Chr (Rndx.Next (60, 123));
                    }
                //2: ADD DATA (t s nnn t hh )
                string strHH = "";
                for (int j = 0; j < strString.Length; j++)
                    {
                    tableId = Rndx.Next (1, 10); // results[1-9]
                    returnCode += tableId.ToString ().Trim ();
                    if (tableId > 5)
                        {
                        tableId -= 5;
                        }
                    //Addn
                    Addn = Rndx.Next (32, 127); // results[32-126]  //Addn = Rndx.Next (60, 123);
                    returnCode += Strings.Chr (Addn).ToString (); //.Trim();
                    for (int x = 32; x < 127; x++)
                        {
                        if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][tableId]) == Addn)
                            {
                            Coeff = Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][6]); //[tblSecurityCodes]: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            break;
                            }
                        }
                    for (int i = 0; i < Coeff; i++)
                        {
                        returnCode += Strings.Chr (Rndx.Next (32, 127)); //results[32-126]   //returnCode += Strings.Chr (Rndx.Next (60, 123));
                        }
                    //tableId for data part in string
                    tableId = Rndx.Next (1, 10); // results[1-9]
                    returnCode += tableId.ToString ().Trim ();
                    if (tableId > 5)
                        {
                        tableId -= 5;
                        }
                    //data
                    strHH = Conversion.Hex (Db.DS.Tables["tblSecurityCodes"].Rows[Strings.Asc (Strings.Mid (strString, j + 1, 1)) - 32][tableId]).ToString ().Trim ();
                    if (tableId % 2 != 0) // tableId is odd
                        {
                        strHH = (Strings.Mid (strHH, 2, 1) + Strings.Mid (strHH, 1, 1)).Trim ();
                        }
                    returnCode += strHH;
                    }
                //3:ADD SUFFIX (x nnn)
                //nx: Number of Null chars in suffix
                int nx = Rndx.Next (1, 10); //results[1-9]
                returnCode += nx.ToString ().Trim (); //save nx before reducing 5 from it
                if (nx > 5)
                    {
                    nx -= 5;
                    }
                for (int i = 0; i < nx; i++)
                    {
                    returnCode += Strings.Chr (Rndx.Next (32, 127)); //results[32-126]    //returnCode += Strings.Chr (Rndx.Next (60, 123));
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show ("err");
                //returnCode = "";
                }
            return returnCode;
            }
        public static string Decode (string strCode)
            {
            string DecodeRet = default;
            string R_Code = strCode;
            int tableId = 0;
            int Addn = 0;
            int Coeff = 0;
            string hexData = "";
            int decData = 0;
            string strSN = "";
            try
                {
                tableId = Convert.ToInt32 (Strings.Left (R_Code, 1));
                if (tableId > 5)
                    {
                    tableId -= 5;
                    }
                Addn = Strings.Asc (Strings.Mid (R_Code, 2, 1));
                for (int x = 32; x <= 126; x++)
                    {
                    if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][tableId]) == Addn) // items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                        {
                        Coeff = Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][6]); // items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                        break;
                        }
                    }
                R_Code = Strings.Mid (R_Code, 2 + Coeff + 1); //Part-Prefix Removed
                //begin parsing Part-Data
                while (Strings.Len (R_Code) > 7)
                    {
                    //For Each one Char In SN:
                    //Remove the leading null-chars
                    tableId = Convert.ToInt32 (Strings.Left (R_Code, 1));
                    if (tableId > 5)
                        {
                        tableId -= 5;
                        }
                    Addn = Strings.Asc (Strings.Mid (R_Code, 2, 1));
                    for (int x = 32; x <= 126; x++)
                        {
                        if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][tableId]) == Addn) // items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            {
                            Coeff = Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][6]); // items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            break;
                            }
                        }
                    R_Code = Strings.Mid (R_Code, 2 + Coeff + 1);
                    //leading null-chars removed, OK
                    tableId = Convert.ToInt32 (Strings.Left (R_Code, 1)); //table-id of the data
                    if (tableId > 5)
                        {
                        tableId -= 5;
                        }
                    hexData = Strings.Mid (R_Code, 2, 2);
                    if (tableId % 2 != 0) //tableId is odd
                        {
                        hexData = Strings.Mid (hexData, 2, 1) + Strings.Mid (hexData, 1, 1); //re-invert
                        }
                    decData = Convert.ToInt32 (hexData, 16); //decData = Conversions.ToInteger ("&H" + hexData);
                    for (int x = 32; x <= 126; x++)
                        {
                        if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][tableId]) == decData) //items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            {
                            strSN = strSN + Strings.Chr (Conversions.ToInteger (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][0])); //items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            break;
                            }
                        }
                    R_Code = Strings.Mid (R_Code, 4);
                    }
                DecodeRet = strSN;
                }
            catch (Exception ex)
                {
                DecodeRet = "";
                //MessageBox.Show ("RCode:\n" + R_Code + "\nError in Eccoding:\n" + ex.ToString ());
                }
            return DecodeRet;
            }
        public static string EncodeHex (string strString)
            {
            string returnCode = "";
            int tableId = 0;
            string tableIdAsciiHex = "";
            int Addn = 0;
            int Coeff = 0;
            try
                {
                //1: add prefix (t s nnn)
                tableId = Rndx.Next (1, 10); //results[1-9]
                tableIdAsciiHex = Conversion.Hex (Strings.Asc (tableId.ToString ().Trim ())); //HH(t)
                returnCode = tableIdAsciiHex;
                if (tableId > 5)
                    {
                    tableId -= 5;
                    }
                //Addn: number of null chars n:[1-4]
                Addn = Rndx.Next (32, 127);
                for (int x = 32; x < 127; x++)
                    {
                    if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][tableId]) == Addn)
                        {
                        Coeff = Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][6]); //[tblSecurityCodes]: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                        returnCode += Strings.Chr (Addn).ToString (); //
                        break;
                        }
                    }
                for (int i = 0; i < Coeff; i++)
                    {
                    returnCode += Strings.Chr (Rndx.Next (32, 127)); //results[32-126]  //returnCode += Strings.Chr (Rndx.Next (60, 123));
                    }
                //2: loop to add all DATA (t s nnn t hh )
                string strHH = "";
                for (int j = 0; j < strString.Length; j++)
                    {
                    tableId = Rndx.Next (1, 10); //results[1-9]
                    tableIdAsciiHex = Conversion.Hex (Strings.Asc (tableId.ToString ().Trim ())); //HH(t)
                    returnCode += tableIdAsciiHex;
                    if (tableId > 5)
                        {
                        tableId -= 5;
                        }
                    //Addn
                    Addn = Rndx.Next (32, 127); // results[32-126]  //Addn = Rndx.Next (60, 123);
                    returnCode += Strings.Chr (Addn).ToString (); //.Trim();
                    for (int x = 32; x < 127; x++)
                        {
                        if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][tableId]) == Addn)
                            {
                            Coeff = Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][6]); //[tblSecurityCodes]: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            break;
                            }
                        }
                    for (int i = 0; i < Coeff; i++)
                        {
                        returnCode += Strings.Chr (Rndx.Next (32, 127));
                        }
                    //tableId for data part in string
                    tableId = Rndx.Next (1, 10); //results[1-9]
                    tableIdAsciiHex = Conversion.Hex (Strings.Asc (tableId.ToString ().Trim ())); //HH(t)
                    returnCode += tableIdAsciiHex;
                    if (tableId > 5)
                        {
                        tableId -= 5;
                        }
                    //data
                    strHH = Conversion.Hex (Db.DS.Tables["tblSecurityCodes"].Rows[Strings.Asc (Strings.Mid (strString, j + 1, 1)) - 32][tableId]).ToString ().Trim ();
                    if (tableId % 2 != 0) // tableId is odd
                        {
                        strHH = (Strings.Mid (strHH, 2, 1) + Strings.Mid (strHH, 1, 1)).Trim ();
                        }
                    returnCode += strHH;
                    }
                //3:ADD SUFFIX (x nnn)
                //nx: Number of Null chars in suffix
                int nx = Rndx.Next (1, 10); //results[1-9]
                string nxAsciiHex = Conversion.Hex (Strings.Asc (nx.ToString ().Trim ())); //HH(t)
                returnCode += nxAsciiHex;
                if (nx > 5)
                    {
                    nx -= 5;
                    }
                for (int i = 0; i < nx; i++)
                    {
                    returnCode += Strings.Chr (Rndx.Next (32, 127)); //results[32-126]    //returnCode += Strings.Chr (Rndx.Next (60, 123));
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show ("err");
                //returnCode = "";
                }
            return returnCode;
            }
        public static string DecodeHex (string strCode)
            {
            string DecodeRet = default;
            string R_Code = strCode;
            int tableId = 0;
            int Addn = 0;
            int Coeff = 0;
            string hexData = "";
            int decData = 0;
            string strSN = "";
            try
                {
                tableId = Convert.ToInt32 (Strings.Chr (Convert.ToInt32 (Strings.Left (R_Code, 1), 16))); //convert hex to int32
                if (tableId > 5)
                    {
                    tableId -= 5;
                    }
                Addn = Strings.Asc (Strings.Mid (R_Code, 2, 1));
                for (int x = 32; x <= 126; x++)
                    {
                    if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][Convert.ToInt32 (tableId.ToString (), 16)]) == Addn) // items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                        {
                        Coeff = Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][6]); // items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                        break;
                        }
                    }
                R_Code = Strings.Mid (R_Code, 2 + Coeff + 1); //Part-Prefix Removed
                //begin parsing Part-Data
                while (Strings.Len (R_Code) > 7)
                    {
                    //For Each one Char In SN:
                    //Remove the leading null-chars
                    tableId = Convert.ToInt32 (Strings.Chr (Convert.ToInt32 (Strings.Left (R_Code, 1), 16))); //convert hex to int32
                    if (tableId > 5)
                        {
                        tableId -= 5;
                        }
                    Addn = Strings.Asc (Strings.Mid (R_Code, 2, 1));
                    for (int x = 32; x <= 126; x++)
                        {
                        if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][tableId]) == Addn) // items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            {
                            Coeff = Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][6]); // items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            break;
                            }
                        }
                    R_Code = Strings.Mid (R_Code, 2 + Coeff + 1);
                    //leading null-chars removed, OK
                    tableId = Convert.ToInt32 (Strings.Chr (Convert.ToInt32 (Strings.Left (R_Code, 1), 16))); //convert hex to int32
                    if (tableId > 5)
                        {
                        tableId -= 5;
                        }
                    hexData = Strings.Mid (R_Code, 2, 2);
                    if (tableId % 2 != 0) //tableId is odd
                        {
                        hexData = Strings.Mid (hexData, 2, 1) + Strings.Mid (hexData, 1, 1); //re-invert
                        }
                    decData = Convert.ToInt32 (hexData, 16); //decData = Conversions.ToInteger ("&H" + hexData);
                    for (int x = 32; x <= 126; x++)
                        {
                        if (Convert.ToInt32 (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][tableId]) == decData) //items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            {
                            strSN = strSN + Strings.Chr (Conversions.ToInteger (Db.DS.Tables["tblSecurityCodes"].Rows[x - 32][0])); //items: 0:Ascii, 1-5:Tab1-5, 6:Coeff
                            break;
                            }
                        }
                    R_Code = Strings.Mid (R_Code, 4);
                    }
                DecodeRet = strSN;
                }
            catch (Exception ex)
                {
                DecodeRet = "";
                //MessageBox.Show ("RCode:\n" + R_Code + "\nError in Eccoding:\n" + ex.ToString ());
                }
            return DecodeRet;
            }
        }
    internal class Report
        {
        public static int Settings = 0x3;   //&H2C = &B000000011 = 3 
        public static string Caption = "";
        public static string Header = "eLib Desktop App [ www.msht.ir ],  by: Dr. Majid Sharifi-Tehrani, Faculty of Science (SKU), 2024";
        public static string Footer = "eLib Desktop App [ www.msht.ir ],  by: Dr. Majid Sharifi-Tehrani, Faculty of Science (SKU), 2024";
        }
    public class Species
        {
        public static int Id;
        public static string SciName;
        public static string Taxonomy;
        public static int ProjectId;
        }
    public static class Cluster
        {
        public static int Id;
        public static string Name;
        public static int SpeciesId;
        }
    public static class Transcript
        {
        public static int Id;
        public static string Name;
        public static int ClusterId;
        public static int SpacerLength;
        public static int TranscriptFrom;
        public static int TranscriptTo;
        public static int GeneSize;
        public static int PereviousGeneEnd;
        public static string Direction;
        public static string Description;
        public static Boolean Sel;
        public static string Info;
        }
    public static class Sequence
        {
        public static int Id;
        public static int ParentType;
        public static int ParentId;
        public static int SequenceType;
        public static string SequenceText;
        }
    public static class Palette
        {
        public static int ID = 0;
        public static int Rcolor = 0;
        public static int Gcolor = 0;
        public static int Bcolor = 0;
        }
    }
