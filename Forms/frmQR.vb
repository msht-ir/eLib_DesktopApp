Public Class frmQR
    Private Sub frmQR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PictureBox1.Image = Image.FromFile(strFilename)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        PictureBox1.Image = Nothing
        Me.Dispose()
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Menu_Exit_Click(sender, e)
    End Sub
End Class