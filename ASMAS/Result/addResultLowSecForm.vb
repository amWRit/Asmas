Imports System.Data
Imports System.Data.OleDb
Public Class addResultLowSecForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Public contents As String() = {}
    Public textBoxes As New TextBox()


    'if edit - {student_id, year, school_name, className, terminal, edit=TRUE}
    '{class_id, year, school_name, className, terminal="", edit=FALSE}
    Public Sub New(params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        Dim textBoxes As TextBox() = {studentName, engTh, engPr, nepTh, nepPr, mathTh, mathPr, sciTh, sciPr, socTh, socPr, obtTh, obtPr, compTh, compPr, heaTh, heaPr, morTh, morPr, attendance}
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

            Dim val As String() = resultFunctions.findStudentName(terminal, class_name, reg_number) '{studentName, student_id}
            If val Is Nothing Then Exit Sub
            studentName.Text = val(0)
            ReDim Preserve contents(7)
            contents(7) = val(1) 'save student id
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Dim textBoxes As TextBox() = {engTh, engPr, nepTh, nepPr, mathTh, mathPr, sciTh, sciPr, socTh, socPr, obtTh, obtPr, compTh, compPr, heaTh, heaPr, morTh, morPr}

        If termCombo.SelectedIndex = -1 Then
            errorMsg.Text = "Please select a terminal."
            Exit Sub
        ElseIf contents(5) = "FALSE" And studentRegCombo.SelectedIndex = -1 Then
            errorMsg.Text = "Please select a student registration number."
            Exit Sub
        Else
            errorMsg.Text = ""
        End If

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
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "obt_th", "obt_th_g", "obt_pr", "obt_pr_g", "obt_total", "obt_total_g", "comp_th", "comp_th_g", "comp_pr", "comp_pr_g",
            "comp_total", "comp_total_g", "hea_th", "hea_th_g", "hea_pr", "hea_pr_g", "hea_total", "hea_total_g", "mor_th", "mor_th_g", "mor_pr", "mor_pr_g", "mor_total", "mor_total_g",
            "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point", "attendance"}


        Dim inputHash = prepareInputHash()
        Dim newInputHash As Hashtable = resultFunctions.calculateGrades(inputHash, class_name)
        Dim insertSQL As String = ""
        Try
            insertSQL = "INSERT INTO results_" & class_name & " ([student_id], [reg_number], [full_name], [school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[obt_th],[obt_th_g],[obt_pr],[obt_pr_g],[obt_total],[obt_total_g],[comp_th],[comp_th_g],[comp_pr],[comp_pr_g],[comp_total],[comp_total_g],
[hea_th],[hea_th_g],[hea_pr],[hea_pr_g],[hea_total],[hea_total_g],[mor_th],[mor_th_g],[mor_pr],[mor_pr_g],[mor_total],[mor_total_g],[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [attendance]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @obt_th, @obt_th_g, @obt_pr, @obt_pr_g, @obt_total, @obt_total_g, @comp_th, @comp_th_g, @comp_pr, @comp_pr_g, @comp_total, @comp_total_g, 
@hea_th, @hea_th_g, @hea_pr, @hea_pr_g, @hea_total, @hea_total_g, @mor_th, @mor_th_g, @mor_pr, @mor_pr_g, @mor_total, @mor_total_g, @total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @attendance)"


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

    Public Function prepareInputHash() As Hashtable
        Dim inputHash As Hashtable = New Hashtable
        Dim total_th = CDbl(engTh.Text) + CDbl(nepTh.Text) + CDbl(mathTh.Text) + CDbl(sciTh.Text) + CDbl(socTh.Text) + CDbl(obtTh.Text) + CDbl(compTh.Text) + CDbl(heaTh.Text) + CDbl(morTh.Text)
        Dim total_th_perc = total_th / 555 * 100
        Dim total_pr = CDbl(engPr.Text) + CDbl(nepPr.Text) + CDbl(mathPr.Text) + CDbl(sciPr.Text) + CDbl(socPr.Text) + CDbl(obtPr.Text) + CDbl(compPr.Text) + CDbl(heaPr.Text) + CDbl(morPr.Text)
        Dim total_pr_perc = total_pr / 245 * 100
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
        inputHash("obt_th") = obtTh.Text
        inputHash("obt_pr") = obtPr.Text
        inputHash("obt_total") = CDbl(obtTh.Text) + CDbl(obtPr.Text)
        inputHash("comp_th") = compTh.Text
        inputHash("comp_pr") = compPr.Text
        inputHash("comp_total") = CDbl(compTh.Text) + CDbl(compPr.Text)
        inputHash("hea_th") = heaTh.Text
        inputHash("hea_pr") = heaPr.Text
        inputHash("hea_total") = CDbl(heaTh.Text) + CDbl(heaPr.Text)
        inputHash("mor_th") = morTh.Text
        inputHash("mor_pr") = morPr.Text
        inputHash("mor_total") = CDbl(morTh.Text) + CDbl(morPr.Text)
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

    End Sub
End Class