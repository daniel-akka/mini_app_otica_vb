Public Class ClDespesaProduto

    Private d_pid As Integer
    Private d_pdescricao As String
    Private d_pporcentagem As Double

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vDescricao As String = "", Optional ByVal vPorcentagem As Double = 0.0)
        Me.d_pid = vId : Me.d_pdescricao = vDescricao : Me.d_pporcentagem = vPorcentagem
    End Sub

    Public Sub ZeraValores()
        Me.d_pid = 0 : Me.d_pdescricao = ""
    End Sub

#Region "Get e Set"

    Public Property dpId() As Int64
        Get
            Return Me.d_pid
        End Get
        Set(value As Int64)
            Me.d_pid = value
        End Set
    End Property

    Public Property dpDescricao() As String
        Get
            Return Me.d_pdescricao
        End Get
        Set(value As String)
            Me.d_pdescricao = value
        End Set
    End Property

    Public Property dpPorcentagem() As String
        Get
            Return Me.d_pporcentagem
        End Get
        Set(value As String)
            Me.d_pporcentagem = value
        End Set
    End Property

#End Region
End Class
