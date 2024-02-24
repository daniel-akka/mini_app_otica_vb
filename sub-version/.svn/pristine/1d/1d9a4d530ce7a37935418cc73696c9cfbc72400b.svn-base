Imports Npgsql
Public Class ClClienteDAO

    Dim _funcoes As New ClFuncoes

    Public Sub incCliente(ByVal Cliente As ClCliente, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO cliente(cid, cnome, cestado, ccidade, cendereco, creferencia, cdatanascimento, ctelefone, cbairro, cdiames, ccpf, "
        sql += "ccep, cemail, tipo, observacao, ufid, cidadeid, cidadecodigo, crg, capelido, cpai, cmae, cof, clocaltrabalho, "
        sql += "cfuncaotrabalho, cnomeconjugue, capelidoconjugue)"
        sql += "VALUES (DEFAULT, @cnome, @cestado, @ccidade, @cendereco, @creferencia, @cdatanascimento, @ctelefone, @cbairro, @cdiames, "
        sql += "@ccpf, @ccep, @cemail, @tipo, @observacao, @ufid, @cidadeid, @cidadecodigo, @crg, @capelido, @cpai, @cmae, "
        sql += "@cof, @clocaltrabalho, @cfuncaotrabalho, @cnomeconjugue, @capelidoconjugue)"
        
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cnome", Cliente.cnome)
        comm.Parameters.Add("@cestado", Cliente.cestado)
        comm.Parameters.Add("@ccidade", Cliente.ccidade)
        comm.Parameters.Add("@cendereco", Cliente.cendereco)
        comm.Parameters.Add("@creferencia", Cliente.creferencia)
        comm.Parameters.Add("@ctelefone", Cliente.ctelefone)
        comm.Parameters.Add("@cbairro", Cliente.cbairro)
        comm.Parameters.Add("@cdiames", Cliente.cdiames)
        comm.Parameters.Add("@ccpf", Cliente.cCpfCnpj)
        comm.Parameters.Add("@ccep", Cliente.ccep)
        comm.Parameters.Add("@cemail", Cliente.cemail)
        comm.Parameters.Add("@tipo", Cliente.tipo)
        comm.Parameters.Add("@observacao", Cliente.observacao)
        comm.Parameters.Add("@ufid", Cliente.ufid)
        comm.Parameters.Add("@cidadeid", Cliente.cidadeid)
        comm.Parameters.Add("@cidadecodigo", Cliente.cidadecodigo)

        If Not IsDate(Cliente.cdatanascimento) Then
            comm.Parameters.Add("@cdatanascimento", DBNull.Value)
        Else
            comm.Parameters.Add("@cdatanascimento", CDate(Cliente.cdatanascimento))
        End If

        'Novas Propriedades para Ótica:
        comm.Parameters.Add("@crg", Cliente.cliRG)
        comm.Parameters.Add("@capelido", Cliente.cliApelido)
        comm.Parameters.Add("@cpai", Cliente.cliPai)
        comm.Parameters.Add("@cmae", Cliente.cliMae)
        comm.Parameters.Add("@cof", Cliente.cliOF)
        comm.Parameters.Add("@clocaltrabalho", Cliente.cliLocalTrabalho)
        comm.Parameters.Add("@cfuncaotrabalho", Cliente.cliFuncaoTrabalho)
        comm.Parameters.Add("@cnomeconjugue", Cliente.cliNomeConjugue)
        comm.Parameters.Add("@capelidoconjugue", Cliente.cliApelidoConjugue)


        comm.ExecuteNonQuery()

        TrazListClientes_BD(MdlConexaoBD.ListaClientes, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altCliente(ByVal Cliente As ClCliente, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE cliente SET cnome = @cnome, cestado = @cestado, ccidade = @ccidade, cendereco = @cendereco, tipo = @tipo, ufid = @ufid, "
        sql += "creferencia = @creferencia, cinativo = @cinativo, cdatanascimento = @cdatanascimento, ccpf = @ccpf, observacao = @observacao, "
        sql += "ctelefone = @ctelefone, cbairro = @cbairro, cdiames = @cdiames, ccep = @ccep, cemail = @cemail, cidadeid = @cidadeid, "
        sql += "cidadecodigo = @cidadecodigo, crg = @crg, capelido = @capelido, cpai = @cpai, cmae = @cmae, cof = @cof, "
        sql += "clocaltrabalho = @clocaltrabalho, cfuncaotrabalho = @cfuncaotrabalho, cnomeconjugue = @cnomeconjugue, "
        sql += "capelidoconjugue = @capelidoconjugue WHERE cid = @cid"


        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cid", Cliente.cid)
        comm.Parameters.Add("@cnome", Cliente.cnome)
        comm.Parameters.Add("@cestado", Cliente.cestado)
        comm.Parameters.Add("@ccidade", Cliente.ccidade)
        comm.Parameters.Add("@cendereco", Cliente.cendereco)
        comm.Parameters.Add("@creferencia", Cliente.creferencia)
        comm.Parameters.Add("@cinativo", Cliente.cinativo)
        comm.Parameters.Add("@ctelefone", Cliente.ctelefone)
        comm.Parameters.Add("@cbairro", Cliente.cbairro)
        comm.Parameters.Add("@cdiames", Cliente.cdiames)
        comm.Parameters.Add("@ccpf", Cliente.cCpfCnpj)
        comm.Parameters.Add("@ccep", Cliente.ccep)
        comm.Parameters.Add("@cemail", Cliente.cemail)
        comm.Parameters.Add("@tipo", Cliente.tipo)
        comm.Parameters.Add("@observacao", Cliente.observacao)
        comm.Parameters.Add("@ufid", Cliente.ufid)
        comm.Parameters.Add("@cidadeid", Cliente.cidadeid)
        comm.Parameters.Add("@cidadecodigo", Cliente.cidadecodigo)
        If Not IsDate(Cliente.cdatanascimento) Then
            comm.Parameters.Add("@cdatanascimento", DBNull.Value)
        Else
            comm.Parameters.Add("@cdatanascimento", CDate(Cliente.cdatanascimento))
        End If

        'Novas Propriedades para Ótica:
        comm.Parameters.Add("@crg", Cliente.cliRG)
        comm.Parameters.Add("@capelido", Cliente.cliApelido)
        comm.Parameters.Add("@cpai", Cliente.cliPai)
        comm.Parameters.Add("@cmae", Cliente.cliMae)
        comm.Parameters.Add("@cof", Cliente.cliOF)
        comm.Parameters.Add("@clocaltrabalho", Cliente.cliLocalTrabalho)
        comm.Parameters.Add("@cfuncaotrabalho", Cliente.cliFuncaoTrabalho)
        comm.Parameters.Add("@cnomeconjugue", Cliente.cliNomeConjugue)
        comm.Parameters.Add("@capelidoconjugue", Cliente.cliApelidoConjugue)


        comm.ExecuteNonQuery()

        TrazListClientes_BD(MdlConexaoBD.ListaClientes, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaCliente(ByVal Cliente As ClCliente, Optional ByVal Operacao As String = "I") As Boolean
        Dim consulta As String = ""
        Dim msg As String = ""

        If Trim(Cliente.cnome).Equals("") Then
            MsgBox("Nome do Cliente não pode ser em Branco", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        'Valida se já existe um cliente com o mesmo nome
        If Operacao.Equals("I") Then
            consulta = "SELECT cid FROM cliente WHERE cnome LIKE '" & Cliente.cnome & "'"
        Else
            consulta = "SELECT cid FROM cliente WHERE cid <> " & Cliente.cid & " AND cnome LIKE '" & Cliente.cnome & "'"
        End If

        If ClienteConsulta(Cliente, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("Já existe em outro cliente com o Nome: """ & Cliente.cnome & """", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        'Valida se já existe um cliente com o mesmo CPF
        If Operacao.Equals("I") Then
            consulta = "SELECT cid FROM cliente WHERE LENGTH(ccpf) > 0 AND ccpf LIKE '" & Cliente.cCpfCnpj & "'"
        Else
            consulta = "SELECT cid FROM cliente WHERE cid <> " & Cliente.cid & " AND LENGTH(ccpf) > 0 AND ccpf LIKE '" & Cliente.cCpfCnpj & "'"
        End If

        If ClienteConsulta(Cliente, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("Já existe em outro cliente com o CPF: """ & Cliente.cCpfCnpj & """", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        'Valida se já existe um cliente INATIVO com o mesmo nome
        If Operacao.Equals("I") Then
            consulta = "SELECT cid FROM cliente WHERE cinativo = true AND cnome LIKE '" & Cliente.cnome & "'"
        Else
            consulta = "SELECT cid FROM cliente WHERE cinativo = true AND cid <> " & Cliente.cid & " AND cnome LIKE '" & Cliente.cnome & "'"
        End If
        If ClienteConsulta(Cliente, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("Já existe um cliente INATIVO com o Nome: """ & Cliente.cnome & """", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        msg = _funcoes.ValidaDiaMesSTR(Cliente.cdiames)
        If Not msg.Equals("") Then
            MsgBox(msg, MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        If (Cliente.ccep.Length > 0) AndAlso _funcoes.validaCEP(Cliente.ccep) = False Then
            MsgBox("CEP do Cliente invalido!", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        Dim mStr As String = _funcoes.RemoverCaracter2(Cliente.cCpfCnpj)
        If Cliente.tipo.Equals("F") Then

            'If (mStr.Length > 0) AndAlso _funcoes.ValidaCPF_SoNumeros(mStr) = False Then
            '    MsgBox("CPF do Cliente invalido!", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
            'End If

        Else

            'If (mStr.Length > 0) AndAlso _funcoes.ValidaCNPJ(Cliente.cCpfCnpj) = False Then
            '    MsgBox("CNPJ do Cliente invalido!", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
            'End If
        End If


        If (Cliente.cemail.Length > 0) AndAlso _funcoes.validaEMAIL(Cliente.cemail) = False Then
            MsgBox("EMAIL do Cliente invalido!", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        If (Cliente.ctelefone.Length > 0) AndAlso _funcoes.validaTELEFONE_SoNumeros(Cliente.ctelefone) = False Then
            MsgBox("TELEFONE do Cliente invalido!", MsgBoxStyle.Exclamation, Application.CompanyName) : Return False
        End If

        Return True
    End Function

    Public Function ClienteConsulta(ByRef Cliente As ClCliente, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClienteDAO:ClienteConsulta"":: " & ex.Message)
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

    Public Function TrazCliente(ByRef Cliente As ClCliente, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClienteDAO:TrazCliente"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT cid, cnome, cestado, ccidade, cendereco, creferencia, cinativo, cdatanascimento, ctelefone, " '8
        consulta += "cbairro, cdataservico, cdiames, ccpf, ccep, cemail, tipo, observacao, ufid, cidadeid, cidadecodigo, " '19
        consulta += "crg, capelido, cpai, cmae, cof, clocaltrabalho, cfuncaotrabalho, cnomeconjugue, capelidoconjugue " '28
        consulta += "FROM cliente WHERE cid = " & Cliente.cid
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Cliente.cid = dr(0)
            Cliente.cnome = dr(1).ToString
            Cliente.cestado = dr(2).ToString
            Cliente.ccidade = dr(3).ToString
            Cliente.cendereco = dr(4).ToString
            Cliente.creferencia = dr(5).ToString
            Cliente.cinativo = dr(6)
            Cliente.cdatanascimento = ""
            If IsDate(dr(7)) Then Cliente.cdatanascimento = dr(7)
            Cliente.ctelefone = dr(8).ToString
            Cliente.cbairro = dr(9).ToString
            Cliente.cdataservico = ""
            If IsDate(dr(10)) Then Cliente.cdataservico = dr(10)
            Cliente.cdiames = dr(11).ToString
            Cliente.cCpfCnpj = dr(12).ToString
            Cliente.ccep = dr(13).ToString
            Cliente.cemail = dr(14).ToString
            Cliente.tipo = dr(15).ToString
            Cliente.observacao = dr(16).ToString
            Cliente.ufid = dr(17)
            Cliente.cidadeid = dr(18)
            Cliente.cidadecodigo = dr(19).ToString

            'Ótica:
            Cliente.cliRG = dr(20).ToString
            Cliente.cliApelido = dr(21).ToString
            Cliente.cliPai = dr(22).ToString
            Cliente.cliMae = dr(23).ToString
            Cliente.cliOF = dr(24).ToString
            Cliente.cliLocalTrabalho = dr(25).ToString
            Cliente.cliFuncaoTrabalho = dr(26).ToString
            Cliente.cliNomeConjugue = dr(27).ToString
            Cliente.cliApelidoConjugue = dr(28).ToString


        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazIdUltimoCliente(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction) As Int64


        Dim dr As NpgsqlDataReader
        Dim com As New NpgsqlCommand
        Dim consulta As String = ""
        Dim mId As Integer = 0

        Try
            consulta = "SELECT MAX(cid) FROM cliente"
            com.Transaction = transacao
            com = New NpgsqlCommand(consulta, conexao)
            dr = com.ExecuteReader

            While dr.Read
                mId = dr(0)
            End While
            dr.Close()
        Catch ex As Exception
            MsgBox("ERRO ao Trazer ID Ultimo Cliente - ClienteDAO:: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            com = Nothing : dr = Nothing : consulta = Nothing
        End Try


        Return mId
    End Function

    Public Function TrazClienteDaListaClientes(ByRef Cliente As ClCliente, ByVal ListClientes As List(Of ClCliente)) As Boolean

        Dim mId As Integer = Cliente.cid
        If ListClientes.Count > 0 Then
            If ListClientes.Exists(Function(c As ClCliente) c.cid = mId) Then

                For Each lc As ClCliente In ListClientes

                    If lc.cid = Cliente.cid Then

                        With Cliente

                            .cnome = lc.cnome
                            .cestado = lc.cestado
                            .ccidade = lc.ccidade
                            .cendereco = lc.cendereco
                            .cbairro = lc.cbairro
                            .cdatanascimento = lc.cdatanascimento
                            .cdataservico = lc.cdataservico
                            .cdiames = lc.cdiames
                            .ctelefone = lc.ctelefone
                            .ccep = lc.ccep
                            .cCpfCnpj = lc.cCpfCnpj
                            .cemail = lc.cemail
                            .tipo = lc.tipo
                            .observacao = lc.observacao
                            .ufid = lc.ufid
                            .cidadeid = lc.cidadeid
                            .cidadecodigo = lc.cidadecodigo

                            .cliRG = lc.cliRG
                            .cliApelido = lc.cliApelido
                            .cliPai = lc.cliPai
                            .cliMae = lc.cliMae
                            .cliOF = lc.cliOF
                            .cliLocalTrabalho = lc.cliLocalTrabalho
                            .cliFuncaoTrabalho = lc.cliFuncaoTrabalho
                            .cliNomeConjugue = lc.cliNomeConjugue
                            .cliApelidoConjugue = lc.cliApelidoConjugue
                        End With
                    End If
                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Sub TrazListClientes_BD(ByRef Cliente As List(Of ClCliente), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim dataNascimento As String = "", dataServico As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClienteDAO:TrazListClientes"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT cid, cnome, cestado, ccidade, cendereco, creferencia, cinativo, cdatanascimento, ctelefone, cbairro, " '9
        consulta += "cdataservico, cdiames, ccpf, ccep, cemail, tipo, observacao, ufid, cidadeid, cidadecodigo, crg, capelido, " '21
        consulta += "cpai, cmae, cof, clocaltrabalho, cfuncaotrabalho, cnomeconjugue, capelidoconjugue " '28
        consulta += "FROM cliente WHERE cinativo = false "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Cliente.Clear()
        While dr.Read

            dataNascimento = ""
            If IsDate(dr(7)) Then dataNascimento = dr(7)
            dataServico = ""
            If IsDate(dr(10)) Then dataServico = dr(10)

            Cliente.Add(New ClCliente(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, _
                                      dr(5).ToString, dr(6), dataNascimento, dr(8).ToString, dr(9).ToString, _
                                      dataServico, dr(11).ToString, dr(12).ToString, dr(13).ToString, dr(14).ToString, _
                                      dr(16).ToString, dr(15).ToString, dr(17), dr(18), dr(19).ToString, dr(20).ToString, _
                                      dr(21).ToString, dr(22).ToString, dr(23).ToString, dr(24).ToString, dr(25).ToString, _
                                      dr(26).ToString, dr(27).ToString, dr(28).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub TrazListClientes_LISTA(ByRef NovaListaCliente As List(Of ClCliente), ByVal ListClientes As List(Of ClCliente))

        Dim Cliente As New ClCliente
        NovaListaCliente.Clear()
        For Each lc As ClCliente In ListClientes

            Cliente.ZeraValores()
            Cliente.SetaValores(lc)
            NovaListaCliente.Add(New ClCliente(Cliente))
        Next

    End Sub

    Public Sub PreencheCboClientes(ByRef cboCliente As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClienteDAO:PreencheCboClientes"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT cnome, cid FROM cliente WHERE cinativo = false "
        If Trim(condicao).Equals("") = False Then consulta += "AND " & condicao & " "
        consulta += "ORDER BY cnome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboCliente.Items.Clear()
        If dr.HasRows = True Then
            cboCliente.AutoCompleteCustomSource.Clear()
            cboCliente.Items.Clear()
            cboCliente.Refresh()
            While dr.Read

                cboCliente.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboCliente.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboCliente.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboClientesLista(ByRef cboCliente As ComboBox, ByVal listCliente As List(Of ClCliente))



        If listCliente.Count > 0 Then

            cboCliente.AutoCompleteCustomSource.Clear()
            cboCliente.Items.Clear()
            cboCliente.Refresh()

            For Each c As ClCliente In listCliente
                cboCliente.AutoCompleteCustomSource.Add(c.cnome & " - " & c.cid.ToString.PadLeft(5, " "))
                cboCliente.Items.Add(c.cnome & " - " & c.cid.ToString.PadLeft(5, " "))
            Next
        End If

    End Sub

    Public Sub PreencheCboClientesRelatorio(ByRef cboCliente As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClienteDAO:PreencheCboClientesRelatorio"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT cnome, cid FROM cliente "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY cnome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboCliente.Items.Clear()
        If dr.HasRows = True Then
            cboCliente.AutoCompleteCustomSource.Clear()
            cboCliente.Items.Clear()
            cboCliente.Refresh()
            cboCliente.AutoCompleteCustomSource.Add("< TODOS >")
            cboCliente.Items.Add("< TODOS >")
            While dr.Read

                cboCliente.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboCliente.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboCliente.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboClientesConsulta(ByRef cboCliente As ComboBox, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClienteDAO:PreencheCboClientesConsulta"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT cnome, cid FROM cliente WHERE cinativo = false ORDER BY cnome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboCliente.Items.Clear()
        If dr.HasRows = True Then
            cboCliente.AutoCompleteCustomSource.Clear()
            cboCliente.Items.Clear()
            cboCliente.Refresh()
            While dr.Read

                cboCliente.AutoCompleteCustomSource.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
                cboCliente.Items.Add(dr(0).ToString & " - " & dr(1).ToString.PadLeft(5, " "))
            End While

            cboCliente.AutoCompleteMode = AutoCompleteMode.Suggest
            cboCliente.AutoCompleteSource = AutoCompleteSource.ListItems
            cboCliente.Refresh()
            cboCliente.SelectedIndex = -1

        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub InativaCliente(ByVal Cliente As ClCliente, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE cliente SET cinativo = true WHERE cid = @cid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cid", Cliente.cid)

        comm.ExecuteNonQuery()

        TrazListClientes_BD(MdlConexaoBD.ListaClientes, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub delCliente(ByVal Cliente As ClCliente, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM cliente WHERE cid = @cid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@cid", Cliente.cid)

        comm.ExecuteNonQuery()

        TrazListClientes_BD(MdlConexaoBD.ListaClientes, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

End Class
