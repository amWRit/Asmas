<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class studentsUnderLocosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(studentsUnderLocosForm))
        Me.studentsListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.locosLabel = New System.Windows.Forms.Label()
        Me.subjectLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.exportBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'studentsListView
        '
        Me.studentsListView.AllowColumnReorder = True
        Me.studentsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.studentsListView.CausesValidation = False
        Me.studentsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.studentsListView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.studentsListView.FullRowSelect = True
        Me.studentsListView.GridLines = True
        Me.studentsListView.Location = New System.Drawing.Point(0, 61)
        Me.studentsListView.MultiSelect = False
        Me.studentsListView.Name = "studentsListView"
        Me.studentsListView.Size = New System.Drawing.Size(520, 293)
        Me.studentsListView.TabIndex = 167
        Me.studentsListView.UseCompatibleStateImageBehavior = False
        Me.studentsListView.View = System.Windows.Forms.View.Details
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
        Me.titleLabel.Font = New System.Drawing.Font("Myriad Pro Light", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleLabel.Location = New System.Drawing.Point(12, 18)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(48, 20)
        Me.titleLabel.TabIndex = 169
        Me.titleLabel.Text = "Class:"
        '
        'locosLabel
        '
        Me.locosLabel.AutoSize = True
        Me.locosLabel.Font = New System.Drawing.Font("Myriad Pro Light", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.locosLabel.Location = New System.Drawing.Point(315, 18)
        Me.locosLabel.Name = "locosLabel"
        Me.locosLabel.Size = New System.Drawing.Size(59, 20)
        Me.locosLabel.TabIndex = 170
        Me.locosLabel.Text = "LOCOS:"
        '
        'subjectLabel
        '
        Me.subjectLabel.AutoSize = True
        Me.subjectLabel.Font = New System.Drawing.Font("Myriad Pro Light", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subjectLabel.Location = New System.Drawing.Point(177, 18)
        Me.subjectLabel.Name = "subjectLabel"
        Me.subjectLabel.Size = New System.Drawing.Size(60, 20)
        Me.subjectLabel.TabIndex = 171
        Me.subjectLabel.Text = "Subject"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(434, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Export to excel"
        '
        'exportBtn
        '
        Me.exportBtn.BackgroundImage = CType(resources.GetObject("exportBtn.BackgroundImage"), System.Drawing.Image)
        Me.exportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.exportBtn.Enabled = False
        Me.exportBtn.Location = New System.Drawing.Point(437, 18)
        Me.exportBtn.Name = "exportBtn"
        Me.exportBtn.Size = New System.Drawing.Size(27, 23)
        Me.exportBtn.TabIndex = 172
        Me.exportBtn.UseVisualStyleBackColor = True
        '
        'studentsUnderLocosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 354)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.exportBtn)
        Me.Controls.Add(Me.subjectLabel)
        Me.Controls.Add(Me.locosLabel)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.studentsListView)
        Me.Name = "studentsUnderLocosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Students under LOCOS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents studentsListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents titleLabel As Label
    Friend WithEvents locosLabel As Label
    Friend WithEvents subjectLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents exportBtn As Button
End Class
