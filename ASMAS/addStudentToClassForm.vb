Imports System.Data
Imports System.Data.OleDb
Public Class addStudentToClassForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Dim DS As DataSet 'Object to store data in

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub addStudentToClassForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByVal class_id As String)
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        classIDLabel.Text = class_id
    End Sub

    Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim search_key As String = searchKey.Text
        Dim search_keyword As String = searchKeyword.Text
        Dim student_query As String = "id, reg_number, f_name, m_name, l_name, photo FROM STUDENT"
        Dim query As String = ""
        Dim SQL As String = ""

        DS = New DataSet

        Try
            If search_key = "ID" Then
                query = " where reg_number = '" & search_keyword & "'"
            ElseIf search_key = "Name" Then
                query = " where (f_name LIKE '%" & search_keyword & "%')"
            End If
            SQL = "SELECT " & student_query & query

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            searchResultListView.Items.Clear() 'prep Listview by clearing it
            searchResultListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                searchResultListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 247, HorizontalAlignment.Left)
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

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub searchResultListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles searchResultListView.MouseUp
        If e.Button = MouseButtons.Right Then
            If searchResultListView.GetItemAt(e.X, e.Y) IsNot Nothing Then
                searchResultListView.GetItemAt(e.X, e.Y).Selected = True
                searchResultContextMenu.Show(searchResultListView, New Point(e.X, e.Y))
            End If

        ElseIf e.Button = MouseButtons.Left Then
            Dim ItemIndex As Integer = searchResultListView.SelectedIndices(0) 'Grab the selected Index
            Dim photoPath = searchResultListView.Items(ItemIndex).SubItems(5).Text.ToString

            If photoPath = "" Then photoPath = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\bin\photo_not_available.png"
            studentPhoto.Image = Image.FromFile(photoPath)

            Dim f_name = searchResultListView.Items(ItemIndex).SubItems(2).Text.ToString
            Dim m_name = searchResultListView.Items(ItemIndex).SubItems(3).Text.ToString
            Dim l_name = searchResultListView.Items(ItemIndex).SubItems(4).Text.ToString
            fullnameLabel.Text = f_name & " " & m_name & " " & l_name
        End If
    End Sub

    Private Sub addStudentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles addStudentToolStripMenuItem.Click
        Dim ItemIndex As Integer = searchResultListView.SelectedIndices(0) 'Grab the selected Index

        Dim itemID = searchResultListView.Items(ItemIndex).SubItems(0).Text
        Dim student_id = searchResultListView.Items(ItemIndex).SubItems(0).Text

        Dim class_id = classIDLabel.Text
        addStudentToClass(class_id, student_id)
    End Sub

    Private Sub addStudentToClass(class_id As String, student_id As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Try
            Dim insertSQL As String = "INSERT INTO class_student ([class_id], [student_id]) 
                                        VALUES 
                                       (@class_id, @student_id)"
            Con.Open()
            Dim cmd As New OleDbCommand(insertSQL, Con)
            cmd.Parameters.AddWithValue("@class_id", class_id)
            cmd.Parameters.AddWithValue("@student_id", student_id)
            cmd.ExecuteNonQuery()

            MsgBox("Insert Successful", MsgBoxStyle.Information, "INSERTED")
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
            'AddTable()
        End Try

    End Sub

    Private Sub addStudentToClassForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub
End Class