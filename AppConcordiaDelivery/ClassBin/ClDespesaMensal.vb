Public Class ClDespesaMensal

    Private _dm_id As Int64, _dm_empresaid As Integer, _dm_empresanome As String, _dm_gpid As Int64, _dm_gpdescricao As String
    Private _dm_sgpid As Int64, _dm_sgpdescricao As String, _dm_data_despesa As Date, _dm_data_inclusao As Date
    Private _dm_valor As Double, _dm_observacao As String, _dm_alteracao As Boolean, _dm_fechado As Boolean

    Sub New(Optional ByVal Id As Int64 = 0, Optional ByVal EmpresaId As Integer = 0, Optional ByVal EmpresaNome As String = "", _
            Optional ByVal GrupoId As Int64 = 0, Optional ByVal GrupoDescricao As String = "", Optional ByVal SubGrupoID As Int64 = 0, _
            Optional ByVal SubGrupoDescricao As String = "", Optional ByVal DataDespesa As Date = Nothing, Optional ByVal DataInclusao As Date = Nothing, _
            Optional ByVal Valor As Double = 0.0, Optional ByVal Observacao As String = "", Optional ByVal Alteracao As Boolean = False, _
            Optional ByVal Fechado As Boolean = False)

        With Me

            ._dm_id = Id
            ._dm_empresaid = EmpresaId
            ._dm_empresanome = EmpresaNome
            ._dm_gpid = GrupoId
            ._dm_gpdescricao = GrupoDescricao
            ._dm_sgpid = SubGrupoID
            ._dm_sgpdescricao = SubGrupoDescricao
            ._dm_data_despesa = DataDespesa
            ._dm_data_inclusao = DataInclusao
            ._dm_valor = Valor
            ._dm_observacao = Observacao
            ._dm_alteracao = Alteracao
            ._dm_fechado = Fechado
        End With
    End Sub

    Sub New(DespesaMensal As ClDespesaMensal)

        With Me

            ._dm_id = DespesaMensal._dm_id
            ._dm_empresaid = DespesaMensal._dm_empresaid
            ._dm_empresanome = DespesaMensal._dm_empresanome
            ._dm_gpid = DespesaMensal._dm_gpid
            ._dm_gpdescricao = DespesaMensal._dm_gpdescricao
            ._dm_sgpid = DespesaMensal._dm_sgpid
            ._dm_sgpdescricao = DespesaMensal._dm_sgpdescricao
            ._dm_data_despesa = DespesaMensal._dm_data_despesa
            ._dm_data_inclusao = DespesaMensal._dm_data_inclusao
            ._dm_valor = DespesaMensal._dm_valor
            ._dm_observacao = DespesaMensal._dm_observacao
            ._dm_alteracao = DespesaMensal._dm_alteracao
            ._dm_fechado = DespesaMensal._dm_fechado
        End With
    End Sub

    Sub setaValores(DespesaMensal As ClDespesaMensal)

        With Me

            ._dm_id = DespesaMensal._dm_id
            ._dm_empresaid = DespesaMensal._dm_empresaid
            ._dm_empresanome = DespesaMensal._dm_empresanome
            ._dm_gpid = DespesaMensal._dm_gpid
            ._dm_gpdescricao = DespesaMensal._dm_gpdescricao
            ._dm_sgpid = DespesaMensal._dm_sgpid
            ._dm_sgpdescricao = DespesaMensal._dm_sgpdescricao
            ._dm_data_despesa = DespesaMensal._dm_data_despesa
            ._dm_data_inclusao = DespesaMensal._dm_data_inclusao
            ._dm_valor = DespesaMensal._dm_valor
            ._dm_observacao = DespesaMensal._dm_observacao
            ._dm_alteracao = DespesaMensal._dm_alteracao
            ._dm_fechado = DespesaMensal._dm_fechado
        End With
    End Sub

    Sub zeraValores()

        With Me

            ._dm_id = 0
            ._dm_empresaid = 0
            ._dm_empresanome = ""
            ._dm_gpid = 0
            ._dm_gpdescricao = ""
            ._dm_sgpid = 0
            ._dm_sgpdescricao = ""
            ._dm_data_despesa = Nothing
            ._dm_data_inclusao = Nothing
            ._dm_valor = 0
            ._dm_observacao = ""
            ._dm_alteracao = False
            ._dm_fechado = False
        End With
    End Sub

#Region "   Get e Set"

    Public Property dm_id() As Int64
        Get
            Return Me._dm_id
        End Get
        Set(value As Int64)
            Me._dm_id = value
        End Set
    End Property

    Public Property dm_empresaid() As Int64
        Get
            Return Me._dm_empresaid
        End Get
        Set(value As Int64)
            Me._dm_empresaid = value
        End Set
    End Property

    Public Property dm_empresanome() As String
        Get
            Return Me._dm_empresanome
        End Get
        Set(value As String)
            Me._dm_empresanome = value
        End Set
    End Property

    Public Property dm_gpid() As Int64
        Get
            Return Me._dm_gpid
        End Get
        Set(value As Int64)
            Me._dm_gpid = value
        End Set
    End Property

    Public Property dm_gpdescricao() As String
        Get
            Return Me._dm_gpdescricao
        End Get
        Set(value As String)
            Me._dm_gpdescricao = value
        End Set
    End Property

    Public Property dm_sgpid() As Int64
        Get
            Return Me._dm_sgpid
        End Get
        Set(value As Int64)
            Me._dm_sgpid = value
        End Set
    End Property

    Public Property dm_sgpdescricao() As String
        Get
            Return Me._dm_sgpdescricao
        End Get
        Set(value As String)
            Me._dm_sgpdescricao = value
        End Set
    End Property

    Public Property dm_data_despesa() As Date
        Get
            Return Me._dm_data_despesa
        End Get
        Set(value As Date)
            Me._dm_data_despesa = value
        End Set
    End Property

    Public Property dm_data_inclusao() As Date
        Get
            Return Me._dm_data_inclusao
        End Get
        Set(value As Date)
            Me._dm_data_inclusao = value
        End Set
    End Property

    Public Property dm_valor() As Double
        Get
            Return Me._dm_valor
        End Get
        Set(value As Double)
            Me._dm_valor = value
        End Set
    End Property

    Public Property dm_observacao() As String
        Get
            Return Me._dm_observacao
        End Get
        Set(value As String)
            Me._dm_observacao = value
        End Set
    End Property

    Public Property dm_alteracao() As Boolean
        Get
            Return Me._dm_alteracao
        End Get
        Set(value As Boolean)
            Me._dm_alteracao = value
        End Set
    End Property

    Public Property dm_fechado() As Boolean
        Get
            Return Me._dm_fechado
        End Get
        Set(value As Boolean)
            Me._dm_fechado = value
        End Set
    End Property
#End Region

End Class
