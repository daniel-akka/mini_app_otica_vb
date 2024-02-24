<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfoSaudePessoa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInfoSaudePessoa))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.txtComorbidade1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComorbidade2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtComorbidade3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtComorbidade4 = New System.Windows.Forms.TextBox()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIdade = New System.Windows.Forms.TextBox()
        Me.grbIMC.SuspendLayout()
        CType(Me.imgIMC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgItensInfoNutri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Name = "Label3"
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.SystemColors.Info
        Me.txtIdCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtIdCliente, "txtIdCliente")
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        '
        'txtNomeCliente
        '
        Me.txtNomeCliente.BackColor = System.Drawing.Color.LightYellow
        Me.txtNomeCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtNomeCliente, "txtNomeCliente")
        Me.txtNomeCliente.Name = "txtNomeCliente"
        Me.txtNomeCliente.ReadOnly = True
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
        resources.ApplyResources(Me.grbIMC, "grbIMC")
        Me.grbIMC.Name = "grbIMC"
        Me.grbIMC.TabStop = False
        '
        'imgIMC
        '
        Me.imgIMC.BackgroundImage = Global.AppOtica.My.Resources.Resources.normal
        resources.ApplyResources(Me.imgIMC, "imgIMC")
        Me.imgIMC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgIMC.Name = "imgIMC"
        Me.imgIMC.TabStop = False
        '
        'txtCausas
        '
        Me.txtCausas.BackColor = System.Drawing.SystemColors.Info
        resources.ApplyResources(Me.txtCausas, "txtCausas")
        Me.txtCausas.Name = "txtCausas"
        Me.txtCausas.ReadOnly = True
        '
        'txtClassificacao
        '
        Me.txtClassificacao.BackColor = System.Drawing.SystemColors.Info
        resources.ApplyResources(Me.txtClassificacao, "txtClassificacao")
        Me.txtClassificacao.Name = "txtClassificacao"
        Me.txtClassificacao.ReadOnly = True
        '
        'txtResultadoIMC
        '
        Me.txtResultadoIMC.BackColor = System.Drawing.SystemColors.Info
        resources.ApplyResources(Me.txtResultadoIMC, "txtResultadoIMC")
        Me.txtResultadoIMC.Name = "txtResultadoIMC"
        Me.txtResultadoIMC.ReadOnly = True
        '
        'txtAltura
        '
        resources.ApplyResources(Me.txtAltura, "txtAltura")
        Me.txtAltura.Name = "txtAltura"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'txtPeso
        '
        resources.ApplyResources(Me.txtPeso, "txtPeso")
        Me.txtPeso.Name = "txtPeso"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.ForeColor = System.Drawing.Color.DarkRed
        Me.Label18.Name = "Label18"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.ForeColor = System.Drawing.Color.DarkRed
        Me.Label17.Name = "Label17"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'btnCalcularIMC
        '
        Me.btnCalcularIMC.BackColor = System.Drawing.Color.DarkRed
        Me.btnCalcularIMC.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnCalcularIMC.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCalcularIMC.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.btnCalcularIMC, "btnCalcularIMC")
        Me.btnCalcularIMC.ForeColor = System.Drawing.Color.White
        Me.btnCalcularIMC.Name = "btnCalcularIMC"
        Me.btnCalcularIMC.UseVisualStyleBackColor = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Name = "Label1"
        '
        'txtComorbidade1
        '
        Me.txtComorbidade1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtComorbidade1, "txtComorbidade1")
        Me.txtComorbidade1.Name = "txtComorbidade1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Name = "Label2"
        '
        'txtComorbidade2
        '
        Me.txtComorbidade2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtComorbidade2, "txtComorbidade2")
        Me.txtComorbidade2.Name = "txtComorbidade2"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Name = "Label4"
        '
        'txtComorbidade3
        '
        Me.txtComorbidade3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtComorbidade3, "txtComorbidade3")
        Me.txtComorbidade3.Name = "txtComorbidade3"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Name = "Label5"
        '
        'txtComorbidade4
        '
        Me.txtComorbidade4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtComorbidade4, "txtComorbidade4")
        Me.txtComorbidade4.Name = "txtComorbidade4"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Name = "Label6"
        '
        'txtObservacao
        '
        Me.txtObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtObservacao, "txtObservacao")
        Me.txtObservacao.Name = "txtObservacao"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.DarkRed
        Me.Label8.Name = "Label8"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnImprimir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.btnImprimir, "btnImprimir")
        Me.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Name = "Label9"
        '
        'cboServico
        '
        Me.cboServico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboServico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboServico.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.cboServico, "cboServico")
        Me.cboServico.FormattingEnabled = True
        Me.cboServico.Name = "cboServico"
        '
        'cboProduto
        '
        resources.ApplyResources(Me.cboProduto, "cboProduto")
        Me.cboProduto.FormattingEnabled = True
        Me.cboProduto.Name = "cboProduto"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Name = "Label10"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Name = "Label11"
        '
        'dtgItensInfoNutri
        '
        Me.dtgItensInfoNutri.AllowUserToAddRows = False
        Me.dtgItensInfoNutri.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dtgItensInfoNutri.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgItensInfoNutri.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgItensInfoNutri.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dtgItensInfoNutri.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgItensInfoNutri.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.dtgItensInfoNutri, "dtgItensInfoNutri")
        Me.dtgItensInfoNutri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgItensInfoNutri.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idServDtg, Me.servicoDtg, Me.idProdDtg, Me.prodDtg})
        Me.dtgItensInfoNutri.MultiSelect = False
        Me.dtgItensInfoNutri.Name = "dtgItensInfoNutri"
        Me.dtgItensInfoNutri.ReadOnly = True
        Me.dtgItensInfoNutri.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtgItensInfoNutri.RowHeadersVisible = False
        Me.dtgItensInfoNutri.RowTemplate.Height = 23
        '
        'idServDtg
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.MediumBlue
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.idServDtg.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.idServDtg, "idServDtg")
        Me.idServDtg.Name = "idServDtg"
        Me.idServDtg.ReadOnly = True
        '
        'servicoDtg
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkRed
        DataGridViewCellStyle4.Format = "T"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.servicoDtg.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(Me.servicoDtg, "servicoDtg")
        Me.servicoDtg.Name = "servicoDtg"
        Me.servicoDtg.ReadOnly = True
        '
        'idProdDtg
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkRed
        Me.idProdDtg.DefaultCellStyle = DataGridViewCellStyle5
        resources.ApplyResources(Me.idProdDtg, "idProdDtg")
        Me.idProdDtg.Name = "idProdDtg"
        Me.idProdDtg.ReadOnly = True
        '
        'prodDtg
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold)
        Me.prodDtg.DefaultCellStyle = DataGridViewCellStyle6
        resources.ApplyResources(Me.prodDtg, "prodDtg")
        Me.prodDtg.Name = "prodDtg"
        Me.prodDtg.ReadOnly = True
        '
        'btnAdicionar
        '
        Me.btnAdicionar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.btnAdicionar, "btnAdicionar")
        Me.btnAdicionar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnAdicionar.Image = Global.AppOtica.My.Resources.Resources.Add
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.UseVisualStyleBackColor = False
        '
        'btnExcluir
        '
        Me.btnExcluir.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExcluir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonShadow
        Me.btnExcluir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight
        Me.btnExcluir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.btnExcluir, "btnExcluir")
        Me.btnExcluir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btnExcluir.Image = Global.AppOtica.My.Resources.Resources.Delete
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.UseVisualStyleBackColor = False
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Name = "Label7"
        '
        'txtIdade
        '
        Me.txtIdade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtIdade, "txtIdade")
        Me.txtIdade.Name = "txtIdade"
        '
        'FormInfoSaudePessoa
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
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
        Me.Controls.Add(Me.txtComorbidade3)
        Me.Controls.Add(Me.txtIdade)
        Me.Controls.Add(Me.txtObservacao)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtComorbidade2)
        Me.Controls.Add(Me.txtComorbidade4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtComorbidade1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grbIMC)
        Me.Controls.Add(Me.txtIdCliente)
        Me.Controls.Add(Me.txtNomeCliente)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormInfoSaudePessoa"
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
    Friend WithEvents txtComorbidade1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComorbidade2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtComorbidade3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComorbidade4 As System.Windows.Forms.TextBox
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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtIdade As System.Windows.Forms.TextBox
End Class
