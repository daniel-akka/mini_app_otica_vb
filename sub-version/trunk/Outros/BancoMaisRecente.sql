--
-- PostgreSQL database dump
--

-- Dumped from database version 9.2.4
-- Dumped by pg_dump version 9.2.4
-- Started on 2021-08-26 12:11:52

SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 262 (class 3079 OID 11727)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2687 (class 0 OID 0)
-- Dependencies: 262
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

--
-- TOC entry 275 (class 1255 OID 16394)
-- Name: altera_estoque_produto(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION altera_estoque_produto() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
-- Aqui temos um bloco IF que confirmará o tipo de operação.
IF (new.estipo = 'E') THEN
	UPDATE produto SET pestoque = pestoque + new.esquantidade WHERE pid = new.esprodutoid;
RETURN NEW;
-- Aqui temos um bloco IF que confirmará o tipo de operação UPDATE.
ELSIF (new.estipo = 'S') THEN
	UPDATE produto SET pestoque = pestoque - new.esquantidade WHERE pid = new.esprodutoid;	
RETURN NEW;
END IF;
RETURN NULL;
END;
$$;


ALTER FUNCTION public.altera_estoque_produto() OWNER TO postgres;

--
-- TOC entry 276 (class 1255 OID 16395)
-- Name: altera_estoque_produto_del(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION altera_estoque_produto_del() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN

IF (old.estipo = 'E') THEN
	UPDATE produto SET pestoque = pestoque - old.esquantidade WHERE pid = old.esprodutoid;
RETURN NEW;
-- Aqui temos um bloco IF que confirmará o tipo de operação UPDATE.
ELSIF (old.estipo = 'S') THEN
	UPDATE produto SET pestoque = pestoque + old.esquantidade WHERE pid = old.esprodutoid;	
RETURN NEW;
END IF;
RETURN NULL;
END;
$$;


ALTER FUNCTION public.altera_estoque_produto_del() OWNER TO postgres;

--
-- TOC entry 277 (class 1255 OID 16396)
-- Name: altfinanceiro_agendamento(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION altfinanceiro_agendamento() RETURNS trigger
    LANGUAGE plpgsql
    AS $$begin 

		IF new.f_agendamento > 0 THEN
			UPDATE agendamento SET a_financeiro = true WHERE a_id = new.f_agendamento;
		END IF;
		return new;
	end;$$;


ALTER FUNCTION public.altfinanceiro_agendamento() OWNER TO postgres;

--
-- TOC entry 278 (class 1255 OID 16397)
-- Name: atualiza_data_finalizacao_locacao(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION atualiza_data_finalizacao_locacao() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
   
       UPDATE movimentacao SET m_datafinalizacao = CURRENT_TIMESTAMP WHERE (m_id = NEW.m_id) 
       AND (NEW.m_finalizado <> OLD.m_finalizado) AND (NEW.m_finalizado = true);
    
   RETURN NEW;
END;
$$;


ALTER FUNCTION public.atualiza_data_finalizacao_locacao() OWNER TO postgres;

--
-- TOC entry 279 (class 1255 OID 16398)
-- Name: insert_locacao_cancelada(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION insert_locacao_cancelada() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
INSERT INTO locacoes_canceladas(
            lc_atendente_id, lc_atendente_nome, lc_produto_id, lc_produto_nome, 
            lc_tempo_programado, lc_tempo_inicial, lc_tempo_final, lc_valor_tempo, 
            lc_valor_tempo_excedido, lc_valor_tempo_total, lc_finalizado, 
            lc_data, lc_tempo_acumulado, lc_tempo_excedido, lc_desconto, 
            lc_valor_total_desconto, lc_justificativa)
    VALUES (OLD.m_atendente_id, OLD.m_atendente_nome, OLD.m_produto_id, OLD.m_produto_nome, 
       OLD.m_tempo_programado, OLD.m_tempo_inicial, OLD.m_tempo_final, OLD.m_valor_tempo, 
       OLD.m_valor_tempo_excedido, OLD.m_valor_tempo_total, OLD.m_finalizado, OLD.m_data, 
       OLD.m_tempo_acumulado, OLD.m_tempo_excedido, OLD.m_desconto, OLD.m_valor_total_desconto, 
       OLD.m_justificativa);
RETURN OLD;
END;
$$;


ALTER FUNCTION public.insert_locacao_cancelada() OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 168 (class 1259 OID 16399)
-- Name: abrir_fechar; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE abrir_fechar (
    af_id bigint NOT NULL,
    af_datahora timestamp without time zone DEFAULT now() NOT NULL,
    af_tipo character varying(1) DEFAULT 'A'::character varying NOT NULL,
    af_concluido boolean DEFAULT false NOT NULL,
    af_total_dinheiro real DEFAULT 0.00 NOT NULL,
    af_total_cartaocredito real DEFAULT 0.00 NOT NULL,
    af_id_abertura bigint DEFAULT 0 NOT NULL,
    af_total_apurado_dn real DEFAULT 0.00 NOT NULL,
    af_total_apurado_ctc real DEFAULT 0.00 NOT NULL,
    af_total_cartaodebito real DEFAULT 0.00 NOT NULL,
    af_total_pix real DEFAULT 0.00 NOT NULL,
    af_total_transferencia real DEFAULT 0.00 NOT NULL,
    af_total_apurado_ctd real DEFAULT 0.00 NOT NULL,
    af_total_apurado_pix real DEFAULT 0.00 NOT NULL,
    af_total_apurado_tra real DEFAULT 0.00 NOT NULL,
    af_total_crediario real DEFAULT 0.00 NOT NULL,
    af_total_apurado_crd real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.abrir_fechar OWNER TO postgres;

--
-- TOC entry 2688 (class 0 OID 0)
-- Dependencies: 168
-- Name: COLUMN abrir_fechar.af_tipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN abrir_fechar.af_tipo IS 'A=Abertura
F=Fechamento';


--
-- TOC entry 169 (class 1259 OID 16418)
-- Name: abrir_fechar_af_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE abrir_fechar_af_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.abrir_fechar_af_id_seq OWNER TO postgres;

--
-- TOC entry 2689 (class 0 OID 0)
-- Dependencies: 169
-- Name: abrir_fechar_af_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE abrir_fechar_af_id_seq OWNED BY abrir_fechar.af_id;


--
-- TOC entry 170 (class 1259 OID 16420)
-- Name: agendamento; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE agendamento (
    a_id bigint NOT NULL,
    a_dtemis date DEFAULT ('now'::text)::date,
    a_dtagend date DEFAULT ('now'::text)::date,
    a_status boolean DEFAULT false,
    a_iddoutor bigint DEFAULT 0,
    a_doutor character varying(100),
    a_valor real DEFAULT 0.00,
    a_cancelado boolean DEFAULT false,
    a_usuario character varying(40),
    a_usuarioalt character varying(40),
    a_financeiro boolean DEFAULT false NOT NULL,
    a_turno character varying(1),
    a_info character varying(150),
    a_pessoaid bigint DEFAULT 0,
    a_pessoanome character varying,
    a_empresanome character varying,
    a_empresaid integer,
    a_hora character varying,
    a_alterado boolean DEFAULT false NOT NULL
);


ALTER TABLE public.agendamento OWNER TO postgres;

--
-- TOC entry 171 (class 1259 OID 16435)
-- Name: agendamento_a_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE agendamento_a_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.agendamento_a_id_seq OWNER TO postgres;

--
-- TOC entry 2690 (class 0 OID 0)
-- Dependencies: 171
-- Name: agendamento_a_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE agendamento_a_id_seq OWNED BY agendamento.a_id;


--
-- TOC entry 172 (class 1259 OID 16437)
-- Name: agendamento_itens; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE agendamento_itens (
    agi_id bigint NOT NULL,
    ag_id bigint NOT NULL,
    agi_codserv bigint NOT NULL,
    agi_descrserv character varying(100),
    agi_dtemis date DEFAULT ('now'::text)::date,
    agi_valor real DEFAULT 0.00,
    agi_qtde real DEFAULT 1 NOT NULL,
    agi_total real DEFAULT 0 NOT NULL,
    agi_atendenteid bigint DEFAULT 0,
    agi_atendentenome character varying
);


ALTER TABLE public.agendamento_itens OWNER TO postgres;

--
-- TOC entry 173 (class 1259 OID 16448)
-- Name: agendamento_itens_agi_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE agendamento_itens_agi_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.agendamento_itens_agi_id_seq OWNER TO postgres;

--
-- TOC entry 2691 (class 0 OID 0)
-- Dependencies: 173
-- Name: agendamento_itens_agi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE agendamento_itens_agi_id_seq OWNED BY agendamento_itens.agi_id;


--
-- TOC entry 174 (class 1259 OID 16450)
-- Name: apagar_parcial; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE apagar_parcial (
    app_id bigint NOT NULL,
    app_aptid bigint NOT NULL,
    app_datapagamento timestamp without time zone DEFAULT now() NOT NULL,
    app_valor real DEFAULT 0 NOT NULL,
    app_tipopagamento character varying(3),
    app_descrpagamento character varying,
    app_desconto real DEFAULT 0 NOT NULL,
    app_acrescimo real,
    app_funcionarioid integer DEFAULT 0 NOT NULL,
    app_funcionarionome character varying,
    app_idcaixa bigint DEFAULT 0 NOT NULL,
    app_pagodinheiro real DEFAULT 0.00 NOT NULL,
    app_pagocartaocred real DEFAULT 0.00 NOT NULL,
    app_pagocartaodeb real DEFAULT 0.00 NOT NULL,
    app_pagopix real DEFAULT 0.0 NOT NULL,
    app_pagotransferencia real DEFAULT 0.00 NOT NULL,
    app_valortotal real DEFAULT 0.00 NOT NULL,
    CONSTRAINT app_valortotalchk CHECK ((app_valortotal = ((((((app_acrescimo + app_pagodinheiro) + app_pagocartaocred) + app_pagocartaodeb) + app_pagopix) + app_pagotransferencia) - app_desconto)))
);


ALTER TABLE public.apagar_parcial OWNER TO postgres;

--
-- TOC entry 2692 (class 0 OID 0)
-- Dependencies: 174
-- Name: COLUMN apagar_parcial.app_tipopagamento; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN apagar_parcial.app_tipopagamento IS 'DN - Dinheiro
CTC - Cartao Credito
CTD - Cartao Debito
PIX - Pix
TRA - Transferencia';


--
-- TOC entry 175 (class 1259 OID 16468)
-- Name: apagar_parcial_app_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE apagar_parcial_app_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.apagar_parcial_app_id_seq OWNER TO postgres;

--
-- TOC entry 2693 (class 0 OID 0)
-- Dependencies: 175
-- Name: apagar_parcial_app_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE apagar_parcial_app_id_seq OWNED BY apagar_parcial.app_id;


--
-- TOC entry 176 (class 1259 OID 16470)
-- Name: apagar_total; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE apagar_total (
    apt_id bigint NOT NULL,
    apt_empresaid integer DEFAULT 0 NOT NULL,
    apt_empresanome character varying,
    apt_portadorid integer NOT NULL,
    apt_portadortipo character varying DEFAULT 'F'::character varying NOT NULL,
    apt_portadornome character varying NOT NULL,
    apt_dataemissao timestamp without time zone DEFAULT now() NOT NULL,
    apt_datavencimento date NOT NULL,
    apt_valor real NOT NULL,
    apt_datapagamento character varying,
    apt_valorrestante real DEFAULT 0.00 NOT NULL,
    apt_desconto real DEFAULT 0 NOT NULL,
    apt_acrescimo real DEFAULT 0 NOT NULL,
    apt_observacao character varying,
    apt_funcionarioid integer DEFAULT 0 NOT NULL,
    apt_funcionarionome character varying,
    apt_valorpago real DEFAULT 0 NOT NULL,
    apt_tela character varying,
    apt_alteradodt character varying,
    apt_alteradofunc character varying,
    apt_estornado boolean DEFAULT false NOT NULL,
    apt_estornadovalor real DEFAULT 0 NOT NULL,
    apt_situacao character varying(1),
    apt_tipopagamento character varying(3),
    apt_idcaixa bigint DEFAULT 0 NOT NULL,
    apt_pagodinheiro real DEFAULT 0 NOT NULL,
    apt_pagocartaocred real DEFAULT 0 NOT NULL,
    apt_pagocartaodeb real DEFAULT 0 NOT NULL,
    apt_pagopix real DEFAULT 0 NOT NULL,
    apt_pagotransferencia real DEFAULT 0 NOT NULL,
    apt_idvendaservico bigint DEFAULT 0 NOT NULL,
    apt_idvendaproduto bigint DEFAULT 0 NOT NULL,
    apt_tipodocumentoid integer DEFAULT 0 NOT NULL,
    apt_tipodocumentodescr character varying
);


ALTER TABLE public.apagar_total OWNER TO postgres;

--
-- TOC entry 2694 (class 0 OID 0)
-- Dependencies: 176
-- Name: COLUMN apagar_total.apt_alteradodt; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN apagar_total.apt_alteradodt IS 'Informar em DateTime';


--
-- TOC entry 2695 (class 0 OID 0)
-- Dependencies: 176
-- Name: COLUMN apagar_total.apt_situacao; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN apagar_total.apt_situacao IS 'N - Normal
L - Liquidada
E - Estornada
V - Vencida';


--
-- TOC entry 177 (class 1259 OID 16495)
-- Name: apagar_total_apt_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE apagar_total_apt_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.apagar_total_apt_id_seq OWNER TO postgres;

--
-- TOC entry 2696 (class 0 OID 0)
-- Dependencies: 177
-- Name: apagar_total_apt_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE apagar_total_apt_id_seq OWNED BY apagar_total.apt_id;


--
-- TOC entry 178 (class 1259 OID 16497)
-- Name: areceber_parcial; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE areceber_parcial (
    arp_id bigint NOT NULL,
    arp_artid bigint NOT NULL,
    arp_datapagamento timestamp without time zone DEFAULT now() NOT NULL,
    arp_valor real DEFAULT 0 NOT NULL,
    arp_tipopagamento character varying(3),
    arp_descrpagamento character varying,
    arp_desconto real DEFAULT 0 NOT NULL,
    arp_acrescimo real,
    arp_funcionarioid integer DEFAULT 0 NOT NULL,
    arp_funcionarionome character varying,
    arp_idcaixa bigint DEFAULT 0 NOT NULL,
    arp_pagodinheiro real DEFAULT 0.00 NOT NULL,
    arp_pagocartaocred real DEFAULT 0.00 NOT NULL,
    arp_pagocartaodeb real DEFAULT 0.00 NOT NULL,
    arp_pagopix real DEFAULT 0.0 NOT NULL,
    arp_pagotransferencia real DEFAULT 0.00 NOT NULL,
    arp_valortotal real DEFAULT 0.00 NOT NULL,
    CONSTRAINT arp_valortotalchk CHECK ((arp_valortotal = ((((((arp_acrescimo + arp_pagodinheiro) + arp_pagocartaocred) + arp_pagocartaodeb) + arp_pagopix) + arp_pagotransferencia) - arp_desconto)))
);


ALTER TABLE public.areceber_parcial OWNER TO postgres;

--
-- TOC entry 2697 (class 0 OID 0)
-- Dependencies: 178
-- Name: COLUMN areceber_parcial.arp_tipopagamento; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN areceber_parcial.arp_tipopagamento IS 'DN - Dinheiro
CTC - Cartao Credito
CTD - Cartao Debito
PIX - Pix
TRA - Transferencia';


--
-- TOC entry 179 (class 1259 OID 16515)
-- Name: areceber_parcial_arp_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE areceber_parcial_arp_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.areceber_parcial_arp_id_seq OWNER TO postgres;

--
-- TOC entry 2698 (class 0 OID 0)
-- Dependencies: 179
-- Name: areceber_parcial_arp_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE areceber_parcial_arp_id_seq OWNED BY areceber_parcial.arp_id;


--
-- TOC entry 180 (class 1259 OID 16517)
-- Name: areceber_total; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE areceber_total (
    art_id bigint NOT NULL,
    art_empresaid integer DEFAULT 0 NOT NULL,
    art_empresanome character varying,
    art_clienteid integer NOT NULL,
    art_clientenome character varying NOT NULL,
    art_dataemissao timestamp without time zone DEFAULT now() NOT NULL,
    art_datavencimento date NOT NULL,
    art_valor real NOT NULL,
    art_datapagamento character varying,
    art_valorrestante real DEFAULT 0.00 NOT NULL,
    art_desconto real DEFAULT 0 NOT NULL,
    art_acrescimo real DEFAULT 0 NOT NULL,
    art_observacao character varying,
    art_funcionarioid integer DEFAULT 0 NOT NULL,
    art_funcionarionome character varying,
    art_valorpago real DEFAULT 0 NOT NULL,
    art_tela character varying,
    art_alteradodt character varying,
    art_alteradofunc character varying,
    art_estornado boolean DEFAULT false NOT NULL,
    art_estornadovalor real DEFAULT 0 NOT NULL,
    art_situacao character varying(1),
    art_tipopagamento character varying(3),
    art_idcaixa bigint DEFAULT 0 NOT NULL,
    art_pagodinheiro real DEFAULT 0 NOT NULL,
    art_pagocartaocred real DEFAULT 0 NOT NULL,
    art_pagocartaodeb real DEFAULT 0 NOT NULL,
    art_pagopix real DEFAULT 0 NOT NULL,
    art_pagotransferencia real DEFAULT 0 NOT NULL,
    art_idvendaservico bigint DEFAULT 0 NOT NULL,
    art_idvendaproduto bigint DEFAULT 0 NOT NULL
);


ALTER TABLE public.areceber_total OWNER TO postgres;

--
-- TOC entry 2699 (class 0 OID 0)
-- Dependencies: 180
-- Name: COLUMN areceber_total.art_alteradodt; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN areceber_total.art_alteradodt IS 'Informar em DateTime';


--
-- TOC entry 2700 (class 0 OID 0)
-- Dependencies: 180
-- Name: COLUMN areceber_total.art_situacao; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN areceber_total.art_situacao IS 'N - Normal
L - Liquidada
E - Estornada
V - Vencida';


--
-- TOC entry 181 (class 1259 OID 16540)
-- Name: areceber_total_art_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE areceber_total_art_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.areceber_total_art_id_seq OWNER TO postgres;

--
-- TOC entry 2701 (class 0 OID 0)
-- Dependencies: 181
-- Name: areceber_total_art_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE areceber_total_art_id_seq OWNED BY areceber_total.art_id;


--
-- TOC entry 182 (class 1259 OID 16542)
-- Name: atendente; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE atendente (
    aid bigint NOT NULL,
    anome character varying DEFAULT 'teste'::character varying NOT NULL,
    acomissao real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.atendente OWNER TO postgres;

--
-- TOC entry 183 (class 1259 OID 16550)
-- Name: atendente_aid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE atendente_aid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.atendente_aid_seq OWNER TO postgres;

--
-- TOC entry 2702 (class 0 OID 0)
-- Dependencies: 183
-- Name: atendente_aid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE atendente_aid_seq OWNED BY atendente.aid;


--
-- TOC entry 184 (class 1259 OID 16552)
-- Name: bairro; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE bairro (
    bid bigint NOT NULL,
    bnome character varying NOT NULL
);


ALTER TABLE public.bairro OWNER TO postgres;

--
-- TOC entry 185 (class 1259 OID 16558)
-- Name: bairro_bid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE bairro_bid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.bairro_bid_seq OWNER TO postgres;

--
-- TOC entry 2703 (class 0 OID 0)
-- Dependencies: 185
-- Name: bairro_bid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE bairro_bid_seq OWNED BY bairro.bid;


--
-- TOC entry 186 (class 1259 OID 16560)
-- Name: cadestado; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE cadestado (
    id bigint NOT NULL,
    codestado smallint NOT NULL,
    sigla character varying(2) NOT NULL,
    nome character varying(30) NOT NULL,
    codpais smallint DEFAULT 55 NOT NULL
);


ALTER TABLE public.cadestado OWNER TO postgres;

--
-- TOC entry 2704 (class 0 OID 0)
-- Dependencies: 186
-- Name: COLUMN cadestado.codpais; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN cadestado.codpais IS '55 = codigo do brasil';


--
-- TOC entry 187 (class 1259 OID 16564)
-- Name: cadestado_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE cadestado_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.cadestado_id_seq OWNER TO postgres;

--
-- TOC entry 2705 (class 0 OID 0)
-- Dependencies: 187
-- Name: cadestado_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE cadestado_id_seq OWNED BY cadestado.id;


--
-- TOC entry 188 (class 1259 OID 16566)
-- Name: cadmun; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE cadmun (
    id bigint NOT NULL,
    id_estado smallint NOT NULL,
    sigla_estado character varying(2) NOT NULL,
    cod_estado smallint NOT NULL,
    codigo integer NOT NULL,
    nome character varying(60) NOT NULL
);


ALTER TABLE public.cadmun OWNER TO postgres;

--
-- TOC entry 189 (class 1259 OID 16569)
-- Name: cadmun_id_estado_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE cadmun_id_estado_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.cadmun_id_estado_seq OWNER TO postgres;

--
-- TOC entry 2706 (class 0 OID 0)
-- Dependencies: 189
-- Name: cadmun_id_estado_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE cadmun_id_estado_seq OWNED BY cadmun.id_estado;


--
-- TOC entry 190 (class 1259 OID 16571)
-- Name: cadmun_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE cadmun_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.cadmun_id_seq OWNER TO postgres;

--
-- TOC entry 2707 (class 0 OID 0)
-- Dependencies: 190
-- Name: cadmun_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE cadmun_id_seq OWNED BY cadmun.id;


--
-- TOC entry 191 (class 1259 OID 16573)
-- Name: caixa; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE caixa (
    cx_id bigint NOT NULL,
    cx_tipo character varying(1) NOT NULL,
    cx_datahora timestamp without time zone DEFAULT now() NOT NULL,
    cx_motivo text,
    cx_af_id bigint,
    cx_valor real DEFAULT 0.00 NOT NULL,
    cx_tipo_valor character varying(2) DEFAULT 'DN'::character varying NOT NULL
);


ALTER TABLE public.caixa OWNER TO postgres;

--
-- TOC entry 2708 (class 0 OID 0)
-- Dependencies: 191
-- Name: COLUMN caixa.cx_tipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN caixa.cx_tipo IS 'S=Saida
E=Entrada
T=Troco
';


--
-- TOC entry 2709 (class 0 OID 0)
-- Dependencies: 191
-- Name: COLUMN caixa.cx_tipo_valor; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN caixa.cx_tipo_valor IS 'CT=CARTAO
DN=DINHEIRO';


--
-- TOC entry 192 (class 1259 OID 16582)
-- Name: caixa_cx_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE caixa_cx_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.caixa_cx_id_seq OWNER TO postgres;

--
-- TOC entry 2710 (class 0 OID 0)
-- Dependencies: 192
-- Name: caixa_cx_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE caixa_cx_id_seq OWNED BY caixa.cx_id;


--
-- TOC entry 193 (class 1259 OID 16584)
-- Name: cliente; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE cliente (
    cid bigint NOT NULL,
    cnome character varying NOT NULL,
    cestado character varying(2) DEFAULT 'PI'::character varying NOT NULL,
    ccidade character varying,
    cendereco character varying,
    creferencia character varying,
    cinativo boolean DEFAULT false NOT NULL,
    cdatanascimento date,
    ctelefone character varying,
    cbairro character varying,
    cdataservico date,
    cdiames character varying,
    ccpf character varying,
    ccep character varying,
    cemail character varying,
    observacao character varying,
    tipo character varying DEFAULT 'F'::character varying NOT NULL,
    ufid integer DEFAULT 0 NOT NULL,
    cidadeid bigint DEFAULT 0 NOT NULL,
    cidadecodigo character varying
);


ALTER TABLE public.cliente OWNER TO postgres;

--
-- TOC entry 194 (class 1259 OID 16595)
-- Name: cliente_cid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE cliente_cid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.cliente_cid_seq OWNER TO postgres;

--
-- TOC entry 2711 (class 0 OID 0)
-- Dependencies: 194
-- Name: cliente_cid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE cliente_cid_seq OWNED BY cliente.cid;


--
-- TOC entry 195 (class 1259 OID 16597)
-- Name: comissao; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE comissao (
    c_id bigint NOT NULL,
    c_atendenteid integer DEFAULT 0 NOT NULL,
    c_atendentenome character varying NOT NULL,
    c_datapagamento timestamp without time zone DEFAULT now() NOT NULL,
    c_valorpago real DEFAULT 0.00 NOT NULL,
    c_observacao character varying,
    c_empresaid integer DEFAULT 0 NOT NULL,
    c_empresanome character varying NOT NULL,
    c_deletada boolean DEFAULT false NOT NULL
);


ALTER TABLE public.comissao OWNER TO postgres;

--
-- TOC entry 196 (class 1259 OID 16608)
-- Name: comissao_c_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE comissao_c_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.comissao_c_id_seq OWNER TO postgres;

--
-- TOC entry 2712 (class 0 OID 0)
-- Dependencies: 196
-- Name: comissao_c_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE comissao_c_id_seq OWNED BY comissao.c_id;


--
-- TOC entry 197 (class 1259 OID 16610)
-- Name: confbd; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE confbd (
    bd_server character varying(80) NOT NULL,
    bd_port character varying(4) NOT NULL,
    bd_userid character varying(20) NOT NULL,
    bd_password character varying(20) NOT NULL,
    bd_database character varying(20) NOT NULL
);


ALTER TABLE public.confbd OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 16613)
-- Name: configuracoes; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE configuracoes (
    idconfg bigint NOT NULL,
    limite_desconto real DEFAULT 1 NOT NULL,
    senha_padrao character varying DEFAULT 1 NOT NULL,
    diasvenccrediario integer DEFAULT 0 NOT NULL,
    caminho_logo character varying,
    caminho_pasta_sgbd character varying,
    caminho_pasta_sistema character varying,
    caminho_pasta_sincronizar character varying
);


ALTER TABLE public.configuracoes OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 16622)
-- Name: configuracoes_idconfg_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE configuracoes_idconfg_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.configuracoes_idconfg_seq OWNER TO postgres;

--
-- TOC entry 2713 (class 0 OID 0)
-- Dependencies: 199
-- Name: configuracoes_idconfg_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE configuracoes_idconfg_seq OWNED BY configuracoes.idconfg;


--
-- TOC entry 200 (class 1259 OID 16624)
-- Name: desp_produto; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE desp_produto (
    dpid bigint NOT NULL,
    dpdescricao character varying DEFAULT 'despesa'::character varying NOT NULL,
    dpporcentagem real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.desp_produto OWNER TO postgres;

--
-- TOC entry 201 (class 1259 OID 16632)
-- Name: desp_produto_dpid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE desp_produto_dpid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.desp_produto_dpid_seq OWNER TO postgres;

--
-- TOC entry 2714 (class 0 OID 0)
-- Dependencies: 201
-- Name: desp_produto_dpid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE desp_produto_dpid_seq OWNED BY desp_produto.dpid;


--
-- TOC entry 202 (class 1259 OID 16634)
-- Name: despesa_mensal; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE despesa_mensal (
    dm_id bigint NOT NULL,
    dm_empresaid integer NOT NULL,
    dm_empresanome character varying NOT NULL,
    dm_gpid bigint NOT NULL,
    dm_gpdescricao character varying NOT NULL,
    dm_sgpid bigint NOT NULL,
    dm_sgpdescricao character varying NOT NULL,
    dm_data_despesa timestamp without time zone NOT NULL,
    dm_data_inclusao timestamp without time zone DEFAULT now() NOT NULL,
    dm_valor real DEFAULT 0.00 NOT NULL,
    dm_observacao character varying,
    dm_alteracao boolean DEFAULT false NOT NULL,
    dm_fechado boolean DEFAULT false NOT NULL
);


ALTER TABLE public.despesa_mensal OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 16644)
-- Name: despesa_mensal_dm_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE despesa_mensal_dm_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.despesa_mensal_dm_id_seq OWNER TO postgres;

--
-- TOC entry 2715 (class 0 OID 0)
-- Dependencies: 203
-- Name: despesa_mensal_dm_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE despesa_mensal_dm_id_seq OWNED BY despesa_mensal.dm_id;


--
-- TOC entry 204 (class 1259 OID 16646)
-- Name: empresa; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE empresa (
    empid bigint NOT NULL,
    emprazaosocial character varying,
    empfantasia character varying NOT NULL,
    empendereco character varying,
    empbairro character varying,
    empfone character varying,
    empestado character varying(2) DEFAULT 'PI'::character varying NOT NULL,
    empcidade character varying,
    empcnpj character varying,
    empcpf character varying
);


ALTER TABLE public.empresa OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 16653)
-- Name: empresa_empid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE empresa_empid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.empresa_empid_seq OWNER TO postgres;

--
-- TOC entry 2716 (class 0 OID 0)
-- Dependencies: 205
-- Name: empresa_empid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE empresa_empid_seq OWNED BY empresa.empid;


--
-- TOC entry 206 (class 1259 OID 16655)
-- Name: entrada_saida; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE entrada_saida (
    esid bigint NOT NULL,
    estipo character varying(1) DEFAULT 'E'::character varying NOT NULL,
    esmotivo character varying,
    esusuarioid integer DEFAULT 0 NOT NULL,
    esusuarionome character varying,
    esfornecedorid integer DEFAULT 0 NOT NULL,
    esfornecedornome character varying,
    esprodutoid integer DEFAULT 0 NOT NULL,
    esprodutonome character varying,
    esquantidade real DEFAULT 0.00 NOT NULL,
    esdata date DEFAULT ('now'::text)::date NOT NULL,
    esdatamovimentacao timestamp without time zone DEFAULT now() NOT NULL,
    esobservacao character varying
);


ALTER TABLE public.entrada_saida OWNER TO postgres;

--
-- TOC entry 2717 (class 0 OID 0)
-- Dependencies: 206
-- Name: COLUMN entrada_saida.estipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN entrada_saida.estipo IS 'E-Entrada
S-Saida';


--
-- TOC entry 207 (class 1259 OID 16668)
-- Name: entrada_saida_esid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE entrada_saida_esid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.entrada_saida_esid_seq OWNER TO postgres;

--
-- TOC entry 2718 (class 0 OID 0)
-- Dependencies: 207
-- Name: entrada_saida_esid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE entrada_saida_esid_seq OWNED BY entrada_saida.esid;


--
-- TOC entry 208 (class 1259 OID 16670)
-- Name: fornecedor; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE fornecedor (
    fid bigint NOT NULL,
    fnome character varying DEFAULT '***'::character varying NOT NULL,
    fendereco character varying DEFAULT '***'::character varying NOT NULL,
    fbairro character varying,
    fcidade character varying,
    festado character varying,
    fidestado integer DEFAULT 0 NOT NULL,
    fidcidade integer DEFAULT 0 NOT NULL,
    fcnpj character varying,
    fcpf character varying,
    ftelefone character varying
);


ALTER TABLE public.fornecedor OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 16680)
-- Name: fornecedor_fid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE fornecedor_fid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.fornecedor_fid_seq OWNER TO postgres;

--
-- TOC entry 2719 (class 0 OID 0)
-- Dependencies: 209
-- Name: fornecedor_fid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE fornecedor_fid_seq OWNED BY fornecedor.fid;


--
-- TOC entry 210 (class 1259 OID 16682)
-- Name: grupo_desp_m; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE grupo_desp_m (
    gp_id bigint NOT NULL,
    gp_descricao character varying NOT NULL
);


ALTER TABLE public.grupo_desp_m OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16688)
-- Name: grupo_desp_m_gp_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE grupo_desp_m_gp_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.grupo_desp_m_gp_id_seq OWNER TO postgres;

--
-- TOC entry 2720 (class 0 OID 0)
-- Dependencies: 211
-- Name: grupo_desp_m_gp_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE grupo_desp_m_gp_id_seq OWNED BY grupo_desp_m.gp_id;


--
-- TOC entry 212 (class 1259 OID 16690)
-- Name: imc; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE imc (
    imc_id bigint NOT NULL,
    imc_minimo real NOT NULL,
    imc_maximo real DEFAULT 0 NOT NULL,
    imc_classificacao character varying NOT NULL,
    imc_problemas character varying
);


ALTER TABLE public.imc OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 16697)
-- Name: imc_imc_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE imc_imc_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.imc_imc_id_seq OWNER TO postgres;

--
-- TOC entry 2721 (class 0 OID 0)
-- Dependencies: 213
-- Name: imc_imc_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE imc_imc_id_seq OWNED BY imc.imc_id;


--
-- TOC entry 214 (class 1259 OID 16699)
-- Name: infonutri_pessoa; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE infonutri_pessoa (
    inp_id bigint NOT NULL,
    inp_pessoaid bigint DEFAULT 0 NOT NULL,
    inp_pessoanome character varying,
    inp_pessoapeso real DEFAULT 0 NOT NULL,
    inp_pessoaaltura real DEFAULT 0 NOT NULL,
    inp_pessoaidade smallint DEFAULT 0 NOT NULL,
    inp_imcid smallint DEFAULT 0 NOT NULL,
    inp_imcclassificacao character varying,
    inp_problema1 character varying,
    inp_problema2 character varying,
    inp_problema3 character varying,
    inp_problema4 character varying,
    inp_problema5 character varying,
    inp_problema6 character varying,
    inp_resultadoimc real DEFAULT 0.00 NOT NULL,
    inp_observacao character varying
);


ALTER TABLE public.infonutri_pessoa OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16711)
-- Name: infonutri_pessoa_inp_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE infonutri_pessoa_inp_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.infonutri_pessoa_inp_id_seq OWNER TO postgres;

--
-- TOC entry 2722 (class 0 OID 0)
-- Dependencies: 215
-- Name: infonutri_pessoa_inp_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE infonutri_pessoa_inp_id_seq OWNED BY infonutri_pessoa.inp_id;


--
-- TOC entry 216 (class 1259 OID 16713)
-- Name: infonutri_pessoa_itens; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE infonutri_pessoa_itens (
    inpi_id bigint NOT NULL,
    inp_id bigint DEFAULT 0 NOT NULL,
    inpi_servicoid bigint DEFAULT 0 NOT NULL,
    inpi_serviconome character varying,
    inpi_produtoid bigint DEFAULT 0 NOT NULL,
    inpi_produtodescricao character varying
);


ALTER TABLE public.infonutri_pessoa_itens OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16722)
-- Name: infonutri_pessoa_itens_inpi_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE infonutri_pessoa_itens_inpi_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.infonutri_pessoa_itens_inpi_id_seq OWNER TO postgres;

--
-- TOC entry 2723 (class 0 OID 0)
-- Dependencies: 217
-- Name: infonutri_pessoa_itens_inpi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE infonutri_pessoa_itens_inpi_id_seq OWNED BY infonutri_pessoa_itens.inpi_id;


--
-- TOC entry 218 (class 1259 OID 16724)
-- Name: movimentacao; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE movimentacao (
    m_id bigint NOT NULL,
    m_atendente_id smallint DEFAULT 0 NOT NULL,
    m_atendente_nome character varying,
    m_produto_id smallint DEFAULT 0 NOT NULL,
    m_produto_nome character varying,
    m_tempo_programado real DEFAULT 1 NOT NULL,
    m_tempo_inicial time without time zone NOT NULL,
    m_tempo_final time without time zone NOT NULL,
    m_valor_tempo real DEFAULT 1 NOT NULL,
    m_valor_tempo_excedido real DEFAULT 0 NOT NULL,
    m_valor_tempo_total real DEFAULT 0 NOT NULL,
    m_finalizado boolean DEFAULT false NOT NULL,
    m_data date DEFAULT ('now'::text)::date NOT NULL,
    m_tempo_acumulado character varying(5) DEFAULT '00:00'::character varying NOT NULL,
    m_tempo_excedido character varying(8) DEFAULT '00:00:00'::character varying NOT NULL,
    m_desconto real DEFAULT 0 NOT NULL,
    m_valor_total_desconto real DEFAULT 0.00 NOT NULL,
    m_justificativa character varying(200),
    m_iniciado boolean DEFAULT false NOT NULL,
    m_tp_pagamento1 character varying(2) DEFAULT 'DN'::character varying NOT NULL,
    m_tp_pagamento2 character varying(2) DEFAULT 'CT'::character varying NOT NULL,
    m_vlr_tp_pagamento1 real DEFAULT 0.00 NOT NULL,
    m_vlr_tp_pagamento2 real DEFAULT 0.00 NOT NULL,
    m_datafinalizacao timestamp without time zone
);


ALTER TABLE public.movimentacao OWNER TO postgres;

--
-- TOC entry 2724 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN movimentacao.m_tp_pagamento1; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN movimentacao.m_tp_pagamento1 IS 'DN-Dinheiro
CT-Cartao';


--
-- TOC entry 2725 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN movimentacao.m_tp_pagamento2; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN movimentacao.m_tp_pagamento2 IS 'DN-Dinheiro
CT-Cartao';


--
-- TOC entry 219 (class 1259 OID 16747)
-- Name: movimentacao_m_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE movimentacao_m_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.movimentacao_m_id_seq OWNER TO postgres;

--
-- TOC entry 2726 (class 0 OID 0)
-- Dependencies: 219
-- Name: movimentacao_m_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE movimentacao_m_id_seq OWNED BY movimentacao.m_id;


--
-- TOC entry 220 (class 1259 OID 16749)
-- Name: movimentacao_prod; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE movimentacao_prod (
    mpid bigint NOT NULL,
    mptipo character varying(1) DEFAULT 'E'::character varying NOT NULL,
    mpdata date DEFAULT ('now'::text)::date NOT NULL,
    mpidprod integer NOT NULL,
    mpnomeprod character varying NOT NULL,
    mpidfornecedor integer,
    mpfornecedor character varying,
    mpmotivo character varying
);


ALTER TABLE public.movimentacao_prod OWNER TO postgres;

--
-- TOC entry 2727 (class 0 OID 0)
-- Dependencies: 220
-- Name: COLUMN movimentacao_prod.mptipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN movimentacao_prod.mptipo IS 'E - Entrada
S - Saida';


--
-- TOC entry 221 (class 1259 OID 16757)
-- Name: movimentacao_prod_mpid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE movimentacao_prod_mpid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.movimentacao_prod_mpid_seq OWNER TO postgres;

--
-- TOC entry 2728 (class 0 OID 0)
-- Dependencies: 221
-- Name: movimentacao_prod_mpid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE movimentacao_prod_mpid_seq OWNED BY movimentacao_prod.mpid;


--
-- TOC entry 222 (class 1259 OID 16759)
-- Name: padrao_sistema; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE padrao_sistema (
    psid bigint NOT NULL,
    psnomesistema character varying,
    psestado character varying,
    pscidade character varying
);


ALTER TABLE public.padrao_sistema OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16765)
-- Name: padrao_sistema_psid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE padrao_sistema_psid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.padrao_sistema_psid_seq OWNER TO postgres;

--
-- TOC entry 2729 (class 0 OID 0)
-- Dependencies: 223
-- Name: padrao_sistema_psid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE padrao_sistema_psid_seq OWNED BY padrao_sistema.psid;


--
-- TOC entry 224 (class 1259 OID 16767)
-- Name: prod_fornecedor; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE prod_fornecedor (
    pfid bigint NOT NULL,
    pfidproduto integer,
    pfdescr_produto character varying,
    pfidfornecedor integer,
    pfnomefornecedor character varying,
    pfquantidade double precision DEFAULT 0.00 NOT NULL,
    pfpreco_custo real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.prod_fornecedor OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16775)
-- Name: prod_fornecedor_pfid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE prod_fornecedor_pfid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.prod_fornecedor_pfid_seq OWNER TO postgres;

--
-- TOC entry 2730 (class 0 OID 0)
-- Dependencies: 225
-- Name: prod_fornecedor_pfid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE prod_fornecedor_pfid_seq OWNED BY prod_fornecedor.pfid;


--
-- TOC entry 226 (class 1259 OID 16777)
-- Name: produto; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE produto (
    pid bigint NOT NULL,
    pdescricao character varying,
    ppeso real DEFAULT 0.00 NOT NULL,
    pcodigo smallint DEFAULT 0 NOT NULL,
    pinformacao character varying,
    pcusto real DEFAULT 0.00 NOT NULL,
    pmargemlucro real DEFAULT 0.00 NOT NULL,
    pvenda real DEFAULT 0.00 NOT NULL,
    pestoque double precision DEFAULT 0.000 NOT NULL,
    punidade character varying(7),
    pdespadicional real DEFAULT 0.00 NOT NULL,
    pgrupoid integer DEFAULT 0,
    pgrupodescricao character varying,
    pmarcaid integer DEFAULT 0 NOT NULL,
    pmarcanome character varying,
    preferencia character varying
);


ALTER TABLE public.produto OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16792)
-- Name: produto_pid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE produto_pid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.produto_pid_seq OWNER TO postgres;

--
-- TOC entry 2731 (class 0 OID 0)
-- Dependencies: 227
-- Name: produto_pid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE produto_pid_seq OWNED BY produto.pid;


--
-- TOC entry 228 (class 1259 OID 16794)
-- Name: produtoservico; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE produtoservico (
    psid bigint NOT NULL,
    psidservico integer NOT NULL,
    psidproduto integer NOT NULL,
    psprodutodescricao character varying NOT NULL,
    psquantidade real DEFAULT 0 NOT NULL
);


ALTER TABLE public.produtoservico OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 16801)
-- Name: produtoservico_psid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE produtoservico_psid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.produtoservico_psid_seq OWNER TO postgres;

--
-- TOC entry 2732 (class 0 OID 0)
-- Dependencies: 229
-- Name: produtoservico_psid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE produtoservico_psid_seq OWNED BY produtoservico.psid;


--
-- TOC entry 230 (class 1259 OID 16803)
-- Name: produtousado; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE produtousado (
    puid bigint NOT NULL,
    puidproduto integer NOT NULL,
    punomeproduto character varying NOT NULL,
    puidservico integer NOT NULL,
    pudescrservico character varying NOT NULL,
    puqtdeproduto real DEFAULT 0 NOT NULL,
    pudatahora timestamp without time zone DEFAULT now() NOT NULL
);


ALTER TABLE public.produtousado OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 16811)
-- Name: produtousado_puid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE produtousado_puid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.produtousado_puid_seq OWNER TO postgres;

--
-- TOC entry 2733 (class 0 OID 0)
-- Dependencies: 231
-- Name: produtousado_puid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE produtousado_puid_seq OWNED BY produtousado.puid;


--
-- TOC entry 232 (class 1259 OID 16813)
-- Name: produtousadovenda; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE produtousadovenda (
    puvid bigint NOT NULL,
    puvidproduto integer NOT NULL,
    puvnomeproduto character varying NOT NULL,
    puvidservico integer NOT NULL,
    puvdescrservico character varying NOT NULL,
    puvqtdeproduto real DEFAULT 0 NOT NULL,
    puvdatahora timestamp without time zone DEFAULT now() NOT NULL,
    puvidvenda bigint NOT NULL
);


ALTER TABLE public.produtousadovenda OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 16821)
-- Name: produtousadovenda_puvid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE produtousadovenda_puvid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.produtousadovenda_puvid_seq OWNER TO postgres;

--
-- TOC entry 2734 (class 0 OID 0)
-- Dependencies: 233
-- Name: produtousadovenda_puvid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE produtousadovenda_puvid_seq OWNED BY produtousadovenda.puvid;


--
-- TOC entry 234 (class 1259 OID 16823)
-- Name: rua; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE rua (
    rid bigint NOT NULL,
    rnome character varying NOT NULL
);


ALTER TABLE public.rua OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 16829)
-- Name: rua_rid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE rua_rid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.rua_rid_seq OWNER TO postgres;

--
-- TOC entry 2735 (class 0 OID 0)
-- Dependencies: 235
-- Name: rua_rid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE rua_rid_seq OWNED BY rua.rid;


--
-- TOC entry 236 (class 1259 OID 16831)
-- Name: servicos; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE servicos (
    sid bigint NOT NULL,
    sdescricao character varying NOT NULL,
    svalor real DEFAULT 0.00 NOT NULL,
    sdespcartaodinheiro real DEFAULT 0.00 NOT NULL,
    sdespcartaoporcentagem real DEFAULT 0.00 NOT NULL,
    sdataalteracao date,
    sidatendente integer DEFAULT 0 NOT NULL,
    snomeatendente character varying
);


ALTER TABLE public.servicos OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 16841)
-- Name: servicos_sid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE servicos_sid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.servicos_sid_seq OWNER TO postgres;

--
-- TOC entry 2736 (class 0 OID 0)
-- Dependencies: 237
-- Name: servicos_sid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE servicos_sid_seq OWNED BY servicos.sid;


--
-- TOC entry 238 (class 1259 OID 16843)
-- Name: sincroniza; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE sincroniza (
    sin_id bigint NOT NULL,
    sin_mac character varying NOT NULL,
    sin_sincroniza boolean DEFAULT false NOT NULL
);


ALTER TABLE public.sincroniza OWNER TO postgres;

--
-- TOC entry 239 (class 1259 OID 16850)
-- Name: sincroniza_sin_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE sincroniza_sin_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.sincroniza_sin_id_seq OWNER TO postgres;

--
-- TOC entry 2737 (class 0 OID 0)
-- Dependencies: 239
-- Name: sincroniza_sin_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE sincroniza_sin_id_seq OWNED BY sincroniza.sin_id;


--
-- TOC entry 240 (class 1259 OID 16852)
-- Name: sincronizacao; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE sincronizacao (
    s_id bigint NOT NULL,
    s_mac character varying NOT NULL,
    s_sincroniza boolean DEFAULT false NOT NULL
);


ALTER TABLE public.sincronizacao OWNER TO postgres;

--
-- TOC entry 241 (class 1259 OID 16859)
-- Name: sincronizacao_s_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE sincronizacao_s_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.sincronizacao_s_id_seq OWNER TO postgres;

--
-- TOC entry 2738 (class 0 OID 0)
-- Dependencies: 241
-- Name: sincronizacao_s_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE sincronizacao_s_id_seq OWNED BY sincronizacao.s_id;


--
-- TOC entry 242 (class 1259 OID 16861)
-- Name: subgrupo_desp_m; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE subgrupo_desp_m (
    sgp_id bigint NOT NULL,
    sgp_gpid bigint NOT NULL,
    sgp_gpdescricao character varying NOT NULL,
    sgp_descricao character varying NOT NULL,
    sgp_valorpadrao real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.subgrupo_desp_m OWNER TO postgres;

--
-- TOC entry 243 (class 1259 OID 16868)
-- Name: subgrupo_desp_m_sbp_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE subgrupo_desp_m_sbp_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subgrupo_desp_m_sbp_id_seq OWNER TO postgres;

--
-- TOC entry 2739 (class 0 OID 0)
-- Dependencies: 243
-- Name: subgrupo_desp_m_sbp_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE subgrupo_desp_m_sbp_id_seq OWNED BY subgrupo_desp_m.sgp_id;


--
-- TOC entry 244 (class 1259 OID 16870)
-- Name: tempo; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE tempo (
    tid bigint NOT NULL,
    tminutos smallint DEFAULT 1 NOT NULL,
    tvalor real DEFAULT 1 NOT NULL
);


ALTER TABLE public.tempo OWNER TO postgres;

--
-- TOC entry 245 (class 1259 OID 16875)
-- Name: tempo_tid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE tempo_tid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tempo_tid_seq OWNER TO postgres;

--
-- TOC entry 2740 (class 0 OID 0)
-- Dependencies: 245
-- Name: tempo_tid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tempo_tid_seq OWNED BY tempo.tid;


--
-- TOC entry 246 (class 1259 OID 16877)
-- Name: termo; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE termo (
    termo1 text NOT NULL,
    tr_id bigint NOT NULL,
    termo2 text,
    termo3 text,
    termo4 text
);


ALTER TABLE public.termo OWNER TO postgres;

--
-- TOC entry 247 (class 1259 OID 16883)
-- Name: termo_tr_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE termo_tr_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.termo_tr_id_seq OWNER TO postgres;

--
-- TOC entry 2741 (class 0 OID 0)
-- Dependencies: 247
-- Name: termo_tr_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE termo_tr_id_seq OWNED BY termo.tr_id;


--
-- TOC entry 248 (class 1259 OID 16885)
-- Name: tipo_documento; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE tipo_documento (
    td_id bigint NOT NULL,
    td_descricao character varying NOT NULL,
    td_tela character varying(2) DEFAULT 'AP'::character varying NOT NULL
);


ALTER TABLE public.tipo_documento OWNER TO postgres;

--
-- TOC entry 2742 (class 0 OID 0)
-- Dependencies: 248
-- Name: COLUMN tipo_documento.td_tela; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN tipo_documento.td_tela IS 'AR = AReceber
AP = APagar';


--
-- TOC entry 249 (class 1259 OID 16892)
-- Name: tipo_documento_td_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE tipo_documento_td_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tipo_documento_td_id_seq OWNER TO postgres;

--
-- TOC entry 2743 (class 0 OID 0)
-- Dependencies: 249
-- Name: tipo_documento_td_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tipo_documento_td_id_seq OWNED BY tipo_documento.td_id;


--
-- TOC entry 250 (class 1259 OID 16894)
-- Name: trava; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE trava (
    idx bigint NOT NULL,
    datatravamento date,
    travar boolean DEFAULT false,
    versao character varying
);


ALTER TABLE public.trava OWNER TO postgres;

--
-- TOC entry 251 (class 1259 OID 16901)
-- Name: trava_idx_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE trava_idx_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.trava_idx_seq OWNER TO postgres;

--
-- TOC entry 2744 (class 0 OID 0)
-- Dependencies: 251
-- Name: trava_idx_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE trava_idx_seq OWNED BY trava.idx;


--
-- TOC entry 252 (class 1259 OID 16903)
-- Name: unidade; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE unidade (
    uid bigint NOT NULL,
    udescricao character varying(5) DEFAULT 'UN'::character varying NOT NULL
);


ALTER TABLE public.unidade OWNER TO postgres;

--
-- TOC entry 253 (class 1259 OID 16907)
-- Name: unidade_uid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE unidade_uid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.unidade_uid_seq OWNER TO postgres;

--
-- TOC entry 2745 (class 0 OID 0)
-- Dependencies: 253
-- Name: unidade_uid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE unidade_uid_seq OWNED BY unidade.uid;


--
-- TOC entry 254 (class 1259 OID 16909)
-- Name: usuario; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE usuario (
    u_id bigint NOT NULL,
    u_login character varying(10) NOT NULL,
    u_nome character varying(20),
    u_senha character varying NOT NULL,
    u_privilegio boolean DEFAULT false NOT NULL,
    u_bloqueado boolean DEFAULT false NOT NULL,
    u_foto oid,
    u_empresaid integer DEFAULT 0 NOT NULL,
    u_empresanome character varying,
    u_inativo boolean DEFAULT false NOT NULL,
    u_caixa boolean DEFAULT false NOT NULL,
    u_datanascimento character varying
);


ALTER TABLE public.usuario OWNER TO postgres;

--
-- TOC entry 255 (class 1259 OID 16920)
-- Name: usuario_u_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE usuario_u_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.usuario_u_id_seq OWNER TO postgres;

--
-- TOC entry 2746 (class 0 OID 0)
-- Dependencies: 255
-- Name: usuario_u_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE usuario_u_id_seq OWNED BY usuario.u_id;


--
-- TOC entry 256 (class 1259 OID 16922)
-- Name: usuariotelas; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE usuariotelas (
    tl_id bigint NOT NULL,
    tl_idusuario smallint NOT NULL,
    tl_cadastros boolean DEFAULT false NOT NULL,
    tl_cadcliente boolean DEFAULT false NOT NULL,
    tl_cadvendedor boolean DEFAULT false NOT NULL,
    tl_cadusuario boolean DEFAULT false NOT NULL,
    tl_cadtitular boolean DEFAULT false NOT NULL,
    tl_cadcidade boolean DEFAULT false NOT NULL,
    tl_cadservico boolean DEFAULT false NOT NULL,
    tl_cadgeno boolean DEFAULT false NOT NULL,
    tl_movimentos boolean DEFAULT false NOT NULL,
    tl_movpedido boolean DEFAULT false NOT NULL,
    tl_movorcamento boolean DEFAULT false NOT NULL,
    tl_movtransferencia boolean DEFAULT false NOT NULL,
    tl_movnfe boolean DEFAULT false NOT NULL,
    tl_cupom boolean DEFAULT false NOT NULL,
    tl_cpprevenda boolean DEFAULT false NOT NULL,
    tl_cpvendadireta boolean DEFAULT false NOT NULL,
    tl_cpconfiguracao boolean DEFAULT false NOT NULL,
    tl_estoque boolean DEFAULT false NOT NULL,
    tl_estpesquisa boolean DEFAULT false NOT NULL,
    tl_estrestaura boolean DEFAULT false NOT NULL,
    tl_estimplantacao boolean DEFAULT false NOT NULL,
    tl_estpedidocompras boolean DEFAULT false NOT NULL,
    tl_estcompras boolean DEFAULT false NOT NULL,
    tl_estatualizacao boolean DEFAULT false NOT NULL,
    tl_financeiro boolean DEFAULT false NOT NULL,
    tl_finpagamentos boolean DEFAULT false NOT NULL,
    tl_finrecebimentos boolean DEFAULT false NOT NULL,
    tl_finfluxocaixa boolean DEFAULT false NOT NULL,
    tl_findespesas boolean DEFAULT false NOT NULL,
    tl_finchqpredatado boolean DEFAULT false NOT NULL,
    tl_manutencao boolean DEFAULT false NOT NULL,
    tl_manemprestimos boolean DEFAULT false NOT NULL,
    tl_mantrocas boolean DEFAULT false NOT NULL,
    tl_manpalmtop boolean DEFAULT false NOT NULL,
    tl_mancidadesibge boolean DEFAULT false NOT NULL,
    tl_contabil boolean DEFAULT false NOT NULL,
    tl_ctbarqdigitais boolean DEFAULT false NOT NULL,
    tl_ctblivrosfiscais boolean DEFAULT false NOT NULL,
    tl_ctbcontador boolean DEFAULT false NOT NULL,
    tl_ctbcfop boolean DEFAULT false NOT NULL,
    tl_parametros boolean DEFAULT false NOT NULL,
    tl_paracontrole boolean DEFAULT false NOT NULL,
    tl_paraultilitarios boolean DEFAULT false NOT NULL,
    tl_parabackup boolean DEFAULT false NOT NULL,
    btn_cancelarexcluir boolean DEFAULT false NOT NULL,
    tl_cadcomodato boolean DEFAULT false NOT NULL,
    tl_cadautomovel boolean DEFAULT false NOT NULL,
    tl_cadgerais boolean DEFAULT false NOT NULL,
    tl_cadgerente boolean DEFAULT false NOT NULL,
    tl_movrequisicao boolean DEFAULT false NOT NULL,
    tl_movemispedido boolean DEFAULT false NOT NULL,
    tl_movgeramapa boolean DEFAULT false NOT NULL,
    tl_mapas boolean DEFAULT false NOT NULL,
    tl_mpvenda boolean DEFAULT false NOT NULL,
    tl_mpretornovenda boolean DEFAULT false NOT NULL,
    tl_estrelatorios boolean DEFAULT false NOT NULL,
    tl_paraconfiguracao boolean DEFAULT false NOT NULL,
    tl_pagoaentregar boolean DEFAULT false NOT NULL,
    btn_carne boolean DEFAULT false NOT NULL,
    tl_movagendamentos boolean DEFAULT false NOT NULL
);


ALTER TABLE public.usuariotelas OWNER TO postgres;

--
-- TOC entry 257 (class 1259 OID 16985)
-- Name: usuariotelas_tl_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE usuariotelas_tl_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.usuariotelas_tl_id_seq OWNER TO postgres;

--
-- TOC entry 2747 (class 0 OID 0)
-- Dependencies: 257
-- Name: usuariotelas_tl_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE usuariotelas_tl_id_seq OWNED BY usuariotelas.tl_id;


--
-- TOC entry 258 (class 1259 OID 16987)
-- Name: venda_servico; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE venda_servico (
    vsid bigint NOT NULL,
    vsempresaid integer NOT NULL,
    vsempresanome character varying NOT NULL,
    vsempresauf character varying(2) DEFAULT 'PI'::character varying NOT NULL,
    vsempresacidade character varying,
    vsclienteid integer,
    vsclientenome character varying,
    vsclienteuf character varying,
    vsclientecidade character varying,
    vsdatahora timestamp without time zone DEFAULT now() NOT NULL,
    vssubtotal real DEFAULT 0.00 NOT NULL,
    vsdesconto real DEFAULT 0.00 NOT NULL,
    vstotalgeral real DEFAULT 0.00 NOT NULL,
    vspagodinheiro real DEFAULT 0.00 NOT NULL,
    vspagocredito real DEFAULT 0.00 NOT NULL,
    vspagodebito real DEFAULT 0.00 NOT NULL,
    vspagopix real DEFAULT 0.00 NOT NULL,
    vspagotransferencia real DEFAULT 0.00 NOT NULL,
    vspagocrediario real DEFAULT 0.00 NOT NULL,
    CONSTRAINT venda_servico_check CHECK ((vstotalgeral = (((((vspagodinheiro + vspagocredito) + vspagodebito) + vspagopix) + vspagotransferencia) + vspagocrediario)))
);


ALTER TABLE public.venda_servico OWNER TO postgres;

--
-- TOC entry 259 (class 1259 OID 17005)
-- Name: venda_servico_itens; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE venda_servico_itens (
    vsi_id bigint NOT NULL,
    vsi_data timestamp without time zone NOT NULL,
    vs_id bigint NOT NULL,
    vs_totalcartao real DEFAULT 0.00 NOT NULL,
    vs_totalcartaoseparado real DEFAULT 0.00 NOT NULL,
    vsi_servicoid integer DEFAULT 0 NOT NULL,
    vsi_serviconome character varying NOT NULL,
    vsi_servicodespctporcent real DEFAULT 0.00 NOT NULL,
    vsi_servicodespctvalor real DEFAULT 0.00 NOT NULL,
    vsi_atendenteid integer DEFAULT 0 NOT NULL,
    vsi_atendentenome character varying NOT NULL,
    vsi_atendentecomissao real DEFAULT 0.00 NOT NULL,
    vsi_quantidadeservico real DEFAULT 0 NOT NULL,
    vsi_valorservico real DEFAULT 0.00 NOT NULL,
    vsi_descontoservico real DEFAULT 0.00 NOT NULL,
    vsi_subtotalservico real DEFAULT 0.00 NOT NULL,
    vsi_valortotalservico real DEFAULT 0.00 NOT NULL,
    vsi_despcartaoseparado real DEFAULT 0.00 NOT NULL,
    vsi_valorcomissao real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.venda_servico_itens OWNER TO postgres;

--
-- TOC entry 2748 (class 0 OID 0)
-- Dependencies: 259
-- Name: COLUMN venda_servico_itens.vsi_servicodespctporcent; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN venda_servico_itens.vsi_servicodespctporcent IS 'servico - despesa com cartao em porcentagem';


--
-- TOC entry 2749 (class 0 OID 0)
-- Dependencies: 259
-- Name: COLUMN venda_servico_itens.vsi_servicodespctvalor; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN venda_servico_itens.vsi_servicodespctvalor IS 'servico - despesa com cartao em valor informado no cadastro do servico';


--
-- TOC entry 2750 (class 0 OID 0)
-- Dependencies: 259
-- Name: COLUMN venda_servico_itens.vsi_atendentecomissao; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN venda_servico_itens.vsi_atendentecomissao IS 'comissao em %';


--
-- TOC entry 2751 (class 0 OID 0)
-- Dependencies: 259
-- Name: COLUMN venda_servico_itens.vsi_subtotalservico; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN venda_servico_itens.vsi_subtotalservico IS 'qtde * valor do servico';


--
-- TOC entry 2752 (class 0 OID 0)
-- Dependencies: 259
-- Name: COLUMN venda_servico_itens.vsi_valortotalservico; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN venda_servico_itens.vsi_valortotalservico IS 'subtotal - desconto';


--
-- TOC entry 2753 (class 0 OID 0)
-- Dependencies: 259
-- Name: COLUMN venda_servico_itens.vsi_despcartaoseparado; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN venda_servico_itens.vsi_despcartaoseparado IS '(valor total cartao separado * servico desp cartao porcent) / 100';


--
-- TOC entry 2754 (class 0 OID 0)
-- Dependencies: 259
-- Name: COLUMN venda_servico_itens.vsi_valorcomissao; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN venda_servico_itens.vsi_valorcomissao IS '((valor total servico - desp cartao separado) * comissao atendente) / 100';


--
-- TOC entry 260 (class 1259 OID 17025)
-- Name: venda_servico_itens_vsi_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE venda_servico_itens_vsi_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.venda_servico_itens_vsi_id_seq OWNER TO postgres;

--
-- TOC entry 2755 (class 0 OID 0)
-- Dependencies: 260
-- Name: venda_servico_itens_vsi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE venda_servico_itens_vsi_id_seq OWNED BY venda_servico_itens.vsi_id;


--
-- TOC entry 261 (class 1259 OID 17027)
-- Name: venda_servico_vsid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE venda_servico_vsid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.venda_servico_vsid_seq OWNER TO postgres;

--
-- TOC entry 2756 (class 0 OID 0)
-- Dependencies: 261
-- Name: venda_servico_vsid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE venda_servico_vsid_seq OWNED BY venda_servico.vsid;


--
-- TOC entry 2253 (class 2604 OID 17029)
-- Name: af_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY abrir_fechar ALTER COLUMN af_id SET DEFAULT nextval('abrir_fechar_af_id_seq'::regclass);


--
-- TOC entry 2263 (class 2604 OID 17030)
-- Name: a_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY agendamento ALTER COLUMN a_id SET DEFAULT nextval('agendamento_a_id_seq'::regclass);


--
-- TOC entry 2269 (class 2604 OID 17031)
-- Name: agi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY agendamento_itens ALTER COLUMN agi_id SET DEFAULT nextval('agendamento_itens_agi_id_seq'::regclass);


--
-- TOC entry 2281 (class 2604 OID 17032)
-- Name: app_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY apagar_parcial ALTER COLUMN app_id SET DEFAULT nextval('apagar_parcial_app_id_seq'::regclass);


--
-- TOC entry 2302 (class 2604 OID 17033)
-- Name: apt_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY apagar_total ALTER COLUMN apt_id SET DEFAULT nextval('apagar_total_apt_id_seq'::regclass);


--
-- TOC entry 2314 (class 2604 OID 17034)
-- Name: arp_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY areceber_parcial ALTER COLUMN arp_id SET DEFAULT nextval('areceber_parcial_arp_id_seq'::regclass);


--
-- TOC entry 2333 (class 2604 OID 17035)
-- Name: art_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY areceber_total ALTER COLUMN art_id SET DEFAULT nextval('areceber_total_art_id_seq'::regclass);


--
-- TOC entry 2336 (class 2604 OID 17036)
-- Name: aid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY atendente ALTER COLUMN aid SET DEFAULT nextval('atendente_aid_seq'::regclass);


--
-- TOC entry 2337 (class 2604 OID 17037)
-- Name: bid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bairro ALTER COLUMN bid SET DEFAULT nextval('bairro_bid_seq'::regclass);


--
-- TOC entry 2339 (class 2604 OID 17038)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY cadestado ALTER COLUMN id SET DEFAULT nextval('cadestado_id_seq'::regclass);


--
-- TOC entry 2340 (class 2604 OID 17039)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY cadmun ALTER COLUMN id SET DEFAULT nextval('cadmun_id_seq'::regclass);


--
-- TOC entry 2341 (class 2604 OID 17040)
-- Name: id_estado; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY cadmun ALTER COLUMN id_estado SET DEFAULT nextval('cadmun_id_estado_seq'::regclass);


--
-- TOC entry 2345 (class 2604 OID 17041)
-- Name: cx_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY caixa ALTER COLUMN cx_id SET DEFAULT nextval('caixa_cx_id_seq'::regclass);


--
-- TOC entry 2351 (class 2604 OID 17042)
-- Name: cid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY cliente ALTER COLUMN cid SET DEFAULT nextval('cliente_cid_seq'::regclass);


--
-- TOC entry 2357 (class 2604 OID 17043)
-- Name: c_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY comissao ALTER COLUMN c_id SET DEFAULT nextval('comissao_c_id_seq'::regclass);


--
-- TOC entry 2361 (class 2604 OID 17044)
-- Name: idconfg; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY configuracoes ALTER COLUMN idconfg SET DEFAULT nextval('configuracoes_idconfg_seq'::regclass);


--
-- TOC entry 2364 (class 2604 OID 17045)
-- Name: dpid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY desp_produto ALTER COLUMN dpid SET DEFAULT nextval('desp_produto_dpid_seq'::regclass);


--
-- TOC entry 2369 (class 2604 OID 17046)
-- Name: dm_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY despesa_mensal ALTER COLUMN dm_id SET DEFAULT nextval('despesa_mensal_dm_id_seq'::regclass);


--
-- TOC entry 2371 (class 2604 OID 17047)
-- Name: empid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY empresa ALTER COLUMN empid SET DEFAULT nextval('empresa_empid_seq'::regclass);


--
-- TOC entry 2379 (class 2604 OID 17048)
-- Name: esid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY entrada_saida ALTER COLUMN esid SET DEFAULT nextval('entrada_saida_esid_seq'::regclass);


--
-- TOC entry 2384 (class 2604 OID 17049)
-- Name: fid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY fornecedor ALTER COLUMN fid SET DEFAULT nextval('fornecedor_fid_seq'::regclass);


--
-- TOC entry 2385 (class 2604 OID 17050)
-- Name: gp_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY grupo_desp_m ALTER COLUMN gp_id SET DEFAULT nextval('grupo_desp_m_gp_id_seq'::regclass);


--
-- TOC entry 2387 (class 2604 OID 17051)
-- Name: imc_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY imc ALTER COLUMN imc_id SET DEFAULT nextval('imc_imc_id_seq'::regclass);


--
-- TOC entry 2394 (class 2604 OID 17052)
-- Name: inp_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY infonutri_pessoa ALTER COLUMN inp_id SET DEFAULT nextval('infonutri_pessoa_inp_id_seq'::regclass);


--
-- TOC entry 2398 (class 2604 OID 17053)
-- Name: inpi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY infonutri_pessoa_itens ALTER COLUMN inpi_id SET DEFAULT nextval('infonutri_pessoa_itens_inpi_id_seq'::regclass);


--
-- TOC entry 2416 (class 2604 OID 17054)
-- Name: m_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY movimentacao ALTER COLUMN m_id SET DEFAULT nextval('movimentacao_m_id_seq'::regclass);


--
-- TOC entry 2419 (class 2604 OID 17055)
-- Name: mpid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY movimentacao_prod ALTER COLUMN mpid SET DEFAULT nextval('movimentacao_prod_mpid_seq'::regclass);


--
-- TOC entry 2420 (class 2604 OID 17056)
-- Name: psid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY padrao_sistema ALTER COLUMN psid SET DEFAULT nextval('padrao_sistema_psid_seq'::regclass);


--
-- TOC entry 2423 (class 2604 OID 17057)
-- Name: pfid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY prod_fornecedor ALTER COLUMN pfid SET DEFAULT nextval('prod_fornecedor_pfid_seq'::regclass);


--
-- TOC entry 2433 (class 2604 OID 17058)
-- Name: pid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY produto ALTER COLUMN pid SET DEFAULT nextval('produto_pid_seq'::regclass);


--
-- TOC entry 2435 (class 2604 OID 17059)
-- Name: psid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY produtoservico ALTER COLUMN psid SET DEFAULT nextval('produtoservico_psid_seq'::regclass);


--
-- TOC entry 2438 (class 2604 OID 17060)
-- Name: puid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY produtousado ALTER COLUMN puid SET DEFAULT nextval('produtousado_puid_seq'::regclass);


--
-- TOC entry 2441 (class 2604 OID 17061)
-- Name: puvid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY produtousadovenda ALTER COLUMN puvid SET DEFAULT nextval('produtousadovenda_puvid_seq'::regclass);


--
-- TOC entry 2442 (class 2604 OID 17062)
-- Name: rid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY rua ALTER COLUMN rid SET DEFAULT nextval('rua_rid_seq'::regclass);


--
-- TOC entry 2447 (class 2604 OID 17063)
-- Name: sid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY servicos ALTER COLUMN sid SET DEFAULT nextval('servicos_sid_seq'::regclass);


--
-- TOC entry 2449 (class 2604 OID 17064)
-- Name: sin_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY sincroniza ALTER COLUMN sin_id SET DEFAULT nextval('sincroniza_sin_id_seq'::regclass);


--
-- TOC entry 2451 (class 2604 OID 17065)
-- Name: s_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY sincronizacao ALTER COLUMN s_id SET DEFAULT nextval('sincronizacao_s_id_seq'::regclass);


--
-- TOC entry 2453 (class 2604 OID 17066)
-- Name: sgp_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY subgrupo_desp_m ALTER COLUMN sgp_id SET DEFAULT nextval('subgrupo_desp_m_sbp_id_seq'::regclass);


--
-- TOC entry 2456 (class 2604 OID 17067)
-- Name: tid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tempo ALTER COLUMN tid SET DEFAULT nextval('tempo_tid_seq'::regclass);


--
-- TOC entry 2457 (class 2604 OID 17068)
-- Name: tr_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY termo ALTER COLUMN tr_id SET DEFAULT nextval('termo_tr_id_seq'::regclass);


--
-- TOC entry 2459 (class 2604 OID 17069)
-- Name: td_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tipo_documento ALTER COLUMN td_id SET DEFAULT nextval('tipo_documento_td_id_seq'::regclass);


--
-- TOC entry 2461 (class 2604 OID 17070)
-- Name: idx; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY trava ALTER COLUMN idx SET DEFAULT nextval('trava_idx_seq'::regclass);


--
-- TOC entry 2463 (class 2604 OID 17071)
-- Name: uid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY unidade ALTER COLUMN uid SET DEFAULT nextval('unidade_uid_seq'::regclass);


--
-- TOC entry 2469 (class 2604 OID 17072)
-- Name: u_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY usuario ALTER COLUMN u_id SET DEFAULT nextval('usuario_u_id_seq'::regclass);


--
-- TOC entry 2530 (class 2604 OID 17073)
-- Name: tl_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY usuariotelas ALTER COLUMN tl_id SET DEFAULT nextval('usuariotelas_tl_id_seq'::regclass);


--
-- TOC entry 2542 (class 2604 OID 17074)
-- Name: vsid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY venda_servico ALTER COLUMN vsid SET DEFAULT nextval('venda_servico_vsid_seq'::regclass);


--
-- TOC entry 2558 (class 2604 OID 17075)
-- Name: vsi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY venda_servico_itens ALTER COLUMN vsi_id SET DEFAULT nextval('venda_servico_itens_vsi_id_seq'::regclass);


--
-- TOC entry 2560 (class 2606 OID 17077)
-- Name: af_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY abrir_fechar
    ADD CONSTRAINT af_idx PRIMARY KEY (af_id);


--
-- TOC entry 2562 (class 2606 OID 17079)
-- Name: agidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY agendamento
    ADD CONSTRAINT agidx PRIMARY KEY (a_id);


--
-- TOC entry 2568 (class 2606 OID 17081)
-- Name: agiidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY agendamento_itens
    ADD CONSTRAINT agiidx PRIMARY KEY (agi_id);


--
-- TOC entry 2574 (class 2606 OID 17083)
-- Name: appidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY apagar_parcial
    ADD CONSTRAINT appidx PRIMARY KEY (app_id);


--
-- TOC entry 2576 (class 2606 OID 17085)
-- Name: aptidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY apagar_total
    ADD CONSTRAINT aptidx PRIMARY KEY (apt_id);


--
-- TOC entry 2578 (class 2606 OID 17087)
-- Name: arpidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY areceber_parcial
    ADD CONSTRAINT arpidx PRIMARY KEY (arp_id);


--
-- TOC entry 2580 (class 2606 OID 17089)
-- Name: artidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY areceber_total
    ADD CONSTRAINT artidx PRIMARY KEY (art_id);


--
-- TOC entry 2584 (class 2606 OID 17091)
-- Name: bidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY bairro
    ADD CONSTRAINT bidx PRIMARY KEY (bid);


--
-- TOC entry 2597 (class 2606 OID 17093)
-- Name: c_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY comissao
    ADD CONSTRAINT c_idx PRIMARY KEY (c_id);


--
-- TOC entry 2592 (class 2606 OID 17095)
-- Name: cidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY cliente
    ADD CONSTRAINT cidx PRIMARY KEY (cid);


--
-- TOC entry 2590 (class 2606 OID 17097)
-- Name: cx_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY caixa
    ADD CONSTRAINT cx_idx PRIMARY KEY (cx_id);


--
-- TOC entry 2603 (class 2606 OID 17099)
-- Name: dm_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY despesa_mensal
    ADD CONSTRAINT dm_idx PRIMARY KEY (dm_id);


--
-- TOC entry 2601 (class 2606 OID 17101)
-- Name: dp_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY desp_produto
    ADD CONSTRAINT dp_id PRIMARY KEY (dpid);


--
-- TOC entry 2605 (class 2606 OID 17103)
-- Name: empidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY empresa
    ADD CONSTRAINT empidx PRIMARY KEY (empid);


--
-- TOC entry 2607 (class 2606 OID 17105)
-- Name: esidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY entrada_saida
    ADD CONSTRAINT esidx PRIMARY KEY (esid);


--
-- TOC entry 2609 (class 2606 OID 17107)
-- Name: f_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY fornecedor
    ADD CONSTRAINT f_id PRIMARY KEY (fid);


--
-- TOC entry 2611 (class 2606 OID 17109)
-- Name: gp_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY grupo_desp_m
    ADD CONSTRAINT gp_idx PRIMARY KEY (gp_id);


--
-- TOC entry 2586 (class 2606 OID 17111)
-- Name: id_estado; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY cadestado
    ADD CONSTRAINT id_estado PRIMARY KEY (id);


--
-- TOC entry 2588 (class 2606 OID 17113)
-- Name: id_mun; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY cadmun
    ADD CONSTRAINT id_mun PRIMARY KEY (id);


--
-- TOC entry 2653 (class 2606 OID 17115)
-- Name: id_trava; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY trava
    ADD CONSTRAINT id_trava PRIMARY KEY (idx);


--
-- TOC entry 2657 (class 2606 OID 17117)
-- Name: idusuario; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY usuario
    ADD CONSTRAINT idusuario PRIMARY KEY (u_id);


--
-- TOC entry 2599 (class 2606 OID 17119)
-- Name: idxconfig; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY configuracoes
    ADD CONSTRAINT idxconfig PRIMARY KEY (idconfg);


--
-- TOC entry 2613 (class 2606 OID 17121)
-- Name: imc_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY imc
    ADD CONSTRAINT imc_idx PRIMARY KEY (imc_id);


--
-- TOC entry 2615 (class 2606 OID 17123)
-- Name: inp_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY infonutri_pessoa
    ADD CONSTRAINT inp_idx PRIMARY KEY (inp_id);


--
-- TOC entry 2617 (class 2606 OID 17125)
-- Name: inpi_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY infonutri_pessoa_itens
    ADD CONSTRAINT inpi_idx PRIMARY KEY (inpi_id);


--
-- TOC entry 2625 (class 2606 OID 17127)
-- Name: pf_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY prod_fornecedor
    ADD CONSTRAINT pf_id PRIMARY KEY (pfid);


--
-- TOC entry 2623 (class 2606 OID 17129)
-- Name: pfidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY padrao_sistema
    ADD CONSTRAINT pfidx PRIMARY KEY (psid);


--
-- TOC entry 2631 (class 2606 OID 17131)
-- Name: psidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY produtoservico
    ADD CONSTRAINT psidx PRIMARY KEY (psid);


--
-- TOC entry 2633 (class 2606 OID 17133)
-- Name: puidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY produtousado
    ADD CONSTRAINT puidx PRIMARY KEY (puid);


--
-- TOC entry 2635 (class 2606 OID 17135)
-- Name: puvidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY produtousadovenda
    ADD CONSTRAINT puvidx PRIMARY KEY (puvid);


--
-- TOC entry 2637 (class 2606 OID 17137)
-- Name: ridx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY rua
    ADD CONSTRAINT ridx PRIMARY KEY (rid);


--
-- TOC entry 2643 (class 2606 OID 17139)
-- Name: s_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY sincronizacao
    ADD CONSTRAINT s_idx PRIMARY KEY (s_id);


--
-- TOC entry 2645 (class 2606 OID 17141)
-- Name: sbp_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY subgrupo_desp_m
    ADD CONSTRAINT sbp_idx PRIMARY KEY (sgp_id);


--
-- TOC entry 2639 (class 2606 OID 17143)
-- Name: sidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY servicos
    ADD CONSTRAINT sidx PRIMARY KEY (sid);


--
-- TOC entry 2641 (class 2606 OID 17145)
-- Name: sin_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY sincroniza
    ADD CONSTRAINT sin_idx PRIMARY KEY (sin_id);


--
-- TOC entry 2651 (class 2606 OID 17147)
-- Name: td_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tipo_documento
    ADD CONSTRAINT td_idx PRIMARY KEY (td_id);


--
-- TOC entry 2661 (class 2606 OID 17149)
-- Name: tl_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY usuariotelas
    ADD CONSTRAINT tl_id PRIMARY KEY (tl_id);


--
-- TOC entry 2655 (class 2606 OID 17151)
-- Name: u_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY unidade
    ADD CONSTRAINT u_id PRIMARY KEY (uid);


--
-- TOC entry 2666 (class 2606 OID 17153)
-- Name: vsi_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY venda_servico_itens
    ADD CONSTRAINT vsi_idx PRIMARY KEY (vsi_id);


--
-- TOC entry 2664 (class 2606 OID 17155)
-- Name: vsidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY venda_servico
    ADD CONSTRAINT vsidx PRIMARY KEY (vsid);


--
-- TOC entry 2582 (class 2606 OID 17157)
-- Name: xa_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY atendente
    ADD CONSTRAINT xa_id PRIMARY KEY (aid);


--
-- TOC entry 2619 (class 2606 OID 17159)
-- Name: xm_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY movimentacao
    ADD CONSTRAINT xm_id PRIMARY KEY (m_id);


--
-- TOC entry 2621 (class 2606 OID 17161)
-- Name: xmpid; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY movimentacao_prod
    ADD CONSTRAINT xmpid PRIMARY KEY (mpid);


--
-- TOC entry 2629 (class 2606 OID 17163)
-- Name: xpid; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY produto
    ADD CONSTRAINT xpid PRIMARY KEY (pid);


--
-- TOC entry 2647 (class 2606 OID 17165)
-- Name: xt_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tempo
    ADD CONSTRAINT xt_id PRIMARY KEY (tid);


--
-- TOC entry 2649 (class 2606 OID 17167)
-- Name: xtr_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY termo
    ADD CONSTRAINT xtr_id PRIMARY KEY (tr_id);


--
-- TOC entry 2626 (class 1259 OID 17168)
-- Name: index_pdescricao; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX index_pdescricao ON produto USING btree (pdescricao);


--
-- TOC entry 2627 (class 1259 OID 17169)
-- Name: index_preferencia; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX index_preferencia ON produto USING btree (preferencia);


--
-- TOC entry 2563 (class 1259 OID 17170)
-- Name: indx_a_doutor; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_a_doutor ON agendamento USING btree (a_doutor);


--
-- TOC entry 2564 (class 1259 OID 17171)
-- Name: indx_a_dtagend; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_a_dtagend ON agendamento USING btree (a_dtagend);


--
-- TOC entry 2565 (class 1259 OID 17172)
-- Name: indx_a_dtemis; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_a_dtemis ON agendamento USING btree (a_dtemis);


--
-- TOC entry 2566 (class 1259 OID 17173)
-- Name: indx_a_status; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_a_status ON agendamento USING btree (a_status);


--
-- TOC entry 2569 (class 1259 OID 17174)
-- Name: indx_ag_id; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_ag_id ON agendamento_itens USING btree (ag_id);


--
-- TOC entry 2570 (class 1259 OID 17175)
-- Name: indx_agi_atendenteid; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_agi_atendenteid ON agendamento_itens USING btree (agi_atendenteid);


--
-- TOC entry 2571 (class 1259 OID 17176)
-- Name: indx_agi_codserv; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_agi_codserv ON agendamento_itens USING btree (agi_codserv);


--
-- TOC entry 2572 (class 1259 OID 17177)
-- Name: indx_agi_dtemis; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_agi_dtemis ON agendamento_itens USING btree (agi_dtemis);


--
-- TOC entry 2593 (class 1259 OID 17178)
-- Name: indx_ccidade; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_ccidade ON cliente USING btree (ccidade);


--
-- TOC entry 2594 (class 1259 OID 17179)
-- Name: indx_cestado; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_cestado ON cliente USING btree (cestado);


--
-- TOC entry 2595 (class 1259 OID 17180)
-- Name: indx_cnome; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_cnome ON cliente USING btree (cnome);


--
-- TOC entry 2662 (class 1259 OID 17181)
-- Name: indx_vsclientenome; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX indx_vsclientenome ON venda_servico USING btree (vsclientenome);


--
-- TOC entry 2658 (class 1259 OID 17182)
-- Name: u_login; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX u_login ON usuario USING btree (u_login);


--
-- TOC entry 2659 (class 1259 OID 17183)
-- Name: u_senha; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX u_senha ON usuario USING btree (u_senha);


--
-- TOC entry 2676 (class 2620 OID 17184)
-- Name: dispara_func_altera_estoque; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER dispara_func_altera_estoque AFTER INSERT ON entrada_saida FOR EACH ROW EXECUTE PROCEDURE altera_estoque_produto();


--
-- TOC entry 2677 (class 2620 OID 17185)
-- Name: dispara_func_altera_estoque_del; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER dispara_func_altera_estoque_del AFTER DELETE ON entrada_saida FOR EACH ROW EXECUTE PROCEDURE altera_estoque_produto_del();


--
-- TOC entry 2678 (class 2620 OID 17186)
-- Name: muda_finalizacao_locacao; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER muda_finalizacao_locacao AFTER UPDATE ON movimentacao FOR EACH ROW EXECUTE PROCEDURE atualiza_data_finalizacao_locacao();


--
-- TOC entry 2679 (class 2620 OID 17187)
-- Name: trigger_insert_locacao_cancelada; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trigger_insert_locacao_cancelada AFTER DELETE ON movimentacao FOR EACH ROW EXECUTE PROCEDURE insert_locacao_cancelada();


--
-- TOC entry 2667 (class 2606 OID 17188)
-- Name: app_aptidx; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY apagar_parcial
    ADD CONSTRAINT app_aptidx FOREIGN KEY (app_aptid) REFERENCES apagar_total(apt_id);


--
-- TOC entry 2668 (class 2606 OID 17193)
-- Name: arp_artidx; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY areceber_parcial
    ADD CONSTRAINT arp_artidx FOREIGN KEY (arp_artid) REFERENCES areceber_total(art_id);


--
-- TOC entry 2669 (class 2606 OID 17198)
-- Name: fk_af_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY caixa
    ADD CONSTRAINT fk_af_id FOREIGN KEY (cx_af_id) REFERENCES abrir_fechar(af_id);


--
-- TOC entry 2674 (class 2606 OID 17203)
-- Name: idusuario; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY usuariotelas
    ADD CONSTRAINT idusuario FOREIGN KEY (tl_idusuario) REFERENCES usuario(u_id);


--
-- TOC entry 2670 (class 2606 OID 17208)
-- Name: inpi_inpid; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY infonutri_pessoa_itens
    ADD CONSTRAINT inpi_inpid FOREIGN KEY (inp_id) REFERENCES infonutri_pessoa(inp_id);


--
-- TOC entry 2671 (class 2606 OID 17213)
-- Name: psidfkproduto; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY produtoservico
    ADD CONSTRAINT psidfkproduto FOREIGN KEY (psidproduto) REFERENCES produto(pid);


--
-- TOC entry 2672 (class 2606 OID 17218)
-- Name: psidfkserv; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY produtoservico
    ADD CONSTRAINT psidfkserv FOREIGN KEY (psidservico) REFERENCES servicos(sid);


--
-- TOC entry 2673 (class 2606 OID 17223)
-- Name: sbp_gpidx; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY subgrupo_desp_m
    ADD CONSTRAINT sbp_gpidx FOREIGN KEY (sgp_gpid) REFERENCES grupo_desp_m(gp_id);


--
-- TOC entry 2675 (class 2606 OID 17228)
-- Name: vs_idx; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY venda_servico_itens
    ADD CONSTRAINT vs_idx FOREIGN KEY (vs_id) REFERENCES venda_servico(vsid);


--
-- TOC entry 2686 (class 0 OID 0)
-- Dependencies: 6
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2021-08-26 12:11:53

--
-- PostgreSQL database dump complete
--

