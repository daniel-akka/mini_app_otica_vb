Imports Microsoft.Reporting.WinForms
Public Class FormListaFichasOtica

    Public _ListaFichasSTR As New List(Of ClRelatorioPadraoSTR)
    Public _FiltroTipoData As String = ""
    Public _FiltroData As String = ""
    Public _FiltroCliente As String = ""
    Public _somaValor As Double = 0

    Private Sub FormListaFichasOtica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregarLista()
        Me.rptvListaFichasOtica.RefreshReport()
    End Sub

    Sub CarregarLista()

        Me.rptvListaFichasOtica.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mFiltroSituacao As New ReportParameter("rpFiltroTipoData", _FiltroTipoData)
        Dim mFiltroData As New ReportParameter("rpFiltroData", _FiltroData)
        Dim mFiltroCliente As New ReportParameter("rpFiltroCliente", _FiltroCliente)
        Dim mTotalRegistros As New ReportParameter("rpTotalRegistros", _ListaFichasSTR.Count)
        Dim mTotalValores As New ReportParameter("rpTotalValores", _somaValor.ToString("#,##0.00"))
        Me.rptvListaFichasOtica.LocalReport.SetParameters(mFiltroSituacao)
        Me.rptvListaFichasOtica.LocalReport.SetParameters(mFiltroData)
        Me.rptvListaFichasOtica.LocalReport.SetParameters(mFiltroCliente)
        Me.rptvListaFichasOtica.LocalReport.SetParameters(mTotalRegistros)
        Me.rptvListaFichasOtica.LocalReport.SetParameters(mTotalValores)

        Me.rptvListaFichasOtica.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaFichasOtica.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("DsRelatorioSTR", _ListaFichasSTR)
        Me.rptvListaFichasOtica.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaFichasSTR
        Me.rptvListaFichasOtica.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rptvListaFichasOtica.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

End Class