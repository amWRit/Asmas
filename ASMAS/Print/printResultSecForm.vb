Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class printResultSecForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path
    Public resultDS As DataSet
    Public _index As Integer
    Public _class_name As String
    Public _class_teacher As String
    Public _school_info As String()

    Private Sub printResultSecForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TerseDataSet.printResultsSec' table. You can move, or remove it, as needed.
        Me.printResultsSecTableAdapter.Fill(Me.TerseDataSet.printResultsSec)
        Me.secReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.secReportViewer.RefreshReport()
    End Sub

    Public Sub New(ByVal tempDS As DataSet, ByVal index As Integer, ByVal class_name As String, ByVal class_teacher As String, school_info As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        resultDS = tempDS
        _index = index
        _class_name = class_name
        _class_teacher = class_teacher
        _school_info = school_info
        myFunctions.prepareTempTable(resultDS, _index, class_name, class_teacher, school_info)
        If resultDS.Tables(0).Rows.Count = 1 Then nextBtn.Enabled = False
        prepareReport()
    End Sub

    Private Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        _index += 1
        If previousBtn.Enabled = False Then previousBtn.Enabled = True
        If _index = resultDS.Tables(0).Rows.Count - 1 Then nextBtn.Enabled = False
        myFunctions.prepareTempTable(resultDS, _index, _class_name, _class_teacher, _school_info)
        prepareReport()
    End Sub

    Private Sub previousBtn_Click(sender As Object, e As EventArgs) Handles previousBtn.Click
        _index -= 1
        If nextBtn.Enabled = False Then nextBtn.Enabled = True
        If _index = 0 Then previousBtn.Enabled = False
        myFunctions.prepareTempTable(resultDS, _index, _class_name, _class_teacher, _school_info)
        prepareReport()
    End Sub

    Public Sub prepareReport()
        Me.Validate()
        Me.printResultsSecBindingSource.EndEdit()
        Me.printResultsSecBindingSource.DataSource = myFunctions.getResultDataTable(_class_name)
        Me.printResultsSecTableAdapter.Update(Me.TerseDataSet.printResultsSec)
        Me.secReportViewer.RefreshReport()
    End Sub

End Class