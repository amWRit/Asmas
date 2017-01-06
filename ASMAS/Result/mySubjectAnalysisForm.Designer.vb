<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mySubjectAnalysisForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mySubjectAnalysisForm))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.exportBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.termCombo = New System.Windows.Forms.ComboBox()
        Me.subjectAnalysisListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.yearCombo = New System.Windows.Forms.ComboBox()
        Me.schoolLabel = New System.Windows.Forms.Label()
        Me.schoolName = New System.Windows.Forms.ComboBox()
        Me.viewBtn = New System.Windows.Forms.Button()
        Me.resultAnalysisContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentsUnderLOCOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.resultAnalysisContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(651, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "Export to excel"
        '
        'exportBtn
        '
        Me.exportBtn.BackgroundImage = CType(resources.GetObject("exportBtn.BackgroundImage"), System.Drawing.Image)
        Me.exportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.exportBtn.Enabled = False
        Me.exportBtn.Location = New System.Drawing.Point(654, 18)
        Me.exportBtn.Name = "exportBtn"
        Me.exportBtn.Size = New System.Drawing.Size(27, 23)
        Me.exportBtn.TabIndex = 190
        Me.exportBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(372, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 175
        Me.Label1.Text = "Terminal"
        '
        'termCombo
        '
        Me.termCombo.FormattingEnabled = True
        Me.termCombo.Items.AddRange(New Object() {"First", "Second", "Third", "SendUp"})
        Me.termCombo.Location = New System.Drawing.Point(425, 18)
        Me.termCombo.Name = "termCombo"
        Me.termCombo.Size = New System.Drawing.Size(121, 21)
        Me.termCombo.TabIndex = 172
        Me.termCombo.Text = "Choose terminal..."
        '
        'subjectAnalysisListView
        '
        Me.subjectAnalysisListView.AllowColumnReorder = True
        Me.subjectAnalysisListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.subjectAnalysisListView.CausesValidation = False
        Me.subjectAnalysisListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.subjectAnalysisListView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.subjectAnalysisListView.FullRowSelect = True
        Me.subjectAnalysisListView.GridLines = True
        Me.subjectAnalysisListView.Location = New System.Drawing.Point(0, 83)
        Me.subjectAnalysisListView.MultiSelect = False
        Me.subjectAnalysisListView.Name = "subjectAnalysisListView"
        Me.subjectAnalysisListView.Size = New System.Drawing.Size(1008, 646)
        Me.subjectAnalysisListView.TabIndex = 172
        Me.subjectAnalysisListView.UseCompatibleStateImageBehavior = False
        Me.subjectAnalysisListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 112
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 294
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(200, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "Year"
        '
        'yearCombo
        '
        Me.yearCombo.FormattingEnabled = True
        Me.yearCombo.Location = New System.Drawing.Point(235, 18)
        Me.yearCombo.Name = "yearCombo"
        Me.yearCombo.Size = New System.Drawing.Size(121, 21)
        Me.yearCombo.TabIndex = 171
        Me.yearCombo.Text = "Choose Year..."
        '
        'schoolLabel
        '
        Me.schoolLabel.AutoSize = True
        Me.schoolLabel.Location = New System.Drawing.Point(18, 21)
        Me.schoolLabel.Name = "schoolLabel"
        Me.schoolLabel.Size = New System.Drawing.Size(40, 13)
        Me.schoolLabel.TabIndex = 181
        Me.schoolLabel.Text = "School"
        '
        'schoolName
        '
        Me.schoolName.FormattingEnabled = True
        Me.schoolName.Location = New System.Drawing.Point(73, 18)
        Me.schoolName.Name = "schoolName"
        Me.schoolName.Size = New System.Drawing.Size(121, 21)
        Me.schoolName.TabIndex = 170
        Me.schoolName.Text = "Choose school..."
        '
        'viewBtn
        '
        Me.viewBtn.Location = New System.Drawing.Point(562, 16)
        Me.viewBtn.Name = "viewBtn"
        Me.viewBtn.Size = New System.Drawing.Size(75, 23)
        Me.viewBtn.TabIndex = 182
        Me.viewBtn.Text = "View"
        Me.viewBtn.UseVisualStyleBackColor = True
        '
        'resultAnalysisContextMenu
        '
        Me.resultAnalysisContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailsToolStripMenuItem})
        Me.resultAnalysisContextMenu.Name = "searchResultContextMenu"
        Me.resultAnalysisContextMenu.Size = New System.Drawing.Size(100, 26)
        '
        'ViewDetailsToolStripMenuItem
        '
        Me.ViewDetailsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudentsUnderLOCOSToolStripMenuItem})
        Me.ViewDetailsToolStripMenuItem.Name = "ViewDetailsToolStripMenuItem"
        Me.ViewDetailsToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ViewDetailsToolStripMenuItem.Text = "View"
        '
        'StudentsUnderLOCOSToolStripMenuItem
        '
        Me.StudentsUnderLOCOSToolStripMenuItem.Name = "StudentsUnderLOCOSToolStripMenuItem"
        Me.StudentsUnderLOCOSToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.StudentsUnderLOCOSToolStripMenuItem.Text = "Students under LOCOS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(518, 13)
        Me.Label4.TabIndex = 191
        Me.Label4.Text = "*In case any subject is missing, please ask respective class teachers to analyse " &
    "the result from their account."
        '
        'mySubjectAnalysisForm
        '
        Me.AcceptButton = Me.viewBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.viewBtn)
        Me.Controls.Add(Me.schoolLabel)
        Me.Controls.Add(Me.schoolName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.yearCombo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.exportBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.termCombo)
        Me.Controls.Add(Me.subjectAnalysisListView)
        Me.Name = "mySubjectAnalysisForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "mySubjectAnalysisForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.resultAnalysisContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents exportBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents termCombo As ComboBox
    Friend WithEvents subjectAnalysisListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label3 As Label
    Friend WithEvents yearCombo As ComboBox
    Friend WithEvents schoolLabel As Label
    Friend WithEvents schoolName As ComboBox
    Friend WithEvents viewBtn As Button
    Friend WithEvents resultAnalysisContextMenu As ContextMenuStrip
    Friend WithEvents ViewDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentsUnderLOCOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As Label
End Class
