Imports Microsoft.Reporting.WinForms
Public Class FormListaProdutos

    Public _ListaProdutos As New List(Of ClProduto)
    Public _FiltroDescricao As String = ""

    Private Sub FormListaProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaLista()
        Me.rpvListaProdutos.RefreshReport()
    End Sub

    Sub CarregaLista()

        Dim mTotalRegistros As New ReportParameter("rpTotalRegistros", _ListaProdutos.Count.ToString)
        Dim mDescricao As New ReportParameter("rpDescricaoPesq", _FiltroDescricao)
        Me.rpvListaProdutos.LocalReport.SetParameters(mTotalRegistros)
        Me.rpvListaProdutos.LocalReport.SetParameters(mDescricao)
        

        Me.rpvListaProdutos.LocalReport.DataSources.Clear()
        Me.rpvListaProdutos.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaProdutos.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("DsProdutos", _ListaProdutos)
        Me.rpvListaProdutos.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaProdutos
        Me.rpvListaProdutos.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaProdutos.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
    End Sub

End Class