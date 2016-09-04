Imports System.Data
Imports System.Data.OleDb
Public Class addResultSecForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Public contents As String() = {}

    'if edit - {student_id, year, school_name, className, terminal, edit=TRUE}
    '{class_id, year, school_name, className, terminal="", edit=FALSE}
    Public Sub New(params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        Dim textBoxes As TextBox() = {studentName, engTh, engPr, nepTh, nepPr, mathTh, mathPr, sciTh, sciPr, socTh, socPr, ephTh, ephPr, opt1Th, opt1Pr, opt2Th, opt2Pr, attendance}
        ' Add any initialization after the InitializeComponent() call.
        contents = params
        Dim edit = params(5)
        If edit = "FALSE" Then
            Dim regNumberCollection As DataSet = resultFunctions.getRegNumber(params)
            resultFunctions.loadRegNumber(regNumberCollection, Me.studentRegCombo)
        Else
            ReDim Preserve contents(7)
            contents(7) = contents(0)
            studentRegCombo.Enabled = False
            termCombo.Text = contents(4)
            resultFunctions.loadResult(params, textBoxes, {studentRegCombo, opt1Combo, opt2Combo})
        End If
    End Sub


    Private Sub studentRegCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles studentRegCombo.SelectedIndexChanged
        If termCombo.SelectedIndex = -1 Then
            MessageBox.Show("Please select a terminal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim reg_number = studentRegCombo.Text
        Dim terminal = termCombo.Text
        Dim class_name = contents(3)

        Dim val As String() = resultFunctions.findStudentName(terminal, class_name, reg_number)
        If val Is Nothing Then Exit Sub
        studentName.Text = val(0)
        ReDim Preserve contents(7)
        contents(7) = val(1) 'save student id
    End Sub

    Private Sub termCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles termCombo.SelectedIndexChanged
        If studentRegCombo.SelectedIndex <> -1 Then
            Dim reg_number = studentRegCombo.Text
            Dim terminal = termCombo.Text
            Dim class_name = contents(3)

            Dim val As String() = resultFunctions.findStudentName(terminal, class_name, reg_number)
            If val Is Nothing Then Exit Sub
            studentName.Text = val(0)
            ReDim Preserve contents(7)
            contents(7) = val(1) 'save student id
        End If
    End Sub

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

        Dim valid As Boolean = resultFunctions.checkNumberValidity(textBoxes)

        If valid = False Then
            MessageBox.Show("You must enter a Number.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim class_name = contents(3)
        Dim terminal = termCombo.Text
        Dim school_year = contents(1)
        Dim school_name = contents(2)
        Dim class_id = contents(0)
        Dim student_id = contents(0)

        Dim hashKeys As String() = {"student_id", "reg_number", "full_name", "school_year", "school_name", "terminal", "eng_th", "eng_th_g", "eng_pr", "eng_pr_g", "eng_total", "eng_total_g", "nep_th", "nep_th_g", "nep_pr",
            "nep_pr_g", "nep_total", "nep_total_g", "math_th", "math_th_g", "math_pr", "math_pr_g", "math_total", "math_total_g", "sci_th", "sci_th_g", "sci_pr", "sci_pr_g", "sci_total", "sci_total_g",
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "eph_th", "eph_th_g", "eph_pr", "eph_pr_g", "eph_total", "eph_total_g", "opt1_th", "opt1_th_g", "opt1_pr", "opt1_pr_g",
            "opt1_total", "opt1_total_g", "opt2_th", "opt2_th_g", "opt2_pr", "opt2_pr_g", "opt2_total", "opt2_total_g",
            "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point", "opt1", "opt2", "attendance"}


        Dim inputHash = prepareInputHash()

        Dim newInputHash As Hashtable = resultFunctions.calculateGrades(inputHash, class_name)

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
            Dim params As String() = {school_year, school_name, terminal, class_name, student_id}
            If edit = "TRUE" Then insertSQL = resultFunctions.buildUpdateResultSQL(params, Con)

            Con.Open()
            Dim cmd As New OleDbCommand(insertSQL, Con)


            For Each key As String In hashKeys
                cmd.Parameters.AddWithValue("@" & key, newInputHash(key).ToString)
            Next

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
        Dim className = contents(3)
        Dim terminal = termCombo.Text
        Dim school_year = contents(1)
        Dim school_name = contents(2)
        Dim class_id = contents(0)
        resultFunctions.findNext({school_year, school_name, terminal, className, class_id}, studentName, studentRegCombo)

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