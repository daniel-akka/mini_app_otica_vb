Public Class ClSubGrupoDespMensalImpr

    Private _sgp_id As String, _sgp_gpid As String, _sgp_gpdescricao As String, _sgp_descricao As String
    Private _sgp_valorpadrao As String

    Sub New(Optional ByVal Id As String = "", Optional ByVal GrupoId As String = "", Optional ByVal Descricao As String = "", _
            Optional ByVal GrupoDescricao As String = "", Optional ByVal ValorPadrao As String = "")

        With Me

            ._sgp_id = Id
            ._sgp_gpid = GrupoId
            ._sgp_descricao = Descricao
            ._sgp_gpdescricao = GrupoDescricao
            ._sgp_valorpadrao = ValorPadrao
        End With
    End Sub

    Sub New(SubGrupo As ClSubGrupoDespMensalImpr)

        With Me

            ._sgp_id = SubGrupo._sgp_id
            ._sgp_gpid = SubGrupo._sgp_gpid
            ._sgp_descricao = SubGrupo._sgp_descricao
            ._sgp_gpdescricao = SubGrupo._sgp_gpdescricao
            ._sgp_valorpadrao = SubGrupo._sgp_valorpadrao
        End With
    End Sub

    Sub setaValores(SubGrupo As ClSubGrupoDespMensalImpr)

        With Me

            ._sgp_id = SubGrupo._sgp_id
            ._sgp_gpid = SubGrupo._sgp_gpid
            ._sgp_descricao = SubGrupo._sgp_descricao
            ._sgp_gpdescricao = SubGrupo._sgp_gpdescricao
            ._sgp_valorpadrao = SubGrupo._sgp_valorpadrao
        End With
    End Sub

    Sub zeraValores()
        Me._sgp_id = "" : Me._sgp_gpid = "" : Me._sgp_descricao = "" : Me._sgp_gpdescricao = ""
        Me._sgp_valorpadrao = ""
    End Sub

#Region "   Get e Set"

    Public Property sgp_id() As String
        Get
            Return Me._sgp_id
        End Get
        Set(value As String)
            Me._sgp_id = value
        End Set
    End Property

    Public Property sgp_valorpadrao() As String
        Get
            Return Me._sgp_valorpadrao
        End Get
        Set(value As String)
            Me._sgp_valorpadrao = value
        End Set
    End Property

    Public Property sgp_gpid() As String
        Get
            Return Me._sgp_gpid
        End Get
        Set(value As String)
            Me._sgp_gpid = value
        End Set
    End Property

    Public Property sgp_descricao() As String
        Get
            Return Me._sgp_descricao
        End Get
        Set(value As String)
            Me._sgp_descricao = value
        End Set
    End Property

    Public Property sgp_gpdescricao() As String
        Get
            Return Me._sgp_gpdescricao
        End Get
        Set(value As String)
            Me._sgp_gpdescricao = value
        End Set
    End Property
#End Region

End Class
