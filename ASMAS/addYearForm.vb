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

        Dim present As Boolean
        present = checkIfPresent(yearName)

        If present = True Then
            MessageBox.Show("The year you entered is already present. Please check.", "Duplicate record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

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

    Public Function checkIfPresent(yearName As String) As Boolean
        Dim present As Boolean = False

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            Dim oData As OleDbDataAdapter
            SQL = "SELECT * from school_year where year_num='" & yearName & "'"
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            DS.Tables.Clear()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count
            If rowCount > 0 Then present = True
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try

        Return present
    End Function

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