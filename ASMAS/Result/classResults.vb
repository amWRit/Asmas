Imports System.Data
Imports System.Data.OleDb
Public Class classResults
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Public contents As String()
    Public tempDS As DataSet

    '{itemID, yearnum, schoolname, classname}
    Public Sub New(ByVal params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        contents = params
        Dim classID = params(0)
        refreshLV(classID, "")

    End Sub


    Private Sub viewBtn_Click(sender As Object, e As EventArgs) Handles viewBtn.Click
        printBtn.Enabled = False
        Dim terminal = termCombo.Text
        refreshLV(contents(0), terminal)
    End Sub

    Public Sub refreshLV(classID As String, terminal As String)
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim className = contents(3)
        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim classSQL As String = "Select distinct short_name from class where class_id=" & classID
        Dim oData As OleDbDataAdapter

        titleLabel.Text = "Class Results: " & className & " - " & terminal

        Try
            SQL = "SELECT * from results_" & className & " where school_name='" & contents(2) & "' and school_year ='" & contents(1) & "'"
            If terminal <> "" Then
                SQL = SQL & " and terminal = '" & terminal & "'"
            End If

            DS.Tables.Clear()
            Con.Open() 'Open connection

            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)
            tempDS = DS

            classResultListView.Items.Clear() 'prep Listview by clearing it
            classResultListView.Columns.Clear() 'remove columns in LV

            'create columns on listview
            For i As Integer = 0 To DS.Tables(0).Columns.Count - 1
                classResultListView.Columns.Add(DS.Tables(0).Columns(i).Caption, 100, HorizontalAlignment.Left)
            Next

            'Parse and add data to the listview
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
                Dim xItem As New ListViewItem(DS.Tables(0).Rows(i)(0).ToString)
                For j As Integer = 1 To DS.Tables(0).Columns.Count - 1
                    xItem.SubItems.Add(DS.Tables(0).Rows(i)(j).ToString)
                Next
                classResultListView.Items.Add(xItem)
            Next

            If DS.Tables(0).Rows.Count > 0 Then printBtn.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub updateRankBtn_Click(sender As Object, e As EventArgs) Handles updateRankBtn.Click
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        If termCombo.SelectedIndex = -1 Then
            MessageBox.Show("Please select a terminal to update rank.", "Incomplete input.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else

            Dim DS = New DataSet
            Dim SQL As String = ""
            Dim oData As OleDbDataAdapter

            Dim terminal = termCombo.Text
            Dim className = contents(3)
            Dim rankSQL As String = "SELECT id, student_id, percentage from results_" & className & " where school_name='" & contents(2) & "' and school_year ='" & contents(1) &
            "' and terminal = '" & terminal & "' order by percentage DESC"

            Try
                Con.Open()
                oData = New OleDbDataAdapter(rankSQL, Con)
                Con.Close()
                oData.Fill(DS)

                Dim rowCount = DS.Tables(0).Rows.Count
                Dim insertSQL = ""
                Dim rowID As Integer
                For i As Integer = 0 To rowCount - 1
                    rowID = CInt(DS.Tables(0).Rows(i)(0))
                    insertSQL = "UPDATE results_" & className & " set rank = @rank where id=" & rowID
                    Con.Open()
                    Dim cmd As New OleDbCommand(insertSQL, Con)

                    cmd.Parameters.AddWithValue("@rank", i + 1)

                    cmd.ExecuteNonQuery()
                    Con.Close()
                Next
                MsgBox("Rank updated successfully. Please make sure of it.", MsgBoxStyle.Information, "Updated")
                refreshLV(className, terminal)
            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                'This code gets called regardless of there being errors
                'This ensures that you close the Database and avoid corrupted data
                Con.Close()
            End Try
        End If
    End Sub

    Private Sub classResultListView_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles classResultListView.MouseUp
        If e.Button = MouseButtons.Right Then
            If classResultListView.GetItemAt(e.X, e.Y) IsNot Nothing Then
                classResultListView.GetItemAt(e.X, e.Y).Selected = True
                classResultsContextMenu.Show(classResultListView, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim ItemIndex As Integer = classResultListView.SelectedIndices(0) 'Grab the selected Index
        Dim studentID = classResultListView.Items(ItemIndex).SubItems(1).Text

        Dim primary As String() = {"1", "2", "3", "4", "5"}
        Dim lowSec As String() = {"6E", "6N", "7E", "7N", "8E", "8N"}
        Dim sec As String() = {"9E", "9N", "10E", "10A"}

        Dim className = contents(3)
        Dim year_num = classResultListView.Items(ItemIndex).SubItems(4).Text
        Dim school_name = classResultListView.Items(ItemIndex).SubItems(5).Text
        Dim terminal = classResultListView.Items(ItemIndex).SubItems(6).Text
        Dim edit = "TRUE"

        Dim params As String() = {studentID, year_num, school_name, className, terminal, edit}

        If primary.Contains(className) Then
            Dim _newClassResult As New addResultPrimaryForm(params)
            _newClassResult.Show()
        ElseIf lowSec.Contains(className) Then
            Dim _newClassResult As New addResultLowSecForm(params)
            _newClassResult.Show()
        ElseIf sec.Contains(className) Then
            Dim _newClassResult As New addResultSecForm(params)
            _newClassResult.Show()
        End If
    End Sub

    Private Sub printBtn_Click(sender As Object, e As EventArgs) Handles printBtn.Click
        letsPrint(0) 'index = 0; start from beginning
    End Sub

    Private Sub letsPrint(index As Integer)
        Dim primary As String() = {"1", "2", "3", "4", "5"}
        Dim lowSec As String() = {"6E", "6N", "7E", "7N", "8E", "8N"}
        Dim sec As String() = {"9E", "9N", "10E", "10A"}

        Dim class_name = contents(3)
        Dim year_num = contents(1)
        Dim school_name = contents(2)

        Dim class_teacher = myFunctions.getClassTeacherName(school_name, year_num, class_name)

        If primary.Contains(class_name) Then
            Dim printForm As New printResultsPrimaryForm(tempDS, index, class_name, class_teacher)
            printForm.Show()
        ElseIf lowSec.Contains(class_name) Then
            Dim printForm As New printResultLowSecForm(tempDS, index, class_name, class_teacher)
            printForm.Show()
        ElseIf sec.Contains(class_name) Then
            Dim printForm As New printResultSecForm(tempDS, index, class_name, class_teacher)
            printForm.Show()
        End If
    End Sub


    Private Sub updateCalcBtn_Click(sender As Object, e As EventArgs) Handles updateCalcBtn.Click
        If termCombo.SelectedIndex = -1 Then
            MessageBox.Show("Please select a terminal to update calcuations.", "Incomplete input.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim class_name = contents(3)
        Dim year_num = contents(1)
        Dim school_name = contents(2)
        resultFunctions.updateCalculations(tempDS, school_name, year_num, class_name)
        refreshLV(class_name, termCombo.Text)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        Dim ItemIndex As Integer = classResultListView.SelectedIndices(0) 'Grab the selected Index
        letsPrint(ItemIndex)
    End Sub
End Class