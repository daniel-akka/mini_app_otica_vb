Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class FrmCadMarca

    Dim _MarcaProduto As New ClMarca
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


        If IsNumeric(txtIdMarca.Text) Then _MarcaProduto.idMarca = CInt(txtIdMarca.Text)
        _MarcaProduto.descricao = Trim(txtDescricao.Text)
        _MarcaProduto.padrao = chkPadrao.Checked

        If _MarcaProduto.ValidaMarca(_MarcaProduto, _tipoOperacao) = False Then Return

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
                _MarcaProduto.incMarca(_MarcaProduto, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _MarcaProduto.altMarca(_MarcaProduto, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Marca Gravada com Sucesso!", MsgBoxStyle.Exclamation)
            Modificacao = True
            _MarcaProduto.TrazListMarcas(MdlConexaoBD.mdlListMarca, MdlConexaoBD.conectionPadrao)
            txtDescricao.Text = "" : txtIdMarca.Text = "" : chkPadrao.Checked = False
            _MarcaProduto.ZeraValores()
            ExecutaF5()
            _tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _MarcaProduto.PreencheCboMarcas(CboMarca, MdlConexaoBD.conectionPadrao)
    End Sub

    Sub ExecuteDel()

        If CboMarca.SelectedIndex < 0 Then MsgBox("Selecione uma Marca para Excluir!") : Return
        If MessageBox.Show("Deseja Realmente Deletar a Marca -> """ & CboMarca.SelectedItem & """ ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _MarcaProduto.descricao = CboMarca.SelectedItem
            _MarcaProduto.TrazMarcaNome(_MarcaProduto, MdlConexaoBD.conectionPadrao)


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
                _MarcaProduto.delMarca(_MarcaProduto, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Marca Deletada com Sucesso!", MsgBoxStyle.Exclamation)
                _MarcaProduto.TrazListMarcas(MdlConexaoBD.mdlListMarca, MdlConexaoBD.conectionPadrao)
                txtDescricao.Text = "" : txtIdMarca.Text = "" : chkPadrao.Checked = False
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
        If CboMarca.SelectedIndex < 0 Then MsgBox("Selecione uma Marca para Alterar!") : Return
        _MarcaProduto.descricao = CboMarca.SelectedItem
        _MarcaProduto.TrazMarcaNome(_MarcaProduto, MdlConexaoBD.conectionPadrao)

        _tipoOperacao = "A"
        txtIdMarca.Text = _MarcaProduto.idMarca
        txtDescricao.Text = _MarcaProduto.descricao
        chkPadrao.Checked = _MarcaProduto.padrao
        txtDescricao.Focus()

    End Sub
End Class