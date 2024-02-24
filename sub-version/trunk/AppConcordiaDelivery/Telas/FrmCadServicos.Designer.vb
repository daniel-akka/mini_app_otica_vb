<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCadServicos
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CboServicos = New System.Windows.Forms.ComboBox()
        Me.txtIdServico = New System.Windows.Forms.TextBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDescricaoServico = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtgProdutoUsado = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgUsadoDeletar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnAddProdUsado = New System.Windows.Forms.Button()
        Me.txtQtdeProdUsado = New System.Windows.Forms.TextBox()
        Me.cboProdutoUsado = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDespCartaoPorcentagem = New System.Windows.Forms.TextBox()
        Me.txtDespCartaoDinheiro = New System.Windows.Forms.TextBox()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboAtendente = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgProdutoUsado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CboServicos
        '
        Me.CboServicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboServicos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CboServicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboServicos.FormattingEnabled = True
        Me.CboServicos.Location = New System.Drawing.Point(105, 85)
        Me.CboServicos.Name = "CboServicos"
        Me.CboServicos.Size = New System.Drawing.Size(275, 23)
        Me.CboServicos.TabIndex = 158
        '
        'txtIdServico
        '
        Me.txtIdServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdServico.Location = New System.Drawing.Point(421, 12)
        Me.txtIdServico.MaxLength = 3
        Me.txtIdServico.Name = "txtIdServico"
        Me.txtIdServico.ReadOnly = True
        Me.txtIdServico.Size = New System.Drawing.Size(35, 21)
        Me.txtIdServico.TabIndex = 157
        Me.txtIdServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdServico.Visible = False
        '
        'btnSalvar
        '
        Me.btnSalvar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSalvar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalvar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnSalvar.Image = Global.AppBarbearia.My.Resources.Resources.Save
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(351, 80)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(105, 34)
        Me.btnSalvar.TabIndex = 155
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(348, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "DEL=Excluir"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(102, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "F3=Alterar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(192, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 15)
        Me.Label6.TabIndex = 152
        Me.Label6.Text = "F5=Atualizar Consulta"
        '
        'txtDescricaoServico
        '
        Me.txtDescricaoServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescricaoServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescricaoServico.Location = New System.Drawing.Point(9, 39)
        Me.txtDescricaoServico.MaxLength = 100
        Me.txtDescricaoServico.Name = "txtDescricaoServico"
        Me.txtDescricaoServico.Size = New System.Drawing.Size(256, 21)
        Me.txtDescricaoServico.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 17)
        Me.Label4.TabIndex = 153
        Me.Label4.Text = "Serviços:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 15)
        Me.Label5.TabIndex = 154
        Me.Label5.Text = "Nome:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(87, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 20)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = ":: CADASTRO DE SERVIÇOS ::"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cboAtendente)
        Me.GroupBox1.Controls.Add(Me.dtgProdutoUsado)
        Me.GroupBox1.Controls.Add(Me.btnAddProdUsado)
        Me.GroupBox1.Controls.Add(Me.txtQtdeProdUsado)
        Me.GroupBox1.Controls.Add(Me.cboProdutoUsado)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.btnSalvar)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDespCartaoPorcentagem)
        Me.GroupBox1.Controls.Add(Me.txtDespCartaoDinheiro)
        Me.GroupBox1.Controls.Add(Me.txtValor)
        Me.GroupBox1.Controls.Add(Me.txtDescricaoServico)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(0, 114)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(472, 276)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Serviço: "
        '
        'dtgProdutoUsado
        '
        Me.dtgProdutoUsado.AllowUserToAddRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        Me.dtgProdutoUsado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgProdutoUsado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgProdutoUsado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dtgProdutoUsado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgProdutoUsado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgProdutoUsado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgProdutoUsado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.dtgUsadoDeletar})
        Me.dtgProdutoUsado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgProdutoUsado.Location = New System.Drawing.Point(3, 181)
        Me.dtgProdutoUsado.MultiSelect = False
        Me.dtgProdutoUsado.Name = "dtgProdutoUsado"
        Me.dtgProdutoUsado.ReadOnly = True
        Me.dtgProdutoUsado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtgProdutoUsado.RowHeadersVisible = False
        Me.dtgProdutoUsado.RowHeadersWidth = 23
        Me.dtgProdutoUsado.RowTemplate.Height = 23
        Me.dtgProdutoUsado.Size = New System.Drawing.Size(466, 92)
        Me.dtgProdutoUsado.TabIndex = 161
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn2.HeaderText = "Produto"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 270
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.Format = "T"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn3.HeaderText = "Qtde.:"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'dtgUsadoDeletar
        '
        Me.dtgUsadoDeletar.HeaderText = ""
        Me.dtgUsadoDeletar.Name = "dtgUsadoDeletar"
        Me.dtgUsadoDeletar.ReadOnly = True
        Me.dtgUsadoDeletar.Text = "Excluir"
        Me.dtgUsadoDeletar.UseColumnTextForButtonValue = True
        '
        'btnAddProdUsado
        '
        Me.btnAddProdUsado.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAddProdUsado.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnAddProdUsado.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAddProdUsado.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAddProdUsado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddProdUsado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddProdUsado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnAddProdUsado.Image = Global.AppBarbearia.My.Resources.Resources.Add
        Me.btnAddProdUsado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddProdUsado.Location = New System.Drawing.Point(392, 145)
        Me.btnAddProdUsado.Name = "btnAddProdUsado"
        Me.btnAddProdUsado.Size = New System.Drawing.Size(64, 29)
        Me.btnAddProdUsado.TabIndex = 160
        Me.btnAddProdUsado.Text = "&Add"
        Me.btnAddProdUsado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddProdUsado.UseVisualStyleBackColor = False
        '
        'txtQtdeProdUsado
        '
        Me.txtQtdeProdUsado.Location = New System.Drawing.Point(337, 153)
        Me.txtQtdeProdUsado.Name = "txtQtdeProdUsado"
        Me.txtQtdeProdUsado.Size = New System.Drawing.Size(45, 20)
        Me.txtQtdeProdUsado.TabIndex = 159
        Me.txtQtdeProdUsado.Text = "0"
        Me.txtQtdeProdUsado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboProdutoUsado
        '
        Me.cboProdutoUsado.FormattingEnabled = True
        Me.cboProdutoUsado.Location = New System.Drawing.Point(67, 153)
        Me.cboProdutoUsado.Name = "cboProdutoUsado"
        Me.cboProdutoUsado.Size = New System.Drawing.Size(198, 21)
        Me.cboProdutoUsado.TabIndex = 158
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label16.Location = New System.Drawing.Point(289, 156)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 13)
        Me.Label16.TabIndex = 156
        Me.Label16.Text = "Qtde.:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(6, 156)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 13)
        Me.Label12.TabIndex = 157
        Me.Label12.Text = "Produto:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(246, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 15)
        Me.Label9.TabIndex = 154
        Me.Label9.Text = "Desp. CT %:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(120, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 15)
        Me.Label8.TabIndex = 154
        Me.Label8.Text = "Desp. CT:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 154
        Me.Label7.Text = "Valor R$:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 125)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(372, 15)
        Me.Label10.TabIndex = 154
        Me.Label10.Text = "Produto Usados no Serviço::                                        [F3]"
        '
        'txtDespCartaoPorcentagem
        '
        Me.txtDespCartaoPorcentagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDespCartaoPorcentagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDespCartaoPorcentagem.ForeColor = System.Drawing.Color.Red
        Me.txtDespCartaoPorcentagem.Location = New System.Drawing.Point(249, 90)
        Me.txtDespCartaoPorcentagem.MaxLength = 100
        Me.txtDespCartaoPorcentagem.Name = "txtDespCartaoPorcentagem"
        Me.txtDespCartaoPorcentagem.Size = New System.Drawing.Size(82, 21)
        Me.txtDespCartaoPorcentagem.TabIndex = 36
        Me.txtDespCartaoPorcentagem.Text = "0,00"
        Me.txtDespCartaoPorcentagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDespCartaoDinheiro
        '
        Me.txtDespCartaoDinheiro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDespCartaoDinheiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDespCartaoDinheiro.ForeColor = System.Drawing.Color.Red
        Me.txtDespCartaoDinheiro.Location = New System.Drawing.Point(123, 90)
        Me.txtDespCartaoDinheiro.MaxLength = 100
        Me.txtDespCartaoDinheiro.Name = "txtDespCartaoDinheiro"
        Me.txtDespCartaoDinheiro.Size = New System.Drawing.Size(82, 21)
        Me.txtDespCartaoDinheiro.TabIndex = 34
        Me.txtDespCartaoDinheiro.Text = "0,00"
        Me.txtDespCartaoDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValor
        '
        Me.txtValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.Location = New System.Drawing.Point(9, 90)
        Me.txtValor.MaxLength = 100
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(82, 21)
        Me.txtValor.TabIndex = 32
        Me.txtValor.Text = "0,00"
        Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(375, 15)
        Me.Label11.TabIndex = 154
        Me.Label11.Text = "______________________________________________"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(24, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 15)
        Me.Label13.TabIndex = 151
        Me.Label13.Text = "F2=Novo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(301, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 15)
        Me.Label14.TabIndex = 154
        Me.Label14.Text = "Atendente:"
        '
        'cboAtendente
        '
        Me.cboAtendente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAtendente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAtendente.BackColor = System.Drawing.SystemColors.Window
        Me.cboAtendente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAtendente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAtendente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAtendente.FormattingEnabled = True
        Me.cboAtendente.Location = New System.Drawing.Point(304, 39)
        Me.cboAtendente.Name = "cboAtendente"
        Me.cboAtendente.Size = New System.Drawing.Size(152, 21)
        Me.cboAtendente.TabIndex = 162
        '
        'FrmCadServicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppBarbearia.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(472, 390)
        Me.Controls.Add(Me.CboServicos)
        Me.Controls.Add(Me.txtIdServico)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmCadServicos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Serviços"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgProdutoUsado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CboServicos As System.Windows.Forms.ComboBox
    Friend WithEvents txtIdServico As System.Windows.Forms.TextBox
    Public WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescricaoServico As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDespCartaoDinheiro As System.Windows.Forms.TextBox
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDespCartaoPorcentagem As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtgProdutoUsado As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgUsadoDeletar As System.Windows.Forms.DataGridViewButtonColumn
    Public WithEvents btnAddProdUsado As System.Windows.Forms.Button
    Friend WithEvents txtQtdeProdUsado As System.Windows.Forms.TextBox
    Friend WithEvents cboProdutoUsado As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboAtendente As System.Windows.Forms.ComboBox
End Class
