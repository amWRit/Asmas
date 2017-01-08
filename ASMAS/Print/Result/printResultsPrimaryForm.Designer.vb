<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class printResultsPrimaryForm
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.TerseDataSet = New ASMAS.TerseDataSet()
        Me.primaryReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.nextBtn = New System.Windows.Forms.Button()
        Me.previousBtn = New System.Windows.Forms.Button()
        Me.PrintResultsPrimaryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintDataSet = New ASMAS.printDataSet()
        Me.PrintResultsPrimaryTableAdapter = New ASMAS.printDataSetTableAdapters.printResultsPrimaryTableAdapter()
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintResultsPrimaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TerseDataSet
        '
        Me.TerseDataSet.DataSetName = "TerseDataSet"
        Me.TerseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'primaryReportViewer
        '
        Me.primaryReportViewer.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource1.Name = "resultPrimary"
        ReportDataSource1.Value = Me.PrintResultsPrimaryBindingSource
        Me.primaryReportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.primaryReportViewer.LocalReport.ReportEmbeddedResource = "ASMAS.resultPrimary.rdlc"
        Me.primaryReportViewer.Location = New System.Drawing.Point(0, 71)
        Me.primaryReportViewer.Name = "primaryReportViewer"
        Me.primaryReportViewer.Size = New System.Drawing.Size(1008, 658)
        Me.primaryReportViewer.TabIndex = 0
        '
        'nextBtn
        '
        Me.nextBtn.Location = New System.Drawing.Point(93, 21)
        Me.nextBtn.Name = "nextBtn"
        Me.nextBtn.Size = New System.Drawing.Size(75, 23)
        Me.nextBtn.TabIndex = 4
        Me.nextBtn.Text = "Next"
        Me.nextBtn.UseVisualStyleBackColor = True
        '
        'previousBtn
        '
        Me.previousBtn.Enabled = False
        Me.previousBtn.Location = New System.Drawing.Point(12, 21)
        Me.previousBtn.Name = "previousBtn"
        Me.previousBtn.Size = New System.Drawing.Size(75, 23)
        Me.previousBtn.TabIndex = 3
        Me.previousBtn.Text = "Previous"
        Me.previousBtn.UseVisualStyleBackColor = True
        '
        'PrintResultsPrimaryBindingSource
        '
        Me.PrintResultsPrimaryBindingSource.DataMember = "printResultsPrimary"
        Me.PrintResultsPrimaryBindingSource.DataSource = Me.PrintDataSet
        '
        'PrintDataSet
        '
        Me.PrintDataSet.DataSetName = "printDataSet"
        Me.PrintDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PrintResultsPrimaryTableAdapter
        '
        Me.PrintResultsPrimaryTableAdapter.ClearBeforeFill = True
        '
        'printResultsPrimaryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.nextBtn)
        Me.Controls.Add(Me.previousBtn)
        Me.Controls.Add(Me.primaryReportViewer)
        Me.Name = "printResultsPrimaryForm"
        Me.Text = "Print Results"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintResultsPrimaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents primaryReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents TerseDataSet As TerseDataSet
    Friend WithEvents nextBtn As Button
    Friend WithEvents previousBtn As Button
    Friend WithEvents PrintDataSet As printDataSet
    Friend WithEvents PrintResultsPrimaryBindingSource As BindingSource
    Friend WithEvents PrintResultsPrimaryTableAdapter As printDataSetTableAdapters.printResultsPrimaryTableAdapter
End Class
