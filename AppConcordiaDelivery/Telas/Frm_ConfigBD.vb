Imports Npgsql
Imports System.Text

Public Class Frm_ConfigBD

    Private _clFuncoes As New ClFuncoes
    Private _caminhoArq As String = "\configBD.sys"
    Dim _configuracoes As New ClConfiguracoes
    Dim _coniguracoesDAO As New ClConfiguracoesDAO

    'Campos:
    Dim Server As String = ""
    Dim Banco As String = ""
    Dim User As String = ""
    Dim Senha As String = ""
    Dim Porta As String = ""

    Private Sub btn_salvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salvar.Click

        If Me.txtPastaDoSistema.Text.Equals("") Then
            MsgBox("Informe a Pasta do Sistema")
            Return
        End If

        If txt_passwordBD.Text.Equals("") Then
            MsgBox("Informe uma Senha")
            txt_passwordBD.Focus()
            Return
        End If

        MdlConexaoBD.mdlConfiguracoes.caminho_pasta_sistema = txtPastaDoSistema.Text
        _caminhoArq = Me.txtPastaDoSistema.Text & "\configBD.sys"
        'Dim transacao As NpgsqlTransaction
        Try
            Dim mConexao As String = ""
            mConexao = "Server=" & txt_serverBD.Text & ";"
            mConexao += "Port=" & txt_portBD.Text & ";"
            mConexao += "UserId=" & txt_userIdBD.Text & ";"
            mConexao += "Password=" & txt_passwordBD.Text & ";"
            mConexao += "Database=" & txt_dataBaseBD.Text & ""

            MdlConexaoBD.conectionPadrao = mConexao

            _clFuncoes.AlteraConfigBD_Arquivo(_caminhoArq, txt_serverBD.Text, txt_dataBaseBD.Text, txt_userIdBD.Text, txt_passwordBD.Text, txt_portBD.Text)
            MsgBox("Configurações salvadas", MsgBoxStyle.Exclamation)

            Me.Close()
        Catch ex As Exception
            MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
            Try
                'transacao.Rollback()
            Catch ex1 As Exception
            End Try
        End Try


    End Sub

    Private Sub salvarConfBD(ByVal conection As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                             ByVal server As String, ByVal port As String, ByVal userID As String, _
                             ByVal password As String, ByVal dataBase As String)

        Dim resultadoLogin As Boolean = False
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Try
            If conection.State = ConnectionState.Open Then
                Try
                    _sqlUsuario.Append("UPDATE confbd SET bd_server = @bd_server, bd_port = @bd_port, ")
                    _sqlUsuario.Append("bd_userid = @bd_userid, bd_password = @bd_password, bd_database = ")
                    _sqlUsuario.Append("@bd_database")
                    _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conection)
                    _cmdUsuario.Parameters.Add("@bd_server", server)
                    _cmdUsuario.Parameters.Add("@bd_port", port)
                    _cmdUsuario.Parameters.Add("@bd_userid", userID)
                    _cmdUsuario.Parameters.Add("@bd_password", password)
                    _cmdUsuario.Parameters.Add("@bd_database", dataBase)

                    _cmdUsuario.ExecuteNonQuery()
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
            _sqlUsuario = Nothing
            _cmdUsuario = Nothing
            conection = Nothing
        End Try

    End Sub

    Private Sub trazConfigBD()

        Try
            Dim resultadoLogin As Boolean = False
            _caminhoArq = _clFunc.LerArquivoSalvo("\Conf.txt") & _caminhoArq
            Me.txt_serverBD.Text = _clFuncoes.trazLinhaArquivoTXT(_caminhoArq, 1)
            Me.txt_dataBaseBD.Text = _clFuncoes.trazLinhaArquivoTXT(_caminhoArq, 2)
            Me.txt_userIdBD.Text = _clFuncoes.trazLinhaArquivoTXT(_caminhoArq, 3)
            Me.txt_passwordBD.Text = _clFuncoes.trazLinhaArquivoTXT(_caminhoArq, 4)
            Me.txt_portBD.Text = _clFuncoes.trazLinhaArquivoTXT(_caminhoArq, 5)
            txtPastaDoSistema.Text = _clFunc.LerArquivoSalvo("\Conf.txt")
        Catch ex As Exception
        End Try


    End Sub

    Private Sub Frm_ConfigBD_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

        End Select
    End Sub

    Private Sub Frm_ConfigBD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        trazConfigBD()
    End Sub

    Private Sub Frm_ConfigBD_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnPastaDoSistema_Click(sender As Object, e As EventArgs) Handles btnPastaDoSistema.Click

        BuscaPastaAplicacao()
    End Sub

    Public Sub BuscaPastaAplicacao()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txtPastaDoSistema.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txtPastaDoSistema.Text = ""
        End Try

    End Sub

End Class