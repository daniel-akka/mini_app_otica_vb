Imports System
Imports System.Data
Imports System.DateTime
Imports System.Text
Imports Npgsql
Imports System.Math
Public Class FrmMenuDuplicatasAPagar

    'Objetos e Variáveis:
    Private _ListaAPagarTotal As New List(Of ClAPagarTotal)
    Private _ListaAPagarTotalRelatorio As New List(Of ClAPagarTotal)
    Private _APagarTotalDAO As New ClAPagarTotalDAO
    Private _APagarTotal As New ClAPagarTotal
    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes
    Public Shared FrmMenuDuplicatasAPagar As New FrmMenuDuplicatasAPagar
    Dim _diasVencidos As Integer = 0
    Dim _sitDoc As String = "N"
    Dim _Fornecedor As New ClFornecedor
    Dim _FornecedorDAO As New ClFornecedorDAO

    'Pagamento de Duplicata
    Public numDuplicata As String = ""
    Public valorDuplicata As Double = 0.0
    Public _idRecebimento As Int64 = 0

    'Pagamento Duplicatas Marcadas
    Dim mJuros, mDesconto, mValor, msubtotal, mtotalgeral, mAcrescimo As Double
    Dim mDias, mCarencia As Integer
    Dim mPesqPortador As Boolean = False

    Private Sub FrmMenuDuplicatasAPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbo_situacao.SelectedIndex = 0
    End Sub

    Private Sub FrmMenuDuplicatasAPagar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.F5
                ExecutaF5()

            Case Keys.F11
                executaF11()

            Case Keys.Delete
                ExecuteEstornar()
        End Select

    End Sub

    Sub ExecutaF5()

        lbl_mensagem.Text = ""
        Dim mSituacao As String = "", mdtVencto As String = "", mDataPagamento As String = ""
        Dim mDataBetween As Boolean = False
        Dim mDias As Integer = 0


        _ListaAPagarTotal.Clear()
        dtgContasAPagar.Rows.Clear()

        If cbo_situacao.SelectedIndex > 0 Then
            mSituacao = cbo_situacao.SelectedItem.ToString.Substring(0, 1).ToUpper
        End If

        If rdb_emiss.Checked Then


            If mSituacao.Equals("") Then 'todos

                _ListaAPagarTotal = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            (FormatDateTime(ar.apt_dataemissao, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.apt_dataemissao, DateFormat.ShortDate).ToString <= dtpFim.Text))

            Else

                _ListaAPagarTotal = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            ar.apt_situacao = mSituacao And _
                                                                            (FormatDateTime(ar.apt_dataemissao, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.apt_dataemissao, DateFormat.ShortDate).ToString <= dtpFim.Text))
            End If

        ElseIf rdb_pagamento.Checked Then


            If mSituacao.Equals("") Then


                For Each Ar As ClAPagarTotal In MdlConexaoBD.ListaAPagarTotal

                    'Inicio das condições:
                    If IsDate(Ar.apt_datapagamento) Then

                        If Ar.apt_portadornome.StartsWith(txt_portador.Text) Then

                            If (FormatDateTime(CDate(Ar.apt_datapagamento), DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                (FormatDateTime(CDate(Ar.apt_datapagamento), DateFormat.ShortDate).ToString <= dtpFim.Text) Then

                                _ListaAPagarTotal.Add(Ar)
                            End If
                        End If
                    End If

                Next

            Else


                For Each Ar As ClAPagarTotal In MdlConexaoBD.ListaAPagarTotal

                    'Inicio das condições:
                    If IsDate(Ar.apt_datapagamento) Then

                        If Ar.apt_portadornome.StartsWith(txt_portador.Text) Then

                            If Ar.apt_situacao.Equals(mSituacao) Then

                                If (FormatDateTime(CDate(Ar.apt_datapagamento), DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                (FormatDateTime(CDate(Ar.apt_datapagamento), DateFormat.ShortDate).ToString <= dtpFim.Text) Then

                                    _ListaAPagarTotal.Add(Ar)
                                End If
                            End If
                        End If
                    End If

                Next

            End If

        ElseIf rdb_vencimento.Checked Then

            If mSituacao.Equals("") Then

                _ListaAPagarTotal = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            (FormatDateTime(ar.apt_datavencimento, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.apt_datavencimento, DateFormat.ShortDate).ToString <= dtpFim.Text))
            Else

                _ListaAPagarTotal = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            ar.apt_situacao = mSituacao And _
                                                                            (FormatDateTime(ar.apt_datavencimento, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.apt_datavencimento, DateFormat.ShortDate).ToString <= dtpFim.Text))
            End If

        Else

            If mSituacao.Equals("") Then

                _ListaAPagarTotal = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text))
            Else

                _ListaAPagarTotal = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            ar.apt_situacao = mSituacao)
            End If

        End If


        If _ListaAPagarTotal.Count > 0 Then

            For Each ar As ClAPagarTotal In _ListaAPagarTotal

                'Calcula os Dias Vencidos:
                mDias = _valorZERO
                Try
                    mdtVencto = Format(Convert.ChangeType(ar.apt_datavencimento, GetType(Date)), "dd/MM/yyyy")

                    If Convert.ChangeType(mdtVencto, GetType(Date)) < Date.Now Then

                        mDias = Date.Now.Subtract(Convert.ChangeType(mdtVencto, GetType(Date))).Days

                    End If

                Catch ex As Exception
                    mdtVencto = ""
                End Try
                _diasVencidos = mDias

                _sitDoc = ar.apt_situacao

                mDataPagamento = ar.apt_datapagamento
                If IsDate(mDataPagamento) Then mDataPagamento = CDate(mDataPagamento).ToShortDateString & " " & CDate(mDataPagamento).ToShortTimeString

                ''Preeenche Com o nome atualizado do Cliente:
                '_Cliente.ZeraValores()
                '_Cliente.cid = ar.apt_clienteid
                '_ClienteDAO.TrazClienteDaListaClientes(_Cliente, MdlConexaoBD.mdlListClientes)
                'ar.apt_portadornome = _Cliente.cnome


                'Adiciona no Grid
                dtgContasAPagar.Rows.Add(False, ar.apt_id, ar.apt_portadorid, ar.apt_portadornome, ar.apt_tela, ar.apt_situacao, _
                                           ar.apt_dataemissao.ToShortDateString, ar.apt_valor.ToString("#,##0.00"), ar.apt_datavencimento.ToShortDateString, ar.apt_valorrestante.ToString("#,##0.00"), mDataPagamento, mDias, ar.apt_acrescimo.ToString("#,##0.00"), ar.apt_observacao)
            Next
        End If

        somaValor()
        somaMarcados()
        lbl_registros.Text = Me.dtgContasAPagar.Rows.Count

    End Sub

    Private Sub FrmMenuDuplicatasAPagar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Sub executaF2()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        lbl_mensagem.Text = ""
        Dim frmCadAreceb As New FrmCadAPagar
        frmCadAreceb.operacao = "I"
        frmCadAreceb.ShowDialog()
        ExecutaF5()
        frmCadAreceb = Nothing
    End Sub

    Private Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click

        executaF2()
    End Sub

    Sub executaPagamento()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        lbl_mensagem.Text = "" : _idRecebimento = 0
        If dtgContasAPagar.RowCount <= 0 Then Return
        If dtgContasAPagar.CurrentRow.IsNewRow Then
            lbl_mensagem.Text = "Por favor Selecione um Documento !"
        Else

            Dim mSit As String = dtgContasAPagar.CurrentRow.Cells(5).Value.ToString
            Select Case mSit
                Case "L"
                    lbl_mensagem.Text = "CONTA A RECEBER já foi PAGA !"
                    Return
                Case "E"
                    lbl_mensagem.Text = "CONTA A RECEBER foi ESTORNADA !"
                    Return
                Case Else
                    Try
                        _APagarTotal.ZeraValores()
                        _APagarTotal.apt_id = dtgContasAPagar.CurrentRow.Cells(1).Value
                        _APagarTotalDAO.TrazContaAPagarDaLista(_APagarTotal, _ListaAPagarTotal)

                        Dim BaixaInd As New FrmBaixaAPagar
                        BaixaInd.APagarTotal.SetaValores(_APagarTotal)
                        BaixaInd.ShowDialog()
                        BaixaInd = Nothing
                        ExecutaF5()

                    Catch ex As Exception
                        MsgBox("ERRO:: " & ex.Message)
                    Finally
                        _APagarTotal.ZeraValores()
                    End Try

            End Select


        End If
    End Sub

    Private Sub btn_pagamento_Click(sender As Object, e As EventArgs) Handles btn_pagamento.Click

        executaPagamento()

    End Sub

    Private Sub dtgContasAPagar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgContasAPagar.CellClick

        If e.ColumnIndex = 0 Then

            If Me.dtgContasAPagar.CurrentRow.Cells(0).Value Then
                Me.dtgContasAPagar.CurrentRow.Cells(0).Value = False
            Else
                Me.dtgContasAPagar.CurrentRow.Cells(0).Value = True
            End If

            somaMarcados()
        End If

    End Sub

    Private Sub somaValor()

        Dim msomaValores As Double = 0.0
        For Each row As DataGridViewRow In Me.dtgContasAPagar.Rows

            If row.IsNewRow = False Then

                Try
                    msomaValores += row.Cells(7).Value
                Catch ex As Exception
                End Try
            End If


        Next

        txt_somaMarcados.Text = ""
        If msomaValores > 0 Then
            Me.txt_totais.Text = Format(msomaValores, "###,##0.00")
        End If

    End Sub

    Private Sub somaMarcados()

        Dim msomaMarcados As Double = 0.0
        For Each row As DataGridViewRow In Me.dtgContasAPagar.Rows

            If row.IsNewRow = False Then

                If row.Cells(0).Value Then

                    Try
                        msomaMarcados += row.Cells(7).Value
                    Catch ex As Exception
                    End Try
                End If

            End If


        Next

        txt_somaMarcados.Text = ""
        If msomaMarcados > 0 Then
            Me.txt_somaMarcados.Text = Format(msomaMarcados, "###,##0.00")
        End If

    End Sub

    Function ExistPago() As Boolean

        For Each row As DataGridViewRow In dtgContasAPagar.Rows

            If row.IsNewRow = False Then
                If row.Cells(0).Value AndAlso row.Cells(5).Value.ToString.Equals("L") Then Return True
            End If
        Next
        Return False
    End Function

    Sub executaBaixaMarcados()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Try
            Dim msg As String = "Deseja realmente Baixar todas as Contas Marcadas?"
            If ExistPago() Then
                msg = "Algum(s) ou Todos os Selecionado já foram Baixados! Deseja Continuar?"
            End If


            lbl_mensagem.Text = "" : _idRecebimento = 0
            If CDec(txt_somaMarcados.Text) > 0 Then

                Dim mTipoPagPadrao As String = "DN"
                'Pega a forma de pagamento padrao:
                Dim frmFormPag As New FrmTipoPagAReceberResp
                frmFormPag.ShowDialog()
                mTipoPagPadrao = frmFormPag.TipoPagamento
                frmFormPag = Nothing

                If MessageBox.Show(msg, "Baixa Total de Documentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                = Windows.Forms.DialogResult.Yes Then


                    Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
                    Dim transacao As NpgsqlTransaction

                    Try
                        conexao.Open()
                    Catch ex As Exception
                        MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
                        Return

                    End Try

                    Try
                        transacao = conexao.BeginTransaction
                        baixaTotalDocumentos(mTipoPagPadrao, conexao, transacao)
                        transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
                        MsgBox("Baixa de Documentos Efetuadas com Sucesso !", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)

                        _APagarTotalDAO.TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
                        _APagarTotalDAO.TrazListAPagarTotalBD(_ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
                        ExecutaF5()
                    Catch ex As NpgsqlException

                        transacao.Rollback()
                        MsgBox(ex.Message.ToString)
                    Catch ex As Exception


                        Try
                            transacao.Rollback()
                        Catch ex2 As Exception
                            MsgBox(ex2.Message.ToString)
                        End Try

                        MsgBox(ex.Message.ToString)
                    Finally
                        conexao = Nothing : transacao = Nothing
                    End Try


                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_baixaMarcados_Click(sender As Object, e As EventArgs) Handles btn_baixaMarcados.Click

        executaBaixaMarcados()

    End Sub

    Private Sub baixaTotalDocumentos(ByVal TipoPagPadrao As String, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Dim numDoc As String = ""
        For Each row As DataGridViewRow In Me.dtgContasAPagar.Rows

            _APagarTotal.ZeraValores()
            If row.IsNewRow = False Then

                If row.Cells(0).Value Then
                    _APagarTotal.apt_id = row.Cells(1).Value
                    _APagarTotalDAO.TrazContaAPagarDaLista(_APagarTotal, _ListaAPagarTotal)
                    Select Case TipoPagPadrao
                        Case "DN"
                            _APagarTotal.apt_pagodinheiro += _APagarTotal.apt_valorrestante
                        Case "CTC"
                            _APagarTotal.apt_pagocartaocred += _APagarTotal.apt_valorrestante
                        Case "CTD"
                            _APagarTotal.apt_pagocartaodeb += _APagarTotal.apt_valorrestante
                        Case "PIX"
                            _APagarTotal.apt_pagopix += _APagarTotal.apt_valorrestante
                        Case "TRA"
                            _APagarTotal.apt_pagotransferencia += _APagarTotal.apt_valorrestante
                    End Select

                    _APagarTotalDAO.altAPagarBaixaIndividual(_APagarTotal, conexao, transacao)
                End If
            End If
        Next

    End Sub

    Private Sub dtgContasAPagar_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgContasAPagar.RowsAdded

        Select Case _sitDoc
            Case "L"
                dtgContasAPagar.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumBlue
            Case "V"
                dtgContasAPagar.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Case "E"
                dtgContasAPagar.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumOrchid
            Case "N"
                If _diasVencidos > 0 Then dtgContasAPagar.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
                If CDbl(dtgContasAPagar.Rows(e.RowIndex).Cells(9).Value) > 0 Then
                    dtgContasAPagar.Rows(e.RowIndex).Cells(9).Style.ForeColor = Color.DarkGreen
                End If
        End Select

    End Sub

    Sub executaF3()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Try

            lbl_mensagem.Text = "" : _idRecebimento = 0
            If dtgContasAPagar.CurrentRow.IsNewRow = False Then

                Dim mSit As String = dtgContasAPagar.CurrentRow.Cells(5).Value.ToString
                Select Case mSit
                    Case "L"
                        lbl_mensagem.Text = "CONTA A PAGAR já foi PAGA ! Não Pode ser Alterada!"
                        Return
                    Case "E"
                        lbl_mensagem.Text = "CONTA A PAGAR foi ESTORNADA ! Não Pode ser Alterada!"
                        Return
                    Case Else

                        _APagarTotal.ZeraValores()
                        _APagarTotal.apt_id = dtgContasAPagar.CurrentRow.Cells(1).Value
                        _APagarTotalDAO.TrazContaAPagarDaLista(_APagarTotal, _ListaAPagarTotal)

                        Dim RecebRegistro As New FrmCadAPagar
                        RecebRegistro._APagarTotal.SetaValores(_APagarTotal)
                        RecebRegistro.operacao = "A" 'Alteração
                        RecebRegistro.ShowDialog()
                        RecebRegistro = Nothing
                        ExecutaF5()

                End Select

            Else
                lbl_mensagem.Text = "Selecione um documento para Alterar !"
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click

        executaF3()

    End Sub

    Sub executaVIZUALIZAR()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        lbl_mensagem.Text = ""
        If dtgContasAPagar.RowCount <= 0 Then Return
        _APagarTotal.ZeraValores()
        _APagarTotal.apt_id = dtgContasAPagar.CurrentRow.Cells(1).Value
        _APagarTotalDAO.TrazContaAPagarDaLista(_APagarTotal, _ListaAPagarTotal)

        If _APagarTotal.apt_id <= 0 Then
            lbl_mensagem.Text = "Selecione uma Conta A PAGAR para Visualizar!"
            Return
        End If

        Dim frmCadAreceb As New FrmCadAPagar
        frmCadAreceb.operacao = "V" 'Visualização
        frmCadAreceb._APagarTotal.SetaValores(_APagarTotal)
        frmCadAreceb.ShowDialog()
        frmCadAreceb = Nothing
    End Sub

    Private Sub btnVizualizar_Click(sender As Object, e As EventArgs) Handles btnVizualizar.Click

        executaVIZUALIZAR()

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        ExecutaF5()
    End Sub

    Private Sub txt_portador_TextChanged(sender As Object, e As EventArgs) Handles txt_portador.TextChanged
        ExecutaF5()
    End Sub

    Private Sub cbo_situacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_situacao.SelectedIndexChanged
        ExecutaF5()
    End Sub

    Sub ExecuteEstornar()
        'Estornar Contas a Receber
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Dim mSituacao As String = dtgContasAPagar.CurrentRow.Cells(5).Value.ToString

        Select Case mSituacao
            Case "L"
                MsgBox("Conta Liquidada não pode ser Estornada!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                Return

            Case "E"
                MsgBox("Conta já Estornada!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                Return

        End Select


        lbl_mensagem.Text = "" : _idRecebimento = 0
        If dtgContasAPagar.CurrentRow.IsNewRow Then MsgBox("Selecione um Conta para Estornar!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper) : Return

        _APagarTotal.apt_id = dtgContasAPagar.CurrentRow.Cells(1).Value
        _APagarTotalDAO.TrazContaAPagarDaLista(_APagarTotal, MdlConexaoBD.ListaAPagarTotal)
        If MessageBox.Show("Deseja Realmente Estornar essa Conta: " & _APagarTotal.apt_valor.ToString("#,##0.00") & " ?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) =
             Windows.Forms.DialogResult.No Then
            _APagarTotal.ZeraValores()
            Return
        End If

        Dim conexao As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Dim transacao As NpgsqlTransaction

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("Erro ao Abrir conexão com BD " & ex.Message, MsgBoxStyle.Exclamation)
            Return

        End Try

        Try
            transacao = conexao.BeginTransaction
            _APagarTotal.apt_id = dtgContasAPagar.CurrentRow.Cells(1).Value
            _APagarTotalDAO.altAPagarEstornarConta(_APagarTotal, conexao, transacao)
            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
            MsgBox("Estorno de Documento Efetuada com Sucesso !", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)

            _APagarTotalDAO.TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
            _APagarTotalDAO.TrazListAPagarTotalBD(_ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
            ExecutaF5()
        Catch ex As NpgsqlException

            transacao.Rollback()
            MsgBox(ex.Message.ToString)
        Catch ex As Exception


            Try
                transacao.Rollback()
            Catch ex2 As Exception
                MsgBox(ex2.Message.ToString)
            End Try

            MsgBox(ex.Message.ToString)
        Finally
            conexao = Nothing : transacao = Nothing
        End Try


    End Sub

    Private Sub btnEstornar_Click(sender As Object, e As EventArgs) Handles btnEstornar.Click
        ExecuteEstornar()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

    Sub executaF11()

        consulta(_ListaAPagarTotalRelatorio)
        If _ListaAPagarTotalRelatorio.Count > 0 Then

            Dim mListaRelatorio As New List(Of ClAPagarTotal)
            Dim mAPagarT As New ClAPagarTotal
            For Each l As ClAPagarTotal In _ListaAPagarTotalRelatorio
                mAPagarT.ZeraValores()
                mAPagarT.SetaValores(l)
                mAPagarT.apt_datapagamento = ""
                If IsDate(l.apt_datapagamento) Then
                    mAPagarT.apt_datapagamento = CDate(l.apt_datapagamento).ToShortDateString & " " & CDate(l.apt_datapagamento).ToShortTimeString
                End If
                mListaRelatorio.Add(New ClAPagarTotal(mAPagarT))
            Next

            Dim mFormulario As New FormListaContasAPagar
            mFormulario._ListaContasAPagar = mListaRelatorio
            mFormulario._FiltroSituacao = Me.cbo_situacao.Text
            mFormulario._FiltroCliente = Me.txt_portador.Text
            mFormulario._FiltroData = "Nenhuma"
            If rdb_emiss.Checked Then mFormulario._FiltroData = "Emissão " & dtpInicio.Text & " A " & dtpFim.Text
            If rdb_pagamento.Checked Then mFormulario._FiltroData = "Pagamento " & dtpInicio.Text & " A " & dtpFim.Text
            If rdb_vencimento.Checked Then mFormulario._FiltroData = "Vencimento " & dtpInicio.Text & " A " & dtpFim.Text
            mFormulario.ShowDialog()
            mFormulario = Nothing

        End If
    End Sub

    Sub consulta(ByRef listaRelatorio As List(Of ClAPagarTotal))

        lbl_mensagem.Text = ""
        Dim mSituacao As String = "", mdtVencto As String = "", mDataPagamento As String = ""
        Dim mDataBetween As Boolean = False
        Dim mDias As Integer = 0


        listaRelatorio.Clear()
        dtgContasAPagar.Rows.Clear()

        If cbo_situacao.SelectedIndex > 0 Then
            mSituacao = cbo_situacao.SelectedItem.ToString.Substring(0, 1).ToUpper
        End If

        If rdb_emiss.Checked Then


            If mSituacao.Equals("") Then 'todos

                listaRelatorio = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            (FormatDateTime(ar.apt_dataemissao, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.apt_dataemissao, DateFormat.ShortDate).ToString <= dtpFim.Text))

            Else

                listaRelatorio = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            ar.apt_situacao = mSituacao And _
                                                                            (FormatDateTime(ar.apt_dataemissao, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.apt_dataemissao, DateFormat.ShortDate).ToString <= dtpFim.Text))
            End If

        ElseIf rdb_pagamento.Checked Then


            If mSituacao.Equals("") Then


                For Each Ar As ClAPagarTotal In MdlConexaoBD.ListaAPagarTotal

                    'Inicio das condições:
                    If IsDate(Ar.apt_datapagamento) Then

                        If Ar.apt_portadornome.StartsWith(txt_portador.Text) Then

                            If (FormatDateTime(CDate(Ar.apt_datapagamento), DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                (FormatDateTime(CDate(Ar.apt_datapagamento), DateFormat.ShortDate).ToString <= dtpFim.Text) Then

                                listaRelatorio.Add(Ar)
                            End If
                        End If
                    End If

                Next

            Else


                For Each Ar As ClAPagarTotal In MdlConexaoBD.ListaAPagarTotal

                    'Inicio das condições:
                    If IsDate(Ar.apt_datapagamento) Then

                        If Ar.apt_portadornome.StartsWith(txt_portador.Text) Then

                            If Ar.apt_situacao.Equals(mSituacao) Then

                                If (FormatDateTime(CDate(Ar.apt_datapagamento), DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                (FormatDateTime(CDate(Ar.apt_datapagamento), DateFormat.ShortDate).ToString <= dtpFim.Text) Then

                                    listaRelatorio.Add(Ar)
                                End If
                            End If
                        End If
                    End If

                Next

            End If

        ElseIf rdb_vencimento.Checked Then

            If mSituacao.Equals("") Then

                listaRelatorio = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            (FormatDateTime(ar.apt_datavencimento, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.apt_datavencimento, DateFormat.ShortDate).ToString <= dtpFim.Text))
            Else

                listaRelatorio = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            ar.apt_situacao = mSituacao And _
                                                                            (FormatDateTime(ar.apt_datavencimento, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.apt_datavencimento, DateFormat.ShortDate).ToString <= dtpFim.Text))
            End If

        Else

            If mSituacao.Equals("") Then

                listaRelatorio = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text))
            Else

                listaRelatorio = MdlConexaoBD.ListaAPagarTotal.FindAll(Function(ar As ClAPagarTotal) _
                                                                            ar.apt_portadornome.StartsWith(txt_portador.Text) And _
                                                                            ar.apt_situacao = mSituacao)
            End If

        End If

    End Sub

End Class