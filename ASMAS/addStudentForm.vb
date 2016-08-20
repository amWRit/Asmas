Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Public Class addStudentForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\Terse.accdb"
    Public contents As String() = {}

    Private Sub addStudentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"


        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error
        Dim schoolSQL As String = "SELECT short_name from SCHOOL"

        'SCHOOL COMBOBOX
        Con.Open() 'Open connection
        Dim schoolData As OleDbDataAdapter
        schoolData = New OleDbDataAdapter(schoolSQL, Con)
        Con.Close()
        schoolData.Fill(DS)
        Dim rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            schoolCombo.Items.Add(Val)
        Next
    End Sub

    Public Sub New(ByVal params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        contents = params
        Dim itemID = params(0)

        If itemID IsNot "" Then
            ' Add any initialization after the InitializeComponent() call.
            Con = New OleDbConnection
            Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

            Try
                Dim SQL As String = "SELECT * from student where reg_number='" & itemID & "'"
                Dim DS As DataSet 'Object to store data in
                DS = New DataSet 'Declare a new instance, or we get Null Reference Error
                Con.Open() 'Open connection
                Dim oData As OleDbDataAdapter
                oData = New OleDbDataAdapter(SQL, Con)
                Con.Close()
                oData.Fill(DS)

                Dim reg_number = DS.Tables(0).Rows(0)(1).ToString
                Dim school_id As Integer = CInt(DS.Tables(0).Rows(0)(2))
                Dim f_name = DS.Tables(0).Rows(0)(3)
                Dim m_name = DS.Tables(0).Rows(0)(4)
                Dim l_name = DS.Tables(0).Rows(0)(5)
                Dim gender = DS.Tables(0).Rows(0)(6)
                Dim admission_year = DS.Tables(0).Rows(0)(7)
                Dim father_name = DS.Tables(0).Rows(0)(8)
                Dim mother_name = DS.Tables(0).Rows(0)(9)
                Dim guardian_name = DS.Tables(0).Rows(0)(10)
                Dim dob = DS.Tables(0).Rows(0)(11)
                Dim p_address = DS.Tables(0).Rows(0)(12)
                Dim t_address = DS.Tables(0).Rows(0)(13)
                Dim phone = DS.Tables(0).Rows(0)(14)
                Dim email = DS.Tables(0).Rows(0)(15)
                Dim photoPath As String = DS.Tables(0).Rows(0)(16).ToString
                Dim info = DS.Tables(0).Rows(0)(17)


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

                'Populate details onto form

                schoolCombo.Text = school_name.ToString
                yearTextBox.Text = admission_year.ToString
                fnameTextBox.Text = f_name.ToString
                mnameTextBox.Text = m_name.ToString
                lnameTextBox.Text = l_name.ToString
                genderCombo.Text = gender.ToString
                dobTextBox.Text = dob.ToString
                fatherTextBox.Text = father_name.ToString
                motherTextBox.Text = mother_name.ToString
                guardianTextBox.Text = guardian_name.ToString
                tAddTextBox.Text = t_address.ToString
                pAddTextBox.Text = p_address.ToString
                phoneTextBox.Text = phone.ToString
                emailTextBox.Text = email.ToString
                infoTextBox.Text = info.ToString
                If photoPath = "" Then photoPath = "C:\Users\amWRit\Documents\Visual Studio 2015\Projects\ASMAS\ASMAS\bin\photo_not_available.png"
                studentPhoto.Image = Image.FromFile(photoPath)



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

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        'Dim present As Boolean
        Dim f_name = fnameTextBox.Text
        Dim m_name = mnameTextBox.Text
        Dim l_name = lnameTextBox.Text
        Dim regNumber = ""

        'present = checkIfPresent(f_name, m_name, l_name)

        'If present = True Then
        '    MessageBox.Show("A student with same same name is already present. Please check. (Hint: Use A, B as suffix))", "Duplicate record!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If

        Dim schoolName = schoolCombo.Text
        Dim schoolSQL As String = "SELECT distinct school_id from SCHOOL where short_name='" & schoolName & "'"

        Con.Open() 'Open connection
        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(schoolSQL, Con)
        Con.Close()
        oData.Fill(DS)

        Dim school_id As Integer = CInt(DS.Tables(0).Rows(0)(0))

        Dim edit = contents(1)
        If edit = "FALSE" Then
            regNumber = buildNewRegNumber()
        Else
            regNumber = contents(0)
        End If

        Try
            Dim insertSQL As String = "INSERT INTO student ([reg_number], [school_id], [f_name], [m_name], [l_name], [gender], [admission_year], [father_name], [mother_name], [guardian_name], [dob], [p_address], [temp_address], [phone], [email], [photo], [info]) 
                                        VALUES
                                        (@reg_number, @school_id, @f_name, @m_name, @l_name, @gender, @admission_year, @father_name, @mother_name, @guardian_name, @dob, @p_address, @temp_address, @phone, @email, @photo, @info)"

            If edit = "TRUE" Then
                insertSQL = "UPDATE student SET [school_id] = @school_id, [f_name] = @f_name, [m_name] = @m_name, [l_name] = @l_name, [gender] = @gender, [admission_year] = @admission_year, [father_name] = @father_name, 
                            [mother_name] = @mother_name, [guardian_name] = @guardian_name, [dob] = @dob, [p_address] = @p_address, [temp_address] = @temp_address, [phone] = @phone, [email] = @email, [photo] = @photo, [info] = @info where reg_number='" & regNumber & "'"
            End If
            Con.Open()
            Dim cmd As New OleDbCommand(insertSQL, Con)
            If edit = "FALSE" Then cmd.Parameters.AddWithValue("@reg_number", regNumber)
            cmd.Parameters.AddWithValue("@school_id", school_id)
            cmd.Parameters.AddWithValue("@f_name", fnameTextBox.Text)
            cmd.Parameters.AddWithValue("@m_name", mnameTextBox.Text)
            cmd.Parameters.AddWithValue("@l_name", lnameTextBox.Text)
            cmd.Parameters.AddWithValue("@gender", genderCombo.Text)
            cmd.Parameters.AddWithValue("@admission_year", yearTextBox.Text)
            cmd.Parameters.AddWithValue("@father_name", fatherTextBox.Text)
            cmd.Parameters.AddWithValue("@mother_name", motherTextBox.Text)
            cmd.Parameters.AddWithValue("@guardian_name", guardianTextBox.Text)
            cmd.Parameters.AddWithValue("@dob", dobTextBox.Text)
            cmd.Parameters.AddWithValue("@p_address", pAddTextBox.Text)
            cmd.Parameters.AddWithValue("@temp_address", tAddTextBox.Text)
            cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text)
            cmd.Parameters.AddWithValue("@email", emailTextBox.Text)
            cmd.Parameters.AddWithValue("@photo", filepathTextBox.Text)
            cmd.Parameters.AddWithValue("@info", infoTextBox.Text)

            cmd.ExecuteNonQuery()

            MsgBox("Insert Successful", MsgBoxStyle.Information, "INSERTED")
            If edit = "TRUE" Then Me.Close()
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Con.Close()
            'AddTable()
        End Try

    End Sub

    Public Function buildNewRegNumber() As String
        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        Dim regNumberSQL As String = "SELECT last(reg_number) from student"

        Con.Open() 'Open connection
        DS.Tables.Clear()
        Dim regData As OleDbDataAdapter
        regData = New OleDbDataAdapter(regNumberSQL, Con)
        Con.Close()
        regData.Fill(DS)

        Dim regString As String = DS.Tables(0).Rows(0)(0).ToString
        Dim separators() As String = {"THSS"}
        Dim result() As String
        result = regString.Split(separators, StringSplitOptions.RemoveEmptyEntries)
        'Dim reg_number As Integer = Convert.ToInt32(result)
        Dim reg_number As Integer
        Integer.TryParse(result(0), reg_number)
        reg_number += 1
        regString = "THSS" & reg_number
        Return regString
    End Function

    'Public Function checkIfPresent(f_name As String, m_name As String, l_name As String) As Boolean
    '    Dim present As Boolean = False

    '    Con = New OleDbConnection
    '    Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

    '    Dim DS = New DataSet
    '    Dim SQL As String = ""

    '    Try
    '        Dim oData As OleDbDataAdapter

    '        SQL = "SELECT * from student where f_name=" & f_name & " and m_name=" & m_name & " and l_name='" & l_name & "'"
    '        Con.Open() 'Open connection
    '        oData = New OleDbDataAdapter(SQL, Con)
    '        Con.Close()
    '        DS.Tables.Clear()
    '        oData.Fill(DS)

    '        Dim rowCount = DS.Tables(0).Rows.Count
    '        If rowCount > 0 Then present = True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)

    '    Finally
    '        'This code gets called regardless of there being errors
    '        'This ensures that you close the Database and avoid corrupted data
    '        Con.Close()
    '    End Try

    '    Return present
    'End Function

    Dim bytImage() As Byte
    Private Sub browsePhotoBtn_Click(sender As Object, e As EventArgs) Handles browsePhotoBtn.Click
        Dim myStream As Stream = Nothing
        Dim dialog As New OpenFileDialog()
        dialog.Title = "Browse Picture"
        dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
        'dialog.InitialDirectory = "c:\"
        dialog.FilterIndex = 2
        dialog.RestoreDirectory = True
        dialog.FileName = ""

        If dialog.ShowDialog() = DialogResult.OK Then
            Try
                myStream = dialog.OpenFile()
                If (myStream IsNot Nothing) Then
                    studentPhoto.Image = Image.FromFile(dialog.FileName)
                    filepathTextBox.Text = dialog.FileName
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If


    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
        HomeForm.Show()
    End Sub

    Private Sub addStudentForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            HomeForm.Show()
        End If
    End Sub
End Class