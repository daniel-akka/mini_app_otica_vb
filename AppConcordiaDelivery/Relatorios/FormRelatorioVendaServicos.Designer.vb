﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRelatorioVendaServicos
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
        Me.rpvRelatorioVendaServicos = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ClRelatorioPadraoSTRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.ClRelatorioPadraoSTRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rpvRelatorioVendaServicos
        '
        Me.rpvRelatorioVendaServicos.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "RelatorioPadraoStrDS"
        ReportDataSource1.Value = Me.ClRelatorioPadraoSTRBindingSource
        Me.rpvRelatorioVendaServicos.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rpvRelatorioVendaServicos.LocalReport.ReportEmbeddedResource = "AppBarbearia.RelatorioVendaServico.rdlc"
        Me.rpvRelatorioVendaServicos.Location = New System.Drawing.Point(0, 0)
        Me.rpvRelatorioVendaServicos.Name = "rpvRelatorioVendaServicos"
        Me.rpvRelatorioVendaServicos.ShowRefreshButton = False
        Me.rpvRelatorioVendaServicos.ShowStopButton = False
        Me.rpvRelatorioVendaServicos.Size = New System.Drawing.Size(642, 414)
        Me.rpvRelatorioVendaServicos.TabIndex = 0
        '
        'ClRelatorioPadraoSTRBindingSource
        '
        Me.ClRelatorioPadraoSTRBindingSource.DataSource = GetType(AppOtica.ClRelatorioPadraoSTR)
        '
        'FormRelatorioVendaServicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 414)
        Me.Controls.Add(Me.rpvRelatorioVendaServicos)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FormRelatorioVendaServicos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório de Vendas Serviços"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ClRelatorioPadraoSTRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpvRelatorioVendaServicos As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ClRelatorioPadraoSTRBindingSource As System.Windows.Forms.BindingSource
End Class
