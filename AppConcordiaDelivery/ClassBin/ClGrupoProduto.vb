Public Class ClGrupoProduto
    Inherits ClGrupoProdutoDAO

    Public Property idGrupo As Integer
    Public Property descricao As String
    Public Property padrao As Boolean

    Sub New(Optional ByVal vId As Integer = 0, Optional ByVal vDescricao As String = "", Optional ByVal vPadrao As Boolean = False)
        Me.idGrupo = vId : Me.descricao = vDescricao : Me.padrao = vPadrao
    End Sub

    Sub New(ByVal vGrupo As ClGrupoProduto)

        If Not IsNothing(vGrupo) Then 'Verifica se não está vazio o objeto:

            With Me
                .idGrupo = vGrupo.idGrupo
                .descricao = vGrupo.descricao
                .padrao = vGrupo.padrao
            End With
        Else
            Me.ZeraValores()
        End If

    End Sub

    Sub ZeraValores()

        With Me
            .idGrupo = 0
            .descricao = ""
            .padrao = False
        End With
    End Sub

    Sub SetaGrupo(ByVal vGrupo As ClGrupoProduto)

        If Not IsNothing(vGrupo) Then 'Verifica se não está vazio o objeto:

            With Me
                .idGrupo = vGrupo.idGrupo
                .descricao = vGrupo.descricao
                .padrao = vGrupo.padrao
            End With
        Else
            Me.ZeraValores()
        End If
    End Sub

End Class
