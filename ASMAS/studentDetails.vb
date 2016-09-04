Imports System.Data
Imports System.Data.OleDb
Public Class studentDetails
    Dim Con As System.Data.OleDb.OleDbConnection
    Private pwd As String
    Private data_source_path As String = DBConnection.data_source_path

    Public class_id As String
    Private Sub studentDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByVal itemID As String)

        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

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

            Dim student_id = DS.Tables(0).Rows(0)(0).ToString
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

            titleLabel.Text = titleLabel.Text & " ( Reg Number = " & reg_number & ")"
            schoolName.Text = school_name.ToString
            admissionYear.Text = admission_year.ToString
            firstName.Text = f_name.ToString
            mName.Text = m_name.ToString
            lName.Text = l_name.ToString
            _gender.Text = gender.ToString
            __dob.Text = dob.ToString
            father.Text = father_name.ToString
            mother.Text = mother_name.ToString
            guardianName.Text = guardian_name.ToString
            tempAdd.Text = t_address.ToString
            permAdd.Text = p_address.ToString
            _phone.Text = phone.ToString
            _email.Text = email.ToString
            _info.Text = info.ToString
            If photoPath = "" Then photoPath = Application.StartupPath & "\StudentPhotos\photo_not_available.png"
            studentPhoto.Image = Image.FromFile(photoPath)

            'find current class
            Dim currentClassSQL As String = "SELECT
                                            c.class_id, short_name from class c
                                            inner join
                                            (select class_id
                                            from class_student
                                            where student_id = " & student_id & ") tb
                                            on c.class_id = tb.class_id
                                            where year_id = " & Year.currentYearID
            DS = New DataSet 'Declare a new instance, or we get Null Reference Error
            Con.Open() 'Open connection
            Dim classData As OleDbDataAdapter
            DS.Tables.Clear()
            classData = New OleDbDataAdapter(currentClassSQL, Con)
            Con.Close()
            classData.Fill(DS)
            class_id = DS.Tables(0).Rows(0)(0).ToString
            classLabel.Text = DS.Tables(0).Rows(0)(1).ToString

            If User.userRole = "Viewer" Then classLabel.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
            'searchResultListView.Items.Clear()

        Finally
            'This code gets called regardless of there being errors
            'This ensures that you close the Database and avoid corrupted data
            Con.Close()
        End Try
    End Sub

    Private Sub classLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles classLabel.LinkClicked
        myClassesForm.viewDetails(class_id)
    End Sub
End Class