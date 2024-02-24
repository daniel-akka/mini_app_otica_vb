<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuDespesaMensal
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdb_nenhuma = New System.Windows.Forms.RadioButton()
        Me.rdb_pagamento = New System.Windows.Forms.RadioButton()
        Me.rdb_emiss = New System.Windows.Forms.RadioButton()
        Me.dtpFim = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.txtObservacaoPesq = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDescrSubGrupoPesquisa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboGrupoDespPesquisa = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtgDespesaMensal = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txt_totais = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lbl_registros = New System.Windows.Forms.Label()
        Me.btnVizualizar = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_incluir = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.idDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idGrupoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nomegrupoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idSubGrupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descrsubgrupoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataEmissao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataPagamentoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorpadraoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.observacaoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechadoDTG = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.alteradoDTG = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dtgDespesaMensal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(254, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 24)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "::   DESPESAS MENSAL   ::"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.txtObservacaoPesq)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDescrSubGrupoPesquisa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboGrupoDespPesquisa)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 121)
        Me.GroupBox1.TabIndex = 73
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros: "
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.rdb_nenhuma)
        Me.GroupBox3.Controls.Add(Me.rdb_pagamento)
        Me.GroupBox3.Controls.Add(Me.rdb_emiss)
        Me.GroupBox3.Controls.Add(Me.dtpFim)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.dtpInicio)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(331, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(310, 60)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        '
        'rdb_nenhuma
        '
        Me.rdb_nenhuma.AutoSize = True
        Me.rdb_nenhuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_nenhuma.Location = New System.Drawing.Point(221, 39)
        Me.rdb_nenhuma.Name = "rdb_nenhuma"
        Me.rdb_nenhuma.Size = New System.Drawing.Size(49, 19)
        Me.rdb_nenhuma.TabIndex = 17
        Me.rdb_nenhuma.Text = "N/D"
        Me.rdb_nenhuma.UseVisualStyleBackColor = True
        '
        'rdb_pagamento
        '
        Me.rdb_pagamento.AutoSize = True
        Me.rdb_pagamento.Checked = True
        Me.rdb_pagamento.Location = New System.Drawing.Point(109, 39)
        Me.rdb_pagamento.Name = "rdb_pagamento"
        Me.rdb_pagamento.Size = New System.Drawing.Size(88, 17)
        Me.rdb_pagamento.TabIndex = 17
        Me.rdb_pagamento.TabStop = True
        Me.rdb_pagamento.Text = "Pagamento"
        Me.rdb_pagamento.UseVisualStyleBackColor = True
        '
        'rdb_emiss
        '
        Me.rdb_emiss.AutoSize = True
        Me.rdb_emiss.Location = New System.Drawing.Point(14, 39)
        Me.rdb_emiss.Name = "rdb_emiss"
        Me.rdb_emiss.Size = New System.Drawing.Size(71, 17)
        Me.rdb_emiss.TabIndex = 17
        Me.rdb_emiss.Text = "Emissão"
        Me.rdb_emiss.UseVisualStyleBackColor = True
        '
        'dtpFim
        '
        Me.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFim.Location = New System.Drawing.Point(199, 13)
        Me.dtpFim.Name = "dtpFim"
        Me.dtpFim.Size = New System.Drawing.Size(105, 20)
        Me.dtpFim.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(179, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "A"
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicio.Location = New System.Drawing.Point(70, 13)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(105, 20)
        Me.dtpInicio.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Periodo:"
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
        Me.btnImprimir.Image = Global.AppOtica.My.Resources.Resources.Imprime
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(673, 64)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(106, 46)
        Me.btnImprimir.TabIndex = 30
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.AppOtica.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(673, 17)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(106, 41)
        Me.btn_buscar.TabIndex = 20
        Me.btn_buscar.Text = "&Buscar F5"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'txtObservacaoPesq
        '
        Me.txtObservacaoPesq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacaoPesq.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacaoPesq.Location = New System.Drawing.Point(331, 88)
        Me.txtObservacaoPesq.Name = "txtObservacaoPesq"
        Me.txtObservacaoPesq.Size = New System.Drawing.Size(245, 23)
        Me.txtObservacaoPesq.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(328, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Observação:"
        '
        'txtDescrSubGrupoPesquisa
        '
        Me.txtDescrSubGrupoPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescrSubGrupoPesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescrSubGrupoPesquisa.Location = New System.Drawing.Point(24, 88)
        Me.txtDescrSubGrupoPesquisa.Name = "txtDescrSubGrupoPesquisa"
        Me.txtDescrSubGrupoPesquisa.Size = New System.Drawing.Size(270, 23)
        Me.txtDescrSubGrupoPesquisa.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descr. SubGrupo:"
        '
        'cboGrupoDespPesquisa
        '
        Me.cboGrupoDespPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupoDespPesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupoDespPesquisa.FormattingEnabled = True
        Me.cboGrupoDespPesquisa.Location = New System.Drawing.Point(24, 34)
        Me.cboGrupoDespPesquisa.Name = "cboGrupoDespPesquisa"
        Me.cboGrupoDespPesquisa.Size = New System.Drawing.Size(228, 23)
        Me.cboGrupoDespPesquisa.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Grupo:"
        '
        'dtgDespesaMensal
        '
        Me.dtgDespesaMensal.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgDespesaMensal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgDespesaMensal.BackgroundColor = System.Drawing.Color.Gray
        Me.dtgDespesaMensal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgDespesaMensal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgDespesaMensal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgDespesaMensal.ColumnHeadersHeight = 26
        Me.dtgDespesaMensal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgDespesaMensal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idDTG, Me.idGrupoDTG, Me.nomegrupoDTG, Me.idSubGrupo, Me.descrsubgrupoDTG, Me.dataEmissao, Me.dataPagamentoDTG, Me.valorpadraoDTG, Me.observacaoDTG, Me.fechadoDTG, Me.alteradoDTG})
        Me.dtgDespesaMensal.Location = New System.Drawing.Point(6, 258)
        Me.dtgDespesaMensal.Name = "dtgDespesaMensal"
        Me.dtgDespesaMensal.ReadOnly = True
        Me.dtgDespesaMensal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtgDespesaMensal.RowHeadersWidth = 20
        Me.dtgDespesaMensal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgDespesaMensal.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgDespesaMensal.Size = New System.Drawing.Size(806, 183)
        Me.dtgDespesaMensal.TabIndex = 91
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btn_excluir)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.btnVizualizar)
        Me.GroupBox2.Controls.Add(Me.btn_alterar)
        Me.GroupBox2.Controls.Add(Me.btn_incluir)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 191)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(792, 57)
        Me.GroupBox2.TabIndex = 92
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operações:"
        '
        'btn_excluir
        '
        Me.btn_excluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_excluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_excluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_excluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_excluir.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_excluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_excluir.Image = Global.AppOtica.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(422, 19)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(106, 32)
        Me.btn_excluir.TabIndex = 81
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_totais)
        Me.GroupBox4.Location = New System.Drawing.Point(675, 11)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(114, 42)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Totais R$"
        '
        'txt_totais
        '
        Me.txt_totais.BackColor = System.Drawing.SystemColors.Info
        Me.txt_totais.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totais.ForeColor = System.Drawing.Color.Red
        Me.txt_totais.Location = New System.Drawing.Point(6, 15)
        Me.txt_totais.MaxLength = 16
        Me.txt_totais.Name = "txt_totais"
        Me.txt_totais.ReadOnly = True
        Me.txt_totais.Size = New System.Drawing.Size(102, 23)
        Me.txt_totais.TabIndex = 15
        Me.txt_totais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lbl_registros)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(549, 11)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(114, 42)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Registros"
        '
        'lbl_registros
        '
        Me.lbl_registros.AutoSize = True
        Me.lbl_registros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_registros.ForeColor = System.Drawing.Color.Red
        Me.lbl_registros.Location = New System.Drawing.Point(42, 18)
        Me.lbl_registros.Name = "lbl_registros"
        Me.lbl_registros.Size = New System.Drawing.Size(15, 15)
        Me.lbl_registros.TabIndex = 0
        Me.lbl_registros.Text = "0"
        '
        'btnVizualizar
        '
        Me.btnVizualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnVizualizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnVizualizar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnVizualizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnVizualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVizualizar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnVizualizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnVizualizar.Image = Global.AppOtica.My.Resources.Resources.visualizar
        Me.btnVizualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVizualizar.Location = New System.Drawing.Point(287, 19)
        Me.btnVizualizar.Name = "btnVizualizar"
        Me.btnVizualizar.Size = New System.Drawing.Size(129, 32)
        Me.btnVizualizar.TabIndex = 12
        Me.btnVizualizar.Text = "Visualizar F9"
        Me.btnVizualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnVizualizar.UseVisualStyleBackColor = False
        '
        'btn_alterar
        '
        Me.btn_alterar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_alterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_alterar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_alterar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_alterar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_alterar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_alterar.Image = Global.AppOtica.My.Resources.Resources.editar
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(152, 19)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(129, 32)
        Me.btn_alterar.TabIndex = 11
        Me.btn_alterar.Text = "Alterar F3"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'btn_incluir
        '
        Me.btn_incluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_incluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_incluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_incluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_incluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_incluir.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_incluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_incluir.Image = Global.AppOtica.My.Resources.Resources.Add
        Me.btn_incluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_incluir.Location = New System.Drawing.Point(18, 19)
        Me.btn_incluir.Name = "btn_incluir"
        Me.btn_incluir.Size = New System.Drawing.Size(129, 32)
        Me.btn_incluir.TabIndex = 10
        Me.btn_incluir.Text = "Incluir F2"
        Me.btn_incluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_incluir.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkRed
        Me.Button3.Enabled = False
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.DarkRed
        Me.Button3.Location = New System.Drawing.Point(701, 51)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(17, 14)
        Me.Button3.TabIndex = 95
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumBlue
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(579, 51)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(17, 14)
        Me.Button1.TabIndex = 96
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(719, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 19)
        Me.Label9.TabIndex = 93
        Me.Label9.Text = "- Alterado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Location = New System.Drawing.Point(597, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 19)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "- Fechado"
        '
        'idDTG
        '
        Me.idDTG.HeaderText = "Id"
        Me.idDTG.MaxInputLength = 13
        Me.idDTG.Name = "idDTG"
        Me.idDTG.ReadOnly = True
        Me.idDTG.Visible = False
        '
        'idGrupoDTG
        '
        Me.idGrupoDTG.HeaderText = "idgrupo"
        Me.idGrupoDTG.Name = "idGrupoDTG"
        Me.idGrupoDTG.ReadOnly = True
        Me.idGrupoDTG.Visible = False
        '
        'nomegrupoDTG
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.nomegrupoDTG.DefaultCellStyle = DataGridViewCellStyle3
        Me.nomegrupoDTG.HeaderText = "Grupo"
        Me.nomegrupoDTG.MaxInputLength = 2
        Me.nomegrupoDTG.Name = "nomegrupoDTG"
        Me.nomegrupoDTG.ReadOnly = True
        Me.nomegrupoDTG.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nomegrupoDTG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nomegrupoDTG.Width = 180
        '
        'idSubGrupo
        '
        Me.idSubGrupo.HeaderText = "idSubGrupo"
        Me.idSubGrupo.Name = "idSubGrupo"
        Me.idSubGrupo.ReadOnly = True
        Me.idSubGrupo.Visible = False
        '
        'descrsubgrupoDTG
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.descrsubgrupoDTG.DefaultCellStyle = DataGridViewCellStyle4
        Me.descrsubgrupoDTG.HeaderText = "Sub. Grupo"
        Me.descrsubgrupoDTG.Name = "descrsubgrupoDTG"
        Me.descrsubgrupoDTG.ReadOnly = True
        Me.descrsubgrupoDTG.Width = 220
        '
        'dataEmissao
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dataEmissao.DefaultCellStyle = DataGridViewCellStyle5
        Me.dataEmissao.HeaderText = "Emissão"
        Me.dataEmissao.Name = "dataEmissao"
        Me.dataEmissao.ReadOnly = True
        Me.dataEmissao.Width = 130
        '
        'dataPagamentoDTG
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dataPagamentoDTG.DefaultCellStyle = DataGridViewCellStyle6
        Me.dataPagamentoDTG.HeaderText = "Pagamento"
        Me.dataPagamentoDTG.Name = "dataPagamentoDTG"
        Me.dataPagamentoDTG.ReadOnly = True
        Me.dataPagamentoDTG.Width = 110
        '
        'valorpadraoDTG
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.valorpadraoDTG.DefaultCellStyle = DataGridViewCellStyle7
        Me.valorpadraoDTG.HeaderText = "Valor $$"
        Me.valorpadraoDTG.Name = "valorpadraoDTG"
        Me.valorpadraoDTG.ReadOnly = True
        Me.valorpadraoDTG.Width = 90
        '
        'observacaoDTG
        '
        Me.observacaoDTG.HeaderText = "Observação"
        Me.observacaoDTG.Name = "observacaoDTG"
        Me.observacaoDTG.ReadOnly = True
        Me.observacaoDTG.Width = 200
        '
        'fechadoDTG
        '
        Me.fechadoDTG.HeaderText = "fechado"
        Me.fechadoDTG.Name = "fechadoDTG"
        Me.fechadoDTG.ReadOnly = True
        Me.fechadoDTG.Visible = False
        '
        'alteradoDTG
        '
        Me.alteradoDTG.HeaderText = "alterado"
        Me.alteradoDTG.Name = "alteradoDTG"
        Me.alteradoDTG.ReadOnly = True
        Me.alteradoDTG.Visible = False
        '
        'FrmMenuDespesaMensal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(819, 448)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dtgDespesaMensal)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMenuDespesaMensal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Despesa Mensal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dtgDespesaMensal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents txtDescrSubGrupoPesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboGrupoDespPesquisa As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtgDespesaMensal As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdb_nenhuma As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_pagamento As System.Windows.Forms.RadioButton
    Friend WithEvents rdb_emiss As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFim As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtObservacaoPesq As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_incluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btnVizualizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_registros As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_totais As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents idDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idGrupoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nomegrupoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idSubGrupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrsubgrupoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataEmissao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dataPagamentoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorpadraoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents observacaoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fechadoDTG As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents alteradoDTG As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
