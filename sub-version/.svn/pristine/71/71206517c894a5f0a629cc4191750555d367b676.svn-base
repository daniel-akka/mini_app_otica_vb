Imports Npgsql
Imports System.Text
Public Class ClInfoNutriPessoaItem

    Public Property inpi_id As Int64
    Public Property inp_id As Int64
    Public Property inpi_servicoid As Int64
    Public Property inpi_serviconome As String
    Public Property inpi_produtoid As Int64
    Public Property inpi_produtodescricao As String
    Public DAO As InfoNPIBancoDados

    Sub New()

        With Me
            .inpi_id = 0
            .inp_id = 0
            .inpi_servicoid = 0
            .inpi_produtoid = 0
            .inpi_serviconome = ""
            .inpi_produtodescricao = ""
        End With
    End Sub

    Sub New(NPitens As ClInfoNutriPessoaItem)

        With Me
            .inpi_id = NPitens.inpi_id
            .inp_id = NPitens.inp_id
            .inpi_servicoid = NPitens.inpi_servicoid
            .inpi_produtoid = NPitens.inpi_produtoid
            .inpi_serviconome = NPitens.inpi_serviconome
            .inpi_produtodescricao = NPitens.inpi_produtodescricao
        End With
    End Sub

    Sub setaValores(NPitens As ClInfoNutriPessoaItem)

        With Me
            .inpi_id = NPitens.inpi_id
            .inp_id = NPitens.inp_id
            .inpi_servicoid = NPitens.inpi_servicoid
            .inpi_produtoid = NPitens.inpi_produtoid
            .inpi_serviconome = NPitens.inpi_serviconome
            .inpi_produtodescricao = NPitens.inpi_produtodescricao
        End With
    End Sub

    Sub zeraValores()

        With Me
            .inpi_id = 0
            .inp_id = 0
            .inpi_servicoid = 0
            .inpi_produtoid = 0
            .inpi_serviconome = ""
            .inpi_produtodescricao = ""
        End With
    End Sub

    Class InfoNPIBancoDados

        Sub New()
        End Sub

        Sub insert(ByVal infoNutri As ClInfoNutriPessoaItem, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

            Dim comm As New NpgsqlCommand
            Dim msql As String = ""
            Dim sql As New StringBuilder

            sql.Append("INSERT INTO infonutri_pessoa_itens(inpi_id, inp_id, inpi_servicoid, inpi_serviconome, inpi_produtoid, inpi_produtodescricao) ")
            sql.Append("VALUES ")
            sql.Append("(DEFAULT, @inp_id, @inpi_servicoid, @inpi_serviconome, @inpi_produtoid, @inpi_produtodescricao) ")


            comm.Transaction = transacao
            comm = New NpgsqlCommand(sql.ToString, conexao)
            ' Prepara Paramentros
            comm.Parameters.Add("@inp_id", infoNutri.inp_id)
            comm.Parameters.Add("@inpi_servicoid", infoNutri.inpi_servicoid)
            comm.Parameters.Add("@inpi_serviconome", infoNutri.inpi_serviconome)
            comm.Parameters.Add("@inpi_produtoid", infoNutri.inpi_produtoid)
            comm.Parameters.Add("@inpi_produtodescricao", infoNutri.inpi_produtodescricao)
            comm.ExecuteNonQuery()

            MdlConexaoBD.ListaItemsInfoNutriPessoa = Me.TrazListaItemInfoNutriPessoa_BD(MdlConexaoBD.conectionPadrao)
            comm = Nothing : msql = Nothing
        End Sub

        Sub delete(ByVal Item As ClInfoNutriPessoaItem, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

            Dim comm As New NpgsqlCommand
            Dim msql As String = ""
            Dim sql As New StringBuilder

            sql.Append("DELETE FROM infonutri_pessoa_itens WHERE inpi_id = @inpi_id ")

            comm.Transaction = transacao
            comm = New NpgsqlCommand(sql.ToString, conexao)
            ' Prepara Paramentros
            comm.Parameters.Add("@inpi_id", Item.inpi_id)
            comm.ExecuteNonQuery()

            MdlConexaoBD.ListaItemsInfoNutriPessoa = Me.TrazListaItemInfoNutriPessoa_BD(MdlConexaoBD.conectionPadrao)
            comm = Nothing : msql = Nothing
        End Sub

        Sub deleteID_InfoN(ByVal infoNutri As ClInfoNutriPessoa, ByVal conexao As NpgsqlConnection, ByVal transacao As NpgsqlTransaction)

            Dim comm As New NpgsqlCommand
            Dim msql As String = ""
            Dim sql As New StringBuilder

            sql.Append("DELETE FROM infonutri_pessoa_itens WHERE inp_id = @inp_id ")

            comm.Transaction = transacao
            comm = New NpgsqlCommand(sql.ToString, conexao)
            ' Prepara Paramentros
            comm.Parameters.Add("@inp_id", infoNutri.inp_id)
            comm.ExecuteNonQuery()

            MdlConexaoBD.ListaItemsInfoNutriPessoa = Me.TrazListaItemInfoNutriPessoa_BD(MdlConexaoBD.conectionPadrao)
            comm = Nothing : msql = Nothing
        End Sub

        Function TrazListaItemInfoNutriPessoa_BD(ByVal strConection As String) As List(Of ClInfoNutriPessoaItem)

            Dim novaLista As New List(Of ClInfoNutriPessoaItem)
            Dim ITEM As New ClInfoNutriPessoaItem
            Dim conexao As New NpgsqlConnection(strConection)

            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO ao Abrir conexão em ""InfoNutri Pessoa ITEM Lista :: TrazINutriPessoa_BD_PorIDInfoNutri"":: " & ex.Message)
                Return novaLista
            End Try

            Dim dr As NpgsqlDataReader
            Dim com As NpgsqlCommand
            Dim consulta As New StringBuilder

            consulta.Append("SELECT inpi_id, inp_id, inpi_servicoid, inpi_serviconome, inpi_produtoid, inpi_produtodescricao ")
            consulta.Append("FROM infonutri_pessoa_itens ")
            com = New NpgsqlCommand(consulta.ToString, conexao)

            dr = com.ExecuteReader

            While dr.Read

                ITEM.zeraValores()
                With ITEM

                    .inpi_id = dr(0)
                    .inp_id = dr(1)
                    .inpi_servicoid = dr(2)
                    .inpi_serviconome = dr(3).ToString
                    .inpi_produtoid = dr(4)
                    .inpi_produtodescricao = dr(5).ToString
                End With
                novaLista.Add(New ClInfoNutriPessoaItem(ITEM))
            End While
            dr.Close()
            com.Dispose()
            conexao.Close()
            com.Dispose()

            Return novaLista
        End Function

        Function TrazINutriPessoa_BD_PorIDInfoNutri(ByVal vInfoNutri As ClInfoNutriPessoa, ByVal strConection As String) As List(Of ClInfoNutriPessoaItem)

            Dim novaLista As New List(Of ClInfoNutriPessoaItem)
            Dim ITEM As New ClInfoNutriPessoaItem
            Dim conexao As New NpgsqlConnection(strConection)

            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO ao Abrir conexão em ""InfoNutri Pessoa ITEM Lista :: TrazINutriPessoa_BD_PorIDInfoNutri"":: " & ex.Message)
                Return novaLista
            End Try

            Dim dr As NpgsqlDataReader
            Dim com As NpgsqlCommand
            Dim consulta As New StringBuilder

            consulta.Append("SELECT inpi_id, inp_id, inpi_servicoid, inpi_serviconome, inpi_produtoid, inpi_produtodescricao ")
            consulta.Append("FROM infonutri_pessoa_itens ")
            consulta.Append("WHERE inp_id = @inp_id ")
            com = New NpgsqlCommand(consulta.ToString, conexao)
            com.Parameters.Add("@inp_id", vInfoNutri.inp_id)

            dr = com.ExecuteReader

            While dr.Read

                ITEM.zeraValores()
                With ITEM

                    .inpi_id = dr(0)
                    .inp_id = dr(1)
                    .inpi_servicoid = dr(2)
                    .inpi_serviconome = dr(3).ToString
                    .inpi_produtoid = dr(4)
                    .inpi_produtodescricao = dr(5).ToString
                End With
                novaLista.Add(New ClInfoNutriPessoaItem(ITEM))
            End While
            dr.Close()
            com.Dispose()
            conexao.Close()
            com.Dispose()

            Return novaLista
        End Function

        Function TrazINutriPessoa_BD_PorID(ByVal vInfoNutri As ClInfoNutriPessoaItem, ByVal strConection As String) As ClInfoNutriPessoaItem

            Dim infoNutriITEM As New ClInfoNutriPessoaItem
            Dim conexao As New NpgsqlConnection(strConection)

            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO ao Abrir conexão em ""InfoNutri Pessoa ITEM:: TrazInfoNutriPessoa_BD_PorID"":: " & ex.Message)
                Return infoNutriITEM
            End Try

            Dim dr As NpgsqlDataReader
            Dim com As NpgsqlCommand
            Dim consulta As New StringBuilder

            consulta.Append("SELECT inpi_id, inp_id, inpi_servicoid, inpi_serviconome, inpi_produtoid, inpi_produtodescricao ")
            consulta.Append("FROM infonutri_pessoa_itens WHERE inpi_id = @inpi_id ")
            com = New NpgsqlCommand(consulta.ToString, conexao)
            com.Parameters.Add("@inpi_id", vInfoNutri.inpi_id)

            dr = com.ExecuteReader

            While dr.Read

                infoNutriITEM.zeraValores()
                With infoNutriITEM

                    .inpi_id = dr(0)
                    .inp_id = dr(1)
                    .inpi_servicoid = dr(2)
                    .inpi_serviconome = dr(3).ToString
                    .inpi_produtoid = dr(4)
                    .inpi_produtodescricao = dr(5).ToString
                End With
            End While
            dr.Close()
            com.Dispose()
            conexao.Close()
            com.Dispose()

            Return infoNutriITEM
        End Function

        Function TrazINutriPessoa_LISTA_PorID(ByVal vInfoNutri As ClInfoNutriPessoaItem, ByVal lista As List(Of ClInfoNutriPessoaItem)) As ClInfoNutriPessoaItem
            Dim novoInfoNutri As New ClInfoNutriPessoaItem
            Dim Id As Int64 = vInfoNutri.inp_id
            novoInfoNutri = lista.Find(Function(i As ClInfoNutriPessoaItem) i.inp_id = Id)
            Return novoInfoNutri
        End Function

        Function TrazINPessoaItem_LISTA_PorIDInfoNutri(ByVal vInfoNutri As ClInfoNutriPessoa, ByVal lista As List(Of ClInfoNutriPessoaItem)) As List(Of ClInfoNutriPessoaItem)
            Dim novaLista As New List(Of ClInfoNutriPessoaItem)
            Dim Item As New ClInfoNutriPessoaItem

            For Each i As ClInfoNutriPessoaItem In lista

                If i.inp_id = vInfoNutri.inp_id Then

                    Item.zeraValores()
                    Item.setaValores(i)
                    novaLista.Add(New ClInfoNutriPessoaItem(Item))
                End If
            Next

            Return novaLista
        End Function

    End Class

End Class
