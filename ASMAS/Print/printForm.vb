Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class printForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"
    Public resultDS As DataSet
    Public _index As Integer

    Private Sub printForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Sub New(ByVal tempDS As DataSet, ByVal index As Integer)
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        resultDS = tempDS
        _index = index
        Dim _viewResultsForm = New viewResultsForm()
        _viewResultsForm.prepareTempTable(resultDS, _index)
        prepareReport()
    End Sub

    Private Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        _index += 1
        If previousBtn.Enabled = False Then previousBtn.Enabled = True
        If _index = resultDS.Tables(0).Rows.Count - 1 Then nextBtn.Enabled = False
        Dim _viewResultsForm = New viewResultsForm()
        _viewResultsForm.prepareTempTable(resultDS, _index)
        prepareReport()
    End Sub

    Private Sub previousBtn_Click(sender As Object, e As EventArgs) Handles previousBtn.Click
        _index -= 1
        If nextBtn.Enabled = False Then nextBtn.Enabled = True
        If _index = 0 Then previousBtn.Enabled = False
        Dim _viewResultsForm = New viewResultsForm()
        _viewResultsForm.prepareTempTable(resultDS, _index)
        prepareReport()
    End Sub

    Public Function getResultDataTable() As DataTable
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        'first clear the tempTable
        Dim SQL = "SELECT * from printResultsLowSec"
        Dim DT As New DataTable
        Con.Open() 'Open connection
        Dim Data As OleDbDataAdapter
        Data = New OleDbDataAdapter(SQL, Con)
        Con.Close()
        Data.Fill(DT)
        Return DT
    End Function

    Public Sub prepareReport()
        Me.Validate()
        Me.printResultsLowSecBindingSource.EndEdit()
        Me.printResultsLowSecBindingSource.DataSource = getResultDataTable()
        Me.printResultsLowSecTableAdapter.Update(Me.TerseDataSet.printResultsLowSec)
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class