Public Class ClUsuario

    Public Property u_id As Int64
    Public Property u_login As String
    Public Property u_nome As String
    Public Property u_senha As String
    Public Property u_privilegio As Boolean
    Public Property u_bloqueado As Boolean
    Public Property u_datanascimento As String
    Public Property u_foto As String
    Public Property u_empresaid As Integer
    Public Property u_empresanome As String
    Public Property u_inativo As Boolean
    Public Property u_caixa As Boolean

    Public Sub New()

        With Me
            .u_id = 0
            .u_login = ""
            .u_nome = ""
            .u_senha = ""
            .u_privilegio = False
            .u_bloqueado = False
            .u_datanascimento = ""
            .u_foto = ""
            .u_empresaid = 0
            .u_empresanome = ""
            .u_inativo = False
            .u_caixa = False
        End With
    End Sub

    Public Sub New(usu As ClUsuario)

        With Me
            .u_id = usu.u_id
            .u_login = usu.u_login
            .u_nome = usu.u_nome
            .u_senha = usu.u_senha
            .u_privilegio = usu.u_privilegio
            .u_bloqueado = usu.u_bloqueado
            .u_datanascimento = usu.u_datanascimento
            .u_foto = usu.u_foto
            .u_empresaid = usu.u_empresaid
            .u_empresanome = usu.u_empresanome
            .u_inativo = usu.u_inativo
            .u_caixa = usu.u_caixa
        End With
    End Sub

    Public Sub setaValores(usu As ClUsuario)

        With Me
            .u_id = usu.u_id
            .u_login = usu.u_login
            .u_nome = usu.u_nome
            .u_senha = usu.u_senha
            .u_privilegio = usu.u_privilegio
            .u_bloqueado = usu.u_bloqueado
            .u_datanascimento = usu.u_datanascimento
            .u_foto = usu.u_foto
            .u_empresaid = usu.u_empresaid
            .u_empresanome = usu.u_empresanome
            .u_inativo = usu.u_inativo
            .u_caixa = usu.u_caixa
        End With
    End Sub


    Public Sub zeraValores()

        With Me
            .u_id = 0
            .u_login = ""
            .u_nome = ""
            .u_senha = ""
            .u_privilegio = False
            .u_bloqueado = False
            .u_datanascimento = ""
            .u_foto = ""
            .u_empresaid = 0
            .u_empresanome = ""
            .u_inativo = False
            .u_caixa = False
        End With
    End Sub

End Class
