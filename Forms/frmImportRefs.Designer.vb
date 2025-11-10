<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportRefs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        txtTitle = New TextBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu1_Select = New ToolStripMenuItem()
        Menu1_Paste = New ToolStripMenuItem()
        Menu1_Move = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        Menu1_Exit = New ToolStripMenuItem()
        ListProduct = New ListBox()
        ContextMenuStrip2 = New ContextMenuStrip(components)
        Menu2_Add = New ToolStripMenuItem()
        Menu2_Remove = New ToolStripMenuItem()
        Menu2_Clear = New ToolStripMenuItem()
        radioPaper = New RadioButton()
        radioBook = New RadioButton()
        radioManual = New RadioButton()
        radioLecture = New RadioButton()
        txtNote = New TextBox()
        Panel1 = New Panel()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        lblPath = New Label()
        CheckAskDest = New CheckBox()
        lblExt = New Label()
        lblSize = New Label()
        lblCreated = New Label()
        lblModified = New Label()
        RadiobtnOpen = New RadioButton()
        RadiobtnMove = New RadioButton()
        RadiobtnInspect = New RadioButton()
        lblDestinationFolder = New Label()
        ContextMenuStrip1.SuspendLayout()
        ContextMenuStrip2.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtTitle
        ' 
        txtTitle.AllowDrop = True
        txtTitle.BackColor = SystemColors.Control
        txtTitle.BorderStyle = BorderStyle.None
        txtTitle.ContextMenuStrip = ContextMenuStrip1
        txtTitle.Dock = DockStyle.Top
        txtTitle.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point)
        txtTitle.ForeColor = Color.IndianRed
        txtTitle.Location = New Point(0, 0)
        txtTitle.Multiline = True
        txtTitle.Name = "txtTitle"
        txtTitle.Size = New Size(835, 69)
        txtTitle.TabIndex = 0
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu1_Select, Menu1_Paste, Menu1_Move, ToolStripMenuItem1, Menu1_Exit})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(181, 120)
        ' 
        ' Menu1_Select
        ' 
        Menu1_Select.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Menu1_Select.ForeColor = SystemColors.ControlText
        Menu1_Select.Name = "Menu1_Select"
        Menu1_Select.Size = New Size(180, 22)
        Menu1_Select.Text = "1- Select ..."
        ' 
        ' Menu1_Paste
        ' 
        Menu1_Paste.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Menu1_Paste.ForeColor = SystemColors.ControlText
        Menu1_Paste.Name = "Menu1_Paste"
        Menu1_Paste.Size = New Size(180, 22)
        Menu1_Paste.Text = "2- Title"
        ' 
        ' Menu1_Move
        ' 
        Menu1_Move.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Menu1_Move.ForeColor = SystemColors.ControlText
        Menu1_Move.Name = "Menu1_Move"
        Menu1_Move.Size = New Size(180, 22)
        Menu1_Move.Text = "3- Move"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(177, 6)
        ' 
        ' Menu1_Exit
        ' 
        Menu1_Exit.ForeColor = Color.IndianRed
        Menu1_Exit.Name = "Menu1_Exit"
        Menu1_Exit.Size = New Size(180, 22)
        Menu1_Exit.Text = "Exit"
        ' 
        ' ListProduct
        ' 
        ListProduct.BackColor = SystemColors.Control
        ListProduct.BorderStyle = BorderStyle.None
        ListProduct.ContextMenuStrip = ContextMenuStrip2
        ListProduct.Font = New Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point)
        ListProduct.ForeColor = Color.DarkCyan
        ListProduct.FormattingEnabled = True
        ListProduct.ItemHeight = 21
        ListProduct.Location = New Point(258, 121)
        ListProduct.Name = "ListProduct"
        ListProduct.Size = New Size(347, 105)
        ListProduct.TabIndex = 1
        ' 
        ' ContextMenuStrip2
        ' 
        ContextMenuStrip2.Items.AddRange(New ToolStripItem() {Menu2_Add, Menu2_Remove, Menu2_Clear})
        ContextMenuStrip2.Name = "ContextMenuStrip2"
        ContextMenuStrip2.Size = New Size(148, 70)
        ' 
        ' Menu2_Add
        ' 
        Menu2_Add.Name = "Menu2_Add"
        Menu2_Add.Size = New Size(147, 22)
        Menu2_Add.Text = "+ Add Project"
        ' 
        ' Menu2_Remove
        ' 
        Menu2_Remove.Name = "Menu2_Remove"
        Menu2_Remove.Size = New Size(147, 22)
        Menu2_Remove.Text = "- Remove"
        ' 
        ' Menu2_Clear
        ' 
        Menu2_Clear.ForeColor = Color.IndianRed
        Menu2_Clear.Name = "Menu2_Clear"
        Menu2_Clear.Size = New Size(147, 22)
        Menu2_Clear.Text = "Clear all"
        ' 
        ' radioPaper
        ' 
        radioPaper.AutoSize = True
        radioPaper.Checked = True
        radioPaper.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        radioPaper.ForeColor = SystemColors.ControlDarkDark
        radioPaper.Location = New Point(9, 4)
        radioPaper.Name = "radioPaper"
        radioPaper.Size = New Size(57, 19)
        radioPaper.TabIndex = 2
        radioPaper.TabStop = True
        radioPaper.Text = "Paper"
        radioPaper.UseVisualStyleBackColor = True
        ' 
        ' radioBook
        ' 
        radioBook.AutoSize = True
        radioBook.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        radioBook.ForeColor = SystemColors.ControlDarkDark
        radioBook.Location = New Point(96, 4)
        radioBook.Name = "radioBook"
        radioBook.Size = New Size(54, 19)
        radioBook.TabIndex = 3
        radioBook.TabStop = True
        radioBook.Text = "Book"
        radioBook.UseVisualStyleBackColor = True
        ' 
        ' radioManual
        ' 
        radioManual.AutoSize = True
        radioManual.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        radioManual.ForeColor = SystemColors.ControlDarkDark
        radioManual.Location = New Point(181, 4)
        radioManual.Name = "radioManual"
        radioManual.Size = New Size(65, 19)
        radioManual.TabIndex = 4
        radioManual.TabStop = True
        radioManual.Text = "Manual"
        radioManual.UseVisualStyleBackColor = True
        ' 
        ' radioLecture
        ' 
        radioLecture.AutoSize = True
        radioLecture.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        radioLecture.ForeColor = SystemColors.ControlDarkDark
        radioLecture.Location = New Point(273, 4)
        radioLecture.Name = "radioLecture"
        radioLecture.Size = New Size(68, 19)
        radioLecture.TabIndex = 5
        radioLecture.TabStop = True
        radioLecture.Text = "Lecture"
        radioLecture.UseVisualStyleBackColor = True
        ' 
        ' txtNote
        ' 
        txtNote.BackColor = Color.LightGray
        txtNote.BorderStyle = BorderStyle.None
        txtNote.ContextMenuStrip = ContextMenuStrip1
        txtNote.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point)
        txtNote.Location = New Point(258, 235)
        txtNote.Name = "txtNote"
        txtNote.Size = New Size(347, 20)
        txtNote.TabIndex = 6
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ControlLight
        Panel1.Controls.Add(radioPaper)
        Panel1.Controls.Add(radioBook)
        Panel1.Controls.Add(radioManual)
        Panel1.Controls.Add(radioLecture)
        Panel1.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point)
        Panel1.ForeColor = SystemColors.ControlDarkDark
        Panel1.Location = New Point(258, 94)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(347, 27)
        Panel1.TabIndex = 7
        ' 
        ' lblPath
        ' 
        lblPath.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        lblPath.ForeColor = Color.IndianRed
        lblPath.Location = New Point(3, 74)
        lblPath.Name = "lblPath"
        lblPath.Size = New Size(857, 14)
        lblPath.TabIndex = 8
        lblPath.Text = "Drop  ^"
        lblPath.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CheckAskDest
        ' 
        CheckAskDest.AutoSize = True
        CheckAskDest.Font = New Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point)
        CheckAskDest.ForeColor = Color.Navy
        CheckAskDest.Location = New Point(506, 269)
        CheckAskDest.Name = "CheckAskDest"
        CheckAskDest.Size = New Size(94, 15)
        CheckAskDest.TabIndex = 16
        CheckAskDest.Text = "sub-Folder"
        CheckAskDest.UseVisualStyleBackColor = True
        ' 
        ' lblExt
        ' 
        lblExt.AutoSize = True
        lblExt.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point)
        lblExt.ForeColor = Color.SlateBlue
        lblExt.Location = New Point(23, 125)
        lblExt.Name = "lblExt"
        lblExt.Size = New Size(10, 13)
        lblExt.TabIndex = 17
        lblExt.Text = "."
        lblExt.Visible = False
        ' 
        ' lblSize
        ' 
        lblSize.AutoSize = True
        lblSize.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point)
        lblSize.ForeColor = Color.SlateBlue
        lblSize.Location = New Point(23, 144)
        lblSize.Name = "lblSize"
        lblSize.Size = New Size(10, 13)
        lblSize.TabIndex = 18
        lblSize.Text = "."
        lblSize.Visible = False
        ' 
        ' lblCreated
        ' 
        lblCreated.AutoSize = True
        lblCreated.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point)
        lblCreated.ForeColor = Color.SlateBlue
        lblCreated.Location = New Point(23, 163)
        lblCreated.Name = "lblCreated"
        lblCreated.Size = New Size(10, 13)
        lblCreated.TabIndex = 19
        lblCreated.Text = "."
        lblCreated.Visible = False
        ' 
        ' lblModified
        ' 
        lblModified.AutoSize = True
        lblModified.Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point)
        lblModified.ForeColor = Color.SlateBlue
        lblModified.Location = New Point(23, 181)
        lblModified.Name = "lblModified"
        lblModified.Size = New Size(10, 13)
        lblModified.TabIndex = 20
        lblModified.Text = "."
        lblModified.Visible = False
        ' 
        ' RadiobtnOpen
        ' 
        RadiobtnOpen.AutoSize = True
        RadiobtnOpen.Font = New Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point)
        RadiobtnOpen.ForeColor = SystemColors.ControlDarkDark
        RadiobtnOpen.Location = New Point(362, 269)
        RadiobtnOpen.Name = "RadiobtnOpen"
        RadiobtnOpen.Size = New Size(51, 15)
        RadiobtnOpen.TabIndex = 21
        RadiobtnOpen.Text = "Open"
        RadiobtnOpen.UseVisualStyleBackColor = True
        ' 
        ' RadiobtnMove
        ' 
        RadiobtnMove.AutoSize = True
        RadiobtnMove.Font = New Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point)
        RadiobtnMove.ForeColor = SystemColors.ControlDarkDark
        RadiobtnMove.Location = New Point(434, 269)
        RadiobtnMove.Name = "RadiobtnMove"
        RadiobtnMove.Size = New Size(51, 15)
        RadiobtnMove.TabIndex = 22
        RadiobtnMove.Text = "Move"
        RadiobtnMove.UseVisualStyleBackColor = True
        ' 
        ' RadiobtnInspect
        ' 
        RadiobtnInspect.AutoSize = True
        RadiobtnInspect.Checked = True
        RadiobtnInspect.Font = New Font("Lucida Console", 8F, FontStyle.Regular, GraphicsUnit.Point)
        RadiobtnInspect.ForeColor = SystemColors.ControlDarkDark
        RadiobtnInspect.Location = New Point(269, 269)
        RadiobtnInspect.Name = "RadiobtnInspect"
        RadiobtnInspect.Size = New Size(72, 15)
        RadiobtnInspect.TabIndex = 23
        RadiobtnInspect.TabStop = True
        RadiobtnInspect.Text = "Inspect"
        RadiobtnInspect.UseVisualStyleBackColor = True
        ' 
        ' lblDestinationFolder
        ' 
        lblDestinationFolder.Font = New Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point)
        lblDestinationFolder.ForeColor = Color.Gray
        lblDestinationFolder.Location = New Point(0, 299)
        lblDestinationFolder.Name = "lblDestinationFolder"
        lblDestinationFolder.Size = New Size(843, 20)
        lblDestinationFolder.TabIndex = 24
        lblDestinationFolder.Text = "-"
        lblDestinationFolder.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmImportRefs
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(835, 308)
        ContextMenuStrip = ContextMenuStrip1
        ControlBox = False
        Controls.Add(lblDestinationFolder)
        Controls.Add(RadiobtnInspect)
        Controls.Add(RadiobtnMove)
        Controls.Add(RadiobtnOpen)
        Controls.Add(lblModified)
        Controls.Add(lblCreated)
        Controls.Add(lblSize)
        Controls.Add(lblExt)
        Controls.Add(CheckAskDest)
        Controls.Add(txtNote)
        Controls.Add(Panel1)
        Controls.Add(ListProduct)
        Controls.Add(lblPath)
        Controls.Add(txtTitle)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmImportRefs"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Import"
        ContextMenuStrip1.ResumeLayout(False)
        ContextMenuStrip2.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtTitle As TextBox
    Friend WithEvents ListProduct As ListBox
    Friend WithEvents radioPaper As RadioButton
    Friend WithEvents radioBook As RadioButton
    Friend WithEvents radioManual As RadioButton
    Friend WithEvents radioLecture As RadioButton
    Friend WithEvents txtNote As TextBox
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Menu2_Add As ToolStripMenuItem
    Friend WithEvents Menu2_Remove As ToolStripMenuItem
    Friend WithEvents Menu2_Clear As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu1_Select As ToolStripMenuItem
    Friend WithEvents Menu1_Paste As ToolStripMenuItem
    Friend WithEvents Menu1_Move As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu1_Exit As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lblPath As Label
    Friend WithEvents CheckAskDest As CheckBox
    Friend WithEvents lblExt As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents lblCreated As Label
    Friend WithEvents lblModified As Label
    Friend WithEvents RadiobtnOpen As RadioButton
    Friend WithEvents RadiobtnMove As RadioButton
    Friend WithEvents RadiobtnInspect As RadioButton
    Friend WithEvents lblDestinationFolder As Label
End Class
