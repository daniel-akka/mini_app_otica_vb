Public Class ClFichaOtica
    Inherits ClFichaOticaDAO

    Public Property fo_id As Int64
    Public Property fo_coordenador As String
    Public Property fo_num_contrato As String
    Public Property fo_localidade As String
    Public Property fo_data_cadastro As Date
    Public Property fo_data_ficha As Date
    Public Property fo_data_alteracao As String
    Public Property fo_cliente_id As Int64
    Public Property fo_cliente_nome As String
    Public Property fo_cliente_fone As String
    Public Property fo_observacoes_gerais As String
    Public Property fo_datas_retorno As String
    Public Property fo_observacoes As String
    Public Property fo_assinatura_vendedor As String
    Public Property fo_soma As Double
    Public Property fo_entrada As Double
    Public Property fo_saldo As Double
    Public Property fo_prestacoes As Double
    Public Property fo_data_entrega As String
    Public Property fo_data_entrada As String
    Public Property fo_data_prestacoes As String

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vCoordenador As String = "", Optional ByVal vNumContrato As String = "", _
            Optional ByVal vLocalidade As String = "", Optional ByVal vDataCadastro As Date = Nothing, Optional ByVal vDataFicha As Date = Nothing, _
            Optional ByVal vDataAlteracao As String = "", Optional ByVal vClienteId As Int64 = 0, Optional ByVal vClienteNome As String = "", _
            Optional ByVal vClienteFone As String = "", Optional ByVal vObservacoesGerais As String = "", Optional ByVal vDatasRetorno As String = "", _
            Optional ByVal vObservacoes As String = "", Optional ByVal vAssinaturaVendedor As String = "", Optional ByVal vSoma As Double = 0, _
            Optional ByVal vEntrada As Double = 0, Optional ByVal vSaldo As Double = 0, Optional ByVal vPrestracoes As Double = 0, _
            Optional ByVal vDataEntrega As String = "", Optional ByVal vDataEntrada As String = "", Optional ByVal vDataPrestacoes As String = "")

        Me.fo_id = vId : Me.fo_coordenador = vCoordenador : Me.fo_num_contrato = vNumContrato : Me.fo_localidade = vLocalidade
        Me.fo_data_cadastro = vDataCadastro : Me.fo_data_ficha = vDataFicha : Me.fo_data_alteracao = vDataAlteracao
        Me.fo_cliente_id = vClienteId : Me.fo_cliente_nome = vClienteNome : Me.fo_cliente_fone = vClienteFone
        Me.fo_observacoes_gerais = vObservacoesGerais : Me.fo_datas_retorno = vDatasRetorno : Me.fo_observacoes = vObservacoes
        Me.fo_datas_retorno = vDatasRetorno : Me.fo_observacoes = vObservacoes : Me.fo_assinatura_vendedor = vAssinaturaVendedor
        Me.fo_soma = vSoma : Me.fo_entrada = vEntrada : Me.fo_saldo = vSaldo : Me.fo_prestacoes = vPrestracoes
        Me.fo_data_entrega = vDataEntrega : Me.fo_data_entrada = vDataEntrada : Me.fo_data_prestacoes = vDataPrestacoes
    End Sub

    Sub New(ByVal vFicha As ClFichaOtica)

        If Not IsNothing(vFicha) Then

            With Me

                .fo_id = vFicha.fo_id
                .fo_coordenador = vFicha.fo_coordenador
                .fo_num_contrato = vFicha.fo_num_contrato
                .fo_localidade = vFicha.fo_localidade
                .fo_data_cadastro = vFicha.fo_data_cadastro
                .fo_data_ficha = vFicha.fo_data_ficha
                .fo_data_alteracao = vFicha.fo_data_alteracao
                .fo_cliente_id = vFicha.fo_cliente_id
                .fo_cliente_nome = vFicha.fo_cliente_nome
                .fo_cliente_fone = vFicha.fo_cliente_fone
                .fo_observacoes_gerais = vFicha.fo_observacoes_gerais
                .fo_datas_retorno = vFicha.fo_datas_retorno
                .fo_observacoes = vFicha.fo_observacoes
                .fo_assinatura_vendedor = vFicha.fo_assinatura_vendedor
                .fo_soma = vFicha.fo_soma
                .fo_entrada = vFicha.fo_entrada
                .fo_saldo = vFicha.fo_saldo
                .fo_prestacoes = vFicha.fo_prestacoes
                .fo_data_entrega = vFicha.fo_data_entrega
                .fo_data_entrada = vFicha.fo_data_entrada
                .fo_data_prestacoes = vFicha.fo_data_prestacoes

            End With
        Else
            Me.ZeraValores()
        End If

    End Sub

    Sub SetaFichaOtica(ByVal vFicha As ClFichaOtica)

        If Not IsNothing(vFicha) Then

            With Me

                .fo_id = vFicha.fo_id
                .fo_coordenador = vFicha.fo_coordenador
                .fo_num_contrato = vFicha.fo_num_contrato
                .fo_localidade = vFicha.fo_localidade
                .fo_data_cadastro = vFicha.fo_data_cadastro
                .fo_data_ficha = vFicha.fo_data_ficha
                .fo_data_alteracao = vFicha.fo_data_alteracao
                .fo_cliente_id = vFicha.fo_cliente_id
                .fo_cliente_nome = vFicha.fo_cliente_nome
                .fo_cliente_fone = vFicha.fo_cliente_fone
                .fo_observacoes_gerais = vFicha.fo_observacoes_gerais
                .fo_datas_retorno = vFicha.fo_datas_retorno
                .fo_observacoes = vFicha.fo_observacoes
                .fo_assinatura_vendedor = vFicha.fo_assinatura_vendedor
                .fo_soma = vFicha.fo_soma
                .fo_entrada = vFicha.fo_entrada
                .fo_saldo = vFicha.fo_saldo
                .fo_prestacoes = vFicha.fo_prestacoes
                .fo_data_entrega = vFicha.fo_data_entrega
                .fo_data_entrada = vFicha.fo_data_entrada
                .fo_data_prestacoes = vFicha.fo_data_prestacoes

            End With
        Else
            Me.ZeraValores()
        End If

    End Sub

    Sub ZeraValores()

        With Me

            .fo_id = 0
            .fo_coordenador = ""
            .fo_num_contrato = ""
            .fo_localidade = ""
            .fo_data_cadastro = Nothing
            .fo_data_ficha = Nothing
            .fo_data_alteracao = ""
            .fo_cliente_id = 0
            .fo_cliente_nome = ""
            .fo_cliente_fone = ""
            .fo_observacoes_gerais = ""
            .fo_datas_retorno = ""
            .fo_observacoes = ""
            .fo_assinatura_vendedor = ""
            .fo_soma = 0
            .fo_entrada = 0
            .fo_saldo = 0
            .fo_prestacoes = 0
            .fo_data_entrega = ""
            .fo_data_entrada = ""
            .fo_data_prestacoes = ""

        End With
    End Sub

End Class
