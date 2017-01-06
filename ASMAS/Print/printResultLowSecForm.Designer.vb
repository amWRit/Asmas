<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class printResultLowSecForm
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.previousBtn = New System.Windows.Forms.Button()
        Me.nextBtn = New System.Windows.Forms.Button()
        Me.printDataSet = New ASMAS.printDataSet()
        Me.PrintResultsLowSecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintResultsLowSecTableAdapter = New ASMAS.printDataSetTableAdapters.printResultsLowSecTableAdapter()
        CType(Me.printDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintResultsLowSecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource1.Name = "resultLowSec"
        ReportDataSource1.Value = Me.PrintResultsLowSecBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ASMAS.resultLowSec.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 67)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1008, 662)
        Me.ReportViewer1.TabIndex = 0
        '
        'previousBtn
        '
        Me.previousBtn.Enabled = False
        Me.previousBtn.Location = New System.Drawing.Point(12, 12)
        Me.previousBtn.Name = "previousBtn"
        Me.previousBtn.Size = New System.Drawing.Size(75, 23)
        Me.previousBtn.TabIndex = 1
        Me.previousBtn.Text = "Previous"
        Me.previousBtn.UseVisualStyleBackColor = True
        '
        'nextBtn
        '
        Me.nextBtn.Location = New System.Drawing.Point(93, 12)
        Me.nextBtn.Name = "nextBtn"
        Me.nextBtn.Size = New System.Drawing.Size(75, 23)
        Me.nextBtn.TabIndex = 2
        Me.nextBtn.Text = "Next"
        Me.nextBtn.UseVisualStyleBackColor = True
        '
        'printDataSet
        '
        Me.printDataSet.DataSetName = "printDataSet"
        Me.printDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PrintResultsLowSecBindingSource
        '
        Me.PrintResultsLowSecBindingSource.DataMember = "printResultsLowSec"
        Me.PrintResultsLowSecBindingSource.DataSource = Me.printDataSet
        '
        'PrintResultsLowSecTableAdapter
        '
        Me.PrintResultsLowSecTableAdapter.ClearBeforeFill = True
        '
        'printResultLowSecForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.nextBtn)
        Me.Controls.Add(Me.previousBtn)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "printResultLowSecForm"
        Me.Text = "Print Results"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.printDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintResultsLowSecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents previousBtn As Button
    Friend WithEvents nextBtn As Button
    Friend WithEvents printDataSet As printDataSet
    Friend WithEvents PrintResultsLowSecBindingSource As BindingSource
    Friend WithEvents PrintResultsLowSecTableAdapter As printDataSetTableAdapters.printResultsLowSecTableAdapter
End Class
