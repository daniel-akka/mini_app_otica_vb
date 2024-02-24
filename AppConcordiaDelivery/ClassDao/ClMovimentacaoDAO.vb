Imports Npgsql
Public Class ClMovimentacaoDAO


    Public Sub incMovimentacao(ByVal Movimentacao As ClMovimentacao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO movimentacao(m_id, m_atendente_id, m_atendente_nome, m_produto_id, m_produto_nome, "
        sql += "m_tempo_programado, m_tempo_inicial, m_tempo_final, m_valor_tempo, m_valor_tempo_total, "
        sql += "m_finalizado, m_iniciado) VALUES (DEFAULT, @m_atendente_id, @m_atendente_nome, @m_produto_id, @m_produto_nome, "
        sql += "@m_tempo_programado,  @m_tempo_inicial, @m_tempo_final, @m_valor_tempo, "
        sql += "@m_valor_tempo_total, @m_finalizado, @m_iniciado)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@m_atendente_id", Movimentacao.mAtendenteId)
        comm.Parameters.Add("@m_atendente_nome", Movimentacao.mAtendenteNome)
        comm.Parameters.Add("@m_produto_id", Movimentacao.mProdutoId)
        comm.Parameters.Add("@m_produto_nome", Movimentacao.mProdutoNome)
        comm.Parameters.Add("@m_tempo_programado", Movimentacao.mTempoProgramado)
        comm.Parameters.Add("@m_tempo_inicial", Movimentacao.mTempoInicial)
        comm.Parameters.Add("@m_tempo_final", Movimentacao.mTempoFinal)
        comm.Parameters.Add("@m_valor_tempo", Movimentacao.mValorTempo)
        comm.Parameters.Add("@m_valor_tempo_total", Movimentacao.mValorTempoTotal)
        comm.Parameters.Add("@m_finalizado", Movimentacao.mFinalizado)
        comm.Parameters.Add("@m_iniciado", Movimentacao.mIniciado)
        comm.ExecuteNonQuery()

        'TrazListaMovimentacaoNaoFinalizada(MdlConexaoBD.mdlListLocacoesNaoFinalizadas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altMovimentacao(ByVal Movimentacao As ClMovimentacao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE movimentacao SET m_atendente_id = @m_atendente_id, m_atendente_nome = @m_atendente_nome, "
        sql += "m_produto_id = @m_produto_id, m_produto_nome = @m_produto_nome, m_tempo_programado = @m_tempo_programado, "
        sql += "m_tempo_inicial = @m_tempo_inicial, m_tempo_final = @m_tempo_final, m_tempo_acumulado = @m_tempo_acumulado, "
        sql += "m_valor_tempo = @m_valor_tempo, m_valor_tempo_total = @m_valor_tempo_total, m_finalizado = @m_finalizado, "
        sql += "m_tempo_excedido = @m_tempo_excedido, m_valor_tempo_excedido = @m_valor_tempo_excedido, "
        sql += "m_desconto = @m_desconto, m_valor_total_desconto = @m_valor_total_desconto, m_justificativa = @m_justificativa, "
        sql += "m_iniciado = @m_iniciado WHERE m_id = @m_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@m_id", Movimentacao.mId)
        comm.Parameters.Add("@m_atendente_id", Movimentacao.mAtendenteId)
        comm.Parameters.Add("@m_atendente_nome", Movimentacao.mAtendenteNome)
        comm.Parameters.Add("@m_produto_id", Movimentacao.mProdutoId)
        comm.Parameters.Add("@m_produto_nome", Movimentacao.mProdutoNome)
        comm.Parameters.Add("@m_tempo_programado", Movimentacao.mTempoProgramado)
        comm.Parameters.Add("@m_tempo_inicial", Movimentacao.mTempoInicial)
        comm.Parameters.Add("@m_tempo_final", Movimentacao.mTempoFinal)
        comm.Parameters.Add("@m_tempo_acumulado", Movimentacao.mTempoAcumulado)
        comm.Parameters.Add("@m_valor_tempo", Movimentacao.mValorTempo)
        comm.Parameters.Add("@m_valor_tempo_total", Movimentacao.mValorTempoTotal)
        comm.Parameters.Add("@m_finalizado", Movimentacao.mFinalizado)
        comm.Parameters.Add("@m_tempo_excedido", Movimentacao.mTempoExcedido)
        comm.Parameters.Add("@m_valor_tempo_excedido", Movimentacao.mValorTempoExcedido)
        comm.Parameters.Add("@m_desconto", Movimentacao.mDesconto)
        comm.Parameters.Add("@m_valor_total_desconto", Movimentacao.mValorTotalDesconto)
        comm.Parameters.Add("@m_justificativa", Movimentacao.mJustificativa)
        comm.Parameters.Add("@m_iniciado", Movimentacao.mIniciado)

        comm.ExecuteNonQuery()


        'TrazListaMovimentacaoNaoFinalizada(MdlConexaoBD.mdlListLocacoesNaoFinalizadas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altMovimentacao(ByVal Movimentacao As ClMovimentacao, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand
        Dim sql As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MovimentacaoDAO:TrazMovimentacao"":: " & ex.Message)
            Return
        End Try

        sql = "UPDATE movimentacao SET m_atendente_id = @m_atendente_id, m_atendente_nome = @m_atendente_nome, "
        sql += "m_produto_id = @m_produto_id, m_produto_nome = @m_produto_nome, m_tempo_programado = @m_tempo_programado, "
        sql += "m_tempo_inicial = @m_tempo_inicial, m_tempo_final = @m_tempo_final, m_tempo_acumulado = @m_tempo_acumulado, "
        sql += "m_valor_tempo = @m_valor_tempo, m_valor_tempo_total = @m_valor_tempo_total, m_finalizado = @m_finalizado, "
        sql += "m_tempo_excedido = @m_tempo_excedido, m_valor_tempo_excedido = @m_valor_tempo_excedido, "
        sql += "m_desconto = @m_desconto, m_valor_total_desconto = @m_valor_total_desconto, m_justificativa = @m_justificativa, "
        sql += "m_iniciado = @m_iniciado WHERE m_id = @m_id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@m_id", Movimentacao.mId)
        comm.Parameters.Add("@m_atendente_id", Movimentacao.mAtendenteId)
        comm.Parameters.Add("@m_atendente_nome", Movimentacao.mAtendenteNome)
        comm.Parameters.Add("@m_produto_id", Movimentacao.mProdutoId)
        comm.Parameters.Add("@m_produto_nome", Movimentacao.mProdutoNome)
        comm.Parameters.Add("@m_tempo_programado", Movimentacao.mTempoProgramado)
        comm.Parameters.Add("@m_tempo_inicial", Movimentacao.mTempoInicial)
        comm.Parameters.Add("@m_tempo_final", Movimentacao.mTempoFinal)
        comm.Parameters.Add("@m_tempo_acumulado", Movimentacao.mTempoAcumulado)
        comm.Parameters.Add("@m_valor_tempo", Movimentacao.mValorTempo)
        comm.Parameters.Add("@m_valor_tempo_total", Movimentacao.mValorTempoTotal)
        comm.Parameters.Add("@m_finalizado", Movimentacao.mFinalizado)
        comm.Parameters.Add("@m_tempo_excedido", Movimentacao.mTempoExcedido)
        comm.Parameters.Add("@m_valor_tempo_excedido", Movimentacao.mValorTempoExcedido)
        comm.Parameters.Add("@m_desconto", Movimentacao.mDesconto)
        comm.Parameters.Add("@m_valor_total_desconto", Movimentacao.mValorTotalDesconto)
        comm.Parameters.Add("@m_justificativa", Movimentacao.mJustificativa)
        comm.Parameters.Add("@m_iniciado", Movimentacao.mIniciado)

        comm.ExecuteNonQuery()


        'TrazListaMovimentacaoNaoFinalizada(MdlConexaoBD.mdlListLocacoesNaoFinalizadas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    'Public Function ValidaMovimentacao(ByVal Movimentacao As ClMovimentacao, Optional ByVal Operacao As String = "I") As Boolean

    '    If Trim(Movimentacao.pCodigo).Equals("") Then
    '        MsgBox("O Codigo """ & Movimentacao.pCodigo & """ já existe em outro Movimentacao !") : Return False
    '    End If

    '    Return True
    'End Function

    Public Function verificaMovimentacaoQuery(ByVal strConection As String, Optional ByVal Query As String = "") As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim retorno As Boolean = False
        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MovimentacaoDAO:TrazMovimentacao"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT m_id, m_atendente_id, m_atendente_nome, m_produto_id, m_produto_nome, m_tempo_programado, " '5
        consulta += "m_tempo_inicial, m_tempo_final, m_tempo_acumulado, m_valor_tempo, m_valor_tempo_total, " '10
        consulta += "m_finalizado, m_tempo_excedido, m_valor_tempo_excedido, m_data, m_iniciado  FROM movimentacao "
        If Trim(Query).Equals("") = False Then consulta += Query

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        If dr.HasRows Then retorno = True

        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return retorno
    End Function

    Public Function TrazMovimentacao(ByRef Movimentacao As ClMovimentacao, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MovimentacaoDAO:TrazMovimentacao"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT m_id, m_atendente_id, m_atendente_nome, m_produto_id, m_produto_nome, m_tempo_programado, " '5
        consulta += "m_tempo_inicial, m_tempo_final, m_tempo_acumulado, m_valor_tempo, m_valor_tempo_total, " '10
        consulta += "m_finalizado, m_tempo_excedido, m_valor_tempo_excedido, m_data, m_desconto, m_valor_total_desconto, " '16
        consulta += "m_iniciado FROM movimentacao WHERE m_id = " & Movimentacao.mId
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Movimentacao.mId = dr(0)
            Movimentacao.mAtendenteId = dr(1)
            Movimentacao.mAtendenteNome = dr(2).ToString
            Movimentacao.mProdutoId = dr(3)
            Movimentacao.mProdutoNome = dr(4).ToString
            Movimentacao.mTempoProgramado = dr(5)
            Movimentacao.mTempoInicial = dr(6)
            Movimentacao.mTempoFinal = dr(7)
            Movimentacao.mTempoAcumulado = dr(8)
            Movimentacao.mValorTempo = dr(9)
            Movimentacao.mValorTempoTotal = dr(10)
            Movimentacao.mFinalizado = dr(11)
            Movimentacao.mTempoExcedido = dr(12)
            Movimentacao.mValorTempoExcedido = dr(13)
            Movimentacao.mData = dr(14)
            Movimentacao.mDesconto = dr(15)
            Movimentacao.mValorTotalDesconto = dr(16)
            Movimentacao.mIniciado = dr(17)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazListaMovimentacaoNaoFinalizada(ByRef Movimentacao As List(Of ClMovimentacao), ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MovimentacaoDAO:TrazMovimentacao"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT m_id, m_atendente_id, m_atendente_nome, m_produto_id, m_produto_nome, m_tempo_programado, " '5
        consulta += "m_tempo_inicial, m_tempo_final, m_tempo_acumulado, m_valor_tempo, m_valor_tempo_total, " '10
        consulta += "m_finalizado, m_tempo_excedido, m_valor_tempo_excedido, m_data, m_desconto, m_valor_total_desconto, m_iniciado " '17 
        consulta += " FROM movimentacao WHERE m_finalizado = false"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        If Movimentacao.Count > 0 Then Movimentacao.Clear()
        While dr.Read

            Movimentacao.Add(New ClMovimentacao(dr(0), dr(1), dr(2).ToString, dr(3), dr(4).ToString, dr(5), dr(6), dr(7),
                                                                      dr(8), dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17)))

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazListaMovimentacoesFinalizadas(ByRef Movimentacao As List(Of ClMovimentacao), ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MovimentacaoDAO:TrazMovimentacao"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT m_id, m_atendente_id, m_atendente_nome, m_produto_id, m_produto_nome, m_tempo_programado, " '5
        consulta += "m_tempo_inicial, m_tempo_final, m_tempo_acumulado, m_valor_tempo, m_valor_tempo_total, " '10
        consulta += "m_finalizado, m_tempo_excedido, m_valor_tempo_excedido, m_data, m_desconto, m_valor_total_desconto, m_iniciado " '17 
        consulta += " FROM movimentacao WHERE m_finalizado = true"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        If Movimentacao.Count > 0 Then Movimentacao.Clear()
        While dr.Read

            Movimentacao.Add(New ClMovimentacao(dr(0), dr(1), dr(2).ToString, dr(3), dr(4).ToString, dr(5), dr(6), dr(7),
                                                                      dr(8), dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17)))

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub TrazListaMovimentacoesNaoFinalizadas(ByRef Movimentacao As List(Of ClMovimentacao), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MovimentacaoDAO:TrazMovimentacao"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT m_id, m_atendente_id, m_atendente_nome, m_produto_id, m_produto_nome, m_tempo_programado, " '5
        consulta += "m_tempo_inicial, m_tempo_final, m_tempo_acumulado, m_valor_tempo, m_valor_tempo_total, " '10
        consulta += "m_finalizado, m_tempo_excedido, m_valor_tempo_excedido, m_data, m_desconto, m_valor_total_desconto, m_iniciado " '17 
        consulta += " FROM movimentacao WHERE m_finalizado = false"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        If Movimentacao.Count > 0 Then Movimentacao.Clear()
        While dr.Read

            Movimentacao.Add(New ClMovimentacao(dr(0), dr(1), dr(2).ToString, dr(3), dr(4).ToString, dr(5), dr(6), dr(7),
                                                                      dr(8), dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17)))

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return
    End Sub

    Public Sub delMovimentacao(ByVal Movimentacao As ClMovimentacao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM movimentacao WHERE m_id = @m_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@m_id", Movimentacao.mId)

        comm.ExecuteNonQuery()

        'TrazListaMovimentacaoNaoFinalizada(MdlConexaoBD.mdlListLocacoesNaoFinalizadas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delMovimentacao(ByVal Movimentacao As ClMovimentacao, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand
        Dim sql As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MovimentacaoDAO:TrazMovimentacao"":: " & ex.Message)
            Return
        End Try

        sql = "DELETE FROM movimentacao WHERE m_id = @m_id"
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@m_id", Movimentacao.mId)

        comm.ExecuteNonQuery()

        'TrazListaMovimentacaoNaoFinalizada(MdlConexaoBD.mdlListLocacoesNaoFinalizadas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

End Class
