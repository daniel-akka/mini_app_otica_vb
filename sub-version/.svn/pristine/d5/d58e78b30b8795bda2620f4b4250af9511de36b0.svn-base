Public Class ClAReceberTotal

    Private _art_id As Int64, _art_empresaid As Integer, _art_empresanome As String
    Private _art_clienteid As Integer, _art_clientenome As String
    Private _art_dataemissao As Date, _art_datavencimento As Date, _art_valor As Double, _art_datapagamento As String
    Private _art_valorrestante As Double, _art_desconto As Double, _art_acrescimo As Double, _art_observacao As String
    Private _art_funcionarioid As Integer, _art_funcionarionome As String, _art_valorpago As Double
    Private _art_tela As String, _art_alteradodt As String, _art_alteradofunc As String
    Private _art_estornado As Boolean, _art_estornadovalor As Double
    Private _art_situacao As String, _art_tipopagamento As String
    Private _art_idcaixa As Integer, _art_pagodinheiro As Double, _art_pagocartaocred As Double
    Private _art_pagocartaodeb As Double, _art_pagopix As Double, _art_pagotransferencia As Double
    Private _art_idvendaservico As Int64, _art_idvendaproduto As Int64

    Sub New(Optional ByVal id As Int64 = 0, Optional ByVal empresaid As Integer = 0, Optional ByVal empresanome As String = "", _
            Optional ByVal clienteid As Integer = 0, Optional ByVal clientenome As String = "", Optional ByVal dataemissao As Date = Nothing, _
            Optional ByVal datavencimento As Date = Nothing, Optional ByVal valor As Double = 0, Optional ByVal datapagamento As String = "", _
            Optional ByVal valorrestante As Double = 0, Optional ByVal desconto As Double = 0, Optional ByVal acrescimo As Double = 0, _
            Optional ByVal observacao As String = "", Optional ByVal funcionarioid As Integer = 0, Optional ByVal funcionarionome As String = "", _
            Optional ByVal valorpago As Double = 0, Optional ByVal tela As String = "ARECEBER", Optional ByVal alteradodt As String = "", _
            Optional ByVal alteradofunc As String = "", Optional ByVal estornado As Boolean = False, Optional ByVal estornadovalor As Double = 0, _
            Optional ByVal situacao As String = "N", Optional ByVal tipopagamento As String = "", Optional ByVal idcaixa As Integer = 0, _
            Optional ByVal pagodinheiro As Double = 0, Optional ByVal pagocartaocred As Double = 0, Optional ByVal pagocartaodeb As Double = 0, _
            Optional ByVal pagopix As Double = 0, Optional ByVal pagotransferencia As Double = 0, Optional ByVal idvendaservico As Int64 = 0, _
            Optional ByVal idvendaproduto As Int64 = 0)

        Me._art_id = id : Me._art_empresaid = empresaid : Me._art_empresanome = empresanome : Me.art_clienteid = clienteid
        Me._art_clientenome = clientenome : Me._art_dataemissao = dataemissao : Me._art_datavencimento = datavencimento
        Me._art_valor = valor : Me._art_datapagamento = datapagamento : Me._art_valorrestante = valorrestante
        Me._art_desconto = desconto : Me._art_acrescimo = acrescimo : Me._art_observacao = observacao
        Me._art_funcionarioid = funcionarioid : Me._art_funcionarionome = funcionarionome
        Me._art_tela = tela : Me._art_alteradodt = alteradodt : Me._art_alteradofunc = _art_alteradofunc
        Me._art_estornado = estornado : Me._art_estornadovalor = estornadovalor
        Me._art_situacao = situacao : Me._art_tipopagamento = tipopagamento
        Me._art_valorpago = valorpago
        Me._art_idcaixa = idcaixa : Me._art_pagodinheiro = pagodinheiro : Me._art_pagocartaocred = pagocartaocred
        Me._art_pagocartaodeb = pagocartaodeb : Me._art_pagopix = pagopix : Me._art_pagotransferencia = pagotransferencia
        Me._art_idvendaservico = idvendaservico : Me._art_idvendaproduto = idvendaproduto

    End Sub

    Sub New(AReceberTotal As ClAReceberTotal)

        With Me

            ._art_id = AReceberTotal.art_id
            ._art_empresaid = AReceberTotal._art_empresaid
            ._art_empresanome = AReceberTotal._art_empresanome
            .art_clienteid = AReceberTotal.art_clienteid
            ._art_clientenome = AReceberTotal._art_clientenome
            ._art_dataemissao = AReceberTotal._art_dataemissao
            ._art_datavencimento = AReceberTotal._art_datavencimento
            ._art_valor = AReceberTotal._art_valor
            ._art_valorpago = AReceberTotal.art_valorpago
            ._art_datapagamento = AReceberTotal._art_datapagamento
            ._art_valorrestante = AReceberTotal._art_valorrestante
            ._art_desconto = AReceberTotal._art_desconto
            ._art_acrescimo = AReceberTotal._art_acrescimo
            ._art_observacao = AReceberTotal._art_observacao
            ._art_funcionarioid = AReceberTotal._art_funcionarioid
            ._art_funcionarionome = AReceberTotal._art_funcionarionome
            ._art_tela = AReceberTotal._art_tela
            If AReceberTotal._art_tela.Equals("") Then .art_tela = "ARECEBER"
            ._art_alteradodt = AReceberTotal._art_alteradodt
            ._art_alteradofunc = AReceberTotal._art_alteradofunc
            ._art_estornado = AReceberTotal._art_estornado
            ._art_estornadovalor = AReceberTotal._art_estornadovalor
            ._art_situacao = AReceberTotal._art_situacao
            ._art_tipopagamento = AReceberTotal._art_tipopagamento
            ._art_idcaixa = AReceberTotal._art_idcaixa
            ._art_pagodinheiro = AReceberTotal._art_pagodinheiro
            ._art_pagocartaocred = AReceberTotal._art_pagocartaocred
            ._art_pagocartaodeb = AReceberTotal._art_pagocartaodeb
            ._art_pagopix = AReceberTotal._art_pagopix
            ._art_pagotransferencia = AReceberTotal._art_pagotransferencia
            ._art_idvendaservico = AReceberTotal._art_idvendaservico
            ._art_idvendaproduto = AReceberTotal._art_idvendaproduto

        End With

    End Sub

    Sub SetaValores(AReceberTotal As ClAReceberTotal)

        With Me

            ._art_id = AReceberTotal.art_id
            ._art_empresaid = AReceberTotal._art_empresaid
            ._art_empresanome = AReceberTotal._art_empresanome
            .art_clienteid = AReceberTotal.art_clienteid
            ._art_clientenome = AReceberTotal._art_clientenome
            ._art_dataemissao = AReceberTotal._art_dataemissao
            ._art_datavencimento = AReceberTotal._art_datavencimento
            ._art_valor = AReceberTotal._art_valor
            ._art_valorpago = AReceberTotal.art_valorpago
            ._art_datapagamento = AReceberTotal._art_datapagamento
            ._art_valorrestante = AReceberTotal._art_valorrestante
            ._art_desconto = AReceberTotal._art_desconto
            ._art_acrescimo = AReceberTotal._art_acrescimo
            ._art_observacao = AReceberTotal._art_observacao
            ._art_funcionarioid = AReceberTotal._art_funcionarioid
            ._art_funcionarionome = AReceberTotal._art_funcionarionome
            ._art_tela = AReceberTotal._art_tela
            ._art_alteradodt = AReceberTotal._art_alteradodt
            ._art_alteradofunc = AReceberTotal._art_alteradofunc
            ._art_estornado = AReceberTotal._art_estornado
            ._art_estornadovalor = AReceberTotal._art_estornadovalor
            ._art_situacao = AReceberTotal._art_situacao
            ._art_tipopagamento = AReceberTotal._art_tipopagamento
            ._art_idcaixa = AReceberTotal._art_idcaixa
            ._art_pagodinheiro = AReceberTotal._art_pagodinheiro
            ._art_pagocartaocred = AReceberTotal._art_pagocartaocred
            ._art_pagocartaodeb = AReceberTotal._art_pagocartaodeb
            ._art_pagopix = AReceberTotal._art_pagopix
            ._art_pagotransferencia = AReceberTotal._art_pagotransferencia
            ._art_idvendaservico = AReceberTotal._art_idvendaservico
            ._art_idvendaproduto = AReceberTotal._art_idvendaproduto

        End With

    End Sub

    Sub ZeraValores()
        Me._art_id = 0 : Me._art_empresaid = 0 : Me._art_empresanome = "" : Me.art_clienteid = 0
        Me._art_clientenome = "" : Me._art_dataemissao = Nothing : Me._art_datavencimento = Nothing
        Me._art_valor = 0 : Me._art_datapagamento = "" : Me._art_valorrestante = 0
        Me._art_desconto = 0 : Me._art_acrescimo = 0 : Me._art_observacao = ""
        Me._art_funcionarioid = 0 : Me._art_funcionarionome = "" : Me._art_tela = "ARECEBER"
        Me._art_alteradodt = "" : Me._art_alteradofunc = ""
        Me._art_estornado = False : Me._art_estornadovalor = 0
        Me._art_situacao = "N" : Me._art_tipopagamento = ""
        Me._art_idcaixa = 0 : Me._art_pagodinheiro = 0 : Me._art_pagocartaocred = 0
        Me._art_pagocartaodeb = 0 : Me._art_pagopix = 0 : Me._art_pagotransferencia = 0
        Me._art_valorpago = 0
        Me._art_idvendaservico = 0
        Me._art_idvendaproduto = 0
    End Sub

#Region "  Get e Set"

    Public Property art_id As Int64
        Get
            Return Me._art_id
        End Get
        Set(value As Int64)
            Me._art_id = value
        End Set
    End Property

    Public Property art_idvendaservico As Int64
        Get
            Return Me._art_idvendaservico
        End Get
        Set(value As Int64)
            Me._art_idvendaservico = value
        End Set
    End Property

    Public Property art_idvendaproduto As Int64
        Get
            Return Me._art_idvendaproduto
        End Get
        Set(value As Int64)
            Me._art_idvendaproduto = value
        End Set
    End Property

    Public Property art_idcaixa As Integer
        Get
            Return Me._art_idcaixa
        End Get
        Set(value As Integer)
            Me._art_idcaixa = value
        End Set
    End Property

    Public Property art_pagodinheiro As Double
        Get
            Return Me._art_pagodinheiro
        End Get
        Set(value As Double)
            Me._art_pagodinheiro = value
        End Set
    End Property

    Public Property art_pagocartaocred As Double
        Get
            Return Me._art_pagocartaocred
        End Get
        Set(value As Double)
            Me._art_pagocartaocred = value
        End Set
    End Property

    Public Property art_pagocartaodeb As Double
        Get
            Return Me._art_pagocartaodeb
        End Get
        Set(value As Double)
            Me._art_pagocartaodeb = value
        End Set
    End Property

    Public Property art_pagopix As Double
        Get
            Return Me._art_pagopix
        End Get
        Set(value As Double)
            Me._art_pagopix = value
        End Set
    End Property

    Public Property art_pagotransferencia As Double
        Get
            Return Me._art_pagotransferencia
        End Get
        Set(value As Double)
            Me._art_pagotransferencia = value
        End Set
    End Property

    Public Property art_estornado As Boolean
        Get
            Return Me._art_estornado
        End Get
        Set(value As Boolean)
            Me._art_estornado = value
        End Set
    End Property

    Public Property art_estornadovalor As Double
        Get
            Return Me._art_estornadovalor
        End Get
        Set(value As Double)
            Me._art_estornadovalor = value
        End Set
    End Property

    Public Property art_tipopagamento As String
        Get
            Return Me._art_tipopagamento
        End Get
        Set(value As String)
            Me._art_tipopagamento = value
        End Set
    End Property

    Public Property art_alteradofunc As String
        Get
            Return Me._art_alteradofunc
        End Get
        Set(value As String)
            Me._art_alteradofunc = value
        End Set
    End Property

    Public Property art_situacao As String
        Get
            Return Me._art_situacao.ToUpper
        End Get
        Set(value As String)
            Me._art_situacao = value.ToUpper
        End Set
    End Property

    Public Property art_alteradodt As String
        Get
            Return Me._art_alteradodt
        End Get
        Set(value As String)
            Me._art_alteradodt = value
        End Set
    End Property

    Public Property art_tela As String
        Get
            Return Me._art_tela.ToUpper
        End Get
        Set(value As String)
            Me._art_tela = value.ToUpper
        End Set
    End Property

    Public Property art_empresaid As Integer
        Get
            Return Me._art_empresaid
        End Get
        Set(value As Integer)
            Me._art_empresaid = value
        End Set
    End Property

    Public Property art_empresanome As String
        Get
            Return Me._art_empresanome
        End Get
        Set(value As String)
            Me._art_empresanome = value
        End Set
    End Property

    Public Property art_clienteid As Integer
        Get
            Return Me._art_clienteid
        End Get
        Set(value As Integer)
            Me._art_clienteid = value
        End Set
    End Property

    Public Property art_clientenome As String
        Get
            Return Me._art_clientenome
        End Get
        Set(value As String)
            Me._art_clientenome = value
        End Set
    End Property

    Public Property art_dataemissao As Date
        Get
            Return Me._art_dataemissao
        End Get
        Set(value As Date)
            Me._art_dataemissao = value
        End Set
    End Property

    Public Property art_datavencimento As Date
        Get
            Return Me._art_datavencimento
        End Get
        Set(value As Date)
            Me._art_datavencimento = value
        End Set
    End Property

    Public Property art_valor As Double
        Get
            Return Me._art_valor
        End Get
        Set(value As Double)
            Me._art_valor = value
        End Set
    End Property

    Public Property art_datapagamento As String
        Get
            Return Me._art_datapagamento
        End Get
        Set(value As String)
            Me._art_datapagamento = value
        End Set
    End Property

    Public Property art_valorrestante As Double
        Get
            Return Me._art_valorrestante
        End Get
        Set(value As Double)
            Me._art_valorrestante = value
        End Set
    End Property

    Public Property art_desconto As Double
        Get
            Return Me._art_desconto
        End Get
        Set(value As Double)
            Me._art_desconto = value
        End Set
    End Property

    Public Property art_acrescimo As Double
        Get
            Return Me._art_acrescimo
        End Get
        Set(value As Double)
            Me._art_acrescimo = value
        End Set
    End Property

    Public Property art_observacao As String
        Get
            Return Me._art_observacao
        End Get
        Set(value As String)
            Me._art_observacao = value
        End Set
    End Property

    Public Property art_funcionarioid As Integer
        Get
            Return Me._art_funcionarioid
        End Get
        Set(value As Integer)
            Me._art_funcionarioid = value
        End Set
    End Property

    Public Property art_funcionarionome As String
        Get
            Return Me._art_funcionarionome
        End Get
        Set(value As String)
            Me._art_funcionarionome = value
        End Set
    End Property

    Public Property art_valorpago As Double
        Get
            Return Me._art_valorpago
        End Get
        Set(value As Double)
            Me._art_valorpago = value
        End Set
    End Property

#End Region

End Class
