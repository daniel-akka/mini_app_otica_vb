Imports Npgsql
Public Class ClIMC

    Public Property imc_id As Integer
    Public Property imc_minimo As Double
    Public Property imc_maximo As Double
    Public Property imc_classificacao As String
    Public Property imc_problemas As String
    Public DAO As ImcBancoDados

    Sub New()

        With Me

            Me.imc_id = 0
            Me.imc_minimo = 0
            Me.imc_maximo = 0
            Me.imc_classificacao = 0
            Me.imc_problemas = 0
            Me.DAO = New ImcBancoDados
        End With
    End Sub

    Sub New(imc As ClIMC)

        With Me

            Me.imc_id = imc.imc_id
            Me.imc_minimo = imc.imc_minimo
            Me.imc_maximo = imc.imc_maximo
            Me.imc_classificacao = imc.imc_classificacao
            Me.imc_problemas = imc.imc_problemas
            Me.DAO = New ImcBancoDados
        End With
    End Sub

    Sub setaValores(imc As ClIMC)

        With Me

            Me.imc_id = imc.imc_id
            Me.imc_minimo = imc.imc_minimo
            Me.imc_maximo = imc.imc_maximo
            Me.imc_classificacao = imc.imc_classificacao
            Me.imc_problemas = imc.imc_problemas
        End With
    End Sub

    Sub zeraValores()

        With Me

            Me.imc_id = 0
            Me.imc_minimo = 0
            Me.imc_maximo = 0
            Me.imc_classificacao = 0
            Me.imc_problemas = 0
        End With
    End Sub

    Function trazPadraoNumerico(resultadoIMC As Double, vIMC As ClIMC) As Int16

        If resultadoIMC < 16.9 Then Return 1
        If (resultadoIMC >= 17) And (resultadoIMC <= 18.4) Then Return 2
        If (resultadoIMC >= 18.5) And (resultadoIMC <= 24.9) Then Return 3
        If (resultadoIMC >= 25) And (resultadoIMC <= 29.9) Then Return 4
        If (resultadoIMC >= 30) And (resultadoIMC <= 34.9) Then Return 5
        If (resultadoIMC >= 35) And (resultadoIMC <= 40) Then Return 6
        If (resultadoIMC >= 40) Then Return 7

        Return 0
    End Function

    Class ImcBancoDados

        Sub New()
        End Sub

        Function trazListaIMC_BD(ByVal strConection As String) As List(Of ClIMC)

            Dim novaLista As New List(Of ClIMC)
            Dim Imc As New ClIMC
            Dim conexao As New NpgsqlConnection(strConection)
            Dim dr As NpgsqlDataReader
            Dim com As NpgsqlCommand
            Dim consulta As String = ""

            Try
                conexao.Open()
            Catch ex As Exception
                MsgBox("ERRO ao Abrir conexão em ""IMC:: trazListaIMC_BD"":: " & ex.Message)
                Return novaLista
            End Try

            consulta = "SELECT imc_id, imc_minimo, imc_maximo, imc_classificacao, imc_problemas FROM imc"
            com = New NpgsqlCommand(consulta, conexao)
            dr = com.ExecuteReader

            While dr.Read

                Imc.zeraValores()
                With Imc

                    .imc_id = dr(0)
                    .imc_minimo = dr(1)
                    .imc_maximo = dr(2)
                    .imc_classificacao = dr(3).ToString
                    .imc_problemas = dr(4).ToString
                End With
                novaLista.Add(New ClIMC(Imc))

            End While
            dr.Close()
            com.Dispose()
            conexao.Close()
            com.Dispose()

            Return novaLista
        End Function

        Function trazIMC_DaListaPorID(ByVal vImc As ClIMC, ByVal lista As List(Of ClIMC)) As ClIMC
            Dim novoIMC As New ClIMC
            Dim Id As Integer = vImc.imc_id
            novoIMC = lista.Find(Function(i As ClIMC) i.imc_id = Id)

            Return novoIMC
        End Function

        Function trazIMC_DaListaPorIMC(ByVal resultadoIMC As Double, ByVal lista As List(Of ClIMC)) As ClIMC
            Dim novoIMC As New ClIMC

            For Each i As ClIMC In lista

                If resultadoIMC >= i.imc_minimo AndAlso resultadoIMC <= i.imc_maximo Then
                    novoIMC.setaValores(i)
                    Exit For
                End If
            Next

            Return novoIMC
        End Function

    End Class

End Class
