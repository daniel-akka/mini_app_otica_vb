Public Class ClServicos
    Private _sid As Integer, _sidatendente As Integer
    Private _sdescricao As String, _sdataalteracao As String, _snomeatendente As String
    Private _svalor As Double, _sdespcartaodinheiro As Double, _sdespcartaoporcentagem As Double

    Sub New(Optional ByVal vsid As Integer = 0, Optional ByVal vsdescricao As String = "", Optional ByVal vsdataalteracao As String = "", _
            Optional ByVal vsvalor As Double = 0.0, Optional ByVal vsdespcartaodinheiro As Double = 0.0, Optional ByVal vsdespcartaoporcentagem As Double = 0.0, _
            Optional ByVal vsidAtendente As Integer = 0, Optional ByVal vsnomeatendente As String = "")

        Me._sid = vsid : Me._sdescricao = vsdescricao : Me._sdataalteracao = vsdataalteracao
        Me._svalor = vsvalor : Me._sdespcartaodinheiro = vsdespcartaodinheiro : Me._sdespcartaoporcentagem = vsdespcartaoporcentagem
        Me._sidatendente = vsidAtendente : Me._snomeatendente = vsnomeatendente
    End Sub

    Sub New(serv As ClServicos)

        With Me

            ._sid = serv.sid
            ._sdescricao = serv.sdescricao
            ._svalor = serv.svalor
            ._sdespcartaodinheiro = serv.sdespcartaodinheiro
            ._sdespcartaoporcentagem = serv.sdespcartaoporcentagem
            ._sidatendente = serv.sidatendente
            ._snomeatendente = serv.snomeatendente
            ._sdataalteracao = serv.sdataalteracao
        End With
    End Sub

    Sub setaValores(serv As ClServicos)

        With Me

            ._sid = serv.sid
            ._sdescricao = serv.sdescricao
            ._svalor = serv.svalor
            ._sdespcartaodinheiro = serv.sdespcartaodinheiro
            ._sdespcartaoporcentagem = serv.sdespcartaoporcentagem
            ._sidatendente = serv.sidatendente
            ._snomeatendente = serv.snomeatendente
            ._sdataalteracao = serv.sdataalteracao
        End With
    End Sub

    Sub ZeraValores()
        Me._sid = 0 : Me._sdescricao = "" : Me._sdataalteracao = ""
        Me._svalor = 0.0 : Me._sdespcartaodinheiro = 0.0 : Me._sdespcartaoporcentagem = 0.0
        Me._sidatendente = 0 : Me._snomeatendente = ""
    End Sub

#Region "Get and Set"

    Public Property sid() As Integer
        Get
            Return Me._sid
        End Get
        Set(value As Integer)
            Me._sid = value
        End Set
    End Property

    Public Property sidatendente() As Integer
        Get
            Return Me._sidatendente
        End Get
        Set(value As Integer)
            Me._sidatendente = value
        End Set
    End Property

    Public Property snomeatendente() As String
        Get
            Return Me._snomeatendente
        End Get
        Set(value As String)
            Me._snomeatendente = value
        End Set
    End Property

    Public Property sdescricao() As String
        Get
            Return Me._sdescricao
        End Get
        Set(value As String)
            Me._sdescricao = value
        End Set
    End Property

    Public Property sdataalteracao() As String
        Get
            Return Me._sdataalteracao
        End Get
        Set(value As String)
            Me._sdataalteracao = value
        End Set
    End Property

    Public Property sdespcartaodinheiro() As Double
        Get
            Return Me._sdespcartaodinheiro
        End Get
        Set(value As Double)
            Me._sdespcartaodinheiro = value
        End Set
    End Property

    Public Property svalor() As Double
        Get
            Return Me._svalor
        End Get
        Set(value As Double)
            Me._svalor = value
        End Set
    End Property

    Public Property sdespcartaoporcentagem() As Double
        Get
            Return Me._sdespcartaoporcentagem
        End Get
        Set(value As Double)
            Me._sdespcartaoporcentagem = value
        End Set
    End Property
#End Region
End Class
