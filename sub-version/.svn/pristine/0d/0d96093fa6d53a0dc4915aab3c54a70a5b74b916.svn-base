Imports Microsoft.Reporting.WinForms
Public Class FormListaContasAPagar

    Public _ListaContasAPagar As New List(Of ClAPagarTotal)
    Public _FiltroSituacao As String = ""
    Public _FiltroData As String = ""
    Public _FiltroCliente As String = ""
    Dim _somaValor As Double = 0

    Private Sub FormListaContasAPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregarLista()
        Me.rptvListaContasAPagar.RefreshReport()
    End Sub

    Sub CarregarLista()

        Me.rptvListaContasAPagar.LocalReport.DataSources.Clear()
        SomaValores()
        'Set Paramentros
        Dim mFiltroSituacao As New ReportParameter("rpFiltroSituacao", _FiltroSituacao)
        Dim mFiltroData As New ReportParameter("rpFiltroData", _FiltroData)
        Dim mFiltroCliente As New ReportParameter("rpFiltroCliente", _FiltroCliente)
        Dim mSoma As New ReportParameter("rpSomaValores", _somaValor.ToString("#,##0.00"))
        Me.rptvListaContasAPagar.LocalReport.SetParameters(mFiltroSituacao)
        Me.rptvListaContasAPagar.LocalReport.SetParameters(mFiltroData)
        Me.rptvListaContasAPagar.LocalReport.SetParameters(mFiltroCliente)
        Me.rptvListaContasAPagar.LocalReport.SetParameters(mSoma)

        Me.rptvListaContasAPagar.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaContasAPagar.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("APagarTotalDS", _ListaContasAPagar)
        Me.rptvListaContasAPagar.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaContasAPagar
        Me.rptvListaContasAPagar.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rptvListaContasAPagar.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

    Sub SomaValores()
        _somaValor = _ListaContasAPagar.Sum(Function(a As ClAPagarTotal) a.apt_valor)
    End Sub

End Class