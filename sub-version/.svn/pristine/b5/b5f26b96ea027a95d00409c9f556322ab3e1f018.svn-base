Public Class ClDespesaMensalmpressao

    Private _dm_id As String, _dm_empresaid As String, _dm_empresanome As String, _dm_gpid As String, _dm_gpdescricao As String
    Private _dm_sgpid As String, _dm_sgpdescricao As String, _dm_data_despesa As String, _dm_data_inclusao As String
    Private _dm_valor As String, _dm_observacao As String, _dm_alteracao As String, _dm_fechado As String

    Sub New(Optional ByVal Id As String = "", Optional ByVal EmpresaId As String = "", Optional ByVal EmpresaNome As String = "", _
            Optional ByVal GrupoId As String = "", Optional ByVal GrupoDescricao As String = "", Optional ByVal SubGrupoID As String = "", _
            Optional ByVal SubGrupoDescricao As String = "", Optional ByVal DataDespesa As String = "", Optional ByVal DataInclusao As String = "", _
            Optional ByVal Valor As String = "", Optional ByVal Observacao As String = "", Optional ByVal Alteracao As String = "", _
            Optional ByVal Fechado As String = "")

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

    Sub New(DespesaMensal As ClDespesaMensalmpressao)

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

            ._dm_id = DespesaMensal.dm_id
            .dm_empresaid = DespesaMensal.dm_empresaid
            .dm_empresanome = DespesaMensal.dm_empresanome
            .dm_gpid = DespesaMensal.dm_gpid
            .dm_gpdescricao = DespesaMensal.dm_gpdescricao
            .dm_sgpid = DespesaMensal.dm_sgpid
            .dm_sgpdescricao = DespesaMensal.dm_sgpdescricao
            .dm_data_despesa = DespesaMensal.dm_data_despesa.ToShortDateString
            .dm_data_inclusao = DespesaMensal.dm_data_inclusao
            .dm_valor = DespesaMensal.dm_valor.ToString("#,##0.00")
            .dm_observacao = DespesaMensal.dm_observacao
            .dm_alteracao = DespesaMensal.dm_alteracao
            ._dm_fechado = DespesaMensal.dm_fechado
        End With
    End Sub

    Sub zeraValores()

        With Me

            ._dm_id = ""
            ._dm_empresaid = ""
            ._dm_empresanome = ""
            ._dm_gpid = ""
            ._dm_gpdescricao = ""
            ._dm_sgpid = ""
            ._dm_sgpdescricao = ""
            ._dm_data_despesa = ""
            ._dm_data_inclusao = ""
            ._dm_valor = ""
            ._dm_observacao = ""
            ._dm_alteracao = ""
            ._dm_fechado = ""
        End With
    End Sub

#Region "   Get e Set"

    Public Property dm_id() As String
        Get
            Return Me._dm_id
        End Get
        Set(value As String)
            Me._dm_id = value
        End Set
    End Property

    Public Property dm_empresaid() As String
        Get
            Return Me._dm_empresaid
        End Get
        Set(value As String)
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

    Public Property dm_gpid() As String
        Get
            Return Me._dm_gpid
        End Get
        Set(value As String)
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

    Public Property dm_sgpid() As String
        Get
            Return Me._dm_sgpid
        End Get
        Set(value As String)
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

    Public Property dm_data_despesa() As String
        Get
            Return Me._dm_data_despesa
        End Get
        Set(value As String)
            Me._dm_data_despesa = value
        End Set
    End Property

    Public Property dm_data_inclusao() As String
        Get
            Return Me._dm_data_inclusao
        End Get
        Set(value As String)
            Me._dm_data_inclusao = value
        End Set
    End Property

    Public Property dm_valor() As String
        Get
            Return Me._dm_valor
        End Get
        Set(value As String)
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

    Public Property dm_alteracao() As String
        Get
            Return Me._dm_alteracao
        End Get
        Set(value As String)
            Me._dm_alteracao = value
        End Set
    End Property

    Public Property dm_fechado() As String
        Get
            Return Me._dm_fechado
        End Get
        Set(value As String)
            Me._dm_fechado = value
        End Set
    End Property
#End Region

End Class
