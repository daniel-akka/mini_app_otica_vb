<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVendas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVendas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.pdRelatorio = New System.Drawing.Printing.PrintDocument()
        Me.pdRelatorioComprovante = New System.Drawing.Printing.PrintDocument()
        Me.PrintDialog2 = New System.Windows.Forms.PrintDialog()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tbpVenda = New System.Windows.Forms.TabPage()
        Me.btnVizualizaVendas = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grpInfoVenda = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cboFormaPagamento = New System.Windows.Forms.ComboBox()
        Me.cboEntregador = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtValorDeliveryVenda = New System.Windows.Forms.TextBox()
        Me.txtValorTotDescVenda = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSubTotVenda = New System.Windows.Forms.TextBox()
        Me.txtValorTotalVenda = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboAtendente = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConfirmarVenda = New System.Windows.Forms.Button()
        Me.grpProduto = New System.Windows.Forms.GroupBox()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQtdeProd = New System.Windows.Forms.TextBox()
        Me.dtgProdVenda = New System.Windows.Forms.DataGridView()
        Me.IdProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nomeProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtdeProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descontoProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotProd = New System.Windows.Forms.TextBox()
        Me.txtDescValorProd = New System.Windows.Forms.TextBox()
        Me.txtDescProdPorcent = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtVlrProd = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboProduto = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.grpCliente = New System.Windows.Forms.GroupBox()
        Me.chkGravarDados = New System.Windows.Forms.CheckBox()
        Me.txtReferenciaCli = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtEstadoCli = New System.Windows.Forms.TextBox()
        Me.txtCidadeCli = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtCodCliente = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboBairro = New System.Windows.Forms.ComboBox()
        Me.cboRua = New System.Windows.Forms.ComboBox()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.tbpVizualizaVendas = New System.Windows.Forms.TabPage()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.txtLocacoesExcedidas = New System.Windows.Forms.TextBox()
        Me.txtInfoLocacoes = New System.Windows.Forms.TextBox()
        Me.dtgVendas = New System.Windows.Forms.DataGridView()
        Me.idLocacao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendaInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorVenda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tempo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DtgEntregador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Iniciado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnCancelar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btn_Iniciar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnFinalizaTempo = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tabControl.SuspendLayout()
        Me.tbpVenda.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpInfoVenda.SuspendLayout()
        Me.grpProduto.SuspendLayout()
        CType(Me.dtgProdVenda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCliente.SuspendLayout()
        Me.tbpVizualizaVendas.SuspendLayout()
        CType(Me.dtgVendas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDialog2
        '
        Me.PrintDialog2.AllowCurrentPage = True
        Me.PrintDialog2.AllowPrintToFile = False
        Me.PrintDialog2.UseEXDialog = True
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tbpVenda)
        Me.tabControl.Controls.Add(Me.tbpVizualizaVendas)
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl.Location = New System.Drawing.Point(0, 0)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(1086, 527)
        Me.tabControl.TabIndex = 0
        '
        'tbpVenda
        '
        Me.tbpVenda.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
        Me.tbpVenda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpVenda.Controls.Add(Me.btnVizualizaVendas)
        Me.tbpVenda.Controls.Add(Me.lblTitulo)
        Me.tbpVenda.Controls.Add(Me.Label9)
        Me.tbpVenda.Controls.Add(Me.Label10)
        Me.tbpVenda.Controls.Add(Me.Label2)
        Me.tbpVenda.Controls.Add(Me.GroupBox1)
        Me.tbpVenda.Location = New System.Drawing.Point(4, 22)
        Me.tbpVenda.Name = "tbpVenda"
        Me.tbpVenda.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpVenda.Size = New System.Drawing.Size(1078, 501)
        Me.tbpVenda.TabIndex = 0
        Me.tbpVenda.Text = "Venda!"
        Me.tbpVenda.UseVisualStyleBackColor = True
        '
        'btnVizualizaVendas
        '
        Me.btnVizualizaVendas.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnVizualizaVendas.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnVizualizaVendas.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnVizualizaVendas.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVizualizaVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVizualizaVendas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnVizualizaVendas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnVizualizaVendas.Image = Global.AppOtica.My.Resources.Resources._Next
        Me.btnVizualizaVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVizualizaVendas.Location = New System.Drawing.Point(948, 8)
        Me.btnVizualizaVendas.Name = "btnVizualizaVendas"
        Me.btnVizualizaVendas.Size = New System.Drawing.Size(102, 30)
        Me.btnVizualizaVendas.TabIndex = 500
        Me.btnVizualizaVendas.Text = "Vendas"
        Me.btnVizualizaVendas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVizualizaVendas.UseVisualStyleBackColor = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(34, 11)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(109, 23)
        Me.lblTitulo.TabIndex = 122
        Me.lblTitulo.Text = ":: VENDAS"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(666, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 15)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Alterar Locação"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Green
        Me.Label10.Location = New System.Drawing.Point(772, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 18)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "[ F3 ]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(552, 17)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "____________________________________________________________________"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.grpInfoVenda)
        Me.GroupBox1.Controls.Add(Me.grpProduto)
        Me.GroupBox1.Controls.Add(Me.grpCliente)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1062, 458)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'grpInfoVenda
        '
        Me.grpInfoVenda.Controls.Add(Me.Label26)
        Me.grpInfoVenda.Controls.Add(Me.cboFormaPagamento)
        Me.grpInfoVenda.Controls.Add(Me.cboEntregador)
        Me.grpInfoVenda.Controls.Add(Me.Label6)
        Me.grpInfoVenda.Controls.Add(Me.txtValorDeliveryVenda)
        Me.grpInfoVenda.Controls.Add(Me.txtValorTotDescVenda)
        Me.grpInfoVenda.Controls.Add(Me.Label16)
        Me.grpInfoVenda.Controls.Add(Me.txtSubTotVenda)
        Me.grpInfoVenda.Controls.Add(Me.txtValorTotalVenda)
        Me.grpInfoVenda.Controls.Add(Me.Label14)
        Me.grpInfoVenda.Controls.Add(Me.cboAtendente)
        Me.grpInfoVenda.Controls.Add(Me.Label17)
        Me.grpInfoVenda.Controls.Add(Me.Label15)
        Me.grpInfoVenda.Controls.Add(Me.Label8)
        Me.grpInfoVenda.Controls.Add(Me.Label1)
        Me.grpInfoVenda.Controls.Add(Me.btnConfirmarVenda)
        Me.grpInfoVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfoVenda.Location = New System.Drawing.Point(622, 209)
        Me.grpInfoVenda.Name = "grpInfoVenda"
        Me.grpInfoVenda.Size = New System.Drawing.Size(427, 235)
        Me.grpInfoVenda.TabIndex = 80
        Me.grpInfoVenda.TabStop = False
        Me.grpInfoVenda.Text = "Info.: Venda:: "
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Blue
        Me.Label26.Location = New System.Drawing.Point(-3, -13)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(434, 13)
        Me.Label26.TabIndex = 129
        Me.Label26.Text = "_____________________________________________________________"
        '
        'cboFormaPagamento
        '
        Me.cboFormaPagamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboFormaPagamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboFormaPagamento.BackColor = System.Drawing.SystemColors.Window
        Me.cboFormaPagamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFormaPagamento.FormattingEnabled = True
        Me.cboFormaPagamento.Items.AddRange(New Object() {"DN  - Dinheiro", "CTC - Cartão Crédito", "CTD - Cartão Débito", "PIX   - Pix", "TRA  - Transferencia"})
        Me.cboFormaPagamento.Location = New System.Drawing.Point(10, 141)
        Me.cboFormaPagamento.Name = "cboFormaPagamento"
        Me.cboFormaPagamento.Size = New System.Drawing.Size(198, 24)
        Me.cboFormaPagamento.TabIndex = 86
        '
        'cboEntregador
        '
        Me.cboEntregador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboEntregador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEntregador.BackColor = System.Drawing.SystemColors.Window
        Me.cboEntregador.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntregador.FormattingEnabled = True
        Me.cboEntregador.Location = New System.Drawing.Point(10, 91)
        Me.cboEntregador.Name = "cboEntregador"
        Me.cboEntregador.Size = New System.Drawing.Size(198, 24)
        Me.cboEntregador.TabIndex = 84
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Atendente:"
        '
        'txtValorDeliveryVenda
        '
        Me.txtValorDeliveryVenda.BackColor = System.Drawing.SystemColors.Window
        Me.txtValorDeliveryVenda.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorDeliveryVenda.ForeColor = System.Drawing.Color.Blue
        Me.txtValorDeliveryVenda.Location = New System.Drawing.Point(10, 194)
        Me.txtValorDeliveryVenda.MaxLength = 7
        Me.txtValorDeliveryVenda.Name = "txtValorDeliveryVenda"
        Me.txtValorDeliveryVenda.ReadOnly = True
        Me.txtValorDeliveryVenda.Size = New System.Drawing.Size(94, 26)
        Me.txtValorDeliveryVenda.TabIndex = 88
        Me.txtValorDeliveryVenda.Text = "0,00"
        Me.txtValorDeliveryVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValorTotDescVenda
        '
        Me.txtValorTotDescVenda.BackColor = System.Drawing.SystemColors.Window
        Me.txtValorTotDescVenda.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorTotDescVenda.ForeColor = System.Drawing.Color.Red
        Me.txtValorTotDescVenda.Location = New System.Drawing.Point(131, 194)
        Me.txtValorTotDescVenda.MaxLength = 7
        Me.txtValorTotDescVenda.Name = "txtValorTotDescVenda"
        Me.txtValorTotDescVenda.ReadOnly = True
        Me.txtValorTotDescVenda.Size = New System.Drawing.Size(110, 26)
        Me.txtValorTotDescVenda.TabIndex = 90
        Me.txtValorTotDescVenda.Text = "0,00"
        Me.txtValorTotDescVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(7, 174)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 16)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Delivery R$:"
        '
        'txtSubTotVenda
        '
        Me.txtSubTotVenda.BackColor = System.Drawing.SystemColors.Info
        Me.txtSubTotVenda.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotVenda.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtSubTotVenda.Location = New System.Drawing.Point(279, 68)
        Me.txtSubTotVenda.MaxLength = 7
        Me.txtSubTotVenda.Name = "txtSubTotVenda"
        Me.txtSubTotVenda.ReadOnly = True
        Me.txtSubTotVenda.Size = New System.Drawing.Size(134, 29)
        Me.txtSubTotVenda.TabIndex = 100
        Me.txtSubTotVenda.Text = "0,00"
        Me.txtSubTotVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValorTotalVenda
        '
        Me.txtValorTotalVenda.BackColor = System.Drawing.SystemColors.Info
        Me.txtValorTotalVenda.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorTotalVenda.ForeColor = System.Drawing.Color.Green
        Me.txtValorTotalVenda.Location = New System.Drawing.Point(279, 135)
        Me.txtValorTotalVenda.MaxLength = 7
        Me.txtValorTotalVenda.Name = "txtValorTotalVenda"
        Me.txtValorTotalVenda.ReadOnly = True
        Me.txtValorTotalVenda.Size = New System.Drawing.Size(134, 38)
        Me.txtValorTotalVenda.TabIndex = 102
        Me.txtValorTotalVenda.Text = "0,00"
        Me.txtValorTotalVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(128, 174)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 16)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Desc. Tot. R$:"
        '
        'cboAtendente
        '
        Me.cboAtendente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAtendente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAtendente.BackColor = System.Drawing.SystemColors.Window
        Me.cboAtendente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAtendente.FormattingEnabled = True
        Me.cboAtendente.Location = New System.Drawing.Point(10, 42)
        Me.cboAtendente.Name = "cboAtendente"
        Me.cboAtendente.Size = New System.Drawing.Size(198, 24)
        Me.cboAtendente.TabIndex = 82
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(276, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(106, 16)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Sub. Total R$:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 119)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(139, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Forma Pagamento:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(276, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Total Venda R$:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Entregador:"
        '
        'btnConfirmarVenda
        '
        Me.btnConfirmarVenda.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnConfirmarVenda.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnConfirmarVenda.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnConfirmarVenda.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnConfirmarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmarVenda.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnConfirmarVenda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnConfirmarVenda.Image = Global.AppOtica.My.Resources.Resources.ok_16x16
        Me.btnConfirmarVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirmarVenda.Location = New System.Drawing.Point(279, 183)
        Me.btnConfirmarVenda.Name = "btnConfirmarVenda"
        Me.btnConfirmarVenda.Size = New System.Drawing.Size(134, 37)
        Me.btnConfirmarVenda.TabIndex = 106
        Me.btnConfirmarVenda.Text = "&Confirmar [F7]"
        Me.btnConfirmarVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirmarVenda.UseVisualStyleBackColor = False
        '
        'grpProduto
        '
        Me.grpProduto.Controls.Add(Me.btnAdicionar)
        Me.grpProduto.Controls.Add(Me.Label4)
        Me.grpProduto.Controls.Add(Me.txtQtdeProd)
        Me.grpProduto.Controls.Add(Me.dtgProdVenda)
        Me.grpProduto.Controls.Add(Me.Label3)
        Me.grpProduto.Controls.Add(Me.txtTotProd)
        Me.grpProduto.Controls.Add(Me.txtDescValorProd)
        Me.grpProduto.Controls.Add(Me.txtDescProdPorcent)
        Me.grpProduto.Controls.Add(Me.Label13)
        Me.grpProduto.Controls.Add(Me.txtVlrProd)
        Me.grpProduto.Controls.Add(Me.Label12)
        Me.grpProduto.Controls.Add(Me.cboProduto)
        Me.grpProduto.Controls.Add(Me.Label11)
        Me.grpProduto.Controls.Add(Me.Label7)
        Me.grpProduto.Controls.Add(Me.Label5)
        Me.grpProduto.Controls.Add(Me.Label25)
        Me.grpProduto.Location = New System.Drawing.Point(11, 29)
        Me.grpProduto.Name = "grpProduto"
        Me.grpProduto.Size = New System.Drawing.Size(595, 415)
        Me.grpProduto.TabIndex = 10
        Me.grpProduto.TabStop = False
        Me.grpProduto.Text = "Produto:: "
        '
        'btnAdicionar
        '
        Me.btnAdicionar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdicionar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdicionar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnAdicionar.Image = Global.AppOtica.My.Resources.Resources.Add
        Me.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdicionar.Location = New System.Drawing.Point(456, 85)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(119, 37)
        Me.btnAdicionar.TabIndex = 24
        Me.btnAdicionar.Text = "&Adicionar"
        Me.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdicionar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkRed
        Me.Label4.Location = New System.Drawing.Point(15, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(249, 13)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "Clique 2x no produto na grade para Excluir"
        '
        'txtQtdeProd
        '
        Me.txtQtdeProd.BackColor = System.Drawing.SystemColors.Window
        Me.txtQtdeProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtdeProd.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtQtdeProd.Location = New System.Drawing.Point(19, 96)
        Me.txtQtdeProd.MaxLength = 7
        Me.txtQtdeProd.Name = "txtQtdeProd"
        Me.txtQtdeProd.Size = New System.Drawing.Size(58, 24)
        Me.txtQtdeProd.TabIndex = 14
        Me.txtQtdeProd.Text = "1"
        Me.txtQtdeProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtgProdVenda
        '
        Me.dtgProdVenda.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgProdVenda.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgProdVenda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgProdVenda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtgProdVenda.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgProdVenda.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgProdVenda.ColumnHeadersHeight = 30
        Me.dtgProdVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgProdVenda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProdV, Me.nomeProdV, Me.qtdeProdV, Me.valorProdV, Me.descontoProdV, Me.totalProdV})
        Me.dtgProdVenda.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgProdVenda.Location = New System.Drawing.Point(3, 180)
        Me.dtgProdVenda.MultiSelect = False
        Me.dtgProdVenda.Name = "dtgProdVenda"
        Me.dtgProdVenda.ReadOnly = True
        Me.dtgProdVenda.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtgProdVenda.RowHeadersVisible = False
        Me.dtgProdVenda.RowTemplate.Height = 38
        Me.dtgProdVenda.Size = New System.Drawing.Size(589, 232)
        Me.dtgProdVenda.TabIndex = 28
        '
        'IdProdV
        '
        Me.IdProdV.HeaderText = "Id"
        Me.IdProdV.Name = "IdProdV"
        Me.IdProdV.ReadOnly = True
        Me.IdProdV.Visible = False
        '
        'nomeProdV
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nomeProdV.DefaultCellStyle = DataGridViewCellStyle3
        Me.nomeProdV.HeaderText = "Produto"
        Me.nomeProdV.Name = "nomeProdV"
        Me.nomeProdV.ReadOnly = True
        Me.nomeProdV.Width = 260
        '
        'qtdeProdV
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle4.Format = "T"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.qtdeProdV.DefaultCellStyle = DataGridViewCellStyle4
        Me.qtdeProdV.HeaderText = "Qtde.:"
        Me.qtdeProdV.Name = "qtdeProdV"
        Me.qtdeProdV.ReadOnly = True
        Me.qtdeProdV.Width = 70
        '
        'valorProdV
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle5.Format = "T"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.valorProdV.DefaultCellStyle = DataGridViewCellStyle5
        Me.valorProdV.HeaderText = "Valor R$"
        Me.valorProdV.Name = "valorProdV"
        Me.valorProdV.ReadOnly = True
        Me.valorProdV.Width = 80
        '
        'descontoProdV
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descontoProdV.DefaultCellStyle = DataGridViewCellStyle6
        Me.descontoProdV.HeaderText = "Desc. R$:"
        Me.descontoProdV.Name = "descontoProdV"
        Me.descontoProdV.ReadOnly = True
        Me.descontoProdV.Width = 80
        '
        'totalProdV
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.totalProdV.DefaultCellStyle = DataGridViewCellStyle7
        Me.totalProdV.HeaderText = "Total R$"
        Me.totalProdV.Name = "totalProdV"
        Me.totalProdV.ReadOnly = True
        Me.totalProdV.Width = 90
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nome:"
        '
        'txtTotProd
        '
        Me.txtTotProd.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotProd.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotProd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtTotProd.Location = New System.Drawing.Point(476, 43)
        Me.txtTotProd.MaxLength = 7
        Me.txtTotProd.Name = "txtTotProd"
        Me.txtTotProd.ReadOnly = True
        Me.txtTotProd.Size = New System.Drawing.Size(99, 24)
        Me.txtTotProd.TabIndex = 22
        Me.txtTotProd.Text = "0,00"
        Me.txtTotProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescValorProd
        '
        Me.txtDescValorProd.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescValorProd.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescValorProd.ForeColor = System.Drawing.Color.Red
        Me.txtDescValorProd.Location = New System.Drawing.Point(336, 96)
        Me.txtDescValorProd.MaxLength = 7
        Me.txtDescValorProd.Name = "txtDescValorProd"
        Me.txtDescValorProd.ReadOnly = True
        Me.txtDescValorProd.Size = New System.Drawing.Size(73, 24)
        Me.txtDescValorProd.TabIndex = 20
        Me.txtDescValorProd.Text = "0,00"
        Me.txtDescValorProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescProdPorcent
        '
        Me.txtDescProdPorcent.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescProdPorcent.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescProdPorcent.ForeColor = System.Drawing.Color.Red
        Me.txtDescProdPorcent.Location = New System.Drawing.Point(228, 96)
        Me.txtDescProdPorcent.MaxLength = 7
        Me.txtDescProdPorcent.Name = "txtDescProdPorcent"
        Me.txtDescProdPorcent.ReadOnly = True
        Me.txtDescProdPorcent.Size = New System.Drawing.Size(73, 24)
        Me.txtDescProdPorcent.TabIndex = 18
        Me.txtDescProdPorcent.Text = "0,00"
        Me.txtDescProdPorcent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(473, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Total R$:"
        '
        'txtVlrProd
        '
        Me.txtVlrProd.BackColor = System.Drawing.SystemColors.Window
        Me.txtVlrProd.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVlrProd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtVlrProd.Location = New System.Drawing.Point(117, 95)
        Me.txtVlrProd.MaxLength = 7
        Me.txtVlrProd.Name = "txtVlrProd"
        Me.txtVlrProd.ReadOnly = True
        Me.txtVlrProd.Size = New System.Drawing.Size(73, 24)
        Me.txtVlrProd.TabIndex = 16
        Me.txtVlrProd.Text = "0,00"
        Me.txtVlrProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(333, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 17)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Desc. R$:"
        '
        'cboProduto
        '
        Me.cboProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProduto.BackColor = System.Drawing.SystemColors.Window
        Me.cboProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProduto.FormattingEnabled = True
        Me.cboProduto.Location = New System.Drawing.Point(19, 43)
        Me.cboProduto.Name = "cboProduto"
        Me.cboProduto.Size = New System.Drawing.Size(390, 24)
        Me.cboProduto.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(225, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 17)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Desc. %:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Qtde.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(114, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Valor R$:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkRed
        Me.Label25.Location = New System.Drawing.Point(20, 118)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(553, 13)
        Me.Label25.TabIndex = 129
        Me.Label25.Text = "______________________________________________________________________________"
        '
        'grpCliente
        '
        Me.grpCliente.Controls.Add(Me.chkGravarDados)
        Me.grpCliente.Controls.Add(Me.txtReferenciaCli)
        Me.grpCliente.Controls.Add(Me.Label21)
        Me.grpCliente.Controls.Add(Me.txtEstadoCli)
        Me.grpCliente.Controls.Add(Me.txtCidadeCli)
        Me.grpCliente.Controls.Add(Me.Label19)
        Me.grpCliente.Controls.Add(Me.Label24)
        Me.grpCliente.Controls.Add(Me.Label23)
        Me.grpCliente.Controls.Add(Me.Label22)
        Me.grpCliente.Controls.Add(Me.Label20)
        Me.grpCliente.Controls.Add(Me.txtCodCliente)
        Me.grpCliente.Controls.Add(Me.Label18)
        Me.grpCliente.Controls.Add(Me.cboBairro)
        Me.grpCliente.Controls.Add(Me.cboRua)
        Me.grpCliente.Controls.Add(Me.cboCliente)
        Me.grpCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCliente.ForeColor = System.Drawing.Color.MediumBlue
        Me.grpCliente.Location = New System.Drawing.Point(621, 30)
        Me.grpCliente.Name = "grpCliente"
        Me.grpCliente.Size = New System.Drawing.Size(427, 168)
        Me.grpCliente.TabIndex = 50
        Me.grpCliente.TabStop = False
        Me.grpCliente.Text = "Cliente:: "
        '
        'chkGravarDados
        '
        Me.chkGravarDados.AutoSize = True
        Me.chkGravarDados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGravarDados.Location = New System.Drawing.Point(315, 139)
        Me.chkGravarDados.Name = "chkGravarDados"
        Me.chkGravarDados.Size = New System.Drawing.Size(113, 19)
        Me.chkGravarDados.TabIndex = 2
        Me.chkGravarDados.Text = "Gravar Dados"
        Me.chkGravarDados.UseVisualStyleBackColor = True
        '
        'txtReferenciaCli
        '
        Me.txtReferenciaCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferenciaCli.Location = New System.Drawing.Point(150, 137)
        Me.txtReferenciaCli.Name = "txtReferenciaCli"
        Me.txtReferenciaCli.Size = New System.Drawing.Size(152, 21)
        Me.txtReferenciaCli.TabIndex = 64
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label21.Location = New System.Drawing.Point(147, 119)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 15)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Referencia:"
        '
        'txtEstadoCli
        '
        Me.txtEstadoCli.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstadoCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstadoCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstadoCli.Location = New System.Drawing.Point(370, 37)
        Me.txtEstadoCli.Name = "txtEstadoCli"
        Me.txtEstadoCli.Size = New System.Drawing.Size(51, 23)
        Me.txtEstadoCli.TabIndex = 56
        Me.txtEstadoCli.Text = "PI"
        Me.txtEstadoCli.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCidadeCli
        '
        Me.txtCidadeCli.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCidadeCli.Location = New System.Drawing.Point(10, 137)
        Me.txtCidadeCli.Name = "txtCidadeCli"
        Me.txtCidadeCli.Size = New System.Drawing.Size(122, 21)
        Me.txtCidadeCli.TabIndex = 62
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label19.Location = New System.Drawing.Point(381, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(25, 15)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "UF"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label24.Location = New System.Drawing.Point(258, 69)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(50, 15)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Bairro:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label23.Location = New System.Drawing.Point(7, 69)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 15)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Endereço:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label22.Location = New System.Drawing.Point(67, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 15)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Nome:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label20.Location = New System.Drawing.Point(10, 117)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 15)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Cidade:"
        '
        'txtCodCliente
        '
        Me.txtCodCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCliente.Location = New System.Drawing.Point(10, 37)
        Me.txtCodCliente.Name = "txtCodCliente"
        Me.txtCodCliente.ReadOnly = True
        Me.txtCodCliente.Size = New System.Drawing.Size(51, 23)
        Me.txtCodCliente.TabIndex = 52
        Me.txtCodCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label18.Location = New System.Drawing.Point(7, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 15)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Cod."
        '
        'cboBairro
        '
        Me.cboBairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBairro.BackColor = System.Drawing.SystemColors.Window
        Me.cboBairro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboBairro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBairro.FormattingEnabled = True
        Me.cboBairro.Location = New System.Drawing.Point(261, 84)
        Me.cboBairro.Name = "cboBairro"
        Me.cboBairro.Size = New System.Drawing.Size(160, 23)
        Me.cboBairro.TabIndex = 60
        '
        'cboRua
        '
        Me.cboRua.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRua.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRua.BackColor = System.Drawing.SystemColors.Window
        Me.cboRua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboRua.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRua.FormattingEnabled = True
        Me.cboRua.Location = New System.Drawing.Point(10, 84)
        Me.cboRua.Name = "cboRua"
        Me.cboRua.Size = New System.Drawing.Size(242, 23)
        Me.cboRua.TabIndex = 58
        '
        'cboCliente
        '
        Me.cboCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCliente.BackColor = System.Drawing.SystemColors.Window
        Me.cboCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(70, 37)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(281, 23)
        Me.cboCliente.TabIndex = 54
        '
        'tbpVizualizaVendas
        '
        Me.tbpVizualizaVendas.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
        Me.tbpVizualizaVendas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpVizualizaVendas.Controls.Add(Me.btnVoltar)
        Me.tbpVizualizaVendas.Controls.Add(Me.txtLocacoesExcedidas)
        Me.tbpVizualizaVendas.Controls.Add(Me.txtInfoLocacoes)
        Me.tbpVizualizaVendas.Controls.Add(Me.dtgVendas)
        Me.tbpVizualizaVendas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpVizualizaVendas.Location = New System.Drawing.Point(4, 22)
        Me.tbpVizualizaVendas.Name = "tbpVizualizaVendas"
        Me.tbpVizualizaVendas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpVizualizaVendas.Size = New System.Drawing.Size(1078, 501)
        Me.tbpVizualizaVendas.TabIndex = 1
        Me.tbpVizualizaVendas.Text = "VizualizaVendas"
        Me.tbpVizualizaVendas.UseVisualStyleBackColor = True
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnVoltar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnVoltar.Image = Global.AppOtica.My.Resources.Resources.Back
        Me.btnVoltar.Location = New System.Drawing.Point(16, 7)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(43, 30)
        Me.btnVoltar.TabIndex = 502
        Me.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'txtLocacoesExcedidas
        '
        Me.txtLocacoesExcedidas.BackColor = System.Drawing.Color.Beige
        Me.txtLocacoesExcedidas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLocacoesExcedidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocacoesExcedidas.ForeColor = System.Drawing.Color.Red
        Me.txtLocacoesExcedidas.Location = New System.Drawing.Point(317, 17)
        Me.txtLocacoesExcedidas.Name = "txtLocacoesExcedidas"
        Me.txtLocacoesExcedidas.ReadOnly = True
        Me.txtLocacoesExcedidas.Size = New System.Drawing.Size(231, 14)
        Me.txtLocacoesExcedidas.TabIndex = 128
        '
        'txtInfoLocacoes
        '
        Me.txtInfoLocacoes.BackColor = System.Drawing.Color.Beige
        Me.txtInfoLocacoes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInfoLocacoes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoLocacoes.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtInfoLocacoes.Location = New System.Drawing.Point(85, 17)
        Me.txtInfoLocacoes.Name = "txtInfoLocacoes"
        Me.txtInfoLocacoes.ReadOnly = True
        Me.txtInfoLocacoes.Size = New System.Drawing.Size(214, 14)
        Me.txtInfoLocacoes.TabIndex = 129
        '
        'dtgVendas
        '
        Me.dtgVendas.AllowUserToAddRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgVendas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgVendas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgVendas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtgVendas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgVendas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dtgVendas.ColumnHeadersHeight = 30
        Me.dtgVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgVendas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idLocacao, Me.VendaInfo, Me.valorVenda, Me.vendedor, Me.tempo, Me.DtgEntregador, Me.data, Me.Iniciado, Me.btnCancelar, Me.btn_Iniciar, Me.btnFinalizaTempo})
        Me.dtgVendas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgVendas.Location = New System.Drawing.Point(3, 103)
        Me.dtgVendas.MultiSelect = False
        Me.dtgVendas.Name = "dtgVendas"
        Me.dtgVendas.ReadOnly = True
        Me.dtgVendas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtgVendas.RowHeadersVisible = False
        Me.dtgVendas.RowTemplate.Height = 38
        Me.dtgVendas.Size = New System.Drawing.Size(1072, 395)
        Me.dtgVendas.TabIndex = 120
        '
        'idLocacao
        '
        Me.idLocacao.HeaderText = "Id"
        Me.idLocacao.Name = "idLocacao"
        Me.idLocacao.ReadOnly = True
        Me.idLocacao.Visible = False
        '
        'VendaInfo
        '
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.VendaInfo.DefaultCellStyle = DataGridViewCellStyle10
        Me.VendaInfo.HeaderText = "Informação da Venda"
        Me.VendaInfo.Name = "VendaInfo"
        Me.VendaInfo.ReadOnly = True
        Me.VendaInfo.Width = 330
        '
        'valorVenda
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle11.Format = "T"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.valorVenda.DefaultCellStyle = DataGridViewCellStyle11
        Me.valorVenda.HeaderText = "Valor Venda R$"
        Me.valorVenda.Name = "valorVenda"
        Me.valorVenda.ReadOnly = True
        Me.valorVenda.Width = 120
        '
        'vendedor
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle12.Format = "T"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.vendedor.DefaultCellStyle = DataGridViewCellStyle12
        Me.vendedor.HeaderText = "Vendedor"
        Me.vendedor.Name = "vendedor"
        Me.vendedor.ReadOnly = True
        Me.vendedor.Width = 120
        '
        'tempo
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tempo.DefaultCellStyle = DataGridViewCellStyle13
        Me.tempo.HeaderText = "Tempo"
        Me.tempo.Name = "tempo"
        Me.tempo.ReadOnly = True
        Me.tempo.Width = 110
        '
        'DtgEntregador
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        Me.DtgEntregador.DefaultCellStyle = DataGridViewCellStyle14
        Me.DtgEntregador.HeaderText = "Entregador"
        Me.DtgEntregador.Name = "DtgEntregador"
        Me.DtgEntregador.ReadOnly = True
        Me.DtgEntregador.Width = 120
        '
        'data
        '
        Me.data.HeaderText = "Data"
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.Visible = False
        '
        'Iniciado
        '
        Me.Iniciado.HeaderText = "dtg_iniciado"
        Me.Iniciado.Name = "Iniciado"
        Me.Iniciado.ReadOnly = True
        Me.Iniciado.Visible = False
        '
        'btnCancelar
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.DefaultCellStyle = DataGridViewCellStyle15
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.HeaderText = "   "
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.ReadOnly = True
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseColumnTextForButtonValue = True
        Me.btnCancelar.Width = 90
        '
        'btn_Iniciar
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn_Iniciar.DefaultCellStyle = DataGridViewCellStyle16
        Me.btn_Iniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Iniciar.HeaderText = ""
        Me.btn_Iniciar.Name = "btn_Iniciar"
        Me.btn_Iniciar.ReadOnly = True
        Me.btn_Iniciar.Text = "Iniciar"
        Me.btn_Iniciar.UseColumnTextForButtonValue = True
        Me.btn_Iniciar.Width = 90
        '
        'btnFinalizaTempo
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.Green
        Me.btnFinalizaTempo.DefaultCellStyle = DataGridViewCellStyle17
        Me.btnFinalizaTempo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFinalizaTempo.HeaderText = "   "
        Me.btnFinalizaTempo.Name = "btnFinalizaTempo"
        Me.btnFinalizaTempo.ReadOnly = True
        Me.btnFinalizaTempo.Text = "Finalizar!"
        Me.btnFinalizaTempo.UseColumnTextForButtonValue = True
        Me.btnFinalizaTempo.Width = 90
        '
        'FrmVendas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1086, 527)
        Me.Controls.Add(Me.tabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmVendas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendas"
        Me.tabControl.ResumeLayout(False)
        Me.tbpVenda.ResumeLayout(False)
        Me.tbpVenda.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.grpInfoVenda.ResumeLayout(False)
        Me.grpInfoVenda.PerformLayout()
        Me.grpProduto.ResumeLayout(False)
        Me.grpProduto.PerformLayout()
        CType(Me.dtgProdVenda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCliente.ResumeLayout(False)
        Me.grpCliente.PerformLayout()
        Me.tbpVizualizaVendas.ResumeLayout(False)
        Me.tbpVizualizaVendas.PerformLayout()
        CType(Me.dtgVendas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents pdRelatorio As System.Drawing.Printing.PrintDocument
    Friend WithEvents pdRelatorioComprovante As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog2 As System.Windows.Forms.PrintDialog
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tbpVenda As System.Windows.Forms.TabPage
    Friend WithEvents tbpVizualizaVendas As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btnConfirmarVenda As System.Windows.Forms.Button
    Friend WithEvents txtValorTotalVenda As System.Windows.Forms.TextBox
    Friend WithEvents txtQtdeProd As System.Windows.Forms.TextBox
    Friend WithEvents cboAtendente As System.Windows.Forms.ComboBox
    Friend WithEvents cboProduto As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtgProdVenda As System.Windows.Forms.DataGridView
    Friend WithEvents txtLocacoesExcedidas As System.Windows.Forms.TextBox
    Friend WithEvents txtInfoLocacoes As System.Windows.Forms.TextBox
    Friend WithEvents dtgVendas As System.Windows.Forms.DataGridView
    Public WithEvents btnVizualizaVendas As System.Windows.Forms.Button
    Public WithEvents btnVoltar As System.Windows.Forms.Button
    Friend WithEvents cboEntregador As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents btnAdicionar As System.Windows.Forms.Button
    Friend WithEvents grpProduto As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotProd As System.Windows.Forms.TextBox
    Friend WithEvents txtDescValorProd As System.Windows.Forms.TextBox
    Friend WithEvents txtDescProdPorcent As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtVlrProd As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grpInfoVenda As System.Windows.Forms.GroupBox
    Friend WithEvents cboFormaPagamento As System.Windows.Forms.ComboBox
    Friend WithEvents txtValorDeliveryVenda As System.Windows.Forms.TextBox
    Friend WithEvents txtValorTotDescVenda As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotVenda As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents grpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents chkGravarDados As System.Windows.Forms.CheckBox
    Friend WithEvents txtReferenciaCli As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtEstadoCli As System.Windows.Forms.TextBox
    Friend WithEvents txtCidadeCli As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtCodCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboBairro As System.Windows.Forms.ComboBox
    Friend WithEvents cboRua As System.Windows.Forms.ComboBox
    Friend WithEvents cboCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents IdProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nomeProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtdeProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descontoProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idLocacao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VendaInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorVenda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vendedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tempo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DtgEntregador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Iniciado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnCancelar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btn_Iniciar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnFinalizaTempo As System.Windows.Forms.DataGridViewButtonColumn
End Class
