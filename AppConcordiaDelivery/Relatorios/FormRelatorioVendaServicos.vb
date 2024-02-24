Imports Microsoft.Reporting.WinForms
Public Class FormRelatorioVendaServicos

    Public _ListaServicos As New List(Of ClRelatorioPadraoSTR)
    Public _FiltroData As String = "", _FiltroServico As String = "", _FiltroCliente As String = ""
    Public _FiltroAtendente As String = ""
    Public _QtdeVendas As Integer = 0, _QtdeServicos As Integer = 0, SomaTotalGeral As Double = 0

    'Totais:
    Public SubTotal As Double = 0, TotDesconto As Double = 0, TotDN As Double = 0, TotCTC As Double = 0, TotCTD As Double = 0, TotPIX As Double = 0
    Public TotTRA As Double = 0, TotCRD As Double = 0

    Private Sub FormRelatorioVendaServicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaLista()
        Me.rpvRelatorioVendaServicos.RefreshReport()
    End Sub

    Sub CarregaLista()

        Dim mFiltroServico As New ReportParameter("rpServico", _FiltroServico)
        Dim mCliente As New ReportParameter("rpCliente", _FiltroCliente)
        Dim mData As New ReportParameter("rpData", _FiltroData)
        Dim mAtendente As New ReportParameter("rpAtendente", _FiltroAtendente)
        Dim mQtdeVendas As New ReportParameter("rpQtdeVendas", _QtdeVendas)
        Dim mQtdeServicos As New ReportParameter("rpQtdeServicos", _QtdeServicos)
        Dim mTotalGeral As New ReportParameter("rpTotalGeral", SomaTotalGeral.ToString("#,##0.00"))
        Dim mSubTotal As New ReportParameter("rpTotalSubTotal", SubTotal.ToString("#,##0.00"))
        Dim mTotDesconto As New ReportParameter("rpTotalDesconto", TotDesconto.ToString("#,##0.00"))
        Dim mTotDN As New ReportParameter("rpTotalDN", TotDN.ToString("#,##0.00"))
        Dim mTotCTC As New ReportParameter("rpTotalCTC", TotCTC.ToString("#,##0.00"))
        Dim mTotCTD As New ReportParameter("rpTotalCTD", TotCTD.ToString("#,##0.00"))
        Dim mTotPIX As New ReportParameter("rpTotalPIX", TotPIX.ToString("#,##0.00"))
        Dim mTotTRA As New ReportParameter("rpTotalTRA", TotTRA.ToString("#,##0.00"))
        Dim mTotCRD As New ReportParameter("rpTotalCRD", TotCRD.ToString("#,##0.00"))

        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mFiltroServico)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mCliente)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mData)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mAtendente)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mQtdeVendas)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mQtdeServicos)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mTotalGeral)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mSubTotal)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mTotDesconto)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mTotDN)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mTotCTC)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mTotCTD)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mTotPIX)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mTotTRA)
        Me.rpvRelatorioVendaServicos.LocalReport.SetParameters(mTotCRD)

        Me.rpvRelatorioVendaServicos.LocalReport.DataSources.Clear()
        Me.rpvRelatorioVendaServicos.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioVendaServico.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("RelatorioPadraoStrDS", _ListaServicos)
        Me.rpvRelatorioVendaServicos.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaServicos
        Me.rpvRelatorioVendaServicos.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvRelatorioVendaServicos.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
    End Sub

End Class