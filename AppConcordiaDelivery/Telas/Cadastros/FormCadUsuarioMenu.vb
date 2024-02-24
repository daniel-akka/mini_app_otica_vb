Imports System
Imports System.Text
Imports Npgsql

Public Class FormCadUsuarioMenu

    Private _clFuncoes As New ClFuncoes
    Dim _EmpresaDAO As New ClEmpresaDAO
    Private _Usuario As New ClUsuario
    Private _UsuarioDAO As New ClUsuarioDAO
    Dim _TelasUsuario As New ClUsuarioTelas
    'Dim _TelasUsuarioDAO As New ClUsuarioTelas
    Private Const _valorZERO As Integer = 0
    Public Shared _frmRef As New FormCadUsuarioMenu
    Dim mSenhaCrypo, mResultado2 As String
    Public _alterando As Boolean = False, _incluindo As Boolean = False
    Dim _acessos As Integer = 0

    'ultilizados para o DataGridView
    Private _oConnBD As NpgsqlConnection = New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
    Private _cmdUsuario As New NpgsqlCommand
    Private _sqlUsuario As New StringBuilder
    Private _drUsuario As NpgsqlDataReader
    Private _idUsuario As Int32 = _valorZERO
    Private _senhaUsuario As String = ""

    Sub executaF5()

        preencheDtg_Usuario(Me.txt_pesquisa.Text)

    End Sub

    Sub executaF2()

        If (_incluindo = True) OrElse (_alterando = True) Then

            If MessageBox.Show("Operação em aberto! Ela será Substituída!", Application.CompanyName.ToUpper, _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _incluindo = True : _alterando = False : tbc_usuario.SelectTab(1) : limpaCamposFormUsuario()
                Me.txt_nome.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
                _Usuario.zeraValores()
                configTelaNormal()

            End If

        Else
            _Usuario.zeraValores()
            _incluindo = True : _alterando = False : tbc_usuario.SelectTab(1) : limpaCamposFormUsuario()
            Me.txt_nome.Focus() : tbp_manutencao.Text = "Incluindo" : btn_salvar.Enabled = True
            configTelaNormal()

        End If

    End Sub

    Sub executaF3()

        If (_incluindo = True) OrElse (_alterando = True) Then 'Se tiver operação executando, então...

            If MessageBox.Show("Operação em aberto! Ela será Substituída?", Application.CompanyName.ToUpper, _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                _alterando = True : _incluindo = False : tbc_usuario.SelectTab(1) : limpaCamposFormUsuario()
                _Usuario.zeraValores()
                _idUsuario = Dg_usuario.CurrentRow.Cells(0).Value : configTelaEditando()
                _Usuario.u_id = _idUsuario
                _UsuarioDAO.TrazUsuarioId_BD(_Usuario, MdlConexaoBD.conectionPadrao)
                trazUsuarioSelecionado() : txt_nome.Focus() : tbp_manutencao.Text = "Alterando"
                btn_salvar.Enabled = True


            End If

        Else
            _alterando = True : _incluindo = False : tbc_usuario.SelectTab(1) : limpaCamposFormUsuario()
            _Usuario.zeraValores()
            _idUsuario = Dg_usuario.CurrentRow.Cells(0).Value : configTelaEditando()
            _Usuario.u_id = _idUsuario
            _UsuarioDAO.TrazUsuarioId_BD(_Usuario, MdlConexaoBD.conectionPadrao)
            trazUsuarioSelecionado() : txt_nome.Focus() : tbp_manutencao.Text = "Alterando"
            btn_salvar.Enabled = True

        End If

    End Sub

    Private Sub btn_acesso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_acesso.Click

        If _incluindo = True And _alterando = False AndAlso _acessos = 0 Then

            '_clUsuarioTelas.pTl_Cadastros = True : _clUsuarioTelas.pTl_movimentos = True : _clUsuarioTelas.pTl_mapas = True
            '_clUsuarioTelas.pTl_cupom = True : _clUsuarioTelas.pTl_estoque = True : _clUsuarioTelas.pTl_financeiro = True
            '_clUsuarioTelas.pTl_manutencao = True : _clUsuarioTelas.pTl_manutencao = True : _clUsuarioTelas.pTl_contabil = True
            '_clUsuarioTelas.pTl_parametros = True
        End If

        Dim formAcessos As New FormUsuarioAcessos
        formAcessos.ShowDialog()
        _TelasUsuario.setaUsuarioTelas(formAcessos.TelasUsuario)
        formAcessos = Nothing

    End Sub

    Sub preencheValoresUsuario()

        With _Usuario

            .u_empresaid = MdlConexaoBD.mdlEmpresa.empid
            .u_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
            .u_nome = Me.txt_nome.Text
            .u_login = Me.txt_login.Text
            .u_senha = mSenhaCrypo
            .u_privilegio = Me.chk_privilegio.Checked
            .u_bloqueado = chk_bloqueado.Checked
            .u_caixa = chkCaixa.Checked
            .u_datanascimento = ""
            If IsDate(msk_dtnascimento.Text) Then .u_datanascimento = CDate(msk_dtnascimento.Text).ToShortDateString

        End With

    End Sub

    Private Sub btn_gravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        mSenhaCrypo = criptografaSenha(Me.txt_senha.Text) : mResultado2 = criptografaSenha(Me.txt_redigita.Text)

        If mSenhaCrypo <> mResultado2 Then

            MsgBox("Atenção ! " & Chr(10) & "Senhas Digitadas não conferem, Redigite !", MsgBoxStyle.Exclamation)
            Me.txt_senha.Text = "" : Me.txt_redigita.Text = "" : Me.txt_senha.Focus()
            Return

        End If

        preencheValoresUsuario()
        If verificaUsuario() Then

            If _incluindo = True Then
                Try
                    inclueUsuario()
                Catch ex As Exception
                    inclueUsuario()
                End Try


            ElseIf _alterando = True Then
                Try
                    alteraUsuario()
                Catch ex As Exception
                    alteraUsuario()
                End Try


            End If
            'If MessageBox.Show("Verifique as telas de Acesso! Deseja Continuar?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
            ' Windows.Forms.DialogResult.Yes Then

            'End If
        End If



    End Sub

    Private Sub Frm_UsuariosManutencao_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then

            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Function criptografaSenha(ByVal senha As String) As String

        Dim Msenha(10), Xsenha(10) As Integer
        Dim senhaCripto As String = ""

        Msenha(0) = 154 : Msenha(1) = 157 : Msenha(2) = 181 : Msenha(3) = 165 : Msenha(4) = 216
        Msenha(5) = 219 : Msenha(6) = 175 : Msenha(7) = 208 : Msenha(8) = 249 : Msenha(9) = 243

        Dim x As Integer
        For x = 1 To Len(senha)

            Xsenha(x - 1) = Asc(Mid(senha, x, 1)) + Msenha(x - 1)
            senhaCripto = RTrim(senhaCripto) & Convert.ToChar(Xsenha(x - 1))

        Next



        Return senhaCripto
    End Function

    Private Sub txt_redigita_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_redigita.Leave

        If Len(txt_redigita.Text) > 10 Then

            MsgBox("Senha com mais de 10 digitus!", MsgBoxStyle.Information)
            txt_redigita.Text = "" : Me.txt_redigita.Focus()

        End If
        If txt_senha.Text <> txt_redigita.Text Then

            MsgBox("Atenção ! " & Chr(10) & "Senhas Digitadas não conferem, Redigite !", MsgBoxStyle.Exclamation)
            Me.txt_redigita.Text = "" : Me.txt_senha.Focus()

        End If



    End Sub

    Private Function verificaUsuario() As Boolean

        If txt_nome.Text.Equals("") Then

            MsgBox("Favor informe o NOME de usuario", MsgBoxStyle.Exclamation)
            txt_senha.Focus() : txt_senha.SelectAll() : Return False
        End If

        If txt_login.Text.Equals("") Then

            MsgBox("Favor informe seu Login", MsgBoxStyle.Exclamation)
            txt_login.Focus() : txt_login.SelectAll() : Return False
        End If

        If txt_senha.Text.Equals("") Then

            MsgBox("Favor informe sua Senha", MsgBoxStyle.Exclamation)
            txt_senha.Focus() : txt_senha.SelectAll() : Return False
        End If

        If criptografaSenha(Me.txt_senha.Text) <> criptografaSenha(Me.txt_redigita.Text) Then

            MsgBox("Atenção ! " & Chr(10) & "Senhas Digitadas não conferem, Redigite !", MsgBoxStyle.Exclamation)
            Me.txt_senhaAtual.SelectAll() : Return False
        End If

        If criptografaSenha(Me.txt_senhaAtual.Text) <> _senhaUsuario Then

            MsgBox("Atenção ! " & Chr(10) & "SenhaAtual incorreta!", MsgBoxStyle.Exclamation)
            Me.txt_senhaAtual.SelectAll() : Return False
        End If



        Return True
    End Function

    Private Sub limpaCamposFormUsuario()

        Me.txt_nome.Text = "" : Me.txt_login.Text = "" : Me.txt_senhaAtual.Text = "" : _senhaUsuario = ""
        Me.txt_senha.Text = "" : Me.txt_redigita.Text = "" : Me.msk_dtnascimento.Text = ""
        Me.chk_privilegio.Checked = False : Me.chk_bloqueado.Checked = False : _idUsuario = _valorZERO

        'telas do Usuario...





    End Sub

    Private Sub inclueUsuarioTelas2(ByVal idUsuario As Int32, ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        _TelasUsuario.idUsuario = _Usuario.u_id
        'If conection.State = ConnectionState.Closed Then conection.Open()
        '_clBD.incUsuarioTelas(_clUsuarioTelas, conection, transacao)



    End Sub

    Private Sub inclueUsuarioTelas(ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim resultadoLogin As Boolean = False
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Dim _drUsuario As NpgsqlDataReader
        Dim idUsuario As Int32 = _valorZERO
        Try
            If conection.State = ConnectionState.Closed Then conection.Open()

            If conection.State = ConnectionState.Open Then
                Try
                    _sqlUsuario.Append("SELECT MAX(u_id) FROM usuario")
                    _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                    _drUsuario = _cmdUsuario.ExecuteReader

                    If _drUsuario.HasRows = True Then

                        While _drUsuario.Read

                            idUsuario = _drUsuario(0)
                        End While
                        _drUsuario.Close()

                        inclueUsuarioTelas2(idUsuario, conection, transacao)
                    End If

                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    resultadoLogin = False

                End Try

                _cmdUsuario.CommandText = ""
                _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
            End If



        Catch ex_ As Exception
            MsgBox("ERRO:: " & ex_.Message, MsgBoxStyle.Critical)

        Finally
            _sqlUsuario = Nothing : _cmdUsuario = Nothing : _drUsuario = Nothing : conection = Nothing

        End Try



    End Sub

    Private Sub inclueUsuario()

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                Return

            End Try


            transacao = conection.BeginTransaction
            _UsuarioDAO.incUsuario(_Usuario, conection, transacao)
            inclueUsuarioTelas(conection, transacao)
            transacao.Commit()

            If MessageBox.Show("Usuario salvo com sucesso! Deseja continuar incluido?", Application.CompanyName.ToUpper, _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
            = Windows.Forms.DialogResult.Yes Then

                _Usuario.zeraValores()
                limpaCamposFormUsuario() : conection.Close() : Me.txt_nome.Focus()

            Else

                _Usuario.zeraValores()
                limpaCamposFormUsuario() : _incluindo = False : _alterando = False : conection.Close()
                tbc_usuario.SelectTab(0) : Me.Dg_usuario.Rows.Clear() : Me.Dg_usuario.Refresh()
                Me.txt_pesquisa.Text = "" : preencheDtg_Usuario("%") : Me.txt_pesquisa.Focus()

            End If

        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally
            transacao = Nothing : conection = Nothing
        End Try



    End Sub

    Private Sub alteraUsuarioTelas2(ByVal idUsuario As Int32, ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        '_clUsuarioTelas.pIdUsuario = idUsuario
        'If conection.State = ConnectionState.Closed Then conection.Open()
        '_clBD.altUsuarioTelas(_clUsuarioTelas, conection, transacao)


    End Sub

    Private Sub alteraUsuarioTelas(ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        'Dim idUsuario As Int32 = _valorZERO
        'If conection.State = ConnectionState.Closed Then conection.Open()
        'If conection.State = ConnectionState.Open Then

        '    alteraUsuarioTelas2(_idUsuario, conection, transacao)

        'End If



    End Sub

    Private Sub alteraUsuario()

        Dim transacao As NpgsqlTransaction
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            Try
                conection.Open()
            Catch ex As Exception
                MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                Return

            End Try


            transacao = conection.BeginTransaction
            _UsuarioDAO.altUsuario(_Usuario, conection, transacao)
            alteraUsuarioTelas(conection, transacao)
            transacao.Commit() : conection.ClearAllPools()

            MsgBox("Usuario salvo com sucesso!", MsgBoxStyle.Exclamation)
            _Usuario.zeraValores()
            limpaCamposFormUsuario() : _incluindo = False : _alterando = False : conection.Close()
            tbc_usuario.SelectTab(0) : Me.Dg_usuario.Rows.Clear() : Me.Dg_usuario.Refresh()
            Me.txt_pesquisa.Text = "" : preencheDtg_Usuario("%") : Me.txt_pesquisa.Focus()


        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                transacao.Rollback()

            Catch ex1 As Exception
            End Try

        Finally
            transacao = Nothing : conection = Nothing
        End Try



    End Sub

    Private Sub txt_login_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_login.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub txt_nome_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_nome.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = _valorZERO Then e.Handled = True

    End Sub

    Private Sub msk_dtnascimento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles msk_dtnascimento.Leave

        If Me.msk_dtnascimento.Text.Length > _valorZERO Then

            If _clFuncoes.RemoverCaracter2(msk_dtnascimento.Text).Equals("") = False Then

                If (Not IsDate(Me.msk_dtnascimento.Text)) OrElse (Me.msk_dtnascimento.Text.Length < 10) Then

                    MsgBox("Data de Nascimento Inválida", MsgBoxStyle.Exclamation)
                    msk_dtnascimento.Focus() : msk_dtnascimento.SelectAll()
                    Return

                End If
            End If

            
        End If



    End Sub

    Private Sub Frm_UsuariosManutencao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        _oConnBD.Open()
        Me.Dg_usuario.Rows.Clear() : Me.Dg_usuario.Refresh() : preencheDtg_Usuario("%")
        Me.txt_pesquisa.Focus()

        Try

            _EmpresaDAO.PreencheCboEmpresasBDLimit_Fantasia(cbo_local, MdlConexaoBD.conectionPadrao, "", "LIMIT 1")
            cbo_local.SelectedIndex = 0
            executaF5()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try



    End Sub

    Private Sub preencheDtg_Usuario(ByVal pesquisa As String)

        Dim nomeCampo As String = ""
        nomeCampo = "u_nome"

        Try
            If _oConnBD.State = ConnectionState.Closed Then _oConnBD.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try


        Dim nome, login As String
        Dim privilegio, bloqueado As Boolean
        Dim id As Int32 = _valorZERO

        Try
            Try
                _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
                _cmdUsuario.CommandText = ""
            Catch ex As Exception
            End Try

            _sqlUsuario.Append("SELECT u_id, u_nome, u_login, u_privilegio, u_bloqueado FROM usuario WHERE ") '4
            _sqlUsuario.Append("UPPER(" & nomeCampo & ") LIKE '" & pesquisa & "%' ORDER BY u_nome ASC")
            _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, _oConnBD)
            _drUsuario = _cmdUsuario.ExecuteReader

            Dg_usuario.Rows.Clear()
            If _drUsuario.HasRows = False Then Return
            While _drUsuario.Read
                id = _drUsuario(0)
                nome = _drUsuario(1).ToString
                login = _drUsuario(2).ToString
                privilegio = _drUsuario(3)
                bloqueado = _drUsuario(4)

                Dg_usuario.Rows.Add(id, nome, login, privilegio, bloqueado)

            End While

            Dg_usuario.Refresh()
            _drUsuario.Close()


        Catch ex As Exception
            MsgBox("ERRO no SELECT do USUARIO:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try

        _cmdUsuario.CommandText = ""
        _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)

        'Limpa Objetos de Memoria...
        nome = Nothing : login = Nothing : privilegio = Nothing : bloqueado = Nothing
        id = Nothing


    End Sub

    Private Sub btn_novo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_novo.Click

        executaF2()

    End Sub

    Private Sub btn_alterar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_alterar.Click

        executaF3()

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click


        If _incluindo = True OrElse _alterando = True Then 'Se tiver operação executando, então...

            If MessageBox.Show("Deseja realmente Cancelar está Operação?", Application.CompanyName.ToUpper, _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                tbc_usuario.SelectTab(0) : limpaCamposFormUsuario() : tbp_manutencao.Text = "Usuario"
                _Usuario.zeraValores()
                _incluindo = False : _alterando = False : btn_salvar.Enabled = False : configTelaNormal()
                Me.Dg_usuario.Rows.Clear() : Me.Dg_usuario.Refresh() : preencheDtg_Usuario("%")
                Me.txt_pesquisa.Focus()

            End If
        End If


    End Sub

    Private Sub trazUsuarioSelecionado()

        Me.txt_nome.Text = _Usuario.u_nome
        Me.txt_login.Text = _Usuario.u_login
        _senhaUsuario = _Usuario.u_senha
        msk_dtnascimento.Text = ""
        If IsDate(_Usuario.u_datanascimento) Then Me.msk_dtnascimento.Text = Format(_Usuario.u_datanascimento, "dd/MM/yyyy")
        Me.chk_privilegio.Checked = _Usuario.u_privilegio
        Me.chk_bloqueado.Checked = _Usuario.u_bloqueado
        chkCaixa.Checked = _Usuario.u_caixa
        
    End Sub

    Private Sub configTelaNormal()

        lbl_senha.SetBounds(72, 144, 54, 18) : txt_senha.SetBounds(133, 141, 90, 24)
        lbl_redigite.SetBounds(61, 177, 65, 18) : txt_redigita.SetBounds(133, 173, 90, 24)
        chk_privilegio.SetBounds(12, 209, 114, 21) : chk_bloqueado.SetBounds(31, 232, 95, 21)
        lbl_senhaAtual.SetBounds(144, 260, 86, 18) : txt_senhaAtual.SetBounds(236, 257, 90, 24)
        lbl_senhaAtual.Visible = False : txt_senhaAtual.Visible = False

    End Sub

    Private Sub configTelaEditando()

        lbl_senha.SetBounds(72, 179, 54, 18) : txt_senha.SetBounds(133, 176, 90, 24)
        lbl_redigite.SetBounds(61, 212, 65, 18) : txt_redigita.SetBounds(133, 208, 90, 24)
        chk_privilegio.SetBounds(12, 244, 114, 21) : chk_bloqueado.SetBounds(31, 267, 95, 21)
        lbl_senhaAtual.SetBounds(40, 148, 86, 18) : txt_senhaAtual.SetBounds(133, 145, 90, 24)
        lbl_senhaAtual.Visible = True : txt_senhaAtual.Visible = True

    End Sub

    Private Sub txt_senhaAtual_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_senhaAtual.Leave

        If criptografaSenha(Me.txt_senhaAtual.Text) <> _senhaUsuario Then

            MsgBox("Atenção ! " & Chr(10) & "SenhaAtual incorreta!", MsgBoxStyle.Exclamation)
            txt_senhaAtual.Focus() : Me.txt_senhaAtual.SelectAll()

        End If


    End Sub

    Private Sub txt_pesquisa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pesquisa.TextChanged

        Me.preencheDtg_Usuario(Me.txt_pesquisa.Text)
    End Sub

    Private Function cbo_vendedor() As Object
        Throw New NotImplementedException
    End Function

    Private Sub tbc_usuario_KeyDown(sender As Object, e As KeyEventArgs) Handles tbc_usuario.KeyDown

        Select Case e.KeyCode
            Case Keys.F5
                executaF5()
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                executaF2()
            Case Keys.F3
                executaF3()
        End Select
    End Sub
End Class