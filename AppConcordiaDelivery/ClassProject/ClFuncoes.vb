Imports Npgsql
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Math
Imports System.DateTime
Imports Microsoft.VisualBasic

Public Class ClFuncoes



    Private dadosArray() As String = {"111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", _
                                              "555.555.555-55", "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99"}
    Private Const msgErro As String = "Dados Inválidos"
    Private bValida As Boolean
    Private sCPF As String
    Private sCNPJ As String

    Public Sub AlteraConfigBD_Arquivo(ByVal caminhoArqConfigBD As String, ByVal IP As String, ByVal nomeBD As String, ByVal usuBD As String, _
                                      ByVal senhaBD As String, ByVal portaBD As String)
        Dim fs As New FileStream(caminhoArqConfigBD, FileMode.Truncate, FileAccess.ReadWrite)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(IP & vbNewLine & nomeBD & vbNewLine & usuBD & vbNewLine & senhaBD & vbNewLine & portaBD)
        sr.Close()
    End Sub

    Public Function trazSincronizaBD(ByVal mac As String, ByVal conexao As String) As Boolean

        Dim sincroniza As Boolean = False
        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return False

        End Try

        Dim sql As String = ""
        Dim cmd As NpgsqlCommand
        Dim dr As NpgsqlDataReader

        sql = "SELECT s_sincroniza FROM sincronizacao WHERE s_mac = '" & mac & "'"
        cmd = New NpgsqlCommand(sql, oConn)
        Try
            dr = cmd.ExecuteReader

            If dr.HasRows Then

                While dr.Read
                    sincroniza = dr(0)
                End While
                dr.Close()

            Else
                dr.Close()

                sql = "INSERT INTO sincronizacao VALUES (DEFAULT, '" & mac & "', True)"
                cmd = New NpgsqlCommand(sql, oConn)
                Try
                    cmd.ExecuteNonQuery()
                    sincroniza = True
                Catch ex As Exception
                    MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
                    sincroniza = False
                End Try


            End If
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        End Try

        cmd = Nothing : sql = Nothing : dr = Nothing

        oConn.Close() : oConn = Nothing


        Return sincroniza
    End Function

    Public Sub atualizaSincronizacaoBD(ByVal sincroniza As Boolean, ByVal conexao As String)

        Dim oConn As NpgsqlConnection = New NpgsqlConnection(conexao)

        Try
            oConn.Open()
        Catch ex As Exception
            MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, "METROSYS")
            Return
        End Try

        Dim sql As String = ""
        Dim cmd As NpgsqlCommand

        sql = "UPDATE sincronizacao SET s_sincroniza = " & sincroniza
        cmd = New NpgsqlCommand(sql, oConn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Critical)
        End Try

        cmd = Nothing : sql = Nothing
        oConn.Close() : oConn = Nothing


    End Sub

    Public Function trazLinhaArquivoTXT(ByVal caminhoArqConfigBD As String, ByVal NumeroLinha As Int64) As String
        Dim sr As StreamReader = New StreamReader(caminhoArqConfigBD, System.Text.Encoding.Default)
        Dim mResultado, mLinha As String
        Dim mContLinha As Integer = 0
        mResultado = "" : mLinha = ""
        mResultado = ""

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            mContLinha += 1
            If mContLinha = NumeroLinha Then
                mResultado = mLinha
                Exit Do
            End If
            
        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()

        Return mResultado
    End Function


    Public Function trazIpServidorBD(ByVal caminhoArqConfigBD As String) As String
        Dim sr As StreamReader = New StreamReader(caminhoArqConfigBD, System.Text.Encoding.Default)
        Dim mIP, mLinha As String
        mIP = "" : mLinha = ""

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            mIP = mLinha '   Por padrão o Endereço IP do Banco DEVE ficar na primeira linha
            Exit Do
        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()

        Return mIP
    End Function

    Public Function trazNomeBancoServidorBD(ByVal caminhoArqConfigBD As String) As String
        Dim sr As StreamReader = New StreamReader(caminhoArqConfigBD, System.Text.Encoding.Default)
        Dim mBanco, mLinha As String
        Dim mContLinha As Integer = 0
        mBanco = "" : mLinha = ""

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            mContLinha += 1
            If mContLinha = 2 Then mBanco = mLinha '   Por padrão o Nome do Banco DEVE ficar na Segunda Linha
        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()

        Return mBanco
    End Function

    Public Function trazIndexUF(ByVal mUF As String, ByVal mCboUF As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboUF.Items.Count - 1

            If mUF.Equals(Trim(mCboUF.Items.Item(index).ToString.Substring(0, 2))) Then

                indiceCfop = index
                Exit For
            End If
        Next


        Return indiceCfop
    End Function

    Public Function trazIndexMUN(ByVal mMUN As String, ByVal mCboMUN As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboMUN.Items.Count - 1

            If mMUN.Equals(Trim(mCboMUN.Items.Item(index).ToString)) Then

                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
    End Function

    Public Sub preenchComboBoxUF(cboUF As ComboBox)

        cboUF.Items.Add("AC") : cboUF.Items.Add("AL") : cboUF.Items.Add("AP")
        cboUF.Items.Add("AM") : cboUF.Items.Add("BA") : cboUF.Items.Add("CE")
        cboUF.Items.Add("DF") : cboUF.Items.Add("ES") : cboUF.Items.Add("EX")
        cboUF.Items.Add("GO") : cboUF.Items.Add("MA") : cboUF.Items.Add("MT")
        cboUF.Items.Add("MS") : cboUF.Items.Add("MG") : cboUF.Items.Add("PA")
        cboUF.Items.Add("PB") : cboUF.Items.Add("PE") : cboUF.Items.Add("PI")
        cboUF.Items.Add("RJ") : cboUF.Items.Add("RN") : cboUF.Items.Add("RS")
        cboUF.Items.Add("RO") : cboUF.Items.Add("RR") : cboUF.Items.Add("SC")
        cboUF.Items.Add("SP") : cboUF.Items.Add("SE") : cboUF.Items.Add("TO")
        cboUF.Items.Add("PR")

    End Sub

    Public Sub preenchComboBoxUFPesquisa(cboUF As ComboBox)

        cboUF.Items.Add("< TODOS >")
        cboUF.Items.Add("AC") : cboUF.Items.Add("AL") : cboUF.Items.Add("AP")
        cboUF.Items.Add("AM") : cboUF.Items.Add("BA") : cboUF.Items.Add("CE")
        cboUF.Items.Add("DF") : cboUF.Items.Add("ES") : cboUF.Items.Add("EX")
        cboUF.Items.Add("GO") : cboUF.Items.Add("MA") : cboUF.Items.Add("MT")
        cboUF.Items.Add("MS") : cboUF.Items.Add("MG") : cboUF.Items.Add("PA")
        cboUF.Items.Add("PB") : cboUF.Items.Add("PE") : cboUF.Items.Add("PI")
        cboUF.Items.Add("RJ") : cboUF.Items.Add("RN") : cboUF.Items.Add("RS")
        cboUF.Items.Add("RO") : cboUF.Items.Add("RR") : cboUF.Items.Add("SC")
        cboUF.Items.Add("SP") : cboUF.Items.Add("SE") : cboUF.Items.Add("TO")
        cboUF.Items.Add("PR")

    End Sub

    Public Function validaHoraMask(HoraTextMask As String) As Boolean

        Dim mstr As String = Trim(HoraTextMask.Replace(":", ""))

        If mstr.Equals("") Then Return True

        If mstr.Length <> 4 Then
            Return False
        End If

        If IsNumeric(mstr.Substring(0, 2)) = False Then
            Return False
        End If

        If IsNumeric(mstr.Substring(2, 2)) = False Then
            Return False
        End If

        If CInt(mstr.Substring(0, 2)) < 0 OrElse CInt(mstr.Substring(0, 2)) > 23 Then
            Return False
        End If

        If CInt(mstr.Substring(2, 2)) < 0 OrElse CInt(mstr.Substring(2, 2)) > 59 Then
            Return False
        End If

        Return True
    End Function

    Public Function criptografaSenha(ByVal senha As String) As String

        Dim Msenha(10), Xsenha(10) As Integer
        Dim senhaCripto As String = ""

        Msenha(0) = 154 : Msenha(1) = 157 : Msenha(2) = 181 : Msenha(3) = 165 : Msenha(4) = 216
        Msenha(5) = 219 : Msenha(6) = 175 : Msenha(7) = 208 : Msenha(8) = 249 : Msenha(9) = 243

        Dim x As Integer
        For x = 1 To Len(senha)

            Xsenha(x - 1) = Asc(Mid(senha, x, 1)) + Msenha(x - 1)
            senhaCripto = RTrim(senhaCripto) & Convert.ToChar(Xsenha(x - 1))

        Next



        Return senhaCripto
    End Function

    Public Function validaHoraMaskTurno(HoraTextMask As String, Turno As String) As Boolean

        Dim mstr As String = Trim(HoraTextMask.Replace(":", ""))
        Dim mInt As Integer = 0

        If mstr.Equals("") Then Return True

        If mstr.Length <> 4 Then
            Return False
        End If

        If IsNumeric(mstr.Substring(0, 2)) = False Then
            Return False
        End If

        If IsNumeric(mstr.Substring(2, 2)) = False Then
            Return False
        End If

        If CInt(mstr.Substring(0, 2)) < 0 OrElse CInt(mstr.Substring(0, 2)) > 23 Then
            Return False
        End If

        If CInt(mstr.Substring(2, 2)) < 0 OrElse CInt(mstr.Substring(2, 2)) > 59 Then
            Return False
        End If

        mInt = CInt(mstr.Substring(0, 2))
        Select Case Turno
            Case "M"

                If mInt < 1 Then
                    Return False
                End If

                If mInt >= 12 Then
                    Return False
                End If

            Case "T"

                If mInt < 12 Then
                    If mInt < 1 OrElse mInt >= 6 Then
                        Return False
                    End If
                End If

                If mInt > 12 Then

                    If mInt < 12 OrElse mInt >= 18 Then
                        Return False
                    End If
                End If
                

            Case "N"

                If mInt >= 1 Then

                    If mInt < 13 Then

                        If mInt < 6 OrElse mInt > 12 Then
                            Return False
                        End If
                    End If

                    If mInt > 13 Then

                        If mInt < 18 OrElse mInt > 23 Then
                            Return False
                        End If
                    End If
                   
                End If
                

            Case Else
                Return False

        End Select

        Return True
    End Function

    Public Function EnderecoMac() As String

        'Dim end_Mac As String = ""
        'Dim mc As System.Management.ManagementClass
        'Dim mo As System.Management.ManagementBaseObject

        'mc = New Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        'Dim moc As Management.ManagementObjectCollection = mc.GetInstances

        Dim mc As New System.Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As System.Management.ManagementObjectCollection = mc.GetInstances()
        Dim end_Mac As String = [String].Empty
        For Each mo As System.Management.ManagementObject In moc

            If end_Mac = [String].Empty Then
                ' only return MAC Address from first card
                If CBool(mo("IPEnabled")) = True Then
                    end_Mac = Replace(mo("MacAddress").ToString(), ":", "-")
                End If
            End If
            mo.Dispose()
        Next


        Return end_Mac

    End Function

    Public Function Mostra_Extenso(ByVal nValor As Decimal) As String

        If nValor <= 0 Or nValor > 9999999.99 Then
            Mostra_Extenso = ""
            Exit Function
        End If

        'Declara as variáveis da função
        Dim nContador, nTamanho As Integer
        Dim cValor, cParte, cFinal As String
        Dim aGrupo(4), aTexto(4) As String

        'Define matrizes com extensos parciais
        Dim aUnid(19) As String
        aUnid(1) = "UM " : aUnid(2) = "DOIS " : aUnid(3) = "TRES "
        aUnid(4) = "QUATRO " : aUnid(5) = "CINCO " : aUnid(6) = "SEIS "
        aUnid(7) = "SETE " : aUnid(8) = "OITO " : aUnid(9) = "NOVE "
        aUnid(10) = "DEZ " : aUnid(11) = "ONZE " : aUnid(12) = "DOZE "
        aUnid(13) = "TREZE " : aUnid(14) = "QUATORZE " : aUnid(15) = "QUINZE "
        aUnid(16) = "DEZESSEIS " : aUnid(17) = "DEZESSETE " : aUnid(18) = "DEZOITO "
        aUnid(19) = "DEZENOVE "

        Dim aDezena(9) As String
        aDezena(1) = "DEZ " : aDezena(2) = "VINTE " : aDezena(3) = "TRINTA "
        aDezena(4) = "QUARENTA " : aDezena(5) = "CINQUENTA "
        aDezena(6) = "SESSENTA " : aDezena(7) = "SETENTA " : aDezena(8) = "OITENTA "
        aDezena(9) = "NOVENTA "

        Dim aCentena(9) As String
        aCentena(1) = "CENTO " : aCentena(2) = "DUZENTOS "
        aCentena(3) = "TREZENTOS " : aCentena(4) = "QUATROCENTOS "
        aCentena(5) = "QUINHENTOS " : aCentena(6) = "SEISCENTOS "
        aCentena(7) = "SETECENTOS " : aCentena(8) = "OITOCENTOS "
        aCentena(9) = "NOVECENTOS "

        'Divide o valor em vários grupos
        cValor = Format(nValor, "0000000000.00")
        aGrupo(1) = Mid$(cValor, 2, 3)
        aGrupo(2) = Mid$(cValor, 5, 3)
        aGrupo(3) = Mid$(cValor, 8, 3)
        aGrupo(4) = "0" + Mid$(cValor, 12, 2)

        'Processa cada grupo
        For nContador = 1 To 4
            cParte = aGrupo(nContador)
            nTamanho = Switch(Val(cParte) < 10, 1, Val(cParte) < 100, 2, Val(cParte) < 1000, 3)
            If nTamanho = 3 Then
                If Right$(cParte, 2) <> "00" Then
                    aTexto(nContador) = aTexto(nContador) + aCentena(Left(cParte, 1)) + "E "
                    nTamanho = 2
                Else
                    aTexto(nContador) = aTexto(nContador) + IIf(Left$(cParte, 1) = "1", "CEM ", aCentena(Left(cParte, 1)))
                End If
            End If
            If nTamanho = 2 Then
                If Val(Right(cParte, 2)) < 20 Then
                    aTexto(nContador) = aTexto(nContador) + aUnid(Right(cParte, 2))
                Else
                    aTexto(nContador) = aTexto(nContador) + aDezena(Mid(cParte, 2, 1))
                    If Right$(cParte, 1) <> "0" Then
                        aTexto(nContador) = aTexto(nContador) + "E "
                        nTamanho = 1
                    End If
                End If
            End If
            If nTamanho = 1 Then
                aTexto(nContador) = aTexto(nContador) + aUnid(Right(cParte, 1))
            End If
        Next

        'Gera o formato final do texto
        If Val(aGrupo(1) + aGrupo(2) + aGrupo(3)) = 0 And Val(aGrupo(4)) <> 0 Then
            cFinal = aTexto(4) + IIf(Val(aGrupo(4)) = 1, "CENTAVO", "CENTAVOS")
        Else
            cFinal = ""
            cFinal = cFinal + IIf(Val(aGrupo(1)) <> 0, aTexto(1) + IIf(Val(aGrupo(1)) > 1, "MILHÕES ", "MILHÃO "), "")
            If Val(aGrupo(2) + aGrupo(3)) = 0 Then
                cFinal = cFinal + "DE "
            Else
                cFinal = cFinal + IIf(Val(aGrupo(2)) <> 0, aTexto(2) + "MIL ", "")
            End If
            cFinal = cFinal + aTexto(3) + IIf(Val(aGrupo(1) + aGrupo(2) + aGrupo(3)) = 1, "REAL ", "REAIS ")
            cFinal = cFinal + IIf(Val(aGrupo(4)) <> 0, "E " + aTexto(4) + IIf(Val(aGrupo(4)) = 1, "CENTAVO", "CENTAVOS"), "")
        End If

        Mostra_Extenso = cFinal

    End Function

    Public Function TrazCliente(ByRef Cliente As ClCliente, ByVal strConection As String) As Boolean

        Dim conexao As New NpgsqlConnection(strConection)
        Dim dr As NpgsqlDataReader
        Dim com As NpgsqlCommand
        Dim consulta As String = ""

        Try
            conexao.Open()
        Catch ex As Exception
            MsgBox("ERRO ao Abrir conexão em ""ClienteDAO:TrazCliente"":: " & ex.Message)
            Return False
        End Try

        consulta = "SELECT cid, cnome, cestado, ccidade, cendereco, creferencia, cinativo, cdatanascimento, ctelefone, "
        consulta += "cbairro, cdataservico, cdiames, ccpf, ccep, cemail FROM cliente WHERE cid = " & Cliente.cid
        com = New NpgsqlCommand(consulta, conexao)
        dr = com.ExecuteReader

        While dr.Read

            Cliente.cid = dr(0)
            Cliente.cnome = dr(1).ToString
            Cliente.cestado = dr(2).ToString
            Cliente.ccidade = dr(3).ToString
            Cliente.cendereco = dr(4).ToString
            Cliente.creferencia = dr(5).ToString
            Cliente.cinativo = dr(6)
            Cliente.cdatanascimento = ""
            If IsDate(dr(7)) Then Cliente.cdatanascimento = dr(7)
            Cliente.ctelefone = dr(8).ToString
            Cliente.cbairro = dr(9).ToString
            Cliente.cdataservico = ""
            If IsDate(dr(10)) Then Cliente.cdataservico = dr(10)
            Cliente.cdiames = dr(11).ToString
            Cliente.cCpfCnpj = dr(12).ToString
            Cliente.ccep = dr(13).ToString
            Cliente.cemail = dr(14).ToString

        End While
        dr.Close()
        com.Dispose()
        conexao.Close()
        com.Dispose()

        Return True
    End Function

    Public Function ValidaDiaMesSTR(ByVal vDiaMes As String) As String

        Dim mDiaMes As String = ""
        mDiaMes = Trim(RemoverCaracter2(vDiaMes))

        If mDiaMes.Equals("") Then
            Return ""
        ElseIf mDiaMes.Length <> 4 Then
            Return "Informe uma Data: Dia/Mês Válida!"
        Else
            If ValidaDiaMesBool(mDiaMes) = False Then Return "Informe uma Data: Dia/Mês Válida!"
        End If

        Return ""
    End Function

    Public Function ValidaDiaMesBool(ByVal vDiaMes As String) As Boolean

        Dim ano As Int16 = Date.Now.Year
        Dim mes As Int16 = CInt(Mid(vDiaMes, 3))
        Dim ultimoDiaDoMes As Int16 = 0
        Try
            ultimoDiaDoMes = DaysInMonth(ano, mes)
        Catch ex As Exception
        End Try
        Dim dia As Int16 = CInt(Mid(vDiaMes, 1, 2))

        If mes < 1 OrElse mes > 12 Then Return False
        If dia < 1 OrElse dia > ultimoDiaDoMes Then Return False


        Return True
    End Function

    Public Function CentralizaSTR(ByVal str As String, ByVal tamanho As Integer) As String

        Dim espacosEsq, espacosDir As Integer
        Dim tamanhoDiv As Integer
        If str.Length > tamanho Then Return str
        tamanhoDiv = tamanho - str.Length
        If tamanhoDiv > 1 Then
            espacosDir = tamanhoDiv \ 2
            espacosEsq = tamanhoDiv - espacosDir
        End If
        str = Space(espacosEsq) & str & Space(espacosDir)

        Return str
    End Function

    Public Function EsquerdaSTR(ByVal str As String, ByVal tamanho As Integer) As String

        Dim espacosEsq As Integer
        Dim tamanhoDiv As Integer
        If str.Length > tamanho Then Return Mid(str, 1, tamanho)
        tamanhoDiv = tamanho - str.Length
        If tamanhoDiv > 1 Then
            espacosEsq = tamanhoDiv
        End If
        str += Space(espacosEsq)

        Return str
    End Function

    Public Function DireitaSTR(ByVal str As String, ByVal tamanho As Integer) As String

        Dim espacosDir As Integer
        Dim tamanhoDiv As Integer
        If str.Length > tamanho Then Return Mid(str, 1, tamanho)
        tamanhoDiv = tamanho - str.Length
        If tamanhoDiv > 1 Then
            espacosDir = tamanhoDiv
        End If
        str = Space(espacosDir) & str

        Return str
    End Function

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
        Temp = ""
        Remover = "()*/-+.,\"
        Temp = Valor
        If Temp.Length = 0 Then Return Trim(Temp)
        For i = 1 To Remover.Length
            Temp = Replace(Temp, Mid(Remover, i, 1), "")
        Next

        Return Trim(Temp)
    End Function

    Public Function ValidaCPF(ByVal CPF As String) As Boolean

        Dim i, x, n1, n2 As Integer

        CPF = CPF.Trim
        For i = 0 To dadosArray.Length - 1
            If CPF.Length <> 14 Or dadosArray(i).Equals(CPF) Then
                Return False
            End If
        Next
        'remove a maskara
        CPF = CPF.Substring(0, 3) + CPF.Substring(4, 3) + CPF.Substring(8, 3) + CPF.Substring(12)
        For x = 0 To 1
            n1 = 0
            For i = 0 To 8 + x
                n1 = n1 + Val(CPF.Substring(i, 1)) * (10 + x - i)
            Next
            n2 = 11 - (n1 - (Int(n1 / 11) * 11))
            If n2 = 10 Or n2 = 11 Then n2 = 0

            If n2 <> Val(CPF.Substring(9 + x, 1)) Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Function ValidaCPF_SoNumeros(ByVal CPF As String) As Boolean

        Dim i, x, n1, n2 As Integer

        CPF = CPF.Trim
        For i = 0 To dadosArray.Length - 1
            If CPF.Length <> 11 Or dadosArray(i).Equals(CPF) Then
                Return False
            End If
        Next

        For x = 0 To 1
            n1 = 0
            For i = 0 To 8 + x
                n1 = n1 + Val(CPF.Substring(i, 1)) * (10 + x - i)
            Next
            n2 = 11 - (n1 - (Int(n1 / 11) * 11))
            If n2 = 10 Or n2 = 11 Then n2 = 0

            If n2 <> Val(CPF.Substring(9 + x, 1)) Then
                Return False
            End If
        Next

        Return True
    End Function

    Public Function ValidaCNPJ(ByVal CNPJ As String) As Boolean

        Dim i As Integer
        Dim valida As Boolean
        CNPJ = CNPJ.Trim

        For i = 0 To dadosArray.Length - 1
            If CNPJ.Length <> 18 Or dadosArray(i).Equals(CNPJ) Then
                Return False
            End If
        Next

        'remove a maskara
        CNPJ = CNPJ.Substring(0, 2) + CNPJ.Substring(3, 3) + CNPJ.Substring(7, 3) + CNPJ.Substring(11, 4) + CNPJ.Substring(16)
        valida = efetivaValidacao(CNPJ)

        If valida Then
            ValidaCNPJ = True
        Else
            ValidaCNPJ = False
        End If

    End Function

    Private Function efetivaValidacao(ByVal cnpj As String)
        Dim Numero(13) As Integer
        Dim soma As Integer
        Dim i As Integer
        Dim valida As Boolean = False
        Dim resultado1 As Integer
        Dim resultado2 As Integer
        For i = 0 To Numero.Length - 1
            Numero(i) = CInt(cnpj.Substring(i, 1))
        Next
        soma = Numero(0) * 5 + Numero(1) * 4 + Numero(2) * 3 + Numero(3) * 2 + Numero(4) * 9 + Numero(5) * 8 + Numero(6) * 7 + _
                   Numero(7) * 6 + Numero(8) * 5 + Numero(9) * 4 + Numero(10) * 3 + Numero(11) * 2
        soma = soma - (11 * (Int(soma / 11)))
        If soma = 0 Or soma = 1 Then
            resultado1 = 0
        Else
            resultado1 = 11 - soma
        End If

        If resultado1 = Numero(12) Then
            soma = Numero(0) * 6 + Numero(1) * 5 + Numero(2) * 4 + Numero(3) * 3 + Numero(4) * 2 + Numero(5) * 9 + Numero(6) * 8 + _
                         Numero(7) * 7 + Numero(8) * 6 + Numero(9) * 5 + Numero(10) * 4 + Numero(11) * 3 + Numero(12) * 2
            soma = soma - (11 * (Int(soma / 11)))
            If soma = 0 Or soma = 1 Then
                resultado2 = 0
            Else
                resultado2 = 11 - soma
            End If
            If resultado2 = Numero(13) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

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

    Public Function trazIndexCboTextoTodo(ByVal mOrigen As String, ByVal mCboOrigen As Object) As Integer
        Dim index As Integer : Dim indiceCfop As Integer = -1
        For index = 0 To mCboOrigen.Items.Count - 1

            If mOrigen.Equals(Trim(mCboOrigen.Items.Item(index).ToString)) Then
                indiceCfop = index
                Exit For
            End If
        Next

        Return indiceCfop
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

    Public Sub removeItemComboBox(ByVal itemRemover As String, ByVal mCboOrigen As ComboBox, ByRef mCboAlteracao As ComboBox)
        Dim index As Integer : Dim indiceCfop As Integer = -1

        mCboAlteracao.AutoCompleteCustomSource.Clear()
        mCboAlteracao.Items.Clear()
        mCboAlteracao.Refresh()

        For Each cbo As String In mCboOrigen.Items
            mCboAlteracao.AutoCompleteCustomSource.Add(cbo.ToString())
            mCboAlteracao.Items.Add(cbo.ToString())
        Next
        mCboAlteracao.Refresh()
        mCboAlteracao.Items.RemoveAt(trazIndexCboTextoTodo(itemRemover, mCboAlteracao))

    End Sub

    Public Sub removeItemComboBoxPesq(ByVal itemRemover As String, ByVal mCboOrigen As ComboBox, ByRef mCboAlteracao As ComboBox)
        Dim index As Integer : Dim indiceCfop As Integer = -1

        mCboAlteracao.AutoCompleteCustomSource.Clear()
        mCboAlteracao.Items.Clear()
        mCboAlteracao.Refresh()

        mCboAlteracao.AutoCompleteCustomSource.Add("")
        mCboAlteracao.Items.Add("")
        For Each cbo As String In mCboOrigen.Items
            mCboAlteracao.AutoCompleteCustomSource.Add(cbo.ToString())
            mCboAlteracao.Items.Add(cbo.ToString())
        Next
        mCboAlteracao.Refresh()
        mCboAlteracao.Items.RemoveAt(trazIndexCboTextoTodo(itemRemover, mCboAlteracao))

    End Sub

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

    Public Function validaEMAIL(ByVal email As String) As Boolean

        'Dim padraoRegex As String = "^[-a-zA-Z0-9._][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\." & _
        '"(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$"

        ''padraoRegex = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9-..]+\\[A-Za-z]{2,4 }$"
        'Dim verifica As New RegularExpressions.Regex(padraoRegex, RegexOptions.IgnorePatternWhitespace)
        'Dim valida As Boolean = True

        ''verifica se foi informado um email
        'If String.IsNullOrEmpty(email) Then
        '    valida = False
        'Else
        '    'usar IsMatch para validar o email
        '    valida = verifica.IsMatch(email)
        'End If

        ''retorna o valor
        'Return valida

        'a@b.c
        Dim EmailValido = True
        Dim I As Byte
        Dim QtdeCaracteres As Byte

        If Len(email) < 5 Then 'Não pode ter menos que 5 caracteres
            EmailValido = False
        ElseIf InStr(email, "@") = 1 Or InStr(email, ".") = 1 Then 'Não pode começar com @ ou .
            EmailValido = False
        ElseIf InStr(email, "@") = Len(email) Or InStr(email, ".") = Len(email) Then 'não pode terminar com @ ou com  .
            EmailValido = False
        ElseIf InStr(email, ".") = 0 Then 'tem que ter pelo menos um .
            EmailValido = False
        ElseIf InStr(email, "..") > 0 Then 'não pode ter dois pontos (ou mais) seguidos
            EmailValido = False
        Else
            'Verificando a quantidade de @ no email
            QtdeCaracteres = 0
            For I = 1 To Len(email)
                If Mid(email, I, 1) = "@" Then
                    QtdeCaracteres = QtdeCaracteres + 1 'Quantidade de @
                End If
            Next
            If QtdeCaracteres <> 1 Then 'Só pode ter um @
                EmailValido = False
            End If
        End If

        If EmailValido = True Then
            'Verificando se tem mais de dois pontos depois do @
            QtdeCaracteres = 0
            For I = InStr(email, "@") To Len(email)
                If Mid(email, I, 1) = "." Then
                    QtdeCaracteres = QtdeCaracteres + 1 'Quantidade de . depois do @
                End If
            Next
            If QtdeCaracteres > 2 Then 'Só pode ter até dois . depois do @
                EmailValido = False
            End If
        End If

        If EmailValido = True Then
            'Verificar se tem somente caracteres válidos
            Dim Letra As String
            For I = 1 To Len(email)
                Letra = Mid(email, I, 1)
                If Not (LCase(Letra) Like "[a-z]" Or Letra = "@" Or Letra = "." Or Letra = "-" Or Letra = "_" Or IsNumeric(Letra)) Then
                    'Tem caracter inválido
                    EmailValido = False
                    Exit For
                End If
            Next
        End If

        Return EmailValido
    End Function

    Public Function validaCEP(ByVal cep As String) As Boolean
        'cria o padrão regex
        Dim padraoRegex As String = "^\d{5}\d{3}$"
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        'variavel boolean para tratar o status
        Dim valida As Boolean = True
        'verifica se o recurso foi fornecido
        If Trim(cep) = "" Then
            'cep invalido
            'valida = False
        Else
            'usa o método IsMatch Method para validar o regex
            valida = verifica.IsMatch(cep, 0)
        End If
        Return valida
    End Function

    Public Function validaTELEFONE_SoNumeros(ByVal telefone As String) As Boolean
        'cria o padrão regex
        '^\d{2}-\d{4}-\d{4}$ 
        Dim padraoRegex As String = "^[0-9]{2}[0-9]{4}[0-9]{4}$"
        'cria o objeto Regex
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        'variavel boolean para tratar o status
        Dim valida As Boolean = True
        telefone = RemoverCaracterTelefone(telefone)
        'verifica se o recurso foi fornecido
        If Trim(telefone) = "" Then
            'telefone invalido
            'valida = False
        Else
            'usa o método IsMatch Method para validar o regex
            valida = verifica.IsMatch(telefone, 0)
        End If
        Return valida
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
