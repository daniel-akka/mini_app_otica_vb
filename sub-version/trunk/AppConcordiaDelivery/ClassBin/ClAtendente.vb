Public Class ClAtendente

    Private a_Id As Int64
    Private a_Nome As String
    Private a_Comissao As Double

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vNome As String = "", Optional ByVal vcomissao As Double = 0.0)
        Me.a_Id = vId : Me.a_Nome = vNome : Me.a_Comissao = vcomissao
    End Sub

    Sub New(aten As ClAtendente)

        With Me
            .a_Id = aten.aId
            .a_Nome = aten.aNome
            .a_Comissao = aten.aComissao
        End With
    End Sub

    Sub setaValores(aten As ClAtendente)

        With Me
            .a_Id = aten.aId
            .a_Nome = aten.aNome
            .a_Comissao = aten.aComissao
        End With
    End Sub

    Public Sub ZeraValores()
        Me.a_Id = 0 : Me.a_Nome = "" : Me.a_Comissao = 0.0
    End Sub

#Region "Get e Set"

    Public Property aId() As Int64
        Get
            Return Me.a_Id
        End Get
        Set(value As Int64)
            Me.a_Id = value
        End Set
    End Property

    Public Property aNome() As String
        Get
            Return Me.a_Nome
        End Get
        Set(value As String)
            Me.a_Nome = value
        End Set
    End Property

    Public Property aComissao() As Double
        Get
            Return Me.a_Comissao
        End Get
        Set(value As Double)
            Me.a_Comissao = value
        End Set
    End Property

#End Region

End Class
