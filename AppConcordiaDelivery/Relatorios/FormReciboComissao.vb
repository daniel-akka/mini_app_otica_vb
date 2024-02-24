Imports Microsoft.Reporting.WinForms
Public Class FormReciboComissao

    Public _empresa As New ClEmpresa
    Public _comissao As New ClComissao
    Public _TipoComissao As String = "SERVIÇOS"
    Dim _funcoes As New ClFuncoes

    Public Sub CarregarDados()
        Dim mCnpjCpf As String = ""
        Dim mParamInscrito As String = ""
        If _empresa.empCnpj.Equals("") = False Then

            mParamInscrito = ", inscrito no CNPJ: "
            mCnpjCpf = _empresa.empCnpj
        ElseIf _empresa.empCPF.Equals("") = False Then

            mParamInscrito = ", inscrito no CPF: "
            mCnpjCpf = _empresa.empCPF
        End If


        'Parametros:
        Dim mInscrito As New ReportParameter("rParamInscrito", mParamInscrito)
        Dim mRazaoEmpresa As New ReportParameter("rParamRazaoEmpresa", _empresa.emprazaosocial)
        Dim mParamCnpjCpf As New ReportParameter("rParamCnpjCPF", mCnpjCpf)
        Dim mTipoComissao As New ReportParameter("rParamTipoComissao", _TipoComissao)
        Dim mValorPago As New ReportParameter("rParamValorPago", _comissao.c_valorpago.ToString("#,##0.00"))
        Dim mDataPagamento As New ReportParameter("rParamDataPagamento", _comissao.c_datapagamento.ToShortDateString & " " & _comissao.c_datapagamento.ToShortTimeString)
        Dim mValorPagoExtenso As New ReportParameter("rParamValorPagoExtenso", _funcoes.Mostra_Extenso(_comissao.c_valorpago))

        RwReciboComissao.LocalReport.SetParameters(mInscrito)
        RwReciboComissao.LocalReport.SetParameters(mRazaoEmpresa)
        RwReciboComissao.LocalReport.SetParameters(mParamCnpjCpf)
        RwReciboComissao.LocalReport.SetParameters(mTipoComissao)
        RwReciboComissao.LocalReport.SetParameters(mValorPago)
        RwReciboComissao.LocalReport.SetParameters(mDataPagamento)
        RwReciboComissao.LocalReport.SetParameters(mValorPagoExtenso)

        Me.RwReciboComissao.RefreshReport()
        Me.RwReciboComissao.SetDisplayMode(DisplayMode.PrintLayout)
        Me.RwReciboComissao.ZoomMode = ZoomMode.PageWidth

    End Sub

    Private Sub FormReciboComissao_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregarDados()
    End Sub
End Class