Public Class ClRelatorioProdAux

    Private produto As String
    Private quantidade As Int16
    Private valorTotal As Double

    Sub New(ByVal vBrinquedo As String, vQuantidade As Int16, vValorTotal As Double)

        Me.produto = vBrinquedo
        Me.quantidade = vQuantidade
        Me.valorTotal = vValorTotal
    End Sub

    Public Sub zeraValores()
        Me.produto = ""
        Me.quantidade = 0
        Me.valorTotal = 0
    End Sub

    Public Property pBrinquedo() As String
        Get
            Return Me.produto
        End Get
        Set(value As String)
            Me.produto = value
        End Set
    End Property

    Public Property pQuantidade() As Int16
        Get
            Return Me.quantidade
        End Get
        Set(value As Int16)
            Me.quantidade = value
        End Set
    End Property

    Public Property pValorTotal() As Double
        Get
            Return Me.valorTotal
        End Get
        Set(value As Double)
            Me.valorTotal = value
        End Set
    End Property
End Class
