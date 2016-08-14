
Imports System.Data
Imports System.Data.OleDb
Public Class addResultPrimaryForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Public contents As String() = {}
    Public lowPrimary As String() = {"1", "2", "3"}
    Public highPrimary As String() = {"4", "5"}

    Public Sub New(params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the Initializegk_convonent() call.
        contents = params
        loadRegNumber(params)
    End Sub


    Private Sub studentRegCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles studentRegCombo.SelectedIndexChanged
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "SELECT f_name, m_name, l_name, id from student where reg_number = '" & studentRegCombo.Text & "'"

            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim present = checkIfPresent(DS.Tables(0).Rows(0)(3).ToString, termCombo.Text, contents(3))
            If present = True Then
                MessageBox.Show("Record is already present. Please check.", "Duplicate record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Val = DS.Tables(0).Rows(0)(0).ToString & " " & DS.Tables(0).Rows(0)(1).ToString & " " & DS.Tables(0).Rows(0)(2).ToString

            studentName.Text = Val

            ReDim Preserve contents(4)
            contents(4) = DS.Tables(0).Rows(0)(3).ToString
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
                    where c.class_id =" & params(0).ToString & ") tb
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

    Public Function checkIfPresent(student_id As String, terminal As String, class_name As String) As Boolean
        Dim present As Boolean = False

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS = New DataSet
        Dim SQL As String = ""
        Try
            SQL = "SELECT * from results_" & class_name.ToString & " where student_id=" & student_id & " and terminal = '" & terminal & "'"

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
        ElseIf studentRegCombo.SelectedIndex = -1 Then
            errorMsg.Text = "Please select a student registration number."
            Exit Sub
        Else
            errorMsg.Text = ""
        End If

        Dim textBoxes As TextBox() = {engTh, engPr, nepTh, nepPr, mathTh, mathPr, socTh, socPr, sciTh, sciPr, optEngTh, optEngPr, gkConvTh, gkConvPr}

        Dim valid As Boolean = checkNumberValidity(textBoxes)

        If valid = False Then
            MessageBox.Show("You must enter a Number.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If lowPrimary.Contains(contents(3)) Then
            Dim okData As Boolean = checkDataEntry(textBoxes)
            If okData = False Then
                MessageBox.Show("One of the input marks is more than full marks. Please check", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim terminal = termCombo.Text
        Dim class_name = contents(3)

        Dim hashKeys As String() = {"student_id", "school_year", "school_name", "terminal", "eng_th", "eng_th_g", "eng_pr", "eng_pr_g", "eng_total", "eng_total_g", "nep_th", "nep_th_g", "nep_pr",
            "nep_pr_g", "nep_total", "nep_total_g", "math_th", "math_th_g", "math_pr", "math_pr_g", "math_total", "math_total_g", "sci_th", "sci_th_g", "sci_pr", "sci_pr_g", "sci_total", "sci_total_g",
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "opt_eng_th", "opt_eng_th_g", "opt_eng_pr", "opt_eng_pr_g", "opt_eng_total", "opt_eng_total_g", "gk_conv_th", "gk_conv_th_g", "gk_conv_pr", "gk_conv_pr_g",
            "gk_conv_total", "gk_conv_total_g", "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point"}


        Dim inputHash = prepareInputHash()

        Dim newInputHash As Hashtable = calculateGrades(inputHash)

        Try
            Dim insertSQL As String = "INSERT INTO results_" & class_name & " ([student_id],[school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[opt_eng_th],[opt_eng_th_g],[opt_eng_pr],[opt_eng_pr_g],[opt_eng_total],[opt_eng_total_g],[gk_conv_th],[gk_conv_th_g],[gk_conv_pr],[gk_conv_pr_g],[gk_conv_total],[gk_conv_total_g],
[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point]) 
VALUES
(@student_id, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @opt_eng_th, @opt_eng_th_g, @opt_eng_pr, @opt_eng_pr_g, @opt_eng_total, @opt_eng_total_g, @gk_conv_th, @gk_conv_th_g, @gk_conv_pr, @gk_conv_pr_g, @gk_conv_total, @gk_conv_total_g, 
@total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point)"

            Con.Open()
            Dim cmd As New OleDbCommand(insertSQL, Con)

            For Each key As String In hashKeys
                cmd.Parameters.AddWithValue("@" & key, newInputHash(key))
            Next

            cmd.ExecuteNonQuery()

            Dim I As Integer = MsgBox("Insert Successful", MsgBoxStyle.Information, "INSERTED")
            If I = MsgBoxResult.Ok Then
                If sequenceCheckBox.Checked Then
                    'MsgBox("sequence selected")
                    prepareNext(textBoxes)
                Else
                    For j As Integer = 0 To textBoxes.Count - 1
                        textBoxes(j).Text = "0"
                    Next
                    termCombo.Text = ""
                    studentRegCombo.Text = ""
                    studentName.Text = ""
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

    Public Function checkNumberValidity(textboxes As TextBox()) As Boolean
        For i As Integer = 0 To textboxes.Count - 1
            If Not IsNumeric(textboxes(i).Text) Or textboxes(i).Text = "" Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function checkDataEntry(textboxes As TextBox()) As Boolean
        For i As Integer = 0 To textboxes.Count - 1
            If CDbl(textboxes(i).Text) > 100 Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function prepareInputHash() As Hashtable
        Dim inputHash As Hashtable = New Hashtable
        Dim total_th_marks = 700 '100% CAS in actual
        Dim total_pr_marks = 1 'just  to avoid 0/0 error

        If highPrimary.Contains(contents(3)) Then
            total_th_marks = 60 * 7 '60% written
            total_pr_marks = 40 * 7 '40% CAS
        End If
        Dim total_th = CDbl(engTh.Text) + CDbl(nepTh.Text) + CDbl(mathTh.Text) + CDbl(sciTh.Text) + CDbl(socTh.Text) + CDbl(optEngTh.Text) + CDbl(gkConvTh.Text)
        Dim total_th_perc = total_th / total_th_marks * 100
        Dim total_pr = CDbl(engPr.Text) + CDbl(nepPr.Text) + CDbl(mathPr.Text) + CDbl(sciPr.Text) + CDbl(socPr.Text) + CDbl(optEngPr.Text) + CDbl(gkConvPr.Text)
        Dim total_pr_perc = total_pr / total_pr_marks * 100
        Dim total = total_th + total_pr
        Dim percentage = total / 700 * 100

        inputHash("student_id") = contents(4)
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
        inputHash("opt_eng_th") = optEngTh.Text
        inputHash("opt_eng_pr") = optEngPr.Text
        inputHash("opt_eng_total") = CDbl(optEngTh.Text) + CDbl(optEngPr.Text)
        inputHash("gk_conv_th") = gkConvTh.Text
        inputHash("gk_conv_pr") = gkConvPr.Text
        inputHash("gk_conv_total") = CDbl(gkConvTh.Text) + CDbl(gkConvPr.Text)
        inputHash("total_th") = total_th
        inputHash("total_th_perc") = total_th_perc
        inputHash("total_pr") = total_pr
        inputHash("total_pr_perc") = total_pr_perc
        inputHash("total") = total
        inputHash("percentage") = percentage

        Return inputHash
    End Function

    Public Function calculateGrades(inputHash As Hashtable) As Hashtable

        Dim theorySub = {"eng_th", "nep_th", "math_th", "sci_th", "soc_th", "opt_eng_th", "gk_conv_th"}
        Dim pracSub = {"eng_pr", "nep_pr", "math_pr", "sci_pr", "soc_pr", "opt_eng_pr", "gk_conv_pr"}
        Dim totalSub = {"eng_total", "nep_total", "math_total", "sci_total", "soc_total", "opt_eng_total", "gk_conv_total"}
        Dim grade As String = ""
        Dim percentage As Double = 0
        Dim grade_point As Double = 0
        Dim th_marks = 100
        Dim pr_marks = 1 'to avoid 0/0 error

        If highPrimary.Contains(contents(3)) Then
            th_marks = 60
            pr_marks = 40
        End If

        For Each subj As String In theorySub
            percentage = CDbl(inputHash(subj)) / th_marks * 100

            grade = percentToGrade(percentage)
            inputHash(subj & "_g") = grade
        Next

        For Each subj As String In pracSub
            percentage = CDbl(inputHash(subj)) / pr_marks * 100

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
        inputHash("grade_point") = calculateGradePoint(inputHash)
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
        If gradePoint = 4 Then
            grade = "A+"
        ElseIf gradePoint >= 3.6 Then
            grade = "A"
        ElseIf gradePoint >= 3.2 Then
            grade = "B+"
        ElseIf gradePoint >= 2.8 Then
            grade = "B"
        ElseIf gradePoint >= 2.4 Then
            grade = "C+"
        ElseIf gradePoint >= 2 Then
            grade = "C"
        ElseIf gradePoint >= 1.6 Then
            grade = "D+"
        ElseIf gradePoint >= 1.2 Then
            grade = "D"
        ElseIf gradePoint >= 0.8 Then
            grade = "E"
        Else
            grade = "NG"
        End If
        Return grade
    End Function

    Function calculateGradePoint(inputHash As Hashtable) As Double
        Dim totalGradePoint As Double = 0
        Dim avgGP As Double = 0
        Dim totalSub = {"eng_total", "nep_total", "math_total", "sci_total", "soc_total", "opt_eng_total", "gk_conv_total"}

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

    Private Sub addResultLowSecForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim labels As Label() = {engThLabel, engPrLabel, nepThLabel, nepPrLabel, mathThLabel, mathPrLabel,
            sciThLabel, sciPrLabel, socThLabel, socPrLabel, optEngThLabel, optEngPrLabel, gkConvThLabel, gkConvPrLabel}

        Dim toDisableTextboxes As TextBox() = {engPr, nepPr, mathPr, sciPr, socPr, optEngPr, gkConvPr}

        If lowPrimary.Contains(contents(3)) Then
            For i As Integer = 0 To labels.Count - 1
                labels(i).Text = "/100"
            Next

            For i As Integer = 0 To toDisableTextboxes.Count - 1
                toDisableTextboxes(i).Enabled = False
            Next
        End If

    End Sub
End Class