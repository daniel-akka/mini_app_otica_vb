Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql
Public Class FrmCadUnidade

    Dim _Unidade As New ClUnidade
    Dim _UnidadeDao As New ClUnidadeDAO
    Dim _funcoes As New ClFuncoes

    Dim _tipoOperacao As String = "I"

    Public Modificacao As Boolean = False

    Private Sub FrmCadUnidade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecutaF5()
    End Sub

    Private Sub FrmCadUnidade_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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


        If IsNumeric(txtIdUnidade.Text) Then _Unidade.Id = CInt(txtIdUnidade.Text)
        _Unidade.Descricao = Trim(txtUnidade.Text)
        _Unidade.uPadrao = chkPadrao.Checked

        If _UnidadeDao.ValidaUnidade(_Unidade, _tipoOperacao) = False Then Return

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
                _UnidadeDao.incUnidade(_Unidade, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _UnidadeDao.altUnidade(_Unidade, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Unidade Gravada com Sucesso!", MsgBoxStyle.Exclamation)
            Modificacao = True
            _UnidadeDao.TrazListUnidades(MdlConexaoBD.mdlListUnidades, MdlConexaoBD.conectionPadrao)
            txtUnidade.Text = "" : txtIdUnidade.Text = "" : chkPadrao.Checked = False
            _Unidade.ZeraValores()
            ExecutaF5()
            _tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _UnidadeDao.PreencheCboUnidades(CboUnidade, MdlConexaoBD.conectionPadrao)
    End Sub

    Sub ExecuteDel()

        If CboUnidade.SelectedIndex < 0 Then MsgBox("Selecione uma Unidade para Excluir!") : Return
        If MessageBox.Show("Deseja Realmente Deletar a Unidade -> """ & CboUnidade.SelectedItem & """ ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _Unidade.Descricao = CboUnidade.SelectedItem
            _UnidadeDao.TrazUnidadeNome(_Unidade, MdlConexaoBD.conectionPadrao)


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
                _UnidadeDao.delUnidade(_Unidade, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Unidade Deletada com Sucesso!", MsgBoxStyle.Exclamation)
                _UnidadeDao.TrazListUnidades(MdlConexaoBD.mdlListUnidades, MdlConexaoBD.conectionPadrao)
                txtUnidade.Text = "" : txtIdUnidade.Text = "" : chkPadrao.Checked = False
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
        If CboUnidade.SelectedIndex < 0 Then MsgBox("Selecione uma Unidade para Alterar!") : Return
        _Unidade.Descricao = CboUnidade.SelectedItem
        _UnidadeDao.TrazUnidadeNome(_Unidade, MdlConexaoBD.conectionPadrao)

        _tipoOperacao = "A"
        txtIdUnidade.Text = _Unidade.Id
        txtUnidade.Text = _Unidade.Descricao
        chkPadrao.Checked = _Unidade.uPadrao
        txtUnidade.Focus()

    End Sub

End Class