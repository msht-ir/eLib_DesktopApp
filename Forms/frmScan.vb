Public Class frmScan
    Private Sub frmScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckFolders()
        RefreshFolderPathLabels()
    End Sub
    Private Sub lblStatus_Click(sender As Object, e As EventArgs) Handles lblStatus.Click
        CheckFolders()
    End Sub
    Private Sub CheckFolders()
        If ValidateFolders() = "valid" Then
            lblStatus.Text = "P A T H S    V A L I D"
        Else
            lblStatus.Text = "C H E C K   F O L D E R    P A T H S"
        End If
    End Sub
    Private Sub RefreshFolderPathLabels()
        lblFolderPapers.Text = strFolderPapers
        lblFolderBooks.Text = strFolderBooks
        lblFolderManuals.Text = strFolderManuals
        lblFolderLectures.Text = strFolderLectures
        lblFolderSaveACopy.Text = strFolderSaveACopy
    End Sub
    '//Clicks
    Private Sub lbl_P_Click(sender As Object, e As EventArgs) Handles lbl_P.Click
        strFolderPapers = GeteLibFolderPath(strFolderPapers)
        SaveFolderAddress2DB("P", strFolderPapers)
        RefreshFolderPathLabels()
    End Sub
    Private Sub lbl_B_Click(sender As Object, e As EventArgs) Handles lbl_B.Click
        strFolderBooks = GeteLibFolderPath(strFolderBooks)
        SaveFolderAddress2DB("B", strFolderBooks)
        RefreshFolderPathLabels()
    End Sub
    Private Sub lbl_M_Click(sender As Object, e As EventArgs) Handles lbl_M.Click
        strFolderManuals = GeteLibFolderPath(strFolderManuals)
        SaveFolderAddress2DB("M", strFolderManuals)
        RefreshFolderPathLabels()
    End Sub
    Private Sub lbl_L_Click(sender As Object, e As EventArgs) Handles lbl_L.Click
        strFolderLectures = GeteLibFolderPath(strFolderLectures)
        SaveFolderAddress2DB("L", strFolderLectures)
        RefreshFolderPathLabels()
    End Sub
    Private Sub lbl_S_Click(sender As Object, e As EventArgs) Handles lbl_S.Click
        strFolderSaveACopy = GeteLibFolderPath(strFolderSaveACopy)
        SaveFolderAddress2DB("S", strFolderSaveACopy)
        RefreshFolderPathLabels()
    End Sub

    Function GeteLibFolderPath(strFldr As String) As String
        FolderBrowserDialog1.SelectedPath = strFldr 'Application.StartupPath 
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            GeteLibFolderPath = FolderBrowserDialog1.SelectedPath
        Else
            Dim strNewPath As String = InputBox("Enter new folder path :", "Settings", strFldr)
            If Len(strNewPath) > 2 Then
                GeteLibFolderPath = strNewPath
            Else
                GeteLibFolderPath = "not available!"
            End If
        End If
    End Function

    '//Save Folder_address
    Private Sub SaveFolderAddress2DB(FldrType As String, strFldrPath As String)
        Select Case FldrType
            Case "P" : strSQL = "UPDATE Usrs SET FolderPapers = @sttvalue WHERE ID = @ID"
            Case "B" : strSQL = "UPDATE Usrs SET FolderBooks = @sttvalue WHERE ID = @ID"
            Case "M" : strSQL = "UPDATE Usrs SET FolderManuals = @sttvalue WHERE ID = @ID"
            Case "L" : strSQL = "UPDATE Usrs SET FolderLectures = @sttvalue WHERE ID = @ID"
            Case "S" : strSQL = "UPDATE Usrs SET FolderSaveACopy = @sttvalue WHERE ID = @ID"
        End Select
        Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
            CnnSS.Open()
            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
            cmd.CommandType = CommandType.Text
            cmd.Parameters.AddWithValue("@sttvalue", strFldrPath)
            cmd.Parameters.AddWithValue("@ID", intUser.ToString)
            Dim i As Integer = cmd.ExecuteNonQuery()
            CnnSS.Close()
        End Using
        CheckFolders()
    End Sub

    '//SCAN
    Private Sub Menu_Scan_Click(sender As Object, e As EventArgs) Handles Menu_Scan.Click
        '//Do Scan
        If ValidateFolders() = "valid" Then
            lblStatus.Text = "Step 1/3 : Clear current file Paths . . ."
            Using CnnSS = New SqlClient.SqlConnection(strDatabaseCNNstring)
                CnnSS.Open()
                Clear_eLibPapersInfo("Paths")
                CnnSS.Close()
            End Using
            lblStatus.Text = "Step 2/3 : Scan eLib Folders . . ."
            eLibScanNames() 'equals eLibTitles in old eLib versions
            lblStatus.Text = "Step 3/3 : Constructing new file Paths  . . ."
            eLibScanPaths() 'equals eLibPaths in old eLib versions
            lblStatus.Text = "SCAN finished successfully!"
            ReadSettingsAndUsers()
            Menu_Exit_Click(sender, e)
        Else
            Exit Sub
        End If
    End Sub
    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        Me.Dispose()
        frmAssign.ShowDialog()
    End Sub

End Class