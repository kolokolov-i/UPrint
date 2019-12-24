﻿BEGIN TRANSACTION;

DROP TABLE IF EXISTS person, task, printer, job, model CASCADE;

CREATE TABLE person (
	id SERIAL2,
	login VARCHAR(20) NOT NULL,
	password VARCHAR(20),
	name VARCHAR(50),
	type CHAR(1) NOT NULL,
	active BOOLEAN DEFAULT TRUE,
	PRIMARY KEY (id),
	CONSTRAINT unique_login_constraint UNIQUE (login)
);

CREATE TABLE model (
	id SERIAL4,
	name VARCHAR(50) NOT NULL,
	path VARCHAR(100) NOT NULL,
	PRIMARY KEY (id)
);

CREATE TABLE job (
	id SERIAL4,
	name VARCHAR(50),
	date_add TIMESTAMP,
	description VARCHAR(500),
	person SMALLINT REFERENCES person(id) ON UPDATE RESTRICT ON DELETE RESTRICT,
	model INTEGER REFERENCES model(id) ON UPDATE RESTRICT ON DELETE RESTRICT,
	PRIMARY KEY (id)
);

CREATE TABLE printer (
	id SERIAL2,
	name VARCHAR(50) NOT NULL,
	status CHAR(1),
	active BOOLEAN DEFAULT TRUE,
	PRIMARY KEY (id),
	CONSTRAINT unique_name_constraint UNIQUE (name)
);

CREATE TABLE task (
	id SERIAL4,
	name VARCHAR(50),
	person INTEGER REFERENCES person(id) ON UPDATE RESTRICT ON DELETE RESTRICT,
	job INTEGER REFERENCES job(id) ON UPDATE RESTRICT ON DELETE RESTRICT,
	date_add TIMESTAMP DEFAULT NOW(),
	time_start TIMESTAMP NULL,
	time_end TIMESTAMP NULL,
	status CHAR(1),
	printer SMALLINT REFERENCES printer(id) ON UPDATE RESTRICT ON DELETE RESTRICT,
	PRIMARY KEY (id)
);

COMMIT TRANSACTION;