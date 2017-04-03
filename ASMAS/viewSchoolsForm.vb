Imports System.Data
Imports System.Data.OleDb

Public Class viewSchoolsForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Private Sub viewSchoolsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        refreshLV()
    End Sub

    Private Sub refreshLV()
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim query As String = ""
        Dim SQL As String = ""

        Dim DS = New DataSet

        Try
            SQL = "SELECT * from [school]"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            schoolsListView.Clear() 'prep Listview by clearing it
            schoolsListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                schoolsListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                schoolsListView.Items.Add(xItem)
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

    Private Sub schoolsListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles schoolsListView.MouseUp
        If e.Button = MouseButtons.Right Then
            If schoolsListView.GetItemAt(e.X, e.Y) IsNot Nothing Then
                schoolsListView.GetItemAt(e.X, e.Y).Selected = True
                viewSchoolsContextMenu.Show(schoolsListView, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim ItemIndex As Integer = schoolsListView.SelectedIndices(0) 'Grab the selected Index
        Dim user_id = schoolsListView.Items(ItemIndex).SubItems(0).Text

        Dim edit As String = "TRUE"
        Dim params As String() = {user_id, edit}
        Dim _addSchoolForm As New addSchoolForm(params)
        _addSchoolForm.Show()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ItemIndex As Integer = schoolsListView.SelectedIndices(0) 'Grab the selected Index
        Dim school_id = schoolsListView.Items(ItemIndex).SubItems(0).Text

        Dim I As Integer = MsgBox("Are you sure you want to delete?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Are you sure?")
        If I = MsgBoxResult.Yes Then
            deleteUserFromDatabase(school_id)
            schoolsListView.Items(ItemIndex).Remove()
        End If
    End Sub

    Private Sub deleteUserFromDatabase(school_id As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        Dim SQL As String = "DELETE * from [school] where school_id =" & school_id
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


    Private Sub refreshBtn_Click(sender As Object, e As EventArgs) Handles refreshBtn.Click
        refreshLV()
    End Sub
End Class