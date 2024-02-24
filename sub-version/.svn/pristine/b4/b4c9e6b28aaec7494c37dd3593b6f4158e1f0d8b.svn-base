Imports System.GC
Imports System.Threading
Imports System.ComponentModel
Public Class FormPrincipal

    Dim _threadsTrazObjetos As Thread
    Dim _clFuncoes As New ClFuncoes
    Dim DaoAgendamentos As New ClAgendamentoDAO
    Dim LoginOK As Boolean = False

    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = Application.CompanyName.ToUpper
        Dim formulario As New FormLogin
        formulario.ShowDialog()
        LoginOK = formulario._loginOK
        If LoginOK AndAlso formulario.ResultadoLogin = False Then Me.Close()
        formulario = Nothing

        If LoginOK = False Then

            Try
                If buscaSincronizar() Then
                    ConfiguraTelasSincroniza()
                    Return
                Else
                    Me.Close()
                End If
            Catch ex As Exception
                Me.Close()
            End Try
        End If


        If mdlConfiguracoes.tId <= 0 Then

            MsgBox("Sistema Sem Configurações no Banco!", MsgBoxStyle.Critical)
            Me.Close()
        End If


        Dim mQtdeAgend As Int64 = 0
        mQtdeAgend = DaoAgendamentos.TrazCountAgendamentosBD(MdlConexaoBD.conectionPadrao, " WHERE a_dtagend = '" & Date.Now.ToShortDateString & "' AND a_status = false ")
        btnAgendamentos.Text = mQtdeAgend
        If mQtdeAgend > 0 Then
            pnAgendamentos.Visible = True
            lblAgendamentos.Visible = True
            btnAgendamentos.Visible = True
        End If

        'Thread Tempo Excedido:
        _threadsTrazObjetos = New Threading.Thread(AddressOf TrazObjetos)
        _threadsTrazObjetos.Start()
        _threadsTrazObjetos.IsBackground = True
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        txt_hora.Text = Mid(TimeString, 1, 5)
    End Sub

    Sub TrazObjetos()

        Dim prodDAO As New ClProdutoDAO
        Dim unidadeDAO As New ClUnidadeDAO
        Dim fornecedoDAO As New ClFornecedorDAO
        Dim depProdutoDAO As New ClDespesaProdutoDAO
        Dim ruaDAO As New ClRuaDAO
        Dim bairroDAO As New ClBairroDAO
        Dim clienteDAO As New ClClienteDAO
        Dim empresaDAO As New ClEmpresaDAO
        Dim funcionarioDAO As New ClAtendenteDAO
        Dim servicoDAO As New ClServicosDAO
        Dim produtosServicoDAO As New ClProdutoServicoDAO
        Dim AreceberTotalDAO As New ClAReceberTotalDAO
        Dim AReceberParcialDAO As New ClAReceberParcialDAO
        Dim ApagarTotalDAO As New ClAPagarTotalDAO
        Dim ApagarParcialDAO As New ClAPagarParcialDAO
        Dim GrupoDAO As New ClGrupoDespMensalDAO
        Dim SubGrupoDAO As New ClSubGrupoDespMensalDAO
        Dim DespMensalDAO As New ClDespesaMensalDAO
        Dim DaoCidades As New ClMunicipioDAO
        Dim DaoAgendamentos As New ClAgendamentoDAO
        Dim IMC As New ClIMC
        Dim SaudePessoa As New ClInfoSaudePessoa
        Dim ItensSaudePessoa As New ClInfoSaudePessoaItem

        Try
            If Not MdlConexaoBD.mdlConfiguracoes.caminho_logo.Equals("") Then
                painelPrincipal.BackgroundImage = Image.FromFile(MdlConexaoBD.mdlConfiguracoes.caminho_logo)
            End If
        Catch ex As Exception
        End Try
        
        mdlConfiguracoesDAO.TrazConfiguracoesID(mdlConfiguracoes, MdlConexaoBD.conectionPadrao)
        mdlPadraoSistemaDAO.TrazPadraoSistema(mdlPadraoSistema, MdlConexaoBD.conectionPadrao)
        empresaDAO.TrazEmpresaWhereLimit(MdlConexaoBD.mdlEmpresa, MdlConexaoBD.conectionPadrao)
        funcionarioDAO.TrazListAtendentes_BD(MdlConexaoBD.ListaAtendentes, MdlConexaoBD.conectionPadrao)
        DaoCidades.preenchListaCidades(MdlConexaoBD.mdlListCidades)
        prodDAO.TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
        fornecedoDAO.TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
        servicoDAO.TrazListServicos_BD(MdlConexaoBD.ListaServicos, MdlConexaoBD.conectionPadrao)
        DaoAgendamentos.TrazListAgendamentosBD(MdlConexaoBD.ListaAgendamentos, MdlConexaoBD.conectionPadrao)
        produtosServicoDAO.TrazListProdutosServico(MdlConexaoBD.mdlListProdutosServico, MdlConexaoBD.conectionPadrao)
        unidadeDAO.TrazListUnidades(MdlConexaoBD.mdlListUnidades, MdlConexaoBD.conectionPadrao)
        ruaDAO.TrazListRuas(MdlConexaoBD.mdlListRuas, MdlConexaoBD.conectionPadrao)
        bairroDAO.TrazListBairros(MdlConexaoBD.mdlListBairros, MdlConexaoBD.conectionPadrao)
        clienteDAO.TrazListClientes_BD(MdlConexaoBD.ListaClientes, MdlConexaoBD.conectionPadrao)
        depProdutoDAO.TrazListdesp_produtos(MdlConexaoBD.mdlListDespesasProduto, MdlConexaoBD.conectionPadrao)
        DespMensalDAO.TrazListDespesaMensalDoBanco(MdlConexaoBD.ListaDespesaMensal, MdlConexaoBD.conectionPadrao)
        MdlConexaoBD.ListaIMC = IMC.DAO.trazListaIMC_BD(MdlConexaoBD.conectionPadrao)
        MdlConexaoBD.ListaInfoSaudePessoa = SaudePessoa.DAO.TrazListaInfoSaudePessoa_BD(MdlConexaoBD.conectionPadrao)
        MdlConexaoBD.ListaItemsInfoSaudePessoa = ItensSaudePessoa.DAO.TrazListaItemInfoNutriPessoa_BD(MdlConexaoBD.conectionPadrao)

        AreceberTotalDAO.TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
        AReceberParcialDAO.TrazListAReceberParcial(MdlConexaoBD.mdlListAReceberParcial, MdlConexaoBD.conectionPadrao)
        ApagarTotalDAO.TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
        ApagarParcialDAO.TrazListAPagarParcial(MdlConexaoBD.mdlListAPagarParcial, MdlConexaoBD.conectionPadrao)
        GrupoDAO.TrazListGrupoDespMensalDoBANCO(MdlConexaoBD.ListaGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        SubGrupoDAO.TrazListaSubGrupoDespMensalDoBANCO(MdlConexaoBD.mdlListSubGrupoDespMensal, MdlConexaoBD.conectionPadrao)


    End Sub

    Private Sub FormPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            _threadsTrazObjetos.Abort()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F1
                If MdlConexaoBD.sincronizado Then Return
                Dim frmCaixa As New FrmCaixa
                frmCaixa.ShowDialog()
                frmCaixa = Nothing

            Case Keys.F2
                Dim formulario As New FrmCadCliente
                formulario.ShowDialog()
                formulario = Nothing

            Case Keys.F3
                If MdlConexaoBD.sincronizado Then Return
                Dim mAbrirFecharCxDAO As New ClAbrirFecharDAO
                If mAbrirFecharCxDAO.VerificaCaixaAberto(MdlConexaoBD.conectionPadrao) = False Then
                    MsgBox("Abra um CAIXA primeiro para prosseguir!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    Return
                End If
                Dim frmServicos As New FrmServicos
                frmServicos.ShowDialog()
                frmServicos = Nothing

            Case Keys.F4
                Dim formulario As New FrmMenuDespesaMensal
                formulario.ShowDialog()
                formulario = Nothing

            Case Keys.F6
                Dim formulario As New FrmPagamentoComissao
                formulario.ShowDialog()
                formulario = Nothing

            Case Keys.F11 'cofiguracoes
                If MdlConexaoBD.sincronizado Then Return
                Dim frmConfig As New FrmConfiguracoes
                frmConfig.ShowDialog()
                frmConfig = Nothing

        End Select
    End Sub

    Private Sub ProdutosMenuCadProduto_Click(sender As Object, e As EventArgs) Handles TSMCadProduto.Click
        Dim frmCadProd As New FrmCadProduto
        frmCadProd.ShowDialog()
        frmCadProd = Nothing
    End Sub

    Private Sub FuncionariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMCadAtendente.Click
        Dim frmCadAtendente As New FrmCadAtendente
        frmCadAtendente.ShowDialog()
        frmCadAtendente = Nothing
    End Sub

    Private Sub FornecedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMCadFornecedor.Click
        Dim frmCadFornecedor As New FrmCadFornecedor
        frmCadFornecedor.ShowDialog()
        frmCadFornecedor = Nothing
    End Sub

    Private Sub LocacoesTSMenuItem_Click(sender As Object, e As EventArgs) Handles TSMMovEntradaSaida.Click
        Dim frmEntradaSaida As New FrmEntradaSaida
        frmEntradaSaida.ShowDialog()
        frmEntradaSaida = Nothing
    End Sub

    Private Sub CaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMMovCaixa.Click
        Dim frmCaixa As New FrmCaixa
        frmCaixa.ShowDialog()
        frmCaixa = Nothing
    End Sub

    Private Sub ConfiguraçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMConfiguracao.Click
        Dim configuracaoDAO As New ClConfiguracoesDAO
        Dim mconfiguracao As New ClConfiguracoes
        configuracaoDAO.TrazConfiguracoesID(mconfiguracao, MdlConexaoBD.conectionPadrao)
        mconfiguracao.liberar = False
        Dim frmTestaSenha As New FrmSenhaPadrao
        frmTestaSenha.configuracao = mconfiguracao
        frmTestaSenha.ShowDialog()
        If mconfiguracao.liberar Then

            Dim mFrmCofniguracoes As New FrmConfiguracoes
            mFrmCofniguracoes.ShowDialog()
        End If

    End Sub

    Private Sub BairrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMCadBairro.Click
        Dim frmBairros As New FrmCadBairro
        frmBairros.ShowDialog()
        frmBairros = Nothing
    End Sub

    Private Sub RuaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMCadRua.Click
        Dim frmRua As New FrmCadRua
        frmRua.ShowDialog()
        frmRua = Nothing
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMCadCliente.Click
        Dim frmCliente As New FrmCadCliente
        frmCliente.ShowDialog()
        frmCliente = Nothing
    End Sub

    Private Sub ServicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMCadServico.Click
        Dim frmServicos As New FrmCadServicos
        frmServicos.ShowDialog()
        frmServicos = Nothing
    End Sub

    Private Sub EmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMCadEmpresa.Click
        Dim frmCadEmpresa As New FrmCadEmpresa
        frmCadEmpresa.ShowDialog()
        frmCadEmpresa = Nothing
    End Sub

    Private Sub ServicosSMP_Click(sender As Object, e As EventArgs) Handles TSMMovVendaServico.Click
        Dim mAbrirFecharCxDAO As New ClAbrirFecharDAO
        If mAbrirFecharCxDAO.VerificaCaixaAberto(MdlConexaoBD.conectionPadrao) = False Then
            MsgBox("Abra um CAIXA primeiro para prosseguir!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If
        Dim frmServicos As New FrmServicos
        frmServicos.ShowDialog()
        frmServicos = Nothing
    End Sub

    Private Sub ContasAReceberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContasAReceberToolStripMenuItem.Click

        Dim frmAreceberMenu As New FrmMenuDuplicatas
        frmAreceberMenu.ShowDialog()
        frmAreceberMenu = Nothing
    End Sub

    Private Sub PagamentoComissãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMMovPagComissao.Click

        Dim frmPagamentoComissao As New FrmPagamentoComissao
        frmPagamentoComissao.ShowDialog()
        frmPagamentoComissao = Nothing

    End Sub

    Private Sub GrupoDeDespesasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TsmMovGrupoDesp.Click
        Dim frmCadGrupoDesp As New FrmCadGrupoDespMensal
        frmCadGrupoDesp.ShowDialog()
        frmCadGrupoDesp = Nothing
    End Sub

    Private Sub SubGrupoDeDespesasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TsmMovSubGrupoDesp.Click
        Dim frmCadSubGrupoDesp As New FrmCadSubGrupoDespMensal
        frmCadSubGrupoDesp.ShowDialog()
        frmCadSubGrupoDesp = Nothing
    End Sub

    Private Sub MenuDespesasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuDespesasToolStripMenuItem.Click
        Dim frmMenuDespesas As New FrmMenuDespesaMensal
        frmMenuDespesas.ShowDialog()
        frmMenuDespesas = Nothing
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TSMCadTipoDocumento.Click

        Dim mFormulario As New FrmCadTipoDocumento
        mFormulario.ShowDialog()
        mFormulario = Nothing
    End Sub

    Private Sub ContasAPagarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContasAPagarToolStripMenuItem.Click

        Dim mFormulario As New FrmMenuDuplicatasAPagar
        mFormulario.ShowDialog()
        mFormulario = Nothing
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles TSMCadCidade.Click

        Dim mFormulario As New Frm_CadCidades
        mFormulario.ShowDialog()
        mFormulario = Nothing
    End Sub

    Private Sub AgendamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMMovAgendamento.Click

        Dim mFormulario As New FormMenuAgendamento
        mFormulario.ShowDialog()
        mFormulario = Nothing

    End Sub

    Private Sub btnAgendamentos_Click(sender As Object, e As EventArgs) Handles btnAgendamentos.Click
        Dim mFormulario As New FormMenuAgendamento
        mFormulario.IndexSituacao = 1
        mFormulario.ShowDialog()
        mFormulario = Nothing
    End Sub

    Private Sub RelacaooDeVendasServicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelacaooDeVendasServicoToolStripMenuItem.Click

        Dim Formulario As New FormRelacaoVendasServico
        Formulario.ShowDialog()
        Formulario = Nothing

    End Sub

    Private Sub RelacaoDeServicosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMRelatServico.Click

        Dim Formulario As New FormRelacaoServicos
        Formulario.ShowDialog()
        Formulario = Nothing

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles TSMCadUsuario.Click

        Dim Formulario As New FormCadUsuarioMenu
        Formulario.ShowDialog()
        Formulario = Nothing

    End Sub

    Sub ConfiguraTelasSincroniza()

        With Me
            If MdlConexaoBD.ListaProdutos.Count < 1 Then .TSMCadProduto.Visible = False
            If MdlConexaoBD.mdlListBairros.Count < 1 Then .TSMCadBairro.Visible = False
            If MdlConexaoBD.mdlListCidades.Count < 1 Then .TSMCadCidade.Visible = False
            If MdlConexaoBD.mdlListEmpresa.Count < 1 Then .TSMCadEmpresa.Visible = False
            If MdlConexaoBD.mdlListTipoDocumentos.Count < 1 Then .TSMCadTipoDocumento.Visible = False
            If MdlConexaoBD.mdlListUsuarios.Count < 1 Then .TSMCadUsuario.Visible = False
            If MdlConexaoBD.mdlListRuas.Count < 1 Then .TSMCadRua.Visible = False
            If MdlConexaoBD.ListaCaixas.Count < 1 Then .RelatorioDoCaixaToolStripMenuItem.Visible = False
            .TSMMovCaixa.Visible = False
            .TSMMovEntradaSaida.Visible = False
            .TSMMovVendaServico.Visible = False
            .TSMMovPagComissao.Visible = False
            If MdlConexaoBD.ListaGrupoDespMensal.Count < 1 Then .TsmMovGrupoDesp.Visible = False
            If MdlConexaoBD.mdlListSubGrupoDespMensal.Count < 1 Then .TsmMovSubGrupoDesp.Visible = False
            .TSMConfiguracao.Visible = False
            .TSMSincroniza.Visible = False
        End With
    End Sub

    Private Sub SincronizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMSincroniza.Click

        Dim sincro As New ClSincronizar
        Dim CliDao As New ClClienteDAO
        Dim ProdDao As New ClProdutoDAO
        Dim ServDao As New ClServicosDAO
        Dim AtendDao As New ClAtendenteDAO
        Dim AgendDao As New ClAgendamentoDAO
        Dim FornDao As New ClFornecedorDAO
        Dim AbrFechDao As New ClAbrirFecharDAO
        Dim CaixaDao As New ClCaixaDAO
        Dim APagarDao As New ClAPagarTotalDAO
        Dim AReceberDao As New ClAReceberTotalDAO
        Dim GrupoDespDao As New ClGrupoDespMensalDAO
        Dim DespMensalDao As New ClDespesaMensalDAO
        Dim VendaServicoDao As New ClVendaServicoDAO
        Dim ItensVendaServicoDao As New ClVendaServicoItensDAO
        Dim SaudePessoa As New ClInfoSaudePessoa
        Dim SaudePessoaItem As New ClInfoSaudePessoaItem
        Dim Imc As New ClIMC


        sincro.caminhoPasta = "\Sincronizar\"

        CliDao.TrazListClientes_BD(sincro.ListaClientes, MdlConexaoBD.conectionPadrao)
        ServDao.TrazListServicos_BD(sincro.ListaServicos, MdlConexaoBD.conectionPadrao)
        ProdDao.TrazListProdutosBD(sincro.ListaProdutos, MdlConexaoBD.conectionPadrao)
        AtendDao.TrazListAtendentes_BD(sincro.ListaAtendentes, MdlConexaoBD.conectionPadrao)
        AgendDao.TrazListAgendamentosBD(sincro.ListaAgendamentos, MdlConexaoBD.conectionPadrao)
        FornDao.TrazListFornecedoresBD(sincro.ListaFornecedores, MdlConexaoBD.conectionPadrao)
        AbrFechDao.TrazListAbriFecharBD(sincro.ListaAbrirFecharCX, MdlConexaoBD.conectionPadrao)
        CaixaDao.TrazListCaixasBD(sincro.ListaCaixa, MdlConexaoBD.conectionPadrao)
        APagarDao.TrazListAPagarTotalBD(sincro.ListaContasAPagar, MdlConexaoBD.conectionPadrao)
        AReceberDao.TrazListAReceberBD(sincro.ListaContasAReceber, MdlConexaoBD.conectionPadrao)
        GrupoDespDao.TrazListGrupoDespMensalDoBANCO(sincro.ListaGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        DespMensalDao.TrazListDespesaMensalDoBanco(sincro.ListaDespMensal, MdlConexaoBD.conectionPadrao)
        VendaServicoDao.TrazListVendaServicoBD(sincro.ListaVendasServico, MdlConexaoBD.conectionPadrao)
        ItensVendaServicoDao.TrazListTodosVendaServicoItens_BD(sincro.ListaVendasServicoItens, MdlConexaoBD.conectionPadrao)
        sincro.ListaSaudePessoa = SaudePessoa.DAO.TrazListaInfoSaudePessoa_BD(MdlConexaoBD.conectionPadrao)
        sincro.ListaItensSaudePessoa = SaudePessoaItem.DAO.TrazListaItemInfoNutriPessoa_BD(MdlConexaoBD.conectionPadrao)
        sincro.ListaIMC = Imc.DAO.trazListaIMC_BD(MdlConexaoBD.conectionPadrao)

        sincro.salvarArquivosTEXTO(sincro)
        MsgBox("Sincronização Atualizada com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
    End Sub

    Function buscaSincronizar() As Boolean
        Dim existArquivo As Boolean = False

        Dim sincro As New ClSincronizar

        sincro.caminhoPasta = "\Sincronizar\"
        MdlConexaoBD.ListaClientes = sincro.TrazListaClientesArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqCliente)
        MdlConexaoBD.ListaServicos = sincro.TrazListaServicosArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqServico)
        MdlConexaoBD.ListaProdutos = sincro.TrazListaProdutosArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqProduto)
        MdlConexaoBD.ListaAtendentes = sincro.TrazListaAtendentesArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqAtendente)
        MdlConexaoBD.ListaAgendamentos = sincro.TrazListaAgendamentosArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqAgendamento)
        MdlConexaoBD.ListaFornecedores = sincro.TrazListaFornecedoresArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqFornecedor)
        MdlConexaoBD.ListaAbrirFecharCX = sincro.TrazListaAbrirFecharCXArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqAbrirFecharCX)
        MdlConexaoBD.ListaCaixas = sincro.TrazListaCaixaArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqCaixa)
        MdlConexaoBD.ListaAPagarTotal = sincro.TrazListaAPagarArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqAPagar)
        MdlConexaoBD.ListaAReceberTotal = sincro.TrazListaAReceberArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqAReceber)
        MdlConexaoBD.ListaGrupoDespMensal = sincro.TrazListaGrupoDespMensalArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqGrupoDesp)
        MdlConexaoBD.ListaDespesaMensal = sincro.TrazListaDespMensalArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqDespMensal)
        MdlConexaoBD.ListaVendaServico = sincro.TrazListaVendaServicoArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqVendaServico)
        MdlConexaoBD.ListaVendaServicoItens = sincro.TrazListaVendaServicoItensArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqVendaServicoItens)
        MdlConexaoBD.ListaInfoSaudePessoa = sincro.TrazListaSaudePessoaArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqSaudePessoa)
        MdlConexaoBD.ListaItemsInfoSaudePessoa = sincro.TrazListaSaudePessoaITENSArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqSaudePessoaItens)
        MdlConexaoBD.ListaIMC = sincro.TrazListaIMCArquivoTEXTO(sincro.caminhoPasta & MdlParametros.arqIMC)

        If MdlConexaoBD.ListaClientes.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaServicos.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaProdutos.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaAtendentes.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaAgendamentos.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaFornecedores.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaAbrirFecharCX.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaCaixas.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaAPagarTotal.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaAReceberTotal.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaGrupoDespMensal.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaDespesaMensal.Count > 0 Then existArquivo = True
        If MdlConexaoBD.ListaVendaServico.Count > 0 Then existArquivo = True


        MdlConexaoBD.sincronizado = existArquivo
        Return existArquivo
    End Function

    Private Sub RelatorioDoCaixaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelatorioDoCaixaToolStripMenuItem.Click
        Dim mFormulario As New FormMenuRelatorioCaixa
        mFormulario.ShowDialog()
        mFormulario = Nothing
    End Sub

End Class
