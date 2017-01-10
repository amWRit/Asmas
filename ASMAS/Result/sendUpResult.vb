Imports System.Data
Imports System.Data.OleDb

Public Class sendUpResult
    Private Shared data_source_path As String = DBConnection.data_source_path
    Public Shared Con As System.Data.OleDb.OleDbConnection

    Public Shared contents As String() = {}
    Public Shared lowPrimary As String() = {"1", "2", "3"}
    Public Shared highPrimary As String() = {"4", "5"}
    Public Shared primary As String() = TheClass.primaryShortNames
    Public Shared lowSec As String() = TheClass.lowSecShortNames
    Public Shared sec As String() = TheClass.secShortNames

    'calculate sendup marks by average of first,second, third
    Public Shared Sub sendupCalculations(terminal As String, school_name As String, year_num As String, class_name As String, class_id As String)
        ' get student ids
        Dim student_ids As Integer() = {}
        student_ids = myFunctions.getStudentIdsOf(class_id)
        'prepare input hash by average
        Dim hashKeys = resultFunctions.getResultTableHashKeys(class_name)

        'for each student_id
        For i As Integer = 0 To student_ids.Count - 1
            Dim student_id = student_ids(i)
            ' student_info = f_name, m_name, l_name, reg_number
            Dim student_info As String() = getStudentInfoOf(student_id)
            Dim reg_number = student_info(3)
            Dim full_name = student_info(0) & " " & student_info(1) & " " & student_info(2)
            Dim params As String() = {student_id.ToString, reg_number, full_name, terminal, school_name, year_num, class_name}

            'load first,second,third term results
            Dim firstTermResult = getResult({student_id.ToString, year_num, school_name, class_name, "first"}).Tables(0)
            Dim secondTermResult = getResult({student_id.ToString, year_num, school_name, class_name, "second"}).Tables(0)
            Dim thirdTermResult = getResult({student_id.ToString, year_num, school_name, class_name, "third"}).Tables(0)

            Dim resultDataRows As DataRow() = {}
            If firstTermResult.Rows.Count > 0 Then resultDataRows.Add(firstTermResult.Rows(0))
            If secondTermResult.Rows.Count > 0 Then resultDataRows.Add(secondTermResult.Rows(0))
            If thirdTermResult.Rows.Count > 0 Then resultDataRows.Add(thirdTermResult.Rows(0))

            'prepare input hash
            Dim inputHash = prepareInputHash(resultDataRows, params)
            Dim newInputHash As Hashtable = resultFunctions.calculateGrades(inputHash, class_name)

            'insert / update sendup data
            'checkifpresent
            Dim present = resultFunctions.checkIfPresent(school_name, year_num, student_id.ToString, terminal, class_name)
            Dim SQL = ""
            Dim newParams As String() = {year_num, school_name, terminal, class_name, student_id.ToString}

            If present = False Then
                SQL = buildInsertResultSQL(class_name)
            Else
                SQL = resultFunctions.buildUpdateResultSQL(newParams, Con)
            End If

            updateResultData(SQL, newParams, hashKeys, newInputHash)
        Next
        MessageBox.Show("All calculations successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    'params {student_id, year, school_name, className, terminal}
    Public Shared Function getResult(params As String()) As DataSet
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
            SQL = resultFunctions.getLoadResultSQL(school_year, school_name, className, student_id, terminal)
            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Return DS
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Function

    '{student_id, reg_number, full_name, terminal, school_name, year_num,  class_name}
    Public Shared Function prepareInputHash(resultDataRows As DataRow(), params As String()) As Hashtable
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

        Dim theorySub = resultFunctions.getSubjects("theory", class_name)
        Dim pracSub = resultFunctions.getSubjects("prac", class_name)
        Dim totalSub = resultFunctions.getSubjects("total", class_name)
        Dim total_th As Double = 0
        Dim total_pr As Double = 0

        For Each key As String In theorySub
            Dim totVal As Double = 0
            For Each DR As DataRow In resultDataRows
                Dim val = DR.Item(key).ToString
                If val = "" Then val = "0"
                totVal += CDbl(val)
            Next
            inputHash(key) = totVal / resultDataRows.Count
            total_th += CDbl(inputHash(key))
        Next
        For Each key As String In pracSub
            Dim totVal As Double = 0
            For Each DR As DataRow In resultDataRows
                Dim val = DR.Item(key).ToString
                If val = "" Then val = "0"
                totVal += CDbl(val)
            Next
            inputHash(key) = totVal / resultDataRows.Count
            total_pr += CDbl(inputHash(key))
        Next
        For i As Integer = 0 To theorySub.Count - 1
            Dim th_key As String = theorySub(i)
            Dim pr_key As String = pracSub(i)
            Dim total_key As String = totalSub(i)
            inputHash(total_key) = CDbl(inputHash(th_key)) + CDbl(inputHash(pr_key))
        Next

        If sec.Contains(class_name) Then
            inputHash("opt1") = resultDataRows(0).Item("opt1")
            inputHash("opt2") = resultDataRows(0).Item("opt2")
        End If

        inputHash("total_th") = total_th
        inputHash("total_pr") = total_pr
        inputHash("total") = total_th + total_pr
        inputHash = resultFunctions.addMoreInputs(inputHash, class_name) 'total_th_perc, total_pr_perc, percentage
        inputHash("attendance") = 0  'dummy - has to be updated manually

        inputHash("attendance") = resultDataRows.Last.Item("attendance")

        'inputHash("rank") = 0 'dummy - separate method/button for updating rank, which will run at end
        Return inputHash
    End Function


    Public Shared Function getStudentInfoOf(student_id As Integer) As String()
        Dim studentInfo As String() = {}

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            'find the student reg_number and name
            SQL = "SELECT  f_name, m_name, l_name, reg_number from student where id = " & student_id
            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim f_name = DS.Tables(0).Rows(0)(0).ToString
            Dim m_name = DS.Tables(0).Rows(0)(1).ToString
            Dim l_name = DS.Tables(0).Rows(0)(2).ToString
            Dim reg_number = DS.Tables(0).Rows(0)(3).ToString
            studentInfo = {f_name, m_name, l_name, reg_number}
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try

        Return studentInfo
    End Function

    'params = {year_num, school_name, terminal, class_name, student_id}
    Public Shared Sub updateResultData(SQL As String, params As String(), hashkeys As String(), newInputHash As Hashtable)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        'Dim updateSQL = resultFunctions.buildUpdateResultSQL(params, Con)
        Try
            Con.Open()
            Dim cmd As New OleDbCommand(SQL, Con)

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

    ' params = {school_year, school_name, terminal, class_name, class_id, student_id}

    Public Shared Function buildInsertResultSQL(class_name As String) As String
        Dim insertSQL_primary = "INSERT INTO results_" & class_name & " ([student_id], [reg_number], [full_name], [school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[opt_eng_th],[opt_eng_th_g],[opt_eng_pr],[opt_eng_pr_g],[opt_eng_total],[opt_eng_total_g],[gk_conv_th],[gk_conv_th_g],[gk_conv_pr],[gk_conv_pr_g],[gk_conv_total],[gk_conv_total_g],
[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [attendance]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @opt_eng_th, @opt_eng_th_g, @opt_eng_pr, @opt_eng_pr_g, @opt_eng_total, @opt_eng_total_g, @gk_conv_th, @gk_conv_th_g, @gk_conv_pr, @gk_conv_pr_g, @gk_conv_total, @gk_conv_total_g, 
@total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @attendance)"

        Dim insertSQL_lowSec = "INSERT INTO results_" & class_name & " ([student_id], [reg_number], [full_name], [school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[obt_th],[obt_th_g],[obt_pr],[obt_pr_g],[obt_total],[obt_total_g],[comp_th],[comp_th_g],[comp_pr],[comp_pr_g],[comp_total],[comp_total_g],
[hea_th],[hea_th_g],[hea_pr],[hea_pr_g],[hea_total],[hea_total_g],[mor_th],[mor_th_g],[mor_pr],[mor_pr_g],[mor_total],[mor_total_g],[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [attendance]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @obt_th, @obt_th_g, @obt_pr, @obt_pr_g, @obt_total, @obt_total_g, @comp_th, @comp_th_g, @comp_pr, @comp_pr_g, @comp_total, @comp_total_g, 
@hea_th, @hea_th_g, @hea_pr, @hea_pr_g, @hea_total, @hea_total_g, @mor_th, @mor_th_g, @mor_pr, @mor_pr_g, @mor_total, @mor_total_g, @total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @attendance)"

        Dim insertSQL_sec = "INSERT INTO results_" & class_name & " ([student_id], [reg_number], [full_name], [school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[eph_th],[eph_th_g],[eph_pr],[eph_pr_g],[eph_total],[eph_total_g],[opt1_th],[opt1_th_g],[opt1_pr],[opt1_pr_g],[opt1_total],[opt1_total_g],
[opt2_th],[opt2_th_g],[opt2_pr],[opt2_pr_g],[opt2_total],[opt2_total_g],[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [opt1], [opt2], [attendance]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @eph_th, @eph_th_g, @eph_pr, @eph_pr_g, @eph_total, @eph_total_g, @opt1_th, @opt1_th_g, @opt1_pr, @opt1_pr_g, @opt1_total, @opt1_total_g, 
@opt2_th, @opt2_th_g, @opt2_pr, @opt2_pr_g, @opt2_total, @opt2_total_g, @total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @opt1, @opt2, @attendance)"

        If primary.Contains(class_name) Then
            Return insertSQL_primary
        ElseIf lowSec.Contains(class_name) Then
            Return insertSQL_lowSec
        Else
            Return insertSQL_sec
        End If
        Return ""
    End Function
End Class
