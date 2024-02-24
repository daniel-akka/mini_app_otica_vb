Public Class ClConfiguracoes

    Private idconfg As Int64
    Private limite_desconto As Double
    Private senhaPadrao As String
    Private diasVencCrediario As Int16
    Public liberar As Boolean = False
    Public appNome As String = "AppOtica"
    Public Property caminho_logo As String
    Public Property caminho_pasta_sgb As String
    Public Property caminho_pasta_sistema As String
    Public Property caminho_pasta_Sincronizar As String


    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vlimite_desconto As Double = 0, Optional ByVal vsenhaPadrao As String = "", _
            Optional ByVal vdiasVencCrediario As Int16 = 0, Optional ByVal caminhoLogo As String = "", Optional ByVal caminhoPastaSgbd As String = "", _
            Optional ByVal PastaSistema As String = "", Optional ByVal PastaSincronizar As String = "")
        Me.idconfg = vId : Me.limite_desconto = vlimite_desconto : Me.senhaPadrao = vsenhaPadrao
        Me.diasVencCrediario = vdiasVencCrediario
        Me.caminho_logo = caminhoLogo
        Me.caminho_pasta_sgb = caminhoPastaSgbd
        Me.caminho_pasta_sistema = PastaSistema
        Me.caminho_pasta_Sincronizar = PastaSincronizar
    End Sub

    Public Sub ZeraValores()
        Me.idconfg = 0 : Me.limite_desconto = 0 : Me.senhaPadrao = "" : Me.diasVencCrediario = 0
    End Sub

#Region "Get e Set"

    Public Property tId() As Int64
        Get
            Return Me.idconfg
        End Get
        Set(value As Int64)
            Me.idconfg = value
        End Set
    End Property

    Public Property tDiasVencCrediario() As Int16
        Get
            Return Me.diasVencCrediario
        End Get
        Set(value As Int16)
            Me.diasVencCrediario = value
        End Set
    End Property

    Public Property tLimiteDesconto() As Double
        Get
            Return Me.limite_desconto
        End Get
        Set(value As Double)
            Me.limite_desconto = value
        End Set
    End Property

    Public Property tSenhaPadrao() As String
        Get
            Return Me.senhaPadrao
        End Get
        Set(value As String)
            Me.senhaPadrao = value
        End Set
    End Property

#End Region

End Class
