<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaComissoes
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
        Me.rpvListaComissoes = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClComissaoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClComissaoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvListaComissoes
        '
        Me.rpvListaComissoes.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ComissaoDS"
        ReportDataSource1.Value = Me.ClComissaoBindingSource
        Me.rpvListaComissoes.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaComissoes.LocalReport.ReportEmbeddedResource = "AppBarbearia.RelatorioListaComissoes.rdlc"
        Me.rpvListaComissoes.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaComissoes.Name = "rpvListaComissoes"
        Me.rpvListaComissoes.Size = New System.Drawing.Size(615, 430)
        Me.rpvListaComissoes.TabIndex = 0
        '
        'ClComissaoBindingSource
        '
        Me.ClComissaoBindingSource.DataSource = GetType(AppOtica.ClComissao)
        '
        'FormListaComissoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 430)
        Me.Controls.Add(Me.rpvListaComissoes)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormListaComissoes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Comissões"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClComissaoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaComissoes As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClComissaoBindingSource As System.Windows.Forms.BindingSource
End Class
