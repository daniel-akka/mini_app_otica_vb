Imports Npgsql
Public Class FrmBaixaAReceber

    Public AReceberTotal As New ClAReceberTotal
    Dim _AReceberTotalDAO As New ClAReceberTotalDAO
    Dim _AReceberParcial As New ClAReceberParcial
    Dim _AReceberParcialDAO As New ClAReceberParcialDAO
    Dim _Cliente As New ClCliente
    Dim _ClienteDAO As New ClClienteDAO
    Dim _AbrirFecharDAO As New ClAbrirFecharDAO
    Public Caixa As New ClAbrirFecharCaixa(0, Date.Now, "", False, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    Dim _funcoes As New ClFuncoes

    Dim EhBaixaParcial As Boolean = False

    Private Sub FrmBaixaAReceber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _AReceberTotalDAO.TrazContaAReceberDaLista(AReceberTotal, MdlConexaoBD.ListaAReceberTotal)
        PreencheCamposAReceber()
        txtPagoDN.Focus() : txtPagoDN.SelectAll()
    End Sub

    Sub PreencheCamposAReceber()

        Dim mDiasAtraso As Int16 = 0
        txtNomeCliente.Text = AReceberTotal.art_clientenome
        txtValor.Text = AReceberTotal.art_valor.ToString("#,##0.00")
        txtTotAcrescimo.Text = AReceberTotal.art_acrescimo.ToString("#,##0.00")
        txtTotDesconto.Text = AReceberTotal.art_desconto.ToString("#,##0.00")
        txtTotGeral.Text = ((AReceberTotal.art_valor + AReceberTotal.art_acrescimo) - AReceberTotal.art_desconto).ToString("#,##0.00")

        dtVencimento.Text = AReceberTotal.art_datavencimento.ToShortDateString
        Try
            mDiasAtraso = (Date.Now.AddDays(45) - AReceberTotal.art_datavencimento).Days
        Catch ex As Exception
        End Try
        If mDiasAtraso > 0 Then txtAtraso.Text = mDiasAtraso & " Dias"

        txt_documento.Text = AReceberTotal.art_id.ToString.PadLeft(6, "0")
        txtValorRestante.Text = AReceberTotal.art_valorrestante.ToString("#,##0.00")

    End Sub

    Private Sub FrmBaixaAReceber_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub txtJuros_Leave(sender As Object, e As EventArgs) Handles txtAcrescimo.Leave

        If IsNumeric(txtAcrescimo.Text) Then

            txtAcrescimo.Text = CDbl(txtAcrescimo.Text).ToString("#,##0.00")
            txtTotGeral.Text = ((CDbl(txtValor.Text) + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
            txtValorRestante.Text = ((AReceberTotal.art_valorrestante + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
        Else
            txtAcrescimo.Text = "0,00"
        End If
    End Sub

    Private Sub txtDesconto_Leave(sender As Object, e As EventArgs) Handles txtDesconto.Leave

        If IsNumeric(txtDesconto.Text) Then

            txtDesconto.Text = CDbl(txtDesconto.Text).ToString("#,##0.00")
            txtTotGeral.Text = ((CDbl(txtValor.Text) + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
            txtValorRestante.Text = ((AReceberTotal.art_valorrestante + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
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

    Private Sub FrmBaixaAReceber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
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

        If verificaAReceber() Then

            PreencheValoresContaAReceber()
            If EhBaixaParcial Then

                SalvandoContaAReceberParcial()
                _AReceberTotalDAO.TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
                _AReceberParcialDAO.TrazListAReceberParcial(MdlConexaoBD.mdlListAReceberParcial, MdlConexaoBD.conectionPadrao)
                Me.Close()
            Else

                SalvandoContaAReceberTotal()
                _AReceberTotalDAO.TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
                _AReceberParcialDAO.TrazListAReceberParcial(MdlConexaoBD.mdlListAReceberParcial, MdlConexaoBD.conectionPadrao)
                Me.Close()
            End If

        End If
    End Sub

    Sub SalvandoContaAReceberTotal()

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction

            _AReceberTotalDAO.altAReceberBaixaIndividual(AReceberTotal, connection, transacao)
            transacao.Commit()

            MsgBox("Conta A Receber Baixada com Sucesso!", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub SalvandoContaAReceberParcial()

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

             Dim transacao As NpgsqlTransaction = connection.BeginTransaction

            _AReceberTotalDAO.baixarAReceberParcial(AReceberTotal, _AReceberParcial, connection, transacao)
            transacao.Commit()

            MsgBox("Baixa Parcial efetuada com Sucesso!", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub PreencheValoresContaAReceber()

        If EhBaixaParcial Then

            AReceberTotal.art_empresaid = MdlConexaoBD.mdlEmpresa.empid
            AReceberTotal.art_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            AReceberTotal.art_valorpago += CDbl(txt_valorPago.Text)
            AReceberTotal.art_valorrestante = (CDbl(txtValorRestante.Text) - CDbl(txt_valorPago.Text))
            AReceberTotal.art_acrescimo += CDbl(txtAcrescimo.Text)
            AReceberTotal.art_desconto += CDbl(txtDesconto.Text)
            AReceberTotal.art_pagodinheiro += CDbl(txtPagoDN.Text)
            AReceberTotal.art_pagocartaocred += CDbl(txtPagoCTC.Text)
            AReceberTotal.art_pagocartaodeb += CDbl(txtPagoCTD.Text)
            AReceberTotal.art_pagopix += CDbl(txtPagoPIX.Text)
            AReceberTotal.art_pagotransferencia += CDbl(txtPagoTRA.Text)

            With _AReceberParcial

                .arp_artid = AReceberTotal.art_id
                .arp_idcaixa = Caixa.Af_id1
                .arp_datapagamento = dtPagamento.Value
                .arp_acrescimo = CDbl(txtAcrescimo.Text)
                .arp_desconto = CDbl(txtDesconto.Text)
                .arp_pagodinheiro = CDbl(txtPagoDN.Text)
                .arp_pagocartaocred = CDbl(txtPagoCTC.Text)
                .arp_pagocartaodeb = CDbl(txtPagoCTD.Text)
                .arp_pagopix = CDbl(txtPagoPIX.Text)
                .arp_pagotransferencia = CDbl(txtPagoTRA.Text)
                .arp_valor = .arp_pagodinheiro + .arp_pagocartaocred + .arp_pagocartaodeb + .arp_pagopix + .arp_pagotransferencia
                .arp_valortotal = (.arp_valor + .arp_acrescimo) - .arp_desconto

            End With

        Else

            AReceberTotal.art_empresaid = MdlConexaoBD.mdlEmpresa.empid
            AReceberTotal.art_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            AReceberTotal.art_valorpago += CDbl(txt_valorPago.Text)
            AReceberTotal.art_valorrestante = (CDbl(txtValorRestante.Text) - CDbl(txt_valorPago.Text))
            AReceberTotal.art_acrescimo += CDbl(txtAcrescimo.Text)
            AReceberTotal.art_desconto += CDbl(txtDesconto.Text)
            AReceberTotal.art_pagodinheiro += CDbl(txtPagoDN.Text)
            AReceberTotal.art_pagocartaocred += CDbl(txtPagoCTC.Text)
            AReceberTotal.art_pagocartaodeb += CDbl(txtPagoCTD.Text)
            AReceberTotal.art_pagopix += CDbl(txtPagoPIX.Text)
            AReceberTotal.art_pagotransferencia += CDbl(txtPagoTRA.Text)

        End If

    End Sub

    Function verificaAReceber() As Boolean

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