<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewDatabaseForm
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
        Me.databaseResultListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.viewBtn = New System.Windows.Forms.Button()
        Me.yearLabel = New System.Windows.Forms.Label()
        Me.schoolLabel = New System.Windows.Forms.Label()
        Me.schoolName = New System.Windows.Forms.ComboBox()
        Me.classLabel = New System.Windows.Forms.Label()
        Me.className = New System.Windows.Forms.ComboBox()
        Me.TerseDataSet = New ASMAS.TerseDataSet()
        Me.TerseDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.yearName = New System.Windows.Forms.ComboBox()
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TerseDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'databaseResultListView
        '
        Me.databaseResultListView.AllowColumnReorder = True
        Me.databaseResultListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.databaseResultListView.CausesValidation = False
        Me.databaseResultListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.databaseResultListView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.databaseResultListView.FullRowSelect = True
        Me.databaseResultListView.GridLines = True
        Me.databaseResultListView.Location = New System.Drawing.Point(0, 133)
        Me.databaseResultListView.MultiSelect = False
        Me.databaseResultListView.Name = "databaseResultListView"
        Me.databaseResultListView.Size = New System.Drawing.Size(1008, 596)
        Me.databaseResultListView.TabIndex = 10
        Me.databaseResultListView.UseCompatibleStateImageBehavior = False
        Me.databaseResultListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 112
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 294
        '
        'viewBtn
        '
        Me.viewBtn.Location = New System.Drawing.Point(551, 8)
        Me.viewBtn.Name = "viewBtn"
        Me.viewBtn.Size = New System.Drawing.Size(75, 23)
        Me.viewBtn.TabIndex = 12
        Me.viewBtn.Text = "View"
        Me.viewBtn.UseVisualStyleBackColor = True
        '
        'yearLabel
        '
        Me.yearLabel.AutoSize = True
        Me.yearLabel.Location = New System.Drawing.Point(199, 13)
        Me.yearLabel.Name = "yearLabel"
        Me.yearLabel.Size = New System.Drawing.Size(29, 13)
        Me.yearLabel.TabIndex = 9
        Me.yearLabel.Text = "Year"
        '
        'schoolLabel
        '
        Me.schoolLabel.AutoSize = True
        Me.schoolLabel.Location = New System.Drawing.Point(12, 13)
        Me.schoolLabel.Name = "schoolLabel"
        Me.schoolLabel.Size = New System.Drawing.Size(40, 13)
        Me.schoolLabel.TabIndex = 7
        Me.schoolLabel.Text = "School"
        '
        'schoolName
        '
        Me.schoolName.FormattingEnabled = True
        Me.schoolName.Location = New System.Drawing.Point(67, 10)
        Me.schoolName.Name = "schoolName"
        Me.schoolName.Size = New System.Drawing.Size(121, 21)
        Me.schoolName.TabIndex = 6
        Me.schoolName.Text = "Choose school..."
        '
        'classLabel
        '
        Me.classLabel.AutoSize = True
        Me.classLabel.Location = New System.Drawing.Point(371, 15)
        Me.classLabel.Name = "classLabel"
        Me.classLabel.Size = New System.Drawing.Size(32, 13)
        Me.classLabel.TabIndex = 13
        Me.classLabel.Text = "Class"
        '
        'className
        '
        Me.className.FormattingEnabled = True
        Me.className.Location = New System.Drawing.Point(409, 10)
        Me.className.Name = "className"
        Me.className.Size = New System.Drawing.Size(121, 21)
        Me.className.TabIndex = 8
        Me.className.Text = "Choose class..."
        '
        'TerseDataSet
        '
        Me.TerseDataSet.DataSetName = "TerseDataSet"
        Me.TerseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TerseDataSetBindingSource
        '
        Me.TerseDataSetBindingSource.DataSource = Me.TerseDataSet
        Me.TerseDataSetBindingSource.Position = 0
        '
        'yearName
        '
        Me.yearName.FormattingEnabled = True
        Me.yearName.Location = New System.Drawing.Point(234, 10)
        Me.yearName.Name = "yearName"
        Me.yearName.Size = New System.Drawing.Size(121, 21)
        Me.yearName.TabIndex = 7
        Me.yearName.Text = "Choose year..."
        '
        'viewDatabaseForm
        '
        Me.AcceptButton = Me.viewBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.yearName)
        Me.Controls.Add(Me.className)
        Me.Controls.Add(Me.classLabel)
        Me.Controls.Add(Me.databaseResultListView)
        Me.Controls.Add(Me.viewBtn)
        Me.Controls.Add(Me.yearLabel)
        Me.Controls.Add(Me.schoolLabel)
        Me.Controls.Add(Me.schoolName)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "viewDatabaseForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Database"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TerseDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents databaseResultListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents viewBtn As Button
    Friend WithEvents yearLabel As Label
    Friend WithEvents schoolLabel As Label
    Friend WithEvents schoolName As ComboBox
    Friend WithEvents TerseDataSet As TerseDataSet
    Friend WithEvents TerseDataSetBindingSource As BindingSource
    Friend WithEvents classLabel As Label
    Friend WithEvents className As ComboBox
    Friend WithEvents yearName As ComboBox
End Class
