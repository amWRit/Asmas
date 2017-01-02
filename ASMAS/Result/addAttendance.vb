Imports System.Data
Imports System.Data.OleDb

Public Class addAttendance
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Public student_ids As Integer() = {}
    Public current_student_id As String = ""
    Public current_student_index As Integer = 0
    Public class_params As String() = {}
    Public present As Boolean = False

    Public Sub New(params As String())
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        class_params = params
        Dim class_id = params(0)
        Dim class_name = params(3)
        'find student ids
        student_ids = myFunctions.getStudentIdsOf(class_id)
        remainingCount.Text = student_ids.Count.ToString
        'load first student to the form
        current_student_id = student_ids.First.ToString
        loadStudentInfo(CInt(current_student_id))
    End Sub

    Public Sub loadStudentInfo(student_id As Integer)
        Dim studentInfo As String() = myFunctions.getStudentInfoOf(student_id) '{reg_number, student_name}
        Dim reg_number = studentInfo(0)
        Dim student_name = studentInfo(1)
        regNumberTextBox.Text = reg_number
        studentNameTextBox.Text = student_name
    End Sub

    Private Sub termCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles termCombo.SelectedIndexChanged
        Dim terminal = termCombo.Text
        Dim class_name = class_params(3)
        Dim school_year = class_params(1)
        Dim school_name = class_params(2)
        present = resultFunctions.checkIfPresent(school_name, school_year, current_student_id, terminal, class_name)

        Dim params As String() = {school_year, school_name, class_name, terminal, current_student_id}
        Dim checkAtt = checkIfAttendanceEntered(params)

        If present = True And checkAtt = True Then
            loadAttendance(params)
        Else
            'presentCheckLabel.Text = "No"
            'presentCheckLabel.ForeColor = Color.Red
            presentDays.Text = "0"
            percAtt.Text = "0"
        End If
        prevBtn.Enabled = True
        nextBtn.Enabled = True
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

    Public Sub prepareData()
        termCombo.Enabled = False
        'totalDays.Enabled = False

        If current_student_index > student_ids.Count - 1 Then
            MessageBox.Show("Yay! You have entered attendance of all the students.", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            saveBtn.Enabled = False
            Exit Sub
        End If

        current_student_id = student_ids(current_student_index).ToString
        loadStudentInfo(CInt(current_student_id))

        Dim terminal = termCombo.Text
        Dim class_name = class_params(3)
        Dim school_year = class_params(1)
        Dim school_name = class_params(2)
        Dim params As String() = {school_year, school_name, class_name, terminal, current_student_id}
        present = resultFunctions.checkIfPresent(school_name, school_year, current_student_id, terminal, class_name)
        Dim attEntered = checkIfAttendanceEntered(params)

        If attEntered = True Then
            'presentCheckLabel.Text = "Yes"
            'presentCheckLabel.ForeColor = Color.ForestGreen
            If present = True Then loadAttendance(params)
        Else
            'presentCheckLabel.Text = "No"
            'presentCheckLabel.ForeColor = Color.Red
            presentDays.Text = "0"
            percAtt.Text = "0"
        End If

    End Sub

    'params = {school_year, school_name, class_name, terminal, current_student_id, subjkey}
    Private Function checkIfAttendanceEntered(params As String()) As Boolean
        Dim present As Boolean = False

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim school_year = params(0)
        Dim school_name = params(1)
        Dim class_name = params(2)
        Dim terminal = params(3)
        Dim student_id = params(4)

        Try
            SQL = "SELECT * from results_" & class_name.ToString & " where student_id=" & student_id & " and school_name='" & school_name & "' and school_year= '" & school_year & "' and terminal = '" & terminal & "' and  attendance <> 0"

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

    'params = {school_year, school_name, class_name, terminal, current_student_id, subjkey}
    Public Sub loadAttendance(params As String())
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim school_year = params(0)
        Dim school_name = params(1)
        Dim class_name = params(2)
        Dim terminal = params(3)
        Dim student_id = params(4)
        Try
            SQL = "SELECT attendance FROM results_" & class_name & " where student_id=" & student_id & " and school_name='" & school_name & "' and school_year= '" & school_year & "' and terminal = '" & terminal & "'"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            percAtt.Text = DS.Tables(0).Rows(0)(0).ToString 'attendance percentage
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub


    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If totalDays.Text = "0" Or termCombo.SelectedIndex = -1 Then
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
        'Dim present As Boolean = False
        'present = resultFunctions.checkIfPresent(current_student_id, terminal, class_name)
        'if present, update, else add new
        Dim attSQL = ""

        attSQL = "INSERT INTO results_" & class_name & " ([student_id], [reg_number], [full_name], [school_year],[school_name],[terminal], [attendance])
                            VALUES
                            (@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @attendance)"


        Dim command = "INSERTED"
        Try
            Con.Open()
            Dim percAttendance As Double = 0
            percAttendance = calculateAttendancePerc()
            If present = True Then
                'get update sql
                command = "UPDATED"
                Dim rowID = resultFunctions.getStudentResultRowID(school_year, school_name, terminal, class_name, current_student_id)
                attSQL = "UPDATE results_" & class_name & " SET attendance = " & percAttendance & " WHERE id=" & rowID
            End If

            Dim cmd As New OleDbCommand(attSQL, Con)

            If present = False Then
                cmd.Parameters.AddWithValue("@student_id", current_student_id)
                cmd.Parameters.AddWithValue("@reg_number", regNumberTextBox.Text)
                cmd.Parameters.AddWithValue("@full_name", studentNameTextBox.Text)
                cmd.Parameters.AddWithValue("@school_year", school_year)
                cmd.Parameters.AddWithValue("@school_name", school_name)
                cmd.Parameters.AddWithValue("@terminal", terminal)
            End If
            percAtt.Text = percAttendance.ToString
            'cmd.Parameters.AddWithValue("@attendance", percAttendance)
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
        presentDays.Focus()
    End Sub


    Private Sub attenPercTextBox_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles percAtt.Enter
        Me.percAtt.Text = calculateAttendancePerc().ToString
    End Sub

    Private Sub attenPercTextBox_MouseClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles percAtt.MouseClick
        Me.percAtt.Text = calculateAttendancePerc().ToString
    End Sub

    Public Function calculateAttendancePerc() As Double
        Dim total_days As Double
        Dim attend_perc As Double
        If totalDays.Text = "0" Then total_days = 1 Else total_days = CDbl(totalDays.Text)
        attend_perc = CDbl(presentDays.Text) / total_days * 100
        Return Math.Round(attend_perc, 2)
    End Function

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Hide()
        myClassesForm.Show()
    End Sub
End Class