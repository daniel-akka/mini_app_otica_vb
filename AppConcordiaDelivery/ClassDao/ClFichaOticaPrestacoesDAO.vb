Imports Npgsql
Public Class ClFichaOticaPrestacoesDAO

    Public Sub incFichaOticaPrestacoes(ByVal FichaOticaPrestacoes As ClFichaOticaPrestacoes, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO ficha_otica_prestacoes(fpp_id, fpp_ficha_id, fpp_data, fpp_prestacao, fpp_valor, fpp_visto) "
        sql += "VALUES (DEFAULT, @fpp_ficha_id, @fpp_data, @fpp_prestacao, @fpp_valor, @fpp_visto) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@fpp_ficha_id", FichaOticaPrestacoes.fpp_ficha_id)
        comm.Parameters.Add("@fpp_data", FichaOticaPrestacoes.fpp_data)
        comm.Parameters.Add("@fpp_prestacao", FichaOticaPrestacoes.fpp_prestacao)
        comm.Parameters.Add("@fpp_valor", FichaOticaPrestacoes.fpp_valor)
        comm.Parameters.Add("@fpp_visto", FichaOticaPrestacoes.fpp_visto)

        comm.ExecuteNonQuery()

        TrazListFichaOticaPrestacoes_BD(MdlConexaoBD.ListaFichaOticaPrestacoes, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altFichaOticaPrestacoes(ByVal FichaOticaPrestacoes As ClFichaOticaPrestacoes, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE ficha_otica_prestacoes SET fpp_ficha_id = @fpp_ficha_id, fpp_data = @fpp_data, fpp_prestacao = @fpp_prestacao, "
        sql += "fpp_valor = @fpp_valor, fpp_visto = @fpp_visto "
        sql += "WHERE fpp_id = @fpp_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@fpp_id", FichaOticaPrestacoes.fpp_id)
        comm.Parameters.Add("@fpp_ficha_id", FichaOticaPrestacoes.fpp_ficha_id)
        comm.Parameters.Add("@fpp_data", FichaOticaPrestacoes.fpp_data)
        comm.Parameters.Add("@fpp_prestacao", FichaOticaPrestacoes.fpp_prestacao)
        comm.Parameters.Add("@fpp_valor", FichaOticaPrestacoes.fpp_valor)
        comm.Parameters.Add("@fpp_visto", FichaOticaPrestacoes.fpp_visto)
        comm.ExecuteNonQuery()

        TrazListFichaOticaPrestacoes_BD(MdlConexaoBD.ListaFichaOticaPrestacoes, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaFichaOticaPrestacoes(ByVal FichaOticaPrestacoes As ClFichaOticaPrestacoes, Optional ByVal Operacao As String = "I") As Boolean

        'If Trim(FichaOticaPrestacoes.aNome).Equals("") Then MsgBox("Informe um NOME para o FichaOticaPrestacoes!") : Return False

        'Dim consulta As String = ""
        'If Operacao.Equals("I") Then
        '    consulta = "SELECT anome FROM FichaOticaPrestacoes WHERE anome = '" & FichaOticaPrestacoes.aNome & "'"
        'Else
        '    consulta = "SELECT anome FROM FichaOticaPrestacoes WHERE aid <> " & FichaOticaPrestacoes.aId & " AND anome = '" & FichaOticaPrestacoes.aNome & "'"
        'End If
        'If FichaOticaPrestacoesConsulta(FichaOticaPrestacoes, consulta, MdlConexaoBD.conectionPadrao) Then
        '    MsgBox("O FichaOticaPrestacoes """ & FichaOticaPrestacoes.aNome & """ já existe em outro CADASTRO !") : Return False
        'End If

        Return True
    End Function

    Public Sub TrazListFichaOticaPrestacoes_BD(ByRef FichaOticaPrestacoes As List(Of ClFichaOticaPrestacoes), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaPrestacoesDAO:TrazListFichaOticaPrestacoess"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT fpp_id, fpp_ficha_id, fpp_data, fpp_prestacao, fpp_valor, fpp_visto " '5
        consulta += "FROM ficha_otica_prestacoes"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        FichaOticaPrestacoes.Clear()
        While dr.Read

            FichaOticaPrestacoes.Add(New ClFichaOticaPrestacoes(dr(0), dr(1), dr(2), dr(3).ToString, dr(4), dr(5).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazFichaOticaPrestacoes(ByRef vFichaOticaPrestacoes As ClFichaOticaPrestacoes, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaPrestacoesDAO:TrazFichaOticaPrestacoes"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT fpp_id, fpp_ficha_id, fpp_data, fpp_prestacao, fpp_valor, fpp_visto " '5
        consulta += "FROM ficha_otica_prestacoes WHERE fpp_id = " & vFichaOticaPrestacoes.fpp_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vFichaOticaPrestacoes

                .fpp_id = dr(0)
                .fpp_ficha_id = dr(1)
                .fpp_data = dr(2)
                .fpp_prestacao = dr(3).ToString
                .fpp_valor = dr(4)
                .fpp_visto = dr(5).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFichaOticaPrestacoes_IdFicha_BD(ByVal vFichaOtica As ClFichaOtica, ByRef vListaPrestacoes As List(Of ClFichaOticaPrestacoes), ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mNovoObjeto As New ClFichaOticaPrestacoes

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaPrestacoesDAO:TrazFichaOticaPrestacoes"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT fpp_id, fpp_ficha_id, fpp_data, fpp_prestacao, fpp_valor, fpp_visto " '5
        consulta += "FROM ficha_otica_prestacoes WHERE fpp_ficha_id = " & vFichaOtica.fo_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With mNovoObjeto

                .fpp_id = dr(0)
                .fpp_ficha_id = dr(1)
                .fpp_data = dr(2)
                .fpp_prestacao = dr(3).ToString
                .fpp_valor = dr(4)
                .fpp_visto = dr(5).ToString
            End With

            vListaPrestacoes.Add(New ClFichaOticaPrestacoes(mNovoObjeto))

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFichaOticaPrestacoesIdDaListaMDL(ByRef vFichaOticaPrestacoes As ClFichaOticaPrestacoes) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ClFichaOticaPrestacoes In MdlConexaoBD.ListaFichaOticaPrestacoes

            If a.fpp_id.Equals(vFichaOticaPrestacoes.fpp_id) Then

                vFichaOticaPrestacoes.SetaValores(a)
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazFichaOticaPrestacoesIdFicha_LIST_MDL(ByVal vFichaOtica As ClFichaOtica, ByRef vListaPrestacoes As List(Of ClFichaOticaPrestacoes)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mNovoObjeto As New ClFichaOticaPrestacoes

        If vListaPrestacoes.Count > 0 Then vListaPrestacoes.Clear()
        For Each a As ClFichaOticaPrestacoes In MdlConexaoBD.ListaFichaOticaPrestacoes

            If a.fpp_ficha_id.Equals(vFichaOtica.fo_id) Then

                mNovoObjeto.SetaValores(a)
                mDeuCerto = True

                vListaPrestacoes.Add(New ClFichaOticaPrestacoes(mNovoObjeto))
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazFichaOticaPrestacoesIdFicha_LIST(ByVal vFichaOtica As ClFichaOtica, ByRef vNovaLista As List(Of ClFichaOticaPrestacoes), ByVal vListaFichaOticaPrestacoess As List(Of ClFichaOticaPrestacoes)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mFichaPrestacoes As New ClFichaOticaPrestacoes
        If vListaFichaOticaPrestacoess.Count < 1 Then Return False

        For Each a As ClFichaOticaPrestacoes In vListaFichaOticaPrestacoess

            If a.fpp_ficha_id.Equals(vFichaOtica.fo_id) Then

                mFichaPrestacoes.SetaValores(a)
                mDeuCerto = True

                vNovaLista.Add(New ClFichaOticaPrestacoes(mFichaPrestacoes))
            End If
        Next

        Return mDeuCerto
    End Function

    Public Sub delFichaOticaPrestacoes(ByVal vFichaOticaPrestacoes As ClFichaOticaPrestacoes, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM ficha_otica_prestacoes WHERE fpp_id = @fpp_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fpp_id", vFichaOticaPrestacoes.fpp_id)

        comm.ExecuteNonQuery()

        TrazListFichaOticaPrestacoes_BD(MdlConexaoBD.ListaFichaOticaPrestacoes, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delFichaOticaPrestacoes_IdFicha(ByVal vFichaOtica As ClFichaOtica, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM ficha_otica_prestacoes WHERE fpp_ficha_id = @fpp_ficha_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fpp_ficha_id", vFichaOtica.fo_id)


        comm.ExecuteNonQuery()

        TrazListFichaOticaPrestacoes_BD(MdlConexaoBD.ListaFichaOticaPrestacoes, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function FichaOticaPrestacoesConsulta(ByRef FichaOticaPrestacoes As ClFichaOticaPrestacoes, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaPrestacoesDAO:FichaOticaPrestacoesConsulta"":: " & ex.Message)
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

End Class
