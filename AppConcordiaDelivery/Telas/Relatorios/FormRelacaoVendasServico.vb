Public Class FormRelacaoVendasServico

    Dim _Cliente As New ClCliente
    Dim _Produto As New ClProduto
    Dim _Servico As New ClServicos
    Dim _Atendente As New ClAtendente
    Dim _VendaServicoPesq As New ClVendaServico

    Dim _ListaItensVendaServicoPesq As New List(Of ClVendaServicoItens)
    Dim _ListaProdutosUsadosVendaPesq As New List(Of ClProdutoUsadoVenda)
    Dim _ListaVendaServicoPesq As New List(Of ClVendaServico)

    Dim _VendaServicoDAO As New ClVendaServicoDAO
    Dim _ServicoDAO As New ClServicosDAO
    Dim _ClienteDAO As New ClClienteDAO
    Dim _ProdutoDAO As New ClProdutoDAO
    Dim _AtententeDAO As New ClAtendenteDAO
    Dim _ItenVendaServicoDAO As New ClVendaServicoItensDAO
    Dim _ProdutoUsadoVendaDAO As New ClProdutoUsadoVendaDAO

    Dim _Relatorio As New ClRelatorioPadraoSTR
    Dim _RelatorioLista As New List(Of ClRelatorioPadraoSTR)
    Dim _RelatorioServicosVendaItens As New List(Of ClVendaServicoItens)

    'Filtros:
    Dim FiltroServico As String = ""
    Dim FiltroCliente As String = ""
    Dim FiltroAtendente As String = ""
    Dim FiltroData As String = ""

    'Somas:
    Dim qtdeVendas As Integer = 0, qtdeServicos As Integer = 0, SomaTotalGeral As Double = 0
    'Totais:
    Dim SubTotal As Double = 0, TotDesconto As Double = 0, TotDN As Double = 0, TotCTC As Double = 0, TotCTD As Double = 0, TotPIX As Double = 0
    Dim TotTRA As Double = 0, TotCRD As Double = 0

    Private Sub FormRelacaoVendasServico_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                ExecutaF5()
            Case Keys.F11
                executaF11()
        End Select
    End Sub

    Private Sub FormRelacaoVendasServico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FormRelacaoVendasServico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If MdlConexaoBD.sincronizado Then
            _ServicoDAO.PreencheCboServicosLista(cboSevico, MdlConexaoBD.ListaServicos)
            _AtententeDAO.PreencheCboAtendentesListaPesquisa(cboAtendente, MdlConexaoBD.ListaAtendentes)
        Else
            _ServicoDAO.PreencheCboServicosBD(cboSevico, MdlConexaoBD.conectionPadrao)
            _AtententeDAO.PreencheCboAtendentesListaPesquisa(cboAtendente, MdlConexaoBD.ListaAtendentes)
        End If

        ExecutaF5()

    End Sub

    Private Sub cboSevico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSevico.SelectedIndexChanged

        _Servico.ZeraValores()
        If cboSevico.SelectedIndex > -1 Then 'Foi selecionado algum serviço:

            _Servico.sdescricao = cboSevico.SelectedItem
            If _ServicoDAO.TrazServicoNomeDaLista(_Servico) = False Then
                MsgBox("Selecione um Serviço!") : cboSevico.Focus() : cboSevico.DroppedDown = True
                Return
            End If
            ExecutaF5()
        End If

    End Sub

    Private Sub cboAtendente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAtendente.SelectedIndexChanged

        _Atendente.ZeraValores()
        Try
            If cboAtendente.SelectedIndex > -1 Then
                _Atendente.aNome = cboAtendente.SelectedItem.ToString
                _AtententeDAO.TrazAtendenteNomeDaLista(_Atendente, MdlConexaoBD.ListaAtendentes)
            End If
        Catch ex As Exception
        Finally
            If _Atendente.aId > 0 Then
                ExecutaF5()
            End If
        End Try

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
        Else

            txtIdCliente.Text = _Cliente.cid
            txtNomeCliente.Text = _Cliente.cnome
            txtNomeCliente.Focus()
        End If
        ExecutaF5()

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


#Region "   Pesquisa dos Serviços"

    Sub executaF11()

        _RelatorioLista.Clear()
        qtdeServicos = 0 : qtdeVendas = 0 : SomaTotalGeral = 0
        SubTotal = 0 : TotDesconto = 0 : TotDN = 0 : TotCTC = 0 : TotCTD = 0 : TotPIX = 0 : TotTRA = 0 : TotCRD = 0

        If _ListaVendaServicoPesq.Count > 0 Then

            FiltroServico = _Servico.sdescricao
            FiltroCliente = _Cliente.cnome
            FiltroAtendente = _Atendente.aNome
            FiltroData = dtpInicio.Text & " A " & dtpFim.Text


            If chkImprServicos.Checked Then 'TOTAIS E SERVIÇOS DA VENDA SERVIÇO:

                _RelatorioServicosVendaItens.Clear()
                For Each vs As ClVendaServico In _ListaVendaServicoPesq

                    _Relatorio.zeraValores()
                    With _Relatorio

                        .coluna1 = vs.vsclientenome.ToUpper
                        .coluna2 = vs.vsdatahora.ToShortDateString & " " & vs.vsdatahora.ToShortTimeString
                        .coluna3 = vs.vstotalgeral.ToString("#,##0.00")
                        .coluna4 = vs.vsdesconto.ToString("#,##0.00")
                        .coluna5 = vs.vssubtotal.ToString("#,##0.00")
                        .coluna6 = vs.vspagodinheiro.ToString("#,##0.00")
                        .coluna7 = vs.vspagocredito.ToString("#,##0.00")
                        .coluna8 = vs.vspagodebito.ToString("#,##0.00")
                        .coluna9 = vs.vspagopix.ToString("#,##0.00")
                        .coluna10 = vs.vspagotransferencia.ToString("#,##0.00")
                        .coluna11 = vs.vspagocrediario.ToString("#,##0.00")
                    End With
                    SomaTotalGeral += vs.vstotalgeral
                    TotDesconto += vs.vsdesconto
                    SubTotal += vs.vssubtotal
                    TotDN += vs.vspagodinheiro
                    TotCTC += vs.vspagocredito
                    TotCTD += vs.vspagodebito
                    TotPIX += vs.vspagopix
                    TotTRA += vs.vspagotransferencia
                    TotCRD += vs.vspagocrediario
                    qtdeVendas += 1
                    _RelatorioLista.Add(New ClRelatorioPadraoSTR(_Relatorio))
                    '***********************************************************

                    'SERVIÇOS:
                    If MdlConexaoBD.sincronizado Then
                        _ItenVendaServicoDAO.TrazListItensVendaServico_LISTA(vs, _RelatorioServicosVendaItens, MdlConexaoBD.ListaVendaServicoItens)
                    Else
                        _ItenVendaServicoDAO.TrazListItensVendaServicoBD(vs, _RelatorioServicosVendaItens, MdlConexaoBD.conectionPadrao)
                    End If

                    If _RelatorioServicosVendaItens.Count > 0 Then

                        For Each vsi As ClVendaServicoItens In _RelatorioServicosVendaItens

                            _Relatorio.zeraValores()
                            With _Relatorio

                                .coluna1 = "* " & vsi.NomeServico.ToUpper
                                .coluna2 = vsi.NomeAtendente.ToUpper
                                .coluna3 = vsi.ValorTotalServico.ToString("#,##0.00")
                                .coluna4 = vsi.DescontoServico.ToString("#,##0.00")
                                .coluna5 = vsi.SubTotalServico.ToString("#,##0.00")
                                .coluna6 = vsi.QuantidadeServico.ToString("#,##0.00")
                            End With
                            qtdeServicos += vsi.QuantidadeServico
                            _RelatorioLista.Add(New ClRelatorioPadraoSTR(_Relatorio))

                        Next
                    End If

                Next



            Else ' SOME OS TOTAIS DA VENDA SERVIÇO:

                For Each vs As ClVendaServico In _ListaVendaServicoPesq

                    _Relatorio.zeraValores()
                    With _Relatorio

                        .coluna1 = vs.vsclientenome.ToUpper
                        .coluna2 = vs.vsdatahora.ToShortDateString & " " & vs.vsdatahora.ToShortTimeString
                        .coluna3 = vs.vstotalgeral.ToString("#,##0.00")
                        .coluna4 = vs.vsdesconto.ToString("#,##0.00")
                        .coluna5 = vs.vssubtotal.ToString("#,##0.00")
                        .coluna6 = vs.vspagodinheiro.ToString("#,##0.00")
                        .coluna7 = vs.vspagocredito.ToString("#,##0.00")
                        .coluna8 = vs.vspagodebito.ToString("#,##0.00")
                        .coluna9 = vs.vspagopix.ToString("#,##0.00")
                        .coluna10 = vs.vspagotransferencia.ToString("#,##0.00")
                        .coluna11 = vs.vspagocrediario.ToString("#,##0.00")
                    End With
                    SomaTotalGeral += vs.vstotalgeral
                    TotDesconto += vs.vsdesconto
                    SubTotal += vs.vssubtotal
                    TotDN += vs.vspagodinheiro
                    TotCTC += vs.vspagocredito
                    TotCTD += vs.vspagodebito
                    TotPIX += vs.vspagopix
                    TotTRA += vs.vspagotransferencia
                    TotCRD += vs.vspagocrediario
                    qtdeVendas += 1
                    _RelatorioLista.Add(New ClRelatorioPadraoSTR(_Relatorio))
                Next
            End If


            Dim Formulario As New FormRelatorioVendaServicos
            Formulario._FiltroServico = FiltroServico
            Formulario._FiltroCliente = FiltroCliente
            Formulario._FiltroAtendente = FiltroAtendente
            Formulario._FiltroData = FiltroData
            Formulario._ListaServicos = _RelatorioLista
            Formulario._QtdeServicos = qtdeServicos
            Formulario._QtdeVendas = qtdeVendas
            Formulario.SomaTotalGeral = SomaTotalGeral
            Formulario.SubTotal = SubTotal
            Formulario.TotDesconto = TotDesconto
            Formulario.TotDN = TotDN
            Formulario.TotCTC = TotCTC
            Formulario.TotCTD = TotCTD
            Formulario.TotPIX = TotPIX
            Formulario.TotTRA = TotTRA
            Formulario.TotCRD = TotCRD

            Formulario.ShowDialog()
            Formulario = Nothing
        End If



    End Sub

    Sub executaF5_BD()

        _ListaVendaServicoPesq.Clear()
        Dim where As String = ""

        If Date.Compare(dtpFim.Text, dtpInicio.Text) < 0 Then
            MsgBox("Data Inicial deve ser Menor ou Igual a Data Final", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        where = "WHERE TO_CHAR(vsdatahora, 'DD/MM/YYYY') BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "

        If _Cliente.cid > 0 Then

            where += "AND vsclienteid = " & _Cliente.cid & " "
        End If

        If _Servico.sid > 0 Then
            where += "AND vsi.vsi_servicoid = " & _Servico.sid & " "
        End If

        If _Atendente.aId > 0 Then
            where += "AND vsi.vsi_atendenteid = " & _Atendente.aId & " "
        End If

        where += "ORDER BY vsdatahora DESC"
        _VendaServicoDAO.TrazListVendaServicoJOIN_Servico(_ListaVendaServicoPesq, MdlConexaoBD.conectionPadrao, where)

        dtgVendasServico.Rows.Clear()
        dtgItensVendaServico.Rows.Clear()
        If _ListaVendaServicoPesq.Count > 0 Then

            For Each vs As ClVendaServico In _ListaVendaServicoPesq
                dtgVendasServico.Rows.Add(vs.vsid, vs.vsclientenome.ToUpper, vs.vsdatahora, vs.vstotalgeral.ToString("#,##0.00"), vs.vsdesconto.ToString("#,##0.00"), vs.vssubtotal.ToString("#,##0.00"), vs.vspagodinheiro.ToString("#,##0.00"), vs.vspagocredito.ToString("#,##0.00"), vs.vspagodebito.ToString("#,##0.00"), vs.vspagopix.ToString("#,##0.00"), vs.vspagotransferencia.ToString("#,##0.00"), vs.vspagocrediario.ToString("#,##0.00"))
            Next
        End If

    End Sub

    Sub executaF5_Sincronizado()

        _ListaVendaServicoPesq.Clear()

        If Date.Compare(dtpFim.Text, dtpInicio.Text) < 0 Then
            MsgBox("Data Inicial deve ser Menor ou Igual a Data Final", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        _ListaVendaServicoPesq = _VendaServicoDAO.trazListaVendaServico_LISTA(MdlConexaoBD.ListaVendaServico)

        _ListaVendaServicoPesq = _ListaVendaServicoPesq.FindAll(Function(vs As ClVendaServico) vs.vsdatahora.ToShortDateString >= dtpInicio.Text And _
                                                                    vs.vsdatahora.ToShortDateString <= dtpFim.Text)

        If _Cliente.cid > 0 Then
            _ListaVendaServicoPesq = _ListaVendaServicoPesq.FindAll(Function(vs As ClVendaServico) vs.vsclienteid = _Cliente.cid)

        End If

        If _Servico.sid > 0 Then
            _ListaVendaServicoPesq = _VendaServicoDAO.trazListaVendaServicoJOIN_Itens_LISTA(_ListaVendaServicoPesq, MdlConexaoBD.ListaVendaServicoItens, _
                                                    _Servico.sid)
        End If

        If _Atendente.aId > 0 Then
            _ListaVendaServicoPesq = _VendaServicoDAO.trazListaVendaServicoJOIN_Itens_LISTA(_ListaVendaServicoPesq, MdlConexaoBD.ListaVendaServicoItens, _
                                                    0, _Atendente.aId)
        End If

        _ListaVendaServicoPesq.Sort(Function(vs1 As ClVendaServico, vs2 As ClVendaServico) vs1.vsdatahora = vs2.vsdatahora)

        dtgVendasServico.Rows.Clear()
        dtgItensVendaServico.Rows.Clear()
        If _ListaVendaServicoPesq.Count > 0 Then

            For Each vs As ClVendaServico In _ListaVendaServicoPesq
                dtgVendasServico.Rows.Add(vs.vsid, vs.vsclientenome.ToUpper, vs.vsdatahora, vs.vstotalgeral.ToString("#,##0.00"), vs.vsdesconto.ToString("#,##0.00"), vs.vssubtotal.ToString("#,##0.00"), vs.vspagodinheiro.ToString("#,##0.00"), vs.vspagocredito.ToString("#,##0.00"), vs.vspagodebito.ToString("#,##0.00"), vs.vspagopix.ToString("#,##0.00"), vs.vspagotransferencia.ToString("#,##0.00"), vs.vspagocrediario.ToString("#,##0.00"))
            Next
        End If

    End Sub

    Sub ExecutaF5()

        If cboSevico.Text.Equals("") Then _Servico.ZeraValores()

        If MdlConexaoBD.sincronizado Then
            executaF5_Sincronizado()
        Else
            executaF5_BD()
        End If

    End Sub

    Sub AtualizaBuscaServicosVenda()

        _ListaItensVendaServicoPesq.Clear()
        _VendaServicoPesq.ZeraValores()
        _VendaServicoPesq.vsid = dtgVendasServico.Rows(dtgVendasServico.CurrentRow.Index).Cells(0).Value
        If MdlConexaoBD.sincronizado Then
            _ItenVendaServicoDAO.TrazListItensVendaServico_LISTA(_VendaServicoPesq, _ListaItensVendaServicoPesq, MdlConexaoBD.ListaVendaServicoItens)
        Else
            _ItenVendaServicoDAO.TrazListItensVendaServicoBD(_VendaServicoPesq, _ListaItensVendaServicoPesq, MdlConexaoBD.conectionPadrao)
        End If


        dtgItensVendaServico.Rows.Clear()
        If _ListaItensVendaServicoPesq.Count > 0 Then

            For Each vsi As ClVendaServicoItens In _ListaItensVendaServicoPesq
                dtgItensVendaServico.Rows.Add(vsi.Id, vsi.NomeServico.ToUpper, vsi.QuantidadeServico.ToString("#,##0.00"), vsi.ValorTotalServico.ToString("#,##0.00"), vsi.DescontoServico.ToString("#,##0.00"), vsi.SubTotalServico.ToString("#,##0.00"), vsi.NomeAtendente.ToUpper)
            Next
        End If
    End Sub

    Sub AtualizaBuscaProdutosDaVendaServico()

        _ListaProdutosUsadosVendaPesq.Clear()
        _VendaServicoPesq.vsid = dtgVendasServico.Rows(dtgVendasServico.CurrentRow.Index).Cells(0).Value
        If MdlConexaoBD.sincronizado Then
            '
        Else
            _ProdutoUsadoVendaDAO.TrazListProdutoUsadoVenda(_VendaServicoPesq, _ListaProdutosUsadosVendaPesq, MdlConexaoBD.conectionPadrao)
        End If


        If _ListaProdutosUsadosVendaPesq.Count > 0 Then

            Dim frmMostraProdutos As New FrmMostraProdutoVenda
            frmMostraProdutos.ListaProdutosVenda = _ListaProdutosUsadosVendaPesq
            frmMostraProdutos.ShowDialog()
            frmMostraProdutos.ListaProdutosVenda.Clear()
            frmMostraProdutos = Nothing
        End If

    End Sub

    Sub atualizaValoresTotaisVendasServicoDtg()

        Dim mSomaDN, mSomaCTC, mSomaCTD, mSomaPIX, mSomaTRA, mSomaCRD As Double
        Try
            If dtgVendasServico.Rows.Count > 0 Then

                For Each dt As DataGridViewRow In dtgVendasServico.Rows

                    If Not dt.IsNewRow Then
                        mSomaDN += dt.Cells(6).Value
                        mSomaCTC += dt.Cells(7).Value
                        mSomaCTD += dt.Cells(8).Value
                        mSomaPIX += dt.Cells(9).Value
                        mSomaTRA += dt.Cells(10).Value
                        mSomaCRD += dt.Cells(11).Value
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

        txtTotaisVendasDN.Text = mSomaDN.ToString("#,##0.00")
        txtTotaisVendasCTC.Text = mSomaCTC.ToString("#,##0.00")
        txtTotaisVendasCTD.Text = mSomaCTD.ToString("#,##0.00")
        txtTotaisVendasPIX.Text = mSomaPIX.ToString("#,##0.00")
        txtTotaisVendasTRA.Text = mSomaTRA.ToString("#,##0.00")
        txtTotaisVendasCRD.Text = mSomaCRD.ToString("#,##0.00")
    End Sub

    Private Sub dtgVendasServico_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgVendasServico.RowsAdded
        atualizaValoresTotaisVendasServicoDtg()
        txtqtdRegistros.Text = dtgVendasServico.Rows.Count
    End Sub

    Private Sub dtgVendasServico_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgVendasServico.RowsRemoved
        atualizaValoresTotaisVendasServicoDtg()
        txtqtdRegistros.Text = dtgVendasServico.Rows.Count
    End Sub

    Private Sub dtgVendasServico_Click(sender As Object, e As EventArgs) Handles dtgVendasServico.Click

        Try
            If Not dtgVendasServico.CurrentRow.IsNewRow Then
                AtualizaBuscaServicosVenda()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtgVendasServico_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgVendasServico.CellDoubleClick

        Try
            If Not dtgVendasServico.CurrentRow.IsNewRow Then
                AtualizaBuscaProdutosDaVendaServico()
            End If
        Catch ex As Exception
        End Try

    End Sub

#End Region

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ExecutaF5()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub
End Class