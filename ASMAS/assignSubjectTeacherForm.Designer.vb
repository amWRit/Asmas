<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class assignSubjectTeacherForm
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
        Me.subjectCombo = New System.Windows.Forms.ComboBox()
        Me.teacherCombo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.assignBtn = New System.Windows.Forms.Button()
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Subject"
        '
        'subjectCombo
        '
        Me.subjectCombo.FormattingEnabled = True
        Me.subjectCombo.Location = New System.Drawing.Point(85, 45)
        Me.subjectCombo.Name = "subjectCombo"
        Me.subjectCombo.Size = New System.Drawing.Size(121, 21)
        Me.subjectCombo.TabIndex = 1
        Me.subjectCombo.Text = "Choose subject..."
        '
        'teacherCombo
        '
        Me.teacherCombo.FormattingEnabled = True
        Me.teacherCombo.Location = New System.Drawing.Point(85, 82)
        Me.teacherCombo.Name = "teacherCombo"
        Me.teacherCombo.Size = New System.Drawing.Size(121, 21)
        Me.teacherCombo.TabIndex = 3
        Me.teacherCombo.Text = "Choose teacher..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Teacher"
        '
        'assignBtn
        '
        Me.assignBtn.Location = New System.Drawing.Point(27, 130)
        Me.assignBtn.Name = "assignBtn"
        Me.assignBtn.Size = New System.Drawing.Size(179, 30)
        Me.assignBtn.TabIndex = 4
        Me.assignBtn.Text = "Assign"
        Me.assignBtn.UseVisualStyleBackColor = True
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Myriad Pro Light", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(24, 9)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(48, 20)
        Me.titleLabel.TabIndex = 168
        Me.titleLabel.Text = "Class:"
        '
        'assignSubjectTeacherForm
        '
        Me.AcceptButton = Me.assignBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(238, 172)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.assignBtn)
        Me.Controls.Add(Me.teacherCombo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.subjectCombo)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "assignSubjectTeacherForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subject Teacher"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents subjectCombo As ComboBox
    Friend WithEvents teacherCombo As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents assignBtn As Button
    Friend WithEvents titleLabel As Label
End Class
