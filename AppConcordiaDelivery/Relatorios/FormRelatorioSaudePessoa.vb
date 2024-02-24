Imports Microsoft.Reporting.WinForms
Public Class FormRelatorioSaudePessoa

    Public _SaudePessoa As New ClInfoSaudePessoa
    Public _ListaItensSaudePessoa As New List(Of ClInfoSaudePessoaItem)
    Public _imagem As New ClImgRelatorio
    Dim _listImagem As New List(Of ClImgRelatorio)
    Public _ComplicacaoIMC As String = ""

    Private Sub FormSaudePessoa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        carregarRelatorio()
        Me.rpvSaudePessoa.RefreshReport()
    End Sub

    Sub carregarRelatorio()

        Dim paramCodPessoa As New ReportParameter("rpCodPessoa", _SaudePessoa.inp_pessoaid.ToString.PadLeft(7, "0"))
        Dim paramNomePessoa As New ReportParameter("rpNomePessoa", _SaudePessoa.inp_pessoanome)
        Dim paramPesoPessoa As New ReportParameter("rpPesoPessoa", _SaudePessoa.inp_pessoapeso.ToString("#,##0.000"))
        Dim paramAlturaPessoa As New ReportParameter("rpAlturaPessoa", _SaudePessoa.inp_pessoaaltura.ToString("#,##0.00"))
        Dim paramResultadoIMC As New ReportParameter("rpImcResultado", _SaudePessoa.inp_resultadoIMC.ToString("#,##0.00"))
        Dim paramIdadePessoa As New ReportParameter("rpIdadePessoa", _SaudePessoa.inp_pessoaidade)
        Dim paramClassificacaoIMC As New ReportParameter("rpImcClassificacao", _SaudePessoa.inp_imcclassificacao)
        Dim paramImcCausa As New ReportParameter("rpImcCausa", _ComplicacaoIMC)
        Dim paramComorbidade1 As New ReportParameter("rpComorbidade1", _SaudePessoa.inp_comorbidade1)
        Dim paramComorbidade2 As New ReportParameter("rpComorbidade2", _SaudePessoa.inp_comorbidade2)
        Dim paramComorbidade3 As New ReportParameter("rpComorbidade3", _SaudePessoa.inp_comorbidade3)
        Dim paramComorbidade4 As New ReportParameter("rpComorbidade4", _SaudePessoa.inp_comorbidade4)
        Dim paramObservacao As New ReportParameter("rpObservacao", _SaudePessoa.inp_observacao)

        Me.rpvSaudePessoa.LocalReport.SetParameters(paramCodPessoa)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramNomePessoa)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramPesoPessoa)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramAlturaPessoa)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramResultadoIMC)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramIdadePessoa)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramClassificacaoIMC)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramImcCausa)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramComorbidade1)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramComorbidade2)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramComorbidade3)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramComorbidade4)
        Me.rpvSaudePessoa.LocalReport.SetParameters(paramObservacao)

        Me.rpvSaudePessoa.LocalReport.DataSources.Clear()
        Me.rpvSaudePessoa.LocalReport.ReportEmbeddedResource = MdlConexaoBD.mdlConfiguracoes.appNome & ".RelatorioSaudePessoa.rdlc"
        Dim ds As New Microsoft.Reporting.WinForms.ReportDataSource("SaudePessoaItemDS", _ListaItensSaudePessoa)
        Me.rpvSaudePessoa.LocalReport.DataSources.Add(ds)
        ds.Value = _ListaItensSaudePessoa

        'Configurando Imagem Relatorio:
        Dim converter As New ImageConverter
        _imagem.ImagemBytes = converter.ConvertTo(_imagem.IMAGEM, GetType(Byte()))
        _listImagem.Add(_imagem)
        Dim dsImg As New Microsoft.Reporting.WinForms.ReportDataSource("ImgRelatorioDS", _listImagem)
        Me.rpvSaudePessoa.LocalReport.DataSources.Add(dsImg)
        dsImg.Value = _listImagem

        Me.rpvSaudePessoa.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.rpvSaudePessoa.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth

    End Sub

End Class