Imports System.Data
Imports System.Data.OleDb

Public Class subjectWiseResultForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Public student_ids As Integer() = {}
    Public current_student_id As String = ""
    Public current_student_index As Integer = 0
    Public class_params As String() = {}
    Public present As Boolean = False

    Private Sub subjectWiseResultForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            myClassesForm.Show()
        End If
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Hide()
        myClassesForm.Show()
    End Sub

    '{class_id, year_num, school_name, className}
    Public Sub New(params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        class_params = params
        Dim class_id = params(0)
        Dim class_name = params(3)
        If TheClass.primaryShortNames.Contains(class_name) Then subjPr.Enabled = False
        'find student ids
        student_ids = myFunctions.getStudentIdsOf(class_id)
        remainingCount.Text = student_ids.Count.ToString
        'load first student to the form
        current_student_id = student_ids.First.ToString
        loadStudentInfo(CInt(current_student_id))

        'load subject names
        Dim subjects As String() = myFunctions.getClassSubjectsOf(class_id)
        For i As Integer = 0 To subjects.Count - 1
            subjectCombo.Items.Add(subjects(i))
        Next
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If subjectCombo.SelectedIndex = -1 Or termCombo.SelectedIndex = -1 Then
            MessageBox.Show("One of the fields is not selected. Please check.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'check if result of that term for that student already exists
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim terminal = termCombo.Text
        Dim class_name = class_params(3)
        Dim school_year = class_params(1)
        Dim school_name = class_params(2)
        Dim subjKey As String = resultFunctions.getSubjKey(subjectCombo.Text, class_name)
        'Dim present As Boolean = False
        'present = resultFunctions.checkIfPresent(current_student_id, terminal, class_name)
        'if present, update, else add new
        Dim subjectSQL = "INSERT INTO results_" & class_name & " ([student_id], [reg_number], [full_name], [school_year],[school_name],[terminal], [" & subjKey & "_th], [" & subjKey & "_pr])
                            VALUES
                            (@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @" & subjKey & "_th, @" & subjKey & "_pr)"
        Dim command = "INSERTED"
        Try
            If present = True Then
                'get update sql
                command = "UPDATED"
                Dim rowID = resultFunctions.getStudentResultRowID(school_year, school_name, terminal, class_name, current_student_id)
                subjectSQL = "UPDATE results_" & class_name & " SET " &
                subjKey & "_th = @" & subjKey & "_th," & subjKey & "_pr = @" & subjKey & "_pr WHERE id=" & rowID
            End If

            Con.Open()
            Dim cmd As New OleDbCommand(subjectSQL, Con)
            If present = False Then
                cmd.Parameters.AddWithValue("@student_id", current_student_id)
                cmd.Parameters.AddWithValue("@reg_number", regNumberTextBox.Text)
                cmd.Parameters.AddWithValue("@full_name", studentNameTextBox.Text)
                cmd.Parameters.AddWithValue("@school_year", school_year)
                cmd.Parameters.AddWithValue("@school_name", school_name)
                cmd.Parameters.AddWithValue("@terminal", terminal)
            End If

            cmd.Parameters.AddWithValue("@" & subjKey & "_th", subjTh.Text)
            cmd.Parameters.AddWithValue("@" & subjKey & "_pr", subjPr.Text)
            cmd.ExecuteNonQuery()

            Dim I As Integer = MsgBox("Successful", MsgBoxStyle.Information, command)
            If I = MsgBoxResult.Ok Then
                prepareNext()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
        End Try
        subjTh.Focus()
    End Sub

    Private Sub subjectCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles subjectCombo.SelectedIndexChanged
        Dim optSub As String() = {"Opt. Math", "Account", "Education", "Economics"}
        If optSub.Contains(subjectCombo.Text) Then
            MessageBox.Show("Please input marks of Optional subjects student wise.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        If subjectCombo.Text = "Maths" Then subjPr.Enabled = False
        If subjectCombo.Text <> "Maths" And Not TheClass.primaryShortNames.Contains(class_params(3)) Then subjPr.Enabled = True

        If termCombo.SelectedIndex <> -1 Then
            Dim terminal = termCombo.Text
            Dim class_name = class_params(3)
            Dim school_year = class_params(1)
            Dim school_name = class_params(2)
            Dim subjKey As String = resultFunctions.getSubjKey(subjectCombo.Text, class_name)
            Dim params As String() = {school_year, school_name, class_name, terminal, current_student_id, subjKey}
            'present = resultFunctions.checkIfPresent(current_student_id, terminal, class_name)
            Dim subjMarksEntered = checkIfSubjMarksEntered(current_student_id, terminal, class_name, subjKey)
            If subjMarksEntered = True Then
                presentCheckLabel.Text = "Yes"
                presentCheckLabel.ForeColor = Color.ForestGreen
                resultFunctions.loadSubjMarks(params, subjTh, subjPr)
            Else
                presentCheckLabel.Text = "No"
                presentCheckLabel.ForeColor = Color.Red
                subjTh.Text = ""
                subjPr.Text = ""
            End If
            prevBtn.Enabled = True
            nextBtn.Enabled = True
        End If
    End Sub

    Private Sub termCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles termCombo.SelectedIndexChanged
        Dim terminal = termCombo.Text
        Dim class_name = class_params(3)
        Dim school_year = class_params(1)
        Dim school_name = class_params(2)
        present = resultFunctions.checkIfPresent(current_student_id, terminal, class_name)

        If subjectCombo.SelectedIndex <> -1 Then
            Dim subjKey As String = resultFunctions.getSubjKey(subjectCombo.Text, class_name)
            Dim params As String() = {school_year, school_name, class_name, terminal, current_student_id, subjKey}
            If present = True Then
                presentCheckLabel.Text = "Yes"
                presentCheckLabel.ForeColor = Color.ForestGreen
                resultFunctions.loadSubjMarks(params, subjTh, subjPr)
            Else
                presentCheckLabel.Text = "No"
                presentCheckLabel.ForeColor = Color.Red
                subjTh.Text = "0"
                subjPr.Text = "0"
            End If
            prevBtn.Enabled = True
            nextBtn.Enabled = True
        End If
    End Sub

    Public Sub loadStudentInfo(student_id As Integer)
        Dim studentInfo As String() = myFunctions.getStudentInfoOf(student_id) '{reg_number, student_name}
        Dim reg_number = studentInfo(0)
        Dim student_name = studentInfo(1)
        regNumberTextBox.Text = reg_number
        studentNameTextBox.Text = student_name
    End Sub


    Public Sub prepareData()
        termCombo.Enabled = False
        subjectCombo.Enabled = False

        If current_student_index > student_ids.Count - 1 Then
            MessageBox.Show("Yay! You have entered marks of all the students for this subject.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            saveBtn.Enabled = False
            Exit Sub
        End If

        current_student_id = student_ids(current_student_index).ToString
        loadStudentInfo(CInt(current_student_id))

        Dim terminal = termCombo.Text
        Dim class_name = class_params(3)
        Dim school_year = class_params(1)
        Dim school_name = class_params(2)
        Dim subjKey As String = resultFunctions.getSubjKey(subjectCombo.Text, class_name)
        Dim params As String() = {school_year, school_name, class_name, terminal, current_student_id, subjKey}
        present = resultFunctions.checkIfPresent(current_student_id, terminal, class_name)
        Dim subjMarksEntered = checkIfSubjMarksEntered(current_student_id, terminal, class_name, subjKey)

        If subjMarksEntered = True Then
            presentCheckLabel.Text = "Yes"
            presentCheckLabel.ForeColor = Color.ForestGreen
            If present = True Then resultFunctions.loadSubjMarks(params, subjTh, subjPr)
        Else
            presentCheckLabel.Text = "No"
            presentCheckLabel.ForeColor = Color.Red
            subjTh.Text = "0"
            subjPr.Text = "0"
        End If

    End Sub

    Public Sub prepareNext()
        If prevBtn.Enabled = False Then prevBtn.Enabled = True
        remainingCount.Text = (student_ids.Count - current_student_index - 1).ToString
        current_student_index += 1
        If current_student_index = student_ids.Count - 1 Then nextBtn.Enabled = False
        prepareData()
    End Sub

    Public Sub preparePrevious()
        If nextBtn.Enabled = False Then nextBtn.Enabled = True
        remainingCount.Text = (CInt(remainingCount.Text) + 1).ToString
        current_student_index -= 1
        If current_student_index = 0 Then prevBtn.Enabled = False
        prepareData()
    End Sub

    Private Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        prepareNext()
    End Sub

    Private Sub prevBtn_Click(sender As Object, e As EventArgs) Handles prevBtn.Click
        preparePrevious()
    End Sub

    Private Function checkIfSubjMarksEntered(student_id As String, terminal As String, class_name As String, subj_key As String) As Boolean
        Dim present As Boolean = False

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "SELECT * from results_" & class_name.ToString & " where student_id=" & student_id & " and terminal = '" & terminal & "' and " & subj_key & "_th <> 0"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count
            If rowCount > 0 Then present = True
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try

        Return present
    End Function
End Class