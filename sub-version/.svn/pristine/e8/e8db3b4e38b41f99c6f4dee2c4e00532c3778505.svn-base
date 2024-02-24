Imports Npgsql
Public Class ClGrupoDespMensalDAO

    Public Sub incGrupoDespMensal(ByVal GrupoDespMensal As ClGrupoDespMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO grupo_desp_m(gp_id, gp_descricao) "
        sql += "VALUES (DEFAULT, @gp_descricao)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@gp_id", GrupoDespMensal.gp_id)
        comm.Parameters.Add("@gp_descricao", GrupoDespMensal.gp_descricao)
        comm.ExecuteNonQuery()

        TrazListGrupoDespMensalDoBANCO(MdlConexaoBD.ListaGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altGrupoDespMensal(ByVal GrupoDespMensal As ClGrupoDespMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE grupo_desp_m SET gp_descricao = @gp_descricao WHERE gp_id = @gp_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@gp_id", GrupoDespMensal.gp_id)
        comm.Parameters.Add("@gp_descricao", GrupoDespMensal.gp_descricao)

        comm.ExecuteNonQuery()

        TrazListGrupoDespMensalDoBANCO(MdlConexaoBD.ListaGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaGrupoDespMensal(ByVal Grupo As ClGrupoDespMensal, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Grupo.gp_descricao).Equals("") Then MsgBox("Informe uma Descricao para o GRUPO!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT gp_descricao FROM grupo_desp_m WHERE gp_descricao = '" & Grupo.gp_descricao & "'"
        Else
            consulta = "SELECT gp_descricao FROM grupo_desp_m WHERE gp_id <> " & Grupo.gp_id & " AND gp_descricao = '" & Grupo.gp_descricao & "'"
        End If
        If GrupoConsulta(Grupo, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O GRUPO """ & Grupo.gp_descricao & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Function GrupoConsulta(ByRef Grupo As ClGrupoDespMensal, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClGrupoDespMensalDAO:GrupoConsulta"":: " & ex.Message)
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

    Public Sub PreencheCboGrupos(ByRef cboGrupo As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClGrupoDespMensalDAO:PreencheCboGrupos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT gp_id, gp_descricao FROM grupo_desp_m "
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

                cboGrupo.AutoCompleteCustomSource.Add(dr(1).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboGrupo.Items.Add(dr(1).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboGrupo.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboGrupoLista(ByRef cboBairro As ComboBox, ByVal listGrupos As List(Of ClGrupoDespMensal))

        If listGrupos.Count > 0 Then

            cboBairro.AutoCompleteCustomSource.Clear()
            cboBairro.Items.Clear()
            cboBairro.Refresh()

            For Each g As ClGrupoDespMensal In listGrupos

                cboBairro.AutoCompleteCustomSource.Add(g.gp_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboBairro.Items.Add(g.gp_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboGrupoListaPesq(ByRef cboBairro As ComboBox, ByVal listGrupos As List(Of ClGrupoDespMensal))

        If listGrupos.Count > 0 Then

            cboBairro.AutoCompleteCustomSource.Clear()
            cboBairro.Items.Clear()
            cboBairro.Refresh()
            cboBairro.AutoCompleteCustomSource.Add("<< TODOS >>") '& " - " & dr(1).ToString.PadLeft(5, " ")
            cboBairro.Items.Add("<< TODOS >>")

            For Each g As ClGrupoDespMensal In listGrupos

                cboBairro.AutoCompleteCustomSource.Add(g.gp_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboBairro.Items.Add(g.gp_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub TrazListGrupoDespMensalDoBANCO(ByRef ClGrupoDespMensal As List(Of ClGrupoDespMensal), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mGrupoDespMensal As New ClGrupoDespMensal

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClGrupoDespMensalDAO:TrazListGrupoDespMensal"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT gp_id, gp_descricao FROM grupo_desp_m "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        ClGrupoDespMensal.Clear()
        While dr.Read

            mGrupoDespMensal.zeraValores()
            With mGrupoDespMensal

                .gp_id = dr(0)
                .gp_descricao = dr(1).ToString
            End With

            ClGrupoDespMensal.Add(New ClGrupoDespMensal(mGrupoDespMensal))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazGrupoNomeDoBANCO(ByRef Grupo As ClGrupoDespMensal, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClGrupoDespMensalDAO:TrazGrupoNome"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT gp_id, gp_descricao FROM grupo_desp_m WHERE gp_descricao = '" & Grupo.gp_descricao & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Grupo.gp_id = dr(0)
            Grupo.gp_descricao = dr(1).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazGrupoDespMensalDoBancoDadosPorID(ByRef GrupoDespMensal As ClGrupoDespMensal, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClGrupoDespMensalDAO:TrazGrupoDespMensalDoBancoDados"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT gp_id, gp_descricao FROM grupo_desp_m WHERE gp_id = " & GrupoDespMensal.gp_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            GrupoDespMensal.zeraValores()
            With GrupoDespMensal

                .gp_id = dr(0)
                .gp_descricao = dr(1).ToString
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazGrupoDespMensalDaListaPorID(ByRef GrupoDespMensal As ClGrupoDespMensal, ByVal ListaGrupoDespMensal As List(Of ClGrupoDespMensal)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each g As ClGrupoDespMensal In ListaGrupoDespMensal

            If g.gp_id = GrupoDespMensal.gp_id Then

                With GrupoDespMensal

                    .gp_id = g.gp_id
                    .gp_descricao = g.gp_descricao
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazGrupoDespMensalDaListaPorNOME(ByRef GrupoDespMensal As ClGrupoDespMensal, ByVal ListaGrupoDespMensal As List(Of ClGrupoDespMensal)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each g As ClGrupoDespMensal In ListaGrupoDespMensal

            If g.gp_descricao = GrupoDespMensal.gp_descricao Then

                With GrupoDespMensal

                    .gp_id = g.gp_id
                    .gp_descricao = g.gp_descricao
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Sub delGrupoDespMensal(ByVal GrupoDespMensal As ClGrupoDespMensal, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM grupo_desp_m WHERE gp_id = @gp_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@gp_id", GrupoDespMensal.gp_id)

        comm.ExecuteNonQuery()

        TrazListGrupoDespMensalDoBANCO(MdlConexaoBD.ListaGrupoDespMensal, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

End Class
