<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HomeForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.currentUserLabel = New System.Windows.Forms.Label()
        Me.searchBtn = New System.Windows.Forms.Button()
        Me.viewDBBtn = New System.Windows.Forms.Button()
        Me.addSchoolBtn = New System.Windows.Forms.Button()
        Me.addYearBtn = New System.Windows.Forms.Button()
        Me.addStudentBtn = New System.Windows.Forms.Button()
        Me.addUserBtn = New System.Windows.Forms.Button()
        Me.addClassBtn = New System.Windows.Forms.Button()
        Me.viewMyClassesBtn = New System.Windows.Forms.Button()
        Me.viewResultBtn = New System.Windows.Forms.Button()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.menuStrip = New System.Windows.Forms.MenuStrip()
        Me.AdminToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportDatabaseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'currentUserLabel
        '
        Me.currentUserLabel.AutoSize = True
        Me.currentUserLabel.Location = New System.Drawing.Point(133, 32)
        Me.currentUserLabel.Name = "currentUserLabel"
        Me.currentUserLabel.Size = New System.Drawing.Size(77, 13)
        Me.currentUserLabel.TabIndex = 0
        Me.currentUserLabel.Text = "Logged in as : "
        Me.currentUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'searchBtn
        '
        Me.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.HelpProvider.SetHelpKeyword(Me.searchBtn, "Search class or students")
        Me.HelpProvider.SetHelpNavigator(Me.searchBtn, System.Windows.Forms.HelpNavigator.Index)
        Me.HelpProvider.SetHelpString(Me.searchBtn, "search")
        Me.searchBtn.Location = New System.Drawing.Point(77, 51)
        Me.searchBtn.Name = "searchBtn"
        Me.HelpProvider.SetShowHelp(Me.searchBtn, True)
        Me.searchBtn.Size = New System.Drawing.Size(195, 43)
        Me.searchBtn.TabIndex = 1
        Me.searchBtn.Text = "Search"
        Me.searchBtn.UseVisualStyleBackColor = True
        '
        'viewDBBtn
        '
        Me.viewDBBtn.Location = New System.Drawing.Point(77, 112)
        Me.viewDBBtn.Name = "viewDBBtn"
        Me.viewDBBtn.Size = New System.Drawing.Size(195, 43)
        Me.viewDBBtn.TabIndex = 2
        Me.viewDBBtn.Text = "View Student Database"
        Me.viewDBBtn.UseVisualStyleBackColor = True
        '
        'addSchoolBtn
        '
        Me.addSchoolBtn.Location = New System.Drawing.Point(77, 173)
        Me.addSchoolBtn.Name = "addSchoolBtn"
        Me.addSchoolBtn.Size = New System.Drawing.Size(195, 43)
        Me.addSchoolBtn.TabIndex = 3
        Me.addSchoolBtn.Text = "Add School"
        Me.addSchoolBtn.UseVisualStyleBackColor = True
        '
        'addYearBtn
        '
        Me.addYearBtn.Location = New System.Drawing.Point(77, 233)
        Me.addYearBtn.Name = "addYearBtn"
        Me.addYearBtn.Size = New System.Drawing.Size(195, 43)
        Me.addYearBtn.TabIndex = 4
        Me.addYearBtn.Text = "Add Year"
        Me.addYearBtn.UseVisualStyleBackColor = True
        '
        'addStudentBtn
        '
        Me.addStudentBtn.Location = New System.Drawing.Point(77, 293)
        Me.addStudentBtn.Name = "addStudentBtn"
        Me.addStudentBtn.Size = New System.Drawing.Size(195, 43)
        Me.addStudentBtn.TabIndex = 5
        Me.addStudentBtn.Text = "Add Student"
        Me.addStudentBtn.UseVisualStyleBackColor = True
        '
        'addUserBtn
        '
        Me.addUserBtn.Location = New System.Drawing.Point(77, 408)
        Me.addUserBtn.Name = "addUserBtn"
        Me.addUserBtn.Size = New System.Drawing.Size(195, 43)
        Me.addUserBtn.TabIndex = 7
        Me.addUserBtn.Text = "Add User"
        Me.addUserBtn.UseVisualStyleBackColor = True
        '
        'addClassBtn
        '
        Me.addClassBtn.Location = New System.Drawing.Point(77, 352)
        Me.addClassBtn.Name = "addClassBtn"
        Me.addClassBtn.Size = New System.Drawing.Size(195, 43)
        Me.addClassBtn.TabIndex = 6
        Me.addClassBtn.Text = "Add Class"
        Me.addClassBtn.UseVisualStyleBackColor = True
        '
        'viewMyClassesBtn
        '
        Me.viewMyClassesBtn.Location = New System.Drawing.Point(77, 173)
        Me.viewMyClassesBtn.Name = "viewMyClassesBtn"
        Me.viewMyClassesBtn.Size = New System.Drawing.Size(195, 43)
        Me.viewMyClassesBtn.TabIndex = 3
        Me.viewMyClassesBtn.Text = "View My Classes"
        Me.viewMyClassesBtn.UseVisualStyleBackColor = True
        Me.viewMyClassesBtn.Visible = False
        '
        'viewResultBtn
        '
        Me.viewResultBtn.Location = New System.Drawing.Point(77, 467)
        Me.viewResultBtn.Name = "viewResultBtn"
        Me.viewResultBtn.Size = New System.Drawing.Size(195, 43)
        Me.viewResultBtn.TabIndex = 8
        Me.viewResultBtn.Text = "View Results"
        Me.viewResultBtn.UseVisualStyleBackColor = True
        '
        'menuStrip
        '
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Size = New System.Drawing.Size(340, 24)
        Me.menuStrip.TabIndex = 12
        Me.menuStrip.Text = "MenuStrip1"
        '
        'AdminToolsToolStripMenuItem
        '
        Me.AdminToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewUsersToolStripMenuItem, Me.ImportDatabaseToolStripMenuItem1})
        Me.AdminToolsToolStripMenuItem.Name = "AdminToolsToolStripMenuItem"
        Me.AdminToolsToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.AdminToolsToolStripMenuItem.Text = "Admin Tools"
        '
        'ViewUsersToolStripMenuItem
        '
        Me.ViewUsersToolStripMenuItem.Name = "ViewUsersToolStripMenuItem"
        Me.ViewUsersToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ViewUsersToolStripMenuItem.Text = "View users"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.SupportToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'SupportToolStripMenuItem
        '
        Me.SupportToolStripMenuItem.Name = "SupportToolStripMenuItem"
        Me.SupportToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SupportToolStripMenuItem.Text = "Support"
        '
        'ImportDatabaseToolStripMenuItem1
        '
        Me.ImportDatabaseToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.ImportDatabaseToolStripMenuItem1.Name = "ImportDatabaseToolStripMenuItem1"
        Me.ImportDatabaseToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ImportDatabaseToolStripMenuItem1.Text = "Database"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'HomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(340, 528)
        Me.Controls.Add(Me.viewResultBtn)
        Me.Controls.Add(Me.viewMyClassesBtn)
        Me.Controls.Add(Me.addClassBtn)
        Me.Controls.Add(Me.addUserBtn)
        Me.Controls.Add(Me.addStudentBtn)
        Me.Controls.Add(Me.addYearBtn)
        Me.Controls.Add(Me.addSchoolBtn)
        Me.Controls.Add(Me.viewDBBtn)
        Me.Controls.Add(Me.searchBtn)
        Me.Controls.Add(Me.currentUserLabel)
        Me.Controls.Add(Me.menuStrip)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "HomeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents currentUserLabel As Label
    Friend WithEvents searchBtn As Button
    Friend WithEvents viewDBBtn As Button
    Friend WithEvents addSchoolBtn As Button
    Friend WithEvents addYearBtn As Button
    Friend WithEvents addStudentBtn As Button
    Friend WithEvents addUserBtn As Button
    Friend WithEvents addClassBtn As Button
    Friend WithEvents viewMyClassesBtn As Button
    Friend WithEvents viewResultBtn As Button
    Friend WithEvents HelpProvider As HelpProvider
    Friend WithEvents menuStrip As MenuStrip
    Friend WithEvents AdminToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewUsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportDatabaseToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
End Class
