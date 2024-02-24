Imports Npgsql
Public Class FrmServicos

    Dim _VendaServico As New ClVendaServico
    Dim _VendaServicoDAO As New ClVendaServicoDAO
    Dim _ItenVendaServico As New ClVendaServicoItens
    Dim _ItenVendaServicoDAO As New ClVendaServicoItensDAO
    Dim _ListaItensVendaServico As New List(Of ClVendaServicoItens)
    Dim _ListaItensVendaServicoPesq As New List(Of ClVendaServicoItens)
    Dim _ListaProdutosUsadosVendaPesq As New List(Of ClProdutoUsadoVenda)
    Dim _ListaVendaServicoPesq As New List(Of ClVendaServico)
    Dim _VendaServicoPesq As New ClVendaServico
    Dim _ruaDAO As New ClRuaDAO
    Dim _Rua As New ClRua
    Dim _Atendente As New ClAtendente
    Dim _Entregador As New ClAtendente
    Dim _Cliente As New ClCliente
    Dim _Produto As New ClProduto
    Dim _Servico As New ClServicos
    Dim _Bairro As New ClBairro
    Dim _ServicoDAO As New ClServicosDAO
    Dim _ClienteDAO As New ClClienteDAO
    Dim _BairroDAO As New ClBairroDAO
    Dim _ProdutoDAO As New ClProdutoDAO
    Dim _AtententeDAO As New ClAtendenteDAO
    Dim _EntregadorDAO As New ClAtendenteDAO
    Dim _ListServicosVenda As New List(Of ClServicos)
    Dim _ProdutosServicos As New ClProdutoServico
    Dim _ListaProdutosServico As New List(Of ClProdutoServico)
    Dim _ProdutosServicosDAO As New ClProdutoServicoDAO
    Dim _ListaProdutosUsados As New List(Of ClProdutoUsado)
    Dim _ListaProdutosUsadosVenda As New List(Of ClProdutoUsadoVenda)
    Dim _ProdutoUsadoDAO As New ClProdutoUsadoDAO
    Dim _ProdutoUsadoVendaDAO As New ClProdutoUsadoVendaDAO
    Dim _ContaAReceber As New ClAReceberTotal
    Dim _ContaAReceberDAO As New ClAReceberTotalDAO
    Public _Agendamento As New ClAgendamento
    Dim ItensAgendamento As New List(Of ClAgendamentoItens)
    Dim DaoAgendamento As New ClAgendamentoDAO
    Dim DaoItensAgendamento As New ClAgendamentoItemDAO
    Public _Modificado As Boolean = False


    Dim _funcoes As New ClFuncoes
    Dim _strAuxiliar As String = ""
    Dim _valorAuxiliar As Double = 0
    Dim _valorPago As Double = 0
    Dim _IdVendaServico As Int64 = 0
    Dim _valueChangeCliente As Boolean = False
    Dim _valueChangeSTR As String = ""

    Private Sub FrmServicos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmServicos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F9
                ExecuteF9()
            Case Keys.F7
                ExecuteF7()
            Case Keys.F4
                Dim frmCaixa As New FrmCaixa
                frmCaixa.ShowDialog()
                frmCaixa = Nothing
        End Select
    End Sub

    Private Sub FrmServicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.Text = "::Servicos - " & Application.CompanyName
        Me.Text = Application.CompanyName

        _ruaDAO.PreencheCboRuasBD(cboRua, MdlConexaoBD.conectionPadrao)
        _BairroDAO.PreencheCboBairrosBD(cboBairro, MdlConexaoBD.conectionPadrao)
        _ServicoDAO.PreencheCboServicosBD(cboServico, MdlConexaoBD.conectionPadrao)
        _ProdutoDAO.PreencheCboProdutosBD(cboProdutoUsado, MdlConexaoBD.conectionPadrao)
        _AtententeDAO.PreencheCboAtendentesBD(cboAtendente, MdlConexaoBD.conectionPadrao)

        PreenchCamposFormAgendamento()

    End Sub

    Sub PreenchCamposFormAgendamento()

        'Tratamento do Agendamento:
        If _Agendamento.a_id > 0 Then
            DaoAgendamento.TrazAgendamentoBD(_Agendamento, MdlConexaoBD.conectionPadrao)
            DaoItensAgendamento.TrazListItensAgendamentoBD(_Agendamento, ItensAgendamento, MdlConexaoBD.conectionPadrao)

            _Cliente.cid = _Agendamento.a_pessoaid
            _ClienteDAO.TrazCliente(_Cliente, MdlConexaoBD.conectionPadrao)
            PreencheCamposCLiente()

            If ItensAgendamento.Count > 0 Then
                For Each ia As ClAgendamentoItens In ItensAgendamento

                    _Servico.ZeraValores()
                    _Atendente.ZeraValores()
                    _Servico.sid = ia.agi_codserv
                    _Atendente.aId = ia.agi_atendenteid
                    _ServicoDAO.TrazServico(_Servico, MdlConexaoBD.conectionPadrao)
                    _AtententeDAO.TrazAtendente(_Atendente, MdlConexaoBD.conectionPadrao)
                    dtgServicos.Rows.Add(_Servico.sid, _Servico.sdescricao, ia.agi_qtde.ToString("#,##0.00"), ia.agi_valor.ToString("#,##0.00"), "0,00", ia.agi_total.ToString("#,##0.00"), _
                                 _Atendente.aNome, _Atendente.aId, _Atendente.aComissao, _Servico.sdespcartaoporcentagem, _Servico.sdespcartaodinheiro)
                    AdicionaProdutoUsadoGrid()
                    ZeraCamposServico()
                    SomaValorServicosGrid()
                Next
                txtValorPagoDinheiro.Text = txtTotGeralServicos.Text
                txtValorPago.Text = txtTotGeralServicos.Text
            End If
        End If

    End Sub

    Private Sub btnVizualizaServicos_Click(sender As Object, e As EventArgs) Handles btnVizualizaServicos.Click
        TabCServicos.SelectTab(1)
    End Sub

    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        TabCServicos.SelectTab(0)
    End Sub

#Region "  TEXTO Busca Cliente"

    Private Sub txtIdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdCliente.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then

            buscaCliente()
        End If

    End Sub

    Sub buscaCliente()

        _strAuxiliar = ""
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
            DesfazCamposCliente()
        Else
            txtIdCliente.Text = _Cliente.cid
            txtNomeCliente.Text = _Cliente.cnome
            txtNomeCliente.ReadOnly = True
            txtNomeCliente.BackColor = Color.LightYellow
            PreencheCamposCLiente()
            txtNomeCliente.Focus()
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
            DesfazCamposCliente()
        Else
            PreencheCamposCLiente()
            txtNomeCliente.ReadOnly = True
            txtNomeCliente.BackColor = Color.LightYellow
        End If
        txtNomeCliente.SelectAll()
    End Sub

#End Region

#Region "   Venda Servicos"

    Private Sub mskCnpjCpf_Focus(sender As Object, e As EventArgs) Handles mskCnpjCpf.GotFocus
        Me.mskCnpjCpf.SelectAll()
    End Sub

    Private Sub rbCnpj_CheckedChanged(sender As Object, e As EventArgs) Handles rbCpf.CheckedChanged, rbCnpj.CheckedChanged
        mudarFormatRDB()
    End Sub

    Sub mudarFormatRDB()
        Me.mskCnpjCpf.Text = ""
        If rbCnpj.Checked Then
            Me.mskCnpjCpf.Mask = "99.999.999/9999-99"
            Me.mskCnpjCpf.Focus() : Me.mskCnpjCpf.SelectAll()
        ElseIf rbCpf.Checked Then
            Me.mskCnpjCpf.Mask = "999.999.999-99"
            Me.mskCnpjCpf.Focus() : Me.mskCnpjCpf.SelectAll()
        End If
    End Sub

    Sub AtualizaCboRUA()
        _ruaDAO.TrazListRuas(MdlConexaoBD.mdlListRuas, MdlConexaoBD.conectionPadrao)
        _ruaDAO.PreencheCboRuasLista(cboRua, MdlConexaoBD.mdlListRuas)
    End Sub

    Sub AtualizaCboBAIRRO()
        _BairroDAO.TrazListBairros(MdlConexaoBD.mdlListBairros, MdlConexaoBD.conectionPadrao)
        _BairroDAO.PreencheCboBairrosLista(cboBairro, MdlConexaoBD.mdlListBairros)
    End Sub

    Private Sub cboAtendente_GotFocus(sender As Object, e As EventArgs) Handles cboAtendente.GotFocus
        If cboAtendente.DroppedDown = False Then cboAtendente.DroppedDown = True
    End Sub

    Private Sub cboSevico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServico.SelectedIndexChanged

        _Servico.ZeraValores()
        txtVlrServico.Text = "0,00"
        If cboServico.SelectedIndex > -1 Then 'Foi selecionado algum serviço:

            _Servico.sdescricao = cboServico.SelectedItem
            If _ServicoDAO.TrazServicoNomeDaLista(_Servico) = False Then
                MsgBox("Selecione um Serviço!") : cboServico.Focus() : cboServico.DroppedDown = True
                Return
            End If

            cboAtendente.SelectedIndex = -1
            If _Servico.sidatendente > 0 Then cboAtendente.SelectedIndex = _funcoes.trazIndexCboTextoTodo(_Servico.snomeatendente, cboAtendente)
            txtVlrServico.Text = _Servico.svalor.ToString("#,##0.00")
            CalculaValorQtdeServiço()
            txtQtdeServico.Focus()
        End If
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click

        If VerificaExisteServicoGrid(_Servico) Then
            MsgBox("Serviço """ & _Servico.sdescricao & """ Já adicionado! Excluir o Serviço Existente e Adicione um Novo!")
            Return
        End If

        If cboServico.SelectedIndex < 0 Then
            MsgBox("Selecione um Serviço por favor!", MsgBoxStyle.Exclamation, Application.CompanyName)
            cboServico.Focus() : cboServico.DroppedDown = True
            Return
        End If

        If cboAtendente.SelectedIndex < 0 Then
            MsgBox("Selecione um Atendente por favor!", MsgBoxStyle.Exclamation, Application.CompanyName)
            cboAtendente.Focus() : cboAtendente.DroppedDown = True
            Return
        End If


        If CDbl(txtTotServico.Text) > 0 Then
            dtgServicos.Rows.Add(_Servico.sid, _Servico.sdescricao, txtQtdeServico.Text, txtVlrServico.Text, txtDescValorServico.Text, txtTotServico.Text, _
                                 _Atendente.aNome, _Atendente.aId, _Atendente.aComissao, _Servico.sdespcartaoporcentagem, _Servico.sdespcartaodinheiro)
            AdicionaProdutoUsadoGrid()
            ZeraCamposServico()
            SomaValorServicosGrid()
        Else
            MsgBox("Total do Serviço deve ser maior que ZERO")
        End If

    End Sub

    Function VerificaExisteServicoGrid(ByVal serv As ClServicos) As Boolean

        For Each s As DataGridViewRow In dtgServicos.Rows

            If Not s.IsNewRow Then

                If CInt(s.Cells(0).Value) = serv.sid Then Return True
            End If
        Next

        Return False
    End Function

    Function VerificaExisteProdutoUsadoGrid(ByVal prod As ClProduto) As Boolean

        For Each p As DataGridViewRow In dtgProdutoUsado.Rows

            If Not p.IsNewRow Then

                If CInt(p.Cells(0).Value) = prod.pId Then Return True
            End If
        Next

        Return False
    End Function

    Private Sub txtQtdeServico_Leave(sender As Object, e As EventArgs) Handles txtQtdeServico.Leave

        If IsNumeric(txtQtdeServico.Text) Then

            If CDbl(txtQtdeServico.Text) <= 0 Then
                MsgBox("Quantidade do Serviço deve ser Maior que ZERO", MsgBoxStyle.Exclamation, Application.CompanyName)
                txtQtdeServico.Focus() : txtQtdeServico.SelectAll()
                Return
            End If
            CalculaValorQtdeServiço()
        Else
            txtQtdeServico.Text = "1" : txtQtdeServico.Focus() : txtQtdeServico.SelectAll()
            Return
        End If
    End Sub

    Private Sub txtVlrServico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVlrServico.KeyPress, txtDescValorServico.KeyPress, txtDescServicoPorcent.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtQtdeServico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtdeServico.KeyPress, txtIdCliente.KeyPress
        'permite só numeros:
        If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Sub CalculaValorQtdeServiço()

        If CDbl(txtQtdeServico.Text) > 0 AndAlso CDbl(txtVlrServico.Text) > 0 Then
            txtSubTotServico.Text = ((CDbl(txtQtdeServico.Text) * CDbl(txtVlrServico.Text))).ToString("#,##0.00")
            txtTotServico.Text = ((CDbl(txtQtdeServico.Text) * CDbl(txtVlrServico.Text)) - CDbl(txtDescValorServico.Text)).ToString("#,##0.00")
        End If
    End Sub

    Private Sub txtVlrServico_Leave(sender As Object, e As EventArgs) Handles txtVlrServico.Leave

        If IsNumeric(txtVlrServico.Text) Then
            If cboServico.SelectedIndex < 0 Then Return
            If CDbl(txtVlrServico.Text) <= 0 Then
                MsgBox("Valor do Serviço deve ser Maior que ZERO", MsgBoxStyle.Exclamation, Application.CompanyName)
                txtVlrServico.Focus() : txtVlrServico.SelectAll()
                Return
            End If
            CalculaValorQtdeServiço()
        Else
            MsgBox("Valor do Serviço deve ser numérico", MsgBoxStyle.Exclamation, Application.CompanyName)
            txtVlrServico.Focus() : txtVlrServico.SelectAll()
            Return
        End If
    End Sub

    Private Sub txtDescValorServico_Leave(sender As Object, e As EventArgs) Handles txtDescValorServico.Leave

        If IsNumeric(txtDescValorServico.Text) Then

            If CDbl(txtDescValorServico.Text) <= 0 Then
                txtDescValorServico.Text = "0,00"
            Else 'Se for maior que  0

                txtDescValorServico.Text = CDbl(txtDescValorServico.Text).ToString("#,##0.00")
            End If
            CalculaDescontoValorServico()
        Else
            txtDescValorServico.Text = "0,00"
            Return
        End If
    End Sub

    Sub CalculaDescontoValorServico()

        If CDbl(txtQtdeServico.Text) > 0 AndAlso CDbl(txtVlrServico.Text) > 0 Then
            txtSubTotServico.Text = (CDbl(txtQtdeServico.Text) * CDbl(txtVlrServico.Text)).ToString("#,##0.00")
            txtTotServico.Text = (CDbl(txtSubTotServico.Text) - CDbl(txtDescValorServico.Text)).ToString("#,##0.00")
            If CDbl(txtDescValorServico.Text) <= 0 Then
                txtDescServicoPorcent.Text = "0,00"
            Else
                txtDescServicoPorcent.Text = ((CDbl(txtDescValorServico.Text) * 100) / CDbl(txtSubTotServico.Text)).ToString("#,##0.00")
            End If
        End If
    End Sub

    Sub CalculaDescontoPorcentagemServico()

        If CDbl(txtQtdeServico.Text) > 0 AndAlso CDbl(txtVlrServico.Text) > 0 Then
            txtSubTotServico.Text = (CDbl(txtQtdeServico.Text) * CDbl(txtVlrServico.Text)).ToString("#,##0.00")
            If CDbl(txtDescServicoPorcent.Text) <= 0 Then
                txtDescValorServico.Text = "0,00"
            Else
                txtDescValorServico.Text = ((CDbl(txtSubTotServico.Text) * CDbl(txtDescServicoPorcent.Text)) / 100).ToString("#,##0.00")
            End If
            txtTotServico.Text = (CDbl(txtSubTotServico.Text) - CDbl(txtDescValorServico.Text)).ToString("#,##0.00")
        End If
    End Sub

    Private Sub txtDescServicoPorcent_Leave(sender As Object, e As EventArgs) Handles txtDescServicoPorcent.Leave

        If IsNumeric(txtDescServicoPorcent.Text) Then

            If CDbl(txtDescServicoPorcent.Text) <= 0 Then
                txtDescServicoPorcent.Text = "0,00"
            Else 'Se for maior que  0

                txtDescServicoPorcent.Text = CDbl(txtDescServicoPorcent.Text).ToString("#,##0.00")
            End If
            CalculaDescontoPorcentagemServico()
        Else
            txtDescServicoPorcent.Text = "0,00"
            Return
        End If
    End Sub

    Sub ZeraCamposServico()
        cboServico.SelectedIndex = -1
        cboAtendente.SelectedIndex = -1
        txtQtdeServico.Text = 1
        txtVlrServico.Text = "0,00"
        txtDescValorServico.Text = "0,00"
        txtDescServicoPorcent.Text = "0,00"
        txtSubTotServico.Text = "0,00"
        txtTotServico.Text = "0,00"
        _VendaServico.ZeraValores()
        '_Cliente.ZeraValores()
        _Servico.ZeraValores()
        _Atendente.ZeraValores()
        _IdVendaServico = 0
    End Sub

    Sub ZeraTodosCamposVendaServico()
        ZeraCamposServico()
        ZeraCamposCliente()
        ZeraCamposInfVendaServiço()
        dtgServicos.Rows.Clear()
    End Sub

    Sub ZeraCamposCliente()
        txtIdCliente.Text = ""
        txtNomeCliente.Text = ""
        txtNomeCliente.ReadOnly = True
        txtNomeCliente.BackColor = Color.LightYellow
        txtEstadoCli.Text = MdlConexaoBD.mdlEmpresa.empestado
        txtCidadeCli.Text = ""
        cboRua.SelectedIndex = -1
        cboRua.Text = ""
        cboBairro.SelectedIndex = -1
        cboBairro.Text = ""
        mskTelefoneCli.Text = ""
        MskDiaMes.Text = ""
        mskCnpjCpf.Text = ""
    End Sub

    Sub ZeraCamposInfVendaServiço()

        txtValorTotalVendaServico.Text = "0,00"
        txtValorPago.Text = "0,00"
        txtSubTotVenda.Text = "0,00"
        txtValorTotDescVenda.Text = "0,00"
        txtValorPagoDinheiro.Text = "0,00"
        txtValorPagoCTCredito.Text = "0,00"
        txtValorPagoCTDebito.Text = "0,00"
        txtValorPagoPix.Text = "0,00"
        txtValorPagoTransferencia.Text = "0,00"
        txtValorPagoCrediario.Text = "0,00"

    End Sub

    Sub SomaValorServicosGrid()

        Dim mSoma As Double = 0.0
        For Each r As DataGridViewRow In dtgServicos.Rows

            If Not r.IsNewRow Then
                mSoma += CDbl(r.Cells(5).Value)
            End If
        Next
        txtTotGeralServicos.Text = mSoma.ToString("#,##0.00")
    End Sub

    Private Sub dtgServicos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgServicos.CellDoubleClick

        dtgServicos.Rows.RemoveAt(e.RowIndex)
        ZeraCamposServico()
        SomaValorServicosGrid()

    End Sub

    Private Sub cboProdutoUsado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProdutoUsado.SelectedIndexChanged

        _Produto.ZeraValores()
        If cboProdutoUsado.SelectedIndex > -1 Then
            Dim mProd As String = cboProdutoUsado.SelectedItem
            _Produto.pId = CInt(Trim(mProd.Substring(mProd.Length - 4)))
            _ProdutoDAO.TrazProdutoDaListaPorID(_Produto, MdlConexaoBD.ListaProdutos)
            txtQtdeProdUsado.Focus()
        End If
    End Sub

    Private Sub btnAddProdUsado_Click(sender As Object, e As EventArgs) Handles btnAddProdUsado.Click

        If _Produto.pId > 0 Then

            If VerificaExisteProdutoUsadoGrid(_Produto) Then
                MsgBox("Produto """ & _Produto.pDescricao & """ Já adicionado! Excluir o Produto Existente e Adicione um Novo!")
                Return
            End If

            dtgProdutoUsado.Rows.Add(_Produto.pId, _Produto.pDescricao, txtQtdeProdUsado.Text)
            cboProdutoUsado.SelectedIndex = -1
            txtQtdeProdUsado.Text = "0"
        End If
    End Sub

    Private Sub dtgProdutoUsado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgProdutoUsado.CellContentClick

        If e.ColumnIndex = 3 Then
            dtgProdutoUsado.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub txtQtdeProdUsado_GotFocus(sender As Object, e As EventArgs) Handles txtQtdeProdUsado.GotFocus
        txtQtdeProdUsado.SelectAll()
    End Sub

    Private Sub txtQtdeProdUsado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtdeProdUsado.KeyPress
        'permite só numeros:
        If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtQtdeProdUsado_Leave(sender As Object, e As EventArgs) Handles txtQtdeProdUsado.Leave

        If IsNumeric(txtQtdeProdUsado.Text) Then

            If CInt(txtQtdeProdUsado.Text) < 0 Then
                txtQtdeProdUsado.Text = "0"
            End If
        Else
            txtQtdeProdUsado.Text = "0"
        End If

    End Sub

    Sub PreencheListaProdutoGrid(ByRef listProdutosServico As List(Of ClProdutoServico))

        listProdutosServico.Clear()
        For Each ps As DataGridViewRow In dtgProdutoUsado.Rows

            If Not ps.IsNewRow Then

                listProdutosServico.Add(New ClProdutoServico(0, _Servico.sid, ps.Cells(0).Value, ps.Cells(1).Value, ps.Cells(2).Value))
            End If
        Next
    End Sub

    Sub PreencheGridProdutoUsadoLista(ByVal listProdutosServico As List(Of ClProdutoServico))

        If listProdutosServico.Count > 0 Then

            For Each ps As ClProdutoServico In listProdutosServico

                If VerificaProdutoUsadoGrid_e_SomaQtde(ps) = False Then
                    dtgProdutoUsado.Rows.Add(ps.psIdProduto, ps.psProdutoDescricao, ps.psQuantidade.ToString)
                End If
            Next
        End If

    End Sub

    Function VerificaProdutoUsadoGrid_e_SomaQtde(ByVal ps As ClProdutoServico)

        For Each p As DataGridViewRow In dtgProdutoUsado.Rows

            If Not p.IsNewRow Then

                If CInt(p.Cells(0).Value) = ps.psIdProduto Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Sub AdicionaProdutoUsadoGrid()

        _ProdutosServicosDAO.TrazProdutosDoServicoBanco(_Servico, _ListaProdutosServico, MdlConexaoBD.conectionPadrao)
        PreencheGridProdutoUsadoLista(_ListaProdutosServico)
    End Sub

    Sub PreencheCamposCLiente()

        txtIdCliente.Text = _Cliente.cid
        txtNomeCliente.Text = _Cliente.cnome
        cboRua.Text = _Cliente.cendereco
        cboBairro.Text = _Cliente.cbairro
        txtCidadeCli.Text = _Cliente.ccidade
        mskTelefoneCli.Text = _Cliente.ctelefone
        MskDiaMes.Text = _Cliente.cdiames
        If _Cliente.tipo.Equals("F") Then rbCpf.Checked = True
        If _Cliente.tipo.Equals("J") Then rbCnpj.Checked = True
        mskCnpjCpf.Text = _Cliente.cCpfCnpj

    End Sub

    Sub PreencheValoresCliente()


        _Cliente.cid = 0
        If IsNumeric(txtIdCliente.Text) Then

            If CInt(txtIdCliente.Text) > 0 Then _Cliente.cid = CInt(txtIdCliente.Text)
        End If

        _Cliente.cnome = txtNomeCliente.Text
        _Cliente.cestado = txtEstadoCli.Text
        _Cliente.ccidade = txtCidadeCli.Text
        _Cliente.cendereco = cboRua.Text
        _Cliente.cbairro = cboBairro.Text
        _Cliente.ctelefone = _funcoes.RemoverCaracter2(mskTelefoneCli.Text)
        _Cliente.cCpfCnpj = mskCnpjCpf.Text.Replace(",", ".")
        If rbCnpj.Checked Then _Cliente.tipo = "J"
        If rbCpf.Checked Then _Cliente.tipo = "F"
        _Cliente.cCpfCnpj = _funcoes.RemoverCaracter2(mskCnpjCpf.Text)
        _strAuxiliar = _funcoes.RemoverCaracter2(MskDiaMes.Text)
        _Cliente.cdiames = ""
        If Not Trim(_strAuxiliar).Equals("") Then
            _Cliente.cdiames = _funcoes.RemoverCaracter2(MskDiaMes.Text)
        End If

    End Sub

    Sub DesfazCamposCliente()
        txtIdCliente.Text = ""
        cboRua.SelectedIndex = -1
        cboBairro.SelectedIndex = -1
        txtCidadeCli.Text = ""
        mskTelefoneCli.Text = ""
        MskDiaMes.Text = ""
        mskCnpjCpf.Text = ""
        _Cliente.ZeraValores()
    End Sub

    Private Sub btnSalvaProdUsados_Click(sender As Object, e As EventArgs) Handles btnSalvaProdUsados.Click


        If CDbl(txtValorTotalVendaServico.Text) > 0 Then

            If MessageBox.Show("Ainda há Serviço em Andamento deseja continuar?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) _
                = Windows.Forms.DialogResult.No Then
                Return
            Else
                chkProdutoUsadoVenda.Checked = False
            End If
        End If



    End Sub

    Sub gravaProdutosUsados(Optional ByVal botao As String = "P")

        If dtgProdutoUsado.Rows.Count > 0 Then

            _ListaProdutosUsados.Clear()
            PreencheListaProdutosUsadoGrid(_ListaProdutosUsados)

            _ListaProdutosUsadosVenda.Clear()
            If chkProdutoUsadoVenda.Checked Then PreencheListaProdutosUsadoVendaGrid(_ListaProdutosUsadosVenda, _IdVendaServico)


            Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
            Try


                Try
                    connection.Open()
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message)
                    connection = Nothing : Return
                End Try

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction

                For Each ps As ClProdutoUsado In _ListaProdutosUsados
                    _ProdutoUsadoDAO.incProdutoUsado(ps, connection, transacao)
                Next

                If _ListaProdutosUsadosVenda.Count > 0 Then
                    For Each ps As ClProdutoUsadoVenda In _ListaProdutosUsadosVenda
                        _ProdutoUsadoVendaDAO.incProdutoUsadoVenda(ps, connection, transacao)
                    Next
                End If
                transacao.Commit()

                If botao.Equals("P") Then MsgBox("Produtos Usados Salvo com Sucesso!", MsgBoxStyle.Exclamation)
                _ListaProdutosUsados.Clear()
                ZeraCamposProdutosUsadosGri()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            Finally
                connection.ClearPool() : connection.Close() : connection = Nothing
            End Try


        End If

    End Sub

    Sub PreencheListaProdutosUsadoGrid(ByRef list As List(Of ClProdutoUsado))

        For Each pu As DataGridViewRow In dtgProdutoUsado.Rows

            If Not pu.IsNewRow Then

                list.Add(New ClProdutoUsado(Date.Now, 0, pu.Cells(0).Value, 0, _
                                            pu.Cells(1).Value.ToString, "", pu.Cells(2).Value))
            End If
        Next
    End Sub

    Sub PreencheListaProdutosUsadoVendaGrid(ByRef list As List(Of ClProdutoUsadoVenda), ByVal idVenda As Int64)

        For Each pu As DataGridViewRow In dtgProdutoUsado.Rows

            If Not pu.IsNewRow Then

                list.Add(New ClProdutoUsadoVenda(Date.Now, 0, pu.Cells(0).Value, 0, _
                                            pu.Cells(1).Value.ToString, "", pu.Cells(2).Value, idVenda))
            End If
        Next
    End Sub

    Sub ZeraCamposProdutosUsadosGri()
        dtgProdutoUsado.Rows.Clear()
        cboProdutoUsado.SelectedIndex = -1
        txtQtdeProdUsado.Text = "0"
    End Sub

    Private Sub btnConfirmarVenda_Click(sender As Object, e As EventArgs) Handles btnConfirmarVenda.Click

        ExecuteF7()
    End Sub

    Sub ExecuteF7()

        If VerificaTodoCamposFinaliza() Then

            _VendaServico.ZeraValores()
            PreencheValoresVendaServico()
            SalvandoVendaServico()

        End If

    End Sub

    Sub PreencheItensVendaServico(ByVal vVendaServico As ClVendaServico)

        Dim mCount As Integer = 0
        _ListaItensVendaServico.Clear()
        If dtgServicos.RowCount > 0 Then

            For Each dtgi As DataGridViewRow In dtgServicos.Rows
                If Not dtgi.IsNewRow Then
                    _valorAuxiliar = CDbl(dtgi.Cells(9).Value) 'Despesa do Cartao Cobrada por Serviço
                    If _valorAuxiliar > 0 Then mCount += 1
                End If
            Next

            For Each dtgi As DataGridViewRow In dtgServicos.Rows

                If Not dtgi.IsNewRow Then
                    _ItenVendaServico.ZeraValores()

                    With _ItenVendaServico

                        .Data = Date.Now
                        .IdVendaServico = vVendaServico.vsid
                        _valorAuxiliar = vVendaServico.vspagocredito + vVendaServico.vspagodebito
                        .TotalCartaoVendaServico = _valorAuxiliar
                        _valorAuxiliar = CDbl(dtgi.Cells(9).Value) 'Despesa do Cartao Cobrada por Serviço
                        .TotalCartaoSeparadoVendaServico = 0
                        If _valorAuxiliar > 0 AndAlso .TotalCartaoVendaServico > 0 AndAlso mCount > 0 Then .TotalCartaoSeparadoVendaServico = .TotalCartaoVendaServico / mCount
                        .IdServico = CInt(dtgi.Cells(0).Value)
                        .NomeServico = dtgi.Cells(1).Value
                        .DespCartaoServico_Porcent = _valorAuxiliar
                        .DespCartaoServico_Valor = CDbl(dtgi.Cells(10).Value)
                        .IdAtendente = CInt(dtgi.Cells(7).Value)
                        .NomeAtendente = dtgi.Cells(6).Value
                        .ComissaoAtendente = CDbl(dtgi.Cells(8).Value)
                        .QuantidadeServico = CDbl(dtgi.Cells(2).Value)
                        .ValorServico = CDbl(dtgi.Cells(3).Value)
                        .DescontoServico = CDbl(dtgi.Cells(4).Value)
                        .SubTotalServico = .QuantidadeServico * .ValorServico
                        .ValorTotalServico = CDbl(dtgi.Cells(5).Value)
                        .DespCartaoSeparado = 0
                        If (.TotalCartaoSeparadoVendaServico > 0) AndAlso (.DespCartaoServico_Porcent > 0) Then
                            .DespCartaoSeparado = ((.TotalCartaoSeparadoVendaServico * .DespCartaoServico_Porcent) / 100)
                        End If

                        .ValorComissao = 0
                        If .ComissaoAtendente > 0 Then
                            .ValorComissao = (((.ValorTotalServico - .DespCartaoSeparado) * .ComissaoAtendente) / 100)
                        End If

                    End With
                    _ListaItensVendaServico.Add(New ClVendaServicoItens(0, _ItenVendaServico.Data, _ItenVendaServico.IdVendaServico, _
                                                _ItenVendaServico.TotalCartaoVendaServico, _ItenVendaServico.TotalCartaoSeparadoVendaServico, _
                                                _ItenVendaServico.IdServico, _ItenVendaServico.NomeServico, _ItenVendaServico.DespCartaoServico_Porcent, _
                                                _ItenVendaServico.DespCartaoServico_Valor, _ItenVendaServico.IdAtendente, _ItenVendaServico.NomeAtendente, _
                                                _ItenVendaServico.ComissaoAtendente, _ItenVendaServico.QuantidadeServico, _ItenVendaServico.ValorServico, _
                                                _ItenVendaServico.DescontoServico, _ItenVendaServico.SubTotalServico, _ItenVendaServico.ValorTotalServico, _
                                                _ItenVendaServico.DespCartaoSeparado, _ItenVendaServico.ValorComissao))

                End If
            Next
        End If
    End Sub

    Sub SalvandoVendaServico()

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim mIdCliente As Integer = 0, mIdVendaServico As Int64 = 0
        Try


            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                conexao = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = conexao.BeginTransaction


            If chkGravarDadosCliente.Checked Then

                'AJUSTA CLIENTE:
                If IsNumeric(txtIdCliente.Text) Then mIdCliente = CInt(txtIdCliente.Text)
                If mIdCliente > 0 Then 'Altera Cliente
                    _ClienteDAO.altCliente(_Cliente, conexao, transacao)
                Else
                    _ClienteDAO.incCliente(_Cliente, conexao, transacao)
                    mIdCliente = _ClienteDAO.TrazIdUltimoCliente(conexao, transacao)
                End If

                'AJUSTA RUAS:
                If _Rua.rId > 0 Then
                    If _ruaDAO.ValidaRuaSemMensagem(_Rua, "A") Then
                        _ruaDAO.altRua(_Rua, conexao, transacao)
                    End If
                Else
                    If _ruaDAO.ValidaRuaSemMensagem(_Rua, "I") Then
                        _ruaDAO.incRua(_Rua, conexao, transacao)
                    End If
                End If

                'AJUSTA BAIRRO:
                If _Bairro.bId > 0 Then
                    If _BairroDAO.ValidaBairroSemMensagem(_Bairro, "A") Then
                        _BairroDAO.altBairro(_Bairro, conexao, transacao)
                    End If
                Else
                    If _BairroDAO.ValidaBairroSemMensagem(_Bairro, "I") Then
                        _BairroDAO.incBairro(_Bairro, conexao, transacao)
                    End If
                End If
            End If

            If _Agendamento.a_id > 0 Then mIdCliente = _Agendamento.a_pessoaid
            _VendaServico.vsclienteid = mIdCliente
            _VendaServico.vsclientenome = _Cliente.cnome
            _VendaServicoDAO.incVendaServico(_VendaServico, conexao, transacao)
            mIdVendaServico = _VendaServicoDAO.TrazIdUltimoVendaServico(conexao, transacao)
            _VendaServico.vsid = mIdVendaServico
            _IdVendaServico = mIdVendaServico
            PreencheItensVendaServico(_VendaServico)
            _ItenVendaServicoDAO.incVendaServicoItensLista(_ListaItensVendaServico, conexao, transacao)

            If (chkProdutoUsadoVenda.Checked = False) AndAlso (dtgProdutoUsado.Rows.Count > 0) Then

                If MessageBox.Show("Deseja Gravar os Produtos Usados?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then
                    chkProdutoUsadoVenda.Checked = True
                    gravaProdutosUsados("V")
                End If
            End If

            'Lança no crediário:
            If CDbl(txtValorPagoCrediario.Text) > 0 Then
                SalvandoContaAReceber(_IdVendaServico, conexao, transacao)
            End If

            If _Agendamento.a_id > 0 Then
                _Agendamento.a_financeiro = True
                DaoAgendamento.altAgendamento(_Agendamento, conexao, transacao)
                _Modificado = True
            End If

            transacao.Commit()

            MsgBox("Venda de Serviço Salva com Sucesso!", MsgBoxStyle.Exclamation)

            If _Agendamento.a_id > 0 Then
                Me.Close()
            End If

            If chkGravarDadosCliente.Checked Then
                AtualizaCboRUA()
                AtualizaCboBAIRRO()
                _ClienteDAO.TrazListClientes_BD(MdlConexaoBD.ListaClientes, MdlConexaoBD.conectionPadrao)
            End If

            If CDbl(txtValorPagoCrediario.Text) > 0 Then
                _ContaAReceberDAO.TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
            End If
            ZeraTodosCamposVendaServico()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            conexao.ClearPool() : conexao.Close() : conexao = Nothing
        End Try

    End Sub

    Sub SalvandoContaAReceber(idVenda As Int64, conexao As NpgsqlConnection, transacao As NpgsqlTransaction)

        _ContaAReceber.ZeraValores()

        With _ContaAReceber

            .art_tela = "SVENDAS"
            .art_clienteid = _Cliente.cid
            .art_clientenome = _Cliente.cnome
            .art_dataemissao = Date.Now
            .art_datavencimento = Date.Now.AddDays(MdlConexaoBD.mdlConfiguracoes.tDiasVencCrediario)
            .art_valor = CDbl(txtValorPagoCrediario.Text)
            .art_valorrestante = CDbl(txtValorPagoCrediario.Text)
            .art_observacao = "LANÇAMENTO AUTOMATICO NA VENDA DE SERVIÇO"
            .art_idvendaservico = idVenda

        End With

        _ContaAReceberDAO.incAReceberTotal(_ContaAReceber, conexao, transacao)


    End Sub

    Sub PreencheValoresVendaServico()

        _VendaServico.vsempresaid = MdlConexaoBD.mdlEmpresa.empid
        _VendaServico.vsempresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
        _VendaServico.vsempresauf = MdlConexaoBD.mdlEmpresa.empestado
        _VendaServico.vsempresacidade = MdlConexaoBD.mdlEmpresa.empcidade
        _VendaServico.vsclienteid = 0
        If IsNumeric(txtIdCliente.Text) Then _VendaServico.vsclienteid = CInt(txtIdCliente.Text)
        _VendaServico.vsclientenome = Trim(txtNomeCliente.Text)
        _VendaServico.vsclienteuf = ""
        If _Cliente.cid > 0 Then _VendaServico.vsclienteuf = Trim(txtEstadoCli.Text)
        _VendaServico.vsclientecidade = Trim(txtCidadeCli.Text)
        _VendaServico.vsdatahora = Date.Now
        _VendaServico.vssubtotal = CDbl(txtSubTotVenda.Text)
        _VendaServico.vsdesconto = CDbl(txtValorTotDescVenda.Text)
        _VendaServico.vstotalgeral = CDbl(txtValorTotalVendaServico.Text)
        _VendaServico.vspagodinheiro = CDbl(txtValorPagoDinheiro.Text)
        _VendaServico.vspagocredito = CDbl(txtValorPagoCTCredito.Text)
        _VendaServico.vspagodebito = CDbl(txtValorPagoCTDebito.Text)
        _VendaServico.vspagopix = CDbl(txtValorPagoPix.Text)
        _VendaServico.vspagotransferencia = CDbl(txtValorPagoTransferencia.Text)
        _VendaServico.vspagocrediario = CDbl(txtValorPagoCrediario.Text)

    End Sub

    Function VerificaTodoCamposFinaliza() As Boolean

        If CDbl(txtValorTotalVendaServico.Text) <= 0 Then
            MsgBox("Deve informar algum Serviço para Confirmar!", MsgBoxStyle.Exclamation, Application.CompanyName)
            cboServico.Focus() : cboServico.DroppedDown = True
            Return False
        End If

        If CDbl(txtValorTotalVendaServico.Text) <> CDbl(txtValorPago.Text) Then

            MsgBox("Valor Total dos Serviços está diferente do Valor PAGO!", MsgBoxStyle.Exclamation, Application.CompanyName)
            txtValorPagoDinheiro.Focus() : txtValorPagoDinheiro.Focus()
            Return False
        End If

        PreencheValoresCliente()
        Dim mTipoOperacao As String = "I"
        If _Cliente.cid > 0 Then mTipoOperacao = "A"

        If Trim(txtNomeCliente.Text).Equals("") = False Then

            If _valueChangeCliente Then

                If _Cliente.cnome.Length > 0 AndAlso chkGravarDadosCliente.Checked = False Then
                    If MessageBox.Show("Deseja que o Sistema Grave os Dados do Cliente?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                        = Windows.Forms.DialogResult.Yes Then
                        chkGravarDadosCliente.Checked = True
                    End If
                End If

                If chkGravarDadosCliente.Checked Then

                    If _ClienteDAO.ValidaCliente(_Cliente, mTipoOperacao) = False Then
                        txtNomeCliente.Focus() : txtNomeCliente.SelectAll()
                        Return False
                    End If
                End If
            End If

        End If


        If CDbl(txtValorPagoCrediario.Text) > 0 AndAlso _Cliente.cnome.Length <= 0 Then

            MsgBox("Foi informado o valor de " & CDbl(txtValorPagoCrediario.Text).ToString("#,##0.00") & " no Crediário ! Será necessário informar um cliente! ", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            txtIdCliente.Focus()
            Return False
        End If


        Return True
    End Function

    Private Sub txtTotGeralServicos_TextChanged(sender As Object, e As EventArgs) Handles txtTotGeralServicos.TextChanged
        txtValorTotalVendaServico.Text = txtTotGeralServicos.Text
    End Sub

    Function CalculaSubTotalServicos() As Double

        'Vai somar
        _valorAuxiliar = 0
        If dtgServicos.Rows.Count > 0 Then

            For Each s As DataGridViewRow In dtgServicos.Rows

                If Not s.IsNewRow Then

                    _valorAuxiliar += (CDbl(s.Cells(3).Value) * CDbl(s.Cells(2).Value))
                End If
            Next
        End If

        Return _valorAuxiliar
    End Function

    Function CalculaTotalGeralServicos() As Double

        'Vai somar
        _valorAuxiliar = 0
        If dtgServicos.Rows.Count > 0 Then

            For Each s As DataGridViewRow In dtgServicos.Rows

                If Not s.IsNewRow Then

                    _valorAuxiliar += CDbl(s.Cells(5).Value)
                End If
            Next
        End If

        Return _valorAuxiliar
    End Function

    Function CalculaTotalDescontoServicos() As Double

        'Vai somar
        _valorAuxiliar = 0
        If dtgServicos.Rows.Count > 0 Then

            For Each s As DataGridViewRow In dtgServicos.Rows

                If Not s.IsNewRow Then

                    _valorAuxiliar += CDbl(s.Cells(4).Value)
                End If
            Next
        End If

        Return _valorAuxiliar
    End Function

    Sub ReajustaValoresDePagamento()

        If CDbl(txtValorTotalVendaServico.Text) < CDbl(txtValorPago.Text) Then
            txtValorPagoTransferencia.Text = "0,00"
            txtValorPagoPix.Text = "0,00"
            txtValorPagoCTDebito.Text = "0,00"
            txtValorPagoCTCredito.Text = "0,00"
            txtValorPagoDinheiro.Text = CDbl(txtValorTotalVendaServico.Text).ToString("#,##0.00")
            txtValorPago.Text = CDbl(txtValorTotalVendaServico.Text).ToString("#,##0.00")
        End If
    End Sub

    Private Sub dtgServicos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgServicos.RowsAdded

        txtSubTotVenda.Text = CalculaSubTotalServicos.ToString("#,##0.00")
        txtValorTotDescVenda.Text = CalculaTotalDescontoServicos.ToString("#,##0.00")
        txtValorTotalVendaServico.Text = CalculaTotalGeralServicos.ToString("#,##0.00")
        ReajustaValorPagoDinheiro()

    End Sub

    Private Sub dtgServicos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgServicos.RowsRemoved

        txtSubTotVenda.Text = CalculaSubTotalServicos.ToString("#,##0.00")
        txtValorTotDescVenda.Text = CalculaTotalDescontoServicos.ToString("#,##0.00")
        txtValorTotalVendaServico.Text = CalculaTotalGeralServicos.ToString("#,##0.00")
        ReajustaValoresDePagamento()
        ReajustaValorPagoDinheiro()

    End Sub

    Private Sub cboAtendente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAtendente.SelectedIndexChanged

        _Atendente.ZeraValores()
        If cboAtendente.SelectedIndex > -1 Then
            _Atendente.aNome = cboAtendente.SelectedItem.ToString
            _AtententeDAO.TrazAtendenteNomeDaLista(_Atendente)
        End If

    End Sub

    Private Sub txtValorPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorPagoDinheiro.KeyPress, txtValorPagoCTCredito.KeyPress, txtValorPagoTransferencia.KeyPress, txtValorPagoPix.KeyPress, txtValorPagoCTDebito.KeyPress, txtValorPagoCrediario.KeyPress
        'permite só numeros e virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtValorPagoDinheiro_GotFocus(sender As Object, e As EventArgs) Handles txtValorPagoDinheiro.GotFocus
        txtValorPagoDinheiro.BackColor = Color.AliceBlue
        txtValorPagoDinheiro.SelectAll()
    End Sub

    Private Sub txtValorPagoCTCredito_GotFocus(sender As Object, e As EventArgs) Handles txtValorPagoCTCredito.GotFocus
        txtValorPagoCTCredito.BackColor = Color.AliceBlue
        txtValorPagoCTCredito.SelectAll()
    End Sub

    Private Sub txtValorPagoCTDebito_GotFocus(sender As Object, e As EventArgs) Handles txtValorPagoCTDebito.GotFocus
        txtValorPagoCTDebito.BackColor = Color.AliceBlue
        txtValorPagoCTDebito.SelectAll()
    End Sub

    Private Sub txtValorPagoPix_GotFocus(sender As Object, e As EventArgs) Handles txtValorPagoPix.GotFocus
        txtValorPagoPix.BackColor = Color.AliceBlue
        txtValorPagoPix.SelectAll()
    End Sub

    Private Sub txtValorPagoTransferencia_GotFocus(sender As Object, e As EventArgs) Handles txtValorPagoTransferencia.GotFocus
        txtValorPagoTransferencia.BackColor = Color.AliceBlue
        txtValorPagoTransferencia.SelectAll()
    End Sub

    Private Sub txtValorPagoCrediario_GotFocus(sender As Object, e As EventArgs) Handles txtValorPagoCrediario.GotFocus
        txtValorPagoCrediario.BackColor = Color.White
        txtValorPagoCrediario.SelectAll()
    End Sub

    Private Sub txtValorPagoDinheiro_Leave(sender As Object, e As EventArgs) Handles txtValorPagoDinheiro.Leave

        txtValorPagoDinheiro.BackColor = Color.White
        If CDbl(txtValorTotalVendaServico.Text) <= 0 Then Return


        If IsNumeric(txtValorPagoDinheiro.Text) Then 'Se for Número

            txtValorPagoDinheiro.Text = CDbl(txtValorPagoDinheiro.Text).ToString("#,##0.00")
            verificaValoresPagos("DN")
        Else
            MsgBox("Valor deve ser Numérico!", MsgBoxStyle.Exclamation, Application.CompanyName)
            txtValorPagoDinheiro.Focus() : txtValorPagoDinheiro.SelectAll() : Return
        End If
    End Sub

    Private Sub txtValorPagoCTCredito_Leave(sender As Object, e As EventArgs) Handles txtValorPagoCTCredito.Leave

        txtValorPagoCTCredito.BackColor = Color.White
        If CDbl(txtValorTotalVendaServico.Text) <= 0 Then Return


        If IsNumeric(txtValorPagoCTCredito.Text) Then

            txtValorPagoCTCredito.Text = CDbl(txtValorPagoCTCredito.Text).ToString("#,##0.00")
            verificaValoresPagos("CTC")
        Else
            MsgBox("Valor deve ser Numérico!", MsgBoxStyle.Exclamation, Application.CompanyName)
            txtValorPagoCTCredito.Focus() : txtValorPagoCTCredito.SelectAll() : Return
        End If

        _valorAuxiliar = 0
    End Sub

    Private Sub txtValorPagoCTDebito_Leave(sender As Object, e As EventArgs) Handles txtValorPagoCTDebito.Leave

        txtValorPagoCTDebito.BackColor = Color.White
        If CDbl(txtValorTotalVendaServico.Text) <= 0 Then Return

        If IsNumeric(txtValorPagoCTDebito.Text) Then

            txtValorPagoCTDebito.Text = CDbl(txtValorPagoCTDebito.Text).ToString("#,##0.00")
            verificaValoresPagos("CTD")
        Else
            MsgBox("Valor deve ser Numérico!", MsgBoxStyle.Exclamation, Application.CompanyName)
            txtValorPagoCTDebito.Focus() : txtValorPagoCTDebito.SelectAll() : Return
        End If

        _valorAuxiliar = 0
    End Sub

    Private Sub txtValorPagoPix_Leave(sender As Object, e As EventArgs) Handles txtValorPagoPix.Leave

        txtValorPagoPix.BackColor = Color.White
        If CDbl(txtValorTotalVendaServico.Text) <= 0 Then Return

        If IsNumeric(txtValorPagoPix.Text) Then

            txtValorPagoPix.Text = CDbl(txtValorPagoPix.Text).ToString("#,##0.00")
            verificaValoresPagos("PIX")
        Else
            MsgBox("Valor deve ser Numérico!", MsgBoxStyle.Exclamation, Application.CompanyName)
            txtValorPagoPix.Focus() : txtValorPagoPix.SelectAll() : Return
        End If

        _valorAuxiliar = 0
    End Sub

    Private Sub txtValorPagoTransferencia_Leave(sender As Object, e As EventArgs) Handles txtValorPagoTransferencia.Leave

        txtValorPagoTransferencia.BackColor = Color.White
        If CDbl(txtValorTotalVendaServico.Text) <= 0 Then Return

        If IsNumeric(txtValorPagoTransferencia.Text) Then

            txtValorPagoTransferencia.Text = CDbl(txtValorPagoTransferencia.Text).ToString("#,##0.00")
            verificaValoresPagos("TRA")
        Else
            MsgBox("Valor deve ser Numérico!", MsgBoxStyle.Exclamation, Application.CompanyName)
            txtValorPagoTransferencia.Focus() : txtValorPagoTransferencia.SelectAll() : Return
        End If

        _valorAuxiliar = 0
    End Sub

    Private Sub txtValorPagoCrediarioa_Leave(sender As Object, e As EventArgs) Handles txtValorPagoCrediario.Leave

        txtValorPagoCrediario.BackColor = Color.White
        If CDbl(txtValorTotalVendaServico.Text) <= 0 Then Return

        If IsNumeric(txtValorPagoCrediario.Text) Then

            If CDbl(txtValorPagoCrediario.Text) > 0 Then
                txtValorPagoCrediario.BackColor = Color.LightBlue
            End If
            txtValorPagoCrediario.Text = CDbl(txtValorPagoCrediario.Text).ToString("#,##0.00")
            verificaValoresPagos("CRD")
        Else
            txtValorPagoCrediario.Text = "0,00"
        End If

        _valorAuxiliar = 0
    End Sub

    Sub verificaValoresPagos(Optional ByVal formPag As String = "DN")
        Dim mValorFormaPag As Double = 0.0
        _valorAuxiliar = 0

        Select Case formPag.ToUpper()
            Case "DN" 'Se Dinheiro

                mValorFormaPag = CDbl(txtValorPagoDinheiro.Text)
                _valorAuxiliar = CDbl(txtValorPagoCTCredito.Text) + CDbl(txtValorPagoCTDebito.Text) + CDbl(txtValorPagoPix.Text) + CDbl(txtValorPagoTransferencia.Text) + CDbl(txtValorPagoCrediario.Text)

                If (_valorAuxiliar + mValorFormaPag) > CDbl(txtValorTotalVendaServico.Text) Then

                    MsgBox("Valor Pago Não Pode ser Maior que o Total dos Serviços!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    txtValorPagoDinheiro.Focus() : txtValorPagoDinheiro.SelectAll() : Return

                End If

            Case "CTC" 'Credito

                mValorFormaPag = CDbl(txtValorPagoCTCredito.Text)
                _valorAuxiliar = CDbl(txtValorPagoDinheiro.Text) + CDbl(txtValorPagoCTDebito.Text) + CDbl(txtValorPagoPix.Text) + CDbl(txtValorPagoTransferencia.Text) + CDbl(txtValorPagoCrediario.Text)

                If (_valorAuxiliar + mValorFormaPag) > CDbl(txtValorTotalVendaServico.Text) Then

                    MsgBox("Valor Pago Não Pode ser Maior que o Total dos Serviços!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    txtValorPagoCTCredito.Focus() : txtValorPagoCTCredito.SelectAll() : Return

                End If

            Case "CTD" 'Debito

                mValorFormaPag = CDbl(txtValorPagoCTDebito.Text)
                _valorAuxiliar = CDbl(txtValorPagoCTCredito.Text) + CDbl(txtValorPagoDinheiro.Text) + CDbl(txtValorPagoPix.Text) + CDbl(txtValorPagoTransferencia.Text) + CDbl(txtValorPagoCrediario.Text)

                If (_valorAuxiliar + mValorFormaPag) > CDbl(txtValorTotalVendaServico.Text) Then

                    MsgBox("Valor Pago Não Pode ser Maior que o Total dos Serviços!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    txtValorPagoCTDebito.Focus() : txtValorPagoCTDebito.SelectAll() : Return

                End If

            Case "PIX" 'PIX

                mValorFormaPag = CDbl(txtValorPagoPix.Text)
                _valorAuxiliar = CDbl(txtValorPagoCTCredito.Text) + CDbl(txtValorPagoCTDebito.Text) + CDbl(txtValorPagoDinheiro.Text) + CDbl(txtValorPagoTransferencia.Text) + CDbl(txtValorPagoCrediario.Text)

                If (_valorAuxiliar + mValorFormaPag) > CDbl(txtValorTotalVendaServico.Text) Then

                    MsgBox("Valor Pago Não Pode ser Maior que o Total dos Serviços!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    txtValorPagoPix.Focus() : txtValorPagoPix.SelectAll() : Return

                End If

            Case "TRA" 'Transferencia

                mValorFormaPag = CDbl(txtValorPagoTransferencia.Text)
                _valorAuxiliar = CDbl(txtValorPagoCTCredito.Text) + CDbl(txtValorPagoCTDebito.Text) + CDbl(txtValorPagoPix.Text) + CDbl(txtValorPagoDinheiro.Text) + CDbl(txtValorPagoCrediario.Text)

                If (_valorAuxiliar + mValorFormaPag) > CDbl(txtValorTotalVendaServico.Text) Then

                    MsgBox("Valor Pago Não Pode ser Maior que o Total dos Serviços!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    txtValorPagoTransferencia.Focus() : txtValorPagoTransferencia.SelectAll() : Return

                End If

            Case "CRD" 'Crediário

                mValorFormaPag = CDbl(txtValorPagoCrediario.Text)
                _valorAuxiliar = CDbl(txtValorPagoCTCredito.Text) + CDbl(txtValorPagoCTDebito.Text) + CDbl(txtValorPagoPix.Text) + CDbl(txtValorPagoDinheiro.Text) + CDbl(txtValorPagoTransferencia.Text)

                If (_valorAuxiliar + mValorFormaPag) > CDbl(txtValorTotalVendaServico.Text) Then

                    MsgBox("Valor Pago Não Pode ser Maior que o Total dos Serviços!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    txtValorPagoCrediario.Focus() : txtValorPagoCrediario.SelectAll() : Return

                End If

        End Select
        txtValorPago.Text = (_valorAuxiliar + mValorFormaPag).ToString("#,##0.00")
    End Sub

    Sub ReajustaValorPagoDinheiro()


        If CDbl(txtValorTotalVendaServico.Text) > 0 Then

            If IsNumeric(txtValorPagoDinheiro.Text) Then 'Se for Número

                txtValorPagoDinheiro.Text = CDbl(txtValorPagoDinheiro.Text).ToString("#,##0.00")
                _valorAuxiliar = CDbl(txtValorPagoCTCredito.Text) + CDbl(txtValorPagoCTDebito.Text) + CDbl(txtValorPagoPix.Text) + CDbl(txtValorPagoTransferencia.Text)

                If (CDbl(txtVlrServico.Text) - _valorAuxiliar) > 0 Then
                    txtValorPagoDinheiro.Text = (CDbl(txtValorTotalVendaServico.Text) - _valorAuxiliar).ToString("#,##0.00")
                End If

                verificaValoresPagos("DN")
            Else
                MsgBox("Valor deve ser Numérico!", MsgBoxStyle.Exclamation, Application.CompanyName)
                txtValorPagoDinheiro.Focus() : txtValorPagoDinheiro.SelectAll() : Return
            End If

        Else
            txtValorPagoDinheiro.Text = "0,00" : txtValorPagoCTCredito.Text = "0,00" : txtValorPago.Text = "0,00"
            txtValorPagoCTDebito.Text = "0,00" : txtValorPagoPix.Text = "0,00" : txtValorPagoTransferencia.Text = "0,00"
        End If
        _valorAuxiliar = 0
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ExecuteF9()
    End Sub

    Sub ExecuteF9()

        If CDbl(txtValorTotalVendaServico.Text) > 0 Then

            If MessageBox.Show("Deseja realmente cancelar?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Information) _
            = Windows.Forms.DialogResult.Yes Then

                dtgServicos.Rows.Clear()
                txtIdCliente.Text = "" : txtNomeCliente.Text = ""
                dtgProdutoUsado.Rows.Clear()
                ReajustaValorPagoDinheiro()
            End If
        End If

    End Sub

    Private Sub txtValorTotalServicos_TextChanged(sender As Object, e As EventArgs) Handles txtValorTotalVendaServico.TextChanged

        If CDbl(txtValorTotalVendaServico.Text) <= 0 Then
            txtTotGeralServicos.Text = "0,00"
        End If
    End Sub

    Private Sub mskTelefoneCli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskTelefoneCli.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtValorTotDescVenda_Leave(sender As Object, e As EventArgs) Handles txtValorTotDescVenda.Leave


        If IsNumeric(txtValorTotDescVenda.Text) Then

            If CDbl(txtValorTotDescVenda.Text) > CDbl(txtValorTotalVendaServico.Text) Then

                MsgBox("Valor Total do Desconto não pode ser Maior que o valor TOTAL da VENDA dos SERVIÇOS", MsgBoxStyle.Exclamation, Application.CompanyName)
                txtValorTotDescVenda.Focus() : txtValorTotDescVenda.SelectAll() : Return

            ElseIf CDbl(txtValorTotDescVenda.Text) = CDbl(txtValorTotalVendaServico.Text) Then

                If MessageBox.Show("Total dos Descontos está igual ao TOTAL da VENDA dos SERVIÇOS! Deseja continuar?!", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                    = Windows.Forms.DialogResult.No Then

                    txtValorTotDescVenda.Focus() : txtValorTotDescVenda.SelectAll() : Return
                End If

            Else 'Ajustar o valor total geral:
                txtValorTotDescVenda.Text = CDbl(txtValorTotDescVenda.Text).ToString("#,##0.00")
                txtValorTotalVendaServico.Text = (CDbl(txtSubTotVenda.Text) - CDbl(txtValorTotDescVenda.Text)).ToString("#,##0.00")
                ReajustaValoresDePagamento()

            End If
        Else
            txtValorTotDescVenda.Text = txtValorTotalVendaServico.Text
        End If
    End Sub

    Private Sub txtValorTotDescVenda_Click(sender As Object, e As EventArgs) Handles txtValorTotDescVenda.Click
        txtValorTotDescVenda.SelectAll()
    End Sub

    Private Sub txtValorPagoDinheiro_Click(sender As Object, e As EventArgs) Handles txtValorPagoDinheiro.Click
        txtValorPagoDinheiro.SelectAll()
    End Sub

    Private Sub txtValorPagoCTCredito_Click(sender As Object, e As EventArgs) Handles txtValorPagoCTCredito.Click
        txtValorPagoCTCredito.SelectAll()
    End Sub

    Private Sub txtValorPagoCTDebito_Click(sender As Object, e As EventArgs) Handles txtValorPagoCTDebito.Click
        txtValorPagoCTDebito.SelectAll()
    End Sub

    Private Sub txtValorPagoPix_Click(sender As Object, e As EventArgs) Handles txtValorPagoPix.Click
        txtValorPagoPix.SelectAll()
    End Sub

    Private Sub txtValorPagoTransferencia_Click(sender As Object, e As EventArgs) Handles txtValorPagoTransferencia.Click
        txtValorPagoTransferencia.SelectAll()
    End Sub

    Private Sub txtValorPagoCrediario_Click(sender As Object, e As EventArgs) Handles txtValorPagoCrediario.Click
        txtValorPagoCrediario.SelectAll()
    End Sub

    Private Sub cboBairro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBairro.SelectedIndexChanged

        Try
            _Bairro.ZeraValores()
            If cboBairro.SelectedIndex >= 0 Then
                _Bairro.bNome = Trim(cboBairro.SelectedItem.ToString())
                _BairroDAO.TrazBairroNome(_Bairro, MdlConexaoBD.conectionPadrao)
            End If
        Catch ex As Exception
            _Bairro.ZeraValores()
        End Try
    End Sub

    Private Sub cboRua_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRua.SelectedIndexChanged

        Try
            _Rua.ZeraValores()
            If cboRua.SelectedIndex >= 0 Then
                _Rua.rNome = Trim(cboRua.SelectedItem.ToString())
                _ruaDAO.TrazRuaNome(_Rua, MdlConexaoBD.conectionPadrao)
            End If
        Catch ex As Exception
            _Rua.ZeraValores()
        End Try
    End Sub

    Private Sub cboRua_Leave(sender As Object, e As EventArgs) Handles cboRua.Leave
        _Rua.rNome = Trim(cboRua.Text)
    End Sub

    Private Sub cboBairro_Leave(sender As Object, e As EventArgs) Handles cboBairro.Leave
        _Bairro.bNome = Trim(cboBairro.Text)
    End Sub

    Private Sub txtQtdeServico_Click(sender As Object, e As EventArgs) Handles txtQtdeServico.Click
        txtQtdeServico.SelectAll()
    End Sub

    Private Sub cboRua_KeyDown(sender As Object, e As KeyEventArgs) Handles cboRua.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                _valueChangeCliente = False
            Case Keys.Tab
                _valueChangeCliente = False
            Case Else
                _valueChangeCliente = True
        End Select
    End Sub

    Private Sub mskTelefoneCli_KeyDown(sender As Object, e As KeyEventArgs) Handles mskTelefoneCli.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                _valueChangeCliente = False
            Case Keys.Tab
                _valueChangeCliente = False
            Case Else
                _valueChangeCliente = True
        End Select
    End Sub

    Private Sub cboBairro_KeyDown(sender As Object, e As KeyEventArgs) Handles cboBairro.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                _valueChangeCliente = False
            Case Keys.Tab
                _valueChangeCliente = False
            Case Else
                _valueChangeCliente = True
        End Select
    End Sub

    Private Sub mskCPF_KeyDown(sender As Object, e As KeyEventArgs)

        Select Case e.KeyCode
            Case Keys.Enter
                _valueChangeCliente = False
            Case Keys.Tab
                _valueChangeCliente = False
            Case Else
                _valueChangeCliente = True
        End Select
    End Sub

    Private Sub txtCidadeCli_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCidadeCli.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                _valueChangeCliente = False
            Case Keys.Tab
                _valueChangeCliente = False
            Case Else
                _valueChangeCliente = True
        End Select
    End Sub

    Private Sub MskDiaMes_KeyDown(sender As Object, e As KeyEventArgs) Handles MskDiaMes.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                _valueChangeCliente = False
            Case Keys.Tab
                _valueChangeCliente = False
            Case Else
                _valueChangeCliente = True
        End Select
    End Sub

    Private Sub cboCliente_KeyDown(sender As Object, e As KeyEventArgs)

        _valueChangeCliente = True
        If _Cliente.cid > 0 Then _valueChangeCliente = False
    End Sub

#End Region

#Region "   Pesquisa dos Serviços"

    Private Sub TabCServicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabCServicos.SelectedIndexChanged

        If TabCServicos.SelectedIndex = 1 Then
            AtualizarBuscaVendaServicos()
        End If
    End Sub

    Sub AtualizarBuscaVendaServicos()

        _ListaVendaServicoPesq.Clear()
        Dim where As String = ""
        _strAuxiliar = Trim(txtPesqNomeCliente.Text)
        If _strAuxiliar.Equals("") Then

            If Date.Compare(msk_DtFim.Text, Msk_DtInicio.Text) < 0 Then
                MsgBox("Data Inicial deve ser Menor ou Igual a Data Final", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                Return
            End If
            where = "WHERE TO_CHAR(vsdatahora, 'DD/MM/YYYY') BETWEEN '" & Msk_DtInicio.Text & "' AND '" & msk_DtFim.Text & "' "
        Else
            where = "WHERE  vsclientenome LIKE '" & _strAuxiliar & "%' "

            If Date.Compare(msk_DtFim.Text, Msk_DtInicio.Text) < 0 Then
                MsgBox("Data Inicial deve ser Menor ou Igual a Data Final", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                Return
            End If
            where += "AND TO_CHAR(vsdatahora, 'DD/MM/YYYY') BETWEEN '" & Msk_DtInicio.Text & "' AND '" & msk_DtFim.Text & "' "
        End If

        where += " ORDER BY vsdatahora DESC"
        _VendaServicoDAO.TrazListVendaServicoBD(_ListaVendaServicoPesq, MdlConexaoBD.conectionPadrao, where)

        dtgVendasServico.Rows.Clear()
        dtgItensVendaServico.Rows.Clear()
        If _ListaVendaServicoPesq.Count > 0 Then

            For Each vs As ClVendaServico In _ListaVendaServicoPesq
                dtgVendasServico.Rows.Add(vs.vsid, vs.vsclientenome.ToUpper, vs.vsdatahora, vs.vstotalgeral.ToString("#,##0.00"), vs.vsdesconto.ToString("#,##0.00"), vs.vssubtotal.ToString("#,##0.00"), vs.vspagodinheiro.ToString("#,##0.00"), vs.vspagocredito.ToString("#,##0.00"), vs.vspagodebito.ToString("#,##0.00"), vs.vspagopix.ToString("#,##0.00"), vs.vspagotransferencia.ToString("#,##0.00"), vs.vspagocrediario.ToString("#,##0.00"))
            Next
        End If

    End Sub

    Sub AtualizaBuscaServicosVenda()

        _ListaItensVendaServicoPesq.Clear()
        _VendaServicoPesq.ZeraValores()
        _VendaServicoPesq.vsid = dtgVendasServico.Rows(dtgVendasServico.CurrentRow.Index).Cells(0).Value
        '_VendaServicoDAO.TrazVendaServico(_VendaServicoPesq, MdlConexaoBD.conectionPadrao)
        _ItenVendaServicoDAO.TrazListItensVendaServicoBD(_VendaServicoPesq, _ListaItensVendaServicoPesq, MdlConexaoBD.conectionPadrao)

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
        '_VendaServicoDAO.TrazVendaServico(_VendaServicoPesq, MdlConexaoBD.conectionPadrao)
        _ProdutoUsadoVendaDAO.TrazListProdutoUsadoVenda(_VendaServicoPesq, _ListaProdutosUsadosVendaPesq, MdlConexaoBD.conectionPadrao)

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

    Private Sub txtPesqNomeCliente_TextChanged(sender As Object, e As EventArgs) Handles txtPesqNomeCliente.TextChanged
        AtualizarBuscaVendaServicos()
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        AtualizarBuscaVendaServicos()
    End Sub

#End Region
    
End Class