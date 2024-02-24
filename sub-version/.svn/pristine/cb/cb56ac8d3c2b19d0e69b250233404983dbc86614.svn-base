Imports Npgsql
Public Class ClCaixaDAO

    Public Sub incCaixa(ByVal caixa As ClCaixa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO caixa(cx_id, cx_tipo, cx_datahora, cx_motivo, cx_af_id, cx_valor, cx_tipo_valor)  "
        sql += "VALUES (DEFAULT, @cx_tipo, @cx_datahora, @cx_motivo, @cx_af_id, @cx_valor, @cx_tipo_valor)"


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cx_tipo", caixa.Cx_tipo1)
        comm.Parameters.Add("@cx_datahora", caixa.Cx_datahora1)
        comm.Parameters.Add("@cx_motivo", caixa.Cx_motivo1)
        comm.Parameters.Add("@cx_af_id", caixa.Cx_af_id1)
        comm.Parameters.Add("@cx_valor", caixa.Cx_valor1)
        comm.Parameters.Add("@cx_tipo_valor", caixa.Cx_tipo_valor1)
        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altCaixa(ByVal caixa As ClCaixa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE caixa SET cx_tipo=@cx_tipo, cx_datahora=@cx_datahora, cx_motivo=@cx_motivo, cx_af_id=@cx_af_id, cx_valor=@cx_valor, "
        sql += "cx_tipo_valor=@cx_tipo_valor WHERE cx_id = @cx_id"


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cx_id", caixa.Cx_id1)
        comm.Parameters.Add("@cx_tipo", caixa.Cx_tipo1)
        comm.Parameters.Add("@cx_datahora", caixa.Cx_datahora1)
        comm.Parameters.Add("@cx_motivo", caixa.Cx_motivo1)
        comm.Parameters.Add("@cx_af_id", caixa.Cx_af_id1)
        comm.Parameters.Add("@cx_valor", caixa.Cx_valor1)
        comm.Parameters.Add("@cx_tipo_valor", caixa.Cx_tipo_valor1)


        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altCaixa(ByVal caixa As ClCaixa, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim comm As NpgsqlCommand
        Dim sql As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AbrirFecharDAO:altAbrirFechar"":: " & ex.Message)
            Return
        End Try

        sql = "UPDATE caixa SET cx_tipo=@cx_tipo, cx_datahora=@cx_datahora, cx_motivo=@cx_motivo, cx_af_id=@cx_af_id, cx_valor=@cx_valor, "
        sql += "cx_tipo_valor=@cx_tipo_valor WHERE cx_id = @cx_id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cx_id", caixa.Cx_id1)
        comm.Parameters.Add("@cx_tipo", caixa.Cx_tipo1)
        comm.Parameters.Add("@cx_datahora", caixa.Cx_datahora1)
        comm.Parameters.Add("@cx_motivo", caixa.Cx_motivo1)
        comm.Parameters.Add("@cx_af_id", caixa.Cx_af_id1)
        comm.Parameters.Add("@cx_valor", caixa.Cx_valor1)
        comm.Parameters.Add("@cx_tipo_valor", caixa.Cx_tipo_valor1)

        comm.ExecuteNonQuery()


        'TrazListaMovimentacaoNaoFinalizada(MdlConexaoBD.mdlListLocacoesNaoFinalizadas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazAbrirFechar(ByRef abrir_fechar As ClAbrirFecharCaixa, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AbrirFecharDAO:TrazAbrirFechar"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT af_id, af_datahora, af_tipo, af_concluido FROM abrir_fechar WHERE af_id = " & abrir_fechar.Af_id1
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            abrir_fechar.Af_id1 = dr(0)
            abrir_fechar.Af_datahora1 = dr(1)
            abrir_fechar.Af_tipo1 = dr(2).ToString
            abrir_fechar.Af_concluido1 = dr(3)
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazCaixaAberto(ByRef CaixaAberto As ClAbrirFecharCaixa, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AbrirFecharDAO:TrazCaixaAberto"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT af_id, af_datahora, af_tipo, af_concluido FROM abrir_fechar WHERE af_tipo = 'A' AND af_concluido = false"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader


        While dr.Read

            With CaixaAberto
                .Af_id1 = dr(0)
                .Af_datahora1 = dr(1)
                .Af_tipo1 = dr(2).ToString
                .Af_concluido1 = dr(3)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function trazListaCaixa_DaLista(lista As List(Of ClCaixa)) As List(Of ClCaixa)
        Dim listaAlterada As New List(Of ClCaixa)

        For Each af As ClCaixa In lista
            listaAlterada.Add(New ClCaixa(af))
        Next

        Return listaAlterada
    End Function

    Public Sub TrazListCaixasBD(ByRef Caixa As List(Of ClCaixa), ByVal strConection As String, Optional ByVal vIdCaixa As Int64 = 0)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""CaixaDAO:TrazCaixas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT cx_id, cx_tipo, cx_datahora, cx_motivo, cx_af_id, cx_valor, cx_tipo_valor FROM caixa "
        If vIdCaixa > 0 Then consulta = "SELECT cx_id, cx_tipo, cx_datahora, cx_motivo, cx_af_id, cx_valor, cx_tipo_valor FROM caixa WHERE cx_af_id = " & vIdCaixa
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Caixa.Clear()
        While dr.Read

            Caixa.Add(New ClCaixa(dr(0), dr(1), dr(2), dr(3).ToString, dr(4), dr(5), dr(6).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function VerificaCaixaAberto(ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""AbrirFecharDAO:VerificaCaixaAberto"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT af_id FROM abrir_fechar WHERE af_tipo = 'A' AND af_concluido = false"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        'Se tiver caixa aberto: 
        If dr.HasRows Then Return True
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return False
    End Function

    Public Function trazValorPorTipo(ByVal strConection As String, ByVal vIdCaixa As Long, ByVal vTipo As String,
                                     Optional ByVal vTipoValor As String = "DN") As Double

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mValor As Double = 0.0

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""CaixaDAO:trazValorPorTipo"":: " & ex.Message)
            Return mValor
        End Try

        consulta = "SELECT SUM(cx_valor) from caixa WHERE cx_af_id = " & vIdCaixa & " AND cx_tipo = '" & vTipo & "' AND cx_tipo_valor = '" & vTipoValor & "';"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        'Se tiver caixa aberto: 
        If dr.HasRows = False Then Return mValor
        While dr.Read

            If IsNumeric(dr(0)) Then mValor = CDbl(dr(0))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return mValor
    End Function

End Class
