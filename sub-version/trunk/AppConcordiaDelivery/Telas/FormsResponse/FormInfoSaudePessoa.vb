Imports Npgsql
Public Class FormInfoSaudePessoa

    Public _Cliente As New ClCliente
    Dim DaoCliente As New ClClienteDAO
    Dim _InfoSaudeP As New ClInfoSaudePessoa
    Dim _IMC As New ClIMC
    Dim _ItemInfoSaudeP As New ClInfoSaudePessoaItem
    Dim _ListaItems As New List(Of ClInfoSaudePessoaItem)
    Dim _ServicoDAO As New ClServicosDAO
    Dim _Servico As New ClServicos
    Dim _ProdutoDAO As New ClProdutoDAO
    Dim _Produto As New ClProduto
    Dim _ResultadoIMC As Double = 0
    Dim _funcoes As New ClFuncoes

    Private Sub FormInfoNutriPessoa_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FormInfoNutriPessoa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FormInfoNutriPessoa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _ServicoDAO.PreencheCboServicosLista(cboServico, MdlConexaoBD.ListaServicos)
        _ProdutoDAO.PreencheCboProdutosLista(cboProduto, MdlConexaoBD.ListaProdutos)
        _InfoSaudeP.setaValores(_InfoSaudeP.DAO.TrazInfoSaudePessoa_LISTA_PorIDPessoa(_Cliente, MdlConexaoBD.ListaInfoSaudePessoa))
        _ListaItems = _ItemInfoSaudeP.DAO.TrazINPessoaItem_LISTA_PorIDInfoNutri(_InfoSaudeP, MdlConexaoBD.ListaItemsInfoSaudePessoa)
        imgIMC.BackgroundImage = AppOtica.My.Resources.normal
        preencheCamposFormulario()

    End Sub

    Sub setaImagemIMC(vResultadoIMC As Double, vImc As ClIMC)

        txtClassificacao.Text = vImc.imc_classificacao
        txtCausas.Text = vImc.imc_problemas
        Select Case vImc.trazPadraoNumerico(vResultadoIMC, vImc)
            Case 1 '"MUITO ABAIXO DO PESO"
                imgIMC.BackgroundImage = AppOtica.My.Resources.muito_magra
                If vImc.imc_classificacao = 0 Then
                    txtClassificacao.Text = "MUITO ABAIXO DO PESO"
                    txtCausas.Text = "Queda de cabelo, infertilidade, ausência menstrual"
                End If
            Case 2 '"ABAIXO DO PESO"
                imgIMC.BackgroundImage = AppOtica.My.Resources.magra
            Case 3 '"PESO NORMAL"
                imgIMC.BackgroundImage = AppOtica.My.Resources.normal
            Case 4 '"ACIMA DO PESO"
                imgIMC.BackgroundImage = AppOtica.My.Resources.gorda
            Case 5 '"OBESIDADE GRAU 1"
                imgIMC.BackgroundImage = AppOtica.My.Resources.muito_gorda
            Case 6 '"OBESIDADE GRAU 2"
                imgIMC.BackgroundImage = AppOtica.My.Resources.muito_muito_gorda
            Case 7 '"OBESIDADE GRAU 3"
                imgIMC.BackgroundImage = AppOtica.My.Resources.muito_muito_muito_gorda
            Case Else
                imgIMC.BackgroundImage = Nothing
        End Select


    End Sub

    Sub setaImagemIMC_Relatorio(vResultadoIMC As Double, vImc As ClIMC, ByRef vImagem As Image)

        Select Case vImc.trazPadraoNumerico(vResultadoIMC, vImc)
            Case 1 '"MUITO ABAIXO DO PESO"
                vImagem = AppOtica.My.Resources.muito_magra
            Case 2 '"ABAIXO DO PESO"
                vImagem = AppOtica.My.Resources.magra
            Case 3 '"PESO NORMAL"
                vImagem = AppOtica.My.Resources.normal
            Case 4 '"ACIMA DO PESO"
                vImagem = AppOtica.My.Resources.gorda
            Case 5 '"OBESIDADE GRAU 1"
                vImagem = AppOtica.My.Resources.muito_gorda
            Case 6 '"OBESIDADE GRAU 2"
                vImagem = AppOtica.My.Resources.muito_muito_gorda
            Case 7 '"OBESIDADE GRAU 3"
                vImagem = AppOtica.My.Resources.muito_muito_muito_gorda
            Case Else
                vImagem = Nothing
        End Select


    End Sub

    Sub preencheCamposFormulario()

        txtIdCliente.Text = _Cliente.cid
        txtNomeCliente.Text = _Cliente.cnome
        txtPeso.Text = _InfoSaudeP.inp_pessoapeso.ToString("#,##0.000")
        txtAltura.Text = _InfoSaudeP.inp_pessoaaltura.ToString("#,##0.00")
        txtResultadoIMC.Text = _InfoSaudeP.inp_resultadoIMC.ToString("#,##0.00")
        calculaIMC()
        txtComorbidade1.Text = _InfoSaudeP.inp_comorbidade1
        txtComorbidade2.Text = _InfoSaudeP.inp_comorbidade2
        txtComorbidade3.Text = _InfoSaudeP.inp_comorbidade3
        txtComorbidade4.Text = _InfoSaudeP.inp_comorbidade4
        txtIdade.Text = _InfoSaudeP.inp_pessoaidade
        txtObservacao.Text = _InfoSaudeP.inp_observacao
        dtgItensInfoNutri.Rows.Clear()
        For Each item As ClInfoSaudePessoaItem In _ListaItems
            dtgItensInfoNutri.Rows.Add(item.inpi_servicoid, item.inpi_serviconome, item.inpi_produtoid, item.inpi_produtodescricao)
        Next

    End Sub

    Sub executeF2()

        If VerificaExisteServicoGrid(_Servico) Then
            MsgBox("Serviço """ & _Servico.sdescricao & """ Já adicionado! Excluir o Serviço Existente e Adicione um Novo!")
            Return
        End If

        If VerificaExisteProdutoGrid(_Produto) Then
            MsgBox("Produto """ & _Produto.pDescricao & """ Já adicionado! Excluir o Produto Existente e Adicione um Novo!")
            Return
        End If

        If _Servico.sid <= 0 And _Produto.pId <= 0 Then
            MsgBox("Selecione um Serviço ou um Produto para Adicionar!", MsgBoxStyle.Exclamation, Application.CompanyName)
            cboServico.Focus() : cboServico.DroppedDown = True
            Return
        End If

        dtgItensInfoNutri.Rows.Add(_Servico.sid, _Servico.sdescricao, _Produto.pId, _Produto.pDescricao)

    End Sub

    Function VerificaExisteServicoGrid(ByVal serv As ClServicos) As Boolean

        For Each s As DataGridViewRow In dtgItensInfoNutri.Rows

            If Not s.IsNewRow Then

                If CInt(s.Cells(0).Value) = serv.sid Then Return True
            End If
        Next

        Return False
    End Function

    Function VerificaExisteProdutoGrid(ByVal prod As ClProduto) As Boolean

        For Each s As DataGridViewRow In dtgItensInfoNutri.Rows

            If Not s.IsNewRow Then

                If CInt(s.Cells(2).Value) = prod.pId Then Return True
            End If
        Next

        Return False
    End Function

    Sub executeDeletaDtgRow()

        Try
            If dtgItensInfoNutri.CurrentRow.IsNewRow Then
                MsgBox("Selecione um Registro na Grade por favor!", MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
                Return
            Else
                dtgItensInfoNutri.Rows.RemoveAt(dtgItensInfoNutri.CurrentRow.Index)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub preencheListaITEMS()

        _ListaItems.Clear()
        For Each i As DataGridViewRow In dtgItensInfoNutri.Rows

            If i.IsNewRow = False Then

                _ItemInfoSaudeP.zeraValores()
                With _ItemInfoSaudeP
                    .inpi_produtoid = i.Cells(0).Value
                    .inpi_produtodescricao = i.Cells(1).Value.ToString
                    .inpi_servicoid = i.Cells(2).Value
                    .inpi_serviconome = i.Cells(3).Value.ToString
                End With
                _ListaItems.Add(New ClInfoSaudePessoaItem(_ItemInfoSaudeP))
            End If
        Next
    End Sub


    Sub setaCamposSaudePessoa()

        preencheListaITEMS()
        With _InfoSaudeP

            .inp_pessoaid = _Cliente.cid
            .inp_pessoanome = _Cliente.cnome
            .inp_imcid = _IMC.imc_id
            .inp_imcclassificacao = _IMC.imc_classificacao
            .inp_resultadoIMC = _ResultadoIMC
            .inp_pessoapeso = CDbl(txtPeso.Text)
            .inp_pessoaaltura = CDbl(txtAltura.Text)
            .inp_pessoaidade = CInt(txtIdade.Text)
            .inp_comorbidade1 = txtComorbidade1.Text
            .inp_comorbidade2 = txtComorbidade2.Text
            .inp_comorbidade3 = txtComorbidade3.Text
            .inp_comorbidade4 = txtComorbidade4.Text
            .inp_observacao = txtObservacao.Text
        End With
    End Sub

    Sub executeF7()

        setaCamposSaudePessoa()

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            Dim transacao As NpgsqlTransaction = connection.BeginTransaction
            If _InfoSaudeP.inp_id > 0 Then 'Alterando...

                _InfoSaudeP.DAO.update(_InfoSaudeP, connection, transacao)
                _ItemInfoSaudeP.DAO.deleteID_InfoN(_InfoSaudeP, connection, transacao)
                For Each i As ClInfoSaudePessoaItem In _ListaItems
                    i.inp_id = _InfoSaudeP.inp_id
                    _ItemInfoSaudeP.DAO.insert(i, connection, transacao)
                Next
                transacao.Commit()

            Else 'Incluindo...

                _InfoSaudeP.DAO.insert(_InfoSaudeP, connection, transacao)
                _InfoSaudeP.inp_id = _InfoSaudeP.DAO.TrazMaxIDInfoSaudePessoa_BD(connection, transacao)
                _ItemInfoSaudeP.DAO.deleteID_InfoN(_InfoSaudeP, connection, transacao)
                For Each i As ClInfoSaudePessoaItem In _ListaItems
                    i.inp_id = _InfoSaudeP.inp_id
                    _ItemInfoSaudeP.DAO.insert(i, connection, transacao)
                Next
                transacao.Commit()

            End If

            If MdlConexaoBD.sincronizado = False Then
                MdlConexaoBD.ListaInfoSaudePessoa = _InfoSaudeP.DAO.TrazListaInfoSaudePessoa_BD(MdlConexaoBD.conectionPadrao)
                MdlConexaoBD.ListaItemsInfoSaudePessoa = _ItemInfoSaudeP.DAO.TrazListaItemInfoNutriPessoa_BD(MdlConexaoBD.conectionPadrao)
            End If

        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub executeF11()

        Dim formulario As New FormRelatorioSaudePessoa
        formulario._SaudePessoa.setaValores(_InfoSaudeP)
        formulario._ListaItensSaudePessoa = _ListaItems
        setaImagemIMC_Relatorio(_ResultadoIMC, _IMC, formulario._imagem.IMAGEM)
        formulario._ComplicacaoIMC = _IMC.imc_problemas
        formulario.ShowDialog()
        formulario = Nothing

    End Sub

    Private Sub btnCalcularIMC_Click(sender As Object, e As EventArgs) Handles btnCalcularIMC.Click

        calculaIMC()
    End Sub

    Sub calculaIMC()

        If Not IsNumeric(txtPeso.Text) OrElse CDbl(txtPeso.Text) <= 0 Then txtResultadoIMC.Text = "0,00" : Return
        If Not IsNumeric(txtAltura.Text) OrElse CDbl(txtAltura.Text) <= 0 Then txtResultadoIMC.Text = "0,00" : Return
        Dim peso As Double, altura As Double
        peso = CDbl(txtPeso.Text)
        altura = CDbl(txtAltura.Text)
        _ResultadoIMC = (peso / (altura * altura))
        txtResultadoIMC.Text = _ResultadoIMC.ToString("#,##0.00")

        _IMC = _IMC.DAO.trazIMC_DaListaPorIMC(_ResultadoIMC, MdlConexaoBD.ListaIMC)
        setaImagemIMC(_ResultadoIMC, _IMC)
    End Sub

    Private Sub cboServico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServico.SelectedIndexChanged

        _Servico.ZeraValores()
        If cboServico.Text.Equals("") Then Return
        If cboServico.SelectedIndex > -1 Then 'Foi selecionado algum serviço:

            _Servico.sdescricao = cboServico.SelectedItem
            If _ServicoDAO.TrazServicoNomeDaLista(_Servico) = False Then
                MsgBox("Selecione um Serviço!") : cboServico.Focus() : cboServico.DroppedDown = True
                Return
            End If
        End If

    End Sub

    Private Sub cboProdutoUsado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProduto.SelectedIndexChanged

        _Produto.ZeraValores()
        If cboProduto.Text.Equals("") Then Return
        If cboProduto.SelectedIndex > -1 Then
            Dim mProd As String = cboProduto.SelectedItem
            _Produto.pId = CInt(Trim(mProd.Substring(mProd.Length - 4)))
            _ProdutoDAO.TrazProdutoDaListaPorID(_Produto, MdlConexaoBD.ListaProdutos)
        End If

    End Sub

    Private Sub txtPeso_Leave(sender As Object, e As EventArgs) Handles txtPeso.Leave

        If IsNumeric(txtPeso.Text) Then
            txtPeso.Text = CDbl(txtPeso.Text).ToString("#,##0.000")
        Else
            txtPeso.Text = "0,000"
        End If
    End Sub

    Private Sub txtAltura_Leave(sender As Object, e As EventArgs) Handles txtAltura.Leave

        If IsNumeric(txtAltura.Text) Then
            txtAltura.Text = CDbl(txtAltura.Text).ToString("#,##0.00")
        Else
            txtAltura.Text = "0,00"
        End If
    End Sub

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        executeF2()
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        executeDeletaDtgRow()
    End Sub

    Private Sub txtIdade_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdade.KeyPress
        'permite só numeros:
        If _funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeso.KeyPress, txtAltura.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtIdade_Leave(sender As Object, e As EventArgs) Handles txtIdade.Leave

        If IsNumeric(txtAltura.Text) Then
            txtAltura.Text = CInt(txtAltura.Text)
        Else
            txtAltura.Text = "0"
        End If
    End Sub

    Private Sub FormInfoSaudePessoa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If MdlConexaoBD.sincronizado = False Then
            executeF7()
        End If

    End Sub

    Private Sub txtPeso_GotFocus(sender As Object, e As EventArgs) Handles txtPeso.GotFocus
        txtPeso.SelectAll()
    End Sub

    Private Sub txtAltura_GotFocus(sender As Object, e As EventArgs) Handles txtAltura.GotFocus
        txtAltura.SelectAll()
    End Sub

    Private Sub txtComorbidade1_GotFocus(sender As Object, e As EventArgs) Handles txtComorbidade1.GotFocus
        txtComorbidade1.SelectAll()
    End Sub

    Private Sub txtComorbidade2_GotFocus(sender As Object, e As EventArgs) Handles txtComorbidade2.GotFocus
        txtComorbidade2.SelectAll()
    End Sub

    Private Sub txtComorbidade3_GotFocus(sender As Object, e As EventArgs) Handles txtComorbidade3.GotFocus
        txtComorbidade3.SelectAll()
    End Sub

    Private Sub txtComorbidade4_GotFocus(sender As Object, e As EventArgs) Handles txtComorbidade4.GotFocus
        txtComorbidade4.SelectAll()
    End Sub

    Private Sub txtIdade_GotFocus(sender As Object, e As EventArgs) Handles txtIdade.GotFocus
        txtIdade.SelectAll()
    End Sub

    Private Sub txtObservacao_GotFocus(sender As Object, e As EventArgs) Handles txtObservacao.GotFocus
        txtObservacao.SelectAll()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        executeF11()
    End Sub

End Class