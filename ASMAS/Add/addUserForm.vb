Imports System.Data
Imports System.Data.OleDb

Public Class addUserForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Public edit As String = ""
    Public user_id As String = ""
    Public old_full_name As String = ""

    Private Sub cancelBtn_Click_1(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Hide()
        HomeForm.Show()
    End Sub

    Private Sub addUserForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub

    Public Sub New(params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        user_id = params(0)
        edit = params(1)
        If edit = "TRUE" Then
            loadUserInfo(user_id)
            old_full_name = fullnameTextBox.Text
        End If
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
        Dim present As Boolean = False
        Dim roleSQL = ""
        Dim command = "added"

        If edit = "FALSE" Then present = checkIfPresent(userName)
        If present = True Then
            MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Try
            If edit = "TRUE" Then
                command = "updated"
                roleSQL = "UPDATE [user] SET [full_name] = @fullName, [user_name] = @userName, [user_password] = @userPwd, [role] = @role where user_id=" & user_id
            Else
                roleSQL = "INSERT INTO [user] ([full_name],[user_name],[user_password],[role]) VALUES (@fullName, @userName, @userPwd, @role)"
            End If
            Con.Open()
            Dim cmd As New OleDbCommand(roleSQL, Con)
            cmd.Parameters.AddWithValue("@fullName", fullName)
            cmd.Parameters.AddWithValue("@userName", userName)
            cmd.Parameters.AddWithValue("@userPwd", userPassword)
            cmd.Parameters.AddWithValue("@role", userRole)

            cmd.ExecuteNonQuery()

            MsgBox("User successfully " & command & ".", MsgBoxStyle.Information, command)
            If edit = "TRUE" Then
                Me.Close()
                'update name in class and subjectTeacher tables
                If old_full_name <> fullName Then
                    updateRelatedTables(old_full_name, fullName)
                End If
            End If

            Dim textboxes = myFunctions.getTextBoxes(Me)
            myFunctions.clearTextBoxes(textboxes)
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

    Public Sub loadUserInfo(user_id As String)

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            Dim oData As OleDbDataAdapter

            SQL = "SELECT * from [user] where user_id=" & user_id
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            DS.Tables.Clear()
            oData.Fill(DS)

            Dim role = DS.Tables(0).Rows(0).Item("role").ToString
            Dim rowCount = DS.Tables(0).Rows.Count
            fullnameTextBox.Text = DS.Tables(0).Rows(0).Item("full_name").ToString
            usernameTextBox.Text = DS.Tables(0).Rows(0).Item("user_name").ToString
            pwdTextBox.Text = DS.Tables(0).Rows(0).Item("user_password").ToString
            roleCombo.Text = DS.Tables(0).Rows(0).Item("role").ToString

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub updateRelatedTables(old_full_name As String, new_full_name As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Try
            Dim SQL = "UPDATE [class] SET [class_teacher] = @fullName where class_teacher='" & old_full_name & "'"
            Con.Open()
            Dim cmd As New OleDbCommand(SQL, Con)
            cmd.Parameters.AddWithValue("@fullName", new_full_name)
            cmd.ExecuteNonQuery()
            Con.Close()

            SQL = "UPDATE [subject_teacher] SET [teacher] = @fullName where teacher='" & old_full_name & "'"
            Con.Open()
            cmd = New OleDbCommand(SQL, Con)
            cmd.Parameters.AddWithValue("@fullName", new_full_name)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

End Class