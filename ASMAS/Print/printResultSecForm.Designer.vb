<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class printResultSecForm
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.secReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.nextBtn = New System.Windows.Forms.Button()
        Me.previousBtn = New System.Windows.Forms.Button()
        Me.TerseDataSet = New ASMAS.TerseDataSet()
        Me.printResultsSecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.printResultsSecTableAdapter = New ASMAS.TerseDataSetTableAdapters.printResultsSecTableAdapter()
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.printResultsSecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'secReportViewer
        '
        Me.secReportViewer.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource2.Name = "resultsSec"
        ReportDataSource2.Value = Me.printResultsSecBindingSource
        Me.secReportViewer.LocalReport.DataSources.Add(ReportDataSource2)
        Me.secReportViewer.LocalReport.ReportEmbeddedResource = "ASMAS.resultSec.rdlc"
        Me.secReportViewer.Location = New System.Drawing.Point(0, 36)
        Me.secReportViewer.Name = "secReportViewer"
        Me.secReportViewer.Size = New System.Drawing.Size(1008, 693)
        Me.secReportViewer.TabIndex = 0
        '
        'nextBtn
        '
        Me.nextBtn.Location = New System.Drawing.Point(93, 7)
        Me.nextBtn.Name = "nextBtn"
        Me.nextBtn.Size = New System.Drawing.Size(75, 23)
        Me.nextBtn.TabIndex = 4
        Me.nextBtn.Text = "Next"
        Me.nextBtn.UseVisualStyleBackColor = True
        '
        'previousBtn
        '
        Me.previousBtn.Enabled = False
        Me.previousBtn.Location = New System.Drawing.Point(12, 7)
        Me.previousBtn.Name = "previousBtn"
        Me.previousBtn.Size = New System.Drawing.Size(75, 23)
        Me.previousBtn.TabIndex = 3
        Me.previousBtn.Text = "Previous"
        Me.previousBtn.UseVisualStyleBackColor = True
        '
        'TerseDataSet
        '
        Me.TerseDataSet.DataSetName = "TerseDataSet"
        Me.TerseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'printResultsSecBindingSource
        '
        Me.printResultsSecBindingSource.DataMember = "printResultsSec"
        Me.printResultsSecBindingSource.DataSource = Me.TerseDataSet
        '
        'printResultsSecTableAdapter
        '
        Me.printResultsSecTableAdapter.ClearBeforeFill = True
        '
        'printResultSecForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.nextBtn)
        Me.Controls.Add(Me.previousBtn)
        Me.Controls.Add(Me.secReportViewer)
        Me.MinimizeBox = False
        Me.Name = "printResultSecForm"
        Me.Text = "printResultSecForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.printResultsSecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents secReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents nextBtn As Button
    Friend WithEvents previousBtn As Button
    Friend WithEvents printResultsSecBindingSource As BindingSource
    Friend WithEvents TerseDataSet As TerseDataSet
    Friend WithEvents printResultsSecTableAdapter As TerseDataSetTableAdapters.printResultsSecTableAdapter
End Class
