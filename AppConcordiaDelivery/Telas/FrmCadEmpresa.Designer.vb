<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCadEmpresa
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboBairro = New System.Windows.Forms.ComboBox()
        Me.cboRua = New System.Windows.Forms.ComboBox()
        Me.grbCadCliente = New System.Windows.Forms.GroupBox()
        Me.mskTelefone = New System.Windows.Forms.MaskedTextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFantasia = New System.Windows.Forms.TextBox()
        Me.txtRazao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.dtg_empresas = New System.Windows.Forms.DataGridView()
        Me.dtgid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgrazao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgtelefone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgendereco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtgcidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_qtdRegistros = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.mskCnpjCpf = New System.Windows.Forms.MaskedTextBox()
        Me.rbCpf = New System.Windows.Forms.RadioButton()
        Me.rbCnpj = New System.Windows.Forms.RadioButton()
        Me.grbCadCliente.SuspendLayout()
        CType(Me.dtg_empresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboBairro
        '
        Me.cboBairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBairro.BackColor = System.Drawing.SystemColors.Window
        Me.cboBairro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboBairro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBairro.FormattingEnabled = True
        Me.cboBairro.Location = New System.Drawing.Point(286, 95)
        Me.cboBairro.Name = "cboBairro"
        Me.cboBairro.Size = New System.Drawing.Size(184, 23)
        Me.cboBairro.TabIndex = 29
        '
        'cboRua
        '
        Me.cboRua.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRua.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRua.BackColor = System.Drawing.SystemColors.Window
        Me.cboRua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboRua.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRua.FormattingEnabled = True
        Me.cboRua.Location = New System.Drawing.Point(14, 95)
        Me.cboRua.Name = "cboRua"
        Me.cboRua.Size = New System.Drawing.Size(251, 23)
        Me.cboRua.TabIndex = 27
        '
        'grbCadCliente
        '
        Me.grbCadCliente.BackColor = System.Drawing.Color.Transparent
        Me.grbCadCliente.Controls.Add(Me.mskCnpjCpf)
        Me.grbCadCliente.Controls.Add(Me.rbCpf)
        Me.grbCadCliente.Controls.Add(Me.rbCnpj)
        Me.grbCadCliente.Controls.Add(Me.cboBairro)
        Me.grbCadCliente.Controls.Add(Me.cboRua)
        Me.grbCadCliente.Controls.Add(Me.mskTelefone)
        Me.grbCadCliente.Controls.Add(Me.btnCancelar)
        Me.grbCadCliente.Controls.Add(Me.btnSalvar)
        Me.grbCadCliente.Controls.Add(Me.Label6)
        Me.grbCadCliente.Controls.Add(Me.txtFantasia)
        Me.grbCadCliente.Controls.Add(Me.txtRazao)
        Me.grbCadCliente.Controls.Add(Me.Label2)
        Me.grbCadCliente.Controls.Add(Me.Label3)
        Me.grbCadCliente.Controls.Add(Me.Label1)
        Me.grbCadCliente.Controls.Add(Me.Label9)
        Me.grbCadCliente.Controls.Add(Me.txtEstado)
        Me.grbCadCliente.Controls.Add(Me.txtCidade)
        Me.grbCadCliente.Controls.Add(Me.Label5)
        Me.grbCadCliente.Controls.Add(Me.Label4)
        Me.grbCadCliente.Location = New System.Drawing.Point(14, 254)
        Me.grbCadCliente.Name = "grbCadCliente"
        Me.grbCadCliente.Size = New System.Drawing.Size(739, 173)
        Me.grbCadCliente.TabIndex = 156
        Me.grbCadCliente.TabStop = False
        Me.grbCadCliente.Text = "Empresa: "
        '
        'mskTelefone
        '
        Me.mskTelefone.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.mskTelefone.Location = New System.Drawing.Point(508, 95)
        Me.mskTelefone.Mask = "(99) 0000-0000"
        Me.mskTelefone.Name = "mskTelefone"
        Me.mskTelefone.Size = New System.Drawing.Size(100, 23)
        Me.mskTelefone.TabIndex = 31
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnCancelar.Image = Global.AppBarbearia.My.Resources.Resources.cancelar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(626, 83)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 35)
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
        Me.btnSalvar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSalvar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnSalvar.Image = Global.AppBarbearia.My.Resources.Resources.Save
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(626, 44)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(106, 35)
        Me.btnSalvar.TabIndex = 114
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(283, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 15)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "Fantasia:"
        '
        'txtFantasia
        '
        Me.txtFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFantasia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFantasia.Location = New System.Drawing.Point(286, 44)
        Me.txtFantasia.MaxLength = 100
        Me.txtFantasia.Name = "txtFantasia"
        Me.txtFantasia.Size = New System.Drawing.Size(152, 23)
        Me.txtFantasia.TabIndex = 24
        '
        'txtRazao
        '
        Me.txtRazao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazao.Location = New System.Drawing.Point(14, 44)
        Me.txtRazao.MaxLength = 100
        Me.txtRazao.Name = "txtRazao"
        Me.txtRazao.Size = New System.Drawing.Size(251, 23)
        Me.txtRazao.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Razao:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(564, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 15)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "UF:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(445, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Cidade:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(505, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 15)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Telefone:"
        '
        'txtEstado
        '
        Me.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(567, 44)
        Me.txtEstado.MaxLength = 2
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(41, 23)
        Me.txtEstado.TabIndex = 37
        Me.txtEstado.Text = "PI"
        Me.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCidade
        '
        Me.txtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCidade.Location = New System.Drawing.Point(448, 44)
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.Size = New System.Drawing.Size(102, 23)
        Me.txtCidade.TabIndex = 35
        Me.txtCidade.Text = "PICOS"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(283, 77)
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
        Me.Label4.Location = New System.Drawing.Point(11, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Endereço:"
        '
        'txtId
        '
        Me.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(12, 12)
        Me.txtId.MaxLength = 3
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(48, 21)
        Me.txtId.TabIndex = 136
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtId.Visible = False
        '
        'dtg_empresas
        '
        Me.dtg_empresas.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_empresas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtg_empresas.BackgroundColor = System.Drawing.Color.Gray
        Me.dtg_empresas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtg_empresas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtg_empresas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_empresas.ColumnHeadersHeight = 26
        Me.dtg_empresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtg_empresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtgid, Me.dtgrazao, Me.dtgtelefone, Me.dtgendereco, Me.dtgcidade})
        Me.dtg_empresas.Location = New System.Drawing.Point(14, 137)
        Me.dtg_empresas.Name = "dtg_empresas"
        Me.dtg_empresas.ReadOnly = True
        Me.dtg_empresas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtg_empresas.RowHeadersWidth = 20
        Me.dtg_empresas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtg_empresas.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtg_empresas.RowTemplate.Height = 24
        Me.dtg_empresas.Size = New System.Drawing.Size(739, 110)
        Me.dtg_empresas.TabIndex = 155
        '
        'dtgid
        '
        Me.dtgid.HeaderText = "Id"
        Me.dtgid.MaxInputLength = 13
        Me.dtgid.Name = "dtgid"
        Me.dtgid.ReadOnly = True
        Me.dtgid.Visible = False
        '
        'dtgrazao
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgrazao.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgrazao.HeaderText = "Razao Social"
        Me.dtgrazao.MaxInputLength = 2
        Me.dtgrazao.Name = "dtgrazao"
        Me.dtgrazao.ReadOnly = True
        Me.dtgrazao.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgrazao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dtgrazao.Width = 240
        '
        'dtgtelefone
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgtelefone.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgtelefone.HeaderText = "Fantasia"
        Me.dtgtelefone.Name = "dtgtelefone"
        Me.dtgtelefone.ReadOnly = True
        Me.dtgtelefone.Width = 170
        '
        'dtgendereco
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.dtgendereco.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgendereco.HeaderText = "Endereço"
        Me.dtgendereco.Name = "dtgendereco"
        Me.dtgendereco.ReadOnly = True
        Me.dtgendereco.Width = 170
        '
        'dtgcidade
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dtgcidade.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgcidade.HeaderText = "Cidade"
        Me.dtgcidade.Name = "dtgcidade"
        Me.dtgcidade.ReadOnly = True
        Me.dtgcidade.Width = 120
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(600, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Registros:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_qtdRegistros)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(739, 37)
        Me.GroupBox1.TabIndex = 154
        Me.GroupBox1.TabStop = False
        '
        'txt_qtdRegistros
        '
        Me.txt_qtdRegistros.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_qtdRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_qtdRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtdRegistros.ForeColor = System.Drawing.Color.Red
        Me.txt_qtdRegistros.Location = New System.Drawing.Point(667, 13)
        Me.txt_qtdRegistros.MaxLength = 4
        Me.txt_qtdRegistros.Name = "txt_qtdRegistros"
        Me.txt_qtdRegistros.ReadOnly = True
        Me.txt_qtdRegistros.Size = New System.Drawing.Size(47, 17)
        Me.txt_qtdRegistros.TabIndex = 1
        Me.txt_qtdRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblCliente.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(226, 14)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(289, 23)
        Me.lblCliente.TabIndex = 152
        Me.lblCliente.Text = ":: CADASTRO DA EMPRESA ::"
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
        Me.btn_alterar.Image = Global.AppBarbearia.My.Resources.Resources.editar
        Me.btn_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_alterar.Location = New System.Drawing.Point(535, 58)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(106, 31)
        Me.btn_alterar.TabIndex = 150
        Me.btn_alterar.Text = "&Alterar F3"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
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
        Me.btn_excluir.Image = Global.AppBarbearia.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(647, 58)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(106, 31)
        Me.btn_excluir.TabIndex = 151
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
        Me.btn_novo.Image = Global.AppBarbearia.My.Resources.Resources.Add
        Me.btn_novo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_novo.Location = New System.Drawing.Point(423, 58)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(106, 31)
        Me.btn_novo.TabIndex = 149
        Me.btn_novo.Text = "&Novo F2"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = False
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(72, 63)
        Me.txt_pesquisa.MaxLength = 60
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(200, 23)
        Me.txt_pesquisa.TabIndex = 148
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 17)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "Nome:"
        '
        'mskCnpjCpf
        '
        Me.mskCnpjCpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.mskCnpjCpf.Location = New System.Drawing.Point(14, 143)
        Me.mskCnpjCpf.Mask = "00.000.000/0000-00"
        Me.mskCnpjCpf.Name = "mskCnpjCpf"
        Me.mskCnpjCpf.Size = New System.Drawing.Size(140, 23)
        Me.mskCnpjCpf.TabIndex = 33
        Me.mskCnpjCpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rbCpf
        '
        Me.rbCpf.AutoSize = True
        Me.rbCpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Bold)
        Me.rbCpf.Location = New System.Drawing.Point(92, 126)
        Me.rbCpf.Name = "rbCpf"
        Me.rbCpf.Size = New System.Drawing.Size(45, 16)
        Me.rbCpf.TabIndex = 120
        Me.rbCpf.Text = "CPF"
        Me.rbCpf.UseVisualStyleBackColor = True
        '
        'rbCnpj
        '
        Me.rbCnpj.AutoSize = True
        Me.rbCnpj.Checked = True
        Me.rbCnpj.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Bold)
        Me.rbCnpj.Location = New System.Drawing.Point(28, 126)
        Me.rbCnpj.Name = "rbCnpj"
        Me.rbCnpj.Size = New System.Drawing.Size(52, 16)
        Me.rbCnpj.TabIndex = 121
        Me.rbCnpj.TabStop = True
        Me.rbCnpj.Text = "CNPJ"
        Me.rbCnpj.UseVisualStyleBackColor = True
        '
        'FrmCadEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppBarbearia.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(770, 444)
        Me.Controls.Add(Me.grbCadCliente)
        Me.Controls.Add(Me.dtg_empresas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmCadEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro da Empresa"
        Me.grbCadCliente.ResumeLayout(False)
        Me.grbCadCliente.PerformLayout()
        CType(Me.dtg_empresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboBairro As System.Windows.Forms.ComboBox
    Friend WithEvents cboRua As System.Windows.Forms.ComboBox
    Friend WithEvents grbCadCliente As System.Windows.Forms.GroupBox
    Friend WithEvents mskTelefone As System.Windows.Forms.MaskedTextBox
    Public WithEvents btnCancelar As System.Windows.Forms.Button
    Public WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents txtRazao As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtCidade As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtg_empresas As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_qtdRegistros As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtgid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgrazao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgtelefone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgendereco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgcidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFantasia As System.Windows.Forms.TextBox
    Friend WithEvents mskCnpjCpf As System.Windows.Forms.MaskedTextBox
    Friend WithEvents rbCpf As System.Windows.Forms.RadioButton
    Friend WithEvents rbCnpj As System.Windows.Forms.RadioButton
End Class
