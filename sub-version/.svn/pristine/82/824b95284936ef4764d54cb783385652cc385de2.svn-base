Public Class ClAPagarParcial

    Private _app_id As Int64, _app_aptid As Int64, _app_datapagamento As Date, _app_valor As Double, _app_tipopagamento As String
    Private _app_descrpagamento As String, _app_desconto As Double, _app_acrescimo As Double, _app_funcionarioid As Integer
    Private _app_funcionarionome As String
    Private _app_idcaixa As Integer, _app_pagodinheiro As Double, _app_pagocartaocred As Double
    Private _app_pagocartaodeb As Double, _app_pagopix As Double, _app_pagotransferencia As Double
    Private _app_valortotal As Double

    Sub New(Optional ByVal id As Int64 = 0, Optional ByVal artid As Int64 = 0, Optional ByVal datapagamento As Date = Nothing, _
            Optional ByVal valor As Double = 0, Optional ByVal tipopagamento As String = "", Optional ByVal descrpagamento As String = "", _
            Optional ByVal desconto As Double = 0, Optional ByVal acrescimo As Double = 0, Optional ByVal funcionarioid As Integer = 0, _
            Optional ByVal funcionarionome As String = "", Optional ByVal idcaixa As Integer = 0, _
            Optional ByVal pagodinheiro As Double = 0, Optional ByVal pagocartaocred As Double = 0, Optional ByVal pagocartaodeb As Double = 0, _
            Optional ByVal pagopix As Double = 0, Optional ByVal pagotransferencia As Double = 0, Optional ByVal valortotal As Double = 0)

        Me._app_id = id : Me._app_aptid = artid : Me._app_datapagamento = datapagamento : Me._app_valor = valor
        Me._app_tipopagamento = tipopagamento : Me._app_descrpagamento = descrpagamento : Me._app_desconto = desconto
        Me._app_acrescimo = acrescimo : Me._app_funcionarioid = funcionarioid : Me._app_funcionarionome = funcionarionome
        Me._app_idcaixa = idcaixa : Me._app_pagodinheiro = pagodinheiro : Me._app_pagocartaocred = pagocartaocred
        Me._app_pagocartaodeb = pagocartaodeb : Me._app_pagopix = pagopix : Me._app_pagotransferencia = pagotransferencia
        Me._app_valortotal = valortotal
    End Sub

    Sub New(APagarParcial As ClAPagarParcial)

        With Me
            .app_id = APagarParcial.app_id
            ._app_aptid = APagarParcial._app_aptid
            ._app_datapagamento = APagarParcial._app_datapagamento
            ._app_valor = APagarParcial._app_valor
            ._app_tipopagamento = APagarParcial._app_tipopagamento
            ._app_descrpagamento = APagarParcial._app_descrpagamento
            ._app_desconto = APagarParcial._app_desconto
            ._app_acrescimo = APagarParcial._app_acrescimo
            ._app_funcionarioid = APagarParcial._app_funcionarioid
            ._app_funcionarionome = APagarParcial._app_funcionarionome
            ._app_idcaixa = APagarParcial._app_idcaixa
            ._app_pagodinheiro = APagarParcial._app_pagodinheiro
            ._app_pagocartaocred = APagarParcial._app_pagocartaocred
            ._app_pagocartaodeb = APagarParcial._app_pagocartaodeb
            ._app_pagopix = APagarParcial._app_pagopix
            ._app_pagotransferencia = APagarParcial._app_pagotransferencia
            ._app_valortotal = APagarParcial._app_valortotal

        End With
    End Sub

    Sub SetaValores(APagarParcial As ClAPagarParcial)

        With Me
            .app_id = APagarParcial.app_id
            ._app_aptid = APagarParcial._app_aptid
            ._app_datapagamento = APagarParcial._app_datapagamento
            ._app_valor = APagarParcial._app_valor
            ._app_tipopagamento = APagarParcial._app_tipopagamento
            ._app_descrpagamento = APagarParcial._app_descrpagamento
            ._app_desconto = APagarParcial._app_desconto
            ._app_acrescimo = APagarParcial._app_acrescimo
            ._app_funcionarioid = APagarParcial._app_funcionarioid
            ._app_funcionarionome = APagarParcial._app_funcionarionome
            ._app_idcaixa = APagarParcial._app_idcaixa
            ._app_pagodinheiro = APagarParcial._app_pagodinheiro
            ._app_pagocartaocred = APagarParcial._app_pagocartaocred
            ._app_pagocartaodeb = APagarParcial._app_pagocartaodeb
            ._app_pagopix = APagarParcial._app_pagopix
            ._app_pagotransferencia = APagarParcial._app_pagotransferencia
            ._app_valortotal = APagarParcial._app_valortotal

        End With
    End Sub

    Sub ZeraValores()
        Me._app_id = 0 : Me._app_aptid = 0 : Me._app_datapagamento = Nothing : Me._app_valor = 0
        Me._app_tipopagamento = "" : Me._app_descrpagamento = "" : Me._app_desconto = 0
        Me._app_acrescimo = 0 : Me._app_funcionarioid = 0 : Me._app_funcionarionome = ""
        Me._app_idcaixa = 0 : Me._app_pagodinheiro = 0 : Me._app_pagocartaocred = 0
        Me._app_pagocartaodeb = 0 : Me._app_pagopix = 0 : Me._app_pagotransferencia = 0
        Me._app_valortotal = 0
    End Sub

#Region "  Get e Set"

    Public Property app_id As Int64
        Get
            Return Me._app_id
        End Get
        Set(value As Int64)
            Me._app_id = value
        End Set
    End Property

    Public Property app_idcaixa As Integer
        Get
            Return Me._app_idcaixa
        End Get
        Set(value As Integer)
            Me._app_idcaixa = value
        End Set
    End Property

    Public Property app_valortotal As Double
        Get
            Return Me._app_valortotal
        End Get
        Set(value As Double)
            Me._app_valortotal = value
        End Set
    End Property

    Public Property app_pagodinheiro As Double
        Get
            Return Me._app_pagodinheiro
        End Get
        Set(value As Double)
            Me._app_pagodinheiro = value
        End Set
    End Property

    Public Property app_pagocartaocred As Double
        Get
            Return Me._app_pagocartaocred
        End Get
        Set(value As Double)
            Me._app_pagocartaocred = value
        End Set
    End Property

    Public Property app_pagocartaodeb As Double
        Get
            Return Me._app_pagocartaodeb
        End Get
        Set(value As Double)
            Me._app_pagocartaodeb = value
        End Set
    End Property

    Public Property app_pagopix As Double
        Get
            Return Me._app_pagopix
        End Get
        Set(value As Double)
            Me._app_pagopix = value
        End Set
    End Property

    Public Property app_pagotransferencia As Double
        Get
            Return Me._app_pagotransferencia
        End Get
        Set(value As Double)
            Me._app_pagotransferencia = value
        End Set
    End Property

    Public Property app_aptid As Int64
        Get
            Return Me._app_aptid
        End Get
        Set(value As Int64)
            Me._app_aptid = value
        End Set
    End Property

    Public Property app_datapagamento As Date
        Get
            Return Me._app_datapagamento
        End Get
        Set(value As Date)
            Me._app_datapagamento = value
        End Set
    End Property

    Public Property app_valor As Double
        Get
            Return Me._app_valor
        End Get
        Set(value As Double)
            Me._app_valor = value
        End Set
    End Property

    Public Property app_tipopagamento As String
        Get
            Return Me._app_tipopagamento
        End Get
        Set(value As String)
            Me._app_tipopagamento = value
        End Set
    End Property

    Public Property app_descrpagamento As String
        Get
            Return Me._app_descrpagamento
        End Get
        Set(value As String)
            Me._app_descrpagamento = value
        End Set
    End Property

    Public Property app_desconto As Double
        Get
            Return Me._app_desconto
        End Get
        Set(value As Double)
            Me._app_desconto = value
        End Set
    End Property

    Public Property app_acrescimo As Double
        Get
            Return Me._app_acrescimo
        End Get
        Set(value As Double)
            Me._app_acrescimo = value
        End Set
    End Property

    Public Property app_funcionarioid As Integer
        Get
            Return Me._app_funcionarioid
        End Get
        Set(value As Integer)
            Me._app_funcionarioid = value
        End Set
    End Property

    Public Property app_funcionarionome As String
        Get
            Return Me._app_funcionarionome
        End Get
        Set(value As String)
            Me._app_funcionarionome = value
        End Set
    End Property

#End Region

End Class
