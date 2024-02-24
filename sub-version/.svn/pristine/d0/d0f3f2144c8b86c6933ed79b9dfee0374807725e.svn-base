Imports Npgsql
Public Class ClTermoResponsabilidadeDAO

    Public Sub inctermo(ByVal termo As ClTermoResponsabilidade, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO termo(tr_id, termo1, termo2, termo3, termo4)"
        sql += "VALUES (DEFAULT, @termo1, @termo2, @termo3, @termo4)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@termo1", termo.trTermo1)
        comm.Parameters.Add("@termo2", termo.trTermo2)
        comm.Parameters.Add("@termo3", termo.trTermo3)
        comm.Parameters.Add("@termo4", termo.trTermo4)
        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub alttermo(ByVal termo As ClTermoResponsabilidade, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE termo SET termo1 = @termo1, termo2 = @termo2, termo3 = @termo3, termo4 = @termo4 WHERE tr_id = @tr_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@tr_id", termo.trId)
        comm.Parameters.Add("@termo1", termo.trTermo1)
        comm.Parameters.Add("@termo2", termo.trTermo2)
        comm.Parameters.Add("@termo3", termo.trTermo3)
        comm.Parameters.Add("@termo4", termo.trTermo4)
        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub alttermo(ByVal termo As ClTermoResponsabilidade, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand
        Dim sql As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""termoDAO:Traztermo"":: " & ex.Message)
        End Try


        sql = "UPDATE termo SET termo1 = @termo1, termo2 = @termo2, termo3 = @termo3, termo4 = @termo4 WHERE tr_id = @tr_id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@tr_id", termo.trId)
        comm.Parameters.Add("@termo1", termo.trTermo1)
        comm.Parameters.Add("@termo2", termo.trTermo2)
        comm.Parameters.Add("@termo3", termo.trTermo3)
        comm.Parameters.Add("@termo4", termo.trTermo4)
        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Function Traztermo(ByRef termo As ClTermoResponsabilidade, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""termoDAO:Traztermo"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT tr_id, termo1, termo2, termo3, termo4 FROM termo LIMIT 1" 'WHERE tr_id = " & termo.trId & " 
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            termo.trId = dr(0)
            termo.trTermo1 = dr(1).ToString
            termo.trTermo2 = dr(2).ToString
            termo.trTermo3 = dr(3).ToString
            termo.trTermo4 = dr(4).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub deltermo(ByVal termo As ClTermoResponsabilidade, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM termo WHERE tr_id = @tr_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@tr_id", termo.trId)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing

    End Sub

End Class
