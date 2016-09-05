Imports System.Data
Imports System.Data.OleDb
Imports System.Configuration

Public Class DBConnection
    Private user_name As String
    Dim mypassword As String = ""
    Private pwd As String
    Public Shared data_source_path As String = "..\Database\Terse.accdb"
    Public Shared connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

End Class
