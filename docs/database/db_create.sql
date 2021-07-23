--
-- PostgreSQL database dump
--

-- Dumped from database version 13.3 (Debian 13.3-1.pgdg100+1)
-- Dumped by pg_dump version 13.3

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

--
-- Name: raftypoile_blog; Type: DATABASE; Schema: -; Owner: it19055
--

CREATE DATABASE raftypoile_blog WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';


ALTER DATABASE raftypoile_blog OWNER TO it19055;

\connect raftypoile_blog

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
-- Name: categories; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".categories (
    id_category bigint NOT NULL,
    name text NOT NULL,
    description text DEFAULT 'todo'::text NOT NULL
);


ALTER TABLE "Main".categories OWNER TO it19055;

--
-- Name: categories_id_category_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".categories_id_category_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".categories_id_category_seq OWNER TO it19055;

--
-- Name: categories_id_category_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".categories_id_category_seq OWNED BY "Main".categories.id_category;


--
-- Name: document_types; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".document_types (
    id_document_type bigint NOT NULL,
    name text NOT NULL
);


ALTER TABLE "Main".document_types OWNER TO it19055;

--
-- Name: document_types_id_document_type_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".document_types_id_document_type_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".document_types_id_document_type_seq OWNER TO it19055;

--
-- Name: document_types_id_document_type_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".document_types_id_document_type_seq OWNED BY "Main".document_types.id_document_type;


--
-- Name: documents; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".documents (
    id_document bigint NOT NULL,
    source text NOT NULL,
    name text NOT NULL,
    description text NOT NULL,
    id_document_type bigint NOT NULL,
    published boolean NOT NULL,
    id_user uuid NOT NULL
);


ALTER TABLE "Main".documents OWNER TO it19055;

--
-- Name: COLUMN documents.published; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".documents.published IS 'Pieejams publiski?';


--
-- Name: COLUMN documents.id_user; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".documents.id_user IS 'Dokumenta ievietotājs,. autors u.t.t';


--
-- Name: documents_id_document_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".documents_id_document_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".documents_id_document_seq OWNER TO it19055;

--
-- Name: documents_id_document_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".documents_id_document_seq OWNED BY "Main".documents.id_document;


--
-- Name: emails; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".emails (
    id_email bigint NOT NULL,
    email character varying NOT NULL
);


ALTER TABLE "Main".emails OWNER TO it19055;

--
-- Name: COLUMN emails.email; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".emails.email IS 'email from app';


--
-- Name: emails_id_email_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".emails_id_email_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".emails_id_email_seq OWNER TO it19055;

--
-- Name: emails_id_email_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".emails_id_email_seq OWNED BY "Main".emails.id_email;


--
-- Name: feed; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".feed (
    id_feed bigint NOT NULL,
    id_user uuid NOT NULL,
    feed_name character varying DEFAULT 'feed'::character varying NOT NULL,
    id_icon bigint DEFAULT 0 NOT NULL,
    feed_url character varying NOT NULL,
    "timestamp" date DEFAULT now() NOT NULL
);


ALTER TABLE "Main".feed OWNER TO it19055;

--
-- Name: feed_id_feed_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".feed_id_feed_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".feed_id_feed_seq OWNER TO it19055;

--
-- Name: feed_id_feed_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".feed_id_feed_seq OWNED BY "Main".feed.id_feed;


--
-- Name: icons; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".icons (
    id_icon bigint NOT NULL,
    name character varying NOT NULL,
    source character varying NOT NULL
);


ALTER TABLE "Main".icons OWNER TO it19055;

--
-- Name: icons_id_icon_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".icons_id_icon_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".icons_id_icon_seq OWNER TO it19055;

--
-- Name: icons_id_icon_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".icons_id_icon_seq OWNED BY "Main".icons.id_icon;


--
-- Name: ingredients; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".ingredients (
    id_ingredient integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE "Main".ingredients OWNER TO it19055;

--
-- Name: ingredients_id_ingredient_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".ingredients_id_ingredient_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".ingredients_id_ingredient_seq OWNER TO it19055;

--
-- Name: ingredients_id_ingredient_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".ingredients_id_ingredient_seq OWNED BY "Main".ingredients.id_ingredient;


--
-- Name: login_data; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".login_data (
    id_user uuid NOT NULL,
    username character varying NOT NULL,
    password character varying NOT NULL,
    account_created date DEFAULT now() NOT NULL
);


ALTER TABLE "Main".login_data OWNER TO it19055;

--
-- Name: pictures; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".pictures (
    id_picture bigint NOT NULL,
    alternative_text text DEFAULT 'todo'::text NOT NULL,
    id_category bigint NOT NULL,
    published boolean DEFAULT false NOT NULL,
    source_header text,
    source_preview text,
    source_original text
);


ALTER TABLE "Main".pictures OWNER TO it19055;

--
-- Name: pictures_id_picture_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".pictures_id_picture_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".pictures_id_picture_seq OWNER TO it19055;

--
-- Name: pictures_id_picture_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".pictures_id_picture_seq OWNED BY "Main".pictures.id_picture;


--
-- Name: posts; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".posts (
    id_post bigint NOT NULL,
    id_cat bigint NOT NULL,
    title text NOT NULL,
    description text NOT NULL,
    body text,
    id_user uuid NOT NULL,
    id_picture bigint DEFAULT 0,
    date date DEFAULT now() NOT NULL,
    published boolean NOT NULL
);


ALTER TABLE "Main".posts OWNER TO it19055;

--
-- Name: COLUMN posts.body; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".posts.body IS 'HTML code';


--
-- Name: COLUMN posts.id_user; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".posts.id_user IS 'Author. Author pic should be added to Author table.';


--
-- Name: COLUMN posts.id_picture; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".posts.id_picture IS 'Mainly for Hero/Header picture';


--
-- Name: posts_id_post_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".posts_id_post_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".posts_id_post_seq OWNER TO it19055;

--
-- Name: posts_id_post_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".posts_id_post_seq OWNED BY "Main".posts.id_post;


--
-- Name: quotes; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".quotes (
    id_quote bigint NOT NULL,
    id_user uuid NOT NULL,
    body text NOT NULL,
    author character varying,
    id_social_media bigint NOT NULL
);


ALTER TABLE "Main".quotes OWNER TO it19055;

--
-- Name: quotes_id_quote_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".quotes_id_quote_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".quotes_id_quote_seq OWNER TO it19055;

--
-- Name: quotes_id_quote_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".quotes_id_quote_seq OWNED BY "Main".quotes.id_quote;


--
-- Name: recipes; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".recipes (
    id_recipe integer DEFAULT nextval('"Main".recipes_inc'::regclass) NOT NULL,
    title character varying NOT NULL,
    body text NOT NULL,
    cooking_time time without time zone NOT NULL,
    servings integer DEFAULT 4 NOT NULL,
    "timestamp" date DEFAULT now() NOT NULL
);


ALTER TABLE "Main".recipes OWNER TO it19055;

--
-- Name: TABLE recipes; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON TABLE "Main".recipes IS 'table for Food API';


--
-- Name: social_media; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".social_media (
    id_social_media bigint NOT NULL,
    name text NOT NULL,
    base_link text NOT NULL,
    id_icon bigint NOT NULL
);


ALTER TABLE "Main".social_media OWNER TO it19055;

--
-- Name: COLUMN social_media.name; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".social_media.name IS 'name of social media';


--
-- Name: COLUMN social_media.base_link; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".social_media.base_link IS 'base link';


--
-- Name: COLUMN social_media.id_icon; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".social_media.id_icon IS 'from font-awesome';


--
-- Name: social_media_id_social_media_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".social_media_id_social_media_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".social_media_id_social_media_seq OWNER TO it19055;

--
-- Name: social_media_id_social_media_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".social_media_id_social_media_seq OWNED BY "Main".social_media.id_social_media;


--
-- Name: social_media_refs; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".social_media_refs (
    id_social_media_ref bigint NOT NULL,
    id_user uuid NOT NULL,
    id_social_media bigint NOT NULL,
    href text NOT NULL
);


ALTER TABLE "Main".social_media_refs OWNER TO it19055;

--
-- Name: COLUMN social_media_refs.id_social_media; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".social_media_refs.id_social_media IS 'social media name';


--
-- Name: COLUMN social_media_refs.href; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".social_media_refs.href IS 'href to social media account';


--
-- Name: social_media_refs_id_social_media_ref_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".social_media_refs_id_social_media_ref_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".social_media_refs_id_social_media_ref_seq OWNER TO it19055;

--
-- Name: social_media_refs_id_social_media_ref_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".social_media_refs_id_social_media_ref_seq OWNED BY "Main".social_media_refs.id_social_media_ref;


--
-- Name: tag_index; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".tag_index (
    id_recipe integer NOT NULL,
    id_tag integer NOT NULL
);


ALTER TABLE "Main".tag_index OWNER TO it19055;

--
-- Name: tags; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".tags (
    id_tag integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE "Main".tags OWNER TO it19055;

--
-- Name: tags_id_tag_seq; Type: SEQUENCE; Schema: Main; Owner: it19055
--

CREATE SEQUENCE "Main".tags_id_tag_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Main".tags_id_tag_seq OWNER TO it19055;

--
-- Name: tags_id_tag_seq; Type: SEQUENCE OWNED BY; Schema: Main; Owner: it19055
--

ALTER SEQUENCE "Main".tags_id_tag_seq OWNED BY "Main".tags.id_tag;


--
-- Name: user_index; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".user_index (
    id_recipe integer NOT NULL,
    id_user uuid NOT NULL
);


ALTER TABLE "Main".user_index OWNER TO it19055;

--
-- Name: users; Type: TABLE; Schema: Main; Owner: it19055
--

CREATE TABLE "Main".users (
    id_user uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    name character varying NOT NULL,
    surname character varying NOT NULL,
    id_email bigint DEFAULT 0 NOT NULL,
    id_picture bigint DEFAULT 0 NOT NULL
);


ALTER TABLE "Main".users OWNER TO it19055;

--
-- Name: COLUMN users.id_email; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".users.id_email IS 'Main email';


--
-- Name: COLUMN users.id_picture; Type: COMMENT; Schema: Main; Owner: it19055
--

COMMENT ON COLUMN "Main".users.id_picture IS 'Author Pic';


--
-- Name: categories id_category; Type: DEFAULT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".users
    ADD CONSTRAINT authors_pk PRIMARY KEY (id_user);


--
-- Name: categories categories_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".categories
    ADD CONSTRAINT categories_pk PRIMARY KEY (id_category);


--
-- Name: document_types document_types_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".document_types
    ADD CONSTRAINT document_types_pk PRIMARY KEY (id_document_type);


--
-- Name: documents documents_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".documents
    ADD CONSTRAINT documents_pk PRIMARY KEY (id_document);


--
-- Name: emails emails_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".emails
    ADD CONSTRAINT emails_pk PRIMARY KEY (id_email);


--
-- Name: feed feed_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".feed
    ADD CONSTRAINT feed_pk PRIMARY KEY (id_feed);


--
-- Name: icons icons_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".icons
    ADD CONSTRAINT icons_pk PRIMARY KEY (id_icon);


--
-- Name: ingredients ingredients_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".ingredients
    ADD CONSTRAINT ingredients_pk PRIMARY KEY (id_ingredient);


--
-- Name: pictures pictures_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".pictures
    ADD CONSTRAINT pictures_pk PRIMARY KEY (id_picture);


--
-- Name: posts posts_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".posts
    ADD CONSTRAINT posts_pk PRIMARY KEY (id_post);


--
-- Name: quotes quotes_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".quotes
    ADD CONSTRAINT quotes_pk PRIMARY KEY (id_quote);


--
-- Name: recipes recipes_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".recipes
    ADD CONSTRAINT recipes_pk PRIMARY KEY (id_recipe);


--
-- Name: social_media social_media_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".social_media
    ADD CONSTRAINT social_media_pk PRIMARY KEY (id_social_media);


--
-- Name: social_media_refs social_media_refs_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".social_media_refs
    ADD CONSTRAINT social_media_refs_pk PRIMARY KEY (id_social_media_ref);


--
-- Name: tag_index tag_index_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".tag_index
    ADD CONSTRAINT tag_index_pk PRIMARY KEY (id_tag, id_recipe);


--
-- Name: tags tags_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".tags
    ADD CONSTRAINT tags_pk PRIMARY KEY (id_tag);


--
-- Name: user_index user_index_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".user_index
    ADD CONSTRAINT user_index_pk PRIMARY KEY (id_recipe, id_user);


--
-- Name: login_data users_pk; Type: CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".login_data
    ADD CONSTRAINT users_pk PRIMARY KEY (id_user);


--
-- Name: tags_name_uindex; Type: INDEX; Schema: Main; Owner: it19055
--

CREATE UNIQUE INDEX tags_name_uindex ON "Main".tags USING btree (name);


--
-- Name: users authors_fk; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".users
    ADD CONSTRAINT authors_fk FOREIGN KEY (id_picture) REFERENCES "Main".pictures(id_picture) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: documents documents_fk; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".documents
    ADD CONSTRAINT documents_fk FOREIGN KEY (id_document_type) REFERENCES "Main".document_types(id_document_type) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: login_data login_data_fk; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".login_data
    ADD CONSTRAINT login_data_fk FOREIGN KEY (id_user) REFERENCES "Main".users(id_user) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: pictures pictures_fk; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".pictures
    ADD CONSTRAINT pictures_fk FOREIGN KEY (id_category) REFERENCES "Main".categories(id_category) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: posts to_auth; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".posts
    ADD CONSTRAINT to_auth FOREIGN KEY (id_user) REFERENCES "Main".users(id_user) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: social_media_refs to_authors; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".social_media_refs
    ADD CONSTRAINT to_authors FOREIGN KEY (id_user) REFERENCES "Main".users(id_user) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: posts to_cat; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".posts
    ADD CONSTRAINT to_cat FOREIGN KEY (id_cat) REFERENCES "Main".categories(id_category) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: users to_emails; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".users
    ADD CONSTRAINT to_emails FOREIGN KEY (id_email) REFERENCES "Main".emails(id_email) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: social_media to_icons; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".social_media
    ADD CONSTRAINT to_icons FOREIGN KEY (id_icon) REFERENCES "Main".icons(id_icon);


--
-- Name: feed to_icons; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".feed
    ADD CONSTRAINT to_icons FOREIGN KEY (id_icon) REFERENCES "Main".icons(id_icon) ON UPDATE SET DEFAULT ON DELETE SET DEFAULT;


--
-- Name: posts to_pic; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".posts
    ADD CONSTRAINT to_pic FOREIGN KEY (id_picture) REFERENCES "Main".pictures(id_picture) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: tag_index to_recipes; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".tag_index
    ADD CONSTRAINT to_recipes FOREIGN KEY (id_recipe) REFERENCES "Main".recipes(id_recipe) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: user_index to_recipes; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".user_index
    ADD CONSTRAINT to_recipes FOREIGN KEY (id_recipe) REFERENCES "Main".recipes(id_recipe) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: social_media_refs to_social_media; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".social_media_refs
    ADD CONSTRAINT to_social_media FOREIGN KEY (id_social_media) REFERENCES "Main".social_media(id_social_media) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: quotes to_social_media; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".quotes
    ADD CONSTRAINT to_social_media FOREIGN KEY (id_social_media) REFERENCES "Main".social_media(id_social_media) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: tag_index to_tags; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".tag_index
    ADD CONSTRAINT to_tags FOREIGN KEY (id_tag) REFERENCES "Main".tags(id_tag) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: documents to_users; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".documents
    ADD CONSTRAINT to_users FOREIGN KEY (id_user) REFERENCES "Main".users(id_user) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: feed to_users; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".feed
    ADD CONSTRAINT to_users FOREIGN KEY (id_user) REFERENCES "Main".users(id_user) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: quotes to_users; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".quotes
    ADD CONSTRAINT to_users FOREIGN KEY (id_user) REFERENCES "Main".users(id_user) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: user_index to_users; Type: FK CONSTRAINT; Schema: Main; Owner: it19055
--

ALTER TABLE ONLY "Main".user_index
    ADD CONSTRAINT to_users FOREIGN KEY (id_user) REFERENCES "Main".users(id_user) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

