Public Class ClUnidade

    Private uId As Int64
    Private uDescricao As String
    Public Property uPadrao As Boolean

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vNome As String = "", Optional ByVal vPadrao As Boolean = False)
        Me.uId = vId : Me.uDescricao = vNome : Me.uPadrao = vPadrao
    End Sub

    Public Sub ZeraValores()
        Me.uId = 0 : Me.uDescricao = "" : Me.uPadrao = False
    End Sub

#Region "Get e Set"

    Public Property Id() As Int64
        Get
            Return Me.uId
        End Get
        Set(value As Int64)
            Me.uId = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return Me.uDescricao
        End Get
        Set(value As String)
            Me.uDescricao = value
        End Set
    End Property

#End Region

End Class
