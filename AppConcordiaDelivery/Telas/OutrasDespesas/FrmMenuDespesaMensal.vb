Imports Npgsql
Public Class FrmMenuDespesaMensal

    Dim _GrupoPesq As New ClGrupoDespMensal
    Dim _GrupoDAO As New ClGrupoDespMensalDAO
    Dim _ListaGrupo As New List(Of ClGrupoDespMensal)

    'Dim _SubGrupoPesq As New ClSubGrupoDespMensal
    'Dim _SubGrupoDAO As New ClSubGrupoDespMensalDAO
    'Dim _ListaSubGrupo As New List(Of ClSubGrupoDespMensal)
    'Dim _ListaSubGrupoAux As New List(Of ClSubGrupoDespMensal)

    Dim _DespesaMensal As New ClDespesaMensal
    Dim _DespesaMensalPesq As New ClDespesaMensal
    Dim _DespesaMensalDAO As New ClDespesaMensalDAO
    Dim _ListaDespesaMensal As New List(Of ClDespesaMensal)
    Dim _ListaDespesaMensalAux As New List(Of ClDespesaMensal)

    'Para Impressão:
    Dim _ListaSubGrupoAuxImpress As New List(Of ClSubGrupoDespMensal)
    Dim _ListaSubGrupoImpressao As New List(Of ClSubGrupoDespMensal)
    Dim _ListaDespesaMensalImpressao As New List(Of ClDespesaMensal)
    Dim _ListaDespesaMensalImpressaoAux As New List(Of ClDespesaMensal)
    Dim _ListaDespMensalRelatorio As New List(Of ClDespesaMensalmpressao)

    Dim _FiltroGrupo As String = ""
    Dim _FiltroDescricao As String = ""
    Dim _FiltroDtInicial As String = ""
    Dim _FiltroDtFinal As String = ""
    Dim _FiltroObservacao As String = ""
    Dim _Operacao As String = "I"
    Dim _Funcoes As New ClFuncoes
    Dim _ModificadoCadDespesa As Boolean = False

    Private Sub FrmMenuDespesaMensal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmMenuDespesaMensal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                executaF2()
            Case Keys.F3
                executaF3()
            Case Keys.F5
                executaF5()
            Case Keys.F9
                executaF9()
            Case Keys.F11
                executaF11()
            Case Keys.Delete
                executaDel()
        End Select
    End Sub

    Private Sub FrmMenuDespesaMensal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PreenchCboGrupos()
        executaF5()
    End Sub

    Sub PreenchCboGrupos()

        Try
            _GrupoDAO.PreencheCboGrupoListaPesq(cboGrupoDespPesquisa, MdlConexaoBD.ListaGrupoDespMensal)
            cboGrupoDespPesquisa.SelectedIndex = 0
        Catch ex As Exception
            'MsgBox("ERRO:: " & ex.Message)
        End Try

    End Sub

    Sub executaF2()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        _ModificadoCadDespesa = False
        Dim frmCadDespesaM As New FrmCadDespesaMensal
        frmCadDespesaM._Operacao = "I"
        frmCadDespesaM.ShowDialog()
        _ModificadoCadDespesa = frmCadDespesaM._Modificado
        If _ModificadoCadDespesa Then executaF5()
        frmCadDespesaM = Nothing

    End Sub

    Sub executaF3()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Try

            If Me.dtgDespesaMensal.CurrentRow.IsNewRow = False Then

                _DespesaMensal.dm_id = Me.dtgDespesaMensal.CurrentRow.Cells(0).Value
                _DespesaMensalDAO.TrazDespesaMensalDaListaPorID(_DespesaMensal, MdlConexaoBD.ListaDespesaMensal)

                If _DespesaMensal.dm_fechado Then

                    If MessageBox.Show("O Período dessa movimentação ja foi fechado! Deseja Continuar?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) _
                        = Windows.Forms.DialogResult.Yes Then

                        _ModificadoCadDespesa = False
                        Dim frmCadDespesaM As New FrmCadDespesaMensal
                        frmCadDespesaM._Operacao = "A"
                        frmCadDespesaM._DespesaMensal.setaValores(_DespesaMensal)
                        frmCadDespesaM.ShowDialog()
                        _ModificadoCadDespesa = frmCadDespesaM._Modificado
                        If _ModificadoCadDespesa Then executaF5()
                        frmCadDespesaM = Nothing

                    End If

                Else

                    _ModificadoCadDespesa = False
                    Dim frmCadDespesaM As New FrmCadDespesaMensal
                    frmCadDespesaM._Operacao = "A"
                    frmCadDespesaM._DespesaMensal.setaValores(_DespesaMensal)
                    frmCadDespesaM.ShowDialog()
                    _ModificadoCadDespesa = frmCadDespesaM._Modificado
                    If _ModificadoCadDespesa Then executaF5()
                    frmCadDespesaM = Nothing
                End If


            Else
                MsgBox("Selecione uma Despesa para poder ALTERAR!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub executaF5()

        _ListaDespesaMensalAux.Clear()
        _ListaDespesaMensal.Clear()
        _ListaDespesaMensalAux = MdlConexaoBD.ListaDespesaMensal
        If _GrupoPesq.gp_id > 0 Then 'filtro do Grupo:
            _ListaDespesaMensalAux = MdlConexaoBD.ListaDespesaMensal.FindAll(Function(dm As ClDespesaMensal) dm.dm_gpid = _GrupoPesq.gp_id)
        End If

        'Filtro das Datas:
        If rdb_emiss.Checked Then
            _ListaDespesaMensalAux = _ListaDespesaMensalAux.FindAll(Function(dm As ClDespesaMensal) _
                                            dm.dm_data_inclusao.ToShortDateString >= dtpInicio.Text And _
                                            dm.dm_data_inclusao.ToShortDateString <= dtpFim.Text)
        End If

        If rdb_pagamento.Checked Then
            _ListaDespesaMensalAux = _ListaDespesaMensalAux.FindAll(Function(dm As ClDespesaMensal) _
                                            dm.dm_data_despesa.ToShortDateString >= dtpInicio.Text And _
                                            dm.dm_data_despesa.ToShortDateString <= dtpFim.Text)
        End If

        'Filtro da Descrição do SubGrupo:
        If Not Trim(txtDescrSubGrupoPesquisa.Text).Equals("") Then

            _ListaDespesaMensalAux = _ListaDespesaMensalAux.FindAll(Function(dm As ClDespesaMensal) dm.dm_sgpdescricao.Contains(Trim(txtDescrSubGrupoPesquisa.Text)))
        End If

        'Filtro da Observação:
        If Not Trim(txtObservacaoPesq.Text).Equals("") Then

            _ListaDespesaMensalAux = _ListaDespesaMensalAux.FindAll(Function(dm As ClDespesaMensal) dm.dm_observacao.Contains(Trim(txtObservacaoPesq.Text)))
        End If


        _ListaDespesaMensal = _ListaDespesaMensalAux

        dtgDespesaMensal.Rows.Clear()
        For Each dsp As ClDespesaMensal In _ListaDespesaMensal
            dtgDespesaMensal.Rows.Add(dsp.dm_id, dsp.dm_gpid, dsp.dm_gpdescricao, dsp.dm_sgpid, dsp.dm_sgpdescricao, dsp.dm_data_inclusao.ToShortDateString & " " & dsp.dm_data_inclusao.ToShortTimeString, _
                                      dsp.dm_data_despesa.ToShortDateString, dsp.dm_valor.ToString("#,##0.00"), dsp.dm_observacao, dsp.dm_fechado, dsp.dm_alteracao)
        Next

        lbl_registros.Text = Me.dtgDespesaMensal.RowCount
        txt_totais.Text = SomaValoresDespesaGRID.ToString("#,##0.00")
    End Sub

    Function SomaValoresDespesaGRID() As Double
        Dim mSoma As Double = 0

        For Each dt As DataGridViewRow In Me.dtgDespesaMensal.Rows

            If dt.IsNewRow = False Then

                mSoma += dt.Cells(7).Value
            End If

        Next

        Return mSoma
    End Function

    Sub executaF11()

        _FiltroGrupo = cboGrupoDespPesquisa.SelectedItem.ToString
        _FiltroDescricao = txtDescrSubGrupoPesquisa.Text
        _FiltroObservacao = txtObservacaoPesq.Text
        _FiltroDtInicial = ""
        _FiltroDtFinal = ""

        If rdb_emiss.Checked OrElse rdb_pagamento.Checked Then
            _FiltroDtInicial = dtpInicio.Text
            _FiltroDtFinal = dtpFim.Text
        End If

        _ListaDespesaMensalImpressao.Clear()
        _ListaDespesaMensalImpressaoAux.Clear()
        _ListaDespesaMensalImpressaoAux = MdlConexaoBD.ListaDespesaMensal
        _ListaDespMensalRelatorio.Clear()
        If _GrupoPesq.gp_id > 0 Then 'filtro do Grupo:
            _ListaDespesaMensalImpressaoAux = MdlConexaoBD.ListaDespesaMensal.FindAll(Function(dm As ClDespesaMensal) dm.dm_gpid = _GrupoPesq.gp_id)
        End If

        'Filtro das Datas:
        If rdb_emiss.Checked Then
            _ListaDespesaMensalImpressaoAux = _ListaDespesaMensalImpressaoAux.FindAll(Function(dm As ClDespesaMensal) _
                                            dm.dm_data_inclusao.ToShortDateString >= dtpInicio.Text And _
                                            dm.dm_data_inclusao.ToShortDateString <= dtpFim.Text)
        End If

        If rdb_pagamento.Checked Then
            _ListaDespesaMensalImpressaoAux = _ListaDespesaMensalImpressaoAux.FindAll(Function(dm As ClDespesaMensal) _
                                            dm.dm_data_despesa.ToShortDateString >= dtpInicio.Text And _
                                            dm.dm_data_despesa.ToShortDateString <= dtpFim.Text)
        End If

        'Filtro da Descrição do SubGrupo:
        If Not Trim(txtDescrSubGrupoPesquisa.Text).Equals("") Then

            _ListaDespesaMensalImpressaoAux = _ListaDespesaMensalImpressaoAux.FindAll(Function(dm As ClDespesaMensal) dm.dm_sgpdescricao.Contains(Trim(txtDescrSubGrupoPesquisa.Text)))
        End If

        'Filtro da Observação:
        If Not Trim(txtObservacaoPesq.Text).Equals("") Then

            _ListaDespesaMensalImpressaoAux = _ListaDespesaMensalImpressaoAux.FindAll(Function(dm As ClDespesaMensal) dm.dm_observacao.Contains(Trim(txtObservacaoPesq.Text)))
        End If


        _ListaDespesaMensalImpressao = _ListaDespesaMensalImpressaoAux
        _DespesaMensalDAO.PreencheListaImpressao(_ListaDespMensalRelatorio, _GrupoPesq, _ListaDespesaMensalImpressao)

        If _ListaDespMensalRelatorio.Count > 0 Then

            Dim mformRelatorio As New FormListaDespesasMensal
            mformRelatorio._FiltroGrupo = _FiltroGrupo
            mformRelatorio._FiltroDescricaoSubGrupo = _FiltroDescricao
            mformRelatorio._FiltroObservacao = _FiltroObservacao
            mformRelatorio._FiltroDtInicial = _FiltroDtInicial
            mformRelatorio._FiltroDtFinal = _FiltroDtFinal
            mformRelatorio._ListaDespMensal = _ListaDespMensalRelatorio
            mformRelatorio.ShowDialog()
            mformRelatorio = Nothing
        End If


    End Sub

    Sub executaF9()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Try

            If Me.dtgDespesaMensal.CurrentRow.IsNewRow = False Then

                _DespesaMensal.dm_id = Me.dtgDespesaMensal.CurrentRow.Cells(0).Value
                _DespesaMensalDAO.TrazDespesaMensalDaListaPorID(_DespesaMensal, MdlConexaoBD.ListaDespesaMensal)
                _ModificadoCadDespesa = False
                Dim frmCadDespesaM As New FrmCadDespesaMensal
                frmCadDespesaM._Operacao = "V"
                frmCadDespesaM._DespesaMensal.setaValores(_DespesaMensal)
                frmCadDespesaM.ShowDialog()
                _ModificadoCadDespesa = frmCadDespesaM._Modificado
                If _ModificadoCadDespesa Then executaF5()
                frmCadDespesaM = Nothing

            Else
                MsgBox("Selecione uma Despesa para poder Visualizar!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            End If
        Catch ex As Exception
        End Try


    End Sub

    Sub ExcluindoDespesa()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
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
            _DespesaMensalDAO.delDespesaMensal(_DespesaMensal, connection, transacao)
            transacao.Commit()

            MsgBox("Despesa EXCLUIDA com Sucesso!", MsgBoxStyle.Exclamation)
            _ModificadoCadDespesa = True
            _DespesaMensalDAO.TrazListDespesaMensalDoBanco(MdlConexaoBD.ListaDespesaMensal, MdlConexaoBD.conectionPadrao)
            executaF5()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub executaDel()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Try

            If Me.dtgDespesaMensal.CurrentRow.IsNewRow = False Then

                _DespesaMensal.dm_id = Me.dtgDespesaMensal.CurrentRow.Cells(0).Value
                _DespesaMensalDAO.TrazDespesaMensalDaListaPorID(_DespesaMensal, MdlConexaoBD.ListaDespesaMensal)
                If _DespesaMensal.dm_fechado Then

                    If MessageBox.Show("O Período do Movimento deste Lançamento já foi Fechado! Deseja Continuar?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) _
                        = Windows.Forms.DialogResult.Yes Then

                        If MessageBox.Show("Deseja Realmente Excluir essa Despesa?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) _
                        = Windows.Forms.DialogResult.Yes Then
                            ExcluindoDespesa()
                        End If
                    End If

                Else

                    If MessageBox.Show("Deseja Realmente Excluir essa Despesa?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) _
                        = Windows.Forms.DialogResult.Yes Then
                        ExcluindoDespesa()
                    End If
                End If

            Else
                MsgBox("Selecione uma Despesa para poder Excluir!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click
        executaF2()
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        executaF3()
    End Sub

    Private Sub btnVizualizar_Click(sender As Object, e As EventArgs) Handles btnVizualizar.Click
        executaF9()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        executaDel()
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        executaF5()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

    Private Sub cboGrupoDespPesquisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrupoDespPesquisa.SelectedIndexChanged

        Try
            _GrupoPesq.zeraValores()
            If cboGrupoDespPesquisa.SelectedIndex >= 0 Then
                _GrupoPesq.gp_descricao = cboGrupoDespPesquisa.SelectedItem.ToString
                _GrupoDAO.TrazGrupoDespMensalDaListaPorNOME(_GrupoPesq, MdlConexaoBD.ListaGrupoDespMensal)
                executaF5()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dtgDespesaMensal_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgDespesaMensal.RowsAdded

        If Me.dtgDespesaMensal.Rows(e.RowIndex).Cells(10).Value Then
            Me.dtgDespesaMensal.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkRed
        End If

        If Me.dtgDespesaMensal.Rows(e.RowIndex).Cells(9).Value Then
            Me.dtgDespesaMensal.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumBlue
        End If
    End Sub

End Class