<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TerseDataSet = New ASMAS.TerseDataSet()
        Me.userBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.userTableAdapter = New ASMAS.TerseDataSetTableAdapters.userTableAdapter()
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.userBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "User"
        ReportDataSource1.Value = Me.userBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(433, 327)
        Me.ReportViewer1.TabIndex = 0
        '
        'TerseDataSet
        '
        Me.TerseDataSet.DataSetName = "TerseDataSet"
        Me.TerseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'userBindingSource
        '
        Me.userBindingSource.DataMember = "user"
        Me.userBindingSource.DataSource = Me.TerseDataSet
        '
        'userTableAdapter
        '
        Me.userTableAdapter.ClearBeforeFill = True
        '
        'Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 327)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Report"
        Me.Text = "Report"
        CType(Me.TerseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.userBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents userBindingSource As BindingSource
    Friend WithEvents TerseDataSet As TerseDataSet
    Friend WithEvents userTableAdapter As TerseDataSetTableAdapters.userTableAdapter
End Class
