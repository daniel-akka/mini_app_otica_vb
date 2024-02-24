Imports Npgsql
Imports System.Text
Public Class FrmCadEmpresa

    'Objetos:
    Dim _Empresa As New ClEmpresa
    Dim _EmpresaDAO As New ClEmpresaDAO
    Dim _funcoes As New ClFuncoes
    Dim _ruaDAO As New ClRuaDAO
    Dim _Rua As New ClRua
    Dim _Bairro As New ClBairro
    Dim _BairroDAO As New ClBairroDAO


    'Variaveis:
    Dim tipoOperacao As String = "I"
    Dim _somaPorcentagemDtg As Double = 0.0

    Private Sub FrmCadEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text += " - " & Application.CompanyName
        _ruaDAO.PreencheCboRuasLista(cboRua, MdlConexaoBD.mdlListRuas)
        _BairroDAO.PreencheCboBairrosLista(cboBairro, MdlConexaoBD.mdlListBairros)
        DesabilitaCampos()
        ExecutaF5()
    End Sub

    Private Sub FrmCadEmpresa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmCadEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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
        Me.txtRazao.Text = "" : Me.txtFantasia.Text = "" : Me.mskTelefone.Text = "" : Me.txtCidade.Text = ""
        Me.cboBairro.SelectedIndex = -1 : Me.cboRua.SelectedIndex = -1 : Me.txtEstado.Text = ""
        Me.txtEstado.Text = mdlPadraoSistema.psestado : Me.txtCidade.Text = mdlPadraoSistema.pscidade
        mskCnpjCpf.Text = ""
    End Sub

    Sub DesabilitaCampos()
        Me.txtRazao.ReadOnly = True : Me.txtFantasia.ReadOnly = True : Me.mskTelefone.ReadOnly = True
        Me.cboBairro.SelectedIndex = -1 : Me.cboRua.SelectedIndex = -1 : Me.cboBairro.Enabled = False
        Me.cboRua.Enabled = False : Me.txtCidade.ReadOnly = True : Me.txtEstado.ReadOnly = True
        Me.btnSalvar.Enabled = False : Me.btnCancelar.Enabled = False
        mskCnpjCpf.ReadOnly = True

        ZeraValores()
    End Sub

    Sub HabilitaCampos()
        Me.txtRazao.ReadOnly = False : Me.txtFantasia.ReadOnly = False : Me.mskTelefone.ReadOnly = False
        Me.cboRua.Enabled = True : Me.txtCidade.ReadOnly = False : Me.txtEstado.ReadOnly = False
        Me.btnSalvar.Enabled = True : Me.btnCancelar.Enabled = True : Me.cboBairro.Enabled = True
        Me.cboBairro.SelectedIndex = -1 : Me.cboRua.SelectedIndex = -1
        mskCnpjCpf.ReadOnly = False

    End Sub

    Private Sub preencheDtgEmpresas()

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


        Try

            sql.Append("SELECT empid, emprazaosocial, empfantasia, empendereco, empcidade FROM empresa ")
            sql.Append("WHERE emprazaosocial LIKE @emprazaosocial ORDER BY emprazaosocial ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConn)
            cmd.Parameters.Add("@emprazaosocial", Me.txt_pesquisa.Text & "%")
            dr = cmd.ExecuteReader

            dtg_Empresas.Rows.Clear()
            If dr.HasRows = False Then Return
            Dim mTelefone As String = ""
            While dr.Read
                dtg_Empresas.Rows.Add(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString(), dr(4).ToString)
            End While

            dtg_Empresas.Refresh() : dr.Close()
            oConn.ClearPool() : oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT das Empresas:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
            Return

        End Try

        txt_qtdRegistros.Text = dtg_Empresas.Rows.Count
        cmd.CommandText = ""
        sql.Remove(0, sql.ToString.Length)

        'Limpa Objetos de Memoria...
        oConn = Nothing : cmd = Nothing
        sql = Nothing : dr = Nothing



    End Sub

    Sub PreencheValoresCampos()

        txtId.Text = _Empresa.empid
        txtRazao.Text = _Empresa.emprazaosocial
        txtFantasia.Text = _Empresa.empfantasia
        mskTelefone.Text = _Empresa.empfone
        txtCidade.Text = _Empresa.empcidade
        txtEstado.Text = _Empresa.empestado
        cboRua.Text = _Empresa.empendereco
        cboBairro.Text = _Empresa.empbairro

        mskCnpjCpf.Text = ""
        If Not _Empresa.empCnpj.Equals("") Then
            rbCnpj.Checked = True
            mskCnpjCpf.Text = _Empresa.empCnpj
        ElseIf Not _Empresa.empCPF.Equals("") Then
            rbCpf.Checked = True
            mskCnpjCpf.Text = _Empresa.empCPF
        End If

    End Sub

    Sub PreencheEmpresaValores()
        Dim mstr As String = ""

        If IsNumeric(txtId.Text) Then _Empresa.empid = CInt(txtId.Text)
        _Empresa.emprazaosocial = txtRazao.Text
        _Empresa.empfantasia = txtFantasia.Text
        _Empresa.empcidade = txtCidade.Text
        _Empresa.empestado = txtEstado.Text
        _Empresa.empendereco = cboRua.Text
        _Empresa.empbairro = cboBairro.Text

        mstr = Trim(_funcoes.RemoverCaracter2(mskCnpjCpf.Text))
        _Empresa.empCnpj = ""
        _Empresa.empCPF = ""
        If rbCnpj.Checked Then
            If Not mstr.Equals("") Then _Empresa.empCnpj = Trim(mskCnpjCpf.Text).Replace(",", ".")
        Else
            If Not mstr.Equals("") Then _Empresa.empCPF = Trim(mskCnpjCpf.Text).Replace(",", ".")
        End If

    End Sub

    Sub ExecutaF5()
        preencheDtgEmpresas()
    End Sub

    Sub ExecutaF2()
        ZeraValores()
        HabilitaCampos()
        txtRazao.Focus()
        tipoOperacao = "I"
    End Sub

    Sub ExecutaF3()

        If dtg_Empresas.CurrentRow.IsNewRow = False Then
            _Empresa.empid = CInt(dtg_empresas.CurrentRow.Cells(0).Value)
            _EmpresaDAO.TrazEmpresa(_Empresa, MdlConexaoBD.conectionPadrao)
            HabilitaCampos()
            PreencheValoresCampos()
            txtRazao.Focus()
            tipoOperacao = "A"
        End If

    End Sub

    Sub ExecutaDel()

        tipoOperacao = ""
        If dtg_Empresas.CurrentRow.IsNewRow = False Then
            _Empresa.empid = CInt(dtg_empresas.CurrentRow.Cells(0).Value)
        End If
        Dim mMsg As String = ""

        Try

            If dtg_Empresas.CurrentRow.IsNewRow = False Then

                _Empresa.empid = CInt(dtg_empresas.CurrentRow.Cells(0).Value)
                _EmpresaDAO.TrazEmpresa(_Empresa, MdlConexaoBD.conectionPadrao)
                
                If MessageBox.Show(mMsg, Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then

                    ZeraValores() : DesabilitaCampos()


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

                       _EmpresaDAO.delEmpresa(_Empresa, conection, transacao)

                        transacao.Commit() : conection.ClearPool() : conection.Close()

                        MsgBox(mMsg, MsgBoxStyle.Exclamation)
                        ExecutaF5()
                        _Empresa.ZeraValores()
                        _EmpresaDAO.TrazListEmpresas(MdlConexaoBD.mdlListEmpresa, MdlConexaoBD.conectionPadrao)
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
            _Empresa.empid = Me.txtId.Text
        Catch ex As Exception
            _Empresa.empid = 0
        End Try

        'Dados principais:
        _Empresa.emprazaosocial = Me.txtRazao.Text
        _Empresa.empendereco = Me.cboRua.Text

        If tipoOperacao.Equals("I") Then
            If _EmpresaDAO.ValidaEmpresa(_Empresa) = False Then Return
        Else
            If _EmpresaDAO.ValidaEmpresa(_Empresa, "A") = False Then Return
        End If

        PreencheEmpresaValores()

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
                _EmpresaDAO.incEmpresa(_Empresa, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _EmpresaDAO.altEmpresa(_Empresa, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Empresa Salvo com Sucesso!", MsgBoxStyle.Exclamation)
            _EmpresaDAO.TrazListEmpresas(MdlConexaoBD.mdlListEmpresa, MdlConexaoBD.conectionPadrao)
            ZeraValores()
            DesabilitaCampos()
            _Empresa.ZeraValores()
            ExecutaF5() : txt_pesquisa.Focus()
            DesabilitaCampos() : ZeraValores()

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try
    End Sub

    Private Sub dtg_produtos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtg_empresas.CellDoubleClick

        If dtg_Empresas.CurrentRow.IsNewRow = False Then
            _Empresa.empid = CInt(dtg_empresas.CurrentRow.Cells(0).Value)
            _EmpresaDAO.TrazEmpresa(_Empresa, MdlConexaoBD.conectionPadrao)
            PreencheValoresCampos()
        End If
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        ExecutaF3()
    End Sub

    Private Sub txt_pesquisa_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_pesquisa.KeyDown
        If Keys.Enter Then preencheDtgEmpresas()
    End Sub

    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        ExecutaDel()
    End Sub

    Private Sub txtCamposNumeros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mskTelefone.KeyPress, mskCnpjCpf.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
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