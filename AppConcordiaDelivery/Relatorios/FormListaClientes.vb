Imports Microsoft.Reporting.WinForms
Public Class FormListaClientes

    Public _ListaClientes As New List(Of ClCliente)
    Public _FiltroCliente As String = ""
    Public _FiltroUF As String = ""
    Public _FiltroCIDADE As String = ""
    Public _FiltroINATIVOS As String = ""

    Private Sub FormListaClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaLista()
        Me.rptvListaClientes.RefreshReport()
    End Sub

    Sub CarregaLista()

        Dim mTotalRegistros As New ReportParameter("rpTotalRegistros", _ListaClientes.Count.ToString)
        Dim mCliente As New ReportParameter("rpCliente", _FiltroCliente)
        Dim mUF As New ReportParameter("rpUf", _FiltroUF)
        Dim mCIDADE As New ReportParameter("rpCidade", _FiltroCIDADE)
        Dim mINATIVOS As New ReportParameter("rpInativos", _FiltroINATIVOS)
        Me.rptvListaClientes.LocalReport.SetParameters(mTotalRegistros)
        Me.rptvListaClientes.LocalReport.SetParameters(mCliente)
        Me.rptvListaClientes.LocalReport.SetParameters(mUF)
        Me.rptvListaClientes.LocalReport.SetParameters(mCIDADE)
        Me.rptvListaClientes.LocalReport.SetParameters(mINATIVOS)

        Me.rptvListaClientes.LocalReport.DataSources.Clear()
        Me.rptvListaClientes.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioListaClientes.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("ClientesDS", _ListaClientes)
        Me.rptvListaClientes.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaClientes
        Me.rptvListaClientes.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rptvListaClientes.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
    End Sub
End Class