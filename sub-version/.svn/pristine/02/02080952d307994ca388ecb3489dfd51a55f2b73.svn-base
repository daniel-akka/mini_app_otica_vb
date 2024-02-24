Public Class ClAReceberListCaixa

    Private _Cliente As String, _Situacao As String, _Data As Date, _Total As Double, _Dinheiro As Double
    Private _cartaoCredito As Double, _cartaoDebito As Double, _Pix As Double, _Transferencia As Double

    Sub New(Optional ByVal vCliente As String = "", Optional ByVal vSituacao As String = "", _
            Optional ByVal vData As Date = Nothing, Optional ByVal vTotal As Double = 0, _
            Optional ByVal vDinheiro As Double = 0, Optional ByVal vcartaoCredito As Double = 0, _
            Optional ByVal vcartaoDebito As Double = 0, Optional ByVal vPix As Double = 0, _
            Optional ByVal vTransferencia As Double = 0)

        Me._Cliente = vCliente : Me._Situacao = Situacao : Me._Data = vData
        Me._Total = vTotal : Me._Dinheiro = vDinheiro : Me._cartaoCredito = vcartaoCredito
        Me._cartaoDebito = vcartaoDebito : Me._Pix = vPix : Me._Transferencia = vTransferencia

    End Sub


#Region "   Get e Set"

    Public Property Cliente() As String
        Get
            Return Me._Cliente
        End Get
        Set(value As String)
            Me._Cliente = value
        End Set
    End Property

    Public Property Data() As Date
        Get
            Return Me._Data
        End Get
        Set(value As Date)
            Me._Data = value
        End Set
    End Property

    Public Property Situacao() As String
        Get
            Return Me._Situacao
        End Get
        Set(value As String)
            Me._Situacao = value
        End Set
    End Property

    Public Property Total() As Double
        Get
            Return Me._Total
        End Get
        Set(value As Double)
            Me._Total = value
        End Set
    End Property

    Public Property Dinheiro() As Double
        Get
            Return Me._Dinheiro
        End Get
        Set(value As Double)
            Me._Dinheiro = value
        End Set
    End Property

    Public Property cartaoCredito() As Double
        Get
            Return Me._cartaoCredito
        End Get
        Set(value As Double)
            Me._cartaoCredito = value
        End Set
    End Property

    Public Property cartaoDebito() As Double
        Get
            Return Me._cartaoDebito
        End Get
        Set(value As Double)
            Me._cartaoDebito = value
        End Set
    End Property

    Public Property Pix() As Double
        Get
            Return Me._Pix
        End Get
        Set(value As Double)
            Me._Pix = value
        End Set
    End Property

    Public Property Transferencia() As Double
        Get
            Return Me._Transferencia
        End Get
        Set(value As Double)
            Me._Transferencia = value
        End Set
    End Property
#End Region

End Class
