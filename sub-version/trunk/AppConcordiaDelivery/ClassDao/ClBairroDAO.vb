Imports Npgsql
Public Class ClBairroDAO

    Public Sub incBairro(ByVal Bairro As ClBairro, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO bairro(bid, bnome)"
        sql += "VALUES (DEFAULT, @bnome)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@bnome", Bairro.bNome)
        comm.ExecuteNonQuery()

        TrazListBairros(MdlConexaoBD.mdlListBairros, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altBairro(ByVal Bairro As ClBairro, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE bairro SET bnome = @bnome WHERE bid = @bid"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@bid", Bairro.bId)
        comm.Parameters.Add("@bnome", Bairro.bNome)
        comm.ExecuteNonQuery()

        TrazListBairros(MdlConexaoBD.mdlListBairros, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub TrazListBairros(ByRef Bairro As List(Of ClBairro), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""BairroDAO:TrazBairro"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT bid, bnome FROM bairro "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Bairro.Clear()
        While dr.Read

            Bairro.Add(New ClBairro(dr(0), dr(1).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazBairro(ByRef Bairro As ClBairro, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""BairroDAO:TrazBairro"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT bid, bnome FROM bairro WHERE bid = " & Bairro.bId
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Bairro.bId = dr(0)
            Bairro.bNome = dr(1).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub PreencheCboBairrosBD(ByRef cboBairro As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""BairroDAO:PreencheCboBairros"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT bnome, bid FROM bairro "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY bnome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboBairro.Items.Clear()
        If dr.HasRows = True Then
            cboBairro.AutoCompleteCustomSource.Clear()
            cboBairro.Items.Clear()
            cboBairro.Refresh()
            While dr.Read

                cboBairro.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboBairro.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboBairro.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboBairrosLista(ByRef cboBairro As ComboBox, ByVal listBairros As List(Of ClBairro))

        cboBairro.Text = ""
        If listBairros.Count > 0 Then

            cboBairro.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cboBairro.AutoCompleteSource = AutoCompleteSource.ListItems
            cboBairro.AutoCompleteCustomSource.Clear()
            cboBairro.Items.Clear()
            cboBairro.Refresh()

            For Each a As ClBairro In listBairros

                cboBairro.AutoCompleteCustomSource.Add(a.bNome) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboBairro.Items.Add(a.bNome) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next

            If cboBairro.Items.Count <= 0 Then

                cboBairro.AutoCompleteSource = AutoCompleteSource.None
                cboBairro.AutoCompleteMode = AutoCompleteMode.None
            End If

        Else

            cboBairro.AutoCompleteMode = AutoCompleteMode.None
            cboBairro.AutoCompleteSource = AutoCompleteSource.None

        End If

    End Sub

    Public Sub delBairro(ByVal Bairro As ClBairro, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM bairro WHERE bid = @bid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@bid", Bairro.bId)

        comm.ExecuteNonQuery()

        TrazListBairros(MdlConexaoBD.mdlListBairros, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function ValidaBairro(ByVal Bairro As ClBairro, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Bairro.bNome).Equals("") Then MsgBox("Informe um NOME para a Bairro!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT bnome FROM bairro WHERE bnome = '" & Bairro.bNome & "'"
        Else
            consulta = "SELECT bnome FROM bairro WHERE bid <> " & Bairro.bId & " AND bnome = '" & Bairro.bNome & "'"
        End If
        If BairroConsulta(Bairro, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Bairro """ & Bairro.bNome & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Function ValidaBairroSemMensagem(ByVal Bairro As ClBairro, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Bairro.bNome).Equals("") Then Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT bnome FROM bairro WHERE bnome = '" & Bairro.bNome & "'"
        Else
            consulta = "SELECT bnome FROM bairro WHERE bid <> " & Bairro.bId & " AND bnome = '" & Bairro.bNome & "'"
        End If
        If BairroConsulta(Bairro, consulta, MdlConexaoBD.conectionPadrao) Then
            Return False
        End If

        Return True
    End Function

    Public Function BairroConsulta(ByRef Bairro As ClBairro, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""BairroDAO:TrazBAIRRO"":: " & ex.Message)
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

    Public Function TrazBairroNome(ByRef Bairro As ClBairro, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""BairroDAO:TrazBairro"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT bid, bnome FROM bairro WHERE bnome = '" & Bairro.bNome & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Bairro.bid = dr(0)
            Bairro.bnome = dr(1).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

End Class
