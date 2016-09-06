<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addStudentToClassForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addStudentToClassForm))
        Me.searchBtn = New System.Windows.Forms.Button()
        Me.searchKeyword = New System.Windows.Forms.TextBox()
        Me.searchByLabel = New System.Windows.Forms.Label()
        Me.searchKey = New System.Windows.Forms.ComboBox()
        Me.studentPhoto = New System.Windows.Forms.PictureBox()
        Me.classIDLabel = New System.Windows.Forms.Label()
        Me.searchResultListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fullnameLabel = New System.Windows.Forms.Label()
        Me.searchResultContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.addStudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.studentPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.searchResultContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'searchBtn
        '
        Me.searchBtn.Location = New System.Drawing.Point(294, 36)
        Me.searchBtn.Name = "searchBtn"
        Me.searchBtn.Size = New System.Drawing.Size(75, 23)
        Me.searchBtn.TabIndex = 2
        Me.searchBtn.Text = "Search"
        Me.searchBtn.UseVisualStyleBackColor = True
        '
        'searchKeyword
        '
        Me.searchKeyword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.searchKeyword.Location = New System.Drawing.Point(175, 38)
        Me.searchKeyword.Name = "searchKeyword"
        Me.searchKeyword.Size = New System.Drawing.Size(104, 20)
        Me.searchKeyword.TabIndex = 1
        '
        'searchByLabel
        '
        Me.searchByLabel.AutoSize = True
        Me.searchByLabel.Location = New System.Drawing.Point(8, 41)
        Me.searchByLabel.Name = "searchByLabel"
        Me.searchByLabel.Size = New System.Drawing.Size(55, 13)
        Me.searchByLabel.TabIndex = 7
        Me.searchByLabel.Text = "Search by"
        '
        'searchKey
        '
        Me.searchKey.FormattingEnabled = True
        Me.searchKey.Items.AddRange(New Object() {"ID", "Name"})
        Me.searchKey.Location = New System.Drawing.Point(69, 38)
        Me.searchKey.Name = "searchKey"
        Me.searchKey.Size = New System.Drawing.Size(90, 21)
        Me.searchKey.TabIndex = 0
        '
        'studentPhoto
        '
        Me.studentPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.studentPhoto.InitialImage = CType(resources.GetObject("studentPhoto.InitialImage"), System.Drawing.Image)
        Me.studentPhoto.Location = New System.Drawing.Point(604, 83)
        Me.studentPhoto.Name = "studentPhoto"
        Me.studentPhoto.Size = New System.Drawing.Size(174, 159)
        Me.studentPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.studentPhoto.TabIndex = 158
        Me.studentPhoto.TabStop = False
        '
        'classIDLabel
        '
        Me.classIDLabel.AutoSize = True
        Me.classIDLabel.Location = New System.Drawing.Point(13, 13)
        Me.classIDLabel.Name = "classIDLabel"
        Me.classIDLabel.Size = New System.Drawing.Size(46, 13)
        Me.classIDLabel.TabIndex = 163
        Me.classIDLabel.Text = "Class ID"
        '
        'searchResultListView
        '
        Me.searchResultListView.AllowColumnReorder = True
        Me.searchResultListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.searchResultListView.CausesValidation = False
        Me.searchResultListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.searchResultListView.FullRowSelect = True
        Me.searchResultListView.GridLines = True
        Me.searchResultListView.Location = New System.Drawing.Point(12, 83)
        Me.searchResultListView.MultiSelect = False
        Me.searchResultListView.Name = "searchResultListView"
        Me.searchResultListView.Size = New System.Drawing.Size(574, 377)
        Me.searchResultListView.TabIndex = 164
        Me.searchResultListView.UseCompatibleStateImageBehavior = False
        Me.searchResultListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 112
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 294
        '
        'fullnameLabel
        '
        Me.fullnameLabel.AutoSize = True
        Me.fullnameLabel.Location = New System.Drawing.Point(604, 259)
        Me.fullnameLabel.Name = "fullnameLabel"
        Me.fullnameLabel.Size = New System.Drawing.Size(39, 13)
        Me.fullnameLabel.TabIndex = 165
        Me.fullnameLabel.Text = "Label1"
        '
        'searchResultContextMenu
        '
        Me.searchResultContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.addStudentToolStripMenuItem})
        Me.searchResultContextMenu.Name = "searchResultContextMenu"
        Me.searchResultContextMenu.Size = New System.Drawing.Size(97, 26)
        '
        'addStudentToolStripMenuItem
        '
        Me.addStudentToolStripMenuItem.Name = "addStudentToolStripMenuItem"
        Me.addStudentToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.addStudentToolStripMenuItem.Text = "Add"
        '
        'addStudentToClassForm
        '
        Me.AcceptButton = Me.searchBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 470)
        Me.Controls.Add(Me.fullnameLabel)
        Me.Controls.Add(Me.searchResultListView)
        Me.Controls.Add(Me.classIDLabel)
        Me.Controls.Add(Me.studentPhoto)
        Me.Controls.Add(Me.searchBtn)
        Me.Controls.Add(Me.searchKeyword)
        Me.Controls.Add(Me.searchByLabel)
        Me.Controls.Add(Me.searchKey)
        Me.MaximizeBox = False
        Me.Name = "addStudentToClassForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add student"
        CType(Me.studentPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.searchResultContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents searchBtn As Button
    Friend WithEvents searchKeyword As TextBox
    Friend WithEvents searchByLabel As Label
    Friend WithEvents searchKey As ComboBox
    Friend WithEvents studentPhoto As PictureBox
    Friend WithEvents classIDLabel As Label
    Friend WithEvents searchResultListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents fullnameLabel As Label
    Friend WithEvents searchResultContextMenu As ContextMenuStrip
    Friend WithEvents addStudentToolStripMenuItem As ToolStripMenuItem
End Class
