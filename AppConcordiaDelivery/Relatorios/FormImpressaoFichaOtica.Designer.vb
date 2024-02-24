<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImpressaoFichaOtica
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rptvImpressaoFichaOtica = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClEmpresaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClFichaOticaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClFichaOticaProdutoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClFichaOticaOlhoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClFichaOticaPrestacoesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClFichaOticaAssinaturaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClEmpresaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClFichaOticaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClFichaOticaProdutoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClFichaOticaOlhoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClFichaOticaPrestacoesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClFichaOticaAssinaturaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptvImpressaoFichaOtica
        '
        Me.rptvImpressaoFichaOtica.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsEmpresa"
        ReportDataSource1.Value = Me.ClEmpresaBindingSource
        ReportDataSource2.Name = "DsCliente"
        ReportDataSource2.Value = Me.ClClienteBindingSource
        ReportDataSource3.Name = "DsFichaOtica"
        ReportDataSource3.Value = Me.ClFichaOticaBindingSource
        ReportDataSource4.Name = "DsProdutoFicha"
        ReportDataSource4.Value = Me.ClFichaOticaProdutoBindingSource
        ReportDataSource5.Name = "DsOlhoFicha"
        ReportDataSource5.Value = Me.ClFichaOticaOlhoBindingSource
        ReportDataSource6.Name = "DsPrestacoesFicha"
        ReportDataSource6.Value = Me.ClFichaOticaPrestacoesBindingSource
        ReportDataSource7.Name = "DsAssinaturaFicha"
        ReportDataSource7.Value = Me.ClFichaOticaAssinaturaBindingSource
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(ReportDataSource3)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(ReportDataSource4)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(ReportDataSource5)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(ReportDataSource6)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(ReportDataSource7)
        Me.rptvImpressaoFichaOtica.LocalReport.ReportEmbeddedResource = "AppOtica.ImpressaoFichaOtica.rdlc"
        Me.rptvImpressaoFichaOtica.Location = New System.Drawing.Point(0, 0)
        Me.rptvImpressaoFichaOtica.Name = "rptvImpressaoFichaOtica"
        Me.rptvImpressaoFichaOtica.Size = New System.Drawing.Size(633, 434)
        Me.rptvImpressaoFichaOtica.TabIndex = 2
        '
        'ClEmpresaBindingSource
        '
        Me.ClEmpresaBindingSource.DataSource = GetType(AppOtica.ClEmpresa)
        '
        'ClClienteBindingSource
        '
        Me.ClClienteBindingSource.DataSource = GetType(AppOtica.ClCliente)
        '
        'ClFichaOticaBindingSource
        '
        Me.ClFichaOticaBindingSource.DataSource = GetType(AppOtica.ClFichaOtica)
        '
        'ClFichaOticaProdutoBindingSource
        '
        Me.ClFichaOticaProdutoBindingSource.DataSource = GetType(AppOtica.ClFichaOticaProduto)
        '
        'ClFichaOticaOlhoBindingSource
        '
        Me.ClFichaOticaOlhoBindingSource.DataSource = GetType(AppOtica.ClFichaOticaOlho)
        '
        'ClFichaOticaPrestacoesBindingSource
        '
        Me.ClFichaOticaPrestacoesBindingSource.DataSource = GetType(AppOtica.ClFichaOticaPrestacoes)
        '
        'ClFichaOticaAssinaturaBindingSource
        '
        Me.ClFichaOticaAssinaturaBindingSource.DataSource = GetType(AppOtica.ClFichaOticaAssinatura)
        '
        'FormImpressaoFichaOtica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 434)
        Me.Controls.Add(Me.rptvImpressaoFichaOtica)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormImpressaoFichaOtica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impressão de Ficha Ótica"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClEmpresaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClFichaOticaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClFichaOticaProdutoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClFichaOticaOlhoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClFichaOticaPrestacoesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClFichaOticaAssinaturaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptvImpressaoFichaOtica As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClEmpresaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClClienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClFichaOticaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClFichaOticaProdutoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClFichaOticaOlhoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClFichaOticaPrestacoesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClFichaOticaAssinaturaBindingSource As System.Windows.Forms.BindingSource
End Class
