Imports System.Data
Imports System.Data.OleDb

Public Class assignSubjectTeacherForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Public class_id As String = ""
    Public Sub New(classID As String, className As String)
        MyBase.New
        If classID = "" Then Exit Sub
        ' This call is required by the designer.
        class_id = classID
        InitializeComponent()
        titleLabel.Text = titleLabel.Text & " " & className
    End Sub
    Private Sub assignSubjectTeacherForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSubjects()
        loadTeachers()
    End Sub

    Public Sub loadTeachers()
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim ctSQL As String = "SELECT [full_name] from [user] where role='Teacher' ORDER BY full_name"
        Con.Open() 'Open connection
        Dim ctData As OleDbDataAdapter
        ctData = New OleDbDataAdapter(ctSQL, Con)
        Con.Close()
        ctData.Fill(DS)
        Dim rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            teacherCombo.Items.Add(Val)
        Next
    End Sub

    Public Sub loadSubjects()
        Try
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Dim SQL As String = "SELECT subject_name from subject ORDER BY subject_name"
            Con.Open() 'Open connection
            Dim ctData As OleDbDataAdapter
            ctData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            ctData.Fill(DS)
            Dim rowCount = DS.Tables(0).Rows.Count

            For i As Integer = 0 To rowCount - 1
                Dim Val = DS.Tables(0).Rows(i)(0).ToString
                subjectCombo.Items.Add(Val)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Private Sub assignBtn_Click(sender As Object, e As EventArgs) Handles assignBtn.Click
        If subjectCombo.SelectedIndex = -1 Or teacherCombo.SelectedIndex = -1 Then
            MessageBox.Show("One of the fields is not selected. Please check.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Dim subject = subjectCombo.Text
            Dim teacher = teacherCombo.Text
            Dim class_info = getClassInfo(class_id)
            'check if present
            Dim assigned As Boolean = checkIfAssigned(class_id, class_info(0), class_info(1), subject, teacher)
            If assigned = True Then
                MessageBox.Show("This subject is already assigned. Please check.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            insertIntoTable(class_id, class_info(0), class_info(1), subject, teacher) '{school_name, school_year}
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Public Function getClassInfo(class_id As String) As String()
        Dim info As String() = {}
        Try
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Dim SQL As String = "SELECT short_name, year_num from
school inner join school_year
on school.school_id = school_year.school_id
where school_year.school_id 
in (SELECT school_id from class
WHERE class_id=" & class_id & ")"
            Con.Open() 'Open connection
            Dim ctData As OleDbDataAdapter
            ctData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            ctData.Fill(DS)

            Dim school_name = DS.Tables(0).Rows(0)("short_name").ToString
            Dim school_year = DS.Tables(0).Rows(0)("year_num").ToString
            info = {school_name, school_year}
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        Return info
    End Function

    Public Sub insertIntoTable(class_id As String, school_name As String, school_year As String, subject As String, teacher As String)
        Try
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

            Dim subjectSQL = "INSERT INTO subject_teacher ([school_year], [school_name], [class_id], [subject_name], [teacher])
                            VALUES
                            (@school_year, @school_name, @class_id, @subject_name, @teacher)"

            Con.Open()
            Dim cmd As New OleDbCommand(subjectSQL, Con)

            cmd.Parameters.AddWithValue("@school_year", school_year)
            cmd.Parameters.AddWithValue("@school_name", school_name)
            cmd.Parameters.AddWithValue("@class_id", class_id)
            cmd.Parameters.AddWithValue("@subject_name", subject)
            cmd.Parameters.AddWithValue("@teacher", teacher)
            cmd.ExecuteNonQuery()

            MsgBox("Successful", MsgBoxStyle.Information, "Inserted")
            subjectCombo.ResetText()
            teacherCombo.ResetText()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Public Function checkIfAssigned(class_id As String, school_name As String, school_year As String, subject As String, teacher As String) As Boolean
        Dim assigned As Boolean = False
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim SQL As String = "SELECT * from subject_teacher
WHERE school_year='" & school_year & "' and school_name='" & school_name & "' and class_id=" & class_id & " and subject_name='" & subject & "'"
        Con.Open() 'Open connection
        Dim ctData As OleDbDataAdapter
        ctData = New OleDbDataAdapter(SQL, Con)
        Con.Close()
        ctData.Fill(DS)
        Dim rowCount = DS.Tables(0).Rows.Count
        If rowCount > 0 Then assigned = True
        Return assigned
    End Function
End Class