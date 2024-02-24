Public Class ClPadraoSistema

    Public psid As Int32
    Public psnomesistema As String
    Public psestado As String
    Public pscidade As String

    Sub New(Optional ByVal vid As Int32 = 0, Optional ByVal vnomesistema As String = "", Optional ByVal vestado As String = "", _
            Optional ByVal vcidade As String = "")
        Me.psid = vid : Me.psnomesistema = vnomesistema : Me.psestado = vestado : Me.pscidade = vcidade
    End Sub
End Class
