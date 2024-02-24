Imports Npgsql
Public Class ClUnidadeDAO


    Public Sub incUnidade(ByVal Unidade As ClUnidade, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO unidade(uid, udescricao, upadrao)"
        sql += "VALUES (DEFAULT, @udescricao, @upadrao)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@udescricao", Unidade.Descricao)
        comm.Parameters.Add("@upadrao", Unidade.uPadrao)
        comm.ExecuteNonQuery()

        TrazListUnidades(MdlConexaoBD.mdlListUnidades, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altUnidade(ByVal Unidade As ClUnidade, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE unidade SET udescricao = @udescricao, upadrao = @upadrao WHERE uid = @uid"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@uid", Unidade.Id)
        comm.Parameters.Add("@udescricao", Unidade.Descricao)
        comm.Parameters.Add("@upadrao", Unidade.uPadrao)
        comm.ExecuteNonQuery()

        TrazListUnidades(MdlConexaoBD.mdlListUnidades, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaUnidade(ByVal Unidade As ClUnidade, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Unidade.Descricao).Equals("") Then MsgBox("Informe um NOME para a Unidade!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT udescricao FROM unidade WHERE udescricao = '" & Unidade.Descricao & "'"
        Else
            consulta = "SELECT udescricao FROM unidade WHERE uid <> " & Unidade.Id & " AND udescricao = '" & Unidade.Descricao & "'"
        End If
        If UnidadeConsulta(Unidade, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Unidade """ & Unidade.Descricao & """ já existe em outro CADASTRO !") : Return False
        End If

        If Unidade.uPadrao Then

            Dim descricao As String = ""
            If Operacao.Equals("I") Then
                consulta = "SELECT udescricao FROM unidade WHERE upadrao = true"
            Else
                consulta = "SELECT udescricao FROM unidade WHERE uid <> " & Unidade.Id & " AND upadrao = true"
            End If
            If UnidadeConsulta(Unidade, consulta, MdlConexaoBD.conectionPadrao, descricao) Then
                MsgBox("Já existe outra Unidade Padrão no Sistema! A Unidade -> " & descricao) : Return False
            End If
        End If

        Return True
    End Function

    Public Sub TrazListUnidades(ByRef Unidade As List(Of ClUnidade), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UnidadeDAO:TrazUnidade"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT uid, udescricao, upadrao FROM unidade "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Unidade.Clear()
        While dr.Read

            Unidade.Add(New ClUnidade(dr(0), dr(1).ToString, dr(2)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazUnidade(ByRef Unidade As ClUnidade, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UnidadeDAO:TrazUnidade"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT uid, udescricao, upadrao FROM unidade WHERE uid = " & Unidade.Id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Unidade.Id = dr(0)
            Unidade.Descricao = dr(1).ToString
            Unidade.uPadrao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazUnidadeNome(ByRef Unidade As ClUnidade, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UnidadeDAO:TrazUnidade"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT uid, udescricao, upadrao FROM unidade WHERE udescricao = '" & Unidade.Descricao & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Unidade.Id = dr(0)
            Unidade.Descricao = dr(1).ToString
            Unidade.uPadrao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazUnidadeNome(ByVal vNome As String, ByVal strConection As String) As ClUnidade

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vUnidade As New ClUnidade

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UnidadeDAO:TrazUnidade"":: " & ex.Message)
            Return vUnidade
        End Try

        consulta = "SELECT uid, udescricao, upadrao FROM unidade WHERE udescricao = '" & vNome & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            vUnidade.Id = dr(0)
            vUnidade.Descricao = dr(1).ToString
            vUnidade.uPadrao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return vUnidade
    End Function

    Public Sub PreencheCboUnidades(ByRef cboUnidade As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UnidadeDAO:PreencheCboUnidades"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT udescricao, uid, upadrao FROM unidade "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY udescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboUnidade.Items.Clear()
        If dr.HasRows = True Then
            cboUnidade.AutoCompleteCustomSource.Clear()
            cboUnidade.Items.Clear()
            cboUnidade.Refresh()
            While dr.Read

                cboUnidade.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboUnidade.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboUnidade.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboUnidades_Padrao(ByRef cboUnidade As ComboBox, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim und_padrao As String = ""
        Dim clFuncoes As New ClFuncoes

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UnidadeDAO:PreencheCboUnidades"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT udescricao, uid, upadrao FROM unidade "
        consulta += "ORDER BY udescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboUnidade.Items.Clear()
        If dr.HasRows = True Then
            cboUnidade.AutoCompleteCustomSource.Clear()
            cboUnidade.Items.Clear()
            cboUnidade.Refresh()
            While dr.Read

                cboUnidade.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboUnidade.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")

                If dr(2) Then und_padrao = dr(0).ToString
            End While


            If und_padrao.Equals("") Then
                cboUnidade.SelectedIndex = -1
            Else
                cboUnidade.SelectedIndex = clFuncoes.trazIndexCboTextoTodo(und_padrao, cboUnidade)
            End If

        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboUnidadesLista(ByRef cboUnidade As ComboBox, ByVal listUnidades As List(Of ClUnidade))

        If listUnidades.Count > 0 Then

            cboUnidade.AutoCompleteCustomSource.Clear()
            cboUnidade.Items.Clear()
            cboUnidade.Refresh()

            For Each a As ClUnidade In listUnidades

                cboUnidade.AutoCompleteCustomSource.Add(a.Descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboUnidade.Items.Add(a.Descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboUnidadesRelatorio(ByRef cboUnidade As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UnidadeDAO:PreencheCboUnidades"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT udescricao, uid, upadrao FROM unidade "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY udescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboUnidade.Items.Clear()
        If dr.HasRows = True Then
            cboUnidade.AutoCompleteCustomSource.Clear()
            cboUnidade.Items.Clear()
            cboUnidade.Refresh()
            cboUnidade.AutoCompleteCustomSource.Add("< TODOS >")
            cboUnidade.Items.Add("< TODOS >")

            While dr.Read

                cboUnidade.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboUnidade.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboUnidade.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delUnidade(ByVal Unidade As ClUnidade, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM unidade WHERE uid = @uid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@uid", Unidade.Id)

        comm.ExecuteNonQuery()

        TrazListUnidades(MdlConexaoBD.mdlListUnidades, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function UnidadeConsulta(ByRef Unidade As ClUnidade, ByVal Query As String, ByVal strConection As String, Optional ByRef descr_unidade As String = "") As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UnidadeDAO:UnidadeConsulta"":: " & ex.Message)
            Return False
        End Try

        consulta = Query
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                descr_unidade = dr(0).ToString
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
