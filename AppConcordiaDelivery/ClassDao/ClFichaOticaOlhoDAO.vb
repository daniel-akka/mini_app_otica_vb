Imports Npgsql
Public Class ClFichaOticaOlhoDAO

    Public Sub incFichaOticaOlho(ByVal FichaOticaOlho As ClFichaOticaOlho, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO ficha_otica_olho(foo_id, foo_ficha_id, foo_produto_id, foo_produto_nome, foo_olho, foo_distancia, foo_esf, "
        sql += "foo_cil, foo_eix, foo_dnp) "
        sql += "VALUES (DEFAULT, @foo_ficha_id, @foo_produto_id, @foo_produto_nome, @foo_olho, @foo_distancia, "
        sql += "@foo_esf, @foo_cil, @foo_eix, @foo_dnp)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@foo_ficha_id", FichaOticaOlho.foo_ficha_id)
        comm.Parameters.Add("@foo_produto_id", FichaOticaOlho.foo_produto_id)
        comm.Parameters.Add("@foo_produto_nome", FichaOticaOlho.foo_produto_nome)
        comm.Parameters.Add("@foo_olho", FichaOticaOlho.foo_olho)
        comm.Parameters.Add("@foo_distancia", FichaOticaOlho.foo_distancia)
        comm.Parameters.Add("@foo_esf", FichaOticaOlho.foo_esf)
        comm.Parameters.Add("@foo_cil", FichaOticaOlho.foo_cil)
        comm.Parameters.Add("@foo_eix", FichaOticaOlho.foo_eix)
        comm.Parameters.Add("@foo_dnp", FichaOticaOlho.foo_dnp)

        comm.ExecuteNonQuery()

        TrazListFichaOticaOlho_BD(MdlConexaoBD.ListaFichaOticaOlho, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altFichaOticaOlho(ByVal FichaOticaOlho As ClFichaOticaOlho, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE ficha_otica_olho SET foo_ficha_id = @foo_ficha_id, foo_produto_id = @foo_produto_id, foo_produto_nome = @foo_produto_nome, "
        sql += "foo_olho = @foo_olho, foo_distancia = @foo_distancia, foo_esf = @foo_esf, "
        sql += "foo_cil = @foo_cil, foo_eix = @foo_eix, foo_dnp = @foo_dnp "
        sql += "WHERE foo_id = @foo_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@foo_id", FichaOticaOlho.foo_id)
        comm.Parameters.Add("@foo_ficha_id", FichaOticaOlho.foo_ficha_id)
        comm.Parameters.Add("@foo_produto_id", FichaOticaOlho.foo_produto_id)
        comm.Parameters.Add("@foo_produto_nome", FichaOticaOlho.foo_produto_nome)
        comm.Parameters.Add("@foo_olho", FichaOticaOlho.foo_olho)
        comm.Parameters.Add("@foo_distancia", FichaOticaOlho.foo_distancia)
        comm.Parameters.Add("@foo_esf", FichaOticaOlho.foo_esf)
        comm.Parameters.Add("@foo_cil", FichaOticaOlho.foo_cil)
        comm.Parameters.Add("@foo_eix", FichaOticaOlho.foo_eix)
        comm.Parameters.Add("@foo_dnp", FichaOticaOlho.foo_dnp)
        comm.ExecuteNonQuery()

        TrazListFichaOticaOlho_BD(MdlConexaoBD.ListaFichaOticaOlho, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaFichaOticaOlho(ByVal FichaOticaOlho As ClFichaOticaOlho, Optional ByVal Operacao As String = "I") As Boolean

        'If Trim(FichaOticaOlho.aNome).Equals("") Then MsgBox("Informe um NOME para o FichaOticaOlho!") : Return False

        'Dim consulta As String = ""
        'If Operacao.Equals("I") Then
        '    consulta = "SELECT anome FROM FichaOticaOlho WHERE anome = '" & FichaOticaOlho.aNome & "'"
        'Else
        '    consulta = "SELECT anome FROM FichaOticaOlho WHERE aid <> " & FichaOticaOlho.aId & " AND anome = '" & FichaOticaOlho.aNome & "'"
        'End If
        'If FichaOticaOlhoConsulta(FichaOticaOlho, consulta, MdlConexaoBD.conectionPadrao) Then
        '    MsgBox("O FichaOticaOlho """ & FichaOticaOlho.aNome & """ já existe em outro CADASTRO !") : Return False
        'End If

        Return True
    End Function

    Public Sub TrazListFichaOticaOlho_BD(ByRef FichaOticaOlho As List(Of ClFichaOticaOlho), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaOlhoDAO:TrazListFichaOticaOlhos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT foo_id, foo_ficha_id, foo_produto_id, foo_produto_nome, foo_olho, foo_distancia, foo_esf, foo_cil, foo_eix, foo_dnp " '9
        consulta += "FROM ficha_otica_olho"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        FichaOticaOlho.Clear()
        While dr.Read

            FichaOticaOlho.Add(New ClFichaOticaOlho(dr(0), dr(1), dr(2), dr(3).ToString, dr(4).ToString, dr(5).ToString, _
                                            dr(6).ToString, dr(7).ToString, dr(8).ToString, dr(9).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazFichaOticaOlho(ByRef vFichaOticaOlho As ClFichaOticaOlho, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaOlhoDAO:TrazFichaOticaOlho"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT foo_id, foo_ficha_id, foo_produto_id, foo_produto_nome, foo_olho, foo_distancia, foo_esf, foo_cil, foo_eix, foo_dnp " '9
        consulta += "FROM ficha_otica_olho WHERE foo_id = " & vFichaOticaOlho.foo_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vFichaOticaOlho

                .foo_id = dr(0)
                .foo_ficha_id = dr(1)
                .foo_produto_id = dr(2)
                .foo_produto_nome = dr(3).ToString
                .foo_olho = dr(4).ToString
                .foo_distancia = dr(5).ToString
                .foo_esf = dr(6).ToString
                .foo_cil = dr(7).ToString
                .foo_eix = dr(8).ToString
                .foo_dnp = dr(9).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFichaOticaOlho_IdFicha_BD(ByVal vFichaOtica As ClFichaOtica, ByRef vListaFichaOlho As List(Of ClFichaOticaOlho), ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mNovoObjeto As New ClFichaOticaOlho

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaOlhoDAO:TrazFichaOticaOlho"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT foo_id, foo_ficha_id, foo_produto_id, foo_produto_nome, foo_olho, foo_distancia, foo_esf, foo_cil, foo_eix, foo_dnp " '9
        consulta += "FROM ficha_otica_olho WHERE foo_ficha_id = " & vFichaOtica.fo_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With mNovoObjeto

                .foo_id = dr(0)
                .foo_ficha_id = dr(1)
                .foo_produto_id = dr(2)
                .foo_produto_nome = dr(3).ToString
                .foo_olho = dr(4).ToString
                .foo_distancia = dr(5).ToString
                .foo_esf = dr(6).ToString
                .foo_cil = dr(7).ToString
                .foo_eix = dr(8).ToString
                .foo_dnp = dr(9).ToString
            End With

            vListaFichaOlho.Add(New ClFichaOticaOlho(mNovoObjeto))

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFichaOticaOlhoIdDaListaMDL(ByRef vFichaOticaOlho As ClFichaOticaOlho) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ClFichaOticaOlho In MdlConexaoBD.ListaFichaOticaOlho

            If a.foo_id.Equals(vFichaOticaOlho.foo_id) Then

                vFichaOticaOlho.SetaValores(a)
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazFichaOticaOlhoIdFicha_LIST_MDL(ByVal vFichaOtica As ClFichaOtica, ByRef vListaFichaOlho As List(Of ClFichaOticaOlho)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mNovoObjeto As New ClFichaOticaOlho

        If vListaFichaOlho.Count > 0 Then vListaFichaOlho.Clear()
        For Each a As ClFichaOticaOlho In MdlConexaoBD.ListaFichaOticaOlho

            If a.foo_ficha_id.Equals(vFichaOtica.fo_id) Then

                mNovoObjeto.SetaValores(a)
                mDeuCerto = True

                vListaFichaOlho.Add(New ClFichaOticaOlho(mNovoObjeto))
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazFichaOticaOlhoIdFicha_LIST(ByVal vFichaOtica As ClFichaOtica, ByRef vNovaLista As List(Of ClFichaOticaOlho), ByVal vListaFichaOticaOlhos As List(Of ClFichaOticaOlho)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mFichaOlho As New ClFichaOticaOlho
        If vListaFichaOticaOlhos.Count < 1 Then Return False

        For Each a As ClFichaOticaOlho In vListaFichaOticaOlhos

            If a.foo_ficha_id.Equals(vFichaOtica.fo_id) Then

                mFichaOlho.SetaValores(a)
                mDeuCerto = True

                vNovaLista.Add(New ClFichaOticaOlho(mFichaOlho))
            End If
        Next

        Return mDeuCerto
    End Function

    Public Sub delFichaOticaOlho(ByVal vFichaOticaOlho As ClFichaOticaOlho, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM ficha_otica_olho WHERE foo_id = @foo_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@foo_id", vFichaOticaOlho.foo_id)

        comm.ExecuteNonQuery()

        TrazListFichaOticaOlho_BD(MdlConexaoBD.ListaFichaOticaOlho, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delFichaOticaOlho_IdFicha(ByVal vFichaOtica As ClFichaOtica, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM ficha_otica_olho WHERE foo_ficha_id = @foo_ficha_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@foo_ficha_id", vFichaOtica.fo_id)


        comm.ExecuteNonQuery()

        TrazListFichaOticaOlho_BD(MdlConexaoBD.ListaFichaOticaOlho, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function FichaOticaOlhoConsulta(ByRef FichaOticaOlho As ClFichaOticaOlho, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaOlhoDAO:FichaOticaOlhoConsulta"":: " & ex.Message)
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
