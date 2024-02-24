Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql

Public Class FrmCadAtendente

    Dim _atendente As New ClAtendente
    Dim _atendenteDao As New ClAtendenteDAO
    Dim _funcoes As New ClFuncoes

    Dim tipoOperacao As String = "I"

    Private Sub FrmCadAtendente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecutaF5()
    End Sub

    Private Sub FrmCadAtendente_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F3
                ExecutaF3()
            Case Keys.F5
                ExecutaF5()
            Case Keys.Delete
                ExecuteDel()
        End Select

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click


        If IsNumeric(txtIdAtendente.Text) Then _atendente.aId = CInt(txtIdAtendente.Text)
        _atendente.aNome = Trim(txtAtendente.Text)
        _atendente.aComissao = CDbl(txtComissao.Text)
        If _atendenteDao.ValidaAtendente(_atendente, tipoOperacao) = False Then Return

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If tipoOperacao.Equals("I") Then
                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _atendenteDao.incAtendente(_atendente, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _atendenteDao.altAtendente(_atendente, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("Funcionário Salvo com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)
            _atendenteDao.TrazListAtendentes(MdlConexaoBD.mdlListAtendentes, MdlConexaoBD.conectionPadrao)
            txtAtendente.Text = "" : txtIdAtendente.Text = "" : txtComissao.Text = "0,00"
            _atendente.ZeraValores()
            ExecutaF5()
            tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()
        _atendenteDao.PreencheCboAtendentesBD(CboAtendente, MdlConexaoBD.conectionPadrao)
    End Sub

    Sub ExecuteDel()

        If CboAtendente.SelectedIndex < 0 Then MsgBox("Selecione um Funcionário para Excluir!") : Return
        If MessageBox.Show("Deseja Realmente Deletar o Funcionário -> """ & CboAtendente.SelectedItem & """ ?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _atendente.aNome = CboAtendente.SelectedItem
            _atendenteDao.TrazAtendenteNome(_atendente, MdlConexaoBD.conectionPadrao)


            Dim transacao As NpgsqlTransaction
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try

                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.CompanyName)
                    Return
                End Try

                transacao = conection.BeginTransaction
                _atendenteDao.delAtendente(_atendente, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("Funcionário Deletado com Sucesso!", MsgBoxStyle.Exclamation, Application.CompanyName)
                _atendenteDao.TrazListAtendentes(MdlConexaoBD.mdlListAtendentes, MdlConexaoBD.conectionPadrao)
                ExecutaF5()
                tipoOperacao = "I"
            Catch ex As Exception
                MsgBox("ERRO: " & ex.Message, MsgBoxStyle.Critical)
                Try
                    transacao.Rollback()

                Catch ex1 As Exception
                End Try

            Finally
                transacao = Nothing : conection = Nothing
            End Try



        End If

    End Sub

    Sub ExecutaF3()
        If CboAtendente.SelectedIndex < 0 Then MsgBox("Selecione um Funcionário para Alterar!", MsgBoxStyle.Exclamation, Application.CompanyName) : Return
        _atendente.aNome = CboAtendente.SelectedItem
        _atendenteDao.TrazAtendenteNome(_atendente, MdlConexaoBD.conectionPadrao)

        tipoOperacao = "A"
        txtIdAtendente.Text = _atendente.aId
        txtAtendente.Text = _atendente.aNome
        txtComissao.Text = _atendente.aComissao.ToString("0.00")
        txtAtendente.Focus()

    End Sub

    Private Sub txtComissao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComissao.KeyPress
        'permite só numeros virgula:
        If _funcoes.SoNumerosVirgula(CShort(Asc(e.KeyChar))) = 0 Then e.Handled = True
    End Sub

    Private Sub txtComissao_Leave(sender As Object, e As EventArgs) Handles txtComissao.Leave


        If IsNumeric(txtComissao.Text) Then

            txtComissao.Text = CDbl(txtComissao.Text).ToString("0.00")
            If CDbl(txtComissao.Text) = 100 Then

                If MessageBox.Show("O VALOR da Comissão está Igual a 100%! Deseja Continuar?", Application.CompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                   = Windows.Forms.DialogResult.No Then
                    txtComissao.Focus() : txtComissao.SelectAll()
                    Return
                End If
            ElseIf CDbl(txtComissao.Text) > 100 Then

                MsgBox("O VALOR da Comissão não deve ser Maior que 100%!", MsgBoxStyle.Exclamation, Application.CompanyName)
                txtComissao.Focus() : txtComissao.SelectAll()
                Return
            End If
        Else
            txtComissao.Text = "0,00"
        End If
        

    End Sub

    Private Sub FrmCadAtendente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            e.Handled = True : SendKeys.Send("{TAB}")
        End If
    End Sub
End Class