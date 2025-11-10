Public Class frmRefAttributes
    Private Sub frmRefAttributes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '//show Attributes
        LabelRefTitle.Text = strRef
        TextBoxProductNote.Text = strProdNote
        TextBoxAssignmentNote.Text = strAssignNote
        TextBoxRefNote.Text = strRefNote
        'reset off all checkboxes
        CheckBoxPaper.Checked = False
        CheckBoxBook.Checked = False
        CheckBoxManual.Checked = False
        CheckBoxLecture.Checked = False
        CheckBoxImp1.Checked = False
        CheckBoxImp2.Checked = False
        CheckBoxImp3.Checked = False
        CheckBoxImR.Checked = False
        'Retval2: 1111-1111 {ImR.Imp3.Imp2.Imp1.Lect.Man.Book.Paper}
        If (Retval2 And 1) = 1 Then CheckBoxPaper.Checked = True
        If (Retval2 And 2) = 2 Then CheckBoxBook.Checked = True
        If (Retval2 And 4) = 4 Then CheckBoxManual.Checked = True
        If (Retval2 And 8) = 8 Then CheckBoxLecture.Checked = True
        If (Retval2 And 16) = 16 Then CheckBoxImp1.Checked = True
        If (Retval2 And 32) = 32 Then CheckBoxImp2.Checked = True
        If (Retval2 And 64) = 64 Then CheckBoxImp3.Checked = True
        If (Retval2 And 128) = 128 Then CheckBoxImR.Checked = True
    End Sub
    Private Sub TextBoxProductNote_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxProductNote.KeyDown
        Select Case e.KeyCode
            Case 13, 40
                TextBoxRefNote.Focus()
                e.SuppressKeyPress = True
        End Select
    End Sub
    Private Sub TextBoxRefNote_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxRefNote.KeyDown
        Select Case e.KeyCode
            Case 38
                TextBoxProductNote.Focus()
                e.SuppressKeyPress = True
            Case 13, 40
                TextBoxAssignmentNote.Focus()
                e.SuppressKeyPress = True
        End Select
    End Sub
    Private Sub TextBoxAssignmentNote_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxAssignmentNote.KeyDown
        Select Case e.KeyCode
            Case 38
                TextBoxRefNote.Focus()
                e.SuppressKeyPress = True
            Case 13
                Menu_Save_Click(sender, e)
                e.SuppressKeyPress = True
        End Select
    End Sub
    Private Sub Menu_Save_Click(sender As Object, e As EventArgs) Handles Menu_Save.Click
        '//show Attributes
        strProdNote = TextBoxProductNote.Text
        strAssignNote = TextBoxAssignmentNote.Text
        strRefNote = TextBoxRefNote.Text
        'Retval2: 1111-1111 {ImR.Imp3.Imp2.Imp1.Lect.Man.Book.Paper}
        Retval2 = 0
        If CheckBoxPaper.Checked = True Then Retval2 = (Retval2 Or 1)
        If CheckBoxBook.Checked = True Then Retval2 = (Retval2 Or 2)
        If CheckBoxManual.Checked = True Then Retval2 = (Retval2 Or 4)
        If CheckBoxLecture.Checked = True Then Retval2 = (Retval2 Or 8)
        If CheckBoxImp1.Checked = True Then Retval2 = (Retval2 Or 16)
        If CheckBoxImp2.Checked = True Then Retval2 = (Retval2 Or 32)
        If CheckBoxImp3.Checked = True Then Retval2 = (Retval2 Or 64)
        If CheckBoxImR.Checked = True Then Retval2 = (Retval2 Or 128)
        Retval1 = 1
        Me.Dispose()
    End Sub
    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        Retval1 = 0
        Me.Dispose()
    End Sub
End Class