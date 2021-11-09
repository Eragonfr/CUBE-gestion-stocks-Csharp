-- Drop conflicting tables
DROP TABLE IF EXISTS article_join_commande;
DROP TABLE IF EXISTS article_join_fournisseur;
DROP TABLE IF EXISTS hist_join_com;
DROP TABLE IF EXISTS client;
DROP TABLE IF EXISTS salarie;
DROP TABLE IF EXISTS fournisseur;
DROP TABLE IF EXISTS commande;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS article;
DROP TABLE IF EXISTS adresse;

-- Adresses
CREATE TABLE adresse (
    id SERIAL PRIMARY KEY,
    codepostal VARCHAR(10) NOT NULL,
    nomrue VARCHAR(255) NOT NULL,
    voie VARCHAR(255),
    pays VARCHAR(255) NOT NULL,
    ville VARCHAR(255) NOT NULL
);

-- Articles/Products
CREATE TABLE article (
    id SERIAL PRIMARY KEY,
    nom VARCHAR(255) NOT NULL,
    stock INT NOT NULL,
    description text,
    producttype VARCHAR(255) NOT NULL,
    provenance VARCHAR(255) NOT NULL,
    medaille VARCHAR(255),
    annee DATE NOT NULL,
    domaine VARCHAR(255) NOT NULL
);

-- Users
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(255) NOT NULL UNIQUE,
    lastname VARCHAR(255) NOT NULL,
    firstname VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL
);

-- Commands
CREATE TABLE commande (
    id SERIAL PRIMARY KEY,
    datecommande DATE NOT NULL,
    datelivraison DATE,
    quantite INT NOT NULL,
    prix NUMERIC NOT NULL
);

-- Fournisseurs
CREATE TABLE fournisseur (
    id SERIAL PRIMARY KEY,
    nom VARCHAR(255) NOT NULL,
    adresse INT NOT NULL UNIQUE,
    telephone VARCHAR(20) UNIQUE
);

-- Salaries
CREATE TABLE salarie (
    users INT NOT NULL UNIQUE,
    poste VARCHAR(255) NOT NULL,
	FOREIGN KEY (users) REFERENCES users (id)
);

-- Clients
CREATE TABLE client (
    users INT NOT NULL UNIQUE,
    adresse INT NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
	FOREIGN KEY (users) REFERENCES users (id),
	FOREIGN KEY (adresse) REFERENCES adresse (id)
);

-- With that we can know the articles in a command
CREATE TABLE article_join_commande (
    article INT NOT NULL,
    commande INT NOT NULL,
	FOREIGN KEY (article) REFERENCES article (id),
	FOREIGN KEY (commande) REFERENCES commande (id)
);

-- With this one we know whitch fournisseur have witch article
CREATE TABLE article_join_fournisseur (
    article INT NOT NULL,
    fournisseur INT NOT NULL,
	FOREIGN KEY (article) REFERENCES article (id),
	FOREIGN KEY (fournisseur) REFERENCES fournisseur (id)
);

-- This is the historic of commands from the userss
CREATE TABLE hist_join_com (
    users INT NOT NULL,
    commande INT NOT NULL,
	FOREIGN KEY (users) REFERENCES users (id),
	FOREIGN KEY (commande) REFERENCES commande (id)
);
