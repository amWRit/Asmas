﻿Imports System.Data
Imports System.Data.OleDb
Public Class Year
    Public Shared Con As System.Data.OleDb.OleDbConnection
    Public Shared pwd As String
    Private Shared data_source_path As String = DBConnection.data_source_path
    Public Shared DS As New DataSet

    Public Shared BS As Date = ConvertToBS(Date.Today)

    Public Shared current_year As String = BS.Year.ToString
    Public Shared current_year_id As String

    Public Shared Property currentYear() As String
        Get
            Return current_year
        End Get
        Set(value As String)
            current_year = value
        End Set
    End Property

    Public Shared Property currentYearID(school_id As Integer) As String
        Get
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

            Dim SQL As String = "SELECT * from school_year where year_num = '" & current_year & "' and school_id=" & school_id
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            DS.Tables.Clear()
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)
            If DS.Tables(0).Rows.Count > 0 Then
                current_year_id = DS.Tables(0).Rows(0)(0).ToString
            Else
                current_year_id = "0" 'to prevent out of index error
            End If
            Return current_year_id
        End Get
        Set(value As String)
            current_year_id = value
        End Set
    End Property

    Public Shared Function ConvertToBS(ByVal ad As Date) As Date
        'About Nepali Calendar
        'Nepali Calendar is based on Bikram Sambat and is 56 years and 8 
        'months ahead of A.D. The Bikram Sambat calendar was started 
        'in 57 B.C. by King Bikramaditya in India. 

        Dim bs As New Date
        bs = ad.AddYears(56)
        bs = bs.AddMonths(8)
        Return bs
    End Function

    Public Shared Function nextYear() As Integer
        Dim next_year As Date = Date.Today.AddYears(1)
        Return ConvertToBS(next_year).Year
    End Function

    Public Shared Function getYearID(school_id As String, year_num As String) As String
        Dim year_id As String = ""
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = "SELECT * from school_year where year_num = '" & year_num & "' and school_id=" & school_id
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Try
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            DS.Tables.Clear()
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)
            year_id = DS.Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        Return year_id
    End Function
End Class
