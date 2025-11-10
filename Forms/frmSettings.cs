using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmSettings
        {
        public frmSettings ()
            {
            InitializeComponent ();
            }
        private void Settings_Load (object sender, EventArgs e)
            {
            Db.ReadSettingsAndUsers ();
            GridSettings.DataSource = Db.DS.Tables ["tblSettings"];
            GridSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            GridSettings.Columns [0].Visible = false;    // ID
            GridSettings.Columns [1].Visible = false;    // Header
            GridSettings.Columns [2].Width = 160;        // Key
            GridSettings.Columns [3].Width = 180;        // Value
            GridSettings.Columns [4].Width = 250;        // Note
            for (int k = 0, loopTo = GridSettings.Columns.Count - 1; k <= loopTo; k++)
                GridSettings.Columns [k].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        private void GridSettings_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            // 0  AdminPass         '1  CurrentVersion    
            // 2  Interface         '3  Owner
            // 4  QRCodeType        '5  SearchRefType
            if (GridSettings.RowCount < 1)
                return;
            int r = e.RowIndex; // count from 0
            int c = e.ColumnIndex; // count from 0
            if (r < 0 | c < 0)
                return;
            if (c != 3)
                return;
            string Keyx = Conversions.ToString (Db.DS.Tables ["tblsettings"].Rows [r] [2]);
            string valx = Conversions.ToString (Db.DS.Tables ["tblsettings"].Rows [r] [3]);
            switch (r)
                {
                case 2: // ToggleY/N
                        {
                        if (Db.DS.Tables ["tblSettings"].Rows [r] [3].ToString () == "1")
                            Db.DS.Tables ["tblSettings"].Rows [r] [3] = "2";
                        else
                            Db.DS.Tables ["tblSettings"].Rows [r] [3] = "1"; // using INPUTBOX
                        break;
                        }

                default:
                        {
                        valx = Interaction.InputBox ("Enter new Value for   " + Keyx, "Settings", valx);
                        Db.DS.Tables ["tblSettings"].Rows [r] [3] = valx;
                        break;
                        }
                }
            SaveSettings ();
            }
        private void SaveSettings ()
            {
            for (int r = 0, loopTo = GridSettings.Rows.Count - 1; r <= loopTo; r++)
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "UPDATE Settings SET sttValue= @sttvalue WHERE ID = @ID";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@sttvalue", Db.DS.Tables ["tblsettings"].Rows [r] [3]);
                    cmd.Parameters.AddWithValue ("@ID", Db.DS.Tables ["tblSettings"].Rows [r] [0].ToString ());
                    int i = cmd.ExecuteNonQuery ();
                    CnnSS.Close ();
                    }
                }
            }
        private void Settings_FormClosing (object sender, FormClosingEventArgs e)
            {
            if (e.CloseReason == CloseReason.UserClosing)
                {
                e.Cancel = true;
                }
            }
        private void Menu_ExitSetup_Click (object sender, EventArgs e)
            {
            SaveSettings ();
            Db.ReadSettingsAndUsers (); // to refresh tblSettings
            Dispose ();
            }
        private void lblSaveExit_Click (object sender, EventArgs e)
            {
            SaveSettings ();
            Db.ReadSettingsAndUsers (); // to refresh tblSettings
            Dispose ();
            }
        }
    }