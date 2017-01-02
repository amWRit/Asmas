Imports System.Data
Imports System.Data.OleDb
Public Class myClassesForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Private Sub myClassesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        refreshLV()
    End Sub

    Private Sub refreshLV()
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim ct_id = User.userID
        Dim ct_name = User.fullName
        Dim ct_role = User.userRole

        Dim student_query As String = "id, reg_number, f_name, m_name, l_name, photo FROM STUDENT"
        Dim query As String = ""
        Dim SQL As String = ""

        Dim DS = New DataSet

        Try
            SQL = "SELECT c.class_id,   sy.year_num as year_num, s.short_name as school_name, c.short_name as class_short_name, c.full_name as class_full_name from
                    (SELECT c.class_id, c.short_name, c.full_name, sy.year_num, c.school_id from 
                    class c
                    INNER JOIN
                    school_year sy
                    on c.year_id = sy.year_id
                    where class_teacher='" & ct_name & "') as tb
                    INNER JOIN
                    school s
                    on tb.school_id = s.school_id"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            myClassesListView.Items.Clear() 'prep Listview by clearing it
            myClassesListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                myClassesListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                myClassesListView.Items.Add(xItem)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub searchResultListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles myClassesListView.MouseUp
        If e.Button = MouseButtons.Right Then
            If myClassesListView.GetItemAt(e.X, e.Y) IsNot Nothing Then
                myClassesListView.GetItemAt(e.X, e.Y).Selected = True
                myClassesContextMenu.Show(myClassesListView, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index

        Dim itemID = myClassesListView.Items(ItemIndex).SubItems(0).Text

        viewDetails(itemID)
    End Sub

    Public Sub viewDetails(itemID As String)

        Dim aclassDetailsForm As New classDetailsForm(itemID)
        aclassDetailsForm.Show()

    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim itemID = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim edit As String = "FALSE"
        Dim params As String() = {itemID, edit}
        Dim _addClassForm As New addClassForm(params)
        _addClassForm.Show()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim itemID = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim I As Integer = MsgBox("Are you sure you want to delete?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Are you sure?")
        If I = MsgBoxResult.Yes Then
            SearchForm.deleteFromDatabase(itemID, "Class")
            myClassesListView.Items(ItemIndex).Remove()
        End If
    End Sub

    Private Sub ViewStudentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewStudentsToolStripMenuItem.Click
        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim itemID = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim _myStudents As New myStudents(itemID)
        _myStudents.Show()
    End Sub

    Private Sub ViewResultsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewResultsToolStripMenuItem.Click
        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim itemID = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim year_num = myClassesListView.Items(ItemIndex).SubItems(1).Text
        Dim school_name = myClassesListView.Items(ItemIndex).SubItems(2).Text
        Dim className = myClassesListView.Items(ItemIndex).SubItems(3).Text

        Dim params As String() = {itemID, year_num, school_name, className}

        Dim _classResults As New classResults(params)
        _classResults.Show()
    End Sub

    Private Sub AddResultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddResultToolStripMenuItem.Click


    End Sub

    Private Sub myClassesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub

    Private Sub AddStudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddStudentToolStripMenuItem.Click
        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim class_id = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim _addStudentToClassForm As New addStudentToClassForm(class_id)
        _addStudentToClassForm.Show()
    End Sub

    Private Sub StudentWiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentWiseToolStripMenuItem.Click
        Dim primary As String() = TheClass.primaryShortNames
        Dim lowSec As String() = TheClass.lowSecShortNames
        Dim sec As String() = TheClass.secShortNames

        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim itemID = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim year_num = myClassesListView.Items(ItemIndex).SubItems(1).Text
        Dim school_name = myClassesListView.Items(ItemIndex).SubItems(2).Text
        Dim className = myClassesListView.Items(ItemIndex).SubItems(3).Text

        Dim params As String() = {itemID, year_num, school_name, className, "", "FALSE"}

        If primary.Contains(className) Then
            Dim _newClassResult As New addResultPrimaryForm(params)
            _newClassResult.Show()
        ElseIf lowSec.Contains(className) Then
            Dim _newClassResult As New addResultLowSecForm(params)
            _newClassResult.Show()
        ElseIf sec.Contains(className) Then
            Dim _newClassResult As New addResultSecForm(params)
            _newClassResult.Show()
        End If
    End Sub

    Private Sub SubjectWiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubjectWiseToolStripMenuItem.Click
        Dim primary As String() = TheClass.primaryShortNames
        Dim lowSec As String() = TheClass.lowSecShortNames
        Dim sec As String() = TheClass.secShortNames

        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim class_id = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim year_num = myClassesListView.Items(ItemIndex).SubItems(1).Text
        Dim school_name = myClassesListView.Items(ItemIndex).SubItems(2).Text
        Dim className = myClassesListView.Items(ItemIndex).SubItems(3).Text

        Dim params As String() = {class_id, year_num, school_name, className}

        Dim subjectResult As New subjectWiseResultForm(params)
        subjectResult.Show()
    End Sub

    Private Sub AttendanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AttendanceToolStripMenuItem.Click
        Dim primary As String() = TheClass.primaryShortNames
        Dim lowSec As String() = TheClass.lowSecShortNames
        Dim sec As String() = TheClass.secShortNames

        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim class_id = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim year_num = myClassesListView.Items(ItemIndex).SubItems(1).Text
        Dim school_name = myClassesListView.Items(ItemIndex).SubItems(2).Text
        Dim className = myClassesListView.Items(ItemIndex).SubItems(3).Text

        Dim params As String() = {class_id, year_num, school_name, className}

        Dim _attendance As New addAttendance(params)
        _attendance.Show()
    End Sub

    Private Sub AssignToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignToolStripMenuItem.Click
        SubjectTeacherToolStripMenuItem.Visible = True
        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim class_id = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim className = myClassesListView.Items(ItemIndex).SubItems(3).Text
        Dim _assignSubjectTeacherForm As New assignSubjectTeacherForm(class_id, className)
        _assignSubjectTeacherForm.Show()
    End Sub

    Private Sub ViewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem1.Click
        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim class_id = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim year_num = myClassesListView.Items(ItemIndex).SubItems(1).Text
        Dim school_name = myClassesListView.Items(ItemIndex).SubItems(2).Text
        Dim className = myClassesListView.Items(ItemIndex).SubItems(3).Text
        Dim params As String() = {class_id, year_num, school_name}

        Dim _subjectTeachersDetails As New subjectTeachersDetails(params)
        _subjectTeachersDetails.Show()
    End Sub

    Private Sub ResultAnalysisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResultAnalysisToolStripMenuItem.Click
        Dim ItemIndex As Integer = myClassesListView.SelectedIndices(0) 'Grab the selected Index
        Dim class_id = myClassesListView.Items(ItemIndex).SubItems(0).Text
        Dim year_num = myClassesListView.Items(ItemIndex).SubItems(1).Text
        Dim school_name = myClassesListView.Items(ItemIndex).SubItems(2).Text
        Dim className = myClassesListView.Items(ItemIndex).SubItems(3).Text
        Dim params As String() = {class_id, className, year_num, school_name}

        Dim _subjectResultAnalysisForm As New subjectResultAnalysisForm(params)
        _subjectResultAnalysisForm.Show()
    End Sub

    Private Sub refreshBtn_Click(sender As Object, e As EventArgs) Handles refreshBtn.Click
        refreshLV()
    End Sub


End Class