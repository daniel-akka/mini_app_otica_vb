Imports Npgsql
Imports System.Math
Imports System.Globalization
Public Class FormFichaOtica

    'Objetos:
    Dim _Empresa As New ClEmpresa
    Dim _Cliente As New ClCliente
    Dim _Produto As New ClProduto
    Dim _Ficha As New ClFichaOtica
    Dim _FichaProduto As New ClFichaOticaProduto
    Dim _FichaOlho As New ClFichaOticaOlho
    Dim _FichaPrestacoes As New ClFichaOticaPrestacoes
    Dim _FichaAssinatura As New ClFichaOticaAssinatura
    Dim _AReceberDAO As New ClAReceberTotalDAO

    'Lista de Objetos:
    Dim _ListaFichas As New List(Of ClFichaOtica)
    Dim _ListaFichaProdutos As New List(Of ClFichaOticaProduto)
    Dim _ListaFichaOlho As New List(Of ClFichaOticaOlho)
    Dim _ListaFichaPrestacoes As New List(Of ClFichaOticaPrestacoes)
    Dim _ListaRelatorio As New List(Of ClRelatorioPadraoSTR)


    'Variáveis de Controle:
    Dim _funcoes As New ClFuncoes
    Dim Operacao As String = ""
    Dim _Query As String = ""
    Dim _strAuxiliar As String = ""
    Dim _IdProduto As Integer = 0
    Dim _somaValoresRelatorio As Double

    Private Sub btnProximo_Click(sender As Object, e As EventArgs) Handles btnProximo.Click
        tbcFicha.SelectTab(2)
    End Sub

    Private Sub btnVoltar3_Click(sender As Object, e As EventArgs) Handles btnVoltar3.Click
        tbcFicha.SelectTab(1)
    End Sub

    Private Sub btnHome2_Click(sender As Object, e As EventArgs) Handles btnHome2.Click
        tbcFicha.SelectTab(0)
    End Sub

    Private Sub FormFichaOtica_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FormFichaOtica_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                ExecutaF2()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
            Case Keys.F9
                ExecutaF9()
            Case Keys.F11
                ExecutaF11()
        End Select
    End Sub

    Private Sub FormFichaOtica_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _Empresa.setValores(MdlConexaoBD.mdlEmpresa)
        ExecutaF5()
    End Sub


#Region "Funções e Métodos de Controle"

    Function VerificaExistProdutoDataGrid() As Boolean

        Dim vExiste As Boolean = False

        If _dtg_produtos.Rows.Count > 0 Then

            For Each r As DataGridViewRow In _dtg_produtos.Rows

                If Not r.IsNewRow Then

                    If r.Cells(1).Value = _Produto.pId Then

                        vExiste = True
                        Exit For
                    End If
                End If
            Next
        End If

        Return vExiste
    End Function

    Function VerificaExistProdutoDataGrid_OE_OD(ByVal vIdProd As Integer) As Boolean

        Dim vExiste As Boolean = False

        If _dtg_produtos.Rows.Count > 0 Then

            For Each r As DataGridViewRow In _dtgOeOd.Rows

                If Not r.IsNewRow Then

                    If r.Cells(2).Value = vIdProd Then

                        vExiste = True
                        Exit For
                    End If
                End If
            Next
        End If

        Return vExiste
    End Function

    Sub SubstitueValoresProdutosDataGrid()

        Dim vExiste As Boolean = False

        If _dtg_produtos.Rows.Count > 0 Then

            For Each r As DataGridViewRow In _dtg_produtos.Rows

                If Not r.IsNewRow Then

                    If r.Cells(1).Value = _Produto.pId Then


                        If CDbl(txtProdutoTotal.Text) <= 0 Then MsgBox("Informe um Valor e Quantidade para o Produto Selecionado!") : Return

                        
                        With _dtg_produtos.Rows(r.Index)

                            .Cells(2).Value = _Produto.pDescricao
                            .Cells(3).Value = CDbl(txtProdutoQtde.Text).ToString("#,##0.00")
                            .Cells(4).Value = CDbl(txtProdutoVlrUnitario.Text).ToString("#,##0.00")
                            .Cells(5).Value = CDbl(txtProdutoTotal.Text).ToString("#,##0.00")
                            .Cells(6).Value = _Produto.p_Cor
                            .Cells(7).Value = _Produto.p_Referencia
                            .Cells(8).Value = _Produto.pUnidade
                        End With

                        Exit For
                    End If
                End If

            Next
        End If

    End Sub

    Sub DesabilitaCamposFormulario()

        With Me

            'Frente:
            .txtFichaCodigo.ReadOnly = True
            .txtFichaCoordenador.ReadOnly = True
            .txtFichaLocalidade.ReadOnly = True
            .txtFichaNumContrato.ReadOnly = True
            .dtpFichaData.Enabled = False
            .txtIdCliente.Enabled = False
            .txtCodProduto.Enabled = False
            .btnAddProdFicha.Enabled = False
            ._dtg_produtos.ReadOnly = True
            ._dtgOeOd.ReadOnly = True
            .rtbObservacoesGerais.ReadOnly = True

            'Verso:
            ._dtgPrestacoes.ReadOnly = True
            .rtbDatasRetorno.ReadOnly = True
            .rtbObservacoes.ReadOnly = True
            .txtValorSoma.ReadOnly = True
            .txtValorEntrada.ReadOnly = True
            .txtValorSaldo.ReadOnly = True
            .txtValorPrestacoes.ReadOnly = True
            .mskDataEntrega.ReadOnly = True
            .mskDataEntrada.ReadOnly = True
            .mskDataPrestacoes.ReadOnly = True

            'Assinatura:
            .txtAssinNumero.ReadOnly = True
            .mskAssinDataVenc.ReadOnly = True
            .txtAssinValor.ReadOnly = True
            .txtAssinTexto1.ReadOnly = True
            .txtAssinEmpRazao.ReadOnly = True
            .txtAssinCnpj.ReadOnly = True
            .txtAssinValorExtenso.ReadOnly = True
            .txtAssinMoeda.ReadOnly = True
            .txtAssinCLienteNome.ReadOnly = True
            .mskAssinDataEmiss.ReadOnly = True
            .txtAssinClienteCnpj.ReadOnly = True
            .txtAssinClienteEndereco.ReadOnly = True
            .txtClienteAssinatura.ReadOnly = True

            .btnSalvar.Enabled = False
        End With
    End Sub

    Sub HabilitaCamposFormulario()

        With Me

            'Frente:
            .txtFichaCodigo.ReadOnly = False
            .txtFichaCoordenador.ReadOnly = False
            .txtFichaLocalidade.ReadOnly = False
            .txtFichaNumContrato.ReadOnly = False
            .dtpFichaData.Enabled = True
            .txtIdCliente.Enabled = True
            .txtCodProduto.Enabled = True
            .btnAddProdFicha.Enabled = True
            ._dtg_produtos.ReadOnly = False
            ._dtgOeOd.ReadOnly = False
            .rtbObservacoesGerais.ReadOnly = False

            'Verso:
            ._dtgPrestacoes.ReadOnly = False
            .rtbDatasRetorno.ReadOnly = False
            .rtbObservacoes.ReadOnly = False
            .txtValorSoma.ReadOnly = True
            .txtValorEntrada.ReadOnly = False
            .txtValorSaldo.ReadOnly = True
            .txtValorPrestacoes.ReadOnly = True
            .mskDataEntrega.ReadOnly = False
            .mskDataEntrada.ReadOnly = False
            .mskDataPrestacoes.ReadOnly = False

            'Assinatura:
            .txtAssinNumero.ReadOnly = False
            .mskAssinDataVenc.ReadOnly = False
            .txtAssinValor.ReadOnly = False
            .txtAssinTexto1.ReadOnly = False
            .txtAssinEmpRazao.ReadOnly = False
            .txtAssinCnpj.ReadOnly = False
            .txtAssinValorExtenso.ReadOnly = False
            .txtAssinMoeda.ReadOnly = False
            .txtAssinCLienteNome.ReadOnly = False
            .mskAssinDataEmiss.ReadOnly = False
            .txtAssinClienteCnpj.ReadOnly = False
            .txtAssinClienteEndereco.ReadOnly = False
            .txtClienteAssinatura.ReadOnly = False


            .btnSalvar.Enabled = True
        End With

    End Sub

    Sub LimpaCamposFormulario()

        With Me

            'Frente:
            .txtFichaCodigo.Text = ""
            .txtFichaCoordenador.Text = ""
            .txtFichaLocalidade.Text = ""
            .txtFichaNumContrato.Text = ""
            .dtpFichaData.Value = Date.Now
            .txtIdCliente.Text = ""
            .txtCodProduto.Text = ""
            .txtNomeCliente.Text = ""
            .txtNomeProduto.Text = ""
            .txtTelefoneCliente.Text = ""
            .txtProdutoQtde.Text = "0"
            .txtProdutoVlrUnitario.Text = "0,00"
            .txtProdutoTotal.Text = "0,00"
            ._dtg_produtos.Rows.Clear()
            ._dtgOeOd.Rows.Clear()
            .rtbObservacoesGerais.Text = ""

            'Verso:
            ._dtgPrestacoes.Rows.Clear()
            .rtbDatasRetorno.Text = ""
            .rtbObservacoes.Text = ""
            .txtValorSoma.Text = "0,00"
            .txtValorEntrada.Text = "0,00"
            .txtValorSaldo.Text = "0,00"
            .txtValorPrestacoes.Text = "0,00"
            .mskDataEntrega.Text = ""
            .mskDataEntrada.Text = ""
            .mskDataPrestacoes.Text = ""

            'Assinatura:
            .txtAssinNumero.Text = ""
            .mskAssinDataVenc.Text = ""
            .txtAssinValor.Text = "0,00"
            .txtAssinTexto1.Text = ""
            .txtAssinEmpRazao.Text = _Empresa.emprazaosocial
            .txtAssinCnpj.Text = ""
            If Not _Empresa.empCnpj.Equals("") Then

                .txtAssinCnpj.Text = _Empresa.empCnpj
            ElseIf Not _Empresa.empCPF.Equals("") Then

                .txtAssinCnpj.Text = _Empresa.empCPF
            End If

            .txtAssinValorExtenso.Text = ""
            .txtAssinMoeda.Text = "REAIS R$"
            .txtAssinCLienteNome.Text = ""
            .mskAssinDataEmiss.Text = ""
            .txtAssinClienteCnpj.Text = ""
            .txtAssinClienteEndereco.Text = ""
            .txtClienteAssinatura.Text = ""

        End With

    End Sub

    Sub PreencheValoresFormulario()


        With Me

            'Frente:
            .txtFichaCodigo.Text = _Ficha.fo_id.ToString.PadLeft(9, "0")
            .txtFichaCoordenador.Text = _Ficha.fo_coordenador
            .txtFichaLocalidade.Text = _Ficha.fo_localidade
            .txtFichaNumContrato.Text = _Ficha.fo_num_contrato
            .dtpFichaData.Value = _Ficha.fo_data_ficha
            .txtIdCliente.Text = _Ficha.fo_cliente_id
            .txtNomeCliente.Text = _Ficha.fo_cliente_nome
            .txtTelefoneCliente.Text = _Ficha.fo_cliente_fone

            PreenchDtgProdutoFicha()
            PreenchDtgOlhoFicha()

            .rtbObservacoesGerais.Text = _Ficha.fo_observacoes_gerais

            'Verso:
            PreenchDtgPrestacoesFicha()
            .rtbDatasRetorno.Text = _Ficha.fo_datas_retorno
            .rtbObservacoes.Text = _Ficha.fo_observacoes
            .txtValorSoma.Text = _Ficha.fo_soma.ToString("#,##0.00")
            .txtValorEntrada.Text = _Ficha.fo_entrada.ToString("#,##0.00")
            .txtValorSaldo.Text = _Ficha.fo_saldo.ToString("#,##0.00")
            .txtValorPrestacoes.Text = _Ficha.fo_prestacoes.ToString("#,##0.00")
            .mskDataEntrega.Text = _Ficha.fo_data_entrega
            .mskDataEntrada.Text = _Ficha.fo_data_entrada
            .mskDataPrestacoes.Text = _Ficha.fo_data_prestacoes

            'Assinatura:
            .txtAssinNumero.Text = _FichaAssinatura.fa_numero
            .mskAssinDataVenc.Text = _FichaAssinatura.fa_vencimento
            .txtAssinValor.Text = _FichaAssinatura.fa_valor.ToString("#,##0.00")
            .txtAssinTexto1.Text = _FichaAssinatura.fa_texto1
            .txtAssinEmpRazao.Text = _FichaAssinatura.fa_empresa_razao
            .txtAssinCnpj.Text = _FichaAssinatura.fa_empresa_cnpj_cpf
            .txtAssinValorExtenso.Text = _FichaAssinatura.fa_valor_extenso
            .txtAssinMoeda.Text = _FichaAssinatura.fa_moeda
            .txtAssinCLienteNome.Text = _FichaAssinatura.fa_cliente_nome
            .mskAssinDataEmiss.Text = _FichaAssinatura.fa_data_emissao
            .txtAssinClienteCnpj.Text = _FichaAssinatura.fa_cliente_cnpj_cpf
            .txtAssinClienteEndereco.Text = _FichaAssinatura.fa_cliente_endereco
            .txtClienteAssinatura.Text = _FichaAssinatura.fa_assinatura_cliente

        End With

    End Sub

    Sub PreencheValoresFicha()


        With _Ficha

            'Frente:
            If Not txtFichaCodigo.Text.Equals("") Then .fo_id = CInt(txtFichaCodigo.Text)

            .fo_coordenador = Me.txtFichaCoordenador.Text
            .fo_num_contrato = Me.txtFichaNumContrato.Text
            .fo_localidade = Me.txtFichaLocalidade.Text
            .fo_data_ficha = Me.dtpFichaData.Value
            .fo_cliente_id = CInt(Me.txtIdCliente.Text)
            .fo_cliente_nome = Me.txtNomeCliente.Text
            .fo_cliente_fone = Me.txtTelefoneCliente.Text

            .fo_observacoes_gerais = Me.rtbObservacoesGerais.Text

            'Verso:
            .fo_datas_retorno = Me.rtbDatasRetorno.Text
            .fo_observacoes = Me.rtbObservacoes.Text
            .fo_soma = Me.txtValorSoma.Text
            .fo_entrada = Me.txtValorEntrada.Text
            .fo_saldo = Me.txtValorSaldo.Text
            .fo_data_prestacoes = Me.txtValorPrestacoes.Text
            .fo_data_entrada = Me.mskDataEntrega.Text
            .fo_data_entrada = Me.mskDataEntrada.Text
            .fo_data_prestacoes = Me.mskDataPrestacoes.Text

        End With

    End Sub

    Sub PreencheValoresAssinatura(ByVal vFicha As ClFichaOtica)

        With _FichaAssinatura

            'Assinatura:
            .fa_ficha_id = vFicha.fo_id
            .fa_numero = Me.txtAssinNumero.Text
            .fa_vencimento = Me.mskAssinDataVenc.Text
            .fa_valor = Me.txtAssinValor.Text
            .fa_texto1 = Me.txtAssinTexto1.Text
            .fa_empresa_razao = Me.txtAssinEmpRazao.Text
            .fa_empresa_cnpj_cpf = Me.txtAssinCnpj.Text
            .fa_valor_extenso = Me.txtAssinValorExtenso.Text
            .fa_moeda = Me.txtAssinMoeda.Text
            .fa_cliente_nome = Me.txtAssinCLienteNome.Text
            .fa_data_emissao = Me.mskAssinDataEmiss.Text
            .fa_cliente_cnpj_cpf = Me.txtAssinClienteCnpj.Text
            .fa_cliente_endereco = Me.txtAssinClienteEndereco.Text
            .fa_assinatura_cliente = Me.txtClienteAssinatura.Text
        End With

    End Sub

    Sub LimpaValoresObjetos()

        _Ficha.ZeraValores()
        _ListaFichaProdutos.Clear()
        _ListaFichaOlho.Clear()
        _ListaFichaPrestacoes.Clear()
        _FichaAssinatura.ZeraValores()

    End Sub

    Sub PreencheValoresObjetos()

        _Ficha.fo_id = _dtgFicha.CurrentRow.Cells(0).Value
        _Ficha.TrazFichaOtica(_Ficha, MdlConexaoBD.conectionPadrao)
        _FichaAssinatura.TrazFichaOticaAssinatura_IdFicha_BD(_Ficha, _FichaAssinatura, MdlConexaoBD.conectionPadrao)
        _FichaProduto.TrazFichaOticaProduto_IdFicha_BD(_Ficha, _ListaFichaProdutos, MdlConexaoBD.conectionPadrao)
        _FichaOlho.TrazFichaOticaOlho_IdFicha_BD(_Ficha, _ListaFichaOlho, MdlConexaoBD.conectionPadrao)
        _FichaPrestacoes.TrazFichaOticaPrestacoes_IdFicha_BD(_Ficha, _ListaFichaPrestacoes, MdlConexaoBD.conectionPadrao)
        _Cliente.cid = _Ficha.fo_cliente_id
        _Cliente.TrazCliente(_Cliente, MdlConexaoBD.conectionPadrao)

        
    End Sub

    Sub PreenchDtgProdutoFicha()

        _dtg_produtos.Rows.Clear()
        For Each fp As ClFichaOticaProduto In _ListaFichaProdutos
            _dtg_produtos.Rows.Add("", fp.fop_produto_id, fp.fop_produto_nome, fp.fop_quantidade, fp.fop_preco_venda.ToString("#,##0.00"), fp.fop_total.ToString("#,##0.00"), fp.fop_cor, fp.fop_referencia, fp.fop_produto_unidade)
        Next
    End Sub

    Sub PreenchDtgOlhoFicha()

        _dtgOeOd.Rows.Clear()
        For Each fp As ClFichaOticaOlho In _ListaFichaOlho
            _dtgOeOd.Rows.Add(dtgCboOdOe.Index = 0, dtgCboDistancia.Index = 0, fp.foo_produto_id, fp.foo_produto_nome, fp.foo_esf, fp.foo_cil, fp.foo_eix, fp.foo_dnp)

        Next
    End Sub

    Sub PreenchDtgPrestacoesFicha()

        _dtgPrestacoes.Rows.Clear()
        For Each fp As ClFichaOticaPrestacoes In _ListaFichaPrestacoes
            _dtgPrestacoes.Rows.Add(fp.fpp_data.ToShortDateString, fp.fpp_valor.ToString("#,##0.00"), fp.fpp_visto, fp.fpp_prestacao)
        Next
    End Sub

    Sub PreencheListaFichaProdutos(ByVal vFicha As ClFichaOtica)

        Dim vProduto As New ClFichaOticaProduto
        If IsNothing(vFicha) Then MsgBox("A Ficha Ótica está vazia... Infome uma Ficha Válida!") : Return
        _ListaFichaProdutos.Clear()
        For Each r As DataGridViewRow In _dtg_produtos.Rows

            If Not r.IsNewRow Then

                With vProduto

                    .fop_ficha_id = vFicha.fo_id
                    .fop_produto_id = r.Cells(1).Value
                    .fop_produto_nome = r.Cells(2).Value
                    .fop_quantidade = r.Cells(3).Value
                    .fop_preco_venda = r.Cells(4).Value
                    .fop_total = r.Cells(5).Value
                    .fop_cor = r.Cells(6).Value
                    .fop_referencia = r.Cells(7).Value
                    .fop_produto_unidade = r.Cells(8).Value
                End With

                _ListaFichaProdutos.Add(New ClFichaOticaProduto(vProduto))
                vProduto.ZeraValores()
            End If

        Next
    End Sub

    Sub PreencheListaFichaOlhos(ByVal vFicha As ClFichaOtica)

        Dim vOlho As New ClFichaOticaOlho
        If IsNothing(vFicha) Then MsgBox("A Ficha Ótica está vazia... Infome uma Ficha Válida!") : Return
        _ListaFichaOlho.Clear()
        For Each r As DataGridViewRow In _dtgOeOd.Rows

            If Not r.IsNewRow Then

                With vOlho

                    .foo_ficha_id = vFicha.fo_id
                    .foo_olho = r.Cells(0).Value.ToString
                    .foo_distancia = r.Cells(1).Value.ToString
                    .foo_produto_id = r.Cells(2).Value
                    .foo_produto_nome = r.Cells(3).Value
                    .foo_esf = r.Cells(4).Value
                    .foo_cil = r.Cells(5).Value
                    .foo_eix = r.Cells(6).Value
                    .foo_dnp = r.Cells(7).Value
                End With

                _ListaFichaOlho.Add(New ClFichaOticaOlho(vOlho))
                vOlho.ZeraValores()
            End If

        Next
    End Sub

    Sub PreencheListaFichaPrestacoes(ByVal vFicha As ClFichaOtica)

        Dim vPrestacao As New ClFichaOticaPrestacoes
        If IsNothing(vFicha) Then MsgBox("A Ficha Ótica está vazia... Infome uma Ficha Válida!") : Return
        _ListaFichaPrestacoes.Clear()
        For Each r As DataGridViewRow In _dtgPrestacoes.Rows

            If Not r.IsNewRow Then

                With vPrestacao

                    .fpp_ficha_id = vFicha.fo_id
                    .fpp_data = r.Cells(0).Value
                    .fpp_valor = r.Cells(1).Value
                    .fpp_visto = r.Cells(2).Value
                    .fpp_prestacao = r.Cells(3).Value
                End With

                _ListaFichaPrestacoes.Add(New ClFichaOticaPrestacoes(vPrestacao))
                vPrestacao.ZeraValores()
            End If

        Next
    End Sub

    Sub SalvarFichaOtica()

        'Preenchendo os Valores dos Objetos:
        PreencheValoresFicha()

        'Salvando os Objetos:
        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                conexao = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = conexao.BeginTransaction

            'Persistindo o Objeto Ficha:
            If Operacao.Equals("I") Then

                _Ficha.incFichaOtica(_Ficha, conexao, transacao)
                _Ficha.fo_id = _Ficha.TrazIdUltimaFicha_Incluida(conexao, transacao)

            ElseIf Operacao.Equals("A") Then

                _Ficha.altFichaOtica(_Ficha, conexao, transacao)

            End If

            'Persistindo Objeto Assinatura Ficha:
            PreencheValoresAssinatura(_Ficha)
            _FichaAssinatura.delFichaOticaAssinatura_IdFicha(_Ficha, conexao, transacao)
            _FichaAssinatura.incFichaOticaAssinatura(_FichaAssinatura, conexao, transacao)

            'Persistindo objeto PRODUTOS Ficha:
            PreencheListaFichaProdutos(_Ficha)
            _FichaProduto.delFichaOticaProduto_IdFicha(_Ficha, conexao, transacao)
            For Each fp As ClFichaOticaProduto In _ListaFichaProdutos
                _FichaProduto.incFichaOticaProduto(fp, conexao, transacao)
            Next

            'Persistindo objeto OLHO Ficha:
            PreencheListaFichaOlhos(_Ficha)
            _FichaOlho.delFichaOticaOlho_IdFicha(_Ficha, conexao, transacao)
            For Each fo As ClFichaOticaOlho In _ListaFichaOlho
                _FichaOlho.incFichaOticaOlho(fo, conexao, transacao)
            Next

            'Persistindo objeto PRESTACOES Ficha:
            PreencheListaFichaPrestacoes(_Ficha)
            _FichaPrestacoes.delFichaOticaPrestacoes_IdFicha(_Ficha, conexao, transacao)
            For Each fp As ClFichaOticaPrestacoes In _ListaFichaPrestacoes
                _FichaPrestacoes.incFichaOticaPrestacoes(fp, conexao, transacao)
            Next

            'Lança CONTAS A RECEBER:
            If _AReceberDAO.VerificaFichaOtica_AReceberBD(_Ficha, MdlConexaoBD.conectionPadrao) Then

                MsgBox("Já Existe Prestações no Contas A Receber Lançadas para Essa FICHA! Estorne Primeiro No Contas a Receber para Incluir novas Prestações", MsgBoxStyle.Exclamation, Application.ProductName)
            Else

                If MessageBox.Show("Prestações serão Incluídas No Contas A Receber! Deseja Gravar a FICHA lançando as Prestações?", Application.ProductName, MessageBoxButtons.YesNo) _
                    = Windows.Forms.DialogResult.Yes Then
                    _Ficha.LancaFichaContasAReceber(_Ficha, _ListaFichaPrestacoes, conexao, transacao)
                End If

            End If

            transacao.Commit()
            MsgBox("Ficha Ótica Salva com Sucesso!", MsgBoxStyle.Exclamation)

            MdlConexaoBD.ListaFichaOtica.Clear()
            _Ficha.TrazListFichaOtica_BD(MdlConexaoBD.ListaFichaOtica, MdlConexaoBD.conectionPadrao)
            ExecutaF5()
            tbcFicha.SelectTab(0)
            txtPesquisaNomeCliente.Focus()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            conexao.ClearPool() : conexao.Close() : conexao = Nothing
        End Try



        'Comandos Finais:
        LimpaCamposFormulario()
        LimpaValoresObjetos()
        DesabilitaCamposFormulario()
        Operacao = ""
        tbcFicha.SelectTab(0)
        txtPesquisaNomeCliente.Focus()
        ExecutaF5()
        BloqueiaVisualiza()

    End Sub

    Sub CancelandoOperacao()

        LimpaCamposFormulario()
        LimpaValoresObjetos()
        DesabilitaCamposFormulario()
        Operacao = ""
        tbcFicha.SelectTab(0)
        BloqueiaVisualiza()

    End Sub

    Sub zeraValoresProduto()

        _Produto.ZeraValores()
        txtCodProduto.Text = ""
        txtNomeProduto.Text = ""
        txtProdutoQtde.Text = "0"
        txtProdutoVlrUnitario.Text = "0,00"
        txtProdutoTotal.Text = "0,00"

    End Sub

    Sub AdicionaProdutoGridView()

        If _Produto.pId <= 0 Then MsgBox("Informe um Produto para ser Adicionado!") : txtCodProduto.Focus() : Return

        If CDbl(txtProdutoTotal.Text) <= 0 Then MsgBox("Informe um Valor e Quantidade para o Produto Selecionado!") : Return

        _dtg_produtos.Rows.Add("", _Produto.pId, _Produto.pDescricao, txtProdutoQtde.Text, txtProdutoVlrUnitario.Text, txtProdutoTotal.Text, _Produto.p_Cor, _Produto.p_Referencia, _Produto.pUnidade)

    End Sub

    Sub AdicionaOlhoGridView()

        If Not _dtg_produtos.CurrentRow.IsNewRow Then

            _dtgOeOd.Rows.Add("", "", _dtg_produtos.CurrentRow.Cells(1).Value, _dtg_produtos.CurrentRow.Cells(2).Value)
        End If
    End Sub

#End Region


#Region "Funções da Aba Vizualização"

    Sub ExecutaF2()

        If Operacao.Equals("A") Then

            If MessageBox.Show("Já existe uma Alteração em Andamento, ela será cancelada! Deseja Continuar?", Application.CompanyName, MessageBoxButtons.YesNo) _
                = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If

        Operacao = "I"
        HabilitaCamposFormulario()
        LimpaCamposFormulario()
        LimpaValoresObjetos()
        tbcFicha.SelectTab(1)
        txtFichaCoordenador.Focus()
        DesbloqueiaVisualiza()
    End Sub

    Sub ExecutaF3()

        Try
            If _dtgFicha.CurrentRow.IsNewRow Then MsgBox("Selecione Uma Ficha para Poder Alterar") : Return
        Catch ex As Exception
            Return
        End Try

        If Operacao.Equals("A") Then

            If MessageBox.Show("Já existe uma Alteração em Andamento, ela será cancelada! Deseja Continuar?", Application.CompanyName, MessageBoxButtons.YesNo) _
                = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If

        Operacao = "A"
        HabilitaCamposFormulario()
        LimpaCamposFormulario()
        LimpaValoresObjetos()
        PreencheValoresObjetos()
        PreencheValoresFormulario()
        tbcFicha.SelectTab(1)
        txtFichaCoordenador.Focus()
        DesbloqueiaVisualiza()
    End Sub

    Sub ExecutaF5()

        If MdlConexaoBD.ListaFichaOtica.Count > 0 Then
            PreencheDtgFichas_LISTA()
        Else
            PreencheDtgFichas_BD()
        End If
    End Sub

    Sub ExecutaF11()

        _Ficha.TrazListFichaOtica_BD(MdlConexaoBD.ListaFichaOtica, MdlConexaoBD.conectionPadrao)
        PreencheLISTA_FICHAS_Relatorio()
        If _ListaFichas.Count > 0 Then

            Dim mListaRelatorio As New List(Of ClFichaOtica)
            Dim mFicha As New ClFichaOtica
            For Each l As ClFichaOtica In _ListaFichas
                mFicha.ZeraValores()
                mFicha.SetaFichaOtica(l)
                mListaRelatorio.Add(New ClFichaOtica(mFicha))
            Next

            Dim mFormulario As New FormListaFichasOtica
            mFormulario._ListaFichasSTR = _ListaRelatorio
            If chkPesquisarPorData.Checked Then

                If rbCadastro.Checked Then mFormulario._FiltroTipoData = "Cadastro:"
                If rbFicha.Checked Then mFormulario._FiltroTipoData = "Ficha:"
                mFormulario._FiltroData = dtpInicial.Text & "  a  " & dtpFinal.Text
            Else
                mFormulario._FiltroTipoData = ":"
                mFormulario._FiltroData = ""
            End If

            mFormulario._FiltroCliente = txtPesquisaNomeCliente.Text
            mFormulario._somaValor = _somaValoresRelatorio
            mFormulario.ShowDialog()
            mFormulario = Nothing

        End If

    End Sub

    Sub ExecutaF9()

        If ValidacoesAntesSalvar() = False Then Return
        SalvarFichaOtica()
    End Sub


    Sub PreencheDtgFichas_LISTA()

        Dim vStrFiltro As String = ""
        _ListaFichas.Clear()
        _dtgFicha.Rows.Clear()

        '********************           Filtros           **********************
        'Nome do Cliente:
        vStrFiltro = Trim(txtPesquisaNomeCliente.Text)
        If Not vStrFiltro.Equals("") Then
            _ListaFichas = MdlConexaoBD.ListaFichaOtica.FindAll(Function(f As ClFichaOtica) f.fo_cliente_nome.Contains(vStrFiltro))
        Else
            _ListaFichas = _Ficha.TrazListaFichaOtica_LIST(MdlConexaoBD.ListaFichaOtica)
        End If

        'Período das Datas:
        If chkPesquisarPorData.Checked Then

            If dtpFinal.Text < dtpInicial.Text Then
                MsgBox("Data Inicial Deve ser Menor ou IGUAL a Data Final", MsgBoxStyle.Information, Application.ProductName)
                Return
            End If

            If rbFicha.Checked Then
                _ListaFichas = _ListaFichas.FindAll(Function(f As ClFichaOtica) f.fo_data_ficha.ToShortDateString >= dtpInicial.Text And _
                                                        f.fo_data_ficha.ToShortDateString <= dtpFinal.Text)
            End If

            If rbCadastro.Checked Then
                _ListaFichas = _ListaFichas.FindAll(Function(f As ClFichaOtica) f.fo_data_cadastro.ToShortDateString >= dtpInicial.Text And _
                                                        f.fo_data_cadastro.ToShortDateString <= dtpFinal.Text)
            End If

        End If

        'Preenche o Data Grid:
        For Each f As ClFichaOtica In _ListaFichas

            _dtgFicha.Rows.Add(f.fo_id, f.fo_cliente_id & " - " & f.fo_cliente_nome, f.fo_data_ficha.ToShortDateString, f.fo_data_cadastro.ToShortDateString, f.fo_saldo.ToString("#,##0.00"), f.fo_data_alteracao)
        Next

    End Sub

    Sub PreencheLISTA_FICHAS_Relatorio()

        Dim vStrFiltro As String = ""
        _ListaFichas.Clear()
        _dtgFicha.Rows.Clear()

        '********************           Filtros           **********************
        'Nome do Cliente:
        vStrFiltro = Trim(txtPesquisaNomeCliente.Text)
        If Not vStrFiltro.Equals("") Then
            _ListaFichas = MdlConexaoBD.ListaFichaOtica.FindAll(Function(f As ClFichaOtica) f.fo_cliente_nome.Contains(vStrFiltro))
        Else
            _ListaFichas = _Ficha.TrazListaFichaOtica_LIST(MdlConexaoBD.ListaFichaOtica)
        End If

        'Período das Datas:
        If chkPesquisarPorData.Checked Then

            If dtpFinal.Text < dtpInicial.Text Then
                MsgBox("Data Inicial Deve ser Menor ou IGUAL a Data Final", MsgBoxStyle.Information, Application.ProductName)
                Return
            End If

            If rbFicha.Checked Then
                _ListaFichas = _ListaFichas.FindAll(Function(f As ClFichaOtica) f.fo_data_ficha.ToShortDateString >= dtpInicial.Text And _
                                                        f.fo_data_ficha.ToShortDateString <= dtpFinal.Text)
            End If

            If rbCadastro.Checked Then
                _ListaFichas = _ListaFichas.FindAll(Function(f As ClFichaOtica) f.fo_data_cadastro.ToShortDateString >= dtpInicial.Text And _
                                                        f.fo_data_cadastro.ToShortDateString <= dtpFinal.Text)
            End If

            _ListaRelatorio.Clear()
            _somaValoresRelatorio = 0
            Dim vRelatorio As New ClRelatorioPadraoSTR
            For Each i As ClFichaOtica In _ListaFichas

                With vRelatorio

                    .coluna1 = i.fo_id
                    .coluna2 = i.fo_cliente_id & " - " & i.fo_cliente_nome
                    .coluna3 = i.fo_data_ficha.ToShortDateString
                    .coluna4 = i.fo_data_cadastro.ToShortDateString
                    .coluna5 = i.fo_soma.ToString("#,##0.00")
                End With
                _somaValoresRelatorio += i.fo_soma
                _ListaRelatorio.Add(New ClRelatorioPadraoSTR(vRelatorio))
            Next
        End If

    End Sub

    Sub PreencheDtgFichas_BD()

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim vStrFiltro As String = ""
        _ListaFichas.Clear()
        _dtgFicha.Rows.Clear()
        _Query = ""
        _Query = "SELECT fo_id, fo_cliente_id, fo_cliente_nome, fo_data_cadastro, fo_data_ficha, fo_soma, fo_data_alteracao " '
        _Query += "FROM ficha_otica "
        '********************           Filtros           **********************
        'Nome do Cliente:
        vStrFiltro = Trim(txtPesquisaNomeCliente.Text)
        If Not vStrFiltro.Equals("") Then
            _Query += "WHERE fo_cliente_nome LIKE '" & vStrFiltro & "' "
        End If

        'Período das Datas:
        If chkPesquisarPorData.Checked Then


            If dtpFinal.Text < dtpInicial.Text Then
                MsgBox("Data Inicial Deve ser Menor ou IGUAL a Data Final", MsgBoxStyle.Information, Application.ProductName)
                Return
            End If

            If rbFicha.Checked Then

                If _Query.Contains("WHERE") Then
                    _Query += "AND fo_data_ficha BETWEEN '" & dtpInicial.Text & "' AND '" & dtpFinal.Text & "' "
                Else
                    _Query += "WHERE fo_data_ficha BETWEEN '" & dtpInicial.Text & "' AND '" & dtpFinal.Text & "' "
                End If
            End If

            If rbCadastro.Checked Then

                If _Query.Contains("WHERE") Then
                    _Query += "AND fo_data_cadastro BETWEEN '" & dtpInicial.Text & "' AND '" & dtpFinal.Text & "' "
                Else
                    _Query += "WHERE fo_data_cadastro BETWEEN '" & dtpInicial.Text & "' AND '" & dtpFinal.Text & "' "
                End If
            End If

        End If



        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaDAO:TrazListFichaOticas"":: " & ex.Message)
            Return
        End Try


        com = New NpgsqlCommand(_Query, conexao)
        dr = com.ExecuteReader

        While dr.Read

            _dtgFicha.Rows.Add(dr(0), dr(1).ToString & " - " & dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString("#,##0.00"), dr(6).ToString)
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub


#End Region


#Region "  TEXTO Busca Cliente"

    Private Sub txtIdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdCliente.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            buscaCliente()
        End If

    End Sub

    Sub buscaCliente()

        _strAuxiliar = ""
        _Cliente.ZeraValores()
        If IsNumeric(txtIdCliente.Text) Then


            _Cliente.cid = CInt(txtIdCliente.Text)
            _Cliente.TrazClienteDaListaClientes(_Cliente, MdlConexaoBD.ListaClientes)

            'Aqui tenta chamar o Formulario de Busca do Fornecedor...
            Try

                If _Cliente.cnome.Equals("") Then

                    Dim frmResponse As New FrmClienteResp
                    frmResponse.ShowDialog()
                    _Cliente.SetaValores(frmResponse._cliente)
                    frmResponse = Nothing
                Else
                    txtNomeCliente.Text = _Cliente.cnome.ToUpper
                End If

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        Else

            'Aqui tenta chamar o Formulario de Busca do Fornecedor...
            Try

                If _Cliente.cnome.Equals("") Then

                    Dim frmResponse As New FrmClienteResp
                    frmResponse.ShowDialog()
                    _Cliente.SetaValores(frmResponse._cliente)
                    frmResponse = Nothing
                Else
                    txtNomeCliente.Text = _Cliente.cnome.ToUpper
                End If

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        End If

        If _Cliente.cid <= 0 Then
            'Aba frente:
            txtIdCliente.Text = "" : txtNomeCliente.Text = ""
            txtTelefoneCliente.Text = ""

            'Aba Verso:
            txtClienteAssinatura.Text = ""
            txtAssinCLienteNome.Text = ""
            txtAssinClienteEndereco.Text = ""
            txtAssinClienteCnpj.Text = ""

            txtIdCliente.Focus() : txtIdCliente.SelectAll()
            txtNomeCliente.ReadOnly = False
            DesfazCamposCliente()
        Else

            'Aba Frente:
            txtIdCliente.Text = _Cliente.cid
            txtNomeCliente.Text = _Cliente.cnome
            txtTelefoneCliente.Text = _Cliente.ctelefone

            'Aba Verso:
            txtClienteAssinatura.Text = _Cliente.cnome
            txtAssinCLienteNome.Text = _Cliente.cnome
            txtAssinClienteEndereco.Text = _Cliente.cendereco
            txtAssinClienteCnpj.Text = _funcoes.formataCNPJ_CPF(_Cliente.cCpfCnpj)

            txtAssinEmpRazao.Text = MdlConexaoBD.mdlEmpresa.emprazaosocial
            If Not MdlConexaoBD.mdlEmpresa.empCnpj.Equals("") Then

                txtAssinCnpj.Text = _funcoes.formataCNPJ_CPF(MdlConexaoBD.mdlEmpresa.empCnpj)

            ElseIf Not MdlConexaoBD.mdlEmpresa.empCPF.Equals("") Then

                txtAssinCnpj.Text = _funcoes.formataCNPJ_CPF(MdlConexaoBD.mdlEmpresa.empCPF)
            End If


            txtNomeCliente.ReadOnly = True
            PreencheCamposCLiente()
            txtNomeCliente.Focus()
        End If

    End Sub

    Private Sub txtIdCliente_Leave(sender As Object, e As EventArgs) Handles txtIdCliente.Leave

        If IsNumeric(txtIdCliente.Text) Then

            Dim mCliente As New ClCliente
            mCliente.cid = CInt(txtIdCliente.Text)
            _Cliente.TrazClienteDaListaClientes(mCliente, MdlConexaoBD.ListaClientes)
            If mCliente.cid < 1 Then

                _Cliente.ZeraValores()
                txtIdCliente.Text = ""
                txtNomeCliente.Text = ""
            Else

                _Cliente.SetaValores(mCliente)
                txtIdCliente.Text = _Cliente.cid
                txtNomeCliente.Text = _Cliente.cnome
            End If
        Else
            _Cliente.ZeraValores()
        End If

    End Sub

    Private Sub txtIdCliente_Click(sender As Object, e As EventArgs) Handles txtIdCliente.Click
        txtIdCliente.SelectAll()
    End Sub

    Private Sub txtNomeCliente_GotFocus(sender As Object, e As EventArgs) Handles txtNomeCliente.GotFocus

        If _Cliente.cid < 1 Then
            txtNomeCliente.Text = ""
            txtNomeCliente.ReadOnly = False
            DesfazCamposCliente()
        Else
            PreencheCamposCLiente()
            txtNomeCliente.ReadOnly = True
        End If
        txtNomeCliente.SelectAll()
    End Sub

    Sub PreencheCamposCLiente()

        txtIdCliente.Text = _Cliente.cid
        txtNomeCliente.Text = _Cliente.cnome
        txtTelefoneCliente.Text = _Cliente.ctelefone

    End Sub

    Sub DesfazCamposCliente()

        txtIdCliente.Text = ""
        txtNomeCliente.Text = ""
        txtTelefoneCliente.Text = ""
        _Cliente.ZeraValores()

    End Sub

#End Region


#Region "  TEXTO Busca Produto"

    Private Sub txtCodProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodProduto.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            buscaProduto()
        End If

    End Sub

    Sub buscaProduto()

        _strAuxiliar = ""
        _Produto.ZeraValores()
        If IsNumeric(txtCodProduto.Text) Then


            _Produto.pId = CInt(txtCodProduto.Text)
            _Produto.TrazProdutoDaListaPorID(_Produto, MdlConexaoBD.ListaProdutos)

            'Aqui tenta chamar o Formulario de Busca do Produto...
            Try

                If _Produto.pDescricao.Equals("") Then

                    Dim frmResponse As New FrmProdutoResp
                    frmResponse.ShowDialog()
                    _Produto.setaValores(frmResponse._produto)
                    frmResponse = Nothing
                Else
                    txtNomeProduto.Text = _Produto.pDescricao.ToUpper
                End If

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        Else

            'Aqui tenta chamar o Formulario de Busca do Produto...
            Try

                If _Produto.pDescricao.Equals("") Then

                    Dim frmResponse As New FrmProdutoResp
                    frmResponse.ShowDialog()
                    _Produto.setaValores(frmResponse._produto)
                    frmResponse = Nothing
                Else
                    txtNomeProduto.Text = _Produto.pDescricao.ToUpper
                End If

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        End If

        If _Produto.pId <= 0 Then
            txtCodProduto.Text = "" : txtNomeProduto.Text = ""
            txtCodProduto.Focus() : txtCodProduto.SelectAll()
            txtCodProduto.ReadOnly = False
            DesfazCamposProduto()
        Else
            txtCodProduto.Text = _Produto.pId
            txtNomeProduto.Text = _Produto.pDescricao
            _Produto.TrazProdutoDaListaPorID(_Produto, MdlConexaoBD.ListaProdutos)
            txtProdutoQtde.Text = "1"
            txtProdutoVlrUnitario.Text = _Produto.pVenda.ToString("#,##0.00")
            txtProdutoTotal.Text = _Produto.pVenda.ToString("#,##0.00")
            txtNomeProduto.ReadOnly = True
            PreencheCamposProduto()
            txtNomeProduto.Focus()
        End If

    End Sub

    Private Sub txtCodProduto_Leave(sender As Object, e As EventArgs) Handles txtCodProduto.Leave

        If IsNumeric(txtCodProduto.Text) Then

            Dim mProduto As New ClProduto
            mProduto.pId = CInt(txtCodProduto.Text)
            _Produto.TrazProdutoDaListaPorID(mProduto, MdlConexaoBD.ListaProdutos)
            If mProduto.pId < 1 Then

                _Produto.ZeraValores()
                txtCodProduto.Text = ""
                txtNomeProduto.Text = ""
            Else

                _Produto.setaValores(mProduto)
                txtCodProduto.Text = _Produto.pId
                txtNomeProduto.Text = _Produto.pDescricao
            End If
        Else
            _Produto.ZeraValores()
        End If

    End Sub

    Private Sub txtCodProduto_Click(sender As Object, e As EventArgs) Handles txtCodProduto.Click
        txtCodProduto.SelectAll()
    End Sub

    Private Sub txtCodProduto_GotFocus(sender As Object, e As EventArgs) Handles txtCodProduto.GotFocus

        If _Produto.pId < 1 Then
            txtNomeProduto.Text = ""
            txtNomeProduto.ReadOnly = False
            DesfazCamposProduto()
        Else
            PreencheCamposCLiente()
            txtNomeProduto.ReadOnly = True
        End If
        txtNomeProduto.SelectAll()
    End Sub

    Sub PreencheCamposProduto()

        txtCodProduto.Text = _Produto.pId
        txtNomeProduto.Text = _Produto.pDescricao


    End Sub

    Sub DesfazCamposProduto()

        txtCodProduto.Text = ""
        txtNomeProduto.Text = ""
        _Produto.ZeraValores()

    End Sub

#End Region


    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        ExecutaF2()
    End Sub

    Function ValidacoesAntesSalvar() As Boolean

        'valida cliente:
        If Not IsNumeric(txtIdCliente.Text) Then

            MsgBox("Informe um Cliente Por Favor!", MsgBoxStyle.Exclamation, Application.ProductName)
            tbcFicha.SelectTab(1)
            txtIdCliente.Focus()
            Return False
        Else

            If _Cliente.cid < 1 Then
                MsgBox("Informe um Cliente Por Favor!", MsgBoxStyle.Exclamation, Application.ProductName)
                tbcFicha.SelectTab(1)
                txtIdCliente.Focus()
                Return False
            End If
        End If

        'Valida produtos:
        If _dtg_produtos.Rows.Count < 1 Then

            MsgBox("Informe um Produto Por Favor!", MsgBoxStyle.Exclamation, Application.ProductName)
            tbcFicha.SelectTab(1)
            txtCodProduto.Focus()
            Return False
        End If

        'Valida Valores R$
        If (CDbl(txtValorEntrada.Text) + CDbl(txtValorPrestacoes.Text)) > CDbl(txtValorSoma.Text) Then

            If MessageBox.Show("Valor de ENTRADA + Valor das Prestações é Maior que o Valor da SOMA! Deseja Continuar?", Application.ProductName, MessageBoxButtons.YesNo) _
                = Windows.Forms.DialogResult.No Then

                Return False
            End If
        End If


        Return True
    End Function

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        If Operacao.Equals("") Then Return
        ExecutaF9()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        If Operacao.Equals("") Then Return

        If MessageBox.Show("Deseja Realmente Cancelar Esta Operação?", Application.CompanyName, MessageBoxButtons.YesNo) _
            = Windows.Forms.DialogResult.Yes Then

            CancelandoOperacao()
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ExecutaF5()
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        ExecutaF3()
    End Sub

    Private Sub txtSoNumeros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProdutoQtde.KeyPress, txtCodProduto.KeyPress, txtIdCliente.KeyPress, txtQtdePrestacoes.KeyPress, txtIntervaloPrestacoes.KeyPress
        'permite só numeros:
        If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtSoNumerosVirgula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProdutoVlrUnitario.KeyPress, txtProdutoTotal.KeyPress, txtValorGeralPrestacoes.KeyPress, txtValorSoma.KeyPress, txtValorEntrada.KeyPress, txtValorPrestacoes.KeyPress, txtValorSaldo.KeyPress, txtAssinValor.KeyPress
        'permite só numeros e virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Sub CalculaTotalProduto()

        If IsNumeric(txtProdutoQtde.Text) AndAlso IsNumeric(txtProdutoVlrUnitario.Text) Then

            If CDbl(txtProdutoQtde.Text) > 0 AndAlso CDbl(txtProdutoVlrUnitario.Text) > 0 Then
                txtProdutoTotal.Text = (CDbl(txtProdutoVlrUnitario.Text) * CDbl(txtProdutoQtde.Text)).ToString("#,##0.00")
            End If
        End If
    End Sub

    Private Sub txtProdutoQtde_Leave(sender As Object, e As EventArgs) Handles txtProdutoQtde.Leave

        If IsNumeric(txtProdutoQtde.Text) Then

            If CDbl(txtProdutoQtde.Text) <= 0 Then
                txtProdutoQtde.Text = "0,00"
            Else 'Se for maior que  0

                txtProdutoQtde.Text = CDbl(txtProdutoQtde.Text).ToString("#,##0.00")
            End If
            CalculaTotalProduto()
        Else
            txtProdutoQtde.Text = "0,00"
            Return
        End If

    End Sub

    Private Sub txtProdutoVlrUnitario_Leave(sender As Object, e As EventArgs) Handles txtProdutoVlrUnitario.Leave

        If IsNumeric(txtProdutoVlrUnitario.Text) Then

            If CDbl(txtProdutoVlrUnitario.Text) <= 0 Then
                txtProdutoVlrUnitario.Text = "0,00"
            Else 'Se for maior que  0

                txtProdutoVlrUnitario.Text = CDbl(txtProdutoVlrUnitario.Text).ToString("#,##0.00")
            End If
            CalculaTotalProduto()
        Else
            txtProdutoVlrUnitario.Text = "0,00"
            Return
        End If

    End Sub

    Private Sub txtProdutoVlrUnitario_GotFocus(sender As Object, e As EventArgs) Handles txtProdutoVlrUnitario.GotFocus
        txtProdutoVlrUnitario.SelectAll()
    End Sub

    Private Sub txtProdutoQtde_GotFocus(sender As Object, e As EventArgs) Handles txtProdutoQtde.GotFocus
        txtProdutoQtde.SelectAll()
    End Sub

    Private Sub btnAddProdFicha_Click(sender As Object, e As EventArgs) Handles btnAddProdFicha.Click

        If VerificaExistProdutoDataGrid() Then

            If MessageBox.Show("Este Produto já foi Adicionado! Deseja Substituir os Valores Anteriores?", Application.CompanyName, MessageBoxButtons.YesNo) _
                = Windows.Forms.DialogResult.Yes Then

                SubstitueValoresProdutosDataGrid()
                txtValorSoma.Text = SomaProdutos.ToString("#,##0.00")
                _dtgPrestacoes.Rows.Clear()

            Else
                Return
            End If
        Else
            AdicionaProdutoGridView()
        End If

        zeraValoresProduto()
        txtCodProduto.Focus()
    End Sub

    Private Sub _dtg_produtos_KeyDown(sender As Object, e As KeyEventArgs) Handles _dtg_produtos.KeyDown

        _IdProduto = 0
        If e.KeyCode = Keys.Delete Then

            _IdProduto = _dtg_produtos.CurrentRow.Cells(1).Value
            _dtg_produtos.Rows.Remove(_dtg_produtos.CurrentRow)
        End If
    End Sub

    Private Sub _dtg_produtos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles _dtg_produtos.CellContentClick

        If e.ColumnIndex = 0 Then 'Coluna do Botão OD/OE
            AdicionaOlhoGridView()
        End If
    End Sub

    Private Sub _dtgOeOd_KeyDown(sender As Object, e As KeyEventArgs) Handles _dtgOeOd.KeyDown

        If e.Control AndAlso e.KeyCode = Keys.Delete Then

            If Not _dtgOeOd.CurrentRow.IsNewRow Then
                _dtgOeOd.Rows.Remove(_dtgOeOd.CurrentRow)
            End If

        End If
    End Sub

    Private Sub _dtgOeOd_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles _dtgOeOd.RowsAdded

        Dim vComboOeOd As DataGridViewComboBoxCell
        Dim vComboDistancia As DataGridViewComboBoxCell
        vComboOeOd = CType(_dtgOeOd.Rows(e.RowIndex).Cells(0), DataGridViewComboBoxCell)
        vComboDistancia = CType(_dtgOeOd.Rows(e.RowIndex).Cells(1), DataGridViewComboBoxCell)

        vComboOeOd.Value = vComboOeOd.Items(0)
        vComboDistancia.Value = vComboDistancia.Items(0)

    End Sub

    Private Sub _dtgPrestacoes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles _dtgPrestacoes.CellClick

        If e.ColumnIndex = 4 Then 'botao

            If e.RowIndex = _dtgPrestacoes.Rows.Count - 1 Then

                If Not _dtgPrestacoes.CurrentRow.IsNewRow Then
                    _dtgPrestacoes.Rows.Remove(_dtgPrestacoes.CurrentRow)
                    txtQtdePrestacoes.Text = _dtgPrestacoes.Rows.Count.ToString.PadLeft(2, "0")
                End If

            Else
                MsgBox("É necessário excluir as últimas parcelas primeiro!", MsgBoxStyle.Exclamation, Application.ProductName) : Return
            End If

        End If
    End Sub

    Private Sub txtQtdePrestacoes_Leave(sender As Object, e As EventArgs) Handles txtQtdePrestacoes.Leave

        If IsNumeric(txtQtdePrestacoes.Text) Then
            txtQtdePrestacoes.Text = CInt(txtQtdePrestacoes.Text).ToString.PadLeft(2, "0")
        Else
            txtQtdePrestacoes.Text = "1"
        End If
    End Sub

    Private Sub txtIntervaloPrestacoes_Leave(sender As Object, e As EventArgs) Handles txtIntervaloPrestacoes.Leave

        If IsNumeric(txtIntervaloPrestacoes.Text) Then
            txtIntervaloPrestacoes.Text = CInt(txtIntervaloPrestacoes.Text).ToString.PadLeft(2, "0")
        Else
            txtIntervaloPrestacoes.Text = "0"
        End If
    End Sub

    Private Sub btnGerarPrestacoes_Click(sender As Object, e As EventArgs) Handles btnGerarPrestacoes.Click

        _dtgPrestacoes.Refresh()
        _dtgPrestacoes.Rows.Clear()
        If IsNumeric(txtQtdePrestacoes.Text) Then

            If Not CInt(txtQtdePrestacoes.Text) > 0 Then

                MsgBox("Quantidade das Prestações deve ser maior que ZERO", MsgBoxStyle.Exclamation, Application.ProductName)
                txtQtdePrestacoes.Focus()
                txtQtdePrestacoes.SelectAll()
                Return
            End If

            If Not CDbl(txtValorGeralPrestacoes.Text) > 0 Then

                MsgBox("Valor das Prestações deve ser maior que ZERO", MsgBoxStyle.Exclamation, Application.ProductName)
                txtValorGeralPrestacoes.Focus()
                txtValorGeralPrestacoes.SelectAll()
                Return
            End If


            If CDbl(txtValorGeralPrestacoes.Text) > CDbl(txtValorSoma.Text) Then

                MsgBox("Valor das Prestações ultrapassa o Valor da SOMA", MsgBoxStyle.Exclamation, Application.ProductName)
                txtValorGeralPrestacoes.Focus()
                txtValorGeralPrestacoes.SelectAll()
                Return
            End If

            'Variáveis:
            Dim vDataPrestacao As Date = dtpPrimeiraPrestacao.Value
            Dim vDias As Int32 = CInt(txtIntervaloPrestacoes.Text)
            Dim vValorPrestacao As Double = CDbl(txtValorGeralPrestacoes.Text)
            Dim vValorDividido As Double = 0
            Dim vSoma As Double = 0
            Dim vQuantidadePrestacoes As Int32 = CInt(txtQtdePrestacoes.Text)

            vValorDividido = Round((CDbl(txtValorGeralPrestacoes.Text) / vQuantidadePrestacoes), 2)
            For i As Int32 = 1 To vQuantidadePrestacoes

                If i = CInt(txtQtdePrestacoes.Text) Then
                    vValorDividido = CDbl(txtValorGeralPrestacoes.Text) - vSoma
                End If

                _dtgPrestacoes.Rows.Add(vDataPrestacao.ToShortDateString, vValorDividido.ToString("#,##0.00"), "", i.ToString.PadLeft(2, "0"))
                vSoma += vValorDividido
                vDataPrestacao = vDataPrestacao.AddDays(vDias)
            Next
        End If
    End Sub

    Private Sub txtValorGeralPrestacoes_Leave(sender As Object, e As EventArgs) Handles txtValorGeralPrestacoes.Leave

        If IsNumeric(txtValorGeralPrestacoes.Text) Then
            txtValorGeralPrestacoes.Text = CDbl(txtValorGeralPrestacoes.Text).ToString("#,##0.00")
        Else
            txtValorGeralPrestacoes.Text = "0,00"
        End If
    End Sub

    Private Sub btnLimparPrestacoes_Click(sender As Object, e As EventArgs) Handles btnLimparPrestacoes.Click
        _dtgPrestacoes.Rows.Clear()
        txtQtdePrestacoes.Text = _dtgPrestacoes.Rows.Count.ToString.PadLeft(2, "0")
    End Sub

    Private Sub txtValorSoma_Leave(sender As Object, e As EventArgs) Handles txtValorSoma.Leave

        If IsNumeric(txtValorSoma.Text) Then
            txtValorSoma.Text = CDbl(txtValorSoma.Text).ToString("#,##0.00")
        Else
            txtValorSoma.Text = "0,00"
        End If

    End Sub

    Private Sub txtValorEntrada_Leave(sender As Object, e As EventArgs) Handles txtValorEntrada.Leave

        If IsNumeric(txtValorEntrada.Text) Then
            txtValorEntrada.Text = CDbl(txtValorEntrada.Text).ToString("#,##0.00")

            If IsNumeric(txtValorSoma.Text) AndAlso CDbl(txtValorSoma.Text) > 0 Then

                Dim vEntrada As Double = 0
                Dim vSoma As Double = 0
                vEntrada = CDbl(txtValorEntrada.Text)
                vSoma = CDbl(txtValorSoma.Text)

                If vSoma < vEntrada Then

                    MsgBox("Valor da ENTRADA não deve ser maior que a o Valor da SOMA", MsgBoxStyle.Exclamation, Application.CompanyName)
                    txtValorEntrada.Focus()
                    txtValorEntrada.SelectAll()
                    Return
                End If

                txtValorSaldo.Text = (vSoma - vEntrada).ToString("#,##0.00")
            End If
        Else
            txtValorEntrada.Text = "0,00"
        End If
    End Sub

    Private Sub txtValorSaldo_Leave(sender As Object, e As EventArgs) Handles txtValorSaldo.Leave

        If IsNumeric(txtValorSaldo.Text) Then
            txtValorSaldo.Text = CDbl(txtValorSaldo.Text).ToString("#,##0.00")
        Else
            txtValorSaldo.Text = "0,00"
        End If
    End Sub

    Private Sub txtValorPrestacoes_Leave(sender As Object, e As EventArgs) Handles txtValorPrestacoes.Leave

        If IsNumeric(txtValorPrestacoes.Text) Then
            txtValorPrestacoes.Text = CDbl(txtValorPrestacoes.Text).ToString("#,##0.00")
        Else
            txtValorPrestacoes.Text = "0,00"
        End If
    End Sub

    Private Sub _dtgPrestacoes_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles _dtgPrestacoes.RowsAdded
        txtValorPrestacoes.Text = SomaPrestacoes.ToString("#,##0.00")
    End Sub

    Private Sub _dtgPrestacoes_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles _dtgPrestacoes.RowsRemoved
        txtValorPrestacoes.Text = SomaPrestacoes.ToString("#,##0.00")
    End Sub

    Function SomaPrestacoes() As Double

        Dim vSoma As Double = 0
        For Each r As DataGridViewRow In _dtgPrestacoes.Rows

            If Not r.IsNewRow Then
                vSoma += r.Cells(1).Value
            End If
        Next

        Return vSoma
    End Function

    Function SomaProdutos() As Double

        Dim vSoma As Double = 0
        For Each r As DataGridViewRow In _dtg_produtos.Rows

            If Not r.IsNewRow Then
                vSoma += r.Cells(5).Value
            End If
        Next

        Return vSoma
    End Function

    Private Sub _dtg_produtos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles _dtg_produtos.RowsAdded

        txtValorSoma.Text = SomaProdutos.ToString("#,##0.00")
        _dtgPrestacoes.Rows.Clear()
    End Sub

    Private Sub _dtg_produtos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles _dtg_produtos.RowsRemoved

        txtValorSoma.Text = SomaProdutos.ToString("#,##0.00")
        _dtgPrestacoes.Rows.Clear()

        RemoveOeOdProduto()
    End Sub

    Sub RemoveOeOdProduto()

        'Remove OE/OD se existir:
        If _dtgOeOd.Rows.Count > 0 Then

            For Each r As DataGridViewRow In _dtgOeOd.Rows

                If Not r.IsNewRow Then

                    If r.Cells(2).Value = _IdProduto Then _dtgOeOd.Rows.RemoveAt(r.Index)
                    If VerificaExistProdutoDataGrid_OE_OD(_IdProduto) Then RemoveOeOdProduto()
                End If
            Next
        End If
    End Sub

    Private Sub txtValorSoma_TextChanged(sender As Object, e As EventArgs) Handles txtValorSoma.TextChanged

        If IsNumeric(txtValorEntrada.Text) Then
            txtValorEntrada.Text = CDbl(txtValorEntrada.Text).ToString("#,##0.00")

            If IsNumeric(txtValorSoma.Text) Then

                Dim vEntrada As Double = 0
                Dim vSoma As Double = 0
                vSoma = CDbl(txtValorSoma.Text)
                vEntrada = CDbl(txtValorEntrada.Text)

                If vEntrada > vSoma Then txtValorEntrada.Text = "0,00"
                vEntrada = CDbl(txtValorEntrada.Text)

                txtValorSaldo.Text = (vSoma - vEntrada).ToString("#,##0.00")
            End If
        Else

            If IsNumeric(txtValorSoma.Text) Then

                Dim vSoma As Double = 0
                vSoma = CDbl(txtValorSoma.Text)

                txtValorSaldo.Text = vSoma.ToString("#,##0.00")
            End If
        End If
        txtAssinValor.Text = txtValorSoma.Text

    End Sub

    Private Sub mskDataPrestacoes_Click(sender As Object, e As EventArgs) Handles mskDataPrestacoes.Click
        mskDataPrestacoes.SelectAll()
    End Sub

    Private Sub mskDataEntrada_Click(sender As Object, e As EventArgs) Handles mskDataEntrada.Click
        mskDataEntrada.SelectAll()
    End Sub

    Private Sub mskDataEntrega_Click(sender As Object, e As EventArgs) Handles mskDataEntrega.Click
        mskDataEntrega.SelectAll()
    End Sub

    Private Sub txtValorEntrada_Click(sender As Object, e As EventArgs) Handles txtValorEntrada.Click
        txtValorEntrada.SelectAll()
    End Sub

    Private Sub mskAssinDataVenc_Click(sender As Object, e As EventArgs) Handles mskAssinDataVenc.Click
        mskAssinDataVenc.SelectAll()
    End Sub

    Private Sub mskAssinDataEmiss_Click(sender As Object, e As EventArgs) Handles mskAssinDataEmiss.Click
        mskAssinDataEmiss.SelectAll()
    End Sub

    Private Sub txtAssinValor_TextChanged(sender As Object, e As EventArgs) Handles txtAssinValor.TextChanged

        If Not IsNumeric(txtAssinValor.Text) Then txtAssinValorExtenso.Text = "" : Return
        If CDbl(txtAssinValor.Text) > 0 Then

            txtAssinValorExtenso.Text = _funcoes.Mostra_Extenso(CDbl(txtAssinValor.Text))
            txtAssinValorExtenso.Text = StrConv(txtAssinValorExtenso.Text, VbStrConv.ProperCase)
        End If

    End Sub

    Private Sub txtAssinValor_Leave(sender As Object, e As EventArgs) Handles txtAssinValor.Leave

        If IsNumeric(txtAssinValor.Text) Then
            txtAssinValor.Text = CDbl(txtAssinValor.Text).ToString("#,##0.00")
        Else
            txtAssinValor.Text = "0,00"
        End If

    End Sub

    Private Sub txtAssinValor_Click(sender As Object, e As EventArgs) Handles txtAssinValor.Click
        txtAssinValor.SelectAll()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click

        If MessageBox.Show("Deseja Realmente Excluir Permanente Esta Ficha?", Application.ProductName, MessageBoxButtons.YesNo) _
            = Windows.Forms.DialogResult.Yes Then

            DeletandoFicha()
        End If
    End Sub

    Sub DeletandoFicha()

        If _dtgFicha.CurrentRow.IsNewRow Then MsgBox("Selecione Uma Ficha para Poder Alterar") : Return

        _Ficha.fo_id = _dtgFicha.CurrentRow.Cells(0).Value
        _Ficha.TrazFichaOtica(_Ficha, MdlConexaoBD.conectionPadrao)

        'Lança CONTAS A RECEBER:
        If _AReceberDAO.VerificaFichaOtica_AReceberBD(_Ficha, MdlConexaoBD.conectionPadrao) Then

            MsgBox("Já Existe Prestações no Contas A Receber Lançadas para Essa FICHA! Estorne Primeiro No Contas a Receber para poder Excluir a Ficha", MsgBoxStyle.Exclamation, Application.ProductName)
            Return
        End If

        'Deletando os Objetos:
        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                conexao = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = conexao.BeginTransaction

            'Deletando Objeto Assinatura Ficha:
            _FichaAssinatura.delFichaOticaAssinatura_IdFicha(_Ficha, conexao, transacao)

            'Deletando objeto PRODUTOS Ficha:
            _FichaProduto.delFichaOticaProduto_IdFicha(_Ficha, conexao, transacao)

            'Deletando objeto OLHO Ficha:
            _FichaOlho.delFichaOticaOlho_IdFicha(_Ficha, conexao, transacao)

            'Deletando objeto PRESTACOES Ficha:
            _FichaPrestacoes.delFichaOticaPrestacoes_IdFicha(_Ficha, conexao, transacao)

            'Deletando o Objeto Ficha:
            _Ficha.delFichaOtica(_Ficha, conexao, transacao)

            transacao.Commit()
            MsgBox("Ficha Ótica Deletada com Sucesso!", MsgBoxStyle.Exclamation)

            MdlConexaoBD.ListaFichaOtica.Clear()
            _Ficha.TrazListFichaOtica_BD(MdlConexaoBD.ListaFichaOtica, MdlConexaoBD.conectionPadrao)
            ExecutaF5()
            tbcFicha.SelectTab(0)
            txtPesquisaNomeCliente.Focus()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            conexao.ClearPool() : conexao.Close() : conexao = Nothing
        End Try


        'Comandos Finais:
        LimpaCamposFormulario()
        LimpaValoresObjetos()
        DesabilitaCamposFormulario()
        Operacao = ""
        ExecutaF5()
        txtPesquisaNomeCliente.Focus()

    End Sub

    Private Sub btnVisualizar_Click(sender As Object, e As EventArgs) Handles btnVisualizar.Click
        VisualizaFICHA()
    End Sub

    Sub VisualizaFICHA()

        Try
            If _dtgFicha.CurrentRow.IsNewRow Then MsgBox("Selecione Uma Ficha para Poder Visualizar") : Return
        Catch ex As Exception
            Return
        End Try

        If Operacao.Equals("A") Then

            If MessageBox.Show("Já existe uma Alteração em Andamento, ela será cancelada! Deseja Continuar?", Application.CompanyName, MessageBoxButtons.YesNo) _
                = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If

        Operacao = "V"
        HabilitaCamposFormulario()
        LimpaCamposFormulario()
        LimpaValoresObjetos()
        PreencheValoresObjetos()
        PreencheValoresFormulario()
        tbcFicha.SelectTab(1)
        txtFichaCoordenador.Focus()
        BloqueiaVisualiza()

    End Sub

    Sub BloqueiaVisualiza()

        txtIdCliente.Enabled = False
        txtCodProduto.Enabled = False
        btnSalvar.Enabled = False
        _dtg_produtos.Enabled = False
        _dtgOeOd.Enabled = False
        _dtgPrestacoes.Enabled = False
        txtValorEntrada.Enabled = False
        btnLimparPrestacoes.Enabled = False
        btnGerarPrestacoes.Enabled = False
        btnAddProdFicha.Enabled = False

        _grbAssinatura.Enabled = False
        _grbTotais.Enabled = False
    End Sub

    Sub DesbloqueiaVisualiza()

        txtIdCliente.Enabled = True
        txtCodProduto.Enabled = True
        btnSalvar.Enabled = True
        _dtg_produtos.Enabled = True
        _dtgOeOd.Enabled = True
        _dtgPrestacoes.Enabled = True
        txtValorEntrada.Enabled = True
        btnLimparPrestacoes.Enabled = True
        btnGerarPrestacoes.Enabled = True
        btnAddProdFicha.Enabled = True

        _grbAssinatura.Enabled = True
        _grbTotais.Enabled = True
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ExecutaF11()
    End Sub

    Sub ImprimeFicha()

        Try
            If _dtgFicha.CurrentRow.IsNewRow Then MsgBox("Selecione Uma Ficha para Poder Alterar") : Return
        Catch ex As Exception
            Return
        End Try

        If Operacao.Equals("A") Then

            If MessageBox.Show("Já existe uma Alteração em Andamento, ela será cancelada! Deseja Continuar?", Application.CompanyName, MessageBoxButtons.YesNo) _
                = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If

        HabilitaCamposFormulario()
        LimpaCamposFormulario()
        LimpaValoresObjetos()
        PreencheValoresObjetos()

        'Prepara Impressão:
        Dim vListEmpresa As New List(Of ClEmpresa)
        Dim vListCliente As New List(Of ClCliente)
        Dim vListFicha As New List(Of ClFichaOtica)
        Dim vListAssinatura As New List(Of ClFichaOticaAssinatura)

        vListEmpresa.Add(New ClEmpresa(_Empresa))
        vListCliente.Add(New ClCliente(_Cliente))
        vListFicha.Add(New ClFichaOtica(_Ficha))
        vListAssinatura.Add(New ClFichaOticaAssinatura(_FichaAssinatura))

        Dim mFormulario As New FormImpressaoFichaOtica
        mFormulario.EnderecoEmp = _Empresa.empendereco
        mFormulario.BairroEmp = _Empresa.empbairro
        mFormulario.CidadeEmp = _Empresa.empcidade
        mFormulario.EstadoEmp = _Empresa.empestado
        mFormulario._Empresa = vListEmpresa
        mFormulario._CLiente = vListCliente
        mFormulario._Ficha = vListFicha
        mFormulario._ListaFichaProdutos = _ListaFichaProdutos
        mFormulario._ListaFichaOlho = _ListaFichaOlho
        mFormulario._ListaFichaPrestacoes = _ListaFichaPrestacoes
        mFormulario._AssinaturaFicha = vListAssinatura
        
        mFormulario.ShowDialog()
        mFormulario = Nothing

    End Sub

    Private Sub _dtgFicha_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles _dtgFicha.CellContentClick

        If e.ColumnIndex = 6 Then

            ImprimeFicha()
        End If

    End Sub

End Class