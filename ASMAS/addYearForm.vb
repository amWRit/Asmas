Imports System.Data
Imports System.Data.OleDb

Public Class addYearForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Private Sub addYearForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim schoolSQL As String = "SELECT distinct [short_name] from [school]"

        'ROLE COMBOBOX
        Con.Open() 'Open connection
        Dim schoolData As OleDbDataAdapter
        schoolData = New OleDbDataAdapter(schoolSQL, Con)
        Con.Close()
        schoolData.Fill(DS)
        Dim rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            schoolCombo.Items.Add(Val)
        Next
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim schoolName = schoolCombo.Text
        Dim yearName = yearTextBox.Text
        Dim schoolID As Integer
        Dim schoolIDsql = "SELECT school_id FROM [school] where [short_name]='" & schoolName & "'"
        Dim DS = New DataSet

        Con.Open() 'Open connection
        Dim schoolData As OleDbDataAdapter
        schoolData = New OleDbDataAdapter(schoolIDsql, Con)
        Con.Close()
        schoolData.Fill(DS)
        schoolID = CInt(DS.Tables(0).Rows(0)(0))

        Try
            Dim roleSQL = "INSERT INTO [school_year] ([year_num],[school_id]) VALUES (@yearNum, @schoolID)"
            Con.Open()
            Dim cmd As New OleDbCommand(roleSQL, Con)
            cmd.Parameters.AddWithValue("@yearNum", yearName)
            cmd.Parameters.AddWithValue("@schoolID", schoolID)

            cmd.ExecuteNonQuery()

            MsgBox("Year successfully created for " & schoolName & ".", MsgBoxStyle.Information, "ADDED")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
        HomeForm.Show()
    End Sub

    Private Sub addYearForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub
End Class