Public Class FrmMostraProdutoVenda

    Public ListaProdutosVenda As New List(Of ClProdutoUsadoVenda)

    Private Sub FrmMostraProdutoVenda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        preencheProdutosVenda(ListaProdutosVenda)
        dtgProdutoUsadoPesquisa.Focus()
    End Sub

    Private Sub FrmMostraProdutoVenda_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Sub preencheProdutosVenda(ByVal produtosVendaCli As List(Of ClProdutoUsadoVenda))

        For Each pvc As ClProdutoUsadoVenda In produtosVendaCli
            dtgProdutoUsadoPesquisa.Rows.Add(pvc.puvnomeproduto, pvc.puvqtdeproduto.ToString("0.00"))
        Next
    End Sub

    Private Sub pbsair_Click(sender As Object, e As EventArgs) Handles pbsair.Click
        Me.Close()
    End Sub

    Private Sub pbsair_MouseEnter(sender As Object, e As EventArgs) Handles pbsair.MouseEnter
        pbsair.BackgroundImage = AppOtica.My.Resources.Resources.exit_icon2
    End Sub

    Private Sub pbsair_MouseLeave(sender As Object, e As EventArgs) Handles pbsair.MouseLeave
        pbsair.BackgroundImage = AppOtica.My.Resources.Resources.exit_vermelho
    End Sub
End Class