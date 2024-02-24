Public Class ClProduto
    Inherits ClProdutoDAO

    Private p_Id As Int64
    Private p_Descricao As String
    Private p_custo As Double
    Private p_Codigo As Int32
    Private p_Informacao As String
    Private p_margemlucro As Double
    Private p_venda As Double
    Private p_estoque As Double
    Private p_unidade As String
    Private p_peso As Double
    Private p_despadicional As Double

    'Outros:
    Public Property p_Grupo As String
    Public Property p_IdGrupo As String
    Public Property p_Marca As String
    Public Property p_IdMarca As String
    Public Property p_Referencia As String
    Public Property p_Cor As String

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vCodigo As Int32 = 0, Optional ByVal vMargemLucro As Double = 0.0, _
            Optional ByVal vCusto As Double = 0.0, Optional ByVal vVenda As Double = 0.0, Optional ByVal vEstoque As Double = 0.0, _
            Optional ByVal vUnidade As String = "", Optional ByVal vDescricao As String = "", _
            Optional ByVal vInformacao As String = "", Optional ByVal vPeso As Double = 0.0, Optional ByVal vDepsAdicional As Double = 0.0, _
            Optional ByVal vIdGrupo As Int32 = 0, Optional ByVal vGrupo As String = "", Optional ByVal vIdMarca As Int32 = 0, _
            Optional ByVal vMarca As String = "", Optional ByVal vReferencia As String = "", Optional ByVal vCor As String = "")
        Me.p_Id = vId : Me.p_Codigo = vCodigo : Me.p_custo = vCusto : Me.p_margemlucro = vMargemLucro
        Me.p_venda = vVenda : Me.p_estoque = vEstoque : Me.p_unidade = vUnidade
        Me.p_Descricao = vDescricao : Me.p_Informacao = vInformacao : Me.p_peso = 0.0 : Me.p_despadicional = vDepsAdicional
        Me.p_IdGrupo = vIdGrupo : Me.p_Grupo = vGrupo : Me.p_IdMarca = vIdMarca : Me.p_Marca = vMarca
        Me.p_Referencia = vReferencia : Me.p_Cor = vCor
    End Sub

    Sub New(prod As ClProduto)

        With Me

            .p_Id = prod.pId
            .p_Codigo = prod.pCodigo
            .p_custo = prod.pCusto
            .p_margemlucro = prod.pMargemLucro
            .p_venda = prod.pVenda
            .p_estoque = prod.pEstoque
            .p_unidade = prod.pUnidade
            .p_Descricao = prod.pDescricao
            .p_Informacao = prod.pInformacao
            .p_peso = prod.pPeso
            .p_despadicional = prod.pDespAdicional

            'outros:
            .p_IdGrupo = prod.p_IdGrupo
            .p_Grupo = prod.p_Grupo
            .p_IdMarca = prod.p_IdMarca
            .p_Marca = prod.p_Marca
            .p_Referencia = prod.p_Referencia
            .p_Cor = prod.p_Cor
        End With
    End Sub

    Sub setaValores(prod As ClProduto)

        With Me

            .p_Id = prod.pId
            .p_Codigo = prod.pCodigo
            .p_custo = prod.pCusto
            .p_margemlucro = prod.pMargemLucro
            .p_venda = prod.pVenda
            .p_estoque = prod.pEstoque
            .p_unidade = prod.pUnidade
            .p_Descricao = prod.pDescricao
            .p_Informacao = prod.pInformacao
            .p_peso = prod.pPeso
            .p_despadicional = prod.pDespAdicional

            'outros:
            .p_IdGrupo = prod.p_IdGrupo
            .p_Grupo = prod.p_Grupo
            .p_IdMarca = prod.p_IdMarca
            .p_Marca = prod.p_Marca
            .p_Referencia = prod.p_Referencia
            .p_Cor = prod.p_Cor
        End With
    End Sub

    Public Sub ZeraValores()

        Me.p_Id = 0 : Me.p_Codigo = 0 : Me.p_custo = 0.0 : Me.pMargemLucro = 0.0 : Me.p_venda = 0.0
        Me.p_Descricao = "" : Me.p_Informacao = "" : Me.p_estoque = 0.0 : Me.p_unidade = "" : Me.p_peso = 0.0
        Me.p_despadicional = 0.0
        Me.p_IdGrupo = 0 : Me.p_Grupo = "" : Me.p_IdMarca = 0 : Me.p_Marca = ""
        Me.p_Referencia = "" : Me.p_Cor = ""
    End Sub

#Region "Get e Set"

    Public Property pId() As Int64
        Get
            Return Me.p_Id
        End Get
        Set(value As Int64)
            Me.p_Id = value
        End Set
    End Property

    Public Property pDescricao() As String
        Get
            Return Me.p_Descricao
        End Get
        Set(value As String)
            Me.p_Descricao = value
        End Set
    End Property

    Public Property pUnidade() As String
        Get
            Return Me.p_unidade
        End Get
        Set(value As String)
            Me.p_unidade = value
        End Set
    End Property

    Public Property pCusto() As Double
        Get
            Return Me.p_custo
        End Get
        Set(value As Double)
            Me.p_custo = value
        End Set
    End Property

    Public Property pCodigo() As Int32
        Get
            Return Me.p_Codigo
        End Get
        Set(value As Int32)
            Me.p_Codigo = value
        End Set
    End Property

    Public Property pInformacao() As String
        Get
            Return Me.p_Informacao
        End Get
        Set(value As String)
            Me.p_Informacao = value
        End Set
    End Property

    Public Property pMargemLucro() As Double
        Get
            Return Me.p_margemlucro
        End Get
        Set(value As Double)
            Me.p_margemlucro = value
        End Set
    End Property

    Public Property pVenda() As Double
        Get
            Return Me.p_venda
        End Get
        Set(value As Double)
            Me.p_venda = value
        End Set
    End Property

    Public Property pEstoque() As Double
        Get
            Return Me.p_estoque
        End Get
        Set(value As Double)
            Me.p_estoque = value
        End Set
    End Property

    Public Property pPeso() As Double
        Get
            Return Me.p_peso
        End Get
        Set(value As Double)
            Me.p_peso = value
        End Set
    End Property

    Public Property pDespAdicional() As Double
        Get
            Return Me.p_despadicional
        End Get
        Set(value As Double)
            Me.p_despadicional = value
        End Set
    End Property
#End Region

End Class
