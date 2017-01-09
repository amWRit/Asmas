Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports Microsoft.Reporting.WinForms

Public Class printCertificatePrimary
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path
    Public resultDS As DataSet
    Public _index As Integer
    Public _class_name As String
    Public _class_teacher As String
    Public _school_info As String()
    Public _class_id As String
    Public _student_info As String()

    Private Sub printCertificatePrimary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'printDataSet.printResultsPrimary' table. You can move, or remove it, as needed.
        Me.printResultsPrimaryTableAdapter.Fill(Me.printDataSet.printResultsPrimary)
        Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Sub New(ByVal tempDS As DataSet, ByVal index As Integer, ByVal class_name As String, ByVal class_teacher As String, school_info As String(), class_id As String)
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        resultDS = tempDS
        _index = index
        _class_id = class_id
        _class_name = class_name
        _class_teacher = class_teacher
        _school_info = school_info
        Dim student_id = tempDS.Tables(0).Rows(index)("student_id")
        Dim student_info = myFunctions.getStudentInfoOf(CInt(student_id))
        _student_info = student_info
        myFunctions.prepareTempTable(resultDS, _index, class_name, class_teacher, _school_info, student_info, _class_id)
        If resultDS.Tables(0).Rows.Count = 1 Then nextBtn.Enabled = False
        prepareReport()
    End Sub

    Private Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        _index += 1
        If previousBtn.Enabled = False Then previousBtn.Enabled = True
        If _index = resultDS.Tables(0).Rows.Count - 1 Then nextBtn.Enabled = False
        Dim student_id = resultDS.Tables(0).Rows(_index)("student_id")
        Dim student_info = myFunctions.getStudentInfoOf(CInt(student_id))
        _student_info = student_info
        myFunctions.prepareTempTable(resultDS, _index, _class_name, _class_teacher, _school_info, student_info, _class_id)
        prepareReport()
    End Sub

    Private Sub previousBtn_Click(sender As Object, e As EventArgs) Handles previousBtn.Click
        _index -= 1
        If nextBtn.Enabled = False Then nextBtn.Enabled = True
        If _index = 0 Then previousBtn.Enabled = False
        Dim student_id = resultDS.Tables(0).Rows(_index)("student_id")
        Dim student_info = myFunctions.getStudentInfoOf(CInt(student_id))
        _student_info = student_info
        myFunctions.prepareTempTable(resultDS, _index, _class_name, _class_teacher, _school_info, student_info, _class_id)
        prepareReport()
    End Sub

    Public Sub prepareReport()
        Me.Validate()
        Me.printResultsPrimaryBindingSource.EndEdit()
        Me.printResultsPrimaryBindingSource.DataSource = myFunctions.getResultDataTable(_class_name)
        Me.printResultsPrimaryTableAdapter.Update(Me.printDataSet.printResultsPrimary)
        loadStudentPhoto()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Sub loadStudentPhoto()
        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Dim student_reg = _student_info(0)
        Dim student_name = _student_info(1).Replace(" ", "")
        Dim strBasePath = Application.StartupPath & "\StudentPhotos\"
        Dim imageName = student_name & "" & student_reg & ".jpg"
        Dim imagePath = strBasePath & imageName

        If imagePath = "" Or Not System.IO.File.Exists(imagePath) Then
            imagePath = Application.StartupPath & "\StudentPhotos\photo_not_available.png"
        End If

        Dim templateImage = New Uri("file:\" & imagePath).AbsoluteUri
        Try
            ReportViewer1.LocalReport.SetParameters(New ReportParameter("studentPhotoParam", templateImage))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class