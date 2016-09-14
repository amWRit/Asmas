Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class myFunctions
    Private Shared data_source_path As String = DBConnection.data_source_path
    Public Shared Con As System.Data.OleDb.OleDbConnection

    Public Shared Function getTextBoxes(_me As Form) As TextBox()
        Dim textBoxes As New List(Of TextBox)
        For Each c In _me.Controls
            If TypeName(c) = "TextBox" Then
                Dim tb As TextBox = DirectCast(c, TextBox)
                textBoxes.Add(tb)
            End If
        Next
        Return textBoxes.ToArray
    End Function

    Public Shared Sub clearTextBoxes(textBoxes As TextBox())
        For i As Integer = 0 To textBoxes.Count - 1
            textBoxes(i).Text = ""
        Next
    End Sub

    'prepare temp table for printing results - three different tables for three levels
    Public Shared Sub prepareTempTable(ByVal DS As DataSet, ByVal index As Integer, ByVal class_name As String, ByVal class_teacher As String, ByVal school_info As String())
        Dim Con As System.Data.OleDb.OleDbConnection

        'add current class results' first row to tempTable
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim table_name = myFunctions.getTempTableName(class_name)

        'first clear the tempTable
        Dim deleteSQL = "DELETE * from " & table_name
        Con.Open()
        Dim cmd As New OleDbCommand(deleteSQL, Con)
        cmd.ExecuteNonQuery()
        Con.Close()

        Dim hashKeys = resultFunctions.getResultTableHashKeys(class_name)

        Dim insertSQL As String = ""
        Dim inputHash As Hashtable = New Hashtable
        For Each key As String In hashKeys
            Dim val = DS.Tables(0).Rows(index)(key).ToString
            If val = "" Then val = "0"
            inputHash(key) = val
        Next

        Try
            insertSQL = getResultTableSQL(class_name, table_name)
            Con.Open()
            cmd = New OleDbCommand(insertSQL, Con)

            For Each key As String In hashKeys
                cmd.Parameters.AddWithValue("@" & key, inputHash(key))
            Next

            cmd.Parameters.AddWithValue("@class_teacher", class_teacher)
            cmd.Parameters.AddWithValue("@class_name", class_name)
            cmd.Parameters.AddWithValue("@school_full_name", school_info(0))
            cmd.Parameters.AddWithValue("@school_address", school_info(1))
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
            'AddTable()
        End Try
    End Sub

    Public Shared Function getTempTableName(ByVal className As String) As String
        Dim table_name = ""
        Dim primary As String() = {"1", "2", "3", "4", "5"}
        Dim lowSec As String() = {"6E", "6N", "7E", "7N", "8E", "8N"}
        Dim sec As String() = {"9E", "9N", "10E", "10A"}

        If primary.Contains(className) Then
            table_name = "printResultsPrimary"
        ElseIf lowSec.Contains(className) Then
            table_name = "printResultsLowSec"
        ElseIf sec.Contains(className) Then
            table_name = "printResultsSec"
        End If

        Return table_name
    End Function

    Public Shared Function getResultDataTable(ByVal _class_name As String) As DataTable
        Dim Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim table_name = myFunctions.getTempTableName(_class_name)
        'first clear the tempTable
        Dim SQL = "SELECT * from " & table_name
        Dim DT As New DataTable
        Con.Open() 'Open connection
        Dim Data As OleDbDataAdapter
        Data = New OleDbDataAdapter(SQL, Con)
        Con.Close()
        Data.Fill(DT)
        Return DT
    End Function


    Public Shared Function getResultTableSQL(ByVal className As String, ByVal table_name As String) As String
        Dim SQL As String = ""
        Dim primarySQL As String = "INSERT INTO " & table_name & " ([student_id], [reg_number], [full_name] ,[school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[opt_eng_th],[opt_eng_th_g],[opt_eng_pr],[opt_eng_pr_g],[opt_eng_total],[opt_eng_total_g],[gk_conv_th],[gk_conv_th_g],[gk_conv_pr],[gk_conv_pr_g],[gk_conv_total],[gk_conv_total_g],
[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [rank], [attendance], [class_teacher], [class], [school_full_name], [school_address]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @opt_eng_th, @opt_eng_th_g, @opt_eng_pr, @opt_eng_pr_g, @opt_eng_total, @opt_eng_total_g, @gk_conv_th, @gk_conv_th_g, @gk_conv_pr, @gk_conv_pr_g, @gk_conv_total, @gk_conv_total_g, 
@total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @rank, @attendance, @class_teacher, @class_name, @school_full_name, @school_address)"

        Dim lowSecSQL = "INSERT INTO " & table_name & " ([student_id], [reg_number], [full_name] ,[school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[obt_th],[obt_th_g],[obt_pr],[obt_pr_g],[obt_total],[obt_total_g],[comp_th],[comp_th_g],[comp_pr],[comp_pr_g],[comp_total],[comp_total_g],
[hea_th],[hea_th_g],[hea_pr],[hea_pr_g],[hea_total],[hea_total_g],[mor_th],[mor_th_g],[mor_pr],[mor_pr_g],[mor_total],[mor_total_g],[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [rank], [attendance], [class_teacher], [class], [school_full_name], [school_address]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @obt_th, @obt_th_g, @obt_pr, @obt_pr_g, @obt_total, @obt_total_g, @comp_th, @comp_th_g, @comp_pr, @comp_pr_g, @comp_total, @comp_total_g, 
@hea_th, @hea_th_g, @hea_pr, @hea_pr_g, @hea_total, @hea_total_g, @mor_th, @mor_th_g, @mor_pr, @mor_pr_g, @mor_total, @mor_total_g, @total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @rank, @attendance, @class_teacher, @class_name, @school_full_name, @school_address)"

        Dim secSQL As String = "INSERT INTO " & table_name & " ([student_id], [reg_number], [full_name],[school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[eph_th],[eph_th_g],[eph_pr],[eph_pr_g],[eph_total],[eph_total_g],[opt1_th],[opt1_th_g],[opt1_pr],[opt1_pr_g],[opt1_total],[opt1_total_g],
[opt2_th],[opt2_th_g],[opt2_pr],[opt2_pr_g],[opt2_total],[opt2_total_g],[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [opt1], [opt2], [rank], [attendance], [class_teacher], [class], [school_full_name], [school_address]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @eph_th, @eph_th_g, @eph_pr, @eph_pr_g, @eph_total, @eph_total_g, @opt1_th, @opt1_th_g, @opt1_pr, @opt1_pr_g, @opt1_total, @opt1_total_g, 
@opt2_th, @opt2_th_g, @opt2_pr, @opt2_pr_g, @opt2_total, @opt2_total_g, @total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @opt1, @opt2, @rank, @attendance, @class_teacher, @class_name, @school_full_name, @school_address)"

        Dim primary As String() = {"1", "2", "3", "4", "5"}
        Dim lowSec As String() = {"6E", "6N", "7E", "7N", "8E", "8N"}
        Dim sec As String() = {"9E", "9N", "10E", "10A"}

        If primary.Contains(className) Then
            SQL = primarySQL
        ElseIf lowSec.Contains(className) Then
            SQL = lowSecSQL
        ElseIf sec.Contains(className) Then
            SQL = secSQL
        End If
        Return SQL
    End Function

    Public Shared Function getClassTeacherName(ByVal school_name As String, ByVal year_num As String, ByVal class_name As String) As String
        Dim class_teacher = ""
        Dim Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Dim SQL As String = ""

        SQL = "SELECT class_teacher from class
                where short_name='" & class_name & "' and year_id=(SELECT year_id  from school_year
                where year_num='" & year_num & "' and school_id=(SELECT school_id from
                school where short_name='" & school_name & "'));"
        Try
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            class_teacher = DS.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try

        Return class_teacher
    End Function

    Public Shared Function getSchoolNameAddress(short_name As String) As String()
        Dim school_info As String() = {"", ""}
        Dim Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Dim SQL As String = ""

        SQL = "SELECT full_name, address from school where short_name = '" & short_name & "'"
        Try
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            school_info(0) = DS.Tables(0).Rows(0)(0).ToString
            school_info(1) = DS.Tables(0).Rows(0)(1).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try

        Return school_info
    End Function


    Public Shared Function getStudentIdsOf(class_id As String) As Integer()
        Dim student_ids As Integer() = {}

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            SQL = "SELECT student_id FROM class_student where class_id=" & class_id
            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count
            ReDim Preserve student_ids(rowCount - 1)

            For i As Integer = 0 To rowCount - 1
                student_ids(i) = CInt(DS.Tables(0).Rows(i)(0))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        Return student_ids
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

            Dim reg_number = DS.Tables(0).Rows(0)(3).ToString
            Dim student_name = DS.Tables(0).Rows(0)(0).ToString & " " & DS.Tables(0).Rows(0)(1).ToString & " " & DS.Tables(0).Rows(0)(2).ToString
            studentInfo = {reg_number, student_name}
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try

        Return studentInfo
    End Function

    Public Shared Function getClassSubjectsOf(class_id As String) As String()
        Dim subjects As String() = {}

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            'find the student reg_number and name
            SQL = "SELECT subject_name from subject_teacher where class_id = " & class_id
            Con.Open() 'Open connection

            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count
            ReDim Preserve subjects(rowCount - 1)

            For i As Integer = 0 To rowCount - 1
                subjects(i) = DS.Tables(0).Rows(i)(0).ToString
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try

        Return subjects
    End Function

    Public Shared Function getStudentIdOf(regNumber As String) As String
        Dim student_id As String = ""
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            Dim oData As OleDbDataAdapter
            SQL = "SELECT * FROM STUDENT where reg_number='" & regNumber & "'"
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            DS.Tables.Clear()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count
            If rowCount > 0 Then
                student_id = DS.Tables(0).Rows(0).Item("id").ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
        Return student_id
    End Function

    Public Shared Function getClassIdOf(school_id As String, year_id As String, class_name As String) As String
        Dim class_id As String = ""
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            Dim oData As OleDbDataAdapter
            SQL = "SELECT * FROM CLASS where school_id=" & school_id & " and year_id=" & year_id & " and short_name='" & class_name & "'"
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            DS.Tables.Clear()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count
            If rowCount > 0 Then
                class_id = DS.Tables(0).Rows(0).Item("class_id").ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
        Return class_id
    End Function


End Class
