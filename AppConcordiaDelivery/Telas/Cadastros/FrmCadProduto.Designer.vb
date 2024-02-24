<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCadProduto
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtIdProd = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.txtDescricaoProd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInfoProd = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtgProdutos = New System.Windows.Forms.DataGridView()
        Me.idUsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomeProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precoV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unidade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referenciaDtg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datagridgrupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datagridmarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_qtdRegistros = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_excluir = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_pesquisa = New System.Windows.Forms.TextBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.tbcProduto = New System.Windows.Forms.TabControl()
        Me.tbpPrincipal = New System.Windows.Forms.TabPage()
        Me.txtProdutoCor = New System.Windows.Forms.TextBox()
        Me.btnUnidade = New System.Windows.Forms.Button()
        Me.cboUnidade = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnMarca = New System.Windows.Forms.Button()
        Me.btnGrupo = New System.Windows.Forms.Button()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.txtPrecoCusto = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboMarca = New System.Windows.Forms.ComboBox()
        Me.txtPrecoVenda = New System.Windows.Forms.TextBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btn_novo = New System.Windows.Forms.Button()
        CType(Me.dtgProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.tbcProduto.SuspendLayout()
        Me.tbpPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIdProd
        '
        Me.txtIdProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIdProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProd.Location = New System.Drawing.Point(841, 10)
        Me.txtIdProd.MaxLength = 3
        Me.txtIdProd.Name = "txtIdProd"
        Me.txtIdProd.ReadOnly = True
        Me.txtIdProd.Size = New System.Drawing.Size(48, 21)
        Me.txtIdProd.TabIndex = 126
        Me.txtIdProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdProd.Visible = False
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
        Me.btnCancelar.Image = Global.AppOtica.My.Resources.Resources.cancelar
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(750, 127)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(110, 28)
        Me.btnCancelar.TabIndex = 152
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
        Me.btnSalvar.Image = Global.AppOtica.My.Resources.Resources.Save
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(750, 91)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(110, 28)
        Me.btnSalvar.TabIndex = 150
        Me.btnSalvar.Text = "&Salvar F9"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'txtDescricaoProd
        '
        Me.txtDescricaoProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescricaoProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescricaoProd.Location = New System.Drawing.Point(17, 38)
        Me.txtDescricaoProd.MaxLength = 100
        Me.txtDescricaoProd.Name = "txtDescricaoProd"
        Me.txtDescricaoProd.Size = New System.Drawing.Size(350, 23)
        Me.txtDescricaoProd.TabIndex = 110
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 112
        Me.Label2.Text = "Nome:"
        '
        'txtInfoProd
        '
        Me.txtInfoProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInfoProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoProd.Location = New System.Drawing.Point(569, 111)
        Me.txtInfoProd.Name = "txtInfoProd"
        Me.txtInfoProd.Size = New System.Drawing.Size(160, 21)
        Me.txtInfoProd.TabIndex = 130
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(566, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 15)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Info. Adicional:"
        '
        'dtgProdutos
        '
        Me.dtgProdutos.AllowUserToAddRows = False
        Me.dtgProdutos.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgProdutos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgProdutos.BackgroundColor = System.Drawing.Color.Gray
        Me.dtgProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgProdutos.ColumnHeadersHeight = 26
        Me.dtgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idUsu, Me.CodProd, Me.NomeProd, Me.precoV, Me.unidade, Me.referenciaDtg, Me.datagridgrupo, Me.datagridmarca})
        Me.dtgProdutos.Location = New System.Drawing.Point(17, 131)
        Me.dtgProdutos.Name = "dtgProdutos"
        Me.dtgProdutos.ReadOnly = True
        Me.dtgProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgProdutos.RowHeadersWidth = 20
        Me.dtgProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgProdutos.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dtgProdutos.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dtgProdutos.Size = New System.Drawing.Size(872, 172)
        Me.dtgProdutos.TabIndex = 125
        '
        'idUsu
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.idUsu.DefaultCellStyle = DataGridViewCellStyle3
        Me.idUsu.HeaderText = "Id"
        Me.idUsu.MaxInputLength = 13
        Me.idUsu.Name = "idUsu"
        Me.idUsu.ReadOnly = True
        Me.idUsu.Width = 70
        '
        'CodProd
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CodProd.DefaultCellStyle = DataGridViewCellStyle4
        Me.CodProd.HeaderText = "Codigo"
        Me.CodProd.Name = "CodProd"
        Me.CodProd.ReadOnly = True
        Me.CodProd.Visible = False
        Me.CodProd.Width = 70
        '
        'NomeProd
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.NomeProd.DefaultCellStyle = DataGridViewCellStyle5
        Me.NomeProd.HeaderText = "Nome"
        Me.NomeProd.MaxInputLength = 2
        Me.NomeProd.Name = "NomeProd"
        Me.NomeProd.ReadOnly = True
        Me.NomeProd.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NomeProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NomeProd.Width = 300
        '
        'precoV
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.precoV.DefaultCellStyle = DataGridViewCellStyle6
        Me.precoV.HeaderText = "Pco. Venda"
        Me.precoV.Name = "precoV"
        Me.precoV.ReadOnly = True
        Me.precoV.Width = 90
        '
        'unidade
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        Me.unidade.DefaultCellStyle = DataGridViewCellStyle7
        Me.unidade.HeaderText = "Unidade"
        Me.unidade.Name = "unidade"
        Me.unidade.ReadOnly = True
        Me.unidade.Width = 60
        '
        'referenciaDtg
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.referenciaDtg.DefaultCellStyle = DataGridViewCellStyle8
        Me.referenciaDtg.HeaderText = "Referencia"
        Me.referenciaDtg.Name = "referenciaDtg"
        Me.referenciaDtg.ReadOnly = True
        Me.referenciaDtg.Width = 105
        '
        'datagridgrupo
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.datagridgrupo.DefaultCellStyle = DataGridViewCellStyle9
        Me.datagridgrupo.HeaderText = "Grupo"
        Me.datagridgrupo.Name = "datagridgrupo"
        Me.datagridgrupo.ReadOnly = True
        '
        'datagridmarca
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.datagridmarca.DefaultCellStyle = DataGridViewCellStyle10
        Me.datagridmarca.HeaderText = "Marca"
        Me.datagridmarca.Name = "datagridmarca"
        Me.datagridmarca.ReadOnly = True
        Me.datagridmarca.Width = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(299, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 23)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = ":: CADASTRO DE PRODUTOS ::"
        '
        'txt_qtdRegistros
        '
        Me.txt_qtdRegistros.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txt_qtdRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_qtdRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_qtdRegistros.ForeColor = System.Drawing.Color.Red
        Me.txt_qtdRegistros.Location = New System.Drawing.Point(818, 12)
        Me.txt_qtdRegistros.MaxLength = 4
        Me.txt_qtdRegistros.Name = "txt_qtdRegistros"
        Me.txt_qtdRegistros.ReadOnly = True
        Me.txt_qtdRegistros.Size = New System.Drawing.Size(47, 17)
        Me.txt_qtdRegistros.TabIndex = 1
        Me.txt_qtdRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(751, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Registros:"
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
        Me.btn_excluir.Location = New System.Drawing.Point(640, 63)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.Size = New System.Drawing.Size(110, 29)
        Me.btn_excluir.TabIndex = 121
        Me.btn_excluir.Text = "&Excluir"
        Me.btn_excluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_excluir.UseVisualStyleBackColor = False
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
        Me.btn_alterar.Location = New System.Drawing.Point(524, 63)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(110, 29)
        Me.btn_alterar.TabIndex = 120
        Me.btn_alterar.Text = "&Alterar F3"
        Me.btn_alterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_alterar.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 17)
        Me.Label7.TabIndex = 123
        Me.Label7.Text = "Nome:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_qtdRegistros)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 35)
        Me.GroupBox1.TabIndex = 124
        Me.GroupBox1.TabStop = False
        '
        'txt_pesquisa
        '
        Me.txt_pesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_pesquisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pesquisa.Location = New System.Drawing.Point(88, 68)
        Me.txt_pesquisa.MaxLength = 60
        Me.txt_pesquisa.Name = "txt_pesquisa"
        Me.txt_pesquisa.Size = New System.Drawing.Size(240, 23)
        Me.txt_pesquisa.TabIndex = 118
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
        Me.btnImprimir.Location = New System.Drawing.Point(773, 49)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(116, 43)
        Me.btnImprimir.TabIndex = 547
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'tbcProduto
        '
        Me.tbcProduto.Controls.Add(Me.tbpPrincipal)
        Me.tbcProduto.Location = New System.Drawing.Point(17, 312)
        Me.tbcProduto.Name = "tbcProduto"
        Me.tbcProduto.SelectedIndex = 0
        Me.tbcProduto.Size = New System.Drawing.Size(876, 192)
        Me.tbcProduto.TabIndex = 50
        '
        'tbpPrincipal
        '
        Me.tbpPrincipal.Controls.Add(Me.txtProdutoCor)
        Me.tbpPrincipal.Controls.Add(Me.btnUnidade)
        Me.tbpPrincipal.Controls.Add(Me.cboUnidade)
        Me.tbpPrincipal.Controls.Add(Me.Label8)
        Me.tbpPrincipal.Controls.Add(Me.btnMarca)
        Me.tbpPrincipal.Controls.Add(Me.btnGrupo)
        Me.tbpPrincipal.Controls.Add(Me.txtReferencia)
        Me.tbpPrincipal.Controls.Add(Me.txtPrecoCusto)
        Me.tbpPrincipal.Controls.Add(Me.Label21)
        Me.tbpPrincipal.Controls.Add(Me.cboMarca)
        Me.tbpPrincipal.Controls.Add(Me.txtPrecoVenda)
        Me.tbpPrincipal.Controls.Add(Me.cboGrupo)
        Me.tbpPrincipal.Controls.Add(Me.Label20)
        Me.tbpPrincipal.Controls.Add(Me.txtInfoProd)
        Me.tbpPrincipal.Controls.Add(Me.txtDescricaoProd)
        Me.tbpPrincipal.Controls.Add(Me.btnCancelar)
        Me.tbpPrincipal.Controls.Add(Me.btnSalvar)
        Me.tbpPrincipal.Controls.Add(Me.Label3)
        Me.tbpPrincipal.Controls.Add(Me.Label4)
        Me.tbpPrincipal.Controls.Add(Me.Label17)
        Me.tbpPrincipal.Controls.Add(Me.Label18)
        Me.tbpPrincipal.Controls.Add(Me.Label16)
        Me.tbpPrincipal.Controls.Add(Me.Label2)
        Me.tbpPrincipal.Location = New System.Drawing.Point(4, 23)
        Me.tbpPrincipal.Name = "tbpPrincipal"
        Me.tbpPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPrincipal.Size = New System.Drawing.Size(868, 165)
        Me.tbpPrincipal.TabIndex = 0
        Me.tbpPrincipal.Text = "Principal - Home"
        Me.tbpPrincipal.UseVisualStyleBackColor = True
        '
        'txtProdutoCor
        '
        Me.txtProdutoCor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProdutoCor.Location = New System.Drawing.Point(428, 110)
        Me.txtProdutoCor.Name = "txtProdutoCor"
        Me.txtProdutoCor.Size = New System.Drawing.Size(124, 22)
        Me.txtProdutoCor.TabIndex = 126
        '
        'btnUnidade
        '
        Me.btnUnidade.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnUnidade.BackgroundImage = Global.AppOtica.My.Resources.Resources.Add
        Me.btnUnidade.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnUnidade.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnUnidade.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnUnidade.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnUnidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnidade.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnUnidade.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnUnidade.Location = New System.Drawing.Point(754, 38)
        Me.btnUnidade.Name = "btnUnidade"
        Me.btnUnidade.Size = New System.Drawing.Size(28, 23)
        Me.btnUnidade.TabIndex = 531
        Me.btnUnidade.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUnidade.UseVisualStyleBackColor = False
        '
        'cboUnidade
        '
        Me.cboUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboUnidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboUnidade.BackColor = System.Drawing.SystemColors.Window
        Me.cboUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidade.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboUnidade.Font = New System.Drawing.Font("Cambria", 9.5!)
        Me.cboUnidade.FormattingEnabled = True
        Me.cboUnidade.Location = New System.Drawing.Point(785, 38)
        Me.cboUnidade.Name = "cboUnidade"
        Me.cboUnidade.Size = New System.Drawing.Size(76, 23)
        Me.cboUnidade.TabIndex = 120
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(782, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 15)
        Me.Label8.TabIndex = 529
        Me.Label8.Text = "Unidade:"
        '
        'btnMarca
        '
        Me.btnMarca.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnMarca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnMarca.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnMarca.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMarca.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnMarca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnMarca.Image = Global.AppOtica.My.Resources.Resources.Add
        Me.btnMarca.Location = New System.Drawing.Point(232, 109)
        Me.btnMarca.Name = "btnMarca"
        Me.btnMarca.Size = New System.Drawing.Size(28, 23)
        Me.btnMarca.TabIndex = 528
        Me.btnMarca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMarca.UseVisualStyleBackColor = False
        '
        'btnGrupo
        '
        Me.btnGrupo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnGrupo.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnGrupo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnGrupo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrupo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnGrupo.Image = Global.AppOtica.My.Resources.Resources.Add
        Me.btnGrupo.Location = New System.Drawing.Point(17, 109)
        Me.btnGrupo.Name = "btnGrupo"
        Me.btnGrupo.Size = New System.Drawing.Size(28, 23)
        Me.btnGrupo.TabIndex = 528
        Me.btnGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrupo.UseVisualStyleBackColor = False
        '
        'txtReferencia
        '
        Me.txtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtReferencia.Location = New System.Drawing.Point(381, 38)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(145, 23)
        Me.txtReferencia.TabIndex = 112
        '
        'txtPrecoCusto
        '
        Me.txtPrecoCusto.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrecoCusto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtPrecoCusto.Location = New System.Drawing.Point(651, 38)
        Me.txtPrecoCusto.MaxLength = 40
        Me.txtPrecoCusto.Name = "txtPrecoCusto"
        Me.txtPrecoCusto.Size = New System.Drawing.Size(91, 23)
        Me.txtPrecoCusto.TabIndex = 116
        Me.txtPrecoCusto.Text = "0,00"
        Me.txtPrecoCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(648, 21)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(79, 15)
        Me.Label21.TabIndex = 112
        Me.Label21.Text = "Pco. Custo:"
        '
        'cboMarca
        '
        Me.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboMarca.Font = New System.Drawing.Font("Cambria", 9.5!)
        Me.cboMarca.FormattingEnabled = True
        Me.cboMarca.Location = New System.Drawing.Point(262, 109)
        Me.cboMarca.Name = "cboMarca"
        Me.cboMarca.Size = New System.Drawing.Size(152, 23)
        Me.cboMarca.TabIndex = 124
        '
        'txtPrecoVenda
        '
        Me.txtPrecoVenda.BackColor = System.Drawing.SystemColors.Info
        Me.txtPrecoVenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.txtPrecoVenda.Location = New System.Drawing.Point(544, 38)
        Me.txtPrecoVenda.MaxLength = 40
        Me.txtPrecoVenda.Name = "txtPrecoVenda"
        Me.txtPrecoVenda.Size = New System.Drawing.Size(91, 23)
        Me.txtPrecoVenda.TabIndex = 114
        Me.txtPrecoVenda.Text = "0,00"
        Me.txtPrecoVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboGrupo
        '
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboGrupo.Font = New System.Drawing.Font("Cambria", 9.5!)
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(47, 109)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(172, 23)
        Me.cboGrupo.TabIndex = 122
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(541, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 15)
        Me.Label20.TabIndex = 112
        Me.Label20.Text = "Pco. Venda:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(425, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 15)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Cor:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(259, 90)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 15)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "Marca:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(378, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 15)
        Me.Label18.TabIndex = 112
        Me.Label18.Text = "Referencia:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(44, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 15)
        Me.Label16.TabIndex = 112
        Me.Label16.Text = "Grupo:"
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
        Me.btn_novo.Location = New System.Drawing.Point(408, 63)
        Me.btn_novo.Name = "btn_novo"
        Me.btn_novo.Size = New System.Drawing.Size(110, 29)
        Me.btn_novo.TabIndex = 548
        Me.btn_novo.Text = "&Incluir F2"
        Me.btn_novo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_novo.UseVisualStyleBackColor = False
        '
        'FrmCadProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(903, 520)
        Me.Controls.Add(Me.btn_novo)
        Me.Controls.Add(Me.tbcProduto)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dtgProdutos)
        Me.Controls.Add(Me.txtIdProd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_excluir)
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_pesquisa)
        Me.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmCadProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Produto ::"
        CType(Me.dtgProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbcProduto.ResumeLayout(False)
        Me.tbpPrincipal.ResumeLayout(False)
        Me.tbpPrincipal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdProd As System.Windows.Forms.TextBox
    Public WithEvents btnCancelar As System.Windows.Forms.Button
    Public WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents txtDescricaoProd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInfoProd As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtgProdutos As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_qtdRegistros As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btn_excluir As System.Windows.Forms.Button
    Friend WithEvents btn_alterar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_pesquisa As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents tbcProduto As System.Windows.Forms.TabControl
    Friend WithEvents tbpPrincipal As System.Windows.Forms.TabPage
    Friend WithEvents btnMarca As System.Windows.Forms.Button
    Friend WithEvents btnGrupo As System.Windows.Forms.Button
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents cboMarca As System.Windows.Forms.ComboBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPrecoCusto As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPrecoVenda As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnUnidade As System.Windows.Forms.Button
    Friend WithEvents cboUnidade As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents idUsu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomeProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents precoV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unidade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents referenciaDtg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datagridgrupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datagridmarca As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtProdutoCor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_novo As System.Windows.Forms.Button
End Class
