Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql
Public Class FrmCadRua

    Dim _Rua As New ClRua
    Dim _RuaDao As New ClRuaDAO
    Dim _funcoes As New ClFuncoes

    Dim _tipoOperacao As String = "I"

    Private Sub FrmCadRua_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecutaF5()
    End Sub

    Private Sub FrmCadRua_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
            Case Keys.Delete
                ExecuteDel()
        End Select

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click


        If IsNumeric(txtIdRua.Text) Then _Rua.rId = CInt(txtIdRua.Text)
        _Rua.rNome = Trim(txtRua.Text)
        If _RuaDao.ValidaRua(_Rua, _tipoOperacao) = False Then Return

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If _tipoOperacao.Equals("I") Then
                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _RuaDao.incRua(_Rua, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _RuaDao.altRua(_Rua, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("RUA Gravada com Sucesso!", MsgBoxStyle.Exclamation)
            _RuaDao.TrazListRuas(MdlConexaoBD.mdlListRuas, MdlConexaoBD.conectionPadrao)
            txtRua.Text = "" : txtIdRua.Text = ""
            _Rua.ZeraValores()
            ExecutaF5()
            _tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _RuaDao.PreencheCboRuasBD(CboRua, MdlConexaoBD.conectionPadrao)
    End Sub

    Sub ExecuteDel()

        If CboRua.SelectedIndex < 0 Then MsgBox("Selecione uma Rua para Excluir!") : Return
        If MessageBox.Show("Deseja Realmente Deletar a RUA -> """ & CboRua.SelectedItem & """ ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _Rua.rNome = CboRua.SelectedItem
            _RuaDao.TrazRuaNome(_Rua, MdlConexaoBD.conectionPadrao)


            Dim transacao As NpgsqlTransaction
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try

                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.ProductName)
                    Return
                End Try

                transacao = conection.BeginTransaction
                _RuaDao.delRua(_Rua, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("RUA Deletada com Sucesso!", MsgBoxStyle.Exclamation)
                _RuaDao.TrazListRuas(MdlConexaoBD.mdlListRuas, MdlConexaoBD.conectionPadrao)
                ExecutaF5()
                _tipoOperacao = "I"
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

    End Sub

    Sub ExecutaF3()
        If CboRua.SelectedIndex < 0 Then MsgBox("Selecione uma RUA para Alterar!") : Return
        _Rua.rNome = CboRua.SelectedItem
        _RuaDao.TrazRuaNome(_Rua, MdlConexaoBD.conectionPadrao)

        _tipoOperacao = "A"
        txtIdRua.Text = _Rua.rId
        txtRua.Text = _Rua.rNome
        txtRua.Focus()

    End Sub

End Class