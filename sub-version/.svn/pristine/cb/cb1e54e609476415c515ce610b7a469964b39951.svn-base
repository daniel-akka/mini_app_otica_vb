Imports Npgsql
Public Class ClAbrirFecharDAO


    Public Sub incAbrirFechar(ByVal abrir As ClAbrirFecharCaixa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        ' 
        '
        sql = "INSERT INTO abrir_fechar(af_id, af_datahora, af_tipo, af_concluido, af_total_dinheiro, af_total_cartaocredito, af_id_abertura, af_total_apurado_dn, "
        sql += "af_total_apurado_ctc, af_total_cartaodebito, af_total_pix, af_total_transferencia, af_total_apurado_ctd, af_total_apurado_pix, af_total_apurado_tra, "
        sql += "af_total_crediario, af_total_apurado_crd) "
        sql += "VALUES (DEFAULT, @af_datahora, @af_tipo, @af_concluido, DEFAULT, DEFAULT, @af_id_abertura, DEFAULT, DEFAULT, DEFAULT, DEFAULT, "
        sql += "DEFAULT, DEFAULT, DEFAULT, DEFAULT, DEFAULT, DEFAULT) "


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@af_datahora", abrir.Af_datahora1)
        comm.Parameters.Add("@af_tipo", abrir.Af_tipo1)
        comm.Parameters.Add("@af_concluido", abrir.Af_concluido1)
        comm.Parameters.Add("@af_id_abertura", abrir.Af_id_abertura1)
        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub incAbrirFecharFechamento(ByVal abrir As ClAbrirFecharCaixa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO abrir_fechar(af_id, af_datahora, af_tipo, af_concluido, af_total_dinheiro, af_total_cartaocredito, af_id_abertura, "
        sql += "af_total_apurado_dn, af_total_apurado_ctc, af_total_cartaodebito, af_total_pix, af_total_transferencia, af_total_apurado_ctd, "
        sql += "af_total_apurado_pix, af_total_apurado_tra, af_total_crediario, af_total_apurado_crd) "
        sql += "VALUES (DEFAULT, @af_datahora, @af_tipo, @af_concluido, @af_total_dinheiro, @af_total_cartaocredito, @af_id_abertura, "
        sql += "@af_total_apurado_dn, @af_total_apurado_ctc, @af_total_cartaodebito, @af_total_pix, @af_total_transferencia, @af_total_apurado_ctd, "
        sql += "@af_total_apurado_pix, @af_total_apurado_tra, @af_total_crediario, @af_total_apurado_crd) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@af_datahora", abrir.Af_datahora1)
        comm.Parameters.Add("@af_tipo", abrir.Af_tipo1)
        comm.Parameters.Add("@af_concluido", abrir.Af_concluido1)
        comm.Parameters.Add("@af_id_abertura", abrir.Af_id_abertura1)
        comm.Parameters.Add("@af_total_dinheiro", abrir.Af_total_dinheiro1)
        comm.Parameters.Add("@af_total_cartaocredito", abrir.Af_total_cartaocredito)
        comm.Parameters.Add("@af_total_apurado_dn", abrir.Af_total_apurado_dn1)
        comm.Parameters.Add("@af_total_apurado_ctc", abrir.Af_total_apurado_ctc)
        comm.Parameters.Add("@af_total_cartaodebito", abrir.af_total_cartaodebito)
        comm.Parameters.Add("@af_total_pix", abrir.af_total_pix)
        comm.Parameters.Add("@af_total_transferencia", abrir.af_total_transferencia)
        comm.Parameters.Add("@af_total_apurado_ctd", abrir.af_total_apurado_ctd)
        comm.Parameters.Add("@af_total_apurado_pix", abrir.af_total_apurado_pix)
        comm.Parameters.Add("@af_total_apurado_tra", abrir.af_total_apurado_tra)
        comm.Parameters.Add("@af_total_crediario", abrir.af_total_crediario)
        comm.Parameters.Add("@af_total_apurado_crd", abrir.af_total_apurado_crd)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAbrirFechar(ByVal abrir_fechar As ClAbrirFecharCaixa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE abrir_fechar SET af_concluido = @af_concluido, af_total_dinheiro = @af_total_dinheiro, af_total_cartaocredito = "
        sql += "@af_total_cartaocredito, af_total_cartaodebito = af_total_cartaodebito, af_total_pix = @af_total_pix, "
        sql += "af_total_transferencia = @af_total_transferencia, af_total_crediario = @af_total_crediario WHERE af_id = @af_id"


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@af_id", abrir_fechar.Af_id1)
        comm.Parameters.Add("@af_concluido", abrir_fechar.Af_concluido1)
        comm.Parameters.Add("@af_total_dinheiro", abrir_fechar.Af_total_dinheiro1)
        comm.Parameters.Add("@af_total_cartaocredito", abrir_fechar.Af_total_cartaocredito)
        comm.Parameters.Add("@af_total_cartaodebito", abrir_fechar.af_total_cartaodebito)
        comm.Parameters.Add("@af_total_pix", abrir_fechar.af_total_pix)
        comm.Parameters.Add("@af_total_transferencia", abrir_fechar.af_total_transferencia)
        comm.Parameters.Add("@af_total_crediario", abrir_fechar.af_total_crediario)


        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAbrirFechar(ByVal abrir_fechar As ClAbrirFecharCaixa, ByVal strConection As String)

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

        sql = "UPDATE abrir_fechar SET af_concluido = @af_concluido, af_total_dinheiro = @af_total_dinheiro, af_total_cartaocredito = "
        sql += "@af_total_cartaocredito, af_total_cartaodebito = af_total_cartaodebito, af_total_pix = @af_total_pix, "
        sql += "af_total_transferencia = @af_total_transferencia, af_total_crediario = @af_total_crediario WHERE af_id = @af_id"

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@af_id", abrir_fechar.Af_id1)
        comm.Parameters.Add("@af_concluido", abrir_fechar.Af_concluido1)
        comm.Parameters.Add("@af_total_dinheiro", abrir_fechar.Af_total_dinheiro1)
        comm.Parameters.Add("@af_total_cartaocredito", abrir_fechar.Af_total_cartaocredito)
        comm.Parameters.Add("@af_total_cartaodebito", abrir_fechar.af_total_cartaodebito)
        comm.Parameters.Add("@af_total_pix", abrir_fechar.af_total_pix)
        comm.Parameters.Add("@af_total_transferencia", abrir_fechar.af_total_transferencia)
        comm.Parameters.Add("@af_total_crediario", abrir_fechar.af_total_crediario)

        comm.ExecuteNonQuery()


        'TrazListaMovimentacaoNaoFinalizada(MdlConexaoBD.mdlListLocacoesNaoFinalizadas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Function trazAbrirFechar_DaLista(ByRef abrir_fechar As ClAbrirFecharCaixa, ByVal lista As List(Of ClAbrirFecharCaixa)) As Boolean
        Dim deuCerto As Boolean = False

        For Each af As ClAbrirFecharCaixa In lista

            If af.Af_id1 = abrir_fechar.Af_id1 Then
                abrir_fechar.SetaValores(af)
                deuCerto = True
                Exit For
            End If
        Next
        Return deuCerto
    End Function

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

        consulta = "SELECT af_id, af_datahora, af_tipo, af_concluido, af_total_dinheiro, af_total_cartaocredito, af_id_abertura, " '6
        consulta += "af_total_apurado_dn, af_total_apurado_ctc, af_total_cartaodebito, af_total_pix, af_total_transferencia, " '11
        consulta += "af_total_apurado_ctd, af_total_apurado_pix, af_total_apurado_tra, af_total_crediario, af_total_apurado_crd " '16
        consulta += "FROM abrir_fechar WHERE af_id = " & abrir_fechar.Af_id1


        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            abrir_fechar.Af_id1 = dr(0)
            abrir_fechar.Af_datahora1 = dr(1)
            abrir_fechar.Af_tipo1 = dr(2).ToString
            abrir_fechar.Af_concluido1 = dr(3)
            abrir_fechar.Af_total_dinheiro1 = dr(4)
            abrir_fechar.Af_total_cartaocredito = dr(5)
            abrir_fechar.Af_id_abertura1 = dr(6)
            abrir_fechar.Af_total_apurado_dn1 = dr(7)
            abrir_fechar.Af_total_apurado_ctc = dr(8)
            abrir_fechar.af_total_cartaodebito = dr(9)
            abrir_fechar.af_total_pix = dr(10)
            abrir_fechar.af_total_transferencia = dr(11)
            abrir_fechar.af_total_apurado_ctd = dr(12)
            abrir_fechar.af_total_apurado_pix = dr(13)
            abrir_fechar.af_total_apurado_tra = dr(14)
            abrir_fechar.af_total_crediario = dr(15)
            abrir_fechar.af_total_apurado_crd = dr(16)

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


        consulta = "SELECT af_id, af_datahora, af_tipo, af_concluido, af_total_dinheiro, af_total_cartaocredito, af_id_abertura, " '6
        consulta += "af_total_apurado_dn, af_total_apurado_ctc, af_total_cartaodebito, af_total_pix, af_total_transferencia, " '11
        consulta += "af_total_apurado_ctd, af_total_apurado_pix, af_total_apurado_tra, af_total_crediario, af_total_apurado_crd " '16
        consulta += "FROM abrir_fechar WHERE af_tipo = 'A' AND af_concluido = false"

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader


        While dr.Read

            CaixaAberto = New ClAbrirFecharCaixa(dr(0), dr(1), dr(2).ToString, dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), _
                                                 dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

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

    Public Function trazListaAbrirFechar_DaLista(lista As List(Of ClAbrirFecharCaixa)) As List(Of ClAbrirFecharCaixa)
        Dim listaAlterada As New List(Of ClAbrirFecharCaixa)

        For Each af As ClAbrirFecharCaixa In lista
            listaAlterada.Add(New ClAbrirFecharCaixa(af))
        Next

        Return listaAlterada
    End Function

    Public Sub TrazListAbriFecharBD(ByRef AbrirFechar As List(Of ClAbrirFecharCaixa), ByVal strConection As String, _
                                  Optional ByVal dtAbertura As String = "") 'Padrao data ex: 31/12/2019

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""TempoDAO:TrazTempo"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT af_id, af_datahora, af_tipo, af_concluido, af_total_dinheiro, af_total_cartaocredito, af_id_abertura, " '6
        consulta += "af_total_apurado_dn, af_total_apurado_ctc, af_total_cartaodebito, af_total_pix, af_total_transferencia, " '11
        consulta += "af_total_apurado_ctd, af_total_apurado_pix, af_total_apurado_tra, af_total_crediario, af_total_apurado_crd FROM abrir_fechar "
        If dtAbertura.Equals("") = False Then
            consulta = "SELECT af_id, af_datahora, af_tipo, af_concluido, af_total_dinheiro, af_total_cartaocredito, af_id_abertura, " '6
            consulta += "af_total_apurado_dn, af_total_apurado_ctc, af_total_cartaodebito, af_total_pix, af_total_transferencia, " '11
            consulta += "af_total_apurado_ctd, af_total_apurado_pix, af_total_apurado_tra, af_total_crediario, af_total_apurado_crd FROM abrir_fechar "
            consulta += "WHERE af_datahora BETWEEN '" & dtAbertura & " 00:00:00' AND '" & dtAbertura & " 23:59:59'"
        End If
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        AbrirFechar.Clear()
        While dr.Read

            AbrirFechar.Add(New ClAbrirFecharCaixa(dr(0), dr(1), dr(2).ToString, dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), _
                                                 dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListAbriFecharWHERE(ByRef AbrirFechar As List(Of ClAbrirFecharCaixa), ByVal strConection As String, _
                                  Optional ByVal Where As String = "") 'Padrao data ex: 31/12/2019

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""TempoDAO:TrazTempo"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT af_id, af_datahora, af_tipo, af_concluido, af_total_dinheiro, af_total_cartaocredito, af_id_abertura, " '6
        consulta += "af_total_apurado_dn, af_total_apurado_ctc, af_total_cartaodebito, af_total_pix, af_total_transferencia, " '11
        consulta += "af_total_apurado_ctd, af_total_apurado_pix, af_total_apurado_tra, af_total_crediario, af_total_apurado_crd FROM abrir_fechar "
        If Where.Equals("") Then
            consulta = "SELECT af_id, af_datahora, af_tipo, af_concluido, af_total_dinheiro, af_total_cartaocredito, af_id_abertura, " '6
            consulta += "af_total_apurado_dn, af_total_apurado_ctc, af_total_cartaodebito, af_total_pix, af_total_transferencia, " '11
            consulta += "af_total_apurado_ctd, af_total_apurado_pix, af_total_apurado_tra, af_total_crediario, af_total_apurado_crd FROM abrir_fechar "
            consulta += "WHERE to_char(af_datahora,'DD/MM/YYYY') BETWEEN '" & Date.Now.ToShortDateString & "' AND '" & Date.Now.ToShortDateString & "' "
        Else
            consulta += Where
        End If
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        AbrirFechar.Clear()
        While dr.Read

            AbrirFechar.Add(New ClAbrirFecharCaixa(dr(0), dr(1), dr(2).ToString, dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), _
                                                 dr(9), dr(10), dr(11), dr(12), dr(13), dr(14), dr(15), dr(16)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

End Class
