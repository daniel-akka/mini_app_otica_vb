Imports Npgsql
Public Class FrmCadTipoDocumento

    Dim _TipoDocumento As New ClTipoDocumento
    Dim _TipoDocumentoDAO As New ClTipoDocumentoDAO
    Dim _ListaTipoDocumento As New List(Of ClTipoDocumento)
    Dim _Operacao As String = "I"

    Private Sub FrmCadTipoDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmCadTipoDocumento_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F2
                executaF2()

            Case Keys.F3
                executaF3()

            Case Keys.Delete
                executaDel()

            Case Keys.F7
                executaF7()

            Case Keys.F5
                executaF5()

        End Select
    End Sub

    Sub executaF2()

        _Operacao = "I"
        habilitaCampos()
        txtDescricao.Focus()
    End Sub

    Sub executaF3()

        If dtgTipoDocumento.CurrentRow.IsNewRow Then
            MsgBox("Selecione um Registro Para Alterar!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        habilitaCampos()
        _TipoDocumento.td_id = dtgTipoDocumento.CurrentRow.Cells(0).Value
        _TipoDocumentoDAO.TrazTipoDocumento(_TipoDocumento, MdlConexaoBD.conectionPadrao)
        _Operacao = "A"
        preenchCamposFormulario()
        txtDescricao.Focus() : txtDescricao.SelectAll()
    End Sub

    Sub preenchCamposFormulario()

        txtID.Text = _TipoDocumento.td_id
        txtDescricao.Text = _TipoDocumento.td_descricao
        Select Case _TipoDocumento.td_tela.ToUpper
            Case "AP"
                rdbAPagar.Checked = True
            Case "AR"
                rdbAReceber.Checked = True
        End Select
    End Sub

    Sub preencheValoresTipoDocumento()

        If IsNumeric(txtID.Text) Then
            _TipoDocumento.td_id = CInt(txtID.Text)
        End If

        _TipoDocumento.td_descricao = txtDescricao.Text
        _TipoDocumento.td_tela = "AP"
        If rdbAPagar.Checked Then _TipoDocumento.td_tela = "AP"
        If rdbAReceber.Checked Then _TipoDocumento.td_tela = "AR"
    End Sub

    Sub executaDel()

        If dtgTipoDocumento.CurrentRow.IsNewRow Then Return
        If MessageBox.Show("Deseja Realmente Deletar esse Registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


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
                _TipoDocumento.td_id = dtgTipoDocumento.CurrentRow.Cells(0).Value
                _TipoDocumentoDAO.delTipoDocumento(_TipoDocumento, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Registro Deletado com Sucesso!", MsgBoxStyle.Exclamation)
                executaF5()
                _TipoDocumento.zeraValores()
                _Operacao = "I"
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

    Sub executaF7()

        If verificaTipoDocumento() Then

            preencheValoresTipoDocumento()
            salvandoTipoDocumento()
        End If

    End Sub

    Sub executaF5()

        _TipoDocumentoDAO.TrazListTipoDocumentos(_ListaTipoDocumento, MdlConexaoBD.conectionPadrao)
        dtgTipoDocumento.Rows.Clear()
        Dim mTela As String = ""
        For Each td As ClTipoDocumento In _ListaTipoDocumento
            Select Case td.td_tela.ToUpper
                Case "AP"
                    mTela = "APAGAR"
                Case "AR"
                    mTela = "ARECEBER"
            End Select
            dtgTipoDocumento.Rows.Add(td.td_id, td.td_descricao, mTela)
        Next

    End Sub

    Sub salvandoTipoDocumento()

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
                _TipoDocumentoDAO.incTipoDocumento(_TipoDocumento, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _TipoDocumentoDAO.altTipoDocumento(_TipoDocumento, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Registro Gravado com Sucesso!", MsgBoxStyle.Exclamation)
            desabilitaCampos()
            _TipoDocumento.zeraValores()
            ExecutaF5()
            _Operacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Function verificaTipoDocumento() As Boolean

        If Trim(txtDescricao.Text).Equals("") Then
            MsgBox("Informe uma Descrição Por Favo!")
            txtDescricao.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        desabilitaCampos()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        executaF7()
    End Sub

    Sub desabilitaCampos()
        btnSalvar.Enabled = False
        _TipoDocumento.zeraValores()
        txtID.Text = ""
        txtDescricao.Text = ""
        rdbAPagar.Checked = True
    End Sub

    Sub habilitaCampos()
        btnSalvar.Enabled = True
        _TipoDocumento.zeraValores()
        txtID.Text = ""
        txtDescricao.Text = ""
        rdbAPagar.Checked = True
    End Sub

    Private Sub FrmCadTipoDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _TipoDocumentoDAO.TrazListTipoDocumentos(_ListaTipoDocumento, MdlConexaoBD.conectionPadrao)
        executaF5()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        executaDel()
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        executaF3()
    End Sub

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        executaF2()
    End Sub

    Private Sub dtgTipoDocumento_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgTipoDocumento.RowsAdded

        If dtgTipoDocumento.Rows(e.RowIndex).Cells(2).Value.Equals("ARECEBER") Then
            dtgTipoDocumento.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkGreen
        Else
            dtgTipoDocumento.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkRed
        End If
    End Sub
End Class