Imports Npgsql
Public Class ClFornecedorDAO

    Dim _funcoes As New ClFuncoes

    Public Sub incFornecedor(ByVal Fornecedor As ClFornecedor, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO fornecedor(fid, fnome, fendereco, fbairro, fcidade, festado, fidestado, fidcidade, fcnpj, fcpf, ftelefone)"
        sql += "VALUES (DEFAULT, @fnome, @fendereco, @fbairro, @fcidade, @festado, @fidestado, @fidcidade, @fcnpj, @fcpf, @ftelefone)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fnome", Fornecedor.pNome)
        comm.Parameters.Add("@fendereco", Fornecedor.pEndereco)
        comm.Parameters.Add("@fbairro", Fornecedor.pBairro)
        comm.Parameters.Add("@fcidade", Fornecedor.pCidade)
        comm.Parameters.Add("@festado", Fornecedor.pEstado)
        comm.Parameters.Add("@fidestado", Fornecedor.pIdEstado)
        comm.Parameters.Add("@fidcidade", Fornecedor.pIdCidade)
        comm.Parameters.Add("@fcnpj", Fornecedor.pfCnpj)
        comm.Parameters.Add("@fcpf", Fornecedor.pfCpf)
        comm.Parameters.Add("@ftelefone", Fornecedor.pfTelefone)
        comm.ExecuteNonQuery()

        TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altFornecedor(ByVal Fornecedor As ClFornecedor, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE fornecedor SET fnome = @fnome, fendereco = @fendereco, fbairro = @fbairro, fcidade = @fcidade, "
        sql += "festado = @festado, fidestado = @fidestado, fidcidade = @fidcidade, fcnpj = @fcnpj, fcpf = @fcpf, "
        sql += "ftelefone = @ftelefone WHERE fid = @fid"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fid", Fornecedor.pId)
        comm.Parameters.Add("@fnome", Fornecedor.pNome)
        comm.Parameters.Add("@fendereco", Fornecedor.pEndereco)
        comm.Parameters.Add("@fbairro", Fornecedor.pBairro)
        comm.Parameters.Add("@fcidade", Fornecedor.pCidade)
        comm.Parameters.Add("@festado", Fornecedor.pEstado)
        comm.Parameters.Add("@fidestado", Fornecedor.pIdEstado)
        comm.Parameters.Add("@fidcidade", Fornecedor.pIdCidade)
        comm.Parameters.Add("@fcnpj", Fornecedor.pfCnpj)
        comm.Parameters.Add("@fcpf", Fornecedor.pfCpf)
        comm.Parameters.Add("@ftelefone", Fornecedor.pfTelefone)
        comm.ExecuteNonQuery()

        TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaFornecedor(ByVal Fornecedor As ClFornecedor, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Fornecedor.pNome).Equals("") Then MsgBox("Informe um NOME para a Fornecedor!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT fnome FROM fornecedor WHERE fnome = '" & Fornecedor.pNome & "'"
        Else
            consulta = "SELECT fnome FROM fornecedor WHERE fid <> " & Fornecedor.pId & " AND fnome = '" & Fornecedor.pNome & "'"
        End If
        If FornecedorConsulta(Fornecedor, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Fornecedor """ & Fornecedor.pNome & """ já existe em outro CADASTRO !") : Return False
        End If

        If (Fornecedor.pfCnpj.Equals("") = False) AndAlso Not _funcoes.ValidaCNPJ(Fornecedor.pfCnpj) Then
            MsgBox("CNPJ do Fornecedor Invalido!", MsgBoxStyle.Exclamation, mdlPadraoSistema.psnomesistema) : Return False
        End If

        If (Fornecedor.pfCpf.Equals("") = False) AndAlso Not _funcoes.ValidaCPF(Fornecedor.pfCpf) Then
            MsgBox("CPF do Fornecedor Invalido!", MsgBoxStyle.Exclamation, mdlPadraoSistema.psnomesistema) : Return False
        End If

        Return True
    End Function

    Public Sub TrazListFornecedoresBD(ByRef Fornecedor As List(Of ClFornecedor), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:TrazFornecedor"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT fid, fnome, fendereco, fbairro, fcidade, festado, fidestado, fidcidade, fcnpj, fcpf, ftelefone FROM fornecedor "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Fornecedor.Clear()
        While dr.Read

            Fornecedor.Add(New ClFornecedor(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString, _
                                            dr(6), dr(7), dr(8).ToString, dr(9).ToString, dr(10).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazFornecedorDoBD(ByRef Fornecedor As ClFornecedor, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:TrazFornecedor"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT fid, fnome, fendereco, fbairro, fcidade, festado, fidestado, fidcidade, fcnpj, fcpf, ftelefone FROM fornecedor WHERE fid = " & Fornecedor.pId
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Fornecedor.pId = dr(0)
            Fornecedor.pNome = dr(1).ToString
            Fornecedor.pEndereco = dr(2).ToString
            Fornecedor.pBairro = dr(3).ToString
            Fornecedor.pCidade = dr(4).ToString
            Fornecedor.pEstado = dr(5).ToString
            Fornecedor.pIdEstado = dr(6)
            Fornecedor.pIdCidade = dr(7)
            Fornecedor.pfCnpj = dr(8).ToString
            Fornecedor.pfCpf = dr(9).ToString
            Fornecedor.pfTelefone = dr(10).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazFornecedorDaLista(ByRef Fornecedor As ClFornecedor, ByVal ListFornecedores As List(Of ClFornecedor)) As Boolean

        Dim mId As Integer = Fornecedor.pId
        If ListFornecedores.Count > 0 Then
            If ListFornecedores.Exists(Function(c As ClFornecedor) c.pId = mId) Then

                For Each lc As ClFornecedor In ListFornecedores

                    If lc.pId = Fornecedor.pId Then

                        Fornecedor.SetaValores(lc)
                    End If
                Next
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Function TrazFornecedorNome(ByRef Fornecedor As ClFornecedor, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:TrazFornecedor"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT fid, fnome FROM fornecedor WHERE fnome = '" & Fornecedor.pNome & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Fornecedor.pId = dr(0)
            Fornecedor.pNome = dr(1).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub PreencheCboFornecedores(ByRef cboFornecedor As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:PreencheCboFornecedors"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT fnome, fid FROM fornecedor "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY fnome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboFornecedor.Items.Clear()
        If dr.HasRows = True Then
            cboFornecedor.AutoCompleteCustomSource.Clear()
            cboFornecedor.Items.Clear()
            cboFornecedor.Refresh()
            While dr.Read

                cboFornecedor.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboFornecedor.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboFornecedor.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboFornecedoresLista(ByRef cboFornecedor As ComboBox, ByVal listFornecedores As List(Of ClFornecedor))

        If listFornecedores.Count > 0 Then

            cboFornecedor.AutoCompleteCustomSource.Clear()
            cboFornecedor.Items.Clear()
            cboFornecedor.Refresh()

            For Each a As ClFornecedor In listFornecedores

                cboFornecedor.AutoCompleteCustomSource.Add(a.pNome & " - " & a.pId.ToString.PadLeft(5, " "))
                cboFornecedor.Items.Add(a.pNome & " - " & a.pId.ToString.PadLeft(5, " "))
            Next
        End If

    End Sub

    Public Sub PreencheCboFornecedoresListaPesq(ByRef cboFornecedor As ComboBox, ByVal listFornecedores As List(Of ClFornecedor))

        If listFornecedores.Count > 0 Then

            cboFornecedor.AutoCompleteCustomSource.Clear()
            cboFornecedor.Items.Clear()
            cboFornecedor.Refresh()

            cboFornecedor.Items.Add("< Todos >")

            For Each a As ClFornecedor In listFornecedores

                cboFornecedor.AutoCompleteCustomSource.Add(a.pNome & " - " & a.pId.ToString.PadLeft(5, " "))
                cboFornecedor.Items.Add(a.pNome & " - " & a.pId.ToString.PadLeft(5, " "))
            Next
        End If

    End Sub

    Public Sub PreencheCboFornecedoresRelatorio(ByRef cboFornecedor As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:PreencheCboFornecedors"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT fnome, fid FROM fornecedor "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY fnome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboFornecedor.Items.Clear()
        If dr.HasRows = True Then
            cboFornecedor.AutoCompleteCustomSource.Clear()
            cboFornecedor.Items.Clear()
            cboFornecedor.Refresh()
            cboFornecedor.AutoCompleteCustomSource.Add("< TODOS >")
            cboFornecedor.Items.Add("< TODOS >")

            While dr.Read

                cboFornecedor.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboFornecedor.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboFornecedor.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delFornecedor(ByVal Fornecedor As ClFornecedor, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM fornecedor WHERE fid = @fid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@fid", Fornecedor.pId)

        comm.ExecuteNonQuery()

        TrazListFornecedoresBD(MdlConexaoBD.ListaFornecedores, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function FornecedorConsulta(ByRef Fornecedor As ClFornecedor, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""FornecedorDAO:FornecedorConsulta"":: " & ex.Message)
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
