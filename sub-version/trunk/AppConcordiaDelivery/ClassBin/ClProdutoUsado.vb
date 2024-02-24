Public Class ClProdutoUsado

    Private _puid As Int64, _puidproduto As Integer
    Private _punomeproduto As String
    Private _puidservico As Integer
    Private _pudescrservico As String
    Private _puqtdeproduto As Double
    Private _pudatahora As Date

    Sub New(ByVal vDataHora As Date, Optional ByVal vID As Int64 = 0, Optional ByVal vIdProduto As Integer = 0, _
            Optional ByVal vIdServico As Integer = 0, Optional ByVal vNomeProduto As String = "", _
            Optional ByVal vDescrServico As String = "", Optional ByVal vQtdeProduto As Double = 0)

        Me._puid = vID : Me._puidproduto = vIdProduto : Me._puidservico = vIdServico
        Me._punomeproduto = vNomeProduto : Me._pudescrservico = vDescrServico
        Me._puqtdeproduto = vQtdeProduto
        Me._pudatahora = vDataHora
    End Sub

    Sub ZeraValores()
        Me._puid = 0 : Me._puidproduto = 0 : Me._puidservico = 0
        Me._punomeproduto = "" : Me._pudescrservico = ""
        Me._puqtdeproduto = 0
        Me._pudatahora = Nothing
    End Sub

#Region "Get e Set"

    Public Property puid() As Int64
        Get
            Return Me._puid
        End Get
        Set(value As Int64)
            Me._puid = value
        End Set
    End Property

    Public Property puidproduto() As Integer
        Get
            Return Me._puidproduto
        End Get
        Set(value As Integer)
            Me._puidproduto = value
        End Set
    End Property

    Public Property puidservico() As Integer
        Get
            Return Me._puidservico
        End Get
        Set(value As Integer)
            Me._puidservico = value
        End Set
    End Property

    Public Property punomeproduto() As String
        Get
            Return Me._punomeproduto
        End Get
        Set(value As String)
            Me._punomeproduto = value
        End Set
    End Property

    Public Property pudescrservico() As String
        Get
            Return Me._pudescrservico
        End Get
        Set(value As String)
            Me._pudescrservico = value
        End Set
    End Property

    Public Property puqtdeproduto() As Double
        Get
            Return Me._puqtdeproduto
        End Get
        Set(value As Double)
            Me._puqtdeproduto = value
        End Set
    End Property

    Public Property pudatahora() As Date
        Get
            Return Me._pudatahora
        End Get
        Set(value As Date)
            Me._pudatahora = value
        End Set
    End Property
#End Region
End Class
