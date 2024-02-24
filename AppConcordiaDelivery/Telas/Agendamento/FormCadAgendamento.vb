Imports Npgsql
Public Class FormCadAgendamento

    Public _Agendamento As New ClAgendamento
    Public _Operacao As String = "I"
    Public _Modificado As Boolean = False

    Dim _DaoAgendamento As New ClAgendamentoDAO
    Dim _DaoItemAgendamento As New ClAgendamentoItemDAO
    Dim _DaoCliente As New ClClienteDAO
    Dim _DaoAtendente As New ClAtendenteDAO
    Dim _DaoServico As New ClServicosDAO
    Dim _DaoEmpresa As New ClEmpresaDAO

    Dim _ItemAgendamento As New ClAgendamentoItens
    Dim _Cliente As New ClCliente
    Dim _Atendente As New ClAtendente
    Dim _Servico As New ClServicos
    Dim _Funcoes As New ClFuncoes

    Dim _ListaItensAgendamento As New List(Of ClAgendamentoItens)

    Private Sub FormCadAgendamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtOperador.Text = MdlConexaoBD.mdlUsuarioLogado.u_nome
        _DaoEmpresa.PreencheCboEmpresasBDLimit_RazaoS(cboEmpresa, MdlConexaoBD.conectionPadrao, "", "LIMIT 1")
        If cboEmpresa.Items.Count > 0 Then cboEmpresa.SelectedIndex = 0
        _DaoServico.PreencheCboServicosBD(cboSevico, MdlConexaoBD.conectionPadrao)
        _DaoAtendente.PreencheCboAtendentesBD(cboAtendente, MdlConexaoBD.conectionPadrao)
        preencheCamposFormulario()

    End Sub

    Private Sub FormCadAgendamento_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2

                If btnAdicionar.Enabled Then
                    executaF2()
                End If

            Case Keys.F7
                If btnFinalizar.Enabled Then
                    executaF7()
                End If

            Case Keys.Delete

                If btn_excluir.Enabled Then
                    executaDel()
                End If

        End Select

    End Sub

    Private Sub FormCadAgendamento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub executaF2()

        adicionaItemAgendDataGrid()

    End Sub

    Sub zeraTodosCamposFormulario()
        dtpDataAgend.Value = Date.Now
        txtIdCliente.Text = ""
        txtNomeCliente.Text = ""
        cboInfomacao.Text = ""
        mskHora.Text = ""
        txtValorTotalAgend.Text = "0,00"
        ZeraCamposServico()
        _Agendamento.zeraValores()
        _ListaItensAgendamento.Clear()
        _ItemAgendamento.zeraValores()
        dtgServicos.Rows.Clear()
        _Cliente.ZeraValores()
    End Sub

    Sub executaDel()

        If dtgServicos.Rows.Count < 1 Then Return
        If dtgServicos.CurrentRow.IsNewRow = False Then
            dtgServicos.Rows.RemoveAt(dtgServicos.CurrentRow.Index)
        End If

    End Sub

    Sub executaF7()

        If validaAgendamento() Then

            preenchValoresAgendamento()
            salvandoAgendamento()

        End If

    End Sub

    Sub salvandoAgendamento()

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If _Operacao.Equals("I") Then
                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _DaoAgendamento.incAgendamento(_Agendamento, connection, transacao)
                _Agendamento.a_id = _DaoAgendamento.TrazUltimoID(connection, transacao)
                If _ListaItensAgendamento.Count > 0 Then

                    For Each i As ClAgendamentoItens In _ListaItensAgendamento
                        _DaoItemAgendamento.incItemAgendamento(_Agendamento, i, connection, transacao)
                    Next
                End If
                transacao.Commit()
                MsgBox("Agendamento Gravado com Sucesso!", MsgBoxStyle.Exclamation)
                _Modificado = True

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _DaoAgendamento.altAgendamento(_Agendamento, connection, transacao)
                _DaoItemAgendamento.delAgendamentoITEM(_Agendamento, connection, transacao)
                If _ListaItensAgendamento.Count > 0 Then

                    For Each i As ClAgendamentoItens In _ListaItensAgendamento
                        _DaoItemAgendamento.incItemAgendamento(_Agendamento, i, connection, transacao)
                    Next
                End If
                transacao.Commit()
                MsgBox("Agendamento Alterado com Sucesso!", MsgBoxStyle.Exclamation)
                _Modificado = True
                Me.Close()
            End If

            _DaoAgendamento.TrazListAgendamentosBD(MdlConexaoBD.ListaAgendamentos, MdlConexaoBD.conectionPadrao)

            If _Operacao = "I" Then

                If _Modificado Then

                    If MessageBox.Show("Deseja Continuar Incluindo?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                        zeraTodosCamposFormulario()
                        txtIdCliente.Focus()
                    Else
                        Me.Close()
                    End If
                End If

            End If


        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub preencheCamposFormulario()

        Select Case _Operacao
            Case "A"

                With _Agendamento

                    txtIDAgendamento.Text = .a_id.ToString.PadLeft(7, "0")
                    dtpDataAgend.Value = .a_dtagend
                    txtValorTotalAgend.Text = .a_valor.ToString("#,##0.00")
                    txtIdCliente.Text = .a_pessoaid
                    txtNomeCliente.Text = .a_pessoanome
                    cboInfomacao.Text = .a_info
                    mskHora.Text = .a_hora

                    Select Case .a_turno
                        Case "M"
                            rdbManha.Checked = True
                        Case "T"
                            rdbTarde.Checked = True
                        Case "N"
                            rdbNoite.Checked = True
                    End Select
                End With


                _DaoItemAgendamento.TrazListItensAgendamentoBD(_Agendamento, _ListaItensAgendamento, MdlConexaoBD.conectionPadrao)
                dtgServicos.Rows.Clear()
                If _ListaItensAgendamento.Count > 0 Then

                    For Each i As ClAgendamentoItens In _ListaItensAgendamento

                        dtgServicos.Rows.Add(i.agi_codserv, i.agi_descrserv, i.agi_qtde.ToString("#,##0.00"), i.agi_valor.ToString("#,##0.00"), i.agi_total.ToString("#,##0.00"), i.agi_atendentenome, i.agi_atendenteid)
                    Next
                End If

                btnFinalizar.Enabled = True
            Case "V"

                With _Agendamento

                    txtIDAgendamento.Text = .a_id.ToString.PadLeft(7, "0")
                    dtpDataAgend.Value = .a_dtagend
                    txtValorTotalAgend.Text = .a_valor.ToString("#,##0.00")
                    txtIdCliente.Text = .a_pessoaid
                    txtNomeCliente.Text = .a_pessoanome
                    cboInfomacao.Text = .a_info
                    mskHora.Text = .a_hora

                    Select Case .a_turno
                        Case "M"
                            rdbManha.Checked = True
                        Case "T"
                            rdbTarde.Checked = True
                        Case "N"
                            rdbNoite.Checked = True
                    End Select
                End With


                _DaoItemAgendamento.TrazListItensAgendamentoBD(_Agendamento, _ListaItensAgendamento, MdlConexaoBD.conectionPadrao)
                dtgServicos.Rows.Clear()
                If _ListaItensAgendamento.Count > 0 Then

                    For Each i As ClAgendamentoItens In _ListaItensAgendamento

                        dtgServicos.Rows.Add(i.agi_codserv, i.agi_descrserv, i.agi_qtde.ToString("#,##0.00"), i.agi_valor.ToString("#,##0.00"), i.agi_total.ToString("#,##0.00"), i.agi_atendentenome, i.agi_atendenteid)
                    Next
                End If

                btnFinalizar.Enabled = False
                btnAdicionar.Enabled = False
                btn_excluir.Enabled = False
                txtIdCliente.ReadOnly = True
                txtNomeCliente.Focus()

            Case Else
                btnFinalizar.Enabled = True
        End Select

    End Sub

    Sub preenchValoresAgendamento()

        'Preenchendo valores do Agendamento;
        With _Agendamento

            If IsNumeric(txtIDAgendamento.Text) Then
                .a_id = CInt(txtIDAgendamento.Text)
            End If
            .a_dtemis = Date.Now
            .a_dtagend = dtpDataAgend.Value
            .a_pessoaid = txtIdCliente.Text
            .a_pessoanome = txtNomeCliente.Text
            .a_empresaid = MdlConexaoBD.mdlEmpresa.empid
            .a_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            .a_info = cboInfomacao.Text
            .a_hora = ""
            If _mskHora.Text.Replace(":", "").ToString.Equals("") = False Then
                .a_hora = mskHora.Text
            End If
            .a_valor = CDbl(txtValorTotalAgend.Text)
            If rdbManha.Checked Then .a_turno = "M"
            If rdbTarde.Checked Then .a_turno = "T"
            If rdbNoite.Checked Then .a_turno = "N"

        End With


        'Preenchendo os Seviços prestados:
        _ListaItensAgendamento.Clear()
        If dtgServicos.RowCount > 0 Then

            For Each r As DataGridViewRow In dtgServicos.Rows

                If r.IsNewRow = False Then

                    _ItemAgendamento.zeraValores()
                    With _ItemAgendamento
                        .AG_ID = _Agendamento.a_id
                        .agi_codserv = r.Cells(0).Value
                        .agi_descrserv = r.Cells(1).Value
                        .agi_qtde = r.Cells(2).Value
                        .agi_valor = r.Cells(3).Value
                        .agi_total = r.Cells(4).Value
                        .agi_atendentenome = r.Cells(5).Value
                        .agi_atendenteid = r.Cells(6).Value
                        .agi_dtemis = Date.Now
                    End With
                    _ListaItensAgendamento.Add(New ClAgendamentoItens(_ItemAgendamento))
                End If

            Next
        End If


    End Sub

    Function validaAgendamento() As Boolean

        If _Cliente.cid < 1 Then

            MsgBox("Informe uma Pessoa para o Atendimento!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            txtIdCliente.Focus()
            Return False
        End If

        If dtpDataAgend.Text < Date.Now.ToShortDateString Then

            If MessageBox.Show("A Data do Agendamento não pode ser Menor que a Data do Dia! Deseja Continuar assim mesmo?!", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) _
                = Windows.Forms.DialogResult.No Then

                dtpDataAgend.Focus()
                Return False
            End If
        End If

        If _Funcoes.validaHoraMask(mskHora.Text) = False Then

            MsgBox("Hora inválida! Informe um Hora Correta!", MsgBoxStyle.Information, Application.CompanyName.ToUpper)
            mskHora.Focus()
            mskHora.SelectAll()
            Return False
        End If

        Dim mTurno As String = ""
        If rdbManha.Checked Then mTurno = "M"
        If rdbTarde.Checked Then mTurno = "T"
        If rdbNoite.Checked Then mTurno = "N"

        If _Funcoes.validaHoraMaskTurno(mskHora.Text, mTurno) = False Then

            MsgBox("Hora incorreta de acordo com o turno! Confira a Hora por favor!", MsgBoxStyle.Information, Application.CompanyName.ToUpper)
            mskHora.Focus()
            mskHora.SelectAll()
            Return False
        End If


        Return True
    End Function

    Sub adicionaItemAgendDataGrid()

        If VerificaExisteServicoGrid(_Servico) Then
            MsgBox("Serviço """ & _Servico.sdescricao & """ Já adicionado! Excluir o Serviço Existente e Adicione um Novo!")
            Return
        End If

        If cboSevico.SelectedIndex < 0 Then
            MsgBox("Selecione um Serviço por favor!", MsgBoxStyle.Exclamation, Application.CompanyName)
            cboSevico.Focus() : cboSevico.DroppedDown = True
            Return
        End If

        If cboAtendente.SelectedIndex < 0 Then
            MsgBox("Selecione um Atendente por favor!", MsgBoxStyle.Exclamation, Application.CompanyName)
            cboAtendente.Focus() : cboAtendente.DroppedDown = True
            Return
        End If


        If CDbl(txtTotServico.Text) > 0 Then
            dtgServicos.Rows.Add(_Servico.sid, _Servico.sdescricao, txtQtdeServico.Text, txtVlrServico.Text, txtTotServico.Text, _
                                 _Atendente.aNome, _Atendente.aId, _Atendente.aComissao, _Servico.sdespcartaoporcentagem, _Servico.sdespcartaodinheiro)

            ZeraCamposServico()
        Else
            MsgBox("Total do Serviço deve ser maior que ZERO")
        End If

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
            _DaoCliente.TrazClienteDaListaClientes(_Cliente, MdlConexaoBD.ListaClientes)

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
        Else
            txtIdCliente.Text = _Cliente.cid
            txtNomeCliente.Text = _Cliente.cnome
            txtNomeCliente.ReadOnly = True
            txtNomeCliente.BackColor = Color.LightYellow
            txtNomeCliente.Focus()
        End If

    End Sub

    Private Sub txtIdCliente_Leave(sender As Object, e As EventArgs) Handles txtIdCliente.Leave

        If IsNumeric(txtIdCliente.Text) Then

            Dim mCliente As New ClCliente
            mCliente.cid = CInt(txtIdCliente.Text)
            _DaoCliente.TrazClienteDaListaClientes(mCliente, MdlConexaoBD.ListaClientes)
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

    Private Sub cboSevico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSevico.SelectedIndexChanged

        _Servico.ZeraValores()
        txtVlrServico.Text = "0,00"
        If cboSevico.SelectedIndex > -1 Then 'Foi selecionado algum serviço:

            _Servico.sdescricao = cboSevico.SelectedItem
            If _DaoServico.TrazServicoNomeDaLista(_Servico) = False Then
                MsgBox("Selecione um Serviço!") : cboSevico.Focus() : cboSevico.DroppedDown = True
                Return
            End If

            cboAtendente.SelectedIndex = -1
            If _Servico.sidatendente > 0 Then cboAtendente.SelectedIndex = _Funcoes.trazIndexCboTextoTodo(_Servico.snomeatendente, cboAtendente)
            txtVlrServico.Text = _Servico.svalor.ToString("#,##0.00")
            CalculaValorQtdeServiço()
            txtQtdeServico.Focus()
        End If

    End Sub

    Sub CalculaValorQtdeServiço()

        If CDbl(txtQtdeServico.Text) > 0 AndAlso CDbl(txtVlrServico.Text) > 0 Then
            txtTotServico.Text = ((CDbl(txtQtdeServico.Text) * CDbl(txtVlrServico.Text))).ToString("#,##0.00")
        End If
    End Sub

    Sub calculaValorTotalAgendamento()

        Dim mSoma As Double = 0

        For Each rw As DataGridViewRow In dtgServicos.Rows

            If rw.IsNewRow = False Then
                mSoma += rw.Cells(4).Value
            End If
        Next

        txtValorTotalAgend.Text = mSoma.ToString("#,##0.00")
    End Sub

    Private Sub txtVlrServico_Leave(sender As Object, e As EventArgs) Handles txtVlrServico.Leave

        If IsNumeric(txtVlrServico.Text) Then
            If cboSevico.SelectedIndex < 0 Then Return
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

    Private Sub dtgServicos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgServicos.RowsAdded
        calculaValorTotalAgendamento()
    End Sub

    Private Sub dtgServicos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtgServicos.RowsRemoved
        calculaValorTotalAgendamento()
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click

        executaF2()

    End Sub

    Function VerificaExisteServicoGrid(ByVal serv As ClServicos) As Boolean

        For Each s As DataGridViewRow In dtgServicos.Rows

            If Not s.IsNewRow Then

                If CInt(s.Cells(0).Value) = serv.sid Then Return True
            End If
        Next

        Return False
    End Function

    Sub ZeraCamposServico()
        cboSevico.SelectedIndex = -1
        cboAtendente.SelectedIndex = -1
        txtQtdeServico.Text = 1
        txtVlrServico.Text = "0,00"
        txtTotServico.Text = "0,00"
        _Servico.ZeraValores()
        _Atendente.ZeraValores()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click

        executaDel()

    End Sub

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

    Private Sub txtQtdeServico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtdeServico.KeyPress
        'permite só numeros:
        If _Funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtVlrServico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVlrServico.KeyPress
        'permite só numeros virgula:
        If _Funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub cboAtendente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAtendente.SelectedIndexChanged

        _Atendente.ZeraValores()
        If cboAtendente.SelectedIndex > -1 Then
            _Atendente.aNome = cboAtendente.SelectedItem.ToString
            _DaoAtendente.TrazAtendenteNomeDaLista(_Atendente)
        End If

    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click

        executaF7()

    End Sub

    Private Sub mskHora_Click(sender As Object, e As EventArgs) Handles mskHora.Click
        mskHora.SelectAll()
    End Sub

    Private Sub btnInfoSaudePessoa_Click(sender As Object, e As EventArgs) Handles btnInfoSaudePessoa.Click
        ExecutaSaudePessoa()
    End Sub

    Sub ExecutaSaudePessoa()

        If _Cliente.cid <= 0 Then
            MsgBox("Selecione um Cliente para Prosseguir!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Dim Formulario As New FormInfoSaudePessoa
        Formulario._Cliente.SetaValores(_Cliente)
        Formulario.ShowDialog()
    End Sub

End Class