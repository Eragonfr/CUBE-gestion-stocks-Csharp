CREATE TABLE user (
    id int ++,
    username string,
    name string,
    firstname string,
    password string
)


CREATE TABLE salarie
(
    userId: int ++ /* meme id que user */
    poste string

)

CREATE TABLE histcom /*table de jointure historique commande*/
(
    userID  int
    commmandeid int ++
)

CREATE TABLE client
(
    userID int
    adressID int
    email string
)

CREATE TABLE adresse
(
  id int ++
  codePostal string
  nomRue string,
  numRue string,
  voie  string,
  pays: string
  ville string
)

CREATE TABLE article
(
 nomProduit string
 fournisseur string,
 id int ++,
 stock int,
 description string,
 typeVin string,
 provenance string,
 medaille string,
 annee int,
 domaine string,
CREATE TABLE fournisseur
(
 id int ++
 nom string,
 adresseId int,
 telephone string

)

CREATE TABLE commande
(
    id int ++
    articleId,
    dateCommande int (date),
    quantite int,
    dateLivraison int (date),
    prix float
)

CREATE TABLE articleFournisseur /*table de jointure */
(
articleId int 
fournisseurId int
)

CREATE TABLE articleCommande
(
articleId string,
commandeId string
)

