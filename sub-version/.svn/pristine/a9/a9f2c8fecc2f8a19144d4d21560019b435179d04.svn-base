<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRelatorioSaudePessoa
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
        Me.rpvSaudePessoa = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClInfoSaudePessoaItemBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClInfoSaudePessoaItemBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvSaudePessoa
        '
        Me.rpvSaudePessoa.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "SaudePessoaItemDS"
        ReportDataSource1.Value = Me.ClInfoSaudePessoaItemBindingSource
        Me.rpvSaudePessoa.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvSaudePessoa.LocalReport.ReportEmbeddedResource = "AppBarbearia.RelatorioSaudePessoa.rdlc"
        Me.rpvSaudePessoa.Location = New System.Drawing.Point(0, 0)
        Me.rpvSaudePessoa.Name = "rpvSaudePessoa"
        Me.rpvSaudePessoa.ShowBackButton = False
        Me.rpvSaudePessoa.ShowFindControls = False
        Me.rpvSaudePessoa.ShowPageNavigationControls = False
        Me.rpvSaudePessoa.ShowRefreshButton = False
        Me.rpvSaudePessoa.ShowStopButton = False
        Me.rpvSaudePessoa.Size = New System.Drawing.Size(601, 425)
        Me.rpvSaudePessoa.TabIndex = 0
        '
        'ClInfoSaudePessoaItemBindingSource
        '
        Me.ClInfoSaudePessoaItemBindingSource.DataSource = GetType(AppOtica.ClInfoSaudePessoaItem)
        '
        'FormRelatorioSaudePessoa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 425)
        Me.Controls.Add(Me.rpvSaudePessoa)
        Me.MinimizeBox = False
        Me.Name = "FormRelatorioSaudePessoa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informações de Saúde da Pessoa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClInfoSaudePessoaItemBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvSaudePessoa As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClInfoSaudePessoaItemBindingSource As System.Windows.Forms.BindingSource
End Class
