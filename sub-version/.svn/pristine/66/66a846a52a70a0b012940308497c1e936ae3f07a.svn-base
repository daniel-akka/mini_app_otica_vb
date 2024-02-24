Public Class ClAPagarTotal

    Private _apt_id As Int64, _apt_empresaid As Integer, _apt_empresanome As String
    Private _apt_portadorid As Integer, _apt_portadornome As String, _apt_portadortipo As String 'F=Fornecedor; C=Cliente
    Private _apt_dataemissao As Date, _apt_datavencimento As Date, _apt_valor As Double, _apt_datapagamento As String
    Private _apt_valorrestante As Double, _apt_desconto As Double, _apt_acrescimo As Double, _apt_observacao As String
    Private _apt_funcionarioid As Integer, _apt_funcionarionome As String, _apt_valorpago As Double
    Private _apt_tela As String, _apt_alteradodt As String, _apt_alteradofunc As String
    Private _apt_estornado As Boolean, _apt_estornadovalor As Double
    Private _apt_situacao As String, _apt_tipopagamento As String
    Private _apt_idcaixa As Integer, _apt_pagodinheiro As Double, _apt_pagocartaocred As Double
    Private _apt_pagocartaodeb As Double, _apt_pagopix As Double, _apt_pagotransferencia As Double
    Private _apt_idvendaservico As Int64, _apt_idvendaproduto As Int64
    Public Property apt_tipodocumentoid As Integer
    Public Property apt_tipodocumentodescr As String

    Sub New(Optional ByVal id As Int64 = 0, Optional ByVal empresaid As Integer = 0, Optional ByVal empresanome As String = "", _
            Optional ByVal portadorid As Integer = 0, Optional ByVal portadortipo As String = "F", Optional ByVal portadornome As String = "", Optional ByVal dataemissao As Date = Nothing, _
            Optional ByVal datavencimento As Date = Nothing, Optional ByVal valor As Double = 0, Optional ByVal datapagamento As String = "", _
            Optional ByVal valorrestante As Double = 0, Optional ByVal desconto As Double = 0, Optional ByVal acrescimo As Double = 0, _
            Optional ByVal observacao As String = "", Optional ByVal funcionarioid As Integer = 0, Optional ByVal funcionarionome As String = "", _
            Optional ByVal valorpago As Double = 0, Optional ByVal tela As String = "APAGAR", Optional ByVal alteradodt As String = "", _
            Optional ByVal alteradofunc As String = "", Optional ByVal estornado As Boolean = False, Optional ByVal estornadovalor As Double = 0, _
            Optional ByVal situacao As String = "N", Optional ByVal tipopagamento As String = "", Optional ByVal idcaixa As Integer = 0, _
            Optional ByVal pagodinheiro As Double = 0, Optional ByVal pagocartaocred As Double = 0, Optional ByVal pagocartaodeb As Double = 0, _
            Optional ByVal pagopix As Double = 0, Optional ByVal pagotransferencia As Double = 0, Optional ByVal idvendaservico As Int64 = 0, _
            Optional ByVal idvendaproduto As Int64 = 0, Optional ByVal TipoDocumentoID As Integer = 0, _
            Optional ByVal TipoDocumentoDescr As String = "")

        Me._apt_id = id : Me._apt_empresaid = empresaid : Me._apt_empresanome = empresanome : Me.apt_portadorid = portadorid
        Me._apt_portadornome = portadornome : Me._apt_dataemissao = dataemissao : Me._apt_datavencimento = datavencimento
        Me._apt_valor = valor : Me._apt_datapagamento = datapagamento : Me._apt_valorrestante = valorrestante
        Me._apt_desconto = desconto : Me._apt_acrescimo = acrescimo : Me._apt_observacao = observacao
        Me._apt_funcionarioid = funcionarioid : Me._apt_funcionarionome = funcionarionome
        Me._apt_tela = tela : Me._apt_alteradodt = alteradodt : Me._apt_alteradofunc = _apt_alteradofunc
        Me._apt_estornado = estornado : Me._apt_estornadovalor = estornadovalor
        Me._apt_situacao = situacao : Me._apt_tipopagamento = tipopagamento
        Me._apt_valorpago = valorpago
        Me._apt_idcaixa = idcaixa : Me._apt_pagodinheiro = pagodinheiro : Me._apt_pagocartaocred = pagocartaocred
        Me._apt_pagocartaodeb = pagocartaodeb : Me._apt_pagopix = pagopix : Me._apt_pagotransferencia = pagotransferencia
        Me._apt_idvendaservico = idvendaservico : Me._apt_idvendaproduto = idvendaproduto
        Me._apt_portadortipo = portadortipo
        Me.apt_tipodocumentoid = TipoDocumentoID
        Me.apt_tipodocumentodescr = TipoDocumentoDescr

    End Sub

    Sub New(APagarTotal As ClAPagarTotal)

        With Me

            ._apt_id = APagarTotal.apt_id
            ._apt_empresaid = APagarTotal._apt_empresaid
            ._apt_empresanome = APagarTotal._apt_empresanome
            .apt_portadorid = APagarTotal.apt_portadorid
            ._apt_portadornome = APagarTotal._apt_portadornome
            ._apt_dataemissao = APagarTotal._apt_dataemissao
            ._apt_datavencimento = APagarTotal._apt_datavencimento
            ._apt_valor = APagarTotal._apt_valor
            ._apt_valorpago = APagarTotal.apt_valorpago
            ._apt_datapagamento = APagarTotal._apt_datapagamento
            ._apt_valorrestante = APagarTotal._apt_valorrestante
            ._apt_desconto = APagarTotal._apt_desconto
            ._apt_acrescimo = APagarTotal._apt_acrescimo
            ._apt_observacao = APagarTotal._apt_observacao
            ._apt_funcionarioid = APagarTotal._apt_funcionarioid
            ._apt_funcionarionome = APagarTotal._apt_funcionarionome
            ._apt_tela = APagarTotal._apt_tela
            If APagarTotal._apt_tela.Equals("") Then .apt_tela = "APAGAR"
            ._apt_alteradodt = APagarTotal._apt_alteradodt
            ._apt_alteradofunc = APagarTotal._apt_alteradofunc
            ._apt_estornado = APagarTotal._apt_estornado
            ._apt_estornadovalor = APagarTotal._apt_estornadovalor
            ._apt_situacao = APagarTotal._apt_situacao
            ._apt_tipopagamento = APagarTotal._apt_tipopagamento
            ._apt_idcaixa = APagarTotal._apt_idcaixa
            ._apt_pagodinheiro = APagarTotal._apt_pagodinheiro
            ._apt_pagocartaocred = APagarTotal._apt_pagocartaocred
            ._apt_pagocartaodeb = APagarTotal._apt_pagocartaodeb
            ._apt_pagopix = APagarTotal._apt_pagopix
            ._apt_pagotransferencia = APagarTotal._apt_pagotransferencia
            ._apt_idvendaservico = APagarTotal._apt_idvendaservico
            ._apt_idvendaproduto = APagarTotal._apt_idvendaproduto
            ._apt_portadortipo = APagarTotal._apt_portadortipo
            .apt_tipodocumentoid = APagarTotal.apt_tipodocumentoid
            .apt_tipodocumentodescr = APagarTotal.apt_tipodocumentodescr

        End With

    End Sub

    Sub SetaValores(APagarTotal As ClAPagarTotal)

        With Me

            ._apt_id = APagarTotal.apt_id
            ._apt_empresaid = APagarTotal._apt_empresaid
            ._apt_empresanome = APagarTotal._apt_empresanome
            .apt_portadorid = APagarTotal.apt_portadorid
            ._apt_portadornome = APagarTotal._apt_portadornome
            ._apt_dataemissao = APagarTotal._apt_dataemissao
            ._apt_datavencimento = APagarTotal._apt_datavencimento
            ._apt_valor = APagarTotal._apt_valor
            ._apt_valorpago = APagarTotal.apt_valorpago
            ._apt_datapagamento = APagarTotal._apt_datapagamento
            ._apt_valorrestante = APagarTotal._apt_valorrestante
            ._apt_desconto = APagarTotal._apt_desconto
            ._apt_acrescimo = APagarTotal._apt_acrescimo
            ._apt_observacao = APagarTotal._apt_observacao
            ._apt_funcionarioid = APagarTotal._apt_funcionarioid
            ._apt_funcionarionome = APagarTotal._apt_funcionarionome
            ._apt_tela = APagarTotal._apt_tela
            ._apt_alteradodt = APagarTotal._apt_alteradodt
            ._apt_alteradofunc = APagarTotal._apt_alteradofunc
            ._apt_estornado = APagarTotal._apt_estornado
            ._apt_estornadovalor = APagarTotal._apt_estornadovalor
            ._apt_situacao = APagarTotal._apt_situacao
            ._apt_tipopagamento = APagarTotal._apt_tipopagamento
            ._apt_idcaixa = APagarTotal._apt_idcaixa
            ._apt_pagodinheiro = APagarTotal._apt_pagodinheiro
            ._apt_pagocartaocred = APagarTotal._apt_pagocartaocred
            ._apt_pagocartaodeb = APagarTotal._apt_pagocartaodeb
            ._apt_pagopix = APagarTotal._apt_pagopix
            ._apt_pagotransferencia = APagarTotal._apt_pagotransferencia
            ._apt_idvendaservico = APagarTotal._apt_idvendaservico
            ._apt_idvendaproduto = APagarTotal._apt_idvendaproduto
            ._apt_portadortipo = APagarTotal._apt_portadortipo
            .apt_tipodocumentoid = APagarTotal.apt_tipodocumentoid
            .apt_tipodocumentodescr = APagarTotal.apt_tipodocumentodescr

        End With

    End Sub

    Sub ZeraValores()
        Me._apt_id = 0 : Me._apt_empresaid = 0 : Me._apt_empresanome = "" : Me.apt_portadorid = 0
        Me._apt_portadornome = "" : Me._apt_dataemissao = Nothing : Me._apt_datavencimento = Nothing
        Me._apt_valor = 0 : Me._apt_datapagamento = "" : Me._apt_valorrestante = 0
        Me._apt_desconto = 0 : Me._apt_acrescimo = 0 : Me._apt_observacao = ""
        Me._apt_funcionarioid = 0 : Me._apt_funcionarionome = "" : Me._apt_tela = "APAGAR"
        Me._apt_alteradodt = "" : Me._apt_alteradofunc = ""
        Me._apt_estornado = False : Me._apt_estornadovalor = 0
        Me._apt_situacao = "N" : Me._apt_tipopagamento = ""
        Me._apt_idcaixa = 0 : Me._apt_pagodinheiro = 0 : Me._apt_pagocartaocred = 0
        Me._apt_pagocartaodeb = 0 : Me._apt_pagopix = 0 : Me._apt_pagotransferencia = 0
        Me._apt_valorpago = 0
        Me._apt_idvendaservico = 0
        Me._apt_idvendaproduto = 0
        Me._apt_portadortipo = "F"
        Me.apt_tipodocumentoid = 0
        Me.apt_tipodocumentodescr = ""
    End Sub

#Region "  Get e Set"

    Public Property apt_id As Int64
        Get
            Return Me._apt_id
        End Get
        Set(value As Int64)
            Me._apt_id = value
        End Set
    End Property

    Public Property apt_idvendaservico As Int64
        Get
            Return Me._apt_idvendaservico
        End Get
        Set(value As Int64)
            Me._apt_idvendaservico = value
        End Set
    End Property

    Public Property apt_idvendaproduto As Int64
        Get
            Return Me._apt_idvendaproduto
        End Get
        Set(value As Int64)
            Me._apt_idvendaproduto = value
        End Set
    End Property

    Public Property apt_idcaixa As Integer
        Get
            Return Me._apt_idcaixa
        End Get
        Set(value As Integer)
            Me._apt_idcaixa = value
        End Set
    End Property

    Public Property apt_pagodinheiro As Double
        Get
            Return Me._apt_pagodinheiro
        End Get
        Set(value As Double)
            Me._apt_pagodinheiro = value
        End Set
    End Property

    Public Property apt_pagocartaocred As Double
        Get
            Return Me._apt_pagocartaocred
        End Get
        Set(value As Double)
            Me._apt_pagocartaocred = value
        End Set
    End Property

    Public Property apt_pagocartaodeb As Double
        Get
            Return Me._apt_pagocartaodeb
        End Get
        Set(value As Double)
            Me._apt_pagocartaodeb = value
        End Set
    End Property

    Public Property apt_pagopix As Double
        Get
            Return Me._apt_pagopix
        End Get
        Set(value As Double)
            Me._apt_pagopix = value
        End Set
    End Property

    Public Property apt_pagotransferencia As Double
        Get
            Return Me._apt_pagotransferencia
        End Get
        Set(value As Double)
            Me._apt_pagotransferencia = value
        End Set
    End Property

    Public Property apt_estornado As Boolean
        Get
            Return Me._apt_estornado
        End Get
        Set(value As Boolean)
            Me._apt_estornado = value
        End Set
    End Property

    Public Property apt_estornadovalor As Double
        Get
            Return Me._apt_estornadovalor
        End Get
        Set(value As Double)
            Me._apt_estornadovalor = value
        End Set
    End Property

    Public Property apt_tipopagamento As String
        Get
            Return Me._apt_tipopagamento
        End Get
        Set(value As String)
            Me._apt_tipopagamento = value
        End Set
    End Property

    Public Property apt_alteradofunc As String
        Get
            Return Me._apt_alteradofunc
        End Get
        Set(value As String)
            Me._apt_alteradofunc = value
        End Set
    End Property

    Public Property apt_situacao As String
        Get
            Return Me._apt_situacao.ToUpper
        End Get
        Set(value As String)
            Me._apt_situacao = value.ToUpper
        End Set
    End Property

    Public Property apt_alteradodt As String
        Get
            Return Me._apt_alteradodt
        End Get
        Set(value As String)
            Me._apt_alteradodt = value
        End Set
    End Property

    Public Property apt_tela As String
        Get
            Return Me._apt_tela.ToUpper
        End Get
        Set(value As String)
            Me._apt_tela = value.ToUpper
        End Set
    End Property

    Public Property apt_empresaid As Integer
        Get
            Return Me._apt_empresaid
        End Get
        Set(value As Integer)
            Me._apt_empresaid = value
        End Set
    End Property

    Public Property apt_empresanome As String
        Get
            Return Me._apt_empresanome
        End Get
        Set(value As String)
            Me._apt_empresanome = value
        End Set
    End Property

    Public Property apt_portadorid As Integer
        Get
            Return Me._apt_portadorid
        End Get
        Set(value As Integer)
            Me._apt_portadorid = value
        End Set
    End Property

    Public Property apt_portadortipo As String
        Get
            Return Me._apt_portadortipo
        End Get
        Set(value As String)
            Me._apt_portadortipo = value
        End Set
    End Property

    Public Property apt_portadornome As String
        Get
            Return Me._apt_portadornome
        End Get
        Set(value As String)
            Me._apt_portadornome = value
        End Set
    End Property

    Public Property apt_dataemissao As Date
        Get
            Return Me._apt_dataemissao
        End Get
        Set(value As Date)
            Me._apt_dataemissao = value
        End Set
    End Property

    Public Property apt_datavencimento As Date
        Get
            Return Me._apt_datavencimento
        End Get
        Set(value As Date)
            Me._apt_datavencimento = value
        End Set
    End Property

    Public Property apt_valor As Double
        Get
            Return Me._apt_valor
        End Get
        Set(value As Double)
            Me._apt_valor = value
        End Set
    End Property

    Public Property apt_datapagamento As String
        Get
            Return Me._apt_datapagamento
        End Get
        Set(value As String)
            Me._apt_datapagamento = value
        End Set
    End Property

    Public Property apt_valorrestante As Double
        Get
            Return Me._apt_valorrestante
        End Get
        Set(value As Double)
            Me._apt_valorrestante = value
        End Set
    End Property

    Public Property apt_desconto As Double
        Get
            Return Me._apt_desconto
        End Get
        Set(value As Double)
            Me._apt_desconto = value
        End Set
    End Property

    Public Property apt_acrescimo As Double
        Get
            Return Me._apt_acrescimo
        End Get
        Set(value As Double)
            Me._apt_acrescimo = value
        End Set
    End Property

    Public Property apt_observacao As String
        Get
            Return Me._apt_observacao
        End Get
        Set(value As String)
            Me._apt_observacao = value
        End Set
    End Property

    Public Property apt_funcionarioid As Integer
        Get
            Return Me._apt_funcionarioid
        End Get
        Set(value As Integer)
            Me._apt_funcionarioid = value
        End Set
    End Property

    Public Property apt_funcionarionome As String
        Get
            Return Me._apt_funcionarionome
        End Get
        Set(value As String)
            Me._apt_funcionarionome = value
        End Set
    End Property

    Public Property apt_valorpago As Double
        Get
            Return Me._apt_valorpago
        End Get
        Set(value As Double)
            Me._apt_valorpago = value
        End Set
    End Property

#End Region

End Class
