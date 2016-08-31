<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addSchoolForm
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
        Me.shortnameTextBox = New System.Windows.Forms.TextBox()
        Me.shortnameLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fullnameTextBox = New System.Windows.Forms.TextBox()
        Me.fullnameLabel = New System.Windows.Forms.Label()
        Me.addressTextBox = New System.Windows.Forms.TextBox()
        Me.addressLabel = New System.Windows.Forms.Label()
        Me.estdTextBox = New System.Windows.Forms.TextBox()
        Me.estdLabel = New System.Windows.Forms.Label()
        Me.phoneTextBox = New System.Windows.Forms.TextBox()
        Me.phoneLabel = New System.Windows.Forms.Label()
        Me.emailTextBox = New System.Windows.Forms.TextBox()
        Me.emailLabel = New System.Windows.Forms.Label()
        Me.websiteTextBox = New System.Windows.Forms.TextBox()
        Me.websiteLabel = New System.Windows.Forms.Label()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.descLabel = New System.Windows.Forms.Label()
        Me.descTextBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'shortnameTextBox
        '
        Me.shortnameTextBox.Location = New System.Drawing.Point(108, 36)
        Me.shortnameTextBox.Name = "shortnameTextBox"
        Me.shortnameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.shortnameTextBox.TabIndex = 58
        '
        'shortnameLabel
        '
        Me.shortnameLabel.AutoSize = True
        Me.shortnameLabel.Location = New System.Drawing.Point(14, 39)
        Me.shortnameLabel.Name = "shortnameLabel"
        Me.shortnameLabel.Size = New System.Drawing.Size(63, 13)
        Me.shortnameLabel.TabIndex = 55
        Me.shortnameLabel.Text = "Short Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Nexa Light", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Add School"
        '
        'fullnameTextBox
        '
        Me.fullnameTextBox.Location = New System.Drawing.Point(108, 78)
        Me.fullnameTextBox.Name = "fullnameTextBox"
        Me.fullnameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.fullnameTextBox.TabIndex = 60
        '
        'fullnameLabel
        '
        Me.fullnameLabel.AutoSize = True
        Me.fullnameLabel.Location = New System.Drawing.Point(14, 81)
        Me.fullnameLabel.Name = "fullnameLabel"
        Me.fullnameLabel.Size = New System.Drawing.Size(54, 13)
        Me.fullnameLabel.TabIndex = 59
        Me.fullnameLabel.Text = "Full Name"
        '
        'addressTextBox
        '
        Me.addressTextBox.Location = New System.Drawing.Point(108, 120)
        Me.addressTextBox.Name = "addressTextBox"
        Me.addressTextBox.Size = New System.Drawing.Size(121, 20)
        Me.addressTextBox.TabIndex = 62
        '
        'addressLabel
        '
        Me.addressLabel.AutoSize = True
        Me.addressLabel.Location = New System.Drawing.Point(14, 123)
        Me.addressLabel.Name = "addressLabel"
        Me.addressLabel.Size = New System.Drawing.Size(45, 13)
        Me.addressLabel.TabIndex = 61
        Me.addressLabel.Text = "Address"
        '
        'estdTextBox
        '
        Me.estdTextBox.Location = New System.Drawing.Point(108, 160)
        Me.estdTextBox.Name = "estdTextBox"
        Me.estdTextBox.Size = New System.Drawing.Size(121, 20)
        Me.estdTextBox.TabIndex = 64
        '
        'estdLabel
        '
        Me.estdLabel.AutoSize = True
        Me.estdLabel.Location = New System.Drawing.Point(14, 163)
        Me.estdLabel.Name = "estdLabel"
        Me.estdLabel.Size = New System.Drawing.Size(59, 13)
        Me.estdLabel.TabIndex = 63
        Me.estdLabel.Text = "ESTD (BS)"
        '
        'phoneTextBox
        '
        Me.phoneTextBox.Location = New System.Drawing.Point(341, 36)
        Me.phoneTextBox.Name = "phoneTextBox"
        Me.phoneTextBox.Size = New System.Drawing.Size(121, 20)
        Me.phoneTextBox.TabIndex = 66
        '
        'phoneLabel
        '
        Me.phoneLabel.AutoSize = True
        Me.phoneLabel.Location = New System.Drawing.Point(247, 39)
        Me.phoneLabel.Name = "phoneLabel"
        Me.phoneLabel.Size = New System.Drawing.Size(38, 13)
        Me.phoneLabel.TabIndex = 65
        Me.phoneLabel.Text = "Phone"
        '
        'emailTextBox
        '
        Me.emailTextBox.Location = New System.Drawing.Point(341, 78)
        Me.emailTextBox.Name = "emailTextBox"
        Me.emailTextBox.Size = New System.Drawing.Size(121, 20)
        Me.emailTextBox.TabIndex = 68
        '
        'emailLabel
        '
        Me.emailLabel.AutoSize = True
        Me.emailLabel.Location = New System.Drawing.Point(247, 81)
        Me.emailLabel.Name = "emailLabel"
        Me.emailLabel.Size = New System.Drawing.Size(32, 13)
        Me.emailLabel.TabIndex = 67
        Me.emailLabel.Text = "Email"
        '
        'websiteTextBox
        '
        Me.websiteTextBox.Location = New System.Drawing.Point(341, 121)
        Me.websiteTextBox.Name = "websiteTextBox"
        Me.websiteTextBox.Size = New System.Drawing.Size(121, 20)
        Me.websiteTextBox.TabIndex = 70
        '
        'websiteLabel
        '
        Me.websiteLabel.AutoSize = True
        Me.websiteLabel.Location = New System.Drawing.Point(247, 124)
        Me.websiteLabel.Name = "websiteLabel"
        Me.websiteLabel.Size = New System.Drawing.Size(46, 13)
        Me.websiteLabel.TabIndex = 69
        Me.websiteLabel.Text = "Website"
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(292, 326)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(75, 23)
        Me.saveBtn.TabIndex = 72
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(384, 326)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 73
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'descLabel
        '
        Me.descLabel.AutoSize = True
        Me.descLabel.Location = New System.Drawing.Point(13, 201)
        Me.descLabel.Name = "descLabel"
        Me.descLabel.Size = New System.Drawing.Size(60, 13)
        Me.descLabel.TabIndex = 74
        Me.descLabel.Text = "Description"
        '
        'descTextBox
        '
        Me.descTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.descTextBox.Location = New System.Drawing.Point(108, 198)
        Me.descTextBox.MaxLength = 255
        Me.descTextBox.Name = "descTextBox"
        Me.descTextBox.Size = New System.Drawing.Size(354, 96)
        Me.descTextBox.TabIndex = 71
        Me.descTextBox.Text = ""
        '
        'addSchoolForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 377)
        Me.Controls.Add(Me.descTextBox)
        Me.Controls.Add(Me.descLabel)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.websiteTextBox)
        Me.Controls.Add(Me.websiteLabel)
        Me.Controls.Add(Me.emailTextBox)
        Me.Controls.Add(Me.emailLabel)
        Me.Controls.Add(Me.phoneTextBox)
        Me.Controls.Add(Me.phoneLabel)
        Me.Controls.Add(Me.estdTextBox)
        Me.Controls.Add(Me.estdLabel)
        Me.Controls.Add(Me.addressTextBox)
        Me.Controls.Add(Me.addressLabel)
        Me.Controls.Add(Me.fullnameTextBox)
        Me.Controls.Add(Me.fullnameLabel)
        Me.Controls.Add(Me.shortnameTextBox)
        Me.Controls.Add(Me.shortnameLabel)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "addSchoolForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "addSchoolForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents shortnameTextBox As TextBox
    Friend WithEvents shortnameLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents fullnameTextBox As TextBox
    Friend WithEvents fullnameLabel As Label
    Friend WithEvents addressTextBox As TextBox
    Friend WithEvents addressLabel As Label
    Friend WithEvents estdTextBox As TextBox
    Friend WithEvents estdLabel As Label
    Friend WithEvents phoneTextBox As TextBox
    Friend WithEvents phoneLabel As Label
    Friend WithEvents emailTextBox As TextBox
    Friend WithEvents emailLabel As Label
    Friend WithEvents websiteTextBox As TextBox
    Friend WithEvents websiteLabel As Label
    Friend WithEvents saveBtn As Button
    Friend WithEvents cancelBtn As Button
    Friend WithEvents descLabel As Label
    Friend WithEvents descTextBox As RichTextBox
End Class
