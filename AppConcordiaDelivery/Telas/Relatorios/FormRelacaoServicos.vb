Public Class FormRelacaoServicos

    Dim _Servico As New ClServicos
    Dim _Atendente As New ClAtendente

    Dim _ServicoDAO As New ClServicosDAO
    Dim _AtententeDAO As New ClAtendenteDAO

    Dim _ListaServicos As New List(Of ClServicos)
    Dim _RelatorioListaServicos As New List(Of ClServicos)
    Dim _RelatorioSTR As New ClRelatorioPadraoSTR
    Dim _RelatorioListaSTR As New List(Of ClRelatorioPadraoSTR)
    Dim _QtdeRegistro As Integer = 0
    Dim FiltroServico As String = ""
    Dim FiltroAtendente As String = ""

    Private Sub FormRelacaoServicos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executaF5()
            Case Keys.F11
                executaF11()
        End Select
    End Sub

    Sub executaF5()

        If cboSevico.Text.Equals("") Then _Servico.ZeraValores()

        _ListaServicos.Clear()

        _ListaServicos = _ServicoDAO.trazListaServico_LISTA(MdlConexaoBD.ListaServicos)
        '_ServicoDAO.TrazListServicos_BD(_ListaServicos, MdlConexaoBD.conectionPadrao)

        If _Servico.sid > 0 Then
            _ListaServicos = _ListaServicos.FindAll(Function(s As ClServicos) s.sid = _Servico.sid)
        End If

        If _Atendente.aId > 0 Then
            _ListaServicos = _ListaServicos.FindAll(Function(s As ClServicos) s.sidatendente = _Atendente.aId)
        End If

        dtgServicos.Rows.Clear()
        For Each s As ClServicos In _ListaServicos
            dtgServicos.Rows.Add(s.sid, s.sdescricao, s.snomeatendente, s.svalor.ToString("#,##0.00"), s.sdespcartaodinheiro.ToString("#,##0.00"), s.sdespcartaoporcentagem.ToString("#,##0.00"))
        Next

        txtRegistros.Text = dtgServicos.Rows.Count
    End Sub

    Sub executaF11()

        FiltroAtendente = ""
        FiltroServico = ""
        If _Servico.sid > 0 Then FiltroServico = _Servico.sdescricao
        If _Atendente.aId > 0 Then FiltroAtendente = _Atendente.aNome

        _ListaServicos.Clear()

        _ListaServicos = _ServicoDAO.trazListaServico_LISTA(MdlConexaoBD.ListaServicos)
        '_ServicoDAO.TrazListServicos_BD(_ListaServicos, MdlConexaoBD.conectionPadrao)

        If _Servico.sid > 0 Then
            _ListaServicos = _ListaServicos.FindAll(Function(s As ClServicos) s.sid = _Servico.sid)
        End If

        If _Atendente.aId > 0 Then
            _ListaServicos = _ListaServicos.FindAll(Function(s As ClServicos) s.sidatendente = _Atendente.aId)
        End If

        dtgServicos.Rows.Clear()
        _RelatorioListaSTR.Clear()
        For Each s As ClServicos In _ListaServicos

            _RelatorioSTR.zeraValores()
            With _RelatorioSTR
                .coluna1 = s.sid
                .coluna2 = s.sdescricao
                .coluna3 = s.snomeatendente
                .coluna4 = s.svalor.ToString("#,##0.00")
                .coluna5 = s.sdespcartaodinheiro.ToString("#,##0.00")
                .coluna6 = s.sdespcartaoporcentagem.ToString("#,##0.00")
            End With
            _RelatorioListaSTR.Add(New ClRelatorioPadraoSTR(_RelatorioSTR))
        Next


        Dim Formulario As New FormListaServicos
        Formulario._listaServicosSTR = _RelatorioListaSTR
        Formulario.QtdeRegistro = _ListaServicos.Count
        Formulario.FiltroServico = FiltroServico
        Formulario.FiltroAtendente = FiltroAtendente
        Formulario.ShowDialog()
        Formulario = Nothing


    End Sub

    Private Sub FormRelacaoServicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _ServicoDAO.PreencheCboServicosLista(cboSevico, MdlConexaoBD.ListaServicos)
        _AtententeDAO.PreencheCboAtendentesListaPesquisa(cboAtendente, MdlConexaoBD.ListaAtendentes)
        ExecutaF5()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        executaF5()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executaF11()
    End Sub

    Private Sub cboSevico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSevico.SelectedIndexChanged

        _Servico.ZeraValores()
        If cboSevico.SelectedIndex > -1 Then 'Foi selecionado algum serviço:

            _Servico.sdescricao = cboSevico.SelectedItem
            If _ServicoDAO.TrazServicoNomeDaLista(_Servico) = False Then
                MsgBox("Selecione um Serviço!") : cboSevico.Focus() : cboSevico.DroppedDown = True
                Return
            End If
            executaF5()
        End If

    End Sub

    Private Sub cboAtendente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAtendente.SelectedIndexChanged

        _Atendente.ZeraValores()
        Try
            If cboAtendente.SelectedIndex > -1 Then
                _Atendente.aNome = cboAtendente.SelectedItem.ToString
                _AtententeDAO.TrazAtendenteNomeDaLista(_Atendente, MdlConexaoBD.ListaAtendentes)
            End If
        Catch ex As Exception
        Finally
            If _Atendente.aId > -1 Then
                executaF5()
            End If
        End Try

    End Sub
End Class