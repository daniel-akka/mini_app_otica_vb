Imports Microsoft.Reporting.WinForms
Public Class FormListaSubGrupo

    Public _ListaSubGrupos As New List(Of ClSubGrupoDespMensalImpr)
    Public _FiltroGrupo As String = ""
    Public _FiltroDescricao As String = ""

    Dim _somaValor As Double = 0

    Private Sub FormListaSubGrupo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaLista()
        Me.rptvListaSubGrupo.RefreshReport()
    End Sub

    Sub CarregaLista()

        Me.rptvListaSubGrupo.LocalReport.DataSources.Clear()
        SomaValores()
        'Set Paramentros
        Dim mFiltroGrupo As New ReportParameter("rpGrupoPesq", _FiltroGrupo)
        Dim mFiltroDescr As New ReportParameter("rpDescricaoPesq", _FiltroDescricao)
        Dim mSoma As New ReportParameter("rpSomaValores", _somaValor.ToString("#,##0.00"))
        Me.rptvListaSubGrupo.LocalReport.SetParameters(mFiltroGrupo)
        Me.rptvListaSubGrupo.LocalReport.SetParameters(mFiltroDescr)
        Me.rptvListaSubGrupo.LocalReport.SetParameters(mSoma)

        Me.rptvListaSubGrupo.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaSubGrupos.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("SubGrupoDSImpressao", _ListaSubGrupos)
        Me.rptvListaSubGrupo.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaSubGrupos
        Me.rptvListaSubGrupo.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rptvListaSubGrupo.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
    End Sub

    Sub SomaValores()
        _somaValor = 0
        For Each s As ClSubGrupoDespMensalImpr In _ListaSubGrupos
            If IsNumeric(s.sgp_valorpadrao) Then _somaValor += CDbl(s.sgp_valorpadrao)
        Next
    End Sub

End Class