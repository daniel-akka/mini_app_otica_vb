--
-- PostgreSQL database dump
--

-- Dumped from database version 9.2.4
-- Dumped by pg_dump version 9.2.4
-- Started on 2021-06-12 09:20:49

SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 174 (class 1259 OID 57540)
-- Name: configuracoes; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE configuracoes (
    idconfg bigint NOT NULL,
    limite_desconto real DEFAULT 1 NOT NULL,
    senha_padrao character varying DEFAULT 1 NOT NULL
);


ALTER TABLE public.configuracoes OWNER TO postgres;

--
-- TOC entry 175 (class 1259 OID 57548)
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
-- TOC entry 1977 (class 0 OID 0)
-- Dependencies: 175
-- Name: configuracoes_idconfg_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE configuracoes_idconfg_seq OWNED BY configuracoes.idconfg;


--
-- TOC entry 1970 (class 2604 OID 57628)
-- Name: idconfg; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY configuracoes ALTER COLUMN idconfg SET DEFAULT nextval('configuracoes_idconfg_seq'::regclass);


--
-- TOC entry 1972 (class 2606 OID 57639)
-- Name: idxconfig; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY configuracoes
    ADD CONSTRAINT idxconfig PRIMARY KEY (idconfg);


-- Completed on 2021-06-12 09:20:50

--
-- PostgreSQL database dump complete
--

