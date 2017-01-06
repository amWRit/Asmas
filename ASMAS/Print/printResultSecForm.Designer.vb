<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class printResultSecForm
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.TerseDataSet = New ASMAS.TerseDataSet()
        Me.secReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.nextBtn = New System.Windows.Forms.Button()
        Me.previousBtn = New System.Windows.Forms.Button()
        Me.PrintDataSet = New ASMAS.printDataSet()
        Me.PrintResultsSecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintResultsSecTableAdapter = New ASMAS.printDataSetTableAdapters.printResultsSecTableAdapter()
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintResultsSecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TerseDataSet
        '
        Me.TerseDataSet.DataSetName = "TerseDataSet"
        Me.TerseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'secReportViewer
        '
        Me.secReportViewer.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource1.Name = "resultsSec"
        ReportDataSource1.Value = Me.PrintResultsSecBindingSource
        Me.secReportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.secReportViewer.LocalReport.ReportEmbeddedResource = "ASMAS.resultSec.rdlc"
        Me.secReportViewer.Location = New System.Drawing.Point(0, 64)
        Me.secReportViewer.Name = "secReportViewer"
        Me.secReportViewer.Size = New System.Drawing.Size(1008, 665)
        Me.secReportViewer.TabIndex = 0
        '
        'nextBtn
        '
        Me.nextBtn.Location = New System.Drawing.Point(93, 12)
        Me.nextBtn.Name = "nextBtn"
        Me.nextBtn.Size = New System.Drawing.Size(75, 23)
        Me.nextBtn.TabIndex = 4
        Me.nextBtn.Text = "Next"
        Me.nextBtn.UseVisualStyleBackColor = True
        '
        'previousBtn
        '
        Me.previousBtn.Enabled = False
        Me.previousBtn.Location = New System.Drawing.Point(12, 12)
        Me.previousBtn.Name = "previousBtn"
        Me.previousBtn.Size = New System.Drawing.Size(75, 23)
        Me.previousBtn.TabIndex = 3
        Me.previousBtn.Text = "Previous"
        Me.previousBtn.UseVisualStyleBackColor = True
        '
        'PrintDataSet
        '
        Me.PrintDataSet.DataSetName = "printDataSet"
        Me.PrintDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PrintResultsSecBindingSource
        '
        Me.PrintResultsSecBindingSource.DataMember = "printResultsSec"
        Me.PrintResultsSecBindingSource.DataSource = Me.PrintDataSet
        '
        'PrintResultsSecTableAdapter
        '
        Me.PrintResultsSecTableAdapter.ClearBeforeFill = True
        '
        'printResultSecForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.nextBtn)
        Me.Controls.Add(Me.previousBtn)
        Me.Controls.Add(Me.secReportViewer)
        Me.Name = "printResultSecForm"
        Me.Text = "Print Results"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintResultsSecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents secReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents nextBtn As Button
    Friend WithEvents previousBtn As Button
    Friend WithEvents TerseDataSet As TerseDataSet
    Friend WithEvents PrintDataSet As printDataSet
    Friend WithEvents PrintResultsSecBindingSource As BindingSource
    Friend WithEvents PrintResultsSecTableAdapter As printDataSetTableAdapters.printResultsSecTableAdapter
End Class
