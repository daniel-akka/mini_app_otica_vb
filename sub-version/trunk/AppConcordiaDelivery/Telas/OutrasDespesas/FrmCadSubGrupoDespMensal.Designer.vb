<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCadSubGrupoDespMensal
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_novo = New System.Windows.Forms.Button()
        Me.dtgSubGrupo = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.txtDescrSubGrupoPesquisa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboGrupoDespPesquisa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.btnAddGrupo = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIdGrupo = New System.Windows.Forms.TextBox()
        Me.txtIdSubGrupo = New System.Windows.Forms.TextBox()
        Me.txtValorPadrao = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescrSubGrupo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.idDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idGrupoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nomegrupoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descrsubgrupoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorpadraoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgSubGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblCliente.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(202, 30)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(305, 23)
        Me.lblCliente.TabIndex = 149
        Me.lblCliente.Text = ":: CADASTRO DE SUBGRUPO ::"
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
        Me.btn_alterar.Location = New System.Drawing.Point(475, 144)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(106, 31)
        Me.btn_alterar.TabIndex = 70
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
        Me.btn_excluir.Image = Global.AppOtica.My.Resources.Resources.Delete
        Me.btn_excluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_excluir.Location = New System.Drawing.Point(587, 144)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(106, 31)
        Me.btn_excluir.TabIndex = 80
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
        Me.btn_novo.Location = New System.Drawing.Point(363, 144)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(106, 31)
        Me.btn_novo.TabIndex = 60
        Me.btn_novo.Text = "&Novo F2"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = False
        '
        'dtgSubGrupo
        '
        Me.dtgSubGrupo.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgSubGrupo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgSubGrupo.BackgroundColor = System.Drawing.Color.Gray
        Me.dtgSubGrupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgSubGrupo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.dtgSubGrupo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgSubGrupo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgSubGrupo.ColumnHeadersHeight = 26
        Me.dtgSubGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgSubGrupo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idDTG, Me.idGrupoDTG, Me.nomegrupoDTG, Me.descrsubgrupoDTG, Me.valorpadraoDTG})
        Me.dtgSubGrupo.Location = New System.Drawing.Point(20, 183)
        Me.dtgSubGrupo.Name = "dtgSubGrupo"
        Me.dtgSubGrupo.ReadOnly = True
        Me.dtgSubGrupo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgSubGrupo.RowHeadersWidth = 20
        Me.dtgSubGrupo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgSubGrupo.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dtgSubGrupo.RowTemplate.Height = 24
        Me.dtgSubGrupo.Size = New System.Drawing.Size(687, 156)
        Me.dtgSubGrupo.TabIndex = 90
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.txtDescrSubGrupoPesquisa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboGrupoDespPesquisa)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(687, 70)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro: "
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
        Me.btnImprimir.Location = New System.Drawing.Point(567, 27)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(106, 33)
        Me.btnImprimir.TabIndex = 30
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.AppOtica.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(472, 27)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(89, 33)
        Me.btn_buscar.TabIndex = 20
        Me.btn_buscar.Text = "&Buscar F5"
        Me.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'txtDescrSubGrupoPesquisa
        '
        Me.txtDescrSubGrupoPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescrSubGrupoPesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescrSubGrupoPesquisa.Location = New System.Drawing.Point(220, 35)
        Me.txtDescrSubGrupoPesquisa.Name = "txtDescrSubGrupoPesquisa"
        Me.txtDescrSubGrupoPesquisa.Size = New System.Drawing.Size(223, 23)
        Me.txtDescrSubGrupoPesquisa.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 19)
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
        Me.cboGrupoDespPesquisa.Size = New System.Drawing.Size(167, 23)
        Me.cboGrupoDespPesquisa.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Grupo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnSalvar)
        Me.GroupBox2.Controls.Add(Me.cboGrupo)
        Me.GroupBox2.Controls.Add(Me.btnAddGrupo)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtIdGrupo)
        Me.GroupBox2.Controls.Add(Me.txtIdSubGrupo)
        Me.GroupBox2.Controls.Add(Me.txtValorPadrao)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtDescrSubGrupo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(20, 345)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(687, 84)
        Me.GroupBox2.TabIndex = 100
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sub. Grupo: "
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
        Me.btnSalvar.Image = Global.AppOtica.My.Resources.Resources.Save
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(582, 36)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(91, 32)
        Me.btnSalvar.TabIndex = 120
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'cboGrupo
        '
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(29, 44)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(167, 23)
        Me.cboGrupo.TabIndex = 104
        '
        'btnAddGrupo
        '
        Me.btnAddGrupo.BackColor = System.Drawing.Color.Transparent
        Me.btnAddGrupo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnAddGrupo.FlatAppearance.BorderSize = 0
        Me.btnAddGrupo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAddGrupo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnAddGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddGrupo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnAddGrupo.Image = Global.AppOtica.My.Resources.Resources.Add
        Me.btnAddGrupo.Location = New System.Drawing.Point(0, 43)
        Me.btnAddGrupo.Name = "btnAddGrupo"
        Me.btnAddGrupo.Size = New System.Drawing.Size(29, 26)
        Me.btnAddGrupo.TabIndex = 146
        Me.btnAddGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddGrupo.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Grupo:"
        '
        'txtIdGrupo
        '
        Me.txtIdGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdGrupo.Location = New System.Drawing.Point(3, 44)
        Me.txtIdGrupo.Name = "txtIdGrupo"
        Me.txtIdGrupo.ReadOnly = True
        Me.txtIdGrupo.Size = New System.Drawing.Size(25, 23)
        Me.txtIdGrupo.TabIndex = 3
        Me.txtIdGrupo.Visible = False
        '
        'txtIdSubGrupo
        '
        Me.txtIdSubGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdSubGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSubGrupo.Location = New System.Drawing.Point(645, 9)
        Me.txtIdSubGrupo.Name = "txtIdSubGrupo"
        Me.txtIdSubGrupo.ReadOnly = True
        Me.txtIdSubGrupo.Size = New System.Drawing.Size(28, 23)
        Me.txtIdSubGrupo.TabIndex = 3
        Me.txtIdSubGrupo.Visible = False
        '
        'txtValorPadrao
        '
        Me.txtValorPadrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValorPadrao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorPadrao.Location = New System.Drawing.Point(479, 43)
        Me.txtValorPadrao.Name = "txtValorPadrao"
        Me.txtValorPadrao.Size = New System.Drawing.Size(76, 23)
        Me.txtValorPadrao.TabIndex = 112
        Me.txtValorPadrao.Text = "0,00"
        Me.txtValorPadrao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(476, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Valor $$:"
        '
        'txtDescrSubGrupo
        '
        Me.txtDescrSubGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescrSubGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescrSubGrupo.Location = New System.Drawing.Point(211, 44)
        Me.txtDescrSubGrupo.Name = "txtDescrSubGrupo"
        Me.txtDescrSubGrupo.Size = New System.Drawing.Size(238, 23)
        Me.txtDescrSubGrupo.TabIndex = 108
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(208, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Descr. SubGrupo:"
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
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomegrupoDTG.DefaultCellStyle = DataGridViewCellStyle3
        Me.nomegrupoDTG.HeaderText = "Grupo"
        Me.nomegrupoDTG.MaxInputLength = 2
        Me.nomegrupoDTG.Name = "nomegrupoDTG"
        Me.nomegrupoDTG.ReadOnly = True
        Me.nomegrupoDTG.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nomegrupoDTG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nomegrupoDTG.Width = 220
        '
        'descrsubgrupoDTG
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.descrsubgrupoDTG.DefaultCellStyle = DataGridViewCellStyle4
        Me.descrsubgrupoDTG.HeaderText = "Sub. Grupo"
        Me.descrsubgrupoDTG.Name = "descrsubgrupoDTG"
        Me.descrsubgrupoDTG.ReadOnly = True
        Me.descrsubgrupoDTG.Width = 306
        '
        'valorpadraoDTG
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.valorpadraoDTG.DefaultCellStyle = DataGridViewCellStyle5
        Me.valorpadraoDTG.HeaderText = "Valor Padrão"
        Me.valorpadraoDTG.Name = "valorpadraoDTG"
        Me.valorpadraoDTG.ReadOnly = True
        Me.valorpadraoDTG.Width = 120
        '
        'FrmCadSubGrupoDespMensal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(728, 442)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.dtgSubGrupo)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCadSubGrupoDespMensal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de SubGrupo de Despesa"
        CType(Me.dtgSubGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_novo As System.Windows.Forms.Button
    Friend WithEvents dtgSubGrupo As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescrSubGrupoPesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboGrupoDespPesquisa As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDescrSubGrupo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnAddGrupo As System.Windows.Forms.Button
    Friend WithEvents txtIdSubGrupo As System.Windows.Forms.TextBox
    Friend WithEvents txtIdGrupo As System.Windows.Forms.TextBox
    Friend WithEvents txtValorPadrao As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents idDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idGrupoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nomegrupoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrsubgrupoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorpadraoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
