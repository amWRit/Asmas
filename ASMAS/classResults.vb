Imports System.Data
Imports System.Data.OleDb
Public Class classResults
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"

    Public classID As String

    Public Sub New(ByVal itemID As String)
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        classID = itemID
        refreshLV(classID, "")

    End Sub

    Private Sub classResults_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub viewBtn_Click(sender As Object, e As EventArgs) Handles viewBtn.Click
        'dim openforms = application.openforms.oftype(of classresults)
        'while openforms.any()
        '    openforms.first.close()
        'end while

        'dim _classresults as new classresults(classid)
        '_classresults.show()
        Dim terminal = termCombo.Text
        refreshLV(classID, terminal)
    End Sub

    Public Sub refreshLV(classID As String, terminal As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim classSQL As String = "Select distinct short_name from class where class_id=" & classID
        Dim oData As OleDbDataAdapter
        Con.Open()
        oData = New OleDbDataAdapter(classSQL, Con)
        Con.Close()
        oData.Fill(DS)
        Dim className As String = DS.Tables(0).Rows(0)(0).ToString

        titleLabel.Text = "Class Results: " & className & " - " & terminal

        Try
            SQL = "SELECT * from 
                    results_" & className & ""
            If terminal <> "" Then
                SQL = "SELECT * from 
                    results_" & className & " where terminal = '" & terminal & "'"
            End If

            DS.Tables.Clear()
            Con.Open() 'Open connection

            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)

            classResultListView.Items.Clear() 'prep Listview by clearing it
            classResultListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                classResultListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 247, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                classResultListView.Items.Add(xItem)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub
End Class