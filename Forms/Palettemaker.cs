using ClosedXML.Excel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace eLib
    {
    public partial class palettemaker
        {
        public palettemaker ()
            {
            InitializeComponent ();
            }
        private void palettemaker_Load (object sender, EventArgs e)
            {
            Width = 480;
            Height = 620;
            //format columns
            GridPalette.Columns [0].Width = 60;   //0ID
            GridPalette.Columns [1].Width = 60;   //1Red
            GridPalette.Columns [2].Width = 60;   //2Green
            GridPalette.Columns [3].Width = 60;   //3Blue
            GridPalette.Columns [4].Width = 200;  //4COLOR
            //format columns...
            for (int i = 0; i < GridPalette.Columns.Count; i++)
                {
                GridPalette.Columns [i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            //default palette
            CreateRandomPalette ();
            }
        //btns
        private void Menu_NewRandomPalette_Click (object sender, EventArgs e)
            {
            CreateRandomPalette ();
            }
        private void Menu_Open_Click (object sender, EventArgs e)
            {
            //load
            string Filename = "";
            string ID = "";
            string strR = "";
            string strG = "";
            string strB = "";
            using (var dialog = new OpenFileDialog () { InitialDirectory = System.Windows.Forms.Application.StartupPath, Filter = "AugustusMate Palette|*.xlsx" })
                {
                if (dialog.ShowDialog () == DialogResult.OK)
                    {
                    Filename = dialog.FileName;
                    }
                else
                    {
                    return;
                    }
                }
            try
                {
                GridPalette.Rows.Clear ();
                using (IXLWorkbook WB = new XLWorkbook (Filename))
                    {
                    var WS = WB.Worksheets.ElementAtOrDefault (0);
                    int iRow = 0;
                    foreach (IXLRow Rowx in WS.Rows ())
                        {
                        iRow = iRow + 1;
                        ID = WS.Cell (iRow, 1).Value.ToString ();
                        strR = WS.Cell (iRow, 2).Value.ToString ();
                        strG = WS.Cell (iRow, 3).Value.ToString ();
                        strB = WS.Cell (iRow, 4).Value.ToString ();
                        GridPalette.Rows.Add (ID, strR, strG, strB);
                        }
                    }
                PaintGrid ();
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Importing Palette \r\n" + ex.ToString ());
                }
            }
        private void Menu_SaveAs_Click (object sender, EventArgs e)
            {
            //saveas
            try
                {
                using var WB = new XLWorkbook ();
                    {
                    var WS0 = WB.AddWorksheet ("Palette");
                    for (int i = 0; i < 20; i++)
                        {
                        WS0.Cell (i + 1, 1).Value = GridPalette.Rows [i].Cells [0].Value.ToString ();
                        WS0.Cell (i + 1, 2).Value = GridPalette.Rows [i].Cells [1].Value.ToString ();
                        WS0.Cell (i + 1, 3).Value = GridPalette.Rows [i].Cells [2].Value.ToString ();
                        WS0.Cell (i + 1, 4).Value = GridPalette.Rows [i].Cells [3].Value.ToString ();
                        }
                    }
                string Filename = "";
                using (var dialog = new SaveFileDialog () { InitialDirectory = System.Windows.Forms.Application.StartupPath, Filter = "AugustusMate Palette|*.xlsx" })
                    {
                    if (dialog.ShowDialog () == DialogResult.OK)
                        {
                        Filename = dialog.FileName;
                        }
                    else
                        {
                        return;
                        }
                    }
                WB.SaveAs (Filename);
                MessageBox.Show ("Palette Saved", "augustusmate");
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error in Saving the Palette \r\n" + ex.ToString ());
                }
            }
        private void Menu_OkUsePalette_Click (object sender, EventArgs e)
            {
            Db.DS.Tables ["tblPalette"].Clear ();
            for (int i = 0; i < 20; i++)
                {
                Palette.ID = Convert.ToInt32 (GridPalette.Rows [i].Cells [0].Value);
                Palette.Rcolor = Convert.ToInt32 (GridPalette.Rows [i].Cells [1].Value);
                Palette.Gcolor = Convert.ToInt32 (GridPalette.Rows [i].Cells [2].Value);
                Palette.Bcolor = Convert.ToInt32 (GridPalette.Rows [i].Cells [3].Value);
                Db.DS.Tables ["tblPalette"].Rows.Add (Palette.ID, Palette.Rcolor, Palette.Gcolor, Palette.Bcolor);
                }
            Dispose ();
            }
        //grid
        private void GridPalette_CellClick (object sender, DataGridViewCellEventArgs e)
            {
            if (e.ColumnIndex == 4)
                {
                GridPalette.CurrentCell = GridPalette.Rows [GridPalette.CurrentCell.RowIndex].Cells [0];
                }
            GaugeR.Value = Convert.ToInt32 (GridPalette.Rows [GridPalette.SelectedCells [0].RowIndex].Cells [1].Value);
            GaugeG.Value = Convert.ToInt32 (GridPalette.Rows [GridPalette.SelectedCells [0].RowIndex].Cells [2].Value);
            GaugeB.Value = Convert.ToInt32 (GridPalette.Rows [GridPalette.SelectedCells [0].RowIndex].Cells [3].Value);
            GaugeR.Focus ();
            }
        //gauges
        private void GaugeR_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Down)
                GaugeG.Focus ();
            else if (e.KeyCode == Keys.Up)
                GaugeB.Focus ();
            }
        private void GaugeG_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Down)
                GaugeB.Focus ();
            else if (e.KeyCode == Keys.Up)
                GaugeR.Focus ();
            }
        private void GaugeB_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Down)
                GaugeR.Focus ();
            else if (e.KeyCode == Keys.Up)
                GaugeG.Focus ();
            }
        private void GaugeR_Scroll (object sender, EventArgs e)
            {
            try
                {
                int r = GridPalette.SelectedCells [0].RowIndex;
                if (r != -1)
                    GridPalette.Rows [GridPalette.SelectedCells [0].RowIndex].Cells [1].Value = GaugeR.Value.ToString ();
                PaintCell (r, GaugeR.Value, GaugeG.Value, GaugeB.Value);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void GaugeG_Scroll (object sender, EventArgs e)
            {
            try
                {
                int r = GridPalette.SelectedCells [0].RowIndex;
                if (r != -1)
                    GridPalette.Rows [GridPalette.SelectedCells [0].RowIndex].Cells [2].Value = GaugeG.Value.ToString ();
                PaintCell (r, GaugeR.Value, GaugeG.Value, GaugeB.Value);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        private void GaugeB_Scroll (object sender, EventArgs e)
            {
            try
                {
                int r = GridPalette.SelectedCells [0].RowIndex;
                if (r != -1)
                    GridPalette.Rows [GridPalette.SelectedCells [0].RowIndex].Cells [3].Value = GaugeB.Value.ToString ();
                PaintCell (r, GaugeR.Value, GaugeG.Value, GaugeB.Value);
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ());
                }
            }
        //methods
        private void LoadDefault ()
            {
            GridPalette.Rows.Clear ();
            GridPalette.Rows.Add ("1", "255", "255", "255");
            GridPalette.Rows.Add ("2", "000", "000", "000");
            GridPalette.Rows.Add ("3", "255", "000", "000");
            GridPalette.Rows.Add ("4", "000", "255", "000");
            GridPalette.Rows.Add ("5", "000", "000", "255");
            GridPalette.Rows.Add ("6", "255", "255", "255");
            GridPalette.Rows.Add ("7", "255", "255", "255");
            GridPalette.Rows.Add ("8", "255", "255", "255");
            GridPalette.Rows.Add ("9", "255", "255", "255");
            GridPalette.Rows.Add ("10", "255", "255", "255");
            GridPalette.Rows.Add ("11", "255", "255", "255");
            GridPalette.Rows.Add ("12", "255", "255", "255");
            GridPalette.Rows.Add ("13", "255", "255", "255");
            GridPalette.Rows.Add ("14", "255", "255", "255");
            GridPalette.Rows.Add ("15", "255", "255", "255");
            GridPalette.Rows.Add ("16", "255", "255", "255");
            GridPalette.Rows.Add ("17", "255", "255", "255");
            GridPalette.Rows.Add ("18", "255", "255", "255");
            GridPalette.Rows.Add ("19", "255", "255", "255");
            GridPalette.Rows.Add ("20", "255", "255", "255");
            PaintGrid ();
            }
        private void CreateRandomPalette ()
            {
            Random rnd = new Random ();
            GridPalette.Rows.Clear ();
            for (int i = 0; i < 20; i++)
                {
                GridPalette.Rows.Add ((i + 1).ToString (), rnd.Next (255), rnd.Next (255), rnd.Next (255));
                }
            PaintGrid ();
            }
        private void PaintGrid ()
            {
            for (int i = 0; i < GridPalette.Rows.Count; i++)
                {
                Palette.Rcolor = Convert.ToInt32 (GridPalette.Rows [i].Cells [1].Value);
                Palette.Gcolor = Convert.ToInt32 (GridPalette.Rows [i].Cells [2].Value);
                Palette.Bcolor = Convert.ToInt32 (GridPalette.Rows [i].Cells [3].Value);
                if (Palette.Rcolor > 255)
                    Palette.Rcolor = 255;
                if (Palette.Gcolor > 255)
                    Palette.Gcolor = 255;
                if (Palette.Bcolor > 255)
                    Palette.Bcolor = 255;
                GridPalette.Rows [i].Cells [4].Style.BackColor = System.Drawing.Color.FromArgb (Palette.Rcolor, Palette.Gcolor, Palette.Bcolor);
                }
            }
        private void PaintCell (int thisRow, int R, int G, int B)
            {
            if (R > 255)
                R = 255;
            if (G > 255)
                G = 255;
            if (B > 255)
                B = 255;
            GridPalette.Rows [thisRow].Cells [4].Style.BackColor = System.Drawing.Color.FromArgb (R, G, B);
            }
        private void label2_Click (object sender, EventArgs e)
            {
            Menu_SaveAs_Click (null, null);
            }
        private void label1_Click (object sender, EventArgs e)
            {
            Menu_OkUsePalette_Click (null, null);
            }
        }
    }
