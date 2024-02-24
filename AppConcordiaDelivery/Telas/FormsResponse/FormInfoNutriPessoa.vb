Imports Npgsql
Public Class FormInfoNutriPessoa

    Public _Cliente As New ClCliente
    Dim DaoCliente As New ClClienteDAO
    Dim InfoNutriP As New ClInfoNutriPessoa
    Dim _IMC As New ClIMC
    Dim ItemInfoNutriP As New ClInfoNutriPessoaItem
    Dim ListaItems As New List(Of ClInfoNutriPessoaItem)
    Dim _ServicoDAO As New ClServicosDAO
    Dim _Servico As New ClServicos
    Dim _ProdutoDAO As New ClProdutoDAO
    Dim _Produto As New ClProduto

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

        InfoNutriP = InfoNutriP.DAO.TrazInfoNutriPessoa_LISTA_PorIDPessoa(_Cliente, MdlConexaoBD.ListaInfoNutriPessoa)
        ListaItems = ItemInfoNutriP.DAO.TrazINPessoaItem_LISTA_PorIDInfoNutri(InfoNutriP, MdlConexaoBD.ListaItemsInfoNutriPessoa)
        If InfoNutriP.inp_id > 0 Then preencheCampos()
    End Sub

    Sub preencheCampos()

        txtIdCliente.Text = _Cliente.cid
        txtNomeCliente.Text = _Cliente.cnome
        txtPeso.Text = InfoNutriP.inp_pessoapeso.ToString("#,##0.000")
        txtAltura.Text = InfoNutriP.inp_pessoaaltura.ToString("#,##0.00")
        txtResultadoIMC.Text = InfoNutriP.inp_resultadoIMC.ToString("#,##0.00")
        txtProblema1.Text = InfoNutriP.inp_problema1
        txtProblema2.Text = InfoNutriP.inp_problema2
        txtProblema3.Text = InfoNutriP.inp_problema3
        txtProblema4.Text = InfoNutriP.inp_problema4
        txtObservacao.Text = InfoNutriP.inp_observacao
        dtgItensInfoNutri.Rows.Clear()
        For Each item As ClInfoNutriPessoaItem In ListaItems
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

    Sub executeDel()

    End Sub

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

    Sub executeF7()

    End Sub

    Sub executeF11()

    End Sub

    Private Sub btnCalcularIMC_Click(sender As Object, e As EventArgs) Handles btnCalcularIMC.Click

        calculaIMC()
    End Sub

    Sub calculaIMC()

        If Not IsNumeric(txtPeso.Text) OrElse CDbl(txtPeso.Text) <= 0 Then txtResultadoIMC.Text = "0,00" : Return
        If Not IsNumeric(txtAltura.Text) OrElse CDbl(txtAltura.Text) <= 0 Then txtResultadoIMC.Text = "0,00" : Return
        Dim peso As Double, altura As Double, resultado As Double
        peso = CDbl(txtPeso.Text)
        altura = CDbl(txtAltura.Text)
        resultado = (peso / (altura * altura))
        txtResultadoIMC.Text = resultado.ToString("#,##0.00")

        _IMC = _IMC.DAO.trazIMC_DaListaPorIMC(resultado, MdlConexaoBD.ListaIMC)
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

End Class