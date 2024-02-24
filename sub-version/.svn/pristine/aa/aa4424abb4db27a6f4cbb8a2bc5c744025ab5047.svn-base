Public Class ClMarca
    Inherits ClMarcaDAO

    Public Property idMarca As Integer
    Public Property descricao As String
    Public Property padrao As Boolean

    Sub New(Optional ByVal vId As Integer = 0, Optional ByVal vDescricao As String = "", Optional ByVal vPadrao As Boolean = False)
        Me.idMarca = vId : Me.descricao = vDescricao : Me.padrao = vPadrao
    End Sub

    Sub New(ByVal vMarca As ClMarca)

        If Not IsNothing(vMarca) Then 'Verifica se não está vazio o objeto:

            With Me
                .idMarca = vMarca.idMarca
                .descricao = vMarca.descricao
                .padrao = vMarca.padrao
            End With
        End If

    End Sub

    Sub ZeraValores()

        With Me
            .idMarca = 0
            .descricao = ""
            .padrao = False
        End With
    End Sub

    Sub SetaMarca(ByVal vMarca As ClMarca)

        If Not IsNothing(vMarca) Then 'Verifica se não está vazio o objeto:

            With Me
                .idMarca = vMarca.idMarca
                .descricao = vMarca.descricao
                .padrao = vMarca.padrao
            End With
        End If
    End Sub

End Class
