Imports Npgsql
Public Class ClProdutoServicoDAO

    Public Sub incProdutoServico(ByVal ProdutoServico As ClProdutoServico, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO produtoservico(psid, psidservico, psidproduto, psprodutodescricao, psquantidade)"
        sql += "VALUES (DEFAULT, @psidservico, @psidproduto, @psprodutodescricao, @psquantidade)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@psidservico", ProdutoServico.psIdServico)
        comm.Parameters.Add("@psidproduto", ProdutoServico.psIdProduto)
        comm.Parameters.Add("@psprodutodescricao", ProdutoServico.psProdutoDescricao)
        comm.Parameters.Add("@psquantidade", ProdutoServico.psQuantidade)

        comm.ExecuteNonQuery()

        TrazListProdutosServico(MdlConexaoBD.mdlListProdutosServico, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delProdutoServico(ByVal Servico As ClServicos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM produtoservico WHERE psidservico = @psidservico"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@psidservico", Servico.sid)

        comm.ExecuteNonQuery()

        TrazListProdutosServico(MdlConexaoBD.mdlListProdutosServico, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Sub TrazListProdutosServico(ByRef ProdutoServico As List(Of ClProdutoServico), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoServicoDAO:TrazListProdutosServico"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT psid, psidservico, psidproduto, psprodutodescricao, psquantidade FROM produtoservico "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        ProdutoServico.Clear()
        While dr.Read

            ProdutoServico.Add(New ClProdutoServico(dr(0), dr(1), dr(2), dr(3).ToString, dr(4)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazProdutosDoServicoBanco(ByVal Servico As ClServicos, ByRef ProdutoServico As List(Of ClProdutoServico), ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ProdutoServicoDAO:TrazProdutosDoServicoBanco"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT psid, psidservico, psidproduto, psprodutodescricao, psquantidade FROM produtoservico WHERE psidservico = " & Servico.sid
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            ProdutoServico.Add(New ClProdutoServico(dr(0), dr(1), dr(2), dr(3).ToString, dr(4)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazProdutosDoServicoLista(ByVal Servico As ClServicos, ByVal ProdutoServicoTodos As List(Of ClProdutoServico), _
                                               ByRef ProdutoServico As List(Of ClProdutoServico)) As Boolean

        If ProdutoServicoTodos.Exists(Function(ps As ClProdutoServico) ps.psIdServico = Servico.sid) Then

            ProdutoServico = ProdutoServicoTodos.FindAll(Function(ps As ClProdutoServico) ps.psIdServico = Servico.sid)
        Else
            Return False
        End If

        Return True
    End Function
End Class
