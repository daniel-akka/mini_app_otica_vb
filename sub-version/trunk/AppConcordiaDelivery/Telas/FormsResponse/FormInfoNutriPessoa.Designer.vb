<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfoNutriPessoa
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.txtNomeCliente = New System.Windows.Forms.TextBox()
        Me.grbIMC = New System.Windows.Forms.GroupBox()
        Me.imgIMC = New System.Windows.Forms.PictureBox()
        Me.txtCausas = New System.Windows.Forms.TextBox()
        Me.txtClassificacao = New System.Windows.Forms.TextBox()
        Me.txtResultadoIMC = New System.Windows.Forms.TextBox()
        Me.txtAltura = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCalcularIMC = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProblema1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtProblema2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProblema3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProblema4 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboServico = New System.Windows.Forms.ComboBox()
        Me.cboProduto = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtgItensInfoNutri = New System.Windows.Forms.DataGridView()
        Me.idServDtg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servicoDtg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idProdDtg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prodDtg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.grbIMC.SuspendLayout()
        CType(Me.imgIMC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgItensInfoNutri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 20)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "PESSOA ::"
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtIdCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(23, 41)
        Me.txtIdCliente.MaxLength = 6
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(88, 26)
        Me.txtIdCliente.TabIndex = 4
        Me.txtIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNomeCliente
        '
        Me.txtNomeCliente.BackColor = System.Drawing.Color.LightYellow
        Me.txtNomeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomeCliente.Location = New System.Drawing.Point(117, 41)
        Me.txtNomeCliente.MaxLength = 40
        Me.txtNomeCliente.Name = "txtNomeCliente"
        Me.txtNomeCliente.ReadOnly = True
        Me.txtNomeCliente.Size = New System.Drawing.Size(442, 26)
        Me.txtNomeCliente.TabIndex = 6
        '
        'grbIMC
        '
        Me.grbIMC.BackColor = System.Drawing.Color.Transparent
        Me.grbIMC.Controls.Add(Me.imgIMC)
        Me.grbIMC.Controls.Add(Me.txtCausas)
        Me.grbIMC.Controls.Add(Me.txtClassificacao)
        Me.grbIMC.Controls.Add(Me.txtResultadoIMC)
        Me.grbIMC.Controls.Add(Me.txtAltura)
        Me.grbIMC.Controls.Add(Me.Label14)
        Me.grbIMC.Controls.Add(Me.Label13)
        Me.grbIMC.Controls.Add(Me.txtPeso)
        Me.grbIMC.Controls.Add(Me.Label16)
        Me.grbIMC.Controls.Add(Me.Label15)
        Me.grbIMC.Controls.Add(Me.Label18)
        Me.grbIMC.Controls.Add(Me.Label17)
        Me.grbIMC.Controls.Add(Me.Label12)
        Me.grbIMC.Controls.Add(Me.btnCalcularIMC)
        Me.grbIMC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbIMC.Location = New System.Drawing.Point(23, 82)
        Me.grbIMC.Name = "grbIMC"
        Me.grbIMC.Size = New System.Drawing.Size(656, 96)
        Me.grbIMC.TabIndex = 10
        Me.grbIMC.TabStop = False
        Me.grbIMC.Text = "IMC "
        '
        'imgIMC
        '
        Me.imgIMC.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgIMC.Location = New System.Drawing.Point(552, 16)
        Me.imgIMC.Name = "imgIMC"
        Me.imgIMC.Size = New System.Drawing.Size(101, 77)
        Me.imgIMC.TabIndex = 143
        Me.imgIMC.TabStop = False
        '
        'txtCausas
        '
        Me.txtCausas.BackColor = System.Drawing.SystemColors.Info
        Me.txtCausas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCausas.Location = New System.Drawing.Point(229, 67)
        Me.txtCausas.Name = "txtCausas"
        Me.txtCausas.ReadOnly = True
        Me.txtCausas.Size = New System.Drawing.Size(307, 21)
        Me.txtCausas.TabIndex = 1
        '
        'txtClassificacao
        '
        Me.txtClassificacao.BackColor = System.Drawing.SystemColors.Info
        Me.txtClassificacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClassificacao.Location = New System.Drawing.Point(9, 67)
        Me.txtClassificacao.Name = "txtClassificacao"
        Me.txtClassificacao.ReadOnly = True
        Me.txtClassificacao.Size = New System.Drawing.Size(194, 21)
        Me.txtClassificacao.TabIndex = 1
        '
        'txtResultadoIMC
        '
        Me.txtResultadoIMC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResultadoIMC.Location = New System.Drawing.Point(470, 22)
        Me.txtResultadoIMC.Name = "txtResultadoIMC"
        Me.txtResultadoIMC.Size = New System.Drawing.Size(66, 21)
        Me.txtResultadoIMC.TabIndex = 1
        Me.txtResultadoIMC.Text = "0,00"
        Me.txtResultadoIMC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAltura
        '
        Me.txtAltura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAltura.Location = New System.Drawing.Point(195, 22)
        Me.txtAltura.Name = "txtAltura"
        Me.txtAltura.Size = New System.Drawing.Size(66, 21)
        Me.txtAltura.TabIndex = 1
        Me.txtAltura.Text = "0,00"
        Me.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(431, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "IMC:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(149, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Altura:"
        '
        'txtPeso
        '
        Me.txtPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeso.Location = New System.Drawing.Point(51, 22)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(66, 21)
        Me.txtPeso.TabIndex = 1
        Me.txtPeso.Text = "0,000"
        Me.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(226, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Causas:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Classificação:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.DarkRed
        Me.Label18.Location = New System.Drawing.Point(262, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(21, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Mt"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DarkRed
        Me.Label17.Location = New System.Drawing.Point(117, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Kg"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Peso:"
        '
        'btnCalcularIMC
        '
        Me.btnCalcularIMC.BackColor = System.Drawing.Color.DarkRed
        Me.btnCalcularIMC.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnCalcularIMC.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCalcularIMC.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCalcularIMC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalcularIMC.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCalcularIMC.ForeColor = System.Drawing.Color.White
        Me.btnCalcularIMC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCalcularIMC.Location = New System.Drawing.Point(302, 17)
        Me.btnCalcularIMC.Name = "btnCalcularIMC"
        Me.btnCalcularIMC.Size = New System.Drawing.Size(104, 28)
        Me.btnCalcularIMC.TabIndex = 142
        Me.btnCalcularIMC.Text = "Calcular"
        Me.btnCalcularIMC.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 199)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Comorbidade 1º"
        '
        'txtProblema1
        '
        Me.txtProblema1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProblema1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProblema1.Location = New System.Drawing.Point(23, 214)
        Me.txtProblema1.Name = "txtProblema1"
        Me.txtProblema1.Size = New System.Drawing.Size(196, 23)
        Me.txtProblema1.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(249, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Comorbidade 2º"
        '
        'txtProblema2
        '
        Me.txtProblema2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProblema2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProblema2.Location = New System.Drawing.Point(252, 215)
        Me.txtProblema2.Name = "txtProblema2"
        Me.txtProblema2.Size = New System.Drawing.Size(196, 23)
        Me.txtProblema2.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(480, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Comorbidade 3º"
        '
        'txtProblema3
        '
        Me.txtProblema3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProblema3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProblema3.Location = New System.Drawing.Point(483, 215)
        Me.txtProblema3.Name = "txtProblema3"
        Me.txtProblema3.Size = New System.Drawing.Size(196, 23)
        Me.txtProblema3.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Comorbidade 4º"
        '
        'txtProblema4
        '
        Me.txtProblema4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProblema4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProblema4.Location = New System.Drawing.Point(23, 268)
        Me.txtProblema4.Name = "txtProblema4"
        Me.txtProblema4.Size = New System.Drawing.Size(196, 23)
        Me.txtProblema4.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(249, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Observação:"
        '
        'txtObservacao
        '
        Me.txtObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacao.Location = New System.Drawing.Point(252, 268)
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(427, 23)
        Me.txtObservacao.TabIndex = 48
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkRed
        Me.Label8.Location = New System.Drawing.Point(20, 309)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(659, 13)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Serviços e Produtos que não podem ser Usados:                                    " & _
    "                                                          "
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(575, 40)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(104, 28)
        Me.btnImprimir.TabIndex = 142
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 338)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 15)
        Me.Label9.TabIndex = 143
        Me.Label9.Text = "Serviço:"
        '
        'cboServico
        '
        Me.cboServico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboServico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboServico.BackColor = System.Drawing.SystemColors.Window
        Me.cboServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboServico.FormattingEnabled = True
        Me.cboServico.Location = New System.Drawing.Point(23, 357)
        Me.cboServico.Name = "cboServico"
        Me.cboServico.Size = New System.Drawing.Size(256, 23)
        Me.cboServico.TabIndex = 145
        '
        'cboProduto
        '
        Me.cboProduto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProduto.FormattingEnabled = True
        Me.cboProduto.Location = New System.Drawing.Point(318, 357)
        Me.cboProduto.Name = "cboProduto"
        Me.cboProduto.Size = New System.Drawing.Size(270, 23)
        Me.cboProduto.TabIndex = 146
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(315, 340)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 144
        Me.Label10.Text = "Produto:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(285, 358)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 147
        Me.Label11.Text = "     "
        '
        'dtgItensInfoNutri
        '
        Me.dtgItensInfoNutri.AllowUserToAddRows = False
        Me.dtgItensInfoNutri.AllowUserToResizeColumns = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.dtgItensInfoNutri.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dtgItensInfoNutri.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgItensInfoNutri.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dtgItensInfoNutri.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgItensInfoNutri.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgItensInfoNutri.ColumnHeadersHeight = 22
        Me.dtgItensInfoNutri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgItensInfoNutri.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idServDtg, Me.servicoDtg, Me.idProdDtg, Me.prodDtg})
        Me.dtgItensInfoNutri.Location = New System.Drawing.Point(22, 387)
        Me.dtgItensInfoNutri.MultiSelect = False
        Me.dtgItensInfoNutri.Name = "dtgItensInfoNutri"
        Me.dtgItensInfoNutri.ReadOnly = True
        Me.dtgItensInfoNutri.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtgItensInfoNutri.RowHeadersVisible = False
        Me.dtgItensInfoNutri.RowHeadersWidth = 22
        Me.dtgItensInfoNutri.RowTemplate.Height = 23
        Me.dtgItensInfoNutri.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dtgItensInfoNutri.Size = New System.Drawing.Size(657, 95)
        Me.dtgItensInfoNutri.TabIndex = 518
        '
        'idServDtg
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.MediumBlue
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.idServDtg.DefaultCellStyle = DataGridViewCellStyle9
        Me.idServDtg.HeaderText = "idServico"
        Me.idServDtg.Name = "idServDtg"
        Me.idServDtg.ReadOnly = True
        Me.idServDtg.Visible = False
        Me.idServDtg.Width = 125
        '
        'servicoDtg
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle10.Format = "T"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.servicoDtg.DefaultCellStyle = DataGridViewCellStyle10
        Me.servicoDtg.HeaderText = "Serviço"
        Me.servicoDtg.Name = "servicoDtg"
        Me.servicoDtg.ReadOnly = True
        Me.servicoDtg.Width = 320
        '
        'idProdDtg
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.DarkRed
        Me.idProdDtg.DefaultCellStyle = DataGridViewCellStyle11
        Me.idProdDtg.HeaderText = "idProd"
        Me.idProdDtg.Name = "idProdDtg"
        Me.idProdDtg.ReadOnly = True
        Me.idProdDtg.Visible = False
        Me.idProdDtg.Width = 125
        '
        'prodDtg
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.prodDtg.DefaultCellStyle = DataGridViewCellStyle12
        Me.prodDtg.HeaderText = "Produto"
        Me.prodDtg.Name = "prodDtg"
        Me.prodDtg.ReadOnly = True
        Me.prodDtg.Width = 320
        '
        'btnAdicionar
        '
        Me.btnAdicionar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdicionar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdicionar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnAdicionar.Image = Global.AppBarbearia.My.Resources.Resources.Add
        Me.btnAdicionar.Location = New System.Drawing.Point(599, 351)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(36, 29)
        Me.btnAdicionar.TabIndex = 519
        Me.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdicionar.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExcluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnExcluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExcluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnExcluir.Image = Global.AppBarbearia.My.Resources.Resources.Delete
        Me.btnExcluir.Location = New System.Drawing.Point(643, 351)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(36, 29)
        Me.btnExcluir.TabIndex = 519
        Me.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'FormInfoNutriPessoa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppBarbearia.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(699, 493)
        Me.Controls.Add(Me.btnExcluir)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.dtgItensInfoNutri)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboServico)
        Me.Controls.Add(Me.cboProduto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtProblema3)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtProblema2)
        Me.Controls.Add(Me.txtProblema4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtProblema1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grbIMC)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.txtNomeCliente)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormInfoNutriPessoa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informações de Saúde"
        Me.grbIMC.ResumeLayout(False)
        Me.grbIMC.PerformLayout()
        CType(Me.imgIMC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgItensInfoNutri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Public WithEvents txtNomeCliente As System.Windows.Forms.TextBox
    Friend WithEvents grbIMC As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProblema1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProblema2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProblema3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProblema4 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObservacao As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboServico As System.Windows.Forms.ComboBox
    Friend WithEvents cboProduto As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtgItensInfoNutri As System.Windows.Forms.DataGridView
    Public WithEvents btnAdicionar As System.Windows.Forms.Button
    Public WithEvents btnExcluir As System.Windows.Forms.Button
    Friend WithEvents idServDtg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents servicoDtg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idProdDtg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prodDtg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents imgIMC As System.Windows.Forms.PictureBox
    Friend WithEvents txtResultadoIMC As System.Windows.Forms.TextBox
    Friend WithEvents txtAltura As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnCalcularIMC As System.Windows.Forms.Button
    Friend WithEvents txtCausas As System.Windows.Forms.TextBox
    Friend WithEvents txtClassificacao As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
