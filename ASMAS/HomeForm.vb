Public Class HomeForm

    'Private id As String
    'Private _name As String
    'Private me_user As DataSet
    'Public Property userID() As String
    '    Get
    '        Return id
    '    End Get
    '    Set(ByVal value As String)
    '        id = value
    '    End Set
    'End Property

    'Public Property User() As DataSet
    '    Get
    '        Return me_user
    '    End Get
    '    Set(ByVal value As DataSet)
    '        me_user = value
    '    End Set
    'End Property

    'Public Property userName() As String
    '    Get
    '        Return _name
    '    End Get
    '    Set(value As String)
    '        _name = value
    '    End Set
    'End Property


    Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currentUser As DataSet
        currentUser = User.user
        currentUserLabel.Text = currentUserLabel.Text & User.userName

        If User.userRole = "Viewer" Or User.userRole = "Teacher" Then
            addSchoolBtn.Enabled = False
            addYearBtn.Enabled = False
            addClassBtn.Enabled = False
            addStudentBtn.Enabled = False
            addUserBtn.Enabled = False
        End If

        If User.userRole = "Teacher" Then viewMyClassesBtn.Show()
        If User.userRole = "Viewer" Then viewResultBtn.Enabled = False
    End Sub

    Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        Me.Hide()
        SearchForm.Show()
    End Sub

    Private Sub viewDBBtn_Click(sender As Object, e As EventArgs) Handles viewDBBtn.Click
        Me.Hide()
        viewDatabaseForm.Show()
    End Sub

    Private Sub addSchoolBtn_Click(sender As Object, e As EventArgs) Handles addSchoolBtn.Click
        Me.Hide()
        addSchoolForm.Show()
    End Sub

    Private Sub addYearBtn_Click(sender As Object, e As EventArgs) Handles addYearBtn.Click
        Me.Hide()
        addYearForm.Show()
    End Sub

    Private Sub addStudentBtn_Click(sender As Object, e As EventArgs) Handles addStudentBtn.Click
        Me.Hide()
        Dim _addStudentForm As New addStudentForm({"", "FALSE"})
        _addStudentForm.Show()
    End Sub

    Private Sub addUserBtn_Click(sender As Object, e As EventArgs) Handles addUserBtn.Click
        Me.Hide()
        addUserForm.Show()
    End Sub

    Private Sub addClassBtn_Click(sender As Object, e As EventArgs) Handles addClassBtn.Click
        Me.Hide()
        Dim _addClassForm As New addClassForm({"", "FALSE"})
        _addClassForm.Show()
    End Sub

    Private Sub viewMyClassesBtn_Click(sender As Object, e As EventArgs) Handles viewMyClassesBtn.Click
        Me.Hide()
        myClassesForm.Show()
    End Sub

    Private Sub HomeForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            Application.Exit()
        End If
    End Sub

    Private Sub viewResultBtn_Click(sender As Object, e As EventArgs) Handles viewResultBtn.Click
        Me.Hide()
        viewResultsForm.Show()
    End Sub

    Private Sub printResultsBtn_Click(sender As Object, e As EventArgs) Handles printResultsBtn.Click
        ReportCard.Show()
    End Sub
End Class