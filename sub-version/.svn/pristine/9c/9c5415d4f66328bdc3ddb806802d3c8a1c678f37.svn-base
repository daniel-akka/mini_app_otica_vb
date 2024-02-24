Imports Npgsql
Public Class ClComissaoDAO

    Public Sub incComissao(ByVal Comissao As ClComissao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO comissao(c_id, c_atendenteid, c_atendentenome, c_datapagamento, c_valorpago, c_observacao, c_empresaid, c_empresanome) "
        sql += "VALUES (DEFAULT, @c_atendenteid, @c_atendentenome, @c_datapagamento, @c_valorpago, @c_observacao, @c_empresaid, @c_empresanome)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@c_atendenteid", Comissao.c_atendenteid)
        comm.Parameters.Add("@c_atendentenome", Comissao.c_atendentenome)
        comm.Parameters.Add("@c_datapagamento", Comissao.c_datapagamento)
        comm.Parameters.Add("@c_valorpago", Comissao.c_valorpago)
        comm.Parameters.Add("@c_observacao", Comissao.c_observacao)
        comm.Parameters.Add("@c_empresaid", Comissao.c_empresaid)
        comm.Parameters.Add("@c_empresanome", Comissao.c_empresanome)

        comm.ExecuteNonQuery()


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delComissao(ByVal Comissao As ClComissao, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE comissao SET c_deletada = true WHERE c_id = @c_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@c_id", Comissao.c_id)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

    Public Sub TrazListComissoes(ByRef Comissao As List(Of ClComissao), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mComissao As New ClComissao

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AtendenteDAO:TrazListComissoes"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT c_id, c_atendenteid, c_atendentenome, c_datapagamento, c_valorpago, c_observacao, c_empresaid, "
        consulta += "c_empresanome, c_deletada FROM comissao "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Comissao.Clear()
        While dr.Read

            With mComissao

                .c_id = dr(0)
                .c_atendenteid = dr(1)
                .c_atendentenome = dr(2).ToString
                .c_datapagamento = dr(3)
                .c_valorpago = dr(4)
                .c_observacao = dr(5).ToString
                .c_empresaid = dr(6)
                .c_empresanome = dr(7).ToString
                .c_deletada = dr(8)
            End With

            Comissao.Add(New ClComissao(mComissao))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazComissaoDaLista(ByRef Comissao As ClComissao, ByVal ListaComissao As List(Of ClComissao)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ClComissao In ListaComissao

            If a.c_id = Comissao.c_id Then

                With Comissao

                    .c_id = a.c_id
                    .c_atendenteid = a.c_atendenteid
                    .c_atendentenome = a.c_atendentenome
                    .c_datapagamento = a.c_datapagamento
                    .c_valorpago = a.c_valorpago
                    .c_observacao = a.c_observacao
                    .c_empresaid = a.c_empresaid
                    .c_empresanome = a.c_empresanome
                    .c_deletada = a.c_deletada
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

End Class
