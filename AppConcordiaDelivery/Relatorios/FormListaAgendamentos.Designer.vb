<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaAgendamentos
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
        Me.rpvListaAgendamentos = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClRelatorioPadraoSTRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClRelatorioPadraoSTRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvListaAgendamentos
        '
        Me.rpvListaAgendamentos.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "RelatorioStrDS"
        ReportDataSource1.Value = Me.ClRelatorioPadraoSTRBindingSource
        Me.rpvListaAgendamentos.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaAgendamentos.LocalReport.ReportEmbeddedResource = "AppBarbearia.RelatorioListaAgendamentos.rdlc"
        Me.rpvListaAgendamentos.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaAgendamentos.Name = "rpvListaAgendamentos"
        Me.rpvListaAgendamentos.Size = New System.Drawing.Size(695, 387)
        Me.rpvListaAgendamentos.TabIndex = 0
        '
        'ClRelatorioPadraoSTRBindingSource
        '
        Me.ClRelatorioPadraoSTRBindingSource.DataSource = GetType(AppOtica.ClRelatorioPadraoSTR)
        '
        'FormListaAgendamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 387)
        Me.Controls.Add(Me.rpvListaAgendamentos)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormListaAgendamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Agendamentos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClRelatorioPadraoSTRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaAgendamentos As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClRelatorioPadraoSTRBindingSource As System.Windows.Forms.BindingSource
End Class
