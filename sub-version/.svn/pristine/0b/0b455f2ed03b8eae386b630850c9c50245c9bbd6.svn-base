Public Class ClLocacoesCanceladas

    Private lc_id As Int64
    Private lc_atendente_id As Integer
    Private lc_atendente_nome As String
    Private lc_produto_id As Integer
    Private lc_produto_nome As String
    Private lc_tempo_programado As Double
    Private lc_tempo_inicial As Date
    Private lc_tempo_final As Date
    Private lc_tempo_excedido As String 'Horas:Minutos:Segundos
    Private lc_tempo_acumulado As String 'Só minutos e segundos 00:00
    Private lc_valor_tempo As Double
    Private lc_valor_tempo_excedido As Double
    Private lc_valor_tempo_total As Double
    Private lc_finalizado As Boolean
    Private lc_data As Date
    Private lc_desconto As Double
    Private lc_valor_total_desconto As Double
    Private lc_justificativa As String


    Sub New(Optional ByVal vid As Int64 = 0, Optional ByVal vatendenteId As Integer = 0, Optional ByVal vatendenteNome As String = "", _
            Optional ByVal vprodutoId As Integer = 0, Optional ByVal vprodutoNome As String = "", Optional ByVal vtempoProgramado As Double = 0, _
            Optional ByVal vtempoInicial As Date = Nothing, Optional ByVal vtempoFinal As Date = Nothing, _
            Optional ByVal vtempoAcumulado As String = "00:00", Optional ByVal vvalorTempo As Double = 0, _
            Optional ByVal vvalorTempoTotal As Double = 0, Optional ByVal vfinalizado As Boolean = False, _
            Optional ByVal vtempoExcedido As String = "00:00:00", Optional ByVal vvalorTempoExcedido As Double = 0, Optional ByVal vdata As Date = Nothing, _
            Optional ByVal vDesconto As Double = 0, Optional ByVal vTotalDesconto As Double = 0, Optional ByVal vJustificativa As String = "")

        Me.lc_id = vid : Me.lc_atendente_id = vatendenteId : Me.lc_produto_id = vprodutoId
        Me.lc_atendente_nome = vatendenteNome : Me.lc_produto_nome = vprodutoNome
        Me.lc_tempo_programado = vtempoProgramado : Me.lc_valor_tempo = vvalorTempo : Me.lc_valor_tempo_excedido = vvalorTempoExcedido : Me.lc_valor_tempo_total = vvalorTempoTotal
        Me.lc_tempo_inicial = vtempoInicial : Me.lc_tempo_final = vtempoFinal : Me.lc_tempo_excedido = vtempoExcedido : Me.lc_tempo_acumulado = "00:00"
        Me.lc_finalizado = vfinalizado : Me.lc_data = vdata : Me.lc_desconto = vDesconto : Me.lc_valor_total_desconto = vTotalDesconto
        Me.lc_justificativa = vJustificativa
    End Sub

    Public Sub ZeraValores()

        Me.lc_id = 0 : Me.lc_atendente_id = 0 : Me.lc_produto_id = 0
        Me.lc_atendente_nome = "" : Me.lc_produto_nome = ""
        Me.lc_tempo_programado = 0 = Me.lc_valor_tempo = 0.0 : Me.lc_valor_tempo_excedido = 0.0 : Me.lc_valor_tempo_total = 0
        Me.lc_tempo_inicial = Nothing : Me.lc_tempo_final = Nothing : Me.lc_tempo_excedido = "00:00:00" : Me.lc_tempo_acumulado = "00:00"
        Me.lc_finalizado = False : Me.lc_data = Nothing : Me.lc_desconto = 0 : Me.lc_valor_total_desconto = 0 : Me.lc_justificativa = ""
    End Sub

#Region "Get e Set"

    Public Property mId As Int64
        Get
            Return Me.lc_id
        End Get
        Set(value As Int64)
            Me.lc_id = value
        End Set
    End Property

    Public Property mAtendenteId As Integer
        Get
            Return Me.lc_atendente_id
        End Get
        Set(value As Integer)
            Me.lc_atendente_id = value
        End Set
    End Property

    Public Property mProdutoId As Integer
        Get
            Return Me.lc_produto_id
        End Get
        Set(value As Integer)
            Me.lc_produto_id = value
        End Set
    End Property

    Public Property mAtendenteNome As String
        Get
            Return Me.lc_atendente_nome
        End Get
        Set(value As String)
            Me.lc_atendente_nome = value
        End Set
    End Property

    Public Property mProdutoNome As String
        Get
            Return Me.lc_produto_nome
        End Get
        Set(value As String)
            Me.lc_produto_nome = value
        End Set
    End Property

    Public Property mJustificativa As String
        Get
            Return Me.lc_justificativa
        End Get
        Set(value As String)
            Me.lc_justificativa = value
        End Set
    End Property

    Public Property mTempoProgramado As Double
        Get
            Return Me.lc_tempo_programado
        End Get
        Set(value As Double)
            Me.lc_tempo_programado = value
        End Set
    End Property

    Public Property mValorTempo As Double
        Get
            Return Me.lc_valor_tempo
        End Get
        Set(value As Double)
            Me.lc_valor_tempo = value
        End Set
    End Property

    Public Property mValorTempoExcedido As Double
        Get
            Return Me.lc_valor_tempo_excedido
        End Get
        Set(value As Double)
            Me.lc_valor_tempo_excedido = value
        End Set
    End Property

    Public Property mValorTempoTotal As Double
        Get
            Return Me.lc_valor_tempo_total
        End Get
        Set(value As Double)
            Me.lc_valor_tempo_total = value
        End Set
    End Property

    Public Property mDesconto As Double
        Get
            Return Me.lc_desconto
        End Get
        Set(value As Double)
            Me.lc_desconto = value
        End Set
    End Property

    Public Property mValorTotalDesconto As Double
        Get
            Return Me.lc_valor_total_desconto
        End Get
        Set(value As Double)
            Me.lc_valor_total_desconto = value
        End Set
    End Property

    Public Property mTempoInicial As Date
        Get
            Return Me.lc_tempo_inicial
        End Get
        Set(value As Date)
            Me.lc_tempo_inicial = value
        End Set
    End Property

    Public Property mTempoFinal As Date
        Get
            Return Me.lc_tempo_final
        End Get
        Set(value As Date)
            Me.lc_tempo_final = value
        End Set
    End Property

    Public Property mTempoExcedido As String
        Get
            Return Me.lc_tempo_excedido
        End Get
        Set(value As String)
            Me.lc_tempo_excedido = value
        End Set
    End Property

    Public Property mTempoAcumulado As String
        Get
            Return Me.lc_tempo_acumulado
        End Get
        Set(value As String)
            Me.lc_tempo_acumulado = value
        End Set
    End Property

    Public Property mFinalizado As Boolean
        Get
            Return Me.lc_finalizado
        End Get
        Set(value As Boolean)
            Me.lc_finalizado = value
        End Set
    End Property

    Public Property mData As Date
        Get
            Return Me.lc_data
        End Get
        Set(value As Date)
            Me.lc_data = value
        End Set
    End Property

#End Region

End Class
