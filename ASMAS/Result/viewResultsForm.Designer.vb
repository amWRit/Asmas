<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewResultsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewResultsForm))
        Me.databaseResultListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.className = New System.Windows.Forms.ComboBox()
        Me.classLabel = New System.Windows.Forms.Label()
        Me.viewBtn = New System.Windows.Forms.Button()
        Me.yearLabel = New System.Windows.Forms.Label()
        Me.schoolLabel = New System.Windows.Forms.Label()
        Me.schoolName = New System.Windows.Forms.ComboBox()
        Me.TerseDataSet = New ASMAS.TerseDataSet()
        Me.TerseDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.yearName = New System.Windows.Forms.ComboBox()
        Me.termCombo = New System.Windows.Forms.ComboBox()
        Me.termLabel = New System.Windows.Forms.Label()
        Me.exportBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.printBtn = New System.Windows.Forms.Button()
        Me.viewResultsContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TerseDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.viewResultsContextMenu.SuspendLayout()
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
        Me.databaseResultListView.Location = New System.Drawing.Point(0, 74)
        Me.databaseResultListView.MultiSelect = False
        Me.databaseResultListView.Name = "databaseResultListView"
        Me.databaseResultListView.Size = New System.Drawing.Size(1008, 655)
        Me.databaseResultListView.TabIndex = 21
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
        'className
        '
        Me.className.FormattingEnabled = True
        Me.className.Location = New System.Drawing.Point(576, 19)
        Me.className.Name = "className"
        Me.className.Size = New System.Drawing.Size(121, 21)
        Me.className.TabIndex = 19
        Me.className.Text = "Choose class..."
        '
        'classLabel
        '
        Me.classLabel.AutoSize = True
        Me.classLabel.Location = New System.Drawing.Point(538, 24)
        Me.classLabel.Name = "classLabel"
        Me.classLabel.Size = New System.Drawing.Size(32, 13)
        Me.classLabel.TabIndex = 21
        Me.classLabel.Text = "Class"
        '
        'viewBtn
        '
        Me.viewBtn.Location = New System.Drawing.Point(710, 19)
        Me.viewBtn.Name = "viewBtn"
        Me.viewBtn.Size = New System.Drawing.Size(75, 23)
        Me.viewBtn.TabIndex = 20
        Me.viewBtn.Text = "View"
        Me.viewBtn.UseVisualStyleBackColor = True
        '
        'yearLabel
        '
        Me.yearLabel.AutoSize = True
        Me.yearLabel.Location = New System.Drawing.Point(199, 21)
        Me.yearLabel.Name = "yearLabel"
        Me.yearLabel.Size = New System.Drawing.Size(29, 13)
        Me.yearLabel.TabIndex = 18
        Me.yearLabel.Text = "Year"
        '
        'schoolLabel
        '
        Me.schoolLabel.AutoSize = True
        Me.schoolLabel.Location = New System.Drawing.Point(12, 21)
        Me.schoolLabel.Name = "schoolLabel"
        Me.schoolLabel.Size = New System.Drawing.Size(40, 13)
        Me.schoolLabel.TabIndex = 17
        Me.schoolLabel.Text = "School"
        '
        'schoolName
        '
        Me.schoolName.FormattingEnabled = True
        Me.schoolName.Location = New System.Drawing.Point(67, 18)
        Me.schoolName.Name = "schoolName"
        Me.schoolName.Size = New System.Drawing.Size(121, 21)
        Me.schoolName.TabIndex = 16
        Me.schoolName.Text = "Choose school..."
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
        Me.yearName.Location = New System.Drawing.Point(234, 18)
        Me.yearName.Name = "yearName"
        Me.yearName.Size = New System.Drawing.Size(121, 21)
        Me.yearName.TabIndex = 17
        Me.yearName.Text = "Choose year..."
        '
        'termCombo
        '
        Me.termCombo.FormattingEnabled = True
        Me.termCombo.Items.AddRange(New Object() {"First", "Second", "Third", "SendUp"})
        Me.termCombo.Location = New System.Drawing.Point(399, 19)
        Me.termCombo.Name = "termCombo"
        Me.termCombo.Size = New System.Drawing.Size(121, 21)
        Me.termCombo.TabIndex = 18
        Me.termCombo.Text = "Choose term..."
        '
        'termLabel
        '
        Me.termLabel.AutoSize = True
        Me.termLabel.Location = New System.Drawing.Point(361, 24)
        Me.termLabel.Name = "termLabel"
        Me.termLabel.Size = New System.Drawing.Size(31, 13)
        Me.termLabel.TabIndex = 24
        Me.termLabel.Text = "Term"
        '
        'exportBtn
        '
        Me.exportBtn.BackgroundImage = CType(resources.GetObject("exportBtn.BackgroundImage"), System.Drawing.Image)
        Me.exportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.exportBtn.Enabled = False
        Me.exportBtn.Location = New System.Drawing.Point(944, 19)
        Me.exportBtn.Name = "exportBtn"
        Me.exportBtn.Size = New System.Drawing.Size(27, 23)
        Me.exportBtn.TabIndex = 25
        Me.exportBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(941, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Export to excel"
        '
        'printBtn
        '
        Me.printBtn.Enabled = False
        Me.printBtn.Location = New System.Drawing.Point(837, 19)
        Me.printBtn.Name = "printBtn"
        Me.printBtn.Size = New System.Drawing.Size(101, 23)
        Me.printBtn.TabIndex = 24
        Me.printBtn.Text = "Print Report Card"
        Me.printBtn.UseVisualStyleBackColor = True
        '
        'viewResultsContextMenu
        '
        Me.viewResultsContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripMenuItem})
        Me.viewResultsContextMenu.Name = "searchResultContextMenu"
        Me.viewResultsContextMenu.Size = New System.Drawing.Size(100, 26)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'viewResultsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.printBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.exportBtn)
        Me.Controls.Add(Me.termCombo)
        Me.Controls.Add(Me.termLabel)
        Me.Controls.Add(Me.databaseResultListView)
        Me.Controls.Add(Me.className)
        Me.Controls.Add(Me.classLabel)
        Me.Controls.Add(Me.viewBtn)
        Me.Controls.Add(Me.yearLabel)
        Me.Controls.Add(Me.schoolLabel)
        Me.Controls.Add(Me.schoolName)
        Me.Controls.Add(Me.yearName)
        Me.Name = "viewResultsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "viewResultsForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TerseDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.viewResultsContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents databaseResultListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents className As ComboBox
    Friend WithEvents classLabel As Label
    Friend WithEvents viewBtn As Button
    Friend WithEvents yearLabel As Label
    Friend WithEvents schoolLabel As Label
    Friend WithEvents schoolName As ComboBox
    Friend WithEvents TerseDataSet As TerseDataSet
    Friend WithEvents TerseDataSetBindingSource As BindingSource
    Friend WithEvents yearName As ComboBox
    Friend WithEvents termCombo As ComboBox
    Friend WithEvents termLabel As Label
    Friend WithEvents exportBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents printBtn As Button
    Friend WithEvents viewResultsContextMenu As ContextMenuStrip
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
End Class
