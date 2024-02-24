Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class FrmCadFornecedor

    'Objetos:
    Dim fornecedor As New ClFornecedor
    Dim fornecedorDAO As New ClFornecedorDAO
    Dim _funcoes As New ClFuncoes

    Dim _despProduto As New ClDespesaProduto
    Dim _despProdutoDAO As New ClDespesaProdutoDAO

    'Variaveis:
    Dim tipoOperacao As String = "I"
    Dim _somaPorcentagemDtg As Double = 0.0

    Private Sub FrmCadFornecedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DesabilitaCampos()
        ExecutaF5()
    End Sub

    Private Sub FrmCadFornecedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmCadFornecedor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                ExecutaF2()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
        End Select
    End Sub

#Region "Funcoes"

    Sub ZeraValores()
        Me.txtNomeFornecedor.Text = "" : Me.mskTelefoneForn.Text = "" : Me.txtCidadeForn.Text = ""
        Me.txtEnderecoForn.Text = "" : Me.txtEstadoForn.Text = "" : Me.mskCnpjCpf.Text = ""
        Me.txtEstadoForn.Text = mdlPadraoSistema.psestado : Me.txtCidadeForn.Text = mdlPadraoSistema.pscidade
    End Sub

    Sub DesabilitaCampos()
        Me.txtNomeFornecedor.ReadOnly = True : Me.mskTelefoneForn.ReadOnly = True : Me.mskCnpjCpf.ReadOnly = True
        Me.txtEnderecoForn.ReadOnly = True : Me.txtCidadeForn.ReadOnly = True : Me.txtEstadoForn.ReadOnly = True
        Me.rbCnpj.Enabled = False : Me.rbCpf.Enabled = False
        Me.btnSalvar.Enabled = False : Me.btnCancelar.Enabled = False
        ZeraValores()
    End Sub

    Sub HabilitaCampos()
        Me.txtNomeFornecedor.ReadOnly = False : Me.mskTelefoneForn.ReadOnly = False : Me.mskCnpjCpf.ReadOnly = False
        Me.txtEnderecoForn.ReadOnly = False : Me.txtCidadeForn.ReadOnly = False : Me.txtEstadoForn.ReadOnly = False
        Me.btnSalvar.Enabled = True : Me.btnCancelar.Enabled = True
        Me.rbCnpj.Enabled = True : Me.rbCpf.Enabled = True
    End Sub

    Private Sub preencheDtgFornecedores()

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "SYSDELIVERY")
            Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader


        Try

            sql.Append("SELECT fid, fnome, ftelefone, fendereco, fcidade FROM fornecedor ")
            sql.Append("WHERE fnome LIKE @fnome ORDER BY fnome ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            cmd.Parameters.Add("@fnome", Me.txt_pesquisa.Text & "%")
            dr = cmd.ExecuteReader

            dtg_fornecedores.Rows.Clear()
            If dr.HasRows = False Then Return
            Dim mTelefone As String = ""
            While dr.Read
                dtg_fornecedores.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString(), dr(4).ToString)
            End While

            dtg_fornecedores.Refresh() : dr.Close()
            oConn.ClearPool() : oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos FORNECEDORES:: " & ex.Message, MsgBoxStyle.Exclamation, "SYSDELIVERY")
            Return

        End Try

        txt_qtdRegistros.Text = dtg_fornecedores.Rows.Count
        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing



    End Sub

    Sub PreencheValoresCampos()

        txtIdForn.Text = fornecedor.pId
        txtNomeFornecedor.Text = fornecedor.pNome
        mskTelefoneForn.Text = fornecedor.pfTelefone
        txtCidadeForn.Text = fornecedor.pCidade
        txtEstadoForn.Text = fornecedor.pEstado
        txtEnderecoForn.Text = fornecedor.pEndereco
        If Not fornecedor.pfCnpj.Equals("") Then
            rbCnpj.Checked = True
            mskCnpjCpf.Text = fornecedor.pfCnpj
        ElseIf Not fornecedor.pfCpf.Equals("") Then
            rbCpf.Checked = True
            mskCnpjCpf.Text = fornecedor.pfCpf
        End If

    End Sub

    Sub PreencheFornecedorValores()

        If IsNumeric(txtIdForn.Text) Then fornecedor.pId = CInt(txtIdForn.Text)
        fornecedor.pNome = txtNomeFornecedor.Text
        fornecedor.pfTelefone = mskTelefoneForn.Text
        fornecedor.pCidade = txtCidadeForn.Text
        fornecedor.pEstado = txtEstadoForn.Text
        fornecedor.pEndereco = txtEnderecoForn.Text
        If rbCnpj.Checked Then fornecedor.pfCpf = "" : fornecedor.pfCnpj = mskCnpjCpf.Text.Replace(",", ".")
        If rbCpf.Checked Then fornecedor.pfCnpj = "" : fornecedor.pfCpf = mskCnpjCpf.Text.Replace(",", ".")

    End Sub

    Sub ExecutaF5()
        preencheDtgFornecedores()
    End Sub

    Sub ExecutaF2()
        ZeraValores()
        HabilitaCampos()
        txtNomeFornecedor.Focus()
        tipoOperacao = "I"
    End Sub

    Sub ExecutaF3()

        If dtg_fornecedores.CurrentRow.IsNewRow = False Then
            fornecedor.pId = CInt(dtg_fornecedores.CurrentRow.Cells(0).Value)
            fornecedorDAO.TrazFornecedorDoBD(fornecedor, MdlConexaoBD.conectionPadrao)
            PreencheValoresCampos()
            HabilitaCampos()
            txtNomeFornecedor.Focus()
            tipoOperacao = "A"
        End If

    End Sub

    Sub ExecutaDel()
        tipoOperacao = ""
        If dtg_fornecedores.CurrentRow.IsNewRow = False Then
            fornecedor.pId = CInt(dtg_fornecedores.CurrentRow.Cells(0).Value)
            'produtoDAO.delProduto(produto
        End If

        Try

            If dtg_fornecedores.CurrentRow.IsNewRow = False Then

                If MessageBox.Show("Deseja Realmente Deletar esse FORNECEDOR ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    ZeraValores() : DesabilitaCampos() : fornecedor.ZeraValores()
                    fornecedor.pId = CInt(dtg_fornecedores.CurrentRow.Cells(0).Value)


                    Dim transacao As NpgsqlTransaction
                    Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

                    Try

                        Try
                            conection.Open()
                        Catch ex As Exception
                            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "SYSDELIVERY")
                            Return
                        End Try

                        transacao = conection.BeginTransaction
                        fornecedorDAO.delFornecedor(fornecedor, conection, transacao)
                        transacao.Commit() : conection.ClearPool() : conection.Close()
                        ExecutaF5()
                        MsgBox("FORNECEDOR Deletado com Sucesso!", MsgBoxStyle.Exclamation)
                        fornecedorDAO.TrazListFornecedores(MdlConexaoBD.mdlListFornecedores, MdlConexaoBD.conectionPadrao)
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

            End If
        Catch ex As Exception
        End Try

    End Sub
#End Region


    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        ExecutaF2()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        tipoOperacao = ""
        ZeraValores()
        DesabilitaCampos()
        txt_pesquisa.Focus()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        Try
            fornecedor.pId = Me.txtIdForn.Text
        Catch ex As Exception
            fornecedor.pId = 0
        End Try

        'Dados principais:
        fornecedor.pNome = Me.txtNomeFornecedor.Text
        fornecedor.pEndereco = Me.txtEnderecoForn.Text

        If tipoOperacao.Equals("I") Then
            If fornecedorDAO.ValidaFornecedor(fornecedor) = False Then Return
        Else
            If fornecedorDAO.ValidaFornecedor(fornecedor, "A") = False Then Return
        End If

        PreencheFornecedorValores()

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If tipoOperacao.Equals("I") Then

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                fornecedorDAO.incFornecedor(fornecedor, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                fornecedorDAO.altFornecedor(fornecedor, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("FORNECEDOR Salvo com Sucesso!", MsgBoxStyle.Exclamation)
            fornecedorDAO.TrazListFornecedores(MdlConexaoBD.mdlListFornecedores, MdlConexaoBD.conectionPadrao)
            ZeraValores()
            DesabilitaCampos()
            fornecedor.ZeraValores()
            ExecutaF5() : txt_pesquisa.Focus()
            DesabilitaCampos() : ZeraValores()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try
    End Sub

    Private Sub dtg_produtos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_fornecedores.CellDoubleClick

        If dtg_fornecedores.CurrentRow.IsNewRow = False Then
            fornecedor.pId = CInt(dtg_fornecedores.CurrentRow.Cells(0).Value)
            fornecedorDAO.TrazFornecedorDoBD(fornecedor, MdlConexaoBD.conectionPadrao)
            PreencheValoresCampos()
        End If
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        ExecutaF3()
    End Sub

    Private Sub txt_pesquisa_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_pesquisa.KeyDown
        If Keys.Enter Then preencheDtgFornecedores()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        ExecutaDel()
    End Sub

    Private Sub txtCamposValores_KeyPress(sender As Object, e As KeyPressEventArgs)
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub mskCnpjCpf_Focus(sender As Object, e As EventArgs) Handles mskCnpjCpf.GotFocus
        Me.mskCnpjCpf.SelectAll()
    End Sub

    Private Sub rbCnpj_CheckedChanged(sender As Object, e As EventArgs) Handles rbCpf.CheckedChanged, rbCnpj.CheckedChanged
        mudarFormatRDB()
    End Sub

    Sub mudarFormatRDB()
        Me.mskCnpjCpf.Text = ""
        If rbCnpj.Checked Then
            Me.mskCnpjCpf.Mask = "99.999.999/9999-99"
            Me.mskCnpjCpf.Focus() : Me.mskCnpjCpf.SelectAll()
        ElseIf rbCpf.Checked Then
            Me.mskCnpjCpf.Mask = "999.999.999-99"
            Me.mskCnpjCpf.Focus() : Me.mskCnpjCpf.SelectAll()
        End If
    End Sub

End Class