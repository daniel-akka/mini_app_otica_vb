--
-- PostgreSQL database dump
--

-- Dumped from database version 9.2.4
-- Dumped by pg_dump version 9.2.4
-- Started on 2021-06-12 09:20:09

SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 168 (class 1259 OID 57507)
-- Name: abrir_fechar; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE abrir_fechar (
    af_id bigint NOT NULL,
    af_datahora timestamp without time zone DEFAULT now() NOT NULL,
    af_tipo character varying(1) DEFAULT 'A'::character varying NOT NULL,
    af_concluido boolean DEFAULT false NOT NULL,
    af_total_dinheiro real DEFAULT 0.00 NOT NULL,
    af_total_cartao real DEFAULT 0.00 NOT NULL,
    af_id_abertura bigint DEFAULT 0 NOT NULL,
    af_total_apurado_dn real DEFAULT 0.00 NOT NULL,
    af_total_apurado_ct real DEFAULT 0.00 NOT NULL
);


ALTER TABLE public.abrir_fechar OWNER TO postgres;

--
-- TOC entry 1983 (class 0 OID 0)
-- Dependencies: 168
-- Name: COLUMN abrir_fechar.af_tipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN abrir_fechar.af_tipo IS 'A=Abertura
F=Fechamento';


--
-- TOC entry 169 (class 1259 OID 57518)
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
-- TOC entry 1984 (class 0 OID 0)
-- Dependencies: 169
-- Name: abrir_fechar_af_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE abrir_fechar_af_id_seq OWNED BY abrir_fechar.af_id;


--
-- TOC entry 1976 (class 2604 OID 57625)
-- Name: af_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY abrir_fechar ALTER COLUMN af_id SET DEFAULT nextval('abrir_fechar_af_id_seq'::regclass);


--
-- TOC entry 1978 (class 2606 OID 57635)
-- Name: af_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY abrir_fechar
    ADD CONSTRAINT af_idx PRIMARY KEY (af_id);


-- Completed on 2021-06-12 09:20:09

--
-- PostgreSQL database dump complete
--

