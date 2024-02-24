Public Class ClFichaOticaAssinatura
    Inherits ClFichaOticaAssinaturaDAO

    Public Property fa_id As Int64
    Public Property fa_ficha_id As Int64
    Public Property fa_numero As String
    Public Property fa_vencimento As String
    Public Property fa_valor As Double
    Public Property fa_texto1 As String
    Public Property fa_empresa_razao As String
    Public Property fa_empresa_cnpj_cpf As String
    Public Property fa_valor_extenso As String
    Public Property fa_moeda As String
    Public Property fa_cliente_id As String
    Public Property fa_cliente_nome As String
    Public Property fa_cliente_cnpj_cpf As String
    Public Property fa_data_emissao As String
    Public Property fa_cliente_endereco As String
    Public Property fa_assinatura_cliente As String

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vFichaId As Int64 = 0, Optional ByVal vNumero As String = "", _
            Optional ByVal vVencimento As String = "", Optional ByVal vValor As Double = 0, Optional ByVal vTexto1 As String = "", _
            Optional ByVal vEmpresaRazao As String = "", Optional ByVal vEmpresaCnpjCpf As String = "", Optional ByVal vValorExtenso As String = "", _
            Optional ByVal vMoeda As String = "", Optional ByVal vClienteId As Int64 = 0, Optional ByVal vClienteNome As String = "", _
            Optional ByVal vClienteCnpjCpf As String = "", Optional ByVal vDataEmissao As String = "", Optional ByVal vClienteEndereco As String = "", _
            Optional ByVal vAssinaturaCliente As String = "")

        Me.fa_id = vId : Me.fa_ficha_id = vFichaId : Me.fa_numero = vNumero : Me.fa_vencimento = vVencimento : Me.fa_valor = vValor
        Me.fa_texto1 = vTexto1 : Me.fa_empresa_razao = vEmpresaRazao : Me.fa_empresa_cnpj_cpf = vEmpresaCnpjCpf
        Me.fa_valor_extenso = vValorExtenso : Me.fa_moeda = vMoeda : Me.fa_cliente_id = vClienteId : Me.fa_cliente_nome = vClienteNome
        Me.fa_cliente_cnpj_cpf = vClienteCnpjCpf : Me.fa_data_emissao = vDataEmissao : Me.fa_cliente_endereco = vClienteEndereco
        Me.fa_assinatura_cliente = vAssinaturaCliente

    End Sub

    Sub New(ByVal vFichaOticaAssinatura As ClFichaOticaAssinatura)

        If Not IsNothing(vFichaOticaAssinatura) Then

            With Me

                .fa_id = vFichaOticaAssinatura.fa_id
                .fa_ficha_id = vFichaOticaAssinatura.fa_ficha_id
                .fa_numero = vFichaOticaAssinatura.fa_numero
                .fa_vencimento = vFichaOticaAssinatura.fa_vencimento
                .fa_valor = vFichaOticaAssinatura.fa_valor
                .fa_texto1 = vFichaOticaAssinatura.fa_texto1
                .fa_empresa_razao = vFichaOticaAssinatura.fa_empresa_razao
                .fa_empresa_cnpj_cpf = vFichaOticaAssinatura.fa_empresa_cnpj_cpf
                .fa_valor_extenso = vFichaOticaAssinatura.fa_valor_extenso
                .fa_moeda = vFichaOticaAssinatura.fa_moeda
                .fa_cliente_id = vFichaOticaAssinatura.fa_cliente_id
                .fa_cliente_nome = vFichaOticaAssinatura.fa_cliente_nome
                .fa_cliente_cnpj_cpf = vFichaOticaAssinatura.fa_cliente_cnpj_cpf
                .fa_data_emissao = vFichaOticaAssinatura.fa_data_emissao
                .fa_cliente_endereco = vFichaOticaAssinatura.fa_cliente_endereco
                .fa_assinatura_cliente = vFichaOticaAssinatura.fa_assinatura_cliente
            End With
        Else
            Me.ZeraValores()
        End If
    End Sub

    Sub SetaValores(ByVal vFichaOticaAssinatura As ClFichaOticaAssinatura)

        If Not IsNothing(vFichaOticaAssinatura) Then

            With Me

                .fa_id = vFichaOticaAssinatura.fa_id
                .fa_ficha_id = vFichaOticaAssinatura.fa_ficha_id
                .fa_numero = vFichaOticaAssinatura.fa_numero
                .fa_vencimento = vFichaOticaAssinatura.fa_vencimento
                .fa_valor = vFichaOticaAssinatura.fa_valor
                .fa_texto1 = vFichaOticaAssinatura.fa_texto1
                .fa_empresa_razao = vFichaOticaAssinatura.fa_empresa_razao
                .fa_empresa_cnpj_cpf = vFichaOticaAssinatura.fa_empresa_cnpj_cpf
                .fa_valor_extenso = vFichaOticaAssinatura.fa_valor_extenso
                .fa_moeda = vFichaOticaAssinatura.fa_moeda
                .fa_cliente_id = vFichaOticaAssinatura.fa_cliente_id
                .fa_cliente_nome = vFichaOticaAssinatura.fa_cliente_nome
                .fa_cliente_cnpj_cpf = vFichaOticaAssinatura.fa_cliente_cnpj_cpf
                .fa_data_emissao = vFichaOticaAssinatura.fa_data_emissao
                .fa_cliente_endereco = vFichaOticaAssinatura.fa_cliente_endereco
                .fa_assinatura_cliente = vFichaOticaAssinatura.fa_assinatura_cliente
            End With
        Else
            Me.ZeraValores()
        End If
    End Sub

    Sub ZeraValores()

        With Me

            .fa_id = 0
            .fa_ficha_id = 0
            .fa_numero = ""
            .fa_vencimento = ""
            .fa_valor = 0
            .fa_texto1 = ""
            .fa_empresa_razao = ""
            .fa_empresa_cnpj_cpf = ""
            .fa_valor_extenso = ""
            .fa_moeda = ""
            .fa_cliente_id = 0
            .fa_cliente_nome = ""
            .fa_cliente_cnpj_cpf = ""
            .fa_data_emissao = ""
            .fa_cliente_endereco = ""
            .fa_assinatura_cliente = ""
        End With
    End Sub
End Class
