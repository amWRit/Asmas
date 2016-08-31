Imports System.Data
Imports System.Data.OleDb
Public Class addSchoolForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim shortName = shortnameTextBox.Text
        Dim fullName = fullnameTextBox.Text
        Dim address = addressTextBox.Text
        Dim estd = estdTextBox.Text
        Dim email = emailTextBox.Text
        Dim phone = phoneTextBox.Text
        Dim website = websiteTextBox.Text
        Dim desc = descTextBox.Text

        Dim present As Boolean
        present = checkIfPresent(shortName)

        If present = True Then
            MessageBox.Show("A school with same short_name is already present. Please check.", "Duplicate record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim DS = New DataSet

        Try
            Dim roleSQL = "INSERT INTO [school] ([short_name],[full_name],[address],[estd_date],[email],[phone],[website],[description]) 
                            VALUES 
                            (@shortName, @fullName, @address, @estd, @email, @phone, @website, @desc)"
            Con.Open()
            Dim cmd As New OleDbCommand(roleSQL, Con)
            cmd.Parameters.AddWithValue("@shortName", shortName)
            cmd.Parameters.AddWithValue("@fullName", fullName)
            cmd.Parameters.AddWithValue("@address", address)
            cmd.Parameters.AddWithValue("@estd", estd)
            cmd.Parameters.AddWithValue("@email", email)
            cmd.Parameters.AddWithValue("@phone", phone)
            cmd.Parameters.AddWithValue("@website", website)
            cmd.Parameters.AddWithValue("@desc", desc)
            cmd.ExecuteNonQuery()

            MsgBox("School successfully added.", MsgBoxStyle.Information, "ADDED")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Public Function checkIfPresent(shortName As String) As Boolean
        Dim present As Boolean = False

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            Dim oData As OleDbDataAdapter
            SQL = "SELECT * from school where short_name='" & shortName & "'"
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

    Private Sub addSchoolForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub
End Class