Public Class ClProdutoServico

    Private _psid As Integer, _psidservico As Integer, _psidproduto As Integer
    Private _psprodutodescricao As String
    Private _psquantidade As Double

    Sub New(Optional ByVal vid As Integer = 0, Optional ByVal vidServico As Integer = 0, Optional ByVal vidProduto As Integer = 0, _
            Optional ByVal vprodutoDescricao As String = "", Optional ByVal vQuantidade As Double = 0)
        Me._psid = vid : Me._psidproduto = vidProduto : Me._psidservico = vidServico
        Me._psprodutodescricao = vprodutoDescricao : Me._psquantidade = vQuantidade
    End Sub

    Sub ZeraValores()
        Me._psid = 0 : Me._psidproduto = 0 : Me._psidservico = 0
        Me._psprodutodescricao = "" : Me._psquantidade = 0
    End Sub

#Region "Get e Set"

    Public Property psId() As Integer
        Get
            Return Me._psid
        End Get
        Set(value As Integer)
            Me._psid = value
        End Set
    End Property

    Public Property psQuantidade() As Double
        Get
            Return Me._psquantidade
        End Get
        Set(value As Double)
            Me._psquantidade = value
        End Set
    End Property

    Public Property psProdutoDescricao() As String
        Get
            Return Me._psprodutodescricao
        End Get
        Set(value As String)
            Me._psprodutodescricao = value
        End Set
    End Property

    Public Property psIdServico() As Integer
        Get
            Return Me._psidservico
        End Get
        Set(value As Integer)
            Me._psidservico = value
        End Set
    End Property

    Public Property psIdProduto() As Integer
        Get
            Return Me._psidproduto
        End Get
        Set(value As Integer)
            Me._psidproduto = value
        End Set
    End Property

#End Region
End Class
