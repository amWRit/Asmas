<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class upgradeStudentForm
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.classCombo = New System.Windows.Forms.ComboBox()
        Me.upgradeBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Year:"
        '
        'yearLabel
        '
        Me.yearLabel.AutoSize = True
        Me.yearLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.yearLabel.Location = New System.Drawing.Point(57, 9)
        Me.yearLabel.Name = "yearLabel"
        Me.yearLabel.Size = New System.Drawing.Size(57, 17)
        Me.yearLabel.TabIndex = 1
        Me.yearLabel.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Available classes:"
        '
        'classCombo
        '
        Me.classCombo.FormattingEnabled = True
        Me.classCombo.Location = New System.Drawing.Point(121, 41)
        Me.classCombo.Name = "classCombo"
        Me.classCombo.Size = New System.Drawing.Size(121, 21)
        Me.classCombo.TabIndex = 0
        Me.classCombo.Text = "Choose class..."
        '
        'upgradeBtn
        '
        Me.upgradeBtn.Location = New System.Drawing.Point(167, 86)
        Me.upgradeBtn.Name = "upgradeBtn"
        Me.upgradeBtn.Size = New System.Drawing.Size(75, 23)
        Me.upgradeBtn.TabIndex = 5
        Me.upgradeBtn.Text = "Promote"
        Me.upgradeBtn.UseVisualStyleBackColor = True
        '
        'upgradeStudentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 136)
        Me.Controls.Add(Me.upgradeBtn)
        Me.Controls.Add(Me.classCombo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.yearLabel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "upgradeStudentForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "upgradeStudentForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents yearLabel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents classCombo As ComboBox
    Friend WithEvents upgradeBtn As Button
End Class
