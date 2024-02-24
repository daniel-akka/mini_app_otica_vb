<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaProdutos
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
        Me.rpvListaProdutos = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClProdutoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClProdutoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvListaProdutos
        '
        Me.rpvListaProdutos.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DsProdutos"
        ReportDataSource1.Value = Me.ClProdutoBindingSource
        Me.rpvListaProdutos.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvListaProdutos.LocalReport.ReportEmbeddedResource = "AppOtica.RelatorioListaProdutos.rdlc"
        Me.rpvListaProdutos.Location = New System.Drawing.Point(0, 0)
        Me.rpvListaProdutos.Name = "rpvListaProdutos"
        Me.rpvListaProdutos.ShowRefreshButton = False
        Me.rpvListaProdutos.ShowStopButton = False
        Me.rpvListaProdutos.Size = New System.Drawing.Size(611, 393)
        Me.rpvListaProdutos.TabIndex = 0
        '
        'ClProdutoBindingSource
        '
        Me.ClProdutoBindingSource.DataSource = GetType(AppOtica.ClProduto)
        '
        'FormListaProdutos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 393)
        Me.Controls.Add(Me.rpvListaProdutos)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormListaProdutos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Produtos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClProdutoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvListaProdutos As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClProdutoBindingSource As System.Windows.Forms.BindingSource
End Class
