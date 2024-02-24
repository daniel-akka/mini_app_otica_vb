Imports Npgsql
Public Class ClVendaServicoItensDAO

    Public Sub incVendaServicoItens(ByVal VendaServicoItens As ClVendaServicoItens, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO venda_servico_itens(vsi_id, vsi_data, vs_id, vs_totalcartao, vs_totalcartaoseparado, vsi_servicoid, "
        sql += "vsi_serviconome, vsi_servicodespctporcent, vsi_servicodespctvalor, vsi_atendenteid, vsi_atendentenome, "
        sql += "vsi_atendentecomissao, vsi_quantidadeservico, vsi_valorservico, vsi_descontoservico, vsi_subtotalservico, "
        sql += "vsi_valortotalservico, vsi_despcartaoseparado, vsi_valorcomissao) VALUES (DEFAULT, @vsi_data, "
        sql += "@vsid, @vstotalcartao, @vstotalcartaoseparado, @vsi_servicoid, @vsi_serviconome, @vsi_servicodespctporcent, "
        sql += "@vsi_servicodespctvalor, @vsi_atendenteid, @vsi_atendentenome, @vsi_atendentecomissao, @vsi_quantidadeservico, "
        sql += "@vsi_valorservico, @vsi_descontoservico, @vsi_subtotalservico, @vsi_valortotalservico, @vsi_despcartaoseparado, "
        sql += "@vsi_valorcomissao)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@vsi_data", VendaServicoItens.Data)
        comm.Parameters.Add("@vsid", VendaServicoItens.IdServico)
        comm.Parameters.Add("@vstotalcartao", VendaServicoItens.TotalCartaoVendaServico)
        comm.Parameters.Add("@vstotalcartaoseparado", VendaServicoItens.TotalCartaoSeparadoVendaServico)
        comm.Parameters.Add("@vsi_servicoid", VendaServicoItens.IdServico)
        comm.Parameters.Add("@vsi_serviconome", VendaServicoItens.NomeServico)
        comm.Parameters.Add("@vsi_servicodespctporcent", VendaServicoItens.DespCartaoServico_Porcent)
        comm.Parameters.Add("@vsi_servicodespctvalor", VendaServicoItens.DespCartaoServico_Valor)
        comm.Parameters.Add("@vsi_atendenteid", VendaServicoItens.IdAtendente)
        comm.Parameters.Add("@vsi_atendentenome", VendaServicoItens.NomeAtendente)
        comm.Parameters.Add("@vsi_atendentecomissao", VendaServicoItens.ComissaoAtendente)
        comm.Parameters.Add("@vsi_quantidadeservico", VendaServicoItens.QuantidadeServico)
        comm.Parameters.Add("@vsi_valorservico", VendaServicoItens.ValorServico)
        comm.Parameters.Add("@vsi_descontoservico", VendaServicoItens.DescontoServico)
        comm.Parameters.Add("@vsi_subtotalservico", VendaServicoItens.SubTotalServico)
        comm.Parameters.Add("@vsi_valortotalservico", VendaServicoItens.ValorTotalServico)
        comm.Parameters.Add("@vsi_despcartaoseparado", VendaServicoItens.DespCartaoSeparado)
        comm.Parameters.Add("@vsi_valorcomissao", VendaServicoItens.ValorComissao)


        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub incVendaServicoItensLista(ByVal ListaItensVendaServico As List(Of ClVendaServicoItens), ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO venda_servico_itens(vsi_id, vsi_data, vs_id, vs_totalcartao, vs_totalcartaoseparado, vsi_servicoid, "
        sql += "vsi_serviconome, vsi_servicodespctporcent, vsi_servicodespctvalor, vsi_atendenteid, vsi_atendentenome, "
        sql += "vsi_atendentecomissao, vsi_quantidadeservico, vsi_valorservico, vsi_descontoservico, vsi_subtotalservico, "
        sql += "vsi_valortotalservico, vsi_despcartaoseparado, vsi_valorcomissao) VALUES (DEFAULT, @vsi_data, "
        sql += "@vsid, @vstotalcartao, @vstotalcartaoseparado, @vsi_servicoid, @vsi_serviconome, @vsi_servicodespctporcent, "
        sql += "@vsi_servicodespctvalor, @vsi_atendenteid, @vsi_atendentenome, @vsi_atendentecomissao, @vsi_quantidadeservico, "
        sql += "@vsi_valorservico, @vsi_descontoservico, @vsi_subtotalservico, @vsi_valortotalservico, @vsi_despcartaoseparado, "
        sql += "@vsi_valorcomissao)"

        comm.Transaction = transacao

        For Each li As ClVendaServicoItens In ListaItensVendaServico

            comm = New NpgsqlCommand(sql, conexao)
            'Prepara Paramentros
            comm.Parameters.Add("@vsi_data", li.Data)
            comm.Parameters.Add("@vsid", li.IdVendaServico)
            comm.Parameters.Add("@vstotalcartao", li.TotalCartaoVendaServico)
            comm.Parameters.Add("@vstotalcartaoseparado", li.TotalCartaoSeparadoVendaServico)
            comm.Parameters.Add("@vsi_servicoid", li.IdServico)
            comm.Parameters.Add("@vsi_serviconome", li.NomeServico)
            comm.Parameters.Add("@vsi_servicodespctporcent", li.DespCartaoServico_Porcent)
            comm.Parameters.Add("@vsi_servicodespctvalor", li.DespCartaoServico_Valor)
            comm.Parameters.Add("@vsi_atendenteid", li.IdAtendente)
            comm.Parameters.Add("@vsi_atendentenome", li.NomeAtendente)
            comm.Parameters.Add("@vsi_atendentecomissao", li.ComissaoAtendente)
            comm.Parameters.Add("@vsi_quantidadeservico", li.QuantidadeServico)
            comm.Parameters.Add("@vsi_valorservico", li.ValorServico)
            comm.Parameters.Add("@vsi_descontoservico", li.DescontoServico)
            comm.Parameters.Add("@vsi_subtotalservico", li.SubTotalServico)
            comm.Parameters.Add("@vsi_valortotalservico", li.ValorTotalServico)
            comm.Parameters.Add("@vsi_despcartaoseparado", li.DespCartaoSeparado)
            comm.Parameters.Add("@vsi_valorcomissao", li.ValorComissao)


            comm.ExecuteNonQuery()
        Next


        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListItensVendaServicoBD(ByVal VendaServico As ClVendaServico, ByRef ItensVendaServico As List(Of ClVendaServicoItens), ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClVendaServicoItensDAO:TrazListItensVendaServico"":: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End Try

        consulta = "SELECT vsi_id, vsi_data, vs_id, vs_totalcartao, vs_totalcartaoseparado, vsi_servicoid, " '5
        consulta += "vsi_serviconome, vsi_servicodespctporcent, vsi_servicodespctvalor, vsi_atendenteid, vsi_atendentenome, " '10
        consulta += "vsi_atendentecomissao, vsi_quantidadeservico, vsi_valorservico, vsi_descontoservico, vsi_subtotalservico, " '15
        consulta += "vsi_valortotalservico, vsi_despcartaoseparado, vsi_valorcomissao FROM venda_servico_itens "
        consulta += "WHERE vs_id = " & VendaServico.vsid & " "
        If Not condicao.Equals("") Then
            consulta += condicao
        End If
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        ItensVendaServico.Clear()
        While dr.Read

            ItensVendaServico.Add(New ClVendaServicoItens(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), _
                                                dr(6).ToString, dr(7), dr(8), dr(9), dr(10).ToString, _
                                                dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListItensVendaServico_LISTA(ByVal VendaServico As ClVendaServico, ByRef ItensVendaServico As List(Of ClVendaServicoItens), ByVal lista As List(Of ClVendaServicoItens))

        ItensVendaServico.Clear()
        For Each vsi As ClVendaServicoItens In lista
            If vsi.IdVendaServico = VendaServico.vsid Then
                ItensVendaServico.Add(New ClVendaServicoItens(vsi))
            End If
        Next
    End Sub

    Function TrazListItensVendaServico_CompareData(ByVal lista As List(Of ClVendaServicoItens), ByVal data1 As Date, ByVal data2 As Date) As List(Of ClVendaServicoItens)
        Dim novaLista As New List(Of ClVendaServicoItens)
        Dim dtInicial As String = data1.ToShortDateString
        Dim dtFinal As String = data2.ToShortDateString
        Dim dataFor As String = ""

        For Each vsi As ClVendaServicoItens In lista

            dataFor = vsi.Data.ToShortDateString
            If CDate(dataFor) >= CDate(dtInicial) Then

                novaLista.Add(New ClVendaServicoItens(vsi))
            End If
        Next
        Return novaLista
    End Function

    Public Sub TrazListTodosVendaServicoItens_BD(ByRef ItensVendaServico As List(Of ClVendaServicoItens), ByVal strConection As String, Optional ByVal Where As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClVendaServicoItensDAO:TrazListItensVendaServico"":: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End Try

        consulta = "SELECT vsi_id, vsi_data, vs_id, vs_totalcartao, vs_totalcartaoseparado, vsi_servicoid, " '5
        consulta += "vsi_serviconome, vsi_servicodespctporcent, vsi_servicodespctvalor, vsi_atendenteid, vsi_atendentenome, " '10
        consulta += "vsi_atendentecomissao, vsi_quantidadeservico, vsi_valorservico, vsi_descontoservico, vsi_subtotalservico, " '15
        consulta += "vsi_valortotalservico, vsi_despcartaoseparado, vsi_valorcomissao FROM venda_servico_itens "
        If Not Where.Equals("") Then
            consulta += Where
        End If
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        ItensVendaServico.Clear()
        While dr.Read

            ItensVendaServico.Add(New ClVendaServicoItens(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), _
                                                dr(6).ToString, dr(7), dr(8), dr(9), dr(10).ToString, _
                                                dr(11), dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

End Class
