Public Class Report
    Private Sub Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TerseDataSet.user' table. You can move, or remove it, as needed.
        Me.userTableAdapter.Fill(Me.TerseDataSet.user)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class