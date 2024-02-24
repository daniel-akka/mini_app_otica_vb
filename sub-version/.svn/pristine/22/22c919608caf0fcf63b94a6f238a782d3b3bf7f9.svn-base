Public Class ClAgendamento

    Public Property a_id As Int64
    Public Property a_empresaid As Integer
    Public Property a_empresanome As String
    Public Property a_dtemis As Date
    Public Property a_dtagend As Date
    Public Property a_status As Boolean
    Public Property a_iddoutor As Integer
    Public Property a_doutor As String
    Public Property a_valor As Double
    Public Property a_cancelado As Boolean
    Public Property a_usuario As String
    Public Property a_usuarioalt As String
    Public Property a_financeiro As Boolean
    Public Property a_turno As String 'M=Manha; T=Tarde; N=Noite
    Public Property a_info As String
    Public Property a_pessoaid As Int64
    Public Property a_pessoanome As String
    Public Property a_hora As String
    Public Property a_alterado As Boolean

    Sub New(Optional ByVal vId As Int64 = 0, Optional ByVal vEmpresaID As Integer = 0, Optional ByVal vEmpresaNome As String = "", Optional ByVal vDtEmissao As Date = Nothing, _
            Optional ByVal vDtAgend As Date = Nothing, Optional ByVal vStatus As Boolean = False, Optional ByVal vDoutorID As Integer = 0,
            Optional ByVal vDoutor As String = "", Optional ByVal vValor As Double = 0, Optional ByVal vCancelado As Boolean = False, _
            Optional ByVal vUsuario As String = "", Optional ByVal vUsuarioAlteracao As String = "", Optional ByVal vFinanceiro As Boolean = False, _
            Optional ByVal vTurno As String = "", Optional ByVal vInfo As String = "", Optional ByVal vPessoaID As Int64 = 0, _
            Optional ByVal vPessoaNOME As String = "", Optional ByVal vHora As String = "", Optional ByVal vAlterado As Boolean = False)

        With Me

            .a_id = vId
            .a_empresaid = vEmpresaID
            .a_empresanome = vEmpresaNome
            .a_dtemis = vDtEmissao
            .a_dtagend = vDtAgend
            .a_status = vStatus
            .a_iddoutor = vDoutorID
            .a_doutor = vDoutor
            .a_valor = vValor
            .a_cancelado = vCancelado
            .a_usuario = vUsuario
            .a_usuarioalt = vUsuarioAlteracao
            .a_financeiro = vFinanceiro
            .a_turno = vTurno
            .a_info = vInfo
            .a_pessoaid = vPessoaID
            .a_pessoanome = vPessoaNOME
            .a_hora = vHora
            .a_alterado = vAlterado
        End With
    End Sub

    Sub New(Agendamento As ClAgendamento)

        With Me

            .a_id = Agendamento.a_id
            .a_empresaid = Agendamento.a_empresaid
            .a_empresanome = Agendamento.a_empresanome
            .a_dtemis = Agendamento.a_dtemis
            .a_dtagend = Agendamento.a_dtagend
            .a_status = Agendamento.a_status
            .a_iddoutor = Agendamento.a_iddoutor
            .a_doutor = Agendamento.a_doutor
            .a_valor = Agendamento.a_valor
            .a_cancelado = Agendamento.a_cancelado
            .a_usuario = Agendamento.a_usuario
            .a_usuarioalt = Agendamento.a_usuarioalt
            .a_financeiro = Agendamento.a_financeiro
            .a_turno = Agendamento.a_turno
            .a_info = Agendamento.a_info
            .a_pessoaid = Agendamento.a_pessoaid
            .a_pessoanome = Agendamento.a_pessoanome
            .a_hora = Agendamento.a_hora
            .a_alterado = Agendamento.a_alterado
        End With
    End Sub

    Sub setaValores(Agendamento As ClAgendamento)

        With Me

            .a_id = Agendamento.a_id
            .a_empresaid = Agendamento.a_empresaid
            .a_empresanome = Agendamento.a_empresanome
            .a_dtemis = Agendamento.a_dtemis
            .a_dtagend = Agendamento.a_dtagend
            .a_status = Agendamento.a_status
            .a_iddoutor = Agendamento.a_iddoutor
            .a_doutor = Agendamento.a_doutor
            .a_valor = Agendamento.a_valor
            .a_cancelado = Agendamento.a_cancelado
            .a_usuario = Agendamento.a_usuario
            .a_usuarioalt = Agendamento.a_usuarioalt
            .a_financeiro = Agendamento.a_financeiro
            .a_turno = Agendamento.a_turno
            .a_info = Agendamento.a_info
            .a_pessoaid = Agendamento.a_pessoaid
            .a_pessoanome = Agendamento.a_pessoanome
            .a_hora = Agendamento.a_hora
            .a_alterado = Agendamento.a_alterado
        End With
    End Sub

    Sub zeraValores()

        With Me

            .a_id = 0
            .a_empresaid = 0
            .a_empresanome = ""
            .a_dtemis = Nothing
            .a_dtagend = Nothing
            .a_status = False
            .a_iddoutor = 0
            .a_doutor = ""
            .a_valor = 0.0
            .a_cancelado = True
            .a_usuario = ""
            .a_usuarioalt = ""
            .a_financeiro = False
            .a_turno = ""
            .a_info = ""
            .a_pessoaid = 0
            .a_pessoanome = ""
            .a_hora = ""
            .a_alterado = False
        End With
    End Sub

End Class
