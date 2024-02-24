Imports Npgsql
Imports System.Text
Imports System.DateTime
Imports System.Threading
Imports System.ComponentModel
Imports System.IO

Public Class FormLogin

    Private _clFuncoes As New ClFuncoes
    Dim agora As Date = Now
    Public Shared _frmRef_Login As New FormLogin
    Private INT_mValorZERO As Integer = 0
    Public _loginOK As Boolean = False
    Private _mac As String = ""
    Public _sincronizar As Boolean = False
    Public privilegio As Boolean = False
    Dim mtenta As Integer = 1
    Public primeiroAcesso As Boolean = False
    Public _formRequest As New FormPrincipal
    Public Shared _frmRef As FormLogin
    Dim bw As New BackgroundWorker
    Dim Usuario As New ClUsuario
    Dim UsuarioDAO As New ClUsuarioDAO
    Public ResultadoLogin As Boolean = False


    'Campos:
    Dim Server As String = ""
    Dim Banco As String = ""
    Dim User As String = ""
    Dim Senha As String = ""
    Dim Porta As String = ""

    Private Sub Frm_login_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub txt_senha_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_senha.GotFocus
        Me.txt_senha.SelectAll()
    End Sub

    Private Sub txt_senha_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_senha.Leave

        If txt_senha.Text <> "" Then
            Dim Msenha(10), Xsenha(10) As Integer
            Dim mresultado As String

            Msenha(0) = 154 : Msenha(1) = 157 : Msenha(2) = 181 : Msenha(3) = 165
            Msenha(4) = 216 : Msenha(5) = 219 : Msenha(6) = 175 : Msenha(7) = 208
            Msenha(8) = 249 : Msenha(9) = 243

            Dim x As Integer
            For x = 1 To Len(Me.txt_senha.Text)
                Xsenha(x - 1) = Asc(Mid(txt_senha.Text, x, 1)) + Msenha(x - 1)
                mresultado = RTrim(mresultado) & Convert.ToChar(Xsenha(x - 1))

            Next

            _loginOK = False
            If validaLogin(Me.txt_login.Text, mresultado) Then

                _loginOK = True
                ResultadoLogin = True
                Me.Close()

                ''SINCRONIZAÇÃO:
                'If MdlEmpresaUsu.sincroniza Then

                '    If _sincronizar Then

                '        Try

                '            If File.Exists("\Wged\Sincroniza\Sincroniza.exe") Then

                '                Shell("\Wged\Sincroniza\Sincroniza.exe", AppWinStyle.Hide, False)
                '                _loginOK = False
                '                _formRequest._frmRef.rlogin = _loginOK
                '                Application.ExitThread()
                '                Application.Exit()
                '                Me.Close()
                '            End If

                '        Catch ex As Exception
                '            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                '        End Try
                '    End If

                'End If

            Else

                ResultadoLogin = False
                MsgBox("Login Incorreto", MsgBoxStyle.Exclamation)
                SendKeys.Send("{TAB}")
            End If


        End If



    End Sub

    Private Function validaLogin(ByVal login As String, ByVal senhaCrypt As String) As Boolean

        Dim resultadoLogin As Boolean = False
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Dim _dr As NpgsqlDataReader

        Try
            conection.Open()

            If conection.State = ConnectionState.Open Then
                Try
                    _sqlUsuario.Append("SELECT * FROM usuario")
                    _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                    _dr = _cmdUsuario.ExecuteReader

                    If _dr.HasRows Then

                        Me.primeiroAcesso = False

                        'Traz o Usuário...
                        Usuario.u_login = txt_login.Text
                        Usuario.u_senha = senhaCrypt
                        UsuarioDAO.TrazUsuarioLOGIN_SENHA_BD(Usuario, MdlConexaoBD.conectionPadrao)

                        If Usuario.u_id > 0 Then
                            resultadoLogin = True
                            MdlConexaoBD.mdlUsuarioLogado.setaValores(Usuario)
                            'Configura telas:

                        Else
                            resultadoLogin = False
                        End If
                    End If

                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    resultadoLogin = False
                End Try

                _cmdUsuario.CommandText = ""
                _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
            End If

            If primeiroAcesso Then resultadoLogin = primeiroAcesso

            conection.ClearAllPools() : conection.Close()
        Catch ex_ As Exception
            MsgBox("ERRO:: " & ex_.Message, MsgBoxStyle.Critical)

            Try
                conection.ClearAllPools()
                If conection.State = ConnectionState.Open Then conection.Close()
                _sqlUsuario = Nothing : _cmdUsuario = Nothing : _dr = Nothing : conection = Nothing
                Return False
            Catch ex As Exception
            End Try
        End Try

        _sqlUsuario = Nothing : _cmdUsuario = Nothing : _dr = Nothing : conection = Nothing

        resultadoLogin = resultadoLogin
        Return resultadoLogin
    End Function

    Private Function validaLogin() As Boolean

        Dim resultadoLogin As Boolean = False
        Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Dim _dr As NpgsqlDataReader

        Try
            conection.Open()

            If conection.State = ConnectionState.Open Then
                Try
                    _sqlUsuario.Append("SELECT * FROM usuario")
                    _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                    _dr = _cmdUsuario.ExecuteReader

                    resultadoLogin = False
                    Me.privilegio = False
                    Me.primeiroAcesso = False
                    If _dr.HasRows = False Then

                        resultadoLogin = True
                        Me.privilegio = True
                        Me.primeiroAcesso = True

                    End If

                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    resultadoLogin = False
                End Try

                _cmdUsuario.CommandText = ""
                _sqlUsuario.Remove(0, _sqlUsuario.ToString.Length)
            End If

            If primeiroAcesso Then resultadoLogin = primeiroAcesso

            conection.ClearAllPools() : conection.Close()
        Catch ex_ As Exception
            MsgBox("ERRO:: " & ex_.Message, MsgBoxStyle.Critical)

            Try
                conection.ClearAllPools()
                If conection.State = ConnectionState.Open Then conection.Close()
                _sqlUsuario = Nothing : _cmdUsuario = Nothing : _dr = Nothing : conection = Nothing
                Return False
            Catch ex As Exception
            End Try
        End Try

        _sqlUsuario = Nothing : _cmdUsuario = Nothing : _dr = Nothing : conection = Nothing

        resultadoLogin = resultadoLogin
        Return resultadoLogin
    End Function


    Private Sub txt_login_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_login.GotFocus
        Me.txt_login.SelectAll()
    End Sub

    Private Sub txt_login_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_login.KeyPress
        'permite só letras
        If _clFuncoes.SoLetras(CShort(Asc(e.KeyChar))) = INT_mValorZERO Then e.Handled = True

    End Sub

    Private Function tempoOK(ByVal tempo As Integer) As Boolean

        Dim cont As Integer = 0

        While cont < 3

            System.Threading.Thread.Sleep(CInt((tempo * 1000)))
            cont += 1
        End While

        Return True
    End Function

    Sub carregaConexao()

        Dim mPastaSis As String = _clFuncoes.LerArquivoSalvo("\conf.txt")
        Dim mArquivo As String = mPastaSis & "\configBD.sys"
        Dim mConexaoOK As Boolean = False

        'Campos:
        Server = _clFuncoes.trazLinhaArquivoTXT(mArquivo, 1)
        Banco = _clFuncoes.trazLinhaArquivoTXT(mArquivo, 2)
        User = _clFuncoes.trazLinhaArquivoTXT(mArquivo, 3)
        Senha = _clFuncoes.trazLinhaArquivoTXT(mArquivo, 4)
        Porta = _clFuncoes.trazLinhaArquivoTXT(mArquivo, 5)

        MdlConexaoBD.conectionPadrao = "Server=" & Server & _
        ";Port=" & Porta & ";UserId=" & User & ";Password=" & Senha & ";Database=" & Banco & _
        ";maxPoolSize=100;Timeout=7;CommandTimeout=7;"
        mConexaoOK = mdlConfiguracoesDAO.TrazConfiguracoesID(mdlConfiguracoes, MdlConexaoBD.conectionPadrao)
        'Configuraconexao:

        If mConexaoOK = False Then

            _loginOK = False
            If MessageBox.Show("Deseja Configurar a Conexão do SISTEMA?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) _
                = Windows.Forms.DialogResult.Yes Then

                ChamaFormConfigBD()

            Else 'Senao Testa os Arquivos Texto Sincronizacao:
                _loginOK = False
                Return

            End If
        End If

        _loginOK = mConexaoOK
        mdlPadraoSistemaDAO.TrazPadraoSistema(mdlPadraoSistema, MdlConexaoBD.conectionPadrao)

        VerificacaoTravamento()

        _mac = _clFuncoes.EnderecoMac
        _sincronizar = _clFuncoes.trazSincronizaBD(_mac, MdlConexaoBD.conectionPadrao)

    End Sub

    Private Sub Frm_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try
            
            carregaConexao()
            _loginOK = False
            If validaLogin() Then 'Verifica se o banco não tem usuarios
                _loginOK = True
                ResultadoLogin = True
                Me.Close()
            End If

            If _loginOK = False Then Me.Close()
        Catch ex1 As Exception


            If MessageBox.Show("Deseja Configurar a Conexão do SISTEMA?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) _
                    = Windows.Forms.DialogResult.Yes Then

                ChamaFormConfigBD()

            Else 'Senao Testa os Arquivos Texto Sincronizacao:
                Me.Close()
            End If

            If mdlConfiguracoes.tId <= 0 Then Me.Close()
        End Try

       

    End Sub

    Sub VerificacaoTravamento()

        Dim _clTravarPrograma As New ClTravaPrograma
        Dim _erroDeAcessoBanco As Boolean = False
        _clTravarPrograma.Travar = _clTravarPrograma.trazTravar(MdlConexaoBD.conectionPadrao, _erroDeAcessoBanco)

        If _erroDeAcessoBanco = False Then
            If _clTravarPrograma.Travar = False Then

                Dim dataPrograma As String = "", travar As Boolean = False
                Dim dataWindows As String = Format(Date.Now, "dd/MM/yyyy")
                Dim resultComparacao As Int16 = 0
                _clTravarPrograma.DataTravamento = _clTravarPrograma.trazDataTravamento(MdlConexaoBD.conectionPadrao)
                dataPrograma = Format(_clTravarPrograma.DataTravamento, "dd/MM/yyyy")
                resultComparacao = DateTime.Compare(Convert.ChangeType(dataPrograma, GetType(Date)), Convert.ChangeType(dataWindows, GetType(Date)))
                If resultComparacao < 1 Then
                    _clTravarPrograma.atualizaTravar(True, MdlConexaoBD.conectionPadrao)
                    MsgBox("Programa Expirado!", MsgBoxStyle.Critical, "Atenção!") : Me.Close()
                End If

            Else
                MsgBox("Programa Expirado!", MsgBoxStyle.Critical, "Atenção!") : Me.Close()
            End If
        Else
            MsgBox("ERRO de Conexão ao Banco!", MsgBoxStyle.Critical)
        End If


    End Sub

    Private Sub Frm_login_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfigBanco.Click

        ChamaFormConfigBD()
    End Sub

    Sub ChamaFormConfigBD()

        Dim mFrmLogGeral As New Frm_LoginGeral
        mFrmLogGeral.ShowDialog()
        privilegio = mFrmLogGeral._loginOK
        mFrmLogGeral.Dispose()

        If privilegio = True Then

            Dim mFrmConfBD As New Frm_ConfigBD
            mFrmConfBD.ShowDialog()
            Me.txt_login.Focus() : Me.txt_login.SelectAll()

            Try
                carregaConexao()
            Catch ex As Exception
                Me.Close()
            End Try
        End If


    End Sub

End Class