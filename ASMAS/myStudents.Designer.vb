<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class myStudents
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
        Me.myStudentsListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.myStudentsContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpgradeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.refreshBtn = New System.Windows.Forms.Button()
        Me.sortBtn = New System.Windows.Forms.Button()
        Me.myStudentsContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'myStudentsListView
        '
        Me.myStudentsListView.AllowColumnReorder = True
        Me.myStudentsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.myStudentsListView.CausesValidation = False
        Me.myStudentsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.myStudentsListView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.myStudentsListView.FullRowSelect = True
        Me.myStudentsListView.GridLines = True
        Me.myStudentsListView.Location = New System.Drawing.Point(0, 75)
        Me.myStudentsListView.Name = "myStudentsListView"
        Me.myStudentsListView.Size = New System.Drawing.Size(1008, 654)
        Me.myStudentsListView.TabIndex = 166
        Me.myStudentsListView.UseCompatibleStateImageBehavior = False
        Me.myStudentsListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 112
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 294
        '
        'titleLabel
        '
        Me.titleLabel.AutoSize = True
        Me.titleLabel.Font = New System.Drawing.Font("Nexa Light", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(12, 14)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(100, 16)
        Me.titleLabel.TabIndex = 167
        Me.titleLabel.Text = "Student Details"
        '
        'myStudentsContextMenu
        '
        Me.myStudentsContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.EditToolStripMenuItem, Me.UpgradeToolStripMenuItem})
        Me.myStudentsContextMenu.Name = "searchResultContextMenu"
        Me.myStudentsContextMenu.Size = New System.Drawing.Size(175, 92)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.DeleteToolStripMenuItem.Text = "Remove from class"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UpgradeToolStripMenuItem
        '
        Me.UpgradeToolStripMenuItem.Name = "UpgradeToolStripMenuItem"
        Me.UpgradeToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.UpgradeToolStripMenuItem.Text = "Promote"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(760, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 13)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Tip: You can select multiple students to promote."
        '
        'refreshBtn
        '
        Me.refreshBtn.Location = New System.Drawing.Point(145, 14)
        Me.refreshBtn.Name = "refreshBtn"
        Me.refreshBtn.Size = New System.Drawing.Size(75, 23)
        Me.refreshBtn.TabIndex = 169
        Me.refreshBtn.Text = "Refresh"
        Me.refreshBtn.UseVisualStyleBackColor = True
        '
        'sortBtn
        '
        Me.sortBtn.Location = New System.Drawing.Point(248, 14)
        Me.sortBtn.Name = "sortBtn"
        Me.sortBtn.Size = New System.Drawing.Size(125, 23)
        Me.sortBtn.TabIndex = 170
        Me.sortBtn.Text = "Sort by SendUp Rank"
        Me.sortBtn.UseVisualStyleBackColor = True
        '
        'myStudents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.sortBtn)
        Me.Controls.Add(Me.refreshBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.myStudentsListView)
        Me.Name = "myStudents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "My Students"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.myStudentsContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents myStudentsListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents titleLabel As Label
    Friend WithEvents myStudentsContextMenu As ContextMenuStrip
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpgradeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents refreshBtn As Button
    Friend WithEvents sortBtn As Button
End Class
