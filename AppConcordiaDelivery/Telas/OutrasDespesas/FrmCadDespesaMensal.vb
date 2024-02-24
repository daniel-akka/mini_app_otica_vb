Imports Npgsql
Public Class FrmCadDespesaMensal

    Public _DespesaMensal As New ClDespesaMensal
    Public _Modificado As Boolean = False
    Public _Operacao As String = "I"

    Dim _Grupo As New ClGrupoDespMensal
    Dim _SubGrupo As New ClSubGrupoDespMensal
    Dim _GrupoDAO As New ClGrupoDespMensalDAO
    Dim _SubGrupoDAO As New ClSubGrupoDespMensalDAO
    Dim _DespesaMensalDAO As New ClDespesaMensalDAO
    Dim _funcoes As New ClFuncoes

    Private Sub FrmCadDespesaMensal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        validaOperacao()
    End Sub

    Private Sub FrmCadDespesaMensal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub FrmCadDespesaMensal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub validaOperacao()

        Select Case _Operacao
            Case "I"
                zeraCamposFormulario()
                habilitaCamposFormulario()
            Case "A"
                zeraCamposFormulario()
                habilitaCamposFormulario()
                preencheCamposFormularioComDespesaM()
            Case "V"
                zeraCamposFormulario()
                preencheCamposFormularioComDespesaM()
                desabilitaCamposFormulario()

        End Select
    End Sub

    Sub preencheCamposFormularioComDespesaM()
        txtIdGrupo.Text = _DespesaMensal.dm_gpid
        txtDescricaoGrupo.Text = _DespesaMensal.dm_gpdescricao
        txtIdSubGrupo.Text = _DespesaMensal.dm_sgpid
        txtDescricaoSubGrupo.Text = _DespesaMensal.dm_sgpdescricao
        txtValor.Text = _DespesaMensal.dm_valor.ToString("#,##0.00")
        txtObservacao.Text = _DespesaMensal.dm_observacao
        dtpDataPagamento.Value = _DespesaMensal.dm_data_despesa
    End Sub

    Sub zeraCamposFormulario()

        _Grupo.zeraValores()
        _SubGrupo.zeraValores()
        txtIdGrupo.Text = "" : txtDescricaoGrupo.Text = ""
        txtIdSubGrupo.Text = "" : txtDescricaoSubGrupo.Text = ""
        dtpDataPagamento.Value = Date.Now
        txtValor.Text = "0,00"
        txtObservacao.Text = ""

    End Sub

    Sub habilitaCamposFormulario()

        txtIdSubGrupo.Enabled = True
        txtIdGrupo.ReadOnly = False
        txtObservacao.ReadOnly = False
        txtValor.ReadOnly = False
        dtpDataPagamento.Enabled = True
        btnSalvar.Enabled = True
    End Sub

    Sub desabilitaCamposFormulario()

        txtIdGrupo.ReadOnly = True
        txtIdSubGrupo.Enabled = False
        txtObservacao.ReadOnly = True
        txtValor.ReadOnly = True
        dtpDataPagamento.Enabled = False
        btnSalvar.Enabled = False
    End Sub

    Function validaCamposDespesaMensal() As Boolean

        If _SubGrupo.sgp_id <= 0 Then

            MsgBox("Informe um Sub. Grupo para continuar!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            txtIdSubGrupo.Focus() : txtIdSubGrupo.SelectAll()
            Return False
        End If

        If IsNumeric(txtValor.Text) AndAlso CDbl(txtValor.Text) <= 0 Then

            MsgBox("Valor da Despesa deve ser Maior que 0,00!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            txtValor.Focus() : txtValor.SelectAll()
            Return False
        End If

        If dtpDataPagamento.Text < Date.Now.ToShortDateString Then

            If MessageBox.Show("Data do Pagamento está menor que a Data Atual! Deseja Continuar?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) _
                = Windows.Forms.DialogResult.No Then

                dtpDataPagamento.Focus()
                Return False
            End If

        End If

        Return True
    End Function

    Private Sub txtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValor.KeyPress
        'permite só numeros e virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtIdSubGrupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdSubGrupo.KeyPress
        'permite só numeros e virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtValor_Leave(sender As Object, e As EventArgs) Handles txtValor.Leave

        If IsNumeric(txtValor.Text) Then
            txtValor.Text = CDbl(txtValor.Text).ToString("#,##0.00")
        Else
            txtValor.Text = "0,00"
        End If
    End Sub

    Private Sub txtValor_Click(sender As Object, e As EventArgs) Handles txtValor.Click
        txtValor.SelectAll()
    End Sub

    Private Sub txtIdSubGrupo_Leave(sender As Object, e As EventArgs) Handles txtIdSubGrupo.Leave

        If IsNumeric(txtIdSubGrupo.Text) Then

            _SubGrupo.zeraValores()
            _SubGrupo.sgp_id = CInt(txtIdSubGrupo.Text)
            _SubGrupoDAO.TrazSubGrupoDespMensalDaListaPorID(_SubGrupo, MdlConexaoBD.mdlListSubGrupoDespMensal)
            If _SubGrupo.sgp_descricao.Equals("") Then
                'Chama Formulario de pesquisa:
                _SubGrupo.zeraValores()
                Dim formPesSubGrupo As New FrmSubGrupoResp
                formPesSubGrupo.ShowDialog()
                _SubGrupo.setaValores(formPesSubGrupo._SubGrupo)
                preencheCamposPeloSubGrupo()
                formPesSubGrupo = Nothing
            Else
                preencheCamposPeloSubGrupo()
            End If
        Else

            'Chama Formulario de pesquisa:
            _SubGrupo.zeraValores()
            Dim formPesSubGrupo As New FrmSubGrupoResp
            formPesSubGrupo.ShowDialog()
            _SubGrupo.setaValores(formPesSubGrupo._SubGrupo)
            preencheCamposPeloSubGrupo()
            formPesSubGrupo = Nothing
        End If

    End Sub

    Sub preencheCamposPeloSubGrupo()

        txtIdGrupo.Text = _SubGrupo.sgp_gpid
        txtDescricaoGrupo.Text = _SubGrupo.sgp_gpdescricao
        txtIdSubGrupo.Text = _SubGrupo.sgp_id
        txtDescricaoSubGrupo.Text = _SubGrupo.sgp_descricao
        If _SubGrupo.sgp_valorpadrao > 0 Then txtValor.Text = _SubGrupo.sgp_valorpadrao.ToString("#,##0.00")
    End Sub

    Function preenchValoresDespesaMensal() As Boolean

        Try
            _DespesaMensal.dm_empresaid = MdlConexaoBD.mdlEmpresa.empid
            _DespesaMensal.dm_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            _DespesaMensal.dm_sgpid = CInt(txtIdSubGrupo.Text)
            _DespesaMensal.dm_sgpdescricao = txtDescricaoSubGrupo.Text
            _DespesaMensal.dm_gpid = CInt(txtIdGrupo.Text)
            _DespesaMensal.dm_gpdescricao = txtDescricaoGrupo.Text
            _DespesaMensal.dm_valor = CDbl(txtValor.Text)
            _DespesaMensal.dm_observacao = txtObservacao.Text
            _DespesaMensal.dm_data_despesa = dtpDataPagamento.Value

            Select Case _Operacao
                Case "A"
                    _DespesaMensal.dm_alteracao = True
            End Select

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

        Return True
    End Function

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        If validaCamposDespesaMensal() Then

            If preenchValoresDespesaMensal() Then

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
                        _DespesaMensalDAO.incDespesaMensal(_DespesaMensal, connection, transacao)
                        transacao.Commit()

                    Else

                        Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                        _DespesaMensalDAO.altDespesaMensal(_DespesaMensal, connection, transacao)
                        transacao.Commit()

                    End If

                    MsgBox("Despesa Gravada com Sucesso!", MsgBoxStyle.Exclamation)
                    _Modificado = True
                    _DespesaMensalDAO.TrazListDespesaMensalDoBanco(MdlConexaoBD.ListaDespesaMensal, MdlConexaoBD.conectionPadrao)
                    Me.Close()

                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message)
                Finally
                    connection.ClearPool() : connection.Close() : connection = Nothing
                End Try

            End If
        End If

    End Sub

End Class