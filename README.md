# Project_Maze

-- Présentation --

Ce projet contient 3 composantes : une API, une IHM et une BDD. Le but est de créer une IHM
de type CRUD qui s’adaptera à tout modèle de données.
Fonctionnalités

  • modèle de données (vous modifierez ce modèle de vous-même afin de tester la partie
  adaptative) : Difficulté : 2
  o des clients, composés de :
    ▪ un nom, un prénom
    ▪ une adresse mail
    ▪ une date de création
  o des factures, composés de :
    ▪ une référence à un client
    ▪ une date d’émission
    ▪ une donnée indiquant si elle a été payé ou non
    ▪ une date de paiement
    ▪ un prix
    ▪ des références à des produits
  o des produits, composés de :
    ▪ un nom
    ▪ un stock
    ▪ une photo
    ▪ un prix
    ▪ des références à des factures

• L’API REST :
  o doit faire le lien avec la BDD via un ORM (l’ORM peut même créer la BDD)
  Difficulté : 4
  o doit fournir des routes HTTP pour toutes les actions CRUD de toutes les tables
  du modèle de données Difficulté : 5
  o doit fournir (en une route HTTP ou plusieurs) toutes les informations relatives
  à la composition du modèle de données (comme un MCD mais en JSON)
  Difficulté : 3

• L’IHM :
  o doit fournir des pages pour toutes les actions CRUD de toutes les tables du
  modèle de données (Ex : par table, une page liste / suppression et une page
  ajout / modification) Difficulté : 3
  o l’IHM doit utiliser la même page pour une action CRUD, quel que soit la table.
  La page devra se construire toute seule en fonction des informations de
  composition du modèle fournis par l’API Difficulté : 6
  o pour ce faire, il faudra créer des composants génériques pour chaque type de
  champ Difficulté : 6
  
Degré de difficulté total : 29 points
