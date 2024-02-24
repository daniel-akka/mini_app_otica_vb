Imports System.IO
Imports System.Text
Public Class ClSincronizar

    Public Property caminhoPasta As String

    'Arquivos para sincronizar:
    Public ListaProdutos As New List(Of ClProduto)
    Public ListaClientes As New List(Of ClCliente)
    Public ListaServicos As New List(Of ClServicos)
    Public ListaAtendentes As New List(Of ClAtendente)
    Public ListaAgendamentos As New List(Of ClAgendamento)
    Public ListaFornecedores As New List(Of ClFornecedor)
    Public ListaAbrirFecharCX As New List(Of ClAbrirFecharCaixa)
    Public ListaCaixa As New List(Of ClCaixa)
    Public ListaContasAPagar As New List(Of ClAPagarTotal)
    Public ListaContasAReceber As New List(Of ClAReceberTotal)
    Public ListaGrupoDespMensal As New List(Of ClGrupoDespMensal)
    Public ListaDespMensal As New List(Of ClDespesaMensal)
    Public ListaVendasServico As New List(Of ClVendaServico)
    Public ListaVendasServicoItens As New List(Of ClVendaServicoItens)
    Public ListaSaudePessoa As New List(Of ClInfoSaudePessoa)
    Public ListaItensSaudePessoa As New List(Of ClInfoSaudePessoaItem)
    Public ListaIMC As New List(Of ClIMC)


    Sub salvarArquivosTEXTO(sincro As ClSincronizar)

        Dim tabela As String = ""

        'Cliente:
        tabela = MdlParametros.arqCliente
        Me.SalvaClientesTEXTO(sincro.caminhoPasta & tabela, sincro.ListaClientes)

        'Servico:
        tabela = MdlParametros.arqServico
        Me.SalvaServicosTEXTO(sincro.caminhoPasta & tabela, sincro.ListaServicos)

        'Produto:
        tabela = MdlParametros.arqProduto
        Me.SalvaProdutosTEXTO(sincro.caminhoPasta & tabela, sincro.ListaProdutos)

        'Atendente:
        tabela = MdlParametros.arqAtendente
        Me.SalvaAtendentesTEXTO(sincro.caminhoPasta & tabela, sincro.ListaAtendentes)

        'Agendamento:
        tabela = MdlParametros.arqAgendamento
        Me.SalvaAgendamentosTEXTO(sincro.caminhoPasta & tabela, sincro.ListaAgendamentos)

        'Fornecedor:
        tabela = MdlParametros.arqFornecedor
        Me.SalvaFornecedoresTEXTO(sincro.caminhoPasta & tabela, sincro.ListaFornecedores)

        'AbrirFechar CX:
        tabela = MdlParametros.arqAbrirFecharCX
        Me.SalvaAbrirFecharCXTEXTO(sincro.caminhoPasta & tabela, sincro.ListaAbrirFecharCX)

        'Caixa:
        tabela = MdlParametros.arqCaixa
        Me.SalvaCaixaTEXTO(sincro.caminhoPasta & tabela, sincro.ListaCaixa)

        'APagar:
        tabela = MdlParametros.arqAPagar
        Me.SalvaContasAPagarTEXTO(sincro.caminhoPasta & tabela, sincro.ListaContasAPagar)

        'AReceber:
        tabela = MdlParametros.arqAReceber
        Me.SalvaContasAReceberTEXTO(sincro.caminhoPasta & tabela, sincro.ListaContasAReceber)

        'GrupoDesp:
        tabela = MdlParametros.arqGrupoDesp
        Me.SalvaGrupoDespMensalTEXTO(sincro.caminhoPasta & tabela, sincro.ListaGrupoDespMensal)

        'DespMensal:
        tabela = MdlParametros.arqDespMensal
        Me.SalvaDespMensalTEXTO(sincro.caminhoPasta & tabela, sincro.ListaDespMensal)

        'DespMensal:
        tabela = MdlParametros.arqVendaServico
        Me.SalvaVendasServicoTEXTO(sincro.caminhoPasta & tabela, sincro.ListaVendasServico)

        'DespMensal:
        tabela = MdlParametros.arqVendaServicoItens
        Me.SalvaVendasServicoItensTEXTO(sincro.caminhoPasta & tabela, sincro.ListaVendasServicoItens)

        'SaudePessoa:
        tabela = MdlParametros.arqSaudePessoa
        Me.SalvaSaudePessoaTEXTO(sincro.caminhoPasta & tabela, sincro.ListaSaudePessoa)

        'ItemSaudePessoa:
        tabela = MdlParametros.arqSaudePessoaItens
        Me.SalvaSaudePessoaItensTEXTO(sincro.caminhoPasta & tabela, sincro.ListaItensSaudePessoa)

        'IMC:
        tabela = MdlParametros.arqIMC
        Me.SalvaImcTEXTO(sincro.caminhoPasta & tabela, sincro.ListaIMC)

    End Sub

    'SALVA ARQUIVOS TEXTO: *******************************
    Public Sub SalvaClientesTEXTO(caminhoArquivo As String, listCli As List(Of ClCliente))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'Cliente:
        tabela = "\" & MdlParametros.arqCliente
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each cli As ClCliente In listCli

            'id?nome?cpfCnpj?telefone?estado?cidade?cep?endereco?bairro?diames?datanascimento?cidadeid?cidadecodigo?inativo
            Linha = cli.cid & "?" & cli.cnome & "?" & cli.cCpfCnpj & "?" & cli.ctelefone & "?" & cli.cestado & "?" & cli.ccidade & "?"
            Linha += cli.ccep & "?" & cli.cendereco & "?" & cli.cbairro & "?" & cli.cdiames & "?"
            Linha += cli.cdatanascimento & "?" & cli.cidadeid & "?" & cli.cidadecodigo & "?" & cli.cinativo
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaServicosTEXTO(caminhoArquivo As String, listServ As List(Of ClServicos))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'Serviço:
        tabela = "\" & MdlParametros.arqServico
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each serv As ClServicos In listServ

            'sid?sdescricao?svalor?sdespcartaodinheiro?sdespcartaoporcentagem?sidatendente?snomeatendente?sdataalteracao
            Linha = serv.sid & "?" & serv.sdescricao & "?" & serv.svalor & "?" & serv.sdespcartaodinheiro & "?" & serv.sdespcartaoporcentagem & "?" & serv.sidatendente & "?"
            Linha += serv.snomeatendente & "?" & serv.sdataalteracao
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaProdutosTEXTO(caminhoArquivo As String, listProd As List(Of ClProduto))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'Produto:
        tabela = "\" & MdlParametros.arqProduto
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each prod As ClProduto In listProd

            'pid?pdescricao?ppeso?pcodigo?pinformacao?pcusto?pmargemlucro?pvenda?pestoque?punidade?pdespadicional
            Linha = prod.pId & "?" & prod.pDescricao & "?" & prod.pPeso & "?" & prod.pCodigo & "?" & prod.pInformacao & "?" & prod.pCusto & "?"
            Linha += prod.pMargemLucro & "?" & prod.pVenda & "?" & prod.pEstoque & "?" & prod.pUnidade & "?" & prod.pDespAdicional
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaAtendentesTEXTO(caminhoArquivo As String, listAtendente As List(Of ClAtendente))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'Atendente:
        tabela = "\" & MdlParametros.arqAtendente
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each atend As ClAtendente In listAtendente

            'aId?aNome?aComissao
            Linha = atend.aId & "?" & atend.aNome & "?" & atend.aComissao
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaAgendamentosTEXTO(caminhoArquivo As String, listAgendamento As List(Of ClAgendamento))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'Agendamento:
        tabela = "\" & MdlParametros.arqAgendamento
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each agend As ClAgendamento In listAgendamento

            'a_id?a_empresaid?a_empresanome?a_dtemis?a_dtagend?a_status?a_iddoutor?a_doutor?a_valor?a_cancelado?a_usuario?a_usuarioalt?a_financeiro?
            'a_turno?a_info?a_pessoaid?a_pessoanome?a_hora?a_alterado
            Linha = agend.a_id & "?" & agend.a_empresaid & "?" & agend.a_empresanome & "?" & agend.a_dtemis & "?" & agend.a_dtagend & "?" & agend.a_status & "?"
            Linha += agend.a_iddoutor & "?" & agend.a_doutor & "?" & agend.a_valor & "?" & agend.a_cancelado & "?" & agend.a_usuario & "?" & agend.a_usuarioalt & "?"
            Linha += agend.a_financeiro & "?" & agend.a_turno & "?" & agend.a_info & "?" & agend.a_pessoaid & "?" & agend.a_pessoanome & "?" & agend.a_hora & "?" & agend.a_alterado

            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaFornecedoresTEXTO(caminhoArquivo As String, listFornecedor As List(Of ClFornecedor))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'Fornecedor:
        tabela = "\" & MdlParametros.arqFornecedor
        Dim fsProd As FileStream
        Try
            fsProd = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fsProd = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fsProd)
        For Each forn As ClFornecedor In listFornecedor

            'pId?pNome?pIdEstado?pIdCidade?pEstado?pCidade?pfTelefone?pfCpf?pfCnpj?pEndereco?pBairro
            Linha = forn.pId & "?" & forn.pNome & "?" & forn.pIdEstado & "?" & forn.pIdCidade & "?" & forn.pEstado & "?" & forn.pCidade & "?"
            Linha += forn.pfTelefone & "?" & forn.pfCpf & "?" & forn.pfCnpj & "?" & forn.pEndereco & "?" & forn.pBairro
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaAbrirFecharCXTEXTO(caminhoArquivo As String, listAbrirFecharCX As List(Of ClAbrirFecharCaixa))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'AbrirFecharCX:
        tabela = "\" & MdlParametros.arqAbrirFecharCX
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each aber As ClAbrirFecharCaixa In listAbrirFecharCX

            'Af_id1?Af_datahora1?Af_tipo1?Af_concluido1?Af_total_dinheiro1?Af_total_cartaocredito?Af_id_abertura1?Af_total_apurado_dn1?
            'Af_total_apurado_ctc?af_total_pix?af_total_transferencia?af_total_apurado_ctd?af_total_apurado_pix?af_total_apurado_tra?
            'af_total_cartaodebito?af_total_crediario?af_total_apurado_crd
            Linha = aber.Af_id1 & "?" & aber.Af_datahora1 & "?" & aber.Af_tipo1 & "?" & aber.Af_concluido1 & "?" & aber.Af_total_dinheiro1 & "?" & aber.Af_total_cartaocredito & "?"
            Linha += aber.Af_id_abertura1 & "?" & aber.Af_total_apurado_dn1 & "?" & aber.Af_total_apurado_ctc & "?" & aber.af_total_pix & "?"
            Linha += aber.af_total_transferencia & "?" & aber.af_total_apurado_ctd & "?" & aber.af_total_apurado_pix & "?" & aber.af_total_apurado_tra & "?"
            Linha += aber.af_total_cartaodebito & "?" & aber.af_total_crediario & "?" & aber.af_total_apurado_crd
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaCaixaTEXTO(caminhoArquivo As String, listCaixa As List(Of ClCaixa))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'Caixa:
        tabela = "\" & MdlParametros.arqCaixa
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each cx As ClCaixa In listCaixa

            'Cx_id1?Cx_tipo1?Cx_datahora1?Cx_motivo1?Cx_af_id1?Cx_valor1?Cx_tipo_valor1
            Linha = cx.Cx_id1 & "?" & cx.Cx_tipo1 & "?" & cx.Cx_datahora1 & "?" & cx.Cx_motivo1 & "?" & cx.Cx_af_id1 & "?" & cx.Cx_valor1 & "?" & cx.Cx_tipo_valor1
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaContasAPagarTEXTO(caminhoArquivo As String, listAPagar As List(Of ClAPagarTotal))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'APagar:
        tabela = "\" & MdlParametros.arqAPagar
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each apagar As ClAPagarTotal In listAPagar

            'apt_id?apt_empresaid?apt_empresanome?apt_portadorid?apt_portadornome?apt_portadortipo?apt_dataemissao?apt_datavencimento?
            'apt_valor?apt_datapagamento?apt_valorrestante?apt_desconto?apt_acrescimo?apt_observacao?apt_funcionarioid?apt_funcionarionome?
            'apt_valorpago?apt_tela?apt_alteradodt?apt_alteradofunc?apt_estornado?apt_estornadovalor?apt_situacao?apt_tipopagamento?
            'apt_idcaixa?apt_pagodinheiro?apt_pagocartaocred?apt_pagocartaodeb?apt_pagopix?apt_pagotransferencia?apt_idvendaservico?
            'apt_idvendaproduto?apt_tipodocumentoid?apt_tipodocumentodescr
            Linha = apagar.apt_id & "?" & apagar.apt_empresaid & "?" & apagar.apt_empresanome & "?" & apagar.apt_portadorid & "?" & apagar.apt_portadornome & "?"
            Linha += apagar.apt_portadortipo & "?" & apagar.apt_dataemissao & "?" & apagar.apt_datavencimento & "?" & apagar.apt_valor & "?" & apagar.apt_datapagamento & "?"
            Linha += apagar.apt_valorrestante & "?" & apagar.apt_desconto & "?" & apagar.apt_acrescimo & "?" & apagar.apt_observacao & "?" & apagar.apt_funcionarioid & "?"
            Linha += apagar.apt_funcionarionome & "?" & apagar.apt_valorpago & "?" & apagar.apt_tela & "?" & apagar.apt_alteradodt & "?" & apagar.apt_alteradofunc & "?"
            Linha += apagar.apt_estornado & "?" & apagar.apt_estornadovalor & "?" & apagar.apt_situacao & "?" & apagar.apt_tipopagamento & "?" & apagar.apt_idcaixa & "?"
            Linha += apagar.apt_pagodinheiro & "?" & apagar.apt_pagocartaocred & "?" & apagar.apt_pagocartaodeb & "?" & apagar.apt_pagopix & "?" & apagar.apt_pagotransferencia & "?"
            Linha += apagar.apt_idvendaservico & "?" & apagar.apt_idvendaproduto & "?" & apagar.apt_tipodocumentoid & "?" & apagar.apt_tipodocumentodescr
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaContasAReceberTEXTO(caminhoArquivo As String, listAReceber As List(Of ClAReceberTotal))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'AReceber:
        tabela = "\" & MdlParametros.arqAReceber
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each ar As ClAReceberTotal In listAReceber

            'art_id?art_empresaid?art_empresanome?art_clienteid?art_clientenome?art_dataemissao?art_datavencimento?art_valor?art_datapagamento?
            'art_valorrestante?art_desconto?art_acrescimo?art_observacao?art_funcionarioid?art_funcionarionome?art_valorpago?art_tela?art_alteradodt?
            'art_alteradofunc?art_estornado?art_estornadovalor?art_situacao?art_tipopagamento?art_idcaixa?art_pagodinheiro?art_pagocartaocred?art_pagocartaodeb?
            'art_pagopix?art_pagotransferencia?art_idvendaservico?art_idvendaproduto
            Linha = ar.art_id & "?" & ar.art_empresaid & "?" & ar.art_empresanome & "?" & ar.art_clienteid & "?" & ar.art_clientenome & "?"
            Linha += ar.art_dataemissao & "?" & ar.art_datavencimento & "?" & ar.art_valor & "?" & ar.art_datapagamento & "?" & ar.art_valorrestante & "?"
            Linha += ar.art_desconto & "?" & ar.art_acrescimo & "?" & ar.art_observacao & "?" & ar.art_funcionarioid & "?" & ar.art_funcionarionome & "?"
            Linha += ar.art_valorpago & "?" & ar.art_tela & "?" & ar.art_alteradodt & "?" & ar.art_alteradofunc & "?" & ar.art_estornado & "?"
            Linha += ar.art_estornadovalor & "?" & ar.art_situacao & "?" & ar.art_tipopagamento & "?" & ar.art_idcaixa & "?" & ar.art_pagodinheiro & "?"
            Linha += ar.art_pagocartaocred & "?" & ar.art_pagocartaodeb & "?" & ar.art_pagopix & "?" & ar.art_pagotransferencia & "?" & ar.art_idvendaservico & "?" & ar.art_idvendaproduto
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaGrupoDespMensalTEXTO(caminhoArquivo As String, Lista As List(Of ClGrupoDespMensal))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'GrupoDespM:
        tabela = "\" & MdlParametros.arqGrupoDesp
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each grupo As ClGrupoDespMensal In Lista

            'gp_id?gp_descricao
            Linha = grupo.gp_id & "?" & grupo.gp_descricao
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaDespMensalTEXTO(caminhoArquivo As String, Lista As List(Of ClDespesaMensal))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'DespMensal:
        tabela = "\" & MdlParametros.arqDespMensal
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each desp As ClDespesaMensal In Lista

            'dm_id?dm_empresaid?dm_empresanome?dm_gpid?dm_gpdescricao?dm_sgpid?dm_sgpdescricao?dm_data_despesa?dm_data_inclusao?
            'dm_valor?dm_observacao?dm_alteracao?dm_fechado
            Linha = desp.dm_id & "?" & desp.dm_empresaid & "?" & desp.dm_empresanome & "?" & desp.dm_gpid & "?" & desp.dm_gpdescricao & "?"
            Linha += desp.dm_sgpid & "?" & desp.dm_sgpdescricao & "?" & desp.dm_data_despesa & "?" & desp.dm_data_inclusao & "?" & desp.dm_valor & "?"
            Linha += desp.dm_observacao & "?" & desp.dm_alteracao & "?" & desp.dm_fechado
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaVendasServicoTEXTO(caminhoArquivo As String, lista As List(Of ClVendaServico))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'VendaServiço:
        tabela = "\" & MdlParametros.arqVendaServico
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each vs As ClVendaServico In lista

            'vsid?vsempresaid?vsclienteid?vsempresanome?vsempresauf?vsempresacidade?vsclientenome?vsclienteuf?vsclientecidade?vsdatahora?
            'vssubtotal?vsdesconto?vstotalgeral?vspagodinheiro?vspagocredito?vspagodebito?vspagopix?vspagotransferencia?vspagocrediario
            Linha = vs.vsid & "?" & vs.vsempresaid & "?" & vs.vsclienteid & "?" & vs.vsempresanome & "?" & vs.vsempresauf & "?" & vs.vsempresacidade & "?" & vs.vsclientenome & "?"
            Linha += vs.vsclienteuf & "?" & vs.vsclientecidade & "?" & vs.vsdatahora & "?" & vs.vssubtotal & "?" & vs.vsdesconto & "?" & vs.vstotalgeral & "?"
            Linha += vs.vspagodinheiro & "?" & vs.vspagocredito & "?" & vs.vspagodebito & "?" & vs.vspagopix & "?" & vs.vspagotransferencia & "?" & vs.vspagocrediario
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaVendasServicoItensTEXTO(caminhoArquivo As String, lista As List(Of ClVendaServicoItens))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'ITensVendaServiço:
        tabela = "\" & MdlParametros.arqVendaServicoItens
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each vs As ClVendaServicoItens In lista

            'vsi_id?vsi_data?vs_id?vs_totalcartao?vs_totalcartaoseparado?vsi_servicoid?vsi_serviconome?vsi_servicodespctporcent?vsi_servicodespctvalor?
            'vsi_atendenteid?vsi_atendentenome?vsi_atendentecomissao?vsi_quantidadeservico?vsi_valorservico?vsi_descontoservico?vsi_subtotalservico?
            'vsi_valortotalservico?vsi_despcartaoseparado?vsi_valorcomissao
            Linha = vs.Id & "?" & vs.Data & "?" & vs.IdVendaServico & "?" & vs.TotalCartaoVendaServico & "?" & vs.TotalCartaoSeparadoVendaServico & "?"
            Linha += vs.IdServico & "?" & vs.NomeServico & "?" & vs.DespCartaoServico_Porcent & "?" & vs.DespCartaoServico_Valor & "?"
            Linha += vs.IdAtendente & "?" & vs.NomeAtendente & "?" & vs.ComissaoAtendente & "?" & vs.QuantidadeServico & "?" & vs.ValorServico & "?"
            Linha += vs.DescontoServico & "?" & vs.SubTotalServico & "?" & vs.ValorTotalServico & "?" & vs.DespCartaoSeparado & "?" & vs.ValorComissao
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaSaudePessoaTEXTO(caminhoArquivo As String, listSaudePessoa As List(Of ClInfoSaudePessoa))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'SaudePessoa:
        tabela = "\" & MdlParametros.arqSaudePessoa
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each sp As ClInfoSaudePessoa In listSaudePessoa

            'inp_id?inp_pessoaid?inp_pessoanome?inp_pessoapeso?inp_pessoaaltura?inp_pessoaidade?inp_resultadoIMC?inp_imcid?inp_imcclassificacao?
            'inp_comorbidade1?inp_comorbidade2?inp_comorbidade3?inp_comorbidade4?inp_comorbidade5?inp_comorbidade6?inp_observacao
            Linha = sp.inp_id & "?" & sp.inp_pessoaid & "?" & sp.inp_pessoanome & "?" & sp.inp_pessoapeso & "?" & sp.inp_pessoaaltura & "?" & sp.inp_pessoaidade & "?"
            Linha += sp.inp_resultadoIMC & "?" & sp.inp_imcid & "?" & sp.inp_imcclassificacao & "?" & sp.inp_comorbidade1 & "?" & sp.inp_comorbidade2 & "?"
            Linha += sp.inp_comorbidade3 & "?" & sp.inp_comorbidade4 & "?" & sp.inp_comorbidade5 & "?" & sp.inp_comorbidade6 & "?" & sp.inp_observacao
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaSaudePessoaItensTEXTO(caminhoArquivo As String, lista As List(Of ClInfoSaudePessoaItem))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'SaudePessoaIENS:
        tabela = "\" & MdlParametros.arqSaudePessoaItens
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)
        For Each spi As ClInfoSaudePessoaItem In lista

            'inpi_id?inp_id?inpi_servicoid?inpi_serviconome?inpi_produtoid?inpi_produtodescricao
            Linha = spi.inpi_id & "?" & spi.inp_id & "?" & spi.inpi_servicoid & "?" & spi.inpi_serviconome & "?" & spi.inpi_produtoid & "?" & spi.inpi_produtodescricao
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub

    Public Sub SalvaImcTEXTO(caminhoArquivo As String, lista As List(Of ClIMC))

        Dim tabela As String = ""
        Dim sr As StreamWriter
        Dim Linha As String = ""

        'IMC:
        tabela = "\" & MdlParametros.arqIMC
        Dim fs As FileStream
        Try
            fs = New FileStream(caminhoArquivo, FileMode.Truncate, FileAccess.ReadWrite)
        Catch ex As Exception
            fs = New FileStream(caminhoArquivo, FileMode.Create, FileAccess.ReadWrite)
        End Try
        sr = New StreamWriter(fs, Encoding.UTF8)

        For Each spi As ClIMC In lista

            'imc_id?imc_minimo?imc_maximo?imc_classificacao?imc_problemas
            Linha = spi.imc_id & "?" & spi.imc_minimo & "?" & spi.imc_maximo & "?" & spi.imc_classificacao & "?" & spi.imc_problemas
            sr.WriteLine(Linha)
        Next
        sr.Close()

    End Sub


    'LER ARQUIVOS TEXTO: **********************************
    Public Function TrazListaClientesArquivoTEXTO(caminhoArquivo As String) As List(Of ClCliente)

        Dim lista As New List(Of ClCliente)
        Dim Cliente As New ClCliente

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try

        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            Cliente.ZeraValores()
            With Cliente

                'id?nome?cpfCnpj?telefone?estado?cidade?cep?endereco?bairro?diames?datanascimento?cidadeid?cidadecodigo?inativo
                .cid = mArray(0)
                .cnome = mArray(1)
                .cCpfCnpj = mArray(2)
                .ctelefone = mArray(3)
                .cestado = mArray(4)
                .ccidade = mArray(5)
                .ccep = mArray(6)
                .cendereco = mArray(7)
                .cbairro = mArray(8)
                .cdiames = mArray(9)
                .cdatanascimento = mArray(10)
                .cidadeid = mArray(11)
                .cidadecodigo = mArray(12)
                .cinativo = mArray(13)
            End With
            lista.Add(New ClCliente(Cliente))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaServicosArquivoTEXTO(caminhoArquivo As String) As List(Of ClServicos)

        Dim lista As New List(Of ClServicos)
        Dim Servico As New ClServicos

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            Servico.ZeraValores()
            With Servico

                'sid?sdescricao?svalor?sdespcartaodinheiro?sdespcartaoporcentagem?sidatendente?snomeatendente?sdataalteracao
                .sid = mArray(0)
                .sdescricao = mArray(1)
                .svalor = mArray(2)
                .sdespcartaodinheiro = mArray(3)
                .sdespcartaoporcentagem = mArray(4)
                .sidatendente = mArray(5)
                .snomeatendente = mArray(6)
                .sdataalteracao = mArray(7)
            End With
            lista.Add(New ClServicos(Servico))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaProdutosArquivoTEXTO(caminhoArquivo As String) As List(Of ClProduto)

        Dim lista As New List(Of ClProduto)
        Dim Produto As New ClProduto

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            Produto.ZeraValores()
            With Produto

                'pid?pdescricao?ppeso?pcodigo?pinformacao?pcusto?pmargemlucro?pvenda?pestoque?punidade?pdespadicional
                .pId = mArray(0)
                .pDescricao = mArray(1)
                .pPeso = mArray(2)
                .pCodigo = mArray(3)
                .pInformacao = mArray(4)
                .pCusto = mArray(5)
                .pMargemLucro = mArray(6)
                .pVenda = mArray(7)
                .pEstoque = mArray(8)
                .pUnidade = mArray(9)
                .pDespAdicional = mArray(10)

            End With
            lista.Add(New ClProduto(Produto))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaAtendentesArquivoTEXTO(caminhoArquivo As String) As List(Of ClAtendente)

        Dim lista As New List(Of ClAtendente)
        Dim Atendente As New ClAtendente

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            Atendente.ZeraValores()
            With Atendente

                'aId?aNome?aComissao
                .aId = mArray(0)
                .aNome = mArray(1)
                .aComissao = mArray(2)

            End With
            lista.Add(New ClAtendente(Atendente))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaAgendamentosArquivoTEXTO(caminhoArquivo As String) As List(Of ClAgendamento)

        Dim lista As New List(Of ClAgendamento)
        Dim Agendamento As New ClAgendamento

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            Agendamento.ZeraValores()
            With Agendamento

                'a_id?a_empresaid?a_empresanome?a_dtemis?a_dtagend?a_status?a_iddoutor?a_doutor?a_valor?a_cancelado?a_usuario?a_usuarioalt?a_financeiro?
                'a_turno?a_info?a_pessoaid?a_pessoanome?a_hora?a_alterado
                .a_id = mArray(0)
                .a_empresaid = mArray(1)
                .a_empresanome = mArray(2)
                .a_dtemis = mArray(3)
                .a_dtagend = mArray(4)
                .a_status = mArray(5)
                .a_iddoutor = mArray(6)
                .a_doutor = mArray(7)
                .a_valor = mArray(8)
                .a_cancelado = mArray(9)
                .a_usuario = mArray(10)
                .a_usuarioalt = mArray(11)
                .a_financeiro = mArray(12)
                .a_turno = mArray(13)
                .a_info = mArray(14)
                .a_pessoaid = mArray(15)
                .a_pessoanome = mArray(16)
                .a_hora = mArray(17)
                .a_alterado = mArray(18)

            End With
            lista.Add(New ClAgendamento(Agendamento))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaFornecedoresArquivoTEXTO(caminhoArquivo As String) As List(Of ClFornecedor)

        Dim lista As New List(Of ClFornecedor)
        Dim Fornecedor As New ClFornecedor

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            Fornecedor.ZeraValores()
            With Fornecedor

                'pId?pNome?pIdEstado?pIdCidade?pEstado?pCidade?pfTelefone?pfCpf?pfCnpj?pEndereco?pBairro
                .pId = mArray(0)
                .pNome = mArray(1)
                .pIdEstado = mArray(2)
                .pIdCidade = mArray(3)
                .pEstado = mArray(4)
                .pCidade = mArray(5)
                .pfTelefone = mArray(6)
                .pfCpf = mArray(7)
                .pfCnpj = mArray(8)
                .pEndereco = mArray(9)
                .pBairro = mArray(10)

            End With
            lista.Add(New ClFornecedor(Fornecedor))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaAbrirFecharCXArquivoTEXTO(caminhoArquivo As String) As List(Of ClAbrirFecharCaixa)

        Dim lista As New List(Of ClAbrirFecharCaixa)
        Dim AbrirFecharCX As New ClAbrirFecharCaixa

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            AbrirFecharCX.zeraValores()
            With AbrirFecharCX

                'Af_id1?Af_datahora1?Af_tipo1?Af_concluido1?Af_total_dinheiro1?Af_total_cartaocredito?Af_id_abertura1?Af_total_apurado_dn1?
                'Af_total_apurado_ctc?af_total_pix?af_total_transferencia?af_total_apurado_ctd?af_total_apurado_pix?af_total_apurado_tra?
                'af_total_cartaodebito?af_total_crediario?af_total_apurado_crd
                .Af_id1 = mArray(0)
                .Af_datahora1 = mArray(1)
                .Af_tipo1 = mArray(2)
                .Af_concluido1 = mArray(3)
                .Af_total_dinheiro1 = mArray(4)
                .Af_total_cartaocredito = mArray(5)
                .Af_id_abertura1 = mArray(6)
                .Af_total_apurado_dn1 = mArray(7)
                .Af_total_apurado_ctc = mArray(8)
                .af_total_pix = mArray(9)
                .af_total_transferencia = mArray(10)
                .af_total_apurado_ctd = mArray(11)
                .af_total_apurado_pix = mArray(12)
                .af_total_apurado_tra = mArray(13)
                .af_total_cartaodebito = mArray(14)
                .af_total_crediario = mArray(15)
                .af_total_apurado_crd = mArray(16)

            End With
            lista.Add(New ClAbrirFecharCaixa(AbrirFecharCX))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaCaixaArquivoTEXTO(caminhoArquivo As String) As List(Of ClCaixa)

        Dim lista As New List(Of ClCaixa)
        Dim Caixa As New ClCaixa

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            Caixa.ZeraValores()
            With Caixa

                'Cx_id1?Cx_tipo1?Cx_datahora1?Cx_motivo1?Cx_af_id1?Cx_valor1?Cx_tipo_valor1
                .Cx_id1 = mArray(0)
                .Cx_tipo1 = mArray(1)
                .Cx_datahora1 = mArray(2)
                .Cx_motivo1 = mArray(3)
                .Cx_af_id1 = mArray(4)
                .Cx_valor1 = mArray(5)
                .Cx_tipo_valor1 = mArray(6)

            End With
            lista.Add(New ClCaixa(Caixa))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaAPagarArquivoTEXTO(caminhoArquivo As String) As List(Of ClAPagarTotal)

        Dim lista As New List(Of ClAPagarTotal)
        Dim APagar As New ClAPagarTotal

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            APagar.ZeraValores()
            With APagar

                'apt_id?apt_empresaid?apt_empresanome?apt_portadorid?apt_portadornome?apt_portadortipo?apt_dataemissao?apt_datavencimento?
                'apt_valor?apt_datapagamento?apt_valorrestante?apt_desconto?apt_acrescimo?apt_observacao?apt_funcionarioid?apt_funcionarionome?
                'apt_valorpago?apt_tela?apt_alteradodt?apt_alteradofunc?apt_estornado?apt_estornadovalor?apt_situacao?apt_tipopagamento?
                'apt_idcaixa?apt_pagodinheiro?apt_pagocartaocred?apt_pagocartaodeb?apt_pagopix?apt_pagotransferencia?apt_idvendaservico?
                'apt_idvendaproduto?apt_tipodocumentoid?apt_tipodocumentodescr
                .apt_id = mArray(0)
                .apt_empresaid = mArray(1)
                .apt_empresanome = mArray(2)
                .apt_portadorid = mArray(3)
                .apt_portadornome = mArray(4)
                .apt_portadortipo = mArray(5)
                .apt_dataemissao = mArray(6)
                .apt_datavencimento = mArray(7)
                .apt_valor = mArray(8)
                .apt_datapagamento = mArray(9)
                .apt_valorrestante = mArray(10)
                .apt_desconto = mArray(11)
                .apt_acrescimo = mArray(12)
                .apt_observacao = mArray(13)
                .apt_funcionarioid = mArray(14)
                .apt_funcionarionome = mArray(15)
                .apt_valorpago = mArray(16)
                .apt_tela = mArray(17)
                .apt_alteradodt = mArray(18)
                .apt_alteradofunc = mArray(19)
                .apt_estornado = mArray(20)
                .apt_estornadovalor = mArray(21)
                .apt_situacao = mArray(22)
                .apt_tipopagamento = mArray(23)
                .apt_idcaixa = mArray(24)
                .apt_pagodinheiro = mArray(25)
                .apt_pagocartaocred = mArray(26)
                .apt_pagocartaodeb = mArray(27)
                .apt_pagopix = mArray(28)
                .apt_pagotransferencia = mArray(29)
                .apt_idvendaservico = mArray(30)
                .apt_idvendaproduto = mArray(31)
                .apt_tipodocumentoid = mArray(32)
                .apt_tipodocumentodescr = mArray(33)

            End With
            lista.Add(New ClAPagarTotal(APagar))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaAReceberArquivoTEXTO(caminhoArquivo As String) As List(Of ClAReceberTotal)

        Dim lista As New List(Of ClAReceberTotal)
        Dim AReceber As New ClAReceberTotal

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            AReceber.ZeraValores()
            With AReceber

                'art_id?art_empresaid?art_empresanome?art_clienteid?art_clientenome?art_dataemissao?art_datavencimento?art_valor?art_datapagamento?
                'art_valorrestante?art_desconto?art_acrescimo?art_observacao?art_funcionarioid?art_funcionarionome?art_valorpago?art_tela?art_alteradodt?
                'art_alteradofunc?art_estornado?art_estornadovalor?art_situacao?art_tipopagamento?art_idcaixa?art_pagodinheiro?art_pagocartaocred?art_pagocartaodeb?
                'art_pagopix?art_pagotransferencia?art_idvendaservico?art_idvendaproduto
                .art_id = mArray(0)
                .art_empresaid = mArray(1)
                .art_empresanome = mArray(2)
                .art_clienteid = mArray(3)
                .art_clientenome = mArray(4)
                .art_dataemissao = mArray(5)
                .art_datavencimento = mArray(6)
                .art_valor = mArray(7)
                .art_datapagamento = mArray(8)
                .art_valorrestante = mArray(9)
                .art_desconto = mArray(10)
                .art_acrescimo = mArray(11)
                .art_observacao = mArray(12)
                .art_funcionarioid = mArray(13)
                .art_funcionarionome = mArray(14)
                .art_valorpago = mArray(15)
                .art_tela = mArray(16)
                .art_alteradodt = mArray(17)
                .art_alteradofunc = mArray(18)
                .art_estornado = mArray(19)
                .art_estornadovalor = mArray(20)
                .art_situacao = mArray(21)
                .art_tipopagamento = mArray(22)
                .art_idcaixa = mArray(23)
                .art_pagodinheiro = mArray(24)
                .art_pagocartaocred = mArray(25)
                .art_pagocartaodeb = mArray(26)
                .art_pagopix = mArray(27)
                .art_pagotransferencia = mArray(28)
                .art_idvendaservico = mArray(29)
                .art_idvendaproduto = mArray(30)

            End With
            lista.Add(New ClAReceberTotal(AReceber))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaGrupoDespMensalArquivoTEXTO(caminhoArquivo As String) As List(Of ClGrupoDespMensal)

        Dim lista As New List(Of ClGrupoDespMensal)
        Dim Grupo As New ClGrupoDespMensal

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            Grupo.zeraValores()
            With Grupo

                'gp_id?gp_descricao
                .gp_id = mArray(0)
                .gp_descricao = mArray(1)

            End With
            lista.Add(New ClGrupoDespMensal(Grupo))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaDespMensalArquivoTEXTO(caminhoArquivo As String) As List(Of ClDespesaMensal)

        Dim lista As New List(Of ClDespesaMensal)
        Dim DespM As New ClDespesaMensal

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            DespM.zeraValores()
            With DespM

                'dm_id?dm_empresaid?dm_empresanome?dm_gpid?dm_gpdescricao?dm_sgpid?dm_sgpdescricao?dm_data_despesa?dm_data_inclusao?
                'dm_valor?dm_observacao?dm_alteracao?dm_fechado
                .dm_id = mArray(0)
                .dm_empresaid = mArray(1)
                .dm_empresanome = mArray(2)
                .dm_gpid = mArray(3)
                .dm_gpdescricao = mArray(4)
                .dm_sgpid = mArray(5)
                .dm_sgpdescricao = mArray(6)
                .dm_data_despesa = mArray(7)
                .dm_data_inclusao = mArray(8)
                .dm_valor = mArray(9)
                .dm_observacao = mArray(10)
                .dm_alteracao = mArray(11)
                .dm_fechado = mArray(12)

            End With
            lista.Add(New ClDespesaMensal(DespM))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaVendaServicoArquivoTEXTO(caminhoArquivo As String) As List(Of ClVendaServico)

        Dim lista As New List(Of ClVendaServico)
        Dim VendaServico As New ClVendaServico

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            VendaServico.ZeraValores()
            With VendaServico

                'vsid?vsempresaid?vsclienteid?vsempresanome?vsempresauf?vsempresacidade?vsclientenome?vsclienteuf?vsclientecidade?vsdatahora?
                'vssubtotal?vsdesconto?vstotalgeral?vspagodinheiro?vspagocredito?vspagodebito?vspagopix?vspagotransferencia?vspagocrediario
                .vsid = mArray(0)
                .vsempresaid = mArray(1)
                .vsclienteid = mArray(2)
                .vsempresanome = mArray(3)
                .vsempresauf = mArray(4)
                .vsempresacidade = mArray(5)
                .vsclientenome = mArray(6)
                .vsclienteuf = mArray(7)
                .vsclientecidade = mArray(8)
                .vsdatahora = mArray(9)
                .vssubtotal = mArray(10)
                .vsdesconto = mArray(11)
                .vstotalgeral = mArray(12)
                .vspagodinheiro = mArray(13)
                .vspagocredito = mArray(14)
                .vspagodebito = mArray(15)
                .vspagopix = mArray(16)
                .vspagotransferencia = mArray(17)
                .vspagocrediario = mArray(18)

            End With
            lista.Add(New ClVendaServico(VendaServico))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaVendaServicoItensArquivoTEXTO(caminhoArquivo As String) As List(Of ClVendaServicoItens)

        Dim lista As New List(Of ClVendaServicoItens)
        Dim VendaServicoITens As New ClVendaServicoItens

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            VendaServicoITens.ZeraValores()
            With VendaServicoITens

                'vsi_id?vsi_data?vs_id?vs_totalcartao?vs_totalcartaoseparado?vsi_servicoid?vsi_serviconome?vsi_servicodespctporcent?vsi_servicodespctvalor?
                'vsi_atendenteid?vsi_atendentenome?vsi_atendentecomissao?vsi_quantidadeservico?vsi_valorservico?vsi_descontoservico?vsi_subtotalservico?
                'vsi_valortotalservico?vsi_despcartaoseparado?vsi_valorcomissao
                .Id = mArray(0)
                .Data = mArray(1)
                .IdVendaServico = mArray(2)
                .TotalCartaoVendaServico = mArray(3)
                .TotalCartaoSeparadoVendaServico = mArray(4)
                .IdServico = mArray(5)
                .NomeServico = mArray(6)
                .DespCartaoServico_Porcent = mArray(7)
                .DespCartaoServico_Valor = mArray(8)
                .IdAtendente = mArray(9)
                .NomeAtendente = mArray(10)
                .ComissaoAtendente = mArray(11)
                .QuantidadeServico = mArray(12)
                .ValorServico = mArray(13)
                .SubTotalServico = mArray(14)
                .ValorTotalServico = mArray(15)
                .DespCartaoSeparado = mArray(16)
                .ValorComissao = mArray(17)

            End With
            lista.Add(New ClVendaServicoItens(VendaServicoITens))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaSaudePessoaArquivoTEXTO(caminhoArquivo As String) As List(Of ClInfoSaudePessoa)

        Dim lista As New List(Of ClInfoSaudePessoa)
        Dim SaudePessoa As New ClInfoSaudePessoa

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            SaudePessoa.ZeraValores()
            With SaudePessoa

                'inp_id?inp_pessoaid?inp_pessoanome?inp_pessoapeso?inp_pessoaaltura?inp_pessoaidade?inp_resultadoIMC?inp_imcid?inp_imcclassificacao?
                'inp_comorbidade1?inp_comorbidade2?inp_comorbidade3?inp_comorbidade4?inp_comorbidade5?inp_comorbidade6?inp_observacao
                .inp_id = mArray(0)
                .inp_pessoaid = mArray(1)
                .inp_pessoanome = mArray(2)
                .inp_pessoapeso = mArray(3)
                .inp_pessoaaltura = mArray(4)
                .inp_pessoaidade = mArray(5)
                .inp_resultadoIMC = mArray(6)
                .inp_imcid = mArray(7)
                .inp_imcclassificacao = mArray(8)
                .inp_comorbidade1 = mArray(9)
                .inp_comorbidade2 = mArray(10)
                .inp_comorbidade3 = mArray(11)
                .inp_comorbidade4 = mArray(12)
                .inp_comorbidade5 = mArray(13)
                .inp_comorbidade6 = mArray(14)
                .inp_observacao = mArray(15)

            End With
            lista.Add(New ClInfoSaudePessoa(SaudePessoa))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaSaudePessoaITENSArquivoTEXTO(caminhoArquivo As String) As List(Of ClInfoSaudePessoaItem)

        Dim lista As New List(Of ClInfoSaudePessoaItem)
        Dim SaudePessoaITEM As New ClInfoSaudePessoaItem

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            SaudePessoaITEM.zeraValores()
            With SaudePessoaITEM

                'inpi_id?inp_id?inpi_servicoid?inpi_serviconome?inpi_produtoid?inpi_produtodescricao
                .inpi_id = mArray(0)
                .inp_id = mArray(1)
                .inpi_servicoid = mArray(2)
                .inpi_serviconome = mArray(3)
                .inpi_produtoid = mArray(4)
                .inpi_produtodescricao = mArray(5)

            End With
            lista.Add(New ClInfoSaudePessoaItem(SaudePessoaITEM))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

    Public Function TrazListaIMCArquivoTEXTO(caminhoArquivo As String) As List(Of ClIMC)

        Dim lista As New List(Of ClIMC)
        Dim IMC As New ClIMC

        Dim sr As StreamReader
        Try
            sr = New StreamReader(caminhoArquivo, System.Text.Encoding.Default)
        Catch ex As Exception
            Return lista
        End Try
        Dim mLinha As String = ""
        Dim mArray() As String

        Do
            'Lê uma linha de cada vez
            mLinha = sr.ReadLine
            If IsNothing(mLinha) Then Exit Do
            mArray = Split(mLinha, "?")

            IMC.zeraValores()
            With IMC

                'imc_id?imc_minimo?imc_maximo?imc_classificacao?imc_problemas
                .imc_id = mArray(0)
                .imc_minimo = mArray(1)
                .imc_maximo = mArray(2)
                .imc_classificacao = mArray(3)
                .imc_problemas = mArray(4)

            End With
            lista.Add(New ClIMC(IMC))

        Loop Until mLinha Is Nothing OrElse mLinha = ""
        sr.Close()


        Return lista
    End Function

End Class
