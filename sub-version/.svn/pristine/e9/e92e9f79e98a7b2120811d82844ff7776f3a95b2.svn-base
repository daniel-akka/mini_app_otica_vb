Public Class FrmSubGrupoResp

    Public _SubGrupo As New ClSubGrupoDespMensal
    Dim _SubGrupoDAO As New ClSubGrupoDespMensalDAO
    Dim _GrupoPesq As New ClGrupoDespMensal
    Dim _GrupoDAO As New ClGrupoDespMensalDAO
    Dim _ListaSubGrupo As New List(Of ClSubGrupoDespMensal)
    Dim _ListaSubGrupoAux As New List(Of ClSubGrupoDespMensal)

    Private Sub FrmSubGrupoResp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PreenchCboGrupo()
        cboGrupoDespPesquisa.SelectedIndex = 0
        executaF5()
        txtDescrSubGrupoPesquisa.Focus()
    End Sub

    Private Sub cboGrupoDespPesquisa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGrupoDespPesquisa.SelectedIndexChanged

        Try
            _GrupoPesq.zeraValores()
            If cboGrupoDespPesquisa.SelectedIndex >= 0 Then
                _GrupoPesq.gp_descricao = cboGrupoDespPesquisa.SelectedItem.ToString
                _GrupoDAO.TrazGrupoDespMensalDaListaPorNOME(_GrupoPesq, MdlConexaoBD.ListaGrupoDespMensal)
                executaF5()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Sub executaF5()

        _ListaSubGrupo.Clear()
        _ListaSubGrupoAux.Clear()
        If _GrupoPesq.gp_id > 0 Then

            _SubGrupoDAO.TrazListaSubGrupoDespMensalDaListaPorGrupoID(_GrupoPesq, _ListaSubGrupoAux, MdlConexaoBD.mdlListSubGrupoDespMensal)
        Else
            _SubGrupoDAO.TrazListaSubGrupoDespMensalDaLista(_ListaSubGrupoAux, MdlConexaoBD.mdlListSubGrupoDespMensal)
        End If

        If Not Trim(txtDescrSubGrupoPesquisa.Text).Equals("") Then
            _ListaSubGrupo = _ListaSubGrupoAux.FindAll(Function(sb As ClSubGrupoDespMensal) sb.sgp_descricao.Contains(Trim(txtDescrSubGrupoPesquisa.Text)))
        Else
            _ListaSubGrupo = _ListaSubGrupoAux
        End If

        dtgSubGrupo.Rows.Clear()
        For Each sb As ClSubGrupoDespMensal In _ListaSubGrupo
            dtgSubGrupo.Rows.Add(sb.sgp_id, sb.sgp_gpid, sb.sgp_gpdescricao, sb.sgp_descricao)
        Next
    End Sub

    Sub PreenchCboGrupo()

        _GrupoDAO.PreencheCboGrupoListaPesq(cboGrupoDespPesquisa, MdlConexaoBD.ListaGrupoDespMensal)
        cboGrupoDespPesquisa.SelectedIndex = 0
    End Sub

    Private Sub txtDescrSubGrupoPesquisa_TextChanged(sender As Object, e As EventArgs) Handles txtDescrSubGrupoPesquisa.TextChanged
        executaF5()
    End Sub

    Private Sub txtDescrSubGrupoPesquisa_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescrSubGrupoPesquisa.KeyDown

        Select Case e.KeyCode
            Case Keys.Down
                Me.dtgSubGrupo.Focus()

            Case Keys.Enter

                If dtgSubGrupo.RowCount = 1 Then
                    Me.dtgSubGrupo.Focus()
                    trazSubGrupoDTG()
                End If
                Me.dtgSubGrupo.Focus()
        End Select
    End Sub

    Private Sub dtgSubGrupo_DoubleClick(sender As Object, e As EventArgs) Handles dtgSubGrupo.DoubleClick

        trazSubGrupoDTG()

    End Sub

    Private Sub dtgSubGrupo_KeyDown(sender As Object, e As KeyEventArgs) Handles dtgSubGrupo.KeyDown

        If e.KeyCode = Keys.Enter Then
            trazSubGrupoDTG()
        End If

    End Sub

    Sub trazSubGrupoDTG()

        Try

            If Me.dtgSubGrupo.CurrentRow.IsNewRow = False Then
                _SubGrupo.sgp_id = Me.dtgSubGrupo.CurrentRow.Cells(0).Value
                _SubGrupoDAO.TrazSubGrupoDespMensalDaListaPorID(_SubGrupo, MdlConexaoBD.mdlListSubGrupoDespMensal)
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        executaF5()
    End Sub

    Private Sub FrmSubGrupoResp_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.F5
                executaF5()
        End Select
    End Sub
End Class