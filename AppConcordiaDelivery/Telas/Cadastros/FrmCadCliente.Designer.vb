<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCadCliente
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
        Me.mskTelefoneCli = New System.Windows.Forms.MaskedTextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.txt_qtdRegistros = New System.Windows.Forms.TextBox()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.txtNomeCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.dtg_clientes = New System.Windows.Forms.DataGridView()
        Me.dtgid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgnome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgtelefone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgendereco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgcidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estadoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grbCadCliente = New System.Windows.Forms.GroupBox()
        Me.txtCliApelido = New System.Windows.Forms.TextBox()
        Me.txtCliRG = New System.Windows.Forms.TextBox()
        Me.txt_codmun = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_cidade = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_cidade = New System.Windows.Forms.Label()
        Me.btnInfoSaudePessoa = New System.Windows.Forms.Button()
        Me.cbo_uf = New System.Windows.Forms.ComboBox()
        Me.lbl_uf = New System.Windows.Forms.Label()
        Me.rbCpf = New System.Windows.Forms.RadioButton()
        Me.rbCnpj = New System.Windows.Forms.RadioButton()
        Me.txtObservacao = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboBairroCli = New System.Windows.Forms.ComboBox()
        Me.cboRuaCli = New System.Windows.Forms.ComboBox()
        Me.mskDiaMes = New System.Windows.Forms.MaskedTextBox()
        Me.mskCep = New System.Windows.Forms.MaskedTextBox()
        Me.mskCnpjCpf = New System.Windows.Forms.MaskedTextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkInativos = New System.Windows.Forms.CheckBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDataPessoaPesq = New System.Windows.Forms.MaskedTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCpfCnpjPessoaPesq = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.cboCidadePesq = New System.Windows.Forms.ComboBox()
        Me.cboUfPesq = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbcCliente = New System.Windows.Forms.TabControl()
        Me.tbpPrincipal = New System.Windows.Forms.TabPage()
        Me.tbpAdicionais = New System.Windows.Forms.TabPage()
        Me.grpInfAdicionais = New System.Windows.Forms.GroupBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtCliLocalTrabalho = New System.Windows.Forms.TextBox()
        Me.txtCliApelidoCONJUGUE = New System.Windows.Forms.TextBox()
        Me.txtCliNomeConjugue = New System.Windows.Forms.TextBox()
        Me.txtCliMAE = New System.Windows.Forms.TextBox()
        Me.txtCliFuncTrabalho = New System.Windows.Forms.TextBox()
        Me.txtCliPAI = New System.Windows.Forms.TextBox()
        Me.txtCliOF = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCadCliente.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbcCliente.SuspendLayout()
        Me.tbpPrincipal.SuspendLayout()
        Me.tbpAdicionais.SuspendLayout()
        Me.grpInfAdicionais.SuspendLayout()
        Me.SuspendLayout()
        '
        'mskTelefoneCli
        '
        Me.mskTelefoneCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.mskTelefoneCli.Location = New System.Drawing.Point(878, 43)
        Me.mskTelefoneCli.Mask = "(99)0000-0000"
        Me.mskTelefoneCli.Name = "mskTelefoneCli"
        Me.mskTelefoneCli.Size = New System.Drawing.Size(91, 23)
        Me.mskTelefoneCli.TabIndex = 34
        '
        'txtId
        '
        Me.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(960, 12)
        Me.txtId.MaxLength = 3
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(48, 21)
        Me.txtId.TabIndex = 136
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtId.Visible = False
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblCliente.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(358, 14)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(282, 23)
        Me.lblCliente.TabIndex = 142
        Me.lblCliente.Text = ":: CADASTRO DE CLIENTE ::"
        '
        'btn_alterar
        '
        Me.btn_alterar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_alterar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_alterar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_alterar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_alterar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_alterar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_alterar.Image = Global.AppOtica.My.Resources.Resources.editar
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(790, 84)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(106, 31)
        Me.btn_alterar.TabIndex = 140
        Me.btn_alterar.Text = "&Alterar F3"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'txt_qtdRegistros
        '
        Me.txt_qtdRegistros.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_qtdRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_qtdRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtdRegistros.ForeColor = System.Drawing.Color.Red
        Me.txt_qtdRegistros.Location = New System.Drawing.Point(161, 13)
        Me.txt_qtdRegistros.MaxLength = 4
        Me.txt_qtdRegistros.Name = "txt_qtdRegistros"
        Me.txt_qtdRegistros.ReadOnly = True
        Me.txt_qtdRegistros.Size = New System.Drawing.Size(47, 17)
        Me.txt_qtdRegistros.TabIndex = 1
        Me.txt_qtdRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.btn_excluir.Location = New System.Drawing.Point(902, 84)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(106, 31)
        Me.btn_excluir.TabIndex = 141
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = False
        '
        'btn_novo
        '
        Me.btn_novo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_novo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btn_novo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_novo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_novo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_novo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_novo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btn_novo.Image = Global.AppOtica.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(678, 84)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(106, 31)
        Me.btn_novo.TabIndex = 139
        Me.btn_novo.Text = "&Novo F2"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = False
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(80, 19)
        Me.txt_pesquisa.MaxLength = 60
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(243, 23)
        Me.txt_pesquisa.TabIndex = 138
        '
        'txtNomeCliente
        '
        Me.txtNomeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomeCliente.Location = New System.Drawing.Point(14, 43)
        Me.txtNomeCliente.MaxLength = 100
        Me.txtNomeCliente.Name = "txtNomeCliente"
        Me.txtNomeCliente.Size = New System.Drawing.Size(309, 23)
        Me.txtNomeCliente.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Nome:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 17)
        Me.Label7.TabIndex = 143
        Me.Label7.Text = "Nome:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_qtdRegistros)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(678, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 37)
        Me.GroupBox1.TabIndex = 144
        Me.GroupBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(94, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Registros:"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnCancelar.Image = Global.AppOtica.My.Resources.Resources.cancelar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(774, 138)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 35)
        Me.btnCancelar.TabIndex = 117
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnSalvar
        '
        Me.btnSalvar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSalvar.Enabled = False
        Me.btnSalvar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalvar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnSalvar.Image = Global.AppOtica.My.Resources.Resources.Save
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(878, 138)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(91, 35)
        Me.btnSalvar.TabIndex = 114
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'dtg_clientes
        '
        Me.dtg_clientes.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_clientes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_clientes.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_clientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_clientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtg_clientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtg_clientes.ColumnHeadersHeight = 26
        Me.dtg_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_clientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtgid, Me.dtgnome, Me.dtgtelefone, Me.dtgendereco, Me.dtgcidade, Me.estadoDTG})
        Me.dtg_clientes.Location = New System.Drawing.Point(13, 157)
        Me.dtg_clientes.Name = "dtg_clientes"
        Me.dtg_clientes.ReadOnly = True
        Me.dtg_clientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtg_clientes.RowHeadersWidth = 20
        Me.dtg_clientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_clientes.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dtg_clientes.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtg_clientes.RowTemplate.Height = 24
        Me.dtg_clientes.Size = New System.Drawing.Size(995, 171)
        Me.dtg_clientes.TabIndex = 145
        '
        'dtgid
        '
        Me.dtgid.HeaderText = "Id"
        Me.dtgid.MaxInputLength = 13
        Me.dtgid.Name = "dtgid"
        Me.dtgid.ReadOnly = True
        Me.dtgid.Visible = False
        '
        'dtgnome
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgnome.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgnome.HeaderText = "Nome"
        Me.dtgnome.MaxInputLength = 2
        Me.dtgnome.Name = "dtgnome"
        Me.dtgnome.ReadOnly = True
        Me.dtgnome.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgnome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dtgnome.Width = 310
        '
        'dtgtelefone
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgtelefone.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgtelefone.HeaderText = "Telefone"
        Me.dtgtelefone.Name = "dtgtelefone"
        Me.dtgtelefone.ReadOnly = True
        Me.dtgtelefone.Width = 140
        '
        'dtgendereco
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dtgendereco.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgendereco.HeaderText = "Endereço"
        Me.dtgendereco.Name = "dtgendereco"
        Me.dtgendereco.ReadOnly = True
        Me.dtgendereco.Width = 250
        '
        'dtgcidade
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgcidade.DefaultCellStyle = DataGridViewCellStyle6
        Me.dtgcidade.HeaderText = "Cidade"
        Me.dtgcidade.Name = "dtgcidade"
        Me.dtgcidade.ReadOnly = True
        Me.dtgcidade.Width = 190
        '
        'estadoDTG
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.estadoDTG.DefaultCellStyle = DataGridViewCellStyle7
        Me.estadoDTG.HeaderText = "Estado"
        Me.estadoDTG.Name = "estadoDTG"
        Me.estadoDTG.ReadOnly = True
        Me.estadoDTG.Width = 65
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(875, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 15)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Telefone:"
        '
        'grbCadCliente
        '
        Me.grbCadCliente.BackColor = System.Drawing.Color.Transparent
        Me.grbCadCliente.Controls.Add(Me.txtCliApelido)
        Me.grbCadCliente.Controls.Add(Me.txtCliRG)
        Me.grbCadCliente.Controls.Add(Me.txt_codmun)
        Me.grbCadCliente.Controls.Add(Me.Label8)
        Me.grbCadCliente.Controls.Add(Me.cbo_cidade)
        Me.grbCadCliente.Controls.Add(Me.Label1)
        Me.grbCadCliente.Controls.Add(Me.lbl_cidade)
        Me.grbCadCliente.Controls.Add(Me.btnInfoSaudePessoa)
        Me.grbCadCliente.Controls.Add(Me.cbo_uf)
        Me.grbCadCliente.Controls.Add(Me.lbl_uf)
        Me.grbCadCliente.Controls.Add(Me.rbCpf)
        Me.grbCadCliente.Controls.Add(Me.rbCnpj)
        Me.grbCadCliente.Controls.Add(Me.txtObservacao)
        Me.grbCadCliente.Controls.Add(Me.txtEmail)
        Me.grbCadCliente.Controls.Add(Me.Label13)
        Me.grbCadCliente.Controls.Add(Me.Label11)
        Me.grbCadCliente.Controls.Add(Me.cboBairroCli)
        Me.grbCadCliente.Controls.Add(Me.cboRuaCli)
        Me.grbCadCliente.Controls.Add(Me.mskDiaMes)
        Me.grbCadCliente.Controls.Add(Me.mskCep)
        Me.grbCadCliente.Controls.Add(Me.mskCnpjCpf)
        Me.grbCadCliente.Controls.Add(Me.mskTelefoneCli)
        Me.grbCadCliente.Controls.Add(Me.btnCancelar)
        Me.grbCadCliente.Controls.Add(Me.btnSalvar)
        Me.grbCadCliente.Controls.Add(Me.txtNomeCliente)
        Me.grbCadCliente.Controls.Add(Me.Label20)
        Me.grbCadCliente.Controls.Add(Me.Label2)
        Me.grbCadCliente.Controls.Add(Me.Label9)
        Me.grbCadCliente.Controls.Add(Me.Label19)
        Me.grbCadCliente.Controls.Add(Me.Label12)
        Me.grbCadCliente.Controls.Add(Me.Label6)
        Me.grbCadCliente.Controls.Add(Me.Label5)
        Me.grbCadCliente.Controls.Add(Me.Label4)
        Me.grbCadCliente.Location = New System.Drawing.Point(7, 12)
        Me.grbCadCliente.Name = "grbCadCliente"
        Me.grbCadCliente.Size = New System.Drawing.Size(977, 182)
        Me.grbCadCliente.TabIndex = 146
        Me.grbCadCliente.TabStop = False
        Me.grbCadCliente.Text = "Cliente: "
        '
        'txtCliApelido
        '
        Me.txtCliApelido.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliApelido.Location = New System.Drawing.Point(346, 43)
        Me.txtCliApelido.Name = "txtCliApelido"
        Me.txtCliApelido.Size = New System.Drawing.Size(141, 23)
        Me.txtCliApelido.TabIndex = 24
        '
        'txtCliRG
        '
        Me.txtCliRG.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliRG.Location = New System.Drawing.Point(673, 43)
        Me.txtCliRG.Name = "txtCliRG"
        Me.txtCliRG.Size = New System.Drawing.Size(100, 23)
        Me.txtCliRG.TabIndex = 30
        '
        'txt_codmun
        '
        Me.txt_codmun.BackColor = System.Drawing.SystemColors.Info
        Me.txt_codmun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_codmun.Location = New System.Drawing.Point(878, 96)
        Me.txt_codmun.MaxLength = 7
        Me.txt_codmun.Name = "txt_codmun"
        Me.txt_codmun.ReadOnly = True
        Me.txt_codmun.Size = New System.Drawing.Size(91, 20)
        Me.txt_codmun.TabIndex = 400
        Me.txt_codmun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(875, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "CodMun.:"
        '
        'cbo_cidade
        '
        Me.cbo_cidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbo_cidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbo_cidade.DropDownWidth = 300
        Me.cbo_cidade.FormattingEnabled = True
        Me.cbo_cidade.Location = New System.Drawing.Point(645, 96)
        Me.cbo_cidade.Name = "cbo_cidade"
        Me.cbo_cidade.Size = New System.Drawing.Size(214, 21)
        Me.cbo_cidade.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(739, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Pressione [ ENTER ]"
        '
        'lbl_cidade
        '
        Me.lbl_cidade.AutoSize = True
        Me.lbl_cidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cidade.Location = New System.Drawing.Point(642, 80)
        Me.lbl_cidade.Name = "lbl_cidade"
        Me.lbl_cidade.Size = New System.Drawing.Size(50, 13)
        Me.lbl_cidade.TabIndex = 122
        Me.lbl_cidade.Text = "Cidade:"
        '
        'btnInfoSaudePessoa
        '
        Me.btnInfoSaudePessoa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnInfoSaudePessoa.Enabled = False
        Me.btnInfoSaudePessoa.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnInfoSaudePessoa.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnInfoSaudePessoa.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnInfoSaudePessoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInfoSaudePessoa.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoSaudePessoa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnInfoSaudePessoa.Image = Global.AppOtica.My.Resources.Resources.beat_heart_icon
        Me.btnInfoSaudePessoa.Location = New System.Drawing.Point(708, 141)
        Me.btnInfoSaudePessoa.Name = "btnInfoSaudePessoa"
        Me.btnInfoSaudePessoa.Size = New System.Drawing.Size(50, 31)
        Me.btnInfoSaudePessoa.TabIndex = 139
        Me.btnInfoSaudePessoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInfoSaudePessoa.UseVisualStyleBackColor = False
        '
        'cbo_uf
        '
        Me.cbo_uf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbo_uf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbo_uf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_uf.FormattingEnabled = True
        Me.cbo_uf.Location = New System.Drawing.Point(575, 96)
        Me.cbo_uf.Name = "cbo_uf"
        Me.cbo_uf.Size = New System.Drawing.Size(61, 21)
        Me.cbo_uf.TabIndex = 50
        '
        'lbl_uf
        '
        Me.lbl_uf.AutoSize = True
        Me.lbl_uf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_uf.Location = New System.Drawing.Point(572, 80)
        Me.lbl_uf.Name = "lbl_uf"
        Me.lbl_uf.Size = New System.Drawing.Size(27, 13)
        Me.lbl_uf.TabIndex = 121
        Me.lbl_uf.Text = "UF:"
        '
        'rbCpf
        '
        Me.rbCpf.AutoSize = True
        Me.rbCpf.Checked = True
        Me.rbCpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Bold)
        Me.rbCpf.Location = New System.Drawing.Point(592, 26)
        Me.rbCpf.Name = "rbCpf"
        Me.rbCpf.Size = New System.Drawing.Size(45, 16)
        Me.rbCpf.TabIndex = 119
        Me.rbCpf.TabStop = True
        Me.rbCpf.Text = "CPF"
        Me.rbCpf.UseVisualStyleBackColor = True
        '
        'rbCnpj
        '
        Me.rbCnpj.AutoSize = True
        Me.rbCnpj.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Bold)
        Me.rbCnpj.Location = New System.Drawing.Point(528, 26)
        Me.rbCnpj.Name = "rbCnpj"
        Me.rbCnpj.Size = New System.Drawing.Size(52, 16)
        Me.rbCnpj.TabIndex = 120
        Me.rbCnpj.Text = "CNPJ"
        Me.rbCnpj.UseVisualStyleBackColor = True
        '
        'txtObservacao
        '
        Me.txtObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacao.Location = New System.Drawing.Point(257, 150)
        Me.txtObservacao.Name = "txtObservacao"
        Me.txtObservacao.Size = New System.Drawing.Size(230, 21)
        Me.txtObservacao.TabIndex = 56
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(14, 149)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(216, 23)
        Me.txtEmail.TabIndex = 54
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(254, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 15)
        Me.Label13.TabIndex = 118
        Me.Label13.Text = "Observação:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 15)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "Email:"
        '
        'cboBairroCli
        '
        Me.cboBairroCli.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBairroCli.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBairroCli.BackColor = System.Drawing.SystemColors.Window
        Me.cboBairroCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboBairroCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBairroCli.FormattingEnabled = True
        Me.cboBairroCli.Location = New System.Drawing.Point(318, 97)
        Me.cboBairroCli.Name = "cboBairroCli"
        Me.cboBairroCli.Size = New System.Drawing.Size(152, 23)
        Me.cboBairroCli.TabIndex = 38
        '
        'cboRuaCli
        '
        Me.cboRuaCli.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRuaCli.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRuaCli.BackColor = System.Drawing.SystemColors.Window
        Me.cboRuaCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboRuaCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRuaCli.FormattingEnabled = True
        Me.cboRuaCli.Location = New System.Drawing.Point(14, 97)
        Me.cboRuaCli.Name = "cboRuaCli"
        Me.cboRuaCli.Size = New System.Drawing.Size(284, 23)
        Me.cboRuaCli.TabIndex = 36
        '
        'mskDiaMes
        '
        Me.mskDiaMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.mskDiaMes.Location = New System.Drawing.Point(798, 43)
        Me.mskDiaMes.Mask = "00/00"
        Me.mskDiaMes.Name = "mskDiaMes"
        Me.mskDiaMes.Size = New System.Drawing.Size(61, 23)
        Me.mskDiaMes.TabIndex = 32
        Me.mskDiaMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mskCep
        '
        Me.mskCep.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.mskCep.Location = New System.Drawing.Point(482, 97)
        Me.mskCep.Mask = "00000-000"
        Me.mskCep.Name = "mskCep"
        Me.mskCep.Size = New System.Drawing.Size(77, 23)
        Me.mskCep.TabIndex = 40
        '
        'mskCnpjCpf
        '
        Me.mskCnpjCpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.mskCnpjCpf.Location = New System.Drawing.Point(512, 43)
        Me.mskCnpjCpf.Mask = "000.000.000-00"
        Me.mskCnpjCpf.Name = "mskCnpjCpf"
        Me.mskCnpjCpf.Size = New System.Drawing.Size(144, 23)
        Me.mskCnpjCpf.TabIndex = 28
        Me.mskCnpjCpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(343, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 15)
        Me.Label20.TabIndex = 112
        Me.Label20.Text = "Apelido:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(670, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 15)
        Me.Label19.TabIndex = 111
        Me.Label19.Text = "RG:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(479, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 15)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "Cep:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(795, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "Dia/Mes:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(315, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 15)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Bairro:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Endereço:"
        '
        'chkInativos
        '
        Me.chkInativos.AutoSize = True
        Me.chkInativos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkInativos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInativos.Location = New System.Drawing.Point(403, 22)
        Me.chkInativos.Name = "chkInativos"
        Me.chkInativos.Size = New System.Drawing.Size(77, 18)
        Me.chkInativos.TabIndex = 147
        Me.chkInativos.Text = "Inativos"
        Me.chkInativos.UseVisualStyleBackColor = True
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
        Me.btnImprimir.Location = New System.Drawing.Point(902, 51)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(106, 29)
        Me.btnImprimir.TabIndex = 141
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtDataPessoaPesq)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtCpfCnpjPessoaPesq)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.btn_buscar)
        Me.GroupBox2.Controls.Add(Me.cboCidadePesq)
        Me.GroupBox2.Controls.Add(Me.cboUfPesq)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txt_pesquisa)
        Me.GroupBox2.Controls.Add(Me.chkInativos)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(591, 99)
        Me.GroupBox2.TabIndex = 148
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filtro(s): "
        '
        'txtDataPessoaPesq
        '
        Me.txtDataPessoaPesq.Location = New System.Drawing.Point(492, 71)
        Me.txtDataPessoaPesq.Mask = "00/00"
        Me.txtDataPessoaPesq.Name = "txtDataPessoaPesq"
        Me.txtDataPessoaPesq.Size = New System.Drawing.Size(56, 20)
        Me.txtDataPessoaPesq.TabIndex = 152
        Me.txtDataPessoaPesq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DarkRed
        Me.Label18.Location = New System.Drawing.Point(521, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(52, 13)
        Me.Label18.TabIndex = 150
        Me.Label18.Text = "Ex: 07/21"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(485, 55)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 150
        Me.Label17.Text = "Data:"
        '
        'txtCpfCnpjPessoaPesq
        '
        Me.txtCpfCnpjPessoaPesq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCpfCnpjPessoaPesq.Location = New System.Drawing.Point(345, 71)
        Me.txtCpfCnpjPessoaPesq.Name = "txtCpfCnpjPessoaPesq"
        Me.txtCpfCnpjPessoaPesq.Size = New System.Drawing.Size(123, 21)
        Me.txtCpfCnpjPessoaPesq.TabIndex = 151
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(344, 55)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 150
        Me.Label16.Text = "CPF / Cnpj:"
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.AppOtica.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(480, 13)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(93, 35)
        Me.btn_buscar.TabIndex = 149
        Me.btn_buscar.Text = "&Buscar F5"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'cboCidadePesq
        '
        Me.cboCidadePesq.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboCidadePesq.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboCidadePesq.FormattingEnabled = True
        Me.cboCidadePesq.Location = New System.Drawing.Point(113, 71)
        Me.cboCidadePesq.Name = "cboCidadePesq"
        Me.cboCidadePesq.Size = New System.Drawing.Size(210, 21)
        Me.cboCidadePesq.TabIndex = 148
        '
        'cboUfPesq
        '
        Me.cboUfPesq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUfPesq.FormattingEnabled = True
        Me.cboUfPesq.Location = New System.Drawing.Point(23, 71)
        Me.cboUfPesq.Name = "cboUfPesq"
        Me.cboUfPesq.Size = New System.Drawing.Size(65, 21)
        Me.cboUfPesq.TabIndex = 148
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DarkRed
        Me.Label15.Location = New System.Drawing.Point(202, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 13)
        Me.Label15.TabIndex = 122
        Me.Label15.Text = "Pressione [ ENTER ]"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(110, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 17)
        Me.Label14.TabIndex = 143
        Me.Label14.Text = "Cidade:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "UF:"
        '
        'tbcCliente
        '
        Me.tbcCliente.Controls.Add(Me.tbpPrincipal)
        Me.tbcCliente.Controls.Add(Me.tbpAdicionais)
        Me.tbcCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcCliente.Location = New System.Drawing.Point(12, 334)
        Me.tbcCliente.Name = "tbcCliente"
        Me.tbcCliente.SelectedIndex = 0
        Me.tbcCliente.Size = New System.Drawing.Size(1000, 234)
        Me.tbcCliente.TabIndex = 149
        '
        'tbpPrincipal
        '
        Me.tbpPrincipal.Controls.Add(Me.grbCadCliente)
        Me.tbpPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpPrincipal.Location = New System.Drawing.Point(4, 22)
        Me.tbpPrincipal.Name = "tbpPrincipal"
        Me.tbpPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPrincipal.Size = New System.Drawing.Size(992, 208)
        Me.tbpPrincipal.TabIndex = 0
        Me.tbpPrincipal.Text = "Principal"
        Me.tbpPrincipal.UseVisualStyleBackColor = True
        '
        'tbpAdicionais
        '
        Me.tbpAdicionais.Controls.Add(Me.grpInfAdicionais)
        Me.tbpAdicionais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbpAdicionais.Location = New System.Drawing.Point(4, 22)
        Me.tbpAdicionais.Name = "tbpAdicionais"
        Me.tbpAdicionais.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAdicionais.Size = New System.Drawing.Size(992, 208)
        Me.tbpAdicionais.TabIndex = 1
        Me.tbpAdicionais.Text = "Info. Adicionais"
        Me.tbpAdicionais.UseVisualStyleBackColor = True
        '
        'grpInfAdicionais
        '
        Me.grpInfAdicionais.Controls.Add(Me.Label24)
        Me.grpInfAdicionais.Controls.Add(Me.Label27)
        Me.grpInfAdicionais.Controls.Add(Me.Label22)
        Me.grpInfAdicionais.Controls.Add(Me.Label26)
        Me.grpInfAdicionais.Controls.Add(Me.Label23)
        Me.grpInfAdicionais.Controls.Add(Me.Label25)
        Me.grpInfAdicionais.Controls.Add(Me.Label21)
        Me.grpInfAdicionais.Controls.Add(Me.txtCliLocalTrabalho)
        Me.grpInfAdicionais.Controls.Add(Me.txtCliApelidoCONJUGUE)
        Me.grpInfAdicionais.Controls.Add(Me.txtCliNomeConjugue)
        Me.grpInfAdicionais.Controls.Add(Me.txtCliMAE)
        Me.grpInfAdicionais.Controls.Add(Me.txtCliFuncTrabalho)
        Me.grpInfAdicionais.Controls.Add(Me.txtCliPAI)
        Me.grpInfAdicionais.Controls.Add(Me.txtCliOF)
        Me.grpInfAdicionais.Controls.Add(Me.Label29)
        Me.grpInfAdicionais.Controls.Add(Me.Label28)
        Me.grpInfAdicionais.Location = New System.Drawing.Point(20, 26)
        Me.grpInfAdicionais.Name = "grpInfAdicionais"
        Me.grpInfAdicionais.Size = New System.Drawing.Size(952, 164)
        Me.grpInfAdicionais.TabIndex = 2
        Me.grpInfAdicionais.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(24, 81)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(114, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Local de Trabalho:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(557, 81)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(64, 13)
        Me.Label27.TabIndex = 0
        Me.Label27.Text = "Conjugue:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(223, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(29, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Pai:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(805, 81)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 13)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Apelido:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(608, 22)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(35, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Mae:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(319, 81)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 13)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Função:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(24, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(27, 13)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "OF:"
        '
        'txtCliLocalTrabalho
        '
        Me.txtCliLocalTrabalho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliLocalTrabalho.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliLocalTrabalho.Location = New System.Drawing.Point(27, 97)
        Me.txtCliLocalTrabalho.Name = "txtCliLocalTrabalho"
        Me.txtCliLocalTrabalho.Size = New System.Drawing.Size(273, 23)
        Me.txtCliLocalTrabalho.TabIndex = 78
        '
        'txtCliApelidoCONJUGUE
        '
        Me.txtCliApelidoCONJUGUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliApelidoCONJUGUE.Location = New System.Drawing.Point(808, 97)
        Me.txtCliApelidoCONJUGUE.Name = "txtCliApelidoCONJUGUE"
        Me.txtCliApelidoCONJUGUE.Size = New System.Drawing.Size(123, 23)
        Me.txtCliApelidoCONJUGUE.TabIndex = 84
        '
        'txtCliNomeConjugue
        '
        Me.txtCliNomeConjugue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliNomeConjugue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliNomeConjugue.Location = New System.Drawing.Point(560, 97)
        Me.txtCliNomeConjugue.Name = "txtCliNomeConjugue"
        Me.txtCliNomeConjugue.Size = New System.Drawing.Size(225, 23)
        Me.txtCliNomeConjugue.TabIndex = 82
        '
        'txtCliMAE
        '
        Me.txtCliMAE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliMAE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliMAE.Location = New System.Drawing.Point(611, 38)
        Me.txtCliMAE.Name = "txtCliMAE"
        Me.txtCliMAE.Size = New System.Drawing.Size(320, 23)
        Me.txtCliMAE.TabIndex = 76
        '
        'txtCliFuncTrabalho
        '
        Me.txtCliFuncTrabalho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliFuncTrabalho.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliFuncTrabalho.Location = New System.Drawing.Point(322, 97)
        Me.txtCliFuncTrabalho.Name = "txtCliFuncTrabalho"
        Me.txtCliFuncTrabalho.Size = New System.Drawing.Size(191, 23)
        Me.txtCliFuncTrabalho.TabIndex = 80
        '
        'txtCliPAI
        '
        Me.txtCliPAI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliPAI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliPAI.Location = New System.Drawing.Point(226, 38)
        Me.txtCliPAI.Name = "txtCliPAI"
        Me.txtCliPAI.Size = New System.Drawing.Size(320, 23)
        Me.txtCliPAI.TabIndex = 72
        '
        'txtCliOF
        '
        Me.txtCliOF.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliOF.Location = New System.Drawing.Point(27, 38)
        Me.txtCliOF.Name = "txtCliOF"
        Me.txtCliOF.Size = New System.Drawing.Size(149, 23)
        Me.txtCliOF.TabIndex = 70
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(301, 97)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(21, 13)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "__"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(787, 97)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(21, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "__"
        '
        'FrmCadCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1024, 581)
        Me.Controls.Add(Me.tbcCliente)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtg_clientes)
        Me.Controls.Add(Me.txtId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmCadCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de CLiente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtg_clientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCadCliente.ResumeLayout(False)
        Me.grbCadCliente.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbcCliente.ResumeLayout(False)
        Me.tbpPrincipal.ResumeLayout(False)
        Me.tbpAdicionais.ResumeLayout(False)
        Me.grpInfAdicionais.ResumeLayout(False)
        Me.grpInfAdicionais.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mskTelefoneCli As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents txt_qtdRegistros As System.Windows.Forms.TextBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents txtNomeCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents btnCancelar As System.Windows.Forms.Button
    Public WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents dtg_clientes As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grbCadCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboBairroCli As System.Windows.Forms.ComboBox
    Friend WithEvents cboRuaCli As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkInativos As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mskDiaMes As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskCnpjCpf As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents mskCep As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents txtObservacao As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rbCpf As System.Windows.Forms.RadioButton
    Friend WithEvents rbCnpj As System.Windows.Forms.RadioButton
    Friend WithEvents cbo_cidade As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_cidade As System.Windows.Forms.Label
    Public WithEvents cbo_uf As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_uf As System.Windows.Forms.Label
    Friend WithEvents txt_codmun As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCidadePesq As System.Windows.Forms.ComboBox
    Friend WithEvents cboUfPesq As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnInfoSaudePessoa As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCpfCnpjPessoaPesq As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtDataPessoaPesq As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbcCliente As System.Windows.Forms.TabControl
    Friend WithEvents tbpPrincipal As System.Windows.Forms.TabPage
    Friend WithEvents tbpAdicionais As System.Windows.Forms.TabPage
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCliRG As System.Windows.Forms.TextBox
    Friend WithEvents txtCliApelido As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents grpInfAdicionais As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtCliLocalTrabalho As System.Windows.Forms.TextBox
    Friend WithEvents txtCliApelidoCONJUGUE As System.Windows.Forms.TextBox
    Friend WithEvents txtCliNomeConjugue As System.Windows.Forms.TextBox
    Friend WithEvents txtCliMAE As System.Windows.Forms.TextBox
    Friend WithEvents txtCliFuncTrabalho As System.Windows.Forms.TextBox
    Friend WithEvents txtCliPAI As System.Windows.Forms.TextBox
    Friend WithEvents txtCliOF As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents dtgid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgnome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgtelefone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgendereco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgcidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estadoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
