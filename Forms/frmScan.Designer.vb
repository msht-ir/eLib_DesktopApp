<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lbl_P = New Label()
        lblFolderPapers = New Label()
        lblFolderBooks = New Label()
        lbl_B = New Label()
        lblFolderManuals = New Label()
        lbl_M = New Label()
        lblFolderLectures = New Label()
        lbl_L = New Label()
        lblFolderSaveACopy = New Label()
        lbl_S = New Label()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu_Scan = New ToolStripMenuItem()
        Menu_Exit = New ToolStripMenuItem()
        lblStatus = New Label()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' lbl_P
        ' 
        lbl_P.AutoSize = True
        lbl_P.Font = New Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        lbl_P.ForeColor = Color.IndianRed
        lbl_P.Location = New Point(89, 36)
        lbl_P.Name = "lbl_P"
        lbl_P.Size = New Size(56, 18)
        lbl_P.TabIndex = 1
        lbl_P.Text = "Papers"
        ' 
        ' lblFolderPapers
        ' 
        lblFolderPapers.AutoSize = True
        lblFolderPapers.Font = New Font("Consolas", 11.25F, FontStyle.Italic, GraphicsUnit.Point)
        lblFolderPapers.ForeColor = SystemColors.ControlDarkDark
        lblFolderPapers.Location = New Point(175, 36)
        lblFolderPapers.Name = "lblFolderPapers"
        lblFolderPapers.Size = New Size(152, 18)
        lblFolderPapers.TabIndex = 2
        lblFolderPapers.Text = "eLib Papers Folder"
        ' 
        ' lblFolderBooks
        ' 
        lblFolderBooks.AutoSize = True
        lblFolderBooks.Font = New Font("Consolas", 11.25F, FontStyle.Italic, GraphicsUnit.Point)
        lblFolderBooks.ForeColor = SystemColors.ControlDarkDark
        lblFolderBooks.Location = New Point(175, 75)
        lblFolderBooks.Name = "lblFolderBooks"
        lblFolderBooks.Size = New Size(144, 18)
        lblFolderBooks.TabIndex = 4
        lblFolderBooks.Text = "eLib Books Folder"
        ' 
        ' lbl_B
        ' 
        lbl_B.AutoSize = True
        lbl_B.Font = New Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        lbl_B.ForeColor = Color.IndianRed
        lbl_B.Location = New Point(97, 75)
        lbl_B.Name = "lbl_B"
        lbl_B.Size = New Size(48, 18)
        lbl_B.TabIndex = 3
        lbl_B.Text = "Books"
        ' 
        ' lblFolderManuals
        ' 
        lblFolderManuals.AutoSize = True
        lblFolderManuals.Font = New Font("Consolas", 11.25F, FontStyle.Italic, GraphicsUnit.Point)
        lblFolderManuals.ForeColor = SystemColors.ControlDarkDark
        lblFolderManuals.Location = New Point(175, 120)
        lblFolderManuals.Name = "lblFolderManuals"
        lblFolderManuals.Size = New Size(160, 18)
        lblFolderManuals.TabIndex = 6
        lblFolderManuals.Text = "eLib Manuals Folder"
        ' 
        ' lbl_M
        ' 
        lbl_M.AutoSize = True
        lbl_M.Font = New Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        lbl_M.ForeColor = Color.IndianRed
        lbl_M.Location = New Point(81, 120)
        lbl_M.Name = "lbl_M"
        lbl_M.Size = New Size(64, 18)
        lbl_M.TabIndex = 5
        lbl_M.Text = "Manuals"
        ' 
        ' lblFolderLectures
        ' 
        lblFolderLectures.AutoSize = True
        lblFolderLectures.Font = New Font("Consolas", 11.25F, FontStyle.Italic, GraphicsUnit.Point)
        lblFolderLectures.ForeColor = SystemColors.ControlDarkDark
        lblFolderLectures.Location = New Point(175, 162)
        lblFolderLectures.Name = "lblFolderLectures"
        lblFolderLectures.Size = New Size(168, 18)
        lblFolderLectures.TabIndex = 8
        lblFolderLectures.Text = "eLib Lectures Folder"
        ' 
        ' lbl_L
        ' 
        lbl_L.AutoSize = True
        lbl_L.Font = New Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        lbl_L.ForeColor = Color.IndianRed
        lbl_L.Location = New Point(73, 162)
        lbl_L.Name = "lbl_L"
        lbl_L.Size = New Size(72, 18)
        lbl_L.TabIndex = 7
        lbl_L.Text = "Lectures"
        ' 
        ' lblFolderSaveACopy
        ' 
        lblFolderSaveACopy.AutoSize = True
        lblFolderSaveACopy.Font = New Font("Consolas", 11.25F, FontStyle.Italic, GraphicsUnit.Point)
        lblFolderSaveACopy.ForeColor = SystemColors.ControlDarkDark
        lblFolderSaveACopy.Location = New Point(175, 206)
        lblFolderSaveACopy.Name = "lblFolderSaveACopy"
        lblFolderSaveACopy.Size = New Size(176, 18)
        lblFolderSaveACopy.TabIndex = 10
        lblFolderSaveACopy.Text = "eLib SaveACopy Folder"
        ' 
        ' lbl_S
        ' 
        lbl_S.AutoSize = True
        lbl_S.Font = New Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        lbl_S.ForeColor = Color.IndianRed
        lbl_S.Location = New Point(49, 206)
        lbl_S.Name = "lbl_S"
        lbl_S.Size = New Size(96, 18)
        lbl_S.TabIndex = 9
        lbl_S.Text = "Save a copy"
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu_Scan, Menu_Exit})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(100, 48)
        ' 
        ' Menu_Scan
        ' 
        Menu_Scan.Name = "Menu_Scan"
        Menu_Scan.Size = New Size(99, 22)
        Menu_Scan.Text = "Scan"
        ' 
        ' Menu_Exit
        ' 
        Menu_Exit.ForeColor = Color.IndianRed
        Menu_Exit.Name = "Menu_Exit"
        Menu_Exit.Size = New Size(99, 22)
        Menu_Exit.Text = "Exit"
        ' 
        ' lblStatus
        ' 
        lblStatus.BackColor = SystemColors.ControlLight
        lblStatus.Dock = DockStyle.Bottom
        lblStatus.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        lblStatus.ForeColor = Color.IndianRed
        lblStatus.Location = New Point(0, 258)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(571, 27)
        lblStatus.TabIndex = 11
        lblStatus.Text = "-"
        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmScan
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(571, 285)
        ContextMenuStrip = ContextMenuStrip1
        ControlBox = False
        Controls.Add(lblStatus)
        Controls.Add(lblFolderSaveACopy)
        Controls.Add(lbl_S)
        Controls.Add(lblFolderLectures)
        Controls.Add(lbl_L)
        Controls.Add(lblFolderManuals)
        Controls.Add(lbl_M)
        Controls.Add(lblFolderBooks)
        Controls.Add(lbl_B)
        Controls.Add(lblFolderPapers)
        Controls.Add(lbl_P)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmScan"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Scan"
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lbl_P As Label
    Friend WithEvents lblFolderPapers As Label
    Friend WithEvents lblFolderBooks As Label
    Friend WithEvents lbl_B As Label
    Friend WithEvents lblFolderManuals As Label
    Friend WithEvents lbl_M As Label
    Friend WithEvents lblFolderLectures As Label
    Friend WithEvents lbl_L As Label
    Friend WithEvents lblFolderSaveACopy As Label
    Friend WithEvents lbl_S As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Scan As ToolStripMenuItem
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents lblStatus As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
