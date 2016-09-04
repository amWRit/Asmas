Imports System.Data.OleDb

Public Class viewDatabaseForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String

    Private data_source_path As String = DBConnection.data_source_path

    Private Sub viewDatabaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim schoolSQL As String = "SELECT short_name from SCHOOL"
        Dim yearSQL As String = "SELECT distinct year_num from school_year"
        Dim classSQL As String = "SELECT distinct short_name from CLASS ORDER BY short_name"

        'SCHOOL COMBOBOX
        Con.Open() 'Open connection
        Dim schoolData As OleDbDataAdapter
        schoolData = New OleDbDataAdapter(schoolSQL, Con)
        Con.Close()
        schoolData.Fill(DS)
        Dim rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            schoolName.Items.Add(Val)
        Next

        DS.Tables.Clear()
        'YEAR COMBOBOX
        Con.Open() 'Open connection
        Dim yearData As OleDbDataAdapter
        yearData = New OleDbDataAdapter(yearSQL, Con)
        Con.Close()
        yearData.Fill(DS)
        rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            yearName.Items.Add(Val)
        Next

        DS.Tables.Clear()
        'CLASS COMBOBOX
        Con.Open() 'Open connection
        Dim classData As OleDbDataAdapter
        classData = New OleDbDataAdapter(classSQL, Con)
        Con.Close()
        classData.Fill(DS)
        rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            className.Items.Add(Val)
        Next

    End Sub

    Private Sub viewBtn_Click(sender As Object, e As EventArgs) Handles viewBtn.Click
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Dim SQL As String = ""
        Dim school_name = schoolName.Text
        If schoolName.SelectedIndex = -1 Then
            school_name = "TerseHSS"
        End If

        Dim year_num = yearName.Text
        If yearName.SelectedIndex = -1 Then
            year_num = "2073"
        End If

        Dim class_name = className.Text
        If className.SelectedIndex = -1 Then
            class_name = "%%"
        End If
        SQL = "select * from student st
                inner Join
                (select cs.student_id from class_student cs
                inner Join
                (select c.class_id from class c
                inner Join
                (select sy.year_id from
                 school s
                inner Join 
                school_year sy
                On s.school_id = sy.school_id
                where sy.year_num = '" & year_num & "' and s.short_name = '" & school_name & "') as tb
                on tb.year_id = c.year_id
                where c.short_name like '" & class_name & "') as temp
                on cs.class_id = temp.class_id) temp2
                On st.id = temp2.student_id"
        Try
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            databaseResultListView.Items.Clear() 'prep Listview by clearing it
            databaseResultListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                databaseResultListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                databaseResultListView.Items.Add(xItem)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
            databaseResultListView.Items.Clear()

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub viewDatabaseForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub
End Class