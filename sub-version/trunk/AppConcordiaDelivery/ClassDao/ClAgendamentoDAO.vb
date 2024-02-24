Imports Npgsql
Public Class ClAgendamentoDAO

    Dim _DaoItensAgendamento As New ClAgendamentoItemDAO

    Public Sub incAgendamento(ByVal Agendamento As ClAgendamento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO agendamento(a_id, a_dtemis, a_dtagend, a_status, a_iddoutor, a_doutor, a_valor, a_cancelado, "
        sql += "a_usuario, a_usuarioalt, a_financeiro, a_turno, a_info, a_pessoaid, a_pessoanome, a_empresanome, a_empresaid, a_hora) "
        sql += "VALUES (DEFAULT, @a_dtemis, @a_dtagend, @a_status, @a_iddoutor, @a_doutor, @a_valor, @a_cancelado, @a_usuario, "
        sql += "@a_usuarioalt, @a_financeiro, @a_turno, @a_info, @a_pessoaid, @a_pessoanome, @a_empresanome, @a_empresaid, @a_hora) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@a_dtemis", Agendamento.a_dtemis)
        comm.Parameters.Add("@a_dtagend", Agendamento.a_dtagend)
        comm.Parameters.Add("@a_status", Agendamento.a_status)
        comm.Parameters.Add("@a_iddoutor", Agendamento.a_iddoutor)
        comm.Parameters.Add("@a_doutor", Agendamento.a_doutor)
        comm.Parameters.Add("@a_valor", Agendamento.a_valor)
        comm.Parameters.Add("@a_cancelado", Agendamento.a_cancelado)
        comm.Parameters.Add("@a_usuario", Agendamento.a_usuario)
        comm.Parameters.Add("@a_usuarioalt", Agendamento.a_usuarioalt)
        comm.Parameters.Add("@a_financeiro", Agendamento.a_financeiro)
        comm.Parameters.Add("@a_turno", Agendamento.a_turno)
        comm.Parameters.Add("@a_info", Agendamento.a_info)
        comm.Parameters.Add("@a_pessoaid", Agendamento.a_pessoaid)
        comm.Parameters.Add("@a_pessoanome", Agendamento.a_pessoanome)
        comm.Parameters.Add("@a_empresanome", Agendamento.a_empresanome)
        comm.Parameters.Add("@a_empresaid", Agendamento.a_empresaid)
        comm.Parameters.Add("@a_hora", Agendamento.a_hora)

        comm.ExecuteNonQuery()

        TrazListAgendamentosBD(MdlConexaoBD.ListaAgendamentos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAgendamento(ByVal Agendamento As ClAgendamento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE agendamento SET a_dtagend = @a_dtagend, a_status = @a_status, a_iddoutor = @a_iddoutor, a_doutor = @a_doutor, "
        sql += "a_valor = @a_valor, a_cancelado = @a_cancelado, a_usuario = @a_usuario, a_usuarioalt = @a_usuarioalt, "
        sql += "a_financeiro = @a_financeiro, a_turno = @a_turno, a_info = @a_info, a_pessoaid = @a_pessoaid, a_pessoanome = @a_pessoanome, "
        sql += "a_empresanome = @a_empresanome, a_empresaid = @a_empresaid, a_hora = @a_hora, a_alterado = true WHERE a_id = @a_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@a_id", Agendamento.a_id)
        comm.Parameters.Add("@a_dtagend", Agendamento.a_dtagend)
        comm.Parameters.Add("@a_status", Agendamento.a_status)
        comm.Parameters.Add("@a_iddoutor", Agendamento.a_iddoutor)
        comm.Parameters.Add("@a_doutor", Agendamento.a_doutor)
        comm.Parameters.Add("@a_valor", Agendamento.a_valor)
        comm.Parameters.Add("@a_cancelado", Agendamento.a_cancelado)
        comm.Parameters.Add("@a_usuario", Agendamento.a_usuario)
        comm.Parameters.Add("@a_usuarioalt", Agendamento.a_usuarioalt)
        comm.Parameters.Add("@a_financeiro", Agendamento.a_financeiro)
        comm.Parameters.Add("@a_turno", Agendamento.a_turno)
        comm.Parameters.Add("@a_info", Agendamento.a_info)
        comm.Parameters.Add("@a_pessoaid", Agendamento.a_pessoaid)
        comm.Parameters.Add("@a_pessoanome", Agendamento.a_pessoanome)
        comm.Parameters.Add("@a_empresanome", Agendamento.a_empresanome)
        comm.Parameters.Add("@a_empresaid", Agendamento.a_empresaid)
        comm.Parameters.Add("@a_hora", Agendamento.a_hora)
        comm.ExecuteNonQuery()

        TrazListAgendamentosBD(MdlConexaoBD.ListaAgendamentos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListAgendamentosBD(ByRef Agendamento As List(Of ClAgendamento), ByVal strConection As String, Optional ByVal Where As String = "", _
                                      Optional ByVal OrderBy As String = "", Optional ByVal Atendente As ClAtendente = Nothing)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mAgendamento As New ClAgendamento

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AgendamentoDAO:TrazAgendamento"":: " & ex.Message)
            Return
        End Try

        Try
            If Atendente.aId > 0 Then
                consulta = "SELECT DISTINCT(a_id), a_dtemis, a_dtagend, a_status, a_iddoutor, a_doutor, a_valor, a_cancelado, a_usuario, a_usuarioalt, a_financeiro, a_turno, "
                consulta += "a_info, a_pessoaid, a_pessoanome, a_empresanome, a_empresaid, a_hora, a_alterado FROM agendamento LEFT JOIN agendamento_itens ON "
                consulta += "ag_id = a_id "
            Else
                consulta = "SELECT DISTINCT(a_id), a_dtemis, a_dtagend, a_status, a_iddoutor, a_doutor, a_valor, a_cancelado, a_usuario, a_usuarioalt, a_financeiro, a_turno, "
                consulta += "a_info, a_pessoaid, a_pessoanome, a_empresanome, a_empresaid, a_hora, a_alterado FROM agendamento "
            End If
        Catch ex As Exception

            consulta = "SELECT DISTINCT(a_id), a_dtemis, a_dtagend, a_status, a_iddoutor, a_doutor, a_valor, a_cancelado, a_usuario, a_usuarioalt, a_financeiro, a_turno, "
            consulta += "a_info, a_pessoaid, a_pessoanome, a_empresanome, a_empresaid, a_hora, a_alterado FROM agendamento "
        End Try


        If Not Where.Equals("") Then
            consulta += " " & Where
        End If
        If Not OrderBy.Equals("") Then
            consulta += " " & OrderBy
        End If

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Agendamento.Clear()
        While dr.Read

            mAgendamento.zeraValores()
            With mAgendamento

                .a_id = dr(0)
                .a_dtemis = dr(1)
                .a_dtagend = dr(2)
                .a_status = dr(3)
                .a_iddoutor = dr(4)
                .a_doutor = dr(5).ToString
                .a_valor = dr(6)
                .a_cancelado = dr(7)
                .a_usuario = dr(8).ToString
                .a_usuarioalt = dr(9).ToString
                .a_financeiro = dr(10)
                .a_turno = dr(11).ToString
                .a_info = dr(12).ToString
                .a_pessoaid = dr(13)
                .a_pessoanome = dr(14).ToString
                .a_empresanome = dr(15).ToString
                .a_empresaid = dr(16)
                .a_hora = dr(17).ToString
                .a_alterado = dr(18)
            End With

            Agendamento.Add(New ClAgendamento(mAgendamento))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazListAgendamentosDaLista(ByVal lista As List(Of ClAgendamento)) As List(Of ClAgendamento)

        Dim listaAlterada As New List(Of ClAgendamento)

        For Each a As ClAgendamento In lista
            listaAlterada.Add(New ClAgendamento(a))
        Next

        Return listaAlterada
    End Function

    Public Function TrazCountAgendamentosBD(ByVal strConection As String, Optional ByVal Where As String = "", _
                                      Optional ByVal OrderBy As String = "", Optional ByVal Atendente As ClAtendente = Nothing) As Int64

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mQuantidade As Int64 = 0

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AgendamentoDAO:TrazAgendamento"":: " & ex.Message)
            Return 0
        End Try

        Try
            If Atendente.aId > 0 Then
                consulta = "SELECT Count(a_id) FROM agendamento LEFT JOIN agendamento_itens ON "
                consulta += "ag_id = a_id "
            Else
                consulta = "SELECT Count(a_id) FROM agendamento "
            End If
        Catch ex As Exception
            consulta = "SELECT Count(a_id) FROM agendamento "
        End Try


        If Not Where.Equals("") Then
            consulta += " " & Where
        End If
        If Not OrderBy.Equals("") Then
            consulta += " " & OrderBy
        End If

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            mQuantidade = dr(0)
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return mQuantidade
    End Function

    Public Function TrazAgendamentoBD(ByRef Agendamento As ClAgendamento, ByVal strConection As String) As Boolean

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

        consulta = "SELECT a_id, a_dtemis, a_dtagend, a_status, a_iddoutor, a_doutor, a_valor, a_cancelado, a_usuario, a_usuarioalt, a_financeiro, a_turno, "
        consulta += "a_info, a_pessoaid, a_pessoanome, a_empresanome, a_empresaid, a_hora, a_alterado FROM agendamento WHERE a_id = @a_id"
        com = New NpgsqlCommand(consulta, conexao)
        com.Parameters.Add("@a_id", Agendamento.a_id)
        dr = com.ExecuteReader

        While dr.Read

            Agendamento.zeraValores()
            With Agendamento

                .a_id = dr(0)
                .a_dtemis = dr(1)
                .a_dtagend = dr(2)
                .a_status = dr(3)
                .a_iddoutor = dr(4)
                .a_doutor = dr(5).ToString
                .a_valor = dr(6)
                .a_cancelado = dr(7)
                .a_usuario = dr(8).ToString
                .a_usuarioalt = dr(9).ToString
                .a_financeiro = dr(10)
                .a_turno = dr(11).ToString
                .a_info = dr(12).ToString
                .a_pessoaid = dr(13)
                .a_pessoanome = dr(14).ToString
                .a_empresanome = dr(15).ToString
                .a_empresaid = dr(16)
                .a_hora = dr(17).ToString
                .a_alterado = dr(18)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazUltimoID(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Int64


        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mID As Int64 = 0

        Try
            If conexao.State = ConnectionState.Closed Then
                MsgBox("ERRO ao Abrir conexão em ""AgendamentoDAO:TrazUltimoID"":: Conexão não Aberta")
                Return 0
            End If
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AgendamentoDAO:TrazAgendamento"":: " & ex.Message)
            Return 0
        End Try

        consulta = "SELECT MAX(a_id) FROM agendamento"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read
            mID = dr(0)
        End While
        dr.Close()
        com.Dispose()

        Return mID
    End Function

    Public Sub delAgendamento(ByVal Agendamento As ClAgendamento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        _DaoItensAgendamento.delAgendamentoITEM(Agendamento, conexao, transacao)

        sql = "DELETE FROM agendamento WHERE a_id = @a_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@a_id", Agendamento.a_id)

        comm.ExecuteNonQuery()

        TrazListAgendamentosBD(MdlConexaoBD.ListaAgendamentos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

End Class
