Imports Npgsql
Imports System.Text
Public Class FormMenuRelatorioCaixa

    Dim _funcoes As New ClFuncoes
    Dim _ListVendaServicos As New List(Of ClVendaServico)
    Dim _ListVendaServicoItens As New List(Of ClVendaServicoItens)
    Dim _ListVendaServicosAuxiliar As New List(Of ClVendaServico)
    Dim _ListVendaServicoItensAuxiliar As New List(Of ClVendaServicoItens)
    Dim _ListServico As New List(Of ClServicos)
    Dim _ListServicoDAO As New ClServicosDAO
    Dim _VendaServico As New ClVendaServico
    Dim _VendaServicoDAO As New ClVendaServicoDAO
    Dim lAbrirFecharTodos As New List(Of ClAbrirFecharCaixa)
    Dim lMovCaixaTodos As New List(Of ClCaixa)
    Dim lCaixasAbertos As New List(Of ClAbrirFecharCaixa)
    Dim lCaixasFechados As New List(Of ClAbrirFecharCaixa)
    Dim _ListaIntesVendaServico As New List(Of ClVendaServicoItens)
    Private _ListaAReceberTotal As New List(Of ClAReceberTotal)
    Private _ListaAReceberParcial As New List(Of ClAReceberParcial)
    Dim _AReceberTotalDAO As New ClAReceberTotalDAO
    Dim _AReceberParcialDAO As New ClAReceberParcialDAO
    Dim _ItemVendaServico As New ClVendaServicoItensDAO

    Dim ListCaixaMarcados As New List(Of ClAbrirFecharCaixa)
    Dim ListRelatorioCaixa As New List(Of ClRelatorioPadraoSTR)
    Dim ListOperacoesRelatorio As New List(Of ClRelatorioPadraoSTR)
    Dim ListVendasRelatorio As New List(Of ClRelatorioPadraoSTR)
    Dim ListRecebimentoClienteRelatorio As New List(Of ClRelatorioPadraoSTR)
    Dim RelatorioAux As New ClRelatorioPadraoSTR
    Dim CaixaRelatorio As New ClAbrirFecharCaixa
    Dim DaoCaixa As New ClAbrirFecharDAO


    Dim mIdCx As Int64 = 0
    Dim mDescricaoCx As String = ""
    'Totais para Relatório:
    Dim TotGeralOperacoes As Double = 0
    Dim TotGeralVendas As Double = 0
    Dim TotGeralRecebimentoCli As Double = 0
    Dim TotalDN As Double = 0, TotalCTC As Double = 0, TotalCTD As Double = 0, TotalPIX As Double = 0
    Dim TotalTRA As Double = 0, TotalCRD As Double = 0, TotalSubTotal As Double = 0
    Dim TotalSaidas As Double = 0, TotalEntradas As Double = 0, TotalTroco As Double = 0
    Dim TotalRecebimento As Double = 0, TotalGeral As Double = 0


    Private Sub FormMenuRelatorioCaixa_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                executaF5()

            Case Keys.F11
                executaF11()

        End Select
    End Sub

    Private Sub FormMenuRelatorioCaixa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FormMenuRelatorioCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TrazCaixas()
        preenchDtgCaixas()
    End Sub

    Sub executaF5()

        If validaBusca() Then
            TotGeralOperacoes = 0
            TotGeralRecebimentoCli = 0
            TotGeralVendas = 0
            configuraRelatorioBusca()
        End If

    End Sub

    Sub executaF11()

        If ListRelatorioCaixa.Count < 1 Then
            MsgBox("Gere Primeiro o Relatorio Por Favor! Clique em Buscar ou Verifique os Filtros da Busca!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Dim Formulario As New FormRelatorioCaixa
        Formulario._ListaRelatorioSTR = ListRelatorioCaixa
        Formulario.FiltroPeriodo = dtpInicio.Text & " A " & dtpFim.Text
        Formulario.TotalGeral = TotalGeral
        Formulario.SubTotal = TotalSubTotal
        Formulario.TotalDN = TotalDN
        Formulario.TotalCTC = TotalCTC
        Formulario.TotalCTD = TotalCTD
        Formulario.TotalPIX = TotalPIX
        Formulario.TotalTRA = TotalTRA
        Formulario.TotalCRD = TotalCRD
        Formulario.TotRecebimentoCli = TotalRecebimento
        Formulario.TotalEntradas = TotalEntradas
        Formulario.TotalSaidas = TotalSaidas
        Formulario.TotalTroco = TotalTroco
        Formulario.ShowDialog()
        Formulario = Nothing

    End Sub

    Sub PreencheListaVendasFinalizadas(caixa As ClAbrirFecharCaixa)

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

            Where = "WHERE vsdatahora >= '" & caixa.Af_datahora1 & "' ORDER BY vsdatahora DESC"
            _VendaServicoDAO.TrazListVendaServico(_ListVendaServicos, MdlConexaoBD.conectionPadrao, Where)

            RelatorioAux.zeraValores()
            If (ListVendasRelatorio.Count < 1) AndAlso (_ListVendaServicos.Count > 0) Then
                RelatorioAux.coluna1 = "VENDAS::"
                ListVendasRelatorio.Add(New ClRelatorioPadraoSTR(RelatorioAux))
            End If

            For Each l As ClVendaServico In _ListVendaServicos

                RelatorioAux.zeraValores()
                With RelatorioAux

                    .coluna1 = l.vsclientenome
                    .coluna2 = l.vsdatahora.ToShortDateString & " " & l.vsdatahora.ToShortTimeString
                    .coluna3 = l.vstotalgeral.ToString("#,##0.00")
                    TotGeralVendas += l.vstotalgeral
                    .coluna4 = l.vspagodinheiro.ToString("#,##0.00")
                    .coluna5 = l.vspagocredito.ToString("#,##0.00")
                    .coluna6 = l.vspagodebito.ToString("#,##0.00")
                    .coluna7 = l.vspagopix.ToString("#,##0.00")
                    .coluna8 = l.vspagotransferencia.ToString("#,##0.00")
                    .coluna9 = l.vspagocrediario.ToString("#,##0.00")
                End With
                ListVendasRelatorio.Add(New ClRelatorioPadraoSTR(RelatorioAux))

                'Soma os totais:
                TotalSubTotal += l.vstotalgeral
                TotalDN += l.vspagodinheiro
                TotalCTC += l.vspagocredito
                TotalCTD += l.vspagodebito
                TotalPIX += l.vspagopix
                TotalTRA += l.vspagotransferencia
                TotalCRD += l.vspagocrediario

            Next

            oConn.ClearPool() : oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT ao trazer VENDAS :: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try

        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing
    End Sub

    Sub PreencheListaAReceberPagas(caixa As ClAbrirFecharCaixa)

        If caixa.Af_id1 <= 0 Then Return
        Try

            _ListaAReceberTotal = MdlConexaoBD.mdlListAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                ar.art_idcaixa = caixa.Af_id1)

            _ListaAReceberParcial = MdlConexaoBD.mdlListAReceberParcial.FindAll(Function(ar As ClAReceberParcial) ar.arp_idcaixa = caixa.Af_id1)


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

                For Each t As ClAReceberTotal In MdlConexaoBD.mdlListAReceberTotal

                    If t.art_id = p.arp_artid Then mNomeCliente = t.art_clientenome
                Next

                mListaAReceberPaga.Add(New ClAReceberListCaixa(mNomeCliente, "P", p.arp_datapagamento, p.arp_valortotal, p.arp_pagodinheiro, p.arp_pagocartaocred, _
                                                                    p.arp_pagocartaodeb, p.arp_pagopix, p.arp_pagotransferencia))

            Next

            mListaAReceberPaga.Sort(Function(a1 As ClAReceberListCaixa, a2 As ClAReceberListCaixa) a1.Data.CompareTo(a2.Data))


            RelatorioAux.zeraValores()
            If (ListRecebimentoClienteRelatorio.Count < 1) AndAlso (mListaAReceberPaga.Count > 0) Then
                RelatorioAux.coluna1 = "Recebimento de Cliente::"
                ListRecebimentoClienteRelatorio.Add(New ClRelatorioPadraoSTR(RelatorioAux))
            End If
            For Each dt As ClAReceberListCaixa In mListaAReceberPaga

                RelatorioAux.zeraValores()

                With RelatorioAux

                    .coluna1 = dt.Cliente
                    .coluna2 = dt.Data.ToShortDateString & " " & dt.Data.ToShortTimeString
                    .coluna3 = dt.Total.ToString("#,##0.00")
                    TotGeralRecebimentoCli += dt.Total
                    .coluna4 = dt.Dinheiro.ToString("#,##0.00")
                    .coluna5 = dt.cartaoCredito.ToString("#,##0.00")
                    .coluna6 = dt.cartaoDebito.ToString("#,##0.00")
                    .coluna7 = dt.Pix.ToString("#,##0.00")
                    .coluna8 = dt.Transferencia.ToString("#,##0.00")

                End With
                ListRecebimentoClienteRelatorio.Add(New ClRelatorioPadraoSTR(RelatorioAux))

                'Soma os totais:
                TotalSubTotal += dt.Total
                TotalRecebimento += dt.Total
                TotalDN += dt.Dinheiro
                TotalCTC += dt.cartaoCredito
                TotalCTD += dt.cartaoDebito
                TotalPIX += dt.Pix
                TotalTRA += dt.Transferencia

            Next

        Catch ex As Exception
            MsgBox("ERRO no SELECT ao trazer Contas Pagas ARECEBER :: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try

        'Limpa Objetos de Memoria...
    End Sub

    Sub PreencheListaOperacoes(caixa As ClAbrirFecharCaixa)

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
            sql.Append(caixa.Af_id1 & " order by cx_datahora ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)

            dr = cmd.ExecuteReader

            If dr.HasRows = False Then Return
            RelatorioAux.zeraValores()
            If (ListOperacoesRelatorio.Count < 1) AndAlso dr.HasRows Then
                RelatorioAux.coluna1 = "Movimentaçoes do Caixa:: "
                ListOperacoesRelatorio.Add(New ClRelatorioPadraoSTR(RelatorioAux))
            End If

            Dim mTelefone As String = ""
            While dr.Read
                RelatorioAux.zeraValores()

                With RelatorioAux

                    .coluna1 = dr(0).ToString & " - " & dr(4).ToString
                    .coluna2 = CDate(dr(1)).ToShortDateString & " " & CDate(dr(1)).ToShortTimeString
                    .coluna3 = CDbl(dr(2)).ToString("#,##0.00")
                    TotGeralOperacoes += dr(2)
                    .coluna4 = dr(3).ToString

                End With
                ListOperacoesRelatorio.Add(New ClRelatorioPadraoSTR(RelatorioAux))

                'Soma os totais:
                Select Case dr(0).ToString
                    Case "E" 'Entradas
                        TotalEntradas += dr(2)
                        TotalSubTotal += dr(2)
                    Case "S" 'Saidas
                        TotalSaidas += dr(2)
                        TotalSubTotal -= dr(2)
                    Case "T" 'Troco
                        TotalTroco = dr(2)
                        TotalSubTotal += dr(2)
                End Select

                Select Case dr(3).ToString
                    Case "DN"
                        TotalDN += dr(2)
                    Case "CTC"
                        TotalCTC += dr(2)
                    Case "CTD"
                        TotalCTD += dr(2)
                    Case "PIX"
                        TotalPIX += dr(2)
                    Case "TRA"
                        TotalTRA += dr(2)
                    Case "CRD"
                        TotalCRD += dr(2)
                End Select


            End While

            dr.Close()
            oConn.ClearPool() : oConn.Close()
        Catch ex As Exception
            'MsgBox("ERRO no SELECT com a VIEW locacoes caixa :: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing

    End Sub

    Sub configuraRelatorioBusca()

        'Limpa as Listas:
        ListRelatorioCaixa.Clear()
        dtgRelatorioCaixa.Rows.Clear()
        ListVendasRelatorio.Clear()
        ListRecebimentoClienteRelatorio.Clear()
        ListOperacoesRelatorio.Clear()

        'Limpa Totais:
        TotalSubTotal = 0 : TotalDN = 0 : TotalCTC = 0 : TotalCTD = 0 : TotalPIX = 0 : TotalTRA = 0 : TotalCRD = 0
        TotalEntradas = 0 : TotalSaidas = 0 : TotalTroco = 0 : TotalRecebimento = 0

        If ListCaixaMarcados.Count > 0 Then

            For Each l As ClAbrirFecharCaixa In ListCaixaMarcados


                If rdbTodos.Checked Then
                    PreencheListaVendasFinalizadas(l)
                    PreencheListaAReceberPagas(l)
                    PreencheListaOperacoes(l)
                End If

                If rdbVendas.Checked Then PreencheListaVendasFinalizadas(l)
                If rdbRecebimentoCli.Checked Then PreencheListaAReceberPagas(l)
                If rdbMovCaixa.Checked Then PreencheListaOperacoes(l)

            Next

            If ListVendasRelatorio.Count > 0 Then
                For Each v As ClRelatorioPadraoSTR In ListVendasRelatorio
                    ListRelatorioCaixa.Add(New ClRelatorioPadraoSTR(v))
                Next
                RelatorioAux.zeraValores()
                With RelatorioAux
                    .coluna1 = "Totais:     ----------> "
                    .coluna3 = TotGeralVendas.ToString("#,##0.00")
                End With
                ListRelatorioCaixa.Add(New ClRelatorioPadraoSTR(RelatorioAux))
            End If

            If ListRecebimentoClienteRelatorio.Count > 0 Then
                If ListVendasRelatorio.Count > 0 Then
                    RelatorioAux.zeraValores()
                    ListRelatorioCaixa.Add(New ClRelatorioPadraoSTR(RelatorioAux))
                End If
                For Each r As ClRelatorioPadraoSTR In ListRecebimentoClienteRelatorio
                    ListRelatorioCaixa.Add(New ClRelatorioPadraoSTR(r))
                Next
                RelatorioAux.zeraValores()
                With RelatorioAux
                    .coluna1 = "Totais:     ----------> "
                    .coluna3 = TotGeralRecebimentoCli.ToString("#,##0.00")
                End With
                ListRelatorioCaixa.Add(New ClRelatorioPadraoSTR(RelatorioAux))
            End If

            If ListOperacoesRelatorio.Count > 0 Then

                If ListVendasRelatorio.Count > 0 OrElse ListRecebimentoClienteRelatorio.Count > 0 Then
                    RelatorioAux.zeraValores()
                    ListRelatorioCaixa.Add(New ClRelatorioPadraoSTR(RelatorioAux))
                End If

                For Each o As ClRelatorioPadraoSTR In ListOperacoesRelatorio
                    ListRelatorioCaixa.Add(New ClRelatorioPadraoSTR(o))
                Next
                RelatorioAux.zeraValores()
                With RelatorioAux
                    .coluna1 = "Totais:     ----------> "
                    .coluna3 = TotGeralOperacoes.ToString("#,##0.00")
                End With
                ListRelatorioCaixa.Add(New ClRelatorioPadraoSTR(RelatorioAux))
            End If

            TotalGeral = (TotalSubTotal + TotalEntradas + TotalTroco) - TotalSaidas

            For Each rl As ClRelatorioPadraoSTR In ListRelatorioCaixa
                dtgRelatorioCaixa.Rows.Add(rl.coluna1, rl.coluna2, rl.coluna3, rl.coluna4, rl.coluna5, rl.coluna6, rl.coluna7, rl.coluna8, rl.coluna9)
            Next
        End If

    End Sub

    Function validaBusca() As Boolean

        If dtpInicio.Text > dtpFim.Text Then
            MsgBox("Data Inicial dever Menor ou Igual a Data Final!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            dtpInicio.Focus()
            Return False
        End If

        If verificaCaixasMarcados(ListCaixaMarcados) = False Then

            dtgRelatorioCaixa.Rows.Clear()
            MsgBox("Selecione um Caixa para o Relatório! Por Favor!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            dtpInicio.Focus()
            Return False
        End If


        Return True
    End Function

    Function verificaCaixasMarcados(ByRef caixas As List(Of ClAbrirFecharCaixa)) As Boolean

        Dim DeuCerto As Boolean = False
        caixas.Clear()
        For Each r As DataGridViewRow In dtgCaixas.Rows

            If r.IsNewRow = False Then

                If r.Cells(1).Value Then

                    CaixaRelatorio.zeraValores()
                    CaixaRelatorio.Af_id1 = r.Cells(0).Value
                    DaoCaixa.TrazAbrirFechar(CaixaRelatorio, MdlConexaoBD.conectionPadrao)
                    caixas.Add(New ClAbrirFecharCaixa(CaixaRelatorio))
                    DeuCerto = True
                End If
            End If
        Next

        Return DeuCerto
    End Function

    Sub MarcaDesmarcaCaixas()

        For Each r As DataGridViewRow In dtgCaixas.Rows

            If r.IsNewRow = False Then
                r.Cells(1).Value = chkMarcarTodosCaixas.Checked
            End If
        Next
    End Sub

    Function validaData() As Boolean

        If dtpInicio.Text > dtpFim.Text Then
            MsgBox("Data Inicial dever Menor ou Igual a Data Final!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            dtpInicio.Focus()
            Return False
        End If

        Return True
    End Function

    Sub TrazCaixas()

        Dim mAbrirFecharDAO As New ClAbrirFecharDAO
        Dim mCaixaDAO As New ClCaixaDAO
        Dim mLocacoes As New ClMovimentacaoDAO

        mAbrirFecharDAO.TrazListAbriFechar(lAbrirFecharTodos, MdlConexaoBD.conectionPadrao)
        mCaixaDAO.TrazListCaixas(lMovCaixaTodos, MdlConexaoBD.conectionPadrao)

    End Sub

    Sub BuscaCaixaPorPeriodo()

        Dim mAbrirFecharDAO As New ClAbrirFecharDAO
        Dim Where As String = "WHERE to_char(af_datahora,'DD/MM/YYYY') BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "
        lAbrirFecharTodos.Clear()
        mAbrirFecharDAO.TrazListAbriFecharWHERE(lAbrirFecharTodos, MdlConexaoBD.conectionPadrao, Where)

        'Caixas Abertos:
        lCaixasAbertos.Clear()
        For Each cx As ClAbrirFecharCaixa In lAbrirFecharTodos
            If cx.Af_tipo1.Equals("A") AndAlso cx.Af_concluido1 = False Then lCaixasAbertos.Add(cx)
        Next

        'Caixas Fechados:
        lCaixasFechados.Clear()
        For Each cx As ClAbrirFecharCaixa In lAbrirFecharTodos
            If cx.Af_tipo1.Equals("F") Then lCaixasFechados.Add(cx)
        Next
    End Sub

    Sub preenchDtgCaixas()

        If validaData() Then

            'Busca os caixa por Data
            BuscaCaixaPorPeriodo()

            If lCaixasAbertos.Count <= 0 Then MsgBox("Não Existe Caixas Nesse Período!") : Return
            dtgCaixas.Rows.Clear()
            For Each cx As ClAbrirFecharCaixa In lCaixasAbertos

                mIdCx = cx.Af_id1
                mDescricaoCx = cx.Af_datahora1.ToLongTimeString & "   Caixa Não Fechado..."

                dtgCaixas.Rows.Add(mIdCx, chkMarcarTodosCaixas.Checked, mDescricaoCx)
            Next

            For Each cx As ClAbrirFecharCaixa In lCaixasFechados

                mIdCx = cx.Af_id_abertura1
                mDescricaoCx = cx.Af_datahora1.ToLongTimeString & " (Fechado: " & cx.Af_datahora1.ToString & ")"

                dtgCaixas.Rows.Add(mIdCx, chkMarcarTodosCaixas.Checked, mDescricaoCx)
            Next
        End If

    End Sub

    Private Sub chkMarcarTodosCaixas_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarcarTodosCaixas.CheckedChanged
        MarcaDesmarcaCaixas()
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpInicio.ValueChanged, dtpFim.ValueChanged
        preenchDtgCaixas()
    End Sub

    Private Sub dtgCaixas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCaixas.CellContentClick

        If e.ColumnIndex = 1 Then

            If dtgCaixas.Rows(e.RowIndex).Cells(1).Value = True Then
                dtgCaixas.Rows(e.RowIndex).Cells(1).Value = False
            Else
                dtgCaixas.Rows(e.RowIndex).Cells(1).Value = True
            End If
        End If
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        executaF5()
    End Sub

    Private Sub dtgRelatorioCaixa_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgRelatorioCaixa.RowsAdded
        somaValoresDtg()
    End Sub

    Private Sub dtgRelatorioCaixa_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgRelatorioCaixa.RowsRemoved
        somaValoresDtg()
    End Sub

    Sub somaValoresDtg()

        Dim SomaDN As Double = 0, SomaCTC As Double = 0, SomaCTD As Double = 0, SomaPIX As Double = 0, SomaTRA As Double = 0, SomaCRD As Double = 0

        For Each rl As ClRelatorioPadraoSTR In ListRelatorioCaixa

            If IsNumeric(rl.coluna4) Then SomaDN += CDbl(rl.coluna4)
            If IsNumeric(rl.coluna5) Then SomaCTC += CDbl(rl.coluna5)
            If IsNumeric(rl.coluna6) Then SomaCTD += CDbl(rl.coluna6)
            If IsNumeric(rl.coluna7) Then SomaPIX += CDbl(rl.coluna7)
            If IsNumeric(rl.coluna8) Then SomaTRA += CDbl(rl.coluna8)
            If IsNumeric(rl.coluna9) Then SomaCRD += CDbl(rl.coluna9)
        Next

        txtTotaisVendasDN.Text = SomaDN.ToString("#,##0.00")
        txtTotaisVendasCTC.Text = SomaCTC.ToString("#,##0.00")
        txtTotaisVendasCTD.Text = SomaCTD.ToString("#,##0.00")
        txtTotaisVendasPIX.Text = SomaPIX.ToString("#,##0.00")
        txtTotaisVendasTRA.Text = SomaTRA.ToString("#,##0.00")
        txtTotaisVendasCRD.Text = SomaCRD.ToString("#,##0.00")
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

End Class