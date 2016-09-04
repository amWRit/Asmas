<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subjectTeachersDetails
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
        Me.subjectTeacherListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.subjectTeacherMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.subjectTeacherMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'subjectTeacherListView
        '
        Me.subjectTeacherListView.AllowColumnReorder = True
        Me.subjectTeacherListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.subjectTeacherListView.CausesValidation = False
        Me.subjectTeacherListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.subjectTeacherListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.subjectTeacherListView.FullRowSelect = True
        Me.subjectTeacherListView.GridLines = True
        Me.subjectTeacherListView.Location = New System.Drawing.Point(0, 0)
        Me.subjectTeacherListView.MultiSelect = False
        Me.subjectTeacherListView.Name = "subjectTeacherListView"
        Me.subjectTeacherListView.Size = New System.Drawing.Size(657, 335)
        Me.subjectTeacherListView.TabIndex = 166
        Me.subjectTeacherListView.UseCompatibleStateImageBehavior = False
        Me.subjectTeacherListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 112
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 294
        '
        'subjectTeacherMenuStrip
        '
        Me.subjectTeacherMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.subjectTeacherMenuStrip.Name = "subjectTeacherMenuStrip"
        Me.subjectTeacherMenuStrip.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'subjectTeachersDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 335)
        Me.Controls.Add(Me.subjectTeacherListView)
        Me.MaximizeBox = False
        Me.Name = "subjectTeachersDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subject Teacher Details"
        Me.subjectTeacherMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents subjectTeacherListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents subjectTeacherMenuStrip As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
End Class
