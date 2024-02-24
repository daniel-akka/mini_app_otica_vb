Imports Microsoft.Reporting.WinForms
Public Class FormListaServicos

    Public _listaServicos As New List(Of ClServicos)
    Public _listaServicosSTR As New List(Of ClRelatorioPadraoSTR)
    Public QtdeRegistro As Integer = 0
    Public FiltroServico As String = ""
    Public FiltroAtendente As String = ""

    Private Sub FormListaServicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaLista()
        Me.rpvListaServicos.RefreshReport()
    End Sub

    Sub CarregaLista()

        Me.rpvListaServicos.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mQtdeRegistros As New ReportParameter("rpQtdeRegistros", QtdeRegistro)
        Dim mFiltroServico As New ReportParameter("rpFiltroServico", FiltroServico)
        Dim mFiltroAtendente As New ReportParameter("rpFiltroAtendente", FiltroAtendente)
        Me.rpvListaServicos.LocalReport.SetParameters(mFiltroServico)
        Me.rpvListaServicos.LocalReport.SetParameters(mFiltroAtendente)
        Me.rpvListaServicos.LocalReport.SetParameters(mQtdeRegistros)

        Me.rpvListaServicos.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaServicos.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("ServicosStrDS", _listaServicosSTR)
        Me.rpvListaServicos.LocalReport.DataSources.Add(ds)
        ds.Value = _listaServicosSTR
        Me.rpvListaServicos.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaServicos.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
    End Sub

End Class