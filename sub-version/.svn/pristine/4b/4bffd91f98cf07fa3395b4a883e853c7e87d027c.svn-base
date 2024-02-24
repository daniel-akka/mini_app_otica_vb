Imports System.Text
Imports Npgsql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class FrmClienteResp

    Protected conexao As String = MdlConexaoBD.conectionPadrao
    Private _erro As Boolean = False
    Private _msgErro As String = ""
    Private _contErros As Integer = 0

    'ultilizados para o DataGridView
    Public _cliente As New ClCliente
    Dim _clienteDAO As New ClClienteDAO
    Dim oConnBD As NpgsqlConnection = New NpgsqlConnection(conexao)
    Private da As NpgsqlDataAdapter
    Private ds As New DataSet
    Dim CmdParticipante As New NpgsqlCommand
    Dim SqlParticipante As New StringBuilder
    Dim drParticipante As NpgsqlDataReader
    Public _formRequest As New Object

    Private Sub rdb_cnpj_cpf_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rdb_codigo.KeyDown, rdb_nome.KeyDown, rdb_cpf.KeyDown

        If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.Tab Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

        If e.KeyCode = Keys.Escape Then
            If _formRequest._frmREf._mPesquisaForn = False Then _formRequest._frmREf.txt_nomePart.Focus()
            _formRequest._frmREf.Show()
            Me.Close()

        End If
    End Sub

    Private Sub txt_pesquisa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_pesquisa.KeyDown

        'If (e.KeyCode = Keys.Enter) OrElse (e.KeyCode = Keys.Tab) Then
        '    e.Handled = True
        '    SendKeys.Send("{TAB}")
        'End If

        Select Case e.KeyCode
            Case Keys.Enter
                If Dtg_particpante.RowCount = 1 Then
                    Me.Dtg_particpante.Focus()
                    setValoresFormRef()
                    Me.Close()
                ElseIf Dtg_particpante.RowCount > 1 Then
                    Me.Dtg_particpante.Focus()
                Else
                    MsgBox("Pesquise o registro desejado, por favor!", MsgBoxStyle.Exclamation)
                End If
                
            Case Keys.Down
                Me.Dtg_particpante.Focus()
            Case Keys.Up
                Me.Dtg_particpante.Focus()
            Case Keys.Escape
                Me.Close()
        End Select

    End Sub

    Private Sub setValoresFormRef()

        Try
            _cliente.cid = Me.Dtg_particpante.CurrentRow.Cells(0).Value
            _cliente.cnome = Me.Dtg_particpante.CurrentRow.Cells(1).Value.ToString
            _clienteDAO.TrazClienteDaListaClientes(_cliente, MdlConexaoBD.ListaClientes)
        Catch ex As Exception
        End Try


    End Sub

    Private Sub rdb_cnpj_cpf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb_nome.CheckedChanged, rdb_codigo.CheckedChanged, rdb_cpf.CheckedChanged

        If rdb_cpf.Checked = True Then
            Me.lbl_pesquisa.Text = "CNPJ ou CPF:"
            Me.txt_pesquisa.SetBounds(232, 63, 119, 23)
            Me.txt_pesquisa.MaxLength = 20
            Me.txt_pesquisa.Text = ""
        End If

        If rdb_codigo.Checked = True Then
            Me.lbl_pesquisa.Text = "CODIGO:"
            Me.txt_pesquisa.SetBounds(200, 63, 65, 23)
            Me.txt_pesquisa.MaxLength = 7
            Me.txt_pesquisa.Text = ""
        End If

        If rdb_nome.Checked = True Then
            Me.lbl_pesquisa.Text = "NOME:"
            Me.txt_pesquisa.SetBounds(188, 63, 200, 23)
            Me.txt_pesquisa.MaxLength = 65
            Me.txt_pesquisa.Text = ""
        End If

    End Sub

    Private Sub txt_pesquisa_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_pesquisa.KeyPress

        If (rdb_cpf.Checked = True) OrElse (rdb_codigo.Checked = True) Then
            'permite só numeros
            If Char.IsLetter(e.KeyChar) Then
                e.Handled = True
            End If
        End If

        If rdb_nome.Checked = True Then
            'permite só letras
            If Char.IsNumber(e.KeyChar) Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub Frm_BuscaCliPedido_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.P
                If Me.txt_pesquisa.Focus() = False Then
                    Me.txt_pesquisa.Focus()
                    Me.txt_pesquisa.SelectAll()
                End If

            Case Keys.K
                If Me.btn_confirmar.Focus = False And Me.txt_pesquisa.Focus = False Then
                    Me.btn_confirmar.Focus()
                End If

        End Select

    End Sub

    Private Sub btn_confirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_confirmar.Click

        If Dtg_particpante.RowCount = 1 Then
            Me.Dtg_particpante.Focus()
            setValoresFormRef()
            Me.Close()
        ElseIf Dtg_particpante.RowCount > 1 Then
            Me.Dtg_particpante.Focus()
        Else
            MsgBox("Pesquise o registro desejado, por favor!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub executeF5()

        Dim mListClientePesq As New List(Of ClCliente)

        Dim pesquisa As String = Trim(txt_pesquisa.Text).ToUpper

        If MdlConexaoBD.ListaClientes.Count < 1 Then
            Me._erro = True
            Me._msgErro = "Não existe Clientes!"
            Return
        End If

        mListClientePesq.Clear()
        mListClientePesq = MdlConexaoBD.ListaClientes.FindAll(Function(c As ClCliente) c.cid <> 0)
        If Me.rdb_cpf.Checked Then

            If Not pesquisa.Equals("") Then
                mListClientePesq.Clear()
                mListClientePesq = MdlConexaoBD.ListaClientes.FindAll(Function(cli As ClCliente) _clFunc.RemoverCaracter2(cli.cCpfCnpj).StartsWith(pesquisa))
            End If

        ElseIf Me.rdb_codigo.Checked Then

            If Not pesquisa.Equals("") Then
                mListClientePesq.Clear()
                mListClientePesq = MdlConexaoBD.ListaClientes.FindAll(Function(cli As ClCliente) cli.cid = CInt(pesquisa))
            End If
        Else

            If Not pesquisa.Equals("") Then
                mListClientePesq.Clear()
                mListClientePesq = MdlConexaoBD.ListaClientes.FindAll(Function(cli As ClCliente) _clFunc.RemoverCaracter2(cli.cnome.ToUpper).StartsWith(pesquisa))
            End If
        End If

        If mListClientePesq.Count > 0 Then Dtg_particpante.Rows.Clear()
        For Each cli As ClCliente In mListClientePesq

            Dtg_particpante.Rows.Add(cli.cid, cli.cnome, cli.cCpfCnpj, cli.cestado)
        Next
        Me._erro = False

        If Me._contErros < 4 AndAlso Me._erro = True Then
            MsgBox(Me._msgErro, MsgBoxStyle.Exclamation)
        End If

        lbl_registros.Text = Dtg_particpante.RowCount
    End Sub

    Private Sub Dg_particpante_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dtg_particpante.CellContentDoubleClick

        setValoresFormRef()
        Me.Close()

    End Sub

    Private Sub dgrd_particpante_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtg_particpante.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                setValoresFormRef()
                Me.Close()
        End Select

    End Sub

    Private Sub Frm_BuscaCliPedido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TESTE
        Me.Dtg_particpante.Rows.Clear()
        Me.Dtg_particpante.Refresh()
        Me.txt_pesquisa.Text = ""
        If Me.rdb_cpf.Checked = True Then Me.rdb_cpf.Focus()
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()
        Me.rdb_nome.Checked = True
        executeF5()

    End Sub

    Private Sub Frm_BuscaCliPedido_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Me.Dtg_particpante.Rows.Clear()
        Me.Dtg_particpante.Refresh()
        Me.txt_pesquisa.Text = ""
        If Me.rdb_cpf.Checked = True Then Me.rdb_cpf.Focus()
        If Me.rdb_codigo.Checked = True Then Me.rdb_codigo.Focus()
        If Me.rdb_nome.Checked = True Then Me.rdb_nome.Focus()

    End Sub


    Private Sub txt_pesquisa_TextChanged(sender As Object, e As EventArgs) Handles txt_pesquisa.TextChanged
        executeF5()
    End Sub
End Class