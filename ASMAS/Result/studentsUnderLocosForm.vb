Imports System.Data.OleDb

Public Class studentsUnderLocosForm
    Private Shared data_source_path As String = DBConnection.data_source_path
    Public Shared Con As System.Data.OleDb.OleDbConnection

    Public Shared contents As String() = {}
    Public Shared lowPrimary As String() = {"1", "2", "3"}
    Public Shared highPrimary As String() = {"4", "5"}
    Public Shared primary As String() = {"1", "2", "3", "4", "5"}
    Public Shared lowSec As String() = {"6E", "6N", "7E", "7N", "8E", "8N"}
    Public Shared sec As String() = {"9E", "9N", "10E", "10A"}
    Public Shared params As String()

    'contents = {class_id, class_name, school_name, school_year, terminal, subject, locos}
    Public Sub New(contents As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        params = contents
    End Sub

    Private Sub studentsUnderLocosForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
        End If
    End Sub

    Private Sub studentsUnderLocosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim class_id = params(0)
        Dim class_name = params(1)
        Dim school_name = params(2)
        Dim school_year = params(3)
        Dim terminal = params(4)
        Dim subject = params(5)
        Dim locos = params(6)

        titleLabel.Text = titleLabel.Text & " " & class_name
        locosLabel.Text = locosLabel.Text & " " & locos
        subjectLabel.Text = subject

        Dim subjKey = resultFunctions.getSubjKey(subject, class_name)
        'get results
        Dim resultDS = getResultOf(subjKey)
        'load to list view
        loadLV(resultDS)
    End Sub

    Public Shared Function getResultOf(subjKey As String) As DataSet
        Dim class_id = params(0)
        Dim class_name = params(1)
        Dim school_name = params(2)
        Dim school_year = params(3)
        Dim terminal = params(4)
        Dim subject = params(5)
        Dim locos = params(6)

        Dim resultDS As New DataSet
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim SQL As String = ""
        Dim oData As OleDbDataAdapter

        Try
            SQL = "SELECT full_name, " & subjKey & "_total from results_" & class_name & " WHERE school_name='" & school_name & "' and school_year ='" & school_year & "' and terminal = '" & terminal & "' and " & subjKey & "_total < " & locos
            If sec.Contains(class_name) And subjKey = "opt1" Then
                SQL = SQL & " AND opt1='" & subject & "'"
            ElseIf sec.Contains(class_name) And subjKey = "opt2" Then
                SQL = SQL & " AND opt2='" & subject & "'"
            End If
            SQL = SQL & " ORDER BY " & subjKey & "_total DESC"
            resultDS.Tables.Clear()
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(resultDS)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        Return resultDS
    End Function

    Public Sub loadLV(resultDS As DataSet)
        studentsListView.Items.Clear() 'prep Listview by clearing it
        studentsListView.Columns.Clear() 'remove columns in LV

        'create columns on listview
        For i As Integer = 0 To resultDS.Tables(0).Columns.Count - 1
            studentsListView.Columns.Add(resultDS.Tables(0).Columns(i).Caption, 200, HorizontalAlignment.Left)
        Next
        Dim rowCount = resultDS.Tables(0).Rows.Count
        'Parse and add data to the listview
        For i As Integer = 0 To rowCount - 1
            Dim xItem As New ListViewItem(resultDS.Tables(0).Rows(i)(0).ToString)
            For j As Integer = 1 To resultDS.Tables(0).Columns.Count - 1
                xItem.SubItems.Add(resultDS.Tables(0).Rows(i)(j).ToString)
            Next
            studentsListView.Items.Add(xItem)
        Next
    End Sub
End Class