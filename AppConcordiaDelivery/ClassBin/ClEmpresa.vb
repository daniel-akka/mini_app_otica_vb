Public Class ClEmpresa
    Inherits ClEmpresaDAO

    Private _empid As Integer
    Private _emprazaosocial As String, _empfantasia As String, _empendereco As String, _empbairro As String
    Private _empfone As String, _empestado As String, _empcidade As String
    Private _empCnpj As String, _empCPF As String

    Sub New(Optional ByVal id As Integer = 0, Optional ByVal razaosocial As String = "", _
            Optional ByVal fantasia As String = "", Optional ByVal endereco As String = "", _
            Optional ByVal bairro As String = "", Optional ByVal fone As String = "", _
            Optional ByVal estado As String = "", Optional ByVal cidade As String = "", _
            Optional ByVal Cnpj As String = "", Optional ByVal CPF As String = "")

        Me._empid = id : Me._emprazaosocial = razaosocial : Me._empendereco = endereco
        Me._empbairro = bairro : Me._empfone = fone : Me._empestado = estado : Me._empcidade = cidade
        Me._empCnpj = Cnpj : Me._empCPF = CPF
    End Sub

    Sub New(ByVal vEmpresa As ClEmpresa)

        With Me

            .empid = vEmpresa.empid
            ._emprazaosocial = vEmpresa._emprazaosocial
            ._empendereco = vEmpresa._empendereco
            ._empfantasia = vEmpresa._empfantasia
            ._empbairro = vEmpresa._empbairro
            ._empfone = vEmpresa._empfone
            ._empestado = vEmpresa._empestado
            ._empcidade = vEmpresa._empcidade
            ._empCnpj = vEmpresa._empCnpj
            ._empCPF = vEmpresa._empCPF
        End With
    End Sub


    Sub ZeraValores()
        Me._empid = 0 : Me._emprazaosocial = "" : Me._empendereco = "" : Me._empfantasia = ""
        Me._empbairro = "" : Me._empfone = "" : Me._empestado = "" : Me._empcidade = ""
        Me._empCnpj = "" : Me._empCPF = ""
    End Sub

    Sub setValores(empresa As ClEmpresa)

        With Me

            .empid = empresa.empid
            ._emprazaosocial = empresa._emprazaosocial
            ._empendereco = empresa._empendereco
            ._empfantasia = empresa._empfantasia
            ._empbairro = empresa._empbairro
            ._empfone = empresa._empfone
            ._empestado = empresa._empestado
            ._empcidade = empresa._empcidade
            ._empCnpj = empresa._empCnpj
            ._empCPF = empresa._empCPF
        End With
    End Sub

#Region "Get and Set"

    Public Property empid() As Integer
        Get
            Return Me._empid
        End Get
        Set(value As Integer)
            Me._empid = value
        End Set
    End Property

    Public Property empCnpj() As String
        Get
            Return Me._empCnpj
        End Get
        Set(value As String)
            Me._empCnpj = value
        End Set
    End Property

    Public Property empCPF() As String
        Get
            Return Me._empCPF
        End Get
        Set(value As String)
            Me._empCPF = value
        End Set
    End Property

    Public Property emprazaosocial() As String
        Get
            Return Me._emprazaosocial
        End Get
        Set(value As String)
            Me._emprazaosocial = value
        End Set
    End Property

    Public Property empendereco() As String
        Get
            Return Me._empendereco
        End Get
        Set(value As String)
            Me._empendereco = value
        End Set
    End Property

    Public Property empfantasia() As String
        Get
            Return Me._empfantasia
        End Get
        Set(value As String)
            Me._empfantasia = value
        End Set
    End Property

    Public Property empbairro() As String
        Get
            Return Me._empbairro
        End Get
        Set(value As String)
            Me._empbairro = value
        End Set
    End Property

    Public Property empfone() As String
        Get
            Return Me._empfone
        End Get
        Set(value As String)
            Me._empfone = value
        End Set
    End Property

    Public Property empestado() As String
        Get
            Return Me._empestado
        End Get
        Set(value As String)
            Me._empestado = value
        End Set
    End Property

    Public Property empcidade() As String
        Get
            Return Me._empcidade
        End Get
        Set(value As String)
            Me._empcidade = value
        End Set
    End Property

#End Region
End Class
