Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql
Public Class FrmCadProduto

    'Objetos:
    Dim produto As New ClProduto
    Dim produtoDAO As New ClProdutoDAO
    Dim _unidadeProduto As New ClUnidade
    Dim _grupoProduto As New ClGrupoProduto
    Dim _marcaProduto As New ClMarca
    Dim _funcoes As New ClFuncoes
    Dim _listaProdutosPesq As New List(Of ClProduto)
    Dim _listaProdutosRelatorio As New List(Of ClProduto)


    Dim _despProduto As New ClDespesaProduto
    Dim _despProdutoDAO As New ClDespesaProdutoDAO

    'Variaveis:
    Dim tipoOperacao As String = "I"
    Dim _somaPorcentagemDtg As Double = 0.0

    Private Sub FrmCadProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ExecutaF5()
        _unidadeProduto.PreencheCboUnidades(cboUnidade, MdlConexaoBD.conectionPadrao)
        _grupoProduto.PreencheCboGrupos(cboGrupo, MdlConexaoBD.conectionPadrao)
        _marcaProduto.PreencheCboMarcas(cboMarca, MdlConexaoBD.conectionPadrao)
        DesabilitaCampos()

    End Sub

    Private Sub FrmCadProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmCadProduto_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                ExecutaF2()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
            Case Keys.F9
                If btnSalvar.Enabled Then ExecutaF9()
            Case Keys.F11
                ExecutaF11()
        End Select
    End Sub

#Region "Funcoes"

    Sub ZeraValoresFormulario()
        Me.txtPrecoCusto.Text = "0.00" : Me.txtDescricaoProd.Text = ""
        Me.txtInfoProd.Text = "" : Me.txtIdProd.Text = "" : Me.cboUnidade.Text = "" : Me.txtPrecoVenda.Text = "0.00"
        Me.txtReferencia.Text = ""
        If cboGrupo.Items.Count > 0 Then cboGrupo.SelectedIndex = -1
        If cboUnidade.Items.Count > 0 Then cboUnidade.SelectedIndex = -1
        If cboMarca.Items.Count > 0 Then cboMarca.SelectedIndex = -1
        txtProdutoCor.Text = ""
        'Me.txtInfoEstoque.Text = "0.00"
        'Me.txtMargemLucro.Text = "0.00"
        'Me.txtDespesasAdicionais.Text = "0.00"
    End Sub

    Sub DesabilitaCampos()
        Me.txtPrecoCusto.ReadOnly = True : Me.txtDescricaoProd.ReadOnly = True
        Me.txtInfoProd.ReadOnly = True : Me.txtPrecoVenda.ReadOnly = True
        Me.txtReferencia.ReadOnly = True : Me.txtProdutoCor.ReadOnly = True
        Me.txtPrecoCusto.ReadOnly = True
        Me.btnSalvar.Enabled = False : Me.btnCancelar.Enabled = False
        If cboGrupo.Items.Count > 0 Then Me.cboGrupo.SelectedIndex = -1 : Me.cboGrupo.Enabled = False
        If cboUnidade.Items.Count > 0 Then Me.cboUnidade.SelectedIndex = -1 : Me.cboUnidade.Enabled = False
        If cboMarca.Items.Count > 0 Then Me.cboMarca.SelectedIndex = -1 : Me.cboMarca.Enabled = False
        'Me.txtInfoEstoque.ReadOnly = True
        'Me.txtMargemLucro.ReadOnly = True
        'Me.txtDespesasAdicionais.Text = "0.00"
    End Sub

    Sub HabilitaCampos()
        Me.txtPrecoCusto.ReadOnly = False : Me.txtDescricaoProd.ReadOnly = False
        Me.txtInfoProd.ReadOnly = False : Me.txtPrecoVenda.ReadOnly = False
        Me.txtReferencia.ReadOnly = False : Me.txtProdutoCor.ReadOnly = False
        Me.txtPrecoCusto.ReadOnly = False
        Me.btnSalvar.Enabled = True : Me.btnCancelar.Enabled = True : Me.cboUnidade.Enabled = True
        Me.cboGrupo.Enabled = True : Me.cboMarca.Enabled = True
        'Me.txtInfoEstoque.ReadOnly = False
        'Me.txtMargemLucro.ReadOnly = False
    End Sub

    Private Sub somaPorcentagemProduto()

        _somaPorcentagemDtg = 0
        For Each dp As ClDespesaProduto In MdlConexaoBD.mdlListDespesasProduto
            _somaPorcentagemDtg += CDbl(dp.dpPorcentagem)
        Next
        'txtDespesasAdicionais.Text = _somaPorcentagemDtg.ToString("0.00")
    End Sub

    Private Sub preencheDtgProdutos()

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader


        Try

            sql.Append("SELECT pid, pid, pdescricao, pvenda, punidade, preferencia, pgrupodescricao, pmarcanome FROM produto ")
            sql.Append("WHERE pdescricao LIKE @descricao ORDER BY pdescricao ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            cmd.Parameters.Add("@descricao", Me.txt_pesquisa.Text & "%")
            dr = cmd.ExecuteReader

            dtgProdutos.Rows.Clear()
            If dr.HasRows = False Then Return

            Dim mTelefone As String = ""
            While dr.Read
                dtgProdutos.Rows.Add(dr(0), dr(1), dr(2).ToString, CDbl(dr(3)).ToString("0.00"), dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString)
            End While

            dtgProdutos.Refresh() : dr.Close()
            oConn.ClearPool() : oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos PRODUTOS:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
            Return

        End Try

        txt_qtdRegistros.Text = dtgProdutos.Rows.Count
        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing



    End Sub

    Sub PreencheValoresCampos()
        txtIdProd.Text = produto.pId
        txtDescricaoProd.Text = produto.pDescricao
        txtReferencia.Text = produto.p_Referencia
        txtPrecoCusto.Text = produto.pCusto.ToString("0.00")
        txtPrecoVenda.Text = produto.pVenda.ToString("0.00")
        txtInfoProd.Text = produto.pInformacao
        cboUnidade.SelectedIndex = _funcoes.trazIndexCboTextoTodo(produto.pUnidade, cboUnidade)
        cboGrupo.SelectedIndex = _funcoes.trazIndexCboTextoTodo(produto.p_Grupo, cboGrupo)
        cboMarca.SelectedIndex = _funcoes.trazIndexCboTextoTodo(produto.p_Marca, cboMarca)
        txtProdutoCor.Text = produto.p_Cor
        'txtMargemLucro.Text = produto.pMargemLucro.ToString("0.00")
        'txtDespesasAdicionais.Text = produto.pDespAdicional.ToString("0.00")
        'txtInfoEstoque.Text = produto.pEstoque.ToString("0.00")
    End Sub

    Sub PreencheProdutoValores()

        If IsNumeric(txtIdProd.Text) Then produto.pId = CInt(txtIdProd.Text)
        produto.pCusto = CInt(txtPrecoCusto.Text)
        produto.pDescricao = txtDescricaoProd.Text
        produto.pEstoque = 0 'CDbl(txtInfoEstoque.Text)
        produto.pInformacao = txtInfoProd.Text
        produto.pMargemLucro = 0 'CDbl(txtMargemLucro.Text)
        produto.pVenda = CDbl(txtPrecoVenda.Text)
        If cboUnidade.SelectedIndex > -1 Then produto.pUnidade = cboUnidade.SelectedItem.ToString
        produto.pDespAdicional = 0 'CDbl(txtDespesasAdicionais.Text)
        produto.p_Referencia = txtReferencia.Text
        If cboMarca.SelectedIndex > -1 Then produto.p_Marca = cboMarca.SelectedItem.ToString
        If cboGrupo.SelectedIndex > -1 Then produto.p_Grupo = cboGrupo.SelectedItem.ToString
        produto.p_Cor = txtProdutoCor.Text
    End Sub

    Sub ExecutaF11()

        _listaProdutosPesq.Clear()
        If MdlConexaoBD.sincronizado Then
            produtoDAO.TrazListProdutos_LISTA(_listaProdutosPesq, MdlConexaoBD.ListaProdutos)
        Else
            produtoDAO.TrazListProdutosBD(_listaProdutosPesq, MdlConexaoBD.conectionPadrao)
        End If


        If Trim(txt_pesquisa.Text).Equals("") Then
            produtoDAO.TrazListProdutos_LISTA(_listaProdutosRelatorio, _listaProdutosPesq)
        Else
            _listaProdutosRelatorio = _listaProdutosPesq.FindAll(Function(p As ClProduto) p.pDescricao.StartsWith(Trim(txt_pesquisa.Text)))
        End If

        If _listaProdutosRelatorio.Count > 0 Then

            _listaProdutosRelatorio.Sort(Function(p1, p2) p1.pDescricao.CompareTo(p2.pDescricao))
            Dim frmRelatoriClientes As New FormListaProdutos
            frmRelatoriClientes._ListaProdutos = _listaProdutosRelatorio
            frmRelatoriClientes._FiltroDescricao = txt_pesquisa.Text
            frmRelatoriClientes.ShowDialog()
            frmRelatoriClientes = Nothing
        End If

    End Sub

    Sub ExecutaF5()

        _listaProdutosPesq.Clear()
        _listaProdutosPesq = MdlConexaoBD.ListaProdutos.FindAll(Function(p As ClProduto) p.pDescricao.StartsWith(Me.txt_pesquisa.Text))
        If _listaProdutosPesq.Count < 1 Then Return
        For Each p As ClProduto In _listaProdutosPesq
            dtgProdutos.Rows.Add(p.pId, p.pCodigo, p.pDescricao, p.pVenda.ToString("0.00"), p.pUnidade, p.p_Referencia, p.p_Grupo, p.p_Marca)
        Next
        txt_qtdRegistros.Text = _listaProdutosPesq.Count

        'preencheDtgProdutos()
    End Sub

    Sub ExecutaF2()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        ZeraValoresFormulario()
        HabilitaCampos()
        _unidadeProduto.PreencheCboUnidades_Padrao(cboUnidade, MdlConexaoBD.conectionPadrao)
        _grupoProduto.PreencheCboGrupos_Padrao(cboGrupo, MdlConexaoBD.conectionPadrao)
        _marcaProduto.PreencheCboMarcas_Padrao(cboMarca, MdlConexaoBD.conectionPadrao)
        txtDescricaoProd.Focus()
        tipoOperacao = "I"
    End Sub

    Sub ExecutaF3()

        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If dtgProdutos.CurrentRow.IsNewRow = False Then
            produto.pId = CInt(dtgProdutos.CurrentRow.Cells(0).Value)
            produtoDAO.TrazProduto(produto, MdlConexaoBD.conectionPadrao)
            PreencheValoresCampos()
            HabilitaCampos()
            txtDescricaoProd.Focus()
            tipoOperacao = "A"
        End If

    End Sub

    Sub ExecutaDel()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        tipoOperacao = ""
        If dtgProdutos.CurrentRow.IsNewRow = False Then
            produto.pId = CInt(dtgProdutos.CurrentRow.Cells(0).Value)
            'produtoDAO.delProduto(produto
        End If

        Try

            If dtgProdutos.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse PRODUTO ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    ZeraValoresFormulario() : DesabilitaCampos() : produto.ZeraValores()
                    produto.pId = CInt(dtgProdutos.CurrentRow.Cells(0).Value)


                    Dim transacao As NpgsqlTransaction
                    Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

                    Try

                        Try
                            conection.Open()
                        Catch ex As Exception
                            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
                            Return
                        End Try

                        transacao = conection.BeginTransaction
                        produtoDAO.delProduto(produto, conection, transacao)
                        transacao.Commit() : conection.ClearPool() : conection.Close()
                        MsgBox("PRODUTO Deletado com Sucesso!", MsgBoxStyle.Exclamation)
                        produtoDAO.TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
                        ExecutaF5()
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

            End If
        Catch ex As Exception
        End Try

    End Sub
#End Region


    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        ExecutaF2()
        somaPorcentagemProduto()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        tipoOperacao = ""
        ZeraValoresFormulario()
        DesabilitaCampos()
        txt_pesquisa.Focus()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        ExecutaF9()
    End Sub

    Sub ExecutaF9()

        Try
            produto.pId = Me.txtIdProd.Text
        Catch ex As Exception
            produto.pId = 0
        End Try

        'Dados principais:
        PreencheProdutoValores()

        If tipoOperacao.Equals("I") Then
            If produtoDAO.ValidaProduto(produto) = False Then Return
        Else
            If produtoDAO.ValidaProduto(produto, "A") = False Then Return
        End If



        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If tipoOperacao.Equals("I") Then

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                produtoDAO.incProduto(produto, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                produtoDAO.altProduto(produto, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("PRODUTO Salvo com Sucesso!", MsgBoxStyle.Exclamation)
            dtgProdutos.Rows.Clear()
            produtoDAO.TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
            ExecutaF5()
            ZeraValoresFormulario()
            DesabilitaCampos()
            produto.ZeraValores()
            txt_pesquisa.Focus()
            DesabilitaCampos() : ZeraValoresFormulario()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub
    Private Sub dtg_produtos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgProdutos.CellDoubleClick

        If dtgProdutos.CurrentRow.IsNewRow = False Then
            produto.pId = CInt(dtgProdutos.CurrentRow.Cells(0).Value)
            produtoDAO.TrazProduto(produto, MdlConexaoBD.conectionPadrao)
            PreencheValoresCampos()
        End If
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        ExecutaF3()
    End Sub

    Private Sub txt_pesquisa_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_pesquisa.KeyDown
        If Keys.Enter Then preencheDtgProdutos()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        ExecutaDel()
    End Sub

    Private Sub txtCamposValores_KeyPress(sender As Object, e As KeyPressEventArgs)
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtPrecoCusto_Leave(sender As Object, e As EventArgs)

        Try
            txtPrecoCusto.Text = CDbl(txtPrecoCusto.Text).ToString("0.00")
        Catch ex As Exception
            MsgBox("Valor Custo deve ser numérico")
        End Try
    End Sub

    Private Sub txtPrecoVenda_Leave(sender As Object, e As EventArgs)

        Try
            txtPrecoVenda.Text = CDbl(txtPrecoVenda.Text).ToString("0.00")
        Catch ex As Exception
            MsgBox("Valor Venda deve ser numérico")
        End Try

    End Sub

    Private Sub btnHomeCodBarras_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(0)
    End Sub

    Private Sub btnHomeEstoque_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(0)
    End Sub

    Private Sub btnNextCodBarras_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(2)
    End Sub

    Private Sub btnBackEstoque_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(1)
    End Sub

    Private Sub btnNextEstoque_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(3)
    End Sub

    Private Sub btnBackForn_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(2)
    End Sub

    Private Sub btnNextForn_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(4)
    End Sub

    Private Sub btnBackHistorico_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(3)
    End Sub

    Private Sub btnHomeForn_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(0)
    End Sub

    Private Sub btnHomeHistorico_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(0)
    End Sub

    Private Sub btnNextPrincipal_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(1)
    End Sub

    Private Sub btnNextHistorico_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(5)
    End Sub

    Private Sub btnBackVencimento_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(4)
    End Sub

    Private Sub btnHomeVencimento_Click(sender As Object, e As EventArgs)
        tbcProduto.SelectTab(0)
    End Sub

    Private Sub btnUnidade_Click(sender As Object, e As EventArgs) Handles btnUnidade.Click

        Dim frm As New FrmCadUnidade
        frm.ShowDialog()
        If frm.Modificacao Then

            _unidadeProduto.PreencheCboUnidades_Padrao(cboUnidade, MdlConexaoBD.conectionPadrao)
        End If
        frm = Nothing

    End Sub

    Private Sub btnGrupo_Click(sender As Object, e As EventArgs) Handles btnGrupo.Click

        Dim frm As New FrmCadGrupo
        frm.ShowDialog()
        If frm.Modificacao Then

            _grupoProduto.PreencheCboGrupos_Padrao(cboGrupo, MdlConexaoBD.conectionPadrao)
        End If
        frm = Nothing

    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click

        Dim frm As New FrmCadMarca
        frm.ShowDialog()
        If frm.Modificacao Then

            _marcaProduto.PreencheCboMarcas_Padrao(cboMarca, MdlConexaoBD.conectionPadrao)
        End If
        frm = Nothing

    End Sub

    Private Sub txtPrecoVenda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecoVenda.KeyPress, txtPrecoCusto.KeyPress
        'permite só numeros e virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtPrecoCusto_Leave_1(sender As Object, e As EventArgs) Handles txtPrecoCusto.Leave

        If IsNumeric(txtPrecoCusto.Text) Then
            txtPrecoCusto.Text = CDbl(txtPrecoCusto.Text).ToString("#,##0.00")
        Else
            txtPrecoCusto.Text = "0,00"
        End If
    End Sub

    Private Sub txtPrecoVenda_Leave_1(sender As Object, e As EventArgs) Handles txtPrecoVenda.Leave

        If IsNumeric(txtPrecoVenda.Text) Then
            txtPrecoVenda.Text = CDbl(txtPrecoVenda.Text).ToString("#,##0.00")
        Else
            txtPrecoVenda.Text = "0,00"
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ExecutaF11()
    End Sub

End Class