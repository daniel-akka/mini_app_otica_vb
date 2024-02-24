Imports Microsoft.Reporting.WinForms
Public Class FormListaComissoes

    Public _listaComissoes As New List(Of ClComissao)
    Public _filtroData As String
    Public _filtroAtendente As String
    Dim somaValores As Double

    Private Sub FormListaComissoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaLista()
        Me.rpvListaComissoes.RefreshReport()
    End Sub

    Sub CarregaLista()
        somaValoresLista()

        Me.rpvListaComissoes.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mAtendente As New ReportParameter("rpAtendente", _filtroAtendente)
        Dim mData As New ReportParameter("rpData", _filtroData)
        Dim mQtdeRegistros As New ReportParameter("rpQtdeRegistros", _listaComissoes.Count)
        Dim mSomaValores As New ReportParameter("rpSomaValores", somaValores.ToString("#,##0.00"))
        Me.rpvListaComissoes.LocalReport.SetParameters(mAtendente)
        Me.rpvListaComissoes.LocalReport.SetParameters(mData)
        Me.rpvListaComissoes.LocalReport.SetParameters(mQtdeRegistros)
        Me.rpvListaComissoes.LocalReport.SetParameters(mSomaValores)

        Me.rpvListaComissoes.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaComissoes.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("ComissaoDS", _listaComissoes)
        Me.rpvListaComissoes.LocalReport.DataSources.Add(ds)
        ds.Value = _listaComissoes
        Me.rpvListaComissoes.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaComissoes.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

    Sub somaValoresLista()
        somaValores = 0
        For Each c As ClComissao In _listaComissoes
            somaValores += c.c_valorpago
        Next
    End Sub

End Class