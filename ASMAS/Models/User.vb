Public Class User
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
End Class
