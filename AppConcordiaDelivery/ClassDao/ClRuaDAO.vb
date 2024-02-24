Imports Npgsql
Public Class ClRuaDAO

    Public Sub incRua(ByVal Rua As ClRua, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO rua(rid, rnome)"
        sql += "VALUES (DEFAULT, @rnome)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@rnome", Rua.rNome)
        comm.ExecuteNonQuery()

        TrazListRuas(MdlConexaoBD.mdlListRuas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altRua(ByVal Rua As ClRua, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE rua SET rnome = @rnome WHERE rid = @rid"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@rid", Rua.rId)
        comm.Parameters.Add("@rnome", Rua.rNome)
        comm.ExecuteNonQuery()

        TrazListRuas(MdlConexaoBD.mdlListRuas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListRuas(ByRef Rua As List(Of ClRua), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""RuaDAO:TrazRua"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT rid, rnome FROM rua "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Rua.Clear()
        While dr.Read

            Rua.Add(New ClRua(dr(0), dr(1).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazRua(ByRef Rua As ClRua, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""RuaDAO:TrazRua"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT rid, rnome FROM rua WHERE rid = " & Rua.rId
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Rua.rId = dr(0)
            Rua.rNome = dr(1).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub PreencheCboRuasBD(ByRef cboRua As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""RuaDAO:PreencheCboRuas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT rnome, rid FROM rua "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY rnome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboRua.Items.Clear()
        If dr.HasRows = True Then
            cboRua.AutoCompleteCustomSource.Clear()
            cboRua.Items.Clear()
            cboRua.Refresh()
            While dr.Read

                cboRua.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboRua.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboRua.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboRuasLista(ByRef cboRua As ComboBox, ByVal listRuas As List(Of ClRua))

        cboRua.Text = ""
        If listRuas.Count > 0 Then

            cboRua.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cboRua.AutoCompleteSource = AutoCompleteSource.ListItems
            cboRua.AutoCompleteCustomSource.Clear()
            cboRua.Items.Clear()
            cboRua.Refresh()

            For Each a As ClRua In listRuas

                cboRua.AutoCompleteCustomSource.Add(a.rNome) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboRua.Items.Add(a.rNome) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next

        Else
            cboRua.AutoCompleteMode = AutoCompleteMode.None
            cboRua.AutoCompleteSource = AutoCompleteSource.None
        End If

    End Sub

    Public Sub delRua(ByVal Rua As ClRua, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM rua WHERE rid = @rid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@rid", Rua.rId)

        comm.ExecuteNonQuery()

        TrazListRuas(MdlConexaoBD.mdlListRuas, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function ValidaRua(ByVal Rua As ClRua, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Rua.rNome).Equals("") Then MsgBox("Informe um NOME para a Rua!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT rnome FROM rua WHERE rnome = '" & Rua.rNome & "'"
        Else
            consulta = "SELECT rnome FROM rua WHERE rid <> " & Rua.rId & " AND rnome = '" & Rua.rNome & "'"
        End If
        If RuaConsulta(Rua, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("A RUA """ & Rua.rNome & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Function ValidaRuaSemMensagem(ByVal Rua As ClRua, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Rua.rNome).Equals("") Then Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT rnome FROM rua WHERE rnome = '" & Rua.rNome & "'"
        Else
            consulta = "SELECT rnome FROM rua WHERE rid <> " & Rua.rId & " AND rnome = '" & Rua.rNome & "'"
        End If
        If RuaConsulta(Rua, consulta, MdlConexaoBD.conectionPadrao) Then
            Return False
        End If

        Return True
    End Function

    Public Function RuaConsulta(ByRef Rua As ClRua, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""RuaDAO:RuaConsulta"":: " & ex.Message)
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

    Public Function TrazRuaNome(ByRef Rua As ClRua, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""RuaDAO:TrazRuaNome"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT rid, rnome FROM rua WHERE rnome = '" & Rua.rNome & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Rua.rId = dr(0)
            Rua.rNome = dr(1).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

End Class
