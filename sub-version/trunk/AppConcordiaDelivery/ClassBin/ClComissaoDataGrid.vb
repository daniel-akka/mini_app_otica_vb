Public Class ClComissaoDataGrid

    Public AtendenteID As Integer, AntendenteNOME As String, ServicoID As Integer, ServicoNOME As String, Qtde As Double
    Public IdVendaServico As Int64, Total As Double, DataHora As Date, Comissao As Double
    Public pagoDN As Double, pagoCTC As Double, pagoCTD As Double, pagoPIX As Double, pagoTRA As Double, pagoCRD As Double
    Public formaPagamentos As String

    Sub New(Optional ByVal ComissaoGrid As ClComissaoDataGrid = Nothing)


        Try
            With Me

                .IdVendaServico = ComissaoGrid.IdVendaServico
                .AtendenteID = ComissaoGrid.AtendenteID
                .AntendenteNOME = ComissaoGrid.AntendenteNOME
                .ServicoNOME = ComissaoGrid.ServicoNOME
                .ServicoID = ComissaoGrid.ServicoID
                .Qtde = ComissaoGrid.Qtde
                .Total = ComissaoGrid.Total
                .DataHora = ComissaoGrid.DataHora
                .Comissao = ComissaoGrid.Comissao
                .pagoDN = ComissaoGrid.pagoDN
                .pagoCTC = ComissaoGrid.pagoCTC
                .pagoCTD = ComissaoGrid.pagoCTD
                .pagoPIX = ComissaoGrid.pagoPIX
                .pagoTRA = ComissaoGrid.pagoTRA
                .pagoCRD = ComissaoGrid.pagoCRD
                .formaPagamentos = ComissaoGrid.formaPagamentos
            End With
        Catch ex As Exception
            Me.ZeraValores()
        End Try
        

    End Sub

    Sub setValores(ComissaoGrid As ClComissaoDataGrid)

        With Me

            .IdVendaServico = ComissaoGrid.IdVendaServico
            .AtendenteID = ComissaoGrid.AtendenteID
            .AntendenteNOME = ComissaoGrid.AntendenteNOME
            .ServicoNOME = ComissaoGrid.ServicoNOME
            .ServicoID = ComissaoGrid.ServicoID
            .Qtde = ComissaoGrid.Qtde
            .Total = ComissaoGrid.Total
            .DataHora = ComissaoGrid.DataHora
            .Comissao = ComissaoGrid.Comissao
            .pagoDN = ComissaoGrid.pagoDN
            .pagoCTC = ComissaoGrid.pagoCTC
            .pagoCTD = ComissaoGrid.pagoCTD
            .pagoPIX = ComissaoGrid.pagoPIX
            .pagoTRA = ComissaoGrid.pagoTRA
            .pagoCRD = ComissaoGrid.pagoCRD
            .formaPagamentos = ComissaoGrid.formaPagamentos
        End With

    End Sub

    Sub ZeraValores()

        With Me

            .IdVendaServico = 0
            .AtendenteID = 0
            .AntendenteNOME = ""
            .ServicoNOME = ""
            .ServicoID = 0
            .Qtde = 0
            .Total = 0
            .DataHora = Nothing
            .Comissao = 0
            .pagoDN = 0
            .pagoCTC = 0
            .pagoCTD = 0
            .pagoPIX = 0
            .pagoTRA = 0
            .pagoCRD = 0
            .formaPagamentos = ""
        End With

    End Sub

End Class
