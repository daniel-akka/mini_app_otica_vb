Imports Npgsql
Public Class ClAPagarTotalDAO

    Private _APagarParcial As New ClAPagarParcial
    Private _APagarParcialDAO As New ClAPagarParcialDAO

    Public Sub incAPagarTotal(ByVal APagarTotal As ClAPagarTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO apagar_total(apt_id, apt_empresaid, apt_empresanome, apt_portadorid, apt_portadortipo, apt_portadornome, apt_dataemissao, "
        sql += "apt_datavencimento, apt_valor, apt_datapagamento, apt_valorrestante, apt_desconto, apt_acrescimo, apt_observacao, "
        sql += "apt_funcionarioid, apt_funcionarionome, apt_valorpago, apt_tela, apt_situacao, apt_idvendaservico, apt_idvendaproduto, "
        sql += "apt_tipodocumentoid, apt_tipodocumentodescr) "
        sql += "VALUES (DEFAULT, @apt_empresaid, @apt_empresanome, @apt_portadorid, @apt_portadortipo, @apt_portadornome, @apt_dataemissao, "
        sql += "@apt_datavencimento, @apt_valor, @apt_datapagamento, @apt_valorrestante, @apt_desconto, @apt_acrescimo, @apt_observacao, "
        sql += "@apt_funcionarioid, @apt_funcionarionome, @apt_valorpago, @apt_tela, @apt_situacao, @apt_idvendaservico, @apt_idvendaproduto, "
        sql += "@apt_tipodocumentoid, @apt_tipodocumentodescr) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@apt_empresaid", APagarTotal.apt_empresaid)
        comm.Parameters.Add("@apt_empresanome", APagarTotal.apt_empresanome)
        comm.Parameters.Add("@apt_portadorid", APagarTotal.apt_portadorid)
        comm.Parameters.Add("@apt_portadortipo", APagarTotal.apt_portadortipo)
        comm.Parameters.Add("@apt_portadornome", APagarTotal.apt_portadornome)
        comm.Parameters.Add("@apt_dataemissao", APagarTotal.apt_dataemissao)
        comm.Parameters.Add("@apt_datavencimento", APagarTotal.apt_datavencimento)
        comm.Parameters.Add("@apt_valor", APagarTotal.apt_valor)
        comm.Parameters.Add("@apt_datapagamento", APagarTotal.apt_datapagamento)
        comm.Parameters.Add("@apt_valorrestante", APagarTotal.apt_valor)
        comm.Parameters.Add("@apt_desconto", APagarTotal.apt_desconto)
        comm.Parameters.Add("@apt_acrescimo", APagarTotal.apt_acrescimo)
        comm.Parameters.Add("@apt_observacao", APagarTotal.apt_observacao)
        comm.Parameters.Add("@apt_funcionarioid", APagarTotal.apt_funcionarioid)
        comm.Parameters.Add("@apt_funcionarionome", APagarTotal.apt_funcionarionome)
        comm.Parameters.Add("@apt_valorpago", APagarTotal.apt_valorpago)
        comm.Parameters.Add("@apt_tela", APagarTotal.apt_tela)
        comm.Parameters.Add("@apt_situacao", APagarTotal.apt_situacao)
        comm.Parameters.Add("@apt_idvendaservico", APagarTotal.apt_idvendaservico)
        comm.Parameters.Add("@apt_idvendaproduto", APagarTotal.apt_idvendaproduto)
        comm.Parameters.Add("@apt_tipodocumentoid", APagarTotal.apt_tipodocumentoid)
        comm.Parameters.Add("@apt_tipodocumentodescr", APagarTotal.apt_tipodocumentodescr)

        comm.ExecuteNonQuery()

        TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAPagarTotal(ByVal APagarTotal As ClAPagarTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE apagar_total SET apt_datavencimento = @apt_datavencimento, apt_datapagamento = @apt_datapagamento, "
        sql += "apt_valorrestante = @apt_valorrestante, apt_desconto = @apt_desconto, apt_acrescimo = @apt_acrescimo, "
        sql += "apt_observacao = @apt_observacao, apt_funcionarioid = @apt_funcionarioid, apt_funcionarionome = @apt_funcionarionome, "
        sql += "apt_valorpago = @apt_valorpago, apt_alteradodt = @apt_alteradodt, apt_alteradofunc = @apt_alteradofunc, "
        sql += "apt_estornado = @apt_estornado, apt_estornadovalor = @apt_estornadovalor, apt_situacao = @apt_situacao, "
        sql += "apt_portadorid = @apt_portadorid, apt_portadornome = @apt_portadornome, apt_portadortipo = @apt_portadortipo, "
        sql += "apt_valor = @apt_valor, apt_tipodocumentoid = @apt_tipodocumentoid, apt_tipodocumentodescr = @apt_tipodocumentodescr WHERE apt_id = @apt_id "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@apt_id", APagarTotal.apt_id)
        comm.Parameters.Add("@apt_datavencimento", APagarTotal.apt_datavencimento)
        comm.Parameters.Add("@apt_datapagamento", APagarTotal.apt_datapagamento)
        comm.Parameters.Add("@apt_valorrestante", APagarTotal.apt_valorrestante)
        comm.Parameters.Add("@apt_valor", APagarTotal.apt_valor)
        comm.Parameters.Add("@apt_desconto", APagarTotal.apt_desconto)
        comm.Parameters.Add("@apt_acrescimo", APagarTotal.apt_acrescimo)
        comm.Parameters.Add("@apt_observacao", APagarTotal.apt_observacao)
        comm.Parameters.Add("@apt_funcionarioid", APagarTotal.apt_funcionarioid)
        comm.Parameters.Add("@apt_funcionarionome", APagarTotal.apt_funcionarionome)
        comm.Parameters.Add("@apt_valorpago", APagarTotal.apt_valorpago)
        APagarTotal.apt_alteradodt = Date.Now
        comm.Parameters.Add("@apt_alteradodt", APagarTotal.apt_alteradodt)
        comm.Parameters.Add("@apt_alteradofunc", APagarTotal.apt_alteradofunc)
        comm.Parameters.Add("@apt_estornado", APagarTotal.apt_estornado)
        comm.Parameters.Add("@apt_estornadovalor", APagarTotal.apt_estornadovalor)
        comm.Parameters.Add("@apt_situacao", APagarTotal.apt_situacao)
        comm.Parameters.Add("@apt_portadorid", APagarTotal.apt_portadorid)
        comm.Parameters.Add("@apt_portadornome", APagarTotal.apt_portadornome)
        comm.Parameters.Add("@apt_portadortipo", APagarTotal.apt_portadortipo)
        comm.Parameters.Add("@apt_tipodocumentoid", APagarTotal.apt_tipodocumentoid)
        comm.Parameters.Add("@apt_tipodocumentodescr", APagarTotal.apt_tipodocumentodescr)

        comm.ExecuteNonQuery()

        TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub baixarAPagarParcial(ByVal APagarTotal As ClAPagarTotal, _
                                     ByVal ApagarParcial As ClAPagarParcial, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE apagar_total SET apt_valorrestante = @apt_valorrestante, apt_desconto = @apt_desconto, "
        sql += "apt_acrescimo = @apt_acrescimo, apt_valorpago = @apt_valorpago, apt_pagodinheiro = @apt_pagodinheiro, "
        sql += "apt_pagocartaocred = @apt_pagocartaocred, apt_pagocartaodeb = @apt_pagocartaodeb, "
        sql += "apt_pagopix = @apt_pagopix, apt_pagotransferencia = @apt_pagotransferencia WHERE apt_id = @apt_id "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@apt_id", APagarTotal.apt_id)
        comm.Parameters.Add("@apt_valorrestante", APagarTotal.apt_valorrestante)
        comm.Parameters.Add("@apt_desconto", APagarTotal.apt_desconto)
        comm.Parameters.Add("@apt_acrescimo", APagarTotal.apt_acrescimo)
        comm.Parameters.Add("@apt_valorpago", APagarTotal.apt_valorpago)
        comm.Parameters.Add("@apt_pagodinheiro", APagarTotal.apt_pagodinheiro)
        comm.Parameters.Add("@apt_pagocartaocred", APagarTotal.apt_pagocartaocred)
        comm.Parameters.Add("@apt_pagocartaodeb", APagarTotal.apt_pagocartaodeb)
        comm.Parameters.Add("@apt_pagopix", APagarTotal.apt_pagopix)
        comm.Parameters.Add("@apt_pagotransferencia", APagarTotal.apt_pagotransferencia)

        comm.ExecuteNonQuery()

        _APagarParcialDAO.incAPagarParcial(ApagarParcial, conexao, transacao)

        TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAPagarBaixaIndividual(ByVal APagarTotal As ClAPagarTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE apagar_total SET apt_datapagamento = @apt_datapagamento, apt_valorrestante = @apt_valorrestante, "
        sql += "apt_valorpago = @apt_valorpago, apt_situacao = @apt_situacao, apt_idcaixa = @apt_idcaixa, "
        sql += "apt_pagodinheiro = @apt_pagodinheiro, apt_pagocartaocred = @apt_pagocartaocred, apt_pagocartaodeb = @apt_pagocartaodeb, "
        sql += "apt_pagopix = @apt_pagopix, apt_pagotransferencia = @apt_pagotransferencia WHERE apt_id = @apt_id "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@apt_id", APagarTotal.apt_id)
        comm.Parameters.Add("@apt_datapagamento", Date.Now)
        comm.Parameters.Add("@apt_valorpago", APagarTotal.apt_valor)
        comm.Parameters.Add("@apt_situacao", "L")
        comm.Parameters.Add("@apt_valorrestante", 0)
        comm.Parameters.Add("@apt_valorpago", APagarTotal.apt_valorpago)
        comm.Parameters.Add("@apt_desconto", APagarTotal.apt_desconto)
        comm.Parameters.Add("@apt_acrescimo", APagarTotal.apt_acrescimo)
        comm.Parameters.Add("@apt_idcaixa", APagarTotal.apt_idcaixa)
        comm.Parameters.Add("@apt_pagodinheiro", APagarTotal.apt_pagodinheiro)
        comm.Parameters.Add("@apt_pagocartaocred", APagarTotal.apt_pagocartaocred)
        comm.Parameters.Add("@apt_pagocartaodeb", APagarTotal.apt_pagocartaodeb)
        comm.Parameters.Add("@apt_pagopix", APagarTotal.apt_pagopix)
        comm.Parameters.Add("@apt_pagotransferencia", APagarTotal.apt_pagotransferencia)

        comm.ExecuteNonQuery()

        TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAPagarEstornarConta(ByVal APagarTotal As ClAPagarTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE apagar_total SET apt_estornado = @apt_estornado, apt_estornadovalor = @apt_estornadovalor, "
        sql += "apt_situacao = @apt_situacao WHERE apt_id = @apt_id "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@apt_id", APagarTotal.apt_id)
        comm.Parameters.Add("@apt_situacao", "E")
        comm.Parameters.Add("@apt_estornado", APagarTotal.apt_estornado)
        comm.Parameters.Add("@apt_estornadovalor", APagarTotal.apt_valor - APagarTotal.apt_valorrestante)

        comm.ExecuteNonQuery()

        TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAPagarEstornarConta(ByVal APagarTotal As ClAPagarTotal, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE apagar_total SET apt_estornado = @apt_estornado, apt_estornadovalor = @apt_estornadovalor, "
        sql += "apt_situacao = @apt_situacao WHERE apt_id = @apt_id "

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@apt_id", APagarTotal.apt_id)
        comm.Parameters.Add("@apt_situacao", "E")
        comm.Parameters.Add("@apt_estornado", APagarTotal.apt_estornado)
        comm.Parameters.Add("@apt_estornadovalor", APagarTotal.apt_valor - APagarTotal.apt_valorrestante)

        comm.ExecuteNonQuery()

        TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListAPagarTotalBD(ByRef APagar As List(Of ClAPagarTotal), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim dataNascimento As String = "", dataServico As String = ""
        Dim mAReceber As New ClAPagarTotal

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClAPagarTotalDAO:TrazListAReceber"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT apt_id, apt_empresaid, apt_empresanome, apt_portadorid, apt_portadornome, apt_dataemissao, " '5
        consulta += "apt_datavencimento, apt_valor, apt_datapagamento, apt_valorrestante, apt_desconto, apt_acrescimo, " '11
        consulta += "apt_observacao, apt_funcionarioid, apt_funcionarionome, apt_valorpago, apt_tela, apt_alteradodt, " '17
        consulta += "apt_alteradofunc, apt_estornado, apt_estornadovalor, apt_situacao, apt_tipopagamento, apt_idcaixa, " '23
        consulta += "apt_pagodinheiro, apt_pagocartaocred, apt_pagocartaodeb, apt_pagopix, apt_pagotransferencia, " '28
        consulta += "apt_portadortipo, apt_tipodocumentoid, apt_tipodocumentodescr FROM apagar_total" '31
        ' , ,
        '
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        APagar.Clear()
        While dr.Read

            mAReceber.ZeraValores()

            With mAReceber

                .apt_id = dr(0)
                .apt_empresaid = dr(1)
                .apt_empresanome = dr(2).ToString
                .apt_portadorid = dr(3)
                .apt_portadornome = dr(4).ToString
                .apt_dataemissao = dr(5)
                .apt_datavencimento = dr(6)
                .apt_valor = dr(7)
                .apt_datapagamento = dr(8).ToString
                .apt_valorrestante = dr(9)
                .apt_desconto = dr(10)
                .apt_acrescimo = dr(11)
                .apt_observacao = dr(12).ToString
                .apt_funcionarioid = dr(13)
                .apt_funcionarionome = dr(14).ToString
                .apt_valorpago = dr(15)
                .apt_tela = dr(16).ToString
                .apt_alteradodt = dr(17).ToString
                .apt_alteradofunc = dr(18).ToString
                .apt_estornado = dr(19)
                .apt_estornadovalor = dr(20)
                .apt_situacao = dr(21).ToString
                .apt_tipopagamento = dr(22).ToString
                .apt_idcaixa = dr(23)
                .apt_pagodinheiro = dr(24)
                .apt_pagocartaocred = dr(25)
                .apt_pagocartaodeb = dr(26)
                .apt_pagopix = dr(27)
                .apt_pagotransferencia = dr(28)
                .apt_portadortipo = dr(29).ToString
                .apt_tipodocumentoid = dr(30)
                .apt_tipodocumentodescr = dr(31).ToString
            End With

            APagar.Add(New ClAPagarTotal(mAReceber))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazContaAPagarDaLista(ByRef APagar As ClAPagarTotal, ByVal ListContasAPagarT As List(Of ClAPagarTotal)) As Boolean

        Dim mId As Integer = APagar.apt_id
        If ListContasAPagarT.Count > 0 Then
            If ListContasAPagarT.Exists(Function(ar As ClAPagarTotal) ar.apt_id = mId) Then

                For Each r As ClAPagarTotal In ListContasAPagarT

                    If r.apt_id = APagar.apt_id Then

                        APagar.SetaValores(r)
                    End If
                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function TrazListaContasParcialCaixa(ByVal Caixa As ClAbrirFecharCaixa, ByRef ListaAPagar As List(Of ClAPagarTotal), ByVal ListTodasContasAPagarT As List(Of ClAPagarTotal)) As Boolean

        Dim APagar As New ClAPagarTotal
        If ListTodasContasAPagarT.Count > 0 Then
            If ListTodasContasAPagarT.Exists(Function(ar As ClAPagarTotal) ar.apt_idcaixa = Caixa.Af_id1) Then

                ListaAPagar.Clear()
                For Each r As ClAPagarTotal In ListTodasContasAPagarT

                    If r.apt_idcaixa = Caixa.Af_id1 Then

                        APagar.ZeraValores()
                        APagar.SetaValores(r)
                        ListaAPagar.Add(New ClAPagarTotal(APagar))
                    End If

                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Sub delAReceberTotal(ByVal APagar As ClAPagarTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM apagar_total WHERE apt_id = @apt_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@apt_id", APagar.apt_id)

        comm.ExecuteNonQuery()

        TrazListAPagarTotalBD(MdlConexaoBD.ListaAPagarTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub


End Class
