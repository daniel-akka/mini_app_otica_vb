Public Class ClProdutoUsadoVenda


    Private _puvid As Int64, _puvidproduto As Integer
    Private _puvnomeproduto As String
    Private _puvidservico As Integer
    Private _puvdescrservico As String
    Private _puvqtdeproduto As Double
    Private _puvdatahora As Date
    Private _puvidvenda As Int64

    Sub New(ByVal vDataHora As Date, Optional ByVal vID As Int64 = 0, Optional ByVal vIdProduto As Integer = 0, _
            Optional ByVal vIdServico As Integer = 0, Optional ByVal vNomeProduto As String = "", _
            Optional ByVal vDescrServico As String = "", Optional ByVal vQtdeProduto As Double = 0, Optional ByVal vIdVenda As Int64 = 0)

        Me._puvid = vID : Me._puvidproduto = vIdProduto : Me._puvidservico = vIdServico
        Me._puvnomeproduto = vNomeProduto : Me._puvdescrservico = vDescrServico
        Me._puvqtdeproduto = vQtdeProduto
        Me._puvdatahora = vDataHora
        Me._puvidvenda = vIdVenda
    End Sub

    Sub ZeraValores()
        Me._puvid = 0 : Me._puvidproduto = 0 : Me._puvidservico = 0
        Me._puvnomeproduto = "" : Me._puvdescrservico = ""
        Me._puvqtdeproduto = 0
        Me._puvdatahora = Nothing
        Me._puvidvenda = 0
    End Sub

#Region "Get e Set"

    Public Property puvid() As Int64
        Get
            Return Me._puvid
        End Get
        Set(value As Int64)
            Me._puvid = value
        End Set
    End Property

    Public Property puvidVenda() As Int64
        Get
            Return Me._puvidvenda
        End Get
        Set(value As Int64)
            Me._puvidvenda = value
        End Set
    End Property

    Public Property puvidproduto() As Integer
        Get
            Return Me._puvidproduto
        End Get
        Set(value As Integer)
            Me._puvidproduto = value
        End Set
    End Property

    Public Property puvidservico() As Integer
        Get
            Return Me._puvidservico
        End Get
        Set(value As Integer)
            Me._puvidservico = value
        End Set
    End Property

    Public Property puvnomeproduto() As String
        Get
            Return Me._puvnomeproduto
        End Get
        Set(value As String)
            Me._puvnomeproduto = value
        End Set
    End Property

    Public Property puvdescrservico() As String
        Get
            Return Me._puvdescrservico
        End Get
        Set(value As String)
            Me._puvdescrservico = value
        End Set
    End Property

    Public Property puvqtdeproduto() As Double
        Get
            Return Me._puvqtdeproduto
        End Get
        Set(value As Double)
            Me._puvqtdeproduto = value
        End Set
    End Property

    Public Property puvdatahora() As Date
        Get
            Return Me._puvdatahora
        End Get
        Set(value As Date)
            Me._puvdatahora = value
        End Set
    End Property
#End Region

End Class
