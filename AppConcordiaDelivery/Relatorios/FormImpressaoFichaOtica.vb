Imports Microsoft.Reporting.WinForms
Public Class FormImpressaoFichaOtica

    'Objetos da Ficha:
    Public _Ficha As New List(Of ClFichaOtica)
    Public _CLiente As New List(Of ClCliente)
    Public _Empresa As New List(Of ClEmpresa)
    Public _AssinaturaFicha As New List(Of ClFichaOticaAssinatura)

    'Lista de Objetos:
    Public _ListaFichaProdutos As New List(Of ClFichaOticaProduto)
    Public _ListaFichaOlho As New List(Of ClFichaOticaOlho)
    Public _ListaFichaPrestacoes As New List(Of ClFichaOticaPrestacoes)

    'Parametros:
    Public EnderecoEmp As String
    Public BairroEmp, CidadeEmp, EstadoEmp As String
    Public FoneEmp As String

    Private Sub FormImpressaoFichaOtica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregarLista()
        Me.rptvImpressaoFichaOtica.RefreshReport()
    End Sub

    Sub CarregarLista()

        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Clear()

        'Set Paramentros
        Dim mFiltroEmpresa1 As New ReportParameter("rpFiltroEmpresa1", EnderecoEmp)
        Dim mFiltroEmpresa2 As New ReportParameter("rpFiltroEmpresa2", BairroEmp & "  " & CidadeEmp & " - " & EstadoEmp)

        If Not IsNothing(FoneEmp) Then

            If Not FoneEmp.Equals("") Then
                FoneEmp = "Fone: " & FoneEmp
            End If
        End If
        
        Dim mFiltroEmpresa3 As New ReportParameter("rpFiltroEmpresa3", FoneEmp)
        Me.rptvImpressaoFichaOtica.LocalReport.SetParameters(mFiltroEmpresa1)
        Me.rptvImpressaoFichaOtica.LocalReport.SetParameters(mFiltroEmpresa2)
        Me.rptvImpressaoFichaOtica.LocalReport.SetParameters(mFiltroEmpresa3)

        Me.rptvImpressaoFichaOtica.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".ImpressaoFichaOtica.rdlc"

        Dim dsEmp As New Microsoft.Reporting.WinForms.ReportDataSource("DsEmpresa", _Empresa)
        Dim dsCli As New Microsoft.Reporting.WinForms.ReportDataSource("DsCliente", _CLiente)
        Dim dsFicha As New Microsoft.Reporting.WinForms.ReportDataSource("DsFichaOtica", _Ficha)
        Dim dsProdutoFicha As New Microsoft.Reporting.WinForms.ReportDataSource("DsProdutoFicha", _ListaFichaProdutos)
        Dim dsOlhoFicha As New Microsoft.Reporting.WinForms.ReportDataSource("DsOlhoFicha", _ListaFichaOlho)
        Dim dsPrestacoesFicha As New Microsoft.Reporting.WinForms.ReportDataSource("DsPrestacoesFicha", _ListaFichaPrestacoes)
        Dim dsAssinaturaFicha As New Microsoft.Reporting.WinForms.ReportDataSource("DsAssinaturaFicha", _AssinaturaFicha)

        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(dsEmp)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(dsCli)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(dsFicha)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(dsProdutoFicha)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(dsOlhoFicha)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(dsPrestacoesFicha)
        Me.rptvImpressaoFichaOtica.LocalReport.DataSources.Add(dsAssinaturaFicha)

        dsEmp.Value = _Empresa
        dsCli.Value = _CLiente
        dsFicha.Value = _Ficha
        dsProdutoFicha.Value = _ListaFichaProdutos
        dsOlhoFicha.Value = _ListaFichaOlho
        dsPrestacoesFicha.Value = _ListaFichaPrestacoes
        dsAssinaturaFicha.Value = _AssinaturaFicha

        Me.rptvImpressaoFichaOtica.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rptvImpressaoFichaOtica.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

End Class