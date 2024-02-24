Public Class ClSubGrupoDespMensal

    Private _sgp_id As Int64, _sgp_gpid As Int64, _sgp_gpdescricao As String, _sgp_descricao As String
    Private _sgp_valorpadrao As Double

    Sub New(Optional ByVal Id As Int64 = 0, Optional ByVal GrupoId As Int64 = 0, Optional ByVal Descricao As String = "", _
            Optional ByVal GrupoDescricao As String = "", Optional ByVal ValorPadrao As Double = 0)

        With Me

            ._sgp_id = Id
            ._sgp_gpid = GrupoId
            ._sgp_descricao = Descricao
            ._sgp_gpdescricao = GrupoDescricao
            ._sgp_valorpadrao = ValorPadrao
        End With
    End Sub

    Sub New(SubGrupo As ClSubGrupoDespMensal)

        With Me

            ._sgp_id = SubGrupo._sgp_id
            ._sgp_gpid = SubGrupo._sgp_gpid
            ._sgp_descricao = SubGrupo._sgp_descricao
            ._sgp_gpdescricao = SubGrupo._sgp_gpdescricao
            ._sgp_valorpadrao = SubGrupo._sgp_valorpadrao
        End With
    End Sub

    Sub setaValores(SubGrupo As ClSubGrupoDespMensal)

        With Me

            ._sgp_id = SubGrupo._sgp_id
            ._sgp_gpid = SubGrupo._sgp_gpid
            ._sgp_descricao = SubGrupo._sgp_descricao
            ._sgp_gpdescricao = SubGrupo._sgp_gpdescricao
            ._sgp_valorpadrao = SubGrupo._sgp_valorpadrao
        End With
    End Sub

    Sub zeraValores()
        Me._sgp_id = 0 : Me._sgp_gpid = 0 : Me._sgp_descricao = "" : Me._sgp_gpdescricao = ""
        Me._sgp_valorpadrao = 0
    End Sub

#Region "   Get e Set"

    Public Property sgp_id() As Int64
        Get
            Return Me._sgp_id
        End Get
        Set(value As Int64)
            Me._sgp_id = value
        End Set
    End Property

    Public Property sgp_valorpadrao() As Double
        Get
            Return Me._sgp_valorpadrao
        End Get
        Set(value As Double)
            Me._sgp_valorpadrao = value
        End Set
    End Property

    Public Property sgp_gpid() As Int64
        Get
            Return Me._sgp_gpid
        End Get
        Set(value As Int64)
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
