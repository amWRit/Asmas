Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Public Class addStudentForm
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path
    Public contents As String() = {}
    Public regNumber As String = ""

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

        DS.Tables.Clear()
        'CLASS COMBOBOX
        Dim classSQL As String = "SELECT distinct short_name from CLASS ORDER BY short_name"
        Con.Open() 'Open connection
        Dim classData As OleDbDataAdapter
        classData = New OleDbDataAdapter(classSQL, Con)
        Con.Close()
        classData.Fill(DS)
        rowCount = DS.Tables(0).Rows.Count

        For i As Integer = 0 To rowCount - 1
            Dim Val = DS.Tables(0).Rows(i)(0).ToString
            classCombo.Items.Add(Val)
        Next
    End Sub

    Public Sub New(ByVal params As String())
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()
        contents = params
        Dim itemID = params(0)

        If itemID IsNot "" Then 'edit is true
            classCombo.Enabled = False
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
                Dim photoPresent As String = DS.Tables(0).Rows(0)(17).ToString
                Dim info = DS.Tables(0).Rows(0)(16)


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

                Dim strBasePath = Application.StartupPath & "\StudentPhotos\"
                Dim imageName = f_name.ToString & m_name.ToString & l_name.ToString & reg_number & ".jpg"
                Dim imagePath = strBasePath & imageName
                If photoPresent = "" Or Not System.IO.File.Exists(imagePath) Then
                    imagePath = Application.StartupPath & "\StudentPhotos\photo_not_available.png"
                End If

                Try
                    studentPhoto.Image = Image.FromFile(imagePath)
                Catch ex As Exception
                    MsgBox("Couldn't find file" & ex.Message)
                Finally
                End Try

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
        Dim edit = contents(1)
        If edit = "FALSE" And schoolCombo.SelectedIndex = -1 Then
            MessageBox.Show("Please select a school.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Con = New OleDbConnection
        Con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & data_source_path & " ;Jet OLEDB:Database Password= & mypassword"

        Dim DS As DataSet 'Object to store data in
        DS = New DataSet 'Declare a new instance, or we get Null Reference Error

        'Dim present As Boolean
        Dim f_name = fnameTextBox.Text
        Dim m_name = mnameTextBox.Text
        Dim l_name = lnameTextBox.Text
        'Dim regNumber = ""
        Dim photoPresent As String = ""
        If filepathTextBox.Text <> "" Then photoPresent = "present"

        Dim schoolName = schoolCombo.Text
        Dim schoolSQL As String = "SELECT distinct school_id from SCHOOL where short_name='" & schoolName & "'"

        Con.Open() 'Open connection
        Dim oData As OleDbDataAdapter
        oData = New OleDbDataAdapter(schoolSQL, Con)
        Con.Close()
        oData.Fill(DS)

        Dim school_id As Integer = CInt(DS.Tables(0).Rows(0)(0))

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
            cmd.Parameters.AddWithValue("@photo", photoPresent)
            cmd.Parameters.AddWithValue("@info", infoTextBox.Text)

            cmd.ExecuteNonQuery()

            MsgBox("Insert Successful", MsgBoxStyle.Information, "INSERTED")
            If classCombo.SelectedIndex <> -1 Then
                'check if student is created
                Dim student_id = myFunctions.getStudentIdOf(regNumber)
                If student_id <> "" Then
                    'find class_id
                    Dim class_id = myFunctions.getClassIdOf(school_id.ToString, Year.currentYearID(school_id), classCombo.Text)
                    addStudentToClassForm.addStudentToClass(class_id, student_id)
                End If

            End If

            If edit = "TRUE" Then
                Me.Close()
            Else
                Dim textboxes = myFunctions.getTextBoxes(Me)
                myFunctions.clearTextBoxes(textboxes)
                tAddTextBox.Text = ""
                pAddTextBox.Text = ""
                classCombo.Text = ""
            End If
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

        Dim regNumberSQL As String = "SELECT TOP 1 reg_number from student ORDER BY ID DESC"

        Con.Open() 'Open connection
        DS.Tables.Clear()
        Dim regData As OleDbDataAdapter
        regData = New OleDbDataAdapter(regNumberSQL, Con)
        Con.Close()
        regData.Fill(DS)

        Dim reg_number As Integer
        Dim regString = ""
        If DS.Tables(0).Rows.Count = 0 Then 'no students added yet
            reg_number = 1
        Else
            regString = DS.Tables(0).Rows(0)(0).ToString
            Dim separators() As String = {"THSS"}
            Dim result() As String
            result = regString.Split(separators, StringSplitOptions.RemoveEmptyEntries)

            Integer.TryParse(result(0), reg_number)
            reg_number += 1
        End If

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
        If fnameTextBox.Text = "" And lnameTextBox.Text = "" Then
            MessageBox.Show("Please enter the name first.", "Incomplete input", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim edit = contents(1)
        If edit = "FALSE" Then
            regNumber = buildNewRegNumber()
        Else
            regNumber = contents(0)
        End If

        If studentPhoto.Image IsNot Nothing Then
            studentPhoto.Image.Dispose()
        End If
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
                    Dim strBasePath = Application.StartupPath & "\StudentPhotos\"
                    Dim imageName = fnameTextBox.Text & mnameTextBox.Text & lnameTextBox.Text & regNumber & ".jpg"
                    Dim imagePath = strBasePath & imageName

                    If System.IO.File.Exists(imagePath) Then
                        Dim I As Integer = MessageBox.Show("Photo already exists for the student. Are you sure you want to replace the file?", "File exists.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        If I = MsgBoxResult.Ok Then
                            System.IO.File.Delete(imagePath)
                        End If
                    End If

                    studentPhoto.Image = FileHandler.RotateImage(Image.FromFile(dialog.FileName))
                    studentPhoto.Image = FileHandler.ResizeImage(studentPhoto.Image, 198, 188)
                    'save resized image to folder
                    'create folder if doesn't exist
                    If (Not System.IO.Directory.Exists(strBasePath)) Then
                        System.IO.Directory.CreateDirectory(strBasePath)
                    End If
                    studentPhoto.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg)
                    filepathTextBox.Text = imagePath
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
                'studentPhoto.Image.Dispose()
            End Try
        End If
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Hide()
        If User.userRole = "Teacher" Then
            myClassesForm.Show()
        ElseIf User.userRole = "Admin" Then
            HomeForm.Show()
        End If
    End Sub

    Private Sub addStudentForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            If User.userRole = "Teacher" Then
                myClassesForm.Show()
            ElseIf User.userRole = "Admin" Then
                HomeForm.Show()
            End If
        End If
    End Sub
End Class