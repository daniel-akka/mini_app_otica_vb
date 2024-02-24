Public Class ClVendaServico

    Private _vsid As Int64, _vsempresaid As Integer, _vsclienteid As Integer
    Private _vsempresanome As String, _vsempresauf As String, _vsempresacidade As String, _vsclientenome As String
    Private _vsclienteuf As String, _vsclientecidade As String
    Private _vsdatahora As Date
    Private _vssubtotal As Double, _vsdesconto As Double, _vstotalgeral As Double, _vspagodinheiro As Double
    Private _vspagocredito As Double, _vspagodebito As Double, _vspagopix As Double, _vspagotransferencia As Double, _vspagocrediario As Double

    Sub New(Optional ByVal Id As Integer = 0, Optional ByVal EmpresaId As Integer = 0, Optional ByVal ClienteId As Integer = 0, _
            Optional ByVal EmpresaNome As String = "", Optional ByVal EmpresaUf As String = "", Optional ByVal EmpresaCidade As String = "", _
            Optional ByVal ClienteNome As String = "", Optional ByVal ClienteUf As String = "", Optional ByVal ClienteCidade As String = "", _
            Optional ByVal Datahora As Date = Nothing, Optional ByVal SubTotal As Double = 0.0, Optional ByVal Desconto As Double = 0.0, _
            Optional ByVal TotalGeral As Double = 0.0, Optional ByVal PagoDinheiro As Double = 0.0, Optional ByVal PagoCredito As Double = 0.0, _
            Optional ByVal PagoDebito As Double = 0.0, Optional ByVal PagoPix As Double = 0.0, Optional ByVal PagoTransferencias As Double = 0.0, _
            Optional ByVal PagoCrediario As Double = 0.0)

        Me._vsid = Id : Me._vsempresaid = EmpresaId : Me._vsclienteid = ClienteId : Me._vsempresanome = EmpresaNome
        Me._vsempresauf = EmpresaUf : Me._vsempresacidade = EmpresaCidade : Me._vsclientenome = ClienteNome
        Me._vsclienteuf = ClienteUf : Me._vsclientecidade = ClienteCidade : Me._vsdatahora = Datahora
        Me._vssubtotal = SubTotal : Me._vsdesconto = Desconto : Me._vstotalgeral = TotalGeral : Me._vspagodinheiro = PagoDinheiro
        Me._vspagocredito = PagoCredito : Me._vspagodebito = PagoDebito : Me._vspagopix = PagoPix : Me._vspagotransferencia = PagoTransferencias
        Me._vspagocrediario = PagoCrediario
    End Sub

    Sub New(VendaServico As ClVendaServico)

        With Me

            .vsid = VendaServico.vsid
            ._vsempresaid = VendaServico._vsempresaid
            ._vsclienteid = VendaServico._vsclienteid
            ._vsempresanome = VendaServico._vsempresanome
            ._vsempresauf = VendaServico._vsempresauf
            ._vsempresacidade = VendaServico._vsempresacidade
            ._vsclientenome = VendaServico._vsclientenome
            ._vsclienteuf = VendaServico._vsclienteuf
            ._vsclientecidade = VendaServico._vsclientecidade
            ._vsdatahora = VendaServico._vsdatahora
            ._vssubtotal = VendaServico._vssubtotal
            ._vsdesconto = VendaServico._vsdesconto
            ._vstotalgeral = VendaServico._vstotalgeral
            ._vspagodinheiro = VendaServico._vspagodinheiro
            ._vspagocredito = VendaServico._vspagocredito
            ._vspagodebito = VendaServico._vspagodebito
            ._vspagopix = VendaServico._vspagopix
            ._vspagotransferencia = VendaServico._vspagotransferencia
            ._vspagocrediario = VendaServico._vspagocrediario
        End With
    End Sub

    Sub SetValores(VendaServico As ClVendaServico)

        With Me

            .vsid = VendaServico.vsid
            ._vsempresaid = VendaServico._vsempresaid
            ._vsclienteid = VendaServico._vsclienteid
            ._vsempresanome = VendaServico._vsempresanome
            ._vsempresauf = VendaServico._vsempresauf
            ._vsempresacidade = VendaServico._vsempresacidade
            ._vsclientenome = VendaServico._vsclientenome
            ._vsclienteuf = VendaServico._vsclienteuf
            ._vsclientecidade = VendaServico._vsclientecidade
            ._vsdatahora = VendaServico._vsdatahora
            ._vssubtotal = VendaServico._vssubtotal
            ._vsdesconto = VendaServico._vsdesconto
            ._vstotalgeral = VendaServico._vstotalgeral
            ._vspagodinheiro = VendaServico._vspagodinheiro
            ._vspagocredito = VendaServico._vspagocredito
            ._vspagodebito = VendaServico._vspagodebito
            ._vspagopix = VendaServico._vspagopix
            ._vspagotransferencia = VendaServico._vspagotransferencia
            ._vspagocrediario = VendaServico._vspagocrediario
        End With
    End Sub

    Sub ZeraValores()
        Me._vsid = 0 : Me._vsempresaid = 0 : Me._vsclienteid = 0
        Me._vsempresanome = "" : Me._vsempresauf = "" : Me._vsempresacidade = "" : Me._vsclientenome = ""
        Me._vsclienteuf = "" : Me._vsclientecidade = ""
        Me._vsdatahora = Nothing
        Me._vssubtotal = 0.0 : Me._vsdesconto = 0.0 : Me._vstotalgeral = 0.0 : Me._vspagodinheiro = 0.0
        Me._vspagocredito = 0.0 : Me._vspagodebito = 0.0 : Me._vspagopix = 0.0 : Me._vspagotransferencia = 0.0
        Me._vspagocrediario = 0
    End Sub

#Region "Get and Set"

    Public Property vsid() As Int64
        Get
            Return Me._vsid
        End Get
        Set(value As Int64)
            Me._vsid = value
        End Set
    End Property

    Public Property vsempresaid() As Integer
        Get
            Return Me._vsempresaid
        End Get
        Set(value As Integer)
            Me._vsempresaid = value
        End Set
    End Property

    Public Property vsclienteid() As Integer
        Get
            Return Me._vsclienteid
        End Get
        Set(value As Integer)
            Me._vsclienteid = value
        End Set
    End Property

    Public Property vsempresanome() As String
        Get
            Return Me._vsempresanome
        End Get
        Set(value As String)
            Me._vsempresanome = value
        End Set
    End Property

    Public Property vsempresauf() As String
        Get
            Return Me._vsempresauf
        End Get
        Set(value As String)
            Me._vsempresauf = value
        End Set
    End Property

    Public Property vsempresacidade() As String
        Get
            Return Me._vsempresacidade
        End Get
        Set(value As String)
            Me._vsempresacidade = value
        End Set
    End Property

    Public Property vsclientenome() As String
        Get
            Return Me._vsclientenome
        End Get
        Set(value As String)
            Me._vsclientenome = value
        End Set
    End Property

    Public Property vsclienteuf() As String
        Get
            Return Me._vsclienteuf
        End Get
        Set(value As String)
            Me._vsclienteuf = value
        End Set
    End Property

    Public Property vsclientecidade() As String
        Get
            Return Me._vsclientecidade
        End Get
        Set(value As String)
            Me._vsclientecidade = value
        End Set
    End Property

    Public Property vsdatahora() As Date
        Get
            Return Me._vsdatahora
        End Get
        Set(value As Date)
            Me._vsdatahora = value
        End Set
    End Property

    Public Property vssubtotal() As Double
        Get
            Return Me._vssubtotal
        End Get
        Set(value As Double)
            Me._vssubtotal = value
        End Set
    End Property

    Public Property vsdesconto() As Double
        Get
            Return Me._vsdesconto
        End Get
        Set(value As Double)
            Me._vsdesconto = value
        End Set
    End Property

    Public Property vstotalgeral() As Double
        Get
            Return Me._vstotalgeral
        End Get
        Set(value As Double)
            Me._vstotalgeral = value
        End Set
    End Property

    Public Property vspagodinheiro() As Double
        Get
            Return Me._vspagodinheiro
        End Get
        Set(value As Double)
            Me._vspagodinheiro = value
        End Set
    End Property

    Public Property vspagocredito() As Double
        Get
            Return Me._vspagocredito
        End Get
        Set(value As Double)
            Me._vspagocredito = value
        End Set
    End Property

    Public Property vspagodebito() As Double
        Get
            Return Me._vspagodebito
        End Get
        Set(value As Double)
            Me._vspagodebito = value
        End Set
    End Property

    Public Property vspagopix() As Double
        Get
            Return Me._vspagopix
        End Get
        Set(value As Double)
            Me._vspagopix = value
        End Set
    End Property

    Public Property vspagotransferencia() As Double
        Get
            Return Me._vspagotransferencia
        End Get
        Set(value As Double)
            Me._vspagotransferencia = value
        End Set
    End Property

    Public Property vspagocrediario() As Double
        Get
            Return Me._vspagocrediario
        End Get
        Set(value As Double)
            Me._vspagocrediario = value
        End Set
    End Property

#End Region

End Class
