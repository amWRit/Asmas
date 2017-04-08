Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration

Public Class splash

    Private user_name As String
    Dim mypassword As String = ""
    Private pwd As String

    Private data_source_path As String = DBConnection.data_source_path
    Dim connectionString As String = DBConnection.connectionString
    Dim con As New OleDbConnection
    'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb ;Jet OLEDB:Database Password= & mypassword")
    Dim cmd As New OleDbCommand

    Private Sub splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = ProgressBar1.Value + 5
        labelCounter.Text = CType(ProgressBar1.Value, String)
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Enabled = False
            Me.Hide()

            ' An arbitrary number to identify this program.
            Const program_id As UInt32 = 2267918298
            'check registration
            'If (Not Registration.IsRegistered(program_id, False)) Then Me.Close()



            Dim firstTime As String = ""
            firstTime = checkIfFirstTime()
            If firstTime = "Yes" Then
                'prompt to create an admin user
                createAdminForm.Show()

            Else
                LoginForm1.Show()
            End If


        End If
    End Sub

    Private Function checkIfFirstTime() As String
        Dim firstTime As String = ""

        con = New OleDbConnection(connectionString)

        Dim sql = "SELECT * FROM firstTimeCheck"

        Try
            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(sql, con)
            oData.Fill(DS)

            firstTime = DS.Tables(0).Rows(0).Item("first_time").ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return firstTime
    End Function


End Class
