Imports System.Data
Imports System.Data.OleDb
Public Class addResultSecForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Public contents As String() = {}

    'if edit - {student_id, year, school_name, className, terminal, edit=TRUE}
    '{class_id, year, school_name, className, terminal="", edit=FALSE}
    Public Sub New(params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        contents = params
        Dim edit = params(5)
        If edit = "FALSE" Then
            loadRegNumber(params)
        Else
            ReDim Preserve contents(7)
            contents(7) = contents(0)
            studentRegCombo.Enabled = False
            termCombo.Text = contents(4)
            loadResult(params)
        End If
    End Sub


    Private Sub studentRegCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles studentRegCombo.SelectedIndexChanged
        findStudentName()
    End Sub

    Public Sub findStudentName()
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = ""
        SQL = "SELECT f_name, m_name, l_name, id from student where reg_number = '" & studentRegCombo.Text & "'"

        Dim DS = New DataSet
        Try
            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim present As Boolean
            present = checkIfPresent(DS.Tables(0).Rows(0)(3).ToString, termCombo.Text, contents(3))

            If present = True Then
                MessageBox.Show("Record is already present. please check.", "Duplicate record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'save student_id
            ReDim Preserve contents(7)
            contents(7) = DS.Tables(0).Rows(0)(3).ToString

            Dim Val = DS.Tables(0).Rows(0)(0).ToString & " " & DS.Tables(0).Rows(0)(1).ToString & " " & DS.Tables(0).Rows(0)(2).ToString
            studentName.Text = Val

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Public Sub loadRegNumber(params As String())
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
                    where c.class_id =" & params(0) & ") tb
                    on s.id = tb.student_id"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count

            For i As Integer = 0 To rowCount - 1
                Dim Val = DS.Tables(0).Rows(i)(1).ToString
                studentRegCombo.Items.Add(Val)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    'if edit - {student_id, year, school_name, className, terminal, TRUE}
    Public Sub loadResult(params As String())
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim textBoxes As TextBox() = {studentName, engTh, engPr, nepTh, nepPr, mathTh, mathPr, sciTh, sciPr, socTh, socPr, ephTh, ephPr, opt1Th, opt1Pr, opt2Th, opt2Pr, attendance}

        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim className = contents(3)
        Dim student_id = contents(0)
        Dim terminal = contents(4)
        Try
            SQL = "SELECT reg_number, full_name, eng_th, eng_pr, nep_th, nep_pr, math_th, math_pr, sci_th, sci_pr, soc_th, soc_pr, eph_th, eph_pr, opt1_th, opt1_pr, opt2_th, opt2_pr, opt1, opt2, attendance
                    FROM 
                    results_" & className & " where student_id=" & student_id & " and terminal = '" & terminal & "'"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            For i As Integer = 1 To textBoxes.Count
                textBoxes(i - 1).Text = DS.Tables(0).Rows(0)(i).ToString
            Next

            studentRegCombo.Text = DS.Tables(0).Rows(0)(0).ToString

            opt1Combo.Text = DS.Tables(0).Rows(0)(19).ToString
            opt2Combo.Text = DS.Tables(0).Rows(0)(20).ToString
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Public Function checkIfPresent(student_id As String, terminal As String, class_name As String) As Boolean
        Dim present As Boolean = False

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "SELECT * from results_" & class_name & " where student_id=" & student_id & " and terminal = '" & terminal & "'"

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If termCombo.SelectedIndex = -1 Then
            errorMsg.Text = "Please select a terminal."
            Exit Sub
        ElseIf contents(5) = "FALSE" And studentRegCombo.SelectedIndex = -1 Then
            errorMsg.Text = "Please select a student registration number."
            Exit Sub
        ElseIf contents(5) = "FALSE" And opt1Combo.SelectedIndex = -1 Then
            errorMsg.Text = "Please select opt1 subject."
            Exit Sub
        ElseIf contents(5) = "FALSE" And opt2Combo.SelectedIndex = -1 Then
            errorMsg.Text = "Please select opt2 subject."
            Exit Sub
        Else
            errorMsg.Text = ""
        End If

        If opt2Combo.Text = "Computer" And (CDbl(opt2Th.Text) > 50 Or CDbl(opt2Pr.Text) > 50) Then
            MessageBox.Show("Comp_th or Comp_pr value can't be more than 50. Please check.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf opt2Combo.Text <> "Computer" And (CDbl(opt2Th.Text) > 75 Or CDbl(opt2Pr.Text) > 25) Then
            MessageBox.Show("Opt2_th or opt2_pr value is more than full marks. Please check.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim textBoxes As TextBox() = {engTh, engPr, nepTh, nepPr, mathTh, mathPr, sciTh, sciPr, socTh, socPr, ephTh, ephPr, opt1Th, opt1Pr, opt2Th, opt2Pr, presentDays, totalDays, attendance}

        Dim valid As Boolean = checkNumberValidity(textBoxes)

        If valid = False Then
            MessageBox.Show("You must enter a Number.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim terminal = termCombo.Text
        Dim class_name = contents(3)

        Dim hashKeys As String() = {"student_id", "reg_number", "full_name", "school_year", "school_name", "terminal", "eng_th", "eng_th_g", "eng_pr", "eng_pr_g", "eng_total", "eng_total_g", "nep_th", "nep_th_g", "nep_pr",
            "nep_pr_g", "nep_total", "nep_total_g", "math_th", "math_th_g", "math_pr", "math_pr_g", "math_total", "math_total_g", "sci_th", "sci_th_g", "sci_pr", "sci_pr_g", "sci_total", "sci_total_g",
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "eph_th", "eph_th_g", "eph_pr", "eph_pr_g", "eph_total", "eph_total_g", "opt1_th", "opt1_th_g", "opt1_pr", "opt1_pr_g",
            "opt1_total", "opt1_total_g", "opt2_th", "opt2_th_g", "opt2_pr", "opt2_pr_g", "opt2_total", "opt2_total_g",
            "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point", "opt1", "opt2", "attendance"}


        Dim inputHash = prepareInputHash()

        Dim newInputHash As Hashtable = calculateGrades(inputHash)

        Try
            Dim insertSQL As String = "INSERT INTO results_" & class_name & " ([student_id], [reg_number], [full_name], [school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[eph_th],[eph_th_g],[eph_pr],[eph_pr_g],[eph_total],[eph_total_g],[opt1_th],[opt1_th_g],[opt1_pr],[opt1_pr_g],[opt1_total],[opt1_total_g],
[opt2_th],[opt2_th_g],[opt2_pr],[opt2_pr_g],[opt2_total],[opt2_total_g],[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [opt1], [opt2], [attendance]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @eph_th, @eph_th_g, @eph_pr, @eph_pr_g, @eph_total, @eph_total_g, @opt1_th, @opt1_th_g, @opt1_pr, @opt1_pr_g, @opt1_total, @opt1_total_g, 
@opt2_th, @opt2_th_g, @opt2_pr, @opt2_pr_g, @opt2_total, @opt2_total_g, @total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @opt1, @opt2, @attendance)"


            Dim edit = contents(5)
            If edit = "TRUE" Then insertSQL = buildUpdateResultSQL(Con)

            Con.Open()
            Dim cmd As New OleDbCommand(insertSQL, Con)


            For Each key As String In hashKeys
                cmd.Parameters.AddWithValue("@" & key, newInputHash(key).ToString)
            Next
            'cmd.Parameters.AddWithValue("@opt1", opt1Combo.Text)
            'cmd.Parameters.AddWithValue("@opt2", opt2Combo.Text)
            cmd.ExecuteNonQuery()

            Dim I As Integer = MsgBox("Insert Successful", MsgBoxStyle.Information, "INSERTED")
            If I = MsgBoxResult.Ok Then
                If sequenceCheckBox.Checked Then
                    'MsgBox("sequence selected")
                    prepareNext(textBoxes)
                ElseIf edit = "TRUE" Then
                    Me.Close()
                Else
                    For j As Integer = 0 To textBoxes.Count - 1
                        textBoxes(j).Text = "0"
                    Next
                    termCombo.Text = ""
                    studentRegCombo.Text = ""
                    studentName.Text = ""
                    opt1Combo.Text = ""
                    opt2Combo.Text = ""
                End If
            End If

            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
            'AddTable()
        End Try
    End Sub

    Public Function buildUpdateResultSQL(con As OleDbConnection) As String
        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim oData As OleDbDataAdapter
        Dim insertSQL = ""

        Dim rankSQL As String = "SELECT id from results_" & contents(3) & " where school_name='" & contents(2) & "' and school_year ='" & contents(1) &
    "' and terminal = '" & termCombo.Text & "' and student_id=" & contents(0)


        con.Open()
        oData = New OleDbDataAdapter(rankSQL, con)
        con.Close()
        oData.Fill(DS)
        Dim rowID = CInt(DS.Tables(0).Rows(0)(0))

        insertSQL = "UPDATE results_" & contents(3) & "
                     SET 
                    student_id = @student_id, reg_number = @reg_number, full_name = @full_name, school_year = @school_year, school_name = @school_name, terminal = @terminal, eng_th = @eng_th, eng_th_g = @eng_th_g, eng_pr = @eng_pr, eng_pr_g = @eng_pr_g, eng_total = @eng_total, eng_total_g = @eng_total_g, 
                    nep_th = @nep_th, nep_th_g = @nep_th_g, nep_pr = @nep_pr, nep_pr_g = @nep_pr_g, nep_total = @nep_total, nep_total_g = @nep_total_g, math_th = @math_th, math_th_g = @math_th_g, math_pr = @math_pr, math_pr_g = @math_pr_g, math_total = @math_total, math_total_g = @math_total_g, 
                    sci_th = @sci_th, sci_th_g = @sci_th_g, sci_pr = @sci_pr, sci_pr_g = @sci_pr_g, sci_total = @sci_total, sci_total_g = @sci_total_g, soc_th = @soc_th, soc_th_g = @soc_th_g, soc_pr = @soc_pr, soc_pr_g = @soc_pr_g, soc_total = @soc_total, soc_total_g = @soc_total_g,
                    eph_th = @eph_th, eph_th_g = @eph_th_g, eph_pr = @eph_pr, eph_pr_g = @eph_pr_g, eph_total = @eph_total, eph_total_g = @eph_total_g, opt1_th = @opt1_th, opt1_th_g = @opt1_th_g, opt1_pr = @opt1_pr, opt1_pr_g = @opt1_pr_g, opt1_total = @opt1_total, opt1_total_g = @opt1_total_g, 
                    opt2_th = @opt2_th, opt2_th_g = @opt2_th_g, opt2_pr = @opt2_pr, opt2_pr_g = @opt2_pr_g, opt2_total = @opt2_total, opt2_total_g = @opt2_total_g, total_th = @total_th, total_th_g = @total_th_g, total_pr = @total_pr, total_pr_g = @total_pr_g, total = @total, 
                    percentage = @percentage, grade = @grade, grade_point = @grade_point, opt1 = @opt1, opt2 = @opt2, attendance= @attendance 
                    WHERE id=" & rowID

        Return insertSQL
    End Function


    Public Function checkNumberValidity(textboxes As TextBox()) As Boolean
        For i As Integer = 0 To textboxes.Count - 1
            If Not IsNumeric(textboxes(i).Text) Or textboxes(i).Text = "" Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function prepareInputHash() As Hashtable
        Dim inputHash As Hashtable = New Hashtable
        Dim total_th = CDbl(engTh.Text) + CDbl(nepTh.Text) + CDbl(mathTh.Text) + CDbl(sciTh.Text) + CDbl(socTh.Text) + CDbl(ephTh.Text) + CDbl(opt1Th.Text) + CDbl(opt2Th.Text)

        Dim total_pr = CDbl(engPr.Text) + CDbl(nepPr.Text) + CDbl(mathPr.Text) + CDbl(sciPr.Text) + CDbl(socPr.Text) + CDbl(ephPr.Text) + CDbl(opt1Pr.Text) + CDbl(opt2Pr.Text)

        inputHash("opt1") = opt1Combo.Text
        inputHash("opt2") = opt2Combo.Text

        Dim total_th_marks = 625
        Dim total_pr_marks = 175

        If inputHash("opt2").ToString = "Computer" Then
            total_th_marks = 600
            total_pr_marks = 200
        End If
        Dim total_th_perc = total_th / total_th_marks * 100
        Dim total_pr_perc = total_pr / total_pr_marks * 100
        Dim total = total_th + total_pr
        Dim percentage = total / 800 * 100

        inputHash("student_id") = contents(7)
        inputHash("reg_number") = studentRegCombo.Text
        inputHash("full_name") = studentName.Text
        inputHash("school_year") = contents(1)
        inputHash("school_name") = contents(2)
        inputHash("terminal") = termCombo.Text
        inputHash("eng_th") = engTh.Text
        inputHash("eng_pr") = engPr.Text
        inputHash("eng_total") = CDbl(engTh.Text) + CDbl(engPr.Text)
        inputHash("nep_th") = nepTh.Text
        inputHash("nep_pr") = nepPr.Text
        inputHash("nep_total") = CDbl(nepTh.Text) + CDbl(nepPr.Text)
        inputHash("math_th") = mathTh.Text
        inputHash("math_pr") = mathPr.Text
        inputHash("math_total") = CDbl(mathTh.Text) + CDbl(mathPr.Text)
        inputHash("sci_th") = sciTh.Text
        inputHash("sci_pr") = sciPr.Text
        inputHash("sci_total") = CDbl(sciTh.Text) + CDbl(sciPr.Text)
        inputHash("soc_th") = socTh.Text
        inputHash("soc_pr") = socPr.Text
        inputHash("soc_total") = CDbl(socTh.Text) + CDbl(socPr.Text)
        inputHash("eph_th") = ephTh.Text
        inputHash("eph_pr") = ephPr.Text
        inputHash("eph_total") = CDbl(ephTh.Text) + CDbl(ephPr.Text)
        inputHash("opt1_th") = opt1Th.Text
        inputHash("opt1_pr") = opt1Pr.Text
        inputHash("opt1_total") = CDbl(opt1Th.Text) + CDbl(opt1Pr.Text)
        inputHash("opt2_th") = opt2Th.Text
        inputHash("opt2_pr") = opt2Pr.Text
        inputHash("opt2_total") = CDbl(opt2Th.Text) + CDbl(opt2Pr.Text)
        inputHash("total_th") = total_th
        inputHash("total_th_perc") = total_th_perc
        inputHash("total_pr") = total_pr
        inputHash("total_pr_perc") = total_pr_perc
        inputHash("total") = total
        inputHash("percentage") = Math.Round(percentage, 2)
        inputHash("attendance") = calculateAttendancePerc()

        Return inputHash
    End Function

    Private Sub attenPercTextBox_Focus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles attendance.Enter
        Me.attendance.Text = calculateAttendancePerc().ToString
    End Sub

    Private Sub attenPercTextBox_MouseClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles attendance.MouseClick
        Me.attendance.Text = calculateAttendancePerc().ToString
    End Sub

    Public Function calculateAttendancePerc() As Double
        Dim total_days As Double
        Dim attend_perc As Double
        If totalDays.Text = "0" Then total_days = 1 Else total_days = CDbl(totalDays.Text)
        attend_perc = CDbl(presentDays.Text) / total_days * 100
        Return Math.Round(attend_perc, 2)
    End Function

    Public Function calculateGrades(inputHash As Hashtable) As Hashtable

        Dim theorySub = {"eng_th", "nep_th", "math_th", "sci_th", "soc_th", "eph_th", "opt1_th", "opt2_th"}
        Dim pracSub = {"eng_pr", "nep_pr", "math_pr", "sci_pr", "soc_pr", "eph_pr", "opt1_pr", "opt2_pr"}
        Dim totalSub = {"eng_total", "nep_total", "math_total", "sci_total", "soc_total", "eph_total", "opt1_total", "opt2_total"}
        Dim grade As String = ""
        Dim percentage As Double = 0
        Dim grade_point As Double = 0
        Dim opt1 = inputHash("opt1")
        Dim opt2 = inputHash("opt2")

        For Each subj As String In theorySub
            If subj = "math_th" Then
                percentage = CDbl(inputHash(subj))
            ElseIf (subj = "opt2_th" And opt2.ToString = "Computer") Or subj = "eph_th" Then
                percentage = CDbl(inputHash(subj)) / 50 * 100
            Else
                percentage = CDbl(inputHash(subj)) / 75 * 100
            End If

            grade = percentToGrade(percentage)
            inputHash(subj & "_g") = grade
        Next

        For Each subj As String In pracSub
            If (subj = "opt2_pr" And opt2.ToString = "Computer") Or subj = "eph_pr" Then
                percentage = CDbl(inputHash(subj)) / 50 * 100
            Else
                percentage = CDbl(inputHash(subj)) / 25 * 100
            End If

            grade = percentToGrade(percentage)
            inputHash(subj & "_g") = grade
        Next

        For Each subj As String In totalSub
            percentage = CDbl(inputHash(subj))

            grade = percentToGrade(percentage)
            inputHash(subj & "_g") = grade
            grade_point = percentToGradePoint(percentage)
            inputHash(subj & "_gp") = grade_point
        Next

        inputHash("total_th_g") = percentToGrade(CDbl(inputHash("total_th_perc")))
        inputHash("total_pr_g") = percentToGrade(CDbl(inputHash("total_pr_perc")))
        Dim avg_grade_point As Double = calculateGradePoint(inputHash)
        inputHash("grade_point") = Math.Round(avg_grade_point, 2)
        inputHash("grade") = gradePointToGrade(CDbl(inputHash("grade_point")))
        Return inputHash
    End Function

    Public Function percentToGrade(percentage As Double) As String
        Dim grade As String
        If percentage >= 90 Then
            grade = "A+"
        ElseIf percentage >= 80 Then
            grade = "A"
        ElseIf percentage >= 70 Then
            grade = "B+"
        ElseIf percentage >= 60 Then
            grade = "B"
        ElseIf percentage >= 50 Then
            grade = "C+"
        ElseIf percentage >= 40 Then
            grade = "C"
        ElseIf percentage >= 30 Then
            grade = "D+"
        ElseIf percentage >= 20 Then
            grade = "D"
        ElseIf percentage > 0 Then
            grade = "E"
        Else
            grade = "NG"
        End If
        Return grade
    End Function

    Public Function percentToGradePoint(percentage As Double) As Double
        Dim gradePoint As Double
        If percentage >= 90 Then
            gradePoint = 4
        ElseIf percentage >= 80 Then
            gradePoint = 3.6
        ElseIf percentage >= 70 Then
            gradePoint = 3.2
        ElseIf percentage >= 60 Then
            gradePoint = 2.8
        ElseIf percentage >= 50 Then
            gradePoint = 2.4
        ElseIf percentage >= 40 Then
            gradePoint = 2
        ElseIf percentage >= 30 Then
            gradePoint = 1.6
        ElseIf percentage >= 20 Then
            gradePoint = 1.2
        ElseIf percentage >= 0 Then
            gradePoint = 0.8
        Else
            gradePoint = 0
        End If
        Return gradePoint
    End Function

    Public Function gradePointToGrade(gradePoint As Double) As String
        Dim grade As String
        If gradePoint >= 3.6 Then
            grade = "A+"
        ElseIf gradePoint >= 3.2 Then
            grade = "A"
        ElseIf gradePoint >= 2.8 Then
            grade = "B+"
        ElseIf gradePoint >= 2.4 Then
            grade = "B"
        ElseIf gradePoint >= 2 Then
            grade = "C+"
        ElseIf gradePoint >= 1.6 Then
            grade = "C"
        ElseIf gradePoint >= 1.2 Then
            grade = "D+"
        ElseIf gradePoint >= 0.8 Then
            grade = "D"
        ElseIf gradePoint > 0 And gradePoint < 0.8 Then
            grade = "E"
        Else
            grade = "NG"
        End If
        Return grade
    End Function

    Function calculateGradePoint(inputHash As Hashtable) As Double
        Dim totalGradePoint As Double = 0
        Dim avgGP As Double = 0
        Dim totalSub = {"eng_total", "nep_total", "math_total", "sci_total", "soc_total", "eph_total", "opt1_total", "opt2_total"}

        For Each key As String In totalSub
            totalGradePoint = totalGradePoint + CDbl(inputHash(key & "_gp"))
        Next
        avgGP = totalGradePoint / totalSub.Count
        Return avgGP
    End Function


    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub

    Public Sub prepareNext(textboxes As TextBox())
        For i As Integer = 0 To textboxes.Count - 1
            textboxes(i).Text = "0"
        Next
        opt1Combo.Text = ""
        opt2Combo.Text = ""

        'find next student whose result is not added
        findNext()

    End Sub

    Public Sub findNext()
        Dim className = contents(3)
        Dim terminal = termCombo.Text
        Dim school_year = contents(1)
        Dim school_name = contents(2)

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "select * from class_student
where class_id = " & contents(0) & " and student_id not in
(select r.student_id from 
results_" & className & " r
inner join
(SELECT * from 
student s
INNER JOIN
(SELECT student_id from 
class c
INNER JOIN
class_student cs
on c.class_id = cs.class_id
where c.class_id = " & contents(0) & ") tb
on s.id = tb.student_id) temp
on r.student_id = temp.student_id
where r.terminal='" & terminal & "'
order by r.student_id asc)
order by student_id"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            If DS.Tables(0).Rows.Count = 0 Then
                Dim I As Integer = MessageBox.Show("Yay!! You have successfully entered result of every student.", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If I = MsgBoxResult.Ok Then
                    Me.Close()
                End If
            End If

            'find the student reg_number and name
            SQL = "SELECT  f_name, m_name, l_name, reg_number from student where id = " & DS.Tables(0).Rows(0)(2).ToString & ""

            Con.Open() 'Open connection

            DS.Tables.Clear()
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)
            Dim Val = DS.Tables(0).Rows(0)(3).ToString
            studentRegCombo.Text = Val

            Dim student_name = DS.Tables(0).Rows(0)(0).ToString & " " & DS.Tables(0).Rows(0)(1).ToString & " " & DS.Tables(0).Rows(0)(2).ToString
            studentName.Text = student_name

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub opt2Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles opt2Combo.SelectedIndexChanged
        If opt2Combo.Text = "Computer" Then
            opt2FM.Text = "/50"
            opt2PM.Text = "/50"
        Else
            opt2FM.Text = "/75"
            opt2PM.Text = "/25"
        End If
    End Sub
End Class