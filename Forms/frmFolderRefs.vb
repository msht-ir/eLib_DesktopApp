Public Class frmFolderRefs
    Private Sub frmFolderRefs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '//in module: Public DestinationFolder As String = ""
        Menu_SubFolders.Checked = False
        DestinationFolder = Application.StartupPath 'OR: Environment.SpecialFolder.Desktop
        lblPath.Text = "-"
    End Sub
    Private Sub Menu_SelectFolder_Click(sender As Object, e As EventArgs) Handles Menu_SelectFolder.Click
        FolderBrowserDialog1.SelectedPath = DestinationFolder   'OR Environment.SpecialFolder.Desktop
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            DestinationFolder = FolderBrowserDialog1.SelectedPath & "\"
            ScanFolder(DestinationFolder)
        Else
            Exit Sub
        End If
    End Sub
    Private Sub Menu_SubFolders_Click(sender As Object, e As EventArgs) Handles Menu_SubFolders.Click
        Select Case Menu_SubFolders.Checked
            Case True : Menu_SubFolders.Checked = False
            Case False : Menu_SubFolders.Checked = True
        End Select
        'refresh the List
        ScanFolder(DestinationFolder)
    End Sub
    Public Sub ScanFolder(strFolderName As String)
        ListPaths.Items.Clear()
        lblPath.Text = DestinationFolder
        Dim boolSubFolder As Boolean = Menu_SubFolders.Checked
        '//EXTRACT FileNames : DIR (/s) >> text files
        Select Case boolSubFolder
            Case True
                Dim tmpArg As String = "/C Dir """ & strFolderName & """ /s > " & Application.StartupPath & "eLibF.txt"
                Process.Start("cmd.exe", tmpArg).WaitForExit()
            Case False
                Dim tmpArg As String = "/C Dir """ & strFolderName & """ > " & Application.StartupPath & "eLibF.txt"
                Process.Start("cmd.exe", tmpArg).WaitForExit()
                'Process.Start("cmd.exe", "/C Dir '" & strFolderName & "' > " & Application.StartupPath & "eLibF.txt").WaitForExit()
        End Select
        '//Extract lines of interest out of textfiles!
        Dim strLine As String = ""
        Dim strName As String = ""
        Try
            FileOpen(1, Application.StartupPath & "eLibF.txt", OpenMode.Input)
            'strLine = LineInput(1)
            'strLine = LineInput(1)
            While Not EOF(1)
                strLine = Trim(LineInput(1))
                If Len(strLine) < 40 Then GoTo Lblx
                If (strLine = "") Or (InStr(1, strLine, "<DIR>") <> 0) Or (InStr(1, strLine, "Directory Of") <> 0) Or (InStr(1, strLine, "File(s) ") <> 0) Or (InStr(1, strLine, "Total Files Listed:") <> 0) Or (InStr(1, strLine, "Dir(s) ") <> 0) Then GoTo Lblx
                If InStr(1, strLine, "\") <> 0 Then GoTo Lblx
                strName = Mid(strLine, 40, Len(strLine) - 39)
                strName = RemoveExtension(strName)
                If Len(strName) > 8 Then
                    ListPaths.Items.Add(strName)
                End If
Lblx:
            End While
            FileClose(1)
        Catch ex As Exception
            FileClose(1)
            MsgBox("//Error//:   " & vbCrLf & strName & vbCrLf & ex.ToString)
        End Try
        '//Delete temporary files
        If Dir(Application.StartupPath & "eLibF.txt") <> "" Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "eLibF.txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
        If Dir(Application.StartupPath & "eLibFx.txt") <> "" Then My.Computer.FileSystem.DeleteFile(Application.StartupPath & "eLibFx.txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.ThrowException)
    End Sub
    Private Sub Menu_Inverse_Click(sender As Object, e As EventArgs) Handles Menu_Inverse.Click
        For i As Integer = 0 To ListPaths.Items.Count - 1
            If ListPaths.GetItemChecked(i) = True Then
                ListPaths.SetItemChecked(i, False)
            Else
                ListPaths.SetItemChecked(i, True)
            End If
        Next i
    End Sub
    Private Sub Menu_None_Click(sender As Object, e As EventArgs) Handles Menu_None.Click
        For i As Integer = 0 To ListPaths.Items.Count - 1
            ListPaths.SetItemChecked(i, False)
        Next i
    End Sub
    Private Sub Menu_CopyTitle_Click(sender As Object, e As EventArgs) Handles Menu_CopyTitle.Click
        If ListPaths.SelectedIndex >= 0 Then
            My.Computer.Clipboard.SetText(ListPaths.Text)
        End If
    End Sub
    Private Sub Menu_Read_Click(sender As Object, e As EventArgs) Handles Menu_Read.Click
        If ListPaths.SelectedIndex >= 0 Then
            strRef = Trim(ListPaths.Text)
            If strRef <> "" Then frmReadRef.ShowDialog()
        End If
    End Sub
    Private Sub Menu_Assign_Click(sender As Object, e As EventArgs) Handles Menu_Assign.Click
        '//Do Assign checked Items
        'intRef = ListPaths.SelectedValue
        Dim tmpCNT As Integer = ListPaths.CheckedItems.Count
        If tmpCNT = 0 Then
            MsgBox("No item is selected!", vbOKOnly, "eLib")
            Exit Sub
        End If
        tmpCNT = 0 'use as a counter
        Dim strItem As String = ""
        frmChooseProject.ShowDialog()
        If Retval1 = 2 Then '//2: A Product is selected from dialog //intProd=id of the selected Product
            If intProd < 1 Then Exit Sub
            For i As Integer = 0 To ListPaths.Items.Count - 1
                If ListPaths.GetItemChecked(i) = True Then
                    strItem = ListPaths.Items(i).ToString
                    Dim intRefId As Integer = FindRefId(strItem)
                    If intRefId > 0 Then
                        Dim k As Integer
                        k = DoAssignRefToProduct(intRefId, intProd)
                        If k = 1 Then
                            lblPath.Text = "Assigned:  " & strItem
                            tmpCNT = tmpCNT + 1
                        End If
                    End If
                End If
            Next i
            lblPath.Text = "Assigned Refs:  " & tmpCNT.ToString
        End If
    End Sub
    Private Function FindRefId(strTitle As String) As Integer
        '//Find ID of a Ref in tblPapers
        DS.Tables("tblRefs1").Clear()
        Dim Fltr As String = "PaperName='" & strTitle & "'"
        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
            CnnSS.Open()
            DASS = New SqlClient.SqlDataAdapter("SELECT Distinct Papers.ID, PaperName, IsPaper, IsBook, IsManual, IsLecture, Papers.Note FROM [Paper_Product] RIGHT JOIN Papers ON [Paper_Product].Paper_ID = Papers.ID  WHERE (" + Fltr + ") ORDER BY Papers.ID DESC;", CnnSS)
            DASS.Fill(DS, "tblRefs1")
            CnnSS.Close()
        End Using
        FindRefId = DS.Tables("tblRefs1").Rows(0).Item(0)
    End Function
    Private Function DoAssignRefToProduct(iRef As Integer, iProd As Integer) As Integer
        strSQL = "INSERT INTO Paper_Product (Paper_ID, Product_ID) VALUES (@paperid, @productid)"
        DoAssignRefToProduct = 1
        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
            CnnSS.Open()
            Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
            cmdx.CommandType = CommandType.Text
            cmdx.Parameters.AddWithValue("@paperid", iRef.ToString)
            cmdx.Parameters.AddWithValue("@productid", iProd.ToString)
            Try
                Dim ix As Integer = cmdx.ExecuteNonQuery()
            Catch ex As Exception
                DoAssignRefToProduct = 0
                MsgBox(ex.ToString)
            End Try
            CnnSS.Close()
        End Using
    End Function
    Private Sub Menu2_LastVisited_Click(sender As Object, e As EventArgs) Handles Menu2_LastVisited.Click
        ScanFolder(DestinationFolder)
    End Sub
    Private Sub Menu2_Papers_Click(sender As Object, e As EventArgs) Handles Menu2_Papers.Click
        DestinationFolder = strFolderPapers & "\"
        ScanFolder(strFolderPapers)
    End Sub
    Private Sub Menu2_Books_Click(sender As Object, e As EventArgs) Handles Menu2_Books.Click
        DestinationFolder = strFolderBooks & "\"
        ScanFolder(strFolderBooks)
    End Sub
    Private Sub Menu2_Manuals_Click(sender As Object, e As EventArgs) Handles Menu2_Manuals.Click
        DestinationFolder = strFolderManuals & "\"
        ScanFolder(strFolderManuals)
    End Sub
    Private Sub Menu2_Lectures_Click(sender As Object, e As EventArgs) Handles Menu2_Lectures.Click
        DestinationFolder = strFolderLectures & "\"
        ScanFolder(strFolderLectures)
    End Sub
    Private Sub lblPath_Click(sender As Object, e As EventArgs) Handles lblPath.Click
        Menu_SelectFolder_Click(sender, e)
    End Sub
    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        Me.Dispose()
    End Sub


End Class