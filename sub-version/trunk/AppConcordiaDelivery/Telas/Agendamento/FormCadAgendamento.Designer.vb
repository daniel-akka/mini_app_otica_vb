<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCadAgendamento
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboInfomacao = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDataAgend = New System.Windows.Forms.DateTimePicker()
        Me.txtIDAgendamento = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_pedido = New System.Windows.Forms.Label()
        Me.rdbNoite = New System.Windows.Forms.RadioButton()
        Me.rdbTarde = New System.Windows.Forms.RadioButton()
        Me.rdbManha = New System.Windows.Forms.RadioButton()
        Me.grp_turno = New System.Windows.Forms.GroupBox()
        Me.grp_pedido = New System.Windows.Forms.GroupBox()
        Me.mskHora = New System.Windows.Forms.MaskedTextBox()
        Me.btnInfoSaudePessoa = New System.Windows.Forms.Button()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtNomeCliente = New System.Windows.Forms.TextBox()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.txtValorTotalAgend = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtgServicos = New System.Windows.Forms.DataGridView()
        Me.IdProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servicoV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qtdeProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalProdV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AtendenteServ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAtendente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comissaoatendente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servicoDespCartaoPorcent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servdespcartaovalor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtQtdeServico = New System.Windows.Forms.TextBox()
        Me.txtVlrServico = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtTotServico = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboAtendente = New System.Windows.Forms.ComboBox()
        Me.cboSevico = New System.Windows.Forms.ComboBox()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.grp_turno.SuspendLayout()
        Me.grp_pedido.SuspendLayout()
        CType(Me.dtgServicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(164, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(396, 35)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Agendamento de Atendimento"
        '
        'cboInfomacao
        '
        Me.cboInfomacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboInfomacao.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInfomacao.FormattingEnabled = True
        Me.cboInfomacao.Location = New System.Drawing.Point(18, 145)
        Me.cboInfomacao.Name = "cboInfomacao"
        Me.cboInfomacao.Size = New System.Drawing.Size(475, 25)
        Me.cboInfomacao.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Informação:"
        '
        'dtpDataAgend
        '
        Me.dtpDataAgend.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDataAgend.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDataAgend.Location = New System.Drawing.Point(519, 36)
        Me.dtpDataAgend.Name = "dtpDataAgend"
        Me.dtpDataAgend.Size = New System.Drawing.Size(101, 23)
        Me.dtpDataAgend.TabIndex = 13
        '
        'txtIDAgendamento
        '
        Me.txtIDAgendamento.BackColor = System.Drawing.SystemColors.Info
        Me.txtIDAgendamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDAgendamento.Location = New System.Drawing.Point(392, 36)
        Me.txtIDAgendamento.MaxLength = 8
        Me.txtIDAgendamento.Name = "txtIDAgendamento"
        Me.txtIDAgendamento.ReadOnly = True
        Me.txtIDAgendamento.Size = New System.Drawing.Size(101, 21)
        Me.txtIDAgendamento.TabIndex = 12
        Me.txtIDAgendamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(516, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 17)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Data:"
        '
        'lbl_pedido
        '
        Me.lbl_pedido.AutoSize = True
        Me.lbl_pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pedido.Location = New System.Drawing.Point(389, 14)
        Me.lbl_pedido.Name = "lbl_pedido"
        Me.lbl_pedido.Size = New System.Drawing.Size(100, 17)
        Me.lbl_pedido.TabIndex = 32
        Me.lbl_pedido.Text = "Agendamento:"
        '
        'rdbNoite
        '
        Me.rdbNoite.AutoSize = True
        Me.rdbNoite.Location = New System.Drawing.Point(158, 21)
        Me.rdbNoite.Name = "rdbNoite"
        Me.rdbNoite.Size = New System.Drawing.Size(59, 21)
        Me.rdbNoite.TabIndex = 0
        Me.rdbNoite.Text = "Noite"
        Me.rdbNoite.UseVisualStyleBackColor = True
        '
        'rdbTarde
        '
        Me.rdbTarde.AutoSize = True
        Me.rdbTarde.Location = New System.Drawing.Point(85, 22)
        Me.rdbTarde.Name = "rdbTarde"
        Me.rdbTarde.Size = New System.Drawing.Size(64, 21)
        Me.rdbTarde.TabIndex = 0
        Me.rdbTarde.Text = "Tarde"
        Me.rdbTarde.UseVisualStyleBackColor = True
        '
        'rdbManha
        '
        Me.rdbManha.AutoSize = True
        Me.rdbManha.Checked = True
        Me.rdbManha.Location = New System.Drawing.Point(8, 21)
        Me.rdbManha.Name = "rdbManha"
        Me.rdbManha.Size = New System.Drawing.Size(69, 21)
        Me.rdbManha.TabIndex = 0
        Me.rdbManha.TabStop = True
        Me.rdbManha.Text = "Manhã"
        Me.rdbManha.UseVisualStyleBackColor = True
        '
        'grp_turno
        '
        Me.grp_turno.Controls.Add(Me.rdbNoite)
        Me.grp_turno.Controls.Add(Me.rdbTarde)
        Me.grp_turno.Controls.Add(Me.rdbManha)
        Me.grp_turno.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_turno.Location = New System.Drawing.Point(519, 65)
        Me.grp_turno.Name = "grp_turno"
        Me.grp_turno.Size = New System.Drawing.Size(222, 50)
        Me.grp_turno.TabIndex = 17
        Me.grp_turno.TabStop = False
        Me.grp_turno.Text = "Turno: "
        '
        'grp_pedido
        '
        Me.grp_pedido.BackColor = System.Drawing.Color.Transparent
        Me.grp_pedido.Controls.Add(Me.mskHora)
        Me.grp_pedido.Controls.Add(Me.btnInfoSaudePessoa)
        Me.grp_pedido.Controls.Add(Me.txtIdCliente)
        Me.grp_pedido.Controls.Add(Me.Label22)
        Me.grp_pedido.Controls.Add(Me.txtNomeCliente)
        Me.grp_pedido.Controls.Add(Me.grp_turno)
        Me.grp_pedido.Controls.Add(Me.cboInfomacao)
        Me.grp_pedido.Controls.Add(Me.btnFinalizar)
        Me.grp_pedido.Controls.Add(Me.Label1)
        Me.grp_pedido.Controls.Add(Me.Label9)
        Me.grp_pedido.Controls.Add(Me.cboEmpresa)
        Me.grp_pedido.Controls.Add(Me.dtpDataAgend)
        Me.grp_pedido.Controls.Add(Me.txtValorTotalAgend)
        Me.grp_pedido.Controls.Add(Me.txtIDAgendamento)
        Me.grp_pedido.Controls.Add(Me.Label3)
        Me.grp_pedido.Controls.Add(Me.Label2)
        Me.grp_pedido.Controls.Add(Me.Label12)
        Me.grp_pedido.Controls.Add(Me.lbl_pedido)
        Me.grp_pedido.Location = New System.Drawing.Point(15, 57)
        Me.grp_pedido.Name = "grp_pedido"
        Me.grp_pedido.Size = New System.Drawing.Size(758, 181)
        Me.grp_pedido.TabIndex = 5
        Me.grp_pedido.TabStop = False
        '
        'mskHora
        '
        Me.mskHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskHora.Location = New System.Drawing.Point(519, 146)
        Me.mskHora.Mask = "00:00"
        Me.mskHora.Name = "mskHora"
        Me.mskHora.Size = New System.Drawing.Size(51, 24)
        Me.mskHora.TabIndex = 522
        Me.mskHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mskHora.ValidatingType = GetType(Date)
        '
        'btnInfoSaudePessoa
        '
        Me.btnInfoSaudePessoa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnInfoSaudePessoa.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnInfoSaudePessoa.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnInfoSaudePessoa.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnInfoSaudePessoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInfoSaudePessoa.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnInfoSaudePessoa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnInfoSaudePessoa.Image = Global.AppOtica.My.Resources.Resources.beat_heart_icon
        Me.btnInfoSaudePessoa.Location = New System.Drawing.Point(452, 86)
        Me.btnInfoSaudePessoa.Name = "btnInfoSaudePessoa"
        Me.btnInfoSaudePessoa.Size = New System.Drawing.Size(41, 29)
        Me.btnInfoSaudePessoa.TabIndex = 9
        Me.btnInfoSaudePessoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInfoSaudePessoa.UseVisualStyleBackColor = False
        '
        'txtIdCliente
        '
        Me.txtIdCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdCliente.Location = New System.Drawing.Point(18, 88)
        Me.txtIdCliente.MaxLength = 6
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(78, 26)
        Me.txtIdCliente.TabIndex = 2
        Me.txtIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label22.Location = New System.Drawing.Point(15, 71)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 15)
        Me.Label22.TabIndex = 521
        Me.Label22.Text = "Pessoa :"
        '
        'txtNomeCliente
        '
        Me.txtNomeCliente.BackColor = System.Drawing.Color.LightYellow
        Me.txtNomeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomeCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomeCliente.Location = New System.Drawing.Point(108, 88)
        Me.txtNomeCliente.MaxLength = 40
        Me.txtNomeCliente.Name = "txtNomeCliente"
        Me.txtNomeCliente.ReadOnly = True
        Me.txtNomeCliente.Size = New System.Drawing.Size(339, 26)
        Me.txtNomeCliente.TabIndex = 3
        '
        'btnFinalizar
        '
        Me.btnFinalizar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnFinalizar.Enabled = False
        Me.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnFinalizar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnFinalizar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFinalizar.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnFinalizar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnFinalizar.Image = Global.AppOtica.My.Resources.Resources.Save
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(609, 133)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(132, 37)
        Me.btnFinalizar.TabIndex = 20
        Me.btnFinalizar.Text = "&Finalizar! F7"
        Me.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFinalizar.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 17)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Empresa :"
        '
        'cboEmpresa
        '
        Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa.DropDownWidth = 150
        Me.cboEmpresa.Enabled = False
        Me.cboEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpresa.FormattingEnabled = True
        Me.cboEmpresa.Items.AddRange(New Object() {"01", "02", "03", "04", "05"})
        Me.cboEmpresa.Location = New System.Drawing.Point(17, 34)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(338, 24)
        Me.cboEmpresa.TabIndex = 10
        '
        'txtValorTotalAgend
        '
        Me.txtValorTotalAgend.BackColor = System.Drawing.SystemColors.Info
        Me.txtValorTotalAgend.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorTotalAgend.Location = New System.Drawing.Point(640, 33)
        Me.txtValorTotalAgend.MaxLength = 8
        Me.txtValorTotalAgend.Name = "txtValorTotalAgend"
        Me.txtValorTotalAgend.ReadOnly = True
        Me.txtValorTotalAgend.Size = New System.Drawing.Size(101, 26)
        Me.txtValorTotalAgend.TabIndex = 14
        Me.txtValorTotalAgend.Text = "0,00"
        Me.txtValorTotalAgend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(637, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 17)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Total G. R$:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(516, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 17)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Hora:"
        '
        'txtOperador
        '
        Me.txtOperador.BackColor = System.Drawing.SystemColors.Info
        Me.txtOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperador.ForeColor = System.Drawing.Color.Red
        Me.txtOperador.Location = New System.Drawing.Point(626, 35)
        Me.txtOperador.MaxLength = 10
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.ReadOnly = True
        Me.txtOperador.Size = New System.Drawing.Size(130, 21)
        Me.txtOperador.TabIndex = 300
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(623, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 17)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Op.:"
        '
        'dtgServicos
        '
        Me.dtgServicos.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dtgServicos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgServicos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgServicos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dtgServicos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgServicos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgServicos.ColumnHeadersHeight = 25
        Me.dtgServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgServicos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProdV, Me.servicoV, Me.qtdeProdV, Me.valorProdV, Me.totalProdV, Me.AtendenteServ, Me.idAtendente, Me.comissaoatendente, Me.servicoDespCartaoPorcent, Me.servdespcartaovalor})
        Me.dtgServicos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgServicos.Location = New System.Drawing.Point(0, 358)
        Me.dtgServicos.MultiSelect = False
        Me.dtgServicos.Name = "dtgServicos"
        Me.dtgServicos.ReadOnly = True
        Me.dtgServicos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtgServicos.RowHeadersVisible = False
        Me.dtgServicos.RowHeadersWidth = 35
        Me.dtgServicos.RowTemplate.Height = 25
        Me.dtgServicos.Size = New System.Drawing.Size(785, 107)
        Me.dtgServicos.TabIndex = 90
        '
        'IdProdV
        '
        Me.IdProdV.HeaderText = "Id"
        Me.IdProdV.Name = "IdProdV"
        Me.IdProdV.ReadOnly = True
        Me.IdProdV.Visible = False
        '
        'servicoV
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.servicoV.DefaultCellStyle = DataGridViewCellStyle3
        Me.servicoV.HeaderText = "Serviço"
        Me.servicoV.Name = "servicoV"
        Me.servicoV.ReadOnly = True
        Me.servicoV.Width = 305
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Format = "T"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.valorProdV.DefaultCellStyle = DataGridViewCellStyle5
        Me.valorProdV.HeaderText = "Valor"
        Me.valorProdV.Name = "valorProdV"
        Me.valorProdV.ReadOnly = True
        Me.valorProdV.Width = 90
        '
        'totalProdV
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Green
        Me.totalProdV.DefaultCellStyle = DataGridViewCellStyle6
        Me.totalProdV.HeaderText = "Total R$"
        Me.totalProdV.Name = "totalProdV"
        Me.totalProdV.ReadOnly = True
        Me.totalProdV.Width = 120
        '
        'AtendenteServ
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold)
        Me.AtendenteServ.DefaultCellStyle = DataGridViewCellStyle7
        Me.AtendenteServ.HeaderText = "Atendente"
        Me.AtendenteServ.Name = "AtendenteServ"
        Me.AtendenteServ.ReadOnly = True
        Me.AtendenteServ.Width = 180
        '
        'idAtendente
        '
        Me.idAtendente.HeaderText = "idAtendente"
        Me.idAtendente.Name = "idAtendente"
        Me.idAtendente.ReadOnly = True
        Me.idAtendente.Visible = False
        '
        'comissaoatendente
        '
        Me.comissaoatendente.HeaderText = "atendentecomissao"
        Me.comissaoatendente.Name = "comissaoatendente"
        Me.comissaoatendente.ReadOnly = True
        Me.comissaoatendente.Visible = False
        '
        'servicoDespCartaoPorcent
        '
        Me.servicoDespCartaoPorcent.HeaderText = "servdespesacartaoporcent"
        Me.servicoDespCartaoPorcent.Name = "servicoDespCartaoPorcent"
        Me.servicoDespCartaoPorcent.ReadOnly = True
        Me.servicoDespCartaoPorcent.Visible = False
        '
        'servdespcartaovalor
        '
        Me.servdespcartaovalor.HeaderText = "servdespcartaovalor"
        Me.servdespcartaovalor.Name = "servdespcartaovalor"
        Me.servdespcartaovalor.ReadOnly = True
        Me.servdespcartaovalor.Visible = False
        '
        'txtQtdeServico
        '
        Me.txtQtdeServico.BackColor = System.Drawing.SystemColors.Window
        Me.txtQtdeServico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtdeServico.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtQtdeServico.Location = New System.Drawing.Point(29, 321)
        Me.txtQtdeServico.MaxLength = 7
        Me.txtQtdeServico.Name = "txtQtdeServico"
        Me.txtQtdeServico.Size = New System.Drawing.Size(50, 24)
        Me.txtQtdeServico.TabIndex = 52
        Me.txtQtdeServico.Text = "1"
        Me.txtQtdeServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtVlrServico
        '
        Me.txtVlrServico.BackColor = System.Drawing.SystemColors.Window
        Me.txtVlrServico.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVlrServico.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtVlrServico.Location = New System.Drawing.Point(98, 321)
        Me.txtVlrServico.MaxLength = 7
        Me.txtVlrServico.Name = "txtVlrServico"
        Me.txtVlrServico.Size = New System.Drawing.Size(77, 24)
        Me.txtVlrServico.TabIndex = 54
        Me.txtVlrServico.Text = "0,00"
        Me.txtVlrServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 302)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 15)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Qtde.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(95, 301)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Valor R$:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DarkRed
        Me.Label25.Location = New System.Drawing.Point(11, 342)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(567, 13)
        Me.Label25.TabIndex = 136
        Me.Label25.Text = "________________________________________________________________________________"
        '
        'txtTotServico
        '
        Me.txtTotServico.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotServico.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotServico.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtTotServico.Location = New System.Drawing.Point(223, 321)
        Me.txtTotServico.MaxLength = 7
        Me.txtTotServico.Name = "txtTotServico"
        Me.txtTotServico.ReadOnly = True
        Me.txtTotServico.Size = New System.Drawing.Size(90, 24)
        Me.txtTotServico.TabIndex = 56
        Me.txtTotServico.Text = "0,00"
        Me.txtTotServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(220, 302)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 15)
        Me.Label13.TabIndex = 137
        Me.Label13.Text = "Total R$:"
        '
        'btnAdicionar
        '
        Me.btnAdicionar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdicionar.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdicionar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnAdicionar.Image = Global.AppOtica.My.Resources.Resources.Add
        Me.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdicionar.Location = New System.Drawing.Point(444, 314)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(134, 32)
        Me.btnAdicionar.TabIndex = 60
        Me.btnAdicionar.Text = "&Adicionar F2"
        Me.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdicionar.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(189, 321)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 24)
        Me.Label8.TabIndex = 130
        Me.Label8.Text = "="
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(405, 250)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 15)
        Me.Label10.TabIndex = 140
        Me.Label10.Text = "Atendente:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(26, 250)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 15)
        Me.Label11.TabIndex = 141
        Me.Label11.Text = "Serviço:"
        '
        'cboAtendente
        '
        Me.cboAtendente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAtendente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAtendente.BackColor = System.Drawing.SystemColors.Window
        Me.cboAtendente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAtendente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAtendente.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAtendente.FormattingEnabled = True
        Me.cboAtendente.Location = New System.Drawing.Point(408, 268)
        Me.cboAtendente.Name = "cboAtendente"
        Me.cboAtendente.Size = New System.Drawing.Size(170, 24)
        Me.cboAtendente.TabIndex = 58
        '
        'cboSevico
        '
        Me.cboSevico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSevico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSevico.BackColor = System.Drawing.SystemColors.Window
        Me.cboSevico.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSevico.FormattingEnabled = True
        Me.cboSevico.Location = New System.Drawing.Point(30, 269)
        Me.cboSevico.Name = "cboSevico"
        Me.cboSevico.Size = New System.Drawing.Size(340, 24)
        Me.cboSevico.TabIndex = 50
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
        Me.btn_excluir.Location = New System.Drawing.Point(592, 314)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(128, 32)
        Me.btn_excluir.TabIndex = 62
        Me.btn_excluir.Text = "&Excluir  Del"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = False
        '
        'FormCadAgendamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(785, 465)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboAtendente)
        Me.Controls.Add(Me.cboSevico)
        Me.Controls.Add(Me.btnAdicionar)
        Me.Controls.Add(Me.txtTotServico)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtQtdeServico)
        Me.Controls.Add(Me.txtVlrServico)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.dtgServicos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grp_pedido)
        Me.Controls.Add(Me.txtOperador)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormCadAgendamento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Agendamento"
        Me.grp_turno.ResumeLayout(False)
        Me.grp_turno.PerformLayout()
        Me.grp_pedido.ResumeLayout(False)
        Me.grp_pedido.PerformLayout()
        CType(Me.dtgServicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboInfomacao As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents dtpDataAgend As System.Windows.Forms.DateTimePicker
    Public WithEvents txtIDAgendamento As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_pedido As System.Windows.Forms.Label
    Friend WithEvents rdbNoite As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTarde As System.Windows.Forms.RadioButton
    Friend WithEvents rdbManha As System.Windows.Forms.RadioButton
    Friend WithEvents grp_turno As System.Windows.Forms.GroupBox
    Friend WithEvents grp_pedido As System.Windows.Forms.GroupBox
    Public WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents cboEmpresa As System.Windows.Forms.ComboBox
    Public WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents txtNomeCliente As System.Windows.Forms.TextBox
    Public WithEvents txtValorTotalAgend As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtgServicos As System.Windows.Forms.DataGridView
    Friend WithEvents btnInfoSaudePessoa As System.Windows.Forms.Button
    Friend WithEvents txtQtdeServico As System.Windows.Forms.TextBox
    Friend WithEvents txtVlrServico As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtTotServico As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents btnAdicionar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboAtendente As System.Windows.Forms.ComboBox
    Friend WithEvents cboSevico As System.Windows.Forms.ComboBox
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents IdProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents servicoV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qtdeProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalProdV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AtendenteServ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idAtendente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comissaoatendente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents servicoDespCartaoPorcent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents servdespcartaovalor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mskHora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
