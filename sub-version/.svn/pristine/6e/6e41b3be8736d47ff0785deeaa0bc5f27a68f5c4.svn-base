Public Class ClMovimentacao

    Private m_id As Int64
    Private m_atendente_id As Integer
    Private m_atendente_nome As String
    Private m_produto_id As Integer
    Private m_produto_nome As String
    Private m_tempo_programado As Double
    Private m_tempo_inicial As Date
    Private m_tempo_final As Date
    Private m_tempo_excedido As String 'Horas:Minutos:Segundos
    Private m_tempo_acumulado As String 'Só minutos e segundos 00:00
    Private m_valor_tempo As Double
    Private m_valor_tempo_excedido As Double
    Private m_valor_tempo_total As Double
    Private m_finalizado As Boolean
    Private m_data As Date
    Private m_desconto As Double
    Private m_valor_total_desconto As Double
    Private m_justificativa As String
    Private m_iniciado As Boolean


    Sub New(Optional ByVal vid As Int64 = 0, Optional ByVal vatendenteId As Integer = 0, Optional ByVal vatendenteNome As String = "",
            Optional ByVal vprodutoId As Integer = 0, Optional ByVal vprodutoNome As String = "", Optional ByVal vtempoProgramado As Double = 0,
            Optional ByVal vtempoInicial As Date = Nothing, Optional ByVal vtempoFinal As Date = Nothing,
            Optional ByVal vtempoAcumulado As String = "00:00", Optional ByVal vvalorTempo As Double = 0,
            Optional ByVal vvalorTempoTotal As Double = 0, Optional ByVal vfinalizado As Boolean = False,
            Optional ByVal vtempoExcedido As String = "00:00:00", Optional ByVal vvalorTempoExcedido As Double = 0, Optional ByVal vdata As Date = Nothing,
            Optional ByVal vDesconto As Double = 0, Optional ByVal vTotalDesconto As Double = 0,
            Optional ByVal vInciado As Boolean = False, Optional ByVal vJustificativa As String = "")

        Me.m_id = vid : Me.m_atendente_id = vatendenteId : Me.m_produto_id = vprodutoId
        Me.m_atendente_nome = vatendenteNome : Me.m_produto_nome = vprodutoNome
        Me.m_tempo_programado = vtempoProgramado : Me.m_valor_tempo = vvalorTempo : Me.m_valor_tempo_excedido = vvalorTempoExcedido : Me.m_valor_tempo_total = vvalorTempoTotal
        Me.m_tempo_inicial = vtempoInicial : Me.m_tempo_final = vtempoFinal : Me.m_tempo_excedido = vtempoExcedido : Me.m_tempo_acumulado = "00:00"
        Me.m_finalizado = vfinalizado : Me.m_data = vdata : Me.m_desconto = vDesconto : Me.m_valor_total_desconto = vTotalDesconto
        Me.m_justificativa = vJustificativa : Me.m_iniciado = vInciado
    End Sub

    Public Sub ZeraValores()

        Me.m_id = 0 : Me.m_atendente_id = 0 : Me.m_produto_id = 0
        Me.m_atendente_nome = "" : Me.m_produto_nome = ""
        Me.m_tempo_programado = 0 = Me.m_valor_tempo = 0.0 : Me.m_valor_tempo_excedido = 0.0 : Me.m_valor_tempo_total = 0
        Me.m_tempo_inicial = Nothing : Me.m_tempo_final = Nothing : Me.m_tempo_excedido = "00:00:00" : Me.m_tempo_acumulado = "00:00"
        Me.m_finalizado = False : Me.m_data = Nothing : Me.m_desconto = 0 : Me.m_valor_total_desconto = 0 : Me.m_justificativa = ""
    End Sub

#Region "Get e Set"

    Public Property mId As Int64
        Get
            Return Me.m_id
        End Get
        Set(value As Int64)
            Me.m_id = value
        End Set
    End Property

    Public Property mAtendenteId As Integer
        Get
            Return Me.m_atendente_id
        End Get
        Set(value As Integer)
            Me.m_atendente_id = value
        End Set
    End Property

    Public Property mProdutoId As Integer
        Get
            Return Me.m_produto_id
        End Get
        Set(value As Integer)
            Me.m_produto_id = value
        End Set
    End Property

    Public Property mAtendenteNome As String
        Get
            Return Me.m_atendente_nome
        End Get
        Set(value As String)
            Me.m_atendente_nome = value
        End Set
    End Property

    Public Property mProdutoNome As String
        Get
            Return Me.m_produto_nome
        End Get
        Set(value As String)
            Me.m_produto_nome = value
        End Set
    End Property

    Public Property mJustificativa As String
        Get
            Return Me.m_justificativa
        End Get
        Set(value As String)
            Me.m_justificativa = value
        End Set
    End Property

    Public Property mTempoProgramado As Double
        Get
            Return Me.m_tempo_programado
        End Get
        Set(value As Double)
            Me.m_tempo_programado = value
        End Set
    End Property

    Public Property mValorTempo As Double
        Get
            Return Me.m_valor_tempo
        End Get
        Set(value As Double)
            Me.m_valor_tempo = value
        End Set
    End Property

    Public Property mValorTempoExcedido As Double
        Get
            Return Me.m_valor_tempo_excedido
        End Get
        Set(value As Double)
            Me.m_valor_tempo_excedido = value
        End Set
    End Property

    Public Property mValorTempoTotal As Double
        Get
            Return Me.m_valor_tempo_total
        End Get
        Set(value As Double)
            Me.m_valor_tempo_total = value
        End Set
    End Property

    Public Property mDesconto As Double
        Get
            Return Me.m_desconto
        End Get
        Set(value As Double)
            Me.m_desconto = value
        End Set
    End Property

    Public Property mValorTotalDesconto As Double
        Get
            Return Me.m_valor_total_desconto
        End Get
        Set(value As Double)
            Me.m_valor_total_desconto = value
        End Set
    End Property

    Public Property mTempoInicial As Date
        Get
            Return Me.m_tempo_inicial
        End Get
        Set(value As Date)
            Me.m_tempo_inicial = value
        End Set
    End Property

    Public Property mTempoFinal As Date
        Get
            Return Me.m_tempo_final
        End Get
        Set(value As Date)
            Me.m_tempo_final = value
        End Set
    End Property

    Public Property mTempoExcedido As String
        Get
            Return Me.m_tempo_excedido
        End Get
        Set(value As String)
            Me.m_tempo_excedido = value
        End Set
    End Property

    Public Property mTempoAcumulado As String
        Get
            Return Me.m_tempo_acumulado
        End Get
        Set(value As String)
            Me.m_tempo_acumulado = value
        End Set
    End Property

    Public Property mFinalizado As Boolean
        Get
            Return Me.m_finalizado
        End Get
        Set(value As Boolean)
            Me.m_finalizado = value
        End Set
    End Property

    Public Property mData As Date
        Get
            Return Me.m_data
        End Get
        Set(value As Date)
            Me.m_data = value
        End Set
    End Property

    Public Property mIniciado As Boolean
        Get
            Return Me.m_iniciado
        End Get
        Set(value As Boolean)
            Me.m_iniciado = value
        End Set
    End Property

#End Region

End Class
