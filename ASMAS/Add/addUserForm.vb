Imports System.Data
Imports System.Data.OleDb

Public Class addUserForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Private Sub cancelBtn_Click_1(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
        HomeForm.Show()
    End Sub

    Private Sub addUserForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub

    Private Sub addUserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Con = New OleDbConnection
        'Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        'Dim DS As DataSet 'Object to store data in
        'DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        'Dim roleSQL As String = "SELECT distinct [role] from [USER]"

        ''ROLE COMBOBOX
        'Con.Open() 'Open connection
        'Dim roleData As OleDbDataAdapter
        'roleData = New OleDbDataAdapter(roleSQL, Con)
        'Con.Close()
        'roleData.Fill(DS)
        'Dim rowCount = DS.Tables(0).Rows.Count

        'For i As Integer = 0 To rowCount - 1
        '    Dim Val = DS.Tables(0).Rows(i)(0).ToString
        '    roleCombo.Items.Add(Val)
        'Next

    End Sub

    Private Sub saveBtn_Click_1(sender As Object, e As EventArgs) Handles saveBtn.Click

        If fullnameTextBox.Text = "" Or usernameTextBox.Text = "" Or pwdTextBox.Text = "" Or roleCombo.SelectedIndex = -1 Then
            MessageBox.Show("One of the fields is empty. Please check!.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim fullName = fullnameTextBox.Text
        Dim userName = usernameTextBox.Text
        Dim userRole = roleCombo.Text
        Dim userPassword = pwdTextBox.Text
        Dim DS = New DataSet
        Dim present As Boolean

        present = checkIfPresent(userName)

        If present = True Then
            MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            Dim roleSQL = "INSERT INTO [user] ([full_name],[user_name],[user_password],[role]) VALUES (@fullName, @userName, @userPwd, @role)"
            Con.Open()
            Dim cmd As New OleDbCommand(roleSQL, Con)
            cmd.Parameters.AddWithValue("@fullName", fullName)
            cmd.Parameters.AddWithValue("@userName", userName)
            cmd.Parameters.AddWithValue("@userPwd", userPassword)
            cmd.Parameters.AddWithValue("@role", userRole)

            cmd.ExecuteNonQuery()

            MsgBox("User successfully added.", MsgBoxStyle.Information, "ADDED")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Public Function checkIfPresent(user_name As String) As Boolean
        Dim present As Boolean = False

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            Dim oData As OleDbDataAdapter

            SQL = "SELECT * from [user] where [user_name]='" & user_name & "'"
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


End Class