Imports Npgsql
Public Class ClServicosDAO


    Public Sub incServico(ByVal Servicos As ClServicos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO servicos(sid, sdescricao, svalor, sdespcartaodinheiro, sdespcartaoporcentagem, sidatendente, snomeatendente)"
        sql += "VALUES (DEFAULT, @sdescricao, @svalor, @sdespcartaodinheiro, @sdespcartaoporcentagem, @sidatendente, @snomeatendente)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@sdescricao", Servicos.sdescricao)
        comm.Parameters.Add("@svalor", Servicos.svalor)
        comm.Parameters.Add("@sdespcartaodinheiro", Servicos.sdespcartaodinheiro)
        comm.Parameters.Add("@sdespcartaoporcentagem", Servicos.sdespcartaoporcentagem)
        comm.Parameters.Add("@sidatendente", Servicos.sidatendente)
        comm.Parameters.Add("@snomeatendente", Servicos.snomeatendente)

        comm.ExecuteNonQuery()

        TrazListServicos_BD(MdlConexaoBD.ListaServicos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altServico(ByVal Servicos As ClServicos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE servicos SET sdescricao = @sdescricao, svalor = @svalor, sdespcartaodinheiro = @sdespcartaodinheiro, "
        sql += "sdespcartaoporcentagem = @sdespcartaoporcentagem, sdataalteracao = @sdataalteracao, "
        sql += "sidatendente = @sidatendente, snomeatendente = @snomeatendente WHERE sid = @sid"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@sid", Servicos.sid)
        comm.Parameters.Add("@sdescricao", Servicos.sdescricao)
        comm.Parameters.Add("@svalor", Servicos.svalor)
        comm.Parameters.Add("@sdespcartaodinheiro", Servicos.sdespcartaodinheiro)
        comm.Parameters.Add("@sdespcartaoporcentagem", Servicos.sdespcartaoporcentagem)
        comm.Parameters.Add("@sdataalteracao", Date.Now)
        comm.Parameters.Add("@sidatendente", Servicos.sidatendente)
        comm.Parameters.Add("@snomeatendente", Servicos.snomeatendente)

        comm.ExecuteNonQuery()

        TrazListServicos_BD(MdlConexaoBD.ListaServicos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaServico(ByVal Servico As ClServicos, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Servico.sdescricao).Equals("") Then MsgBox("Informe uma DESCRICAO para o Servico!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT sdescricao FROM servicos WHERE sdescricao = '" & Servico.sdescricao & "'"
        Else
            consulta = "SELECT sdescricao FROM servicos WHERE sid <> " & Servico.sid & " AND sdescricao = '" & Servico.sdescricao & "'"
        End If
        If ServicosConsulta(Servico, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Servico """ & Servico.sdescricao & """ já existe em outro CADASTRO !") : Return False
        End If

        If Servico.svalor <= 0 Then
            MsgBox("Valor do Serviço deve ser Maior que ZERO !") : Return False
        End If

        Return True
    End Function

    Public Sub TrazListServicos_BD(ByRef Servicos As List(Of ClServicos), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ServicosDAO:TrazListServicos"":: " & ex.Message)
            Return
        End Try

        Servicos.Clear()
        ' 8 - colunas     -1
        consulta = "SELECT sid, sdescricao, svalor, sdespcartaodinheiro, sdespcartaoporcentagem, sdataalteracao, sidatendente, snomeatendente FROM servicos "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Servicos.Clear()
        While dr.Read

            Servicos.Add(New ClServicos(dr(0), dr(1).ToString, dr(5).ToString, dr(2), dr(3), dr(4), dr(6), dr(7).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Function trazListaServico_LISTA(ByVal lista As List(Of ClServicos)) As List(Of ClServicos)
        Dim NovaLista As New List(Of ClServicos)

        For Each s As ClServicos In lista
            NovaLista.Add(New ClServicos(s))
        Next

        Return NovaLista
    End Function

    Public Function TrazServico(ByRef Servico As ClServicos, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ServicosDAO:TrazServico"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT sid, sdescricao, svalor, sdespcartaodinheiro, sdespcartaoporcentagem, sdataalteracao, sidatendente, snomeatendente "
        consulta += "FROM servicos WHERE sid = " & Servico.sid
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Servico.sid = dr(0)
            Servico.sdescricao = dr(1).ToString
            Servico.svalor = dr(2)
            Servico.sdespcartaodinheiro = dr(3)
            Servico.sdespcartaoporcentagem = dr(4)
            Servico.sdataalteracao = ""
            If IsDate(dr(5)) Then Servico.sdataalteracao = dr(5)
            Servico.sidatendente = dr(6)
            Servico.snomeatendente = dr(7).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazServicoNomeDaLista(ByRef Servico As ClServicos) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each s As ClServicos In MdlConexaoBD.ListaServicos

            If s.sdescricao.Equals(Servico.sdescricao) Then

                With Servico

                    .sid = s.sid
                    .sdescricao = s.sdescricao
                    .svalor = s.svalor
                    .sdespcartaodinheiro = s.sdespcartaodinheiro
                    .sdespcartaoporcentagem = s.sdespcartaoporcentagem
                    .sdataalteracao = s.sdataalteracao
                    .sidatendente = s.sidatendente
                    .snomeatendente = s.snomeatendente
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazServicoNome(ByRef Servico As ClServicos, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ServicosDAO:TrazServicos"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT sid, sdescricao, svalor, sdespcartaodinheiro, sdespcartaoporcentagem, sdataalteracao, sidatendente, snomeatendente FROM servicos WHERE sdescricao = '" & Servico.sdescricao & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Servico.sid = dr(0)
            Servico.sdescricao = dr(1).ToString
            Servico.svalor = dr(2)
            Servico.sdespcartaodinheiro = dr(3)
            Servico.sdespcartaoporcentagem = dr(4)
            Servico.sidatendente = dr(6)
            Servico.snomeatendente = dr(7).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub PreencheCboServicosBD(ByRef cboServicos As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ServicosDAO:PreencheCboServicos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT sdescricao, sid FROM servicos "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY sdescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboServicos.Items.Clear()
        If dr.HasRows = True Then
            cboServicos.AutoCompleteCustomSource.Clear()
            cboServicos.Items.Clear()
            cboServicos.Refresh()
            While dr.Read

                cboServicos.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboServicos.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboServicos.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboServicosLista(ByRef cboServicos As ComboBox, ByVal listServicoss As List(Of ClServicos))

        If listServicoss.Count > 0 Then

            cboServicos.AutoCompleteCustomSource.Clear()
            cboServicos.Items.Clear()
            cboServicos.Refresh()

            For Each s As ClServicos In listServicoss

                cboServicos.AutoCompleteCustomSource.Add(s.sdescricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboServicos.Items.Add(s.sdescricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboServicosRelatorio(ByRef cboServicos As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ServicosDAO:PreencheCboServicosRelatorio"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT sdescricao, sid FROM servicos "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY sdescricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboServicos.Items.Clear()
        If dr.HasRows = True Then
            cboServicos.AutoCompleteCustomSource.Clear()
            cboServicos.Items.Clear()
            cboServicos.Refresh()
            cboServicos.AutoCompleteCustomSource.Add("< TODOS >")
            cboServicos.Items.Add("< TODOS >")

            While dr.Read

                cboServicos.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboServicos.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboServicos.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delServico(ByVal Servico As ClServicos, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM servicos WHERE sid = @sid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@sid", Servico.sid)

        comm.ExecuteNonQuery()

        TrazListServicos_BD(MdlConexaoBD.ListaServicos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function ServicosConsulta(ByRef Servicos As ClServicos, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ServicosDAO:ServicosConsulta"":: " & ex.Message)
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
