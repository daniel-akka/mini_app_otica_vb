Imports Npgsql
Public Class ClAReceberParcialDAO

    Public Sub incAReceberParcial(ByVal AReceberParcial As ClAReceberParcial, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO areceber_parcial(arp_id, arp_artid, arp_datapagamento, arp_valor, "
        sql += "arp_descrpagamento, arp_desconto, arp_acrescimo, arp_funcionarioid, arp_funcionarionome, arp_idcaixa, arp_pagodinheiro, arp_pagocartaocred, "
        sql += "arp_pagocartaodeb, arp_pagopix, arp_pagotransferencia, arp_valortotal) "
        sql += "VALUES (DEFAULT, @arp_artid, @arp_datapagamento, @arp_valor, "
        sql += "@arp_descrpagamento, @arp_desconto, @arp_acrescimo, @arp_funcionarioid, @arp_funcionarionome, @arp_idcaixa, @arp_pagodinheiro, @arp_pagocartaocred, "
        sql += "@arp_pagocartaodeb, @arp_pagopix, @arp_pagotransferencia, @arp_valortotal) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@arp_artid", AReceberParcial.arp_artid)
        comm.Parameters.Add("@arp_datapagamento", AReceberParcial.arp_datapagamento)
        comm.Parameters.Add("@arp_valor", AReceberParcial.arp_valor)
        comm.Parameters.Add("@arp_descrpagamento", AReceberParcial.arp_descrpagamento)
        comm.Parameters.Add("@arp_desconto", AReceberParcial.arp_desconto)
        comm.Parameters.Add("@arp_acrescimo", AReceberParcial.arp_acrescimo)
        comm.Parameters.Add("@arp_funcionarioid", AReceberParcial.arp_funcionarioid)
        comm.Parameters.Add("@arp_funcionarionome", AReceberParcial.arp_funcionarionome)
        comm.Parameters.Add("@arp_idcaixa", AReceberParcial.arp_idcaixa)
        comm.Parameters.Add("@arp_pagodinheiro", AReceberParcial.arp_pagodinheiro)
        comm.Parameters.Add("@arp_pagocartaocred", AReceberParcial.arp_pagocartaocred)
        comm.Parameters.Add("@arp_pagocartaodeb", AReceberParcial.arp_pagocartaodeb)
        comm.Parameters.Add("@arp_pagopix", AReceberParcial.arp_pagopix)
        comm.Parameters.Add("@arp_pagotransferencia", AReceberParcial.arp_pagotransferencia)
        comm.Parameters.Add("@arp_valortotal", AReceberParcial.arp_valortotal)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListAReceberParcial(ByVal AReceberTotal As ClAReceberTotal, ByRef AReceberParcial As List(Of ClAReceberParcial), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim dataNascimento As String = "", dataServico As String = ""
        Dim mARecebParcial As New ClAReceberParcial


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClAReceberParcialDAO:TrazListAReceberParcial"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT arp_id, arp_artid, arp_datapagamento, arp_valor, arp_descrpagamento, arp_desconto, " '5
        consulta += "arp_acrescimo, arp_funcionarioid, arp_funcionarionome, arp_idcaixa, arp_pagodinheiro, " '10
        consulta += "arp_pagocartaocred, arp_pagocartaodeb, arp_pagopix, arp_pagotransferencia, arp_valortotal FROM areceber_parcial " '15
        consulta += "WHERE arp_artid = " & AReceberTotal.art_id

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        AReceberParcial.Clear()
        While dr.Read

            mARecebParcial.ZeraValores()
            With mARecebParcial

                .arp_id = dr(0)
                .arp_artid = dr(1)
                .arp_datapagamento = dr(2)
                .arp_valor = dr(3)
                .arp_descrpagamento = dr(4).ToString
                .arp_desconto = dr(5)
                .arp_acrescimo = dr(6)
                .arp_funcionarioid = dr(7)
                .arp_funcionarionome = dr(8).ToString
                .arp_idcaixa = dr(9)
                .arp_pagodinheiro = dr(10)
                .arp_pagocartaocred = dr(11)
                .arp_pagocartaodeb = dr(12)
                .arp_pagopix = dr(13)
                .arp_pagotransferencia = dr(14)
                .arp_valortotal = dr(15)


            End With

            AReceberParcial.Add(New ClAReceberParcial(mARecebParcial))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazContaParcialDaLista(ByRef AReceberParcial As ClAReceberParcial, ByVal ListContasAReceberP As List(Of ClAReceberParcial)) As Boolean

        Dim mId As Integer = AReceberParcial.arp_id
        If ListContasAReceberP.Count > 0 Then
            If ListContasAReceberP.Exists(Function(ar As ClAReceberParcial) ar.arp_id = mId) Then

                For Each r As ClAReceberParcial In ListContasAReceberP

                    If r.arp_id = AReceberParcial.arp_id Then

                        With AReceberParcial

                            .arp_id = r.arp_id
                            .arp_artid = r.arp_artid
                            .arp_datapagamento = r.arp_datapagamento
                            .arp_valor = r.arp_valor
                            .arp_descrpagamento = r.arp_descrpagamento
                            .arp_desconto = r.arp_desconto
                            .arp_acrescimo = r.arp_acrescimo
                            .arp_funcionarioid = r.arp_funcionarioid
                            .arp_funcionarionome = r.arp_funcionarionome
                            .arp_idcaixa = r.arp_idcaixa
                            .arp_pagodinheiro = r.arp_pagodinheiro
                            .arp_pagocartaocred = r.arp_pagocartaocred
                            .arp_pagocartaodeb = r.arp_pagocartaodeb
                            .arp_pagopix = r.arp_pagopix
                            .arp_pagotransferencia = r.arp_pagotransferencia
                            .arp_valortotal = r.arp_valortotal
                        End With
                    End If
                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function TrazContasParcialLISTA(ByVal AReceberTotal As ClAReceberTotal, ByRef ListaParcial As List(Of ClAReceberParcial), ByVal ListTodasContasAReceberP As List(Of ClAReceberParcial)) As Boolean

        Dim mReceberParcial As New ClAReceberParcial
        If ListTodasContasAReceberP.Count > 0 Then
            If ListTodasContasAReceberP.Exists(Function(ar As ClAReceberParcial) ar.arp_artid = AReceberTotal.art_id) Then

                ListaParcial.Clear()
                For Each r As ClAReceberParcial In ListTodasContasAReceberP

                    If r.arp_artid = AReceberTotal.art_id Then

                        mReceberParcial.ZeraValores()
                        With mReceberParcial

                            .arp_id = r.arp_id
                            .arp_artid = r.arp_artid
                            .arp_datapagamento = r.arp_datapagamento
                            .arp_valor = r.arp_valor
                            .arp_descrpagamento = r.arp_descrpagamento
                            .arp_desconto = r.arp_desconto
                            .arp_acrescimo = r.arp_acrescimo
                            .arp_funcionarioid = r.arp_funcionarioid
                            .arp_funcionarionome = r.arp_funcionarionome
                            .arp_idcaixa = r.arp_idcaixa
                            .arp_pagodinheiro = r.arp_pagodinheiro
                            .arp_pagocartaocred = r.arp_pagocartaocred
                            .arp_pagocartaodeb = r.arp_pagocartaodeb
                            .arp_pagopix = r.arp_pagopix
                            .arp_pagotransferencia = r.arp_pagotransferencia
                            .arp_valortotal = r.arp_valortotal
                        End With
                        ListaParcial.Add(New ClAReceberParcial(mReceberParcial))
                    End If

                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function TrazListaContasParcialCaixa(ByVal Caixa As ClAbrirFecharCaixa, ByRef ListaParcial As List(Of ClAReceberParcial), ByVal ListTodasContasAReceberP As List(Of ClAReceberParcial)) As Boolean

        Dim mReceberParcial As New ClAReceberParcial
        If ListTodasContasAReceberP.Count > 0 Then
            If ListTodasContasAReceberP.Exists(Function(ar As ClAReceberParcial) ar.arp_idcaixa = Caixa.Af_id1) Then

                ListaParcial.Clear()
                For Each r As ClAReceberParcial In ListTodasContasAReceberP

                    If r.arp_idcaixa = Caixa.Af_id1 Then

                        mReceberParcial.ZeraValores()
                        With mReceberParcial

                            .arp_id = r.arp_id
                            .arp_artid = r.arp_artid
                            .arp_datapagamento = r.arp_datapagamento
                            .arp_valor = r.arp_valor
                            .arp_descrpagamento = r.arp_descrpagamento
                            .arp_desconto = r.arp_desconto
                            .arp_acrescimo = r.arp_acrescimo
                            .arp_funcionarioid = r.arp_funcionarioid
                            .arp_funcionarionome = r.arp_funcionarionome
                            .arp_idcaixa = r.arp_idcaixa
                            .arp_pagodinheiro = r.arp_pagodinheiro
                            .arp_pagocartaocred = r.arp_pagocartaocred
                            .arp_pagocartaodeb = r.arp_pagocartaodeb
                            .arp_pagopix = r.arp_pagopix
                            .arp_pagotransferencia = r.arp_pagotransferencia
                            .arp_valortotal = r.arp_valortotal
                        End With
                        ListaParcial.Add(New ClAReceberParcial(mReceberParcial))
                    End If

                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Sub TrazListAReceberParcial(ByRef AReceberParcial As List(Of ClAReceberParcial), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim dataNascimento As String = "", dataServico As String = ""
        Dim mAReceberParcial As New ClAReceberParcial

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClAReceberTotalDAO:TrazListAReceber"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT arp_id, arp_artid, arp_datapagamento, arp_valor, arp_descrpagamento, arp_desconto, " '5
        consulta += "arp_acrescimo, arp_funcionarioid, arp_funcionarionome, arp_idcaixa, arp_pagodinheiro, " '10
        consulta += "arp_pagocartaocred, arp_pagocartaodeb, arp_pagopix, arp_pagotransferencia, arp_valortotal FROM areceber_parcial " '15
        
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        AReceberParcial.Clear()
        While dr.Read

            mAReceberParcial.ZeraValores()

            With mAReceberParcial

                .arp_id = dr(0)
                .arp_artid = dr(1)
                .arp_datapagamento = dr(2)
                .arp_valor = dr(3)
                .arp_descrpagamento = dr(4).ToString
                .arp_desconto = dr(5)
                .arp_acrescimo = dr(6)
                .arp_funcionarioid = dr(7)
                .arp_funcionarionome = dr(8).ToString
                .arp_idcaixa = dr(9)
                .arp_pagodinheiro = dr(10)
                .arp_pagocartaocred = dr(11)
                .arp_pagocartaodeb = dr(12)
                .arp_pagopix = dr(13)
                .arp_pagotransferencia = dr(14)
                .arp_valortotal = dr(15)


            End With


            AReceberParcial.Add(New ClAReceberParcial(mAReceberParcial))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

End Class
