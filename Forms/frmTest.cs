using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmTest : System.Windows.Forms.Form
        {
        public frmTest ()
            {
            InitializeComponent ();
            }
        private void frmTest_Load (object sender, EventArgs e)
            {
            Width = 1255;
            Height = 600;
            this.Text = "eLib.Courses.Testbank";
            try
                {
                chkDblClick2Paste.Checked = (Testbank.PasteOnDblClick) ? true : false;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            cboTests.DataSource = Db.DS.Tables["tblTests"];
            cboTests.DisplayMember = "TestTitle";
            cboTests.ValueMember = "ID";
            cboTests.SelectedValue = Test.Id;
            ShowTest ();
            RefreshTestOptionsList (Test.Id);
            }
        private void cboTests_SelectedIndexChanged (object sender, EventArgs e)
            {
            try
                {
                if (Convert.ToInt32 (cboTests.SelectedIndex) >= 0)
                    {
                    Test.Id = Convert.ToInt32 (cboTests.SelectedValue);
                    Testbank.GetTestById (Test.Id);
                    ShowTest ();
                    RefreshTestOptionsList (Test.Id);
                    }
                }
            catch { }
            }
        private void frmTest_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode.ToString () == "F5")
                {
                e.SuppressKeyPress = true;
                lblSave_Click (null, null);
                }
            else if (e.KeyCode.ToString () == "Escape")
                {
                e.SuppressKeyPress = true;
                lblExit_Click (null, null);
                }
            }
        private void txtTest_DoubleClick (object sender, EventArgs e)
            {
            if ((My.MyProject.Computer.Clipboard.ContainsText ()) && (chkDblClick2Paste.Checked))
                {
                //paste from clipboard
                txtTest.Text = Strings.Left ((My.MyProject.Computer.Clipboard.GetText ()), 510);
                }
            }
        private void gridOptions_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if ((gridOptions.Rows.Count == 0) || (gridOptions.SelectedCells[0].RowIndex == -1))
                {
                return;
                }
            else
                {
                //ID, Test_ID, OptionText, IsAnswer, ForceLast
                int optID = Convert.ToInt32 (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[0].Value);
                int optTestID = Convert.ToInt32 (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[1].Value);
                string currentOptText = gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[2].Value.ToString () ?? "-";
                string newOptText = currentOptText; //just an initial/temporary value
                bool optIsAns = Convert.ToBoolean (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[3].Value);
                bool optForce = Convert.ToBoolean (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[4].Value);
                switch (gridOptions.SelectedCells[0].ColumnIndex)
                    {
                    case 2:
                            {
                            if (My.MyProject.Computer.Clipboard.ContainsText ())
                                {
                                if (chkDblClick2Paste.Checked)
                                    {
                                    //paste from clipboard
                                    newOptText = Strings.Left ((My.MyProject.Computer.Clipboard.GetText ()), 320);
                                    //save optText in clipboard
                                    //My.MyProject.Computer.Clipboard.SetText (currentOptText);
                                    }
                                else
                                    {
                                    //dialog Input
                                    string strOpt = Interaction.InputBox ("Option:", "eLib", currentOptText);
                                    if (strOpt.Trim () != "")
                                        {
                                        newOptText = strOpt;
                                        }
                                    else
                                        {
                                        newOptText = currentOptText;
                                        return;
                                        }
                                    }
                                }
                            break;
                            }
                    case 3:
                            {
                            optIsAns = !optIsAns;
                            break;
                            }
                    case 4:
                            {
                            optForce = !optForce;
                            break;
                            }
                    }
                if (newOptText.Trim () != "")
                    {
                    bool result = Testbank.UpdateTestOption (optID, newOptText, optIsAns, optForce);
                    if (result) //(Testbank.regTestBank |= 0b10000) == 0b01111
                        {
                        RefreshTestOptionsList (Test.Id);
                        }
                    }
                }
            }
        private void chkTestRTL_CheckedChanged (object sender, EventArgs e)
            {
            if (chkTestRTL.Checked)
                {
                txtTest.RightToLeft = RightToLeft.Yes;
                }
            else
                {
                txtTest.RightToLeft = RightToLeft.No;
                }
            }
        private void chkOptionsRTL_CheckedChanged (object sender, EventArgs e)
            {
            if (chkOptionsRTL.Checked)
                {
                gridOptions.RightToLeft = RightToLeft.Yes;
                }
            else
                {
                gridOptions.RightToLeft = RightToLeft.No;
                }
            }
        private void chkDblClick2Paste_CheckedChanged (object sender, EventArgs e)
            {
            Testbank.PasteOnDblClick = chkDblClick2Paste.Checked;
            }
        //radios
        private void radio5_CheckedChanged (object sender, EventArgs e)
            {
            //
            }
        private void radio4_CheckedChanged (object sender, EventArgs e)
            {
            //
            }
        private void radio3_CheckedChanged (object sender, EventArgs e)
            {
            //
            }
        private void radio2_CheckedChanged (object sender, EventArgs e)
            {
            //
            }
        private void radio1_CheckedChanged (object sender, EventArgs e)
            {
            //
            }
        //Menu1
        private void Menu_Save_Click (object sender, EventArgs e)
            {
            DoSave ();
            }
        private void lblSave_Click (object sender, EventArgs e)
            {
            DoSave ();
            }
        //Menu2
        private void Menu2_AddOption_Click (object sender, EventArgs e)
            {
            //Add an option {text + ans + force?}
            if (radio5.Checked == true)
                {
                Test.Type = 5;
                }
            else if (radio4.Checked == true)
                {
                Test.Type = 4;
                }
            else if (radio3.Checked == true)
                {
                Test.Type = 3;
                }
            else if (radio2.Checked == true)
                {
                Test.Type = 2;
                }
            else
                {
                Test.Type = 1;
                }
            if (gridOptions.Rows.Count < Test.Type)
                {
                Testbank.AddTestOption (Test.Id, "_new option", false, false);
                RefreshTestOptionsList (Test.Id);
                }
            }
        private void Menu2_EditOption_Click (object sender, EventArgs e)
            {
            if (gridOptions.Rows.Count == 0)
                {
                return;
                }
            else
                {
                //[tblTestOptions]: ID, Test_ID, OptionText, IsAnswer, ForceLast
                if (gridOptions.SelectedCells[0].ColumnIndex == 2)
                    {
                    int optID = Convert.ToInt32 (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[0].Value);
                    int optTestID = Convert.ToInt32 (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[1].Value);
                    string optText = gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[2].Value.ToString ();
                    bool optIsAns = Convert.ToBoolean (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[3].Value);
                    bool optForce = Convert.ToBoolean (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[4].Value);
                    string strOpt = Interaction.InputBox ("Option:", "eLib", optText);
                    if (strOpt.Trim () != "")
                        {
                        optText = strOpt;
                        bool result = Testbank.UpdateTestOption (optID, optText, optIsAns, optForce);
                        if (result) //(Testbank.regTestBank |= 0b10000) == 0b01111
                            {
                            RefreshTestOptionsList (Test.Id);
                            }
                        }
                    }
                }
            }
        private void Menu2_DeleteOption_Click (object sender, EventArgs e)
            {
            //Delete selected option
            if ((gridOptions.Rows.Count == 0) || (gridOptions.SelectedCells[0].RowIndex == 0))
                {
                return;
                }
            else
                {
                DialogResult myansw = MessageBox.Show ("Delete?", "eLib", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (myansw == DialogResult.Yes)
                    {
                    int optID = Convert.ToInt32 (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[0].Value);
                    int optTestID = Convert.ToInt32 (gridOptions.Rows[gridOptions.SelectedCells[0].RowIndex].Cells[1].Value);
                    bool result = Testbank.DeleteTestOptionById (optID);
                    if (result)
                        {
                        RefreshTestOptionsList (optTestID);
                        }
                    }
                }
            }
        //methods
        private void ShowTest ()
            {
            Testbank.GetTestById (Test.Id);
            //[tblTest1]: 0ID, 1TestTitle, 2TestType, 3Course_ID, 4TopicId, 5TestRTL, 6OptionsRTL, 7ForceLast, 8TestLevel
            Test.Text = Db.DS.Tables["tblTest1"].Rows[0][1].ToString ();
            Test.TestTags = Convert.ToBoolean (Db.DS.Tables["tblTest1"].Rows[0][5]);
            if (Test.TestTags)
                {
                txtTest.RightToLeft = RightToLeft.Yes;
                chkTestRTL.Checked = true;
                }
            else
                {
                txtTest.RightToLeft = RightToLeft.No;
                chkTestRTL.Checked = false;
                }
            Test.TestTags = Convert.ToBoolean (Db.DS.Tables["tblTest1"].Rows[0][6]);
            if (Test.TestTags)
                {
                gridOptions.RightToLeft = RightToLeft.Yes;
                chkOptionsRTL.Checked = true;
                }
            else
                {
                gridOptions.RightToLeft = RightToLeft.No;
                chkOptionsRTL.Checked = false;
                }
            Test.Type = Convert.ToInt32 (Db.DS.Tables["tblTest1"].Rows[0][2]);
            Test.TopicId = Convert.ToInt32 (Db.DS.Tables["tblTest1"].Rows[0][4]);
            txtTest.Text = Test.Text;
            switch (Test.Type)
                {
                case 5:
                        {
                        radio5.Checked = true;
                        break;
                        }
                case 4:
                        {
                        radio4.Checked = true;
                        break;
                        }
                case 3:
                        {
                        radio3.Checked = true;
                        break;
                        }
                case 2:
                        {
                        radio2.Checked = true;
                        break;
                        }
                case 1:
                        {
                        radio1.Checked = true;
                        break;
                        }
                }
            //show level
            Test.Level = Convert.ToInt32 (Db.DS.Tables["tblTest1"].Rows[0][7]);
            for (int i = 4; i >= 0; i--)
                {
                if (((long) Test.Level & (long) Math.Pow (2, i)) != 0)
                    {
                    lvl1.Value = i + 1;
                    }
                }
            for (int i = 0; i < 5; i++)
                {
                if (((long) Test.Level & (long) Math.Pow (2, i)) != 0)
                    {
                    lvl2.Value = i + 1;
                    }
                }
            //show topic
            Testbank.GetCourseTopics (Course.Id);
            //[tblCourseTopics]: ID, Course_ID, Topic
            lstTopics.DataSource = Db.DS.Tables["tblCourseTopics"];
            lstTopics.DisplayMember = "Topic";
            lstTopics.ValueMember = "ID";
            lstTopics.SelectedValue = Test.TopicId;
            if (Testbank.CourseRTL)
                {
                lstTopics.RightToLeft = RightToLeft.Yes;
                }
            else
                {
                lstTopics.RightToLeft = RightToLeft.No;
                }
            }
        private void RefreshTestOptionsList (int testid)
            {
            Testbank.GetTestOptions (testid);
            gridOptions.DataSource = Db.DS.Tables["tblTestOptions"];
            for (int i = 0, loopTo = gridOptions.Columns.Count - 1; i <= loopTo; i++) //disable sort for column_haeders
                {
                gridOptions.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            //ID, Test_ID, OptionText, IsAnswer, ForceLast
            gridOptions.Columns[0].Visible = false;   //ID
            gridOptions.Columns[1].Visible = false;   //Test_ID
            gridOptions.Columns[2].Width = 750;       //OptionText
            gridOptions.Columns[3].Width = 70;        //IsAnswer
            gridOptions.Columns[4].Width = 90;        //ForceLast
            }
        private void DoSave ()
            {
            //text
            Test.Text = txtTest.Text.Trim ();
            if (Test.Text.Length == 0)
                {
                txtTest.Focus ();
                txtTest.SelectionStart = 1;
                txtTest.SelectionLength = txtTest.TextLength;
                return;
                }
            //topic-id
            if (lstTopics.SelectedIndex == -1)
                {
                if (lstTopics.Items.Count == 1)
                    {
                    lstTopics.SelectedIndex = 0;
                    Test.TopicId = Convert.ToInt32 (lstTopics.SelectedValue);
                    }
                else
                    {
                    MessageBox.Show ("Topic ?", "eLib");
                    lstTopics.Focus ();
                    return;
                    }
                }
            else
                {
                Test.TopicId = Convert.ToInt32 (lstTopics.SelectedValue);
                }
            //type and opts
            if (radio5.Checked == true)
                {
                Test.Type = 5;
                if (gridOptions.Rows.Count != Test.Type)
                    {
                    MessageBox.Show ("Check Number of Options!", "eLib");
                    return;
                    }
                }
            else if (radio4.Checked == true)
                {
                Test.Type = 4;
                if (gridOptions.Rows.Count != Test.Type)
                    {
                    MessageBox.Show ("Check Number of Options!", "eLib");
                    return;
                    }
                }
            else if (radio3.Checked == true)
                {
                Test.Type = 3;
                if (gridOptions.Rows.Count != Test.Type)
                    {
                    MessageBox.Show ("Check Number of Options!", "eLib");
                    return;
                    }
                }
            else if (radio2.Checked == true)
                {
                Test.Type = 2;
                if (gridOptions.Rows.Count != Test.Type)
                    {
                    MessageBox.Show ("Check Number of Options!", "eLib");
                    return;
                    }
                }
            else
                {
                Test.Type = 1;
                if (gridOptions.Rows.Count != Test.Type)
                    {
                    MessageBox.Show ("Check Number of Options!", "eLib");
                    return;
                    }
                }
            //rtl
            Test.TestTags = chkTestRTL.Checked;
            Test.TestTags = chkOptionsRTL.Checked;
            //level
            Test.Level = 0; //initialize to 0
            if (lvl1.Value > lvl2.Value)
                {
                lvl2.Value = lvl1.Value;
                }
            //calc
            Test.Level = 0;
            for (int i = lvl1.Value - 1; i < lvl2.Value; i++)
                {
                Test.Level += Convert.ToInt32 ((long) Math.Pow (2, i));
                }
            //check doual-answeres!
            try
                {
                if (gridOptions.Rows.Count > 1)
                    {
                    //for multiple-choice tests
                    int tmp_nAns = 0;
                    for (int i = 0; i < gridOptions.Rows.Count; i++)
                        {
                        if (Convert.ToBoolean (gridOptions.Rows[i].Cells[3].Value) == true)
                            {
                            tmp_nAns++;
                            }
                        }
                    if ((tmp_nAns > 1) || (tmp_nAns == 0))
                        {
                        DialogResult myansw = MessageBox.Show ("Check Options and Answers!\n\n Save anayway?", "eLib", MessageBoxButtons.OKCancel);
                        if (myansw == DialogResult.Cancel)
                            {
                            return;
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); //shows a conversion error at formLoad 
                }
            //save
            Testbank.UpdateTest (Test.Id, "course");
            Testbank.regTestBank |= 0b010000;
            Db.DS.Tables["tbltests"].Rows[cboTests.SelectedIndex][1] = Test.Text;
            //Dispose ();
            MessageBox.Show ("Saved", "eLib.ExamTests");
            }
        //exit
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        private void lblExit_Click (object sender, EventArgs e)
            {
            Testbank.regTestBank &= 0b01111; //set bit5 off: not-saved 
            Dispose ();
            }

        private void btn_Previous_Click (object sender, EventArgs e)
            {
            try
                {
                cboTests.SelectedIndex -= 1;
                }
            catch { }
            }

        private void btn_Next_Click (object sender, EventArgs e)
            {
            try
                {
                cboTests.SelectedIndex += 1;
                }
            catch { }
            }
        }
    }
