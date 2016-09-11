Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration

Public Class LoginForm1
    Private user_name As String
    Dim mypassword As String = ""
    Private pwd As String

    Private data_source_path As String = DBConnection.data_source_path
    Dim connectionString As String = DBConnection.connectionString
    Dim con As New OleDbConnection
    'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb ;Jet OLEDB:Database Password= & mypassword")
    Dim cmd As New OleDbCommand

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        usernameError.Text = ""
        passwordError.Text = ""
        user_name = username.Text
        pwd = password.Text

        ' Check if username is empty
        If user_name = "" Then
            usernameError.Text = "Please enter a username."
        End If
        ' Check if password is empty
        If pwd = "" Then
            passwordError.Text = "Please enter password."
        End If

        'Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        con = New OleDbConnection(connectionString)

        Dim sql = "SELECT * FROM [user] WHERE user_name='" & user_name & "' AND user_password='" & pwd & "'"

        cmd = New OleDbCommand(sql, con)
        con.Open()
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Try
            If dr.Read = False Then
                MessageBox.Show("Authentication failed! Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'MessageBox.Show("Login successfully...")
                Me.Hide()

                Dim DS As DataSet 'Object to store data in
                DS = New DataSet 'Declare a new instance, or we get Null Reference Error


                Dim oData As OleDbDataAdapter
                oData = New OleDbDataAdapter(sql, con)
                oData.Fill(DS)

                User.user = DS
                HomeForm.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub LoginForm1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            Application.Exit()
        End If
    End Sub
End Class
