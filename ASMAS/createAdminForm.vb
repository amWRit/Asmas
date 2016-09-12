Imports System.Data
Imports System.Data.OleDb

Public Class createAdminForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path
    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim fullName = fullnameTextBox.Text
        Dim userName = usernameTextBox.Text
        Dim userRole = "Admin"
        Dim userPassword = pwdTextBox.Text
        Dim DS = New DataSet
        Dim present As Boolean = False

        Try
            Dim Sql = "INSERT INTO [user] ([full_name],[user_name],[user_password],[role]) VALUES (@fullName, @userName, @userPwd, @role)"
            Con.Open()
            Dim cmd As New OleDbCommand(Sql, Con)
            cmd.Parameters.AddWithValue("@fullName", fullName)
            cmd.Parameters.AddWithValue("@userName", userName)
            cmd.Parameters.AddWithValue("@userPwd", userPassword)
            cmd.Parameters.AddWithValue("@role", userRole)

            cmd.ExecuteNonQuery()

            MsgBox("Admin successfully created.", MsgBoxStyle.Information, Command)

            'update the first_time flag
            updateFirstTimeFlag()
            'exit the program
            MessageBox.Show("The program needs to restart now.", "RESTART", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Application.Restart()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Private Sub updateFirstTimeFlag()
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Try
            Dim Sql = "UPDATE [firstTimeCheck] SET [first_time] = @first_time"
            Con.Open()
            Dim cmd As New OleDbCommand(Sql, Con)
            cmd.Parameters.AddWithValue("@first_time", "No")

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub
End Class