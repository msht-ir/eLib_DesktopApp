<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFolderRefs
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
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu_SelectFolder = New ToolStripMenuItem()
        Menu_Read = New ToolStripMenuItem()
        Menu_Assign = New ToolStripMenuItem()
        Menu_CopyTitle = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripSeparator()
        Menu_SubFolders = New ToolStripMenuItem()
        Menu_Inverse = New ToolStripMenuItem()
        Menu_None = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        Menu_Exit = New ToolStripMenuItem()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        lblPath = New Label()
        ContextMenuStrip2 = New ContextMenuStrip(components)
        Menu2_Papers = New ToolStripMenuItem()
        Menu2_Books = New ToolStripMenuItem()
        Menu2_Manuals = New ToolStripMenuItem()
        Menu2_Lectures = New ToolStripMenuItem()
        ToolStripMenuItem4 = New ToolStripSeparator()
        Menu2_LastVisited = New ToolStripMenuItem()
        ListPaths = New CheckedListBox()
        ContextMenuStrip1.SuspendLayout()
        ContextMenuStrip2.SuspendLayout()
        SuspendLayout()
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu_SelectFolder, Menu_Read, Menu_Assign, Menu_CopyTitle, ToolStripMenuItem2, Menu_SubFolders, Menu_Inverse, Menu_None, ToolStripMenuItem1, Menu_Exit})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(158, 192)
        ' 
        ' Menu_SelectFolder
        ' 
        Menu_SelectFolder.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Menu_SelectFolder.ForeColor = Color.SeaGreen
        Menu_SelectFolder.Name = "Menu_SelectFolder"
        Menu_SelectFolder.Size = New Size(157, 22)
        Menu_SelectFolder.Text = "Select Folder ..."
        ' 
        ' Menu_Read
        ' 
        Menu_Read.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Menu_Read.ForeColor = SystemColors.HotTrack
        Menu_Read.Name = "Menu_Read"
        Menu_Read.Size = New Size(157, 22)
        Menu_Read.Text = "Read"
        ' 
        ' Menu_Assign
        ' 
        Menu_Assign.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Menu_Assign.ForeColor = Color.SeaGreen
        Menu_Assign.Name = "Menu_Assign"
        Menu_Assign.Size = New Size(157, 22)
        Menu_Assign.Text = "Assign ..."
        ' 
        ' Menu_CopyTitle
        ' 
        Menu_CopyTitle.Name = "Menu_CopyTitle"
        Menu_CopyTitle.Size = New Size(157, 22)
        Menu_CopyTitle.Text = "Copy title"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(154, 6)
        ' 
        ' Menu_SubFolders
        ' 
        Menu_SubFolders.Checked = True
        Menu_SubFolders.CheckState = CheckState.Checked
        Menu_SubFolders.Name = "Menu_SubFolders"
        Menu_SubFolders.Size = New Size(157, 22)
        Menu_SubFolders.Text = "Subfolders"
        ' 
        ' Menu_Inverse
        ' 
        Menu_Inverse.Name = "Menu_Inverse"
        Menu_Inverse.Size = New Size(157, 22)
        Menu_Inverse.Text = "Inverse"
        ' 
        ' Menu_None
        ' 
        Menu_None.Name = "Menu_None"
        Menu_None.Size = New Size(157, 22)
        Menu_None.Text = "None"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(154, 6)
        ' 
        ' Menu_Exit
        ' 
        Menu_Exit.ForeColor = Color.IndianRed
        Menu_Exit.Name = "Menu_Exit"
        Menu_Exit.Size = New Size(157, 22)
        Menu_Exit.Text = "Exit"
        ' 
        ' lblPath
        ' 
        lblPath.ContextMenuStrip = ContextMenuStrip2
        lblPath.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point)
        lblPath.ForeColor = SystemColors.ActiveCaption
        lblPath.Location = New Point(12, 6)
        lblPath.Name = "lblPath"
        lblPath.Size = New Size(1194, 15)
        lblPath.TabIndex = 2
        lblPath.Text = "-"
        lblPath.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ContextMenuStrip2
        ' 
        ContextMenuStrip2.Items.AddRange(New ToolStripItem() {Menu2_Papers, Menu2_Books, Menu2_Manuals, Menu2_Lectures, ToolStripMenuItem4, Menu2_LastVisited})
        ContextMenuStrip2.Name = "ContextMenuStrip2"
        ContextMenuStrip2.Size = New Size(130, 120)
        ' 
        ' Menu2_Papers
        ' 
        Menu2_Papers.Name = "Menu2_Papers"
        Menu2_Papers.Size = New Size(129, 22)
        Menu2_Papers.Text = "Papers"
        ' 
        ' Menu2_Books
        ' 
        Menu2_Books.Name = "Menu2_Books"
        Menu2_Books.Size = New Size(129, 22)
        Menu2_Books.Text = "Books"
        ' 
        ' Menu2_Manuals
        ' 
        Menu2_Manuals.Name = "Menu2_Manuals"
        Menu2_Manuals.Size = New Size(129, 22)
        Menu2_Manuals.Text = "Manuals"
        ' 
        ' Menu2_Lectures
        ' 
        Menu2_Lectures.Name = "Menu2_Lectures"
        Menu2_Lectures.Size = New Size(129, 22)
        Menu2_Lectures.Text = "Lectures"
        ' 
        ' ToolStripMenuItem4
        ' 
        ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        ToolStripMenuItem4.Size = New Size(126, 6)
        ' 
        ' Menu2_LastVisited
        ' 
        Menu2_LastVisited.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Menu2_LastVisited.ForeColor = SystemColors.HotTrack
        Menu2_LastVisited.Name = "Menu2_LastVisited"
        Menu2_LastVisited.Size = New Size(129, 22)
        Menu2_LastVisited.Text = "Last folder"
        ' 
        ' ListPaths
        ' 
        ListPaths.BackColor = SystemColors.Control
        ListPaths.BorderStyle = BorderStyle.None
        ListPaths.ContextMenuStrip = ContextMenuStrip1
        ListPaths.Font = New Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point)
        ListPaths.FormattingEnabled = True
        ListPaths.Location = New Point(12, 30)
        ListPaths.Name = "ListPaths"
        ListPaths.Size = New Size(1218, 440)
        ListPaths.TabIndex = 3
        ' 
        ' frmFolderRefs
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(1244, 503)
        ControlBox = False
        Controls.Add(ListPaths)
        Controls.Add(lblPath)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmFolderRefs"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Folder Refs"
        ContextMenuStrip1.ResumeLayout(False)
        ContextMenuStrip2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Assign As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_Inverse As ToolStripMenuItem
    Friend WithEvents Menu_None As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents Menu_SubFolders As ToolStripMenuItem
    Friend WithEvents Menu_SelectFolder As ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lblPath As Label
    Friend WithEvents ListPaths As CheckedListBox
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Menu2_Papers As ToolStripMenuItem
    Friend WithEvents Menu2_Books As ToolStripMenuItem
    Friend WithEvents Menu2_Manuals As ToolStripMenuItem
    Friend WithEvents Menu2_Lectures As ToolStripMenuItem
    Friend WithEvents Menu2_LastVisited As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents Menu_Read As ToolStripMenuItem
    Friend WithEvents Menu_CopyTitle As ToolStripMenuItem
End Class
