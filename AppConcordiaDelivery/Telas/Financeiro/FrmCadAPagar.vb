Imports Npgsql
Public Class FrmCadAPagar

    Public operacao As String = "I"
    Public _APagarTotal As New ClAPagarTotal
    Dim _APagarTotalDAO As New ClAPagarTotalDAO
    Dim _APagarParcial As New ClAPagarParcial
    Dim _ListAPagarParcial As New List(Of ClAPagarParcial)
    Dim _APagarParcialDAO As New ClAPagarParcialDAO
    Dim _fornecedor As New ClFornecedor
    Dim _fornecadorDAO As New ClFornecedorDAO
    Dim _funcoes As New ClFuncoes
    Dim _TipoDocumento As New ClTipoDocumento
    Dim _ListaTipoDocumento As New List(Of ClTipoDocumento)
    Dim _TIpoDocumentoDAO As New ClTipoDocumentoDAO

    Private Sub FrmCadAPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _TIpoDocumentoDAO.TrazListTipoDocumentos(_ListaTipoDocumento, MdlConexaoBD.conectionPadrao)
        _TIpoDocumentoDAO.PreencheCboTipoDocumentosLista(cboTipoDocumento, _ListaTipoDocumento, "AP")
        ConfiguraCamposParaOperacao()
        SetaCamposAPagar()
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
                cboTipoDocumento.SelectedIndex = -1
                cboTipoDocumento.Enabled = True

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

                If Not _APagarTotal.apt_tela.Equals("APAGAR") Then
                    txt_codPart.Enabled = False
                End If

                If _APagarTotal.apt_valorrestante < _APagarTotal.apt_valor Then
                    txtValorConta.ReadOnly = True
                End If

                If _APagarTotal.apt_valorpago > 0 Then
                    txtValorConta.ReadOnly = True
                End If

                cboTipoDocumento.Enabled = True

                PreencheAPagarParcial()

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

                cboTipoDocumento.Enabled = False
                Btn_salvar.Enabled = False

                PreencheAPagarParcial()

        End Select

    End Sub

    Private Sub FrmCadAPagar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmCadAPagar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

#Region "  TEXTO Busca Cliente"

    Private Sub txt_codPapt_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_codPart.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            buscaPortador()
        End If

    End Sub

    Sub buscaPortador()

        lbl_mensagem.Text = ""
        _fornecedor.ZeraValores()
        If IsNumeric(txt_codPart.Text) Then


            _fornecedor.pId = CInt(txt_codPart.Text)
            _fornecadorDAO.TrazFornecedorDoBD(_fornecedor, MdlConexaoBD.conectionPadrao)


            'Aqui tenta chamar o Formulario de Busca do Fornecedor...
            Try

                If _fornecedor.pNome.Equals("") Then

                    Dim frmResponse As New FrmFornecedorResp
                    frmResponse.ShowDialog()
                    _fornecedor.SetaValores(frmResponse._fornecedor)
                    frmResponse = Nothing

                Else
                    txt_nomePart.Text = _fornecedor.pNome.ToUpper
                End If


            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        Else

            'Aqui tenta chamar o Formulario de Busca do Cliente...
            Try

                If _fornecedor.pNome.Equals("") Then

                    Dim frmResponse As New FrmFornecedorResp
                    frmResponse.ShowDialog()
                    _fornecedor.SetaValores(frmResponse._fornecedor)
                    frmResponse = Nothing

                Else
                    txt_nomePart.Text = _fornecedor.pNome.ToUpper
                End If

                Me.txt_nomePart.Focus()
                Me.txt_nomePart.SelectAll()

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        End If


        If _fornecedor.pId = 0 Then
            txt_codPart.Text = "" : txt_nomePart.Text = ""
            txt_codPart.Focus() : txt_codPart.SelectAll()
        Else
            txt_codPart.Text = _fornecedor.pId
            txt_nomePart.Text = _fornecedor.pNome
            Me.txt_nomePart.Focus()
            Me.txt_nomePart.SelectAll()
        End If


    End Sub

    Private Sub txt_codPapt_Leave(sender As Object, e As EventArgs) Handles txt_codPart.Leave

        If IsNumeric(txt_codPart.Text) Then


            Dim mFornecedor As New ClFornecedor
            mFornecedor.pId = CInt(txt_codPart.Text)
            _fornecadorDAO.TrazFornecedorDoBD(mFornecedor, MdlConexaoBD.conectionPadrao)
            If mFornecedor.pId < 1 Then

                _fornecedor.ZeraValores()
                txt_codPart.Text = ""
                txt_nomePart.Text = ""
            Else

                _fornecedor.SetaValores(mFornecedor)
                txt_codPart.Text = _fornecedor.pId
                txt_nomePart.Text = _fornecedor.pNome
            End If

        End If

    End Sub

    Private Sub txt_codPapt_Click(sender As Object, e As EventArgs) Handles txt_codPart.Click
        txt_codPart.SelectAll()
    End Sub

#End Region


    Private Sub txt_valor_Leave(sender As Object, e As EventArgs) Handles txtValorConta.Leave

        lbl_mensagem.Text = ""
        If IsNumeric(txtValorConta.Text) Then 'Se for Número

            txtValorConta.Text = CDbl(txtValorConta.Text).ToString("#,##0.00")
            If _APagarTotal.apt_valorpago <= 0 Then
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

        If ValidaCamposAPagar() Then
            SetaValoresAPagar()
            SalvaContaAPagar()
            _APagarTotalDAO.TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
            Me.Close()
        Else
            Return
        End If
    End Sub

    Sub SalvaContaAPagar()

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

                _APagarTotalDAO.incAPagarTotal(_APagarTotal, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction

                _APagarTotalDAO.altAPagarTotal(_APagarTotal, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Conta A PAGAR Gravada com Sucesso!", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Function ValidaCamposAPagar() As Boolean

        lbl_mensagem.Text = ""
        Dim mMsg As String = ""

        If _fornecedor.pId <= 0 Then
            lbl_mensagem.Text = "Informe um Fornecedor para Conta !"
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

        If cboTipoDocumento.SelectedIndex < 0 Then
            lbl_mensagem.Text = "Selecione Um Documento Para Pagamaento!"
            cboTipoDocumento.Focus() : cboTipoDocumento.DroppedDown = True
            Return False
        End If

        Return True
    End Function

    Sub SetaValoresAPagar()

        Select Case operacao
            Case "I"

                With _APagarTotal

                    .apt_empresaid = MdlConexaoBD.mdlEmpresa.empid
                    .apt_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
                    .apt_portadorid = _fornecedor.pId
                    .apt_portadornome = _fornecedor.pNome
                    .apt_dataemissao = dtp_emissao.Value
                    .apt_datavencimento = dtp_vencto.Value
                    .apt_valor = CDbl(txtValorConta.Text)
                    .apt_valorrestante = CDbl(txtValorRestante.Text)
                    .apt_observacao = txt_historico.Text
                    .apt_tipodocumentoid = _TipoDocumento.td_id
                    .apt_tipodocumentodescr = _TipoDocumento.td_descricao
                End With

            Case "A"

                With _APagarTotal

                    .apt_portadorid = _fornecedor.pId
                    .apt_portadornome = _fornecedor.pNome
                    .apt_dataemissao = dtp_emissao.Value
                    .apt_datavencimento = dtp_vencto.Value
                    .apt_valor = CDbl(txtValorConta.Text)
                    .apt_valorrestante = CDbl(txtValorRestante.Text) - .apt_valorpago
                    .apt_observacao = txt_historico.Text
                    .apt_tipodocumentoid = _TipoDocumento.td_id
                    .apt_tipodocumentodescr = _TipoDocumento.td_descricao

                End With

        End Select

    End Sub

    Sub SetaCamposAPagar()

        dtp_vencto.Value = dtp_emissao.Value.AddDays(CDbl(MdlConexaoBD.mdlConfiguracoes.tDiasVencCrediario))
        Select Case operacao
            Case "V"

                With _APagarTotal
                    txt_codPart.Text = .apt_portadorid
                    txt_nomePart.Text = .apt_portadornome
                    dtp_emissao.Value = .apt_dataemissao
                    dtp_vencto.Value = .apt_datavencimento
                    txtValorConta.Text = .apt_valor.ToString("#,##0.00")
                    txtValorRestante.Text = .apt_valorrestante.ToString("#,##0.00")
                    txt_historico.Text = .apt_observacao
                    txtDesconto.Text = .apt_desconto.ToString("#,##0.00")
                    txtAcrescimo.Text = .apt_acrescimo.ToString("#,##0.00")
                    txtSituacao.Text = .apt_situacao
                    mskDtPagamento.Text = .apt_datapagamento
                    txtValorPago.Text = .apt_valorpago.ToString("#,##0.00")
                    cboTipoDocumento.SelectedIndex = _clFunc.trazIndexCboTextoTodo(.apt_tipodocumentodescr, cboTipoDocumento)

                End With

            Case "A"

                With _APagarTotal
                    txt_codPart.Text = .apt_portadorid
                    txt_nomePart.Text = .apt_portadornome
                    dtp_emissao.Value = .apt_dataemissao
                    dtp_vencto.Value = .apt_datavencimento
                    txtValorConta.Text = .apt_valor.ToString("#,##0.00")
                    txtValorRestante.Text = .apt_valorrestante.ToString("#,##0.00")
                    txt_historico.Text = .apt_observacao
                    txtDesconto.Text = .apt_desconto.ToString("#,##0.00")
                    txtAcrescimo.Text = .apt_acrescimo.ToString("#,##0.00")
                    txtSituacao.Text = .apt_situacao
                    mskDtPagamento.Text = .apt_datapagamento
                    txtValorPago.Text = .apt_valorpago.ToString("#,##0.00")
                    cboTipoDocumento.SelectedIndex = _clFunc.trazIndexCboTextoTodo(.apt_tipodocumentodescr, cboTipoDocumento)

                End With

        End Select

    End Sub

    Private Sub txtValorConta_GotFocus(sender As Object, e As EventArgs) Handles txtValorConta.GotFocus
        txtValorConta.SelectAll()
    End Sub

    Sub PreencheAPagarParcial()

        dtgAPagarParcial.Rows.Clear()
        _APagarParcialDAO.TrazContasParcialLISTA(_APagarTotal, _ListAPagarParcial, MdlConexaoBD.mdlListAPagarParcial)
        Dim mDataStr As String = ""
        For Each arp As ClAPagarParcial In _ListAPagarParcial
            mDataStr = ""
            mDataStr = arp.app_datapagamento.ToShortDateString & " " & arp.app_datapagamento.ToShortTimeString

            dtgAPagarParcial.Rows.Add(arp.app_pagodinheiro.ToString("#,##0.00"), arp.app_pagocartaocred.ToString("#,##0.00"), arp.app_pagocartaodeb.ToString("#,##0.00"), arp.app_pagopix.ToString("#,##0.00"), arp.app_pagotransferencia.ToString("#,##0.00"), mDataStr)
        Next

        SomaValoresContasPagas()
        lbl_registros.Text = dtgAPagarParcial.Rows.Count
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

        For Each r As DataGridViewRow In dtgAPagarParcial.Rows

            If r.IsNewRow = False Then

                mSoma += r.Cells(indexCol).Value
            End If
        Next

        Return mSoma
    End Function

    Private Sub txt_codPapt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_codPart.KeyPress
        'permite só numeros:
        If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDocumento.SelectedIndexChanged

        Try
            _TipoDocumento.zeraValores()
            If cboTipoDocumento.SelectedIndex >= 0 Then

                _TipoDocumento.td_descricao = cboTipoDocumento.SelectedItem.ToString
                _TIpoDocumentoDAO.TrazTipoDocumentoNome(_TipoDocumento, MdlConexaoBD.conectionPadrao)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class