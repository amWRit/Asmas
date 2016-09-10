Imports System.Data.OleDb
Public Class SearchForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path


    Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        Dim search_type As String = searchType.Text
        Dim search_key As String = searchKey.Text
        Dim search_keyword As String = searchKeyword.Text

        If searchType.SelectedIndex = -1 Then
            MessageBox.Show("Please choose a search type.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim student_query As String = "reg_number,f_name, l_name FROM STUDENT"
        Dim class_query As String = "* FROM CLASS"
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Try
            Dim SQL As String = ""
            Dim query As String = ""


            If search_type = "Student" Then
                If search_key = "ID" Then
                    query = " where reg_number = '" & search_keyword & "'"
                ElseIf search_key = "Name" Then
                    query = " where (f_name LIKE '%" & search_keyword & "%')"
                End If
                SQL = "SELECT " & student_query & query
                If User.userRole = "Admin" Then SubjectTeacherToolStripMenuItem.Visible = False
            ElseIf search_type = "Class" Then
                If search_key = "ID" Then
                    query = " where class_id = " & Convert.ToInt32(search_keyword) & ""
                ElseIf search_key = "Name" Then
                    query = " where (full_name LIKE '%" & search_keyword & "%')"
                End If
                SQL = "SELECT " & class_query & query
                If User.userRole = "Admin" Then SubjectTeacherToolStripMenuItem.Visible = True
            End If


            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)


            searchResultListView.Items.Clear() 'prep Listview by clearing it
            searchResultListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                searchResultListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                searchResultListView.Items.Add(xItem)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
            searchResultListView.Items.Clear()

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub


    'Private Sub frmProgramma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    If MessageBox.Show("Are you sur to close this application?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
    '        Me.Close()
    '        HomeForm.Show()
    '    Else
    '        e.Cancel = True
    '    End If
    'End Sub

    Private Sub searchResultListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles searchResultListView.MouseUp
        If e.Button = MouseButtons.Right Then
            If searchResultListView.GetItemAt(e.X, e.Y) IsNot Nothing Then
                searchResultListView.GetItemAt(e.X, e.Y).Selected = True
                searchResultContextMenu.Show(searchResultListView, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub ViewDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailsToolStripMenuItem.Click
        'viewDatabaseForm.Show()
        Dim ItemIndex As Integer = searchResultListView.SelectedIndices(0) 'Grab the selected Index

        Dim search_Type = searchType.Text
        Dim itemID = searchResultListView.Items(ItemIndex).SubItems(0).Text

        viewDetails(itemID, search_Type)
        'MsgBox(, MsgBoxStyle.Information)
    End Sub

    Private Sub viewDetails(itemID As String, search_type As String)
        If search_type = "Class" Then
            Dim aclassDetailsForm As New classDetailsForm(itemID)
            aclassDetailsForm.Show()
        End If

        If search_type = "Student" Then
            Dim astudentDetails As New studentDetails(itemID)
            astudentDetails.Show()
        End If
    End Sub

    Private Sub SearchForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        'viewDatabaseForm.Show()
        Dim ItemIndex As Integer = searchResultListView.SelectedIndices(0) 'Grab the selected Index

        Dim search_Type = searchType.Text
        Dim itemID = searchResultListView.Items(ItemIndex).SubItems(0).Text

        If search_Type = "Class" Then
            Dim _addClassForm As New addClassForm({itemID, "TRUE"})
            _addClassForm.Show()
        End If

        If search_Type = "Student" Then
            Dim _addStudentForm As New addStudentForm({itemID, "TRUE"})
            _addStudentForm.Show()
        End If

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        'viewDatabaseForm.Show()
        Dim ItemIndex As Integer = searchResultListView.SelectedIndices(0) 'Grab the selected Index
        Dim search_Type = searchType.Text
        Dim itemID = searchResultListView.Items(ItemIndex).SubItems(0).Text
        Dim I As Integer = MsgBox("Are you sure you want to delete?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Are you sure?")
        If I = MsgBoxResult.Yes Then
            deleteFromDatabase(itemID, search_Type)
            searchResultListView.Items(ItemIndex).Remove()
        End If

    End Sub

    Public Sub deleteFromDatabase(ByVal itemID As String, ByVal search_Type As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = ""
        If search_Type = "Class" Then
            SQL = "DELETE * FROM CLASS where class_id=" & itemID
        ElseIf search_Type = "Student" Then
            SQL = "DELETE * from student where reg_number='" & itemID & "'"
        End If

        Try
            Con.Open()
            'DELETE FROM TableName WHERE PrimaryKey = ID
            Dim cmd2 As New OleDb.OleDbCommand(SQL, Con)
            cmd2.ExecuteNonQuery()
            MsgBox("Record Removed Successfully", MsgBoxStyle.Information, "REMOVED")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try

    End Sub

    Private Sub SearchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If User.userRole = "Viewer" Or User.userRole = "Teacher" Then
            EditToolStripMenuItem.Visible = False
            DeleteToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub AssignToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignToolStripMenuItem.Click
        Dim ItemIndex As Integer = searchResultListView.SelectedIndices(0) 'Grab the selected Index
        Dim class_id = searchResultListView.Items(ItemIndex).SubItems(0).Text
        Dim class_name = searchResultListView.Items(ItemIndex).SubItems(3).Text

        Dim _assignSubjectTeacherForm As New assignSubjectTeacherForm(class_id, class_name)
        _assignSubjectTeacherForm.Show()
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Dim ItemIndex As Integer = searchResultListView.SelectedIndices(0) 'Grab the selected Index
        Dim class_id = searchResultListView.Items(ItemIndex).SubItems(0).Text

        Dim form = New assignSubjectTeacherForm("", "")
        Dim class_info = form.getClassInfo(class_id) '{school_name, school_year}

        Dim params As String() = {class_id, class_info(1), class_info(0)}
        Dim _subjectTeachersDetails As New subjectTeachersDetails(params)
        _subjectTeachersDetails.Show()
    End Sub
End Class