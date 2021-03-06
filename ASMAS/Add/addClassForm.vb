﻿Imports System.Data
Imports System.Data.OleDb

Public Class addClassForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path
    Public contents As String() = {}
    Public edit As String = ""

    Public Sub New(ByVal params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        contents = params
        Dim itemID = params(0)
        Dim edit = params(1)
        ' Add any initialization after the InitializeComponent() call.
        If itemID IsNot "" Then
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"
            Dim class_id = itemID
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


                schoolNameCombo.Text = school_name.ToString
                yearNameCombo.Text = year_num.ToString
                shortnameTextBox.Text = short_name.ToString
                fullnameTextBox.Text = full_name.ToString
                sizeTextBox.Text = size.ToString
                ctCombo.Text = class_teacher.ToString
            Catch ex As Exception
                MsgBox(ex.Message)
                'searchResultListView.Items.Clear()

            Finally
                'This code gets called regardless of there being errors
                'This ensures that you close the Database and avoid corrupted data
                Con.Close()
            End Try
        End If

    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
        If edit <> "FALSE" Then HomeForm.Show()
    End Sub

    Private Sub addClassForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            If edit <> "FALSE" Then HomeForm.Show()
        End If
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click

        If schoolNameCombo.SelectedIndex = -1 Or yearNameCombo.SelectedIndex = -1 Or shortnameTextBox.Text = "" Or fullnameTextBox.Text = "" Or sizeTextBox.Text = "" Or ctCombo.SelectedIndex = -1 Then
            MessageBox.Show("One of the fields is empty.Please check!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim valid_class_name = checkIfClassNameValid(shortnameTextBox.Text)
        If valid_class_name = False Then
            MessageBox.Show("Unacceptable short name format. The acceptable formats are  1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 
1A , 2A , 3A , 4A , 5A , 6A , 7A , 8A , 9A , 10A , 1B , 2B , 3B , 4B , 5B , 6B , 7B , 8B , 9B , 10B , 1E , 2E , 3E , 4E , 5E , 6E , 
7E , 8E , 9E , 10E , 1N , 2N , 3N , 4N , 5N , 6N , 7N , 8N , 9N , 10N", "Unacceptable format", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim present As Boolean
        Dim school_name = schoolNameCombo.Text
        Dim year_num = yearNameCombo.Text
        Dim edit = contents(1)

        If edit = "FALSE" Then
            present = checkIfPresent(shortnameTextBox.Text, school_name, year_num)
        End If

        If present = True Then
            MessageBox.Show("A class with same short_name is already present. Please check.", "Duplicate record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim strSQL As String = "SELECT top 1 * from class"

        Dim SQL As String = ""
        If schoolNameCombo.SelectedIndex = -1 Then
            school_name = "TerseHSS"
        End If

        If yearNameCombo.SelectedIndex = -1 Then
            year_num = "2073"
        End If

        Dim yearSQL As String = "SELECT s.school_id, sy.year_id from 
                                school s
                                INNER JOIN
                                school_year sy
                                on s.school_id = sy.school_id
                                where s.short_name = '" & school_name & "' and sy.year_num = '" & year_num & "'"

        Con.Open() 'Open connection
        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(yearSQL, Con)
        Con.Close()
        oData.Fill(DS)

        Dim school_id As Integer = CInt(DS.Tables(0).Rows(0)(0))
        Dim year_id As Integer = CInt(DS.Tables(0).Rows(0)(1))

        DS.Tables.Clear()
        Con.Open() 'Open connection
        oData = New OleDbDataAdapter(strSQL, Con)
        Con.Close()
        oData.Fill(DS)

        Dim classItems = "(" & school_id & "," & year_id & "," & shortnameTextBox.Text & "," & fullnameTextBox.Text & "," & sizeTextBox.Text & "," & ctCombo.Text & ")"


        Try
            Dim insertSQL As String = "INSERT INTO class ([school_id], [year_id], [short_name], [full_name], [size], [class_teacher]) 
                                        VALUES (@school_id, @year_id, @short_name, @full_name, @size, @class_teacher)"

            If edit = "TRUE" Then
                insertSQL = "UPDATE class SET [school_id] = @school_id, [year_id] = @year_id, [short_name] = @short_name, [full_name] = @full_name, [size] = @size, [class_teacher] = @class_teacher  where class_id=" & contents(0)
            End If
            Con.Open()
            Dim cmd As New OleDbCommand(insertSQL, Con)
            cmd.Parameters.AddWithValue("@school_id", school_id)
            cmd.Parameters.AddWithValue("@year_id", year_id)
            cmd.Parameters.AddWithValue("@short_name", shortnameTextBox.Text)
            cmd.Parameters.AddWithValue("@full_name", fullnameTextBox.Text)
            cmd.Parameters.AddWithValue("@size", sizeTextBox.Text)
            cmd.Parameters.AddWithValue("@class_teacher", ctCombo.Text)
            cmd.ExecuteNonQuery()

            MsgBox("Successful", MsgBoxStyle.Information, "INSERTED")
            If edit = "TRUE" Then
                Me.Close()
            Else
                Dim textboxes = myFunctions.getTextBoxes(Me)
                myFunctions.clearTextBoxes(textboxes)
            End If
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
            'AddTable()
        End Try

    End Sub
    Public Function checkIfClassNameValid(short_name As String) As Boolean
        Dim valid As Boolean = False
        If TheClass.AcceptableClassShortNames.Contains(short_name) Then
            Return True
        End If
        Return valid
    End Function

    Public Function checkIfPresent(className As String, school_name As String, year_num As String) As Boolean
        Dim present As Boolean = False

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS = New DataSet
        Dim SQL As String = ""
        Dim school_id As String
        Dim year_id As String

        Try
            'find school_id
            SQL = "SELECT school_id from school where short_name='" & school_name & "'"
            Con.Open() 'Open connection
            Dim oData As OleDbDataAdapter
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            oData.Fill(DS)
            school_id = DS.Tables(0).Rows(0)(0).ToString

            'find year_id
            SQL = "SELECT year_id from school_year where year_num='" & year_num & "'"
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            DS.Tables.Clear()
            oData.Fill(DS)
            year_id = DS.Tables(0).Rows(0)(0).ToString

            SQL = "SELECT * from class where school_id=" & school_id & " and year_id=" & year_id & " and short_name='" & className & "'"
            Con.Open() 'Open connection
            oData = New OleDbDataAdapter(SQL, Con)
            Con.Close()
            DS.Tables.Clear()
            oData.Fill(DS)

            Dim rowCount = DS.Tables(0).Rows.Count
            If rowCount > 0 Then present = True
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try

        Return present
    End Function

    Private Sub addClassForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentUserLabel.Text = currentUserLabel.Text & User.userName

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim schoolSQL As String = "SELECT short_name from SCHOOL"
        Dim yearSQL As String = "SELECT distinct year_num from school_year"
        Dim ctSQL As String = "SELECT [full_name] from [user] WHERE role='Teacher' ORDER BY full_name"

        'SCHOOL COMBOBOX
        Con.Open() 'Open connection
        Dim schoolData As OleDbDataAdapter
        schoolData = New OleDbDataAdapter(schoolSQL, Con)
        Con.Close()
        schoolData.Fill(DS)
        Dim rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            schoolNameCombo.Items.Add(Val)
        Next

        DS.Tables.Clear()
        'YEAR COMBOBOX
        Con.Open() 'Open connection
        Dim yearData As OleDbDataAdapter
        yearData = New OleDbDataAdapter(yearSQL, Con)
        Con.Close()
        yearData.Fill(DS)
        rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            yearNameCombo.Items.Add(Val)
        Next

        DS.Tables.Clear()
        'classteacher COMBOBOX
        Con.Open() 'Open connection
        Dim ctData As OleDbDataAdapter
        ctData = New OleDbDataAdapter(ctSQL, Con)
        Con.Close()
        ctData.Fill(DS)
        rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            ctCombo.Items.Add(Val)
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As MouseEventArgs) Handles LinkLabel1.MouseClick
        ClassShortNames.Show()
        classNamesToolTip.SetToolTip(shortnameTextBox, "Please see acceptable formats.")
    End Sub
End Class