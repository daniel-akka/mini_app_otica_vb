Imports Npgsql
Public Class ClProdutoUsadoVendaDAO

    Dim _funcoes As New ClFuncoes

    Public Sub incProdutoUsadoVenda(ByVal ProdutoUsado As ClProdutoUsadoVenda, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO produtousadovenda(puvid, puvidproduto, puvnomeproduto, puvidservico, puvdescrservico, puvqtdeproduto, puvdatahora, puvidvenda)"
        sql += "VALUES (DEFAULT, @puvidproduto, @puvnomeproduto, @puvidservico, @puvdescrservico, @puvqtdeproduto, @puvdatahora, @puvidvenda)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@puvidproduto", ProdutoUsado.puvidproduto)
        comm.Parameters.Add("@puvnomeproduto", ProdutoUsado.puvnomeproduto)
        comm.Parameters.Add("@puvidservico", ProdutoUsado.puvidservico)
        comm.Parameters.Add("@puvdescrservico", ProdutoUsado.puvdescrservico)
        comm.Parameters.Add("@puvqtdeproduto", ProdutoUsado.puvqtdeproduto)
        comm.Parameters.Add("@puvdatahora", ProdutoUsado.puvdatahora)
        comm.Parameters.Add("@puvidvenda", ProdutoUsado.puvidVenda)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListProdutoUsadoVenda(ByVal VendaServico As ClVendaServico, ByRef ProdutosUsadosVenda As List(Of ClProdutoUsadoVenda), ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClProdutoUsadoVendaVendaDAO:TrazListProdutoUsadoVenda"":: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End Try

        consulta = "SELECT puvdatahora, puvid, puvidproduto, puvidservico, puvnomeproduto, puvdescrservico, puvqtdeproduto, puvidvenda " '5
        consulta += "FROM produtousadovenda WHERE puvidvenda = " & VendaServico.vsid
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        ProdutosUsadosVenda.Clear()
        While dr.Read

            ProdutosUsadosVenda.Add(New ClProdutoUsadoVenda(dr(0), dr(1), dr(2), dr(3), dr(4).ToString, dr(5).ToString, _
                                                dr(6), dr(7)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delProdutoUsadoVenda(ByVal ProdutoUsado As ClProdutoUsadoVenda, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM produtousadovenda WHERE puvid = @puvid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@puvid", ProdutoUsado.puvid)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

End Class
