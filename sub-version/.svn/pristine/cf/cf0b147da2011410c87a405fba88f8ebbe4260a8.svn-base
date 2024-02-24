Imports Npgsql
Imports System.Text
Imports System.Math
Public Class FrmCaixa

    Dim vAbrirFecharDAO As New ClAbrirFecharDAO
    Dim vCaixaDAO As New ClCaixaDAO
    Dim vAbrirFechar As ClAbrirFecharCaixa
    Dim vAbrirFecharAuxiliar As ClAbrirFecharCaixa
    Dim _ListaIntesVendaServico As New List(Of ClVendaServicoItens)
    Private _ListaAReceberTotal As New List(Of ClAReceberTotal)
    Private _ListaAReceberParcial As New List(Of ClAReceberParcial)
    Dim _AReceberTotalDAO As New ClAReceberTotalDAO
    Dim _AReceberParcialDAO As New ClAReceberParcialDAO
    Dim _ItemVendaServico As New ClVendaServicoItensDAO
    Dim _ListaVendaServico As New List(Of ClVendaServico)
    Dim _VendaServicoDAO As New ClVendaServicoDAO

    Private Sub cbo_tipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_tipo.SelectedIndexChanged

        txtTotalApuradoDn.Text = "0.00" : txtTotalApuradoCtCredito.Text = "0.00"
        If cbo_tipo.SelectedIndex < 0 Then Return
        Select Case cbo_tipo.SelectedItem.ToString.Substring(0, 1)
            Case "S" 'Saida
                rtb_motivo.Enabled = True
            Case "E" 'Entrada
                rtb_motivo.Enabled = True
            Case "T" 'troco
                rtb_motivo.Enabled = False
            Case "F" 'Fechamento
                rtb_motivo.Enabled = False
                Dim mSomaEntradasDn As Double = 0.0
                Dim mSomaEntradasCtc As Double = 0.0
                Dim mSomaEntradasCtd As Double = 0.0
                Dim mSomaEntradasPix As Double = 0.0
                Dim mSomaEntradasTra As Double = 0.0
                Dim mSomaEntradasCrd As Double = 0.0
                Dim mSomaSaidasDn As Double = 0.0
                Dim mSomaSaidasCtc As Double = 0.0
                Dim mSomaSaidasCtd As Double = 0.0
                Dim mSomaSaidasPix As Double = 0.0
                Dim mSomaSaidasTra As Double = 0.0
                Dim mSomaSaidasCrd As Double = 0.0
                Dim mSomaTroco As Double = 0.0


                mSomaEntradasDn = somaValoresMovimentacoes("E", "DN")
                mSomaEntradasCtc = somaValoresMovimentacoes("E", "CTC")
                mSomaEntradasCtd = somaValoresMovimentacoes("E", "CTD")
                mSomaEntradasPix = somaValoresMovimentacoes("E", "PIX")
                mSomaEntradasTra = somaValoresMovimentacoes("E", "TRA")
                mSomaEntradasCrd = somaValoresMovimentacoes("E", "CRD")
                mSomaSaidasDn = somaValoresMovimentacoes("S", "DN")
                mSomaSaidasCtc = somaValoresMovimentacoes("S", "CTC")
                mSomaSaidasCtd = somaValoresMovimentacoes("S", "CTD")
                mSomaSaidasPix = somaValoresMovimentacoes("S", "PIX")
                mSomaSaidasTra = somaValoresMovimentacoes("S", "TRA")
                mSomaSaidasCrd = somaValoresMovimentacoes("S", "CRD")
                mSomaTroco = somaValoresMovimentacoes("T")
                Try
                    txtTotalApuradoDn.Text = Round(((CDbl(txtTotalDN.Text) + mSomaEntradasDn + mSomaTroco) - mSomaSaidasDn), 2).ToString("#,##0.00")
                    txtTotalApuradoDn.Text = (CDbl(txtTotalApuradoDn.Text) + CDbl(txtTotalDNaReceber.Text)).ToString("#,##0.00")
                    txtInfoDinheiro.Text = txtTotalApuradoDn.Text
                Catch ex As Exception
                End Try

                Try
                    txtTotalApuradoCtCredito.Text = Round(((mSomaEntradasCtc + CDbl(txtTotalCTC.Text)) - mSomaSaidasCtc), 2).ToString("#,##0.00")
                    txtTotalApuradoCtCredito.Text = (CDbl(txtTotalApuradoCtCredito.Text) + CDbl(txtTotalCTCaReceber.Text)).ToString("#,##0.00")
                    txtInfoCartaoCredito.Text = txtTotalApuradoCtCredito.Text
                Catch ex As Exception
                End Try

                Try
                    txtTotalApuradoCtDebito.Text = Round(((mSomaEntradasCtd + CDbl(txtTotalCTD.Text)) - mSomaSaidasCtd), 2).ToString("#,##0.00")
                    txtTotalApuradoCtDebito.Text = (CDbl(txtTotalApuradoCtDebito.Text) + CDbl(txtTotalCTDaReceber.Text)).ToString("#,##0.00")
                    txtInfoCartaoDebito.Text = txtTotalApuradoCtDebito.Text
                Catch ex As Exception
                End Try

                Try
                    txtTotalApuradoPix.Text = Round(((mSomaEntradasPix + CDbl(txtTotalPix.Text)) - mSomaSaidasPix), 2).ToString("#,##0.00")
                    txtTotalApuradoPix.Text = (CDbl(txtTotalApuradoPix.Text) + CDbl(txtTotalPIXaReceber.Text)).ToString("#,##0.00")
                    txtInfoPix.Text = txtTotalApuradoPix.Text
                Catch ex As Exception
                End Try

                Try
                    txtTotalApuradoTransferencia.Text = Round(((mSomaEntradasTra + CDbl(txtTotalTRA.Text)) - mSomaSaidasTra), 2).ToString("#,##0.00")
                    txtTotalApuradoTransferencia.Text = (CDbl(txtTotalApuradoTransferencia.Text) + CDbl(txtTotalTRAaReceber.Text)).ToString("#,##0.00")
                    txtInfoTransferencia.Text = txtTotalApuradoTransferencia.Text
                Catch ex As Exception
                End Try

                Try
                    txtTotalApuradoCrediario.Text = Round(((mSomaEntradasCrd + CDbl(txtTotalCRD.Text)) - mSomaSaidasCrd), 2).ToString("#,##0.00")
                    txtInfoCrediario.Text = txtTotalApuradoCrediario.Text
                Catch ex As Exception
                End Try

            Case Else
                rtb_motivo.Text = "" : rtb_motivo.Enabled = False
        End Select
    End Sub

    Sub zeraValores()
        txtTotalCTC.Text = "0.00" : txtTotalDN.Text = "0.00"
        txtTotalCTD.Text = "0.00" : txtTotalPix.Text = "0.00"
        txtTotalTRA.Text = "0.00" : txtTotalCRD.Text = "0,00"
        txtRegVendas.Text = "0" : txtTotalDN.Text = "0.00"
        txtTotMovSaidas.Text = "0.00" : txtTotMovEntradas.Text = "0.00"
        dtgVendasCaixa.Rows.Clear()
        dtgOperacoesCaixa.Rows.Clear()
        txtTotalApuradoDn.Text = "0.00" : txtTotalApuradoCtCredito.Text = "0.00"
        txtTotalApuradoPix.Text = "0.00" : txtTotalApuradoCtDebito.Text = "0.00"
        txtTotalApuradoTransferencia.Text = "0.00" : txtTotalApuradoCrediario.Text = "0.00"
        txtInfoCartaoCredito.Text = "0.00" : txtInfoDinheiro.Text = "0.00"
        txtInfoCartaoDebito.Text = "0.00" : txtInfoPix.Text = "0.00"
        txtInfoTransferencia.Text = "0.00" : txtInfoCrediario.Text = "0.00"
    End Sub

    Private Sub FrmCaixa_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F7
                chamaFormAReceberCliente()

        End Select
    End Sub

    Private Sub FrmCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text += " - " & Application.CompanyName.ToUpper
        rtb_motivo.Text = "" : rtb_motivo.Enabled = False
        If vAbrirFecharDAO.VerificaCaixaAberto(MdlConexaoBD.conectionPadrao) Then

            cbo_tipo.Items.Clear()
            cbo_tipo.Items.Add("S= Saida Do Caixa")
            cbo_tipo.Items.Add("E= Entrada No Caixa")
            cbo_tipo.Items.Add("T= Troco")
            cbo_tipo.Items.Add("F= Fechamento")
            vAbrirFecharDAO.TrazCaixaAberto(vAbrirFecharAuxiliar, MdlConexaoBD.conectionPadrao)

            'Preenchendo DataGrid Views:
            PreencheDtgVendasFinalizadas()
            PreencheDtgAReceberPagas()
            PreencheDtgOperacoes()
        Else

            cbo_tipo.Items.Clear()
            cbo_tipo.Items.Add("A= Abertura")
            cbo_tipo.SelectedIndex = 0
            rtb_motivo.Text = "" : rtb_motivo.Enabled = False
        End If


    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        'Verifica qual a opção selecionada
        Select Case cbo_tipo.SelectedItem.ToString.Substring(0, 2)
            Case "A=" 'Abertura: Incluir uma abertura de caixa
                InserirAberturaCaixa()
            Case "F=" 'Fechar: Rotina para Fechamento do caixa
                FechamentoDoCaixa()
            Case "S=" 'Saida
                InserirOperacao()
                PreencheDtgOperacoes()
            Case "E=" 'Entrada
                InserirOperacao()
                PreencheDtgOperacoes()
            Case "T=" 'Troco
                InserirOperacao()
                PreencheDtgOperacoes()
        End Select
        cbo_tipo.SelectedIndex = -1
        rtb_motivo.Text = ""
        rtb_motivo.ReadOnly = True

    End Sub

#Region "Rotinas de Controle"

    Sub InserirAberturaCaixa()
        Dim mAbertura As New ClAbrirFecharCaixa(0, Date.Now, "A", False, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction
            vAbrirFecharDAO.incAbrirFechar(mAbertura, connection, transacao)
            transacao.Commit()

            MsgBox("CAIXA Aberto com Sucesso!", MsgBoxStyle.Exclamation)
            rtb_motivo.Text = "" : rtb_motivo.ReadOnly = False
            cbo_tipo.Items.Clear()
            cbo_tipo.Items.Add("S= Saida Do Caixa")
            cbo_tipo.Items.Add("E= Entrada No Caixa")
            cbo_tipo.Items.Add("T= Troco")
            cbo_tipo.Items.Add("F= Fechamento")
            vAbrirFecharDAO.TrazCaixaAberto(vAbrirFecharAuxiliar, MdlConexaoBD.conectionPadrao)

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try


    End Sub

    Sub FechamentoDoCaixa()

        Dim mAbertura As New ClAbrirFecharCaixa(0, Date.Now, "A", False, 0, 0, vAbrirFecharAuxiliar.Af_id1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

        vAbrirFecharDAO.TrazCaixaAberto(mAbertura, MdlConexaoBD.conectionPadrao)
        mAbertura.Af_concluido1 = True
        vAbrirFecharDAO.altAbrirFechar(mAbertura, MdlConexaoBD.conectionPadrao)
        mAbertura.Af_tipo1 = "F"
        mAbertura.Af_datahora1 = Date.Now
        mAbertura.Af_id1 = 0
        mAbertura.Af_concluido1 = True
        'Totais Informado:
        mAbertura.Af_total_dinheiro1 = CDbl(txtInfoDinheiro.Text)
        mAbertura.Af_total_cartaocredito = CDbl(txtInfoCartaoCredito.Text)
        mAbertura.af_total_cartaodebito = CDbl(txtInfoCartaoDebito.Text)
        mAbertura.af_total_pix = CDbl(txtInfoPix.Text)
        mAbertura.af_total_transferencia = CDbl(txtInfoTransferencia.Text)
        mAbertura.af_total_crediario = CDbl(txtInfoCrediario.Text)
        mAbertura.Af_id_abertura1 = vAbrirFecharAuxiliar.Af_id1

        'Totais Apurado:
        mAbertura.Af_total_apurado_dn1 = CDbl(txtTotalApuradoDn.Text)
        mAbertura.Af_total_apurado_ctc = CDbl(txtTotalApuradoCtCredito.Text)
        mAbertura.af_total_apurado_ctd = CDbl(txtTotalApuradoCtDebito.Text)
        mAbertura.af_total_apurado_pix = CDbl(txtTotalApuradoPix.Text)
        mAbertura.af_total_apurado_tra = CDbl(txtTotalApuradoTransferencia.Text)
        mAbertura.af_total_apurado_crd = CDbl(txtTotalApuradoCrediario.Text)


        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction
            vAbrirFecharDAO.incAbrirFecharFechamento(mAbertura, connection, transacao)
            transacao.Commit()

            MsgBox("CAIXA Fechado com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            PreencheDtgVendasFinalizadas()
            PreencheDtgOperacoes()
            txtInfoCartaoCredito.Text = "0.00" : txtInfoDinheiro.Text = "0.00"
            txtInfoCartaoDebito.Text = "0.00" : txtInfoPix.Text = "0.00"
            txtInfoTransferencia.Text = "0.00" : txtInfoCrediario.Text = "0.00"
            txtTotalApuradoDn.Text = "0.00" : txtTotalApuradoCtCredito.Text = "0.00"
            txtTotalApuradoCtDebito.Text = "0.00" : txtTotalApuradoPix.Text = "0.00"
            txtTotalApuradoTransferencia.Text = "0.00" : txtTotalApuradoCrediario.Text = "0.00"
            txtTotalCTC.Text = "0.00" : txtTotalGeral.Text = "0,00"
            txtTotalCTD.Text = "0.00" : txtTotalPix.Text = "0.00"
            txtTotalTRA.Text = "0.00" : txtTotalDN.Text = "0.00"
            txtTotalCRD.Text = "0.00"
            dtgContasAReceber.Rows.Clear()
            txtQtdeAReceber.Text = "0" : txtTotGAReceber.Text = "0,00"
            txtTotalCTCaReceber.Text = "0.00"
            txtTotalCTDaReceber.Text = "0.00" : txtTotalPIXaReceber.Text = "0.00"
            txtTotalTRAaReceber.Text = "0.00" : txtTotalDNaReceber.Text = "0.00"

            rtb_motivo.Text = "" : rtb_motivo.ReadOnly = True
            cbo_tipo.Items.Clear()
            cbo_tipo.Items.Add("A= Abertura")
            cbo_tipo.SelectedIndex = 0
            zeraValores()
            rtb_motivo.Enabled = False

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try


    End Sub

    Sub InserirOperacao()
        Dim mAbertura As New ClAbrirFecharCaixa(0, Date.Now, "A", False, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        vAbrirFecharDAO.TrazCaixaAberto(vAbrirFechar, MdlConexaoBD.conectionPadrao)
        Dim mCaixa As ClCaixa
        Dim mTipo As String = cbo_tipo.SelectedItem.ToString.Substring(0, 1)

        If CDbl(txtInfoDinheiro.Text) > 0 Then 'Se o valor for em Dinheiro
            mCaixa = New ClCaixa(0, mTipo, Date.Now, rtb_motivo.Text, vAbrirFechar.Af_id1, CDbl(txtInfoDinheiro.Text), "DN")

        ElseIf CDbl(txtInfoCartaoCredito.Text) > 0 Then 'Se o valor for em Cartao Crédito
            mCaixa = New ClCaixa(0, mTipo, Date.Now, rtb_motivo.Text, vAbrirFechar.Af_id1, CDbl(txtInfoCartaoCredito.Text), "CTC")

        ElseIf CDbl(txtInfoCartaoDebito.Text) > 0 Then 'Se o valor for em Cartao Débito
            mCaixa = New ClCaixa(0, mTipo, Date.Now, rtb_motivo.Text, vAbrirFechar.Af_id1, CDbl(txtInfoCartaoDebito.Text), "CTD")

        ElseIf CDbl(txtInfoPix.Text) > 0 Then 'Se o valor for em PIX
            mCaixa = New ClCaixa(0, mTipo, Date.Now, rtb_motivo.Text, vAbrirFechar.Af_id1, CDbl(txtInfoPix.Text), "PIX")

        ElseIf CDbl(txtInfoTransferencia.Text) > 0 Then 'Se o valor for em Transferência
            mCaixa = New ClCaixa(0, mTipo, Date.Now, rtb_motivo.Text, vAbrirFechar.Af_id1, CDbl(txtInfoTransferencia.Text), "TRA")

        ElseIf CDbl(txtInfoCrediario.Text) > 0 Then 'Se o valor for em Crediário
            mCaixa = New ClCaixa(0, mTipo, Date.Now, rtb_motivo.Text, vAbrirFechar.Af_id1, CDbl(txtInfoCrediario.Text), "CRD")

        End If


        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction
            vCaixaDAO.incCaixa(mCaixa, connection, transacao)
            transacao.Commit()

            MsgBox("Operação Realizada com Sucesso!", MsgBoxStyle.Exclamation)
            rtb_motivo.Text = "" : rtb_motivo.ReadOnly = False
            txtInfoDinheiro.Text = "0.00" : txtInfoCartaoCredito.Text = "0.00"


        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try


    End Sub

    Sub PreencheDtgVendasFinalizadas()

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader
        Dim Where As String = ""

        Try

            Where = "WHERE vsdatahora >= '" & vAbrirFecharAuxiliar.Af_datahora1 & "' ORDER BY vsdatahora DESC"
            _VendaServicoDAO.TrazListVendaServicoBD(_ListaVendaServico, MdlConexaoBD.conectionPadrao, Where)

            For Each l As ClVendaServico In _ListaVendaServico
                dtgVendasCaixa.Rows.Add(l.vsclientenome, l.vsdatahora, _
                                        l.vstotalgeral.ToString("#,##0.00"), l.vspagodinheiro.ToString("#,##0.00"), l.vspagocredito.ToString("#,##0.00"), _
                                        l.vspagodebito.ToString("#,##0.00"), l.vspagopix.ToString("#,##0.00"), l.vspagotransferencia.ToString("#,##0.00"), _
                                        l.vspagocrediario.ToString("#,##0.00"))
            Next

            dtgVendasCaixa.Refresh()
            oConn.ClearPool() : oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT ao trazer VENDAS :: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try

        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)
        txtRegVendas.Text = "" : If dtgVendasCaixa.Rows.Count > 0 Then txtRegVendas.Text = dtgVendasCaixa.Rows.Count

        somaValoresVendas()
        somaValoresVendasDn()
        somaValoresVendasCTC()
        somaValoresVendasCTD()
        somaValoresVendasPIX()
        somaValoresVendasTRA()
        somaValoresVendasCRD()
        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing
    End Sub

    Sub PreencheDtgAReceberPagas()

        If vAbrirFecharAuxiliar.Af_id1 <= 0 Then Return
        Try

            _ListaAReceberTotal = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                ar.art_idcaixa = vAbrirFecharAuxiliar.Af_id1)

            _ListaAReceberParcial = MdlConexaoBD.mdlListAReceberParcial.FindAll(Function(ar As ClAReceberParcial) ar.arp_idcaixa = vAbrirFecharAuxiliar.Af_id1)


            Dim mListaAReceberPaga As New List(Of ClAReceberListCaixa)
            Dim mSomaValorParcial As Double = 0, mValorTotal As Double = 0
            Dim mSomaParcialDN As Double, mSomaParcialCTC As Double, mSomaParcialCTD As Double, mSomaParcialPIX As Double, mSomaParcialTRA As Double
            Dim mNomeCliente As String = ""

            For Each t As ClAReceberTotal In _ListaAReceberTotal

                mSomaValorParcial = 0
                mSomaParcialDN = 0
                mSomaParcialCTC = 0
                mSomaParcialCTD = 0
                mSomaParcialPIX = 0
                mSomaParcialTRA = 0
                For Each p As ClAReceberParcial In _ListaAReceberParcial

                    If p.arp_artid = t.art_id Then

                        mSomaValorParcial += p.arp_valortotal
                        mSomaParcialDN += p.arp_pagodinheiro
                        mSomaParcialCTC += p.arp_pagocartaocred
                        mSomaParcialCTD += p.arp_pagocartaodeb
                        mSomaParcialPIX += p.arp_pagopix
                        mSomaParcialTRA += p.arp_pagotransferencia
                    End If
                Next

                mValorTotal = t.art_valor - mSomaValorParcial

                mListaAReceberPaga.Add(New ClAReceberListCaixa(t.art_clientenome, "T", CDate(t.art_datapagamento), mValorTotal, _
                                    (t.art_pagodinheiro - mSomaParcialDN), (t.art_pagocartaocred - mSomaParcialCTC), _
                                    (t.art_pagocartaodeb - mSomaParcialCTD), (t.art_pagopix - mSomaParcialPIX), _
                                    (t.art_pagotransferencia - mSomaParcialTRA)))

            Next


            For Each p As ClAReceberParcial In _ListaAReceberParcial

                For Each t As ClAReceberTotal In MdlConexaoBD.ListaAReceberTotal

                    If t.art_id = p.arp_artid Then mNomeCliente = t.art_clientenome
                Next

                mListaAReceberPaga.Add(New ClAReceberListCaixa(mNomeCliente, "P", p.arp_datapagamento, p.arp_valortotal, p.arp_pagodinheiro, p.arp_pagocartaocred, _
                                                                    p.arp_pagocartaodeb, p.arp_pagopix, p.arp_pagotransferencia))

            Next

            mListaAReceberPaga.Sort(Function(a1 As ClAReceberListCaixa, a2 As ClAReceberListCaixa) a1.Data.CompareTo(a2.Data))


            dtgContasAReceber.Rows.Clear()
            For Each dt As ClAReceberListCaixa In mListaAReceberPaga

                dtgContasAReceber.Rows.Add(dt.Cliente, dt.Situacao, dt.Data, dt.Total.ToString("#,##0.00"), dt.Dinheiro.ToString("#,##0.00"), _
                                           dt.cartaoCredito.ToString("#,##0.00"), dt.cartaoDebito.ToString("#,##0.00"), _
                                           dt.Pix.ToString("#,##0.00"), dt.Transferencia.ToString("#,##0.00"))
            Next


            dtgVendasCaixa.Refresh()
        Catch ex As Exception
            MsgBox("ERRO no SELECT ao trazer Contas Pagas ARECEBER :: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try

        If dtgContasAReceber.Rows.Count > 0 Then txtQtdeAReceber.Text = dtgContasAReceber.Rows.Count

        txtTotGAReceber.Text = somaColunaDtg(3).ToString("#,##0.00")
        txtTotalDNaReceber.Text = somaColunaDtg(4).ToString("#,##0.00")
        txtTotalCTCaReceber.Text = somaColunaDtg(5).ToString("#,##0.00")
        txtTotalCTDaReceber.Text = somaColunaDtg(6).ToString("#,##0.00")
        txtTotalPIXaReceber.Text = somaColunaDtg(7).ToString("#,##0.00")
        txtTotalTRAaReceber.Text = somaColunaDtg(8).ToString("#,##0.00")

        'Limpa Objetos de Memoria...
    End Sub

    Function somaColunaDtg(indexCol As Integer) As Double

        Dim mSomaValores As Double = 0.0

        Try
            For Each dt As DataGridViewRow In dtgContasAReceber.Rows
                If dt.IsNewRow = False Then
                    mSomaValores += dt.Cells(indexCol).Value
                End If
            Next
        Catch ex As Exception
            mSomaValores = 0
        End Try

        Return mSomaValores
    End Function

    Sub somaValoresVendas()

        Dim mSomaValores As Double = 0.0
        For Each dt As DataGridViewRow In dtgVendasCaixa.Rows
            If dt.IsNewRow = False Then
                mSomaValores += dt.Cells(2).Value
            End If
        Next
        txtTotalGeral.Text = mSomaValores.ToString("#,##0.00")
    End Sub

    Sub somaValoresVendasDn()

        Dim mSomaValores As Double = 0.0
        For Each dt As DataGridViewRow In dtgVendasCaixa.Rows
            If dt.IsNewRow = False Then

                If (CDbl(dt.Cells(3).Value) > 0) Then
                    mSomaValores += dt.Cells(3).Value
                    dtgVendasCaixa.Rows(dt.Index).Cells(3).Style.ForeColor = System.Drawing.Color.MediumBlue
                    'Else
                    '    dtgVendasCaixa.Rows(dt.Index).Cells(3).Style.Font = New Font(
                End If
            End If
        Next
        txtTotalDN.Text = mSomaValores.ToString("#,##0.00")
    End Sub

    Sub somaValoresVendasCTC()

        Dim mSomaValores As Double = 0.0
        For Each dt As DataGridViewRow In dtgVendasCaixa.Rows
            If dt.IsNewRow = False Then

                If (CDbl(dt.Cells(4).Value) > 0) Then
                    mSomaValores += dt.Cells(4).Value
                    dtgVendasCaixa.Rows(dt.Index).Cells(4).Style.ForeColor = System.Drawing.Color.DarkRed
                End If
            End If
        Next
        txtTotalCTC.Text = mSomaValores.ToString("#,##0.00")
    End Sub

    Sub somaValoresVendasCTD()

        Dim mSomaValores As Double = 0.0
        For Each dt As DataGridViewRow In dtgVendasCaixa.Rows
            If dt.IsNewRow = False Then

                If (CDbl(dt.Cells(5).Value) > 0) Then
                    mSomaValores += dt.Cells(5).Value
                    dtgVendasCaixa.Rows(dt.Index).Cells(5).Style.ForeColor = System.Drawing.Color.DarkRed
                End If
            End If
        Next
        txtTotalCTD.Text = mSomaValores.ToString("#,##0.00")
    End Sub

    Sub somaValoresVendasPIX()

        Dim mSomaValores As Double = 0.0
        For Each dt As DataGridViewRow In dtgVendasCaixa.Rows
            If dt.IsNewRow = False Then

                If (CDbl(dt.Cells(6).Value) > 0) Then
                    mSomaValores += dt.Cells(6).Value
                    'dtgVendasCaixa.Rows(dt.Index).Cells(6).Style.ForeColor = System.Drawing.Color.MediumBlue
                End If
            End If
        Next
        txtTotalPix.Text = mSomaValores.ToString("#,##0.00")
    End Sub

    Sub somaValoresVendasTRA()

        Dim mSomaValores As Double = 0.0
        For Each dt As DataGridViewRow In dtgVendasCaixa.Rows
            If dt.IsNewRow = False Then

                If (CDbl(dt.Cells(7).Value) > 0) Then
                    mSomaValores += dt.Cells(7).Value
                    'dtgVendasCaixa.Rows(dt.Index).Cells(7).Style.ForeColor = System.Drawing.Color.MediumBlue
                End If
            End If
        Next
        txtTotalTRA.Text = mSomaValores.ToString("#,##0.00")
    End Sub

    Sub somaValoresVendasCRD()

        Dim mSomaValores As Double = 0.0
        For Each dt As DataGridViewRow In dtgVendasCaixa.Rows
            If dt.IsNewRow = False Then

                If (CDbl(dt.Cells(8).Value) > 0) Then
                    mSomaValores += dt.Cells(8).Value
                    dtgVendasCaixa.Rows(dt.Index).Cells(8).Style.ForeColor = System.Drawing.Color.Green
                End If
            End If
        Next
        txtTotalCRD.Text = mSomaValores.ToString("#,##0.00")
    End Sub


    Function somaValoresMovimentacoes(ByVal vTipoMov As String) As Double

        Dim mSomaValores As Double = 0.0
        For Each dt As DataGridViewRow In dtgOperacoesCaixa.Rows
            If dt.IsNewRow = False Then

                If dt.Cells(0).Value.ToString.Equals(vTipoMov) Then
                    mSomaValores += dt.Cells(2).Value
                    If vTipoMov.Equals("S") Then
                        dtgOperacoesCaixa.Rows(dt.Index).Cells(2).Style.ForeColor = System.Drawing.Color.Red
                    End If
                End If

            End If
        Next

        Return mSomaValores
    End Function

    Function somaValoresMovimentacoes(ByVal vTipoMov As String, ByVal vTipoValor As String) As Double

        Dim mSomaValores As Double = 0.0
        For Each dt As DataGridViewRow In dtgOperacoesCaixa.Rows
            If dt.IsNewRow = False Then

                If dt.Cells(0).Value.ToString.Equals(vTipoMov) And dt.Cells(4).Value.ToString.Equals(vTipoValor) Then
                    mSomaValores += dt.Cells(2).Value
                End If

            End If
        Next

        Return mSomaValores
    End Function

    Sub PreencheDtgOperacoes()

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader


        Try

            sql.Append("select cx_tipo, cx_datahora, cx_valor, cx_tipo_valor, cx_motivo from caixa where cx_af_id = ")
            sql.Append(vAbrirFecharAuxiliar.Af_id1 & " order by cx_datahora ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)

            dr = cmd.ExecuteReader

            dtgOperacoesCaixa.Rows.Clear()
            If dr.HasRows = False Then Return
            Dim mTelefone As String = ""
            While dr.Read
                dtgOperacoesCaixa.Rows.Add(dr(0).ToString, dr(1).ToString, CDbl(dr(2)).ToString("#,##0.00"), dr(4).ToString, dr(3).ToString)
            End While

            dtgOperacoesCaixa.Refresh() : dr.Close()
            oConn.ClearPool() : oConn.Close()
        Catch ex As Exception
            'MsgBox("ERRO no SELECT com a VIEW locacoes caixa :: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)
        txtTotMovEntradas.Text = somaValoresMovimentacoes("E").ToString("#,##0.00")
        txtTotMovSaidas.Text = somaValoresMovimentacoes("S").ToString("#,##0.00")
        txtTotMovTroco.Text = somaValoresMovimentacoes("T").ToString("#,##0.00")

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing

    End Sub

    'Text changed:
    Private Sub txtInfoDinheiro_TextChanged(sender As Object, e As EventArgs) Handles txtInfoDinheiro.TextChanged

        If IsNumeric(txtInfoDinheiro.Text) Then

            If CDbl(txtInfoDinheiro.Text) < 0 Then
                txtInfoCartaoCredito.Text = "0,00"
            End If
        End If
    End Sub

    Private Sub txtInfoCartaoCredito_TextChanged(sender As Object, e As EventArgs) Handles txtInfoCartaoCredito.TextChanged

        If IsNumeric(txtInfoCartaoCredito.Text) Then

            If CDbl(txtInfoCartaoCredito.Text) < 0 Then
                txtInfoDinheiro.Text = "0,00"
            End If

        End If
    End Sub

    Private Sub txtInfoCartaoDebito_TextChanged(sender As Object, e As EventArgs) Handles txtInfoCartaoDebito.TextChanged

        If IsNumeric(txtInfoCartaoDebito.Text) Then

            If CDbl(txtInfoCartaoDebito.Text) < 0 Then
                txtInfoCartaoDebito.Text = "0,00"
            End If
        End If
    End Sub

    Private Sub txtInfoPix_TextChanged(sender As Object, e As EventArgs) Handles txtInfoPix.TextChanged

        If IsNumeric(txtInfoPix.Text) Then

            If CDbl(txtInfoPix.Text) < 0 Then
                txtInfoPix.Text = "0,00"
            End If
        End If
    End Sub

    Private Sub txtInfoTransferencia_TextChanged(sender As Object, e As EventArgs) Handles txtInfoTransferencia.TextChanged

        If IsNumeric(txtInfoTransferencia.Text) Then

            If CDbl(txtInfoTransferencia.Text) < 0 Then
                txtInfoTransferencia.Text = "0,00"
            End If
        End If
    End Sub

    Private Sub txtInfoCrediario_TextChanged(sender As Object, e As EventArgs) Handles txtInfoCrediario.TextChanged

        If IsNumeric(txtInfoCrediario.Text) Then

            If CDbl(txtInfoCrediario.Text) < 0 Then
                txtInfoCrediario.Text = "0,00"
            End If
        End If
    End Sub

    Private Sub txtInfoDinheiro_Leave(sender As Object, e As EventArgs) Handles txtInfoDinheiro.Leave

        If IsNumeric(txtInfoDinheiro.Text) Then

            txtInfoDinheiro.Text = CDbl(txtInfoDinheiro.Text).ToString("#,##0.00")
        Else
            txtInfoDinheiro.Text = "0,00"
        End If
    End Sub

    Private Sub txtInfoCartao_Leave(sender As Object, e As EventArgs) Handles txtInfoCartaoCredito.Leave

        If IsNumeric(txtInfoCartaoCredito.Text) Then

            txtInfoCartaoCredito.Text = CDbl(txtInfoCartaoCredito.Text).ToString("#,##0.00")
        Else
            txtInfoCartaoCredito.Text = "0,00"
        End If
    End Sub

    Private Sub txtInfoCartaoDebito_Leave(sender As Object, e As EventArgs) Handles txtInfoCartaoDebito.Leave

        If IsNumeric(txtInfoCartaoDebito.Text) Then

            txtInfoCartaoDebito.Text = CDbl(txtInfoCartaoDebito.Text).ToString("#,##0.00")
        Else
            txtInfoCartaoDebito.Text = "0,00"
        End If
    End Sub

    Private Sub txtInfoPix_Leave(sender As Object, e As EventArgs) Handles txtInfoPix.Leave

        If IsNumeric(txtInfoPix.Text) Then

            txtInfoPix.Text = CDbl(txtInfoPix.Text).ToString("#,##0.00")
        Else
            txtInfoPix.Text = "0,00"
        End If
    End Sub

    Private Sub txtInfoTransferencia_Leave(sender As Object, e As EventArgs) Handles txtInfoTransferencia.Leave

        If IsNumeric(txtInfoTransferencia.Text) Then

            txtInfoTransferencia.Text = CDbl(txtInfoTransferencia.Text).ToString("#,##0.00")
        Else
            txtInfoTransferencia.Text = "0,00"
        End If
    End Sub

    Private Sub txtInfoCrediario_Leave(sender As Object, e As EventArgs) Handles txtInfoCrediario.Leave

        If IsNumeric(txtInfoCrediario.Text) Then

            txtInfoCrediario.Text = CDbl(txtInfoCrediario.Text).ToString("#,##0.00")
        Else
            txtInfoCrediario.Text = "0,00"
        End If
    End Sub

    Private Sub FrmCaixa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtInfoDinheiro_Click(sender As Object, e As EventArgs) Handles txtInfoDinheiro.Click
        txtInfoDinheiro.SelectAll()
    End Sub

    Private Sub txtInfoCartaoCredito_Click(sender As Object, e As EventArgs) Handles txtInfoCartaoCredito.Click
        txtInfoCartaoCredito.SelectAll()
    End Sub

    Private Sub txtInfoCartaoDebito_Click(sender As Object, e As EventArgs) Handles txtInfoCartaoDebito.Click
        txtInfoCartaoDebito.SelectAll()
    End Sub

    Private Sub txtInfoPix_Click(sender As Object, e As EventArgs) Handles txtInfoPix.Click
        txtInfoPix.SelectAll()
    End Sub

    Private Sub txtInfoTransferencia_Click(sender As Object, e As EventArgs) Handles txtInfoTransferencia.Click
        txtInfoTransferencia.SelectAll()
    End Sub

    Private Sub txtInfoCrediario_Click(sender As Object, e As EventArgs) Handles txtInfoCrediario.Click
        txtInfoCrediario.SelectAll()
    End Sub

#End Region
    
    Private Sub btnRecebimentoCliente_Click(sender As Object, e As EventArgs) Handles btnRecebimentoCliente.Click

        chamaFormAReceberCliente()
    End Sub

    Sub chamaFormAReceberCliente()

        Try
            If vAbrirFecharAuxiliar.Af_id1 <= 0 Then Return
        Catch ex As Exception
            Return
        End Try

        Dim frmRecebCli As New FrmContasAReceberCliente
        frmRecebCli._Caixa.SetaValores(vAbrirFecharAuxiliar)
        frmRecebCli.ShowDialog()
        If frmRecebCli._TeveBaixa Then PreencheDtgAReceberPagas()
        frmRecebCli = Nothing
    End Sub

    Private Sub dtgContasAReceber_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgContasAReceber.RowsAdded

        If dtgContasAReceber.Rows(e.RowIndex).Cells(4).Value > 0 Then
            dtgContasAReceber.Rows(e.RowIndex).Cells(4).Style.ForeColor = Color.MediumBlue
        End If

        If dtgContasAReceber.Rows(e.RowIndex).Cells(5).Value > 0 Then
            dtgContasAReceber.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.DarkRed
        End If

        If dtgContasAReceber.Rows(e.RowIndex).Cells(6).Value > 0 Then
            dtgContasAReceber.Rows(e.RowIndex).Cells(6).Style.ForeColor = Color.DarkRed
        End If
    End Sub
End Class