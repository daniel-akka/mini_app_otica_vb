Imports Npgsql
Public Class ClSubGrupoDespMensalDAO

    Public Sub incSubGrupoDespMensal(ByVal SubGrupoDespMensal As ClSubGrupoDespMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO subgrupo_desp_m(sgp_id, sgp_gpid, sgp_gpdescricao, sgp_descricao, sgp_valorpadrao) "
        sql += "VALUES (DEFAULT, @sgp_gpid, @sgp_gpdescricao, @sgp_descricao, @sgp_valorpadrao)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@sgp_gpid", SubGrupoDespMensal.sgp_gpid)
        comm.Parameters.Add("@sgp_gpdescricao", SubGrupoDespMensal.sgp_gpdescricao)
        comm.Parameters.Add("@sgp_descricao", SubGrupoDespMensal.sgp_descricao)
        comm.Parameters.Add("@sgp_valorpadrao", SubGrupoDespMensal.sgp_valorpadrao)
        comm.ExecuteNonQuery()

        TrazListaSubGrupoDespMensalDoBANCO(MdlConexaoBD.mdlListSubGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altSubGrupoDespMensal(ByVal SubGrupoDespMensal As ClSubGrupoDespMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE subgrupo_desp_m SET sgp_gpid = @sgp_gpid, sgp_gpdescricao = @sgp_gpdescricao, sgp_descricao = @sgp_descricao, sgp_valorpadrao = @sgp_valorpadrao WHERE sgp_id = @sgp_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@sgp_id", SubGrupoDespMensal.sgp_id)
        comm.Parameters.Add("@sgp_gpid", SubGrupoDespMensal.sgp_gpid)
        comm.Parameters.Add("@sgp_gpdescricao", SubGrupoDespMensal.sgp_gpdescricao)
        comm.Parameters.Add("@sgp_descricao", SubGrupoDespMensal.sgp_descricao)
        comm.Parameters.Add("@sgp_valorpadrao", SubGrupoDespMensal.sgp_valorpadrao)

        comm.ExecuteNonQuery()

        TrazListaSubGrupoDespMensalDoBANCO(MdlConexaoBD.mdlListSubGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaSubGrupoDespMensal(ByVal SubGrupo As ClSubGrupoDespMensal, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(SubGrupo.sgp_descricao).Equals("") Then MsgBox("Informe uma Descricao para o GRUPO!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT sgp_descricao FROM subgrupo_desp_m WHERE sgp_descricao = '" & SubGrupo.sgp_descricao & "'"
        Else
            consulta = "SELECT sgp_descricao FROM subgrupo_desp_m WHERE sgp_id <> " & SubGrupo.sgp_id & " AND sgp_descricao = '" & SubGrupo.sgp_descricao & "'"
        End If

        If SubGrupoConsulta(SubGrupo, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("Este SUB GRUPO: """ & SubGrupo.sgp_descricao & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Function SubGrupoConsulta(ByRef SubGrupo As ClSubGrupoDespMensal, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClSubGrupoDespMensalDAO:SubGrupoConsulta"":: " & ex.Message)
            Return False
        End Try

        consulta = Query
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader
        If dr.HasRows Then
            Return True
        Else
            Return False
        End If

        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub TrazListaSubGrupoDespMensalDoBANCO(ByRef ListSubGrupoDespMensal As List(Of ClSubGrupoDespMensal), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mSubGrupoDespMensal As New ClSubGrupoDespMensal

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClSubGrupoDespMensalDAO:TrazListSubGrupoDespMensal"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT sgp_id, sgp_gpid, sgp_descricao, sgp_gpdescricao, sgp_valorpadrao FROM subgrupo_desp_m "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        ListSubGrupoDespMensal.Clear()
        While dr.Read

            mSubGrupoDespMensal.zeraValores()
            With mSubGrupoDespMensal

                .sgp_id = dr(0)
                .sgp_gpid = dr(1)
                .sgp_descricao = dr(2).ToString
                .sgp_gpdescricao = dr(3).ToString
                .sgp_valorpadrao = dr(4)
            End With

            ListSubGrupoDespMensal.Add(New ClSubGrupoDespMensal(mSubGrupoDespMensal))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazSubGrupoDespMensalDoBancoDadosPorID(ByRef SubGrupoDespMensal As ClSubGrupoDespMensal, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mSubGrupoDespMensal As New ClSubGrupoDespMensal

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClSubGrupoDespMensalDAO:TrazSubGrupoDespMensalDoBancoDados"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT sgp_id, sgp_gpid, sgp_descricao, sgp_gpdescricao, sgp_valorpadrao FROM subgrupo_desp_m WHERE sgp_id = " & SubGrupoDespMensal.sgp_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            SubGrupoDespMensal.zeraValores()
            With SubGrupoDespMensal

                mSubGrupoDespMensal.zeraValores()
                With mSubGrupoDespMensal

                    .sgp_id = dr(0)
                    .sgp_gpid = dr(1)
                    .sgp_descricao = dr(2).ToString
                    .sgp_gpdescricao = dr(3).ToString
                    .sgp_valorpadrao = dr(4)
                End With
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazSubGrupoDespMensalDaListaPorID(ByRef SubGrupoDespMensal As ClSubGrupoDespMensal, ByVal ListaSubGrupoDespMensal As List(Of ClSubGrupoDespMensal)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each sg As ClSubGrupoDespMensal In ListaSubGrupoDespMensal

            If sg.sgp_id = SubGrupoDespMensal.sgp_id Then

                With SubGrupoDespMensal

                    .sgp_id = sg.sgp_id
                    .sgp_gpid = sg.sgp_gpid
                    .sgp_descricao = sg.sgp_descricao
                    .sgp_gpdescricao = sg.sgp_gpdescricao
                    .sgp_valorpadrao = sg.sgp_valorpadrao
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function PreencheListaImpressao(ByRef ListaSubGrupoImpressao As List(Of ClSubGrupoDespMensalImpr), ByVal GrupoDespMensal As ClGrupoDespMensal, ByVal ListaSubGrupoDespMensal As List(Of ClSubGrupoDespMensal)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mSubGrupoImpressao As New ClSubGrupoDespMensalImpr
        Dim mIDGrupo As Integer = 0
        For Each sg As ClSubGrupoDespMensal In ListaSubGrupoDespMensal

            If GrupoDespMensal.gp_id > 0 Then 'Se vinher algum grupo:

                If sg.sgp_gpid = GrupoDespMensal.gp_id Then

                    If mIDGrupo <> sg.sgp_gpid Then 'Preenche só o Grupo:

                        mIDGrupo = sg.sgp_gpid
                        mSubGrupoImpressao.zeraValores()
                        With mSubGrupoImpressao
                            .sgp_gpid = sg.sgp_gpid
                            .sgp_gpdescricao = sg.sgp_gpdescricao
                        End With

                        ListaSubGrupoImpressao.Add(New ClSubGrupoDespMensalImpr(mSubGrupoImpressao))
                    End If

                    mSubGrupoImpressao.zeraValores()
                    With mSubGrupoImpressao

                        .sgp_id = sg.sgp_id
                        .sgp_descricao = sg.sgp_descricao
                        .sgp_valorpadrao = sg.sgp_valorpadrao.ToString("#,##0.00")
                    End With
                    mDeuCerto = True
                    ListaSubGrupoImpressao.Add(New ClSubGrupoDespMensalImpr(mSubGrupoImpressao))
                End If

            Else

                If mIDGrupo <> sg.sgp_gpid Then 'Preenche só o Grupo:

                    mIDGrupo = sg.sgp_gpid
                    mSubGrupoImpressao.zeraValores()
                    With mSubGrupoImpressao
                        .sgp_gpid = sg.sgp_gpid
                        .sgp_gpdescricao = sg.sgp_gpdescricao
                    End With

                    ListaSubGrupoImpressao.Add(New ClSubGrupoDespMensalImpr(mSubGrupoImpressao))
                End If

                mSubGrupoImpressao.zeraValores()
                With mSubGrupoImpressao

                    .sgp_id = sg.sgp_id
                    .sgp_descricao = sg.sgp_descricao
                    .sgp_valorpadrao = sg.sgp_valorpadrao.ToString("#,##0.00")
                End With
                mDeuCerto = True
                ListaSubGrupoImpressao.Add(New ClSubGrupoDespMensalImpr(mSubGrupoImpressao))

            End If

        Next

        Return mDeuCerto
    End Function

    Public Function TrazListaSubGrupoDespMensalDaListaPorGrupoID(ByVal GrupoDespMensal As ClGrupoDespMensal, ByRef ListSubGrupoDespMensal As List(Of ClSubGrupoDespMensal), ByVal ListaSubGrupoDespMensal As List(Of ClSubGrupoDespMensal)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mSubGrupoDespMensal As New ClSubGrupoDespMensal

        For Each sg As ClSubGrupoDespMensal In ListaSubGrupoDespMensal

            If sg.sgp_gpid = GrupoDespMensal.gp_id Then

                mSubGrupoDespMensal.zeraValores()
                With mSubGrupoDespMensal

                    .sgp_id = sg.sgp_id
                    .sgp_gpid = sg.sgp_gpid
                    .sgp_descricao = sg.sgp_descricao
                    .sgp_gpdescricao = sg.sgp_gpdescricao
                    .sgp_valorpadrao = sg.sgp_valorpadrao
                End With

                ListSubGrupoDespMensal.Add(New ClSubGrupoDespMensal(mSubGrupoDespMensal))
                mDeuCerto = True
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazListaSubGrupoDespMensalDaLista(ByRef ListSubGrupoDespMensal As List(Of ClSubGrupoDespMensal), ByVal ListaSubGrupoDespMensal As List(Of ClSubGrupoDespMensal)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mSubGrupoDespMensal As New ClSubGrupoDespMensal

        For Each sg As ClSubGrupoDespMensal In ListaSubGrupoDespMensal

            mSubGrupoDespMensal.zeraValores()
            With mSubGrupoDespMensal

                .sgp_id = sg.sgp_id
                .sgp_gpid = sg.sgp_gpid
                .sgp_descricao = sg.sgp_descricao
                .sgp_gpdescricao = sg.sgp_gpdescricao
                .sgp_valorpadrao = sg.sgp_valorpadrao
            End With

            ListSubGrupoDespMensal.Add(New ClSubGrupoDespMensal(mSubGrupoDespMensal))
            mDeuCerto = True
        Next

        Return mDeuCerto
    End Function

    Public Sub delSubGrupoDespMensal(ByVal SubGrupoDespMensal As ClSubGrupoDespMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM subgrupo_desp_m WHERE sgp_id = @sgp_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@sgp_id", SubGrupoDespMensal.sgp_id)

        comm.ExecuteNonQuery()

        TrazListaSubGrupoDespMensalDoBANCO(MdlConexaoBD.mdlListSubGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

End Class
