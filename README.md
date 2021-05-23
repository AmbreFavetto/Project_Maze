**Étapes a suivre pour faire fonctionner la base de données**

  1 - Installer le logiciel XAMPP afin d'avoir un serveur local Apache contenant MySQL, PHP (nécessaire pour Composer) :
          https://www.apachefriends.org/xampp-files/7.3.28/xampp-windows-x64-7.3.28-1-VC15-installer.exe

  2 - Installer le logiciel Composer (lors de l'étape de la séléction du command-line PHP, veuillez sélectionner "php.exe" présent dans ...\XAMPP\php\)
      (nécéssaire pour Laravel Installer) :
          https://getcomposer.org/Composer-Setup.exe

  3 - Installer Laravel Installer à l'aide d'une commande (via une invite de commande dans le chemin d'accès ...\Xampp\htdocs\Laravel) (Dossier Laravel a créer) :
        **composer global require laravel/installer**

  4 - Déplacer le fichier TrueSlimeMaze (présent sur git dans la branche bdd-branch) dans le dossier ...\Xampp\htdocs\Laravel

  5 - Ouvrir le logiciel XAMPP afin de démarer les serveurs Apache et MySQL (bouton Start sur la ligne Apache et MySQL)

  6 - Cliquez sur le bouton Admin sur la ligne du serveur MySQL afin de se rendre dans notre gestionnaire de base de données
  
  7 - Créer une base de données se nommant "trueslimemaze" dans le gestionnaire de base de données

  8 - Créer les tables dans la base de données à l'aide d'une commande (via une invite de commande dans le chemin d'accès ...\Xampp\htdocs\Laravel\TrueSlimeMaze) :
        **php artisan migrate**

  9 - Lancer le serveur local Laravel à l'aide d'une commande (via une invite de commande dans le chemin d'accès ...\Xampp\htdocs\Laravel\TrueSlimeMaze) :  
        **php artisan serve --port=8080**
