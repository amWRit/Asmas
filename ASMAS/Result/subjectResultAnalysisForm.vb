Imports System.Data
Imports System.Data.OleDb

Public Class subjectResultAnalysisForm
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path
    Public Shared Con As System.Data.OleDb.OleDbConnection
    Public Shared params As String()
    Public opt1 As String() = {"Opt. Math", "Economics"}
    Public opt2 As String() = {"Computer", "Account", "Education"}
    Public Shared primary As String() = TheClass.primaryShortNames
    Public Shared lowSec As String() = TheClass.lowSecShortNames
    Public Shared sec As String() = TheClass.secShortNames

    Public filePath As String = ""
    Public tempDS As DataSet

    Private Sub subjectResultAnalysisForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
    End Sub

    Private Sub subjectResultAnalysisForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            myClassesForm.Show()
        End If
    End Sub

    'params = {class_id, className, year_num, school_name}
    Public Sub New(_params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        params = _params
        refreshLV()
    End Sub

    Public Sub refreshLV()
        Dim class_id = params(0)
        Dim class_name = params(1)
        Dim school_year = params(2)
        Dim school_name = params(3)
        Dim terminal = "First"
        If termCombo.SelectedIndex <> -1 Then terminal = termCombo.Text

        Dim DS As New DataSet
        Dim rowIDs As Integer() = {}
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password = & mypassword"

        Dim SQL As String = ""
        Dim oData As OleDbDataAdapter

        Try
            SQL = "SELECT * from subjectResultAnalysis where class_id =" & class_id & " and school_year='" & school_year & "' and school_name='" & school_name & "' and terminal='" & terminal & "'"
            DS.Tables.Clear()
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            tempDS = DS
            filePath = "SubjectResultAnalysis_" & school_name & "_" & school_year & "_" & terminal & "Term_Class" & class_name
            Dim rowCount = DS.Tables(0).Rows.Count
            If rowCount = 0 Then
                MessageBox.Show("The result is not analysed yet. Press 'Analyse Result' button.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            exportBtn.Enabled = True
            subjectAnalysisListView.Items.Clear() 'prep Listview by clearing it
            subjectAnalysisListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                subjectAnalysisListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To rowCount - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
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

    Private Sub analyseBtn_Click(sender As Object, e As EventArgs) Handles analyseBtn.Click

        If termCombo.SelectedIndex = -1 Then
            MessageBox.Show("Please select a terminal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim class_id = params(0)
        Dim class_name = params(1)
        Dim school_year = params(2)
        Dim school_name = params(3)
        Dim terminal = termCombo.Text
        Dim dataHash As New Hashtable
        Try
            'get the results
            Dim resultDS As DataSet = resultFunctions.getResultOf(class_name, terminal, school_year, school_name)
            If resultDS.Tables(0).Rows.Count = 0 Then
                MsgBox("There are no results available to be analysed.", MsgBoxStyle.Information, "No DATA")
            Else
                dataHash = getResultAnaysisData(resultDS, class_id, class_name)
                'update into the table
                insertAnalysisData(dataHash, class_id, class_name, terminal, school_year, school_name)
                refreshLV()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Function getResultAnaysisData(resultDS As DataSet, class_id As String, class_name As String) As Hashtable

        'get analysis data
        Dim totSubj = myFunctions.getClassSubjectsOf(class_id)
        Dim dataHash As New Hashtable

        For Each subj As String In totSubj
            Dim rowCount = resultDS.Tables(0).Rows.Count
            Dim key = resultFunctions.getSubjCode(subj)
            Dim total As Double = 0
            Dim average As Double = 0
            Dim min As Double = 100
            Dim max As Double = 0
            Dim marks As New List(Of Double)
            Dim locos As Double = 0
            Dim drs As DataRow() = {}
            If (opt1.Contains(subj) Or opt2.Contains(subj)) And sec.Contains(class_name) Then
                If opt1.Contains(subj) Then drs = resultDS.Tables(0).Select("opt1='" & subj & "'")
                If opt2.Contains(subj) Then drs = resultDS.Tables(0).Select("opt2='" & subj & "'")
                rowCount = drs.Count
            End If
            Dim presentStudentCount = rowCount
            Dim locosIndex As Integer
            For i As Integer = 0 To rowCount - 1
                Dim val As Object
                Dim dVal As Double = 0
                If opt1.Contains(subj) And sec.Contains(class_name) Then
                    drs = resultDS.Tables(0).Select("opt1='" & subj & "'")
                    val = drs.ElementAt(i).Item(47)
                ElseIf opt2.Contains(subj) And sec.Contains(class_name) Then
                    drs = resultDS.Tables(0).Select("opt2='" & subj & "'")
                    val = drs.ElementAt(i).Item(53)
                Else
                    val = resultDS.Tables(0).Rows(i).Item(key & "_total")
                End If

                If val Is DBNull.Value Then
                    dVal = 0
                Else
                    dVal = CDbl(val)
                End If

                total += dVal
                If dVal = 0 Then
                    presentStudentCount -= 1 'assuming he/she was absent
                Else
                    marks.Add(dVal)
                    min = Math.Min(dVal, min)
                    max = Math.Max(dVal, max)
                End If
            Next
            dataHash(key) = total
            If presentStudentCount = 0 Then presentStudentCount = 1 'to avoid 0/0
            average = total / presentStudentCount
            dataHash(key & "_average") = Math.Round(average, 2)
            dataHash(key & "_min") = min
            dataHash(key & "_max") = max
            Dim marksArr = marks.ToArray
            Array.Sort(Of Double)(marksArr)
            If marksArr.Count = 1 Then
                locosIndex = 0
            Else
                locosIndex = CInt(Math.Ceiling(0.2 * presentStudentCount))
            End If
            If marksArr.Count <> 0 Then locos = marksArr(locosIndex)
            dataHash(key & "_locos") = locos
        Next
        Return dataHash
    End Function

    Public Sub insertAnalysisData(dataHash As Hashtable, class_id As String, class_name As String, terminal As String, school_year As String, school_name As String)
        Dim DS As New DataSet
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = ""
        Dim oData As OleDbDataAdapter
        Dim teacher_id As Integer
        Dim teacher_name As String
        Dim subject_name As String
        Dim subj_key As String
        Try
            SQL = "SELECT ID, teacher, subject_name FROM subject_teacher where class_id =" & class_id & " and school_year='" & school_year & "' and school_name='" & school_name & "'"
            DS.Tables.Clear()
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim insertSQL = "INSERT into subjectResultAnalysis ([class_id],[school_name], [school_year], [teacher_id],[teacher_name],[subject],[terminal],[average],[high],[low],[locos])
                            VALUES
                            (@class_id, @school_name, @school_year, @teacher_id, @teacher_name, @subject, @terminal, @average, @high, @low, @locos)"
            Dim rowIDs As Integer() = checkifPresent(class_id, school_year, school_name, terminal)


            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                If rowIDs.Count > 0 Then
                    insertSQL = "UPDATE subjectResultAnalysis 
                            SET
                            class_id = @class_id, school_name = @school_name, school_year = @school_year, teacher_id = @teacher_id, teacher_name = @teacher_name, subject= @subject, terminal = @terminal, average = @average,high= @high, low=@low, locos= @locos
                            WHERE ID = " & rowIDs(i)
                End If
                Con.Open()
                Dim cmd As New OleDbCommand(insertSQL, Con)
                teacher_id = CInt(DS.Tables(0).Rows(i).Item("ID"))
                teacher_name = DS.Tables(0).Rows(i).Item("teacher").ToString
                subject_name = DS.Tables(0).Rows(i).Item("subject_name").ToString
                subj_key = resultFunctions.getSubjCode(subject_name)

                cmd.Parameters.AddWithValue("@class_id", class_id)
                cmd.Parameters.AddWithValue("@school_name", school_name)
                cmd.Parameters.AddWithValue("@school_year", school_year)
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id)
                cmd.Parameters.AddWithValue("@teacher_name", teacher_name)
                cmd.Parameters.AddWithValue("@subject", subject_name)
                cmd.Parameters.AddWithValue("@terminal", terminal)
                cmd.Parameters.AddWithValue("@average", dataHash(subj_key & "_average"))
                cmd.Parameters.AddWithValue("@high", dataHash(subj_key & "_max"))
                cmd.Parameters.AddWithValue("@low", dataHash(subj_key & "_min"))
                cmd.Parameters.AddWithValue("@locos", dataHash(subj_key & "_locos"))

                cmd.ExecuteNonQuery()
                Con.Close()
            Next
            MsgBox("Analysis successfully completed and updated.", MsgBoxStyle.Information, "SUCCESS")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Public Function checkifPresent(class_id As String, school_year As String, school_name As String, terminal As String) As Integer()
        Dim DS As New DataSet
        Dim rowIDs As Integer() = {}
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = ""
        Dim oData As OleDbDataAdapter

        Try
            SQL = "SELECT ID from subjectResultAnalysis where class_id =" & class_id & " and school_year='" & school_year & "' and school_name='" & school_name & "' and terminal='" & terminal & "'"
            DS.Tables.Clear()
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count
            If rowCount = 0 Then Return rowIDs
            ReDim Preserve rowIDs(rowCount - 1)
            For i As Integer = 0 To rowCount - 1
                rowIDs(i) = CInt(DS.Tables(0).Rows(i).Item("ID"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        Return rowIDs
    End Function

    Private Sub termCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles termCombo.SelectedIndexChanged
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
        Dim locos = subjectAnalysisListView.Items(ItemIndex).SubItems(11).Text
        Dim class_name = params(1)

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