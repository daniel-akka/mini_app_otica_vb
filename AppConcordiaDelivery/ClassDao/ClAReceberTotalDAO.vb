Imports Npgsql
Public Class ClAReceberTotalDAO

    Private _AReceberParcial As New ClAReceberParcial
    Private _AReceberParcialDAO As New ClAReceberParcialDAO

    Public Sub incAReceberTotal(ByVal AReceberTotal As ClAReceberTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO areceber_total(art_id, art_empresaid, art_empresanome, art_clienteid, art_clientenome, art_dataemissao, "
        sql += "art_datavencimento, art_valor, art_datapagamento, art_valorrestante, art_desconto, art_acrescimo, art_observacao, "
        sql += "art_funcionarioid, art_funcionarionome, art_valorpago, art_tela, art_situacao, art_idvendaservico, art_idvendaproduto, "
        sql += "art_idficha_otica, art_parcela) "
        sql += "VALUES (DEFAULT, @art_empresaid, @art_empresanome, @art_clienteid, @art_clientenome, @art_dataemissao, "
        sql += "@art_datavencimento, @art_valor, @art_datapagamento, @art_valorrestante, @art_desconto, @art_acrescimo, @art_observacao, "
        sql += "@art_funcionarioid, @art_funcionarionome, @art_valorpago, @art_tela, @art_situacao, @art_idvendaservico, @art_idvendaproduto, "
        sql += "@art_idficha_otica, @art_parcela) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@art_empresaid", AReceberTotal.art_empresaid)
        comm.Parameters.Add("@art_empresanome", AReceberTotal.art_empresanome)
        comm.Parameters.Add("@art_clienteid", AReceberTotal.art_clienteid)
        comm.Parameters.Add("@art_clientenome", AReceberTotal.art_clientenome)
        comm.Parameters.Add("@art_dataemissao", AReceberTotal.art_dataemissao)
        comm.Parameters.Add("@art_datavencimento", AReceberTotal.art_datavencimento)
        comm.Parameters.Add("@art_valor", AReceberTotal.art_valor)
        comm.Parameters.Add("@art_datapagamento", AReceberTotal.art_datapagamento)
        comm.Parameters.Add("@art_valorrestante", AReceberTotal.art_valor)
        comm.Parameters.Add("@art_desconto", AReceberTotal.art_desconto)
        comm.Parameters.Add("@art_acrescimo", AReceberTotal.art_acrescimo)
        comm.Parameters.Add("@art_observacao", AReceberTotal.art_observacao)
        comm.Parameters.Add("@art_funcionarioid", AReceberTotal.art_funcionarioid)
        comm.Parameters.Add("@art_funcionarionome", AReceberTotal.art_funcionarionome)
        comm.Parameters.Add("@art_valorpago", AReceberTotal.art_valorpago)
        comm.Parameters.Add("@art_tela", AReceberTotal.art_tela)
        comm.Parameters.Add("@art_situacao", AReceberTotal.art_situacao)
        comm.Parameters.Add("@art_idvendaservico", AReceberTotal.art_idvendaservico)
        comm.Parameters.Add("@art_idvendaproduto", AReceberTotal.art_idvendaproduto)
        comm.Parameters.Add("@art_idficha_otica", AReceberTotal.art_idficha_otica)
        comm.Parameters.Add("@art_parcela", AReceberTotal.art_parcela)

        comm.ExecuteNonQuery()

        TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAReceberTotal(ByVal AReceberTotal As ClAReceberTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE areceber_total SET art_datavencimento = @art_datavencimento, art_datapagamento = @art_datapagamento, "
        sql += "art_valorrestante = @art_valorrestante, art_desconto = @art_desconto, art_acrescimo = @art_acrescimo, "
        sql += "art_observacao = @art_observacao, art_funcionarioid = @art_funcionarioid, art_funcionarionome = @art_funcionarionome, "
        sql += "art_valorpago = @art_valorpago, art_alteradodt = @art_alteradodt, art_alteradofunc = @art_alteradofunc, "
        sql += "art_estornado = @art_estornado, art_estornadovalor = @art_estornadovalor, art_situacao = @art_situacao, "
        sql += "art_clienteid = @art_clienteid, art_clientenome = @art_clientenome, art_idficha_otica = @art_idficha_otica, "
        sql += "art_valor = @art_valor, art_parcela = @art_parcela WHERE art_id = @art_id "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@art_id", AReceberTotal.art_id)
        comm.Parameters.Add("@art_datavencimento", AReceberTotal.art_datavencimento)
        comm.Parameters.Add("@art_datapagamento", AReceberTotal.art_datapagamento)
        comm.Parameters.Add("@art_valorrestante", AReceberTotal.art_valorrestante)
        comm.Parameters.Add("@art_valor", AReceberTotal.art_valor)
        comm.Parameters.Add("@art_desconto", AReceberTotal.art_desconto)
        comm.Parameters.Add("@art_acrescimo", AReceberTotal.art_acrescimo)
        comm.Parameters.Add("@art_observacao", AReceberTotal.art_observacao)
        comm.Parameters.Add("@art_funcionarioid", AReceberTotal.art_funcionarioid)
        comm.Parameters.Add("@art_funcionarionome", AReceberTotal.art_funcionarionome)
        comm.Parameters.Add("@art_valorpago", AReceberTotal.art_valorpago)
        AReceberTotal.art_alteradodt = Date.Now
        comm.Parameters.Add("@art_alteradodt", AReceberTotal.art_alteradodt)
        comm.Parameters.Add("@art_alteradofunc", AReceberTotal.art_alteradofunc)
        comm.Parameters.Add("@art_estornado", AReceberTotal.art_estornado)
        comm.Parameters.Add("@art_estornadovalor", AReceberTotal.art_estornadovalor)
        comm.Parameters.Add("@art_situacao", AReceberTotal.art_situacao)
        comm.Parameters.Add("@art_clienteid", AReceberTotal.art_clienteid)
        comm.Parameters.Add("@art_clientenome", AReceberTotal.art_clientenome)
        comm.Parameters.Add("@art_idficha_otica", AReceberTotal.art_idficha_otica)
        comm.Parameters.Add("@art_parcela", AReceberTotal.art_parcela)

        comm.ExecuteNonQuery()

        TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub baixarAReceberParcial(ByVal AReceberTotal As ClAReceberTotal, _
                                     ByVal AreceberParcial As ClAReceberParcial, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE areceber_total SET art_valorrestante = @art_valorrestante, art_desconto = @art_desconto, "
        sql += "art_acrescimo = @art_acrescimo, art_valorpago = @art_valorpago, art_pagodinheiro = @art_pagodinheiro, "
        sql += "art_pagocartaocred = @art_pagocartaocred, art_pagocartaodeb = @art_pagocartaodeb, "
        sql += "art_pagopix = @art_pagopix, art_pagotransferencia = @art_pagotransferencia WHERE art_id = @art_id "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@art_id", AReceberTotal.art_id)
        comm.Parameters.Add("@art_valorrestante", AReceberTotal.art_valorrestante)
        comm.Parameters.Add("@art_desconto", AReceberTotal.art_desconto)
        comm.Parameters.Add("@art_acrescimo", AReceberTotal.art_acrescimo)
        comm.Parameters.Add("@art_valorpago", AReceberTotal.art_valorpago)
        comm.Parameters.Add("@art_pagodinheiro", AReceberTotal.art_pagodinheiro)
        comm.Parameters.Add("@art_pagocartaocred", AReceberTotal.art_pagocartaocred)
        comm.Parameters.Add("@art_pagocartaodeb", AReceberTotal.art_pagocartaodeb)
        comm.Parameters.Add("@art_pagopix", AReceberTotal.art_pagopix)
        comm.Parameters.Add("@art_pagotransferencia", AReceberTotal.art_pagotransferencia)

        comm.ExecuteNonQuery()

        _AReceberParcialDAO.incAReceberParcial(AreceberParcial, conexao, transacao)

        TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAReceberBaixaIndividual(ByVal AReceberTotal As ClAReceberTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE areceber_total SET art_datapagamento = @art_datapagamento, art_valorrestante = @art_valorrestante, "
        sql += "art_valorpago = @art_valorpago, art_situacao = @art_situacao, art_idcaixa = @art_idcaixa, "
        sql += "art_pagodinheiro = @art_pagodinheiro, art_pagocartaocred = @art_pagocartaocred, art_pagocartaodeb = @art_pagocartaodeb, "
        sql += "art_pagopix = @art_pagopix, art_pagotransferencia = @art_pagotransferencia WHERE art_id = @art_id "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@art_id", AReceberTotal.art_id)
        comm.Parameters.Add("@art_datapagamento", Date.Now)
        comm.Parameters.Add("@art_valorpago", AReceberTotal.art_valor)
        comm.Parameters.Add("@art_situacao", "L")
        comm.Parameters.Add("@art_valorrestante", 0)
        comm.Parameters.Add("@art_valorpago", AReceberTotal.art_valorpago)
        comm.Parameters.Add("@art_desconto", AReceberTotal.art_desconto)
        comm.Parameters.Add("@art_acrescimo", AReceberTotal.art_acrescimo)
        comm.Parameters.Add("@art_idcaixa", AReceberTotal.art_idcaixa)
        comm.Parameters.Add("@art_pagodinheiro", AReceberTotal.art_pagodinheiro)
        comm.Parameters.Add("@art_pagocartaocred", AReceberTotal.art_pagocartaocred)
        comm.Parameters.Add("@art_pagocartaodeb", AReceberTotal.art_pagocartaodeb)
        comm.Parameters.Add("@art_pagopix", AReceberTotal.art_pagopix)
        comm.Parameters.Add("@art_pagotransferencia", AReceberTotal.art_pagotransferencia)

        comm.ExecuteNonQuery()

        TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAReceberEstornarConta(ByVal AReceberTotal As ClAReceberTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE areceber_total SET art_estornado = @art_estornado, art_estornadovalor = @art_estornadovalor, "
        sql += "art_situacao = @art_situacao WHERE art_id = @art_id "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@art_id", AReceberTotal.art_id)
        comm.Parameters.Add("@art_situacao", "E")
        comm.Parameters.Add("@art_estornado", AReceberTotal.art_estornado)
        comm.Parameters.Add("@art_estornadovalor", AReceberTotal.art_valor - AReceberTotal.art_valorrestante)

        comm.ExecuteNonQuery()

        TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altAReceberEstornarConta(ByVal AReceberTotal As ClAReceberTotal, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "UPDATE areceber_total SET art_estornado = @art_estornado, art_estornadovalor = @art_estornadovalor, "
        sql += "art_situacao = @art_situacao WHERE art_id = @art_id "

        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@art_id", AReceberTotal.art_id)
        comm.Parameters.Add("@art_situacao", "E")
        comm.Parameters.Add("@art_estornado", AReceberTotal.art_estornado)
        comm.Parameters.Add("@art_estornadovalor", AReceberTotal.art_valor - AReceberTotal.art_valorrestante)

        comm.ExecuteNonQuery()

        TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListAReceberBD(ByRef AReceber As List(Of ClAReceberTotal), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim dataNascimento As String = "", dataServico As String = ""
        Dim mAReceber As New ClAReceberTotal

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClAReceberTotalDAO:TrazListAReceber"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT art_id, art_empresaid, art_empresanome, art_clienteid, art_clientenome, art_dataemissao, " '5
        consulta += "art_datavencimento, art_valor, art_datapagamento, art_valorrestante, art_desconto, art_acrescimo, " '11
        consulta += "art_observacao, art_funcionarioid, art_funcionarionome, art_valorpago, art_tela, art_alteradodt, " '17
        consulta += "art_alteradofunc, art_estornado, art_estornadovalor, art_situacao, art_tipopagamento, art_idcaixa, " '23
        consulta += "art_pagodinheiro, art_pagocartaocred, art_pagocartaodeb, art_pagopix, art_pagotransferencia, art_idficha_otica, " '29
        consulta += "art_parcela FROM areceber_total"
        ' , ,
        '
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        AReceber.Clear()
        While dr.Read

            mAReceber.ZeraValores()

            With mAReceber

                .art_id = dr(0)
                .art_empresaid = dr(1)
                .art_empresanome = dr(2).ToString
                .art_clienteid = dr(3)
                .art_clientenome = dr(4).ToString
                .art_dataemissao = dr(5)
                .art_datavencimento = dr(6)
                .art_valor = dr(7)
                .art_datapagamento = dr(8).ToString
                .art_valorrestante = dr(9)
                .art_desconto = dr(10)
                .art_acrescimo = dr(11)
                .art_observacao = dr(12).ToString
                .art_funcionarioid = dr(13)
                .art_funcionarionome = dr(14).ToString
                .art_valorpago = dr(15)
                .art_tela = dr(16).ToString
                .art_alteradodt = dr(17).ToString
                .art_alteradofunc = dr(18).ToString
                .art_estornado = dr(19)
                .art_estornadovalor = dr(20)
                .art_situacao = dr(21).ToString
                .art_tipopagamento = dr(22).ToString
                .art_idcaixa = dr(23)
                .art_pagodinheiro = dr(24)
                .art_pagocartaocred = dr(25)
                .art_pagocartaodeb = dr(26)
                .art_pagopix = dr(27)
                .art_pagotransferencia = dr(28)
                .art_idficha_otica = dr(29)
                .art_parcela = dr(30)

            End With

            AReceber.Add(New ClAReceberTotal(mAReceber))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function VerificaFichaOtica_AReceberBD(ByVal vFicha As ClFichaOtica, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Boolean

        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vExiste As Boolean = False

        consulta = "SELECT art_idficha_otica FROM areceber_total WHERE art_idficha_otica = " & vFicha.fo_id & " "
        consulta += "AND art_situacao <> 'E'"

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            vExiste = True
            Exit While
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return vExiste
    End Function

    Public Function VerificaFichaOtica_AReceberBD(ByVal vFicha As ClFichaOtica, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vExiste As Boolean = False

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClAReceberTotalDAO:VerificaFichaOtica_AReceberBD"":: " & ex.Message)
            Return vExiste
        End Try

        consulta = "SELECT art_idficha_otica FROM areceber_total WHERE art_idficha_otica = " & vFicha.fo_id & " "
        consulta += "AND art_situacao <> 'E'"

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            vExiste = True
            Exit While
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return vExiste
    End Function

    Public Function TrazContaAReceberDaLista(ByRef AReceber As ClAReceberTotal, ByVal ListContasAReceberT As List(Of ClAReceberTotal)) As Boolean

        Dim mId As Integer = AReceber.art_id
        If ListContasAReceberT.Count > 0 Then
            If ListContasAReceberT.Exists(Function(ar As ClAReceberTotal) ar.art_id = mId) Then

                For Each r As ClAReceberTotal In ListContasAReceberT

                    If r.art_id = AReceber.art_id Then

                        With AReceber

                            .art_id = r.art_id
                            .art_empresaid = r.art_empresaid
                            .art_empresanome = r.art_empresanome
                            .art_clienteid = r.art_clienteid
                            .art_clientenome = r.art_clientenome
                            .art_dataemissao = r.art_dataemissao
                            .art_datavencimento = r.art_datavencimento
                            .art_valor = r.art_valor
                            .art_datapagamento = r.art_datapagamento
                            .art_valorrestante = r.art_valorrestante
                            .art_desconto = r.art_desconto
                            .art_acrescimo = r.art_acrescimo
                            .art_observacao = r.art_observacao
                            .art_funcionarioid = r.art_funcionarioid
                            .art_funcionarionome = r.art_funcionarionome
                            .art_valorpago = r.art_valorpago
                            .art_tela = r.art_tela
                            .art_alteradodt = r.art_alteradodt
                            .art_alteradofunc = r.art_alteradofunc
                            .art_estornado = r.art_estornado
                            .art_estornadovalor = r.art_estornadovalor
                            .art_situacao = r.art_situacao
                            .art_tipopagamento = r.art_tipopagamento
                            .art_idcaixa = r.art_idcaixa
                            .art_pagodinheiro = r.art_pagodinheiro
                            .art_pagocartaocred = r.art_pagocartaocred
                            .art_pagocartaodeb = r.art_pagocartaodeb
                            .art_pagopix = r.art_pagopix
                            .art_pagotransferencia = r.art_pagotransferencia
                            .art_idficha_otica = r.art_idficha_otica
                            .art_parcela = r.art_parcela

                        End With
                    End If
                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function TrazListaContasParcialCaixa(ByVal Caixa As ClAbrirFecharCaixa, ByRef ListaAReceber As List(Of ClAReceberTotal), ByVal ListTodasContasAReceberT As List(Of ClAReceberTotal)) As Boolean

        Dim AReceber As New ClAReceberTotal
        If ListTodasContasAReceberT.Count > 0 Then
            If ListTodasContasAReceberT.Exists(Function(ar As ClAReceberTotal) ar.art_idcaixa = Caixa.Af_id1) Then

                ListaAReceber.Clear()
                For Each r As ClAReceberTotal In ListTodasContasAReceberT

                    If r.art_idcaixa = Caixa.Af_id1 Then

                        AReceber.ZeraValores()
                        With AReceber

                            .art_id = r.art_id
                            .art_empresaid = r.art_empresaid
                            .art_empresanome = r.art_empresanome
                            .art_clienteid = r.art_clienteid
                            .art_clientenome = r.art_clientenome
                            .art_dataemissao = r.art_dataemissao
                            .art_datavencimento = r.art_datavencimento
                            .art_valor = r.art_valor
                            .art_datapagamento = r.art_datapagamento
                            .art_valorrestante = r.art_valorrestante
                            .art_desconto = r.art_desconto
                            .art_acrescimo = r.art_acrescimo
                            .art_observacao = r.art_observacao
                            .art_funcionarioid = r.art_funcionarioid
                            .art_funcionarionome = r.art_funcionarionome
                            .art_valorpago = r.art_valorpago
                            .art_tela = r.art_tela
                            .art_alteradodt = r.art_alteradodt
                            .art_alteradofunc = r.art_alteradofunc
                            .art_estornado = r.art_estornado
                            .art_estornadovalor = r.art_estornadovalor
                            .art_situacao = r.art_situacao
                            .art_tipopagamento = r.art_tipopagamento
                            .art_idcaixa = r.art_idcaixa
                            .art_pagodinheiro = r.art_pagodinheiro
                            .art_pagocartaocred = r.art_pagocartaocred
                            .art_pagocartaodeb = r.art_pagocartaodeb
                            .art_pagopix = r.art_pagopix
                            .art_pagotransferencia = r.art_pagotransferencia
                            .art_idficha_otica = r.art_idficha_otica
                            .art_parcela = r.art_parcela

                        End With
                        ListaAReceber.Add(New ClAReceberTotal(AReceber))
                    End If

                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Sub delAReceberTotal(ByVal AReceber As ClAReceberTotal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM areceber_total WHERE art_id = @art_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@art_id", AReceber.art_id)

        comm.ExecuteNonQuery()

        TrazListAReceberBD(MdlConexaoBD.ListaAReceberTotal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

End Class
