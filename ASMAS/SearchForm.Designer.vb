<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SearchForm
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
        Me.searchType = New System.Windows.Forms.ComboBox()
        Me.searchLabel = New System.Windows.Forms.Label()
        Me.searchByLabel = New System.Windows.Forms.Label()
        Me.searchKey = New System.Windows.Forms.ComboBox()
        Me.searchKeyword = New System.Windows.Forms.TextBox()
        Me.searchBtn = New System.Windows.Forms.Button()
        Me.searchResultListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TerseDataSet = New ASMAS.TerseDataSet()
        Me.TerseDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.searchResultContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TerseDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.searchResultContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'searchType
        '
        Me.searchType.FormattingEnabled = True
        Me.searchType.Items.AddRange(New Object() {"Class", "Student"})
        Me.searchType.Location = New System.Drawing.Point(67, 20)
        Me.searchType.Name = "searchType"
        Me.searchType.Size = New System.Drawing.Size(121, 21)
        Me.searchType.TabIndex = 0
        '
        'searchLabel
        '
        Me.searchLabel.AutoSize = True
        Me.searchLabel.Location = New System.Drawing.Point(12, 23)
        Me.searchLabel.Name = "searchLabel"
        Me.searchLabel.Size = New System.Drawing.Size(41, 13)
        Me.searchLabel.TabIndex = 1
        Me.searchLabel.Text = "Search"
        '
        'searchByLabel
        '
        Me.searchByLabel.AutoSize = True
        Me.searchByLabel.Location = New System.Drawing.Point(199, 23)
        Me.searchByLabel.Name = "searchByLabel"
        Me.searchByLabel.Size = New System.Drawing.Size(55, 13)
        Me.searchByLabel.TabIndex = 3
        Me.searchByLabel.Text = "Search by"
        '
        'searchKey
        '
        Me.searchKey.FormattingEnabled = True
        Me.searchKey.Items.AddRange(New Object() {"ID", "Name"})
        Me.searchKey.Location = New System.Drawing.Point(260, 20)
        Me.searchKey.Name = "searchKey"
        Me.searchKey.Size = New System.Drawing.Size(121, 21)
        Me.searchKey.TabIndex = 2
        '
        'searchKeyword
        '
        Me.searchKeyword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.searchKeyword.Location = New System.Drawing.Point(403, 20)
        Me.searchKeyword.Name = "searchKeyword"
        Me.searchKeyword.Size = New System.Drawing.Size(250, 20)
        Me.searchKeyword.TabIndex = 4
        '
        'searchBtn
        '
        Me.searchBtn.Location = New System.Drawing.Point(669, 20)
        Me.searchBtn.Name = "searchBtn"
        Me.searchBtn.Size = New System.Drawing.Size(75, 23)
        Me.searchBtn.TabIndex = 5
        Me.searchBtn.Text = "Search"
        Me.searchBtn.UseVisualStyleBackColor = True
        '
        'searchResultListView
        '
        Me.searchResultListView.AllowColumnReorder = True
        Me.searchResultListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.searchResultListView.CausesValidation = False
        Me.searchResultListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.searchResultListView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.searchResultListView.FullRowSelect = True
        Me.searchResultListView.GridLines = True
        Me.searchResultListView.Location = New System.Drawing.Point(0, 134)
        Me.searchResultListView.MultiSelect = False
        Me.searchResultListView.Name = "searchResultListView"
        Me.searchResultListView.Size = New System.Drawing.Size(1008, 595)
        Me.searchResultListView.TabIndex = 4
        Me.searchResultListView.UseCompatibleStateImageBehavior = False
        Me.searchResultListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 112
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 294
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
        'searchResultContextMenu
        '
        Me.searchResultContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailsToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.searchResultContextMenu.Name = "searchResultContextMenu"
        Me.searchResultContextMenu.Size = New System.Drawing.Size(137, 70)
        '
        'ViewDetailsToolStripMenuItem
        '
        Me.ViewDetailsToolStripMenuItem.Name = "ViewDetailsToolStripMenuItem"
        Me.ViewDetailsToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ViewDetailsToolStripMenuItem.Text = "View details"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'SearchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.searchResultListView)
        Me.Controls.Add(Me.searchBtn)
        Me.Controls.Add(Me.searchKeyword)
        Me.Controls.Add(Me.searchByLabel)
        Me.Controls.Add(Me.searchKey)
        Me.Controls.Add(Me.searchLabel)
        Me.Controls.Add(Me.searchType)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SearchForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TerseDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.searchResultContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents searchType As ComboBox
    Friend WithEvents searchLabel As Label
    Friend WithEvents searchByLabel As Label
    Friend WithEvents searchKey As ComboBox
    Friend WithEvents searchKeyword As TextBox
    Friend WithEvents searchBtn As Button
    Friend WithEvents searchResultListView As ListView
    Friend WithEvents TerseDataSet As TerseDataSet
    Friend WithEvents TerseDataSetBindingSource As BindingSource
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents searchResultContextMenu As ContextMenuStrip
    Friend WithEvents ViewDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
End Class
