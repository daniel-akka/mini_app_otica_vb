--
-- PostgreSQL database dump
--

-- Dumped from database version 9.2.4
-- Dumped by pg_dump version 9.2.4
-- Started on 2021-06-13 17:02:35

SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 210 (class 3079 OID 11727)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2198 (class 0 OID 0)
-- Dependencies: 210
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

--
-- TOC entry 225 (class 1255 OID 57661)
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
-- TOC entry 226 (class 1255 OID 57664)
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
-- TOC entry 223 (class 1255 OID 24822)
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
-- TOC entry 224 (class 1255 OID 24823)
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
-- TOC entry 168 (class 1259 OID 24824)
-- Name: abrir_fechar; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE abrir_fechar (
    af_id bigint NOT NULL,
    af_datahora timestamp without time zone DEFAULT now() NOT NULL,
    af_tipo character varying(1) DEFAULT 'A'::character varying NOT NULL,
    af_concluido boolean DEFAULT false NOT NULL,
    af_total_dinheiro real DEFAULT 0.00 NOT NULL,
    af_total_cartao real DEFAULT 0.00 NOT NULL,
    af_id_abertura bigint DEFAULT 0 NOT NULL
);


ALTER TABLE public.abrir_fechar OWNER TO postgres;

--
-- TOC entry 2199 (class 0 OID 0)
-- Dependencies: 168
-- Name: COLUMN abrir_fechar.af_tipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN abrir_fechar.af_tipo IS 'A=Abertura
F=Fechamento';


--
-- TOC entry 169 (class 1259 OID 24833)
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
-- TOC entry 2200 (class 0 OID 0)
-- Dependencies: 169
-- Name: abrir_fechar_af_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE abrir_fechar_af_id_seq OWNED BY abrir_fechar.af_id;


--
-- TOC entry 170 (class 1259 OID 24835)
-- Name: atendente; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE atendente (
    aid bigint NOT NULL,
    anome character varying DEFAULT 'teste'::character varying NOT NULL
);


ALTER TABLE public.atendente OWNER TO postgres;

--
-- TOC entry 171 (class 1259 OID 24842)
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
-- TOC entry 2201 (class 0 OID 0)
-- Dependencies: 171
-- Name: atendente_aid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE atendente_aid_seq OWNED BY atendente.aid;


--
-- TOC entry 207 (class 1259 OID 57668)
-- Name: bairro; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE bairro (
    bid bigint NOT NULL,
    bnome character varying NOT NULL
);


ALTER TABLE public.bairro OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 57666)
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
-- TOC entry 2202 (class 0 OID 0)
-- Dependencies: 206
-- Name: bairro_bid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE bairro_bid_seq OWNED BY bairro.bid;


--
-- TOC entry 197 (class 1259 OID 32779)
-- Name: estados; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE estados (
    id bigint NOT NULL,
    codestado smallint NOT NULL,
    sigla character varying(2) NOT NULL,
    nome character varying(30) NOT NULL,
    codpais smallint DEFAULT 55 NOT NULL
);


ALTER TABLE public.estados OWNER TO postgres;

--
-- TOC entry 2203 (class 0 OID 0)
-- Dependencies: 197
-- Name: COLUMN estados.codpais; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN estados.codpais IS '55 = codigo do brasil';


--
-- TOC entry 198 (class 1259 OID 32783)
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
-- TOC entry 2204 (class 0 OID 0)
-- Dependencies: 198
-- Name: cadestado_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE cadestado_id_seq OWNED BY estados.id;


--
-- TOC entry 199 (class 1259 OID 32788)
-- Name: cidades; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE cidades (
    id bigint NOT NULL,
    id_estado smallint NOT NULL,
    sigla_estado character varying(2) NOT NULL,
    cod_estado smallint NOT NULL,
    codigo integer NOT NULL,
    nome character varying(60) NOT NULL
);


ALTER TABLE public.cidades OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 32791)
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
-- TOC entry 2205 (class 0 OID 0)
-- Dependencies: 200
-- Name: cadmun_id_estado_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE cadmun_id_estado_seq OWNED BY cidades.id_estado;


--
-- TOC entry 201 (class 1259 OID 32793)
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
-- TOC entry 2206 (class 0 OID 0)
-- Dependencies: 201
-- Name: cadmun_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE cadmun_id_seq OWNED BY cidades.id;


--
-- TOC entry 172 (class 1259 OID 24844)
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
-- TOC entry 2207 (class 0 OID 0)
-- Dependencies: 172
-- Name: COLUMN caixa.cx_tipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN caixa.cx_tipo IS 'S=Saida
E=Entrada
T=Troco
';


--
-- TOC entry 2208 (class 0 OID 0)
-- Dependencies: 172
-- Name: COLUMN caixa.cx_tipo_valor; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN caixa.cx_tipo_valor IS 'CT=CARTAO
DN=DINHEIRO';


--
-- TOC entry 173 (class 1259 OID 24853)
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
-- TOC entry 2209 (class 0 OID 0)
-- Dependencies: 173
-- Name: caixa_cx_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE caixa_cx_id_seq OWNED BY caixa.cx_id;


--
-- TOC entry 174 (class 1259 OID 24855)
-- Name: configuracoes; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE configuracoes (
    idconfg bigint NOT NULL,
    limite_desconto real DEFAULT 1 NOT NULL,
    senha_padrao character varying DEFAULT 1 NOT NULL
);


ALTER TABLE public.configuracoes OWNER TO postgres;

--
-- TOC entry 175 (class 1259 OID 24863)
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
-- TOC entry 2210 (class 0 OID 0)
-- Dependencies: 175
-- Name: configuracoes_idconfg_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE configuracoes_idconfg_seq OWNED BY configuracoes.idconfg;


--
-- TOC entry 176 (class 1259 OID 24865)
-- Name: desp_produto; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE desp_produto (
    dpid bigint NOT NULL,
    dpdescricao character varying DEFAULT 'despesa'::character varying NOT NULL,
    dpporcentagem real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.desp_produto OWNER TO postgres;

--
-- TOC entry 177 (class 1259 OID 24873)
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
-- TOC entry 2211 (class 0 OID 0)
-- Dependencies: 177
-- Name: desp_produto_dpid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE desp_produto_dpid_seq OWNED BY desp_produto.dpid;


--
-- TOC entry 205 (class 1259 OID 49154)
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
-- TOC entry 2212 (class 0 OID 0)
-- Dependencies: 205
-- Name: COLUMN entrada_saida.estipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN entrada_saida.estipo IS 'E-Entrada
S-Saida';


--
-- TOC entry 204 (class 1259 OID 49152)
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
-- TOC entry 2213 (class 0 OID 0)
-- Dependencies: 204
-- Name: entrada_saida_esid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE entrada_saida_esid_seq OWNED BY entrada_saida.esid;


--
-- TOC entry 178 (class 1259 OID 24875)
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
-- TOC entry 179 (class 1259 OID 24885)
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
-- TOC entry 2214 (class 0 OID 0)
-- Dependencies: 179
-- Name: fornecedor_fid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE fornecedor_fid_seq OWNED BY fornecedor.fid;


--
-- TOC entry 180 (class 1259 OID 24887)
-- Name: locacoes_canceladas; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE locacoes_canceladas (
    lc_id bigint NOT NULL,
    lc_atendente_id smallint DEFAULT 0 NOT NULL,
    lc_atendente_nome character varying,
    lc_produto_id smallint DEFAULT 0 NOT NULL,
    lc_produto_nome character varying,
    lc_tempo_programado real DEFAULT 1 NOT NULL,
    lc_tempo_inicial time without time zone NOT NULL,
    lc_tempo_final time without time zone NOT NULL,
    lc_valor_tempo real DEFAULT 1 NOT NULL,
    lc_valor_tempo_excedido real DEFAULT 0 NOT NULL,
    lc_valor_tempo_total real DEFAULT 0 NOT NULL,
    lc_finalizado boolean DEFAULT false NOT NULL,
    lc_data date DEFAULT ('now'::text)::date NOT NULL,
    lc_tempo_acumulado character varying(5) DEFAULT '00:00'::character varying NOT NULL,
    lc_tempo_excedido character varying(8) DEFAULT '00:00:00'::character varying NOT NULL,
    lc_desconto real DEFAULT 0 NOT NULL,
    lc_valor_total_desconto real DEFAULT 0.00 NOT NULL,
    lc_justificativa character varying(200)
);


ALTER TABLE public.locacoes_canceladas OWNER TO postgres;

--
-- TOC entry 181 (class 1259 OID 24905)
-- Name: locacao_cancelada_lc_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE locacao_cancelada_lc_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.locacao_cancelada_lc_id_seq OWNER TO postgres;

--
-- TOC entry 2215 (class 0 OID 0)
-- Dependencies: 181
-- Name: locacao_cancelada_lc_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE locacao_cancelada_lc_id_seq OWNED BY locacoes_canceladas.lc_id;


--
-- TOC entry 182 (class 1259 OID 24907)
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
-- TOC entry 2216 (class 0 OID 0)
-- Dependencies: 182
-- Name: COLUMN movimentacao.m_tp_pagamento1; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN movimentacao.m_tp_pagamento1 IS 'DN-Dinheiro
CT-Cartao';


--
-- TOC entry 2217 (class 0 OID 0)
-- Dependencies: 182
-- Name: COLUMN movimentacao.m_tp_pagamento2; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN movimentacao.m_tp_pagamento2 IS 'DN-Dinheiro
CT-Cartao';


--
-- TOC entry 183 (class 1259 OID 24930)
-- Name: locacoes_do_caixa; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW locacoes_do_caixa AS
    SELECT m.m_produto_nome, m.m_datafinalizacao, m.m_valor_total_desconto, m.m_tp_pagamento1, m.m_vlr_tp_pagamento1, m.m_tp_pagamento2, m.m_vlr_tp_pagamento2 FROM movimentacao m WHERE ((m.m_finalizado = true) AND (m.m_datafinalizacao >= (SELECT af2.af_datahora FROM abrir_fechar af2 WHERE (((af2.af_tipo)::text = 'A'::text) AND (af2.af_concluido = false)) LIMIT 1)));


ALTER TABLE public.locacoes_do_caixa OWNER TO postgres;

--
-- TOC entry 184 (class 1259 OID 24934)
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
-- TOC entry 2218 (class 0 OID 0)
-- Dependencies: 184
-- Name: movimentacao_m_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE movimentacao_m_id_seq OWNED BY movimentacao.m_id;


--
-- TOC entry 203 (class 1259 OID 40962)
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
-- TOC entry 2219 (class 0 OID 0)
-- Dependencies: 203
-- Name: COLUMN movimentacao_prod.mptipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN movimentacao_prod.mptipo IS 'E - Entrada
S - Saida';


--
-- TOC entry 202 (class 1259 OID 40960)
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
-- TOC entry 2220 (class 0 OID 0)
-- Dependencies: 202
-- Name: movimentacao_prod_mpid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE movimentacao_prod_mpid_seq OWNED BY movimentacao_prod.mpid;


--
-- TOC entry 196 (class 1259 OID 32770)
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
-- TOC entry 195 (class 1259 OID 32768)
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
-- TOC entry 2221 (class 0 OID 0)
-- Dependencies: 195
-- Name: padrao_sistema_psid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE padrao_sistema_psid_seq OWNED BY padrao_sistema.psid;


--
-- TOC entry 185 (class 1259 OID 24936)
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
-- TOC entry 186 (class 1259 OID 24944)
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
-- TOC entry 2222 (class 0 OID 0)
-- Dependencies: 186
-- Name: prod_fornecedor_pfid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE prod_fornecedor_pfid_seq OWNED BY prod_fornecedor.pfid;


--
-- TOC entry 187 (class 1259 OID 24946)
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
    pdespadicional real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.produto OWNER TO postgres;

--
-- TOC entry 188 (class 1259 OID 24958)
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
-- TOC entry 2223 (class 0 OID 0)
-- Dependencies: 188
-- Name: produto_pid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE produto_pid_seq OWNED BY produto.pid;


--
-- TOC entry 209 (class 1259 OID 57679)
-- Name: rua; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE rua (
    rid bigint NOT NULL,
    rnome character varying NOT NULL
);


ALTER TABLE public.rua OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 57677)
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
-- TOC entry 2224 (class 0 OID 0)
-- Dependencies: 208
-- Name: rua_rid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE rua_rid_seq OWNED BY rua.rid;


--
-- TOC entry 189 (class 1259 OID 24960)
-- Name: tempo; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE tempo (
    tid bigint NOT NULL,
    tminutos smallint DEFAULT 1 NOT NULL,
    tvalor real DEFAULT 1 NOT NULL
);


ALTER TABLE public.tempo OWNER TO postgres;

--
-- TOC entry 190 (class 1259 OID 24965)
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
-- TOC entry 2225 (class 0 OID 0)
-- Dependencies: 190
-- Name: tempo_tid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tempo_tid_seq OWNED BY tempo.tid;


--
-- TOC entry 191 (class 1259 OID 24967)
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
-- TOC entry 192 (class 1259 OID 24973)
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
-- TOC entry 2226 (class 0 OID 0)
-- Dependencies: 192
-- Name: termo_tr_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE termo_tr_id_seq OWNED BY termo.tr_id;


--
-- TOC entry 193 (class 1259 OID 24975)
-- Name: unidade; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE unidade (
    uid bigint NOT NULL,
    udescricao character varying(5) DEFAULT 'UN'::character varying NOT NULL
);


ALTER TABLE public.unidade OWNER TO postgres;

--
-- TOC entry 194 (class 1259 OID 24979)
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
-- TOC entry 2227 (class 0 OID 0)
-- Dependencies: 194
-- Name: unidade_uid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE unidade_uid_seq OWNED BY unidade.uid;


--
-- TOC entry 2062 (class 2604 OID 24981)
-- Name: af_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY abrir_fechar ALTER COLUMN af_id SET DEFAULT nextval('abrir_fechar_af_id_seq'::regclass);


--
-- TOC entry 2064 (class 2604 OID 24982)
-- Name: aid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY atendente ALTER COLUMN aid SET DEFAULT nextval('atendente_aid_seq'::regclass);


--
-- TOC entry 2144 (class 2604 OID 57671)
-- Name: bid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bairro ALTER COLUMN bid SET DEFAULT nextval('bairro_bid_seq'::regclass);


--
-- TOC entry 2068 (class 2604 OID 24983)
-- Name: cx_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY caixa ALTER COLUMN cx_id SET DEFAULT nextval('caixa_cx_id_seq'::regclass);


--
-- TOC entry 2131 (class 2604 OID 32795)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY cidades ALTER COLUMN id SET DEFAULT nextval('cadmun_id_seq'::regclass);


--
-- TOC entry 2132 (class 2604 OID 32796)
-- Name: id_estado; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY cidades ALTER COLUMN id_estado SET DEFAULT nextval('cadmun_id_estado_seq'::regclass);


--
-- TOC entry 2071 (class 2604 OID 24984)
-- Name: idconfg; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY configuracoes ALTER COLUMN idconfg SET DEFAULT nextval('configuracoes_idconfg_seq'::regclass);


--
-- TOC entry 2074 (class 2604 OID 24985)
-- Name: dpid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY desp_produto ALTER COLUMN dpid SET DEFAULT nextval('desp_produto_dpid_seq'::regclass);


--
-- TOC entry 2136 (class 2604 OID 49157)
-- Name: esid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY entrada_saida ALTER COLUMN esid SET DEFAULT nextval('entrada_saida_esid_seq'::regclass);


--
-- TOC entry 2130 (class 2604 OID 32785)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY estados ALTER COLUMN id SET DEFAULT nextval('cadestado_id_seq'::regclass);


--
-- TOC entry 2079 (class 2604 OID 24986)
-- Name: fid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY fornecedor ALTER COLUMN fid SET DEFAULT nextval('fornecedor_fid_seq'::regclass);


--
-- TOC entry 2092 (class 2604 OID 24987)
-- Name: lc_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY locacoes_canceladas ALTER COLUMN lc_id SET DEFAULT nextval('locacao_cancelada_lc_id_seq'::regclass);


--
-- TOC entry 2110 (class 2604 OID 24988)
-- Name: m_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY movimentacao ALTER COLUMN m_id SET DEFAULT nextval('movimentacao_m_id_seq'::regclass);


--
-- TOC entry 2133 (class 2604 OID 40965)
-- Name: mpid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY movimentacao_prod ALTER COLUMN mpid SET DEFAULT nextval('movimentacao_prod_mpid_seq'::regclass);


--
-- TOC entry 2128 (class 2604 OID 32773)
-- Name: psid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY padrao_sistema ALTER COLUMN psid SET DEFAULT nextval('padrao_sistema_psid_seq'::regclass);


--
-- TOC entry 2113 (class 2604 OID 24989)
-- Name: pfid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY prod_fornecedor ALTER COLUMN pfid SET DEFAULT nextval('prod_fornecedor_pfid_seq'::regclass);


--
-- TOC entry 2120 (class 2604 OID 24990)
-- Name: pid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY produto ALTER COLUMN pid SET DEFAULT nextval('produto_pid_seq'::regclass);


--
-- TOC entry 2145 (class 2604 OID 57682)
-- Name: rid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY rua ALTER COLUMN rid SET DEFAULT nextval('rua_rid_seq'::regclass);


--
-- TOC entry 2124 (class 2604 OID 24991)
-- Name: tid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tempo ALTER COLUMN tid SET DEFAULT nextval('tempo_tid_seq'::regclass);


--
-- TOC entry 2125 (class 2604 OID 24992)
-- Name: tr_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY termo ALTER COLUMN tr_id SET DEFAULT nextval('termo_tr_id_seq'::regclass);


--
-- TOC entry 2127 (class 2604 OID 24993)
-- Name: uid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY unidade ALTER COLUMN uid SET DEFAULT nextval('unidade_uid_seq'::regclass);


--
-- TOC entry 2147 (class 2606 OID 24995)
-- Name: af_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY abrir_fechar
    ADD CONSTRAINT af_idx PRIMARY KEY (af_id);


--
-- TOC entry 2183 (class 2606 OID 57676)
-- Name: bidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY bairro
    ADD CONSTRAINT bidx PRIMARY KEY (bid);


--
-- TOC entry 2151 (class 2606 OID 24997)
-- Name: cx_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY caixa
    ADD CONSTRAINT cx_idx PRIMARY KEY (cx_id);


--
-- TOC entry 2155 (class 2606 OID 24999)
-- Name: dp_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY desp_produto
    ADD CONSTRAINT dp_id PRIMARY KEY (dpid);


--
-- TOC entry 2181 (class 2606 OID 49160)
-- Name: esidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY entrada_saida
    ADD CONSTRAINT esidx PRIMARY KEY (esid);


--
-- TOC entry 2157 (class 2606 OID 25001)
-- Name: f_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY fornecedor
    ADD CONSTRAINT f_id PRIMARY KEY (fid);


--
-- TOC entry 2175 (class 2606 OID 32787)
-- Name: id_estado; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY estados
    ADD CONSTRAINT id_estado PRIMARY KEY (id);


--
-- TOC entry 2177 (class 2606 OID 32798)
-- Name: id_mun; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY cidades
    ADD CONSTRAINT id_mun PRIMARY KEY (id);


--
-- TOC entry 2153 (class 2606 OID 25003)
-- Name: idxconfig; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY configuracoes
    ADD CONSTRAINT idxconfig PRIMARY KEY (idconfg);


--
-- TOC entry 2163 (class 2606 OID 25005)
-- Name: pf_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY prod_fornecedor
    ADD CONSTRAINT pf_id PRIMARY KEY (pfid);


--
-- TOC entry 2173 (class 2606 OID 32778)
-- Name: pfidx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY padrao_sistema
    ADD CONSTRAINT pfidx PRIMARY KEY (psid);


--
-- TOC entry 2185 (class 2606 OID 57687)
-- Name: ridx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY rua
    ADD CONSTRAINT ridx PRIMARY KEY (rid);


--
-- TOC entry 2171 (class 2606 OID 25007)
-- Name: u_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY unidade
    ADD CONSTRAINT u_id PRIMARY KEY (uid);


--
-- TOC entry 2149 (class 2606 OID 25009)
-- Name: xa_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY atendente
    ADD CONSTRAINT xa_id PRIMARY KEY (aid);


--
-- TOC entry 2159 (class 2606 OID 25011)
-- Name: xlc_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY locacoes_canceladas
    ADD CONSTRAINT xlc_id PRIMARY KEY (lc_id);


--
-- TOC entry 2161 (class 2606 OID 25013)
-- Name: xm_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY movimentacao
    ADD CONSTRAINT xm_id PRIMARY KEY (m_id);


--
-- TOC entry 2179 (class 2606 OID 40972)
-- Name: xmpid; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY movimentacao_prod
    ADD CONSTRAINT xmpid PRIMARY KEY (mpid);


--
-- TOC entry 2165 (class 2606 OID 25015)
-- Name: xpid; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY produto
    ADD CONSTRAINT xpid PRIMARY KEY (pid);


--
-- TOC entry 2167 (class 2606 OID 25017)
-- Name: xt_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY tempo
    ADD CONSTRAINT xt_id PRIMARY KEY (tid);


--
-- TOC entry 2169 (class 2606 OID 25019)
-- Name: xtr_id; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY termo
    ADD CONSTRAINT xtr_id PRIMARY KEY (tr_id);


--
-- TOC entry 2189 (class 2620 OID 57662)
-- Name: dispara_func_altera_estoque; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER dispara_func_altera_estoque AFTER INSERT ON entrada_saida FOR EACH ROW EXECUTE PROCEDURE altera_estoque_produto();


--
-- TOC entry 2190 (class 2620 OID 57665)
-- Name: dispara_func_altera_estoque_del; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER dispara_func_altera_estoque_del AFTER DELETE ON entrada_saida FOR EACH ROW EXECUTE PROCEDURE altera_estoque_produto_del();


--
-- TOC entry 2187 (class 2620 OID 25020)
-- Name: muda_finalizacao_locacao; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER muda_finalizacao_locacao AFTER UPDATE ON movimentacao FOR EACH ROW EXECUTE PROCEDURE atualiza_data_finalizacao_locacao();


--
-- TOC entry 2188 (class 2620 OID 25021)
-- Name: trigger_insert_locacao_cancelada; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trigger_insert_locacao_cancelada AFTER DELETE ON movimentacao FOR EACH ROW EXECUTE PROCEDURE insert_locacao_cancelada();


--
-- TOC entry 2186 (class 2606 OID 25022)
-- Name: fk_af_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY caixa
    ADD CONSTRAINT fk_af_id FOREIGN KEY (cx_af_id) REFERENCES abrir_fechar(af_id);


--
-- TOC entry 2197 (class 0 OID 0)
-- Dependencies: 6
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2021-06-13 17:02:35

--
-- PostgreSQL database dump complete
--

