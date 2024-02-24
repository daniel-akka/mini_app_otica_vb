Imports Npgsql

Public Class ClConfiguracoesDAO

    Public Sub altConfiguracoes(ByVal Config As ClConfiguracoes, ByVal strConection As String)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        Dim conexao As New NpgsqlConnection(strConection)
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AtendenteDAO:TrazAtendente"":: " & ex.Message)
            Return
        End Try

        sql = "UPDATE configuracoes SET limite_desconto = @limite_desconto, senha_padrao = @senha_padrao, diasvenccrediario = @diasvenccrediario, "
        sql += "caminho_logo = @caminho_logo, caminho_pasta_sgbd = @caminho_pasta_sgbd, caminho_pasta_sistema = @caminho_pasta_sistema, "
        sql += "caminho_pasta_sincronizar = @caminho_pasta_sincronizar WHERE idconfg = @idconfg"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@idconfg", Config.tId)
        comm.Parameters.Add("@limite_desconto", Config.tLimiteDesconto)
        comm.Parameters.Add("@senha_padrao", Config.tSenhaPadrao)
        comm.Parameters.Add("@diasvenccrediario", Config.tDiasVencCrediario)
        comm.Parameters.Add("@caminho_logo", Config.caminho_logo)
        comm.Parameters.Add("@caminho_pasta_sgbd", Config.caminho_pasta_sgb)
        comm.Parameters.Add("@caminho_pasta_sistema", Config.caminho_pasta_sistema)
        comm.Parameters.Add("@caminho_pasta_sincronizar", Config.caminho_pasta_Sincronizar)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazConfiguracoesID(ByRef Config As ClConfiguracoes, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexao em ""ConfiguracoesDAO:TrazConfiguracoesID"":: " & ex.Message, MsgBoxStyle.Critical, Application.CompanyName.ToUpper)
            Return False
        End Try

        consulta = "SELECT idconfg, limite_desconto, senha_padrao, diasvenccrediario, caminho_logo, caminho_pasta_sgbd, "
        consulta += "caminho_pasta_sistema, caminho_pasta_sincronizar FROM configuracoes LIMIT 1"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With Config
                .tId = dr(0)
                .tLimiteDesconto = dr(1)
                .tSenhaPadrao = dr(2).ToString
                .tDiasVencCrediario = dr(3)
                .caminho_logo = dr(4).ToString
                .caminho_pasta_sgb = dr(5).ToString
                .caminho_pasta_sistema = dr(6).ToString
                .caminho_pasta_Sincronizar = dr(7).ToString
            End With
            

        End While

        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

End Class
