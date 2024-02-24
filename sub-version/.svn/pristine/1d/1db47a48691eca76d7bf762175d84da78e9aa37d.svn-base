Imports Npgsql
Public Class ClEmpresaDAO

    Public Sub incEmpresa(ByVal Empresa As ClEmpresa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO empresa(empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone, empestado, empcidade, empcnpj, empcpf)"
        sql += "VALUES (DEFAULT, @emprazaosocial, @empfantasia, @empendereco, @empbairro, @empfone, @empestado, @empcidade, @empcnpj, @empcpf)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@emprazaosocial", Empresa.emprazaosocial)
        comm.Parameters.Add("@empfantasia", Empresa.empfantasia)
        comm.Parameters.Add("@empendereco", Empresa.empendereco)
        comm.Parameters.Add("@empbairro", Empresa.empbairro)
        comm.Parameters.Add("@empfone", Empresa.empfone)
        comm.Parameters.Add("@empestado", Empresa.empestado)
        comm.Parameters.Add("@empcidade", Empresa.empcidade)
        comm.Parameters.Add("@empcnpj", Empresa.empCnpj)
        comm.Parameters.Add("@empcpf", Empresa.empCPF)

        comm.ExecuteNonQuery()

        TrazListEmpresas(MdlConexaoBD.mdlListEmpresa, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altEmpresa(ByVal Empresa As ClEmpresa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE Empresa SET emprazaosocial = @emprazaosocial, empfantasia = @empfantasia, empcnpj = @empcnpj, "
        sql += "empendereco = @empendereco, empbairro = @empbairro, empfone = @empfone, empcpf = @empcpf, "
        sql += "empestado = @empestado, empcidade = @empcidade WHERE empid = @empid"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@empid", Empresa.empid)
        comm.Parameters.Add("@emprazaosocial", Empresa.emprazaosocial)
        comm.Parameters.Add("@empfantasia", Empresa.empfantasia)
        comm.Parameters.Add("@empendereco", Empresa.empendereco)
        comm.Parameters.Add("@empbairro", Empresa.empbairro)
        comm.Parameters.Add("@empfone", Empresa.empfone)
        comm.Parameters.Add("@empestado", Empresa.empestado)
        comm.Parameters.Add("@empcidade", Empresa.empcidade)
        comm.Parameters.Add("@empcnpj", Empresa.empCnpj)
        comm.Parameters.Add("@empcpf", Empresa.empCPF)
        comm.ExecuteNonQuery()

        TrazListEmpresas(MdlConexaoBD.mdlListEmpresa, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaEmpresa(ByVal Empresa As ClEmpresa, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(Empresa.emprazaosocial).Equals("") Then MsgBox("Informe um NOME para a Empresa!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT emprazaosocial FROM empresa WHERE emprazaosocial = '" & Empresa.emprazaosocial & "'"
        Else
            consulta = "SELECT emprazaosocial FROM empresa WHERE empid <> " & Empresa.empid & " AND emprazaosocial = '" & Empresa.emprazaosocial & "'"
        End If
        If EmpresaConsulta(Empresa, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O Empresa """ & Empresa.emprazaosocial & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Sub TrazListEmpresas(ByRef Empresa As List(Of ClEmpresa), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:TrazListEmpresas"":: " & ex.Message)
            Return
        End Try
        'empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone, empestado, empcidade, empcnpj, empcpf :: 10
        consulta = "SELECT empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone, empestado, empcidade, empcnpj, empcpf FROM empresa "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        Empresa.Clear()
        While dr.Read

            Empresa.Add(New ClEmpresa(dr(0), dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString, _
                                      dr(6).ToString, dr(7).ToString, dr(8).ToString, dr(9).ToString))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazEmpresa(ByRef Empresa As ClEmpresa, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:TrazEmpresa"":: " & ex.Message)
            Return False
        End Try

        'empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone, empestado, empcidade :: 8
        consulta = "SELECT empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone, empestado, empcidade, empcnpj, empcpf FROM empresa WHERE empid = " & Empresa.empid
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Empresa.empid = dr(0)
            Empresa.emprazaosocial = dr(1).ToString
            Empresa.empfantasia = dr(2).ToString
            Empresa.empendereco = dr(3).ToString
            Empresa.empbairro = dr(4).ToString
            Empresa.empfone = dr(5).ToString
            Empresa.empestado = dr(6).ToString
            Empresa.empcidade = dr(7).ToString
            Empresa.empCnpj = dr(8).ToString
            Empresa.empCPF = dr(9).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazEmpresaWhereLimit(ByRef Empresa As ClEmpresa, ByVal strConection As String, Optional ByVal Query As String = "", _
                                          Optional ByVal limit As String = " LIMIT 1") As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:TrazEmpresa"":: " & ex.Message)
            Return False
        End Try

        'empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone, empestado, empcidade :: 8
        consulta = "SELECT empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone, empestado, empcidade, empcnpj, empcpf FROM empresa "
        If Not Query.Equals("") Then consulta += Query
        consulta += limit

        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Empresa.empid = dr(0)
            Empresa.emprazaosocial = dr(1).ToString
            Empresa.empfantasia = dr(2).ToString
            Empresa.empendereco = dr(3).ToString
            Empresa.empbairro = dr(4).ToString
            Empresa.empfone = dr(5).ToString
            Empresa.empestado = dr(6).ToString
            Empresa.empcidade = dr(7).ToString
            Empresa.empCnpj = dr(8).ToString
            Empresa.empCPF = dr(9).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazEmpresaNome(ByRef Empresa As ClEmpresa, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:TrazEmpresaNome"":: " & ex.Message)
            Return False
        End Try

        'empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone, empestado, empcidade :: 8
        consulta = "SELECT empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone, empestado, empcidade, empcnpj, empcpf "
        consulta += "FROM empresa WHERE emprazaosocial = '" & Empresa.emprazaosocial & "'"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Empresa.empid = dr(0)
            Empresa.emprazaosocial = dr(1).ToString
            Empresa.empfantasia = dr(2).ToString
            Empresa.empendereco = dr(3).ToString
            Empresa.empbairro = dr(4).ToString
            Empresa.empfone = dr(5).ToString
            Empresa.empestado = dr(6).ToString
            Empresa.empcidade = dr(7).ToString
            Empresa.empCnpj = dr(8).ToString
            Empresa.empCPF = dr(9).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Sub PreencheCboEmpresasBD(ByRef cboEmpresa As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:PreencheCboEmpresas"":: " & ex.Message)
            Return
        End Try

        'empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone :: 5
        consulta = "SELECT empfantasia, empid FROM empresa "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY empfantasia ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboEmpresa.Items.Clear()
        If dr.HasRows = True Then
            cboEmpresa.AutoCompleteCustomSource.Clear()
            cboEmpresa.Items.Clear()
            cboEmpresa.Refresh()
            While dr.Read

                cboEmpresa.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEmpresa.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboEmpresa.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboEmpresasBDLimit_RazaoS(ByRef cboEmpresa As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "", _
                                          Optional ByVal limit As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:PreencheCboEmpresas"":: " & ex.Message)
            Return
        End Try

        'empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone :: 5
        consulta = "SELECT empfantasia, empid, emprazaosocial FROM empresa "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += " ORDER BY empfantasia ASC "
        If Trim(limit).Equals("") = False Then consulta += limit
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboEmpresa.Items.Clear()
        If dr.HasRows = True Then
            cboEmpresa.AutoCompleteCustomSource.Clear()
            cboEmpresa.Items.Clear()
            cboEmpresa.Refresh()
            While dr.Read

                cboEmpresa.AutoCompleteCustomSource.Add(dr(2).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEmpresa.Items.Add(dr(2).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboEmpresa.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboEmpresasBDLimit_Fantasia(ByRef cboEmpresa As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "", _
                                          Optional ByVal limit As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:PreencheCboEmpresas"":: " & ex.Message)
            Return
        End Try

        'empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone :: 5
        consulta = "SELECT empfantasia, empid, emprazaosocial FROM empresa "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += " ORDER BY empfantasia ASC "
        If Trim(limit).Equals("") = False Then consulta += limit
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboEmpresa.Items.Clear()
        If dr.HasRows = True Then
            cboEmpresa.AutoCompleteCustomSource.Clear()
            cboEmpresa.Items.Clear()
            cboEmpresa.Refresh()
            While dr.Read

                cboEmpresa.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEmpresa.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboEmpresa.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboEmpresasLista(ByRef cboEmpresa As ComboBox, ByVal listEmpresas As List(Of ClEmpresa))

        If listEmpresas.Count > 0 Then

            cboEmpresa.AutoCompleteCustomSource.Clear()
            cboEmpresa.Items.Clear()
            cboEmpresa.Refresh()

            For Each a As ClEmpresa In listEmpresas

                cboEmpresa.AutoCompleteCustomSource.Add(a.empfantasia) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEmpresa.Items.Add(a.empfantasia) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboEmpresasRelatorio(ByRef cboEmpresa As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:PreencheCboEmpresas"":: " & ex.Message)
            Return
        End Try

        'empid, emprazaosocial, empfantasia, empendereco, empbairro, empfone :: 5
        consulta = "SELECT empfantasia, empid FROM empresa "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY empfantasia ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboEmpresa.Items.Clear()
        If dr.HasRows = True Then
            cboEmpresa.AutoCompleteCustomSource.Clear()
            cboEmpresa.Items.Clear()
            cboEmpresa.Refresh()
            cboEmpresa.AutoCompleteCustomSource.Add("< TODOS >")
            cboEmpresa.Items.Add("< TODOS >")

            While dr.Read

                cboEmpresa.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboEmpresa.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboEmpresa.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delEmpresa(ByVal Empresa As ClEmpresa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM empresa WHERE empid = @empid"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@empid", Empresa.empid)

        comm.ExecuteNonQuery()

        TrazListEmpresas(MdlConexaoBD.mdlListEmpresa, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function EmpresaConsulta(ByRef Empresa As ClEmpresa, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""EmpresaDAO:EmpresaConsulta"":: " & ex.Message)
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
