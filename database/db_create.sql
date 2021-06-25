create table "Main".categories
(
	id_category bigserial not null
		constraint categories_pk
			primary key,
	name text not null,
	description text default 'todo'::text not null
);

alter table "Main".categories owner to postgres;

create table "Main".document_types
(
	id_document_type bigserial not null
		constraint document_types_pk
			primary key,
	name text not null
);

alter table "Main".document_types owner to postgres;

create table "Main".emails
(
	id_email bigserial not null
		constraint emails_pk
			primary key,
	email varchar not null
);

comment on column "Main".emails.email is 'email from app';

alter table "Main".emails owner to postgres;

create table "Main".pictures
(
	id_picture bigserial not null
		constraint pictures_pk
			primary key,
	alternative_text text default 'todo'::text not null,
	id_category bigint not null
		constraint pictures_fk
			references "Main".categories
				on update cascade on delete cascade,
	published boolean default false not null,
	source_header text,
	source_preview text,
	source_original text
);

alter table "Main".pictures owner to postgres;

create table "Main".users
(
	id_user uuid default uuid_generate_v4() not null
		constraint authors_pk
			primary key,
	name varchar not null,
	surname varchar not null,
	id_email bigint default 0 not null
		constraint to_emails
			references "Main".emails
				on update cascade on delete cascade,
	id_picture bigint default 0 not null
		constraint authors_fk
			references "Main".pictures
				on update cascade on delete cascade
);

comment on column "Main".users.id_email is 'Main email';

comment on column "Main".users.id_picture is 'Author Pic';

alter table "Main".users owner to postgres;

create table "Main".documents
(
	id_document bigserial not null
		constraint documents_pk
			primary key,
	source text not null,
	name text not null,
	description text not null,
	id_document_type bigint not null
		constraint documents_fk
			references "Main".document_types
				on update cascade on delete cascade,
	published boolean not null,
	id_user uuid not null
		constraint to_users
			references "Main".users
				on update cascade on delete cascade
);

comment on column "Main".documents.published is 'Pieejams publiski?';

comment on column "Main".documents.id_user is 'Dokumenta ievietotājs,. autors u.t.t';

alter table "Main".documents owner to postgres;

create table "Main".posts
(
	id_post bigserial not null
		constraint posts_pk
			primary key,
	id_cat bigint not null
		constraint to_cat
			references "Main".categories
				on update cascade on delete cascade,
	title text not null,
	description text not null,
	body text,
	id_user uuid not null
		constraint to_auth
			references "Main".users
				on update cascade on delete cascade,
	id_picture bigint default 0 not null
		constraint to_pic
			references "Main".pictures
				on update cascade on delete cascade,
	date date default now() not null,
	published boolean not null
);

comment on column "Main".posts.body is 'HTML code';

comment on column "Main".posts.id_user is 'Author. Author pic should be added to Author table.';

comment on column "Main".posts.id_picture is 'Mainly for Hero/Header picture';

alter table "Main".posts owner to postgres;

create table "Main".login_data
(
	id_user uuid not null
		constraint users_pk
			primary key
		constraint login_data_fk
			references "Main".users
				on update cascade on delete cascade,
	username varchar not null,
	password varchar not null,
	account_created date default now() not null
);

alter table "Main".login_data owner to postgres;

create table "Main".icons
(
	id_icon bigserial not null
		constraint icons_pk
			primary key,
	name varchar not null,
	source varchar not null
);

alter table "Main".icons owner to postgres;

create table "Main".social_media
(
	id_social_media bigserial not null
		constraint social_media_pk
			primary key,
	name text not null,
	base_link text not null,
	id_icon bigint not null
		constraint to_icons
			references "Main".icons
);

comment on column "Main".social_media.name is 'name of social media';

comment on column "Main".social_media.base_link is 'base link';

comment on column "Main".social_media.id_icon is 'from font-awesome';

alter table "Main".social_media owner to postgres;

create table "Main".social_media_refs
(
	id_social_media_ref bigserial not null
		constraint social_media_refs_pk
			primary key,
	id_user uuid not null
		constraint to_authors
			references "Main".users
				on update cascade on delete cascade,
	id_social_media bigint not null
		constraint to_social_media
			references "Main".social_media
				on update cascade on delete cascade,
	href text not null
);

comment on column "Main".social_media_refs.id_social_media is 'social media name';

comment on column "Main".social_media_refs.href is 'href to social media account';

alter table "Main".social_media_refs owner to postgres;

create table "Main".feed
(
	id_feed bigserial not null
		constraint feed_pk
			primary key,
	id_user uuid not null
		constraint to_users
			references "Main".users
				on update cascade on delete cascade,
	feed_name varchar default 'feed'::character varying not null,
	id_icon bigint default 0 not null
		constraint to_icons
			references "Main".icons
				on update set default on delete set default,
	feed_url varchar not null,
	timestamp date default now() not null
);

alter table "Main".feed owner to postgres;

create table "Main".quotes
(
	id_quote bigserial not null
		constraint quotes_pk
			primary key,
	id_user uuid not null
		constraint to_users
			references "Main".users
				on update cascade on delete cascade,
	body text not null,
	author varchar,
	id_social_media bigint not null
		constraint to_social_media
			references "Main".social_media
				on update cascade on delete cascade
);

alter table "Main".quotes owner to postgres;


