<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class classResults
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
        Me.classResultListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.titleLabel = New System.Windows.Forms.Label()
        Me.termCombo = New System.Windows.Forms.ComboBox()
        Me.termLabel = New System.Windows.Forms.Label()
        Me.viewBtn = New System.Windows.Forms.Button()
        Me.updateRankBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'classResultListView
        '
        Me.classResultListView.AllowColumnReorder = True
        Me.classResultListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.classResultListView.CausesValidation = False
        Me.classResultListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.classResultListView.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.classResultListView.FullRowSelect = True
        Me.classResultListView.GridLines = True
        Me.classResultListView.Location = New System.Drawing.Point(0, 57)
        Me.classResultListView.MultiSelect = False
        Me.classResultListView.Name = "classResultListView"
        Me.classResultListView.Size = New System.Drawing.Size(1008, 672)
        Me.classResultListView.TabIndex = 166
        Me.classResultListView.UseCompatibleStateImageBehavior = False
        Me.classResultListView.View = System.Windows.Forms.View.Details
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
        Me.titleLabel.Location = New System.Drawing.Point(12, 9)
        Me.titleLabel.Name = "titleLabel"
        Me.titleLabel.Size = New System.Drawing.Size(89, 16)
        Me.titleLabel.TabIndex = 167
        Me.titleLabel.Text = "Class results :"
        '
        'termCombo
        '
        Me.termCombo.FormattingEnabled = True
        Me.termCombo.Items.AddRange(New Object() {"First", "Second", "Third", "SendUp"})
        Me.termCombo.Location = New System.Drawing.Point(188, 7)
        Me.termCombo.Name = "termCombo"
        Me.termCombo.Size = New System.Drawing.Size(121, 21)
        Me.termCombo.TabIndex = 168
        Me.termCombo.Text = "Choose term..."
        '
        'termLabel
        '
        Me.termLabel.AutoSize = True
        Me.termLabel.Location = New System.Drawing.Point(150, 12)
        Me.termLabel.Name = "termLabel"
        Me.termLabel.Size = New System.Drawing.Size(31, 13)
        Me.termLabel.TabIndex = 172
        Me.termLabel.Text = "Term"
        '
        'viewBtn
        '
        Me.viewBtn.Location = New System.Drawing.Point(315, 7)
        Me.viewBtn.Name = "viewBtn"
        Me.viewBtn.Size = New System.Drawing.Size(75, 23)
        Me.viewBtn.TabIndex = 170
        Me.viewBtn.Text = "View"
        Me.viewBtn.UseVisualStyleBackColor = True
        '
        'updateRankBtn
        '
        Me.updateRankBtn.Location = New System.Drawing.Point(884, 9)
        Me.updateRankBtn.Name = "updateRankBtn"
        Me.updateRankBtn.Size = New System.Drawing.Size(99, 23)
        Me.updateRankBtn.TabIndex = 173
        Me.updateRankBtn.Text = "Update Rank"
        Me.updateRankBtn.UseVisualStyleBackColor = True
        '
        'classResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.updateRankBtn)
        Me.Controls.Add(Me.termCombo)
        Me.Controls.Add(Me.termLabel)
        Me.Controls.Add(Me.viewBtn)
        Me.Controls.Add(Me.titleLabel)
        Me.Controls.Add(Me.classResultListView)
        Me.MaximizeBox = False
        Me.Name = "classResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "classResults"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents classResultListView As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents titleLabel As Label
    Friend WithEvents termCombo As ComboBox
    Friend WithEvents termLabel As Label
    Friend WithEvents viewBtn As Button
    Friend WithEvents updateRankBtn As Button
End Class
