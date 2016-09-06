<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.currentUserLabel = New System.Windows.Forms.Label()
        Me.searchBtn = New System.Windows.Forms.Button()
        Me.viewDBBtn = New System.Windows.Forms.Button()
        Me.addSchoolBtn = New System.Windows.Forms.Button()
        Me.addYearBtn = New System.Windows.Forms.Button()
        Me.addStudentBtn = New System.Windows.Forms.Button()
        Me.addUserBtn = New System.Windows.Forms.Button()
        Me.addClassBtn = New System.Windows.Forms.Button()
        Me.viewMyClassesBtn = New System.Windows.Forms.Button()
        Me.viewResultBtn = New System.Windows.Forms.Button()
        Me.aboutLink = New System.Windows.Forms.LinkLabel()
        Me.supportLink = New System.Windows.Forms.LinkLabel()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.SuspendLayout()
        '
        'currentUserLabel
        '
        Me.currentUserLabel.AutoSize = True
        Me.currentUserLabel.Location = New System.Drawing.Point(127, 9)
        Me.currentUserLabel.Name = "currentUserLabel"
        Me.currentUserLabel.Size = New System.Drawing.Size(77, 13)
        Me.currentUserLabel.TabIndex = 0
        Me.currentUserLabel.Text = "Logged in as : "
        '
        'searchBtn
        '
        Me.searchBtn.Location = New System.Drawing.Point(76, 42)
        Me.searchBtn.Name = "searchBtn"
        Me.searchBtn.Size = New System.Drawing.Size(195, 43)
        Me.searchBtn.TabIndex = 1
        Me.searchBtn.Text = "Search"
        Me.searchBtn.UseVisualStyleBackColor = True
        '
        'viewDBBtn
        '
        Me.viewDBBtn.Location = New System.Drawing.Point(76, 103)
        Me.viewDBBtn.Name = "viewDBBtn"
        Me.viewDBBtn.Size = New System.Drawing.Size(195, 43)
        Me.viewDBBtn.TabIndex = 2
        Me.viewDBBtn.Text = "View Database"
        Me.viewDBBtn.UseVisualStyleBackColor = True
        '
        'addSchoolBtn
        '
        Me.addSchoolBtn.Location = New System.Drawing.Point(76, 164)
        Me.addSchoolBtn.Name = "addSchoolBtn"
        Me.addSchoolBtn.Size = New System.Drawing.Size(195, 43)
        Me.addSchoolBtn.TabIndex = 3
        Me.addSchoolBtn.Text = "Add School"
        Me.addSchoolBtn.UseVisualStyleBackColor = True
        '
        'addYearBtn
        '
        Me.addYearBtn.Location = New System.Drawing.Point(76, 224)
        Me.addYearBtn.Name = "addYearBtn"
        Me.addYearBtn.Size = New System.Drawing.Size(195, 43)
        Me.addYearBtn.TabIndex = 4
        Me.addYearBtn.Text = "Add Year"
        Me.addYearBtn.UseVisualStyleBackColor = True
        '
        'addStudentBtn
        '
        Me.addStudentBtn.Location = New System.Drawing.Point(76, 284)
        Me.addStudentBtn.Name = "addStudentBtn"
        Me.addStudentBtn.Size = New System.Drawing.Size(195, 43)
        Me.addStudentBtn.TabIndex = 5
        Me.addStudentBtn.Text = "Add Student"
        Me.addStudentBtn.UseVisualStyleBackColor = True
        '
        'addUserBtn
        '
        Me.addUserBtn.Location = New System.Drawing.Point(76, 399)
        Me.addUserBtn.Name = "addUserBtn"
        Me.addUserBtn.Size = New System.Drawing.Size(195, 43)
        Me.addUserBtn.TabIndex = 7
        Me.addUserBtn.Text = "Add User"
        Me.addUserBtn.UseVisualStyleBackColor = True
        '
        'addClassBtn
        '
        Me.addClassBtn.Location = New System.Drawing.Point(76, 343)
        Me.addClassBtn.Name = "addClassBtn"
        Me.addClassBtn.Size = New System.Drawing.Size(195, 43)
        Me.addClassBtn.TabIndex = 6
        Me.addClassBtn.Text = "Add Class"
        Me.addClassBtn.UseVisualStyleBackColor = True
        '
        'viewMyClassesBtn
        '
        Me.viewMyClassesBtn.Location = New System.Drawing.Point(76, 164)
        Me.viewMyClassesBtn.Name = "viewMyClassesBtn"
        Me.viewMyClassesBtn.Size = New System.Drawing.Size(195, 43)
        Me.viewMyClassesBtn.TabIndex = 3
        Me.viewMyClassesBtn.Text = "View My Classes"
        Me.viewMyClassesBtn.UseVisualStyleBackColor = True
        Me.viewMyClassesBtn.Visible = False
        '
        'viewResultBtn
        '
        Me.viewResultBtn.Location = New System.Drawing.Point(76, 458)
        Me.viewResultBtn.Name = "viewResultBtn"
        Me.viewResultBtn.Size = New System.Drawing.Size(195, 43)
        Me.viewResultBtn.TabIndex = 8
        Me.viewResultBtn.Text = "View Results"
        Me.viewResultBtn.UseVisualStyleBackColor = True
        '
        'aboutLink
        '
        Me.aboutLink.AutoSize = True
        Me.aboutLink.Location = New System.Drawing.Point(132, 506)
        Me.aboutLink.Name = "aboutLink"
        Me.aboutLink.Size = New System.Drawing.Size(35, 13)
        Me.aboutLink.TabIndex = 10
        Me.aboutLink.TabStop = True
        Me.aboutLink.Text = "About"
        '
        'supportLink
        '
        Me.supportLink.AutoSize = True
        Me.supportLink.Location = New System.Drawing.Point(173, 506)
        Me.supportLink.Name = "supportLink"
        Me.supportLink.Size = New System.Drawing.Size(44, 13)
        Me.supportLink.TabIndex = 11
        Me.supportLink.TabStop = True
        Me.supportLink.Text = "Support"
        '
        'HomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(340, 528)
        Me.Controls.Add(Me.supportLink)
        Me.Controls.Add(Me.aboutLink)
        Me.Controls.Add(Me.viewResultBtn)
        Me.Controls.Add(Me.viewMyClassesBtn)
        Me.Controls.Add(Me.addClassBtn)
        Me.Controls.Add(Me.addUserBtn)
        Me.Controls.Add(Me.addStudentBtn)
        Me.Controls.Add(Me.addYearBtn)
        Me.Controls.Add(Me.addSchoolBtn)
        Me.Controls.Add(Me.viewDBBtn)
        Me.Controls.Add(Me.searchBtn)
        Me.Controls.Add(Me.currentUserLabel)
        Me.MaximizeBox = False
        Me.Name = "HomeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents currentUserLabel As Label
    Friend WithEvents searchBtn As Button
    Friend WithEvents viewDBBtn As Button
    Friend WithEvents addSchoolBtn As Button
    Friend WithEvents addYearBtn As Button
    Friend WithEvents addStudentBtn As Button
    Friend WithEvents addUserBtn As Button
    Friend WithEvents addClassBtn As Button
    Friend WithEvents viewMyClassesBtn As Button
    Friend WithEvents viewResultBtn As Button
    Friend WithEvents aboutLink As LinkLabel
    Friend WithEvents supportLink As LinkLabel
    Friend WithEvents HelpProvider As HelpProvider
End Class
