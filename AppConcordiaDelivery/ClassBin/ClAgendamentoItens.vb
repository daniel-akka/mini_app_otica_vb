Public Class ClAgendamentoItens

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Public Property agi_id As Int64
    Public Property AG_ID As Int64
    Public Property agi_codserv As Int64
    Public Property agi_descrserv As String
    Public Property agi_dtemis As Date
    Public Property agi_valor As Double
    Public Property agi_qtde As Double
    Public Property agi_total As Double
    Public Property agi_atendenteid As Integer
    Public Property agi_atendentenome As String

    Sub New(Optional ByVal vID As Int64 = 0, Optional ByVal vIDAgendamento As Int64 = 0, Optional ByVal vCodServ As Int64 = 0, _
            Optional ByVal vDescrServ As String = "", Optional ByVal vDtEmiss As Date = Nothing, Optional ByVal vValor As Double = 0, _
            Optional ByVal vQtde As Double = 0, Optional ByVal vTotal As Double = 0, Optional ByVal vAtendenteID As Integer = 0, _
            Optional ByVal vAtendenteNOME As String = "")

        With Me

            .agi_id = vID
            .AG_ID = vIDAgendamento
            .agi_codserv = vCodServ
            .agi_descrserv = vDescrServ
            .agi_dtemis = vDtEmiss
            .agi_valor = vValor
            .agi_qtde = vQtde
            .agi_total = vTotal
            .agi_atendenteid = vAtendenteID
            .agi_atendentenome = vAtendenteNOME
        End With
    End Sub

    Sub New(AgendItem As ClAgendamentoItens)

        With Me

            .agi_id = AgendItem.agi_id
            .AG_ID = AgendItem.AG_ID
            .agi_codserv = AgendItem.agi_codserv
            .agi_descrserv = AgendItem.agi_descrserv
            .agi_dtemis = AgendItem.agi_dtemis
            .agi_valor = AgendItem.agi_valor
            .agi_qtde = AgendItem.agi_qtde
            .agi_total = AgendItem.agi_total
            .agi_atendenteid = AgendItem.agi_atendenteid
            .agi_atendentenome = AgendItem.agi_atendentenome
        End With
    End Sub

    Sub setaValores(AgendItem As ClAgendamentoItens)

        With Me

            .agi_id = AgendItem.agi_id
            .AG_ID = AgendItem.AG_ID
            .agi_codserv = AgendItem.agi_codserv
            .agi_descrserv = AgendItem.agi_descrserv
            .agi_dtemis = AgendItem.agi_dtemis
            .agi_valor = AgendItem.agi_valor
            .agi_qtde = AgendItem.agi_qtde
            .agi_total = AgendItem.agi_total
            .agi_atendenteid = AgendItem.agi_atendenteid
            .agi_atendentenome = AgendItem.agi_atendentenome
        End With
    End Sub

    Sub zeraValores()

        With Me

            .agi_id = 0
            .AG_ID = 0
            .agi_codserv = 0
            .agi_descrserv = ""
            .agi_dtemis = Nothing
            .agi_valor = 0
            .agi_qtde = 0
            .agi_total = 0
            .agi_atendenteid = 0
            .agi_atendentenome = ""
        End With
    End Sub

End Class
