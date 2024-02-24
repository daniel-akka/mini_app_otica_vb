Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql
Public Class FrmCadGrupo

    Dim _GrupoProduto As New ClGrupoProduto
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


        If IsNumeric(txtIdGrupo.Text) Then _GrupoProduto.idGrupo = CInt(txtIdGrupo.Text)
        _GrupoProduto.Descricao = Trim(txtDescricao.Text)
        _GrupoProduto.padrao = chkPadrao.Checked

        If _GrupoProduto.ValidaGrupo(_GrupoProduto, _tipoOperacao) = False Then Return

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
                _GrupoProduto.incGrupo(_GrupoProduto, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _GrupoProduto.altGrupo(_GrupoProduto, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Grupo Gravado com Sucesso!", MsgBoxStyle.Exclamation)
            Modificacao = True
            _GrupoProduto.TrazListGrupos(MdlConexaoBD.mdlListGrupoProdutos, MdlConexaoBD.conectionPadrao)
            txtDescricao.Text = "" : txtIdGrupo.Text = "" : chkPadrao.Checked = False
            _GrupoProduto.ZeraValores()
            ExecutaF5()
            _tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _GrupoProduto.PreencheCboGrupos(CboGrupo, MdlConexaoBD.conectionPadrao)
    End Sub

    Sub ExecuteDel()

        If CboGrupo.SelectedIndex < 0 Then MsgBox("Selecione um GRUPO para Excluir!") : Return
        If MessageBox.Show("Deseja Realmente Deletar o Grupo -> """ & CboGrupo.SelectedItem & """ ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _GrupoProduto.descricao = CboGrupo.SelectedItem
            _GrupoProduto.TrazGrupoNome(_GrupoProduto, MdlConexaoBD.conectionPadrao)


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
                _GrupoProduto.delGrupo(_GrupoProduto, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Grupo Deletado com Sucesso!", MsgBoxStyle.Exclamation)
                _GrupoProduto.TrazListGrupos(MdlConexaoBD.mdlListGrupoProdutos, MdlConexaoBD.conectionPadrao)
                txtDescricao.Text = "" : txtIdGrupo.Text = "" : chkPadrao.Checked = False
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
        If CboGrupo.SelectedIndex < 0 Then MsgBox("Selecione um Grupo para Alterar!") : Return
        _GrupoProduto.descricao = CboGrupo.SelectedItem
        _GrupoProduto.TrazGrupoNome(_GrupoProduto, MdlConexaoBD.conectionPadrao)

        _tipoOperacao = "A"
        txtIdGrupo.Text = _GrupoProduto.idGrupo
        txtDescricao.Text = _GrupoProduto.descricao
        chkPadrao.Checked = _GrupoProduto.padrao
        txtDescricao.Focus()

    End Sub
End Class