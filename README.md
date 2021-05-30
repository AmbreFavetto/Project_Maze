# Project_Maze

## -- Présentation --

__Ce projet est un jeu vidéo de type “Labyrinthe”. L’utilisateur va créer des niveaux, et voir
comment l’IA du jeu s’en sort dessus. Il contient 3 composantes : deux IHM et une BDD__

## -- Fonctionnalités --

• __modèle de données :__ *Difficulté : 3*   

  o des types d’obstacles, avec pour chacun :  
    ▪ s'ils sont traversables ou non  
    ▪ leur effet sur l’IA si on les traverse  
    ▪ leur nom  
    ▪ leur apparence  
    ▪ le nombre minimum contenu dans un niveau  
    ▪ le nombre maximum dans un niveau  
  o des niveaux, avec pour chacun :  
    ▪ un nom  
    ▪ un créateur  
    ▪ une date de création  
    ▪ une date de modification  
    ▪ une composition  
  o des tests de niveau, avec pour chacun :  
    ▪ une référence au niveau  
    ▪ une date de passage  
    ▪ un résultat  
    
• pour les __types d’obstacle__, avoir au minimum :  
  o point de départ  
  o point d’arrivé  
  o mur  
  o piège (met en échec l’IA)  
  o boue (ralenti l’IA)  
  
• le lien avec la BDD doit se faire via un __ORM__ *Difficulté : 4*  

• __Logiciel de test de l’IA__ :  
  • l’utilisateur choisi un niveau crée *Difficulté : 2*  
  • l’IA apparait sur l’élément Point de Départ *Difficulté : 1*  
  • l’IA tente d’atteindre le Point d’arrivé, à l’aide d’un algorithme au choix (Ex :
  machine learning ou pathfinding A*) *Difficulté : 8*  
  • le résultat du test est entré en BDD *Difficulté : 1*  
  
• __Logiciel d’édition de niveau__ :  
  • l’utilisateur doit pouvoir créer ou éditer un niveau existant *Difficulté : 2*  
  • une boite à outils permettant de choisir parmi tous les types d’obstacle
  *Difficulté : 2*  
  • l’utilisateur doit pouvoir placer, déplacer, supprimer des obstacles sur une map
  de jeu 2D *Difficulté : 5*  
  
  
*Degré de difficulté total : 28 points*

__Pour plus d'infos sur l'avancée du projet cf. Maze_Doc__
