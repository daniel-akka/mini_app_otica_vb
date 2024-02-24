Public Class ClAbrirFecharCaixa

    Private _af_id As Long
    Private _af_datahora As Date
    Private _af_tipo As String 'A=Abertura...  F=Fechamento
    Private _af_concluido As Boolean
    Private _af_total_dinheiro As Double
    Private _af_total_cartaocredito As Double
    Private _af_id_abertura As Long
    Private _af_total_apurado_dn As Double
    Private _af_total_apurado_ctc As Double
    Private _af_total_cartaodebito As Double
    Private _af_total_pix As Double, _af_total_crediario As Double, _af_total_apurado_crd As Double
    Private _af_total_transferencia As Double
    Private _af_total_apurado_ctd As Double
    Private _af_total_apurado_pix As Double
    Private _af_total_apurado_tra As Double


    Public Sub New(af_id As Long, af_datahora As Date, af_tipo As String, af_concluido As Boolean, af_total_dinheiro As Double, af_total_cartaocredito As Double, _
                   vaf_id_abertura As Long, vaf_total_apurado_dn As Double, vaf_total_apurado_ctc As Double, vaf_total_cartaodebito As Double, _
                   vaf_total_pix As Double, vaf_total_transferencia As Double, vaf_total_apurado_ctd As Double, _
                   vaf_total_apurado_pix As Double, vaf_total_apurado_tra As Double, vaf_total_crediario As Double, vaf_total_apurado_crd As Double)
        Me._af_id = af_id
        Me._af_datahora = af_datahora
        Me._af_tipo = af_tipo
        Me._af_concluido = af_concluido
        Me._af_total_dinheiro = af_total_dinheiro
        Me._af_total_cartaocredito = af_total_cartaocredito
        Me._af_id_abertura = vaf_id_abertura
        Me._af_total_apurado_dn = vaf_total_apurado_dn
        Me._af_total_apurado_ctc = vaf_total_apurado_ctc
        Me._af_total_cartaodebito = vaf_total_cartaodebito
        Me._af_total_pix = vaf_total_pix
        Me._af_total_transferencia = vaf_total_transferencia
        Me._af_total_apurado_ctd = vaf_total_apurado_ctd
        Me._af_total_apurado_pix = vaf_total_apurado_pix
        Me._af_total_apurado_tra = vaf_total_apurado_tra
        Me._af_total_crediario = vaf_total_crediario
        Me._af_total_apurado_crd = vaf_total_apurado_crd

    End Sub

    Public Sub New()

        With Me

            ._af_id = 0
            ._af_datahora = Nothing
            ._af_tipo = ""
            ._af_concluido = False
            ._af_total_dinheiro = 0
            ._af_total_cartaocredito = 0
            ._af_id_abertura = 0
            ._af_total_apurado_dn = 0
            ._af_total_apurado_ctc = 0
            ._af_total_cartaodebito = 0
            ._af_total_pix = 0
            ._af_total_transferencia = 0
            ._af_total_apurado_ctd = 0
            ._af_total_apurado_pix = 0
            ._af_total_apurado_tra = 0
            ._af_total_crediario = 0
            ._af_total_apurado_crd = 0

        End With

    End Sub

    Sub zeraValores()

        With Me

            ._af_id = 0
            ._af_datahora = Nothing
            ._af_tipo = ""
            ._af_concluido = False
            ._af_total_dinheiro = 0
            ._af_total_cartaocredito = 0
            ._af_id_abertura = 0
            ._af_total_apurado_dn = 0
            ._af_total_apurado_ctc = 0
            ._af_total_cartaodebito = 0
            ._af_total_pix = 0
            ._af_total_transferencia = 0
            ._af_total_apurado_ctd = 0
            ._af_total_apurado_pix = 0
            ._af_total_apurado_tra = 0
            ._af_total_crediario = 0
            ._af_total_apurado_crd = 0

        End With
    End Sub

    Sub New(ByVal AbrirFecharCaixa As ClAbrirFecharCaixa)

        With Me

            ._af_id = AbrirFecharCaixa._af_id
            ._af_datahora = AbrirFecharCaixa._af_datahora
            ._af_tipo = AbrirFecharCaixa._af_tipo
            ._af_concluido = AbrirFecharCaixa._af_concluido
            ._af_total_dinheiro = AbrirFecharCaixa._af_total_dinheiro
            ._af_total_cartaocredito = AbrirFecharCaixa._af_total_cartaocredito
            ._af_id_abertura = AbrirFecharCaixa._af_id_abertura
            ._af_total_apurado_dn = AbrirFecharCaixa._af_total_apurado_dn
            ._af_total_apurado_ctc = AbrirFecharCaixa._af_total_apurado_ctc
            ._af_total_cartaodebito = AbrirFecharCaixa._af_total_cartaodebito
            ._af_total_pix = AbrirFecharCaixa._af_total_pix
            ._af_total_transferencia = AbrirFecharCaixa._af_total_transferencia
            ._af_total_apurado_ctd = AbrirFecharCaixa._af_total_apurado_ctd
            ._af_total_apurado_pix = AbrirFecharCaixa._af_total_apurado_pix
            ._af_total_apurado_tra = AbrirFecharCaixa._af_total_apurado_tra
            ._af_total_crediario = AbrirFecharCaixa._af_total_crediario
            ._af_total_apurado_crd = AbrirFecharCaixa._af_total_apurado_crd

        End With
    End Sub

    Sub SetaValores(ByVal AbrirFecharCaixa As ClAbrirFecharCaixa)

        With Me

            ._af_id = AbrirFecharCaixa._af_id
            ._af_datahora = AbrirFecharCaixa._af_datahora
            ._af_tipo = AbrirFecharCaixa._af_tipo
            ._af_concluido = AbrirFecharCaixa._af_concluido
            ._af_total_dinheiro = AbrirFecharCaixa._af_total_dinheiro
            ._af_total_cartaocredito = AbrirFecharCaixa._af_total_cartaocredito
            ._af_id_abertura = AbrirFecharCaixa._af_id_abertura
            ._af_total_apurado_dn = AbrirFecharCaixa._af_total_apurado_dn
            ._af_total_apurado_ctc = AbrirFecharCaixa._af_total_apurado_ctc
            ._af_total_cartaodebito = AbrirFecharCaixa._af_total_cartaodebito
            ._af_total_pix = AbrirFecharCaixa._af_total_pix
            ._af_total_transferencia = AbrirFecharCaixa._af_total_transferencia
            ._af_total_apurado_ctd = AbrirFecharCaixa._af_total_apurado_ctd
            ._af_total_apurado_pix = AbrirFecharCaixa._af_total_apurado_pix
            ._af_total_apurado_tra = AbrirFecharCaixa._af_total_apurado_tra
            ._af_total_crediario = AbrirFecharCaixa._af_total_crediario
            ._af_total_apurado_crd = AbrirFecharCaixa._af_total_apurado_crd

        End With
    End Sub

    Public Property Af_id1 As Long
        Get
            Return _af_id
        End Get
        Set(value As Long)
            _af_id = value
        End Set
    End Property

    Public Property Af_datahora1 As Date
        Get
            Return _af_datahora
        End Get
        Set(value As Date)
            _af_datahora = value
        End Set
    End Property

    Public Property Af_tipo1 As String
        Get
            Return _af_tipo
        End Get
        Set(value As String)
            _af_tipo = value
        End Set
    End Property

    Public Property Af_concluido1 As Boolean
        Get
            Return _af_concluido
        End Get
        Set(value As Boolean)
            _af_concluido = value
        End Set
    End Property

    Public Property Af_total_dinheiro1 As Double
        Get
            Return _af_total_dinheiro
        End Get
        Set(value As Double)
            _af_total_dinheiro = value
        End Set
    End Property

    Public Property Af_total_cartaocredito As Double
        Get
            Return _af_total_cartaocredito
        End Get
        Set(value As Double)
            _af_total_cartaocredito = value
        End Set
    End Property

    Public Property Af_id_abertura1 As Long
        Get
            Return _af_id_abertura
        End Get
        Set(value As Long)
            _af_id_abertura = value
        End Set
    End Property

    Public Property Af_total_apurado_dn1 As Double
        Get
            Return _af_total_apurado_dn
        End Get
        Set(value As Double)
            _af_total_apurado_dn = value
        End Set
    End Property

    Public Property Af_total_apurado_ctc As Double
        Get
            Return _af_total_apurado_ctc
        End Get
        Set(value As Double)
            _af_total_apurado_ctc = value
        End Set
    End Property

    Public Property af_total_pix As Double
        Get
            Return Me._af_total_pix
        End Get
        Set(value As Double)
            Me._af_total_pix = value
        End Set
    End Property

    Public Property af_total_transferencia As Double
        Get
            Return Me._af_total_transferencia
        End Get
        Set(value As Double)
            Me._af_total_transferencia = value
        End Set
    End Property

    Public Property af_total_apurado_ctd As Double
        Get
            Return Me._af_total_apurado_ctd
        End Get
        Set(value As Double)
            Me._af_total_apurado_ctd = value
        End Set
    End Property

    Public Property af_total_apurado_pix As Double
        Get
            Return Me._af_total_apurado_pix
        End Get
        Set(value As Double)
            Me._af_total_apurado_pix = value
        End Set
    End Property

    Public Property af_total_apurado_tra As Double
        Get
            Return Me._af_total_apurado_tra
        End Get
        Set(value As Double)
            Me._af_total_apurado_tra = value
        End Set
    End Property

    Public Property af_total_cartaodebito As Double
        Get
            Return Me._af_total_cartaodebito
        End Get
        Set(value As Double)
            Me._af_total_cartaodebito = value
        End Set
    End Property

    Public Property af_total_crediario As Double
        Get
            Return Me._af_total_crediario
        End Get
        Set(value As Double)
            Me._af_total_crediario = value
        End Set
    End Property

    Public Property af_total_apurado_crd As Double
        Get
            Return Me._af_total_apurado_crd
        End Get
        Set(value As Double)
            Me._af_total_apurado_crd = value
        End Set
    End Property

End Class
