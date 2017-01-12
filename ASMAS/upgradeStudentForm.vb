Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports Microsoft.ReportingServices.Rendering.ExcelRenderer

Public Class upgradeStudentForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path
    Public student_ids As String()
    Public prev_class_id As String
    Public school_id As String

    Private Sub upgradeStudentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim yearSQL As String = "SELECT distinct year_num from school_year"

        Try
            Con.Open() 'Open connection
            DS.Tables.Clear()
            'YEAR COMBOBOX
            Dim yearData As OleDbDataAdapter
            yearData = New OleDbDataAdapter(yearSQL, Con)
            Con.Close()
            yearData.Fill(DS)
            Dim rowCount = DS.Tables(0).Rows.Count

            For i As Integer = 0 To rowCount - 1
                Dim Val = DS.Tables(0).Rows(i)(0).ToString
                yearName.Items.Add(Val)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try

    End Sub

    Public Sub New(ids As String(), class_id As String)
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        student_ids = ids
        prev_class_id = class_id
    End Sub

    Private Sub yearName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles yearName.SelectedIndexChanged
        loadClasses()
    End Sub

    Public Sub loadClasses()
        yearLabel.Text = yearName.Text
        classCombo.Items.Clear()
        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim classSQL As String = "SELECT distinct short_name, school_id from CLASS where year_id = (SELECT year_id from school_year where year_num='" & yearName.Text & "' and school_id=(SELECT school_id from class where class_id=" & prev_class_id & "))"

        Try
            Con.Open() 'Open connection
            Dim classData As OleDbDataAdapter
            classData = New OleDbDataAdapter(classSQL, Con)
            Con.Close()
            classData.Fill(DS)
            Dim rowCount = DS.Tables(0).Rows.Count

            If rowCount = 0 Then
                MessageBox.Show("No class has been added yet for this year. Please contact your admin.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                Exit Sub
            End If
            school_id = DS.Tables(0).Rows(0)(1).ToString

            For i As Integer = 0 To rowCount - 1
                Dim Val = DS.Tables(0).Rows(i)(0).ToString
                classCombo.Items.Add(Val)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try

    End Sub

    Private Sub upgradeBtn_Click(sender As Object, e As EventArgs) Handles upgradeBtn.Click
        If classCombo.SelectedIndex = -1 Then
            MessageBox.Show("Please select a class.", "No data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim old_class_name = TheClass.getClassName(CInt(prev_class_id))
        Dim class_name = classCombo.Text

        Dim old_class_int = Int32.Parse(Regex.Replace(old_class_name, "\D", ""))
        Dim new_class_int = Int32.Parse(Regex.Replace(class_name, "\D", ""))

        If new_class_int < old_class_int Then
            Dim I As Integer = MessageBox.Show("The class you are trying to promote to seems to be smaller than the exisiting class. Are you sure?", "CHECK", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If I = MsgBoxResult.No Then
                Me.Close()
                Exit Sub
            End If
        End If
        Dim next_year = Year.nextYear.ToString

        Dim year_id = Year.getYearID(school_id, next_year)
        Dim new_class_id = myFunctions.getClassIdOf(school_id, year_id, class_name)

        myFunctions.upgradeClass(student_ids, new_class_id, year_id)
    End Sub
End Class