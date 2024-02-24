Imports Npgsql
Public Class ClFichaOticaProdutoDAO

    Public Sub incFichaOticaProduto(ByVal FichaOticaProduto As ClFichaOticaProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO ficha_otica_produto(fop_id, fop_ficha_id, fop_produto_id, fop_produto_nome, fop_produto_unidade, "
        sql += "fop_quantidade, fop_preco_venda, fop_total, fop_cor, fop_referencia) "
        sql += "VALUES (DEFAULT, @fop_ficha_id, @fop_produto_id, @fop_produto_nome, @fop_produto_unidade, @fop_quantidade, "
        sql += "@fop_preco_venda, @fop_total, @fop_cor, @fop_referencia)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@fop_ficha_id", FichaOticaProduto.fop_ficha_id)
        comm.Parameters.Add("@fop_produto_id", FichaOticaProduto.fop_produto_id)
        comm.Parameters.Add("@fop_produto_nome", FichaOticaProduto.fop_produto_nome)
        comm.Parameters.Add("@fop_produto_unidade", FichaOticaProduto.fop_produto_unidade)
        comm.Parameters.Add("@fop_quantidade", FichaOticaProduto.fop_quantidade)
        comm.Parameters.Add("@fop_preco_venda", FichaOticaProduto.fop_preco_venda)
        comm.Parameters.Add("@fop_total", FichaOticaProduto.fop_total)
        comm.Parameters.Add("@fop_cor", FichaOticaProduto.fop_cor)
        comm.Parameters.Add("@fop_referencia", FichaOticaProduto.fop_referencia)

        comm.ExecuteNonQuery()

        TrazListFichaOticaProduto_BD(MdlConexaoBD.ListaFichaOticaProduto, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altFichaOticaProduto(ByVal FichaOticaProduto As ClFichaOticaProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE ficha_otica_produto SET fop_ficha_id = @fop_ficha_id, fop_produto_id = @fop_produto_id, fop_produto_nome = @fop_produto_nome, "
        sql += "fop_produto_unidade = @fop_produto_unidade, fop_quantidade = @fop_quantidade, fop_preco_venda = @fop_preco_venda, "
        sql += "fop_total = @fop_total, fop_cor = @fop_cor, fop_referencia = @fop_referencia "
        sql += "WHERE fop_id = @fop_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@fop_id", FichaOticaProduto.fop_id)
        comm.Parameters.Add("@fop_ficha_id", FichaOticaProduto.fop_ficha_id)
        comm.Parameters.Add("@fop_produto_id", FichaOticaProduto.fop_produto_id)
        comm.Parameters.Add("@fop_produto_nome", FichaOticaProduto.fop_produto_nome)
        comm.Parameters.Add("@fop_produto_unidade", FichaOticaProduto.fop_produto_unidade)
        comm.Parameters.Add("@fop_quantidade", FichaOticaProduto.fop_quantidade)
        comm.Parameters.Add("@fop_preco_venda", FichaOticaProduto.fop_preco_venda)
        comm.Parameters.Add("@fop_total", FichaOticaProduto.fop_total)
        comm.Parameters.Add("@fop_cor", FichaOticaProduto.fop_cor)
        comm.Parameters.Add("@fop_referencia", FichaOticaProduto.fop_referencia)
        comm.ExecuteNonQuery()

        TrazListFichaOticaProduto_BD(MdlConexaoBD.ListaFichaOticaProduto, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaFichaOticaProduto(ByVal FichaOticaProduto As ClFichaOticaProduto, Optional ByVal Operacao As String = "I") As Boolean

        'If Trim(FichaOticaProduto.aNome).Equals("") Then MsgBox("Informe um NOME para o FichaOticaProduto!") : Return False

        'Dim consulta As String = ""
        'If Operacao.Equals("I") Then
        '    consulta = "SELECT anome FROM FichaOticaProduto WHERE anome = '" & FichaOticaProduto.aNome & "'"
        'Else
        '    consulta = "SELECT anome FROM FichaOticaProduto WHERE aid <> " & FichaOticaProduto.aId & " AND anome = '" & FichaOticaProduto.aNome & "'"
        'End If
        'If FichaOticaProdutoConsulta(FichaOticaProduto, consulta, MdlConexaoBD.conectionPadrao) Then
        '    MsgBox("O FichaOticaProduto """ & FichaOticaProduto.aNome & """ já existe em outro CADASTRO !") : Return False
        'End If

        Return True
    End Function

    Public Sub TrazListFichaOticaProduto_BD(ByRef FichaOticaProduto As List(Of ClFichaOticaProduto), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaProdutoDAO:TrazListFichaOticaProdutos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT fop_id, fop_ficha_id, fop_produto_id, fop_produto_nome, fop_produto_unidade, fop_quantidade, " '5
        consulta += "fop_preco_venda, fop_total, fop_cor, fop_referencia " '9
        consulta += "FROM ficha_otica_produto"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        FichaOticaProduto.Clear()
        While dr.Read

            FichaOticaProduto.Add(New ClFichaOticaProduto(dr(0), dr(1), dr(2), dr(3).ToString, dr(4).ToString, dr(5), _
                                            dr(6), dr(7), dr(8).ToString, dr(9).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazFichaOticaProduto(ByRef vFichaOticaProduto As ClFichaOticaProduto, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaProdutoDAO:TrazFichaOticaProduto"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT fop_id, fop_ficha_id, fop_produto_id, fop_produto_nome, fop_produto_unidade, fop_quantidade, " '5
        consulta += "fop_preco_venda, fop_total, fop_cor, fop_referencia " '9
        consulta += "FROM ficha_otica_produto WHERE fop_id = " & vFichaOticaProduto.fop_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vFichaOticaProduto

                .fop_id = dr(0)
                .fop_ficha_id = dr(1)
                .fop_produto_id = dr(2)
                .fop_produto_nome = dr(3).ToString
                .fop_produto_unidade = dr(4).ToString
                .fop_quantidade = dr(5)
                .fop_preco_venda = dr(6)
                .fop_total = dr(7)
                .fop_cor = dr(8).ToString
                .fop_referencia = dr(9).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFichaOticaProduto_IdFicha_BD(ByVal vFichaOtica As ClFichaOtica, ByRef vListaFichaProd As List(Of ClFichaOticaProduto), ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mFichaProduto As New ClFichaOticaProduto

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaProdutoDAO:TrazFichaOticaProduto"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT fop_id, fop_ficha_id, fop_produto_id, fop_produto_nome, fop_produto_unidade, fop_quantidade, " '5
        consulta += "fop_preco_venda, fop_total, fop_cor, fop_referencia " '9
        consulta += "FROM ficha_otica_produto WHERE fop_ficha_id = " & vFichaOtica.fo_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With mFichaProduto

                .fop_id = dr(0)
                .fop_ficha_id = dr(1)
                .fop_produto_id = dr(2)
                .fop_produto_nome = dr(3).ToString
                .fop_produto_unidade = dr(4).ToString
                .fop_quantidade = dr(5)
                .fop_preco_venda = dr(6)
                .fop_total = dr(7)
                .fop_cor = dr(8).ToString
                .fop_referencia = dr(9).ToString
            End With

            vListaFichaProd.Add(New ClFichaOticaProduto(mFichaProduto))

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFichaOticaProdutoIdDaListaMDL(ByRef vFichaOticaProduto As ClFichaOticaProduto) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ClFichaOticaProduto In MdlConexaoBD.ListaFichaOticaProduto

            If a.fop_id.Equals(vFichaOticaProduto.fop_id) Then

                vFichaOticaProduto.SetaValores(a)
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazFichaOticaProdutoIdFicha_LIST_MDL(ByVal vFichaOtica As ClFichaOtica, ByRef vListaFichaProduto As List(Of ClFichaOticaProduto)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mFichaProd As New ClFichaOticaProduto
        If vListaFichaProduto.Count > 0 Then vListaFichaProduto.Clear()
        For Each a As ClFichaOticaProduto In MdlConexaoBD.ListaFichaOticaProduto

            If a.fop_ficha_id.Equals(vFichaOtica.fo_id) Then

                mFichaProd.SetaValores(a)
                mDeuCerto = True

                vListaFichaProduto.Add(New ClFichaOticaProduto(mFichaProd))
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazFichaOticaProdutoIdFicha_LIST(ByVal vFichaOtica As ClFichaOtica, ByRef vNovaLista As List(Of ClFichaOticaProduto), ByVal ListaFichaOticaProdutos As List(Of ClFichaOticaProduto)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mFichaProd As New ClFichaOticaProduto
        For Each a As ClFichaOticaProduto In ListaFichaOticaProdutos

            If a.fop_ficha_id.Equals(vFichaOtica.fo_id) Then

                mFichaProd.SetaValores(a)
                mDeuCerto = True

                vNovaLista.Add(New ClFichaOticaProduto(mFichaProd))
            End If
        Next

        Return mDeuCerto
    End Function

    Public Sub delFichaOticaProduto(ByVal vFichaOticaProduto As ClFichaOticaProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM ficha_otica_produto WHERE fop_id = @fop_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fop_id", vFichaOticaProduto.fop_id)

        comm.ExecuteNonQuery()

        TrazListFichaOticaProduto_BD(MdlConexaoBD.ListaFichaOticaProduto, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delFichaOticaProduto_IdFicha(ByVal vFichaOtica As ClFichaOtica, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM ficha_otica_produto WHERE fop_ficha_id = @fop_ficha_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fop_ficha_id", vFichaOtica.fo_id)

        comm.ExecuteNonQuery()

        TrazListFichaOticaProduto_BD(MdlConexaoBD.ListaFichaOticaProduto, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function FichaOticaProdutoConsulta(ByRef FichaOticaProduto As ClFichaOticaProduto, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaProdutoDAO:FichaOticaProdutoConsulta"":: " & ex.Message)
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
