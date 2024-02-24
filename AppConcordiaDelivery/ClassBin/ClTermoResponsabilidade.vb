Public Class ClTermoResponsabilidade

    Private tr_Id As Int64
    Private tr_termo1 As String
    Private tr_termo2 As String
    Private tr_termo3 As String
    Private tr_termo4 As String

    Sub New()
        Me.tr_Id = 0 : Me.tr_termo1 = "" : Me.tr_termo2 = "" : Me.tr_termo3 = "" : Me.tr_termo4 = ""
    End Sub

    Public Sub ZeraValores()
        Me.tr_Id = 0 : Me.tr_termo1 = "" : Me.tr_termo2 = "" : Me.tr_termo3 = "" : Me.tr_termo4 = ""
    End Sub

#Region "Get e Set"

    Public Property trId() As Int64
        Get
            Return Me.tr_Id
        End Get
        Set(value As Int64)
            Me.tr_Id = value
        End Set
    End Property

    Public Property trTermo1() As String
        Get
            Return Me.tr_termo1
        End Get
        Set(value As String)
            Me.tr_termo1 = value
        End Set
    End Property

    Public Property trTermo2() As String
        Get
            Return Me.tr_termo2
        End Get
        Set(value As String)
            Me.tr_termo2 = value
        End Set
    End Property

    Public Property trTermo3() As String
        Get
            Return Me.tr_termo3
        End Get
        Set(value As String)
            Me.tr_termo3 = value
        End Set
    End Property

    Public Property trTermo4() As String
        Get
            Return Me.tr_termo4
        End Get
        Set(value As String)
            Me.tr_termo4 = value
        End Set
    End Property
#End Region

End Class
