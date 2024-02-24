Imports Npgsql
Public Class FrmPagamentoComissao

    Dim _atendente As New ClAtendente
    Dim _atendenteDao As New ClAtendenteDAO
    Dim _atendentePesq As New ClAtendente
    Dim _funcoes As New ClFuncoes
    Dim _ListVendaServicos As New List(Of ClVendaServico)
    Dim _ListVendaServicoItens As New List(Of ClVendaServicoItens)
    Dim _ListVendaServicosAuxiliar As New List(Of ClVendaServico)
    Dim _ListVendaServicoItensAuxiliar As New List(Of ClVendaServicoItens)
    Dim _ListServico As New List(Of ClServicos)
    Dim _ListServicoDAO As New ClServicosDAO
    Dim _ListComissaoDataGrid As New List(Of ClComissaoDataGrid)
    Dim _ComissaoDataGrid As New ClComissaoDataGrid
    Dim _VendaServico As New ClVendaServico
    Dim lAbrirFecharTodos As New List(Of ClAbrirFecharCaixa)
    Dim lMovCaixaTodos As New List(Of ClCaixa)
    Dim lCaixasAbertos As New List(Of ClAbrirFecharCaixa)
    Dim lCaixasFechados As New List(Of ClAbrirFecharCaixa)


    Dim mIdCx As Integer = 0, mDescricaoCx As String = ""
    Dim _VendaServicoDAO As New ClVendaServicoDAO
    Dim _VendaServicoItensDAO As New ClVendaServicoItensDAO
    Dim _Comissao As New ClComissao
    Dim _ComissaoAuxiliar As New ClComissao
    Dim _ListaComissoes As New List(Of ClComissao)
    Dim _ListaComissoesAuxiliar As New List(Of ClComissao)
    Dim _ListaComissaoRelatorio As New List(Of ClComissao)
    Dim _ComissaoDAO As New ClComissaoDAO


    Private Sub FrmPagamentoComissao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmPagamentoComissao_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                executeF5()

            Case Keys.F11
                executeF11()

        End Select
    End Sub

#Region "   Pagamento de Comissão"

    Sub TrazCaixas()

        Dim mAbrirFecharDAO As New ClAbrirFecharDAO
        Dim mCaixaDAO As New ClCaixaDAO
        Dim mLocacoes As New ClMovimentacaoDAO

        mAbrirFecharDAO.TrazListAbriFecharBD(lAbrirFecharTodos, MdlConexaoBD.conectionPadrao)
        mCaixaDAO.TrazListCaixasBD(lMovCaixaTodos, MdlConexaoBD.conectionPadrao)

    End Sub

    Sub BuscaCaixaPorPeriodo()


        Dim mListCaixasDatas As IList(Of ClAbrirFecharCaixa)
        mListCaixasDatas = lAbrirFecharTodos.FindAll(Function(l As ClAbrirFecharCaixa) (CDate(l.Af_datahora1.ToShortDateString) >= CDate(dtpInicio.Value.ToShortDateString)) AndAlso _
                                                         (CDate(l.Af_datahora1.ToShortDateString) <= CDate(dtpFim.Value.ToShortDateString)))

        'Caixas Abertos:
        For Each cx As ClAbrirFecharCaixa In mListCaixasDatas
            If cx.Af_tipo1.Equals("A") Then lCaixasAbertos.Add(cx)
        Next

        'Caixas Fechados:
        For Each cx As ClAbrirFecharCaixa In mListCaixasDatas
            If cx.Af_tipo1.Equals("F") Then lCaixasFechados.Add(cx)
        Next
    End Sub

    Sub preenchDtgCaixas()

        If validaData() Then

            'Busca os caixa por Data
            BuscaCaixaPorPeriodo()

            If lCaixasAbertos.Count <= 0 Then Return 'MsgBox("Não Existe Caixas Nesse Período!") : 
            dtgCaixas.Rows.Clear()
            For Each cx As ClAbrirFecharCaixa In lCaixasAbertos

                mIdCx = cx.Af_id1
                mDescricaoCx = cx.Af_datahora1.ToLongTimeString & "   Caixa Não Fechado..."
                For Each cxF As ClAbrirFecharCaixa In lCaixasFechados.FindAll(Function(l As ClAbrirFecharCaixa) l.Af_id_abertura1 = mIdCx)
                    mDescricaoCx = cx.Af_datahora1.ToLongTimeString & " (Fechado: " & cxF.Af_datahora1.ToString & ")"
                Next

                dtgCaixas.Rows.Add(mIdCx, chkMarcarTodosCaixas.Checked, mDescricaoCx)
            Next
        End If

    End Sub

    Sub MarcaDesmarcaCaixas()

        For Each r As DataGridViewRow In dtgCaixas.Rows

            If r.IsNewRow = False Then
                r.Cells(1).Value = chkMarcarTodosCaixas.Checked
            End If
        Next
    End Sub

    Private Sub btnVizualizaComissoes_Click(sender As Object, e As EventArgs) Handles btnVizualizaComissoes.Click
        tbcComissao.SelectTab(1)
    End Sub

    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        tbcComissao.SelectTab(0)
    End Sub

    Private Sub FrmPagamentoComissao_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _atendenteDao.PreencheCboAtendentesListaPesquisa(CboAtendente, MdlConexaoBD.ListaAtendentes)
        _atendenteDao.PreencheCboAtendentesListaPesquisa(cboAtendenteRelatorio, MdlConexaoBD.ListaAtendentes)
        CboAtendente.SelectedIndex = 0 : cboAtendenteRelatorio.SelectedIndex = 0

        _VendaServicoItensDAO.TrazListTodosVendaServicoItens_BD(_ListVendaServicoItens, MdlConexaoBD.conectionPadrao)
        _VendaServicoDAO.TrazListVendaServicoBD(_ListVendaServicos, MdlConexaoBD.conectionPadrao)
        _ComissaoDAO.TrazListComissoes(_ListaComissoes, MdlConexaoBD.conectionPadrao)

        'TrazCaixas()
        'preenchDtgCaixas()

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click

        executeF5()
    End Sub

    'Sub PreencheIDsCaixas()

    '    If dtgCaixas.Rows.Count <= 0 Then Return
    '    _ComissaoAuxiliar.zeraValores()
    '    For Each r As DataGridViewRow In dtgCaixas.Rows

    '        If r.IsNewRow = False Then

    '            If r.Cells(1).Value Then
    '                _ComissaoAuxiliar.ArrayIdCaixas.Add(r.Cells(0).Value)
    '            End If
    '        End If
    '    Next
    'End Sub

    Sub executeF5()

        If validaBusca() = False Then Return

        Dim dtInicial As String = Format(dtpInicio.Value, "dd/MM/yyyy")
        Dim dtFinal As String = Format(dtpFim.Value, "dd/MM/yyyy")
        Dim mIdServ As Integer = 0, mSomaNormal As Double, mSomaVariado As Double, mSomaCartao As Double, mSomaTotal As Double
        Dim mSomaComissao As Double = 0
        Dim mVendasServicos As New List(Of ClVendaServico)
        _ListVendaServicosAuxiliar.Clear()
        _ListVendaServicoItensAuxiliar.Clear()

        'Correto:
        '_ListVendaServicoItensAuxiliar = _VendaServicoItensDAO.TrazListItensVendaServico_CompareData(_ListVendaServicoItens, dtpInicio.Value, dtpFim.Value)
        _ListVendaServicoItensAuxiliar = _ListVendaServicoItens.FindAll(Function(vi As ClVendaServicoItens) _
                                        CDate(Format(vi.Data, "dd/MM/yyyy")) >= CDate(dtInicial) AndAlso _
                                       CDate(Format(vi.Data, "dd/MM/yyyy")) <= CDate(dtFinal))

        If CboAtendente.SelectedIndex > 0 Then
            _ListVendaServicoItensAuxiliar = _ListVendaServicoItensAuxiliar.FindAll(Function(vi As ClVendaServicoItens) vi.IdAtendente = _atendente.aId)
        End If


        'Adiciona os Registros Totais da Venda Serviço de acordo com a Busca:
        For Each vi As ClVendaServicoItens In _ListVendaServicoItensAuxiliar

            If _ListVendaServicosAuxiliar.Exists(Function(v As ClVendaServico) v.vsid = vi.IdVendaServico) = False Then
                _ListVendaServicosAuxiliar.Add(New ClVendaServico(_ListVendaServicos.Find(Function(v As ClVendaServico) v.vsid = vi.IdVendaServico)))
            End If
        Next


        _ListComissaoDataGrid.Clear()
        For Each vi As ClVendaServicoItens In _ListVendaServicoItensAuxiliar

            'If mIdServ = vi.IdServico Then Continue For
            _ComissaoDataGrid.ZeraValores()
            _ComissaoDataGrid.IdVendaServico = vi.IdVendaServico
            _ComissaoDataGrid.AtendenteID = _atendente.aId
            _ComissaoDataGrid.AntendenteNOME = _atendente.aNome
            _ComissaoDataGrid.ServicoID = vi.IdServico
            _ComissaoDataGrid.ServicoNOME = vi.NomeServico
            _ComissaoDataGrid.DataHora = vi.Data
            _ComissaoDataGrid.Qtde = vi.QuantidadeServico
            _ComissaoDataGrid.Total = vi.ValorTotalServico
            _ComissaoDataGrid.Comissao = vi.ValorComissao
            '_ComissaoDataGrid.Qtde = _ListVendaServicoItensAuxiliar.FindAll(Function(i As ClVendaServicoItens) i.IdServico = _ComissaoDataGrid.ServicoID).Count
            '_ComissaoDataGrid.Total = (From serv As ClVendaServicoItens In _ListVendaServicoItensAuxiliar Where serv.IdServico = _ComissaoDataGrid.ServicoID Select serv.ValorTotalServico).Sum
            '_ComissaoDataGrid.Comissao = (From serv As ClVendaServicoItens In _ListVendaServicoItensAuxiliar Where serv.IdServico = _ComissaoDataGrid.ServicoID Select serv.ValorComissao).Sum

            _ComissaoDataGrid.pagoDN = (From vend As ClVendaServico In _ListVendaServicosAuxiliar Where vend.vsid = vi.IdVendaServico Select vend.vspagodinheiro).Sum
            _ComissaoDataGrid.pagoCTC = (From vend As ClVendaServico In _ListVendaServicosAuxiliar Where vend.vsid = vi.IdVendaServico Select vend.vspagocredito).Sum
            _ComissaoDataGrid.pagoCTD = (From vend As ClVendaServico In _ListVendaServicosAuxiliar Where vend.vsid = vi.IdVendaServico Select vend.vspagodebito).Sum
            _ComissaoDataGrid.pagoPIX = (From vend As ClVendaServico In _ListVendaServicosAuxiliar Where vend.vsid = vi.IdVendaServico Select vend.vspagopix).Sum
            _ComissaoDataGrid.pagoTRA = (From vend As ClVendaServico In _ListVendaServicosAuxiliar Where vend.vsid = vi.IdVendaServico Select vend.vspagotransferencia).Sum
            _ComissaoDataGrid.pagoCRD = (From vend As ClVendaServico In _ListVendaServicosAuxiliar Where vend.vsid = vi.IdVendaServico Select vend.vspagocrediario).Sum

            If _ComissaoDataGrid.pagoDN > 0 Then _ComissaoDataGrid.formaPagamentos += "DN=" & _ComissaoDataGrid.pagoDN.ToString("#,##0.00") & ";"
            If _ComissaoDataGrid.pagoCTC > 0 Then
                _ComissaoDataGrid.formaPagamentos += "CTC=" & _ComissaoDataGrid.pagoCTC.ToString("#,##0.00") & ";"
            End If

            If _ComissaoDataGrid.pagoCTD > 0 Then
                If _ComissaoDataGrid.formaPagamentos.Equals("") = False Then _ComissaoDataGrid.formaPagamentos += ";"
                _ComissaoDataGrid.formaPagamentos += "CTD=" & _ComissaoDataGrid.pagoCTD.ToString("#,##0.00")
            End If

            If _ComissaoDataGrid.pagoPIX > 0 Then
                If _ComissaoDataGrid.formaPagamentos.Equals("") = False Then _ComissaoDataGrid.formaPagamentos += ";"
                _ComissaoDataGrid.formaPagamentos += "PIX=" & _ComissaoDataGrid.pagoPIX.ToString("#,##0.00")
            End If

            If _ComissaoDataGrid.pagoTRA > 0 Then
                If _ComissaoDataGrid.formaPagamentos.Equals("") = False Then _ComissaoDataGrid.formaPagamentos += ";"
                _ComissaoDataGrid.formaPagamentos += "TRA=" & _ComissaoDataGrid.pagoTRA.ToString("#,##0.00")
            End If

            If _ComissaoDataGrid.pagoCRD > 0 Then
                If _ComissaoDataGrid.formaPagamentos.Equals("") = False Then _ComissaoDataGrid.formaPagamentos += ";"
                _ComissaoDataGrid.formaPagamentos += "CRD=" & _ComissaoDataGrid.pagoCRD.ToString("#,##0.00")
            End If

            'mIdServ = _ComissaoDataGrid.ServicoID
            _ListComissaoDataGrid.Add(New ClComissaoDataGrid(_ComissaoDataGrid))

        Next

        dtgVendasServicoAtendente.Rows.Clear()
        _ListComissaoDataGrid.Sort(Function(c1 As ClComissaoDataGrid, c2 As ClComissaoDataGrid) c1.DataHora.CompareTo(c2.DataHora) And c1.IdVendaServico.CompareTo(c2.IdVendaServico))
        mSomaNormal = 0 : mSomaVariado = 0 : mSomaCartao = 0 : mSomaTotal = 0
        For Each d As ClComissaoDataGrid In _ListComissaoDataGrid


            dtgVendasServicoAtendente.Rows.Add(d.IdVendaServico, d.AtendenteID, d.AntendenteNOME, d.ServicoNOME, d.Qtde.ToString("#,##0.00"), d.Total.ToString("#,##0.00"), d.DataHora, d.formaPagamentos, d.Comissao)

            mSomaTotal += d.Total
            mSomaComissao += d.Comissao

            'Valor normal:
            If (d.pagoCTC = 0) AndAlso (d.pagoCTD = 0) Then

                mSomaNormal += d.Total
                Continue For
            End If

            'Só cartao:
            If (d.pagoDN = 0) AndAlso (d.pagoPIX = 0) AndAlso (d.pagoTRA = 0) AndAlso (d.pagoCRD = 0) Then

                mSomaCartao += d.Total
                Continue For
            End If

            mSomaVariado += d.Total

        Next

        txtTotalGeral.Text = mSomaTotal.ToString("#,##0.00")
        txtTotalCartao.Text = mSomaCartao.ToString("#,##0.00")
        txtTotalVariado.Text = mSomaVariado.ToString("#,##0.00")
        txtTotalNormal.Text = mSomaNormal.ToString("#,##0.00")
        txtTotalComissaoAuto.Text = mSomaComissao.ToString("#,##0.00")

        calculaDesp()
        calculaComissao()

    End Sub

    Private Sub CboFuncionario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboAtendente.SelectedIndexChanged

        _atendente.ZeraValores()
        Try
            If CboAtendente.SelectedIndex > 0 Then
                _atendente.aNome = CboAtendente.SelectedItem.ToString
                _atendenteDao.TrazAtendenteNomeDaLista(_atendente, MdlConexaoBD.ListaAtendentes)
            End If
        Catch ex As Exception
        End Try


    End Sub

    Function validaData() As Boolean

        If dtpInicio.Text > dtpFim.Text Then
            MsgBox("Data Inicial dever Menor ou Igual a Data Final!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            dtpInicio.Focus()
            Return False
        End If

        Return True
    End Function

    Function validaBusca() As Boolean

        If _atendente.aId <= 0 Then
            MsgBox("Por favor Selecione Algum Funcionário(a)!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            CboAtendente.Focus() : CboAtendente.DroppedDown = True
            Return False
        End If

        If dtpInicio.Text > dtpFim.Text Then
            MsgBox("Data Inicial dever Menor ou Igual a Data Final!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            dtpInicio.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub chkDespCartao_CheckedChanged(sender As Object, e As EventArgs) Handles chkDespVariado.CheckedChanged, chkDespTotalNormal.CheckedChanged, chkDespCartao.CheckedChanged

        calculaDesp()

    End Sub

    Sub calculaDesp()

        Dim mSoma As Double = 0

        Try

            If chkDespTotalNormal.Checked Then
                mSoma += CDbl(txtTotalNormal.Text)
            End If

            If chkDespVariado.Checked Then
                mSoma += CDbl(txtTotalVariado.Text)
            End If

            If chkDespCartao.Checked Then
                mSoma += CDbl(txtTotalCartao.Text)
            End If
        Catch ex As Exception
        End Try

        txtTotaisDesp.Text = mSoma.ToString("#,##0.00")

    End Sub

    Sub calculaComissao()

        Dim mSoma As Double = 0

        Try

            If chkUsarAuto.Checked Then

                mSoma += CDbl(txtTotalComissaoAuto.Text) - CDbl(txtValorDesp.Text)
            Else

                mSoma += CDbl(txtTotalGeral.Text) - CDbl(txtValorDesp.Text)
            End If

        Catch ex As Exception
        End Try

        txtComissao.Text = mSoma.ToString("#,##0.00")
    End Sub

    Private Sub txtValorDesp_TextChanged(sender As Object, e As EventArgs) Handles txtValorDesp.TextChanged

        Try
            Dim mValor As Double = 0
            If IsNumeric(txtValorDesp.Text) Then
                mValor = CDbl(txtComissao.Text) - CDbl(txtValorDesp.Text)

                If mValor < 0 Then
                    chkUsarAuto.Checked = False
                    txtComissao.Text = txtTotalGeral.Text
                    mValor = CDbl(txtComissao.Text) - CDbl(txtValorDesp.Text)
                End If
                txtValorAPagar.Text = (CDbl(txtComissao.Text) - CDbl(txtValorDesp.Text)).ToString("#,##0.00")
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtComissao_TextChanged(sender As Object, e As EventArgs) Handles txtComissao.TextChanged

        If IsNumeric(txtComissao.Text) AndAlso IsNumeric(txtValorDesp.Text) Then
            txtValorAPagar.Text = (CDbl(txtComissao.Text) - CDbl(txtValorDesp.Text)).ToString("#,##0.00")
        End If

    End Sub

    Private Sub txtValorDesp_Leave(sender As Object, e As EventArgs) Handles txtValorDesp.Leave

        If IsNumeric(txtValorDesp.Text) Then
            txtValorDesp.Text = CDbl(txtValorDesp.Text).ToString("#,##0.00")

            Dim mValor As Double = 0
            mValor = ((CDbl(txtValorDesp.Text) * 100) / CDbl(txtTotaisDesp.Text))
            txtPorcentDesp.Text = mValor.ToString("#,##0.00")
        Else
            txtValorDesp.Text = "0,00"
        End If
    End Sub

    Private Sub txtPorcentDesp_Leave(sender As Object, e As EventArgs) Handles txtPorcentDesp.Leave

        Try

            Dim mValor As Double = 0
            If IsNumeric(txtTotaisDesp.Text) AndAlso CDbl(txtTotaisDesp.Text) > 0 Then

                If IsNumeric(txtPorcentDesp.Text) Then

                    txtPorcentDesp.Text = CDbl(txtPorcentDesp.Text).ToString("#,##0.00")
                    If CDbl(txtPorcentDesp.Text) > 0 Then

                        mValor = ((CDbl(txtTotaisDesp.Text) * CDbl(txtPorcentDesp.Text)) / 100)
                        txtValorDesp.Text = mValor.ToString("#,##0.00")
                    Else
                        txtValorDesp.Text = "0,00"
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub txtPorcentDesp_Click(sender As Object, e As EventArgs) Handles txtPorcentDesp.Click
        txtPorcentDesp.SelectAll()
    End Sub

    Private Sub txtValorDesp_Click(sender As Object, e As EventArgs) Handles txtValorDesp.Click
        txtValorDesp.SelectAll()
    End Sub

    Private Sub chkUsarAuto_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsarAuto.CheckedChanged
        calculaComissao()
    End Sub

    Private Sub txt_valorPago_Click(sender As Object, e As EventArgs) Handles txtValorPago.Click
        txtValorPago.SelectAll()
    End Sub

    Private Sub btn_baixar_Click(sender As Object, e As EventArgs) Handles btn_baixar.Click

        If VerificaComissao() Then

            PreencheValoreComissao()
            salvandoComissao()

        End If
    End Sub

    Sub PreencheValoreComissao()

        With _Comissao

            .c_datapagamento = dtPagamento.Value
            .c_valorpago = CDbl(txtValorPago.Text)
            .c_empresaid = MdlConexaoBD.mdlEmpresa.empid
            .c_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            .c_atendenteid = _atendente.aId
            .c_atendentenome = _atendente.aNome
            .c_observacao = txtObservacao.Text
        End With
    End Sub

    Sub ZeraValorescomissao()

        _Comissao.zeraValores()
        dtgVendasServicoAtendente.Rows.Clear()
        CboAtendente.SelectedIndex = 0
        dtpInicio.Value = Date.Now
        dtpFim.Value = Date.Now
        txtTotaisDesp.Text = "0.00" : txtPorcentDesp.Text = "0.00" : txtValorDesp.Text = "0.00"
        txtComissao.Text = "0,00" : txtValorAPagar.Text = "0,00" : txtValorPago.Text = "0,00"
        txtTotalCartao.Text = "0,00" : txtTotalNormal.Text = "0,00" : txtTotalVariado.Text = "0,00"
        txtTotalGeral.Text = "0,00" : txtTotalComissaoAuto.Text = "0,00"
        txtObservacao.Text = ""
    End Sub

    Function VerificaComissao() As Boolean

        If validaBusca() = False Then Return False

        If dtgVendasServicoAtendente.Rows.Count <= 0 Then

            MsgBox("Clique em Buscar para Gerar as Comissões, por favor!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return False
        End If

        If IsNumeric(txtValorPago.Text) = False Then

            MsgBox("Valor Pago dever ser NUMERICO!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            txtValorPago.Focus() : txtValorPago.SelectAll()
            Return False
        End If

        If CDbl(txtValorPago.Text) <= 0 Then

            MsgBox("Valor Pago dever ser Maior que 0,00!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            txtValorPago.Focus() : txtValorPago.SelectAll()
            Return False
        End If

        If CDbl(txtValorPago.Text) > CDbl(txtValorAPagar.Text) Then

            If MessageBox.Show("Valor Pago está Maior que o Valor a Pagar! Deseja Continuar?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                = Windows.Forms.DialogResult.No Then

                txtValorPago.Focus() : txtValorPago.SelectAll()
                Return False
            End If
        End If

        Return True
    End Function

    Sub salvandoComissao()

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction
            _ComissaoDAO.incComissao(_Comissao, connection, transacao)
            transacao.Commit()

            MsgBox("Comissão Gravada com Sucesso! Você poderá ir na Aba das Comissões para Imprimir um Recibo :-)", MsgBoxStyle.Exclamation)
            ZeraValorescomissao()
            _ListaComissoes.Clear()
            _ComissaoDAO.TrazListComissoes(_ListaComissoes, MdlConexaoBD.conectionPadrao)
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

#End Region


#Region "   Visualiza as Comissões"

    Private Sub btnBuscaComissoes_Click(sender As Object, e As EventArgs) Handles btnBuscaComissoes.Click
        executaPesqComissoes()
    End Sub

    Private Sub cboFuncionarioComissoes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAtendenteRelatorio.SelectedIndexChanged

        _atendentePesq.ZeraValores()
        Try
            If cboAtendenteRelatorio.SelectedIndex > 0 Then
                _atendentePesq.aNome = cboAtendenteRelatorio.SelectedItem.ToString
                _atendenteDao.TrazAtendenteNomeDaLista(_atendentePesq, MdlConexaoBD.ListaAtendentes)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub executaPesqComissoes()

        Dim dtInicial As String = Format(dtpInicioRelatorio.Value, "dd/MM/yyyy")
        Dim dtFinal As String = Format(dtpFinalRelatorio.Value, "dd/MM/yyyy")
        _ListaComissoesAuxiliar.Clear()

        If cboAtendenteRelatorio.SelectedIndex > 0 Then

            _ListaComissoesAuxiliar = _ListaComissoes.FindAll(Function(c As ClComissao) c.c_atendenteid = _atendentePesq.aId AndAlso _
                                c.c_deletada = chkComissoesExcluidas.Checked AndAlso CDate(Format(c.c_datapagamento, "dd/MM/yyyy")) >= CDate(dtInicial) _
                                AndAlso CDate(Format(c.c_datapagamento, "dd/MM/yyyy")) <= CDate(dtFinal))
        Else

            _ListaComissoesAuxiliar = _ListaComissoes.FindAll(Function(c As ClComissao) c.c_deletada = chkComissoesExcluidas.Checked AndAlso _
                                CDate(Format(c.c_datapagamento, "dd/MM/yyyy")) >= CDate(dtInicial) _
                                AndAlso CDate(Format(c.c_datapagamento, "dd/MM/yyyy")) <= CDate(dtFinal))

        End If


        dtgComissoesGravadas.Rows.Clear()
        For Each c As ClComissao In _ListaComissoesAuxiliar

            dtgComissoesGravadas.Rows.Add(c.c_id, c.c_atendenteid, c.c_atendentenome, c.c_datapagamento, c.c_valorpago.ToString("#,##0.00"), c.c_observacao, c.c_empresaid, c.c_empresanome)
        Next
        txtTotRegistrosRelatorio.Text = dtgComissoesGravadas.RowCount
        txtTotalValoresPagamento.Text = somaColunaDtg(4).ToString("#,##0.00")

    End Sub

    Function somaColunaDtg(iDColuna As Integer) As Double
        Dim somaValor As Double = 0

        Try
            For Each r As DataGridViewRow In dtgComissoesGravadas.Rows
                somaValor += r.Cells(iDColuna).Value
            Next
        Catch ex As Exception
        End Try

        Return somaValor
    End Function

    Sub deletandoComissao()


        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction
            _ComissaoDAO.delComissao(_ComissaoAuxiliar, connection, transacao)
            transacao.Commit()

            MsgBox("Comissão Deletada com Sucesso!", MsgBoxStyle.Exclamation)
            _ListaComissoes.Clear()
            _ComissaoDAO.TrazListComissoes(_ListaComissoes, MdlConexaoBD.conectionPadrao)
            executaPesqComissoes()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

#End Region

    Private Sub tbcComissao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcComissao.SelectedIndexChanged

        If tbcComissao.SelectedIndex = 1 Then
            executaPesqComissoes()
        End If
    End Sub

    Private Sub chkMarcarTodosCaixas_CheckedChanged(sender As Object, e As EventArgs) Handles chkMarcarTodosCaixas.CheckedChanged
        MarcaDesmarcaCaixas()
    End Sub

    Private Sub dtgCaixas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgCaixas.CellClick

        If e.ColumnIndex = 1 Then

            If dtgCaixas.Rows(e.RowIndex).Cells(1).Value = True Then
                dtgCaixas.Rows(e.RowIndex).Cells(1).Value = False
            Else
                dtgCaixas.Rows(e.RowIndex).Cells(1).Value = True
            End If
        End If
    End Sub

    Private Sub dtgComissoesGravadas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgComissoesGravadas.CellClick

        _ComissaoAuxiliar.zeraValores()

        'Deletar Comissão:
        If e.ColumnIndex = 10 Then


            If MessageBox.Show("Deseje Realmente Deletar esse Registro?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                = Windows.Forms.DialogResult.Yes Then

                _ComissaoAuxiliar.c_id = dtgComissoesGravadas.Rows(e.RowIndex).Cells(0).Value
                _ComissaoDAO.TrazComissaoDaLista(_ComissaoAuxiliar, _ListaComissoes)
                deletandoComissao()
            End If

        End If

        'Impressão do Relatório:
        If e.ColumnIndex = 9 Then

            _ComissaoAuxiliar.c_id = dtgComissoesGravadas.Rows(e.RowIndex).Cells(0).Value
            _ComissaoDAO.TrazComissaoDaLista(_ComissaoAuxiliar, _ListaComissoes)
            Dim frmReciboComiss As New FormReciboComissao
            frmReciboComiss._comissao.SetaValores(_ComissaoAuxiliar)
            frmReciboComiss._empresa.setValores(MdlConexaoBD.mdlEmpresa)
            frmReciboComiss.ShowDialog()
            frmReciboComiss = Nothing

        End If


    End Sub

    Private Sub dtpInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpInicio.ValueChanged, dtpFim.ValueChanged
        preenchDtgCaixas()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        executeF11()
    End Sub

    Sub executeF11()

        _ListaComissaoRelatorio.Clear()

        If cboAtendenteRelatorio.SelectedIndex <= 0 Then

            _ListaComissaoRelatorio = _ListaComissoes.FindAll(Function(c As ClComissao) c.c_deletada = chkComissoesExcluidas.Checked And _
                                (CDate(c.c_datapagamento.ToShortDateString()) >= CDate(dtpInicioRelatorio.Value.ToShortDateString)) _
                                And (CDate(c.c_datapagamento.ToShortDateString()) <= CDate(dtpFinalRelatorio.Value.ToShortDateString)))
        Else

            _ListaComissaoRelatorio = _ListaComissoes.FindAll(Function(c As ClComissao) c.c_atendenteid = _atendentePesq.aId And _
                                c.c_deletada = chkComissoesExcluidas.Checked And (CDate(c.c_datapagamento.ToShortDateString()) >= CDate(dtpInicioRelatorio.Value.ToShortDateString)) _
                                And (CDate(c.c_datapagamento.ToShortDateString()) <= CDate(dtpFinalRelatorio.Value.ToShortDateString)))
        End If

        'Formulario Relatorio:
        Dim form As New FormListaComissoes
        form._listaComissoes = _ListaComissaoRelatorio
        form._filtroData = dtpInicioRelatorio.Text & " A " & dtpFinalRelatorio.Text
        form._filtroAtendente = cboAtendenteRelatorio.Text
        form.ShowDialog()
        form = Nothing

    End Sub

End Class