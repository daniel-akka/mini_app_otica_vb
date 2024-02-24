Imports Npgsql
Public Class ClAgendamentoItemDAO

    Public Sub incItemAgendamento(ByVal Agendamento As ClAgendamento, ByVal Item As ClAgendamentoItens, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO agendamento_itens(agi_id, ag_id, agi_codserv, agi_descrserv, agi_dtemis, agi_valor, agi_qtde, "
        sql += "agi_total, agi_atendenteid, agi_atendentenome) "
        sql += "VALUES (DEFAULT, @ag_id, @agi_codserv, @agi_descrserv, @agi_dtemis, @agi_valor, @agi_qtde, "
        sql += "@agi_total, @agi_atendenteid, @agi_atendentenome)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@ag_id", Agendamento.a_id)
        comm.Parameters.Add("@agi_codserv", Item.agi_codserv)
        comm.Parameters.Add("@agi_descrserv", Item.agi_descrserv)
        comm.Parameters.Add("@agi_dtemis", Item.agi_dtemis)
        comm.Parameters.Add("@agi_valor", Item.agi_valor)
        comm.Parameters.Add("@agi_qtde", Item.agi_qtde)
        comm.Parameters.Add("@agi_total", Item.agi_total)
        comm.Parameters.Add("@agi_atendenteid", Item.agi_atendenteid)
        comm.Parameters.Add("@agi_atendentenome", Item.agi_atendentenome)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altItemAgendamento(ByVal Agendamento As ClAgendamento, ByVal Item As ClAgendamentoItens, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE agendamento_itens SET ag_id = @ag_id, agi_codserv = @agi_codserv, agi_descrserv = @agi_descrserv, agi_dtemis = @agi_dtemis, agi_valor = @agi_valor, "
        sql += "agi_qtde = @agi_qtde, agi_total = @agi_total, agi_atendenteid = @agi_atendenteid, agi_atendentenome = @agi_atendentenome WHERE agi_id = @agi_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@agi_id", Item.agi_id)
        comm.Parameters.Add("@ag_id", Agendamento.a_id)
        comm.Parameters.Add("@agi_codserv", Item.agi_codserv)
        comm.Parameters.Add("@agi_descrserv", Item.agi_descrserv)
        comm.Parameters.Add("@agi_dtemis", Item.agi_dtemis)
        comm.Parameters.Add("@agi_valor", Item.agi_valor)
        comm.Parameters.Add("@agi_qtde", Item.agi_qtde)
        comm.Parameters.Add("@agi_total", Item.agi_total)
        comm.Parameters.Add("@agi_atendenteid", Item.agi_atendenteid)
        comm.Parameters.Add("@agi_atendentenome", Item.agi_atendentenome)
        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListItensAgendamentoBD(ByVal Agendamento As ClAgendamento, ByRef AgendamentoItens As List(Of ClAgendamentoItens), ByVal strConection As String, _
                                          Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mItem As New ClAgendamentoItens


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AgendamentoDAO:TrazAgendamento"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT agi_id, ag_id, agi_codserv, agi_descrserv, agi_dtemis, agi_valor, agi_qtde, agi_total, agi_atendenteid, agi_atendentenome "
        consulta += "FROM agendamento_itens WHERE ag_id = " & Agendamento.a_id
        If Not condicao.Equals("") Then
            consulta += " " & condicao
        End If
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        AgendamentoItens.Clear()
        While dr.Read

            mItem.zeraValores()
            With mItem

                .agi_id = dr(0)
                .AG_ID = dr(1)
                .agi_codserv = dr(2)
                .agi_descrserv = dr(3)
                .agi_dtemis = dr(4)
                .agi_valor = dr(5)
                .agi_qtde = dr(6)
                .agi_total = dr(7)
                .agi_atendenteid = dr(8)
                .agi_atendentenome = dr(9).ToString
            End With

            AgendamentoItens.Add(New ClAgendamentoItens(mItem))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazItemAgendamentoBD(ByRef Item As ClAgendamentoItens, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AgendamentoDAO:TrazAgendamento"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT agi_id, ag_id, agi_codserv, agi_descrserv, agi_dtemis, agi_valor, agi_qtde, agi_total, agi_atendenteid, agi_atendentenome "
        consulta += "FROM agendamento_itens WHERE agi_id = @agi_id"
        com = New NpgsqlCommand(consulta, conexao)
        com.Parameters.Add("@agi_id", Item.agi_id)
        dr = com.ExecuteReader

        While dr.Read

            Item.zeraValores()
            With Item

                .agi_id = dr(0)
                .AG_ID = dr(1)
                .agi_codserv = dr(2)
                .agi_descrserv = dr(3)
                .agi_dtemis = dr(4)
                .agi_valor = dr(5)
                .agi_qtde = dr(6)
                .agi_total = dr(7)
                .agi_atendenteid = dr(8)
                .agi_atendentenome = dr(9).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub delAgendamentoITEM(ByVal Item As ClAgendamentoItens, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM agendamento_itens WHERE agi_id = @agi_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@agi_id", Item.agi_id)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delAgendamentoItem(ByVal Agendamento As ClAgendamento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM agendamento_itens WHERE ag_id = @ag_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@ag_id", Agendamento.a_id)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

End Class
