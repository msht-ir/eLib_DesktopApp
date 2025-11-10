using eLib.Forms;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace eLib
    {
    public partial class frmAugustusLib
        {
        public frmAugustusLib ()
            {
            InitializeComponent ();
            }
        private void frmAugustusLib_Load (object sender, EventArgs e)
            {
            Width = 1295;
            Height = 670;
            if (Project.Id < 1)
                {
                SelectProject ();
                return;
                ;
                }
            GetSpecies (Project.Id);
            }
        private void lblProjectID_Click (object sender, EventArgs e)
            {
            SelectProject ();
            }
        private void Menu_Project_Click (object sender, EventArgs e)
            {
            SelectProject ();
            }
        private void Menu_SelectProject_Click (object sender, EventArgs e)
            {
            SelectProject ();
            }
        private void SelectProject ()
            {
            Client.DialogRequestParams = 1; //bit1(2^0)=1:get Project; bit2(2^1)=2:get SubProject; bit1,2(1+2=3):get Project or SubProject
            My.MyProject.Forms.frmChooseProject.ShowDialog ();
            if (Client.DialogRequestParams == 64) //bit7:2^6:64: a Project is selected from dialog
                {
                lblProjectID.Text = "Project [" + Project.Id.ToString () + ": " + Project.Name + "]";
                GetSpecies (Project.Id);
                }
            else
                {
                Exit ();
                }
            }
        //list species
        private void lstSpecies_Click (object sender, EventArgs e)
            {
            if (lstSpecies.SelectedIndex != -1)
                {
                Species.Id = (int) lstSpecies.SelectedValue;
                GetClusters (Species.Id);
                }
            }
        private void lstSpecies_DoubleClick (object sender, EventArgs e)
            {
            EditSpecies ();
            }
        private void Menu_AddSpecies_Click (object sender, EventArgs e)
            {
            try
                {
                string strSpeciesName = Interaction.InputBox ("Enter Species Name:", "eLib", "Genus-species");
                if (!String.IsNullOrEmpty (strSpeciesName)) //save it
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        Db.strSQL = "INSERT INTO Species (SciName, Taxonomy, Project_ID) VALUES (@sciname, @taxonomy, @projectid); SELECT CAST (scope_identity() AS int)";
                        CnnSS.Open ();
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@sciname", strSpeciesName);
                        cmdx.Parameters.AddWithValue ("@taxonomy", "-");
                        cmdx.Parameters.AddWithValue ("@projectid", Project.Id.ToString ());
                        int SpId = (int) cmdx.ExecuteScalar ();
                        CnnSS.Close ();
                        }
                    GetSpecies (Project.Id);
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); // Do Nothing!
                }
            }
        private void Menu_EditSpecies_Click (object sender, EventArgs e)
            {
            EditSpecies ();
            }
        private void EditSpecies ()
            {
            if (lstSpecies.SelectedIndex != -1)
                {
                string tmpSpeciesName = lstSpecies.Text;
                int SpId = (int) lstSpecies.SelectedValue;
                try
                    {
                    string strSpeciesName = Interaction.InputBox ("Enter Species Name:", "eLib", tmpSpeciesName);
                    if (!String.IsNullOrEmpty (strSpeciesName)) //save it
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            CnnSS.Open ();
                            Db.strSQL = "UPDATE Species SET SciName = @sciname WHERE ID = @id";
                            var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                            cmdx.CommandType = CommandType.Text;
                            cmdx.Parameters.AddWithValue ("@sciname", strSpeciesName);
                            cmdx.Parameters.AddWithValue ("@id", SpId.ToString ());
                            int i = (int) cmdx.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        GetSpecies (Project.Id);
                        lstSpecies.SelectedValue = SpId;
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ()); //do nothing!
                    }
                }
            }
        private void Menu_Draw_Click (object sender, EventArgs e)
            {
            Client.DialogRequestParams = 8; //BIT4(=8): 0:new, 1:Edit
            Form frmDrawArrow = new Arrows ();
            frmDrawArrow.ShowDialog ();
            }
        private void Menu_DeleteSpecies_Click (object sender, EventArgs e)
            {
            if ((lstSpecies.SelectedIndex != -1) && (lstCluster.Items.Count == 0))
                {
                Species.Id = (int) lstSpecies.SelectedValue;
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        Db.strSQL = "DELETE FROM Species WHERE ID = @id";
                        var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx.CommandType = CommandType.Text;
                        cmdx.Parameters.AddWithValue ("@id", Species.Id.ToString ());
                        int i = (int) cmdx.ExecuteNonQuery ();
                        CnnSS.Close ();
                        }
                    GetSpecies (Project.Id);
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ()); //do nothing!
                    }
                }
            else
                {
                MessageBox.Show ("Select a Species and Delete its Clusters, then try  again", "eLib");
                }
            }
        //list clusters
        private void lstCluster_DragEnter (object sender, DragEventArgs e)
            {
            if (lstSpecies.SelectedIndex == -1)
                {
                return;
                }
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void lstCluster_DragDrop (object sender, DragEventArgs e)
            {
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            for (int i = 0; i < strFiles.Length; i++)
                {
                eLibFile.strFilex = strFiles [i];
                FileInfo MyFile = new FileInfo (strFiles [i]);
                if ((MyFile.Extension.ToLower () == ".txt") && (lstSpecies.SelectedIndex != -1))
                    {
                    Species.Id = (int) lstSpecies.SelectedValue;
                    //clear downstream lists
                    lstTranscript.DataSource = null;
                    txtSequenceData.Text = "";
                    string Linex = "";
                    Transcript.PereviousGeneEnd = 1;
                    //open the file
                    FileSystem.FileOpen (1, eLibFile.strFilex, OpenMode.Input);
                    Linex = FileSystem.LineInput (1);
                    if (Strings.Left (Linex, 41) == "# This output was generated with AUGUSTUS")
                        {
                        Transcript.PereviousGeneEnd = 1;
                        Transcript.TranscriptFrom = 0;
                        Transcript.TranscriptTo = 0;
                        Cluster.Name = MyFile.Name;
                        //SQL: add cluster to table (cluster name = filename)
                        try
                            {
                            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                                {
                                CnnSS.Open ();
                                Db.strSQL = @"INSERT INTO Clusters (ClusterName, Species_ID) VALUES (@clustername, @speciesid); SELECT CAST (scope_identity() AS int)";
                                var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue ("@clustername", Cluster.Name);
                                cmd.Parameters.AddWithValue ("@speciesid", Species.Id.ToString ());
                                Cluster.Id = (int) cmd.ExecuteScalar ();
                                CnnSS.Close ();
                                }
                            }
                        catch (Exception ex)
                            {
                            DialogResult myansw = (DialogResult) MessageBox.Show ("Error adding new cluster \r\n Show Error Message ?", "eLib", MessageBoxButtons.YesNo);
                            if ((int) myansw == (int) Constants.vbYes)
                                {
                                MessageBox.Show (ex.ToString ());
                                }
                            }
                        //bypass 14 more lines -untill reach a line satating with # start gene xxx
                        while (Strings.Left (Linex, 37) != "# Predicted genes for sequence number")
                            {
                            Linex = FileSystem.LineInput (1);
                            }
                        //start reading genes and transcripts
                        Transcript.PereviousGeneEnd = 1;
                        while (!FileSystem.EOF (1))
                            {
                            try
                                {
                                Linex = FileSystem.LineInput (1);
                                switch (Strings.Left (Linex, 11))
                                    {
                                    case "# start gen":
                                            {
                                            string geneLine = FileSystem.LineInput (1);
                                            Transcript.PereviousGeneEnd = Transcript.TranscriptTo;
                                            ParseTranscriptBlock ("");
                                            break;
                                            }
                                    case "# end gene ":
                                            {
                                            Linex = FileSystem.LineInput (1); //###
                                            break;
                                            }
                                    case "# command l":
                                            {
                                            Linex = FileSystem.LineInput (1);
                                            break;
                                            }
                                    default:
                                            {
                                            string [] itmT = Linex.Split ('\t');
                                            if (itmT [2] == "transcript")
                                                {
                                                ParseTranscriptBlock (Linex);
                                                }
                                            break;
                                            }
                                    }
                                }
                            catch (Exception ex)
                                {
                                MessageBox.Show (ex.ToString ());
                                }
                            }
                        FileSystem.FileClose (1);
                        }
                    else //bad file
                        {
                        MessageBox.Show ("incorrect file!", "eLib");
                        FileSystem.FileClose (1);
                        }
                    e.Effect = DragDropEffects.None;
                    }
                Species.Id = (int) lstSpecies.SelectedValue;
                GetClusters (Species.Id);
                }
            }
        private void ParseTranscriptBlock (string strline)
            {
            string transcriptLine = "";
            if (strline == "")
                {
                transcriptLine = FileSystem.LineInput (1);
                }
            else
                transcriptLine = strline;
                {
                }
            string [] items = transcriptLine.Split ('\t');
            //lstTranscript.Items.Add ("Transcript: " + items [8]);
            Transcript.TranscriptFrom = Convert.ToInt32 (items [3]);
            Transcript.TranscriptTo = Convert.ToInt32 (items [4]);
            Transcript.Direction = (items [6] == "+") ? "P" : "N";
            Transcript.Name = items [8];
            //SQL
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = @"INSERT INTO Transcripts (TranscriptName, Cluster_ID, SpacerLength, TranscriptFrom, TranscriptTo, GeneSize, Direction, Description, Sel, Info) VALUES (@transcriptname, @clusterid, @spacerlength, @transcriptfrom, @transcriptto, @genesize, @direction, '', 1, ''); SELECT CAST (scope_identity() AS int)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@transcriptname", Transcript.Name);
                    cmd.Parameters.AddWithValue ("@clusterid", Cluster.Id.ToString ());
                    cmd.Parameters.AddWithValue ("@spacerlength", (Transcript.TranscriptFrom - Transcript.PereviousGeneEnd).ToString ());
                    cmd.Parameters.AddWithValue ("@transcriptfrom", Transcript.TranscriptFrom.ToString ());
                    cmd.Parameters.AddWithValue ("@transcriptto", Transcript.TranscriptTo.ToString ());
                    cmd.Parameters.AddWithValue ("@genesize", (Transcript.TranscriptTo - Transcript.TranscriptFrom).ToString ());
                    cmd.Parameters.AddWithValue ("@direction", Transcript.Direction);
                    Transcript.Id = (int) cmd.ExecuteScalar ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                DialogResult myansw = (DialogResult) MessageBox.Show ("Error \r\n Show Error Message ?", "eLib", MessageBoxButtons.YesNo);
                if ((int) myansw == (int) Constants.vbYes)
                    MessageBox.Show (ex.ToString ());
                }
            string strSequence = "";
            //dna
            while (Strings.InStr (1, transcriptLine, "# coding sequence =") == 0)
                {
                transcriptLine = FileSystem.LineInput (1);
                }
            strSequence = Strings.Mid (transcriptLine, 21);
            while (Strings.Right (transcriptLine, 1) != "]")
                {
                transcriptLine = FileSystem.LineInput (1);
                strSequence += Strings.Mid (transcriptLine, 2);
                }
            //SQL
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = @"INSERT INTO Sequences (ParentType, Parent_ID, SequenceType, SequenceText) VALUES (@parenttype, @parentid, @sequencetype, @sequencetext); SELECT CAST (scope_identity() AS int)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@parenttype", 1); //1:t 2:g
                    cmd.Parameters.AddWithValue ("@parentid", Transcript.Id.ToString ());
                    cmd.Parameters.AddWithValue ("@sequencetype", 1); //1:dna 2:rna 3:pr
                    cmd.Parameters.AddWithValue ("@sequencetext", strSequence);
                    Sequence.Id = (int) cmd.ExecuteScalar ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                DialogResult myansw = (DialogResult) MessageBox.Show ("Error \r\n Show Error Message ?", "eLib", MessageBoxButtons.YesNo);
                if ((int) myansw == (int) Constants.vbYes)
                    MessageBox.Show (ex.ToString ());
                }
            //protein
            strSequence = "";
            transcriptLine = FileSystem.LineInput (1);
            strSequence = Strings.Mid (transcriptLine, 22);
            while (Strings.Right (transcriptLine, 1) != "]")
                {
                transcriptLine = FileSystem.LineInput (1);
                strSequence += Strings.Mid (transcriptLine, 2);
                }
            //SQL
            try
                {
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = @"INSERT INTO Sequences (ParentType, Parent_ID, SequenceType, SequenceText) VALUES (@parenttype, @parentid, @sequencetype, @sequencetext); SELECT CAST (scope_identity() AS int)";
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue ("@parenttype", 1); //1:t 2:g
                    cmd.Parameters.AddWithValue ("@parentid", Transcript.Id.ToString ());
                    cmd.Parameters.AddWithValue ("@sequencetype", 3); //1:dna 2:rna 3:pr
                    cmd.Parameters.AddWithValue ("@sequencetext", strSequence);
                    Sequence.Id = (int) cmd.ExecuteScalar ();
                    CnnSS.Close ();
                    }
                }
            catch (Exception ex)
                {
                DialogResult myansw = (DialogResult) MessageBox.Show ("Error \r\n Show Error Message ?", "eLib", MessageBoxButtons.YesNo);
                if ((int) myansw == (int) Constants.vbYes)
                    MessageBox.Show (ex.ToString ());
                }
            }
        private void lstCluster_Click (object sender, EventArgs e)
            {
            try
                {
                if (lstCluster.SelectedIndex != -1)
                    {
                    Cluster.Id = (int) lstCluster.SelectedValue;
                    GetTranscripts (Cluster.Id);
                    txtSequenceData.Text = "";
                    Species.SciName = lstSpecies.Text;
                    Cluster.Name = lstCluster.Text;
                    txtSequenceData.Text = "SPECIES:     \t" + Species.SciName;
                    txtSequenceData.Text += "\r\nCLUSTER:    \t" + Cluster.Name + "\r\n--------\r\n";
                    for (int index = 0; index < lstTranscript.Items.Count; index++)
                        {
                        Transcript.Id = (int) lstTranscript.SelectedValue;
                        Transcript.Name = Db.DS.Tables ["tblTranscripts"].Rows [index] [1].ToString ();
                        Transcript.ClusterId = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [2].ToString ());
                        Transcript.SpacerLength = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [3].ToString ());
                        Transcript.TranscriptFrom = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [4].ToString ());
                        Transcript.TranscriptTo = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [5].ToString ());
                        Transcript.GeneSize = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [6].ToString ());
                        Transcript.Direction = Db.DS.Tables ["tblTranscripts"].Rows [index] [7].ToString ();
                        Transcript.Description = Db.DS.Tables ["tblTranscripts"].Rows [index] [8].ToString ();
                        Transcript.Sel = Convert.ToBoolean (Db.DS.Tables ["tblTranscripts"].Rows [index] [9].ToString ());
                        Transcript.Info = Db.DS.Tables ["tblTranscripts"].Rows [index] [10].ToString ();

                        txtSequenceData.Text += "\r\nTranscript: \t" + Transcript.Name;
                        txtSequenceData.Text += "\r\nSize:       \t" + Transcript.GeneSize.ToString () + " (" + Transcript.TranscriptFrom.ToString () + " - " + Transcript.TranscriptTo.ToString () + ")";
                        txtSequenceData.Text += "\r\nDirection:  \t" + Transcript.Direction;
                        txtSequenceData.Text += "\r\nFunction:   \t" + Transcript.Description + "\r\n";
                        }
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show ("Error:\n" + ex.ToString ());
                }
            }
        private void lstCluster_DoubleClick (object sender, EventArgs e)
            {
            EditCluster ();
            }
        private void Menu_EditCluster_Click (object sender, EventArgs e)
            {
            EditCluster ();
            }
        private void EditCluster ()
            {
            if (lstCluster.SelectedIndex != -1)
                {
                string tmpClusterName = lstCluster.Text;
                Cluster.Id = (int) lstCluster.SelectedValue;
                try
                    {
                    string strClusterName = Interaction.InputBox ("Enter Cluster Name:", "eLib", tmpClusterName);
                    if (!String.IsNullOrEmpty (strClusterName)) //save it
                        {
                        using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                            {
                            CnnSS.Open ();
                            Db.strSQL = "UPDATE Clusters SET ClusterName = @clustername WHERE ID = @id";
                            var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                            cmdx.CommandType = CommandType.Text;
                            cmdx.Parameters.AddWithValue ("@clustername", strClusterName);
                            cmdx.Parameters.AddWithValue ("@id", Cluster.Id.ToString ());
                            int i = (int) cmdx.ExecuteNonQuery ();
                            CnnSS.Close ();
                            }
                        Species.Id = (int) lstSpecies.SelectedValue;
                        GetClusters (Species.Id);
                        lstCluster.SelectedValue = Cluster.Id;
                        }
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ()); //do nothing!
                    }
                }
            }
        private void Menu_DeleteCluster_Click (object sender, EventArgs e)
            {
            if (lstCluster.SelectedIndex != -1)
                {
                Cluster.Id = (int) lstCluster.SelectedValue;
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        //3
                        Db.strSQL = "DELETE FROM Sequences WHERE Parent_ID IN (SELECT ID FROM Transcripts WHERE Cluster_ID = " + Cluster.Id.ToString () + ")";
                        var cmdx3 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx3.CommandType = CommandType.Text;
                        int i3 = (int) cmdx3.ExecuteNonQuery ();
                        //2
                        Db.strSQL = "DELETE FROM Transcripts WHERE Cluster_ID = @id";
                        var cmdx2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx2.CommandType = CommandType.Text;
                        cmdx2.Parameters.AddWithValue ("@id", Cluster.Id.ToString ());
                        int i2 = (int) cmdx2.ExecuteNonQuery ();
                        //1
                        Db.strSQL = "DELETE FROM Clusters WHERE ID = @id";
                        var cmdx1 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx1.CommandType = CommandType.Text;
                        cmdx1.Parameters.AddWithValue ("@id", Cluster.Id.ToString ());
                        int i = (int) cmdx1.ExecuteNonQuery ();
                        //close
                        CnnSS.Close ();
                        }
                    Species.Id = (int) lstSpecies.SelectedValue;
                    GetClusters (Species.Id);
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ()); //do nothing!
                    }
                }
            }
        //list transcript
        private void lstTranscript_Click (object sender, EventArgs e)
            {
            if (lstTranscript.SelectedIndex == -1)
                {
                return;
                }
            Species.SciName = lstSpecies.Text;
            Cluster.Name = lstCluster.Text;
            int index = lstTranscript.SelectedIndex;
            Transcript.Id = (int) lstTranscript.SelectedValue;
            Transcript.Name = Db.DS.Tables ["tblTranscripts"].Rows [index] [1].ToString ();
            Transcript.ClusterId = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [2].ToString ());
            Transcript.SpacerLength = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [3].ToString ());
            Transcript.TranscriptFrom = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [4].ToString ());
            Transcript.TranscriptTo = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [5].ToString ());
            Transcript.GeneSize = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [6].ToString ());
            Transcript.Direction = Db.DS.Tables ["tblTranscripts"].Rows [index] [7].ToString ();
            Transcript.Description = Db.DS.Tables ["tblTranscripts"].Rows [index] [8].ToString ();
            Transcript.Sel = Convert.ToBoolean (Db.DS.Tables ["tblTranscripts"].Rows [index] [9].ToString ());
            Transcript.Info = Db.DS.Tables ["tblTranscripts"].Rows [index] [10].ToString ();

            txtSequenceData.Text = "SPECIES:     \t" + Species.SciName;
            txtSequenceData.Text += "\r\nCLUSTER:    \t" + Cluster.Name;
            txtSequenceData.Text += "\r\nTRANSCRIPT: \t" + Transcript.Name;
            txtSequenceData.Text += "\r\nSPACER:   \t" + Transcript.SpacerLength.ToString ();
            txtSequenceData.Text += "\r\nFROM:     \t" + Transcript.TranscriptFrom.ToString ();
            txtSequenceData.Text += "\r\nTo:       \t" + Transcript.TranscriptTo.ToString ();
            txtSequenceData.Text += "\r\nGeneSIZE: \t" + Transcript.GeneSize.ToString ();
            txtSequenceData.Text += "\r\nDIRECTION: \t" + Transcript.Direction;
            txtSequenceData.Text += "\r\nFUNCTION: \t" + Transcript.Description;
            txtSequenceData.Text += "\r\n\r\nPROTEIN: \r\n";
            txtSequenceData.Text += GetSequence (Transcript.Id, 3);
            txtSequenceData.Text += "\r\n\r\nDNA: \r\n";
            txtSequenceData.Text += GetSequence (Transcript.Id, 1);
            }
        private void lstTranscript_DoubleClick (object sender, EventArgs e)
            {
            EditTranscript ();
            }
        private void Menu_EditTranscript_Click (object sender, EventArgs e)
            {
            EditTranscript ();
            }
        private void EditTranscript ()
            {
            if (lstTranscript.SelectedIndex != -1)
                {
                int index = lstTranscript.SelectedIndex;
                Transcript.Id = (int) lstTranscript.SelectedValue;
                Transcript.Name = Db.DS.Tables ["tblTranscripts"].Rows [index] [1].ToString ();
                Transcript.ClusterId = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [2].ToString ());
                Transcript.SpacerLength = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [3].ToString ());
                Transcript.TranscriptFrom = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [4].ToString ());
                Transcript.TranscriptTo = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [5].ToString ());
                Transcript.GeneSize = Convert.ToInt32 (Db.DS.Tables ["tblTranscripts"].Rows [index] [6].ToString ());
                Transcript.Direction = Db.DS.Tables ["tblTranscripts"].Rows [index] [7].ToString ();
                Transcript.Description = Db.DS.Tables ["tblTranscripts"].Rows [index] [8].ToString ();
                Transcript.Sel = Convert.ToBoolean (Db.DS.Tables ["tblTranscripts"].Rows [index] [9].ToString ());
                Transcript.Info = Db.DS.Tables ["tblTranscripts"].Rows [index] [10].ToString ();
                //show dialog
                Form TranscriptEditor = new frmAugustusTranscriptEdit ();
                TranscriptEditor.ShowDialog ();
                txtSequenceData.Text = "";
                GetTranscripts (Cluster.Id);
                lstTranscript.SelectedValue = Transcript.Id;
                }
            }
        //textbox
        private void txtSequenceData_DragEnter (object sender, DragEventArgs e)
            {
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        private void txtSequenceData_DragDrop (object sender, DragEventArgs e)
            {
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            eLibFile.strFilex = strFiles [0];
            FileInfo MyFile = new FileInfo (strFiles [0]);
            string ext = MyFile.Extension.ToLower ();
            if ((ext == ".txt") || (ext == ".cs") || (ext == ".fasta") || (ext == ".r") || (ext == ".py"))
                {
                string text = System.IO.File.ReadAllText (eLibFile.strFilex);
                e.Effect = DragDropEffects.None;
                txtSequenceData.Text = text; //Strings.Left (text, 3998);
                }
            }
        private void Menu_DeleteDuplicateTranscripts_Click (object sender, EventArgs e)
            {
            DialogResult myansw = MessageBox.Show ("Delete Transcripts \n\nWHERE : not Selected\n\nNotice: This operation cannot be undo!", "eLib", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (myansw == DialogResult.Cancel)
                {
                return;
                }
            else
                {
                Cluster.Id = (int) lstCluster.SelectedValue;
                try
                    {
                    using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                        {
                        CnnSS.Open ();
                        //B
                        Db.strSQL = "DELETE FROM Sequences WHERE Parent_ID IN (SELECT ID FROM Transcripts WHERE Cluster_ID = " + Cluster.Id.ToString () + " AND SEL = 0)";
                        var cmdx3 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx3.CommandType = CommandType.Text;
                        int i3 = (int) cmdx3.ExecuteNonQuery ();
                        //A
                        Db.strSQL = "DELETE FROM Transcripts WHERE Cluster_ID = @id AND Sel = 0";
                        var cmdx2 = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                        cmdx2.CommandType = CommandType.Text;
                        cmdx2.Parameters.AddWithValue ("@id", Cluster.Id.ToString ());
                        int i2 = (int) cmdx2.ExecuteNonQuery ();
                        //close
                        CnnSS.Close ();
                        }
                    Species.Id = (int) lstSpecies.SelectedValue;
                    GetClusters (Species.Id);
                    MessageBox.Show ("Duplicate Transcripts REMOVED!", "eLib");
                    }
                catch (Exception ex)
                    {
                    MessageBox.Show (ex.ToString ()); //do nothing!
                    }
                }
            }
        //feed lists
        private void GetSpecies (int projectid)
            {
            //refresh species
            Db.DS.Tables ["tblSpecies"].Clear ();
            Db.strSQL = "Select ID, SciName, Taxonomy, Project_ID FROM Species WHERE Project_ID = " + projectid.ToString () + " Order By SciName";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblSpecies");
                CnnSS.Close ();
                }
            lstSpecies.DataSource = Db.DS.Tables ["tblSpecies"];
            lstSpecies.ValueMember = "ID";
            lstSpecies.DisplayMember = "SciName";
            lstCluster.DataSource = null;
            lstTranscript.DataSource = null;
            txtSequenceData.Text = "";
            }
        private void GetClusters (int speciesid)
            {
            Db.DS.Tables ["tblClusters"].Clear ();
            Db.strSQL = "Select ID, ClusterName, Species_ID FROM Clusters WHERE Species_ID = " + speciesid.ToString () + " Order By ID";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblClusters");
                CnnSS.Close ();
                }
            lstCluster.DataSource = Db.DS.Tables ["tblClusters"];
            lstCluster.ValueMember = "ID";
            lstCluster.DisplayMember = "ClusterName";
            lstTranscript.DataSource = null;
            txtSequenceData.Text = "";
            }
        private void GetTranscripts (int clusterid)
            {
            Db.DS.Tables ["tblTranscripts"].Clear ();
            Db.strSQL = "Select ID, TranscriptName, Cluster_ID, SpacerLength, TranscriptFrom, TranscriptTo, GeneSize, Direction, Description, Sel, Info FROM Transcripts WHERE Cluster_ID = " + clusterid.ToString () + " Order By TranscriptFrom";
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                CnnSS.Open ();
                Db.DASS = new Microsoft.Data.SqlClient.SqlDataAdapter (Db.strSQL, CnnSS);
                Db.DASS.Fill (Db.DS, "tblTranscripts");
                CnnSS.Close ();
                }
            lstTranscript.DataSource = Db.DS.Tables ["tblTranscripts"];
            lstTranscript.ValueMember = "ID";
            lstTranscript.DisplayMember = "TranscriptName";
            }
        private string GetSequence (int parentid, int sequencetype)
            {
            using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                {
                Db.strSQL = "SELECT SequenceText FROM Sequences WHERE Parent_ID = " + parentid.ToString () + " AND Sequencetype = " + sequencetype.ToString ();
                CnnSS.Open ();
                var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                var reader = cmdx.ExecuteScalar ();
                CnnSS.Close ();
                Sequence.SequenceText = reader.ToString ();
                return Sequence.SequenceText;
                }
            }
        //navigation
        private void lstSpecies_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Enter:
                case Keys.Right:
                        {
                        lstSpecies_Click (null, null);
                        lstCluster.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case Keys.Escape:
                        {
                        Exit ();
                        break;
                        }
                }
            }
        private void lstCluster_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Left:
                        {
                        lstSpecies.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case Keys.Enter:
                case Keys.Right:
                        {
                        lstCluster_Click (null, null);
                        lstTranscript.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case Keys.Escape:
                        {
                        Exit ();
                        break;
                        }
                }
            }
        private void lstTranscript_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Left:
                        {
                        lstCluster.Focus ();
                        e.SuppressKeyPress = true;
                        break;
                        }
                case Keys.Enter:
                        {
                        e.SuppressKeyPress = true;
                        Menu_EditTranscript_Click (null, null);
                        break;
                        }
                case Keys.Right:
                        {
                        lstTranscript_Click (null, null);
                        e.SuppressKeyPress = true;
                        break;
                        }
                case Keys.Escape:
                        {
                        Exit ();
                        break;
                        }
                }
            }
        //exit
        private void Menu_Exit_Click (object sender, EventArgs e)
            {
            Exit ();
            }
        private void label2_Click (object sender, EventArgs e)
            {
            Exit ();
            }
        private void Exit ()
            {
            Dispose ();
            }

        }
    }
