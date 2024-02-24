Public Class Cl_Municipio

    Private idEstado As Integer, siglaEstado As String, codEstado As String
    Private codMun As Integer, nomeMun As String
    Public Property id As Int64

    Public Sub New()

        Me.idEstado = 0 : Me.siglaEstado = "" : Me.codEstado = "" : Me.codMun = 0
        Me.nomeMun = ""
        Me.id = 0
    End Sub

    Sub New(cidade As Cl_Municipio)

        With Me
            .id = cidade.id
            .idEstado = cidade.pIdEstado
            .siglaEstado = cidade.pSiglaEstado
            .codEstado = cidade.codEstado
            .codMun = cidade.codMun
            .nomeMun = cidade.pNomeMun
        End With
    End Sub

    Sub setaValores(cidade As Cl_Municipio)

        With Me
            .id = cidade.id
            .idEstado = cidade.pIdEstado
            .siglaEstado = cidade.pSiglaEstado
            .codEstado = cidade.codEstado
            .codMun = cidade.codMun
            .nomeMun = cidade.pNomeMun
        End With
    End Sub

    Public Sub zeraValores()

        Me.idEstado = 0 : Me.siglaEstado = "" : Me.codEstado = "" : Me.codMun = 0
        Me.nomeMun = "" : Me.id = 0
    End Sub


#Region "   * *  Metodos Set e Get  * *   "

    Public Property pIdEstado() As Integer
        Get
            Return Me.idEstado
        End Get
        Set(ByVal value As Integer)
            Me.idEstado = value
        End Set
    End Property

    Public Property pSiglaEstado() As String
        Get
            Return Me.siglaEstado
        End Get
        Set(ByVal value As String)
            Me.siglaEstado = value
        End Set
    End Property


    Public Property pCodEstado() As String
        Get
            Return Me.codEstado
        End Get
        Set(ByVal value As String)
            Me.codEstado = value
        End Set
    End Property

    Public Property pCodMun() As Integer
        Get
            Return Me.codMun
        End Get
        Set(ByVal value As Integer)
            Me.codMun = value
        End Set
    End Property

    Public Property pNomeMun() As String
        Get
            Return Me.nomeMun
        End Get
        Set(ByVal value As String)
            Me.nomeMun = value
        End Set
    End Property

#End Region

End Class
