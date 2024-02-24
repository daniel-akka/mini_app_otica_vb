Module MdlERRO

    Public _erro As Boolean
    Public _clFunc As New ClFuncoes

    Public Sub msgErro(msg As String)

        If MessageBox.Show(msg & vbNewLine & "Deseja Continuar assim mesmo?", Application.CompanyName.ToUpper, _
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            MdlERRO._erro = ""
        End If

    End Sub

End Module
