Imports System.Data.OleDb
Imports Microsoft.ReportingServices.Rendering.ExcelRenderer

Public Class mySubjectAnalysisForm

    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path
    Public Shared params As String()

    Public index As Integer
    Public class_name As String = ""

    Public opt1 As String() = {"Opt. Math", "Economics"}
    Public opt2 As String() = {"Computer", "Account", "Education"}
    Public Shared primary As String() = TheClass.primaryShortNames
    Public Shared lowSec As String() = TheClass.lowSecShortNames
    Public Shared sec As String() = TheClass.secShortNames

    Public filePath As String = ""
    Public tempDS As DataSet

    Private Sub mySubjectAnalysisForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        subjectAnalysisListView.Width = 270


        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim schoolSQL As String = "SELECT short_name from SCHOOL"
        Dim yearSQL As String = "SELECT distinct year_num from school_year"

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
            yearCombo.Items.Add(Val)
        Next

    End Sub

    Private Sub subjectResultAnalysisForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub

    Public Sub refreshLV()
        Dim school_year = yearCombo.Text
        Dim school_name = schoolName.Text
        Dim teacher_name = User.fullName
        Dim terminal = termCombo.Text

        Dim DS As New DataSet
        Dim rowIDs As Integer() = {}
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password = & mypassword"

        Dim SQL As String = ""
        Dim oData As OleDbDataAdapter

        Try
            SQL = "SELECT class_id, school_name, school_year, terminal, teacher_name, subject, average, high, low, locos from subjectResultAnalysis where school_year='" & school_year & "' and school_name='" & school_name & "' and terminal='" & terminal & "' and teacher_name = '" & teacher_name & "'"
            DS.Tables.Clear()
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            tempDS = DS
            filePath = teacher_name & "_SubjectResultAnalysis_" & school_name & "_" & school_year & "_" & terminal & "Term"
            Dim rowCount = DS.Tables(0).Rows.Count
            If rowCount = 0 Then
                MessageBox.Show("The result is not analysed yet. Press 'Analyse Result' button.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            exportBtn.Enabled = True
            subjectAnalysisListView.Items.Clear() 'prep Listview by clearing it
            subjectAnalysisListView.Columns.Clear() 'remove columns in LV

            'get class_name

            'create columns on listview
            subjectAnalysisListView.Columns.Add("class_name", 100, HorizontalAlignment.Left)
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                subjectAnalysisListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To rowCount - 1
                Dim class_id = DS.Tables(0).Rows(i)(0).ToString
                Dim class_full_name = TheClass.getClassFullName(CInt(class_id))
                Dim xItem As New ListViewItem(class_full_name)
                For j As Integer = 0 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                subjectAnalysisListView.Items.Add(xItem)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Private Sub viewBtn_Click(sender As Object, e As EventArgs) Handles viewBtn.Click
        If yearCombo.SelectedIndex = -1 Or termCombo.SelectedIndex = -1 Or schoolName.SelectedIndex = -1 Then
            MessageBox.Show("One of the fields is not selected. Please check.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        refreshLV()
    End Sub

    Private Sub subjectAnalysisListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles subjectAnalysisListView.MouseUp
        If e.Button = MouseButtons.Right Then
            If subjectAnalysisListView.GetItemAt(e.X, e.Y) IsNot Nothing Then
                subjectAnalysisListView.GetItemAt(e.X, e.Y).Selected = True
                resultAnalysisContextMenu.Show(subjectAnalysisListView, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub StudentsUnderLOCOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StudentsUnderLOCOSToolStripMenuItem.Click
        Dim ItemIndex As Integer = subjectAnalysisListView.SelectedIndices(0) 'Grab the selected Index

        'Dim 1,2,3,4,6,11
        Dim class_id = subjectAnalysisListView.Items(ItemIndex).SubItems(1).Text
        Dim school_name = subjectAnalysisListView.Items(ItemIndex).SubItems(2).Text
        Dim school_year = subjectAnalysisListView.Items(ItemIndex).SubItems(3).Text
        Dim terminal = subjectAnalysisListView.Items(ItemIndex).SubItems(4).Text
        Dim subject = subjectAnalysisListView.Items(ItemIndex).SubItems(6).Text
        Dim locos = subjectAnalysisListView.Items(ItemIndex).SubItems(10).Text
        Dim class_name = TheClass.getClassName(CInt(class_id))

        Dim contents As String() = {class_id, class_name, school_name, school_year, terminal, subject, locos}
        Dim _studentsUnderLocosForm As New studentsUnderLocosForm(contents)
        _studentsUnderLocosForm.Show()
    End Sub

    Private Sub exportBtn_Click(sender As Object, e As EventArgs) Handles exportBtn.Click
        Dim objDlg As New SaveFileDialog
        objDlg.Filter = "Excel File|*.xlsx"
        objDlg.OverwritePrompt = False
        objDlg.FileName = filePath
        If objDlg.ShowDialog = DialogResult.OK Then
            Dim filepath As String = objDlg.FileName
            FileHandler.ExportToExcel(FileHandler.GetDatatable(tempDS), filepath)
        End If
    End Sub

End Class