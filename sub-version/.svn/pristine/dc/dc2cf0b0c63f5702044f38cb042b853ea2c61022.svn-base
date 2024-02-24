Public Class ClEntradaSaida

    Private _esid As Int64
    Private _estipo As String 'E-Entrada/S-Saída
    Private _esmotivo As String
    Private _esusuarioid As Integer
    Private _esusuarionome As String
    Private _esfornecedorid As Integer
    Private _esfornecedornome As String
    Private _esprodutoid As Integer
    Private _esprodutonome As String
    Private _esquantidade As Double
    Private _esdata As Date
    Private _esdatamovimentacao As Date 'Data Hora
    Private _esobservacao As String

    Sub New(Optional ByVal vesid As Int64 = 0, Optional ByVal vestipo As String = "", Optional ByVal vesmotivo As String = "", _
            Optional ByVal vesusuarioid As Integer = 0, Optional ByVal vesusuarionome As String = "", Optional ByVal vesfornecedorid As Integer = 0, _
            Optional ByVal vesfornecedornome As String = "", Optional ByVal vesprodutoid As Integer = 0, Optional ByVal vesprodutonome As String = "", _
            Optional ByVal vesquantidade As Double = 0.0, Optional ByVal vesdata As Date = Nothing, Optional ByVal vesdatamovimentacao As Date = Nothing, _
            Optional ByVal vesobservacao As String = "")


        Me._esid = vesid : Me._estipo = vestipo : Me._esmotivo = vesmotivo : Me._esusuarioid = vesusuarioid
        Me._esusuarionome = vesusuarionome : Me._esfornecedorid = vesfornecedorid : Me._esfornecedornome = vesfornecedornome
        Me._esprodutoid = vesprodutoid : Me._esprodutonome = vesprodutonome : Me._esquantidade = vesquantidade
        Me._esdata = vesdata : Me._esdatamovimentacao = vesdatamovimentacao : Me._esobservacao = vesobservacao
    End Sub

    Sub ZeraValores()

        Me._esid = 0 : Me._estipo = "" : Me._esmotivo = "" : Me._esusuarioid = 0
        Me._esusuarionome = "" : Me._esfornecedorid = 0 : Me._esfornecedornome = ""
        Me._esprodutoid = 0 : Me._esprodutonome = "" : Me._esquantidade = 0
        Me._esdata = Nothing : Me._esdatamovimentacao = Nothing : Me._esobservacao = ""
    End Sub

#Region "Get and Set"

    Public Property esid() As Int64
        Get
            Return Me._esid
        End Get
        Set(value As Int64)
            Me._esid = value
        End Set
    End Property

    Public Property estipo() As String
        Get
            Return Me._estipo
        End Get
        Set(value As String)
            Me._estipo = value
        End Set
    End Property

    Public Property esmotivo() As String
        Get
            Return Me._esmotivo
        End Get
        Set(value As String)
            Me._esmotivo = value
        End Set
    End Property

    Public Property esusuarioid() As Integer
        Get
            Return Me._esusuarioid
        End Get
        Set(value As Integer)
            Me._esusuarioid = value
        End Set
    End Property

    Public Property esusuarionome() As String
        Get
            Return Me._esusuarionome
        End Get
        Set(value As String)
            Me._esusuarionome = value
        End Set
    End Property

    Public Property esfornecedorid() As Integer
        Get
            Return Me._esfornecedorid
        End Get
        Set(value As Integer)
            Me._esfornecedorid = value
        End Set
    End Property

    Public Property esfornecedornome() As String
        Get
            Return Me._esfornecedornome
        End Get
        Set(value As String)
            Me._esfornecedornome = value
        End Set
    End Property

    Public Property esprodutoid() As Integer
        Get
            Return Me._esprodutoid
        End Get
        Set(value As Integer)
            Me._esprodutoid = value
        End Set
    End Property

    Public Property esprodutonome() As String
        Get
            Return Me._esprodutonome
        End Get
        Set(value As String)
            Me._esprodutonome = value
        End Set
    End Property

    Public Property esquantidade() As Integer
        Get
            Return Me._esquantidade
        End Get
        Set(value As Integer)
            Me._esquantidade = value
        End Set
    End Property

    Public Property esdata() As Date
        Get
            Return Me._esdata
        End Get
        Set(value As Date)
            Me._esdata = value
        End Set
    End Property

    Public Property esdatamovimentacao() As Date
        Get
            Return Me._esdatamovimentacao
        End Get
        Set(value As Date)
            Me._esdatamovimentacao = value
        End Set
    End Property

    Public Property esobservacao() As String
        Get
            Return Me._esobservacao
        End Get
        Set(value As String)
            Me._esobservacao = value
        End Set
    End Property

#End Region

End Class
