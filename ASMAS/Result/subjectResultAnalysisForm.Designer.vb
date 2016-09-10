<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class subjectResultAnalysisForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(subjectResultAnalysisForm))
        Me.TerseDataSet = New ASMAS.TerseDataSet()
        Me.TerseDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.subjectAnalysisListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.termCombo = New System.Windows.Forms.ComboBox()
        Me.analyseBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.resultAnalysisContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StudentsUnderLOCOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.exportBtn = New System.Windows.Forms.Button()
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TerseDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.resultAnalysisContextMenu.SuspendLayout()
        Me.SuspendLayout()
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
        Me.subjectAnalysisListView.TabIndex = 166
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
        'termCombo
        '
        Me.termCombo.FormattingEnabled = True
        Me.termCombo.Items.AddRange(New Object() {"First", "Second", "Third", "SendUp"})
        Me.termCombo.Location = New System.Drawing.Point(199, 12)
        Me.termCombo.Name = "termCombo"
        Me.termCombo.Size = New System.Drawing.Size(121, 21)
        Me.termCombo.TabIndex = 167
        Me.termCombo.Text = "Choose terminal..."
        '
        'analyseBtn
        '
        Me.analyseBtn.Location = New System.Drawing.Point(352, 12)
        Me.analyseBtn.Name = "analyseBtn"
        Me.analyseBtn.Size = New System.Drawing.Size(112, 23)
        Me.analyseBtn.TabIndex = 168
        Me.analyseBtn.Text = "Analyse Result"
        Me.analyseBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(146, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 169
        Me.Label1.Text = "Terminal"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(483, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Export to excel"
        '
        'exportBtn
        '
        Me.exportBtn.BackgroundImage = CType(resources.GetObject("exportBtn.BackgroundImage"), System.Drawing.Image)
        Me.exportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.exportBtn.Enabled = False
        Me.exportBtn.Location = New System.Drawing.Point(486, 12)
        Me.exportBtn.Name = "exportBtn"
        Me.exportBtn.Size = New System.Drawing.Size(27, 23)
        Me.exportBtn.TabIndex = 170
        Me.exportBtn.UseVisualStyleBackColor = True
        '
        'subjectResultAnalysisForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.exportBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.analyseBtn)
        Me.Controls.Add(Me.termCombo)
        Me.Controls.Add(Me.subjectAnalysisListView)
        Me.Name = "subjectResultAnalysisForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subject Result Analysis"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TerseDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.resultAnalysisContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TerseDataSet As TerseDataSet
    Friend WithEvents TerseDataSetBindingSource As BindingSource
    Friend WithEvents subjectAnalysisListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents termCombo As ComboBox
    Friend WithEvents analyseBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents resultAnalysisContextMenu As ContextMenuStrip
    Friend WithEvents ViewDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StudentsUnderLOCOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents exportBtn As Button
End Class
