Imports Microsoft.Reporting.WinForms
Public Class FormListaDespesasMensal

    Public _ListaDespMensal As New List(Of ClDespesaMensalmpressao)
    Public _FiltroGrupo As String = ""
    Public _FiltroDescricaoSubGrupo As String = ""
    Public _FiltroDtInicial As String = ""
    Public _FiltroDtFinal As String = ""
    Public _FiltroObservacao As String = ""
    Dim _somaValor As Double = 0

    Private Sub FormListaDespesasMensal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaLista()
        Me.rpvListaDespesasMensal.RefreshReport()
    End Sub

    Sub CarregaLista()

        Me.rpvListaDespesasMensal.LocalReport.DataSources.Clear()
        SomaValores()
        'Set Paramentros
        Dim mFiltroGrupo As New ReportParameter("rpGrupo", _FiltroGrupo)
        Dim mFiltroDescr As New ReportParameter("rpSubGrupo", _FiltroDescricaoSubGrupo)
        Dim mFiltroDtInicial As New ReportParameter("rpDataInicial", _FiltroDtInicial)
        Dim mFiltroDtFinal As New ReportParameter("rpDataFinal", _FiltroDtFinal)
        Dim mFiltroObservacao As New ReportParameter("rpObservacao", _FiltroObservacao)
        Dim mSoma As New ReportParameter("rpSomaValores", _somaValor.ToString("#,##0.00"))
        Me.rpvListaDespesasMensal.LocalReport.SetParameters(mFiltroGrupo)
        Me.rpvListaDespesasMensal.LocalReport.SetParameters(mFiltroDescr)
        Me.rpvListaDespesasMensal.LocalReport.SetParameters(mFiltroDtInicial)
        Me.rpvListaDespesasMensal.LocalReport.SetParameters(mFiltroDtFinal)
        Me.rpvListaDespesasMensal.LocalReport.SetParameters(mFiltroObservacao)
        Me.rpvListaDespesasMensal.LocalReport.SetParameters(mSoma)

        Me.rpvListaDespesasMensal.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaDespesasMensal.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("DespesaMensalImpressaoDS", _ListaDespMensal)
        Me.rpvListaDespesasMensal.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaDespMensal
        Me.rpvListaDespesasMensal.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaDespesasMensal.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
    End Sub

    Sub SomaValores()
        _somaValor = 0
        For Each s As ClDespesaMensalmpressao In _ListaDespMensal
            If IsNumeric(s.dm_valor) Then

                If IsDate(s.dm_data_despesa) Then _somaValor += CDbl(s.dm_valor)
            End If

        Next
    End Sub

End Class