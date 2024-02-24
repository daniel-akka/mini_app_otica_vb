<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaContasAReceber
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
        Me.rptvListaContasAReceber = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClAReceberTotalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClAReceberTotalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptvListaContasAReceber
        '
        Me.rptvListaContasAReceber.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "AReceberTotalDS"
        ReportDataSource1.Value = Me.ClAReceberTotalBindingSource
        Me.rptvListaContasAReceber.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptvListaContasAReceber.LocalReport.ReportEmbeddedResource = "AppBarbearia.RelatorioListaContasAReceber.rdlc"
        Me.rptvListaContasAReceber.Location = New System.Drawing.Point(0, 0)
        Me.rptvListaContasAReceber.Name = "rptvListaContasAReceber"
        Me.rptvListaContasAReceber.Size = New System.Drawing.Size(633, 434)
        Me.rptvListaContasAReceber.TabIndex = 0
        '
        'ClAReceberTotalBindingSource
        '
        Me.ClAReceberTotalBindingSource.DataSource = GetType(AppOtica.ClAReceberTotal)
        '
        'FormListaContasAReceber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 434)
        Me.Controls.Add(Me.rptvListaContasAReceber)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormListaContasAReceber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Contas a Receber"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClAReceberTotalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptvListaContasAReceber As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClAReceberTotalBindingSource As System.Windows.Forms.BindingSource
End Class
