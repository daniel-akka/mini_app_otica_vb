Public Class ClComissao

    Private _c_id As Int64, _c_atendenteid As Integer, _c_atendentenome As String
    Private _c_datapagamento As Date, _c_valorpago As Double, _c_observacao As String
    Private _c_empresaid As Integer, _c_empresanome As String, _c_deletada As Boolean
    'Private _ArrayIdCaixas As New List(Of Integer)

    Sub New(Optional ByVal vid As Int64 = 0, Optional ByVal vAtendenteID As Int64 = 0, Optional ByVal vAtendenteNome As String = "", _
            Optional ByVal vDataPagamento As Date = Nothing, Optional ByVal vValorPago As Double = 0, Optional ByVal vObservacao As String = "", _
            Optional ByVal vEmpresaId As Int64 = 0, Optional ByVal vEmpresaNome As String = "", Optional ByVal vDeletada As Boolean = False)
        'Optional ByVal IdCaixasArray As List(Of Integer) = Nothing

        With Me
            ._c_id = vid
            ._c_atendenteid = vAtendenteID
            ._c_atendentenome = vAtendenteNome
            ._c_datapagamento = vDataPagamento
            ._c_valorpago = vValorPago
            ._c_observacao = vObservacao
            ._c_empresaid = vEmpresaId
            ._c_empresanome = vEmpresaNome
            ._c_deletada = vDeletada
            '._ArrayIdCaixas = IdCaixasArray
        End With

    End Sub

    Sub New(Comissao As ClComissao)

        With Me
            ._c_id = Comissao._c_id
            ._c_atendenteid = Comissao._c_atendenteid
            ._c_atendentenome = Comissao._c_atendentenome
            ._c_datapagamento = Comissao._c_datapagamento
            ._c_valorpago = Comissao._c_valorpago
            ._c_observacao = Comissao._c_observacao
            ._c_empresaid = Comissao._c_empresaid
            ._c_empresanome = Comissao._c_empresanome
            ._c_deletada = Comissao._c_deletada
            '._ArrayIdCaixas = Comissao._ArrayIdCaixas
        End With
    End Sub

    Sub SetaValores(Comissao As ClComissao)

        With Me
            ._c_id = Comissao._c_id
            ._c_atendenteid = Comissao._c_atendenteid
            ._c_atendentenome = Comissao._c_atendentenome
            ._c_datapagamento = Comissao._c_datapagamento
            ._c_valorpago = Comissao._c_valorpago
            ._c_observacao = Comissao._c_observacao
            ._c_empresaid = Comissao._c_empresaid
            ._c_empresanome = Comissao._c_empresanome
            ._c_deletada = Comissao._c_deletada
            '._ArrayIdCaixas = Comissao._ArrayIdCaixas
        End With
    End Sub

    Sub zeraValores()

        With Me
            ._c_id = 0
            ._c_atendenteid = 0
            ._c_atendentenome = ""
            ._c_datapagamento = Nothing
            ._c_valorpago = 0
            ._c_observacao = ""
            ._c_empresaid = 0
            ._c_empresanome = ""
            ._c_deletada = False
            '._ArrayIdCaixas.Clear()
        End With
    End Sub

    'Function IdCaixasFormatSTR(ids As List(Of Integer)) As String
    '    Dim mSTR As String = ""

    '    Try
    '        If ids.Count <= 0 Then Return mSTR
    '    Catch ex As Exception
    '        Return mSTR
    '    End Try

    '    For Each i As Integer In ids
    '        mSTR += "|" & i
    '    Next

    '    Return mSTR
    'End Function

    'Function ExistIdCaixas(ids As List(Of Integer), comissoes As List(Of ClComissao)) As Boolean

    '    Try
    '        If comissoes.Count <= 0 Then Return False
    '        If ids.Count <= 0 Then Return False
    '    Catch ex As Exception
    '        Return False
    '    End Try

    '    For Each c As ClComissao In comissoes


    '    Next


    '    Return False
    'End Function

    'Sub BuscarIdCaixasFormatSTR(array As String)

    '    Dim mArray As Array
    '    mArray = array.Split("|")

    '    Me._ArrayIdCaixas.Clear()
    '    For Each i In mArray

    '        If IsNumeric(i) Then
    '            Me._ArrayIdCaixas.Add(i)
    '        End If
    '    Next

    'End Sub



#Region "   Get e Set"

    Public Property c_id() As Int64
        Get
            Return Me._c_id
        End Get
        Set(value As Int64)
            Me._c_id = value
        End Set
    End Property

    'Public Property ArrayIdCaixas() As List(Of Integer)
    '    Get
    '        Return Me._ArrayIdCaixas
    '    End Get
    '    Set(value As List(Of Integer))
    '        Me._ArrayIdCaixas = value
    '    End Set
    'End Property

    Public Property c_deletada() As Boolean
        Get
            Return Me._c_deletada
        End Get
        Set(value As Boolean)
            Me._c_deletada = value
        End Set
    End Property

    Public Property c_empresaid() As Integer
        Get
            Return Me._c_empresaid
        End Get
        Set(value As Integer)
            Me._c_empresaid = value
        End Set
    End Property

    Public Property c_empresanome() As String
        Get
            Return Me._c_empresanome
        End Get
        Set(value As String)
            Me._c_empresanome = value
        End Set
    End Property

    Public Property c_atendenteid() As Integer
        Get
            Return Me._c_atendenteid
        End Get
        Set(value As Integer)
            Me._c_atendenteid = value
        End Set
    End Property

    Public Property c_atendentenome() As String
        Get
            Return Me._c_atendentenome
        End Get
        Set(value As String)
            Me._c_atendentenome = value
        End Set
    End Property

    Public Property c_datapagamento() As Date
        Get
            Return Me._c_datapagamento
        End Get
        Set(value As Date)
            Me._c_datapagamento = value
        End Set
    End Property

    Public Property c_valorpago() As Double
        Get
            Return Me._c_valorpago
        End Get
        Set(value As Double)
            Me._c_valorpago = value
        End Set
    End Property

    Public Property c_observacao() As String
        Get
            Return Me._c_observacao
        End Get
        Set(value As String)
            Me._c_observacao = value
        End Set
    End Property

#End Region

End Class
