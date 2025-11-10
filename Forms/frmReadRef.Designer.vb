<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReadRef
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
        ListPaths = New ListBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu_Read = New ToolStripMenuItem()
        Menu_Edit = New ToolStripMenuItem()
        Menu_Locate = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        Menu_SaveACopy = New ToolStripMenuItem()
        Menu_OpenSaveFolder = New ToolStripMenuItem()
        Menu_Email = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripSeparator()
        Menu_Delete = New ToolStripMenuItem()
        Menu_Cancel = New ToolStripMenuItem()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListPaths
        ' 
        ListPaths.BackColor = SystemColors.ControlLight
        ListPaths.BorderStyle = BorderStyle.None
        ListPaths.ContextMenuStrip = ContextMenuStrip1
        ListPaths.Dock = DockStyle.Fill
        ListPaths.Font = New Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point)
        ListPaths.ForeColor = Color.IndianRed
        ListPaths.FormattingEnabled = True
        ListPaths.ItemHeight = 17
        ListPaths.Location = New Point(0, 0)
        ListPaths.Name = "ListPaths"
        ListPaths.Size = New Size(1201, 76)
        ListPaths.TabIndex = 0
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu_Read, Menu_Edit, Menu_Locate, ToolStripMenuItem1, Menu_SaveACopy, Menu_OpenSaveFolder, Menu_Email, ToolStripMenuItem3, Menu_Delete, Menu_Cancel})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(148, 192)
        ' 
        ' Menu_Read
        ' 
        Menu_Read.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Menu_Read.ForeColor = SystemColors.HotTrack
        Menu_Read.Name = "Menu_Read"
        Menu_Read.Size = New Size(147, 22)
        Menu_Read.Text = "Read ..."
        ' 
        ' Menu_Edit
        ' 
        Menu_Edit.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Menu_Edit.ForeColor = Color.DarkGoldenrod
        Menu_Edit.Name = "Menu_Edit"
        Menu_Edit.Size = New Size(147, 22)
        Menu_Edit.Text = "Edit ..."
        ' 
        ' Menu_Locate
        ' 
        Menu_Locate.Name = "Menu_Locate"
        Menu_Locate.Size = New Size(147, 22)
        Menu_Locate.Text = "Locate"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(144, 6)
        ' 
        ' Menu_SaveACopy
        ' 
        Menu_SaveACopy.Name = "Menu_SaveACopy"
        Menu_SaveACopy.Size = New Size(147, 22)
        Menu_SaveACopy.Text = "Save a Copy"
        ' 
        ' Menu_OpenSaveFolder
        ' 
        Menu_OpenSaveFolder.Name = "Menu_OpenSaveFolder"
        Menu_OpenSaveFolder.Size = New Size(147, 22)
        Menu_OpenSaveFolder.Text = "SaveAs Folder"
        ' 
        ' Menu_Email
        ' 
        Menu_Email.Enabled = False
        Menu_Email.Name = "Menu_Email"
        Menu_Email.Size = New Size(147, 22)
        Menu_Email.Text = "Email"
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(144, 6)
        ' 
        ' Menu_Delete
        ' 
        Menu_Delete.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Menu_Delete.ForeColor = Color.IndianRed
        Menu_Delete.Name = "Menu_Delete"
        Menu_Delete.Size = New Size(147, 22)
        Menu_Delete.Text = "Delete"
        ' 
        ' Menu_Cancel
        ' 
        Menu_Cancel.ForeColor = Color.IndianRed
        Menu_Cancel.Name = "Menu_Cancel"
        Menu_Cancel.Size = New Size(147, 22)
        Menu_Cancel.Text = "Exit"
        ' 
        ' frmReadRef
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(1201, 76)
        ContextMenuStrip = ContextMenuStrip1
        ControlBox = False
        Controls.Add(ListPaths)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmReadRef"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "DblClick to READ"
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ListPaths As ListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Read As ToolStripMenuItem
    Friend WithEvents Menu_SaveACopy As ToolStripMenuItem
    Friend WithEvents Menu_OpenSaveFolder As ToolStripMenuItem
    Friend WithEvents Menu_Edit As ToolStripMenuItem
    Friend WithEvents Menu_Delete As ToolStripMenuItem
    Friend WithEvents Menu_Locate As ToolStripMenuItem
    Friend WithEvents Menu_Email As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
End Class
