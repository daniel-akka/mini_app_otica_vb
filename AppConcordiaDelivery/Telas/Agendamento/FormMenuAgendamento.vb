Imports Npgsql
Public Class FormMenuAgendamento

    Dim _ListaAgendamento As New List(Of ClAgendamento)
    Dim _ListaAgendamentoRelatorio As New List(Of ClAgendamento)
    Dim _ListaItensAgendamento As New List(Of ClAgendamentoItens)
    Dim _ListaRelatorio As New List(Of ClRelatorioPadraoSTR)

    Dim _Pessoa As New ClCliente
    Dim _Agendamento As New ClAgendamento
    Dim _AgendamentoCX As New ClAgendamento
    Dim _Atendente As New ClAtendente
    Dim _Servico As New ClServicos
    Dim Relatorio As New ClRelatorioPadraoSTR

    Dim _DaoAgendamento As New ClAgendamentoDAO
    Dim _DaoPessoa As New ClClienteDAO
    Dim _DaoAtendente As New ClAtendenteDAO
    Dim _DaoServico As New ClServicosDAO
    Dim _DaoItemAgendamento As New ClAgendamentoItemDAO

    Public IndexSituacao As Integer = 0


    Private Sub FormMenuAgendamento_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                executaF2()
            Case Keys.F3
                executaF3()
            Case Keys.Delete
                executaDel()
            Case Keys.F5
                executaF5()
            Case Keys.F7
                executaF7()
            Case Keys.F11
                executaF11()
        End Select
    End Sub

    Private Sub FormMenuAgendamento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FormMenuAgendamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboSituacao.SelectedIndex = IndexSituacao
        'DaoAtendente.PreencheCboAtendentesPesquisaBD(cboAtendente, MdlConexaoBD.conectionPadrao)
        _DaoAtendente.PreencheCboAtendentesLista(cboAtendente, MdlConexaoBD.ListaAtendentes)
        cboAtendente.SelectedIndex = 0
        If MdlConexaoBD.sincronizado Then
            cboAtendente.Enabled = False
        End If
        executaF5()
    End Sub

    Sub executaF2()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Dim Formulario As New FormCadAgendamento
        Formulario.ShowDialog()
        If Formulario._Modificado Then
            executaF5()
        End If
        Formulario = Nothing
    End Sub

    Sub executaF3()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If dtgAgendamentos.Rows.Count > 0 Then

            If dtgAgendamentos.CurrentRow.IsNewRow = False Then

                _Agendamento.zeraValores()
                _Agendamento.a_id = dtgAgendamentos.CurrentRow.Cells(0).Value
                _DaoAgendamento.TrazAgendamentoBD(_Agendamento, MdlConexaoBD.conectionPadrao)

                If _Agendamento.a_status Then
                    MsgBox("Agendamento FINALIZADO Não Pode Ser ALTERADO!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    Return
                End If
                Dim Formulario As New FormCadAgendamento
                Formulario._Agendamento.setaValores(_Agendamento)
                Formulario._Operacao = "A"
                Formulario.ShowDialog()
                If Formulario._Modificado Then
                    executaF5()
                End If
                Formulario = Nothing

            Else
                MsgBox("Selecione um Agendamento para poder ALTERAR!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                dtgAgendamentos.Focus()
                Return
            End If
        End If

    End Sub

    Sub executaDel()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If dtgAgendamentos.Rows.Count > 0 Then

            If dtgAgendamentos.CurrentRow.IsNewRow = False Then


                If MessageBox.Show("Deseja Realmente Excluir esse Registro?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    _Agendamento.zeraValores()
                    _Agendamento.a_id = dtgAgendamentos.CurrentRow.Cells(0).Value
                    _DaoAgendamento.TrazAgendamentoBD(_Agendamento, MdlConexaoBD.conectionPadrao)
                    If _Agendamento.a_status Then
                        MsgBox("Agendamento FINALIZADO Não Pode Ser ALTERADO!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                        Return
                    End If

                    Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Try


                        connection.Open()
                        Dim transacao As NpgsqlTransaction = connection.BeginTransaction

                        _DaoAgendamento.delAgendamento(_Agendamento, connection, transacao)

                        transacao.Commit()
                        MsgBox("Agendamento EXCLUIDO com Sucesso!", MsgBoxStyle.Exclamation)
                        executaF5()
                    Catch ex As Exception
                        MsgBox("ERRO:: " & ex.Message)
                    Finally
                        connection.ClearPool() : connection.Close() : connection = Nothing
                    End Try
                End If
                

            Else
                MsgBox("Selecione um Agendamento para poder EXCLUIR!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                dtgAgendamentos.Focus()
                Return
            End If
        End If
    End Sub

    Sub executaF5_sincronizado()

        _ListaAgendamento.Clear()
        Dim mStrTurno As String = ""
        Dim mWhere As String = "WHERE "
        Dim mOrderBy As String = ""
        _ListaAgendamento = _DaoAgendamento.TrazListAgendamentosDaLista(MdlConexaoBD.ListaAgendamentos)

        _ListaAgendamento = _ListaAgendamento.FindAll(Function(a As ClAgendamento) a.a_dtagend.ToShortDateString >= dtpInicio.Text And a.a_dtagend <= dtpFim.Text)

        If rdbManha.Checked Then
            _ListaAgendamento = _ListaAgendamento.FindAll(Function(a As ClAgendamento) a.a_turno = "M")
        End If

        If rdbTarde.Checked Then
            _ListaAgendamento = _ListaAgendamento.FindAll(Function(a As ClAgendamento) a.a_turno = "T")
        End If

        If rdbNoite.Checked Then
            _ListaAgendamento = _ListaAgendamento.FindAll(Function(a As ClAgendamento) a.a_turno = "N")
        End If


        Select Case Mid(cboSituacao.Text, 1, 1)
            Case "N" 'Normal
                _ListaAgendamento = _ListaAgendamento.FindAll(Function(a As ClAgendamento) a.a_status = False)

            Case "F" 'Finalizada
                _ListaAgendamento = _ListaAgendamento.FindAll(Function(a As ClAgendamento) a.a_status = True And a.a_financeiro = False)

            Case "L" 'Lançada
                _ListaAgendamento = _ListaAgendamento.FindAll(Function(a As ClAgendamento) a.a_financeiro = True)

        End Select

        If Not Trim(txtPessoaPesq.Text).Equals("") Then
            _ListaAgendamento = _ListaAgendamento.FindAll(Function(a As ClAgendamento) a.a_pessoanome.StartsWith(txtPessoaPesq.Text))
        End If

        _ListaAgendamento.Sort(Function(a1 As ClAgendamento, a2 As ClAgendamento) a1.a_dtagend = a2.a_dtagend And a1.a_hora = a2.a_hora)


        dtgAgendamentos.Rows.Clear()
        If _ListaAgendamento.Count > 0 Then

            For Each a As ClAgendamento In _ListaAgendamento

                Select Case a.a_turno
                    Case "M"
                        mStrTurno = "MANHÃ"
                    Case "T"
                        mStrTurno = "TARDE"
                    Case "N"
                        mStrTurno = "NOITE"
                End Select

                _Pessoa.cid = a.a_pessoaid
                _DaoPessoa.TrazClienteDaListaClientes(_Pessoa, MdlConexaoBD.ListaClientes)

                dtgAgendamentos.Rows.Add(a.a_id, a.a_pessoanome, _Pessoa.ctelefone, a.a_dtemis.ToShortDateString, a.a_dtagend.ToShortDateString, mStrTurno, a.a_hora, a.a_valor.ToString("#,##0.00"), a.a_status, a.a_alterado, a.a_financeiro)
            Next
            _Pessoa.ZeraValores()
        End If

        txtTotRegistros.Text = _ListaAgendamento.Count

    End Sub

    Sub executaF5_BD()

        Dim mStrTurno As String = ""
        Dim mWhere As String = "WHERE "
        Dim mOrderBy As String = ""

        If rdbManha.Checked Then
            mWhere += "a_turno = 'M' AND a_dtagend BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "
        End If

        If rdbTarde.Checked Then

            mWhere += "a_turno = 'T' AND a_dtagend BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "
        End If

        If rdbNoite.Checked Then

            mWhere += "a_turno = 'N' AND a_dtagend BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "
        End If

        If rdbDia.Checked Then

            mWhere += "a_dtagend BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "
        End If


        Select Case Mid(cboSituacao.Text, 1, 1)
            Case "N" 'Normal

                mWhere += "AND a_status = false "

            Case "F" 'Finalizada

                mWhere += "AND a_status = true AND a_financeiro = false "

            Case "L" 'Lançada
                mWhere += "AND a_financeiro = true "

        End Select

        If cboAtendente.SelectedIndex > 0 Then
            mWhere += "AND agi_atendenteid = " & _Atendente.aId & " "
        End If

        mWhere += "AND a_pessoanome LIKE '" & txtPessoaPesq.Text & "%' "
        mOrderBy = "ORDER BY a_dtagend, a_hora ASC "

        _ListaAgendamento.Clear()
        _DaoAgendamento.TrazListAgendamentosBD(_ListaAgendamento, MdlConexaoBD.conectionPadrao, mWhere, mOrderBy, _Atendente)

        dtgAgendamentos.Rows.Clear()
        If _ListaAgendamento.Count > 0 Then

            For Each a As ClAgendamento In _ListaAgendamento

                Select Case a.a_turno
                    Case "M"
                        mStrTurno = "MANHÃ"
                    Case "T"
                        mStrTurno = "TARDE"
                    Case "N"
                        mStrTurno = "NOITE"
                End Select

                _Pessoa.cid = a.a_pessoaid
                _DaoPessoa.TrazClienteDaListaClientes(_Pessoa, MdlConexaoBD.ListaClientes)

                dtgAgendamentos.Rows.Add(a.a_id, a.a_pessoanome, _Pessoa.ctelefone, a.a_dtemis.ToShortDateString, a.a_dtagend.ToShortDateString, mStrTurno, a.a_hora, a.a_valor.ToString("#,##0.00"), a.a_status, a.a_alterado, a.a_financeiro)
            Next
            _Pessoa.ZeraValores()
        End If


        txtTotRegistros.Text = dtgAgendamentos.Rows.Count

    End Sub

    Sub executaF5()

        If MdlConexaoBD.sincronizado Then
            executaF5_sincronizado()
        Else
            executaF5_BD()
        End If

    End Sub

    Sub executaF7()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If dtgAgendamentos.Rows.Count > 0 Then

            If dtgAgendamentos.CurrentRow.IsNewRow = False Then


                _Agendamento.zeraValores()
                _Agendamento.a_id = dtgAgendamentos.CurrentRow.Cells(0).Value
                _DaoAgendamento.TrazAgendamentoBD(_Agendamento, MdlConexaoBD.conectionPadrao)
                If _Agendamento.a_status Then
                    MsgBox("Agendamento ja foi FINALIZADO!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    Return
                End If

                Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Try


                    connection.Open()
                    Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                    _Agendamento.a_status = True
                    _DaoAgendamento.altAgendamento(_Agendamento, connection, transacao)

                    transacao.Commit()
                    MsgBox("Agendamento FINALIZADO com Sucesso!", MsgBoxStyle.Exclamation)
                    executaF5()
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message)
                Finally
                    connection.ClearPool() : connection.Close() : connection = Nothing
                End Try

            Else
                MsgBox("Selecione um Agendamento para poder FINALIZAR!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                dtgAgendamentos.Focus()
                Return
            End If
        End If
    End Sub

    Sub executaF11_BD()

        Dim mStrTurno As String = ""
        Dim mWhere As String = "WHERE "
        Dim mOrderBy As String = ""
        Dim FiltroData As String = ""
        Dim FiltroPessoa As String = ""
        Dim FiltroSituacao As String = ""
        Dim FiltroAtendente As String = ""
        Dim FiltroTurno As String = ""
        Dim mSomaQtde As Double = 0
        Dim mSomaValores As Double = 0

        FiltroData = dtpInicio.Text & " A " & dtpFim.Text
        If rdbManha.Checked Then
            mWhere += "a_turno = 'M' AND a_dtagend BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "
            FiltroTurno = "MANHÃ"
        End If

        If rdbTarde.Checked Then

            mWhere += "a_turno = 'T' AND a_dtagend BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "
            FiltroTurno = "TARDE"
        End If

        If rdbNoite.Checked Then

            mWhere += "a_turno = 'N' AND a_dtagend BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "
            FiltroTurno = "NOITE"
        End If

        If rdbDia.Checked Then

            mWhere += "a_dtagend BETWEEN '" & dtpInicio.Text & "' AND '" & dtpFim.Text & "' "
            FiltroTurno = "O DIA TODO"
        End If


        Select Case Mid(cboSituacao.Text, 1, 1)
            Case "N" 'Normal

                mWhere += "AND a_status = false "
                FiltroSituacao = "NORMAL"

            Case "F" 'Finalizada

                mWhere += "AND a_status = true AND a_financeiro = false "
                FiltroSituacao = "FINALIZADA"

            Case "L" 'Lançada
                mWhere += "AND a_financeiro = true "
                FiltroSituacao = "LANÇADA NO CAIXA"

        End Select

        If cboAtendente.SelectedIndex > 0 Then
            mWhere += "AND agi_atendenteid = " & _Atendente.aId & " "
            FiltroAtendente = _Atendente.aNome
        End If

        mWhere += "AND a_pessoanome LIKE '" & txtPessoaPesq.Text & "%' "
        FiltroPessoa = txtPessoaPesq.Text
        mOrderBy = "ORDER BY a_dtagend, a_hora ASC "

        _ListaAgendamentoRelatorio.Clear()
        _DaoAgendamento.TrazListAgendamentosBD(_ListaAgendamentoRelatorio, MdlConexaoBD.conectionPadrao, mWhere, mOrderBy, _Atendente)

        If _ListaAgendamentoRelatorio.Count > 0 Then

            _ListaRelatorio.Clear()
            For Each a As ClAgendamento In _ListaAgendamentoRelatorio

                Relatorio.zeraValores()
                With Relatorio

                    .coluna1 = a.a_id.ToString.PadLeft(7, "0")
                    .coluna2 = a.a_pessoanome
                    Select Case a.a_turno
                        Case "M"
                            .coluna3 = "MANHÃ"
                        Case "T"
                            .coluna3 = "TARDE"
                        Case "N"
                            .coluna3 = "NOITE"
                    End Select

                    .coluna4 = a.a_hora
                    .coluna5 = ""
                    If _Atendente.aId <= 0 Then
                        If a.a_valor > 0 Then
                            .coluna5 = a.a_valor.ToString("#,##0.00")
                        End If
                    End If

                End With
                _ListaRelatorio.Add(New ClRelatorioPadraoSTR(Relatorio))


                If _Atendente.aId > 0 Then
                    _DaoItemAgendamento.TrazListItensAgendamentoBD(a, _ListaItensAgendamento, MdlConexaoBD.conectionPadrao, "AND agi_atendenteid = " & _Atendente.aId)
                Else
                    _DaoItemAgendamento.TrazListItensAgendamentoBD(a, _ListaItensAgendamento, MdlConexaoBD.conectionPadrao)
                End If

                If _ListaItensAgendamento.Count > 0 Then
                    mSomaQtde += _ListaItensAgendamento.Count
                Else
                    mSomaQtde += 1
                End If

                For Each i As ClAgendamentoItens In _ListaItensAgendamento

                    Relatorio.zeraValores()
                    With Relatorio

                        .coluna1 = ""
                        .coluna2 = i.agi_descrserv
                        .coluna3 = i.agi_atendentenome
                        .coluna4 = ""
                        .coluna5 = ""
                        If a.a_valor > 0 Then
                            .coluna5 = i.agi_valor.ToString("#,##0.00")
                        End If
                        mSomaValores += i.agi_valor
                    End With
                    _ListaRelatorio.Add(New ClRelatorioPadraoSTR(Relatorio))
                Next
            Next

            Dim Formulario As New FormListaAgendamentos
            Formulario._ListaRelatorio = _ListaRelatorio
            Formulario._FiltroAtendente = FiltroAtendente
            Formulario._FiltroData = FiltroData
            Formulario._FiltroSituacao = FiltroSituacao
            Formulario._FiltroPessoa = FiltroPessoa
            Formulario._FiltroTurno = FiltroTurno
            Formulario.somaQtde = mSomaQtde
            Formulario.somaValores = mSomaValores
            Formulario.ShowDialog()
            Formulario = Nothing

        End If

    End Sub

    Sub executaF11_Sincronizado()

        Dim mStrTurno As String = ""
        Dim mWhere As String = "WHERE "
        Dim mOrderBy As String = ""
        Dim FiltroData As String = ""
        Dim FiltroPessoa As String = ""
        Dim FiltroSituacao As String = ""
        Dim FiltroAtendente As String = ""
        Dim FiltroTurno As String = ""
        Dim mSomaQtde As Double = 0
        Dim mSomaValores As Double = 0

        FiltroData = dtpInicio.Text & " A " & dtpFim.Text

        _ListaAgendamentoRelatorio.Clear()
        _ListaAgendamentoRelatorio = _DaoAgendamento.TrazListAgendamentosDaLista(MdlConexaoBD.ListaAgendamentos)

        _ListaAgendamentoRelatorio = _ListaAgendamentoRelatorio.FindAll(Function(a As ClAgendamento) a.a_dtagend.ToShortDateString >= dtpInicio.Text And a.a_dtagend <= dtpFim.Text)

        If rdbManha.Checked Then
            _ListaAgendamentoRelatorio = _ListaAgendamentoRelatorio.FindAll(Function(a As ClAgendamento) a.a_turno = "M")
        End If

        If rdbTarde.Checked Then
            _ListaAgendamentoRelatorio = _ListaAgendamentoRelatorio.FindAll(Function(a As ClAgendamento) a.a_turno = "T")
        End If

        If rdbNoite.Checked Then
            _ListaAgendamentoRelatorio = _ListaAgendamentoRelatorio.FindAll(Function(a As ClAgendamento) a.a_turno = "N")
        End If


        Select Case Mid(cboSituacao.Text, 1, 1)
            Case "N" 'Normal
                _ListaAgendamentoRelatorio = _ListaAgendamentoRelatorio.FindAll(Function(a As ClAgendamento) a.a_status = False)

            Case "F" 'Finalizada
                _ListaAgendamentoRelatorio = _ListaAgendamentoRelatorio.FindAll(Function(a As ClAgendamento) a.a_status = True And a.a_financeiro = False)

            Case "L" 'Lançada
                _ListaAgendamentoRelatorio = _ListaAgendamentoRelatorio.FindAll(Function(a As ClAgendamento) a.a_financeiro = True)

        End Select

        If Not Trim(txtPessoaPesq.Text).Equals("") Then
            _ListaAgendamentoRelatorio = _ListaAgendamentoRelatorio.FindAll(Function(a As ClAgendamento) a.a_pessoanome.StartsWith(txtPessoaPesq.Text))
        End If

        _ListaAgendamentoRelatorio.Sort(Function(a1 As ClAgendamento, a2 As ClAgendamento) a1.a_dtagend = a2.a_dtagend And a1.a_hora = a2.a_hora)


        If _ListaAgendamentoRelatorio.Count > 0 Then

            _ListaRelatorio.Clear()
            For Each a As ClAgendamento In _ListaAgendamentoRelatorio

                Relatorio.zeraValores()
                With Relatorio

                    .coluna1 = a.a_id.ToString.PadLeft(7, "0")
                    .coluna2 = a.a_pessoanome
                    Select Case a.a_turno
                        Case "M"
                            .coluna3 = "MANHÃ"
                        Case "T"
                            .coluna3 = "TARDE"
                        Case "N"
                            .coluna3 = "NOITE"
                    End Select

                    .coluna4 = a.a_hora
                    .coluna5 = ""
                    If _Atendente.aId <= 0 Then
                        If a.a_valor > 0 Then
                            .coluna5 = a.a_valor.ToString("#,##0.00")
                        End If
                    End If

                End With
                _ListaRelatorio.Add(New ClRelatorioPadraoSTR(Relatorio))


                If MdlConexaoBD.sincronizado Then
                    '


                Else
                    If _Atendente.aId > 0 Then
                        _DaoItemAgendamento.TrazListItensAgendamentoBD(a, _ListaItensAgendamento, MdlConexaoBD.conectionPadrao, "AND agi_atendenteid = " & _Atendente.aId)
                    Else
                        _DaoItemAgendamento.TrazListItensAgendamentoBD(a, _ListaItensAgendamento, MdlConexaoBD.conectionPadrao)
                    End If

                End If


                If _ListaItensAgendamento.Count > 0 Then
                    mSomaQtde += _ListaItensAgendamento.Count
                Else
                    mSomaQtde += 1
                End If

                For Each i As ClAgendamentoItens In _ListaItensAgendamento

                    Relatorio.zeraValores()
                    With Relatorio

                        .coluna1 = ""
                        .coluna2 = i.agi_descrserv
                        .coluna3 = i.agi_atendentenome
                        .coluna4 = ""
                        .coluna5 = ""
                        If a.a_valor > 0 Then
                            .coluna5 = i.agi_valor.ToString("#,##0.00")
                        End If
                        mSomaValores += i.agi_valor
                    End With
                    _ListaRelatorio.Add(New ClRelatorioPadraoSTR(Relatorio))
                Next
            Next

            Dim Formulario As New FormListaAgendamentos
            Formulario._ListaRelatorio = _ListaRelatorio
            Formulario._FiltroAtendente = FiltroAtendente
            Formulario._FiltroData = FiltroData
            Formulario._FiltroSituacao = FiltroSituacao
            Formulario._FiltroPessoa = FiltroPessoa
            Formulario._FiltroTurno = FiltroTurno
            Formulario.somaQtde = mSomaQtde
            Formulario.somaValores = mSomaValores
            Formulario.ShowDialog()
            Formulario = Nothing

        End If


    End Sub

    Sub executaF11()

        If MdlConexaoBD.sincronizado Then
            executaF11_Sincronizado()
        Else
            executaF11_BD()
        End If


    End Sub

    Sub executaVISUALIZAR()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If dtgAgendamentos.Rows.Count > 0 Then

            If dtgAgendamentos.CurrentRow.IsNewRow = False Then

                _Agendamento.zeraValores()
                _Agendamento.a_id = dtgAgendamentos.CurrentRow.Cells(0).Value
                _DaoAgendamento.TrazAgendamentoBD(_Agendamento, MdlConexaoBD.conectionPadrao)
                Dim Formulario As New FormCadAgendamento
                Formulario._Agendamento.setaValores(_Agendamento)
                Formulario._Operacao = "V"
                Formulario.ShowDialog()
                Formulario = Nothing

            Else
                MsgBox("Selecione um Agendamento para poder VISUALIZAR!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                dtgAgendamentos.Focus()
                Return
            End If
        End If

    End Sub

    Sub lancaCaixa()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If dtgAgendamentos.Rows.Count > 0 Then

            If dtgAgendamentos.CurrentRow.IsNewRow = False Then


                _AgendamentoCX.zeraValores()
                _AgendamentoCX.a_id = dtgAgendamentos.CurrentRow.Cells(0).Value
                _DaoAgendamento.TrazAgendamentoBD(_AgendamentoCX, MdlConexaoBD.conectionPadrao)
                If _AgendamentoCX.a_status = False Then
                    MsgBox("Agendamento NÃO foi FINALIZADO! Finalize Primeiro Para Pode Continuar!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    Return
                End If

                If _AgendamentoCX.a_financeiro Then
                    MsgBox("Agendamento já foi lançado no CAIXA! Não Será Possível Lançar 2x", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                    Return
                End If

                If _AgendamentoCX.a_id > 0 Then

                    Dim mAbrirFecharCxDAO As New ClAbrirFecharDAO
                    If mAbrirFecharCxDAO.VerificaCaixaAberto(MdlConexaoBD.conectionPadrao) = False Then
                        MsgBox("Abra um CAIXA primeiro para prosseguir!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                        Return
                    End If

                    Dim Formulario As New FrmServicos
                    Formulario._Agendamento.setaValores(_AgendamentoCX)
                    Formulario.ShowDialog()
                    If Formulario._Modificado Then
                        executaF5()
                    End If
                    Formulario = Nothing
                End If

            Else
                MsgBox("Selecione um Agendamento para Lançar no CAIXA!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                dtgAgendamentos.Focus()
                Return
            End If
        End If

    End Sub

    Private Sub dtgAgendamentos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgAgendamentos.RowsAdded

        If dtgAgendamentos.Rows(e.RowIndex).IsNewRow = False Then

            If dtgAgendamentos.Rows(e.RowIndex).Cells(8).Value AndAlso dtgAgendamentos.Rows(e.RowIndex).Cells(10).Value = False Then

                dtgAgendamentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumBlue
            End If

            If dtgAgendamentos.Rows(e.RowIndex).Cells(9).Value AndAlso dtgAgendamentos.Rows(e.RowIndex).Cells(8).Value = False Then
                dtgAgendamentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkRed
            End If

            If dtgAgendamentos.Rows(e.RowIndex).Cells(10).Value Then
                dtgAgendamentos.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Green
            End If
        End If
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        executaF7()
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        executaDel()
    End Sub

    Private Sub btnVizualizar_Click(sender As Object, e As EventArgs) Handles btnVizualizar.Click
        executaVISUALIZAR()
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        executaF3()
    End Sub

    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        executaF2()
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        executaF5()
    End Sub

    Private Sub cboAtendente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAtendente.SelectedIndexChanged

        _Atendente.ZeraValores()
        If cboAtendente.SelectedIndex > -1 Then
            _Atendente.aNome = cboAtendente.SelectedItem.ToString
            _DaoAtendente.TrazAtendenteNomeDaLista(_Atendente)
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

    Private Sub btnLancarVenda_Click(sender As Object, e As EventArgs) Handles btnLancarVenda.Click
        lancaCaixa()
    End Sub

End Class