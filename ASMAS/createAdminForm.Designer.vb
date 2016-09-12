<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class createAdminForm
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
        Me.passwordLabel = New System.Windows.Forms.Label()
        Me.pwdTextBox = New System.Windows.Forms.TextBox()
        Me.fullnameTextBox = New System.Windows.Forms.TextBox()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.userNameLabel = New System.Windows.Forms.Label()
        Me.usernameTextBox = New System.Windows.Forms.TextBox()
        Me.FNLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'passwordLabel
        '
        Me.passwordLabel.AutoSize = True
        Me.passwordLabel.Location = New System.Drawing.Point(44, 119)
        Me.passwordLabel.Name = "passwordLabel"
        Me.passwordLabel.Size = New System.Drawing.Size(53, 13)
        Me.passwordLabel.TabIndex = 55
        Me.passwordLabel.Text = "Password"
        '
        'pwdTextBox
        '
        Me.pwdTextBox.Location = New System.Drawing.Point(112, 112)
        Me.pwdTextBox.Name = "pwdTextBox"
        Me.pwdTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pwdTextBox.Size = New System.Drawing.Size(121, 20)
        Me.pwdTextBox.TabIndex = 47
        '
        'fullnameTextBox
        '
        Me.fullnameTextBox.Location = New System.Drawing.Point(110, 44)
        Me.fullnameTextBox.Name = "fullnameTextBox"
        Me.fullnameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.fullnameTextBox.TabIndex = 45
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(66, 164)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(75, 23)
        Me.saveBtn.TabIndex = 49
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(156, 164)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 50
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'userNameLabel
        '
        Me.userNameLabel.AutoSize = True
        Me.userNameLabel.Location = New System.Drawing.Point(42, 86)
        Me.userNameLabel.Name = "userNameLabel"
        Me.userNameLabel.Size = New System.Drawing.Size(58, 13)
        Me.userNameLabel.TabIndex = 54
        Me.userNameLabel.Text = "User name"
        '
        'usernameTextBox
        '
        Me.usernameTextBox.Location = New System.Drawing.Point(110, 79)
        Me.usernameTextBox.Name = "usernameTextBox"
        Me.usernameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.usernameTextBox.TabIndex = 46
        '
        'FNLabel
        '
        Me.FNLabel.AutoSize = True
        Me.FNLabel.Location = New System.Drawing.Point(40, 51)
        Me.FNLabel.Name = "FNLabel"
        Me.FNLabel.Size = New System.Drawing.Size(54, 13)
        Me.FNLabel.TabIndex = 52
        Me.FNLabel.Text = "Full Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Nexa Light", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Create Admin"
        '
        'createAdminForm
        '
        Me.AcceptButton = Me.saveBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 211)
        Me.Controls.Add(Me.passwordLabel)
        Me.Controls.Add(Me.pwdTextBox)
        Me.Controls.Add(Me.fullnameTextBox)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.userNameLabel)
        Me.Controls.Add(Me.usernameTextBox)
        Me.Controls.Add(Me.FNLabel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "createAdminForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create New Admin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents passwordLabel As Label
    Friend WithEvents pwdTextBox As TextBox
    Friend WithEvents fullnameTextBox As TextBox
    Friend WithEvents saveBtn As Button
    Friend WithEvents cancelBtn As Button
    Friend WithEvents userNameLabel As Label
    Friend WithEvents usernameTextBox As TextBox
    Friend WithEvents FNLabel As Label
    Friend WithEvents Label1 As Label
End Class
