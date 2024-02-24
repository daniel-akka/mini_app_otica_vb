Module MdlConexaoBD

    Public conectionPadrao As String = _
    "Server=localhost;Port=5432;UserId=postgres;Password=.akka.;Database=SERVICOS;" & _
    "maxPoolSize=100;Timeout=7;CommandTimeout=7;"

    Public sincronizado As Boolean = False


    'Objetos Listas
    Public ListaProdutos As New List(Of ClProduto)
    Public ListaAtendentes As New List(Of ClAtendente)
    Public mdlListUnidades As New List(Of ClUnidade)
    Public mdlListGrupoProdutos As New List(Of ClGrupoProduto)
    Public mdlListMarca As New List(Of ClMarca)
    Public mdlListDespesasProduto As New List(Of ClDespesaProduto)
    Public ListaFornecedores As New List(Of ClFornecedor)
    Public mdlListBairros As New List(Of ClBairro)
    Public mdlListRuas As New List(Of ClRua)
    Public ListaClientes As New List(Of ClCliente)
    Public ListaServicos As New List(Of ClServicos)
    Public mdlListEmpresa As New List(Of ClEmpresa)
    Public mdlListProdutosServico As New List(Of ClProdutoServico)
    Public ListaAReceberTotal As New List(Of ClAReceberTotal)
    Public mdlListAReceberParcial As New List(Of ClAReceberParcial)
    Public ListaGrupoDespMensal As New List(Of ClGrupoDespMensal)
    Public mdlListSubGrupoDespMensal As New List(Of ClSubGrupoDespMensal)
    Public ListaDespesaMensal As New List(Of ClDespesaMensal)
    Public ListaAPagarTotal As New List(Of ClAPagarTotal)
    Public mdlListAPagarParcial As New List(Of ClAPagarParcial)
    Public mdlListTipoDocumentos As New List(Of ClTipoDocumento)
    Public mdlListCidades As New List(Of Cl_Municipio)
    Public ListaAgendamentos As New List(Of ClAgendamento)
    Public mdlListUsuarios As New List(Of ClUsuario)
    Public ListaCaixas As New List(Of ClCaixa)
    Public ListaAbrirFecharCX As New List(Of ClAbrirFecharCaixa)
    Public ListaVendaServico As New List(Of ClVendaServico)
    Public ListaVendaServicoItens As New List(Of ClVendaServicoItens)
    Public ListaIMC As New List(Of ClIMC)
    Public ListaInfoSaudePessoa As New List(Of ClInfoSaudePessoa)
    Public ListaItemsInfoSaudePessoa As New List(Of ClInfoSaudePessoaItem)

    'Objetos Configuracoes
    Public mdlUsuarioLogado As New ClUsuario
    Public mdlEmpresa As New ClEmpresa
    Public mdlConfiguracoes As New ClConfiguracoes
    Public mdlConfiguracoesDAO As New ClConfiguracoesDAO
    Public mdlPadraoSistema As New ClPadraoSistema
    Public mdlPadraoSistemaDAO As New ClPadraoSistemaDAO

End Module
