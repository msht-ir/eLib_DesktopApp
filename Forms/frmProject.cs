using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmProject
        {
        public frmProject ()
            {
            InitializeComponent ();
            }
        private void frmProject_Load (object sender, EventArgs e)
            {
            Width = 500;
            Height = 225;
            //Client.DialogRequestParams: bits: 1:Project 2:SubProjects 3:User Add/Edit
            //Client.DialogRequestParams bits: 4: 0:new 1:edit
            switch (Client.DialogRequestParams)
                {
                case 1: //project + new
                        {
                        Text = "NOTE: New Project:";
                        txtProjectName.Text = "Prj " + DateTime.Now.ToString ("yyyy.MM.dd-HH:mm") + "- EDIT";
                        txtProjectNote.Text = "note";
                        CheckBoxActive.Checked = true;
                        txtProjectName.Focus ();
                        txtProjectName.SelectionStart = 0;
                        txtProjectName.SelectionLength = Strings.Len (txtProjectName.Text);
                        break;
                        }
                case 9: //project + edit 
                        {
                        Text = "Edit Project:";
                        txtProjectName.Text = Project.Name;
                        txtProjectNote.Text = Project.Note;
                        CheckBoxActive.Checked = Project.IsActive;
                        txtProjectName.Focus ();
                        txtProjectName.SelectionStart = 0;
                        txtProjectName.SelectionLength = Strings.Len (txtProjectName.Text);
                        break;
                        }
                case 2: //subProject + new 
                        {
                        Text = "subProject:";
                        CheckBoxActive.Enabled = false;
                        Text = "New subProject:";
                        txtProjectName.Text = SubProject.Name;
                        txtProjectNote.Text = SubProject.Note;
                        txtProjectName.Focus ();
                        txtProjectName.SelectionStart = 0;
                        txtProjectName.SelectionLength = Strings.Len (txtProjectName.Text);
                        break;
                        }
                case 10: //subProject + edit 
                        {
                        Text = "subProject:";
                        CheckBoxActive.Enabled = false;
                        Text = "Edit subProject:";
                        txtProjectName.Text = Project.Name;
                        txtProjectNote.Text = Project.Note;
                        txtProjectName.Focus ();
                        txtProjectName.SelectionStart = 0;
                        txtProjectName.SelectionLength = Strings.Len (txtProjectName.Text);
                        break;
                        }
                case 4: //userPassword + new 
                        {
                        CheckBoxActive.Enabled = true;
                        Text = "New User:";
                        txtProjectName.Text = "User-" + DateTime.Now.ToString ("HHmmss") + "   - EDIT";
                        txtProjectNote.Text = "[password]";
                        // txtProjectNote.PasswordChar = "-"
                        txtProjectName.Focus ();
                        txtProjectName.SelectionStart = 0;
                        txtProjectName.SelectionLength = Strings.Len (txtProjectName.Text);
                        break;
                        }
                case 12: //userPassword + edit 
                        {
                        Text = "Change Password:";
                        txtProjectName.Text = Project.Name;
                        CheckBoxActive.Checked = Project.IsActive;
                        txtProjectName.Enabled = false;
                        txtProjectNote.Focus ();
                        txtProjectNote.Text = Project.Note;
                        txtProjectNote.SelectionStart = 0;
                        txtProjectNote.SelectionLength = Strings.Len (txtProjectNote.Text);
                        break;
                        }
                case 128: //new Student (bit8 on, bit4 off)
                        {
                        CheckBoxActive.Enabled = false;
                        Text = "New Student:";
                        txtProjectName.Text = Project.Name;
                        txtProjectNote.Text = Project.Note;
                        txtProjectName.Focus ();
                        txtProjectName.SelectionStart = 0;
                        txtProjectName.SelectionLength = Strings.Len (txtProjectName.Text);
                        break;
                        }
                case 136: //edit Student (bit8 on, bit4 on)
                        {
                        CheckBoxActive.Enabled = false;
                        Text = "Edit Student:";
                        txtProjectName.Text = Project.Name;
                        CheckBoxActive.Checked = true;
                        txtProjectName.Enabled = true;
                        txtProjectNote.Text = Project.Note;
                        txtProjectName.Focus ();
                        txtProjectName.SelectionStart = 0;
                        txtProjectName.SelectionLength = Strings.Len (txtProjectName.Text);
                        break;
                        }
                }
            }
        private void frmProject_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode.ToString () == "F5")
                {
                e.SuppressKeyPress = true;
                lblSave_Click (null, null);
                }
            else if (e.KeyCode.ToString () == "Escape")
                {
                e.SuppressKeyPress = true;
                lblCancel_Click (null, null);
                }
            }
        private void txtProjectName_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Down:
                case Keys.Enter:
                        {
                        e.SuppressKeyPress = true;
                        txtProjectNote.Focus ();
                        txtProjectNote.SelectionStart = 0;
                        txtProjectNote.SelectionLength = Strings.Len (txtProjectNote.Text);
                        break;
                        }
                case Keys.Escape:
                        {
                        e.SuppressKeyPress = true;
                        Menu_Cancel_Click (null, null);
                        break;
                        }
                }
            }
        private void txtProjectNote_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Enter:
                        {
                        if (Strings.Right (txtProjectName.Text, 6) == "- EDIT")
                            {
                            txtProjectName.Focus ();
                            txtProjectName.SelectionStart = 0;
                            txtProjectName.SelectionLength = Strings.Len (txtProjectName.Text);
                            e.SuppressKeyPress = true;
                            return;
                            }
                        if (Strings.Trim (txtProjectNote.Text) == "[password]")
                            {
                            txtProjectNote.SelectionStart = 0;
                            txtProjectNote.SelectionLength = Strings.Len (txtProjectNote.Text);
                            e.SuppressKeyPress = true;
                            return;
                            }
                        Menu_Save_Click (sender, e);
                        break;
                        }
                case Keys.Up:
                        {
                        try
                            {
                            e.SuppressKeyPress = true;
                            txtProjectName.Focus ();
                            }
                        catch { }
                        break;
                        }
                }
            }
        private void lblSave_Click (object sender, EventArgs e)
            {
            DoSave ();
            }
        private void Menu_Save_Click (object sender, EventArgs e)
            {
            DoSave ();
            }
        private void DoSave ()
            {
            if (Client.DialogRequestParams == 4)
                {
                //mode:userPassNew: chack space does not exist in username
                if ((string.IsNullOrEmpty (Strings.Trim (txtProjectName.Text))) || (txtProjectName.Text.Contains (" ")))
                    {
                    MessageBox.Show ("Notice: remove space(s) from Username");
                    txtProjectName.Focus ();
                    txtProjectName.SelectionStart = 0;
                    txtProjectName.SelectionLength = txtProjectName.Text.Length;
                    return;
                    }
                }
            Project.Name = txtProjectName.Text;
            Project.Note = txtProjectNote.Text;
            Project.IsActive = CheckBoxActive.Checked;
            if (string.IsNullOrEmpty (Strings.Trim (Project.Name)))
                {
                txtProjectName.Focus ();
                return;
                }
            else
                {
                Client.DialogRequestParams = 16; //set bit5 (00010000): 0:cancel, 1:save 
                Dispose ();
                }
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Menu_Cancel_Click (null, null);
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 0; //set bit5 (00010000): 0:cancel, 1:save 
            Dispose ();
            }
        }
    }