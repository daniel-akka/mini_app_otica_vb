Imports Npgsql
Public Class ClAPagarParcialDAO

    Public Sub incAPagarParcial(ByVal APagarParcial As ClAPagarParcial, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""


        sql = "INSERT INTO apagar_parcial(app_id, app_aptid, app_datapagamento, app_valor, "
        sql += "app_descrpagamento, app_desconto, app_acrescimo, app_funcionarioid, app_funcionarionome, app_idcaixa, app_pagodinheiro, app_pagocartaocred, "
        sql += "app_pagocartaodeb, app_pagopix, app_pagotransferencia, app_valortotal) "
        sql += "VALUES (DEFAULT, @app_aptid, @app_datapagamento, @app_valor, "
        sql += "@app_descrpagamento, @app_desconto, @app_acrescimo, @app_funcionarioid, @app_funcionarionome, @app_idcaixa, @app_pagodinheiro, @app_pagocartaocred, "
        sql += "@app_pagocartaodeb, @app_pagopix, @app_pagotransferencia, @app_valortotal) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@app_aptid", APagarParcial.app_aptid)
        comm.Parameters.Add("@app_datapagamento", APagarParcial.app_datapagamento)
        comm.Parameters.Add("@app_valor", APagarParcial.app_valor)
        comm.Parameters.Add("@app_descrpagamento", APagarParcial.app_descrpagamento)
        comm.Parameters.Add("@app_desconto", APagarParcial.app_desconto)
        comm.Parameters.Add("@app_acrescimo", APagarParcial.app_acrescimo)
        comm.Parameters.Add("@app_funcionarioid", APagarParcial.app_funcionarioid)
        comm.Parameters.Add("@app_funcionarionome", APagarParcial.app_funcionarionome)
        comm.Parameters.Add("@app_idcaixa", APagarParcial.app_idcaixa)
        comm.Parameters.Add("@app_pagodinheiro", APagarParcial.app_pagodinheiro)
        comm.Parameters.Add("@app_pagocartaocred", APagarParcial.app_pagocartaocred)
        comm.Parameters.Add("@app_pagocartaodeb", APagarParcial.app_pagocartaodeb)
        comm.Parameters.Add("@app_pagopix", APagarParcial.app_pagopix)
        comm.Parameters.Add("@app_pagotransferencia", APagarParcial.app_pagotransferencia)
        comm.Parameters.Add("@app_valortotal", APagarParcial.app_valortotal)

        comm.ExecuteNonQuery()

        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListAPagarParcial(ByVal APagarTotal As ClAPagarTotal, ByRef APagarParcial As List(Of ClAPagarParcial), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim dataNascimento As String = "", dataServico As String = ""
        Dim mARecebParcial As New ClAPagarParcial


        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClAPagarParcialDAO:TrazListAPagarParcial"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT app_id, app_aptid, app_datapagamento, app_valor, app_descrpagamento, app_desconto, " '5
        consulta += "app_acrescimo, app_funcionarioid, app_funcionarionome, app_idcaixa, app_pagodinheiro, " '10
        consulta += "app_pagocartaocred, app_pagocartaodeb, app_pagopix, app_pagotransferencia, app_valortotal FROM apagar_parcial " '15
        consulta += "WHERE app_artid = " & APagarTotal.apt_id

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        APagarParcial.Clear()
        While dr.Read

            mARecebParcial.ZeraValores()
            With mARecebParcial

                .app_id = dr(0)
                .app_aptid = dr(1)
                .app_datapagamento = dr(2)
                .app_valor = dr(3)
                .app_descrpagamento = dr(4).ToString
                .app_desconto = dr(5)
                .app_acrescimo = dr(6)
                .app_funcionarioid = dr(7)
                .app_funcionarionome = dr(8).ToString
                .app_idcaixa = dr(9)
                .app_pagodinheiro = dr(10)
                .app_pagocartaocred = dr(11)
                .app_pagocartaodeb = dr(12)
                .app_pagopix = dr(13)
                .app_pagotransferencia = dr(14)
                .app_valortotal = dr(15)


            End With

            APagarParcial.Add(New ClAPagarParcial(mARecebParcial))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazContaParcialDaLista(ByRef APagarParcial As ClAPagarParcial, ByVal ListContasAReceberP As List(Of ClAPagarParcial)) As Boolean

        Dim mId As Integer = APagarParcial.app_id
        If ListContasAReceberP.Count > 0 Then
            If ListContasAReceberP.Exists(Function(ar As ClAPagarParcial) ar.app_id = mId) Then

                For Each r As ClAPagarParcial In ListContasAReceberP

                    If r.app_id = APagarParcial.app_id Then

                        With APagarParcial

                            .app_id = r.app_id
                            .app_aptid = r.app_aptid
                            .app_datapagamento = r.app_datapagamento
                            .app_valor = r.app_valor
                            .app_descrpagamento = r.app_descrpagamento
                            .app_desconto = r.app_desconto
                            .app_acrescimo = r.app_acrescimo
                            .app_funcionarioid = r.app_funcionarioid
                            .app_funcionarionome = r.app_funcionarionome
                            .app_idcaixa = r.app_idcaixa
                            .app_pagodinheiro = r.app_pagodinheiro
                            .app_pagocartaocred = r.app_pagocartaocred
                            .app_pagocartaodeb = r.app_pagocartaodeb
                            .app_pagopix = r.app_pagopix
                            .app_pagotransferencia = r.app_pagotransferencia
                            .app_valortotal = r.app_valortotal
                        End With
                    End If
                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function TrazContasParcialLISTA(ByVal APagarTotal As ClAPagarTotal, ByRef ListaParcial As List(Of ClAPagarParcial), ByVal ListTodasContasAReceberP As List(Of ClAPagarParcial)) As Boolean

        Dim mReceberParcial As New ClAPagarParcial
        If ListTodasContasAReceberP.Count > 0 Then
            If ListTodasContasAReceberP.Exists(Function(ar As ClAPagarParcial) ar.app_aptid = APagarTotal.apt_id) Then

                ListaParcial.Clear()
                For Each r As ClAPagarParcial In ListTodasContasAReceberP

                    If r.app_aptid = APagarTotal.apt_id Then

                        mReceberParcial.ZeraValores()
                        With mReceberParcial

                            .app_id = r.app_id
                            .app_aptid = r.app_aptid
                            .app_datapagamento = r.app_datapagamento
                            .app_valor = r.app_valor
                            .app_descrpagamento = r.app_descrpagamento
                            .app_desconto = r.app_desconto
                            .app_acrescimo = r.app_acrescimo
                            .app_funcionarioid = r.app_funcionarioid
                            .app_funcionarionome = r.app_funcionarionome
                            .app_idcaixa = r.app_idcaixa
                            .app_pagodinheiro = r.app_pagodinheiro
                            .app_pagocartaocred = r.app_pagocartaocred
                            .app_pagocartaodeb = r.app_pagocartaodeb
                            .app_pagopix = r.app_pagopix
                            .app_pagotransferencia = r.app_pagotransferencia
                            .app_valortotal = r.app_valortotal
                        End With
                        ListaParcial.Add(New ClAPagarParcial(mReceberParcial))
                    End If

                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function TrazListaContasParcialCaixa(ByVal Caixa As ClAbrirFecharCaixa, ByRef ListaParcial As List(Of ClAPagarParcial), ByVal ListTodasContasAReceberP As List(Of ClAPagarParcial)) As Boolean

        Dim mReceberParcial As New ClAPagarParcial
        If ListTodasContasAReceberP.Count > 0 Then
            If ListTodasContasAReceberP.Exists(Function(ar As ClAPagarParcial) ar.app_idcaixa = Caixa.Af_id1) Then

                ListaParcial.Clear()
                For Each r As ClAPagarParcial In ListTodasContasAReceberP

                    If r.app_idcaixa = Caixa.Af_id1 Then

                        mReceberParcial.ZeraValores()
                        With mReceberParcial

                            .app_id = r.app_id
                            .app_aptid = r.app_aptid
                            .app_datapagamento = r.app_datapagamento
                            .app_valor = r.app_valor
                            .app_descrpagamento = r.app_descrpagamento
                            .app_desconto = r.app_desconto
                            .app_acrescimo = r.app_acrescimo
                            .app_funcionarioid = r.app_funcionarioid
                            .app_funcionarionome = r.app_funcionarionome
                            .app_idcaixa = r.app_idcaixa
                            .app_pagodinheiro = r.app_pagodinheiro
                            .app_pagocartaocred = r.app_pagocartaocred
                            .app_pagocartaodeb = r.app_pagocartaodeb
                            .app_pagopix = r.app_pagopix
                            .app_pagotransferencia = r.app_pagotransferencia
                            .app_valortotal = r.app_valortotal
                        End With
                        ListaParcial.Add(New ClAPagarParcial(mReceberParcial))
                    End If

                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Sub TrazListAPagarParcial(ByRef APagarParcial As List(Of ClAPagarParcial), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim dataNascimento As String = "", dataServico As String = ""
        Dim mAPagarParcial As New ClAPagarParcial

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClAReceberTotalDAO:TrazListAReceber"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT app_id, app_aptid, app_datapagamento, app_valor, app_descrpagamento, app_desconto, " '5
        consulta += "app_acrescimo, app_funcionarioid, app_funcionarionome, app_idcaixa, app_pagodinheiro, " '10
        consulta += "app_pagocartaocred, app_pagocartaodeb, app_pagopix, app_pagotransferencia, app_valortotal FROM apagar_parcial " '15

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        APagarParcial.Clear()
        While dr.Read

            mAPagarParcial.ZeraValores()

            With mAPagarParcial

                .app_id = dr(0)
                .app_aptid = dr(1)
                .app_datapagamento = dr(2)
                .app_valor = dr(3)
                .app_descrpagamento = dr(4).ToString
                .app_desconto = dr(5)
                .app_acrescimo = dr(6)
                .app_funcionarioid = dr(7)
                .app_funcionarionome = dr(8).ToString
                .app_idcaixa = dr(9)
                .app_pagodinheiro = dr(10)
                .app_pagocartaocred = dr(11)
                .app_pagocartaodeb = dr(12)
                .app_pagopix = dr(13)
                .app_pagotransferencia = dr(14)
                .app_valortotal = dr(15)


            End With


            APagarParcial.Add(New ClAPagarParcial(mAPagarParcial))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub


End Class
