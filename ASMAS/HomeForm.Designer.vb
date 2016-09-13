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
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.menuStrip = New System.Windows.Forms.MenuStrip()
        Me.AdminToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportDatabaseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SchoolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MyClassesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.menuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'currentUserLabel
        '
        Me.currentUserLabel.AutoSize = True
        Me.currentUserLabel.BackColor = System.Drawing.Color.Coral
        Me.currentUserLabel.Font = New System.Drawing.Font("Bigmouth", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currentUserLabel.Location = New System.Drawing.Point(14, 226)
        Me.currentUserLabel.Name = "currentUserLabel"
        Me.currentUserLabel.Size = New System.Drawing.Size(232, 46)
        Me.currentUserLabel.TabIndex = 0
        Me.currentUserLabel.Text = "Username"
        Me.currentUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'menuStrip
        '
        Me.menuStrip.BackColor = System.Drawing.SystemColors.Control
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolsToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.SearchToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Size = New System.Drawing.Size(477, 24)
        Me.menuStrip.TabIndex = 12
        Me.menuStrip.Text = "MenuStrip1"
        '
        'AdminToolsToolStripMenuItem
        '
        Me.AdminToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewUsersToolStripMenuItem, Me.ImportDatabaseToolStripMenuItem1, Me.AddToolStripMenuItem})
        Me.AdminToolsToolStripMenuItem.Name = "AdminToolsToolStripMenuItem"
        Me.AdminToolsToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.AdminToolsToolStripMenuItem.Text = "Admin Tools"
        '
        'ViewUsersToolStripMenuItem
        '
        Me.ViewUsersToolStripMenuItem.Name = "ViewUsersToolStripMenuItem"
        Me.ViewUsersToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.ViewUsersToolStripMenuItem.Text = "View users"
        '
        'ImportDatabaseToolStripMenuItem1
        '
        Me.ImportDatabaseToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.ImportDatabaseToolStripMenuItem1.Name = "ImportDatabaseToolStripMenuItem1"
        Me.ImportDatabaseToolStripMenuItem1.Size = New System.Drawing.Size(129, 22)
        Me.ImportDatabaseToolStripMenuItem1.Text = "Database"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.YearToolStripMenuItem, Me.SchoolToolStripMenuItem, Me.ClassToolStripMenuItem, Me.UserToolStripMenuItem, Me.StudentToolStripMenuItem})
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'YearToolStripMenuItem
        '
        Me.YearToolStripMenuItem.Name = "YearToolStripMenuItem"
        Me.YearToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.YearToolStripMenuItem.Text = "Year"
        '
        'SchoolToolStripMenuItem
        '
        Me.SchoolToolStripMenuItem.Name = "SchoolToolStripMenuItem"
        Me.SchoolToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.SchoolToolStripMenuItem.Text = "School"
        '
        'ClassToolStripMenuItem
        '
        Me.ClassToolStripMenuItem.Name = "ClassToolStripMenuItem"
        Me.ClassToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.ClassToolStripMenuItem.Text = "Class"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'StudentToolStripMenuItem
        '
        Me.StudentToolStripMenuItem.Name = "StudentToolStripMenuItem"
        Me.StudentToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.StudentToolStripMenuItem.Text = "Student"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MyClassesToolStripMenuItem, Me.StudentDatabaseToolStripMenuItem, Me.ResultsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'MyClassesToolStripMenuItem
        '
        Me.MyClassesToolStripMenuItem.Name = "MyClassesToolStripMenuItem"
        Me.MyClassesToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.MyClassesToolStripMenuItem.Text = "My Classes"
        '
        'StudentDatabaseToolStripMenuItem
        '
        Me.StudentDatabaseToolStripMenuItem.Name = "StudentDatabaseToolStripMenuItem"
        Me.StudentDatabaseToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.StudentDatabaseToolStripMenuItem.Text = "Student Database"
        '
        'ResultsToolStripMenuItem
        '
        Me.ResultsToolStripMenuItem.Name = "ResultsToolStripMenuItem"
        Me.ResultsToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ResultsToolStripMenuItem.Text = "Results"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.SearchToolStripMenuItem.Text = "Search"
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
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'SupportToolStripMenuItem
        '
        Me.SupportToolStripMenuItem.Name = "SupportToolStripMenuItem"
        Me.SupportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SupportToolStripMenuItem.Text = "Support"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 31)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "WELCOME"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HomeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.ASMAS.My.Resources.Resources.FB_IMG_1459356927089
        Me.ClientSize = New System.Drawing.Size(477, 308)
        Me.Controls.Add(Me.Label1)
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
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents YearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SchoolToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MyClassesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
End Class
