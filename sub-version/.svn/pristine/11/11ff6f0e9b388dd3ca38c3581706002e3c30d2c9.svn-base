Imports Npgsql
Imports System.Text
Imports System.Data
Imports System.Math
Public Class FrmEntradaSaida
    Dim _produto As New ClProduto
    Dim _produtoDAO As New ClProdutoDAO
    Dim _fornecedor As New ClFornecedor
    Dim _fornecedorDAO As New ClFornecedorDAO
    Dim _clFuncoes As New ClFuncoes
    Dim _es As New ClEntradaSaida
    Dim _esDAO As New ClEntradaSaidaDAO
    Dim _esList As New List(Of ClEntradaSaida)

    Private Sub FrmEntradaSaida_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtProdPesquisa.Focus()
        cboES_Pesq.SelectedIndex = 0
        _produtoDAO.PreencheCboProdutosLista(cboProdutoES, MdlConexaoBD.ListaProdutos)
        _fornecedorDAO.PreencheCboFornecedoresLista(cboFornecedorES, MdlConexaoBD.ListaFornecedores)
        _fornecedorDAO.PreencheCboFornecedoresListaPesq(cboFornecedorPesq, MdlConexaoBD.ListaFornecedores)
        DesativaCampos()
        ExecuteF5()
    End Sub

    Sub AtivaCampos()
        Me.btnAdicionar.Enabled = True
        Me.btnSalvar.Enabled = True
        Me.cboMotivo.SelectedIndex = 0
        Me.cboFornecedorPesq.SelectedIndex = 0
        Me.cboES.SelectedIndex = 0
        _produto.ZeraValores()
        _fornecedor.ZeraValores()
        Me.txtQuantidade.Text = "1"
        Me.cboES_Pesq.SelectedIndex = 0
    End Sub

    Sub DesativaCampos()
        Me.btnAdicionar.Enabled = False
        Me.btnSalvar.Enabled = False
        Me.cboMotivo.SelectedIndex = 0
        Me.cboProdutoES.SelectedIndex = -1
        Me.cboFornecedorES.SelectedIndex = -1
        Me.cboFornecedorPesq.SelectedIndex = 0
        Me.cboES.SelectedIndex = 0
        _produto.ZeraValores()
        _fornecedor.ZeraValores()
        Me.txtQuantidade.Text = "1"
        Me.cboES_Pesq.SelectedIndex = 0
    End Sub

    Private Sub FrmEntradaSaida_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F4
                AtivaCampos()
                TabControlES.SelectTab(1)
                cboProdutoES.Focus()
            Case Keys.F5
                ExecuteF5()
            Case Keys.Delete
                ExecutaDel()
        End Select
    End Sub

    'Got FOCUS ****
    Private Sub cboProdutoES_GotFocus(sender As Object, e As EventArgs) Handles cboProdutoES.GotFocus
        If cboProdutoES.DroppedDown = False Then cboProdutoES.DroppedDown = True
    End Sub
    Private Sub cboFornecedorES_GotFocus(sender As Object, e As EventArgs) Handles cboFornecedorES.GotFocus
        If cboFornecedorES.DroppedDown = False Then cboFornecedorES.DroppedDown = True
    End Sub

    Private Sub cboProdutoES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProdutoES.SelectedIndexChanged
        _produto.ZeraValores()
        If cboProdutoES.SelectedIndex > -1 Then

            Dim mProd As String = cboProdutoES.SelectedItem
            _produto.pId = CInt(Trim(mProd.Substring(mProd.Length - 4)))
            For Each p As ClProduto In MdlConexaoBD.ListaProdutos
                If p.pId.Equals(_produto.pId) Then

                    With _produto
                        .pId = p.pId
                        .pCodigo = p.pCodigo
                        .pDescricao = p.pDescricao
                        .pInformacao = p.pInformacao
                        .pVenda = p.pVenda
                    End With
                    Exit For
                End If

            Next
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Try

            If DtgProdEntradaSaida.RowCount > 0 Then
                DtgProdEntradaSaida.Rows.Clear()
                DtgProdEntradaSaida.Refresh()
            Else
                DesativaCampos()
                TabControlES.SelectTab(0)
                txtProdPesquisa.Focus()
            End If
        Catch ex As Exception
            DesativaCampos()
            TabControlES.SelectTab(0)
            txtProdPesquisa.Focus()
        End Try

    End Sub

    Private Sub cboMotivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMotivo.SelectedIndexChanged

        '****
        If cboMotivo.SelectedIndex = 0 Then
            If cboES.SelectedIndex = 1 Then cboES.SelectedIndex = 0
        End If

        If cboMotivo.SelectedIndex = 1 Then
            If cboES.SelectedIndex = 0 Then cboES.SelectedIndex = 1
        End If

        lblMotiv.Visible = False
        txtMotivo.Text = "" : txtMotivo.Visible = False
        If cboMotivo.SelectedIndex = 2 Then ' Outros
            lblMotiv.Visible = True
            txtMotivo.Text = "" : txtMotivo.Visible = True
        End If

    End Sub

    Private Sub txtQuantidade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantidade.KeyPress
        'permite só numeros com virgula:
        If _clFuncoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtQuantidade_Leave(sender As Object, e As EventArgs) Handles txtQuantidade.Leave

        If IsNumeric(Me.txtQuantidade.Text) Then
            If CInt(Me.txtQuantidade.Text) <= 0 Then
                Me.txtQuantidade.Text = "1"
            End If
            Me.txtQuantidade.Text = CInt(Me.txtQuantidade.Text)
        Else
            Me.txtQuantidade.Text = "1"
        End If


    End Sub

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        AtivaCampos()
        TabControlES.SelectTab(1)
        cboProdutoES.Focus()
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        AdicionaES_DataGrid()
    End Sub

    Function verificaES()
        If cboProdutoES.SelectedIndex < 0 Then
            MsgBox("Obrigatorio informar algum Produto", MsgBoxStyle.Exclamation)
            cboProdutoES.Focus()
            Return False
        End If
        Return True
    End Function

    Sub AdicionaES_DataGrid()

        If verificaES() Then

            With _es

                .estipo = Mid(cboES.SelectedItem.ToString(), 1, 1)
                .esmotivo = cboMotivo.SelectedItem.ToString
                .esobservacao = txtMotivo.Text
                .esprodutoid = _produto.pId
                .esprodutonome = _produto.pDescricao
                .esfornecedorid = _fornecedor.pId
                .esfornecedornome = _fornecedor.pNome
                .esdatamovimentacao = dtpES.Value
                .esquantidade = CInt(txtQuantidade.Text)

            End With

            Me.DtgProdEntradaSaida.Rows.Add(_es.esprodutonome, _es.estipo, _es.esmotivo, _es.esdatamovimentacao, _es.esquantidade, _
                                            _es.esfornecedornome, _es.esprodutoid, _es.esfornecedorid, _es.esobservacao)

            DesativaCampos() : AtivaCampos() : cboProdutoES.Focus()
        End If
    End Sub

    Private Sub cboES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboES.SelectedIndexChanged

        If cboES.SelectedIndex = 0 Then
            If cboMotivo.SelectedIndex = 1 OrElse cboMotivo.SelectedIndex = 2 Then cboMotivo.SelectedIndex = 0
        End If

        If cboES.SelectedIndex = 1 Then
            If cboMotivo.SelectedIndex = 0 OrElse cboMotivo.SelectedIndex = 2 Then cboMotivo.SelectedIndex = 1
        End If

    End Sub

    Private Sub cboFornecedorES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFornecedorES.SelectedIndexChanged

        _fornecedor.ZeraValores()
        If cboFornecedorES.SelectedIndex > -1 Then

            Dim mFornecedor As String = cboFornecedorES.SelectedItem
            _fornecedor.pId = CInt(Trim(mFornecedor.Substring(mFornecedor.Length - 4)))
            For Each f As ClFornecedor In MdlConexaoBD.ListaFornecedores
                If f.pId.Equals(_fornecedor.pId) Then

                    _fornecedor = f
                    Exit For
                End If

            Next
        End If
    End Sub

    Private Sub DtgProdEntradaSaida_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtgProdEntradaSaida.CellContentDoubleClick

        If DtgProdEntradaSaida.CurrentRow.IsNewRow = False Then
            DtgProdEntradaSaida.Rows.RemoveAt(DtgProdEntradaSaida.CurrentRow.Index)
        End If
    End Sub

    Private Sub DtgProdEntradaSaida_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DtgProdEntradaSaida.RowsAdded

        If DtgProdEntradaSaida.Rows(e.RowIndex).Cells(1).Value.ToString.Equals("E") Then
            DtgProdEntradaSaida.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue
        End If

        If DtgProdEntradaSaida.Rows(e.RowIndex).Cells(1).Value.ToString.Equals("S") Then
            DtgProdEntradaSaida.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            connection.Open()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
            connection = Nothing : Return
        End Try

        Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction
            For Each es As DataGridViewRow In DtgProdEntradaSaida.Rows

                If es.IsNewRow = False Then

                    'Seta valores:
                    With _es

                        .estipo = es.Cells(1).Value
                        .esmotivo = es.Cells(2).Value
                        .esobservacao = es.Cells(8).Value
                        .esprodutoid = es.Cells(6).Value
                        .esprodutonome = es.Cells(0).Value
                        .esfornecedorid = es.Cells(7).Value
                        .esfornecedornome = es.Cells(5).Value
                        .esdatamovimentacao = es.Cells(3).Value
                        .esquantidade = CInt(es.Cells(4).Value)

                    End With

                    _esDAO.incEntradaSaida(_es, connection, transacao)
                End If
            Next


            transacao.Commit()

            MsgBox("Movimentações Salvas com Sucesso!", MsgBoxStyle.Exclamation)
            '_esDAO.TrazListEntradaSaida(MdlConexaoBD.mdlListe, MdlConexaoBD.conectionPadrao)
            DtgProdEntradaSaida.Rows.Clear()
            DesativaCampos()
            TabControlES.SelectTab(0)
            txtProdPesquisa.Focus()


        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try
        
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        ExecuteF5()
    End Sub

    Sub ExecuteF5()
        DtgESPrincipal.Rows.Clear()
        preencheDtgES()
        txtRegistros.Text = DtgESPrincipal.Rows.Count
    End Sub

    Private Sub preencheDtgES()

        Dim mQuery As String = ""
        If Not Trim(txtProdPesquisa.Text).Equals("") Then
            mQuery += "esprodutonome LIKE '%" & txtProdPesquisa.Text & "%' "
        End If

        If cboFornecedorPesq.SelectedIndex > 0 Then

            If mQuery.Equals("") Then
                mQuery += "esfornecedornome LIKE '%" & cboFornecedorPesq.SelectedItem.ToString() & "%' "
            Else
                mQuery += "AND esfornecedornome LIKE '%" & cboFornecedorPesq.SelectedItem.ToString() & "%' "
            End If
        End If

        If cboES_Pesq.SelectedIndex > 0 Then

            If mQuery.Equals("") Then
                mQuery += "estipo = '" & Mid(cboES_Pesq.SelectedItem.ToString(), 1, 1) & "' "
            Else
                mQuery += "AND estipo = '" & Mid(cboES_Pesq.SelectedItem.ToString(), 1, 1) & "' "
            End If
        End If

        If mQuery.Equals("") Then
            mQuery += "esdata BETWEEN '" & Msk_inicio.Value.ToShortDateString & "' AND '" & msk_fim.Value.ToShortDateString & "' "
        Else
            mQuery += "AND esdata BETWEEN '" & Msk_inicio.Value & "' AND '" & msk_fim.Value & "' "
        End If


        _esDAO.TrazListEntradaSaidaConsulta(_esList, mQuery, MdlConexaoBD.conectionPadrao)

        For Each es As ClEntradaSaida In _esList

            DtgESPrincipal.Rows.Add(es.esid, es.estipo, es.esprodutonome, es.esdatamovimentacao, es.esquantidade, es.esfornecedornome, es.esmotivo, es.esobservacao)
        Next

    End Sub

    Private Sub DtgESPrincipal_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DtgESPrincipal.RowsAdded

        If DtgESPrincipal.Rows(e.RowIndex).Cells(1).Value.ToString.Equals("E") Then
            DtgESPrincipal.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Blue
        End If

        If DtgESPrincipal.Rows(e.RowIndex).Cells(1).Value.ToString.Equals("S") Then
            DtgESPrincipal.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click

        ExecutaDel()
    End Sub

    Sub ExecutaDel()

        If DtgESPrincipal.CurrentRow.IsNewRow = False Then
            _es.esid = CInt(DtgESPrincipal.CurrentRow.Cells(0).Value)
        End If

        Try

            If MessageBox.Show("Deseja Realmente Essa Movimentação ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


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
                    _esDAO.delEntradaSaida(_es, conection, transacao)
                    transacao.Commit() : conection.ClearPool() : conection.Close()
                    MsgBox("Movimentação Deletada com Sucesso!", MsgBoxStyle.Exclamation)
                    ExecuteF5()
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
        Catch ex As Exception
        End Try

    End Sub
End Class