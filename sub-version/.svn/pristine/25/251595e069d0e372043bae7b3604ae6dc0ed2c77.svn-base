Public Class ClCaixa

    Private cx_id As Long
    Private cx_tipo As String 'E= Entrada; S= Saida; T= Troco
    Private cx_datahora As Date
    Private cx_motivo As String
    Private cx_af_id As Long
    Private cx_valor As Double
    Private cx_tipo_valor As String 'DN= Dinheiro; CT= Cartao

    Public Sub New(cx_id As Long, cx_tipo As String, cx_datahora As Date, cx_motivo As String, cx_af_id As Long, cx_valor As Double, cx_tipo_valor As String)
        Me.cx_id = cx_id
        Me.cx_tipo = cx_tipo
        Me.cx_datahora = cx_datahora
        Me.cx_motivo = cx_motivo
        Me.cx_af_id = cx_af_id
        Me.cx_valor = cx_valor
        Me.cx_tipo_valor = cx_tipo_valor
    End Sub

    Sub New()

        With Me
            .cx_id = 0
            .cx_tipo = 0
            .cx_datahora = Nothing
            .cx_motivo = ""
            .cx_af_id = 0
            .cx_valor = 0
            .cx_tipo_valor = ""
        End With
    End Sub

    Sub New(cx As ClCaixa)

        With Me
            .cx_id = cx.Cx_id1
            .cx_tipo = cx.Cx_tipo1
            .cx_datahora = cx.Cx_datahora1
            .cx_motivo = cx.Cx_motivo1
            .cx_af_id = cx.Cx_af_id1
            .cx_valor = cx.Cx_valor1
            .cx_tipo_valor = cx.Cx_tipo_valor1
        End With
    End Sub

    Sub zeraValores()

        With Me
            .cx_id = 0
            .cx_tipo = 0
            .cx_datahora = Nothing
            .cx_motivo = ""
            .cx_af_id = 0
            .cx_valor = 0
            .cx_tipo_valor = ""
        End With
    End Sub

    Public Property Cx_id1 As Long
        Get
            Return cx_id
        End Get
        Set(value As Long)
            cx_id = value
        End Set
    End Property

    Public Property Cx_tipo1 As String
        Get
            Return cx_tipo
        End Get
        Set(value As String)
            cx_tipo = value
        End Set
    End Property

    Public Property Cx_datahora1 As Date
        Get
            Return cx_datahora
        End Get
        Set(value As Date)
            cx_datahora = value
        End Set
    End Property

    Public Property Cx_motivo1 As String
        Get
            Return cx_motivo
        End Get
        Set(value As String)
            cx_motivo = value
        End Set
    End Property

    Public Property Cx_af_id1 As Long
        Get
            Return cx_af_id
        End Get
        Set(value As Long)
            cx_af_id = value
        End Set
    End Property

    Public Property Cx_valor1 As Double
        Get
            Return cx_valor
        End Get
        Set(value As Double)
            cx_valor = value
        End Set
    End Property

    Public Property Cx_tipo_valor1 As String
        Get
            Return cx_tipo_valor
        End Get
        Set(value As String)
            cx_tipo_valor = value
        End Set
    End Property
End Class
