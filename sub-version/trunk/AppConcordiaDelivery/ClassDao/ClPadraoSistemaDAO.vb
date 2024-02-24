Imports Npgsql
Public Class ClPadraoSistemaDAO

    Public Sub TrazListPadraoSistema(ByRef PadraoSistema As List(Of ClPadraoSistema), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UnidadeDAO:TrazUnidade"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT psid, psnomesistema, psestado, pscidade FROM padrao_sistema LIMIT 1"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        PadraoSistema.Clear()
        While dr.Read

            PadraoSistema.Add(New ClPadraoSistema(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazPadraoSistema(ByRef PadraoSistema As ClPadraoSistema, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""PadraoSistemaAO:TrazPadraoSistema"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT psid, psnomesistema, psestado, pscidade FROM padrao_sistema LIMIT 1"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            PadraoSistema = New ClPadraoSistema(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString)
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function


End Class
