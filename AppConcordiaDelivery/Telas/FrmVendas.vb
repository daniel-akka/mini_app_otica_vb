Public Class FrmVendas

    Dim _ruaDAO As New ClRuaDAO
    Dim _Rua As New ClRua
    Dim _Atendente As New ClAtendente
    Dim _Entregador As New ClAtendente
    'Dim _Cliente As New 
    Dim _Produto As New ClProduto
    Dim _Bairro As New ClBairro
    Dim _BairroDAO As New ClBairroDAO
    Dim _ProdutoDAO As New ClProdutoDAO
    Dim _AtententeDAO As New ClAtendenteDAO
    Dim _EntregadorDAO As New ClAtendenteDAO

    Private Sub FrmVendas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmVendas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmVendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.Text = "::Vendas - " & Application.ProductName
        Me.Text = Application.ProductName
        tbpVenda.Text = ""
        tbpVizualizaVendas.Text = ""

        _ruaDAO.PreencheCboRuasLista(cboRua, MdlConexaoBD.mdlListRuas)
        _BairroDAO.PreencheCboBairrosLista(cboBairro, MdlConexaoBD.mdlListBairros)

        ZeraValores()
    End Sub

    Private Sub btnVizualizaVendas_Click(sender As Object, e As EventArgs) Handles btnVizualizaVendas.Click
        tabControl.SelectTab(1)
    End Sub

    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        tabControl.SelectTab(0)
    End Sub

    Sub ZeraValores()
        txtCidadeCli.Text = MdlConexaoBD.mdlPadraoSistema.pscidade
        txtEstadoCli.Text = MdlConexaoBD.mdlPadraoSistema.psestado
    End Sub
End Class