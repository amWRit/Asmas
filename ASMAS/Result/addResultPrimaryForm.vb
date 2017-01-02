
Imports System.Data
Imports System.Data.OleDb
Public Class addResultPrimaryForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Public contents As String() = {}
    Public lowPrimary As String() = {"1", "2", "3"}
    Public highPrimary As String() = {"4", "5"}
    Public textBoxes As TextBox() = {studentName, engTh, engPr, nepTh, nepPr, mathTh, mathPr, sciTh, sciPr, socTh, socPr, optEngTh, optEngPr, gkConvTh, gkConvPr, attendance}


    'if edit - {student_id, year, school_name, className, terminal, edit=TRUE}
    '{class_id, year, school_name, className, terminal="", edit=FALSE}
    Public Sub New(params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        Dim textBoxes As TextBox() = {studentName, engTh, engPr, nepTh, nepPr, mathTh, mathPr, sciTh, sciPr, socTh, socPr, optEngTh, optEngPr, gkConvTh, gkConvPr, attendance}

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
            resultFunctions.loadResult(params, textBoxes, {studentRegCombo})
        End If
    End Sub


    Private Sub studentRegCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles studentRegCombo.SelectedIndexChanged
        If termCombo.SelectedIndex = -1 Then
            MessageBox.Show("Please select a terminal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim reg_number = studentRegCombo.Text
        Dim terminal = termCombo.Text
        Dim school_name = contents(3)
        Dim school_year = contents(1)
        Dim class_name = contents(3)

        Dim val As String() = resultFunctions.findStudentName(school_name, school_year, terminal, class_name, reg_number)
        studentName.Text = val(0)
        If val(2) = "present" Then
            saveBtn.Enabled = False
            Exit Sub
        Else
            saveBtn.Enabled = True
        End If
        ReDim Preserve contents(7)
        contents(7) = val(1) 'save student id
    End Sub

    Private Sub termCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles termCombo.SelectedIndexChanged
        If studentRegCombo.SelectedIndex <> -1 Then
            Dim reg_number = studentRegCombo.Text
            Dim terminal = termCombo.Text
            Dim school_name = contents(3)
            Dim school_year = contents(1)
            Dim class_name = contents(3)

            Dim val As String() = resultFunctions.findStudentName(school_name, school_year, terminal, class_name, reg_number)
            studentName.Text = val(0)
            If val(2) = "present" Then
                saveBtn.Enabled = False
                Exit Sub
            Else
                saveBtn.Enabled = True
            End If
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
        Else
            errorMsg.Text = ""
        End If

        Dim textBoxes As TextBox() = {engTh, engPr, nepTh, nepPr, mathTh, mathPr, sciTh, sciPr, socTh, socPr, optEngTh, optEngPr, gkConvTh, gkConvPr}

        Dim valid As Boolean = resultFunctions.checkNumberValidity(textBoxes)

        If valid = False Then
            MessageBox.Show("You must enter a Number.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim okData As Boolean = checkDataEntry(textBoxes)
        If okData = False Then
            MessageBox.Show("One of the input marks is more than full marks. Please check", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "opt_eng_th", "opt_eng_th_g", "opt_eng_pr", "opt_eng_pr_g", "opt_eng_total", "opt_eng_total_g", "gk_conv_th", "gk_conv_th_g", "gk_conv_pr", "gk_conv_pr_g",
            "gk_conv_total", "gk_conv_total_g", "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point", "attendance"}


        Dim inputHash = prepareInputHash()

        Dim newInputHash As Hashtable = resultFunctions.calculateGrades(inputHash, class_name)

        Try
            Dim insertSQL As String = "INSERT INTO results_" & class_name & " ([student_id], [reg_number], [full_name], [school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[opt_eng_th],[opt_eng_th_g],[opt_eng_pr],[opt_eng_pr_g],[opt_eng_total],[opt_eng_total_g],[gk_conv_th],[gk_conv_th_g],[gk_conv_pr],[gk_conv_pr_g],[gk_conv_total],[gk_conv_total_g],
[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [attendance]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @opt_eng_th, @opt_eng_th_g, @opt_eng_pr, @opt_eng_pr_g, @opt_eng_total, @opt_eng_total_g, @gk_conv_th, @gk_conv_th_g, @gk_conv_pr, @gk_conv_pr_g, @gk_conv_total, @gk_conv_total_g, 
@total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @attendance)"

            Dim edit = contents(5)
            Dim params As String() = {school_year, school_name, terminal, class_name, student_id}
            If edit = "TRUE" Then insertSQL = resultFunctions.buildUpdateResultSQL(params, Con)

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
                ElseIf edit = "TRUE" Then
                    Me.Close()
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

        'If highPrimary.Contains(contents(3)) Then
        '    total_th_marks = 60 * 7 '60% written
        '    total_pr_marks = 40 * 7 '40% CAS
        'End If
        Dim total_th = CDbl(engTh.Text) + CDbl(nepTh.Text) + CDbl(mathTh.Text) + CDbl(sciTh.Text) + CDbl(socTh.Text) + CDbl(optEngTh.Text) + CDbl(gkConvTh.Text)
        Dim total_th_perc = total_th / total_th_marks * 100
        Dim total_pr = CDbl(engPr.Text) + CDbl(nepPr.Text) + CDbl(mathPr.Text) + CDbl(sciPr.Text) + CDbl(socPr.Text) + CDbl(optEngPr.Text) + CDbl(gkConvPr.Text)
        Dim total_pr_perc = total_pr / total_pr_marks * 100
        Dim total = total_th + total_pr
        Dim percentage = total / 700 * 100

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

        'find next student whose result is not added
        Dim className = contents(3)
        Dim terminal = termCombo.Text
        Dim school_year = contents(1)
        Dim school_name = contents(2)
        Dim class_id = contents(0)
        resultFunctions.findNext({school_year, school_name, terminal, className, class_id}, studentName, studentRegCombo)

    End Sub

    Private Sub addResultLowSecForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim labels As Label() = {engThLabel, engPrLabel, nepThLabel, nepPrLabel, mathThLabel, mathPrLabel,
            sciThLabel, sciPrLabel, socThLabel, socPrLabel, optEngThLabel, optEngPrLabel, gkConvThLabel, gkConvPrLabel}

        Dim toDisableTextboxes As TextBox() = {engPr, nepPr, mathPr, sciPr, socPr, optEngPr, gkConvPr}

        'If lowPrimary.Contains(contents(3)) Then
        '    For i As Integer = 0 To labels.Count - 1
        '        labels(i).Text = "/100"
        '    Next

        '    For i As Integer = 0 To toDisableTextboxes.Count - 1
        '        toDisableTextboxes(i).Enabled = False
        '    Next
        'End If

    End Sub
End Class