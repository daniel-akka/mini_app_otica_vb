Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class FrmCadServicos

    Dim _Servico As New ClServicos
    Dim _ServicoDao As New ClServicosDAO
    Dim _funcoes As New ClFuncoes
    Dim _Produto As New ClProduto
    Dim _ProdutoDAO As New ClProdutoDAO
    Dim _ProdutosServicos As New ClProdutoServico
    Dim _ListaProdutosServico As New List(Of ClProdutoServico)
    Dim _ProdutosServicosDAO As New ClProdutoServicoDAO
    Dim _tipoOperacao As String = "I"
    Dim _Atendente As New ClAtendente
    Dim _AtendenteDAO As New ClAtendenteDAO

    Private Sub FrmCadServico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text += " - " & Application.CompanyName

        _ProdutoDAO.PreencheCboProdutosLista(cboProdutoUsado, MdlConexaoBD.ListaProdutos)
        _AtendenteDAO.PreencheCboAtendentesListaPesquisa(cboAtendente, MdlConexaoBD.ListaAtendentes)
        DesabilitaCamposProdServ()
        ExecutaF5()
    End Sub

    Private Sub FrmCadServico_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
            Case Keys.Delete
                ExecuteDel()
            Case Keys.F2
                ExecutaF2()
        End Select

    End Sub

    Sub ExecutaF2()

        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        CboServicos.SelectedIndex = -1
        ZeraValores()
        DesabilitaCamposProdServ()
        _tipoOperacao = "I"
    End Sub

    Sub DesabilitaCamposProdServ()
        btnAddProdUsado.Enabled = False
        dtgProdutoUsado.Rows.Clear()
    End Sub

    Sub HabilitaCamposProdServ()
        btnAddProdUsado.Enabled = True
        dtgProdutoUsado.Rows.Clear()
    End Sub

    Sub PreenchaValoresServico()
        _Servico.sid = 0
        If IsNumeric(txtIdServico.Text) Then _Servico.sid = CInt(txtIdServico.Text)
        _Servico.sdescricao = txtDescricaoServico.Text
        _Servico.svalor = CDbl(txtValor.Text)
        _Servico.sdespcartaodinheiro = CDbl(txtDespCartaoDinheiro.Text)
        _Servico.sdespcartaoporcentagem = CDbl(txtDespCartaoPorcentagem.Text)
        _Servico.sidatendente = _Atendente.aId
        _Servico.snomeatendente = _Atendente.aNome
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click


        If CDbl(txtValor.Text) = CDbl(txtDespCartaoDinheiro.Text) Then

            If MessageBox.Show("O VALOR do Serviço está igual o Valor da Despesa do Serviço! Deseja Continuar?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                   = Windows.Forms.DialogResult.No Then
                txtDespCartaoDinheiro.Focus() : txtDespCartaoDinheiro.SelectAll()
                Return
            End If
        End If


        If IsNumeric(txtIdServico.Text) Then _Servico.sid = CInt(txtIdServico.Text)
        _Servico.sdescricao = Trim(txtDescricaoServico.Text)
        PreenchaValoresServico()
        If _ServicoDao.ValidaServico(_Servico, _tipoOperacao) = False Then Return

        'Validar Produtos do Serviço:
        _ProdutosServicos.ZeraValores()
        _ListaProdutosServico.Clear()
        If dtgProdutoUsado.Rows.Count > 0 Then

            _ProdutosServicos.ZeraValores()
            _ListaProdutosServico.Clear()
            PreencheListaProdutoGrid(_ListaProdutosServico)
        End If


        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try


            If _tipoOperacao.Equals("I") Then
                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _ServicoDao.incServico(_Servico, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _ServicoDao.altServico(_Servico, connection, transacao)

                'Incluindo os Produtos do Servico:
                If _ListaProdutosServico.Count > 0 Then
                    _ProdutosServicosDAO.delProdutoServico(_Servico, connection, transacao)
                    For Each ps As ClProdutoServico In _ListaProdutosServico
                        _ProdutosServicosDAO.incProdutoServico(ps, connection, transacao)
                    Next
                Else
                    _ProdutosServicosDAO.delProdutoServico(_Servico, connection, transacao)
                End If
                transacao.Commit()

            End If

            MsgBox("Serviço Salvo com Sucesso!", MsgBoxStyle.Exclamation)
            _ServicoDao.TrazListServicos_BD(MdlConexaoBD.ListaServicos, MdlConexaoBD.conectionPadrao)
            txtDescricaoServico.Text = "" : txtIdServico.Text = ""
            _Servico.ZeraValores()
            ZeraValores()
            DesabilitaCamposProdServ()
            ExecutaF5()
            txtDescricaoServico.Focus()
            _tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ZeraValores()
        txtIdServico.Text = "" : txtDescricaoServico.Text = ""
        txtValor.Text = "0,00" : txtDespCartaoDinheiro.Text = "0,00" : txtDespCartaoPorcentagem.Text = "0,00"
        cboAtendente.SelectedIndex = 0
        _Atendente.ZeraValores()
        dtgProdutoUsado.Rows.Clear()
        _ProdutosServicos.ZeraValores()
        _ListaProdutosServico.Clear()
    End Sub

    Sub ExecutaF5()
        '_ServicoDao.PreencheCboServicosBD(CboServicos, MdlConexaoBD.conectionPadrao)
        _ServicoDao.PreencheCboServicosLista(CboServicos, MdlConexaoBD.ListaServicos)
    End Sub

    Sub ExecuteDel()

        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If CboServicos.SelectedIndex < 0 Then MsgBox("Selecione um Serviço para Excluir!") : Return
        If MessageBox.Show("Deseja Realmente Deletar esse Serviço -> """ & CboServicos.SelectedItem & """ ?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _Servico.sdescricao = CboServicos.SelectedItem
            _ServicoDao.TrazServicoNome(_Servico, MdlConexaoBD.conectionPadrao)


            Dim transacao As NpgsqlTransaction
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try

                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
                    Return
                End Try

                transacao = conection.BeginTransaction
                'Deletando os Produtos do Servico:
                _ProdutosServicosDAO.delProdutoServico(_Servico, conection, transacao)
                _ServicoDao.delServico(_Servico, conection, transacao)

                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Serviço Deletado com Sucesso!", MsgBoxStyle.Exclamation)
                _ServicoDao.TrazListServicos_BD(MdlConexaoBD.ListaServicos, MdlConexaoBD.conectionPadrao)
                ZeraValores()
                DesabilitaCamposProdServ()
                ExecutaF5()
                _tipoOperacao = "I"
            Catch ex As Exception
                MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                Try
                    transacao.Rollback()

                Catch ex1 As Exception
                End Try

            Finally
                transacao = Nothing : conection = Nothing
            End Try

        End If

    End Sub

    Sub PreencheCamposServico()

        txtIdServico.Text = _Servico.sid
        txtDescricaoServico.Text = _Servico.sdescricao
        txtValor.Text = _Servico.svalor.ToString("0.00")
        txtDespCartaoDinheiro.Text = _Servico.sdespcartaodinheiro.ToString("0.00")
        txtDespCartaoPorcentagem.Text = _Servico.sdespcartaoporcentagem.ToString("0.00")

        cboAtendente.SelectedIndex = 0
        If _Servico.sidatendente > 0 Then cboAtendente.SelectedIndex = _funcoes.trazIndexCboTextoTodo(_Servico.snomeatendente, cboAtendente)
    End Sub

    Sub ExecutaF3()

        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        ZeraValores()
        If CboServicos.SelectedIndex < 0 Then MsgBox("Selecione um Serviço para Alterar!") : Return
        _Servico.sdescricao = CboServicos.SelectedItem
        _ServicoDao.TrazServicoNome(_Servico, MdlConexaoBD.conectionPadrao)

        _tipoOperacao = "A"
        PreencheCamposServico()
        txtDescricaoServico.Focus()
        HabilitaCamposProdServ()

        _ProdutosServicosDAO.TrazProdutosDoServicoBanco(_Servico, _ListaProdutosServico, MdlConexaoBD.conectionPadrao)
        PreencheGridProdutoUsadoLista(_ListaProdutosServico)

    End Sub

    Private Sub txtValor_Leave(sender As Object, e As EventArgs) Handles txtValor.Leave

        If IsNumeric(txtValor.Text) Then

            If CDbl(txtValor.Text) <= 0 Then
                MsgBox("Valor do Serviço deve ser Maior que ZERO", MsgBoxStyle.Exclamation, Application.CompanyName)
                txtValor.Text = "0,00" : txtValor.Focus() : txtValor.SelectAll()
                Return
            End If
            txtValor.Text = CDbl(txtValor.Text).ToString("0.00")
            CalculaValorDespPorcentagem()
        Else
            MsgBox("Valor do Serviço deve ser numérico", MsgBoxStyle.Exclamation, Application.CompanyName)
            txtValor.Text = "0,00" : txtValor.Focus() : txtValor.SelectAll()
            Return
        End If
    End Sub

    Private Sub txtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValor.KeyPress, txtDespCartaoDinheiro.KeyPress, txtDespCartaoPorcentagem.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtDespCartaoDinheiro_Leave(sender As Object, e As EventArgs) Handles txtDespCartaoDinheiro.Leave

        If IsNumeric(txtDespCartaoDinheiro.Text) Then

            If CDbl(txtDespCartaoDinheiro.Text) > 0 Then
                txtDespCartaoDinheiro.Text = CDbl(txtDespCartaoDinheiro.Text).ToString("0.00")

                If CDbl(txtDespCartaoDinheiro.Text) > CDbl(txtValor.Text) Then
                    MsgBox("Valor da Despesa em Dinheiro não pode ser Maior que o Valor do Serviço", MsgBoxStyle.Exclamation, Application.CompanyName)
                    txtDespCartaoDinheiro.Focus() : txtDespCartaoDinheiro.SelectAll() : Return
                End If
                CalculaValorDespPorcentagem()
            Else
                txtDespCartaoDinheiro.Text = "0,00"
            End If

        Else
            txtDespCartaoDinheiro.Text = "0,00"
            Return
        End If
    End Sub

    Sub CalculaValorDespPorcentagem()
        Dim mValor As Double = CDbl(txtValor.Text)
        Dim mDespDinheiro As Double = CDbl(txtDespCartaoDinheiro.Text)

        If mValor > 0 And mDespDinheiro > 0 Then
            txtDespCartaoPorcentagem.Text = CDbl(((mDespDinheiro * 100) / mValor)).ToString("0.00")
        End If
    End Sub

    Sub CalculaValorDespDinheiro()
        Dim mValor As Double = CDbl(txtValor.Text)
        Dim mDespPorcentage As Double = CDbl(txtDespCartaoPorcentagem.Text)

        If mValor > 0 And mDespPorcentage > 0 Then
            txtDespCartaoDinheiro.Text = CDbl(((mValor * mDespPorcentage) / 100)).ToString("0.00")
        End If
    End Sub

    Private Sub txtDespCartaoPorcentagem_Leave(sender As Object, e As EventArgs) Handles txtDespCartaoPorcentagem.Leave

        If IsNumeric(txtDespCartaoPorcentagem.Text) Then

            If CDbl(txtDespCartaoPorcentagem.Text) > 0 Then
                txtDespCartaoPorcentagem.Text = CDbl(txtDespCartaoPorcentagem.Text).ToString("0.00")
                If CDbl(txtDespCartaoPorcentagem.Text) > 100 Then
                    MsgBox("Valor da Despesa em Porcentagem não pode ser Maior que 100%", MsgBoxStyle.Exclamation, Application.CompanyName)
                    txtDespCartaoPorcentagem.Focus() : txtDespCartaoPorcentagem.SelectAll() : Return
                End If
                CalculaValorDespDinheiro()
            Else
                txtDespCartaoPorcentagem.Text = "0,00"
            End If

        Else
            txtDespCartaoPorcentagem.Text = "0,00"
            Return
        End If
    End Sub

    Private Sub FrmCadServicos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
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

    Function VerificaExisteProdutoUsadoGrid(ByVal prod As ClProduto) As Boolean

        For Each p As DataGridViewRow In dtgProdutoUsado.Rows

            If Not p.IsNewRow Then

                If CInt(p.Cells(0).Value) = prod.pId Then Return True
            End If
        Next

        Return False
    End Function

    Private Sub dtgProdutoUsado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgProdutoUsado.CellContentClick

        If e.ColumnIndex = 3 Then
            dtgProdutoUsado.Rows.RemoveAt(e.RowIndex)
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

    Private Sub txtQtdeProdUsado_GotFocus(sender As Object, e As EventArgs) Handles txtQtdeProdUsado.GotFocus
        txtQtdeProdUsado.SelectAll()
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
                dtgProdutoUsado.Rows.Add(ps.psIdProduto, ps.psProdutoDescricao, ps.psQuantidade.ToString)
            Next
        End If
        
    End Sub

    Private Sub cboAtendente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAtendente.SelectedIndexChanged

        If cboAtendente.SelectedIndex > 0 Then
            _Atendente.aNome = cboAtendente.SelectedItem.ToString
            _AtendenteDAO.TrazAtendenteNome(_Atendente, MdlConexaoBD.conectionPadrao)
        End If
    End Sub
End Class