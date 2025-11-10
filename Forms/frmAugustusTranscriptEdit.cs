using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace eLib.Forms
    {
    public partial class frmAugustusTranscriptEdit : Form
        {
        public frmAugustusTranscriptEdit ()
            {
            InitializeComponent ();
            }
        private void frmAugustusTranscriptEdit_Load (object sender, EventArgs e)
            {
            txtTranscriptName.Text = Transcript.Name;
            txtGeneSize.Text = Transcript.GeneSize.ToString ();
            chkSel.Checked = Transcript.Sel;
            txtFunction.Text = Transcript.Description;
            txtInfo.Text = Transcript.Info;
            }
        private void frmAugustusTranscriptEdit_KeyDown (object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Escape)
                {
                Exit ();
                }
            }
        //navigations
        private void txtGeneSize_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Up:
                        {
                        e.SuppressKeyPress = true;
                        txtFunction.Focus ();
                        break;
                        }
                case Keys.Left:
                        {
                        e.SuppressKeyPress = true;
                        txtTranscriptName.Focus ();
                        break;
                        }
                case Keys.Enter:
                case Keys.Down:
                        {
                        e.SuppressKeyPress = true;
                        txtInfo.Focus ();
                        break;
                        }
                }
            }
        private void txtTranscriptName_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Enter:
                        {
                        e.SuppressKeyPress = true;
                        txtFunction.Focus ();
                        break;
                        }
                }
            }
        private void txtFunction_KeyDown (object sender, KeyEventArgs e)
            {
            switch (e.KeyCode)
                {
                case Keys.Enter:
                        {
                        e.SuppressKeyPress = true;
                        txtGeneSize.Focus ();
                        break;
                        }
                }
            }
        //drop
        private void txtInfo_DragDrop (object sender, DragEventArgs e)
            {
            string [] strFiles = (string []) e.Data.GetData (DataFormats.FileDrop, false);
            eLibFile.strFilex = strFiles [0];
            FileInfo MyFile = new FileInfo (strFiles [0]);
            string ext = MyFile.Extension.ToLower ();
            if ((ext == ".txt") || (ext == ".cs") || (ext == ".fasta") || (ext == ".r") || (ext == ".py"))
                {
                string text = System.IO.File.ReadAllText (eLibFile.strFilex);
                e.Effect = DragDropEffects.None;
                txtInfo.Text = text; //Strings.Left (text, 3998);
                }
            }
        private void txtInfo_DragEnter (object sender, DragEventArgs e)
            {
            if (e.Data.GetDataPresent (DataFormats.FileDrop))
                {
                e.Effect = DragDropEffects.Copy;
                }
            }
        //menu
        private void lblSave_Click (object sender, EventArgs e)
            {
            SaveTranscript ();
            }
        private void SaveTranscript ()
            {
            try
                {
                Transcript.Name = txtTranscriptName.Text;
                Transcript.GeneSize = Convert.ToInt32 (txtGeneSize.Text);
                Transcript.Sel = chkSel.Checked;
                Transcript.Description = txtFunction.Text;
                Transcript.Info = txtInfo.Text;
                using (var CnnSS = new Microsoft.Data.SqlClient.SqlConnection (Db.CnnString))
                    {
                    CnnSS.Open ();
                    Db.strSQL = "UPDATE Transcripts SET TranscriptName = @transcriptname, Genesize = @genesize, Description = @description, Sel = @sel, Info = @info WHERE ID = @id";
                    var cmdx = new Microsoft.Data.SqlClient.SqlCommand (Db.strSQL, CnnSS);
                    cmdx.CommandType = CommandType.Text;
                    cmdx.Parameters.AddWithValue ("@transcriptname", Transcript.Name);
                    cmdx.Parameters.AddWithValue ("@genesize", Transcript.GeneSize.ToString ());
                    cmdx.Parameters.AddWithValue ("@description", Transcript.Description);
                    cmdx.Parameters.AddWithValue ("@sel", Transcript.Sel.ToString ());
                    cmdx.Parameters.AddWithValue ("@info", Transcript.Info);
                    cmdx.Parameters.AddWithValue ("@id", Transcript.Id.ToString ());
                    int i = (int) cmdx.ExecuteNonQuery ();
                    CnnSS.Close ();
                    Exit ();
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show (ex.ToString ()); //do nothing!
                }
            }
        private void Menu_Save_Click (object sender, EventArgs e)
            {
            SaveTranscript ();
            }
        private void Menu_Cancel_Click (object sender, EventArgs e)
            {
            Exit ();
            }
        private void Exit ()
            {
            Dispose ();
            }

        private void label6_Click (object sender, EventArgs e)
            {
            Exit ();
            }
        }
    }
