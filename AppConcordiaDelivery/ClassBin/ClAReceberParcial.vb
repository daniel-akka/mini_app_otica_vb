Public Class ClAReceberParcial

    Private _arp_id As Int64, _arp_artid As Int64, _arp_datapagamento As Date, _arp_valor As Double, _arp_tipopagamento As String
    Private _arp_descrpagamento As String, _arp_desconto As Double, _arp_acrescimo As Double, _arp_funcionarioid As Integer
    Private _arp_funcionarionome As String
    Private _arp_idcaixa As Integer, _arp_pagodinheiro As Double, _arp_pagocartaocred As Double
    Private _arp_pagocartaodeb As Double, _arp_pagopix As Double, _arp_pagotransferencia As Double
    Private _arp_valortotal As Double

    Sub New(Optional ByVal id As Int64 = 0, Optional ByVal artid As Int64 = 0, Optional ByVal datapagamento As Date = Nothing, _
            Optional ByVal valor As Double = 0, Optional ByVal tipopagamento As String = "", Optional ByVal descrpagamento As String = "", _
            Optional ByVal desconto As Double = 0, Optional ByVal acrescimo As Double = 0, Optional ByVal funcionarioid As Integer = 0, _
            Optional ByVal funcionarionome As String = "", Optional ByVal idcaixa As Integer = 0, _
            Optional ByVal pagodinheiro As Double = 0, Optional ByVal pagocartaocred As Double = 0, Optional ByVal pagocartaodeb As Double = 0, _
            Optional ByVal pagopix As Double = 0, Optional ByVal pagotransferencia As Double = 0, Optional ByVal valortotal As Double = 0)

        Me._arp_id = id : Me._arp_artid = artid : Me._arp_datapagamento = datapagamento : Me._arp_valor = valor
        Me._arp_tipopagamento = tipopagamento : Me._arp_descrpagamento = descrpagamento : Me._arp_desconto = desconto
        Me._arp_acrescimo = acrescimo : Me._arp_funcionarioid = funcionarioid : Me._arp_funcionarionome = funcionarionome
        Me._arp_idcaixa = idcaixa : Me._arp_pagodinheiro = pagodinheiro : Me._arp_pagocartaocred = pagocartaocred
        Me._arp_pagocartaodeb = pagocartaodeb : Me._arp_pagopix = pagopix : Me._arp_pagotransferencia = pagotransferencia
        Me._arp_valortotal = valortotal
    End Sub

    Sub New(AReceberParcial As ClAReceberParcial)

        With Me
            .arp_id = AReceberParcial.arp_id
            ._arp_artid = AReceberParcial._arp_artid
            ._arp_datapagamento = AReceberParcial._arp_datapagamento
            ._arp_valor = AReceberParcial._arp_valor
            ._arp_tipopagamento = AReceberParcial._arp_tipopagamento
            ._arp_descrpagamento = AReceberParcial._arp_descrpagamento
            ._arp_desconto = AReceberParcial._arp_desconto
            ._arp_acrescimo = AReceberParcial._arp_acrescimo
            ._arp_funcionarioid = AReceberParcial._arp_funcionarioid
            ._arp_funcionarionome = AReceberParcial._arp_funcionarionome
            ._arp_idcaixa = AReceberParcial._arp_idcaixa
            ._arp_pagodinheiro = AReceberParcial._arp_pagodinheiro
            ._arp_pagocartaocred = AReceberParcial._arp_pagocartaocred
            ._arp_pagocartaodeb = AReceberParcial._arp_pagocartaodeb
            ._arp_pagopix = AReceberParcial._arp_pagopix
            ._arp_pagotransferencia = AReceberParcial._arp_pagotransferencia
            ._arp_valortotal = AReceberParcial._arp_valortotal

        End With
    End Sub

    Sub SetaValores(AReceberParcial As ClAReceberParcial)

        With Me
            .arp_id = AReceberParcial.arp_id
            ._arp_artid = AReceberParcial._arp_artid
            ._arp_datapagamento = AReceberParcial._arp_datapagamento
            ._arp_valor = AReceberParcial._arp_valor
            ._arp_tipopagamento = AReceberParcial._arp_tipopagamento
            ._arp_descrpagamento = AReceberParcial._arp_descrpagamento
            ._arp_desconto = AReceberParcial._arp_desconto
            ._arp_acrescimo = AReceberParcial._arp_acrescimo
            ._arp_funcionarioid = AReceberParcial._arp_funcionarioid
            ._arp_funcionarionome = AReceberParcial._arp_funcionarionome
            ._arp_idcaixa = AReceberParcial._arp_idcaixa
            ._arp_pagodinheiro = AReceberParcial._arp_pagodinheiro
            ._arp_pagocartaocred = AReceberParcial._arp_pagocartaocred
            ._arp_pagocartaodeb = AReceberParcial._arp_pagocartaodeb
            ._arp_pagopix = AReceberParcial._arp_pagopix
            ._arp_pagotransferencia = AReceberParcial._arp_pagotransferencia
            ._arp_valortotal = AReceberParcial._arp_valortotal

        End With
    End Sub

    Sub ZeraValores()
        Me._arp_id = 0 : Me._arp_artid = 0 : Me._arp_datapagamento = Nothing : Me._arp_valor = 0
        Me._arp_tipopagamento = "" : Me._arp_descrpagamento = "" : Me._arp_desconto = 0
        Me._arp_acrescimo = 0 : Me._arp_funcionarioid = 0 : Me._arp_funcionarionome = ""
        Me._arp_idcaixa = 0 : Me._arp_pagodinheiro = 0 : Me._arp_pagocartaocred = 0
        Me._arp_pagocartaodeb = 0 : Me._arp_pagopix = 0 : Me._arp_pagotransferencia = 0
        Me._arp_valortotal = 0
    End Sub

#Region "  Get e Set"

    Public Property arp_id As Int64
        Get
            Return Me._arp_id
        End Get
        Set(value As Int64)
            Me._arp_id = value
        End Set
    End Property

    Public Property arp_idcaixa As Integer
        Get
            Return Me._arp_idcaixa
        End Get
        Set(value As Integer)
            Me._arp_idcaixa = value
        End Set
    End Property

    Public Property arp_valortotal As Double
        Get
            Return Me._arp_valortotal
        End Get
        Set(value As Double)
            Me._arp_valortotal = value
        End Set
    End Property

    Public Property arp_pagodinheiro As Double
        Get
            Return Me._arp_pagodinheiro
        End Get
        Set(value As Double)
            Me._arp_pagodinheiro = value
        End Set
    End Property

    Public Property arp_pagocartaocred As Double
        Get
            Return Me._arp_pagocartaocred
        End Get
        Set(value As Double)
            Me._arp_pagocartaocred = value
        End Set
    End Property

    Public Property arp_pagocartaodeb As Double
        Get
            Return Me._arp_pagocartaodeb
        End Get
        Set(value As Double)
            Me._arp_pagocartaodeb = value
        End Set
    End Property

    Public Property arp_pagopix As Double
        Get
            Return Me._arp_pagopix
        End Get
        Set(value As Double)
            Me._arp_pagopix = value
        End Set
    End Property

    Public Property arp_pagotransferencia As Double
        Get
            Return Me._arp_pagotransferencia
        End Get
        Set(value As Double)
            Me._arp_pagotransferencia = value
        End Set
    End Property

    Public Property arp_artid As Int64
        Get
            Return Me._arp_artid
        End Get
        Set(value As Int64)
            Me._arp_artid = value
        End Set
    End Property

    Public Property arp_datapagamento As Date
        Get
            Return Me._arp_datapagamento
        End Get
        Set(value As Date)
            Me._arp_datapagamento = value
        End Set
    End Property

    Public Property arp_valor As Double
        Get
            Return Me._arp_valor
        End Get
        Set(value As Double)
            Me._arp_valor = value
        End Set
    End Property

    Public Property arp_tipopagamento As String
        Get
            Return Me._arp_tipopagamento
        End Get
        Set(value As String)
            Me._arp_tipopagamento = value
        End Set
    End Property

    Public Property arp_descrpagamento As String
        Get
            Return Me._arp_descrpagamento
        End Get
        Set(value As String)
            Me._arp_descrpagamento = value
        End Set
    End Property

    Public Property arp_desconto As Double
        Get
            Return Me._arp_desconto
        End Get
        Set(value As Double)
            Me._arp_desconto = value
        End Set
    End Property

    Public Property arp_acrescimo As Double
        Get
            Return Me._arp_acrescimo
        End Get
        Set(value As Double)
            Me._arp_acrescimo = value
        End Set
    End Property

    Public Property arp_funcionarioid As Integer
        Get
            Return Me._arp_funcionarioid
        End Get
        Set(value As Integer)
            Me._arp_funcionarioid = value
        End Set
    End Property

    Public Property arp_funcionarionome As String
        Get
            Return Me._arp_funcionarionome
        End Get
        Set(value As String)
            Me._arp_funcionarionome = value
        End Set
    End Property

#End Region

End Class
