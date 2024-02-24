<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRelacaoServicos
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
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSevico = New System.Windows.Forms.ComboBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cboAtendente = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtgServicos = New System.Windows.Forms.DataGridView()
        Me.idItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servicoItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AtendenteItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorServ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descontoItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subTotalItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRegistros = New System.Windows.Forms.TextBox()
        Me.grbFiltros.SuspendLayout()
        CType(Me.dtgServicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbFiltros
        '
        Me.grbFiltros.BackColor = System.Drawing.Color.Transparent
        Me.grbFiltros.Controls.Add(Me.txtRegistros)
        Me.grbFiltros.Controls.Add(Me.Label3)
        Me.grbFiltros.Controls.Add(Me.cboSevico)
        Me.grbFiltros.Controls.Add(Me.btnImprimir)
        Me.grbFiltros.Controls.Add(Me.btnBuscar)
        Me.grbFiltros.Controls.Add(Me.cboAtendente)
        Me.grbFiltros.Controls.Add(Me.Label2)
        Me.grbFiltros.Controls.Add(Me.Label6)
        Me.grbFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbFiltros.Location = New System.Drawing.Point(21, 40)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(724, 106)
        Me.grbFiltros.TabIndex = 507
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Lucida Bright", 9.5!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(20, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 522
        Me.Label3.Text = "Serviço:"
        '
        'cboSevico
        '
        Me.cboSevico.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSevico.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSevico.BackColor = System.Drawing.SystemColors.Window
        Me.cboSevico.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSevico.FormattingEnabled = True
        Me.cboSevico.Location = New System.Drawing.Point(24, 43)
        Me.cboSevico.Name = "cboSevico"
        Me.cboSevico.Size = New System.Drawing.Size(344, 24)
        Me.cboSevico.TabIndex = 523
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
        Me.btnImprimir.Location = New System.Drawing.Point(616, 56)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(100, 37)
        Me.btnImprimir.TabIndex = 508
        Me.btnImprimir.Text = "&Imprimir F11"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.AppOtica.My.Resources.Resources.Busca_16x16
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(616, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 37)
        Me.btnBuscar.TabIndex = 507
        Me.btnBuscar.Text = "&Buscar F5"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cboAtendente
        '
        Me.cboAtendente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAtendente.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboAtendente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAtendente.FormattingEnabled = True
        Me.cboAtendente.Location = New System.Drawing.Point(391, 44)
        Me.cboAtendente.Name = "cboAtendente"
        Me.cboAtendente.Size = New System.Drawing.Size(199, 23)
        Me.cboAtendente.TabIndex = 212
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Lucida Bright", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(390, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 15)
        Me.Label6.TabIndex = 213
        Me.Label6.Text = "Atendente:"
        '
        'dtgServicos
        '
        Me.dtgServicos.AllowUserToAddRows = False
        Me.dtgServicos.AllowUserToResizeColumns = False
        Me.dtgServicos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dtgServicos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgServicos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dtgServicos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgServicos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgServicos.ColumnHeadersHeight = 27
        Me.dtgServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgServicos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idItem, Me.servicoItem, Me.AtendenteItem, Me.valorServ, Me.descontoItem, Me.subTotalItem})
        Me.dtgServicos.Location = New System.Drawing.Point(21, 152)
        Me.dtgServicos.MultiSelect = False
        Me.dtgServicos.Name = "dtgServicos"
        Me.dtgServicos.ReadOnly = True
        Me.dtgServicos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dtgServicos.RowHeadersVisible = False
        Me.dtgServicos.RowTemplate.Height = 23
        Me.dtgServicos.Size = New System.Drawing.Size(724, 168)
        Me.dtgServicos.TabIndex = 510
        '
        'idItem
        '
        Me.idItem.HeaderText = "Id"
        Me.idItem.Name = "idItem"
        Me.idItem.ReadOnly = True
        Me.idItem.Visible = False
        '
        'servicoItem
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.servicoItem.DefaultCellStyle = DataGridViewCellStyle3
        Me.servicoItem.HeaderText = "Serviço"
        Me.servicoItem.Name = "servicoItem"
        Me.servicoItem.ReadOnly = True
        Me.servicoItem.Width = 280
        '
        'AtendenteItem
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AtendenteItem.DefaultCellStyle = DataGridViewCellStyle4
        Me.AtendenteItem.HeaderText = "Atendente"
        Me.AtendenteItem.Name = "AtendenteItem"
        Me.AtendenteItem.ReadOnly = True
        Me.AtendenteItem.Width = 145
        '
        'valorServ
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.Format = "T"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.valorServ.DefaultCellStyle = DataGridViewCellStyle5
        Me.valorServ.HeaderText = "Valor R$"
        Me.valorServ.Name = "valorServ"
        Me.valorServ.ReadOnly = True
        '
        'descontoItem
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle6.Format = "T"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.descontoItem.DefaultCellStyle = DataGridViewCellStyle6
        Me.descontoItem.HeaderText = "Despesa R$"
        Me.descontoItem.Name = "descontoItem"
        Me.descontoItem.ReadOnly = True
        Me.descontoItem.Width = 90
        '
        'subTotalItem
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Bold)
        Me.subTotalItem.DefaultCellStyle = DataGridViewCellStyle7
        Me.subTotalItem.HeaderText = "Despesa %"
        Me.subTotalItem.Name = "subTotalItem"
        Me.subTotalItem.ReadOnly = True
        Me.subTotalItem.Width = 86
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(250, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 20)
        Me.Label1.TabIndex = 511
        Me.Label1.Text = "::   LISTA DE SERVIÇOS   ::"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Lucida Bright", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(446, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 14)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "Registros:"
        '
        'txtRegistros
        '
        Me.txtRegistros.BackColor = System.Drawing.SystemColors.Info
        Me.txtRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegistros.Location = New System.Drawing.Point(516, 81)
        Me.txtRegistros.Name = "txtRegistros"
        Me.txtRegistros.ReadOnly = True
        Me.txtRegistros.Size = New System.Drawing.Size(74, 20)
        Me.txtRegistros.TabIndex = 524
        Me.txtRegistros.Text = "0"
        Me.txtRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FormRelacaoServicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(765, 332)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtgServicos)
        Me.Controls.Add(Me.grbFiltros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRelacaoServicos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relação de Serviços"
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        CType(Me.dtgServicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSevico As System.Windows.Forms.ComboBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents cboAtendente As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtgServicos As System.Windows.Forms.DataGridView
    Friend WithEvents idItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents servicoItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AtendenteItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorServ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descontoItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents subTotalItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRegistros As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
