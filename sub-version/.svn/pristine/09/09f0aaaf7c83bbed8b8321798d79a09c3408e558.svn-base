Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Math

Public Class ClFuncoes

    Public Function PreenchComboUF(ByVal cbo_uf As ComboBox) As ComboBox
        cbo_uf.Items.Add("AC") : cbo_uf.Items.Add("AL") : cbo_uf.Items.Add("AP")
        cbo_uf.Items.Add("AM") : cbo_uf.Items.Add("BA") : cbo_uf.Items.Add("CE")
        cbo_uf.Items.Add("DF") : cbo_uf.Items.Add("ES") : cbo_uf.Items.Add("EX")
        cbo_uf.Items.Add("GO") : cbo_uf.Items.Add("MA") : cbo_uf.Items.Add("MT")
        cbo_uf.Items.Add("MS") : cbo_uf.Items.Add("MG") : cbo_uf.Items.Add("PA")
        cbo_uf.Items.Add("PB") : cbo_uf.Items.Add("PE") : cbo_uf.Items.Add("PI")
        cbo_uf.Items.Add("RJ") : cbo_uf.Items.Add("RN") : cbo_uf.Items.Add("RS")
        cbo_uf.Items.Add("RO") : cbo_uf.Items.Add("RR") : cbo_uf.Items.Add("SC")
        cbo_uf.Items.Add("SP") : cbo_uf.Items.Add("SE") : cbo_uf.Items.Add("TO")
        cbo_uf.Items.Add("PR")

        Return cbo_uf
    End Function

    Public Function RemoverCaracterTelefone(ByVal Valor As String) As String
        Dim Remover As String, i As Byte, Temp As String
        Remover = "()*/-+., "
        Temp = Valor
        For i = 1 To Valor.Length
            Temp = Replace(Temp, Mid(Remover, i, 1), "")
        Next
        RemoverCaracterTelefone = Temp
    End Function

    Public Function RemoverCaracter2(ByVal Valor As String) As String
        Dim Remover As String, i As Byte, Temp As String
        Remover = "()*/-+.,\"
        Temp = Valor
        For i = 1 To Remover.Length
            Temp = Replace(Temp, Mid(Remover, i, 1), "")
        Next

        Return Temp
    End Function

    Public Function formataCNPJ_CPF(ByVal cnpj_cpf As String) As String

        Try

            If cnpj_cpf.Length = 14 Then
                cnpj_cpf = Format(Convert.ToInt64(cnpj_cpf), "00\.000\.000\/0000\-00")
            ElseIf cnpj_cpf.Length = 11 Then
                cnpj_cpf = Format(Convert.ToInt64(cnpj_cpf), "000\.000\.000\-00")
            End If
        Catch ex As Exception
        End Try


        Return cnpj_cpf
    End Function

    Public Function formataFone(ByVal fone As String) As String

        Try

            If fone.Length = 10 Then
                fone = Format(Convert.ToInt64(fone), "\(00\) 0000\-0000")
            ElseIf fone.Length = 8 Then
                fone = Format(Convert.ToInt64(fone), "0000\-0000")
            End If
        Catch ex As Exception
        End Try


        Return fone
    End Function

    Public Function repeteCaracteresPagina(ByVal caracter As String, ByVal qtdeRepeticao As Integer) As String
        Dim retorno As String = ""

        For i As Integer = 1 To qtdeRepeticao
            retorno += caracter
        Next

        Return retorno
    End Function

    Public Function SoNumeros(ByVal Keyascii As Short) As Short

        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoNumeros = 0
        Else
            SoNumeros = Keyascii
        End If

        Select Case Keyascii
            Case 8
                SoNumeros = Keyascii
            Case 13
                SoNumeros = Keyascii
            Case 32
                SoNumeros = Keyascii
        End Select

    End Function

    Public Function SoNumerosPonto(ByVal Keyascii As Short) As Short

        If InStr("1234567890.", Chr(Keyascii)) = 0 Then

            SoNumerosPonto = 0

        Else
            SoNumerosPonto = Keyascii
        End If

        Select Case Keyascii
            Case 8
                SoNumerosPonto = Keyascii
            Case 13
                SoNumerosPonto = Keyascii
            Case 32
                SoNumerosPonto = Keyascii
        End Select

    End Function

    Public Function SoNumerosVirgula(ByVal Keyascii As Short) As Short

        If InStr("1234567890,", Chr(Keyascii)) = 0 Then

            SoNumerosVirgula = 0

        Else
            SoNumerosVirgula = Keyascii
        End If

        Select Case Keyascii
            Case 8
                SoNumerosVirgula = Keyascii
            Case 13
                SoNumerosVirgula = Keyascii
            Case 32
                SoNumerosVirgula = Keyascii
        End Select

    End Function

    Public Function SoNumerosVirgulaNegativo(ByVal Keyascii As Short) As Short

        If InStr("1234567890-,", Chr(Keyascii)) = 0 Then

            SoNumerosVirgulaNegativo = 0

        Else
            SoNumerosVirgulaNegativo = Keyascii
        End If

        Select Case Keyascii
            Case 8
                SoNumerosVirgulaNegativo = Keyascii
            Case 13
                SoNumerosVirgulaNegativo = Keyascii
            Case 32
                SoNumerosVirgulaNegativo = Keyascii
        End Select

    End Function

    Public Function SoLetras(ByVal KeyAscii As Integer) As Integer

        'Transformar letras minusculas em Maiúsculas
        KeyAscii = Asc(UCase(Chr(KeyAscii)))

        ' Intercepta um código ASCII recebido e admite somente letras
        If InStr("AÃÁBCÇDEÉÊFGHIÍJKLMNOPQRSTUÚVWXYZ", Chr(KeyAscii)) = 0 Then
            SoLetras = 0
        Else
            SoLetras = KeyAscii
        End If

        ' teclas adicionais permitidas
        If KeyAscii = 8 Then SoLetras = KeyAscii ' Backspace
        If KeyAscii = 13 Then SoLetras = KeyAscii ' Enter
        If KeyAscii = 32 Then SoLetras = KeyAscii ' Espace

    End Function

    Public Function trazIndexCboOrigem(ByVal mOrigen As String, ByVal mCboOrigen As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboOrigen.Items.Count - 1

            If mOrigen.Equals(Trim(mCboOrigen.Items.Item(index).ToString.Substring(0, 1))) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Function trazIndexComboBox(ByVal mBusca As String, ByVal qtdCaracteres As Int16, ByVal mComboBox As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1

        For index = 0 To mComboBox.Items.Count - 1

            If mBusca.Equals(Trim(Mid(mComboBox.Items.Item(index).ToString, 1, qtdCaracteres))) Then
                indiceCfop = index
                Exit For
            End If

        Next

        Return indiceCfop
    End Function

    Public Function trazIndexComboBoxFinal(ByVal mBusca As String, ByVal qtdCaracteres As Int16, ByVal mComboBox As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        Dim qtd As Integer = qtdCaracteres - 1

        For index = 0 To mComboBox.Items.Count - 1

            If (mComboBox.Items.Item(index).ToString.Length - qtd) > 0 Then
                If Trim(mBusca).Equals(Trim(Mid(mComboBox.Items.Item(index).ToString, mComboBox.Items.Item(index).ToString.Length - qtd))) Then

                    indiceCfop = index
                    Exit For

                End If
            End If

        Next

        Return indiceCfop
    End Function

    Public Function LerArquivoSalvo(ByVal arqSaida As String) As String

        'Ler o Arquivo salvo...
        Dim FilePath As String = arqSaida
        Dim arquivoSTR As String = ""

        Try
            Dim MyfileStream As New IO.StreamReader(FilePath)
            arquivoSTR = MyfileStream.ReadToEnd
            MyfileStream.Close() : MyfileStream.Dispose() : MyfileStream = Nothing
        Catch ex As Exception
            arquivoSTR = ""
        End Try


        Return arquivoSTR
    End Function


End Class
