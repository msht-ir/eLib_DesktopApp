using System;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmRefAttributes
        {
        public frmRefAttributes ()
            {
            InitializeComponent ();
            }
        private void frmRefAttributes_Load (object sender, EventArgs e)
            {
            //show Attributes
            LabelRefTitle.Text = Ref.Title;
            // reset off all checkboxes
            CheckBoxPaper.Checked = false;
            CheckBoxBook.Checked = false;
            CheckBoxManual.Checked = false;
            CheckBoxLecture.Checked = false;
            CheckBoxImp1.Checked = false;
            CheckBoxImp2.Checked = false;
            CheckBoxImp3.Checked = false;
            CheckBoxImR.Checked = false;
            //1111-1111 {ImR.Imp3.Imp2.Imp1.Lect.Man.Book.Paper}
            if ((Ref.Attributes & 1) == 1)
                CheckBoxPaper.Checked = true;
            if ((Ref.Attributes & 2) == 2)
                CheckBoxBook.Checked = true;
            if ((Ref.Attributes & 4) == 4)
                CheckBoxManual.Checked = true;
            if ((Ref.Attributes & 8) == 8)
                CheckBoxLecture.Checked = true;
            if ((Ref.Attributes & 16) == 16)
                CheckBoxImp1.Checked = true;
            if ((Ref.Attributes & 32) == 32)
                CheckBoxImp2.Checked = true;
            if ((Ref.Attributes & 64) == 64)
                CheckBoxImp3.Checked = true;
            if ((Ref.Attributes & 128) == 128)
                CheckBoxImR.Checked = true;
            }
        private void frmRefAttributes_KeyDown (object sender, KeyEventArgs e)
            {
            if ((int) e.KeyCode == 27)
                {
                Menu_Cancel_Click (null, null);
                }
            }
        private void Menu_Save_Click (object sender, EventArgs e)
            {
            //show Attributes
            //1111-1111 {ImR.Imp3.Imp2.Imp1.Lect.Man.Book.Paper}
            Ref.Attributes = 0;
            if (CheckBoxPaper.Checked == true)
                Ref.Attributes = Ref.Attributes | 1;
            if (CheckBoxBook.Checked == true)
                Ref.Attributes = Ref.Attributes | 2;
            if (CheckBoxManual.Checked == true)
                Ref.Attributes = Ref.Attributes | 4;
            if (CheckBoxLecture.Checked == true)
                Ref.Attributes = Ref.Attributes | 8;
            if (CheckBoxImp1.Checked == true)
                Ref.Attributes = Ref.Attributes | 16;
            if (CheckBoxImp2.Checked == true)
                Ref.Attributes = Ref.Attributes | 32;
            if (CheckBoxImp3.Checked == true)
                Ref.Attributes = Ref.Attributes | 64;
            if (CheckBoxImR.Checked == true)
                Ref.Attributes = Ref.Attributes | 128;
            Client.DialogRequestParams = 16;
            Dispose ();
            }
        private void lblSave_Click (object sender, EventArgs e)
            {
            Menu_Save_Click (null, null);
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 0;
            Dispose ();
            }
        private void lblBack_Click (object sender, EventArgs e)
            {
            Dispose ();
            }
        }
    }