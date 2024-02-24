Imports Npgsql
Public Class ClGrupoProdutoDAO

    Public Sub incGrupo(ByVal Grupo As ClGrupoProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO grupo_produto(gp_id, gp_descricao, gp_padrao)"
        sql += "VALUES (DEFAULT, @gp_descricao, @gp_padrao)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@gp_descricao", Grupo.descricao)
        comm.Parameters.Add("@gp_padrao", Grupo.padrao)
        comm.ExecuteNonQuery()

        TrazListGrupos(MdlConexaoBD.mdlListGrupoProdutos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altGrupo(ByVal Grupo As ClGrupoProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE grupo_produto SET gp_descricao = @gp_descricao, gp_padrao = @gp_padrao WHERE gp_id = @gp_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@gp_id", Grupo.idGrupo)
        comm.Parameters.Add("@gp_descricao", Grupo.descricao)
        comm.Parameters.Add("@gp_padrao", Grupo.padrao)
        comm.ExecuteNonQuery()

        TrazListGrupos(MdlConexaoBD.mdlListGrupoProdutos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaGrupo(ByVal Grupo As ClGrupoProduto, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Grupo.descricao).Equals("") Then MsgBox("Informe um NOME para a Grupo!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT gp_descricao FROM grupo_produto WHERE gp_descricao = '" & Grupo.descricao & "'"
        Else
            consulta = "SELECT gp_descricao FROM grupo_produto WHERE gp_id <> " & Grupo.idGrupo & " AND gp_descricao = '" & Grupo.descricao & "'"
        End If
        If GrupoConsulta(Grupo, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Grupo """ & Grupo.descricao & """ já existe em outro CADASTRO !") : Return False
        End If

        If Grupo.padrao Then

            Dim descricao As String = ""
            If Operacao.Equals("I") Then
                consulta = "SELECT gp_descricao FROM grupo_produto WHERE gp_padrao = true"
            Else
                consulta = "SELECT gp_descricao FROM grupo_produto WHERE gp_id <> " & Grupo.idGrupo & " AND gp_padrao = true"
            End If
            If GrupoConsulta(Grupo, consulta, MdlConexaoBD.conectionPadrao, descricao) Then
                MsgBox("Já existe outra Grupo Padrão no Sistema! A Grupo -> " & descricao) : Return False
            End If
        End If

        Return True
    End Function

    Public Sub TrazListGrupos(ByRef Grupo As List(Of ClGrupoProduto), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""GrupoDAO:TrazGrupo"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT gp_id, gp_descricao, gp_padrao FROM grupo_produto "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Grupo.Clear()
        While dr.Read

            Grupo.Add(New ClGrupoProduto(dr(0), dr(1).ToString, dr(2)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazGrupo(ByRef Grupo As ClGrupoProduto, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""GrupoDAO:TrazGrupo"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT gp_id, gp_descricao, gp_padrao FROM grupo_produto WHERE gp_id = " & Grupo.idGrupo
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Grupo.idGrupo = dr(0)
            Grupo.descricao = dr(1).ToString
            Grupo.padrao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazGrupoNome(ByRef Grupo As ClGrupoProduto, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""GrupoDAO:TrazGrupo"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT gp_id, gp_descricao, gp_padrao FROM grupo_produto WHERE gp_descricao = '" & Grupo.descricao & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Grupo.idGrupo = dr(0)
            Grupo.descricao = dr(1).ToString
            Grupo.padrao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazGrupoNome(ByVal Nome As String, ByVal strConection As String) As ClGrupoProduto

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vGrupo As New ClGrupoProduto

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""GrupoDAO:TrazGrupo"":: " & ex.Message)
            Return vGrupo
        End Try

        consulta = "SELECT gp_id, gp_descricao, gp_padrao FROM grupo_produto WHERE gp_descricao = '" & Nome & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            vGrupo.idGrupo = dr(0)
            vGrupo.descricao = dr(1).ToString
            vGrupo.padrao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return vGrupo
    End Function

    Public Sub PreencheCboGrupos(ByRef cboGrupo As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""GrupoDAO:PreencheCboGrupos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT gp_descricao, gp_id, gp_padrao FROM grupo_produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY gp_descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboGrupo.Items.Clear()
        If dr.HasRows = True Then
            cboGrupo.AutoCompleteCustomSource.Clear()
            cboGrupo.Items.Clear()
            cboGrupo.Refresh()
            While dr.Read

                cboGrupo.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboGrupo.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboGrupo.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboGrupos_Padrao(ByRef cboGrupo As ComboBox, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim und_padrao As String = ""
        Dim clFuncoes As New ClFuncoes

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""GrupoDAO:PreencheCboGrupos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT gp_descricao, gp_id, gp_padrao FROM grupo_produto "
        consulta += "ORDER BY gp_descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboGrupo.Items.Clear()
        If dr.HasRows = True Then
            cboGrupo.AutoCompleteCustomSource.Clear()
            cboGrupo.Items.Clear()
            cboGrupo.Refresh()
            While dr.Read

                cboGrupo.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboGrupo.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")

                If dr(2) Then und_padrao = dr(0).ToString
            End While


            If und_padrao.Equals("") Then
                cboGrupo.SelectedIndex = -1
            Else
                cboGrupo.SelectedIndex = clFuncoes.trazIndexCboTextoTodo(und_padrao, cboGrupo)
            End If

        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboGruposLista(ByRef cboGrupo As ComboBox, ByVal listGrupos As List(Of ClGrupoProduto))

        If listGrupos.Count > 0 Then

            cboGrupo.AutoCompleteCustomSource.Clear()
            cboGrupo.Items.Clear()
            cboGrupo.Refresh()

            For Each a As ClGrupoProduto In listGrupos

                cboGrupo.AutoCompleteCustomSource.Add(a.descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboGrupo.Items.Add(a.descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboGruposRelatorio(ByRef cboGrupo As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""GrupoDAO:PreencheCboGrupos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT gp_descricao, gp_id, gp_padrao FROM grupo_produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY gp_descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboGrupo.Items.Clear()
        If dr.HasRows = True Then
            cboGrupo.AutoCompleteCustomSource.Clear()
            cboGrupo.Items.Clear()
            cboGrupo.Refresh()
            cboGrupo.AutoCompleteCustomSource.Add("< TODOS >")
            cboGrupo.Items.Add("< TODOS >")

            While dr.Read

                cboGrupo.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboGrupo.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboGrupo.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delGrupo(ByVal Grupo As ClGrupoProduto, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM grupo_produto WHERE gp_id = @gp_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@gp_id", Grupo.idGrupo)

        comm.ExecuteNonQuery()

        TrazListGrupos(MdlConexaoBD.mdlListGrupoProdutos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function GrupoConsulta(ByRef Grupo As ClGrupoProduto, ByVal Query As String, ByVal strConection As String, Optional ByRef descr_Grupo As String = "") As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""GrupoDAO:GrupoConsulta"":: " & ex.Message)
            Return False
        End Try

        consulta = Query
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                descr_Grupo = dr(0).ToString
            End While
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
