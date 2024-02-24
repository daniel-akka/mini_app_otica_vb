<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReciboComissao
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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.RwReciboComissao = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'RwReciboComissao
        '
        Me.RwReciboComissao.AutoSize = True
        Me.RwReciboComissao.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource3.Name = "DataSetEmpresa"
        ReportDataSource4.Name = "DataSetComissao"
        Me.RwReciboComissao.LocalReport.DataSources.Add(ReportDataSource3)
        Me.RwReciboComissao.LocalReport.DataSources.Add(ReportDataSource4)
        Me.RwReciboComissao.LocalReport.ReportEmbeddedResource = "AppBarbearia.RptReciboComissao.rdlc"
        Me.RwReciboComissao.Location = New System.Drawing.Point(0, 0)
        Me.RwReciboComissao.Name = "RwReciboComissao"
        Me.RwReciboComissao.ShowFindControls = False
        Me.RwReciboComissao.ShowRefreshButton = False
        Me.RwReciboComissao.ShowStopButton = False
        Me.RwReciboComissao.ShowZoomControl = False
        Me.RwReciboComissao.Size = New System.Drawing.Size(503, 420)
        Me.RwReciboComissao.TabIndex = 0
        '
        'FormReciboComissao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 420)
        Me.Controls.Add(Me.RwReciboComissao)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormReciboComissao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibo de Comissao"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RwReciboComissao As Microsoft.Reporting.WinForms.ReportViewer
End Class
