<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addAttendance
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
        Me.presentCheckLabel = New System.Windows.Forms.Label()
        Me.prevBtn = New System.Windows.Forms.Button()
        Me.nextBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.termCombo = New System.Windows.Forms.ComboBox()
        Me.remainingCount = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.presentDays = New System.Windows.Forms.TextBox()
        Me.percAtt = New System.Windows.Forms.TextBox()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.regNumberTextBox = New System.Windows.Forms.TextBox()
        Me.studentRegLabel = New System.Windows.Forms.Label()
        Me.studentNameTextBox = New System.Windows.Forms.TextBox()
        Me.totalDays = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'presentCheckLabel
        '
        Me.presentCheckLabel.AutoSize = True
        Me.presentCheckLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.4!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.presentCheckLabel.ForeColor = System.Drawing.Color.ForestGreen
        Me.presentCheckLabel.Location = New System.Drawing.Point(292, 107)
        Me.presentCheckLabel.Name = "presentCheckLabel"
        Me.presentCheckLabel.Size = New System.Drawing.Size(0, 15)
        Me.presentCheckLabel.TabIndex = 226
        '
        'prevBtn
        '
        Me.prevBtn.Enabled = False
        Me.prevBtn.Location = New System.Drawing.Point(28, 221)
        Me.prevBtn.Name = "prevBtn"
        Me.prevBtn.Size = New System.Drawing.Size(75, 23)
        Me.prevBtn.TabIndex = 224
        Me.prevBtn.Text = "Previous"
        Me.prevBtn.UseVisualStyleBackColor = True
        '
        'nextBtn
        '
        Me.nextBtn.Enabled = False
        Me.nextBtn.Location = New System.Drawing.Point(109, 221)
        Me.nextBtn.Name = "nextBtn"
        Me.nextBtn.Size = New System.Drawing.Size(75, 23)
        Me.nextBtn.TabIndex = 223
        Me.nextBtn.Text = "Next"
        Me.nextBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 222
        Me.Label2.Text = "Choose Terminal"
        '
        'termCombo
        '
        Me.termCombo.FormattingEnabled = True
        Me.termCombo.Items.AddRange(New Object() {"First", "Second", "Third", "SendUp"})
        Me.termCombo.Location = New System.Drawing.Point(109, 50)
        Me.termCombo.Name = "termCombo"
        Me.termCombo.Size = New System.Drawing.Size(98, 21)
        Me.termCombo.TabIndex = 12
        Me.termCombo.Text = "Choose terminal..."
        '
        'remainingCount
        '
        Me.remainingCount.AutoSize = True
        Me.remainingCount.Location = New System.Drawing.Point(449, 0)
        Me.remainingCount.Name = "remainingCount"
        Me.remainingCount.Size = New System.Drawing.Size(22, 13)
        Me.remainingCount.TabIndex = 194
        Me.remainingCount.Text = "cnt"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(387, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 193
        Me.Label5.Text = "Remaining: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.4!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(184, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 15)
        Me.Label6.TabIndex = 225
        Me.Label6.Text = "Marks Entered? "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.remainingCount)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.presentDays)
        Me.GroupBox1.Controls.Add(Me.percAtt)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 130)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(476, 85)
        Me.GroupBox1.TabIndex = 217
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Enter Attendance"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Adobe Heiti Std R", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.Location = New System.Drawing.Point(256, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 16)
        Me.Label4.TabIndex = 192
        Me.Label4.Text = "Percentage (%)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Adobe Heiti Std R", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(102, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 16)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "Present Days"
        '
        'presentDays
        '
        Me.presentDays.Location = New System.Drawing.Point(105, 48)
        Me.presentDays.Name = "presentDays"
        Me.presentDays.Size = New System.Drawing.Size(100, 20)
        Me.presentDays.TabIndex = 15
        Me.presentDays.Text = "0"
        '
        'percAtt
        '
        Me.percAtt.Location = New System.Drawing.Point(259, 48)
        Me.percAtt.Name = "percAtt"
        Me.percAtt.Size = New System.Drawing.Size(100, 20)
        Me.percAtt.TabIndex = 16
        Me.percAtt.Text = "0"
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(428, 222)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 219
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(347, 222)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(75, 23)
        Me.saveBtn.TabIndex = 17
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(224, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 221
        Me.Label14.Text = "Student Name"
        '
        'regNumberTextBox
        '
        Me.regNumberTextBox.Enabled = False
        Me.regNumberTextBox.Location = New System.Drawing.Point(109, 12)
        Me.regNumberTextBox.Name = "regNumberTextBox"
        Me.regNumberTextBox.Size = New System.Drawing.Size(98, 20)
        Me.regNumberTextBox.TabIndex = 1
        '
        'studentRegLabel
        '
        Me.studentRegLabel.AutoSize = True
        Me.studentRegLabel.Location = New System.Drawing.Point(19, 19)
        Me.studentRegLabel.Name = "studentRegLabel"
        Me.studentRegLabel.Size = New System.Drawing.Size(67, 13)
        Me.studentRegLabel.TabIndex = 220
        Me.studentRegLabel.Text = "Reg Number"
        '
        'studentNameTextBox
        '
        Me.studentNameTextBox.Enabled = False
        Me.studentNameTextBox.Location = New System.Drawing.Point(314, 12)
        Me.studentNameTextBox.Name = "studentNameTextBox"
        Me.studentNameTextBox.Size = New System.Drawing.Size(182, 20)
        Me.studentNameTextBox.TabIndex = 2
        '
        'totalDays
        '
        Me.totalDays.Location = New System.Drawing.Point(314, 51)
        Me.totalDays.Name = "totalDays"
        Me.totalDays.Size = New System.Drawing.Size(98, 20)
        Me.totalDays.TabIndex = 14
        Me.totalDays.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(224, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 228
        Me.Label1.Text = "Total days"
        '
        'addAttendance
        '
        Me.AcceptButton = Me.saveBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 256)
        Me.Controls.Add(Me.totalDays)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.presentCheckLabel)
        Me.Controls.Add(Me.prevBtn)
        Me.Controls.Add(Me.nextBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.termCombo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.regNumberTextBox)
        Me.Controls.Add(Me.studentRegLabel)
        Me.Controls.Add(Me.studentNameTextBox)
        Me.Name = "addAttendance"
        Me.Text = "addAttendance"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents presentCheckLabel As Label
    Friend WithEvents prevBtn As Button
    Friend WithEvents nextBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents termCombo As ComboBox
    Friend WithEvents remainingCount As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents presentDays As TextBox
    Friend WithEvents percAtt As TextBox
    Friend WithEvents cancelBtn As Button
    Friend WithEvents saveBtn As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents regNumberTextBox As TextBox
    Friend WithEvents studentRegLabel As Label
    Friend WithEvents studentNameTextBox As TextBox
    Friend WithEvents totalDays As TextBox
    Friend WithEvents Label1 As Label
End Class
