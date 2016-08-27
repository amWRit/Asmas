Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class myFunctions
    Public Shared data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    'prepare temp table for printing results - three different tables for three levels
    Public Shared Sub prepareTempTable(ByVal DS As DataSet, ByVal index As Integer, ByVal class_name As String)
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

        Dim hashKeys = getResultTableHashKeys(class_name)

        Dim insertSQL As String = ""
        Dim inputHash As Hashtable = New Hashtable
        For Each key As String In hashKeys
            inputHash(key) = DS.Tables(0).Rows(index)(key).ToString
        Next

        Try
            insertSQL = getResultTableSQL(class_name, table_name)
            Con.Open()
            cmd = New OleDbCommand(insertSQL, Con)

            For Each key As String In hashKeys
                cmd.Parameters.AddWithValue("@" & key, inputHash(key))
            Next

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

    Public Shared Function getResultTableHashKeys(ByVal className As String) As String()
        Dim lowSecHashKeys As String() = {"student_id", "reg_number", "full_name", "school_year", "school_name", "terminal", "eng_th", "eng_th_g", "eng_pr", "eng_pr_g", "eng_total", "eng_total_g", "nep_th", "nep_th_g", "nep_pr",
            "nep_pr_g", "nep_total", "nep_total_g", "math_th", "math_th_g", "math_pr", "math_pr_g", "math_total", "math_total_g", "sci_th", "sci_th_g", "sci_pr", "sci_pr_g", "sci_total", "sci_total_g",
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "obt_th", "obt_th_g", "obt_pr", "obt_pr_g", "obt_total", "obt_total_g", "comp_th", "comp_th_g", "comp_pr", "comp_pr_g",
            "comp_total", "comp_total_g", "hea_th", "hea_th_g", "hea_pr", "hea_pr_g", "hea_total", "hea_total_g", "mor_th", "mor_th_g", "mor_pr", "mor_pr_g", "mor_total", "mor_total_g",
            "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point", "rank", "attendance"}
        Dim primaryHashKeys As String() = {"student_id", "reg_number", "full_name", "school_year", "school_name", "terminal", "eng_th", "eng_th_g", "eng_pr", "eng_pr_g", "eng_total", "eng_total_g", "nep_th", "nep_th_g", "nep_pr",
            "nep_pr_g", "nep_total", "nep_total_g", "math_th", "math_th_g", "math_pr", "math_pr_g", "math_total", "math_total_g", "sci_th", "sci_th_g", "sci_pr", "sci_pr_g", "sci_total", "sci_total_g",
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "opt_eng_th", "opt_eng_th_g", "opt_eng_pr", "opt_eng_pr_g", "opt_eng_total", "opt_eng_total_g", "gk_conv_th", "gk_conv_th_g", "gk_conv_pr", "gk_conv_pr_g",
            "gk_conv_total", "gk_conv_total_g", "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "grade_point", "rank", "attendance"}
        Dim SecHashKeys As String() = {"student_id", "reg_number", "full_name", "school_year", "school_name", "terminal", "eng_th", "eng_th_g", "eng_pr", "eng_pr_g", "eng_total", "eng_total_g", "nep_th", "nep_th_g", "nep_pr",
            "nep_pr_g", "nep_total", "nep_total_g", "math_th", "math_th_g", "math_pr", "math_pr_g", "math_total", "math_total_g", "sci_th", "sci_th_g", "sci_pr", "sci_pr_g", "sci_total", "sci_total_g",
            "soc_th", "soc_th_g", "soc_pr", "soc_pr_g", "soc_total", "soc_total_g", "eph_th", "eph_th_g", "eph_pr", "eph_pr_g", "eph_total", "eph_total_g", "opt1_th", "opt1_th_g", "opt1_pr", "opt1_pr_g",
            "opt1_total", "opt1_total_g", "opt2_th", "opt2_th_g", "opt2_pr", "opt2_pr_g", "opt2_total", "opt2_total_g",
            "total_th", "total_th_g", "total_pr", "total_pr_g", "total", "percentage", "grade", "opt1", "opt2", "grade_point", "rank", "attendance"}

        Dim hashKeys As String() = {}
        Dim primary As String() = {"1", "2", "3", "4", "5"}
        Dim lowSec As String() = {"6E", "6N", "7E", "7N", "8E", "8N"}
        Dim sec As String() = {"9E", "9N", "10E", "10A"}

        If primary.Contains(className) Then
            hashKeys = primaryHashKeys
        ElseIf lowSec.Contains(className) Then
            hashKeys = lowSecHashKeys
        ElseIf sec.Contains(className) Then
            hashKeys = SecHashKeys
        End If

        Return hashKeys
    End Function

    Public Shared Function getResultTableSQL(ByVal className As String, ByVal table_name As String) As String
        Dim SQL As String = ""
        Dim primarySQL As String = "INSERT INTO " & table_name & " ([student_id], [reg_number], [full_name] ,[school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[opt_eng_th],[opt_eng_th_g],[opt_eng_pr],[opt_eng_pr_g],[opt_eng_total],[opt_eng_total_g],[gk_conv_th],[gk_conv_th_g],[gk_conv_pr],[gk_conv_pr_g],[gk_conv_total],[gk_conv_total_g],
[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [rank], [attendance]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @opt_eng_th, @opt_eng_th_g, @opt_eng_pr, @opt_eng_pr_g, @opt_eng_total, @opt_eng_total_g, @gk_conv_th, @gk_conv_th_g, @gk_conv_pr, @gk_conv_pr_g, @gk_conv_total, @gk_conv_total_g, 
@total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @rank, @attendance)"

        Dim lowSecSQL = "INSERT INTO " & table_name & " ([student_id], [reg_number], [full_name] ,[school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[obt_th],[obt_th_g],[obt_pr],[obt_pr_g],[obt_total],[obt_total_g],[comp_th],[comp_th_g],[comp_pr],[comp_pr_g],[comp_total],[comp_total_g],
[hea_th],[hea_th_g],[hea_pr],[hea_pr_g],[hea_total],[hea_total_g],[mor_th],[mor_th_g],[mor_pr],[mor_pr_g],[mor_total],[mor_total_g],[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [rank], [attendance]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @obt_th, @obt_th_g, @obt_pr, @obt_pr_g, @obt_total, @obt_total_g, @comp_th, @comp_th_g, @comp_pr, @comp_pr_g, @comp_total, @comp_total_g, 
@hea_th, @hea_th_g, @hea_pr, @hea_pr_g, @hea_total, @hea_total_g, @mor_th, @mor_th_g, @mor_pr, @mor_pr_g, @mor_total, @mor_total_g, @total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @rank, @attendance)"

        Dim secSQL As String = "INSERT INTO " & table_name & " ([student_id], [reg_number], [full_name],[school_year],[school_name],[terminal],[eng_th],[eng_th_g],[eng_pr],[eng_pr_g],[eng_total],[eng_total_g],
[nep_th],[nep_th_g],[nep_pr],[nep_pr_g],[nep_total],[nep_total_g],[math_th],[math_th_g],[math_pr],[math_pr_g],[math_total],[math_total_g],[sci_th],[sci_th_g],[sci_pr],[sci_pr_g],[sci_total],[sci_total_g],
[soc_th],[soc_th_g],[soc_pr],[soc_pr_g],[soc_total],[soc_total_g],[eph_th],[eph_th_g],[eph_pr],[eph_pr_g],[eph_total],[eph_total_g],[opt1_th],[opt1_th_g],[opt1_pr],[opt1_pr_g],[opt1_total],[opt1_total_g],
[opt2_th],[opt2_th_g],[opt2_pr],[opt2_pr_g],[opt2_total],[opt2_total_g],[total_th],[total_th_g],[total_pr],[total_pr_g],[total],[percentage],[grade],[grade_point], [opt1], [opt2], [rank], [attendance]) 
VALUES
(@student_id, @reg_number, @full_name, @school_year, @school_name, @terminal, @eng_th, @eng_th_g, @eng_pr, @eng_pr_g, @eng_total, @eng_total_g, @nep_th, @nep_th_g, @nep_pr, @nep_pr_g,
@nep_total, @nep_total_g, @math_th, @math_th_g, @math_pr, @math_pr_g, @math_total, @math_total_g, @sci_th, @sci_th_g, @sci_pr, @sci_pr_g, @sci_total, @sci_total_g, 
@soc_th, @soc_th_g, @soc_pr, @soc_pr_g, @soc_total, @soc_total_g, @eph_th, @eph_th_g, @eph_pr, @eph_pr_g, @eph_total, @eph_total_g, @opt1_th, @opt1_th_g, @opt1_pr, @opt1_pr_g, @opt1_total, @opt1_total_g, 
@opt2_th, @opt2_th_g, @opt2_pr, @opt2_pr_g, @opt2_total, @opt2_total_g, @total_th, @total_th_g, @total_pr, @total_pr_g, @total, @percentage, @grade, @grade_point, @opt1, @opt2, @rank, @attendance)"

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

End Class
