Imports Npgsql
Public Class FrmCadAReceber

    Public operacao As String = "I"
    Public _AReceberTotal As New ClAReceberTotal
    Dim _AReceberTotalDAO As New ClAReceberTotalDAO
    Dim _AReceberParcial As New ClAReceberParcial
    Dim _ListAReceberParcial As New List(Of ClAReceberParcial)
    Dim _AReceberParcialDAO As New ClAReceberParcialDAO
    Dim _Cliente As New ClCliente
    Dim _ClienteDAO As New ClClienteDAO
    Dim _funcoes As New ClFuncoes

    Private Sub FrmCadAReceber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ConfiguraCamposParaOperacao()
        SetaCamposAReceber()

    End Sub

    Sub ConfiguraCamposParaOperacao()

        Select Case operacao
            Case "I" 'Inclusão

                mskDtPagamento.ReadOnly = True
                txtDesconto.ReadOnly = True
                txtAcrescimo.ReadOnly = True
                txtValorPago.ReadOnly = True
                mskDtPagamento.BackColor = Color.LightYellow
                txtDesconto.BackColor = Color.LightYellow
                txtAcrescimo.BackColor = Color.LightYellow
                txtValorPago.BackColor = Color.LightYellow
                cboTipoPagamento.SelectedIndex = -1
                cboTipoPagamento.Enabled = False

            Case "A" 'Alteração

                mskDtPagamento.ReadOnly = True
                txtDesconto.ReadOnly = True
                txtAcrescimo.ReadOnly = True
                txtValorPago.ReadOnly = True
                mskDtPagamento.BackColor = Color.LightYellow
                txtDesconto.BackColor = Color.LightYellow
                txtAcrescimo.BackColor = Color.LightYellow
                txtValorPago.BackColor = Color.LightYellow
                dtp_emissao.Enabled = False

                If Not _AReceberTotal.art_tela.Equals("ARECEBER") Then
                    txt_codPart.Enabled = False
                End If

                If _AReceberTotal.art_valorrestante < _AReceberTotal.art_valor Then
                    txtValorConta.ReadOnly = True
                End If

                If _AReceberTotal.art_valorpago > 0 Then
                    txtValorConta.ReadOnly = True
                End If


                cboTipoPagamento.SelectedIndex = -1
                cboTipoPagamento.Enabled = False

                PreencheAReceberParcial()

            Case "V" 'Visualização

                mskDtPagamento.ReadOnly = True
                txtDesconto.ReadOnly = True
                txtAcrescimo.ReadOnly = True
                txtValorPago.ReadOnly = True
                txt_historico.ReadOnly = True
                txtValorConta.ReadOnly = True
                txt_codPart.Enabled = False
                dtp_emissao.Enabled = False
                dtp_vencto.Enabled = False
                mskDtPagamento.BackColor = Color.LightYellow
                txtDesconto.BackColor = Color.LightYellow
                txtAcrescimo.BackColor = Color.LightYellow
                txtValorPago.BackColor = Color.LightYellow

                cboTipoPagamento.SelectedIndex = -1
                cboTipoPagamento.Enabled = False
                Btn_salvar.Enabled = False

                PreencheAReceberParcial()

        End Select

    End Sub

    Private Sub FrmCadAReceber_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmCadAReceber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

#Region "  TEXTO Busca Cliente"

    Private Sub txt_codPart_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_codPart.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            buscaCliente()
        End If

    End Sub

    Sub buscaCliente()

        lbl_mensagem.Text = ""
        _Cliente.ZeraValores()
        If IsNumeric(txt_codPart.Text) Then


            _Cliente.cid = CInt(txt_codPart.Text)
            _ClienteDAO.TrazClienteDaListaClientes(_Cliente, MdlConexaoBD.ListaClientes)

            'Aqui tenta chamar o Formulario de Busca do Fornecedor...
            Try

                If _Cliente.cnome.Equals("") Then

                    Dim frmResponse As New FrmClienteResp
                    frmResponse.ShowDialog()
                    _Cliente.SetaValores(frmResponse._cliente)
                    frmResponse = Nothing
                Else
                    txt_nomePart.Text = _Cliente.cnome.ToUpper
                End If

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        Else

            'Aqui tenta chamar o Formulario de Busca do Fornecedor...
            Try

                If _Cliente.cnome.Equals("") Then

                    Dim frmResponse As New FrmClienteResp
                    frmResponse.ShowDialog()
                    _Cliente.SetaValores(frmResponse._cliente)
                    frmResponse = Nothing
                Else
                    txt_nomePart.Text = _Cliente.cnome.ToUpper
                End If

                Me.txt_nomePart.Focus()
                Me.txt_nomePart.SelectAll()

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        End If

        If _Cliente.cid = 0 Then
            txt_codPart.Text = "" : txt_nomePart.Text = ""
            txt_codPart.Focus() : txt_codPart.SelectAll()
        Else
            txt_codPart.Text = _Cliente.cid
            txt_nomePart.Text = _Cliente.cnome
            Me.txt_nomePart.Focus()
            Me.txt_nomePart.SelectAll()
        End If

    End Sub

    Private Sub txt_codPart_Leave(sender As Object, e As EventArgs) Handles txt_codPart.Leave

        If IsNumeric(txt_codPart.Text) Then

            Dim mCliente As New ClCliente
            mCliente.cid = CInt(txt_codPart.Text)
            _ClienteDAO.TrazClienteDaListaClientes(mCliente, MdlConexaoBD.ListaClientes)
            If mCliente.cid < 1 Then

                _Cliente.ZeraValores()
                txt_codPart.Text = ""
                txt_nomePart.Text = ""
            Else

                _Cliente.SetaValores(mCliente)
                txt_codPart.Text = _Cliente.cid
                txt_nomePart.Text = _Cliente.cnome
            End If
        End If

    End Sub

    Private Sub txt_codPart_Click(sender As Object, e As EventArgs) Handles txt_codPart.Click
        txt_codPart.SelectAll()
    End Sub

#End Region


    Private Sub txt_valor_Leave(sender As Object, e As EventArgs) Handles txtValorConta.Leave

        lbl_mensagem.Text = ""
        If IsNumeric(txtValorConta.Text) Then 'Se for Número

            txtValorConta.Text = CDbl(txtValorConta.Text).ToString("#,##0.00")
            If _AReceberTotal.art_valorpago <= 0 Then
                txtValorRestante.Text = txtValorConta.Text
            End If

            If CDbl(txtValorConta.Text) <= 0 Then
                lbl_mensagem.Text = "Valor dever ser Maior do que 0"
            End If
        Else
            txtValorConta.Text = "0,00"
            lbl_mensagem.Text = "Valor dever ser Maior do que 0"
        End If

    End Sub

    Private Sub txt_valor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorConta.KeyPress, txtValorRestante.KeyPress, txtValorPago.KeyPress, txtAcrescimo.KeyPress, txtDesconto.KeyPress
        'permite só numeros e virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub Btn_salvar_Click(sender As Object, e As EventArgs) Handles Btn_salvar.Click

        If ValidaCamposAReceber() Then
            SetaValoresAReceber()
            SalvaContaAReceber()
            _AReceberTotalDAO.TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
            Me.Close()
        Else
            Return
        End If
    End Sub

    Sub SalvaContaAReceber()

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If operacao.Equals("I") Then
                Dim transacao As NpgsqlTransaction = connection.BeginTransaction

                _AReceberTotalDAO.incAReceberTotal(_AReceberTotal, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction

                _AReceberTotalDAO.altAReceberTotal(_AReceberTotal, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Conta A Receber Gravada com Sucesso!", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Function ValidaCamposAReceber() As Boolean

        lbl_mensagem.Text = ""

        If _Cliente.cid <= 0 Then
            lbl_mensagem.Text = "Informe um Cliente para Conta !"
            txt_codPart.Focus()
            Return False
        End If

        If Date.Compare(dtp_vencto.Text, dtp_emissao.Text) < 0 Then
            lbl_mensagem.Text = "Data de Vencimento DEVE ser Maior ou Igual a Data de Emissão !"
            dtp_vencto.Focus()
            Return False
        End If

        If CDbl(txtValorConta.Text) <= 0 Then
            lbl_mensagem.Text = "Valor da Conta DEVE ser Maior do que 0 !"
            txtValorConta.Focus() : txtValorConta.SelectAll()
            Return False
        End If

        Return True
    End Function

    Sub SetaValoresAReceber()

        Select Case operacao
            Case "I"

                With _AReceberTotal
                    .art_empresaid = MdlConexaoBD.mdlEmpresa.empid
                    .art_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
                    .art_clienteid = _Cliente.cid
                    .art_clientenome = _Cliente.cnome
                    .art_dataemissao = dtp_emissao.Value
                    .art_datavencimento = dtp_vencto.Value
                    .art_valor = CDbl(txtValorConta.Text)
                    .art_valorrestante = CDbl(txtValorRestante.Text)
                    .art_observacao = txt_historico.Text

                End With

            Case "A"

                With _AReceberTotal
                    .art_clienteid = _Cliente.cid
                    .art_clientenome = _Cliente.cnome
                    .art_dataemissao = dtp_emissao.Value
                    .art_datavencimento = dtp_vencto.Value
                    .art_valor = CDbl(txtValorConta.Text)
                    .art_valorrestante = CDbl(txtValorRestante.Text) - .art_valorpago
                    .art_observacao = txt_historico.Text

                End With

        End Select

    End Sub

    Sub SetaCamposAReceber()

        dtp_vencto.Value = dtp_emissao.Value.AddDays(CDbl(MdlConexaoBD.mdlConfiguracoes.tDiasVencCrediario))
        Select Case operacao
            Case "V"

                With _AReceberTotal
                    txt_codPart.Text = .art_clienteid
                    txt_nomePart.Text = .art_clientenome
                    dtp_emissao.Value = .art_dataemissao
                    dtp_vencto.Value = .art_datavencimento
                    txtValorConta.Text = .art_valor.ToString("#,##0.00")
                    txtValorRestante.Text = .art_valorrestante.ToString("#,##0.00")
                    txt_historico.Text = .art_observacao
                    txtDesconto.Text = .art_desconto.ToString("#,##0.00")
                    txtAcrescimo.Text = .art_acrescimo.ToString("#,##0.00")
                    txtSituacao.Text = .art_situacao
                    mskDtPagamento.Text = .art_datapagamento
                    txtValorPago.Text = .art_valorpago.ToString("#,##0.00")
                    cboTipoPagamento.SelectedIndex = _funcoes.trazIndexComboBox(.art_tipopagamento, 3, cboTipoPagamento)

                End With

            Case "A"

                With _AReceberTotal
                    txt_codPart.Text = .art_clienteid
                    txt_nomePart.Text = .art_clientenome
                    dtp_emissao.Value = .art_dataemissao
                    dtp_vencto.Value = .art_datavencimento
                    txtValorConta.Text = .art_valor.ToString("#,##0.00")
                    txtValorRestante.Text = .art_valorrestante.ToString("#,##0.00")
                    txt_historico.Text = .art_observacao
                    txtDesconto.Text = .art_desconto.ToString("#,##0.00")
                    txtAcrescimo.Text = .art_acrescimo.ToString("#,##0.00")
                    txtSituacao.Text = .art_situacao
                    mskDtPagamento.Text = .art_datapagamento
                    txtValorPago.Text = .art_valorpago.ToString("#,##0.00")
                    cboTipoPagamento.SelectedIndex = _funcoes.trazIndexComboBox(.art_tipopagamento, 3, cboTipoPagamento)

                End With

        End Select

    End Sub

    Private Sub txtValorConta_GotFocus(sender As Object, e As EventArgs) Handles txtValorConta.GotFocus
        txtValorConta.SelectAll()
    End Sub

    Sub PreencheAReceberParcial()

        dtgAReceberParcial.Rows.Clear()
        _AReceberParcialDAO.TrazContasParcialLISTA(_AReceberTotal, _ListAReceberParcial, MdlConexaoBD.mdlListAReceberParcial)
        Dim mDataStr As String = ""
        For Each arp As ClAReceberParcial In _ListAReceberParcial
            mDataStr = ""
            mDataStr = arp.arp_datapagamento.ToShortDateString & " " & arp.arp_datapagamento.ToShortTimeString

            dtgAReceberParcial.Rows.Add(arp.arp_pagodinheiro.ToString("#,##0.00"), arp.arp_pagocartaocred.ToString("#,##0.00"), arp.arp_pagocartaodeb.ToString("#,##0.00"), arp.arp_pagopix.ToString("#,##0.00"), arp.arp_pagotransferencia.ToString("#,##0.00"), mDataStr)
        Next

        SomaValoresContasPagas()
        lbl_registros.Text = dtgAReceberParcial.Rows.Count
    End Sub

    Sub SomaValoresContasPagas()

        txtTotalPagoDN.Text = SomaValoresDtg(0).ToString("#,##0.00")
        txtTotalPagoCTC.Text = SomaValoresDtg(1).ToString("#,##0.00")
        txtTotalPagoCTD.Text = SomaValoresDtg(2).ToString("#,##0.00")
        txtTotalPagoPIX.Text = SomaValoresDtg(3).ToString("#,##0.00")
        txtTotalPagoTRA.Text = SomaValoresDtg(4).ToString("#,##0.00")
    End Sub

    Function SomaValoresDtg(ByVal indexCol As Integer) As Double

        Dim mSoma As Double = 0

        For Each r As DataGridViewRow In dtgAReceberParcial.Rows

            If r.IsNewRow = False Then

                mSoma += r.Cells(indexCol).Value
            End If
        Next

        Return mSoma
    End Function

    Private Sub txt_codPart_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_codPart.KeyPress
        'permite só numeros:
        If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub
End Class