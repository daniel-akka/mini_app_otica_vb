Imports Microsoft.Reporting.WinForms
Public Class FormRelatorioCaixa
    Public _ListaRelatorioSTR As New List(Of ClRelatorioPadraoSTR)
    Public TotalDN As Double = 0, TotalCTC As Double = 0, TotalCTD As Double = 0, TotalPIX As Double = 0
    Public TotalTRA As Double = 0, TotalCRD As Double = 0, TotalGeral As Double = 0
    Public TotalSaidas As Double = 0, TotalEntradas As Double = 0, TotalTroco As Double = 0
    Public TotRecebimentoCli As Double = 0, SubTotal As Double = 0, TotalLiquido As Double = 0
    Public FiltroPeriodo As String = ""

    Private Sub FormRelatorioCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregarLista()
        Me.rpvRelatorioCaixa.RefreshReport()
    End Sub

    Sub CarregarLista()

        Me.rpvRelatorioCaixa.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mTotGERAL As New ReportParameter("rpTotalGeral", TotalGeral.ToString("#,##0.00"))
        Dim mTotDN As New ReportParameter("rpTotalDN", TotalDN.ToString("#,##0.00"))
        Dim mTotCTC As New ReportParameter("rpTotalCTC", TotalCTC.ToString("#,##0.00"))
        Dim mTotCTD As New ReportParameter("rpTotalCTD", TotalCTD.ToString("#,##0.00"))
        Dim mTotPIX As New ReportParameter("rpTotalPIX", TotalPIX.ToString("#,##0.00"))
        Dim mTotTRA As New ReportParameter("rpTotalTRA", TotalTRA.ToString("#,##0.00"))
        Dim mTotCRD As New ReportParameter("rpTotalCRD", TotalCRD.ToString("#,##0.00"))
        Dim mTotENTRADAS As New ReportParameter("rpTotalEntradas", TotalEntradas.ToString("#,##0.00"))
        Dim mTotSAIDAS As New ReportParameter("rpTotalSaidas", TotalSaidas.ToString("#,##0.00"))
        Dim mTotLiquido As New ReportParameter("rpTotalLiquido", TotalLiquido.ToString("#,##0.00"))
        Dim mTotTROCO As New ReportParameter("rpTotalTroco", TotalTroco.ToString("#,##0.00"))
        Dim mTotRecebimento As New ReportParameter("rpRecebimento", TotRecebimentoCli.ToString("#,##0.00"))
        Dim mSubTotal As New ReportParameter("rpSubTotal", SubTotal.ToString("#,##0.00"))
        Dim mPeriodo As New ReportParameter("rpFiltroPeriodo", FiltroPeriodo)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotGERAL)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotDN)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotCTC)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotCTD)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotPIX)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotTRA)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotCRD)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotENTRADAS)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotSAIDAS)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotTROCO)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotRecebimento)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mSubTotal)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mPeriodo)
        Me.rpvRelatorioCaixa.LocalReport.SetParameters(mTotLiquido)
        
        Me.rpvRelatorioCaixa.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioCaixa.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("RelatorioStrDS", _ListaRelatorioSTR)
        Me.rpvRelatorioCaixa.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaRelatorioSTR
        Me.rpvRelatorioCaixa.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvRelatorioCaixa.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

End Class