Imports System.Data
Imports System.Data.OleDb

Public Class TheClass
    Public Shared Con As System.Data.OleDb.OleDbConnection
    Public Shared pwd As String
    Private Shared data_source_path As String = DBConnection.data_source_path
    Public Shared DS As New DataSet

    Public Shared AcceptableClassShortNames As String() = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "1A", "2A", "3A", "4A", "5A", "6A", "7A", "8A", "9A", "10A", "1B", "2B", "3B", "4B", "5B", "6B", "7B", "8B", "9B", "10B", "1E", "2E", "3E", "4E", "5E", "6E", "7E", "8E", "9E", "10E", "1N", "2N", "3N", "4N", "5N", "6N", "7N", "8N", "9N", "10N"}
    Public Shared primaryShortNames As String() = {"1", "2", "3", "4", "5", "1A", "2A", "3A", "4A", "5A", "1B", "2B", "3B", "4B", "5B", "1E", "2E", "3E", "4E", "5E", "1N", "2N", "3N", "4N", "5N"}
    Public Shared lowSecShortNames As String() = {"6", "7", "8", "6A", "7A", "8A", "6B", "7B", "8B", "6E", "7E", "8E", "6N", "7N", "8N"}
    Public Shared secShortNames As String() = {"9", "10", "9A", "10A", "9B", "10B", "9E", "10E", "9N", "10N"}

    Public Shared primaryRegEx As String = "[1-5]*"
    Public Shared lowSecRegEx As String = "[6-8]*"
    Public Shared SecRegEx1 As String = "9*"
    Public Shared secRegEx2 As String = "10*"

    Public Shared school_id As Integer

    Public Shared Property schoolId(class_id As Integer) As Integer
        Get
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

            Dim SQL As String = "SELECT distinct school_id from CLASS where class_id = " & class_id
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            DS.Tables.Clear()
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)
            school_id = CInt(DS.Tables(0).Rows(0)(0))
            Return school_id
        End Get
        Set(value As Integer)
            school_id = value
        End Set
    End Property

    Public Shared Function getClassName(class_id As Integer) As String
        Dim class_name = ""
        Try
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Dim SQL As String = "SELECT short_name from class where class_id=" & class_id
            Con.Open() 'Open connection
            Dim ctData As OleDbDataAdapter
            ctData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            ctData.Fill(DS)
            class_name = (DS.Tables(0).Rows(0)(0)).ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        Return class_name
    End Function
End Class
