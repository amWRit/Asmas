Imports System.Data.OleDb
Imports Microsoft.ReportingServices.Rendering.ExcelRenderer


Public Class viewResultsForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"
    Public tempDS As New DataSet
    Public filePath As String
    Public index As Integer
    Public class_name As String = ""

    Private Sub viewResultsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        databaseResultListView.Width = 270
        Dim currentUser As DataSet
        currentUser = User.user
        Dim ct_name = User.fullName


        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim schoolSQL As String = "SELECT short_name from SCHOOL"
        Dim yearSQL As String = "SELECT distinct year_num from school_year"
        Dim classSQL As String = "SELECT distinct short_name from CLASS"

        If User.userRole = "Teacher" Then
            classSQL = "SELECT c.short_name as class_short_name from
                    (SELECT c.class_id, c.short_name, c.full_name, sy.year_num, c.school_id from 
                    class c
                    INNER JOIN
                    school_year sy
                    on c.year_id = sy.year_id
                    where class_teacher='" & ct_name & "') as tb
                    INNER JOIN
                    school s
                    on tb.school_id = s.school_id"
        End If

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

        If schoolName.SelectedIndex = -1 Or yearName.SelectedIndex = -1 Or termCombo.SelectedIndex = -1 Or className.SelectedIndex = -1 Then
            MessageBox.Show("One of the fields is not selected. Please check.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Dim SQL As String = ""
        Dim school_name = schoolName.Text
        Dim year_num = yearName.Text
        class_name = className.Text
        Dim term = termCombo.Text
        filePath = school_name & "_" & year_num & "_" & class_name & "_" & term & "Term"
        SQL = "SELECT * from" &
                " (select id, reg_number, f_name, l_name from student) s" &
                " inner join results_" & class_name & " r on s.id = r.student_id" &
                " where school_name ='" & school_name & "' and school_year='" & year_num & "' and terminal='" & term & "';"
        Try
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)
            tempDS = DS

            databaseResultListView.Items.Clear() 'prep Listview by clearing it
            databaseResultListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                databaseResultListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 247, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                databaseResultListView.Items.Add(xItem)
            Next

            'Enable export button
            If DS.Tables(0).Rows.Count > 0 Then
                exportBtn.Enabled = True
                printBtn.Enabled = True
            End If
            'prepare table for print
            myFunctions.prepareTempTable(tempDS, 0, class_name)

        Catch ex As Exception
            MsgBox(ex.Message)
            databaseResultListView.Items.Clear()

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try

    End Sub

    Private Sub viewResultsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub

    Private Sub exportBtn_Click(sender As Object, e As EventArgs) Handles exportBtn.Click
        'Using save file dialog that allow you to chosse the file name.
        Dim objDlg As New SaveFileDialog
        objDlg.Filter = "Excel File|*.xlsx"
        objDlg.OverwritePrompt = False
        objDlg.FileName = filePath
        If objDlg.ShowDialog = DialogResult.OK Then
            Dim filepath As String = objDlg.FileName
            FileHandler.ExportToExcel(GetDatatable(), filepath)
        End If

    End Sub

    Private Function GetDatatable() As DataTable
        'Create the data table at runtime
        Dim DT As New DataTable
        DT = tempDS.Tables(0)
        Return DT
    End Function

    Private Sub printBtn_Click(sender As Object, e As EventArgs) Handles printBtn.Click
        Dim primary As String() = {"1", "2", "3", "4", "5"}
        Dim lowSec As String() = {"6E", "6N", "7E", "7N", "8E", "8N"}
        Dim sec As String() = {"9E", "9N", "10E", "10A"}

        If primary.Contains(class_name) Then
            Dim printForm As New printResultsPrimaryForm(tempDS, 0, class_name)
            printForm.Show()
        ElseIf lowSec.Contains(class_name) Then
            Dim printForm As New printResultLowSecForm(tempDS, 0, class_name)
            printForm.Show()
        ElseIf sec.Contains(class_name) Then
            Dim printForm As New printResultLowSecForm(tempDS, 0, class_name)
            printForm.Show()
        End If
    End Sub

End Class