Public Class ClFichaOticaProduto
    Inherits ClFichaOticaProdutoDAO

    Public Property fop_id As Int64
    Public Property fop_ficha_id As Int64
    Public Property fop_produto_id As Int64
    Public Property fop_produto_nome As String
    Public Property fop_produto_unidade As String
    Public Property fop_quantidade As Double
    Public Property fop_preco_venda As Double
    Public Property fop_total As Double
    Public Property fop_cor As String
    Public Property fop_referencia As String

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vFichaId As Int64 = 0, Optional ByVal vProdutoId As Int64 = 0, _
            Optional ByVal vProdutoNome As String = "", Optional ByVal vProdutoUnidade As String = "", Optional ByVal vQuantidade As Double = 0, _
            Optional ByVal vPrecoVenda As Double = 0, Optional ByVal vTotal As Double = 0, Optional ByVal vCor As String = "", _
            Optional ByVal vReferencia As String = "")

        Me.fop_id = vId : Me.fop_ficha_id = vFichaId : Me.fop_produto_id = vProdutoId : Me.fop_produto_nome = vProdutoNome
        Me.fop_produto_unidade = vProdutoUnidade : Me.fop_quantidade = vQuantidade : Me.fop_preco_venda = vPrecoVenda
        Me.fop_total = vTotal : Me.fop_cor = vCor : Me.fop_referencia = vReferencia
    End Sub

    Sub New(ByVal vFichaOticaProduto As ClFichaOticaProduto)

        If Not IsNothing(vFichaOticaProduto) Then

            With Me

                .fop_id = vFichaOticaProduto.fop_id
                .fop_ficha_id = vFichaOticaProduto.fop_ficha_id
                .fop_produto_id = vFichaOticaProduto.fop_produto_id
                .fop_produto_nome = vFichaOticaProduto.fop_produto_nome
                .fop_produto_unidade = vFichaOticaProduto.fop_produto_unidade
                .fop_quantidade = vFichaOticaProduto.fop_quantidade
                .fop_preco_venda = vFichaOticaProduto.fop_preco_venda
                .fop_total = vFichaOticaProduto.fop_total
                .fop_cor = vFichaOticaProduto.fop_cor
                .fop_referencia = vFichaOticaProduto.fop_referencia
            End With
        Else
            Me.ZeraValores()
        End If
    End Sub

    Sub SetaValores(ByVal vFichaOticaProduto As ClFichaOticaProduto)

        If Not IsNothing(vFichaOticaProduto) Then

            With Me

                .fop_id = vFichaOticaProduto.fop_id
                .fop_ficha_id = vFichaOticaProduto.fop_ficha_id
                .fop_produto_id = vFichaOticaProduto.fop_produto_id
                .fop_produto_nome = vFichaOticaProduto.fop_produto_nome
                .fop_produto_unidade = vFichaOticaProduto.fop_produto_unidade
                .fop_quantidade = vFichaOticaProduto.fop_quantidade
                .fop_preco_venda = vFichaOticaProduto.fop_preco_venda
                .fop_total = vFichaOticaProduto.fop_total
                .fop_cor = vFichaOticaProduto.fop_cor
                .fop_referencia = vFichaOticaProduto.fop_referencia
            End With
        Else
            Me.ZeraValores()
        End If
    End Sub

    Sub ZeraValores()

        With Me

            .fop_id = 0
            .fop_ficha_id = 0
            .fop_produto_id = 0
            .fop_produto_nome = ""
            .fop_produto_unidade = ""
            .fop_quantidade = 0
            .fop_preco_venda = 0
            .fop_total = 0
            .fop_cor = ""
            .fop_referencia = ""
        End With
    End Sub

End Class
