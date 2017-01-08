<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class printCertificatePrimary
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
        Me.printDataSet = New ASMAS.printDataSet()
        Me.nextBtn = New System.Windows.Forms.Button()
        Me.previousBtn = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.printResultsPrimaryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.printResultsPrimaryTableAdapter = New ASMAS.printDataSetTableAdapters.printResultsPrimaryTableAdapter()
        CType(Me.printDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.printResultsPrimaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'printDataSet
        '
        Me.printDataSet.DataSetName = "printDataSet"
        Me.printDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'nextBtn
        '
        Me.nextBtn.Location = New System.Drawing.Point(93, 6)
        Me.nextBtn.Name = "nextBtn"
        Me.nextBtn.Size = New System.Drawing.Size(75, 23)
        Me.nextBtn.TabIndex = 8
        Me.nextBtn.Text = "Next"
        Me.nextBtn.UseVisualStyleBackColor = True
        '
        'previousBtn
        '
        Me.previousBtn.Enabled = False
        Me.previousBtn.Location = New System.Drawing.Point(12, 6)
        Me.previousBtn.Name = "previousBtn"
        Me.previousBtn.Size = New System.Drawing.Size(75, 23)
        Me.previousBtn.TabIndex = 7
        Me.previousBtn.Text = "Previous"
        Me.previousBtn.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource2.Name = "printCertificatePrimary"
        ReportDataSource2.Value = Me.printResultsPrimaryBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ASMAS.printCertificatePrimary.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 67)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1008, 662)
        Me.ReportViewer1.TabIndex = 6
        '
        'printResultsPrimaryBindingSource
        '
        Me.printResultsPrimaryBindingSource.DataMember = "printResultsPrimary"
        Me.printResultsPrimaryBindingSource.DataSource = Me.printDataSet
        '
        'printResultsPrimaryTableAdapter
        '
        Me.printResultsPrimaryTableAdapter.ClearBeforeFill = True
        '
        'printCertificatePrimary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.nextBtn)
        Me.Controls.Add(Me.previousBtn)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "printCertificatePrimary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "printCertificatePrimary"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.printDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.printResultsPrimaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents printDataSet As printDataSet
    Friend WithEvents nextBtn As Button
    Friend WithEvents previousBtn As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents printResultsPrimaryBindingSource As BindingSource
    Friend WithEvents printResultsPrimaryTableAdapter As printDataSetTableAdapters.printResultsPrimaryTableAdapter
End Class
