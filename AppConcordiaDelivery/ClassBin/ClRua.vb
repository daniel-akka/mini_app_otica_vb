Public Class ClRua

    Private _Id As Int64
    Private _Nome As String

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vNome As String = "")
        Me._Id = vId : Me._Nome = vNome
    End Sub

    Public Sub ZeraValores()
        Me._Id = 0 : Me._Nome = ""
    End Sub

#Region "Get e Set"

    Public Property rId() As Int64
        Get
            Return Me._Id
        End Get
        Set(value As Int64)
            Me._Id = value
        End Set
    End Property

    Public Property rNome() As String
        Get
            Return Me._Nome
        End Get
        Set(value As String)
            Me._Nome = value
        End Set
    End Property

#End Region

End Class
