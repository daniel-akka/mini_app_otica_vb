--
-- PostgreSQL database dump
--

-- Dumped from database version 9.2.4
-- Dumped by pg_dump version 9.2.4
-- Started on 2021-06-12 09:20:29

SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 172 (class 1259 OID 57529)
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
-- TOC entry 1979 (class 0 OID 0)
-- Dependencies: 172
-- Name: COLUMN caixa.cx_tipo; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN caixa.cx_tipo IS 'S=Saida
E=Entrada
T=Troco
';


--
-- TOC entry 1980 (class 0 OID 0)
-- Dependencies: 172
-- Name: COLUMN caixa.cx_tipo_valor; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN caixa.cx_tipo_valor IS 'CT=CARTAO
DN=DINHEIRO';


--
-- TOC entry 173 (class 1259 OID 57538)
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
-- TOC entry 1981 (class 0 OID 0)
-- Dependencies: 173
-- Name: caixa_cx_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE caixa_cx_id_seq OWNED BY caixa.cx_id;


--
-- TOC entry 1971 (class 2604 OID 57627)
-- Name: cx_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY caixa ALTER COLUMN cx_id SET DEFAULT nextval('caixa_cx_id_seq'::regclass);


--
-- TOC entry 1973 (class 2606 OID 57637)
-- Name: cx_idx; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY caixa
    ADD CONSTRAINT cx_idx PRIMARY KEY (cx_id);


--
-- TOC entry 1974 (class 2606 OID 57654)
-- Name: fk_af_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY caixa
    ADD CONSTRAINT fk_af_id FOREIGN KEY (cx_af_id) REFERENCES abrir_fechar(af_id);


-- Completed on 2021-06-12 09:20:29

--
-- PostgreSQL database dump complete
--

