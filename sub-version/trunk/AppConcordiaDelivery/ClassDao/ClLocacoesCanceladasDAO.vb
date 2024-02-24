Imports Npgsql
Public Class ClLocacoesCanceladasDAO

    Public Sub incLocacoesCanceladas(ByVal LocacoesCanceladas As ClLocacoesCanceladas, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO locacoes_canceladas(lc_id, lc_atendente_id, lc_atendente_nome, lc_produto_id, lc_produto_nome, "
        sql += "lc_tempo_programado, lc_tempo_inicial, lc_tempo_final, lc_valor_tempo, lc_valor_tempo_total, "
        sql += "lc_finalizado) VALUES (DEFAULT, @lc_atendente_id, @lc_atendente_nome, @lc_produto_id, @lc_produto_nome, "
        sql += "@lc_tempo_programado,  @lc_tempo_inicial, @lc_tempo_final, @lc_valor_tempo, "
        sql += "@lc_valor_tempo_total, @lc_finalizado)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@lc_atendente_id", LocacoesCanceladas.mAtendenteId)
        comm.Parameters.Add("@lc_atendente_nome", LocacoesCanceladas.mAtendenteNome)
        comm.Parameters.Add("@lc_produto_id", LocacoesCanceladas.mProdutoId)
        comm.Parameters.Add("@lc_produto_nome", LocacoesCanceladas.mProdutoNome)
        comm.Parameters.Add("@lc_tempo_programado", LocacoesCanceladas.mTempoProgramado)
        comm.Parameters.Add("@lc_tempo_inicial", LocacoesCanceladas.mTempoInicial)
        comm.Parameters.Add("@lc_tempo_final", LocacoesCanceladas.mTempoFinal)
        comm.Parameters.Add("@lc_valor_tempo", LocacoesCanceladas.mValorTempo)
        comm.Parameters.Add("@lc_valor_tempo_total", LocacoesCanceladas.mValorTempoTotal)
        comm.Parameters.Add("@lc_finalizado", LocacoesCanceladas.mFinalizado)
        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altLocacoesCanceladas(ByVal LocacoesCanceladas As ClLocacoesCanceladas, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE locacoes_canceladas SET lc_atendente_id = @lc_atendente_id, lc_atendente_nome = @lc_atendente_nome, "
        sql += "lc_produto_id = @lc_produto_id, lc_produto_nome = @lc_produto_nome, lc_tempo_programado = @lc_tempo_programado, "
        sql += "lc_tempo_inicial = @lc_tempo_inicial, lc_tempo_final = @lc_tempo_final, lc_tempo_acumulado = @lc_tempo_acumulado, "
        sql += "lc_valor_tempo = @lc_valor_tempo, lc_valor_tempo_total = @lc_valor_tempo_total, lc_finalizado = @lc_finalizado, "
        sql += "lc_tempo_excedido = @lc_tempo_excedido, lc_valor_tempo_excedido = @lc_valor_tempo_excedido, "
        sql += "lc_desconto = @lc_desconto, lc_valor_total_desconto = @lc_valor_total_desconto, lc_justificativa = @lc_justificativa WHERE lc_id = @lc_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@lc_id", LocacoesCanceladas.mId)
        comm.Parameters.Add("@lc_atendente_id", LocacoesCanceladas.mAtendenteId)
        comm.Parameters.Add("@lc_atendente_nome", LocacoesCanceladas.mAtendenteNome)
        comm.Parameters.Add("@lc_produto_id", LocacoesCanceladas.mProdutoId)
        comm.Parameters.Add("@lc_produto_nome", LocacoesCanceladas.mProdutoNome)
        comm.Parameters.Add("@lc_tempo_programado", LocacoesCanceladas.mTempoProgramado)
        comm.Parameters.Add("@lc_tempo_inicial", LocacoesCanceladas.mTempoInicial)
        comm.Parameters.Add("@lc_tempo_final", LocacoesCanceladas.mTempoFinal)
        comm.Parameters.Add("@lc_tempo_acumulado", LocacoesCanceladas.mTempoAcumulado)
        comm.Parameters.Add("@lc_valor_tempo", LocacoesCanceladas.mValorTempo)
        comm.Parameters.Add("@lc_valor_tempo_total", LocacoesCanceladas.mValorTempoTotal)
        comm.Parameters.Add("@lc_finalizado", LocacoesCanceladas.mFinalizado)
        comm.Parameters.Add("@lc_tempo_excedido", LocacoesCanceladas.mTempoExcedido)
        comm.Parameters.Add("@lc_valor_tempo_excedido", LocacoesCanceladas.mValorTempoExcedido)
        comm.Parameters.Add("@lc_desconto", LocacoesCanceladas.mDesconto)
        comm.Parameters.Add("@lc_valor_total_desconto", LocacoesCanceladas.mValorTotalDesconto)
        comm.Parameters.Add("@lc_justificativa", LocacoesCanceladas.mJustificativa)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazLocacaoCancelada(ByRef LocacoesCanceladas As ClLocacoesCanceladas, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""LocacoesCanceladasDAO:TrazLocacoesCanceladas"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT lc_id, lc_atendente_id, lc_atendente_nome, lc_produto_id, lc_produto_nome, lc_tempo_programado, " '5
        consulta += "lc_tempo_inicial, lc_tempo_final, lc_tempo_acumulado, lc_valor_tempo, lc_valor_tempo_total, " '10
        consulta += "lc_finalizado, lc_tempo_excedido, lc_valor_tempo_excedido, lc_data, lc_desconto, lc_valor_total_desconto, lc_justificativa FROM locacoes_canceladas WHERE lc_id = " & LocacoesCanceladas.mId
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            LocacoesCanceladas.mId = dr(0)
            LocacoesCanceladas.mAtendenteId = dr(1)
            LocacoesCanceladas.mAtendenteNome = dr(2).ToString
            LocacoesCanceladas.mProdutoId = dr(3)
            LocacoesCanceladas.mProdutoNome = dr(4).ToString
            LocacoesCanceladas.mTempoProgramado = dr(5)
            LocacoesCanceladas.mTempoInicial = dr(6)
            LocacoesCanceladas.mTempoFinal = dr(7)
            LocacoesCanceladas.mTempoAcumulado = dr(8)
            LocacoesCanceladas.mValorTempo = dr(9)
            LocacoesCanceladas.mValorTempoTotal = dr(10)
            LocacoesCanceladas.mFinalizado = dr(11)
            LocacoesCanceladas.mTempoExcedido = dr(12)
            LocacoesCanceladas.mValorTempoExcedido = dr(13)
            LocacoesCanceladas.mData = dr(14)
            LocacoesCanceladas.mDesconto = dr(15)
            LocacoesCanceladas.mValorTotalDesconto = dr(16)
            LocacoesCanceladas.mJustificativa = dr(17).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazListaLocacoesCanceladas(ByRef LocacoesCanceladas As List(Of ClLocacoesCanceladas), ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""LocacoesCanceladasDAO:TrazLocacoesCanceladas"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT lc_id, lc_atendente_id, lc_atendente_nome, lc_produto_id, lc_produto_nome, lc_tempo_programado, " '5
        consulta += "lc_tempo_inicial, lc_tempo_final, lc_tempo_acumulado, lc_valor_tempo, lc_valor_tempo_total, " '10
        consulta += "lc_finalizado, lc_tempo_excedido, lc_valor_tempo_excedido, lc_data, lc_desconto, lc_valor_total_desconto, lc_justificativa FROM locacoes_canceladas "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        If LocacoesCanceladas.Count > 0 Then LocacoesCanceladas.Clear()
        While dr.Read

            LocacoesCanceladas.Add(New ClLocacoesCanceladas(dr(0), dr(1), dr(2).ToString, dr(3), dr(4).ToString, dr(5), dr(6), dr(7), _
                                                                      dr(8), dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17).ToString))

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub delLocacoesCanceladas(ByVal LocacoesCanceladas As ClLocacoesCanceladas, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM locacoes_canceladas WHERE lc_id = @lc_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@lc_id", LocacoesCanceladas.mId)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delLocacoesCanceladas(ByVal LocacoesCanceladas As ClLocacoesCanceladas, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand
        Dim sql As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""LocacoesCanceladasDAO:TrazLocacoesCanceladas"":: " & ex.Message)
            Return
        End Try

        sql = "DELETE FROM locacoes_canceladas WHERE lc_id = @lc_id"
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@lc_id", LocacoesCanceladas.mId)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

End Class
