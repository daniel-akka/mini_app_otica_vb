Public Class ClFornecedor

    Private fid As Integer
    Private fnome As String
    Private fendereco As String
    Private fbairro As String
    Private fcidade As String
    Private festado As String
    Private fidestado As Integer
    Private fidcidade As Integer
    Private fcnpj As String
    Private fcpf As String
    Private ftelefone As String
    Dim _funcoes As New ClFuncoes

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vNome As String = "", Optional ByVal vEndereco As String = "", _
            Optional ByVal vBairro As String = "", Optional ByVal vCidade As String = "", Optional ByVal vEstado As String = "",
            Optional ByVal vIdEstado As Integer = 0, Optional ByVal vIdCidade As Integer = 0, Optional ByVal vCnpj As String = "", _
            Optional ByVal vCpf As String = "", Optional ByVal vTelefone As String = "")
        Me.fid = vId : Me.fnome = vNome : Me.fendereco = vEndereco : Me.fbairro = vBairro
        Me.fcidade = vCidade : Me.festado = vEstado : Me.fidestado = vIdEstado : Me.fidcidade = vIdCidade
        Me.fcnpj = vCnpj : Me.fcpf = vCpf : Me.ftelefone = vTelefone
    End Sub

    Public Sub ZeraValores()
        Me.fid = 0 : Me.fnome = "" : Me.fendereco = "" : Me.fbairro = "" : Me.fcpf = "" : Me.fcnpj = ""
        Me.fcidade = "" : Me.festado = "" : Me.fidestado = 0 : Me.fidcidade = 0 : Me.ftelefone = ""
    End Sub

    Sub New(fornecedor As ClFornecedor)

        With Me

            .pId = fornecedor.pId
            .pNome = fornecedor.pNome
            .pIdEstado = fornecedor.pIdEstado
            .pIdCidade = fornecedor.pIdCidade
            .pEstado = fornecedor.pEstado
            .pCidade = fornecedor.pCidade
            .pfTelefone = fornecedor.pfTelefone
            .pfCpf = fornecedor.pfCpf
            .pfCnpj = fornecedor.pfCnpj
            .pEndereco = fornecedor.pEndereco
            .pBairro = fornecedor.pBairro

        End With
    End Sub

    Public Sub SetaValores(fornecedor As ClFornecedor)

        With Me

            .pId = fornecedor.pId
            .pNome = fornecedor.pNome
            .pIdEstado = fornecedor.pIdEstado
            .pIdCidade = fornecedor.pIdCidade
            .pEstado = fornecedor.pEstado
            .pCidade = fornecedor.pCidade
            .pfTelefone = fornecedor.pfTelefone
            .pfCpf = fornecedor.pfCpf
            .pfCnpj = fornecedor.pfCnpj
            .pEndereco = fornecedor.pEndereco
            .pBairro = fornecedor.pBairro

        End With
    End Sub

#Region "Get e Set"

    Public Property pId() As Int64
        Get
            Return Me.fid
        End Get
        Set(value As Int64)
            Me.fid = value
        End Set
    End Property

    Public Property pNome() As String
        Get
            Return Me.fnome
        End Get
        Set(value As String)
            Me.fnome = value
        End Set
    End Property

    Public Property pEndereco() As String
        Get
            Return Me.fendereco
        End Get
        Set(value As String)
            Me.fendereco = value
        End Set
    End Property

    Public Property pBairro() As String
        Get
            Return Me.fbairro
        End Get
        Set(value As String)
            Me.fbairro = value
        End Set
    End Property

    Public Property pCidade() As String
        Get
            Return Me.fcidade
        End Get
        Set(value As String)
            Me.fcidade = value
        End Set
    End Property

    Public Property pEstado() As String
        Get
            Return Me.festado
        End Get
        Set(value As String)
            Me.festado = value
        End Set
    End Property

    Public Property pIdEstado() As Integer
        Get
            Return Me.fidestado
        End Get
        Set(value As Integer)
            Me.fidestado = value
        End Set
    End Property

    Public Property pIdCidade() As Integer
        Get
            Return Me.fidcidade
        End Get
        Set(value As Integer)
            Me.fidcidade = value
        End Set
    End Property

    Public Property pfCnpj() As String
        Get
            Return Me.fcnpj
        End Get
        Set(value As String)
            Me.fcnpj = value
        End Set
    End Property

    Public Property pfCpf() As String
        Get
            Return Me.fcpf
        End Get
        Set(value As String)

            Me.fcpf = value
        End Set
    End Property

    Public Property pfTelefone() As String
        Get
            Return Me.ftelefone
        End Get
        Set(value As String)
            Me.ftelefone = value
        End Set
    End Property
#End Region

End Class
