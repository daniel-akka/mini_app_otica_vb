Imports Npgsql
Imports System.Text

Public Class ClUsuarioDAO

    Public Sub incUsuario(ByVal Usuario As ClUsuario, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO usuario(u_id, u_login, u_nome, u_senha, u_privilegio, u_bloqueado, u_datanascimento, u_foto, u_empresaid, u_empresanome, u_caixa) "
        sql += "VALUES (DEFAULT, @u_login, @u_nome, @u_senha, @u_privilegio, @u_bloqueado, @u_datanascimento, @u_foto, @u_empresaid, @u_empresanome, @u_caixa)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@u_login", Usuario.u_login)
        comm.Parameters.Add("@u_nome", Usuario.u_nome)
        comm.Parameters.Add("@u_senha", Usuario.u_senha)
        comm.Parameters.Add("@u_privilegio", Usuario.u_privilegio)
        comm.Parameters.Add("@u_bloqueado", Usuario.u_bloqueado)
        comm.Parameters.Add("@u_datanascimento", Usuario.u_datanascimento)
        comm.Parameters.Add("@u_caixa", Usuario.u_caixa)
        If Usuario.u_foto.Equals("") Then
            comm.Parameters.Add("@u_foto", System.DBNull.Value)
        Else
            comm.Parameters.Add("@u_foto", Usuario.u_foto)
        End If

        comm.Parameters.Add("@u_empresaid", Usuario.u_empresaid)
        comm.Parameters.Add("@u_empresanome", Usuario.u_empresanome)

        comm.ExecuteNonQuery()

        TrazListUsuarios_BD(MdlConexaoBD.mdlListUsuarios, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altUsuario(ByVal Usuario As ClUsuario, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE usuario SET u_login = @u_login, u_nome = @u_nome, u_senha = @u_senha, u_privilegio = @u_privilegio, u_bloqueado = @u_bloqueado, "
        sql += "u_datanascimento = @u_datanascimento, u_foto = @u_foto, u_empresaid = @u_empresaid, u_empresanome = @u_empresanome, u_caixa = @u_caixa WHERE u_id = @u_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@u_id", Usuario.u_id)
        comm.Parameters.Add("@u_login", Usuario.u_login)
        comm.Parameters.Add("@u_nome", Usuario.u_nome)
        comm.Parameters.Add("@u_senha", Usuario.u_senha)
        comm.Parameters.Add("@u_privilegio", Usuario.u_privilegio)
        comm.Parameters.Add("@u_bloqueado", Usuario.u_bloqueado)
        comm.Parameters.Add("@u_caixa", Usuario.u_caixa)
        comm.Parameters.Add("@u_datanascimento", Usuario.u_datanascimento)
        If Usuario.u_foto.Equals("") Then
            comm.Parameters.Add("@u_foto", System.DBNull.Value)
        Else
            comm.Parameters.Add("@u_foto", Usuario.u_foto)
        End If

        comm.Parameters.Add("@u_empresaid", Usuario.u_empresaid)
        comm.Parameters.Add("@u_empresanome", Usuario.u_empresanome)
        comm.ExecuteNonQuery()

        TrazListUsuarios_BD(MdlConexaoBD.mdlListUsuarios, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaUsuario(ByVal Usuario As ClUsuario, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Usuario.u_nome).Equals("") Then MsgBox("Informe um NOME para o Usuario!") : Return False
        If Trim(Usuario.u_login).Equals("") Then MsgBox("Informe um LOGIN para o Usuario!") : Return False
        If Trim(Usuario.u_senha).Equals("") Then MsgBox("Informe uma SENHA para o Usuario!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT u_login FROM usuario WHERE u_login = '" & Usuario.u_login & "'"
        Else
            consulta = "SELECT u_login FROM usuario WHERE u_id <> " & Usuario.u_id & " AND u_login = '" & Usuario.u_login & "'"
        End If
        If UsuarioConsulta_BOOLEAN(Usuario, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O LOGIN """ & Usuario.u_login & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Sub TrazListUsuarios_BD(ByRef Usuario As List(Of ClUsuario), ByVal strConection As String, Optional ByVal Where As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""
        Dim mUsuario As New ClUsuario

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UsuarioDAO:TrazListUsuarios"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT u_id, u_login, u_nome, u_senha, u_privilegio, u_bloqueado, u_datanascimento, u_foto, u_empresaid, u_empresanome, u_caixa FROM usuario "
        If Not Where.Equals("") Then consulta += Where
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Usuario.Clear()
        While dr.Read

            mUsuario.zeraValores()
            With mUsuario

                .u_id = dr(0)
                .u_login = dr(1).ToString
                .u_nome = dr(2).ToString
                .u_senha = dr(3).ToString
                .u_privilegio = dr(4)
                .u_bloqueado = dr(5)
                .u_datanascimento = dr(6).ToString
                .u_foto = dr(7).ToString
                .u_empresaid = dr(8)
                .u_empresanome = dr(9).ToString
                .u_caixa = dr(10)
            End With

            Usuario.Add(New ClUsuario(mUsuario))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazUsuarioId_BD(ByRef Usuario As ClUsuario, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UsuarioDAO:TrazUsuario"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT u_id, u_login, u_nome, u_senha, u_privilegio, u_bloqueado, u_datanascimento, u_foto, u_empresaid, u_empresanome, u_caixa "
        consulta += "FROM usuario WHERE u_id = " & Usuario.u_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Usuario.zeraValores()
            With Usuario

                .u_id = dr(0)
                .u_login = dr(1).ToString
                .u_nome = dr(2).ToString
                .u_senha = dr(3).ToString
                .u_privilegio = dr(4)
                .u_bloqueado = dr(5)
                .u_datanascimento = dr(6).ToString
                .u_foto = dr(7).ToString
                .u_empresaid = dr(8)
                .u_empresanome = dr(9).ToString
                .u_caixa = dr(10)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazUsuarioLOGIN_BD(ByRef Usuario As ClUsuario, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UsuarioDAO:TrazUsuarioNome"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT u_id, u_login, u_nome, u_senha, u_privilegio, u_bloqueado, u_datanascimento, u_foto, u_empresaid, u_empresanome, u_caixa "
        consulta += "FROM usuario WHERE u_login = " & Usuario.u_login
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Usuario.zeraValores()
            With Usuario

                .u_id = dr(0)
                .u_login = dr(1).ToString
                .u_nome = dr(2).ToString
                .u_senha = dr(3).ToString
                .u_privilegio = dr(4)
                .u_bloqueado = dr(5)
                .u_datanascimento = dr(6).ToString
                .u_foto = dr(7).ToString
                .u_empresaid = dr(8)
                .u_empresanome = dr(9).ToString
                .u_caixa = dr(10)
            End With

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazUsuarioLOGIN_SENHA_BD(ByRef Usuario As ClUsuario, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim _sqlUsuario As New StringBuilder
        Dim _cmdUsuario As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UsuarioDAO:TrazUsuarioNome"":: " & ex.Message)
            Return False
        End Try

        _sqlUsuario.Append("SELECT u_id, u_login, u_nome, u_senha, u_privilegio, u_bloqueado, u_datanascimento, u_foto, u_empresaid, u_empresanome, u_caixa ") '5
        _sqlUsuario.Append("FROM usuario WHERE u_login = @u_login AND u_senha = @u_senha")
        _cmdUsuario = New NpgsqlCommand(_sqlUsuario.ToString, conexao)
        _cmdUsuario.Parameters.Add("@u_login", Usuario.u_login)
        _cmdUsuario.Parameters.Add("@u_senha", Usuario.u_senha)
        dr = _cmdUsuario.ExecuteReader

        While dr.Read

            Usuario.zeraValores()
            With Usuario

                .u_id = dr(0)
                .u_login = dr(1).ToString
                .u_nome = dr(2).ToString
                .u_senha = dr(3).ToString
                .u_privilegio = dr(4)
                .u_bloqueado = dr(5)
                .u_datanascimento = dr(6).ToString
                .u_foto = dr(7).ToString
                .u_empresaid = dr(8)
                .u_empresanome = dr(9).ToString
                .u_caixa = dr(10)
            End With

        End While
        dr.Close()
        _cmdUsuario.Dispose()
        conexao.Close()
        _cmdUsuario.Dispose()

        Return True
    End Function

    Public Function TrazUsuarioDaLista_PorLOGIN(ByRef Usuario As ClUsuario, ByVal listaUsu As List(Of ClUsuario)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each usu As ClUsuario In listaUsu

            If usu.u_login.Equals(Usuario.u_login) Then

                Usuario.setaValores(usu)
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazUsuarioDaLista_PorID(ByRef Usuario As ClUsuario, ByVal ListaUsuarios As List(Of ClUsuario)) As Boolean

        Dim mDeuCerto As Boolean = False
        Dim mUsuario As New ClUsuario
        Dim mID As Integer = Usuario.u_id

        mUsuario.setaValores(New ClUsuario(ListaUsuarios.Find(Function(u As ClUsuario) u.u_id = mID)))
        If mUsuario.u_id > 0 Then
            Usuario.setaValores(mUsuario)
            mDeuCerto = True
        End If

        Return mDeuCerto
    End Function

    Public Sub PreencheCboUsuariosBD(ByRef cboUsuario As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UsuarioDAO:PreencheCboUsuarios"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT u_nome, u_id FROM usuario "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY u_nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboUsuario.Items.Clear()
        If dr.HasRows = True Then
            cboUsuario.AutoCompleteCustomSource.Clear()
            cboUsuario.Items.Clear()
            cboUsuario.Refresh()
            While dr.Read

                cboUsuario.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboUsuario.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboUsuario.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboUsuariosPesquisaBD(ByRef cboUsuario As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UsuarioDAO:PreencheCboUsuarios"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT u_nome, u_id FROM usuario "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY u_nome ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboUsuario.Items.Clear()
        If dr.HasRows = True Then
            cboUsuario.AutoCompleteCustomSource.Clear()
            cboUsuario.Items.Clear()
            cboUsuario.Refresh()
            cboUsuario.AutoCompleteCustomSource.Add("<< TODOS >>")
            cboUsuario.Items.Add("<< TODOS >>")

            While dr.Read

                cboUsuario.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboUsuario.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboUsuario.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboUsuariosLista(ByRef cboUsuario As ComboBox, ByVal listUsuarios As List(Of ClUsuario))

        If listUsuarios.Count > 0 Then

            cboUsuario.AutoCompleteCustomSource.Clear()
            cboUsuario.Items.Clear()
            cboUsuario.Refresh()

            For Each a As ClUsuario In listUsuarios

                cboUsuario.AutoCompleteCustomSource.Add(a.u_nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboUsuario.Items.Add(a.u_nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboUsuariosListaPesquisa(ByRef cboUsuario As ComboBox, ByVal listUsuarios As List(Of ClUsuario))

        If listUsuarios.Count > 0 Then

            cboUsuario.AutoCompleteCustomSource.Clear()
            cboUsuario.Items.Clear()
            cboUsuario.Refresh()
            cboUsuario.AutoCompleteCustomSource.Add("<< Nenhum >>")
            cboUsuario.Items.Add("<< Nenhum >>")
            For Each a As ClUsuario In listUsuarios

                cboUsuario.AutoCompleteCustomSource.Add(a.u_nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboUsuario.Items.Add(a.u_nome) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub delUsuario(ByVal Usuario As ClUsuario, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM usuario WHERE u_id = @u_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@u_id", Usuario.u_id)

        comm.ExecuteNonQuery()

        TrazListUsuarios_BD(MdlConexaoBD.mdlListUsuarios, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Sub delUsuario_INATIVO(ByVal Usuario As ClUsuario, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE usuario SET u_inativo = @u_inativo WHERE u_id = @u_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@u_id", Usuario.u_id)
        comm.Parameters.Add("@u_inativo", Usuario.u_inativo)

        comm.ExecuteNonQuery()

        TrazListUsuarios_BD(MdlConexaoBD.mdlListUsuarios, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function UsuarioConsulta_BOOLEAN(ByRef Usuario As ClUsuario, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""UsuarioDAO:UsuarioConsulta"":: " & ex.Message)
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
