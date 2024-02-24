Imports Npgsql

Public Class FrmConfiguracoes

    'Objetos:
    Dim _configuracao As New ClConfiguracoes
    Dim configuracaoDAO As New ClConfiguracoesDAO
    Dim funcoes As New ClFuncoes


    Private Sub txtLimiteDesconto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimiteDesconto.KeyPress, txtDiasCrediario.KeyPress
        'permite só numeros virgula:
        If funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtDiasCrediario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasCrediario.KeyPress
        'permite só numeros:
        If funcoes.SoNumeros(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub FrmConfiguracoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        configuracaoDAO.TrazConfiguracoesID(_configuracao, MdlConexaoBD.conectionPadrao)
        Me.txtLimiteDesconto.Text = _configuracao.tLimiteDesconto
        Me.txtSenhaPadrao.Text = _configuracao.tSenhaPadrao
        Me.txtDiasCrediario.Text = _configuracao.tDiasVencCrediario
        Me.txtLocalLogoMarca.Text = _configuracao.caminho_logo
        Me.txtPastaSGBD.Text = _configuracao.caminho_pasta_sgb
        Me.txtPastaDoSistema.Text = _configuracao.caminho_pasta_sistema
        Me.txtPastaSincronizar.Text = _configuracao.caminho_pasta_Sincronizar
    End Sub

    Private Sub FrmConfiguracoes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FrmConfiguracoes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        With Me._configuracao

            If IsNumeric(txtLimiteDesconto.Text) Then .tLimiteDesconto = CDbl(txtLimiteDesconto.Text)
            .tSenhaPadrao = Trim(txtSenhaPadrao.Text)
            If IsNumeric(txtDiasCrediario.Text) Then .tDiasVencCrediario = CInt(txtDiasCrediario.Text)
            .caminho_pasta_sistema = txtPastaDoSistema.Text
            .caminho_pasta_sgb = txtPastaSGBD.Text
            .caminho_logo = txtLocalLogoMarca.Text
            .caminho_pasta_Sincronizar = Me.txtPastaSincronizar.Text
        End With

        configuracaoDAO.altConfiguracoes(_configuracao, MdlConexaoBD.conectionPadrao)
        mdlConfiguracoesDAO.TrazConfiguracoesID(mdlConfiguracoes, MdlConexaoBD.conectionPadrao)
        Me.Close()
    End Sub

    Private Sub btnLogo_Click(sender As Object, e As EventArgs) Handles btnLogo.Click
        BuscaLogo()
    End Sub

    Public Sub BuscaLogo()

        OpenFileDialog1.Filter = "JPG (*.jpg)|*.jpg|JPEG (*.JPEG)|*.jpg|PNG (*.PNG)|*.png"
        'OpenFileDialog1
        Me.txtLocalLogoMarca.Text = OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> "" Then Me.txtLocalLogoMarca.Text = OpenFileDialog1.FileName

    End Sub

    Public Sub BuscaPastaSGBD()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txtPastaSGBD.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txtPastaSGBD.Text = ""
        End Try

    End Sub

    Public Sub BuscaPastaSINCRONIZAR()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txtPastaSincronizar.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txtPastaSincronizar.Text = ""
        End Try

    End Sub

    Public Sub BuscaPastaAplicacao()

        Try
            OpenFolder.ShowDialog()
            If OpenFolder.SelectedPath <> "" Then Me.txtPastaDoSistema.Text = OpenFolder.SelectedPath
        Catch ex As Exception
            Me.txtPastaDoSistema.Text = ""
        End Try

    End Sub

    Private Sub btnPastaAplicacao_Click(sender As Object, e As EventArgs) Handles btnPastaAplicacao.Click
        BuscaPastaAplicacao()
    End Sub

    Private Sub btnPastaSGBD_Click(sender As Object, e As EventArgs) Handles btnPastaSGBD.Click
        BuscaPastaSGBD()
    End Sub

    Private Sub btnPastaSincronizar_Click(sender As Object, e As EventArgs) Handles btnPastaSincronizar.Click
        BuscaPastaSINCRONIZAR()
    End Sub
End Class