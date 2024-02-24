Imports Npgsql
Public Class ClFichaOticaDAO

    Public Sub incFichaOtica(ByVal FichaOtica As ClFichaOtica, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO ficha_otica(fo_id, fo_coordenador, fo_num_contrato, fo_localidade, fo_data_cadastro, fo_data_ficha, "
        sql += "fo_data_alteracao, fo_cliente_id, fo_cliente_nome, fo_cliente_fone, fo_observacoes_gerais, fo_datas_retorno, fo_observacoes, "
        sql += "fo_assinatura_vendedor, fo_soma, fo_entrada, fo_saldo, fo_prestacoes, fo_data_entrega, fo_data_entrada, fo_data_prestacoes) "
        sql += "VALUES (DEFAULT, @fo_coordenador, @fo_num_contrato, @fo_localidade, DEFAULT, @fo_data_ficha, @fo_data_alteracao, "
        sql += "@fo_cliente_id, @fo_cliente_nome, @fo_cliente_fone, @fo_observacoes_gerais, @fo_datas_retorno, @fo_observacoes, "
        sql += "@fo_assinatura_vendedor, @fo_soma, @fo_entrada, @fo_saldo, @fo_prestacoes, @fo_data_entrega, @fo_data_entrada, @fo_data_prestacoes) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fo_coordenador", FichaOtica.fo_coordenador)
        comm.Parameters.Add("@fo_num_contrato", FichaOtica.fo_num_contrato)
        comm.Parameters.Add("@fo_localidade", FichaOtica.fo_localidade)
        comm.Parameters.Add("@fo_data_ficha", FichaOtica.fo_data_ficha)
        comm.Parameters.Add("@fo_data_alteracao", "")
        comm.Parameters.Add("@fo_cliente_id", FichaOtica.fo_cliente_id)
        comm.Parameters.Add("@fo_cliente_nome", FichaOtica.fo_cliente_nome)
        comm.Parameters.Add("@fo_cliente_fone", FichaOtica.fo_cliente_fone)
        comm.Parameters.Add("@fo_observacoes_gerais", FichaOtica.fo_observacoes_gerais)
        comm.Parameters.Add("@fo_datas_retorno", FichaOtica.fo_datas_retorno)
        comm.Parameters.Add("@fo_observacoes", FichaOtica.fo_observacoes)
        comm.Parameters.Add("@fo_assinatura_vendedor", FichaOtica.fo_assinatura_vendedor)
        comm.Parameters.Add("@fo_soma", FichaOtica.fo_soma)
        comm.Parameters.Add("@fo_entrada", FichaOtica.fo_entrada)
        comm.Parameters.Add("@fo_saldo", FichaOtica.fo_saldo)
        comm.Parameters.Add("@fo_prestacoes", FichaOtica.fo_prestacoes)
        comm.Parameters.Add("@fo_data_entrega", FichaOtica.fo_data_entrega)
        comm.Parameters.Add("@fo_data_entrada", FichaOtica.fo_data_entrada)
        comm.Parameters.Add("@fo_data_prestacoes", FichaOtica.fo_data_prestacoes)

        comm.ExecuteNonQuery()

        TrazListFichaOtica_BD(MdlConexaoBD.ListaFichaOtica, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altFichaOtica(ByVal FichaOtica As ClFichaOtica, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE ficha_otica SET fo_coordenador = @fo_coordenador, fo_num_contrato = @fo_num_contrato, fo_localidade = @fo_localidade, "
        sql += "fo_data_ficha = @fo_data_ficha, fo_data_alteracao = @fo_data_alteracao, fo_cliente_id = @fo_cliente_id, "
        sql += "fo_cliente_nome = @fo_cliente_nome, fo_cliente_fone = @fo_cliente_fone, fo_observacoes_gerais = @fo_observacoes_gerais, "
        sql += "fo_datas_retorno = @fo_datas_retorno, fo_observacoes = @fo_observacoes, fo_assinatura_vendedor = @fo_assinatura_vendedor, "
        sql += "fo_soma = @fo_soma, fo_entrada = @fo_entrada, fo_saldo = @fo_saldo, fo_prestacoes = @fo_prestacoes, "
        sql += "fo_data_entrega = @fo_data_entrega, fo_data_entrada = @fo_data_entrada, fo_data_prestacoes = @fo_data_prestacoes "
        sql += "WHERE fo_id = @fo_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fo_id", FichaOtica.fo_id)
        comm.Parameters.Add("@fo_coordenador", FichaOtica.fo_coordenador)
        comm.Parameters.Add("@fo_num_contrato", FichaOtica.fo_num_contrato)
        comm.Parameters.Add("@fo_localidade", FichaOtica.fo_localidade)
        comm.Parameters.Add("@fo_data_ficha", FichaOtica.fo_data_ficha)
        comm.Parameters.Add("@fo_data_alteracao", Date.Now.ToShortDateString & " " & Date.Now.ToShortTimeString)
        comm.Parameters.Add("@fo_cliente_id", FichaOtica.fo_cliente_id)
        comm.Parameters.Add("@fo_cliente_nome", FichaOtica.fo_cliente_nome)
        comm.Parameters.Add("@fo_cliente_fone", FichaOtica.fo_cliente_fone)
        comm.Parameters.Add("@fo_observacoes_gerais", FichaOtica.fo_observacoes_gerais)
        comm.Parameters.Add("@fo_datas_retorno", FichaOtica.fo_datas_retorno)
        comm.Parameters.Add("@fo_observacoes", FichaOtica.fo_observacoes)
        comm.Parameters.Add("@fo_assinatura_vendedor", FichaOtica.fo_assinatura_vendedor)
        comm.Parameters.Add("@fo_soma", FichaOtica.fo_soma)
        comm.Parameters.Add("@fo_entrada", FichaOtica.fo_entrada)
        comm.Parameters.Add("@fo_saldo", FichaOtica.fo_saldo)
        comm.Parameters.Add("@fo_prestacoes", FichaOtica.fo_prestacoes)
        comm.Parameters.Add("@fo_data_entrega", FichaOtica.fo_data_entrega)
        comm.Parameters.Add("@fo_data_entrada", FichaOtica.fo_data_entrada)
        comm.Parameters.Add("@fo_data_prestacoes", FichaOtica.fo_data_prestacoes)
        comm.ExecuteNonQuery()

        TrazListFichaOtica_BD(MdlConexaoBD.ListaFichaOtica, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaFichaOtica(ByVal FichaOtica As ClFichaOtica, Optional ByVal Operacao As String = "I") As Boolean

        'If Trim(FichaOtica.aNome).Equals("") Then MsgBox("Informe um NOME para o FichaOtica!") : Return False

        'Dim consulta As String = ""
        'If Operacao.Equals("I") Then
        '    consulta = "SELECT anome FROM FichaOtica WHERE anome = '" & FichaOtica.aNome & "'"
        'Else
        '    consulta = "SELECT anome FROM FichaOtica WHERE aid <> " & FichaOtica.aId & " AND anome = '" & FichaOtica.aNome & "'"
        'End If
        'If FichaOticaConsulta(FichaOtica, consulta, MdlConexaoBD.conectionPadrao) Then
        '    MsgBox("O FichaOtica """ & FichaOtica.aNome & """ já existe em outro CADASTRO !") : Return False
        'End If

        Return True
    End Function

    Public Function TrazIdUltimaFicha_Incluida(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Int64


        Dim dr As NpgsqlDataReader
        Dim com As New NpgsqlCommand
        Dim consulta As String = ""
        Dim mId As Integer = 0

        Try
            consulta = "SELECT MAX(fo_id) FROM ficha_otica"
            com.Transaction = transacao
            com = New NpgsqlCommand(consulta, conexao)
            dr = com.ExecuteReader

            While dr.Read
                mId = dr(0)
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO ao Trazer ID da Última Ficha Incluida - DAO:: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            com = Nothing : dr = Nothing : consulta = Nothing
        End Try


        Return mId
    End Function

    Public Sub TrazListFichaOtica_BD(ByRef FichaOtica As List(Of ClFichaOtica), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaDAO:TrazListFichaOticas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT fo_id, fo_coordenador, fo_num_contrato, fo_localidade, fo_data_cadastro, fo_data_ficha, fo_data_alteracao, " '6
        consulta += "fo_cliente_id, fo_cliente_nome, fo_cliente_fone, fo_observacoes_gerais, fo_datas_retorno, fo_observacoes, " '12
        consulta += "fo_assinatura_vendedor, fo_soma, fo_entrada, fo_saldo, fo_prestacoes, fo_data_entrega, fo_data_entrada, fo_data_prestacoes " '20
        consulta += "FROM ficha_otica"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        FichaOtica.Clear()
        While dr.Read

            FichaOtica.Add(New ClFichaOtica(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4), dr(5), _
                                            dr(6).ToString, dr(7), dr(8).ToString, dr(9).ToString, dr(10).ToString, dr(11).ToString, _
                                            dr(12).ToString, dr(13).ToString, dr(14), dr(15), dr(16), dr(17), _
                                            dr(18).ToString, dr(19).ToString, dr(20).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListFichaOtica_Query_BD(ByRef FichaOtica As List(Of ClFichaOtica), ByVal vConsulta As String, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaDAO:TrazListFichaOticas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT fo_id, fo_coordenador, fo_num_contrato, fo_localidade, fo_data_cadastro, fo_data_ficha, fo_data_alteracao, " '6
        consulta += "fo_cliente_id, fo_cliente_nome, fo_cliente_fone, fo_observacoes_gerais, fo_datas_retorno, fo_observacoes, " '12
        consulta += "fo_assinatura_vendedor, fo_soma, fo_entrada, fo_saldo, fo_prestacoes, fo_data_entrega, fo_data_entrada, fo_data_prestacoes " '20
        consulta += "FROM ficha_otica "
        consulta += vConsulta

        com = New NpgsqlCommand(vConsulta, conexao)
        dr = com.ExecuteReader

        FichaOtica.Clear()
        While dr.Read

            FichaOtica.Add(New ClFichaOtica(dr(0), dr(1).ToString, dr(2).ToString, dr(3), dr(4), dr(5), _
                                            dr(6).ToString, dr(7), dr(8).ToString, dr(9).ToString, dr(10).ToString, dr(11).ToString, _
                                            dr(12).ToString, dr(13).ToString, dr(14), dr(15), dr(16), dr(17), _
                                            dr(18).ToString, dr(19).ToString, dr(20).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazFichaOtica(ByRef vFichaOtica As ClFichaOtica, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaDAO:TrazFichaOtica"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT fo_id, fo_coordenador, fo_num_contrato, fo_localidade, fo_data_cadastro, fo_data_ficha, fo_data_alteracao, " '6
        consulta += "fo_cliente_id, fo_cliente_nome, fo_cliente_fone, fo_observacoes_gerais, fo_datas_retorno, fo_observacoes, " '12
        consulta += "fo_assinatura_vendedor, fo_soma, fo_entrada, fo_saldo, fo_prestacoes, fo_data_entrega, fo_data_entrada, fo_data_prestacoes " '20
        consulta += "FROM ficha_otica WHERE fo_id = " & vFichaOtica.fo_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vFichaOtica

                .fo_id = dr(0)
                .fo_coordenador = dr(1).ToString
                .fo_num_contrato = dr(2).ToString
                .fo_localidade = dr(3).ToString
                .fo_data_cadastro = dr(4)
                .fo_data_ficha = dr(5)
                .fo_data_alteracao = dr(6).ToString
                .fo_cliente_id = dr(7)
                .fo_cliente_nome = dr(8).ToString
                .fo_cliente_fone = dr(9).ToString
                .fo_observacoes_gerais = dr(10).ToString
                .fo_datas_retorno = dr(11).ToString
                .fo_observacoes = dr(12).ToString
                .fo_assinatura_vendedor = dr(13).ToString
                .fo_soma = dr(14)
                .fo_entrada = dr(15)
                .fo_saldo = dr(16)
                .fo_prestacoes = dr(17)
                .fo_data_entrega = dr(18).ToString
                .fo_data_entrada = dr(19).ToString
                .fo_data_prestacoes = dr(20).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFichaOticaIdDaListaMDL(ByRef vFichaOtica As ClFichaOtica) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ClFichaOtica In MdlConexaoBD.ListaFichaOtica

            If a.fo_id.Equals(vFichaOtica.fo_id) Then

                vFichaOtica.SetaFichaOtica(a)
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazFichaOticaIdLista(ByRef vFichaOtica As ClFichaOtica, ByVal ListaFichaOticas As List(Of ClFichaOtica)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ClFichaOtica In ListaFichaOticas

            If a.fo_id.Equals(vFichaOtica.fo_id) Then

                vFichaOtica.SetaFichaOtica(a)
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazListaFichaOtica_LIST(ByVal ListaFichaOticas As List(Of ClFichaOtica)) As List(Of ClFichaOtica)

        Dim mDeuCerto As Boolean = False
        Dim vNovaLista As New List(Of ClFichaOtica)

        For Each a As ClFichaOtica In ListaFichaOticas

            vNovaLista.Add(New ClFichaOtica(a))
        Next

        Return vNovaLista
    End Function

    Public Sub delFichaOtica(ByVal vFichaOtica As ClFichaOtica, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""
        'tabelas referenciadas:
        Dim fProdutoDAO As New ClFichaOticaProdutoDAO
        Dim fOlhoDAO As New ClFichaOticaOlhoDAO
        Dim fPrestacoesDAO As New ClFichaOticaPrestacoesDAO
        Dim fAssinaturaDAO As New ClFichaOticaAssinaturaDAO

        'Falta deletar das outras tabelas relacionadas primeiro!
        fAssinaturaDAO.delFichaOticaAssinatura_IdFicha(vFichaOtica, conexao, transacao)
        fPrestacoesDAO.delFichaOticaPrestacoes_IdFicha(vFichaOtica, conexao, transacao)
        fOlhoDAO.delFichaOticaOlho_IdFicha(vFichaOtica, conexao, transacao)
        fProdutoDAO.delFichaOticaProduto_IdFicha(vFichaOtica, conexao, transacao)


        sql = "DELETE FROM ficha_otica WHERE fo_id = @fo_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fo_id", vFichaOtica.fo_id)

        comm.ExecuteNonQuery()

        TrazListFichaOtica_BD(MdlConexaoBD.ListaFichaOtica, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function FichaOticaConsulta(ByRef FichaOtica As ClFichaOtica, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaDAO:FichaOticaConsulta"":: " & ex.Message)
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


    'CONTAS A RECEBER: ***********
    Sub LancaFichaContasAReceber(ByVal vFicha As ClFichaOtica, ByVal vListaPrestacoes As List(Of ClFichaOticaPrestacoes), ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)


        Dim vContaAReceber As New ClAReceberTotal
        Dim vContaAReceberDAO As New ClAReceberTotalDAO
        vContaAReceber.ZeraValores()


        For Each pres As ClFichaOticaPrestacoes In vListaPrestacoes

            With vContaAReceber

                .art_tela = "F_OTICA"
                .art_clienteid = vFicha.fo_cliente_id
                .art_clientenome = vFicha.fo_cliente_nome
                .art_empresaid = MdlConexaoBD.mdlEmpresa.empid
                .art_empresanome = MdlConexaoBD.mdlEmpresa.emprazaosocial
                .art_dataemissao = Date.Now
                .art_datavencimento = pres.fpp_data
                .art_valor = pres.fpp_valor
                .art_valorrestante = 0
                .art_observacao = "LANÇAMENTO AUTOMATICO NA TELA FICHA OTICA"
                .art_idficha_otica = vFicha.fo_id
                .art_parcela = CInt(pres.fpp_prestacao)

            End With

            vContaAReceberDAO.incAReceberTotal(vContaAReceber, conexao, transacao)

        Next

    End Sub

    Sub DeletaFichaContasARECEBER(ByVal vFicha As ClFichaOtica, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        'sql = "DELETE FROM ficha_otica WHERE fo_id = @fo_id"
        'comm.Transaction = transacao
        'comm = New NpgsqlCommand(sql, conexao)
        '' Prepara Paramentros
        'comm.Parameters.Add("@fo_id", vFicha.fo_id)

        'comm.ExecuteNonQuery()

        TrazListFichaOtica_BD(MdlConexaoBD.ListaFichaOtica, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

End Class
