Imports Npgsql
Imports System.Text
Public Class ClInfoNutriPessoa

    Public Property inp_id As Int64
    Public Property inp_pessoaid As Int64
    Public Property inp_pessoanome As String
    Public Property inp_pessoapeso As Double
    Public Property inp_pessoaaltura As Double
    Public Property inp_pessoaidade As Int16
    Public Property inp_resultadoIMC As Double
    Public Property inp_imcid As Integer
    Public Property inp_imcclassificacao As String
    Public Property inp_problema1 As String
    Public Property inp_problema2 As String
    Public Property inp_problema3 As String
    Public Property inp_problema4 As String
    Public Property inp_problema5 As String
    Public Property inp_problema6 As String
    Public Property inp_observacao As String
    Public DAO As InfoNutriBancoDados

    Sub New()

        With Me

            .inp_id = 0
            .inp_pessoaid = 0
            .inp_pessoanome = ""
            .inp_pessoapeso = 0
            .inp_pessoaaltura = 0
            .inp_pessoaidade = 0
            .inp_imcid = 0
            .inp_imcclassificacao = ""
            .inp_problema1 = ""
            .inp_problema2 = ""
            .inp_problema3 = ""
            .inp_problema4 = ""
            .inp_problema5 = ""
            .inp_problema6 = ""
            .inp_resultadoIMC = 0
            .inp_observacao = ""
            .DAO = New InfoNutriBancoDados
        End With
    End Sub

    Sub New(infoNutri As ClInfoNutriPessoa)

        With Me

            .inp_id = infoNutri.inp_id
            .inp_pessoaid = infoNutri.inp_pessoaid
            .inp_pessoanome = infoNutri.inp_pessoanome
            .inp_pessoapeso = infoNutri.inp_pessoanome
            .inp_pessoaaltura = infoNutri.inp_pessoaaltura
            .inp_pessoaidade = infoNutri.inp_pessoaidade
            .inp_imcid = infoNutri.inp_imcid
            .inp_imcclassificacao = infoNutri.inp_imcclassificacao
            .inp_problema1 = infoNutri.inp_problema1
            .inp_problema2 = infoNutri.inp_problema2
            .inp_problema3 = infoNutri.inp_problema3
            .inp_problema4 = infoNutri.inp_problema4
            .inp_problema5 = infoNutri.inp_problema5
            .inp_problema6 = infoNutri.inp_problema6
            .inp_resultadoIMC = 0
            .inp_observacao = infoNutri.inp_observacao
            .DAO = New InfoNutriBancoDados
        End With
    End Sub

    Sub setaValores(infoNutri As ClInfoNutriPessoa)

        With Me

            .inp_id = infoNutri.inp_id
            .inp_pessoaid = infoNutri.inp_pessoaid
            .inp_pessoanome = infoNutri.inp_pessoanome
            .inp_pessoapeso = infoNutri.inp_pessoanome
            .inp_pessoaaltura = infoNutri.inp_pessoaaltura
            .inp_pessoaidade = infoNutri.inp_pessoaidade
            .inp_imcid = infoNutri.inp_imcid
            .inp_imcclassificacao = infoNutri.inp_imcclassificacao
            .inp_problema1 = infoNutri.inp_problema1
            .inp_problema2 = infoNutri.inp_problema2
            .inp_problema3 = infoNutri.inp_problema3
            .inp_problema4 = infoNutri.inp_problema4
            .inp_problema5 = infoNutri.inp_problema5
            .inp_problema6 = infoNutri.inp_problema6
            .inp_observacao = infoNutri.inp_observacao
            .inp_resultadoIMC = 0
        End With
    End Sub

    Sub zeraValores()

        With Me

            .inp_id = 0
            .inp_pessoaid = 0
            .inp_pessoanome = ""
            .inp_pessoapeso = 0
            .inp_pessoaaltura = 0
            .inp_pessoaidade = 0
            .inp_imcid = 0
            .inp_imcclassificacao = ""
            .inp_problema1 = ""
            .inp_problema2 = ""
            .inp_problema3 = ""
            .inp_problema4 = ""
            .inp_problema5 = ""
            .inp_problema6 = ""
            .inp_observacao = ""
            .inp_resultadoIMC = 0
        End With
    End Sub

    Class InfoNutriBancoDados

        Sub New()
        End Sub

        Sub insert(ByVal infoNutri As ClInfoNutriPessoa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

            Dim comm As New NpgsqlCommand
            Dim msql As String = ""
            Dim sql As New StringBuilder

            sql.Append("INSERT INTO infonutri_pessoa(inp_id, inp_pessoaid, inp_pessoanome, inp_pessoapeso, inp_pessoaaltura, inp_pessoaidade, inp_resultadoimc, ")
            sql.Append("inp_imcid, inp_imcclassificacao, inp_problema1, inp_problema2, inp_problema3, inp_problema4, inp_problema5, inp_problema6, inp_observacao) ")
            sql.Append("VALUES ")
            sql.Append("(DEFAULT, @inp_pessoaid, @inp_pessoanome, @inp_pessoapeso, @inp_pessoaaltura, @inp_pessoaidade, @inp_resultadoimc, @inp_imcid, ")
            sql.Append("@inp_imcclassificacao, @inp_problema1, @inp_problema2, @inp_problema3, @inp_problema4, @inp_problema5, @inp_problema6, @inp_observacao) ")
            
            comm.Transaction = transacao
            comm = New NpgsqlCommand(sql.ToString, conexao)
            ' Prepara Paramentros
            comm.Parameters.Add("@inp_pessoaid", infoNutri.inp_pessoaid)
            comm.Parameters.Add("@inp_pessoanome", infoNutri.inp_pessoanome)
            comm.Parameters.Add("@inp_pessoapeso", infoNutri.inp_pessoapeso)
            comm.Parameters.Add("@inp_pessoaaltura", infoNutri.inp_pessoaaltura)
            comm.Parameters.Add("@inp_pessoaidade", infoNutri.inp_pessoaidade)
            comm.Parameters.Add("@inp_resultadoimc", infoNutri.inp_resultadoIMC)
            comm.Parameters.Add("@inp_imcid", infoNutri.inp_imcid)
            comm.Parameters.Add("@inp_imcclassificacao", infoNutri.inp_imcclassificacao)
            comm.Parameters.Add("@inp_problema1", infoNutri.inp_problema1)
            comm.Parameters.Add("@inp_problema2", infoNutri.inp_problema2)
            comm.Parameters.Add("@inp_problema3", infoNutri.inp_problema3)
            comm.Parameters.Add("@inp_problema4", infoNutri.inp_problema4)
            comm.Parameters.Add("@inp_problema5", infoNutri.inp_problema5)
            comm.Parameters.Add("@inp_problema6", infoNutri.inp_problema6)
            comm.Parameters.Add("@inp_observacao", infoNutri.inp_observacao)
            comm.ExecuteNonQuery()

            MdlConexaoBD.ListaInfoNutriPessoa = Me.TrazListaInfoNutriPessoa_BD(MdlConexaoBD.conectionPadrao)
            comm = Nothing : msql = Nothing
        End Sub

        Sub update(ByVal infoNutri As ClInfoNutriPessoa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

            Dim comm As New NpgsqlCommand
            Dim msql As String = ""
            Dim sql As New StringBuilder

            sql.Append("UPDATE infonutri_pessoa SET inp_pessoaid = @inp_pessoaid, inp_pessoanome = @inp_pessoanome, inp_pessoapeso = @inp_pessoapeso, ")
            sql.Append("inp_pessoaaltura = @inp_pessoaaltura, inp_pessoaidade = @inp_pessoaidade, inp_imcid = @inp_imcid, inp_imcclassificacao = @inp_imcclassificacao, ")
            sql.Append("inp_problema1 = @inp_problema1, inp_problema2 = @inp_problema2, inp_problema3 = @inp_problema3, inp_problema4 = @inp_problema4, ")
            sql.Append("inp_problema5 = @inp_problema5, inp_problema6 = @inp_problema6, inp_resultadoimc = @inp_resultadoimc, inp_observacao = @inp_observacao ")
            sql.Append("WHERE inp_id = @inp_id ")

            comm.Transaction = transacao
            comm = New NpgsqlCommand(sql.ToString, conexao)
            ' Prepara Paramentros
            comm.Parameters.Add("@inp_id", infoNutri.inp_id)
            comm.Parameters.Add("@inp_pessoaid", infoNutri.inp_pessoaid)
            comm.Parameters.Add("@inp_pessoanome", infoNutri.inp_pessoanome)
            comm.Parameters.Add("@inp_pessoapeso", infoNutri.inp_pessoapeso)
            comm.Parameters.Add("@inp_pessoaaltura", infoNutri.inp_pessoaaltura)
            comm.Parameters.Add("@inp_pessoaidade", infoNutri.inp_pessoaidade)
            comm.Parameters.Add("@inp_resultadoimc", infoNutri.inp_resultadoIMC)
            comm.Parameters.Add("@inp_imcid", infoNutri.inp_imcid)
            comm.Parameters.Add("@inp_imcclassificacao", infoNutri.inp_imcclassificacao)
            comm.Parameters.Add("@inp_problema1", infoNutri.inp_problema1)
            comm.Parameters.Add("@inp_problema2", infoNutri.inp_problema2)
            comm.Parameters.Add("@inp_problema3", infoNutri.inp_problema3)
            comm.Parameters.Add("@inp_problema4", infoNutri.inp_problema4)
            comm.Parameters.Add("@inp_problema5", infoNutri.inp_problema5)
            comm.Parameters.Add("@inp_problema6", infoNutri.inp_problema6)
            comm.Parameters.Add("@inp_observacao", infoNutri.inp_observacao)
            comm.ExecuteNonQuery()

            MdlConexaoBD.ListaInfoNutriPessoa = Me.TrazListaInfoNutriPessoa_BD(MdlConexaoBD.conectionPadrao)
            comm = Nothing : msql = Nothing
        End Sub

        Sub delete(ByVal infoNutri As ClInfoNutriPessoa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

            Dim comm As New NpgsqlCommand
            Dim msql As String = ""
            Dim sql As New StringBuilder

            sql.Append("DELETE FROM infonutri_pessoa WHERE inp_id = @inp_id ")

            comm.Transaction = transacao
            comm = New NpgsqlCommand(sql.ToString, conexao)
            ' Prepara Paramentros
            comm.Parameters.Add("@inp_id", infoNutri.inp_id)
            comm.ExecuteNonQuery()

            MdlConexaoBD.ListaInfoNutriPessoa = Me.TrazListaInfoNutriPessoa_BD(MdlConexaoBD.conectionPadrao)
            comm = Nothing : msql = Nothing
        End Sub

        Function TrazListaInfoNutriPessoa_BD(ByVal strConection As String) As List(Of ClInfoNutriPessoa)

            Dim novaLista As New List(Of ClInfoNutriPessoa)
            Dim infoNutri As New ClInfoNutriPessoa
            Dim conexao As New NpgsqlConnection(strConection)

            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO ao Abrir conexão em ""InfoNutri Pessoa:: TrazListaInfoNutriPessoa_BD"":: " & ex.Message)
                Return novaLista
            End Try

            Dim dr As NpgsqlDataReader
            Dim com As NpgsqlCommand
            Dim consulta As New StringBuilder

            consulta.Append("SELECT inp_id, inp_pessoaid, inp_pessoanome, inp_pessoapeso, inp_pessoaaltura, inp_pessoaidade, ")
            consulta.Append("inp_imcid, inp_imcclassificacao, inp_problema1, inp_problema2, inp_problema3, inp_problema4, ")
            consulta.Append("inp_problema5, inp_problema6, inp_resultadoimc, inp_observacao FROM infonutri_pessoa ")
            com = New NpgsqlCommand(consulta.ToString, conexao)
            dr = com.ExecuteReader

            While dr.Read

                infoNutri.zeraValores()
                With infoNutri

                    .inp_id = dr(0)
                    .inp_pessoaid = dr(1)
                    .inp_pessoanome = dr(2).ToString
                    .inp_pessoapeso = dr(3)
                    .inp_pessoaaltura = dr(4)
                    .inp_pessoaidade = dr(5)
                    .inp_imcid = dr(6)
                    .inp_imcclassificacao = dr(7).ToString
                    .inp_problema1 = dr(8).ToString
                    .inp_problema2 = dr(9).ToString
                    .inp_problema3 = dr(10).ToString
                    .inp_problema4 = dr(11).ToString
                    .inp_problema5 = dr(12).ToString
                    .inp_problema6 = dr(13).ToString
                    .inp_resultadoIMC = dr(14)
                    .inp_observacao = dr(15).ToString
                End With
                novaLista.Add(New ClInfoNutriPessoa(infoNutri))
            End While
            dr.Close()
            com.Dispose()
            conexao.Close()
            com.Dispose()

            Return novaLista
        End Function

        Function TrazInfoNutriPessoa_BD_PorIDPessoa(ByVal Pessoa As ClCliente, ByVal strConection As String) As ClInfoNutriPessoa

            Dim infoNutri As New ClInfoNutriPessoa
            Dim conexao As New NpgsqlConnection(strConection)

            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO ao Abrir conexão em ""InfoNutri Pessoa:: TrazListaInfoNutriPessoa_BD"":: " & ex.Message)
                Return infoNutri
            End Try

            Dim dr As NpgsqlDataReader
            Dim com As NpgsqlCommand
            Dim consulta As New StringBuilder

            consulta.Append("SELECT inp_id, inp_pessoaid, inp_pessoanome, inp_pessoapeso, inp_pessoaaltura, inp_pessoaidade, ")
            consulta.Append("inp_imcid, inp_imcclassificacao, inp_problema1, inp_problema2, inp_problema3, inp_problema4, ")
            consulta.Append("inp_problema5, inp_problema6, inp_resultadoimc, inp_observacao FROM infonutri_pessoa ")
            consulta.Append("WHERE inp_pessoaid = @inp_pessoaid ")
            com = New NpgsqlCommand(consulta.ToString, conexao)
            com.Parameters.Add("@inp_pessoaid", Pessoa.cid)

            dr = com.ExecuteReader

            While dr.Read

                infoNutri.zeraValores()
                With infoNutri

                    .inp_id = dr(0)
                    .inp_pessoaid = dr(1)
                    .inp_pessoanome = dr(2).ToString
                    .inp_pessoapeso = dr(3)
                    .inp_pessoaaltura = dr(4)
                    .inp_pessoaidade = dr(5)
                    .inp_imcid = dr(6)
                    .inp_imcclassificacao = dr(7).ToString
                    .inp_problema1 = dr(8).ToString
                    .inp_problema2 = dr(9).ToString
                    .inp_problema3 = dr(10).ToString
                    .inp_problema4 = dr(11).ToString
                    .inp_problema5 = dr(12).ToString
                    .inp_problema6 = dr(13).ToString
                    .inp_resultadoIMC = dr(14)
                    .inp_observacao = dr(15).ToString
                End With
            End While
            dr.Close()
            com.Dispose()
            conexao.Close()
            com.Dispose()

            Return infoNutri
        End Function

        Function TrazInfoNutriPessoa_BD_PorID(ByVal vInfoNutri As ClInfoNutriPessoa, ByVal strConection As String) As ClInfoNutriPessoa

            Dim infoNutri As New ClInfoNutriPessoa
            Dim conexao As New NpgsqlConnection(strConection)

            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO ao Abrir conexão em ""InfoNutri Pessoa:: TrazListaInfoNutriPessoa_BD"":: " & ex.Message)
                Return infoNutri
            End Try

            Dim dr As NpgsqlDataReader
            Dim com As NpgsqlCommand
            Dim consulta As New StringBuilder

            consulta.Append("SELECT inp_id, inp_pessoaid, inp_pessoanome, inp_pessoapeso, inp_pessoaaltura, inp_pessoaidade, ")
            consulta.Append("inp_imcid, inp_imcclassificacao, inp_problema1, inp_problema2, inp_problema3, inp_problema4, ")
            consulta.Append("inp_problema5, inp_problema6, inp_resultadoimc, inp_observacao FROM infonutri_pessoa ")
            consulta.Append("WHERE inp_id = @inp_id ")
            com = New NpgsqlCommand(consulta.ToString, conexao)
            com.Parameters.Add("@inp_id", vInfoNutri.inp_id)

            dr = com.ExecuteReader

            While dr.Read

                infoNutri.zeraValores()
                With infoNutri

                    .inp_id = dr(0)
                    .inp_pessoaid = dr(1)
                    .inp_pessoanome = dr(2).ToString
                    .inp_pessoapeso = dr(3)
                    .inp_pessoaaltura = dr(4)
                    .inp_pessoaidade = dr(5)
                    .inp_imcid = dr(6)
                    .inp_imcclassificacao = dr(7).ToString
                    .inp_problema1 = dr(8).ToString
                    .inp_problema2 = dr(9).ToString
                    .inp_problema3 = dr(10).ToString
                    .inp_problema4 = dr(11).ToString
                    .inp_problema5 = dr(12).ToString
                    .inp_problema6 = dr(13).ToString
                    .inp_observacao = dr(15).ToString
                    .inp_resultadoIMC = dr(14)
                End With
            End While
            dr.Close()
            com.Dispose()
            conexao.Close()
            com.Dispose()

            Return infoNutri
        End Function

        Function TrazInfoNutriPessoa_LISTA_PorID(ByVal vInfoNutri As ClInfoNutriPessoa, ByVal lista As List(Of ClInfoNutriPessoa)) As ClInfoNutriPessoa
            Dim novoInfoNutri As New ClInfoNutriPessoa
            Dim Id As Int64 = vInfoNutri.inp_id
            novoInfoNutri = lista.Find(Function(i As ClInfoNutriPessoa) i.inp_id = Id)
            Return novoInfoNutri
        End Function

        Function TrazInfoNutriPessoa_LISTA_PorIDPessoa(ByVal vPessoa As ClCliente, ByVal lista As List(Of ClInfoNutriPessoa)) As ClInfoNutriPessoa
            Dim novoInfoNutri As New ClInfoNutriPessoa
            Dim Id As Int64 = vPessoa.cid
            novoInfoNutri = lista.FindLast(Function(i As ClInfoNutriPessoa) i.inp_pessoaid = vPessoa.cid)
            Return novoInfoNutri
        End Function

    End Class

End Class
