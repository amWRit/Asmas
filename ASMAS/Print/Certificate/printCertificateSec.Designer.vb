<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class printCertificateSec
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
        Me.nextBtn = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.previousBtn = New System.Windows.Forms.Button()
        Me.printDataSet = New ASMAS.printDataSet()
        Me.printResultsSecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.printResultsSecTableAdapter = New ASMAS.printDataSetTableAdapters.printResultsSecTableAdapter()
        CType(Me.printDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.printResultsSecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nextBtn
        '
        Me.nextBtn.Location = New System.Drawing.Point(93, 3)
        Me.nextBtn.Name = "nextBtn"
        Me.nextBtn.Size = New System.Drawing.Size(75, 23)
        Me.nextBtn.TabIndex = 11
        Me.nextBtn.Text = "Next"
        Me.nextBtn.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource1.Name = "printCertificateSec"
        ReportDataSource1.Value = Me.printResultsSecBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ASMAS.printCertificateSec.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 67)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1008, 662)
        Me.ReportViewer1.TabIndex = 9
        '
        'previousBtn
        '
        Me.previousBtn.Enabled = False
        Me.previousBtn.Location = New System.Drawing.Point(12, 3)
        Me.previousBtn.Name = "previousBtn"
        Me.previousBtn.Size = New System.Drawing.Size(75, 23)
        Me.previousBtn.TabIndex = 10
        Me.previousBtn.Text = "Previous"
        Me.previousBtn.UseVisualStyleBackColor = True
        '
        'printDataSet
        '
        Me.printDataSet.DataSetName = "printDataSet"
        Me.printDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'printResultsSecBindingSource
        '
        Me.printResultsSecBindingSource.DataMember = "printResultsSec"
        Me.printResultsSecBindingSource.DataSource = Me.printDataSet
        '
        'printResultsSecTableAdapter
        '
        Me.printResultsSecTableAdapter.ClearBeforeFill = True
        '
        'printCertificateSec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.nextBtn)
        Me.Controls.Add(Me.previousBtn)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "printCertificateSec"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "printCertificateSec"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.printDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.printResultsSecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents nextBtn As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents previousBtn As Button
    Friend WithEvents printDataSet As printDataSet
    Friend WithEvents printResultsSecBindingSource As BindingSource
    Friend WithEvents printResultsSecTableAdapter As printDataSetTableAdapters.printResultsSecTableAdapter
End Class
