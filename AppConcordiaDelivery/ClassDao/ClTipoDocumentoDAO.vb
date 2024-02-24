Imports Npgsql
Public Class ClTipoDocumentoDAO

    Public Sub incTipoDocumento(ByVal TipoDocumento As ClTipoDocumento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "INSERT INTO tipo_documento(td_id, td_descricao, td_tela) "
        sql += "VALUES (DEFAULT, @td_descricao, @td_tela)"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@td_descricao", TipoDocumento.td_descricao)
        comm.Parameters.Add("@td_tela", TipoDocumento.td_tela)
        comm.ExecuteNonQuery()

        TrazListTipoDocumentos(MdlConexaoBD.mdlListTipoDocumentos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Sub altTipoDocumento(ByVal TipoDocumento As ClTipoDocumento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "UPDATE tipo_documento SET td_tela = @td_tela, td_descricao = @td_descricao WHERE td_id = @td_id"

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@td_id", TipoDocumento.td_id)
        comm.Parameters.Add("@td_descricao", TipoDocumento.td_descricao)
        comm.Parameters.Add("@td_tela", TipoDocumento.td_tela)
        comm.ExecuteNonQuery()

        TrazListTipoDocumentos(MdlConexaoBD.mdlListTipoDocumentos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing
    End Sub

    Public Function ValidaTipoDocumento(ByVal TipoDocumento As ClTipoDocumento, Optional ByVal Operacao As String = "I") As Boolean

        If Trim(TipoDocumento.td_descricao).Equals("") Then MsgBox("Informe um NOME para o TipoDocumento!") : Return False

        Dim consulta As String = ""
        If Operacao.Equals("I") Then
            consulta = "SELECT td_descricao FROM tipo_documento WHERE td_descricao = '" & TipoDocumento.td_descricao & "' AND td_tela = '" & TipoDocumento.td_tela & "'"
        Else
            consulta = "SELECT td_descricao FROM tipo_documento WHERE td_id <> " & TipoDocumento.td_id & " AND td_descricao = '" & TipoDocumento.td_descricao & "' AND td_tela = '" & TipoDocumento.td_tela & "'"
        End If
        If TipoDocumentoConsulta(TipoDocumento, consulta, MdlConexaoBD.conectionPadrao) Then
            MsgBox("O TipoDocumento """ & TipoDocumento.td_descricao & """ já existe em outro CADASTRO !") : Return False
        End If

        Return True
    End Function

    Public Sub TrazListTipoDocumentos(ByRef TipoDocumento As List(Of ClTipoDocumento), ByVal strConection As String)

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""TipoDocumentoDAO:TrazListTipoDocumentos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT td_id, td_descricao, td_tela FROM tipo_documento "
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        TipoDocumento.Clear()
        While dr.Read

            TipoDocumento.Add(New ClTipoDocumento(dr(0), dr(1).ToString, dr(2)))
        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Function TrazTipoDocumento(ByRef TipoDocumento As ClTipoDocumento, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""TipoDocumentoDAO:TrazTipoDocumento"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT td_id, td_descricao, td_tela FROM tipo_documento WHERE td_id = " & TipoDocumento.td_id
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            TipoDocumento.td_id = dr(0)
            TipoDocumento.td_descricao = dr(1).ToString
            TipoDocumento.td_tela = dr(2).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazTipoDocumentoNome(ByRef TipoDocumento As ClTipoDocumento, ByVal strConection As String, _
                                          Optional ByVal tela As String = "") As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""TipoDocumentoDAO:TrazTipoDocumentoNome"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT td_id, td_descricao, td_tela FROM tipo_documento WHERE td_descricao = '" & TipoDocumento.td_descricao & "' "
        If Not tela.Equals("") Then
            consulta += "AND td_tela = '" & tela & "' "
        End If
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            TipoDocumento.td_id = dr(0)
            TipoDocumento.td_descricao = dr(1).ToString
            TipoDocumento.td_tela = dr(2).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function TrazTipoDocumentoNomeDaLista(ByRef TipoDocumento As ClTipoDocumento) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ClTipoDocumento In MdlConexaoBD.mdlListTipoDocumentos

            If a.td_descricao.Equals(TipoDocumento.td_descricao) Then

                With TipoDocumento

                    .td_id = a.td_id
                    .td_descricao = a.td_descricao
                    .td_tela = a.td_tela
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Function TrazTipoDocumentoNomeDaLista(ByRef TipoDocumento As ClTipoDocumento, ByVal ListaTipoDocumentos As List(Of ClTipoDocumento)) As Boolean

        Dim mDeuCerto As Boolean = False
        For Each a As ClTipoDocumento In ListaTipoDocumentos

            If a.td_descricao.Equals(TipoDocumento.td_descricao) Then

                With TipoDocumento

                    .td_id = a.td_id
                    .td_descricao = a.td_descricao
                    .td_tela = a.td_tela
                End With
                mDeuCerto = True
                Exit For
            End If
        Next

        Return mDeuCerto
    End Function

    Public Sub PreencheCboTipoDocumentos(ByRef cboTipoDocumento As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""TipoDocumentoDAO:PreencheCboTipoDocumentos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT td_descricao, td_id FROM tipo_documento "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY td_descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboTipoDocumento.Items.Clear()
        If dr.HasRows = True Then
            cboTipoDocumento.AutoCompleteCustomSource.Clear()
            cboTipoDocumento.Items.Clear()
            cboTipoDocumento.Refresh()
            While dr.Read

                cboTipoDocumento.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboTipoDocumento.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboTipoDocumento.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub PreencheCboTipoDocumentosLista(ByRef cboTipoDocumento As ComboBox, ByVal listTipoDocumentos As List(Of ClTipoDocumento), _
                                              Optional ByVal tela As String = "")

        If listTipoDocumentos.Count > 0 Then

            cboTipoDocumento.AutoCompleteCustomSource.Clear()
            cboTipoDocumento.Items.Clear()
            cboTipoDocumento.Refresh()

            For Each a As ClTipoDocumento In listTipoDocumentos

                Select Case tela

                    Case "AP"
                        If a.td_tela.Equals("AP") Then

                            cboTipoDocumento.AutoCompleteCustomSource.Add(a.td_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                            cboTipoDocumento.Items.Add(a.td_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                        End If
                        
                    Case "AR"
                        If a.td_tela.Equals("AR") Then

                            cboTipoDocumento.AutoCompleteCustomSource.Add(a.td_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                            cboTipoDocumento.Items.Add(a.td_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                        End If
                    Case Else
                        cboTipoDocumento.AutoCompleteCustomSource.Add(a.td_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                        cboTipoDocumento.Items.Add(a.td_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")

                End Select
               
            Next
        End If

    End Sub

    Public Sub PreencheCboTipoDocumentosListaPesquisa(ByRef cboTipoDocumento As ComboBox, ByVal listTipoDocumentos As List(Of ClTipoDocumento))

        If listTipoDocumentos.Count > 0 Then

            cboTipoDocumento.AutoCompleteCustomSource.Clear()
            cboTipoDocumento.Items.Clear()
            cboTipoDocumento.Refresh()
            cboTipoDocumento.AutoCompleteCustomSource.Add("<< Nenhum >>")
            cboTipoDocumento.Items.Add("<< Nenhum >>")
            For Each a As ClTipoDocumento In listTipoDocumentos

                cboTipoDocumento.AutoCompleteCustomSource.Add(a.td_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboTipoDocumento.Items.Add(a.td_descricao) '& " - " & dr(1).ToString.PadLeft(5, " ")
            Next
        End If

    End Sub

    Public Sub PreencheCboTipoDocumentosRelatorio(ByRef cboTipoDocumento As ComboBox, ByVal strConection As String, Optional ByVal condicao As String = "")

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""TipoDocumentoDAO:PreencheCboTipoDocumentos"":: " & ex.Message)
            Return
        End Try

        consulta = "SELECT td_descricao, td_id FROM tipo_documento "
        If Trim(condicao).Equals("") = False Then consulta += "WHERE " & condicao & " "
        consulta += "ORDER BY td_descricao ASC"
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        cboTipoDocumento.Items.Clear()
        If dr.HasRows = True Then
            cboTipoDocumento.AutoCompleteCustomSource.Clear()
            cboTipoDocumento.Items.Clear()
            cboTipoDocumento.Refresh()
            cboTipoDocumento.AutoCompleteCustomSource.Add("< TODOS >")
            cboTipoDocumento.Items.Add("< TODOS >")

            While dr.Read

                cboTipoDocumento.AutoCompleteCustomSource.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
                cboTipoDocumento.Items.Add(dr(0).ToString) '& " - " & dr(1).ToString.PadLeft(5, " ")
            End While

            cboTipoDocumento.SelectedIndex = -1
        End If
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

    End Sub

    Public Sub delTipoDocumento(ByVal TipoDocumento As ClTipoDocumento, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sql As String = ""

        sql = "DELETE FROM tipo_documento WHERE td_id = @td_id"
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sql, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@td_id", TipoDocumento.td_id)

        comm.ExecuteNonQuery()

        TrazListTipoDocumentos(MdlConexaoBD.mdlListTipoDocumentos, MdlConexaoBD.conectionPadrao)
        comm = Nothing : sql = Nothing

    End Sub

    Public Function TipoDocumentoConsulta(ByRef TipoDocumento As ClTipoDocumento, ByVal Query As String, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""TipoDocumentoDAO:TipoDocumentoConsulta"":: " & ex.Message)
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
