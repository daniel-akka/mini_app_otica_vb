Imports Npgsql
Public Class ClDespesaProdutoDAO

    Public Sub incdesp_produto(ByVal desp_produto As ClDespesaProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO desp_produto(dpid, dpdescricao, dpporcentagem)"
        sql += "VALUES (DEFAULT, @dpdescricao, @dpporcentagem)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@dpdescricao", desp_produto.dpDescricao)
        comm.Parameters.Add("@dpporcentagem", desp_produto.dpPorcentagem)
        comm.ExecuteNonQuery()

        TrazListdesp_produtos(MdlConexaoBD.mdlListDespesasProduto, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altdesp_produto(ByVal desp_produto As ClDespesaProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE desp_produto SET dpdescricao = @dpdescricao, dpporcentagem = @dpporcentagem WHERE dpid = @dpid"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@dpid", desp_produto.dpId)
        comm.Parameters.Add("@dpdescricao", desp_produto.dpDescricao)
        comm.Parameters.Add("@dpporcentagem", desp_produto.dpPorcentagem)
        comm.ExecuteNonQuery()

        TrazListdesp_produtos(MdlConexaoBD.mdlListDespesasProduto, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function Validadesp_produto(ByVal desp_produto As ClDespesaProduto, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(desp_produto.dpDescricao).Equals("") Then MsgBox("Informe um NOME para o desp_produto!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT dpdescricao FROM desp_produto WHERE dpdescricao = '" & desp_produto.dpDescricao & "'"
        Else
            consulta = "SELECT dpdescricao FROM desp_produto WHERE dpid <> " & desp_produto.dpId & " AND dpdescricao = '" & desp_produto.dpDescricao & "'"
        End If
        If desp_produtoConsulta(desp_produto, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O desp_produto """ & desp_produto.dpDescricao & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Sub TrazListdesp_produtos(ByRef desp_produto As List(Of ClDespesaProduto), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""desp_produtoDAO:Trazdesp_produto"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT dpid, dpdescricao, dpporcentagem FROM desp_produto "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        desp_produto.Clear()
        While dr.Read

            desp_produto.Add(New ClDespesaProduto(dr(0), dr(1).ToString, dr(2)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function Trazdesp_produto(ByRef desp_produto As ClDespesaProduto, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""desp_produtoDAO:Trazdesp_produto"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT dpid, dpdescricao, dpporcentagem FROM desp_produto WHERE dpid = " & desp_produto.dpId
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            desp_produto.dpId = dr(0)
            desp_produto.dpDescricao = dr(1).ToString
            desp_produto.dpPorcentagem = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function Trazdesp_produtoNome(ByRef desp_produto As ClDespesaProduto, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""desp_produtoDAO:Trazdesp_produto"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT dpid, dpdescricao, dpporcentagem FROM desp_produto WHERE dpdescricao = '" & desp_produto.dpDescricao & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            desp_produto.dpId = dr(0)
            desp_produto.dpDescricao = dr(1).ToString
            desp_produto.dpPorcentagem = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub PreencheCbodesp_produtos(ByRef cbodesp_produto As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""desp_produtoDAO:PreencheCbodesp_produtos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT dpdescricao, dpid FROM desp_produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY dpdescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cbodesp_produto.Items.Clear()
        If dr.HasRows = True Then
            cbodesp_produto.AutoCompleteCustomSource.Clear()
            cbodesp_produto.Items.Clear()
            cbodesp_produto.Refresh()
            While dr.Read

                cbodesp_produto.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cbodesp_produto.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cbodesp_produto.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCbodesp_produtosLista(ByRef cbodesp_produto As ComboBox, ByVal listdesp_produtos As List(Of ClDespesaProduto))

        If listdesp_produtos.Count > 0 Then

            cbodesp_produto.AutoCompleteCustomSource.Clear()
            cbodesp_produto.Items.Clear()
            cbodesp_produto.Refresh()

            For Each a As ClDespesaProduto In listdesp_produtos

                cbodesp_produto.AutoCompleteCustomSource.Add(a.dpDescricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cbodesp_produto.Items.Add(a.dpDescricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCbodesp_produtosRelatorio(ByRef cbodesp_produto As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""desp_produtoDAO:PreencheCbodesp_produtos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT dpdescricao, dpid FROM desp_produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY dpdescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cbodesp_produto.Items.Clear()
        If dr.HasRows = True Then
            cbodesp_produto.AutoCompleteCustomSource.Clear()
            cbodesp_produto.Items.Clear()
            cbodesp_produto.Refresh()
            cbodesp_produto.AutoCompleteCustomSource.Add("< TODOS >")
            cbodesp_produto.Items.Add("< TODOS >")

            While dr.Read

                cbodesp_produto.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cbodesp_produto.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cbodesp_produto.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub deldesp_produto(ByVal desp_produto As ClDespesaProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM desp_produto WHERE dpid = @aid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@dpid", desp_produto.dpId)

        comm.ExecuteNonQuery()

        TrazListdesp_produtos(MdlConexaoBD.mdlListDespesasProduto, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function desp_produtoConsulta(ByRef desp_produto As ClDespesaProduto, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""desp_produtoDAO:TrazTEMPO"":: " & ex.Message)
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
