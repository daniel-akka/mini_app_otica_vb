<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubGrupoResp
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.txtDescrSubGrupoPesquisa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboGrupoDespPesquisa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtgSubGrupo = New System.Windows.Forms.DataGridView()
        Me.idDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idGrupoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nomegrupoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descrsubgrupoDTG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgSubGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btn_buscar)
        Me.GroupBox1.Controls.Add(Me.txtDescrSubGrupoPesquisa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboGrupoDespPesquisa)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 73)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro: "
        '
        'btn_buscar
        '
        Me.btn_buscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscar.Image = Global.AppOtica.My.Resources.Resources.Busca_16x16
        Me.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_buscar.Location = New System.Drawing.Point(472, 27)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(89, 33)
        Me.btn_buscar.TabIndex = 25
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
        Me.txtDescrSubGrupoPesquisa.TabIndex = 13
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
        Me.cboGrupoDespPesquisa.TabIndex = 20
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(116, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(339, 24)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "::   PESQUISA DE SUB. GRUPO   ::"
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
        Me.dtgSubGrupo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idDTG, Me.idGrupoDTG, Me.nomegrupoDTG, Me.descrsubgrupoDTG})
        Me.dtgSubGrupo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dtgSubGrupo.Location = New System.Drawing.Point(0, 161)
        Me.dtgSubGrupo.Name = "dtgSubGrupo"
        Me.dtgSubGrupo.ReadOnly = True
        Me.dtgSubGrupo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dtgSubGrupo.RowHeadersWidth = 20
        Me.dtgSubGrupo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgSubGrupo.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgSubGrupo.RowTemplate.Height = 24
        Me.dtgSubGrupo.Size = New System.Drawing.Size(597, 167)
        Me.dtgSubGrupo.TabIndex = 91
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
        Me.descrsubgrupoDTG.Width = 335
        '
        'FrmSubGrupoResp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AppOtica.My.Resources.Resources.backgroundTelas
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(597, 328)
        Me.Controls.Add(Me.dtgSubGrupo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSubGrupoResp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisa de SubGrupo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgSubGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents txtDescrSubGrupoPesquisa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboGrupoDespPesquisa As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtgSubGrupo As System.Windows.Forms.DataGridView
    Friend WithEvents idDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idGrupoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nomegrupoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descrsubgrupoDTG As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
