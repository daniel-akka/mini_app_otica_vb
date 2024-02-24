Imports Npgsql
Imports System.Text
Public Class ClMunicipioDAO

#Region "  * * Manutenção de Municípios * *  "

    Public Sub incMunicipio(ByVal objMunicipio As Cl_Municipio, ByVal conexao As NpgsqlConnection, _
                            ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("INSERT INTO cadmun(")
        sqlbuild.Append("id, id_estado, sigla_estado, cod_estado, codigo, nome) ")
        sqlbuild.Append("VALUES (DEFAULT, @id_estado, @sigla_estado, @cod_estado, @codigo, @nome);")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id_estado", objMunicipio.pIdEstado)
        comm.Parameters.Add("@sigla_estado", objMunicipio.pSiglaEstado)
        comm.Parameters.Add("@cod_estado", objMunicipio.pCodEstado)
        comm.Parameters.Add("@codigo", objMunicipio.pCodMun)
        comm.Parameters.Add("@nome", objMunicipio.pNomeMun)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub altMunicipio(ByVal id As Int32, ByVal objMunicipio As Cl_Municipio, _
                            ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("UPDATE cadmun SET ")
        sqlbuild.Append("id_estado = @id_estado, sigla_estado = @sigla_estado, cod_estado = @cod_estado, ")
        sqlbuild.Append("codigo = @codigo, nome = @nome WHERE id = @id")

        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", id)
        comm.Parameters.Add("@id_estado", objMunicipio.pIdEstado)
        comm.Parameters.Add("@sigla_estado", objMunicipio.pSiglaEstado)
        comm.Parameters.Add("@cod_estado", objMunicipio.pCodEstado)
        comm.Parameters.Add("@codigo", objMunicipio.pCodMun)
        comm.Parameters.Add("@nome", objMunicipio.pNomeMun)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Sub delMunicipio(ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction, _
                          ByVal id As Int32)

        Dim comm As New NpgsqlCommand
        Dim sqlbuild As New StringBuilder

        sqlbuild.Append("DELETE FROM cadmun WHERE id = @id")
        comm.Transaction = transacao
        comm = New NpgsqlCommand(sqlbuild.ToString, conexao)
        ' Prepara Paramentros
        comm.Parameters.Add("@id", id)

        comm.ExecuteNonQuery()


        comm = Nothing : sqlbuild = Nothing
    End Sub

    Public Function existeNomeServico(ByVal conexao As NpgsqlConnection, ByVal nome As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT s_id FROM servico WHERE s_descricao = @s_descricao"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@s_descricao", nome)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeServicoAlt(ByVal conexao As NpgsqlConnection, ByVal nome As String, _
                                     ByVal nomeAnterior As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT s_id FROM servico WHERE s_descricao <> @nomeAnterior AND s_descricao = @nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@nome", nome)
        comm.Parameters.Add("@nomeAnterior", nomeAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeCidade(ByVal conexao As NpgsqlConnection, _
                                     ByVal siglaEstado As String, ByVal nome As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT id FROM cadmun WHERE sigla_estado = @sigla_estado AND nome = @nome;"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@sigla_estado", siglaEstado)
        comm.Parameters.Add("@nome", nome)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeNomeCidadeAlt(ByVal conexao As NpgsqlConnection, _
                                     ByVal siglaEstado As String, ByVal nome As String, _
                                     ByVal nomeAnterior As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT id FROM cadmun WHERE sigla_estado = @sigla_estado AND " & _
        "nome <> @nomeAnterior AND nome = @nome"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@sigla_estado", siglaEstado)
        comm.Parameters.Add("@nome", nome)
        comm.Parameters.Add("@nomeAnterior", nomeAnterior)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeCodigoCidade(ByVal conexao As NpgsqlConnection, _
                                     ByVal codCidade As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT id FROM cadmun WHERE codigo = @codigo"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@codigo", codCidade)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Function existeCodigoCidadeAlt(ByVal conexao As NpgsqlConnection, _
                                     ByVal codCidade As String, ByVal codCidadeAnt As String) As Boolean

        Dim mexiste As Boolean = False
        Dim comm As New NpgsqlCommand
        Dim dr As NpgsqlDataReader
        Dim sqlcmd As String = "SELECT id FROM cadmun WHERE codigo <> @codigo AND codigo = @codigoAnt"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@codigo", codCidade)
        comm.Parameters.Add("@codigoAnt", codCidadeAnt)
        dr = comm.ExecuteReader
        If dr.HasRows Then mexiste = True

        dr.Close()
        comm = Nothing : dr = Nothing : sqlcmd = Nothing


        Return mexiste
    End Function

    Public Sub preenchListaCidades(ByRef ListaCidades As List(Of Cl_Municipio))

        Dim oConn As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try

        Dim cmdMunicipios As New NpgsqlCommand
        Dim sqlMunicipios As New StringBuilder
        Dim drMunicipios As NpgsqlDataReader

        Dim mCidade As New Cl_Municipio
        Dim uf As String = "", descricao As String = "", codMun As String = ""
        Dim id As Int32 = 0

        Try

            sqlMunicipios.Append("SELECT id, id_estado, sigla_estado, cod_estado, codigo, nome FROM cadmun ORDER BY nome ASC") '3
            cmdMunicipios = New NpgsqlCommand(sqlMunicipios.ToString, oConn)
            drMunicipios = cmdMunicipios.ExecuteReader


            If drMunicipios.HasRows = False Then Return
            ListaCidades.Clear()
            While drMunicipios.Read

                mCidade.zeraValores()
                With mCidade
                    .id = drMunicipios(0)
                    .pIdEstado = drMunicipios(1)
                    .pSiglaEstado = drMunicipios(2).ToString
                    .pCodEstado = drMunicipios(3).ToString
                    .pCodMun = drMunicipios(4)
                    .pNomeMun = drMunicipios(5).ToString
                End With

                ListaCidades.Add(New Cl_Municipio(mCidade))
            End While

            oConn.Close()
        Catch ex As Exception
            MsgBox("ERRO no SELECT das CIDADES:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return

        End Try

        cmdMunicipios.CommandText = ""
        sqlMunicipios.Remove(0, sqlMunicipios.ToString.Length)

        'Limpa Objetos de Memoria...
        descricao = Nothing : id = Nothing : oConn = Nothing : cmdMunicipios = Nothing
        sqlMunicipios = Nothing : drMunicipios = Nothing

    End Sub

    Public Function PreenchComboMunicipiosBD(ByVal uf As String, ByVal cboMun As Object, _
                                           ByVal strConection As String) As ComboBox

        Dim oConnMunicipios As NpgsqlConnection = New NpgsqlConnection(strConection)

        Try
            oConnMunicipios.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return cboMun
        End Try


        Dim cmd As New NpgsqlCommand
        Dim sql As New StringBuilder
        Dim dr As NpgsqlDataReader

        Try
            sql.Append("SELECT nome FROM cadmun WHERE sigla_estado = '" & uf & "' ORDER BY nome ASC")
            cmd = New NpgsqlCommand(sql.ToString, oConnMunicipios)
            dr = cmd.ExecuteReader
            Dim sstr As String = sql.ToString
            If dr.HasRows = True Then
                cboMun.AutoCompleteCustomSource.Clear()
                cboMun.Items.Clear()
                cboMun.Refresh()
                While dr.Read

                    cboMun.AutoCompleteCustomSource.Add(dr(0).ToString)
                    cboMun.Items.Add(dr(0).ToString)
                End While

                cboMun.Refresh()
                cboMun.SelectedIndex = 0
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        dr.Close() : oConnMunicipios.ClearAllPools() : oConnMunicipios.Close()
        cmd = Nothing : sql = Nothing : dr = Nothing


        oConnMunicipios = Nothing
        Return cboMun
    End Function

    Public Function PreenchComboMunicipiosLISTA(ByVal uf As String, ByVal cboMun As Object, _
                                           ByVal ListaMunicipios As List(Of Cl_Municipio)) As ComboBox

        For Each m As Cl_Municipio In ListaMunicipios

            cboMun.AutoCompleteCustomSource.Add(m.pNomeMun)
            cboMun.Items.Add(m.pNomeMun)
        Next
        
        cboMun.Refresh()
        cboMun.SelectedIndex = 0


        Return cboMun
    End Function

#End Region


#Region "   Funções de Estado"

    Public Function trazCodMun(ByVal conexao As NpgsqlConnection, ByVal siglaEstado As String, _
                               ByVal nomeMunicipio As String) As String

        Dim mCodMun As String = ""
        Dim drForn As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT codigo FROM cadmun WHERE nome = @nome AND sigla_estado = @sigla_estado"

        comm = New NpgsqlCommand(sqlcmd, conexao)
        comm.Parameters.Add("@nome", nomeMunicipio)
        comm.Parameters.Add("@sigla_estado", siglaEstado)
        drForn = comm.ExecuteReader
        While drForn.Read

            mCodMun = drForn(0)
        End While

        drForn.Close() : drForn = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mCodMun
    End Function

    Public Function trazCodMunDaLISTA(ByVal ListaMunicipios As List(Of Cl_Municipio), ByVal siglaEstado As String, _
                               ByVal nomeMunicipio As String) As String

        Dim mCodMun As String = ""
        For Each c As Cl_Municipio In ListaMunicipios

            If c.pSiglaEstado.Equals(siglaEstado) AndAlso c.pNomeMun.Equals(nomeMunicipio) Then
                mCodMun = c.pCodMun : Exit For
            End If
        Next

        Return mCodMun
    End Function

    Public Function trazCodEstado(ByVal conexao As NpgsqlConnection, ByVal siglaEstado As String) As String

        Dim mCodEstado As String = ""
        Dim drForn As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT codestado FROM cadestado WHERE sigla = @sigla "

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@sigla", siglaEstado)
        drForn = comm.ExecuteReader
        While drForn.Read

            mCodEstado = drForn(0)
        End While

        drForn.Close() : drForn = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mCodEstado
    End Function

    Public Function trazIdEstado(ByVal conexao As NpgsqlConnection, ByVal siglaEstado As String) As Int32

        Dim mIdEstado As String = 0
        Dim drForn As NpgsqlDataReader
        Dim comm As New NpgsqlCommand
        Dim sqlcmd As String = "SELECT id FROM cadestado WHERE sigla = @sigla "

        comm = New NpgsqlCommand(sqlcmd.ToString, conexao)
        comm.Parameters.Add("@sigla", siglaEstado)
        drForn = comm.ExecuteReader
        While drForn.Read

            mIdEstado = drForn(0)
        End While

        drForn.Close() : drForn = Nothing : comm = Nothing : sqlcmd = Nothing


        Return mIdEstado
    End Function

#End Region
End Class
