Public Class ClVendaServicoItens


    Private _vsi_id As Int64, _vsi_data As Date
    Private _vs_id As Int64, _vs_totalcartao As Double, _vs_totalcartaoseparado As Double
    Private _vsi_servicoid As Integer, _vsi_serviconome As String, _vsi_servicodespctporcent As Double, _vsi_servicodespctvalor As Double
    Private _vsi_atendenteid As Integer, _vsi_atendentenome As String, _vsi_atendentecomissao As Double
    Private _vsi_quantidadeservico As Double, _vsi_valorservico As Double, _vsi_descontoservico As Double
    Private _vsi_subtotalservico As Double, _vsi_valortotalservico As Double, _vsi_despcartaoseparado As Double
    Private _vsi_valorcomissao As Double

    Sub New(Optional ByVal Id As Int64 = 0, Optional ByVal Data As Date = Nothing, Optional ByVal IdVendaServico As Int64 = 0, Optional ByVal TotCartaoVendaServico As Double = 0, _
            Optional ByVal TotCartaoSeparadoVendServico As Double = 0, Optional ByVal IdServico As Integer = 0, Optional ByVal NomeServico As String = "", _
            Optional ByVal DespCartaoServico_Porcent As Double = 0, Optional ByVal DespCartaoServico_Valor As Double = 0, Optional ByVal IdAtendente As Integer = 0, _
            Optional ByVal NomeAtendente As String = "", Optional ByVal ComissaoAtendente As Double = 0, Optional ByVal QuantidadeServico As Double = 0, _
            Optional ByVal ValorServico As Double = 0, Optional ByVal DescontoServico As Double = 0, Optional ByVal SubTotalServico As Double = 0, _
            Optional ByVal ValorTotalServico As Double = 0, Optional ByVal DespCartaoSeparado As Double = 0, Optional ByVal ValorComissao As Double = 0)

        Me._vsi_id = Id : Me._vsi_data = Data : Me._vs_id = IdVendaServico : Me._vs_totalcartao = TotCartaoVendaServico : Me._vsi_serviconome = NomeServico
        Me._vs_totalcartaoseparado = TotCartaoSeparadoVendServico : Me._vsi_servicoid = IdServico : Me._vsi_servicodespctporcent = DespCartaoServico_Porcent
        Me._vsi_servicodespctvalor = DespCartaoServico_Valor : Me._vsi_atendenteid = IdAtendente : Me._vsi_atendentenome = NomeAtendente
        Me._vsi_atendentecomissao = ComissaoAtendente : Me._vsi_quantidadeservico = QuantidadeServico : Me._vsi_valorservico = ValorServico
        Me._vsi_descontoservico = DescontoServico : Me._vsi_subtotalservico = SubTotalServico : Me._vsi_valortotalservico = ValorTotalServico
        Me._vsi_despcartaoseparado = DespCartaoSeparado : Me._vsi_valorcomissao = ValorComissao
    End Sub

    Sub New(vsi As ClVendaServicoItens)

        With Me
            ._vsi_id = vsi.Id
            ._vsi_data = vsi.Data
            ._vs_id = vsi.IdVendaServico
            ._vs_totalcartao = vsi.TotalCartaoVendaServico
            ._vsi_serviconome = vsi.NomeServico
            ._vs_totalcartaoseparado = vsi.TotalCartaoSeparadoVendaServico
            ._vsi_servicoid = vsi.IdServico
            ._vsi_servicodespctporcent = vsi.DespCartaoServico_Porcent
            ._vsi_servicodespctvalor = vsi.DespCartaoServico_Valor
            ._vsi_atendenteid = vsi.IdAtendente
            ._vsi_atendentenome = vsi.NomeAtendente
            ._vsi_atendentecomissao = vsi.ComissaoAtendente
            ._vsi_quantidadeservico = vsi.QuantidadeServico
            ._vsi_valorservico = vsi.ValorServico
            ._vsi_descontoservico = vsi.DescontoServico
            ._vsi_subtotalservico = vsi.SubTotalServico
            ._vsi_valortotalservico = vsi.ValorTotalServico
            ._vsi_despcartaoseparado = vsi.DespCartaoSeparado
            ._vsi_valorcomissao = vsi.ValorComissao
        End With
    End Sub

    Sub setaValores(vsi As ClVendaServicoItens)

        With Me
            ._vsi_id = vsi.Id
            ._vsi_data = vsi.Data
            ._vs_id = vsi.IdVendaServico
            ._vs_totalcartao = vsi.TotalCartaoVendaServico
            ._vsi_serviconome = vsi.NomeServico
            ._vs_totalcartaoseparado = vsi.TotalCartaoSeparadoVendaServico
            ._vsi_servicoid = vsi.IdServico
            ._vsi_servicodespctporcent = vsi.DespCartaoServico_Porcent
            ._vsi_servicodespctvalor = vsi.DespCartaoServico_Valor
            ._vsi_atendenteid = vsi.IdAtendente
            ._vsi_atendentenome = vsi.NomeAtendente
            ._vsi_atendentecomissao = vsi.ComissaoAtendente
            ._vsi_quantidadeservico = vsi.QuantidadeServico
            ._vsi_valorservico = vsi.ValorServico
            ._vsi_descontoservico = vsi.DescontoServico
            ._vsi_subtotalservico = vsi.SubTotalServico
            ._vsi_valortotalservico = vsi.ValorTotalServico
            ._vsi_despcartaoseparado = vsi.DespCartaoSeparado
            ._vsi_valorcomissao = vsi.ValorComissao
        End With
    End Sub

    Sub ZeraValores()
        Me._vsi_id = 0 : Me._vsi_data = Nothing : Me._vs_id = 0 : Me._vs_totalcartao = 0 : Me._vsi_serviconome = ""
        Me._vs_totalcartaoseparado = 0 : Me._vsi_servicoid = 0 : Me._vsi_servicodespctporcent = 0
        Me._vsi_servicodespctvalor = 0 : Me._vsi_atendenteid = 0 : Me._vsi_atendentenome = ""
        Me._vsi_atendentecomissao = 0 : Me._vsi_quantidadeservico = 0 : Me._vsi_valorservico = 0
        Me._vsi_descontoservico = 0 : Me._vsi_subtotalservico = 0 : Me._vsi_valortotalservico = 0
        Me._vsi_despcartaoseparado = 0 : Me._vsi_valorcomissao = 0
    End Sub

#Region "  Get e Set  "

    Public Property Id() As Int64
        Get
            Return Me._vsi_id
        End Get
        Set(value As Int64)
            Me._vsi_id = value
        End Set
    End Property

    Public Property IdVendaServico() As Int64
        Get
            Return Me._vs_id
        End Get
        Set(value As Int64)
            Me._vs_id = value
        End Set
    End Property

    Public Property Data() As Date
        Get
            Return Me._vsi_data
        End Get
        Set(value As Date)
            Me._vsi_data = value
        End Set
    End Property

    Public Property TotalCartaoVendaServico() As Double
        Get
            Return Me._vs_totalcartao
        End Get
        Set(value As Double)
            Me._vs_totalcartao = value
        End Set
    End Property

    Public Property TotalCartaoSeparadoVendaServico() As Double
        Get
            Return Me._vs_totalcartaoseparado
        End Get
        Set(value As Double)
            Me._vs_totalcartaoseparado = value
        End Set
    End Property

    Public Property NomeServico() As String
        Get
            Return Me._vsi_serviconome
        End Get
        Set(value As String)
            Me._vsi_serviconome = value
        End Set
    End Property

    Public Property IdServico() As Integer
        Get
            Return Me._vsi_servicoid
        End Get
        Set(value As Integer)
            Me._vsi_servicoid = value
        End Set
    End Property

    Public Property DespCartaoServico_Porcent() As Double
        Get
            Return Me._vsi_servicodespctporcent
        End Get
        Set(value As Double)
            Me._vsi_servicodespctporcent = value
        End Set
    End Property

    Public Property DespCartaoServico_Valor() As Double
        Get
            Return Me._vsi_servicodespctvalor
        End Get
        Set(value As Double)
            Me._vsi_servicodespctvalor = value
        End Set
    End Property

    Public Property IdAtendente() As Integer
        Get
            Return Me._vsi_atendenteid
        End Get
        Set(value As Integer)
            Me._vsi_atendenteid = value
        End Set
    End Property

    Public Property NomeAtendente() As String
        Get
            Return Me._vsi_atendentenome
        End Get
        Set(value As String)
            Me._vsi_atendentenome = value
        End Set
    End Property

    Public Property ComissaoAtendente() As Double
        Get
            Return Me._vsi_atendentecomissao
        End Get
        Set(value As Double)
            Me._vsi_atendentecomissao = value
        End Set
    End Property

    Public Property QuantidadeServico() As Double
        Get
            Return Me._vsi_quantidadeservico
        End Get
        Set(value As Double)
            Me._vsi_quantidadeservico = value
        End Set
    End Property

    Public Property ValorServico() As Double
        Get
            Return Me._vsi_valorservico
        End Get
        Set(value As Double)
            Me._vsi_valorservico = value
        End Set
    End Property

    Public Property DescontoServico() As Double
        Get
            Return Me._vsi_descontoservico
        End Get
        Set(value As Double)
            Me._vsi_descontoservico = value
        End Set
    End Property

    Public Property SubTotalServico() As Double
        Get
            Return Me._vsi_subtotalservico
        End Get
        Set(value As Double)
            Me._vsi_subtotalservico = value
        End Set
    End Property

    Public Property ValorTotalServico() As Double
        Get
            Return Me._vsi_valortotalservico
        End Get
        Set(value As Double)
            Me._vsi_valortotalservico = value
        End Set
    End Property

    Public Property DespCartaoSeparado() As Double
        Get
            Return Me._vsi_despcartaoseparado
        End Get
        Set(value As Double)
            Me._vsi_despcartaoseparado = value
        End Set
    End Property

    Public Property ValorComissao() As Double
        Get
            Return Me._vsi_valorcomissao
        End Get
        Set(value As Double)
            Me._vsi_valorcomissao = value
        End Set
    End Property
#End Region

End Class
