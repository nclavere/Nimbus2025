# Nimbus2025

19/11/2025 : note pour les DI 24

Les points ajoutés :

- Chargement des listes de paramètres au lancement de l'application, pour simplifier le code et optimiser les requêtes à l'API
- L'obervableCollection des vols charge maintenant des VueModèles de vol au lieu des VolDto : c'est une bonne pratique et, là encore, on simplifie le code 
- Ajout du bouton de création d'un nouveau vol, en se plaçant par défaut sur l'élément ajouté
- La méthode d'enregistrement teste alors s'il s'agit d'un nouveau vol (=> POST) ou d'une modification (=> PUT)

Reste à faire pour terminer cet écran :

- La gestion des heures dans le formulaire de saisie (il n'y a que la date pour l'instant)
- Les appels POST et PUT à l'API dans l'enregistrement

A vous de jouer ! <br/>
Essayez d'implémenter un écran de bout en bout ... Enjoy 😉
