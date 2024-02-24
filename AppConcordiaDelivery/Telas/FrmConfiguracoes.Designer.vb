<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfiguracoes
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPastaSincronizar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPastaSGBD = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPastaDoSistema = New System.Windows.Forms.TextBox()
        Me.btnPastaSincronizar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPastaSGBD = New System.Windows.Forms.Button()
        Me.txtLocalLogoMarca = New System.Windows.Forms.TextBox()
        Me.btnPastaAplicacao = New System.Windows.Forms.Button()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.btnLogo = New System.Windows.Forms.Button()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.txtSenhaPadrao = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDiasCrediario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLimiteDesconto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnSalvar)
        Me.GroupBox1.Controls.Add(Me.txtSenhaPadrao)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDiasCrediario)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtLimiteDesconto)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 279)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configurações: "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPastaSincronizar)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtPastaSGBD)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtPastaDoSistema)
        Me.GroupBox2.Controls.Add(Me.btnPastaSincronizar)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnPastaSGBD)
        Me.GroupBox2.Controls.Add(Me.txtLocalLogoMarca)
        Me.GroupBox2.Controls.Add(Me.btnPastaAplicacao)
        Me.GroupBox2.Controls.Add(Me.Label106)
        Me.GroupBox2.Controls.Add(Me.btnLogo)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(3, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(604, 168)
        Me.GroupBox2.TabIndex = 116
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Caminhos: "
        '
        'txtPastaSincronizar
        '
        Me.txtPastaSincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPastaSincronizar.Location = New System.Drawing.Point(142, 136)
        Me.txtPastaSincronizar.MaxLength = 90
        Me.txtPastaSincronizar.Name = "txtPastaSincronizar"
        Me.txtPastaSincronizar.Size = New System.Drawing.Size(396, 21)
        Me.txtPastaSincronizar.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 15)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Pasta Sincronizar:"
        '
        'txtPastaSGBD
        '
        Me.txtPastaSGBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPastaSGBD.Location = New System.Drawing.Point(142, 101)
        Me.txtPastaSGBD.MaxLength = 90
        Me.txtPastaSGBD.Name = "txtPastaSGBD"
        Me.txtPastaSGBD.Size = New System.Drawing.Size(396, 21)
        Me.txtPastaSGBD.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Pasta SGBD:"
        '
        'txtPastaDoSistema
        '
        Me.txtPastaDoSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPastaDoSistema.Location = New System.Drawing.Point(142, 65)
        Me.txtPastaDoSistema.MaxLength = 90
        Me.txtPastaDoSistema.Name = "txtPastaDoSistema"
        Me.txtPastaDoSistema.Size = New System.Drawing.Size(396, 21)
        Me.txtPastaDoSistema.TabIndex = 7
        '
        'btnPastaSincronizar
        '
        Me.btnPastaSincronizar.BackgroundImage = Global.AppOtica.My.Resources.Resources.folder_open
        Me.btnPastaSincronizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPastaSincronizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPastaSincronizar.Location = New System.Drawing.Point(542, 134)
        Me.btnPastaSincronizar.Name = "btnPastaSincronizar"
        Me.btnPastaSincronizar.Size = New System.Drawing.Size(33, 25)
        Me.btnPastaSincronizar.TabIndex = 8
        Me.btnPastaSincronizar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Pasta do Sistema:"
        '
        'btnPastaSGBD
        '
        Me.btnPastaSGBD.BackgroundImage = Global.AppOtica.My.Resources.Resources.folder_open
        Me.btnPastaSGBD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPastaSGBD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPastaSGBD.Location = New System.Drawing.Point(542, 99)
        Me.btnPastaSGBD.Name = "btnPastaSGBD"
        Me.btnPastaSGBD.Size = New System.Drawing.Size(33, 25)
        Me.btnPastaSGBD.TabIndex = 8
        Me.btnPastaSGBD.UseVisualStyleBackColor = True
        '
        'txtLocalLogoMarca
        '
        Me.txtLocalLogoMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocalLogoMarca.Location = New System.Drawing.Point(142, 29)
        Me.txtLocalLogoMarca.MaxLength = 90
        Me.txtLocalLogoMarca.Name = "txtLocalLogoMarca"
        Me.txtLocalLogoMarca.Size = New System.Drawing.Size(396, 21)
        Me.txtLocalLogoMarca.TabIndex = 7
        '
        'btnPastaAplicacao
        '
        Me.btnPastaAplicacao.BackgroundImage = Global.AppOtica.My.Resources.Resources.folder_open
        Me.btnPastaAplicacao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPastaAplicacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPastaAplicacao.Location = New System.Drawing.Point(542, 63)
        Me.btnPastaAplicacao.Name = "btnPastaAplicacao"
        Me.btnPastaAplicacao.Size = New System.Drawing.Size(33, 25)
        Me.btnPastaAplicacao.TabIndex = 8
        Me.btnPastaAplicacao.UseVisualStyleBackColor = True
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label106.Location = New System.Drawing.Point(29, 32)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(76, 15)
        Me.Label106.TabIndex = 6
        Me.Label106.Text = "Logo Marca:"
        '
        'btnLogo
        '
        Me.btnLogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogo.Location = New System.Drawing.Point(542, 27)
        Me.btnLogo.Name = "btnLogo"
        Me.btnLogo.Size = New System.Drawing.Size(33, 25)
        Me.btnLogo.TabIndex = 8
        Me.btnLogo.Text = ". . ."
        Me.btnLogo.UseVisualStyleBackColor = True
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
        Me.btnSalvar.Image = Global.AppOtica.My.Resources.Resources.Save
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(488, 32)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(103, 37)
        Me.btnSalvar.TabIndex = 115
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.UseVisualStyleBackColor = False
        '
        'txtSenhaPadrao
        '
        Me.txtSenhaPadrao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSenhaPadrao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSenhaPadrao.Location = New System.Drawing.Point(169, 46)
        Me.txtSenhaPadrao.MaxLength = 60
        Me.txtSenhaPadrao.Name = "txtSenhaPadrao"
        Me.txtSenhaPadrao.Size = New System.Drawing.Size(125, 23)
        Me.txtSenhaPadrao.TabIndex = 7
        Me.txtSenhaPadrao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(166, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 17)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "SenhaPadrão:"
        '
        'txtDiasCrediario
        '
        Me.txtDiasCrediario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDiasCrediario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasCrediario.Location = New System.Drawing.Point(325, 47)
        Me.txtDiasCrediario.MaxLength = 5
        Me.txtDiasCrediario.Name = "txtDiasCrediario"
        Me.txtDiasCrediario.Size = New System.Drawing.Size(126, 23)
        Me.txtDiasCrediario.TabIndex = 4
        Me.txtDiasCrediario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(322, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 17)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Dias Venc. Cred.:"
        '
        'txtLimiteDesconto
        '
        Me.txtLimiteDesconto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLimiteDesconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimiteDesconto.Location = New System.Drawing.Point(25, 46)
        Me.txtLimiteDesconto.MaxLength = 5
        Me.txtLimiteDesconto.Name = "txtLimiteDesconto"
        Me.txtLimiteDesconto.Size = New System.Drawing.Size(103, 23)
        Me.txtLimiteDesconto.TabIndex = 4
        Me.txtLimiteDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 17)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Limite Desconto:"
        '
        'OpenFolder
        '
        Me.OpenFolder.Description = "Selecione um Pasta"
        Me.OpenFolder.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'FrmConfiguracoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 316)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConfiguracoes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracoes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents txtSenhaPadrao As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLimiteDesconto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDiasCrediario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLocalLogoMarca As System.Windows.Forms.TextBox
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents btnLogo As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtPastaDoSistema As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPastaAplicacao As System.Windows.Forms.Button
    Friend WithEvents txtPastaSGBD As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPastaSGBD As System.Windows.Forms.Button
    Friend WithEvents OpenFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtPastaSincronizar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPastaSincronizar As System.Windows.Forms.Button
End Class
