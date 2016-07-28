Public Class splash
    Private Sub splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = ProgressBar1.Value + 5
        labelCounter.Text = CType(ProgressBar1.Value, String)
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Enabled = False
            Me.Hide()
            LoginForm1.Show()
        End If
    End Sub

    Private Sub label1_Click(sender As Object, e As EventArgs) Handles label1.Click

    End Sub
End Class
