<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChooseProject
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
        ListProj = New ListBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        Menu1_Active = New ToolStripMenuItem()
        Menu1_Inactive = New ToolStripMenuItem()
        Menu1_All = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        Menu1_OK = New ToolStripMenuItem()
        Menu1_Cancel = New ToolStripMenuItem()
        ListProd = New ListBox()
        ContextMenuStrip2 = New ContextMenuStrip(components)
        Menu2_OK = New ToolStripMenuItem()
        Menu2_Cancel = New ToolStripMenuItem()
        TextBoxProdNote = New TextBox()
        txtSearchProj = New TextBox()
        ContextMenuStrip1.SuspendLayout()
        ContextMenuStrip2.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListProj
        ' 
        ListProj.BackColor = SystemColors.ControlLight
        ListProj.BorderStyle = BorderStyle.None
        ListProj.ContextMenuStrip = ContextMenuStrip1
        ListProj.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        ListProj.FormattingEnabled = True
        ListProj.ItemHeight = 17
        ListProj.Location = New Point(12, 56)
        ListProj.Margin = New Padding(4)
        ListProj.Name = "ListProj"
        ListProj.Size = New Size(304, 340)
        ListProj.TabIndex = 0
        ListProj.TabStop = False
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Menu1_Active, Menu1_Inactive, Menu1_All, ToolStripMenuItem1, Menu1_OK, Menu1_Cancel})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(153, 120)
        ' 
        ' Menu1_Active
        ' 
        Menu1_Active.Checked = True
        Menu1_Active.CheckState = CheckState.Checked
        Menu1_Active.Name = "Menu1_Active"
        Menu1_Active.Size = New Size(152, 22)
        Menu1_Active.Text = "Active"
        ' 
        ' Menu1_Inactive
        ' 
        Menu1_Inactive.Name = "Menu1_Inactive"
        Menu1_Inactive.Size = New Size(152, 22)
        Menu1_Inactive.Text = "Inactive"
        ' 
        ' Menu1_All
        ' 
        Menu1_All.Name = "Menu1_All"
        Menu1_All.Size = New Size(152, 22)
        Menu1_All.Text = "All"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(149, 6)
        ' 
        ' Menu1_OK
        ' 
        Menu1_OK.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Menu1_OK.ForeColor = SystemColors.HotTrack
        Menu1_OK.Name = "Menu1_OK"
        Menu1_OK.Size = New Size(152, 22)
        Menu1_OK.Text = "Select Project"
        ' 
        ' Menu1_Cancel
        ' 
        Menu1_Cancel.ForeColor = Color.IndianRed
        Menu1_Cancel.Name = "Menu1_Cancel"
        Menu1_Cancel.Size = New Size(152, 22)
        Menu1_Cancel.Text = "Cancel"
        ' 
        ' ListProd
        ' 
        ListProd.BackColor = SystemColors.ControlLight
        ListProd.BorderStyle = BorderStyle.None
        ListProd.ContextMenuStrip = ContextMenuStrip2
        ListProd.Font = New Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        ListProd.FormattingEnabled = True
        ListProd.ItemHeight = 17
        ListProd.Location = New Point(335, 56)
        ListProd.Margin = New Padding(4)
        ListProd.Name = "ListProd"
        ListProd.Size = New Size(304, 340)
        ListProd.TabIndex = 1
        ListProd.TabStop = False
        ' 
        ' ContextMenuStrip2
        ' 
        ContextMenuStrip2.Items.AddRange(New ToolStripItem() {Menu2_OK, Menu2_Cancel})
        ContextMenuStrip2.Name = "ContextMenuStrip2"
        ContextMenuStrip2.Size = New Size(172, 48)
        ' 
        ' Menu2_OK
        ' 
        Menu2_OK.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Menu2_OK.ForeColor = SystemColors.HotTrack
        Menu2_OK.Name = "Menu2_OK"
        Menu2_OK.Size = New Size(171, 22)
        Menu2_OK.Text = "Select subProject"
        ' 
        ' Menu2_Cancel
        ' 
        Menu2_Cancel.ForeColor = Color.IndianRed
        Menu2_Cancel.Name = "Menu2_Cancel"
        Menu2_Cancel.Size = New Size(171, 22)
        Menu2_Cancel.Text = "Cancel"
        ' 
        ' TextBoxProdNote
        ' 
        TextBoxProdNote.BackColor = SystemColors.Control
        TextBoxProdNote.BorderStyle = BorderStyle.None
        TextBoxProdNote.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point)
        TextBoxProdNote.ForeColor = Color.Teal
        TextBoxProdNote.Location = New Point(13, 416)
        TextBoxProdNote.Margin = New Padding(4)
        TextBoxProdNote.Name = "TextBoxProdNote"
        TextBoxProdNote.Size = New Size(626, 14)
        TextBoxProdNote.TabIndex = 2
        TextBoxProdNote.TabStop = False
        TextBoxProdNote.TextAlign = HorizontalAlignment.Right
        ' 
        ' txtSearchProj
        ' 
        txtSearchProj.BackColor = SystemColors.ControlLight
        txtSearchProj.BorderStyle = BorderStyle.None
        txtSearchProj.Font = New Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point)
        txtSearchProj.ForeColor = Color.IndianRed
        txtSearchProj.Location = New Point(13, 13)
        txtSearchProj.Margin = New Padding(4)
        txtSearchProj.Name = "txtSearchProj"
        txtSearchProj.Size = New Size(626, 18)
        txtSearchProj.TabIndex = 0
        txtSearchProj.TextAlign = HorizontalAlignment.Center
        ' 
        ' frmChooseProject
        ' 
        AutoScaleDimensions = New SizeF(9F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        ClientSize = New Size(654, 440)
        ControlBox = False
        Controls.Add(txtSearchProj)
        Controls.Add(TextBoxProdNote)
        Controls.Add(ListProd)
        Controls.Add(ListProj)
        Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmChooseProject"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Choose a Project / subProject"
        ContextMenuStrip1.ResumeLayout(False)
        ContextMenuStrip2.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListProj As ListBox
    Friend WithEvents ListProd As ListBox
    Friend WithEvents TextBoxProdNote As TextBox
    Friend WithEvents txtSearchProj As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu1_Active As ToolStripMenuItem
    Friend WithEvents Menu1_Inactive As ToolStripMenuItem
    Friend WithEvents Menu1_All As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu1_Cancel As ToolStripMenuItem
    Friend WithEvents Menu1_OK As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Menu2_OK As ToolStripMenuItem
    Friend WithEvents Menu2_Cancel As ToolStripMenuItem
End Class
