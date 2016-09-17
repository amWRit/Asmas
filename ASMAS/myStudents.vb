﻿Imports System.Data
Imports System.Data.OleDb
Public Class myStudents
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path
    Public Shared class_id As String = ""

    Public Sub New(ByVal itemID As String)
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        class_id = itemID
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "SELECT * from 
                    student s
                    INNER JOIN
                    (SELECT student_id from 
                    class c
                    INNER JOIN
                    class_student cs
                    on c.class_id = cs.class_id
                    where c.class_id =" & itemID & ") tb
                    on s.id = tb.student_id ORDER BY ID"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            myStudentsListView.Items.Clear() 'prep Listview by clearing it
            myStudentsListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                myStudentsListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                myStudentsListView.Items.Add(xItem)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub myStudentsListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles myStudentsListView.MouseUp
        If e.Button = MouseButtons.Right Then
            If myStudentsListView.GetItemAt(e.X, e.Y) IsNot Nothing Then
                myStudentsListView.GetItemAt(e.X, e.Y).Selected = True
                myStudentsContextMenu.Show(myStudentsListView, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Dim ItemIndex As Integer = myStudentsListView.SelectedIndices(0) 'Grab the selected Index
        Dim itemID = myStudentsListView.Items(ItemIndex).SubItems(1).Text
        'Dim _addStudentForm As New addStudentForm(itemID)
        '_addStudentForm.Show()
        Dim _studentDetails As New studentDetails(itemID)
        _studentDetails.Show()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ItemIndex As Integer = myStudentsListView.SelectedIndices(0) 'Grab the selected Index
        Dim student_id = myStudentsListView.Items(ItemIndex).SubItems(0).Text
        Dim I As Integer = MsgBox("Are you sure you want to remove this student?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Are you sure?")
        If I = MsgBoxResult.Yes Then
            'SearchForm.deleteFromDatabase(itemID, "Student")
            removeFromMyClass(student_id)
            myStudentsListView.Items(ItemIndex).Remove()
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim ItemIndex As Integer = myStudentsListView.SelectedIndices(0) 'Grab the selected Index
        Dim itemID = myStudentsListView.Items(ItemIndex).SubItems(1).Text
        Dim _addStudentForm As New addStudentForm({itemID, "TRUE"})
        _addStudentForm.Show()
    End Sub

    Private Sub removeFromMyClass(student_id As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL = "DELETE * from class_student where student_id=" & student_id & " and class_id=" & class_id
        Try
            Con.Open()
            'DELETE FROM TableName WHERE PrimaryKey = ID
            Dim cmd2 As New OleDb.OleDbCommand(SQL, Con)
            cmd2.ExecuteNonQuery()
            MsgBox("Student removed successfully from your class. Please check.", MsgBoxStyle.Information, "REMOVED")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Private Sub myStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
    End Sub

    Private Sub UpgradeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpgradeToolStripMenuItem.Click
        Dim selectedItemsCount = myStudentsListView.SelectedItems.Count
        Dim student_ids As String()
        ReDim Preserve student_ids(selectedItemsCount - 1)
        For i As Integer = 0 To selectedItemsCount - 1
            Dim ItemIndex As Integer = myStudentsListView.SelectedIndices(i) 'Grab the selected Index
            student_ids(i) = myStudentsListView.Items(ItemIndex).SubItems(0).Text
        Next

        Dim _upgradeStudentForm As New upgradeStudentForm(student_ids, class_id)
        _upgradeStudentForm.Show()
    End Sub

End Class