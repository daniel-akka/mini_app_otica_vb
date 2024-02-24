Imports Npgsql
Public Class FrmContasAReceberCliente

    Private _ListaAReceberTotal As New List(Of ClAReceberTotal)
    Private _AReceberTotalDAO As New ClAReceberTotalDAO
    Private _AReceberTotal As New ClAReceberTotal
    Dim _AReceberParcial As New ClAReceberParcial
    Dim _AReceberParcialDAO As New ClAReceberParcialDAO
    Private _Cliente As New ClCliente
    Private _ClienteDAO As New ClClienteDAO
    Dim _AbrirFecharDAO As New ClAbrirFecharDAO
    Public _Caixa As New ClAbrirFecharCaixa(0, Date.Now, "", False, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    Public _TeveBaixa As Boolean = False

    Dim _sitDoc As String = "N"
    Dim _diasVencidos As Integer = 0
    Dim EhBaixaParcial As Boolean = False
    Dim _funcoes As New ClFuncoes

    Private Sub FrmContasAReceberCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                ExecutaF5()

        End Select

    End Sub

    Private Sub FrmContasAReceberCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Sub ExecutaF5()


        Dim mSituacao As String = "", mdtVencto As String = "", mDataPagamento As String = ""
        Dim mDataBetween As Boolean = False
        Dim mDias As Integer = 0
        Dim mIdCliente As Integer = 0
        If IsNumeric(txtIdCliente.Text) Then mIdCliente = CInt(txtIdCliente.Text)


        _ListaAReceberTotal.Clear()
        dtgContasAReceberCliente.Rows.Clear()

        mSituacao = "N"
       
        _ListaAReceberTotal = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                        ar.art_clienteid = mIdCliente And _
                                                                        ar.art_situacao = mSituacao)

        If _ListaAReceberTotal.Count > 0 Then

            For Each ar As ClAReceberTotal In _ListaAReceberTotal

                'Calcula os Dias Vencidos:
                mDias = 0
                Try
                    mdtVencto = Format(Convert.ChangeType(ar.art_datavencimento, GetType(Date)), "dd/MM/yyyy")

                    If Convert.ChangeType(mdtVencto, GetType(Date)) < Date.Now Then

                        mDias = Date.Now.Subtract(Convert.ChangeType(mdtVencto, GetType(Date))).Days

                    End If

                Catch ex As Exception
                    mdtVencto = ""
                End Try
                _diasVencidos = mDias

                _sitDoc = ar.art_situacao

                mDataPagamento = ar.art_datapagamento
                If IsDate(mDataPagamento) Then mDataPagamento = CDate(mDataPagamento).ToShortDateString & " " & CDate(mDataPagamento).ToShortTimeString

                ''Preeenche Com o nome atualizado do Cliente:
                '_Cliente.ZeraValores()
                '_Cliente.cid = ar.art_clienteid
                '_ClienteDAO.TrazClienteDaListaClientes(_Cliente, MdlConexaoBD.mdlListClientes)
                'ar.art_clientenome = _Cliente.cnome


                'Adiciona no Grid
                dtgContasAReceberCliente.Rows.Add(False, ar.art_id, ar.art_tela, ar.art_situacao, _
                                           ar.art_dataemissao.ToShortDateString, ar.art_valor.ToString("#,##0.00"), ar.art_datavencimento.ToShortDateString, ar.art_valorrestante.ToString("#,##0.00"), ar.art_observacao)
            Next
        End If

        somaMarcados()

    End Sub

    Private Sub somaMarcados()

        Dim msomaMarcados As Double = 0.0
        For Each row As DataGridViewRow In Me.dtgContasAReceberCliente.Rows

            If row.IsNewRow = False Then

                If row.Cells(0).Value Then

                    Try
                        msomaMarcados += row.Cells(7).Value
                    Catch ex As Exception
                    End Try
                End If

            End If


        Next

        Me.txtTotalSelecionados.Text = Format(msomaMarcados, "###,##0.00")

    End Sub


#Region "  TEXTO Busca Cliente"

    Private Sub txtIdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdCliente.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            buscaCliente()
        End If

    End Sub

    Sub buscaCliente()

        _Cliente.ZeraValores()
        If IsNumeric(txtIdCliente.Text) Then


            _Cliente.cid = CInt(txtIdCliente.Text)
            _ClienteDAO.TrazClienteDaListaClientes(_Cliente, MdlConexaoBD.ListaClientes)

            'Aqui tenta chamar o Formulario de Busca do Fornecedor...
            Try

                If _Cliente.cnome.Equals("") Then

                    Dim frmResponse As New FrmClienteResp
                    frmResponse.ShowDialog()
                    _Cliente.SetaValores(frmResponse._cliente)
                    frmResponse = Nothing
                Else
                    txtNomeCliente.Text = _Cliente.cnome.ToUpper
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
                    txtNomeCliente.Text = _Cliente.cnome.ToUpper
                End If

            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            End Try

        End If

        If _Cliente.cid <= 0 Then
            txtIdCliente.Text = "" : txtNomeCliente.Text = ""
            txtIdCliente.Focus() : txtIdCliente.SelectAll()
            txtNomeCliente.ReadOnly = False
            txtNomeCliente.BackColor = Color.White
            dtgContasAReceberCliente.Rows.Clear()
        Else
            txtIdCliente.Text = _Cliente.cid
            txtNomeCliente.Text = _Cliente.cnome
            txtNomeCliente.ReadOnly = True
            txtNomeCliente.BackColor = Color.LightYellow
            txtNomeCliente.Focus()
            ExecutaF5()
        End If

    End Sub

    Private Sub txtIdCliente_Leave(sender As Object, e As EventArgs) Handles txtIdCliente.Leave

        If IsNumeric(txtIdCliente.Text) Then

            Dim mCliente As New ClCliente
            mCliente.cid = CInt(txtIdCliente.Text)
            _ClienteDAO.TrazClienteDaListaClientes(mCliente, MdlConexaoBD.ListaClientes)
            If mCliente.cid < 1 Then

                _Cliente.ZeraValores()
                txtIdCliente.Text = ""
                txtNomeCliente.Text = ""
            Else

                _Cliente.SetaValores(mCliente)
                txtIdCliente.Text = _Cliente.cid
                txtNomeCliente.Text = _Cliente.cnome
            End If
        Else
            _Cliente.ZeraValores()
        End If

    End Sub

    Private Sub txtIdCliente_Click(sender As Object, e As EventArgs) Handles txtIdCliente.Click
        txtIdCliente.SelectAll()
    End Sub

    Private Sub txtNomeCliente_GotFocus(sender As Object, e As EventArgs) Handles txtNomeCliente.GotFocus

        If _Cliente.cid < 1 Then
            txtNomeCliente.Text = ""
            txtNomeCliente.ReadOnly = False
            txtNomeCliente.BackColor = Color.White

        Else
            txtNomeCliente.ReadOnly = True
            txtNomeCliente.BackColor = Color.LightYellow
        End If
        txtNomeCliente.SelectAll()
    End Sub

#End Region

    Private Sub dtgContasAReceberCliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgContasAReceberCliente.CellClick

        If e.ColumnIndex = 0 Then

            desmarcaContas(e.RowIndex)
            If Me.dtgContasAReceberCliente.CurrentRow.Cells(0).Value Then
                Me.dtgContasAReceberCliente.CurrentRow.Cells(0).Value = False
                _AReceberTotal.ZeraValores()
            Else
                Me.dtgContasAReceberCliente.CurrentRow.Cells(0).Value = True
                _AReceberTotal.art_id = dtgContasAReceberCliente.CurrentRow.Cells(1).Value
                _AReceberTotalDAO.TrazContaAReceberDaLista(_AReceberTotal, MdlConexaoBD.ListaAReceberTotal)
            End If

            somaMarcados()
        End If

    End Sub

    Sub desmarcaContas(rowIndex As Integer)

        For Each r As DataGridViewRow In dtgContasAReceberCliente.Rows

            If r.IsNewRow = False Then

                If r.Index = rowIndex Then Continue For
                r.Cells(0).Value = False
            End If

        Next
    End Sub

    Sub desmarcaTodasContas()

        For Each r As DataGridViewRow In dtgContasAReceberCliente.Rows

            If r.IsNewRow = False Then

                r.Cells(0).Value = False
            End If

        Next
    End Sub

    Private Sub dtgContasAReceberCliente_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgContasAReceberCliente.RowsAdded

        If _diasVencidos > 0 Then dtgContasAReceberCliente.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        If CDbl(dtgContasAReceberCliente.Rows(e.RowIndex).Cells(7).Value) > 0 Then
            dtgContasAReceberCliente.Rows(e.RowIndex).Cells(7).Style.ForeColor = Color.DarkGreen
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

    Private Sub txtPagoDN_Leave(sender As Object, e As EventArgs) Handles txtPagoDN.Leave
        If IsNumeric(txtPagoDN.Text) Then

            txtPagoDN.Text = CDbl(txtPagoDN.Text).ToString("#,##0.00")
            If CDbl(txtValorPago.Text) > CDbl(txtTotalSelecionados.Text) Then
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
            If CDbl(txtValorPago.Text) > CDbl(txtTotalSelecionados.Text) Then
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
            If CDbl(txtValorPago.Text) > CDbl(txtTotalSelecionados.Text) Then
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
            If CDbl(txtValorPago.Text) > CDbl(txtTotalSelecionados.Text) Then
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
            If CDbl(txtValorPago.Text) > CDbl(txtTotalSelecionados.Text) Then
                MsgBox("Valor Pago não pode ser Maior que o Valor Restante!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                txtPagoTRA.Focus() : txtPagoTRA.SelectAll()
                Return
            End If
        Else
            txtPagoTRA.Text = "0,00"
        End If
    End Sub

    Private Sub txtPago_TextChanged(sender As Object, e As EventArgs) Handles txtPagoTRA.TextChanged, txtPagoPIX.TextChanged, txtPagoDN.TextChanged, txtPagoCTD.TextChanged, txtPagoCTC.TextChanged

        If IsNumeric(txtPagoTRA.Text) AndAlso IsNumeric(txtPagoPIX.Text) AndAlso IsNumeric(txtPagoDN.Text) _
            AndAlso IsNumeric(txtPagoCTD.Text) AndAlso IsNumeric(txtPagoCTC.Text) Then

            txtValorPago.Text = (CDbl(txtPagoDN.Text) + CDbl(txtPagoCTC.Text) + CDbl(txtPagoCTD.Text) + CDbl(txtPagoPIX.Text) + CDbl(txtPagoTRA.Text)).ToString("#,##0.00")
        End If

    End Sub

    Private Sub txtValorPago_TextChanged(sender As Object, e As EventArgs) Handles txtValorPago.TextChanged

        EhBaixaParcial = False
        If IsNumeric(txtValorPago.Text) Then

            If IsNumeric(txtTotalSelecionados.Text) Then

                If CDbl(txtTotalSelecionados.Text) > 0 Then

                    txtValorRestante.Text = (CDbl(txtTotalSelecionados.Text) - CDbl(txtValorPago.Text)).ToString("#,##0.00")
                    If CDbl(txtValorRestante.Text) > 0 Then EhBaixaParcial = True
                Else
                    txtValorRestante.Text = "0,00"
                End If
            Else
                txtValorRestante.Text = "0,00"
            End If

        End If
    End Sub

    Private Sub btn_baixar_Click(sender As Object, e As EventArgs) Handles btn_baixar.Click

        _TeveBaixa = False
        If verificaContaAReceber() Then

            PreencheValoresContaAReceber()
            If EhBaixaParcial Then

                SalvandoContaAReceberParcial()
                _AReceberTotalDAO.TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
                _AReceberParcialDAO.TrazListAReceberParcial(MdlConexaoBD.mdlListAReceberParcial, MdlConexaoBD.conectionPadrao)
                desmarcaTodasContas()
                ZeraValores()
                ExecutaF5()

            Else

                SalvandoContaAReceberTotal()
                _AReceberTotalDAO.TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
                _AReceberParcialDAO.TrazListAReceberParcial(MdlConexaoBD.mdlListAReceberParcial, MdlConexaoBD.conectionPadrao)
                desmarcaTodasContas()
                ZeraValores()
                ExecutaF5()
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

            _AReceberTotalDAO.altAReceberBaixaIndividual(_AReceberTotal, connection, transacao)
            transacao.Commit()

            MsgBox("Conta A Receber Baixada com Sucesso!", MsgBoxStyle.Exclamation)
            _TeveBaixa = True
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

            _AReceberTotalDAO.baixarAReceberParcial(_AReceberTotal, _AReceberParcial, connection, transacao)
            transacao.Commit()

            MsgBox("Baixa Parcial efetuada com Sucesso!", MsgBoxStyle.Exclamation)
            _TeveBaixa = True
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub PreencheValoresContaAReceber()

        If EhBaixaParcial Then

            _AReceberTotal.art_empresaid = MdlConexaoBD.mdlEmpresa.empid
            _AReceberTotal.art_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            _AReceberTotal.art_valorpago += CDbl(txtValorPago.Text)
            _AReceberTotal.art_valorrestante = CDbl(txtValorRestante.Text)
            _AReceberTotal.art_acrescimo += CDbl(txtAcrescimo.Text)
            _AReceberTotal.art_desconto += CDbl(txtDesconto.Text)
            _AReceberTotal.art_pagodinheiro += CDbl(txtPagoDN.Text)
            _AReceberTotal.art_pagocartaocred += CDbl(txtPagoCTC.Text)
            _AReceberTotal.art_pagocartaodeb += CDbl(txtPagoCTD.Text)
            _AReceberTotal.art_pagopix += CDbl(txtPagoPIX.Text)
            _AReceberTotal.art_pagotransferencia += CDbl(txtPagoTRA.Text)

            With _AReceberParcial

                .arp_artid = _AReceberTotal.art_id
                .arp_idcaixa = _Caixa.Af_id1
                .arp_datapagamento = Date.Now
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

            _AReceberTotal.art_empresaid = MdlConexaoBD.mdlEmpresa.empid
            _AReceberTotal.art_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            _AReceberTotal.art_idcaixa = _Caixa.Af_id1
            _AReceberTotal.art_valorpago += CDbl(txtValorPago.Text)
            _AReceberTotal.art_valorrestante = CDbl(txtValorRestante.Text)
            _AReceberTotal.art_acrescimo += CDbl(txtAcrescimo.Text)
            _AReceberTotal.art_desconto += CDbl(txtDesconto.Text)
            _AReceberTotal.art_pagodinheiro += CDbl(txtPagoDN.Text)
            _AReceberTotal.art_pagocartaocred += CDbl(txtPagoCTC.Text)
            _AReceberTotal.art_pagocartaodeb += CDbl(txtPagoCTD.Text)
            _AReceberTotal.art_pagopix += CDbl(txtPagoPIX.Text)
            _AReceberTotal.art_pagotransferencia += CDbl(txtPagoTRA.Text)

        End If

    End Sub

    Function verificaContaAReceber() As Boolean

        If CDbl(txtTotalSelecionados.Text) <= 0 Then

            MsgBox("Selecione Uma Conta para Baixar!", MsgBoxStyle.Information, Application.CompanyName.ToUpper)
            Return False
        End If

        If CDbl(txtValorPago.Text) <= 0 Then

            MsgBox("Informe Algum Valor Para Baixar a Conta!", MsgBoxStyle.Information, Application.CompanyName.ToUpper)
            txtPagoDN.Focus() : txtPagoDN.SelectAll()
            Return False
        End If

        Return True
    End Function

    Private Sub txtAcrescimo_Click(sender As Object, e As EventArgs) Handles txtAcrescimo.Click
        txtAcrescimo.SelectAll()
    End Sub

    Private Sub txtDesconto_Click(sender As Object, e As EventArgs) Handles txtDesconto.Click
        txtDesconto.SelectAll()
    End Sub

    Private Sub txtAcrescimo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAcrescimo.KeyPress, txtDesconto.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtAcrescimo_Leave(sender As Object, e As EventArgs) Handles txtAcrescimo.Leave

        If IsNumeric(txtAcrescimo.Text) Then

            txtAcrescimo.Text = CDbl(txtAcrescimo.Text).ToString("#,##0.00")
            txtTotalSelecionados.Text = ((CDbl(txtTotalSelecionados.Text) + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
            txtValorRestante.Text = ((_AReceberTotal.art_valorrestante + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
        Else
            txtAcrescimo.Text = "0,00"
        End If
    End Sub

    Private Sub txtDesconto_Leave(sender As Object, e As EventArgs) Handles txtDesconto.Leave

        If IsNumeric(txtDesconto.Text) Then

            txtDesconto.Text = CDbl(txtDesconto.Text).ToString("#,##0.00")
            txtTotalSelecionados.Text = ((CDbl(txtTotalSelecionados.Text) + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
            txtValorRestante.Text = ((_AReceberTotal.art_valorrestante + CDbl(txtAcrescimo.Text)) - CDbl(txtDesconto.Text)).ToString("#,##0.00")
        Else
            txtDesconto.Text = "0,00"
        End If
    End Sub

    Sub ZeraValores()

        txtPagoDN.Text = "0,00" : txtPagoCTC.Text = "0,00"
        txtPagoCTD.Text = "0,00" : txtPagoPIX.Text = "0,00"
        txtPagoTRA.Text = "0,00" : txtValorRestante.Text = "0,00"
        txtTotalSelecionados.Text = "0,00" : txtValorPago.Text = "0,00"
        txtAcrescimo.Text = "0,00" : txtDesconto.Text = "0,00"
        txtObservacao.Text = ""

    End Sub

End Class