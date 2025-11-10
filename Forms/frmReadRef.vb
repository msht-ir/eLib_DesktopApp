Public Class frmReadRef
    Private Sub frmReadRef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox("id: " & intRef.ToString & " /Type: " & strRefType & " /Title: " & strRef & " /Note: " & strRefNote)
        If UserType <> "Admin" Then Menu_Delete.Enabled = False Else Menu_Delete.Enabled = True
        RefreshPathTable()
    End Sub
    Private Sub RefreshPathTable()
        Try
            DS.Tables("tblRefPaths").Clear()
            Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                CnnSS.Open()
                DASS = New SqlClient.SqlDataAdapter("SELECT FilePath, StorageSN FROM Paths WHERE StorageSN = '" & strClientSN & "' AND FilePath Like '%" & strRef & "%' ORDER BY FilePath;", CnnSS)
                DASS.Fill(DS, "tblRefPaths")
                CnnSS.Close()
            End Using
            ListPaths.DataSource = DS.Tables("tblRefPaths")
            ListPaths.DisplayMember = "FilePath"
            ListPaths.ValueMember = "FilePath"
            ListPaths.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub ListPaths_DoubleClick(sender As Object, e As EventArgs) Handles ListPaths.DoubleClick
        Menu_Read_Click(sender, e)
    End Sub
    Private Sub ListPaths_KeyDown(sender As Object, e As KeyEventArgs) Handles ListPaths.KeyDown
        Select Case e.KeyCode
            Case 13 : Menu_Read_Click(sender, e)
            Case 27 : Menu_Cancel_Click(sender, e)
            Case Else  'nothing
        End Select
    End Sub

    'MENU
    Private Sub Menu_Read_Click(sender As Object, e As EventArgs) Handles Menu_Read.Click
        If ListPaths.SelectedIndex = -1 Then
            ListPaths.Focus()
            Exit Sub
        End If
        strPath = ListPaths.Text
        Dim G As Long = Shell("RUNDLL32.EXE URL.DLL,FileProtocolHandler " & strPath, vbNormalFocus)
        Me.Dispose()
    End Sub
    Private Sub Menu_Edit_Click(sender As Object, e As EventArgs) Handles Menu_Edit.Click
        If ListPaths.SelectedIndex = -1 Then
            ListPaths.Focus()
            Exit Sub
        End If
        strPath = ListPaths.Text
        Retval3 = 1 'flag for Edit Ref (not NewImport!)
        Try
            strExt = Microsoft.VisualBasic.Right(strPath, 4)
            If Microsoft.VisualBasic.Left(strExt, 1) <> "." Then strExt = "." & strExt
            My.Computer.FileSystem.MoveFile(strPath, Microsoft.VisualBasic.Left(strPath, 3) & strRef & strExt, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
            Try '//Delete thisPath from tbl_Paths
                Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                    CnnSS.Open()
                    strSQL = "DELETE FROM Paths WHERE FilePath='" & strPath & "'"
                    Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmdx.CommandType = CommandType.Text
                    Dim ix As Integer = cmdx.ExecuteNonQuery()
                    CnnSS.Close()
                End Using
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            strPath = Microsoft.VisualBasic.Left(strPath, 3) & strRef & strExt 'Path of the Ref in Root Directory
            Me.Dispose()
            frmImportRefs.ShowDialog()
        Catch ex As Exception
            MsgBox("Selected Ref is NOT Accessible! Close teh Ref and Try Again", vbOKOnly, "eLib")
            Exit Sub
        End Try
    End Sub
    Private Sub Menu_Delete_Click(sender As Object, e As EventArgs) Handles Menu_Delete.Click
        '//Waiting ...
        If UserType <> "Admin" Then Exit Sub '//OK, already was disabled by Me.Load
        If ListPaths.SelectedIndex = -1 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("NOTICE: Delete Ref from Depository ? SURE ?", vbYesNo + vbDefaultButton2, "eLib")
        Select Case myansw
            Case vbNo
                Exit Sub
            Case vbYes
                Randomize()
                Dim strRndNumber As Integer = Trim(Str(CInt(Int((10000 * Rnd()) + 1001))))
                Dim strAnsw As String = InputBox("Enter this Code: " & strRndNumber, "Enter Code below to Proceed with Delete", "")
                If strAnsw <> strRndNumber Then
                    Exit Sub
                Else
                    '//Delete Ref!
                    strPath = ListPaths.Text
                    My.Computer.FileSystem.DeleteFile(strPath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
                    Try '//Delete thisPath from tbl_Paths
                        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                            CnnSS.Open()
                            strSQL = "DELETE FROM Paths WHERE FilePath='" & strPath & "'"
                            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmdx.CommandType = CommandType.Text
                            Dim ix As Integer = cmdx.ExecuteNonQuery()
                            CnnSS.Close()
                        End Using
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    'MsgBox(strPath & vbCrLf & vbCrLf & "Deleted!", vbOKOnly + vbInformation, "eLib")
                    RefreshPathTable()
                End If
        End Select
    End Sub
    Private Sub Menu_Locate_Click(sender As Object, e As EventArgs) Handles Menu_Locate.Click
        '//Locate
        If ListPaths.SelectedIndex = -1 Then Exit Sub
        strPath = ListPaths.Text
        Dim strTitle As String = strPath
lblNextBackslash:
        Dim intPosBackslash As Integer = 0
        intPosBackslash = InStr(1, strTitle, "\")
        If intPosBackslash <> 0 Then
            strTitle = Mid(strTitle, intPosBackslash + 1)
            GoTo lblNextBackslash
        End If
        strPath = Microsoft.VisualBasic.Left(strPath, Len(strPath) - Len(strTitle) - 1)
        Shell("explorer " & strPath, AppWinStyle.NormalFocus)
    End Sub
    Private Sub Menu_SaveACopy_Click(sender As Object, e As EventArgs) Handles Menu_SaveACopy.Click
        '//SaveACopy
        If ListPaths.SelectedIndex = -1 Then Exit Sub
        '//strFolderSaveACopy = ?
        strPath = ListPaths.Text
        '//Extract Filename
        Dim strTitle As String = strPath
lblNextBackslash:
        Dim intPosBackslash As Integer = 0
        intPosBackslash = InStr(1, strTitle, "\")
        If intPosBackslash <> 0 Then
            strTitle = Mid(strTitle, intPosBackslash + 1)
            GoTo lblNextBackslash
        End If
        'MsgBox(strPath & vbCrLf & strTitle & vbCrLf & strFolderSaveACopy)
        My.Computer.FileSystem.CopyFile(strPath, strFolderSaveACopy & "\" & strTitle, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
        Dim myansw As DialogResult = MsgBox("A Copy of Ref:" & vbCrLf & strTitle & vbCrLf & "Copied to:" & vbCrLf & strFolderSaveACopy & vbCrLf & vbCrLf & "Open Folder?", vbYesNo + vbQuestion + vbDefaultButton2, "eLib")
        Select Case myansw
            Case vbYes
                Menu_OpenSaveFolder_Click(sender, e)
            Case vbNo
        End Select
    End Sub
    Private Sub Menu_OpenSaveFolder_Click(sender As Object, e As EventArgs) Handles Menu_OpenSaveFolder.Click
        '//OpenSaveFolder
        '//strFolderSaveACopy = ?
        Dim G As Long = Shell("RUNDLL32.EXE URL.DLL,FileProtocolHandler " & strFolderSaveACopy, vbNormalFocus)
    End Sub
    Private Sub Menu_Email_Click(sender As Object, e As EventArgs) Handles Menu_Email.Click
        '//WAINTING ...
        '//Email
        'Dim strTo As String = "msht.ir@outlook.com"
        'Dim strSubject As String = "My Subject"
        'Dim strBody As String = "The Body of the message goes here"
        'Dim strMessage As String = "mailto:" & strTo & "?subject=" & strSubject & "&body=" & strBody
        'System.Diagnostics.Process.Start(strMessage)
    End Sub
    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        Me.Dispose()
    End Sub
End Class