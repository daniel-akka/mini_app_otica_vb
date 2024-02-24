Public Class FrmTipoPagAReceberResp

    Public TipoPagamento As String = "DN"
    Dim _funcoes As New ClFuncoes
    Private Sub FrmTipoPagAReceberResp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboFormaPagamento.SelectedIndex = _funcoes.trazIndexComboBox(TipoPagamento, 3, cboFormaPagamento)
    End Sub

    Private Sub FrmTipoPagAReceberResp_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F7
                TipoPagamento = Trim(cboFormaPagamento.SelectedItem.ToString.Substring(0, 3))
                Me.Close()
        End Select
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        TipoPagamento = Trim(cboFormaPagamento.SelectedItem.ToString.Substring(0, 3))
        Me.Close()
    End Sub

End Class