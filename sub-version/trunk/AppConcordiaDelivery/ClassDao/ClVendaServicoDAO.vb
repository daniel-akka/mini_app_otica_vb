Imports Npgsql
Public Class ClVendaServicoDAO

    Public Sub incVendaServico(ByVal VendaServico As ClVendaServico, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO venda_servico(vsid, vsempresaid, vsempresanome, vsempresauf, vsempresacidade, vsclienteid, "
        sql += "vsclientenome, vsclienteuf, vsclientecidade, vsdatahora, vssubtotal, vsdesconto, vstotalgeral, "
        sql += "vspagodinheiro, vspagocredito, vspagodebito, vspagopix, vspagotransferencia, vspagocrediario)"
        sql += "VALUES (DEFAULT, @vsempresaid, @vsempresanome, @vsempresauf, @vsempresacidade, @vsclienteid, "
        sql += "@vsclientenome, @vsclienteuf, @vsclientecidade, @vsdatahora, @vssubtotal, @vsdesconto, @vstotalgeral, "
        sql += "@vspagodinheiro, @vspagocredito, @vspagodebito, @vspagopix, @vspagotransferencia, @vspagocrediario)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@vsempresaid", VendaServico.vsempresaid)
        comm.Parameters.Add("@vsempresanome", VendaServico.vsempresanome)
        comm.Parameters.Add("@vsempresauf", VendaServico.vsempresauf)
        comm.Parameters.Add("@vsempresacidade", VendaServico.vsempresacidade)
        comm.Parameters.Add("@vsclienteid", VendaServico.vsclienteid)
        comm.Parameters.Add("@vsclientenome", VendaServico.vsclientenome)
        comm.Parameters.Add("@vsclienteuf", VendaServico.vsclienteuf)
        comm.Parameters.Add("@vsclientecidade", VendaServico.vsclientecidade)
        comm.Parameters.Add("@vsdatahora", VendaServico.vsdatahora)
        comm.Parameters.Add("@vssubtotal", VendaServico.vssubtotal)
        comm.Parameters.Add("@vsdesconto", VendaServico.vsdesconto)
        comm.Parameters.Add("@vstotalgeral", VendaServico.vstotalgeral)
        comm.Parameters.Add("@vspagodinheiro", VendaServico.vspagodinheiro)
        comm.Parameters.Add("@vspagocredito", VendaServico.vspagocredito)
        comm.Parameters.Add("@vspagodebito", VendaServico.vspagodebito)
        comm.Parameters.Add("@vspagopix", VendaServico.vspagopix)
        comm.Parameters.Add("@vspagotransferencia", VendaServico.vspagotransferencia)
        comm.Parameters.Add("@vspagocrediario", VendaServico.vspagocrediario)
        

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Function TrazIdUltimoVendaServico(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Int64


        Dim dr As NpgsqlDataReader
        Dim com As New NpgsqlCommand
        Dim consulta As String = ""
        Dim mId As Integer = 0

        Try
            consulta = "SELECT MAX(vsid) FROM venda_servico"
            com.Transaction = transacao
            com = New NpgsqlCommand(consulta, conexao)
            dr = com.ExecuteReader

            While dr.Read
                mId = dr(0)
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO ao Trazer ID Ultima Venda Seviço - VendaServicoDAO:: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            com = Nothing : dr = Nothing : consulta = Nothing
        End Try


        Return mId
    End Function

    Public Sub TrazVendaServico(ByRef VendaServico As ClVendaServico, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClVendaServicoDAO:TrazListVendaServico"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT vsid, vsempresaid, vsempresanome, vsempresauf, vsempresacidade, vsclienteid, vsclientenome, " '6
        consulta += "vsclienteuf, vsclientecidade, vsdatahora, vssubtotal, vsdesconto, vstotalgeral, vspagodinheiro, " '13
        consulta += "vspagocredito, vspagodebito, vspagopix, vspagotransferencia, vspagocrediario FROM venda_servico WHERE vsid = " & VendaServico.vsid
        
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With VendaServico

                .vsid = dr(0)
                .vsempresaid = dr(1)
                .vsempresanome = dr(2).ToString
                .vsempresauf = dr(3).ToString
                .vsempresacidade = dr(4).ToString
                .vsclienteid = dr(5)
                .vsclientenome = dr(6).ToString
                .vsclienteuf = dr(7).ToString
                .vsclientecidade = dr(8).ToString
                .vsdatahora = dr(9)
                .vssubtotal = dr(10)
                .vsdesconto = dr(11)
                .vstotalgeral = dr(12)
                .vspagodinheiro = dr(13)
                .vspagocredito = dr(14)
                .vspagodebito = dr(15)
                .vspagopix = dr(16)
                .vspagotransferencia = dr(17)
                .vspagocrediario = dr(18)
            End With
            
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListVendaServicoBD(ByRef VendaServico As List(Of ClVendaServico), ByVal strConection As String, Optional ByVal Where As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClVendaServicoDAO:TrazListVendaServico"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT vsid, vsempresaid, vsempresanome, vsempresauf, vsempresacidade, vsclienteid, vsclientenome, " '6
        consulta += "vsclienteuf, vsclientecidade, vsdatahora, vssubtotal, vsdesconto, vstotalgeral, vspagodinheiro, " '13
        consulta += "vspagocredito, vspagodebito, vspagopix, vspagotransferencia, vspagocrediario FROM venda_servico " '18
        If Not Where.Equals("") Then
            consulta += Where
        End If

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        VendaServico.Clear()
        While dr.Read

            VendaServico.Add(New ClVendaServico(dr(0), dr(1), dr(5), dr(2).ToString, dr(3).ToString, dr(4).ToString, _
                                                dr(6).ToString, dr(7).ToString, dr(8).ToString, dr(9), dr(10), _
                                                dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Function trazListaVendaServico_LISTA(ByVal lista As List(Of ClVendaServico)) As List(Of ClVendaServico)
        Dim novaLista As New List(Of ClVendaServico)

        For Each vs As ClVendaServico In lista
            novaLista.Add(New ClVendaServico(vs))
        Next

        Return novaLista
    End Function

    Function trazListaVendaServicoJOIN_Itens_LISTA(ByVal lista As List(Of ClVendaServico), ByVal listaItens As List(Of ClVendaServicoItens), _
                                            Optional ByVal idServico As Integer = 0, _
                                            Optional ByVal idAtendente As Integer = 0) As List(Of ClVendaServico)

        Dim novaLista As New List(Of ClVendaServico)

        If idServico > 0 AndAlso idAtendente > 0 Then

            novaLista = (From vs As ClVendaServico In lista Join vsi As ClVendaServicoItens In listaItens On vs.vsid Equals vsi.IdVendaServico _
              Where vsi.IdServico = idServico And vsi.IdAtendente = idAtendente Select vs).ToList

        Else

            If idServico > 0 AndAlso idAtendente < 1 Then
                novaLista = (From vs As ClVendaServico In lista Join vsi As ClVendaServicoItens In listaItens On vs.vsid Equals vsi.IdVendaServico _
              Where vsi.IdServico = idServico Select vs).ToList
            End If

            If idAtendente > 0 AndAlso idServico < 1 Then
                novaLista = (From vs As ClVendaServico In lista Join vsi As ClVendaServicoItens In listaItens On vs.vsid Equals vsi.IdVendaServico _
              Where vsi.IdAtendente = idAtendente Select vs).ToList
            End If
        End If
        


        Return novaLista
    End Function

    Public Sub TrazListVendaServicoJOIN_Servico(ByRef VendaServico As List(Of ClVendaServico), ByVal strConection As String, Optional ByVal Where As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClVendaServicoDAO:TrazListVendaServico"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT vsid, vsempresaid, vsempresanome, vsempresauf, vsempresacidade, vsclienteid, vsclientenome, " '6
        consulta += "vsclienteuf, vsclientecidade, vsdatahora, vssubtotal, vsdesconto, vstotalgeral, vspagodinheiro, " '13
        consulta += "vspagocredito, vspagodebito, vspagopix, vspagotransferencia, vspagocrediario FROM venda_servico " '18
        consulta += "LEFT JOIN venda_servico_itens vsi ON vsi.vs_id = vsid " '18
        If Not Where.Equals("") Then
            consulta += Where
        End If

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        VendaServico.Clear()
        While dr.Read

            VendaServico.Add(New ClVendaServico(dr(0), dr(1), dr(5), dr(2).ToString, dr(3).ToString, dr(4).ToString, _
                                                dr(6).ToString, dr(7).ToString, dr(8).ToString, dr(9), dr(10), _
                                                dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

End Class
