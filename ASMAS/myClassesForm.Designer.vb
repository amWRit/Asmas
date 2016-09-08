<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class myClassesForm
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
        Me.myClassesListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.myClassesContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewStudentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStudentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddResultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentWiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubjectWiseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubjectTeacherToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResultAnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.myClassesContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'myClassesListView
        '
        Me.myClassesListView.AllowColumnReorder = True
        Me.myClassesListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.myClassesListView.CausesValidation = False
        Me.myClassesListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.myClassesListView.FullRowSelect = True
        Me.myClassesListView.GridLines = True
        Me.myClassesListView.Location = New System.Drawing.Point(1, 44)
        Me.myClassesListView.MultiSelect = False
        Me.myClassesListView.Name = "myClassesListView"
        Me.myClassesListView.Size = New System.Drawing.Size(635, 355)
        Me.myClassesListView.TabIndex = 165
        Me.myClassesListView.UseCompatibleStateImageBehavior = False
        Me.myClassesListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 112
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 294
        '
        'myClassesContextMenu
        '
        Me.myClassesContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ViewStudentsToolStripMenuItem, Me.AddStudentToolStripMenuItem, Me.ViewResultsToolStripMenuItem, Me.AddResultToolStripMenuItem, Me.SubjectTeacherToolStripMenuItem})
        Me.myClassesContextMenu.Name = "searchResultContextMenu"
        Me.myClassesContextMenu.Size = New System.Drawing.Size(158, 180)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Enabled = False
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ViewStudentsToolStripMenuItem
        '
        Me.ViewStudentsToolStripMenuItem.Name = "ViewStudentsToolStripMenuItem"
        Me.ViewStudentsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ViewStudentsToolStripMenuItem.Text = "View Students"
        '
        'AddStudentToolStripMenuItem
        '
        Me.AddStudentToolStripMenuItem.Name = "AddStudentToolStripMenuItem"
        Me.AddStudentToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.AddStudentToolStripMenuItem.Text = "Add Student"
        '
        'ViewResultsToolStripMenuItem
        '
        Me.ViewResultsToolStripMenuItem.Name = "ViewResultsToolStripMenuItem"
        Me.ViewResultsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ViewResultsToolStripMenuItem.Text = "View Results"
        '
        'AddResultToolStripMenuItem
        '
        Me.AddResultToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StudentWiseToolStripMenuItem, Me.SubjectWiseToolStripMenuItem})
        Me.AddResultToolStripMenuItem.Name = "AddResultToolStripMenuItem"
        Me.AddResultToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.AddResultToolStripMenuItem.Text = "Add Result"
        '
        'StudentWiseToolStripMenuItem
        '
        Me.StudentWiseToolStripMenuItem.Name = "StudentWiseToolStripMenuItem"
        Me.StudentWiseToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.StudentWiseToolStripMenuItem.Text = "Student wise"
        '
        'SubjectWiseToolStripMenuItem
        '
        Me.SubjectWiseToolStripMenuItem.Name = "SubjectWiseToolStripMenuItem"
        Me.SubjectWiseToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SubjectWiseToolStripMenuItem.Text = "Subject wise"
        '
        'SubjectTeacherToolStripMenuItem
        '
        Me.SubjectTeacherToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssignToolStripMenuItem, Me.ViewToolStripMenuItem1, Me.ResultAnalysisToolStripMenuItem})
        Me.SubjectTeacherToolStripMenuItem.Name = "SubjectTeacherToolStripMenuItem"
        Me.SubjectTeacherToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SubjectTeacherToolStripMenuItem.Text = "Subject Teacher"
        '
        'AssignToolStripMenuItem
        '
        Me.AssignToolStripMenuItem.Name = "AssignToolStripMenuItem"
        Me.AssignToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AssignToolStripMenuItem.Text = "Assign"
        '
        'ViewToolStripMenuItem1
        '
        Me.ViewToolStripMenuItem1.Name = "ViewToolStripMenuItem1"
        Me.ViewToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ViewToolStripMenuItem1.Text = "View"
        '
        'ResultAnalysisToolStripMenuItem
        '
        Me.ResultAnalysisToolStripMenuItem.Name = "ResultAnalysisToolStripMenuItem"
        Me.ResultAnalysisToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ResultAnalysisToolStripMenuItem.Text = "Result Analysis"
        '
        'myClassesForm
        '
        Me.AccessibleName = ""
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 392)
        Me.Controls.Add(Me.myClassesListView)
        Me.MaximizeBox = False
        Me.Name = "myClassesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "My classes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.myClassesContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents myClassesListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents myClassesContextMenu As ContextMenuStrip
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewStudentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewResultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddResultToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddStudentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentWiseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubjectWiseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubjectTeacherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssignToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ResultAnalysisToolStripMenuItem As ToolStripMenuItem
End Class
