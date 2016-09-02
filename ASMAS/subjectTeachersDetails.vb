Imports System.Data
Imports System.Data.OleDb

Public Class subjectTeachersDetails
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"
    Public contents As String()

    'params = {class_id, year_num, school_name}
    Public Sub New(params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        contents = params

        Dim teacherDS As New DataSet
        teacherDS = getSubjectTeacherDetailsOf(contents)
        refreshLV(teacherDS)
    End Sub

    Public Sub refreshLV(DS As DataSet)
        Try
            subjectTeacherListView.Items.Clear() 'prep Listview by clearing it
            subjectTeacherListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                subjectTeacherListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                subjectTeacherListView.Items.Add(xItem)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    'params = {class_id, year_num, school_name}
    Public Function getSubjectTeacherDetailsOf(params As String()) As DataSet
        Dim class_id = params(0)
        Dim school_year = params(1)
        Dim school_name = params(2)
        Dim teacherDS As New DataSet
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            'find the student reg_number and name
            SQL = "SELECT * from subject_teacher
WHERE school_year='" & school_year & "' and school_name='" & school_name & "' and class_id=" & class_id
            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(teacherDS)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        Return teacherDS
    End Function

    Private Sub subjectTeacherListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles subjectTeacherListView.MouseUp
        If e.Button = MouseButtons.Right Then
            If subjectTeacherListView.GetItemAt(e.X, e.Y) IsNot Nothing Then
                subjectTeacherListView.GetItemAt(e.X, e.Y).Selected = True
                subjectTeacherMenuStrip.Show(subjectTeacherListView, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim ItemIndex As Integer = subjectTeacherListView.SelectedIndices(0) 'Grab the selected Index
        Dim itemID = subjectTeacherListView.Items(ItemIndex).SubItems(0).Text 'rowID
        Dim I As Integer = MsgBox("Are you sure you want to delete?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), "Are you sure?")
        If I = MsgBoxResult.Yes Then
            deleteFromDatabase(itemID)
            subjectTeacherListView.Items(ItemIndex).Remove()
        End If
    End Sub

    Public Sub deleteFromDatabase(itemID As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = ""
        SQL = "DELETE * from subject_teacher where ID=" & itemID

        Try
            'DELETE FROM TableName WHERE PrimaryKey = ID
            Dim cmd2 As New OleDb.OleDbCommand(SQL, Con)
            cmd2.ExecuteNonQuery()
            MsgBox("Record removed successfully.Please check.", MsgBoxStyle.Information, "REMOVED")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub
End Class