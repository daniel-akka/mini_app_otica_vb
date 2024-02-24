Imports Npgsql
Public Class ClMarcaDAO

    Public Sub incMarca(ByVal Marca As ClMarca, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO marca_produto(mp_id, mp_descricao, mp_padrao)"
        sql += "VALUES (DEFAULT, @mp_descricao, @mp_padrao)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@mp_descricao", Marca.descricao)
        comm.Parameters.Add("@mp_padrao", Marca.padrao)
        comm.ExecuteNonQuery()

        TrazListMarcas(MdlConexaoBD.mdlListMarca, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altMarca(ByVal Marca As ClMarca, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE marca_produto SET mp_descricao = @mp_descricao, mp_padrao = @mp_padrao WHERE mp_id = @mp_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@mp_id", Marca.idMarca)
        comm.Parameters.Add("@mp_descricao", Marca.descricao)
        comm.Parameters.Add("@mp_padrao", Marca.padrao)
        comm.ExecuteNonQuery()

        TrazListMarcas(MdlConexaoBD.mdlListMarca, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaMarca(ByVal Marca As ClMarca, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Marca.descricao).Equals("") Then MsgBox("Informe um NOME para a Marca!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT mp_descricao FROM marca_produto WHERE mp_descricao = '" & Marca.descricao & "'"
        Else
            consulta = "SELECT mp_descricao FROM marca_produto WHERE mp_id <> " & Marca.idMarca & " AND mp_descricao = '" & Marca.descricao & "'"
        End If
        If MarcaConsulta(Marca, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Marca """ & Marca.descricao & """ já existe em outro CADASTRO !") : Return False
        End If

        If Marca.padrao Then

            Dim descricao As String = ""
            If Operacao.Equals("I") Then
                consulta = "SELECT mp_descricao FROM marca_produto WHERE mp_padrao = true"
            Else
                consulta = "SELECT mp_descricao FROM marca_produto WHERE mp_id <> " & Marca.idMarca & " AND mp_padrao = true"
            End If
            If MarcaConsulta(Marca, consulta, MdlConexaoBD.conectionPadrao, descricao) Then
                MsgBox("Já existe outra Marca Padrão no Sistema! A Marca -> " & descricao) : Return False
            End If
        End If

        Return True
    End Function

    Public Sub TrazListMarcas(ByRef Marca As List(Of ClMarca), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MarcaDAO:TrazMarca"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT mp_id, mp_descricao, mp_padrao FROM marca_produto "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Marca.Clear()
        While dr.Read

            Marca.Add(New ClMarca(dr(0), dr(1).ToString, dr(2)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazMarca(ByRef Marca As ClMarca, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MarcaDAO:TrazMarca"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT mp_id, mp_descricao, mp_padrao FROM marca_produto WHERE mp_id = " & Marca.idMarca
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Marca.idMarca = dr(0)
            Marca.descricao = dr(1).ToString
            Marca.padrao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazMarcaNome(ByRef Marca As ClMarca, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MarcaDAO:TrazMarca"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT mp_id, mp_descricao, mp_padrao FROM marca_produto WHERE mp_descricao = '" & Marca.descricao & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Marca.idMarca = dr(0)
            Marca.descricao = dr(1).ToString
            Marca.padrao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazMarcaNome(ByVal Nome As String, ByVal strConection As String) As ClMarca

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim vMarca As New ClMarca

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MarcaDAO:TrazMarca"":: " & ex.Message)
            Return vMarca
        End Try

        consulta = "SELECT mp_id, mp_descricao, mp_padrao FROM marca_produto WHERE mp_descricao = '" & Nome & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            vMarca.idMarca = dr(0)
            vMarca.descricao = dr(1).ToString
            vMarca.padrao = dr(2)

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return vMarca
    End Function

    Public Sub PreencheCboMarcas(ByRef cboMarca As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MarcaDAO:PreencheCboMarcas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT mp_descricao, mp_id, mp_padrao FROM marca_produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY mp_descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboMarca.Items.Clear()
        If dr.HasRows = True Then
            cboMarca.AutoCompleteCustomSource.Clear()
            cboMarca.Items.Clear()
            cboMarca.Refresh()
            While dr.Read

                cboMarca.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboMarca.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboMarca.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboMarcas_Padrao(ByRef cboMarca As ComboBox, ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim und_padrao As String = ""
        Dim clFuncoes As New ClFuncoes

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MarcaDAO:PreencheCboMarcas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT mp_descricao, mp_id, mp_padrao FROM marca_produto "
        consulta += "ORDER BY mp_descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboMarca.Items.Clear()
        If dr.HasRows = True Then
            cboMarca.AutoCompleteCustomSource.Clear()
            cboMarca.Items.Clear()
            cboMarca.Refresh()
            While dr.Read

                cboMarca.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboMarca.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")

                If dr(2) Then und_padrao = dr(0).ToString
            End While


            If und_padrao.Equals("") Then
                cboMarca.SelectedIndex = -1
            Else
                cboMarca.SelectedIndex = clFuncoes.trazIndexCboTextoTodo(und_padrao, cboMarca)
            End If

        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboMarcasLista(ByRef cboMarca As ComboBox, ByVal listMarcas As List(Of ClMarca))

        If listMarcas.Count > 0 Then

            cboMarca.AutoCompleteCustomSource.Clear()
            cboMarca.Items.Clear()
            cboMarca.Refresh()

            For Each a As ClMarca In listMarcas

                cboMarca.AutoCompleteCustomSource.Add(a.descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboMarca.Items.Add(a.descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboMarcasRelatorio(ByRef cboMarca As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MarcaDAO:PreencheCboMarcas"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT mp_descricao, mp_id, mp_padrao FROM marca_produto "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY mp_descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboMarca.Items.Clear()
        If dr.HasRows = True Then
            cboMarca.AutoCompleteCustomSource.Clear()
            cboMarca.Items.Clear()
            cboMarca.Refresh()
            cboMarca.AutoCompleteCustomSource.Add("< TODOS >")
            cboMarca.Items.Add("< TODOS >")

            While dr.Read

                cboMarca.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboMarca.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboMarca.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delMarca(ByVal Marca As ClMarca, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM marca_produto WHERE mp_id = @mp_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@mp_id", Marca.idMarca)

        comm.ExecuteNonQuery()

        TrazListMarcas(MdlConexaoBD.mdlListMarca, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function MarcaConsulta(ByRef Marca As ClMarca, ByVal Query As String, ByVal strConection As String, Optional ByRef descr_Marca As String = "") As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""MarcaDAO:MarcaConsulta"":: " & ex.Message)
            Return False
        End Try

        consulta = Query
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                descr_Marca = dr(0).ToString
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
