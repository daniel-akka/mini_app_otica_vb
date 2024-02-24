<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaServicos
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
        Me.rpvListaServicos = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClRelatorioPadraoSTRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClRelatorioPadraoSTRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvListaServicos
        '
        Me.rpvListaServicos.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ServicosStrDS"
        ReportDataSource1.Value = Me.ClRelatorioPadraoSTRBindingSource
        Me.rpvListaServicos.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaServicos.LocalReport.ReportEmbeddedResource = "AppBarbearia.RelatorioListaServicos.rdlc"
        Me.rpvListaServicos.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaServicos.Name = "rpvListaServicos"
        Me.rpvListaServicos.Size = New System.Drawing.Size(559, 381)
        Me.rpvListaServicos.TabIndex = 0
        '
        'ClRelatorioPadraoSTRBindingSource
        '
        Me.ClRelatorioPadraoSTRBindingSource.DataSource = GetType(AppOtica.ClRelatorioPadraoSTR)
        '
        'FormListaServicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 381)
        Me.Controls.Add(Me.rpvListaServicos)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormListaServicos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Servicos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClRelatorioPadraoSTRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaServicos As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClRelatorioPadraoSTRBindingSource As System.Windows.Forms.BindingSource
End Class
