Imports Npgsql
Public Class ClDespesaMensalDAO

    Public Sub incDespesaMensal(ByVal DespesaMensal As ClDespesaMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO despesa_mensal(dm_id, dm_data_inclusao, dm_alteracao, dm_fechado, dm_empresaid, dm_empresanome, dm_gpid, dm_gpdescricao, dm_sgpid, "
        sql += "dm_sgpdescricao, dm_data_despesa, dm_valor, dm_observacao) "
        sql += "VALUES (DEFAULT, DEFAULT, DEFAULT, DEFAULT, @dm_empresaid, @dm_empresanome, @dm_gpid, @dm_gpdescricao, @dm_sgpid, "
        sql += "@dm_sgpdescricao, @dm_data_despesa, @dm_valor, @dm_observacao)"


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@dm_empresaid", DespesaMensal.dm_empresaid)
        comm.Parameters.Add("@dm_empresanome", DespesaMensal.dm_empresanome)
        comm.Parameters.Add("@dm_gpid", DespesaMensal.dm_gpid)
        comm.Parameters.Add("@dm_gpdescricao", DespesaMensal.dm_gpdescricao)
        comm.Parameters.Add("@dm_sgpid", DespesaMensal.dm_sgpid)
        comm.Parameters.Add("@dm_sgpdescricao", DespesaMensal.dm_sgpdescricao)
        comm.Parameters.Add("@dm_data_despesa", DespesaMensal.dm_data_despesa)
        comm.Parameters.Add("@dm_valor", DespesaMensal.dm_valor)
        comm.Parameters.Add("@dm_observacao", DespesaMensal.dm_observacao)

        comm.ExecuteNonQuery()

        TrazListDespesaMensalDoBanco(MdlConexaoBD.ListaDespesaMensal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altDespesaMensal(ByVal DespesaMensal As ClDespesaMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE despesa_mensal SET dm_alteracao = @dm_alteracao, dm_fechado = @dm_fechado, dm_empresaid = @dm_empresaid, "
        sql += "dm_empresanome = @dm_empresanome, dm_gpid = @dm_gpid, dm_gpdescricao = @dm_gpdescricao, dm_sgpid = @dm_sgpid, "
        sql += "dm_sgpdescricao = @dm_sgpdescricao, dm_data_despesa = @dm_data_despesa, dm_valor = @dm_valor, dm_observacao = @dm_observacao WHERE dm_id = @dm_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@dm_id", DespesaMensal.dm_id)
        comm.Parameters.Add("@dm_empresaid", DespesaMensal.dm_empresaid)
        comm.Parameters.Add("@dm_empresanome", DespesaMensal.dm_empresanome)
        comm.Parameters.Add("@dm_gpid", DespesaMensal.dm_gpid)
        comm.Parameters.Add("@dm_gpdescricao", DespesaMensal.dm_gpdescricao)
        comm.Parameters.Add("@dm_sgpid", DespesaMensal.dm_sgpid)
        comm.Parameters.Add("@dm_sgpdescricao", DespesaMensal.dm_sgpdescricao)
        comm.Parameters.Add("@dm_data_despesa", DespesaMensal.dm_data_despesa)
        comm.Parameters.Add("@dm_valor", DespesaMensal.dm_valor)
        comm.Parameters.Add("@dm_observacao", DespesaMensal.dm_observacao)
        comm.Parameters.Add("@dm_alteracao", DespesaMensal.dm_alteracao)
        comm.Parameters.Add("@dm_fechado", DespesaMensal.dm_fechado)

        comm.ExecuteNonQuery()

        TrazListDespesaMensalDoBanco(MdlConexaoBD.ListaDespesaMensal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListDespesaMensalDoBanco(ByRef ClDespesaMensal As List(Of ClDespesaMensal), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mDespesaMensal As New ClDespesaMensal

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClDespesaMensalDAO:TrazListDespesaMensal"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT dm_id, dm_empresaid, dm_empresanome, dm_gpid, dm_gpdescricao, dm_sgpid, dm_sgpdescricao, "
        consulta += "dm_data_despesa, dm_data_inclusao, dm_valor, dm_observacao, dm_alteracao, dm_fechado FROM despesa_mensal"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        ClDespesaMensal.Clear()
        While dr.Read

            mDespesaMensal.zeraValores()
            With mDespesaMensal

                .dm_id = dr(0)
                .dm_empresaid = dr(1)
                .dm_empresanome = dr(2).ToString
                .dm_gpid = dr(3)
                .dm_gpdescricao = dr(4).ToString
                .dm_sgpid = dr(5)
                .dm_sgpdescricao = dr(6).ToString
                .dm_data_despesa = dr(7)
                .dm_data_inclusao = dr(8)
                .dm_valor = dr(9)
                .dm_observacao = dr(10).ToString
                .dm_alteracao = dr(11)
                .dm_fechado = dr(12)
            End With

            ClDespesaMensal.Add(New ClDespesaMensal(mDespesaMensal))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazDespesaMensalDoBancoDadosPorID(ByRef DespesaMensal As ClDespesaMensal, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClDespesaMensalDAO:TrazDespesaMensalDoBancoDadosPorID"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT dm_id, dm_empresaid, dm_empresanome, dm_gpid, dm_gpdescricao, dm_sgpid, dm_sgpdescricao, "
        consulta += "dm_data_despesa, dm_data_inclusao, dm_valor, dm_observacao, dm_alteracao, dm_fechado FROM despesa_mensal WHERE dm_id = " & DespesaMensal.dm_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            DespesaMensal.zeraValores()
            With DespesaMensal

                .dm_id = dr(0)
                .dm_empresaid = dr(1)
                .dm_empresanome = dr(2).ToString
                .dm_gpid = dr(3)
                .dm_gpdescricao = dr(4).ToString
                .dm_sgpid = dr(5)
                .dm_sgpdescricao = dr(6).ToString
                .dm_data_despesa = dr(7)
                .dm_data_inclusao = dr(8)
                .dm_valor = dr(9)
                .dm_observacao = dr(10).ToString
                .dm_alteracao = dr(11)
                .dm_fechado = dr(12)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazDespesaMensalDaListaPorID(ByRef DespesaMensal As ClDespesaMensal, ByVal ListaDespesaMensal As List(Of ClDespesaMensal)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each dm As ClDespesaMensal In ListaDespesaMensal

            If dm.dm_id = DespesaMensal.dm_id Then

                With DespesaMensal

                    .dm_id = dm.dm_id
                    .dm_empresaid = dm.dm_empresaid
                    .dm_empresanome = dm.dm_empresanome
                    .dm_gpid = dm.dm_gpid
                    .dm_gpdescricao = dm.dm_gpdescricao
                    .dm_sgpid = dm.dm_sgpid
                    .dm_sgpdescricao = dm.dm_sgpdescricao
                    .dm_data_despesa = dm.dm_data_despesa
                    .dm_data_inclusao = dm.dm_data_inclusao
                    .dm_valor = dm.dm_valor
                    .dm_observacao = dm.dm_observacao
                    .dm_alteracao = dm.dm_alteracao
                    .dm_fechado = dm.dm_fechado
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function PreencheListaImpressao(ByRef ListaDespesaMensalImpressao As List(Of ClDespesaMensalmpressao), ByVal GrupoDespMensal As ClGrupoDespMensal, ByVal ListaDespesaMensal As List(Of ClDespesaMensal)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mDespMensalImpressao As New ClDespesaMensalmpressao
        Dim mIDGrupo As Integer = 0
        Dim mSomaGrupo As Double = 0, mPrimeiroLaco As Boolean = True
        For Each sg As ClDespesaMensal In ListaDespesaMensal

            If GrupoDespMensal.gp_id > 0 Then 'Se vinher algum grupo:

                If sg.dm_gpid = GrupoDespMensal.gp_id Then

                    If mIDGrupo <> sg.dm_gpid Then 'Preenche só o Grupo:

                        If mPrimeiroLaco = False Then

                            mDespMensalImpressao.zeraValores()
                            mDespMensalImpressao.dm_valor = mSomaGrupo.ToString("#,##0.00")
                            ListaDespesaMensalImpressao.Add(New ClDespesaMensalmpressao(mDespMensalImpressao))
                            mSomaGrupo = 0
                        End If

                        mPrimeiroLaco = False
                        mIDGrupo = sg.dm_gpid
                        mDespMensalImpressao.zeraValores()
                        With mDespMensalImpressao

                            .dm_gpid = sg.dm_gpid
                            .dm_gpdescricao = sg.dm_gpdescricao

                        End With

                        ListaDespesaMensalImpressao.Add(New ClDespesaMensalmpressao(mDespMensalImpressao))
                    End If

                    mDespMensalImpressao.zeraValores()
                    mDespMensalImpressao.setaValores(sg)
                    mSomaGrupo += sg.dm_valor
                    With mDespMensalImpressao

                        .dm_empresaid = ""
                        .dm_empresanome = ""
                        .dm_gpid = ""
                        .dm_gpdescricao = ""
                    End With
                    mDeuCerto = True
                    ListaDespesaMensalImpressao.Add(New ClDespesaMensalmpressao(mDespMensalImpressao))
                End If

            Else

                If mIDGrupo <> sg.dm_gpid Then 'Preenche só o Grupo:

                    If mPrimeiroLaco = False Then

                        mDespMensalImpressao.zeraValores()
                        mDespMensalImpressao.dm_valor = mSomaGrupo.ToString("#,##0.00")
                        ListaDespesaMensalImpressao.Add(New ClDespesaMensalmpressao(mDespMensalImpressao))
                        mSomaGrupo = 0
                    End If

                    mPrimeiroLaco = False
                    mIDGrupo = sg.dm_gpid
                    mDespMensalImpressao.zeraValores()
                    With mDespMensalImpressao

                        .dm_gpid = sg.dm_gpid
                        .dm_gpdescricao = sg.dm_gpdescricao

                    End With

                    ListaDespesaMensalImpressao.Add(New ClDespesaMensalmpressao(mDespMensalImpressao))
                End If

                mDespMensalImpressao.zeraValores()
                mDespMensalImpressao.setaValores(sg)
                mSomaGrupo += sg.dm_valor
                With mDespMensalImpressao

                    .dm_empresaid = ""
                    .dm_empresanome = ""
                    .dm_gpid = ""
                    .dm_gpdescricao = ""
                End With
                mDeuCerto = True
                ListaDespesaMensalImpressao.Add(New ClDespesaMensalmpressao(mDespMensalImpressao))

            End If

        Next

        If mSomaGrupo > 0 Then

            mDespMensalImpressao.zeraValores()
            mDespMensalImpressao.dm_valor = mSomaGrupo.ToString("#,##0.00")
            ListaDespesaMensalImpressao.Add(New ClDespesaMensalmpressao(mDespMensalImpressao))
            mSomaGrupo = 0

        End If

        Return mDeuCerto
    End Function

    Public Sub delDespesaMensal(ByVal DespesaMensal As ClDespesaMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM despesa_mensal WHERE dm_id = @dm_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@dm_id", DespesaMensal.dm_id)

        comm.ExecuteNonQuery()

        TrazListDespesaMensalDoBanco(MdlConexaoBD.ListaDespesaMensal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

End Class
