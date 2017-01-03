Imports System.Data
Imports System.Data.OleDb
Public Class resultFunctions
    Private Shared data_source_path As String = DBConnection.data_source_path
    Public Shared Con As System.Data.OleDb.OleDbConnection

    Public Shared contents As String() = {}
    Public Shared lowPrimary As String() = {"1", "2", "3"}
    Public Shared highPrimary As String() = {"4", "5"}
    Public Shared primary As String() = TheClass.primaryShortNames
    Public Shared lowSec As String() = TheClass.lowSecShortNames
    Public Shared sec As String() = TheClass.secShortNames

    Public Shared Function getRegNumber(params As String()) As DataSet
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

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
        Return DS
    End Function

    Public Shared Sub loadRegNumber(regNumberCollection As DataSet, studentRegCombo As ComboBox)
        Dim rowCount = regNumberCollection.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = regNumberCollection.Tables(0).Rows(i)(1).ToString
            studentRegCombo.Items.Add(Val)
        Next
    End Sub

    Public Shared Function findStudentName(school_name As String, school_year As String, terminal As String, class_name As String, reg_number As String) As String()
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = ""
        SQL = "SELECT f_name, m_name, l_name, id from student where reg_number = '" & reg_number & "'"


        Dim DS = New DataSet
        Dim studentName As String = ""
        Dim student_id As String = ""
        Try

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)
            studentName = DS.Tables(0).Rows(0)(0).ToString & " " & DS.Tables(0).Rows(0)(1).ToString & " " & DS.Tables(0).Rows(0)(2).ToString

            Dim present As Boolean
            present = checkIfPresent(school_name, school_year, DS.Tables(0).Rows(0)(3).ToString, terminal, class_name)

            If present = True Then
                MessageBox.Show("Record is already present. Please try editing the result instead.", "Duplicate record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return {studentName, "", "present"}
                'Exit Function
            End If
            'save student_id
            'ReDim Preserve contents(7)
            student_id = DS.Tables(0).Rows(0)(3).ToString


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
        Return {studentName, student_id, "absent"}
    End Function

    Public Shared Function checkIfPresent(school_name As String, school_year As String, student_id As String, terminal As String, class_name As String) As Boolean
        Dim present As Boolean = False

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "SELECT * from results_" & class_name.ToString & " where student_id=" & student_id & " and school_name='" & school_name & "' and school_year= '" & school_year & "' and terminal='" & terminal & "'"

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

    Public Shared Function getResultTableHashKeys(ByVal className As String) As String()
        Dim lowSecHashKeys As String() = {"student_id", "reg_number", "full_name", "school_year", "school_name", "terminal", "eng_th", "eng_th_g", "eng_pr", "eng_pr_g", "eng_total", "eng_total_g", "nep_th", "nep_th_g", "nep_pr",
            "nep_pr_g", "nep_total", "nep_total_g", "math_th", "math_th_g", "math_pr", "math_pr_g", "math_total", "math_total_g", "sci_th", "sci_th_g", "sci_pr", "sci_pr_g", "sci_total", "sci_total_g",
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "obt_th", "obt_th_g", "obt_pr", "obt_pr_g", "obt_total", "obt_total_g", "comp_th", "comp_th_g", "comp_pr", "comp_pr_g",
            "comp_total", "comp_total_g", "hea_th", "hea_th_g", "hea_pr", "hea_pr_g", "hea_total", "hea_total_g", "mor_th", "mor_th_g", "mor_pr", "mor_pr_g", "mor_total", "mor_total_g",
            "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point", "attendance"}
        Dim primaryHashKeys As String() = {"student_id", "reg_number", "full_name", "school_year", "school_name", "terminal", "eng_th", "eng_th_g", "eng_pr", "eng_pr_g", "eng_total", "eng_total_g", "nep_th", "nep_th_g", "nep_pr",
            "nep_pr_g", "nep_total", "nep_total_g", "math_th", "math_th_g", "math_pr", "math_pr_g", "math_total", "math_total_g", "sci_th", "sci_th_g", "sci_pr", "sci_pr_g", "sci_total", "sci_total_g",
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "opt_eng_th", "opt_eng_th_g", "opt_eng_pr", "opt_eng_pr_g", "opt_eng_total", "opt_eng_total_g", "gk_conv_th", "gk_conv_th_g", "gk_conv_pr", "gk_conv_pr_g",
            "gk_conv_total", "gk_conv_total_g", "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point", "attendance"}
        Dim SecHashKeys As String() = {"student_id", "reg_number", "full_name", "school_year", "school_name", "terminal", "eng_th", "eng_th_g", "eng_pr", "eng_pr_g", "eng_total", "eng_total_g", "nep_th", "nep_th_g", "nep_pr",
            "nep_pr_g", "nep_total", "nep_total_g", "math_th", "math_th_g", "math_pr", "math_pr_g", "math_total", "math_total_g", "sci_th", "sci_th_g", "sci_pr", "sci_pr_g", "sci_total", "sci_total_g",
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "eph_th", "eph_th_g", "eph_pr", "eph_pr_g", "eph_total", "eph_total_g", "opt1_th", "opt1_th_g", "opt1_pr", "opt1_pr_g",
            "opt1_total", "opt1_total_g", "opt2_th", "opt2_th_g", "opt2_pr", "opt2_pr_g", "opt2_total", "opt2_total_g",
            "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point", "opt1", "opt2", "attendance"}

        Dim hashKeys As String() = {}
        Dim primary As String() = TheClass.primaryShortNames
        Dim lowSec As String() = TheClass.lowSecShortNames
        Dim sec As String() = TheClass.secShortNames

        If primary.Contains(className) Then
            hashKeys = primaryHashKeys
        ElseIf lowSec.Contains(className) Then
            hashKeys = lowSecHashKeys
        ElseIf sec.Contains(className) Then
            hashKeys = SecHashKeys
        End If

        Return hashKeys
    End Function

    Public Shared Function percentToGrade(percentage As Double) As String
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

    Public Shared Function percentToGradePoint(percentage As Double) As Double
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
        ElseIf percentage > 0 Then
            gradePoint = 0.8
        Else
            gradePoint = 0
        End If
        Return gradePoint
    End Function

    Public Shared Function gradePointToGrade(gradePoint As Double) As String
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

    Public Shared Function calculateGrades(inputHash As Hashtable, class_name As String) As Hashtable

        Dim grade As String = ""
        Dim percentage As Double = 0
        Dim grade_point As Double = 0
        'for low primary
        Dim th_marks = 100
        Dim pr_marks = 1 'to avoid 0/0 error

        'If highPrimary.Contains(class_name) Then
        '    th_marks = 60
        '    pr_marks = 40
        'ElseIf lowSec.Contains(class_name) Or sec.Contains(class_name) Then
        '    th_marks = 75
        '    pr_marks = 25
        'End If

        Dim theorySub = getSubjects("theory", class_name)
        Dim pracSub = getSubjects("prac", class_name)
        Dim totalSub = getSubjects("total", class_name)

        For Each subj As String In theorySub
            If (lowSec.Contains(class_name) Or sec.Contains(class_name)) And subj = "math_th" Then
                th_marks = 100
            ElseIf lowSec.Contains(class_name) Then
                If subj = "obt_th" Or subj = "comp_th" Then
                    th_marks = 50
                ElseIf subj = "hea_th" Then
                    th_marks = 30
                ElseIf subj = "mor_th" Then
                    th_marks = 25
                Else
                    th_marks = 75
                End If
            ElseIf sec.Contains(class_name) Then
                If subj = "opt1_th" Then
                    th_marks = 100
                ElseIf subj = "opt2_th" And inputHash("opt2").ToString = "Computer" Then
                    th_marks = 50
                Else
                    th_marks = 75
                End If
            End If

            percentage = CDbl(inputHash(subj)) / th_marks * 100

            grade = resultFunctions.percentToGrade(percentage)
            inputHash(subj & "_g") = grade
        Next

        For Each subj As String In pracSub
            If (lowSec.Contains(class_name) Or sec.Contains(class_name)) And subj = "math_pr" Then
                pr_marks = 1 'to avoid 0/0 error
            ElseIf lowSec.Contains(class_name) Then
                If subj = "obt_pr" Or subj = "comp_pr" Then
                    pr_marks = 50
                ElseIf subj = "hea_pr" Then
                    pr_marks = 20
                ElseIf subj = "mor_pr" Then
                    pr_marks = 25
                Else
                    pr_marks = 25
                End If
            ElseIf sec.Contains(class_name) Then
                If subj = "opt1_pr" Then
                    pr_marks = 1 'to avoid 0/0 error
                ElseIf subj = "opt2_pr" And inputHash("opt2").ToString = "Computer" Then
                    pr_marks = 50
                Else
                    pr_marks = 25
                End If
            End If

            percentage = CDbl(inputHash(subj)) / pr_marks * 100

            grade = resultFunctions.percentToGrade(percentage)
            inputHash(subj & "_g") = grade
        Next

        For Each subj As String In totalSub
            percentage = CDbl(inputHash(subj))
            If lowSec.Contains(class_name) Then
                If subj = "mor_total" Or subj = "hea_total" Then
                    percentage = CDbl(inputHash(subj)) / 50 * 100
                End If
            End If

            grade = resultFunctions.percentToGrade(percentage)
            inputHash(subj & "_g") = grade
            grade_point = resultFunctions.percentToGradePoint(percentage)
            inputHash(subj & "_gp") = grade_point
        Next

        inputHash("total_th_g") = resultFunctions.percentToGrade(CDbl(inputHash("total_th_perc")))
        inputHash("total_pr_g") = resultFunctions.percentToGrade(CDbl(inputHash("total_pr_perc")))
        Dim avg_grade_point As Double = resultFunctions.calculateGradePoint(inputHash, class_name)
        inputHash("grade_point") = Math.Round(avg_grade_point, 2)
        inputHash("grade") = resultFunctions.gradePointToGrade(CDbl(inputHash("grade_point")))
        Return inputHash
    End Function

    Public Shared Function calculateGradePoint(inputHash As Hashtable, class_name As String) As Double
        Dim totalGradePoint As Double = 0
        Dim avgGP As Double = 0
        Dim totalSub = getSubjects("total", class_name)

        For Each key As String In totalSub
            totalGradePoint = totalGradePoint + CDbl(inputHash(key & "_gp"))
        Next
        avgGP = totalGradePoint / totalSub.Count
        Return avgGP
    End Function

    Public Shared Function getSubjects(indicator As String, class_name As String) As String()

        Dim theorySub_primary = {"eng_th", "nep_th", "math_th", "sci_th", "soc_th", "opt_eng_th", "gk_conv_th"}
        Dim pracSub_primary = {"eng_pr", "nep_pr", "math_pr", "sci_pr", "soc_pr", "opt_eng_pr", "gk_conv_pr"}
        Dim totalSub_primary = {"eng_total", "nep_total", "math_total", "sci_total", "soc_total", "opt_eng_total", "gk_conv_total"}

        Dim theorySub_lowSec = {"eng_th", "nep_th", "math_th", "sci_th", "soc_th", "obt_th", "comp_th", "hea_th", "mor_th"}
        Dim pracSub_lowSec = {"eng_pr", "nep_pr", "math_pr", "sci_pr", "soc_pr", "obt_pr", "comp_pr", "hea_pr", "mor_pr"}
        Dim totalSub_lowSec = {"eng_total", "nep_total", "math_total", "sci_total", "soc_total", "obt_total", "comp_total", "hea_total", "mor_total"}


        Dim theorySub_sec = {"eng_th", "nep_th", "math_th", "sci_th", "soc_th", "eph_th", "opt1_th", "opt2_th"}
        Dim pracSub_sec = {"eng_pr", "nep_pr", "math_pr", "sci_pr", "soc_pr", "eph_pr", "opt1_pr", "opt2_pr"}
        Dim totalSub_sec = {"eng_total", "nep_total", "math_total", "sci_total", "soc_total", "eph_total", "opt1_total", "opt2_total"}

        If indicator = "theory" Then
            If primary.Contains(class_name) Then
                Return theorySub_primary
            ElseIf lowSec.Contains(class_name) Then
                Return theorySub_lowSec
            ElseIf sec.Contains(class_name) Then
                Return theorySub_sec
            End If
        ElseIf indicator = "prac" Then
            If primary.Contains(class_name) Then
                Return pracSub_primary
            ElseIf lowSec.Contains(class_name) Then
                Return pracSub_lowSec
            ElseIf sec.Contains(class_name) Then
                Return pracSub_sec
            End If
        ElseIf indicator = "total" Then
            If primary.Contains(class_name) Then
                Return totalSub_primary
            ElseIf lowSec.Contains(class_name) Then
                Return totalSub_lowSec
            ElseIf sec.Contains(class_name) Then
                Return totalSub_sec
            End If
        End If
        Return {}
    End Function

    Public Shared Function checkNumberValidity(textboxes As TextBox()) As Boolean
        For i As Integer = 0 To textboxes.Count - 1
            If Not IsNumeric(textboxes(i).Text) Or textboxes(i).Text = "" Then
                Return False
            End If
        Next
        Return True
    End Function

    ' params = {school_year, school_name, terminal, class_name, class_id, student_id}
    Public Shared Function buildUpdateResultSQL(params As String(), con As OleDbConnection) As String
        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim oData As OleDbDataAdapter
        Dim updateSQL = ""

        Dim class_name = params(3)
        Dim terminal = params(2)
        Dim school_year = params(0)
        Dim school_name = params(1)
        Dim student_id = params(4)

        Dim rowSQL As String = "SELECT id from results_" & class_name & " where school_name='" & school_name & "' and school_year ='" & school_year &
    "' and terminal = '" & terminal & "' and student_id=" & student_id

        con.Open()
        oData = New OleDbDataAdapter(rowSQL, con)
        con.Close()
        oData.Fill(DS)
        Dim rowID = CInt(DS.Tables(0).Rows(0)(0))

        updateSQL = getUpdateResultSQL(class_name, rowID)
        Return updateSQL
    End Function

    Public Shared Function getUpdateResultSQL(class_name As String, rowID As Integer) As String

        Dim updateSQL_primary = "UPDATE results_" & class_name & "
                     SET 
                     student_id = @student_id, reg_number = @reg_number, full_name = @full_name, school_year = @school_year, school_name = @school_name, terminal = @terminal, eng_th = @eng_th, eng_th_g = @eng_th_g, eng_pr = @eng_pr, eng_pr_g = @eng_pr_g, eng_total = @eng_total, eng_total_g = @eng_total_g, 
                    nep_th = @nep_th, nep_th_g = @nep_th_g, nep_pr = @nep_pr, nep_pr_g = @nep_pr_g, nep_total = @nep_total, nep_total_g = @nep_total_g, math_th = @math_th, math_th_g = @math_th_g, math_pr = @math_pr, math_pr_g = @math_pr_g, math_total = @math_total, math_total_g = @math_total_g, 
                    sci_th = @sci_th, sci_th_g = @sci_th_g, sci_pr = @sci_pr, sci_pr_g = @sci_pr_g, sci_total = @sci_total, sci_total_g = @sci_total_g, soc_th = @soc_th, soc_th_g = @soc_th_g, soc_pr = @soc_pr, soc_pr_g = @soc_pr_g, soc_total = @soc_total, soc_total_g = @soc_total_g, 
                    opt_eng_th = @opt_eng_th, opt_eng_th_g = @opt_eng_th_g, opt_eng_pr = @opt_eng_pr, opt_eng_pr_g = @opt_eng_pr_g, opt_eng_total = @opt_eng_total, opt_eng_total_g = @opt_eng_total_g, gk_conv_th = @gk_conv_th, gk_conv_th_g = @gk_conv_th_g, gk_conv_pr = @gk_conv_pr, gk_conv_pr_g = @gk_conv_pr_g, gk_conv_total = @gk_conv_total, gk_conv_total_g = @gk_conv_total_g, 
                    total_th = @total_th, total_th_g = @total_th_g, total_pr = @total_pr, total_pr_g = @total_pr_g, total = @total, percentage = @percentage, grade = @grade, grade_point = @grade_point, attendance= @attendance 
                    WHERE id=" & rowID

        Dim updateSQL_lowSec = "UPDATE results_" & class_name & "
                            SET 
                            student_id = @student_id, reg_number = @reg_number, full_name = @full_name, school_year = @school_year, school_name = @school_name, terminal = @terminal, eng_th = @eng_th, eng_th_g = @eng_th_g, eng_pr = @eng_pr, eng_pr_g = @eng_pr_g, eng_total = @eng_total, eng_total_g = @eng_total_g, 
                            nep_th = @nep_th, nep_th_g = @nep_th_g, nep_pr = @nep_pr, nep_pr_g = @nep_pr_g, nep_total = @nep_total, nep_total_g = @nep_total_g, math_th = @math_th, math_th_g = @math_th_g, math_pr = @math_pr, math_pr_g = @math_pr_g, math_total = @math_total, math_total_g = @math_total_g, 
                            sci_th = @sci_th, sci_th_g = @sci_th_g, sci_pr = @sci_pr, sci_pr_g = @sci_pr_g, sci_total = @sci_total, sci_total_g = @sci_total_g, soc_th = @soc_th, soc_th_g = @soc_th_g, soc_pr = @soc_pr, soc_pr_g = @soc_pr_g, soc_total = @soc_total, soc_total_g = @soc_total_g, 
                            obt_th = @obt_th, obt_th_g = @obt_th_g, obt_pr = @obt_pr, obt_pr_g = @obt_pr_g, obt_total = @obt_total, obt_total_g = @obt_total_g, comp_th = @comp_th, comp_th_g = @comp_th_g, comp_pr = @comp_pr, comp_pr_g = @comp_pr_g, comp_total = @comp_total, comp_total_g = @comp_total_g, 
                            hea_th = @hea_th, hea_th_g = @hea_th_g, hea_pr = @hea_pr, hea_pr_g = @hea_pr_g, hea_total = @hea_total, hea_total_g = @hea_total_g, mor_th = @mor_th, mor_th_g = @mor_th_g, mor_pr = @mor_pr, mor_pr_g = @mor_pr_g, mor_total = @mor_total, mor_total_g = @mor_total_g, 
                            total_th = @total_th, total_th_g = @total_th_g, total_pr = @total_pr, total_pr_g = @total_pr_g, total = @total, percentage = @percentage, grade = @grade, grade_point = @grade_point, attendance= @attendance 
                             WHERE id=" & rowID

        Dim updateSQL_sec = "UPDATE results_" & class_name & "
                     SET 
                    student_id = @student_id, reg_number = @reg_number, full_name = @full_name, school_year = @school_year, school_name = @school_name, terminal = @terminal, eng_th = @eng_th, eng_th_g = @eng_th_g, eng_pr = @eng_pr, eng_pr_g = @eng_pr_g, eng_total = @eng_total, eng_total_g = @eng_total_g, 
                    nep_th = @nep_th, nep_th_g = @nep_th_g, nep_pr = @nep_pr, nep_pr_g = @nep_pr_g, nep_total = @nep_total, nep_total_g = @nep_total_g, math_th = @math_th, math_th_g = @math_th_g, math_pr = @math_pr, math_pr_g = @math_pr_g, math_total = @math_total, math_total_g = @math_total_g, 
                    sci_th = @sci_th, sci_th_g = @sci_th_g, sci_pr = @sci_pr, sci_pr_g = @sci_pr_g, sci_total = @sci_total, sci_total_g = @sci_total_g, soc_th = @soc_th, soc_th_g = @soc_th_g, soc_pr = @soc_pr, soc_pr_g = @soc_pr_g, soc_total = @soc_total, soc_total_g = @soc_total_g,
                    eph_th = @eph_th, eph_th_g = @eph_th_g, eph_pr = @eph_pr, eph_pr_g = @eph_pr_g, eph_total = @eph_total, eph_total_g = @eph_total_g, opt1_th = @opt1_th, opt1_th_g = @opt1_th_g, opt1_pr = @opt1_pr, opt1_pr_g = @opt1_pr_g, opt1_total = @opt1_total, opt1_total_g = @opt1_total_g, 
                    opt2_th = @opt2_th, opt2_th_g = @opt2_th_g, opt2_pr = @opt2_pr, opt2_pr_g = @opt2_pr_g, opt2_total = @opt2_total, opt2_total_g = @opt2_total_g, total_th = @total_th, total_th_g = @total_th_g, total_pr = @total_pr, total_pr_g = @total_pr_g, total = @total, 
                    percentage = @percentage, grade = @grade, grade_point = @grade_point, opt1 = @opt1, opt2 = @opt2, attendance= @attendance 
                    WHERE id=" & rowID

        If primary.Contains(class_name) Then
            Return updateSQL_primary
        ElseIf lowSec.Contains(class_name) Then
            Return updateSQL_lowSec
        Else
            Return updateSQL_sec
        End If
        Return ""
    End Function

    'if edit - params {student_id, year, school_name, className, terminal, TRUE}, comboboxes {regcombo, opt1combo, opt2combo}
    Public Shared Sub loadResult(params As String(), textboxes As TextBox(), comboBoxes As ComboBox())
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim className = params(3)
        Dim student_id = params(0)
        Dim terminal = params(4)
        Dim school_year = params(1)
        Dim school_name = params(2)
        Try
            SQL = getLoadResultSQL(school_year, school_name, className, student_id, terminal)
            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            For i As Integer = 1 To textboxes.Count
                textboxes(i - 1).Text = DS.Tables(0).Rows(0)(i).ToString
            Next

            comboBoxes(0).Text = DS.Tables(0).Rows(0)(0).ToString 'studentRegCombo

            If sec.Contains(className) Then
                comboBoxes(1).Text = DS.Tables(0).Rows(0)(19).ToString 'opt1Combo
                comboBoxes(2).Text = DS.Tables(0).Rows(0)(20).ToString 'opt2Combo
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Public Shared Function getLoadResultSQL(school_year As String, school_name As String, className As String, student_id As String, terminal As String) As String
        Dim loadSQL_primary = "SELECT reg_number, full_name, eng_th, eng_pr, nep_th, nep_pr, math_th, math_pr, sci_th, sci_pr, soc_th, soc_pr, opt_eng_th, opt_eng_pr, gk_conv_th, gk_conv_pr, attendance
                    FROM 
                    results_" & className & " where student_id=" & student_id & " and school_name='" & school_name & "' and school_year= '" & school_year & "' and terminal = '" & terminal & "'"

        Dim loadSQL_lowSec = "SELECT reg_number, full_name, eng_th, eng_pr, nep_th, nep_pr, math_th, math_pr, sci_th, sci_pr, soc_th, soc_pr, obt_th, obt_pr, comp_th, comp_pr, hea_th, hea_pr, mor_th, mor_pr, attendance
                    FROM 
                    results_" & className & " where student_id=" & student_id & " and school_name='" & school_name & "' and school_year= '" & school_year & "' and terminal = '" & terminal & "'"

        Dim loadSQL_sec = "SELECT reg_number, full_name, eng_th, eng_pr, nep_th, nep_pr, math_th, math_pr, sci_th, sci_pr, soc_th, soc_pr, eph_th, eph_pr, opt1_th, opt1_pr, opt2_th, opt2_pr, attendance, opt1, opt2
                    FROM 
                    results_" & className & " where student_id=" & student_id & " and school_name='" & school_name & "' and school_year= '" & school_year & "' and terminal = '" & terminal & "'"

        If primary.Contains(className) Then
            Return loadSQL_primary
        ElseIf lowSec.Contains(className) Then
            Return loadSQL_lowSec
        Else
            Return loadSQL_sec
        End If
    End Function

    '{school_year, school_name, terminal, className, class_id, studentNameTextBox, regNumberCombo}
    Public Shared Sub findNext(params As String(), studentNameTextBox As TextBox, regNumberCombo As ComboBox)
        Dim className = params(3)
        Dim class_id = params(4)
        Dim terminal = params(2)
        Dim school_year = params(0)
        Dim school_name = params(1)

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "select * from class_student
where class_id = " & class_id & " and student_id not in
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
where c.class_id = " & class_id & ") tb
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
                    Exit Sub
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
            regNumberCombo.Text = Val

            Dim student_name = DS.Tables(0).Rows(0)(0).ToString & " " & DS.Tables(0).Rows(0)(1).ToString & " " & DS.Tables(0).Rows(0)(2).ToString
            studentNameTextBox.Text = student_name

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Public Shared Function getSubjKey(subject As String, class_name As String) As String
        Dim key As String = ""
        If subject = "English" Then
            key = "eng"
        ElseIf subject = "Nepali" Then
            key = "nep"
        ElseIf subject = "Maths" Then
            key = "math"
        ElseIf subject = "Science" Then
            key = "sci"
        ElseIf subject = "Social" Then
            key = "soc"
        ElseIf subject = "OBT" Then
            key = "obt"
        ElseIf subject = "Health" Then
            key = "hea"
        ElseIf subject = "Moral" Then
            key = "mor"
        ElseIf subject = "Computer" And sec.Contains(class_name) Then
            key = "opt2"
        ElseIf subject = "Opt English" Then
            key = "opt_eng"
        ElseIf subject = "GK/Conv" Then
            key = "gk_conv"
        ElseIf subject = "EPH" Then
            key = "eph"
        ElseIf subject = "Opt. Math" Then
            key = "opt1"
        ElseIf subject = "Account" Then
            key = "opt2"
        ElseIf subject = "Economics" Then
            key = "opt1"
        ElseIf subject = "Education" Then
            key = "opt2"
        ElseIf subject = "Computer" Then
            key = "comp"
        End If
        Return key
    End Function

    Public Shared Function getSubjCode(subject As String) As String
        Dim key As String = ""
        If subject = "English" Then
            key = "eng"
        ElseIf subject = "Nepali" Then
            key = "nep"
        ElseIf subject = "Maths" Then
            key = "math"
        ElseIf subject = "Science" Then
            key = "sci"
        ElseIf subject = "Social" Then
            key = "soc"
        ElseIf subject = "OBT" Then
            key = "obt"
        ElseIf subject = "Health" Then
            key = "hea"
        ElseIf subject = "Moral" Then
            key = "mor"
        ElseIf subject = "Computer" Then
            key = "comp"
        ElseIf subject = "Opt English" Then
            key = "opt_eng"
        ElseIf subject = "GK/Conv" Then
            key = "gk_conv"
        ElseIf subject = "EPH" Then
            key = "eph"
        ElseIf subject = "Opt. Math" Then
            key = "opt_math"
        ElseIf subject = "Account" Then
            key = "acc"
        ElseIf subject = "Economics" Then
            key = "eco"
        ElseIf subject = "Education" Then
            key = "edu"
        End If
        Return key
    End Function

    Public Shared Function getStudentResultRowID(school_year As String, school_name As String, terminal As String, class_name As String, student_id As String) As Integer
        Dim SQL = ""
        Dim DS = New DataSet
        Dim oData As OleDbDataAdapter

        Dim rowSQL As String = "SELECT id from results_" & class_name & " where school_name='" & school_name & "' and school_year ='" & school_year &
    "' and terminal = '" & terminal & "' and student_id=" & student_id

        Con.Open()
        oData = New OleDbDataAdapter(rowSQL, Con)
        Con.Close()
        oData.Fill(DS)
        Dim rowID = CInt(DS.Tables(0).Rows(0)(0))
        Return rowID
    End Function

    'params = {school_year, school_name, class_name, terminal, current_student_id, subjkey}
    Public Shared Sub loadSubjMarks(params As String(), subjTh As TextBox, subjPr As TextBox)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim school_year = params(0)
        Dim school_name = params(1)
        Dim class_name = params(2)
        Dim terminal = params(3)
        Dim student_id = params(4)
        Dim subjKey = params(5)
        Try
            SQL = "SELECT " & subjKey & "_th, " & subjKey & "_pr " &
                    "FROM results_" & class_name & " where student_id=" & student_id & " and school_name='" & school_name & "' and school_year= '" & school_year & "' and terminal = '" & terminal & "'"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            subjTh.Text = DS.Tables(0).Rows(0)(0).ToString 'theory marks
            subjPr.Text = DS.Tables(0).Rows(0)(1).ToString 'practical marks        
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Public Shared Sub updateCalculations(DS As DataSet, school_name As String, year_num As String, class_name As String)
        'get studentIDs
        Dim rowCount = DS.Tables(0).Rows.Count
        Dim student_ids As String() = {}
        ReDim Preserve student_ids(rowCount - 1)
        For i As Integer = 0 To rowCount - 1
            student_ids(i) = DS.Tables(0).Rows(i).Item("student_id").ToString
        Next

        Dim hashKeys = getResultTableHashKeys(class_name)

        'for each student_id
        For i As Integer = 0 To student_ids.Count - 1
            Dim student_id = student_ids(i)
            Dim reg_number = DS.Tables(0).Rows(i).Item("reg_number").ToString
            Dim full_name = DS.Tables(0).Rows(i).Item("full_name").ToString
            Dim terminal = DS.Tables(0).Rows(i).Item("terminal").ToString
            Dim params As String() = {student_id, reg_number, full_name, terminal, school_name, year_num, class_name}
            'prepare input hash
            Dim inputHash = prepareInputHash(DS.Tables(0).Rows(i), params)
            Dim newInputHash As Hashtable = resultFunctions.calculateGrades(inputHash, class_name)
            'update row
            Dim newParams As String() = {year_num, school_name, terminal, class_name, student_id}
            updateResultData(newParams, hashKeys, newInputHash)
        Next
        MessageBox.Show("All calculations successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    '{student_id, reg_number, full_name, terminal, school_name, year_num,  class_name}
    Public Shared Function prepareInputHash(DR As DataRow, params As String()) As Hashtable
        Dim inputHash As New Hashtable
        Dim student_id = params(0)
        Dim reg_number = params(1)
        Dim full_name = params(2)
        Dim terminal = params(3)
        Dim school_name = params(4)
        Dim school_year = params(5)
        Dim class_name = params(6)

        inputHash("student_id") = student_id
        inputHash("reg_number") = reg_number
        inputHash("full_name") = full_name
        inputHash("school_year") = school_year
        inputHash("school_name") = school_name
        inputHash("terminal") = terminal

        Dim theorySub = getSubjects("theory", class_name)
        Dim pracSub = getSubjects("prac", class_name)
        Dim totalSub = getSubjects("total", class_name)
        Dim total_th As Double = 0
        Dim total_pr As Double = 0

        For Each key As String In theorySub
            Dim val = DR.Item(key).ToString
            If val = "" Then val = "0"
            inputHash(key) = val
            total_th += CDbl(val)
        Next
        For Each key As String In pracSub
            Dim val = DR.Item(key).ToString
            If val = "" Then val = "0"
            inputHash(key) = val
            total_pr += CDbl(val)
        Next
        For i As Integer = 0 To theorySub.Count - 1
            Dim th_key As String = theorySub(i)
            Dim pr_key As String = pracSub(i)
            Dim total_key As String = totalSub(i)
            inputHash(total_key) = CDbl(inputHash(th_key)) + CDbl(inputHash(pr_key))
        Next

        If sec.Contains(class_name) Then
            inputHash("opt1") = DR.Item("opt1")
            inputHash("opt2") = DR.Item("opt2")
        End If

        inputHash("total_th") = total_th
        inputHash("total_pr") = total_pr
        inputHash("total") = total_th + total_pr
        inputHash = addMoreInputs(inputHash, class_name) 'total_th_perc, total_pr_perc, percentage
        inputHash("attendance") = 0  'dummy - has to be updated manually
        If DR.Item("attendance") IsNot "0" Then
            inputHash("attendance") = DR.Item("attendance")
        End If
        'inputHash("rank") = 0 'dummy - separate method/button for updating rank, which will run at end
        Return inputHash
    End Function

    Public Shared Function addMoreInputs(inputHash As Hashtable, class_name As String) As Hashtable
        Dim total_th_perc As Double = 0
        Dim total_pr_perc As Double = 0
        Dim percentage As Double = 0

        If primary.Contains(class_name) Then
            Dim total_th_marks = 700 '100% CAS in actual
            Dim total_pr_marks = 1 'just  to avoid 0/0 error

            Dim total_th = CDbl(inputHash("total_th"))
            total_th_perc = total_th / total_th_marks * 100
            Dim total_pr = CDbl(inputHash("total_pr"))
            total_pr_perc = total_pr / total_pr_marks * 100
            Dim total = total_th + total_pr
            percentage = total / 700 * 100
        ElseIf lowSec.Contains(class_name) Then
            Dim total_th = CDbl(inputHash("total_th"))
            total_th_perc = total_th / 555 * 100
            Dim total_pr = CDbl(inputHash("total_pr"))
            total_pr_perc = total_pr / 245 * 100
            Dim total = total_th + total_pr
            percentage = total / 800 * 100
        Else
            Dim total_th = CDbl(inputHash("total_th"))
            Dim total_pr = CDbl(inputHash("total_pr"))
            Dim total_th_marks = 625
            Dim total_pr_marks = 175

            If inputHash("opt2").ToString = "Computer" Then
                total_th_marks = 600
                total_pr_marks = 200
            End If
            total_th_perc = total_th / total_th_marks * 100
            total_pr_perc = total_pr / total_pr_marks * 100
            Dim total = total_th + total_pr
            percentage = total / 800 * 100
        End If

        inputHash("total_th_perc") = total_th_perc
        inputHash("total_pr_perc") = total_pr_perc
        inputHash("percentage") = Math.Round(percentage, 2)

        Return inputHash
    End Function

    'params = {year_num, school_name, terminal, class_name, student_id}
    Public Shared Sub updateResultData(params As String(), hashkeys As String(), newInputHash As Hashtable)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        Dim updateSQL = resultFunctions.buildUpdateResultSQL(params, Con)
        Try
            Con.Open()
            Dim cmd As New OleDbCommand(updateSQL, Con)

            For Each key As String In hashkeys
                cmd.Parameters.AddWithValue("@" & key, newInputHash(key))
            Next

            cmd.ExecuteNonQuery()
            'MessageBox.Show("All calculations successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub

    Public Shared Function getResultOf(class_name As String, terminal As String, school_year As String, school_name As String) As DataSet
        Dim resultDS As New DataSet
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = ""
        Dim oData As OleDbDataAdapter

        Try
            SQL = "SELECT * from results_" & class_name & " where school_name='" & school_name & "' and school_year ='" & school_year & "'" & " and terminal = '" & terminal & "'"
            resultDS.Tables.Clear()
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(resultDS)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        Return resultDS
    End Function

    'updates full name in results table if student name is edited 
    Public Shared Sub updateFullNameInResults(reg_number As String, class_name As String, full_name As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = ""
        SQL = "UPDATE results_" & class_name & " SET full_name = @full_name where reg_number='" & reg_number & "'"
        Dim DS = New DataSet
        Try
            Con.Open() 'Open connection
            Dim cmd As New OleDbCommand(SQL, Con)
            cmd.Parameters.AddWithValue("@full_name", full_name)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
    End Sub


End Class
