Imports System.Data
Imports System.Data.OleDb

Public Class viewUsersForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Private Sub viewUsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim query As String = ""
        Dim SQL As String = ""

        Dim DS = New DataSet

        Try
            SQL = "SELECT * from [user]"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            usersListView.Clear() 'prep Listview by clearing it
            usersListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                usersListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                usersListView.Items.Add(xItem)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub viewUsersForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub

    Private Sub usersListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles usersListView.MouseUp
        If e.Button = MouseButtons.Right Then
            If usersListView.GetItemAt(e.X, e.Y) IsNot Nothing Then
                usersListView.GetItemAt(e.X, e.Y).Selected = True
                viewUsersContextMenu.Show(usersListView, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim ItemIndex As Integer = usersListView.SelectedIndices(0) 'Grab the selected Index
        Dim user_id = usersListView.Items(ItemIndex).SubItems(0).Text
        If User.isAdmin(user_id) = True Then
            MessageBox.Show("You can't edit an ADMIN.", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim edit As String = "TRUE"
            Dim params As String() = {user_id, edit}
            Dim _addUserForm As New addUserForm(params)
            _addUserForm.Show()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ItemIndex As Integer = usersListView.SelectedIndices(0) 'Grab the selected Index
        Dim user_id = usersListView.Items(ItemIndex).SubItems(0).Text

        If User.isAdmin(user_id) = True Then
            MessageBox.Show("You can't delete an ADMIN.", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim I As Integer = MsgBox("Are you sure you want to delete?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Are you sure?")
            If I = MsgBoxResult.Yes Then
                deleteUserFromDatabase(user_id)
                usersListView.Items(ItemIndex).Remove()
            End If
        End If

    End Sub

    Private Sub deleteUserFromDatabase(user_id As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        Dim SQL As String = "DELETE * from [user] where user_id =" & user_id
        Try
            Con.Open()
            'DELETE FROM TableName WHERE PrimaryKey = ID
            Dim cmd2 As New OleDb.OleDbCommand(SQL, Con)
            cmd2.ExecuteNonQuery()
            MsgBox("User removed successfully. Please check.", MsgBoxStyle.Information, "REMOVED")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

End Class