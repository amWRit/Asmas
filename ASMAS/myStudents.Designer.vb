<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class myStudents
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
        Me.myStudentsListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.myStudentsContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.myStudentsListView.Location = New System.Drawing.Point(0, 134)
        Me.myStudentsListView.MultiSelect = False
        Me.myStudentsListView.Name = "myStudentsListView"
        Me.myStudentsListView.Size = New System.Drawing.Size(1008, 595)
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
        Me.myStudentsContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.myStudentsContextMenu.Name = "searchResultContextMenu"
        Me.myStudentsContextMenu.Size = New System.Drawing.Size(153, 92)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'myStudents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.myStudentsListView)
        Me.MaximizeBox = False
        Me.Name = "myStudents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "myStudents"
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
End Class
