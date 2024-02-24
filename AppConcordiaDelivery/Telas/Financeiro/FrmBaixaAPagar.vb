Imports Npgsql
Public Class FrmBaixaAPagar

    Public APagarTotal As New ClAPagarTotal
    Dim _APagarTotalDAO As New ClAPagarTotalDAO
    Dim _APagarParcial As New ClAPagarParcial
    Dim _APagarParcialDAO As New ClAPagarParcialDAO
    Dim _Fornecedor As New ClFornecedor
    Dim _FornecedorDAO As New ClFornecedorDAO
    Dim _AbrirFecharDAO As New ClAbrirFecharDAO
    Public Caixa As New ClAbrirFecharCaixa(0, Date.Now, "", False, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    Dim _funcoes As New ClFuncoes

    Dim EhBaixaParcial As Boolean = False

    Private Sub FrmBaixaAPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _APagarTotalDAO.TrazContaAPagarDaLista(APagarTotal, MdlConexaoBD.ListaAPagarTotal)
        PreencheCamposAPagar()
        txtPagoDN.Focus() : txtPagoDN.SelectAll()
    End Sub

    Sub PreencheCamposAPagar()

        Dim mDiasAtraso As Int16 = 0
        txtNomeCliente.Text = APagarTotal.apt_portadornome
        txtValor.Text = APagarTotal.apt_valor.ToString("#,##0.00")
        txtTotAcrescimo.Text = APagarTotal.apt_acrescimo.ToString("#,##0.00")
        txtTotDesconto.Text = APagarTotal.apt_desconto.ToString("#,##0.00")
        txtTotGeral.Text = ((APagarTotal.apt_valor + APagarTotal.apt_acrescimo) - APagarTotal.apt_desconto).ToString("#,##0.00")

        dtVencimento.Text = APagarTotal.apt_datavencimento.ToShortDateString
        Try
            mDiasAtraso = (Date.Now.AddDays(45) - APagarTotal.apt_datavencimento).Days
        Catch ex As Exception
        End Try
        If mDiasAtraso > 0 Then txtAtraso.Text = mDiasAtraso & " Dias"

        txt_documento.Text = APagarTotal.apt_id.ToString.PadLeft(6, "0")
        txtValorRestante.Text = APagarTotal.apt_valorrestante.ToString("#,##0.00")

    End Sub

    Private Sub FrmBaixaAPagar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub txtJuros_Leave(sender As Object, e As EventArgs) Handles txtAcrescimo.Leave

        If IsNumeric(txtAcrescimo.Text) Then

            txtAcrescimo.Text = CDbl(txtAcrescimo.Text).ToString("#,##0.00")
            txtTotGeral.Text = ((CDbl(txtValor.Text) + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
            txtValorRestante.Text = ((APagarTotal.apt_valorrestante + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
        Else
            txtAcrescimo.Text = "0,00"
        End If
    End Sub

    Private Sub txtDesconto_Leave(sender As Object, e As EventArgs) Handles txtDesconto.Leave

        If IsNumeric(txtDesconto.Text) Then

            txtDesconto.Text = CDbl(txtDesconto.Text).ToString("#,##0.00")
            txtTotGeral.Text = ((CDbl(txtValor.Text) + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
            txtValorRestante.Text = ((APagarTotal.apt_valorrestante + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
        Else
            txtDesconto.Text = "0,00"
        End If
    End Sub

    Private Sub txtJuros_Click(sender As Object, e As EventArgs) Handles txtAcrescimo.Click
        txtAcrescimo.SelectAll()
    End Sub

    Private Sub txtDesconto_Click(sender As Object, e As EventArgs) Handles txtDesconto.Click
        txtDesconto.SelectAll()
    End Sub

    Private Sub txtJuros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAcrescimo.KeyPress, txtDesconto.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub FrmBaixaAPagar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtValorRestante_TextChanged(sender As Object, e As EventArgs) Handles txtValorRestante.TextChanged

        If CDbl(txt_valorPago.Text) > CDbl(txtValorRestante.Text) Then
            txtPagoDN.Text = "0,00"
            txtPagoCTC.Text = "0,00"
            txtPagoCTD.Text = "0,00"
            txtPagoPIX.Text = "0,00"
            txtPagoTRA.Text = "0,00"
        End If
    End Sub

    Private Sub txtPago_TextChanged(sender As Object, e As EventArgs) Handles txtPagoTRA.TextChanged, txtPagoPIX.TextChanged, txtPagoDN.TextChanged, txtPagoCTD.TextChanged, txtPagoCTC.TextChanged

        If IsNumeric(txtPagoTRA.Text) AndAlso IsNumeric(txtPagoPIX.Text) AndAlso IsNumeric(txtPagoDN.Text) _
            AndAlso IsNumeric(txtPagoCTD.Text) AndAlso IsNumeric(txtPagoCTC.Text) Then

            txt_valorPago.Text = (CDbl(txtPagoDN.Text) + CDbl(txtPagoCTC.Text) + CDbl(txtPagoCTD.Text) + CDbl(txtPagoPIX.Text) + CDbl(txtPagoTRA.Text)).ToString("#,##0.00")
        End If

    End Sub

    Private Sub txtPagoDN_Leave(sender As Object, e As EventArgs) Handles txtPagoDN.Leave
        If IsNumeric(txtPagoDN.Text) Then

            txtPagoDN.Text = CDbl(txtPagoDN.Text).ToString("#,##0.00")
            If CDbl(txt_valorPago.Text) > CDbl(txtValorRestante.Text) Then
                MsgBox("Valor Pago não pode ser Maior que o Valor Restante!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                txtPagoDN.Focus() : txtPagoDN.SelectAll()
                Return
            End If
        Else
            txtPagoDN.Text = "0,00"
        End If
    End Sub

    Private Sub txtPagoCTC_Leave(sender As Object, e As EventArgs) Handles txtPagoCTC.Leave
        If IsNumeric(txtPagoCTC.Text) Then

            txtPagoCTC.Text = CDbl(txtPagoCTC.Text).ToString("#,##0.00")
            If CDbl(txt_valorPago.Text) > CDbl(txtValorRestante.Text) Then
                MsgBox("Valor Pago não pode ser Maior que o Valor Restante!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                txtPagoCTC.Focus() : txtPagoCTC.SelectAll()
                Return
            End If
        Else
            txtPagoCTC.Text = "0,00"
        End If
    End Sub


    Private Sub txtPagoCTD_Leave(sender As Object, e As EventArgs) Handles txtPagoCTD.Leave
        If IsNumeric(txtPagoCTD.Text) Then

            txtPagoCTD.Text = CDbl(txtPagoCTD.Text).ToString("#,##0.00")
            If CDbl(txt_valorPago.Text) > CDbl(txtValorRestante.Text) Then
                MsgBox("Valor Pago não pode ser Maior que o Valor Restante!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                txtPagoCTD.Focus() : txtPagoCTD.SelectAll()
                Return
            End If
        Else
            txtPagoCTD.Text = "0,00"
        End If
    End Sub


    Private Sub txtPagoPIX_Leave(sender As Object, e As EventArgs) Handles txtPagoPIX.Leave
        If IsNumeric(txtPagoDN.Text) Then

            txtPagoPIX.Text = CDbl(txtPagoPIX.Text).ToString("#,##0.00")
            If CDbl(txt_valorPago.Text) > CDbl(txtValorRestante.Text) Then
                MsgBox("Valor Pago não pode ser Maior que o Valor Restante!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                txtPagoPIX.Focus() : txtPagoPIX.SelectAll()
                Return
            End If
        Else
            txtPagoPIX.Text = "0,00"
        End If
    End Sub

    Private Sub txtPagoTRA_Leave(sender As Object, e As EventArgs) Handles txtPagoTRA.Leave
        If IsNumeric(txtPagoTRA.Text) Then

            txtPagoTRA.Text = CDbl(txtPagoTRA.Text).ToString("#,##0.00")
            If CDbl(txt_valorPago.Text) > CDbl(txtValorRestante.Text) Then
                MsgBox("Valor Pago não pode ser Maior que o Valor Restante!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                txtPagoTRA.Focus() : txtPagoTRA.SelectAll()
                Return
            End If
        Else
            txtPagoTRA.Text = "0,00"
        End If
    End Sub

    Private Sub txtPagoCTC_Click(sender As Object, e As EventArgs) Handles txtPagoCTC.Click
        txtPagoCTC.SelectAll()
    End Sub

    Private Sub txtPagoCTD_Click(sender As Object, e As EventArgs) Handles txtPagoCTD.Click
        txtPagoCTD.SelectAll()
    End Sub

    Private Sub txtPagoPIX_Click(sender As Object, e As EventArgs) Handles txtPagoPIX.Click
        txtPagoPIX.SelectAll()
    End Sub

    Private Sub txtPagoTRA_Click(sender As Object, e As EventArgs) Handles txtPagoTRA.Click
        txtPagoTRA.SelectAll()
    End Sub

    Private Sub txtPagoDN_Click(sender As Object, e As EventArgs) Handles txtPagoDN.Click
        txtPagoDN.SelectAll()
    End Sub

    Private Sub btn_baixar_Click(sender As Object, e As EventArgs) Handles btn_baixar.Click

        If verificaAPagar() Then

            PreencheValoresContaAPagar()
            If EhBaixaParcial Then

                SalvandoContaAPagarParcial()
                _APagarTotalDAO.TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
                _APagarParcialDAO.TrazListAPagarParcial(MdlConexaoBD.mdlListAPagarParcial, MdlConexaoBD.conectionPadrao)
                Me.Close()
            Else

                SalvandoContaAPagarTotal()
                _APagarTotalDAO.TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
                _APagarParcialDAO.TrazListAPagarParcial(MdlConexaoBD.mdlListAPagarParcial, MdlConexaoBD.conectionPadrao)
                Me.Close()
            End If

        End If
    End Sub

    Sub SalvandoContaAPagarTotal()

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction

            _APagarTotalDAO.altAPagarBaixaIndividual(APagarTotal, connection, transacao)
            transacao.Commit()

            MsgBox("Conta A PAGAR Baixada com Sucesso!", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub SalvandoContaAPagarParcial()

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction

            _APagarTotalDAO.baixarAPagarParcial(APagarTotal, _APagarParcial, connection, transacao)
            transacao.Commit()

            MsgBox("Baixa Parcial efetuada com Sucesso!", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub PreencheValoresContaAPagar()

        If EhBaixaParcial Then

            APagarTotal.apt_empresaid = MdlConexaoBD.mdlEmpresa.empid
            APagarTotal.apt_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            APagarTotal.apt_valorpago += CDbl(txt_valorPago.Text)
            APagarTotal.apt_valorrestante = (CDbl(txtValorRestante.Text) - CDbl(txt_valorPago.Text))
            APagarTotal.apt_acrescimo += CDbl(txtAcrescimo.Text)
            APagarTotal.apt_desconto += CDbl(txtDesconto.Text)
            APagarTotal.apt_pagodinheiro += CDbl(txtPagoDN.Text)
            APagarTotal.apt_pagocartaocred += CDbl(txtPagoCTC.Text)
            APagarTotal.apt_pagocartaodeb += CDbl(txtPagoCTD.Text)
            APagarTotal.apt_pagopix += CDbl(txtPagoPIX.Text)
            APagarTotal.apt_pagotransferencia += CDbl(txtPagoTRA.Text)

            With _APagarParcial

                .app_aptid = APagarTotal.apt_id
                .app_idcaixa = Caixa.Af_id1
                .app_datapagamento = dtPagamento.Value
                .app_acrescimo = CDbl(txtAcrescimo.Text)
                .app_desconto = CDbl(txtDesconto.Text)
                .app_pagodinheiro = CDbl(txtPagoDN.Text)
                .app_pagocartaocred = CDbl(txtPagoCTC.Text)
                .app_pagocartaodeb = CDbl(txtPagoCTD.Text)
                .app_pagopix = CDbl(txtPagoPIX.Text)
                .app_pagotransferencia = CDbl(txtPagoTRA.Text)
                .app_valor = .app_pagodinheiro + .app_pagocartaocred + .app_pagocartaodeb + .app_pagopix + .app_pagotransferencia
                .app_valortotal = (.app_valor + .app_acrescimo) - .app_desconto

            End With

        Else

            APagarTotal.apt_empresaid = MdlConexaoBD.mdlEmpresa.empid
            APagarTotal.apt_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            APagarTotal.apt_valorpago += CDbl(txt_valorPago.Text)
            APagarTotal.apt_valorrestante = (CDbl(txtValorRestante.Text) - CDbl(txt_valorPago.Text))
            APagarTotal.apt_acrescimo += CDbl(txtAcrescimo.Text)
            APagarTotal.apt_desconto += CDbl(txtDesconto.Text)
            APagarTotal.apt_pagodinheiro += CDbl(txtPagoDN.Text)
            APagarTotal.apt_pagocartaocred += CDbl(txtPagoCTC.Text)
            APagarTotal.apt_pagocartaodeb += CDbl(txtPagoCTD.Text)
            APagarTotal.apt_pagopix += CDbl(txtPagoPIX.Text)
            APagarTotal.apt_pagotransferencia += CDbl(txtPagoTRA.Text)

        End If

    End Sub

    Function verificaAPagar() As Boolean

        If CDbl(txt_valorPago.Text) <= 0 Then
            MsgBox("Faltou informar um Valor para PAGAR! :-(", MsgBoxStyle.Information, Application.CompanyName.ToUpper)
            txtPagoDN.Focus() : txtPagoDN.SelectAll()
            Return False
        End If

        If CDbl(txt_valorPago.Text) > CDbl(txtValorRestante.Text) Then
            MsgBox("O Valor Pago não deve ser Maior que o Valor Restante!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return False
        End If

        EhBaixaParcial = False
        If CDbl(txt_valorPago.Text) < CDbl(txtValorRestante.Text) Then
            EhBaixaParcial = True
        End If

        Return True
    End Function

End Class