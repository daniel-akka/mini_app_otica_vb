Public Class ClUsuarioTelas

    Public Property idUsuario As Integer
    'Cadastros:
    Public Property Cadastros As Boolean
    Public Property CadCliente As Boolean
    Public Property CadProduto As Boolean
    Public Property CadFornecedor As Boolean
    Public Property CadEmpresa As Boolean
    Public Property CadServico As Boolean
    Public Property CadFuncionario As Boolean
    Public Property CadCidade As Boolean
    Public Property CadGrupo As Boolean
    Public Property CadMarca As Boolean

    'Movimentação:
    Public Property Movimentacao As Boolean
    Public Property MovEntradaSaida As Boolean
    Public Property MovVendaServico As Boolean
    Public Property MovCaixa As Boolean
    Public Property MovFinanceiro As Boolean
    Public Property MovRelatorioCaixa As Boolean
    Public Property MovOutrasDespesas As Boolean

    Sub New()

        With Me

            'Cadastros:
            .Cadastros = False
            .CadCliente = False
            .CadProduto = False
            .CadFornecedor = False
            .CadEmpresa = False
            .CadServico = False
            .CadFuncionario = False
            .CadCidade = False
            .CadGrupo = False
            .CadMarca = False

            'Movimentacao:
            .Movimentacao = False
            .MovEntradaSaida = False
            .MovVendaServico = False
            .MovCaixa = False
            .MovFinanceiro = False
            .MovRelatorioCaixa = False
            .MovOutrasDespesas = False

        End With

    End Sub

    Sub setaUsuarioTelas(telas As ClUsuarioTelas)

        With Me

            'Cadastros:
            .Cadastros = telas.Cadastros
            .CadCliente = telas.CadCliente
            .CadProduto = telas.CadProduto
            .CadFornecedor = telas.CadFornecedor
            .CadEmpresa = telas.CadEmpresa
            .CadServico = telas.CadServico
            .CadFuncionario = telas.CadFuncionario
            .CadCidade = telas.CadCidade
            .CadGrupo = telas.CadGrupo
            .CadMarca = telas.CadMarca

            'Movimentacao:
            .Movimentacao = telas.Movimentacao
            .MovEntradaSaida = telas.MovEntradaSaida
            .MovVendaServico = telas.MovVendaServico
            .MovCaixa = telas.MovCaixa
            .MovFinanceiro = telas.MovFinanceiro
            .MovRelatorioCaixa = telas.MovRelatorioCaixa
            .MovOutrasDespesas = telas.MovOutrasDespesas

        End With

    End Sub
End Class
