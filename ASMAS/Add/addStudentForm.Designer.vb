﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addStudentForm
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
        Me.studentPhoto = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.schoolCombo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.yearTextBox = New System.Windows.Forms.TextBox()
        Me.fnameTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mnameTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lnameTextBox = New System.Windows.Forms.TextBox()
        Me.lnameLabel = New System.Windows.Forms.Label()
        Me.genderCombo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dobTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.guardianTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.motherTextBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.fatherTextBox = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pAddTextBox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tAddTextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.emailTextBox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.phoneTextBox = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.browsePhotoBtn = New System.Windows.Forms.Button()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.infoTextBox = New System.Windows.Forms.RichTextBox()
        Me.filepathTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.classCombo = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.studentPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'studentPhoto
        '
        Me.studentPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.studentPhoto.Location = New System.Drawing.Point(24, 52)
        Me.studentPhoto.Name = "studentPhoto"
        Me.studentPhoto.Size = New System.Drawing.Size(198, 188)
        Me.studentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.studentPhoto.TabIndex = 0
        Me.studentPhoto.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Nexa Light", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 16)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Add Student"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "School"
        '
        'schoolCombo
        '
        Me.schoolCombo.FormattingEnabled = True
        Me.schoolCombo.Location = New System.Drawing.Point(300, 42)
        Me.schoolCombo.Name = "schoolCombo"
        Me.schoolCombo.Size = New System.Drawing.Size(100, 21)
        Me.schoolCombo.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(420, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Adm. year"
        '
        'yearTextBox
        '
        Me.yearTextBox.Location = New System.Drawing.Point(479, 44)
        Me.yearTextBox.Name = "yearTextBox"
        Me.yearTextBox.Size = New System.Drawing.Size(100, 20)
        Me.yearTextBox.TabIndex = 1
        '
        'fnameTextBox
        '
        Me.fnameTextBox.Location = New System.Drawing.Point(300, 83)
        Me.fnameTextBox.Name = "fnameTextBox"
        Me.fnameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.fnameTextBox.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(244, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "First name"
        '
        'mnameTextBox
        '
        Me.mnameTextBox.Location = New System.Drawing.Point(479, 83)
        Me.mnameTextBox.Name = "mnameTextBox"
        Me.mnameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.mnameTextBox.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(422, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Middle"
        '
        'lnameTextBox
        '
        Me.lnameTextBox.Location = New System.Drawing.Point(643, 83)
        Me.lnameTextBox.Name = "lnameTextBox"
        Me.lnameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.lnameTextBox.TabIndex = 4
        '
        'lnameLabel
        '
        Me.lnameLabel.AutoSize = True
        Me.lnameLabel.Location = New System.Drawing.Point(592, 90)
        Me.lnameLabel.Name = "lnameLabel"
        Me.lnameLabel.Size = New System.Drawing.Size(27, 13)
        Me.lnameLabel.TabIndex = 64
        Me.lnameLabel.Text = "Last"
        '
        'genderCombo
        '
        Me.genderCombo.FormattingEnabled = True
        Me.genderCombo.Items.AddRange(New Object() {"Male", "Female", "Others"})
        Me.genderCombo.Location = New System.Drawing.Point(300, 121)
        Me.genderCombo.Name = "genderCombo"
        Me.genderCombo.Size = New System.Drawing.Size(100, 21)
        Me.genderCombo.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(244, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Gender"
        '
        'dobTextBox
        '
        Me.dobTextBox.Location = New System.Drawing.Point(479, 121)
        Me.dobTextBox.Name = "dobTextBox"
        Me.dobTextBox.Size = New System.Drawing.Size(100, 20)
        Me.dobTextBox.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(420, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "DOB (BS)"
        '
        'guardianTextBox
        '
        Me.guardianTextBox.Location = New System.Drawing.Point(643, 162)
        Me.guardianTextBox.Name = "guardianTextBox"
        Me.guardianTextBox.Size = New System.Drawing.Size(100, 20)
        Me.guardianTextBox.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(592, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 74
        Me.Label9.Text = "Guardian"
        '
        'motherTextBox
        '
        Me.motherTextBox.Location = New System.Drawing.Point(479, 162)
        Me.motherTextBox.Name = "motherTextBox"
        Me.motherTextBox.Size = New System.Drawing.Size(100, 20)
        Me.motherTextBox.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(420, 169)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 72
        Me.Label10.Text = "Mother"
        '
        'fatherTextBox
        '
        Me.fatherTextBox.Location = New System.Drawing.Point(300, 162)
        Me.fatherTextBox.Name = "fatherTextBox"
        Me.fatherTextBox.Size = New System.Drawing.Size(100, 20)
        Me.fatherTextBox.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(244, 169)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "Father"
        '
        'pAddTextBox
        '
        Me.pAddTextBox.Location = New System.Drawing.Point(229, 28)
        Me.pAddTextBox.Name = "pAddTextBox"
        Me.pAddTextBox.Size = New System.Drawing.Size(100, 20)
        Me.pAddTextBox.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(170, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Perm."
        '
        'tAddTextBox
        '
        Me.tAddTextBox.Location = New System.Drawing.Point(50, 28)
        Me.tAddTextBox.Name = "tAddTextBox"
        Me.tAddTextBox.Size = New System.Drawing.Size(100, 20)
        Me.tAddTextBox.TabIndex = 12
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Temp."
        '
        'emailTextBox
        '
        Me.emailTextBox.Location = New System.Drawing.Point(476, 283)
        Me.emailTextBox.Name = "emailTextBox"
        Me.emailTextBox.Size = New System.Drawing.Size(100, 20)
        Me.emailTextBox.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(420, 290)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 13)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Email"
        '
        'phoneTextBox
        '
        Me.phoneTextBox.Location = New System.Drawing.Point(300, 283)
        Me.phoneTextBox.Name = "phoneTextBox"
        Me.phoneTextBox.Size = New System.Drawing.Size(100, 20)
        Me.phoneTextBox.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(244, 290)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 80
        Me.Label15.Text = "Phone"
        '
        'browsePhotoBtn
        '
        Me.browsePhotoBtn.Location = New System.Drawing.Point(24, 246)
        Me.browsePhotoBtn.Name = "browsePhotoBtn"
        Me.browsePhotoBtn.Size = New System.Drawing.Size(75, 23)
        Me.browsePhotoBtn.TabIndex = 18
        Me.browsePhotoBtn.Text = "Browse"
        Me.browsePhotoBtn.UseVisualStyleBackColor = True
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(577, 432)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(75, 23)
        Me.saveBtn.TabIndex = 19
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(668, 432)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 20
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(244, 327)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Other Information"
        '
        'infoTextBox
        '
        Me.infoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.infoTextBox.Location = New System.Drawing.Point(247, 343)
        Me.infoTextBox.Name = "infoTextBox"
        Me.infoTextBox.Size = New System.Drawing.Size(496, 71)
        Me.infoTextBox.TabIndex = 17
        Me.infoTextBox.Text = ""
        '
        'filepathTextBox
        '
        Me.filepathTextBox.Location = New System.Drawing.Point(24, 276)
        Me.filepathTextBox.Name = "filepathTextBox"
        Me.filepathTextBox.Size = New System.Drawing.Size(198, 20)
        Me.filepathTextBox.TabIndex = 89
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tAddTextBox)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.pAddTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(247, 209)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 60)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Address"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(27, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 91
        Me.Label16.Text = "Class"
        '
        'classCombo
        '
        Me.classCombo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.classCombo.FormattingEnabled = True
        Me.classCombo.Location = New System.Drawing.Point(78, 35)
        Me.classCombo.Name = "classCombo"
        Me.classCombo.Size = New System.Drawing.Size(100, 21)
        Me.classCombo.TabIndex = 19
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.classCombo)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(24, 327)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 87)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Assign to a class?"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 417)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(231, 13)
        Me.Label17.TabIndex = 90
        Me.Label17.Text = "You can leave this blank and assign class later."
        '
        'addStudentForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 478)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.filepathTextBox)
        Me.Controls.Add(Me.infoTextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.browsePhotoBtn)
        Me.Controls.Add(Me.emailTextBox)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.phoneTextBox)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.guardianTextBox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.motherTextBox)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.fatherTextBox)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dobTextBox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.genderCombo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lnameTextBox)
        Me.Controls.Add(Me.lnameLabel)
        Me.Controls.Add(Me.mnameTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.fnameTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.yearTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.schoolCombo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.studentPhoto)
        Me.MaximizeBox = False
        Me.Name = "addStudentForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Student"
        CType(Me.studentPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents studentPhoto As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents schoolCombo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents yearTextBox As TextBox
    Friend WithEvents fnameTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents mnameTextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lnameTextBox As TextBox
    Friend WithEvents lnameLabel As Label
    Friend WithEvents genderCombo As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dobTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents guardianTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents motherTextBox As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents fatherTextBox As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents pAddTextBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tAddTextBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents emailTextBox As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents phoneTextBox As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents browsePhotoBtn As Button
    Friend WithEvents saveBtn As Button
    Friend WithEvents cancelBtn As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents infoTextBox As RichTextBox
    Friend WithEvents filepathTextBox As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents classCombo As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label17 As Label
End Class
