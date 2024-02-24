<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaContasAPagar
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
        Me.rptvListaContasAPagar = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClAPagarTotalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClAPagarTotalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptvListaContasAPagar
        '
        Me.rptvListaContasAPagar.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "APagarTotalDS"
        ReportDataSource1.Value = Me.ClAPagarTotalBindingSource
        Me.rptvListaContasAPagar.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptvListaContasAPagar.LocalReport.ReportEmbeddedResource = "AppBarbearia.RelatorioListaContasAPagar.rdlc"
        Me.rptvListaContasAPagar.Location = New System.Drawing.Point(0, 0)
        Me.rptvListaContasAPagar.Name = "rptvListaContasAPagar"
        Me.rptvListaContasAPagar.ShowRefreshButton = False
        Me.rptvListaContasAPagar.ShowStopButton = False
        Me.rptvListaContasAPagar.Size = New System.Drawing.Size(602, 421)
        Me.rptvListaContasAPagar.TabIndex = 0
        '
        'ClAPagarTotalBindingSource
        '
        Me.ClAPagarTotalBindingSource.DataSource = GetType(AppOtica.ClAPagarTotal)
        '
        'FormListaContasAPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 421)
        Me.Controls.Add(Me.rptvListaContasAPagar)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormListaContasAPagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contas a Pagar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClAPagarTotalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptvListaContasAPagar As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClAPagarTotalBindingSource As System.Windows.Forms.BindingSource
End Class
