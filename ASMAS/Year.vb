﻿Imports System.Data
Imports System.Data.OleDb
Public Class Year
    Public Shared Con As System.Data.OleDb.OleDbConnection
    Public Shared pwd As String
    Public Shared data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"
    Public Shared DS As New DataSet

    Public Shared current_year As String = "2073"
    Public Shared current_year_id As String

    Public Shared Property currentYear() As String
        Get
            Return current_year
        End Get
        Set(value As String)
            current_year = value
        End Set
    End Property

    Public Shared Property currentYearID() As String
        Get
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

            Dim SQL As String = "SELECT * from school_year where year_num = '" & current_year & "'"
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            DS.Tables.Clear()
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)
            current_year_id = DS.Tables(0).Rows(0)(0).ToString
            Return current_year_id
        End Get
        Set(value As String)
            current_year_id = value
        End Set
    End Property
End Class