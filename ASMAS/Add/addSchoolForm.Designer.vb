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
        Me.filepathTextBox = New System.Windows.Forms.TextBox()
        Me.browsePhotoBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.editInfoLabel = New System.Windows.Forms.Label()
        Me.schoolLogo = New System.Windows.Forms.PictureBox()
        CType(Me.schoolLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'shortnameTextBox
        '
        Me.shortnameTextBox.Location = New System.Drawing.Point(116, 56)
        Me.shortnameTextBox.Name = "shortnameTextBox"
        Me.shortnameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.shortnameTextBox.TabIndex = 1
        '
        'shortnameLabel
        '
        Me.shortnameLabel.AutoSize = True
        Me.shortnameLabel.Location = New System.Drawing.Point(22, 59)
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
        Me.fullnameTextBox.Location = New System.Drawing.Point(116, 98)
        Me.fullnameTextBox.Name = "fullnameTextBox"
        Me.fullnameTextBox.Size = New System.Drawing.Size(121, 20)
        Me.fullnameTextBox.TabIndex = 3
        '
        'fullnameLabel
        '
        Me.fullnameLabel.AutoSize = True
        Me.fullnameLabel.Location = New System.Drawing.Point(22, 101)
        Me.fullnameLabel.Name = "fullnameLabel"
        Me.fullnameLabel.Size = New System.Drawing.Size(54, 13)
        Me.fullnameLabel.TabIndex = 59
        Me.fullnameLabel.Text = "Full Name"
        '
        'addressTextBox
        '
        Me.addressTextBox.Location = New System.Drawing.Point(116, 140)
        Me.addressTextBox.Name = "addressTextBox"
        Me.addressTextBox.Size = New System.Drawing.Size(121, 20)
        Me.addressTextBox.TabIndex = 5
        '
        'addressLabel
        '
        Me.addressLabel.AutoSize = True
        Me.addressLabel.Location = New System.Drawing.Point(22, 143)
        Me.addressLabel.Name = "addressLabel"
        Me.addressLabel.Size = New System.Drawing.Size(45, 13)
        Me.addressLabel.TabIndex = 61
        Me.addressLabel.Text = "Address"
        '
        'estdTextBox
        '
        Me.estdTextBox.Location = New System.Drawing.Point(116, 180)
        Me.estdTextBox.Name = "estdTextBox"
        Me.estdTextBox.Size = New System.Drawing.Size(121, 20)
        Me.estdTextBox.TabIndex = 7
        '
        'estdLabel
        '
        Me.estdLabel.AutoSize = True
        Me.estdLabel.Location = New System.Drawing.Point(22, 183)
        Me.estdLabel.Name = "estdLabel"
        Me.estdLabel.Size = New System.Drawing.Size(59, 13)
        Me.estdLabel.TabIndex = 63
        Me.estdLabel.Text = "ESTD (BS)"
        '
        'phoneTextBox
        '
        Me.phoneTextBox.Location = New System.Drawing.Point(349, 56)
        Me.phoneTextBox.Name = "phoneTextBox"
        Me.phoneTextBox.Size = New System.Drawing.Size(121, 20)
        Me.phoneTextBox.TabIndex = 2
        '
        'phoneLabel
        '
        Me.phoneLabel.AutoSize = True
        Me.phoneLabel.Location = New System.Drawing.Point(255, 59)
        Me.phoneLabel.Name = "phoneLabel"
        Me.phoneLabel.Size = New System.Drawing.Size(38, 13)
        Me.phoneLabel.TabIndex = 65
        Me.phoneLabel.Text = "Phone"
        '
        'emailTextBox
        '
        Me.emailTextBox.Location = New System.Drawing.Point(349, 98)
        Me.emailTextBox.Name = "emailTextBox"
        Me.emailTextBox.Size = New System.Drawing.Size(121, 20)
        Me.emailTextBox.TabIndex = 4
        '
        'emailLabel
        '
        Me.emailLabel.AutoSize = True
        Me.emailLabel.Location = New System.Drawing.Point(255, 101)
        Me.emailLabel.Name = "emailLabel"
        Me.emailLabel.Size = New System.Drawing.Size(32, 13)
        Me.emailLabel.TabIndex = 67
        Me.emailLabel.Text = "Email"
        '
        'websiteTextBox
        '
        Me.websiteTextBox.Location = New System.Drawing.Point(349, 141)
        Me.websiteTextBox.Name = "websiteTextBox"
        Me.websiteTextBox.Size = New System.Drawing.Size(121, 20)
        Me.websiteTextBox.TabIndex = 6
        '
        'websiteLabel
        '
        Me.websiteLabel.AutoSize = True
        Me.websiteLabel.Location = New System.Drawing.Point(255, 144)
        Me.websiteLabel.Name = "websiteLabel"
        Me.websiteLabel.Size = New System.Drawing.Size(46, 13)
        Me.websiteLabel.TabIndex = 69
        Me.websiteLabel.Text = "Website"
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(304, 495)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(75, 23)
        Me.saveBtn.TabIndex = 9
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(396, 495)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 10
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'descLabel
        '
        Me.descLabel.AutoSize = True
        Me.descLabel.Location = New System.Drawing.Point(22, 383)
        Me.descLabel.Name = "descLabel"
        Me.descLabel.Size = New System.Drawing.Size(60, 13)
        Me.descLabel.TabIndex = 74
        Me.descLabel.Text = "Description"
        '
        'descTextBox
        '
        Me.descTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.descTextBox.Location = New System.Drawing.Point(117, 380)
        Me.descTextBox.MaxLength = 255
        Me.descTextBox.Name = "descTextBox"
        Me.descTextBox.Size = New System.Drawing.Size(354, 96)
        Me.descTextBox.TabIndex = 9
        Me.descTextBox.Text = ""
        '
        'filepathTextBox
        '
        Me.filepathTextBox.Location = New System.Drawing.Point(162, 261)
        Me.filepathTextBox.Name = "filepathTextBox"
        Me.filepathTextBox.Size = New System.Drawing.Size(311, 20)
        Me.filepathTextBox.TabIndex = 92
        '
        'browsePhotoBtn
        '
        Me.browsePhotoBtn.Location = New System.Drawing.Point(162, 232)
        Me.browsePhotoBtn.Name = "browsePhotoBtn"
        Me.browsePhotoBtn.Size = New System.Drawing.Size(75, 23)
        Me.browsePhotoBtn.TabIndex = 8
        Me.browsePhotoBtn.Text = "Browse"
        Me.browsePhotoBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "School Logo"
        '
        'editInfoLabel
        '
        Me.editInfoLabel.AutoSize = True
        Me.editInfoLabel.ForeColor = System.Drawing.Color.Maroon
        Me.editInfoLabel.Location = New System.Drawing.Point(22, 35)
        Me.editInfoLabel.Name = "editInfoLabel"
        Me.editInfoLabel.Size = New System.Drawing.Size(305, 13)
        Me.editInfoLabel.TabIndex = 94
        Me.editInfoLabel.Text = "* Please enter the SHORT NAME carefully. You can't edit later."
        '
        'schoolLogo
        '
        Me.schoolLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.schoolLogo.Location = New System.Drawing.Point(21, 232)
        Me.schoolLogo.Name = "schoolLogo"
        Me.schoolLogo.Size = New System.Drawing.Size(124, 130)
        Me.schoolLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.schoolLogo.TabIndex = 90
        Me.schoolLogo.TabStop = False
        '
        'addSchoolForm
        '
        Me.AcceptButton = Me.saveBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 528)
        Me.Controls.Add(Me.editInfoLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.filepathTextBox)
        Me.Controls.Add(Me.browsePhotoBtn)
        Me.Controls.Add(Me.schoolLogo)
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
        Me.Text = "Add School"
        CType(Me.schoolLogo, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents filepathTextBox As TextBox
    Friend WithEvents browsePhotoBtn As Button
    Friend WithEvents schoolLogo As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents editInfoLabel As Label
End Class
