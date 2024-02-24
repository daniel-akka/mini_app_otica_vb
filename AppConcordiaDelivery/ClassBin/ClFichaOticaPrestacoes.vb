Public Class ClFichaOticaPrestacoes
    Inherits ClFichaOticaPrestacoesDAO

    Public Property fpp_id As Int64
    Public Property fpp_ficha_id As Int64
    Public Property fpp_data As Date
    Public Property fpp_prestacao As String
    Public Property fpp_valor As Double
    Public Property fpp_visto As String

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vFichaId As Int64 = 0, Optional ByVal vData As Date = Nothing, _
            Optional ByVal vPrestacao As String = "", Optional ByVal vValor As Double = 0, Optional ByVal vVisto As String = "")

        Me.fpp_id = vId : Me.fpp_ficha_id = vFichaId : Me.fpp_data = vData : Me.fpp_prestacao = vPrestacao
        Me.fpp_valor = vValor : Me.fpp_visto = vVisto
    End Sub

    Sub New(ByVal vFichaOticaPrestacoes As ClFichaOticaPrestacoes)

        If Not IsNothing(vFichaOticaPrestacoes) Then

            With Me

                .fpp_id = vFichaOticaPrestacoes.fpp_id
                .fpp_ficha_id = vFichaOticaPrestacoes.fpp_ficha_id
                .fpp_data = vFichaOticaPrestacoes.fpp_data
                .fpp_prestacao = vFichaOticaPrestacoes.fpp_prestacao
                .fpp_valor = vFichaOticaPrestacoes.fpp_valor
                .fpp_visto = vFichaOticaPrestacoes.fpp_visto
            End With
        Else
            Me.ZeraValores()
        End If
    End Sub

    Sub SetaValores(ByVal vFichaOticaPrestacoes As ClFichaOticaPrestacoes)

        If Not IsNothing(vFichaOticaPrestacoes) Then

            With Me

                .fpp_id = vFichaOticaPrestacoes.fpp_id
                .fpp_ficha_id = vFichaOticaPrestacoes.fpp_ficha_id
                .fpp_data = vFichaOticaPrestacoes.fpp_data
                .fpp_prestacao = vFichaOticaPrestacoes.fpp_prestacao
                .fpp_valor = vFichaOticaPrestacoes.fpp_valor
                .fpp_visto = vFichaOticaPrestacoes.fpp_visto
            End With
        Else
            Me.ZeraValores()
        End If
    End Sub

    Sub ZeraValores()

        With Me

            .fpp_id = 0
            .fpp_ficha_id = 0
            .fpp_data = Nothing
            .fpp_prestacao = ""
            .fpp_valor = 0
            .fpp_visto = ""
        End With
    End Sub

End Class
