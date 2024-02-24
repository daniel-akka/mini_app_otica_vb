Public Class ClRelatorioPadraoSTR

    Public Property coluna1 As String
    Public Property coluna2 As String
    Public Property coluna3 As String
    Public Property coluna4 As String
    Public Property coluna5 As String
    Public Property coluna6 As String
    Public Property coluna7 As String
    Public Property coluna8 As String
    Public Property coluna9 As String
    Public Property coluna10 As String
    Public Property coluna11 As String

    Sub New()

        With Me
            .coluna1 = ""
            .coluna2 = ""
            .coluna3 = ""
            .coluna4 = ""
            .coluna5 = ""
            .coluna6 = ""
            .coluna7 = ""
            .coluna8 = ""
            .coluna9 = ""
            .coluna10 = ""
            .coluna11 = ""
        End With
    End Sub

    Sub New(rel As ClRelatorioPadraoSTR)

        With Me
            .coluna1 = rel.coluna1
            .coluna2 = rel.coluna2
            .coluna3 = rel.coluna3
            .coluna4 = rel.coluna4
            .coluna5 = rel.coluna5
            .coluna6 = rel.coluna6
            .coluna7 = rel.coluna7
            .coluna8 = rel.coluna8
            .coluna9 = rel.coluna9
            .coluna10 = rel.coluna10
            .coluna11 = rel.coluna11
        End With

    End Sub


    Sub setaValores(rlPadrao As ClRelatorioPadraoSTR)

        With Me
            .coluna1 = rlPadrao.coluna1
            .coluna2 = rlPadrao.coluna2
            .coluna3 = rlPadrao.coluna3
            .coluna4 = rlPadrao.coluna4
            .coluna5 = rlPadrao.coluna5
            .coluna6 = rlPadrao.coluna6
            .coluna7 = rlPadrao.coluna7
            .coluna8 = rlPadrao.coluna8
            .coluna9 = rlPadrao.coluna9
            .coluna10 = rlPadrao.coluna10
            .coluna11 = rlPadrao.coluna11
        End With

    End Sub

    Sub zeraValores()

        With Me
            .coluna1 = ""
            .coluna2 = ""
            .coluna3 = ""
            .coluna4 = ""
            .coluna5 = ""
            .coluna6 = ""
            .coluna7 = ""
            .coluna8 = ""
            .coluna9 = ""
            .coluna10 = ""
            .coluna11 = ""
        End With
    End Sub


End Class
