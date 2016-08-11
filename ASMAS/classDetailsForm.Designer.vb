<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class classDetailsForm
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
        Me.ctLabel = New System.Windows.Forms.Label()
        Me.sizeLabel = New System.Windows.Forms.Label()
        Me.fullNameLabel = New System.Windows.Forms.Label()
        Me.shortNameLabel = New System.Windows.Forms.Label()
        Me.yearLabel = New System.Windows.Forms.Label()
        Me.schoolLabel = New System.Windows.Forms.Label()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.ct = New System.Windows.Forms.Label()
        Me.sizeOfClass = New System.Windows.Forms.Label()
        Me.fullname = New System.Windows.Forms.Label()
        Me.shortName = New System.Windows.Forms.Label()
        Me.yearNum = New System.Windows.Forms.Label()
        Me.schoolName = New System.Windows.Forms.Label()
        Me.editBtn = New System.Windows.Forms.Button()
        Me.addStudentBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ctLabel
        '
        Me.ctLabel.AutoSize = True
        Me.ctLabel.Location = New System.Drawing.Point(38, 224)
        Me.ctLabel.Name = "ctLabel"
        Me.ctLabel.Size = New System.Drawing.Size(71, 13)
        Me.ctLabel.TabIndex = 27
        Me.ctLabel.Text = "Class teacher"
        '
        'sizeLabel
        '
        Me.sizeLabel.AutoSize = True
        Me.sizeLabel.Location = New System.Drawing.Point(28, 189)
        Me.sizeLabel.Name = "sizeLabel"
        Me.sizeLabel.Size = New System.Drawing.Size(81, 13)
        Me.sizeLabel.TabIndex = 26
        Me.sizeLabel.Text = "No. of Students"
        '
        'fullNameLabel
        '
        Me.fullNameLabel.AutoSize = True
        Me.fullNameLabel.Location = New System.Drawing.Point(55, 155)
        Me.fullNameLabel.Name = "fullNameLabel"
        Me.fullNameLabel.Size = New System.Drawing.Size(54, 13)
        Me.fullNameLabel.TabIndex = 25
        Me.fullNameLabel.Text = "Full Name"
        '
        'shortNameLabel
        '
        Me.shortNameLabel.AutoSize = True
        Me.shortNameLabel.Location = New System.Drawing.Point(46, 116)
        Me.shortNameLabel.Name = "shortNameLabel"
        Me.shortNameLabel.Size = New System.Drawing.Size(63, 13)
        Me.shortNameLabel.TabIndex = 24
        Me.shortNameLabel.Text = "Short Name"
        '
        'yearLabel
        '
        Me.yearLabel.AutoSize = True
        Me.yearLabel.Location = New System.Drawing.Point(80, 87)
        Me.yearLabel.Name = "yearLabel"
        Me.yearLabel.Size = New System.Drawing.Size(29, 13)
        Me.yearLabel.TabIndex = 19
        Me.yearLabel.Text = "Year"
        '
        'schoolLabel
        '
        Me.schoolLabel.AutoSize = True
        Me.schoolLabel.Location = New System.Drawing.Point(69, 57)
        Me.schoolLabel.Name = "schoolLabel"
        Me.schoolLabel.Size = New System.Drawing.Size(40, 13)
        Me.schoolLabel.TabIndex = 17
        Me.schoolLabel.Text = "School"
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Nexa Light", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(17, 20)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(76, 16)
        Me.titleLabel.TabIndex = 28
        Me.titleLabel.Text = "Class detail"
        '
        'ct
        '
        Me.ct.AutoSize = True
        Me.ct.Font = New System.Drawing.Font("Adobe Fangsong Std R", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ct.Location = New System.Drawing.Point(136, 224)
        Me.ct.Name = "ct"
        Me.ct.Size = New System.Drawing.Size(11, 16)
        Me.ct.TabIndex = 34
        Me.ct.Text = ":"
        '
        'sizeOfClass
        '
        Me.sizeOfClass.AutoSize = True
        Me.sizeOfClass.Font = New System.Drawing.Font("Adobe Fangsong Std R", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sizeOfClass.Location = New System.Drawing.Point(136, 189)
        Me.sizeOfClass.Name = "sizeOfClass"
        Me.sizeOfClass.Size = New System.Drawing.Size(11, 16)
        Me.sizeOfClass.TabIndex = 33
        Me.sizeOfClass.Text = ":"
        '
        'fullname
        '
        Me.fullname.AutoSize = True
        Me.fullname.Font = New System.Drawing.Font("Adobe Fangsong Std R", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fullname.Location = New System.Drawing.Point(136, 155)
        Me.fullname.Name = "fullname"
        Me.fullname.Size = New System.Drawing.Size(11, 16)
        Me.fullname.TabIndex = 32
        Me.fullname.Text = ":"
        '
        'shortName
        '
        Me.shortName.AutoSize = True
        Me.shortName.Font = New System.Drawing.Font("Adobe Fangsong Std R", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shortName.Location = New System.Drawing.Point(136, 116)
        Me.shortName.Name = "shortName"
        Me.shortName.Size = New System.Drawing.Size(11, 16)
        Me.shortName.TabIndex = 31
        Me.shortName.Text = ":"
        '
        'yearNum
        '
        Me.yearNum.AutoSize = True
        Me.yearNum.Font = New System.Drawing.Font("Adobe Fangsong Std R", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.yearNum.Location = New System.Drawing.Point(136, 87)
        Me.yearNum.Name = "yearNum"
        Me.yearNum.Size = New System.Drawing.Size(11, 16)
        Me.yearNum.TabIndex = 30
        Me.yearNum.Text = ":"
        '
        'schoolName
        '
        Me.schoolName.AutoSize = True
        Me.schoolName.Font = New System.Drawing.Font("Adobe Fangsong Std R", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schoolName.Location = New System.Drawing.Point(136, 54)
        Me.schoolName.Name = "schoolName"
        Me.schoolName.Size = New System.Drawing.Size(11, 16)
        Me.schoolName.TabIndex = 29
        Me.schoolName.Text = ":"
        '
        'editBtn
        '
        Me.editBtn.Location = New System.Drawing.Point(259, 242)
        Me.editBtn.Name = "editBtn"
        Me.editBtn.Size = New System.Drawing.Size(75, 23)
        Me.editBtn.TabIndex = 35
        Me.editBtn.Text = "Edit"
        Me.editBtn.UseVisualStyleBackColor = True
        '
        'addStudentBtn
        '
        Me.addStudentBtn.Location = New System.Drawing.Point(352, 242)
        Me.addStudentBtn.Name = "addStudentBtn"
        Me.addStudentBtn.Size = New System.Drawing.Size(75, 23)
        Me.addStudentBtn.TabIndex = 36
        Me.addStudentBtn.Text = "Add student"
        Me.addStudentBtn.UseVisualStyleBackColor = True
        '
        'classDetailsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 277)
        Me.Controls.Add(Me.addStudentBtn)
        Me.Controls.Add(Me.editBtn)
        Me.Controls.Add(Me.ct)
        Me.Controls.Add(Me.sizeOfClass)
        Me.Controls.Add(Me.fullname)
        Me.Controls.Add(Me.shortName)
        Me.Controls.Add(Me.yearNum)
        Me.Controls.Add(Me.schoolName)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.ctLabel)
        Me.Controls.Add(Me.sizeLabel)
        Me.Controls.Add(Me.fullNameLabel)
        Me.Controls.Add(Me.shortNameLabel)
        Me.Controls.Add(Me.yearLabel)
        Me.Controls.Add(Me.schoolLabel)
        Me.MaximizeBox = False
        Me.Name = "classDetailsForm"
        Me.Text = "classDetailsForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ctLabel As Label
    Friend WithEvents sizeLabel As Label
    Friend WithEvents fullNameLabel As Label
    Friend WithEvents shortNameLabel As Label
    Friend WithEvents yearLabel As Label
    Friend WithEvents schoolLabel As Label
    Friend WithEvents titleLabel As Label
    Friend WithEvents ct As Label
    Friend WithEvents sizeOfClass As Label
    Friend WithEvents fullname As Label
    Friend WithEvents shortName As Label
    Friend WithEvents yearNum As Label
    Friend WithEvents schoolName As Label
    Friend WithEvents editBtn As Button
    Friend WithEvents addStudentBtn As Button
End Class
