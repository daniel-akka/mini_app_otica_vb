<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaSubGrupo
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
        Me.rptvListaSubGrupo = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClSubGrupoDespMensalImprBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClSubGrupoDespMensalImprBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptvListaSubGrupo
        '
        Me.rptvListaSubGrupo.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "SubGrupoDSImpressao"
        ReportDataSource1.Value = Me.ClSubGrupoDespMensalImprBindingSource
        Me.rptvListaSubGrupo.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptvListaSubGrupo.LocalReport.ReportEmbeddedResource = "AppBarbearia.RelatorioListaSubGrupos.rdlc"
        Me.rptvListaSubGrupo.Location = New System.Drawing.Point(0, 0)
        Me.rptvListaSubGrupo.Name = "rptvListaSubGrupo"
        Me.rptvListaSubGrupo.ShowRefreshButton = False
        Me.rptvListaSubGrupo.ShowStopButton = False
        Me.rptvListaSubGrupo.Size = New System.Drawing.Size(719, 486)
        Me.rptvListaSubGrupo.TabIndex = 0
        '
        'ClSubGrupoDespMensalImprBindingSource
        '
        Me.ClSubGrupoDespMensalImprBindingSource.DataSource = GetType(AppOtica.ClSubGrupoDespMensalImpr)
        '
        'FormListaSubGrupo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 486)
        Me.Controls.Add(Me.rptvListaSubGrupo)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormListaSubGrupo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista dos SubGrupos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClSubGrupoDespMensalImprBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptvListaSubGrupo As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClSubGrupoDespMensalImprBindingSource As System.Windows.Forms.BindingSource
End Class
