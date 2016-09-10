Imports System.Data
Imports System.Data.OleDb

Public Class User
    Public Shared Con As System.Data.OleDb.OleDbConnection
    Public Shared pwd As String
    Private Shared data_source_path As String = DBConnection.data_source_path
    Public Shared DS As New DataSet

    Public Shared id As String
    Public Shared me_user As DataSet
    Public Shared _name As String
    Private Shared _role As String
    Private Shared full_name As String

    Public Shared Property user() As DataSet
        Get
            Return me_user
        End Get
        Set(ByVal value As DataSet)
            me_user = value
        End Set
    End Property

    Public Shared Property userID() As String
        Get
            id = me_user.Tables(0).Rows(0).Item("user_id").ToString()
            Return id
        End Get
        Set(ByVal value As String)
            id = value
        End Set
    End Property

    Public Shared Property userName() As String
        Get
            _name = me_user.Tables(0).Rows(0).Item("user_name").ToString()
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Shared Property userRole() As String
        Get
            _role = me_user.Tables(0).Rows(0).Item("role").ToString()
            Return _role
        End Get
        Set(value As String)
            _role = value
        End Set
    End Property

    Public Shared Property fullName() As String
        Get
            full_name = me_user.Tables(0).Rows(0).Item("full_name").ToString()
            Return full_name
        End Get
        Set(value As String)
            full_name = value
        End Set
    End Property

    Public Shared Function isAdmin(user_id As String) As Boolean
        Dim admin = False
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""

        Try
            Dim oData As OleDbDataAdapter
            SQL = "SELECT * from [user] where user_id=" & user_id
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            DS.Tables.Clear()
            oData.Fill(DS)
            Dim role = DS.Tables(0).Rows(0).Item("role").ToString
            If role = "Admin" Then
                admin = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
        Return admin
    End Function
End Class
