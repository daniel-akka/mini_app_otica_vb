Imports System
Imports System.Data
Imports System.DateTime
Imports System.Text
Imports Npgsql
Imports System.Math

Public Class FrmMenuDuplicatas

    'Objetos e Variáveis:
    Private _ListaAReceberTotal As New List(Of ClAReceberTotal)
    Dim _ListaAPagarTotalRelatorio As New List(Of ClAReceberTotal)
    Private _AReceberTotalDAO As New ClAReceberTotalDAO
    Private _AReceberTotal As New ClAReceberTotal
    Private Const _valorZERO As Integer = 0
    Private _clFuncoes As New ClFuncoes
    Public Shared FrmMenuDuplicatas As New FrmMenuDuplicatas
    Dim _diasVencidos As Integer = 0
    Dim _sitDoc As String = "N"
    Dim _Cliente As New ClCliente
    Dim _ClienteDAO As New ClClienteDAO

    'Pagamento de Duplicata
    Public numDuplicata As String = ""
    Public valorDuplicata As Double = 0.0
    Public _idRecebimento As Int64 = 0

    'Pagamento Duplicatas Marcadas
    Dim mJuros, mDesconto, mValor, msubtotal, mtotalgeral, mAcrescimo As Double
    Dim mDias, mCarencia As Integer
    Dim mPesqPortador As Boolean = False

    Private Sub FrmMenuDuplicatas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cbo_situacao.SelectedIndex = 0
    End Sub

    Private Sub FrmMenuDuplicatas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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


        Dim mSituacao As String = "", mdtVencto As String = "", mDataPagamento As String = ""
        Dim mDataBetween As Boolean = False
        Dim mDias As Integer = 0


        _ListaAReceberTotal.Clear()
        dtgContasAReceber.Rows.Clear()

        If cbo_situacao.SelectedIndex > 0 Then
            mSituacao = cbo_situacao.SelectedItem.ToString.Substring(0, 1).ToUpper
        End If

        If rdb_emiss.Checked Then


            If mSituacao.Equals("") Then 'todos

                _ListaAReceberTotal = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            (FormatDateTime(ar.art_dataemissao, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.art_dataemissao, DateFormat.ShortDate).ToString <= dtpFim.Text))

            Else

                _ListaAReceberTotal = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            ar.art_situacao = mSituacao And _
                                                                            (FormatDateTime(ar.art_dataemissao, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.art_dataemissao, DateFormat.ShortDate).ToString <= dtpFim.Text))
            End If

        ElseIf rdb_pagamento.Checked Then


            If mSituacao.Equals("") Then


                For Each Ar As ClAReceberTotal In MdlConexaoBD.ListaAReceberTotal

                    'Inicio das condições:
                    If IsDate(Ar.art_datapagamento) Then

                        If Ar.art_clientenome.StartsWith(txt_portador.Text) Then

                            If (FormatDateTime(CDate(Ar.art_datapagamento), DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                (FormatDateTime(CDate(Ar.art_datapagamento), DateFormat.ShortDate).ToString <= dtpFim.Text) Then

                                _ListaAReceberTotal.Add(Ar)
                            End If
                        End If
                    End If

                Next

            Else


                For Each Ar As ClAReceberTotal In MdlConexaoBD.ListaAReceberTotal

                    'Inicio das condições:
                    If IsDate(Ar.art_datapagamento) Then

                        If Ar.art_clientenome.StartsWith(txt_portador.Text) Then

                            If Ar.art_situacao.Equals(mSituacao) Then

                                If (FormatDateTime(CDate(Ar.art_datapagamento), DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                (FormatDateTime(CDate(Ar.art_datapagamento), DateFormat.ShortDate).ToString <= dtpFim.Text) Then

                                    _ListaAReceberTotal.Add(Ar)
                                End If
                            End If
                        End If
                    End If

                Next

            End If

        ElseIf rdb_vencimento.Checked Then

            If mSituacao.Equals("") Then

                _ListaAReceberTotal = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            (FormatDateTime(ar.art_datavencimento, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.art_datavencimento, DateFormat.ShortDate).ToString <= dtpFim.Text))
            Else

                _ListaAReceberTotal = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            ar.art_situacao = mSituacao And _
                                                                            (FormatDateTime(ar.art_datavencimento, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.art_datavencimento, DateFormat.ShortDate).ToString <= dtpFim.Text))
            End If

        Else

            If mSituacao.Equals("") Then

                _ListaAReceberTotal = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text))
            Else

                _ListaAReceberTotal = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            ar.art_situacao = mSituacao)
            End If

        End If


        If _ListaAReceberTotal.Count > 0 Then

            For Each ar As ClAReceberTotal In _ListaAReceberTotal

                'Calcula os Dias Vencidos:
                mDias = _valorZERO
                Try
                    mdtVencto = Format(Convert.ChangeType(ar.art_datavencimento, GetType(Date)), "dd/MM/yyyy")

                    If Convert.ChangeType(mdtVencto, GetType(Date)) < Date.Now Then

                        mDias = Date.Now.Subtract(Convert.ChangeType(mdtVencto, GetType(Date))).Days

                    End If

                Catch ex As Exception
                    mdtVencto = ""
                End Try
                _diasVencidos = mDias

                _sitDoc = ar.art_situacao

                mDataPagamento = ar.art_datapagamento
                If IsDate(mDataPagamento) Then mDataPagamento = CDate(mDataPagamento).ToShortDateString & " " & CDate(mDataPagamento).ToShortTimeString

                ''Preeenche Com o nome atualizado do Cliente:
                '_Cliente.ZeraValores()
                '_Cliente.cid = ar.art_clienteid
                '_ClienteDAO.TrazClienteDaListaClientes(_Cliente, MdlConexaoBD.mdlListClientes)
                'ar.art_clientenome = _Cliente.cnome


                'Adiciona no Grid
                dtgContasAReceber.Rows.Add(False, ar.art_id, ar.art_clienteid, ar.art_clientenome, ar.art_tela, ar.art_situacao, _
                                           ar.art_dataemissao.ToShortDateString, ar.art_valor.ToString("#,##0.00"), ar.art_datavencimento.ToShortDateString, ar.art_valorrestante.ToString("#,##0.00"), ar.art_parcela.ToString.PadLeft(2, "0"), mDataPagamento, mDias, ar.art_acrescimo.ToString("#,##0.00"), ar.art_observacao)
            Next
        End If

        somaValor()
        somaMarcados()
        lbl_registros.Text = Me.dtgContasAReceber.Rows.Count

    End Sub

    Private Sub FrmMenuDuplicatas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If

    End Sub

    Sub executaF2()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        Dim frmCadAreceb As New FrmCadAReceber
        frmCadAreceb.operacao = "I"
        frmCadAreceb.ShowDialog()
        ExecutaF5()
        frmCadAreceb = Nothing
    End Sub

    Private Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click

        executaF2()
    End Sub

    Private Sub btn_pagamento_Click(sender As Object, e As EventArgs) Handles btn_pagamento.Click

        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        lbl_mensagem.Text = "" : _idRecebimento = 0
        If dtgContasAReceber.RowCount <= 0 Then Return
        If dtgContasAReceber.CurrentRow.IsNewRow Then
            lbl_mensagem.Text = "Por favor Selecione um Documento !"
        Else

            Dim mSit As String = dtgContasAReceber.CurrentRow.Cells(5).Value.ToString
            Select Case mSit
                Case "L"
                    lbl_mensagem.Text = "CONTA A RECEBER já foi PAGA !"
                    Return
                Case "E"
                    lbl_mensagem.Text = "CONTA A RECEBER foi ESTORNADA !"
                    Return
                Case Else
                    Try
                        _AReceberTotal.ZeraValores()
                        _AReceberTotal.art_id = dtgContasAReceber.CurrentRow.Cells(1).Value
                        _AReceberTotalDAO.TrazContaAReceberDaLista(_AReceberTotal, _ListaAReceberTotal)

                        Dim BaixaInd As New FrmBaixaAReceber
                        BaixaInd.AReceberTotal.SetaValores(_AReceberTotal)
                        BaixaInd.ShowDialog()
                        BaixaInd = Nothing
                        ExecutaF5()

                    Catch ex As Exception
                        MsgBox("ERRO:: " & ex.Message)
                    Finally
                        _AReceberTotal.ZeraValores()
                    End Try

            End Select


        End If

    End Sub

    Private Sub dtgContasAReceber_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgContasAReceber.CellClick

        If e.ColumnIndex = 0 Then

            If Me.dtgContasAReceber.CurrentRow.Cells(0).Value Then
                Me.dtgContasAReceber.CurrentRow.Cells(0).Value = False
            Else
                Me.dtgContasAReceber.CurrentRow.Cells(0).Value = True
            End If

            somaMarcados()
        End If

    End Sub

    Private Sub somaValor()

        Dim msomaValores As Double = 0.0
        For Each row As DataGridViewRow In Me.dtgContasAReceber.Rows

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
        For Each row As DataGridViewRow In Me.dtgContasAReceber.Rows

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

        For Each row As DataGridViewRow In dtgContasAReceber.Rows

            If row.IsNewRow = False Then
                If row.Cells(0).Value AndAlso row.Cells(5).Value.ToString.Equals("L") Then Return True
            End If
        Next
        Return False
    End Function

    Private Sub btn_baixaMarcados_Click(sender As Object, e As EventArgs) Handles btn_baixaMarcados.Click

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

                        _AReceberTotalDAO.TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
                        _AReceberTotalDAO.TrazListAReceberBD(_ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
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

    Private Sub baixaTotalDocumentos(ByVal TipoPagPadrao As String, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim numDoc As String = ""
        For Each row As DataGridViewRow In Me.dtgContasAReceber.Rows

            _AReceberTotal.ZeraValores()
            If row.IsNewRow = False Then

                If row.Cells(0).Value Then
                    _AReceberTotal.art_id = row.Cells(1).Value
                    _AReceberTotalDAO.TrazContaAReceberDaLista(_AReceberTotal, _ListaAReceberTotal)
                    Select Case TipoPagPadrao
                        Case "DN"
                            _AReceberTotal.art_pagodinheiro += _AReceberTotal.art_valorrestante
                        Case "CTC"
                            _AReceberTotal.art_pagocartaocred += _AReceberTotal.art_valorrestante
                        Case "CTD"
                            _AReceberTotal.art_pagocartaodeb += _AReceberTotal.art_valorrestante
                        Case "PIX"
                            _AReceberTotal.art_pagopix += _AReceberTotal.art_valorrestante
                        Case "TRA"
                            _AReceberTotal.art_pagotransferencia += _AReceberTotal.art_valorrestante
                    End Select

                    _AReceberTotalDAO.altAReceberBaixaIndividual(_AReceberTotal, conexao, transacao)
                End If
            End If
        Next

    End Sub

    Private Sub dtgContasAReceber_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtgContasAReceber.RowsAdded

        Select Case _sitDoc
            Case "L"
                dtgContasAReceber.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumBlue
            Case "V"
                dtgContasAReceber.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            Case "E"
                dtgContasAReceber.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.MediumOrchid
            Case "N"
                If _diasVencidos > 0 Then dtgContasAReceber.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
                If CDbl(dtgContasAReceber.Rows(e.RowIndex).Cells(9).Value) > 0 Then
                    dtgContasAReceber.Rows(e.RowIndex).Cells(9).Style.ForeColor = Color.DarkGreen
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
            If dtgContasAReceber.CurrentRow.IsNewRow = False Then

                Dim mSit As String = dtgContasAReceber.CurrentRow.Cells(5).Value.ToString
                Select Case mSit
                    Case "L"
                        lbl_mensagem.Text = "CONTA A RECEBER já foi PAGA ! Não Pode ser Alterada!"
                        Return
                    Case "E"
                        lbl_mensagem.Text = "CONTA A RECEBER foi ESTORNADA ! Não Pode ser Alterada!"
                        Return
                    Case Else

                        _AReceberTotal.ZeraValores()
                        _AReceberTotal.art_id = dtgContasAReceber.CurrentRow.Cells(1).Value
                        _AReceberTotalDAO.TrazContaAReceberDaLista(_AReceberTotal, _ListaAReceberTotal)

                        Dim RecebRegistro As New FrmCadAReceber
                        RecebRegistro._AReceberTotal.SetaValores(_AReceberTotal)
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
        If dtgContasAReceber.RowCount <= 0 Then Return
        _AReceberTotal.ZeraValores()
        _AReceberTotal.art_id = dtgContasAReceber.CurrentRow.Cells(1).Value
        _AReceberTotalDAO.TrazContaAReceberDaLista(_AReceberTotal, _ListaAReceberTotal)

        If _AReceberTotal.art_id <= 0 Then
            lbl_mensagem.Text = "Selecione uma Conta A Recebe para Visualizar!"
            Return
        End If

        Dim frmCadAreceb As New FrmCadAReceber
        frmCadAreceb.operacao = "V" 'Visualização
        frmCadAreceb._AReceberTotal.SetaValores(_AReceberTotal)
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


        Dim mSituacao As String = dtgContasAReceber.CurrentRow.Cells(5).Value.ToString

        Select Case mSituacao
            Case "L"
                MsgBox("Conta Liquidada não pode ser Estornada!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                Return

            Case "E"
                MsgBox("Conta já Estornada!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                Return

        End Select


        lbl_mensagem.Text = "" : _idRecebimento = 0
        If dtgContasAReceber.CurrentRow.IsNewRow Then MsgBox("Selecione um Conta para Estornar!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper) : Return

        _AReceberTotal.art_id = dtgContasAReceber.CurrentRow.Cells(1).Value
        _AReceberTotalDAO.TrazContaAReceberDaLista(_AReceberTotal, MdlConexaoBD.ListaAReceberTotal)
        If MessageBox.Show("Deseja Realmente Estornar essa Conta: " & _AReceberTotal.art_valor.ToString("#,##0.00") & " ?", Application.CompanyName.ToUpper, MessageBoxButtons.YesNo) =
             Windows.Forms.DialogResult.No Then
            _AReceberTotal.ZeraValores()
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
            _AReceberTotal.art_id = dtgContasAReceber.CurrentRow.Cells(1).Value
            _AReceberTotalDAO.altAReceberEstornarConta(_AReceberTotal, conexao, transacao)
            transacao.Commit() : conexao.ClearAllPools() : conexao.Close()
            MsgBox("Estorno de Documento Efetuada com Sucesso !", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)

            _AReceberTotalDAO.TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
            _AReceberTotalDAO.TrazListAReceberBD(_ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
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

    Sub executaF11()

        consulta(_ListaAPagarTotalRelatorio)
        If _ListaAPagarTotalRelatorio.Count > 0 Then

            Dim mListaRelatorio As New List(Of ClAReceberTotal)
            Dim mAPagarT As New ClAReceberTotal
            For Each l As ClAReceberTotal In _ListaAPagarTotalRelatorio
                mAPagarT.ZeraValores()
                mAPagarT.SetaValores(l)
                mAPagarT.art_datapagamento = ""
                If IsDate(l.art_datapagamento) Then
                    mAPagarT.art_datapagamento = CDate(l.art_datapagamento).ToShortDateString & " " & CDate(l.art_datapagamento).ToShortTimeString
                End If
                mListaRelatorio.Add(New ClAReceberTotal(mAPagarT))
            Next

            Dim mFormulario As New FormListaContasAReceber
            mFormulario._ListaContasAReceber = mListaRelatorio
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

    Sub consulta(ByRef listaRelatorio As List(Of ClAReceberTotal))

        Dim mSituacao As String = "", mdtVencto As String = "", mDataPagamento As String = ""
        Dim mDataBetween As Boolean = False
        Dim mDias As Integer = 0


        listaRelatorio.Clear()
        dtgContasAReceber.Rows.Clear()

        If cbo_situacao.SelectedIndex > 0 Then
            mSituacao = cbo_situacao.SelectedItem.ToString.Substring(0, 1).ToUpper
        End If

        If rdb_emiss.Checked Then


            If mSituacao.Equals("") Then 'todos

                listaRelatorio = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            (FormatDateTime(ar.art_dataemissao, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.art_dataemissao, DateFormat.ShortDate).ToString <= dtpFim.Text))

            Else

                listaRelatorio = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            ar.art_situacao = mSituacao And _
                                                                            (FormatDateTime(ar.art_dataemissao, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.art_dataemissao, DateFormat.ShortDate).ToString <= dtpFim.Text))
            End If

        ElseIf rdb_pagamento.Checked Then


            If mSituacao.Equals("") Then


                For Each Ar As ClAReceberTotal In MdlConexaoBD.ListaAReceberTotal

                    'Inicio das condições:
                    If IsDate(Ar.art_datapagamento) Then

                        If Ar.art_clientenome.StartsWith(txt_portador.Text) Then

                            If (FormatDateTime(CDate(Ar.art_datapagamento), DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                (FormatDateTime(CDate(Ar.art_datapagamento), DateFormat.ShortDate).ToString <= dtpFim.Text) Then

                                listaRelatorio.Add(Ar)
                            End If
                        End If
                    End If

                Next

            Else


                For Each Ar As ClAReceberTotal In MdlConexaoBD.ListaAReceberTotal

                    'Inicio das condições:
                    If IsDate(Ar.art_datapagamento) Then

                        If Ar.art_clientenome.StartsWith(txt_portador.Text) Then

                            If Ar.art_situacao.Equals(mSituacao) Then

                                If (FormatDateTime(CDate(Ar.art_datapagamento), DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                (FormatDateTime(CDate(Ar.art_datapagamento), DateFormat.ShortDate).ToString <= dtpFim.Text) Then

                                    listaRelatorio.Add(Ar)
                                End If
                            End If
                        End If
                    End If

                Next

            End If

        ElseIf rdb_vencimento.Checked Then

            If mSituacao.Equals("") Then

                listaRelatorio = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            (FormatDateTime(ar.art_datavencimento, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.art_datavencimento, DateFormat.ShortDate).ToString <= dtpFim.Text))
            Else

                listaRelatorio = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            ar.art_situacao = mSituacao And _
                                                                            (FormatDateTime(ar.art_datavencimento, DateFormat.ShortDate).ToString >= dtpInicio.Text) And _
                                                                            (FormatDateTime(ar.art_datavencimento, DateFormat.ShortDate).ToString <= dtpFim.Text))
            End If

        Else

            If mSituacao.Equals("") Then

                listaRelatorio = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text))
            Else

                listaRelatorio = MdlConexaoBD.ListaAReceberTotal.FindAll(Function(ar As ClAReceberTotal) _
                                                                            ar.art_clientenome.StartsWith(txt_portador.Text) And _
                                                                            ar.art_situacao = mSituacao)
            End If

        End If


    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

End Class