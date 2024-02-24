Public Class FrmSenhaPadrao

    Public configuracao As ClConfiguracoes
    Public liberar As Boolean = False

    Private Sub FrmSenhaPadrao_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                Me.Close()
        End Select
    End Sub

    Private Sub FrmSenhaPadrao_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If configuracao.tSenhaPadrao.Equals(Me.mskSenhaPadrao.Text) Then
            configuracao.liberar = True
        End If
    End Sub

End Class