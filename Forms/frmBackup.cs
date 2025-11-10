using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmBackup : Form
        {
        public frmBackup ()
            {
            InitializeComponent ();
            }
        private void frmBackup_Load (object sender, EventArgs e)
            {
            Width = 390;
            Height = 650;
            treeView1.ExpandAll ();
            }
        private void treeView1_AfterSelect (object sender, TreeViewEventArgs e)
            {
            switch (treeView1.SelectedNode.FullPath.ToString ())
                {
                case "eLib data - select all":
                case "eLib data - select all\\Files":
                case "eLib data - select all\\Projects":
                case "eLib data - select all\\Links (assignments)":
                case "eLib data - select all\\Notes":
                case "eLib data - select all\\TestBank":
                        {
                        break;
                        }
                default:
                        {
                        treeView1.SelectedNode = treeView1.TopNode;
                        break;
                        }
                }
            }
        //MENUS
        private void lblBackup_Click (object sender, EventArgs e)
            {
            Menu_Select_Click (null, null);
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Menu_Cancel_Click (null, null);
            }
        private void Menu_Select_Click (object sender, EventArgs e)
            {
            /*
                  bit1:1   0000'0001  Refs
                  bit2:2   0000'0010  Projects and subProjects
                  bit3:4   0000'0100  Links
                  bit4:8   0000'1000  Notes
                  bit5:16  0001'0000  Backup CET (courses-exams-tests)
                  bit6:32  0010'0000  1:all-users (0: one-user)
                  bit7:64  0-00'0000  reserved
                  bit8:128 1000'0000  backup was successful
            */
            Db.BackupRegister = 0;    //--00 0000
            switch (treeView1.SelectedNode.FullPath.ToString ())
                {
                case "eLib data":                      //0001'1111
                        {
                        Db.BackupRegister = 31;
                        this.Dispose ();
                        break;
                        }
                case "eLib data\\Refs":                //0000'0001
                        {
                        Db.BackupRegister = 1;
                        this.Dispose ();
                        break;
                        }
                case "eLib data\\Projects":            //0000'0010
                        {
                        Db.BackupRegister = 2;
                        this.Dispose ();
                        break;
                        }
                case "eLib data\\Links":               //0000'0111
                        {
                        Db.BackupRegister = 7;
                        this.Dispose ();
                        break;
                        }
                case "eLib data\\Notes":
                        {
                        Db.BackupRegister = 11;        //0000'1011
                        this.Dispose ();
                        break;
                        }
                case "eLib data\\TestBank":
                        {
                        Db.BackupRegister = 16;        //0001'0000
                        this.Dispose ();
                        break;
                        }
                default:
                        {
                        Db.BackupRegister = 0;         //0000'0000
                        treeView1.SelectedNode = treeView1.TopNode;
                        break;
                        }
                }
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            Db.BackupRegister = 0;
            this.Dispose ();
            }
        }
    }
