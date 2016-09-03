<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addClassForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.yearLabel = New System.Windows.Forms.Label()
        Me.yearNameCombo = New System.Windows.Forms.ComboBox()
        Me.schoolLabel = New System.Windows.Forms.Label()
        Me.schoolNameCombo = New System.Windows.Forms.ComboBox()
        Me.shortnameTextBox = New System.Windows.Forms.TextBox()
        Me.fullnameTextBox = New System.Windows.Forms.TextBox()
        Me.sizeTextBox = New System.Windows.Forms.TextBox()
        Me.shortNameLabel = New System.Windows.Forms.Label()
        Me.fullNameLabel = New System.Windows.Forms.Label()
        Me.sizeLabel = New System.Windows.Forms.Label()
        Me.ctLabel = New System.Windows.Forms.Label()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.currentUserLabel = New System.Windows.Forms.Label()
        Me.ctCombo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Nexa Light", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add Class"
        '
        'yearLabel
        '
        Me.yearLabel.AutoSize = True
        Me.yearLabel.Location = New System.Drawing.Point(221, 44)
        Me.yearLabel.Name = "yearLabel"
        Me.yearLabel.Size = New System.Drawing.Size(29, 13)
        Me.yearLabel.TabIndex = 7
        Me.yearLabel.Text = "Year"
        '
        'yearNameCombo
        '
        Me.yearNameCombo.FormattingEnabled = True
        Me.yearNameCombo.Location = New System.Drawing.Point(265, 36)
        Me.yearNameCombo.Name = "yearNameCombo"
        Me.yearNameCombo.Size = New System.Drawing.Size(121, 21)
        Me.yearNameCombo.TabIndex = 1
        Me.yearNameCombo.Text = "Choose year..."
        '
        'schoolLabel
        '
        Me.schoolLabel.AutoSize = True
        Me.schoolLabel.Location = New System.Drawing.Point(14, 39)
        Me.schoolLabel.Name = "schoolLabel"
        Me.schoolLabel.Size = New System.Drawing.Size(40, 13)
        Me.schoolLabel.TabIndex = 5
        Me.schoolLabel.Text = "School"
        '
        'schoolNameCombo
        '
        Me.schoolNameCombo.FormattingEnabled = True
        Me.schoolNameCombo.Location = New System.Drawing.Point(69, 36)
        Me.schoolNameCombo.Name = "schoolNameCombo"
        Me.schoolNameCombo.Size = New System.Drawing.Size(121, 21)
        Me.schoolNameCombo.TabIndex = 0
        Me.schoolNameCombo.Text = "Choose School..."
        '
        'shortnameTextBox
        '
        Me.shortnameTextBox.Location = New System.Drawing.Point(108, 87)
        Me.shortnameTextBox.Name = "shortnameTextBox"
        Me.shortnameTextBox.Size = New System.Drawing.Size(212, 20)
        Me.shortnameTextBox.TabIndex = 2
        '
        'fullnameTextBox
        '
        Me.fullnameTextBox.Location = New System.Drawing.Point(108, 120)
        Me.fullnameTextBox.Name = "fullnameTextBox"
        Me.fullnameTextBox.Size = New System.Drawing.Size(212, 20)
        Me.fullnameTextBox.TabIndex = 3
        '
        'sizeTextBox
        '
        Me.sizeTextBox.Location = New System.Drawing.Point(108, 153)
        Me.sizeTextBox.Name = "sizeTextBox"
        Me.sizeTextBox.Size = New System.Drawing.Size(212, 20)
        Me.sizeTextBox.TabIndex = 4
        '
        'shortNameLabel
        '
        Me.shortNameLabel.AutoSize = True
        Me.shortNameLabel.Location = New System.Drawing.Point(17, 94)
        Me.shortNameLabel.Name = "shortNameLabel"
        Me.shortNameLabel.Size = New System.Drawing.Size(63, 13)
        Me.shortNameLabel.TabIndex = 12
        Me.shortNameLabel.Text = "Short Name"
        '
        'fullNameLabel
        '
        Me.fullNameLabel.AutoSize = True
        Me.fullNameLabel.Location = New System.Drawing.Point(17, 127)
        Me.fullNameLabel.Name = "fullNameLabel"
        Me.fullNameLabel.Size = New System.Drawing.Size(54, 13)
        Me.fullNameLabel.TabIndex = 13
        Me.fullNameLabel.Text = "Full Name"
        '
        'sizeLabel
        '
        Me.sizeLabel.AutoSize = True
        Me.sizeLabel.Location = New System.Drawing.Point(17, 160)
        Me.sizeLabel.Name = "sizeLabel"
        Me.sizeLabel.Size = New System.Drawing.Size(81, 13)
        Me.sizeLabel.TabIndex = 14
        Me.sizeLabel.Text = "No. of Students"
        '
        'ctLabel
        '
        Me.ctLabel.AutoSize = True
        Me.ctLabel.Location = New System.Drawing.Point(17, 194)
        Me.ctLabel.Name = "ctLabel"
        Me.ctLabel.Size = New System.Drawing.Size(71, 13)
        Me.ctLabel.TabIndex = 15
        Me.ctLabel.Text = "Class teacher"
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(311, 232)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 7
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(224, 232)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(75, 23)
        Me.saveBtn.TabIndex = 6
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'currentUserLabel
        '
        Me.currentUserLabel.AutoSize = True
        Me.currentUserLabel.Location = New System.Drawing.Point(222, 9)
        Me.currentUserLabel.Name = "currentUserLabel"
        Me.currentUserLabel.Size = New System.Drawing.Size(77, 13)
        Me.currentUserLabel.TabIndex = 18
        Me.currentUserLabel.Text = "Logged in as : "
        '
        'ctCombo
        '
        Me.ctCombo.FormattingEnabled = True
        Me.ctCombo.Location = New System.Drawing.Point(108, 186)
        Me.ctCombo.Name = "ctCombo"
        Me.ctCombo.Size = New System.Drawing.Size(212, 21)
        Me.ctCombo.TabIndex = 5
        Me.ctCombo.Text = "Choose class teacher..."
        '
        'addClassForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 274)
        Me.Controls.Add(Me.ctCombo)
        Me.Controls.Add(Me.currentUserLabel)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.ctLabel)
        Me.Controls.Add(Me.sizeLabel)
        Me.Controls.Add(Me.fullNameLabel)
        Me.Controls.Add(Me.shortNameLabel)
        Me.Controls.Add(Me.sizeTextBox)
        Me.Controls.Add(Me.fullnameTextBox)
        Me.Controls.Add(Me.shortnameTextBox)
        Me.Controls.Add(Me.yearLabel)
        Me.Controls.Add(Me.yearNameCombo)
        Me.Controls.Add(Me.schoolLabel)
        Me.Controls.Add(Me.schoolNameCombo)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "addClassForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "addClassForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents yearLabel As Label
    Friend WithEvents yearNameCombo As ComboBox
    Friend WithEvents schoolLabel As Label
    Friend WithEvents schoolNameCombo As ComboBox
    Friend WithEvents shortnameTextBox As TextBox
    Friend WithEvents fullnameTextBox As TextBox
    Friend WithEvents sizeTextBox As TextBox
    Friend WithEvents shortNameLabel As Label
    Friend WithEvents fullNameLabel As Label
    Friend WithEvents sizeLabel As Label
    Friend WithEvents ctLabel As Label
    Friend WithEvents cancelBtn As Button
    Friend WithEvents saveBtn As Button
    Friend WithEvents currentUserLabel As Label
    Friend WithEvents ctCombo As ComboBox
End Class
