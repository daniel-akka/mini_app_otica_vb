Public Class ClFichaOticaOlho
    Inherits ClFichaOticaOlhoDAO

    Public Property foo_id As Int64
    Public Property foo_ficha_id As Int64
    Public Property foo_produto_id As Int64
    Public Property foo_produto_nome As String
    Public Property foo_olho As String
    Public Property foo_distancia As String
    Public Property foo_esf As String
    Public Property foo_cil As String
    Public Property foo_eix As String
    Public Property foo_dnp As String

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vFichaId As Int64 = 0, Optional ByVal vProdutoId As Int64 = 0, _
            Optional ByVal vProdutoNome As String = "", Optional ByVal vOlho As String = "", Optional ByVal vDistancia As String = "", _
            Optional ByVal vEsf As String = "", Optional ByVal vCil As String = "", Optional ByVal vEix As String = "", _
            Optional ByVal vDnp As String = "")

        Me.foo_id = vId : Me.foo_ficha_id = vFichaId : Me.foo_produto_id = vProdutoId : Me.foo_produto_nome = vProdutoNome
        Me.foo_olho = vOlho : Me.foo_distancia = vDistancia : Me.foo_esf = vEsf : Me.foo_cil = vCil : Me.foo_eix = vEix : Me.foo_dnp = vDnp
    End Sub

    Sub New(ByVal vFichaOticaOlho As ClFichaOticaOlho)

        If Not IsNothing(vFichaOticaOlho) Then

            With Me

                .foo_id = vFichaOticaOlho.foo_ficha_id
                .foo_ficha_id = vFichaOticaOlho.foo_ficha_id
                .foo_produto_id = vFichaOticaOlho.foo_produto_id
                .foo_produto_nome = vFichaOticaOlho.foo_produto_nome
                .foo_olho = vFichaOticaOlho.foo_olho
                .foo_distancia = vFichaOticaOlho.foo_distancia
                .foo_esf = vFichaOticaOlho.foo_esf
                .foo_cil = vFichaOticaOlho.foo_cil
                .foo_eix = vFichaOticaOlho.foo_eix
                .foo_dnp = vFichaOticaOlho.foo_dnp
            End With
        Else
            Me.ZeraValores()
        End If
    End Sub

    Sub SetaValores(ByVal vFichaOticaOlho As ClFichaOticaOlho)

        If Not IsNothing(vFichaOticaOlho) Then

            With Me

                .foo_id = vFichaOticaOlho.foo_ficha_id
                .foo_ficha_id = vFichaOticaOlho.foo_ficha_id
                .foo_produto_id = vFichaOticaOlho.foo_produto_id
                .foo_produto_nome = vFichaOticaOlho.foo_produto_nome
                .foo_olho = vFichaOticaOlho.foo_olho
                .foo_distancia = vFichaOticaOlho.foo_distancia
                .foo_esf = vFichaOticaOlho.foo_esf
                .foo_cil = vFichaOticaOlho.foo_cil
                .foo_eix = vFichaOticaOlho.foo_eix
                .foo_dnp = vFichaOticaOlho.foo_dnp
            End With
        Else
            Me.ZeraValores()
        End If
    End Sub

    Sub ZeraValores()

        With Me

            .foo_id = 0
            .foo_ficha_id = 0
            .foo_produto_id = 0
            .foo_produto_nome = ""
            .foo_olho = ""
            .foo_distancia = ""
            .foo_esf = ""
            .foo_cil = ""
            .foo_eix = ""
            .foo_dnp = ""
        End With
    End Sub
End Class
