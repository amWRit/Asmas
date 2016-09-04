<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addYearForm
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
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.yearLabel = New System.Windows.Forms.Label()
        Me.schoolCombo = New System.Windows.Forms.ComboBox()
        Me.schoolLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.yearTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(73, 129)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(75, 23)
        Me.saveBtn.TabIndex = 2
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(163, 129)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 3
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'yearLabel
        '
        Me.yearLabel.AutoSize = True
        Me.yearLabel.Location = New System.Drawing.Point(49, 88)
        Me.yearLabel.Name = "yearLabel"
        Me.yearLabel.Size = New System.Drawing.Size(52, 13)
        Me.yearLabel.TabIndex = 51
        Me.yearLabel.Text = "Year (BS)"
        '
        'schoolCombo
        '
        Me.schoolCombo.FormattingEnabled = True
        Me.schoolCombo.Location = New System.Drawing.Point(117, 50)
        Me.schoolCombo.Name = "schoolCombo"
        Me.schoolCombo.Size = New System.Drawing.Size(121, 21)
        Me.schoolCombo.TabIndex = 0
        Me.schoolCombo.Text = "Choose school.."
        '
        'schoolLabel
        '
        Me.schoolLabel.AutoSize = True
        Me.schoolLabel.Location = New System.Drawing.Point(47, 53)
        Me.schoolLabel.Name = "schoolLabel"
        Me.schoolLabel.Size = New System.Drawing.Size(40, 13)
        Me.schoolLabel.TabIndex = 46
        Me.schoolLabel.Text = "School"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Nexa Light", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Add YEAR"
        '
        'yearTextBox
        '
        Me.yearTextBox.Location = New System.Drawing.Point(117, 81)
        Me.yearTextBox.Name = "yearTextBox"
        Me.yearTextBox.Size = New System.Drawing.Size(121, 20)
        Me.yearTextBox.TabIndex = 1
        '
        'addYearForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 181)
        Me.Controls.Add(Me.yearTextBox)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.yearLabel)
        Me.Controls.Add(Me.schoolCombo)
        Me.Controls.Add(Me.schoolLabel)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "addYearForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Year"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents saveBtn As Button
    Friend WithEvents cancelBtn As Button
    Friend WithEvents yearLabel As Label
    Friend WithEvents schoolCombo As ComboBox
    Friend WithEvents schoolLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents yearTextBox As TextBox
End Class
