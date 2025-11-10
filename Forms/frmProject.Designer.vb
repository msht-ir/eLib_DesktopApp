<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProject
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
        Panel1 = New Panel()
        txtProjectNote = New TextBox()
        CheckBoxActive = New CheckBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu_Save = New ToolStripMenuItem()
        Menu_Cancel = New ToolStripMenuItem()
        txtProjectName = New MaskedTextBox()
        Panel1.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Control
        Panel1.Controls.Add(txtProjectNote)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 73)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(571, 68)
        Panel1.TabIndex = 0
        Panel1.TabStop = True
        ' 
        ' txtProjectNote
        ' 
        txtProjectNote.BackColor = SystemColors.ControlLight
        txtProjectNote.BorderStyle = BorderStyle.None
        txtProjectNote.Location = New Point(60, 24)
        txtProjectNote.Name = "txtProjectNote"
        txtProjectNote.Size = New Size(456, 16)
        txtProjectNote.TabIndex = 1
        txtProjectNote.Text = "-"
        ' 
        ' CheckBoxActive
        ' 
        CheckBoxActive.AutoSize = True
        CheckBoxActive.Checked = True
        CheckBoxActive.CheckState = CheckState.Checked
        CheckBoxActive.Location = New Point(23, 43)
        CheckBoxActive.Name = "CheckBoxActive"
        CheckBoxActive.Size = New Size(59, 19)
        CheckBoxActive.TabIndex = 0
        CheckBoxActive.TabStop = False
        CheckBoxActive.Text = "Active"
        CheckBoxActive.UseVisualStyleBackColor = True
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu_Save, Menu_Cancel})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(111, 48)
        ' 
        ' Menu_Save
        ' 
        Menu_Save.Name = "Menu_Save"
        Menu_Save.Size = New Size(110, 22)
        Menu_Save.Text = "Save"
        ' 
        ' Menu_Cancel
        ' 
        Menu_Cancel.ForeColor = Color.IndianRed
        Menu_Cancel.Name = "Menu_Cancel"
        Menu_Cancel.Size = New Size(110, 22)
        Menu_Cancel.Text = "Cancel"
        ' 
        ' txtProjectName
        ' 
        txtProjectName.BackColor = SystemColors.Control
        txtProjectName.BorderStyle = BorderStyle.None
        txtProjectName.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtProjectName.ForeColor = SystemColors.ControlText
        txtProjectName.Location = New Point(23, 13)
        txtProjectName.Name = "txtProjectName"
        txtProjectName.Size = New Size(247, 20)
        txtProjectName.TabIndex = 0
        ' 
        ' frmProject
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlLight
        ClientSize = New Size(571, 141)
        ContextMenuStrip = ContextMenuStrip1
        ControlBox = False
        Controls.Add(txtProjectName)
        Controls.Add(CheckBoxActive)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmProject"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Project"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtProjectNote As TextBox
    Friend WithEvents CheckBoxActive As CheckBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Save As ToolStripMenuItem
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents txtProjectName As MaskedTextBox
End Class
