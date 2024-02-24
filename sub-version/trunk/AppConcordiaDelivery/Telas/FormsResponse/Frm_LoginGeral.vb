Public Class Frm_LoginGeral

    Public _loginOK As Boolean = False
   
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If txt_senha.Text.Equals(".Geral.7") Then _loginOK = True
        txt_senha.Text = "" : Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        _loginOK = False
        Me.Close()
    End Sub

    Private Sub Frm_LogGeral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _loginOK = False
    End Sub

    Private Sub Frm_LogGeral_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

End Class
