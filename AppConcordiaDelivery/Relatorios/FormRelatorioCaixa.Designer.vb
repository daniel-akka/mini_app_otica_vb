<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRelatorioCaixa
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
        Me.rpvRelatorioCaixa = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClRelatorioPadraoSTRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClRelatorioPadraoSTRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvRelatorioCaixa
        '
        Me.rpvRelatorioCaixa.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "RelatorioStrDS"
        ReportDataSource1.Value = Me.ClRelatorioPadraoSTRBindingSource
        Me.rpvRelatorioCaixa.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvRelatorioCaixa.LocalReport.ReportEmbeddedResource = "AppBarbearia.RelatorioCaixa.rdlc"
        Me.rpvRelatorioCaixa.Location = New System.Drawing.Point(0, 0)
        Me.rpvRelatorioCaixa.Name = "rpvRelatorioCaixa"
        Me.rpvRelatorioCaixa.Size = New System.Drawing.Size(645, 431)
        Me.rpvRelatorioCaixa.TabIndex = 0
        '
        'ClRelatorioPadraoSTRBindingSource
        '
        Me.ClRelatorioPadraoSTRBindingSource.DataSource = GetType(AppOtica.ClRelatorioPadraoSTR)
        '
        'FormRelatorioCaixa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 431)
        Me.Controls.Add(Me.rpvRelatorioCaixa)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRelatorioCaixa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório do Caixa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClRelatorioPadraoSTRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvRelatorioCaixa As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClRelatorioPadraoSTRBindingSource As System.Windows.Forms.BindingSource
End Class
