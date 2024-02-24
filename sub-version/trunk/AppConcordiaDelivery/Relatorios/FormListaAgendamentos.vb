Imports Microsoft.Reporting.WinForms
Public Class FormListaAgendamentos

    Public _ListaRelatorio As New List(Of ClRelatorioPadraoSTR)
    Public _FiltroPessoa As String = ""
    Public _FiltroSituacao As String = ""
    Public _FiltroData As String = ""
    Public _FiltroTurno As String = ""
    Public _FiltroAtendente As String = ""
    Public somaQtde As Double = 0
    Public somaValores As Double = 0

    Private Sub FormListaAgendamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregarLista()
        Me.rpvListaAgendamentos.RefreshReport()
    End Sub

    Sub CarregarLista()

        Me.rpvListaAgendamentos.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mFiltroSituacao As New ReportParameter("rpFiltroSituacao", _FiltroSituacao)
        Dim mFiltroData As New ReportParameter("rpFiltroData", _FiltroData)
        Dim mFiltroCliente As New ReportParameter("rpFiltroCliente", _FiltroPessoa)
        Dim mFiltroAtendente As New ReportParameter("rpFiltroAtendente", _FiltroAtendente)
        Dim mFiltroTurno As New ReportParameter("rpFiltroTurno", _FiltroTurno)
        Dim mSomaQtde As New ReportParameter("rpSomaQtde", CInt(somaQtde))
        Dim mSomaValores As New ReportParameter("rpSomaValores", somaValores.ToString("#,##0.00"))

        Me.rpvListaAgendamentos.LocalReport.SetParameters(mFiltroSituacao)
        Me.rpvListaAgendamentos.LocalReport.SetParameters(mFiltroData)
        Me.rpvListaAgendamentos.LocalReport.SetParameters(mFiltroCliente)
        Me.rpvListaAgendamentos.LocalReport.SetParameters(mFiltroAtendente)
        Me.rpvListaAgendamentos.LocalReport.SetParameters(mFiltroTurno)
        Me.rpvListaAgendamentos.LocalReport.SetParameters(mSomaQtde)
        Me.rpvListaAgendamentos.LocalReport.SetParameters(mSomaValores)

        Me.rpvListaAgendamentos.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaAgendamentos.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("RelatorioStrDS", _ListaRelatorio)
        Me.rpvListaAgendamentos.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaRelatorio
        Me.rpvListaAgendamentos.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvListaAgendamentos.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub
End Class