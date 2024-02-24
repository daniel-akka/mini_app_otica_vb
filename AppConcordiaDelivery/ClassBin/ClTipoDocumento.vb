Public Class ClTipoDocumento

    Public Property td_id As Integer
    Public Property td_descricao As String
    Public Property td_tela As String

    Sub New(Optional ByVal Id As Integer = 0, Optional ByVal Descricao As String = "", Optional ByVal Tela As String = "APAGAR")

        With Me
            .td_id = Id
            .td_descricao = Descricao
            .td_tela = Tela
        End With
    End Sub

    Sub zeraValores()

        With Me
            .td_id = 0
            .td_descricao = ""
            .td_tela = ""
        End With
    End Sub

    Sub setaValores(TipoDoc As ClTipoDocumento)

        With Me
            .td_id = TipoDoc.td_id
            .td_descricao = TipoDoc.td_descricao
            .td_tela = TipoDoc.td_tela
        End With
    End Sub

End Class
