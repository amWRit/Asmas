Imports System.Data
Imports System.Data.OleDb
Public Class classDetailsForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Private class_id As String
    Private Sub classDetailsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByVal itemID As String)

        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
        class_id = itemID
        Try
            Dim SQL As String = "SELECT * from CLASS where class_id=" & itemID
            Dim DS As DataSet 'Object to store data in
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            Dim school_id As Integer = CInt(DS.Tables(0).Rows(0)(1))
            Dim year_id As Integer = CInt(DS.Tables(0).Rows(0)(2))
            Dim short_name = DS.Tables(0).Rows(0)(3)
            Dim full_name = DS.Tables(0).Rows(0)(4)
            Dim size = DS.Tables(0).Rows(0)(5)
            Dim class_teacher = DS.Tables(0).Rows(0)(6)

            'get school name
            Dim schoolSQL As String = "SELECT short_name from SCHOOl where school_id=" & school_id
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Con.Open() 'Open connection
            Dim schoolData As OleDbDataAdapter
            DS.Tables.Clear()
            schoolData = New OleDbDataAdapter(schoolSQL, Con)
            Con.Close()
            schoolData.Fill(DS)

            Dim school_name = DS.Tables(0).Rows(0)(0)

            'get year number
            Dim yearSQL As String = "SELECT year_num from school_year where year_id=" & year_id
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Con.Open() 'Open connection
            DS.Tables.Clear()
            Dim yearData As OleDbDataAdapter
            yearData = New OleDbDataAdapter(yearSQL, Con)
            Con.Close()
            yearData.Fill(DS)

            Dim year_num = DS.Tables(0).Rows(0)(0)

            'Populate details onto form

            titleLabel.Text = titleLabel.Text & " (ID =  " & itemID & ")"
            schoolName.Text = school_name.ToString
            yearNum.Text = year_num.ToString
            shortName.Text = short_name.ToString
            fullname.Text = full_name.ToString
            sizeOfClass.Text = size.ToString
            ct.Text = class_teacher.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
            'searchResultListView.Items.Clear()

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub addStudentBtn_Click(sender As Object, e As EventArgs) Handles addStudentBtn.Click
        Dim _addStudentToClassForm As New addStudentToClassForm(class_id)
        _addStudentToClassForm.Show()
    End Sub

    Private Sub editBtn_Click(sender As Object, e As EventArgs) Handles editBtn.Click

    End Sub
End Class