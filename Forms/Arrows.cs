using ClosedXML.Excel;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace eLib
    {
    public partial class Arrows : Form
        {
        public Arrows ()
            {
            InitializeComponent ();
            }
        private void Arrows_Load (object sender, EventArgs e)
            {
            Width = 1245;
            Height = 550;
            if ((Client.DialogRequestParams & 8) == 8)
                {
                //BIT4(=8): 0:new, 1:Edit
                ReadProjectData ();
                Menu_SelectAll_Click (null, null);
                }
            else
                {
                //ReadExcel ();
                }
            }
        public void ReadProjectData ()
            {
            //tblArrows: Species Cluster Gene Spacer Size Dir Description Dye Sel
            Db.DS.Tables["tblArrows"].Clear ();
            Db.strSQL = "SELECT Species.SciName AS Species, Clusters.ClusterName AS Cluster, Transcripts.TranscriptName AS Gene, Transcripts.SpacerLength AS Spacer, Transcripts.GeneSize AS Size, Transcripts.Direction AS Dir, Transcripts.Description FROM Species INNER JOIN Clusters ON (Clusters.Species_ID = Species.ID) INNER JOIN Transcripts ON (Transcripts.Cluster_ID = Clusters.ID) WHERE Transcripts.Sel = 1 AND Species.Project_ID = " + Project.Id.ToString ();
            //, Transcripts.Sel
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblArrows");
                CnnSS.Close ();
                }
            //grid data source
            FeedGrid ();
            for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                Grid1.Rows[i].Cells[7].Value = "1";
                }
            }
        private void Menu_ReadExcelData_Click (object sender, EventArgs e)
            {
            ReadExcel ();
            }
        public void ReadExcel ()
            {
            string Filename = "";
            string Species = "";
            string Cluster = "";
            string Gene = "";
            int Spacer = 0;
            int Size = 0;
            string Dir = "";
            string Description = "";
            string Dye = "";
            string Sel = "";
            using (var dialog = new OpenFileDialog () { InitialDirectory = System.Windows.Forms.Application.StartupPath, Filter = "Augustus Arrows Data|*.xlsx" })
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
                Db.DS.Tables["tblArrows"].Clear ();
                using (IXLWorkbook WB = new XLWorkbook (Filename))
                    {
                    var WS0 = WB.Worksheets.ElementAtOrDefault (0);
                    int iRow = 0;
                    foreach (IXLRow Rowx in WS0.Rows ())
                        {
                        iRow = iRow + 1;
                        if (iRow > 1)
                            {
                            Species = WS0.Cell (iRow, 1).Value.ToString ();
                            Cluster = WS0.Cell (iRow, 2).Value.ToString ();
                            Gene = WS0.Cell (iRow, 3).Value.ToString ();
                            Spacer = Convert.ToInt32 (WS0.Cell (iRow, 4).Value.ToString ());
                            Size = Convert.ToInt32 (WS0.Cell (iRow, 5).Value.ToString ());
                            Dir = WS0.Cell (iRow, 6).Value.ToString ();
                            Description = WS0.Cell (iRow, 7).Value.ToString ();
                            Dye = WS0.Cell (iRow, 8).Value.ToString ();
                            Sel = "+";
                            Db.DS.Tables["tblArrows"].Rows.Add (Species, Cluster, Gene, Spacer, Size, Dir, Description, Dye, Sel);
                            }
                        }
                    }
                }
            catch (Exception ex)
                {
                //MessageBox.Show ("Error in Importing Arrow Data \r\n" + ex.ToString ());
                }
            //grid data source
            FeedGrid ();
            }
        public void FeedGrid ()
            {
            Grid1.DataSource = null;
            Grid1.DataSource = Db.DS.Tables["tblArrows"];
            //grid format w=1034
            Grid1.Columns[0].Width = 150; //0Species
            Grid1.Columns[1].Width = 150; //1Cluster
            Grid1.Columns[2].Width = 80;  //2Gene
            Grid1.Columns[3].Width = 60;  //3Spacer
            Grid1.Columns[4].Width = 60;  //4Size
            Grid1.Columns[5].Width = 40;  //5Dir
            Grid1.Columns[6].Width = 400; //6Description
            Grid1.Columns[7].Width = 30;  //7Dye
            Grid1.Columns[8].Width = 30;  //8Sel
            for (int i = 0; i < Grid1.Columns.Count; i++)
                {
                Grid1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        private void Menu_SelectAll_Click (object sender, EventArgs e)
            {
            for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                Grid1.Rows[i].Cells[8].Value = "+";
                }
            }
        private void Menu_InvertSelection_Click (object sender, EventArgs e)
            {
            for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                if (Grid1.Rows[i].Cells[8].Value.ToString () == "+")
                    {
                    Grid1.Rows[i].Cells[8].Value = "";
                    }
                else
                    {
                    Grid1.Rows[i].Cells[8].Value = "+";
                    }
                }
            }
        private void Menu_RandomColors_Click (object sender, EventArgs e)
            {
            Random color = new Random ();
            for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                int clrx = color.Next (20) + 1;
                Grid1.Rows[i].Cells[7].Value = clrx.ToString ();
                }
            }
        private void Grid1_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
            {
            if (Grid1.Rows.Count == 0)
                return;
            int c = e.ColumnIndex;
            int r = e.RowIndex;
            if (c == 8)
                {
                if (Grid1.Rows[r].Cells[c].Value.ToString () == "+")
                    {
                    Grid1.Rows[r].Cells[c].Value = "";
                    }
                else
                    {
                    Grid1.Rows[r].Cells[c].Value = "+";
                    }
                }
            }
        private void Menu_ColorPalette_Click (object sender, EventArgs e)
            {
            var frmPalette = new palettemaker ();
            frmPalette.ShowDialog ();
            }
        private void Menu_Draw_Click (object sender, EventArgs e)
            {
            if (Grid1.Rows.Count == 0)
                {
                return;
                }
            //check colors column
            for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                if (Grid1.Rows[i].Cells[7].Value.ToString () == "")
                    {
                    Grid1.Rows[i].Cells[8].Value = "1";//###8?
                    }
                }
            //0Species 1Cluster 2Gene 3Spacer 4Size 5Dir 6Description 7Dye 8Sel
            int slideWidth = Convert.ToInt32 (txtSlideWidth.Text);
            int slideHeight = Convert.ToInt32 (txtSlideHeight.Text);
            int arrowHeight = Convert.ToInt32 (txtArrowHeight.Text);
            int geneMagnPercent = Convert.ToInt32 (lblGeneMagn.Text);
            int spacerMagnPercent = Convert.ToInt32 (lblSpacerMagn.Text);
            int geneScalebar = Convert.ToInt32 (txtGeneScalebar.Text);
            int spacerScalebar = Convert.ToInt32 (txtSpacerScalebar.Text);
            var pptApp = new Microsoft.Office.Interop.PowerPoint.Application ();
            int slideNumber = 0;
            int intPointer = 0;
            int arrowLength = 0;
            int spacerLength = 0;
            int shapeTotalLength = 0;
            string currentClusterName = "";
            int geneIdThisCluster = 0;
            string legendThisCluster = "";
            Microsoft.Office.Interop.PowerPoint.Slides slides;
            Microsoft.Office.Interop.PowerPoint.TextRange objText;
            //create the presentation file
            Presentation pptPres = pptApp.Presentations.Add (Microsoft.Office.Core.MsoTriState.msoTrue);
            Microsoft.Office.Interop.PowerPoint.CustomLayout customLayout = pptPres.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText];
            //slides Size
            pptPres.PageSetup.SlideWidth = slideWidth;
            pptPres.PageSetup.SlideHeight = slideHeight;
            //slides and slide
            slides = pptPres.Slides;
            Microsoft.Office.Interop.PowerPoint._Slide slide = slides.AddSlide (1, customLayout);
            //start drawing
            for (int i = 0; i < Grid1.Rows.Count; i++)
                {
                if (Grid1.Rows[i].Cells[8].Value.ToString ().Trim () == "+") //check if row is selected by '+' tag
                    {
                    //new slide|first slide
                    if ((Grid1.Rows[i].Cells[0].Value.ToString () + Grid1.Rows[i].Cells[1].Value.ToString ()) != currentClusterName)
                        {
                        //new cluster | first cluster
                        if (currentClusterName != "")
                            {
                            //new cluster (not the first cluster)
                            //before adding new slide: write legend of the genes (1-n) for the previous cluster (see also similar code at the end of for loop)
                            var legendText4Cluster = slide.Shapes.AddTextbox (MsoTextOrientation.msoTextOrientationHorizontal, Left: 10, Top: arrowHeight + 200, Width: (Convert.ToInt32 (slideWidth * 0.8)), Height: 500);
                            legendText4Cluster.TextFrame.TextRange.Text = legendThisCluster.ToString ();
                            legendText4Cluster.TextEffect.FontName = "Tahoma";//Tahoma, Palatino, Courier New, 
                            legendText4Cluster.TextEffect.FontSize = 28;
                            }
                        //add a new slide (for the new|first cluster)
                        currentClusterName = (Grid1.Rows[i].Cells[0].Value.ToString () + Grid1.Rows[i].Cells[1].Value.ToString ());
                        slideNumber += 1;
                        slide = slides.AddSlide (slideNumber, customLayout);
                        slide.Shapes[2].Delete (); //remove auto place holders on the new slide
                        slide.Shapes[1].Delete (); //remove auto place holders on the new slide
                        intPointer = 5; //add padding at left
                        shapeTotalLength = 0;
                        geneIdThisCluster = 0;
                        legendThisCluster = "LEGEND: ";
                        //add horizontal line
                        slide.Shapes.AddShape (MsoAutoShapeType.msoShapeLineInverse, 0, (90 + arrowHeight / 2), slideWidth - 100, 0);
                        //add scale-bar for genes
                        slide.Shapes.AddShape (MsoAutoShapeType.msoShapeLineInverse, (Convert.ToInt32 (slideWidth * 0.82)), arrowHeight + 200, geneScalebar * geneMagnPercent / 100, 0);
                        var shp_ScalebarGene = slide.Shapes.AddTextbox (MsoTextOrientation.msoTextOrientationHorizontal, Left: (Convert.ToInt32 (slideWidth * 0.82)), Top: arrowHeight + 205, Width: 300, Height: 100);
                        shp_ScalebarGene.TextFrame.TextRange.Text = "Scale Bar (genes, bp): " + geneScalebar.ToString ();
                        shp_ScalebarGene.TextEffect.FontName = "Arial";
                        shp_ScalebarGene.TextEffect.FontSize = 20;
                        //add scale-bar for spacers
                        slide.Shapes.AddShape (MsoAutoShapeType.msoShapeLineInverse, (Convert.ToInt32 (slideWidth * 0.82)), arrowHeight + 300, spacerScalebar * spacerMagnPercent / 100, 0);
                        var shp_ScalebarSpacer = slide.Shapes.AddTextbox (MsoTextOrientation.msoTextOrientationHorizontal, Left: (Convert.ToInt32 (slideWidth * 0.82)), Top: arrowHeight + 305, Width: 300, Height: 100);
                        shp_ScalebarSpacer.TextFrame.TextRange.Text = "Scale Bar (spacers, bp): " + spacerScalebar.ToString ();
                        shp_ScalebarSpacer.TextEffect.FontName = "Arial";
                        shp_ScalebarSpacer.TextEffect.FontSize = 20;
                        //add slide title
                        var shp_title = slide.Shapes.AddTextbox (MsoTextOrientation.msoTextOrientationHorizontal, Left: 30, Top: 5, Width: 2000, Height: 120);
                        shp_title.TextFrame.TextRange.Text = "Cluster:    " + Grid1.Rows[i].Cells[0].Value.ToString () + "  /  " + Grid1.Rows[i].Cells[1].Value.ToString ();
                        shp_title.TextEffect.FontName = "Arial";
                        shp_title.TextEffect.FontSize = 32;
                        }
                    //add one arrow on current slide
                    spacerLength = Convert.ToInt32 (Grid1.Rows[i].Cells[3].Value);
                    arrowLength = Convert.ToInt32 (Grid1.Rows[i].Cells[4].Value);
                    GetColor (Convert.ToInt32 (Grid1.Rows[i].Cells[7].Value));
                    switch (Grid1.Rows[i].Cells[5].Value.ToString ())
                        {
                        case "P":
                                {
                                intPointer += (spacerLength * spacerMagnPercent / 100);
                                geneIdThisCluster += 1;
                                var s = slide.Shapes.AddShape (MsoAutoShapeType.msoShapeRightArrow, intPointer, 90, arrowLength * geneMagnPercent / 100, arrowHeight);
                                s.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb (Palette.Bcolor, Palette.Gcolor, Palette.Rcolor).ToArgb ();
                                var legend = slide.Shapes.AddTextbox (MsoTextOrientation.msoTextOrientationHorizontal, Left: intPointer, Top: arrowHeight + 120, Width: 70, Height: 50);
                                legend.TextFrame.TextRange.Text = "t." + geneIdThisCluster.ToString ();
                                legend.TextEffect.FontName = "Tahoma";//Tahoma, Palatino, Courier New, 
                                legend.TextEffect.FontSize = 28;
                                legendThisCluster += "t." + geneIdThisCluster.ToString () + ": (" + Grid1.Rows[i].Cells[2].Value.ToString ().Trim () + ") " + Grid1.Rows[i].Cells[6].Value.ToString ().Trim () + ";  ";
                                break;
                                }
                        case "N":
                                {
                                intPointer += (spacerLength * spacerMagnPercent / 100);
                                geneIdThisCluster += 1;
                                var s = slide.Shapes.AddShape (MsoAutoShapeType.msoShapeLeftArrow, intPointer, 90, arrowLength * geneMagnPercent / 100, arrowHeight);
                                s.Fill.ForeColor.RGB = System.Drawing.Color.FromArgb (Palette.Bcolor, Palette.Gcolor, Palette.Rcolor).ToArgb ();
                                var legend = slide.Shapes.AddTextbox (MsoTextOrientation.msoTextOrientationHorizontal, Left: intPointer, Top: arrowHeight + 120, Width: 70, Height: 50);
                                legend.TextFrame.TextRange.Text = "t." + geneIdThisCluster.ToString ();
                                legend.TextEffect.FontName = "Tahoma";
                                legend.TextEffect.FontSize = 28;
                                legendThisCluster += "t." + geneIdThisCluster.ToString () + ": (" + Grid1.Rows[i].Cells[2].Value.ToString ().Trim () + ") " + Grid1.Rows[i].Cells[6].Value.ToString ().Trim () + ";  ";
                                break;
                                }
                        }
                    //notice: interop reads colors as BGR (not RGB!)
                    intPointer += (arrowLength * geneMagnPercent / 100); // + (spacerLength * spacerMagnPercent / 100);
                    shapeTotalLength += (arrowLength * geneMagnPercent / 100) + (spacerLength * spacerMagnPercent / 100);
                    }
                } //end if for-loop
            //dont forget to write legend of the genes (1-n) for the very last cluster! (for loop will not do this!)
            if (currentClusterName != "")
                {
                var legendText4Cluster = slide.Shapes.AddTextbox (MsoTextOrientation.msoTextOrientationHorizontal, Left: 10, Top: arrowHeight + 200, Width: (Convert.ToInt32 (slideWidth * 0.8)), Height: 500);
                legendText4Cluster.TextFrame.TextRange.Text = legendThisCluster.ToString ();
                legendText4Cluster.TextEffect.FontName = "Tahoma";//Tahoma, Palatino, Courier New, 
                legendText4Cluster.TextEffect.FontSize = 28;
                }
            ////slide-2
            //slide = slides.AddSlide (2, customLayout);
            //objText = slide.Shapes [1].TextFrame.TextRange;
            //objText.Text = "This is slide.Shapes [1]";
            //objText.Font.Name = "Arial";
            //objText.Font.Size = 32;
            //objText = slide.Shapes [2].TextFrame.TextRange;
            //objText.Text = "slide.Shapes [2]";
            //objText = slide.Shapes [2].TextFrame.TextRange;
            //objText.Text = "now?";
            ////slide.Shapes [3].Fill.ForeColor.RGB = System.Drawing.Color.FromArgb (0, 0, 255).ToArgb ();
            ////note: here the color RGB is given in format of BGR because interop reads it as BGR and not RGB

            //save
            pptPres.SaveAs (@"d:\fppt.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
            // pptPres.Close();
            // pptApp.Quit();
            }
        private void GetColor (int ColorID)
            {
            ColorID--;
            Palette.Rcolor = (int) Db.DS.Tables["tblPalette"].Rows[ColorID][1];
            Palette.Gcolor = (int) Db.DS.Tables["tblPalette"].Rows[ColorID][2];
            Palette.Bcolor = (int) Db.DS.Tables["tblPalette"].Rows[ColorID][3];
            }
        private void trackBar1_Scroll (object sender, EventArgs e)
            {
            lblGeneMagn.Text = trackBar1.Value.ToString ();
            }
        private void trackBar2_Scroll (object sender, EventArgs e)
            {
            lblSpacerMagn.Text = trackBar2.Value.ToString ();
            }
        private void panel1_Click (object sender, EventArgs e)
            {
            DialogResult myansw = MessageBox.Show ("Exit Draw?", "eLib.Augustus.Draw", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (myansw == DialogResult.OK)
                {
                Dispose ();
                }
            }
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            //if (MessageBox.Show ("Exit agustusmate?", "augustusmate ver1", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            this.Dispose ();
            }

        private void label9_Click (object sender, EventArgs e)
            {
            this.Dispose ();
            }
        }
    }
