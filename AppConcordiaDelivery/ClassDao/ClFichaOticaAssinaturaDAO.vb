Imports Npgsql
Public Class ClFichaOticaAssinaturaDAO

    Public Sub incFichaOticaAssinatura(ByVal FichaOticaAssinatura As ClFichaOticaAssinatura, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO ficha_otica_assinatura(fa_id, fa_ficha_id, fa_numero, fa_vencimento, fa_valor, fa_texto1, fa_empresa_razao, "
        sql += "fa_empresa_cnpj_cpf, fa_valor_extenso, fa_moeda, fa_cliente_id, fa_cliente_nome, fa_cliente_cnpj_cpf, fa_data_emissao, "
        sql += "fa_cliente_endereco, fa_assinatura_cliente) "
        sql += "VALUES (DEFAULT, @fa_ficha_id, @fa_numero, @fa_vencimento, @fa_valor, @fa_texto1, @fa_empresa_razao, "
        sql += "@fa_empresa_cnpj_cpf, @fa_valor_extenso, @fa_moeda, @fa_cliente_id, @fa_cliente_nome, @fa_cliente_cnpj_cpf, @fa_data_emissao, "
        sql += "@fa_cliente_endereco, @fa_assinatura_cliente) "

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@fa_ficha_id", FichaOticaAssinatura.fa_ficha_id)
        comm.Parameters.Add("@fa_numero", FichaOticaAssinatura.fa_numero)
        comm.Parameters.Add("@fa_vencimento", FichaOticaAssinatura.fa_vencimento)
        comm.Parameters.Add("@fa_valor", FichaOticaAssinatura.fa_valor)
        comm.Parameters.Add("@fa_texto1", FichaOticaAssinatura.fa_texto1)
        comm.Parameters.Add("@fa_empresa_razao", FichaOticaAssinatura.fa_empresa_razao)
        comm.Parameters.Add("@fa_empresa_cnpj_cpf", FichaOticaAssinatura.fa_empresa_cnpj_cpf)
        comm.Parameters.Add("@fa_valor_extenso", FichaOticaAssinatura.fa_valor_extenso)
        comm.Parameters.Add("@fa_moeda", FichaOticaAssinatura.fa_moeda)
        comm.Parameters.Add("@fa_cliente_id", FichaOticaAssinatura.fa_cliente_id)
        comm.Parameters.Add("@fa_cliente_nome", FichaOticaAssinatura.fa_cliente_nome)
        comm.Parameters.Add("@fa_cliente_cnpj_cpf", FichaOticaAssinatura.fa_cliente_cnpj_cpf)
        comm.Parameters.Add("@fa_data_emissao", FichaOticaAssinatura.fa_data_emissao)
        comm.Parameters.Add("@fa_cliente_endereco", FichaOticaAssinatura.fa_cliente_endereco)
        comm.Parameters.Add("@fa_assinatura_cliente", FichaOticaAssinatura.fa_assinatura_cliente)

        comm.ExecuteNonQuery()

        TrazListFichaOticaAssinatura_BD(MdlConexaoBD.ListaFichaOticaAssinatura, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altFichaOticaAssinatura(ByVal FichaOticaAssinatura As ClFichaOticaAssinatura, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE ficha_otica_assinatura SET fa_ficha_id = @fa_ficha_id, fa_numero = @fa_numero, fa_vencimento = @fa_vencimento, "
        sql += "fa_valor = @fa_valor, fa_texto1 = @fa_texto1, fa_empresa_razao = @fa_empresa_razao,  "
        sql += "fa_empresa_cnpj_cpf = @fa_empresa_cnpj_cpf, fa_valor_extenso = @fa_valor_extenso, fa_moeda = @fa_moeda, "
        sql += "fa_cliente_id = @fa_cliente_id, fa_cliente_nome = @fa_cliente_nome, fa_cliente_cnpj_cpf = @fa_cliente_cnpj_cpf, "
        sql += "fa_data_emissao = @fa_data_emissao, fa_cliente_endereco = @fa_cliente_endereco, fa_assinatura_cliente = @fa_assinatura_cliente "
        sql += "WHERE fa_id = @fa_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)

        ' Prepara Paramentros
        comm.Parameters.Add("@fa_id", FichaOticaAssinatura.fa_id)
        comm.Parameters.Add("@fa_ficha_id", FichaOticaAssinatura.fa_ficha_id)
        comm.Parameters.Add("@fa_numero", FichaOticaAssinatura.fa_numero)
        comm.Parameters.Add("@fa_vencimento", FichaOticaAssinatura.fa_vencimento)
        comm.Parameters.Add("@fa_valor", FichaOticaAssinatura.fa_valor)
        comm.Parameters.Add("@fa_texto1", FichaOticaAssinatura.fa_texto1)
        comm.Parameters.Add("@fa_empresa_razao", FichaOticaAssinatura.fa_empresa_razao)
        comm.Parameters.Add("@fa_empresa_cnpj_cpf", FichaOticaAssinatura.fa_empresa_cnpj_cpf)
        comm.Parameters.Add("@fa_valor_extenso", FichaOticaAssinatura.fa_valor_extenso)
        comm.Parameters.Add("@fa_moeda", FichaOticaAssinatura.fa_moeda)
        comm.Parameters.Add("@fa_cliente_id", FichaOticaAssinatura.fa_cliente_id)
        comm.Parameters.Add("@fa_cliente_nome", FichaOticaAssinatura.fa_cliente_nome)
        comm.Parameters.Add("@fa_cliente_cnpj_cpf", FichaOticaAssinatura.fa_cliente_cnpj_cpf)
        comm.Parameters.Add("@fa_data_emissao", FichaOticaAssinatura.fa_data_emissao)
        comm.Parameters.Add("@fa_cliente_endereco", FichaOticaAssinatura.fa_cliente_endereco)
        comm.Parameters.Add("@fa_assinatura_cliente", FichaOticaAssinatura.fa_assinatura_cliente)
        comm.ExecuteNonQuery()

        TrazListFichaOticaAssinatura_BD(MdlConexaoBD.ListaFichaOticaAssinatura, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaFichaOticaAssinatura(ByVal FichaOticaAssinatura As ClFichaOticaAssinatura, Optional ByVal Operacao As String = "I") As Boolean

        'If Trim(FichaOticaAssinatura.aNome).Equals("") Then MsgBox("Informe um NOME para o FichaOticaAssinatura!") : Return False

        'Dim consulta As String = ""
        'If Operacao.Equals("I") Then
        '    consulta = "SELECT anome FROM FichaOticaAssinatura WHERE anome = '" & FichaOticaAssinatura.aNome & "'"
        'Else
        '    consulta = "SELECT anome FROM FichaOticaAssinatura WHERE aid <> " & FichaOticaAssinatura.aId & " AND anome = '" & FichaOticaAssinatura.aNome & "'"
        'End If
        'If FichaOticaAssinaturaConsulta(FichaOticaAssinatura, consulta, MdlConexaoBD.conectionPadrao) Then
        '    MsgBox("O FichaOticaAssinatura """ & FichaOticaAssinatura.aNome & """ já existe em outro CADASTRO !") : Return False
        'End If

        Return True
    End Function

    Public Sub TrazListFichaOticaAssinatura_BD(ByRef FichaOticaAssinatura As List(Of ClFichaOticaAssinatura), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaAssinaturaDAO:TrazListFichaOticaAssinaturas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT fa_id, fa_ficha_id, fa_numero, fa_vencimento, fa_valor, fa_texto1, fa_empresa_razao, fa_empresa_cnpj_cpf, " '7
        consulta += "fa_valor_extenso, fa_moeda, fa_cliente_id, fa_cliente_nome, fa_cliente_cnpj_cpf, fa_data_emissao, " '13
        consulta += "fa_cliente_endereco, fa_assinatura_cliente " '15
        consulta += "FROM ficha_otica_assinatura"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        FichaOticaAssinatura.Clear()
        While dr.Read

            FichaOticaAssinatura.Add(New ClFichaOticaAssinatura(dr(0), dr(1), dr(2).ToString, dr(3).ToString, dr(4), dr(5).ToString, _
                                                                dr(6).ToString, dr(7).ToString, dr(8).ToString, dr(9).ToString, _
                                                                dr(10), dr(11).ToString, dr(12).ToString, dr(13).ToString, _
                                                                dr(14).ToString, dr(15).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazFichaOticaAssinatura(ByRef vFichaOticaAssinatura As ClFichaOticaAssinatura, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaAssinaturaDAO:TrazFichaOticaAssinatura"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT fa_id, fa_ficha_id, fa_numero, fa_vencimento, fa_valor, fa_texto1, fa_empresa_razao, fa_empresa_cnpj_cpf, " '7
        consulta += "fa_valor_extenso, fa_moeda, fa_cliente_id, fa_cliente_nome, fa_cliente_cnpj_cpf, fa_data_emissao, " '13
        consulta += "fa_cliente_endereco, fa_assinatura_cliente " '15
        consulta += "FROM ficha_otica_assinatura WHERE fa_id = " & vFichaOticaAssinatura.fa_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vFichaOticaAssinatura

                .fa_id = dr(0)
                .fa_ficha_id = dr(1)
                .fa_numero = dr(2)
                .fa_vencimento = dr(3).ToString
                .fa_valor = dr(4)
                .fa_texto1 = dr(5).ToString
                .fa_empresa_razao = dr(6).ToString
                .fa_empresa_cnpj_cpf = dr(7).ToString
                .fa_valor_extenso = dr(8).ToString
                .fa_moeda = dr(9).ToString
                .fa_cliente_id = dr(10).ToString
                .fa_cliente_nome = dr(11).ToString
                .fa_cliente_cnpj_cpf = dr(12).ToString
                .fa_data_emissao = dr(13).ToString
                .fa_cliente_endereco = dr(14).ToString
                .fa_assinatura_cliente = dr(15).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFichaOticaAssinatura_IdFicha_BD(ByVal vFichaOtica As ClFichaOtica, ByRef vFichaAssinatura As ClFichaOticaAssinatura, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaAssinaturaDAO:TrazFichaOticaAssinatura"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT fa_id, fa_ficha_id, fa_numero, fa_vencimento, fa_valor, fa_texto1, fa_empresa_razao, fa_empresa_cnpj_cpf, " '7
        consulta += "fa_valor_extenso, fa_moeda, fa_cliente_id, fa_cliente_nome, fa_cliente_cnpj_cpf, fa_data_emissao, " '13
        consulta += "fa_cliente_endereco, fa_assinatura_cliente " '15
        consulta += "FROM ficha_otica_assinatura WHERE fa_ficha_id = " & vFichaOtica.fo_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            With vFichaAssinatura

                .fa_id = dr(0)
                .fa_ficha_id = dr(1)
                .fa_numero = dr(2)
                .fa_vencimento = dr(3).ToString
                .fa_valor = dr(4)
                .fa_texto1 = dr(5).ToString
                .fa_empresa_razao = dr(6).ToString
                .fa_empresa_cnpj_cpf = dr(7).ToString
                .fa_valor_extenso = dr(8).ToString
                .fa_moeda = dr(9).ToString
                .fa_cliente_id = dr(10).ToString
                .fa_cliente_nome = dr(11).ToString
                .fa_cliente_cnpj_cpf = dr(12).ToString
                .fa_data_emissao = dr(13).ToString
                .fa_cliente_endereco = dr(14).ToString
                .fa_assinatura_cliente = dr(15).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFichaOticaAssinaturaIdDaListaMDL(ByRef vFichaOticaAssinatura As ClFichaOticaAssinatura) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ClFichaOticaAssinatura In MdlConexaoBD.ListaFichaOticaAssinatura

            If a.fa_id.Equals(vFichaOticaAssinatura.fa_id) Then

                vFichaOticaAssinatura.SetaValores(a)
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazFichaOticaAssinaturaIdFicha_LIST_MDL(ByVal vFichaOtica As ClFichaOtica, ByRef vListaFichaProduto As List(Of ClFichaOticaAssinatura)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mNovoObjeto As New ClFichaOticaAssinatura

        If vListaFichaProduto.Count > 0 Then vListaFichaProduto.Clear()
        For Each a As ClFichaOticaAssinatura In MdlConexaoBD.ListaFichaOticaAssinatura

            If a.fa_ficha_id.Equals(vFichaOtica.fo_id) Then

                mNovoObjeto.SetaValores(a)
                mDeuCerto = True

                vListaFichaProduto.Add(New ClFichaOticaAssinatura(mNovoObjeto))
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazFichaOticaAssinaturaIdFicha_LIST(ByVal vFichaOtica As ClFichaOtica, ByRef vNovaLista As List(Of ClFichaOticaAssinatura), ByVal vListaFichaOticaAssinaturas As List(Of ClFichaOticaAssinatura)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mFichaAssinatura As New ClFichaOticaAssinatura
        If vListaFichaOticaAssinaturas.Count < 1 Then Return False

        For Each a As ClFichaOticaAssinatura In vListaFichaOticaAssinaturas

            If a.fa_ficha_id.Equals(vFichaOtica.fo_id) Then

                mFichaAssinatura.SetaValores(a)
                mDeuCerto = True

                vNovaLista.Add(New ClFichaOticaAssinatura(mFichaAssinatura))
            End If
        Next

        Return mDeuCerto
    End Function

    Public Sub delFichaOticaAssinatura(ByVal vFichaOticaAssinatura As ClFichaOticaAssinatura, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM ficha_otica_assinatura WHERE fa_id = @fa_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fa_id", vFichaOticaAssinatura.fa_id)

        comm.ExecuteNonQuery()

        TrazListFichaOticaAssinatura_BD(MdlConexaoBD.ListaFichaOticaAssinatura, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delFichaOticaAssinatura_IdFicha(ByVal vFichaOtica As ClFichaOtica, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM ficha_otica_assinatura WHERE fa_ficha_id = @fa_ficha_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fa_ficha_id", vFichaOtica.fo_id)


        comm.ExecuteNonQuery()

        TrazListFichaOticaAssinatura_BD(MdlConexaoBD.ListaFichaOticaAssinatura, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function FichaOticaAssinaturaConsulta(ByRef FichaOticaAssinatura As ClFichaOticaAssinatura, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FichaOticaAssinaturaDAO:FichaOticaAssinaturaConsulta"":: " & ex.Message)
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
