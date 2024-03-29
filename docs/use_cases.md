# Use cases

``` plantuml
@startuml
left to right direction
actor "Utilisateur" as j
rectangle Dou_Shou_Qi{
  usecase "Lancer une nouvelle partie" as UC1
  usecase "Charger une ancienne partie" as UC2
  usecase "Regarder les crédit" as UC3
  usecase "Regarder le tableau des Scores" as UC4
  usecase "Changer options" as UC8
  usecase "Activer/Désactiver le son" as UC9
  usecase "Changer le thème" as UC10
  usecase "Entrer noms des joueurs" as UC5
  usecase "Activer règle" as UC6
  usecase "Jouer" as UC7
  usecase "Importer joueur" as UC11
  usecase "Sauvegarder la partie" as UC12
  usecase "Quitter la partie" as UC13
  
}
j-- UC1
j-- UC2
j-- UC3
j-- UC4
j-- UC8
UC1 ---|> UC5 
UC1 ---|> UC11 
UC1 <... UC6 : <extend>
UC5 ...> UC7 : <include>
UC2 ....> UC7 : <include>
UC11 ...> UC7 : <include>
UC8 --|> UC9 
UC8 --|> UC10
UC7 --|> UC12
UC7 --|> UC13
@enduml
```

| USE CASE | Lancer une nouvelle partie |
| :----------- |:----------------- |
| Objectif | Pouvoir jouer 
              au jeu |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | deux joueurs veulent commencer une toute nouvelle parti |
| Conditions de Fin | afzaev |

| USE CASE | Charger une ancienne partie |
| :----------- |:----------------- |
| Objectif | Pouvoir reprendre une ancienne partie non terminée |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Regarder les crédit |
| :----------- |:----------------- |
| Objectif | Regarder les différents créateurs du jeu |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Regarder le tableau des Scores |
| :----------- |:----------------- |
| Objectif | Regarder le classement des différents joueurs en fonction de leur nombre de victoire |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Changer options |
| :----------- |:----------------- |
| Objectif | Apporter des modifications à l'application |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Activer/Désactiver le son |
| :----------- |:----------------- |
| Objectif | Soit activer, soit désactiver les sons de l'application |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Changer le thème |
| :----------- |:----------------- |
| Objectif | Modifier les thèmes général de l'application |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Entrer noms des joueurs |
| :----------- |:----------------- |
| Objectif | Ecrire les noms des deux joueurs qui vont joueur une nouvelle partie |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Importer joueur |
| :----------- |:----------------- |
| Objectif | Utiliser des joueurs déja existant dans le jeux |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Activer règle |
| :----------- |:----------------- |
| Objectif | Pouvoir jouer à la variante du jeu |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | afzaev |
| Conditions de Fin | afzaev |

| USE CASE | Jouer |
| :----------- |:----------------- |
| Objectif | Lancer la nouvelle partie après l'avoir configurer |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | deux joueurs veulent jouer l'un contre l'autre |
| Conditions de Fin | afzaev |

| USE CASE | Sauvegarder la partie |
| :----------- |:----------------- |
| Objectif | Quitter la partie en cours et la sauvegarder pour pouvoir la relancer plus tard |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | Les joueurs veulent arrèter la partie en la sauvegardant |
| Conditions de Fin | afzaev |

| USE CASE | Quitter la partie |
| :----------- |:----------------- |
| Objectif | Quitter la partie en cours |
| Acteur | Utilisateur |
| Conditions initial | afzaev |
| Scénario d'utilisation | Les joueurs veulent arrèter la partie sans la sauvegarder |
| Conditions de Fin | afzaev |