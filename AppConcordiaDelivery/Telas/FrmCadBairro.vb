Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql
Public Class FrmCadBairro

    Dim _Bairro As New ClBairro
    Dim _BairroDao As New ClBairroDAO
    Dim _funcoes As New ClFuncoes

    Dim _tipoOperacao As String = "I"

    Private Sub FrmCadBairro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecutaF5()
    End Sub

    Private Sub FrmCadBairro_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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


        If IsNumeric(txtIdBairro.Text) Then _Bairro.bId = CInt(txtIdBairro.Text)
        _Bairro.bNome = Trim(txtBairro.Text)
        If _BairroDao.ValidaBairro(_Bairro, _tipoOperacao) = False Then Return

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
                _BairroDao.incBairro(_Bairro, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _BairroDao.altBairro(_Bairro, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Bairro Gravado com Sucesso!", MsgBoxStyle.Exclamation)
            _BairroDao.TrazListBairros(MdlConexaoBD.mdlListBairros, MdlConexaoBD.conectionPadrao)
            txtBairro.Text = "" : txtIdBairro.Text = ""
            _Bairro.ZeraValores()
            ExecutaF5()
            _tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _BairroDao.PreencheCboBairrosBD(CboBairros, MdlConexaoBD.conectionPadrao)
    End Sub

    Sub ExecuteDel()

        If CboBairros.SelectedIndex < 0 Then MsgBox("Selecione um Bairro para Excluir!") : Return
        If MessageBox.Show("Deseja Realmente Deletar o Bairro -> """ & CboBairros.SelectedItem & """ ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _Bairro.bNome = CboBairros.SelectedItem
            _BairroDao.TrazBairroNome(_Bairro, MdlConexaoBD.conectionPadrao)


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
                _BairroDao.delBairro(_Bairro, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Bairro Deletado com Sucesso!", MsgBoxStyle.Exclamation)
                _BairroDao.TrazListBairros(MdlConexaoBD.mdlListBairros, MdlConexaoBD.conectionPadrao)
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
        If CboBairros.SelectedIndex < 0 Then MsgBox("Selecione um Bairro para Alterar!") : Return
        _Bairro.bNome = CboBairros.SelectedItem
        _BairroDao.TrazBairroNome(_Bairro, MdlConexaoBD.conectionPadrao)

        _tipoOperacao = "A"
        txtIdBairro.Text = _Bairro.bId
        txtBairro.Text = _Bairro.bNome
        txtBairro.Focus()

    End Sub

End Class