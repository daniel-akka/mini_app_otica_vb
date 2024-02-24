Imports Npgsql
Public Class FrmCadSubGrupoDespMensal

    Dim _Grupo As New ClGrupoDespMensal
    Dim _GrupoPesq As New ClGrupoDespMensal
    Dim _GrupoDAO As New ClGrupoDespMensalDAO
    Dim _ListaGrupo As New List(Of ClGrupoDespMensal)

    Dim _SubGrupo As New ClSubGrupoDespMensal
    Dim _SubGrupoPesq As New ClSubGrupoDespMensal
    Dim _SubGrupoDAO As New ClSubGrupoDespMensalDAO
    Dim _ListaSubGrupo As New List(Of ClSubGrupoDespMensal)
    Dim _ListaSubGrupoAux As New List(Of ClSubGrupoDespMensal)

    Dim _ListaSubGrupoAuxImpress As New List(Of ClSubGrupoDespMensal)
    Dim _ListaSubGrupoImpressao As New List(Of ClSubGrupoDespMensal)
    Dim _ListaSubGrupoImpressaoRelatorio As New List(Of ClSubGrupoDespMensalImpr)

    Dim _FitroGrupo As String = ""
    Dim _FitroDescricao As String = ""
    Dim _Operacao As String = "I"
    Dim _Funcoes As New ClFuncoes
    Dim _ModificadoCadGrupo As Boolean = False

    Private Sub FrmCadSubGrupoDespMensal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _ModificadoCadGrupo = True
        PreenchCboGrupos()
        executaF5()
    End Sub

    Sub executaF5()

        _ListaSubGrupo.Clear()
        _ListaSubGrupoAux.Clear()
        If _GrupoPesq.gp_id > 0 Then

            _SubGrupoDAO.TrazListaSubGrupoDespMensalDaListaPorGrupoID(_GrupoPesq, _ListaSubGrupoAux, MdlConexaoBD.mdlListSubGrupoDespMensal)
        Else
            _SubGrupoDAO.TrazListaSubGrupoDespMensalDaLista(_ListaSubGrupoAux, MdlConexaoBD.mdlListSubGrupoDespMensal)
        End If

        If Not Trim(txtDescrSubGrupoPesquisa.Text).Equals("") Then
            _ListaSubGrupo = _ListaSubGrupoAux.FindAll(Function(sb As ClSubGrupoDespMensal) sb.sgp_descricao.Contains(Trim(txtDescrSubGrupoPesquisa.Text)))
        Else
            _ListaSubGrupo = _ListaSubGrupoAux
        End If

        dtgSubGrupo.Rows.Clear()
        For Each sb As ClSubGrupoDespMensal In _ListaSubGrupo
            dtgSubGrupo.Rows.Add(sb.sgp_id, sb.sgp_gpid, sb.sgp_gpdescricao, sb.sgp_descricao, sb.sgp_valorpadrao.ToString("#,##0.00"))
        Next
    End Sub

    Sub executaF2()

        _Operacao = "I"
        zeraCamposSubGrupo()
        cboGrupo.DroppedDown = True : cboGrupo.Focus()
        btnSalvar.Enabled = True
    End Sub

    Sub executaF3()

        zeraCamposSubGrupo()
        If setaSubGrupoDataGrid() = False Then Return
        _Operacao = "A"
        preenchCamposSubGrupo()
        btnSalvar.Enabled = True
    End Sub

    Sub executaDel()

        If setaSubGrupoDataGrid() = False Then

            MsgBox("Selecione Um registro para excluir!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        Else

            If MessageBox.Show("Deseja Realmente Excluir esse Registro?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) _
                = Windows.Forms.DialogResult.Yes Then

                'Codigo pra exlcusão!:
                Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                Try


                    Try
                        connection.Open()
                    Catch ex As Exception
                        MsgBox("ERRO:: " & ex.Message)
                        connection = Nothing : Return
                    End Try

                    Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                    _SubGrupoDAO.delSubGrupoDespMensal(_SubGrupo, connection, transacao)
                    transacao.Commit()

                    MsgBox("SUB GRUPO EXCLUIDO com Sucesso!", MsgBoxStyle.Exclamation)

                    _SubGrupoDAO.TrazListaSubGrupoDespMensalDoBANCO(MdlConexaoBD.mdlListSubGrupoDespMensal, MdlConexaoBD.conectionPadrao)
                    zeraCamposSubGrupo()
                    executaF5()
                    _Operacao = "I"
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message)
                Finally
                    connection.ClearPool() : connection.Close() : connection = Nothing
                End Try


            End If
        End If

    End Sub

    Sub executaF11()

        _ListaSubGrupoAuxImpress.Clear()
        _ListaSubGrupoImpressao.Clear()
        _ListaSubGrupoImpressaoRelatorio.Clear()
        _FitroGrupo = cboGrupoDespPesquisa.SelectedItem.ToString
        _FitroDescricao = Trim(txtDescrSubGrupoPesquisa.Text)
        If _GrupoPesq.gp_id > 0 Then

            _SubGrupoDAO.TrazListaSubGrupoDespMensalDaListaPorGrupoID(_GrupoPesq, _ListaSubGrupoAuxImpress, MdlConexaoBD.mdlListSubGrupoDespMensal)
        Else
            _SubGrupoDAO.TrazListaSubGrupoDespMensalDaLista(_ListaSubGrupoAuxImpress, MdlConexaoBD.mdlListSubGrupoDespMensal)
        End If

        _ListaSubGrupoImpressao = _ListaSubGrupoAuxImpress.FindAll(Function(sb As ClSubGrupoDespMensal) sb.sgp_descricao.Contains(Trim(txtDescrSubGrupoPesquisa.Text)))

        _SubGrupoDAO.PreencheListaImpressao(_ListaSubGrupoImpressaoRelatorio, _GrupoPesq, _ListaSubGrupoImpressao)

        If _ListaSubGrupoImpressao.Count > 0 Then

            Dim mformRelatorio As New FormListaSubGrupo
            mformRelatorio._FiltroGrupo = _FitroGrupo
            mformRelatorio._FiltroDescricao = _FitroDescricao
            mformRelatorio._ListaSubGrupos = _ListaSubGrupoImpressaoRelatorio
            mformRelatorio.ShowDialog()
            mformRelatorio = Nothing
        End If
        

    End Sub

    Sub salvaSubGrupo()

        If verificaSubGrupo() Then

            preenchValoresSubGrupo()
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
                    _SubGrupoDAO.incSubGrupoDespMensal(_SubGrupo, connection, transacao)
                    transacao.Commit()

                Else

                    Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                    _SubGrupoDAO.altSubGrupoDespMensal(_SubGrupo, connection, transacao)
                    transacao.Commit()

                End If

                MsgBox("SUB GRUPO Gravado com Sucesso!", MsgBoxStyle.Exclamation)

                _SubGrupoDAO.TrazListaSubGrupoDespMensalDoBANCO(MdlConexaoBD.mdlListSubGrupoDespMensal, MdlConexaoBD.conectionPadrao)
                zeraCamposSubGrupo()
                executaF5()
                _Operacao = "I"
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
            Finally
                connection.ClearPool() : connection.Close() : connection = Nothing
            End Try

        End If

    End Sub

    Private Sub FrmCadSubGrupoDespMensal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmCadSubGrupoDespMensal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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
            Case Keys.F11
                executaF11()
        End Select

    End Sub

    Sub zeraCamposSubGrupo()

        txtIdGrupo.Text = ""
        cboGrupo.SelectedIndex = -1
        txtIdSubGrupo.Text = ""
        txtDescrSubGrupo.Text = ""
        _SubGrupo.zeraValores()
        _Grupo.zeraValores()
    End Sub

    Sub preenchCamposSubGrupo()

        If _SubGrupo.sgp_id > 0 Then

            txtIdGrupo.Text = _SubGrupo.sgp_gpid
            cboGrupo.SelectedIndex = _Funcoes.trazIndexCboTextoTodo(_SubGrupo.sgp_gpdescricao, cboGrupo)
            txtIdSubGrupo.Text = _SubGrupo.sgp_id
            txtDescrSubGrupo.Text = _SubGrupo.sgp_descricao
            txtValorPadrao.Text = _SubGrupo.sgp_valorpadrao.ToString("#,##0.00")
        End If
    End Sub

    Sub preenchValoresSubGrupo()


        _SubGrupo.sgp_gpid = _Grupo.gp_id
        _SubGrupo.sgp_gpdescricao = _Grupo.gp_descricao
        _SubGrupo.sgp_id = 0
        If IsNumeric(txtIdSubGrupo.Text) Then _SubGrupo.sgp_id = CInt(txtIdSubGrupo.Text)
        _SubGrupo.sgp_descricao = Trim(txtDescrSubGrupo.Text)
        _SubGrupo.sgp_valorpadrao = CDbl(txtValorPadrao.Text)
    End Sub

    Function setaSubGrupoDataGrid() As Boolean


        Try
            _SubGrupo.zeraValores()
            If dtgSubGrupo.CurrentRow.IsNewRow = False Then

                _SubGrupo.sgp_id = Me.dtgSubGrupo.CurrentRow.Cells(0).Value
                If _SubGrupo.sgp_id <= 0 Then Return False
                _SubGrupoDAO.TrazSubGrupoDespMensalDaListaPorID(_SubGrupo, MdlConexaoBD.mdlListSubGrupoDespMensal)
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Function verificaSubGrupo() As Boolean

        Try

            If _Grupo.gp_id <= 0 Then

                MsgBox("Selecione um Grupo por favor!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                cboGrupo.DroppedDown = True : cboGrupo.Focus()
                Return False
            End If

            If Trim(txtDescrSubGrupo.Text).Equals("") Then

                MsgBox("Informe uma Descrição para o SubGrupo!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                txtDescrSubGrupo.Focus()
                Return False
            End If

            preenchValoresSubGrupo()
            If _SubGrupoDAO.ValidaSubGrupoDespMensal(_SubGrupo, _Operacao) = False Then
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        salvaSubGrupo()

    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrupo.SelectedIndexChanged

        Try
            _Grupo.zeraValores()
            If cboGrupo.SelectedIndex >= 0 Then
                _Grupo.gp_descricao = cboGrupo.SelectedItem.ToString
                _GrupoDAO.TrazGrupoDespMensalDaListaPorNOME(_Grupo, MdlConexaoBD.ListaGrupoDespMensal)
                txtIdGrupo.Text = _Grupo.gp_id
                txtDescrSubGrupo.Focus()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnAddGrupo_Click(sender As Object, e As EventArgs) Handles btnAddGrupo.Click

        _ModificadoCadGrupo = False
        Dim mFormGrupo As New FrmCadGrupoDespMensal
        mFormGrupo.ShowDialog()
        If mFormGrupo._Modificacao Then _ModificadoCadGrupo = True : PreenchCboGrupos()
        mFormGrupo = Nothing
    End Sub

    Sub PreenchCboGrupos()

        If _ModificadoCadGrupo Then

            _GrupoDAO.PreencheCboGrupoLista(cboGrupo, MdlConexaoBD.ListaGrupoDespMensal)
            _GrupoDAO.PreencheCboGrupoListaPesq(cboGrupoDespPesquisa, MdlConexaoBD.ListaGrupoDespMensal)
            cboGrupo.SelectedIndex = -1
            cboGrupoDespPesquisa.SelectedIndex = 0
        End If

    End Sub

    Private Sub cboGrupoDespPesquisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrupoDespPesquisa.SelectedIndexChanged

        Try
            _GrupoPesq.zeraValores()
            If cboGrupoDespPesquisa.SelectedIndex >= 0 Then
                _GrupoPesq.gp_descricao = cboGrupoDespPesquisa.SelectedItem.ToString
                _GrupoDAO.TrazGrupoDespMensalDaListaPorNOME(_GrupoPesq, MdlConexaoBD.ListaGrupoDespMensal)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click

        executaF5()
    End Sub

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        executaF2()
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        executaF3()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        executaDel()
    End Sub

    Private Sub txtValorPadrao_Leave(sender As Object, e As EventArgs) Handles txtValorPadrao.Leave

        If IsNumeric(txtValorPadrao.Text) Then

            txtValorPadrao.Text = CDbl(txtValorPadrao.Text).ToString("#,##0.00")
            If CDbl(txtValorPadrao.Text) < 0 Then txtValorPadrao.Text = "0,00"
        Else
            txtValorPadrao.Text = "0,00"
        End If
    End Sub

    Private Sub txtValorPadrao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorPadrao.KeyPress
        'permite só numeros e virgula:
        If _Funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtValorPadrao_Click(sender As Object, e As EventArgs) Handles txtValorPadrao.Click
        txtValorPadrao.SelectAll()
    End Sub

    Private Sub txtDescrSubGrupo_Click(sender As Object, e As EventArgs) Handles txtDescrSubGrupo.Click
        txtDescrSubGrupo.SelectAll()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub
End Class