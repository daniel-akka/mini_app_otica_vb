Public Class ClGrupoDespMensal

    Private _gp_id As Int64, _gp_descricao As String

    Sub New(Optional ByVal Id As Int64 = 0, Optional ByVal Descricao As String = "")

        With Me

            ._gp_id = Id
            ._gp_descricao = Descricao
        End With
    End Sub

    Sub New(GrupoDesp As ClGrupoDespMensal)

        With Me

            ._gp_id = GrupoDesp._gp_id
            ._gp_descricao = GrupoDesp._gp_descricao
        End With
    End Sub

    Sub setaValores(GrupoDesp As ClGrupoDespMensal)

        With Me

            ._gp_id = GrupoDesp._gp_id
            ._gp_descricao = GrupoDesp._gp_descricao
        End With
    End Sub

    Sub zeraValores()
        Me._gp_id = 0 : Me._gp_descricao = ""
    End Sub

#Region "   Get e Set"

    Public Property gp_id() As Int64
        Get
            Return Me._gp_id
        End Get
        Set(value As Int64)
            Me._gp_id = value
        End Set
    End Property

    Public Property gp_descricao() As String
        Get
            Return Me._gp_descricao
        End Get
        Set(value As String)
            Me._gp_descricao = value
        End Set
    End Property

#End Region
End Class
