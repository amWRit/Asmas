﻿Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class printResultsPrimaryForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"
    Public resultDS As DataSet
    Public _index As Integer
    Public _class_name As String

    Private Sub printResultsPrimaryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TerseDataSet.printResultsPrimary' table. You can move, or remove it, as needed.
        Me.primaryReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.primaryReportViewer.RefreshReport()
    End Sub

    Public Sub New(ByVal tempDS As DataSet, ByVal index As Integer, ByVal class_name As String)
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        resultDS = tempDS
        _index = index
        _class_name = class_name
        myFunctions.prepareTempTable(resultDS, _index, class_name)
        If resultDS.Tables(0).Rows.Count = 1 Then nextBtn.Enabled = False
        prepareReport()
    End Sub

    Private Sub nextBtn_Click(sender As Object, e As EventArgs) Handles nextBtn.Click
        _index += 1
        If previousBtn.Enabled = False Then previousBtn.Enabled = True
        If _index = resultDS.Tables(0).Rows.Count - 1 Then nextBtn.Enabled = False
        myFunctions.prepareTempTable(resultDS, _index, _class_name)
        prepareReport()
    End Sub

    Private Sub previousBtn_Click(sender As Object, e As EventArgs) Handles previousBtn.Click
        _index -= 1
        If nextBtn.Enabled = False Then nextBtn.Enabled = True
        If _index = 0 Then previousBtn.Enabled = False
        myFunctions.prepareTempTable(resultDS, _index, _class_name)
        prepareReport()
    End Sub

    Public Sub prepareReport()
        Me.Validate()
        Me.printResultsPrimaryBindingSource.EndEdit()
        Me.printResultsPrimaryBindingSource.DataSource = myFunctions.getResultDataTable(_class_name)
        Me.printResultsPrimaryTableAdapter.Update(Me.TerseDataSet.printResultsPrimary)
        Me.primaryReportViewer.RefreshReport()
    End Sub

End Class