Public Class ClCliente
    Inherits ClClienteDAO

    Private _cid As Integer
    Private _cnome As String
    Private _cestado As String
    Private _ccidade As String
    Private _cendereco As String
    Private _creferencia As String
    Private _cinativo As Boolean
    Private _cdatanascimento As String
    Private _cdataservico As String
    Private _ctelefone As String
    Private _cbairro As String
    Private _diames As String
    Private _cCpfCnpj As String
    Private _ccep As String
    Private _cemail As String
    Public Property observacao As String
    Public Property tipo As String
    Public Property ufid As Integer
    Public Property cidadeid As Int64
    Public Property cidadecodigo As String

    'Novas Propriedades para Ótica:
    Public Property cliRG As String
    Public Property cliApelido As String
    Public Property cliPai As String
    Public Property cliMae As String
    Public Property cliOF As String
    Public Property cliLocalTrabalho As String
    Public Property cliFuncaoTrabalho As String
    Public Property cliNomeConjugue As String
    Public Property cliApelidoConjugue As String


    Sub New(Optional ByVal vcid As Integer = 0, Optional ByVal vcnome As String = "", Optional ByVal vcestado As String = "", _
            Optional ByVal vccidade As String = "", Optional ByVal vcendereco As String = "", Optional ByVal vcreferencia As String = "", _
            Optional ByVal vcinativo As Boolean = False, Optional ByVal vcdatanascimento As String = "", _
            Optional ByVal vctelefone As String = "", Optional ByVal vcbairro As String = "", Optional ByVal vcdataservico As String = "", _
            Optional ByVal vdiames As String = "", Optional ByVal vcpf As String = "", _
            Optional ByVal vcep As String = "", Optional ByVal vemail As String = "", Optional ByVal vObservacao As String = "", _
            Optional ByVal vTipo As String = "", Optional ByVal vUfID As Integer = 0, Optional ByVal vCidadeID As Int64 = 0, _
            Optional ByVal vCodigoCidade As String = "", Optional ByVal vCliRG As String = "", Optional ByVal vCliApelido As String = "", _
            Optional ByVal vCliPai As String = "", Optional ByVal vCliMae As String = "", Optional ByVal vCliOF As String = "", _
            Optional ByVal vCliLocalTrabalho As String = "", Optional ByVal vCliFuncaoTrabalho As String = "", _
            Optional ByVal vCliNomeConjugue As String = "", Optional ByVal vCliApelidoConjugue As String = "")

        Me._cid = vcid : Me._cnome = vcnome : Me._cestado = vcestado : Me._ccidade = vccidade : Me._cendereco = vcendereco
        Me._creferencia = vcreferencia : Me._cinativo = vcinativo : Me._cdatanascimento = vcdatanascimento
        Me._ctelefone = vctelefone : Me._cbairro = vcbairro : Me._cdataservico = vcdataservico : Me._diames = vdiames
        Me._cCpfCnpj = vcpf : Me._ccep = vcep : Me._cemail = vemail : Me._observacao = vObservacao
        Me.tipo = vTipo : Me.ufid = vUfID : Me.cidadeid = vCidadeID : Me.cidadecodigo = vCodigoCidade

        Me.cliRG = vCliRG : Me.cliApelido = vCliApelido : Me.cliPai = vCliPai : Me.cliMae = vCliMae : Me.cliOF = vCliOF
        Me.cliLocalTrabalho = vCliLocalTrabalho : Me.cliFuncaoTrabalho = vCliFuncaoTrabalho : Me.cliNomeConjugue = vCliNomeConjugue
        Me.cliApelidoConjugue = vCliApelidoConjugue
    End Sub

    Sub New(Cliente As ClCliente)

        With Me

            .cid = Cliente.cid
            .cnome = Cliente.cnome
            ._cestado = Cliente._cestado
            ._ccidade = Cliente._ccidade
            ._cendereco = Cliente._cendereco
            ._creferencia = Cliente._creferencia
            ._cinativo = Cliente._cinativo
            ._cdatanascimento = Cliente._cdatanascimento
            ._ctelefone = Cliente._ctelefone
            ._cbairro = Cliente._cbairro
            ._cdataservico = Cliente._cdataservico
            ._diames = Cliente._diames
            ._cCpfCnpj = Cliente._cCpfCnpj
            ._ccep = Cliente._ccep
            ._cemail = Cliente._cemail
            .observacao = Cliente.observacao
            .tipo = Cliente.tipo
            .ufid = Cliente.ufid
            .cidadeid = Cliente.cidadeid
            .cidadecodigo = Cliente.cidadecodigo

            .cliRG = Cliente.cliRG
            .cliApelido = Cliente.cliApelido
            .cliPai = Cliente.cliPai
            .cliMae = Cliente.cliMae
            .cliOF = Cliente.cliOF
            .cliLocalTrabalho = Cliente.cliLocalTrabalho
            .cliFuncaoTrabalho = Cliente.cliFuncaoTrabalho
            .cliNomeConjugue = Cliente.cliNomeConjugue
            .cliApelidoConjugue = Cliente.cliApelidoConjugue

        End With

    End Sub

    Sub SetaValores(Cliente As ClCliente)

        With Me

            .cid = Cliente.cid
            .cnome = Cliente.cnome
            ._cestado = Cliente._cestado
            ._ccidade = Cliente._ccidade
            ._cendereco = Cliente._cendereco
            ._creferencia = Cliente._creferencia
            ._cinativo = Cliente._cinativo
            ._cdatanascimento = Cliente._cdatanascimento
            ._ctelefone = Cliente._ctelefone
            ._cbairro = Cliente._cbairro
            ._cdataservico = Cliente._cdataservico
            ._diames = Cliente._diames
            ._cCpfCnpj = Cliente._cCpfCnpj
            ._ccep = Cliente._ccep
            ._cemail = Cliente._cemail
            .observacao = Cliente.observacao
            .tipo = Cliente.tipo
            .ufid = Cliente.ufid
            .cidadeid = Cliente.cidadeid
            .cidadecodigo = Cliente.cidadecodigo

            .cliRG = Cliente.cliRG
            .cliApelido = Cliente.cliApelido
            .cliPai = Cliente.cliPai
            .cliMae = Cliente.cliMae
            .cliOF = Cliente.cliOF
            .cliLocalTrabalho = Cliente.cliLocalTrabalho
            .cliFuncaoTrabalho = Cliente.cliFuncaoTrabalho
            .cliNomeConjugue = Cliente.cliNomeConjugue
            .cliApelidoConjugue = Cliente.cliApelidoConjugue
        End With

    End Sub

    Sub ZeraValores()
        Me._cid = 0 : Me._cnome = "" : Me._cestado = "" : Me._ccidade = "" : Me._cendereco = ""
        Me._creferencia = "" : Me._cinativo = False : Me._cdatanascimento = "" : Me._ctelefone = ""
        Me._cbairro = "" : Me._cdataservico = "" : Me._diames = "" : Me._cCpfCnpj = ""
        Me._ccep = "" : Me._cemail = "" : Me.observacao = ""
        Me.tipo = "" : Me.ufid = 0 : Me.cidadeid = 0 : Me.cidadecodigo = ""
        Me.cliRG = "" : Me.cliApelido = "" : Me.cliPai = "" : Me.cliMae = "" : Me.cliOF = ""
        Me.cliLocalTrabalho = "" : Me.cliFuncaoTrabalho = "" : Me.cliNomeConjugue = ""
        Me.cliApelidoConjugue = ""
    End Sub

#Region "Get e Set"

    Public Property cid() As Integer
        Get
            Return Me._cid
        End Get
        Set(value As Integer)
            Me._cid = value
        End Set
    End Property

    Public Property ccep() As String
        Get
            Return Me._ccep
        End Get
        Set(value As String)
            Me._ccep = value
        End Set
    End Property

    Public Property cemail() As String
        Get
            Return Me._cemail
        End Get
        Set(value As String)
            Me._cemail = value
        End Set
    End Property

    Public Property cCpfCnpj() As String
        Get
            Return Me._cCpfCnpj
        End Get
        Set(value As String)
            Me._cCpfCnpj = value
        End Set
    End Property

    Public Property cnome() As String
        Get
            Return Me._cnome
        End Get
        Set(value As String)
            Me._cnome = value
        End Set
    End Property

    Public Property cestado() As String
        Get
            Return Me._cestado
        End Get
        Set(value As String)
            Me._cestado = value
        End Set
    End Property

    Public Property ccidade() As String
        Get
            Return Me._ccidade
        End Get
        Set(value As String)
            Me._ccidade = value
        End Set
    End Property

    Public Property cendereco() As String
        Get
            Return Me._cendereco
        End Get
        Set(value As String)
            Me._cendereco = value
        End Set
    End Property

    Public Property creferencia() As String
        Get
            Return Me._creferencia
        End Get
        Set(value As String)
            Me._creferencia = value
        End Set
    End Property

    Public Property cinativo() As Boolean
        Get
            Return Me._cinativo
        End Get
        Set(value As Boolean)
            Me._cinativo = value
        End Set
    End Property

    Public Property cdatanascimento() As String
        Get
            Return Me._cdatanascimento
        End Get
        Set(value As String)
            Me._cdatanascimento = value
        End Set
    End Property

    Public Property ctelefone() As String
        Get
            Return Me._ctelefone
        End Get
        Set(value As String)
            Me._ctelefone = value
        End Set
    End Property

    Public Property cbairro() As String
        Get
            Return Me._cbairro
        End Get
        Set(value As String)
            Me._cbairro = value
        End Set
    End Property

    Public Property cdataservico() As String
        Get
            Return Me._cdataservico
        End Get
        Set(value As String)
            Me._cdataservico = value
        End Set
    End Property

    Public Property cdiames() As String
        Get
            Return Me._diames
        End Get
        Set(value As String)
            Me._diames = value
        End Set
    End Property
#End Region

End Class
