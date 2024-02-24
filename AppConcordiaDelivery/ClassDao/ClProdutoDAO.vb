Imports Npgsql

Public Class ClProdutoDAO

    Dim _funcoes As New ClFuncoes

    Public Sub incProduto(ByVal Produto As ClProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO produto(pid, pdescricao, ppeso, pcodigo, pinformacao, pcusto, pmargemlucro, pvenda, pestoque, punidade, pdespadicional, "
        sql += "pgrupoid, pgrupodescricao, pmarcaid, pmarcanome, preferencia, pcor) "
        sql += "VALUES (DEFAULT, @pdescricao, @ppeso, @pcodigo, @pinformacao, @pcusto, @pmargemlucro, @pvenda, @pestoque, @punidade, @pdespadicional, "
        sql += "@pgrupoid, @pgrupodescricao, @pmarcaid, @pmarcanome, @preferencia, @pcor)"

        'pgrupoid integer DEFAULT 0,
        'pgrupodescricao character varying,
        'pmarcaid integer NOT NULL DEFAULT 0,
        'pmarcanome character varying,
        'preferencia character varying,
        'pcor character varying(40),
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@pdescricao", Produto.pDescricao)
        comm.Parameters.Add("@ppeso", Produto.pPeso)
        comm.Parameters.Add("@pcodigo", Produto.pCodigo)
        comm.Parameters.Add("@pinformacao", Produto.pInformacao)
        comm.Parameters.Add("@pcusto", Produto.pCusto)
        comm.Parameters.Add("@pmargemlucro", Produto.pMargemLucro)
        comm.Parameters.Add("@pvenda", Produto.pVenda)
        comm.Parameters.Add("@pestoque", Produto.pEstoque)
        comm.Parameters.Add("@punidade", Produto.pUnidade)
        comm.Parameters.Add("@pdespadicional", Produto.pDespAdicional)
        comm.Parameters.Add("@pgrupoid", Produto.p_IdGrupo)
        comm.Parameters.Add("@pgrupodescricao", Produto.p_Grupo)
        comm.Parameters.Add("@pmarcaid", Produto.p_IdMarca)
        comm.Parameters.Add("@pmarcanome", Produto.p_Marca)
        comm.Parameters.Add("@preferencia", Produto.p_Referencia)
        comm.Parameters.Add("@pcor", Produto.p_Cor)

        comm.ExecuteNonQuery()

        TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListProdutos_LISTA(ByRef NovaListaProdutos As List(Of ClProduto), ByVal ListProdutos As List(Of ClProduto))

        Dim Produto As New ClProduto
        NovaListaProdutos.Clear()
        For Each lp As ClProduto In ListProdutos

            Produto.ZeraValores()
            Produto.setaValores(lp)
            NovaListaProdutos.Add(New ClProduto(Produto))
        Next

    End Sub

    Public Sub altProduto(ByVal Produto As ClProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE produto SET pdescricao = @pdescricao, pcodigo = @pcodigo, ppeso = @ppeso, pinformacao = @pinformacao, "
        sql += "pcusto = @pcusto, pmargemlucro = @pmargemlucro, pvenda = @pvenda, pestoque = @pestoque, punidade = @punidade, "
        sql += "pdespadicional = @pdespadicional, pgrupoid = @pgrupoid, pgrupodescricao = @pgrupodescricao, pmarcaid = @pmarcaid, "
        sql += "pmarcanome = @pmarcanome, preferencia = @preferencia, pcor = @pcor WHERE pid = @pid"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@pid", Produto.pId)
        comm.Parameters.Add("@pdescricao", Produto.pDescricao)
        comm.Parameters.Add("@ppeso", Produto.pPeso)
        comm.Parameters.Add("@pcodigo", Produto.pCodigo)
        comm.Parameters.Add("@pinformacao", Produto.pInformacao)
        comm.Parameters.Add("@pcusto", Produto.pCusto)
        comm.Parameters.Add("@pmargemlucro", Produto.pMargemLucro)
        comm.Parameters.Add("@pvenda", Produto.pVenda)
        comm.Parameters.Add("@pestoque", Produto.pEstoque)
        comm.Parameters.Add("@punidade", Produto.pUnidade)
        comm.Parameters.Add("@pdespadicional", Produto.pDespAdicional)
        comm.Parameters.Add("@pgrupoid", Produto.p_IdGrupo)
        comm.Parameters.Add("@pgrupodescricao", Produto.p_Grupo)
        comm.Parameters.Add("@pmarcaid", Produto.p_IdMarca)
        comm.Parameters.Add("@pmarcanome", Produto.p_Marca)
        comm.Parameters.Add("@preferencia", Produto.p_Referencia)
        comm.Parameters.Add("@pcor", Produto.p_Cor)

        comm.ExecuteNonQuery()

        TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaProduto(ByVal Produto As ClProduto, Optional ByVal Operacao As String = "I") As Boolean
        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT pid FROM produto WHERE pid = " & Produto.pId
        Else
            consulta = "SELECT pid FROM produto WHERE pid <> " & Produto.pId & " AND pdescricao = '" & Produto.pDescricao & "'"
        End If
        If ProdutoConsulta(Produto, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Produto """ & Produto.pDescricao & """ já existe em outro Cadastro !", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        If Produto.pVenda <= 0 Then
            MsgBox("O Preço de Venda do Produto Precisa ser Maior Que 0 !", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        Return True
    End Function

    Public Function ProdutoConsulta(ByRef Produto As ClProduto, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:TrazPRODUTO"":: " & ex.Message)
            Return False
        End Try

        consulta = Query
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader
        If dr.HasRows Then
            Return True
        Else
            Return False
        End If

        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazProduto(ByRef Produto As ClProduto, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:TrazPRODUTO"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT pid, pdescricao, ppeso, pcodigo, pinformacao, pcusto, pmargemlucro, pvenda, pestoque, punidade, pdespadicional, " '10
        consulta += "pgrupoid, pgrupodescricao, pmarcaid, pmarcanome, preferencia, pcor " '16
        consulta += "FROM produto WHERE pid = " & Produto.pId
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Produto.pId = dr(0)
            Produto.pDescricao = dr(1).ToString
            Produto.pPeso = dr(2)
            Produto.pCodigo = dr(3).ToString
            Produto.pInformacao = dr(4).ToString
            Produto.pCusto = dr(5)
            Produto.pMargemLucro = dr(6)
            Produto.pVenda = dr(7)
            Produto.pEstoque = dr(8)
            Produto.pUnidade = dr(9).ToString
            Produto.pDespAdicional = dr(10)
            Produto.p_IdGrupo = dr(11)
            Produto.p_Grupo = dr(12).ToString
            Produto.p_IdMarca = dr(13)
            Produto.p_Marca = dr(14).ToString
            Produto.p_Referencia = dr(15).ToString
            Produto.p_Cor = dr(16).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub TrazProdutoDaListaPorID(ByRef vProduto As ClProduto, ByVal ListProdutos As List(Of ClProduto))


        For Each p As ClProduto In ListProdutos
            If p.pId.Equals(vProduto.pId) Then

                With vProduto

                    .pId = p.pId
                    .pCodigo = p.pCodigo
                    .pDescricao = p.pDescricao
                    .pInformacao = p.pInformacao
                    .pVenda = p.pVenda
                    .pPeso = p.pPeso
                    .pCusto = p.pCusto
                    .pMargemLucro = p.pMargemLucro
                    .pEstoque = p.pEstoque
                    .pUnidade = p.pUnidade
                    .pDespAdicional = p.pDespAdicional
                    .p_IdGrupo = p.p_IdGrupo
                    .p_Grupo = p.p_Grupo
                    .p_IdMarca = p.p_IdMarca
                    .p_Marca = p.p_Marca
                    .p_Referencia = p.p_Referencia
                    .p_Cor = p.p_Cor

                End With
                Exit For
            End If

        Next

    End Sub

    Public Sub TrazListProdutosBD(ByRef Produto As List(Of ClProduto), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:TrazListPRODUTOS"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT pid, pcodigo, pmargemlucro, pcusto, pvenda, pestoque, punidade, pdescricao, pinformacao, ppeso, pdespadicional, " '10
        consulta += "pgrupoid, pgrupodescricao, pmarcaid, pmarcanome, preferencia, pcor FROM produto "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Produto.Clear()
        While dr.Read

            Produto.Add(New ClProduto(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6).ToString, dr(7).ToString, dr(8).ToString, dr(9), dr(10), _
                                      dr(11), dr(12).ToString, dr(13), dr(14).ToString, dr(15).ToString, dr(16).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboProdutosBD(ByRef cboProduto As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:PreencheCboProdutos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT pdescricao, pid FROM produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY pdescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboProduto.Items.Clear()
        If dr.HasRows = True Then
            cboProduto.AutoCompleteCustomSource.Clear()
            cboProduto.Items.Clear()
            cboProduto.Refresh()
            While dr.Read

                cboProduto.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboProduto.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboProduto.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboProdutosLista(ByRef cboProduto As ComboBox, ByVal listProd As List(Of ClProduto))



        If listProd.Count > 0 Then

            cboProduto.AutoCompleteCustomSource.Clear()
            cboProduto.Items.Clear()
            cboProduto.Refresh()

            For Each p As ClProduto In listProd
                cboProduto.AutoCompleteCustomSource.Add(p.pDescricao & " - " & p.pId.ToString.PadLeft(5, " "))
                cboProduto.Items.Add(p.pDescricao & " - " & p.pId.ToString.PadLeft(5, " "))
            Next
        End If

    End Sub

    Public Sub PreencheCboProdutosRelatorio(ByRef cboProduto As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:PreencheCboProdutosRelatorio"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT pdescricao, pid FROM produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY pdescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboProduto.Items.Clear()
        If dr.HasRows = True Then
            cboProduto.AutoCompleteCustomSource.Clear()
            cboProduto.Items.Clear()
            cboProduto.Refresh()
            cboProduto.AutoCompleteCustomSource.Add("< TODOS >")
            cboProduto.Items.Add("< TODOS >")
            While dr.Read

                cboProduto.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboProduto.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboProduto.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboProdutosConsulta(ByRef cboCliente As ComboBox, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoDAO:PreencheCboProdutosConsulta"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT pdescricao, pid FROM produto ORDER BY pdescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboCliente.Items.Clear()
        If dr.HasRows = True Then
            cboCliente.AutoCompleteCustomSource.Clear()
            cboCliente.Items.Clear()
            cboCliente.Refresh()
            While dr.Read

                cboCliente.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboCliente.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboCliente.AutoCompleteMode = AutoCompleteMode.Suggest
            cboCliente.AutoCompleteSource = AutoCompleteSource.ListItems
            cboCliente.Refresh()
            cboCliente.SelectedIndex = -1

        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delProduto(ByVal Produto As ClProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM produto WHERE pid = @pid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@pid", Produto.pId)

        comm.ExecuteNonQuery()

        TrazListProdutosBD(MdlConexaoBD.ListaProdutos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

End Class
