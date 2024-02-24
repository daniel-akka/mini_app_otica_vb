Imports Npgsql
Public Class ClEntradaSaidaDAO

    Public Sub incEntradaSaida(ByVal EntradaSaida As ClEntradaSaida, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = " INSERT INTO entrada_saida(esid, esdata, estipo, esmotivo, esusuarioid, esusuarionome, esfornecedorid, "
        sql += "esfornecedornome, esprodutoid, esprodutonome, esquantidade, esdatamovimentacao, esobservacao) "
        sql += "VALUES (DEFAULT, DEFAULT, @estipo, @esmotivo, @esusuarioid, @esusuarionome, @esfornecedorid, "
        sql += "@esfornecedornome, @esprodutoid, @esprodutonome, @esquantidade, @esdatamovimentacao, @esobservacao)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@estipo", EntradaSaida.estipo)
        comm.Parameters.Add("@esmotivo", EntradaSaida.esmotivo)
        comm.Parameters.Add("@esusuarioid", EntradaSaida.esusuarioid)
        comm.Parameters.Add("@esusuarionome", EntradaSaida.esusuarionome)
        comm.Parameters.Add("@esfornecedorid", EntradaSaida.esfornecedorid)
        comm.Parameters.Add("@esfornecedornome", EntradaSaida.esfornecedornome)
        comm.Parameters.Add("@esprodutoid", EntradaSaida.esprodutoid)
        comm.Parameters.Add("@esprodutonome", EntradaSaida.esprodutonome)
        comm.Parameters.Add("@esquantidade", EntradaSaida.esquantidade)
        comm.Parameters.Add("@esdatamovimentacao", EntradaSaida.esdatamovimentacao)
        comm.Parameters.Add("@esobservacao", EntradaSaida.esobservacao)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListEntradaSaida(ByRef EntradaSaida As List(Of ClEntradaSaida), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntradaSaidaDAO:TrazEntradaSaida"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT esid, estipo, esmotivo, esusuarioid, esusuarionome, esfornecedorid, esfornecedornome, "
        consulta += "esprodutoid, esprodutonome, esquantidade, esdata, esdatamovimentacao, esobservacao FROM entrada_saida "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        EntradaSaida.Clear()
        While dr.Read

            EntradaSaida.Add(New ClEntradaSaida(dr(0), dr(1).ToString, dr(2).ToString, dr(3), dr(4).ToString, _
                                                dr(5), dr(6).ToString, dr(7), dr(8).ToString, dr(9), dr(10), dr(11), dr(12).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListEntradaSaidaConsulta(ByRef EntradaSaida As List(Of ClEntradaSaida), ByVal Query As String, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EntradaSaidaDAO:TrazEntradaSaida"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT esid, estipo, esmotivo, esusuarioid, esusuarionome, esfornecedorid, esfornecedornome, "
        consulta += "esprodutoid, esprodutonome, esquantidade, esdata, esdatamovimentacao, esobservacao FROM entrada_saida "
        If Not Query.Equals("") Then consulta += "WHERE " & Query
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        EntradaSaida.Clear()
        While dr.Read

            EntradaSaida.Add(New ClEntradaSaida(dr(0), dr(1).ToString, dr(2).ToString, dr(3), dr(4).ToString, _
                                                dr(5), dr(6).ToString, dr(7), dr(8).ToString, dr(9), dr(10), dr(11), dr(12).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub altEntradaSaida(ByVal EntradaSaida As ClEntradaSaida, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE entrada_saida SET esmotivo = @esmotivo, esfornecedorid = @esfornecedorid, esfornecedornome = @esfornecedornome, "
        sql += "esprodutoid = @esprodutoid, esprodutonome = @esprodutonome, esquantidade = @esquantidade, esobservacao = @esobservacao, "
        sql += "esdatamovimentacao = @esdatamovimentacao WHERE esid = @esid"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@esid", EntradaSaida.esid)
        comm.Parameters.Add("@esmotivo", EntradaSaida.esmotivo)
        comm.Parameters.Add("@esfornecedorid", EntradaSaida.esfornecedorid)
        comm.Parameters.Add("@esfornecedornome", EntradaSaida.esfornecedornome)
        comm.Parameters.Add("@esprodutoid", EntradaSaida.esprodutoid)
        comm.Parameters.Add("@esprodutonome", EntradaSaida.esprodutonome)
        comm.Parameters.Add("@esquantidade", EntradaSaida.esquantidade)
        comm.Parameters.Add("@esdatamovimentacao", EntradaSaida.esdatamovimentacao)
        comm.Parameters.Add("@esobservacao", EntradaSaida.esobservacao)
        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delEntradaSaida(ByVal EntradaSaida As ClEntradaSaida, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM entrada_saida WHERE esid = @esid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@esid", EntradaSaida.esid)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

End Class
