<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaClientes
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
        Me.rptvListaClientes = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptvListaClientes
        '
        Me.rptvListaClientes.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ClientesDS"
        ReportDataSource1.Value = Me.ClClienteBindingSource
        Me.rptvListaClientes.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rptvListaClientes.LocalReport.ReportEmbeddedResource = "AppOtica.RelatorioListaClientes.rdlc"
        Me.rptvListaClientes.Location = New System.Drawing.Point(0, 0)
        Me.rptvListaClientes.Name = "rptvListaClientes"
        Me.rptvListaClientes.ShowRefreshButton = False
        Me.rptvListaClientes.ShowStopButton = False
        Me.rptvListaClientes.Size = New System.Drawing.Size(920, 508)
        Me.rptvListaClientes.TabIndex = 0
        '
        'ClClienteBindingSource
        '
        Me.ClClienteBindingSource.DataSource = GetType(AppOtica.ClCliente)
        '
        'FormListaClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 508)
        Me.Controls.Add(Me.rptvListaClientes)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormListaClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Clientes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptvListaClientes As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClClienteBindingSource As System.Windows.Forms.BindingSource
End Class
