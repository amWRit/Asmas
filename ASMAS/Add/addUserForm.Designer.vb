<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addUserForm
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
        Me.fullnameTextBox = New System.Windows.Forms.TextBox()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.userNameLabel = New System.Windows.Forms.Label()
        Me.usernameTextBox = New System.Windows.Forms.TextBox()
        Me.roleLabel = New System.Windows.Forms.Label()
        Me.roleCombo = New System.Windows.Forms.ComboBox()
        Me.FNLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.passwordLabel = New System.Windows.Forms.Label()
        Me.pwdTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'fullnameTextBox
        '
        Me.fullnameTextBox.Location = New System.Drawing.Point(94, 45)
        Me.fullnameTextBox.Name = "fullnameTextBox"
        Me.fullnameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.fullnameTextBox.TabIndex = 0
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(50, 213)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(75, 23)
        Me.saveBtn.TabIndex = 4
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(140, 213)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 5
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'userNameLabel
        '
        Me.userNameLabel.AutoSize = True
        Me.userNameLabel.Location = New System.Drawing.Point(26, 87)
        Me.userNameLabel.Name = "userNameLabel"
        Me.userNameLabel.Size = New System.Drawing.Size(58, 13)
        Me.userNameLabel.TabIndex = 39
        Me.userNameLabel.Text = "User name"
        '
        'usernameTextBox
        '
        Me.usernameTextBox.Location = New System.Drawing.Point(94, 80)
        Me.usernameTextBox.Name = "usernameTextBox"
        Me.usernameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.usernameTextBox.TabIndex = 1
        '
        'roleLabel
        '
        Me.roleLabel.AutoSize = True
        Me.roleLabel.Location = New System.Drawing.Point(49, 155)
        Me.roleLabel.Name = "roleLabel"
        Me.roleLabel.Size = New System.Drawing.Size(29, 13)
        Me.roleLabel.TabIndex = 37
        Me.roleLabel.Text = "Role"
        '
        'roleCombo
        '
        Me.roleCombo.FormattingEnabled = True
        Me.roleCombo.Items.AddRange(New Object() {"Admin", "Teacher", "Viewer"})
        Me.roleCombo.Location = New System.Drawing.Point(94, 152)
        Me.roleCombo.Name = "roleCombo"
        Me.roleCombo.Size = New System.Drawing.Size(121, 21)
        Me.roleCombo.TabIndex = 3
        Me.roleCombo.Text = "Choose role.."
        '
        'FNLabel
        '
        Me.FNLabel.AutoSize = True
        Me.FNLabel.Location = New System.Drawing.Point(24, 52)
        Me.FNLabel.Name = "FNLabel"
        Me.FNLabel.Size = New System.Drawing.Size(54, 13)
        Me.FNLabel.TabIndex = 35
        Me.FNLabel.Text = "Full Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Nexa Light", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Add USER"
        '
        'passwordLabel
        '
        Me.passwordLabel.AutoSize = True
        Me.passwordLabel.Location = New System.Drawing.Point(28, 120)
        Me.passwordLabel.Name = "passwordLabel"
        Me.passwordLabel.Size = New System.Drawing.Size(53, 13)
        Me.passwordLabel.TabIndex = 44
        Me.passwordLabel.Text = "Password"
        '
        'pwdTextBox
        '
        Me.pwdTextBox.Location = New System.Drawing.Point(96, 113)
        Me.pwdTextBox.Name = "pwdTextBox"
        Me.pwdTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pwdTextBox.Size = New System.Drawing.Size(121, 20)
        Me.pwdTextBox.TabIndex = 2
        '
        'addUserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(244, 242)
        Me.Controls.Add(Me.passwordLabel)
        Me.Controls.Add(Me.pwdTextBox)
        Me.Controls.Add(Me.fullnameTextBox)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.userNameLabel)
        Me.Controls.Add(Me.usernameTextBox)
        Me.Controls.Add(Me.roleLabel)
        Me.Controls.Add(Me.roleCombo)
        Me.Controls.Add(Me.FNLabel)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "addUserForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "addUserForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fullnameTextBox As TextBox
    Friend WithEvents saveBtn As Button
    Friend WithEvents cancelBtn As Button
    Friend WithEvents userNameLabel As Label
    Friend WithEvents usernameTextBox As TextBox
    Friend WithEvents roleLabel As Label
    Friend WithEvents roleCombo As ComboBox
    Friend WithEvents FNLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents passwordLabel As Label
    Friend WithEvents pwdTextBox As TextBox
End Class
