using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmTimeAndDate : Form
        {
        public frmTimeAndDate ()
            {
            InitializeComponent ();
            }
        private void frmTimeAndDate_Load (object sender, EventArgs e)
            {
            try
                {
                //calendar rtl?
                int intYear = Convert.ToInt32 (DateTime.Now.ToString ("yyyy").ToString ());
                if (intYear < 1450)
                    {
                    MC.RightToLeft = RightToLeft.Yes;
                    MC.RightToLeftLayout = true;
                    }
                else
                    {
                    MC.RightToLeft = RightToLeft.No;
                    MC.RightToLeftLayout = false;
                    }
                //reset flag
                Client.DialogRequestParams = 0;
                try
                    {
                    MC.SetDate (Conversions.ToDate (Strings.Mid (Note.DateTime, 1, 4) + "/" + Strings.Mid (Note.DateTime, 6, 2) + "/" + Strings.Mid (Note.DateTime, 9, 2)));
                    }
                catch (Exception ex)
                    {
                    //MessageBox.Show (ex.ToString ());
                    //MC.SetDate (Conversions.ToDate (Strings.Mid (Note.DateTime, 1, 4) + "/" + Strings.Mid (Note.DateTime, 6, 2) + "/01"));
                    MC.SetDate (DateTime.Now);
                    Note.DateTime = DateTime.Now.ToString ("yyyy-MM-dd . 08-30");
                    }
                txtDateTime.Text = Note.DateTime;
                MC.Focus ();
                txtDateTime.SelectionStart = 13;
                txtDateTime.SelectionLength = 5;
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void MC_DateSelected (object sender, DateRangeEventArgs e)
            {
            string strTimex = Strings.Mid (txtDateTime.Text, 14, 5);
            txtDateTime.Text = MC.SelectionStart.Date.ToString ("yyyy-MM-dd " + strTimex);
            txtDateTime.Focus ();
            txtDateTime.SelectionStart = 13;
            txtDateTime.SelectionLength = 5;
            }
        //MENU and EXIT
        private void lblSelect_Click (object sender, EventArgs e)
            {
            Menu_OK (null, null);
            }
        private void lblCancel_Click (object sender, EventArgs e)
            {
            Menu_Cancel (null, null);
            }
        private void Menu_OK (object sender, EventArgs e)
            {
            //check mask is completed
            if (txtDateTime.MaskCompleted == false)
                return;
            //retval:
            if (txtDateTime.Text == Note.DateTime)
                {
                Client.DialogRequestParams = 0;
                }
            else
                {
                Client.DialogRequestParams = 16;
                Note.DateTime = txtDateTime.Text;
                }
            Dispose ();
            }
        private void Menu_Cancel (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 0;
            Dispose ();
            }
        private void frmTimeAndDate_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Escape)
                {
                Client.DialogRequestParams = 0;
                Dispose ();
                }
            }
        private void txtDateTime_KeyDown (object sender, KeyEventArgs e)
            {
            try
                {
                switch (e.KeyCode)
                    {
                    case Keys.Enter:
                            {
                            Menu_OK (null, null);
                            break;
                            }
                    case Keys.Escape:
                            {
                            Menu_Cancel (null, null);
                            break;
                            }
                    case Keys.Up:
                            {
                            int intYr = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 1, 4)); // ____-__-__ . __-__
                            int intMt = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 6, 2));
                            int intDy = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 9, 2));
                            int intHr = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 14, 2));
                            int intMn = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 17, 2));
                            if (txtDateTime.SelectionStart <= 4) // 1234-__-__ . __-__
                                {
                                if (intYr >= 1450)
                                    {
                                    txtDateTime.SelectionStart = 0;
                                    txtDateTime.SelectionLength = 4;
                                    e.SuppressKeyPress = true;
                                    return;
                                    }
                                else
                                    {
                                    intYr += 1;
                                    txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                    txtDateTime.SelectionStart = 0;
                                    txtDateTime.SelectionLength = 4;
                                    }
                                }
                            else if ((txtDateTime.SelectionStart >= 5) && (txtDateTime.SelectionStart <= 7)) // ____-67-__ . __-__
                                {
                                if (intMt >= 12)
                                    {
                                    txtDateTime.SelectionStart = 5;
                                    txtDateTime.SelectionLength = 2;
                                    e.SuppressKeyPress = true;
                                    return;
                                    }
                                intMt += 1;
                                txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                txtDateTime.SelectionStart = 5;
                                txtDateTime.SelectionLength = 2;
                                }
                            else if ((txtDateTime.SelectionStart >= 8) && (txtDateTime.SelectionStart <= 10)) // ____-__-90 . __-__
                                {
                                if (intDy >= 30)
                                    {
                                    txtDateTime.SelectionStart = 8;
                                    txtDateTime.SelectionLength = 2;
                                    e.SuppressKeyPress = true;
                                    return;
                                    }
                                intDy += 1;
                                txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                txtDateTime.SelectionStart = 8;
                                txtDateTime.SelectionLength = 2;
                                }
                            else if ((txtDateTime.SelectionStart >= 13) && (txtDateTime.SelectionStart <= 15)) // ____-__-__ . 45-__
                                {
                                if (intHr >= 23)
                                    {
                                    txtDateTime.SelectionStart = 13;
                                    txtDateTime.SelectionLength = 2;
                                    e.SuppressKeyPress = true;
                                    return;
                                    }
                                intHr += 1;
                                txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                txtDateTime.SelectionStart = 13;
                                txtDateTime.SelectionLength = 2;
                                }
                            else if (txtDateTime.SelectionStart >= 16) // ____-__-__ . __-67
                                {
                                if (intMn >= 59)
                                    {
                                    txtDateTime.SelectionStart = 16;
                                    txtDateTime.SelectionLength = 2;
                                    e.SuppressKeyPress = true;
                                    return;
                                    }
                                intMn += 1;
                                txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                txtDateTime.SelectionStart = 16;
                                txtDateTime.SelectionLength = 2;
                                }
                            e.SuppressKeyPress = true;
                            break;
                            }
                    case Keys.Down:
                            {
                            int intYr = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 1, 4)); // ____-__-__ . __-__
                            int intMt = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 6, 2));
                            int intDy = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 9, 2));
                            int intHr = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 14, 2));
                            int intMn = Convert.ToInt32 (Strings.Mid (txtDateTime.Text, 17, 2));
                            if (txtDateTime.SelectionStart <= 4) // 1234-__-__ . __-__
                                {
                                if (intYr <= 1354)
                                    {
                                    txtDateTime.SelectionStart = 0;
                                    txtDateTime.SelectionLength = 4;
                                    e.SuppressKeyPress = true;
                                    return;
                                    }
                                intYr -= 1;
                                txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                txtDateTime.SelectionStart = 0;
                                txtDateTime.SelectionLength = 4;
                                }
                            else if ((txtDateTime.SelectionStart >= 5) && (txtDateTime.SelectionStart <= 7)) // ____-67-__ . __-__
                                {
                                if (intMt <= 1)
                                    {
                                    txtDateTime.SelectionStart = 5;
                                    txtDateTime.SelectionLength = 2;
                                    e.SuppressKeyPress = true;
                                    return;
                                    }
                                intMt -= 1;
                                txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                txtDateTime.SelectionStart = 5;
                                txtDateTime.SelectionLength = 2;
                                }
                            else if ((txtDateTime.SelectionStart >= 8) && (txtDateTime.SelectionStart <= 10)) // ____-__-90 . __-__
                                {
                                if (intDy <= 1)
                                    {
                                    txtDateTime.SelectionStart = 8;
                                    txtDateTime.SelectionLength = 2;
                                    e.SuppressKeyPress = true;
                                    return;
                                    }
                                intDy -= 1;
                                txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                txtDateTime.SelectionStart = 8;
                                txtDateTime.SelectionLength = 2;
                                }
                            else if ((txtDateTime.SelectionStart >= 13) && (txtDateTime.SelectionStart <= 15)) // ____-__-__ . 45-__
                                {
                                intHr -= 1;
                                txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                txtDateTime.SelectionStart = 13;
                                txtDateTime.SelectionLength = 2;
                                }
                            else if (txtDateTime.SelectionStart >= 16) // ____-__-__ . __-67
                                {
                                intMn -= 1;
                                txtDateTime.Text = intYr.ToString ("0000").Trim () + "-" + intMt.ToString ("00").Trim () + "-" + intDy.ToString ("00").Trim () + " . " + intHr.ToString ("00").Trim () + "-" + intMn.ToString ("00").Trim ();
                                txtDateTime.SelectionStart = 16;
                                txtDateTime.SelectionLength = 2;
                                }
                            e.SuppressKeyPress = true;
                            break;
                            }
                    }
                }
            catch { }
            }
        }
    }
