Imports Npgsql
Imports System.Text
Public Class FrmCadCliente

    'Objetos:
    Dim Cliente As New ClCliente
    Dim _ListaClientes As New List(Of ClCliente)
    Dim _ListaClientesRelatorio As New List(Of ClCliente)
    Dim ClienteDAO As New ClClienteDAO
    Dim _funcoes As New ClFuncoes
    Dim _ruaDAO As New ClRuaDAO
    Dim _Rua As New ClRua
    Dim _Bairro As New ClBairro
    Dim _BairroDAO As New ClBairroDAO
    Dim _DaoMunincipio As New ClMunicipioDAO


    'Variaveis:
    Dim _ufCorrenteCbo As String = ""
    Dim tipoOperacao As String = "I"
    Dim _somaPorcentagemDtg As Double = 0.0

    Private Sub FrmCadCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If MdlConexaoBD.sincronizado Then
            preencheDtgClientesLista()
            Return
        End If
        _clFunc.preenchComboBoxUF(cbo_uf)
        _clFunc.preenchComboBoxUFPesquisa(cboUfPesq)
        cboUfPesq.SelectedIndex = 0
        _ruaDAO.PreencheCboRuasLista(cboRuaCli, MdlConexaoBD.mdlListRuas)
        _BairroDAO.PreencheCboBairrosLista(cboBairroCli, MdlConexaoBD.mdlListBairros)
        DesabilitaCampos()
        ExecutaF5()

    End Sub

    Private Sub FrmCadCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmCadCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F2
                ExecutaF2()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
            Case Keys.F11
                executaF11()
        End Select
    End Sub

#Region "Funcoes"

    Sub executaF11()

        _ListaClientes.Clear()
        If MdlConexaoBD.sincronizado Then
            ClienteDAO.TrazListClientes_LISTA(_ListaClientes, MdlConexaoBD.ListaClientes)
        Else
            ClienteDAO.TrazListClientes_BD(_ListaClientes, MdlConexaoBD.conectionPadrao)
        End If


        If Trim(txt_pesquisa.Text).Equals("") Then
            _ListaClientesRelatorio = _ListaClientes.FindAll(Function(c As ClCliente) c.cinativo = chkInativos.Checked)
        Else
            _ListaClientesRelatorio = _ListaClientes.FindAll(Function(c As ClCliente) c.cnome.StartsWith(Trim(txt_pesquisa.Text)) And _
                                                                                    c.cinativo = chkInativos.Checked)
        End If

        If cboUfPesq.SelectedIndex > 0 Then
            _ListaClientesRelatorio = _ListaClientesRelatorio.FindAll(Function(c As ClCliente) c.cestado.Equals(cboUfPesq.SelectedItem.ToString))
        End If

        If Not cboCidadePesq.Text.Equals("") Then
            _ListaClientesRelatorio = _ListaClientesRelatorio.FindAll(Function(c As ClCliente) c.ccidade.StartsWith(cboCidadePesq.Text))
        End If

        If _ListaClientesRelatorio.Count > 0 Then
            Dim frmRelatoriClientes As New FormListaClientes
            frmRelatoriClientes._ListaClientes = _ListaClientesRelatorio
            frmRelatoriClientes._FiltroCliente = txt_pesquisa.Text
            frmRelatoriClientes._FiltroINATIVOS = ""
            If chkInativos.Checked Then frmRelatoriClientes._FiltroINATIVOS = "INATIVOS"
            frmRelatoriClientes._FiltroUF = cboUfPesq.Text
            frmRelatoriClientes._FiltroCIDADE = cboCidadePesq.Text
            frmRelatoriClientes.ShowDialog()
            frmRelatoriClientes = Nothing
        End If

    End Sub

    Sub ZeraValoresCamposFormulario()
        Me.txtNomeCliente.Text = "" : Me.mskTelefoneCli.Text = "" : Me.cbo_cidade.SelectedIndex = -1
        Me.cboRuaCli.Text = "" : Me.cboBairroCli.Text = ""
        Me.cboBairroCli.SelectedIndex = -1 : Me.cboRuaCli.SelectedIndex = -1 : Me.cbo_uf.SelectedIndex = -1
        Me.mskDiaMes.Text = "" : Me.mskCep.Text = "" : Me.txtEmail.Text = "" : Me.mskCnpjCpf.Text = ""
        Me.cbo_uf.Text = _clFunc.trazIndexCboTextoTodo(MdlConexaoBD.mdlPadraoSistema.psestado, Me.cbo_uf)
        Me.txtObservacao.Text = "" : Me.txt_codmun.Text = ""

        'Ótica:
        Me.txtCliApelido.Text = "" : Me.txtCliRG.Text = "" : Me.txtCliOF.Text = ""
        Me.txtCliPAI.Text = "" : Me.txtCliMAE.Text = "" : Me.txtCliLocalTrabalho.Text = ""
        Me.txtCliFuncTrabalho.Text = "" : Me.txtCliNomeConjugue.Text = "" : Me.txtCliApelidoCONJUGUE.Text = ""
    End Sub

    Sub DesabilitaCampos()
        Me.txtNomeCliente.ReadOnly = True : Me.mskTelefoneCli.ReadOnly = True
        Me.cboBairroCli.SelectedIndex = -1 : Me.cboRuaCli.SelectedIndex = -1 : Me.cboBairroCli.Enabled = False
        Me.cboRuaCli.Enabled = False : Me.cbo_uf.Enabled = False : Me.cbo_cidade.Enabled = False
        Me.btnSalvar.Enabled = False : Me.btnCancelar.Enabled = False : Me.mskDiaMes.ReadOnly = True
        Me.mskCnpjCpf.ReadOnly = True : Me.mskCep.ReadOnly = True : Me.txtEmail.ReadOnly = True
        Me.txtObservacao.ReadOnly = True

        'Ótica:
        Me.txtCliApelido.ReadOnly = True : Me.txtCliRG.ReadOnly = True : Me.txtCliOF.ReadOnly = True
        Me.txtCliPAI.ReadOnly = True : Me.txtCliMAE.ReadOnly = True : Me.txtCliLocalTrabalho.ReadOnly = True
        Me.txtCliFuncTrabalho.ReadOnly = True : Me.txtCliNomeConjugue.ReadOnly = True : Me.txtCliApelidoCONJUGUE.ReadOnly = True

        ZeraValoresCamposFormulario()
    End Sub

    Sub HabilitaCampos()
        Me.txtNomeCliente.ReadOnly = False : Me.mskTelefoneCli.ReadOnly = False : Me.mskDiaMes.ReadOnly = False
        Me.cboRuaCli.Enabled = True : Me.cbo_uf.Enabled = True : Me.cbo_cidade.Enabled = True
        Me.btnSalvar.Enabled = True : Me.btnCancelar.Enabled = True : Me.cboBairroCli.Enabled = True
        Me.mskCnpjCpf.ReadOnly = False : Me.mskCep.ReadOnly = False : Me.txtEmail.ReadOnly = False
        Me.txtObservacao.ReadOnly = False
        Me.cboBairroCli.SelectedIndex = -1 : Me.cboRuaCli.SelectedIndex = -1

        'Ótica:
        Me.txtCliApelido.ReadOnly = False : Me.txtCliRG.ReadOnly = False : Me.txtCliOF.ReadOnly = False
        Me.txtCliPAI.ReadOnly = False : Me.txtCliMAE.ReadOnly = False : Me.txtCliLocalTrabalho.ReadOnly = False
        Me.txtCliFuncTrabalho.ReadOnly = False : Me.txtCliNomeConjugue.ReadOnly = False : Me.txtCliApelidoCONJUGUE.ReadOnly = False

    End Sub

    Private Sub preencheDtgClientes()

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
            Return

        End Try

        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader
        Dim diaMes As String = _clFunc.RemoverCaracter2(txtDataPessoaPesq.Text)

        Try

            sql.Append("SELECT cid, cnome, ctelefone, cendereco, ccidade, cestado FROM Cliente ")
            If chkInativos.Checked Then
                sql.Append("WHERE cinativo = true ")
            Else
                sql.Append("WHERE cinativo = false ")
            End If

            sql.Append("AND cnome LIKE @cnome ")
            If cboUfPesq.SelectedIndex > 0 Then
                sql.Append("AND cestado LIKE @uf ")
            End If

            If txtCpfCnpjPessoaPesq.Text.Equals("") = False Then
                sql.Append("AND ccpf LIKE '%" & txtCpfCnpjPessoaPesq.Text & "%' ")
            End If

            If diaMes.Equals("") = False Then
                sql.Append("AND cdiames LIKE '%" & txtDataPessoaPesq.Text & "%' ")
            End If

            sql.Append("AND ccidade LIKE @cidade ")
            sql.Append("ORDER BY cnome ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            cmd.Parameters.Add("@cnome", Me.txt_pesquisa.Text & "%")
            If cboUfPesq.SelectedIndex > 0 Then cmd.Parameters.Add("@uf", cboUfPesq.SelectedItem.ToString)
            If cboCidadePesq.SelectedIndex >= 0 Then
                cmd.Parameters.Add("@cidade", cboCidadePesq.Text)
            Else
                cmd.Parameters.Add("@cidade", "%")
            End If
            dr = cmd.ExecuteReader

            dtg_clientes.Rows.Clear()
            If dr.HasRows = False Then Return
            Dim mTelefone As String = ""
            While dr.Read
                dtg_clientes.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString(), dr(4).ToString, dr(5).ToString)
            End While

            dtg_clientes.Refresh() : dr.Close()
            oConn.ClearPool() : oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT dos Clientes:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
            Return

        End Try

        txt_qtdRegistros.Text = dtg_clientes.Rows.Count
        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing

        'dtg_clientes.Rows.Clear()
        'For Each cl As ClCliente In MdlConexaoBD.mdlListClientes
        '    dtg_clientes.Rows.Add(cl.cid, cl.cnome, cl.ctelefone, cl.cendereco, cl.ccidade, cl.cestado)
        'Next
        'txt_qtdRegistros.Text = dtg_clientes.Rows.Count

    End Sub

    Private Sub preencheDtgClientesLista()

        _ListaClientes.Clear()
        If MdlConexaoBD.sincronizado Then
            ClienteDAO.TrazListClientes_LISTA(_ListaClientes, MdlConexaoBD.ListaClientes)
        Else
            ClienteDAO.TrazListClientes_BD(_ListaClientes, MdlConexaoBD.conectionPadrao)
        End If

        Dim diaMes As String = _clFunc.RemoverCaracter2(txtDataPessoaPesq.Text)


        If Trim(txt_pesquisa.Text).Equals("") Then
            _ListaClientesRelatorio = _ListaClientes.FindAll(Function(c As ClCliente) c.cinativo = chkInativos.Checked)
        Else
            _ListaClientesRelatorio = _ListaClientes.FindAll(Function(c As ClCliente) c.cnome.StartsWith(Trim(txt_pesquisa.Text)) And _
                                                                                    c.cinativo = chkInativos.Checked)
        End If

        If cboUfPesq.SelectedIndex > 0 Then
            _ListaClientesRelatorio = _ListaClientesRelatorio.FindAll(Function(c As ClCliente) c.cestado.Equals(cboUfPesq.SelectedItem.ToString))
        End If

        If txtCpfCnpjPessoaPesq.Text.Equals("") = False Then
            _ListaClientesRelatorio = _ListaClientesRelatorio.FindAll(Function(c As ClCliente) c.cCpfCnpj.Equals(txtCpfCnpjPessoaPesq.Text))
        End If

        If diaMes.Equals("") = False Then
            _ListaClientesRelatorio = _ListaClientesRelatorio.FindAll(Function(c As ClCliente) c.cdiames.Equals(txtDataPessoaPesq.Text))
        End If

        If Not cboCidadePesq.Text.Equals("") Then
            _ListaClientesRelatorio = _ListaClientesRelatorio.FindAll(Function(c As ClCliente) c.ccidade.StartsWith(cboCidadePesq.Text))
        End If

        dtg_clientes.Rows.Clear()
        For Each cli As ClCliente In _ListaClientesRelatorio

            dtg_clientes.Rows.Add(cli.cid, cli.cnome, cli.ctelefone, cli.cendereco, cli.ccidade, cli.cestado)
        Next

        txt_qtdRegistros.Text = dtg_clientes.Rows.Count

    End Sub

    Sub PreencheValoresCampos()

        txtId.Text = Cliente.cid
        txtNomeCliente.Text = Cliente.cnome
        mskTelefoneCli.Text = Cliente.ctelefone

        Me.cbo_uf.SelectedIndex = _clFunc.trazIndexCboTextoTodo(Cliente.cestado, Me.cbo_uf)
        If cbo_uf.SelectedIndex >= 0 Then

            Me.cbo_cidade = _DaoMunincipio.PreenchComboMunicipiosBD(Me.cbo_uf.Text, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            cbo_cidade.Text = Cliente.ccidade
            'cbo_cidade.SelectedIndex = _funcoes.trazIndexCboTextoTodo(Cliente.ccidade, cbo_cidade)
            _ufCorrenteCbo = cbo_uf.Text

        End If
        txt_codmun.Text = Cliente.cidadecodigo
        cboRuaCli.Text = Cliente.cendereco
        cboBairroCli.Text = Cliente.cbairro
        mskDiaMes.Text = Cliente.cdiames
        mskCep.Text = Cliente.ccep
        If Cliente.tipo.Equals("F") Then rbCpf.Checked = True
        If Cliente.tipo.Equals("J") Then rbCnpj.Checked = True
        mskCnpjCpf.Text = Cliente.cCpfCnpj
        txtEmail.Text = Cliente.cemail
        txtObservacao.Text = Cliente.observacao


        'Ótica:
        Me.txtCliApelido.Text = Cliente.cliApelido : Me.txtCliRG.Text = Cliente.cliRG : Me.txtCliOF.Text = Cliente.cliOF
        Me.txtCliPAI.Text = Cliente.cliPai : Me.txtCliMAE.Text = Cliente.cliMae : Me.txtCliLocalTrabalho.Text = Cliente.cliLocalTrabalho
        Me.txtCliFuncTrabalho.Text = Cliente.cliFuncaoTrabalho : Me.txtCliNomeConjugue.Text = Cliente.cliNomeConjugue
        Me.txtCliApelidoCONJUGUE.Text = Cliente.cliApelidoConjugue

    End Sub

    Sub PreencheValoresCamposVisualizacao()

        DesabilitaCampos()
        txtId.Text = Cliente.cid
        txtNomeCliente.Text = Cliente.cnome
        mskTelefoneCli.Text = Cliente.ctelefone
        Me.cbo_uf.Text = Cliente.cestado
        Me.cbo_cidade.Text = Cliente.ccidade
        txt_codmun.Text = Cliente.cidadecodigo
        cboRuaCli.Text = Cliente.cendereco
        cboBairroCli.Text = Cliente.cbairro
        mskDiaMes.Text = Cliente.cdiames
        mskCep.Text = Cliente.ccep
        If Cliente.tipo.Equals("F") Then rbCpf.Checked = True
        If Cliente.tipo.Equals("J") Then rbCnpj.Checked = True
        mskCnpjCpf.Text = Cliente.cCpfCnpj
        txtEmail.Text = Cliente.cemail
        txtObservacao.Text = Cliente.observacao

        'Ótica:
        Me.txtCliApelido.Text = Cliente.cliApelido : Me.txtCliRG.Text = Cliente.cliRG : Me.txtCliOF.Text = Cliente.cliOF
        Me.txtCliPAI.Text = Cliente.cliPai : Me.txtCliMAE.Text = Cliente.cliMae : Me.txtCliLocalTrabalho.Text = Cliente.cliLocalTrabalho
        Me.txtCliFuncTrabalho.Text = Cliente.cliFuncaoTrabalho : Me.txtCliNomeConjugue.Text = Cliente.cliNomeConjugue
        Me.txtCliApelidoCONJUGUE.Text = Cliente.cliApelidoConjugue

    End Sub

    Sub PreencheClienteValores()

        If IsNumeric(txtId.Text) Then Cliente.cid = CInt(txtId.Text)
        Cliente.cnome = txtNomeCliente.Text
        Cliente.ctelefone = _funcoes.RemoverCaracter2(mskTelefoneCli.Text)
        Try
            Cliente.ccidade = cbo_cidade.SelectedItem.ToString
        Catch ex As Exception
            Cliente.ccidade = ""
        End Try

        Try
            Cliente.cestado = cbo_uf.SelectedItem.ToString
        Catch ex As Exception
            Cliente.cestado = ""
        End Try
        
        Cliente.cidadecodigo = txt_codmun.Text
        Cliente.cendereco = cboRuaCli.Text
        Cliente.cbairro = cboBairroCli.Text
        Cliente.cdiames = mskDiaMes.Text
        Cliente.ccep = _funcoes.RemoverCaracter2(mskCep.Text)
        Cliente.cCpfCnpj = Trim(_funcoes.RemoverCaracter2(mskCnpjCpf.Text))
        Cliente.cemail = txtEmail.Text
        Cliente.observacao = txtObservacao.Text
        If rbCnpj.Checked Then Cliente.tipo = "J"
        If rbCpf.Checked Then Cliente.tipo = "F"

        'Ótica:
        Cliente.cliApelido = Me.txtCliApelido.Text : Cliente.cliRG = Me.txtCliRG.Text : Cliente.cliOF = Me.txtCliOF.Text
        Cliente.cliPai = Me.txtCliPAI.Text : Cliente.cliMae = Me.txtCliMAE.Text : Cliente.cliLocalTrabalho = Me.txtCliLocalTrabalho.Text
        Cliente.cliFuncaoTrabalho = Me.txtCliFuncTrabalho.Text : Cliente.cliNomeConjugue = Me.txtCliNomeConjugue.Text
        Cliente.cliApelidoConjugue = Me.txtCliApelidoCONJUGUE.Text

    End Sub

    Sub ExecutaF5()

        If MdlConexaoBD.sincronizado Then
            preencheDtgClientesLista()
        Else
            preencheDtgClientes()
        End If

    End Sub

    Sub ExecutaSaudePessoa()

        If Cliente.cid <= 0 Then
            MsgBox("Selecione um Cliente para Prosseguir!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Dim Formulario As New FormInfoSaudePessoa
        Formulario._Cliente.SetaValores(Cliente)
        Formulario.ShowDialog()
    End Sub

    Sub ExecutaF2()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        btnInfoSaudePessoa.Enabled = False
        ZeraValoresCamposFormulario()
        HabilitaCampos()
        txtNomeCliente.Focus()
        tipoOperacao = "I"
    End Sub

    Sub ExecutaF3()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        btnInfoSaudePessoa.Enabled = True
        If dtg_clientes.CurrentRow.IsNewRow = False Then

            Dim mID As Int64 = CInt(dtg_clientes.CurrentRow.Cells(0).Value)
            Cliente.ZeraValores()
            Cliente = New ClCliente(MdlConexaoBD.ListaClientes.Find(Function(c As ClCliente) c.cid = mID))
            HabilitaCampos()
            PreencheValoresCampos()
            txtNomeCliente.Focus()
            tipoOperacao = "A"
        End If

    End Sub

    Sub ExecutaDel()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        tipoOperacao = ""
        If dtg_clientes.CurrentRow.IsNewRow = False Then
            Cliente.cid = CInt(dtg_clientes.CurrentRow.Cells(0).Value)
        End If
        Dim mMsg As String = ""

        Try

            If dtg_clientes.CurrentRow.IsNewRow = False Then

                Cliente.cid = CInt(dtg_clientes.CurrentRow.Cells(0).Value)
                ClienteDAO.TrazCliente(Cliente, MdlConexaoBD.conectionPadrao)
                If Cliente.cinativo Then
                    mMsg = "Deseja Realmente DELETAR esse Cliente ?"
                Else
                    mMsg = "Deseja Realmente DESATIVAR esse Cliente ?"
                End If
                If MessageBox.Show(mMsg, Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    ZeraValoresCamposFormulario() : DesabilitaCampos()


                    Dim transacao As NpgsqlTransaction
                    Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

                    Try

                        Try
                            conection.Open()
                        Catch ex As Exception
                            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
                            Return
                        End Try

                        transacao = conection.BeginTransaction
                        If Cliente.cinativo Then
                            ClienteDAO.delCliente(Cliente, conection, transacao)
                        Else
                            ClienteDAO.InativaCliente(Cliente, conection, transacao)
                        End If

                        transacao.Commit() : conection.ClearPool() : conection.Close()

                        If Cliente.cinativo Then
                            mMsg = "Cliente DELETADO com Sucesso!"
                        Else
                            mMsg = "Cliente DESTIVADO com Sucesso!"
                        End If

                        MsgBox(mMsg, MsgBoxStyle.Exclamation)
                        ClienteDAO.TrazListClientes_BD(MdlConexaoBD.ListaClientes, MdlConexaoBD.conectionPadrao)
                        ExecutaF5()
                        Cliente.ZeraValores()

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

    Private Sub btn_novo_Click(sender As Object, e As EventArgs) Handles btn_novo.Click
        ExecutaF2()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        tipoOperacao = ""
        ZeraValoresCamposFormulario()
        DesabilitaCampos()
        txt_pesquisa.Focus()
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        Try
            Cliente.cid = Me.txtId.Text
        Catch ex As Exception
            Cliente.cid = 0
        End Try

        'Dados principais:
        PreencheClienteValores()

        If tipoOperacao.Equals("I") Then
            If ClienteDAO.ValidaCliente(Cliente) = False Then Return
        Else
            If ClienteDAO.ValidaCliente(Cliente, "A") = False Then Return
        End If



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
                ClienteDAO.incCliente(Cliente, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                ClienteDAO.altCliente(Cliente, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Cliente Salvo com Sucesso!", MsgBoxStyle.Exclamation)
            ClienteDAO.TrazListClientes_BD(MdlConexaoBD.ListaClientes, MdlConexaoBD.conectionPadrao)
            ZeraValoresCamposFormulario()
            DesabilitaCampos()
            Cliente.ZeraValores()
            ExecutaF5() : txt_pesquisa.Focus()
            DesabilitaCampos() : ZeraValoresCamposFormulario()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        ExecutaF3()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        ExecutaDel()
    End Sub

    Private Sub txtCamposNumeros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskTelefoneCli.KeyPress, mskDiaMes.KeyPress, mskCnpjCpf.KeyPress, mskCep.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub chkInativos_CheckedChanged(sender As Object, e As EventArgs) Handles chkInativos.CheckedChanged
        ExecutaF5()
    End Sub

    Private Sub mskCep_GotFocus(sender As Object, e As EventArgs) Handles mskCep.GotFocus
        mskCep.SelectAll()
    End Sub

    Private Sub mskCPF_GotFocus(sender As Object, e As EventArgs) Handles mskCnpjCpf.GotFocus
        mskCnpjCpf.SelectAll()
    End Sub

    Private Sub mskTelefoneCli_GotFocus(sender As Object, e As EventArgs) Handles mskTelefoneCli.GotFocus
        mskTelefoneCli.SelectAll()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

    Private Sub cbo_uf_Leave(sender As Object, e As EventArgs) Handles cbo_uf.Leave

        If _ufCorrenteCbo.Equals("") Then

            If cbo_uf.SelectedIndex >= 0 Then

                Me.cbo_cidade = _DaoMunincipio.PreenchComboMunicipiosBD(Me.cbo_uf.SelectedItem, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
                _ufCorrenteCbo = Me.cbo_uf.SelectedItem

            End If
        ElseIf cbo_uf.SelectedIndex > 0 And Not _ufCorrenteCbo.Equals(cbo_uf.Text) Then

            Me.cbo_cidade = _DaoMunincipio.PreenchComboMunicipiosBD(Me.cbo_uf.SelectedItem, Me.cbo_cidade, MdlConexaoBD.conectionPadrao)
            _ufCorrenteCbo = Me.cbo_uf.SelectedItem

        End If

    End Sub

    Private Sub cbo_cidade_KeyDown(sender As Object, e As KeyEventArgs) Handles cbo_cidade.KeyDown

        Try
            If cbo_cidade.SelectedIndex > -1 Then
                enviaTecla(sender, e, "TAB")
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub enviaTecla(ByRef sender As Object, ByRef e As System.Windows.Forms.KeyEventArgs, ByVal tecla As String)

        If e.KeyCode = Keys.Enter Then
            e.Handled = True : SendKeys.Send("{" & tecla.ToUpper & "}")
        End If

    End Sub

    Private Sub cbo_cidade_Leave(sender As Object, e As EventArgs) Handles cbo_cidade.Leave

        Me.txt_codmun.Text = _DaoMunincipio.trazCodMunDaLISTA(MdlConexaoBD.mdlListCidades, Me.cbo_uf.SelectedItem, Me.cbo_cidade.SelectedItem)

    End Sub

    Private Sub cboUfPesq_Leave(sender As Object, e As EventArgs) Handles cboUfPesq.Leave


        If cboUfPesq.SelectedIndex > 0 Then
            Me.cboCidadePesq = _DaoMunincipio.PreenchComboMunicipiosBD(Me.cboUfPesq.SelectedItem, Me.cboCidadePesq, MdlConexaoBD.conectionPadrao)
            cboCidadePesq.SelectedIndex = -1
        Else
            cboCidadePesq.Items.Clear()
            cboCidadePesq.SelectedIndex = -1
        End If

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        ExecutaF5()
    End Sub

    Private Sub dtg_clientes_DoubleClick(sender As Object, e As EventArgs) Handles dtg_clientes.DoubleClick

        If dtg_clientes.CurrentRow.IsNewRow = False Then

            Dim mID As Int64 = CInt(dtg_clientes.CurrentRow.Cells(0).Value)
            Cliente.ZeraValores()
            Cliente = New ClCliente(MdlConexaoBD.ListaClientes.Find(Function(c As ClCliente) c.cid = mID))
            tipoOperacao = "V"
            PreencheValoresCamposVisualizacao()
            btnInfoSaudePessoa.Enabled = True

        End If

    End Sub

    Private Sub btnInfoSaudePessoa_Click(sender As Object, e As EventArgs) Handles btnInfoSaudePessoa.Click

        ExecutaSaudePessoa()
    End Sub

    Private Sub txtDataPessoaPesq_Click(sender As Object, e As EventArgs) Handles txtDataPessoaPesq.Click
        txtDataPessoaPesq.SelectAll()
    End Sub

    Private Sub txtCpfCnpjPessoaPesq_GotFocus(sender As Object, e As EventArgs) Handles txtCpfCnpjPessoaPesq.GotFocus
        txtCpfCnpjPessoaPesq.SelectAll()
    End Sub

    Private Sub cboRuaCli_KeyDown(sender As Object, e As KeyEventArgs) Handles cboRuaCli.KeyDown

        If cboRuaCli.AutoCompleteMode = AutoCompleteMode.None Then

            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If

        'If Not cboRuaCli.Text.Equals("") Then cboRuaCli.Text = cboRuaCli.Text.ToUpper()
    End Sub

    Private Sub cboBairroCli_KeyDown(sender As Object, e As KeyEventArgs) Handles cboBairroCli.KeyDown

        If cboRuaCli.AutoCompleteMode = AutoCompleteMode.None Then

            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End If

        ' If Not cboBairroCli.Text.Equals("") Then cboBairroCli.Text = cboBairroCli.Text.ToUpper()
    End Sub

   
    Private Sub cboBairroCli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboBairroCli.KeyPress, cboRuaCli.KeyPress

        If Char.IsLetter(e.KeyChar) Then e.KeyChar = Char.ToUpper(e.KeyChar)

    End Sub
End Class