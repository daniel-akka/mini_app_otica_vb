Imports Npgsql
Public Class ClProdutoUsadoDAO

    Dim _funcoes As New ClFuncoes

    Public Sub incProdutoUsado(ByVal ProdutoUsado As ClProdutoUsado, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO produtoUsado(puid, puidproduto, punomeproduto, puidservico, pudescrservico, puqtdeproduto, pudatahora)"
        sql += "VALUES (DEFAULT, @puidproduto, @punomeproduto, @puidservico, @pudescrservico, @puqtdeproduto, @pudatahora)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@puidproduto", ProdutoUsado.puidproduto)
        comm.Parameters.Add("@punomeproduto", ProdutoUsado.punomeproduto)
        comm.Parameters.Add("@puidservico", ProdutoUsado.puidservico)
        comm.Parameters.Add("@pudescrservico", ProdutoUsado.pudescrservico)
        comm.Parameters.Add("@puqtdeproduto", ProdutoUsado.puqtdeproduto)
        comm.Parameters.Add("@pudatahora", ProdutoUsado.pudatahora)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delProdutoUsado(ByVal ProdutoUsado As ClProdutoUsado, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM produtousado WHERE puid = @puid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@puid", ProdutoUsado.puid)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

End Class
