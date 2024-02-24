Imports System.Text
Imports System.Data
Imports System.Math
Imports Npgsql
Public Class FrmCadGrupoDespMensal

    Dim _GrupoDespMensal As New ClGrupoDespMensal
    Dim _GrupoDespMensalDao As New ClGrupoDespMensalDAO
    Dim _funcoes As New ClFuncoes
    Public _Modificacao As Boolean = False

    Dim _tipoOperacao As String = "I"

    Private Sub FrmCadGrupoDespMensal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ExecutaF5()
    End Sub

    Private Sub FrmCadGrupoDespMensal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

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

        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If IsNumeric(txtIdGrupo.Text) Then _GrupoDespMensal.gp_id = CInt(txtIdGrupo.Text)
        _GrupoDespMensal.gp_descricao = Trim(txtDescrGrupo.Text)
        If _GrupoDespMensalDao.ValidaGrupoDespMensal(_GrupoDespMensal, _tipoOperacao) = False Then Return

        Dim connection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)
        Try


            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("ERRO:: " & ex.Message)
                connection = Nothing : Return
            End Try

            If _tipoOperacao.Equals("I") Then
                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _GrupoDespMensalDao.incGrupoDespMensal(_GrupoDespMensal, connection, transacao)
                transacao.Commit()

            Else

                Dim transacao As NpgsqlTransaction = connection.BeginTransaction
                _GrupoDespMensalDao.altGrupoDespMensal(_GrupoDespMensal, connection, transacao)
                transacao.Commit()

            End If

            MsgBox("GRUPO Gravado com Sucesso!", MsgBoxStyle.Exclamation)
            _Modificacao = True
            _GrupoDespMensalDao.TrazListGrupoDespMensalDoBANCO(MdlConexaoBD.ListaGrupoDespMensal, MdlConexaoBD.conectionPadrao)
            txtDescrGrupo.Text = "" : txtIdGrupo.Text = ""
            _GrupoDespMensal.ZeraValores()
            ExecutaF5()
            _tipoOperacao = "I"
        Catch ex As Exception
            MsgBox("ERRO:: " & ex.Message)
        Finally
            connection.ClearPool() : connection.Close() : connection = Nothing
        End Try

    End Sub

    Sub ExecutaF5()

        If MdlConexaoBD.sincronizado Then
            _GrupoDespMensalDao.PreencheCboGrupoLista(CboGrupos, MdlConexaoBD.ListaGrupoDespMensal)
        Else
            _GrupoDespMensalDao.PreencheCboGrupos(CboGrupos, MdlConexaoBD.conectionPadrao)
        End If

    End Sub

    Sub ExecuteDel()
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If CboGrupos.SelectedIndex < 0 Then MsgBox("Selecione um GrupoDespMensal para Excluir!") : Return
        If MessageBox.Show("Deseja Realmente Deletar o GrupoDespMensal -> """ & CboGrupos.SelectedItem & """ ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                    = Windows.Forms.DialogResult.Yes Then


            _GrupoDespMensal.gp_descricao = CboGrupos.SelectedItem.ToString
            _GrupoDespMensalDao.TrazGrupoNomeDoBANCO(_GrupoDespMensal, MdlConexaoBD.conectionPadrao)


            Dim transacao As NpgsqlTransaction
            Dim conection As New NpgsqlConnection(MdlConexaoBD.conectionPadrao)

            Try

                Try
                    conection.Open()
                Catch ex As Exception
                    MsgBox("ERRO ao ABRIR connection:: " & ex.Message, MsgBoxStyle.Exclamation, Application.ProductName)
                    Return
                End Try

                transacao = conection.BeginTransaction
                _GrupoDespMensalDao.delGrupoDespMensal(_GrupoDespMensal, conection, transacao)
                transacao.Commit() : conection.ClearPool() : conection.Close()
                MsgBox("GRUPO Deletado com Sucesso!", MsgBoxStyle.Exclamation)
                _Modificacao = True
                _GrupoDespMensalDao.TrazListGrupoDespMensalDoBANCO(MdlConexaoBD.ListaGrupoDespMensal, MdlConexaoBD.conectionPadrao)
                ExecutaF5()
                _tipoOperacao = "I"
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
        If MdlConexaoBD.sincronizado Then
            MsgBox(MdlParametros.msgAmbienteSincronizado, MsgBoxStyle.Exclamation, Application.CompanyName.ToUpper)
            Return
        End If

        If CboGrupos.SelectedIndex < 0 Then MsgBox("Selecione um GRUPO para Alterar!") : Return
        _GrupoDespMensal.gp_descricao = CboGrupos.SelectedItem.ToString
        _GrupoDespMensalDao.TrazGrupoNomeDoBANCO(_GrupoDespMensal, MdlConexaoBD.conectionPadrao)

        _tipoOperacao = "A"
        txtIdGrupo.Text = _GrupoDespMensal.gp_id
        txtDescrGrupo.Text = _GrupoDespMensal.gp_descricao
        txtDescrGrupo.Focus()

    End Sub

End Class