Imports Microsoft.Reporting.WinForms
Public Class FormListaContasAReceber

    Public _ListaContasAReceber As New List(Of ClAReceberTotal)
    Public _FiltroSituacao As String = ""
    Public _FiltroData As String = ""
    Public _FiltroCliente As String = ""
    Dim _somaValor As Double = 0

    Private Sub FormListaContasAReceber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregarLista()
        Me.rptvListaContasAReceber.RefreshReport()
    End Sub

    Sub CarregarLista()

        Me.rptvListaContasAReceber.LocalReport.DataSources.Clear()
        SomaValores()
        'Set Paramentros
        Dim mFiltroSituacao As New ReportParameter("rpFiltroSituacao", _FiltroSituacao)
        Dim mFiltroData As New ReportParameter("rpFiltroData", _FiltroData)
        Dim mFiltroCliente As New ReportParameter("rpFiltroCliente", _FiltroCliente)
        Dim mSoma As New ReportParameter("rpSomaValores", _somaValor.ToString("#,##0.00"))
        Me.rptvListaContasAReceber.LocalReport.SetParameters(mFiltroSituacao)
        Me.rptvListaContasAReceber.LocalReport.SetParameters(mFiltroData)
        Me.rptvListaContasAReceber.LocalReport.SetParameters(mFiltroCliente)
        Me.rptvListaContasAReceber.LocalReport.SetParameters(mSoma)

        Me.rptvListaContasAReceber.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaContasAReceber.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("AReceberTotalDS", _ListaContasAReceber)
        Me.rptvListaContasAReceber.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaContasAReceber
        Me.rptvListaContasAReceber.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rptvListaContasAReceber.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

    Sub SomaValores()
        _somaValor = _ListaContasAReceber.Sum(Function(a As ClAReceberTotal) a.art_valor)
    End Sub

End Class