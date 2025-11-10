<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductNotes
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
        Me.components = New System.ComponentModel.Container()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_UpdateDateTime = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtDatum = New System.Windows.Forms.MaskedTextBox()
        Me.MC1 = New System.Windows.Forms.MonthCalendar()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.SystemColors.Control
        Me.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNote.ContextMenuStrip = Me.ContextMenuStrip1
        Me.txtNote.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtNote.Location = New System.Drawing.Point(27, 55)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(416, 106)
        Me.txtNote.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Save, Me.Menu_UpdateDateTime, Me.ToolStripMenuItem1, Me.Menu_Cancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(171, 76)
        '
        'Menu_Save
        '
        Me.Menu_Save.Name = "Menu_Save"
        Me.Menu_Save.Size = New System.Drawing.Size(170, 22)
        Me.Menu_Save.Text = "Save"
        '
        'Menu_UpdateDateTime
        '
        Me.Menu_UpdateDateTime.Name = "Menu_UpdateDateTime"
        Me.Menu_UpdateDateTime.Size = New System.Drawing.Size(170, 22)
        Me.Menu_UpdateDateTime.Text = "Update Date/Time"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(167, 6)
        '
        'Menu_Cancel
        '
        Me.Menu_Cancel.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Cancel.Name = "Menu_Cancel"
        Me.Menu_Cancel.Size = New System.Drawing.Size(170, 22)
        Me.Menu_Cancel.Text = "Cancel"
        '
        'txtDatum
        '
        Me.txtDatum.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtDatum.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDatum.ContextMenuStrip = Me.ContextMenuStrip1
        Me.txtDatum.Font = New System.Drawing.Font("Courier New", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtDatum.ForeColor = System.Drawing.Color.IndianRed
        Me.txtDatum.Location = New System.Drawing.Point(134, 18)
        Me.txtDatum.Mask = "0000-00-00 . 00-00"
        Me.txtDatum.Name = "txtDatum"
        Me.txtDatum.Size = New System.Drawing.Size(200, 17)
        Me.txtDatum.TabIndex = 2
        Me.txtDatum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MC1
        '
        Me.MC1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MC1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.MC1.Location = New System.Drawing.Point(471, 8)
        Me.MC1.Name = "MC1"
        Me.MC1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MC1.RightToLeftLayout = True
        Me.MC1.ShowToday = False
        Me.MC1.TabIndex = 3
        Me.MC1.TabStop = False
        '
        'frmProductNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(858, 188)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.MC1)
        Me.Controls.Add(Me.txtDatum)
        Me.Controls.Add(Me.txtNote)
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductNotes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Note"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNote As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Save As ToolStripMenuItem
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents Menu_UpdateDateTime As ToolStripMenuItem
    Friend WithEvents txtDatum As MaskedTextBox
    Friend WithEvents MC1 As MonthCalendar
End Class
