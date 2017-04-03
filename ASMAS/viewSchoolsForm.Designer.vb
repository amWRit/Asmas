<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewSchoolsForm
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
        Me.refreshBtn = New System.Windows.Forms.Button()
        Me.schoolsListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.viewSchoolsContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.viewSchoolsContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'refreshBtn
        '
        Me.refreshBtn.Location = New System.Drawing.Point(12, 6)
        Me.refreshBtn.Name = "refreshBtn"
        Me.refreshBtn.Size = New System.Drawing.Size(75, 23)
        Me.refreshBtn.TabIndex = 172
        Me.refreshBtn.Text = "Refresh"
        Me.refreshBtn.UseVisualStyleBackColor = True
        '
        'schoolsListView
        '
        Me.schoolsListView.AllowColumnReorder = True
        Me.schoolsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.schoolsListView.CausesValidation = False
        Me.schoolsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.schoolsListView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.schoolsListView.FullRowSelect = True
        Me.schoolsListView.GridLines = True
        Me.schoolsListView.Location = New System.Drawing.Point(0, 82)
        Me.schoolsListView.MultiSelect = False
        Me.schoolsListView.Name = "schoolsListView"
        Me.schoolsListView.Size = New System.Drawing.Size(1008, 647)
        Me.schoolsListView.TabIndex = 171
        Me.schoolsListView.UseCompatibleStateImageBehavior = False
        Me.schoolsListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 112
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 294
        '
        'viewSchoolsContextMenu
        '
        Me.viewSchoolsContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.viewSchoolsContextMenu.Name = "searchResultContextMenu"
        Me.viewSchoolsContextMenu.Size = New System.Drawing.Size(108, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'viewSchoolsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.refreshBtn)
        Me.Controls.Add(Me.schoolsListView)
        Me.Name = "viewSchoolsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Schools"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.viewSchoolsContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents refreshBtn As Button
    Friend WithEvents schoolsListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents viewSchoolsContextMenu As ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
End Class
