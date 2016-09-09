Imports System.Data
Imports System.Data.OleDb

Public Class TheClass
    Public Shared Con As System.Data.OleDb.OleDbConnection
    Public Shared pwd As String
    Private Shared data_source_path As String = DBConnection.data_source_path
    Public Shared DS As New DataSet

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
End Class
