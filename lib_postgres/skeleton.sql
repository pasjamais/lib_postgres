--
-- PostgreSQL database dump
--

-- Dumped from database version 15.1
-- Dumped by pg_dump version 15.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: city; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.city (
    id bigint NOT NULL,
    name character varying(100) NOT NULL,
    _is_deleted boolean
);


ALTER TABLE public.city OWNER TO postgres;

--
-- Name: City_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."City_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."City_id_seq" OWNER TO postgres;

--
-- Name: City_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."City_id_seq" OWNED BY public.city.id;


--
-- Name: action; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.action (
    id bigint NOT NULL,
    name character varying(100),
    date date DEFAULT CURRENT_DATE,
    comment character varying(100),
    place bigint,
    action_type bigint,
    _is_deleted boolean
);


ALTER TABLE public.action OWNER TO postgres;

--
-- Name: action_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.action_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.action_id_seq OWNER TO postgres;

--
-- Name: action_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.action_id_seq OWNED BY public.action.id;


--
-- Name: action_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.action_type (
    id bigint NOT NULL,
    name character varying(100) NOT NULL,
    _is_deleted boolean,
    operation boolean
);


ALTER TABLE public.action_type OWNER TO postgres;

--
-- Name: action_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.action_type_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.action_type_id_seq OWNER TO postgres;

--
-- Name: action_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.action_type_id_seq OWNED BY public.action_type.id;


--
-- Name: art; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.art (
    id bigint NOT NULL,
    name character varying(100) NOT NULL,
    genre bigint,
    writing_year date,
    orig_language bigint,
    _is_deleted boolean
);


ALTER TABLE public.art OWNER TO postgres;

--
-- Name: art_genre_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.art_genre_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.art_genre_seq OWNER TO postgres;

--
-- Name: art_genre_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.art_genre_seq OWNED BY public.art.genre;


--
-- Name: art_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.art_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.art_id_seq OWNER TO postgres;

--
-- Name: art_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.art_id_seq OWNED BY public.art.id;


--
-- Name: art_orig_language_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.art_orig_language_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.art_orig_language_seq OWNER TO postgres;

--
-- Name: art_orig_language_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.art_orig_language_seq OWNED BY public.art.orig_language;


--
-- Name: art_read; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.art_read (
    id bigint NOT NULL,
    art_id bigint NOT NULL,
    date date,
    comment character varying(255),
    book_id bigint,
    mark_id bigint,
    book_format_id bigint,
    _is_deleted boolean,
    read_language_id bigint
);


ALTER TABLE public.art_read OWNER TO postgres;

--
-- Name: art_read_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.art_read ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.art_read_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: art_spec_register; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.art_spec_register (
    id bigint NOT NULL,
    art_id bigint,
    spec_register_attribute_id bigint,
    comment "char",
    date date,
    _is_deleted boolean
);


ALTER TABLE public.art_spec_register OWNER TO postgres;

--
-- Name: art_spec_register_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.art_spec_register ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.art_spec_register_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: art_to_read; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.art_to_read (
    id bigint NOT NULL,
    date date,
    source_art_id bigint,
    source_author_id bigint,
    source_another_id bigint,
    toread_art_id bigint,
    toread_author_id bigint,
    comment character varying,
    _is_deleted boolean
);


ALTER TABLE public.art_to_read OWNER TO postgres;

--
-- Name: art_to_read_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.art_to_read ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.art_to_read_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: author; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.author (
    id bigint NOT NULL,
    name character varying(100) NOT NULL,
    _is_deleted boolean
);


ALTER TABLE public.author OWNER TO postgres;

--
-- Name: author_art; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.author_art (
    id bigint NOT NULL,
    author bigint,
    art bigint,
    _is_deleted boolean
);


ALTER TABLE public.author_art OWNER TO postgres;

--
-- Name: author_art_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.author_art_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.author_art_id_seq OWNER TO postgres;

--
-- Name: author_art_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.author_art_id_seq OWNED BY public.author_art.id;


--
-- Name: author_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.author_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.author_id_seq OWNER TO postgres;

--
-- Name: author_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.author_id_seq OWNED BY public.author.id;


--
-- Name: book; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.book (
    id bigint NOT NULL,
    id_art bigint NOT NULL,
    publication_year date,
    id_publishing_house bigint,
    id_language bigint,
    id_city bigint,
    pages integer,
    id_series bigint,
    code character varying(100),
    has_jacket boolean,
    comment text,
    notes text,
    state integer,
    family_notes text,
    is_art_book boolean,
    _is_deleted boolean
);


ALTER TABLE public.book OWNER TO postgres;

--
-- Name: book_format; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.book_format (
    id bigint NOT NULL,
    name character varying(30),
    _is_deleted boolean
);


ALTER TABLE public.book_format OWNER TO postgres;

--
-- Name: book_format_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.book_format ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.book_format_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: book_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.book_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.book_id_seq OWNER TO postgres;

--
-- Name: book_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.book_id_seq OWNED BY public.book.id;


--
-- Name: chifres_names; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.chifres_names (
    id bigint NOT NULL,
    id_genre bigint NOT NULL,
    chifre bit varying,
    _is_deleted boolean
);


ALTER TABLE public.chifres_names OWNER TO postgres;

--
-- Name: chifres_names_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.chifres_names_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.chifres_names_id_seq OWNER TO postgres;

--
-- Name: chifres_names_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.chifres_names_id_seq OWNED BY public.chifres_names.id;


--
-- Name: genre; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.genre (
    id bigint NOT NULL,
    name character varying(100) NOT NULL,
    _is_deleted boolean
);


ALTER TABLE public.genre OWNER TO postgres;

--
-- Name: genre_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.genre_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.genre_id_seq OWNER TO postgres;

--
-- Name: genre_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.genre_id_seq OWNED BY public.genre.id;


--
-- Name: language; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.language (
    id bigint NOT NULL,
    name character varying,
    bref character varying(5),
    _is_deleted boolean
);


ALTER TABLE public.language OWNER TO postgres;

--
-- Name: language_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.language_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.language_id_seq OWNER TO postgres;

--
-- Name: language_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.language_id_seq OWNED BY public.language.id;


--
-- Name: location; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.location (
    id bigint NOT NULL,
    operation boolean,
    book bigint,
    place bigint,
    owner bigint,
    comment character varying(100),
    action bigint,
    _is_deleted boolean
);


ALTER TABLE public.location OWNER TO postgres;

--
-- Name: mark; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.mark (
    id bigint NOT NULL,
    name character varying(30) NOT NULL,
    _is_deleted boolean
);


ALTER TABLE public.mark OWNER TO postgres;

--
-- Name: mark_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.mark ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.mark_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: people; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.people (
    id bigint NOT NULL,
    name character varying(100) NOT NULL,
    _is_deleted boolean
);


ALTER TABLE public.people OWNER TO postgres;

--
-- Name: people_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.people_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.people_id_seq OWNER TO postgres;

--
-- Name: people_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.people_id_seq OWNED BY public.people.id;


--
-- Name: place; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.place (
    id bigint NOT NULL,
    name character varying(100) NOT NULL,
    comment character varying(100),
    _is_deleted boolean
);


ALTER TABLE public.place OWNER TO postgres;

--
-- Name: place_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.place_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.place_id_seq OWNER TO postgres;

--
-- Name: place_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.place_id_seq OWNED BY public.place.id;


--
-- Name: possession; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.possession (
    id bigint NOT NULL,
    date date,
    comment character varying(100),
    book bigint NOT NULL,
    person bigint,
    action bigint,
    _is_deleted boolean
);


ALTER TABLE public.possession OWNER TO postgres;

--
-- Name: possession_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.possession_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.possession_id_seq OWNER TO postgres;

--
-- Name: possession_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.possession_id_seq OWNED BY public.possession.id;


--
-- Name: publishing_house; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.publishing_house (
    id bigint NOT NULL,
    name character varying(100),
    _is_deleted boolean
);


ALTER TABLE public.publishing_house OWNER TO postgres;

--
-- Name: publishing_house_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.publishing_house_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.publishing_house_id_seq OWNER TO postgres;

--
-- Name: publishing_house_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.publishing_house_id_seq OWNED BY public.publishing_house.id;


--
-- Name: query; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.query (
    id bigint NOT NULL,
    name character varying(100),
    text text,
    _is_deleted boolean
);


ALTER TABLE public.query OWNER TO postgres;

--
-- Name: query_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.query ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.query_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: registration_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.registration_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.registration_id_seq OWNER TO postgres;

--
-- Name: registration_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.registration_id_seq OWNED BY public.location.id;


--
-- Name: series; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.series (
    id bigint NOT NULL,
    name character varying(100),
    _is_deleted boolean
);


ALTER TABLE public.series OWNER TO postgres;

--
-- Name: series_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.series_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.series_id_seq OWNER TO postgres;

--
-- Name: series_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.series_id_seq OWNED BY public.series.id;


--
-- Name: source_toread_another; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.source_toread_another (
    id bigint NOT NULL,
    name character varying,
    comment character varying,
    _is_deleted boolean
);


ALTER TABLE public.source_toread_another OWNER TO postgres;

--
-- Name: source_toread_another_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.source_toread_another ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.source_toread_another_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: spec_register_attribute; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.spec_register_attribute (
    id bigint NOT NULL,
    name character varying,
    comment character varying,
    _is_deleted boolean
);


ALTER TABLE public.spec_register_attribute OWNER TO postgres;

--
-- Name: spec_register_attribute_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.spec_register_attribute ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.spec_register_attribute_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- Name: view_actions; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_actions AS
 SELECT action.id AS action_id,
    action.date,
    action.comment,
    place.name AS place
   FROM ((public.action
     LEFT JOIN public.action_type ON ((action.action_type = action_type.id)))
     LEFT JOIN public.place ON ((action.place = place.id)))
  ORDER BY action.date;


ALTER TABLE public.view_actions OWNER TO postgres;

--
-- Name: view_all_real_books; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_all_real_books AS
 SELECT unique_book.unique_book_id,
    place.name AS "Место",
    action.comment AS "Движ.",
    action_type.name AS "Действие",
    unique_book.date AS "Дата",
    t_art.art_name AS "Название",
    book_authors.authors_names AS "Автор(ы)",
    t_art.genre_name AS "Жанр",
    t_art.orig_language AS "Язык написания",
    language.name AS "Язык издания",
    EXTRACT(year FROM unique_book.publication_year) AS "Год издания",
    publishing_house.name AS "Издательство",
    unique_book.code AS "Шифр",
    unique_book.pages AS "Страниц"
   FROM (((((((( SELECT DISTINCT ON (book.id) book.id AS unique_book_id,
            location.place,
            location.action,
            book.id_art,
            book.id_language,
            book.id_publishing_house,
            book.publication_year,
            book.code,
            book.pages,
            action_1.date
           FROM ((public.book
             LEFT JOIN public.location ON ((location.book = book.id)))
             LEFT JOIN public.action action_1 ON ((location.action = action_1.id)))
          ORDER BY book.id, action_1.date DESC) unique_book
     LEFT JOIN public.place ON ((unique_book.place = place.id)))
     LEFT JOIN public.action ON ((unique_book.action = action.id)))
     LEFT JOIN public.action_type ON ((action_type.id = action.action_type)))
     LEFT JOIN ( SELECT art.id,
            art.name AS art_name,
            genre.name AS genre_name,
            language_1.name AS orig_language
           FROM ((public.art
             LEFT JOIN public.genre ON ((art.genre = genre.id)))
             LEFT JOIN public.language language_1 ON ((art.orig_language = language_1.id)))) t_art ON ((unique_book.id_art = t_art.id)))
     LEFT JOIN ( SELECT author_art.art,
            string_agg((author.name)::text, ', '::text) AS authors_names
           FROM (public.author_art
             JOIN public.author ON ((author_art.author = author.id)))
          GROUP BY author_art.art) book_authors ON ((t_art.id = book_authors.art)))
     LEFT JOIN public.language ON ((unique_book.id_language = language.id)))
     LEFT JOIN public.publishing_house ON ((unique_book.id_publishing_house = publishing_house.id)))
  ORDER BY unique_book.unique_book_id;


ALTER TABLE public.view_all_real_books OWNER TO postgres;

--
-- Name: view_arts; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_arts AS
 SELECT art.name AS "Название",
    t1."Автор(ы)",
    genre.name AS "Жанр"
   FROM ((public.art
     LEFT JOIN ( SELECT author_art.art,
            string_agg((author.name)::text, ', '::text) AS "Автор(ы)"
           FROM (public.author_art
             LEFT JOIN public.author ON ((author_art.author = author.id)))
          GROUP BY author_art.art) t1 ON ((art.id = t1.art)))
     LEFT JOIN public.genre ON ((art.genre = genre.id)));


ALTER TABLE public.view_arts OWNER TO postgres;

--
-- Name: view_arts_with_id; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_arts_with_id AS
 SELECT art.id,
    art.name AS "Название",
    t1."Автор(ы)",
    genre.name AS "Жанр"
   FROM ((public.art
     LEFT JOIN ( SELECT author_art.art,
            string_agg((author.name)::text, ', '::text) AS "Автор(ы)"
           FROM (public.author_art
             LEFT JOIN public.author ON ((author_art.author = author.id)))
          GROUP BY author_art.art) t1 ON ((art.id = t1.art)))
     LEFT JOIN public.genre ON ((art.genre = genre.id)));


ALTER TABLE public.view_arts_with_id OWNER TO postgres;

--
-- Name: view_books; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_books AS
 SELECT book.id,
    art.name AS "Название",
    t1."Автор(ы)",
    EXTRACT(year FROM book.publication_year) AS "Год издания",
    genre.name AS "Жанр",
    publishing_house.name AS "Издательство",
    book.code AS "Шифр"
   FROM ((((public.book
     JOIN public.art ON ((book.id_art = art.id)))
     LEFT JOIN public.genre ON ((art.genre = genre.id)))
     LEFT JOIN public.publishing_house ON ((book.id_publishing_house = publishing_house.id)))
     JOIN ( SELECT author_art.art,
            string_agg((author.name)::text, ', '::text) AS "Автор(ы)"
           FROM (public.author_art
             JOIN public.author ON ((author_art.author = author.id)))
          GROUP BY author_art.art) t1 ON ((art.id = t1.art)))
  ORDER BY book.id;


ALTER TABLE public.view_books OWNER TO postgres;

--
-- Name: view_codes; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_codes AS
 SELECT book.id AS book_id,
    art.name,
    book.code,
    genre.name AS genre
   FROM ((public.book
     JOIN public.art ON ((book.id_art = art.id)))
     JOIN public.genre ON ((art.genre = genre.id)))
  ORDER BY book.code;


ALTER TABLE public.view_codes OWNER TO postgres;

--
-- Name: view_genres; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_genres AS
 SELECT genre.id,
    genre.name
   FROM public.genre
  ORDER BY genre.name;


ALTER TABLE public.view_genres OWNER TO postgres;

--
-- Name: view_has_read; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_has_read AS
 SELECT art_read.id,
    art_read.date AS "Дата",
    art_authors.authors_names AS "Автор(ы)",
    t_art.art_name AS "Название",
    t_art.genre_name AS "Жанр",
    t_art.orig_language AS "Язык оригинала",
    art_read.comment AS "Впечатление",
    mark.name AS "Оценка",
    book_format.name AS "Формат"
   FROM ((((public.art_read
     JOIN ( SELECT art.id,
            art.name AS art_name,
            genre.name AS genre_name,
            language_1.name AS orig_language
           FROM ((public.art
             LEFT JOIN public.genre ON ((art.genre = genre.id)))
             LEFT JOIN public.language language_1 ON ((art.orig_language = language_1.id)))) t_art ON ((art_read.art_id = t_art.id)))
     LEFT JOIN ( SELECT author_art.art,
            string_agg((author.name)::text, ', '::text) AS authors_names
           FROM (public.author_art
             JOIN public.author ON ((author_art.author = author.id)))
          GROUP BY author_art.art) art_authors ON ((t_art.id = art_authors.art)))
     LEFT JOIN public.mark ON ((art_read.mark_id = mark.id)))
     LEFT JOIN public.book_format ON ((art_read.book_format_id = book_format.id)))
  ORDER BY art_read.date;


ALTER TABLE public.view_has_read OWNER TO postgres;

--
-- Name: view_hint_art_to_art; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_hint_art_to_art AS
 SELECT art_to_read.id,
    view_arts_with_id."Название" AS "Источник (Книга)",
    view_arts_with_id."Автор(ы)" AS "Источник (Автор)",
    toread_art."Название" AS "Рекомендация (Книга)",
    toread_art."Автор(ы)" AS "Рекомендация (Автор)",
    art_to_read.comment
   FROM ((public.art_to_read
     JOIN public.view_arts_with_id toread_art ON ((art_to_read.toread_art_id = toread_art.id)))
     JOIN public.view_arts_with_id ON ((art_to_read.source_art_id = view_arts_with_id.id)))
  ORDER BY view_arts_with_id.id;


ALTER TABLE public.view_hint_art_to_art OWNER TO postgres;

--
-- Name: view_hint_art_to_author; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_hint_art_to_author AS
 SELECT art_to_read.id,
    view_arts_with_id."Название" AS "Источник (Книга)",
    view_arts_with_id."Автор(ы)" AS "Источник (Автор)",
    author.name AS "Рекомендация (Автор)",
    art_to_read.comment
   FROM ((public.art_to_read
     JOIN public.author ON ((art_to_read.toread_author_id = author.id)))
     JOIN public.view_arts_with_id ON ((art_to_read.source_art_id = view_arts_with_id.id)))
  ORDER BY view_arts_with_id.id;


ALTER TABLE public.view_hint_art_to_author OWNER TO postgres;

--
-- Name: view_hint_author_to_author; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_hint_author_to_author AS
 SELECT art_to_read.id,
    source_author_table.name AS "Источник (Автор)",
    author.name AS "Рекомендация (Автор)",
    art_to_read.comment
   FROM ((public.art_to_read
     LEFT JOIN public.author source_author_table ON ((art_to_read.source_author_id = source_author_table.id)))
     LEFT JOIN public.author ON ((art_to_read.toread_author_id = author.id)))
  WHERE (art_to_read.source_author_id IS NOT NULL);


ALTER TABLE public.view_hint_author_to_author OWNER TO postgres;

--
-- Name: view_hint_from_another; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_hint_from_another AS
 SELECT art_to_read.id,
    source_toread_another.name AS "Источник",
    author.name AS "Рекомендация (Автор)",
    toread_art."Название" AS "Рекомендация (Книга)",
    toread_art."Автор(ы)" AS "Рекомендация (Автор книги)",
    art_to_read.comment
   FROM (((public.art_to_read
     LEFT JOIN public.source_toread_another ON ((art_to_read.source_another_id = source_toread_another.id)))
     LEFT JOIN public.author ON ((art_to_read.toread_author_id = author.id)))
     LEFT JOIN public.view_arts_with_id toread_art ON ((art_to_read.toread_art_id = toread_art.id)))
  WHERE (art_to_read.source_another_id IS NOT NULL);


ALTER TABLE public.view_hint_from_another OWNER TO postgres;

--
-- Name: view_hint_from_art; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_hint_from_art AS
 SELECT art_to_read.id,
    view_arts_with_id."Название" AS "Источник (Книга)",
    view_arts_with_id."Автор(ы)" AS "Источник (Автор)",
    author.name AS "Рекомендация (Автор)",
    toread_art."Название" AS "Рекомендация (Книга)",
    toread_art."Автор(ы)" AS "Рекомендация (Автор книги)",
    art_to_read.comment
   FROM (((public.art_to_read
     LEFT JOIN public.view_arts_with_id ON ((art_to_read.source_art_id = view_arts_with_id.id)))
     LEFT JOIN public.view_arts_with_id toread_art ON ((art_to_read.toread_art_id = toread_art.id)))
     LEFT JOIN public.author ON ((art_to_read.toread_author_id = author.id)))
  ORDER BY view_arts_with_id.id;


ALTER TABLE public.view_hint_from_art OWNER TO postgres;

--
-- Name: view_hint_from_author; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_hint_from_author AS
 SELECT art_to_read.id,
    source_author_table.name AS "Источник (Автор)",
    author.name AS "Рекомендация (Автор)",
    toread_art."Название" AS "Рекомендация (Книга)",
    toread_art."Автор(ы)" AS "Рекомендация (Автор книги)",
    art_to_read.comment
   FROM (((public.art_to_read
     LEFT JOIN public.author source_author_table ON ((art_to_read.source_author_id = source_author_table.id)))
     LEFT JOIN public.author ON ((art_to_read.toread_author_id = author.id)))
     LEFT JOIN public.view_arts_with_id toread_art ON ((art_to_read.toread_art_id = toread_art.id)))
  WHERE (art_to_read.source_author_id IS NOT NULL);


ALTER TABLE public.view_hint_from_author OWNER TO postgres;

--
-- Name: view_my_books; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_my_books AS
 SELECT unique_book.unique_book_id,
    place.name AS "Место",
    action.comment AS "Движ.",
    action_type.name AS "Действие",
    unique_book.date AS "Дата",
    t_art.art_name AS "Название",
    book_authors.authors_names AS "Автор(ы)",
    t_art.genre_name AS "Жанр",
    t_art.orig_language AS "Язык написания",
    language.name AS "Язык издания",
    EXTRACT(year FROM unique_book.publication_year) AS "Год издания",
    publishing_house.name AS "Издательство",
    unique_book.code AS "Шифр",
    unique_book.pages AS "Страниц"
   FROM ((((((((( SELECT DISTINCT ON (location.book) location.book AS unique_book_id,
            location.place,
            location.action,
            location.owner,
            book.id_art,
            book.id_language,
            book.id_publishing_house,
            book.publication_year,
            book.code,
            book.pages,
            action_1.date
           FROM ((public.book
             LEFT JOIN public.location ON ((location.book = book.id)))
             LEFT JOIN public.action action_1 ON ((location.action = action_1.id)))
          ORDER BY location.book, action_1.date DESC) unique_book
     LEFT JOIN public.place ON ((unique_book.place = place.id)))
     LEFT JOIN public.action ON ((unique_book.action = action.id)))
     LEFT JOIN public.action_type ON ((action_type.id = action.action_type)))
     LEFT JOIN ( SELECT art.id,
            art.name AS art_name,
            genre.name AS genre_name,
            language_1.name AS orig_language
           FROM ((public.art
             LEFT JOIN public.genre ON ((art.genre = genre.id)))
             LEFT JOIN public.language language_1 ON ((art.orig_language = language_1.id)))) t_art ON ((unique_book.id_art = t_art.id)))
     LEFT JOIN ( SELECT author_art.art,
            string_agg((author.name)::text, ', '::text) AS authors_names
           FROM (public.author_art
             JOIN public.author ON ((author_art.author = author.id)))
          GROUP BY author_art.art) book_authors ON ((t_art.id = book_authors.art)))
     LEFT JOIN public.language ON ((unique_book.id_language = language.id)))
     LEFT JOIN public.publishing_house ON ((unique_book.id_publishing_house = publishing_house.id)))
     LEFT JOIN public.people ON ((unique_book.owner = people.id)))
  WHERE ((people.name)::text = 'Я'::text)
  ORDER BY place.name, action.comment, t_art.art_name;


ALTER TABLE public.view_my_books OWNER TO postgres;

--
-- Name: view_my_books_in_other_hands; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.view_my_books_in_other_hands AS
 SELECT unique_book.unique_book_id,
    place.name AS "Место",
    action.comment AS "Движ.",
    action_type.name AS "Действие",
    unique_book.date AS "Дата",
    t_art.art_name AS "Название",
    book_authors.authors_names AS "Автор(ы)",
    t_art.genre_name AS "Жанр",
    t_art.orig_language AS "Язык написания",
    language.name AS "Язык издания",
    EXTRACT(year FROM unique_book.publication_year) AS "Год издания",
    publishing_house.name AS "Издательство",
    unique_book.code AS "Шифр",
    unique_book.pages AS "Страниц"
   FROM ((((((((( SELECT DISTINCT ON (location.book) location.book AS unique_book_id,
            location.place,
            location.action,
            location.owner,
            book.id_art,
            book.id_language,
            book.id_publishing_house,
            book.publication_year,
            book.code,
            book.pages,
            action_1.date
           FROM ((public.book
             LEFT JOIN public.location ON ((location.book = book.id)))
             LEFT JOIN public.action action_1 ON ((location.action = action_1.id)))
          ORDER BY location.book, action_1.date DESC) unique_book
     LEFT JOIN public.place ON ((unique_book.place = place.id)))
     LEFT JOIN public.action ON ((unique_book.action = action.id)))
     LEFT JOIN public.action_type ON ((action_type.id = action.action_type)))
     LEFT JOIN ( SELECT art.id,
            art.name AS art_name,
            genre.name AS genre_name,
            language_1.name AS orig_language
           FROM ((public.art
             LEFT JOIN public.genre ON ((art.genre = genre.id)))
             LEFT JOIN public.language language_1 ON ((art.orig_language = language_1.id)))) t_art ON ((unique_book.id_art = t_art.id)))
     LEFT JOIN ( SELECT author_art.art,
            string_agg((author.name)::text, ', '::text) AS authors_names
           FROM (public.author_art
             JOIN public.author ON ((author_art.author = author.id)))
          GROUP BY author_art.art) book_authors ON ((t_art.id = book_authors.art)))
     LEFT JOIN public.language ON ((unique_book.id_language = language.id)))
     LEFT JOIN public.publishing_house ON ((unique_book.id_publishing_house = publishing_house.id)))
     LEFT JOIN public.people ON ((unique_book.owner = people.id)))
  WHERE (((people.name)::text = 'Я'::text) AND (unique_book.place IS NULL))
  ORDER BY place.name, action.comment, t_art.art_name;


ALTER TABLE public.view_my_books_in_other_hands OWNER TO postgres;

--
-- Name: action id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.action ALTER COLUMN id SET DEFAULT nextval('public.action_id_seq'::regclass);


--
-- Name: action_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.action_type ALTER COLUMN id SET DEFAULT nextval('public.action_type_id_seq'::regclass);


--
-- Name: art id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art ALTER COLUMN id SET DEFAULT nextval('public.art_id_seq'::regclass);


--
-- Name: author id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.author ALTER COLUMN id SET DEFAULT nextval('public.author_id_seq'::regclass);


--
-- Name: author_art id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.author_art ALTER COLUMN id SET DEFAULT nextval('public.author_art_id_seq'::regclass);


--
-- Name: book id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.book ALTER COLUMN id SET DEFAULT nextval('public.book_id_seq'::regclass);


--
-- Name: chifres_names id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.chifres_names ALTER COLUMN id SET DEFAULT nextval('public.chifres_names_id_seq'::regclass);


--
-- Name: city id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.city ALTER COLUMN id SET DEFAULT nextval('public."City_id_seq"'::regclass);


--
-- Name: genre id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.genre ALTER COLUMN id SET DEFAULT nextval('public.genre_id_seq'::regclass);


--
-- Name: language id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.language ALTER COLUMN id SET DEFAULT nextval('public.language_id_seq'::regclass);


--
-- Name: location id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location ALTER COLUMN id SET DEFAULT nextval('public.registration_id_seq'::regclass);


--
-- Name: people id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.people ALTER COLUMN id SET DEFAULT nextval('public.people_id_seq'::regclass);


--
-- Name: place id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.place ALTER COLUMN id SET DEFAULT nextval('public.place_id_seq'::regclass);


--
-- Name: possession id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.possession ALTER COLUMN id SET DEFAULT nextval('public.possession_id_seq'::regclass);


--
-- Name: publishing_house id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.publishing_house ALTER COLUMN id SET DEFAULT nextval('public.publishing_house_id_seq'::regclass);


--
-- Name: series id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.series ALTER COLUMN id SET DEFAULT nextval('public.series_id_seq'::regclass);


--
-- Name: city City_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.city
    ADD CONSTRAINT "City_pkey" PRIMARY KEY (id);


--
-- Name: action action_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.action
    ADD CONSTRAINT action_pkey PRIMARY KEY (id);


--
-- Name: action_type action_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.action_type
    ADD CONSTRAINT action_type_pkey PRIMARY KEY (id);


--
-- Name: art art_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art
    ADD CONSTRAINT art_pkey PRIMARY KEY (id);


--
-- Name: art_read art_read_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_read
    ADD CONSTRAINT art_read_pkey PRIMARY KEY (id);


--
-- Name: art_spec_register art_spec_register_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_spec_register
    ADD CONSTRAINT art_spec_register_pkey PRIMARY KEY (id);


--
-- Name: art_to_read art_to_read_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_to_read
    ADD CONSTRAINT art_to_read_pkey PRIMARY KEY (id);


--
-- Name: author_art author_art_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.author_art
    ADD CONSTRAINT author_art_pkey PRIMARY KEY (id);


--
-- Name: author author_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.author
    ADD CONSTRAINT author_pkey PRIMARY KEY (id);


--
-- Name: book_format book_format_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.book_format
    ADD CONSTRAINT book_format_pkey PRIMARY KEY (id);


--
-- Name: book book_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_pkey PRIMARY KEY (id);


--
-- Name: chifres_names chifres_names_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.chifres_names
    ADD CONSTRAINT chifres_names_pkey PRIMARY KEY (id_genre);


--
-- Name: genre genre_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.genre
    ADD CONSTRAINT genre_pkey PRIMARY KEY (id);


--
-- Name: language language_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.language
    ADD CONSTRAINT language_pkey PRIMARY KEY (id);


--
-- Name: mark mark_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mark
    ADD CONSTRAINT mark_pkey PRIMARY KEY (id);


--
-- Name: people people_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.people
    ADD CONSTRAINT people_pkey PRIMARY KEY (id);


--
-- Name: place place_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.place
    ADD CONSTRAINT place_pkey PRIMARY KEY (id);


--
-- Name: possession possession_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.possession
    ADD CONSTRAINT possession_pkey PRIMARY KEY (id);


--
-- Name: publishing_house publishing_house_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.publishing_house
    ADD CONSTRAINT publishing_house_pkey PRIMARY KEY (id);


--
-- Name: query query_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.query
    ADD CONSTRAINT query_pkey PRIMARY KEY (id);


--
-- Name: location registration_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT registration_pkey PRIMARY KEY (id);


--
-- Name: series series_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.series
    ADD CONSTRAINT series_pkey PRIMARY KEY (id);


--
-- Name: source_toread_another source_toread_another_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.source_toread_another
    ADD CONSTRAINT source_toread_another_pkey PRIMARY KEY (id);


--
-- Name: spec_register_attribute spec_register_attribute_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.spec_register_attribute
    ADD CONSTRAINT spec_register_attribute_pkey PRIMARY KEY (id);


--
-- Name: action action_action_type_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.action
    ADD CONSTRAINT action_action_type_fkey FOREIGN KEY (action_type) REFERENCES public.action_type(id);


--
-- Name: action action_place_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.action
    ADD CONSTRAINT action_place_fkey FOREIGN KEY (place) REFERENCES public.place(id);


--
-- Name: art art_genre_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art
    ADD CONSTRAINT art_genre_fkey FOREIGN KEY (genre) REFERENCES public.genre(id);


--
-- Name: art art_orig_language_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art
    ADD CONSTRAINT art_orig_language_fkey FOREIGN KEY (orig_language) REFERENCES public.language(id);


--
-- Name: art_read art_read_art_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_read
    ADD CONSTRAINT art_read_art_id_fkey FOREIGN KEY (art_id) REFERENCES public.art(id) NOT VALID;


--
-- Name: art_read art_read_book_format_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_read
    ADD CONSTRAINT art_read_book_format_id_fkey FOREIGN KEY (book_format_id) REFERENCES public.book_format(id) NOT VALID;


--
-- Name: art_read art_read_book_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_read
    ADD CONSTRAINT art_read_book_id_fkey FOREIGN KEY (book_id) REFERENCES public.book(id) NOT VALID;


--
-- Name: art_read art_read_mark_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_read
    ADD CONSTRAINT art_read_mark_id_fkey FOREIGN KEY (mark_id) REFERENCES public.mark(id) NOT VALID;


--
-- Name: art_read art_read_read_language_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_read
    ADD CONSTRAINT art_read_read_language_id_fkey FOREIGN KEY (read_language_id) REFERENCES public.language(id) NOT VALID;


--
-- Name: art_spec_register art_spec_register_art_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_spec_register
    ADD CONSTRAINT art_spec_register_art_id_fkey FOREIGN KEY (art_id) REFERENCES public.art(id);


--
-- Name: art_spec_register art_spec_register_spec_register_attribute_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_spec_register
    ADD CONSTRAINT art_spec_register_spec_register_attribute_id_fkey FOREIGN KEY (spec_register_attribute_id) REFERENCES public.spec_register_attribute(id) NOT VALID;


--
-- Name: art_to_read art_to_read_source_another_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_to_read
    ADD CONSTRAINT art_to_read_source_another_id_fkey FOREIGN KEY (source_another_id) REFERENCES public.source_toread_another(id) NOT VALID;


--
-- Name: art_to_read art_to_read_source_art_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_to_read
    ADD CONSTRAINT art_to_read_source_art_id_fkey FOREIGN KEY (source_art_id) REFERENCES public.art(id) NOT VALID;


--
-- Name: art_to_read art_to_read_source_author_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_to_read
    ADD CONSTRAINT art_to_read_source_author_id_fkey FOREIGN KEY (source_author_id) REFERENCES public.author(id) NOT VALID;


--
-- Name: art_to_read art_to_read_toread_art_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_to_read
    ADD CONSTRAINT art_to_read_toread_art_id_fkey FOREIGN KEY (toread_art_id) REFERENCES public.art(id) NOT VALID;


--
-- Name: art_to_read art_to_read_toread_author_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.art_to_read
    ADD CONSTRAINT art_to_read_toread_author_id_fkey FOREIGN KEY (toread_author_id) REFERENCES public.author(id) NOT VALID;


--
-- Name: author_art author_art_art_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.author_art
    ADD CONSTRAINT author_art_art_fkey FOREIGN KEY (art) REFERENCES public.art(id);


--
-- Name: author_art author_art_author_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.author_art
    ADD CONSTRAINT author_art_author_fkey FOREIGN KEY (author) REFERENCES public.author(id);


--
-- Name: book book_id_art_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_id_art_fkey FOREIGN KEY (id_art) REFERENCES public.art(id);


--
-- Name: book book_id_city_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_id_city_fkey FOREIGN KEY (id_city) REFERENCES public.city(id);


--
-- Name: book book_id_language_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_id_language_fkey FOREIGN KEY (id_language) REFERENCES public.language(id);


--
-- Name: book book_id_publishing_house_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_id_publishing_house_fkey FOREIGN KEY (id_publishing_house) REFERENCES public.publishing_house(id);


--
-- Name: book book_id_series_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.book
    ADD CONSTRAINT book_id_series_fkey FOREIGN KEY (id_series) REFERENCES public.series(id);


--
-- Name: location location_action_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT location_action_fkey FOREIGN KEY (action) REFERENCES public.action(id);


--
-- Name: location location_book_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT location_book_fkey FOREIGN KEY (book) REFERENCES public.book(id);


--
-- Name: location location_place_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT location_place_fkey FOREIGN KEY (place) REFERENCES public.place(id);


--
-- Name: location locationn_owner_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.location
    ADD CONSTRAINT locationn_owner_fkey FOREIGN KEY (owner) REFERENCES public.people(id);


--
-- Name: possession possession_action_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.possession
    ADD CONSTRAINT possession_action_fkey FOREIGN KEY (action) REFERENCES public.action(id);


--
-- Name: possession possession_book_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.possession
    ADD CONSTRAINT possession_book_fkey FOREIGN KEY (book) REFERENCES public.book(id);


--
-- Name: possession possession_person_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.possession
    ADD CONSTRAINT possession_person_fkey FOREIGN KEY (person) REFERENCES public.people(id);


--
-- PostgreSQL database dump complete
--

